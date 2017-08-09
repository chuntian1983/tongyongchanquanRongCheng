jQuery(function ($) {
    GridView();
});

function GridView() {
    $('#adminTg').datagrid({
        title: '角色信息列表', /*表头*/
        iconCls: 'icon-save', /*图标*/
        nowrap: true, /*设置为true，当数据长度超出列宽时将会自动截取。*/
        striped: true, /*设置为true将交替显示行背景。*/
        url: '../ashx/roleuser.ashx?action=paging',
        remoteSort: false,
        sortName: 'id',
        singleSelect: true,
        sortOrder: 'desc',
        fit: true, /*自动补全*/
        fitColumns: true,
        rownumbers: true,
        frozenColumns: [[

	                { title: '编号id', field: 'id', width: 50, align: 'left', sortable: false },
                    { field: 'rolename', title: '角色名称', width: 180, align: 'left', sortable: false}]],
        toolbar: [{
            id: 'btnadd',
            text: '新建',
            iconCls: 'icon-add',
            handler: function () {
                $("#mainCenter").hide();
                $("#newsEdit").show();
                $("#btnAddNews").show();
                $("#btnEditNews").hide();
                $("#roleEdit").hide();
                //EmptyTextClick();
            }
        }, '-', {
            id: 'btndel',
            text: '删除',
            iconCls: 'icon-no',
            handler: function () {
                /*删除操作region*/
                var rows = $('#adminTg').datagrid('getSelections');
                if (rows.length > 0) {
                    $.messager.confirm('询问提示', '您确定要删除选中的编号为 [' + rows[0].id + '] 的 [' + rows[0].rolename + '] 这一条信息吗？', function (data) {
                        if (data) {
                            $.get("../ashx/roleuser.ashx?action=del", { id: rows[0].id }, function (data) {
                                msgShow("提示", data, "info");
                                $('#adminTg').datagrid('clearSelections');
                                $('#adminTg').datagrid('reload');
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
                var rows = $('#adminTg').datagrid('getSelections');

                if (rows.length > 0) {

                    /**/
                    // EmptyTextClick();
                    $.get("../ashx/roleuser.ashx?action=Id", { Id: rows[0].id }, function (data) {

                        $("#txtrolename").textbox('setValue', data.rolename);
                        $("#txtId").val(data.id);

                    }, "json");
                    /**/
                    $("#mainCenter").hide();
                    $("#btnAddNews").hide();
                    $("#roleEdit").hide(); //权限div
                    $("#btnEditNews").show();
                    $("#newsEdit").show();
                } else {
                    msgShow("提示", "您还没有选中要修改的列信息？", "warning");
                }
                /*end*/
            }
        },
        '-', {
            id: 'btnqx',
            text: '权限分配',
            iconCls: 'icon-redo',
            handler: function () {
                /*修改操作region */
                var rows = $('#adminTg').datagrid('getSelections');

                if (rows.length > 0) {

                    /**/
                    // EmptyTextClick();
                    $.get("../ashx/roleuser.ashx?action=roleid", { Id: rows[0].id }, function (data) {

                        $("#lblName").text(data.rolename);
                        $("#txtId").val(data.id);
                        $("#txtroleid").val(data.id);
                        OnLoadFunCode();
                    }, "json");
                    /**/
                    $("#mainCenter").hide();
                    $("#btnAddNews").hide();
                    $("#btnEditNews").hide();
                    $("#newsEdit").hide();
                    $("#roleEdit").show();
                    
                } else {
                    msgShow("提示", "您还没有选中信息？", "warning");
                }
                /*end*/
            }
        }
               ],


        pagination: true,
        pageSize: _rowsMin
    });
    var p = $('#adminTg').datagrid('getPager');
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
    $("#newsEdit").hide();
    $("#roleEdit").hide();
    $('#adminTg').datagrid('reload');
}
//add
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
        url: '../ashx/roleuser.ashx?action=add',
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

}
//update
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
        url: '../ashx/roleuser.ashx?action=up',
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

}
var zTree;
var setting = {
    checkable: true,
    showLine: true,
    callback: {
        click: zTreeOnClick
    }
}


function OnLoadFunCode() {
   var roleid ;
   
   roleid = $("#txtroleid").val();
   
    $.get("../ashx/sysfun.ashx?action=tree", { NodeId: "0", roleid:roleid }, function (data) {
               zTree = $("#sfun").zTree(setting, data);
        //alert(data);
//        $("#sfun").tree(data);
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
//返回列表
jQuery(function ($) {
    $("#afanhui").click(function () { OnReturnListClick(); });
});

function OnReturnListClick() {
    
    $("#mainCenter").show();
    $("#btnAddNews").hide();
    $("#btnEditNews").hide();
    $("#newsEdit").hide();
    $("#roleEdit").hide();
    $('#adminTg').datagrid('reload');
}
//添加权限
jQuery(function ($) {
    $("#btnAdd").click(function () { OnAddRoleClick(); });
});

function OnAddRoleClick() {
    adminUserId = $("#txtroleid").val();
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



