using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class controls_Cates :ControlBase
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    private int _upID;

    public int upID
    {
        set { _upID = value; }
        get { return _upID; }
    }


}
