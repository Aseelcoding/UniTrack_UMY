
namespace UniTrack_UMY.Core.Models
{
    public class StudyNote
    {
        public string Id { get; set; } = string.Empty;

        public string Title { get; set; } = string.Empty;

        public string CourseId { get; set; } = string.Empty;

        public string CourseName { get; set; } = string.Empty;

        public string Content { get; set; } = string.Empty;

        public System.DateTime CreatedAt { get; set; } =
            System.DateTime.Now;

        public System.DateTime UpdatedAt { get; set; } =
            System.DateTime.Now;
    }
}
