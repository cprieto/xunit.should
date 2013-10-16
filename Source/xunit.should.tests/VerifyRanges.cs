using System.Collections.Generic;

using Xunit.Should.Sdk;

namespace Xunit.Should.Tests
{
    public class VerifyRanges
    {
        [Fact]
        public void InRange() {
            10.ShouldBeInRange(5, 15);
            new InRangeException(10, 15, true, 20, true).ShouldBeThrownBy(() => 10.ShouldBeInRange(15, 20));
        }

        [Fact]
        public void InRangeWithComparer() {
            var comparer = Comparer<int>.Default;
            10.ShouldBeInRange(5, 15, comparer);
            new InRangeException(10, 15, true, 20, true).ShouldBeThrownBy(() => 10.ShouldBeInRange(15, 20, comparer));
        }

        [Fact]
        public void NotInRange() {
            10.ShouldNotBeInRange(15, true, 20, true);
            10.ShouldNotBeInRange(15, false, 20, true);
            10.ShouldNotBeInRange(15, true, 20, false);
            10.ShouldNotBeInRange(15, false, 20, false);
            25.ShouldNotBeInRange(15, 20);
            new NotInRangeException(15, 10, true, 20, true).ShouldBeThrownBy(() => 15.ShouldNotBeInRange(10, 20));
        }

        [Fact]
        public void NotInRangeWithComparer() {
            var comparer = Comparer<int>.Default;
            10.ShouldNotBeInRange(15, 20, comparer);
            25.ShouldNotBeInRange(15, 20, comparer);
            new NotInRangeException(15, 10, true, 20, true).ShouldBeThrownBy(() => 15.ShouldNotBeInRange(10, 20, comparer));
        }
    }
}