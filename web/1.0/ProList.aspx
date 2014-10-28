<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ProList.aspx.cs" Inherits="corp_ProList" %>

<%@ Register Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" TagPrefix="webdiyer" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>
        <%= Title %>
    </title>
    <meta id="keywords" name="keywords" content='' runat="server" />
    <meta id="desrc" name="description" content='' runat="server" />
    <link href="css/StyleSheet.css" rel="stylesheet" type="text/css" />
    <link href="css/corp.css" rel="stylesheet" type="text/css" />
    <link href="css/StyleSheet.css" rel="stylesheet" type="text/css" />
    <link href="css/wu.css" rel="stylesheet" type="text/css" />
    <style type="text/css">
        .pirt
        {
        	width:100%;
            text-align: center;
            clear: both;
            line-height: 22px;
            padding-top: 35px;
            margin-top:35px;
        }
        .pirt a
        {
            margin-right: 5px;
            margin-left: 5px;
            color: #000000;
        }
        .pirt a:hover
        {
            text-decoration: underline;
        }
        .pirt .a1
        {
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
                <span>你现在的位置：</span><a href="Index.aspx">网站首页</a><span>>></span><a href="#">产品展示</a>
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
                    <a href="#"></a>产品展示</h1>
                <div class="info_wrap">
                    <div class="bt" style="display: none">
                        <div class="bt_cplm" onclick="javascript:showtab_cpzs(1)">
                            产品分类1</div>
                        <div class="bt_cplm" onclick="javascript:showtab_cpzs(2)">
                            产品分类2
                        </div>
                        <div class="bt_cplm" onclick="javascript:showtab_cpzs(3)">
                            产品分类3</div>
                        <div class="bt_cplm" onclick="javascript:showtab_cpzs(4)">
                            产品分类4</div>
                    </div>
                    <div class="list">
                        <div id="cpzs1" class="block">
                            <asp:Repeater ID="rpt_proList" runat="server">
                                <ItemTemplate>
                                    <div class="cpzsKJ">
                                        <div class="cpzsPic">
                                            <a href='ProInfo.aspx?ID=<%# Eval("ID") %>'>
                                                <img border="0" src='../ProImg/s_<%# Eval("url").ToString()==""? "default.jpg":Eval("url") %>'
                                                    width="140" height="100" alt='<%# Eval("title") %>(点击查看详情)' title='<%# Eval("title") %>(点击查看详情)'></a></div>
                                        <div class="cpzsTitle">
                                            <%# Eval("title") %></div>
                                    </div>
                                </ItemTemplate>
                            </asp:Repeater>
                        </div>
                    </div>
                    <div class="pirt">
                        <webdiyer:AspNetPager ID="AspNetPager1" runat="server" Width="100%" NumericButtonCount="6"
                            UrlPaging="true" FirstPageText="首页" LastPageText="末页" NextPageText="下页" PrevPageText="上页"
                            Font-Names="Arial" AlwaysShow="true" ShowPageIndexBox="Always" SubmitButtonText="跳转"
                            SubmitButtonStyle="botton" OnPageChanging="AspNetPager1_PageChanged">
                        </webdiyer:AspNetPager>
                    </div>
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
