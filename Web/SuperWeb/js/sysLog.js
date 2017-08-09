jQuery(function ($) {
    GridView();
    $("#btnQuery").click(OnSelectClick);
});
function GridView() {
    $('#tdg').datagrid({
        title: '系统操作日志信息', /*表头*/
        iconCls: 'icon-save', /*图标*/
        nowrap: false, /*设置为true，当数据长度超出列宽时将会自动截取。*/
        striped: true, /*设置为true将交替显示行背景。*/
        url: '../ashx/sysLog.ashx?action=paging',
        remoteSort: false,
        singleSelect: true,
        sortName: 'CreateDate',
        sortOrder: 'desc',
        fit: true, /*自动补全*/
        fitColumns: true,
        rownumbers: true,
        frozenColumns: [[
	                { title: '编号', field: 'Id', width: 50, align: 'left' }
				]],
        columns: [[
					{ field: 'LogValue', title: '操作内容', width: 80, align: 'left' },
                    { field: 'Operates', title: '操作类型', width: 80, align: 'left' },
                    { field: 'HostName', title: '主机名称', width: 80, align: 'left' },
                    { field: 'Ip', title: 'IP地址', width: 80, align: 'left' },
					{ field: 'Editor', title: '操作人', width: 80, align: 'left' },
                    { field: 'CreateDate', title: '操作时间', width: 80, align: 'left', sortable: true }
				]],
        toolbar: ['-', {
            id: 'btncut',
            text: '删除',
            iconCls: 'icon-no',
            handler: function () {
                $.messager.confirm('询问提示', '您确定要清空操作日志吗？', function (data) {
                    if (data) {
                        $.get("../ashx/sysLog.ashx?action=del", {}, function (data) {
                            msgShow("提示", data, "info");
                            $('#tdg').datagrid('reload');
                        }, "text");
                    } 
                });
            }
        }, '-'],
        pagination: true,
        pageSize: _rows
    });
    var p = $('#tdg').datagrid('getPager');
    $(p).pagination({
        onBeforeRefresh: function () {
        }
    });
}

function OnSelectClick() {
    if ($("#txtstateDate").datebox('getValue') == "") {
        msgShow("提示", "查询开始时间不能为空！", "error");
        $("#txtstateDate").focus();
        return;
    }
    if ($("#txtendDate").datebox('getValue') == "") {
        msgShow("提示", "结束查询时间不能为空！", "error");
        $("#txtendDate").focus();
        return;
    }
    var stateDate = $("#txtstateDate").datebox('getValue');
    var endDate = $("#txtendDate").datebox('getValue');
    var url = '../ashx/sysLog.ashx?' + $.param({ action: "paging", StateDate: stateDate, EndDate: endDate });
    $('#tdg').datagrid({ url: url });
    $('#tdg').datagrid('reload');
}   