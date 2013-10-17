using System;
using System.Collections.Generic;

namespace Xunit.Should
{
    public static class ThrowsExtensions
    {
        public static void ShouldBeThrownBy<T>(this T expected, Assert.ThrowsDelegate testCode) where T : Exception {
            var thrown = Assert.Throws<T>(testCode);
            Assert.Equal(expected, thrown, ExceptionComparer.Instance);
        }

        public static void ShouldBeThrownBy<T>(this T expected, Assert.ThrowsDelegateWithReturn testCode) where T : Exception {
            var thrown = Assert.Throws<T>(testCode);
            Assert.Equal(expected, thrown, ExceptionComparer.Instance);
        }

        public static void ShouldThrow<T>(this Action testCode, string message = null) where T : Exception {
            var thrown = Assert.Throws<T>(() => testCode);
            if (message != null) {
                Assert.Equal(message, thrown.Message);
            }
        }

        public static void ShouldThrow<T>(Func<object> testCode, string message = null) where T : Exception {
            var thrown = Assert.Throws<T>(() => testCode);
            if (message != null) {
                Assert.Equal(message, thrown.Message);
            }
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