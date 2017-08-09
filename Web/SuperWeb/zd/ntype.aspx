<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ntype.aspx.cs" Inherits="Web.SuperWeb.zd.ntype" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="../js/easyUI/themes/default/easyui.css" rel="stylesheet" type="text/css" />
    <link href="../css/default.css" rel="stylesheet" type="text/css" />
    <link href="../js/easyUI/themes/icon.css" rel="stylesheet" type="text/css" />
    <link href="../css/myCss.css" rel="stylesheet" type="text/css" />
    <script src="../js/easyUI/jquery.min.js" type="text/javascript" language="javascript"></script>
    <script src="../js/easyUI/jquery.easyui.min.js" type="text/javascript" language="javascript"></script>
    <script src="../js/easyUI/locale/easyui-lang-zh_CN.js" type="text/javascript" language="javascript"></script>
    <script src="../js/JSConfig.js" language="javascript" type="text/javascript"></script>
    <script src="../js/JSControl.js" language="javascript" type="text/javascript"></script>
    <script src="../js/ntype.js" language="javascript" type="text/javascript"></script>
</head>
<body class="easyui-layout" style="overflow-y: hidden" scroll="no" oncontextmenu="return false" onselectstart="return false">
    <div region="center">
        <div id="mainCenter" style="width: 100%; height: 100%;">
            <table id="tdg">
            </table>
        </div>
        <div id="Edit" style="display: none; width: 100%; height: 100%; overflow: hidden;">
            <div class="easyui-panel" title="新闻类别信息" style="width: 100%; height: 97%;">
                <div class="easyui-linkbutton" iconcls="icon-redo">
                    <a href="javascript:void(0);" id="areturn">返回列表</a>
                </div>
                <br />
                <form id="forms" runat="server">
                <table class="tb" border="0px" cellpadding="0" cellspacing="0">
                    <tr>
                        <td style="width: 80px" height="43">
                            新闻类型名称
                        </td>
                        <td>
                            <input type="text" name="NewsTypeName" id="txtNewsTypeName" maxlength="100" class="easyui-textbox"
                                style="width: 200px;" required="true" />
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 80px" height="43">
                            上级新闻类型
                        </td>
                        <td>
                            <select id="txtUpId" name="UpId" class="easyui-combobox" style="width: 200px;" required="true">
                            </select>
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 80px" height="43">
                            新闻类型级别
                        </td>
                        <td>
                            <select id="txtTypeLevel" name="TypeLevel" class="easyui-combobox" required="true" style="width: 200px;">
                                <option value="1">一级</option>
                                <option value="2" selected="selected">二级</option>
                                <option value="3">三级</option>
                                <option value="4">四级</option>
                                <option value="5">五级</option>
                                <option value="6">六级</option>
                                <option value="7">七级</option>
                                <option value="8">八级</option>
                                <option value="9">九级</option>
                                <option value="10">十级</option>
                            </select>
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
                </form>
            </div>
        </div>
    </div>
</body>
</html>
