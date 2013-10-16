using System;
using System.Collections.Generic;

namespace Xunit.Should.Legacy
{
    public static class ShouldExtensions
    {
        [Obsolete("Use ShouldEqual instead.")]
        public static void ShouldBe<T>(this T self, T other) {
            Assert.Equal(other, self);
        }

        [Obsolete("Use ShouldEqual instead.")]
        public static void ShouldBe<T>(this T self, T other, IEqualityComparer<T> comparer) {
            Assert.Equal(other, self, comparer);
        }

        [Obsolete("Use ShouldNotEqual instead.")]
        public static void ShouldNotBe<T>(this T self, T other) {
            Assert.NotEqual(other, self);
        }

        [Obsolete("Use ShouldNotEqual instead.")]
        public static void ShouldNotBe<T>(this T self, T other, IEqualityComparer<T> comparer) {
            Assert.NotEqual(other, self, comparer);
        }
    }
}