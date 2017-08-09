<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="roleuser.aspx.cs" Inherits="Web.SuperWeb.sys.roleuser" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
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
    <script src="../js/roleuser.js" type="text/javascript" language="javascript"></script>
</head>
<body class="easyui-layout" style="overflow-y: hidden" scroll="no" oncontextmenu="return false"
    onselectstart="return false">
     <form id="formNews" runat="server">
    <div region="center" split="true" style="overflow: hidden; border: 0px;"
        border="false">
        
        <div id="mainCenter" style="width: 100%; height: 100%;">
            <table id="adminTg">
            </table>
        </div>
        <div id="newsEdit" style="display:none; width: 100%; height: 100%; overflow: hidden;">
            <div class="easyui-panel" title="角色信息" style="width: 100%; height: 97%;">
                <div class="easyui-linkbutton" iconcls="icon-redo">
                    <a href="javascript:void(0);" id="areturn">返回角色列表</a>
                </div>
                <br />
               
                <table class="table" border="0px" cellpadding="0" cellspacing="0">
                    <tr>
                        <td style="width: 80px" height="43">
                            角色名称<span style="color: Red;">*</span>
                        </td>
                        <td>
                            <input type="text" name="rolename" id="txtrolename" maxlength="100" class="easyui-textbox"
                                style="width: 300px;" required="true" />
                        </td>
                    </tr>
                   
                    <tr>
                        <td colspan="2" height="43">
                            <div style="text-align: left; padding-left: 100px; height: 30px; line-height: 30px;">
                                <a id="btnAddNews" class="easyui-linkbutton" icon="icon-ok" href="javascript:void(0)">
                                    添加</a> <a id="btnEditNews" class="easyui-linkbutton" icon="icon-ok" href="javascript:void(0)"
                                        style="display: none">修改</a> <a id="btnCancel" class="easyui-linkbutton" icon="icon-cancel"
                                            href="javascript:void(0)">取消</a>
                            </div>
                        </td>
                    </tr>
                </table>
                <input id="txtId" name="Id" type="hidden" value="0" />
                <input id="txtNumClicks" name="NumClicks" type="hidden" value="0" />
                <input id="txtIfDel" name="IfDel" type="hidden" value="0" />
                
            </div>
        </div>
        <div id="roleEdit" style="display: none; width: 100%; height: 100%; overflow: hidden;">
            <div class="easyui-panel" title="权限设置" style="width: 100%; height: 97%;">
                <div class="easyui-linkbutton" iconcls="icon-redo">
                    <a href="javascript:void(0);" id="afanhui">返回列表</a>
                </div>
                &nbsp;&nbsp;&nbsp;&nbsp;<a id="btnAdd" class="easyui-linkbutton" icon="icon-ok" href="javascript:void(0)">添加授权</a>
                <br />
                <br />
                <div style="border-color: #8AAADB; border-style: solid; border-width: 2px;">
                <br />
                &nbsp;&nbsp;&nbsp;&nbsp;<span style="color:Red;">授予[ <span id="lblName"></span> ]以下权限：</span>
                <hr />
                    &nbsp;&nbsp;&nbsp;&nbsp;操作权限：<input type="checkbox" id="tIfAdd" name="IfAdd" checked="checked"/>添加
                    <input type="checkbox" id="tIfUp" name="IfUp" checked="checked"/>修改<input type="checkbox" id="tIfDel"
                        name="IfDel" checked="checked"/>删除
                    <input type="checkbox" id="tIfSel" name="IfSel" checked="checked"/>查询
                    <hr/>
                    <ul id="sfun" class="tree">
                    </ul>
                   <input id="txtroleid" name="txtroleid" type="hidden" value="0" />
                </div>
            </div>
        </div>
    </div>
    </form>
</body>
</html>
