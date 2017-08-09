<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="admin.aspx.cs" Inherits="Web.SuperWeb.sys.admin" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>管理员信息</title>
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
    <script src="../js/admin.js" type="text/javascript" language="javascript"></script>
</head>
<body class="easyui-layout" style="overflow-y: hidden" scroll="no" oncontextmenu="return false" onselectstart="return false">
    <div region="north" title="管理员信息搜索" split="true" style="height: 65px; overflow: hidden;
        border: 0px;" border="false">
        &nbsp;&nbsp;登录账号：
        <input type="text" id="txt_AdminLogName" class="easyui-textbox" required="required" style=" width:300px;"/>
        <a href="javascript:void(0)" id="btnQuery" class="easyui-linkbutton" iconcls="icon-search">
            管理员账号搜索</a>
    </div>
    <div region="center">
        <div id="mainCenter" style="width: 100%; height: 100%;">
            <table id="tdg">
            </table>
        </div>
        <div id="adminUserEdit" style="display: none; width: 100%; height: 100%; overflow: hidden;">
            <div class="easyui-panel" title="管理员详细信息" style="width: 100%; height: 97%;">
                <div class="easyui-linkbutton" iconcls="icon-redo">
                    <a href="javascript:void(0);" id="areturn">返回信息列表</a>
                </div>
                <br />
                <br />
                <form id="adminUserFrom" runat="server">
                <table class="tb" border="0px" cellpadding="0" cellspacing="0">
                    <tr>
                        <td style="width: 80px" height="43">
                            登录账号<span style="color: Red;">*</span>
                        </td>
                        <td>
                            <input type="text" name="AdminLogName" id="txtAdminLogName" maxlength="100" class="easyui-textbox"
                                style="width:300px;" required="true"  />
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 80px" height="43">
                            登录密码<span style="color: Red;">*</span>
                        </td>
                        <td>
                            <input id="txtAdminLogPass" type="password" name="AdminLogPass" 
                                style="width: 300px;" class="easyui-validatebox" data-options="required:true,validType:'length[6,20]'">  
                        </td>
                    </tr>
                    <tr>
                        <td height="43">
                            单位代码<span style="color: Red;">*</span>
                        </td>
                        <td>
                            <input type="text" id="txtUnitCode" name="UnitCode" maxlength="50" value="" class="easyui-textbox"
                                style="width: 250px;" required="true" />&nbsp;&nbsp;<a href="javascript:void(0)"
                                    onclick="OnOpenTree();">请选择</a>
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 80px" height="43">
                            姓名
                        </td>
                        <td>
                            <input id="txtAdminName" name="AdminName" class="easyui-textbox" style="width: 300px;" />
                        </td>
                    </tr>
                    <tr>
                        <td height="43">
                            电话
                        </td>
                        <td>
                            <input type="text" name="AdminTel" id="txtAdminTel" class="easyui-textbox" style="width: 300px;" />
                        </td>
                    </tr>
                    <tr>
                        <td height="43">
                            登录状态
                        </td>
                        <td>
                            <select name="AdminState" id="txtAdminState" class="easyui-combobox" style="width: 300px;">
                                <option value="1">正常使用</option>
                                <option value="0">禁止该登陆账号登录到系统平台中</option>
                            </select>
                        </td>
                    </tr>
                    <tr>
                        <td height="43">
                            审核权限
                        </td>
                        <td>
                            <select name="IsCheck" id="txtIsCheck" class="easyui-combobox" style="width: 300px;">
                                <option value="0">该用户发布信息需要上级审核后网站才显示信息</option>
                                <option value="1">用户发布信息不审核就显示</option>
                            </select>
                        </td>
                    </tr>
                    <tr>
                        <td height="43">
                            角色权限
                        </td>
                        <td>
                            <%--<select name="roleid" id="roleid" class="easyui-combobox" style="width: 300px;">
                                <option value="0">管理员</option>
                                <option value="1">操作员</option>
                            </select>--%>
                            <input id="roleid" class="easyui-combobox" style=" width:200px;" name="roleid"   
    data-options="valueField:'id',textField:'rolename',url:'../ashx/roleuser.ashx?action=rolecombox'" />  


                        </td>
                    </tr>
                    <tr>
                        <td colspan="2" height="43">
                            <div style="text-align: left; padding-left: 100px; height: 30px; line-height: 30px;">
                                <a id="btnAdd" class="easyui-linkbutton" icon="icon-ok" href="javascript:void(0)">
                                    添加</a> <a id="btnEdit" class="easyui-linkbutton" icon="icon-ok" href="javascript:void(0)"
                                        style="display: none">修改</a> <a id="btnCancel" class="easyui-linkbutton" icon="icon-cancel"
                                            href="javascript:void(0)">取消</a>
                            </div>
                        </td>
                    </tr>
                </table>
                <input id="txtId" name="Id" type="hidden" value="0" />
                <input id="txtAdminType" name="AdminType" type="hidden" value="0" />
                <input id="txtAdminLogNum" name="AdminLogNum" type="hidden" value="0" />
                <input id="txtEndDate" name="EndDate" type="hidden" value="0" />
                <input id="txtEditor" name="Editor" type="hidden" value="0" />
                <input id="txtCreateDate" name="CreateDate" type="hidden" value="0" />
                </form>
            </div>
        </div>
    </div>
    <div id="orgList" class="easyui-window" title="选择组织单位代码" collapsible="false" minimizable="false"
        maximizable="false" icon="icon-save" style="width: 250px; height: 400px; padding: 5px;
        background: #fafafa;">
        <ul id="tree" class="tree">
        </ul>
    </div>
</body>
</html>
