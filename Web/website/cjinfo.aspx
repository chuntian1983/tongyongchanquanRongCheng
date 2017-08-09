<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="cjinfo.aspx.cs" Inherits="Web.website.cjinfo" %>
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
                                    <img src="Images/indexlist_13.gif"  /> 您当前所在的位置：网站首页 >>&nbsp; <%=ClassName %> 
                              </td>
                            </tr>
                            <tr>
                                <td style="height: 5px;border-left: 6px solid #f6f6f6;border-right: 6px solid #f6f6f6; text-align:center">
                                <hr style="color:#fa8900; width:96%"/>
                                </td>
                            </tr>
                            <tr>
                                <td style=" background-color:White; vertical-align: top; border: 6px solid #f6f6f6; border-top: 0;">
                                    <table class="table" border="0px" cellpadding="0" cellspacing="0" width="700">
                    <tr>
                        <td height="35" style=" width:180px;">
                            项目编码
                        </td>
                        <td>
                            <asp:Label ID="lbxmbh" runat="server" Text="Label"></asp:Label>
&nbsp;</td>
                    </tr>
                    <tr>
                        <td height="35">
                            区域
                        </td>
                        <td>
                            
                            <asp:Label ID="lbxmbh0" runat="server" Text="Label"></asp:Label>
                            
                        </td>
                    </tr>
                    <tr>
                        <td height="35">
                            项目类别
                        </td>
                        <td>
                            <asp:Label ID="lbxmbh1" runat="server" Text="Label"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td height="35">
                            转出标的名称
                        </td>
                        <td>
                            <asp:Label ID="lbxmbh2" runat="server" Text="Label"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td height="35">
                            转出方名称</td>
                        <td>
                            <asp:Label ID="lbxmbh3" runat="server" Text="Label"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td height="35">
                            挂牌价格</td>
                        <td>
                            <asp:Label ID="lbxmbh4" runat="server" Text="Label"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td height="35">
                            拟转出期限
                        </td>
                        <td>
                            <asp:Label ID="lbxmbh5" runat="server" Text="Label"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td height="35">
                            授权情况
                        </td>
                        <td>
                            <asp:Label ID="lbxmbh6" runat="server" Text="Label"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td height="35">
                            坐落/市镇村
                        </td>
                        <td>
                            <asp:Label ID="lbxmbh7" runat="server" Text="Label"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td height="35">
                            权属
                        </td>
                        <td>
                            <asp:Label ID="lbxmbh8" runat="server" Text="Label"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td height="35">
                            承包方式
                        </td>
                        <td>
                            <asp:Label ID="lbxmbh9" runat="server" Text="Label"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td height="35">
                            拟转出面积（亩）</td>
                        <td>
                            <asp:Label ID="lbxmbh10" runat="server" Text="Label"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td height="35">
                            涉及农户数
                        </td>
                        <td>
                            <asp:Label ID="lbxmbh11" runat="server" Text="Label"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td height="35">
                            土地东至
                        </td>
                        <td>
                            <asp:Label ID="lbxmbh12" runat="server" Text="Label"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td height="35">
                            土地南至
                        </td>
                        <td>
                            <asp:Label ID="lbxmbh13" runat="server" Text="Label"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td height="35">
                            土地西至
                        </td>
                        <td>
                            <asp:Label ID="lbxmbh14" runat="server" Text="Label"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td height="35">
                            土地北至
                        </td>
                        <td>
                            <asp:Label ID="lbxmbh15" runat="server" Text="Label"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td height="35">
                            流转承包用途
                        </td>
                        <td>
                            <asp:Label ID="lbxmbh16" runat="server" Text="Label"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td height="35">
                            是否属于再次转出
                        </td>
                        <td>
                            <asp:Label ID="lbxmbh17" runat="server" Text="Label"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td height="35">
                            拟转出方式
                        </td>
                        <td>
                            <asp:Label ID="lbxmbh18" runat="server" Text="Label"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td height="35">
                            农户转出意愿情况
                        </td>
                        <td>
                            <asp:Label ID="lbxmbh19" runat="server" Text="Label"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td height="35">
                            挂牌公告期
                        </td>
                        <td>
                            <asp:Label ID="lbxmbh20" runat="server" Text="Label"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td height="35">
                            如征集到两个及以上有效转入申请
                        </td>
                        <td>
                            <asp:Label ID="lbxmbh21" runat="server" Text="Label"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td height="35">
                            转入方应具备的条件
                        </td>
                        <td>
                            <asp:Label ID="lbxmbh22" runat="server" Text="Label"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td height="35">
                            交易方式
                        </td>
                        <td>
                            <asp:Label ID="lbxmbh23" runat="server" Text="Label"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td height="35">
                            标是否存在 抵押、封查等情况
                        </td>
                        <td>
                            <asp:Label ID="lbxmbh24" runat="server" Text="Label"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td height="35">
                            其它需要披露事项
                        </td>
                        <td>
                            <asp:Label ID="lbxmbh25" runat="server" Text="Label"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td height="35">
                            截止日期为
                        </td>
                        <td>
                            <asp:Label ID="lbxmbh26" runat="server" Text="Label"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td height="35">
                            挂牌状态
                        </td>
                        <td>
                            <asp:Label ID="lbxmbh27" runat="server" Text="Label"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="2">
                            &nbsp;</td>
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
