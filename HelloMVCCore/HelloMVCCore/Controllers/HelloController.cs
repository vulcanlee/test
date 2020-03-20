using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace HelloMVCCore.Controllers
{
    public class HelloModel
    {
        public string YourName { get; set; }
        public string MyAnswer { get; set; }
    }
    public class HelloController : Controller
    {
        public HelloModel HelloModel { get; set; }
        public HelloController()
        {
            HelloModel = new HelloModel();
            HelloModel.YourName = "請在此輸入姓名";
        }
        public IActionResult Index()
        {
            return View(HelloModel);
        }
        [HttpPost]
        public IActionResult Post(HelloModel model)
        {
            HelloModel.MyAnswer = $"{model.YourName} 你好，這裡是 ASP.NET Core Page";
            return View(HelloModel);
        }
    }
}