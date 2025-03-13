$(function () {
    autoSearch();
    bindGrid();
    bigImg();
    binddgStudyDesign();
    cbxToProject();
    $('#divMonitorImport').accordion({
        border: false
    });
//    $('#txtSD').combobox({
//        editable: true,
    //        url: 'Person.ashx?M=getccLeading_SD',
//        valueField: 'id',
//        textField: 'text'
//    });
    $('#txtJSD').combobox({
        editable: true,
        url: 'Person.ashx?M=getccSD',
        valueField: 'id',
        textField: 'text'
    });
    $('#txtDTgroup').combobox({
        editable: true,
        url: 'Person.ashx?M=getMonitorDTgroup',
        valueField: 'id',
        textField: 'text',
        onSelect: function () {
            
            ddlDT();
        },
        onLoadSuccess: function () {
            
            ddlDT();
        }
    });
    $('#txtDM').combobox({
        editable: true,
        url: 'Person.ashx?M=getMonitorDM',
        valueField: 'id',
        textField: 'text'
    });

});
function ddlDT() {
    $('#ddlDT').combotree({
        editable: false,
        url: 'Person.ashx?M=getddlDT&DTgroup=' + $('#txtDTgroup').combobox('getValue'),
        id: 'id',
        text: 'text'
        , onLoadSuccess: function () {
            if ($('#hfDT').val() != "") {
                var arr = $('#hfDT').val().split(",");
                //                $('#ddlDT').combotree('setValues', arr);
                for (i = 0; i < arr.length; i++) {
                    node = $('#ddlDT').combotree('tree').tree('find', arr[i]);
                    if (node != null) {
                        $('#ddlDT').combotree('tree').tree('check', node.target);
                    }
                }
            }
        }
    });
}
function bigImg() {
    if ($('.fancybox').length > 0) {
        $('.fancybox').fancybox({

    });
}
};
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
function getdgProjectMonitor() {
    var params = { model_id: $('#searchModelID').val()
    , searchProjectNumber: $('#searchProjectNumber').val()
    , searchDOI: $('#searchDOI').val()
    , searchCompleted: $('#searchCompleted').val()
     , searchJSD: $('#searchJSD').val()
      , searchPM: $('#searchPM').val()
    };
    $("#dgProjectMonitor").datagrid('reload', params);
}
function bindGrid() {
    $('#dgProjectMonitor').datagrid({
        url: 'Getdatagrid.ashx?M=getdgProjectMonitor&type=All',
        iconCls: 'icon-export',
        width: 'auto',
        height: 'auto',
        title: "Project Monitor",
        idField: 'PROJECT_MONITOR_ID',
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

              { field: 'REQUEST_ID', title: 'Request ID', width: 80, sortable: false },
           { field: 'Model_ID', title: 'Model ID', width: 100, sortable: false },
              { field: 'Major_Project', title: 'Major Project', width: 250, sortable: false },
               { field: 'Sub_Project', title: 'Sub Project', width: 250, sortable: false },
                     { field: 'Request_Status', title: 'Request Status', width: 120, sortable: false },
                  { field: 'Type_of_Study', title: 'Type of Study', width: 250, sortable: false },
                  { field: 'Potential_Study_Size', title: 'Study Size', width: 120, sortable: false },

                           { field: 'opt', title: 'Tissue/Animal Providing', width: 130, sortable: false,
                               formatter: function (value, rowData, rowIndex) {
                                   if (rowData.Provide_Seeding_Animal == "") {
                                       return "<a href='javascript:void();' onclick='getAnimal_Handover(&quot;" + rowData.Model_ID + "&quot;,&quot;" + rowData.REQUEST_ID + "&quot;,&quot;" + rowData.Provide_Seeding_Animal + "&quot;);'>To Provide</a>";
                                   }
                                   else {
                                       return "<a href='javascript:void();' onclick='getAnimal_Handover(&quot;" + rowData.Model_ID + "&quot;,&quot;" + rowData.REQUEST_ID + "&quot;,&quot;" + rowData.Provide_Seeding_Animal + "&quot);'>" + rowData.Provide_Seeding_Animal + "</a>";
                                   }
                               }
                           },
                    { field: 'Estimated_DOI', title: 'Estimated DOI', width: 180, sortable: false },
                      { field: 'Cachexia_Label', title: 'Cachexia Label', width: 100, sortable: false },
                 { field: 'CV40_Take_rate', title: 'CV 40% (take rate)', width: 100, sortable: false },
        

                     { field: 'STR_Consistence', title: 'STR', width: 230, sortable: false },
//                      { field: 'DOI', title: 'Day of Inoculation', width: 150, sortable: false },
//                        { field: 'DOR', title: 'Day of Randomization', width: 150, sortable: false },
        //                          { field: 'DOT', title: 'Day of Termination', width: 150, sortable: false },
  {field: 'PM', title: 'PM', width: 100, sortable: false },
                            { field: 'SD', title: 'SD', width: 100, sortable: false },
  { field: 'JSD', title: 'JSD', width: 100, sortable: false },
    { field: 'DT_Group', title: 'DT Group', width: 100, sortable: false },
    { field: 'DT', title: 'DT', width: 100, sortable: false },
      { field: 'DM', title: 'DM', width: 100, sortable: false },
  { field: 'Room', title: 'Room', width: 100, sortable: false },
    { field: 'Number_of_Animal_Purchase', title: 'Number of Animal Purchase', width: 100, sortable: false },
      { field: 'Number_of_Animal_Inoculated', title: 'Number of Animal Inoculated', width: 100, sortable: false },
    { field: 'BW_TV_Measure_During_Treatment', title: 'BW/TV Measure During Treatment', width: 100, sortable: false },
      { field: 'BW_TV_Measure_During_Observation', title: 'BW/TV Measure During Observation', width: 100, sortable: false },
                                     { field: 'FFPE_Tumor_Sample_Number', title: 'FFPE Tumor Sample Number', width: 100, sortable: false },
                                       { field: 'Snap_Frozne_Sample_Number', title: 'Snap Frozne Sample Number', width: 100, sortable: false },
                                           { field: 'Blood_Sample_Type', title: 'Blood Sample Type', width: 100, sortable: false },
                                            { field: 'Blood_Sample_Number', title: 'Blood Sample Number', width: 100, sortable: false },
                                { field: 'Sample_Amount', title: 'Sample Amount', width: 100, sortable: false },

{ field: 'Signed_Quotation', title: 'Signed_Quotation', width: 100, sortable: false },
{ field: 'Kickoff', title: 'Kickoff', width: 100, sortable: false },
{ field: 'Register_Project', title: 'Register_Project', width: 100, sortable: false },
{ field: 'Booking_Animals', title: 'Booking_Animals', width: 100, sortable: false },
{ field: 'Order_Animal', title: 'Order_Animal', width: 100, sortable: false },
{ field: 'Finalize_Protocol', title: 'Finalize_Protocol', width: 100, sortable: false },
{ field: 'Provide_Seeding_Animal', title: 'Provide_Seeding_Animal', width: 100, sortable: false },
{ field: 'Inoculation', title: 'Inoculation', width: 100, sortable: false },
{ field: 'Randomization', title: 'Randomization', width: 100, sortable: false },
{ field: 'Treatment_Start', title: 'Treatment_Start', width: 100, sortable: false },
{ field: 'Treatment_Finished', title: 'Treatment_Finished', width: 100, sortable: false },
{ field: 'Observation_Post_Treatment', title: 'Observation_Post_Treatment', width: 100, sortable: false },
{ field: 'Tissue_Collection', title: 'Tissue_Collection', width: 100, sortable: false },
{ field: 'Tissue_Sent_Out', title: 'Tissue_Sent_Out', width: 100, sortable: false },
{ field: 'Final_Data_Sent_Out', title: 'Final_Data_Sent_Out', width: 100, sortable: false },
{ field: 'Document_Archieve', title: 'Document_Archieve', width: 100, sortable: false },
{ field: 'Report_Sent_Out', title: 'Report_Sent_Out', width: 100, sortable: false },
{ field: 'Balance_Invoice_Sent_Out', title: 'Balance_Invoice_Sent_Out', width: 100, sortable: false },
{ field: 'Completion_Proportions_Per_Study', title: 'Completion_Proportions_Per_Study', width: 100, sortable: false },
{ field: 'Completion_Proportions_Per_Project', title: 'Completion_Proportions_Per_Project', width: 100, sortable: false },
{ field: 'Complete_Study', title: 'Complete_Study', width: 100, sortable: false }


        //                    , { field: 'opt', title: '', align: 'left', width: 80,
        //                        formatter: function (value, rowData, rowIndex) {

        //                            return "<a href='#' onclick='EditProjectMonitor(&quot;" + rowData.PROJECT_MONITOR_ID + "&quot;);'>Edit</a>";

        //                        }
        //                            }

                 ]]
                   , onClickRow: function (rowIndex, rowData) {
                       EditProjectMonitor(rowData.PROJECT_MONITOR_ID);
                     
                   }


    });
}

function SaveAnimal_Handover() {
    var all_DeliverDate = [];
    $("input[name='all_DeliverDate']").each(function () {
        all_DeliverDate.push($(this)[0].defaultValue);
    });
    var all_ReceiveDate = [];
    $("input[name='all_ReceiveDate']").each(function () {
        all_ReceiveDate.push($(this)[0].defaultValue);
    });
    $.ajax({
        type: "POST",
        dataType: "text",
        url: "Person.ashx?M=SaveAnimal_Handover",
        data: "hfMid=" + $('#hfAnimal_Handover_mid').val() + "&hfRid=" + $('#hfAnimal_Handover_rid').val()

                 + "&lblTissue_Batch=" + $('#lblTissue_Batch').val() + "&txtDate_of_Tissue=" + $('#txtDate_of_Tissue').datebox('getValue')
                  + "&txtAnimal_by_Tissue=" + $('#txtAnimal_by_Tissue').val() + "&lblSourceProject=" + $('#lblSourceProject').html()
                  + "&lblLeader=" + $('#lblLeader').html() + "&lblModelbatch1=" + $('#lblModelbatch1').html()
                  + "&lblAnimal_by_Live=" + $('#lblAnimal_by_Live').html() + "&IVC=" + $('#IVC').html()
                   + "&lblDOT=" + $('#lblDOT').html() + "&txtDeliver=" + all_DeliverDate.join(';').toString()
                    + "&lblReceivingProject=" + $('#lblReceivingProject').html() + "&lblJSD=" + $('#lblJSD').html()
                     + "&lblModelbatch2=" + $('#lblModelbatch2').html() + "&txtAlive=" + $('#txtAlive').val()
                        + "&txtDead=" + $('#txtDead').val() + "&txtReceive=" + all_ReceiveDate.join(';').toString()
                           + "&txtInoculation_Used=" + $('#txtInoculation_Used').val() + "&txtTissue=" + $('#txtTissue').val()
                    ,
        success: function (msg) {
            if (msg == "") {
                $.messager.alert("info", "Save successfully.", "info", null);
                $('#hfAnimal_Handover_mid').val("");
                $('#hfAnimal_Handover_rid').val("");
                $.fancybox.close();
                $("#dgProjectMonitor").datagrid('reload');
            }
        }
    });
}

var div_id = 0;
var div_id_2 = 0;
function getAnimal_Handover(mid, rid, pdate) {
    $('#allDeliver').html("");
    $('#allReceive').html("");
    div_id = 0;
    div_id_2 = 0;
    $.ajax({
        type: "POST",
        dataType: "text",
        url: "Getdatagrid.ashx?M=CheckRole_Animal_Handover",
        success: function (msg) {
            if (msg != "") {
                $.ajax({
                    type: "POST",
                    dataType: "json",
                    url: "Getdatagrid.ashx?M=getAnimal_Handover",
                    data: "hfMid=" + mid + "&hfRid=" + rid
                    + "&pdate=" + pdate,
                    success: function (data) {
                        if (data.length > 0) {
                            if (msg == "save") {
                                $('#btnSaveAnimal_Handover').css('display', 'block');
                            }
                            else if (msg == "read only") {
                                $('#btnSaveAnimal_Handover').css('display', 'none');
                            }
                            $('#w-Provide').click();
                            $('#lblTissue_Batch').val(data[0].Tissue_Batch);
                            $('#txtDate_of_Tissue').datebox('setValue', data[0].Date_of_Tissue);
                            $('#txtAnimal_by_Tissue').val(data[0].Animal_by_Tissue);
                            $('#lblSourceProject').html(data[0].Source_Project);
                            $('#lblLeader').html(data[0].Leader);
                            $('#lblModelbatch1').html(data[0].Modelbatch1);
                            $('#lblAnimal_by_Live').html(data[0].Animal_by_Live);
                            $('#IVC').html(data[0].IVC);
                            $('#lblDOT').html(data[0].Expected_Date_To_Support);

                            $('#lblReceivingProject').html(data[0].Receiving_Project);
                            $('#lblJSD').html(data[0].JSD);
                            $('#lblModelbatch2').html(data[0].Modelbatch2);
                            $('#txtAlive').val(data[0].Healthy_and_Alive);
                            $('#txtDead').html(data[0].Animal_Dead);

                            $('#txtInoculation_Used').val(data[0].Inoculation_Used);
                            $('#txtTissue').html(data[0].Tissue_Collection);
                            $('#hfAnimal_Handover_mid').val(mid);
                            $('#hfAnimal_Handover_rid').val(rid);

                            var dates = new Array();
                            if (data[0].Date_of_Deliver != null && data[0].Date_of_Deliver !="") {
                                dates = data[0].Date_of_Deliver.split(";");
                                for (i = 0; i < dates.length; i++) {
                                    var txtid = "txtDeliver" + i;
                                    $('#allDeliver').append(" <div id='div" + div_id + "'><input id='txtDeliver" + i + "' name=\"all_DeliverDate\" class=\"easyui-datebox\" data-options=\"formatter:myformatter\" editable=\"false\" /><input type='button' value = 'close' onclick='closeDate(\"div" + div_id + "\");'/></br></div>");
                                    $.parser.parse('#allDeliver');
                                    $("#" + txtid + "").datebox('setValue', dates[i]);
                                    div_id++;
                                }
                            }

                            var dates_2 = new Array();
                            if (data[0].Date_of_Receive != null && data[0].Date_of_Receive !="") {
                                dates_2 = data[0].Date_of_Receive.split(";");
                                for (i = 0; i < dates_2.length; i++) {
                                    var txtid = "txtReceive" + i;
                                    $('#allReceive').append(" <div id='divTwo" + div_id_2 + "'><input id='txtReceive" + i + "' name=\"all_ReceiveDate\" class=\"easyui-datebox\" data-options=\"formatter:myformatter\" editable=\"false\" /><input type='button' value = 'close' onclick='closeDate(\"divTwo" + div_id_2 + "\");'/></br></div>");
                                    $.parser.parse('#allReceive');
                                    $("#" + txtid + "").datebox('setValue', dates[i]);
                                    div_id_2++;
                                }
                            }


                        }
                    }
                });
            }
        }
    });


    

}

function closeDate(id) {
    $("#" + id + "").remove();
}
function longStr(value) {
    if (value.length > 15) {
        return "<a  title='" + value + "'" + ">" + value.substr(0, 15) + "..." + "</a>";
    }
    else {
        return value;
    }
}

function EditProjectMonitor(monitor_id) {
    var row = $('#dgProjectMonitor').datagrid('getSelected');

    if (row) {
        $('#hfMonitor_id').val(monitor_id);

        $('#txtNumber_of_Animal_Purchase').val(row.Number_of_Animal_Purchase);
        $('#txtNumber_of_Animal_Inoculation').val(row.Number_of_Animal_Inoculated);
        
        $('#txtSD').val(row.SD);
        $('#txtJSD').combobox('setValue', row.JSD);
        $('#txtDTgroup').combobox('setValue', row.DT_Group);
        $('#lblModelID').html(row.Model_ID); 
        $('#txtDM').combobox('setValue', row.DM);

        if (row.DT != "") {
            $('#hfDT').val(row.DT_ID);
        }
        else {
            $('#hfDT').val("");
        }
        ddlDT();
        $('#txtROOM').val(row.Room);

        $('#txtArms').html(row.Arms);
        $('#txtFFPE').val(row.FFPE_Tumor_Sample_Number);
        $('#txtSnap').val(row.Snap_Frozne_Sample_Number);
        
        $('#txtbloodnumber1').val("0");
        $('#txtbloodnumber2').val("0");
        $('#txtbloodnumber3').val("0");
        var number = row.Blood_Sample_Number.split(",");
        var type = row.Blood_Sample_Type.split(",");
        for (var i = 0; i < type.length; i++) {
            if (type[i] == "Plasma") {
                $('#txtbloodnumber1').val(number[i]);
            }
            else if (type[i] == "Serum") {
                $('#txtbloodnumber2').val(number[i]);
            }
            else if (type[i] == "Whole Blood") {
                $('#txtbloodnumber3').val(number[i]);
            }
        }

        $('#txtSample_Amount').html(row.Sample_Amount);
        $('#txtTumor_Monitor_Schedule').val(row.BW_TV_Measure_During_Treatment);
        $('#txtTumor_Monitor_Schedule2').val(row.BW_TV_Measure_During_Observation);
      
        $("#txtMajorProject").html(row.Major_Project);
        $("#txtSubProject").html(row.Sub_Project);
    }

}

function SaveMonitorAdd() {
    $.ajax({
        type: "POST",
        dataType: "text",
        url: "Person.ashx?M=SaveMonitorAdd",
        success: function (msg) {
            alert(msg);
        }
    });
}


function SaveMonitor() {
    if ($('#hfMonitor_id').val() != "") {
        var flag = true;
        $('#context input').each(function () {
            if ($(this).attr('required') || $(this).attr('validType')) {
                if (!$(this).validatebox('isValid')) {
                    flag = false;
                    return;
                }
            }
        });
        if (!flag) {
            alert('Please fill out the missing info as indicated.');
            return false;
        }
        if (flag) {
            if (confirm('Are you confirm this?')) {
                
                var txtJSD = $('#txtJSD').combobox('getValue');
                var txtDTgroup = $('#txtDTgroup').combobox('getValue');
                var txtDM = $('#txtDM').combobox('getValue');
                var ddlDT = $('#ddlDT').combotree('getValues');

            

                $.ajax({
                    type: "POST",
                    dataType: "text",
                    url: "Person.ashx?M=SaveMonitor",
                    data: "hfMonitor_id=" + $('#hfMonitor_id').val()

            + "&txtNumber_of_Animal_Purchase=" + $('#txtNumber_of_Animal_Purchase').val()
            + "&txtNumber_of_Animal_Inoculation=" + $('#txtNumber_of_Animal_Inoculation').val()
            + "&txtJSD=" + txtJSD
            + "&txtDTgroup=" + txtDTgroup
            + "&ddlDT_ID=" + ddlDT
            + "&ddlDT=" + $('#ddlDT').combotree('getText')
            + "&txtDM=" + txtDM
            + "&txtROOM=" + $('#txtROOM').val()
        + "&txtTumor_Monitor_Schedule2=" + $('#txtTumor_Monitor_Schedule2').val()
        + "&txtTumor_Monitor_Schedule=" + $('#txtTumor_Monitor_Schedule').val()
       
          
          
            + "&txtFFPE=" + $('#txtFFPE').val()
            + "&txtSnap=" + $('#txtSnap').val()
            + "&txtbloodnumber=" + $('#txtbloodnumber1').val() + "," + $('#txtbloodnumber2').val() + "," + $('#txtbloodnumber3').val(),
         
       
           
                    success: function (msg) {
                        if (msg == "") {
                            $.messager.alert("info", "Save successfully", "info", null);
                            $('#hfMonitor_id').val("");
                            $("#dgProjectMonitor").datagrid('reload');
                           
                        }
                        else {
                            $.messager.alert("info", msg, "info", null);
                        }


                    }
                });
            }
        }
    }
    else {
        $.messager.alert("info", "Please select one project monitor below.", "info", null);
    }
}

$.extend($.fn.validatebox.defaults.rules, {
    minNumber: {// 验证小数 
        validator: function (value) {
            return /^[\d]+\.?[\d]*$/i.test(value);
        },
        message: 'Please enter a valid number.'
    },
    integer: {// 验证整数 
        validator: function (value) {
            return /^[+]?[1-9]+\d*$/i.test(value);
        },
        message: 'Please enter a valid number.'
    }
});

function Remove() {
    var rows = $('#dgProjectMonitor').datagrid('getChecked');
    if (rows.length > 0) {
        var ids = [];
        for (var i = 0; i < rows.length; i++) {
            //每行ID放入数组中
            ids.push("'" + rows[i].PROJECT_MONITOR_ID + "'");
        }
        //必须为string类型，不然传不过去  
        var aa = ids.toString();
        $.ajax({
            type: "POST",
            url: "Person.ashx?M=DeleteMonitor&MonitorID=" + aa,
            success: function (data) {
                if (data != "") {
                    getdgProjectMonitor();
                    $.messager.alert("info", data, "info", null);
                }
            }
        });
    }
    else {
        $.messager.alert("info", "Please check the records to remove.", "info", null);
    }
}

function btnPM_edit() {
    var row = $('#dgProjectMonitor').datagrid('getSelected');
    if (row) {
        $('#w-PM_edit').click();
        $('#txtSigned_Quotation').datebox('setValue', row.Signed_Quotation);
        $('#txtKickoff').datebox('setValue', row.Kickoff);
        $('#txtRegister_Project').datebox('setValue', row.Register_Project);
        $('#txtTissue_Sent_Out').datebox('setValue', row.Tissue_Sent_Out);
        $('#txtFinal_Data_Sent_Out').datebox('setValue', row.Final_Data_Sent_Out);
        $('#txtDocument_Archieve').datebox('setValue', row.Document_Archieve);
        $('#txtReport_Sent_Out').datebox('setValue', row.Report_Sent_Out);
        $('#txtBalance_Invoice_Sent_Out').datebox('setValue', row.Balance_Invoice_Sent_Out);

     
    }
}
function SavePMedit() {
    if ($('#hfMonitor_id').val() != "") {
        var flag = true;
        $('#divPM_edit input').each(function () {
            if ($(this).attr('required') || $(this).attr('validType')) {
                if (!$(this).validatebox('isValid')) {
                    flag = false;
                    return;
                }
            }
        });
        if (!flag) {
            alert('Please fill out the missing info as indicated.');
            return false;
        }
        if (flag) {
            if (confirm('Are you confirm this?')) {
                $.ajax({
                    type: "POST",
                    dataType: "text",
                    url: "Person.ashx?M=SaveMonitorPM_edit",
                    data: "hfMonitor_id=" + $('#hfMonitor_id').val()
            + "&txtSigned_Quotation=" + $('#txtSigned_Quotation').datebox('getValue')
            + "&txtKickoff=" + $('#txtKickoff').datebox('getValue')
            + "&txtRegister_Project=" + $('#txtRegister_Project').datebox('getValue')
            + "&txtTissue_Sent_Out=" + $('#txtTissue_Sent_Out').datebox('getValue')
            + "&txtFinal_Data_Sent_Out=" + $('#txtFinal_Data_Sent_Out').datebox('getValue')
            + "&txtDocument_Archieve=" + $('#txtDocument_Archieve').datebox('getValue')
            + "&txtReport_Sent_Out=" + $('#txtReport_Sent_Out').datebox('getValue')
            + "&txtBalance_Invoice_Sent_Out=" + $('#txtBalance_Invoice_Sent_Out').datebox('getValue')
        ,
                    success: function (msg) {
                        if (msg == "") {
                            $.messager.alert("info", "Save successfully", "info", null);
                            $("#dgProjectMonitor").datagrid('reload');
                           
                            $.fancybox.close();
                        }
                        else {
                            $.messager.alert("info", msg, "info", null);
                        }
                    }
                });
            }
        }
    }
    else {
        $.messager.alert("info", "Please select one project monitor below.", "info", null);
    }
}

function btnComplete_study() {
    var row = $('#dgProjectMonitor').datagrid('getSelected');
    if (row) {
        if (row.Complete_Study != "Yes") {
            if (confirm('Are you confirm this? You must complete the study first!')) {
                $.ajax({
                    type: "POST",
                    dataType: "text",
                    url: "Person.ashx?M=Complete_study",
                    data: "hfMonitor_id=" + $('#hfMonitor_id').val(),
                    success: function (msg) {
                        if (msg == "") {
                            $.messager.alert("info", "Save successfully", "info", null);
                            $("#dgProjectMonitor").datagrid('reload');
                        }
                        else {
                            $.messager.alert("info", msg, "info", null);
                        }
                    }
                });
            }
        }
        else {
            $.messager.alert("info", "You can not edit completed study.", "info", null);
        }
    }
    
}

function btnJSD_edit() {
    var row = $('#dgProjectMonitor').datagrid('getSelected');
    if (row) {
        if (row.Complete_Study != "Yes") {
            $('#w-JSD_edit').click();
            $('#txtBooking_Animals').datebox('setValue', row.Booking_Animals);
            $('#txtOrder_Animal').datebox('setValue', row.Order_Animal);
            $('#txtFinalize_Protocol').datebox('setValue', row.Finalize_Protocol);

            //$('#txtProvide_Seeding_Animal').datebox('setValue', row.Provide_Seeding_Animal);
            $('#txtInoculation').datebox('setValue', row.Inoculation);
            $('#txtRandomization').datebox('setValue', row.Randomization);
            $('#txtTreatment_Start').datebox('setValue', row.Treatment_Start);
            $('#txtTreatment_Finished').datebox('setValue', row.Treatment_Finished);
            $('#txtObservation_Post_Treatment').datebox('setValue', row.Observation_Post_Treatment);
            $('#txtTissue_Collection').datebox('setValue', row.Tissue_Collection);

            var dates = new Array();
            if (data[0].Date_of_Deliver != null && data[0].Date_of_Deliver != "") {
                dates = data[0].Date_of_Deliver.split(";");
                for (i = 0; i < dates.length; i++) {
                    var txtid = "txtDeliver" + i;
                    $('#allDeliver').append(" <div id='div" + div_id + "'><input id='txtProvide_Seeding_Animal" + i + "' name=\"all_DeliverDate\" class=\"easyui-datebox\" data-options=\"formatter:myformatter\" editable=\"false\" /><input type='button' value = 'close' onclick='closeDate(\"div" + div_id + "\");'/></br></div>");
                    $.parser.parse('#allDeliver');
                    $("#" + txtid + "").datebox('setValue', dates[i]);
                    div_id++;
                }
            }
        }
        else {
            $.messager.alert("info", "You can not edit completed study.", "info", null);
        }
    }
}
function SaveJSDedit() {
    if ($('#hfMonitor_id').val() != "") {
        var flag = true;
        $('#divJSD_edit input').each(function () {
            if ($(this).attr('required') || $(this).attr('validType')) {
                if (!$(this).validatebox('isValid')) {
                    flag = false;
                    return;
                }
            }
        });
        if (!flag) {
            alert('Please fill out the missing info as indicated.');
            return false;
        }
        if (flag) {
            if (confirm('Are you confirm this?')) {
            
                $.ajax({
                    type: "POST",
                    dataType: "text",
                    url: "Person.ashx?M=SaveMonitorJSD_edit",
                    data: "hfMonitor_id=" + $('#hfMonitor_id').val()
            + "&txtBooking_Animals=" + $('#txtBooking_Animals').datebox('getValue')
            + "&txtOrder_Animal=" + $('#txtOrder_Animal').datebox('getValue')
            + "&txtFinalize_Protocol=" + $('#txtFinalize_Protocol').datebox('getValue')
            + "&txtProvide_Seeding_Animal=" + $('#txtProvide_Seeding_Animal').datebox('getValue')
            + "&txtInoculation=" + $('#txtInoculation').datebox('getValue')
            + "&txtRandomization=" + $('#txtRandomization').datebox('getValue')
            + "&txtTreatment_Start=" + $('#txtTreatment_Start').datebox('getValue')
            + "&txtTreatment_Finished=" + $('#txtTreatment_Finished').datebox('getValue')
            + "&txtObservation_Post_Treatment=" + $('#txtObservation_Post_Treatment').datebox('getValue')
            + "&txtTissue_Collection=" + $('#txtTissue_Collection').datebox('getValue')
        ,
                    success: function (msg) {
                        if (msg != "") {
                            $.messager.alert("info", msg, "info", null);
                            $("#dgProjectMonitor").datagrid('reload');
                            $.fancybox.close();
                        }
                    }
                });
            }
        }
    }
    else {
        $.messager.alert("info", "Please select one project monitor below.", "info", null);
    }
}


function SetStudyDesign() {
    if ($('#hfMonitor_id').val() != "") {

        getdgStudyDesign();
    }
    else {
        $.messager.alert("info", "Please select one project monitor below.", "info", null);
    }
}

function SetbtnCollection() {
    if ($('#hfMonitor_id').val() != "") {
        $('#w-collection').click();
    }
    else {
        $.messager.alert("info", "Please select one project monitor below.", "info", null);
    }
}
function SetbtnPersonnel() {
    if ($('#hfMonitor_id').val() != "") {
        $('#w-Personnel').click();
    }
    else {
        $.messager.alert("info", "Please select one project monitor below.", "info", null);
    }
}


function getdgStudyDesign() {
    var params = { hfMonitor_id: $('#hfMonitor_id').val()
    };
    $('#dgStudyDesign').datagrid('options').url = 'Getdatagrid.ashx?M=getdgStudyDesign';
    $("#dgStudyDesign").datagrid('reload', params);

}
function binddgStudyDesign() {
    $('#dgStudyDesign').datagrid({

        title: "Dosing Schedule",
        width: '800',
        height: '250',
        nowrap: false,
        striped: true,
        remoteSort: false,
        idField: 'PROJECT_MONITOR_STUDY_DESIGN_ID',
        pagination: true,
        rownumbers: true,
        singleSelect: false,
        pageSize: 10,
        pageList: [10, 20, 30],
        onLoadSuccess: function (data) {
            if ($('#dgStudyDesign').css('display') != "block") {
                $('#w-study').click();
                $('#txtImport').val("");
            }
        },
        frozenColumns: [[
             { field: 'ck', checkbox: true }
            ]],
        columns: [[

           { field: '_GROUP', title: 'Group', width: 80, sortable: false },
           { field: 'MICE_GROUP', title: 'Mice #/group', width: 100, sortable: false },
           { field: 'TYPE', title: 'Type', width: 100, sortable: false },
           { field: 'ARTICLE', title: 'Aricle', width: 100, sortable: false },
           { field: 'VEHICLE', title: 'Vehicle', width: 100, sortable: false },
           { field: 'DOSE_LEVEL', title: 'Dose_Level', width: 100, sortable: false },
           { field: 'UNIT', title: 'Unit', width: 100, sortable: false },
           { field: 'DOSING_ROUTE', title: 'Dosing Route', width: 200, sortable: false },
           { field: 'DOSING_SCHEDULE', title: 'Dosing Schedule', width: 100, sortable: false },
           { field: 'DOSING_PERIOD', title: 'Dosing Period', width: 100, sortable: false },
           { field: 'DOSE_RULE', title: 'Dose Rule', width: 200, sortable: false }
//           ,{ field: 'opt', title: '', align: 'left', width: 80,
//               formatter: function (value, rowData, rowIndex) {

//                   return "<a href='#' onclick='deleteStudy(&quot;" + rowData.PROJECT_MONITOR_STUDY_DESIGN_ID + "&quot;);'>delete</a>";

//               }
//           }
                 ]]
    });
    //设置分页控件属性  
    var p = $('#dgStudyDesign').datagrid('getPager');
    $(p).pagination({
        beforePageText: 'Page',
        afterPageText: 'of {pages}',
        displayMsg: 'Displaying {from} to {to} of {total} items'
    });
}



function DelStudy() {
    var rows = $('#dgStudyDesign').datagrid('getChecked');
    if (rows.length > 0) {
        if (confirm('Are you confirm this?')) {
            var ids = [];
            for (var i = 0; i < rows.length; i++) {
                //每行ID放入数组中
                ids.push(rows[i].PROJECT_MONITOR_STUDY_DESIGN_ID);
            }
            //必须为string类型，不然传不过去  
            var aa = ids.toString();
            $.ajax({
                type: "POST",
                url: "Person.ashx?M=deleteStudy&hfStudy_id=" + aa,
                success: function (data) {
                    if (data != "") {
                        $.messager.alert("info", data, "info", null);
                        $("#dgStudyDesign").datagrid('reload');
                        $('#dgStudyDesign').datagrid('clearChecked'); 
                    }
                }
            });
        }
    }
    else {
        $.messager.alert("info", "Please check the records to delete.", "info", null);
    }
    
}

function SaveStudy() {
    if ($('#hfMonitor_id').val() != "") {
        var flag = true;
        //        $('#dgStudy input').each(function () {
        //            if ($(this).attr('data-options') || $(this).attr('validType')) {
        //                if (!$(this).validatebox('isValid')) {
        //                    flag = false;
        //                    return;
        //                }
        //            }
        //        });
        if ($('#txtImport').val() == "") {
            flag = false;
        }
        if (!flag) {
            alert('Please fill out the missing info as indicated.');
            return false;
        }
        if (flag) {
            if (confirm('Are you confirm this?')) {
                //                var selectObj = document.getElementById('txtDosing_Route');
                //                var selectObj2 = document.getElementById('txtDosing_Schedule');
                $.ajax({
                    type: "POST",
                    dataType: "text",
                    url: "Person.ashx?M=SaveStudy",
                    data: "hfMonitor_id=" + $('#hfMonitor_id').val()
                    //            + "&txtGroup=" + $('#txtGroup').val()
                    //            + "&txtMice_group=" + $('#txtMice_group').val()
                    //            + "&txtDosing_Route=" + selectObj.options[selectObj.selectedIndex].text
                    //            + "&txtDosing_Route_Value=" + $('#txtDosing_Route').val()
                    //            + "&txtDosing_Schedule=" + selectObj2.options[selectObj2.selectedIndex].text
                    //            + "&txtDosing_Schedule_Value=" + $('#txtDosing_Schedule').val()
                    //            + "&txtDosing_Period=" + $('#txtDosing_Period').val(),
 + "&txtImport=" + $('#txtImport').val(),
                    success: function (msg) {
                        if (msg == "") {
                            $.messager.alert("info", "Save successfully", "info", null);
                            $("#dgStudyDesign").datagrid('reload');
                            $('#txtImport').val("");
                        }
                        else {
                            $.messager.alert("info", msg, "info", null);
                        }


                    }
                });
            }
        }
    }
}


function cbxToProject() {
    $('#cbxToProject').combobox({
        editable: true,
        url: 'GetGenedata.ashx?M=cbxToProject',
        valueField: 'id',
        textField: 'text',
        onSelect: function () {
            cbxToModelID();
        }
    })
    
}

function cbxToModelID() {
    $('#cbxToModelID').combotree({
        editable: false,
        url: 'GetGenedata.ashx?M=cbxToModelID&Project=' + $('#cbxToProject').combobox('getValue'),
        id: 'id',
        text: 'text'
    });
}
function MoveToModelID() {
    var cbxToProject = $('#cbxToProject').combobox('getValue');
    var cbxToModelID = $('#cbxToModelID').combotree('getValues');
    
    if (cbxToModelID!="") {
        if ($('#hfMonitor_id').val() != "") {
            if (confirm('Are you confirm this?')) {
                $.ajax({
                    type: "POST",
                    dataType: "text",
                    url: "Person.ashx?M=MoveToStudyDesign",
                    data: "Monitor_id=" + $('#hfMonitor_id').val() + "&cbxToModelID=" + cbxToModelID + "&cbxToProject=" + cbxToProject,
                    success: function (msg) {
                        if (msg != "") {
                            $.messager.alert("info", msg, "info", null);

                        }
                    }
                });
            }

        }
        else {
            $.messager.alert("info", "Please check the records to move.", "info", null);
        }
    }
    else {
        $.messager.alert("info", "Please select the Model ID to copy.", "info", null);
    }
}


function add_allDeliver() {
    $('#allDeliver').append(" <div id='div" + div_id + "'><input name=\"all_DeliverDate\" class=\"easyui-datebox\" data-options=\"formatter:myformatter\" editable=\"false\" /><input type='button' value = 'close' onclick='closeDate(\"div" + div_id + "\");'/></br></div>");
    $.parser.parse('#allDeliver');
    div_id++;
}

function add_allReceive() {
    $('#allReceive').append(" <div id='divTwo" + div_id_2 + "'><input name=\"all_ReceiveDate\" class=\"easyui-datebox\" data-options=\"formatter:myformatter\" editable=\"false\" /><input type='button' value = 'close' onclick='closeDate(\"divTwo" + div_id_2 + "\");'/></br></div>");
    $.parser.parse('#allReceive');
    div_id_2++;
}
