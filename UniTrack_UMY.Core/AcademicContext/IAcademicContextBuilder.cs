using System.Threading;
using System.Threading.Tasks;

namespace UniTrack_UMY.Core.AcademicContext
{
    public interface IAcademicContextBuilder
    {
        Task<AcademicContextData> BuildAsync(
            string userQuestion,
            AcademicContextOptions options,
            CancellationToken cancellationToken = default);
    }
}