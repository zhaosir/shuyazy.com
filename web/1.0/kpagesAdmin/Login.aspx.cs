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

public partial class SysAdmin_Login : System.Web.UI.Page
{
    UserMaster master = new UserMaster();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            Label1.Text = new randomCode().RandomNum(5);   //产生验证码
        }
    }
    protected void bnLogin_Click(object sender, EventArgs e)
    {
        string userName = tbUserName.Value.Trim();
        string password = tbPassword.Value.Trim();

        if (tbRan.Value.Trim() != Label1.Text)
        {
            info.InnerHtml = "请输入正确的验证码！";
            return;
        }
        else
        {
            bool isLogin = master.Login(userName, password);
            if (isLogin == true)
            {
                Session["userName"] = userName;
                Response.Redirect("Index.html");
            }
            else
            {
                info.InnerHtml = master.GetMsg();
            }
        }
    }
}
