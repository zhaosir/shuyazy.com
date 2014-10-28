<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Profile.aspx.cs" Inherits="kpagesAdmin_site_Profile" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>无标题页</title>
    <link href="../css/common.css" rel="stylesheet" type="text/css" />
    <script src="../../js/JScript.js" type="text/javascript"></script>
</head>
<body>
    <form id="form1" runat="server" >
        <div id="man_zone">
            <h2>网站联系信息配置</h2>
            <table class="admintable">
                <tr>
                    <td>
                        <label>网站标题</label>
                        <input id="tbTitle" type="text" size="52" runat="server" />
                        <label id="titleInfo" class="errorMsg">*</label>
                    </td>
                </tr>
                
                <tr>
                    <td>
                        <label>前台网址</label>
                        <input id="tbSite" type="text" size="32" runat="server" />
                        <label id="siteInfo" class="errorMsg">*</label>
                    </td>
                </tr>
                <tr>
                    <td>
                        <label>联系电话</label>
                        <input id="tbTel" type="text" runat="server" />
                        <label id="telInfo" class="errorMsg">*</label>
                    </td>
                </tr>
                
                <tr>
                    <td>
                        <label>联系邮箱</label>
                        <input id="tbMail" type="text" size="42" runat="server" />
                        <label id="mailInfo" class="errorMsg">*</label>
                    </td>
                </tr>
                
                <tr>
                    <td>
                        <label>联系QQ</label>
                        <input id="tbQQ" type="text" runat="server" />
                        <label id="qqInfo" class="errorMsg">*</label>
                    </td>
                </tr>
                <tr>
                    <td>
                        <label>版权信息</label>
                        <textarea id="tbCopyRigth" runat="server" rows="5" cols="80"></textarea> 
                    </td>
                </tr>
                
                <tr>
                    <td class="noBorder">
                        <input type="submit" class="bn" onserverclick="setInfo" onclick="return pageElementDataCheck.sumit();" value="确定" runat="server" />
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
                if(CheckNull($('tbTitle'),'titleInfo')==false)
                {
                    result++;
                   
                }
                if(CheckURL($('tbSite'),'siteInfo')==false)
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
