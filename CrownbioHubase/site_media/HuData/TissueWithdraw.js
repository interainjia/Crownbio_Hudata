$(function () {
   

  
    bindGrid();
    bindGrid_Completed();
});



function getdgTissueWithdraw() {
    var params = { model_id: $('#searchModel_ID').val()
     , searchProjectNumber: $('#searchProjectNumber').val()
     , S_Date_of_Withdraw: $('#S_Date_of_Withdraw').datebox('getValue')
    };
    $("#dgTissueWithdraw").datagrid('load', params);
}

function bindGrid() {
    $('#dgTissueWithdraw').datagrid({
        url: 'Getdatagrid.ashx?M=getdgTissueWithdraw',
        iconCls: 'icon-export',
        width: 'auto',
        height: 'auto',
        title: "Tissue Withdraw",
        idField: 'Tissue_Withdraw_ID',
        fitColumns: false,
        singleSelect: true,
        nowrap: false,
        striped: true,
        selectOnCheck: false,
        checkOnSelect: false,
        remoteSort: true,
        pagination: true,
        rownumbers: true,
        pageSize: 10,
        pageList: [10, 20, 30, 40],
        frozenColumns: [[
                            { field: 'ck', checkbox: true },
                    { field: 'Model_ID', title: 'Model_ID', width: 100, sortable: false }

                ]],
        columns: [[

                    { field: 'Rn', title: 'Rn', width: 80, sortable: false },
                      { field: 'Pn', title: 'Pn', width: 80, sortable: false },
                       { field: 'Date_of_Inoculation', title: 'Date_of_Inoculation', width: 150, sortable: false, formatter: myformatter },
                      { field: 'Animal_Number', title: 'Animal_Number', width: 150, sortable: false },
                       { field: 'Total_Tumor_Volume', title: 'Total_Tumor_Volume', width: 200, sortable: false },
                        { field: 'Date_of_Tissue_Collection', title: 'Date_of_Tissue_Collection', width: 200, sortable: false, formatter: myformatter },
                      { field: 'Site_of_Tissue_Collection', title: 'Site_of_Tissue_Collection', width: 200, sortable: false },
                      { field: 'Tissue_Type', title: 'Tissue_Type', width: 100, sortable: false },
                      { field: 'Preserve_Method', title: 'Preserve_Method', width: 150, sortable: false },
                     { field: 'Treatment_To_Mice', title: 'Treatment_To_Mice', width: 150, sortable: false },
                       { field: 'Location_ID', title: 'Location_ID', width: 200, sortable: false,
                           formatter: function (value, rowData, rowIndex) {
                               return "<a href='javascript:void();' onclick='openStorgeMap(&quot;" + rowData.Location_ID + "&quot;);'>" + rowData.Location_ID + "</a>";
                           }
                       },
                      { field: 'Well_ID', title: 'Well_ID', width: 100, sortable: false },
                      { field: 'Withdraw_Date', title: 'Withdraw_Date', width: 100, sortable: false, formatter: myformatter },
                      { field: 'Withdraw_Project_Number', title: 'Withdraw_Project_Number', width: 150, sortable: false }


                 ]]



    });

    //设置分页控件属性  
    var p = $('#dgTissueWithdraw').datagrid('getPager');
    $(p).pagination({
        beforePageText: 'Page',
        afterPageText: 'of {pages}',
        displayMsg: 'Displaying {from} to {to} of {total} items'
    });
}

function getdgTissueWithdraw_Completed() {
    var params = { model_id: $('#searchModel_ID2').val()
       , searchProjectNumber: $('#searchProjectNumber2').val()
        , S_Date_of_Withdraw2: $('#S_Date_of_Withdraw2').datebox('getValue')
    };
    $("#dgTissueWithdraw_Completed").datagrid('load', params);
}

function bindGrid_Completed() {
    $('#dgTissueWithdraw_Completed').datagrid({
        url: 'Getdatagrid.ashx?M=getdgTissueWithdraw_Completed',
        iconCls: 'icon-export',
        width: 'auto',
        height: 'auto',
        title: "Tissue Withdraw Completed",
        idField: 'Tissue_Withdraw_ID',
        fitColumns: false,
        singleSelect: true,
        nowrap: false,
        striped: true,
        selectOnCheck: false,
        checkOnSelect: false,
        remoteSort: true,
        pagination: true,
        rownumbers: true,
        pageSize: 10,
        pageList: [10, 20, 30, 40],
        frozenColumns: [[

                    { field: 'Model_ID', title: 'Model_ID', width: 100, sortable: false }

                ]],
        columns: [[

                    { field: 'Rn', title: 'Rn', width: 80, sortable: false },
                      { field: 'Pn', title: 'Pn', width: 80, sortable: false },
                       { field: 'Date_of_Inoculation', title: 'Date_of_Inoculation', width: 150, sortable: false, formatter: myformatter },
                      { field: 'Animal_Number', title: 'Animal_Number', width: 150, sortable: false },
                       { field: 'Total_Tumor_Volume', title: 'Total_Tumor_Volume', width: 200, sortable: false },
                        { field: 'Date_of_Tissue_Collection', title: 'Date_of_Tissue_Collection', width: 200, sortable: false, formatter: myformatter },
                      { field: 'Site_of_Tissue_Collection', title: 'Site_of_Tissue_Collection', width: 200, sortable: false },
                      { field: 'Tissue_Type', title: 'Tissue_Type', width: 100, sortable: false },
                      { field: 'Preserve_Method', title: 'Preserve_Method', width: 150, sortable: false },
                     { field: 'Treatment_To_Mice', title: 'Treatment_To_Mice', width: 150, sortable: false },
                       { field: 'Location_ID', title: 'Location_ID', width: 200, sortable: false,
                           formatter: function (value, rowData, rowIndex) {
                               return "<a href='javascript:void();' onclick='openStorgeMap(&quot;" + rowData.Location_ID + "&quot;);'>" + rowData.Location_ID + "</a>";
                           }
                       },
                      { field: 'Well_ID', title: 'Well_ID', width: 100, sortable: false },
                      { field: 'Withdraw_Date', title: 'Withdraw_Date', width: 100, sortable: false, formatter: myformatter },
                      { field: 'Withdraw_Project_Number', title: 'Withdraw_Project_Number', width: 150, sortable: false }


                 ]]



    });

    //设置分页控件属性  
    var p = $('#dgTissueWithdraw_Completed').datagrid('getPager');
    $(p).pagination({
        beforePageText: 'Page',
        afterPageText: 'of {pages}',
        displayMsg: 'Displaying {from} to {to} of {total} items'
    });
}

function htmlExport_old2() {
    var btn = document.getElementById('btnExport2');
    btn.click();
}

function Preserve_Amount() {
    var btn = document.getElementById('btnExport_amount');
    btn.click();
}

function openStorgeMap(Location_ID) {
    if (window.parent.$('#tt').tabs('exists', 'Storage Maps')) {
        window.parent.updateTab('Storage Maps', '../HuData/StorageMaps.aspx?Location_id=' + Location_ID + '');
    }
    else {
        window.parent.addTab('Storage Maps', '../HuData/StorageMaps.aspx?Location_id=' + Location_ID + '');
    }
}


function ConfirmWithDraw() {
    if (confirm('Are you confirm this?')) {
    if ($('#txtProjectNumber').val() != "") {
        var rows = $('#dgTissueWithdraw').datagrid('getChecked');
        if (rows.length > 0) {
            var ids = [];
            for (var i = 0; i < rows.length; i++) {
                //每行ID放入数组中
                ids.push(rows[i].Tissue_Withdraw_ID);
            }
            //必须为string类型，不然传不过去  
            var aa = ids.toString();
            $.ajax({
                type: "POST",
                dataType: "text",
                url: "Person.ashx?M=ConfirmWithDraw",
                data: "id=" + aa,
                success: function (data) {
                    if (data == "") {
                        $.messager.alert("info", "Confirm successfully.", "info", null);
                        $("#dgTissueWithdraw").datagrid('reload');
                        $("#dgTissueWithdraw_Completed").datagrid('reload');
                        $('#dgTissueWithdraw').datagrid('clearChecked');
                    }
                    else {
                        $.messager.alert("info", data, "info", null);
                    }
                }
            });
        }
        else {
            $.messager.alert("info", "Please check the records to confirm.", "info", null);
        }
    }
    else {
        $.messager.alert("info", "Please select the project number.", "info", null);
    }
    }

}



function CancelWithDraw() {
    if (confirm('Are you confirm this?')) {

        var rows = $('#dgTissueWithdraw').datagrid('getChecked');
        if (rows.length > 0) {
            var ids = [];
            for (var i = 0; i < rows.length; i++) {
                //每行ID放入数组中
                ids.push(rows[i].Tissue_Withdraw_ID);
            }
            //必须为string类型，不然传不过去  
            var aa = ids.toString();
            $.ajax({
                type: "POST",
                dataType: "text",
                url: "Person.ashx?M=CancelWithDraw",
                data: "id=" + aa,
                success: function (data) {
                    if (data == "") {
                        $.messager.alert("info", "Cancel successfully.", "info", null);
                        $("#dgTissueWithdraw").datagrid('reload');
                        $('#dgTissueWithdraw').datagrid('clearChecked');
                    }
                    else {
                        $.messager.alert("info", data, "info", null);
                    }
                }
            });
        }
        else {
            $.messager.alert("info", "Please check the records to confirm.", "info", null);
        }
    }
}
