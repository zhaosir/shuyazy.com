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

public partial class kpagesAdmin_user_UserInfo :UserMaster
{
    Kpages.Model.UserInfo model;
    protected void Page_Load(object sender, EventArgs e)
    {
        model = (Kpages.Model.UserInfo)Session["userInfo"];
        if (model != null)
        {
            tbBirthday.Value = model.birthday.ToString();
            tbMail.Value = model.mail;
            tbTel.Value = model.tel;
            rblSex.SelectedValue = model.sex.ToString();
        }

    }
    protected void UpdateUser(Object sender, EventArgs e)
    {

        model.tel = tbTel.Value;
        model.sex = Convert.ToInt32(rblSex.SelectedValue);
        model.password = tbPassword.Value;
        model.mail = tbMail.Value;
        model.birthday = Convert.ToDateTime(tbBirthday.Value);

        successInfo.InnerHtml = msg;


    }
}
