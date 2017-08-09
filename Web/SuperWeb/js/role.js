jQuery(function ($) {
    GridView();
});

function GridView() {
    $('#adminTg').datagrid({
        title: '管理员信息列表', /*表头*/
        iconCls: 'icon-save', /*图标*/
        nowrap: true, /*设置为true，当数据长度超出列宽时将会自动截取。*/
        striped: true, /*设置为true将交替显示行背景。*/
        url: '../ashx/admin.ashx?action=paging',
        remoteSort: false,
        sortName: 'EndDate',
        singleSelect: true,
        sortOrder: 'desc',
        fit: true, /*自动补全*/
        fitColumns: true,
        rownumbers: true,
        frozenColumns: [[
        { field: 'ck', align: 'center', checkbox: true },
	                { title: '编号', field: 'Id', width: 50, align: 'left', sortable: true },
                    { field: 'AdminLogName', title: '登录账号', width: 80, align: 'left', sortable: true },
					{ field: 'AdminName', title: '管理员姓名', width: 80, align: 'left', sortable: true}]],
        columns: [[
                    { field: 'AdminTel', title: '管理员电话', width: 80, align: 'left', sortable: true },
                    { field: 'UnitCode', title: '组织单位代码', width: 80, align: 'left', sortable: true },
                    { field: 'AdminType', title: '管理员类型', width: 80, align: 'left', sortable: true, formatter: function (value, row, index) { if (6 == value) { return "部级"; } else if (5 == value) { return "省级"; } else if (4 == value) { return "市级"; } else if (3 == value) { return "县市级"; } else if (2 == value) { return "乡镇级"; } else if (1 == value) { return "村级"; } else if (0 == value) { return "组级"; } } },
                    { field: 'AdminState', title: '管理员状态', width: 50, align: 'left', sortable: true, formatter: function (value, row, index) { return row.AdminState == 0 ? "<span style='color:red;'>禁用</span>" : "<span style='color:blue;'>正常<span>"; } },
                    { field: 'AdminLogNum', title: '登录次数', width: 50, align: 'left', sortable: true },
                    { field: 'IsCheck', title: '越级审核权限', width: 50, align: 'left', sortable: true, formatter: function (value, row, index) { return row.IsCheck == 0 ? "否" : "是"; } },
                    { field: 'EndDate', title: '最后登录时间', width: 80, align: 'left', sortable: true },
                    { field: 'CreateDate', title: '查看权限信息', width: 80, align: 'left', sortable: true, formatter: function (value, row, index) { return "&nbsp;&nbsp;<img onclick=\"OnRoleListClick('" + row.Id + "','" + row.AdminName + "');\" src='../js/easyUI/themes/icons/search.png' align='absmiddle' />&nbsp;&nbsp;"; } }
				]],
        pagination: true,
        pageSize: _rowsMin
    });
    var p = $('#adminTg').datagrid('getPager');
    $(p).pagination({
        onBeforeRefresh: function () {
        }
    });
}
var adminUserId = "";
var adminUserName = "";
function OnRoleListClick(id, uname) {
    adminUserId = id;
    adminUserName = uname;
    var url = '../ashx/role.ashx?' + $.param({ action: "paging", adminUserId: id });
    $('#roleTg').datagrid({ url: url });
    $('#roleTg').datagrid('reload');
}
jQuery(function ($) {
    GvRole();
});
function GvRole() {
    $('#roleTg').datagrid({
        title: '权限信息列表',
        iconCls: 'icon-save',
        nowrap: true,
        striped: true,
        url: '../ashx/role.ashx?action=paging&adminUserId=0',
        remoteSort: false,
        sortName: 'CreateDate',
        singleSelect: true,
        sortOrder: 'desc',
        fit: true,
        fitColumns: true,
        rownumbers: true,
        frozenColumns: [[
	                { title: '编号', field: 'Id', width: 50, align: 'left', sortable: true },
                    { field: 'AdminUserId', title: '登录账号', width: 150, align: 'left', sortable: true },
					{ field: 'SysFunId', title: '系统菜单', width: 150, align: 'left', sortable: true}]],
        columns: [[
                    { field: 'IfAdd', title: '添加权限', width: 80, align: 'left', sortable: true, formatter: function (value, row, index) { return row.IfAdd == 0 ? "<span style='color:red;'>否</span>" : "<span style='color:blue;'>是<span>"; } },
                    { field: 'IfUp', title: '修改权限', width: 80, align: 'left', sortable: true, formatter: function (value, row, index) { return row.IfUp == 0 ? "<span style='color:red;'>否</span>" : "<span style='color:blue;'>是<span>"; } },
                    { field: 'IfDel', title: '删除权限', width: 80, align: 'left', sortable: true, formatter: function (value, row, index) { return row.IfDel == 0 ? "<span style='color:red;'>否</span>" : "<span style='color:blue;'>是<span>"; } },
                    { field: 'IfSel', title: '查询权限', width: 80, align: 'left', sortable: true, formatter: function (value, row, index) { return row.IfSel == 0 ? "<span style='color:red;'>否</span>" : "<span style='color:blue;'>是<span>"; } },
                    { field: 'Editor', title: '操作人', width: 80, align: 'left', sortable: true },
                    { field: 'CreateDate', title: '操作时间', width: 80, align: 'left', sortable: true }
				]],
        toolbar: [{
            id: 'btnadd',
            text: '授权设置',
            iconCls: 'icon-add',
            handler: function () {
                if (adminUserId != "") {
                    $("#mainCenter").hide();
                    $("#Edit").show();
                    $("#lblName").text(adminUserName);
                }
                else {
                    msgShow("提示", "您还没有选中要授权的管理账户！请从上面的列表中选择要授权的管理账户信息！", "info");
                }
            }
        }]
    });
}

var zTree;
var setting = {
    checkable: true,
    showLine: true,
    callback: {
        click: zTreeOnClick
    }
};

jQuery(function ($) {
    OnLoadFunCode();
});

function OnLoadFunCode() {
    $.get("../ashx/sysfun.ashx?action=tree", { NodeId: "0" }, function (data) {
        zTree = $("#sfun").zTree(setting, data);
    }, "json");
}
function zTreeOnClick(event, treeId, treeNode) {
    AddNodes(treeNode.id, treeNode);
}

function AddNodes(id, Node) {
    $.get("../ashx/sysfun.ashx?action=node", { NodeId: id }, function (data) {
        if (data.length != 0) {
            if (Node.nodes.length == 0) {
                var nodes = zTree.addNodes(Node, data);
            }
        }
        Node.open = true;
    }, "json");
}

jQuery(function ($) {
    $("#areturn").click(function () { OnReturnListClick(); });
});

function OnReturnListClick() {
    $("#mainCenter").show();
    $("#Edit").hide();
    $('#roleTg').datagrid('reload');
}

jQuery(function ($) {
    $("#btnAdd").click(function () { OnAddRoleClick(); });
});

function OnAddRoleClick() {
    if (adminUserId != "") {
        var roleId = "";
        var ifAdd = "";
        var ifUp = "";
        var ifDel = "";
        var ifSel = "";
        var nodes = zTree.getCheckedNodes(true);
        if ($("#tIfAdd").is(":checked")) { ifAdd = "1"; } else { ifAdd = "0"; }
        if ($("#tIfUp").is(":checked")) { ifUp = "1"; } else { ifUp = "0"; }
        if ($("#tIfDel").is(":checked")) { ifDel = "1"; } else { ifDel = "0"; }
        if ($("#tIfSel").is(":checked")) { ifSel = "1"; } else { ifSel = "0"; }
        for (var i = 0; i < nodes.length; i++) {
            roleId += nodes[i].id;
            if (i < nodes.length - 1) {
                roleId += ",";
            }
        }
        $.get("../ashx/role.ashx?action=add", { AdminUserId: adminUserId, IfAdd: ifAdd, IfUp: ifUp, IfDel: ifDel, IfSel: ifSel, Role: roleId }, function (data) {
            msgShow("提示", data, "info");
            OnReturnListClick();
        }, "text");
    }
    else {
        msgShow("提示", "您还没有选中要授权的管理账户！请从上面的列表中选择要授权的管理账户信息！", "info");
    }
}