<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="role.aspx.cs" Inherits="Web.SuperWeb.sys.role" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="../js/easyUI/themes/default/easyui.css" rel="stylesheet" type="text/css" />
    <link href="../css/default.css" rel="stylesheet" type="text/css" />
    <link href="../css/myCss.css" rel="stylesheet" type="text/css" />
    <link href="../js/easyUI/themes/icon.css" rel="stylesheet" type="text/css" />
    <link href="../css/zTreeStyle.css" rel="stylesheet" type="text/css" />
    <script src="../js/easyUI/jquery.min.js" type="text/javascript" language="javascript"></script>
    <script src="../js/easyUI/jquery.easyui.min.js" type="text/javascript" language="javascript"></script>
    <script src="../js/easyUI/locale/easyui-lang-zh_CN.js" type="text/javascript" language="javascript"></script>
    <script src="../js/jquery.ztree-2.6.min.js" type="text/javascript" language="javascript"></script>
    <script src="../js/main.js" type="text/javascript" language="javascript"></script>
    <script src="../js/JSConfig.js" language="javascript" type="text/javascript"></script>
    <script src="../js/JSControl.js" language="javascript" type="text/javascript"></script>
    <script src="../js/role.js" type="text/javascript" language="javascript"></script>
</head>
<body class="easyui-layout" style="overflow-y: hidden" scroll="no" oncontextmenu="return false"
    onselectstart="return false">
    <div region="north" split="true" style="height: 50%; overflow: hidden; border: 0px;"
        border="false">
        <table id="adminTg">
        </table>
    </div>
    <div region="center" split="true" style="height: 50%; overflow: hidden; border: 0px;"
        border="false">
        <div id="mainCenter" style="width: 100%; height: 100%;">
            <table id="roleTg">
            </table>
        </div>
        <div id="Edit" style="display: none; width: 100%; height: 100%; overflow: hidden;">
            <div class="easyui-panel" title="权限设置" style="width: 100%; height: 97%;">
                <div class="easyui-linkbutton" iconcls="icon-redo">
                    <a href="javascript:void(0);" id="areturn">返回列表</a>
                </div>
                &nbsp;&nbsp;&nbsp;&nbsp;<a id="btnAdd" class="easyui-linkbutton" icon="icon-ok" href="javascript:void(0)">添加授权</a>
                <br />
                <br />
                <div style="border-color: #8AAADB; border-style: solid; border-width: 2px;">
                <br />
                &nbsp;&nbsp;&nbsp;&nbsp;<span style="color:Red;">授予[ <span id="lblName"></span> ]管理账户以下权限：</span>
                <hr />
                    &nbsp;&nbsp;&nbsp;&nbsp;操作权限：<input type="checkbox" id="tIfAdd" name="IfAdd" checked="checked"/>添加
                    <input type="checkbox" id="tIfUp" name="IfUp" checked="checked"/>修改<input type="checkbox" id="tIfDel"
                        name="IfDel" checked="checked"/>删除
                    <input type="checkbox" id="tIfSel" name="IfSel" checked="checked"/>查询
                    <hr/>
                    <ul id="sfun" class="tree">
                    </ul>
                </div>
            </div>
        </div>
    </div>
</body>
</html>
