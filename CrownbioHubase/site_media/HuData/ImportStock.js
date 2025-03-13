$(function () {
    bindAction1();

    bindGrid();
});

function doAction1() {
    //    var Select1 = document.getElementById('Select1');
    //    var Select = Select1.options[Select1.selectedIndex].text;
    var form = document.getElementById("uploadexcel");
    //    if (Select == "Specimen Stock(.xlsx)") {
    form.action = "importDB.ashx?Tablename=SpecimenStock&S_region=" + $('input:radio[name=S_region]:checked').val();
    //    }
    $('#uploadexcel').submit();
}
function doAction2() {
    //    var Select1 = document.getElementById('Select1');
    //    var Select = Select1.options[Select1.selectedIndex].text;
    var form = document.getElementById("uploadexcel");
    //    if (Select == "Specimen Stock(.xlsx)") {
    form.action = "importDB.ashx?Tablename=Tissue_Withdraw";
    //    }
    $('#uploadexcel').submit();
}

function bindAction1() {
    $('#uploadexcel').form({
        onSubmit: function () {
            if (confirm('Are you confirm this?')) {
                jQuery('#activity_pane').showLoading(
	 			         {
	 			             'addClass': 'loading-indicator-bars'
	 			         }
				        );

                var file = ($("#FileUpload").val());
                var file2 = ($("#FileUpload2").val());
                if (file == "" && file2 == "") {
                    $.messager.alert('info', 'Please select a csv file.');
                    jQuery('#activity_pane').hideLoading();
                    return false;
                }

                else {
                    var re = /(\\+)/g;
                    var filename;
                    if (file != "")
                    { filename = file.replace(re, "#"); }
                    else { filename = file2.replace(re, "#"); }

                    //对路径字符串进行剪切截取
                    var one = filename.split("#");
                    //获取数组中最后一个，即文件名
                    var two = one[one.length - 1];
                    //再对文件名进行截取，以取得后缀名
                    var three = two.split(".");
                    //获取截取的最后一个字符串，即为后缀名
                    var stuff = three[three.length - 1];
                    if (stuff != 'xlsx') {
                        $.messager.alert('Import', 'Please select a xlsx file.');
                        jQuery('#activity_pane').hideLoading();
                        return false;
                    }
                    else {
                        return true;
                    }

                }
            }
            else {
                return false;
            }
        },
        success: function (data) {
            jQuery('#activity_pane').hideLoading();
            $("#dgTissueStock").datagrid('load');
            $.messager.alert('Import', data, 'info');
            $('#dgTissueStock').datagrid('clearChecked');

        },
        error: function (result) { //如果没有上面的捕获出错会执行这里的回调函数
            $.messager.alert('Import', result, 'error');
            jQuery('#activity_pane').hideLoading();
            $('#dgTissueStock').datagrid('clearChecked');
        }
    });

}



function getTemp_dgTissueStock() {
    var params = {
}
    $("#dgTissueStock").datagrid('load', params);
}

function bindGrid() {
    $('#dgTissueStock').datagrid({
        url: 'Getdatagrid.ashx?M=getTemp_dgTissueStock',
        iconCls: 'icon-export',
        width: 'auto',
        height: 'auto',
        title: "Specimen Stocks",
        idField: 'Specimen_Stock_ID',
        fitColumns: false,
        singleSelect: false,
        nowrap: false,
        striped: true,
        remoteSort: true,
        pagination: true,
        rownumbers: true,
        pageSize: 10,
        pageList: [10, 20, 30, 40,1000],
        frozenColumns: [[
                            { field: 'ck', checkbox: true },
                    { field: 'Model_ID', title: 'Model_ID', width: 100, sortable: false, styler: cellStyler }

                ]],
        columns: [[

                    { field: 'Rn', title: 'Rn', width: 80, sortable: false },
                      { field: 'Pn', title: 'Pn', width: 80, sortable: false },
                       { field: 'Date_of_Inoculation', title: 'Date_of_Inoculation', width: 150, sortable: false },
                      { field: 'Animal_Number', title: 'Animal_Number', width: 150, sortable: false },
                       { field: 'Total_Tumor_Volume', title: 'Total_Tumor_Volume', width: 200, sortable: false },
                        { field: 'Date_of_Tissue_Collection', title: 'Date_of_Tissue_Collection', width: 200, sortable: false },
                      { field: 'Site_of_Tissue_Collection', title: 'Site_of_Tissue_Collection', width: 200, sortable: false },
                      { field: 'Tissue_Type', title: 'Tissue_Type', width: 100, sortable: false },
                      { field: 'Preserve_Method', title: 'Preserve_Method', width: 150, sortable: false },
                     { field: 'Treatment_To_Mice', title: 'Treatment_To_Mice', width: 150, sortable: false },
                       { field: 'Location_ID', title: 'Location_ID', width: 150, sortable: false },
                      { field: 'Well_ID', title: 'Well_ID', width: 100, sortable: false},
                      { field: 'Import_Date', title: 'Import_Date', width: 100, sortable: false },
                      { field: 'Import_Project_Number', title: 'Import_Project_Number', width: 150, sortable: false },
                  { field: 'Export_Date', title: 'Export_Date', width: 100, sortable: false },
                      { field: 'Export_Project_Number', title: 'Export_Project_Number', width: 150, sortable: false },
                       { field: 'STR', title: 'STR', width: 100, sortable: false }
//                           , { field: 'opt1', title: '', align: 'left', width: 80,
//                               formatter: function (value, rowData, rowIndex) {
//                                   if (rowData.log_count != "") {
//                                       return "<a href='#' onclick='getdgModifyRequest(&quot;" + rowData.REQUEST_ID + "&quot;);'>log</a>";
//                                   }
//                                   else {
//                                       return "";
//                                   }
//                               }
//                           }
                 ]]
                   , onClickRow: function (rowIndex, rowData) {
//                       $('#hfRequest_id').val(rowData.REQUEST_ID);
//                       EditRequest(rowData);
//                       getdgSelectMice(rowData.REQUEST_ID);
//                       AutoSubproject(rowData.REQUEST_ID, rowData.PARENT_PROJECT);
                   }


    });

    //设置分页控件属性  
    var p = $('#dgTissueStock').datagrid('getPager');
    $(p).pagination({
        beforePageText: 'Page',
        afterPageText: 'of {pages}',
        displayMsg: 'Displaying {from} to {to} of {total} items'
    });
}


function btnSaveStock() {
    if (confirm('Are you confirm this?')) {
        jQuery('#activity_pane').showLoading(
	 			         {
	 			             'addClass': 'loading-indicator-bars'
	 			         }
				        );
        var rows = $('#dgTissueStock').datagrid('getChecked');
        if (rows.length > 0) {
            var ids = [];
            for (var i = 0; i < rows.length; i++) {
                //每行ID放入数组中
                ids.push(rows[i].Specimen_Stock_ID);
            }
            //必须为string类型，不然传不过去  
            var aa = ids.toString();
            $.ajax({
                type: "POST",
                dataType: "text",
                url: "Person.ashx?M=SaveTissueStock",
                data: "id=" + aa,
                success: function (data) {
                    if (data == "") {
                        jQuery('#activity_pane').hideLoading();
                        $.messager.alert("info", "Import successfully.", "info", null);
                        getTemp_dgTissueStock();
                        $('#dgTissueStock').datagrid('clearChecked');
                    }
                    else {
                        $.messager.alert("info", msg, "info", null);
                    }
                }
            });
        }
        else {
            jQuery('#activity_pane').hideLoading();
            $.messager.alert("info", "Please check the records to import.", "info", null);
        }
    }
}


function cellStyler(value, rowData, rowIndex) {
    if (rowData.have_animal == "yes") {
        return 'background-color:#ffee00;color:red;';
    }
}


function btnSaveWithdraw() {
    if (confirm('Are you confirm this?')) {
        jQuery('#activity_pane').showLoading(
	 			         {
	 			             'addClass': 'loading-indicator-bars'
	 			         }
				        );
        var rows = $('#dgTissueStock').datagrid('getChecked');
        if (rows.length > 0) {
            var ids = [];
            for (var i = 0; i < rows.length; i++) {
                //每行ID放入数组中
                ids.push("'" + rows[i].Specimen_Stock_ID + "'");
            }
            //必须为string类型，不然传不过去  
            var aa = ids.toString();
            $.ajax({
                type: "POST",
                dataType: "text",
                url: "Person.ashx?M=SaveWithdraw",
                data: "id=" + aa,
                success: function (data) {
                    if (data == "") {
                        jQuery('#activity_pane').hideLoading();
                        $.messager.alert("info", "Import successfully.", "info", null);
                        getTemp_dgTissueStock();
                        $('#dgTissueStock').datagrid('clearChecked');
                    }
                    else {
                        $.messager.alert("info", msg, "info", null);
                    }
                }
            });
        }
        else {
            jQuery('#activity_pane').hideLoading();
            $.messager.alert("info", "Please check the records to import.", "info", null);
        }
    }
}