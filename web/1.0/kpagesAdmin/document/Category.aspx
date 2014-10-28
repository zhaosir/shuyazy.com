<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Category.aspx.cs" Inherits="kpagesAdmin_document_Category" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>漯河市郾城区舒雅纸业</title>
    <link href="../css/common.css" rel="stylesheet" type="text/css" />
    <script src="../../js/JScript.js" type="text/javascript"></script>
</head>
<body>
    <form id="form1" runat="server">
        <div id="man_zone">
            <h2>分类管理</h2>
            <%--<table class="admintable">
                <tr>
                    <td class="noBorder"> 
                        <a href="CateInfo.aspx?act=add" class="bn">添加顶级栏目</a>
                    </td>
                </tr>
            </table>--%>
            <asp:TreeView ID="tvCate" runat="server" 
                onselectednodechanged="TreeView1_SelectedNodeChanged">
            </asp:TreeView>
            <div class='treeItem'><a href="MessageManage.aspx">公司简介</a></div>
            <div class='treeItem'><a href="News.aspx">最新资讯</a></div>
            <div class='treeItem'><a href="MessageManage.aspx">留言管理</a></div>
            <div class='treeItem'><a href="ProManage.aspx">产品管理</a></div>
            <label id="successInfo" runat="server" class="errorMsg"></label>
        </div>
    </form>
</body>
</html>
