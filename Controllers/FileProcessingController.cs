using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GARRATA_09242026.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FileProcessingController : ControllerBase
    {
        public async Task<IActionResult> ProcessFile(IFormFile? file, CancellationToken cancelToken)
        {
            // TODO
            // 1 - validate request from user
            // 2 - call a service thr will process the file
            // 3 - return the reponse

            return Ok();
        }
    }
}
