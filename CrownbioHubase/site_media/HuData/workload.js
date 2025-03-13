$(function () {
    var firstbind = true;
    dgGridBind();
    $('#txtName').combobox({
        editable: true,
        url: 'Person.ashx?M=getWorkloadPerson&cbxDep=SD' ,
        valueField: 'id',
        textField: 'text'
    });
    dgDTgroupGridBind();
});

function ddlDT() {
    $('#txtName').combobox({
        editable: true,
        url: 'Person.ashx?M=getWorkloadPerson&cbxDep=' + $('#cbxDep').val(),
        valueField: 'id',
        textField: 'text'
    });
}function getdgWorkload() {
    firstbind = true;
    var params = { cbxDep: $('#cbxDep').val(), txtName: $('#txtName').combobox('getValue')};
    $("#dgWorkload").datagrid('load', params);
}
function dgGridBind() {
    firstbind = true;
    //绑定datagrid
    $('#dgWorkload').datagrid({
        title: 'Workload',
        iconCls: 'icon-export',
        url: 'Getdatagrid.ashx?M=getdgWorkload',
        width: 'auto',
        height: 'auto',
        fitColumns: true,
        singleSelect: true,
        nowrap: false,
        striped: true,
        remoteSort: false,
        pagination: true,
        rownumbers: true,
        pageSize: 10,
        pageList: [10, 20, 40],
        columns: [[
                    
                      { field: 'Date_of_Workload', title: 'Date of Workload', width: 100, sortable: false },
                      { field: 'Person', title: 'Person', width: 120, sortable: false },
                      { field: 'STUDY_WORKLOAD', title: 'Workload(Minute)', width: 120, sortable: false },
                      ]]
                , onLoadSuccess: function (data) {
                    if (firstbind) {
                        //showFlash($('#txtName').val());
                    }

                    if (data.rows.length > 0) {
                        document.getElementById("aExport1").style.display = "block";
                    }
                    else {
                        document.getElementById("aExport1").style.display = "none";
                    }

                }
    });

    //设置分页控件属性  
    var p = $('#dgWorkload').datagrid('getPager');
    $(p).pagination({
        beforePageText: 'Page',
        afterPageText: 'of {pages}',
        displayMsg: 'Displaying {from} to {to} of {total} items'
    });
}

function dgDTgroupGridBind() {

    //绑定datagrid
    $('#dgDTgroup').datagrid({
        title: 'DTgroup workload',
        iconCls: 'icon-export',
        url: 'Getdatagrid.ashx?M=getdgDTgroup',
        width: 'auto',
        height: 'auto',
        fitColumns: true,
        singleSelect: true,
        nowrap: false,
        striped: true,
        remoteSort: false,
        pagination: true,
        rownumbers: true,
        pageSize: 10,
        pageList: [10, 20, 40],
        columns: [[

                      { field: 'DTgroup', title: 'DT group', width: 100, sortable: false },
                      { field: 'today', title: 'today', width: 100, sortable: false },
                      { field: '10days', title: '+10 days', width: 100, sortable: false },
                      { field: '20days', title: '+20 days', width: 100, sortable: false },
                      { field: '30days', title: '+30 days', width: 100, sortable: false },
                      { field: '40days', title: '+40 days', width: 100, sortable: false },
                      { field: '50days', title: '+50 days', width: 100, sortable: false },
                      { field: '60days', title: '+60 days', width: 100, sortable: false }
                      ]]



    });

    //设置分页控件属性  
    var p = $('#dgDTgroup').datagrid('getPager');
    $(p).pagination({
        beforePageText: 'Page',
        afterPageText: 'of {pages}',
        displayMsg: 'Displaying {from} to {to} of {total} items'
    });
}