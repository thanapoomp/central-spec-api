using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CentralSpecAPI.Controllers
{

    [ApiController]
    [Route("api/[controller]")]

    public class FileUploadController : ControllerBase
    {
        public FileUploadController()
        {

        }

        [HttpPost("UploadImage")]
        public async Task<IActionResult> UploadImage(IFormFile file)
        {
            await Task.Yield();
            string[] permittedExtensions = { ".jpg", ".png" };
            var fileName = file.FileName;
            var size = file.Length.ToString();
            var extension = Path.GetExtension(fileName).ToLowerInvariant();

            if (string.IsNullOrEmpty(extension) || !permittedExtensions.Contains(extension))
            {
                return BadRequest("invalid file , only .jpg or .png allowed.");
            }


            // Process uploaded files
            // Don't rely on or trust the FileName property without validation.

            return Ok(new { fileName,size,extension });
        }

    }
}