/*弹出信息窗口 title:标题 msgString:提示信息 msgType:信息类型 [error,info,question,warning]*/
function msgShow(title, msgString, msgType) {
    $.messager.alert(title, msgString, msgType);
}
/*获取URL传递的参数*/
Request = {
    QueryString: function (item) {
        var svalue = location.search.match(new RegExp("[\?\&]" + item + "=([^\&]*)(\&?)", "i"));
        return svalue ? svalue[1] : svalue;
    }
}

function slide(_title, _msg) {
    $.messager.show({
        title: _title,
        msg: _msg,
        timeout: 3500,
        showType: 'slide'
    });
}

function OnCheckImg(ControlName) {
    var imgDom = document.getElementById(ControlName);
    var location = imgDom.value;
    if (location != "") {
        var point = location.lastIndexOf(".");
        var type = location.substr(point).toLowerCase();
        if (type == ".jpg" || type == ".gif" || type == ".jpeg" || type == ".png") {
            var imgSize = 0;
            if (window.navigator.userAgent.indexOf("Firefox") >= 1) {
                imgSize = imgDom.files[0].fileSize;
            } else {
                imgSize = img.fileSize;
            }
            if (imgSize > 102400) {
                msgShow("提示", "图片大小请不要大于100KB", "info");
                return false;
            }
        }
        else {
            var afile = $("#" + ControlName);
            afile.replaceWith(afile.clone());
            msgShow("提示", "只能上传jpg,jpge,gif,png格式的图片", "info");
            return false;
        }
    }
}

function OnCheckFile(ControlName) {
    var imgDom = document.getElementById(ControlName);
    var location = imgDom.value;
    if (location != "") {
        var point = location.lastIndexOf(".");
        var type = location.substr(point).toLowerCase();
        if (type == ".doc" || type == ".txt" || type == ".xls" || type == ".pdf" || type == ".rtf") {
            var imgSize = 0;
            if (window.navigator.userAgent.indexOf("Firefox") >= 1) {
                imgSize = imgDom.files[0].fileSize;
            } else {
                imgSize = img.fileSize;
            }
        }
        else {
            var afile = $("#" + ControlName);
            afile.replaceWith(afile.clone());
            msgShow("提示", "只能上传doc,txt,xls,pdf,rtf格式的文件", "info");
            return false;
        }
    }
}


