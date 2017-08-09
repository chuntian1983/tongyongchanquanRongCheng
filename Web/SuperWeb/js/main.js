$(document).ready(function () {
    tabClose();
    tabCloseEven();
    $("#v").html(Version);
})

$(document).ready(function () {
    $.get("ashx/mainH.ashx?action=aname", { par: "" }, function (data) {
        $("#lblUserName").html(data);
    }, "text");
});

$(document).ready(function () {
    $(".easyui-accordionl").empty();
    var menulist = "";
    $.get("ashx/mainH.ashx?action=fun", { par: "" }, function (data) {
        $.each(data, function (i, n) {
            menulist += '<div title="' + n.menuname + '" icon="icon-sys" style="overflow:auto;">';
            menulist += '<ul>';
            $.each(n.menus, function (j, o) {
                menulist += '<div><a ref="' + o.menuid + '" href="#" rel="' + o.url + '" ><span class="icon icon-users">&nbsp;&nbsp;&nbsp;&nbsp;</span><span class="nav">' + o.menuname + '</span></a></div><br/>';
            })
            menulist += '</ul></div>';
        })
        $(".easyui-accordionl").append(menulist);
        $('.easyui-accordionl a').click(function () {
            var tabTitle = $(this).children('.nav').text();
            var url = $(this).attr("rel");
            var icon = 'icon-save';
            addTab(tabTitle, url, icon);
            $('.easyui-accordionl div').removeClass("selected");
            $(this).parent().addClass("selected");
        }).hover(function () {
            $(this).parent().addClass("hover");
        }, function () {
            $(this).parent().removeClass("hover");
        });
        $(".easyui-accordionl").accordion();
    }, "json");
});
function tabClose() {
    /*双击关闭TAB选项卡*/
    $(".tabs-inner").dblclick(function () {
        var subtitle = $(this).children(".tabs-closable").text();
        $('#tabs').tabs('close', subtitle);
    })
    /*为选项卡绑定右键*/
    $(".tabs-inner").bind('contextmenu', function (e) {
        $('#mm').menu('show', {
            left: e.pageX,
            top: e.pageY
        });

        var subtitle = $(this).children(".tabs-closable").text();

        $('#mm').data("currtab", subtitle);
        $('#tabs').tabs('select', subtitle);
        return false;
    });
}

function createFrame(url) {
    var s = '<iframe scrolling="auto" frameborder="0" style="width:100%;height:100%;"  src="' + url + '"></iframe>';
    return s;
}

function addTab(subtitle, url, icon) {
    if (!$('#tabs').tabs('exists', subtitle)) {
        $('#tabs').tabs('add', {
            title: subtitle,
            content: createFrame(url),
            closable: true,
            cache: false,
            icon: icon
        });
    } else {
        $('#tabs').tabs('select', subtitle);
    }
    tabClose();
}

//绑定右键菜单事件
function tabCloseEven() {
    //关闭当前
    $('#mm-tabclose').click(function () {
        var currtab_title = $('#mm').data("currtab");
        $('#tabs').tabs('close', currtab_title);
    })
    //全部关闭
    $('#mm-tabcloseall').click(function () {
        $('.tabs-inner span').each(function (i, n) {
            var t = $(n).text();
            $('#tabs').tabs('close', t);
        });
    });
    //关闭除当前之外的TAB
    $('#mm-tabcloseother').click(function () {
        var currtab_title = $('#mm').data("currtab");
        $('.tabs-inner span').each(function (i, n) {
            var t = $(n).text();
            if (t != currtab_title)
                $('#tabs').tabs('close', t);
        });
    });
    //关闭当前右侧的TAB
    $('#mm-tabcloseright').click(function () {
        var nextall = $('.tabs-selected').nextAll();
        if (nextall.length == 0) {
            msgShow('系统提示', '后边没有啦~~', 'error');
            return false;
        }
        nextall.each(function (i, n) {
            var t = $('a:eq(0) span', $(n)).text();
            $('#tabs').tabs('close', t);
        });
        return false;
    });
    //关闭当前左侧的TAB
    $('#mm-tabcloseleft').click(function () {
        var prevall = $('.tabs-selected').prevAll();
        if (prevall.length == 0) {
            msgShow('系统提示', '到头了，前边没有啦~~', 'error');
            return false;
        }
        prevall.each(function (i, n) {
            var t = $('a:eq(0) span', $(n)).text();
            $('#tabs').tabs('close', t);
        });
        return false;
    });

    $("#mm-exit").click(function () {
        $('#mm').menu('hide');
    })
}
jQuery(function ($) {
    $('#loginOut').click(function () {
        $.messager.confirm('系统提示', '您确定要退出本次登录吗?', function (r) {
            if (r) {
                $.get("ashx/mainH.ashx?action=emp", { p: "" }, function (d) {
                    window.location.href = "/SuperWeb/Default.aspx";
                }, "text");
            }
        });
    });
});
jQuery(function ($) {
    OnClockClick();
});
function OnClockClick() {
    var now = new Date();
    var year = now.getFullYear(); 
    var month = now.getMonth();
    var date = now.getDate();
    var day = now.getDay();
    var hour = now.getHours();
    var minu = now.getMinutes();
    var sec = now.getSeconds();
    var week;
    month = month + 1;
    if (month < 10) month = "0" + month;
    if (date < 10) date = "0" + date;
    if (hour < 10) hour = "0" + hour;
    if (minu < 10) minu = "0" + minu;
    if (sec < 10) sec = "0" + sec;
    var arr_week = new Array("星期日", "星期一", "星期二", "星期三", "星期四", "星期五", "星期六");
    week = arr_week[day];
    var time = "";
    time = year + "年" + month + "月" + date + "日" + " " + hour + ":" + minu + ":" + sec + " " + week;

    $("#lblclock").html(time);

    var timer = setTimeout("OnClockClick()", 200);
 }