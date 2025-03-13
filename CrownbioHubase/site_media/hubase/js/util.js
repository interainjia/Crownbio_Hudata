
/**
Tree action
**/
function changeStatus(fatherChecked, cancerType) {
    var eles = $(document.body).getElements('input[name=' + cancerType + ']');
    var i = 0;
    for (i = 0; i < eles.length; i++) {
        if (fatherChecked) {

            eles[i].set("checked", true);
        }
        else {
            eles[i].erase("checked");
        }
    }
}
function changeFartherStatus(cancerType) {
    var eles = $(document.body).getElements('input[name=' + cancerType + ']').filter('input[class=tumormodel]');
    var i = 0;
    var nullchecked = true;
    for (i = 0; i < eles.length; i++) {

        var checked = eles[i].get("checked");
        if (checked) {
            nullchecked = false;
        }

    }
    var ele = $(document.body).getElements('input[class=cancertype]').filter('input[name=' + cancerType + ']');
    if (nullchecked) {

        ele[0].erase("checked");
    }
    else {
        ele[0].set("checked", true);
    }
}
function selectAll(checkbox, type) {
    $('#hfselectAll').val("true");
    if (checkbox.checked == true) {
        
        var nodes = $('#tree_right').tree('getRoots');       
        for (var i = 0; i < nodes.length; i++) {
            $('#tree_right').tree('check', nodes[i].target);
        }
        if (type == "Gene") {
            draw_compareable_barchart();
        }
        else if (type == "CN") {
            draw_compareable_barchart_CN();
        }
        else if (type == "Mutation") {
            draw_compareable_barchart_MU();
        }
        else if (type == "Mutation_Validated") {
            draw_compareable_barchart_MU_Validated();
        }
        else if (type == "Genefusion") {
            draw_compareable_barchart_GF();
        }
        else if (type == "GeneExpression_RNA") {
            draw_compareable_barchart_GNRNA();
        }
    }
    else {        
        var nodes = $('#tree_right').tree('getRoots');      
        for (var i = 0; i < nodes.length; i++) {
            $('#tree_right').tree('uncheck', nodes[i].target);
        }
        $('#hfselectAll').val("false");
    }
   
}


// explore the chart in a new pop-up windows
function open_in_windows(element_id) {

    var open_in_window = document.getElements('a[id=' + element_id + ']');
    var url = open_in_window.get("name");
    new MUI.Modal({
        id: 'explore_chart',
        title: 'Chart',
        loadMethod: 'iframe',
        contentURL: url + "&popup=true",
        type: 'modal',
        width: 1200,
        height: 600,
        padding: { top: 10, right: 12, bottom: 10, left: 12 },
        scrollbars: true
    });

}
/**
room in or room out the chart
**/
function zoom_chart(chart_id, action) {
    var chart = document.getElementById(chart_id);
    var chart_width = chart.offsetWidth;
    if (action == "in") {
        if (parseInt(chart_width) < 5000) {
            chart.style.width = parseInt(chart_width) * 1.1 + 'px';
        }
    }
    else if (action == "out") {
        if (parseInt(chart_width) > 700) {
            chart.style.width = parseInt(chart_width) * 0.9 + 'px';
        }

    }
}