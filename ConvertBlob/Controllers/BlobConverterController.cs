using ConvertBlob.InterFace;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ConvertBlob.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BlobConverterController : ControllerBase
    {
        private readonly IBlobConverter _blobConverter;
        public BlobConverterController(IBlobConverter blobConverter)
        {
            _blobConverter = blobConverter;
        }

        [HttpGet]
        public async Task<IActionResult> ConvertBlob() { 
            var result = await _blobConverter.ConvertBlob();
            return Ok(result);
        }
    }
}
