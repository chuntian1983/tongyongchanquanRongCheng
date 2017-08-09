jQuery(function ($) {
    GridView();
});
function GridView() {
    $('#tdg').datagrid({
        title: '下载文件信息列表', /*表头*/
        iconCls: 'icon-save', /*图标*/
        nowrap: true, /*设置为true，当数据长度超出列宽时将会自动截取。*/
        striped: true, /*设置为true将交替显示行背景。*/
        url: '../ashx/file.ashx?action=paging',
        remoteSort: false,
        sortName: 'CreateDate',
        singleSelect: true,
        sortOrder: 'desc',
        fit: true, /*自动补全*/
        fitColumns: true,
        rownumbers: true,
        frozenColumns: [[
	                { title: '编号', field: 'Id', width: 50, align: 'left', sortable: true },
                     { field: 'FileName', title: '文件名称', width: 180, align: 'left', sortable: true },
					{ field: 'FileTypeSuffix', title: '文件类型后缀', width: 180, align: 'left', sortable: true }
				]],
        columns: [[
                    { field: 'FileTypeName', title: '文件类型', width: 180, align: 'left', sortable: true },
                    { field: 'FilePath', title: '文件路径', width: 180, align: 'left', sortable: true },                 
                    { field: 'Editor', title: '操作人', width: 80, align: 'left', sortable: true },
                    { field: 'CreateDate', title: '操作时间', width: 80, align: 'left', sortable: true, formatter: function (value, row, index) { return value.substring(0, 10); } }
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
                    $.messager.confirm('询问提示', '您确定要删除选中的编号为 [' + rows[0].Id + '] 的 [' + rows[0].FileName + '] 这一条信息吗？', function (data) {
                        if (data) {
                            $.get("../ashx/file.ashx?action=del", { id: rows[0].Id }, function (data) {
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
                    $.get("../ashx/file.ashx?action=Id", { Id: rows[0].Id }, function (data) {
                        $("#txtFileName").textbox('setValue', date.FileName);
                        $("#txtFileTypeName").combobox('setValue', data.FileTypeName);
                        $("#txtId").val(Date.Id);
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
    $("#txtFileName").textbox('setValue', '');
    $("#txtFilePath").val("");
    $("#txtId").val("0");
 }
jQuery(function ($) {
    OnComBoxloadDate();
});
function OnComBoxloadDate() {
    $('#txtFileTypeName').combobox({
        url: '../ashx/newsType.ashx?action=upid&UpId=7',
        valueField: 'id',
        textField: 'text'
    });
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
        url: '../ashx/file.ashx?action=up',
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
        url: '../ashx/file.ashx?action=add',
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
    $("#btnCancel").click(function () { OnReturnListClick(); });
    $("#areturn").click(function () { OnReturnListClick(); });
});

function OnReturnListClick() {
    $("#mainCenter").show();
    $("#Edit").hide();
    $('#tdg').datagrid('reload');
}

jQuery(function ($) {
    $("#btnQuery").click(function () { OnSelectClick(); });
});
function OnSelectClick() {

    if ($("#tFileName").datebox('getValue') == "") {
        msgShow("提示", "搜索内容不能为空！", "error");
        $("#tFileName").focus();
        return;
    }
    var tFileName = $("#tFileName").datebox('getValue');
    var url = '../ashx/file.ashx?' + $.param({ action: "paging", FileName: tFileName });
    $('#tdg').datagrid({ url: url });
    $('#tdg').datagrid('reload');
}