using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

public partial class kpagesAdmin_NewsInfo : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void btn_submit_Click(object sender, EventArgs e)
    {
        string title = this.txt_title.Text;
        string content = this.FCKeditor1.Value;
        if (title.Trim() == "")
        {
            return;
        }
        if (content.Trim() == "")
        {
            return;
        }
        Kpages.Model.Document news = new Kpages.Model.Document();
        news.title = title;
        news.contents = content;
        news.cateID = 6;
        Bll_Model bllmodel = new Bll_Model();
        bllmodel.AddNews(news);
    }
}
