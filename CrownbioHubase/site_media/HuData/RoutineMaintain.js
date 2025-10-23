$(function () {
    $('#hfStudy').val("-1");
    $('#hfRoutineMaintain_ID').val("-1");
    $('#hfLocation').val("-1");
    bigImg();
    ddl_bind();
    bindGrid();
    getdgAnimalInfo_RoutineMaintain(-1);

    $('#divRoutineMaintainImport').accordion({
        border: false
    });
    bind_dg_logs();
});
function bigImg() {
    if ($('.fancybox').length > 0) {
        $('.fancybox').fancybox({

        });
    }
};

$.extend($.fn.validatebox.defaults.rules, {
    minNumber: {// 验证小数 
        validator: function (value) {
            return /^[\d]+\.?[\d]*$/i.test(value);
        },
        message: 'Please enter a valid number.'
    },
    integer: {// 验证整数 
        validator: function (value) {
            return /^[+]?[0-9]+\d*$/i.test(value);
        },
        message: 'Please enter a valid number.'
    }
});

function ddl_bind() {
    $('#txtCancer_Type_Abbr').combobox({
        editable: false,
        url: 'Person.ashx?M=getCancerType_Abbr',
        valueField: 'id',
        textField: 'text'
        , onLoadSuccess: function () {
            ddlSubtype();
        }
    });
    $('#txtModel_Type').combobox({
        editable: false,
        url: 'Person.ashx?M=getDDLtxtSource&&ddlname=Model%20Type',
        valueField: 'id',
        textField: 'text'
    });
    $('#txtProject').combobox({
        editable: false,
        url: 'Person.ashx?M=getDDLtxtSource&&ddlname=Project',
        valueField: 'id',
        textField: 'text'
    });
    $('#txtLocation').combobox({
        editable: false,
        url: 'Person.ashx?M=getDDLtxtSource&&ddlname=Location',
        valueField: 'id',
        textField: 'text'
    });
    $('#txtOpreation').combobox({
        editable: false,
        url: 'Person.ashx?M=getDDLtxtSource&&ddlname=Opreation',
        valueField: 'id',
        textField: 'text'
    });
    $('#txtAnimal_Strain').combobox({
        editable: false,
        url: 'Person.ashx?M=getDDLtxtSource&&ddlname=Animal%20Strain',
        valueField: 'id',
        textField: 'text'
    });
    $('#txtPDX_growth_status').combobox({
        editable: false,
        url: 'Person.ashx?M=getDDLtxtSource&&ddlname=PDX%20growth%20status',
        valueField: 'id',
        textField: 'text'
    });

    $('#txtPathology_info_available').combobox({
        editable: false,
        url: 'Person.ashx?M=getDDLtxtSource&&ddlname=Pathology%20info%20available',
        valueField: 'id',
        textField: 'text'
    });
    //    $('#txtPathology_info_Qced').combobox({
    //        editable: false,
    //        url: 'Person.ashx?M=getDDLtxtSource&&ddlname=Pathology%20info%20Qced',
    //        valueField: 'id',
    //        textField: 'text'
    //    });
    $('#txtPatient_Pathology_info_Qced').combobox({
        editable: false,
        url: 'Person.ashx?M=getDDLtxtSource&&ddlname=Patient%20Pathology%20info%20Qced',
        valueField: 'id',
        textField: 'text'
    });
}

function ddlSubtype() {
    $('#txtSubtype1').combobox({
        editable: false,
        url: 'Person.ashx?M=getSubtype-combobox&Tumor_Type=' + $('#txtCancer_Type_Abbr').combobox('getText'),
        valueField: 'id',
        textField: 'text'
    });
    $('#txtSubtype2').combobox({
        editable: false,
        url: 'Person.ashx?M=getSubtype2-combobox&Tumor_Type=' + $('#txtCancer_Type_Abbr').combobox('getText'),
        valueField: 'id',
        textField: 'text'
    });
}


$.extend($.fn.combobox.methods, {
    selectedIndex: function (jq, index) {
        if (!index) {
            index = 0;
        }
        $(jq).combobox({
            onLoadSuccess: function () {
                var opt = $(jq).combobox('options');
                var data = $(jq).combobox('getData');
                for (var i = 0; i < data.length; i++) {
                    if (i == index) {
                        $(jq).combobox('setValue', eval('data[index].' + opt.valueField));
                        break;
                    }
                }
            }
        });
    }
});


/***
* 对 特殊字符进行重新编码(转义)
* **/
function URLencode(sStr) {
    return escape(sStr).replace(/\+/g, '%2B').replace(/\"/g, '%22').replace(/\'/g, '%27').replace(/\//g, '%2F').replace(/\#/g, '%23').replace(/\&/g, '%26');
}

var Check = function () {
    if (confirm('Are you confirm this?')) {
        var flag = true;
        $('#RoutineMaintainImport input').each(function () {
            if ($(this).attr('data-options') || $(this).attr('validType')) {
                if ($(this)[0].id != "txtDate_of_Passage_inoculation" && $(this)[0].id != "txtDate_of_Passage_Termination" && $(this)[0].id != "txtDate_of_Pathology_info_Received") {
                    if (!$(this).validatebox('isValid')) {
                        flag = false;
                        return;
                    }
                }
                else if (!$(this).datebox('isValid')) {
                    flag = false;
                    return;
                }

            }
        });

        if (!flag) {//单个保存不满足
            alert('Please fill out the missing info as indicated.');
        }
        else {
            // var type = $('#ddlTumor_Type').combobox('getValue');
            if ($('#hfRoutineMaintain_ID').val() != "-1") {
                CheckIsRole_Edit(function (callback) {
                    if (callback) {
                        save();
                    }
                });
            }
            else {
                save();
            }

        }
    }
}
var save = function () {
    $.ajax({
        type: "POST",
        dataType: "text",
        url: "Person.ashx?M=SaveRoutineMaintain",
        data: "hfRoutineMaintain_ID=" + $('#hfRoutineMaintain_ID').val()
            + "&txtSerial=" + $('#txtSerial').val()
            + "&txtModel_Type=" + $('#txtModel_Type').combobox('getValue')
            + "&txtCancer_Type_Abbr=" + $('#txtCancer_Type_Abbr').combobox('getValue')
            + "&txtSubtype1=" + $('#txtSubtype1').combobox('getValue')
            + "&txtSubtype2=" + $('#txtSubtype2').combobox('getValue')
            + "&txtModel_ID=" + $("#txtModel_ID").val()
            + "&txtProject=" + $('#txtProject').combobox('getValue')
            + "&txtLocation=" + $('#txtLocation').combobox('getValue')
            + "&txtSource_Animal=" + $("#txtSource_Animal").val()
            + "&txtOpreation=" + $('#txtOpreation').combobox('getValue')
            + "&txtRn=" + $("#txtRn").val()
            + "&txtPn=" + $("#txtPn").val()
            + "&txtDate_of_Passage_inoculation=" + $('#txtDate_of_Passage_inoculation').datebox('getValue')
            + "&txtAnimal_Strain=" + $('#txtAnimal_Strain').combobox('getValue')
            + "&txtAnimal_Sex=" + $('#txtAnimal_Sex').combobox('getValue')
            + "&txtCurrent_Animal_Ear_Tag=" + $('#txtCurrent_Animal_Ear_Tag').val()
            + "&txtAnimal_Quantity=" + $('#txtAnimal_Quantity').val()
            + "&txtPDX_growth_status=" + $('#txtPDX_growth_status').combobox('getValue')
            + "&txtDate_of_Passage_Termination=" + $('#txtDate_of_Passage_Termination').datebox('getValue')

            + "&txtComments=" + $('#txtComments').val()
            + "&txtAnimal_Room_Number=" + $('#txtAnimal_Room_Number').val()
            + "&txtModel_Tumor_Characteristics=" + $('#txtModel_Tumor_Characteristics').val()
        ,

        success: function (msg) {
            if (msg == "" || msg == "Send successfully.") {
                $.messager.alert("info", "Save successfully.", "info", null);
                $("#dgRoutineMaintain").datagrid('reload');
                $("#Reset1").click();
                $('#hfStudy').val("-1");
                AddNew_model();
            }
            else {
                $.messager.alert("info", msg, "info", null);
            }
        }
    });
}

var CheckIsRole_Edit = function (callback) {
    var value;
    $.ajax({
        type: "POST",
        dataType: "json",
        async: false,
        url: "Person.ashx?M=CheckIsRole_Edit&_modulepPge=RoutineMaintain"
    }).done(function (msg) {
        if (msg.cbsd && $('#hfLocation').val() != "CBSD") {
            $.messager.alert("info", "Permission Denied", "info", null);
            value = false;
        }
        else if (msg.cbnc && $('#hfLocation').val() != "CBNC") {
            $.messager.alert("info", "Permission Denied", "info", null);
            value = false;
        }
        else {
            value = true;
        }
        callback(value);
    });
}


function htmlExport_old3() {
    var btn = document.getElementById('btnExport3');
    btn.click();
}

function getdgRoutineMaintain() {

    var params = {
        model_id: $('#searchModelID').val()
        , S_Model_Type: $('#S_Model_Type').val()
        , S_Subtype1: $('#S_Subtype1').val()
        , S_Subtype2: $('#S_Subtype2').val()
        , S_Project: $('#S_Project').val()
        , S_Location: $('#S_Location').val()
        , S_Rn: $('#S_Rn').val()
        , S_Pn: $('#S_Pn').val()
        , S_Date_of_Passage_inoculation: $('#S_Date_of_Passage_inoculation').datebox('getValue')
        , S_Current_Animal_Ear_Tag: $('#S_Current_Animal_Ear_Tag').val()
        , model_id: $('#searchModelID').val()
    };
    $("#dgRoutineMaintain").datagrid('load', params);

}

function AddNew_model() {
    $('#hfRoutineMaintain_ID').val("-1");
    $('#hfLocation').val("-1");
    $("#Reset1").click();
    $('#txtModel_Type').combobox('setValue', "");
    $('#txtCancer_Type_Abbr').combobox('setValue', "");
    $('#txtSubtype1').combobox('setValue', "");
    $('#txtSubtype2').combobox('setValue', "");
    $('#txtLocation').combobox('setValue', "");
    $('#txtOpreation').combobox('setValue', "");
    $("#txtDate_of_Passage_inoculation").datebox('setValue', "");
    $('#txtAnimal_Strain').combobox('setValue', "");
    $('#txtAnimal_Sex').combobox('setValue', "");
    $('#txtPDX_growth_status').combobox('setValue', "");
    $("#txtDate_of_Passage_Termination").datebox('setValue', "");


}

function bindGrid() {
    $('#dgRoutineMaintain').datagrid({
        url: 'Getdatagrid.ashx?M=getdgRoutineMaintain',
        iconCls: 'icon-export',
        width: 'auto',
        height: 'auto',
        title: "Routine Maintain",
        fitColumns: false,
        singleSelect: true,
        nowrap: false,
        striped: true,
        remoteSort: true,
        pagination: true,
        rownumbers: true,
        pageSize: 10,
        pageList: [10, 20, 30, 40],
        frozenColumns: [[
            { field: 'ck', checkbox: true },


        ]],
        columns: [[
            { field: 'Serial', title: 'Serial #', width: 80, sortable: false },
            { field: 'Model_Type', title: 'Model Type', width: 120, sortable: false },

            { field: 'Subtype1', title: 'Subtype1', width: 180, sortable: false },
            { field: 'Subtype2', title: 'Subtype2', width: 180, sortable: false },
            { field: 'Model_ID', title: 'Model ID', width: 120, sortable: false },
            { field: 'Project', title: 'Project #', width: 150, sortable: false },

            { field: 'Location', title: 'Location', width: 120, sortable: false },
            { field: 'Source_Animal', title: 'Source Animal', width: 150, sortable: false },

            { field: 'Opreation', title: 'Opreation', width: 150, sortable: false },
            { field: 'Rn', title: 'Rn', width: 100, sortable: false },
            { field: 'Pn', title: 'Pn', width: 100, sortable: false },
            { field: 'Date_of_Passage_inoculation', title: 'Date of Passage inoculation', width: 150, sortable: false },
            { field: 'Study', title: 'Study #', width: 150, sortable: false },
            { field: 'Animal_Strain', title: 'Animal Strain', width: 150, sortable: false },
            { field: 'Animal_Sex', title: 'Animal Sex', width: 100, sortable: false },
            { field: 'Current_Animal_Ear_Tag', title: 'Current Animal Ear Tag', width: 150, sortable: false },
            { field: 'Animal_Quantity', title: 'Animal Quantity', width: 150, sortable: false },
            { field: 'PDX_growth_status', title: 'PDX growth status', width: 150, sortable: false },
            { field: 'Date_of_Passage_Termination', title: 'Date of Passage Termination', width: 200, sortable: false },
            { field: 'Animal_Room_Number', title: 'Animal Room Number', width: 220, sortable: false },
            { field: 'Duration', title: 'Duration(Days)', width: 120, sortable: false },
            { field: 'Model_Tumor_Characteristics', title: 'Model Tumor Characteristics', width: 220, sortable: false },
            { field: 'Comments', title: 'Comments', width: 150, sortable: false },
            {
                field: 'opt1', title: '', align: 'left', width: 80,
                formatter: function (value, rowData, rowIndex) {
                    return "<a href='javascript:void();' onclick='get_logs(&quot;" + rowData.RoutineMaintain_ID + "&quot;);'>log</a>";
                }
            }

        ]]
        , onClickRow: function (rowIndex, rowData) {
            $('#hfRoutineMaintain_ID').val(rowData.RoutineMaintain_ID);
            $('#hfStudy').val(rowData.Study);
            getdgAnimalInfo_RoutineMaintain(rowData.Study);
            EditRoutineMaintain(rowData);
        }


    });

    //设置分页控件属性  
    var p = $('#dgRoutineMaintain').datagrid('getPager');
    $(p).pagination({
        beforePageText: 'Page',
        afterPageText: 'of {pages}',
        displayMsg: 'Displaying {from} to {to} of {total} items'
    });
}

function get_logs(_id) {
    $('#dgRoutineMaintain_Log').datagrid('options').url = 'Getdatagrid.ashx?M=getdgRoutineMaintain_Log';
    var params = { id: _id };
    $("#dgRoutineMaintain_Log").datagrid('load', params);
}
function bind_dg_logs() {
    if ($('#dgRoutineMaintain_Log').length > 0) {
        $('#dgRoutineMaintain_Log').datagrid({
            title: "Log",
            width: '800',
            height: '450',
            nowrap: false,
            striped: true,
            remoteSort: false,
            idField: 'RoutineMaintain_Log_ID',
            pagination: true,
            rownumbers: true,
            singleSelect: true,
            pageSize: 20,
            pageList: [20, 40, 60],
            onLoadSuccess: function (data) {
                if (data.total >= 1) {
                    if ($('#divLog').css('display') != "block") {
                        $('#w-Log').click();

                    }
                }
            },
            columns: [[
                { field: 'Serial', title: 'Serial #', width: 80, sortable: false },
                { field: 'Model_Type', title: 'Model Type', width: 120, sortable: false },
                { field: 'Cancer_Type_Abbr', title: 'Cancer Type Abbr', width: 150, sortable: false },
                { field: 'Subtype1', title: 'Subtype1', width: 180, sortable: false },
                { field: 'Subtype2', title: 'Subtype2', width: 180, sortable: false },
                { field: 'Model_ID', title: 'Model ID', width: 120, sortable: false },
                { field: 'Project', title: 'Project #', width: 150, sortable: false },

                { field: 'Location', title: 'Location', width: 120, sortable: false },
                { field: 'Source_Animal', title: 'Source Animal/Tissue info', width: 220, sortable: false },

                { field: 'Opreation', title: 'Opreation', width: 150, sortable: false },
                { field: 'Rn', title: 'Rn', width: 100, sortable: false },
                { field: 'Pn', title: 'Pn', width: 100, sortable: false },
                { field: 'Date_of_Passage_inoculation', title: 'Date of Passage inoculation', width: 150, sortable: false },
                { field: 'Study', title: 'Study #', width: 150, sortable: false },
                { field: 'Animal_Strain', title: 'Animal Strain', width: 150, sortable: false },
                { field: 'Animal_Sex', title: 'Animal Sex', width: 100, sortable: false },
                { field: 'Current_Animal_Ear_Tag', title: 'Current Animal Ear Tag', width: 150, sortable: false },
                { field: 'Animal_Quantity', title: 'Animal Quantity', width: 150, sortable: false },

                { field: 'Date_of_Passage_Termination', title: 'Date of Passage Termination', width: 200, sortable: false },
                { field: 'Duration', title: 'Duration(Days)', width: 120, sortable: false },

                { field: 'Comments', title: 'Comments', width: 150, sortable: false },
                { field: 'Editor', title: 'Editor', width: 150, sortable: false },
                { field: 'Date_of_Create', title: 'Date_of_Create', width: 150, sortable: false }
            ]]

        });

        //设置分页控件属性  
        var p = $('#dgRoutineMaintain_Log').datagrid('getPager');
        $(p).pagination({
            pageSize: 20,
            pageList: [20, 40, 60],
            beforePageText: 'Page',
            afterPageText: 'of {pages}',
            displayMsg: 'Displaying {from} to {to} of {total} items'
        });
    }
}


function getdgAnimalInfo_RoutineMaintain(Study) {
    var url = "Getdatagrid.ashx?M=getdgAnimalInfo_RoutineMaintain";
    var params = {
        id: Study,
        rows: 20, page: 1
    };
    $.post(url, params, bindGrid_AnimalInfo, "json");
}



function bindGrid_AnimalInfo(data) {
    var options = {
        iconCls: 'icon-export',
        width: 'auto',
        height: 'auto',
        title: "RoutineMaintain-Animal info",
        fitColumns: false,
        singleSelect: true,
        nowrap: false,
        striped: true,
        remoteSort: true,
        pagination: true,
        rownumbers: true,
        pageSize: 20,
        pageList: [20, 30, 40, 50],
        frozenColumns: [[



        ]]
    };
    options.columns = eval(data.columns); //把返回的数组字符串转为对象，并赋于datagrid的column属性
    var dataGrid = $("#dgAnimalInfo_RoutineMaintain");
    dataGrid.datagrid(options); //根据配置选项，生成datagrid
    dataGrid.datagrid("loadData", data.data[0]); //载入本地json格式的数据


    $('#dgAnimalInfo_RoutineMaintain').datagrid('getPager').pagination({
        displayMsg: 'Displaying {from} to {to} of {total} items',
        onSelectPage: function (pPageIndex, pPageSize) {
            //改变opts.pageNumber和opts.pageSize的参数值，用于下次查询传给数据层查询指定页码的数据   
            var gridOpts = $('#dgAnimalInfo_RoutineMaintain').datagrid('options');
            gridOpts.pageNumber = pPageIndex;
            gridOpts.pageSize = pPageSize;

            var url = "Getdatagrid.ashx?M=getdgAnimalInfo_RoutineMaintain";
            var params = {
                id: $('#hfStudy').val(),
                rows: gridOpts.pageSize, page: gridOpts.pageNumber
            };
            $.post(url, params, pages, "json");
        }
    });
}
function pages(data) {
    //使用loadDate方法加载Dao层返回的数据   
    $('#dgAnimalInfo_RoutineMaintain').datagrid('loadData', { "total": data.data[0].total, "rows": data.data[0].rows });
}

function longStr(value) {
    if (value.length > 30) {
        return "<a  title='" + value + "'" + ">" + value.substr(0, 30) + "..." + "</a>";
    }
    else {
        return value;
    }
}



function deleteRoutineMaintain() {
    var rows = $('#dgRoutineMaintain').datagrid('getChecked');
    if (rows.length > 0) {
        if (confirm('Are you confirm this?')) {
            CheckIsRole_Edit(function (callback) {
                if (callback) {
                    $.ajax({
                        type: "POST",
                        dataType: "text",
                        url: "Person.ashx?M=deleteRoutineMaintain",
                        data: "delRoutineMaintain_ID=" + rows[0].RoutineMaintain_ID,
                        success: function (msg) {
                            if (msg != "") {
                                $.messager.alert("info", msg, "info", null);
                                $("#dgRoutineMaintain").datagrid('load');
                                getdgAnimalInfo_RoutineMaintain(-1);
                                AddNew_model();
                            }
                        }
                    });
                }
            });
        }
    }
    else {
        $.messager.alert("info", "Please check one request first.", "info", null);
    }
}



function EditRoutineMaintain(row) {
    $('#hfRoutineMaintain_ID').val(row.RoutineMaintain_ID);
    $("#txtSerial").val(row.Serial);
    $('#txtModel_Type').combobox('setValue', row.Model_Type)
    $('#txtCancer_Type_Abbr').combobox('setValue', row.Cancer_Type_Abbr)
    $('#txtSubtype1').combobox('setValue', row.Subtype1)
    $('#txtSubtype2').combobox('setValue', row.Subtype2)
    $("#txtModel_ID").val(row.Model_ID);
    $("#txtProject").combobox('setValue', row.Project);
    $('#txtLocation').combobox('setValue', row.Location)
    $('#hfLocation').val(row.Location);

    $("#txtSource_Animal").val(row.Source_Animal);
    $('#txtPDX_growth_status').combobox('setValue', row.PDX_growth_status)
    $('#txtOpreation').combobox('setValue', row.Opreation)
    $("#txtRn").val(row.Rn);
    $("#txtPn").val(row.Pn);
    $("#txtDate_of_Passage_inoculation").datebox('setValue', row.Date_of_Passage_inoculation);
    $('#txtAnimal_Strain').combobox('setValue', row.Animal_Strain)
    $('#txtAnimal_Sex').combobox('setValue', row.Animal_Sex)
    $("#txtCurrent_Animal_Ear_Tag").val(row.Current_Animal_Ear_Tag);
    $('#txtAnimal_Quantity').val(row.Animal_Quantity)

    $("#txtDate_of_Passage_Termination").datebox('setValue', row.Date_of_Passage_Termination);

    $("#txtComments").val(row.Comments);
    $("#txtAnimal_Room_Number").val(row.Animal_Room_Number);
    $("#txtModel_Tumor_Characteristics").val(row.Model_Tumor_Characteristics);
}





