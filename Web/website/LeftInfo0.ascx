<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="LeftInfo0.ascx.cs" Inherits="Web.website.LeftInfo0" %>
<style type="text/css">
        body,div,span,img,ul,li,dl,dt,table,tr,td{ margin:0; padding:0; border:0;color:#5b5b5b;}
        ul{ list-style:none;}
        .topright{ float:right;}
        .news{ line-height:23px;}
      .news li{ list-style-type:disc; border-bottom:#666666 1px dashed; list-style-position:inside;padding-left:5px;}
      .ty{ line-height:25px;}
      .ty li{list-style-type:disc;  list-style-position:inside;padding-left:5px;}
        body
        {
            background-image: url('images/bodybj.jpg');
            background-repeat: repeat-x;
            font-size:13px;
        }
        .indexbar01
        {
            background-image: url(Images/index_08.gif);
            font-size: 12pt;
            vertical-align: bottom;
            cursor: hand;
        }
        .indexbar02
        {
            background-image: url(Images/index_09.gif);
            font-size: 10pt;
            vertical-align: bottom;
            cursor: hand;
        }
        .table
        {
            border: 1px solid #c1c1c1;
            border-collapse: collapse; /*是否合并边框*/
        }
        .table th
        {
            border: 1px solid #c1c1c1;
            text-align: center;
            background-color: #eeeeee;
            padding: 1px;
        }
        .td
        {
            border: 1px solid #c1c1c1;
            padding: 1px;
        }
        a.class:link
        {
            color: #454545;
        }
        /*没点之前 */
        a.class:visited
        {
            color: #454545;
        }
        /*点过之后 */
        a.class:hover
        {
            color: #fbae1a;
        }
        /*鼠标移到上方 */
        a.class:active
        {
            color: #fbae1a;
        }
        /*激活时 */
        img
        {
            border: 0;
        }
        .font
        {
            font-size: 14px;
            font-family: 宋体;
            font-weight: bold;
            color:#ffffff;
        }
        .b
        {
            border-left: 1px solid #cacac9;
            border-right: 1px solid #cacac9;
            border-bottom: 1px solid #cacac9;
        }
      
        .style4
        {
            height: 233px;
            width: 363px;
        }
        .style5
        {
            width: 609px;
        }
        .fs
        {
            font-size:12px;
            }
            .gg{ font-size:14px; color:#0C358D; display:block; line-height:33px; text-align:center; text-decoration:none; }
    </style>
<table id="tableModel" cellpadding="0" cellspacing="0" runat="server"  visible="false" style="border: 4px solid #f3f4f0;">
    <tr>
        <td style="height: 36px; background-image: url(images/neibar.jpg); text-align: left;
            width: 222px; color: #fc4600; font-size: 14px;" valign="middle">
            <span style="padding-left:20px"><strong>
                &nbsp;&nbsp; <%=ClassName %>
            </strong></span>
        </td>
    </tr>
    <tr>
        <td style="background-image: url(Images3/indexlist_06.gif); height: 246px; width: 222px;">
            <table cellpadding="0" cellspacing="0" style="width: 222px; height: 100%;">
                <tr>
                    <td style="vertical-align: top; text-align: left;">
                        <table cellpadding="0" cellspacing="0" style="width: 95%; margin-left: 13px; margin-top: 5px;
                            font-size: 10pt;">
                            <tr>
                                <td>
                                    <%=ModelList.ToString() %>
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
            </table>
        </td>
    </tr>
</table>
<table cellpadding="0" cellspacing="0" style="border: 4px solid #f3f4f0;">
    <tr>
        <td style="height: 36px; background-image: url(images/neibar.jpg); color: #fc4600;
            font-size: 14px;" align="left" valign="middle">
            <span style="padding-left:20px"><strong>&nbsp;&nbsp;最新发布</strong></span>
        </td>
    </tr>
    <tr>
        <td style="background-image: url(Images3/indexlist_06.gif); height: 246px; width: 222px;
            vertical-align: top">
            <table cellpadding="0" cellspacing="0" style="width: 222px;">
                <tr>
                    <td>
                        <table cellpadding="0" cellspacing="0" style="width: 95%; margin-left: 3px; margin-top: 5px;padding-left:5px;
                            text-align: left; font-size: 10pt">
                            <tr>
                                <td><div class="ty" style="width: 95%; text-align: left;">
                                                              <ul>
                                                                                <asp:Repeater ID="repzuixin" runat="server">
    <ItemTemplate><li><a href="shownews.aspx?lbid=<%#Eval("NewsTypeId")%>&id=<%#Eval("id")%>" target="_blank" style="text-decoration:none"><%#Eval("NewsTitle").ToString().Length > 12 ? Eval("NewsTitle").ToString().Substring(0, 12) + ".." : Eval("NewsTitle").ToString()%></a></li>
    </ItemTemplate>
    </asp:Repeater>
                                                                                </ul>
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

