using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using ELA_Data_Service.Contracts.V1;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;

namespace ELA_Data_Service.Controllers.V1
{
    public class PicturesController : Controller
    {

        [HttpGet(ApiRoutes.Pictures.UserPoints)]
        public async Task<IActionResult> Vocabulary([FromServices] IWebHostEnvironment env, string imgName)
        {
            try
            {
                var image = System.IO.File.OpenRead(Path.Combine(env.WebRootPath, $"vocabulary/{imgName}"));
                return File(image, "image/jpeg");
            }
            catch
            {
                return NotFound("Picture not found");
            }
        }
    }
}