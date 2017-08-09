jQuery(function ($) {
    GridView();
    $('#orgList').window('close');
});
//data-options="onChange:function(){ OnCheckUserName();}"
function GridView() {
    $('#tdg').datagrid({
        title: '管理员信息列表', /*表头*/
        iconCls: 'icon-save', /*图标*/
        nowrap: true, /*设置为true，当数据长度超出列宽时将会自动截取。*/
        striped: true, /*设置为true将交替显示行背景。*/
        url: '../ashx/admin.ashx?action=paging',
        remoteSort: false,
        sortName: 'CreateDate',
        singleSelect: true,
        sortOrder: 'desc',
        fit: true, /*自动补全*/
        fitColumns: true,
        rownumbers: true,

        frozenColumns: [[
	                { title: '编号', field: 'Id', width: 50, align: 'left', checkbox: true, sortable: true },
                    { field: 'AdminLogName', title: '登录账号', width: 80, align: 'left', sortable: true },
					{ field: 'AdminLogPass', title: '登录密码', width: 80, align: 'left', sortable: true, formatter: function (value, row, index) { return "********"; } }
				]],
        columns: [[
                    { field: 'AdminName', title: '用户姓名', width: 80, align: 'left', sortable: true },
                    { field: 'AdminTel', title: '用户电话', width: 80, align: 'left', sortable: true },
                    { field: 'UnitCode', title: '组织单位代码', width: 80, align: 'left', sortable: true },
                    { field: 'AdminType', title: '用户类型', width: 80, align: 'left', sortable: true, formatter: function (value, row, index) { if (6 == value) { return "部级"; } else if (5 == value) { return "省级"; } else if (4 == value) { return "市级"; } else if (3 == value) { return "县市级"; } else if (2 == value) { return "乡镇级"; } else if (1 == value) { return "村级"; } else if (0 == value) { return "组级"; } } },
                    { field: 'AdminState', title: '用户状态', width: 50, align: 'left', sortable: true, formatter: function (value, row, index) { var s = row.AdminState == 0 ? "<span style='color:red;'>禁用</span>" : "<span style='color:blue;'>正常<span>"; return s += "&nbsp;&nbsp;<img onclick=\"OnRowsStateClick('" + row.Id + "','AdminState','" + row.AdminState + "');\" src='../images/" + row.AdminState + ".gif' align='absmiddle'  />"; } },
                    { field: 'AdminLogNum', title: '登录次数', width: 50, align: 'left', sortable: true },
                    { field: 'IsCheck', title: '越级审核权限', width: 50, align: 'left', sortable: true, formatter: function (value, row, index) { var c = row.IsCheck == 0 ? "否" : "是"; return c += "&nbsp;&nbsp;<img onclick=\"OnRowsStateClick('" + row.Id + "','IsCheck','" + row.IsCheck + "');\" src='../images/" + row.IsCheck + ".gif' align='absmiddle' />"; } },
                    { field: 'EndDate', title: '最后登录时间', width: 80, align: 'left', sortable: true },
                    { field: 'CreateDate', title: '创建时间', width: 80, align: 'left', sortable: true }
				]],

        singleSelect: false,
        selectOnCheck: true,
        checkOnSelect: true,
        toolbar: [{
            id: 'btnadd',
            text: '新建',
            iconCls: 'icon-add',
            handler: function () {
                $("#mainCenter").hide();
                $("#adminUserEdit").show();
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
                    $.messager.confirm('询问提示', '您确定要删除选中的用户信息吗？', function (data) {
                        if (data) {
                            var ids='';
                            if (rows.length > 0) {

                                for (var i = 0; i < rows.length; i++) {
                                    ids += rows[i].Id + ',';
                                }
                            }
                            
                            $.get("../ashx/admin.ashx?action=del", { id: ids }, function (data) {
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
        }, '-', {
            id: 'btncut',
            text: '修改',
            iconCls: 'icon-cut',
            handler: function () {
                /*修改操作region */
                var rows = $('#tdg').datagrid('getSelections');
                if (rows.length > 0) {
                    EmptyTextClick();
                    /**/
                    // $.messager.progress();
                    $.get("../ashx/admin.ashx?action=id", { Id: rows[0].Id }, function (data) {
                        $("#txtAdminLogName").textbox('setValue', data.AdminLogName);
                        $("#txtAdminLogPass").val(data.AdminLogPass);
                        $("#txtUnitCode").textbox('setValue', data.UnitCode);
                        $("#txtAdminName").textbox('setValue', data.AdminName);
                        $("#txtAdminTel").textbox('setValue', data.AdminTel);
                        $("#txtAdminState").combobox('setValue', data.AdminState);
                        $("#txtIsCheck").combobox('setValue', data.IsCheck);
                        $("#roleid").combobox('setValue', data.Roleid);
                        /**/
                        $("#txtId").val(data.Id);
                        $("#txtAdminType").val(data.AdminType);
                        $("#txtAdminLogNum").val(data.AdminLogNum);
                    }, "json");
                    //
                    $("#mainCenter").hide();
                    $("#btnAdd").hide();
                    $("#btnEdit").show();
                    $("#adminUserEdit").show();
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
    $("#btnQuery").click(function () { OnSelectClick(); });
});
function OnSelectClick() {
    var adminLogName = $("#txt_AdminLogName").textbox('getValue');
    var url = '../ashx/admin.ashx?' + $.param({ action: "paging", AdminLogName: adminLogName });
    $('#tdg').datagrid({ url: url });
    $('#tdg').datagrid('reload');
}

function OnRowsStateClick(_id, _rn, _vl) {
    $.messager.confirm('询问提示', '您确定要修改相关的权限设置吗？', function (data) {
        if (data) {
            $.get("../ashx/admin.ashx?action=rs", { Id: _id, Rows: _rn, Vale: _vl }, function (data) {
                slide("提示", data);
                $('#tdg').datagrid('reload');
            }, "text");
        }
    });
}

jQuery(function ($) {
    $("#btnCancel").click(function () { OnReturnListClick(); });
    $("#areturn").click(function () { OnReturnListClick(); });
});

function OnReturnListClick() {
    $("#mainCenter").show();
    $("#adminUserEdit").hide();
    $('#tdg').datagrid('reload');
}


jQuery(function ($) {
    $("#btnAdd").click(function () { OnCreateClick(); });
});
function OnCreateClick() {
    //form提交
    $('#adminUserFrom').form('submit', {
        url: '../ashx/admin.ashx?action=add',
        async: false,
        onSubmit: function () {
            return $(this).form('validate');
        },
        success: function (data) {
            msgShow("提示", data, "info");
        }
    });
    //刷新form
    adminUserFrom.reset();
}

function EmptyTextClick() {
    $("#txtAdminLogName").textbox('setValue', "");
    $("#txtAdminLogPass").val("");
    $("#txtUnitCode").textbox('setValue', "");
    $("#txtAdminName").textbox('setValue', "");
    $("#txtAdminTel").textbox('setValue', "");
    $("#txtAdminState").combobox('setValue', "0");
    $("#txtIsCheck").combobox('setValue', "0");

    $("#roleid").combobox('setValue', "2");
    /**/
    $("#txtId").val("0");
    $("#txtAdminType").val("0");
    $("#txtAdminLogNum").val("0");
}
var zTree;
var setting = {
    showLine: true,
    callback: {
        click: zTreeOnClick,
        dblclick: zTreeOnDblclick
    }
};

function OnOpenTree() {
    $('#orgList').window('open');
    $.get("../ashx/org.ashx?action=list", { id: "" }, function (data) {
        zTree = $("#tree").zTree(setting, data);
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


jQuery(function ($) {
    $("#btnEdit").click(function () { OnUpdateClick(); });
});
function OnUpdateClick() {
    //form提交
    $('#adminUserFrom').form('submit', {
        url: '../ashx/admin.ashx?action=up',
        async: false,
        onSubmit: function () {
            return $(this).form('validate');
        },
        success: function (data) {
            msgShow("提示", data, "info");
        }
    });
    //刷新form
    adminUserFrom.reset();
}

function OnCheckUserName() {
    $.get("../ashx/admin.ashx?action=ck", { AdminLogName: $("#txtAdminLogName").textbox('getValue') }, function (data) {
        if ("Y" == data) {
            msgShow("提示", "管理员登录账户已经存在！", "warning");
            $("#txtAdminLogName").textbox('setValue', "");
        }
    }, "text");
}