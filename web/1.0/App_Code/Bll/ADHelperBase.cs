using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using Kpages.IO;
using System.Xml;

/// <summary>
///ADHelperBase 的摘要说明
/// </summary>
public class ADHelperBase:MasterBase
{
    IOHelperXml helper;
    XmlNode rootNode;
	public ADHelperBase()
	{
        helper = new IOHelperXml(Server.MapPath("~/ad/xml/bcastr.xml"));

        rootNode = helper.SelectNode("bcaster");

	}

    public DataTable GetList()
    {
       return helper.GetTableFromNode(rootNode, "item");
    }

    public void Update(string ID, string imgUrl, string link)
    {
        string xpath = "/bcaster/item[@id='" + ID + "']";

        XmlNode node = helper.SelectNode(xpath);

        node.Attributes["item_url"].Value = imgUrl;
        node.Attributes["link"].Value = link;
        helper.Save();

    }

    public void Add(string imgUrl, string link)
    {
        XmlNode node = helper.CreateNode("item");

        helper.AddAttribute(node, "id", (Convert.ToInt32(getMaxID()) + 1).ToString());
        helper.AddAttribute(node, "item_url", imgUrl);
        helper.AddAttribute(node, "link", link);
        
        helper.AddNode(rootNode, node);
       
    }

    public void Delete(int ID)
    {
        string xpath = "/bcaster/item[@id='" + ID + "']";

        XmlNode node = helper.SelectNode(xpath);

        rootNode.RemoveChild(node);

        helper.Save();

    }

    public string getMaxID()
    {
       return rootNode.LastChild.Attributes["id"].Value;
    }

    /// <summary>
    /// 获取记录
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    public ADItem GetItem(string id)
    {
        string xpath = "/bcaster/item[@id='" + id + "']";

        XmlNode node = helper.SelectNode(xpath);

        ADItem item = new ADItem();
        item.id = id;
        item.item_url = node.Attributes["item_url"].Value;
        item.link = node.Attributes["link"].Value;

        return item;
    }


}


public class ADItem
{
    private string _id;
    private string _item_url;
    private string _link;

    public string id
    {
        set { _id = value; }
        get { return _id; }
    }

    public string item_url
    {
        set { _item_url = value; }
        get { return _item_url; }
    }

    public string link
    {
        set { _link = value; }
        get { return _link; }
    }
}