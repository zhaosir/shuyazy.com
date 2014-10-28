<%@ Page Language="C#" AutoEventWireup="true" CodeFile="News.aspx.cs" Inherits="kpagesAdmin_document_News" %>

<%@ Register Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" TagPrefix="webdiyer" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <link href="../css/common.css" rel="stylesheet" type="text/css" />
    <style>
.list {
	PADDING-BOTTOM: 15px; PADDING-LEFT: 15px; PADDING-RIGHT: 15px; PADDING-TOP: 0px
}
.list UL LI {
	BORDER-BOTTOM: #cccccc 1px dashed; LINE-HEIGHT: 30px; LIST-STYLE-TYPE: none
}
.list UL LI SPAN {
	FLOAT: right
}
.list UL LI A {
	COLOR: #393939
}
.list UL LI SPAN {
	FLOAT: right
}
.lockDiv 
{ 
position:absolute; 
left:0; 
top:0; 
height:700px; 
width:1300px; 
border:2 solid red; 
display:none; 
text-align:center; 
background-color:#DBDBDB; 
filter:Alpha(opacity=60); 
} 
</style>

<script type="text/javascript">
var  xhr;                      
function showContent(obj)
{
    document.getElementById("lock").style.display="block";
    document.getElementById("div_content").style.display="block";
    document.getElementById("conten_span").innerHTML="正在获取内容...";
    var newsid=obj.getAttribute("newsid");
    var title=obj.innerText;
    if(title.length>11)
    {
        title=title.substring(0,8)+"..";
    }
    document.getElementById("title_a").innerText=title;
    CreatXMLHttpRequest();
    if(xhr)
    {

        var request_url="../../controls/GetNewsInfo.ashx?newsid="+newsid+"&time="+new Date().getTime();
        xhr.onreadystatechange=asynGetProInfo;
        xhr.open("GET",request_url);  
        xhr.send(null);
    }
}

function asynGetProInfo()
{
    if(xhr.readyState==4 && xhr.status == 200)
    {
        var returnValue = xhr.responseText;
        if(returnValue)
        {
            document.getElementById("conten_span").innerHTML=returnValue;
        }
        xhr=null; 
    }
}

function hiddenContent()
{
    document.getElementById("div_content").style.display="none";
    document.getElementById("lock").style.display="none";
}


//创建XHR对象
function CreatXMLHttpRequest() {
    try  {
        xhr=new XMLHttpRequest();
    }
    catch (e)
    {      
        try {
            xhr=new ActiveXObject("Msxml2.XMLHTTP");
        }
        catch (e) {
            try {
                xhr=new ActiveXObject("Microsoft.XMLHTTP");
            }
            catch (e){
                alert("您的浏览器不支持AJAX！");
            }
        }
    }
}
    </script>

    <title>最新资讯</title>
</head>
<body>
    <form id="form1" runat="server">
        <div style="text-align: center">
            <table class="admintable">
                <tr>
                    <td class="noBorder" colspan="2" style="text-align: center; height: 20px; width: 988px;">
                        <strong><span style="font-size: 16pt"><strong>最新咨询管理</strong></span></strong></td>
                </tr>
                <tr style="height:8px">
                    <td class="noBorder" colspan="2" style="text-align: right">
                        <span style="font-size: 8pt; border:solid 1px; cursor:pointer;" ><a href="DocumentInfo.aspx" title="最新资讯添加">最新资讯添加</a></span></td>
                </tr>
                <tr class="noBorder" colspan="2">
                    <td style="">
                        <div class="list">
                            <ul>
                                <asp:Repeater ID="rep_newsList" runat="server" OnItemCommand="rep_newsList_ItemCommand">
                                    <ItemTemplate>
                                        <li><span>
                                            <%# Eval("postDate","{0:yyyy-MM-dd HH:mm}") %>&nbsp;&nbsp;<asp:LinkButton ID="del" runat="server" Text="删除" CommandName="del" CommandArgument='<%#Eval("Id") %>'></asp:LinkButton>&nbsp;&nbsp;<a href='DocumentInfo.aspx?ID=<%#Eval("Id") %>'  title='修改'>修改</a>
                                        </span><a style="cursor: pointer" title='<%# Eval("title") %>' newsid='<%#Eval("Id") %>'
                                            onclick="showContent(this)">
                                            <%# Eval("title") %>
                                        </a></li>
                                    </ItemTemplate>
                                </asp:Repeater>
                            </ul>
                        </div>
                    </td>
                </tr>
                <tr>
                    <td class="noBorder" colspan="2" style="text-align: center; width: 988px;">
                        <webdiyer:AspNetPager ID="AspNetPager1" runat="server" NumericButtonCount="6" UrlPaging="true"
                            FirstPageText="|<" LastPageText=">|" NextPageText=">>" PrevPageText="<<" Font-Names="Arial"
                            AlwaysShow="true" ShowPageIndexBox="Never" SubmitButtonText="跳转" SubmitButtonStyle="botton"
                            OnPageChanging="AspNetPager1_PageChanged">
                        </webdiyer:AspNetPager>
                    </td>
                </tr>
            </table>
        </div>
        <div class="lockDiv" id="lock">
        </div>
        <div id="div_content" style="position: absolute; top: 50px; left: 233px; width: 734px;
            height: 483px; background-color: White; z-index: 2000; border: solid 1px black;
            text-align: center; display: none">
            <div style="text-align:left; margin-top: 9px;">
                <strong><span id="title_a" style="padding-left:300px">正在获取标题...</span><span style="position:absolute; cursor: pointer;margin-left:700px; left: 0px; top: 9px;"
                    title="关闭" onclick="hiddenContent()">X</span></strong>
            </div>
            <div style="margin-top: 5px; height: 1px; background-color: Black; width: 700px">
            </div>
            <div style="margin-top: 5px; width: 674px; height: 423px; overflow-y: scroll; text-align: left;">
                <span id="conten_span">正在获取内容...</span>
            </div>
        </div>
    </form>
</body>
</html>
