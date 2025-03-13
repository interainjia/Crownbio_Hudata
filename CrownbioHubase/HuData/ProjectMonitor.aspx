<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ProjectMonitor.aspx.cs" Inherits="PDXmodelBase.HuData.ProjectMonitor" %>

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
    <link rel="stylesheet" type="text/css" href="/site_media/hudata/css/base.css" />
    <script type="text/javascript" src="../Common/css/persontree.js"></script>
    <link rel="stylesheet" type="text/css" href="../Common/easyui-1.3.2/themes/bootstrap/easyui.css" />
    <link rel="stylesheet" type="text/css" href="../Common/easyui-1.3.2/themes/icon.css" />
    <script type="text/javascript" src="/site_media/HuData/ProjectMonitor.js"></script>
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
            width: 12%;
        }
        .td_left
        {
            width: 12%;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <input id="hfmodel_ids" type="hidden" />
    <input id="hfMonitor_id" type="hidden" />
    <input id="Searchdata" type="hidden" />
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <div id="context" style="overflow-y:scroll ">
        <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional">
            <ContentTemplate>
                <div id="divMonitorImport" class="easyui-accordion">
                    <div id="MonitorImport" title="Edit" style="overflow: auto;">
                        <table width="100%" border="0" align="center" cellpadding="0" cellspacing="1" class="tb1">
                            <tr>
                                <td class="td_left">
                                    Major Project:
                                </td>
                                <td class="td_right">
                                    <label id="txtMajorProject">
                                    </label>
                                </td>
                                <td class="td_left">
                                    Sub Project:
                                </td>
                                <td class="td_right">
                                    <label id="txtSubProject">
                                    </label>
                                </td>
                                <td class="td_left">
                                   Model ID:
                                </td>
                                <td class="td_right" colspan="3">
                                    <label id="lblModelID">
                                    </label>
                                </td>
                            </tr>
                            <tr>
                                <td class="td_left">
                                    Table of Study Design
                                </td>
                                <td class="td_right">
                                      <a  class="easyui-linkbutton"  onclick="SetStudyDesign();" id="btnEditStudy">Edit</a>
                                      <a  class="easyui-linkbutton"  onclick="MoveToModelID();" id="btnMoveTo">Copy To</a>
                                     
                                   <select id="cbxToProject" class="easyui-combobox" name="cbxToProject" style="width: 150px;"> </select>
                                         <select id="cbxToModelID" name="cbxToModelID" class="easyui-combotree" multiple="multiple" style="width: 150px;">
                                    </select>
                                </td>
                              <td class="td_left">
                                    Tissue collection:
                                </td>
                                <td class="td_right">
                                          <a  class="easyui-linkbutton"  onclick="SetbtnCollection();" id="btnCollection">Edit</a>
                                </td>
                                <td class="td_left">
                                    Personnel:
                                </td>
                                <td class="td_right">
                                         <a  class="easyui-linkbutton"  onclick="SetbtnPersonnel();" id="btnPersonnel">Edit</a>
                                </td>
                                 <td class="td_left">
                                     Study location:</td>
                                <td class="td_right">
                                   <select id="txtROOM">
                                        <option value="BJ-146">BJ-146</option>
                                        <option value="BJ-150">BJ-150</option>
                                        <option value="BJ-152">BJ-152</option>
                                        <option value="BJ-153">BJ-153</option>
                                        <option value="BJ-180">BJ-180</option>
                                        <option value="BJ-181">BJ-181</option>
                                        <option value="BJ-182">BJ-182</option>
                                        <option value="BJ-188">BJ-188</option>
                                        <option value="BJ-189">BJ-189</option>
                                        <option value="BJ-190">BJ-190</option>
                                        <option value="TC-221">TC-221</option>
                                        <option value="TC-222">TC-222</option>
                                        <option value="TC-224">TC-224</option>
                                        <option value="TC-225">TC-225</option>
                                        <option value="TC-227">TC-227</option>
                                        <option value="TC-229">TC-229</option>
                                        <option value="TC-231">TC-231</option>
                                        <option value="TC-232">TC-232</option>
                                        <option value="TC-234">TC-234</option>
                                        <option value="TC-235">TC-235</option>
                                        <option value="TC-237">TC-237</option>
                                        <option value="TC-238">TC-238</option>
                                        <option value="TC-239">TC-239</option>
                                    </select></td>
                            </tr>
                          
                            <tr>
                               
                                <td class="td_left">
                                    
                                    Number of Animal Purchase:</td>
                                <td class="td_right">
                                      <input id="txtNumber_of_Animal_Purchase" />
                                </td>
                                 <td class="td_left">
                                    Number of Animal Inoculated:
                                </td>
                                <td class="td_right" >
                                    <input id="txtNumber_of_Animal_Inoculation" />
                                </td>
                                <td class="td_left">
                                    Arms:
                                </td>
                                <td class="td_right">
                                     <label id="txtArms">
                                    </label>
                                </td>
                               
                                 
                                 <td class="td_left">
                                   Sample Amount:
                                </td>
                                <td class="td_right" >
                                       <label id="txtSample_Amount">
                                    </label>
                                </td>
                            </tr>
                            <tr>
                                <td class="td_left">
                                    BW/TV Measure During Treatment:</td>
                                <td class="td_right">
                                    <select id="txtTumor_Monitor_Schedule">
                                     <option value=""></option>
                                <option value="TID">TID</option>
                                <option value="BID">BID</option>
                                <option value="QD">QD</option>
                                <option value="5 Days on and 2 days off">5 Days on and 2 days off</option>
                                <option value="Q2D">Q2D</option>
                                <option value="Q3D">Q3D</option>
                                <option value="Q4D">Q4D</option>
                                <option value="TIW">TIW</option>
                                <option value="BIW">BIW</option>
                                <option value="QW">QW</option>
                                <option value="Q2W">Q2W</option>
                                <option value="Q3W">Q3W</option>
                                 <option value="Once">Once</option>
                            </select></td>
                                <td class="td_left">
                                    BW/TV Measure During Observation:</td>
                                <td class="td_right">
                                  <select id="txtTumor_Monitor_Schedule2">
                                     <option value=""></option>
                                <option value="TID">TID</option>
                                <option value="BID">BID</option>
                                <option value="QD">QD</option>
                                <option value="5 Days on and 2 days off">5 Days on and 2 days off</option>
                                <option value="Q2D">Q2D</option>
                                <option value="Q3D">Q3D</option>
                                <option value="Q4D">Q4D</option>
                                <option value="TIW">TIW</option>
                                <option value="BIW">BIW</option>
                                <option value="QW">QW</option>
                                <option value="Q2W">Q2W</option>
                                <option value="Q3W">Q3W</option>
                                 <option value="Once">Once</option>
                            </select>
                                </td>
                                <td class="td_left">
                                    &nbsp;</td>
                                <td class="td_right">
                                    &nbsp;</td>
                                <td class="td_left">
                                    &nbsp;</td>
                                <td class="td_right">
                                    &nbsp;</td>
                            </tr>
                            <tr>
                                <td class="td_left">
                                    &nbsp;
                                </td>
                                <td class="td_right" colspan="7">
                                          <a  class="easyui-linkbutton"  onclick="SaveMonitor();" id="btnSave">Save</a>
                                                                            <input type="button" onclick="SaveMonitorAdd();" id="Button2"  class="button-push"
                                        value="SaveADD" style="display:none" />
                                </td>
                            </tr>
                        </table>
                    </div>
                </div>
            </ContentTemplate>
        </asp:UpdatePanel>
        <div id="tb2" style="padding: 5px; height: auto">
           <%-- <div style="margin-bottom: 5px">
                <table>
                    <tr>
                        <td>
                            <a id="Remove_id" href="#" class="easyui-linkbutton" iconcls="icon-remove" plain="true"
                                onclick="Remove();">Remove</a>
                        </td>
                    </tr>
                </table>
            </div>--%>
            <div style="margin-bottom: 5px">
                Model ID:
                <input id="searchModelID" name="searchModelID" type="text" />
                Project Number:
                <input id="searchProjectNumber" name="searchProjectNumber" type="text" />
                 JSD:
                <input id="searchJSD" name="searchJSD" type="text" />
                 PM:
                <input id="searchPM" name="searchPM" type="text" />
                DOI:
                <select id="searchDOI" name="searchDOI">
                    <option value=""></option>
                    <option value="Yes">Yes</option>
                    <option value="No">No</option>
                </select>
                    Completed Per Study:
                <select id="searchCompleted" name="searchCompleted">
                    <option value="No" selected="selected">No</option>
                    <option value="Yes">Yes</option>
                    <option value="All">All</option>
                </select><br />
             <%--   Is removed:<input id="cbx_isRemoved" type="checkbox" />--%>
                <a href="javascript:void();" class="easyui-linkbutton" iconcls="icon-search" onclick="getdgProjectMonitor();">
                    Search</a> <a href="javascript:void();" class="easyui-linkbutton" iconcls="icon-save" onclick="htmlExport_old();"
                        id="aExport1">Export</a>
                <asp:Button ID="btnExport1" runat="server" Text="全部导出" OnClick="btnExport1_Click"
                    Style="display: none" />
                <a id="btnPM_edit" class="easyui-linkbutton" href="javascript:void();" iconcls="icon-edit" name="btnPM_edit"
                    onclick="btnPM_edit();">PM Edit</a> <a id="btnJSD_edit" class="easyui-linkbutton"
                        href="javascript:void();" iconcls="icon-edit" name="btnJSD_edit" onclick="btnJSD_edit();">JSD Edit</a> <a id="btnComplete_study" class="easyui-linkbutton"
                        href="javascript:void();" iconcls="icon-edit" name="btnComplete_study" onclick="btnComplete_study();">Complete</a></div>
            </div>
           
            <table cellpadding="0" cellspacing="0" border="0" width="100%">
                <tr>
                    <td>
                        <table id="dgProjectMonitor" title="" data-options="toolbar:'#tb2'">
                        </table>
                    </td>
                </tr>
            </table>
          
    </div>
    <a id="w-study" class="fancybox" href="#divStudy"></a>
    <div id="divStudy" style="width: 800px; height: 400px; display: none;">
        <table id="dgStudy" width="100%" border="0" align="center" cellpadding="0" cellspacing="1"
            class="tb1">
            <%--  <tr>
                        <td class="td_left">
                            Group:
                        </td>
                        <td class="td_right" >
                            <input id="txtGroup" name="txtGroup" class="easyui-validatebox" validtype="integer" data-options="required:true" />
                        </td>
                        <td class="td_left">
                            Mice #/group:
                        </td>
                        <td class="td_right" >
                            <input id="txtMice_group" name="txtMice_group" class="easyui-validatebox" validtype="integer" data-options="required:true" />
                        </td>
                         <td class="td_left">
                            Dosing Route:
                        </td>
                        <td class="td_right" >
                            <select id="txtDosing_Route">
                                <option value="2.02">i.p.</option>
                                <option value="2.03">s.c.</option>
                                <option value="2.04">i.t.</option>
                                <option value="2.05">i.m.</option>
                                <option value="2.06">i.v.</option>
                                <option value="2.07">p.o.</option>
                            </select>
                        </td>
                      
                    </tr>
                    <tr>
                       <td class="td_left">
                            Dosing Schedule:
                        </td>
                        <td class="td_right" >
                             <select id="txtDosing_Schedule">
                                <option value="3">TID</option>
                                <option value="2">BID</option>
                                <option value="1">QD</option>
                                <option value="0.71">5 Days on and 2 days off</option>
                                <option value="0.5">Q2D</option>
                                <option value="0.33">Q3D</option>
                                <option value="0.25">Q4D</option>
                                <option value="0.43">Monday, Wednesday, Friday</option>
                                <option value="0.43">TIW</option>
                                <option value="0.29">BIW</option>
                                <option value="0.14">QW</option>
                                <option value="0.07">Q2W</option>
                                <option value="0.05">Q3W</option>
                            </select>
                        </td>
                        <td class="td_left">
                            Dosing_Period(weeks):
                        </td>
                        <td class="td_right" >
                            <input id="txtDosing_Period" name="txtDosing_Period " class="easyui-validatebox" validtype="integer" data-options="required:true" />
                        </td>
                        <td class="td_left" ></td>
                          <td class="td_right" colspan="9"><input id="btnSaveStudy" value="Add" type="button" onclick="SaveStudy();"/></td>
                    </tr>--%>
            <tr>
                <td class="td_left" style="width: 10%">
                    Study Design:
                </td>
                <td class="td_right" style="width: 90%">
                    <textarea id="txtImport" cols="20" rows="10" style="width: 100%; height: 100px;"></textarea>
                    <a target="_blank" href="../File/Template-StudyDesign.xlsx">Template</a>
                      <a  class="easyui-linkbutton"  onclick="SaveStudy();" id="btnSaveStudy">Add</a>
                        <a  class="easyui-linkbutton"  onclick="DelStudy();" id="btnSaveStudy">Delete</a>
                </td>
            </tr>
        </table>
        <table id="dgStudyDesign" cellpadding="0" cellspacing="0" style="width: 100%;">
        </table>
    </div>
    <a id="w-collection" class="fancybox" href="#divCollection"></a>
    <div id="divCollection" style="width: 400px; height: 400px; display: none;">
        <table id="Table1" width="100%" border="0" align="center" cellpadding="0" cellspacing="1"
            class="tb1">
            <tr>
                <td class="td_left">
                    FFPE Tumor Sample Number:
                </td>
                <td class="td_right">
                    <input id="txtFFPE" type="text" />
                </td>
            </tr>
            <tr>
                <td class="td_left">
                    Snap Frozne Sample Number:
                </td>
                <td class="td_right">
                    <input id="txtSnap" type="text" />
                </td>
            </tr>
            <tr>
                <td class="td_left">
                    Blood Sample Number(Plasma):
                </td>
                <td class="td_right">
                <input id="txtbloodnumber1" type="text" />
                </td>
            </tr>
            <tr>
                <td class="td_left">
                    Blood Sample Number(Serum):
                </td>
                <td class="td_right">
                    <input id="txtbloodnumber2" type="text" />
                </td>
            </tr>
             <tr>
                <td class="td_left">
                    Blood Sample Number(Whole Blood):
                </td>
                <td class="td_right">
                    <input id="txtbloodnumber3" type="text" />
                </td>
            </tr>
        </table>
    </div>
    <a id="w-Personnel" class="fancybox" href="#divPersonnel"></a>
    <div id="divPersonnel" style="width: 400px; height: 200px; display: none;">
        <table id="Table2" width="100%" border="0" align="center" cellpadding="0" cellspacing="1"
            class="tb1">
            <tr>
                <td class="td_left">
                    SD:
                </td>
                <td class="td_right">
                    <input id="txtSD" name="txtSD" style="width: 150px;" />
                   
                </td>
            </tr>
            <tr>
                <td class="td_left">
                    JSD:
                </td>
                <td class="td_right">
                    <select id="txtJSD" class="easyui-combobox" name="txtJSD" style="width: 150px;">
                    </select>
                </td>
            </tr>
            <tr>
                <td class="td_left">
                    DT group:
                </td>
                <td class="td_right">
                      <select id="txtDTgroup" class="easyui-combobox" name="txtDTgroup" style="width: 150px;">
                    </select>
                </td>
            </tr>
            <tr>
                <td class="td_left">
                    DT:
                </td>
                <td class="td_right">
                  <select id="ddlDT" name="ddlDT" class="easyui-combotree" multiple style="width: 150px;">
                                    </select>
                                      <input id="hfDT" type="hidden" />
                </td>
            </tr>
            <tr>
                <td class="td_left">
                    DM:
                </td>
                <td class="td_right">
                         <select id="txtDM" class="easyui-combobox" name="txtDM" style="width: 150px;">
                    </select>
                </td>
            </tr>
        </table>
    </div>
 
    <a id="w-PM_edit" class="fancybox" href="#divPM_edit"></a>
    <div id="divPM_edit" style="width: 400px; height: 400px; display: none;">
        <table id="Table4" width="100%" border="0" align="center" cellpadding="0" cellspacing="1"
            class="tb1">
            <tr>
                <td>
                    Project preparation
                </td>
            </tr>
            <tr>
                <td class="td_left">
                    Signed_Quotation:
                </td>
                <td class="td_right">
                    <input id="txtSigned_Quotation" class="easyui-datebox" data-options="formatter:myformatter"
                        editable="false" />
                </td>
            </tr>
            <tr>
                <td class="td_left">
                    Kickoff:
                </td>
                <td class="td_right">
                    <input id="txtKickoff" class="easyui-datebox" data-options="formatter:myformatter"
                        editable="false" />
                </td>
            </tr>
            <tr>
                <td class="td_left">
                    Register_Project:
                </td>
                <td class="td_right">
                    <input disabled="disabled" id="txtRegister_Project" class="easyui-datebox" data-options="formatter:myformatter"
                        editable="false" />
                </td>
            </tr>
            <tr>
                <td>
                    Project closure
                </td>
            </tr>
            <tr>
                <td class="td_left">
                    Tissue_Sent_Out:
                </td>
                <td class="td_right">
                    <input id="txtTissue_Sent_Out" class="easyui-datebox" data-options="formatter:myformatter"
                        editable="false" />
                </td>
            </tr>
            <tr>
                <td class="td_left">
                    Final_Data_Sent_Out:
                </td>
                <td class="td_right">
                    <input id="txtFinal_Data_Sent_Out" class="easyui-datebox" data-options="formatter:myformatter"
                        editable="false" />
                </td>
            </tr>
            <tr>
                <td class="td_left">
                    Document_Archieve:
                </td>
                <td class="td_right">
                    <input id="txtDocument_Archieve" class="easyui-datebox" data-options="formatter:myformatter"
                        editable="false" />
                </td>
            </tr>
            <tr>
                <td class="td_left">
                    Report_Sent_Out:
                </td>
                <td class="td_right">
                    <input id="txtReport_Sent_Out" class="easyui-datebox" data-options="formatter:myformatter"
                        editable="false" />
                </td>
            </tr>
            <tr>
                <td class="td_left">
                    Balance_Invoice_Sent_Out:
                </td>
                <td class="td_right">
                    <input id="txtBalance_Invoice_Sent_Out" class="easyui-datebox" data-options="formatter:myformatter"
                        editable="false" />
                </td>
            </tr>
            <tr>
                <td class="td_left">
                    &nbsp;
                </td>
                <td class="td_right">
                    <input type="button" onclick="SavePMedit();" id="SavePM-edit" name="SavePM-edit"
                        class="button-push" value="Save" />
                </td>
            </tr>
        </table>
    </div>
    <a id="w-JSD_edit" class="fancybox" href="#divJSD_edit"></a>
    <div id="divJSD_edit" style="width: 450px; height: 450px; display: none;">
        <table id="Table5" width="100%" border="0" align="center" cellpadding="0" cellspacing="1"
            class="tb1">
            <tr>
                <td>
                    Study Preparation
                </td>
            </tr>
            <tr>
                <td class="td_left">
                    Booking_Animals:
                </td>
                <td class="td_right">
                    <input id="txtBooking_Animals" class="easyui-datebox" data-options="formatter:myformatter"
                        editable="false" />
                </td>
            </tr>
            <tr>
                <td class="td_left">
                    Order_Animal:
                </td>
                <td class="td_right">
                    <input id="txtOrder_Animal" class="easyui-datebox" data-options="formatter:myformatter"
                        editable="false" />
                </td>
            </tr>
            <tr>
                <td class="td_left">
                    Finalize_Protocol:
                </td>
                <td class="td_right">
                    <input id="txtFinalize_Protocol" class="easyui-datebox" data-options="formatter:myformatter"
                        editable="false" />
                </td>
            </tr>
            <tr>
                <td>
                    Model development
                </td>
            </tr>
            <tr>
                <td class="td_left">
                    Provide_Seeding_Animal:
                </td>
                <td class="td_right">
                    <input id="txtProvide_Seeding_Animal" class="easyui-datebox" data-options="formatter:myformatter"
                        editable="false" disabled="disabled"/>
                </td>
            </tr>
            <tr>
                <td class="td_left">
                    Inoculation:
                </td>
                <td class="td_right">
                    <input id="txtInoculation" class="easyui-datebox" data-options="formatter:myformatter"
                        editable="false" />
                </td>
            </tr>
            <tr>
                <td>
                    Experiment
                </td>
            </tr>
            <tr>
                <td class="td_left">
                    Randomization:
                </td>
                <td class="td_right">
                    <input id="txtRandomization" class="easyui-datebox" data-options="formatter:myformatter"
                        editable="false" />
                </td>
            </tr>
            <tr>
                <td class="td_left">
                    Treatment_Start:
                </td>
                <td class="td_right">
                    <input id="txtTreatment_Start" class="easyui-datebox" data-options="formatter:myformatter"
                        editable="false" />
                </td>
            </tr>
            <tr>
                <td class="td_left">
                    Treatment_Finished:
                </td>
                <td class="td_right">
                    <input id="txtTreatment_Finished" class="easyui-datebox" data-options="formatter:myformatter"
                        editable="false" />
                </td>
            </tr>
            <tr>
                <td class="td_left">
                    Observation_Post_Treatment:
                </td>
                <td class="td_right">
                    <input id="txtObservation_Post_Treatment" class="easyui-datebox" data-options="formatter:myformatter"
                        editable="false" />
                </td>
            </tr>
            <tr>
                <td class="td_left">
                    Tissue_Collection:
                </td>
                <td class="td_right">
                    <input id="txtTissue_Collection" class="easyui-datebox" data-options="formatter:myformatter"
                        editable="false" />
                </td>
            </tr>
            <tr>
                <td class="td_left">
                    &nbsp;
                </td>
                <td class="td_right">
                    <input type="button" onclick="SaveJSDedit();" id="Button1" name="SaveJSD_edit" class="button-push"
                        value="Save" />
                </td>
            </tr>
        </table>
    </div>

       <a id="w-Provide" class="fancybox" href="#divProvide"></a>
    <div id="divProvide" style="width:500px; height: 700px; display: none;">
         <table id="Table3" width="100%" border="0" align="center" cellpadding="0" cellspacing="1"
            class="tb1">
            <tr><td>
Tissue bank provide</td></tr>
<tr>
                 <td class="td_left">
                    Tissue batch #:
                </td>
                 <td class="td_right">
                    <input id="lblTissue_Batch" type="text" />
                    </td>
            </tr>
            <tr>
                 <td class="td_left">
                    Date of tissue collection:
                </td>
                 <td class="td_right">
                    <input id="txtDate_of_Tissue" class="easyui-datebox" data-options="formatter:myformatter"
                        editable="false" />
                    </td>
            </tr>
             <tr>
                 <td class="td_left">
                    Animal #:
                </td>
                 <td class="td_right">
                     <input type="text" id="txtAnimal_by_Tissue" />
                    </td>
            </tr>
           <tr><td>
Live animal provide</td></tr>
            <tr>
                 <td class="td_left">
                    Source Project #:
                </td>
                 <td class="td_right">
                    <label id="lblSourceProject">
                    </label>
                    </td>
            </tr>
            <tr>
                  <td class="td_left">
                    Mt. Leader/JSD:
                </td>
                 <td class="td_right">
                    <label id="lblLeader">
                    </label>
                </td>
            </tr>
            <tr>
                  <td class="td_left">
                    Model batch #:
                </td>
                  <td class="td_right">
                    <label id="lblModelbatch1">
                    </label>
                </td>
            </tr>
            <tr>
                  <td class="td_left">
                    Animal #:
                </td>
                <td class="td_right">
                    <label id="lblAnimal_by_Live">
                    </label>
                </td>
            </tr>
            <tr>
                  <td class="td_left">
                    IVC:
                </td>
                 <td class="td_right">
                    <label id="IVC">
                    </label>
                </td>
            </tr>
            <tr>
                 <td class="td_left">
                    Expected date to support:
                </td>
                 <td class="td_right">
                    <label id="lblDOT">
                    </label>
                </td>
            </tr>
            <tr>
                 <td class="td_left">
                    Date of deliver:
                </td>
                 <td class="td_right">
                    <input type="button" value="Add" onclick="add_allDeliver();"/>
                        <div id="allDeliver"></div>
                </td>
            </tr>
            <tr><td class="td_left">&nbsp;</td><td class="td_right">&nbsp;</td></tr>
            <tr>
                 <td class="td_left">
                    Receiving Project:
                </td>
                <td class="td_right">
                    <label id="lblReceivingProject">
                    </label>
                </td>
            </tr>
            <tr>
                <td class="td_left">
                    Mt. Leader/JSD:
                </td>
               <td class="td_right">
                    <label id="lblJSD">
                    </label>
                </td>
            </tr>
            <tr>
                 <td class="td_left">
                    Model batch #:
                </td>
                  <td class="td_right">
                    <label id="lblModelbatch2">
                    </label>
                </td>
            </tr>
            <tr>
                  <td class="td_left">
                    Healthy and alive:
                </td>
                 <td class="td_right">
                    <input type="text" id="txtAlive" />
                   
                </td>
            </tr>
            <tr>
              <td class="td_left">
                    Animal dead:
                </td>
                 <td class="td_right">
                  <label id="txtDead"></label>
                   
                </td>
            </tr>
            <tr>
                 <td class="td_left">
                    Date of receive:
                </td>
                   <td class="td_right">
                    <input type="button" value="Add" onclick="add_allReceive();"/>
                        <div id="allReceive"></div>
                </td>
            </tr>
            <tr>
                  <td class="td_left">
                    Inoculation used:
                </td>
                 <td class="td_right">
                    <input type="text" id="txtInoculation_Used" />
               
                </td>
            </tr>
            <tr>
                 <td class="td_left">
                    Tissue collection/discard:
                </td>
                 <td class="td_right">
                    <label id="txtTissue" ></label>

                </td>
            </tr>
            <tr>
               <td class="td_left"></td>
                  <td class="td_right">   <input type="button" onclick="SaveAnimal_Handover();" id="btnSaveAnimal_Handover" name="btnSaveAnimal_Handover"
            value="Save" />
                      <input id="hfAnimal_Handover_mid" type="hidden" />
                       <input id="hfAnimal_Handover_rid" type="hidden" />
            </td>
            </tr>
        </table>
    </div>
    </form>
</body>
</html>
