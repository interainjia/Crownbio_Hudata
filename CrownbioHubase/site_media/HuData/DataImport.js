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
var ASYNC_JOB_PREFIX = "ASYNC_JOB:";

// 轮询后台导入进度，显示进度条；结束后弹出结果（与原同步导入的提示一致）
function trackImportJob(jobId) {
    var failures = 0;
    $.messager.progress({ title: 'Import', msg: 'Import is running in the background. You can keep this page open to see the progress.', text: '{value}%', interval: 0 });

    function setProgress(job) {
        var pct = job.total > 0 ? Math.floor(job.processed * 100 / job.total) : 0;
        var bar = $.messager.progress('bar');
        if (bar.length) {
            bar.progressbar('setValue', Math.min(pct, 100));
        }
        var minutes = Math.floor(job.elapsedSeconds / 60), seconds = job.elapsedSeconds % 60;
        $('body>div.messager-window').find('div.messager-p-msg').html(
            $('<div/>').text(job.stage || '').html() + '<br/>' +
            'Rows: ' + job.processed + ' / ' + job.total + '&nbsp;&nbsp;&nbsp;Elapsed: ' + minutes + 'm ' + seconds + 's');
    }

    function finish(message, icon) {
        $.messager.progress('close');
        $.messager.alert('Import', message, icon);
    }

    function poll() {
        $.ajax({
            url: 'importDB.ashx',
            type: 'GET',
            cache: false,
            dataType: 'json',
            data: { M: 'ImportProgress', JobId: jobId },
            success: function (job) {
                failures = 0;
                if (job.status === 'running') {
                    setProgress(job);
                    setTimeout(poll, 2000);
                } else if (job.status === 'done') {
                    setProgress(job);
                    finish(job.message, 'info');
                } else {
                    finish(job.message || 'Import failed.', 'error');
                }
            },
            error: function () {
                // 网络抖动/网关偶发错误时继续重试，连续失败 10 次（约 1 分钟）才放弃（后台导入不受影响）
                failures++;
                if (failures >= 10) {
                    finish('Lost connection to the server while checking import progress. The import is still running in the background; please check the data later.', 'warning');
                } else {
                    setTimeout(poll, 5000);
                }
            }
        });
    }

    poll();
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
            jQuery('#activity_pane').hideLoading();
            // 后台异步导入：服务端返回 "ASYNC_JOB:任务ID"（iframe 提交时可能被包在 <pre> 中，先取纯文本）
            var text = $.trim($('<div/>').html(data).text());
            if (text.indexOf(ASYNC_JOB_PREFIX) === 0) {
                trackImportJob(text.substring(ASYNC_JOB_PREFIX.length));
                return;
            }
            $.messager.alert('Import', data, 'info');
        },
        error: function (result) { //如果没有上面的捕获出错会执行这里的回调函数
            $.messager.alert('Import', result, 'error');
            jQuery('#activity_pane').hideLoading();
        }
    });

}
