<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="EndModels.aspx.cs" Inherits="PDXmodelBase.HuData.EndModels" %>

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
    <script type="text/javascript" src="/site_media/HuData/EndModels.js"></script>
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
    <input id="hfEndModels_ID" type="hidden" />
    <input id="rid" type="hidden" />
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <div id="context" style="overflow-y: scroll">
        <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional">
            <ContentTemplate>
                <div id="divEndModelsImport" class="easyui-accordion">
                    <div id="EndModelsImport" title="Edit" style="overflow: auto;">
                        <table width="100%" border="0" cellpadding="0" cellspacing="1" class="tb1">
                            <tr>
                                <td class="td_left">
                                    LEADER:<span style="color: Red">*</span>
                                </td>
                                <td class="td_right">
                                    <input id="txtLEADER" class="easyui-validatebox" data-options="required:true" ></input>
                                </td>
                                <td class="td_left">
                                    Model ID:
                                </td>
                                <td class="td_right">
                                     <input id="txtGROUP_NAME"></input>
                                </td>
                                <td class="td_left">
                                    RN:
                                </td>
                                <td class="td_right">
                                   <input id="txtRN"></input>
                                </td>
                            </tr>
                            <tr>
                                <td class="td_left">
                                    PN:
                                </td>
                                <td class="td_right">
                                    <input id="txtPN"></input>
                                </td>
                                <td class="td_left">
                                    Date of Passage inoculation;
                                </td>
                                <td class="td_right">
                                     <input id="txtHUSBANDRY_START" class="easyui-datebox" data-options="formatter:myformatter"
                                        editable="false" />
                                </td>
                                <td class="td_left">
                                    Date of Passage Termaination
                                </td>
                                <td class="td_right">
                                      <input id="txtDATE_OF_DEAD" class="easyui-datebox" data-options="formatter:myformatter"
                                        editable="false" />
                                </td>
                            </tr>
                            <tr>
                                <td class="td_left">
                                    LOCATION:
                                </td>
                                <td class="td_right">
                                    <input id="txtLOCATION"></input>
                                </td>
                                <td class="td_left">
                                    IVC:
                                </td>
                                <td class="td_right">
                                      <input id="txtIVC"></input>
                                </td>
                                <td class="td_left">
                                    REVIVAL:
                                </td>
                                <td class="td_right">
                                   <input id="txtREVIVAL"></input>
                                </td>
                            </tr>
                            <tr>
                                <td class="td_left">
                                    ANIMAL
                                </td>
                                <td class="td_right">
                                    <input id="txtANIMAL"></input>
                                </td>
                                <td class="td_left">
                                    COMMENTS:
                                </td>
                                <td class="td_right">
                                    <input id="txtCOMMENTS"></input>
                                </td>
                                <td class="td_left">
                                  DATE_OF_UPDATE:
                                </td>
                                <td class="td_right">
                                   <input id="txtDATE_OF_UPDATE" disabled="disabled"></input>
                                </td>
                            </tr>
                        
                            <tr>
                                <td class="td_left">
                                    &nbsp;
                                </td>
                                <td class="td_right">
                                    &nbsp;
                                       <a  class="easyui-linkbutton"  onclick="AddNew_model();">Add</a>
                                         <input id="Reset1" type="reset" value="reset" style="display: none" />
                                       <a  class="easyui-linkbutton"  onclick="Check();">Save</a>
                                </td>
                                <td class="td_left">
                                    &nbsp;
                                </td>
                                <td class="td_right">&nbsp;</td>
                                <td class="td_left">
                                    &nbsp;
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
                    <table id="dgEndModels" title="" data-options="toolbar:'#tb'">
                    </table>
                </td>
            </tr>
        </table>
        <div id="tb" style="padding: 0px; height: auto;width:100%">
            <div style="margin-bottom: 5px">
                Animal:
                <input id="S_Animal" name="S_Animal" type="text" />
                  Model ID:<input id="S_GroupName" type="text" />
                <div id="divSearch" class="easyui-accordion">
                <div id="AdvancadSearch" title="Advancad Search" style="overflow: auto;">
                    Leader:<input id="S_Leader" type="text" />
                    Rn:<input id="S_Rn" type="text" />
                    Pn:<input id="S_Pn" type="text" />
                    Location:<input id="S_Location" type="text" />
                    IVC:<input id="S_IVC" type="text" />
                  </div>
            </div>
                <a href="javascript:void();" class="easyui-linkbutton" iconcls="icon-search" onclick="getdgEndModels();">
                    Search</a> <a id="aExport1" class="easyui-linkbutton" href="javascript:void();" iconcls="icon-save"
                        onclick="htmlExport_old();">Export</a>
                <asp:Button ID="btnExport1" runat="server" OnClick="btnExport1_Click" Style="display: none"
                    Text="全部导出" />
                <a id="btndelete" name="btndelete" href="javascript:void();" class="easyui-linkbutton" iconcls="icon-cancel"
                    onclick="deleteEndModels();">Delete</a> 
                <%=btnImport%>
            </div>
        </div>
    </div>
        <a id="w-importIC50" class="fancybox" href="#divImportFile1"></a>
<div id="divImportFile1" style="width: 600px; height: 200px; display: none;">
    <input type="file" name="uploadify1" id="uploadify1" /><br />
    <button id="btn_Upload01" value="Upload" class="easyui-linkbutton" onclick="javascript:$('#uploadify1').uploadifive('upload')">
        upload
    </button>&nbsp;
    <button id="btn_close1" value="Close" class="easyui-linkbutton" onclick="closeWindow();">
        Close
    </button>
    <div id="fileQueue1">
    </div>
</div>
    </form>
</body>
</html>
