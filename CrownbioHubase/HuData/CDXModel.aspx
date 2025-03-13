<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CDXModel.aspx.cs" Inherits="PDXmodelBase.HuData.CDXModel" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
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
    <link rel="stylesheet" type="text/css" href="/site_media/HuData/css/base.css" />
    <script type="text/javascript" src="../Common/css/persontree.js"></script>
    <link rel="stylesheet" type="text/css" href="../Common/easyui-1.3.2/themes/bootstrap/easyui.css" />
    <link rel="stylesheet" type="text/css" href="../Common/easyui-1.3.2/themes/icon.css" />
    <script type="text/javascript" src="/site_media/HuData/CDXModel.js?v=7.0"></script>
    <script type="text/javascript" src="../site_media/HuData/base.js"></script>
    <script type="text/javascript" src="../site_media/HuData/export.js"></script>
    <script type="text/javascript" src="../Common/fancyBox/source/jquery.fancybox.js?v=2.1.4"></script>
    <link rel="stylesheet" type="text/css" href="../Common/fancyBox/source/jquery.fancybox.css?v=2.1.4"
        media="screen" />
    <link rel="stylesheet" type="text/css" href="../Common/css/HuDataform.css" />
    <link rel="stylesheet" type="text/css" href="/site_media/uploadify/uploadify.css" />
    <script type='text/javascript' src='/site_media/uploadify/jquery.uploadify.min.js'></script>
    <link rel="stylesheet" type="text/css" href="../Common/css/buttons2.css" />
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
    <input id="compared_objects_list" name="compared_objects_list" type="hidden" value="" />
    <input id="hfmodel_ids" type="hidden" />
    <input id="hfStudy" type="hidden" />
    <input id="Searchdata" type="hidden" />
    <input id="hfPN" type="hidden" />
    <input id="hfCDXModel_ID" type="hidden" />
    <input id="rid" type="hidden" />
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <div id="context" style="overflow-y: scroll">
        <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional">
            <ContentTemplate>
                <div id="divCDXModelImport" class="easyui-accordion">
                    <div id="CDXModelImport" title="more" style="overflow: auto;">
                        <table width="100%" border="0" align="center" cellpadding="0" cellspacing="1" class="tb1">
                            <tr>
                                <td class="td_left">
                                    Sq Number:
                                </td>
                                <td class="td_right">
                                    <input id="txtSq_Number" class="easyui-validatebox" data-options="required:true" />
                                </td>
                                <td class="td_left">
                                    Cancer Type Abbr:
                                </td>
                                <td class="td_right">
                                    <input id="txtCancer_Type_Abbr" disabled="disabled"></input>
                                </td>
                                <td class="td_left">
                                    Model ID:
                                </td>
                                <td class="td_right">
                                    <input id="txtModel_ID" disabled="disabled"></input>
                                </td>
                            </tr>
                            <tr>
                                <td class="td_left">
                                    Model From:
                                </td>
                                <td class="td_right">
                                    <div id="divModel_From">
                                        <select id="txtModel_From" class="easyui-combobox" name="txtModel_From" style="width: 100px;">
                                        </select></div>
                                </td>
                                <td class="td_left">
                                    Mouse Strain:
                                </td>
                                <td class="td_right">
                                    <input id="txtMouse_Strain"></input>
                                </td>
                                <td class="td_left">
                                    Cancer Type:
                                </td>
                                <td class="td_right">
                                    <div id="divCancer_Type">
                                        <select id="txtCancer_Type" class="easyui-combobox" name="txtCancer_Type" style="width: 250px;">
                                        </select></div>
                                </td>
                            </tr>
                            <tr>
                                <td class="td_left">
                                    Subtype1:
                                </td>
                                <td class="td_right">
                                    <div id="divSubtype1">
                                        <select id="txtSubtype1" name="txtSubtype1" class="easyui-combobox" style="width: 250px;">
                                        </select></div>
                                </td>
                                <td class="td_left">
                                    Subtype2:
                                </td>
                                <td class="td_right">
                                    <div id="divSubtype2">
                                        <select id="txtSubtype2" name="txtSubtype2" class="easyui-combobox" style="width: 250px;">
                                        </select></div>
                                </td>
                                <td class="td_left">
                                    Model Category:
                                </td>
                                <td class="td_right">
                                    <div id="divModel_Category">
                                        <select id="txtModel_Category" class="easyui-combobox" name="txtModel_Category" style="width: 100px;">
                                        </select></div>
                                </td>
                            </tr>
                            <tr>
                                <td class="td_left">
                                    Source ID:
                                </td>
                                <td class="td_right">
                                    <input id="txtSource_ID"></input>
                                </td>
                                <td class="td_left">
                                    Source Note:
                                </td>
                                <td class="td_right">
                                    <input id="txtSource_Note"></input>
                                </td>
                                <td class="td_left">
                                    PDX QC:
                                </td>
                                <td class="td_right">
                                    <input id="txtPDX_QC"></input>
                                </td>
                            </tr>
                            <tr>
                                <td class="td_left">
                                    Genotype Consistence:
                                </td>
                                <td class="td_right">
                                    <input id="txtGenotype_Consistence" />
                                </td>
                                <td class="td_left">
                                    IN_HUBA:
                                </td>
                                <td class="td_right">
                                    <input id="txtIN_HUBA"></input>
                                </td>
                                <td class="td_left">
                                    Total Revival Success Rate:
                                </td>
                                <td class="td_right">
                                    <input id="txtTotal_Revival_Success_Rate" />
                                </td>
                            </tr>
                            <tr>
                                <td class="td_left">
                                    Time of Revival:
                                </td>
                                <td class="td_right">
                                    <input id="txtTime_of_Revival"></input>
                                </td>
                                <td class="td_left">
                                    Revival Recommended Strain:
                                </td>
                                <td class="td_right">
                                    <input id="txtRevival_Recommended_Strain"></input>
                                </td>
                                <td class="td_left">
                                    Time of Model for Transplant:
                                </td>
                                <td class="td_right">
                                    <input id="txtTime_of_Model_for_Transplant" />
                                </td>
                            </tr>
                            <tr>
                                <td class="td_left">
                                    Maintain Recommended Strain:
                                </td>
                                <td class="td_right">
                                    <input id="txtMaintain_Recommended_Strain"></input>
                                </td>
                                <td class="td_left">
                                    Spare% for CV40:
                                </td>
                                <td class="td_right">
                                    <input id="txtSpare_for_CV40"></input>
                                </td>
                                <td class="td_left">
                                    Spare% for CV30:
                                </td>
                                <td class="td_right">
                                    <input id="txtSpare_for_CV30" />
                                </td>
                            </tr>
                            <tr><td class="td_left">
                                   Optimal Overage:
                                </td>
                                <td class="td_right">
                                    <input id="txtOptimal_Overage"></input>
                                </td>
                                <td class="td_left">
                                </td>
                                <td class="td_right">
                                </td>
                                <td class="td_left">
                                </td>
                                <td class="td_right">
                                </td></tr>
                            <tr>
                                <td class="td_left">
                                    Dosing Window:
                                </td>
                                <td class="td_right">
                                    <input id="txtDosing_Window"></input>
                                </td>
                                <td class="td_left">
                                    Cryo-P:
                                </td>
                                <td class="td_right">
                                    <input id="txtCryo_P"></input>
                                </td>
                                <td class="td_left">
                                    Snap Frozen:
                                </td>
                                <td class="td_right">
                                    <input id="txtSnap_Frozen" />
                                </td>
                            </tr>
                            <tr>
                                <td class="td_left">
                                    FFPE:
                                </td>
                                <td class="td_right">
                                    <input id="txtFFPE"></input>
                                </td>
                                <td class="td_left">
                                </td>
                                <td class="td_right">
                                </td>
                                <td class="td_left">
                                    Times Used In Study:
                                </td>
                                <td class="td_right">
                                    <input id="txtTimes_Used_In_Study" />
                                </td>
                            </tr>
                            <tr>
                                <td class="td_left">
                                    Cachexia Label(Cachexia>=50%;Slight BW loss0-50%;Normal<0):
                                </td>
                                <td class="td_right">
                                    <div id="divCachexia_Label">
                                        <select id="txtCachexia_Label" class="easyui-combobox" name="txtCachexia_Label" style="width: 150px;">
                                        </select></div>
                                </td>
                                <td class="td_left">
                                    Cachexia:
                                </td>
                                <td class="td_right">
                                    <div id="divCachexia">
                                        <input id="txtCachexia" />
                                    </div>
                                </td>
                                <td class="td_left">
                                    Slight_BW_loss:
                                </td>
                                <td class="td_right">
                                    <div id="divSlight_BW_loss">
                                        <input id="txtSlight_BW_loss" />
                                    </div>
                                </td>
                            </tr>
                            <tr>
                                <td class="td_left">
                                    Normal:
                                </td>
                                <td class="td_right">
                                    <div id="divNormal">
                                        <input id="txtNormal" />
                                    </div>
                                </td>
                                <td class="td_left">
                                    Ulceration Label:
                                </td>
                                <td class="td_right">
                                    <input id="txtUlceration_Label"></input>
                                </td>
                                <td class="td_left">
                                    Survival Curve:
                                </td>
                                <td class="td_right">
                                    <div id="divSurvival_Curve">
                                        <select id="txtSurvival_Curve" class="easyui-combobox" name="txtSurvival_Curve" style="width: 150px;">
                                        </select></div>
                                </td>
                            </tr>
                            <tr>
                                <td class="td_left">
                                    SOC:
                                </td>
                                <td class="td_right">
                                    <div id="divSOC">
                                        <select id="ddlSOC" name="ddlSOC" class="easyui-combotree" multiple style="width: 150px;">
                                        </select></div>
                                    <input id="hfSOC" type="hidden" />
                                </td>
                                <td class="td_left">
                                    &nbsp;
                                </td>
                                <td class="td_right">
                                    &nbsp;
                                </td>
                                <td class="td_left">
                                    &nbsp;
                                </td>
                                <td class="td_right">
                                    &nbsp;
                                </td>
                            </tr>
                            <tr>
                                <td class="td_left">
                                    Comments:
                                </td>
                                <td class="td_right" colspan="5">
                                    <input id="txtcomments" style="width: 600px" />
                                </td>
                            </tr>
                            <tr>
                                <td class="td_left">
                                </td>
                                <td class="td_right" colspan="5">
                                    <a class="easyui-linkbutton" onclick="AddCDXModel();" id="btnAdd">Add</a> <a class="easyui-linkbutton"
                                        onclick="Check();" id="btnSend3">Save</a>
                                    <asp:HiddenField ID="hfCDXModel_ID" runat="server" />
                                    <asp:HiddenField ID="HiddenField2" runat="server" />
                                    <asp:HiddenField ID="hfAvailableColumns" runat="server" />
                                    <asp:HiddenField ID="hfAvailableColumns2" runat="server" />
                                    <input id="Reset1" type="reset" value="reset" style="display: none" />
                                </td>
                            </tr>
                        </table>
                    </div>
                </div>
            </ContentTemplate>
            <%--<triggers>                                                   
                                                  <asp:AsyncPostBackTrigger ControlID="btnSendmail" EventName="Click"></asp:AsyncPostBackTrigger>
                                                 </triggers>--%>
        </asp:UpdatePanel>
        <table cellpadding="0" cellspacing="0" border="0" width="98%">
            <tr>
                <td>
                    <table id="dgCDXModel" title="" data-options="toolbar:'#tb'">
                    </table>
                </td>
            </tr>
        </table>
        <div id="tb" style="padding: 5px; height: auto">
            <div style="margin-bottom: 5px">
                Model ID:
                <input id="S_CDXModelname" name="S_CDXModelname" type="text" />
                <a href="#" class="easyui-linkbutton" onclick="SelectDatagrid();">Search</a> <a id="aExport1"
                    class="easyui-linkbutton" href="#" onclick="htmlExport_old();">Export</a>
                <asp:Button ID="btnExport1" runat="server" OnClick="btnExport1_Click" Style="display: none"
                    Text="全部导出" />
                <a id="btndelete" name="btndelete" href="#" class="easyui-linkbutton" onclick="deleteCDXModel();">
                    Delete</a> <a id="btnSetColumns" name="btnSetColumns" href="#" class="easyui-linkbutton"
                        onclick="SetColumns();">Columns</a>
                        Note!:Cachexia Label(Cachexia>=50%;Slight BW loss0-50%;Normal<0)
            </div>
            <div id="divSearch" class="easyui-accordion">
                <div id="AdvancadSearch" title="Advancad Search" style="overflow: auto;">
                    <table id="table2" width="100%" border="0" cellpadding="0" cellspacing="0">
                        <tr id="tr1">
                            <td>
                                <img alt="" id="search1" onclick="ADSearch()" src="../images/list-search.png" />
                                <img alt="" id="add1" onclick="AddField()" src="../images/list-add.png" />
                            </td>
                            <td>
                                Field Name:<select id="selectFieldName0" class="easyui-combobox" name="selectFieldName[]"
                                    style="width: 150px;">
                                </select>
                            </td>
                            <td>
                                Condition:<select id="selectCondition0" name="selectCondition[]">
                                    <option value="like">like</option>
                                    <option value="not like">not like</option>
                                    <option value="=">=</option>
                                    <option value="<>"><></option>
                                </select>
                            </td>
                            <td>
                                Field Value:<input id="selectFieidValue0" name="selectFieidValue[]" type="text" />
                            </td>
                        </tr>
                    </table>
                </div>
            </div>
        </div>
    </div>
    <a id="w-Log" class="fancybox" href="#divLog"></a>
    <div id="divLog" style="width: 800px; height: 500px; display: none;">
        <table id="dgCDXModel_Log" cellpadding="0" cellspacing="0">
        </table>
    </div>
    <a id="open-SetColumns" class="fancybox" href="#divSetColumns"></a>
    <div id="divSetColumns" style="width: 800px; height: 500px; display: none;">
        <iframe scrolling="no" frameborder="0" style="width: 100%; height: 100%;" id="iframepage"
            name="iframepage" onload="iFrameHeight()"></iframe>
    </div>
    </form>
</body>
</html>
