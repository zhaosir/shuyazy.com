<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="kpagesAdmin_user_Default" %>

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
            <h2>网站管理员</h2>
            <asp:GridView ID="gv" runat="server" CssClass="admintable" 
                AutoGenerateColumns="False">
                <Columns>
                    <asp:TemplateField HeaderText="选择">
                        <EditItemTemplate>
                            <asp:CheckBox ID="CheckBox1" runat="server" />
                        </EditItemTemplate>
                        <ItemTemplate>
                            <asp:CheckBox ID="CheckBox1" runat="server"  />
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:BoundField DataField="ID" HeaderText="编号" />
                    <asp:BoundField DataField="userName" HeaderText="用户" />
                    <asp:TemplateField HeaderText="权根">
                        <EditItemTemplate>
                            <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("type") %>'></asp:TextBox>
                        </EditItemTemplate>
                        <ItemTemplate>
                            <asp:Label ID="Label1" runat="server" Text='<%# Convert.ToInt32(Eval("type").ToString())>0?"管理员":"普通用户" %>' ></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    
                    <asp:TemplateField HeaderText="性别">
                        <EditItemTemplate>
                            <asp:TextBox ID="TextBox2" runat="server" Text='<%# Bind("sex") %>'></asp:TextBox>
                        </EditItemTemplate>
                        <ItemTemplate>
                            <asp:Label ID="Label2" runat="server" Text='<%# Convert.ToInt32(Eval("sex").ToString())>0?"女":"男" %>' ></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:BoundField DataField="tel" HeaderText="电话" />
                    <asp:BoundField DataField="birthday" HeaderText="生日" />
                    <asp:BoundField DataField="mail" HeaderText="邮箱" />
                </Columns>
            </asp:GridView>
            
            <table class="admintable">
                <tr>
                    <td>
                        <input id="Submit2" class="bn" type="submit" value="删除所选" onserverclick="Delete" runat="server"/>
                        <input class="bn" onclick="selectOthers()" type="button" value="反向选择" />
                        <input class="bn" onclick="selectAll()" type="button" value="全选" />
                    </td>
                </tr>
            </table>
            
            <table class="admintable">
                <tr>
                    <td>
                        <label>用户名称</label>
                        <input type="text" id="tbUserName" runat="server" />
                        <label id="userNameInfo" class="errorMsg">*</label>
                        
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
                        
                        <label>用户电话</label>
                        <input type="text" id="tbTel" runat="server" />
                        <label id="tbTelInfo" class="errorMsg">*</label>
                        
                    </td>
                </tr>
                
                
                <tr>
                    <td class="noBorder">
                        <input type="submit" class="bn" id="bnAdd" runat="server"  onserverclick="AddUser" value="添加用户"  onclick="return pageElementDataCheck.sumit();"/>
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
                if(CheckNull($('tbUserName'),'userNameInfo')==false)
                {
                    result++;
                   
                }
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


       var area = $("gv");
       var list;

       if (area) {
           list = area.getElementsByTagName("input");

       }
       
       
       function selectAll()
       {
            for(var i=0;i<list.length;i++)
            {
                list[i].checked = true;
            }
       }
       
       function selectOthers()
       {
            for(var i=0;i<list.length;i++)
            {
                if(list[i].checked == true)
                {
                    list[i].checked = false;
                }else{
                    list[i].checked = true;
                }
            }
       }
       
       function add()
       {
            $("tbTitle").value ="";
            $("tbSite").value ="";
            $("successInfo").innerHTML="";

       }
       

    </script>
</html>
