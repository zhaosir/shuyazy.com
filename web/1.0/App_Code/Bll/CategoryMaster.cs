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
using Kpages.Model;

/// <summary>
///CategoryMaster 的摘要说明
/// </summary>
public class CategoryMaster:MasterBase
{
    private readonly CategoryDal dal = new CategoryDal();
	public CategoryMaster()
	{

	}

    protected bool add(Category model)
    {
        if (dal.Exists(model.upID, model.category))
        {
            msg = "本级已存在些栏目名称!";
            return false;
        }
        else
        {
            dal.Add(model);
            msg = "添加成功！";
            return true;
        }

    }

    protected bool Update(Category model)
    {
        if (dal.Exists(model.upID, model.category))
        {
            msg = "本级已存在些栏目名称!";
            return false;
        }
        else
        {
            dal.Update(model);
            msg = "修改成功！";
            return true;
        }
    }

    /// <summary>
    /// 删除指定栏目
    /// </summary>
    /// <param name="ID"></param>
    /// <returns></returns>
    protected bool Delete(int ID)
    {
        if (Isparent(ID))
        {
            msg = "拥有下级栏目,请先删除下级栏目!";
            return false;
        }
        else
        {
            if (HasDoc(ID))
            {
                msg = "栏目拥有文档,请先删除此栏目文档!";
                return false;
            }
            else
            {
                dal.Delete(ID);
                msg = "删除成功!";
                return true;
            }

        }
    }

    /// <summary>
    /// 是否有下级栏目
    /// </summary>
    /// <param name="ID"></param>
    /// <returns></returns>
    public bool Isparent(int ID)
    {
        if (GetList(ID).Tables[0].Rows.Count > 0)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    /// <summary>
    /// 获取指定的下级集合
    /// </summary>
    /// <param name="upID"></param>
    /// <returns></returns>
    public DataSet GetList(int upID)
    {
        return dal.GetList("upID=" + upID);
    }

    /// <summary>
    /// 栏目下是否有文档
    /// </summary>
    /// <param name="ID">ID</param>
    /// <returns></returns>
    public bool HasDoc(int ID)
    {
        DocumentDal docDal = new DocumentDal();
        if (docDal.GetList("cateID=" + ID).Tables[0].Rows.Count > 0)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    /// <summary>
    /// 获取实体
    /// </summary>
    /// <param name="ID">ID</param>
    /// <returns></returns>
    public Category GetModel(int ID)
    {
        return dal.GetModel(ID);
    }

 
}
