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

public partial class admin_frame_Right : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["userName"] == null)
            this.Response.Redirect(@"~\kpagesAdmin\Login.aspx");
        if (!this.IsPostBack)
        {
            lbServerName.Text = "http://" + HttpContext.Current.Request.Url.Host + HttpContext.Current.Request.ApplicationPath;//服务器计算机名
            lbIp.Text = Request.ServerVariables["LOCAl_ADDR"];//服务器IP地址
            lbDomain.Text = Request.ServerVariables["SERVER_NAME"].ToString();//服务器域名
            lbPort.Text = Request.ServerVariables["Server_Port"].ToString();//服务器端口
            lbIISVer.Text = Request.ServerVariables["Server_SoftWare"].ToString();//服务器IIS版本
            lbPhPath.Text = Request.PhysicalApplicationPath;//本文件所在文件夹
            lbOperat.Text = Environment.OSVersion.ToString();//服务器操作系统
            lbSystemPath.Text = Environment.SystemDirectory.ToString();//系统所在文件夹
            lbTimeOut.Text = (Server.ScriptTimeout / 1000).ToString() + "秒";//服务器脚本超时时间
            lbAspnetVer.Text = string.Concat(new object[] { Environment.Version.Major, ".", Environment.Version.Minor, Environment.Version.Build, ".", Environment.Version.Revision });//ASP.NET Framework 版本
            lbCurrentTime.Text = DateTime.Now.ToString();//服务器当前时间
            lbCpuNum.Text = Environment.GetEnvironmentVariable("NUMBER_OF_PROCESSORS").ToString();//CPU 总数
            lbCpuType.Text = Environment.GetEnvironmentVariable("PROCESSOR_IDENTIFIER").ToString();//CPU 类型
            lbMemoryPro.Text = ((Double)GC.GetTotalMemory(false) / 1048576).ToString("N2") + "M";// 当前程序占用内存
            lbMemory.Text = (Environment.WorkingSet / 1024).ToString() + "M";//虚拟内存

        }
        

    }
}
