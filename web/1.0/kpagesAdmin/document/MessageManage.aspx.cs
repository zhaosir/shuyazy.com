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
//using shuyaIp;
public partial class kpagesAdmin_document_MessageManage : System.Web.UI.Page
{
    //public shuyaIp.IpAddressSearchWebService ipss = new IpAddressSearchWebService();
    protected void Page_Load(object sender, EventArgs e)
    {
        this.rep_messages.ItemCommand += new RepeaterCommandEventHandler(rep_messages_ItemCommand);
        this.rep_messages.ItemDataBound += new RepeaterItemEventHandler(rep_messages_ItemDataBound);
        rep_messages.DataBinding += new EventHandler(rep_messages_DataBinding);
    }

    void rep_messages_DataBinding(object sender, EventArgs e)
    {
       
    }

    void rep_messages_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        Control c=e.Item.FindControl("lab_ipadd");
        Object obj_item=e.Item.DataItem;
        if (c != null && c is Label && obj_item!=null&&obj_item is DataRowView)
        {
            Label lable = (Label)c;
            DataRowView dateitem = (DataRowView)obj_item;
            string ip=dateitem["ipaddress"].ToString();
            string showText = "未知";
            if (ip!= "")
            {
                string[] res = null;//ipss.getCountryCityByIp(ip);
                if (res != null && res.Length >= 2)
                {
                    //showText = res[1];
                }
            }
            lable.Text = showText;
        }
    }

    void rep_messages_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
        string commandName=e.CommandName;
        if (commandName == "delMsg")
        {
            string Msgid = e.CommandArgument.ToString();
            Bll_Message bll_msg = new Bll_Message();
            bool res=bll_msg.DelMessageById(Msgid);
            string del_res = "";
            if (res)
                del_res = "成功";
            else
                del_res = "失败";
            //this.Response.Write("<script type=\"text/javascript\">alert(\"删除" + del_res + "！\")</script>");
            pageIndex = AspNetPager1.CurrentPageIndex;
            BindGrid();
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
        int pageSize = this.AspNetPager1.PageSize = 8;
        Bll_Message bll_msg = new Bll_Message();
        int totalCount = 0;
        System.Data.DataTable tab_news = bll_msg.GetMsgList(pageIndex, pageSize, out totalCount);
        this.AspNetPager1.RecordCount = totalCount;
        rep_messages.DataSource = tab_news;
        rep_messages.DataBind();
    }
}
