<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="orglist.aspx.cs" Inherits="Web.SuperWeb.sys.orglist" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
    <link href="../js/easyUI/themes/default/easyui.css" rel="stylesheet" type="text/css" />
    <link href="../css/default.css" rel="stylesheet" type="text/css" />
    <link href="../css/myCss.css" rel="stylesheet" type="text/css" />
    <link href="../js/easyUI/themes/icon.css" rel="stylesheet" type="text/css" />
    <script src="../js/easyUI/jquery.min.js" type="text/javascript" language="javascript"></script>
    <script src="../js/easyUI/jquery.easyui.min.js" type="text/javascript" language="javascript"></script>
    <script src="../js/easyUI/locale/easyui-lang-zh_CN.js" type="text/javascript" language="javascript"></script>
    <script src="../js/org.js" language="javascript" type="text/javascript"></script>
    <script src="../js/JSConfig.js" language="javascript" type="text/javascript"></script>
    <script src="../js/JSControl.js" language="javascript" type="text/javascript"></script>
</head>
<body>
    
    <div region="north" title="组织单位管理" split="true" style="height: 35px; overflow: hidden;
        border: 0px;" border="false">
       <a href="javascript:void(0)" id="btnadd" class="easyui-linkbutton" iconcls="icon-add">
            添加</a>
        <a href="javascript:void(0)" id="btnedit" class="easyui-linkbutton" iconcls="icon-edit">
            修改</a>
            <a href="javascript:void(0)" id="btndel" class="easyui-linkbutton" iconcls="icon-remove" style=" display:none;">
            删除</a>
    </div>
    <div region="center">
    <div class="easyui-panel" style="padding:5px">
        <ul id="orglist" class="easyui-tree" ></ul>
    </div>
    
</div>
<div id="divadd" class="easyui-window" title="组织单位信息" style="width:430px;height:400px;"   
        data-options="iconCls:'icon-save',modal:true">   
    <div class="easyui-layout" data-options="fit:true">   
        
        <div data-options="region:'center'">   
        <form id="form1" runat="server">
          <table class="table" border="0px" cellpadding="0" cellspacing="0">
          <tr>
                        <td style="width: 80px" height="43">
                            上级组织单位<span style="color: Red;">*</span>
                        </td>
                        <td>
                            <input type="text" name="UpOrgCode" id="txtUpOrgCode" maxlength="100" class="easyui-textbox"
                                style="width: 300px;" required="true" />
                                <input type="hidden" name="hdtxtUpOrgCode" id="hdtxtUpOrgCode" />
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 80px" height="43">
                            组织单位代码<span style="color: Red;">*</span>
                        </td>
                        <td>
                            <input type="text" name="OrgCode" id="txtOrgCode" maxlength="100" class="easyui-textbox"
                                style="width: 300px;" required="true" />
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 80px" height="43">
                            组织单位全称<span style="color: Red;">*</span>
                        </td>
                        <td>
                            <input type="text" name="OrgName" id="txtOrgName" maxlength="100" class="easyui-textbox"
                                style="width: 300px;" required="true" />
                        </td>
                    </tr>
                    
                    <tr>
                        <td height="43">
                            组织单位简称<span style="color: Red;">*</span>
                        </td>
                        <td>
                            <input type="text" name="OrgShortName" id="txtOrgShortName" maxlength="100" class="easyui-textbox"
                                style="width: 300px;" required="true" />
                        </td>
                    </tr>
                    <tr>
                        <td height="43">
                            排序号<span style="color: Red;">*</span>
                        </td>
                        <td>
                            <input type="text" id="txtSeq" name="Seq" min="0" max="1000" precision="0" value="0" class="easyui-numberbox"
                                style="width: 300px;" />
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
                 </form>
        </div>   
    </div>   
</div>
   
</body>
</html>
