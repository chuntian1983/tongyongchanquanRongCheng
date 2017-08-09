jQuery(function ($) {
    BindTree();
    $('#divadd').window('close');
});
var va;
var vaid;
function BindTree() {
    $('#orglist').tree({
        checkbox: false,
        url: '../ashx/org.ashx?action=orglist',
        animate: true,
        lines: true,
        onBeforeExpand: function (node, param) {
            $('#orglist').tree('options').url = "../ashx/org.ashx?action=orglist&id=" + node.id;
        },
        onClick: function (node) {

            va = node.text;
            vaid = node.id;
        }

    })
}
//btn
jQuery(function ($) {
    $("#btnadd").click(function () { OnLoadUnitCode(); });
    $("#btndel").click(function () { btndel(); });
    $("#btnCancel").click(function () { btncancel(); });
    $("#btnedit").click(function () { btnedit(); });
    $('#btnAddNews').click(function () { btnAddNews(); });
    $('#btnEditNews').click(function () { btnEditNews(); });
});

function OnLoadUnitCode() {
    if (va == null || va == "") {
        alert('请先选择上级组织单位，才能添加组织单位信息！');
        return;

    }
    $('#divadd').window('open');
    $('#btnEditNews').hide();
    $('#btnAddNews').show();
    $('#txtUpOrgCode').textbox('setValue', va);
    $('#hdtxtUpOrgCode').val(vaid);

    $("#txtOrgName").textbox('setValue','');
    $("#txtOrgCode").textbox('setValue','');
    $("#txtOrgShortName").textbox('setValue','');
    $("#txtSeq").numberbox('setValue',0);


}
function btndel() {
    if (va == null || va == "") {
        alert('请先单击选择组织单位');
        return;

    }
    $.get("../ashx/org.ashx?action=del", { id: vaid }, function (data) {
        msgShow("提示", data, "info");
        BindTree();

    }, "text");
    
    

}
function btncancel() {
    $('#divadd').window('close');
    BindTree();

}
function btnedit() {
    if (va == null || va == "") {
        alert('请先选择上级组织单位，才能添加组织单位信息！');
        return;

    }
    $.get("../ashx/org.ashx?action=id", { id:vaid }, function (data) {
        $("#txtOrgName").textbox('setValue', data.OrgName);
        $("#txtOrgCode").textbox('setValue', data.OrgCode);
        $("#txtOrgShortName").textbox('setValue', data.OrgShortName);
        $("#txtSeq").numberbox('setValue', data.Seq);
       
    }, "json");
    $('#divadd').window('open');
    $('#txtUpOrgCode').textbox('setValue', va);
    $('#hdtxtUpOrgCode').val(vaid);
    $('#btnEditNews').show();
    $('#btnAddNews').hide();

}
//添加组织单位
function btnAddNews() {
    $(function () {
        //验证必写循环
        $('#form1 input').each(function () {
            if ($(this).attr('required') || $(this).attr('validType'))
                $(this).validatebox();
        })
    });
    //form提交
    $('#form1').form('submit', {
        url: '../ashx/org.ashx?action=add&upid='+vaid+'',
        async: false,
        onSubmit: function () {
            return $(this).form('validate');
        },
        success: function (data) {
            msgShow("提示", data, "info");
            $('#divadd').window('close');
            BindTree();
        }
    });

}
//修改组织单位
function btnEditNews() {
    $(function () {
        //验证必写循环
        $('#form1 input').each(function () {
            if ($(this).attr('required') || $(this).attr('validType'))
                $(this).validatebox();
        })
    });
    //form提交
    $('#form1').form('submit', {
        url: '../ashx/org.ashx?action=edit&upid=' + vaid + '',
        async: false,
        onSubmit: function () {
            return $(this).form('validate');
        },
        success: function (data) {
            msgShow("提示", data, "info");
            $('#divadd').window('close');
            BindTree();
        }
    });

}