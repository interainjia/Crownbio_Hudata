<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="RoutineMaintain.aspx.cs" Inherits="PDXmodelBase.HuData.RoutineMaintain" %>

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
    <script type="text/javascript" src="/site_media/HuData/RoutineMaintain.js?v=2.1"></script>
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
        <input id="hfStudy" type="hidden" />
        <input id="Searchdata" type="hidden" />
        <input id="hfPN" type="hidden" />
        <input id="hfRoutineMaintain_ID" type="hidden" />

        <input id="rid" type="hidden" />
        <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>
        <div id="context" style="overflow-y: scroll">
            <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional">
                <ContentTemplate>
                    <div id="divRoutineMaintainImport" class="easyui-accordion">
                        <div id="RoutineMaintainImport" title="Edit" style="overflow: auto;">
                            <table width="100%" border="0" cellpadding="0" cellspacing="1" class="tb1">
                                <tr>
                                    <td class="td_left">Serial #:<span style="color: Red">*</span></td>
                                    <td class="td_right">
                                        <input id="txtSerial" class="easyui-validatebox" data-options="required:true"></input>
                                    </td>
                                    <td class="td_left">&nbsp;Model Type</td>
                                    <td class="td_right">
                                        <select id="txtModel_Type" class="easyui-combobox"
                                            name="txtModel_Type" style="width: 150px;">
                                        </select></td>
                                    <td class="td_left">Cancer Type Abbr:</td>
                                    <td class="td_right">
                                        <select id="txtCancer_Type_Abbr" class="easyui-combobox"
                                            name="txtCancer_Type_Abbr" style="width: 150px;">
                                        </select>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="td_left">Subtype1:</td>
                                    <td class="td_right">
                                        <select id="txtSubtype1" class="easyui-combobox" name="txtSubtype1"
                                            style="width: 150px;">
                                        </select></td>
                                    <td class="td_left">Subtype2;</td>
                                    <td class="td_right">
                                        <select id="txtSubtype2" class="easyui-combobox" name="txtSubtype2"
                                            style="width: 150px;">
                                        </select></td>
                                    <td class="td_left">Project #</td>
                                    <td class="td_right">
                                        <select id="txtProject" class="easyui-combobox"
                                            name="txtProject" style="width: 150px;">
                                        </select>
                                    </td>
                                </tr>
                                <tr>

                                    <td class="td_left">Location:<span style="color: Red">*</span></td>
                                    <td class="td_right">
                                        <select id="txtLocation" class="easyui-combobox" name="txtLocation"
                                            style="width: 150px;">
                                        </select></td>
                                    <td class="td_left">Source Animal/Tissue info:</td>
                                    <td class="td_right">
                                        <input id="txtSource_Animal"></input>
                                    </td>
                                    <td class="td_left">Opreation:</td>
                                    <td class="td_right">
                                        <select id="txtOpreation" class="easyui-combobox" name="txtOpreation"
                                            style="width: 150px;">
                                        </select></td>

                                </tr>
                                <tr>
                                    <td class="td_left">Rn</td>
                                    <td class="td_right">
                                        <input id="txtRn"></input></td>
                                    <td class="td_left">Pn:</td>
                                    <td class="td_right">
                                        <input id="txtPn"></input></td>
                                    <td class="td_left">Date of Passage inoculation:</td>
                                    <td class="td_right">
                                        <input id="txtDate_of_Passage_inoculation" class="easyui-datebox" data-options="formatter:myformatter"
                                            editable="false" />
                                    </td>

                                </tr>
                                <tr>

                                    <td class="td_left">Animal Strain:
                                    </td>
                                    <td class="td_right">
                                        <select id="txtAnimal_Strain" class="easyui-combobox"
                                            name="txtAnimal_Strain" style="width: 150px;">
                                        </select>
                                    </td>
                                    <td class="td_left">Animal Sex:</td>
                                    <td class="td_right">
                                        <select id="txtAnimal_Sex" name="txtAnimal_Sex" class="easyui-combobox"
                                            style="width: 150px;">
                                            <option value="Female">Female</option>
                                            <option value="Male">Male</option>
                                        </select></td>
                                    <td class="td_left">Current Animal Ear Tag:</td>
                                    <td class="td_right">
                                        <input id="txtCurrent_Animal_Ear_Tag"></input></td>

                                </tr>
                                <tr>
                                    <td class="td_left">Animal Quantity:</td>
                                    <td class="td_right">
                                        <input id="txtAnimal_Quantity"></input></td>
                                    <td class="td_left">Date of Passage Termination:</td>
                                    <td class="td_right">
                                        <input id="txtDate_of_Passage_Termination" class="easyui-datebox" data-options="formatter:myformatter"
                                            editable="false" />
                                    </td>
                                    <td class="td_left">Comments:</td>
                                    <td class="td_right">
                                        <input id="txtComments" />
                                    </td>
                                </tr>
                                 <tr>
                                    <td class="td_left">Animal Room Number:
                                    </td>
                                    <td class="td_right">
                                        <input id="txtAnimal_Room_Number"></input>
                                    </td>
                                   <td class="td_left">Model Tumor Characteristics
                                    </td>
                                    <td class="td_right">
                                        <input id="txtModel_Tumor_Characteristics"></input>
                                    </td>
                                    <td class="td_left">&nbsp;
                                    </td>
                                    <td class="td_right">&nbsp;
                                    </td>
                                </tr>
                                <tr>
                                    <td class="td_left">PDX growth status:</td>
                                    <td class="td_right">
                                        <select id="txtPDX_growth_status" class="easyui-combobox"
                                            name="txtPDX_growth_status" style="width: 150px;">
                                        </select></td>
                                    <td class="td_left">&nbsp;</td>
                                    <td class="td_right">&nbsp;</td>
                                    <td class="td_left">&nbsp;</td>
                                    <td class="td_right">&nbsp;</td>
                                </tr>

                                <tr>
                                    <td class="td_left">&nbsp;</td>
                                    <td class="td_right">&nbsp; <a class="easyui-linkbutton" onclick="AddNew_model();">Add</a>
                                        <input id="Reset1" type="reset" value="reset" style="display: none" />
                                        <a class="easyui-linkbutton" onclick="Check();">Save</a>
                                        <input id="hfLocation" type="hidden" />
                                    </td>
                                    <td class="td_left">&nbsp;</td>
                                    <td class="td_right">&nbsp;</td>
                                    <td class="td_left">&nbsp;</td>
                                    <td class="td_right">&nbsp;</td>
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
                        <table id="dgRoutineMaintain" title="" data-options="toolbar:'#tb'">
                        </table>
                    </td>
                </tr>
            </table>
            <div id="tb" style="padding: 0px; height: auto;">
                Model ID:
            <input id="searchModelID" name="searchModelID" type="text" />
                <div id="divSearch" class="easyui-accordion">
                    <div id="AdvancadSearch" title="Advancad Search" style="overflow: auto;">
                        Model_Type:
                    <input id="S_Model_Type" type="text" />
                        Subtype1:<input id="S_Subtype1" type="text" />
                        Subtype2:<input id="S_Subtype2" type="text" />
                        Project:<input id="S_Project" type="text" />
                        Location:<input id="S_Location" type="text" />
                        Rn:<input id="S_Rn" type="text" />
                        Pn:<input id="S_Pn" type="text" />
                        Date_of_Passage_inoculation:<input id="S_Date_of_Passage_inoculation" class="easyui-datebox"
                            data-options="formatter:myformatter" editable="false" />
                        Current_Animal_Ear_Tag:<input id="S_Current_Animal_Ear_Tag" type="text" />
                    </div>
                </div>
                <a href="javascript:void();" class="easyui-linkbutton" iconcls="icon-search" onclick="getdgRoutineMaintain();">Search</a> <a id="aExport1" class="easyui-linkbutton" href="javascript:void();" iconcls="icon-save"
                    onclick="htmlExport_old();">Export</a>
                <asp:Button ID="btnExport1" runat="server" OnClick="btnExport1_Click" Style="display: none"
                    Text="全部导出" />
                <a id="btndelete" name="btndelete" href="javascript:void();" class="easyui-linkbutton" iconcls="icon-cancel"
                    onclick="deleteRoutineMaintain();">Delete</a>
                Start Data:
                <input id="S_StartData" class="easyui-datebox"
                    data-options="formatter:myformatter" name="S_StartData" />
                End Data:
                <input id="S_EndData" class="easyui-datebox"
                    data-options="formatter:myformatter" name="S_EndData" />
                <a id="aExport3"
                    class="easyui-linkbutton" href="javascript:void();" iconcls="icon-save"
                    onclick="htmlExport_old3();">Export</a>
                <asp:Button ID="btnExport3" runat="server" OnClick="btnExport3_Click"
                    Style="display: none" Text="全部导出" />
            </div>


            <div id="tb2" style="padding: 0px; height: auto">
                <div style="margin-bottom: 5px;">
                    <a href="javascript:void();" class="easyui-linkbutton" iconcls="icon-save" onclick="htmlExport_old2();"
                        id="aExport2">Export</a>
                    <asp:Button ID="btnExport2" runat="server" Text="全部导出" OnClick="btnExport2_Click"
                        Style="display: none" />
                    <%--     <a href="#" class="easyui-linkbutton" iconcls="icon-save" onclick="Sendmail2();"
                                                                            id="Sendmail" >Sendmail</a>
                                                                         
                                                                          <asp:Button ID="btnSendmail" runat="server" Text="全部导出" OnClick="btnSendmail_Click" 
                                                                            Style="display: none" />--%>
                </div>

            </div>
            <table cellpadding="0" cellspacing="0" border="0" width="100%">
                <tr>
                    <td>
                        <table id="dgAnimalInfo_RoutineMaintain" title="" data-options="toolbar:'#tb2'">
                        </table>
                    </td>
                </tr>
            </table>
        </div>
        <a id="w-Log" class="fancybox" href="#divLog"></a>
        <div id="divLog" style="width: 800px; height: 500px; display: none;">
            <table id="dgRoutineMaintain_Log" cellpadding="0" cellspacing="0">
            </table>
        </div>
    </form>
</body>
</html>
