<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Users.aspx.cs" Inherits="PDXmodelBase.HuData.Users" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <script type="text/javascript" src="../Common/easyui-1.3.2/jquery-1.8.0.min.js"></script>
    <script type="text/javascript" src="../Common/easyui-1.2.5/jquery.wresize.js"></script>
    <script type='text/javascript' src='../Common/autocomplete/lib/jquery.bgiframe.min.js'></script>
    <script type='text/javascript' src='../Common/autocomplete/lib/jquery.ajaxQueue.js'></script>
    <script type='text/javascript' src='../Common/autocomplete/lib/thickbox-compressed.js'></script>
    <script type='text/javascript' src='../Common/autocomplete/jquery.autocomplete.js'></script>
    <script type='text/javascript' src='../Common/autocomplete/localdata.js'></script>
    <link rel="stylesheet" type="text/css" href="../Common/autocomplete/jquery.autocomplete.css" />
    <link rel="stylesheet" type="text/css" href="../Common/autocomplete/lib/thickbox.css" />
    <script type="text/javascript" src="../Common/easyui-1.3.2/jquery.easyui.min.js"></script>
    <script type="text/javascript" src="../Common/css/persontree.js"></script>
    <link rel="stylesheet" type="text/css" href="../Common/easyui-1.3.2/themes/bootstrap/easyui.css" />
    <link rel="stylesheet" type="text/css" href="../Common/easyui-1.3.2/themes/icon.css" />
        <script type="text/javascript" src="/site_media/HuData/export.js"></script>
    <script type="text/javascript" src="../Common/fancyBox/source/jquery.fancybox.js?v=2.1.4"></script>
    <link rel="stylesheet" type="text/css" href="../Common/fancyBox/source/jquery.fancybox.css?v=2.1.4"
        media="screen" />
    <link rel="stylesheet" type="text/css" href="../Common/css/form.css" />
    <link rel="stylesheet" type="text/css" href="/site_media/uploadify/uploadify.css" />
    <script type='text/javascript' src='/site_media/uploadify/jquery.uploadify.min.js'></script>
    <link rel="stylesheet" type="text/css" href="../Common/css/buttons3.css" />
 <link href="../Common/waiting/showLoading.css" rel="stylesheet" media="screen" /> 
  <script type="text/javascript" src="../Common/waiting/jquery.showLoading.js"></script>
    <style type="text/css">
        body
        {
            padding: 0px;
            margin: 0px;
        }
    </style>
    <style type="text/css">
        div#activity_pane
        {
            border: 1px solid #CCCCCC;
        }
        .loading-indicator-bars
        {
            background-image: url('../Common/waiting/image/loading-bars.gif');
            width: 150px;
        }
    </style>
    <script type="text/javascript">
        $(function () {
            $(window).wresize(content_resize);
            content_resize();
        });
        function content_resize() {
            $('#context').height(fillsizeH(1));
        }
        function fillsizeH(percent) {
            var bodyHeight = document.documentElement.clientHeight;
            return (bodyHeight) * percent;
        }
    </script>
    <script type="text/javascript">
        function getdata() {
            var params = { searchUser: $('#searchUser').val() };
            $("#test").datagrid('load', params);
        }

        $(function () {
            //绑定datagrid  
            $('#test').datagrid({
                iconCls: 'icon-export',
                url: 'UserFunction.ashx?M=PRO_SYS_USER',
                width: 'auto',
                height: 'auto',
                fitColumns: true,
                singleSelect: true,
                nowrap: false,
                striped: true,
                remoteSort: true,
                pagination: true,
                rownumbers: true,
                pageSize: 10,
                pageList: [10, 20, 30],
                frozenColumns: [[{ field: 'ck', checkbox: true}]],
                columns: [[

                { field: 'FIRST_NAME', title: 'First name', align: 'center' },
                { field: 'LAST_NAME', title: 'Last name', align: 'center' },
                { field: 'POSITION', title: 'Position', align: 'center' },
                { field: 'DEPARTMENT', title: 'Department', align: 'center' },
                { field: 'INSTITUTION', title: 'Institution', align: 'center' },
                { field: 'CITY', title: 'City', align: 'center' },
                { field: 'COUNTRY', title: 'Country',  align: 'center' },
                { field: 'PHONE', title: 'Phone', align: 'center' },
                { field: 'EMAIL', title: 'Email', align: 'center' },
                { field: 'IS_AVAILABLE', title: 'Active', align: 'center' },
                { field: 'ROLE_TYPE', title: 'Role', align: 'center'},
                //添加超级链 
                {field: 'opt', title: '', align: 'center',
                formatter: function (value, rowData, rowIndex) {

                    //function里面的三个参数代表当前字段值，当前行数据对象，行号（行号从0开始）

                    //                        alert(rowData.strChildName);

                    return "<a href='javascript:void();' onclick='show(&quot;" + rowData.USER_ID + "&quot;);'>View</a>";
                }
            }
                , { field: 'opt2', title: '', align: 'center',
                    formatter: function (value, rowData, rowIndex) {

                        //function里面的三个参数代表当前字段值，当前行数据对象，行号（行号从0开始）

                        //                        alert(rowData.strChildName);
                        if (rowData.IS_AVAILABLE == "Y") {
                            return "<a href='javascript:void();' onclick='Disable(&quot;" + rowData.USER_ID + "&quot;);'>Disable</a>";
                        }
                        else {
                            return "<a href='javascript:void();' onclick='Approve(&quot;" + rowData.USER_ID + "&quot;);'>Approve</a>";
                        }
                    }
                }
//                 , { field: 'opt3', title: '', align: 'center',
//                     formatter: function (value, rowData, rowIndex) {
//                         return "<a href='#' onclick='getUserFunction(&quot;" + rowData.USER_ID + "&quot;);'>Permission</a>";

//                     }
//                 }

                        ]]
//                       , toolbar: [
//                       { text: 'Add', iconCls: 'icon-add', handler: function () { DisplayDialog(); } }, '-',
//                       { text: 'Modify', iconCls: 'icon-save', handler: function () { DisEdit(); } }, '-', 
//                       { text: 'Delete', iconCls: 'icon-remove', handler: function () { DelFun(); } }]
        });

        //设置分页控件属性  
        var p = $('#test').datagrid('getPager');
        $(p).pagination({
            pageSize: 10,
            pageList: [10, 20, 30],
            beforePageText: 'Page',
            afterPageText: 'of {pages}',
            displayMsg: 'Displaying {from} to {to} of {total} items'
        });

    });

    function getLink(link) {
        alert(link);
    }
    //设置一个全局URL  
    var url;

    //添加弹出窗口  
    function DisplayDialog() {
        $('#dlg').css('display', 'block');
        url = 'Getdatagrid.ashx';
        $("#dlg").dialog({
            title: 'User Add',
            modal: true,
            collapsible: true,
            resizable: true
        });
        //去掉所有Input为text的内容  
        $('#USER_ID').attr('value', '');
        $('#USER_CODE').attr('value', '');
        $('#USER_PWD').attr('value', '');
        $('#ROLE_TYPE').attr('value', '');
        $('#PROJECT_CODE').attr('value', '');
        $('#PART_MENT').attr('value', '');
        $('#EMAIL').attr('value', '');
        $('#REMARK').attr('value', '');
        //           $('input').each(function () {  
        //               if ($(this).attr('type') == 'text') {  
        //                   $(this).attr('value', '');  
        //               }  
        // 
        //           });
    }
    function Approve(link) {
        if (confirm('Are you confirm this?')) {
            jQuery('#activity_pane').showLoading(
	 			         {
	 			             'addClass': 'loading-indicator-bars'
	 			         }
				        );
            $.ajax({
                type: 'post',
                url: 'userLogin.ashx',
                data: { M: "Approve", USER_ID: link },
                success: function (msg) {
                    jQuery('#activity_pane').hideLoading();
                    alert(msg);
                    $("#test").datagrid('reload');
                }
            });
        }
    }
    function Disable(link) {
        if (confirm('Are you confirm this?')) {
            $.ajax({
                type: 'post',
                url: 'userLogin.ashx',
                data: { M: "Disable", USER_ID: link },
                success: function (msg) {
                    alert(msg);
                    $("#test").datagrid('reload');
                }
            });
        }
    }
    function show(link) {

        $('#dlg2').css('display', 'block');

        $.ajax({
            type: 'post',
            url: 'UserFunction.ashx',
            data: { M: "show", USER_ID: link },
            success: function (msg) {
                $("#dlg2").dialog({
                    title: 'User detail',
                    modal: true,
                    collapsible: true,
                    resizable: true
                });
                //赋值  
                var json = eval("(" + msg + ")");
                $('#hfuser_id').val(link);
                $('#txsUSER_CODE').attr('value', json[0].USER_CODE);
                //$('#txsUSER_PWD').attr('value', json[0].USER_PWD);
                $('#txsFIRST_NAME').attr('value', json[0].FIRST_NAME);
                $('#txsLAST_NAME').attr('value', json[0].LAST_NAME);
                $('#txsPOSITION').attr('value', json[0].POSITION);
                $('#txsDEPARTMENT').attr('value', json[0].DEPARTMENT);
                $('#txsINSTITUTION').attr('value', json[0].INSTITUTION);
                $('#txsSTREET_ADDRESS').attr('value', json[0].STREET_ADDRESS);
                $('#txsCITY').attr('value', json[0].CITY);
                $('#txsCOUNTRY').attr('value', json[0].COUNTRY);
                $('#txsPHONE').attr('value', json[0].PHONE);
                $('#txsFAX').attr('value', json[0].FAX);
                $('#txsEMAIL').attr('value', json[0].EMAIL);
                $('#txsROLE_TYPE').attr('value', json[0].ROLE_NAME);
                //$('#txsPART_MENT').attr('value', json[0].PART_MENT);
                $('#txsUPDATE_TIME').attr('value', json[0].REMARK);
                $('#txsIS_AVAILABLE').attr('value', json[0].IS_AVAILABLE);

            }
        });


    }
    function ConvertJSONDateToJSDateObject(JSONDateString) {
        var date = new Date(parseInt(JSONDateString.replace("/Date(", "").replace(")/", ""), 10));
        var result = date.getFullYear() + "-" + (date.getMonth() + 1 < 10 ? "0" + (date.getMonth() + 1) : date.getMonth() + 1) + "-" + (date.getDate() < 10 ? "0" + date.getDate() : date.getDate()) + " " + (date.getHours() < 10 ? "0" + date.getHours() : date.getHours()) + ":" + (date.getMinutes() < 10 ? "0" + date.getMinutes() : date.getMinutes());
        return result;
    }
    //修改弹出窗口
    function editUser() {
        var flag = true;
        $('#dlg2 input').each(function () {
            if ($(this).attr('required') || $(this).attr('validType')) {
                if (!$(this).validatebox('isValid')) {
                    flag = false;
                    return;
                }
            }
        })
        if (flag)
            $.ajax({
                type: 'post',
                url: 'UserFunction.ashx',
                data: { M: "EditUser", User_ID: $('#hfuser_id').val(), txsFIRST_NAME: $('#txsFIRST_NAME').val(),
                    txsLAST_NAME: $('#txsLAST_NAME').val(), txsPOSITION: $('#txsPOSITION').val()
                    , txsDEPARTMENT: $('#txsDEPARTMENT').val(), txsSTREET_ADDRESS: $('#txsSTREET_ADDRESS').val()
                    , txsCITY: $('#txsCITY').val()
                    , txsINSTITUTION: $('#txsINSTITUTION').val()
                    , txsCOUNTRY: $('#txsCOUNTRY').val()
                    , txsPHONE: $('#txsPHONE').val()
                    , txsFAX: $('#txsFAX').val()
                    , txsEMAIL: $('#txsEMAIL').val()
                },
                success: function (msg) {
                    $('#dlg2').dialog('close');
                    $('#test').datagrid('reload');
                    $.messager.alert('info', msg);
                }
            });
        else
            alert('验证失败！');
    }

    function DisEdit() {
        //通过getSelected取出一行的所有信息  
        var row = $('#test').datagrid('getSelected');
        var rows = $('#test').datagrid('getSelections');
        if (row) {
            //判断是否多选  
            if (rows.length > 1) {
                $.messager.alert('Warning', '请不要多选');
            }
            else {
    
                $('#dlg').click();
                url = 'Getdatagrid.ashx';
                $("#dlg").dialog({
                    title: 'User Modify',
                    modal: true,
                    collapsible: true,
                    resizable: true
                });
                //赋值  

                $('#USER_ID').attr('value', row.USER_ID);
                $('#USER_CODE').attr('value', row.USER_CODE);
//                $('#USER_PWD').attr('value', '000');
                $('#ROLE_TYPE').attr('value', row.ROLE_TYPE);
                $('#PROJECT_CODE').attr('value', row.PROJECT_CODE);
                $('#PART_MENT').attr('value', row.PART_MENT);
                $('#EMAIL').attr('value', row.EMAIL);
                $('#REMARK').attr('value', row.REMARK);

               
         
            }
        }
        else {
            $.messager.alert('Warning', '请选择');
        }
    }
    //添加,修改执行方法  
    function AddFuc() {
        var flag = true;
        $('#dlg input').each(function () {
            if ($(this).attr('required') || $(this).attr('validType')) {
                if (!$(this).validatebox('isValid')) {
                    flag = false;
                    return;
                }
            }
        })
        if (flag)
            $.ajax({
                type: 'post',
                url: url,
                data: { M: "Ins", User_ID: $('#USER_ID').val(), USER_CODE: $('#USER_CODE').val(), USER_PWD: $('#USER_PWD').val(), ROLE_TYPE: $('#ROLE_TYPE').val(), PROJECT_CODE: $('#PROJECT_CODE').val()
                    , PART_MENT: $('#PART_MENT').val(), EMAIL: $('#EMAIL').val(), REMARK: $('#REMARK').val()
                },
                success: function (msg) {
                    $('#dlg').dialog('close');
                    $('#test').datagrid('reload');
                    $.messager.alert('info', msg);
                }
            });
        else
            alert('验证失败！');

    }

    //删除方法  
    function DelFun() {
        url = 'Getdatagrid.ashx';
        var row = $('#test').datagrid('getSelected');
        var rows = $('#test').datagrid('getSelections');
        //是否选择，也可以用if(row)来判断(一个返回null一个返回array)  
        if (rows.length > 0) {
            $.messager.confirm('确认', '是否真的删除?', function (r) {
                if (r) {
                    var ids = [];
                    for (var i = 0; i < rows.length; i++) {
                        //每行ID放入数组中  
                        ids.push(rows[i].USER_ID);
                    }
                    //必须为string类型，不然传不过去  
                    var aa = ids.toString();
                    $.ajax({
                        type: 'post',
                        url: url,
                        data: { M: 'Del', USER_ID: aa },
                        success: function (msg) { $('#test').datagrid('reload'); $('#test').datagrid('clearSelections'); } //设置可以多选后，删除一条后再删除一条会提示删除两条，实际上只删除了一条，已经删除的那一条没有清空   

                    });
                }
            });
        }
        else {
            $.messager.alert('Warning', '请选择');
        }
    }
    function addTab(name, url) {
        if ($('#tt').tabs('exists', name)) {
            $('#tt').tabs('select', name);
        }
        else {
            $('#tt').tabs('add', {
                title: name,
                content: "<iframe id = '" + name + "' scrolling='yes' frameborder='0'  src='" + url + "' style='width:100%;height:100%;'></iframe>",
                iconCls: 'icon-tab',
                closable: true

            });
        }
    }

    function getUserFunction(userid) {
        $('#hfuser_id').val(userid);
        if ($('#hfuser_id').val() != "") {
            $('#iframeUserfunction').attr('src', 'UserFunction.aspx?uid=' + $('#hfuser_id').val());
            $('#iframeUserfunction').height(480);
            $('#open_userFunction').click();
        }

    }
    function deleteUser() {

        //var rows = $('#test').datagrid('getSelected');
        var rows = $('#test').datagrid('getChecked');
        if (rows.length > 0) {
            if (confirm('Are you confirm this?')) {
                $.ajax({
                    type: "POST",
                    dataType: "text",
                    url: "UserFunction.ashx?M=DeleteUser",
                    data: "USER_ID=" + rows[0].USER_ID,
                    success: function (msg) {
                        if (msg != "") {
                            $.messager.alert("info", msg, "info", null);
                            $("#test").datagrid('load');
                        }
                    }
                });
            }
        }
        else {
            $.messager.alert("info", "Please check a user first.", "info", null);
        }
    }
    </script>
</head>
<body>
    <form id="form1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
       <div id="context" style="overflow: auto">
      <div id="tb2" style="padding: 5px; height: auto">
                <div style="margin-bottom: 5px">
                 Email:
               <input id="searchUser" name="searchUser" type="text" />
                  <a href="javascript:void();" class="easyui-linkbutton" iconcls="icon-search"   onclick="getdata();">
                    Search</a>
                     <a id="btndelete" name="btndelete" href="javascript:void();" class="easyui-linkbutton" iconcls="icon-cancel"  onclick="deleteUser();">
                Delete</a>
                           <a href="javascript:void();" class="easyui-linkbutton" iconcls="icon-save" onclick="htmlExport_old();"
                        id="aExport1">Export</a>
                <asp:Button ID="btnExport1" runat="server" Text="" OnClick="btnExport1_Click" style="display:none" />
                    </div>
      </div>
    <div id="activity_pane">
        <table id="test" cellspacing="0" cellpadding="0"  data-options="toolbar:'#tb2'">
        </table>
    </div>
     <a id="dlg" class="fancybox" href="#inline2"></a>
    <div id="inline2" style="width: 400px; height: 400px; display: none">
        <table style="text-align: center; margin: 0 auto;" cellspacing="0" cellpadding="0">
            <tr>
                <td>
                    User_ID:
                </td>
                <td>
                    <input id="USER_ID" class="easyui-validatebox" disabled="disabled" />
                </td>
            </tr>
            <tr>
                <td>
                    User Name:
                </td>
                <td>
                    <input id="USER_CODE" class="easyui-validatebox" data-options="required:true" validtype="length[3,20]" />
                </td>
            </tr>
            <tr>
                <td>
                    User Password:
                </td>
                <td>
                    <input id="USER_PWD" class="easyui-validatebox" data-options="required:true" validtype="length[3,20]"
                        type="password" />
                </td>
            </tr>
            <tr>
                <td>
                    ROLE_TYPE:
                </td>
                <td>
                    <input id="ROLE_TYPE" class="easyui-validatebox" />
                </td>
            </tr>
            <tr>
                <td>
                    PROJECT_CODE:
                </td>
                <td>
                    <input id="PROJECT_CODE" class="easyui-validatebox" />
                </td>
            </tr>
            <tr>
                <td>
                    PART_MENT:
                </td>
                <td>
                    <input id="PART_MENT" class="easyui-validatebox" />
                </td>
            </tr>
            <tr>
                <td>
                    Email:
                </td>
                <td>
                    <input id="EMAIL" class="easyui-validatebox" validtype="email" />
                </td>
            </tr>
            <tr>
                <td>
                    Remark:
                </td>
                <td>
                    <textarea id="REMARK" class="easyui-validatebox" style="height: 100px;"></textarea>
                </td>
            </tr>
            <tr style="height: 30px">
            </tr>
            <tr>
                <td>
                    <input type="button" value="提交" onclick="AddFuc()" />
                </td>
                <td>
                    <input type="button" value="关闭" onclick="javascirpt:$('#dlg').dialog('close')" />
                </td>
            </tr>
        </table>
    </div>
    
    <div id="dlg2" style="width: 500px; height: 450px; display: none; overflow: auto">
        <table width="100%" border="0" align="center" cellpadding="0" cellspacing="1" class="tb1">
            <%--<tr>
			<td class="td_left">User Name:</td>
			<td class="td_right"><input id="txsUSER_CODE"/></td>
		</tr>--%>
            <tr>
                <td class="td_left">
                    First Name:
                </td>
                <td class="td_right">
                    <input id="txsFIRST_NAME" />
                </td>
            </tr>
            <tr>
                <td class="td_left">
                    Last Name:
                </td>
                <td class="td_right">
                    <input id="txsLAST_NAME" />
                </td>
            </tr>
            <tr>
                <td class="td_left">
                    Position/Title:
                </td>
                <td class="td_right">
                    <input id="txsPOSITION" />
                </td>
            </tr>
            <tr>
                <td class="td_left">
                    Department:
                </td>
                <td class="td_right">
                    <input id="txsDEPARTMENT" />
                </td>
            </tr>
            <tr>
                <td class="td_left">
                    Institution:
                </td>
                <td class="td_right">
                    <input id="txsINSTITUTION" />
                </td>
            </tr>
            <tr>
                <td class="td_left">
                    Street Address:
                </td>
                <td class="td_right">
                    <input id="txsSTREET_ADDRESS" />
                </td>
            </tr>
            <tr>
                <td class="td_left">
                    City and State:
                </td>
                <td class="td_right">
                    <input id="txsCITY" />
                </td>
            </tr>
            <tr>
                <td class="td_left">
                    Country:
                </td>
                <td class="td_right">
                    <input id="txsCOUNTRY" />
                </td>
            </tr>
            <tr>
                <td class="td_left">
                    Phone number:
                </td>
                <td class="td_right">
                    <input id="txsPHONE" />
                </td>
            </tr>
            <tr>
                <td class="td_left">
                    Fax number:
                </td>
                <td class="td_right">
                    <input id="txsFAX" />
                </td>
            </tr>
            <tr>
                <td class="td_left">
                    Company Email:
                </td>
                <td class="td_right">
                    <input id="txsEMAIL" />
                </td>
            </tr>
            <tr>
                <td class="td_left">
                    Available:
                </td>
                <td class="td_right">
                    <input id="txsIS_AVAILABLE" />
                </td>
            </tr>
            <tr>
                <td class="td_left">
                    Role:
                </td>
                <td class="td_right">
                    <input id="txsROLE_TYPE" disabled="disabled"/>
                </td>
            </tr>
            <tr>
                <td class="td_left">
                    Time end:
                </td>
                <td class="td_right">
                    <input id="txsUPDATE_TIME" />
                </td>
            </tr>
           
             <tr>
            <td class="td_left">
             
            </td>
            <td class="td_right">
             <a  class="easyui-linkbutton"  onclick="editUser();" id="btnSave">Save</a>
            </td>
        </tr>
        </table>
    </div>
    <div>
        <input id="hfuser_id" name="hfuser_id" type="hidden" />
                <a id="open_userFunction" class="fancybox" href="#inline1"></a>
                <div id="inline1" style="width: 800px; height: 480px;display: none;">
                    <iframe runat="server" id="iframeUserfunction" width="100%" height="480px" frameborder="0"
            border="0"></iframe>
                </div>
          
    </div>
    </div>
    </form>
</body>
</html>
