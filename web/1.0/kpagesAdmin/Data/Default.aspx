<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="kpagesAdmin_Data_Default" %>

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
            <h2>数据库备份和还原</h2>
            <table class="admintable">
                <tr>
                    <td>
                        <label>单击"备份数据库",系统会按日期自动保存备份文件到指定文件夹。</label>
                    </td>
                </tr>
                <tr>
                    <td class="noBorder">
                         <input type="submit" value="备份数据库" runat="server" onserverclick="backUp" />
                         
                    </td>
                </tr>
            </table>
            
            <table class="admintable">
                <tr>
                    <td>
                        <label>选择备份文件</label>
                        <input type="text" size="52" runat="server" id="tbFilePath" onfocus="openList()" />
                        <label id="tbFilePathInfo" runat="server" class="errorMsg">*</label>
                    </td>
                </tr>
                <tr>
                    <td>
                        <input id="Submit1" type="submit" value="还原选择的数据库备份" runat="server" onserverclick="restore" onclick="return pageElementDataCheck.sumit();"  />
                    </td>
                </tr>

            </table>
            
            <table  id="datalist" style="display:none;" class="admintable">
                <tr>
                    <td>
                        <asp:DataList ID="DataList1" runat="server" CellPadding="4" ForeColor="#333333" 
                            RepeatColumns="3" RepeatDirection="Horizontal" Width="100%">
                            <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                            <AlternatingItemStyle BackColor="White" />
                            <ItemStyle BackColor="#EFF3FB" />
                            <SelectedItemStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                            <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                            <ItemTemplate>
                                <label>[选择]</label><label onclick="selectThis(this)"><%# Eval("filePath") %></label>
                            </ItemTemplate>
                        </asp:DataList>
                    </td>
                </tr>
            </table>
            <label id="successInfo" runat="server" class="errorMsg"></label>
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
                if(CheckNull($('tbFilePath'),'tbFilePathInfo')==false)
                {
                    result++;
                   
                }
                
                if(result>0)
                {
                    return false;
                }
            }

       }

//       var selectID;
//       function selectImg(e)
//       {
//            selectID = e.id;
//            openList();
//            
//       }
      
       function openList()
       {
             $("datalist").style.display ="";
       }
       
       function closedList()
       {
            $("DataList1").style.display ="none";
       }
       
       function selectThis(e)
       {
            $("tbFilePath").value = e.innerHTML;
            closedList();
            
       }
    </script>
</html>
