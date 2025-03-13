$(function () {
    $('#hfStudy').val("-1");
    $('#hfEndModels_ID').val("-1");
    bigImg();
    bindGrid();

    $('#divEndModelsImport').accordion({
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







/***
* 对 特殊字符进行重新编码(转义)
* **/
function URLencode(sStr) {
    return escape(sStr).replace(/\+/g, '%2B').replace(/\"/g, '%22').replace(/\'/g, '%27').replace(/\//g, '%2F').replace(/\#/g, '%23').replace(/\&/g, '%26');
}

var Check = function () {
    if (confirm('Are you confirm this?')) {
        var flag = true;
        $('#EndModelsImport input').each(function () {
            if ($(this).attr('data-options') || $(this).attr('validType')) {
                if ($(this)[0].id != "txtHUSBANDRY_START" && $(this)[0].id != "txtDATE_OF_DEAD") {
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

            $.ajax({
                type: "POST",
                dataType: "text",
                url: "Person.ashx?M=SaveEndModels",
                data: "hfEndModels_ID=" + $('#hfEndModels_ID').val()
                    + "&txtLEADER=" + $('#txtLEADER').val()
                    + "&txtGROUP_NAME=" + $('#txtGROUP_NAME').val()
                    + "&txtRN=" + $('#txtRN').val()
                    + "&txtPN=" + $('#txtPN').val()
                    + "&txtLOCATION=" + $('#txtLOCATION').val()
                    + "&txtIVC=" + $('#txtIVC').val()
                    + "&txtREVIVAL=" + $('#txtREVIVAL').val()
                    + "&txtHUSBANDRY_START=" + $('#txtHUSBANDRY_START').datebox('getValue')
                    + "&txtDATE_OF_DEAD=" + $('#txtDATE_OF_DEAD').combobox('getValue')
                    + "&txtANIMAL=" + $('#txtANIMAL').val()
                    + "&txtCOMMENTS=" + $('#txtCOMMENTS').val()
                ,

                success: function (msg) {
                    if (msg == "" || msg == "Send successfully.") {
                        $.messager.alert("info", "Save successfully.", "info", null);
                        $("#dgEndModels").datagrid('reload');
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



    }
}




function getdgEndModels() {

    var params = {
        S_Animal: $('#S_Animal').val()
        , S_GroupName: $('#S_GroupName').val()
        , S_Leader: $('#S_Leader').val()
        , S_Rn: $('#S_Rn').val()
        , S_Pn: $('#S_Pn').val()
        , S_Location: $('#S_Location').val()
        , S_IVC: $('#S_IVC').val()
    };
    $("#dgEndModels").datagrid('load', params);

}

function AddNew_model() {
    $('#hfEndModels_ID').val("-1");
    $("#Reset1").click();
    $("#txtHUSBANDRY_START").datebox('setValue', "");
    $("#txtDATE_OF_DEAD").datebox('setValue', "");
}

function bindGrid() {
    $('#dgEndModels').datagrid({
        url: 'Getdatagrid.ashx?M=getdgEndModels',
        iconCls: 'icon-export',
        width: 'auto',
        height: 'auto',
        title: "End of Models",
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
            { field: 'Date_of_Update', title: 'Date_of_Update', width: 150, sortable: false },
            { field: 'Leader', title: 'Leader', width: 120, sortable: false },
            { field: 'Group_name', title: 'Model ID', width: 120, sortable: false },
            { field: 'Rn', title: 'Rn', width: 120, sortable: false },
            { field: 'Pn', title: 'Pn', width: 120, sortable: false },
            { field: 'Husbandry_Start', title: 'Date of Passage inoculation', width: 150, sortable: false },
            { field: 'Date_of_Dead', title: 'Date of Passage Termaination', width: 150, sortable: false },
            { field: 'Location', title: 'Location', width: 120, sortable: false },
            { field: 'IVC', title: 'IVC', width: 120, sortable: false },
            { field: 'Revival', title: 'Revival', width: 120, sortable: false },
            { field: 'Animal', title: 'Animal', width: 150, sortable: false },
            { field: 'Comments', title: 'Comments', width: 120, sortable: false }
        ]]
        , onClickRow: function (rowIndex, rowData) {
            $('#hfEndModels_ID').val(rowData.EndModels_ID);
            EditEndModels(rowData);
        }


    });

    //设置分页控件属性  
    var p = $('#dgEndModels').datagrid('getPager');
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



function deleteEndModels() {
    var rows = $('#dgEndModels').datagrid('getChecked');
    if (rows.length > 0) {
        if (confirm('Are you confirm this?')) {
            $.ajax({
                type: "POST",
                dataType: "text",
                url: "Person.ashx?M=deleteEndModels",
                data: "delEndModels_ID=" + rows[0].EndModels_ID,
                success: function (msg) {
                    if (msg != "") {
                        $.messager.alert("info", msg, "info", null);
                        $("#dgEndModels").datagrid('load');
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



function EditEndModels(row) {
    $('#hfEndModels_ID').val(row.EndModels_ID);
    $("#txtDATE_OF_UPDATE").val(row.Date_of_Update);
    $("#txtLEADER").val(row.Leader);
    $("#txtGROUP_NAME").val(row.Group_name);
    $("#txtRN").val(row.Rn);
    $("#txtPN").val(row.Pn);
    $("#txtLOCATION").val(row.Location);
    $("#txtIVC").val(row.IVC);
    $("#txtREVIVAL").val(row.Revival);
    $("#txtANIMAL").val(row.Animal);
    $("#txtCOMMENTS").val(row.Comments);
    $("#txtHUSBANDRY_START").datebox('setValue', row.Husbandry_Start);
    $("#txtDATE_OF_DEAD").datebox('setValue', row.Date_of_Dead);
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
        'uploadScript': 'importDB.ashx?M=importEndModels',
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
            getdgEndModels();
            alert(data);
        }
    });
}



