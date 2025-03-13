$(function () {
    $('#hfValidationStatus_Hukime_ID').val("-1");
    bigImg();
    bindGrid();

    $('#divValidationStatus_HukimeImport').accordion({
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
        $('#ValidationStatus_HukimeImport input').each(function () {
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
                url: "Person.ashx?M=SaveValidationStatus_Hukime",
                data: "hfValidationStatus_Hukime_ID=" + $('#hfValidationStatus_Hukime_ID').val()
                    + "&txtSq=" + $('#txtSq').val()
                    + "&txtCancerType=" + $('#txtCancerType').val()
                    + "&txtCancerTypeAbbr=" + $('#txtCancerTypeAbbr').val()
                    + "&txtModelID=" + $('#txtModelID').val()
                    + "&txtModel_Type=" + $('#txtModel_Type').val()
                    + "&txtSource=" + $('#txtSource').val()
                    + "&txtSubtype=" + $('#txtSubtype').val()
                    + "&txtEstablished_Date=" + $('#txtEstablished_Date').datebox('getValue')
                    + "&txtEstablished_Location=" + $('#txtEstablished_Location').val()
                    + "&txtValidationStatus=" + $('#txtValidationStatus').val()
                    + "&txtFinalDateofValidation=" + $('#txtFinalDateofValidation').datebox('getValue')
                    + "&txtDateofUpdate=" + $('#txtDateofUpdate').datebox('getValue')

                    + "&txtTU=" + $('#txtTU').val()
                    + "&txtFACS=" + $('#txtFACS').val()
                    + "&txtbank=" + $('#txtbank').val()
                    + "&txtRevival=" + $('#txtRevival').datebox('getValue')
                    + "&txtpassage=" + $('#txtpassage').val()
                    + "&txtsnp=" + $('#txtsnp').val()
                    + "&txtComment=" + URLencode($('#txtComment').val())
                ,

                success: function (msg) {
                    if (msg == "" || msg == "Send successfully.") {
                        $.messager.alert("info", "Save successfully.", "info", null);
                        $("#dgValidationStatus_Hukime").datagrid('reload');
                        $("#Reset1").click();
                        $('#hfValidationStatus_Hukime_ID').val("-1");
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




function getdgValidationStatus_Hukime() {

    var params = {
        S_Sq: $('#S_Sq').val()
        , S_ModelID: $('#S_ModelID').val()
    };
    $("#dgValidationStatus_Hukime").datagrid('load', params);

}

function AddNew_model() {
    $('#hfValidationStatus_Hukime_ID').val("-1");
    $("#Reset1").click();
    $("#txtEstablished_Date").datebox('setValue', "");
    $("#txtFinalDateofValidation").datebox('setValue', "");
    $("#txtRevival").datebox('setValue', "");
}

function bindGrid() {
    $('#dgValidationStatus_Hukime').datagrid({
        url: 'Getdatagrid.ashx?M=getdgValidationStatus_Hukime',
        iconCls: 'icon-export',
        width: 'auto',
        height: 'auto',
        title: "Model Validation Status Hukime",
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
            /****** Script for SelectTopNRows command from SSMS  ******/
            { field: 'Sq', title: 'Sq#', width: 120, sortable: false },
            { field: 'CancerType', title: 'CancerType', width: 120, sortable: false },
            { field: 'CancerTypeAbbr', title: 'CancerTypeAbbr', width: 120, sortable: false },
            { field: 'ModelID', title: 'ModelID', width: 120, sortable: false },
            { field: 'Model_Type', title: 'Model_Type', width: 120, sortable: false },
            { field: 'Source', title: 'Source', width: 120, sortable: false },
            { field: 'Subtype', title: 'Subtype', width: 120, sortable: false },
            { field: 'Established_Date', title: 'Established_Date', width: 120, sortable: false },
            { field: 'Established_Location', title: 'Established_Location', width: 120, sortable: false },
            { field: 'ValidationStatus', title: 'ValidationStatus', width: 120, sortable: false },
            { field: 'FinalDateofValidation', title: 'FinalDateofValidation', width: 120, sortable: false },
            { field: 'TU', title: 'TU', width: 120, sortable: false },
            { field: 'FACS', title: 'FACS', width: 120, sortable: false },
            { field: 'bank', title: 'bank', width: 120, sortable: false },
            { field: 'Revival', title: 'Revival', width: 120, sortable: false },
            { field: 'passage', title: 'passage', width: 120, sortable: false },
            { field: 'snp', title: 'snp', width: 120, sortable: false },
            { field: 'DateofUpdate', title: 'DateofUpdate', width: 120, sortable: false },
            { field: 'Comment', title: 'Comment', width: 120, sortable: false }

        ]]
        , onClickRow: function (rowIndex, rowData) {
            $('#hfValidationStatus_Hukime_ID').val(rowData.ValidationStatus_Hukime_ID);
            EditValidationStatus_Hukime(rowData);
        }


    });

    //设置分页控件属性  
    var p = $('#dgValidationStatus_Hukime').datagrid('getPager');
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



function deleteValidationStatus_Hukime() {
    var rows = $('#dgValidationStatus_Hukime').datagrid('getChecked');
    if (rows.length > 0) {
        if (confirm('Are you confirm this?')) {
            $.ajax({
                type: "POST",
                dataType: "text",
                url: "Person.ashx?M=deleteValidationStatus_Hukime",
                data: "delValidationStatus_Hukime_ID=" + rows[0].ValidationStatus_Hukime_ID,
                success: function (msg) {
                    if (msg != "") {
                        $.messager.alert("info", msg, "info", null);
                        $("#dgValidationStatus_Hukime").datagrid('load');
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



function EditValidationStatus_Hukime(row) {
    $('#hfValidationStatus_Hukime_ID').val(row.ValidationStatus_Hukime_ID);
    $("#txtSq").val(row.Sq);
    $("#txtCancerType").val(row.CancerType);
    $("#txtCancerTypeAbbr").val(row.CancerTypeAbbr);
    $("#txtModelID").val(row.ModelID);
    $("#txtModel_Type").val(row.Model_Type);
    $("#txtSource").val(row.Source);
    $("#txtSubtype").val(row.Subtype);
    $("#txtEstablished_Date").datebox('setValue', row.Established_Date);
    $("#txtFinalDateofValidation").datebox('setValue', row.FinalDateofValidation);
    $("#txtRevival").datebox('setValue', row.Revival);
    $("#txtEstablished_Location").val(row.Established_Location);
    $("#txtValidationStatus").val(row.ValidationStatus);
    $("#txtTU").val(row.TU);
    $("#txtFACS").val(row.FACS);
    $("#txtbank").val(row.bank);
    $("#txtpassage").val(row.passage);
    $("#txtsnp").val(row.snp);
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
        'uploadScript': 'importDB.ashx?M=importValidationStatus_Hukime',
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
            getdgValidationStatus_Hukime();
            alert(data);
        }
    });
}



