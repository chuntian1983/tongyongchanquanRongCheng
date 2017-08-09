<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="complaint.aspx.cs" Inherits="Web.SuperWeb.bc.complaint" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
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
    <script src="../js/complaint.js" type="text/javascript" language="javascript"></script>
</head>
<body class="easyui-layout" style="overflow-y: hidden" scroll="no" oncontextmenu="return false" onselectstart="return false">
    <div region="north" title="投诉信息搜索" split="true" style="height: 65px; overflow: hidden;
        border: 0px;" border="false">
        &nbsp;&nbsp;投诉标题：
        <input type="text" id="tConsTitle" class="easyui-textbox" required="required"  style="width:300px;"/>
        <a href="javascript:void(0)" id="btnQuery" class="easyui-linkbutton" iconcls="icon-search">搜索</a>
    </div>
    <div region="center">
        <div id="mainCenter" style="width: 100%; height: 100%;">
            <table id="tdg">
            </table>
        </div>
        <div id="Edit" style="display: none; width: 100%; height: 100%; overflow: hidden;">
            <div class="easyui-panel" title="投诉信息" style="width: 100%; height: 97%;">
                <div class="easyui-linkbutton" iconcls="icon-redo">
                    <a href="javascript:void(0);" id="areturn">返回信息列表</a>
                </div>
                <br />
                <form id="forms" runat="server">
                <table width=600 class="table" border="0px" cellpadding="0" cellspacing="0">
                    <tr>
                        <td style="width: 80px" height="43">
                            姓名
                        </td>
                        <td>
                            <input type="text" name="UserName" id="txtUserName" maxlength="100" class="easyui-textbox"
                                style="width: 300px;" />
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 80px" height="43">
                            地址
                        </td>
                        <td>
                            <input id="txtUserAddress" name="UserAddress" class="easyui-textbox" style="width: 300px;"
                               />
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 80px" height="43">
                            电话
                        </td>
                        <td>
                            <input id="txtUserTel" name="UserTel" class="easyui-textbox" style="width: 300px;"
                               />
                        </td>
                    </tr>
                    <tr>
                        <td height="43">
                            邮箱
                        </td>
                        <td>
                            <input type="text" name="UserEmail" id="txtUserEmail" class="easyui-textbox"
                                style="width: 300px;" />
                        </td>
                    </tr>
                    <tr>
                        <td height="43">
                            主题
                        </td>
                        <td>
                            <input type="text" id="txtConsTitle" name="ConsTitle" maxlength="50" value="" class="easyui-textbox"
                                style="width: 300px;" />
                        </td>
                    </tr>
                    <tr>
                        <td height="43">
                            内容
                        </td>
                        <td>
                            <textarea cols="80" rows="10" name="ConsContent" id="txtConsContent" ></textarea>
                        </td>
                    </tr>
                    <tr>
                        <td height="43">
                            咨询时间
                        </td>
                        <td>
                            <input name="ConsDate" type="text" id="txtConsDate" class="easyui-datebox" required="required" 
                                style="width: 100px;" />
                        </td>
                    </tr>
                    <tr>
                        <td height="43">
                            回复内容
                        </td>
                        <td>
                            <textarea cols="80" rows="10" name="ReplyContent" id="txtReplyContent" ></textarea>
                        </td>
                    </tr>
                    <tr>
                        <td height="43">
                            回复时间
                        </td>
                        <td>
                            <input id="txtReplyDate" name="ReplyDate" class="easyui-datebox" required="required"  style="width: 100px;"
                               />
                               
                        </td>
                    </tr>
                    <tr>
                        <td height="43">
                            回复人
                        </td>
                        <td>
                            <input id="txtReplyUser" name="ReplyUser" class="easyui-textbox" style="width: 100px;" />
                              
                        </td>
                    </tr>
                    <tr>
                        <td colspan="2" height="43">
                            <div style="text-align: left; padding-left: 100px; height: 30px; line-height: 30px;">
                                <a id="btnAdd" class="easyui-linkbutton" icon="icon-ok" href="javascript:void(0)">
                                    添加</a> <a id="btnEdit" class="easyui-linkbutton" icon="icon-ok" href="javascript:void(0)"
                                        style="display: none">回复</a> <a id="btnCancel" class="easyui-linkbutton" icon="icon-cancel"
                                            href="javascript:void(0)">取消</a>
                            </div>
                        </td>
                    </tr>
                </table>
                <input id="txtId" name="Id" type="hidden" value="0" />
                </form>
            </div>
        </div>
    </div>
</body>
</html>
