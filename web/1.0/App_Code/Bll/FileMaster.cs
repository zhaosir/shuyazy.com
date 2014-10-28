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
///FileMaster 的摘要说明
/// </summary>
public class FileMaster:MasterBase
{
    private readonly FileDal dal = new FileDal();
    public FileMaster()
    {
        //
        //TODO: 在此处添加构造函数逻辑
        //
    }

    protected void add(Kpages.Model.File model)
    {
        dal.Add(model);
        msg = "添加成功！";
    }

    protected void Update(Kpages.Model.File model)
    {
        dal.Update(model);
        msg = "修改成功！";
    }

    protected void Delete(int ID)
    {
        dal.Delete(ID);
        msg = "删除成功!";
    }

    public DataSet GetList(string sqlStr)
    {
        return dal.GetList(sqlStr);
    }

    public Kpages.Model.File GetModel(int ID)
    {
        return dal.GetModel(ID);
    }

}
