<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Info.aspx.cs" Inherits="corp_Info" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
<meta id="keywords" name="keywords" content='' runat="server" />
    <meta id="desrc" name="description" content='' runat="server" />
    <title> <%= Title %></title>
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
                    <span>你现在的位置：</span><a href="Index.aspx">网站首页</a><span>>></span><a href="#">公司简介</a>
                    <div class="clear"></div>
                </div>
                <div class="c_left">
                    <a href="#">
                        <img src="images/Info_contact.jpg" />
                    </a>
                </div>
                <div class="c_right">
                    <h1 class="category"><a href="#"></a>公司简介</h1>
                    <div class="info_wrap">
                        <img src="images/Info_11.jpg" />
                        <p>漯河舒雅纸业是一家集生产、销售、研发于一体的专业商用纸品公司，公司拥有先进的生产设备和熟练的技术工人。自主加工生产面巾纸、擦手纸、大盘纸、方巾纸、卫卷及其它各种纸制品；同时公司还配套星级酒店用品。
</p>
                        <p>我公司是维达纸业商务用纸河南营销中心，批量供应维达系列生活用纸和商用纸品，是星级酒店、商务休闲会所、、行政机关及企事业单位商用纸品和团购生活用纸的专一供应商。
</p>
                        <p>多年来，我公司坚持“诚信经营、不断创新开拓的方针，依靠扎实稳步的营销思路进行发展，提高竞争力，实现销量与效益同时增长的目标。
</p>
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
