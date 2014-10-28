<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ADS.aspx.cs" Inherits="kpagesAdmin_ad_ADS" %>

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
            <h2>广告管理</h2>
            
            <asp:GridView ID="gv" runat="server" CssClass="admintable" 
                AutoGenerateColumns="False">
                <Columns>
                    <asp:BoundField DataField="ID" HeaderText="编号" />
                    <asp:TemplateField HeaderText="图片">
                        <EditItemTemplate>
                            <asp:CheckBox ID="CheckBox1" runat="server" />
                        </EditItemTemplate>
                        <ItemTemplate>
                            <asp:CheckBox ID="CheckBox1" runat="server" Text='<%# Eval("item_url") %>'  />
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:BoundField DataField="link" HeaderText="网址" />
                    <asp:TemplateField HeaderText="编辑" ShowHeader="False">
                        <ItemTemplate>
                            <asp:LinkButton ID="LinkButton1" runat="server" CausesValidation="False" 
                                CommandArgument='<%# Eval("id") %>' oncommand="LinkButton1_Command" Text="编辑"></asp:LinkButton>
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
            
            <table class="admintable">
                <tr>
                    <td>
                        <input id="Submit2" class="bn" type="submit" value="删除所选" onserverclick="Delete" runat="server"/>
                        <input class="bn" onclick="selectOthers()" type="button" value="反向选择" />
                        <input class="bn" onclick="selectAll()" type="button" value="全选" />
                        <input id="Submit1" class="bn" type="submit" value="添加" onserverclick="New" onclick="add()" runat="server" />
                    </td>
                </tr>
            </table>
            
            <table class="admintable">
                <tr>
                    <td>
                        <label>图片地址</label>
                        <input id="tbTitle" type="text" size="32" runat="server" />
                        <asp:FileUpload ID="FileUpload1" runat="server" />
                        <input type="submit" runat="server" value="上传" onserverclick="upimage" />
                        <label id="titleInfo" class="errorMsg" runat="server">*</label>
                    </td>
                </tr>
                
                <tr>
                    <td>
                        <label>链接网址</label>
                        <input id="tbSite" type="text" size="72" runat="server" />
                        <label id="siteInfo" class="errorMsg">*</label>
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
       
       var area = $("gv");
       var list = area.getElementsByTagName("input");
       
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
