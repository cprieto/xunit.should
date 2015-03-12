namespace Xunit.Should.Tests
{
    using System;
    using System.Collections.Generic;

    using xunit.should.tests.Helpers;

    public class ShouldExtensionsTests
    {
        [Fact]
        public static void ShouldBe()
        {
            const string Expected = "abc";
            const string Result = "abc";

            Result.ShouldBe(Expected);
        }

        [Fact]
        public static void ShouldBeWithEqualityComparer()
        {
            var expected = new DateTime(2014, 8, 8, 12, 0, 0);
            var result = new DateTime(2014, 8, 8, 12, 0, 0);

            result.ShouldBe(expected, new DateTimeEqualityComparer());
        }

        [Fact]
        public static void ShouldBeEmpty()
        {
            var emptyList = new List<string>();

            emptyList.ShouldBeEmpty();
        }

        [Fact]
        public static void ShouldBeFalse()
        {
            false.ShouldBeFalse();
            false.ShouldBeFalse("message");
        }

        [Fact]
        public static void ShouldBeGreaterThan()
        {
            2.ShouldBeGreaterThan(1);
        }

        [Fact]
        public static void ShouldBeGreaterThanOrEqualTo()
        {
            2.ShouldBeGreaterThanOrEqualTo(1);
            2.ShouldBeGreaterThanOrEqualTo(2);
        }

        [Fact]
        public static void ShouldBeInRange()
        {
            2.ShouldBeInRange(1, 3);
            2.ShouldBeInRange(2, 2);
        }

        [Fact]
        public static void ShouldBeTrue()
        {
            true.ShouldBeTrue();
            true.ShouldBeTrue("blubb");
        }

        [Fact]
        public static void ShouldContain()
        {
            "Christian".ShouldContain("ian");
            "Christian".ShouldContain("IAN", StringComparison.OrdinalIgnoreCase);
        }

        [Fact]
        public static void ShouldContainOnEnumberable()
        {
            IEnumerable<string> x = new List<string> { "a", "b", "c" };
            x.ShouldContain("b");
        }

        private class Person
        {
            public string Firstname { get; set; }

            public string Lastname { get; set; }
        }

        private class PersonComparer : IEqualityComparer<Person>
        {
            public bool Equals(Person x, Person y)
            {
                return x.Lastname.Equals(y.Lastname);
            }

            public int GetHashCode(Person obj)
            {
                return obj.GetHashCode();
            }
        }

        [Fact]
        public static void ShouldContainOnEnumberableWithComparer()
        {
            var listOfPersons = new List<Person>
                                        {
                                            new Person { Firstname = "Arnold", Lastname = "Schwarzenegger" },
                                            new Person { Firstname = "Harld", Lastname = "Schmid" }
                                        };
            listOfPersons.ShouldContain(new Person { Lastname = "Schmid" }, new PersonComparer());
        }

        [Fact]
        public static void ShouldNotBeEmpty()
        {
            var listOfPersons = new List<Person>();
            listOfPersons.ShouldBeEmpty();
        }
    }
}
