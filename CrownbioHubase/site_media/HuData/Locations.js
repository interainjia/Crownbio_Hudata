function init() {
    $.ajax({
        type: "POST",
        dataType: "json",
        url: "GetGenedata.ashx?M=Locations",
        data: "pId=0",
        success: function (data) {
            $.fn.zTree.init($("#treeDemo"), setting, data);
            var zTree = $.fn.zTree.getZTreeObj("treeDemo");
            if (zTree != null) {
                zTree.expandAll(true);
            }

        }
    });
}

/**
* 刷新当前选择节点的父节点
*/

function refreshCurrentNode(treeNode) {
    var zTree = $.fn.zTree.getZTreeObj("treeDemo");
    //nodes = zTree.getSelectedNodes();
    /*根据 zTree 的唯一标识 tId 快速获取节点 JSON 数据对象*/
    var currentNode = zTree.getNodeByTId(treeNode.tId);
    /*选中指定节点*/
    zTree.selectNode(currentNode);
    zTree.reAsyncChildNodes(currentNode, "refresh", false);

}
function refreshParentNode(treeNode) {
    var zTree = $.fn.zTree.getZTreeObj("treeDemo");
		//nodes = zTree.getSelectedNodes();
    /*根据 zTree 的唯一标识 tId 快速获取节点 JSON 数据对象*/
    var parentNode = zTree.getNodeByTId(treeNode.parentTId);
    /*选中指定节点*/
    zTree.selectNode(parentNode);
    zTree.reAsyncChildNodes(parentNode, "refresh", false);

}

$(function () {
    init();

    $("#copy").bind("click", copy);
    $("#paste").bind("click", paste);

    bigImg();

    $('#txtLocation_Type').combobox({
        editable: false,
        url: 'Person.ashx?M=getDDLtxtSource&&ddlname=Location%20Type',
        valueField: 'id',
        textField: 'text'

    });
});


var IDMark_A = "_a";

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
        url: "GetGenedata.ashx?M=Locations",
        autoParam: ["id", "pId", "name"]
        //,otherParam: ["Search", "false", "ModelID", $('#txtModelID').val(), "Rn", $('#txtRn').val(), "Pn", $('#txtPn').val()]
    },
    view: {
      //  addHoverDom: addHoverDom
    },
    edit: {
        enable: true
//        ,showRemoveBtn: showRemoveBtn,
//		showRenameBtn: showRenameBtn
    },
    callback: {
        onClick: zTreeOnClick,
        //beforeReName: beforeReName,
        onRename: onRename,
        onRemove:onRemove,
        beforeRemove: beforeRemove

//展开单层
        ,beforeExpand: beforeExpand,
				onExpand: onExpand
    }

};

//function showRemoveBtn(treeId, treeNode) {
//    return !treeNode.isFirstNode;
//}
//function showRenameBtn(treeId, treeNode) {
////    return !treeNode.isFirstNode;
//}

function fontCss(treeNode) {
    var aObj = $("#" + treeNode.tId + "_a");
    aObj.removeClass("copy").removeClass("cut");
    if (treeNode === curSrcNode) {
        if (curType == "copy") {
            aObj.addClass(curType);
        } else {
            aObj.addClass(curType);
        }
    }
}


var curSrcNode, curType;
function setCurSrcNode(treeNode) {
    var zTree = $.fn.zTree.getZTreeObj("treeDemo");
    if (curSrcNode) {
        delete curSrcNode.isCur;
        var tmpNode = curSrcNode;
        curSrcNode = null;
        fontCss(tmpNode);
    }
    curSrcNode = treeNode;
    if (!treeNode) return;

    curSrcNode.isCur = true;
    zTree.cancelSelectedNode();
    fontCss(curSrcNode);
}
function copy(e) {
    var zTree = $.fn.zTree.getZTreeObj("treeDemo"),
			nodes = zTree.getSelectedNodes();
    if (nodes.length == 0) {
        alert("Please select a node");
        return;
    }
    curType = "copy";
    setCurSrcNode(nodes[0]);
}


function paste(e) {
    if (!curSrcNode) {
        alert("Please select a node to copy.");
        return;
    }
    var zTree = $.fn.zTree.getZTreeObj("treeDemo"),
			nodes = zTree.getSelectedNodes(),
			targetNode = nodes.length > 0 ? nodes[0] : null,
            curSrcNode2 = curSrcNode;
    if (curSrcNode === targetNode) {
        alert("不能移动，源节点 与 目标节点相同");
        return;
    } else if (curType === "cut" && ((!!targetNode && curSrcNode.parentTId === targetNode.tId) || (!targetNode && !curSrcNode.parentTId))) {
        alert("不能移动，源节点 已经存在于 目标节点中");
        return;
    } else if (curType === "copy") {
        //    var targetNode = zTree.transformToArray(targetNode); //复制到哪个根节点
        //    var curSrcNode = zTree.transformToArray(curSrcNode);//复制的节点
        if (targetNode != null) {
            $.ajax({
                type: "POST",
                dataType: "text",
                url: "Person.ashx?M=CopyLocations",
                data: "targetNode=" + targetNode.id
            + "&curSrcNode=" + curSrcNode.id

          ,
                success: function (data) {
                    if (data != "") {
                        //                        var zTree = $.fn.zTree.getZTreeObj("treeDemo");
                        //                        var treeNodes = eval('(' + data + ')');
                        //                        $.fn.zTree.init($("#treeDemo"), setting, treeNodes);
                        //                        zTree.expandAll(true);
                        refreshCurrentNode(targetNode);
                        alert("successful");
                    }

                }
            });
        }
        else {
            alert("Please select a parent node to paste.");
            return;
        }


    } else if (curType === "cut") {
        targetNode = zTree.moveNode(targetNode, curSrcNode, "inner");
        if (!targetNode) {
            alert("剪切失败，源节点是目标节点的父节点");
        }
        targetNode = curSrcNode;
    }
    setCurSrcNode();
    delete targetNode.isCur;
    zTree.selectNode(targetNode);
}



function onRename(e, treeId, treeNode) {
    
    if (treeNode.name.indexOf("(") < 0 && treeNode.name.indexOf(")") < 0) {
        $.messager.alert("info", "The format is incorrect.", "info", null);
        return;
    }
    
    //add by Jack 2025.12.23
    // Check if parentheses exist; if they do, split the string and take the first part
    var cleanName = treeNode.name.indexOf("(") > -1
        ? treeNode.name.split("(")[0]
        : treeNode.name;

    $.ajax({
        type: "POST",
        dataType: "text",
        url: "Person.ashx?M=SaveLocations_Name",
        data: "id=" + treeNode.id
            + "&name=" + cleanName,
        success: function (data) {
            if (data != "") {
                refreshParentNode(treeNode);
            }

        }
    });
}

function beforeReName(treeId, treeNode) {
//    var zTree = $.fn.zTree.getZTreeObj("treeDemo");
//    zTree.selectNode(treeNode);
    return confirm("Are you confirm rename this?");
}

function onRemove(e, treeId, treeNode) {
    $.ajax({
        type: "POST",
        dataType: "text",
        url: "Person.ashx?M=Remove_Locations",
        data: "id=" + treeNode.id,

        success: function (data) {
            if (data != "") {
                //init();
                refreshParentNode(treeNode);
            }

        }
    });
}

function beforeRemove(treeId, treeNode) {
   
    var zTree = $.fn.zTree.getZTreeObj("treeDemo");
    zTree.selectNode(treeNode);
    return confirm("Are you confirm remove this?");
}



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


function zTreeOnClick(event, treeId, treeNode) {
    $.ajax({
        type: "POST",
        dataType: "json",
        url: "Person.ashx?M=edit_Locations",
        data: "id=" + treeNode.id,
        success: function (data) {
            if (data.length > 0) {
                $('#txtAID').val(data[0].AID.split(';')[0]);
                $('#txtLocation_Type').combobox('setValue', data[0].LOCATION_TYPE)
                $('#txtName').val(data[0].NAME);
                $('#txtRows').val(data[0].MAPS_ROWS);
                $('#txtColumns').val(data[0].MAPS_COLUMNS);
                $('#hfAID').val(treeNode.id);
            }

        }
    });
}

function btnSaveLocation() {
    if ($('#hfAID').val() != "") {
        $.ajax({
            type: "POST",
            dataType: "text",
            url: "Person.ashx?M=btnSaveLocation",
            data: "id=" + $('#hfAID').val() + "&txtRows=" + $('#txtRows').val() + "&txtColumns=" + $('#txtColumns').val() + "&txtLocation_Type=" + $('#txtLocation_Type').combobox('getValue'),
            success: function (data) {
                if (data == "") {
                    $.messager.alert("info", "Save successfully", "info", null);
                }

            }
        });
    }
}