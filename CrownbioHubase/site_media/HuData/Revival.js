$(function () {
    $('#hfRevival_ID').val("-1");
    bigImg();
    bindGrid();

    $('#divRevivalImport').accordion({
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


var CheckIsRole_Edit = function (callback) {
    var value;
    $.ajax({
        type: "POST",
        dataType: "json",
        async: false,
        url: "Person.ashx?M=CheckIsRole_Edit&_modulepPge=Revival"
    }).done(function (msg) {
        if (msg.cbsd && $('#txtLocation').val() != "SD") {
            $.messager.alert("info", "Permission Denied", "info", null);
            value = false;
        }
        else if (msg.cbnc && $('#txtLocation').val() != "NC") {
            $.messager.alert("info", "Permission Denied", "info", null);
            value = false;
        }
        else {
            value = true;
        }
        callback(value);
    });
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
        $('#RevivalImport input').each(function () {
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
            CheckIsRole_Edit(function (callback) {
                if (callback) {
                    $.ajax({
                        type: "POST",
                        dataType: "text",
                        url: "Person.ashx?M=SaveRevival",
                        data: "hfRevival_ID=" + $('#hfRevival_ID').val()
                            + "&txtsq1=" + $('#txtsq1').val()
                            + "&txtSq=" + $('#txtSq').val()
                            + "&txtCancerType=" + $('#txtCancerType').val()
                            + "&txtModelID=" + $('#txtModelID').val()
                            + "&txtDate_of_Tissue_collection=" + $('#txtDate_of_Tissue_collection').datebox('getValue')
                            + "&txtBatch_of_cryo_p_tissue=" + URLencode($('#txtBatch_of_cryo_p_tissue').val())
                            + "&txtDate_of_Revival=" + $('#txtDate_of_Revival').datebox('getValue')
                            + "&txtDuration_in_LiN2=" + $('#txtDuration_in_LiN2').val()
                            + "&txtLocation=" + $('#txtLocation').val()
                            + "&txtPre_Rn=" + $('#txtPre_Rn').val()
                            + "&txtRn=" + $('#txtRn').val()
                            + "&txtPn=" + $('#txtPn').val()
                            + "&txtRn_match=" + $('#txtRn_match').val()
                            + "&txtAnimal_Strain=" + $('#txtAnimal_Strain').val()
                            + "&txtAnimal_Quantity=" + $('#txtAnimal_Quantity').val()
                            + "&txtDate_of_Revival_suceeded=" + $('#txtDate_of_Revival_suceeded').datebox('getValue')
                            + "&txtOutcome=" + $('#txtOutcome').val()
                            + "&txtDuration_of_Revival=" + $('#txtDuration_of_Revival').val()
                            + "&txtStudy=" + URLencode($('#txtStudy').val())
                            + "&txtProject_No=" + $('#txtProject_No').val()
                            + "&txtComment=" + $('#txtComment').val()
                            + "&txtPre_Recovery_Pathogen=" + $('#txtPre_Recovery_Pathogen').val()
                            + "&txtRecovery_Pathogen=" + $('#txtRecovery_Pathogen').val()
                            + "&txtImplantation_Pathogen=" + $('#txtImplantation_Pathogen').val()
                            + "&txtRecovery_SNP=" + $('#txtRecovery_SNP').val()
                            + "&txtImplantation_SNP=" + $('#txtImplantation_SNP').val()
                        ,

                        success: function (msg) {
                            if (msg == "" || msg == "Send successfully.") {
                                $.messager.alert("info", "Save successfully.", "info", null);
                                $("#dgRevival").datagrid('reload');
                                $("#Reset1").click();
                                $('#hfRevival_ID').val("-1");
                                AddNew_model();
                            }
                            else {
                                $.messager.alert("info", msg, "info", null);
                            }
                        }
                    });
                }
            });
        }
    }
}


function getdgRevival() {

    var params = {
        S_Sq: $('#S_Sq').val()
        , S_ModelID: $('#S_ModelID').val()
        , s_Location: $('#s_Location').val()
        , s_Rn: $('#s_Rn').val()
        , s_Pn: $('#s_Pn').val()
        , s_Animal_Strain: $('#s_Animal_Strain').val()
        , s_Outcome: $('#s_Outcome').val()
    };
    $("#dgRevival").datagrid('load', params);

}

function AddNew_model() {
    $('#hfRevival_ID').val("-1");
    $("#Reset1").click();
    $("#txtDate_of_Tissue_collection").datebox('setValue', "");
    $("#txtDate_of_Revival").datebox('setValue', "");
    $("#txtDate_of_Revival_suceeded").datebox('setValue', "");
}

function bindGrid() {
    $('#dgRevival').datagrid({
        url: 'Getdatagrid.ashx?M=getdgRevival',
        iconCls: 'icon-export',
        width: 'auto',
        height: 'auto',
        title: "Revival",
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

            { field: 'sq1', title: 'sq1#', width: 120, sortable: false },
            { field: 'Sq', title: 'Sq#', width: 120, sortable: false },
            { field: 'CancerType', title: 'CancerType', width: 120, sortable: false },
            { field: 'ModelID', title: 'ModelID', width: 120, sortable: false },
            { field: 'Date_of_Tissue_collection', title: 'Date_of_Tissue_collection', width: 120, sortable: false },
            { field: 'Batch_of_cryo_p_tissue', title: 'Batch_of_cryo_p_tissue', width: 120, sortable: false },
            { field: 'Date_of_Revival', title: 'Date_of_Revival', width: 120, sortable: false },
            { field: 'Duration_in_LiN2', title: 'Duration_in_LiN2', width: 120, sortable: false },
            { field: 'Location', title: 'Location', width: 120, sortable: false },
            { field: 'Pre_Rn', title: 'Pre_Rn', width: 120, sortable: false },
            { field: 'Rn', title: 'Rn', width: 120, sortable: false },
            { field: 'Pn', title: 'Pn', width: 120, sortable: false },
            { field: 'Rn_match', title: 'Rn_match', width: 120, sortable: false },
            { field: 'Animal_Strain', title: 'Animal_Strain', width: 120, sortable: false },
            { field: 'Animal_Quantity', title: 'Animal_Quantity', width: 120, sortable: false },
            { field: 'Date_of_Revival_suceeded', title: 'Date_of_Revival_suceeded', width: 120, sortable: false },
            { field: 'Outcome', title: 'Outcome', width: 120, sortable: false },
            { field: 'Duration_of_Revival', title: 'Duration_of_Revival', width: 120, sortable: false },
            { field: 'Study', title: 'Study', width: 120, sortable: false },
            { field: 'Project_No', title: 'Project_No', width: 120, sortable: false },
            { field: 'Comment', title: 'Comment', width: 120, sortable: false },
            { field: 'Pre_Recovery_Pathogen', title: 'Pre_Recovery_Pathogen', width: 120, sortable: false },
            { field: 'Recovery_Pathogen', title: 'Recovery_Pathogen', width: 120, sortable: false },
            { field: 'Implantation_Pathogen', title: 'Implantation_Pathogen', width: 120, sortable: false },
            { field: 'Recovery_SNP', title: 'Recovery_SNP', width: 120, sortable: false },
            { field: 'Implantation_SNP', title: 'Implantation_SNP', width: 120, sortable: false },
            { field: 'Time_of_Update', title: 'Time_of_Update', width: 120, sortable: false },
            { field: 'Name_of_Update', title: 'Name_of_Update', width: 120, sortable: false }
        ]]
        , onClickRow: function (rowIndex, rowData) {
            $('#hfRevival_ID').val(rowData.Revival_ID);
            EditRevival(rowData);
        }


    });

    //设置分页控件属性  
    var p = $('#dgRevival').datagrid('getPager');
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



function deleteRevival() {
    var rows = $('#dgRevival').datagrid('getChecked');
    if (rows.length > 0) {
        if (confirm('Are you confirm this?')) {
            $.ajax({
                type: "POST",
                dataType: "text",
                url: "Person.ashx?M=deleteRevival",
                data: "delRevival_ID=" + rows[0].Revival_ID,
                success: function (msg) {
                    if (msg != "") {
                        $.messager.alert("info", msg, "info", null);
                        $("#dgRevival").datagrid('load');
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



function EditRevival(row) {
    $('#hfRevival_ID').val(row.Revival_ID);
    $("#txtsq1").val(row.sq1);
    $("#txtSq").val(row.Sq);
    $("#txtCancerType").val(row.CancerType);
    $("#txtModelID").val(row.ModelID);
    $("#txtDate_of_Tissue_collection").datebox('setValue', row.Date_of_Tissue_collection);
    $("#txtBatch_of_cryo_p_tissue").val(row.Batch_of_cryo_p_tissue);
    $("#txtDate_of_Revival").datebox('setValue', row.Date_of_Revival);
    $("#txtDuration_in_LiN2").val(row.Duration_in_LiN2);
    $("#txtLocation").val(row.Location);
    $("#txtPre_Rn").val(row.Pre_Rn);
    $("#txtRn").val(row.Rn);
    $("#txtPn").val(row.Pn);
    $("#txtRn_match").val(row.Rn_match);
    $("#txtAnimal_Strain").val(row.Animal_Strain);
    $("#txtAnimal_Quantity").val(row.Animal_Quantity);
    $("#txtDate_of_Revival_suceeded").datebox('setValue', row.Date_of_Revival_suceeded);
    $("#txtOutcome").val(row.Outcome);
    $("#txtDuration_of_Revival").val(row.Duration_of_Revival);
    $("#txtStudy").val(row.Study);
    $("#txtProject_No").val(row.Project_No);
    $("#txtComment").val(row.Comment);
    $("#txtPre_Recovery_Pathogen").val(row.Pre_Recovery_Pathogen);
    $("#txtRecovery_Pathogen").val(row.Recovery_Pathogen);
    $("#txtImplantation_Pathogen").val(row.Implantation_Pathogen);
    $("#txtRecovery_SNP").val(row.Recovery_SNP);
    $("#txtImplantation_SNP").val(row.Implantation_SNP);
    $("#txtTime_of_Update").datebox('setValue', row.Time_of_Update);
    $("#txtName_of_Update").val(row.Name_of_Update);
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
        'uploadScript': 'importDB.ashx?M=importRevival',
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
            getdgRevival();
            alert(data);
        }
    });
}



