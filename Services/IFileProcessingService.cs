using System;

namespace GARRATA_09242026.Services;

public interface IFileProcessingService
{
    Task ProcessJsonAsync(IFormFile file, CancellationToken cancellationToken);
}
