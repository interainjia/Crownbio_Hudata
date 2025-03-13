// framework actions

var resizeTimer;
window.onresize = function () {
    clearTimeout(resizeTimer);
    setTimeout("pageResizeHandler()", 300);
}
$(function () {
    pageResizeHandler();
    bigImg();
})


function pageResizeHandler() {
    if (document.getElementById("div_middle") != null) {
        var boddorHeight = document.getElementById("div_middle").clientTop * 2;
        var heightValue = document.body.clientHeight - document.getElementById("div_top").offsetHeight - boddorHeight; // 
        if (document.getElementById("div_bottom")) {
            heightValue -= document.getElementById("div_bottom").offsetHeight;
        }
        document.getElementById("div_middle").style.height = (heightValue - 40).toString() + "px";
        document.getElementById("div_body").style.pixelHeight = heightValue - document.getElementById("div_borderTop").offsetHeight - 32;
    }
}

function hideLeft() {
    var div_left = document.getElementById("div_left")
    div_left.style.display = (div_left.style.display == "none") ? "block" : "none";
}
//end framework actions
//input field actions
function cls(oSource, str) {
    with (oSource)
        if (value == str) value = "";
}
function res(oSource, str) {
    with (oSource)
        if (value == "") value = str;
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
function htmlExport1(fname) {
    $.ajax({
        type: "POST",
        dataType: "text",
        url: "UserFunction.ashx?M=CheckExport&fname=" + fname,
        success: function (results) {
            if (results != "0") {
                var objBtn = document.getElementById('btnExport1');
                objBtn.click();
            }
            else {
                alert('You do not have permission to export this data.');
            }
        }
    })

}

function selectSource(type) {
    if (type == "single") {
        $('#single-window').click();
    }
    else {
        $('#multi-window').click();
    }
}
function goto1() {
    addTab('Microarray GeneExpression(Single Gene)', '../HuBase/gene.aspx');
    $.fancybox.close();
}
function goto2() {
    addTab('RNAseq GeneExpression(Single Gene)', '../HuBase/geneExpressionRNA.aspx');
    $.fancybox.close();
}
function goto3() {
    addTab('Microarray GeneExpression(Multiple Genes)', '../HuBase/geneMulti.aspx')
    $.fancybox.close();
}
function goto4() {
    addTab('RNAseq GeneExpression(Multiple Genes)', '../HuBase/geneExpressionRNAMulti.aspx')
    $.fancybox.close();
}
function AddtoModelTree(treetype) {
    var cln = $('#txtCellline').val();
    if (cln != "") {
        $.ajax({
            type: "POST",
            dataType: "json",
            url: "GetCelllineType.ashx?M=AddtoModelTree&treetype=" + treetype + "&cln=" + cln,
            success: function (results) {
                if (results != "") {
                    var fnode = $('#tree_right').tree('getRoots');
                    $('#tree_right').tree('collapseAll', fnode.target);
                    for (var i = 0; i < fnode.length; i++) {
                        if (fnode[i].id == results[0][0]) {
                            $('#tree_right').tree('expand', fnode[i].target);
                            $('#hfautocell').val(cln);
                        }
                    }
                }
            }
        })
    }
}
//end input field actions
//search gene by  type a string
function get_gene2() {
    OnloadTree_right();
}
function get_gene3() {
    OnloadTree_right_CN();
}
function Redirect_gene() {
    if ($('#search_gene').val() != "" && $('#search_gene').val() != "Expression profiling") {
        window.location.href = "gene.aspx?Gene=" + $('#search_gene').val() + "&type=" + $('input:radio[name="gn"]:checked').attr('id');
    }
    else {
        alert('Please add Gene.');
    }
}
function Redirect_cn() {
    if ($('#search_gene_snp').val().length > 1 && $('#search_gene_snp').val() != "Genome SNP") {
        reloadBindGrid_out($('#search_gene_snp').val());
    }
}
function Redirect_Model() {
    window.location.href = "huprime.aspx?Cln=" + $('#searchtype_tumor').val();
}
function Get_Model() {
    $('#hfCellline').val($('#searchtype_tumor').val());
    AddSelect();
}


function addtoGene_click() {
    document.getElementById("compared_objects_list").value += "," + $("#search_gene").val();
}
function removelist_click() {
    document.getElementById("compared_objects_list").value = "";
}

function addtoGene_click_CN() {
    document.getElementById("compared_objects_list").value += "," + $("#search_gene_snp").val();
}


function getCompareWindow() {
    if ($('#searchField_snp_compare_CN').val().length > 1) {
        reloadBindGrid_compare($('#searchField_snp_compare_CN').val());
    }
}
function getGeneInfo_CN_PennCNV() {
    if ($('#Searchdata').val() != "") {
        var objBtn = document.getElementById('btnGetGeneInfo_CN_PennCNV');
        objBtn.click();
    }
}
function getGeneInfo_CN_Picnic() {
    if ($('#Searchdata').val() != "") {
        var objBtn = document.getElementById('btnGetGeneInfo_CN_Picnic');
        objBtn.click();
    }
}
function Continue_single() {
    var selected = $('#genegrid').datagrid('getSelected');
    if (selected) {
        $.fancybox.close();
        $('#search_gene').val(selected.GeneName);
        $('#Searchdata').val(selected.GeneName);
        var objBtn = document.getElementById('btnGetGeneInfo');
        objBtn.click();

    }
}
function Continue_in() {
    var selected = $('#genegrid').datagrid('getSelected');
    if (selected) {
        $('#search_gene_snp').val(selected.GeneName);
        $('#Searchdata').val(selected.GeneName);
        $.fancybox.close();
        $('#activity_pane').showLoading({ 'addClass': 'loading-indicator-bars' });
        $.ajax({
            type: "POST",
            dataType: "text",
            url: "CopyNumber.aspx?loading=" + selected.GeneName,
            success: function (results) {
                $('#activity_pane').hideLoading();
                var objBtn = document.getElementById('btnGetGeneInfo');
                objBtn.click();
            }
        });
       
    }   
}
function Continue_out() {
    var selected = $('#genegrid').datagrid('getSelected');
    if (selected) {
        $.fancybox.close();
        $('#activity_pane').showLoading({ 'addClass': 'loading-indicator-bars' });
        $.ajax({
            type: "POST",
            dataType: "text",
            url: "CopyNumber.aspx?loading=" + selected.GeneName,
            success: function (results) {
                window.location.href = "CopyNumber.aspx?CN=" + selected.GeneName;
            }
        });
    }
}
function Continue_Compare() {
    var selected = $('#genegrid').datagrid('getSelected');
    if (selected) {
        $('#searchField_snp_compare_CN').val(selected.GeneName);
        $.fancybox.close();
        append_obj_tag_CN(); submit_compareable_bar_chart_form_CN('ajax', false); 
    }
}

function get_gene(element_id, type, next) {
    var base_url = "/hubase/gene/";
    var search_url = "/hubase/searchgene/?type=json_list&t=" + new Date();
    var search_source = "tree";
    var gene_symbol = "";
    var search_gene = null;
    // if the type is 'radio' the window.location will direct to the target url
    if (type == 'radio') {
        search_gene = $(document.body).getElement('input[name=' + element_id + ']:checked').value;
        var target_url = base_url + "?search_term=" + search_gene;
        window.location.href = target_url;
    }
    else {
        search_gene = $(document.body).getElement('input[id=' + element_id + ']').value;
    }
    var jsonRequest = new Request.JSON({ url: search_url, onSuccess: function (gene_list) {
        var g_list = gene_list; //JSON.decode(gene_list);
        gene_list_length = g_list.length; //g_list.size;
        //if more then one results found, it will pop-up a results list , user should select one to continue
        if (gene_list_length > 1) {
            var result_content;
            var req_url = '/hubase/searchgene/?source=' + search_source + '&name=' + search_gene;
            var jsonRequest = new Request.HTML({ url: req_url, onSuccess: function (responseTree, responseElements, responseHTML, responseJavaScript) {
                result_content = new Element('div', {
                    html: responseHTML
                });
                SqueezeBox.open(result_content, { handler: 'adopt', size: { x: 800, y: 320} });
            } 
            }).get();

        }
        //if there was only one result found, redirect to the target url
        else if (gene_list_length == 1) {

            search_gene = g_list[0]; //(g_list.value.split(','))[0];
            var target_url = base_url + "?search_term=" + search_gene;
            window.location.href = target_url;

        }
        //if there was no result found, give some tips to user
        else if (gene_list_length == 0) {
            var alert_div = new Element('div', {
                html: '<font color=red>No gene  match query:' + search_gene + '</font>'
            });
            SqueezeBox.open(alert_div, { handler: 'adopt', size: { x: 300, y: 100} });
        }


    } 
    }).get({ 'name': search_gene });


}
//search gene_snp by  type a string
// TODO: code refactoring: get_gene and get_gene_snp
function get_gene_snp(element_id, type) {
    var base_url = "/hubase/snp/";
    var search_url = "/hubase/searchsnp/?type=json_list&t=" + new Date();
    var gene_symbol = "";
    // if the type is 'radio' the window.location will direct to the target url
    if (type == 'radio') {
        var selected_snp_gene = $(document.body).getElement('input[name=' + element_id + ']:checked');
        gene_symbol = selected_snp_gene.value;
        var target_url = base_url + "?search_term=" + gene_symbol;
        window.location.href = target_url;
    }
    else {
        gene_symbol = $(document.body).getElement('input[id=' + element_id + ']').value;
    }
    var jsonRequest = new Request.JSON({ url: search_url, onSuccess: function (gene_list) {
        var g_list = gene_list; //JSON.decode(gene_list);
        gene_list_length = g_list.length;
        //if more then one results found, it will pop-up a results list , user should select one to continue
        if (gene_list_length > 1) {
            var result_content;
            var req_url = '/hubase/searchsnp/?source=tree&type=html_choice&name=' + gene_symbol;
            var jsonRequest = new Request.HTML({ url: req_url, onSuccess: function (responseTree, responseElements, responseHTML, responseJavaScript) {
                result_content = new Element('div', {
                    html: responseHTML
                });
                SqueezeBox.open(result_content, { handler: 'adopt', size: { x: 800, y: 320} });
            } 
            }).get();
        }
        //if there was only one result found, redirect to the target url
        else if (gene_list_length == 1) {
            search_gene = g_list[0]; //(g_list.value.split(','))[0];
            var target_url = base_url + "?search_term=" + search_gene;
            window.location.href = target_url;
        }
        //if there was no result found, give some tips to user
        else if (gene_list_length == 0) {
            var alert_div = new Element('div', {
                html: '<font color=red>No gene symbol match query: ' + gene_symbol + '</font>'
            });
            SqueezeBox.open(alert_div, { handler: 'adopt', size: { x: 300, y: 100} });
        }
    } 
    }).get({ 'name': gene_symbol });
}
//Refresh the tree by filter
function refresh_tree(hubase_type) {
    var filter_name = "";
    var eles = $(document.body).getElements('input[class=tumor_filter]:checked');
    var i = 0;
    for (i = 0; i < eles.length; i++) {

        filter_name = filter_name + "," + eles[i].value;
    }
    eles = $(document.body).getElements('option[class=tumor_filter]:selected');
    for (i = 0; i < eles.length; i++) {

        filter_name = filter_name + "," + eles[i].value;
    }
    var base_url = "/hubase/refresh_tree/?hubase_type=" + hubase_type + "&t=" + new Date();
    var search_gene = null;
    var jsonRequest = new Request.HTML({ url: base_url, onSuccess: function (responseTree, responseElements, responseHTML, responseJavaScript) {
        var div_tree = $(document.body).getElement('div[id=div_tree]');
        div_tree.set('html', responseHTML);
        build_tree();
    } 
    }).get({ 'filter': filter_name });
}
//when domready
//window.addEvent('load', function () {
//    build_tree();

//});
function build_tree() {
    buildTree('tree1');
    buildTree('tree-HuKemia');
   
    
//    var selected_tab = $(document.body).getElement('input[id=hidden_selected_tab]');
//    var inputWord = $(document.body).getElement('input[id=search_gene]');
//    if (inputWord != null) {
//        new Autocompleter.Request.JSON(inputWord, '/hubase/searchgene.aspx?M=searchgene', {
//            'postVar': 'search_gene',
//            'selectFirst': true,
//            'selectMode': true
//        });
//    }
//    var inputWord_tumor = $(document.body).getElement('input[class=searchField_tumor]');
//    if (inputWord_tumor != null) {
//        new Autocompleter.Request.JSON(inputWord_tumor, '/hubase/searchtumor/?hubase_type=' + selected_tab.value, {
//            'postVar': 'tumor',
//            'selectFirst': true,
//            'selectMode': true
//        });
//    }
//    //auto complete for gene snp search
//    var inputWord_snp = $(document.body).getElement('input[class=searchField_snp]');
//    if (inputWord_snp != null) {
//        new Autocompleter.Request.JSON(inputWord_snp, '/hubase/searchsnp/?type=json_list', {
//            'postVar': 'name',
//            'selectFirst': true,
//            'selectMode': true
//        });
//    }
}


OFC = {}
OFC.none = {
    name: "pure DOM",
    version: function (src) { return document.getElementById(src).get_version() },
    rasterize: function (src, dst) {
        var _dst = document.getElementById(dst)
        e = document.createElement("div")
        e.innerHTML = Control.OFC.image(src)
        _dst.parentNode.replaceChild(e, _dst);
    },
    image: function (src) { return "<img src='data:image/png;base64," + document.getElementById(src).get_img_binary() + "' />" },
    popup: function (src) {
        var img_win = window.open('', 'Image')
        with (img_win.document) {
            write("<html><head><title>Charts: Export as Image</title></head><body>" + Control.OFC.image(src) + "</body></html>")
        }
    }
}
if (typeof (Control == "undefined")) { var Control = { OFC: OFC.none} }
function save_image() { Control.OFC.popup('my_chart') }

function jsonDateFormat(jsonDate) {//json日期格式转换为正常格式
    try {//出自http://www.cnblogs.com/ahjesus 尊重作者辛苦劳动成果,转载请注明出处,谢谢!
        var date = new Date(parseInt(jsonDate.replace("/Date(", "").replace(")/", ""), 10));
        var month = date.getMonth() + 1 < 10 ? "0" + (date.getMonth() + 1) : date.getMonth() + 1;
        var day = date.getDate() < 10 ? "0" + date.getDate() : date.getDate();
        var hours = date.getHours();
        var minutes = date.getMinutes();
        var seconds = date.getSeconds();
        var milliseconds = date.getMilliseconds();
        //return date.getFullYear() + "-" + month + "-" + day + " " + hours + ":" + minutes + ":" + seconds + "." + milliseconds;
        return date.getFullYear() + "-" + month + "-" + day;
    } catch (ex) {//出自http://www.cnblogs.com/ahjesus 尊重作者辛苦劳动成果,转载请注明出处,谢谢!
        return "";
    }
}



function ShowMsg(msg) {
    //    if ($.browser.msie) {//IE浏览器
    //        alert(msg);
    //    }
    //    else {
    $.messager.alert("info", msg, "info", null);
    //   }
}

function iFrameHeight() {
    var ifm = document.getElementById("iframepage");
    var subWeb = document.frames ? document.frames["iframepage"].document :
ifm.contentDocument;
    if (ifm != null && subWeb != null) {
        ifm.height = subWeb.body.scrollHeight;
    }
}

