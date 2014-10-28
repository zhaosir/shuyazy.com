<%@ Page Language="C#" AutoEventWireup="true" CodeFile="UserInfo.aspx.cs" Inherits="kpagesAdmin_user_UserInfo" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>无标题页</title>
    <link href="../css/common.css" rel="stylesheet" type="text/css" />
    <script src="../../js/JScript.js" type="text/javascript"></script>
</head>
<body>
    <form id="form1" runat="server">
        <div id="man_zone">
            <h2>编辑个人信息</h2>
            
            <table class="admintable">
                <tr>
                    <td>
                        <label>用户性别</label>
                        <asp:RadioButtonList ID="rblSex" RepeatDirection="Horizontal" runat="server">
                            <asp:ListItem Value="0" Text="男" Selected="True"></asp:ListItem>
                            <asp:ListItem Value="1" Text="女"></asp:ListItem>
                        </asp:RadioButtonList>
                        
                    </td>
                    
                </tr>
                <tr>
                    <td>

                        <label>用户生日</label>
                        <input type="text" id="tbBirthday" runat="server" />
                        <label id="tbBirthdayInfo" class="errorMsg">*</label>
                    </td>
                </tr>
                <tr>
                    <td>
                        <label>用户密码</label>
                        <input type="password" id="tbPassword" runat="server" />
                        <label id="passwordInfo" class="errorMsg">*</label>
                        

                        
                    </td>
                </tr>
                
                <tr>
                    <td>
                        <label>确定密码</label>
                        <input type="password" id="tbPwd" runat="server" />
                        <label id="pwdInfo" class="errorMsg">*</label>
                        
                    
                    </td>
                </tr>
                
                <tr>
                    <td>
                        <label>用户邮箱</label>
                        <input type="text" id="tbMail" size="32" runat="server" />
                        <label id="mailInfo" class="errorMsg">*</label>
                        

                        
                    </td>
                </tr>
                <tr>
                    <td>
                        <label>用户电话</label>
                        <input type="text" id="tbTel" runat="server" />
                        <label id="tbTelInfo" class="errorMsg">*</label>
                    
                    </td>
                </tr>
                
                <tr>
                    <td class="noBorder">
                        <input type="submit" class="bn" id="bnAdd" runat="server"  onserverclick="UpdateUser" value="编辑用户信息"  onclick="return pageElementDataCheck.sumit();"/>
                        <a href="Default.aspx" class="bn">返回用户管理</a>
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
                if(CheckNull($('tbPassword'),'passwordInfo')==false)
                {
                    result++;
                   
                }
                if($('tbPassword').value!=$('tbPwd').value)
                {
                    pwdInfo.innerHTML="两次密码不一样！";
                    result++;
                   
                }
                if(CheckMail($('tbMail'),'mailInfo')==false)
                {
                    result++;
                }
               
                if(CheckData($('tbBirthday'),'tbBirthdayInfo')==false)
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
