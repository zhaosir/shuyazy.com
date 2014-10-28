using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;

public partial class Error : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Request.QueryString["msg"] != null && Request.QueryString["type"] != null)
        {
            if (Request.QueryString["type"].ToString() == "1")
            {
                Response.Write(Request.QueryString["msg"] + "</br>");
                Response.Write("<a href='Login.aspx'>进入系统登录页面</a>");
            }
            else
            {
                Response.Write(Request.QueryString["msg"] + "</br>");
            }
        }

    }
}
