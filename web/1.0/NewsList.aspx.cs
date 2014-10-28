using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class corp_List : PageBase
{
    protected void Page_Load(object sender, EventArgs e)
    {
        keywords.Content = Keyword;
        desrc.Content = Descr;
        if (!IsPostBack)
        {
        }
    }
    public int pageIndex = 0;
    protected void AspNetPager1_PageChanged(object sender, Wuqi.Webdiyer.PageChangingEventArgs e)
    {
        pageIndex = e.NewPageIndex;
        BindGrid();
    }

    public void BindGrid()
    {
        int pageSize = this.AspNetPager1.PageSize = 5;
        Bll_Model bll_model = new Bll_Model();
        int totalCount=0;
        System.Data.DataTable tab_news = bll_model.GetNewsTable(pageIndex, pageSize, out totalCount);
        this.AspNetPager1.RecordCount = totalCount;
        rep_newsList.DataSource = tab_news;
        rep_newsList.DataBind();
    }
}
