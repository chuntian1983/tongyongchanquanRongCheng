jQuery(function ($) {
    GridView();
});
function GridView() {
    $('#tdg').datagrid({
        title: '系统菜单信息列表',
        iconCls: 'icon-save',
        nowrap: true,
        striped: true,
        url: '../ashx/sysfun.ashx?action=paging',
        remoteSort: false,
        sortName: 'ParentNodeId',
        singleSelect: true,
        sortOrder: 'asc',
        fit: true,
        fitColumns: true,
        rownumbers: true,
        frozenColumns: [[
	                { title: '编号', field: 'NodeId', width: 50, align: 'left', sortable: true },
                     { field: 'DisplayName', title: '菜单名称', width: 300, align: 'left', sortable: true },
					{ field: 'NodeURL', title: '菜单地址', width: 300, align: 'left', sortable: true }
				]],
        columns: [[
                    { field: 'DisplayOrder', title: '菜单顺序', width: 300, align: 'left', sortable: true },
                     { field: 'ParentNodeId', title: '父节点ID', width: 300, align: 'left', sortable: true }                   
				]],
        toolbar: [{
            id: 'btnadd',
            text: '新建',
            iconCls: 'icon-add',
            handler: function () {
                OnComBoxloadDate();
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
                    $.messager.confirm('询问提示', '您确定要删除选中的编号为 [' + rows[0].NodeId + '] 的 [' + rows[0].DisplayName + '] 这一条信息吗？', function (data) {
                        if (data) {
                            $.get("../ashx/sysfun.ashx?action=del", { Id: rows[0].NodeId }, function (data) {
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
                    OnComBoxloadDate();
                    $.get("../ashx/sysfun.ashx?action=id", { Id: rows[0].NodeId }, function (data) {
                        $("#txtDisplayName").textbox('setValue', data.DisplayName);
                        $("#txtNodeURL").textbox('setValue', data.NodeURL);
                        $("#txtDisplayOrder").textbox('setValue', data.DisplayOrder);
                        $("#txtParentNodeId").combobox('setValue', data.ParentNodeId);
                        $("#txtNodeId").val(data.NodeId);
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
        ]
    });
    var p = $('#tdg').datagrid('getPager');
    $(p).pagination({
        onBeforeRefresh: function () {
        }
    });
}

function EmptyTextClick() {
    $("#txtDisplayName").textbox('setValue', "");
    $("#txtNodeURL").textbox('setValue', "");
    $("#txtDisplayOrder").textbox('setValue', "");
    $("#txtNodeId").val("0");
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
        $('#forms input').each(function () {
            if ($(this).attr('required') || $(this).attr('validType'))
                $(this).validatebox();
        })
    });
    $('#forms').form('submit', {
        url: '../ashx/sysfun.ashx?action=add',
        async: false,
        onSubmit: function () {
            return $(this).form('validate');
        },
        success: function (data) {
            msgShow("提示", data, "info");
            OnReturnListClick();
        }
    });
    forms.reset();
}

jQuery(function ($) {
    $("#btnEdit").click(function () { OnUpdateClick(); });
});
function OnUpdateClick() {
    $(function () {
        $('#forms input').each(function () {
            if ($(this).attr('required') || $(this).attr('validType'))
                $(this).validatebox();
        })
    });
    $('#forms').form('submit', {
        url: '../ashx/sysfun.ashx?action=up',
        async: false,
        onSubmit: function () {
            return $(this).form('validate');
        },
        success: function (data) {
            msgShow("提示", data, "info");
            OnReturnListClick();
        }
    });
    forms.reset();
}

function OnComBoxloadDate() {
    $('#txtParentNodeId').combobox({
        url: '../ashx/sysfun.ashx?action=parent',
        valueField: 'id',
        textField: 'text'
    });
}
