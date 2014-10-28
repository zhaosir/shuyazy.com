<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ProInfo.aspx.cs" Inherits="corp_ProList" %>

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
    <script type="text/javascript">
    var imgs=['cp2.jpg','InfoList_03-02.jpg','picdemo.jpg','InfoList_03.jpg','cp2.jpg'];
    var index=imgs.length;
    index=1;
    function next()
    {
        if(index>=imgs.length-1)
        {
            alert("后面没有了");
            return;
        }
        index++;
        var imgpath="images/"+imgs[index];
        //alert(imgpath);
        document.getElementById("pro_img").setAttribute("src",imgpath)
    }
    function before()
    {
        if(index==0)
        {
            alert("前面没有了！");
            return;
        }
        index--;
        var imgpath="images/"+imgs[index];
        document.getElementById("pro_img").setAttribute("src",imgpath)
    }
    
    function page_load()
    {
        var pro_img=document.getElementById("pro_img");
        pro_img.onload=function(){
            //pro_img.setAttribute("src","images/loading.gif");
        
        };
        pro_img.onreadystatechange = function(){
            if ( this.readyState == "complete")
            {
                //alert("加载完毕");
            }
            else
            {
                //pro_img.setAttribute("src","images/loading.gif");
            }
        
        }

    }
    </script>
</head>
<body onload="page_load()">
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
                        <div class="cpxq">
                            <div class="cpName" id="cpName">
                                <asp:Literal ID="li_proName" runat="server"></asp:Literal></div>
                            <div class="cpPick">
                                <div class="updown">
                                    <img src="images/shang.jpg" style="width: 16px; height: 62px" onclick="getNextProInfo('0')" title="上一个" alt="上一个" ></div>
                                <div class="cpPic" style="text-align: center" align=center>
                                    <img id="pro_img"  src="images/loading.gif" width="400" height="300" runat="server"></div>
                                <div class="updown" style="margin-left: 40px;">
                                    <img src="images/xia.jpg" onclick="getNextProInfo('1')" title="下一个" alt="下一个" style="width: 16px; height: 62px"></div>
                            </div>
                            <div class="cpContent">
                                <span id="des_ProDes" runat="server">
                                </span>
                            </div>
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
        <script type="text/javascript" src="js/GetProInfo.js"></script>
    </form>
</body>
</html>
