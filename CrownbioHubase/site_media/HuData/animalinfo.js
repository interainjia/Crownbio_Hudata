$(function () {

    getdgAnimalInfo();
    bigImg();
    autoSearch();
    autoColumns("animalinfo");
    autosearchAlive();
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

function autosearchAlive() {
    $('#searchAlive').combotree({
        editable: false,
        url: 'Person.ashx?M=getsearchAlive',
        id: 'id',
        text: 'text'
    });
}



function autoSearch() {
    $("#searchModelID").val("");
    $("#searchModelID").unautocomplete();
    $("#searchModelID").autocomplete("GetGenedata.ashx?M=AutoModelID", {
        extraParams: { key: function () { return $('#searchModelID').val(); }
        , cancertype: function () { return ''; }
         , subtype: function () { return ''; }
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
function getdgAnimalInfo() {
    var url = "Getdatagrid.ashx?M=getdgAnimalInfo";
    var params = {
        modelid: $('#searchModelID').val(),
        sort: $("#cbxSort").val(),
        searchAlive: $('#searchAlive').combotree('getValues').toString(),
//Cancertype: $('#searchCancertype').combobox('getValue')
//            , searchSubtype: $('#searchSubtype').combotree('getValues').toString()
//            , Revivable: $('#searchRevivable').combobox('getValue')
//            , fitforefficacy: $('#fitforefficacy').combobox('getValue'), cbx_isbooked: $('#cbx_isbooked').attr("checked")
//            , 
        rows: 20, page: 1
    };
    $.post(url, params, bindGrid, "json");
}



function bindGrid(data) {
    var options = {
        iconCls: 'icon-export',
        width: 'auto',
        height: 'auto',
        title: "Animal info",
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
//                                    { field: 'opt', title: '', align: 'left',
//                                        formatter: function (value, rowData, rowIndex) {

//                                            return "<a href='#' onclick='Viewbooking(&quot;" + rowData.PDXMODEL_INFO_ID + "&quot;);'>View</a>";
//                                        }
//                                    }
                  

                ]]
    };
    options.columns = eval(data.columns); //把返回的数组字符串转为对象，并赋于datagrid的column属性
    var dataGrid = $("#dgAnimalInfo");
    dataGrid.datagrid(options); //根据配置选项，生成datagrid
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
    $('#dgAnimalInfo').datagrid('getPager').pagination({
        displayMsg: 'Displaying {from} to {to} of {total} items',
        onSelectPage: function (pPageIndex, pPageSize) {
            //改变opts.pageNumber和opts.pageSize的参数值，用于下次查询传给数据层查询指定页码的数据   
            var gridOpts = $('#dgAnimalInfo').datagrid('options');
            gridOpts.pageNumber = pPageIndex;
            gridOpts.pageSize = pPageSize;

            var url = "Getdatagrid.ashx?M=getdgAnimalInfo";
            var params = { 
            modelid: $('#searchModelID').val(),sort: $("#cbxSort").val(),
            searchAlive: $('#searchAlive').combotree('getValues').toString(),
            // Cancertype: $('#searchCancertype').combobox('getValue')
//            , searchSubtype: $('#searchSubtype').combotree('getValues').toString()
//            , Revivable: $('#searchRevivable').combobox('getValue')
//            , fitforefficacy: $('#fitforefficacy').combobox('getValue'), cbx_isbooked: $('#cbx_isbooked').attr("checked")
//            , 
            rows: gridOpts.pageSize, page: gridOpts.pageNumber
            };
            $.post(url, params, pages, "json");
        }
    });
}
function pages(data) {
    //使用loadDate方法加载Dao层返回的数据   
    $('#dgAnimalInfo').datagrid('loadData', { "total": data.data[0].total, "rows": data.data[0].rows });
}
