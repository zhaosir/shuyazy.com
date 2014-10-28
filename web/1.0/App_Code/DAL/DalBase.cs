using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Maticsoft.DBUtility;//请先添加引用

/// <summary>
///DalBase 的摘要说明
/// </summary>
public class DalBase
{
	public DalBase()
	{

	}
    protected int SetValue(string table, string flName, string value, int type, string strWhere)
    {
        int result;
        StringBuilder sqlStr = new StringBuilder();
        try
        {
            sqlStr.Append("update " + table + " set [");
            if (type == 0) //字段为 string 类型
            {
                sqlStr.Append(flName + "] ='" + value + "'");
            }
            else if (type == 1) //如果字段为int 类型
            {
                sqlStr.Append(flName + "] =" + Convert.ToInt32(value));
            }

            if (strWhere != null && strWhere != "")
            {
                sqlStr.Append(" where " + strWhere);
            }

            result = DbHelperSQL.ExecuteSql(ClearKeys(sqlStr.ToString()));
        }
        catch (Exception ex)
        {
            throw ex;
        }

        return result;

    }

    /// <summary>
    /// 自定义查询
    /// </summary>
    /// <param name="sqlStr">查询语句</param>
    /// <returns>数据集</returns>
    public DataSet Query(string sqlStr)
    {
        sqlStr = ClearKeys(sqlStr);
        return DbHelperSQL.Query(sqlStr);
    }

    /// <summary>
    /// 清除sql 不安全关键字
    /// </summary>
    /// <param name="sqlStr"></param>
    /// <returns></returns>
    public string ClearKeys(string sqlStr)
    {
        sqlStr.Replace("delete", "删除");
        sqlStr.Replace("update", "更新");
        sqlStr.Replace("insert", "添加");
        sqlStr.Replace("drop", "清除");

        return sqlStr;
    }
}
