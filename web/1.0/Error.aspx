<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Error.aspx.cs" Inherits="corp_NewsList" %>


<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title> <%= Title %></title>
    <meta id="keywords" name="keywords" content='' runat="server" />
    <meta id="desrc" name="description" content='' runat="server" />
    <link href="css/StyleSheet.css" rel="stylesheet" type="text/css" />
    <link href="css/corp.css" rel="stylesheet" type="text/css" />
    <link href="css/wu.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" class="wrap" runat="server">
        <div class="content">
            <div class="top">
                <a href="#" class="logo"><img src="images/logo1.png" /></a>
                <div class="nav">
                    <div class="tools"></div>
                    <Kpages:nav ID="nav" runat="server" />
                </div>
                <div class="clear"></div>
            </div>
            
            <div class="c_wrap">
                <div class="banner">
                    <img src="images/Info_banner.jpg" />
                </div>
                <div class="map">
                    
                </div>
                <div class="c_left">
                    <a href="#">
                        <img src="images/Info_contact.jpg" />
                    </a>
                </div>
                <div class="c_right">
                    <h1 class="category"><a href="#"></a>网站异常</h1>
                    <div class="info_wrap" style="text-align: center">
                        <br />
                        <strong><span style="color: #ff0000">网站出现异常！</span></strong>
                        <br /><br /><br />
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
