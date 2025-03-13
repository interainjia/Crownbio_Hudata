function htmlExport1() {
    $('#w-exportCol').click();

}
function htmlExport_old() {
    var btn = document.getElementById('btnExport1');
    btn.click();
}
function htmlExport_old2() {
    var btn = document.getElementById('btnExport2');
    btn.click();
}
function confirm1() {
    $('#hfAvailableColumns').val($('#AvailableColumns').combotree('getValues').toString());
    var btn = document.getElementById('btnExport1');
    btn.click();
}
function confirm2() {
    $('#hfAvailableColumns2').val($('#AvailableColumns2').combotree('getValues').toString());
    var btn = document.getElementById('btnExport2');
    btn.click();
}
function Sendmail1() {
    
    var btn = document.getElementById('btnSendmail');
    btn.click();
}
function myformatter2(cellval) { //json格式日期转换
    if (cellval != "/Date(-62135596800000)/") {
        var date = new Date(parseInt(cellval.replace("/Date(", "").replace(")/", ""), 10));
        var y = date.getFullYear();
        var m = date.getMonth() + 1;
        var d = date.getDate();
        return y + '-' + (m < 10 ? ('0' + m) : m) + '-' + (d < 10 ? ('0' + d) : d);
    }
    return "";
}

function myformatter(cellval) { //普通格式日期转换
    if (cellval != "0001/1/1 0:00:00") {
        var date = new Date(cellval);
        var y = date.getFullYear();
        var m = date.getMonth() + 1;
        var d = date.getDate();
        return y + '-' + (m < 10 ? ('0' + m) : m) + '-' + (d < 10 ? ('0' + d) : d);
    }
    return "";
}

function autoColumns(type) {
    $('#AvailableColumns').combotree({
        editable: false,
        url: 'Person.ashx?M=hfAvailableColumns&Type=' + type,
        id: 'id',
        text: 'text'

    });
}