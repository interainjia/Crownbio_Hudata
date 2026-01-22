<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Revival.aspx.cs" Inherits="PDXmodelBase.HuData.Revival" %>

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
    <script type="text/javascript" src="/site_media/HuData/Revival.js?V=2.4"></script>
    <script type="text/javascript" src="/site_media/HuData/export.js"></script>
    <script type="text/javascript" src="../Common/fancyBox/source/jquery.fancybox.js?v=2.1.4"></script>
    <link rel="stylesheet" type="text/css" href="../Common/fancyBox/source/jquery.fancybox.css?v=2.1.4"
        media="screen" />
    <link rel="stylesheet" type="text/css" href="../Common/css/hudataform.css" />
    <link rel="stylesheet" type="text/css" href="../Common/uploadifive-v1.2.2-standard/uploadifive.css" />

    <%--<script type='text/javascript' src="../Common/uploadifive-v1.2.2-standard/Sample/jquery.min.js"></script>--%>
    <script type='text/javascript' src="../Common/uploadifive-v1.2.2-standard/jquery.uploadifive.js"></script>

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
        <input id="Searchdata" type="hidden" />
        <input id="hfRevival_ID" type="hidden" />
        <input id="rid" type="hidden" />
        <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>
        <div id="context" style="overflow-y: scroll">
            <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional">
                <ContentTemplate>
                    <div id="divRevivalImport" class="easyui-accordion">
                        <div id="RevivalImport" title="Edit" style="overflow: auto;">
                            <table width="100%" border="0" cellpadding="0" cellspacing="1" class="tb1">
                                <tr>
                                    <td class="td_left">sq1#:<span style="color: Red">*</span>
                                    </td>
                                    <td class="td_right">
                                        <input id="txtsq1" class="easyui-validatebox" data-options="required:true"></input>
                                    </td>
                                    <td class="td_left">Sq#:<span style="color: Red">*</span>
                                    </td>
                                    <td class="td_right">
                                        <input id="txtSq" class="easyui-validatebox" data-options="required:true"></input>
                                    </td>
                                    <td class="td_left">CancerType:
                                    </td>
                                    <td class="td_right">
                                        <input id="txtCancerType"></input>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="td_left">ModelID:<span style="color: Red">*</span>
                                    </td>
                                    <td class="td_right">
                                        <input id="txtModelID" class="easyui-validatebox" data-options="required:true"></input>
                                    </td>
                                    <td class="td_left">Date_of_Tissue_collection;
                                    </td>
                                    <td class="td_right">
                                        <input id="txtDate_of_Tissue_collection" class="easyui-datebox" data-options="formatter:myformatter"
                                            editable="false" />
                                    </td>
                                    <td class="td_left">Batch_of_cryo_p_tissue
                                    </td>
                                    <td class="td_right">
                                        <input id="txtBatch_of_cryo_p_tissue"></input>

                                    </td>
                                </tr>
                                <tr>
                                    <td class="td_left">Date_of_Revival:
                                    </td>
                                    <td class="td_right">
                                        <input id="txtDate_of_Revival" class="easyui-datebox" data-options="formatter:myformatter"
                                            editable="false" />
                                    </td>
                                    <td class="td_left">Duration_in_LiN2:
                                    </td>
                                    <td class="td_right">
                                        <input id="txtDuration_in_LiN2" disabled="disabled"></input>
                                    </td>
                                    <td class="td_left">Location:
                                    </td>
                                    <td class="td_right">
                                        <input id="txtLocation"></input>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="td_left">Pre_Rn
                                    </td>
                                    <td class="td_right">
                                        <input id="txtPre_Rn"></input>
                                    </td>
                                    <td class="td_left">Rn:
                                    </td>
                                    <td class="td_right">
                                        <input id="txtRn"></input>
                                    </td>
                                    <td class="td_left">Pn:
                                    </td>
                                    <td class="td_right">
                                        <input id="txtPn"></input>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="td_left">Rn_match
                                    </td>
                                    <td class="td_right">
                                        <input id="txtRn_match" disabled="disabled"></input>
                                    </td>
                                    <td class="td_left">Animal_Strain:
                                    </td>
                                    <td class="td_right">
                                        <select id="txtAnimal_Strain">
                                            <option value="Balb/c nu">Balb/c nu</option>
                                            <option value="B-NSG">B-NSG</option>
                                            <option value="CB17.SCID">CB17.SCID</option>
                                            <option value="C-NKG">C-NKG</option>
                                            <option value="HGF">HGF</option>
                                            <option value="NCG">NCG</option>
                                            <option value="NOD.SCID">NOD.SCID</option>
                                            <option value="NOG">NOG</option>
                                            <option value="NPG">NPG</option>
                                            <option value="NPSG">NPSG</option>
                                            <option value="NSG">NSG</option>
                                            <option value="NTG">NTG</option>
                                        </select>
                                    </td>
                                    <td class="td_left">Animal_Quantity:
                                    </td>
                                    <td class="td_right">
                                        <input id="txtAnimal_Quantity"></input>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="td_left">Date_of_Revival_suceeded
                                    </td>
                                    <td class="td_right">
                                        <input id="txtDate_of_Revival_suceeded" class="easyui-datebox" data-options="formatter:myformatter"
                                            editable="false" />
                                    </td>
                                    <td class="td_left">Outcome:
                                    </td>
                                    <td class="td_right">
                                        <select id="txtOutcome">
                                            <option value="On going">On going</option>
                                            <option value="Succeeded">Succeeded</option>
                                            <option value="Failed">Failed</option>
                                            <option value=""></option>
                                        </select>
                                    </td>
                                    <td class="td_left">Duration_of_Revival:
                                    </td>
                                    <td class="td_right">
                                        <input id="txtDuration_of_Revival" disabled="disabled"></input>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="td_left">Study
                                    </td>
                                    <td class="td_right">
                                        <input id="txtStudy"></input>
                                    </td>
                                    <td class="td_left">Project_No:
                                    </td>
                                    <td class="td_right">
                                        <input id="txtProject_No"></input>
                                    </td>
                                    <td class="td_left">Comment:
                                    </td>
                                    <td class="td_right">
                                        <input id="txtComment"></input>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="td_left">Pre_Recovery_Pathogen
                                    </td>
                                    <td class="td_right">
                                        <input id="txtPre_Recovery_Pathogen"></input>
                                    </td>
                                    <td class="td_left">Recovery_Pathogen:
                                    </td>
                                    <td class="td_right">
                                        <input id="txtRecovery_Pathogen"></input>
                                    </td>
                                    <td class="td_left">Implantation_Pathogen:
                                    </td>
                                    <td class="td_right">
                                        <input id="txtImplantation_Pathogen"></input>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="td_left">Recovery_SNP
                                    </td>
                                    <td class="td_right">
                                        <input id="txtRecovery_SNP"></input>
                                    </td>
                                    <td class="td_left">Implantation_SNP:
                                    </td>
                                    <td class="td_right">
                                        <input id="txtImplantation_SNP"></input>
                                    </td>
                                    <td class="td_left">Time_of_Update:
                                    </td>
                                    <td class="td_right">
                                        <input id="txtTime_of_Update" class="easyui-datebox" data-options="formatter:myformatter"
                                            editable="false" disabled="disabled" />
                                    </td>
                                </tr>
                                <tr>
                                    <td class="td_left">Name_of_Update
                                    </td>
                                    <td class="td_right">
                                        <input id="txtName_of_Update" disabled="disabled"></input>
                                    </td>
                                    <td class="td_left">&nbsp;
                                    </td>
                                    <td class="td_right">&nbsp;
                                    </td>
                                    <td class="td_left">&nbsp;
                                    </td>
                                    <td class="td_right">&nbsp;
                                    </td>
                                </tr>
                                <tr>
                                    <td class="td_left">&nbsp;
                                    </td>
                                    <td class="td_right">&nbsp;
                                       <a class="easyui-linkbutton" onclick="AddNew_model();">Add</a>
                                        <input id="Reset1" type="reset" value="reset" style="display: none" />
                                        <a class="easyui-linkbutton" onclick="Check();">Save</a>
                                    </td>
                                    <td class="td_left">&nbsp;
                                    </td>
                                    <td class="td_right">&nbsp;</td>
                                    <td class="td_left">&nbsp;
                                    </td>
                                    <td class="td_right">&nbsp;</td>
                                </tr>
                            </table>
                        </div>
                    </div>
                </ContentTemplate>
            </asp:UpdatePanel>
            <table cellpadding="0" cellspacing="0" border="0" width="100%">
                <tr>
                    <td>
                        <table id="dgRevival" title="" data-options="toolbar:'#tb'">
                        </table>
                    </td>
                </tr>
            </table>
            <div id="tb" style="padding: 0px; height: auto; width: 100%">
                <div style="margin-bottom: 5px">
                    Sq#:
                <input id="S_Sq" name="S_Sq" type="text" />
                    Model ID:<input id="S_ModelID" name="S_ModelID" type="text" />
                    <div id="divMoreSearch" class="easyui-accordion">
                        <div id="MoreSearch" title="Advancad Search" style="overflow: auto;">
                            Location:
                        <input id="S_Location" name="S_Location" type="text" />
                            Rn：
                        <input id="s_Rn" name="s_Rn" type="text" />
                            Pn：
                        <input id="s_Pn" name="s_Pn" type="text" />
                            Animal_Strain:
                       <select id="s_Animal_Strain">
                           <option value="All">All</option>
                           <option value="Balb/c nu">Balb/c nu</option>
                           <option value="B-NSG">B-NSG</option>
                           <option value="CB17.SCID">CB17.SCID</option>
                           <option value="HGF">HGF</option>
                           <option value="NCG">NCG</option>
                           <option value="NOD.SCID">NOD.SCID</option>
                           <option value="NOG">NOG</option>
                           <option value="NPG">NPG</option>
                           <option value="NPSG">NPSG</option>
                           <option value="NSG">NSG</option>
                           <option value="NTG">NTG</option>
                       </select>
                            Outcome:
                       <select id="s_Outcome">
                           <option value="All">All</option>
                           <option value="On going">On going</option>
                           <option value="Succeeded">Succeeded</option>
                           <option value="Failed">Failed</option>
                           <option value=""></option>
                       </select>
                        </div>
                    </div>
                    <a href="javascript:void();" class="easyui-linkbutton" iconcls="icon-search" onclick="getdgRevival();">Search</a>
                    <a id="aExport3" class="easyui-linkbutton" href="javascript:void();" iconcls="icon-save" onclick="htmlExport_old3();">Export</a>
                    <asp:Button ID="btnExport3" runat="server" OnClick="btnExport3_Click" Style="display: none"
                        Text="全部导出" />
                    <a id="btndelete" name="btndelete" href="javascript:void();" class="easyui-linkbutton" iconcls="icon-cancel"
                        onclick="deleteRevival();">Delete</a>
                    <%=btnImport%>
                </div>
            </div>
        </div>
        <a id="w-importIC50" class="fancybox" href="#divImportFile1"></a>
        <div id="divImportFile1" style="width: 600px; height: 200px; display: none;">
            <input type="file" name="uploadify1" id="uploadify1" /><br />
            <button id="btn_Upload01" value="Upload" class="easyui-linkbutton" onclick="javascript:$('#uploadify1').uploadifive('upload')">
                upload
            </button>
            &nbsp;
    <button id="btn_close1" value="Close" class="easyui-linkbutton" onclick="closeWindow();">
        Close
    </button>
            <div id="fileQueue1">
            </div>
        </div>
    </form>
</body>
</html>
