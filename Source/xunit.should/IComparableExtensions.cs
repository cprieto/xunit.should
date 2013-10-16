using System;
using System.Collections.Generic;

using Xunit.Sdk;

namespace Xunit.Should
{
    public static class ComparableShouldExtensions
    {
        public static void ShouldBeGreaterThan<T>(this T actual, T expected) where T : IComparable<T> {
            if (actual.CompareTo(expected) <= 0) {
                throw new InRangeException(actual, expected, false, null, false);
            }
        }

        public static void ShouldBeGreaterThan<T>(this T actual, T expected, IComparer<T> comparer) {
            if (comparer.Compare(actual, expected) <= 0) {
                throw new InRangeException(actual, expected, false, null, false);
            }
        }

        public static void ShouldBeGreaterThanOrEqual<T>(this T actual, T expected) where T : IComparable<T> {
            if (actual.CompareTo(expected) < 0) {
                throw new InRangeException(actual, expected, true, null, false);
            }
        }

        public static void ShouldBeGreaterThanOrEqualTo<T>(this T actual, T expected, IComparer<T> comparer) {
            if (comparer.Compare(actual, expected) < 0) {
                throw new InRangeException(actual, expected, true, null, false);
            }
        }

        public static void ShouldBeInRange<T>(this T actual, T low, T high) where T : IComparable<T> {
            ShouldBeInRange(actual, low, true, high, true);
        }

        public static void ShouldBeInRange<T>(this T actual, T low, T high, IComparer<T> comparer) {
            ShouldBeInRange(actual, low, true, high, true, comparer);
        }

        public static void ShouldBeInRange<T>(this T actual, T low, bool lowInclusive, T high, bool highInclusive) where T : IComparable<T> {
            int compareLow = actual.CompareTo(low);
            int compareHigh = actual.CompareTo(high);
            if ((lowInclusive && compareLow < 0) || (!lowInclusive && compareLow <= 0) || (highInclusive && compareHigh > 0) ||
                (!highInclusive && compareHigh >= 0)) {
                throw new InRangeException(actual, low, lowInclusive, high, highInclusive);
            }
        }

        public static void ShouldBeInRange<T>(this T actual, T low, bool lowInclusive, T high, bool highInclusive, IComparer<T> comparer) {
            int compareLow = comparer.Compare(actual, low);
            int compareHigh = comparer.Compare(actual, high);
            if ((lowInclusive && compareLow < 0) || (!lowInclusive && compareLow <= 0) || (highInclusive && compareHigh > 0) ||
                (!highInclusive && compareHigh >= 0)) {
                throw new InRangeException(actual, low, lowInclusive, high, highInclusive);
            }
        }

        public static void ShouldBeLessThan<T>(this T actual, T expected) where T : IComparable<T> {
            if (actual.CompareTo(expected) >= 0) {
                throw new InRangeException(actual, null, false, expected, false);
            }
        }

        public static void ShouldBeLessThan<T>(this T actual, T expected, IComparer<T> comparer) {
            if (comparer.Compare(actual, expected) >= 0) {
                throw new InRangeException(actual, null, false, expected, false);
            }
        }

        public static void ShouldBeLessThanOrEqual<T>(this T actual, T expected) where T : IComparable<T> {
            if (actual.CompareTo(expected) > 0) {
                throw new InRangeException(actual, null, false, expected, true);
            }
        }

        public static void ShouldBeLessThanOrEqualTo<T>(this T actual, T expected, IComparer<T> comparer) {
            if (comparer.Compare(actual, expected) > 0) {
                throw new InRangeException(actual, null, false, expected, true);
            }
        }

        public static void ShouldNotBeInRange<T>(this T actual, T low, T high) where T : IComparable<T> {
            ShouldNotBeInRange(actual, low, true, high, true);
        }

        public static void ShouldNotBeInRange<T>(this T actual, T low, T high, IComparer<T> comparer) {
            ShouldNotBeInRange(actual, low, true, high, true, comparer);
        }

        public static void ShouldNotBeInRange<T>(this T actual, T low, bool lowInclusive, T high, bool highInclusive)
            where T : IComparable<T> {
            int compareLow = actual.CompareTo(low);
            int compareHigh = actual.CompareTo(high);
            if (((lowInclusive && compareLow >= 0) || (!lowInclusive && compareLow > 0)) &&
                ((highInclusive && compareHigh <= 0) || (!highInclusive && compareHigh < 0))) {
                throw new NotInRangeException(actual, low, lowInclusive, high, highInclusive);
            }
        }

        public static void ShouldNotBeInRange<T>(this T actual, T low, bool lowInclusive, T high, bool highInclusive, IComparer<T> comparer) {
            int compareLow = comparer.Compare(actual, low);
            int compareHigh = comparer.Compare(actual, high);
            if (((lowInclusive && compareLow >= 0) || (!lowInclusive && compareLow > 0)) &&
                ((highInclusive && compareHigh <= 0) || (!highInclusive && compareHigh < 0))) {
                throw new NotInRangeException(actual, low, lowInclusive, high, highInclusive);
            }
        }
    }

    public class InRangeException : RangeException
    {
        public InRangeException(object actual, object low, bool lowInclusive, object high, bool highInclusive)
            : base(actual, low, lowInclusive, high, highInclusive, "Assert.InRange() Failure") { }
    }

    public class NotInRangeException : RangeException
    {
        public NotInRangeException(object actual, object low, bool lowInclusive, object high, bool highInclusive)
            : base(actual, low, lowInclusive, high, highInclusive, "Assert.NotInRange() Failure") { }
    }

    public abstract class RangeException : AssertException
    {
        private readonly string _actual;
        private readonly string _high;
        private readonly bool _highInclusive;
        private readonly string _low;
        private readonly bool _lowInclusive;

        /// <summary>
        ///     Initializes a new instance of the <see cref="RangeException" /> class.
        /// </summary>
        /// <param name="actual">The actual.</param>
        /// <param name="low">The low.</param>
        /// <param name="lowInclusive">
        ///     if set to <c>true</c> low is considered in the range.
        /// </param>
        /// <param name="high">The high.</param>
        /// <param name="highInclusive">
        ///     if set to <c>true</c> high is considered in the range.
        /// </param>
        /// <param name="messageHeader">exception message header</param>
        /// <remarks></remarks>
        protected RangeException(object actual, object low, bool lowInclusive, object high, bool highInclusive, string messageHeader)
            : base(messageHeader) {
            _actual = actual == null ? null : actual.ToString();
            _low = low == null ? null : low.ToString();
            _lowInclusive = lowInclusive;
            _high = high == null ? null : high.ToString();
            _highInclusive = highInclusive;
        }

        /// <summary>
        ///     Gets the actual object value
        /// </summary>
        public string Actual {
            get { return _actual; }
        }

        /// <summary>
        ///     Gets the high value of the range
        /// </summary>
        public string High {
            get { return _high; }
        }

        /// <summary>
        ///     Gets a value indicating whether high is considered in the range.
        /// </summary>
        /// <remarks></remarks>
        public bool HighInclusive {
            get { return _highInclusive; }
        }

        /// <summary>
        ///     Gets the low value of the range
        /// </summary>
        public string Low {
            get { return _low; }
        }

        /// <summary>
        ///     Gets a value indicating whether low is considered in the range.
        /// </summary>
        /// <remarks></remarks>
        public bool LowInclusive {
            get { return _lowInclusive; }
        }

        /// <summary>
        ///     Gets a message that describes the current exception.
        /// </summary>
        /// <returns>
        ///     The error message that explains the reason for the exception, or an empty string("").
        /// </returns>
        public override string Message {
            get {
                return string.Format("{0}{6}Range:  {1}{2} - {3}{4}{6}Actual: {5}",
                                     base.Message,
                                     LowInclusive ? "[" : "(",
                                     Low,
                                     High,
                                     HighInclusive ? "]" : ")",
                                     Actual ?? "(null)",
                                     Environment.NewLine);
            }
        }
    }
}