using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;

public partial class kpagesAdmin_document_Document :DocumentMaster
{


    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["userName"] == null)
            this.Response.Redirect(@"~\kpagesAdmin\Login.aspx");
        if (!IsPostBack)
        {
            BindCates(ddl);
            if (Request.QueryString["cateID"] != null)
            {
                ddl.SelectedValue = Request.QueryString["cateID"].ToString();
                if (Request.QueryString["page"] != null)
                {
                    Search();
                }
            }
 
        }
    }

    /// <summary>
    /// 删除所选记录
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void Delete(Object sender, EventArgs e)
    {
        foreach (GridViewRow row in gv.Rows)
        {
            CheckBox cb = (CheckBox)row.FindControl("CheckBox1");
            if (cb.Checked == true)
            {
                string str = row.Cells[1].Text;
                Delete(Convert.ToInt32(row.Cells[0].Text.ToString()));
            }
        }
        Search();
        Bind(gv);
    }

    protected void New(Object sender, EventArgs e)
    {
        Response.Redirect("DocumentInfo.aspx?upID=" + ddl.SelectedValue);
    }

    protected void Search(object sender, EventArgs e)
    {
        Search();
    }

    /// <summary>
    /// 搜索
    /// </summary>
    public void Search()
    {
        int cateID = Convert.ToInt32(ddl.SelectedValue);
        string keyword = tbKeyword.Value.Trim();
        int state = Convert.ToInt32(ddlState.Value);

        if (Request.QueryString["page"] != null)
        {
            int num = select(keyword, cateID, state, Convert.ToInt32(Request.QueryString["page"].ToString()));
            Bind(gv);
            pages.Text = printPage(num, 10, Convert.ToInt32(Request.QueryString["page"].ToString()));

        }
        else
        {
            int num = select(keyword, cateID, state, 1);
            Bind(gv);

            pages.Text = printPage(num, 10, 1);

        }
    }
    /// <summary>
    /// 打印分页代码
    /// </summary>
    /// <param name="num"></param>
    /// <param name="pagesize"></param>
    /// <param name="pageIndex"></param>
    /// <returns></returns>
    public string printPage(int num,int pagesize,int pageIndex)
    {
        string str = "";
        if (num > pagesize)
        {
            int m = num / pagesize;
            for (int i = 1; i <= m+1; i++)
            {
                if (i == pageIndex)
                {
                    str += "<span class='current'>" + i + "</a>";
                }
                else
                {
                    str += "<a href='Document.aspx?page=" + i + "&cateID=" + Convert.ToInt32(ddl.SelectedValue) + "'>" + i + "</a>";
                }
            }

            return str;
        }
        else
        {
            return null;
        }
    }


    static int sortBydate = 0;
    static int sortByhits = 0;

    protected void SortByDate(object sender, EventArgs e)
    {
        if (sortBydate == 0)
        {
            Sort("postDate desc");
            sortBydate = 1;
        }
        else if (sortBydate == 1)
        {
            Sort("postDate");
            sortBydate = 0;
        }
        
    }

    protected void SortByHits(object sender, EventArgs e)
    {
        if (sortByhits == 0)
        {
            Sort("sort desc");
            sortByhits = 1;
        }
        else
        {
            Sort("sort");
            sortByhits = 0;
        }
       
    }


    protected void Push(object sender, EventArgs e)
    {
        foreach (GridViewRow row in gv.Rows)
        {
            CheckBox cb = (CheckBox)row.FindControl("CheckBox1");
            if (cb.Checked == true)
            {
                string str = row.Cells[0].Text.ToString();

                setValue("state", "1", Convert.ToInt32(str));
            }
        }
        Search();
        Bind(gv);
    }


    protected void Build(object sender, EventArgs e)
    {
        foreach (GridViewRow row in gv.Rows)
        {
            CheckBox cb = (CheckBox)row.FindControl("CheckBox1");
            if (cb.Checked == true)
            {
                string str = row.Cells[0].Text.ToString();

                setValue("builded", "1", Convert.ToInt32(str));
            }
        }
        Search();
        Bind(gv);
    }

    /// <summary>
    /// 排序
    /// </summary>
    /// <param name="type"></param>
    public void Sort(string type)
    {
        DataView dv = new DataView(list);
        dv.Sort = type;
        Bind(gv, dv.ToTable());
    }
}
