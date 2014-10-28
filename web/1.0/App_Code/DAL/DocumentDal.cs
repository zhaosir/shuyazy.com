using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Maticsoft.DBUtility;//请先添加引用
namespace Kpages.DAL
{
    /// <summary>
    /// 数据访问类Document。
    /// </summary>
    public class DocumentDal:DalBase
    {
        public DocumentDal()
        { }
        #region  成员方法

        /// <summary>
        /// 得到最大ID
        /// </summary>
        public int GetMaxId()
        {
            return DbHelperSQL.GetMaxID("ID", "k_Document");
        }

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int ID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from k_Document");
            strSql.Append(" where ID=@ID ");
            SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.Int,4)};
            parameters[0].Value = ID;

            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }


        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(Kpages.Model.Document model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into k_Document(");
            strSql.Append("title,cateID,contents,seoTitle,keys,descr)");
            strSql.Append(" values (");
            strSql.Append("@title,@cateID,@contents,@seoTitle,@keys,@descr)");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
					new SqlParameter("@title", SqlDbType.VarChar,100),
					new SqlParameter("@cateID", SqlDbType.Int,4),
					new SqlParameter("@contents", SqlDbType.Text),
					new SqlParameter("@seoTitle", SqlDbType.VarChar,50),
					new SqlParameter("@keys", SqlDbType.VarChar,100),
					new SqlParameter("@descr", SqlDbType.VarChar,200)
                                        };
            parameters[0].Value = model.title;
            parameters[1].Value = model.cateID;
            parameters[2].Value = model.contents;
            parameters[3].Value = model.seoTitle;
            parameters[4].Value = model.keys;
            parameters[5].Value = model.descr;


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
        public void Update(Kpages.Model.Document model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update k_Document set ");
            strSql.Append("title=@title,");
            strSql.Append("cateID=@cateID,");
            strSql.Append("contents=@contents,");
            strSql.Append("post=@post,");
            strSql.Append("postDate=@postDate,");
            strSql.Append("seoTitle=@seoTitle,");
            strSql.Append("keys=@keys,");
            strSql.Append("descr=@descr,");
            strSql.Append("sort=@sort,");
            strSql.Append("state=@state,");
            strSql.Append("builded=@builded");
            strSql.Append(" where ID=@ID ");
            SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.Int,4),
					new SqlParameter("@title", SqlDbType.VarChar,100),
					new SqlParameter("@cateID", SqlDbType.Int,4),
					new SqlParameter("@contents", SqlDbType.Text),
					new SqlParameter("@post", SqlDbType.Int,4),
					new SqlParameter("@postDate", SqlDbType.DateTime),
					new SqlParameter("@seoTitle", SqlDbType.VarChar,50),
					new SqlParameter("@keys", SqlDbType.VarChar,100),
					new SqlParameter("@descr", SqlDbType.VarChar,200),
					new SqlParameter("@sort", SqlDbType.Int,4),
					new SqlParameter("@state", SqlDbType.Int,4),
					new SqlParameter("@builded", SqlDbType.Int,4)};
            parameters[0].Value = model.ID;
            parameters[1].Value = model.title;
            parameters[2].Value = model.cateID;
            parameters[3].Value = model.contents;
            parameters[4].Value = model.post;
            parameters[5].Value = model.postDate;
            parameters[6].Value = model.seoTitle;
            parameters[7].Value = model.keys;
            parameters[8].Value = model.descr;
            parameters[9].Value = model.sort;
            parameters[10].Value = model.state;
            parameters[11].Value = model.builded;

            DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
        }


        /// <summary>
        ///  设置值
        /// </summary>
        /// <param name="name"></param>
        /// <param name="value"></param>
        /// <param name="id"></param>
        public void setValue(string name, string value,int id)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update k_Document set ");
            strSql.Append(name + "=@name");
            strSql.Append(" where ID=@ID");

            SqlParameter[] parameters = { 
                            new SqlParameter("@name",value),
                            new SqlParameter("@ID",id)
                                        };

            DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);


        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public void Delete(int ID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("update k_Document set state=0");
            strSql.Append(" where ID=@ID ");
            SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.Int,4)};
            parameters[0].Value = ID;

            DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
        }


        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public Kpages.Model.Document GetModel(int ID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 ID,title,cateID,contents,post,postDate,seoTitle,keys,descr,sort,state,builded from k_Document ");
            strSql.Append(" where ID=@ID ");
            SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.Int,4)};
            parameters[0].Value = ID;

            Kpages.Model.Document model = new Kpages.Model.Document();
            DataSet ds = DbHelperSQL.Query(strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["ID"].ToString() != "")
                {
                    model.ID = int.Parse(ds.Tables[0].Rows[0]["ID"].ToString());
                }
                model.title = ds.Tables[0].Rows[0]["title"].ToString();
                if (ds.Tables[0].Rows[0]["cateID"].ToString() != "")
                {
                    model.cateID = int.Parse(ds.Tables[0].Rows[0]["cateID"].ToString());
                }
                model.contents = ds.Tables[0].Rows[0]["contents"].ToString();
                if (ds.Tables[0].Rows[0]["post"].ToString() != "")
                {
                    model.post = int.Parse(ds.Tables[0].Rows[0]["post"].ToString());
                }
                if (ds.Tables[0].Rows[0]["postDate"].ToString() != "")
                {
                    model.postDate = DateTime.Parse(ds.Tables[0].Rows[0]["postDate"].ToString());
                }
                model.seoTitle = ds.Tables[0].Rows[0]["seoTitle"].ToString();
                model.keys = ds.Tables[0].Rows[0]["keys"].ToString();
                model.descr = ds.Tables[0].Rows[0]["descr"].ToString();
                if (ds.Tables[0].Rows[0]["sort"].ToString() != "")
                {
                    model.sort = int.Parse(ds.Tables[0].Rows[0]["sort"].ToString());
                }
                if (ds.Tables[0].Rows[0]["state"].ToString() != "")
                {
                    model.state = int.Parse(ds.Tables[0].Rows[0]["state"].ToString());
                }
                if (ds.Tables[0].Rows[0]["builded"].ToString() != "")
                {
                    model.builded = int.Parse(ds.Tables[0].Rows[0]["builded"].ToString());
                }
                return model;
            }
            else
            {
                return null;
            }
        }

        public Model.Document ToModel(DataSet ds)
        {
            Kpages.Model.Document model = new Kpages.Model.Document();
            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["ID"].ToString() != "")
                {
                    model.ID = int.Parse(ds.Tables[0].Rows[0]["ID"].ToString());
                }
                model.title = ds.Tables[0].Rows[0]["title"].ToString();
                if (ds.Tables[0].Rows[0]["cateID"].ToString() != "")
                {
                    model.cateID = int.Parse(ds.Tables[0].Rows[0]["cateID"].ToString());
                }
                model.contents = ds.Tables[0].Rows[0]["contents"].ToString();
                if (ds.Tables[0].Rows[0]["post"].ToString() != "")
                {
                    model.post = int.Parse(ds.Tables[0].Rows[0]["post"].ToString());
                }
                if (ds.Tables[0].Rows[0]["postDate"].ToString() != "")
                {
                    model.postDate = DateTime.Parse(ds.Tables[0].Rows[0]["postDate"].ToString());
                }
                model.seoTitle = ds.Tables[0].Rows[0]["seoTitle"].ToString();
                model.keys = ds.Tables[0].Rows[0]["keys"].ToString();
                model.descr = ds.Tables[0].Rows[0]["descr"].ToString();
                if (ds.Tables[0].Rows[0]["sort"].ToString() != "")
                {
                    model.sort = int.Parse(ds.Tables[0].Rows[0]["sort"].ToString());
                }
                if (ds.Tables[0].Rows[0]["state"].ToString() != "")
                {
                    model.state = int.Parse(ds.Tables[0].Rows[0]["state"].ToString());
                }
                if (ds.Tables[0].Rows[0]["builded"].ToString() != "")
                {
                    model.builded = int.Parse(ds.Tables[0].Rows[0]["builded"].ToString());
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
            strSql.Append("select ID,title,cateID,contents,post,postDate,seoTitle,keys,descr,sort,state,builded ");
            strSql.Append(" FROM k_Document ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            return DbHelperSQL.Query(strSql.ToString());
        }
        

        /// <summary>
        /// 获得数据列表
        /// add by comger at 2010-07-22 for cms 
        /// </summary>
        /// <param name="strWhere">查询条件</param>
        /// <returns>SqlDataReader 的数据集</returns>
        public SqlDataReader GetListBackReader(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select ID,title,cateID,contents,post,postDate,seoTitle,keys,descr,sort,state,builded ");
            strSql.Append(" FROM k_Document ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            return DbHelperSQL.ExecuteReader(strSql.ToString());
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
            strSql.Append(" * ");
            strSql.Append(" FROM k_Document ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            strSql.Append(" order by " + filedOrder);
            return DbHelperSQL.Query(strSql.ToString());
        }

        
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
            parameters[0].Value = "k_Document";
            parameters[1].Value = "ID";
            parameters[2].Value = PageSize;
            parameters[3].Value = PageIndex;
            parameters[4].Value = 0;
            parameters[5].Value = 0;
            parameters[6].Value = strWhere;	
            return DbHelperSQL.RunProcedure("GetRecordByPage",parameters,"ds");
        }



        /// <summary>
        /// 搜索带图的文档，并加返回第一张图的信息
        /// </summary>
        /// <param name="num"></param>
        /// <param name="strWhere"></param>
        /// <returns></returns>
        public DataSet GetProList(int num, string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select distinct top " + num);
            strSql.Append(" k_Document.ID,k_Document.title,k_Document.cateID,k_Document.state,k_Document.postDate,k_Document.sort,");
            strSql.Append(" k_File.DocID,k_File.url,k_File.title");
            strSql.Append(" FROM k_Document join k_File on k_Document.ID = k_File.DocID");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            return DbHelperSQL.Query(strSql.ToString());
        }
        #endregion  成员方法
    }
}

