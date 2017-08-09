<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SuDemand.aspx.cs" Inherits="Web.SuperWeb.info.SuDemand" %>

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
    <script src="../js/SuDemand.js" type="text/javascript" language="javascript"></script>
</head>
<body class="easyui-layout" style="overflow-y: hidden" scroll="no" oncontextmenu="return false" onselectstart="return false">
    <div region="north" title="供应需求信息搜索" split="true" style="height: 65px; overflow: hidden;
        border: 0px;" border="false">
        &nbsp;&nbsp;供应需求信息名称：
        <input type="text" id="tProName" class="easyui-textbox" required="required" style="width: 300px;" />
        <a href="javascript:void(0)" id="btnQuery" class="easyui-linkbutton" iconcls="icon-search">
            搜索</a>
    </div>
    <div region="center">
        <div id="mainCenter" style="width: 100%; height: 100%;">
            <input name="rdobtn" type="radio" id="rdobtnS" value="1" checked="checked" onclick="OnSwitchingClick();" />供应信息&nbsp;&nbsp;&nbsp;&nbsp;<input
                type="radio" name="rdobtn" id="rdobtnD" value="2" onclick="OnSwitchingClick();" />需求信息
            <table id="tdg">
            </table>
        </div>
        <div id="Edit" style="display: none; width: 100%; height: 100%; overflow: hidden;">
            <div class="easyui-panel" title="供应需求信息详细信息" style="width: 100%; height: 97%;">
                <div class="easyui-linkbutton" iconcls="icon-redo">
                    <a href="javascript:void(0);" id="areturn">返回信息列表</a>
                </div>
                <br />
                <form id="forms" runat="server">
                <table class="tb" border="0px" cellpadding="0" cellspacing="0">
                    <tr>
                        <td style="width: 100px" height="40">
                            供应或需求
                        </td>
                        <td>
                           
                            <input name="rSupplyOrDemand" type="radio" value="1" checked="checked" onclick="OnCheckSupplyOrDemandClick();">供应信息&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<input
                                name="rSupplyOrDemand" type="radio" value="2" onclick="OnCheckSupplyOrDemandClick();">需求信息
                        </td>
                    </tr>
                    <tr>
                        <td height="40">
                            项目名称<span style="color: Red;">*</span>
                        </td>
                        <td>
                            <input id="txtProName" name="ProName" class="easyui-textbox" style="width: 300px;"
                                required="true" />
                        </td>
                    </tr>
                    <tr>
                        <td height="40">
                            关键字<span style="color: Red;">*</span>
                        </td>
                        <td>
                            <input id="txtKeyWord" name="KeyWord" class="easyui-textbox" style="width: 300px;"
                                required="true" />
                        </td>
                    </tr>
                    <tr>
                        <td height="40">
                            项目编号
                        </td>
                        <td>
                            <input type="text" name="ProNum" id="txtProNum" class="easyui-textbox" style="width: 300px;" readonly="readonly" />
                        </td>
                    </tr>
                </table>
                <div id="dSupply">
                    <table class="tb" border="0px" cellpadding="0" cellspacing="0">
                        <tr>
                            <td style="width: 100px" height="40">
                                受让方姓名
                            </td>
                            <td>
                                <input id="txtdName" name="dName" class="easyui-textbox" style="width: 300px;"  />
                            </td>
                        </tr>
                        <tr>
                            <td height="40">
                                受让方土地用途
                            </td>
                            <td>
                                <input id="txtdGlebePurpose" name="dGlebePurpose" class="easyui-textbox" style="width: 300px;"
                                    />
                            </td>
                        </tr>
                        <tr>
                            <td height="40">
                                受让方挂牌时间
                            </td>
                            <td>
                                <input id="txtdListingDate" name="dListingDate" class="easyui-datebox" style="width: 300px;"
                                     />
                            </td>
                        </tr>
                        <tr>
                            <td height="40">
                                受让方面积
                            </td>
                            <td>
                                <input type="text" name="dArea" id="txtdArea" class="easyui-textbox" style="width: 300px;" />
                            </td>
                        </tr>
                        <tr>
                            <td height="40">
                                受让方意向报价
                            </td>
                            <td>
                                <input type="text" name="dQuotation" id="txtdQuotation" class="easyui-textbox" style="width: 300px;" />
                            </td>
                        </tr>
                        <tr>
                            <td height="40">
                                受让方流转方式
                            </td>
                            <td>
                                <input type="text" name="dcirculation" id="txtdcirculation" class="easyui-textbox"
                                    style="width: 300px;" />
                            </td>
                        </tr>
                        <tr>
                            <td height="40">
                                受让方流转期限
                            </td>
                            <td>
                                <input type="text" name="dDeadline" id="txtdDeadline" class="easyui-textbox" style="width: 300px;" />
                            </td>
                        </tr>
                        <tr>
                            <td height="40">
                                受让方中心联系方式
                            </td>
                            <td>
                                <input type="text" name="dCenterContact" id="txtdCenterContact" class="easyui-textbox"
                                    style="width: 300px;" />
                            </td>
                        </tr>
                        <tr>
                            <td height="40">
                                受让方项目联系方式
                            </td>
                            <td>
                                <input type="text" name="dProContact" id="txtdProContact" class="easyui-textbox"
                                    style="width: 300px;" />
                            </td>
                        </tr>
                    </table>
                </div>
                <div id="dDemand" style="display: none;">
                    <table class="tb" border="0px" cellpadding="0" cellspacing="0">
                        <tr>
                            <td style="width: 100px" height="40">
                                转让方名称
                            </td>
                            <td>
                                <input id="txtsName" name="sName" class="easyui-textbox" style="width: 300px;"  />
                            </td>
                        </tr>
                        <tr>
                            <td height="40">
                                转让方土地性质
                            </td>
                            <td>
                                <input id="txtsLandProperties" name="sLandProperties" class="easyui-textbox" style="width: 300px;"
                                   />
                            </td>
                        </tr>
                        <tr>
                            <td height="40">
                                转让方其他
                            </td>
                            <td>
                                <input id="txtsOther" name="sOther" class="easyui-textbox" style="width: 300px;"
                                    />
                            </td>
                        </tr>
                        <tr>
                            <td height="40">
                                转让方坐落
                            </td>
                            <td>
                                <input type="text" name="sLocated" id="txtsLocated" class="easyui-textbox" style="width: 300px;" />
                            </td>
                        </tr>
                        <tr>
                            <td height="40">
                                转让方拟转出面积
                            </td>
                            <td>
                                <input type="text" name="sOutArea" id="txtsOutArea" class="easyui-textbox" style="width: 300px;" />
                            </td>
                        </tr>
                        <tr>
                            <td height="40">
                                转让方拟转出年限
                            </td>
                            <td>
                                <input type="text" name="sDeadline" id="txtsDeadline" class="easyui-textbox" style="width: 300px;" />
                            </td>
                        </tr>
                        <tr>
                            <td height="40">
                                转让方拟转出方式
                            </td>
                            <td>
                                <input type="text" name="sOutWay" id="txtsOutWay" class="easyui-textbox" style="width: 300px;" />
                            </td>
                        </tr>
                        <tr>
                            <td height="40">
                                转让方挂牌时间
                            </td>
                            <td>
                                <input type="text" name="sListedData" id="txtsListedData" class="easyui-datebox"
                                    style="width: 300px;" />
                            </td>
                        </tr>
                        <tr>
                            <td height="40">
                                转让方是否再次转出
                            </td>
                            <td>
                                <input type="text" name="sOutAgain" id="txtsOutAgain" class="easyui-textbox" style="width: 300px;" />
                            </td>
                        </tr>
                        <tr>
                            <td height="40">
                                转让方交易方式
                            </td>
                            <td>
                                <input type="text" name="sTransactions" id="txtsTransactions" class="easyui-textbox"
                                    style="width: 300px;" />
                            </td>
                        </tr>
                        <tr>
                            <td height="40">
                                转让方标是否存在 抵押、封查等情况
                            </td>
                            <td>
                                <input type="text" name="sIsMorSeal" id="txtsIsMorSeal" class="easyui-textbox" style="width: 300px;" />
                            </td>
                        </tr>
                        <tr>
                            <td height="40">
                                转让方挂牌价格
                            </td>
                            <td>
                                <input type="text" name="sListingPrice" id="txtsListingPrice" class="easyui-textbox"
                                    style="width: 300px;" />
                            </td>
                        </tr>
                        <tr>
                            <td height="40">
                                转让方联系方式电话
                            </td>
                            <td>
                                <input type="text" name="sCenterContact" id="txtsCenterContact" class="easyui-textbox"
                                    style="width: 300px;" />
                            </td>
                        </tr>
                        <tr>
                            <td height="40">
                                转让方项目联系方式
                            </td>
                            <td>
                                <input type="text" name="sProContact" id="txtsProContact" class="easyui-textbox"
                                    style="width: 300px;" />
                            </td>
                        </tr>
                        <tr>
                            <td height="40">
                                转让方结算方式
                            </td>
                            <td>
                                <input type="text" name="sSettlement" id="txtsSettlement" class="easyui-textbox"
                                    style="width: 300px;" />
                            </td>
                        </tr>
                    </table>
                </div>
                <table class="tb" border="0px" cellpadding="0" cellspacing="0">
                    <tr>
                        <td style="width: 100px" height="40">
                            备注
                        </td>
                        <td>
                            <textarea name="Remark" rows="5" wrap="physical" id="txtRemark"
                                 cols="55"></textarea>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="2" height="40">
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
    <div id="orgList" class="easyui-window" title="选择组织单位代码" collapsible="false" minimizable="false"
        maximizable="false" icon="icon-save" style="width: 250px; height: 400px; padding: 5px;
        background: #fafafa;">
        <ul id="tree" class="tree">
        </ul>
    </div>
</body>
</html>
