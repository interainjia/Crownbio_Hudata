$(function () {
//    autoSample();
//   
//    datebind();
    //    ddlbind();
    bigImg();
    bindGrid();
    $('#hfRequest_id').val();
    bindGrid_Modifylog();
});
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
function reload() {
    Sys.WebForms.PageRequestManager.getInstance().add_endRequest(depBind);
    Sys.WebForms.PageRequestManager.getInstance().add_endRequest(autoSample);
    Sys.WebForms.PageRequestManager.getInstance().add_endRequest(datebind);
    Sys.WebForms.PageRequestManager.getInstance().add_endRequest(ddlbind);
}
function autoSample() {
    $("#txtModel_ID").autocomplete("GetGenedata.ashx?M=AutoModelID", {
        minChars: 0, //自动完成激活之前填入的最小字符 
        width: 150,
        max: 100,
        matchContains: false, //包含匹配，就是data参数里的数据，是否只要包含文本框里的数据就显示 
        autoFill: false, //自动填充 
        parse: function (data) {
            return $.map(eval(data), function (row) {
                return {
                    data: row,
                    value: row.ModelID,
                    result: row.ModelID
                }
            });
        },
        formatItem: function (data) { return data.ModelID; }, //格式化选项
        formatResult: function (data) { return data.ModelID; } //格式化选择结果
    });
    $("#searchModelID").autocomplete("GetGenedata.ashx?M=AutoModelID", {
        minChars: 0, //自动完成激活之前填入的最小字符 
        width: 100,
        max: 100,
        matchContains: false, //包含匹配，就是data参数里的数据，是否只要包含文本框里的数据就显示 
        autoFill: false, //自动填充 
        parse: function (data) {
            return $.map(eval(data), function (row) {
                return {
                    data: row,
                    value: row.ModelID,
                    result: row.ModelID
                }
            });
        },
        formatItem: function (data) { return data.ModelID; }, //格式化选项
        formatResult: function (data) { return data.ModelID; } //格式化选择结果
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
            $('#ddlSubtype').combobox({
                editable: false,
                url: 'Person.ashx?M=getSubtype&Tumor_Type=' + $('#ddlTumor_Type').combobox('getValue'),
                valueField: 'id',
                textField: 'text'
            })
        }
    })
}
function datebind() {
    $('#txtDateRespond').datebox({
        editable: false,
        formatter: myformatter,
        parser: myparser
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
function ConfirmRespond() {
    var row = $('#dgRespond').datagrid('getSelected');
    var row1 = $('#dgSelectMice').datagrid('getSelected');
    if (row) {
        if (row.HAVE_RESPONDED != "Y") {
            if (confirm('Are you confirm this?')) {
                var rows = $('#dgSelectMice').datagrid('getSelections');
                var ids = [];
                for (var i = 0; i < rows.length; i++) {
                    //每行ID放入数组中
                    ids.push(rows[i].Model_ID + ";" + rows[i].Rn + ";" + rows[i].Pn + ";" + rows[i].Estimated_DOT);
                }
                //必须为string类型，不然传不过去  
                var aa = ids.toString();
                $.ajax({
                    type: "POST",
                    dataType: "text",
                    url: "Person.ashx?M=SaveRespond",
                    data: { hfRequest_id: row.REQUEST_ID, mids: aa, remark: $('#txtRemark').val() },
                    success: function (msg) {
                        if (msg != "") {
                            $.messager.alert("info", msg, "info", null);
                            $("#dgRespond").datagrid('load');
                            $("#dgSelectMice").datagrid('load');
                        }
                    }
                });
            }
        }
        else {
            $.messager.alert("info", "This request has been responded.", "info", null);
        }
    }
    else {
        $.messager.alert("info", "Please select one request below.", "info", null);
    }
}
var Check = function () {
    if (confirm('Are you confirm this?')) {
        if ($('#hfRequest_id').val() == "") {
            $.messager.alert("info", "Please select one request below.", "info", null);
        }
        else {
            var flag = true;
            $('#form1 input').each(function () {
                if ($(this).attr('required') || $(this).attr('validType')) {
                    if ($(this)[0].id != "txtDateRespond") {
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

                $.ajax({
                    type: "POST",
                    dataType: "text",
                    url: "Person.ashx?M=CheckRespond",
                    data: "&txtDateRespond=" + $("#txtDateRespond").datebox("getValue")
                + "&txtTotal_Tumor_Bearing_Mice=" + $('#txtTotal_Tumor_Bearing_Mice').val()
            + "&ddlModel_Status=" + $('#ddlModel_Status').combobox('getValue')
            + "&txtTotal_TV_On_All_Mice=" + $('#txtTotal_TV_On_All_Mice').val() + "&txtEstimated_Time_To_Transplant=" + $('#txtEstimated_Time_To_Transplant').val(),
                    success: function (msg) {
                        if (msg != "") {
                            $.messager.alert("info", msg, "info", null);
                        }
                        else {


                            $.ajax({
                                type: "POST",
                                dataType: "text",
                                url: "Person.ashx?M=SaveRespond",
                                data: "&txtDateRespond=" + $("#txtDateRespond").datebox("getValue")
                            + "&hfRequest_id=" + $('#hfRequest_id').val()
                + "&txtTotal_Tumor_Bearing_Mice=" + $('#txtTotal_Tumor_Bearing_Mice').val()
            + "&ddlModel_Status=" + $('#ddlModel_Status').combobox('getValue')
            + "&txtTotal_TV_On_All_Mice=" + $('#txtTotal_TV_On_All_Mice').val() + "&txtEstimated_Time_To_Transplant=" + $('#txtEstimated_Time_To_Transplant').val(),
                                success: function (msg) {
                                    if (msg != "") {
                                        $.messager.alert("info", msg, "info", null);
                                        $("#dgRespond").datagrid('load');
                                    }
                                }
                            });
                        }

                    }
                });
            }
        }
    }
}
function getdgSelectMice(request_id, model_ids) {
    $('#hfmodel_ids').val(model_ids);
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
        idField: 'AutoID',
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
                   { field: 'ck', checkbox: true },
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
                                     { field: 'Estimated_DOT', title: 'Estimated_DOT', width: 100, sortable: true },
                                     { field: 'Time_of_Model_for_Transplant', title: 'Time_of_Model_for_Transplant', width: 100, sortable: false },

                 ]]


    });
}
function getdgRespond() {

    var params = { modelid: $('#searchModelID').val(), is_responded: $('#searchResponded').combobox('getValue') };
    $("#dgRespond").datagrid('load', params);

}
function bindGrid() {
    $('#dgRespond').datagrid({
        url: 'Getdatagrid.ashx?M=getdgRespond',
        iconCls: 'icon-export',
        width: 'auto',
        height: 'auto',
        title: "Request",
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
         { field: 'ck', checkbox: true },
        //                    {field: 'DATE_REQUEST_F', title: 'Date of Request', width: 100, sortable: false }
           {field: 'REQUEST_ID', title: 'Request ID', width: 80, sortable: false },
                  { field: 'HAVE_RESPONDED', title: 'Responded', width: 100, sortable: false },
            { field: 'HAVE_CONFIRMED', title: 'Confirmed', width: 100, sortable: false }
            ]],
        columns: [[
                        { field: 'RESPONDER', title: 'Responder', width: 60, sortable: false },
                        { field: 'DATE_RESPONDING_F', title: 'Date of Responding', width: 110, sortable: false },
                        { field: 'CLIENT', title: 'Client', width: 80, sortable: false },
                        { field: 'BD', title: 'BD', width: 80, sortable: false },
                        { field: 'SD', title: 'SD', width: 80, sortable: false },
                          { field: 'DATE_REQUEST_F', title: 'Date of Request', width: 90, sortable: false },
                          { field: 'SPECIAL_REQUIREMENTS', title: 'Special Requirements', width: 200, sortable: false
                            , formatter: function (value, rowData, rowIndex) {
                                if (value.length > 15) {
                                    return "<a  title='" + value + "'" + ">" + value.substr(0, 15) + "..." + "</a>";
                                }
                                else {
                                    return value;
                                }
                            }
                        },
                        { field: 'OTHERS_TO_NOTIFY', title: 'Remark', width: 150, sortable: false
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
                                      return "<a href='javascript:void();' onclick='reload_dgModifylog(&quot;" + rowData.REQUEST_ID + "&quot;);'>modify log</a>";
                                  }
                                  else {
                                      return "";
                                  }
                              }
                          }

                 ]]
                 , onClickRow: function (rowIndex, rowData) {
                     DisEdit();
                     getdgSelectMice(rowData.REQUEST_ID, "");
                 }
                

    });

    //设置分页控件属性  
    var p = $('#dgRespond').datagrid('getPager');
    $(p).pagination({
        beforePageText: 'Page',
        afterPageText: 'of {pages}',
        displayMsg: 'Displaying {from} to {to} of {total} items'
    });
}

function DisEdit() {
    var row = $('#dgRespond').datagrid('getSelected');
    if (row) {
//        $('#ddlModel_Status').select("Available for Efficacy Study");

//        $('#txtDateRespond').datebox('setValue', row.DATE_RESPONDING_F);
//        $('#txtTotal_Tumor_Bearing_Mice').attr('value', row.TOTAL_TUMOR_BEARING_MICE);
//        $('#txtTotal_TV_On_All_Mice').attr('value', row.TOTAL_TV_ON_ALL_MICE);
//        $('#txtEstimated_Time_To_Transplant').attr('value', row.ESTIMATED_TIME_TO_TRANSPLANT);
//        if (row.MODEL_STATUS != "") {
//            $('#ddlModel_Status').combobox('select', row.MODEL_STATUS)
//        }
//        else {
//            $('#ddlModel_Status').select("Available for Efficacy Study");
//        }

     
//        $('#txtDataRequest').attr('value', row.DATE_REQUEST_F);
//        $('#ccBD').attr('value', row.BD);
//        $('#ccSD').attr('value', row.SD);
//        $('#txtClient').attr('value', row.CLIENT);
        $('#txtModel_ID').attr('value', row.MODEL_ID);
        $('#txtTumor_Type').attr('value', row.TUMOR_TYPE);
        $('#txtSubtype').attr('value', row.SUBTYPE);
//        $('#txtRequirements').attr('value', row.SPECIAL_REQUIREMENTS);
        $('#txtPotential_Study_Size').attr('value', row.POTENTIAL_STUDY_SIZE);
        $('#txtProjectNumber').attr('value', row.PROJECT_NUMBER);


        $('#hfRequest_id').val(row.REQUEST_ID);
        if (row.DATE_RESPONDING_F != "") {
            $('#btnSend3').css('display', "none");
        }
        else {
            $('#btnSend3').css('display', "inline-block");
        }
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
                if (data.total >0) {
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