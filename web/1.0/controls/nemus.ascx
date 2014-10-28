<%@ Control Language="C#" AutoEventWireup="true" CodeFile="nemus.ascx.cs" Inherits="controls_nemus" %>
<%@ Import Namespace="System.Collections.Generic" %>
<%@ Import Namespace="Kpages.Model" %>

<ul>
<%
    
    List<Category> cates = GetCates(rootID);

    foreach (Category cate in cates)
    {
        if (cate.linkType == 0)
        {
            //指向文档 
            if (cate.type==0)
            {
                 //文档类型
                if (isParent(cate.ID) == true)
                {
                    //父级
                     if (showNextNav == 1)
                     {
                         %>
                            <li><a href="#"><%= cate.category %></a><ul>
                         <%
                         //显示子级导航
                         List<Category> nlist = GetCates(cate.ID); //子级列表

                         foreach (Category ncate in nlist)
                         {
                             int tempCount=GetDocCount(ncate.ID);
                             if (tempCount > 1)
                             {
                                 //列表页   
                                 
                                 %>
                                    <li><a href='<%= BaseUrl+"/doc/DocList.aspx?ID=" + ncate.ID %>'><%= ncate.category %></a></li>
                                 <%
                             }
                             else if (tempCount == 1)
                             {
                                 //内容页 
                                 %>
                                    <li><a href='<%= BaseUrl+"/doc/DocInfo.aspx?ID=" + ncate.ID %>'><%= ncate.category %></a></li>
                                 <%
                             }
                             else
                             {
                                 //空栏目 
                                 %>
                                    <li><a href="#"><%= ncate.category %></a></li>
                                 <%
                             }
                         } 
                         %>
                            </ul></li>
                         <%
                     }
                     else if (showNextNav == 0)
                     {
                         %>
                         
                            <li><a href='<%= BaseUrl +"/doc/DocList.aspx?ID="+ GetFirstCate(cate.ID) %>'><%= cate.category %></a></li>
                         <%
                     } 
                }
                else
                {
                     //无下级
                    if (GetDocCount(cate.ID) > 1)
                    {
                        //多文档，指向列表
                        %>
                            <li><a href='<%= BaseUrl+ "/doc/DocList.aspx?ID="+cate.ID %>'><%= cate.category%></a></li>
                        <%
                     }
                    else
                    {
                        //0或1个文档
                        int tID = GetFirstDoc(cate.ID);
                        if (tID == 0)
                        {
                            %>
                                <li><a href="#"><%= cate.category%></a></li>
                            <%
                        }
                        else
                        {
                            %>
                                <li><a href='<%= BaseUrl+ "/doc/DocInfo.aspx?ID="+tID %>'><%= cate.category%></a></li>
                            <%
                        } 
                    }


                }
                
            }
            else if (cate.type == 1)
            {
                 //产品类型
                if (isParent(cate.ID) == true)
                {
                    //父级
                     if (showNextNav == 1)
                     {
                         %>
                            <li><a href="#"><%= cate.category %></a><ul>
                         <%
                         //显示子级导航
                         List<Category> nlist = GetCates(cate.ID); //子级列表

                         foreach (Category ncate in nlist)
                         {
                             int tempCount = GetDocCount(ncate.ID);
                             if (tempCount > 1)
                             {
                                 //列表页 
                                 
                                 %>
                                    <li><a href='<%= BaseUrl+"/doc/DocList.aspx?ID=" + ncate.ID %>'><%= ncate.category %></a></li>
                                 <%
                             }
                             else if (tempCount == 1)
                             {
                                 //内容页 
                                 %>
                                    <li><a href='<%= BaseUrl+"/doc/ProInfo.aspx?ID=" + ncate.ID %>'><%= ncate.category %></a></li>
                                 <%
                             }
                             else
                             {
                                 //空栏目 
                                 %>
                                    <li><a href="#"><%= ncate.category %></a></li>
                                 <%
                             }
                         } 
                         %>
                            </ul></li>
                         <%
                     }
                     else
                     {
                         %>
                         
                            <li><a href='<%= BaseUrl +"/doc/DocList.aspx?ID="+ GetFirstCate(cate.ID) %>'><%= cate.category %></a></li>
                         <%
                     }
                }
                else
                {
                                         //无下级
                    if (GetDocCount(cate.ID) > 1)
                    {
                        //多文档，指向列表
                        %>
                            <li><a href='<%= BaseUrl+ "/doc/DocList.aspx?ID="+cate.ID %>'><%= cate.category%></a></li>
                        <%
                             }
                    else
                    {
                        int tID = GetFirstDoc(cate.ID);
                        if (tID == 0)
                        {
                            %>
                                <li><a href="#"><%= cate.category%></a></li>
                            <%
                        }
                        else
                        {
                            %>
                                <li><a href='<%= BaseUrl+ "/doc/ProInfo.aspx?ID="+ tID %>'><%= cate.category%></a></li>
                            <%
                        }
                    }

                }
                
            }
            else if (cate.type == 2)
            {
                //相册类型 
            }
        }
        else if (cate.linkType == 1)
        {
            // 指向绝对地址
            
              %>
              
                <li><a href="<%= cate.link %>"><%= cate.category %></a></li>
              
              <% 
        } 
        
    }

 %>
</ul>
