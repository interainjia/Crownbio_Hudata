$(function () {

  
    bindAction1();
    
});
function doAction1() {
    var Select1 = document.getElementById('Select1');
    var Select = Select1.options[Select1.selectedIndex].text;
    var form = document.getElementById("uploadexcel");
    if (Select == "PDXModelInfo(.csv)") {
        form.action = "importDB.ashx?Tablename=PDXmodelInfo&delete=true";
    }
    else if (Select == "PDXModelInfo_subtype(.xlsx)") {
        form.action = "importDB.ashx?Tablename=PDXModelInfo_subtype&delete=true";
    }
    else if (Select == "PDXModelInfo_update(.xlsx)") {
        form.action = "importDB.ashx?Tablename=PDXModelInfo_update";
    }
    else if (Select == "AnimalInfo(.csv)") {
        form.action = "importDB.ashx?Tablename=AnimalInfo&delete=true";
    }
    else if (Select == "AnimalInfo(Z-group)(.xlsx)") {
        form.action = "importDB.ashx?Tablename=AnimalInfo(Z-group)";
    }
    else if (Select == "AnimalInfo(update)(.xlsx)") {
        form.action = "importDB.ashx?Tablename=AnimalInfo(update)";
    }
    else if (Select == "AnimalInfo(logs)") {
        form.action = "importDB.ashx?Tablename=AnimalInfo(logs)";
    }
    else if (Select == "Model Tree(.xlsx)") {
        form.action = "importDB.ashx?Tablename=ANIMAL_TREE";
    }
    else if (Select == "Sponsor(.xlsx)") {
        form.action = "importDB.ashx?Tablename=Sponsor";
    }
    else if (Select == "NewModel(.xlsx)") {
        form.action = "importDB.ashx?Tablename=NewModel";
    }
    else if (Select == "Validation(.xlsx)") {
        form.action = "importDB.ashx?Tablename=Validation";
    }
    else if (Select == "RoutineMaintain(.xlsx)") {
        form.action = "importDB.ashx?Tablename=RoutineMaintain";
    }
    else if (Select == "Table_1(.xlsx)") {
        form.action = "importDB.ashx?Tablename=Table_1";
    }
    else if (Select == "Cachexia Label(.xlsx)") {
        form.action = "importDB.ashx?Tablename=Cachexia";
    }
    $('#uploadexcel').submit();
}
function doAction2() {
    var form = document.getElementById("uploadexcel");
    form.action = "importDB.ashx?Tablename=PDXmodelInfo&delete=false";
    $('#uploadexcel').submit();
}


function bindAction1() {
    $('#uploadexcel').form({
        onSubmit: function () {
            if (confirm('Are you confirm this?')) {
                jQuery('#activity_pane').showLoading(
	 			         {
	 			             'addClass': 'loading-indicator-bars'
	 			         }
				        );

                var file = ($("#FileUpload").val());
                if (file == "") {
                    $.messager.alert('info', 'Please select a csv file.');
                    jQuery('#activity_pane').hideLoading();
                    return false;
                }

                else {
                    var re = /(\\+)/g;
                    var filename = file.replace(re, "#");
                    //对路径字符串进行剪切截取
                    var one = filename.split("#");
                    //获取数组中最后一个，即文件名
                    var two = one[one.length - 1];
                    //再对文件名进行截取，以取得后缀名
                    var three = two.split(".");
                    //获取截取的最后一个字符串，即为后缀名
                    var stuff = three[three.length - 1];
                    var Select1 = document.getElementById('Select1');
                    var Select = Select1.options[Select1.selectedIndex].text;
                    if (Select == "PDXModelInfo(.csv)" || Select == "AnimalInfo(.csv)") {
                        if (stuff != 'csv') {
                            $.messager.alert('Import', 'Please select a csv file.');
                            jQuery('#activity_pane').hideLoading();
                            return false;
                        }
                    }
                    else if (stuff != 'xlsx') {
                        $.messager.alert('Import', 'Please select a xlsx file.');
                        jQuery('#activity_pane').hideLoading();
                        return false;
                    }
                    else {
                        return true;
                    }

                }
            }
            else {
                return false;
            }
        },
        success: function (data) {
            $.messager.alert('Import', data, 'info');
            jQuery('#activity_pane').hideLoading();

        },
        error: function (result) { //如果没有上面的捕获出错会执行这里的回调函数
            $.messager.alert('Import', result, 'error');
            jQuery('#activity_pane').hideLoading();
        }
    });

}
