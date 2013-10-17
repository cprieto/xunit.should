using System.Xml.Linq;

using Xunit.Sdk;

namespace Xunit.Should
{
    public static class XNameExtensions
    {
        public static void ShouldEqual(this XName actual, XName expected) {
            if (actual.ToString() != expected.ToString()) {
                throw new EqualException(expected, actual);
            }
        }

        public static void ShouldEqual(this XName actual, string expected) {
            if (actual.ToString() != expected) {
                throw new EqualException(expected, actual.ToString());
            }
        }
    }
}