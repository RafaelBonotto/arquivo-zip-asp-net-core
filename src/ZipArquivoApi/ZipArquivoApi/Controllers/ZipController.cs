using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ZipArquivoApi.Controllers
{
    [Route("api/zip")]
    [ApiController]
    public class ZipController : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> GetZipDocumentos()
        {
            return Ok();
        }
    }
}
