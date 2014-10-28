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
///UserMaster 的摘要说明
/// </summary>
public class UserMaster:MasterBase
{
    private readonly UserInfoDal dal = new UserInfoDal();
	public UserMaster()
	{
		//
		//TODO: 在此处添加构造函数逻辑
		//
	}

    /// <summary>
    /// 注册用户
    /// </summary>
    /// <param name="model"></param>
    /// <returns></returns>
    protected void Add(UserInfo model)
    {
        if (!dal.Exists(model.userName))
        {
            dal.Add(model);
            msg = "添加用户成功!";
        }
        else
        {
            msg = "已存在此用户名!";
        }
        
    }

    /// <summary>
    /// 更新用户信息
    /// </summary>
    /// <param name="model"></param>
    protected void Update(UserInfo model)
    {
        dal.Update(model);
        msg = "用户信息修改成功!";
    }

    /// <summary>
    /// 删除用户
    /// </summary>
    /// <param name="ID"></param>
    protected void Delete(int ID)
    {
        dal.Delete(ID);
        msg = "用户信息删除成功!";
        
    }

    /// <summary>
    /// 判断用户登录
    /// </summary>
    /// <param name="userName">用户名</param>
    /// <param name="password">密码</param>
    /// <returns></returns>
    public bool Login(string userName, string password)
    {
        string sqlstr = " userName='" + userName + "' and password='" + password + "'";
        Kpages.Model.UserInfo model = dal.ToModel(dal.GetList(sqlstr));
        if (model != null)
        {
            Session["user"] = model;
            Session["type"] = model.type;
            return true;
        }
        else
        {
            msg = "用户名或密码不对";
            return false;
        }
    }

    /// <summary>
    /// 获取用户集
    /// </summary>
    /// <returns></returns>
    public DataSet GetList()
    {
        return dal.GetList("");
    }

    public string GetMsg()
    {
        return msg;
    }

    public void Bind(GridView gv)
    {
        gv.DataSource = GetList();
        gv.DataBind();
    }



}
