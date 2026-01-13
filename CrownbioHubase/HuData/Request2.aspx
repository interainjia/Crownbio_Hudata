<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Request2.aspx.cs" Inherits="PDXmodelBase.HuData.Request2" %>

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
    <script type="text/javascript" src="/site_media/HuData/request2.js?v=3.1"></script>
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
        <input id="compared_objects_list" name="compared_objects_list" type="hidden" value="" />
        <input id="hfmodel_ids" type="hidden" />
        <input id="hfRequest_id" type="hidden" />
        <input id="Searchdata" type="hidden" />
        <input id="hfPN" type="hidden" />
        <input id="hfNoliveAnimal" type="hidden" />
        <input id="book_MODEL_ID" type="hidden" />
        <input id="hfSub-Project" type="hidden" />
        <input id="rid" type="hidden" />
        <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>
        <div id="context" style="overflow-y: scroll">
            <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional">
                <ContentTemplate>
                    <div id="divRequestImport" class="easyui-accordion">
                        <div id="requestImport" title="Edit" style="overflow: auto;">
                            <table width="100%" border="0" cellpadding="0" cellspacing="1" class="tb1">
                                <tr>
                                    <td class="td_left">Sponsor:
                                    </td>
                                    <td class="td_right">
                                        <input id="txtClient" name="txtClient" style="width: 150px;"></input>
                                    </td>
                                    <td class="td_left">Major Project:
                                    </td>
                                    <td class="td_right">
                                        <input id="txtParent_Project"></input>
                                    </td>
                                    <td class="td_left">Sub-Project:<span style="color: Red">*</span>
                                    </td>
                                    <td class="td_right">
                                        <input id="txtProjectNumber"  class="easyui-validatebox" data-options="required:true"></input>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="td_left">BD:
                                    </td>
                                    <td class="td_right">
                                        <select id="ccBD" class="easyui-combobox" name="ccBD" style="width: 150px;">
                                        </select>
                                    </td>
                                    <td class="td_left">Leading SD:
                                    </td>
                                    <td class="td_right">
                                        <select id="ccLeading_SD" class="easyui-combobox" name="ccLeading_SD" style="width: 150px;">
                                        </select>
                                    </td>
                                    <td class="td_left">Executive SD:
                                    </td>
                                    <td class="td_right">
                                        <select id="ccSD" class="easyui-combobox" name="ccSD" style="width: 150px;">
                                        </select>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="td_left">Date of Request:<span style="color: Red">*</span>
                                    </td>
                                    <td class="td_right">
                                        <input id="txtDate_of_Request" class="easyui-datebox" data-options="formatter:myformatter,required:true"
                                            editable="false" />
                                    </td>
                                    <td class="td_left">Type of Study:<span style="color: Red">*</span>
                                    </td>
                                    <td class="td_right">
                                        <select id="txtType_of_Study" class="easyui-combobox" name="txtType_of_Study" style="width: 150px;">
                                        </select>
                                    </td>
                                    <td class="td_left"></td>
                                    <td class="td_right"></td>
                                </tr>
                                <tr>
                                    <td class="td_left">Cancer Type:
                                    </td>
                                    <td class="td_right">
                                        <select id="ddlTumor_Type" class="easyui-combobox" name="ddlTumor_Type" style="width: 150px;">
                                        </select>
                                    </td>
                                    <td class="td_left">Subtype1:
                                    </td>
                                    <td class="td_right">
                                        <select id="ddlSubtype1" name="ddlSubtype1" class="easyui-combotree" multiple style="width: 250px;">
                                        </select>
                                    </td>
                                    <td class="td_left">Subtype2:
                                    </td>
                                    <td class="td_right">
                                        <select id="ddlSubtype2" name="ddlSubtype2" class="easyui-combotree" multiple style="width: 250px;">
                                        </select>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="td_left">Model ID:
                                    </td>
                                    <td class="td_right">
                                        <textarea id="txtModelID" name="txtModelID" cols="20" rows="10" style="width: 75%"></textarea>
                                        <a class="easyui-linkbutton" onclick="ConvertMid();" id="btnConvert">Convert</a>
                                    </td>
                                    <td class="td_left">Potential Study Size:
                                    </td>
                                    <td class="td_right">
                                        <input id="txtPotential_Study_Size" class="easyui-numberbox" />
                                    </td>
                                    <td class="td_left">Special Requirements:
                                    </td>
                                    <td class="td_right">
                                        <input id="txtRequirements" style="width: 250px" type="text" />
                                    </td>
                                </tr>
                                <tr>
                                    <td class="td_left">Completed Model ID:
                                    </td>
                                    <td class="td_right">
                                        <textarea id="txtCOMPLETED_MODEL_ID" cols="20" name="txtCOMPLETED_MODEL_ID" rows="5"
                                            style="width: 75%"></textarea>
                                    </td>
                                    <td class="td_left">Date of 1st responding:
                                    </td>
                                    <td class="td_right">
                                        <input id="txtDate_of_1st_responding" class="easyui-datebox" data-options="formatter:myformatter"
                                            editable="false" />
                                    </td>
                                    <td class="td_left">Remark:
                                    </td>
                                    <td class="td_right">
                                        <textarea id="editRemark" cols="45" rows="3"></textarea>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="td_left">Import:
                                    </td>
                                    <td class="td_right" colspan="5">
                                        <textarea id="txtImport" cols="20" rows="10" style="width: 90%; height: 61px;"></textarea>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="td_left">&nbsp;
                                    </td>
                                    <td class="td_right"  colspan="5">&nbsp;
                                       <a class="easyui-linkbutton" onclick="Add();">Add</a>
                                        <a class="easyui-linkbutton" onclick="Check();" id="btnSend3">Save</a>
                                        <asp:Button ID="btnSend2" runat="server" OnClick="btnSend_OnClick" Style="display: none" />
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
            <table cellpadding="0" cellspacing="0" border="0" width="100%">
                <tr>
                    <td>
                        <table id="dgRequest" title="" data-options="toolbar:'#tb'">
                        </table>
                    </td>
                </tr>
            </table>
            <div id="tb" style="padding: 0px; height: auto; width: 100%">
                <div style="margin-bottom: 5px">
                    Sponsor:
                <input id="searchSponsor" name="searchSponsor" type="text" />
                    AX code:
                <input id="searchAXcode" name="searchAXcode" type="text" />
                    Project Number:
                <input id="searchProjectNumber" name="searchProjectNumber" type="text" />
                    BD:
                <input id="searchBD" name="searchBD" type="text" />
                    SD:
                <input id="searchSD" name="searchSD" type="text" />
                    PM:
                <input id="searchPM" name="searchPM" type="text" />
                    <div id="divMoreSearch" class="easyui-accordion">
                        <div id="MoreSearch" title="Advancad Search" style="overflow: auto;">
                            Model ID:
                        <input id="searchModelID" name="searchModelID" type="text" />
                            Request Status：
                        <select id="searchSigned">
                            <option value="All">All</option>
                            <option value="Request only">Request only</option>
                            <option value="Signed">Signed</option>
                            <option value="Cancelled">Cancelled</option>
                            <option value="Postponed">Postponed</option>
                        </select>
                            Request ID:
                        <input id="searchRequestID" name="searchRequestID" type="text" />
                        </div>
                    </div>
                    <a href="javascript:void();" class="easyui-linkbutton" iconcls="icon-search" onclick="getdgRequest();">Search</a> <a id="aExport1" class="easyui-linkbutton" href="javascript:void();" iconcls="icon-save"
                        onclick="htmlExport1();">Export</a>
                    <asp:Button ID="btnExport1" runat="server" OnClick="btnExport1_Click" Style="display: none"
                        Text="全部导出" />
                    <a id="btndelete" name="btndelete" href="javascript:void();" class="easyui-linkbutton" iconcls="icon-cancel"
                        onclick="deleteRequest();">Delete</a>
                </div>
            </div>
            <div id="tb2" style="padding: 5px; height: auto;">
                <div style="margin-bottom: 5px;">
                    Model ID:
                <input id="part2Model_ID" name="part2Model_ID" type="text" />
                    Project Number:
                <input id="part2ProjectN" name="part2ProjectN" type="text" />
                    Have Animals:<select id="part2HaveAnimals">
                        <option value=""></option>
                        <option value="Yes">Yes</option>
                        <option value="No">No</option>
                    </select>
                    <a href="javascript:void();" class="easyui-linkbutton" iconcls="icon-search" onclick="getdgSelectMice();">Search</a> <a href="javascript:void();" class="easyui-linkbutton" iconcls="icon-save" onclick="htmlExport2();"
                        id="aExport2">Export</a>
                    <asp:Button ID="btnExport2" runat="server" Text="全部导出" OnClick="btnExport2_Click"
                        Style="display: none" />
                    <%--     <a href="#" class="easyui-linkbutton" iconcls="icon-save" onclick="Sendmail2();"
                                                                            id="Sendmail" >Sendmail</a>
                                                                         
                                                                          <asp:Button ID="btnSendmail" runat="server" Text="全部导出" OnClick="btnSendmail_Click" 
                                                                            Style="display: none" />--%>
                    <div id="divTosubject">
                        To SubProject:
                    <input id="ddlSubproject" name="ddlSubproject" type="text" />
                        <input id="hfexport" type="hidden" runat="server" />
                        <a id="btnMoveTo" class="easyui-linkbutton" href="javascript:void();" iconcls="icon-redo" name="btnMoveTo"
                            onclick="MoveToProject();">Move</a>
                    </div>
                </div>
            </div>
            <table cellpadding="0" cellspacing="0" border="0" width="100%">
                <tr>
                    <td>
                        <table id="dgSelectMice" title="" data-options="toolbar:'#tb2'">
                        </table>
                    </td>
                </tr>
            </table>
        </div>
        <a id="w-editRequest" class="fancybox" href="#inline1"></a>
        <div id="inline1" style="width: 400px; height: 100px; display: none;">
            <table cellpadding="0" cellspacing="0" border="0">
                <tr>
                    <td class="td_left">Sponsor:
                    </td>
                    <td class="td_right">
                        <input id="editSponsor" style="width: 150px;" />
                    </td>
                </tr>
                <tr>
                    <td class="td_left">PM:
                    </td>
                    <td class="td_right">
                        <select id="ccPM" class="easyui-combobox" name="ccPM" style="width: 150px;">
                        </select>
                    </td>
                </tr>
                <tr>
                    <td class="td_left">Request Status：
                    </td>
                    <td class="td_right">
                        <select id="txtSigned">
                            <option value="Request only">Request only</option>
                            <option value="Signed">Signed</option>
                            <option value="Cancelled">Cancelled</option>
                            <option value="Postponed">Postponed</option>
                        </select>
                    </td>
                </tr>
            </table>
            <div style="float: right; padding-top: 10px; padding-right: 5px;">
                <a id="btnSave1" class="easyui-linkbutton" onclick="SavePM_Edit();">Save</a>
            </div>
        </div>
        <a id="no-results" class="fancybox" href="#inline2"></a>
        <div id="inline2" style="width: 300px; height: 100px; display: none;">
            <label id="lblnoResults">
            </label>
        </div>
        <a id="w-AnimalStatus" class="fancybox" href="#divAnimalStatus"></a>
        <div id="divAnimalStatus" style="width: 800px; height: 500px; display: none;">
            <label id="lblmodel"></label>
            <br />
            Animal Booking:<input id="txtAnimal_Booking" name="txtAnimal_Booking" type="text" />
            Further Expanding:<input id="txtFurther_expanding" name="txtFurther_expanding" type="text" />
            Revive:<input id="txtRevive" name="txtRevive" type="text" />
            <input id="hfAnimal_Number" type="hidden" />
            <a id="btnSaveBooking" class="easyui-linkbutton" onclick="SaveBooking();">Save</a>
            <br />
            <table id="dgAnimalStatus" cellpadding="0" cellspacing="0">
            </table>
        </div>
        <a id="w-Log" class="fancybox" href="#divLogRequest"></a>
        <div id="divLogRequest" style="width: 800px; height: 500px; display: none;">
            <table id="dgRequestLog" cellpadding="0" cellspacing="0">
            </table>
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
        <a id="w-Piggybacked" class="fancybox" href="#divPiggybacked"></a>
        <div id="divPiggybacked" style="width: 200px; height: 100px; display: none;">
            <table id="Table1" cellpadding="0" cellspacing="0">
                <tr>
                    <td>Piggybacked by:<input id="txtPiggybacked" name="txtPiggybacked" type="text" />
                    </td>
                    <td>
                        <a id="btnSavePiggybacked" class="easyui-linkbutton" onclick="SavePiggybacked();">Save</a>
                    </td>
                </tr>
                <tr>
                    <td>
                        <input id="hfMid" type="hidden" />
                        <input id="hfRid" type="hidden" />
                        <input id="hfsubProject" type="hidden" />
                    </td>
                </tr>
            </table>
        </div>

    </form>
</body>
</html>
