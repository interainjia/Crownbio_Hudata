$(function () {
    AddMuPrime();
    autoFiled("selectFieldName0");
    ddl_bind();
    bindGrid();
    $('#divMuPrimeImport').accordion({
        border: false
    });
    ddlSOC();
    //bind_dg_logs();
});


function AddMuPrime() {
    $("#Reset1").click();
    $('#hfMuPrime_ID').val("-1");
    //    $('#txtLife_Span').combobox('selectedIndex', 0);
    //    $('#txtCategory').combobox('selectedIndex', 0);
}

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

function ddlSOC() {
    $('#ddlSOC').combotree({
        editable: false,
        url: 'Person.ashx?M=getddlSOC',
        id: 'id',
        text: 'text'
        , onLoadSuccess: function () {
            if ($('#hfSOC').val() != "") {
                var arr = $('#hfSOC').val().split(",");
                $('#ddlSOC').combotree('setValues', arr);
            }
        }
    });
}

function ddl_bind() {
    $("#selectFieldName0").combobox({
        editable: false,
        url: 'Person.ashx?M=getDDLtxtSource&&ddlname=MuPrime-SelectField',
        valueField: 'id',
        textField: 'text'
    });

    $('#txtCancer_Type').combobox({
        editable: false,
        url: 'Person.ashx?M=getCancertype',
        valueField: 'id',
        textField: 'text'
        , onLoadSuccess: function () {
            ddlSubtype();
        }
    });
    $('#txtModel_From').combobox({
        editable: false,
        url: 'Person.ashx?M=getDDLtxtSource&&ddlname=Model_From',
        valueField: 'id',
        textField: 'text'

    });
    $('#txtSource').combobox({
        editable: false,
        url: 'Person.ashx?M=getDDLtxtSource&&ddlname=Source',
        valueField: 'id',
        textField: 'text'

    });
    $('#txtModel_Category').combobox({
        editable: false,
        url: 'Person.ashx?M=getDDLtxtSource&&ddlname=Model%20Category',
        valueField: 'id',
        textField: 'text'

    });
    $('#txtCachexia_Label').combobox({
        editable: false,
        url: 'Person.ashx?M=getDDLtxtSource&&ddlname=Cachexia%20Label',
        valueField: 'id',
        textField: 'text'

    });
    $('#txtSurvival_Curve').combobox({
        editable: false,
        url: 'Person.ashx?M=getDDLtxtSource&&ddlname=Survival%20Curve',
        valueField: 'id',
        textField: 'text'

    });
    $('#cbxSource').combobox({
        editable: true,
        url: 'Person.ashx?M=getDDLtxtSource&&ddlname=Source',
        valueField: 'id',
        textField: 'text'

    });
    $('#cbxModel_Category').combotree({
        editable: false,
        url: 'Person.ashx?M=cbxModel_Category-combotree',
        id: 'id',
        text: 'text'
    });
}

function ddlSubtype() {
    $('#txtSubtype1').combobox({
        editable: false,
        url: 'Person.ashx?M=getSubtype-combobox&Tumor_Type=' + $('#txtCancer_Type').combobox('getValue'),
        valueField: 'id',
        textField: 'text'
    });
    $('#txtSubtype2').combobox({
        editable: false,
        url: 'Person.ashx?M=getSubtype2-combobox&Tumor_Type=' + $('#txtCancer_Type').combobox('getValue'),
        valueField: 'id',
        textField: 'text'
    });

}


/***
* 对 特殊字符进行重新编码(转义) ajax传参数的时候
* **/
function URLencode(sStr) {
    return escape(sStr).replace(/\+/g, '%2B').replace(/\"/g, '%22').replace(/\'/g, '%27').replace(/\//g, '%2F').replace(/\#/g, '%23').replace(/\&/g, '%26');
}

var Check = function () {
    if (confirm('Are you confirm this?')) {
        var flag = true;
        $('#MuPrimeImport input').each(function () {
            if ($(this).attr('data-options') || $(this).attr('validType')) {
                if (!$(this).validatebox('isValid')) {
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
            $.ajax({
                type: "POST",
                dataType: "text",
                url: "Person.ashx?M=SaveMuPrime",
                data: "hfMuPrime_ID=" + $('#hfMuPrime_ID').val()
                           + "&txtSq_Number=" + $('#txtSq_Number').val() + "&txtCancer_Type_Abbr=" + $("#txtCancer_Type_Abbr").val()
                    + "&txtModel_ID=" + $('#txtModel_ID').val() + "&txtModel_From=" + $('#txtModel_From').combobox('getValue')
                            + "&txtCancer_Type=" + $('#txtCancer_Type').combobox('getValue') + "&txtSubtype1=" + $('#txtSubtype1').combobox('getValues')
                            + "&txtSubtype2=" + $('#txtSubtype2').combobox('getValues')
                            + "&txtMouse_Strain=" + $('#txtMouse_Strain').val()
                            + "&txtModel_Category=" + $('#txtModel_Category').combobox('getValue') + "&txtSource_ID=" + $('#txtSource_ID').val()
                            + "&txtSource_Note=" + $('#txtSource_Note').val()
                            + "&txtPDX_QC=" + $('#txtPDX_QC').val()
                            + "&txtGenotype_Consistence=" + $('#txtGenotype_Consistence').val()
                            + "&txtIN_HUBA=" + $("#txtIN_HUBA").val()
                            + "&txtTotal_Revival_Success_Rate=" + $("#txtTotal_Revival_Success_Rate").val()
                            + "&txtTime_of_Revival=" + $("#txtTime_of_Revival").val()
                            + "&txtRevival_Recommended_Strain=" + $("#txtRevival_Recommended_Strain").val()
                            + "&txtTime_of_Model_for_Transplant=" + $("#txtTime_of_Model_for_Transplant").val()
                            + "&txtMaintain_Recommended_Strain=" + $("#txtMaintain_Recommended_Strain").val()
                            + "&txtSpareforCV40=" + $("#txtSpare_for_CV40").val()
                            + "&txtSpareforCV30=" + $("#txtSpare_for_CV30").val()
                            + "&txtOptimal_Overage=" + $("#txtOptimal_Overage").val()
                            + "&txtDosing_Window=" + $("#txtDosing_Window").val()
                            + "&txtCryo_P=" + $("#txtCryo_P").val()
                            + "&txtSnap_Frozen=" + $("#txtSnap_Frozen").val()
                            + "&txtFFPE=" + $("#txtFFPE").val()
                            + "&txtTimes_Used_In_Study=" + $("#txtTimes_Used_In_Study").val()
                             + "&txtCachexia_Label=" + $('#txtCachexia_Label').combobox('getValue')
                              + "&txtCachexia=" + $("#txtCachexia").val()
                              + "&txtSlight_BW_loss=" + $("#txtSlight_BW_loss").val()
                              + "&txtNormal=" + $("#txtNormal").val()

                               + "&txtUlceration_Label=" + $("#txtUlceration_Label").val()
                              + "&txtSurvival_Curve=" + $('#txtSurvival_Curve').combobox('getValue')
                               + "&ddlSOC=" + $('#ddlSOC').combotree('getText')
                    + "&txtcomments=" + $("#txtcomments").val()
                    + "&txtSource=" + $("#txtSource").combobox('getValue')
                            ,

                success: function (msg) {
                    if (msg == "" || msg == "Send successfully.") {
                        ShowMsg("Save successfully");
                        $("#dgMuPrime").datagrid('reload');
                        AddMuPrime();

                    }
                    else {
                        ShowMsg(msg);
                    }
                }
            });
        }



    }
}







function SelectDatagrid() {
    setFirstPage();
    var params = {
        S_MuPrimename: $('#S_MuPrimename').val(),
        rows: 10, page: 1
    };
    $("#dgMuPrime").datagrid('reload', params);
}

function setFirstPage() {
    $("#dgMuPrime").datagrid("options").pageNumber = 1;
    $("#dgMuPrime").datagrid('getPager').pagination({ pageNumber: 1 });
}

function bindGrid() {
    $('#dgMuPrime').datagrid({
        iconCls: 'icon-export',
        url: 'Getdatagrid.ashx?M=getdgMuPrime',
        width: 'auto',
        height: 'auto',
        title: "MuPrime",
        idField: 'PDXMODEL_INFO_ID',
        fitColumns: false,
        singleSelect: true,
        nowrap: false,
        striped: true,
        remoteSort: true,
        pagination: true,
        rownumbers: true,
        selectOnCheck: false,
        checkOnSelect: false,
        pageSize: 10,
        pageList: [10, 20, 30, 40],
        frozenColumns: [[
                            { field: 'ck', checkbox: true }
//                            { field: 'opt1', title: '', align: 'left', width: 80,
//                                formatter: function (value, rowData, rowIndex) {
//                                    return "<a href='#' onclick='get_logs(&quot;" + rowData.MuPrime_ID + "&quot;);'>log</a>";
//                                }
//                            }
                ]],
        columns: [[
                 ]]
                   , onClickRow: function (rowIndex, rowData) {
                       $('#hfMuPrime_ID').val(rowData.PDXMODEL_INFO_ID);
                       EditMuPrime(rowData);
                   }
    });
    //设置分页控件属性  
    var p = $('#dgMuPrime').datagrid('getPager');
    $(p).pagination({
        beforePageText: 'Page',
        afterPageText: 'of {pages}',
        displayMsg: 'Displaying {from} to {to} of {total} items'
    });
    getUserColumns();
}

function htmlExport3() {
    $('#btnExport3').click();
}

function getUserColumns() {
    $.ajax({
        type: "POST",
        dataType: "json",
        url: "Getdatagrid.ashx?M=ajaxGetColumns",
        data: "tablename=" + "MuPrime",
        success: function (data) {
            $('#dgMuPrime').datagrid({
                columns: eval(data.columns)
            });
        }
    });

}



function get_logs(_id) {
    $('#dgMuPrime_Log').datagrid('options').url = 'Getdatagrid.ashx?M=getdgMuPrime_Log';
    var params = { id: _id };
    $("#dgMuPrime_Log").datagrid('load', params);
}
function bind_dg_logs() {
    if ($('#dgMuPrime_Log').length > 0) {
        $('#dgMuPrime_Log').datagrid({
            title: "Log",
            width: '800',
            height: '450',
            nowrap: false,
            striped: true,
            remoteSort: false,
            idField: 'MuPrime_Log_ID',
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
                      { field: 'Date_of_P0_inoculation', title: 'Date of P0 inoculation', width: 150, sortable: false },
                           { field: 'Study', title: 'Study #', width: 150, sortable: false },
                                 { field: 'Animal_Strain', title: 'Animal Strain', width: 150, sortable: false },
                                     { field: 'Animal_Sex', title: 'Animal Sex', width: 100, sortable: false },
     { field: 'Current_Animal_Ear_Tag', title: 'Current Animal Ear Tag', width: 150, sortable: false },
          { field: 'Animal_Quantity', title: 'Animal Quantity', width: 150, sortable: false },
                      { field: 'PDX_growth_status', title: 'PDX growth status', width: 150, sortable: false },
                        { field: 'Date_of_P0_Termination', title: 'Date of P0 Termination', width: 200, sortable: false },
                      { field: 'Duration', title: 'Duration(Days)', width: 120, sortable: false },
                      { field: 'Source_Hospital', title: 'Source Hospital', width: 150, sortable: false },
                      { field: 'Pathology_info_available', title: 'Pathology info available', width: 220, sortable: false },
                     { field: 'Date_of_Pathology_info_Received', title: 'Date of Pathology info Received', width: 250, sortable: false },

                       { field: 'Patient_No', title: 'Patient No', width: 150, sortable: false },
                        { field: 'Patient_Name', title: 'Patient Name', width: 150, sortable: false, formatter: longStr },

                      { field: 'Patient_Age', title: 'Patient Age', width: 100, sortable: false, formatter: longStr },
                      { field: 'Patient_Sex', title: 'Patient Sex', width: 100, sortable: false },

                       { field: 'Pathology_info_Qced', title: 'Pathology info Qced', width: 150, sortable: false },
                      { field: 'Comments', title: 'Comments', width: 150, sortable: false },
                      { field: 'Editor', title: 'Editor', width: 150, sortable: false },
                      { field: 'Date_of_Create', title: 'Date_of_Create', width: 150, sortable: false }
                 ]]

        });

        //设置分页控件属性  
        var p = $('#dgMuPrime_Log').datagrid('getPager');
        $(p).pagination({
            pageSize: 20,
            pageList: [20, 40, 60],
            beforePageText: 'Page',
            afterPageText: 'of {pages}',
            displayMsg: 'Displaying {from} to {to} of {total} items'
        });
    }
}




function longStr(value) {
    if (value.length > 30) {
        return "<a  title='" + value + "'" + ">" + value.substr(0, 30) + "..." + "</a>";
    }
    else {
        return value;
    }
}



function deleteMuPrime() {
    var rows = $('#dgMuPrime').datagrid('getChecked');
    if (rows.length > 0) {
        if (confirm('Are you confirm this?')) {
            var ids = [];
            for (var i = 0; i < rows.length; i++) {
                ids.push(rows[i].PDXMODEL_INFO_ID);
            }
            var aa = ids.toString();
            $.ajax({
                type: "POST",
                dataType: "text",
                url: "Person.ashx?M=deleteMuPrime",
                data: "delMuPrime_ID=" + aa,
                success: function (msg) {
                    if (msg != "") {
                        ShowMsg(msg);
                        AddMuPrime();
                        $("#dgMuPrime").datagrid('reload');
                        $('#dgMuPrime').datagrid('clearChecked');
                    }
                }
            });
        }
    }
    else {
        $.messager.alert("info", "Please check a Cell Line first.", "info", null);
    }
}



function EditMuPrime(row) {
    $('#hfMuPrime_ID').val(row.PDXMODEL_INFO_ID);
    $('#txtSq_Number').val(row.Sq_Number);
    $('#txtCancer_Type_Abbr').val(row.Cancer_Type_Abbr);
    $('#txtModel_From').combobox('setValue', row.Model_From)
    $('#txtModel_ID').val(row.Model_ID);
    $('#txtMouse_Strain').val(row.Mouse_Strain)
    $('#txtCancer_Type').combobox('setValue', row.Cancer_Type)
    $('#txtSubtype1').combobox('setValue', row.Subtype1)
    $('#txtSubtype2').combobox('setValue', row.Subtype2)
    $('#txtModel_Category').combobox('setValue', row.Model_Category)
    $('#txtSource_ID').val(row.Source_ID);
    $('#txtSource_Note').val(row.Source_Note);
    $('#txtPDX_QC').val(row.PDX_QC);
    $('#txtGenotype_Consistence').val(row.Genotype_Consistence)
    $('#txtIN_HUBA').val(row.In_Huba);
    $('#txtTotal_Revival_Success_Rate').val(row.Total_Revival_Success_Rate);
    $('#txtTime_of_Revival').val(row.Time_of_Revival);
    $('#txtRevival_Recommended_Strain').val(row.Revival_Recommended_Strain);
    $('#txtTime_of_Model_for_Transplant').val(row.Time_of_Model_for_Transplant);
    $('#txtMaintain_Recommended_Strain').val(row.Maintain_Recommended_Strain);
    $('#txtSpare_for_CV40').val(row.CV40_Take_rate);
    $('#txtSpare_for_CV30').val(row.CV30_Take_rate);
    $('#txtOptimal_Overage').val(row.Optimal_Overage);
    $('#txtDosing_Window').val(row.Dosing_Window);
    $('#txtCryo_P').val(row.Cryo_P);
    $('#txtSnap_Frozen').val(row.Snap_Frozen);
    $('#txtFFPE').val(row.FFPE1);
    $('#txtTimes_Used_In_Study').val(row.Times_Used_In_Study);
    $('#txtCachexia_Label').combobox('setValue', row.Cachexia_Label);
    $('#txtCachexia').val(row.Cachexia);
    $('#txtSlight_BW_loss').val(row.Slight_BW_loss);
    $('#txtNormal').val(row.Normal);

    $('#txtUlceration_Label').val(row.Ulceration_Label);
    $('#txtSurvival_Curve').combobox('setValue', row.Survival_Curve);
    $('#hfSOC').val(row.SOC);
    $('#txtcomments').val(row.Comments);
    $('#txtSource').combobox('setValue', row.Source);
    ddlSOC();
}


function autoFiled(Filed_id) {
    $("#" + Filed_id + "").combobox({
        editable: false,
        url: 'Person.ashx?M=getDDLtxtSource&&ddlname=MuPrime-SelectField',
        valueField: 'id',
        textField: 'text'
    });
}

var a = 0;
function AddField() {
    a += 1;

    $("#table2>tbody").append('<tr id="tr1"><td></td><td>Field Name:<select id="selectFieldName' + a + '" name="selectFieldName[]" class="easyui-combobox"  style="width: 150px;"></td> <td>Condition:<select  id="selectCondition' + a + '"><option value="like">like</option><option value="not like">not like</option><option value="=">=</option><option value="<>"><></option></select></td><td>Field Value:<input id="selectFieidValue' + a + '" type="text"/></td><td><img onclick="deltr(this)"  src="../images/remove.png"/></td></tr>')

    autoFiled("selectFieldName" + a);
}

//删除行的函数，必须要放domready函数外面
function deltr(delbtn) {
    if ($(delbtn).parent().parent("tr").index() == 0) {
        $(delbtn).parent().parent("tr").remove();
        if ($("#table2>tbody td").length != 0) {
            $("#table2>tbody td")[0].innerHTML = "";
        }
    }
    else {
        $(delbtn).parent().parent("tr").remove();
    }
};

function ADSearch() {
    var flag = true;
    var error = "";
    $("input[name='selectFieldName[]']").each(function () {
        if ($(this).val() == "") {
            error = "Field can not be empty.";
            flag = false;
        }
    });
    $("input[name='selectFieidValue[]']").each(function () {
        if ($(this).val() == "") {
            error = "Field can not be empty.";
            flag = false;
        }
    });
    if (!flag) {
        alert(error);
        return false;
    }
    var str = "";
    $("#table2>tbody tr").each(function () {
        if ($(this).attr("id") == "tr1") {
            str += getTrRow($(this), "tr1,") + ":";
        }
    });
    var params = {
        str: str,
        rows: 10, page: 1
    };
    setFirstPage();
    $("#dgMuPrime").datagrid('reload', params);
}
function getTrRow(a, tr) {
    var strRow = tr;
    a.children('td').each(function () {
        $(this).find('input').each(function () {
            if ($(this).attr('type') == "text") {
                strRow += $(this).val() + ",";
            }

        });
        $(this).find('select').each(function () {
            if ($(this).val() != null) {
                strRow += $(this).val() + ",";
            }
        });
    });
    return strRow;
}


function SetColumns() {
    if ($('#divSetColumns').css('display') != "block") {
        $('#iframepage').attr("src", "SetUserColumns.aspx?Table=MuPrime");
        $('#open-SetColumns').click();
    }
} 
  
     