jQuery(function ($) {
    GridView();
});
function GridView() {
    $('#tdg').datagrid({
        title: '挂牌项目类型信息表', /*表头*/
        iconCls: 'icon-save', /*图标*/
        nowrap: false, /*设置为true，当数据长度超出列宽时将会自动截取。*/
        striped: true, /*设置为true将交替显示行背景。*/
        url: '../ashx/proType.ashx?action=paging',
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
					{ field: 'ListedProjectTypeName', title: '挂牌项目名称', width: 80, align: 'left', sortable: true },
                    { field: 'ListedProjectTypeOrder', title: '排列顺序', width: 80, align: 'left', sortable: true },      
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
                $("#txtListedProjectTypeName").textbox('setValue', "");
            }
        }, '-', {
            id: 'btncut',
            text: '修改',
            iconCls: 'icon-cut',
            handler: function () {
                /*修改操作region */
                var rows = $('#tdg').datagrid('getSelections');
                if (rows.length > 0) {
                    $.get("../ashx/proType.ashx?action=id", { Id: rows[0].Id }, function (data) {
                        $("#txtListedProjectTypeName").textbox('setValue', data.ListedProjectTypeName);
                        $("#txtListedProjectTypeOrder").textbox('setValue', data.ListedProjectTypeOrder);
                        $("#txtId").val(data.Id);
                    }, "json");
                    /**/
                    $("#mainCenter").hide();
                    $("#btnAdd").hide();
                    $("#btnEdit").show();
                    $("#Edit").show();
                } else {
                    msgShow("提示", "您还没有选中要修改的列信息？", "warning");
                }
            }
        }
      ]
    });
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
        url: '../ashx/proType.ashx?action=add',
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
        url: '../ashx/proType.ashx?action=up',
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