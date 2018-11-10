﻿// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the Apache 2.0 License.
// See the LICENSE file in the project root for more information. 

using System.Collections.Generic;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;

namespace System.Linq
{
    public static partial class AsyncEnumerableEx
    {
        public static IAsyncEnumerable<TSource> Amb<TSource>(this IAsyncEnumerable<TSource> first, IAsyncEnumerable<TSource> second)
        {
            if (first == null)
                throw new ArgumentNullException(nameof(first));
            if (second == null)
                throw new ArgumentNullException(nameof(second));

            return new AmbAsyncIterator<TSource>(first, second);
        }

        public static IAsyncEnumerable<TSource> Amb<TSource>(params IAsyncEnumerable<TSource>[] sources)
        {
            if (sources == null)
                throw new ArgumentNullException(nameof(sources));

            return new AmbAsyncIteratorN<TSource>(sources);
        }

        public static IAsyncEnumerable<TSource> Amb<TSource>(this IEnumerable<IAsyncEnumerable<TSource>> sources)
        {
            if (sources == null)
                throw new ArgumentNullException(nameof(sources));

            return new AmbAsyncIteratorN<TSource>(sources.ToArray());
        }

        private sealed class AmbAsyncIterator<TSource> : AsyncIterator<TSource>
        {
            private readonly IAsyncEnumerable<TSource> _first;
            private readonly IAsyncEnumerable<TSource> _second;

            private IAsyncEnumerator<TSource> _enumerator;

            public AmbAsyncIterator(IAsyncEnumerable<TSource> first, IAsyncEnumerable<TSource> second)
            {
                Debug.Assert(first != null);
                Debug.Assert(second != null);

                _first = first;
                _second = second;
            }

            public override AsyncIterator<TSource> Clone()
            {
                return new AmbAsyncIterator<TSource>(_first, _second);
            }

            public override async ValueTask DisposeAsync()
            {
                if (_enumerator != null)
                {
                    await _enumerator.DisposeAsync().ConfigureAwait(false);
                    _enumerator = null;
                }

                await base.DisposeAsync().ConfigureAwait(false);
            }

            protected override async ValueTask<bool> MoveNextCore(CancellationToken cancellationToken)
            {
                switch (state)
                {
                    case AsyncIteratorState.Allocated:
                        var firstEnumerator = _first.GetAsyncEnumerator(cancellationToken);
                        var secondEnumerator = _second.GetAsyncEnumerator(cancellationToken);

                        var firstMoveNext = firstEnumerator.MoveNextAsync().AsTask();
                        var secondMoveNext = secondEnumerator.MoveNextAsync().AsTask();

                        var winner = await Task.WhenAny(firstMoveNext, secondMoveNext).ConfigureAwait(false);

                        //
                        // REVIEW: An alternative option is to call DisposeAsync on the other and await it, but this has two drawbacks:
                        //
                        // 1. Concurrent DisposeAsync while a MoveNextAsync is in flight.
                        // 2. The winner elected by Amb is blocked to yield results until the loser unblocks.
                        //
                        // The approach below has one drawback, namely that exceptions raised by loser are dropped on the floor.
                        //

                        if (winner == firstMoveNext)
                        {
                            _enumerator = firstEnumerator;

                            var ignored = secondMoveNext.ContinueWith(_ =>
                            {
                                secondEnumerator.DisposeAsync();
                            });
                        }
                        else
                        {
                            _enumerator = secondEnumerator;

                            var ignored = firstMoveNext.ContinueWith(_ =>
                            {
                                firstEnumerator.DisposeAsync();
                            });
                        }

                        state = AsyncIteratorState.Iterating;

                        if (await winner.ConfigureAwait(false))
                        {
                            current = _enumerator.Current;
                            return true;
                        }

                        break;

                    case AsyncIteratorState.Iterating:
                        if (await _enumerator.MoveNextAsync().ConfigureAwait(false))
                        {
                            current = _enumerator.Current;
                            return true;
                        }

                        break;
                }

                await DisposeAsync().ConfigureAwait(false);
                return false;
            }
        }

        private sealed class AmbAsyncIteratorN<TSource> : AsyncIterator<TSource>
        {
            private readonly IAsyncEnumerable<TSource>[] _sources;

            private IAsyncEnumerator<TSource> _enumerator;

            public AmbAsyncIteratorN(IAsyncEnumerable<TSource>[] sources)
            {
                Debug.Assert(sources != null);

                _sources = sources;
            }

            public override AsyncIterator<TSource> Clone()
            {
                return new AmbAsyncIteratorN<TSource>(_sources);
            }

            public override async ValueTask DisposeAsync()
            {
                if (_enumerator != null)
                {
                    await _enumerator.DisposeAsync().ConfigureAwait(false);
                    _enumerator = null;
                }

                await base.DisposeAsync().ConfigureAwait(false);
            }

            protected override async ValueTask<bool> MoveNextCore(CancellationToken cancellationToken)
            {
                switch (state)
                {
                    case AsyncIteratorState.Allocated:
                        var n = _sources.Length;

                        var enumerators = new IAsyncEnumerator<TSource>[n];
                        var moveNexts = new ValueTask<bool>[n];

                        for (var i = 0; i < n; i++)
                        {
                            var enumerator = _sources[i].GetAsyncEnumerator(cancellationToken);

                            enumerators[i] = enumerator;
                            moveNexts[i] = enumerator.MoveNextAsync();
                        }

                        var winner = await Task.WhenAny(moveNexts.Select(t => t.AsTask())).ConfigureAwait(false);

                        //
                        // REVIEW: An alternative option is to call DisposeAsync on the other and await it, but this has two drawbacks:
                        //
                        // 1. Concurrent DisposeAsync while a MoveNextAsync is in flight.
                        // 2. The winner elected by Amb is blocked to yield results until all losers unblocks.
                        //
                        // The approach below has one drawback, namely that exceptions raised by any loser are dropped on the floor.
                        //

                        var winnerIndex = Array.IndexOf(moveNexts, winner);

                        _enumerator = enumerators[winnerIndex];

                        for (var i = 0; i < n; i++)
                        {
                            if (i != winnerIndex)
                            {
                                var ignored = moveNexts[i].AsTask().ContinueWith(_ =>
                                {
                                    enumerators[i].DisposeAsync();
                                });
                            }
                        }

                        state = AsyncIteratorState.Iterating;

                        if (await winner.ConfigureAwait(false))
                        {
                            current = _enumerator.Current;
                            return true;
                        }

                        break;

                    case AsyncIteratorState.Iterating:
                        if (await _enumerator.MoveNextAsync().ConfigureAwait(false))
                        {
                            current = _enumerator.Current;
                            return true;
                        }

                        break;
                }

                await DisposeAsync().ConfigureAwait(false);
                return false;
            }
        }
    }
}