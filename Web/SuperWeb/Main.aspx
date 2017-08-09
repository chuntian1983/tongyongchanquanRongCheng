<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Main.aspx.cs" Inherits="Web.SuperWeb.Main" %>

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
    <script src="js/main.js" type="text/javascript" language="javascript"></script>
    <script src="js/JsConfig.js" type="text/javascript" language="javascript"></script>
</head>
<body class="easyui-layout" style="overflow-y: hidden" scroll="no" oncontextmenu="return false"
    onselectstart="return false">
    <noscript>
        <iframe scr="*.htm"></iframe>
    </noscript>
    <div region="north" split="true" border="false" style="overflow: hidden; height: 55px;
        background: #7f99be repeat-x center 50%; line-height: 20px; color: #fff; font-family: Verdana, 微软雅黑,黑体">
        <span style="float: right; padding-right: 20px;" class="head"><span id="v"></span>&nbsp;&nbsp;【<span id="lblclock"></span>】&nbsp;&nbsp;&nbsp;&nbsp;欢迎您
            <span id="lblUserName" style="color:Blue"></span>&nbsp;&nbsp;&nbsp;&nbsp;<a href="javascript:void(0)"
                id="loginOut" style="color: Red;">[安全退出]</a></span> <span style="padding-left: 10px;
                    font-size: 28px;">
                    <img src="images/logo.png" align="absmiddle" alt="山东农友软件有限公司" />
                    农村产权交易平台管理系统</span>
    </div>
    <div region="south" split="true" style="height: 30px; background: #D2E0F2;">
        <div class="footer">
            www.nongyou.com.cn © 山东农友软件有限公司&nbsp;&nbsp;研发
        </div>
    </div>
    <div region="west" split="true" title="系统菜单" style="width: 180px;" id="west">
        <div class="easyui-accordionl" fit="true" border="false">
        </div>
       
    </div>
    
    <div id="mainPanle" region="center" style="background: #eee; overflow-y: hidden;" >
    <div class="easyui-layout" data-options="fit:true">
   <%-- <div data-options="region:'west',collapsed:true"  style="width:1px" title=""></div>--%>
    <div data-options="region:'center'">
        <div id="tabs" class="easyui-tabs" fit="true" border="false">
            <div title="欢迎首页" style="padding: 20px; overflow: hidden; color:#4F688F; background-image: url(images/adminstart.jpg)"
                id="home">
            <h2>· 欢迎您使用山东农友软件有限公司农村产权交易平台管理系统!</h2>
			<br />
			<h1>· .NET Framework 版本：<%=FrameworkBersion %></h1>
            <h1>· 服务器运行时间：<%=runTime%></h1>
            <h1>· 您的客户端操作系统：<%=Platform%></h1>
            <h1>· 农村产权交易平台占用内存：<%=CmsRam%></h1>
            <h1>· 农村产权交易平台当前缓存数量：<%=CacheCount%></h1>
            </div>
        </div>
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
