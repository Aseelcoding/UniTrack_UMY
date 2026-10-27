using System;
using System.Collections.Generic;
using System.Text;

namespace UniTrack_UMY.Core.Interfaces
{
    public interface IHtmlFetcher
    {
        Task<string> GetHtmlAsync(string url);
    }
}
