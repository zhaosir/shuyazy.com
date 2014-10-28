using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;



/// <summary>
///Mailmaster 的摘要说明
/// </summary>
public class Mailmaster:MasterBase
{
	public Mailmaster()
	{
		//
		//TODO: 在此处添加构造函数逻辑
		//
	}

    public string get(string name)
    {
        return ConfigurationManager.AppSettings[name].ToString();
    }

    public void set(string name,string value)
    {
        ConfigurationManager.AppSettings[name] = value;
    }


}
