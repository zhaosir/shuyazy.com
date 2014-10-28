using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Collections.Generic;
using System.Reflection;

using Kpages.Model;
using Kpages.Common;

/// <summary>
///ControlBase 的摘要说明
/// </summary>
public class ControlBase : System.Web.UI.UserControl
{
	public ControlBase()
	{
		//
		//TODO: 在此处添加构造函数逻辑
		//
	}

    public string BaseUrl
    {
        get
        {
            string sUrl = Request.Url.AbsoluteUri;
            if (sUrl.Contains("?"))
            {
                string rul = sUrl.Substring(0, sUrl.LastIndexOf("?"));
                rul = sUrl.Substring(0, sUrl.LastIndexOf("/"));
                rul = sUrl.Substring(0, sUrl.LastIndexOf("/"));
                return rul.Substring(0, rul.LastIndexOf("/"));
            }
            else
            {
                return sUrl.Substring(0, sUrl.LastIndexOf("/"));

            }
        }
    }

    public string RootUrl
    {
        get {
            string sUrl = Request.Url.AbsoluteUri;

            return sUrl.Substring(0, sUrl.LastIndexOf(Request.CurrentExecutionFilePath));
        }
    }



    /// <summary>
    /// DataTable to List
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="dt"></param>
    /// <returns></returns>
    public static List<T> ConvertList<T>(DataTable dt)
    {
        List<T> result = new List<T>();

        // 定义Converter委托
        Converter<DataRow, T> converter = delegate(DataRow row)
        {
            // 创建泛型对象
            T rowInstance = Activator.CreateInstance<T>();

            // 获取泛型对象的属性集合
            PropertyInfo[] properties = typeof(T).GetProperties();

            // 通过反射遍历对象的每个属性
            foreach (PropertyInfo property in properties)
            {
                // 判断是否存在以属性名称为字段名称的列，若存在则对泛型对象的属性进行赋值
                if (row.Table.Columns.Contains(property.Name))
                {
                    // 注意需要将值转换成属性相同的类型
                    property.SetValue(rowInstance, Convert.ChangeType(row[property.Name], property.PropertyType), null);
                }
            }

            return rowInstance;
        };

        // 这里和Array.ConvertAll的实现方式相同
        foreach (DataRow row in dt.Rows)
        {
            result.Add(converter(row));
        }

        return result;
    }


    #region Category 操作

    Kpages.DAL.CategoryDal cates = new Kpages.DAL.CategoryDal();

    /// <summary>
    /// 获取实体列表
    /// </summary>
    /// <param name="upID"></param>
    /// <returns></returns>
    public List<Category> GetCates(int upID)
    {
        if (DataCache.GetCache("cates_" + upID) != null)
        {
            return DataCache.GetCache("cates_" + upID) as List<Category>;
        }
        else
        {
            string sqlWhere = "upID=" + upID;
            List<Category> list = ConvertList<Category>(cates.GetList(sqlWhere).Tables[0]);
            DataCache.SetCache("cates_" + upID, list);
            return list;
        }

    }

    /// <summary>
    /// 获取实体数据模型
    /// </summary>
    /// <param name="ID"></param>
    /// <returns></returns>
    public Category GetModel(int ID)
    {
        return cates.GetModel(ID);
    }

    /// <summary>
    /// 是否为父级
    /// </summary>
    /// <param name="ID"></param>
    /// <returns></returns>
    public bool isParent(int ID)
    {
        if (GetCates(ID).Count > 0)
        {
            return true;
        }
        else
        {
            return false;
        }

    }

    Kpages.DAL.DocumentDal docDal = new Kpages.DAL.DocumentDal();
    /// <summary>
    /// 获取此分类的文档数
    /// </summary>
    /// <param name="ID"></param>
    /// <returns></returns>
    public int  GetDocCount(int ID)
    {

        string sqlWhere = "cateID=" + ID;

        return docDal.GetList(sqlWhere).Tables[0].Rows.Count;

    }

    /// <summary>
    /// 获取此分类子类的第一个文档
    /// </summary>
    /// <param name="ID">分类ID</param>
    /// <returns></returns>
    public int GetFirstDoc(int ID)
    {
        int docID = 0;

        string sqlWhere = "select top 1 ID from k_Document where cateID in (select ID from k_Category where upID=" + ID + " or cateID="+ID+")";
        DataTable dt = docDal.Query(sqlWhere).Tables[0];
        if (dt.Rows.Count >= 1)
        {
            return Convert.ToInt32(dt.Rows[0]["ID"].ToString());
        }
        else
        {
            return docID;
        }
        
    }

    /// <summary>
    /// 获取第一个下次分类ID
    /// </summary>
    /// <param name="ID"></param>
    /// <returns></returns>
    public int GetFirstCate(int ID)
    {
        string sqlWhere = "select top 1 ID from k_Category where upID=" + ID;
        DataTable dt = docDal.Query(sqlWhere).Tables[0];
        if (dt.Rows.Count >= 1)
        {
            return Convert.ToInt32(dt.Rows[0]["ID"].ToString());
        }
        else
        {
            return 0;
        }
    }
    #endregion
}
