<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="MemberReg.aspx.cs" Inherits="Web.website.MemberReg" %>
<%@ Register Src="LeftInfo0.ascx" TagName="LeftInfo0" TagPrefix="uc3" %>
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

.wrap-right{
	float: right;
	width: 735px;
	height: auto !important;
	min-height: 385px;
	height: 385px;
}
.content{
	border: 1px solid #c3c3c3;
	/*background: #f7f7f7;*/
	min-height:460px;
}
.content-title{
	border-bottom: 1px solid #3198e8;
	height: 33px;
	text-align: left;
	line-height: 33px;
	position: relative;
}
.content-title h4{
	display: inline;
	padding-left: 15px;
	color: #3198e8;
	font-size: 15px;
	font-weight: 100;
}
.content-title span{
	position: absolute;
	right: 15px;
	_line-height:25px;
	line-height: 28px;
}
.content-title span a{
	padding: 0px 5px;
}
.content-list{
	width: 720px;
	margin: 10px auto;
	text-align: left;
}
.info-search input{
	vertical-align: middle;
	width: 150px;
	height: 20px;
	line-height: 20px;
	border: 1px solid #c3c3c3;
}
.info-search input.searchbtn{
	width: 85px;
	height: 24px;
	margin-left: 20px;
	background: url(../images/btn.png) no-repeat;
	border: 0px;
	color: #fff;
	line-height: 24px;
	cursor: pointer;
}

.list-news{
	width: 700px;
	margin: 10px auto;
}
.index-news li,.list-news ul li{
	line-height: 30px;
	border-bottom: 1px dotted #ccc;
	font-size: 13px;
	background: url(../images/icon_1.png) no-repeat 2px 9px;
	padding-left: 15px;
	height: 30px;
	overflow:hidden;
}
.index-news li span,.list-news ul li span{
	float: right;
	padding-right: 5px;
}
.index-news{
	padding-top: 8px;
	width: 355px;
	height: 155px;
	overflow: hidden;
	margin-bottom: 10px;
}
.index-news li{
	line-height: 26px;
	border:0px;
	background-position: 2px 7px;
	font-size: 12px;
	text-align: left;
}
.index-news li span{
	color: #aeaeae;
	padding-right: 8px;
}
p.more{
	text-align: right;
	padding-right: 10px;
}
.page{
	text-align: center;
}
.page span{
	padding: 0px 5px;
}
.page a{
	padding: 0px 8px;
}
.page input{
	margin: 0px 5px;
	width: 25px;
	height: 20px;
}

.content-list h3{
	height: 35px;
	border-bottom: 1px solid #ccc;
	line-height: 35px;
	text-align: center;
	font-size: 16px;
}
.content-list h3.no-line{border: 0px;}
.content-list1 h3{
	height: 35px;
	border-bottom: 1px solid #ccc;
	line-height: 35px;
	text-align: center;
	font-size: 16px;
}
.content-list1 h3.no-line{border: 0px;}
.content-list h4{
	height: 20px;
	border-bottom: 1px solid #ccc;
	line-height: 20px;
	text-align: center;
	font-size: 14px;
}
.content-list p.p-span{
	text-align: center;
	line-height: 20px;
	padding: 5px 0px;
}
.content-list p.p-span span{
	padding: 0px 10px;
}
.content-list p.p-con{
	text-indent: 2em;
	line-height: 20px;
	padding: 0px 40px;
}
.content-list table{
	font-size: 12px;
	border-collapse: collapse;
}
.content-list1 table{
	font-size: 12px;
	border-collapse: collapse;
}
.content-list1 table th{
	border:1px solid #ccc;
	padding: 3px 0px;
}
.content-list1 table td{
	padding: 2px 5px;
	border: 1px solid #ccc;
	border-collapse: collapse;
	padding: 3px 2px;
}
.content-list table td{
	padding: 2px 5px;
	border: 1px solid #fff;
	border-collapse: collapse;
}
.content-list table td input{
	margin-right: 3px;
}
.content-list table td .name{
	border: 1px solid #ccc;
}
.content-list table td table.govmember td{
	font-size: 12px;
	border: 0px;
	padding: 0px;
}
.content-list1 table td input{
	margin-right: 3px;
}
.content-list1 table td .name{
	border: 1px solid #ccc;
}
.content-list1 table td table.govmember td{
	font-size: 12px;
	border: 0px;
	padding: 0px;
}
.content-list table td table.govmember td div{line-height: 20px;}
.content-list1 table td table.govmember td div{line-height: 20px;}
.content-list table td table.govmember td div span{
	font-weight: bold;
	line-height: 20px;
	color: #3198e8;
	cursor:pointer;
}
.content-list1 table td table.govmember td div span{
	font-weight: bold;
	line-height: 20px;
	color: #3198e8;
	cursor:pointer;
}
.content-list1 table.BYZ_infotab td{
	border:0px;
}
input.captcha{
	width: 40px;
}


.info-content{
	width: 700px;
	margin: 0px auto;
}
/*.info-content p{
	text-indent: 2em;
	line-height: 2em;
}
*/p.next{
	border-top: 1px solid #ccc;
	padding: 10px 0px 0px 5px;
	margin-top: 10px;
}
p.next span{
	display: block;
	line-height: 20px;
	color: #F00;
}
.no-gray{
	color:#999;
}

/*index*/
.index-left{
	float: left;
	width: 735px;
	height: 916px;
	overflow: hidden;
}
.left-wrap{
	width: 735px;
	height: 239px;
	overflow: hidden;
}
.news-img{
	float: left;
	width: 366px;
	height: 237px;
	border: 1px solid #a1a1a1;
	overflow: hidden;
	text-align: center;
}
.news-img img{
	width: 358px;
	height: 228px;
}
.news-list{
	float: right;
	width: 358px;
	border: 1px solid #c3c3c3;
	height: 237px;
	overflow: hidden;
	background: #fff;
}
.index-second{
	width: 733px;
	border: 1px solid #c3c3c3;
	height: 198px;
	overflow: hidden;
	margin-top: 8px;
	background: #f7f7f7;
}
.index-icon{
	position: relative;
}
.index-icon h4{
	padding-left: 30px;
	display: block;
}
.index-icon h4 a{color:#3198e8;font-size: 15px;}
.icon1 h4{
	background: url(../images/icon1.png) no-repeat 7px 8px;
}
.icon2 h4{
	background: url(../images/icon1.png) no-repeat 7px -24px;
}
.icon3 h4{
	background: url(../images/icon1.png) no-repeat 7px -53px;
}
.icon4 h4{
	background: url(../images/icon1.png) no-repeat 7px -83px;
}
.icon5 h4{
	background: url(../images/icon1.png) no-repeat 7px -114px;
}
.index-icon span{
	position: absolute;
	right: 5px;
	top: 7px;
}
.index-icon span.index-zi{
	top: 3px;
}
.index-icon span.index-zi a{
	border: 1px solid #ccc;
	color: #ccc;
	padding: 3px 2px 2px 2px;
}

.second{
	width: 733px;
	height: 164px;
	overflow: hidden;
}
.second-left{
	float: left;
	width: 208px;
	height: 161px;
	overflow: hidden;
	background: url(../images/second-left.png) no-repeat left;
	text-align: right;
	padding-top: 3px;
}
.second-left p{
	background: url(../images/second-leftbg.png) no-repeat;
	width: 100px;
	height: 20px;
	margin: 0px auto;
	margin-right: 5px;
	margin-top: 10px;
	text-align: center;
	line-height: 20px;
	overflow: hidden;
}
.second-left p a{
	color: #fff;
}
.second-right{
	width: 152px;
	height: 109px;
	border: 8px solid #e2d3e5;
	float: left;
	position: relative;
	z-index: 0;
	text-align: center;
	margin: 14px 7px 0px 0px;
}
.second-right p{
	font-size: 14px;
	font-family: "微软雅黑";
}
p.second-list{
	background: url(../images/second-list.jpg) no-repeat;
	width: 117px;
	height: 26px;
	line-height: 26px;
	margin: 0px auto;
	margin-top: 6px;
}
p.second-R-last{
	position: absolute;
	bottom: -20px;
	left: 17px;
	z-index: 999;
	background: url(../images/second.jpg) no-repeat;
	width: 118px;
	height: 28px;
	margin: 0px auto;
	line-height: 27px;
	font-weight: bold;
	overflow: hidden;
}
.second-purple{
	border-color: #c7c9e9;
}
.second-purple p.second-R-last{
	background: url(../images/purple.jpg) no-repeat;
}
.second-green{
	border-color: #d7e9c7;
}
.second-green p.second-R-last{
	background: url(../images/green.jpg) no-repeat;
}

.index-three{
	width: 735px;
	height: 275px;
	overflow: hidden;
	margin-top: 8px;
	
}
.three-left{
	float: left;
	width: 223px;
	height: 273px;
	overflow: hidden;
	border: 1px solid #c3c3c3;
	background: #f7f7f7;
}
.three-left-cont{
	text-align: left;
	padding: 9px 9px;
}
.three-left-cont p{
	line-height: 28px;
	color: #2a2a2a;
}
.three-right{
	float: right;
	width: 498px;
	border: 1px solid #c3c3c3;
	height: 273px;
}
p.three-right-list{
	position: absolute;
	top: 10px;
	right: 0px;
	width: 405px;
	text-align: right;
}
p.three-right-list span{
	color: #3198e8;
	margin: 0px 1px;
	float: left;
	display: block;
	width: 65px;
	height: 23px;
	line-height: 23px;
	text-align: center;
	position: static;
	cursor: pointer;
}
p.three-right-list span.a-active{
	background: url(../images/office.jpg) no-repeat;
	color: #fff;
}

.office{
	width: 498px;
	height: 239px;
	overflow: hidden;
}
.office-img{
	margin: 4px 9px;
	background: url(../images/office1.jpg) no-repeat;
	width: 480px;
	height: 73px;
	position: relative;
}
.office-name{
	position: absolute;
	top: 8px;
	left: 40px;
	font-size: 30px;
	font-family: "微软雅黑";
}
.office p{
	line-height: 28px;
	text-indent:2em;
	text-align: left;
	padding: 5px 0px 0px 10px;
}
.index-four{
	height: 172px;
}
.ask{
	width: 733px;
	height: 138px;
	overflow: hidden;
}
.ask-left,.ask-right{
	float: left;
	width: 366px;
	height: 138px;
	overflow: hidden;
	position: relative;
}
.ask-left span,.ask-right span{
	width: 20px;
	height: 60px;
	position: absolute;
	left: 13px;
	top: 23px;
	color: #3a5d91;
	font-size: 14px;
	font-family: "微软雅黑";
}
.ask-left table,.ask-right table{
	width: 290px;
	color: #4a4a4a;
	margin: 15px 10px 0px 0px;
}
.ask-left table th,.ask-right table th{
	height: 22px;
}
.ask-left table td,.ask-right table td{
	height: 22px;
	line-height: 18px;
}
.ask-ge{
	float: left;
	width: 1px;
	background: #d8d8d8;
	height: 118px;
	margin-top: 10px;
}
.ask-right{
	float: right;
}
.index-right{
	float: right;
	width: 233px;
	height: 916px;
	overflow: hidden;
}
.index-right-title{
	background: url(../images/left-titlebg.png) no-repeat;
	line-height: 35px;
	color: #fff;
	padding-left: 17px;
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
                                    <img src="Images/indexlist_13.gif"  /> 您当前所在的位置：网站首页 >>&nbsp; 会员中心 >>&nbsp;会员注册
                              </td>
                            </tr>
                            <tr>
                                <td style="height: 5px;border-left: 6px solid #f6f6f6;border-right: 6px solid #f6f6f6; text-align:center">
                                <hr style="color:#fa8900; width:96%"/>
                                </td>
                            </tr>
                            <tr>
                                <td class="content-list" style="height: 778px; vertical-align: top;text-align: left;">
                                     <TABLE class=messageboard cellSpacing=0 cellPadding=0 width=720 
            align=left>
              <TBODY>
              <TR>
                <TH colSpan=4 align=middle><FONT size=4>会员信息</FONT></TH></TR>
              <TR>
                <TH width=140 noWrap align=right><SPAN 
                  style="COLOR: red">*</SPAN>会员姓名：</TH>
                <TD width=220><INPUT style="WIDTH: 95%" id=mem_name  runat="server"
                  class="easyui-textbox easyui-validatebox" maxLength=20 
                  type=text name=mem_name data-options="required:true"> </TD>
                <TH width=140 noWrap align=right>会员性别：</TH>
                <TD width=220>
                    <asp:DropDownList ID="ddlsex" runat="server">
                        <asp:ListItem>男</asp:ListItem>
                        <asp:ListItem>女</asp:ListItem>
                    </asp:DropDownList>
                    &nbsp;&nbsp;</TD></TR>
              <TR>
                <TH noWrap align=right><SPAN 
                style="COLOR: red">*</SPAN>登陆账号：</TH>
                <TD><INPUT style="WIDTH: 95%" id=mem_account  runat="server"
                  class="easyui-textbox easyui-validatebox" maxLength=20 
                  type=text name=mem_account  data-options="required:true"> 
                </TD>
                <TH noWrap align=right><SPAN 
                style="COLOR: red">*</SPAN>身份证号：</TH>
                <TD><INPUT style="WIDTH: 95%" id=mem_card runat="server"
                  class="easyui-textbox easyui-validatebox" maxLength=20 
                  type=text name=mem_card 
                  data-options="required:true,validType:'idcard'"> </TD></TR>
              <TR>
                <TH noWrap align=right><SPAN 
                style="COLOR: red">*</SPAN>登录密码：</TH>
                <TD><INPUT style="WIDTH: 95%" id=mem_password runat="server"
                  class="easyui-textbox easyui-validatebox" maxLength=20 
                  type=password name=mem_password data-options="required:true" 
                  validType="safepass"> </TD>
                <TH noWrap align=right><SPAN 
                style="COLOR: red">*</SPAN>确认密码：</TH>
                <TD><INPUT style="WIDTH: 95%" id=con_password runat="server"
                  class="easyui-textbox easyui-validatebox" maxLength=20 
                  type=password name=con_password data-options="required:true" 
                  validType="safepass&amp;equals['#mem_password']"> </TD></TR>
              <TR>
                <TH noWrap align=right>会员地址：</TH>
                <TD colSpan=3>
                    <INPUT style="WIDTH: 95%" id=men_address runat="server"
                  class="easyui-textbox easyui-validatebox" maxLength=20 
                   name=mem_password0 
                  >&nbsp;&nbsp; </TD></TR>
              <TR>
                <TH noWrap align=right><SPAN 
                style="COLOR: red">*</SPAN>联系电话：</TH>
                <TD><INPUT style="WIDTH: 95%" id=mem_phone runat="server"
                  class="easyui-textbox easyui-validatebox" maxLength=20 
                  type=text name=mem_phone data-options="required:true"> </TD>
                <TH noWrap align=right>会员邮箱：</TH>
                <TD><INPUT style="WIDTH: 95%" id=mem_email runat="server"
                  class="easyui-textbox easyui-validatebox" maxLength=35 
                  type=text name=mem_email validType="email"> </TD></TR>
              <TR>
                <TD colSpan=4 align=middle><INPUT id=agreement CHECKED 
                  type=checkbox name=agreement> 我已仔细阅读并同意<A 
                  style="COLOR: #005aa0" 
                  href="#" 
                  target=_blank>《农村产权交易中心会员注册协议》</A> </TD></TR>
              <TR>
                <TD style="HEIGHT: 76px; VERTICAL-ALIGN: middle" colSpan=4 
                align=middle>
                    <asp:Button ID="Button1" runat="server" Text="提     交" class=research-btn 
                        onclick="Button1_Click"   /> 
<INPUT style="PADDING-TOP: 0px" id=Reset class="research-btn research-btnresult" value="重 &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;置" type=reset name=Reset> 
                </TD></TR></TBODY></TABLE>
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
