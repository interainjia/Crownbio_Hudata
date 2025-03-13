<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ValidationStatus_Hukime.aspx.cs" Inherits="PDXmodelBase.HuData.ValidationStatus_Hukime" %>

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
    <script type="text/javascript" src="/site_media/HuData/ValidationStatus_Hukime.js?V=3.0"></script>
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
        <input id="hfValidationStatus_Hukime_ID" type="hidden" />
        <input id="rid" type="hidden" />
        <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>
        <div id="context" style="overflow-y: scroll">
            <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional">
                <ContentTemplate>
                    <div id="divValidationStatus_HukimeImport" class="easyui-accordion">
                        <div id="ValidationStatus_HukimeImport" title="Edit" style="overflow: auto;">
                            <table width="100%" border="0" cellpadding="0" cellspacing="1" class="tb1">
                                <tr>
                                    <td class="td_left">Sq:<span style="color: Red">*</span>
                                    </td>
                                    <td class="td_right">
                                        <input id="txtSq" class="easyui-validatebox" data-options="required:true"></input>
                                    </td>
                                    <td class="td_left">CancerType:
                                    </td>
                                    <td class="td_right">
                                        <input id="txtCancerType"></input>
                                    </td>
                                    <td class="td_left">CancerTypeAbbr:
                                    </td>
                                    <td class="td_right">
                                        <input id="txtCancerTypeAbbr"></input>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="td_left">ModelID:<span style="color: Red">*</span>
                                    </td>
                                    <td class="td_right">
                                        <input id="txtModelID" class="easyui-validatebox" data-options="required:true"></input>
                                    </td>
                                    <td class="td_left">Model_Type;
                                    </td>
                                    <td class="td_right">
                                        <input id="txtModel_Type"></input>
                                    </td>
                                    <td class="td_left">Source
                                    </td>
                                    <td class="td_right">
                                        <input id="txtSource"></input>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="td_left">Subtype:
                                    </td>
                                    <td class="td_right">
                                        <input id="txtSubtype"></input>
                                    </td>
                                    <td class="td_left">Established_Date:
                                    </td>
                                    <td class="td_right">
                                        <input id="txtEstablished_Date" class="easyui-datebox" data-options="formatter:myformatter"
                                            editable="false" />
                                    </td>
                                    <td class="td_left">Established_Location:
                                    </td>
                                    <td class="td_right">
                                        <input id="txtEstablished_Location"></input>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="td_left">ValidationStatus
                                    </td>
                                    <td class="td_right">
                                        <input id="txtValidationStatus"></input>
                                    </td>
                                    <td class="td_left">FinalDateofValidation:
                                    </td>
                                    <td class="td_right">
                                        <input id="txtFinalDateofValidation" class="easyui-datebox" data-options="formatter:myformatter"
                                            editable="false" />
                                    </td>
                                    <td class="td_left">TU:
                                    </td>
                                    <td class="td_right">
                                        <input id="txtTU"></input>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="td_left">FACS
                                    </td>
                                    <td class="td_right">
                                        <input id="txtFACS"></input>
                                    </td>
                                    <td class="td_left">bank:
                                    </td>
                                    <td class="td_right">
                                        <input id="txtbank"></input>
                                    </td>
                                    <td class="td_left">Revival:
                                    </td>
                                    <td class="td_right">
                                        <input id="txtRevival" class="easyui-datebox" data-options="formatter:myformatter"
                                            editable="false" />
                                    </td>
                                </tr>
                                <tr>
                                    <td class="td_left">passage
                                    </td>
                                    <td class="td_right">
                                        <input id="txtpassage"></input>
                                    </td>
                                    <td class="td_left">snp:
                                    </td>
                                    <td class="td_right">
                                        <input id="txtsnp"></input>
                                    </td>
                                    <td class="td_left">DateofUpdate
                                    </td>
                                    <td class="td_right">
                                        <input id="txtDateofUpdate" class="easyui-datebox" data-options="formatter:myformatter"
                                            editable="false" />
                                    </td>
                                </tr>
                                <tr>
                                    <td class="td_left">&nbsp;
                                    </td>
                                    <td class="td_right">&nbsp;
                                    </td>
                                    <td class="td_left">&nbsp;
                                    </td>
                                    <td class="td_right">&nbsp;
                                    </td>
                                    <td class="td_left">Comment
                                    </td>
                                    <td class="td_right">
                                        <input id="txtComment"></input>
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
                        <table id="dgValidationStatus_Hukime" title="" data-options="toolbar:'#tb'">
                        </table>
                    </td>
                </tr>
            </table>
            <div id="tb" style="padding: 0px; height: auto; width: 100%">
                <div style="margin-bottom: 5px">
                    Sq#:
                <input id="S_Sq" name="S_Sq" type="text" />
                    Model ID:<input id="S_ModelID" name="S_ModelID" type="text" />
                    <a href="javascript:void();" class="easyui-linkbutton" iconcls="icon-search" onclick="getdgValidationStatus_Hukime();">Search</a> 
                    <a id="aExport3" class="easyui-linkbutton" href="javascript:void();" iconcls="icon-save" onclick="htmlExport_old3();">Export</a>
                    <asp:Button ID="btnExport3" runat="server" OnClick="btnExport3_Click" Style="display: none"
                        Text="全部导出" />
                    <a id="btndelete" name="btndelete" href="javascript:void();" class="easyui-linkbutton" iconcls="icon-cancel"
                        onclick="deleteValidationStatus_Hukime();">Delete</a>
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
