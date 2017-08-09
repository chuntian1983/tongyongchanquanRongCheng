<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ShowNews.aspx.cs" Inherits="Web.website.ShowNews" %>

<%@ Register Src="LeftInfo0.ascx" TagName="LeftInfo0" TagPrefix="uc3" %>
<%@ Register Src="WebBottom.ascx" TagName="WebBottom" TagPrefix="uc2" %>
<%@ Register Src="WebHead.ascx" TagName="WebHead" TagPrefix="uc1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>荣成市农村产权交易平台</title>
    <style>
        body{ background-image:url('images/bodybj.jpg'); background-repeat:repeat-x;}
	a.class:link   {color:   #454545;} /*没点之前 */
a.class:visited   {color:   #454545;} /*点过之后 */
a.class:hover   {color:   #fbae1a;} /*鼠标移到上方 */
a.class:active   {color:   #fbae1a;} /*激活时 */
	    .style3
        {
            width: 200px;
        }
	</style>
    <link type="text/css" href="../Images/css.css" rel="Stylesheet" />
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
                                     <div style="width: 222px; border: 6px solid #fff; background:#fff">
                                            <uc3:LeftInfo0 ID="LeftInfo0_1" runat="server"></uc3:LeftInfo0>    
                                    </div>
	                          </td>
                                <td  valign="middle" style="height: 30px; border: 6px solid #f6f6f6; border-bottom: 0;padding-left:10px;font-size: 14px; text-align: left;">
                                    <img src="Images/indexlist_13.gif"  /> 您当前所在的位置：网站首页 >>&nbsp; <%=ClassName %> 
                              </td>
                            </tr>
                            <tr>
                                <td style="height: 5px;border-left: 6px solid #f6f6f6;border-right: 6px solid #f6f6f6; text-align:center">
                                <hr style="color:#fa8900; width:96%"/>
                                </td>
                            </tr>
                            <tr>
                                <td style="height: 778px; vertical-align: top; border: 6px solid #f6f6f6; border-top: 0;">
                                    <table cellpadding="0" cellspacing="0" style="width: 98%; height: 100%; margin-left: 5px;
                                        margin-top: 5px; text-align: left">
                                        <tr>
                                            <td height="41" style="height: 35px; text-align: center; font-size: 20px">
                                                <strong>
                                                    <%=NewsTitle%>
                                                </strong>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td height="31" style="text-align: center; height: 25px; font-size: 10pt; color: Gray;
                                                border-bottom: 1px solid #cccccc">
                                                发布者：<%=AddUser %>&nbsp;&nbsp;&nbsp;&nbsp;发布时间：<%=AddTime %>&nbsp;&nbsp;&nbsp;&nbsp;信息来源：<%=NewsSource %>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="height: 15px">&nbsp;
                                                </td>
                                        </tr>
                                        <tr>
                                            <td style="height: 750px;padding:0 10px; line-height:25px; vertical-align: top; ">
                                                <%=Contents%>
                                                <br />
                                                <div id="Appendix" runat="server" style="color: Red; border-top: 1px solid #f6f6f6;
                                                    width: 100%;">
                                                </div>
                                            </td>
                                        </tr>
                                    </table>
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
