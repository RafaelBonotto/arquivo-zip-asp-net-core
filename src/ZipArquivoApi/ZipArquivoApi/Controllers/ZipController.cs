using Microsoft.AspNetCore.Mvc;
using System.IO.Compression;

namespace ZipArquivoApi.Controllers
{
    [Route("api/zip")]
    [ApiController]
    public class ZipController : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> GetZipDocumentos()
        {
            List<byte[]> imagens = new();

            string[] arquivos = Directory.GetFiles(@"C:\teste");
            byte[] imgdata = System.IO.File.ReadAllBytes(arquivos[0]);
            
            string base64Zip = ZipTeste(imagens);
            return Ok(new { ZipBase64 = base64Zip });
        }
        static string ZipTeste(List<byte[]> imgs)
        {
            string ret = string.Empty;

            using (var ms = new MemoryStream())
            {
                using (var archive = new ZipArchive(ms, ZipArchiveMode.Create, true))
                {
                    foreach (var img in imgs)
                    {
                        var entry = archive.CreateEntry("Img-3-pgs.pdf", CompressionLevel.Fastest);

                        using (var zipStream = entry.Open())
                        {
                            zipStream.Write(img, 0, img.Length);
                        }
                    }
                }
                //Teste - Salvar Zip no disco
                System.IO.File.WriteAllBytes(@"C:\\Imagens\\zip3pgs.zip", ms.ToArray());
                // Final do teste

                ret = Convert.ToBase64String(ms.ToArray());
            }
            return ret;
        }
    }
}
