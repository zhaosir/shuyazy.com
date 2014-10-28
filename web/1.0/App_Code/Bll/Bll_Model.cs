using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

/// <summary>
/// Bll_Model 的摘要说明
/// </summary>
public class Bll_Model
{
	public Bll_Model()
	{
		//
		// TODO: 在此处添加构造函数逻辑
		//
	}
    Dal_Model dal_model = new Dal_Model();

    #region 最新资讯
    /// <summary>
    /// 获取最新资讯
    /// </summary>
    /// <param name="pageIndex"></param>
    /// <param name="pageSize"></param>
    /// <param name="totalCount"></param>
    /// <returns></returns>
    public DataTable GetNewsTable(int pageIndex, int pageSize, out int totalCount)
    {
        
        return dal_model.GetNewsTable(pageIndex, pageSize, out totalCount);
    }
    /// <summary>
    /// 
    /// </summary>
    /// <param name="model"></param>
    /// <returns></returns>
    public bool AddNews(Kpages.Model.Document news)
    {
        Kpages.DAL.DocumentDal documentDal = new Kpages.DAL.DocumentDal();
        int i = documentDal.Add(news);
        if (i > 0)
            return true;
        return false;
    }

    public bool DelNews()
    {
        return true;
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
            if (pro.doc != null&&pro.docFile!=null)
            {
                return dal_model.AddProInfo(pro);
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
            return dal_model.GetHotProList(topCount);
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
        return dal_model.GetProListByType(pageindex, pagesize, typeid, out totalCount);
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
            return dal_model.GetProInfoByProId(proId);
        }
        return null;
    }

    /// <summary>
    /// 获取所有产品，并返回id为priid产品的索引；
    /// </summary>
    /// <param name="priid"></param>
    /// <param name="index"></param>
    /// <returns></returns>
    public DataTable GetAllPro(string priid, out int index)
    {
        index = 0;
        return dal_model.GetAllPro(priid, out index);
    }


     /// <summary>
    /// 删除指定ID的产品
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    public bool DelProById(string id, bool istrue,string imgPath,string dirPath)
    {
        if (istrue)
        {
            string img = dirPath+"\\" + imgPath;
            string s_imgPath = dirPath + "\\s_" + imgPath;
            string sy_imgPath = dirPath + "\\sy_" + imgPath;
            delFile(img);
            delFile(s_imgPath);
            delFile(sy_imgPath);
        }
        bool res = dal_model.DelProById(id, istrue);
        if (res && istrue)
        {
            //删除图片
        }
        return res;
    }

    public bool delFile(string path)
    {
        bool res=true;
        try
        {
            string fullpath = System.IO.Path.GetFullPath(path);
            if (System.IO.File.Exists(fullpath))
                System.IO.File.Delete(fullpath);
        }
        catch (Exception ex)
        {
            res = false;
        }
        return res;
    }
    #endregion
}
