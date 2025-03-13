$(function () {
    $('#hfProjectConsulting_ID').val("-1");
    bigImg();
    bindGrid();

    $('#divProjectConsultingImport').accordion({
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
        $('#ProjectConsultingImport input').each(function () {
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
                url: "ProjectConsultingApi.ashx?M=SaveProjectConsulting",
                data: "hfProjectConsulting_ID=" + $('#hfProjectConsulting_ID').val()
                    + "&ModelID=" + $('#ModelID').val()
                    + "&CancerType=" + $('#CancerType').val()
                    + "&LiveStatus=" + $('#LiveStatus').val()
                    + "&Pn=" + $('#Pn').val()
                    + "&Location=" + $('#Location').val()
                    + "&Estimated_Timeframe_of_inoculation=" + $('#Estimated_Timeframe_of_inoculation').val()
                    + "&ConfidenceScore=" + $('#ConfidenceScore').val()
                    + "&AvailableIn=" + $('#AvailableIn').val()
                    + "&SpecialFeature=" + $('#SpecialFeature').val()
                    + "&Comment=" + $('#Comment').val()
                    + "&BD=" + $('#BD').val()
                    + "&Customer=" + $('#Customer').val()
                    + "&ConsultationDate=" + $('#ConsultationDate').datebox('getValue')
                    + "&ProjectNo=" + $('#ProjectNo').val()
                    + "&Cause=" + $('#Cause').val()
                    
                ,

                success: function (msg) {
                    if (msg == "" || msg == "Send successfully.") {
                        $.messager.alert("info", "Save successfully.", "info", null);
                        $("#dgProjectConsulting").datagrid('reload');
                        $("#Reset1").click();
                        $('#hfProjectConsulting_ID').val("-1");
                        AddProjectConsulting();
                    }
                    else {
                        $.messager.alert("info", msg, "info", null);
                    }
                }
            });
        }
    }
}

function getdgProjectConsulting() {

    var params = {
        S_ModelID: $('#S_ModelID').val()
        , S_Customer: $('#S_Customer').val()
    };
    $("#dgProjectConsulting").datagrid('load', params);

}

function AddProjectConsulting() {
    $('#hfProjectConsulting_ID').val("-1");
    $("#Reset1").click();

}

function bindGrid() {
    $('#dgProjectConsulting').datagrid({
        url: 'ProjectConsultingApi.ashx?M=getdgProjectConsulting',
        iconCls: 'icon-export',
        width: 'auto',
        height: 'auto',
        title: "ProjectConsulting",
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
            { field: 'ModelID', title: 'ModelID', width: 120, sortable: false },
            { field: 'CancerType', title: 'CancerType', width: 120, sortable: false },
            { field: 'LiveStatus', title: 'LiveStatus', width: 120, sortable: false },
            { field: 'Pn', title: 'Pn', width: 50, sortable: false },
            { field: 'Location', title: 'Location', width: 120, sortable: false },
            { field: 'Estimated_Timeframe_of_inoculation', title: 'Estimated_Timeframe_of_inoculation', width: 220, sortable: false },
            { field: 'ConfidenceScore', title: 'ConfidenceScore', width: 120, sortable: false },
            { field: 'AvailableIn', title: 'AvailableIn', width: 120, sortable: false },
            { field: 'SpecialFeature', title: 'SpecialFeature', width: 220, sortable: false },
            { field: 'Comment', title: 'Comment', width: 120, sortable: false },
            { field: 'BD', title: 'BD', width: 120, sortable: false },
            { field: 'Customer', title: 'Customer', width: 120, sortable: false },
            { field: 'ConsultationDate', title: 'ConsultationDate', width: 120, sortable: false },
            { field: 'ConsultationDays', title: 'ConsultationDays', width: 120, sortable: false },
            { field: 'IsEnabled', title: 'IsEnabled', width: 120, sortable: false },
            { field: 'Cause', title: 'Cause', width: 120, sortable: false },
            { field: 'ProjectNo', title: 'ProjectNo', width: 120, sortable: false },
            { field: 'EmailLink', title: 'EmailLink', width: 120, sortable: false },
        ]]
        , onClickRow: function (rowIndex, rowData) {
            $('#hfProjectConsulting_ID').val(rowData.ProjectConsulting_ID);
            EditProjectConsulting(rowData);
        }


    });

    //设置分页控件属性  
    var p = $('#dgProjectConsulting').datagrid('getPager');
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



function deleteProjectConsulting() {
    var rows = $('#dgProjectConsulting').datagrid('getChecked');
    if (rows.length > 0) {
        if (confirm('Are you confirm this?')) {
            $.ajax({
                type: "POST",
                dataType: "text",
                url: "ProjectConsultingApi.ashx?M=deleteProjectConsulting",
                data: "delProjectConsulting_ID=" + rows[0].ProjectConsulting_ID,
                success: function (msg) {
                    if (msg != "") {
                        $.messager.alert("info", msg, "info", null);
                        $("#dgProjectConsulting").datagrid('load');
                        AddProjectConsulting();
                    }
                }
            });
        }
    }
    else {
        $.messager.alert("info", "Please check one request first.", "info", null);
    }
}



function EditProjectConsulting(row) {
    $('#hfProjectConsulting_ID').val(row.ProjectConsulting_ID);
    $('#ModelID').val(row.ModelID);
    $("#CancerType").val(row.CancerType);
    $("#LiveStatus").val(row.LiveStatus);
    $("#Pn").val(row.Pn);
    $("#Location").val(row.Location);
    $("#Estimated_Timeframe_of_inoculation").val(row.Estimated_Timeframe_of_inoculation);
    $("#ConfidenceScore").val(row.ConfidenceScore);
    $("#AvailableIn").val(row.AvailableIn);
    $("#SpecialFeature").val(row.SpecialFeature);
    $("#Comment").val(row.Comment);
    $("#BD").val(row.BD);
    $("#Customer").val(row.Customer);
    $("#ConsultationDate").datebox('setValue', row.ConsultationDate);
    $("#ProjectNo").val(row.ProjectNo);
    $("#Cause").val(row.Cause);
    
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
        'uploadScript': 'ProjectConsultingApi.ashx?M=importProjectConsulting',
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
            getdgProjectConsulting();
            alert(data);
        }
    });
}



