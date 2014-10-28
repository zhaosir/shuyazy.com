<%@ Control Language="C#" AutoEventWireup="true" CodeFile="Cates.ascx.cs" Inherits="controls_Cates" %>
<%@ Import Namespace="System.Collections.Generic" %>
<%@ Import Namespace="Kpages.Model" %>

    <ul>
        <%
            List<Category> list = GetCates(upID);
            foreach (Category item in list)
            {
               %>
                   <li><a href="?cateID=<%= item.ID %>"><%= item.category%></a></li>
               <% 
            }
             %>
    </ul>