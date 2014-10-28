<%@ Page Language="C#" AutoEventWireup="true" ValidateRequest="false" CodeFile="Message.aspx.cs" Inherits="corp_Message" %>

<%@ Register Assembly="FredCK.FCKeditorV2" Namespace="FredCK.FCKeditorV2" TagPrefix="FCKeditorV2" %>
<%@ Import Namespace="Kpages.Model" %>
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
                    <span>你现在的位置：</span><a href="Index.aspx">网站首页</a><span>>></span><a href="#">留言簿</a>
                    <div class="clear"></div>
                </div>
                <div class="c_left">
                    <a href="#">
                        <img src="images/Info_contact.jpg" />
                    </a>
                </div>
                <div class="c_right">
                
                    <h1 class="category"><a href="#"></a>留言簿</h1>
                    <div class="info_wrap">
                        <ul>
                            <li>
                                <label>
                                    *标 题：</label><input type="text" id="txt_title" size="30" runat="server" /><span>&nbsp;&nbsp;<asp:RequiredFieldValidator
                                        ID="check_title" runat="server" ErrorMessage="标题不能为空！" ControlToValidate="txt_title"
                                        ValidationGroup="s" SetFocusOnError="True"></asp:RequiredFieldValidator></span></li>
                            <li>
                                <label>
                                    *姓 名：</label><input type="text" id="txt_name" size="30" runat="server" /><span>&nbsp;&nbsp;<asp:RequiredFieldValidator
                                        ID="check_name" runat="server" ErrorMessage="姓名不能为空！" ControlToValidate="txt_name"
                                        ValidationGroup="s" SetFocusOnError="True" Display="Dynamic"></asp:RequiredFieldValidator><asp:Label ID="lab_result" runat="server" ForeColor="Red"></asp:Label></span></li>
                            <li>
                                <label>
                                    *电 话：</label><input type="text" id="txt_phone" size="30" runat="server" /><span>&nbsp;&nbsp;<asp:RequiredFieldValidator
                                        ID="check_phonenull" runat="server" ErrorMessage="电话不能为空！" ControlToValidate="txt_phone"
                                        Display="Dynamic" ValidationGroup="s" SetFocusOnError="True"></asp:RequiredFieldValidator><asp:RegularExpressionValidator
                                            ID="check_phonefor" runat="server" ErrorMessage="请输入正确的电话号码！" ControlToValidate="txt_phone"
                                            Display="Dynamic" ValidationExpression="^[-]?\d+[.]?\d*$" ValidationGroup="s"
                                            SetFocusOnError="True"></asp:RegularExpressionValidator></span></li>
                            <li>
                                <label>
                                    *Email：</label><input type="text" id="txt_email" size="30" runat="server" /><span>&nbsp;&nbsp;<asp:RegularExpressionValidator
                                        ID="check_emalifor" runat="server" ErrorMessage="请输入正确的Email！" ControlToValidate="txt_email"
                                        Display="Dynamic" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"
                                        ValidationGroup="s" SetFocusOnError="True"></asp:RegularExpressionValidator><asp:RequiredFieldValidator
                                            ID="check_emalinull" runat="server" ErrorMessage="Email不能为空！" ControlToValidate="txt_email"
                                            Display="Dynamic" ValidationGroup="s" SetFocusOnError="True"></asp:RequiredFieldValidator></span></li>
                            <li>
                                <label>
                                    *地 址：</label><input type="text" id="txt_address" size="30" runat="server" /><span></span></li>
                            <li>
                                <label>
                                    *内 容：</label><br />
                                <FCKeditorV2:FCKeditor ID="FCKeditor1" runat="server" TabSpaces="1" ToolbarSet="zzj" DefaultLanguage="zh-cn">
                                </FCKeditorV2:FCKeditor><span>
                                <asp:RequiredFieldValidator
                                    ID="RequiredFieldValidator1" runat="server" ErrorMessage="留言内容不能为空！" ControlToValidate="FCKeditor1" ValidationGroup="s" SetFocusOnError="True"></asp:RequiredFieldValidator></span></li>
                            <li>
                                <asp:Button ID="btn_submit" Text="留 言" runat="server" OnClick="btn_submit_Click" ValidationGroup="s" />
                                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp; </li>
                        </ul>
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
