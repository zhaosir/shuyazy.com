<%@ Page Language="C#" AutoEventWireup="true" CodeFile="NewsInfo.aspx.cs" Inherits="kpagesAdmin_NewsInfo" %>

<%@ Register Assembly="FredCK.FCKeditorV2" Namespace="FredCK.FCKeditorV2" TagPrefix="FCKeditorV2" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <link href="../css/common.css" rel="stylesheet" type="text/css" />
    <style>


</style>
    <title>最新咨询</title>
</head>
<body>
    <form id="form1" runat="server">
        <div style="text-align: center">
            <table class="admintable">
                <tr>
                    <td class="noBorder" colspan="2" style="text-align: center; height: 20px; width: 988px;">
                        <strong>
                            <asp:Label ID="lab_title" runat="server">最新咨询添加</asp:Label></strong><span style="font-size: 16pt"></td>
                </tr>
                <tr>
                    <td class="noBorder" style="width: 37px; text-align: right; height: 17px;">
                        标题：</td>
                    <td class="noBorder" style="text-align: left; height: 17px;">
                        <asp:TextBox ID="txt_title" runat="server"></asp:TextBox><label id="title_error" style="color:Red">请输入标题</label>
                    </td>
                </tr>
                <tr>
                    <td class="noBorder" style="text-align: right; width: 37px;">
                        内容：
                    </td>
                    <td class="noBorder" style="text-align: left">
                        <FCKeditorV2:FCKeditor ID="FCKeditor1" runat="server" Width="790px" Height="430px"
                            TabSpaces="1" DefaultLanguage="zh-cn" ToolbarSet="Default">
                        </FCKeditorV2:FCKeditor>
                        <label id="content_error" style="color:Red">请输入标题</label>
                    </td>
                </tr>
                <tr>
                    <td class="noBorder" style="text-align: right; width: 37px;">
                        &nbsp;</td>
                    <td class="noBorder" style="text-align: left">
                        <asp:Button ID="btn_submit" runat="server" Text="添加" OnClick="btn_submit_Click" />
                        <input type="button" value="取消" />
                    </td>
                </tr>
            </table>
        </div>
    </form>
</body>
</html>
