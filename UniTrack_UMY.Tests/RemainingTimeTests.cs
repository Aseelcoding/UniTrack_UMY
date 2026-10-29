using System;
using UniTrack_UMY.Core;
using Xunit;

namespace UniTrack_UMY.Tests
{
    public class RemainingTimeTests
    {
        [Fact]
        public void Describe_WhenNoDueDate_ReturnsEmpty()
        {
            Assert.Equal(string.Empty, RemainingTime.Describe(null));
        }

        [Fact]
        public void Describe_WhenDueInTwoDays_ReturnsDueIn()
        {
            DateTime now = new DateTime(2026, 1, 1, 12, 0, 0);
            DateTime due = now.AddDays(2);

            Assert.Equal("Due in 2 days", RemainingTime.Describe(due, now));
        }

        [Fact]
        public void Describe_WhenDueInOneDay_UsesSingular()
        {
            DateTime now = new DateTime(2026, 1, 1, 12, 0, 0);
            DateTime due = now.AddDays(1);

            Assert.Equal("Due in 1 day", RemainingTime.Describe(due, now));
        }

        [Fact]
        public void Describe_WhenDueInHours_ReturnsHours()
        {
            DateTime now = new DateTime(2026, 1, 1, 12, 0, 0);
            DateTime due = now.AddHours(3);

            Assert.Equal("Due in 3 hours", RemainingTime.Describe(due, now));
        }

        [Fact]
        public void Describe_WhenOverdueByOneDay_ReturnsOverdue()
        {
            DateTime now = new DateTime(2026, 1, 3, 12, 0, 0);
            DateTime due = new DateTime(2026, 1, 2, 12, 0, 0);

            Assert.Equal("Overdue by 1 day", RemainingTime.Describe(due, now));
        }
    }
}
