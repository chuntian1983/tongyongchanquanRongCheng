jQuery(function ($) {
    GridView();
    OnComBoxloadDate();
});

jQuery(function ($) {
    $("#btnCancel").click(function () { OnReturnListClick(); });
    $("#areturn").click(function () { OnReturnListClick(); });
});
function OnReturnListClick() {
    $("#mainCenter").show();
    $("#Edit").hide();
    $('#tdg').datagrid('reload');
}
jQuery(function ($) {
    $("#btnAdd").click(function () { OnCreateClick(); });
});
function OnCreateClick() {
    $(function () {
        //验证必写循环
        $('#forms input').each(function () {
            if ($(this).attr('required') || $(this).attr('validType'))
                $(this).validatebox();
        })
    });
    //form提交
    $('#forms').form('submit', {
        url: '../ashx/ntype.ashx?action=add',
        async: false,
        onSubmit: function () {
            return $(this).form('validate');
        },
        success: function (data) {
            msgShow("提示", data, "info");
            OnReturnListClick();
        }
    });
    //刷新form
    forms.reset();
}
function GridView() {
    $('#tdg').datagrid({
        title: '新闻类型信息表', /*表头*/
        iconCls: 'icon-save', /*图标*/
        nowrap: false, /*设置为true，当数据长度超出列宽时将会自动截取。*/
        striped: true, /*设置为true将交替显示行背景。*/
        url: '../ashx/newsType.ashx?action=paging',
        remoteSort: false,
        singleSelect: true,
        sortName: 'CreateDate',
        sortOrder: 'desc',
        fit: true, /*自动补全*/
        fitColumns: true,
        rownumbers: true,
        frozenColumns: [[
	                { title: '编号', field: 'Id', width: 50, align: 'left', sortable: true }
				]],
        columns: [[
					{ field: 'NewsTypeName', title: '类型名称', width: 80, align: 'left', sortable: true },
                    { field: 'UpId', title: '父级', width: 80, align: 'left', sortable: true },
                    { field: 'TypeLevel', title: '类型级别', width: 80, align: 'left', sortable: true, formatter: function (value, row, index) { return NewsTypeLevel(value); } },
					{ field: 'Editor', title: '操作人', width: 80, align: 'left', sortable: true },
                    { field: 'CreateDate', title: '操作时间', width: 80, align: 'left', sortable: true }
				]],
        toolbar: [{
            id: 'btnadd',
            text: '新建',
            iconCls: 'icon-add',
            handler: function () {
                $("#mainCenter").hide();
                $("#Edit").show();
                $("#txtNewsTitle").textbox('setValue', "");
            }
        }, '-', {
            id: 'btncut',
            text: '修改',
            iconCls: 'icon-cut',
            handler: function () {
                /*修改操作region */
                var rows = $('#tdg').datagrid('getSelections');
                if (rows.length > 0) {
                    $.get("../ashx/newsType.ashx?action=id", { Id: rows[0].Id }, function (data) {
                        $("#txtNewsTypeName").textbox('setValue', data.NewsTypeName);
                        $("#txtUpId").combobox('setValue', data.UpId);
                        $("#txtTypeLevel").combobox('setValue', data.TypeLevel);
                        $("#txtId").val(data.Id);
                    }, "json");
                    /**/
                    $("#mainCenter").hide();
                    $("#btnAdd").hide();
                    $("#btnEdit").show();
                    $("#Edit").show();
                } else {
                    msgShow("提示", "您还没有选中要修改的信息列？", "warning");
                }
            }
        }, '-', {
            id: 'btndel',
            text: '删除',
            iconCls: 'icon-no',
            handler: function () {
                /*删除操作region*/
                var rows = $('#tdg').datagrid('getSelections');
                if (rows.length > 0) {
                    $.messager.confirm('询问提示', '您确定要删除选中的信息吗？', function (data) {
                        if (data) {
                            var ids = '';
                            if (rows.length > 0) {

                                for (var i = 0; i < rows.length; i++) {
                                    ids += rows[i].Id + ',';
                                }
                            }

                            $.get("../ashx/newsType.ashx?action=del", { id: ids }, function (data) {
                                msgShow("提示", data, "info");
                                $('#tdg').datagrid('clearSelections');
                                $('#tdg').datagrid('reload');
                            }, "text");
                        }
                    });
                }
                else {
                    msgShow("提示", "您还没有选中要删除的信息？", "warning");
                }
                /*end*/
            }
        }
     ]
    });
}

function OnComBoxloadDate() {
    $('#txtUpId').combobox({
        url: '../ashx/newsType.ashx?action=list',
        valueField: 'id',
        textField: 'text'
    });
}

jQuery(function ($) {
    $("#btnEdit").click(function () { OnUpdateClick(); });
});
function OnUpdateClick() {
    $(function () {
        //验证必写循环
        $('#forms input').each(function () {
            if ($(this).attr('required') || $(this).attr('validType'))
                $(this).validatebox();
        })
    });
    //form提交
    $('#forms').form('submit', {
        url: '../ashx/newsType.ashx?action=up',
        async: false,
        onSubmit: function () {
            return $(this).form('validate');
        },
        success: function (data) {
            msgShow("提示", data, "info");
            OnReturnListClick();
        }
    });
    //刷新form
    forms.reset();
}

function NewsTypeLevel(type) {
    var str;
    switch (type) {
        case "1":
            str = "一级";
            break;
        case "2":
            str = "二级";
            break;
        case "3":
            str = "三级";
            break;
        case "4":
            str = "四级";
            break;
        case "5":
            str = "五级";
            break;
        case "6":
            str = "六级";
            break;
        case "7":
            str = "七级";
            break;
        case "8":
            str = "八级";
            break;
        case "9":
            str = "九级";
            break;
        case "10":
            str = "十级";
            break;
    }
    return str;
}