<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="default.aspx.cs" Inherits="Web.website._default" %>
<%@ Register Src="WebBottom.ascx" TagName="WebBottom" TagPrefix="uc2" %>
<%@ Register Src="WebHead.ascx" TagName="WebHead" TagPrefix="uc1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>荣成市农村产权交易平台</title>
    <style type="text/css">
        body,div,span,img,ul,li,dl,dt,table,tr,td{ margin:0; padding:0; border:0;color:#5b5b5b;}
        ul{ list-style:none;}
        .guapai{ width:700px; overflow:hidden;table-layout:fixed;}
        .guapai th{ color:#3986E0; background-image:url('images/untitled.bmp'); background-repeat:repeat-x; text-align:center;}
        .guapai2 td{  white-space:nowrap; overflow:hidden; table-layout:fixed;}
        .guapai2{ width:355px; overflow:hidden;table-layout:fixed;}
        .guapai2 th{ color:#3986E0; background-image:url('images/untitled.bmp'); background-repeat:repeat-x; text-align:center;}
        .guapai td{  white-space:nowrap; overflow:hidden; table-layout:fixed;}
        .topright{ float:right;}
        .news{ line-height:23px;}
      .news li{ list-style-type:disc; border-bottom:#666666 1px dashed; list-style-position:inside;padding-left:5px;}
      .ty{ line-height:25px;}
      .ty li{list-style-type:disc;  list-style-position:inside;padding-left:5px;}
      .bmfw{background:url(index_28.jpg) repeat-x; width:234px; margin:0;height:239px;}
.bmfw li.frist{padding-left:25px; line-height:31px; height:31px; color:#006cce; list-style-type:none;  border:none; }
.bmfw li.se{ float:left; width:100px; overflow:hidden; margin-top:15px; margin-left:10px;}
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
        .fs
        {
            font-size:12px; color:White;
            }
            .fs a{ color:White;}
            .gg{ font-size:12px; color:#0C358D; width:65px; display:block; line-height:33px; text-align:center; text-decoration:none; }
    </style>
   
    <script type="text/javascript">
        function $(o) { return (typeof (o) == "object") ? o : document.getElementById(o); }
        function SetIndexBar(v) {
            if (v == 0) {
                $("IndexBar01").className = "indexbar01";
                $("IndexBar02").className = "indexbar02";
                $("indexD01").style.display = "";
                $("indexD02").style.display = "none";
            }
            else {
                $("IndexBar01").className = "indexbar02";
                $("IndexBar02").className = "indexbar01";
                $("indexD01").style.display = "none";
                $("indexD02").style.display = "";
            }
        }
        function openWin(v) {
            location.href = "GuestBook.aspx?tid=" + v;
        }
        function gotof(a) {
            document.getElementById("ifr").src = a;
        }
        function SetArea(vid) {
            var returnV = window.showModalDialog("../../SystemManage/SetGoogleMap.aspx?g=" + (new Date()).getTime(), $(vid).value, "dialogWidth=700px;dialogHeight=528px;center=yes;");
            if (typeof (returnV) != "undefined") {
                $(vid).value = returnV;
            }
            return false;
        }

        function fnover(n) {
            switch (n) {
                case 1:
                    document.getElementById('gg1').style.backgroundImage = "url('images/xuanxk.jpg')";
                    document.getElementById('gg2').style.backgroundImage = "";
                    document.getElementById('gg3').style.backgroundImage = "";
                    document.getElementById('tdgg1').style.display = "";
                    document.getElementById('tdgg2').style.display = "none";
                    document.getElementById('tdgg3').style.display = "none";
                    break;
                case 2:
                    document.getElementById('gg1').style.backgroundImage = "";
                    document.getElementById('gg2').style.backgroundImage = "url('images/xuanxk.jpg')";
                    document.getElementById('gg3').style.backgroundImage = "";
                    document.getElementById('tdgg1').style.display = "none";
                    document.getElementById('tdgg2').style.display = "";
                    document.getElementById('tdgg3').style.display = "none";
                    break;
                case 3:
                    document.getElementById('gg1').style.backgroundImage = "";
                    document.getElementById('gg2').style.backgroundImage = "";
                    document.getElementById('gg3').style.backgroundImage = "url('images/xuanxk.jpg')";
                    document.getElementById('tdgg1').style.display = "none";
                    document.getElementById('tdgg2').style.display = "none";
                    document.getElementById('tdgg3').style.display = "";
                    break;
                case 4:
                    document.getElementById('gg4').style.backgroundImage = "url('images/xuanxk.jpg')";
                    document.getElementById('gg5').style.backgroundImage = "";
                    document.getElementById('gg6').style.backgroundImage = "";
                    document.getElementById('tdgg4').style.display = "";
                    document.getElementById('tdgg5').style.display = "none";
                    document.getElementById('tdgg6').style.display = "none";
                    break;
                case 5:
                    document.getElementById('gg4').style.backgroundImage = "";
                    document.getElementById('gg5').style.backgroundImage = "url('images/xuanxk.jpg')";
                    document.getElementById('gg6').style.backgroundImage = "";
                    document.getElementById('tdgg4').style.display = "none";
                    document.getElementById('tdgg5').style.display = "";
                    document.getElementById('tdgg6').style.display = "none";
                    break;
                case 6:
                    document.getElementById('gg4').style.backgroundImage = "";
                    document.getElementById('gg5').style.backgroundImage = "";
                    document.getElementById('gg6').style.backgroundImage = "url('images/xuanxk.jpg')";
                    document.getElementById('tdgg4').style.display = "none";
                    document.getElementById('tdgg5').style.display = "none";
                    document.getElementById('tdgg6').style.display = "";
                    break;
                case 7:
                    document.getElementById('gg7').style.backgroundImage = "url('images/xuanxk.jpg')";
                    document.getElementById('gg8').style.backgroundImage = "";
                    document.getElementById('tdgg7').style.display = "";
                    document.getElementById('tdgg8').style.display = "none";
                    break;
                case 8:
                    document.getElementById('gg8').style.backgroundImage = "url('images/xuanxk.jpg')";
                    document.getElementById('gg7').style.backgroundImage = "";
                    document.getElementById('tdgg8').style.display = "";
                    document.getElementById('tdgg7').style.display = "none";
                    break;
            }

        }
        function tablegupai(a,b) {
            var va = 'A';
            var ta = 'Table';
            for (var i = 1; i < 12; i++) {
                va = 'A' + i;
                if (a == i) {
                    
                    document.getElementById(va).style.backgroundImage = "url('images/xuanxk.jpg')";

                }else { document.getElementById(va).style.backgroundImage = ""; }
            }
            for (var i = 0; i < 11; i++) {
                ta = 'Table' + i;
                if (b == i) {
                    document.getElementById(ta).style.display = "";
                } else { document.getElementById(ta).style.display = "none"; }
            }
        }
    </script>
     
     
</head>
<body style="text-align: center; margin: 0px;">
    <form id="form1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <div style="margin: 0 auto; width: 999px; overflow:hidden;  border-right:solid 1px #CCCCCC;">
        <table cellpadding="0" cellspacing="0" style="width: 999px; border: 1px solid #f6f6f6;">
            <tr>
                <td>
                    <uc1:WebHead ID="WebHead1" runat="server" />
                </td>
            </tr>
            <tr>
                <td>
                    <img src="images/csbst.gif" />
                </td>
            </tr>
            <tr>
                <td valign="top">
                    <table cellpadding="0" cellspacing="0" style="width: 998px; border: 1px solid #cccccc;">
                        <tr>
                            <td align="left" valign="top">
                                <table cellpadding="0" cellspacing="0">
                                    <tr>
                                        <td align="center">
                                            <table cellpadding="0" cellspacing="0" style="width: 550px; padding-left: 0px">
                                                <tr>
                                                    <td align="center" style="width: 800px; vertical-align: top">
                                                        <table cellpadding="0" cellspacing="0" style="width: 630px; height: 277px; text-align: left;">
                                                            <tr>
                                                                <td align="center">
                                                                    <div style="width: 364px; height: 270px; text-align: center; border: 1px solid #cacac9;">
                                                                        <div style="padding-left: 3px; padding-top: 5px">
                                                                            <script type="text/javascript">
                                                                                var focus_width = 360;
                                                                                var focus_height = 259;
                                                                                var text_height = 40;
                                                                                var swf_height = focus_height
                                                                                var pics = "<%=picNews.ToString() %>";
                                                                                var links = "<%=picLinks.ToString() %>";
                                                                                var texts = "<%=picTexts.ToString() %>";
                                                                                document.write('<object classid="clsid:d27cdb6e-ae6d-11cf-96b8-444553540000" codebase="http://fpdownload.macromedia.com/pub/shockwave/cabs/flash/swflash.cab#version=6,0,0,0" width="' + focus_width + '" height="' + swf_height + '">');
                                                                                document.write('<param name="allowScriptAccess" value="sameDomain"><param name="movie" value="Images/focus.swf"><param name="quality" value="high"><param name="bgcolor" value="#F0F0F0">');
                                                                                document.write('<param name="menu" value="false"><param name=wmode value="opaque">');
                                                                                document.write('<param name="FlashVars" value="pics=' + pics + '&links=' + links + '&texts=' + texts + '&borderwidth=' + focus_width + '&borderheight=' + focus_height + '&textheight=' + text_height + '">');
                                                                                document.write('<embed src="Images/focus.swf" wmode="opaque" FlashVars="pics=' + pics + '&links=' + links + '&texts=' + texts + '&borderwidth=' + focus_width + '&borderheight=' + focus_height + '&textheight=' + text_height
                        + '" menu="false" bgcolor="#F0F0F0" quality="high" width="' + focus_width + '" height="' + focus_height + '" allowScriptAccess="sameDomain" type="application/x-shockwave-flash" pluginspage="http://www.macromedia.com/go/getflashplayer" />');
                                                                                document.write('</object>');
                                                                            </script>
                                                                        </div>
                                                                        <br />
                                                                        <br />
                                                                    </div>
                                                                </td>
                                                                <td align="center" valign="top">
                                                                    <table cellpadding="0" cellspacing="0" style="width: 361px; text-align: left; margin-top: 2px;
                                                                        margin-left: 5px">
                                                                        <tr>
                                                                            <td style="height: 35px; background-image: url(images/news2.jpg); overflow: hidden;
                                                                                background-repeat: no-repeat;">
                                                                                <div style="margin-left: 340px">
                                                                                    <a href="ShowNewsList.aspx?lbid=2"><font style="font-size: 12px; font-family: 宋体;
                                                                                        color: #fc4c08">更多</font></a>
                                                                                </div>
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td style="text-align: center; vertical-align: top; border: 1px solid #cacac9; border-top: 0">
                                                                                <div class="news" style="text-align: left; width: 370px; height: 236px; margin-left: 2px; vertical-align: top">
                                                                                <ul>
                                                                                <asp:Repeater ID="repfwsn" runat="server">
    <ItemTemplate><li><span class="topright"><%#DateTime.Parse(Eval("CreateDate").ToString()).ToString("yyyy-MM-dd")%></span><a href="shownews.aspx?lbid=<%#Eval("NewsTypeId")%>&id=<%#Eval("id")%>" target="_blank" style="text-decoration:none"><%#Eval("NewsTitle").ToString().Length > 20 ? Eval("NewsTitle").ToString().Substring(0, 20) + ".." : Eval("NewsTitle").ToString()%></a></li>
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
                                        </td>
                                        <td align="left">
                                            <table cellpadding="0" cellspacing="0" style=" margin-left:10px; border:0px solid #cccccc;">
                                                    <tr>
                                                        <td style="width: 326px; height: 33px; text-align: left; background-image: url(images/zcfagui.jpg); background-repeat:no-repeat; overflow:hidden;padding-left: 20px" class="font">
                                                           <a id="gg7"  onmouseover="fnover(7)" href="ShowNewsList.aspx?lbid=14" class=gg style="background-image:url('images/xuanxk.jpg');display:block;   height:31px;  float:left;">通知公告</a><a id="gg8"  onmouseover="fnover(8)" href="cjinfolist.aspx?lbid=5" class=gg style=" float:left; display:block;   height:31px; ">成交公告</a>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td id="tdgg7" style="width: 326px; height: 233px; padding-top: 5px; text-align: center; 
                                                            vertical-align: top">
                                                            <div class="ty" style="width: 95%; text-align: left;">
                                                              <ul>
                                                                                <asp:Repeater ID="reptz" runat="server">
    <ItemTemplate><li><a href="shownews.aspx?lbid=<%#Eval("NewsTypeId")%>&id=<%#Eval("id")%>" target="_blank" style="text-decoration:none"><%#Eval("NewsTitle").ToString().Length > 14 ? Eval("NewsTitle").ToString().Substring(0, 14) + ".." : Eval("NewsTitle").ToString()%></a></li>
    </ItemTemplate>
    </asp:Repeater>
                                                                                </ul>
                                                            </div>
                                                            <div style="width: 95%; text-align: right; vertical-align: bottom; height: 25px">
                                                                <span><a href="ShowNewsList.aspx?lbid=14"><font style="font-size: 12px;
                                                                    font-family: 宋体; color: #fc4c08">更多...</font> </a>&nbsp;&nbsp;&nbsp;&nbsp;</span>
                                                            </div>
                                                        </td>
                                                        <td id="tdgg8" style="width: 326px; height: 233px; padding-top: 5px; text-align: center; display:none; vertical-align: top">
                                                            <div class="ty" style="width: 95%; text-align: left;">
                                                              <ul>
                                                                                <asp:Repeater ID="repchengjiao" runat="server">
    <ItemTemplate><li><a href="cjinfo.aspx?id=<%#Eval("id")%>" target="_blank" style="text-decoration:none"><%#Eval("OutProName").ToString().Length > 11 ? Eval("OutProName").ToString().Substring(0, 11) + ".." : Eval("OutProName").ToString()%></a><span style=" float:right;">交易完成</span></li>
    </ItemTemplate>
    </asp:Repeater>
                                                                                </ul>
                                                            </div>
                                                            <div style="width: 95%; text-align: right; vertical-align: bottom; height: 25px">
                                                                <span><a href="cjinfolist.aspx?lbid=5"><font style="font-size: 12px;
                                                                    font-family: 宋体; color: #fc4c08">更多...</font> </a>&nbsp;&nbsp;&nbsp;&nbsp;</span>
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
                </td>
            </tr>
            <tr>
                <td>
                    <img border="0" src="images/syslnk.jpg" usemap="#syslnks" alt=""/>
                    <map name="syslnks" id="syslnks">
                        <area shape="rect" coords="14,49,239,90" target="_blank" href="<%=Url1 %>" alt="农村三资监管系统" />
                        <area shape="rect" coords="16,100,237,137" target="_blank" href="<%=Url2 %>" alt="招投标管理系统" />
                        <area shape="rect" coords="16,148,237,185" target="_blank" href="<%=Url3 %>" alt="海域使用权管理系统" />
                        <area shape="rect" coords="264,49,486,89" target="_blank" href="<%=Url4 %>" alt="农村土地确权管理系统" />
                        <area shape="rect" coords="266,100,485,134" target="_blank" href="<%=Url5 %>" alt="专家库管理系统" />
                        <area shape="rect" coords="266,146,486,181" target="_blank" href="<%=Url6 %>" alt="宅基地使用权管理系统" />
                        <area shape="rect" coords="509,51,727,87" target="_blank" href="<%=Url7 %>" alt="农村土地流转管理系统" />
                        <area shape="rect" coords="509,100,727,135" target="_blank" href="<%=Url8 %>" alt="林权管理系统" />
                        <area shape="rect" coords="508,147,725,180" target="_blank" href="<%=Url9 %>" alt="产权抵押管理系统" />
                        <area shape="rect" coords="746,22,997,92" target="_blank" href="<%=Url10 %>" alt="农村三资查询系统" />
                        <area shape="rect" coords="750,108,998,173" target="_blank" href="<%=Url11 %>" alt="供求信息发布系统" />
                    </map>
                </td>
            </tr>
            </table>
            <table>
            <!---->
            <tr>
                <td>
                    <table cellpadding="0" cellspacing="0" style="width: 1000px; height:460px;">
                        <tr>
                            <td valign=top style="text-align: left;">
                                <table cellpadding="0" cellspacing="0">
                                    <tr>
                                        <td style="text-align: left;">
                                            <table cellpadding="0" cellspacing="0" style="border: 1px solid #cccccc; height:458px;">
                                                <tr>
                                                    <td style="width: 730px; height: 33px; text-align: left; background-image: url(images/comm.jpg);
                                                        padding-left: 20px" class="font">
                                                        &nbsp;<span style="color:Black;">挂牌项目</span>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td style="width: 730px; height: 233px; text-align: center; padding-top: 5px; vertical-align: top;">
                                                            <table cellpadding="0" cellspacing="0" style=" margin-left:10px; border:0px solid #cccccc;">
                                                    <tr>
                                                        <td style="width: 100%; height: 33px; text-align: left; background-image: url(images/zcfagui.jpg); background-repeat:repeat-x; overflow:hidden;padding-left: 2px" class="font">
                                                           <a id="A1"  onmouseover="tablegupai(1,0)" href="gpinfolist.aspx?typeid=1" class=gg style="background-image:url('images/xuanxk.jpg');display:block;   height:31px;  float:left;">土地承包</a><a id="A2"  onmouseover="tablegupai(2,1)" href="gpinfolist.aspx?typeid=2" class=gg style=" float:left; display:block;  height:31px; ">四荒地</a>
                                                           <a id="A3"  onmouseover="tablegupai(3,2)" href="gpinfolist.aspx?typeid=3" class=gg style=" float:left; display:block;   height:31px; ">养殖水田</a>
                                                           <a id="A4"  onmouseover="tablegupai(4,3)" href="gpinfolist.aspx?typeid=4" class=gg style=" float:left; display:block;   height:31px; ">林地林木</a>
                                                           <a id="A5"  onmouseover="tablegupai(5,4)" href="gpinfolist.aspx?typeid=5" class=gg style=" float:left; display:block;   height:31px; ">知识产权</a>
                                                           <a id="A6"  onmouseover="tablegupai(6,5)" href="gpinfolist.aspx?typeid=6" class=gg style=" float:left; display:block;   height:31px; ">组织股权</a>
                                                           <a id="A7"  onmouseover="tablegupai(7,6)" href="gpinfolist.aspx?typeid=7" class=gg style=" float:left; display:block;   height:31px; ">农村房屋</a>
                                                           <a id="A8"  onmouseover="tablegupai(8,7)" href="gpinfolist.aspx?typeid=8" class=gg style=" float:left; display:block;   height:31px; ">闲置宅基地</a>
                                                           <a id="A9"  onmouseover="tablegupai(9,8)" href="gpinfolist.aspx?typeid=9" class=gg style=" float:left; display:block;   height:31px; ">生产设施</a>
                                                           <a id="A10"  onmouseover="tablegupai(10,9)" href="gpinfolist.aspx?typeid=10" class=gg style=" float:left; display:block;   height:31px; ">资产采购</a>
                                                           <a id="A11"  onmouseover="tablegupai(11,10)" href="gpinfolist.aspx?typeid=11" class=gg style=" float:left; display:block;   height:31px; ">集体工程</a>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td id="td1" style=" height: 233px; padding-top: 5px; text-align: center; 
                                                            vertical-align: top">
                                                            <div class="ty" style="width: 95%; text-align: left;">
                                                            <table class="guapai" id="Table0" style=" display:block; width:700px;">
                                                           <tr>
                                                           <th>项目编号</th>
                                                           <th>项目名称</th>
                                                           <th>挂牌价格</th>
                                                           <th>挂牌时间</th>
                                                           <th>交易状态</th>
                                                           </tr>
                                                           <asp:Repeater runat=server ID="rep1"><ItemTemplate>
                                                           <tr>
                                                           <td><%#Eval("ProNum")%></td>
                                                           <td><a href='gpinfo.aspx?id=<%#Eval("id")%>' target="_blank"> <%#Eval("OutProName").ToString().Length > 11 ? Eval("OutProName").ToString().Substring(0, 11) + ".." : Eval("OutProName").ToString()%></a></td>
                                                           <td><%#Eval("ListingPrice").ToString().Length > 11 ? Eval("ListingPrice").ToString().Substring(0, 11) + ".." : Eval("ListingPrice").ToString()%></td>
                                                           <td><%#Eval("ListedPeriod")%></td>
                                                           <td><%#Eval("ListingStatus")%></td>
                                                           
                                                           </tr>
                                                           </ItemTemplate></asp:Repeater>
                                                            </table>
                                                            <table class="guapai" id="Table1" style=" display:none;">
                                                           <tr>
                                                           <th>项目编号</th>
                                                           <th>项目名称</th>
                                                           <th>挂牌价格</th>
                                                           <th>挂牌时间</th>
                                                           <th>交易状态</th>
                                                           </tr>
                                                           <asp:Repeater runat=server ID="Repeater1"><ItemTemplate>
                                                           <tr>
                                                           <td><%#Eval("ProNum")%></td>
                                                           <td><a href='gpinfo.aspx?id=<%#Eval("id")%>' target="_blank"><%#Eval("OutProName").ToString().Length > 11 ? Eval("OutProName").ToString().Substring(0, 11) + ".." : Eval("OutProName").ToString()%></a></td>
                                                           <td><%#Eval("ListingPrice")%></td>
                                                           <td><%#Eval("ListedPeriod")%></td>
                                                           <td><%#Eval("ListingStatus")%></td>
                                                           
                                                           </tr>
                                                           </ItemTemplate></asp:Repeater>
                                                            </table>
                                                            <table class="guapai" id="Table2" style=" display:none;">
                                                           <tr>
                                                           <th>项目编号</th>
                                                           <th>项目名称</th>
                                                           <th>挂牌价格</th>
                                                           <th>挂牌时间</th>
                                                           <th>交易状态</th>
                                                           </tr>
                                                           <asp:Repeater runat=server ID="Repeater2"><ItemTemplate>
                                                           <tr>
                                                           <td><%#Eval("ProNum")%></td>
                                                           <td><a href='gpinfo.aspx?id=<%#Eval("id")%>' target="_blank"><%#Eval("OutProName").ToString().Length > 11 ? Eval("OutProName").ToString().Substring(0, 11) + ".." : Eval("OutProName").ToString()%></a></td>
                                                           <td><%#Eval("ListingPrice")%></td>
                                                           <td><%#Eval("ListedPeriod")%></td>
                                                           <td><%#Eval("ListingStatus")%></td>
                                                           
                                                           </tr>
                                                           </ItemTemplate></asp:Repeater>
                                                            </table>
                                                            <table class="guapai" id="Table3" style=" display:none;">
                                                           <tr>
                                                           <th>项目编号</th>
                                                           <th>项目名称</th>
                                                           <th>挂牌价格</th>
                                                           <th>挂牌时间</th>
                                                           <th>交易状态</th>
                                                           </tr>
                                                           <asp:Repeater runat=server ID="Repeater3"><ItemTemplate>
                                                           <tr>
                                                           <td><%#Eval("ProNum")%></td>
                                                           <td><a href='gpinfo.aspx?id=<%#Eval("id")%>' target="_blank"><%#Eval("OutProName").ToString().Length > 11 ? Eval("OutProName").ToString().Substring(0, 11) + ".." : Eval("OutProName").ToString()%></a></td>
                                                           <td><%#Eval("ListingPrice")%></td>
                                                           <td><%#Eval("ListedPeriod")%></td>
                                                           <td><%#Eval("ListingStatus")%></td>
                                                           
                                                           </tr>
                                                           </ItemTemplate></asp:Repeater>
                                                            </table>
                                                            <table class="guapai" id="Table4" style=" display:none;">
                                                           <tr>
                                                           <th>项目编号</th>
                                                           <th>项目名称</th>
                                                           <th>挂牌价格</th>
                                                           <th>挂牌时间</th>
                                                           <th>交易状态</th>
                                                           </tr>
                                                           <asp:Repeater runat=server ID="Repeater4"><ItemTemplate>
                                                           <tr>
                                                           <td><%#Eval("ProNum")%></td>
                                                           <td><a href='gpinfo.aspx?id=<%#Eval("id")%>' target="_blank"><%#Eval("OutProName").ToString().Length > 11 ? Eval("OutProName").ToString().Substring(0, 11) + ".." : Eval("OutProName").ToString()%></a></td>
                                                           <td><%#Eval("ListingPrice")%></td>
                                                           <td><%#Eval("ListedPeriod")%></td>
                                                           <td><%#Eval("ListingStatus")%></td>
                                                           
                                                           </tr>
                                                           </ItemTemplate></asp:Repeater>
                                                            </table>
                                                            <table class="guapai" id="Table5" style=" display:none;">
                                                           <tr>
                                                           <th>项目编号</th>
                                                           <th>项目名称</th>
                                                           <th>挂牌价格</th>
                                                           <th>挂牌时间</th>
                                                           <th>交易状态</th>
                                                           </tr>
                                                           <asp:Repeater runat=server ID="Repeater5"><ItemTemplate>
                                                           <tr>
                                                           <td><%#Eval("ProNum")%></td>
                                                           <td><a href='gpinfo.aspx?id=<%#Eval("id")%>' target="_blank"><%#Eval("OutProName").ToString().Length > 11 ? Eval("OutProName").ToString().Substring(0, 11) + ".." : Eval("OutProName").ToString()%></a></td>
                                                           <td><%#Eval("ListingPrice")%></td>
                                                           <td><%#Eval("ListedPeriod")%></td>
                                                           <td><%#Eval("ListingStatus")%></td>
                                                           
                                                           </tr>
                                                           </ItemTemplate></asp:Repeater>
                                                            </table>
                                                            <table class="guapai" id="Table6" style=" display:none;">
                                                           <tr>
                                                           <th>项目编号</th>
                                                           <th>项目名称</th>
                                                           <th>挂牌价格</th>
                                                           <th>挂牌时间</th>
                                                           <th>交易状态</th>
                                                           </tr>
                                                           <asp:Repeater runat=server ID="Repeater6"><ItemTemplate>
                                                           <tr>
                                                           <td><%#Eval("ProNum")%></td>
                                                           <td><a href='gpinfo.aspx?id=<%#Eval("id")%>' target="_blank"><%#Eval("OutProName").ToString().Length > 11 ? Eval("OutProName").ToString().Substring(0, 11) + ".." : Eval("OutProName").ToString()%></a></td>
                                                           <td><%#Eval("ListingPrice")%></td>
                                                           <td><%#Eval("ListedPeriod")%></td>
                                                           <td><%#Eval("ListingStatus")%></td>
                                                           
                                                           </tr>
                                                           </ItemTemplate></asp:Repeater>
                                                            </table>
                                                            <table class="guapai" id="Table7" style=" display:none;">
                                                           <tr>
                                                           <th>项目编号</th>
                                                           <th>项目名称</th>
                                                           <th>挂牌价格</th>
                                                           <th>挂牌时间</th>
                                                           <th>交易状态</th>
                                                           </tr>
                                                           <asp:Repeater runat=server ID="Repeater7"><ItemTemplate>
                                                           <tr>
                                                           <td><%#Eval("ProNum")%></td>
                                                           <td><a href='gpinfo.aspx?id=<%#Eval("id")%>' target="_blank"><%#Eval("OutProName").ToString().Length > 11 ? Eval("OutProName").ToString().Substring(0, 11) + ".." : Eval("OutProName").ToString()%></a></td>
                                                           <td><%#Eval("ListingPrice")%></td>
                                                           <td><%#Eval("ListedPeriod")%></td>
                                                           <td><%#Eval("ListingStatus")%></td>
                                                           
                                                           </tr>
                                                           </ItemTemplate></asp:Repeater>
                                                            </table>
                                                            <table class="guapai" id="Table8" style=" display:none;">
                                                           <tr>
                                                           <th>项目编号</th>
                                                           <th>项目名称</th>
                                                           <th>挂牌价格</th>
                                                           <th>挂牌时间</th>
                                                           <th>交易状态</th>
                                                           </tr>
                                                           <asp:Repeater runat=server ID="Repeater8"><ItemTemplate>
                                                           <tr>
                                                           <td><%#Eval("ProNum")%></td>
                                                           <td><a href='gpinfo.aspx?id=<%#Eval("id")%>' target="_blank"><%#Eval("OutProName").ToString().Length > 11 ? Eval("OutProName").ToString().Substring(0, 11) + ".." : Eval("OutProName").ToString()%></a></td>
                                                           <td><%#Eval("ListingPrice")%></td>
                                                           <td><%#Eval("ListedPeriod")%></td>
                                                           <td><%#Eval("ListingStatus")%></td>
                                                           
                                                           </tr>
                                                           </ItemTemplate></asp:Repeater>
                                                            </table>
<table class="guapai" id="Table9" style=" display:none;">
                                                           <tr>
                                                           <th>项目编号</th>
                                                           <th>项目名称</th>
                                                           <th>挂牌价格</th>
                                                           <th>挂牌时间</th>
                                                           <th>交易状态</th>
                                                           </tr>
                                                           <asp:Repeater runat=server ID="Repeater9"><ItemTemplate>
                                                           <tr>
                                                           <td><%#Eval("ProNum")%></td>
                                                           <td><a href='gpinfo.aspx?id=<%#Eval("id")%>' target="_blank"><%#Eval("OutProName").ToString().Length > 11 ? Eval("OutProName").ToString().Substring(0, 11) + ".." : Eval("OutProName").ToString()%></a></td>
                                                           <td><%#Eval("ListingPrice")%></td>
                                                           <td><%#Eval("ListedPeriod")%></td>
                                                           <td><%#Eval("ListingStatus")%></td>
                                                           
                                                           </tr>
                                                           </ItemTemplate></asp:Repeater>
                                                            </table>
                                                            <table class="guapai" id="Table10" style=" display:none;">
                                                           <tr>
                                                           <th>项目编号</th>
                                                           <th>项目名称</th>
                                                           <th>挂牌价格</th>
                                                           <th>挂牌时间</th>
                                                           <th>交易状态</th>
                                                           </tr>
                                                           <asp:Repeater runat=server ID="Repeater10"><ItemTemplate>
                                                           <tr>
                                                           <td><%#Eval("ProNum")%></td>
                                                           <td><a href='gpinfo.aspx?id=<%#Eval("id")%>' target="_blank"><%#Eval("OutProName").ToString().Length > 11 ? Eval("OutProName").ToString().Substring(0, 11) + ".." : Eval("OutProName").ToString()%></a></td>
                                                           <td><%#Eval("ListingPrice")%></td>
                                                           <td><%#Eval("ListedPeriod")%></td>
                                                           <td><%#Eval("ListingStatus")%></td>
                                                           
                                                           </tr>
                                                           </ItemTemplate></asp:Repeater>
                                                            </table>
                                                            


                                                             
                                                            </div>
                                                            <div style="width: 95%; text-align: right; vertical-align: bottom; height: 25px; display:none;">
                                                                <span><a href="gpinfolist.aspx?typeid=1"><font style="font-size: 12px;
                                                                    font-family: 宋体; color: #fc4c08">更多...</font> </a>&nbsp;&nbsp;&nbsp;&nbsp;</span>
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
                            </td>
                            <td valign="top">
                                <table cellpadding="0" cellspacing="0" style="margin-left: 10px; border: 1px solid #cccccc;">
                                    <tr>
                                        <td style="width: 217px; height: 33px; text-align: left; background-repeat: no-repeat;
                                            background-image: url(images/commnews.jpg); padding-left: 20px" class="font">
                                            &nbsp;&nbsp;项目查询
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="width: 217px; height: 233px; padding-top: 5px; text-align: center;table-layout:fixed; vertical-align: top">
                                            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                                            <ContentTemplate>
                                            <table width="217" height="195" border="0" class="fs">
                                                <tr>
                                                    <td style=" width:50px;">
                                                        类型：
                                                    </td>
                                                    <td align="left" style=" width:80px;">
                                                        <asp:DropDownList ID="ddlleixing" runat="server" 
                                                            onselectedindexchanged="ddlleixing_SelectedIndexChanged">
                                                            <asp:ListItem>请选择</asp:ListItem>
                                                            <asp:ListItem>挂牌项目</asp:ListItem>
                                                            <asp:ListItem>自由发布</asp:ListItem>
                                                        </asp:DropDownList>
                                                    </td>
                                                    <td align="left" style=" width:80px;">
                                                        <asp:DropDownList ID="ddlgongqiu" runat="server">
                                                            <asp:ListItem>请选择</asp:ListItem>
                                                            <asp:ListItem>供应信息</asp:ListItem>
                                                            <asp:ListItem>需求信息</asp:ListItem>
                                                        </asp:DropDownList>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td style=" width:40px;">
                                                        地区：
                                                    </td>
                                                    <td align="left" colspan="2">
                                                        <asp:DropDownList ID="ddlcity" AutoPostBack="true" runat="server" 
                                                            onselectedindexchanged="ddlcity_SelectedIndexChanged">
                                                        </asp:DropDownList><asp:DropDownList ID="ddlzhen" runat="server">
                                                        </asp:DropDownList>
                                                    </td>
                                                    
                                                </tr>
                                                <tr>
                                                    <td>
                                                        类别：
                                                    </td>
                                                    <td colspan="2" align="left">
                                                        <asp:DropDownList ID="ddlleibie" runat="server">
                                                        </asp:DropDownList>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        面积：
                                                    </td>
                                                    <td align="left"  colspan="2">
                                                        <input type="text" id="txtmj1" runat="server"  />
                                                    </td>
                                                    
                                                </tr>
                                                <tr>
                                                    <td>
                                                        价格：
                                                    </td>
                                                    <td colspan="2" align="left">
                                                        <asp:TextBox ID="txtjiage" runat="server"></asp:TextBox>
                                                    </td>
                                                </tr>
                                                </table>
                                                
                                            </ContentTemplate>
                                            </asp:UpdatePanel>
                                            <table width="217"  border="0" class="fs">
                                            <tr>
                                                    <td colspan="3">
                                                        <asp:ImageButton ID="imgbtntj" ImageUrl="images/sbtn.jpg" runat="server" 
                                                            onclick="imgbtntj_Click" />
                                                     
                                                    </td>
                                                </tr>
                                            </table>
                                        </td>
                                    </tr>
                                </table>
                                <table cellpadding="0" cellspacing="0" style="margin-left: 10px; border: 1px solid #cccccc;">
                                    <tr>
                                        <td style="width: 217px; height: 33px; text-align: left; background-repeat: no-repeat;
                                            background-image: url(images/commnews.jpg); padding-left: 20px" class="font">
                                            &nbsp;&nbsp;在线互动
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="width: 217px; height: 145px; padding-top: 5px; text-align: center; vertical-align: top">
                                            <table style=" height:145px; width:100%"  border="0" class="fs">
                                                <tr><td><a href="ywzx.aspx" target="_blank"><img src="images/ywzx.jpg" /></a> </td></tr>
                                                <tr><td><a href="tsjy.aspx" target="_blank"><img src="images/tsfk.jpg" /></a></td></tr>
                                            </table>
                                        </td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
            <!---->
            <tr>
                <td style="height: 10px;">
                </td>
            </tr>
            <tr>
                <td>
                    <table cellpadding="0" cellspacing="0" style="width: 1000px;">
                        <tr>
                            <td style="text-align: left;">
                                <table cellpadding="0" cellspacing="0">
                                    <tr>
                                        <td style="text-align: left;">
                                            <table cellpadding="0" cellspacing="0" style="border: 1px solid #cccccc;">
                                                <tr>
                                                    <td style="width: 363px; height: 33px; text-align: left; background-image: url(images/commnewslong.jpg);
                                                        padding-left: 20px" class="font">
                                                        &nbsp;&nbsp;供应信息
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td style="width: 363px; height: 233px; text-align: center; padding-top: 5px; vertical-align: top;">
                                                         <div class="ty" style="width:355px; text-align: left; float:left;">
                                                              <table class="guapai2" id="Table11" style=" display:block;">
                                                           <tr>
                                                           <th style=" width:79px;">信息名称</th>
                                                           <th style=" width:73px;">土地用途</th>
                                                           <th style=" width:73px;">价格</th>
                                                           <th style=" width:73px;">面积</th>
                                                           <th style=" width:73px;">发布时间</th>
                                                           </tr>
                                                           <asp:Repeater runat=server ID="repgongying"><ItemTemplate>
                                                           <tr>
                                                           <td><a href='gqinfo.aspx?id=<%#Eval("id")%>' title='<%#Eval("ProName")%>'><%#Eval("ProName").ToString().Length > 4 ? Eval("ProName").ToString().Substring(0, 4) + ".." : Eval("ProName")%></a> </td>
                                                           <td><%#Eval("dGlebePurpose")%></td>
                                                           <td><%#Eval("dQuotation")%></td>
                                                           <td><%#Eval("dArea")%></td>
                                                           <td><%#DateTime.Parse(Eval("dListingDate").ToString()).ToString("yyyy-MM-dd")%></td>
                                                           
                                                           </tr>
                                                           </ItemTemplate></asp:Repeater>
                                                            </table>
                                                            </div>
                                                            <div style="width: 95%; text-align: right; vertical-align: bottom; height: 25px">
                                                            <span><a href="gqinfolist.aspx?typeid=1"><font style="font-size: 12px; font-family: 宋体;
                                                                color: #fc4c08">更多...</font></a>&nbsp;&nbsp;&nbsp;&nbsp;</span>
                                                        </div>
                                                        
                                                    </td>
                                                </tr>
                                            </table>
                                        </td>
                                        <td>
                                            <table cellpadding="0" cellspacing="0" style="margin-left: 10px; border: 1px solid #cccccc;">
                                                <tr>
                                                    <td style="width: 363px; height: 33px; text-align: left; background-image: url(images/commnewslong.jpg);
                                                        padding-left: 20px" class="font">
                                                        &nbsp;&nbsp;需求信息
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td style="width: 363px; height: 233px; padding-top: 5px; text-align: center; vertical-align: top">
                                                         <div class="ty" style="width: 355px; text-align: left; float:left;">
                                                              <table class="guapai2" id="Table12" style=" display:block;">
                                                            <tr>
                                                           <th style=" width:80px;">信息名称</th>
                                                           <th>土地性质</th>
                                                           <th style=" width:80px;">位置</th>
                                                           <th>面积</th>
                                                           <th>发布时间</th>
                                                           </tr>
                                                           <asp:Repeater runat=server ID="repxuqiu"><ItemTemplate>
                                                           <tr>
                                                           <td><a href='xqinfo.aspx?id=<%#Eval("id")%>'><%#Eval("ProName").ToString().Length > 6 ? Eval("ProName").ToString().Substring(0, 6) + ".." : Eval("ProName")%></a></td>
                                                           <td><%#Eval("sLandProperties")%></td>
                                                           <td><%#Eval("sLocated").ToString().Length >5? Eval("sLocated").ToString().Substring(0,5)+"..":Eval("sLocated").ToString()%></td>
                                                           <td><%#Eval("sOutArea")%></td>
                                                           <td><%#DateTime.Parse( Eval("sListedData").ToString()).ToString("yyyy-MM-dd")%></td>
                                                           
                                                           </tr>
                                                           </ItemTemplate></asp:Repeater>
                                                            </table>
                                                            </div>
                                                            <div style="width: 95%; float:left; text-align: right; vertical-align: bottom; height: 25px">
                                                            <span><a href="xqinfolist.aspx?typeid=2"><font style="font-size: 12px; font-family: 宋体;
                                                                color: #fc4c08">更多...</font></a>&nbsp;&nbsp;&nbsp;&nbsp;</span>
                                                        </div>
                                                        
                                                    </td>
                                                </tr>
                                            </table>
                                        </td>
                                    </tr>
                                </table>
                            </td>
                            <td>
                                <table cellpadding="0" cellspacing="0" style="margin-left: 10px; border: 1px solid #cccccc;">
                                    <tr>
                                        <td style="width: 225px; height: 33px; text-align: left; background-repeat: no-repeat;
                                            background-image: url(images/commnews.jpg); padding-left: 20px" class="font">
                                           <span class="font">&nbsp;&nbsp;交易指南</span>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="width: 225px; height: 233px; padding-top: 5px; text-align: center; vertical-align: top">
                                         <div class="ty" style="width: 95%; text-align: left;">
                                                              <ul>
                                                                                <asp:Repeater ID="repjyzn" runat="server">
    <ItemTemplate><li><a href="shownews.aspx?lbid=<%#Eval("NewsTypeId")%>&id=<%#Eval("id")%>" target="_blank" style="text-decoration:none"><%#Eval("NewsTitle").ToString().Length > 14 ? Eval("NewsTitle").ToString().Substring(0, 14) + ".." : Eval("NewsTitle").ToString()%></a></li>
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
            <tr>
                <td>
                    <table cellpadding="0" cellspacing="0" style="width: 1000px; margin-top: 10px;">
                        <tr>
                            <td style="text-align: left;">
                                <table cellpadding="0" cellspacing="0">
                                    <tr>
                                        <td style="text-align: left;">
                                            <table cellpadding="0" cellspacing="0" style="border: 1px solid #cccccc;">
                                                <tr>
                                                    <td style="width: 363px; height: 33px;text-align: left; background-image: url('images/commnewslong.jpg'); padding-left: 20px"
                                                         class="font">
                                                        &nbsp;&nbsp;政策法规
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td style="text-align: center; padding-top: 5px; vertical-align: top;" class="style4">
                                                         <div class="ty" style="width: 95%; text-align: left;">
                                                              <ul>
                                                                                <asp:Repeater ID="repzcfg" runat="server">
    <ItemTemplate><li><a href="shownews.aspx?lbid=<%#Eval("NewsTypeId")%>&id=<%#Eval("id")%>" target="_blank" style="text-decoration:none"><%#Eval("NewsTitle").ToString().Length > 24 ? Eval("NewsTitle").ToString().Substring(0, 24) + ".." : Eval("NewsTitle").ToString()%></a></li>
    </ItemTemplate>
    </asp:Repeater>
                                                                                </ul>
                                                            </div>
                                                        <div style="width: 95%; text-align: right; vertical-align: bottom; height: 25px">
                                                            <span><a href="ShowNewsList.aspx?lbid=3"><font style="font-size: 12px; font-family: 宋体;
                                                                color: #fc4c08">更多...</font></a>&nbsp;&nbsp;&nbsp;&nbsp;</span>
                                                        </div>
                                                    </td>
                                                </tr>
                                            </table>
                                        </td>
                                        <td>
                                            <table cellpadding="0" cellspacing="0" style="margin-left: 10px; border: 1px solid #cccccc;">
                                                <tr>
                                                    <td style="width: 363px; height: 33px; text-align: left; background-image: url(images/commnewslong.jpg);
                                                        padding-left: 20px" class="font">
                                                        &nbsp;&nbsp;经验交流
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td style="width: 363px; height: 233px; padding-top: 5px; text-align: center; vertical-align: top">
                                                         <div class="ty" style="width: 95%; text-align: left;">
                                                              <ul>
                                                                                <asp:Repeater ID="repjyjl" runat="server">
    <ItemTemplate><li><a href="shownews.aspx?lbid=<%#Eval("NewsTypeId")%>&id=<%#Eval("id")%>" target="_blank" style="text-decoration:none"><%#Eval("NewsTitle").ToString().Length > 24 ? Eval("NewsTitle").ToString().Substring(0, 24) + ".." : Eval("NewsTitle").ToString()%></a></li>
    </ItemTemplate>
    </asp:Repeater>
                                                                                </ul>
                                                            </div>
                                                        <div style="width: 95%; text-align: right; vertical-align: bottom; height: 25px">
                                                            <span><a href="ShowNewsList.aspx?lbid=8"><font style="font-size: 12px; font-family: 宋体;
                                                                color: #fc4c08">更多...</font> </a>&nbsp;&nbsp;&nbsp;&nbsp;</span>
                                                        </div>
                                                    </td>
                                                </tr>
                                            </table>
                                        </td>
                                    </tr>
                                </table>
                            </td>
                            <td>
                                <table cellpadding="0" cellspacing="0" style="margin-left: 10px; border: 1px solid #cccccc;">
                                    <tr>
                                        <td style="width: 225px; height: 33px; text-align: left; background-repeat: no-repeat;
                                            background-image: url(images/commnews.jpg); padding-left: 20px" class="font">
                                            &nbsp;&nbsp;便民服务
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="width: 225px; height: 233px; padding-top: 5px; text-align: center; vertical-align: top">
                                        <div class="topright bmfw">
        <ul>
		   <li class="se"><a href="http://weather.com.cn/html/weather/101121301.shtml" target="_blank"> <img src="images/index_40.jpg" /></a></li>
        <li class="se"><a href="http://www.caac.gov.cn/s1/gncx/" target="_blank"> <img src="images/index_42.jpg" /></a></li>
        <li class="se"><a href="http://www.hao123.com/haoserver/tefudh.htm" target="_blank"> <img src="images/index_46.jpg" /></a></li>
        <li class="se"><a href="http://www.whrsks.gov.cn/" target="_blank"> <img src="images/index_48.jpg" /></a></li>
        <li class="se"><a href="http://www.12306.cn/mormhweb/" target="_blank"> <img src="images/index_52.jpg" /></a></li>
        <li class="se"><a href="http://www.chinalegalaid.gov.cn/" target="_blank"> <img src="images/index_53.jpg" /></a></li>
        <li class="se"><a href="http://sdwh.spb.gov.cn/" target="_blank"> <img src="images/index_56.jpg" /></a></li>
        <li class="se"><a href="http://www.whdzjc.com/" target="_blank"> <img src="images/index_57.jpg" /></a></li>
        <li class="se"><a href="http://www.rcrc.gov.cn/" target="_blank"> <img src="images/index_60.jpg" /></a></li>
        <li class="se"><a href="http://www.whep.gov.cn/" target="_blank"> <img src="images/index_61.jpg" /></a></li>
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
            <tr>
                <td style="height: 5px;">
                </td>
            </tr>
            <tr>
                <td style="width: 1000px; background-image: url('images/tese.jpg'); background-repeat: no-repeat;
                    height: 207px;">
                    <table cellpadding="0" cellspacing="0" style="width: 990px; border: 0px solid #eeeded;
                        margin-top: 33px;">
                        <tr>
                            <td align="left" style="width: 50px;">
                            </td>
                            <td>
                                <div id="demo" style="overflow: hidden; width: 900px; height: 143px">
                                    <table height="143" cellspacing="0" cellpadding="0" width="1800" border="0">
                                        <tr>
                                            <td id="demo1">
                                                <table cellpadding="0" cellspacing="0" style="text-align: center; font-size: 13px;
                                                    width: 1500px">
                                                    <tr>
                                                        <%=tesesb.ToString() %>
                                                        
                                                    </tr>
                                                </table>
                                            </td>
                                            <td id="demo2">
                                            </td>
                                        </tr>
                                    </table>
                                </div>
                            </td>
                        </tr>
                    </table>
                    <script language="javascript" type="text/javascript">

                        var speed = 15;
                        var speedStep = 1;
                        demo2.innerHTML = demo1.innerHTML;
                        function MarqueeToLeft() {
                            if (demo1.offsetWidth - demo.scrollLeft <= 0) {
                                demo.scrollLeft -= demo1.offsetWidth;
                            }
                            else {
                                demo.scrollLeft += speedStep;
                            }
                        }
                        var MyMar1 = setInterval(MarqueeToLeft, speed)
                        demo.onmouseover = function () { clearInterval(MyMar1) }
                        demo.onmouseout = function () { MyMar1 = setInterval(MarqueeToLeft, speed) }
                        // demo.scrollLeft++向左滚动

                        //demo.scrollLeft-- 向右滚动

                        //demo.scrolltop++ 向上滚动

                        //demo.scrolltop--向下滚动  
                    </script>
                </td>
            </tr>
            <tr>
                <td align="left" class="fs" style=" background-image:url('images/yqlj.jpg'); height:30px;">
                  
                </td>
            </tr>
           
            <tr>
                <td>
                    <uc2:WebBottom ID="WebBottom1" runat="server" />
                </td>
            </tr>
        </table>
    </div>
    <asp:HiddenField ID="LatLgnValue" runat="server" />
    </form>
    <script type="text/javascript">        document.write(unescape("%3Cspan id='_ideConac' %3E%3C/span%3E%3Cscript src='http://dcs.conac.cn/js/16/243/1038/60396433/CA162431038603964330000.js' type='text/javascript'%3E%3C/script%3E"));</script>
</body>
</html>
