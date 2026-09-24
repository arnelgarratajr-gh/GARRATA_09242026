using static GARRATA_09242026.Data.JsonProcessing;

namespace GARRATA_09242026.Services;

public interface IFileProcessingService
{
    Task<JsonProcessingResult> ProcessJsonAsync(IFormFile file, CancellationToken cancellationToken);
}
