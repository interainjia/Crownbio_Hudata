$(function () {
    bindGrid();

   
});



function query() {
    var url = "Getdatagrid.ashx?M=getdgTakeRate";
    $('#dgTakeRate').datagrid('options').url = url;
    $("#dgTakeRate").datagrid('load');
  
}
function bindGrid() {
    $('#dgTakeRate').datagrid({
        width: 'auto',
        height: 'auto',
        url: 'Getdatagrid.ashx?M=getdgTakeRate',
        nowrap: false,
        striped: true,
        singleSelect: true,
        remoteSort: false,
        pagination: true,
        rownumbers: true,
        pageSize: 15,
        pageList: [15, 30, 45, 60],
        frozenColumns: [[

                    { field: 'Cancer_Type_Abbr', title: 'Cancer_Type_Abbr', width: 100, sortable: false }
                ]],
        columns: [[
                      { field: 'Total_PDX_Engraftment', title: 'Total_PDX_Engraftment', width: 100, sortable: false }
                   , { field: 'Established_PDX_Model', title: 'Established_PDX_Model', width: 100, sortable: false }
                     , { field: 'Take_Rate', title: 'Take_Rate', width: 100, sortable: false }
//                    , { field: 'Fit_for_Efficacy', title: 'Fit_for_Efficacy', width: 100, sortable: false }
//                     , { field: 'Live_Models', title: 'Live_Models', width: 100, sortable: false }
//                        , { field: 'Maintain', title: 'Maintain', width: 100, sortable: false }
                 ]]

    });

    //设置分页控件属性  
    var p = $('#dgTakeRate').datagrid('getPager');
    $(p).pagination({
        beforePageText: 'Page',
        afterPageText: 'of {pages}',
        displayMsg: 'Displaying {from} to {to} of {total} items'
    });
}

