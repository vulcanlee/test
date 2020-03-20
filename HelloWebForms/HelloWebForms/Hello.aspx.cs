using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace HelloWebForms
{
    public partial class Hello : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Page.IsPostBack)
            {
                MyAnswer.Text = $"{YourName.Text} 你好，這裡是 ASP.NET Web Forms";
                MyAnswer.Visible = true;
            }
            else
            {
                YourName.Text = "請在此輸入姓名";
                MyAnswer.Visible = false;
            }
        }
    }
}