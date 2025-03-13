/**
	domready action
**/
//window.addEvent('domready', function() {
//	buildTree('tree2');
//	SqueezeBox.assign($$('a.boxed'), {
//				parse: 'rel'
//			});
//	var element = document.getElements('input[class=cancertype]');
//	element.addEvent('click', function(e){
//				
//				var base_gene = document.getElement('input[id=base_gene]');
//				nodeName = this.get("name");
//				checked = this.get("checked");
//				changeStatus(checked,nodeName);
//				draw_compareable_barchart();
//	});
//	var tumormodels = document.getElements('input[class=tumormodel]');
//	tumormodels.addEvent('click', function(e){
//				var base_gene = document.getElement('input[id=base_gene]');
//				nodeName =  this.get("name");
//				changeFartherStatus(nodeName);
//				draw_compareable_barchart();
//			});
//	//auto complete for gene snp search
//	var inputWord_snp = document.getElement('input[id=searchField_snp_compare]');
//	new Autocompleter.Request.JSON(inputWord_snp, get_url("base_search_url")+'?type=json_list', {
//			'postVar': 'name',
//			'selectFirst': true,
//			'selectMode': true
//		});
		
//	$('compare_form').addEvent('submit', function(e) {
//							/**
//							 * Prevent the submit event
//							 */
//							new Event(e).stop();
//							var search_url = get_url("base_search_url")+"?type=json_list&t="+new Date();
//							var new_compare_obj=document.getElement("input[id=searchField_snp_compare]").value;
//							var obj_list_length = 1;
//							if(new_compare_obj!=null&&new_compare_obj!=''){
//									var jsonRequest = new Request.JSON({url: search_url, onSuccess: function(gene_list){
//												var g_list = gene_list; //JSON.decode(gene_list);
//												obj_list_length = g_list.length;
//												if(obj_list_length > 1){
//													var result_content;
//													var req_url = get_url("base_search_url")+'?source=chart&type=html_choice&name='+new_compare_obj;
//													var jsonRequest = new Request.HTML({url: req_url, onSuccess: function(responseTree, responseElements, responseHTML, responseJavaScript){
//														result_content = new Element('div', {
//																html: responseHTML
//															});
//														SqueezeBox.open(result_content, {handler: 'adopt',size: {x: 800, y: 320}});
//													}}).get();
//										
//												}
//												if(obj_list_length == 1){
//													
//														new_compare_obj = g_list[0]; //(g_list.value.split(','))[0];
//														append_obj_tag(new_compare_obj);
//														submit_compareable_bar_chart_form(new_compare_obj,'ajax',false);
//													
//												}
//												
//												
//												}}).get({'name':new_compare_obj});
//												
//							}
//						
//							
//		});
		
//});
function get_url(type){
        var url = "";
        if(type == "base_url"){
			url = document.getElement('input[id=base_url]').value;
		}
		else if(type == "base_search_url"){
			url = document.getElement('input[id=base_search_url]').value;
		}
		else if(type == "base_chart_url"){
			url = document.getElement('input[id=base_chart_url]').value;
		}
		
		return url;
}

/**
	draw compareable bar chart 
**/
function draw_compareable_barchart_CN() {
    var compareobj_list = $('#compared_objects_list');
    var mutli = "true";

    //    if (compareobj_list != null && compareobj_list.val().length > 0) {
    //        compareobj_list_str = compareobj_list_str + ',' + compareobj_list.val();
    //    }
    if ($('#hftarget').length > 0) {
        if (compareobj_list.length == 0) {
            getShow_CN_Multi($('#hftarget').val(), "");
        }
        else {
            getShow_CN_Multi($('#hftarget').val(), mutli);
        }
    }
    else {
        var types = $(".selected")[0].id;
        if (compareobj_list.length == 0) {
            getShow_CN_Multi(types, "");
        }
        else {
            getShow_CN_Multi(types, mutli);
        }
    }
}
function draw_compareable_barchart() {
    var compareobj_list = $('#compared_objects_list');
    var mutli = "true";

//    if (compareobj_list != null && compareobj_list.val().length > 0) {
//        compareobj_list_str = compareobj_list_str + ',' + compareobj_list.val();
    //    }
    if (compareobj_list.length == 0) {
        getShow("");
    }
    else {
        getShow(mutli);
    }

}
function draw_compareable_barchart_MU() {
    var compareobj_list = $('#compared_objects_list');
    var mutli = "true";
    var cbx = "";
    if ($('#cbxtype').length > 0) {
        var data = $('#cbxtype').combobox('getValues');
        cbx = data.join(",");
    }
    if (compareobj_list.length == 0) {
        getShow("", cbx, "");
    }
    else {
        getShow(mutli, cbx, "");
    }
}
function draw_compareable_barchart_MU_Validated() {
    var compareobj_list = $('#compared_objects_list');
    var mutli = "true";
    if (compareobj_list.length == 0) {
        getShow2("");
    }
    else {
        getShow2(mutli);
    }

}
function draw_compareable_barchart_GF() {
    var compareobj_list = $('#compared_objects_list');
    var mutli = "true";
    if (compareobj_list.length == 0) {
        getShow("");
    }
    else {
        getShow(mutli);
    }

}
function draw_compareable_barchart_GNRNA() {
    var compareobj_list = $('#compared_objects_list');
    var mutli = "true";
    if (compareobj_list.length == 0) {
        getShow("");
    }
    else {
        getShow(mutli);
    }

}
function update_urls(url_data_part){
	var open_in_window = document.getElementById('open_in_window');
	if (open_in_window != null) {
		open_in_window.set('name', get_url("base_url")+"?popup=true&"+url_data_part);
	}
	var export_csv_url = document.getElementById('export_csv_url');
	if (export_csv_url != null) {
		export_csv_url.href = get_url("base_chart_url") + "?exportcsv=1&" +
								url_data_part;
	}
}



function check_object_box() {
	var gene_tag_box =$('div[id=compare_gene_box]');
	var children = gene_tag_box.children();
	if (children.length == 0){
		   $('#select_gene_info_box').css('display','none');
	}
	else{
		   $('#select_gene_info_box').css('display','block');
	}
}



function closeAll_tag_action() {
    var compared_objects_list = $('input[id=compared_objects_list]');
    compared_objects_list.val('');
    var gene_tag_box = $('div[id=compare_gene_box]');
    gene_tag_box.children().remove();
    $('#select_gene_info_box').css('display', 'none');
    $('#Searchdata').val("");
    $('#genegrid').datagrid('clearSelections');
}

function Continue_Addselect() {
    var selected = $('#genegrid').datagrid('getSelections');
    if (selected.length > 0) {
        $.fancybox.close();
        $.each(selected, function (key, val) {
            var compareobj_list = $('#compared_objects_list').val().split(',');
            if ($.inArray(val.MODEL_ID, compareobj_list) == "-1") {//不包含数组里
                append_obj_tag_miRNA(val.MODEL_ID);
                submit_compareable_bar_chart_form_miRNA(val.MODEL_ID, 'ajax', false);
            }
        });
    }
}
function One_Addselect(MODEL_ID) {
    var compareobj_list = $('#compared_objects_list').val().split(',');
    if ($.inArray(MODEL_ID, compareobj_list) == "-1") {//不包含数组里
        append_obj_tag_miRNA(MODEL_ID);
        submit_compareable_bar_chart_form_miRNA(MODEL_ID, 'ajax', false);
    }
}
function append_obj_tag_miRNA(gene_name) {
    var holder = $('.compare_gene_box');
    var compare_gene = $("<div id='" + gene_name + "' name='compare_gene' class='gene_tag'></div>");
    var compare_gene_name = $("<div class='compare_gene_name' title='gene_name'></div>");
    var gene_close = $("<a id='close_" + gene_name + "' name='gene_close' class='gene_close' title='Remove this gene'></a>");
    gene_close.append('×');
    compare_gene_name.append(gene_name);
    compare_gene.append(gene_close);
    compare_gene.append(compare_gene_name);
    holder.append(compare_gene);
    gene_close.bind('click', close_tag_action_miRNA);
    check_object_box();
}

function submit_compareable_bar_chart_form_miRNA(new_selected_gene, action_type, colse_w) {
    var compareobj_list = $('input[id=compared_objects_list]');
    temp_compareobj_list_str = compareobj_list.val() + ',' + new_selected_gene
    compareobj_list.val(temp_compareobj_list_str);
    if (colse_w) {
        $('select_snp_gene').retrieve('instance').close();
    }
    var compareobj_list = $('#compared_objects_list');
    var compareobj_list_str = "";
    if (compareobj_list != null && compareobj_list.val().length > 0) {
        compareobj_list_str = compareobj_list_str + ',' + compareobj_list.val();
    }
    $('#Searchdata').val(compareobj_list_str);
}
function close_tag_action_miRNA() {
    var compared_objects_list = $('input[id=compared_objects_list]');
    var gene_tag = $(this).parent();
    var compared_objects_list_str = compared_objects_list.val();
    var new_compared_objects_list_str = compared_objects_list_str.indexOf(',') != -1 ? compared_objects_list_str.replace(',' + gene_tag.attr('id'), '') : compared_objects_list_str.replace(gene_tag.attr('id'), '');
    compared_objects_list.val(new_compared_objects_list_str);
    gene_tag.remove();
    check_object_box()
    var compareobj_list = $('#compared_objects_list');
    var compareobj_list_str = "";
    if (compareobj_list != null && compareobj_list.val().length > 0) {
        compareobj_list_str = compareobj_list_str + ',' + compareobj_list.val();
    }
    $('#Searchdata').val(compareobj_list_str);
}
function autoCheckbox() {
    if ($('#compared_objects_list').length > 0) {
        var compareobj_list = $('#compared_objects_list').val().split(',');
        $.each(compareobj_list, function (key, val) {
            $('#genegrid').datagrid('selectRecord', val);
        });
    }
}
