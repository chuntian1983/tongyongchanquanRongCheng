<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="test.aspx.cs" Inherits="Web.SuperWeb.sys.test" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">

<head id="Head1" runat="server">
    <title>测试</title>
    <link href="../js/easyUI/themes/default/easyui.css" rel="stylesheet" type="text/css" />
    <link href="../css/default.css" rel="stylesheet" type="text/css" />
    <link href="../js/easyUI/themes/icon.css" rel="stylesheet" type="text/css" />

   
</head>
<body class="easyui-layout" style="overflow-y: hidden" scroll="no" oncontextmenu="return false" onselectstart="return false">
    <form id="test2" runat="server">
    <div region="north" title="日志查询" split="true" style="height: 65px; overflow: hidden;
        border: 0px;" border="false">
        开始时间：
        <input type="text" id="txtstateDate" runat="server" class="easyui-datebox" required="required" />&nbsp;结束时间：
        <input type="text" id="txtendDate" runat="server" class="easyui-datebox" required="required" />
        <a href="javascript:void(0)" id="btnQuery" class="easyui-linkbutton" iconcls="icon-search">
            日志搜索</a>
        
    </div>
    <div region="center">
       <asp:Button ID="Button1" runat="server" onclick="Button1_Click" Text="Button" />
    
        <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>  
    </form>
    </div> 
    
</body>


</html>
