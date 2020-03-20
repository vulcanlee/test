using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace HelloRazorPage.Pages
{
    public class HelloModel : PageModel
    {
        public string YourName { get;set; }
        public string MyAnswer { get; set; }
        public void OnGet()
        {
            YourName = "請在此輸入姓名";
        }
        public void OnPost(string yourName)
        {
            MyAnswer = $"{yourName} 你好，這裡是 Razor Page";
        }
    }
}