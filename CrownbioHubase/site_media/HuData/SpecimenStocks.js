$(function () {
    $('#hfStocks_ID').val("-1");
    bigImg();
    binddgAnimal();
    AutoProject();
    bindGrid();
    ddl_bind();
    $.fn.zTree.init($("#treeDemo"), setting);
});
function htmlExport_old2() {
    var btn = document.getElementById('btnExport1');
    btn.click();
}

function ddl_bind() {
    $("#txtModel_ID").autocomplete("GetGenedata.ashx?M=AutoModel_ID", {
        extraParams: { key: function () { return $('#txtModel_ID').val(); } },
        minChars: 0, //自动完成激活之前填入的最小字符 
        width: 120, //提示的宽度，溢出隐藏
        max: 100,
        matchContains: true, //包含匹配，就是data参数里的数据，是否只要包含文本框里的数据就显示 
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

    //$("#searchModel_ID").autocomplete("GetGenedata.ashx?M=AutoModel_ID", {
    //    extraParams: { key: function () { return $('#searchModel_ID').val(); } },
    //    minChars: 0, //自动完成激活之前填入的最小字符 
    //    width: 120, //提示的宽度，溢出隐藏
    //    max: 100,
    //    matchContains: true, //包含匹配，就是data参数里的数据，是否只要包含文本框里的数据就显示 
    //    autoFill: false, //自动填充 
    //    parse: function (data) {
    //        return $.map(eval(data), function (row) {
    //            return {
    //                data: row,
    //                value: row.MODEL_ID,
    //                result: row.MODEL_ID
    //            }
    //        });
    //    },
    //    formatItem: function (data) { return data.MODEL_ID; }, //格式化选项
    //    formatResult: function (data) { return data.MODEL_ID; } //格式化选择结果
    //});

    $('#txtSite_of_Tissue_Collection').combobox({
        editable: false,
        url: 'Person.ashx?M=getDDLtxtSource&&ddlname=Site%20of%20Tissue%20Collection',
        valueField: 'id',
        textField: 'text'
    });
    $('#txtTissue_Type').combobox({
        editable: false,
        url: 'Person.ashx?M=getDDLtxtSource&&ddlname=Tissue%20Type',
        valueField: 'id',
        textField: 'text'
    });
    $('#txtPreserve_Method').combobox({
        editable: false,
        url: 'Person.ashx?M=getDDLtxtSource&&ddlname=Preserve%20Method',
        valueField: 'id',
        textField: 'text'
    });
    $('#txtTreatment_To_Mice').combobox({
        editable: false,
        url: 'Person.ashx?M=getDDLtxtSource&&ddlname=Treatment%20To%20Mice',
        valueField: 'id',
        textField: 'text'
    });
}

function bind_ModelID() {

}

function deleteStocks() {
    CheckIsRole_Edit(function (callback) {
        if (callback) {
            var rows = $('#dgSpecimenStocks').datagrid('getChecked');
            if (rows.length > 0) {
                if (confirm('Are you confirm this?')) {
                    var ids = [];
                    for (var i = 0; i < rows.length; i++) {
                        ids.push(rows[i].Specimen_Stock_ID);
                    }
                    var aa = ids.toString();
                    $.ajax({
                        type: "POST",
                        dataType: "text",
                        url: "Person.ashx?M=deleteSpecimenStocks",
                        data: "delSpecimen_Stock_ID=" + aa,
                        success: function (msg) {
                            if (msg != "") {
                                ShowMsg(msg);
                                $("#Reset1").click();
                                $('#hfStocks_ID').val("-1");
                                $("#dgSpecimenStocks").datagrid('reload');
                                $('#dgSpecimenStocks').datagrid('clearChecked');
                            }
                        }
                    });
                }
            }
            else {
                $.messager.alert("info", "Please check a specimen stock first.", "info", null);
            }
        }
    });
}

function deleteStocks2() {
    $.ajax({
        type: "POST",
        dataType: "text",
        url: "Person.ashx?M=deleteSpecimenStocks2",

        success: function (msg) {
            if (msg != "") {
                ShowMsg(msg);
                $("#Reset1").click();
                $('#hfStocks_ID').val("-1");
                $("#dgSpecimenStocks").datagrid('reload');
                $('#dgSpecimenStocks').datagrid('clearChecked');
            }
        }
    });
}
function getdgSpecimenStocks() {
    var msg = CheckIsRole_View(); // 同步获取权限信息

    if (!msg) {
        $.messager.alert("Error", "Failed to check permission.", "error");
        return;
    }

    var locationVal = $('#txtRegion').val(); // 默认用用户选的

    // 根据权限强制设置 S_Location
    if (msg.all === true) {
        locationVal = $('#txtRegion').val();
    }
    else if (msg.cbnc === true) {
        locationVal = "CBNC";
    }
    else if (msg.cbsd === true) {
        locationVal = "CBSD";
    }
    else if (msg.cbsg === true) {
        locationVal = "CBSG";
    }
    else {
        locationVal = "NA"; // 没有权限查看任何数据
    }

    var params = {
        model_id: $('#searchModel_ID').val()
        ,S_PojectNo: $('#S_PojectNo').val()
        //, S_Region: $('#S_Region').val()
        ,S_Region: locationVal
        ,S_Well_ID: $('#S_Well_ID').val()
        ,S_Location_ID: $('#S_Location_ID').val()
        ,S_Site_of_Tissue_Collection: $('#S_Site_of_Tissue_Collection').val()
        ,S_Preserve_Method: $('#S_Preserve_Method').val()
        ,S_Date_of_Tissue_Collection: $('#S_Date_of_Tissue_Collection').datebox('getValue')
        ,S_Animal_Number: $('#S_Animal_Number').val()
        ,S_Pn: $('#S_Pn').val()
        ,S_Tissue_Type: $('#S_Tissue_Type').val()
    };
    $("#dgSpecimenStocks").datagrid('load', params);
}

function bindGrid() {
    $('#dgSpecimenStocks').datagrid({
        url: 'Getdatagrid.ashx?M=getdgTissueStock',
        iconCls: 'icon-export',
        width: 'auto',
        height: 'auto',
        title: "Specimen Stocks",
        idField: 'Specimen_Stock_ID',
        fitColumns: false,
        singleSelect: true,
        nowrap: false,
        striped: true,
        selectOnCheck: false,
        checkOnSelect: false,
        remoteSort: true,
        pagination: true,
        rownumbers: true,
        pageSize: 10,
        pageList: [10, 20, 30, 40,1000],
        frozenColumns: [[
                            { field: 'ck', checkbox: true },
                    { field: 'Model_ID', title: 'Model_ID', width: 100, sortable: false },
                     { field: 'Rn', title: 'Rn', width: 80, sortable: false },
                      { field: 'Pn', title: 'Pn', width: 80, sortable: false },
                        { field: 'Region', title: 'Region', width: 80, sortable: false },
                ]],
        columns: [[
                       { field: 'Date_of_Inoculation', title: 'Date_of_Inoculation', width: 150, sortable: false, formatter: myformatter },
                      { field: 'Animal_Number', title: 'Animal_Number', width: 150, sortable: false },
                       { field: 'Total_Tumor_Volume', title: 'Total_Tumor_Volume', width: 200, sortable: false },
                        { field: 'Date_of_Tissue_Collection', title: 'Date_of_Tissue_Collection', width: 200, sortable: false, formatter: myformatter },
                      { field: 'Site_of_Tissue_Collection', title: 'Site_of_Tissue_Collection', width: 200, sortable: false },
                      { field: 'Tissue_Type', title: 'Tissue_Type', width: 100, sortable: false },
                      { field: 'Preserve_Method', title: 'Preserve_Method', width: 150, sortable: false },
                     { field: 'Treatment_To_Mice', title: 'Treatment_To_Mice', width: 150, sortable: false },
                       { field: 'Location_ID', title: 'Location_ID', width: 200, sortable: false,
                           formatter: function (value, rowData, rowIndex) {
                               return "<a href='javascript:void();' onclick='openStorgeMap(&quot;" + rowData.Location_ID + "&quot;);'>" + rowData.Location_ID + "</a>";
                           }
                       },
                      { field: 'Well_ID', title: 'Well_ID', width: 100, sortable: false },
                      { field: 'Import_Date', title: 'Import_Date', width: 100, sortable: false, formatter: myformatter },
                      { field: 'Import_Project_Number', title: 'Import_Project_Number', width: 150, sortable: false },
                       { field: 'STR', title: 'STR', width: 100, sortable: false }
        //                           , { field: 'opt1', title: '', align: 'left', width: 80,
        //                               formatter: function (value, rowData, rowIndex) {
        //                                   if (rowData.log_count != "") {
        //                                       return "<a href='#' onclick='getdgModifyRequest(&quot;" + rowData.REQUEST_ID + "&quot;);'>log</a>";
        //                                   }
        //                                   else {
        //                                       return "";
        //                                   }
        //                               }
        //                           }
                 ]]
                   , onClickRow: function (rowIndex, rowData) {

                       EditSpecimenStocks(rowData);
                       // getdgAnimal(rowData.Model_ID);

                   }


    });

    //设置分页控件属性  
    var p = $('#dgSpecimenStocks').datagrid('getPager');
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

function openStorgeMap(Location_ID) {
    if (window.parent.$('#tt').tabs('exists', 'Storage Maps')) {
        window.parent.updateTab('Storage Maps', '../HuData/StorageMaps.aspx?Location_id=' + Location_ID + '');
    }
    else {
        window.parent.addTab('Storage Maps', '../HuData/StorageMaps.aspx?Location_id=' + Location_ID + '');
    }
}


function btnGotoWithDraw() {
    if (confirm('Are you confirm this?')) {
        if ($('#txtProjectNumber').val() != "") {
            var rows = $('#dgSpecimenStocks').datagrid('getChecked');
            if (rows.length > 0) {
                var ids = [];
                for (var i = 0; i < rows.length; i++) {
                    //每行ID放入数组中
                    ids.push(rows[i].Specimen_Stock_ID);
                }
                //必须为string类型，不然传不过去  
                var aa = ids.toString();
                $.ajax({
                    type: "POST",
                    dataType: "text",
                    url: "Person.ashx?M=GotoWithDraw",
                    data: "id=" + aa + "&pn=" + $('#txtProjectNumber').val(),
                    success: function (data) {
                        if (data == "") {
                            $.messager.alert("info", "Withdraw successfully.", "info", null);
                            $('#dgSpecimenStocks').datagrid('clearChecked');
                        }
                        else {
                            $.messager.alert("info", data, "info", null);
                        }
                    }
                });
            }
            else {
                $.messager.alert("info", "Please check the records to import.", "info", null);
            }
        }
        else {
            $.messager.alert("info", "Please select the project number.", "info", null);
        }
    }
}


function AutoProject() {
    $("#txtProjectNumber").val("");
    $("#txtProjectNumber").unautocomplete();
    $("#txtProjectNumber").autocomplete("GetGenedata.ashx?M=AutoProject", {
        extraParams: { key: function () { return $('#txtProjectNumber').val(); }
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


function getdgAnimal() {
    var txtModel_ID = $('#txtModel_ID').val();
    if (txtModel_ID != "") {
        var params = { txtModel_ID: $('#txtModel_ID').val()
        };
        $('#dgAnimal').datagrid('options').url = 'Getdatagrid.ashx?M=getdgAnimal';
        $("#dgAnimal").datagrid('reload', params);
    }
    else {
        $.messager.alert('Warning', 'Please add model ID');
    }

}
function binddgAnimal() {
    $('#dgAnimal').datagrid({
        title: "Animal info",
        width: '800',
        height: '350',
        nowrap: false,
        striped: true,
        selectOnCheck: false,
        checkOnSelect: false,
        remoteSort: false,
        idField: 'ANIMAL_INFO_ID',
        pagination: true,
        rownumbers: true,
        singleSelect: true,
        pageSize: 10,
        pageList: [10, 20, 30],
        onLoadSuccess: function (data) {
            if ($('#dgAnimal').css('display') != "block") {
                $('#w-Animal').click();
            }
        },
        frozenColumns: [[
             { field: 'ck', checkbox: true }
            ]],
        columns: [[

           { field: 'RN', title: 'Rn', width: 80, sortable: false },
           { field: 'PN', title: 'Pn', width: 80, sortable: false },
           { field: 'DOI_F', title: 'Date of Inoculation', width: 150, sortable: false },
           { field: 'ANIMAL_NUMBER', title: 'Animal Number', width: 100, sortable: false },
           { field: 'LOCATION_OF_LIVE_ANIMAL', title: 'Animal Maintain Location', width: 150, sortable: false },
           { field: 'SOURCE_PROJECT', title: 'Import Project #', width: 150, sortable: false }

                 ]]
    });
    //设置分页控件属性  
    var p = $('#dgAnimal').datagrid('getPager');
    $(p).pagination({
        beforePageText: 'Page',
        afterPageText: 'of {pages}',
        displayMsg: 'Displaying {from} to {to} of {total} items'
    });
}

function btnSetAnimal() {
    var rows = $('#dgAnimal').datagrid('getChecked');
    if (rows.length == 1) {
        var ids = [];
        for (var i = 0; i < rows.length; i++) {
            //每行ID放入数组中
            ids.push(rows[i].ANIMAL_NUMBER);
        }
        var aa = ids.toString();
        $('#txtAnimal_number').val(aa);
        $.fancybox.close();
    }
    else {
        $.messager.alert("info", "Please select an Animal info.", "info", null);
    }
}

var CheckIsRole_View = function () {
    var result = null;
    $.ajax({
        type: "POST",
        dataType: "json",
        async: false, // 同步请求（不推荐，但可用）
        url: "Person.ashx?M=CheckIsRole_View&_modulepPge=Revival"
    }).done(function (msg) {
        result = msg; // 把结果存到外层变量
    });
    return result; // ✅ 现在可以正确返回
};

var CheckIsRole_Edit = function (callback) {
    var value;
    var a1 = $.ajax({
        type: "POST",
        dataType: "json",
        async: false,
        url: "Person.ashx?M=CheckIsRole_Edit&_modulepPge=SpecimenStocks"
    }).done(function (msg) {
        if (msg.all) {
            value = true;
        }
        else if (msg.cbsd && $('#txtRegion').val() != "CBSD") {
            $.messager.alert("info", "Permission Denied", "info", null);
            value = false;
        }
        else if (msg.cbnc && $('#txtRegion').val() != "CBNC") {
            $.messager.alert("info", "Permission Denied", "info", null);
            value = false;
        }
        else {
            value = true;
        }
        callback(value);
    });
}

function Save() {
    CheckIsRole_Edit(function (callback) {
        if (callback) {
            if (confirm('Are you confirm this?')) {
                var flag = true;
                $('#StocksImport input').each(function () {
                    if ($(this).attr('data-options') || $(this).attr('validType')) {
                        if ($(this)[0].id != "txtDate_of_Tissue_Collection" && $(this)[0].id != "txtImport_Date") {
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
                var rows = $('#dgAnimal').datagrid('getChecked');
                if (rows.length != 1) {
                    $.messager.alert("info", "Please select an Animal info.", "info", null);
                    return;

                }
                if (!flag) {//单个保存不满足
                    $.messager.alert("info", "Please fill out the missing info as indicated.", "info", null);
                }
                else {
                    var ids = [];
                    for (var i = 0; i < rows.length; i++) {
                        //每行ID放入数组中
                        ids.push(rows[i].ANIMAL_INFO_ID);
                    }
                    var aa = ids.toString();

                    $.ajax({
                        type: "POST",
                        dataType: "text",
                        url: "Person.ashx?M=Save_SpecimenStocks",
                        data: "hfStocks_ID=" + $('#hfStocks_ID').val()
                            + "&txtModel_ID=" + $('#txtModel_ID').val()
                            + "&txtDate_of_Tissue_Collection=" + $('#txtDate_of_Tissue_Collection').datebox('getValue')
                            + "&txtImport_Date=" + $('#txtImport_Date').datebox('getValue')
                            + "&txtSite_of_Tissue_Collection=" + $('#txtSite_of_Tissue_Collection').combobox('getValue')
                            + "&txtTissue_Type=" + $('#txtTissue_Type').combobox('getValue')
                            + "&txtPreserve_Method=" + $('#txtPreserve_Method').combobox('getValue')
                            + "&txtTreatment_To_Mice=" + $('#txtTreatment_To_Mice').combobox('getValue')
                            + "&txtLocation_ID=" + $('#txtLocation_ID').val()
                            + "&txtWell_ID=" + $('#txtWell_ID').val()
                            + "&txtSTR=" + $('#txtSTR').val()
                            + "&animal_id=" + aa
                        ,

                        success: function (msg) {
                            if (msg == "" || msg == "Send successfully.") {
                                $.messager.alert("info", "Save successfully.", "info", null);
                                $("#dgSpecimenStocks").datagrid('reload');
                                $("#Reset1").click();
                                $('#hfStocks_ID').val("-1");
                            }
                            else {
                                $.messager.alert("info", msg, "info", null);
                            }
                        }
                    });
                }
            }
        }
    });
}

function EditSpecimenStocks(row) {
    $('#hfStocks_ID').val(row.Specimen_Stock_ID);
    $("#txtModel_ID").val(row.Model_ID);
    $("#txtDate_of_Tissue_Collection").datebox('setValue', myformatter(row.Date_of_Tissue_Collection));
    $("#txtImport_Date").datebox('setValue', myformatter(row.Import_Date));
    $("#txtSite_of_Tissue_Collection").combobox('setValue', row.Site_of_Tissue_Collection);
    $("#txtTissue_Type").combobox('setValue', row.Tissue_Type);
    $("#txtPreserve_Method").combobox('setValue', row.Preserve_Method);
    $("#txtTreatment_To_Mice").combobox('setValue', row.Treatment_To_Mice);
    $("#txtLocation_ID").val(row.Location_ID);
    $("#txtWell_ID").val(row.Well_ID);
    $('#txtRegion').val(row.Region);
    $("#txtSTR").val(row.STR);

}

function getLocationID() {
    $('#w-Location').click();

}

function filter(treeId, parentNode, childNodes) {
    if (!childNodes) return null;
    for (var i = 0, l = childNodes.length; i < l; i++) {
        childNodes[i].name = childNodes[i].name.replace(/\.n/g, '.');
    }
    return childNodes;
}

function btnOK() {
    if ($('#selectWell_ID').combobox('getValue') != "") {
        var zTree = $.fn.zTree.getZTreeObj("treeDemo");
        var nodes = zTree.getSelectedNodes();
        $('#txtLocation_ID').val(nodes[0].id.split(';')[0]);
        $('#txtWell_ID').val($('#selectWell_ID').combobox('getValue'));
        $.fancybox.close();
    }
}

function zTreeOnClick(event, treeId, treeNode) {
    if (!treeNode.isParent) {
        $('#selectWell_ID').combobox({
            editable: false,
            url: 'GetGenedata.ashx?M=Locations_getWellID&id=' + treeNode.id,
            valueField: 'text',
            textField: 'text'
        });
    }
}

var setting = {
    data: {
        keep: {
            parent: true,
            leaf: true
        },
        key: {
            name: "name"
        },
        simpleData: {
            enable: true,
            idKey: "id",
            pIdKey: "pId"
        }
    },
    async: {
        enable: true,
        url: "GetGenedata.ashx?M=LocationID_Select",
        autoParam: ["id", "pId", "name"]
        , dataFilter: filter
        //,otherParam: ["Search", "false", "ModelID", $('#txtModelID').val(), "Rn", $('#txtRn').val(), "Pn", $('#txtPn').val()]
    },
    view: {
        //  addHoverDom: addHoverDom
    },

    callback: {
        onClick: zTreeOnClick




        //展开单层
            , beforeExpand: beforeExpand,
        onExpand: onExpand
    }

};


var curExpandNode = null;
function beforeExpand(treeId, treeNode) {
    var pNode = curExpandNode ? curExpandNode.getParentNode() : null;
    var treeNodeP = treeNode.parentTId ? treeNode.getParentNode() : null;
    var zTree = $.fn.zTree.getZTreeObj("treeDemo");
    for (var i = 0, l = !treeNodeP ? 0 : treeNodeP.children.length; i < l; i++) {
        if (treeNode !== treeNodeP.children[i]) {
            zTree.expandNode(treeNodeP.children[i], false);
        }
    }
    while (pNode) {
        if (pNode === treeNode) {
            break;
        }
        pNode = pNode.getParentNode();
    }
    if (!pNode) {
        singlePath(treeNode);
    }

}

function singlePath(newNode) {
    if (newNode === curExpandNode) return;
    if (curExpandNode && curExpandNode.open == true) {
        var zTree = $.fn.zTree.getZTreeObj("treeDemo");
        if (newNode.parentTId === curExpandNode.parentTId) {
            zTree.expandNode(curExpandNode, false);
        } else {
            var newParents = [];
            while (newNode) {
                newNode = newNode.getParentNode();
                if (newNode === curExpandNode) {
                    newParents = null;
                    break;
                } else if (newNode) {
                    newParents.push(newNode);
                }
            }
            if (newParents != null) {
                var oldNode = curExpandNode;
                var oldParents = [];
                while (oldNode) {
                    oldNode = oldNode.getParentNode();
                    if (oldNode) {
                        oldParents.push(oldNode);
                    }
                }
                if (newParents.length > 0) {
                    zTree.expandNode(oldParents[Math.abs(oldParents.length - newParents.length) - 1], false);
                } else {
                    zTree.expandNode(oldParents[oldParents.length - 1], false);
                }
            }
        }
    }
    curExpandNode = newNode;
}

function onExpand(event, treeId, treeNode) {
    curExpandNode = treeNode;
}
