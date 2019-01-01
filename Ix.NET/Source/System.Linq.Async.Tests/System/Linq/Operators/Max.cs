﻿// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the Apache 2.0 License.
// See the LICENSE file in the project root for more information. 

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace Tests
{
    public class Max : AsyncEnumerableTests
    {
        [Fact]
        public async Task Max_Null()
        {
            // Max(IAE<P>)

            await Assert.ThrowsAsync<ArgumentNullException>(() => AsyncEnumerable.MaxAsync(default(IAsyncEnumerable<int>)));
            await Assert.ThrowsAsync<ArgumentNullException>(() => AsyncEnumerable.MaxAsync(default(IAsyncEnumerable<int?>)));
            await Assert.ThrowsAsync<ArgumentNullException>(() => AsyncEnumerable.MaxAsync(default(IAsyncEnumerable<long>)));
            await Assert.ThrowsAsync<ArgumentNullException>(() => AsyncEnumerable.MaxAsync(default(IAsyncEnumerable<long?>)));
            await Assert.ThrowsAsync<ArgumentNullException>(() => AsyncEnumerable.MaxAsync(default(IAsyncEnumerable<double>)));
            await Assert.ThrowsAsync<ArgumentNullException>(() => AsyncEnumerable.MaxAsync(default(IAsyncEnumerable<double?>)));
            await Assert.ThrowsAsync<ArgumentNullException>(() => AsyncEnumerable.MaxAsync(default(IAsyncEnumerable<float>)));
            await Assert.ThrowsAsync<ArgumentNullException>(() => AsyncEnumerable.MaxAsync(default(IAsyncEnumerable<float?>)));
            await Assert.ThrowsAsync<ArgumentNullException>(() => AsyncEnumerable.MaxAsync(default(IAsyncEnumerable<decimal>)));
            await Assert.ThrowsAsync<ArgumentNullException>(() => AsyncEnumerable.MaxAsync(default(IAsyncEnumerable<decimal?>)));

            // Max(IAE<P>, CT)

            await Assert.ThrowsAsync<ArgumentNullException>(() => AsyncEnumerable.MaxAsync(default(IAsyncEnumerable<int>), CancellationToken.None));
            await Assert.ThrowsAsync<ArgumentNullException>(() => AsyncEnumerable.MaxAsync(default(IAsyncEnumerable<int?>), CancellationToken.None));
            await Assert.ThrowsAsync<ArgumentNullException>(() => AsyncEnumerable.MaxAsync(default(IAsyncEnumerable<long>), CancellationToken.None));
            await Assert.ThrowsAsync<ArgumentNullException>(() => AsyncEnumerable.MaxAsync(default(IAsyncEnumerable<long?>), CancellationToken.None));
            await Assert.ThrowsAsync<ArgumentNullException>(() => AsyncEnumerable.MaxAsync(default(IAsyncEnumerable<double>), CancellationToken.None));
            await Assert.ThrowsAsync<ArgumentNullException>(() => AsyncEnumerable.MaxAsync(default(IAsyncEnumerable<double?>), CancellationToken.None));
            await Assert.ThrowsAsync<ArgumentNullException>(() => AsyncEnumerable.MaxAsync(default(IAsyncEnumerable<float>), CancellationToken.None));
            await Assert.ThrowsAsync<ArgumentNullException>(() => AsyncEnumerable.MaxAsync(default(IAsyncEnumerable<float?>), CancellationToken.None));
            await Assert.ThrowsAsync<ArgumentNullException>(() => AsyncEnumerable.MaxAsync(default(IAsyncEnumerable<decimal>), CancellationToken.None));
            await Assert.ThrowsAsync<ArgumentNullException>(() => AsyncEnumerable.MaxAsync(default(IAsyncEnumerable<decimal?>), CancellationToken.None));

            // Max<T>(IAE<T>, Func<T, P>)

            await Assert.ThrowsAsync<ArgumentNullException>(() => AsyncEnumerable.MaxAsync(default(IAsyncEnumerable<int>), x => x));
            await Assert.ThrowsAsync<ArgumentNullException>(() => AsyncEnumerable.MaxAsync(default(IAsyncEnumerable<int?>), x => x));
            await Assert.ThrowsAsync<ArgumentNullException>(() => AsyncEnumerable.MaxAsync(default(IAsyncEnumerable<long>), x => x));
            await Assert.ThrowsAsync<ArgumentNullException>(() => AsyncEnumerable.MaxAsync(default(IAsyncEnumerable<long?>), x => x));
            await Assert.ThrowsAsync<ArgumentNullException>(() => AsyncEnumerable.MaxAsync(default(IAsyncEnumerable<double>), x => x));
            await Assert.ThrowsAsync<ArgumentNullException>(() => AsyncEnumerable.MaxAsync(default(IAsyncEnumerable<double?>), x => x));
            await Assert.ThrowsAsync<ArgumentNullException>(() => AsyncEnumerable.MaxAsync(default(IAsyncEnumerable<float>), x => x));
            await Assert.ThrowsAsync<ArgumentNullException>(() => AsyncEnumerable.MaxAsync(default(IAsyncEnumerable<float?>), x => x));
            await Assert.ThrowsAsync<ArgumentNullException>(() => AsyncEnumerable.MaxAsync(default(IAsyncEnumerable<decimal>), x => x));
            await Assert.ThrowsAsync<ArgumentNullException>(() => AsyncEnumerable.MaxAsync(default(IAsyncEnumerable<decimal?>), x => x));

            await Assert.ThrowsAsync<ArgumentNullException>(() => AsyncEnumerable.MaxAsync(AsyncEnumerable.Empty<int>(), default(Func<int, int>)));
            await Assert.ThrowsAsync<ArgumentNullException>(() => AsyncEnumerable.MaxAsync(AsyncEnumerable.Empty<int>(), default(Func<int, int?>)));
            await Assert.ThrowsAsync<ArgumentNullException>(() => AsyncEnumerable.MaxAsync(AsyncEnumerable.Empty<int>(), default(Func<int, long>)));
            await Assert.ThrowsAsync<ArgumentNullException>(() => AsyncEnumerable.MaxAsync(AsyncEnumerable.Empty<int>(), default(Func<int, long?>)));
            await Assert.ThrowsAsync<ArgumentNullException>(() => AsyncEnumerable.MaxAsync(AsyncEnumerable.Empty<int>(), default(Func<int, double>)));
            await Assert.ThrowsAsync<ArgumentNullException>(() => AsyncEnumerable.MaxAsync(AsyncEnumerable.Empty<int>(), default(Func<int, double?>)));
            await Assert.ThrowsAsync<ArgumentNullException>(() => AsyncEnumerable.MaxAsync(AsyncEnumerable.Empty<int>(), default(Func<int, float>)));
            await Assert.ThrowsAsync<ArgumentNullException>(() => AsyncEnumerable.MaxAsync(AsyncEnumerable.Empty<int>(), default(Func<int, float?>)));
            await Assert.ThrowsAsync<ArgumentNullException>(() => AsyncEnumerable.MaxAsync(AsyncEnumerable.Empty<int>(), default(Func<int, decimal>)));
            await Assert.ThrowsAsync<ArgumentNullException>(() => AsyncEnumerable.MaxAsync(AsyncEnumerable.Empty<int>(), default(Func<int, decimal?>)));

            // Max<T>(IAE<T>, Func<T, P>, CT)

            await Assert.ThrowsAsync<ArgumentNullException>(() => AsyncEnumerable.MaxAsync(default(IAsyncEnumerable<int>), x => x, CancellationToken.None));
            await Assert.ThrowsAsync<ArgumentNullException>(() => AsyncEnumerable.MaxAsync(default(IAsyncEnumerable<int?>), x => x, CancellationToken.None));
            await Assert.ThrowsAsync<ArgumentNullException>(() => AsyncEnumerable.MaxAsync(default(IAsyncEnumerable<long>), x => x, CancellationToken.None));
            await Assert.ThrowsAsync<ArgumentNullException>(() => AsyncEnumerable.MaxAsync(default(IAsyncEnumerable<long?>), x => x, CancellationToken.None));
            await Assert.ThrowsAsync<ArgumentNullException>(() => AsyncEnumerable.MaxAsync(default(IAsyncEnumerable<double>), x => x, CancellationToken.None));
            await Assert.ThrowsAsync<ArgumentNullException>(() => AsyncEnumerable.MaxAsync(default(IAsyncEnumerable<double?>), x => x, CancellationToken.None));
            await Assert.ThrowsAsync<ArgumentNullException>(() => AsyncEnumerable.MaxAsync(default(IAsyncEnumerable<float>), x => x, CancellationToken.None));
            await Assert.ThrowsAsync<ArgumentNullException>(() => AsyncEnumerable.MaxAsync(default(IAsyncEnumerable<float?>), x => x, CancellationToken.None));
            await Assert.ThrowsAsync<ArgumentNullException>(() => AsyncEnumerable.MaxAsync(default(IAsyncEnumerable<decimal>), x => x, CancellationToken.None));
            await Assert.ThrowsAsync<ArgumentNullException>(() => AsyncEnumerable.MaxAsync(default(IAsyncEnumerable<decimal?>), x => x, CancellationToken.None));

            await Assert.ThrowsAsync<ArgumentNullException>(() => AsyncEnumerable.MaxAsync(AsyncEnumerable.Empty<int>(), default(Func<int, int>), CancellationToken.None));
            await Assert.ThrowsAsync<ArgumentNullException>(() => AsyncEnumerable.MaxAsync(AsyncEnumerable.Empty<int>(), default(Func<int, int?>), CancellationToken.None));
            await Assert.ThrowsAsync<ArgumentNullException>(() => AsyncEnumerable.MaxAsync(AsyncEnumerable.Empty<int>(), default(Func<int, long>), CancellationToken.None));
            await Assert.ThrowsAsync<ArgumentNullException>(() => AsyncEnumerable.MaxAsync(AsyncEnumerable.Empty<int>(), default(Func<int, long?>), CancellationToken.None));
            await Assert.ThrowsAsync<ArgumentNullException>(() => AsyncEnumerable.MaxAsync(AsyncEnumerable.Empty<int>(), default(Func<int, double>), CancellationToken.None));
            await Assert.ThrowsAsync<ArgumentNullException>(() => AsyncEnumerable.MaxAsync(AsyncEnumerable.Empty<int>(), default(Func<int, double?>), CancellationToken.None));
            await Assert.ThrowsAsync<ArgumentNullException>(() => AsyncEnumerable.MaxAsync(AsyncEnumerable.Empty<int>(), default(Func<int, float>), CancellationToken.None));
            await Assert.ThrowsAsync<ArgumentNullException>(() => AsyncEnumerable.MaxAsync(AsyncEnumerable.Empty<int>(), default(Func<int, float?>), CancellationToken.None));
            await Assert.ThrowsAsync<ArgumentNullException>(() => AsyncEnumerable.MaxAsync(AsyncEnumerable.Empty<int>(), default(Func<int, decimal>), CancellationToken.None));
            await Assert.ThrowsAsync<ArgumentNullException>(() => AsyncEnumerable.MaxAsync(AsyncEnumerable.Empty<int>(), default(Func<int, decimal?>), CancellationToken.None));

            // Max<T>(IAE<T>, Func<T, VT<P>>)

            await Assert.ThrowsAsync<ArgumentNullException>(() => AsyncEnumerable.MaxAsync(default(IAsyncEnumerable<int>), x => new ValueTask<int>(x)));
            await Assert.ThrowsAsync<ArgumentNullException>(() => AsyncEnumerable.MaxAsync(default(IAsyncEnumerable<int?>), x => new ValueTask<int?>(x)));
            await Assert.ThrowsAsync<ArgumentNullException>(() => AsyncEnumerable.MaxAsync(default(IAsyncEnumerable<long>), x => new ValueTask<long>(x)));
            await Assert.ThrowsAsync<ArgumentNullException>(() => AsyncEnumerable.MaxAsync(default(IAsyncEnumerable<long?>), x => new ValueTask<long?>(x)));
            await Assert.ThrowsAsync<ArgumentNullException>(() => AsyncEnumerable.MaxAsync(default(IAsyncEnumerable<double>), x => new ValueTask<double>(x)));
            await Assert.ThrowsAsync<ArgumentNullException>(() => AsyncEnumerable.MaxAsync(default(IAsyncEnumerable<double?>), x => new ValueTask<double?>(x)));
            await Assert.ThrowsAsync<ArgumentNullException>(() => AsyncEnumerable.MaxAsync(default(IAsyncEnumerable<float>), x => new ValueTask<float>(x)));
            await Assert.ThrowsAsync<ArgumentNullException>(() => AsyncEnumerable.MaxAsync(default(IAsyncEnumerable<float?>), x => new ValueTask<float?>(x)));
            await Assert.ThrowsAsync<ArgumentNullException>(() => AsyncEnumerable.MaxAsync(default(IAsyncEnumerable<decimal>), x => new ValueTask<decimal>(x)));
            await Assert.ThrowsAsync<ArgumentNullException>(() => AsyncEnumerable.MaxAsync(default(IAsyncEnumerable<decimal?>), x => new ValueTask<decimal?>(x)));

            await Assert.ThrowsAsync<ArgumentNullException>(() => AsyncEnumerable.MaxAsync(AsyncEnumerable.Empty<int>(), default(Func<int, ValueTask<int>>)));
            await Assert.ThrowsAsync<ArgumentNullException>(() => AsyncEnumerable.MaxAsync(AsyncEnumerable.Empty<int>(), default(Func<int, ValueTask<int?>>)));
            await Assert.ThrowsAsync<ArgumentNullException>(() => AsyncEnumerable.MaxAsync(AsyncEnumerable.Empty<int>(), default(Func<int, ValueTask<long>>)));
            await Assert.ThrowsAsync<ArgumentNullException>(() => AsyncEnumerable.MaxAsync(AsyncEnumerable.Empty<int>(), default(Func<int, ValueTask<long?>>)));
            await Assert.ThrowsAsync<ArgumentNullException>(() => AsyncEnumerable.MaxAsync(AsyncEnumerable.Empty<int>(), default(Func<int, ValueTask<double>>)));
            await Assert.ThrowsAsync<ArgumentNullException>(() => AsyncEnumerable.MaxAsync(AsyncEnumerable.Empty<int>(), default(Func<int, ValueTask<double?>>)));
            await Assert.ThrowsAsync<ArgumentNullException>(() => AsyncEnumerable.MaxAsync(AsyncEnumerable.Empty<int>(), default(Func<int, ValueTask<float>>)));
            await Assert.ThrowsAsync<ArgumentNullException>(() => AsyncEnumerable.MaxAsync(AsyncEnumerable.Empty<int>(), default(Func<int, ValueTask<float?>>)));
            await Assert.ThrowsAsync<ArgumentNullException>(() => AsyncEnumerable.MaxAsync(AsyncEnumerable.Empty<int>(), default(Func<int, ValueTask<decimal>>)));
            await Assert.ThrowsAsync<ArgumentNullException>(() => AsyncEnumerable.MaxAsync(AsyncEnumerable.Empty<int>(), default(Func<int, ValueTask<decimal?>>)));

            // Max<T>(IAE<T>, Func<T, VT<P>>, CT)

            await Assert.ThrowsAsync<ArgumentNullException>(() => AsyncEnumerable.MaxAsync(default(IAsyncEnumerable<int>), x => new ValueTask<int>(x), CancellationToken.None));
            await Assert.ThrowsAsync<ArgumentNullException>(() => AsyncEnumerable.MaxAsync(default(IAsyncEnumerable<int?>), x => new ValueTask<int?>(x), CancellationToken.None));
            await Assert.ThrowsAsync<ArgumentNullException>(() => AsyncEnumerable.MaxAsync(default(IAsyncEnumerable<long>), x => new ValueTask<long>(x), CancellationToken.None));
            await Assert.ThrowsAsync<ArgumentNullException>(() => AsyncEnumerable.MaxAsync(default(IAsyncEnumerable<long?>), x => new ValueTask<long?>(x), CancellationToken.None));
            await Assert.ThrowsAsync<ArgumentNullException>(() => AsyncEnumerable.MaxAsync(default(IAsyncEnumerable<double>), x => new ValueTask<double>(x), CancellationToken.None));
            await Assert.ThrowsAsync<ArgumentNullException>(() => AsyncEnumerable.MaxAsync(default(IAsyncEnumerable<double?>), x => new ValueTask<double?>(x), CancellationToken.None));
            await Assert.ThrowsAsync<ArgumentNullException>(() => AsyncEnumerable.MaxAsync(default(IAsyncEnumerable<float>), x => new ValueTask<float>(x), CancellationToken.None));
            await Assert.ThrowsAsync<ArgumentNullException>(() => AsyncEnumerable.MaxAsync(default(IAsyncEnumerable<float?>), x => new ValueTask<float?>(x), CancellationToken.None));
            await Assert.ThrowsAsync<ArgumentNullException>(() => AsyncEnumerable.MaxAsync(default(IAsyncEnumerable<decimal>), x => new ValueTask<decimal>(x), CancellationToken.None));
            await Assert.ThrowsAsync<ArgumentNullException>(() => AsyncEnumerable.MaxAsync(default(IAsyncEnumerable<decimal?>), x => new ValueTask<decimal?>(x), CancellationToken.None));

            await Assert.ThrowsAsync<ArgumentNullException>(() => AsyncEnumerable.MaxAsync(AsyncEnumerable.Empty<int>(), default(Func<int, ValueTask<int>>), CancellationToken.None));
            await Assert.ThrowsAsync<ArgumentNullException>(() => AsyncEnumerable.MaxAsync(AsyncEnumerable.Empty<int>(), default(Func<int, ValueTask<int?>>), CancellationToken.None));
            await Assert.ThrowsAsync<ArgumentNullException>(() => AsyncEnumerable.MaxAsync(AsyncEnumerable.Empty<int>(), default(Func<int, ValueTask<long>>), CancellationToken.None));
            await Assert.ThrowsAsync<ArgumentNullException>(() => AsyncEnumerable.MaxAsync(AsyncEnumerable.Empty<int>(), default(Func<int, ValueTask<long?>>), CancellationToken.None));
            await Assert.ThrowsAsync<ArgumentNullException>(() => AsyncEnumerable.MaxAsync(AsyncEnumerable.Empty<int>(), default(Func<int, ValueTask<double>>), CancellationToken.None));
            await Assert.ThrowsAsync<ArgumentNullException>(() => AsyncEnumerable.MaxAsync(AsyncEnumerable.Empty<int>(), default(Func<int, ValueTask<double?>>), CancellationToken.None));
            await Assert.ThrowsAsync<ArgumentNullException>(() => AsyncEnumerable.MaxAsync(AsyncEnumerable.Empty<int>(), default(Func<int, ValueTask<float>>), CancellationToken.None));
            await Assert.ThrowsAsync<ArgumentNullException>(() => AsyncEnumerable.MaxAsync(AsyncEnumerable.Empty<int>(), default(Func<int, ValueTask<float?>>), CancellationToken.None));
            await Assert.ThrowsAsync<ArgumentNullException>(() => AsyncEnumerable.MaxAsync(AsyncEnumerable.Empty<int>(), default(Func<int, ValueTask<decimal>>), CancellationToken.None));
            await Assert.ThrowsAsync<ArgumentNullException>(() => AsyncEnumerable.MaxAsync(AsyncEnumerable.Empty<int>(), default(Func<int, ValueTask<decimal?>>), CancellationToken.None));

#if !NO_DEEP_CANCELLATION
            // Max<T>(IAE<T>, Func<T, CT, VT<P>>, CT)

            await Assert.ThrowsAsync<ArgumentNullException>(() => AsyncEnumerable.MaxAsync(default(IAsyncEnumerable<int>), (x, ct) => new ValueTask<int>(x), CancellationToken.None));
            await Assert.ThrowsAsync<ArgumentNullException>(() => AsyncEnumerable.MaxAsync(default(IAsyncEnumerable<int?>), (x, ct) => new ValueTask<int?>(x), CancellationToken.None));
            await Assert.ThrowsAsync<ArgumentNullException>(() => AsyncEnumerable.MaxAsync(default(IAsyncEnumerable<long>), (x, ct) => new ValueTask<long>(x), CancellationToken.None));
            await Assert.ThrowsAsync<ArgumentNullException>(() => AsyncEnumerable.MaxAsync(default(IAsyncEnumerable<long?>), (x, ct) => new ValueTask<long?>(x), CancellationToken.None));
            await Assert.ThrowsAsync<ArgumentNullException>(() => AsyncEnumerable.MaxAsync(default(IAsyncEnumerable<double>), (x, ct) => new ValueTask<double>(x), CancellationToken.None));
            await Assert.ThrowsAsync<ArgumentNullException>(() => AsyncEnumerable.MaxAsync(default(IAsyncEnumerable<double?>), (x, ct) => new ValueTask<double?>(x), CancellationToken.None));
            await Assert.ThrowsAsync<ArgumentNullException>(() => AsyncEnumerable.MaxAsync(default(IAsyncEnumerable<float>), (x, ct) => new ValueTask<float>(x), CancellationToken.None));
            await Assert.ThrowsAsync<ArgumentNullException>(() => AsyncEnumerable.MaxAsync(default(IAsyncEnumerable<float?>), (x, ct) => new ValueTask<float?>(x), CancellationToken.None));
            await Assert.ThrowsAsync<ArgumentNullException>(() => AsyncEnumerable.MaxAsync(default(IAsyncEnumerable<decimal>), (x, ct) => new ValueTask<decimal>(x), CancellationToken.None));
            await Assert.ThrowsAsync<ArgumentNullException>(() => AsyncEnumerable.MaxAsync(default(IAsyncEnumerable<decimal?>), (x, ct) => new ValueTask<decimal?>(x), CancellationToken.None));

            await Assert.ThrowsAsync<ArgumentNullException>(() => AsyncEnumerable.MaxAsync(AsyncEnumerable.Empty<int>(), default(Func<int, CancellationToken, ValueTask<int>>), CancellationToken.None));
            await Assert.ThrowsAsync<ArgumentNullException>(() => AsyncEnumerable.MaxAsync(AsyncEnumerable.Empty<int>(), default(Func<int, CancellationToken, ValueTask<int?>>), CancellationToken.None));
            await Assert.ThrowsAsync<ArgumentNullException>(() => AsyncEnumerable.MaxAsync(AsyncEnumerable.Empty<int>(), default(Func<int, CancellationToken, ValueTask<long>>), CancellationToken.None));
            await Assert.ThrowsAsync<ArgumentNullException>(() => AsyncEnumerable.MaxAsync(AsyncEnumerable.Empty<int>(), default(Func<int, CancellationToken, ValueTask<long?>>), CancellationToken.None));
            await Assert.ThrowsAsync<ArgumentNullException>(() => AsyncEnumerable.MaxAsync(AsyncEnumerable.Empty<int>(), default(Func<int, CancellationToken, ValueTask<double>>), CancellationToken.None));
            await Assert.ThrowsAsync<ArgumentNullException>(() => AsyncEnumerable.MaxAsync(AsyncEnumerable.Empty<int>(), default(Func<int, CancellationToken, ValueTask<double?>>), CancellationToken.None));
            await Assert.ThrowsAsync<ArgumentNullException>(() => AsyncEnumerable.MaxAsync(AsyncEnumerable.Empty<int>(), default(Func<int, CancellationToken, ValueTask<float>>), CancellationToken.None));
            await Assert.ThrowsAsync<ArgumentNullException>(() => AsyncEnumerable.MaxAsync(AsyncEnumerable.Empty<int>(), default(Func<int, CancellationToken, ValueTask<float?>>), CancellationToken.None));
            await Assert.ThrowsAsync<ArgumentNullException>(() => AsyncEnumerable.MaxAsync(AsyncEnumerable.Empty<int>(), default(Func<int, CancellationToken, ValueTask<decimal>>), CancellationToken.None));
            await Assert.ThrowsAsync<ArgumentNullException>(() => AsyncEnumerable.MaxAsync(AsyncEnumerable.Empty<int>(), default(Func<int, CancellationToken, ValueTask<decimal?>>), CancellationToken.None));
#endif

            // Max<T>(IAE<T>)

            await Assert.ThrowsAsync<ArgumentNullException>(() => AsyncEnumerable.MaxAsync(default(IAsyncEnumerable<DateTime>)));

            // Max<T>(IAE<T>, CT)

            await Assert.ThrowsAsync<ArgumentNullException>(() => AsyncEnumerable.MaxAsync(default(IAsyncEnumerable<DateTime>), CancellationToken.None));

            // Max<T>(IAE<T>, Func<T, R>)

            await Assert.ThrowsAsync<ArgumentNullException>(() => AsyncEnumerable.MaxAsync(default(IAsyncEnumerable<DateTime>), x => x));
            await Assert.ThrowsAsync<ArgumentNullException>(() => AsyncEnumerable.MaxAsync(AsyncEnumerable.Empty<DateTime>(), default(Func<DateTime, bool>)));

            // Max<T>(IAE<T>, Func<T, R>, CT)

            await Assert.ThrowsAsync<ArgumentNullException>(() => AsyncEnumerable.MaxAsync(default(IAsyncEnumerable<DateTime>), x => x, CancellationToken.None));
            await Assert.ThrowsAsync<ArgumentNullException>(() => AsyncEnumerable.MaxAsync(AsyncEnumerable.Empty<DateTime>(), default(Func<DateTime, bool>), CancellationToken.None));

            // Max<T>(IAE<T>, Func<T, VT<R>>)

            await Assert.ThrowsAsync<ArgumentNullException>(() => AsyncEnumerable.MaxAsync(default(IAsyncEnumerable<DateTime>), x => new ValueTask<DateTime>(x)));
            await Assert.ThrowsAsync<ArgumentNullException>(() => AsyncEnumerable.MaxAsync(AsyncEnumerable.Empty<DateTime>(), default(Func<DateTime, ValueTask<bool>>)));

            // Max<T>(IAE<T>, Func<T, VT<R>>, CT)

            await Assert.ThrowsAsync<ArgumentNullException>(() => AsyncEnumerable.MaxAsync(default(IAsyncEnumerable<DateTime>), x => new ValueTask<DateTime>(x), CancellationToken.None));
            await Assert.ThrowsAsync<ArgumentNullException>(() => AsyncEnumerable.MaxAsync(AsyncEnumerable.Empty<DateTime>(), default(Func<DateTime, ValueTask<bool>>), CancellationToken.None));

#if !NO_DEEP_CANCELLATION
            // Max<T>(IAE<T>, Func<T, CT, VT<R>>, CT)

            await Assert.ThrowsAsync<ArgumentNullException>(() => AsyncEnumerable.MaxAsync(default(IAsyncEnumerable<DateTime>), (x, ct) => new ValueTask<DateTime>(x), CancellationToken.None));
            await Assert.ThrowsAsync<ArgumentNullException>(() => AsyncEnumerable.MaxAsync(AsyncEnumerable.Empty<DateTime>(), default(Func<DateTime, CancellationToken, ValueTask<bool>>), CancellationToken.None));
#endif
        }

        [Fact]
        public async Task Max1Async()
        {
            var xs = new[] { 2, 7, 3 };
            var ys = xs.ToAsyncEnumerable();
            Assert.Equal(xs.Max(), await ys.MaxAsync());
            Assert.Equal(xs.Max(), await ys.MaxAsync(x => x));
            Assert.Equal(xs.Max(), await ys.MaxAsync(x => new ValueTask<int>(x)));
        }

        [Fact]
        public async Task Max2Async()
        {
            var xs = new[] { 2, default(int?), 3, 1 };
            var ys = xs.ToAsyncEnumerable();
            Assert.Equal(xs.Max(), await ys.MaxAsync());
            Assert.Equal(xs.Max(), await ys.MaxAsync(x => x));
            Assert.Equal(xs.Max(), await ys.MaxAsync(x => new ValueTask<int?>(x)));
        }

        [Fact]
        public async Task Max3Async()
        {
            var xs = new[] { 2L, 7L, 3L };
            var ys = xs.ToAsyncEnumerable();
            Assert.Equal(xs.Max(), await ys.MaxAsync());
            Assert.Equal(xs.Max(), await ys.MaxAsync(x => x));
            Assert.Equal(xs.Max(), await ys.MaxAsync(x => new ValueTask<long>(x)));
        }

        [Fact]
        public async Task Max4Async()
        {
            var xs = new[] { 2L, default(long?), 3L, 1L };
            var ys = xs.ToAsyncEnumerable();
            Assert.Equal(xs.Max(), await ys.MaxAsync());
            Assert.Equal(xs.Max(), await ys.MaxAsync(x => x));
            Assert.Equal(xs.Max(), await ys.MaxAsync(x => new ValueTask<long?>(x)));
        }

        [Fact]
        public async Task Max5Async()
        {
            var xs = new[] { 2.0, 7.0, 3.0 };
            var ys = xs.ToAsyncEnumerable();
            Assert.Equal(xs.Max(), await ys.MaxAsync());
            Assert.Equal(xs.Max(), await ys.MaxAsync(x => x));
            Assert.Equal(xs.Max(), await ys.MaxAsync(x => new ValueTask<double>(x)));
        }

        [Fact]
        public async Task Max6Async()
        {
            var xs = new[] { 2.0, default(double?), 3.0, 1.0 };
            var ys = xs.ToAsyncEnumerable();
            Assert.Equal(xs.Max(), await ys.MaxAsync());
            Assert.Equal(xs.Max(), await ys.MaxAsync(x => x));
            Assert.Equal(xs.Max(), await ys.MaxAsync(x => new ValueTask<double?>(x)));
        }

        [Fact]
        public async Task Max7Async()
        {
            var xs = new[] { 2.0f, 7.0f, 3.0f };
            var ys = xs.ToAsyncEnumerable();
            Assert.Equal(xs.Max(), await ys.MaxAsync());
            Assert.Equal(xs.Max(), await ys.MaxAsync(x => x));
            Assert.Equal(xs.Max(), await ys.MaxAsync(x => new ValueTask<float>(x)));
        }

        [Fact]
        public async Task Max8Async()
        {
            var xs = new[] { 2.0f, default(float?), 3.0f, 1.0f };
            var ys = xs.ToAsyncEnumerable();
            Assert.Equal(xs.Max(), await ys.MaxAsync());
            Assert.Equal(xs.Max(), await ys.MaxAsync(x => x));
            Assert.Equal(xs.Max(), await ys.MaxAsync(x => new ValueTask<float?>(x)));
        }

        [Fact]
        public async Task Max9Async()
        {
            var xs = new[] { 2.0m, 7.0m, 3.0m };
            var ys = xs.ToAsyncEnumerable();
            Assert.Equal(xs.Max(), await ys.MaxAsync());
            Assert.Equal(xs.Max(), await ys.MaxAsync(x => x));
            Assert.Equal(xs.Max(), await ys.MaxAsync(x => new ValueTask<decimal>(x)));
        }

        [Fact]
        public async Task Max10Async()
        {
            var xs = new[] { 2.0m, default(decimal?), 3.0m, 1.0m };
            var ys = xs.ToAsyncEnumerable();
            Assert.Equal(xs.Max(), await ys.MaxAsync());
            Assert.Equal(xs.Max(), await ys.MaxAsync(x => x));
            Assert.Equal(xs.Max(), await ys.MaxAsync(x => new ValueTask<decimal?>(x)));
        }

        [Fact]
        public async Task Max11Async()
        {
            var xs = new[] { DateTime.Now.AddDays(1), DateTime.Now.Subtract(TimeSpan.FromDays(1)), DateTime.Now.AddDays(2), DateTime.Now };
            var ys = xs.ToAsyncEnumerable();
            Assert.Equal(xs.Max(), await ys.MaxAsync());
            Assert.Equal(xs.Max(), await ys.MaxAsync(x => x));
            Assert.Equal(xs.Max(), await ys.MaxAsync(x => new ValueTask<DateTime>(x)));
        }

        [Fact]
        public async Task Max12Async()
        {
            var xs = new[] { "foo", "bar", "qux", "baz", "fred", "wilma" };
            var ys = xs.ToAsyncEnumerable();
            Assert.Equal(xs.Max(), await ys.MaxAsync());
            Assert.Equal(xs.Max(), await ys.MaxAsync(x => x));
            Assert.Equal(xs.Max(), await ys.MaxAsync(x => new ValueTask<string>(x)));
        }
    }
}