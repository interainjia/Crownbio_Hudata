// framework actions

var resizeTimer;
window.onresize = function () {
    clearTimeout(resizeTimer);
    setTimeout("pageResizeHandler()", 300);
}

window.onload = function () {
    pageResizeHandler();
}

function pageResizeHandler() {
    var boddorHeight = document.getElementById("div_middle").clientTop * 2;
    var heightValue = document.body.clientHeight - document.getElementById("div_top").offsetHeight - boddorHeight; // 
    if (document.getElementById("div_bottom")) {
        heightValue -= document.getElementById("div_bottom").offsetHeight;
    }
    document.getElementById("div_middle").style.height = (heightValue - 5).toString() + "px";
    document.getElementById("div_body").style.pixelHeight = heightValue - document.getElementById("div_borderTop").offsetHeight - 32;
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
//end input field actions
//search gene by  type a string
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
function refresh_tree() {
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
    var base_url = "/hubase/refresh_tree/?t=" + new Date();
    var search_gene = null;
    var jsonRequest = new Request.HTML({ url: base_url, onSuccess: function (responseTree, responseElements, responseHTML, responseJavaScript) {
        var div_tree = $(document.body).getElement('div[id=div_tree]');
        div_tree.set('html', responseHTML);
        build_tree();
    } 
    }).get({ 'filter': filter_name });
}
//when domready
window.addEvent('load', function () {
    build_tree();

});
function build_tree() {
    buildTree('tree1');
    var inputWord = $(document.body).getElement('input[id=search_gene]');
    new Autocompleter.Request.JSON(inputWord, '/hubase/searchgene/?type=json_list', {
        'postVar': 'name',
        'selectFirst': true,
        'selectMode': true
    });
    var inputWord_tumor = $(document.body).getElement('input[class=searchField_tumor]');
    new Autocompleter.Request.JSON(inputWord_tumor, '/hubase/searchtumor/', {
        'postVar': 'tumor',
        'selectFirst': true,
        'selectMode': true
    });
    //auto complete for gene snp search
    var inputWord_snp = $(document.body).getElement('input[class=searchField_snp]');
    new Autocompleter.Request.JSON(inputWord_snp, '/hubase/searchsnp/?type=json_list', {
        'postVar': 'name',
        'selectFirst': true,
        'selectMode': true
    });
}

