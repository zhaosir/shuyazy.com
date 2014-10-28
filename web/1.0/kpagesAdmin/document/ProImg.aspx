<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ProImg.aspx.cs" Inherits="kpagesAdmin_document_ProImg" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>无标题页</title>
    <link href="../css/common.css" rel="stylesheet" type="text/css" />
    <script src="../../js/JScript.js" type="text/javascript"></script>
</head>
<body>
    <form id="form1" runat="server">
    <div  id="man_zone">
    <h2>产品图片管理</h2>
    <asp:DataList ID="dl" CssClass="admintable" CellSpacing="10" runat="server" RepeatColumns="5" 
                RepeatDirection="Horizontal">
                <ItemTemplate>
                    <img src="<%# "../../"+ Eval("url") %>" width="120" alt='<%# Eval("title") %>' /><br />
                    <asp:Button ID="bnUpdate" runat="server" CommandArgument='<%# Eval("ID") %>' 
                        Text="修改" oncommand="bnUpdate_Command" />
                    <asp:Button ID="bnDelete" runat="server" CommandArgument='<%# Eval("ID") %>' 
                        Text="删除" oncommand="bnDelete_Command" />
                    
                </ItemTemplate>
            </asp:DataList>
            
            <table class="admintable">
               <tr>
                    <td>
                        <label>文件类型</label>
                        <asp:DropDownList ID="ddlType" runat="server">
                            <asp:ListItem Value="0">图片类型</asp:ListItem>
                            <asp:ListItem Value="1">下载类型</asp:ListItem>
                        </asp:DropDownList>
                    </td>
               </tr>
                 <tr>
                    <td>
                        <label>文件标题</label>
                        <input id="tbTitle" type="text" size="72" runat="server" />
                        <label id="tbTitleInfo" class="errorMsg" runat="server">*</label>
                    </td>
                </tr>  
                 <tr>
                    <td>
                        <label>文件地址</label>
                        <input id="tbUrl" type="text" size="32" runat="server" />
                        <asp:FileUpload ID="FileUpload1" runat="server" />
                        <input id="Submit1" type="submit" runat="server" value="上传" onserverclick="upimage" />
                        <label id="tbUrlInfo" class="errorMsg" runat="server">*</label>
                    </td>
                </tr>
                <tr>
                    <td class="noBorder">
                        <input id="bnAdd" type="submit" class="bn" onserverclick="Add" onclick="return pageElementDataCheck.sumit();" value="添加" runat="server" />
                        <input id="bnUpdate" type="submit" class="bn" onserverclick="Update" onclick="return pageElementDataCheck.sumit();" value="编辑" runat="server" />
                        <label id="successInfo" runat="server" class="errorMsg"></label>
                    </td>
                </tr>
            </table>
    </div>
    </form>
</body>

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
                
                if(CheckNull($('tbTitle'),'tbTitleInfo')==false)
                {
                    result++;
                   
                }
                if(CheckNull($('tbUrl'),'tbUrlInfo')==false)
                {
                    result++;
                   
                }
                if(result>0)
                {
                    return false;
                }
            }
       }
    </script>
</html>
