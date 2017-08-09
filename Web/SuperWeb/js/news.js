jQuery(function ($) {
    GridView();
    $('#orgList').window('close');
    $('#newtype').window('close');
});
function GridView() {
    $('#tdg').datagrid({
        title: '新闻信息列表', /*表头*/
        iconCls: 'icon-save', /*图标*/
        nowrap: true, /*设置为true，当数据长度超出列宽时将会自动截取。*/
        striped: true, /*设置为true将交替显示行背景。*/
        url: '../ashx/news.ashx?action=paging',
        remoteSort: false,
        sortName: 'CreateDate',
        singleSelect: true,
        sortOrder: 'desc',
        fit: true, /*自动补全*/
        fitColumns: true,
        rownumbers: true,
        frozenColumns: [[
	                { title: '编号', field: 'Id', width: 50, align: 'left', sortable: true },
                     { field: 'UnitCode', title: '组织单位名称', width: 100, align: 'left', sortable: true },
					{ field: 'NewsTypeId', title: '新闻类型', width: 100, align: 'left', sortable: true }
				]],
        columns: [[
                    { field: 'NewsTitle', title: '新闻主标题', width: 150, align: 'left', sortable: true },
                    { field: 'NewsImg', title: '新闻图片', width: 100, align: 'left', sortable: true },
                    { field: 'NumClicks', title: '点击数量', width: 50, align: 'left', sortable: true },
                    { field: 'IfShow', title: '是否显示', width: 50, align: 'left', sortable: true, formatter: function (value, row, index) { var c = value == 0 ? "否" : "是"; return c += "&nbsp;&nbsp;<img onclick=\"OnRowsStateClick('" + row.Id + "','IfShow','" + row.IfShow + "');\" src='../images/" + row.IfShow + ".gif' align='absmiddle' />"; } },
                    { field: 'IfHost', title: '是否热点', width: 50, align: 'left', sortable: true, formatter: function (value, row, index) { var h = value == 0 ? "否" : "是"; return h += "&nbsp;&nbsp;<img onclick=\"OnRowsStateClick('" + row.Id + "','IfHost','" + row.IfHost + "');\" src='../images/" + row.IfHost + ".gif' align='absmiddle' />"; } },
                    { field: 'IfDel', title: '是否删除', width: 50, align: 'left', sortable: true, formatter: function (value, row, index) { var d = value == 0 ? "否" : "是"; return d += "&nbsp;&nbsp;<img onclick=\"OnRowsStateClick('" + row.Id + "','IfDel','" + row.IfDel + "');\" src='../images/" + row.IfDel + ".gif' align='absmiddle' />"; } },
                    { field: 'IfUp', title: '是否置顶', width: 50, align: 'left', sortable: true, formatter: function (value, row, index) { var u = value == 0 ? "否" : "是"; return u += "&nbsp;&nbsp;<img onclick=\"OnRowsStateClick('" + row.Id + "','IfUp','" + row.IfUp + "');\" src='../images/" + row.IfUp + ".gif' align='absmiddle' />"; } },
                    { field: 'IsCheck', title: '审核状态', width: 50, align: 'left', sortable: true, formatter: function (value, row, index) { var s = value == 0 ? "<span style='color:red;'>未审核</span>" : "<span style='color:blue;'>通过</span>"; return s += "&nbsp;&nbsp;<img onclick=\"OnRowsStateClick('" + row.Id + "','IsCheck','" + row.IsCheck + "');\" src='../images/" + row.IsCheck + ".gif' align='absmiddle' />"; } },
                    { field: 'Editor', title: '操作人', width: 50, align: 'left', sortable: true },
                    { field: 'CreateDate', title: '操作时间', width: 50, align: 'left', sortable: true, formatter: function (value, row, index) { return value.substring(0, 10); } }
				]],
        toolbar: [{
            id: 'btnadd',
            text: '新建',
            iconCls: 'icon-add',
            handler: function () {
                $("#mainCenter").hide();
                $("#newsEdit").show();
                $("#btnAddNews").show();
                $("#btnEditNews").hide();
                EmptyTextClick();
            }
        }, '-', {
            id: 'btndel',
            text: '删除',
            iconCls: 'icon-no',
            handler: function () {
                /*删除操作region*/
                var rows = $('#tdg').datagrid('getSelections');
                if (rows.length > 0) {
                    $.messager.confirm('询问提示', '您确定要删除选中的编号为 [' + rows[0].Id + '] 的 [' + rows[0].NewsTypeId + '] 这一条信息吗？', function (data) {
                        if (data) {
                            $.get("../ashx/news.ashx?action=del", { id: rows[0].Id }, function (data) {
                                msgShow("提示", data, "info");
                                $('#tdg').datagrid('clearSelections');
                                $('#tdg').datagrid('reload');
                            }, "text");
                        }
                    });
                }
                else {
                    msgShow("提示", "您还没有选中要删除的列信息？", "warning");
                }
                /*end*/
            }
        }, '-', {
            id: 'btncut',
            text: '修改',
            iconCls: 'icon-cut',
            handler: function () {
                /*修改操作region */
                var rows = $('#tdg').datagrid('getSelections');

                if (rows.length > 0) {
//                    alert('11');
                    /**/
                    EmptyTextClick();
                    $.get("../ashx/news.ashx?action=Id", { Id: rows[0].Id }, function (data) {
                        $("#txtNewsTitle").textbox('setValue', data.NewsTitle);
                        $("#txtNewsTypeId").textbox('setValue', data.NewsTypeId);
                        $("#txtUnitCode").textbox('setValue', data.UnitCode);
                        $("#txtNewsSubheading").textbox('setValue', data.NewsSubheading);
                        $("#txtNewsSource").textbox('setValue', data.NewsSource);
                        $("#txtContent").textbox('setValue', data.Content);
                        $("#txtKeyword").textbox('setValue', data.Keyword);
                        $("#txtIfHost").combobox('setValue', data.IfHost);
                        $("#txtIfUp").combobox('setValue', data.IfUp);
                        editor1.html(data.NewsContent);
                        $("#txtId").val(data.Id);
                        $("#txtNumClicks").val(data.NumClicks);
                        $("#txtIfDel").val(data.IfDel);
                    }, "json");
                    /**/
                    $("#mainCenter").hide();
                    $("#btnAddNews").hide();
                    $("#btnEditNews").show();
                    $("#newsEdit").show();
                } else {
                    msgShow("提示", "您还没有选中要修改的列信息？", "warning");
                }
                /*end*/
            }
        }
               ],
        pagination: true,
        pageSize: _rows
    });
    var p = $('#tdg').datagrid('getPager');
    $(p).pagination({
        onBeforeRefresh: function () {
        }
    });
}
function OnRowsStateClick(_id, _rn, _vl) {
    $.messager.confirm('询问提示', '您确定要修改新闻的状态吗？', function (data) {
        if (data) {
            $.get("../ashx/news.ashx?action=rs", { Id: _id, Rows: _rn, Vale: _vl }, function (data) {
                slide("提示", data);
                $('#tdg').datagrid('reload');
            }, "text");
        }
    });
}
jQuery(function ($) {
    $("#btnQuery").click(function () { OnSelectClick(); });
});
function OnSelectClick() {


    var tNewsTitle = '';
    var cbNewsType = '';
if ($("#tNewsTitle").textbox('getValue') == "") {
//    msgShow("提示", "新闻内容不能为空！", "error");
//    $("#tNewsTitle").focus();
//    return;
    }
    else{
        tNewsTitle = $("#tNewsTitle").textbox('getValue');
    }
    if ( $("#cbnewstype").combobox('getValue')!="") {
        cbNewsType = $("#cbnewstype").combobox('getValue');
    }
    
    var url = '../ashx/news.ashx?' + $.param({ action: "paging", NewsTitle: tNewsTitle,NewsType:cbNewsType });
    $('#tdg').datagrid({ url: url });
    $('#tdg').datagrid('reload');
}
jQuery(function ($) {
    $("#btnCancel").click(function () { OnReturnNewsListClick(); });
    $("#areturn").click(function () { OnReturnNewsListClick(); });
});

function OnReturnNewsListClick() {
    $("#mainCenter").show();
    $("#newsEdit").hide();
    $('#tdg').datagrid('reload');
}

var editor1;
KindEditor.ready(function (K) {
    editor1 = K.create('#txtNewsContent', {
        cssPath: '../../kindeditor/plugins/code/prettify.css',
        uploadJson: '../../kindeditor/upload_json.ashx',
        fileManagerJson: '../../kindeditor/file_manager_json.ashx',
        //关键代码，当失去焦点时执行 this.sync(); -- 没这句没法获得文本值
        afterBlur: function () { editor1.sync(); },
        allowFileManager: true
    });
});

jQuery(function ($) {
    $("#btnAddNews").click(function () { OnCreateNewsClick(); });
});
function OnCreateNewsClick() {
    $(function () {
        //验证必写循环
        $('#formNews input').each(function () {
            if ($(this).attr('required') || $(this).attr('validType'))
                $(this).validatebox();
        })
    });
    //form提交
    $('#formNews').form('submit', {
        url: '../ashx/news.ashx?action=add',
        async: false,
        onSubmit: function () {
            return $(this).form('validate');
        },
        success: function (data) {
            msgShow("提示", data, "info");
        }
    });
    //刷新form
    formNews.reset();
    editor1.html(""); //Kindeditor 清空
}
jQuery(function ($) {
    $("#btnEditNews").click(function () { OnUpdateNewsClick(); });
});
function OnUpdateNewsClick() {
    $(function () {
        //验证必写循环
        $('#formNews input').each(function () {
            if ($(this).attr('required') || $(this).attr('validType'))
                $(this).validatebox();
        })
    });
    //form提交
    $('#formNews').form('submit', {
        url: '../ashx/news.ashx?action=up',
        async: false,
        onSubmit: function () {
            
            return $(this).form('validate');
           
        },
        success: function (data) {
            msgShow("提示", data, "info");
        }
    });
    //刷新form
    formNews.reset();
    editor1.html(""); //Kindeditor 清空
}
var zTree;
var tTree;
var setting = {
    showLine: true,
    callback: {
        click: zTreeOnClick,
        dblclick: zTreeOnDblclick
    }
};
var settings = {
    showLine: true,
    callback: {
        click: typeTreeOnClick,
        dblclick: typeTreeOnDblclick
    }
};
jQuery(function ($) {
    $("#btnNewsType").click(function () { OnLoadNewsType(); });
});

function OnLoadNewsType() {
    $('#newtype').window('open');
    $.get("../ashx/newsType.ashx?action=tree", { Id: "0" }, function (data) {
        tTree = $("#type").zTree(settings, data);     
    }, "json");
}
function typeTreeOnClick(event, treeId, treeNode) {
    $.get("../ashx/newsType.ashx?action=node", { UpId: treeNode.id }, function (data) {
        if (data.length != 0) {
            if (treeNode.nodes.length == 0) {
                var nodes = tTree.addNodes(treeNode, data);
            }
        }
        treeNode.open = true;
    }, "json");
 }
 function typeTreeOnDblclick(event, treeId, treeNode) {
     $("#txtNewsTypeId").textbox('setValue', treeNode.id);
     $('#newtype').window('close');
 }
//组织单位树
 jQuery(function ($) {
     $("#btnUnitCode").click(function () { OnLoadUnitCode(); });
 });

 function OnLoadUnitCode() {
     $('#orgList').window('open');
     $.get("../ashx/org.ashx?action=list", { id: "" }, function (data) {
         zTree = $("#org").zTree(setting, data);
     }, "json");
 }
 function zTreeOnClick(event, treeId, treeNode) {
     AddNodes(treeNode.id, treeNode);
 }

 function AddNodes(orgcode, Node) {
     $.get("../ashx/org.ashx?action=node", { OrgCode: orgcode }, function (data) {
         if (data.length != 0) {
             if (Node.nodes.length == 0) {
                 var nodes = zTree.addNodes(Node, data);
             }
         }
         Node.open = true;
     }, "json");
 }
 function zTreeOnDblclick(event, treeId, treeNode) {
     $("#txtUnitCode").textbox('setValue', treeNode.id);
     $('#orgList').window('close');
 }
 function EmptyTextClick() {
     $("#txtNewsTitle").textbox('setValue', "");
     $("#txtNewsTypeId").textbox('setValue', "");
     $("#txtUnitCode").textbox('setValue', "");
     $("#txtNewsSubheading").textbox('setValue', "");
     $("#txtNewsSource").textbox('setValue', "");
     $("#txtContent").textbox('setValue', "");
     $("#txtKeyword").textbox('setValue', "");
     $("#txtIfHost").combobox('setValue', "0");
     $("#txtIfUp").combobox('setValue', "0");
     editor1.html("");
     $("#txtId").val("0");
     $("#txtNumClicks").val("0");
     $("#txtIfDel").val("0");
 }

