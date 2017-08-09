<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="UserMain.aspx.cs" Inherits="Web.SuperWeb.UserMain" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>农村产权交易平台管理系统</title>
    <link href="js/easyUI/themes/default/easyui.css" rel="stylesheet" type="text/css" />
    <link href="css/default.css" rel="stylesheet" type="text/css" />
    <link href="js/easyUI/themes/icon.css" rel="stylesheet" type="text/css" />
    <script src="js/easyUI/jquery.min.js" type="text/javascript" language="javascript"></script>
    <script src="js/easyUI/jquery.easyui.min.js" type="text/javascript" language="javascript"></script>
    <script src="js/easyUI/locale/easyui-lang-zh_CN.js" type="text/javascript" language="javascript"></script>
    <script src="js/usermain.js" type="text/javascript" language="javascript"></script>
    <script src="js/JsConfig.js" type="text/javascript" language="javascript"></script>
</head>
<body class="easyui-layout" style="overflow-y: hidden" scroll="no" oncontextmenu="return false"
    onselectstart="return false">
    <noscript>
        <iframe scr="*.htm"></iframe>
    </noscript>
    <div region="north" split="true" border="false" style="overflow: hidden; height: 55px;
        background: #7f99be repeat-x center 50%; line-height: 20px; color: #fff; font-family: Verdana, 微软雅黑,黑体">
        <span style="float: right; padding-right: 20px;" class="head"><span id="v"></span>&nbsp;&nbsp;欢迎会员：
            <asp:Label ID="lbhy" runat="server" Text=""></asp:Label> <a href="javascript:void(0)" id="loginOut" style="color: Red;">安全退出</a></span>
        <span style="padding-left: 10px; font-size: 28px;">
            <img src="images/logo.png" align="absmiddle" alt="山东农友软件有限公司" />
            农村产权交易平台管理系统</span>
    </div>
    <div region="south" split="true" style="height: 30px; background: #D2E0F2;">
        <div class="footer">
            www.nongyou.com.cn © 山东农友软件有限公司&nbsp;&nbsp;研发
        </div>
    </div>
    <div region="west" split="true" title="系统菜单" style="width: 180px;" id="west">
        <div class="easyui-accordion" fit="true" border="false">
            <!--  导航内容 -->
            
            
            <div title="会员信息管理" data-options="iconCls:'icon-reload'">
                
                <ul>
                    <a href="javascript:void(0);" onclick="OnOpenNewPageLoadTab('info/SuDemand.aspx','供应需求','icon-reload');">
                        <span class="icon-reload">&nbsp;&nbsp&nbsp;&nbsp</span><span>供求需求</span> </a>
                </ul>
               
            </div>
            
           
            <!---->
        </div>
    </div>
    <div id="mainPanle" region="center" style="background: #eee; overflow-y: hidden">
        <div id="tabs" class="easyui-tabs" fit="true" border="false">
            <div title="欢迎使用" style="padding: 20px; overflow: hidden; background-image: url(images/adminstart.jpg)"
                id="home">
                欢迎使用
            </div>
        </div>
    </div>
    <!--右键菜单-->
    <div id="mm" class="easyui-menu" style="width: 150px; display: none;">
        <div id="mm-tabclose">
            关闭</div>
        <div id="mm-tabcloseall">
            全部关闭</div>
        <div id="mm-tabcloseother">
            除此之外全部关闭</div>
        <div class="menu-sep">
        </div>
        <div id="mm-tabcloseright">
            当前页右侧全部关闭</div>
        <div id="mm-tabcloseleft">
            当前页左侧全部关闭</div>
        <div class="menu-sep">
        </div>
        <div id="mm-exit">
            退出</div>
    </div>
</body>
</html>
