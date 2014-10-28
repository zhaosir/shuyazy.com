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
///DocumentMaster 的摘要说明
/// </summary>
public class DocumentMaster:MasterBase
{
    CategoryMaster cates = new CategoryMaster();
    private readonly DocumentDal dal = new DocumentDal();
    private readonly FileDal fileDal = new FileDal();
    public static DataTable list;
    public static Document model;



    protected int inedx;
	public DocumentMaster()
	{
		//
		//TODO: 在此处添加构造函数逻辑
		//
	}

    /// <summary>
    /// 添加文档
    /// </summary>
    /// <param name="model"></param>
    protected void Add(Document model)
    {
        inedx = dal.Add(model);
        msg = "添加成功！";
    }

    /// <summary>
    /// 修改
    /// </summary>
    /// <param name="model"></param>
    protected void Update(Document model)
    {
        inedx = model.ID;
        dal.Update(model);
        msg = "修改成功！";
    }

    /// <summary>
    /// 删除文档
    /// </summary>
    /// <param name="ID"></param>
    protected void Delete(int ID)
    {
        //if (HasFile(ID))
        {
            //msg = "拥有相关图片或文件，请先删除图片或文件";
        }
        //else
        {
            
        }
        dal.Delete(ID);
    }

    /// <summary>
    /// 选择文档
    /// </summary>
    /// <param name="ID"></param>
    public void setIndex(int ID)
    {
        model = dal.GetModel(ID);
    }

    /// <summary>
    /// 文档是否拥有图片或文件
    /// </summary>
    /// <param name="ID">ID</param>
    /// <returns></returns>
    public bool HasFile(int ID)
    {
        if (fileDal.GetList("DocID=" + ID).Tables[0].Rows.Count > 0)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    public Category getCategorry(int ID)
    {
        return cates.GetModel(ID);
    }

    /// <summary>
    /// 获取实体
    /// </summary>
    /// <param name="ID"></param>
    /// <returns></returns>
    public Document GetModel(int ID)
    {
        return dal.GetModel(ID);
    }

    /// <summary>
    /// 获取文档的附件表,如果type为0返回图片列表,如果type为1返回其它文件,否则返回所有文件
    /// </summary>
    /// <param name="ID">ID</param>
    /// <param name="type">文件类型</param>
    /// <returns></returns>
    public DataSet GetFiles(int ID,int type)
    {
        if (type == 0 || type == 1)
        {
            return fileDal.GetList("DocID=" + ID + " and type=" + type);
        }
        else
        {
            return fileDal.GetList("DocID=" + ID);
        }
    }

    /// <summary>
    /// 获取一产品类型的文档
    /// </summary>
    /// <param name="ID">ID</param>
    /// <returns></returns>
    public Product GetProduct(int ID)
    {
        Product pro = new Product();
        pro.doc = dal.GetModel(ID);
        pro.docFile = fileDal.ToModel(GetFiles(ID, 0));
        return pro;
    }

    /// <summary>
    /// 搜索文档
    /// </summary>
    /// <param name="keyword">关键字</param>
    /// <param name="cateID">分类ID</param>
    /// <param name="state">状态</param>
    public int select(string keyword, int cateID, int state, int pageIndex)
    {
        string sqlWhere = "";
        sqlWhere = "cateID in(select ID from k_Category where upID=" + cateID + " or cateID=" + cateID + ") and title like '%" + keyword + "%' and builded =" + state;
        sqlWhere.Replace("delete", "删除");

        list = dal.GetList(10, pageIndex, sqlWhere).Tables[0];
        return dal.GetList(sqlWhere).Tables[0].Rows.Count;

    }

    /// <summary>
    /// 将三级栏目绑定到指定下拉菜单
    /// </summary>
    /// <param name="ddl"></param>
    public void BindCates(DropDownList ddl)
    {
        ddl.DataTextField = "category";
        ddl.DataValueField = "ID";

        DataTable dt = cates.GetList(0).Tables[0];

        foreach (DataRow dr in dt.Rows)
        {
            ListItem item = new ListItem(dr["category"].ToString(), dr["ID"].ToString());
            ddl.Items.Add(item);

            foreach (DataRow row in cates.GetList(Convert.ToInt32(dr["ID"].ToString())).Tables[0].Rows)
            {
                ddl.Items.Add(new ListItem("----" + row["category"].ToString(), row["ID"].ToString()));

                foreach (DataRow r in cates.GetList(Convert.ToInt32(row["ID"].ToString())).Tables[0].Rows)
                {
                    ddl.Items.Add(new ListItem("------" + r["category"].ToString(), r["ID"].ToString()));
                }
            }
        }
    }


    public void setValue(string name, string value,int ID)
    {
        dal.setValue(name, value, ID);
    }

    /// <summary>
    /// 将搜索结果显示在gridview
    /// </summary>
    /// <param name="gv"></param>
    public void Bind(GridView gv)
    {
        gv.DataSource = list;
        gv.DataBind();
    }
}
