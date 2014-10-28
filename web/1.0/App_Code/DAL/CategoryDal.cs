using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Maticsoft.DBUtility;//请先添加引用
namespace Kpages.DAL
{
    /// <summary>
    /// 数据访问类Category。
    /// </summary>
    public class CategoryDal:DalBase
    {
        public CategoryDal()
        { }
        #region  成员方法

        /// <summary>
        /// 得到最大ID
        /// </summary>
        public int GetMaxId()
        {
            return DbHelperSQL.GetMaxID("ID", "k_Category");
        }

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int ID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from k_Category");
            strSql.Append(" where ID=@ID ");
            SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.Int,4)};
            parameters[0].Value = ID;

            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }



        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int upID,string category)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from k_Category");
            strSql.Append(" where upID=@upID and category=@category ");
            SqlParameter[] parameters = {
					new SqlParameter("@upID", SqlDbType.Int,4),
                    new SqlParameter("@category", SqlDbType.VarChar,50)
                                        };
            parameters[0].Value = upID;
            parameters[1].Value = category;

            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }


        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(Kpages.Model.Category model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into k_Category(");
            strSql.Append("category,upID,linkType,type,link,sort)");
            strSql.Append(" values (");
            strSql.Append("@category,@upID,@linkType,@type,@link,@sort)");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
					new SqlParameter("@category", SqlDbType.VarChar,100),
					new SqlParameter("@upID", SqlDbType.Int,4),
					new SqlParameter("@linkType", SqlDbType.Int,4),
					new SqlParameter("@type", SqlDbType.Int,4),
					new SqlParameter("@link", SqlDbType.VarChar,100),
					new SqlParameter("@sort", SqlDbType.Int,4)};
            parameters[0].Value = model.category;
            parameters[1].Value = model.upID;
            parameters[2].Value = model.linkType;
            parameters[3].Value = model.type;
            parameters[4].Value = model.link;
            parameters[5].Value = model.sort;

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
        public void Update(Kpages.Model.Category model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update k_Category set ");
            strSql.Append("category=@category,");
            strSql.Append("upID=@upID,");
            strSql.Append("linkType=@linkType,");
            strSql.Append("type=@type,");
            strSql.Append("link=@link,");
            strSql.Append("sort=@sort");
            strSql.Append(" where ID=@ID ");
            SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.Int,4),
					new SqlParameter("@category", SqlDbType.VarChar,100),
					new SqlParameter("@upID", SqlDbType.Int,4),
					new SqlParameter("@linkType", SqlDbType.Int,4),
					new SqlParameter("@type", SqlDbType.Int,4),
					new SqlParameter("@link", SqlDbType.VarChar,100),
					new SqlParameter("@sort", SqlDbType.Int,4)};
            parameters[0].Value = model.ID;
            parameters[1].Value = model.category;
            parameters[2].Value = model.upID;
            parameters[3].Value = model.linkType;
            parameters[4].Value = model.type;
            parameters[5].Value = model.link;
            parameters[6].Value = model.sort;

            DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public void Delete(int ID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from k_Category ");
            strSql.Append(" where ID=@ID ");
            SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.Int,4)};
            parameters[0].Value = ID;

            DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
        }


        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public Kpages.Model.Category GetModel(int ID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 ID,category,upID,linkType,type,link,sort from k_Category ");
            strSql.Append(" where ID=@ID ");
            SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.Int,4)};
            parameters[0].Value = ID;

            Kpages.Model.Category model = new Kpages.Model.Category();
            DataSet ds = DbHelperSQL.Query(strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["ID"].ToString() != "")
                {
                    model.ID = int.Parse(ds.Tables[0].Rows[0]["ID"].ToString());
                }
                model.category = ds.Tables[0].Rows[0]["category"].ToString();
                if (ds.Tables[0].Rows[0]["upID"].ToString() != "")
                {
                    model.upID = int.Parse(ds.Tables[0].Rows[0]["upID"].ToString());
                }
                if (ds.Tables[0].Rows[0]["linkType"].ToString() != "")
                {
                    model.linkType = int.Parse(ds.Tables[0].Rows[0]["linkType"].ToString());
                }
                if (ds.Tables[0].Rows[0]["type"].ToString() != "")
                {
                    model.type = int.Parse(ds.Tables[0].Rows[0]["type"].ToString());
                }
                model.link = ds.Tables[0].Rows[0]["link"].ToString();
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

        public Kpages.Model.Category ToModel(DataSet ds)
        {
            Kpages.Model.Category model = new Kpages.Model.Category();
            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["ID"].ToString() != "")
                {
                    model.ID = int.Parse(ds.Tables[0].Rows[0]["ID"].ToString());
                }
                model.category = ds.Tables[0].Rows[0]["category"].ToString();
                if (ds.Tables[0].Rows[0]["upID"].ToString() != "")
                {
                    model.upID = int.Parse(ds.Tables[0].Rows[0]["upID"].ToString());
                }
                if (ds.Tables[0].Rows[0]["linkType"].ToString() != "")
                {
                    model.linkType = int.Parse(ds.Tables[0].Rows[0]["linkType"].ToString());
                }
                if (ds.Tables[0].Rows[0]["type"].ToString() != "")
                {
                    model.type = int.Parse(ds.Tables[0].Rows[0]["type"].ToString());
                }
                model.link = ds.Tables[0].Rows[0]["link"].ToString();
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
            strSql.Append("select ID,category,upID,linkType,type,link,sort ");
            strSql.Append(" FROM k_Category ");
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
            strSql.Append(" ID,category,upID,linkType,type,link,sort ");
            strSql.Append(" FROM k_Category ");
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
            parameters[0].Value = "k_Category";
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

