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
using System.IO;
using System.Web.Configuration;
public partial class Test : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        EncryptConnStrings();
    }
    private void EncryptConnStrings()
    {
        Configuration config = 
            WebConfigurationManager.OpenWebConfiguration(Request.ApplicationPath);
        ConfigurationSection connectionStrings = config.GetSection("connectionStrings");
        if (connectionStrings != null)
            if (!connectionStrings.SectionInformation.IsProtected)
            {
                connectionStrings.SectionInformation.ProtectSection(
                    "DataProtectionConfigurationProvider");
                config.Save();
            }
    }
}
