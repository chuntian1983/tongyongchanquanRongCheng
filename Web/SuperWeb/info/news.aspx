<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="news.aspx.cs" Inherits="Web.SuperWeb.info.news" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>新闻信息</title>
    <link href="../js/easyUI/themes/default/easyui.css" rel="stylesheet" type="text/css" />
    <link href="../css/default.css" rel="stylesheet" type="text/css" />
    <link href="../js/easyUI/themes/icon.css" rel="stylesheet" type="text/css" />
     <link href="../css/zTreeStyle.css" rel="stylesheet" type="text/css" />
    <link href="../css/myCss.css" rel="stylesheet" type="text/css" />
    <script src="../js/easyUI/jquery.min.js" type="text/javascript" language="javascript"></script>
    <script src="../js/easyUI/jquery.easyui.min.js" type="text/javascript" language="javascript"></script>
    <script src="../js/easyUI/locale/easyui-lang-zh_CN.js" type="text/javascript" language="javascript"></script>
     <script src="../js/jquery.ztree-2.6.min.js" type="text/javascript" language="javascript"></script>
    <script charset="utf-8" src="../../kindeditor/kindeditor-min.js" type="text/javascript"
        language="javascript"></script>
    <script src="../js/JSConfig.js" language="javascript" type="text/javascript"></script>
    <script src="../js/JSControl.js" language="javascript" type="text/javascript"></script>
    <script src="../js/news.js" language="javascript" type="text/javascript"></script>
</head>
<body class="easyui-layout" style="overflow-y: hidden" scroll="no" oncontextmenu="return false" onselectstart="return false">
    <div region="north" title="新闻信息搜索" split="true" style="height: 60px; overflow: hidden;
        border: 0px;" border="false">
       &nbsp;新闻标题：
        <input type="text" id="tNewsTitle" class="easyui-textbox" style=" width:300px;" required="required" />
        &nbsp;新闻类型：<input id="cbnewstype" class="easyui-combobox" style=" width:80px;" name="cbnewstype"   
    data-options="valueField:'id',textField:'text',url:'../ashx/newstype.ashx?action=list'" />  
        <a href="javascript:void(0)" id="btnQuery" class="easyui-linkbutton" iconcls="icon-search">
            新闻搜索</a>
    </div>
    <div region="center">
        <div id="mainCenter" style="width: 100%; height: 100%;">
            <table id="tdg">
            </table>
        </div>
        <div id="newsEdit" style="display:none; width: 100%; height: 100%; overflow: hidden;">
            <div class="easyui-panel" title="新闻详细信息" style="width: 100%; height: 97%;">
                <div class="easyui-linkbutton" iconcls="icon-redo">
                    <a href="javascript:void(0);" id="areturn">返回新闻列表</a>
                </div>
                <br />
                <form id="formNews" runat="server">
                <table class="table" border="0px" cellpadding="0" cellspacing="0">
                    <tr>
                        <td style="width: 80px" height="43">
                            新闻标题<span style="color: Red;">*</span>
                        </td>
                        <td>
                            <input type="text" name="NewsTitle" id="txtNewsTitle" maxlength="100" class="easyui-textbox"
                                style="width: 300px;" required="true" />
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 80px" height="43">
                            新闻类型代码<span style="color: Red;">*</span>
                        </td>
                        <td>
                            <input id="txtNewsTypeId" name="NewsTypeId" class="easyui-textbox" style="width: 100px;"
                                required="true" readonly="readonly" />&nbsp;&nbsp; <a href="javascript:void(0);"
                                    id="btnNewsType">请选择</a>
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 80px" height="43">
                            组织单位代码<span style="color: Red;">*</span>
                        </td>
                        <td>
                            <input id="txtUnitCode" name="UnitCode" class="easyui-textbox" style="width: 100px;"
                                required="true" readonly="readonly" />&nbsp;&nbsp; <a href="javascript:void(0);"
                                    id="btnUnitCode">请选择</a>
                        </td>
                    </tr>
                    <tr>
                        <td height="43">
                            新闻副标题
                        </td>
                        <td>
                            <input type="text" name="NewsSubheading" id="txtNewsSubheading" class="easyui-textbox"
                                style="width: 300px;" />
                        </td>
                    </tr>
                    <tr>
                        <td height="43">
                            新闻来源
                        </td>
                        <td>
                            <input type="text" id="txtNewsSource" name="NewsSource" maxlength="50" value="" class="easyui-textbox"
                                style="width: 300px;" />
                        </td>
                    </tr>
                    <tr>
                        <td height="43">
                            摘要
                        </td>
                        <td>
                            <input name="Content" type="text" id="txtContent" maxlength="50" class="easyui-textbox"
                                style="width: 300px;" />
                        </td>
                    </tr>
                    <tr>
                        <td height="43">
                            关键字
                        </td>
                        <td>
                            <input name="Keyword" type="text" id="txtKeyword" maxlength="50" class="easyui-textbox"
                                style="width: 300px;" />
                        </td>
                    </tr>
                    <tr>
                        <td height="43">
                            新闻图片
                        </td>
                        <td>
                            <input name="NewsImg" type="file" id="fileNewsImg" onchange="OnCheckImg('fileNewsImg');"  runat="server" 
                                style="width: 300px;"/>
                        </td>
                    </tr>
                    <tr>
                        <td height="43">
                            是否热点新闻
                        </td>
                        <td>
                            
                            <select id="txtIfHost" name="IfHost" class="easyui-combobox" style="width: 50px;" >
                                <option value="0" selected="selected">否</option>
                                <option value="1">是</option>
                            </select>
                        </td>
                    </tr>
                    <tr>
                        <td height="43">
                            是否置顶
                        </td>
                        <td>
                            <select id="txtIfUp" name="IfUp" class="easyui-combobox" style="width: 50px;" >
                                <option value="0" selected="selected">否</option>
                                <option value="1">是</option>
                            </select>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            新闻内容<span style="color: Red;">*</span>
                        </td>
                        <td>
                            <!--开始HTML编辑器-->
                            <textarea name="NewsContent" id="txtNewsContent" cols="80" rows="8" style="width: 700px;
                                height: 300px; visibility: hidden;"  ></textarea>
                            <!--结束-->
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
    <div id="newtype" class="easyui-window" title="选择新闻类型" collapsible="false" minimizable="false"
        maximizable="false" icon="icon-save" style="width: 200px; height: 400px; padding: 5px;
        background: #fafafa;">
        <ul id="type" class="tree">
        </ul>
    </div>
</body>
</html>
