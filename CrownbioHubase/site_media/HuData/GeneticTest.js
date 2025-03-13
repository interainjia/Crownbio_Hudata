$(function () {
    $('#hfGeneticTest_ID').val("-1");
    bigImg();
    bindGrid();

    $('#divGeneticTestImport').accordion({
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
        $('#GeneticTestImport input').each(function () {
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
                url: "Person.ashx?M=SaveGeneticTest",
                data: "hfGeneticTest_ID=" + $('#hfGeneticTest_ID').val()
                    + "&txtSq_Number=" + $('#txtSq_Number').val()
                    + "&txtModel_ID=" + $('#txtModel_ID').val()
                    + "&txtSource=" + $('#txtSource').val()
                    + "&txtRNAseq=" + $('#txtRNAseq').val()
                    + "&txtWES=" + $('#txtWES').val()
                    + "&txtWGS=" + $('#txtWGS').val()
                    + "&txtComment=" + $('#txtComment').val()
                    + "&txtGenetic_type_updata=" + $('#txtGenetic_type_updata').val()
                    + "&txtPathology=" + $('#txtPathology').val()
                    + "&txtPatholog_updata=" + $('#txtPatholog_updata').val()
                    + "&txtComment_all=" + $('#txtComment_all').val()
                ,

                success: function (msg) {
                    if (msg == "" || msg == "Send successfully.") {
                        $.messager.alert("info", "Save successfully.", "info", null);
                        $("#dgGeneticTest").datagrid('reload');
                        $("#Reset1").click();
                        $('#hfGeneticTest_ID').val("-1");
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




function getdgGeneticTest() {

    var params = {
        S_Sq: $('#S_Sq').val()
        , S_ModelID: $('#S_ModelID').val()
        , s_Source: $('#s_Source').val()
        , s_RNAseq: $('#s_RNAseq').val()
        , s_WES: $('#s_WES').val()
        , s_WGS: $('#s_WGS').val()
    };
    $("#dgGeneticTest").datagrid('load', params);

}

function AddNew_model() {
    $('#hfGeneticTest_ID').val("-1");
    $("#Reset1").click();

}

function bindGrid() {
    $('#dgGeneticTest').datagrid({
        url: 'Getdatagrid.ashx?M=getdgGeneticTest',
        iconCls: 'icon-export',
        width: 'auto',
        height: 'auto',
        title: "GeneticTest",
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
            { field: 'Sq_Number', title: 'Sq_Number', width: 120, sortable: false },
            { field: 'Model_ID', title: 'Model_ID', width: 120, sortable: false },
            { field: 'Source', title: 'Source', width: 120, sortable: false },
            { field: 'RNAseq', title: 'RNAseq', width: 120, sortable: false },
            { field: 'WES', title: 'WES', width: 120, sortable: false },
            { field: 'WGS', title: 'WGS', width: 120, sortable: false },
            { field: 'Comment', title: 'Comment', width: 120, sortable: false },
            { field: 'Time_of_Update', title: 'Time_of_Update', width: 120, sortable: false },
            { field: 'Name_of_Update', title: 'Name_of_Update', width: 120, sortable: false },
            { field: 'Genetic_type_updata', title: 'Genetic_type_updata', width: 120, sortable: false },
            { field: 'Pathology', title: 'Pathology', width: 120, sortable: false },
            { field: 'Patholog_updata', title: 'Patholog_updata', width: 120, sortable: false },
            { field: 'Comment_all', title: 'Comment_all', width: 120, sortable: false }
        ]]
        , onClickRow: function (rowIndex, rowData) {
            $('#hfGeneticTest_ID').val(rowData.GeneticTest_ID);
            EditGeneticTest(rowData);
        }


    });

    //设置分页控件属性  
    var p = $('#dgGeneticTest').datagrid('getPager');
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



function deleteGeneticTest() {
    var rows = $('#dgGeneticTest').datagrid('getChecked');
    if (rows.length > 0) {
        if (confirm('Are you confirm this?')) {
            $.ajax({
                type: "POST",
                dataType: "text",
                url: "Person.ashx?M=deleteGeneticTest",
                data: "delGeneticTest_ID=" + rows[0].GeneticTest_ID,
                success: function (msg) {
                    if (msg != "") {
                        $.messager.alert("info", msg, "info", null);
                        $("#dgGeneticTest").datagrid('load');
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



function EditGeneticTest(row) {
    $('#hfGeneticTest_ID').val(row.GeneticTest_ID);
    $("#txtSq_Number").val(row.Sq_Number);
    $("#txtModel_ID").val(row.Model_ID);
    $("#txtSource").val(row.Source);
    $("#txtRNAseq").val(row.RNAseq);
    $("#txtWES").val(row.WES);
    $("#txtWGS").val(row.WGS);
    $("#txtComment").val(row.Comment);
    $("#txtTime_of_Update").datebox('setValue', row.Time_of_Update);
    $("#txtName_of_Update").val(row.Name_of_Update);
    $("#txtGenetic_type_updata").val(row.Genetic_type_updata);
    $("#txtPathology").val(row.Pathology);
    $("#txtPatholog_updata").val(row.Patholog_updata);
    $("#txtComment_all").val(row.Comment_all);
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
        'uploadScript': 'importDB.ashx?M=importGeneticTest',
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
            getdgGeneticTest();
            alert(data);
        }
    });
}



