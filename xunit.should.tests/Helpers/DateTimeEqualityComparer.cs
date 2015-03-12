namespace xunit.should.tests.Helpers
{
    using System;
    using System.Collections.Generic;

    public class DateTimeEqualityComparer : IEqualityComparer<DateTime>
    {
        /// <summary>
        /// tests on equality on basis of seconds
        /// </summary>        
        public bool Equals(DateTime expected, DateTime actual)
        {
            if (expected.Year == actual.Year && expected.DayOfYear == actual.DayOfYear && expected.Hour == actual.Hour
                && expected.Minute == actual.Minute && expected.Second == actual.Second)
            {
                return true;
            }

            return false;
        }

        public int GetHashCode(DateTime obj)
        {
            return obj.ToUniversalTime().Year + obj.ToUniversalTime().DayOfYear + obj.ToUniversalTime().Hour
                   + obj.ToUniversalTime().Minute + obj.ToUniversalTime().Second;
        }
    }
}