using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Maticsoft.DBUtility;//请先添加引用
namespace Kpages.DAL
{
    /// <summary>
    /// 数据访问类UserInfo。
    /// </summary>
    public class UserInfoDal:DalBase
    {
        public UserInfoDal()
        { }
        #region  成员方法

        /// <summary>
        /// 得到最大ID
        /// </summary>
        public int GetMaxId()
        {
            return DbHelperSQL.GetMaxID("ID", "k_UserInfo");
        }

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int ID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from k_UserInfo");
            strSql.Append(" where ID=@ID ");
            SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.Int,4)};
            parameters[0].Value = ID;

            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }


        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(string name)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from k_UserInfo");
            strSql.Append(" where userName=@userName ");
            SqlParameter[] parameters = {
					new SqlParameter("@userName", SqlDbType.VarChar,50)};
            parameters[0].Value = name;

            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }


        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(Kpages.Model.UserInfo model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into k_UserInfo(");
            strSql.Append("userName,password,regDate,sex,birthday,mail,type,tel)");
            strSql.Append(" values (");
            strSql.Append("@userName,@password,@regDate,@sex,@birthday,@mail,@type,@tel)");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
					new SqlParameter("@userName", SqlDbType.VarChar,50),
					new SqlParameter("@password", SqlDbType.VarChar,50),
					new SqlParameter("@regDate", SqlDbType.DateTime),
					new SqlParameter("@sex", SqlDbType.Int,4),
					new SqlParameter("@birthday", SqlDbType.DateTime),
					new SqlParameter("@mail", SqlDbType.VarChar,100),
					new SqlParameter("@type", SqlDbType.Int,4),
					new SqlParameter("@tel", SqlDbType.VarChar,20)};
            parameters[0].Value = model.userName;
            parameters[1].Value = model.password;
            parameters[2].Value = DateTime.Now;
            parameters[3].Value = model.sex;
            parameters[4].Value = model.birthday;
            parameters[5].Value = model.mail;
            parameters[6].Value = 0;
            parameters[7].Value = model.tel;

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
        public void Update(Kpages.Model.UserInfo model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update k_UserInfo set ");
            strSql.Append("userName=@userName,");
            strSql.Append("password=@password,");
            strSql.Append("regDate=@regDate,");
            strSql.Append("sex=@sex,");
            strSql.Append("birthday=@birthday,");
            strSql.Append("mail=@mail,");
            strSql.Append("type=@type,");
            strSql.Append("tel=@tel");
            strSql.Append(" where ID=@ID ");
            SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.Int,4),
					new SqlParameter("@userName", SqlDbType.VarChar,50),
					new SqlParameter("@password", SqlDbType.VarChar,50),
					new SqlParameter("@regDate", SqlDbType.DateTime),
					new SqlParameter("@sex", SqlDbType.Int,4),
					new SqlParameter("@birthday", SqlDbType.DateTime),
					new SqlParameter("@mail", SqlDbType.VarChar,100),
					new SqlParameter("@type", SqlDbType.Int,4),
					new SqlParameter("@tel", SqlDbType.VarChar,20)};
            parameters[0].Value = model.ID;
            parameters[1].Value = model.userName;
            parameters[2].Value = model.password;
            parameters[3].Value = model.regDate;
            parameters[4].Value = model.sex;
            parameters[5].Value = model.birthday;
            parameters[6].Value = model.mail;
            parameters[7].Value = model.type;
            parameters[8].Value = model.tel;

            DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public void Delete(int ID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from k_UserInfo ");
            strSql.Append(" where ID=@ID ");
            SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.Int,4)};
            parameters[0].Value = ID;

            DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
        }


        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public Kpages.Model.UserInfo GetModel(int ID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 ID,userName,password,regDate,sex,birthday,mail,type,tel from k_UserInfo ");
            strSql.Append(" where ID=@ID ");
            SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.Int,4)};
            parameters[0].Value = ID;

            Kpages.Model.UserInfo model = new Kpages.Model.UserInfo();
            DataSet ds = DbHelperSQL.Query(strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["ID"].ToString() != "")
                {
                    model.ID = int.Parse(ds.Tables[0].Rows[0]["ID"].ToString());
                }
                model.userName = ds.Tables[0].Rows[0]["userName"].ToString();
                model.password = ds.Tables[0].Rows[0]["password"].ToString();
                if (ds.Tables[0].Rows[0]["regDate"].ToString() != "")
                {
                    model.regDate = DateTime.Parse(ds.Tables[0].Rows[0]["regDate"].ToString());
                }
                if (ds.Tables[0].Rows[0]["sex"].ToString() != "")
                {
                    model.sex = int.Parse(ds.Tables[0].Rows[0]["sex"].ToString());
                }
                if (ds.Tables[0].Rows[0]["birthday"].ToString() != "")
                {
                    model.birthday = DateTime.Parse(ds.Tables[0].Rows[0]["birthday"].ToString());
                }
                model.mail = ds.Tables[0].Rows[0]["mail"].ToString();
                if (ds.Tables[0].Rows[0]["type"].ToString() != "")
                {
                    model.type = int.Parse(ds.Tables[0].Rows[0]["type"].ToString());
                }
                model.tel = ds.Tables[0].Rows[0]["tel"].ToString();
                return model;
            }
            else
            {
                return null;
            }
        }


        public Model.UserInfo ToModel(DataSet ds)
        {
            Kpages.Model.UserInfo model = new Kpages.Model.UserInfo();
            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["ID"].ToString() != "")
                {
                    model.ID = int.Parse(ds.Tables[0].Rows[0]["ID"].ToString());
                }
                model.userName = ds.Tables[0].Rows[0]["userName"].ToString();
                model.password = ds.Tables[0].Rows[0]["password"].ToString();
                if (ds.Tables[0].Rows[0]["regDate"].ToString() != "")
                {
                    model.regDate = DateTime.Parse(ds.Tables[0].Rows[0]["regDate"].ToString());
                }
                if (ds.Tables[0].Rows[0]["sex"].ToString() != "")
                {
                    model.sex = int.Parse(ds.Tables[0].Rows[0]["sex"].ToString());
                }
                if (ds.Tables[0].Rows[0]["birthday"].ToString() != "")
                {
                    model.birthday = DateTime.Parse(ds.Tables[0].Rows[0]["birthday"].ToString());
                }
                model.mail = ds.Tables[0].Rows[0]["mail"].ToString();
                if (ds.Tables[0].Rows[0]["type"].ToString() != "")
                {
                    model.type = int.Parse(ds.Tables[0].Rows[0]["type"].ToString());
                }
                model.tel = ds.Tables[0].Rows[0]["tel"].ToString();
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
            strSql.Append("select ID,userName,password,regDate,sex,birthday,mail,type,tel ");
            strSql.Append(" FROM k_UserInfo ");
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
            strSql.Append(" ID,userName,password,regDate,sex,birthday,mail,type,tel ");
            strSql.Append(" FROM k_UserInfo ");
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
            parameters[0].Value = "k_UserInfo";
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

