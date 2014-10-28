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

public partial class kpagesAdmin_site_Profile :ConfigBase
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["userName"] == null)
            this.Response.Redirect(@"~\kpagesAdmin\Login.aspx");
        if (!IsPostBack)
        {
            tbTitle.Value = get("title");
            tbSite.Value = get("webSite");
            tbCopyRigth.Value = get("copyRight");
            tbTel.Value = get("tel");
            tbQQ.Value = get("qq");
            tbMail.Value = get("mail");
        }
    }

    protected void setInfo(object sender, EventArgs e)
    {
        string title = tbTitle.Value.Trim();
        string webSite = tbSite.Value.Trim();
        string copyRigth = tbCopyRigth.Value.Trim();

        setContactInfo(tbTel.Value.Trim(), tbMail.Value.Trim(), tbQQ.Value.Trim());
        setBaseInfo(title, webSite, copyRigth);

        successInfo.InnerHtml = "修改成功！";

    }
}
