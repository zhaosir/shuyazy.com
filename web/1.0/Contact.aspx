<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Contact.aspx.cs" Inherits="corp_List" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head2" runat="server">
    <title>
        <%= Title %>
    </title>
    <meta id="keywords" name="keywords" content='' runat="server" />
    <meta id="desrc" name="description" content='' runat="server" />
    <link href="css/StyleSheet.css" rel="stylesheet" type="text/css" />
    <link href="css/corp.css" rel="stylesheet" type="text/css" />
    <link href="css/wu.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form2" class="wrap" runat="server">
        <div class="content">
            <div class="top">
                <a href="#" class="logo">
                    <img src="images/logo1.png" /></a>
                <div class="nav">
                    <div class="tools">
                    </div>
                    <Kpages:nav ID="nav1" runat="server" />
                </div>
                <div class="clear">
                </div>
            </div>
            <div class="c_wrap">
                <div class="banner">
                    <img src="images/Info_banner.jpg" />
                </div>
                <div class="map">
                    <span>你现在的位置：</span><a href="Index.aspx">网站首页</a><span>>></span><a href="#">联系我们</a>
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
                        <a href="#"></a>联系我们</h1>
                    <div class="info_wrap">
                        <ul>
                            <li>
                                <label>
                                    </label>
                                <strong><span style="font-size: 12pt">漯河市郾城区舒雅纸业</span></strong>
                            </li>
                                    <li>
                                <label>
                                    手 机：</label><span>13849499216</span></li>
                            <li>
                                <label>
                                    电 话：</label><span>0395-3188078</span></li>
                            <li>
                                <label>
                                    Email：</label><span>shuya@shuyazy.com</span></li>
                                    <li>
                                <label>
                                    Q  Q：</label><span>1457355625</span></li>
                            <li>
                                <label>
                                    地 址：</label><span>漯河市黄河路中段劳动局西邻</span></li>
                        </ul>
                        <div class="clear">
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
