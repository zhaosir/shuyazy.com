<%@ Page Language="C#" AutoEventWireup="true" CodeFile="NewsList.aspx.cs" Inherits="corp_List" %>
<%@ Register Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" TagPrefix="webdiyer" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title><%= Title %></title>
    <meta id="keywords" name="keywords" content='' runat="server" />
    <meta id="desrc" name="description" content='' runat="server" />
    <link href="css/StyleSheet.css" rel="stylesheet" type="text/css" />
    <link href="css/corp.css" rel="stylesheet" type="text/css" />
    <link href="css/StyleSheet.css" rel="stylesheet" type="text/css" />
    <link href="css/wu.css" rel="stylesheet" type="text/css" />
     <style type="text/css">
    .pirt {
	text-align: center;
	clear: both;
	line-height: 22px;
	padding-top: 10px;
}
.pirt a {
	margin-right: 5px;
	margin-left: 5px;
	color: #000000;
}
.pirt a:hover {
	text-decoration: underline;
}
.pirt .a1 {
	font-weight: bold;
	color: #CC0000;
}
    </style>
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
                <div class="banner">
                    <img src="images/Info_banner.jpg" />
                </div>
                <div class="map">
                    <span>你现在的位置：</span><a href="Index.aspx">网站首页</a><span>>></span><a href="#">最新资讯</a>
                    <div class="clear"></div>
                </div>
                <div class="c_left">
                    <a href="#">
                        <img src="images/Info_contact.jpg" />
                    </a>
                </div>
                <div class="c_right">
                    <h1 class="category"><a href="Index.aspx"></a>最新资讯</h1>
                    <div class="info_wrap"> 
                        <div class="list">
                            <ul>
                            <asp:Repeater ID="rep_newsList" runat="server">
                                <ItemTemplate>
                                    <li><span><%# Eval("postDate","{0:yyyy-MM-dd HH:mm}") %></span><a href='DocInfo.aspx?ID=<%#Eval("Id") %>'  title='<%# Eval("title") %>'><%# Eval("title") %></a></li>
                                </ItemTemplate>
                            </asp:Repeater>
                            </ul>
                        </div>
                        <div class="pirt">
                        <webdiyer:AspNetPager ID="AspNetPager1" runat="server" Width="80%" NumericButtonCount="6" UrlPaging="true"
FirstPageText="首页" LastPageText="末页" NextPageText="下页" PrevPageText="上页" Font-Names="Arial" AlwaysShow="true" ShowPageIndexBox="Always" SubmitButtonText="跳转" SubmitButtonStyle="botton" OnPageChanging="AspNetPager1_PageChanged" >
              </webdiyer:AspNetPager>
                    </div>     
                </div>
            </div>
            <div class="clear"></div>
        </div>
        </div>
         <div class="foot" align="center">
            <xx:foot ID="footer" runat="server" />
        </div>
    </form>
</body>
</html>
