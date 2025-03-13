function refresh_zTree() {
    $('#hfclickID').val("");
    var treeObj = $.fn.zTree.getZTreeObj("treeDemo");
    treeObj.reAsyncChildNodes(null, "refresh");
}

function AutoTree(location_id) {
    $('#hfclickID').val(location_id);
    $.fn.zTree.init($("#treeDemo"), setting);

   
       
   
//    $.ajax({
//        type: "POST",
//        dataType: "json",
//        url: "GetGenedata.ashx?M=Locations",
//        data: "pId=0",
//        success: function (data) {
//            $.fn.zTree.init($("#treeDemo"), setting, data);
//            var zTree = $.fn.zTree.getZTreeObj("treeDemo");
//            if (zTree != null) {
//                if ($('#hfclickID').val() != "") {
//                    var nodes = zTree.getNodesByParam("id", $('#hfclickID').val(), null);
//                    if (nodes.length > 0) {
//                        zTree.selectNode(nodes[0]);
//                        $("#" + nodes[0].tId + "_a").click();
//                    }
//                }
//                else {
//                    // zTree.expandAll(true);
//                    var nodes = zTree.getNodesByParamFuzzy("name", "CrownBio");
//                    if (nodes.length > 0) {
//                        zTree.expandNode(nodes[0],true);
//                    }
//                }
//            }

    }

    function zTreeOnAsyncSuccess(event, treeId, treeNode, msg) {
        var zTree = $.fn.zTree.getZTreeObj("treeDemo");
        if (zTree != null) {
            if ($('#hfclickID').val() != "") {
                var list = [];
                list = $('#hfclickID').val().split(';')[0].split(':');
                var nodes = zTree.getNodesByParamFuzzy("name", list[0]);
                list.splice(0,1);
                $('#hfclickID').val(list.join(':'));
                if (list.length>0) {
                    if (nodes.length > 0) {
                        zTree.expandNode(nodes[0], true);
                    }
                }
                else {
                    if (nodes.length > 0) {
                        zTree.selectNode(nodes[0]);
                        $("#" + nodes[0].tId + "_a").click();
                    }
                }

            }
        };
    };


function filter(treeId, parentNode, childNodes) {
    if (!childNodes) return null;
    for (var i = 0, l = childNodes.length; i < l; i++) {
        childNodes[i].name = childNodes[i].name.replace(/\.n/g, '.');
    }
    return childNodes;
}

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
        , dataFilter: filter
        //,otherParam: ["Search", "false", "ModelID", $('#txtModelID').val(), "Rn", $('#txtRn').val(), "Pn", $('#txtPn').val()]
    },
    view: {
    //  addHoverDom: addHoverDom
},

callback: {
    onClick: zTreeOnClick




    //展开单层
            , beforeExpand: beforeExpand,
    onExpand: onExpand,
    onAsyncSuccess: zTreeOnAsyncSuccess
}

};


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
                
                $("#tbMaps>tbody").html("");
                $('#txtAID').html(data[0].AID.split(';')[0]);
                var rows = data[0].MAPS_ROWS * 1;
                var columns = data[0].MAPS_COLUMNS * 1;
                setMaps(rows, columns);

                $('#hfAID').val(data[0].AID.split(';')[0]);
                SetMaps_location($('#txtAID').html());

            }

        }
    });
}

function SetMaps_location(AID) {
    $.ajax({
        type: "POST",
        dataType: "json",
        url: "Person.ashx?M=SetMaps_location",
        data: "id=" + AID,
        success: function (data) {
            if (data != null) {
                for (var i = 0; i < data.length; i++) {
                    var _td = document.getElementById('' + data[i].WELL_ID + '');
                    if (_td != null) {
                        _td.innerHTML = data[i].MODEL_ID + "," + data[i].RN + "," + data[i].PN + "," + myformatter2(data[i].DATE_OF_INOCULATION) + "," + data[i].ANIMAL_NUMBER;
                    }
                }



            }

        }
    });
}


function setMaps(rows, columns) {
    $("#tbMaps>tbody").append('<tr>');
    for (var k = 0; k < columns + 1; k++) {
        if (k != 0) { $("#tbMaps>tbody").append('<td >' + k + '</td>'); }
        else {
            $("#tbMaps>tbody").append('<td ></td>');
        }
    }
    $("#tbMaps>tbody").append('/<tr>');

    for (var i = 0; i < rows; i++) {
        $("#tbMaps>tbody").append('<tr>');
        $("#tbMaps>tbody").append('<td width="20px" align="center">' + String.fromCharCode(65 + i) + '</td>');
        for (var j = 0; j < columns; j++) {
            $("#tbMaps>tbody").append('<td bgcolor="#ffbfbf" id="' + String.fromCharCode(65 + i) + (j+1) + '"></td>');
        }
        $("#tbMaps>tbody").append('/<tr>');

    }
}


