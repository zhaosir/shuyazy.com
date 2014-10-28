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

public partial class kpagesAdmin_document_DocumentInfo :DocumentMaster
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["userName"] == null)
            this.Response.Redirect(@"~\kpagesAdmin\Login.aspx");
        if (!IsPostBack)
        {
            BindCates(ddlCate);
            if (Request.QueryString["ID"] != null)
            {
                setIndex(Convert.ToInt32(Request.QueryString["ID"].ToString()));


                categoryInfo.InnerHtml = getCategorry(model.cateID).category;
                ddlCate.SelectedValue = model.cateID.ToString();

                tbDesrciption.Value = model.descr;
                tbKeyword.Value = model.keys;
                tbSEOTitle.Value = model.seoTitle;

                tbTitle.Value = model.title;

                Editor1.Text = model.contents;

 
            }
            else
            {

                if (Request.QueryString["upID"] != null)
                {
                    categoryInfo.InnerHtml = getCategorry(Convert.ToInt32(Request.QueryString["upID"].ToString())).category;

                    ddlCate.SelectedValue = Request.QueryString["upID"].ToString();
                    
                }
                model = null;

            }

            showBn();
        }


    }

    protected void AddInfo(object sender, EventArgs e)
    {
        model = new Kpages.Model.Document();
        model.title = tbTitle.Value;
        model.cateID = 6;
        model.contents = Editor1.Text;
        model.seoTitle = tbSEOTitle.Value;
        model.keys = tbKeyword.Value;
        model.descr = tbDesrciption.Value;
        model.state = 1;

        Add(model);
        model = null;
        showBn();
        //Response.Redirect("DocumentInfo.aspx?ID=" + inedx);
        successInfo.InnerHtml = msg;
        Response.Redirect("News.aspx");

    }

    protected void UpdateInfo(object sender, EventArgs e)
    {
        model.title = tbTitle.Value;
        model.cateID = 6;
        model.contents = Editor1.Text;
        model.seoTitle = tbSEOTitle.Value;
        model.keys = tbKeyword.Value;
        model.descr = tbDesrciption.Value;
        model.state = 1;

        Update(model);
        successInfo.InnerHtml = msg;
        Response.Redirect("News.aspx");
    }

    /// <summary>
    /// 转换状态
    /// </summary>
    public void showBn()
    {
        if (model == null)
        {
            bnAdd.Visible = true;
            bnUpdate.Visible = false;

            bnGo.Visible = false;
            bnGoImg.Visible = false;
        }
        else
        {
            bnAdd.Visible = false;
            bnUpdate.Visible = true;

            bnGo.Visible = false;
            bnGoImg.Visible = false;

            if (getCategorry(model.cateID).type == 1)
            {
                bnGoImg.Visible = true;
            }
            else if (getCategorry(model.cateID).type == 2)
            {
                bnGo.Visible = true;
            }
        }
        successInfo.InnerHtml = "";
    }

    protected void Go(object sender, EventArgs e)
    {
        Response.Redirect("ProductInfo.aspx?ID=" + Request.QueryString["ID"].ToString());
    }

    protected void GoImg(object sender, EventArgs e)
    {
        Response.Redirect("ProImg.aspx?ID=" + Request.QueryString["ID"].ToString());

    }


}
