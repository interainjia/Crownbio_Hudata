$(function () {
    bindGrid();
    $('.fancybox').fancybox();
    $('#hfRoleID').val("-1");
});



function query() {
    var url = "UserFunction.ashx?M=getdgUserRole";
    $('#dgUserRole').datagrid('options').url = url;
    $("#dgUserRole").datagrid('load');
  
}
function bindGrid() {
    $('#dgUserRole').datagrid({
        width: 'auto',
        height: 'auto',
        url: 'UserFunction.ashx?M=getdgUserRole',
        nowrap: false,
        striped: true,
        singleSelect: true,
        remoteSort: false,
        pagination: true,
        rownumbers: true,
        pageSize: 15,
        pageList: [15, 30, 45, 60],
        frozenColumns: [[
                    { field: 'ck', checkbox: true },
                    { field: 'ROLE_ID', title: 'ROLE_ID', width: 100, sortable: false }
                ]],
        columns: [[
                      { field: 'ROLE_NAME', title: 'ROLE_NAME', width: 200, sortable: false }
                   

                 ]]

    });

    //设置分页控件属性  
    var p = $('#dgUserRole').datagrid('getPager');
    $(p).pagination({
        beforePageText: 'Page',
        afterPageText: 'of {pages}',
        displayMsg: 'Displaying {from} to {to} of {total} items'
    });
}

function add() {
    $('#hfRoleID').val("-1");
    $('#iframeUserRole').attr('src', 'RoleFunction.aspx?roleNo=-1&roleID=' + $('#hfRoleID').val());
    $('#iframeUserRole').height(480);
    $('#open_userRole').click();

}

function edit() {
    var row = $('#dgUserRole').datagrid('getChecked');
    if (row.length > 0) {
        $('#hfRoleID').val(row[0].ROLE_ID);
        $('#iframeUserRole').attr('src', 'RoleFunction.aspx?roleNo=' + row[0].ROLE_NO + '&roleID=' + $('#hfRoleID').val());
        $('#iframeUserRole').height(480);
        $('#open_userRole').click();
    }
}

function deleteRole() {
    var rows = $('#dgUserRole').datagrid('getChecked');
    if (rows.length > 0) {
        if (confirm('Are you confirm this?')) {
            $.ajax({
                type: "POST",
                dataType: "text",
                url: "UserFunction.ashx?M=DeleteRole",
                data: "roleID=" + rows[0].ROLE_ID,
                success: function (msg) {
                    if (msg != "") {
                        $.messager.alert("info", msg, "info", null);
                        $("#dgUserRole").datagrid('load');
                    }
                }
            });
        }
    }
    else {
        $.messager.alert("info", "Please check a role first.", "info", null);
    }
}
