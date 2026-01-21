$(function () {
    $('#hfRequest_id').val("-1");
    $('#hfSub-Project').val("-1");
    bigImg();
    ddlbindSearch();
    autoSample();
    autoSearch();
    bindGrid();
    bindGrid_AnimalStatus();
    AutoProject();
    AutoPiggybacked();
    bindGridMice();
    binddgModifyRequest();
    autoColumns("request2");
    autoColumns2("ModelStatus");
    $('#divRequestImport').accordion({
        border: false
    });

});

var Add = function () {
    $("#Reset1").click();
    $('#hfRequest_id').val("-1");
    $('#hfSub-Project').val("-1");
}

function bigImg() {
    if ($('.fancybox').length > 0) {
        $('.fancybox').fancybox({

    });
}
};

function ddlbindSearch() {
    $('#txtType_of_Study').combobox({
        editable: true,
        url: 'Person.ashx?M=getDDLtxtSource&&ddlname=Type%20of%20Study',
        valueField: 'id',
        textField: 'text'
    })
    
    $('#ddlTumor_Type').combobox({
        editable: false,
        url: 'Person.ashx?M=getCancertype',
        valueField: 'id',
        textField: 'text',
        onSelect: function () {
            ddlSubtype();
        },
        onLoadSuccess: function () {
            ddlSubtype();
        }
    })
    $('#ccBD').combobox({
        editable: true,
        url: 'Person.ashx?M=getccBD',
        valueField: 'id',
        textField: 'text'
    });
    $('#ccPM').combobox({
        editable: true,
        url: 'Person.ashx?M=getccPM',
        valueField: 'id',
        textField: 'text'
    });
    $('#ccLeading_SD').combobox({
        editable: true,
        url: 'Person.ashx?M=getccLeading_SD',
        valueField: 'id',
        textField: 'text'
    });
    $('#ccSD').combobox({
        editable: true,
        url: 'Person.ashx?M=getccSD',
        valueField: 'id',
        textField: 'text'
    });

    $('#editBD').combobox({
        editable: true,
        url: 'Person.ashx?M=getccBD',
        valueField: 'id',
        textField: 'text'
    });
    $('#editLeading_SD').combobox({
        editable: true,
        url: 'Person.ashx?M=getccLeading_SD',
        valueField: 'id',
        textField: 'text'
    });
    $('#editSD').combobox({
        editable: true,
        url: 'Person.ashx?M=getccSD',
        valueField: 'id',
        textField: 'text'
    });
//    $('#txtClient').combobox({
//        editable: true,
//        url: 'Person.ashx?M=getSponsor',
//        valueField: 'text',
//        textField: 'id'
//    });   //.combobox('selectedIndex', 1);

    $("#txtClient").val("");
    $("#txtClient").unautocomplete();
    $("#txtClient").autocomplete("GetGenedata.ashx?M=AutoSponsor", {
        extraParams: { key: function () { return $('#txtClient').val(); }
        },
        minChars: 0, //自动完成激活之前填入的最小字符 
        width: 150,
        max: 100,
        matchContains: false, //包含匹配，就是data参数里的数据，是否只要包含文本框里的数据就显示 
        autoFill: false, //自动填充 
        parse: function (data) {
            return $.map(eval(data), function (row) {
                return {
                    data: row,
                    value: row.SPONSOR,
                    result: row.SPONSOR
                }
            });
        },
        formatItem: function (data) { return data.SPONSOR + "(" + data.AX_CODE + ")"; }, //格式化选项
        formatResult: function (data) { return data.SPONSOR + "(" + data.AX_CODE + ")"; } //格式化选择结果
    });

    $("#editSponsor").val("");
    $("#editSponsor").unautocomplete();
    $("#editSponsor").autocomplete("GetGenedata.ashx?M=AutoSponsor", {
        extraParams: { key: function () { return $('#editSponsor').val(); }
        },
        minChars: 0, //自动完成激活之前填入的最小字符 
        width: 150,
        max: 100,
        matchContains: false, //包含匹配，就是data参数里的数据，是否只要包含文本框里的数据就显示 
        autoFill: false, //自动填充 
        parse: function (data) {
            return $.map(eval(data), function (row) {
                return {
                    data: row,
                    value: row.SPONSOR,
                    result: row.SPONSOR
                }
            });
        },
        formatItem: function (data) { return data.SPONSOR + "(" + data.AX_CODE + ")"; }, //格式化选项
        formatResult: function (data) { return data.SPONSOR + "(" + data.AX_CODE + ")"; } //格式化选择结果
    });
//    $('#editSponsor').combobox({
//        editable: true,
//        url: 'Person.ashx?M=getSponsor',
//        valueField: 'text',
//        textField: 'text'
//    }); 
}
function ddlSubtype() {
    $('#ddlSubtype1').combotree({
        editable: false,
        url: 'Person.ashx?M=getSubtype&Tumor_Type=' + $('#ddlTumor_Type').combobox('getValue'),
        id: 'id',
        text: 'text'

    });
    $('#ddlSubtype2').combotree({
        editable: false,
        url: 'Person.ashx?M=getSubtype2&Tumor_Type=' + $('#ddlTumor_Type').combobox('getValue'),
        id: 'id',
        text: 'text'

    });
}
function ConvertMid() {
    $.ajax({
        type: "POST",
        dataType: "text",
        url: "Person.ashx?M=ConvertMid",
        data: "txtImport=" + $('#txtModelID').val(),
        success: function (msg) {
            if (msg != "") {
                $('#txtModelID').val(msg);
            }
        }
    });
}
function autoColumns2(type) {
    $('#AvailableColumns2').combotree({
        editable: false,
        url: 'Person.ashx?M=hfAvailableColumns&Type=' + type,
        id: 'id',
        text: 'text'

    });
}
function autoSearch() {
    $("#searchModelID").val("");
    $("#searchModelID").unautocomplete();
    $("#searchModelID").autocomplete("GetGenedata.ashx?M=AutoModelID", {
        extraParams: { key: function () { return $('#searchModelID').val(); }
        , cancertype: function () { return ""; }
         , subtype: function () { return ""; }
           , subtype2: function () { return ''; }
        },
        minChars: 0, //自动完成激活之前填入的最小字符 
        width: 150,
        max: 100,
        matchContains: false, //包含匹配，就是data参数里的数据，是否只要包含文本框里的数据就显示 
        autoFill: false, //自动填充 
        parse: function (data) {
            return $.map(eval(data), function (row) {
                return {
                    data: row,
                    value: row.MODEL_ID,
                    result: row.MODEL_ID
                }
            });
        },
        formatItem: function (data) { return data.MODEL_ID; }, //格式化选项
        formatResult: function (data) { return data.MODEL_ID; } //格式化选择结果
    });

}
function autoSample() {
    $("#part2Model_ID").val("");
    $("#part2Model_ID").unautocomplete();
    $("#part2Model_ID").autocomplete("GetGenedata.ashx?M=AutoModelID", {
        extraParams: { key: function () { return $('#part2Model_ID').val(); }
        , cancertype: function () { return ""; }
         , subtype: function () { return ""; }
           , subtype2: function () { return ''; }
        },
        minChars: 0, //自动完成激活之前填入的最小字符 
        width: 150,
        max: 100,
        matchContains: false, //包含匹配，就是data参数里的数据，是否只要包含文本框里的数据就显示 
        autoFill: false, //自动填充 
        parse: function (data) {
            return $.map(eval(data), function (row) {
                return {
                    data: row,
                    value: row.MODEL_ID,
                    result: row.MODEL_ID
                }
            });
        },
        formatItem: function (data) { return data.MODEL_ID; }, //格式化选项
        formatResult: function (data) { return data.MODEL_ID; } //格式化选择结果
    });

}
function AutoPiggybacked() {
    $("#txtPiggybacked").val("");
    $("#txtPiggybacked").unautocomplete();
    $("#txtPiggybacked").autocomplete("GetGenedata.ashx?M=AutoProject", {
        extraParams: { key: function () { return $('#txtPiggybacked').val(); }
        },
        minChars: 0, //自动完成激活之前填入的最小字符 
        width: 150,
        max: 100,
        matchContains: false, //包含匹配，就是data参数里的数据，是否只要包含文本框里的数据就显示 
        autoFill: false, //自动填充 
        parse: function (data) {
            return $.map(eval(data), function (row) {
                return {
                    data: row,
                    value: row.Project_Number,
                    result: row.Project_Number
                }
            });
        },
        formatItem: function (data) { return data.Project_Number; }, //格式化选项
        formatResult: function (data) { return data.Project_Number; } //格式化选择结果
    });
}
function AutoSubproject(requestID, ParentProject) {
    $("#ddlSubproject").val("");
    $("#ddlSubproject").unautocomplete();
    $("#ddlSubproject").autocomplete("GetGenedata.ashx?M=ddlSubproject&&requestID=" + requestID + "&&ParentProject=" + ParentProject, {
        extraParams: { key: function () { return $('#ddlSubproject').val(); }
        },
        minChars: 0, //自动完成激活之前填入的最小字符 
        width: 150,
        max: 100,
        matchContains: false, //包含匹配，就是data参数里的数据，是否只要包含文本框里的数据就显示 
        autoFill: false, //自动填充 
        parse: function (data) {
            return $.map(eval(data), function (row) {
                return {
                    data: row,
                    value: row.PROJECT_NUMBER,
                    result: row.PROJECT_NUMBER
                }
            });
        },
        formatItem: function (data) { return data.PROJECT_NUMBER; }, //格式化选项
        formatResult: function (data) { return data.PROJECT_NUMBER; } //格式化选择结果
    });
}
function AutoProject() {
    $("#txtAnimal_Booking").val("");
    $("#txtAnimal_Booking").unautocomplete();
    $("#txtAnimal_Booking").autocomplete("GetGenedata.ashx?M=AutoProject", {
        extraParams: { key: function () { return $('#txtAnimal_Booking').val(); }
        },
        minChars: 0, //自动完成激活之前填入的最小字符 
        width: 150,
        max: 100,
        matchContains: false, //包含匹配，就是data参数里的数据，是否只要包含文本框里的数据就显示 
        autoFill: false, //自动填充 
        parse: function (data) {
            return $.map(eval(data), function (row) {
                return {
                    data: row,
                    value: row.Project_Number,
                    result: row.Project_Number
                }
            });
        },
        formatItem: function (data) { return data.Project_Number; }, //格式化选项
        formatResult: function (data) { return data.Project_Number; } //格式化选择结果
    });
    $("#txtFurther_expanding").val("");
    $("#txtFurther_expanding").unautocomplete();
    $("#txtFurther_expanding").autocomplete("GetGenedata.ashx?M=AutoProject", {
        extraParams: { key: function () { return $('#txtFurther_expanding').val(); }
        },
        minChars: 0, //自动完成激活之前填入的最小字符 
        width: 150,
        max: 100,
        matchContains: false, //包含匹配，就是data参数里的数据，是否只要包含文本框里的数据就显示 
        autoFill: false, //自动填充 
        parse: function (data) {
            return $.map(eval(data), function (row) {
                return {
                    data: row,
                    value: row.Project_Number,
                    result: row.Project_Number
                }
            });
        },
        formatItem: function (data) { return data.Project_Number; }, //格式化选项
        formatResult: function (data) { return data.Project_Number; } //格式化选择结果
    });
    $("#txtRevive").val("");
    $("#txtRevive").unautocomplete();
    $("#txtRevive").autocomplete("GetGenedata.ashx?M=AutoProject", {
        extraParams: { key: function () { return $('#txtRevive').val(); }
        },
        minChars: 0, //自动完成激活之前填入的最小字符 
        width: 150,
        max: 100,
        matchContains: false, //包含匹配，就是data参数里的数据，是否只要包含文本框里的数据就显示 
        autoFill: false, //自动填充 
        parse: function (data) {
            return $.map(eval(data), function (row) {
                return {
                    data: row,
                    value: row.Project_Number,
                    result: row.Project_Number
                }
            });
        },
        formatItem: function (data) { return data.Project_Number; }, //格式化选项
        formatResult: function (data) { return data.Project_Number; } //格式化选择结果
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
    var str_confirm = "Confirm that you are adding a new request?";
    if ($('#hfRequest_id').val() != "-1") {
        str_confirm = "Confirm that you are editing a old request?";
    }
    if (confirm(str_confirm)) {
        var flag = true;
        $('#requestImport input').each(function () {
            if ($(this).attr('data-options') || $(this).attr('validType')) {
                if ($(this)[0].id != "txtDate_of_Request" && $(this)[0].id != "txtDate_of_1st_responding") {
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
            if ($('#txtImport').val() == "") {
                alert('Please fill out the missing info as indicated.');
                return false;
            }
            else {
                $.ajax({
                    type: "POST",
                    dataType: "text",
                    url: "Person.ashx?M=SaveRequest2",
                    data: "txtImport=" + $('#txtImport').val(),
                    success: function (msg) {
                        if (msg != "") {
                            $.messager.alert("info", msg, "info", null);
                            $("#dgRequest").datagrid('load');
                            $('#txtImport').val("");
                        }
                    }
                });

            }
        }
        else {
           
            CheckIsRole_Edit(function (callback) {
                if (callback) {
                    Save();
                }
            });
        }
    }
}

var Save = function () {
    var type = $('#ddlTumor_Type').combobox('getValue');
    var Subtype1 = $('#ddlSubtype1').combotree('getValues');
    var Subtype2 = $('#ddlSubtype2').combotree('getValues');

    var ccBD = $('#ccBD').combobox('getValue');

    var ccLeading_SD = $('#ccLeading_SD').combobox('getValue');
    var ccSD = $('#ccSD').combobox('getValue');
    if (ccBD == "" && ccSD == "" && ccLeading_SD == "") {
        alert('BD or SD is required.');
        return false;
    }

    var txtType_of_Study = $('#txtType_of_Study').combobox('getValue');
    if (txtType_of_Study == "") {
        alert('Type of Study is required.');
        return false;
    }
    //if ($('#txtClient').val() == "") {
    //    alert('Sponsor is required.');
    //    return false;
    //}
    $.ajax({
        type: "POST",
        dataType: "text",
        url: "Person.ashx?M=SaveRequest",
        data: "txtClient=" + URLencode($('#txtClient').val()) + "&txtProjectNumber=" + $("#txtProjectNumber").val()
            + "&ccBD=" + ccBD + "&ccSD=" + ccSD + "&txtType_of_Study=" + $('#txtType_of_Study').combobox('getValue')
            + "&ddlTumor_Type=" + $('#ddlTumor_Type').combobox('getValue') + "&ddlSubtype1=" + $('#ddlSubtype1').combotree('getValues')
            + "&ddlSubtype2=" + $('#ddlSubtype2').combotree('getValues')
            + "&txtModel_ID=" + $('#txtModelID').val() + "&txtPotential_Study_Size=" + $('#txtPotential_Study_Size').val()
            + "&txtRequirements=" + $('#txtRequirements').val()
            + "&txtDate_of_Request=" + $('#txtDate_of_Request').datebox('getValue')
            + "&txtParent_Project=" + $("#txtParent_Project").val()
            + "&ccLeading_SD=" + ccLeading_SD
            + "&hfRequest_id=" + $('#hfRequest_id').val()

            + "&txtDate_of_1st_responding=" + $('#txtDate_of_1st_responding').datebox('getValue')
            + "&editRemark=" + $('#editRemark').val(),
        success: function (msg) {
            if (msg == "" || msg == "Send successfully.") {
                $.messager.alert("info", "Save successfully.", "info", null);
                $("#dgRequest").datagrid('load');
                $("#Reset1").click();
                $('#hfRequest_id').val("-1");
                ddlbindSearch();
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
        url: "Person.ashx?M=CheckIsRole_Edit&_modulepPge=Request"
    }).done(function (msg) {
        if (msg.all) {
            value = true;
        }
        else if (msg.pm) {
            value = true;
        }
        else if (msg.cbsd && $('#hfSub-Project').val() == -1 && $('#txtProjectNumber').val().indexOf("-SD") == -1) {
            $.messager.alert("info", "Permission Denied", "info", null);
            value = false;
        }
        else if (msg.cbsd && $('#hfSub-Project').val() != -1 && $('#hfSub-Project').val().indexOf("-SD") == -1) {
            $.messager.alert("info", "Permission Denied", "info", null);
            value = false;
        }
        if (msg.cbnc && $('#hfSub-Project').val() == -1 && $('#txtProjectNumber').val().indexOf("-NC") == -1) {
            $.messager.alert("info", "Permission Denied", "info", null);
            value = false;
        }
        else if (msg.cbnc && $('#hfSub-Project').val() != -1 && $('#hfSub-Project').val().indexOf("-NC") == -1) {
            $.messager.alert("info", "Permission Denied", "info", null);
            value = false;
        }
        else {
            value = true;
        }
        callback(value);
    });
}

function htmlExport2() {
    var rows = $('#dgSelectMice').datagrid('getChecked');
    if (rows.length > 0) {
        var ids = [];
        for (var i = 0; i < rows.length; i++) {
            //每行ID放入数组中
            ids.push(rows[i].AutoID);
        }
        //必须为string类型，不然传不过去  
        var aa = ids.toString();
        $('#hfexport').val(aa);
        $('#w-exportCol2').click();
       
    }
    else {
        $.messager.alert("info", "Please check the records to export.", "info", null);
    }
  
}
function Sendmail2() {
    var rows = $('#dgSelectMice').datagrid('getChecked');
    if (rows.length > 0) {
        var ids = [];
        for (var i = 0; i < rows.length; i++) {
            //每行ID放入数组中
            ids.push(rows[i].AutoID);
        }
        //必须为string类型，不然传不过去  
        var aa = ids.toString();
        $('#hfexport').val(aa);
        var btn = document.getElementById('btnSendmail');
        btn.click();
    }
    else {
        $.messager.alert("info", "Please check the records to export.", "info", null);
    }
   
}

function getdgRequest() {

    var params = { searchSponsor: $('#searchSponsor').val(),
        searchAXcode: $('#searchAXcode').val(),
        searchProjectNumber: $('#searchProjectNumber').val(), searchBD: $('#searchBD').val(), searchSD: $('#searchSD').val(), searchPM: $('#searchPM').val()
        , searchModelID: $('#searchModelID').val()
        , searchSigned: $('#searchSigned').val()
            , searchRequestID: $('#searchRequestID').val()
    };
    $("#dgRequest").datagrid('load', params);

}
function bindGrid() {
    $('#dgRequest').datagrid({
        url: 'Getdatagrid.ashx?M=getdgRequest2',
        iconCls: 'icon-export',
        width: 'auto',
        height: 'auto',
        title: "Request",
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
                    { field: 'REQUEST_ID', title: 'Request ID', width: 80, sortable: false }

                ]],
        columns: [[

                    { field: 'DATE_REQUEST_F', title: 'Date of Request', width: 120, sortable: false },
                      { field: 'CLIENT', title: 'Sponsor', width: 150, sortable: false },
                       { field: 'AX_CODE', title: 'AX Code', width: 150, sortable: false },
                      { field: 'PARENT_PROJECT', title: 'Major Project', width: 150, sortable: false },
                      { field: 'PROJECT_NUMBER', title: 'Sub-Project', width: 150, sortable: false },
                      { field: 'BD', title: 'BD', width: 100, sortable: false },
                        { field: 'PM', title: 'PM', width: 100, sortable: false },
                      { field: 'LEADING_SD', title: 'Leading SD', width: 100, sortable: false },
                      { field: 'SD', title: 'Executive SD', width: 100, sortable: false },
                      { field: 'TUMOR_TYPE', title: 'Cancer Type', width: 100, sortable: false
                       , formatter: function (value, rowData, rowIndex) {
                           if (value.length > 15) {
                               return "<a  title='" + value + "'" + ">" + value.substr(0, 15) + "..." + "</a>";
                           }
                           else {
                               return value;
                           }
                       }
                      },
                     { field: 'SUBTYPE1', title: 'Subtype1', width: 150, sortable: false
                       , formatter: function (value, rowData, rowIndex) {
                           if (value.length > 15) {
                               return "<a  title='" + value + "'" + ">" + value.substr(0, 15) + "..." + "</a>";
                           }
                           else {
                               return value;
                           }
                       }
                     },
                       { field: 'SUBTYPE2', title: 'Subtype2', width: 150, sortable: false
                       , formatter: function (value, rowData, rowIndex) {
                           if (value.length > 15) {
                               return "<a  title='" + value + "'" + ">" + value.substr(0, 15) + "..." + "</a>";
                           }
                           else {
                               return value;
                           }
                       }
                       },
                      { field: 'MODEL_ID', title: 'Model ID', width: 220, sortable: false, formatter: longStr },
                      { field: 'COMPLETED_MODEL_ID', title: 'Completed Model ID', width: 220, sortable: false, formatter: longStr },
                      { field: 'POTENTIAL_STUDY_SIZE', title: 'Potential Study Size', width: 100, sortable: false },
                      { field: 'SPECIAL_REQUIREMENTS', title: 'Special Requirements', width: 150, sortable: false
                       , formatter: function (value, rowData, rowIndex) {
                           if (value.length > 20) {
                               return "<a  title='" + value + "'" + ">" + value.substr(0, 20) + "..." + "</a>";
                           }
                           else {
                               return value;
                           }
                       }
                      },

                        { field: 'DATE_RESPONDING_F', title: 'Date of 1st responding', width: 100, sortable: false }
                         , { field: 'REMARK', title: 'Remark', width: 150, sortable: false
                          , formatter: function (value, rowData, rowIndex) {
                              if (value.length > 20) {
                                  return "<a  title='" + value + "'" + ">" + value.substr(0, 20) + "..." + "</a>";
                              }
                              else {
                                  return value;
                              }
                          }
                         }
                         , { field: 'SIGNED', title: 'Request Status', width: 100, sortable: false }
                             , { field: 'TYPE_OF_STUDY', title: 'Type of Study', width: 150, sortable: false }

                          , { field: 'opt', title: '', align: 'left', width: 80,
                              formatter: function (value, rowData, rowIndex) {

                                  return "<a href='javascript:void();' onclick='PM_Edit(&quot;" + rowData.SIGNED + "&quot;,&quot;" + rowData.REQUEST_ID + "&quot;,&quot;" + rowData.CLIENT + "&quot;,&quot;" + rowData.PM + "&quot;);'>Edit</a>";

                              }
                          }
                           , { field: 'opt1', title: '', align: 'left', width: 80,
                               formatter: function (value, rowData, rowIndex) {
                                   if (rowData.log_count != "") {
                                       return "<a href='javascript:void();' onclick='getdgModifyRequest(&quot;" + rowData.REQUEST_ID + "&quot;);'>log</a>";
                                   }
                                   else {
                                       return "";
                                   }
                               }
                           }
                 ]]
                   , onClickRow: function (rowIndex, rowData) {
                       $('#hfRequest_id').val(rowData.REQUEST_ID);
                       EditRequest(rowData);
                       getdgSelectMice(rowData.REQUEST_ID);
                       AutoSubproject(rowData.REQUEST_ID, rowData.PARENT_PROJECT);
                   }


    });

    //设置分页控件属性  
    var p = $('#dgRequest').datagrid('getPager');
    $(p).pagination({
        beforePageText: 'Page',
        afterPageText: 'of {pages}',
        displayMsg: 'Displaying {from} to {to} of {total} items'
    });
}



function getdgSelectMice(request_id) {
    var params = { hfrequest_id: request_id, part2ProjectN: $('#part2ProjectN').val(), part2HaveAnimals: $('#part2HaveAnimals').val(), part2Model_ID: $('#part2Model_ID').val() };
    $("#dgSelectMice").datagrid('load', params);
    $("#dgSelectMice").datagrid('uncheckAll');
}
function bindGridMice() {
    $('#dgSelectMice').datagrid({
        url: 'Getdatagrid.ashx?M=getdgSelectMice2',
        iconCls: 'icon-export',
        width: 'auto',
        height: 'auto',
        title: "Model Status-Animal info",
        idField: 'AutoID',
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
                           { field: 'ck', checkbox: true },



            ]],
        columns: [[

              { field: 'Have_Animals', title: 'Have Animals', width: 80, sortable: false },
              { field: 'REQUEST_ID', title: 'Request ID', width: 80, sortable: false },
           { field: 'Client', title: 'Sponsor', width: 150, sortable: false },
               { field: 'Project_Number', title: 'Project Number', width: 135, sortable: false },
                 { field: 'Cancer_Type', title: 'Cancer Type', width: 100, sortable: false
                       , formatter: function (value, rowData, rowIndex) {
                           if (value.length > 15) {
                               return "<a  title='" + value + "'" + ">" + value.substr(0, 15) + "..." + "</a>";
                           }
                           else {
                               return value;
                           }
                       }
                 },
                      { field: 'Subtype1', title: 'Subtype1', width: 150, sortable: false, formatter: longStr },
                       { field: 'Subtype2', title: 'Subtype2', width: 150, sortable: false, formatter: longStr },
                    { field: 'Model_ID', title: 'Model ID', width: 80, sortable: false },
                    { field: 'Potential_Study_Size', title: 'Potential Study Size', width: 100, sortable: false },
                        { field: 'Provide_Date', title: 'Provide Date', width: 100, sortable: false
                           
                        },
                      { field: 'Location', title: 'Location(BJ/TC)', width: 100, sortable: false },
                       { field: 'Tumor_Numbers', title: 'Tumor Numbers', width: 100, sortable: false },
                        { field: 'Piggybacked_by', title: 'Piggybacked by', width: 100, sortable: false },
                     { field: 'opt', title: '', align: 'left', width: 80,
                         formatter: function (value, rowData, rowIndex) {

                             return "<a href='javascript:void();' onclick='reload_dgAnimalStatus(&quot;" + rowData.Model_ID + "&quot;,&quot;" + rowData.Project_Number + "&quot;,&quot;" + rowData.REQUEST_ID + "&quot;);'>Animal Status</a>";

                         }
                     }
                      , { field: 'opt2', title: '', align: 'left', width: 100,
                          formatter: function (value, rowData, rowIndex) {
                              return "<a href='javascript:void();' onclick='Piggybacked(&quot;" + rowData.Model_ID + "&quot;,&quot;" + rowData.REQUEST_ID + "&quot;,&quot;" + rowData.Piggybacked_by + "&quot;,&quot;" + rowData.Piggybacked_by + "&quot;,&quot;" + rowData.Project_Number + "&quot;,&quot;" + rowData.Project_Number + "&quot;);'>Piggybacked by</a>";

                          }
                      }
                 ]]



    });
}


function longStr(value) {
    if (value.length > 30) {
        return "<a  title='" + value + "'" + ">" + value.substr(0, 300) + "..." + "</a>";
    }
    else {
        return value;
    }
}


function getdgModifyRequest(request_id) {
    $('#dgRequestLog').datagrid('options').url = 'Getdatagrid.ashx?M=getdgModifyRequest';
    var params = { hfRequest_id: request_id };
    $("#dgRequestLog").datagrid('load', params);
}
function binddgModifyRequest() {
    if ($('#dgRequestLog').length > 0) {
        $('#dgRequestLog').datagrid({
            title: "Request Log",
            width: '800',
            height: '450',
            nowrap: false,
            striped: true,
            remoteSort: false,
            idField: 'REQUEST_LOG_ID',
            pagination: true,
            rownumbers: true,
            singleSelect: true,
            pageSize: 20,
            pageList: [20, 40, 60],
            onLoadSuccess: function (data) {
                if (data.total >= 1) {
                    if ($('#divLogRequest').css('display') != "block") {
                        $('#w-Log').click();

                    }
                }


            },
            columns: [[
                        { field: 'REQUEST_ID', title: 'Request ID', width: 100, sortable: false },
                           { field: 'CLIENT', title: 'Sponsor', width: 150, sortable: false },
                               { field: 'PARENT_PROJECT', title: 'Parent Project', width: 150, sortable: false },
                      { field: 'PROJECT_NUMBER', title: 'Project Number', width: 150, sortable: false },
                               { field: 'MODEL_ID', title: 'Model ID', width: 200, sortable: false, formatter: longStr },
                                   { field: 'DATE_OF_1ST_RESPONDING_F', title: 'Date of 1st responding', width: 150, sortable: false },
                               { field: 'STUDY_SIZE', title: 'Study Size', width: 80, sortable: false },
                                 { field: 'BD', title: 'BD', width: 100, sortable: false },
                                 { field: 'PM', title: 'PM', width: 100, sortable: false },
                                    { field: 'LEADING_SD', title: 'Leading SD', width: 100, sortable: false },
                                   { field: 'SD', title: 'Executive SD', width: 100, sortable: false },
                                { field: 'SIGNED', title: 'Signed', width: 80, sortable: false },
                                  { field: 'CREATE_OF_DATE', title: 'Time of Edit', width: 150, sortable: false },
                                   { field: 'EDITOR', title: 'Editor', width: 150, sortable: false },
                 { field: 'REMARK', title: 'Remark', width: 150, sortable: false, formatter: longStr }
                 ]]

        });

        //设置分页控件属性  
        var p = $('#dgRequestLog').datagrid('getPager');
        $(p).pagination({
            pageSize: 20,
            pageList: [20, 40, 60],
            beforePageText: 'Page',
            afterPageText: 'of {pages}',
            displayMsg: 'Displaying {from} to {to} of {total} items'
        });
    }
}

function Piggybacked(mid, rid, by, pigg,subpro) {
    if (subpro != "") {
        $('#hfMid').val(mid);
        $('#hfRid').val(rid);
        $('#hfsubProject').val(subpro);
        $('#txtPiggybacked').val(pigg);
        $('#w-Piggybacked').click();
    }
    else {
        alert("Add the Sub-project first please.");
    }
}
function SavePiggybacked() {
    $.ajax({
        type: "POST",
        dataType: "text",
        url: "Person.ashx?M=SavePiggybacked",
        data: "hfMid=" + $('#hfMid').val() + "&hfRid=" + $('#hfRid').val()
                    + "&hfsubProject=" + $('#hfsubProject').val() + "&txtPiggybacked=" + URLencode($('#txtPiggybacked').val()),
        success: function (msg) {
            if (msg == "") {
                $.messager.alert("info", "Save successfully.", "info", null);
                $('#hfMid').val("");
                $('#hfRid').val("");
                $('#hfsubProject').val("");
                $("#dgSelectMice").datagrid('load');
                $.fancybox.close();
            }
        }
    });
}


function reload_dgAnimalStatus(key,pn,rid) {
    $('#hfPN').val(pn);
    $('#rid').val(rid);
    
    $('#book_MODEL_ID').val(key);
    $('#dgAnimalStatus').datagrid('options').url = 'Getdatagrid.ashx?M=getdgAnimalStatus';
    var params = { modelid: key, PN: pn };
    $("#dgAnimalStatus").datagrid('load', params);
}
function bindGrid_AnimalStatus() {
    if ($('#dgAnimalStatus').length > 0) {
        $('#dgAnimalStatus').datagrid({
            title: "Animal Status",
            width: '800',
            height: '400',
            nowrap: false,
            striped: true,
            remoteSort: false,
            idField: 'AnimalStatus',
            pagination: true,
            rownumbers: true,
            singleSelect: true,
            pageSize: 10,
            pageList: [10,20, 40, 60],
            onLoadSuccess: function (data) {
                if (data.total >= 1) {
                    if ($('#divAnimalStatus').css('display') != "block") {
                        $('#hfAnimal_Number').val("");
                        $('#txtAnimal_Booking').val("");
                        $('#txtFurther_expanding').val("");
                        $('#txtRevive').val("");
                        $('#lblmodel').html($('#book_MODEL_ID').val());
                        $('#w-AnimalStatus').click();
                     
                    }
                }
                else {
                    alert("no animals");
                }

            },
            columns: [[
                        { field: 'Animal_Number', title: 'Animal_Number', width: 100, sortable: false }
                                , { field: 'Location_of_live_animal', title: 'Location_of_live_animal', width: 50, sortable: false }
                              , { field: 'Current_Project_Number', title: 'Current_Project_Number', width: 150, sortable: false }
                                  , { field: 'Rn', title: 'Rn', width: 50, sortable: false },
                               { field: 'Pn', title: 'Pn', width: 50, sortable: false },
                                { field: 'DOI', title: 'DOI', width: 100, sortable: false },
                 { field: 'Body_Weight', title: 'BW', width: 50, sortable: false },
                                  { field: 'TVLB', title: 'TVLB', width: 50, sortable: false },
                                   { field: 'TVLF', title: 'TVLF', width: 50, sortable: false },
                                    { field: 'TVRF', title: 'TVRF', width: 50, sortable: false },
                                     { field: 'TVRB', title: 'TVRB', width: 50, sortable: false },
                                     { field: 'TV_AVG', title: 'TV_AVG', width: 50, sortable: false },
                                     { field: 'Tumor_Number', title: 'Tumor_Number', width: 100, sortable: false },
                                      { field: 'Clinical_Observation', title: 'Clinical_Observation', width: 120, sortable: false },
                                       { field: 'Mortality_Observation', title: 'Mortality_Observation', width: 120, sortable: false },
                                     { field: 'Estimated_DOT', title: 'Estimated_DOT', width: 100, sortable: true }
                                                             , { field: 'Animal_Booking', title: 'Animal Booking', width: 100, sortable: false },
                                                               { field: 'Further_expanding', title: 'Further Expanding', width: 100, sortable: false },
                                                                { field: 'Revive', title: 'Revive', width: 100, sortable: false }
                                                                , { field: 'Date_of_Update', title: 'Date_of_Update', width: 100, sortable: false }
                , { field: 'opt', title: '', align: 'left', width: 80,
                    formatter: function (value, rowData, rowIndex) {
                        return "<a href='javascript:void();' onclick='Animal_Booking(&quot;" + rowData.Animal_Booking + "&quot;,&quot;" + rowData.Further_expanding + "&quot;,&quot;" + rowData.Revive + "&quot;,&quot;" + rowData.Current_Project_Number + "&quot;,&quot;" + rowData.Animal_Number + "&quot;);'>Edit</a>";

                    }
                }
               
                 ]]

        });

        //设置分页控件属性  
        var p = $('#dgAnimalStatus').datagrid('getPager');
        $(p).pagination({
            pageSize: 10,
            pageList: [10,20, 40, 60],
            beforePageText: 'Page',
            afterPageText: 'of {pages}',
            displayMsg: 'Displaying {from} to {to} of {total} items'
        });
    }
}

function Animal_Booking(Animal_Booking, Further_expanding, Revive, Current_Project_Number, Animal_Number) {
    $('#txtAnimal_Booking').val(Animal_Booking);
    $('#txtFurther_expanding').val(Further_expanding);
    $('#hfAnimal_Number').val(Animal_Number);

    $('#hfNoliveAnimal').val(Current_Project_Number);
    $('#txtRevive').val(Revive);
}

function SaveBooking() {
    CheckIsRole_Edit(function (callback) {
        if (callback) {
            if ($('#hfAnimal_Number').val() != "" || $('#hfNoliveAnimal').val() == "No live animals") {
                if ($('#hfPN').val() != "") {
                    // if ($('#txtAnimal_Booking').val() != "" || $('#txtFurther_expanding').val() != "" || $('#txtRevive').val() != "") {
                    $.ajax({
                        type: "POST",
                        dataType: "text",
                        url: "Person.ashx?M=SaveBooking",
                        data: "txtAnimal_Booking=" + $('#txtAnimal_Booking').val().replace(/\+/g, "%2B") + "&txtFurther_expanding=" + $('#txtFurther_expanding').val().replace(/\+/g, "%2B")
                            + "&txtRevive=" + $('#txtRevive').val().replace(/\+/g, "%2B") + "&hfNoliveAnimal=" + $('#hfNoliveAnimal').val()
                            + "&hfAnimal_Number=" + $('#hfAnimal_Number').val() + "&book_MODEL_ID=" + $('#book_MODEL_ID').val()
                            + "&rid=" + $('#rid').val() + "&total=" + $('#dgAnimalStatus').datagrid('getData').total,
                        success: function (msg) {
                            if (msg == "") {
                                $.messager.alert("info", "Save successfully.", "info", null);
                                $('#hfAnimal_Number').val("");
                                $('#hfNoliveAnimal').val("");
                                $("#dgAnimalStatus").datagrid('load');
                            }
                            else {
                                $.messager.alert("info", "You've reached the maximum number of booking.", "info", null);
                                $('#hfAnimal_Number').val("");
                                $('#hfNoliveAnimal').val("");
                                $("#dgAnimalStatus").datagrid('load');
                            }
                        }
                    });
                    // }
                    //            else {
                    //                $.messager.alert("info", "Input can not be empty", "info", null);
                    //            }
                }
                else {
                    $.messager.alert("info", "Project Number can not be empty", "info", null);
                }
            }
            else {
                $.messager.alert("info", "Please edit one animal below.", "info", null);
            }
        }
    });
}



function EditRequest(row) {
    $('#txtClient').val(row.CLIENT);
    $("#txtProjectNumber").val(row.PROJECT_NUMBER);
    $('#hfSub-Project').val(row.PROJECT_NUMBER);
    $('#ccBD').combobox('setValue', row.BD);
    $('#ccSD').combobox('setValue', row.SD);
    $('#txtType_of_Study').combobox('setValue', row.TYPE_OF_STUDY);
    $('#ddlTumor_Type').combobox('setValue', row.TUMOR_TYPE);
//    $('#ddlSubtype1').combotree('setValues', [row.SUBTYPE1]);
    //    $('#ddlSubtype2').combotree('setValues', [row.SUBTYPE2]);
    $('#txtModelID').val(row.MODEL_ID);
    $('#txtCOMPLETED_MODEL_ID').val(row.COMPLETED_MODEL_ID);
    $('#txtPotential_Study_Size').val(row.POTENTIAL_STUDY_SIZE);
    $('#txtRequirements').val(row.SPECIAL_REQUIREMENTS);
    $('#txtDate_of_Request').datebox('setValue', row.DATE_REQUEST_F);
  
    $('#txtParent_Project').val(row.PARENT_PROJECT);
    $('#ccLeading_SD').combobox('setValue', row.LEADING_SD);
  
    $('#txtDate_of_1st_responding').datebox('setValue', row.DATE_RESPONDING_F);
    var dd = row.REMARK;
    if (dd != null) {
        var divHTML = dd.replace(/\\r\\n/g, "\r\n").replace(/\\t/g, "\t");
        $('#editRemark').val(divHTML);
    }
    else {
        $('#editRemark').val("");
    }
}


function PM_Edit(signed,Request_id, Sponsor, PM)
{
    $('#txtSigned').val(signed);
    $('#editSponsor').val(Sponsor);
    $('#ccPM').combobox('setValue', PM);
    if ($('#inline1').css('display') != "block") {
        $('#w-editRequest').click();
    }
}

function SavePM_Edit() {
    CheckIsRole_Edit(function (callback) {
        if (callback) {
            var ccPM = $('#ccPM').combobox('getValue');
            var editSponsor = $('#editSponsor').val();
            if (editSponsor != "") {
                $.ajax({
                    type: "POST",
                    dataType: "text",
                    url: "Person.ashx?M=SavePM_Edit",
                    data: "hfRequest_id=" + $('#hfRequest_id').val() + "&editSponsor=" + editSponsor
                        + "&ccPM=" + ccPM
                        + "&SIGNED=" + $('#txtSigned').val(),
                    success: function (msg) {
                        if (msg != "") {
                            $.messager.alert("info", msg, "info", null);
                            //$('#hfRequest_id').val("");
                            $("#dgRequest").datagrid('load');
                            $.fancybox.close();
                        }


                    }
                });
            }
        }
    });
}

function deleteRequest() {
    var rows = $('#dgRequest').datagrid('getChecked');
    if (rows.length > 0) {
        if (confirm('Are you confirm this?')) {
            CheckIsRole_Edit(function (callback) {
                if (callback) {
                    $.ajax({
                        type: "POST",
                        dataType: "text",
                        url: "Person.ashx?M=deleteRequest",
                        data: "delRequest_id=" + rows[0].REQUEST_ID,
                        success: function (msg) {
                            if (msg != "") {
                                $.messager.alert("info", msg, "info", null);
                                $("#dgRequest").datagrid('load');
                                getdgSelectMice(-1);
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

function MoveToProject() {
    var rows = $('#dgSelectMice').datagrid('getChecked');
    var subprojects = $('#ddlSubproject').val();
    if (subprojects != "") {
        if (rows.length > 0) {
            if (confirm('Are you confirm this?')) {
                var ids = [];
                var rid = "";
                for (var i = 0; i < rows.length; i++) {
                    //每行ID放入数组中
                    ids.push(rows[i].Model_ID);
                    rid = rows[0].REQUEST_ID;
                }
                //必须为string类型，不然传不过去  
                var aa = ids.toString();
                $.ajax({
                    type: "POST",
                    dataType: "text",
                    url: "Person.ashx?M=MoveToSubproject",
                    data: "moveIDs=" + aa + "&subprojects=" + subprojects + "&Requestid=" + rid,
                    success: function (msg) {
                        if (msg != "") {
                            $.messager.alert("info", msg, "info", null);
                            $("#dgRequest").datagrid('load');
                            $("#dgSelectMice").datagrid('load');

                        }
                    }
                });
            }

        }
        else {
            $.messager.alert("info", "Please check the records to copy.", "info", null);
        }
    }
    else {
        $.messager.alert("info", "Please select a subproject.", "info", null);
    }
}


