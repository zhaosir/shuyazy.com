<%@ Page Language="C#" AutoEventWireup="true" validateRequest="false"  CodeFile="ProAddAndEdit.aspx.cs" Inherits="kpagesAdmin_document_ProAddAndEdit" %>

<%@ Register Assembly="FredCK.FCKeditorV2" Namespace="FredCK.FCKeditorV2" TagPrefix="FCKeditorV2" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>无标题页</title>
    <link href="../css/common.css" rel="stylesheet" type="text/css" />

    <script src="../../js/JScript.js" type="text/javascript"></script>

</head>
<body>
    <form id="form1" runat="server">
        <div>
            <table class="admintable">
                <tr>
                    <td class="noBorder" style="width: 102px; text-align: right">
                        产品名称：
                    </td>
                    <td class="noBorder" style="width: 140px; text-align: left">
                        <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="noBorder" style="width: 102px; height: 158px; text-align: right">
                        产品描述：
                    </td>
                    <td class="noBorder" style="width: 140px; height: 158px; text-align: left">
                        
                        <fckeditorv2:fckeditor id="FCKeditor1" runat="server" Width="470px" Height="170px"  TabSpaces="1" DefaultLanguage="zh-cn"  ToolbarSet="Default" ></fckeditorv2:fckeditor>
                       
                    </td>
                </tr>
                <tr>
                    <td class="noBorder" style="width: 102px; text-align: right">
                        产品图片：
                    </td>
                    <td class="noBorder" style="width: 140px; text-align: left">
                        <asp:FileUpload ID="FileUpload1" runat="server" />
                    </td>
                </tr>
                <tr>
                <td style="text-align: right">
                        <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="新增产品" /><span
                            style="font-family: Book Antiqua">
                    </td>
                    <td>
                        <asp:Label ID="Label1" runat="server" Font-Bold="False" Font-Italic="False" Font-Size="12pt"
                            ForeColor="Red"></asp:Label>
                    </td>
                </tr>
            </table>
        </div>
    </form>
</body>
</html>
