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

public partial class kpagesAdmin_user_Default:UserMaster
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            Bind(gv);
        }
    }

    protected void Delete(object sender, EventArgs e)
    {
        foreach (GridViewRow row in gv.Rows)
        {
            CheckBox cb = (CheckBox)row.FindControl("CheckBox1");
            if (cb.Checked == true)
            {
                string str = row.Cells[1].Text.ToString();
                Delete(Convert.ToInt32(row.Cells[1].Text.ToString()));
                
            }
        }

        Bind(gv);
    }

    protected void AddUser(object sender, EventArgs e)
    {
        Kpages.Model.UserInfo model = new Kpages.Model.UserInfo();

        model.userName = tbUserName.Value;
        model.tel = tbTel.Value;
        model.sex = Convert.ToInt32(rblSex.SelectedValue);
        model.password = tbPassword.Value;
        model.mail = tbMail.Value;
        model.birthday = Convert.ToDateTime(tbBirthday.Value);

        Add(model);
        Bind(gv);
        
        successInfo.InnerHtml = msg;
    }


}
