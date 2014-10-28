<%@ Page Language="C#" AutoEventWireup="true" CodeFile="DocumentInfo.aspx.cs" Inherits="kpagesAdmin_document_DocumentInfo" %>
<%@ Register Assembly="CuteEditor" Namespace="CuteEditor" TagPrefix="CE" %>

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

            <ul id="tab" class="tab">
                <li class="select" id="nav1" onclick="select('1')">文档信息</li>
                <li class="selectNo" id="nav2" onclick="select('2')">优化信息</li>
            </ul>
            <table id="tab1" class="admintable">
                <tr>
                    <td>
                        <label>标题</label>
                        <input id="tbTitle" type="text" size="50" runat="server" />
                        <label id="titleInfo" class="errorMsg">*</label>
                    </td>
                </tr>
                <tr>
                    <td>
                        <label>分类</label>
                        <asp:DropDownList ID="ddlCate" runat="server" Enabled="False" Visible="False"></asp:DropDownList>
                        <label id="categoryInfo" class="errorMsg" runat="server">
                            最新咨询</label></td>
                </tr>
                
                <tr>
                    <td>
                        <CE:Editor ID="Editor1" runat="server" AutoConfigure="Minimal" Width="100%">
<FrameStyle BackColor="White" BorderColor="#DDDDDD" BorderWidth="1px" BorderStyle="Solid" CssClass="CuteEditorFrame" Height="100%" Width="100%"></FrameStyle>
                        </CE:Editor>
                    </td>
                </tr>
            </table>
            
            <table id="tab2" class="admintable">
                <tr>
                    <td>
                        <label>优化标题</label>
                        <input id="tbSEOTitle" type="text" size="50" runat="server" />
                        <label id="seoTitleInfo" class="errorMsg">*</label>
                    </td>
                </tr>
                <tr>
                    <td>
                        <label>关键字词</label>
                        <input id="tbKeyword" type="text" size="50" runat="server" />
                        <label id="keywordInfo" class="errorMsg">*</label>
                    </td>
                </tr>
                <tr>
                    <td>
                        <label>页面描述</label>
                        <textarea id="tbDesrciption" runat="server" rows="5" cols="80"></textarea>
                    </td>
                </tr>
            </table>
            
            <table class="admintable">
                <tr>
                    <td class="noBorder">
                        <input id="bnAdd" type="submit" class="bn" onserverclick="AddInfo" onclick="return pageElementDataCheck.sumit();" value="保存" runat="server" />
                        <input id="bnUpdate" type="submit" class="bn" onserverclick="UpdateInfo" onclick="return pageElementDataCheck.sumit();" value="修改" runat="server" />
                        <input id="bnGo" type="submit" class="bn" onserverclick="Go" runat="server" value="设置相册图片" />
                        <input id="bnGoImg" type="submit" class="bn" onserverclick="GoImg" runat="server" value="设置产品图片" />

                         <a href="Category.aspx" class="bn">返回栏目管理</a>
                         <a href="Document.aspx" class="bn" style="display:none">返回文档管理</a>
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

                if(result>0)
                {
                    return false;
                }
            }
       }
       

      
       
       function clearStyle()
       {
             var tabList = document.getElementsByTagName("li");
             for(var i=0;i<tabList.length;i++)
             {
                tabList[i].className ="selectNo";
             }

             $("tab1").style.display="none";
             $("tab2").style.display="none";
       }
       
       
       function select(id)
       {
            clearStyle();
            var navID ="nav"+id;
            var tableID ="tab"+id;
            
            $(navID).className="select";
            $(tableID).style.display="";
       }
       
       select(1);
       
       function backto()
       {
            history.go(-2);
       }
       
    </script>

</html>
