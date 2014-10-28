using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using Maticsoft.DBUtility;//请先添加引用
using System.Data;
using System.Data.SqlClient;
/// <summary>
/// Dal_Message 的摘要说明
/// </summary>
public class Dal_Message
{
	public Dal_Message()
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
    public bool AddMessage(Message msg,out int type)
    {
        type = -1;
        if (msg != null)
        {
            SqlParameter[] pa = new SqlParameter[] { 
                new SqlParameter("@name",SqlDbType.NVarChar),
                new SqlParameter("@sex",SqlDbType.NVarChar),
                new SqlParameter("@age",SqlDbType.NVarChar),
                new SqlParameter("@email",SqlDbType.NVarChar),
                new SqlParameter("@address",SqlDbType.NVarChar),
                new SqlParameter("@ipaddress",SqlDbType.NVarChar),
                new SqlParameter("@content",SqlDbType.NVarChar),
                new SqlParameter("@phone",SqlDbType.NVarChar),
                new SqlParameter("@title",SqlDbType.NVarChar)
            };
            pa[0].Value=msg.Name;
            pa[1].Value = msg.Sex;
            pa[2].Value = msg.Age;
            pa[3].Value = msg.Email;
            pa[4].Value = msg.Address;
            pa[5].Value = msg.IpAddress;
            pa[6].Value = msg.Content;
            pa[7].Value = msg.Phone;
            pa[8].Value = msg.Title;
            int result = 0;
            type=DbHelperSQL.RunProcedure("p_message_addMessage", pa, out result);
            return result == 1 ? true : false;
        }
        return false;
    }

    /// <summary>
    /// 删除一条留言
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    public bool DelMessageById(string id)
    {
        if (id != null&&!id.Contains("'"))
        {
            try
            {
                Guid msgid = new Guid(id) ;
                string sql = "UPDATE tab_message SET [state] = 0 where [state]!=0 and id='"+msgid.ToString()+"'";
                int result = DbHelperSQL.ExecuteSql(sql);
                return result == 1 ? true : false;
            }
            catch (Exception e)
            {
                return false;
            }
        }
        return false;
    }

    /// <summary>
    /// 查看留言
    /// </summary>
    /// <param name="pageindex"></param>
    /// <param name="pagesize"></param>
    /// <param name="count"></param>
    /// <returns></returns>
    public DataTable GetMsgList(int pageindex,int pagesize,out int count )
    {
        count = 0;
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
            DataSet ds=DbHelperSQL.RunProcedure("p_message_getMessage", pa, "tab_message");
            Int32.TryParse(pa[2].Value.ToString(), out count);
            if (ds != null && ds.Tables.Count > 0)
            {
                return ds.Tables[0];
            }
        }
        return null;
    }
}
