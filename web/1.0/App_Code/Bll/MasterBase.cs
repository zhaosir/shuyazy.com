using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using Kpages.DAL;

/// <summary>
///MasterBase 的摘要说明
/// </summary>
public class MasterBase : System.Web.UI.Page 
{
    bool isLogin = false; //登录标记 ture为已登录,false 为未登录
    public string serverPath; // 程序根目录
    protected string msg;

	public MasterBase()
	{
        serverPath = Server.MapPath("~/");//设置根目录
	}

    /// <summary>
    /// 检查登录
    /// </summary>
    public void checkLogin() 
    {
        if (Session["user"] == null)
        {
            Response.Redirect("../Error.aspx?msg=" + "你还未登录管理系统,请先登录！" + "&type=1");
        }
    }

    /// <summary>
    /// 将数据表绑定到指定的gridview
    /// </summary>
    /// <param name="gv"></param>
    /// <param name="dt"></param>
    public void Bind(GridView gv, DataTable dt)
    {
        gv.DataSource = dt;
        gv.EmptyDataText = "对不起，没有找到你要的数据";
        gv.DataBind();
    }

    protected void Page_Init(object sender, EventArgs e)
    {
        //checkLogin();
    }
}
