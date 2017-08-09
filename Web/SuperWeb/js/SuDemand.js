jQuery(function ($) {
    GridView();
    $('#orgList').window('close');
});
function GridView() {
    $('#tdg').datagrid({
        title: '供应需求信息列表',
        iconCls: 'icon-save',
        nowrap: true,
        striped: true,
        url: '../ashx/SuDem.ashx?action=paging&SupplyOrDemand=' + $("input[name='rdobtn']:checked").val(),
        remoteSort: false,
        sortName: 'CreateDate',
        singleSelect: true,
        sortOrder: 'desc',
        fit: false,
        fitColumns: true,
        rownumbers: true,
        frozenColumns: [[
	                { title: '编号', field: 'Id', width: 30, align: 'center', sortable: true },
                     { field: 'SupplyOrDemand', title: '供应或需求', width: 80, align: 'center', sortable: true, formatter: function (value, row, index) { return value == 1 ? "供应信息" : "需求信息"; } },
					{ field: 'ProName', title: '项目名称', width: 100, align: 'center', sortable: true }
				]],
        columns: [[
          { field: 'IsCheck', title: '审核状态', width: 100, align: 'left', sortable: true, formatter: function (value, row, index) { var s = value == 0 ? "<span style='color:red;'>未审核</span>" : "<span style='color:blue;'>通过</span>"; return s += "&nbsp;&nbsp;<img onclick=\"OnRowsStateClick('" + row.Id + "','IsCheck','" + row.IsCheck + "');\" src='../images/" + row.IsCheck + ".gif' align='absmiddle' />"; } },
                    { field: 'dName', title: '受让方姓名', width: 100, align: 'center', sortable: true },
                    { field: 'dArea', title: '受让方面积', width: 100, align: 'right', sortable: true },
                    { field: 'dQuotation', title: '受让方意向报价', width: 100, align: 'right', sortable: true },
                    { field: 'dCenterContact', title: '受让方中心联系方式', width: 120, align: 'center', sortable: true },
                    { field: 'sName', title: '转让方名称', width: 100, align: 'center', sortable: true },
                    { field: 'sOutArea', title: '转让方拟转出面积', width: 100, align: 'right', sortable: true },
                    { field: 'sDeadline', title: '转让方拟转出年限', width: 100, align: 'center', sortable: true },
                    { field: 'sListingPrice', title: '转让方挂牌价格', width: 100, align: 'right', sortable: true },
                    { field: 'sCenterContact', title: '转让方联系方式电话', width: 120, align: 'center', sortable: true },
                    { field: 'CreateDate', title: '操作时间', width: 100, align: 'center', sortable: true, formatter: function (value, row, index) { return value.substring(0, 10); } }
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
                    $.messager.confirm('询问提示', '您确定要删除选中的编号为 [' + rows[0].Id + '] 的 [' + rows[0].ProName + '] 这一条信息吗？', function (data) {
                        if (data) {
                            $.get("../ashx/SuDem.ashx?action=del", { Id: rows[0].Id }, function (data) {
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
                // msgShow("提示", "正在研发中", "info");               
                var rows = $('#tdg').datagrid('getSelections');
                if (rows.length > 0) {
                    EmptyTextClick();
                    $.get("../ashx/SuDem.ashx?action=id", { Id: rows[0].Id }, function (data) {
                        if (1 == data.SupplyOrDemand) {
                            $("input[name='rSupplyOrDemand']").get(0).checked = true;
                        } else {
                            $("input[name='rSupplyOrDemand']").get(1).checked = true;
                        }
                        OnCheckSupplyOrDemandClick();
                        $("#txtProName").textbox('setValue', data.ProName);
                        $("#txtKeyWord").textbox('setValue', data.KeyWord);
                        $("#txtProNum").textbox('setValue', data.ProNum);
                        $("#txtdName").textbox('setValue', data.dName);
                        $("#txtdGlebePurpose").textbox('setValue', data.dGlebePurpose);
                        $("#txtdListingDate").textbox('setValue', data.dListingDate.replace("T", " "));
                        $("#txtdArea").textbox('setValue', data.dArea);
                        $("#txtdQuotation").textbox('setValue', data.dQuotation);
                        $("#txtdcirculation").textbox('setValue', data.dcirculation);
                        $("#txtdDeadline").textbox('setValue', data.dDeadline);
                        $("#txtdCenterContact").textbox('setValue', data.dCenterContact);
                        $("#txtdProContact").textbox('setValue', data.dProContact);
                        $("#txtsName").textbox('setValue', data.sName);
                        $("#txtsLandProperties").textbox('setValue', data.sLandProperties);
                        $("#txtsOther").textbox('setValue', data.sOther);
                        $("#txtsLocated").textbox('setValue', data.sLocated);
                        $("#txtsOutArea").textbox('setValue', data.sOutArea);
                        $("#txtsDeadline").textbox('setValue', data.sDeadline);
                        $("#txtsOutWay").textbox('setValue', data.sOutWay);
                        $("#txtsListedData").textbox('setValue', data.sListedData.replace("T", " "));
                        $("#txtsOutAgain").textbox('setValue', data.sOutAgain);
                        $("#txtsTransactions").textbox('setValue', data.sTransactions);
                        $("#txtsIsMorSeal").textbox('setValue', data.sIsMorSeal);
                        $("#txtsListingPrice").textbox('setValue', data.sListingPrice);
                        $("#txtsCenterContact").textbox('setValue', data.sCenterContact);
                        $("#txtsProContact").textbox('setValue', data.sProContact);
                        $("#txtsSettlement").textbox('setValue', data.sSettlement);

                        $("#txtRemark").val(data.Remark);
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
        },
        '-', {
            id: 'btnexcel',
            text: '导出excel',
            iconCls: 'icon-redo',
            handler: function () {
                //获取选中的是供应还是需求
                var val = $('input:radio[name="rdobtn"]:checked').val();

                $.get("../ashx/SuDem.ashx?action=excel", { Id: val }, function (data) {
                    //alert(data);
                    window.open(data);

                }, "text");
                /*end*/
            }
        }
        ],
        pagination: true,
        pageSize: _rowsMin
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

    if ($("#tProName").textbox('getValue') == "") {
        msgShow("提示", "供应需求信息名称不能为空！", "error");
        $("#tProName").focus();
        return;
    }
    var tProName = $("#tProName").textbox('getValue');
    var url = '../ashx/SuDem.ashx?' + $.param({ action: "paging", ProName: tProName, SupplyOrDemand: $("input[name='rdobtn']:checked").val() });
    $('#tdg').datagrid({ url: url });
    $('#tdg').datagrid('reload');
}
function OnSwitchingClick() {
    var url = '../ashx/SuDem.ashx?action=paging&SupplyOrDemand=' + $("input[name='rdobtn']:checked").val();
    $('#tdg').datagrid({ url: url });
    $('#tdg').datagrid('reload');
}

function EmptyTextClick() {
    $("#txtProName").textbox('setValue');
    $("#txtKeyWord").textbox('setValue');
    $("#txtProNum").textbox('setValue');
    $("#txtdName").textbox('setValue');
    $("#txtdGlebePurpose").textbox('setValue');
    $("#txtdListingDate").textbox('setValue');
    $("#txtdArea").textbox('setValue');
    $("#txtdQuotation").textbox('setValue');
    $("#txtdcirculation").textbox('setValue');
    $("#txtdDeadline").textbox('setValue');
    $("#txtdCenterContact").textbox('setValue');
    $("#txtdProContact").textbox('setValue');
    $("#txtsName").textbox('setValue');
    $("#txtsLandProperties").textbox('setValue');
    $("#txtsOther").textbox('setValue');
    $("#txtsLocated").textbox('setValue');
    $("#txtsOutArea").textbox('setValue');
    $("#txtsDeadline").textbox('setValue');
    $("#txtsOutWay").textbox('setValue');
    $("#txtsListedData").textbox('setValue');
    $("#txtsOutAgain").textbox('setValue');
    $("#txtsTransactions").textbox('setValue');
    $("#txtsIsMorSeal").textbox('setValue');
    $("#txtsListingPrice").textbox('setValue');
    $("#txtsCenterContact").textbox('setValue');
    $("#txtsProContact").textbox('setValue');
    $("#txtsSettlement").textbox('setValue');

    $("#txtRemark").val();
    $("#txtId").val(0);
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
function OnCheckSupplyOrDemandClick() {
    if (1 == $("input[name='rSupplyOrDemand']:checked").val()) {
        $("#dSupply").show();
        $("#dDemand").hide();
    }
    else {
        $("#dSupply").hide();
        $("#dDemand").show();
    }
}

function OnRowsStateClick(_id, _rn, _vl) {
    $.messager.confirm('询问提示', '您确定要供求需求信息的状态吗？', function (data) {
        if (data) {
            $.get("../ashx/SuDem.ashx?action=rs", { Id: _id, Rows: _rn, Vale: _vl }, function (data) {
                slide("提示", data);
                $('#tdg').datagrid('reload');
            }, "text");
        }
    });
}

jQuery(function ($) {
    $("#btnAdd").click(function () { OnCreateNewsClick(); });
});
function OnCreateNewsClick() {
    $(function () {
        $('#forms input').each(function () {
            if ($(this).attr('required') || $(this).attr('validType'))
                $(this).validatebox();
        })
    });
    $('#forms').form('submit', {
        url: '../ashx/SuDem.ashx?action=add',
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
    $("#btnEdit").click(function () { OnUpdateNewsClick(); });
});
function OnUpdateNewsClick() {
    $(function () {
        $('#forms input').each(function () {
            if ($(this).attr('required') || $(this).attr('validType'))
                $(this).validatebox();
        })
    });
    $('#forms').form('submit', {
        url: '../ashx/SuDem.ashx?action=up',
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