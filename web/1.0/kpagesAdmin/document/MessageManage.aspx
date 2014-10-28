<%@ Page Language="C#" AutoEventWireup="true" CodeFile="MessageManage.aspx.cs" Inherits="kpagesAdmin_document_MessageManage" %>

<%@ Register Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" TagPrefix="webdiyer" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>留言管理</title>
    <link href="../css/common.css" rel="stylesheet" type="text/css" />
    <script src="../../js/JScript.js" type="text/javascript"></script>
    <script type="text/javascript">
        function over(obj)
        {
            obj.setAttribute("style","background-color:#ccccff");
            //obj.
            var es=obj.getElementsByTagName("a");
            if(es&&es[0])
            {
                es[0].style.display="";
            }
            
        }
        function out(obj)
        {
            obj.setAttribute("style"," ");
            var es=obj.getElementsByTagName("a");
            if(es&&es[0])
            {
                es[0].style.display="none";
            }
        }
    </script>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <table class="admintable">
                <tr>
                    <td class="noBorder" colspan="2" style="text-align: center; height: 20px;">
                        <strong><span style="font-size: 16pt"><strong>留言管理</strong></span></strong></td>
                </tr>
                <asp:Repeater ID="rep_messages" runat="server">
                    <ItemTemplate>
                        <tr onmouseover="over(this)" onmouseout="out(this)">
                            <td class="" colspan="2" style="height: 11px; text-align: left; border-bottom-width: 5px;
                                border-bottom-color: #ccccff">
                                <div style="">
                                    <span><strong>标题：</strong><span style="font-size: 12pt"><%# Eval("title") %></span></span>
                                    <span style="font-size: 8pt"><strong>日期：</strong><%# Eval("date","{0:yyyy-MM-dd HH:mm}") %></span><span
                                        style="margin-left: 600px"><asp:LinkButton ID="btn_del" runat="server" Text="删除" style="display:none"
                                            CommandName="delMsg" CommandArgument='<%# Eval("id") %>'></asp:LinkButton></span><br />
                                    <span><strong>姓名：</strong><%# Eval("name") %>
                                        &nbsp; &nbsp;<strong> 电话：</strong><%# Eval("phone") %>
                                        &nbsp; <strong>Email：</strong><%# Eval("email") %>
                                        &nbsp; &nbsp;<strong> 留言地点：</strong><asp:Label ID="lab_ipadd" runat="server">未知</asp:Label><strong>&nbsp;
                                            Ip:</strong><asp:Label ID="lab_ip" runat="server"> <%# Eval("ipaddress") %></asp:Label></span>
                                    <br />
                                    <span><strong>地址：</strong><%# Eval("address") %></span>
                                </div>
                                <hr />
                                <div style="">
                                    <%# Eval("content") %>
                                </div>
                            </td>
                        </tr>
                    </ItemTemplate>
                </asp:Repeater>
                <tr>
                    <td class="noBorder" colspan="2" style="text-align: center;">
                        <webdiyer:AspNetPager ID="AspNetPager1" runat="server" NumericButtonCount="6"
                            UrlPaging="true" FirstPageText="|<"  LastPageText=">|" NextPageText=">>" PrevPageText="<<"
                            Font-Names="Arial" AlwaysShow="true" ShowPageIndexBox="Never" SubmitButtonText="跳转"
                            SubmitButtonStyle="botton" OnPageChanging="AspNetPager1_PageChanged">
                        </webdiyer:AspNetPager>
                    </td>
                </tr>
            </table>
        </div>
    </form>
</body>
</html>
