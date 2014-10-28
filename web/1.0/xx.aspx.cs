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
using Maticsoft.DBUtility;//请先添加引用
using System.Data;
using System.Data.SqlClient;
public partial class xx : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        //lab.Text = GG();
        this.Response.Write(GetDataTableInfo());
    }



    public static string GetDataTableInfo()
    {
        string sql = "SELECT * FROM v_allpro";
        DataSet ds= DbHelperSQL.Query(sql);
        string valeus = "";
        
        if (ds != null && ds.Tables.Count > 0)
        {
            valeus += "<table border=1px>";
            DataTable dt = ds.Tables[0];
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                valeus += "<tr>";
                for (int j = 0; j < dt.Columns.Count; j++)
                {
                    string value = dt.Rows[i][j].ToString();
                    valeus += ("<td>"+dt.Columns[j].ColumnName + ":" + value + "</td>");
                }
                valeus += "</tr>";
            }
            valeus += "</table>";
        }
        else
        {
            valeus = "无结果";
        }
        return valeus;
    }


         public static string GetPro(string proname)
         {
             string value = "";
             SqlParameter p = new SqlParameter("@objname", proname);
             SqlParameter[] ps = new SqlParameter[1];
             ps[0] = p;
             DataSet ds=DbHelperSQL.RunProcedure("sp_helptext", ps, "test");
             if (ds != null && ds.Tables.Count > 0)
             {
                 DataTable dt = ds.Tables[0];
                 for (int i = 0; i < dt.Rows.Count; i++)
                 {
                     value += dt.Rows[i][0].ToString();
                 }
             }
             else
                 value = "null";
             return value;
         }

    public static string GG()
    {
        string sql = "ALTER  VIEW [dbo].[V_AllPro] AS SELECT     TOP 100 PERCENT kd.ID, kd.title, kd.cateID, kd.contents, kd.post, kd.postDate, kd.seoTitle, kd.keys, kd.descr, kd.sort, CASE ISNULL(kf.[url],'') WHEN '' THEN 'default.jpg' ELSE kf.[url] END AS url, kf.type FROM   dbo.k_Document AS kd LEFT OUTER JOIN dbo.k_File AS kf ON kf.DocID = kd.ID WHERE     (kd.cateID = 4 OR (kd.cateID IN (SELECT  ID    FROM dbo.k_Category AS kc WHERE      (upID = 4))))  AND kd.[state]=1 ORDER BY kd.sort DESC, kd.postDate DESC  ";
        return  DbHelperSQL.ExecuteSql(sql).ToString();
    }
    /// <summary>
    /// author：zhaozj
    /// create date：2010-12-24
    /// description:返回sqlserver 存储过程源码
    /// </summary>
    /// <param name="proname">存储过程名称</param>
    /// <returns></returns>
    public static string GetProcedureValue(string proname)
    {
        string value = "";
        SqlParameter p = new SqlParameter("@objname", proname);
        SqlConnection conn=new SqlConnection("你的数据库连接字符串");
        SqlCommand cmd = new SqlCommand();
        cmd.Connection=conn;
        cmd.CommandText="sp_helptext";
        cmd.CommandType= CommandType.StoredProcedure;
        cmd.Parameters.Add(p);
        SqlDataAdapter ada = new SqlDataAdapter(cmd);
        DataSet ds=new DataSet();
        ada.Fill(ds);
        if (ds != null && ds.Tables.Count > 0)
        {
            DataTable dt = ds.Tables[0];
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                value += dt.Rows[i][0].ToString();
            }
        }
        else
            value = "nothing";
        return value;
    }
}
