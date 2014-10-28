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

public partial class kpagesAdmin_document_ProManage : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        rep_pro.ItemCommand += new RepeaterCommandEventHandler(rep_pro_ItemCommand);
    }

    void rep_pro_ItemCommand(object source, RepeaterCommandEventArgs e)
    {

        string commandType = e.CommandName;
        string comandId = e.CommandArgument.ToString();
        if (commandType == "del")
        {
            Bll_Model bll_model = new Bll_Model();
            Control control=e.Item.FindControl("img_pro");
            if (control != null && control is HtmlImage)
            {
                HtmlImage image = (HtmlImage)control;
                string imgSrc = image.Src;
                string truePath=System.IO.Path.GetDirectoryName(MapPath(imgSrc));
                string fileName = System.IO.Path.GetFileName(imgSrc).Remove(0, 2);
                bll_model.DelProById(comandId, false, fileName, truePath);
                pageIndex = AspNetPager1.CurrentPageIndex;
                BindGrid();
            }
        }
        if (commandType == "edit")
        {
            this.Response.Redirect("ProAddAndEdit.aspx?type=edit_shuya&pid=" + comandId);
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
        int pageSize = this.AspNetPager1.PageSize = 6;
        Bll_Model bll_model = new Bll_Model();
        int totalCount = 0;
        System.Data.DataTable tab_news = bll_model.GetProListByType(pageIndex, pageSize,"", out totalCount);
        this.AspNetPager1.RecordCount = totalCount;
        rep_pro.DataSource = tab_news;
        rep_pro.DataBind();
    }
}
