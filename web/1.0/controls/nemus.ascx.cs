using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using Kpages.Model;

public partial class controls_nemus:ControlBase
{
    private int _rootID;

    protected void Page_Load(object sender, EventArgs e)
    {
        
    }

    public int rootID
    {
        set { _rootID = value; }
        get { return _rootID; }
    }

    private int _showNextNav;

    public int showNextNav
    {
        set { _showNextNav = value; }
        get { return _showNextNav; }
    }
}
