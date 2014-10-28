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
/// 网站配置基础类
/// </summary>
public class ConfigBase: MasterBase
{
    public ConfigBase()
    {
        helper = new IOHelperXml(Server.MapPath("~/App_Data/SiteConfig.xml"));
    }

    private string _title;
    private string _keywords;
    private string _description;
    private string _webSite;
    private string _tel;
    private string _mail;
    private string _qq;
    private string _coryRight;

    private IOHelperXml helper;

    /// <summary>
    /// 配置网站基础信息
    /// </summary>
    /// <param name="title">标题</param>
    /// <param name="webSite">网址</param>
    /// <param name="copyRigth">版权信息</param>
    public void setBaseInfo(string title,string webSite, string copyRigth)
    {
        set("title", title);
        set("webSite", webSite);
        set("copyRight", copyRigth);
        helper.Save();

    }

    /// <summary>
    /// 设置节点值
    /// </summary>
    /// <param name="name"></param>
    /// <param name="value"></param>
    private void set(string name, string value)
    {
        XmlNode node = helper.SelectNode("/site/"+name);
        node.InnerXml = value;
       
    }

    /// <summary>
    /// 获取节点值
    /// </summary>
    /// <param name="name"></param>
    /// <returns></returns>
    public string get(string name)
    {
        XmlNode node = helper.SelectNode("/site/" + name);
        return node.InnerXml;
    }

    /// <summary>
    /// 配置联系信息
    /// </summary>
    /// <param name="tel">电话</param>
    /// <param name="mail">邮箱</param>
    /// <param name="qq">QQ</param>
    public void setContactInfo(string tel, string mail, string qq)
    {
        set("tel", tel);
        set("mail", mail);
        set("qq", qq);
        helper.Save();
    }

    /// <summary>
    /// 配置首页优化信息
    /// </summary>
    /// <param name="keywords">关键字</param>
    /// <param name="description">描述</param>
    public void setSEO(string keywords, string description)
    {
        set("keywords", keywords);
        set("description", description);
        helper.Save();
    }

}
