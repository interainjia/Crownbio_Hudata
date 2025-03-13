<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SysManagement.aspx.cs"
    Inherits="PDXmodelBase.HuData.SysManagement" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link rel="stylesheet" type="text/css" href="../Common/easyui-1.3.2/themes/bootstrap/easyui.css" />
    <script type="text/javascript" src="../Common/easyui-1.3.2/jquery-1.8.0.min.js"></script>
    <link rel="stylesheet" type="text/css" href="../Common/easyui-1.3.2/themes/icon.css" />
    <script type="text/javascript" src="../Common/easyui-1.3.2/jquery.easyui.min.js"></script>
    <%--左侧点击样式--%>
    <script type="text/javascript">
        function setStyle(obj) {
            var Alist = document.getElementsByTagName("a")
            for (var i = 0; i < Alist.length; i++) {
                if (Alist[i].className == "selectTab")
                    Alist[i].className = 'notselectTab';
                if (Alist[i].className == "notselectTab")
                    Alist[i].className = 'notselectTab';

            }
            obj.className = "selectTab";
        }
    </script>
    <%--左侧导航样式--%>
    <style type="text/css">
        .submenu
        {
            background: white;
        }
        
        .submenu ul
        {
            list-style-type: none;
            margin: 0;
            padding: 0;
        }
        .submenu ul li a
        {
            display: block;
            font: normal 13px "Lucida Grande" , "Trebuchet MS" , Verdana, Helvetica, sans-serif;
            color: #1E90FF;
            text-decoration: none;
            padding: 15px 0;
            padding-left: 20px;
            text-align: left;
            height: 15px;
        }
        
        .submenu ul li a:link
        {
            background: #FFFFFF;
        }
        
        .submenu ul li a:hover
        {
            background: #d0e5f6;
        }
        .selectTab
        {
            background: #d0e5f6;
        }
    </style>
    <script type="text/javascript">
        function addTab(name, url) {
            if ($('#systt').tabs('exists', name)) {
                $('#systt').tabs('select', name);
            }
            else {
//                $('.tabs-inner span').each(function (i, n) {
//                    if ($(this).parent().next().is('.tabs-close')) {
//                        var t = $(n).text();
//                        $('#systt').tabs('close', t);
//                    }
//                });

                $('#systt').tabs('add', {
                    title: name,
                    content: "<iframe id = '" + name + "' scrolling='auto' frameborder='0'  src='" + url + "' style='width:100%;height:100%;'></iframe>",
                    //content: "<iframe scrolling='no' frameborder='0'  src='" + url + "' style='width:100%;height:100%;' id='iframepage' name='iframepage' onLoad='iFrameHeight()' ></iframe>",
                    iconCls: 'icon-tab',
                    closable: true

                });
            }
        }
        function updateTab(name, url) {
            var tab = $('#systt').tabs('getTab', name);
            $('#systt').tabs('update', {
                tab: tab,
                options: {
                    title: name,
                    content: "<iframe id = '" + name + "' scrolling='auto' frameborder='0'  src='" + url + "' style='width:100%;height:750px;'></iframe>",
                    iconCls: 'icon-tab',
                    closable: true
                }
            });
            $('#systt').tabs('select', name);
        }

        function iFrameHeight() {
            //for firefox: window.frames["iframepage"]; for IE :document.frames
            var ifm = document.getElementById("iframepage");

            var subWeb = document.frames ? document.frames["iframepage"].document :

ifm.contentDocument;

            if (ifm != null && subWeb != null) {

                ifm.height = subWeb.body.scrollHeight;

            }
        }
    </script>
</head>
<body class="easyui-layout">
    <form id="form1" runat="server">
    <div region="west" split="true" title="" style="width: 170px; padding: 1px;">
        <div class="easyui-accordion" fit="true" border="false">
            <div title="System Management" class="submenu" selected="true" iconcls="icon-title">
                <ul>
                    <li><a href="javascript:void();" class="notselectTab" onclick="setStyle(this);addTab('Role Management','UserRole.aspx')">
                        Role Management</a></li>
                </ul>
                <ul>
                    <li><a href="javascript:void();" class="notselectTab" onclick="setStyle(this);addTab('User Management','Users.aspx')">
                        Users Management</a></li>
                </ul>
                <ul>
                    <li><a href="javascript:void();" class="notselectTab" onclick="setStyle(this);addTab('Data Management','DataImport.aspx')">
                        Data Management</a></li>
                </ul>
                <ul>
                    <li><a href="javascript:void();" class="notselectTab" onclick="setStyle(this);addTab('Husbandry Analysis','Husbandry.aspx')">
                        Husbandry Analysis</a></li>
                </ul>
                <ul>
                    <li><a href="javascript:void();" class="notselectTab" onclick="setStyle(this);addTab('Take Rate Analysis','TakeRate.aspx')">
                        Take Rate Analysis</a></li>
                </ul>
                <ul>
                    <li><a href="javascript:void();" class="notselectTab" onclick="setStyle(this);addTab('DropDownList','DropDownList.aspx')">
                        DropDownList</a></li>
                </ul>
                <ul>
                    <li><a href="javascript:void();" class="notselectTab" onclick="setStyle(this);addTab('Stock Locations','Locations.aspx')">
                        Stock Locations</a></li>
                </ul>
                 <ul>
                    <li><a href="javascript:void();" class="notselectTab" onclick="setStyle(this);addTab('Import Stocks','ImportStock.aspx')">
                        Import Stocks</a></li>
                </ul>
                 <ul>
                    <li><a href="javascript:void();" class="notselectTab" onclick="setStyle(this);addTab('Import Stocks','ImportAnimalInfo.aspx')">
                        Import AnimalInfo from Studylog</a></li>
                </ul>
            </div>
        </div>
    </div>
    <div region="center" title="">
        <div class="easyui-tabs" fit="true" border="false" id="systt">
        </div>
    </div>
    </form>
</body>
</html>
