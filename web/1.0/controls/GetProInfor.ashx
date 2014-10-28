<%@ WebHandler Language="C#" Class="GetProInfor" %>

using System;
using System.Web;
using System.Data.SqlClient;
using System.Data;

public class GetProInfor : IHttpHandler {
    
    public void ProcessRequest (HttpContext context) {
        context.Response.ContentType = "text/plain";
        string proid = context.Request.Params["proid"];
        string dir = context.Request.Params["dir"];
        Bll_Model bll_model = new Bll_Model();
        int index = 0;
        DataTable dt= bll_model.GetAllPro(proid, out index);
        System.Text.StringBuilder bs = new System.Text.StringBuilder();
        for (int i = 0; i < dt.Rows.Count; i++)
        {
            bs.Append("{title:'");
            bs.Append(dt.Rows[i]["title"].ToString()+"',");
            bs.Append("img:'");
            bs.Append(dt.Rows[i]["url"].ToString()+"',");
            bs.Append("desc:'");
            bs.Append(dt.Rows[i]["contents"].ToString()+"'},");
            if (dt.Rows[i]["ID"].ToString() == proid)
            {
                if (dir == "1")//向前
                {
                    index = i + 1;
                }
                else if (dir == "0")//向后
                {
                    index = i - 1; 
                }
                index = i;
            } 
            
        }
        context.Response.Write("["+bs.ToString()+index.ToString()+"]");
    }
 
    public bool IsReusable {
        get {
            return false;
        }
    }

}