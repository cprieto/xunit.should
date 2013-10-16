using System;
using System.Collections.Generic;

namespace Xunit.Should
{
    public static class ThrowsExtensions
    {
        public static void ShouldBeThrownBy<T>(this T expected, Assert.ThrowsDelegate method) where T : Exception {
            var thrown = Assert.Throws<T>(method);
            Assert.Equal(expected, thrown, ExceptionComparer.Instance);
        }

        public static void ShouldBeThrownBy<T>(this T expected, Assert.ThrowsDelegateWithReturn method) where T : Exception {
            var thrown = Assert.Throws<T>(method);
            Assert.Equal(expected, thrown, ExceptionComparer.Instance);
        }

        internal class ExceptionComparer : IEqualityComparer<Exception>
        {
            public static ExceptionComparer Instance = new ExceptionComparer();

            public bool Equals(Exception x, Exception y) {
                return (x.GetType() == y.GetType()) && (String.Compare(x.Message, y.Message, StringComparison.Ordinal) == 0);
            }

            public int GetHashCode(Exception obj) {
                return obj.GetHashCode();
            }
        }
    }
}