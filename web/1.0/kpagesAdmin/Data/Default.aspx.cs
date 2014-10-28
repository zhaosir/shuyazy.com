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
using Maticsoft.DBUtility;
using System.IO;


public partial class kpagesAdmin_Data_Default : System.Web.UI.Page
{
    
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["userName"] == null)
            this.Response.Redirect(@"~\kpagesAdmin\Login.aspx");
        if (!IsPostBack)
        {
            Bind();
        }
    }

    /// <summary>
    /// 备份数据库
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void backUp(object sender, EventArgs e)
    {
        try
        {
            string path = Server.MapPath("~/App_Data/backup/");
            string sqlStr = "backup database ppBase to disk='" + path + DateTime.Now.ToShortDateString() + "data.bak'";
            DbHelperSQL.Query(sqlStr);
        }
        catch (Exception ex)
        {
            successInfo.InnerHtml = ex.Message.ToString();

        }
        

    }

    /// <summary>
    /// 还原数据库
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void restore(object sender, EventArgs e)
    {
        try
        {
            string filePath = tbFilePath.Value.Trim();
            string url = Server.MapPath("~/App_Data/backup/");

            string sqlStr = "use master restore database lpBase from disk='" + url + filePath + "'";

            DbHelperSQL.Query(sqlStr);
        }
        catch (Exception ex)
        {
            successInfo.InnerHtml = ex.Message.ToString();
        }
    }

    public void Bind()
    {
        string url = Server.MapPath("~/App_Data/backup/");
        DirectoryInfo dr = new DirectoryInfo(url);
        FileInfo[] files = dr.GetFiles();
        DataTable dt = new DataTable();
        dt.Columns.Add("filePath");
        foreach (FileInfo file in files)
        {
            DataRow row = dt.NewRow();
            row["filePath"] = file.Name;
            dt.Rows.Add(row);
        }

        DataList1.DataSource = dt;
        DataList1.DataBind();
    }
}
