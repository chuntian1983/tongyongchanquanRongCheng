<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="member.aspx.cs" Inherits="Web.SuperWeb.um.member" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="../js/easyUI/themes/default/easyui.css" rel="stylesheet" type="text/css" />
    <link href="../css/default.css" rel="stylesheet" type="text/css" />
    <link href="../js/easyUI/themes/icon.css" rel="stylesheet" type="text/css" />
    <link href="../css/myCss.css" rel="stylesheet" type="text/css" />
    <link href="../css/zTreeStyle.css" rel="stylesheet" type="text/css" />
    <script src="../js/easyUI/jquery.min.js" type="text/javascript" language="javascript"></script>
    <script src="../js/easyUI/jquery.easyui.min.js" type="text/javascript" language="javascript"></script>
    <script src="../js/easyUI/locale/easyui-lang-zh_CN.js" type="text/javascript" language="javascript"></script>
    <script src="../js/jquery.ztree-2.6.min.js" type="text/javascript" language="javascript"></script>
    <script src="../js/main.js" type="text/javascript" language="javascript"></script>
    <script src="../js/JSConfig.js" language="javascript" type="text/javascript"></script>
    <script src="../js/JSControl.js" language="javascript" type="text/javascript"></script>
    <script src="../js/member.js" type="text/javascript" language="javascript"></script>
</head>
<body class="easyui-layout" style="overflow-y: hidden" scroll="no" oncontextmenu="return false" onselectstart="return false">
    <div region="north" title="会员信息搜索" split="true" style="height: 65px; overflow: hidden;
        border: 0px;" border="false">
        &nbsp;&nbsp;会员名称：
        <input type="text" id="tUserName" class="easyui-textbox" required="true" style=" width:300px;" />
        <a href="javascript:void(0)" id="btnQuery" class="easyui-linkbutton" iconcls="icon-search">
            会员搜索</a>
    </div>
    <div region="center">
        <div id="mainCenter" style="width: 100%; height: 100%;">
            <table id="tdg">
            </table>
        </div>
        <div id="Edit" style="display: none; width: 100%; height: 100%; overflow: hidden;">
            <div class="easyui-panel" title="会员信息详细信息" style="width: 100%; height: 97%;">
                <div class="easyui-linkbutton" iconcls="icon-redo">
                    <a href="javascript:void(0);" id="areturn">返回信息列表</a>
                </div>
                <br />
                <form id="forms" runat="server">
                <table class="tb"  border="0px" cellpadding="0" cellspacing="0">
                    <tr>
                        <td style="width: 80px" height="43">
                            会员登陆账号<span style="color: Red;">*</span>
                        </td>
                        <td>
                            <input type="text" name="UserLogName" id="txtUserLogName" maxlength="100" class="easyui-textbox"
                                style="width: 300px;" required="true" />
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 80px" height="43">
                            会员登陆密码<span style="color: Red;">*</span>
                        </td>
                        <td>
                            <input id="txtUserLogPass" type="password" name="UserLogPass" class="easyui-textbox"
                                style="width: 300px;" required="true" />
                        </td>
                    </tr>
                    <tr>
                        <td height="43">
                            会员姓名<span style="color: Red;">*</span>
                        </td>
                        <td>
                            <input type="text" id="txtUserName" name="UserName" maxlength="50" value="" class="easyui-textbox"
                                style="width: 300px;" required="true" />
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 80px" height="43">
                            会员性别
                        </td>
                        <td>
                            <select name="UserSex" id="txtUserSex" class="easyui-combobox" style="width:50px;">
                                <option value="男" selected="selected">男</option>
                                <option value="女">女</option>
                            </select>
                        </td>
                    </tr>
                    <tr>
                        <td height="43">
                            身份证号码
                        </td>
                        <td>
                            <input type="text" name="CardId" id="txtCardId" class="easyui-textbox" style="width: 300px;" />
                        </td>
                    </tr>
                    <tr>
                        <td height="43">
                            会员地址
                        </td>
                        <td>
                            <input type="text" name="UserAddress" id="txtUserAddress" class="easyui-textbox"
                                style="width: 300px;" />
                        </td>
                    </tr>
                    <tr>
                        <td height="43">
                            会员电话
                        </td>
                        <td>
                            <input type="text" name="UserTel" id="txtUserTel" class="easyui-textbox" required="true" style="width: 300px;" />
                        </td>
                    </tr>
                    <tr>
                        <td height="43">
                            会员邮箱
                        </td>
                        <td>
                            <input type="text" name="UserEmail" id="txtUserEmail" class="easyui-textbox" data-options="required:true,validType:'email'" style="width: 300px;" />
                        </td>
                    </tr>
                    <tr>
                        <td height="43">
                            登录状态
                        </td>
                        <td>
                            <select name="UserState" id="txtUserState" class="easyui-combobox" style="width: 300px;">
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
                        <td colspan="2" height="43">
                            <div style="text-align: left; padding-left: 100px; height: 30px; line-height: 30px;">
                                <a id="btnAdd" class="easyui-linkbutton" icon="icon-ok" href="javascript:void(0)">添加</a>
                                <a id="btnEdit" class="easyui-linkbutton" icon="icon-ok" href="javascript:void(0)"
                                    style="display: none">修改</a> <a id="btnCancel" class="easyui-linkbutton" icon="icon-cancel"
                                        href="javascript:void(0)">取消</a>
                            </div>
                        </td>
                    </tr>
                </table>
                <input id="txtId" name="Id" type="hidden" value="0" />
                <input id="txtUserLogNum" name="UserLogNum" type="hidden" value="0" />
                </form>
            </div>
        </div>
    </div>
</body>
</html>
