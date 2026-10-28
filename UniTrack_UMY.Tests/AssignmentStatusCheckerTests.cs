
using UniTrack_UMY.Core.Models;
using UniTrack_UMY.Infrastructure.Services;
using Xunit;

namespace UniTrack_UMY.Tests
{
    public class AssignmentStatusCheckerTests
    {
        private readonly AssignmentStatusChecker _checker =
            new AssignmentStatusChecker();

        [Theory]
        [InlineData("")]
        [InlineData("   ")]
        [InlineData("<html><body>No submission data</body></html>")]
        public void CheckStatus_WhenSubmissionDataIsMissing_ReturnsNull(
            string html)
        {
            var result = _checker.CheckStatus(html);

            Assert.Null(result);
        }

        [Fact]
        public void CheckStatus_WhenSubmittedForGrading_ReturnsCompleted()
        {
            string html = @"
                <div class='submissionstatustable'>
                    <table>
                        <tr>
                            <th>Submission status</th>
                            <td>Submitted for grading</td>
                        </tr>
                    </table>
                </div>";

            var result = _checker.CheckStatus(html);

            Assert.Equal(
                TaskItem.TaskStatus.Completed,
                result);
        }

        [Fact]
        public void CheckStatus_WhenSubmittedLate_ReturnsSubmittedLate()
        {
            string html = @"
                <div class='submissionstatustable'>
                    <table>
                        <tr>
                            <th>Submission status</th>
                            <td>Submitted for grading</td>
                        </tr>
                        <tr>
                            <th>Time remaining</th>
                            <td class='latesubmission'>Late submission</td>
                        </tr>
                    </table>
                </div>";

            var result = _checker.CheckStatus(html);

            Assert.Equal(
                TaskItem.TaskStatus.SubmittedLate,
                result);
        }

        [Fact]
        public void CheckStatus_WhenNoAttempt_ReturnsOverdue()
        {
            string html = @"
                <div class='submissionstatustable'>
                    <table>
                        <tr>
                            <th>Submission status</th>
                            <td>No attempt</td>
                        </tr>
                    </table>
                </div>";

            var result = _checker.CheckStatus(html);

            Assert.Equal(
                TaskItem.TaskStatus.Overdue,
                result);
        }


        [Fact]
        public void CheckStatus_WhenSubmissionTableIsMissing_ReturnsNull()
        {
            string html = @"
                <div>
                    <table>
                        <tr>
                            <th>Submission status</th>
                            <td>Submitted for grading</td>
                        </tr>
                    </table>
                </div>";

            var result = _checker.CheckStatus(html);

            Assert.Null(result);
        }

        [Fact]
        public void CheckStatus_WhenStatusIsUnknown_ReturnsNull()
        {
            string html = @"
                <div class='submissionstatustable'>
                    <table>
                        <tr>
                            <th>Submission status</th>
                            <td>Draft</td>
                        </tr>
                    </table>
                </div>";

            var result = _checker.CheckStatus(html);

            Assert.Null(result);
        }

    }
}
