<%@ Page Language="C#" AutoEventWireup="true" CodeFile="CateInfo.aspx.cs" Inherits="SysAdmin_CateInfo" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>无标题页</title>
    <link href="../css/common.css" rel="stylesheet" type="text/css" />
    <script src="../../js/JScript.js" type="text/javascript"></script>
    <script type="text/javascript" language="javascript">
        var pageElementDataCheck={
            checTextBox:function(targe,errmsg){
                if(targe)
                {
                    var temp=$(errmsg);
                    if(temp)
                    {
                        if(targe.value.trim()=="")
                        {
                            temp.innerHTML="不能为空！";
                        }
                        else
                        {
                            temp.innerHTML="";
                        }
                    }
                }
            },
            clearMsg:function(id){
                var temp=$(id);
                if(temp)
                {
                    temp.innerHTML="";
                }
            },
            sumit:function(){
                var result=0;
                if(CheckNull($('tbCate'),'cateInfo')==false)
                {
                    result++;
                   
                }
                if($("ddlLinkType").selectedIndex!=0)
                {
                    if(CheckURL($('tbLink'),'tbLinkInfo')==false)
                    {
                        result++;
                    }
                }
                if(result>0)
                {
                    return false;
                }
            }
       }
    </script>
</head>
<body>
    <form id="form1" class="wrap" runat="server">

        <div id="man_zone">
             <h2>栏目管理</h2>
            <table class="admintable">
                <tr>
                    <td><label>栏目名称</label>
                    <input id="tbCate" runat="server" type="text" size="28" />
                    <label id="cateInfo" class="errorMsg">*</label></td>
                </tr>
                <tr>
                    <td>
                        <label>栏目类型</label>
                        <asp:DropDownList ID="ddlType" runat="server">
                            <asp:ListItem Value="0" Text="文本文档"></asp:ListItem>
                            <asp:ListItem Value="1" Text="产品文档"></asp:ListItem>
                            <asp:ListItem Value="2" Text="相册文档"></asp:ListItem>
                        </asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td>
                        <label>链接类型</label>
                        <asp:DropDownList ID="ddlLinkType" runat="server">
                            <asp:ListItem Value="0" Text="转到第一条信息"></asp:ListItem>
                            <asp:ListItem Value="1" Text="转到链接地址"></asp:ListItem>
                        </asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td>
                        <label>链接地址</label>
                        <input type="text" id="tbLink" size="52" runat="server" />
                        <label id="tbLinkInfo" class="errorMsg"></label>
                    </td>
                </tr>
                <tr>
                    <td>
                        
                        <asp:Button ID="bnAdd" CssClass="bn" runat="server" Text="增加" OnClientClick="return pageElementDataCheck.sumit();" onclick="bnAdd_Click" />
                        <asp:Button ID="bnUpdate"  CssClass="bn"  runat="server" Text="修改" OnClientClick="return pageElementDataCheck.sumit();" onclick="bnUpdate_Click" />
                        <a href="Category.aspx" class="bn">返回栏目管理</a>
                        <label id="successInfo" runat="server" class="errorMsg"></label>
                    </td>
                </tr>
            </table>

        </div>

    </form>
</body>
</html>
