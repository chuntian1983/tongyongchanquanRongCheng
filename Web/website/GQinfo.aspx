<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="GQinfo.aspx.cs" Inherits="Web.website.GQinfo" %>
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
                                    <img src="Images/indexlist_13.gif"  /> 您当前所在的位置：网站首页 >>&nbsp;供求信息
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
                            项目名称
                        </td>
                        <td>
                            <asp:Label ID="lbxmbh" runat="server" Text="Label"></asp:Label>
&nbsp;</td>
                    </tr>
                    <tr>
                        <td height="35">
                            关键字</td>
                        <td>
                            
                            <asp:Label ID="lbxmbh0" runat="server" Text="Label"></asp:Label>
                            
                        </td>
                    </tr>
                    <tr>
                        <td height="35">
                            项目编号
                        </td>
                        <td>
                            <asp:Label ID="lbxmbh1" runat="server" Text="Label"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td height="35">
                            受让方姓名
                        </td>
                        <td>
                            <asp:Label ID="lbxmbh2" runat="server" Text="Label"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td height="35">
                            受让方土地用途</td>
                        <td>
                            <asp:Label ID="lbxmbh3" runat="server" Text="Label"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td height="35">
                            受让方挂牌时间</td>
                        <td>
                            <asp:Label ID="lbxmbh4" runat="server" Text="Label"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td height="35">
                            受让方面积</td>
                        <td>
                            <asp:Label ID="lbxmbh5" runat="server" Text="Label"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td height="35">
                            受让方意向报价</td>
                        <td>
                            <asp:Label ID="lbxmbh6" runat="server" Text="Label"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td height="35">
                            受让方流转方式</td>
                        <td>
                            <asp:Label ID="lbxmbh7" runat="server" Text="Label"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td height="35">
                            受让方流转期限</td>
                        <td>
                            <asp:Label ID="lbxmbh8" runat="server" Text="Label"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td height="35">
                            受让方中心联系方式</td>
                        <td>
                            <asp:Label ID="lbxmbh9" runat="server" Text="Label"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td height="35">
                            受让方项目联系方式</td>
                        <td>
                            <asp:Label ID="lbxmbh10" runat="server" Text="Label"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td height="35">
                            备注
                        </td>
                        <td>
                            <asp:Label ID="lbxmbh11" runat="server" Text="Label"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="2">
                            &nbsp;</td>
                    </tr>
                </table>
                <table class="guapai" id="Table12" style=" display:block;">
                <tr><td colspan="5">查找的相关需求信息</td></tr>
                                                            <tr>
                                                           <th>信息名称</th>
                                                           <th>土地性质</th>
                                                           <th>位置</th>
                                                           <th>面积</th>
                                                           <th>发布时间</th>
                                                           </tr>
                                                           <asp:Repeater runat=server ID="repxuqiu"><ItemTemplate>
                                                           <tr>
                                                           <td><a href='xqinfo.aspx?id=<%#Eval("id")%>'><%#Eval("ProName")%></a></td>
                                                           <td><%#Eval("sLandProperties")%></td>
                                                           <td><%#Eval("sLocated")%></td>
                                                           <td><%#Eval("sOutArea")%></td>
                                                           <td><%#DateTime.Parse( Eval("sListedData").ToString()).ToString("yyyy-MM-dd")%></td>
                                                           
                                                           </tr>
                                                           </ItemTemplate></asp:Repeater>
                                                            </table>
                                                            
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
                                </td>
                            </tr>
                           
                        </table>
                    </td>
                </tr>
            </table>
             <asp:HiddenField ID="hdpage"  runat="server" Value="1" />
            <uc2:WebBottom ID="WebBottom1" runat="server" />
        </div>
    </form>
</body>
</html>
