<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="searchlist.aspx.cs" Inherits="Web.website.searchlist" %>
<%@ Register Src="LeftInfo0.ascx" TagName="LeftInfo0" TagPrefix="uc3" %>
<%@ Register Src="WebBottom.ascx" TagName="WebBottom" TagPrefix="uc2" %>
<%@ Register Src="WebHead.ascx" TagName="WebHead" TagPrefix="uc1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>荣成市农村产权交易平台</title>
    <style type="text/css">

a.class:link   {color:   #454545;} /*没点之前 */
a.class:visited   {color:   #454545;} /*点过之后 */
a.class:hover   {color:   #fbae1a;} /*鼠标移到上方 */
a.class:active   {color:   #fbae1a;} /*激活时 */
body{ background-image:url('images/bodybj.jpg'); background-repeat:repeat-x;}
</style>
    <link type="text/css" href="Images/css.css" rel="Stylesheet" />
</head>
<body style="text-align: center; margin: 0px">
    <form id="form1" runat="server">
        <div style=" width:1000px; margin:0 auto;">
            <uc1:WebHead ID="WebHead1" runat="server" />
            <table border="0" cellpadding="0" cellspacing="0" style="margin-top: 3px; width: 1000px;">
                <tr>
                    <td style="width: 70%; vertical-align: top">
                        <table cellpadding="0" cellspacing="0" style="width: 100%; height: 100%; margin-top: 5px">
                            <tr>
                                <td width="222" rowspan="3" align="left" style="vertical-align: top; width: 200px;">
                              <uc3:LeftInfo0 ID="LeftInfo0_1" runat="server"></uc3:LeftInfo0>                              </td>
                                <td width="76%" valign="middle" style="height: 37px; color: #454545; font-size: 14px; text-align: left;
                                    border: 6px solid #f6f6f6; border-bottom: 0;padding-left:10px;">
                                    <img src="Images/indexlist_13.gif" /><b>您当前所在的位置：</b> 网站首页 >>&nbsp;
                                    <%=ClassName %>
                              </td>
                            </tr>
                            <tr>
                                <td style="height: 5px;border-left: 6px solid #f6f6f6;border-right: 6px solid #f6f6f6; text-align:center"><hr style="color:#fa8900; width:96%"/>
                                </td>
                            </tr>
                            <tr>
                                <td style="height: 528px; vertical-align: top; border: 6px solid #f6f6f6; border-top: 0;padding-left:10px;">
                                    <asp:GridView ID="GridView1" runat="server" AllowPaging="True" AllowSorting="True"
                                        AutoGenerateColumns="False" Height="1px" PageSize="15" Style="color: #454545"
                                        Width="100%" ShowHeader="False" OnRowDataBound="Fun_A2500144CE07445DB52955237F3BC2D1"
                                        BorderWidth="0px">
                                        <PagerSettings FirstPageText="首页" LastPageText="尾页" Mode="NumericFirstLast" />
                                        <Columns>
                                            <asp:BoundField DataField="newstitle" HeaderText="新闻标题">
                                                <ItemStyle Width="600px" HorizontalAlign="Left" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="createdate" DataFormatString="{0:yyyy-MM-dd HH:mm:ss}" HeaderText="发布日期"
                                                HtmlEncode="False">
                                                <ItemStyle HorizontalAlign="center" Width="220px" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="newstypeid" HeaderText="newstype" Visible="False" />
                                        </Columns>
                                        <PagerTemplate>
                                            &nbsp;<asp:LinkButton ID="FirstPage" runat="server" Font-Size="10pt" OnClick="Fun_7D7C6C8605D84A43BC6DEAB1B71BA736">首页</asp:LinkButton>
                                            &nbsp;
                                            <asp:LinkButton ID="PreviousPage" runat="server" Font-Size="10pt" OnClick="Fun_6D4066F03C9048D2B493145F67949985">上一页</asp:LinkButton>
                                            &nbsp;
                                            <asp:LinkButton ID="NextPage" runat="server" Font-Size="10pt" OnClick="Fun_25E80831410741DFA561BAFDA942D4C2">下一页</asp:LinkButton>
                                            &nbsp;
                                            <asp:LinkButton ID="LastPage" runat="server" Font-Size="10pt" OnClick="Fun_135A605A3357484A83413430EE60047E">尾页</asp:LinkButton>
                                            &nbsp;
                                            <asp:Label ID="ShowPageInfo" runat="server" Font-Size="10pt" Text="总页数："></asp:Label>
                                            &nbsp;&nbsp;
                                            <asp:Label ID="Label1" runat="server" Font-Size="10pt" ForeColor="Navy" Text="跳转到："></asp:Label>
                                            <asp:DropDownList ID="JumpPage" runat="server" AutoPostBack="True" OnSelectedIndexChanged="Fun_ADA162A2B67849BE9E78F16CF5E2F4BC">
                                            </asp:DropDownList>
                                        </PagerTemplate>
                                        <RowStyle Font-Size="10pt" Height="24px" />
                                        <PagerStyle BackColor="White" ForeColor="Olive" />
                                    </asp:GridView>
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
