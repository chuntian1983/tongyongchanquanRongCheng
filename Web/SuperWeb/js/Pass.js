/*
jQuery(function ($) {
    BindText();
});
function BindText() {
    $.get("../ashx/admin.ashx?action=pass", function (data) {
        $("#txtoldpass").textbox('setValue', data.AdminLogPass);
        $("#txtId").val(data.ID);
    }, "json");

}
*/
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
        url: '../ashx/pass.ashx?action=up',
        async: false,
        onSubmit: function () {

            return $(this).form('validate');

        },
        success: function (data) {
            msgShow("提示", data, "info");
        }
    });
    //刷新form
   // formNews.reset();
    $("#txtoldpass").textbox('setValue',"");
    $("#txtnewpass").textbox('setValue',"");
    $("#txtnewpass2").textbox('setValue',"");

}