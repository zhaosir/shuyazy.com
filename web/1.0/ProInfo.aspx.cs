using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class corp_ProList : PageBase
{
    public int cateID;
    public string proid;
    protected void Page_Load(object sender, EventArgs e)
    {
        keywords.Content = Keyword;
        desrc.Content = Descr;

        if (Request.QueryString["cateID"] != null)
        {
            cateID = Convert.ToInt32(Request.QueryString["cateID"].ToString());
        }
        else
        {
            cateID = 16;
        }
        if (Request.QueryString["ID"] != null)
        {
            proid = Request.QueryString["ID"].ToString();
        }
        else
            this.Response.Redirect("ProList.aspx");

        MyDataBind(proid);
       // list.cateID = cateID;
    }

    public void MyDataBind(string proid)
    {
        Bll_Model bll_model = new Bll_Model();
        System.Data.DataTable dt= bll_model.GetProInfoByProId(proid);
        int index = 0;
        //System.Data.DataTable dt = bll_model.GetAllPro(proid, out index);
        if (dt == null)
        {
            this.Response.Redirect("Error.aspx?errid=9");
        }
        else
        {
            des_ProDes.InnerHtml = dt.Rows[0]["contents"].ToString();
            pro_img.Src = "../ProImg/sy_" + dt.Rows[0]["url"].ToString();
            string proName=dt.Rows[0]["title"].ToString();
            pro_img.Alt = proName;
            pro_img.Attributes.Add("title", proName);
            li_proName.Text = proName;
        }
    }
}
