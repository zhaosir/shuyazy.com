using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class corp_Index :PageBase
{
    protected void Page_Load(object sender, EventArgs e)
    {
        keywords.Content = Keyword;
        desrc.Content = Descr;
        DataBind();
    }

    private void DataBind()
    {
        Bll_Model bll_model = new Bll_Model();
        rep_hotpro.DataSource = bll_model.GetHotProList("3");
        rep_hotpro.DataBind();
    }
}
