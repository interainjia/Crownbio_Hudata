<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SpecimenStocks.aspx.cs"
    Inherits="PDXmodelBase.HuData.SpecimenStocks" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <script type="text/javascript" src="../Common/easyui-1.3.2/jquery-1.8.0.min.js"></script>
    <script type="text/javascript" src="../Common/easyui-1.2.5/jquery.wresize.js"></script>
    <script type="text/javascript" src="/site_media/HuData/base.js"></script>
    <script type='text/javascript' src='../Common/autocomplete/lib/jquery.bgiframe.min.js'></script>
    <script type='text/javascript' src='../Common/autocomplete/lib/jquery.ajaxQueue.js'></script>
    <script type='text/javascript' src='../Common/autocomplete/lib/thickbox-compressed.js'></script>
    <script type='text/javascript' src='../Common/autocomplete/jquery.autocomplete.js'></script>
    <script type='text/javascript' src='../Common/autocomplete/localdata.js'></script>
    <link rel="stylesheet" type="text/css" href="../Common/autocomplete/jquery.autocomplete.css" />
    <link rel="stylesheet" type="text/css" href="../Common/autocomplete/lib/thickbox.css" />
    <link rel="stylesheet" type="text/css" href="/site_media/HuData/css/base.css" />
    <script type="text/javascript" src="/site_media/HuData/SpecimenStocks.js?v=1.4"></script>
    <script type="text/javascript" src="/site_media/HuData/export.js"></script>
    <script type="text/javascript" src="/site_media/HuData/base.js"></script>
    <link href="../Common/waiting/showLoading.css" rel="stylesheet" media="screen" />
    <script type="text/javascript" src="../Common/waiting/jquery.showLoading.js"></script>
    <link rel="stylesheet" href="/site_media/zTree/css/demo.css" type="text/css" />
    <link rel="stylesheet" href="/site_media/zTree/css/zTreeStyle/zTreeStyle.css" type="text/css" />
    <script type="text/javascript" src="/site_media/zTree/js/jquery.ztree.core-3.5.js"></script>
    <script type="text/javascript" src="/site_media/zTree/js/jquery.ztree.excheck-3.5.js"></script>
    <script type="text/javascript" src="/site_media/zTree/js/jquery.ztree.exedit-3.5.js"></script>
    <script type="text/javascript" src="../Common/easyui-1.3.2/jquery.easyui.min.js"></script>
    <link rel="stylesheet" type="text/css" href="../Common/easyui-1.3.2/themes/bootstrap/easyui.css" />
    <link rel="stylesheet" type="text/css" href="../Common/easyui-1.3.2/themes/icon.css" />
    <script type="text/javascript" src="../Common/fancyBox/source/jquery.fancybox.js?v=2.1.4"></script>
    <link rel="stylesheet" type="text/css" href="../Common/fancyBox/source/jquery.fancybox.css?v=2.1.4"
        media="screen" />
    <link rel="stylesheet" type="text/css" href="../Common/css/hudataform.css" />
    <!--[if gte IE 8]><script type="text/javascript" src="../Common/textcontent.js"></script><![endif]-->
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
    <input id="hfStocks_ID" type="hidden" />
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <div id="context" style="overflow-y: scroll">
        <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional">
            <ContentTemplate>
                <div id="divStocksImport" class="easyui-accordion">
                    <div id="StocksImport" title="Edit" style="overflow: auto;">
                        <table width="100%" border="0" cellpadding="0" cellspacing="1" class="tb1">
                            <tr>
                                <%--<td class="td_left">
                                     Cancer Type:<span style="color: Red">*</span>
                                </td>
                                <td class="td_right">
                                   <select id="txtCancer_Type" class="easyui-combobox" name="txtCancer_Type" style="width: 150px;">
                            </select>
                                </td>
                                <td class="td_left">
                                   Sq Number:<span style="color: Red">*</span>
                                </td>
                                <td class="td_right">
                                 <input id="txtSq_Number" class="easyui-validatebox" data-options="required:true" validType="integer"/>
                                </td>--%>
                                <td class="td_left">
                                    Model ID:<span style="color: Red">*</span>
                                </td>
                                <td class="td_right">
                                    <input id="txtModel_ID" class="easyui-validatebox" data-options="required:true"></input>
                                </td>
                                <td class="td_left">
                                    Animal info
                                </td>
                                <td class="td_right">
                                    <a class="easyui-linkbutton" id="selectAnimal" onclick="getdgAnimal();">select</a>
                                    <input id="txtAnimal_number" />
                                </td>
                                <td class="td_left">
                                    Region:
                                </td>
                                <td class="td_right">
                                    <input id="txtRegion" disabled="disabled"/>
                                </td>
                            </tr>
                            <tr>
                                <td class="td_left">
                                    Date of Tissue Collection:
                                </td>
                                <td class="td_right">
                                    <input id="txtDate_of_Tissue_Collection" class="easyui-datebox" data-options="formatter:myformatter"
                                        editable="false" />
                                </td>
                                <td class="td_left">
                                    Site of Tissue Collection:
                                </td>
                                <td class="td_right">
                                    <select id="txtSite_of_Tissue_Collection" class="easyui-combobox" name="txtSite_of_Tissue_Collection"
                                        style="width: 150px;">
                                    </select>
                                </td>
                                <td class="td_left">
                                    Tissue Type:
                                </td>
                                <td class="td_right">
                                    <select id="txtTissue_Type" class="easyui-combobox" name="txtTissue_Type" style="width: 150px;">
                                    </select>
                            </tr>
                            <tr>
                                </td>
                                <td class="td_left">
                                    Preserve Method:
                                </td>
                                <td class="td_right">
                                    <select id="txtPreserve_Method" class="easyui-combobox" name="txtPreserve_Method"
                                        style="width: 150px;">
                                    </select>
                                </td>
                                <td class="td_left">
                                    Treatment To Mice:
                                </td>
                                <td class="td_right">
                                    <select id="txtTreatment_To_Mice" class="easyui-combobox" name="txtTreatment_To_Mice"
                                        style="width: 150px;">
                                    </select>
                                </td>
                                <td class="td_left">
                                    Import Date:
                                </td>
                                <td class="td_right">
                                    <input id="txtImport_Date" class="easyui-datebox" data-options="formatter:myformatter"
                                        editable="false" />
                                </td>
                            </tr>
                            <tr>
                                <td class="td_left">
                                    Location ID:
                                </td>
                                <td class="td_right">
                                    <input id="txtLocation_ID" style="width: 200px" />
                                    <a id="btngetLocationID" class="easyui-linkbutton" onclick="getLocationID();">select</a>
                                </td>
                                <td class="td_left">
                                    Well ID:
                                </td>
                                <td class="td_right">
                                    <input id="txtWell_ID" />
                                </td>
                                <td class="td_left">
                                    STR:
                                </td>
                                <td class="td_right">
                                    <input id="txtSTR" />
                                </td>
                            </tr>
                            <tr>
                                <td class="td_left">
                                    &nbsp;
                                </td>
                                <td class="td_right">
                                    <a id="btnSend3" name="btnSend" class="easyui-linkbutton" onclick="Save();">Save</a>
                                    <input id="Reset1" type="reset" value="reset" style="display: none" />
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
                    <table id="dgSpecimenStocks" title="" data-options="toolbar:'#tb'">
                    </table>
                </td>
            </tr>
        </table>
        <div id="tb" style="padding: 0px; height: auto">
            <div style="margin-bottom: 5px">
                Region:
                <input id="S_Region" name="S_Region" type="text" />
                Model ID:
                <input id="searchModel_ID" name="searchModel_ID" type="text" />
                Project No:
                <input id="S_PojectNo" name="S_PojectNo" type="text" />
                Well ID:<input id="S_Well_ID" name="S_Well_ID" type="text" />
                Location ID:<input id="S_Location_ID" type="text" name="S_Location_ID" />
                <br />
                Site of Tissue Collection:<input id="S_Site_of_Tissue_Collection" type="text" name="S_Site_of_Tissue_Collection" />
                Preserve Method:<input id="S_Preserve_Method" type="text" name="S_Preserve_Method" />
                Date of Tissue Collection:
                <input id="S_Date_of_Tissue_Collection" name="S_Date_of_Tissue_Collection" class="easyui-datebox"
                    data-options="formatter:myformatter" editable="false" />
                Animal_Number:<input id="S_Animal_Number" type="text" name="S_Animal_Number" />
                <br />
                Pn:
                <input id="S_Pn" type="text" name="S_Pn" />Tissue_Type:
                <input id="S_Tissue_Type" type="text" name="S_Tissue_Type" />
                <br />
                <a href="javascript:void();" class="easyui-linkbutton" iconcls="icon-search" onclick="getdgSpecimenStocks();">
                    Search</a> <a id="aExport1" class="easyui-linkbutton" href="javascript:void();" iconcls="icon-save"
                        onclick="htmlExport_old();">Export</a>
                <asp:Button ID="btnExport1" runat="server" OnClick="btnExport1_Click" Style="display: none"
                    Text="全部导出" />
                <a id="btndelete" name="btndelete" href="javascript:void();" class="easyui-linkbutton"
                    iconcls="icon-cancel" onclick="deleteStocks();">Delete</a> <a id="btnGotoWithDraw"
                        class="easyui-linkbutton" href="javascript:void();" iconcls="icon-redo" onclick="btnGotoWithDraw();">
                        Withdraw</a> Project Number:
                <input id="txtProjectNumber" name="txtProjectNumber" type="text" />
                <%--     <a id="btndelete0" class="easyui-linkbutton" href="#" iconcls="icon-cancel" 
                name="btndelete0" onclick="deleteStocks2();">Delete2</a>--%>
            </div>
        </div>
    </div>
    <a id="w-Animal" class="fancybox" href="#divAnimal"></a>
    <div id="divAnimal" style="width: 800px; height: 400px; display: none;">
        <table id="dgAnimal" cellpadding="0" cellspacing="0">
        </table>
        <input type="button" onclick="btnSetAnimal();" value="OK" class="button-push" />
    </div>
    <a id="w-Location" class="fancybox" href="#divLocation"></a>
    <div id="divLocation" style="width: 800px; height: 500px; display: none;">
        <table id="Table1" cellpadding="0" cellspacing="0">
            <tr>
                <td>
                    <ul id="treeDemo" class="ztree" style="width: 250px;">
                    </ul>
                </td>
                <td>
                    <select id="selectWell_ID" class="easyui-combobox" name="selectWell_ID" style="width: 100px">
                    </select>
                </td>
                <td>
                    <a class="easyui-linkbutton" onclick="btnOK();">Confirm</a>
                </td>
            </tr>
        </table>
    </div>
    </form>
</body>
</html>
