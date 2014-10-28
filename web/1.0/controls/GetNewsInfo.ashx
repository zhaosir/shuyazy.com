<%@ WebHandler Language="C#" Class="GetNewsInfo" %>

using System;
using System.Web;
using Kpages.Model;
public class GetNewsInfo : IHttpHandler {
    
    public void ProcessRequest (HttpContext context) {
        context.Response.ContentType = "text/plain";
        string newsid = context.Request.Params["newsid"];
        System.Text.StringBuilder bs = new System.Text.StringBuilder();
        if (newsid != null)
        {
            Kpages.DAL.DocumentDal docDal = new Kpages.DAL.DocumentDal();
            Document doc = docDal.GetModel(Int32.Parse(newsid));
            bs.Append(doc.contents);
        }
        context.Response.Write(bs.ToString());
    }
 
    public bool IsReusable {
        get {
            return false;
        }
    }

}