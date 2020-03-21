using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HelloAjax.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SayHelloController : ControllerBase
    {
        [HttpGet]
        [Route("{yourName}")]
        public string Get(string yourName)
        {
            return $"{yourName} 你好，這裡是 jQuery Ajax API";
        }

    }
}