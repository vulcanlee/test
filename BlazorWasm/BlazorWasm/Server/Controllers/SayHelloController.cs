using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BlazorWasm.Server.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
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