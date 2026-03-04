<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="TissueWithdraw.aspx.cs"
    Inherits="PDXmodelBase.HuData.TissueWithdraw" %>

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
    <link rel="stylesheet" type="text/css" href="/site_media/hudata/css/base.css" />
    <script type="text/javascript" src="../Common/css/persontree.js"></script>
    <link rel="stylesheet" type="text/css" href="../Common/easyui-1.3.2/themes/bootstrap/easyui.css" />
    <link rel="stylesheet" type="text/css" href="../Common/easyui-1.3.2/themes/icon.css" />
    <script type="text/javascript" src="/site_media/HuData/TissueWithdraw.js?v=1.0.1"></script>
    <script type="text/javascript" src="/site_media/HuData/export.js"></script>
    <script type="text/javascript" src="../Common/fancyBox/source/jquery.fancybox.js?v=2.1.4"></script>
    <link rel="stylesheet" type="text/css" href="../Common/fancyBox/source/jquery.fancybox.css?v=2.1.4"
        media="screen" />
    <link rel="stylesheet" type="text/css" href="../Common/css/hudataform.css" />
    <link rel="stylesheet" type="text/css" href="/site_media/uploadify/uploadify.css" />
    <script type='text/javascript' src='/site_media/uploadify/jquery.uploadify.min.js'></script>
    <link rel="stylesheet" type="text/css" href="../Common/css/buttons3.css" />
    <script type="text/javascript" src="/site_media/HuData/compareable_barchart_tag.js"></script>
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
        .td_right
        {
            width: 16%;
        }
        .td_left
        {
            width: 16%;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <div id="context" style="overflow-y: scroll">
        <table cellpadding="0" cellspacing="0" border="0" width="100%">
            <tr>
                <td>
                    <table id="dgTissueWithdraw" title="" data-options="toolbar:'#tb'">
                    </table>
                </td>
            </tr>
        </table>
        <div id="tb" style="padding: 5px; height: auto">
            <div style="margin-bottom: 5px">
                Project Number：
                <input id="searchProjectNumber" name="searchProjectNumber" type="text" />
                Model ID:
                <input id="searchModel_ID" name="searchModel_ID" type="text" />
                Date of Withdraw:
                 <input id="S_Date_of_Withdraw"  name="S_Date_of_Withdraw"  class="easyui-datebox" data-options="formatter:myformatter" />
                Site of Tissue Collection:<input id="S_Site_of_Tissue_Collection" type="text" name="S_Site_of_Tissue_Collection" />
                <a href="javascript:void();" class="easyui-linkbutton" iconcls="icon-search" onclick="getdgTissueWithdraw();">
                    Search</a> <a id="aExport1" class="easyui-linkbutton" href="javascript:void();" iconcls="icon-save"
                        onclick="htmlExport_old();">Export</a>
                <asp:Button ID="btnExport1" runat="server" OnClick="btnExport1_Click" Style="display: none"
                    Text="全部导出" />
                <a id="btnConfirmWithDraw" class="easyui-linkbutton" href="javascript:void();" iconcls="icon-redo"
                    onclick="ConfirmWithDraw();">Confirm</a> <a id="btnCancelWithDraw" class="easyui-linkbutton"
                        href="javascript:void();" iconcls="icon-redo" onclick="CancelWithDraw();">Cancel</a> <a id="Preserve_Amount"
                            class="easyui-linkbutton" href="javascript:void();" iconcls="icon-save" onclick="Preserve_Amount();">
                            Preserve_Amount</a>
                <asp:Button ID="btnExport_amount" runat="server" OnClick="btnExport3_Click" Style="display: none"
                    Text="全部导出" />
            </div>
        </div>
        <br />
        <table cellpadding="0" cellspacing="0" border="0" width="100%">
            <tr>
                <td>
                    <table id="dgTissueWithdraw_Completed" title="" data-options="toolbar:'#tb2'">
                    </table>
                </td>
            </tr>
        </table>
        <div id="tb2" style="padding: 5px; height: auto">
            <div style="margin-bottom: 5px">
                Project Number：
                <input id="searchProjectNumber2" name="searchProjectNumber2" type="text" />
                Model ID:
                <input id="searchModel_ID2" name="searchModel_ID2" type="text" />
                 Date of Withdraw:<input id="S_Date_of_Withdraw2"  name="S_Date_of_Withdraw2"  class="easyui-datebox" data-options="formatter:myformatter" />
                Site of Tissue Collection:<input id="S_Site_of_Tissue_Collection2" type="text" name="S_Site_of_Tissue_Collection2" />
                <a href="javascript:void();" class="easyui-linkbutton" iconcls="icon-search" onclick="getdgTissueWithdraw_Completed();">
                    Search</a> <a id="a1" class="easyui-linkbutton" href="javascript:void();" iconcls="icon-save" onclick="htmlExport_old2();">
                        Export</a>
                <asp:Button ID="btnExport2" runat="server" OnClick="btnExport2_Click" Style="display: none"
                    Text=" " />
            </div>
        </div>
    </div>
    </form>
</body>
</html>
