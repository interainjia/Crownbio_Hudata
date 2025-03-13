<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ProjectConsulting.aspx.cs" Inherits="PDXmodelBase.HuData.ProjectConsulting" %>

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
    <script type="text/javascript" src="/site_media/HuData/ProjectConsulting.js?V=1.0"></script>
    <script type="text/javascript" src="/site_media/HuData/export.js"></script>
    <script type="text/javascript" src="../Common/fancyBox/source/jquery.fancybox.js?v=2.1.4"></script>
    <link rel="stylesheet" type="text/css" href="../Common/fancyBox/source/jquery.fancybox.css?v=2.1.4"
        media="screen" />
    <link rel="stylesheet" type="text/css" href="../Common/css/hudataform.css" />
    <link rel="stylesheet" type="text/css" href="../Common/uploadifive-v1.2.2-standard/uploadifive.css" />
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
        <input id="hfProjectConsulting_ID" type="hidden" />
        <input id="rid" type="hidden" />
        <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>
        <div id="context" style="overflow-y: scroll">
            <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional">
                <ContentTemplate>
                    <div id="divProjectConsultingImport" class="easyui-accordion">
                        <div id="ProjectConsultingImport" title="Edit" style="overflow: auto;">
                            <table width="100%" border="0" cellpadding="0" cellspacing="1" class="tb1">
                                <tr>
                                    <td class="td_left">ModelID:<span style="color: Red">*</span>
                                    </td>
                                    <td class="td_right">
                                        <input id="ModelID" class="easyui-validatebox" data-options="required:true"></input>
                                    </td>
                                    <td class="td_left">CancerType:<span style="color: Red">*</span>
                                    </td>
                                    <td class="td_right">
                                        <input id="CancerType" class="easyui-validatebox" data-options="required:true"></input>
                                    </td>
                                    <td class="td_left">LiveStatus:
                                    </td>
                                    <td class="td_right">
                                        <input id="LiveStatus"></input>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="td_left">Pn:
                                    </td>
                                    <td class="td_right">
                                        <input id="Pn"></input>
                                    </td>
                                    <td class="td_left">Location:
                                    </td>
                                    <td class="td_right">
                                        <input id="Location"></input>
                                    </td>
                                    <td class="td_left">Estimated_Timeframe_of_inoculation:
                                    </td>
                                    <td class="td_right">
                                        <input id="Estimated_Timeframe_of_inoculation"></input>

                                    </td>
                                </tr>
                                <tr>
                                    <td class="td_left">ConfidenceScore:
                                    </td>
                                    <td class="td_right">
                                        <input id="ConfidenceScore"></input>
                                    </td>
                                    <td class="td_left">AvailableIn:
                                    </td>
                                    <td class="td_right">
                                        <input id="AvailableIn"></input>
                                    </td>
                                    <td class="td_left">SpecialFeature:
                                    </td>
                                    <td class="td_right">
                                        <input id="SpecialFeature"></input>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="td_left">Comment:
                                    </td>
                                    <td class="td_right">
                                        <input id="Comment"></input>
                                    </td>
                                    <td class="td_left">BD:
                                    </td>
                                    <td class="td_right">
                                        <input id="BD"></input>
                                    </td>
                                    <td class="td_left">Customer:
                                    </td>
                                    <td class="td_right">
                                        <input id="Customer"></input>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="td_left">ConsultationDate:
                                    </td>
                                    <td class="td_right">
                                        <input id="ConsultationDate" class="easyui-datebox" data-options="formatter:myformatter" />
                                    </td>
                                    <td class="td_left">ProjectNo:
                                    </td>
                                    <td class="td_right">
                                        <input id="ProjectNo"></input>
                                    </td>
                                    <td class="td_left">Cause:
                                    </td>
                                    <td class="td_right">
                                        <input id="Cause"></input></td>
                                </tr>
                                <tr>
                                    <td class="td_left">&nbsp;
                                    </td>
                                    <td class="td_right">&nbsp;
                                       <a class="easyui-linkbutton" onclick="AddProjectConsulting();">Add</a>
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
                        <table id="dgProjectConsulting" title="" data-options="toolbar:'#tb'">
                        </table>
                    </td>
                </tr>
            </table>
            <div id="tb" style="padding: 0px; height: auto; width: 100%">
                <div style="margin-bottom: 5px">
                    Model ID:<input id="S_ModelID" name="S_ModelID" type="text" />
                    Customer::<input id="S_Customer" name="S_Customer" type="text" />
                    <%--  <div id="divMoreSearch" class="easyui-accordion">
                        <div id="MoreSearch" title="Advancad Search" style="overflow: auto;">
                            Source:
                        <input id="s_Source" name="s_Source" type="text" />
                            RNAseq：
                        <input id="s_RNAseq" name="s_RNAseq" type="text" />
                            WES：
                        <input id="s_WES" name="s_WES" type="text" />
                           WGS：
                        <input id="s_WGS" name="s_WGS" type="text" />
                        </div>
                    </div>--%>
                    <a href="javascript:void();" class="easyui-linkbutton" iconcls="icon-search" onclick="getdgProjectConsulting();">Search</a>
                    <a id="aExport3" class="easyui-linkbutton" href="javascript:void();" iconcls="icon-save" onclick="htmlExport_old3();">Export</a>
                    <asp:Button ID="btnExport3" runat="server" OnClick="btnExport3_Click" Style="display: none"
                        Text="全部导出" />
                    <a id="btndelete" name="btndelete" href="javascript:void();" class="easyui-linkbutton" iconcls="icon-cancel"
                        onclick="deleteProjectConsulting();">Delete</a>
                    <%=btnImport%>
                </div>
            </div>
        </div>
        <a id="w-importIC50" class="fancybox" href="#divImportFile1"></a>
        <div id="divImportFile1" style="width: 600px; height: 200px; display: none;">
            <input type="file" name="uploadify1" id="uploadify1" /><br />
            <a id="btn_Upload01" value="Upload" class="easyui-linkbutton" onclick="javascript:$('#uploadify1').uploadifive('upload')">
                upload
            </a>
            &nbsp;
    <a id="btn_close1" value="Close" class="easyui-linkbutton" onclick="closeWindow();">
        Close
    </a>
            <div id="fileQueue1">
            </div>
        </div>
    </form>
</body>
</html>
