jQuery(function ($) {
    GridView();
});
function GridView() {
    $('#tdg').datagrid({
        title: '会员信息列表', /*表头*/
        iconCls: 'icon-save', /*图标*/
        nowrap: true, /*设置为true，当数据长度超出列宽时将会自动截取。*/
        striped: true, /*设置为true将交替显示行背景。*/
        url: '../ashx/member.ashx?action=paging',
        remoteSort: false,
        sortName: 'CreateDate',
        singleSelect: true,
        sortOrder: 'desc',
        fit: true, /*自动补全*/
        fitColumns: true,
        rownumbers: true,
        frozenColumns: [[
	                { title: '编号', field: 'Id', width: 30, align: 'left', sortable: true },
                     { field: 'UserLogName', title: '会员登陆账号', width: 80, align: 'left', sortable: true },
					{ field: 'UserName', title: '会员姓名', width: 80, align: 'left', sortable: true }
				]],
        columns: [[
                    { field: 'UserSex', title: '会员性别', width: 40, align: 'left', sortable: true },
                    { field: 'CardId', title: '身份证号码', width: 80, align: 'left', sortable: true },
                    { field: 'UserAddress', title: '会员住址', width: 80, align: 'left', sortable: true },
                    { field: 'UserTel', title: '会员电话', width: 80, align: 'left', sortable: true },
                    { field: 'UserEmail', title: '会员邮箱', width: 80, align: 'left', sortable: true },
                    { field: 'UserLogNum', title: '登陆次数', width: 50, align: 'left', sortable: true },
                    { field: 'UserState', title: '状态', width: 50, align: 'left', sortable: true, formatter: function (value, row, index) { var s = value == 0 ? "<span style='color:red;'>未审核</span>" : "<span style='color:blue;'>通过</span>"; return s += "&nbsp;&nbsp;<img onclick=\"OnRowsStateClick('" + row.Id + "','UserState','" + row.UserState + "');\" src='../images/" + row.UserState + ".gif' align='absmiddle' />"; }  },
                    { field: 'IsCheck', title: '越级审核权限', width: 50, align: 'left', sortable: true, formatter: function (value, row, index) { var u = value == 0 ? "否" : "是"; return u += "&nbsp;&nbsp;<img onclick=\"OnRowsStateClick('" + row.Id + "','IsCheck','" + row.IsCheck + "');\" src='../images/" + row.IsCheck + ".gif' align='absmiddle' />"; } },
                    { field: 'EndDate', title: '最后登陆时间', width: 80, align: 'left', sortable: true },
                    { field: 'CreateDate', title: '创建时间', width: 80, align: 'left', sortable: true, formatter: function (value, row, index) { return value.substring(0, 10); } }
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
                    $.messager.confirm('询问提示', '您确定要删除选中的编号为 [' + rows[0].Id + '] 的 [' + rows[0].UserName + '] 这一条信息吗？', function (data) {
                        if (data) {
                            $.get("../ashx/member.ashx?action=del", { Id: rows[0].Id }, function (data) {
                               slide("提示", data);
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
                var rows = $('#tdg').datagrid('getSelections');
                if (rows.length > 0) {
                    EmptyTextClick();
                    $.get("../ashx/member.ashx?action=id", { Id: rows[0].Id }, function (data) {
                        $("#txtUserLogName").textbox('setValue', data.UserLogName);
                        $("#txtUserLogPass").textbox('setValue', data.UserLogPass);
                        $("#txtUserName").textbox('setValue', data.UserName);
                        $("#txtUserSex").combobox('setValue', data.UserSex);
                        $("#txtCardId").textbox('setValue', data.CardId);
                        $("#txtUserAddress").textbox('setValue', data.UserAddress);
                        $("#txtUserTel").textbox('setValue', data.UserTel);
                        $("#txtUserEmail").textbox('setValue', data.UserEmail);
                        $("#txtUserLogNum").val(data.UserLogNum);
                        $("#txtUserState").combobox('setValue', data.UserState);
                        $("#txtIsCheck").combobox('setValue', data.IsCheck);
                        $("#txtId").val(data.Id);
                    }, "json");
                    $("#mainCenter").hide();
                    $("#btnAdd").hide();
                    $("#btnEdit").show();
                    $("#Edit").show();
                } else {
                    msgShow("提示", "您还没有选中要修改的列信息？", "warning");
                }
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
    $.messager.confirm('询问提示', '您确定要修改会员的状态吗？', function (data) {
        if (data) {
            $.get("../ashx/member.ashx?action=rs", { Id: _id, Rows: _rn, Vale: _vl }, function (data) {
                slide("提示", data);
                $('#tdg').datagrid('reload');
            }, "text");
        }
    });
}
function EmptyTextClick() {
    $("#txtUserLogName").textbox('setValue', "");
    $("#txtUserLogPass").textbox('setValue', "");
    $("#txtUserName").textbox('setValue', "");
    $("#txtUserSex").combobox('setValue', "男");
    $("#txtCardId").textbox('setValue', "");
    $("#txtUserAddress").textbox('setValue', "");
    $("#txtUserTel").textbox('setValue', "");
    $("#txtUserEmail").textbox('setValue', "");
    $("#txtUserLogNum").val("0");
    $("#txtId").val("0");
}


jQuery(function ($) {
    $("#btnQuery").click(function () { OnSelectClick(); });
});

function OnSelectClick() {
    if (""==$("#tUserName").textbox('getValue')) {
        msgShow("提示", "您还没有输入要搜索的条件？", "warning");
        return; 
     } 
    var userName= $("#tUserName").textbox('getValue');
    var url = '../ashx/member.ashx?' + $.param({ action: "paging", UserName: userName});
    $('#tdg').datagrid({ url: url });
    $('#tdg').datagrid('reload');
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
        url: '../ashx/member.ashx?action=add',
        async: false,
        onSubmit: function () {
            return $(this).form('validate');
        },
        success: function (data) {
            msgShow("提示", data, "info");
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
        url: '../ashx/member.ashx?action=up',
        async: false,
        onSubmit: function () {
            return $(this).form('validate');
        },
        success: function (data) {
            msgShow("提示", data, "info");
        }
    });
    //刷新form
    forms.reset();
}