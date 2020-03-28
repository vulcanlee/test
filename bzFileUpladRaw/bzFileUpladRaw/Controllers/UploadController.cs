using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace bzFileUpladRaw.Controllers
{
    [Route("api/upload")]
    [ApiController]
    public class UploadController : ControllerBase
    {
        private readonly IHostingEnvironment environment;

        public UploadController(IHostingEnvironment environment)
        {
            this.environment = environment;
        }
        [HttpGet]
        public string get()
        {
            return "OK";
        }
        [HttpPost]
        public async Task<IActionResult> Post(List<IFormFile> files)
        {
            if (files.Count > 0)
            {
                foreach (var formFile in files)
                {
                    if (formFile.Length > 0)
                    {
                        var filePath = Path.Combine(environment.WebRootPath, formFile.FileName);
                        using (var stream = new FileStream(filePath, FileMode.Create))
                        {
                            await formFile.CopyToAsync(stream);
                        }

                        return Ok(filePath);
                    }
                }
            }
            var tempFileName = Path.GetTempFileName();
            using (var writer = System.IO.File.OpenWrite(tempFileName))
            {
                await Request.Body.CopyToAsync(writer);
            }
            return Ok(Path.GetFileNameWithoutExtension(tempFileName));
        }
        //public async Task<IActionResult> Save()
        //{
        //    var tempFileName = Path.GetTempFileName();
        //    using (var writer = System.IO.File.OpenWrite(tempFileName))
        //    {
        //        await Request.Body.CopyToAsync(writer);
        //    }
        //    return Ok(Path.GetFileNameWithoutExtension(tempFileName));
        //}
    }
}