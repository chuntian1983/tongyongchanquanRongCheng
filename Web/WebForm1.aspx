<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm1.aspx.cs" Inherits="Web.WebForm1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">


<!DOCTYPE html> 
<html lang="zh"> 
<head>
    <meta charset="UTF-8">
    <title>Basic Draggable - jQuery EasyUI Demo</title>
    <link rel="stylesheet" type="text/css" href="SuperWeb/js/easyui/themes/default/easyui.css">
    <link rel="stylesheet" type="text/css" href="SuperWeb/js/easyui/themes/icon.css">
    
    <script type="text/javascript" src="SuperWeb/js/easyui/jquery.min.js"></script>
    <script type="text/javascript" src="SuperWeb/js/easyui/jquery.easyui.min.js"></script>
    <script>
        function cc() {
            var va = $('#divcc').css("top");
            va = va + "|" + $('#divcc').css("left");
            alert(va);

        }
        function fz() {
            $('#divcc').css("top", "206px");

        }
    </script>
</head>
<body>
    <h2>CheckBox Tree</h2>
    <p>Tree nodes with check boxes.</p>
    <div style="margin:20px 0;">
        <a href="#" class="easyui-linkbutton" onclick="getChecked()">GetChecked</a> 
    </div>
    <div style="margin:10px 0">
        <input type="checkbox" checked onchange="$('#tt').tree({cascadeCheck:$(this).is(':checked')})">CascadeCheck 
        <input type="checkbox" onchange="$('#tt').tree({onlyLeafCheck:$(this).is(':checked')})">OnlyLeafCheck
    </div>
    <div class="easyui-panel" style="padding:5px">
        <ul id="tt" class="easyui-tree" data-options="url:'tree_data1.json',method:'get',animate:true,checkbox:true"></ul>
    </div>
    <script type="text/javascript">
        function getChecked() {
            var nodes = $('#tt').tree('getChecked');
            var s = '';
            for (var i = 0; i < nodes.length; i++) {
                if (s != '') s += ',';
                s += nodes[i].text;
            }
            alert(s);
        }
    </script>
    <a href="#" class="easyui-linkbutton" data-options="iconCls:'icon-add'" onclick="getChecked()" >ceshi</a>

</body>
</html> 
