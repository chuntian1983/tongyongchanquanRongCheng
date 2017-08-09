<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PassChange.aspx.cs" Inherits="Web.SuperWeb.sys.PassChange" %>

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
    <script src="../js/pass.js" type="text/javascript" language="javascript"></script>
</head>
<body class="easyui-layout" style="overflow-y: hidden" scroll="no" oncontextmenu="return false"
    onselectstart="return false">
     <form id="formNews" runat="server">
    <div region="center" split="true" style="overflow: hidden; border: 0px;"
        border="false">
        
       
        <div id="newsEdit" style="display:block; width: 100%; height: 100%; overflow: hidden;">
            <div class="easyui-panel" title="用户密码修改" style="width: 100%; height: 97%;">
                
                <br />
               
                <table class="table" border="0px" cellpadding="0" cellspacing="0">
                    
                   <tr>
                        <td style="width: 80px" height="43">
                            原密码<span style="color: Red;">*</span>
                        </td>
                        <td>
                            <input type="text" name="oldpass" id="txtoldpass" maxlength="100" class="easyui-textbox"
                                style="width: 300px;" required="true" />
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 80px" height="43">
                            新密码<span style="color: Red;">*</span>
                        </td>
                        <td>
                            <input type="password" name="newpass" id="txtnewpass" maxlength="100" class="easyui-textbox"
                                style="width: 300px;" required="true" />
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 80px" height="43">
                            确认新密码<span style="color: Red;">*</span>
                        </td>
                        <td>
                            <input type="password" name="newpass2" id="txtnewpass2" maxlength="100" class="easyui-textbox"
                                style="width: 300px;" required="true" />
                        </td>
                    </tr>
                    <tr>
                        <td colspan="2" height="43">
                            <div style="text-align: left; padding-left: 100px; height: 30px; line-height: 30px;">
                                <a id="btnEditNews" class="easyui-linkbutton" icon="icon-ok" href="javascript:void(0)"
                                        >修改</a> <a id="btnCancel" class="easyui-linkbutton" icon="icon-cancel"
                                            href="javascript:void(0)">取消</a>
                            </div>
                        </td>
                    </tr>
                </table>
                <input id="txtId" name="Id" type="hidden" value="0" />
                
                
            </div>
        </div>
        
    </div>
    </form>
</body>
</html>
