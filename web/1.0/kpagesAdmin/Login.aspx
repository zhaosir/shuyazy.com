<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Login.aspx.cs" Inherits="SysAdmin_Login" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>无标题页</title>
    <style type="text/css">
        body{ background-color:#f4f6f7; font-size:14px; color:#424242; font-weight:bold; }
        .login{ margin:100px 250px;
                background-image:url(images/login_03.jpg); width:448px; height:278px;}
       .login table{ margin-left:100px; margin-top:50px;}
       .login table td{ height:35px;}
       .bn{ margin-left:70px;}
    </style>
    <script src="../js/JScript.js" type="text/javascript"></script>
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
                if(CheckNull($('tbUserName'),'info')==false)
                {
                    result++;
                   
                }
                if(CheckNull($('tbPassword'),'info')==false)
                {
                    result++;
                   
                }
                if(CheckNull($('tbRan'),'info')==false)
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

    
</head>
<body>
    <form id="form1" runat="server">
           <div class="login">
                <table>
                    <tr>
                        <td>
                            <label>用户名：</label>
                            <input id="tbUserName" type="text" onfocus="showLabelInfo('','info')" size="30" runat="server" />
                            
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <label>密&nbsp;&nbsp;&nbsp;码：</label>
                            <input id="tbPassword" type="password" onfocus="showLabelInfo('','info')"  size="30" runat="server" />
                            
                        </td>
                    </tr>
                    
                    <tr>
                        <td>
                            <label>验证码：</label>
                            <input id="tbRan" type="text" size="10" onfocus="showLabelInfo('','info')"  runat="server" />
                            <asp:Label ID="Label1" runat="server" Font-Size="Medium"  ForeColor="#0000C0" Text="8888" Width="42px"  Font-Names="幼圆"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Button ID="bnLogin" CssClass="bn" runat="server" Text="登录" OnClientClick="return pageElementDataCheck.sumit();" 
                                onclick="bnLogin_Click" /></td>
                    </tr>
                    <tr>
                        <td>
                            <label id="info" runat="server"></label>
                        </td>
                    </tr>
                </table>
           
           </div>
    </form>
</body>
</html>
