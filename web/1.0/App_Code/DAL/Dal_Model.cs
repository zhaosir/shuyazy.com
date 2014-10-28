using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Data.SqlClient;
using Maticsoft.DBUtility;//请先添加引用
/// <summary>
/// Dal_Model 的摘要说明
/// create  by zzj
/// </summary>
public class Dal_Model
{
	public Dal_Model()
	{
		//
		// TODO: 在此处添加构造函数逻辑
		//
    }

    #region 最新资讯
    /// <summary>
    /// 获取最新资讯
    /// </summary>
    /// <param name="pageIndex"></param>
    /// <param name="pageSize"></param>
    /// <param name="totalCount"></param>
    /// <returns></returns>
    public DataTable GetNewsTable(int pageindex, int pagesize, out int totalCount)
    {
        totalCount = 0;
        if (pageindex > 0 && pagesize > 0)
        {
            SqlParameter[] pa = new SqlParameter[] { 
                new SqlParameter("@pageindex",SqlDbType.Int),
                new SqlParameter("@pagesize",SqlDbType.Int),
                new SqlParameter("@count",SqlDbType.Int)
            };
            pa[0].Value = pageindex;
            pa[1].Value = pagesize;
            pa[2].Direction = ParameterDirection.Output;
            DataSet ds = DbHelperSQL.RunProcedure("p_model_getNewsList", pa, "tab_news");
            Int32.TryParse(pa[2].Value.ToString(), out totalCount);
            if (ds != null && ds.Tables.Count > 0)
            {
                return ds.Tables[0];
            }
        }
        return null;
    }

  
    #endregion

    #region 产品
    /// <summary>
    /// 增加产品
    /// </summary>
    /// <param name="pro"></param>
    /// <returns></returns>
    public bool AddProInfo(Kpages.Model.Product pro)
    {
        if (pro != null)
        {
            if (pro.doc != null)
            {
                SqlParameter[] pa = new SqlParameter[] { 
                    new SqlParameter("@protitle",SqlDbType.NChar),
                    new SqlParameter("@procontent",SqlDbType.NChar),
                    new SqlParameter("@cateID",SqlDbType.Int),
                    new SqlParameter("@proimg",SqlDbType.NChar),
                    new SqlParameter("@sort",SqlDbType.Int),
                    new SqlParameter("@seotitle",SqlDbType.NChar),
                    new SqlParameter("@keys",SqlDbType.NChar),
                    new SqlParameter("@descr",SqlDbType.NChar),
                };
                pa[0].Value = pro.doc.title;
                pa[1].Value = pro.doc.contents;
                pa[2].Value = pro.doc.cateID;
                pa[3].Value = pro.docFile.url;
                pa[4].Value = pro.doc.sort;
                pa[5].Value = pro.doc.seoTitle;
                pa[6].Value = pro.doc.keys;
                pa[7].Value = pro.doc.descr;
                int count=0;
                DbHelperSQL.RunProcedure("p_pro_AddProInfo", pa, out count);
                if (count > 0)
                    return true;
            }
        }
        return false;
    }

    /// <summary>
    /// 查询最热产品
    /// </summary>
    /// <param name="topCount"></param>
    /// <returns></returns>
    public DataTable GetHotProList(string topCount)
    {
        if (topCount != null)
        {
            int top;
            if(!Int32.TryParse(topCount, out top))
                top = 3;
            string sql = "SELECT TOP " + top.ToString() + " kd.ID,kd.title, kd.cateID, kd.contents, kd.post, kd.postDate, kd.seoTitle, kd.[keys], kd.descr, kd.sort, kf.[url], kf.[type] FROM k_Document kd left JOIN k_File kf ON kf.DocID = kd.ID WHERE kd.cateID=4 OR kd.cateID IN (SELECT kc.ID  FROM k_Category kc WHERE  kc.upID=4) order by kd.sort desc ,kd.postDate desc";
            DataSet ds=DbHelperSQL.Query(sql);
            if (ds != null && ds.Tables.Count > 0)
                return ds.Tables[0];
        }
        return null;
    }

    /// <summary>
    /// 获取产品
    /// typeid 分类ID，为“”或-1表示全部产品
    /// </summary>
    /// <param name="pageindex"></param>
    /// <param name="pagesize"></param>
    /// <param name="typeid"></param>
    /// <param name="totalCount"></param>
    /// <returns></returns>
    public DataTable GetProListByType(int pageindex, int pagesize, string typeid, out int totalCount)
    {
        totalCount = 0;
        if (typeid != null)
        {
            SqlParameter[] pa = new SqlParameter[] { 
                new SqlParameter("@pageindex",SqlDbType.Int),
                new SqlParameter("@pagesize",SqlDbType.Int),
                new SqlParameter("@count",SqlDbType.Int),
                new SqlParameter("@typeid",SqlDbType.NVarChar)
            
            };
            pa[0].Value = pageindex;
            pa[1].Value = pagesize;
            pa[2].Direction = ParameterDirection.Output;
            pa[3].Value = typeid;
            DataSet ds = DbHelperSQL.RunProcedure("p_pro_getProList", pa, "tab_news");
            Int32.TryParse(pa[2].Value.ToString(), out totalCount);
            if (ds != null && ds.Tables.Count > 0)
            {
                return ds.Tables[0];
            }
        }
        return null;
    }

    /// <summary>
    /// 获取详情产品
    /// </summary>
    /// <param name="proId"></param>
    /// <returns></returns>
    public DataTable GetProInfoByProId(string proId)
    {
        if (proId != null && proId != "")
        {
            string sql = "SELECT kd.ID, kd.title, kd.cateID, kd.contents, kd.post, kd.postDate, kd.seoTitle, kd.keys, kd.descr, kd.sort, CASE ISNULL(kf.[url],'') WHEN '' THEN 'default.jpg' ELSE kf.[url] END AS url, kf.type FROM k_Document kd left JOIN k_File kf ON kd.ID=kf.DocID WHERE kd.[state]=1 AND kd.ID='" + proId + "'";
            DataSet ds = DbHelperSQL.Query(sql);
            if (ds != null && ds.Tables.Count > 0)
                return ds.Tables[0];
        }
        return null;
    }

    /// <summary>
    /// 获取所有产品，并返回id为priid产品的索引；
    /// </summary>
    /// <param name="priid"></param>
    /// <param name="index"></param>
    /// <returns></returns>
    public DataTable GetAllPro(string priid,out int index)
    {
        index = 0;
        string sql = "SELECT * FROM V_AllPro vap ORDER by postDate desc";
        DataSet ds = DbHelperSQL.Query(sql);
        if (ds != null && ds.Tables.Count > 0)
        {
            DataTable dt=ds.Tables[0];
            //for (int i = 0; i < dt.Rows.Count; i++)
            {
                //string temp_id = dt.Rows[i]["ID"].ToString();
               // if (temp_id == priid)
                //{
                   // index = i;
                   // break;
               // }
            }
            return dt;
        }
        return null;
    }

    /// <summary>
    /// 删除指定ID的产品
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    public bool DelProById(string id,bool istrue)
    {
        if (id != null)
        {
            string sql = "";
            if (istrue)
            {
                sql = "delete from k_Document where id='" + id + "';delete from k_File where DocId='"+id+"'";
            }
            else
            {
                sql = "update k_Document set [state]=0 where id='"+id+"'";
            }
            int count=DbHelperSQL.ExecuteSql(sql);
            return count > 0 ? true : false;
        }
        return false;
    }
    #endregion

}
