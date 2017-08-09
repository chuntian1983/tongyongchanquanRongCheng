jQuery(function ($) {
    GridView();
});
function GridView() {
    $('#tdg').datagrid({
        title: '业务咨询信息列表', /*表头*/
        iconCls: 'icon-save', /*图标*/
        nowrap: true, /*设置为true，当数据长度超出列宽时将会自动截取。*/
        striped: true, /*设置为true将交替显示行背景。*/
        url: '../ashx/consulting.ashx?action=paging',
        remoteSort: false,
        sortName: 'ConsDate',
        singleSelect: true,
        sortOrder: 'desc',
        fit: true, /*自动补全*/
        fitColumns: false,
        rownumbers: true,
        frozenColumns: [[
	                { title: '编号', field: 'Id', width: 50, align: 'left', sortable: true },
                    { field: 'UserName', title: '姓名', width: 100, align: 'left', sortable: true },
					{ field: 'UserAddress', title: '地址', width: 100, align: 'left', sortable: true }
				]],
        columns: [[
                    { field: 'UserTel', title: '电话', width: 100, align: 'left', sortable: true },
                    { field: 'UserEmail', title: '邮箱', width: 150, align: 'left', sortable: true },
                    { field: 'ConsTitle', title: '主题', width: 150, align: 'left', sortable: true },
                    { field: 'ConsContent', title: '内容', width: 150, align: 'left', sortable: true },
                    { field: 'ConsDate', title: '咨询时间', width: 100, align: 'left', sortable: true },
                    { field: 'ReplyContent', title: '回复内容', width: 150, align: 'left', sortable: true },
                    { field: 'ReplyDate', title: '回复时间', width: 100, align: 'left', sortable: true, formatter: function (value, row, index) { return row.ReplyContent != "" ? value : ""; } },
                    { field: 'ReplyUser', title: '回复人', width: 80, align: 'left', sortable: true }
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
                    $.messager.confirm('询问提示', '您确定要删除选中的编号为 [' + rows[0].Id + '] 的 [' + rows[0].ConsTitle + '] 这一条信息吗？', function (data) {
                        if (data) {
                            $.get("../ashx/consulting.ashx?action=del", { Id: rows[0].Id }, function (data) {
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
            text: '回复',
            iconCls: 'icon-cut',
            handler: function () {
                /*修改操作region */
                var rows = $('#tdg').datagrid('getSelections');
                if (rows.length > 0) {
                    EmptyTextClick();
                    $.get("../ashx/consulting.ashx?action=Id", { Id: rows[0].Id }, function (data) {
                        $("#txtUserName").textbox('setValue', data.UserName);
                        $("#txtUserAddress").textbox('setValue', data.UserAddress);
                        $("#txtUserTel").textbox('setValue', data.UserTel);
                        $("#txtUserEmail").textbox('setValue', data.UserEmail);
                        $("#txtConsTitle").textbox('setValue', data.ConsTitle);
                        $("#txtConsContent").val(data.ConsContent);
                        $("#txtConsDate").textbox('setValue', data.ConsDate.replace("T", " "));
                        $("#txtReplyContent").val(data.ReplyContent);
                        $("#txtReplyDate").textbox('setValue', data.ReplyDate.replace("T", " "));
                        $("#txtReplyUser").textbox('setValue', data.ReplyUser);
                        $("#txtId").val(data.Id);
                    }, "json");
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

jQuery(function ($) {
    $("#btnCancel").click(function () { OnReturnNewsListClick(); });
    $("#areturn").click(function () { OnReturnNewsListClick(); });
});

function OnReturnNewsListClick() {
    $("#mainCenter").show();
    $("#Edit").hide();
    $('#tdg').datagrid('reload');
}

function EmptyTextClick() {
    $("#txtUserName").textbox('setValue',"");
    $("#txtUserAddress").textbox('setValue',"");
    $("#txtUserTel").textbox('setValue', "");
    $("#txtUserEmail").textbox('setValue',"");
    $("#txtConsTitle").textbox('setValue',"");
    $("#txtConsContent").val("");
    $("#txtConsDate").textbox('setValue',"");
    $("#txtReplyContent").val("");
    $("#txtReplyDate").textbox('setValue',"");
    $("#txtReplyUser").textbox('setValue',"");
    $("#txtId").val("0");
}

jQuery(function ($) {
    $("#btnAdd").click(function () { OnCreateClick(); });
});
function OnCreateClick() {  
    //form提交
    $('#forms').form('submit', {
        url: '../ashx/consulting.ashx?action=add',
        async: false,
        onSubmit: function () {
            return $(this).form('validate');
        },
        success: function (data) {
            msgShow("提示", data, "info");
            OnReturnNewsListClick();
        }
    });
    //刷新form
    forms.reset();
}
jQuery(function ($) {
    $("#btnEdit").click(function () { OnUpdateClick(); });
});
function OnUpdateClick() {
   
    //form提交
    $('#forms').form('submit', {
        url: '../ashx/consulting.ashx?action=up',
        async: false,
        onSubmit: function () {
            return $(this).form('validate');
        },
        success: function (data) {
            msgShow("提示", data, "info");
            OnReturnNewsListClick();
        }
    });
    //刷新form
    forms.reset();
}
jQuery(function ($) {
    $("#btnQuery").click(function () { OnSelectClick(); });
});
function OnSelectClick() {
    if ("" == $("#tConsTitle").textbox('getValue')) {
        msgShow("提示", "您还没有输入要搜索的条件？", "warning");
        return;
    }
    var consTitle = $("#tConsTitle").textbox('getValue');
    var url = '../ashx/consulting.ashx?' + $.param({ action: "paging", ConsTitle: consTitle });
    $('#tdg').datagrid({ url: url });
    $('#tdg').datagrid('reload');
}
