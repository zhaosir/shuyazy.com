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

public partial class kpagesAdmin_site_SEO:ConfigBase
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["userName"] == null)
            this.Response.Redirect(@"~\kpagesAdmin\Login.aspx");
        if (!IsPostBack)
        {
            tbKeyword.Value = get("keywords");
            tbDescriptiom.Value = get("description");
        }
    }

    protected void setInfo(object sender, EventArgs e)
    {

        setSEO(tbKeyword.Value.Trim(), tbDescriptiom.Value.Trim());
        successInfo.InnerHtml = "修改成功！";

    }
}
