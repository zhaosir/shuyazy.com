<%@ Page Language="C#" AutoEventWireup="true" CodeFile="SEO.aspx.cs" Inherits="kpagesAdmin_site_SEO" %>

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
            <h2>网站优化信息配置</h2>
            <table class="admintable">
                <tr>
                    <td>
                        <label>关键字词</label>
                        <input id="tbKeyword" type="text" size="62" runat="server" />
                        <label id="keywordInfo" class="errorMsg">*</label>
                    </td>
                </tr>
                
                <tr>
                    <td>
                        <label>页面描述</label>
                        <textarea id="tbDescriptiom" runat="server" rows="5" cols="80"></textarea> 
                    </td>
                </tr>
                

                
                <tr>
                    <td class="noBorder">
                        <input id="Submit1" type="submit" class="bn" onserverclick="setInfo" onclick="return pageElementDataCheck.sumit();" value="确定" runat="server" />
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
                if(CheckNull($('tbKeyword'),'keywordInfo')==false)
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
