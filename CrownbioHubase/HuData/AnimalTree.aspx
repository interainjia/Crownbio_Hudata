<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AnimalTree.aspx.cs" Inherits="PDXmodelBase.HuData.huprime" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <title>CrownBio HuData</title>
    <meta name="description" content="CrownBio HuBase" />
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
    <script type="text/javascript" src="/site_media/HuData/AnimalTree.js?V=5.0"></script>
    <script type="text/javascript" src="/site_media/HuData/export.js"></script>
    <script type="text/javascript" src="/site_media/HuData/base.js"></script>
    <link href="../Common/waiting/showLoading.css" rel="stylesheet" media="screen" />
    <script type="text/javascript" src="../Common/waiting/jquery.showLoading.js"></script>
    <link rel="stylesheet" href="/site_media/zTree/css/demo.css" type="text/css" />
    <link rel="stylesheet" href="/site_media/zTree/css/zTreeStyle/zTreeStyle.css" type="text/css" />
    <%--    <script type="text/javascript" src="/site_media/zTree/js/jquery-1.4.4.min.js"></script>--%>
    <script type="text/javascript" src="/site_media/zTree/js/jquery.ztree.core-3.5.js"></script>
    <script type="text/javascript" src="/site_media/zTree/js/jquery.ztree.excheck-3.5.js"></script>
    <script type="text/javascript" src="/site_media/zTree/js/jquery.ztree.exedit-3.5.js"></script>
    <script type="text/javascript" src="../Common/easyui-1.3.2/jquery.easyui.min.js"></script>
    <link rel="stylesheet" type="text/css" href="../Common/easyui-1.3.2/themes/bootstrap/easyui.css" />
    <link rel="stylesheet" type="text/css" href="../Common/easyui-1.3.2/themes/icon.css" />
    <link rel="stylesheet" type="text/css" href="/site_media/hubase/plugins/tree/css/style.css" />
    <script type="text/javascript" src="../Common/fancyBox/source/jquery.fancybox.js?v=2.1.4"></script>
    <link rel="stylesheet" type="text/css" href="../Common/fancyBox/source/jquery.fancybox.css?v=2.1.4"
        media="screen" />
    <link rel="stylesheet" type="text/css" href="../Common/css/hudataform.css" />
    <link rel="stylesheet" type="text/css" href="../Common/css/buttons3.css" />
    <!--[if gte IE 8]><script type="text/javascript" src="../Common/textcontent.js"></script><![endif]-->
    <script type="text/javascript">
      $(document).ready(function(){
      doRestore();
       });
       function doRestore()
       {
        var  treeNodes = [<%=NodesData%>]; 
       $.fn.zTree.init($("#treeDemo"), setting, treeNodes);
       }


    </script>
    <style type="text/css">
.ztree li span.demoIcon{padding:0 2px 0 10px;}
.ztree li span.button.icon01{margin:0; background: url(/site_media/zTree/css/zTreeStyle/img/diy/3.png) no-repeat scroll 0 0 transparent; vertical-align:top; *vertical-align:middle}
.ztree li span.button.icon02{margin:0; background: url(/site_media/zTree/css/zTreeStyle/img/diy/4.png) no-repeat scroll 0 0 transparent; vertical-align:top; *vertical-align:middle}
.ztree li span.button.icon03{margin:0; background: url(/site_media/zTree/css/zTreeStyle/img/diy/5.png) no-repeat scroll 0 0 transparent; vertical-align:top; *vertical-align:middle}
.ztree li span.button.icon04{margin:0; background: url(/site_media/zTree/css/zTreeStyle/img/diy/6.png) no-repeat scroll 0 0 transparent; vertical-align:top; *vertical-align:middle}
.ztree li span.button.icon05{margin:0; background: url(/site_media/zTree/css/zTreeStyle/img/diy/7.png) no-repeat scroll 0 0 transparent; vertical-align:top; *vertical-align:middle}
.ztree li span.button.icon06{margin:0; background: url(/site_media/zTree/css/zTreeStyle/img/diy/8.png) no-repeat scroll 0 0 transparent; vertical-align:top; *vertical-align:middle}
	</style>
</head>
<!-- end blockhead-->
<body>
    <form id="form1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <div id="wrapper">
        <!--Top-->
        <div id="div_top">
        </div>
        <!--main-->
        <div id="activity_pane">
            <div id="div_middle">
                <!--top border-->
                <div id="div_borderTop">
                </div>
                <div id="div_body">
                    <!--left-->
                    <div id="div_left">
                        <div id="panel_wrapper">
                            <div id="tree-panel" class="panel  bottomPanel">
                                <div id="div_tree">
                                    <%-- <div style="margin: 5px;">
                                    <div class="symbol_lookup">
                                        Choose from below&nbsp;</div>
                                    <div class="symbol_help">
                                        <a style="font-size: 18px; color: #FFF" onclick="return false;" title="Choose from below">
                                            ?</a></div>
                                </div>--%>
                                    <div class="new_tabs_frame">
                                        <div class="tabdata">
                                            <div class="clearfix">
                                                &nbsp;&nbsp;</div>
                                            <ul id="tree1" class="tree" style="padding-left: 5px">
                                                <li class="folder f-open first">
                                                    <img alt="" src="../site_media/hubase/plugins/tree/images/_open.gif" /><span>Model Search</span>
                                                    <ul>
                                                        <li id="GeneList2" class="doc search" name="gene2">
                                                            <img alt="" src="../site_media/hubase/plugins/tree/images/_doc.gif" /><span style="display: inline">
                                                                <input type="text" id="txtModelID" name="txtModelID" class="searchField_tumor" /><input
                                                                    type="button" id="drawgene" name="button" class="draw_button" onclick="doSearch()" /></span></li>
                                                    </ul>
                                                    <ul style="padding-left: 21px">
                                                        <li class="folder f-open">
                                                            <img alt="" src="../site_media/hubase/plugins/tree/images/_open.gif" /><span>Filters</span>
                                                            <ul>
                                                                <li>Rn:<input id="txtRn" type="text" /></li>
                                                            </ul>
                                                            <ul>
                                                                <li>Pn:<input id="txtPn" type="text" />
                                                                    <input id="Button2" type="button" value="Restore" onclick="doRestore();"/>
                                                                    <span id="hfnotes" style="display: none">
                                                                        <%=NodesData%></span></li>
                                                            </ul>
                                                        </li>
                                                    </ul>
                                                    <ul style="padding-left: 21px">
                                                        <li class="folder f-open">
                                                            <img alt="" src="../site_media/hubase/plugins/tree/images/_open.gif" /><span> Cancer
                                                                Types</span>
                                                            <ul id="tt1" class="easyui-tree" animate="true" dnd="false" style="padding-left: 0px">
                                                            </ul>
                                                            <input id="hfCellline" type="hidden" name="hfCellline" />
                                                        </li>
                                                    </ul>
                                                </li>
                                            </ul>
                                        </div>
                                    </div>
                                </div>
                                <!--end block left-->
                            </div>
                        </div>
                    </div>
                    <div id="div_right">
                        <!--center border-->
                        <div id="div_borderMiddle" class="div_borderMiddle" onclick="hideLeft()">
                            <div class="columnHandle">
                                <div class="handleIcon">
                                </div>
                            </div>
                        </div>
                        <div id="mainPanel_header" class="panel-header">
                            <div id="mainPanel_headerCollapseBox" class="toolbox">
                                <div id="mainPanel_collapseToggle" class="panel-collapse toolbox-icon" title="Collapse Panel">
                                </div>
                            </div>
                            <div id="mainPanel_headerContent" class="panel-headerContent">
                                <h2 id="mainPanel_title">
                                </h2>
                            </div>
                        </div>
                        <!--center-->
                        <div id="div_right_l">
                            <div id="splitPanel_sidePanel_query" class=" panelAlt bottomPanel">
                                <asp:UpdatePanel ID="UpdatePanel2" runat="server" UpdateMode="Conditional">
                                    <ContentTemplate>
                                        <div class="pad">
                                            <div class="center_title">
                                                <b>
                                                    <asp:Label ID="lblcancertype" runat="server"></asp:Label></b></div>
                                            <div class="w2hitebg">
                                                <div class="top">
                                                    <span class="title_left">&nbsp;</span><span class="title_center"><b></b></span><span
                                                        class="title_right">&nbsp;</span></div>
                                                <div class="box_left">
                                                    <div class="box_right">
                                                        <ul id="treeDemo" class="ztree" style="width: 269px;">
                                                        </ul>
                                                    </div>
                                                </div>
                                                <div class="bottom">
                                                    <span class="bottom_left">&nbsp;</span><span class="bottom_center">&nbsp;</span><span
                                                        class="bottom_right">&nbsp;</span></div>
                                            </div>
                                            <!--end block center-->
                                        </div>
                                    </ContentTemplate>
                                </asp:UpdatePanel>
                            </div>
                        </div>
                        <!--center border-->
                        <div id="div_borderMiddle" class="div_borderMiddle" onclick="hideLeft()">
                            <div class="columnHandle">
                                <div class="handleIcon">
                                </div>
                            </div>
                        </div>
                        <!--right--->
                        <div id="div_right_r">
                            <div class="bottomPanel">
                                <div class="pad">
                                  <%--  <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional">
                                        <ContentTemplate>--%>
                                            <asp:Button ID="btnShowData" runat="server" OnClick="btnShowData_OnClick" Style="display: none;" />
                                            <input id="hfAID" type="hidden" name="hfAID" />
                                            <div class="pad">
                                                <div id="tb" style="padding: 5px; height: auto">
                                                    <div style="margin-bottom: 5px">
                                                        DOI:
                                        from<input id="S_DOI_from" class="easyui-datebox" data-options="formatter:myformatter" editable="false" />
                                                         to:
                                        <input id="S_DOI_to" class="easyui-datebox" data-options="formatter:myformatter" editable="false" />
                                                        <br />
                                                          Date of update:
                                        from<input id="S_Date_of_update_from" class="easyui-datebox" data-options="formatter:myformatter" editable="false" />
                                                         to:
                                        <input id="S_Date_of_update_to" class="easyui-datebox" data-options="formatter:myformatter" editable="false" />
                                                        Mortality_Observation:<select id="S_Mortality_Observation">
                                                                                    <option value=""  selected="selected"></option>
                                                                                    <option value="D">D</option>
                                                                              </select>
                                                        <a href="javascript:void();" class="easyui-linkbutton"iconcls="icon-search" onclick="filter_date();">Filter</a>
                                                        <a href="javascript:void();" class="easyui-linkbutton" iconcls="icon-save" onclick="htmlExport_old();"
                                                            id="aExport1">Export</a>
                                                        <asp:Button ID="btnExport1" runat="server" OnClick="btnExport1_Click" Style="display: none" />
                                                           <a href="javascript:void();" class="easyui-linkbutton"iconcls="icon-chart" onclick="showBWchart();">BW chart</a>
                                                    </div>
                                                </div>
                                                <table cellpadding="0" cellspacing="0" border="0" width="1500px">
                                                    <tr>
                                                        <td>
                                                            <table id="tbAnimalinfo_Logs" title="" data-options="toolbar:'#tb'">
                                                            </table>
                                                        </td>
                                                    </tr>
                                                </table>
                                                 <div id="div_BWchart1"></div>
                                            </div>
                                            <%--<div class="pad">
                               <div class="">
                                                  <b>
                                                    <asp:Label runat="server" ID="lblmodel"></asp:Label></b></div>
                                                  <div >
                                                    <table width="100%" border="0" cellpadding="0" cellspacing="1" class="tb1">
                            <tr>
                                <td class="td_left">
                                    Serial #:<span style="color: Red">*</span>
                                </td>
                                <td class="td_right">
                                    <input id="txtSerial" class="easyui-validatebox" data-options="required:true" validtype="integer"></input>
                                </td>
                                <td class="td_left">
                                    &nbsp;Model Type
                                </td>
                                <td class="td_right">
                                    <select id="txtModel_Type" class="easyui-combobox" name="txtModel_Type" style="width: 150px;">
                                    </select>
                                </td>
                                <td class="td_left">
                                    Cancer Type Abbr:
                                </td>
                                <td class="td_right">
                                    <select id="txtCancer_Type_Abbr" class="easyui-combobox" name="txtCancer_Type_Abbr"
                                        style="width: 150px;">
                                    </select>
                                </td>
                            </tr>
                            <tr>
                                <td class="td_left">
                                    Subtype1:
                                </td>
                                <td class="td_right">
                                    <select id="txtSubtype1" class="easyui-combobox" name="txtSubtype1" style="width: 150px;">
                                    </select>
                                </td>
                                <td class="td_left">
                                    Subtype2;
                                </td>
                                <td class="td_right">
                                    <select id="txtSubtype2" class="easyui-combobox" name="txtSubtype2" style="width: 150px;">
                                    </select>
                                </td>
                                <td class="td_left">
                                    Project #
                                </td>
                                <td class="td_right">
                                    <select id="txtProject" class="easyui-combobox" name="txtProject" style="width: 150px;">
                                    </select>
                                </td>
                            </tr>
                            <tr>
                                <td class="td_left">
                                    Location:
                                </td>
                                <td class="td_right">
                                    <select id="txtLocation" class="easyui-combobox" name="txtLocation" style="width: 150px;">
                                    </select>
                                </td>
                                <td class="td_left">
                                </td>
                                <td class="td_right">
                                </td>
                                <td class="td_left">
                                    Opreation:
                                </td>
                                <td class="td_right">
                                    <select id="txtOpreation" class="easyui-combobox" name="txtOpreation" style="width: 150px;">
                                    </select>
                                </td>
                            </tr>
                            <tr>
                                <td class="td_left">
                                    Rn
                                </td>
                                <td class="td_right">
                                    <input id="Text1"></input>
                                </td>
                                <td class="td_left">
                                    Pn:
                                </td>
                                <td class="td_right">
                                    <input id="Text2"></input>
                                </td>
                                <td class="td_left">
                                    Date of Passage inoculation:
                                </td>
                                <td class="td_right">
                                    <input id="txtDate_of_Passage_inoculation" class="easyui-datebox" data-options="formatter:myformatter"
                                        editable="false" />
                                </td>
                            </tr>
                            <tr>
                                <td class="td_left">
                                    Animal Strain:
                                </td>
                                <td class="td_right">
                                    <select id="txtAnimal_Strain" class="easyui-combobox" name="txtAnimal_Strain" style="width: 150px;">
                                    </select>
                                </td>
                                <td class="td_left">
                                    Animal Sex:
                                </td>
                                <td class="td_right">
                                    <select id="txtAnimal_Sex" name="txtAnimal_Sex" class="easyui-combobox" style="width: 150px;">
                                        <option value="Female">Female</option>
                                        <option value="Male">Male</option>
                                    </select>
                                </td>
                                <td class="td_left">
                                    Current Animal Ear Tag:
                                </td>
                                <td class="td_right">
                                    <input id="txtCurrent_Animal_Ear_Tag"></input>
                                </td>
                            </tr>
                            <tr>
                                <td class="td_left">
                                    Animal Quantity:
                                </td>
                                <td class="td_right">
                                    <input id="txtAnimal_Quantity"></input>
                                </td>
                                <td class="td_left">
                                    PDX growth status:
                                </td>
                                <td class="td_right">
                                    <select id="txtPDX_growth_status" class="easyui-combobox" name="txtPDX_growth_status"
                                        style="width: 150px;">
                                    </select>
                                </td>
                                <td class="td_left">
                                    Date of Passage Termination:
                                </td>
                                <td class="td_right">
                                    <input id="txtDate_of_Passage_Termination" class="easyui-datebox" data-options="formatter:myformatter"
                                        editable="false" />
                                </td>
                            </tr>
                            <tr>
                                <td class="td_left" colspan="6">
                                    &nbsp;
                                </td>
                            </tr>
                            <tr>
                                <td class="td_left">
                                    Source Hospital:
                                </td>
                                <td class="td_right">
                                    <select id="txtSource_Hospital" class="easyui-combobox" name="txtSource_Hospital"
                                        style="width: 150px;">
                                    </select>
                                </td>
                                <td class="td_left">
                                    Pathology info available:
                                </td>
                                <td class="td_right">
                                    <select id="txtPathology_info_available" class="easyui-combobox" name="txtPathology_info_available"
                                        style="width: 150px;">
                                    </select>
                                </td>
                                <td class="td_left">
                                    Date of Pathology info:
                                </td>
                                <td class="td_right">
                                    <input id="txtDate_of_Pathology_info_Received" class="easyui-datebox" data-options="formatter:myformatter"
                                        editable="false" />
                                </td>
                            </tr>
                            <tr>
                                <td class="td_left">
                                    Patient No:
                                </td>
                                <td class="td_right">
                                    <input id="txtPatient_No" />
                                </td>
                                <td class="td_left">
                                    Patient Name:
                                </td>
                                <td class="td_right">
                                    <input id="txtPatient_Name" />
                                </td>
                                <td class="td_left">
                                    Patient Age:
                                </td>
                                <td class="td_right">
                                    <input id="txtPatient_Age" />
                                </td>
                            </tr>
                            <tr>
                                <td class="td_left">
                                    Patient Sex:
                                </td>
                                <td class="td_right">
                                    <input id="txtPatient_Sex" />
                                </td>
                                <td class="td_left">
                                    Patient Pathology info Qced:
                                </td>
                                <td class="td_right">
                                    <select id="txtPatient_Pathology_info_Qced" class="easyui-combobox" name="txtPatient_Pathology_info_Qced"
                                        style="width: 150px;">
                                    </select>
                                </td>
                                <td class="td_left">
                                    Comments:
                                </td>
                                <td class="td_right">
                                    <input id="txtComments" />
                                </td>
                            </tr>
                            <tr>
                                <td class="td_left">
                                    &nbsp;
                                </td>
                                <td class="td_right">
                                    &nbsp;
                                    <input id="Reset1" type="reset" value="reset" style="display: none" />
                                    <input type="button" onclick="Check();" id="btnSend4" name="btnSend" class="button-push"
                                        value="Save" />
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
                                           </div>--%>
                                       <%-- </ContentTemplate>
                                        <Triggers>
                                            <asp:AsyncPostBackTrigger ControlID="btnShowData" EventName="Click"></asp:AsyncPostBackTrigger>
                                            <asp:AsyncPostBackTrigger ControlID="btnEdit" EventName="Click"></asp:AsyncPostBackTrigger>
                                        </Triggers>
                                    </asp:UpdatePanel>--%>
                                </div>
                                <!--end block right-->
                            </div>
                        </div>
                    </div>
                </div>
            </div>
            <!-- end blockmain-->
        </div>
    </div>
    <a id="w_StudyNumber_edit" class="fancybox" href="#divStudyNumber_edit"></a>
    <div id="divStudyNumber_edit" style="width: 400px; height: 400px; display: none;">
        <table id="Table1" width="100%" border="0" align="center" cellpadding="0" cellspacing="1"
            class="tb1">
            <tr>
                <td>
                    Pharmacodynamics
                </td>
            </tr>
            <tr>
                <td class="td_left">
                    Study Number:
                </td>
                <td class="td_right">
                    <input id="txtStudy_Number" class="easyui-validatebox" data-options="required:true" />
                </td>
            </tr>
            <tr>
                <td class="td_left">
                    Inoculation Date:
                </td>
                <td class="td_right">
                    <input id="txtInoculation_Date" class="easyui-datebox" data-options="formatter:myformatter,required:true"
                        editable="false" />
                </td>
            </tr>
            <tr>
                <td class="td_left">
                    <input id="hf_Pharmacology_Effect" type="hidden" />
                </td>
                <td class="td_right">
                    <input id="btnStudyNumber" value="Save" type="button" onclick="SavePharmacology_Effect();" />
                </td>
            </tr>
        </table>
    </div>
    <a id="w_Maintain" class="fancybox" href="#divMaintain"></a>
    <div id="divMaintain" style="width: 400px; height: 400px; display: none;">
        <table id="Table2" width="100%" border="0" align="center" cellpadding="0" cellspacing="1"
            class="tb1">
            <tr>
                <td>
                    Maintain
                </td>
            </tr>
            <tr>
                <td class="td_left">
                    Maintain:
                </td>
                <td class="td_right">
                    <input id="txtMaintain" class="easyui-validatebox" data-options="required:true" />
                </td>
            </tr>
            <tr>
                <td class="td_left">
                    DOI:
                </td>
                <td class="td_right">
                    <input id="txtDOI" class="easyui-datebox" data-options="formatter:myformatter,required:true"
                        editable="false" />
                </td>
            </tr>
            <tr>
                <td class="td_left">
                    <input id="Hidden1" type="hidden" />
                </td>
                <td class="td_right">
                    <input id="Button1" value="Save" type="button" onclick="SavePharmacology_Effect();" />
                </td>
            </tr>
        </table>
    </div>
    <!--bottom-->
    <!-- end blockbottom-->
    </form>
      <script type='text/javascript' src='../Common/plotly/plotly-latest.min.js'></script>
</body>
</html>
