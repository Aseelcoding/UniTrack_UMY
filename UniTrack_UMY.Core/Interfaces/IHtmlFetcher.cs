using System.Threading;
using System.Threading.Tasks;

namespace UniTrack_UMY.Core.Interfaces
{
    public interface IHtmlFetcher
    {
        Task<string> GetHtmlAsync(string url, CancellationToken cancellationToken = default);
    }
}
