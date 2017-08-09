<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="listpro.aspx.cs" Inherits="Web.SuperWeb.info.listpro" %>

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
    <script src="../js/listpro.js" type="text/javascript" language="javascript"></script>
</head>
<body class="easyui-layout" style="overflow-y: hidden" scroll="no" oncontextmenu="return false" onselectstart="return false">
    <div region="north" title="挂牌项目信息搜索" split="true" style="height: 65px; overflow: hidden;
        border: 0px;" border="false">
        &nbsp;&nbsp;挂牌项目名称：
        <input type="text" id="tOutProName" class="easyui-textbox" required="required" style="width: 300px;" />
        <a href="javascript:void(0)" id="btnSearch" class="easyui-linkbutton" iconcls="icon-search">
            搜索</a>
    </div>
    <div region="center">
    
        <div id="mainCenter" style="width: 100%; height: 100%;">
            <table id="tdg">
            </table>
        </div>
        <div id="Edit" style="display: none; width: 100%; height: 100%; overflow: hidden;">
            <div class="easyui-panel" title="挂牌项目详细信息" style="width: 100%; height: 97%;">
                <div class="easyui-linkbutton" iconcls="icon-redo">
                    <a href="javascript:void(0);" id="areturn">返回信息列表</a>
                </div>
                <br />
                <form id="forms" runat="server">
                <table class="table" border="0px" cellpadding="0" cellspacing="0" width="700">
                    <tr>
                        <td width="100" height="35">
                            组织单位代码<span style="color: Red;">*</span>
                        </td>
                        <td>
                            <input type="text" name="UnitCode" id="txtUnitCode" maxlength="400" class="easyui-textbox"
                                style="width: 200px;" required="true" />&nbsp;&nbsp;<a href="javascript:void(0);"
                                    id="btnUnitCode">请选择</a>
                        </td>
                    </tr>
                    <tr>
                        <td height="35">
                            项目编码
                        </td>
                        <td>
                            <input id="txtProNum" readonly="readonly" name="ProNum" class="easyui-textbox" style="width: 450px;"
                               />
                        </td>
                    </tr>
                    <tr>
                        <td height="35">
                            区域<span style="color: Red;">*</span>
                        </td>
                        <td>
                            <select id="txtRegion" name="Region" class="easyui-combobox" style="width: 450px;" required="true">
                            </select>
                        </td>
                    </tr>
                    <tr>
                        <td height="35">
                            项目类别<span style="color: Red;">*</span>
                        </td>
                        <td>
                            <select name="ProType" id="txtProType" class="easyui-combobox" required="true" style="width: 200px;">
                            </select>
                        </td>
                    </tr>
                    <tr>
                        <td height="35">
                            转出标的名称<span style="color: Red;">*</span>
                        </td>
                        <td>
                            <input type="text" id="txtOutProName" name="OutProName" maxlength="50" value="" class="easyui-textbox"
                                style="width: 450px;" required="true" />
                        </td>
                    </tr>
                    <tr>
                        <td height="35">
                            转出方名称<span style="color: Red;">*</span>
                        </td>
                        <td>
                            <input name="OutName" type="text" id="txtOutName" maxlength="50" class="easyui-textbox"
                                style="width: 450px;" required="true" />
                        </td>
                    </tr>
                    <tr>
                        <td height="35">
                            挂牌价格<span style="color: Red;">*</span>
                        </td>
                        <td>
                            <input name="ListingPrice" type="text" id="txtListingPrice" maxlength="50" class="easyui-textbox"
                                style="width: 200px;" required="true" />
                        </td>
                    </tr>
                    <tr>
                        <td height="35">
                            拟转出期限<span style="color: Red;">*</span>
                        </td>
                        <td>
                            <input name="OutPeriod" type="text" id="txtOutPeriod" class="easyui-textbox" style="width: 200px;"
                                required="true" />
                        </td>
                    </tr>
                    <tr>
                        <td height="35">
                            授权情况
                        </td>
                        <td>
                            <input type="text" id="txtAuthorization" name="Authorization" class="easyui-textbox"
                                style="width: 450px;" />
                        </td>
                    </tr>
                    <tr>
                        <td height="35">
                            坐落/市镇村
                        </td>
                        <td>
                            <input type="text" id="txtLocated" name="Located" class="easyui-textbox" style="width: 450px;" />
                        </td>
                    </tr>
                    <tr>
                        <td height="35">
                            权属
                        </td>
                        <td>
                            <input type="text" id="txtManageAuth" name="ManageAuth" class="easyui-textbox" style="width: 450px;" />
                        </td>
                    </tr>
                    <tr>
                        <td height="35">
                            承包方式
                        </td>
                        <td>
                            <input type="text" id="txtContractKind" name="ContractKind" class="easyui-textbox"
                                style="width: 450px;" />
                        </td>
                    </tr>
                    <tr>
                        <td height="35">
                            拟转出面积（亩）<span style="color: Red;">*</span>
                        </td>
                        <td>
                            <input type="text" id="txtOutArea" name="OutArea" class="easyui-textbox" style="width: 450px;" />
                        </td>
                    </tr>
                    <tr>
                        <td height="35">
                            涉及农户数
                        </td>
                        <td>
                            <input type="text" id="txtFarmersNum" name="FarmersNum" class="easyui-textbox" style="width: 450px;" />
                        </td>
                    </tr>
                    <tr>
                        <td height="35">
                            土地东至
                        </td>
                        <td>
                            <input type="text" id="txtEast" name="East" class="easyui-textbox" style="width: 450px;" />
                        </td>
                    </tr>
                    <tr>
                        <td height="35">
                            土地南至
                        </td>
                        <td>
                            <input type="text" id="txtSouth" name="South" class="easyui-textbox" style="width: 450px;" />
                        </td>
                    </tr>
                    <tr>
                        <td height="35">
                            土地西至
                        </td>
                        <td>
                            <input type="text" id="txtWest" name="West" class="easyui-textbox" style="width: 450px;" />
                        </td>
                    </tr>
                    <tr>
                        <td height="35">
                            土地北至
                        </td>
                        <td>
                            <input type="text" id="txtNorth" name="North" class="easyui-textbox" style="width: 450px;" />
                        </td>
                    </tr>
                    <tr>
                        <td height="35">
                            流转承包用途
                        </td>
                        <td>
                            <input type="text" id="txtGlebePurpose" name="GlebePurpose" class="easyui-textbox"
                                style="width: 450px;" />
                        </td>
                    </tr>
                    <tr>
                        <td height="35">
                            是否属于再次转出
                        </td>
                        <td>
                            <input type="text" id="txtWhetherAgainOut" name="WhetherAgainOut" class="easyui-textbox"
                                style="width: 450px;" />
                        </td>
                    </tr>
                    <tr>
                        <td height="35">
                            拟转出方式
                        </td>
                        <td>
                            <input type="text" id="txtOutWay" name="OutWay" class="easyui-textbox" style="width: 450px;" />
                        </td>
                    </tr>
                    <tr>
                        <td height="35">
                            农户转出意愿情况
                        </td>
                        <td>
                            <input type="text" id="txtFarmersWishes" name="FarmersWishes" class="easyui-textbox"
                                style="width: 450px;" />
                        </td>
                    </tr>
                    <tr>
                        <td height="35">
                            挂牌公告期
                        </td>
                        <td>
                            <input type="text" id="txtListedPeriod" name="ListedPeriod" class="easyui-datebox"
                                required="required" style="width: 200px;" />
                        </td>
                    </tr>
                    <tr>
                        <td height="35">
                            如征集到两个及以上有效转入申请
                        </td>
                        <td>
                            <input type="text" id="txtTwoApplication" name="TwoApplication" class="easyui-textbox"
                                style="width: 450px;" />
                        </td>
                    </tr>
                    <tr>
                        <td height="35">
                            转入方应具备的条件
                        </td>
                        <td>
                            <input type="text" id="txtTranCondition" name="TranCondition" class="easyui-textbox"
                                style="width: 450px;" />
                        </td>
                    </tr>
                    <tr>
                        <td height="35">
                            交易方式
                        </td>
                        <td>
                            <input type="text" id="txtTranMode" name="TranMode" class="easyui-textbox" style="width: 450px;" />
                        </td>
                    </tr>
                    <tr>
                        <td height="35">
                            标是否存在 抵押、封查等情况
                        </td>
                        <td>
                            <input type="text" id="txtIsMorSeal" name="IsMorSeal" class="easyui-textbox" style="width: 450px;" />
                        </td>
                    </tr>
                    <tr>
                        <td height="35">
                            其它需要披露事项
                        </td>
                        <td>
                            <input type="text" id="txtOther" name="Other" class="easyui-textbox" style="width: 450px;" />
                        </td>
                    </tr>
                    <tr>
                        <td height="35">
                            截止日期为
                        </td>
                        <td>
                            <input type="text" id="txtEndDate" name="EndDate" class="easyui-datebox" required="required"
                                style="width: 200px;" />
                        </td>
                    </tr>
                    <tr>
                        <td height="35">
                            挂牌状态
                        </td>
                        <td>
                            <input type="text" id="txtListingStatus" name="ListingStatus" class="easyui-textbox"
                                style="width: 200px;" />
                        </td>
                    </tr>
                    <tr>
                        <td height="35">
                            是否置顶
                        </td>
                        <td>
                            <select id="txtIfUp" name="IfUp" class="easyui-combobox" style="width: 200px;" required="true">
                                <option value="0" selected="selected">否</option>
                                <option value="1">是</option>
                            </select>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="2">
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
                <input id="txtIsCheck" type="hidden" name="IsCheck" value="0" />
                </form>
            </div>
        </div>
    </div>
    <div id="orgList" class="easyui-window" title="选择组织单位代码" collapsible="false" minimizable="false"
        maximizable="false" icon="icon-save" style="width: 250px; height: 400px; padding: 5px;
        background: #fafafa;">
        <ul id="org" class="tree">
        </ul>
    </div>
</body>
</html>
