using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;

using System.IO;
using System.Web.Hosting;
using System.Net;
using System.Text;

/// <summary>
///BuildPage 的摘要说明
/// </summary>
public class BuildPage: System.Web.UI.Page
{
	public BuildPage()
	{
		//
		//TODO: 在此处添加构造函数逻辑
		//
	}

    /// <summary>
    /// 获取单个地址的流
    /// </summary>
    /// <param name="url"></param>
    /// <returns></returns>
    public string GetStream(string url)
    {
        string strResult = "";

        try
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            request.Method = "GET";
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            Stream streamReceive = response.GetResponseStream();
            Encoding encoding = Encoding.GetEncoding("GB2312");
            StreamReader streamReader = new StreamReader(streamReceive, encoding);
            strResult = streamReader.ReadToEnd();
        }
        catch { }

        return strResult;

    }

    public string GetHtmlSource(string Url, string charset)
    {
        if (charset == "" || charset == null) charset = "gb2312";
        string text1 = "";
        try
        {
            HttpWebRequest request1 = (HttpWebRequest)WebRequest.Create(Url);
            HttpWebResponse response1 = (HttpWebResponse)request1.GetResponse();
            Stream stream1 = response1.GetResponseStream();
            StreamReader reader1 = new StreamReader(stream1, Encoding.GetEncoding(charset));
            text1 = reader1.ReadToEnd();
            stream1.Close();
            response1.Close();
        }
        catch (Exception exception1)
        {
        }
        return text1;
    }


    public bool MakeFile(string content,string path, string fileName, int ID)
    {
        Encoding code = Encoding.GetEncoding("gb2312");

        //要存放生成的.html的地址

        //读取模板文件
        string temp = HttpContext.Current.Server.MapPath("text.html");
        StreamReader sr = null;
        StreamWriter sw = null;
        string str = "";

        try
        {
            sr = new StreamReader(temp, code);
            str = sr.ReadToEnd();
        }
        catch (Exception exp)
        {
            HttpContext.Current.Response.Write(exp.Message);
            HttpContext.Current.Response.End();
            sr.Close();
        }
        string htmlfilename = path + fileName + ID + ".html";
        //替换内容

        str = str.Replace("contents", content);

        //写文件
        try
        {
            sw = new StreamWriter(htmlfilename, false, code);
            sw.Write(str);
            sw.Flush();
        }
        catch (Exception ex)
        {
            HttpContext.Current.Response.Write(ex.Message);
            HttpContext.Current.Response.End();
        }
        finally
        {
            sw.Close();
        }
        return true;
    }

    public bool MakeFile(string content, string path, string fileName)
    {
        Encoding code = Encoding.GetEncoding("gb2312");


        //读取模板文件
        string temp = HttpContext.Current.Server.MapPath("text.html");
        StreamReader sr = null;
        StreamWriter sw = null;
        string str = "";

        try
        {
            sr = new StreamReader(temp, code);
            str = sr.ReadToEnd();
        }
        catch (Exception exp)
        {
            HttpContext.Current.Response.Write(exp.Message);
            HttpContext.Current.Response.End();
            sr.Close();
        }
        string htmlfilename = path + fileName + ".html";
        //替换内容

        str = str.Replace("contents", content);

        //写文件
        try
        {
            sw = new StreamWriter(htmlfilename, false, code);
            sw.Write(str);
            sw.Flush();
        }
        catch (Exception ex)
        {
            HttpContext.Current.Response.Write(ex.Message);
            HttpContext.Current.Response.End();
        }
        finally
        {
            sw.Close();
        }
        return true;
   
    }
}
