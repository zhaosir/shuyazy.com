<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ProManage.aspx.cs" Inherits="kpagesAdmin_document_ProManage" %>

<%@ Register Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" TagPrefix="webdiyer" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>产品管理</title>
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
                //es[0].style.display="";
            }
            
        }
        function out(obj)
        {
            obj.setAttribute("style"," ");
            var es=obj.getElementsByTagName("a");
            if(es&&es[0])
            {
                //es[0].style.display="none";
            }
        }
    </script>

</head>
<body>
    <form id="form1" runat="server">
        <div>
            <table class="admintable"> 
                <tr>
                    <td class="noBorder" colspan="2" style="text-align: center">
                        <strong><span style="font-size: 14pt">产品管理</span></strong></td>
                </tr>
                <tr style="height:8px">
                    <td class="noBorder" colspan="2" style="text-align: right">
                        <span style="font-size: 8pt; border:solid 1px; cursor:pointer;" ><a href="ProAddAndEdit.aspx?type=add_shuya" title="产品添加">产品添加</a></span></td>
                </tr>
                <asp:Repeater ID="rep_pro" runat="server">
                    <ItemTemplate>
                        <tr onmouseover="over(this)" onmouseout="out(this)">
                            <td class="" colspan="2" style="height: 158px; text-align: left; border-bottom-width: 5px;
                                border-bottom-color: #ccccff">
                                <div style="float: left; border-right-width: 3px; border-right-style: solid; border-right-color: #a9a9a9">
                                    <ul>
                                        <li style=""><span>
                                            <img id="img_pro" runat="server" src='<%# "../../ProImg/s_"+Eval("url") %>' alt='<%# Eval("title") %>'
                                                title='<%# Eval("title") %>' />
                                            &nbsp; &nbsp;</span></li>
                                    </ul>
                                </div>
                                <div style="float: left; margin-left: 10px; width:80%">
                                    <ul>
                                        <li><span><strong><span style="font-size: 10pt">名称：</span></strong><%# Eval("title") %></span><span>
                                            &lt;<%# Eval("postDate")%>&gt;</span></li>
                                        <li><span><span style="font-size: 10pt"><strong>描述：</strong><%# Eval("contents") %></span></span></li>
                                        <li><strong><span style="font-size: 10pt">&nbsp;操作：</span></strong><asp:LinkButton
                                            ID="LinkButton1" runat="server" Text="删除" CommandName="del" CommandArgument='<%# Eval("id") %>' OnClientClick="return confirm( '确定要删除此记录吗？')"></asp:LinkButton>
                                            <asp:LinkButton ID="LinkButton2" runat="server" Text="修改" CommandName="edit" CommandArgument='<%# Eval("id") %>'></asp:LinkButton><span></span></li>
                                    </ul>
                                </div>
                            </td>
                        </tr>
                    </ItemTemplate>
                </asp:Repeater>
                <tr>
                    <td class="noBorder" colspan="2" style="text-align: center;">
                        <webdiyer:AspNetPager ID="AspNetPager1" runat="server" NumericButtonCount="6" UrlPaging="true"
                            FirstPageText="|<" LastPageText=">|" NextPageText=">>" PrevPageText="<<" Font-Names="Arial"
                            AlwaysShow="true" ShowPageIndexBox="Never" SubmitButtonText="跳转" SubmitButtonStyle="botton"
                            OnPageChanging="AspNetPager1_PageChanged">
                        </webdiyer:AspNetPager>
                    </td>
                </tr>
            </table>
        </div>
    </form>
</body>
</html>
