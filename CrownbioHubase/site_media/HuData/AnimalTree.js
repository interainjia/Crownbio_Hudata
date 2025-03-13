var IDMark_A = "_a";

var setting = {
    data: {
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
        url: "GetGenedata.ashx?M=AnimalTree",
        autoParam: ["id", "pId", "name"],
        otherParam: ["Search", "false", "ModelID", $('#txtModelID').val(), "Rn", $('#txtRn').val(), "Pn", $('#txtPn').val()]
    },
    edit: {
        enable: true,
        showRemoveBtn: true,
        showRenameBtn: false
        //        ,showRemoveBtn: showRemoveBtn,
        //		showRenameBtn: showRenameBtn
    },
    view: {
				addDiyDom: addDiyDom
			},
    callback: {
		onClick: zTreeOnClick,
        onRemove:onRemove,
        beforeRemove: beforeRemove
	}
   
};
      
//		var zNodes =[
//			{ name: "LU3075", id: "0", count: 500, times: 1, isParent: true }
//            , { name: "LU3074", id: "0", count: 500, times: 1, isParent: true }
//		
//		];
			
        
        var log, className = "dark",
		startTime = 0, endTime = 0, perCount = 100, perTime = 100;

		function getUrl(treeId, treeNode) {
		    
		    var param;

		    var curCount = (treeNode.children) ? treeNode.children.length : 0;
		    var getCount = (curCount + perCount) > treeNode.count ? (treeNode.count - curCount) : perCount;

		    selectNode = treeNode;
		    var l = selectNode.level;
		    var tempnode;
		    if (selectNode.level != 0 && typeof(selectNode.level) != "undefined") {
		        for (var i = 0; i < l; i++) {
		            if (i == 0) {
		                tempnode = selectNode.getParentNode();
		            } else {
		                tempnode = tempnode.getParentNode();
		            }
		        }
		        // alert(tempnode.name); 找到根节点MODEL_ID

		    }
		    else {
		        tempnode = selectNode;
		    }
		    param ="Search="+"false"+ "&id=" + treeNode.id + "&name=" + tempnode.name
            + "&ModelID=" + $('#txtModelID').val() + "&Rn=" + $('#txtRn').val() + "&Pn=" + $('#txtPn').val();


		    return "GetGenedata.ashx?M=AnimalTree&" + param;
		}
//		function beforeExpand(treeId, treeNode) {
//			if (!treeNode.isAjaxing) {
//				startTime = new Date();
//				treeNode.times = 1;
//				ajaxGetNodes(treeNode, "refresh");
//				return true;
//			} else {
//				alert("zTree 正在下载数据中，请稍后展开节点。。。");
//				return false;
//			}
//		}
function zTreeOnClick(event, treeId, treeNode) {
    if (treeNode.level == "0") {
        gettbAnimalinfo_Logs("", treeNode.name);
        //showBWchart(treeNode.name);
    }

    if (treeNode.level == "4") {
        $('#hfAID').val(treeNode.id);
        //$.ajax({
        //    type: "POST",
        //    dataType: "json",
        //    url: "Getdatagrid.ashx?M=editModelTree",
        //    data: "editModelTree_ID=" + treeNode.id,
        //    success: function (data) {
        //        if (data.total>0) {
        //            $("#txtSerial").val(data.rows[0].SERIAL);
        //            $('#txtModel_Type').combobox('setValue', data.rows[0].MODEL_TYPE)
        //            $('#txtCancer_Type_Abbr').combobox('setValue', data.rows[0].CANCER_TYPE_ABBR)
        //            $('#txtSubtype1').combobox('setValue', data.rows[0].SUBTYPE1)
        //            $('#txtSubtype2').combobox('setValue', data.rows[0].SUBTYPE2)
        //            //$("#txtModel_ID").val(data.rows[0].Model_ID);
        //            $("#txtProject").combobox('setValue', data.rows[0].PROJECT);
        //            $('#txtLocation').combobox('setValue', data.rows[0].LOCATION)
        //            $('#txtOpreation').combobox('setValue', data.rows[0].OPREATION)
        //            $("#txtRn").val(data.rows[0].RN);
        //            $("#txtPn").val(data.rows[0].PN);
        //            $("#txtDate_of_Passage_inoculation").datebox('setValue', myformatter(data.rows[0].DATE_OF_PASSAGE_INOCULATION));
        //            $('#txtAnimal_Strain').combobox('setValue', data.rows[0].ANIMAL_STRAIN)
        //            $('#txtAnimal_Sex').combobox('setValue', data.rows[0].ANIMAL_SEX)
        //            $("#txtCurrent_Animal_Ear_Tag").val(data.rows[0].CURRENT_ANIMAL_EAR_TAG);
        //            $('#txtAnimal_Quantity').val(data.rows[0].ANIMAL_QUANTITY)
        //            $('#txtPDX_growth_status').combobox('setValue', data.rows[0].PDX_GROWTH_STATUS)
        //            $("#txtDate_of_Passage_Termination").datebox('setValue', myformatter(data.rows[0].DATE_OF_PASSAGE_TERMINATION));
        //            $('#txtSource_Hospital').combobox('setValue', data.rows[0].SOURCE_HOSPITAL)
        //            $("#txtPathology_info_available").combobox('setValue', data.rows[0].PATHOLOGY_INFO_AVAILABLE);
        //            $("#txtDate_of_Pathology_info_Received").datebox('setValue', myformatter(data.rows[0].DATE_OF_PATHOLOGY_INFO_RECEIVED));
        //            $("#txtPatient_No").val(data.rows[0].PATIENT_NO);
        //            $("#txtPatient_Name").val(data.rows[0].PATIENT_NAME);
        //            $("#txtPatient_Age").val(data.rows[0].PATIENT_AGE);
        //            $("#txtPatient_Sex").val(data.rows[0].PATIENT_SEX);
        //            $('#txtPathology_info_Qced').combobox('setValue', data.rows[0].PATIENT_PATHOLOGY_INFO_QCED)
        //            $("#txtComments").val(data.rows[0].COMMENTS);
        //        }
        //    }
        //});

        gettbAnimalinfo_Logs(treeNode.id,"");
    }
    // alert(treeNode.pId + ", " + treeNode.name);
}

		function onRemove(e, treeId, treeNode) {
		    $.ajax({
		        type: "POST",
		        dataType: "text",
		        url: "Person.ashx?M=Remove_ModelTree_Node",
		        data: "id=" + treeNode.id,

		        success: function (data) {
		            if (data != "") {
//		                var zTree = $.fn.zTree.getZTreeObj("treeDemo");
//		                var treeNodes = eval('(' + data + ')');
//		                $.fn.zTree.init($("#treeDemo"), setting, treeNodes);
//		                zTree.expandAll(true);
		            }

		        }
		    });
		}
		function beforeRemove(treeId, treeNode) {

		    var zTree = $.fn.zTree.getZTreeObj("treeDemo");
		    zTree.selectNode(treeNode);
		    return confirm("Are you confirm remove this?");
		}

	    function doSearch() {
	        // var zNodes1 = [{id:2,pId:0,"name":"LU3074","isParent": true},{id:221,pId:22,"name":"R2P2","isParent": true},{id:22,pId:2,"name":"R2P1","isParent": true}];

	        //"[{id:221,pId:22,'name':'R2P2','isParent': true},{id:22,pId:2,'name':'R2P1','isParent': true},{id:2,pId:0,'name':'LU3074','isParent': true}]"

	        $.ajax({
	            type: "POST",
	            dataType: "json",
	            url: "GetGenedata.ashx?M=AnimalTree",
	            data: { Search: "true", id: "", pId: "", name: "", ModelID: $('#txtModelID').val(), Rn: $('#txtRn').val(), Pn: $('#txtPn').val() },
	            success: function (zNodes1) {

	                if (zNodes1.length > 0) {
	                    $("#treeDemo").empty();
	                    $.fn.zTree.init($("#treeDemo"), setting, zNodes1);
	                    var treeObj = $.fn.zTree.getZTreeObj("treeDemo");
	                    var searhStr = "";
	                    if ($('#txtModelID').val() != "") {
	                        searhStr = $('#txtModelID').val();
	                    }
	                    if ($('#txtRn').val() != "")
	                    { searhStr = "R" + $('#txtRn').val(); }
	                    if ($('#txtPn').val() != "")
	                    { searhStr += "P" + $('#txtPn').val(); }
	                    //var nodes = treeObj.getNodesByParam("name", searhStr, null);
                        var nodes = treeObj.getNodesByParamFuzzy("name", searhStr, null);
                        
	                    if (nodes.length > 0) {
	                        treeObj.selectNode(nodes[0]);
	                    }
	                    else {
	                        alert("no model");
	                    }
	                }
	            }
	        });
	    }


	    $(function () {
	        bingCancerType();
	        bigImg();
	        bindGrid();
	    });

	    function bingCancerType() {
	        $('#tt1').tree({
	            checkbox: false,
	            lines: true,
	            url: 'GetGenedata.ashx?M=bingCancerType&pid=0',
	            onBeforeExpand: function (node, param) {
	                $('#tt1').tree('options').url = "GetGenedata.ashx?M=bingCancerType&pid=" + escape(node.id); // change the url   

	            },
	            onExpand: function (node, param) {
	                if ($('#hfCellline').val() != "") {
	                    var childnodes = $('#tt1').tree('getChildren', node.target);
	                    for (var j = 0; j < childnodes.length; j++) {
	                        if (childnodes[j].target.textContent == $('#hfCellline').val()) {
	                            $('#tt1').tree('select', childnodes[j].target);
	                        }
	                    }
	                    $('#hfCellline').val("");
	                }
	            },
	            onSelect: function (node) {
	                var fnode = $('#tt1').tree('getParent', node.target);
	                if (fnode != null) {
	                    $.ajax({
	                        type: "POST",
	                        dataType: "json",
	                        url: "GetGenedata.ashx?M=AnimalTree",
	                        data: { Search: "true", id: "", pId: "", name: "", ModelID: node.target.textContent, Rn: $('#txtRn').val(), Pn: $('#txtPn').val() },
	                        success: function (zNodes1) {

	                            if (zNodes1.length > 0) {
	                                $("#treeDemo").empty();
	                                $.fn.zTree.init($("#treeDemo"), setting, zNodes1);
	                                var treeObj = $.fn.zTree.getZTreeObj("treeDemo");
	                                var searhStr = "";
	                                if (node.target.textContent != "") {
	                                    searhStr = node.target.textContent;
	                                }
	                                if ($('#txtRn').val() != "")
	                                { searhStr = "R" + $('#txtRn').val(); }
	                                if ($('#txtPn').val() != "")
	                                { searhStr += "P" + $('#txtPn').val(); }
	                                var nodes = treeObj.getNodesByParam("name", searhStr, null);
	                                //treeObj.expandNode(nodes, true, true, true);
	                                if (nodes.length > 0) {
	                                    treeObj.selectNode(nodes[0]);
	                                }
	                                else {
	                                    alert("no model");
	                                }
	                            }
	                        }
	                    });
	                }

	            }

	        });
	    }

	   

function addDiyDom(treeId, treeNode) {
    if (treeNode.isParent) return;
    var aObj = $("#" + treeNode.tId + IDMark_A);

    var editStr = "<span class='demoIcon' id='diyBtn_" + treeNode.tId + "' title='Pharmacodynamics' onfocus='this.blur();'><span class='button icon02'></span></span>"
            + "<span class='demoIcon' id='diyBtn2_" + treeNode.tId + "' title='Maintain' onfocus='this.blur();'><span class='button icon02'></span></span>";
    aObj.after(editStr);
    var btn = $("#diyBtn_" + treeNode.tId);
    if (btn) btn.bind("click", function showProjectNumber() {
        $.ajax({
            type: "POST",
            dataType: "json",
            url: "Getdatagrid.ashx?M=getPharmacology_Effect",
            data: "hf_Pharmacology_Effect=" + treeNode.id,
            success: function (data) {
                $('#w_StudyNumber_edit').click();
                $('#hf_Pharmacology_Effect').val(treeNode.id);
                if (data.length > 0) {
                    $('#txtStudy_Number').val(data[0].STUDY_NUMBER);
                    $('#txtInoculation_Date').datebox('setValue', jsonDateFormat(data[0].INOCULATION_DATE));
                }
                else {
                    $('#txtStudy_Number').val("");
                    $('#txtInoculation_Date').datebox('setValue', "");
                }
            }
        });
    });

    var btn2 = $("#diyBtn2_" + treeNode.tId);
    if (btn2) btn2.bind("click", function showMaintain() {
        $.ajax({
            type: "POST",
            dataType: "json",
            url: "Getdatagrid.ashx?M=getMaintain",
            data: "hf_Maintain=" + treeNode.id,
            success: function (data) {
//                $('#w_StudyNumber_edit').click();
//                $('#hf_Pharmacology_Effect').val(treeNode.id);
//                if (data.length > 0) {
//                    $('#txtStudy_Number').val(data[0].STUDY_NUMBER);
//                    $('#txtInoculation_Date').datebox('setValue', jsonDateFormat(data[0].INOCULATION_DATE));
//                }
//                else {
//                    $('#txtStudy_Number').val("");
//                    $('#txtInoculation_Date').datebox('setValue', "");
//                }
            }
        });
    });
}

function SavePharmacology_Effect() {
    if ($('#hf_Pharmacology_Effect').val() != "") {
        var flag = true;
        $('#divStudyNumber_edit input').each(function () {
            if ($(this).attr('data-options') || $(this).attr('validType')) {
                if ($(this)[0].id != "txtInoculation_Date") {
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
        if (flag) {
            if (confirm('Are you confirm this?')) {
                $.ajax({
                    type: "POST",
                    dataType: "text",
                    url: "Person.ashx?M=SavePharmacology_Effect",
                    data: "hf_Pharmacology_Effect=" + $('#hf_Pharmacology_Effect').val()
            + "&txtStudy_Number=" + $('#txtStudy_Number').val()
            + "&txtInoculation_Date=" + $('#txtInoculation_Date').datebox('getValue'),
                    success: function (msg) {
                        if (msg == "") {
                            $.messager.alert("info", "Save successfully", "info", null);
                            $('#hf_Pharmacology_Effect').val("");
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

function bindGrid() {
    $('#tbAnimalinfo_Logs').datagrid({
        url: 'Getdatagrid.ashx?M=gettbAnimalinfo_Logs',
        iconCls: 'icon-export',
        width: 'auto',
        height: 'auto',
        title: "Animalinfo Logs",
        idField: 'ANIMAL_INFO_LOGS_ID',
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
        pageList: [10, 20, 30, 40, 1000],
        frozenColumns: [[
            { field: 'ck', checkbox: true },
            //{
            //    field: 'opt', title: 'chart', align: 'left', width: 80,
            //    formatter: function (value, rowData, rowIndex) {

            //        return "<a href='javascript:void();' onclick='showBWchart(&quot;" + rowData.MODEL_ID + "&quot;,&quot;" + rowData.ANIMAL_NUMBER + "&quot;);'>show</a>";

            //    }
            //},
                    { field: 'MODEL_ID', title: 'MODEL ID', width: 80, sortable: false }

                ]],
        columns: [[

          { field: 'DOI_F', title: 'DOI', width: 150, sortable: false },
          { field: 'RN', title: 'RN', width: 150, sortable: false },
           { field: 'PN', title: 'PN', width: 150, sortable: false },
            { field: 'LOCATION_OF_LIVE_ANIMAL', title: 'LOCATION_OF_LIVE_ANIMAL', width: 150, sortable: false },
             { field: 'ANIMAL_ROOM_NUMBER', title: 'ANIMAL_ROOM_NUMBER', width: 150, sortable: false },
              { field: 'IVC_LOCATION', title: 'IVC_LOCATION', width: 150, sortable: false },
               { field: 'ANIMAL_NUMBER', title: 'ANIMAL_NUMBER', width: 150, sortable: false },
                { field: 'BODY_WEIGHT', title: 'BODY_WEIGHT', width: 150, sortable: false },
                 { field: 'TVLB', title: 'TVLB', width: 150, sortable: false },
                  { field: 'TVLF', title: 'TVLF', width: 150, sortable: false },
                   { field: 'TVRF', title: 'TVRF', width: 150, sortable: false },
                    { field: 'TVRB', title: 'TVRB', width: 150, sortable: false },
                     { field: 'TV_AVG', title: 'TV_AVG', width: 150, sortable: false },
                       { field: 'TUMOR_NUMBER', title: 'TUMOR_NUMBER', width: 150, sortable: false },
                         { field: 'DATE_OF_UPDATE_F', title: 'DATE_OF_UPDATE', width: 150, sortable: false },
            { field: 'DURATION', title: 'DURATION', width: 150, sortable: false },      
            { field: 'MORTALITY_OBSERVATION', title: 'Mortality_Observation', width: 120, sortable: false },
            { field: 'CLINICAL_OBSERVATION', title: 'Clinical_Observation', width: 120, sortable: false },
                 ]]



    });

    //设置分页控件属性  
    var p = $('#tbAnimalinfo_Logs').datagrid('getPager');
    $(p).pagination({
        beforePageText: 'Page',
        afterPageText: 'of {pages}',
        displayMsg: 'Displaying {from} to {to} of {total} items'
    });
}

function gettbAnimalinfo_Logs(aid,mid) {
    var params = {
        aid: aid,
        mid: mid,
        S_DOI_from: $('#S_DOI_from').datebox('getValue'),
        S_DOI_to: $('#S_DOI_to').datebox('getValue'),
        S_Date_of_update_from: $('#S_Date_of_update_from').datebox('getValue'),
        S_Date_of_update_to: $('#S_Date_of_update_to').datebox('getValue'),
        S_Mortality_Observation: $('#S_Mortality_Observation').val()
    };
    $("#tbAnimalinfo_Logs").datagrid('reload', params);

}

var filter_date = function () {
    var treeObj = $.fn.zTree.getZTreeObj("treeDemo");
    var treeNodes = treeObj.getSelectedNodes();
    if (treeNodes.length > 0) {
        var treeNode = treeNodes[0];
        if (treeNode.level == "0") {
            gettbAnimalinfo_Logs("", treeNode.name);
         
        }
    }
}

//#region showBWchart
function showBWchart() {
    var rows = $('#tbAnimalinfo_Logs').datagrid('getChecked');
    var list = [];
    var mid = "";
    for (var i = 0; i < rows.length; i++) {
       
        list.push(rows[i].ANIMAL_NUMBER);
        mid = rows[0].MODEL_ID;
    }
    var a_num = list.toString();
    var data = [];
    var title = "";
    //Create Traces
    var Traces3_p_AUC = $.ajax({
        type: 'GET',
        dataType: "json",
        url: "GetHighCharts.ashx?M=showBWchart",
        data: { mid: mid, a_num: a_num },
    }).done(function (json) {
        if (json.length > 0) {
            var trace = {
                type: "scatter",
                x: json[0].x,
                y: json[0].y,
                text: json[0].animal,
                transforms: [{ type: "groupby", groups: json[0].animal }],
                hovertemplate:
                    "Duration: %{x}<br>" + "Body Weight: %{y}<br>" +
                    "Animal Number: %{text}<br>" +
                    "<extra></extra>"
            }
            data.push(trace);
        }
        //Format the layout
        var layout_moa_drug = {
            title: mid + ' Body Weight Curve',
            hovermode: 'closest',
            xaxis: {
                title: 'Days post inoculation',
                tickangle: 45
            },
            yaxis: {
                title: ' Body Weight(g)',
                tickangle: 45
            },
            height: 520,
            legend: {
                showlegend: false
            }
        };

        //get chart
        Plotly.newPlot('div_BWchart1', data, layout_moa_drug, config);
    });
    var config = { responsive: true }
}
//#endregion