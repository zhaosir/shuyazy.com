using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Collections.Generic;
using System.Reflection;

using Kpages.Model;
using System.Xml;


/// <summary>
///BasePage 的摘要说明
/// </summary>
public class PageBase :System.Web.UI.Page
{
    static PageBase()
    {

    }

    public string BaseUrl
    {
        get
        {
            string sUrl = Request.Url.AbsoluteUri;
            return sUrl.Substring(0, sUrl.LastIndexOf("/"));
        }
    }


    /// <summary>
    /// 登录人ID，对应Users里的USERID
    /// </summary>
    public string USERID
    {
        get
        {
            if (Session["USERID"] != null)
                return Session["USERID"].ToString();
            else
                return "";
        }
        set
        {
            Session["USERID"] = value;
        }
    }




    #region 页面加载流程
    private void Page_Load(object sender, System.EventArgs e)
    {
        Page_LoadAlwayInit();

        Page_LoadAlways();

        if (IsPostBack)
        {

        }
        else
        {
            Page_LoadOnce();
        }
    }


    protected void Page_Init(object sender, EventArgs e)
    {
        string xmlpath = Server.MapPath("~/App_Data/SiteConfig.xml");
        configHelper = new Kpages.IO.IOHelperXml(xmlpath);
    }
    protected virtual void Page_LoadOnce()
    {

    }


    protected virtual void Page_LoadPostBack()
    {

    }

    protected virtual void Page_LoadAlways()
    {

        Page_LoadPostBack();
    }

    private void Page_LoadAlwayInit()
    {

    }
    #endregion

    #region 基类方法

    public void AlertMessage(string title, string msg)
    {
        msg = msg.Replace("\\", "\\\\");
        msg = msg.Replace("\r\n", "\\n");
        msg = msg.Replace("\n", "\\n");
        msg = msg.Replace("\"", "\\\"");
        string script = "";
        if (title == null)
            script = "<script>Ext.onReady(function(){Ext.MessageBox.alert('" + msg + "');})</script>";
        else
            script = "<script>Ext.onReady(function(){Ext.MessageBox.alert('" + title + "', '" + msg + "');})</script>";
        ClientScript.RegisterStartupScript(this.GetType(), System.Guid.NewGuid().ToString(), script);
    }




    /// <summary>
    /// 返回上一页
    /// </summary>
    public void JavascriptGoBack()
    {
        string script = "<script>history.go(-1);</script>";
        ClientScript.RegisterStartupScript(this.GetType(), System.Guid.NewGuid().ToString(), script);
    }

    /// <summary>
    /// 执行JavaScript方法
    /// </summary>
    /// <param name="script"></param>
    public void JavascriptFun(string script)
    {
        string AllScript = string.Format("<script>{0}</script>", script);
        ClientScript.RegisterStartupScript(this.GetType(), System.Guid.NewGuid().ToString(), AllScript);
    }

    /// <summary>
    /// 关闭窗口
    /// </summary>
    public void JavascriptClose()
    {
        string script = "<script>window.opener = null;window.close();</script>";
        ClientScript.RegisterStartupScript(this.GetType(), System.Guid.NewGuid().ToString(), script);
    }

    /// <summary>
    /// 跳转到其他页面
    /// </summary>
    /// <param name="url">页面地址</param>
    public void JavascriptGoUrl(string url)
    {
        string script = string.Format("<script>location = '{0}';</script>", url);
        ClientScript.RegisterStartupScript(this.GetType(), System.Guid.NewGuid().ToString(), script);
    }

    /// <summary>
    /// 显示信息并跳转页面
    /// </summary>
    /// <param name="message"></param>
    /// <param name="url"></param>
    public void ShowMessageAndGoUrl(string message, string url)
    {
        string script = string.Format("<script>alert('{0}');location.href='{1}';</script>", message, url);
        ClientScript.RegisterStartupScript(this.GetType(), System.Guid.NewGuid().ToString(), script);
    }


    /// <summary>
    /// 获取MD5值
    /// </summary>
    /// <param name="data">原字符串</param>
    /// <returns>通过MD5加密后的</returns>
    public string GetMd5Code(string data)
    {
        return System.Web.Security.FormsAuthentication.HashPasswordForStoringInConfigFile(data, "md5").ToUpper();
    }


    /// <summary>
    /// 返回上一页
    /// </summary>
    protected bool GoBack()
    {
        if (ViewState["BackUrl"] != null)
        {
            Response.Redirect(ViewState["BackUrl"].ToString());
            return true;
        }
        else
            return false;
    }


    /// <summary>
    /// 将列转化成字符串形式用逗号分隔
    /// </summary>
    /// <param name="columns">列字符串</param>
    public string GetTableColumns(DataColumnCollection columns)
    {
        string title = "";
        foreach (DataColumn col in columns)
        {
            //title += GetSafeString(col.ColumnName).Replace(',', '_') + ",";
        }
        return title.Remove(title.Length - 1);
    }


    public static string CutString(string str, int maxlength)
    {
        if (str.Length > maxlength)
            return str.Substring(0, maxlength) + "....";
        else return str;
    }
    #endregion 基类方法

    #region Web 窗体设计器生成的代码
    override protected void OnInit(EventArgs e)
    {
        //
        // CODEGEN: 该调用是 ASP.NET Web 窗体设计器所必需的。
        //
        InitializeComponent();
        base.OnInit(e);
    }

    /// <summary>
    /// 设计器支持所需的方法 - 不要使用代码编辑器修改
    /// 此方法的内容。
    /// </summary>
    private void InitializeComponent()
    {
        this.Load += new System.EventHandler(this.Page_Load);
    }

    /// <summary>
    /// DataTable to List
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="dt"></param>
    /// <returns></returns>
    public static List<T> ConvertList<T>(DataTable dt)
    {
        List<T> result = new List<T>();

        // 定义Converter委托
        Converter<DataRow, T> converter = delegate(DataRow row)
        {
            // 创建泛型对象
            T rowInstance = Activator.CreateInstance<T>();

            // 获取泛型对象的属性集合
            PropertyInfo[] properties = typeof(T).GetProperties();

            // 通过反射遍历对象的每个属性
            foreach (PropertyInfo property in properties)
            {
                // 判断是否存在以属性名称为字段名称的列，若存在则对泛型对象的属性进行赋值
                if (row.Table.Columns.Contains(property.Name))
                {
                    // 注意需要将值转换成属性相同的类型
                    property.SetValue(rowInstance, Convert.ChangeType(row[property.Name], property.PropertyType), null);
                }
            }

            return rowInstance;
        };

        // 这里和Array.ConvertAll的实现方式相同
        foreach (DataRow row in dt.Rows)
        {
            result.Add(converter(row));
        }

        return result;
    }

    #endregion



    #region Category 操作

    Kpages.DAL.CategoryDal cates =new Kpages.DAL.CategoryDal();

    /// <summary>
    /// 获取实体列表
    /// </summary>
    /// <param name="upID"></param>
    /// <returns></returns>
    public List<Category> GetCates(int upID)
    {
        string sqlWhere = "upID=" + upID;
        return ConvertList<Category>(cates.GetList(sqlWhere).Tables[0]);
    }

    /// <summary>
    /// 获取实体数据模型
    /// </summary>
    /// <param name="ID"></param>
    /// <returns></returns>
    public Category GetModel(int ID)
    {
        return cates.GetModel(ID);
    }

    /// <summary>
    /// 是否为父级
    /// </summary>
    /// <param name="ID"></param>
    /// <returns></returns>
    public bool isParent(int ID)
    {
        if (GetCates(ID).Count > 0)
        {
            return true;
        }
        else
        {
            return false;
        }

    }


    Kpages.DAL.DocumentDal docDal = new Kpages.DAL.DocumentDal();
    /// <summary>
    /// 获取实体
    /// </summary>
    /// <param name="ID"></param>
    /// <returns></returns>
    protected Document GetDoc(int ID)
    {
        return docDal.GetModel(ID);
    }

    protected DataTable GetCateDoc(int ID)
    {
        string strSql = "cateID=" + ID;

        return docDal.GetList(1, strSql, "ID desc").Tables[0];

    }


    /// <summary>
    /// 获取文档的第一张图片
    /// </summary>
    /// <param name="ID"></param>
    /// <returns></returns>
    public string GetImageByDocID(int ID)
    {
        DataTable dt = GetImages(ID);
        if (dt.Rows.Count > 0)
        {
            return dt.Rows[0]["url"].ToString();
        }
        else
        {
            return null;
        }
    }

    /// <summary>
    /// 按文档ID查询本文档的图片
    /// </summary>
    /// <param name="ID"></param>
    /// <returns></returns>
    public DataTable GetImages(int ID)
    {
        Kpages.DAL.FileDal fileDal = new Kpages.DAL.FileDal();
        return fileDal.GetList("docID=" + ID).Tables[0];
    }

    #endregion

    #region config 操作

    Kpages.IO.IOHelperXml configHelper;
    public string Title
    {
        get {
            return configHelper.SelectNode("site/title").InnerText;
        }
    }


    public string Keyword
    {
        get {
            return configHelper.SelectNode("site/keywords").InnerText;
        }
    }
    public string CopyRight
    {
        get {
            return configHelper.SelectNode("site/copyRight").InnerText;
        }
    }

    public string Descr
    {
        get {
            return configHelper.SelectNode("site/description").InnerText;
        }
    }

    public string WebSite
    {
        get {
            return configHelper.SelectNode("site/webSite").InnerText;
        }
    }

    public string Tel
    {
        get
        {
            return configHelper.SelectNode("site/tel").InnerText;
        }
    }

    #endregion




}
