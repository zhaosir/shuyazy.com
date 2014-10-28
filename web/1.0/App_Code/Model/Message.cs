using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

/// <summary>
/// message 的摘要说明
/// </summary>
public class Message
{
    public Message()
	{
		//
		// TODO: 在此处添加构造函数逻辑
		//
	}

    private Guid _id;
    private string _title;
    private string _name;
    private string _age;
    private string _sex;
    private string _address;
    private string _phone;
    private string _ipaddress;
    private string _email;
    private string _content;
    public Guid Id
    {
        get
        {
            return _id;
        }
        set
        {
            this._id = value;
        }
    }
    public string Title
    {
        get
        {
            return this._title;
        }
        set
        {
            this._title = value;
        }
    }
    public string Name
    {
        get
        {
            return _name;
        }
        set
        {
            this._name = value;
        }
    }
    public string Age
    {
        get
        {
            return _age;
        }
        set
        {
            this._age = value;
        }
    }
    public string Sex
    {
        get
        {
            return _sex;
        }
        set
        {
            this._sex = value;
        }
    }
    public string Address
    {
        get
        {
            return _address;
        }
        set
        {
            this._address = value;
        }
    }
    public string Phone
    {
        get
        {
            return this._phone;
        }
        set
        {
            this._phone = value;
        }
    }
    public string IpAddress
    {
        get
        {
            return _ipaddress;
        }
        set
        {
            this._ipaddress = value;
        }
    }
    public string Email
    {
        get
        {
            return _email;
        }
        set
        {
            this._email = value;
        }
    }
    public string Content
    {
        get
        {
            return this._content;
        }
        set
        {
            this._content = value;
        }
    }
}
