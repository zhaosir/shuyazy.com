<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Right.aspx.cs" Inherits="admin_frame_Right" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>无标题页</title>
</head>
<body>
    <form id="Form1" runat="server">
	<div style="font-size:12px; padding-left:20px; padding-top:10px;">
	 服务器计算机名：<asp:Label ID="lbServerName" runat="server"></asp:Label><br /><br />
     服务器IP地址：<asp:Label ID="lbIp" runat="server"></asp:Label><br /><br />
     服务器域名：<asp:Label ID="lbDomain" runat="server"></asp:Label><br /><br />
     服务器端口：<asp:Label ID="lbPort" runat="server"></asp:Label><br /><br />
     服务器IIS版本：<asp:Label ID="lbIISVer" runat="server"></asp:Label><br /><br />
     本文件所在文件夹：<asp:Label ID="lbPhPath" runat="server"></asp:Label><br /><br />
     服务器操作系统：<asp:Label ID="lbOperat" runat="server"></asp:Label><br /><br />
     系统所在文件夹：<asp:Label ID="lbSystemPath" runat="server"></asp:Label><br /><br />
     服务器脚本超时时间：<asp:Label ID="lbTimeOut" runat="server"></asp:Label><br /><br />
     ASP.NET Framework 版本：<asp:Label ID="lbAspnetVer" runat="server"></asp:Label><br /><br />
     服务器当前时间：<asp:Label ID="lbCurrentTime" runat="server"></asp:Label><br /><br />
     CPU 总数：<asp:Label ID="lbCpuNum" runat="server"></asp:Label>个<br /><br />
     CPU 类型：<asp:Label ID="lbCpuType" runat="server"></asp:Label><br /><br />
     当前程序占用内存：<asp:Label ID="lbMemoryPro" runat="server"></asp:Label><br /><br />
     虚拟内存：<asp:Label ID="lbMemory" runat="server"></asp:Label>
	</div>	
	</form>
</body>
</html>
