using GARRATA_09242026.Services;
using Microsoft.AspNetCore.Mvc;

namespace GARRATA_09242026.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FileProcessingController(IFileProcessingService fileProcessingService) : ControllerBase
    {
        [HttpPost("process")]
        public async Task<IActionResult> ProcessFile(IFormFile? file, CancellationToken cancelToken)
        {
            if (file is null || file.Length == 0)
            { 
                return BadRequest("A non-empty JSON file is required.");
            }

            if (!string.Equals(Path.GetExtension(file.FileName), ".json", StringComparison.OrdinalIgnoreCase))
            {
                return BadRequest("Only .json files are supported.");
            }

            var processingResult = await fileProcessingService.ProcessJsonAsync(file, cancelToken);
            if (!processingResult.IsValid)
            {
                return BadRequest(processingResult.ErrorMessage);
            }

            return Ok(processingResult.Response);
        }
    }
}
