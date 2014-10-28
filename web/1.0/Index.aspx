<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Index.aspx.cs" Inherits="corp_Index" %>
<%@ Register Src="~/controls/footer.ascx" TagName="foot" TagPrefix="xx" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
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
        /*
        转向指定的url
        */
        function Transmit(url)
        {
            window.location.href=url;
        }
    </script>

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
                <div class="c_left">
                    <div class="contact">
                        <h3>
                            联系地址</h3>
                        <p>
                            漯河黄河路中段劳动局西邻</p>
                        <h3>
                            咨讯热线</h3>
                        <p>
                            086-395-3188078</p>
                        <h3>
                            24小时热线</h3>
                        <p>
                            13849499216</p>
                        <h3>
                            在线客服</h3>
                        <p>
                            1457355625</p>
                    </div>
                    <a href="#" class="box">
                        <img src="images/contact.jpg" /></a>
                </div>
                <div class="c_right">
                    <div>
                        <iframe name="content_frame" marginheight="0" marginwidth="0" width="645" height="240"
                            src="../ad/Index.html" frameborder="0" style="overflow: hidden"></iframe>
                    </div>
                    <div class="l_box floatL news">
                        <h2>
                            <a onclick="Transmit('NewsList.aspx')" style="cursor: pointer" title="更多">更多>></a>最新资讯</h2>
                        <Kpages:docs runat="server" cateID="6" showTime="0" num="4"  />
                    </div>
                    <div class="floatL">
                        <img src="images/line.jpg" /></div>
                    <div class="l_box floatL pics">
                        <h2>
                            <a onclick="Transmit('ProList.aspx')" style="cursor: pointer" title="更多">更多>></a>产品推荐</h2>
                        <div class="imglist">
                            <asp:Repeater ID="rep_hotpro" runat="server">
                                <ItemTemplate>
                                    <div class="sycpzsKJ">
                                        <div class="sycpzsPic">
                                        <a href='ProInfo.aspx?ID=<%# Eval("ID") %>'><img border="0" style="width:96px; height:70px"  src='../ProImg/s_<%# Eval("url") %>' title='<%# Eval("title") %>(点击查看详情)' alt='<%# Eval("title") %>' /></a>
                                        </div>
                                        <div class="sycpzsTitle">
                                            <%# Eval("title") %>
                                        </div>
                                    </div>
                                </ItemTemplate>
                            </asp:Repeater>
                        </div>
                    </div>
                    <div class="clear">
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
