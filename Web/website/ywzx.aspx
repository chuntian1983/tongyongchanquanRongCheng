<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ywzx.aspx.cs" Inherits="Web.website.ywzx" %>
<%@ Register Src="LeftInfo0.ascx" TagName="LeftInfo0" TagPrefix="uc3" %>
<%@ Register Src="WebBottom.ascx" TagName="WebBottom" TagPrefix="uc2" %>
<%@ Register Src="WebHead.ascx" TagName="WebHead" TagPrefix="uc1" %>
<%@ Register Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" TagPrefix="webdiyer" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
 <link href="../superweb/js/easyUI/themes/default/easyui.css" rel="stylesheet" type="text/css" />
    <link href="../SuperWeb/css/default.css" rel="stylesheet" type="text/css" />
    <link href="../SuperWeb/js/easyUI/themes/icon.css" rel="stylesheet" type="text/css" />
    <link href="../SuperWeb/css/myCss.css" rel="stylesheet" type="text/css" />
    <link href="../SuperWeb/css/zTreeStyle.css" rel="stylesheet" type="text/css" />
    <script src="../SuperWeb/js/easyUI/jquery.min.js" type="text/javascript" language="javascript"></script>
    <script src="../SuperWeb/js/easyUI/jquery.easyui.min.js" type="text/javascript" language="javascript"></script>
    <script src="../SuperWeb/js/easyUI/locale/easyui-lang-zh_CN.js" type="text/javascript" language="javascript"></script>
    <script src="../SuperWeb/js/jquery.ztree-2.6.min.js" type="text/javascript" language="javascript"></script>
    <script src="../SuperWeb/js/main.js" type="text/javascript" language="javascript"></script>
    <script src="../SuperWeb/js/JSConfig.js" language="javascript" type="text/javascript"></script>
    <script src="../SuperWeb/js/JSControl.js" language="javascript" type="text/javascript"></script>

    <title>荣成市农村产权交易平台</title>
    <style>
        .guapai{ width:100%;}
        .guapai th{ color:#3986E0; background-image:url('images/untitled.bmp'); background-repeat:repeat-x; text-align:center;}
        .guapai td{ text-align:center; line-height:30px;}
    </style>
</head>
<body style="margin: 0px; text-align: center;background-color:White;">
    <form id="form1" runat="server">
        <div style=" width:1000px; margin:0 auto;">
            <uc1:WebHead ID="WebHead1" runat="server" />
            <table border="0" cellpadding="0" cellspacing="0" style="margin-top: 3px;  width: 1000px;">
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
                                    <img src="Images/indexlist_13.gif"  /> 您当前所在的位置：网站首页 >>&nbsp;业务咨询
                              </td>
                            </tr>
                            <tr>
                                <td style="height: 5px;border-left: 6px solid #f6f6f6;border-right: 6px solid #f6f6f6; text-align:center">
                                <hr style="color:#fa8900; width:96%"/>
                                </td>
                            </tr>
                            <tr>
                                <td style=" background-color:White; vertical-align: top; border: 6px solid #f6f6f6; border-top: 0;">
                                    
              
                                                           <asp:Repeater runat=server ID="repgongying"><ItemTemplate>
                                                           <table class="table" border="0px" cellpadding="0" cellspacing="0" width="700" >
                                                           <tr><td colspan=4 style=" height:5px;"></td></tr>
                    <tr>
                        <td height="35" style=" width:180px;">
                            咨询人
                        </td>
                        <td height="35" style=" width:180px;">
                          <%#Eval("UserName")%></td>
                        <td height="35" style=" width:180px;">
                            咨询时间</td>
                        <td>
                             <%#Eval("ConsDate")%>
&nbsp;</td>
                    </tr>
                    <tr>
                        <td height="35">
                            咨询标题</td>
                        <td height="35" colspan="3">
                            &nbsp; <%#Eval("ConsTitle")%></td>
                    </tr>
                    <tr>
                        <td height="35">
                            回复人
                        </td>
                        <td height="35">
                            &nbsp; <%#Eval("ReplyUser")%></td>
                        <td height="35">
                            回复时间</td>
                        <td>
                             <%#Eval("ReplyDate")%>
                        </td>
                    </tr>
                    <tr>
                        <td height="35">
                            回复内容</td>
                        <td height="35" colspan="3">
                            &nbsp; <%#Eval("ReplyContent")%></td>
                    </tr>
                    </table>
                                                           </ItemTemplate></asp:Repeater>
                                                       
                                                            
                                                            <webdiyer:aspnetpager id="pg" runat="server" ShowBoxThreshold="5"
										ShowCustomInfoSection="Left" HorizontalAlign="Right" 
    OnPageChanged="Pager_PageChanged"  
    
    CustomInfoClass="pager-1"
    CustomInfoTextAlign="Left"  FirstPageText="首页" 
    LastPageText="尾页" NextPageText="下一页" PrevPageText="上一页" 
    CustomInfoHTML="数据：%RecordCount%条  第%CurrentPageIndex%/%PageCount%页 " 
     AlwaysShow=true PageIndexBoxClass=homeLogin PageSize=20 
       PageIndexBoxStyle="pagerindexbox" 
        PageIndexBoxType="TextBox" ShowPageIndexBox="Always" SubmitButtonText="Go" UrlPaging="false" 
     
     ></webdiyer:aspnetpager>
     <table class="table" border="0px" cellpadding="0" cellspacing="0" width="700" style=" padding-top:5px;">
                    <tr>
                        <td height="35" style=" width:180px;">
                            您的姓名
                        </td>
                        <td height="35" style=" width:180px;">
                            <asp:TextBox ID="txtname" runat="server"></asp:TextBox>
                        </td>
                        <td height="35" style=" width:180px;">
                            您的性别</td>
                        <td>
                            <asp:DropDownList ID="ddlxb" runat="server">
                                <asp:ListItem>男</asp:ListItem>
                                <asp:ListItem>女</asp:ListItem>
                            </asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <td height="35" style=" width:180px;">
                            联系方式</td>
                        <td height="35" style=" width:180px;">
                            <asp:TextBox ID="txtlxfs" runat="server"></asp:TextBox>
                        </td>
                        <td height="35" style=" width:180px;">
                            验证码</td>
                        <td>
                            <asp:TextBox ID="txt_CheckCodeImg" runat="server" Width="40px"></asp:TextBox><img src="../Controls/ValidateCode.aspx" align="absmiddle" alt="看不清楚，单击图片换一张。" onclick="this.src = '../Controls/ValidateCode.aspx?flag=' + Math.random();document.getElementById('txt_CheckCodeImg').value='';"
                        border="0" />
                        </td>
                    </tr>
                    <tr>
                        <td height="35">
                            咨询标题</td>
                        <td height="35" colspan="3">
                            <asp:TextBox ID="txttitle" runat="server" Width="397px"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td height="35">
                            咨询内容</td>
                        <td height="35" colspan="3">
                            <asp:TextBox ID="txtcontent" runat="server" Height="135px" TextMode="MultiLine" 
                                Width="397px"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td height="35" colspan="4">
                            <asp:Button ID="Button1" runat="server" Text="提   交" onclick="Button1_Click" />
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
        <asp:HiddenField ID="hdpage"  runat="server" Value="1" />
    </form>
</body>
</html>
