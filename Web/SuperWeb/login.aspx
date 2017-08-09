<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="login.aspx.cs" Inherits="Web.SuperWeb.login" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html>
<head>

<meta charset="utf-8" >
<title>登录</title>

<link href="images/login.css" rel="stylesheet" type="text/css">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8">
<meta name="viewport" content="width=device-width, user-scalable=no, initial-scale=1.0; maximum-scale=1.0; user-scalable=0;">



<!--[if lt IE 9]> 
<script src="images/css3-mediaqueries.js"></script> 
<![endif]--> 
<style>
    .sub { display:block; width:75px; height:30px; border:none; background:url(../images/login_sub.png) no-repeat; cursor:pointer;}
</style>
</head>

<body class="by">
<form id="form1" runat="server">
   <div class="bgtop ">

      <!--���ⲿ��-->
	   <div class="topt topt-img-top">
       <span class="write">登录管理</span></br>
	   <span class="orage">农村产权交易系统</span>
	   </div>
      <!--���岿��-->
      <div class="mian">
	     
	       <ul>
		      <li>用户账号<asp:TextBox ID="txt_AdminLogName" runat="server" ></asp:TextBox></li>
			  <li>登陆密码<asp:TextBox ID="txt_AdminLogPass" runat="server" TextMode="Password" ></asp:TextBox></li>
			  <li>验证码<asp:TextBox ID="txt_CheckCodeImg" runat="server" ></asp:TextBox><img src="../Controls/ValidateCode.aspx" align="absmiddle" alt="看不清楚，单击图片换一张。" onclick="this.src = '../Controls/ValidateCode.aspx?flag=' + Math.random();document.getElementById('txt_CheckCodeImg').value='';"
                        border="0" /></li>
			  <li><asp:Button ID="btn_login" runat="server" OnClick="btn_login_Click" CssClass="input1" /></li>
		   </ul>
	  </div>
   


</div></form>
</body>
</html>
