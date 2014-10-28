using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

public partial class kpagesAdmin_document_News : DocumentMaster
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void AspNetPager1_PageChanged(object sender, Wuqi.Webdiyer.PageChangingEventArgs e)
    {
        pageIndex = e.NewPageIndex;
        BindGrid();
    }
    public int pageIndex = 0;
    public void BindGrid()
    {
        int pageSize = this.AspNetPager1.PageSize = 5;
        Bll_Model bll_model = new Bll_Model();
        int totalCount = 0;
        System.Data.DataTable tab_news = bll_model.GetNewsTable(pageIndex, pageSize, out totalCount);
        this.AspNetPager1.RecordCount = totalCount;
        rep_newsList.DataSource = tab_news;
        rep_newsList.DataBind();
    }

    protected void rep_newsList_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
        string cmdType = e.CommandName;
        string id = e.CommandArgument.ToString();
        if (cmdType == "del")
        {
            bool res = true;
            try
            {
                Delete(Int32.Parse(id));
            }
            catch
            {
                res = false;
            }

           
            if (res)
            {
                pageIndex = AspNetPager1.CurrentPageIndex;
                BindGrid();
                this.Response.Write("<script type=\"text/javascript\">alert('删除成功！') </script>");
            }
            else
                this.Response.Write("<script type=\"text/javascript\">alert('删除失败！') </script>");
        }
    }
}
