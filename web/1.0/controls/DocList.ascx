<%@ Control Language="C#" AutoEventWireup="true" CodeFile="DocList.ascx.cs" Inherits="controls_DocList" %>
<%@ Import Namespace="Kpages.Model" %>
<%@ Import Namespace="System.Data" %>

    <%
        if (type == 0)
        {
            //文档格式 
               %>
                <ul>
                <%
            if (showTime == 0)
            {
                //带时间的输出
                foreach (Document doc in list)
                {
                     %>
                          <li><span><%= doc.postDate.ToShortDateString() %></span><a href='<%= BaseUrl +"/DocInfo.aspx?ID="+doc.ID %>'  title='<%= doc.title %>'><%= doc.title.Length > 16 ? doc.title.Substring(0,15)+"..." : doc.title%></a></li>
                     <%
                }
                 
            }
            else if (showTime == 1)
            {
                //不带时间输出 
                foreach (Document doc in list)
                {
                     %>
                          <li><a href='<%= BaseUrl +"/DocInfo.aspx?ID="+doc.ID %>' title='<%= doc.title %>'><%= doc.title %></a></li>
                     <%
                }
            }
            
            %>
                </ul>
            <%     
        }
        else if (type == 1)
        {
            //产品列表
            if (showPic == 0)
            {
                 //显示图片
                     %>
                    <ul>
                    <%
                        foreach (DataRow dr in GetPros().Rows)
                        { 
                            %>
                                <li><a href='<%= BaseUrl +"/ProInfo.aspx?ID="+dr["ID"] %>' title='<%= dr["title"] %>'><img src='<%= ImgbaseUrl +"/"+dr["url"] %>' title='<%= dr["title"] %>'><br/><%= dr["title"] %></a></li>
               
                            <%
                        }
                
                        %>
                            </ul>
                        <% 
                
            }
            else if (showPic == 1)
            {
                     %>
                    <ul>
                    <%
                        foreach (Document doc in list)
                        { 
                            %>
                                <li><a href='<%= BaseUrl +"/ProInfo.aspx?ID="+doc.ID%>' title='<%= doc.title %>'><%=  doc.title%></a></li>
               
                            <%
                        }
                
                        %>
                            </ul>
                        <% 
            }

        }
        else if (showPic == 2 && list.Count>0)
        {
            
            Document doc = list[0];
             %>
             <p><img alt="畅优视觉" src="images/Index_19.jpg" complete="complete"/><%= doc.descr %></p>
             <ul>
             <%
            
                 for (int i = 1; i < list.Count; i++)
                 {
                     %>
                     <li><a href='<%= BaseUrl+"/DocInfo.aspx?ID="+list[i].ID %>'><%= list[i].title %></a></li>
                     <% 
                 }
            %>
                </ul>
            <%
        }
            
    %>
</ul>