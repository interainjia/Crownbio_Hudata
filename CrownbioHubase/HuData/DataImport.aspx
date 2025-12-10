<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="DataImport.aspx.cs" Inherits="PDXmodelBase.HuData.DataImport" %>

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
    <script type="text/javascript" src="../Common/easyui-1.3.2/jquery.easyui.min.js"></script>
    <script type="text/javascript" src="../Common/css/persontree.js"></script>
    <link rel="stylesheet" type="text/css" href="../Common/easyui-1.3.2/themes/bootstrap/easyui.css" />
    <link rel="stylesheet" type="text/css" href="../Common/easyui-1.3.2/themes/icon.css" />
    <script type="text/javascript" src="/site_media/HuData/DataImport.js?v=1.2"></script>
    <script type="text/javascript" src="/site_media/HuData/export.js"></script>
    <script type="text/javascript" src="../Common/fancyBox/source/jquery.fancybox.js?v=2.1.4"></script>
    <link rel="stylesheet" type="text/css" href="../Common/fancyBox/source/jquery.fancybox.css?v=2.1.4"
        media="screen" />
    <link rel="stylesheet" type="text/css" href="../Common/css/form.css" />
    <link rel="stylesheet" type="text/css" href="/site_media/uploadify/uploadify.css" />
    <script type='text/javascript' src='/site_media/uploadify/jquery.uploadify.min.js'></script>
    <link rel="stylesheet" type="text/css" href="../Common/css/buttons3.css" />
    <link href="../Common/waiting/showLoading.css" rel="stylesheet" media="screen" />
    <script type="text/javascript" src="../Common/waiting/jquery.showLoading.js"></script>
    <script type="text/javascript">
        $(function () {
            $(window).wresize(content_resize);
            content_resize();
        });
        function content_resize() {
            $('#context').height(fillsizeH(1));
        }
        function fillsizeH(percent) {
            var bodyHeight = document.documentElement.clientHeight;
            return (bodyHeight) * percent;
        }
    </script>
    <style type="text/css">
        div#activity_pane {
        }

        .loading-indicator-bars {
            background-image: url('../Common/waiting/image/loading2.gif');
            width: 150px;
        }
    </style>
</head>
<body>
    <form id="uploadexcel" enctype="multipart/form-data" method="post" runat="server">
        <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>
        <div id="context" style="overflow: auto">
            <table cellpadding="0" cellspacing="0" border="0" width="98%">
                <tr>
                    <td>
                        <div id="activity_pane">
                            Import Table
                            <select id="Select1" style="width: 120px">
                                <option value="PDXModelInfo" selected="selected">PDXModelInfo(.csv)</option>
                                <option value="PDXModelInfo_subtype">PDXModelInfo_subtype(.xlsx)</option>
                                <option value="PDXModelInfo_update">PDXModelInfo_update(.xlsx)</option>
                                <option value="AnimalInfo">AnimalInfo(.csv)</option>
                                <option value="AnimalInfo(Z-group)">AnimalInfo(Z-group)(.xlsx)</option>
                                <option value="AnimalInfo(update)">AnimalInfo(update)(.xlsx)</option>
                                <option value="ANIMAL_TREE">Model Tree(.xlsx)</option>
                                <option value="Sponsor">Sponsor(.xlsx)</option>
                                <option value="NewModel">NewModel(.xlsx)</option>
                                <option value="Validation">Validation(.xlsx)</option>
                                <option value="RoutineMaintain">RoutineMaintain(.xlsx)</option>

                                <option value="AnimalInfo(logs)">AnimalInfo(logs)</option>
                                <option value="Cachexia Label">Cachexia Label(.xlsx)</option>
                                <%--    <option value="Table_1">Table_1(.xlsx)</option>--%>
                            </select>
                            <input id="FileUpload" name="FileUpload" type="file" style="width: 400px; background: White" class="easyui-validatebox" validtype="length[1,100]" />
                            <a href="javascript:void();" class="easyui-linkbutton" iconcls="icon-add" onclick="doAction1();">Import</a>
                            <%--    <a href="#" class="easyui-linkbutton" iconcls="icon-add" onclick="doAction2();">
                Import</a>   --%>
                        </div>
                    </td>
                </tr>

            </table>

        </div>

    </form>
</body>
</html>
