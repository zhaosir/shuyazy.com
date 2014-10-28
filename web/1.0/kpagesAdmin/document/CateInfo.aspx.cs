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
using Kpages.Common;

public partial class SysAdmin_CateInfo :CategoryMaster
{

    static Kpages.Model.Category model;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["userName"] == null)
            this.Response.Redirect(@"~\kpagesAdmin\Login.aspx");
        if (!IsPostBack)
        {
            if (Request.QueryString["act"] != null)
            {
                DataCache.Remove("cate_0");
                if (Request.QueryString["act"].ToString() == "add")
                {
                    model = null;
                    showBn();
                }
                else if (Request.QueryString["act"].ToString() == "update")
                {
                    if (Request.QueryString["ID"] != null)
                    {
                        model = GetModel(Convert.ToInt32(Request.QueryString["ID"].ToString()));

                        tbCate.Value = model.category;
                        ddlType.SelectedValue = model.type.ToString();
                        ddlLinkType.SelectedValue = model.linkType.ToString();
                        tbLink.Value = model.link;

                        showBn();

                    }
                }
                else if (Request.QueryString["act"].ToString() == "delete")
                {
                    if (Request.QueryString["ID"] != null)
                    {
                        Delete(Convert.ToInt32(Request.QueryString["ID"].ToString()));
                        Response.Redirect("Category.aspx");
                    }
                }
            }
        }
    }
    protected void bnAdd_Click(object sender, EventArgs e)
    {
        model = new Kpages.Model.Category();

        model.category = tbCate.Value;
        model.link = tbLink.Value;
        model.type = Convert.ToInt32(ddlType.SelectedValue);
        model.linkType = Convert.ToInt32(ddlLinkType.SelectedValue);
        if (Request.QueryString["upID"] != null)
        {
            model.upID = Convert.ToInt32(Request.QueryString["upID"].ToString());
        }
        else
        {
            model.upID = 0;
        }
        

        add(model);

        successInfo.InnerHtml = msg;


    }
    protected void bnUpdate_Click(object sender, EventArgs e)
    {
        model.category = tbCate.Value;
        model.link = tbLink.Value;
        model.type = Convert.ToInt32(ddlType.SelectedValue);
        model.linkType = Convert.ToInt32(ddlLinkType.SelectedValue);

        Update(model);
        successInfo.InnerHtml = msg;
    }

    public void showBn()
    {
        if (model == null)
        {
            bnAdd.Visible = true;
            bnUpdate.Visible = false;
        }
        else
        {
            bnAdd.Visible = false;
            bnUpdate.Visible = true;
        }
    }
}
