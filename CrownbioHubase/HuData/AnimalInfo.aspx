<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AnimalInfo.aspx.cs" Inherits="PDXmodelBase.HuData.AnimalInfo" %>

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
    <script type="text/javascript" src="/site_media/HuData/animalInfo.js"></script>
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
    <form id="uploadexcel" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <div id="context" style="overflow-y: scroll">
        <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional">
            <ContentTemplate>
             <asp:HiddenField ID="hfAvailableColumns" runat="server" />
            </ContentTemplate>
        </asp:UpdatePanel>
                <table cellpadding="0" cellspacing="0" border="0" width="100%">
                    <tr>
                        <td>
                            <table id="dgAnimalInfo" title="" data-options="toolbar:'#tb'">
                            </table>
                        </td>
                    </tr>
                </table>
                <div id="tb" style="padding: 5px; height: auto">
                    <div style="margin-bottom: 5px">
                        Model ID:
                        <input id="searchModelID" name="searchModelID" type="text" />
                           Sort By: <select id="cbxSort">
                               <option value=""></option>
                    <option value="TV">TV</option>
                        <option value="Body_Weight">Body_Weight</option>
                            </select>
                                Alive:
                  <select id="searchAlive" class="easyui-combotree" multiple name="searchAlive" style="width: 100px;">
                            </select>
                        <a href="javascript:void();" class="easyui-linkbutton" iconcls="icon-search" onclick="getdgAnimalInfo();">
                            Search</a> <a href="javascript:void();" class="easyui-linkbutton" iconcls="icon-save" onclick="htmlExport1();"
                                id="aExport1">Export</a>
                        <asp:Button ID="btnExport1" runat="server" Text="全部导出" OnClick="btnExport1_Click"
                            Style="display: none" />
                             
                    </div>
                </div>
                 
    </div>
    <a id="w-exportCol" class="fancybox" href="#exportCol"></a>
    <div id="exportCol" style="width: 300px; height: 200px; display: none;">
        Available Columns:<br />
        <select id="AvailableColumns" name="AvailableColumns" class="easyui-combotree" multiple
            style="width: 250px;">
        </select><br />
        <input id="btnConfirm" type="button" value="Confirm" onclick="confirm1();" />
    </div>
    </form>
</body>
</html>
