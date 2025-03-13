$(function () {
    bigImg();
    autoColumns("request2");
    autoSearch();
    bindGrid();
    bindGrid2();
});
function htmlExport_old2() {
    var btn = document.getElementById('btnExport2');
    btn.click();
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

function getdgRequest() {

    var params = { searchSponsor: $('#searchSponsor').val(),
        searchAXcode: $('#searchAXcode').val(),
        searchProjectNumber: $('#searchProjectNumber').val(), searchBD: $('#searchBD').val(), searchSD: $('#searchSD').val(), searchPM: $('#searchPM').val()
        , searchModelID: $('#searchModelID').val()
        , searchSigned: $('#searchSigned').val()

    };
    $("#dgRequest").datagrid('load', params);

}

function bindGrid() {
    $('#dgRequest').datagrid({
        url: 'Getdatagrid.ashx?M=getdgRequest_Completed',
        iconCls: 'icon-export',
        width: 'auto',
        height: 'auto',
        title: "Completed Project",
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

                        
                         
                 ]]
                   , onClickRow: function (rowIndex, rowData) {
                       $('#hfRequest_id').val(rowData.REQUEST_ID);
                     
                       getdgProjectMonitor(rowData.REQUEST_ID);
                     
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
function bigImg() {
    if ($('.fancybox').length > 0) {
        $('.fancybox').fancybox({

    });
}
};
function doSearchMonitor() {
    getdgProjectMonitor($('#hfRequest_id').val());
}

function getdgProjectMonitor(request_id) {
    var params = { model_id: $('#searchModelID').val()
    , searchProjectNumber: $('#searchProjectNumber').val()
    , searchDOI: $('#searchDOI').val()
    , searchCompleted: $('#searchCompleted').val()
    , request_id: request_id
     , searchJSD: $('#searchJSD').val()
      , searchPM2: $('#searchPM2').val()
    };
    $("#dgProjectMonitor").datagrid('reload', params);
}

function bindGrid2() {
    $('#dgProjectMonitor').datagrid({
        url: 'Getdatagrid.ashx?M=getdgProjectMonitor&type=Completed',
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
                          //  { field: 'ck', checkbox: true },



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


                 ]]
                


    });
}

function longStr(value) {
    if (value.length > 15) {
        return "<a  title='" + value + "'" + ">" + value.substr(0, 15) + "..." + "</a>";
    }
    else {
        return value;
    }
}

function getAnimal_Handover(mid, rid, pdate) {
    $.ajax({
        type: "POST",
        dataType: "json",
        url: "Getdatagrid.ashx?M=getAnimal_Handover",
        data: "hfMid=" + mid + "&hfRid=" + rid
                    + "&pdate=" + pdate,
        success: function (data) {
            if (data.length > 0) {
               
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
                $('#txtDeliver').datebox('setValue', data[0].Date_of_Deliver);
                $('#lblReceivingProject').html(data[0].Receiving_Project);
                $('#lblJSD').html(data[0].JSD);
                $('#lblModelbatch2').html(data[0].Modelbatch2);
                $('#txtAlive').val(data[0].Healthy_and_Alive);
                $('#txtDead').html(data[0].Animal_Dead);
                $('#txtReceive').datebox('setValue', data[0].Date_of_Receive);
                $('#txtInoculation_Used').val(data[0].Inoculation_Used);
                $('#txtTissue').html(data[0].Tissue_Collection);
                $('#hfAnimal_Handover_mid').val(mid);
                $('#hfAnimal_Handover_rid').val(rid);

            }
        }
    });




}