$(function () {
    bigImg();
    ddlbind();
    autoSample();

    ddlbindSearch();
    autoSearch();
    //    depBind();
    //    reload();
    datebind();
    bindGrid();
    bindGridMice();
    bindGrid_ModelID_Multi();
    bindGrid_Modifylog();
});
function reload() {
    Sys.WebForms.PageRequestManager.getInstance().add_endRequest(depBind);
    Sys.WebForms.PageRequestManager.getInstance().add_endRequest(autoSample);
    Sys.WebForms.PageRequestManager.getInstance().add_endRequest(datebind);
    Sys.WebForms.PageRequestManager.getInstance().add_endRequest(ddlbind);
}
function bigImg() {
    if ($('.fancybox').length > 0) {
        $('.fancybox').fancybox({
            afterClose: function () {
                if ($('#genegrid').length > 0) {
                    $('#genegrid').datagrid('clearSelections');
                    $('#genegrid').datagrid('clearChecked');
                }
            }
        });
    }
};
function AddMulti() {
    if ($('#txtModel_ID').val().length > 1 && $('#txtModel_ID').val() != "") {
        reloadBindGrid($('#txtModel_ID').val());
    }
}
function reload_dgModifylog(key) {
    $('#dgModifylog').datagrid('options').url = 'Getdatagrid.ashx?M=getdgModifyRequest';
    var params = { hfRequest_id: key };
    $("#dgModifylog").datagrid('load', params);
}
function bindGrid_Modifylog() {
    if ($('#dgModifylog').length > 0) {
        $('#dgModifylog').datagrid({
            width: '800',
            height: '350',
            nowrap: false,
            striped: true,
            remoteSort: false,
            idField: 'Modifylog',
            pagination: true,
            rownumbers: true,
            pageSize: 20,
            pageList: [20, 40, 60],
            onLoadSuccess: function (data) {
                if (data.total >= 1) {
                    if ($('#divModifylog').css('display') != "block") {
                        $('#w-modifylog').click();
                    }
                }

            },
            columns: [[
                       { field: 'REQUEST_ID', title: 'Request ID', width: 60, sortable: false },
                      { field: 'HAVE_RESPONDED', title: 'Responded', width: 60, sortable: false },
                         { field: 'HAVE_CONFIRMED', title: 'Confirmed', width: 60, sortable: false },
                          { field: 'CONFIRM_DATE_F', title: 'Data of Confirm', width: 90, sortable: false },
                    { field: 'DATE_REQUEST_F', title: 'Date of Request', width: 90, sortable: false },
        { field: 'PROJECT_NUMBER', title: 'Project Number', width: 135, sortable: false },
                      { field: 'CLIENT', title: 'Client', width: 80, sortable: false },
                      { field: 'BD', title: 'BD', width: 100, sortable: false },
                      { field: 'SD', title: 'SD', width: 100, sortable: false },
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
                      { field: 'SUBTYPE', title: 'Subtype', width: 150, sortable: false
                       , formatter: function (value, rowData, rowIndex) {
                           if (value.length > 15) {
                               return "<a  title='" + value + "'" + ">" + value.substr(0, 15) + "..." + "</a>";
                           }
                           else {
                               return value;
                           }
                       }
                      },
                      { field: 'MODEL_ID', title: 'Model ID', width: 100, sortable: false
                       , formatter: function (value, rowData, rowIndex) {
                           if (value.length > 15) {
                               return "<a  title='" + value + "'" + ">" + value.substr(0, 15) + "..." + "</a>";
                           }
                           else {
                               return value;
                           }
                       }
                      },
                      { field: 'POTENTIAL_STUDY_SIZE', title: 'Potential Study Size', width: 70, sortable: false },
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
                        { field: 'RESPONDER', title: 'Responder', width: 80, sortable: false },
                        { field: 'DATE_RESPONDING_F', title: 'Date of Responding', width: 100, sortable: false }
                          , { field: 'OTHERS_TO_NOTIFY', title: 'Remark', width: 150, sortable: false
                          , formatter: function (value, rowData, rowIndex) {
                              if (value.length > 20) {
                                  return "<a  title='" + value + "'" + ">" + value.substr(0, 20) + "..." + "</a>";
                              }
                              else {
                                  return value;
                              }
                          }
                          }
                 ]]

        });

        //设置分页控件属性  
        var p = $('#dgModifylog').datagrid('getPager');
        $(p).pagination({
            pageSize: 20,
            pageList: [20, 40, 60],
            beforePageText: 'Page',
            afterPageText: 'of {pages}',
            displayMsg: 'Displaying {from} to {to} of {total} items'
        });
    }
}


function reloadBindGrid(key) {
    $('#genegrid').datagrid('options').url = 'GetGenedata.ashx?M=Search_ModelIDMulti';
    var params = { key: key, cancertype: $('#ddlTumor_Type').combobox('getValue'), subtype: $('#ddlSubtype').combotree('getValues').toString() };
    $("#genegrid").datagrid('load', params);
}
function bindGrid_ModelID_Multi() {
    if ($('#genegrid').length > 0) {
        $('#genegrid').datagrid({
            width: '800',
            height: '350',
            nowrap: false,
            striped: true,
            remoteSort: false,
            idField: 'MODEL_ID',
            pagination: true,
            rownumbers: true,
            pageSize: 20,
            pageList: [20, 40, 60],
            onLoadSuccess: function (data) {
                if (data.total > 1) {
                    autoCheckbox();
                    if ($('#inline1').css('display') != "block") {
                        document.getElementById('ContinueNote').innerHTML = 'There are more than one records about "<span style="color:Red">' + $('#txtModel_ID').val() + '</span>",please select to continue:';
                        $('#w-searchGene').click();
                    }
                }
                else if (data.total == 1) {
                    One_Addselect(data.rows[0].MODEL_ID);
                }
                else {
                    document.getElementById('lblnoResults').innerHTML = "No model ID match query: <span style='color:Red'>" + $('#txtModel_ID').val() + "</span>";
                    $('#no-results').click();
                }
            },
            columns: [[
                      { field: 'ck', checkbox: true },
                      { field: 'MODEL_ID', title: 'MODEL ID', width: 300, sortable: false }
                 ]]

        });

        //设置分页控件属性  
        var p = $('#genegrid').datagrid('getPager');
        $(p).pagination({
            pageSize: 20,
            pageList: [20, 40, 60],
            beforePageText: 'Page',
            afterPageText: 'of {pages}',
            displayMsg: 'Displaying {from} to {to} of {total} items'
        });
    }
}
function autoSearch() {
    $("#searchModelID").val("");
    $("#searchModelID").unautocomplete();
    $("#searchModelID").autocomplete("GetGenedata.ashx?M=AutoModelID", {
        extraParams: { key: function () { return $('#searchModelID').val(); }
        , cancertype: function () { return $('#searchCancertype').combobox('getValue'); }
         , subtype: function () { return $('#searchSubtype').combotree('getValues').toString(); }
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
    $("#txtModel_ID").val("");
    $("#txtModel_ID").unautocomplete();
    $("#txtModel_ID").autocomplete("GetGenedata.ashx?M=AutoModelID", {
        extraParams: { key: function () { return $('#txtModel_ID').val(); }
        , cancertype: function () { return $('#ddlTumor_Type').combobox('getValue'); }
         , subtype: function () { return $('#ddlSubtype').combotree('getValues').toString(); } 
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
function depBind() {
    $('#ccBD').combotree({
        editable: false,
        url: 'Person.ashx?M=getPerson&dep=BD',
        id: "id",
        text: "text"
    })
    $('#ccSD').combotree({
        editable: false,
        url: 'Person.ashx?M=getPerson&dep=SD',
        id: "id",
        text: "text"
    })
}
function ddlbind() {
    $('#ddlTumor_Type').combobox({
        editable: false,
        url: 'Person.ashx?M=getCancertype',
        valueField: 'id',
        textField: 'text',
        onSelect: function () {
            autoSample();
            $('#ddlSubtype').combotree({
                editable: false,
                url: 'Person.ashx?M=getSubtype&Tumor_Type=' + $('#ddlTumor_Type').combobox('getValue'),
                id: 'id',
                text: 'text',
                onCheck: function () {
                    autoSample();
                }
            })
        }
    })
}
function datebind() {
    $('#txtDate_Request').datebox({
        editable: false,
        formatter: myformatter,
        parser: myparser
    })
}

function ddlbindSearch() {
    $('#searchCancertype').combobox({
        editable: false,
        url: 'Person.ashx?M=getCancertype',
        valueField: 'id',
        textField: 'text',
        onSelect: function () {
            autoSearch();
            $('#searchSubtype').combotree({
                editable: false,
                url: 'Person.ashx?M=getSubtype&Tumor_Type=' + $('#searchCancertype').combobox('getValue'),
                id: 'id',
                text: 'text',
                onCheck: function () {
                    autoSearch();
                }
            })
        }
    })
}


function myformatter(date) {
    var y = date.getFullYear();
    var m = date.getMonth() + 1;
    var d = date.getDate();
    return y + '-' + (m < 10 ? ('0' + m) : m) + '-' + (d < 10 ? ('0' + d) : d);
}
function myparser(s) {
    if (!s) return new Date();
    var ss = s.split('-');
    var y = parseInt(ss[0], 10);
    var m = parseInt(ss[1], 10);
    var d = parseInt(ss[2], 10);
    if (!isNaN(y) && !isNaN(m) && !isNaN(d)) {
        return new Date(y, m - 1, d);
    } else {
        return new Date();
    }
}
function checkkey(value, e) {
    //alert(e.which);
    var key = window.event ? e.keyCode : e.which;
    if (key >= 48 && key <= 57)
    { }
    else if (key != 8) {
        if (window.event) //IE
        {
            e.returnValue = false;   //event.returnValue=false 效果相同.
        }
        else //Firefox
        {
            e.preventDefault();
        }
    }
}

var Check = function () {
    if (confirm('Are you confirm this?')) {
        var flag = true;
        $('#form1 input').each(function () {
            if ($(this).attr('required') || $(this).attr('validType')) {
                if ($(this)[0].id != "txtDate_Request") {
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

        if (!flag) {
            alert('Please fill out the missing info as indicated.');
            return false;
        }
        else {
            var type = $('#ddlTumor_Type').combobox('getValue');
            if ($('#Searchdata').val() == "" && (type == "" || type == " ")) {
                alert('Model ID or Cancer Type is required.');
                return false;
            }
            $.ajax({
                type: "POST",
                dataType: "text",
                url: "Person.ashx?M=SaveRequest",
                data: "txtClient=" + $('#txtClient').val() + "&txtProjectNumber=" + $("#txtProjectNumber").val()
                //                                + "&ccBD=" + $('#ccBD').combotree('getValues') + "&ccSD=" + $('#ccSD').combotree('getValues') + "&txtOthers=" + $('#txtOthers').val()
                            + "&ccBD=" + $('#ccBD').val() + "&ccSD=" + $('#ccSD').val()
                            + "&ddlTumor_Type=" + $('#ddlTumor_Type').combobox('getValue') + "&ddlSubtype=" + $('#ddlSubtype').combotree('getValues')
                            + "&txtModel_ID=" + $('#Searchdata').val() + "&txtPotential_Study_Size=" + $('#txtPotential_Study_Size').val()
                            + "&txtRequirements=" + $('#txtRequirements').val(),
                success: function (msg) {
                    if (msg != "") {
                        $.messager.alert("info", msg, "info", null);
                        $("#dgRequest").datagrid('load');
                    }
                }
            });

        }
    }
}

function getdgRequest() {

    var params = { searchCancertype: $('#searchCancertype').combobox('getValue'), modelid: $('#searchModelID').val(), searchSubtype: $('#searchSubtype').combotree('getValues').toString(), is_responded: $('#searchResponded').combobox('getValue') };
    $("#dgRequest").datagrid('load', params);

}
function bindGrid() {
    $('#dgRequest').datagrid({
        url: 'Getdatagrid.ashx?M=getdgRequest',
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
                    { field: 'REQUEST_ID', title: 'Request ID', width: 60, sortable: false },
                      { field: 'HAVE_RESPONDED', title: 'Responded', width: 60, sortable: false },
                         { field: 'HAVE_CONFIRMED', title: 'Confirmed', width: 60, sortable: false }
                ]],
        columns: [[
              { field: 'CONFIRM_DATE_F', title: 'Data of Confirm', width: 90, sortable: false },
                    { field: 'DATE_REQUEST_F', title: 'Date of Request', width: 90, sortable: false },
        { field: 'PROJECT_NUMBER', title: 'Project Number', width: 135, sortable: false },
                      { field: 'CLIENT', title: 'Client', width: 80, sortable: false },
                      { field: 'BD', title: 'BD', width: 100, sortable: false },
                      { field: 'SD', title: 'SD', width: 100, sortable: false },
        //{ field: 'OTHERS_TO_NOTIFY', title: 'Others to Notify', width: 110, sortable: false },
                      {field: 'TUMOR_TYPE', title: 'Cancer Type', width: 100, sortable: false
                       , formatter: function (value, rowData, rowIndex) {
                           if (value.length > 15) {
                               return "<a  title='" + value + "'" + ">" + value.substr(0, 15) + "..." + "</a>";
                           }
                           else {
                               return value;
                           }
                       }
                  },
                      { field: 'SUBTYPE', title: 'Subtype', width: 150, sortable: false
                       , formatter: function (value, rowData, rowIndex) {
                           if (value.length > 15) {
                               return "<a  title='" + value + "'" + ">" + value.substr(0, 15) + "..." + "</a>";
                           }
                           else {
                               return value;
                           }
                       }
                      },
                      { field: 'MODEL_ID', title: 'Model ID', width: 100, sortable: false
                       , formatter: function (value, rowData, rowIndex) {
                           if (value.length > 15) {
                               return "<a  title='" + value + "'" + ">" + value.substr(0, 15) + "..." + "</a>";
                           }
                           else {
                               return value;
                           }
                       }
                      },
                      { field: 'POTENTIAL_STUDY_SIZE', title: 'Potential Study Size', width: 70, sortable: false },
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
                        { field: 'RESPONDER', title: 'Responder', width: 80, sortable: false },
                        { field: 'DATE_RESPONDING_F', title: 'Date of Responding', width: 100, sortable: false }
                         ,{ field: 'OTHERS_TO_NOTIFY', title: 'Remark', width: 150, sortable: false
                          , formatter: function (value, rowData, rowIndex) {
                              if (value.length > 20) {
                                  return "<a  title='" + value + "'" + ">" + value.substr(0, 20) + "..." + "</a>";
                              }
                              else {
                                  return value;
                              }
                          }
                         }
                       , { field: 'opt', title: '', align: 'left', width: 80,
                           formatter: function (value, rowData, rowIndex) {
                               if (rowData.log_count != "") {
                                   return "<a href='#' onclick='reload_dgModifylog(&quot;" + rowData.REQUEST_ID + "&quot;);'>modify log</a>";
                               }
                               else {
                                   return "";
                               }
                           }
                       }
                 ]]
                   , onClickRow: function (rowIndex, rowData) {

                       if (rowData.HAVE_RESPONDED == "Y") {
                           getdgSelectMice(rowData.REQUEST_ID, "");
                       }
                       else {
                           getdgSelectMice("", "");
                       }
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



function doModify() {
    //$('#ddlTumor_Type').combobox('select', "");
    //closeAll_tag_action();
    var row = $('#dgRequest').datagrid('getSelected');
    if (row) {
        var type = $('#ddlTumor_Type').combobox('getValue');
        if ($('#Searchdata').val() == "" && (type == "" || type == " ")) {
            alert('Model ID or Cancer Type is required.');
            return false;
        }
        else if ($('#txtProjectNumber').val() == "")
        {
            alert('Project Number is required.');
            return false;
        }
        else {
            if (confirm('Are you confirm this?')) {
                $.ajax({
                    type: "POST",
                    dataType: "text",
                    url: "Person.ashx?M=ModifyRequest",
                    data: "&hfRequest_id=" + row.REQUEST_ID
                            +"&ddlTumor_Type=" + $('#ddlTumor_Type').combobox('getValue') + "&ddlSubtype=" + $('#ddlSubtype').combotree('getValues')
                            + "&txtModel_ID=" + $('#Searchdata').val() + "&PN=" + $('#txtProjectNumber').val(),
                    success: function (msg) {
                        if (msg != "") {
                            $.messager.alert("info", msg, "info", null);
                            $("#dgRequest").datagrid('load');
                        }
                    }
                });
            }
        }
    }
    else {
        $.messager.alert("info", "Please select one request below.", "info", null);
    }
}

function ConfirmRequest() {

    var row = $('#dgRequest').datagrid('getSelected');
    if (row) {
        if (row.HAVE_RESPONDED == "Y") {
            if (row.HAVE_CONFIRMED == "N") {
                if (confirm('Are you confirm this?')) {
                    $.ajax({
                        type: "POST",
                        dataType: "text",
                        url: "Person.ashx?M=SavePorjectbooking",
                        data: "&hfRequest_id=" + row.REQUEST_ID
                + "&model_ids=" ,
                        success: function (msg) {
                            if (msg != "") {
                                $.messager.alert("info", msg, "info", null);
                                $("#dgRequest").datagrid('load');
                            }
                        }
                    });
                }
            }
            else {
                $.messager.alert("info", "This request has been booked.", "info", null);
            }
        }
        else {
            $.messager.alert("info", "This request has not been responded.", "info", null);
        }
    }
    else {
        $.messager.alert("info", "Please select one request below.", "info", null);
    }
}
function getdgSelectMice(request_id, model_ids) {
    //$('#hfmodel_ids').val(model_ids);
    var params = { hfrequest_id: request_id, model_ids: model_ids };
    $("#dgSelectMice").datagrid('load', params);
}
function bindGridMice() {
    $('#dgSelectMice').datagrid({
        url: 'Getdatagrid.ashx?M=getdgSelectMice',
        iconCls: 'icon-export',
        width: 'auto',
        height: 'auto',
        title: "Model Status-Animal info",
        fitColumns: true,
        singleSelect: false,
        nowrap: false,
        striped: true,
        remoteSort: true,
        pagination: true,
        rownumbers: true,
        pageSize: 10,
        pageList: [10, 20, 30, 40],
        frozenColumns: [[
        //                    { field: 'ck', checkbox: true },



            ]],
        columns: [[
    { field: 'Model_ID', title: 'Model ID', width: 80, sortable: true }
           , { field: 'Current_Project_Number', title: 'Current_Project_Number', width: 100, sortable: false }
                                , { field: 'Rn', title: 'Rn', width: 100, sortable: false },
                               { field: 'Pn', title: 'Pn', width: 100, sortable: false },
                               { field: 'Model_Fit_for_efficacy', title: 'Model_Fit_for_efficacy', width: 100, sortable: false },
                               { field: 'Location_of_live_animal', title: 'Location_of_live_animal', width: 100, sortable: false },
                                { field: 'Animal_Room_Number', title: 'Animal_Room_Number', width: 100, sortable: false },
                                 { field: 'IVC_Location', title: 'IVC_Location', width: 200, sortable: false
                                   , formatter: function (value, rowData, rowIndex) {
                                       if (value.length > 15) {
                                           return "<a  title='" + value + "'" + ">" + value.substr(0, 15) + "..." + "</a>";
                                       }
                                       else {
                                           return value;
                                       }
                                   } 
                                 },
                                  { field: 'DOI', title: 'DOI', width: 100, sortable: false },
                                   { field: 'Model_status', title: 'Model_status', width: 100, sortable: false },
                                   { field: 'Animal_Number', title: 'Animal_Number', width: 200, sortable: false
                                    , formatter: function (value, rowData, rowIndex) {
                                        if (value.length > 15) {
                                            return "<a  title='" + value + "'" + ">" + value.substr(0, 15) + "..." + "</a>";
                                        }
                                        else {
                                            return value;
                                        }
                                    }
                                   },
                                     { field: 'Date_of_Update', title: 'Date_of_Update', width: 100, sortable: false },
                                    { field: 'TV', title: 'TV', width: 100, sortable: false },
                                     { field: 'Extimated_DOT', title: 'Extimated_DOT', width: 100, sortable: true },
                                     { field: 'Time_of_Model_for_Transplant', title: 'Time_of_Model_for_Transplant', width: 100, sortable: false },

                 ]]



    });
}