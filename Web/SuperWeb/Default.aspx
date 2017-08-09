<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Web.SuperWeb.Default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>农村产权交易系统后台登陆首页</title>
    <link type="text/css" href="css/login.css" rel="stylesheet" />
</head>
<body oncontextmenu="return false" onselectstart="return false">
    <form id="form1" runat="server">
    <div id="login">
        <div id="login_header">
            <h1 class="login_logo">
                <img src="images/logo.png" />
            </h1>
            <div class="login_headerContent">
                <div class="navList">
                    <ul>
                    </ul>
                </div>
                <h2 class="login_title">
                </h2>
            </div>
        </div>
        <div id="login_content">
            <div class="loginForm">
                <p>
                    <label>
                        用户名：</label>
                    <asp:TextBox ID="txt_AdminLogName" runat="server" Style="width: 143px;"></asp:TextBox>
                </p>
                <p>
                    <label>
                        密码：</label>
                    <asp:TextBox ID="txt_AdminLogPass" runat="server" TextMode="Password" Style="width: 143px;"></asp:TextBox>
                </p>
                <p>
                    <label>
                        验证码：</label>
                    <asp:TextBox ID="txt_CheckCodeImg" runat="server" Width="40px"></asp:TextBox><img src="../Controls/ValidateCode.aspx" align="absmiddle" alt="看不清楚，单击图片换一张。" onclick="this.src = '../Controls/ValidateCode.aspx?flag=' + Math.random();document.getElementById('txt_CheckCodeImg').value='';"
                        border="0" />
                </p>
                <div class="login_bar">
                    <asp:Button ID="btn_login" runat="server" OnClick="btn_login_Click" CssClass="sub" />
                </div>
            </div>
            <div class="login_banner">
                <img src="images/login_banner.jpg" /></div>
            <div class="login_main">
                <ul class="helpList">
                    <li><a href="http://www.nongyou.com.cn" target="_blank">联系我们</a></li>
                </ul>
                <div class="login_inner">
                    <p>
                    </p>
                    <p>
                    </p>
                </div>
            </div>
        </div>
        <div id="login_footer">
            山东农友软件有限公司 研发
        </div>
    </div>
    </form>
</body>
</html>
