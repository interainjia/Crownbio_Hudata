<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Respond.aspx.cs" Inherits="PDXmodelBase.HuData.Respond" %>

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
    <link rel="stylesheet" type="text/css" href="../Common/easyui-1.3.2/themes/default/easyui.css" />
    <link rel="stylesheet" type="text/css" href="../Common/easyui-1.3.2/themes/icon.css" />
    <script type="text/javascript" src="/site_media/HuData/respond.js"></script>
    <script type="text/javascript" src="../Common/fancyBox/source/jquery.fancybox.js?v=2.1.4"></script>
    <link rel="stylesheet" type="text/css" href="../Common/fancyBox/source/jquery.fancybox.css?v=2.1.4"
        media="screen" />
    <link rel="stylesheet" type="text/css" href="../Common/css/hudataform.css" />
    <link rel="stylesheet" type="text/css" href="/site_media/uploadify/uploadify.css" />
    <script type='text/javascript' src='/site_media/uploadify/jquery.uploadify.min.js'></script>
    <link rel="stylesheet" type="text/css" href="../Common/css/buttons3.css" />
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
</head>
<body>
    <form id="form1" runat="server">
    <input id="Hidden1" type="hidden" />
    <input id="hfRequest_id" type="hidden" />
    <input id="hfmodel_ids" type="hidden" />
    <input id="hfCheckmodel" type="hidden" />
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <div id="context" style="overflow: auto">
        <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional">
            <ContentTemplate>
                <table width="100%" border="0" align="center" cellpadding="0" cellspacing="1" class="tb1">
                    <tr>
                        <td class="td_left">
                            Responder:
                        </td>
                        <td class="td_right">
                            <input id="txtResponder" disabled />
                        </td>
                        <td class="td_left">
                            Project Number:
                        </td>
                        <td class="td_right">
                            <input id="txtProjectNumber" disabled></input>
                        </td>
                    </tr>
                    <tr>
                        <td class="td_left">
                            Cancer Type:
                        </td>
                        <td class="td_right">
                            <textarea id="txtTumor_Type" cols="30" rows="2" disabled></textarea>
                        </td>
                        <td class="td_left">
                            Subtype:
                        </td>
                        <td class="td_right">
                            <textarea id="txtSubtype" cols="30" rows="2" disabled></textarea>
                        </td>
                    </tr>
                    <tr>
                        <td class="td_left">
                            Model ID:
                        </td>
                        <td class="td_right">
                            <textarea id="txtModel_ID" cols="30" rows="2" disabled></textarea>
                        </td>
                        <td class="td_left">
                            Potential Study Size:
                        </td>
                        <td class="td_right">
                            <input id="txtPotential_Study_Size" disabled />
                        </td>
                    </tr>
                    <tr>
                        <td class="td_right" colspan="4" style="text-align: right; padding-right: 5px; width: 90%">
                            &nbsp;
                        </td>
                    </tr>
                </table>
            </ContentTemplate>
        </asp:UpdatePanel>
        <table cellpadding="0" cellspacing="0" border="0" width="98%">
            <tr>
                <td>
                    <table id="dgRespond" title="" data-options="toolbar:'#tb'">
                    </table>
                </td>
            </tr>
        </table>
        <div id="tb" style="padding: 5px; height: auto">
            <div style="margin-bottom: 5px">
                <%--    Model ID:
                <input type="text" id="searchModelID" name="searchModelID" style="width: 100px" />--%>
                Responded:
                <select id="searchResponded" name="searchResponded" class="easyui-combobox" editable="false">
                    <option selected="selected" value="All">All</option>
                    <option value="Have responded">Have responded</option>
                    <option value="Not responded">Not responded</option>
                </select>
                <a href="#" class="easyui-linkbutton" iconcls="icon-search" onclick="getdgRespond();">
                    Search</a>
            </div>
        </div>
        <table cellpadding="0" cellspacing="0" border="0" width="98%">
            <tr>
                <td>
                    <table id="dgSelectMice" title="" data-options="toolbar:'#tb2'">
                    </table>
                </td>
            </tr>
            <tr>
                <td>
                     Remark: <textarea id="txtRemark" cols="20" rows="5" style="width: 500px"></textarea>
                </td>
            </tr>
        </table>
        <div id="tb2" style="padding: 5px; height: auto">
            <div style="margin-bottom: 5px">
                <a href="#" class="easyui-linkbutton" iconcls="icon-ok" onclick="ConfirmRespond();">
                    Confirm respond</a>
            </div>
        </div>
        <a id="w-modifylog" class="fancybox" href="#divModifylog"></a>
        <div id="divModifylog" style="width: 800px; height: 400px; display: none;">
            <table id="dgModifylog" cellpadding="0" cellspacing="0">
            </table>
        </div>
    </div>
    </form>
</body>
</html>
