jQuery(function ($) {
    GridView();
});
function GridView() {
    $('#tdg').datagrid({
        title: '友情链接信息列表', /*表头*/
        iconCls: 'icon-save', /*图标*/
        nowrap: true, /*设置为true，当数据长度超出列宽时将会自动截取。*/
        striped: true, /*设置为true将交替显示行背景。*/
        url: '../ashx/link.ashx?action=paging',
        remoteSort: false,
        sortName: 'CreateDate',
        singleSelect: true,
        sortOrder: 'desc',
        fit: true, /*自动补全*/
        fitColumns: true,
        rownumbers: true,
        frozenColumns: [[
	                { title: '编号', field: 'Id', width: 50, align: 'left', sortable: true },
                     { field: 'LinkName', title: '友情链接名称', width: 200, align: 'left', sortable: true },
					{ field: 'LinkUrl', title: '友情链接网址', width: 200, align: 'left', sortable: true }
				]],
        columns: [[
                    { field: 'LinkImgurl', title: '友情链接图片', width: 200, align: 'left', sortable: true },
                    { field: 'Editor', title: '操作人', width: 50, align: 'left', sortable: true },
                    { field: 'CreateDate', title: '操作时间', width: 50, align: 'left', sortable: true, formatter: function (value, row, index) { return value.substring(0, 10); } }
				]],
        toolbar: [{
            id: 'btnadd',
            text: '新建',
            iconCls: 'icon-add',
            handler: function () {
                $("#mainCenter").hide();
                $("#Edit").show();
                $("#btnAdd").show();
                $("#btnEdit").hide();
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
                    $.messager.confirm('询问提示', '您确定要删除选中的编号为 [' + rows[0].Id + '] 的 [' + rows[0].LinkName + '] 这一条信息吗？', function (data) {
                        if (data) {
                            $.get("../ashx/link.ashx?action=del", { id: rows[0].Id }, function (data) {
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
                    /**/
                    EmptyTextClick();
                    $.get("../ashx/link.ashx?action=id", { Id: rows[0].Id }, function (d) {
                        $("#txtLinkName").textbox('setValue', d.LinkName);
                        $("#txtLinkUrl").textbox('setValue', d.LinkUrl);
                        $("#txtId").val(d.Id); 
                    }, "json");
                    /**/
                    $("#mainCenter").hide();
                    $("#btnAdd").hide();
                    $("#btnEdit").show();
                    $("#Edit").show();
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

function EmptyTextClick() {
    $("#txtLinkName").textbox('setValue', "");
    $("#txtLinkUrl").textbox('setValue', "");
    $("#txtLinkImgurl").val("");
    $("#txtId").val("0");
 }

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
        url: '../ashx/link.ashx?action=add',
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
        url: '../ashx/link.ashx?action=up',
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