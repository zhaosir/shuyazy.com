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
/// Bll_Message 的摘要说明
/// </summary>
public class Bll_Message
{
	public Bll_Message()
	{
		//
		// TODO: 在此处添加构造函数逻辑
		//
	}

    /// <summary>
    /// 新增留言
    /// </summary>
    /// <param name="msg"></param>
    /// <param name="type">-1 Msg为空，0留言成功，1同一IP留言间隔小</param>
    /// <returns>true 成功，false失败</returns>
    public bool AddNewMessage(Message msg,out int type)
    {
        type = -1;
        if (msg != null)
        {
            Dal_Message dal_msg=new Dal_Message();
            return dal_msg.AddMessage(msg, out type);
        }
        return false;
    }

    public bool CheckMessage(Message msg)
    {
        return true;
    }

    /// <summary>
    /// 查看留言
    /// </summary>
    /// <param name="pageindex"></param>
    /// <param name="pagesize"></param>
    /// <param name="count"></param>
    /// <returns></returns>
    public DataTable GetMsgList(int pageindex, int pagesize, out int count)
    {
        Dal_Message dal_msg = new Dal_Message();
        return dal_msg.GetMsgList( pageindex,  pagesize, out count);
    }

    /// <summary>
    /// 删除一条留言
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    public bool DelMessageById(string id)
    {
        return new Dal_Message().DelMessageById(id);
    }
}
