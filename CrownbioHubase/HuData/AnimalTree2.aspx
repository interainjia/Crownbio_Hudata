<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AnimalTree2.aspx.cs" Inherits="PDXmodelBase.HuData.AnimalTree2" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <script type="text/javascript" src="../Common/easyui-1.3.2/jquery-1.8.0.min.js"></script>
    <script type="text/javascript" src="../Common/easyui-1.2.5/jquery.wresize.js"></script>
    <script type='text/javascript' src='../Common/autocomplete/lib/jquery.bgiframe.min.js'></script>
    <script type='text/javascript' src='../Common/autocomplete/lib/jquery.ajaxQueue.js'></script>
    <script type='text/javascript' src='../Common/autocomplete/lib/thickbox-compressed.js'></script>
    <script type='text/javascript' src='../Common/autocomplete/jquery.autocomplete.js'></script>
    <script type='text/javascript' src='../Common/autocomplete/localdata.js'></script>
    <link rel="stylesheet" type="text/css" href="../Common/autocomplete/jquery.autocomplete.css" />
    <link rel="stylesheet" type="text/css" href="../Common/autocomplete/lib/thickbox.css" />
     <link rel="stylesheet" type="text/css" href="/site_media/hubase/css/base.css" />
    <script type="text/javascript" src="/site_media/HuData/AnimalTree.js"></script>
    <script type="text/javascript" src="../Common/fancyBox/source/jquery.fancybox.js?v=2.1.4"></script>
    <link rel="stylesheet" type="text/css" href="../Common/fancyBox/source/jquery.fancybox.css?v=2.1.4"
        media="screen" />
    <link rel="stylesheet" type="text/css" href="../Common/css/form.css" />
    <link rel="stylesheet" type="text/css" href="/site_media/uploadify/uploadify.css" />
    <script type='text/javascript' src='/site_media/uploadify/jquery.uploadify.min.js'></script>
    <%--  <link rel="stylesheet" type="text/css" href="../Common/css/buttons2.css" />--%>
    <link href="../Common/waiting/showLoading.css" rel="stylesheet" media="screen" />
    <script type="text/javascript" src="../Common/waiting/jquery.showLoading.js"></script>
    <link rel="stylesheet" href="/site_media/zTree/css/demo.css" type="text/css" />
    <link rel="stylesheet" href="/site_media/zTree/css/zTreeStyle/zTreeStyle.css" type="text/css" />
    <script type="text/javascript" src="/site_media/zTree/js/jquery-1.4.4.min.js"></script>
    <script type="text/javascript" src="/site_media/zTree/js/jquery.ztree.core-3.5.js"></script>
    <script type="text/javascript" src="/site_media/zTree/js/jquery.ztree.excheck-3.5.js"></script>
    <script type="text/javascript" src="/site_media/zTree/js/jquery.ztree.exedit-3.5.js"></script>
        <script type="text/javascript" src="../Common/easyui-1.3.2/jquery.easyui.min.js"></script>
    <script type="text/javascript" src="../Common/css/persontree.js"></script>
    <link rel="stylesheet" type="text/css" href="../Common/easyui-1.3.2/themes/default/easyui.css" />
    <link rel="stylesheet" type="text/css" href="../Common/easyui-1.3.2/themes/icon.css" />
    <script type="text/javascript">
//        $(function () {
//            $(window).wresize(content_resize);
//            content_resize();
//          
//        });
//        function content_resize() {
//            $('#context').height(fillsizeH(1));
//        }
//        function fillsizeH(percent) {
//            var bodyHeight = document.documentElement.clientHeight;
//            return (bodyHeight) * percent;
//        }
    $(document).ready(function(){
      doRestore();
       });
       function doRestore()
       {
        var  treeNodes = [<%=NodesData%>]; 
       $.fn.zTree.init($("#treeDemo"), setting, treeNodes);
       }
    </script>
    <style type="text/css">
        div#activity_pane
        {
        }
        .loading-indicator-bars
        {
            background-image: url('../Common/waiting/image/loading2.gif');
            width: 150px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <div id="context" style="overflow: auto">
        <table cellpadding="0" cellspacing="0" border="0" width="98%">
            <tr>
                <td>
                    Model ID:<input id="txtModelID" type="text" />
                    Rn:<input id="txtRn" type="text" />Pn:<input
                        id="txtPn" type="text" />
                    <input id="Button1" type="button" value="Search" onclick="doSearch();" />
                    <input id="Button2" type="button" value="Restore" onclick="doRestore();" />
                    <span id="hfnotes" style="display: none">
                        <%=NodesData%></span>
                </td>
                <td rowspan="2">
                    <ul id="treeDemo" class="ztree" style="width: 800px;height:500px">
                    </ul>
                </td>
            </tr>
            <tr>
            <td style="width:100px">
                  <ul id="tt1" class="easyui-tree" animate="true" dnd="false" style="padding-left: 0px">
                                                        </ul>   <input id="hfCellline" type="hidden" name="hfCellline" />
            </td>
            </tr>
        </table>
    </div>
    </form>
</body>
</html>
