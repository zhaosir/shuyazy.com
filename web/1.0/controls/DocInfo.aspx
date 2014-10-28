<%@ Page Language="C#" AutoEventWireup="true" CodeFile="DocInfo.aspx.cs" Inherits="corp_DocInfo" %>

<%@ Import Namespace="Kpages.Model" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>
        <%= Title %>
    </title>
    <meta id="keywords" name="keywords" content='' runat="server" />
    <meta id="desrc" name="description" content='' runat="server" />
    <link href="../css/StyleSheet.css" rel="stylesheet" type="text/css" />
    <link href="css/corp.css" rel="stylesheet" type="text/css" />
    <link href="../corp/css/wu.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" class="wrap" runat="server">
        <div class="content">
            <div class="top">
                <a href="#" class="logo">
                    <img src="images/logo1.png" /></a>
                <div class="nav">
                    <div class="tools">
                    </div>
                    <Kpages:nav ID="nav" runat="server" />
                </div>
                <div class="clear">
                </div>
            </div>
            <div class="c_wrap">
                <% Document doc = GetDoc(ID); %>
                <div class="banner">
                    <img src="images/Info_banner.jpg" />
                </div>
                <div class="map">
                    <span>你现在的位置：</span><a href="Index.aspx">网站首页</a><span>>></span><a href="#"><%= GetModel(doc.cateID).category %></a>
                    <div class="clear">
                    </div>
                </div>
                <div class="c_left">
                    <a href="#">
                        <img src="images/Info_contact.jpg" />
                    </a>
                </div>
                <div class="c_right">
                    <h1 class="category">
                        <a id="a_back" runat="server" href="NewsList.aspx">返回</a><%= GetModel(doc.cateID).category %></h1>
                    <div class="info_wrap">
                        <img src="images/Info_11.jpg" />
                        <h3>
                            <%= doc.title %>
                        </h3>
                        <%= doc.contents %>
                    </div>
                </div>
                <div class="clear">
                </div>
            </div>
        </div>
         <div class="foot" align="center">
            <xx:foot ID="footer" runat="server" />
        </div>
    </form>
</body>
</html>
