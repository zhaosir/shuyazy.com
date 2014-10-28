using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class corp_ProList : PageBase
{
    public string cateID;
    protected void Page_Load(object sender, EventArgs e)
    {
        keywords.Content = Keyword;
        desrc.Content = Descr;

        if (Request.QueryString["cateID"] != null)
        {
            cateID =Request.QueryString["cateID"].ToString();
        }
        else
        {
            cateID = "";
        }

        //list.cateID = cateID;
    }
    public int pageIndex = 0;
    protected void AspNetPager1_PageChanged(object sender, Wuqi.Webdiyer.PageChangingEventArgs e)
    {
        pageIndex = e.NewPageIndex;
        BindGrid();
    }

    public void BindGrid()
    {
        int pageSize = this.AspNetPager1.PageSize =9;
        Bll_Model bll_model = new Bll_Model();
        int count=0;
        System.Data.DataTable dt = bll_model.GetProListByType(pageIndex, pageSize, cateID, out count);
        this.AspNetPager1.RecordCount = count;
        rpt_proList.DataSource = dt;
        rpt_proList.DataBind();
    }
}
