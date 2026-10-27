using System;
using System.Collections.Generic;
using System.Text;

namespace UniTrack_UMY.Core.Models
{
    public class Course
    {
        public string Id { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
        public string Url { get; set; } = string.Empty;
        public double ProgressPercent { get; set; }
        public bool HasProgress { get; set; }
    }
}
