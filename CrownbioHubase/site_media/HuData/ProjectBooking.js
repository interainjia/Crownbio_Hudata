$(function () {

    bindGrid();
    AutoProject();
    autoSearch();
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
function AutoProject() {
    $("#txtAnimalBooking").val("");
    $("#txtAnimalBooking").unautocomplete();
    $("#txtAnimalBooking").autocomplete("GetGenedata.ashx?M=AutoProject", {
        extraParams: { key: function () { return $('#txtAnimalBooking').val(); }
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
    $("#txtFurtherExpanding").val("");
    $("#txtFurtherExpanding").unautocomplete();
    $("#txtFurtherExpanding").autocomplete("GetGenedata.ashx?M=AutoProject", {
        extraParams: { key: function () { return $('#txtFurtherExpanding').val(); }
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
    $("#txtPN").val("");
    $("#txtPN").unautocomplete();
    $("#txtPN").autocomplete("GetGenedata.ashx?M=AutoProject", {
        extraParams: { key: function () { return $('#txtPN').val(); }
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

function getdgProjectBooking() {

    var params = { txtAnimalBooking: $('#txtAnimalBooking').val(), txtFurtherExpanding: $('#txtFurtherExpanding').val(),
        searchModelID: $('#searchModelID').val(), searchBD: $('#searchBD').val(), searchSD: $('#searchSD').val()
        , txtRevive: $('#txtRevive').val(), txtPN: $('#txtPN').val(), txtAnimal_Number: $('#searchAnimalNumber').val()
    };
    $("#dgProjectBooking").datagrid('load', params);

}
function bindGrid() {
    $('#dgProjectBooking').datagrid({
        url: 'Getdatagrid.ashx?M=getdgProjectBooking',
        iconCls: 'icon-export',
        width: 'auto',
        height: 'auto',
        title: "Project booking",
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
        // { field: 'ck', checkbox: true },
                             {field: 'Project_Number', title: 'Project Number', width: 150, sortable: false },
                    {field: 'Model_ID', title: 'MODEL ID', width: 150, sortable: false }

                ]],
        columns: [[
          { field: 'Animal_Number', title: 'Animal_Number', width: 150, sortable: false },
          { field: 'BD', title: 'BD', width: 150, sortable: false },
            { field: 'SD', title: 'SD(Leading SD)', width: 150, sortable: false },
            { field: 'JSD', title: 'JSD(Executive SD)', width: 150, sortable: false },
                { field: 'Animal_Booking', title: 'Animal_Booking', width: 200, sortable: false },
                  { field: 'Date_Of_Booking', title: 'Date_Of_Booking', width: 200, sortable: false },
                   { field: 'Further_Expanding', title: 'Further_Expanding', width: 200, sortable: false },
                  { field: 'Date_Of_Further_Expanding_Request', title: 'Date_Of_Further_Expanding_Request', width: 200, sortable: false },
                    { field: 'Revive', title: 'Revive', width: 200, sortable: false },
                  { field: 'Date_Of_Revive_Request', title: 'Date_Of_Revive_Request', width: 200, sortable: false }
                 ]]
                  


    });

    //设置分页控件属性  
    var p = $('#dgProjectBooking').datagrid('getPager');
    $(p).pagination({
        beforePageText: 'Page',
        afterPageText: 'of {pages}',
        displayMsg: 'Displaying {from} to {to} of {total} items'
    });
}