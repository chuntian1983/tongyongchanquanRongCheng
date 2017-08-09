<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Memberlogin.aspx.cs" Inherits="Web.website.memberlogin" %>
<%@ Register Src="WebBottom.ascx" TagName="WebBottom" TagPrefix="uc2" %>
<%@ Register Src="WebHead.ascx" TagName="WebHead" TagPrefix="uc1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">


<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>荣成市农村产权交易平台</title>
 
  
    
   
    <style>
        body{ background-image:url('images/bodybj.jpg'); background-repeat:repeat-x;}
      ul,dl{ 
	list-style-image:none;
	list-style-position:outside;
	list-style-type:none;
	
}
ul 
{
    margin:0;
    padding:0;
    }

.content-list {
	TEXT-ALIGN: left; MARGIN: 10px auto; WIDTH: 720px
}
TABLE.messageboard TD {
	PADDING-BOTTOM: 5px; PADDING-LEFT: 5px; PADDING-RIGHT: 5px; PADDING-TOP: 5px
}
TABLE.messageboard TD INPUT[type=text] {
	BORDER-BOTTOM: #ccc 1px solid; BORDER-LEFT: #ccc 1px solid; PADDING-BOTTOM: 2px; PADDING-LEFT: 3px; PADDING-RIGHT: 3px; FONT-SIZE: 12px; BORDER-TOP: #ccc 1px solid; BORDER-RIGHT: #ccc 1px solid; PADDING-TOP: 2px
}
TABLE.messageboard TD TEXTAREA {
	BORDER-BOTTOM: #ccc 1px solid; BORDER-LEFT: #ccc 1px solid; PADDING-BOTTOM: 2px; PADDING-LEFT: 3px; PADDING-RIGHT: 3px; FONT-SIZE: 12px; BORDER-TOP: #ccc 1px solid; BORDER-RIGHT: #ccc 1px solid; PADDING-TOP: 2px
}
TABLE.messageboard TD INPUT.captcha {
	WIDTH: 40px
}
TABLE.messageboard TD TEXTAREA {
	WIDTH: 460px
}
	a.class:link   {color:   #454545;} /*没点之前 */
a.class:visited   {color:   #454545;} /*点过之后 */
a.class:hover   {color:   #fbae1a;} /*鼠标移到上方 */
a.class:active   {color:   #fbae1a;} /*激活时 */
	    .style3
        {
            width: 233px;
        }
        /*news*/
.wrap-left{
	float: left;
	width: 233px;
}
.left-list{
	background: url(images/left-bg.jpg) repeat;
	width: 233px;
	padding-bottom: 8px;
}
.pt15{padding-top: 15px;}
.left-title{
	height: 53px;
	color: #0390ea;
	font-size: 24px;
	font-family: "微软雅黑";
	padding-left: 80px;
	text-align: left;
	line-height: 53px;
	margin-bottom: 10px;
	background: url(images/cq014.png) no-repeat 20px 50%;
}
.left-title-query{
	height: 30px;
	color: #0390ea;
	font-size: 18px;
	font-family: "微软雅黑";
	background-color:#E5E5E5;
	text-align: center;
	line-height: 30px;
	margin-bottom: 5px;
}
.left-list ul{
	width: 200px;
	display: block;
	margin-left: 18px;
	_margin-left: 8px;
}
.left-list ul li{
	height: 38px;
	background: url(../website/images/left-listbg.jpg) no-repeat;
	line-height: 38px;
	margin-bottom: 8px;
	text-align: left;
	padding-left: 20px;
}
.left-img{
	margin-top: 10px;
	width: 233px;
}
table{padding: 0px;
color: #666;
margin-right: 0px;
margin-bottom: 0px;
margin-left: 0px;}
.messageboard
{
    font-size: 12px;
border-collapse: collapse;

    }
 .login-title
 {
     height: 40px;
font-family: "微软雅黑";
width: 380px;
padding-top: 15px;
margin-bottom: 30px;
     }





	</style>
   
<script language="javascript" type="text/javascript">



</script>
</head>
<body style="margin: 0px; text-align: center">
    <form id="form1" runat="server">
        <div style=" width:1000px; margin:0 auto;">
            <uc1:WebHead ID="WebHead1" runat="server" />
            <table border="0" cellpadding="0" cellspacing="0" style="margin-top: 3px; width: 1000px;">
                <tr>
                    <td style=" vertical-align: top">
                        <table cellpadding="0" cellspacing="0" style="width: 100%; height: 100%; margin-top: 5px">
                            <tr>
                                <td rowspan="3" align="left" valign="top" style="vertical-align: top; " 
                                    class="style3">
                                    <div class="wrap-left">
   	<div class="left-list pt15">
   		<div class="left-title">会员中心</div>
       	<ul>
           <li><a href="#">会员简介</a></li>
           	<li><a href="#">会员须知</a></li>
           	
           	<li><a href="memberlogin.aspx">会员登录</a></li>
           	<li><a href="memberreg.aspx">会员注册</a></li>
        </ul>
    </div>
</div>  
	                          </td>
                                <td  valign="middle" style="height: 30px; border: 6px solid #f6f6f6; border-bottom: 0;padding-left:10px;font-size: 14px; text-align: left;">
                                    <img src="Images/indexlist_13.gif"  /> 您当前所在的位置：网站首页 >>&nbsp; 会员中心 >>&nbsp;会员登录
                              </td>
                            </tr>
                            <tr>
                                <td style="height: 5px;border-left: 6px solid #f6f6f6;border-right: 6px solid #f6f6f6; text-align:center">
                                <hr style="color:#fa8900; width:96%"/>
                                </td>
                            </tr>
                            <tr>
                                <td class="content-list" style="height: 778px; vertical-align: top;text-align: left;">
                                <DIV 
            style="MARGIN: 50px auto 0px; PADDING-LEFT: 30px; WIDTH: 399px; BACKGROUND: url(images/login_bg.jpg) no-repeat; HEIGHT: 262px; VERTICAL-ALIGN: middle; PADDING-TOP: 0px" 
            class=content-list>
            <div class="login-title">

    <h4>会员登录</h4>

</div>
                                     <TABLE class=messageboard border=0 cellSpacing=0 cellPadding=0 
            width="70%" align=left>
              <TBODY>
              <TR>
                <TH align=right>用户名：</TH>
                <TD>
                    <asp:TextBox ID="txtusername" runat="server" Width=200></asp:TextBox> </TD></TR>
              <TR>
                <TH align=right><SPAN 
                  style="LETTER-SPACING: 1em; MARGIN-RIGHT: -1em">密码</SPAN>：</TH>
                <TD>
                    <asp:TextBox ID="txtpass" Width=200 TextMode=Password runat="server"></asp:TextBox> </TD></TR>
              <TR>
                <TH align=right>验证码：</TH>
                <TD>
                  <asp:TextBox ID="txt_CheckCodeImg" runat="server" Width="40px"></asp:TextBox><img src="../Controls/ValidateCode.aspx" align="absmiddle" alt="看不清楚，单击图片换一张。" onclick="this.src = '../Controls/ValidateCode.aspx?flag=' + Math.random();document.getElementById('txt_CheckCodeImg').value='';"
                        border="0" /></TD></TR>
              <TR>
                <TD colSpan=2 align=middle>
                    <asp:Button ID="Button1" runat="server" Text="登录" onclick="Button1_Click" />
                  &nbsp;&nbsp; <A 
                  style="COLOR: #5abfdb; VERTICAL-ALIGN: bottom; TEXT-DECORATION: underline" 
                  href="MemberReg.aspx">会员注册</A> 
                </TD></TR></TBODY></TABLE>                </DIV>
                                </td>
                            </tr>
                           
                        </table>
                    </td>
                </tr>
            </table>
            <uc2:WebBottom ID="WebBottom1" runat="server" />
        </div>
    </form>
</body>
</html>
