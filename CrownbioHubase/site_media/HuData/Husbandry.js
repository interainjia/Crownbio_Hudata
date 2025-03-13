
$(document).ready(function () {
    bindGrid();

    $("#uploadify3").uploadify({
        'swf': '../site_media/uploadify/uploadify.swf',
        'uploader': 'importDB.ashx?M=UploadHusbandry',
        'fileTypeDesc': 'Image Files (.xlsx)',
        'fileTypeExts': '*.xlsx',
        'queueSizeLimit': 100,      //允许同时上传文件数量
        'fileSizeLimit': '2MB',   //限制单个文件大小，限制IIS大小请到Web.Config修改
        'queueID': 'testID',
        'buttonText': 'Select files',
        'auto': false,
        'multi': false,
        'height': 20,
        'removeTimeout': 1,
        'onQueueComplete': function (queueData) {         //所有文件上传完成时触发此事件
            //alert(queueData.uploadsSuccessful + ' files were successfully uploaded.');
            alert('Files were successfully uploaded.');
            getdgHusbandry();
        },
        'onUploadError': function (file, errorCode, errorMsg, errorString) {    //错误提示 
            if (errorString != "Cancelled") {
                alert('The file ' + file.name + ' could not be uploaded: ' + errorString);

            }
        }
    });
    $("#uploadify4").uploadify({
        'swf': '../site_media/uploadify/uploadify.swf',
        'uploader': 'importDB.ashx?M=UploadHusbandry_Zgroup',
        'fileTypeDesc': 'Image Files (.xlsx)',
        'fileTypeExts': '*.xlsx',
        'queueSizeLimit': 100,      //允许同时上传文件数量
        'fileSizeLimit': '2MB',   //限制单个文件大小，限制IIS大小请到Web.Config修改
        'queueID': 'testID2',
        'buttonText': 'Select files',
        'auto': false,
        'multi': false,
        'height': 20,
        'removeTimeout': 1,
        'onQueueComplete': function (queueData) {         //所有文件上传完成时触发此事件
            //alert(queueData.uploadsSuccessful + ' files were successfully uploaded.');
            alert('Files were successfully uploaded.');
            getdgHusbandry();
        },
        'onUploadError': function (file, errorCode, errorMsg, errorString) {    //错误提示 
            if (errorString != "Cancelled") {
                alert('The file ' + file.name + ' could not be uploaded: ' + errorString);

            }
        }
    });
});
function delDB() {
    $.ajax({
        type: "POST",
        url: "importDB.ashx?M=DeleteHus",
        success: function (msg) {
            if (msg != "") {
                alert(msg);
            }
        }
    });
}


function getdgHusbandry() {
    var params = { txtDate: ""
//    $('#txtDate').datebox('getValue')
    };
    $("#dgHusbandry").datagrid('load', params);
}

function bindGrid() {
    $('#dgHusbandry').datagrid({
        url: 'Getdatagrid.ashx?M=getdgHusbandry',
        iconCls: 'icon-export',
        width: 'auto',
        height: 'auto',
        title: "",
        fitColumns: true,
        singleSelect: true,
        nowrap: false,
        striped: true,
        remoteSort: true,
        pagination: true,
        rownumbers: true,
        pageSize: 10,
        pageList: [10, 20, 30, 40],
        frozenColumns: [[

                 { field: 'Cancer_Type', title: 'Cancer_Type', width: 150, sortable: false },
                    {field: 'Model_ID', title: 'Model_ID', width: 150, sortable: false }

                ]],
        columns: [[
              { field: 'Rn', title: 'Rn', width: 80, sortable: false },
              { field: 'Pn', title: 'Pn', width: 80, sortable: false },
              { field: 'DOI', title: 'DOI', width: 80, sortable: false},
              { field: 'Cage', title: 'Cage', width: 80, sortable: false },
              { field: 'Number_in_Cage', title: 'Number_in_Cage', width: 80, sortable: false },
              { field: 'Date_of_Update', title: 'Date_of_Update', width: 80, sortable: false },
              { field: 'Hunbandry_Days', title: 'Hunbandry_Days', width: 80, sortable: false },
                { field: 'Cost_accumulation', title: 'Cost_accumulation', width: 80, sortable: false },
                    { field: 'Project', title: 'Project', width: 80, sortable: false }
                 ]]



    });

    //设置分页控件属性  
    var p = $('#dgHusbandry').datagrid('getPager');
    $(p).pagination({
        beforePageText: 'Page',
        afterPageText: 'of {pages}',
        displayMsg: 'Displaying {from} to {to} of {total} items'
    });
}