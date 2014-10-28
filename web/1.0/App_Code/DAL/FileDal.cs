using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Maticsoft.DBUtility;//请先添加引用
namespace Kpages.DAL
{
    /// <summary>
    /// 数据访问类File。
    /// </summary>
    public class FileDal:DalBase
    {
        public FileDal()
        { }
        #region  成员方法

        /// <summary>
        /// 得到最大ID
        /// </summary>
        public int GetMaxId()
        {
            return DbHelperSQL.GetMaxID("ID", "k_File");
        }

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int ID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from k_File");
            strSql.Append(" where ID=@ID ");
            SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.Int,4)};
            parameters[0].Value = ID;

            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }


        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(Kpages.Model.File model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into k_File(");
            strSql.Append("DocID,title,url,type,sort)");
            strSql.Append(" values (");
            strSql.Append("@DocID,@title,@url,@type,@sort)");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
					new SqlParameter("@DocID", SqlDbType.Int,4),
					new SqlParameter("@title", SqlDbType.VarChar,50),
					new SqlParameter("@url", SqlDbType.VarChar,200),
					new SqlParameter("@type", SqlDbType.Int,4),
					new SqlParameter("@sort", SqlDbType.Int,4)};
            parameters[0].Value = model.DocID;
            parameters[1].Value = model.title;
            parameters[2].Value = model.url;
            parameters[3].Value = model.type;
            parameters[4].Value = model.sort;

            object obj = DbHelperSQL.GetSingle(strSql.ToString(), parameters);
            if (obj == null)
            {
                return 1;
            }
            else
            {
                return Convert.ToInt32(obj);
            }
        }
        /// <summary>
        /// 更新一条数据
        /// </summary>
        public void Update(Kpages.Model.File model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update k_File set ");
            strSql.Append("DocID=@DocID,");
            strSql.Append("title=@title,");
            strSql.Append("url=@url,");
            strSql.Append("type=@type,");
            strSql.Append("sort=@sort");
            strSql.Append(" where ID=@ID ");
            SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.Int,4),
					new SqlParameter("@DocID", SqlDbType.Int,4),
					new SqlParameter("@title", SqlDbType.VarChar,50),
					new SqlParameter("@url", SqlDbType.VarChar,200),
					new SqlParameter("@type", SqlDbType.Int,4),
					new SqlParameter("@sort", SqlDbType.Int,4)};
            parameters[0].Value = model.ID;
            parameters[1].Value = model.DocID;
            parameters[2].Value = model.title;
            parameters[3].Value = model.url;
            parameters[4].Value = model.type;
            parameters[5].Value = model.sort;

            DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public void Delete(int ID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from k_File ");
            strSql.Append(" where ID=@ID ");
            SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.Int,4)};
            parameters[0].Value = ID;

            DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
        }


        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public Kpages.Model.File GetModel(int ID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 ID,DocID,title,url,type,sort from k_File ");
            strSql.Append(" where ID=@ID ");
            SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.Int,4)};
            parameters[0].Value = ID;

            Kpages.Model.File model = new Kpages.Model.File();
            DataSet ds = DbHelperSQL.Query(strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["ID"].ToString() != "")
                {
                    model.ID = int.Parse(ds.Tables[0].Rows[0]["ID"].ToString());
                }
                if (ds.Tables[0].Rows[0]["DocID"].ToString() != "")
                {
                    model.DocID = int.Parse(ds.Tables[0].Rows[0]["DocID"].ToString());
                }
                model.title = ds.Tables[0].Rows[0]["title"].ToString();
                model.url = ds.Tables[0].Rows[0]["url"].ToString();
                if (ds.Tables[0].Rows[0]["type"].ToString() != "")
                {
                    model.type = int.Parse(ds.Tables[0].Rows[0]["type"].ToString());
                }
                if (ds.Tables[0].Rows[0]["sort"].ToString() != "")
                {
                    model.sort = int.Parse(ds.Tables[0].Rows[0]["sort"].ToString());
                }
                return model;
            }
            else
            {
                return null;
            }
        }


        public Model.File ToModel(DataSet ds)
        {
            Kpages.Model.File model = new Kpages.Model.File();
            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["ID"].ToString() != "")
                {
                    model.ID = int.Parse(ds.Tables[0].Rows[0]["ID"].ToString());
                }
                if (ds.Tables[0].Rows[0]["DocID"].ToString() != "")
                {
                    model.DocID = int.Parse(ds.Tables[0].Rows[0]["DocID"].ToString());
                }
                model.title = ds.Tables[0].Rows[0]["title"].ToString();
                model.url = ds.Tables[0].Rows[0]["url"].ToString();
                if (ds.Tables[0].Rows[0]["type"].ToString() != "")
                {
                    model.type = int.Parse(ds.Tables[0].Rows[0]["type"].ToString());
                }
                if (ds.Tables[0].Rows[0]["sort"].ToString() != "")
                {
                    model.sort = int.Parse(ds.Tables[0].Rows[0]["sort"].ToString());
                }
                return model;
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetList(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select ID,DocID,title,url,type,sort ");
            strSql.Append(" FROM k_File ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            return DbHelperSQL.Query(strSql.ToString());
        }

        /// <summary>
        /// 获得前几行数据
        /// </summary>
        public DataSet GetList(int Top, string strWhere, string filedOrder)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select ");
            if (Top > 0)
            {
                strSql.Append(" top " + Top.ToString());
            }
            strSql.Append(" ID,DocID,title,url,type,sort ");
            strSql.Append(" FROM k_File ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            strSql.Append(" order by " + filedOrder);
            return DbHelperSQL.Query(strSql.ToString());
        }

        /*
        /// <summary>
        /// 分页获取数据列表
        /// </summary>
        public DataSet GetList(int PageSize,int PageIndex,string strWhere)
        {
            SqlParameter[] parameters = {
                    new SqlParameter("@tblName", SqlDbType.VarChar, 255),
                    new SqlParameter("@fldName", SqlDbType.VarChar, 255),
                    new SqlParameter("@PageSize", SqlDbType.Int),
                    new SqlParameter("@PageIndex", SqlDbType.Int),
                    new SqlParameter("@IsReCount", SqlDbType.Bit),
                    new SqlParameter("@OrderType", SqlDbType.Bit),
                    new SqlParameter("@strWhere", SqlDbType.VarChar,1000),
                    };
            parameters[0].Value = "k_File";
            parameters[1].Value = "ID";
            parameters[2].Value = PageSize;
            parameters[3].Value = PageIndex;
            parameters[4].Value = 0;
            parameters[5].Value = 0;
            parameters[6].Value = strWhere;	
            return DbHelperSQL.RunProcedure("UP_GetRecordByPage",parameters,"ds");
        }*/

        #endregion  成员方法
    }
}

