jQuery(function ($) {
    GridView();
    $('#orgList').window('close');
});
function GridView() {
    $('#tdg').datagrid({
        title: '挂牌项目信息列表', /*表头*/
        iconCls: 'icon-save', /*图标*/
        nowrap: true, /*设置为true，当数据长度超出列宽时将会自动截取。*/
        striped: true, /*设置为true将交替显示行背景。*/
        url: '../ashx/listpro.ashx?action=paging',
        remoteSort: false,
        sortName: 'CreateDate',
        singleSelect: true,
        sortOrder: 'desc',
        fit: true, /*自动补全*/
        fitColumns: false,
        rownumbers: true,
        frozenColumns: [[
	                { title: '编号', field: 'Id', width: 50, align: 'left', sortable: true },
                     { field: 'ProNum', title: '项目编码', width: 200, align: 'left', sortable: true },
					{ field: 'OutProName', title: '项目名称', width: 150, align: 'left', sortable: true }
				]],
        columns: [[
                    { field: 'OutName', title: '转出方名称', width: 100, align: 'left', sortable: true },
                    { field: 'ListingPrice', title: '挂牌价格', width: 100, align: 'left', sortable: true },
                    { field: 'OutPeriod', title: '拟转出期限', width: 100, align: 'left', sortable: true },
                    { field: 'ContractKind', title: '承包方式', width: 100, align: 'left', sortable: true },
                    { field: 'OutArea', title: '拟转出面积（亩）', width: 100, align: 'right', sortable: true },
                    { field: 'ListedPeriod', title: '挂牌公告期', width: 100, align: 'left', sortable: true },
                    { field: 'EndDate', title: '截止日期为', width: 150, align: 'left', sortable: true },
                    { field: 'ListingStatus', title: '挂牌状态', width: 100, align: 'left', sortable: true },
                    { field: 'IfUp', title: '是否置顶', width: 100, align: 'left', sortable: true, formatter: function (value, row, index) { var u = value == 0 ? "否" : "是"; return u += "&nbsp;&nbsp;<img onclick=\"OnRowsStateClick('" + row.Id + "','IfUp','" + row.IfUp + "');\" src='../images/" + row.IfUp + ".gif' align='absmiddle' />"; } },
                    { field: 'IsCheck', title: '审核状态', width: 100, align: 'left', formatter: function (value, row, index) { var s = value == 0 ? "<span style='color:red;'>未审核</span>" : "<span style='color:blue;'>通过</span>"; return s += "&nbsp;&nbsp;<img onclick=\"OnRowsStateClick('" + row.Id + "','IsCheck','" + row.IsCheck + "');\" src='../images/" + row.IsCheck + ".gif' align='absmiddle' />"; } },
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
                    $.messager.confirm('询问提示', '您确定要删除选中的编号为 [' + rows[0].Id + '] 的 [' + rows[0].OutProName + '] 这一条信息吗？', function (data) {
                        if (data) {
                            $.get("../ashx/listpro.ashx?action=del", { id: rows[0].Id }, function (data) {
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
                    EmptyTextClick();
                    $.get("../ashx/listpro.ashx?action=id", { Id: rows[0].Id }, function (data) {
                        $("#txtUnitCode").textbox('setValue', data.UnitCode);
                        $("#txtProNum").textbox('setValue', data.ProNum);
                        $("#txtRegion").combobox('setValue', data.Region);
                        $("#txtProType").combobox('setValue', data.ProType);
                       
                        //$("#txtProType").find("option[value='" + data.ProType + "']").attr("selected", true);
                        $("#txtOutProName").textbox('setValue', data.OutProName);
                        $("#txtOutName").textbox('setValue', data.OutName);
                        $("#txtListingPrice").textbox('setValue', data.ListingPrice);
                        $("#txtOutPeriod").textbox('setValue', data.OutPeriod);
                        $("#txtAuthorization").textbox('setValue', data.Authorization);
                        $("#txtLocated").textbox('setValue', data.Located);
                        $("#txtManageAuth").textbox('setValue', data.ManageAuth);
                        $("#txtContractKind").textbox('setValue', data.ContractKind);
                        $("#txtOutArea").textbox('setValue', data.OutArea);
                        $("#txtFarmersNum").textbox('setValue', data.FarmersNum);
                        $("#txtEast").textbox('setValue', data.East);
                        $("#txtSouth").textbox('setValue', data.South);
                        $("#txtWest").textbox('setValue', data.West);
                        $("#txtNorth").textbox('setValue', data.North);
                        $("#txtGlebePurpose").textbox('setValue', data.GlebePurpose);
                        $("#txtWhetherAgainOut").textbox('setValue', data.WhetherAgainOut);
                        $("#txtOutWay").textbox('setValue', data.OutWay);
                        $("#txtFarmersWishes").textbox('setValue', data.FarmersWishes);
                        $("#txtListedPeriod").textbox('setValue', data.ListedPeriod);
                        $("#txtTwoApplication").textbox('setValue', data.TwoApplication);
                        $("#txtTranCondition").textbox('setValue', data.TranCondition);
                        $("#txtTranMode").textbox('setValue', data.TranMode);
                        $("#txtIsMorSeal").textbox('setValue', data.IsMorSeal);
                        $("#txtOther").textbox('setValue', data.Other);
                        $("#txtEndDate").textbox('setValue', data.EndDate);
                        $("#txtListingStatus").textbox('setValue', data.ListingStatus);
                        $("#txtIfUp").combobox('setValue', data.IfUp);
                        $("#txtIsCheck").val('setValue', data.IsCheck);
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
jQuery(function ($) {
    $("#btnAdd").click(function () { OnCreateClick(); });
});
function OnCreateClick() {
    $('#forms').form('submit', {
        url: '../ashx/listpro.ashx?action=add',
        async: false,
        onSubmit: function () {
            return $(this).form('validate');
        },
        success: function (data) {
            msgShow("提示", data, "info");
            OnReturnNewsListClick();
        }
    });
    forms.reset();
}

jQuery(function ($) {
    $("#btnEdit").click(function () { OnUpdateClick(); });
});
function OnUpdateClick() {
    $('#forms').form('submit', {
        url: '../ashx/listpro.ashx?action=up',
        async: false,
        onSubmit: function () {
            return $(this).form('validate');
        },
        success: function (data) {
            msgShow("提示", data, "info");
            OnReturnNewsListClick();
        }
    });
    forms.reset();
}

function EmptyTextClick() {
    $("#txtUnitCode").textbox('setValue', "");
    $("#txtProNum").textbox('setValue', "");
    $("#txtRegion").combobox('setValue', "");
    $("#txtProType").textbox('setValue', "");
    $("#txtOutProName").textbox('setValue', "");
    $("#txtOutName").textbox('setValue', "");
    $("#txtListingPrice").textbox('setValue', "");
    $("#txtOutPeriod").textbox('setValue', "");
    $("#txtAuthorization").textbox('setValue', "");
    $("#txtLocated").textbox('setValue', "");
    $("#txtManageAuth").textbox('setValue', "");
    $("#txtContractKind").textbox('setValue', "");
    $("#txtOutArea").textbox('setValue', "");
    $("#txtFarmersNum").textbox('setValue', "");
    $("#txtEast").textbox('setValue', "");
    $("#txtSouth").textbox('setValue', "");
    $("#txtWest").textbox('setValue', "");
    $("#txtNorth").textbox('setValue', "");
    $("#txtGlebePurpose").textbox('setValue', "");
    $("#txtWhetherAgainOut").textbox('setValue', "");
    $("#txtOutWay").textbox('setValue', "");
    $("#txtFarmersWishes").textbox('setValue', "");
    $("#txtListedPeriod").textbox('setValue', "");
    $("#txtTwoApplication").textbox('setValue', "");
    $("#txtTranCondition").textbox('setValue', "");
    $("#txtTranMode").textbox('setValue', "协议");
    $("#txtIsMorSeal").textbox('setValue', "");
    $("#txtOther").textbox('setValue', "");
    $("#txtEndDate").textbox('setValue', "");
    $("#txtListingStatus").textbox('setValue', "交易中");
    $("#txtIfUp").combobox('setValue', "0");
    $("#txtIsCheck").val('setValue', "0");
    $("#txtId").val("0");
}

//组织单位树
jQuery(function ($) {
    $("#btnUnitCode").click(function () { OnLoadUnitCode(); });
});
var zTree;
var setting = {
    showLine: true,
    callback: {
        click: zTreeOnClick,
        dblclick: zTreeOnDblclick
    }
};
function OnLoadUnitCode() {
    $('#orgList').window('open');
    $.get("../ashx/org.ashx?action=list", { id: "" }, function (data) {
        zTree = $("#org").zTree(setting, data);
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
    OnComBoxloadDate();
});
function OnComBoxloadDate() {
    $('#txtProType').combobox({
        url: '../ashx/proType.ashx?action=list',
        valueField: 'id',
        textField: 'text'
    });
}

jQuery(function ($) {
    OnRegionClick();
});

function OnRegionClick() {
    $('#txtRegion').combobox({
        url: "../ashx/org.ashx?action=easycom",
        valueField: 'id',
        textField: 'text'
    });
}

function OnRowsStateClick(_id, _rn, _vl) {
    $.messager.confirm('询问提示', '您确定要修改挂牌项目的状态吗？', function (data) {
        if (data) {
            $.get("../ashx/listpro.ashx?action=rs", { Id: _id, Rows: _rn, Vale: _vl }, function (data) {
                slide("提示", data);
                $('#tdg').datagrid('reload');
            }, "text");
        }
    });
}

$(function ($) {
    $("#btnSearch").click(function () { OnSearchClick(); });
});
function OnSearchClick() {
    if ($("#tOutProName").textbox('getValue') == "") {
        msgShow("提示", "搜索的内容不能为空！", "error");
        $("#tOutProName").focus();
        return;
    }
    var tOutProName = $("#tOutProName").textbox('getValue');
    var url = '../ashx/listpro.ashx?' + $.param({ action: "paging", OutProName: tOutProName });
    $('#tdg').datagrid({ url: url });
    $('#tdg').datagrid('reload');
}