<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="sysLog.aspx.cs" Inherits="Web.SuperWeb.sys.sysLog" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>系统日志</title>
    <link href="../js/easyUI/themes/default/easyui.css" rel="stylesheet" type="text/css" />
    <link href="../css/default.css" rel="stylesheet" type="text/css" />
    <link href="../js/easyUI/themes/icon.css" rel="stylesheet" type="text/css" />
    <script src="../js/easyUI/jquery.min.js" type="text/javascript" language="javascript"></script>
    <script src="../js/easyUI/jquery.easyui.min.js" type="text/javascript" language="javascript"></script>
    <script src="../js/easyUI/locale/easyui-lang-zh_CN.js" type="text/javascript" language="javascript"></script>
    <script src="../js/JSConfig.js" language="javascript" type="text/javascript"></script>
    <script src="../js/JSControl.js" language="javascript" type="text/javascript"></script>
    <script src="../js/sysLog.js" language="javascript" type="text/javascript"></script>
</head>
<body class="easyui-layout" style="overflow-y: hidden" scroll="no" oncontextmenu="return false" onselectstart="return false">
    <form id="formlog" runat="server">
    <div region="north" title="日志查询" split="true" style="height: 65px; overflow: hidden;
        border: 0px;" border="false">
        开始时间：
        <input type="text" id="txtstateDate" class="easyui-datebox" required="required" />&nbsp;结束时间：
        <input type="text" id="txtendDate" class="easyui-datebox" required="required" />
        <a href="javascript:void(0)" id="btnQuery" class="easyui-linkbutton" iconcls="icon-search">
            日志搜索</a>
    </div>
    <div region="center">
        <table id="tdg">
        </table>
    </div>   
    </form>
</body>
</html>
