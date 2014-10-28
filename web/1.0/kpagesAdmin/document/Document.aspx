<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Document.aspx.cs" Inherits="kpagesAdmin_document_Document" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>无标题页</title>
    <link href="../css/common.css" rel="stylesheet" type="text/css" />
    <script src="../../js/JScript.js" type="text/javascript"></script>
    <link href="../../css/public.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
        <div id="man_zone">
            <table class="admintable">
                <tr>
                    <td>
                        <input type="submit" onserverclick="SortByHits" runat="server" class="bn" value="按点击排名" />
                        <input type="submit" onserverclick="SortByDate" runat="server" class="bn" value="按时间排名" />
                        
                    </td>
                </tr>
                <tr>
                    <td class="noBorder">
                        <label>搜索选项</label>
                        <asp:DropDownList ID="ddl" runat="server"></asp:DropDownList>
                        <label>关键字</label>
                        <input type="text" runat="server" id="tbKeyword" size="32" />
                        <label>生成状态</label>
                        <select id="ddlState" runat="server">
                            <option value="0">新建</option>
                            <option value="1">已生成</option>
                        </select>
                        
                        <input type="submit" id="bnSure" onserverclick="Search" class="bn" runat="server" value="确定" />
                    </td>
                </tr>
            </table>
            
            <asp:GridView ID="gv" CssClass="admintable" runat="server" 
                AutoGenerateColumns="False">
                <Columns>
                    <asp:BoundField DataField="ID" HeaderText="编号" />
                    <asp:TemplateField HeaderText="标题">
                        <EditItemTemplate>
                            <asp:CheckBox ID="CheckBox1" runat="server" />
                        </EditItemTemplate>
                        <ItemTemplate>
                            <asp:CheckBox ID="CheckBox1" runat="server" Text='<%# Eval("title") %>' />
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:BoundField DataField="postDate" HeaderText="发表时间" />
                    <asp:TemplateField HeaderText="生成状态">
                        <EditItemTemplate>
                            <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("builded") %>'></asp:TextBox>
                        </EditItemTemplate>
                        <ItemTemplate>
                            <asp:Label ID="Label1" runat="server" Text='<%# Convert.ToInt32(Eval("builded").ToString())>0?"已生成":"新建" %>' ></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="发布状态">
                        <EditItemTemplate>
                            <asp:TextBox ID="TextBox2" runat="server" Text='<%# Bind("state") %>'></asp:TextBox>
                        </EditItemTemplate>
                        <ItemTemplate>
                            <asp:Label ID="Label2" runat="server" Text='<%# Convert.ToInt32(Eval("state").ToString())>0?"已发布":"未审核" %>' ></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:BoundField DataField="post" HeaderText="点击" />
                    <asp:HyperLinkField DataNavigateUrlFields="ID" 
                        DataNavigateUrlFormatString="DocumentInfo.aspx?ID={0}" HeaderText="编辑" 
                        Text="编辑" />
                </Columns>
                
            </asp:GridView>
            
            <table class="admintable">
                <tr>
                    <td class="noBorder">
                        <input id="Submit2" class="bn1" type="submit" value="删除所选" onserverclick="Delete" runat="server"/>
                        <input class="bn1" onclick="selectOthers()" type="button" value="反向选择" />
                        <input class="bn1" onclick="selectAll()" type="button" value="全选" />

                        <input id="Submit1" class="bn1" type="submit" value="添加" onserverclick="New" onclick="add()" runat="server" />
                         
                        <input class="bn1" type="submit" value="发布" onserverclick="Push" runat="server" />
                        <input class="bn1" type="submit" value="生成" onserverclick="Build"  runat="server"/>
                        <div class="yahoo"><span class="disabled"> < </span>
                             <asp:Literal ID="pages" runat="server"></asp:Literal>
                        </div>
                        
                    </td>
                </tr>
            </table>
        </div>
    </form>
</body>
    
    <script type="text/javascript" language="javascript">

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

    </script>
</html>
