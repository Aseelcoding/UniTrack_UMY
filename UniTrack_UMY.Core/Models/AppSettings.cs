using System;
using System.Collections.Generic;
using System.Text;

namespace UniTrack_UMY.Core.Models
{
    public class AppSettings
    {
        public AppLanguage Language { get; set; } = AppLanguage.English;

        public AppTheme Theme { get; set; } = AppTheme.Dark;
    }
}
