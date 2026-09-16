<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PDXmodelInfo.aspx.cs" Inherits="PDXmodelBase.HuData.PDXmodelInfo" %>

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
    <script type="text/javascript" src="/site_media/HuData/modelinfo.js?v=8.7"></script>
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
    <style type="text/css">
        .td_right {
            width: 16%;
        }

        .td_left {
            width: 16%;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>
        <div id="context" style="overflow-y: scroll">
            <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional">
                <ContentTemplate>
                    <div id="divPDXmodelImport" class="easyui-accordion">
                        <div id="PDXmodelImport" title="Edit" style="overflow: auto;">
                            <table width="100%" border="0" align="center" cellpadding="0" cellspacing="1" class="tb1">
                                <%--   <tr>
                                    <td class="td_left">Location:<span style="color: Red">*</span>
                                    </td>
                                    <td class="td_right">
                                        <select id="txtLocation" name="txtLocation" style="width: 100px;" disabled="disabled">
                                            <option value="Not CBSD">Not CBSD</option>
                                            <option value="CBSD">CBSD</option>
                                        </select>
                                    </td>
                                    <td class="td_left"></td>
                                    <td class="td_right"></td>
                                    <td class="td_left"></td>
                                    <td class="td_right"></td>
                                </tr>--%>
                                <tr>
                                    <td class="td_left">Sq Number:
                                    </td>
                                    <td class="td_right">
                                        <input id="txtSq_Number" class="easyui-validatebox" data-options="required:true" />
                                    </td>
                                    <td class="td_left">Cancer Type Abbr:
                                    </td>
                                    <td class="td_right">
                                        <input id="txtCancer_Type_Abbr" disabled="disabled"></input>
                                    </td>
                                    <td class="td_left">Model ID:
                                    </td>
                                    <td class="td_right">
                                        <input id="txtModel_ID" disabled="disabled"></input>
                                    </td>
                                </tr>
                                <!-- New Row 2: Patient ID, Source, Origin (3 items) -->
                                <tr>
                                    <td class="td_left">Patient ID:
                                    </td>
                                    <td class="td_right">
                                        <input id="txtPatient_ID"></input>
                                    </td>
                                    <td class="td_left">Source
                                    </td>
                                    <td class="td_right">
                                        <div id="divSource">
                                            <select id="txtSource" class="easyui-combobox" name="txtSource" style="width: 150px;">
                                            </select>
                                        </div>
                                    </td>
                                    <td class="td_left">Origin:
                                    </td>
                                    <td class="td_right">
                                        <div id="divOrigin">
                                            <select id="txtOrigin" class="easyui-combobox" name="txtOrigin" style="width: 150px;">
                                            </select>
                                        </div>
                                    </td>
                                </tr>
                                <!-- New Row 3: Cancer Type, Subtype1, Subtype2 (3 items) -->
                                <tr>
                                    <td class="td_left">Cancer Type:
                                    </td>
                                    <td class="td_right">
                                        <div id="divCancer_Type">
                                            <select id="txtCancer_Type" class="easyui-combobox" name="txtCancer_Type" style="width: 150px;">
                                            </select>
                                        </div>
                                    </td>
                                    <td class="td_left">Subtype1:
                                    </td>
                                    <td class="td_right">
                                        <div id="divSubtype1">
                                            <select id="txtSubtype1" name="txtSubtype1" class="easyui-combobox" style="width: 150px;">
                                            </select>
                                        </div>
                                    </td>
                                    <td class="td_left">Subtype2:
                                    </td>
                                    <td class="td_right">
                                        <div id="divSubtype2">
                                            <select id="txtSubtype2" name="txtSubtype2" class="easyui-combobox" style="width: 150px;">
                                            </select>
                                        </div>
                                    </td>
                                </tr>
                                <!-- New Row 4: Model Category, Source ID, Source Note (3 items) -->
                                <tr>
                                    <td class="td_left">Model Category:
                                    </td>
                                    <td class="td_right">
                                        <div id="divModel_Category">
                                            <select id="txtModel_Category" class="easyui-combobox" name="txtModel_Category" style="width: 150px;">
                                            </select>
                                        </div>
                                    </td>
                                    <td class="td_left">Source ID:
                                    </td>
                                    <td class="td_right">
                                        <input id="txtSource_ID"></input>
                                    </td>
                                    <td class="td_left">Source Note:
                                    </td>
                                    <td class="td_right">
                                        <input id="txtSource_Note"></input>
                                    </td>
                                </tr>
                                <!-- New Row 5: PDX QC, STR Consistence, In_Huba (3 items) -->
                                <tr>
                                    <td class="td_left">PDX QC:
                                    </td>
                                    <td class="td_right">
                                        <input id="txtPDX_QC"></input>
                                    </td>
                                    <td class="td_left">STR Consistence:
                                    </td>
                                    <td class="td_right">
                                        <div id="divSTR_Consistence">
                                            <select id="txtSTR_Consistence" class="easyui-combobox" name="txtSTR_Consistence"
                                                style="width: 150px;">
                                            </select>
                                        </div>
                                    </td>
                                    <td class="td_left">In_Huba:
                                    </td>
                                    <td class="td_right">
                                        <input id="txtIN_HUBA"></input>
                                    </td>
                                </tr>
                                <!-- New Row 5b: Available_Site (1 item + 2 empty slots) -->
                                <tr>
                                    <td class="td_left">Available Site:
                                    </td>
                                    <td class="td_right">
                                        <input id="txtAvailable_Site"></input>
                                    </td>
                                    <td class="td_left"></td>
                                    <td class="td_right"></td>
                                    <td class="td_left"></td>
                                    <td class="td_right"></td>
                                </tr>
                                <!-- Row 6: Total Revival Success Rate, Time of Revival, Revival Recommended Strain (3 items) -->
                                <tr>
                                    <td class="td_left">Total Revival Success Rate:
                                    </td>
                                    <td class="td_right">
                                        <input id="txtTotal_Revival_Success_Rate" />
                                    </td>
                                    <td class="td_left">Time of Revival:
                                    </td>
                                    <td class="td_right">
                                        <input id="txtTime_of_Revival"></input>
                                    </td>
                                    <td class="td_left">Revival Recommended Strain:
                                    </td>
                                    <td class="td_right">
                                        <input id="txtRevival_Recommended_Strain"></input>
                                    </td>
                                </tr>
                                <!-- Row 7: Time of Model for Transplant, Maintain Recommended Strain, Spare% for CV40 (3 items) -->
                                <tr>
                                    <td class="td_left">Time of Model for Transplant:
                                    </td>
                                    <td class="td_right">
                                        <input id="txtTime_of_Model_for_Transplant" />
                                    </td>
                                    <td class="td_left">Maintain Recommended Strain:
                                    </td>
                                    <td class="td_right">
                                        <input id="txtMaintain_Recommended_Strain"></input>
                                    </td>
                                    <td class="td_left">Spare% for CV40:
                                    </td>
                                    <td class="td_right">
                                        <input id="txtSpare_for_CV40"></input>
                                    </td>
                                </tr>
                                <!-- Row 8: Spare% for CV30, Optimal Overage (2 items + 1 empty slot) -->
                                <tr>
                                    <td class="td_left">Spare% for CV30:
                                    </td>
                                    <td class="td_right">
                                        <input id="txtSpare_for_CV30" />
                                    </td>
                                    <td class="td_left">Optimal Overage:
                                    </td>
                                    <td class="td_right">
                                        <input id="txtOptimal_Overage"></input>
                                    </td>
                                    <td class="td_left"></td>
                                    <td class="td_right"></td>
                                </tr>
                                <tr>
                                    <td class="td_left">Dosing Window:
                                    </td>
                                    <td class="td_right">
                                        <input id="txtDosing_Window"></input>
                                    </td>
                                    <td class="td_left">Cryo-P:
                                    </td>
                                    <td class="td_right">
                                        <input id="txtCryo_P"></input>
                                    </td>
                                    <td class="td_left">Snap Frozen:
                                    </td>
                                    <td class="td_right">
                                        <input id="txtSnap_Frozen" />
                                    </td>
                                </tr>
                                <tr>
                                    <td class="td_left">FFPE:
                                    </td>
                                    <td class="td_right">
                                        <input id="txtFFPE"></input>
                                    </td>
                                    <td class="td_left">HP2.0:
                                    </td>
                                    <td class="td_right">
                                        <input id="txtHP2"></input>
                                    </td>
                                    <td class="td_left">Times Used In Study:
                                    </td>
                                    <td class="td_right">
                                        <input id="txtTimes_Used_In_Study" />
                                    </td>
                                </tr>
                                <tr>
                                    <td class="td_left">Cachexia Label(Cachexia>=50%;Slight BW loss0-50%;Normal<0):
                                    </td>
                                    <td class="td_right">
                                        <div id="divCachexia_Label">
                                            <select id="txtCachexia_Label" class="easyui-combobox" name="txtCachexia_Label" style="width: 150px;">
                                            </select>
                                        </div>
                                    </td>
                                    <td class="td_left">Cachexia:
                                    </td>
                                    <td class="td_right">
                                        <div id="divCachexia">
                                            <input id="txtCachexia" />
                                        </div>
                                    </td>
                                    <td class="td_left">Slight_BW_loss:
                                    </td>
                                    <td class="td_right">
                                        <div id="divSlight_BW_loss">
                                            <input id="txtSlight_BW_loss" />
                                        </div>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="td_left">Normal:
                                    </td>
                                    <td class="td_right">
                                        <div id="divNormal">
                                            <input id="txtNormal" />
                                        </div>
                                    </td>
                                    <td class="td_left">Ulceration Label:
                                    </td>
                                    <td class="td_right">
                                        <input id="txtUlceration_Label"></input>
                                    </td>
                                    <td class="td_left">Survival Curve:
                                    </td>
                                    <td class="td_right">
                                        <div id="divSurvival_Curve">
                                            <select id="txtSurvival_Curve" class="easyui-combobox" name="txtSurvival_Curve" style="width: 150px;">
                                            </select>
                                        </div>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="td_left">SOC:
                                    </td>
                                    <td class="td_right">
                                        <div id="divSOC">
                                            <select id="ddlSOC" name="ddlSOC" class="easyui-combotree" multiple style="width: 150px;">
                                            </select>
                                        </div>
                                        <input id="hfSOC" type="hidden" />
                                    </td>
                                    <td class="td_left">Exomeseq:
                                    </td>
                                    <td class="td_right">
                                        <input id="txtExomeseq"></input>
                                    </td>
                                    <td class="td_left">&nbsp;
                                    </td>
                                    <td class="td_right">&nbsp;
                                    </td>
                                </tr>
                                <tr>
                                    <td class="td_left">Comments:
                                    </td>
                                    <td class="td_right" colspan="5">
                                        <input id="txtcomments" style="width: 600px" />
                                    </td>
                                </tr>
                                <tr>
                                    <td class="td_left">Total_Revival_Success_Rate_CBNC:
                                    </td>
                                    <td class="td_right">
                                        <input id="txtTotal_Revival_Success_Rate_CBNC" />
                                    </td>
                                    <td class="td_left">Time_of_Revival_CBNC:
                                    </td>
                                    <td class="td_right">
                                        <input id="txtTime_of_Revival_CBNC" />
                                    </td>
                                    <td class="td_left">Revival_Recommended_Strain_CBNC:
                                    </td>
                                    <td class="td_right">
                                        <input id="txtRevival_Recommended_Strain_CBNC" />
                                    </td>
                                </tr>
                                <tr>
                                    <td class="td_left">Treatment_history_1:
                                    </td>
                                    <td class="td_right">
                                        <input id="txtTreatment_history_1" />
                                    </td>
                                    <td class="td_left">Treatment_history_2
                                    </td>
                                    <td class="td_right">
                                        <input id="txtTreatment_history_2" />
                                    </td>
                                    <td class="td_left">Model From:
                                    </td>
                                    <td class="td_right">
                                        <div id="divModel_From">
                                            <select id="txtModel_From" class="easyui-combobox" name="txtModel_From" style="width: 150px;">
                                            </select>
                                        </div>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="td_left">Implantation_Method:
                                    </td>
                                    <td class="td_right">
                                        <input id="txtImplantation_Method" />
                                    </td>
                                    <td class="td_left">DeathRate:
                                    </td>
                                    <td class="td_right">
                                        <input id="txtDeathRate" />
                                    </td>
                                    <td class="td_left">&nbsp;
                                    </td>
                                    <td class="td_right">&nbsp;
                                    </td>
                                </tr>
                                <tr>
                                    <td class="td_left"></td>
                                    <td class="td_right" colspan="5">
                                        <a class="easyui-linkbutton" onclick="AddPDXmodel();" id="btnAdd">Add</a> <a class="easyui-linkbutton"
                                            onclick="Check();" id="btnSend3">Save</a>
                                        <asp:Button ID="btnSend2" runat="server" OnClick="btnSend_OnClick" Style="display: none" />
                                        <asp:HiddenField ID="hfPDXInfoID" runat="server" />
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
            </asp:UpdatePanel>
            <table cellpadding="0" cellspacing="0" border="0" width="100%">
                <tr>
                    <td>
                        <table id="dgModelInfo" title="" data-options="toolbar:'#tb'">
                        </table>
                    </td>
                </tr>
            </table>
            <div id="tb" style="padding: 0px; height: auto">
                <div style="margin-bottom: 5px">
                    Cancer Type:
                <select id="searchCancertype" class="easyui-combobox" name="searchCancertype" style="width: 100px;">
                </select>
                    Subtype1:
                <select id="searchSubtype1" name="searchSubtype1" class="easyui-combotree" multiple
                    style="width: 150px;">
                </select>
                    Subtype2:
                <select id="searchSubtype2" name="searchSubtype2" class="easyui-combotree" multiple
                    style="width: 150px;">
                </select>
                    Model ID:
                <input id="searchModelID" name="searchModelID" type="text" />
                    Model Category:
                <select id="cbxModel_Category" name="cbxModel_Category" class="easyui-combotree"
                    multiple style="width: 150px;">
                </select>
                    <div id="divMoreSearch" class="easyui-accordion">
                        <div id="MoreSearch" title="Advancad Search" style="overflow: auto;">
                            Source:
                        <select id="cbxSource" class="easyui-combobox" name="cbxSource" style="width: 100px; display: none">
                        </select>
                            Model Status:
                        <select id="cbxModelstatus">
                            <option value=""></option>
                            <option value="Available">Available</option>
                            <option value="Not available">Not available</option>
                            <option value="Available for internal use">Available for internal use</option>
                            <option value="NA">NA</option>
                        </select>
                            <br />
                            Patient Pathology info:
                        <select id="cbxPatient">
                            <option value=""></option>
                            <option value="Qced">Qced</option>
                        </select>
                            Source Note:
                        <input type="text" id="cbxSource_Note" name="cbxSource_Note" />
                            PDX QC:
                        <input type="text" id="cbxPDX_QC" name="cbxPDX_QC" />
                            <br />
                            STR Consistence:
                        <select id="cbxSTR_Consistence" class="easyui-combobox" name="cbxSTR_Consistence"
                            style="width: 200px;">
                        </select>
                            Sort By:
                        <select id="cbxSort">
                            <option value=""></option>
                            <option value="Time_of_Revival">Time of Revival</option>
                            <option value="Time_of_Model_for_Transplant">Time of Model for Transplant </option>
                            <option value="CRYO_P">Cryo-P</option>
                            <option value="SNAP_FROZEN">Snap Frozen</option>
                            <option value="FFPE1">FFPE</option>
                        </select>
                            <br />
                            Dosing_Window:
                        <select id="cbxDosing_Window">
                            <option value=""></option>
                            <option value="Yes.">Yes.</option>
                        </select>
                            Ulceration_Label:
                        <input type="text" id="searchUlceration_Label" name="searchUlceration_Label" />
                        </div>
                    </div>
                    <a href="javascript:void();" class="easyui-linkbutton" iconcls="icon-search" onclick="getdgModelInfo();">Search</a>
                    <a href="javascript:void();" class="easyui-linkbutton" iconcls="icon-save" onclick="htmlExport1();" id="aExport1">Export</a>
                    <asp:Button ID="btnExport1" runat="server" Text="全部导出" OnClick="btnExport1_Click"
                        Style="display: none" />
                    <a href="javascript:void();" class="easyui-linkbutton" iconcls="icon-save" onclick="htmlExport2();"
                        id="aExport2">Export AnimalInfo</a>
                    <asp:Button ID="btnExport2" runat="server" Text="全部导出" OnClick="btnExport2_Click"
                        Style="display: none" />

                    <a href="javascript:void();" class="easyui-linkbutton" iconcls="icon-save" onclick="htmlExport3();" id="aExport3">ExportAll</a>
                    <asp:Button runat="server" ID="btnExport3" OnClick="btnExport3_Click"
                        Style="display: none" />
                    Note!:Cachexia Label(Cachexia>=50%;Slight BW loss0-50%;Normal<0)
                <%--   <a href="#" class="easyui-linkbutton" iconcls="icon-search" plain="true" onclick="gotoRespond();">
                ToRespond</a>--%>
                </div>
            </div>
        </div>
        <a id="w-searchGene" class="fancybox" href="#inline1"></a>
        <div id="inline1" style="width: 800px; height: 400px; display: none;">
            <label id="ContinueNote">
            </label>
            <table id="genegrid" cellpadding="0" cellspacing="0">
            </table>
        </div>
        <a id="no-results" class="fancybox" href="#inline2"></a>
        <div id="inline2" style="width: 300px; height: 100px; display: none;">
            <label id="lblnoResults">
            </label>
        </div>
        <a id="w-exportCol" class="fancybox" href="#exportCol"></a>
        <div id="exportCol" style="width: 300px; height: 200px; display: none;">
            Available Columns:<br />
            <select id="AvailableColumns" name="AvailableColumns" class="easyui-combotree" multiple
                style="width: 250px;">
            </select><br />
            <input id="btnConfirm" type="button" value="Confirm" onclick="confirm1();" />
        </div>
        <a id="w-exportCol2" class="fancybox" href="#exportCol2"></a>
        <div id="exportCol2" style="width: 300px; height: 200px; display: none;">
            Available Columns:<br />
            <select id="AvailableColumns2" name="AvailableColumns2" class="easyui-combotree"
                multiple style="width: 250px;">
            </select><br />
            <input id="btnConfirm2" type="button" value="Confirm" onclick="confirm2();" />
        </div>
    </form>
</body>
</html>
