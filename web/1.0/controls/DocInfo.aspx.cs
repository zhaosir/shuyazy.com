using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class corp_DocInfo :PageBase
{
    public int cateID;
    public int ID;
    protected void Page_Load(object sender, EventArgs e)
    {
        keywords.Content = Keyword;
        desrc.Content = Descr;

        if (Request.QueryString["ID"] != null)
        {
            string url=Request.UrlReferrer.ToString();
            a_back.HRef = url;
            ID = Convert.ToInt32(Request.QueryString["ID"]);
        }
        else
        {
            Response.Redirect("NewsList.aspx");
        }
    }
}
