$(function () {
    $('#hfValidationStatus_Huprime_ID').val("-1");
    bigImg();
    bindGrid();

    $('#divValidationStatus_HuprimeImport').accordion({
        border: false
    });
    fancybox_bind();
    uploadify_bind();
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



function htmlExport_old3() {
    var btn = document.getElementById('btnExport3');
    btn.click();
}



/***
* 对 特殊字符进行重新编码(转义)
* **/
function URLencode(sStr) {
    return escape(sStr).replace(/\+/g, '%2B').replace(/\"/g, '%22').replace(/\'/g, '%27').replace(/\//g, '%2F').replace(/\#/g, '%23').replace(/\&/g, '%26');
}

var Check = function () {
    if (confirm('Are you confirm this?')) {
        var flag = true;
        $('#ValidationStatus_HuprimeImport input').each(function () {
            if ($(this).hasClass('easyui-validatebox') || $(this).attr('validType')) {
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
                url: "Person.ashx?M=SaveValidationStatus_Huprime",
                data: "hfValidationStatus_Huprime_ID=" + $('#hfValidationStatus_Huprime_ID').val()

                    + "&txtSq=" + $('#txtSq').val()
                    + "&txtCancerType=" + $('#txtCancerType').val()
                    + "&txtCancerTypeAbbr=" + $('#txtCancerTypeAbbr').val()
                    + "&txtModelID=" + $('#txtModelID').val()
                    + "&txtModel_Type=" + $('#txtModel_Type').val()
                    + "&txtSource=" + $('#txtSource').val()
                    + "&txtProject=" + URLencode($('#txtProject').val())
                    + "&txtArrival_Date=" + $('#txtArrival_Date').datebox('getValue')
                    + "&txtEstablished_Date=" + $('#txtEstablished_Date').datebox('getValue')
                    + "&txtFinalDateofValidation=" + $('#txtFinalDateofValidation').datebox('getValue')
                    + "&txtCryo_PTissue=" + $('#txtCryo_PTissue').datebox('getValue')
                    + "&txtFirst_Revival=" + $('#txtFirst_Revival').datebox('getValue')
                    + "&txtGC=" + $('#txtGC').datebox('getValue')
                    + "&txtDateofUpdate=" + $('#txtDateofUpdate').datebox('getValue')

                    + "&txtEstablished_Location=" + $('#txtEstablished_Location').val()
                    + "&txtValidationStatus=" + $('#txtValidationStatus').val()
                    + "&txtCryo_PTissue_number=" + $('#txtCryo_PTissue_number').val()
                    + "&txtFrozen_Storage=" + $('#txtFrozen_Storage').val()
                    + "&txtAnimalRoomNumber=" + $('#txtAnimalRoomNumber').val()
                    + "&txtComment=" + URLencode($('#txtComment').val())
                ,

                success: function (msg) {
                    if (msg == "" || msg == "Send successfully.") {
                        $.messager.alert("info", "Save successfully.", "info", null);
                        $("#dgValidationStatus_Huprime").datagrid('reload');
                        $("#Reset1").click();
                        $('#hfValidationStatus_Huprime_ID').val("-1");
                        AddNew_model();
                    }
                    else {
                        $.messager.alert("info", msg, "info", null);
                    }
                }
            });
        }



    }
}




function getdgValidationStatus_Huprime() {

    var params = {
        S_Sq: $('#S_Sq').val()
        , S_ModelID: $('#S_ModelID').val()
    };
    $("#dgValidationStatus_Huprime").datagrid('load', params);

}

function AddNew_model() {
    $('#hfValidationStatus_Huprime_ID').val("-1");
    $("#Reset1").click();
    //add by Jack 2025.09.04
    $("#txtArrival_Date").datebox('setValue', "");
    $("#txtEstablished_Date").datebox('setValue', "");
    $("#txtFinalDateofValidation").datebox('setValue', "");
    $("#txtCryo_PTissu").datebox('setValue', "");
    $("#txtFirst_Revival").datebox('setValue', "");
    $("#txtGC").datebox('setValue', "");
}

function bindGrid() {
    $('#dgValidationStatus_Huprime').datagrid({
        url: 'Getdatagrid.ashx?M=getdgValidationStatus_Huprime',
        iconCls: 'icon-export',
        width: 'auto',
        height: 'auto',
        title: "Model Validation Status Huprime&MuPrime",
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
            { field: 'ck', checkbox: true }

        ]],
        columns: [[
            { field: 'Sq', title: 'Sq#', width: 120, sortable: false },
            { field: 'CancerType', title: 'CancerType', width: 120, sortable: false },
            { field: 'CancerTypeAbbr', title: 'CancerTypeAbbr', width: 120, sortable: false },
            { field: 'ModelID', title: 'ModelID', width: 120, sortable: false },
            { field: 'Model_Type', title: 'Model_Type', width: 120, sortable: false },
            { field: 'Source', title: 'Source', width: 120, sortable: false },
            { field: 'Project', title: 'Project', width: 120, sortable: false },
            { field: 'Arrival_Date', title: 'Arrival_Date', width: 120, sortable: false },
            { field: 'Established_Date', title: 'Established_Date', width: 120, sortable: false },
            { field: 'Established_Location', title: 'Established_Location', width: 120, sortable: false },
            { field: 'ValidationStatus', title: 'ValidationStatus', width: 120, sortable: false },
            { field: 'FinalDateofValidation', title: 'FinalDateofValidation', width: 120, sortable: false },
            { field: 'Cryo_PTissue', title: 'Cryo_PTissue', width: 120, sortable: false },
            { field: 'Cryo_PTissue_number', title: 'Cryo_PTissue_number', width: 120, sortable: false },
            { field: 'Frozen_Storage', title: 'Frozen_Storage', width: 120, sortable: false },
            { field: 'First_Revival', title: 'First_Revival', width: 120, sortable: false },
            { field: 'GC', title: 'GC', width: 120, sortable: false },
            { field: 'AnimalRoomNumber', title: 'AnimalRoomNumber', width: 120, sortable: false },
            { field: 'DateofUpdate', title: 'DateofUpdate', width: 150, sortable: false },
            { field: 'Comment', title: 'Comment', width: 120, sortable: false }
        ]]
        , onClickRow: function (rowIndex, rowData) {
            $('#hfValidationStatus_Huprime_ID').val(rowData.ValidationStatus_Huprime_ID);
            EditValidationStatus_Huprime(rowData);
        }


    });

    //设置分页控件属性  
    var p = $('#dgValidationStatus_Huprime').datagrid('getPager');
    $(p).pagination({
        beforePageText: 'Page',
        afterPageText: 'of {pages}',
        displayMsg: 'Displaying {from} to {to} of {total} items'
    });
}



function longStr(value) {
    if (value.length > 30) {
        return "<a  title='" + value + "'" + ">" + value.substr(0, 30) + "..." + "</a>";
    }
    else {
        return value;
    }
}



function deleteValidationStatus_Huprime() {
    var rows = $('#dgValidationStatus_Huprime').datagrid('getChecked');
    if (rows.length > 0) {
        if (confirm('Are you confirm this?')) {
            $.ajax({
                type: "POST",
                dataType: "text",
                url: "Person.ashx?M=deleteValidationStatus_Huprime",
                data: "delValidationStatus_Huprime_ID=" + rows[0].ValidationStatus_Huprime_ID,
                success: function (msg) {
                    if (msg != "") {
                        $.messager.alert("info", msg, "info", null);
                        $("#dgValidationStatus_Huprime").datagrid('load');
                        AddNew_model();
                    }
                }
            });
        }
    }
    else {
        $.messager.alert("info", "Please check one request first.", "info", null);
    }
}



function EditValidationStatus_Huprime(row) {
    $('#hfValidationStatus_Huprime_ID').val(row.ValidationStatus_Huprime_ID);
    $("#txtSq").val(row.Sq);
    $("#txtCancerType").val(row.CancerType);
    $("#txtCancerTypeAbbr").val(row.CancerTypeAbbr);
    $("#txtModelID").val(row.ModelID);
    $("#txtModel_Type").val(row.Model_Type);
    $("#txtSource").val(row.Source);
    $("#txtProject").val(row.Project);
    //add by Jack 2025.09.04
    $("#txtArrival_Date").datebox('setValue', row.Arrival_Date);
    $("#txtEstablished_Date").datebox('setValue', row.Established_Date);
    $("#txtFinalDateofValidation").datebox('setValue', row.FinalDateofValidation);
    $("#txtCryo_PTissue").datebox('setValue', row.Cryo_PTissue);
    $("#txtFirst_Revival").datebox('setValue', row.First_Revival);
    $("#txtGC").datebox('setValue', row.GC);
    $("#txtEstablished_Location").val(row.Established_Location);
    $("#txtValidationStatus").val(row.ValidationStatus);
    $("#txtCryo_PTissue_number").val(row.Cryo_PTissue_number);
    $("#txtFrozen_Storage").val(row.Frozen_Storage);
    $("#txtAnimalRoomNumber").val(row.AnimalRoomNumber);
    $("#txtDateofUpdate").datebox('setValue', row.DateofUpdate);
    $("#txtComment").val(row.Comment);

}


function fancybox_bind() {
    if ($('.fancybox').length > 0) {
        $('.fancybox').fancybox({});
        $("#w-importIC50").fancybox({
            'modal': true
        });
    }
}
function closeWindow() {
    $.fancybox.close();
}
function Import() {
    $('#w-importIC50').click();
}

function uploadify_bind() {
    $("#uploadify1").uploadifive({
        'auto': false,
        'uploadScript': 'importDB.ashx?M=importValidationStatus_Huprime',
        'buttonText': 'Select',
        'queueID': 'fileQueue1',
        'fileType': '*.xls; *.xlsx',
        'fileTypeDesc': 'Files (.XLS, .XLSX)',
        'multi': false,
        'fileSizeLimit': '10MB',
        'queueSizeLimit': 1,
        'removeCompleted': true,
        'onUploadComplete': function (file, data, response) {
            closeWindow();
            getdgValidationStatus_Huprime();
            alert(data);
        }
    });
}



