//tabs右键

$(function () {
    bindTabEvent();
    bindTabMenuEvent();
})

//li 增加点击class
$(function () {
    var liobj = $("#Nav_actve li");
    liobj.each(function () {
        $(this).click(function () {
            liobj.removeClass("active")
            $(this).addClass("active");
            //return false;    //加这句来阻止跳转 可用来调试效果
        });
    });
});
 

//    轮播


function formatText(index, panel) {
    return index + "";
}

//$(function () {

//    $('.anythingSlider').anythingSlider({
//        easing: "easeInOutExpo",        // Anything other than "linear" or "swing" requires the easing plugin
//        autoPlay: true,                 // This turns off the entire FUNCTIONALY, not just if it starts running or not.
//        delay: 3000,                    // How long between slide transitions in AutoPlay mode
//        startStopped: false,            // If autoPlay is on, this can force it to start stopped
//        animationTime: 600,             // How long the slide transition takes
//        hashTags: true,                 // Should links change the hashtag in the URL?
//        buildNavigation: true,          // If true, builds and list of anchor links to link to each slide
//        pauseOnHover: true,             // If true, and autoPlay is enabled, the show will pause on hover
//        startText: "Go",             // Start text
//        stopText: "Stop",               // Stop text
//        navigationFormatter: formatText       // Details at the top of the file on this use (advanced use)
//    });

//    $("#slide-jump").click(function () {
//        $('.anythingSlider').anythingSlider(6);
//    });

//});

//注销
function Logout_Click() {
    $.ajax({
        type: "POST", //提交的类型
        url: "Logout1.ashx?M=logout", //提交地址
        success: function (data) {
            window.location.href = data;
        }
    })

}

function addTab(name, url) {
    if ($('#tt').tabs('exists', name)) {
        $('#tt').tabs('select', name);
    }
    else {
        var $tab = $('#tt');
        var tabCount = $tab.tabs('tabs').length;

        if (tabCount >= 4) {
            $('.tabs-inner span').each(function (i, n) {
                if (i == 0) {
                    if ($(this).parent().next().is('.tabs-close')) {
                        var t = $(n).text();
                        $('#tt').tabs('close', t);
                    }
                }
            });
        }
        
        $('#tt').tabs('add', {
            title: name,
            //content: "<iframe scrolling='auto' frameborder='0'  src='" + url + "' style='width:100%;height:560px;' id='iframepage' name='iframepage' onLoad='autoiframe()' ></iframe>",

            content: "<iframe id = '" + name + "' scrolling='no' frameborder='0'  src='" + url + "' style='width:100%;height:100%;'></iframe>",
            iconCls: 'icon-tab',
            closable: true

        });
        updateTab(name,url);
    }
}
function autoiframe() {
    startInit('iframepage', 560);
}

var browserVersion = window.navigator.userAgent.toUpperCase();
var isOpera = false;
var isFireFox = false;
var isChrome = false;
var isSafari = false;
var isIE = false;
var iframeTime;
function reinitIframe(iframeId, minHeight) {
    try {
        var iframe = document.getElementById(iframeId);
        var bHeight = 0;
        if (isChrome == false && isSafari == false)
            bHeight = iframe.contentWindow.document.body.scrollHeight;

        var dHeight = 0;
        if (isFireFox == true)
            dHeight = iframe.contentWindow.document.documentElement.offsetHeight + 2;
        else if (isIE == false && isOpera == false)
            dHeight = iframe.contentWindow.document.documentElement.scrollHeight;
        else
            bHeight += 3;
        var height = Math.max(bHeight, dHeight);
        if (height < minHeight) height = minHeight;
        iframe.style.height = height + "px";
    } catch (ex) { }
}
function startInit(iframeId, minHeight) {
    isOpera = browserVersion.indexOf("OPERA") > -1 ? true : false;
    isFireFox = browserVersion.indexOf("FIREFOX") > -1 ? true : false;
    isChrome = browserVersion.indexOf("CHROME") > -1 ? true : false;
    isSafari = browserVersion.indexOf("SAFARI") > -1 ? true : false;
    if (!!window.ActiveXObject || "ActiveXObject" in window)
        isIE = true;
    reinitIframe(iframeId, minHeight);
    if (iframeTime != null)
        clearInterval(iframeTime)
    reinitIframe(iframeId, minHeight);
//    iframeTime = window.setInterval("reinitIframe('" + iframeId + "'," + minHeight + ")", 100);
}

function updateTab(name, url) {
    var tab = $('#tt').tabs('getTab', name);
    $('#tt').tabs('update', {
        tab: tab,
        options: {
            title: name,
            content: "<iframe id = '" + name + "' scrolling='no' frameborder='0'  src='" + url + "' style='width:100%;height:100%;'></iframe>",
            iconCls: 'icon-tab',
            closable: true
        }
    });
    $('#tt').tabs('select', name);
}

//遮挡pdf

$(document).ready(function () {
    //                if (document.getElementById('Chart1') != null) {
    //                    document.getElementById('Chart1').style.display = 'none';
    //                }

    $("#diymenu").mouseover(function (e) {
        //判断是否在根节点，去除js冒泡事件
        if (checkHover(e, this)) {
            var iframeWin = document.createElement("iframe");
            iframeWin.id = "ProgressBarIframe";
            iframeWin.style.cssText = "position:absolute;top:0;left:200px;width:440px; height:200px;filter:alpha(opacity=0);opacity:0;-moz-opacity:0;z-index:19;";
            iframeWin.src = "javascript:false";
            document.body.insertBefore(iframeWin, document.body.firstChild);
        }
    })
    $("#diymenu").mouseout(function (e) {
        if (checkHover(e, this)) {
            var a = document.getElementById("ProgressBarIframe");
            if (a != null) {
                document.body.removeChild(a);
            }
        }
    })
})


function contains(parentNode, childNode) {
    return parentNode.contains ? parentNode != childNode && parentNode.contains(childNode) : !!(parentNode.compareDocumentPosition(childNode) & 16);
}
function checkHover(e, target) {
    if (getEvent(e).type == "mouseover")
        return !contains(target, getEvent(e).relatedTarget || getEvent(e).fromElement) && !((getEvent(e).relatedTarget || getEvent(e).fromElement) === target);
    else {
        return !contains(target, getEvent(e).relatedTarget || getEvent(e).toElement) && !((getEvent(e).relatedTarget || getEvent(e).toElement) === target);
    }
}
function getEvent(e) {
    return e || window.event;
}
function mouseover() {

    //               var pp = $('#tt').tabs('getSelected');
    //               var tab = pp.panel('options').title
    //               var a = $("#" + tab + "").contents().find("#Pdf1");
    //               if (a.length > 0) {
    //                   a.css('display', 'none');
    //               }
}
function mouseout() {
    //               var pp = $('#tt').tabs('getSelected');
    //               var tab = pp.panel('options').title;
    //               var a = $("#" + tab + "").contents().find("#Pdf1");
    //               if (a.length > 0) {
    //                   a.css('display', 'block');
    //               }
}




//绑定tab的双击事件、右键事件
function bindTabEvent() {
    $(".tabs-inner").live('dblclick', function () {
        var subtitle = $(this).children("span").text();
        if ($(this).next().is('.tabs-close')) {
            $('#tt').tabs('close', subtitle);
        }
    });
    $(".tabs-inner").live('contextmenu', function (e) {
        $('#mm').menu('show', {
            left: e.pageX,
            top: e.pageY
        });
        var subtitle = $(this).children("span").text();
        $('#mm').data("currtab", subtitle);
        return false;
    });
}
//绑定tab右键菜单事件
function bindTabMenuEvent() {
    //关闭当前
    $('#mm-tabclose').click(function () {
        var currtab_title = $('#mm').data("currtab");
        if (currtab_title != "HOME") {
            $('#tt').tabs('close', currtab_title);
        }
    });
    //全部关闭
    $('#mm-tabcloseall').click(function () {
        $('.tabs-inner span').each(function (i, n) {
            if ($(this).parent().next().is('.tabs-close')) {
                var t = $(n).text();
                $('#tt').tabs('close', t);
            }
        });
    });
    //关闭除当前之外的TAB
    $('#mm-tabcloseother').click(function () {
        var currtab_title = $('#mm').data("currtab");
        $('.tabs-inner span').each(function (i, n) {
            if ($(this).parent().next().is('.tabs-close')) {
                var t = $(n).text();
                if (t != currtab_title)
                    $('#tt').tabs('close', t);
            }
        });
    });
    //关闭当前右侧的TAB
    $('#mm-tabcloseright').click(function () {
        var nextall = $('.tabs-selected').nextAll();
        if (nextall.length == 0) {
            //alert('已经是最后一个了');
            return false;
        }
        nextall.each(function (i, n) {
            if ($('a.tabs-close', $(n)).length > 0) {
                var t = $('a:eq(0) span', $(n)).text();
                $('#tt').tabs('close', t);
            }
        });
        return false;
    });
    //关闭当前左侧的TAB
    $('#mm-tabcloseleft').click(function () {
        var prevall = $('.tabs-selected').prevAll();
        if (prevall.length == 1) {
            //alert('已经是第一个了');
            return false;
        }
        prevall.each(function (i, n) {
            if ($('a.tabs-close', $(n)).length > 0) {
                var t = $('a:eq(0) span', $(n)).text();
                $('#tt').tabs('close', t);
            }
        });
        return false;
    });
}




