using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class kpagesAdmin_System_Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["userName"] == null)
            this.Response.Redirect(@"~\kpagesAdmin\Login.aspx");
    }
}
