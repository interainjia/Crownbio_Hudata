$(function () {
    $('#hfPDXInfoID').val("-1");
    ddlbindSearch();
    //    bindGrid();
    getdgModelInfo();

    ddlSOC();
    $('#divPDXmodelImport').accordion({
        border: false
    });
    autoColumns("modelinfo");
    autoColumns2("animalinfo");
    bigImg();
});

function bigImg() {
    if ($('.fancybox').length > 0) {
        $('.fancybox').fancybox({
//            afterClose: function () {
//                if ($('#genegrid').length > 0) {
//                    $('#genegrid').datagrid('clearSelections');
//                    $('#genegrid').datagrid('clearChecked');
//                }
//            }
        });
    }
};

function htmlExport3() {
    $('#btnExport3').click();

}

function htmlExport2() {
    $('#w-exportCol2').click();

}
function autoColumns2(type) {
    $('#AvailableColumns2').combotree({
        editable: false,
        url: 'Person.ashx?M=hfAvailableColumns&Type=' + type,
        id: 'id',
        text: 'text'

    });
}
function ddlSOC() {
    $('#ddlSOC').combotree({
        editable: false,
        url: 'Person.ashx?M=getddlSOC',
        id: 'id',
        text: 'text'
        , onLoadSuccess: function () {
            if ($('#hfSOC').val() != "") {
                var arr = $('#hfSOC').val().split(",");
                $('#ddlSOC').combotree('setValues', arr);
            }
        }
    });
}
function ddlbindSearch() {
    $('#searchCancertype').combobox({
        editable: false,
        url: 'Person.ashx?M=getCancertype',
        valueField: 'id',
        textField: 'text'
//        ,onSelect: function () {
//            ddlSubtype();
//        }
//        ,onLoadSuccess: function () {
//            ddlSubtype();
//        }
    });
    $('#txtCancer_Type').combobox({
        editable: false,
        url: 'Person.ashx?M=getCancertype',
        valueField: 'id',
        textField: 'text'
//        ,onSelect: function () {
//            ddlSubtype();
//        }
        ,onLoadSuccess: function () {
            ddlSubtype();
        }
    });
    $('#txtModel_From').combobox({
        editable: false,
        url: 'Person.ashx?M=getDDLtxtSource&&ddlname=Model_From',
        valueField: 'id',
        textField: 'text'

    });
    $('#txtSource').combobox({
        editable: true,
        url: 'Person.ashx?M=getDDLtxtSource&&ddlname=Source',
        valueField: 'id',
        textField: 'text'

    });
    $('#txtOrigin').combobox({
        editable: false,
        url: 'Person.ashx?M=getDDLtxtSource&&ddlname=Origin',
        valueField: 'id',
        textField: 'text'

    });
    $('#txtModel_Category').combobox({
        editable: false,
        url: 'Person.ashx?M=getDDLtxtSource&&ddlname=Model%20Category',
        valueField: 'id',
        textField: 'text'

    });
    $('#txtCachexia_Label').combobox({
        editable: false,
        url: 'Person.ashx?M=getDDLtxtSource&&ddlname=Cachexia%20Label',
        valueField: 'id',
        textField: 'text'

    });
    $('#txtSurvival_Curve').combobox({
        editable: false,
        url: 'Person.ashx?M=getDDLtxtSource&&ddlname=Survival%20Curve',
        valueField: 'id',
        textField: 'text'

    });
    $('#txtSTR_Consistence').combobox({
        editable: false,
        url: 'Person.ashx?M=getDDLtxtSource&&ddlname=STR%20Consistence',
        valueField: 'id',
        textField: 'text'

    });
    $('#cbxSource').combobox({
        editable: true,
        url: 'Person.ashx?M=getDDLtxtSource&&ddlname=Source',
        valueField: 'id',
        textField: 'text'

    });
    $('#cbxSTR_Consistence').combobox({
        editable: true,
        url: 'Person.ashx?M=getDDLtxtSource&&ddlname=STR%20Consistence',
        valueField: 'id',
        textField: 'text'

    });
    $('#cbxModel_Category').combotree({
        editable: false,
        url: 'Person.ashx?M=cbxModel_Category-combotree',
        id: 'id',
        text: 'text'
    });
}
function ddlSubtype() {
    
    $('#searchSubtype1').combotree({
        editable: false,
        url: 'Person.ashx?M=getSubtype&Tumor_Type=' + $('#searchCancertype').combobox('getValue'),
        id: 'id',
        text: 'text',
        onCheck: function () {
            // autoSearch();
        }
    });
    $('#searchSubtype2').combotree({
        editable: false,
        url: 'Person.ashx?M=getSubtype2&Tumor_Type=' + $('#searchCancertype').combobox('getValue'),
        id: 'id',
        text: 'text',
        onCheck: function () {
            // autoSearch();
        }
    });
    $('#txtSubtype1').combobox({
        editable: false,
        url: 'Person.ashx?M=getSubtype-combobox&Tumor_Type=' + $('#txtCancer_Type').combobox('getValue'),
        valueField: 'id',
        textField: 'text'
    });
    $('#txtSubtype2').combobox({
        editable: false,
        url: 'Person.ashx?M=getSubtype2-combobox&Tumor_Type=' + $('#txtCancer_Type').combobox('getValue'),
        valueField: 'id',
        textField: 'text'
    });
  
}
function autoSearch() {
    $("#searchModelID").val("");
    $("#searchModelID").unautocomplete();
    $("#searchModelID").autocomplete("GetGenedata.ashx?M=AutoModelID", {
        extraParams: { key: function () { return $('#searchModelID').val(); }
        , cancertype: function () { return $('#searchCancertype').combobox('getValue'); }
         , subtype: function () { return $('#searchSubtype1').combotree('getValues').toString(); }
           , subtype2: function () { return $('#searchSubtype2').combotree('getValues').toString(); }
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

function updateTab1(name, url, rows) {
    if (window.parent.$('#tt').tabs('exists', 'Respond')) {
        var tab = window.parent.$('#tt').tabs('getTab', name);
        window.parent.$('#tt').tabs('update', {
            tab: tab,
            options: {
                title: name,
                content: "<iframe id = '" + name + "' scrolling='no' frameborder='0'  src='" + url + "?model_ids=" + rows + "'  style='width:100%;height:100%;'></iframe>",
                iconCls: 'icon-tab',
                closable: true
            }
        });
        window.parent.$('#tt').tabs('select', name);
    }
    else {
        window.parent.$('#tt').tabs('add', {
            title: name,
            content: "<iframe id = '" + name + "' scrolling='no' frameborder='0'  src='" + url + "?model_ids=" + rows + "' style='width:100%;height:100%;'></iframe>",
            iconCls: 'icon-tab',
            closable: true

        });
    }
}
function gotoRespond() {
    if (confirm('Are you confirm this?')) {
        var row = $('#dgModelInfo').datagrid('getSelected');
        var rows = $('#dgModelInfo').datagrid('getSelections');
        if (row) {
            
            var ids = "" ;
            for (var i = 0; i < rows.length; i++) {
                ids += rows[i].PDXMODEL_INFO_ID + ",";
            }
            updateTab1("Respond", "../HuData/Respond.aspx", ids);
        }
        else {
            $.messager.alert('Warning', 'Please select');
        }
    }
}
function getdgModelInfo() {
    
    var url = "Getdatagrid.ashx?M=getdgModelInfo";
    var params = { modelid: $('#searchModelID').val(), Cancertype: $('#searchCancertype').combobox('getValue')
            , searchSubtype1: $('#searchSubtype1').combotree('getValues').toString()
            , searchSubtype2: $('#searchSubtype2').combotree('getValues').toString()
            , cbxModel_Category: $('#cbxModel_Category').combotree('getValues').toString()
            , cbxSource: $('#cbxSource').combobox('getValue'), cbxModelstatus: $("#cbxModelstatus").val()
            , cbxPatient: $("#cbxPatient").val(), cbxPDX_QC: $("#cbxPDX_QC").val(), sort: $("#cbxSort").val()
          , cbxSource_Note: $("#cbxSource_Note").val()
           // , cbxTime_of_Revival: $("#cbxTime_of_Revival").val(), cbxTime_of_Model_for_Transplant: $("#cbxTime_of_Model_for_Transplant").val()
            , cbxSTR_Consistence: $('#cbxSTR_Consistence').combobox('getValue')
            , cbxDosing_Window: $("#cbxDosing_Window").val()
            , searchUlceration_Label: $("#searchUlceration_Label").val()
            , rows: 20, page: 1
    };
    $.post(url, params, bindGrid, "json");
}



function bindGrid(data) {
    var options = {
        iconCls: 'icon-export',
        width: 'auto',
        height: 'auto',
        title: "PDX Model Info",
        fitColumns: false,
        singleSelect: true,
        nowrap: false,
        striped: true,
        remoteSort: true,
        pagination: true,
        rownumbers: true,
        pageSize: 20,
        pageList: [20, 30, 40, 50],
        frozenColumns: [[
//                                { field: 'opt', title: '', align: 'left', width: 80,
//                                    formatter: function (value, rowData, rowIndex) {

//                                        return "<a href='#' onclick='EditPDXmodel(&quot;" + rowData.PDXMODEL_INFO_ID + "&quot;);'>Edit</a>";

//                                    }
//                                }
                ]]
                 , onClickRow: function (rowIndex, rowData) {
                     EditPDXmodel(rowData);
                 }
    };
    options.columns = eval(data.columns); //把返回的数组字符串转为对象，并赋于datagrid的column属性
    var dataGrid = $("#dgModelInfo");
    dataGrid.datagrid(options); //根据配置选项，生成datagrid
    var gridOpts = $('#dgModelInfo').datagrid('options');
    $('#dgModelInfo').datagrid('getPager').pagination({
        pageNumber: 1,
        pageSize: 20
    });
    dataGrid.datagrid("loadData", data.data[0]); //载入本地json格式的数据
   

    // { field: 'SQ_NUMBER', title: 'SQ_NUMBER', width: 110, sortable: false },
    //{ field: 'CANCER_TYPE_ABBR', title: 'CANCER_TYPE_ABBR', width: 100, sortable: false },
    //                      { field: 'ORIGIN', title: 'ORIGIN', width: 80, sortable: false },
    //                      { field: 'CANCER_TYPE', title: 'CANCER_TYPE', width: 100, sortable: false },
    //                      { field: 'SUBTYPE', title: 'SUBTYPE', width: 100, sortable: false },
    //                        { field: 'FIT_FOR_EFFICACY', title: 'FIT_FOR_EFFICACY', width: 110, sortable: false },
    //                      { field: 'POTENTIAL_FIT_FOR_EFFICACY', title: 'POTENTIAL_FIT_FOR_EFFICACY', width: 90, sortable: false },
    //                      { field: 'PATHOLOGY_INFO', title: 'PATHOLOGY_INFO', width: 150, sortable: false },
    //                      { field: 'CRYO_P', title: 'CRYO_P', width: 60, sortable: false },
    //                      { field: 'SNAP_FROZEN', title: 'SNAP_FROZEN', width: 70, sortable: false },
    //                      { field: 'FFPE', title: 'FFPE', width: 100, sortable: false },
    //                        { field: 'REVIVABLE', title: 'REVIVABLE', width: 60, sortable: false },
    //                        { field: 'STR_CONSISTANT', title: 'STR_CONSISTANT', width: 100, sortable: false },
    //                        { field: 'LYMPHOMA', title: 'LYMPHOMA', width: 100, sortable: false },
    //                        { field: 'MUTATION_PROFILING', title: 'MUTATION_PROFILING', width: 100, sortable: false },
    //                        { field: '_1S_GROWTH_CURVE', title: '_1S_GROWTH_CURVE', width: 100, sortable: false },
    //                         { field: '_4S_GROWTH_CURVE', title: '_4S_GROWTH_CURVE', width: 100, sortable: false },
    //                          { field: 'SOURCE', title: 'SOURCE', width: 100, sortable: false },
    //                            { field: 'MODEL_ON_HUBASE_2', title: 'MODEL_ON_HUBASE_2', width: 100, sortable: false }


    //                 , onBeforeLoad: function (data) {
    //                     $.ajax({
    //                         type: "POST",
    //                         dataType: "json",
    //                         url: "userLogin.ashx?M=CheckPDXmodel_Columns",
    //                         success: function (msg) {
    //                             for (var i = 0; i < msg.length; i++) {
    //                                 $('#dgModelInfo').datagrid('hideColumn', msg[i].HideColumn);
    //                             }
    //                         }
    //                     });
    //                 }



    //设置分页控件属性  
    //    var p = $('#dgModelInfo').datagrid('getPager');
    //    $(p).pagination({
    //    
    //        pageSize: 20,
    //        pageList: [20, 30, 40, 50],
    //        beforePageText: 'Page',
    //        afterPageText: 'of {pages}',
    //        displayMsg: 'Displaying {from} to {to} of {total} items'
    //    });
    $('#dgModelInfo').datagrid('getPager').pagination({
        displayMsg: 'Displaying {from} to {to} of {total} items',
        onSelectPage: function (pPageIndex, pPageSize) {
            //改变opts.pageNumber和opts.pageSize的参数值，用于下次查询传给数据层查询指定页码的数据   
            var gridOpts = $('#dgModelInfo').datagrid('options');
            gridOpts.pageNumber = pPageIndex;
            gridOpts.pageSize = pPageSize;
            
            var url = "Getdatagrid.ashx?M=getdgModelInfo";
            var params = { modelid: $('#searchModelID').val(), Cancertype: $('#searchCancertype').combobox('getValue')
            , searchSubtype1: $('#searchSubtype1').combotree('getValues').toString()
            , searchSubtype2: $('#searchSubtype2').combotree('getValues').toString()
            , cbxModel_Category: $('#cbxModel_Category').combotree('getValues').toString()
            , cbxSource: $("#cbxSource").val(), cbxModelstatus: $("#cbxModelstatus").val()
            , cbxPatient: $("#cbxPatient").val(), cbxPDX_QC: $("#cbxPDX_QC").val(), sort: $("#cbxSort").val()
            //, cbxTime_of_Revival: $("#cbxTime_of_Revival").val(), cbxTime_of_Model_for_Transplant: $("#cbxTime_of_Model_for_Transplant").val()
            , cbxSource_Note: $("#cbxSource_Note").val()
            , cbxSTR_Consistence: $("#cbxSTR_Consistence").val()
            , cbxDosing_Window: $("#cbxDosing_Window").val()
            , searchUlceration_Label: $("#searchUlceration_Label").val()
            , rows: gridOpts.pageSize, page: gridOpts.pageNumber
            };
            $.post(url, params, pages, "json");
        }
    });
}
function pages(data) {
    //使用loadDate方法加载Dao层返回的数据   
    $('#dgModelInfo').datagrid('loadData', { "total": data.data[0].total, "rows": data.data[0].rows });
}
function Viewbooking(PDX_id) {
    reloadBindGrid(PDX_id);
}

function reloadBindGrid(key) {
    $('#genegrid').datagrid('options').url = 'Getdatagrid.ashx?M=Viewbooking';
    var params = { key: key };
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
            idField: 'PROJECT_BOOKING_ID',
            pagination: true,
            rownumbers: true,
            pageSize: 10,
            pageList: [10, 20, 30],
            onLoadSuccess: function (data) {
                if (data.total > 0) {
                    if ($('#inline1').css('display') != "block") {
                        document.getElementById('ContinueNote').innerHTML = 'Project booking: ';
                        $('#w-searchGene').click();
                    }
                }
                else {
                    document.getElementById('lblnoResults').innerHTML = "No Project booking";
                    $('#no-results').click();
                }
            },
            columns: [[
                      { field: 'REQUEST_ID', title: 'Request ID', width: 100, sortable: false }
                      , { field: 'CONFIRM_DATE_F', title: 'Confirm Date', width: 100, sortable: false }
                      , { field: 'PROJECT_NUMBER', title: 'Project Number', width: 100, sortable: false }
                       , { field: 'POTENTIAL_STUDY_SIZE', title: 'Potential Study Size', width: 200, sortable: false }
                         , { field: 'CONTEXT', title: 'RnPn', width: 80, sortable: false }
                 ]]

        });

        //设置分页控件属性  
        var p = $('#genegrid').datagrid('getPager');
        $(p).pagination({
            beforePageText: 'Page',
            afterPageText: 'of {pages}',
            displayMsg: 'Displaying {from} to {to} of {total} items'
        });
    }
}

var Check = function () {
    if (confirm('Are you confirm this?')) {
        var flag = true;
        $('#form1 input').each(function () {
            if ($(this).attr('data-options') || $(this).attr('validType')) {
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
        else {
            save();
        }
    }
}

var save = function () {
    $.ajax({
        type: "POST",
        dataType: "text",
        url: "Person.ashx?M=SavePDXmodel",
        data: "hfPDXInfoID=" + $('#hfPDXInfoID').val()
            //+ "&txtLocation=" + $('#txtLocation').val()
            + "&txtSq_Number=" + $('#txtSq_Number').val() + "&txtCancer_Type_Abbr=" + $("#txtCancer_Type_Abbr").val()
            + "&txtModel_ID=" + $('#txtModel_ID').val() + "&txtModel_From=" + $('#txtModel_From').combobox('getValue') + "&txtOrigin=" + $('#txtOrigin').combobox('getValue')
            + "&txtCancer_Type=" + $('#txtCancer_Type').combobox('getValue') + "&txtSubtype1=" + $('#txtSubtype1').combobox('getValues')
            + "&txtSubtype2=" + $('#txtSubtype2').combobox('getValues')
            + "&txtModel_Category=" + $('#txtModel_Category').combobox('getValue') + "&txtSource_ID=" + $('#txtSource_ID').val()
            + "&txtSource_Note=" + $('#txtSource_Note').val()
            + "&txtPDX_QC=" + $('#txtPDX_QC').val()
            + "&txtSTR_Consistence=" + $('#txtSTR_Consistence').combobox('getValue')
            + "&txtIN_HUBA=" + $("#txtIN_HUBA").val()
            + "&txtExomeseq=" + $("#txtExomeseq").val()
            + "&txtTotal_Revival_Success_Rate=" + $("#txtTotal_Revival_Success_Rate").val()
            + "&txtTime_of_Revival=" + $("#txtTime_of_Revival").val()
            + "&txtRevival_Recommended_Strain=" + $("#txtRevival_Recommended_Strain").val()
            + "&txtTime_of_Model_for_Transplant=" + $("#txtTime_of_Model_for_Transplant").val()
            + "&txtMaintain_Recommended_Strain=" + $("#txtMaintain_Recommended_Strain").val()
            + "&txtSpareforCV40=" + $("#txtSpare_for_CV40").val()
            + "&txtSpareforCV30=" + $("#txtSpare_for_CV30").val()
            + "&txtOptimal_Overage=" + $("#txtOptimal_Overage").val()
            + "&txtDosing_Window=" + $("#txtDosing_Window").val()
            + "&txtCryo_P=" + $("#txtCryo_P").val()
            + "&txtcomments=" + $("#txtcomments").val()
            + "&txtSnap_Frozen=" + $("#txtSnap_Frozen").val()
            + "&txtFFPE=" + $("#txtFFPE").val()
            + "&txtHP2=" + $("#txtHP2").val()
            + "&txtUlceration_Label=" + $("#txtUlceration_Label").val()
            + "&txtTimes_Used_In_Study=" + $("#txtTimes_Used_In_Study").val()
            + "&txtCachexia_Label=" + $('#txtCachexia_Label').combobox('getValue')
            + "&txtCachexia=" + $("#txtCachexia").val()
            + "&txtSlight_BW_loss=" + $("#txtSlight_BW_loss").val()
            + "&txtNormal=" + $("#txtNormal").val()
            + "&txtSurvival_Curve=" + $('#txtSurvival_Curve').combobox('getValue')
            + "&ddlSOC=" + $('#ddlSOC').combotree('getText')
            + "&txtTotal_Revival_Success_Rate_CBSD=" + $("#txtTotal_Revival_Success_Rate_CBSD").val()
            + "&txtTime_of_Revival_CBSD=" + $("#txtTime_of_Revival_CBSD").val()
            + "&txtRevival_Recommended_Strain_CBSD=" + $("#txtRevival_Recommended_Strain_CBSD").val()
            + "&txtTreatment_history_1=" + $("#txtTreatment_history_1").val()
            + "&txtTreatment_history_2=" + $("#txtTreatment_history_2").val()
            + "&txtSource=" + $("#txtSource").combobox('getValue')
            + "&txtImplantation_Method=" + $("#txtImplantation_Method").val()
            + "&txtDeathRate=" + $("#txtDeathRate").val()
            + "&txtPatient_ID=" + $("#txtPatient_ID").val()
        ,
        success: function (msg) {
            if (msg != "") {
                $.messager.alert("info", msg, "info", null);
            }
            else {
                $.messager.alert("info", "Save successfully.", "info", null);
                AddPDXmodel();
                getdgModelInfo();
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
        url: "Person.ashx?M=CheckIsRole_Edit&_modulepPge=PDXModelInfo"
    }).done(function (msg) {
        if (msg.cbsd && $('#txtLocation').val() != "CBSD") {
            $.messager.alert("info", "Permission Denied", "info", null);
            value = false;
        }
        else if (msg.cbnc && $('#txtLocation').val() != "CBNC") {
            $.messager.alert("info", "Permission Denied", "info", null);
            value = false;
        }
        else {
            value = true;
        }
        callback(value);
    });
}

function EditPDXmodel(row) {
    $('#hfPDXInfoID').val(row.PDXMODEL_INFO_ID);
    //$('#txtLocation').val(row.Location);
    $('#txtSq_Number').val(row.Sq_Number);
    $('#txtCancer_Type_Abbr').val(row.Cancer_Type_Abbr);
    $('#txtModel_From').combobox('setValue', row.Model_From)
    $('#hfSource').val(row.Source);
    $('#txtModel_ID').val(row.Model_ID); 
    $('#txtPatient_ID').val(row.Patient_ID); //add by Jack, 2025.12.10
    $('#txtOrigin').combobox('setValue', row.Origin)
    $('#txtCancer_Type').combobox('setValue', row.Cancer_Type)
    $('#txtSubtype1').combobox('setValue', row.Subtype1)
    $('#txtSubtype2').combobox('setValue', row.Subtype2)
    $('#txtModel_Category').combobox('setValue', row.Model_Category)
    $('#txtSource_ID').val(row.Source_ID);
    $('#txtSource_Note').val(row.Source_Note);
    $('#txtPDX_QC').val(row.PDX_QC);
    $('#txtSTR_Consistence').combobox('setValue', row.STR_Consistence)
    $('#txtIN_HUBA').val(row.In_Huba);
    $('#txtExomeseq').val(row.Exomeseq);
    
    $('#txtTotal_Revival_Success_Rate').val(row.Total_Revival_Success_Rate);
    $('#txtTime_of_Revival').val(row.Time_of_Revival);
    $('#txtRevival_Recommended_Strain').val(row.Revival_Recommended_Strain);
    $('#txtTime_of_Model_for_Transplant').val(row.Time_of_Model_for_Transplant);
    $('#txtMaintain_Recommended_Strain').val(row.Maintain_Recommended_Strain);
    $('#txtSpare_for_CV40').val(row.Spare_for_CV40);
    $('#txtSpare_for_CV30').val(row.Spare_for_CV30);
    $('#txtOptimal_Overage').val(row.Optimal_Overage);
    $('#txtDosing_Window').val(row.Dosing_Window);
    $('#txtCryo_P').val(row.Cryo_P);
    $('#txtcomments').val(row.Comments);
    $('#txtSnap_Frozen').val(row.Snap_Frozen);
    $('#txtFFPE').val(row.FFPE1);
    $('#txtHP2').val(row.HP2);
    $('#txtUlceration_Label').val(row.Ulceration_Label);
    $('#txtTimes_Used_In_Study').val(row.Times_Used_In_Study);
    $('#txtCachexia_Label').combobox('setValue', row.Cachexia_Label);

    $('#txtCachexia').val(row.Cachexia);
    $('#txtSlight_BW_loss').val(row.Slight_BW_loss);
    $('#txtNormal').val(row.Normal);

    $('#txtSurvival_Curve').combobox('setValue', row.Survival_Curve);
    $('#hfSOC').val(row.SOC);

    $('#txtTotal_Revival_Success_Rate_CBSD').val(row.Total_Revival_Success_Rate_CBSD);
    $('#txtTime_of_Revival_CBSD').val(row.Time_of_Revival_CBSD);
    $('#txtRevival_Recommended_Strain_CBSD').val(row.Revival_Recommended_Strain_CBSD);

    $('#txtTreatment_history_1').val(row.Treatment_history_1);
    $('#txtTreatment_history_2').val(row.Treatment_history_2);
    $('#txtSource').combobox('setValue', row.Source);
    $('#txtImplantation_Method').val(row.Implantation_Method);
    $('#txtDeathRate').val(row.DeathRate);

    ddlSOC();
}

function AddPDXmodel() {
    $('#hfPDXInfoID').val("-1");
    $("#Reset1").click();
    ddlbindSearch();
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