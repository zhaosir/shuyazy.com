using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Kpages.Model;
using System.Data;


public partial class controls_DocList :ControlBase
{
    public Kpages.DAL.DocumentDal dal = new Kpages.DAL.DocumentDal();
    public List<Document> list;
    protected void Page_Load(object sender, EventArgs e)
    {
        string sqlWhere = "state =1 and cateID=" + cateID;
        list = ConvertList<Document>(dal.GetList(num,sqlWhere,"ID desc").Tables[0]);
    }

    /// <summary>
    /// 带图文档
    /// </summary>
    /// <param name="cateID"></param>
    /// <returns></returns>
    public DataTable GetPros()
    {
        string sqlWhere = "cateID=" + cateID;
        return dal.GetProList(num, sqlWhere).Tables[0];
    }

    /// <summary>
    /// 文档第一张图片
    /// </summary>
    /// <param name="docID"></param>
    /// <returns></returns>
    public string GetFilePath(int docID)
    {
        Kpages.DAL.FileDal fileDal = new Kpages.DAL.FileDal();

        string sqlWhere = "docID=" + docID;
        return fileDal.GetList(sqlWhere).Tables[0].Rows[0]["url"].ToString();
    }

    /// <summary>
    /// 在产品类型是是否显示图片 0:显示,1不显示,2显示固定的图片,3自动
    /// </summary>
    private int _showPic;
    public int showPic
    {
        set { _showPic = value; }
        get { return _showPic; }
    }

    /// <summary>
    /// 是否显示发布时间0:显示,1不显示
    /// </summary>
    private int _showTime;
    public int showTime
    {
        set { _showTime = value; }
        get { return _showTime; }
    }

    /// <summary>
    /// 列表文档所属分类
    /// </summary>
    private int _cateID;
    public int cateID
    {
        set { _cateID = value; }
        get { return _cateID; }
    }
    
    /// <summary>
    /// 列表文档数量
    /// </summary>
    private int _num;
    public int num
    {
        set { _num = value; }
        get { return _num; }
    }

    /// <summary>
    /// 列表文档类型 0:文档,1为产品
    /// </summary>
    private int _type;
    public int type
    {
        set { _type = value; }
        get { return _type; }
    }

    /// <summary>
    /// 网站根目录
    /// </summary>
    private string _baseUrl;
    public string ImgbaseUrl
    {
        set { _baseUrl = value; }
        get { return _baseUrl; }
    }


}
