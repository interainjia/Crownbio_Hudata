$(function () {
    bindGrid();
    $('.fancybox').fancybox();
    $('#hfddlID').val("-1");
});



function query() {
    var url = "UserFunction.ashx?M=getdgDropDownList";
    $('#dgDropDownList').datagrid('options').url = url;
    $("#dgDropDownList").datagrid('load');
  
}
function bindGrid() {
    $('#dgDropDownList').datagrid({
        width: 'auto',
        height: 'auto',
        url: 'UserFunction.ashx?M=getdgDropDownList',
        nowrap: false,
        fitColumns: true,
        striped: true,
        singleSelect: true,
        remoteSort: false,
        pagination: true,
        rownumbers: true,
        pageSize: 15,
        pageList: [15, 30, 45, 60],
        frozenColumns: [[
                    { field: 'ck', checkbox: true }
                   
                ]],
        columns: [[
                      { field: 'DROPDOWNLIST_NAME', title: 'DropDownList Name', width: 150, sortable: false }
                      , { field: 'DROPDOWNLIST_CONTEXT', title: 'DropDownList Context', width: 200, sortable: false }
                 ]]

    });

    //设置分页控件属性  
    var p = $('#dgDropDownList').datagrid('getPager');
    $(p).pagination({
        beforePageText: 'Page',
        afterPageText: 'of {pages}',
        displayMsg: 'Displaying {from} to {to} of {total} items'
    });
}



function edit() {
    var row = $('#dgDropDownList').datagrid('getChecked');
    if (row.length > 0) {
        $('#hfddlID').val(row[0].DROPDOWNLIST_ID);
        $('#lblName').html(row[0].DROPDOWNLIST_NAME);
        $('#txtContext').val(row[0].DROPDOWNLIST_CONTEXT);
        $('#open_DropDownList').click();
    }
}


function Save() {
    if ($('#hfddlID').val() != "") {
        $.ajax({
            type: "POST",
            dataType: "text",
            url: "UserFunction.ashx?M=SaveDropDownList",
            data: "hfddlID=" + $('#hfddlID').val()
            + "&txtContext=" + $('#txtContext').val(),
            success: function (msg) {
                if (msg == "") {
                    $.messager.alert("info", "Save successfully", "info", null);
                    $('#hfddlID').val("");
                    $("#dgDropDownList").datagrid('reload');

                }
                else { 
                    $.messager.alert("info", msg, "info", null);
                }


            }
        });
    }
}