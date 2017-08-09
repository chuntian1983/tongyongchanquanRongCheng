<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm2.aspx.cs" Inherits="Web.WebForm2" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html>
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
            va =va+ "|" + $('#divcc').css("left");
            alert(va);

        }
        function fz() {
            $('#divcc').css("top","206px");
            
        }
    </script>
</head>
<body>
    <h2>Basic Draggable</h2>
    <p>Move the boxes below by clicking on it with mouse.</p>
    <div style="margin:20px 0;"></div>
    <div id="divcc" class="easyui-draggable" style="width:200px;height:50px;background:#fafafa;border:1px solid #ccc">证书号</div>
    <div class="easyui-draggable" data-options="handle:'#title'" style="width:200px;height:150px;background:#fafafa;border:1px solid #ccc;margin-top:10px">
        <div id="title" style="padding:5px;background:#ccc;color:#fff">Title</div>
    </div>
    <input  type=button onclick="cc()" value="提取坐标"/>
    <input  type=button onclick="fz()" value="坐标赋值"/>
</body>
</html>
