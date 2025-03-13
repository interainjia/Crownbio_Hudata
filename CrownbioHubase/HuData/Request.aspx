<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Request.aspx.cs" Inherits="PDXmodelBase.HuData.Request" %>

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
    <link rel="stylesheet" type="text/css" href="../Common/easyui-1.3.2/themes/default/easyui.css" />
    <link rel="stylesheet" type="text/css" href="../Common/easyui-1.3.2/themes/icon.css" />
    <script type="text/javascript" src="/site_media/HuData/request.js"></script>
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
</head>
<body>
    <form id="form1" runat="server">
      <input id="hfmodel_ids" type="hidden" />
       <input id="hfRequest_id" type="hidden" />
          <input id="Searchdata" type="hidden" />
       
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <div id="context" style="overflow: auto">
        <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional">
            <ContentTemplate>
                <table width="100%" border="0" align="center" cellpadding="0" cellspacing="1" class="tb1">
                    <tr>
                        <td class="td_left">
                            Client:<span style="color: Red">*</span>
                        </td>
                        <td class="td_right">
                            <input id="txtClient" class="easyui-validatebox" required="true" />
                        </td>
                        <td class="td_left">
                            Project Number:<span style="color: Red">*</span>
                        </td>
                        <td class="td_right">
                            <input id="txtProjectNumber"  class="easyui-validatebox" required="true"></input>
                        </td>
                    </tr>
                    <tr>
                        <td class="td_left">
                            BD:
                        </td>
                        <td class="td_right">
                            <input id="ccBD" name="ccBD" disabled />
                        </td>
                        <td class="td_left">
                            SD:</td>
                        <td class="td_right">
                            <input id="ccSD" name="ccSD" disabled />
                        </td>
                    </tr>
                 <%--   <tr>
                        <td class="td_left">
                            Others to Notify:
                        </td>
                        <td class="td_right" colspan="2">
                            <textarea id="txtOthers" cols="20" rows="3" style="width: 250px"></textarea>
                            <span style="font-size: 12px">(Emails separated by whitespace)</span>
                        </td>
                        <td class="td_right">
                            &nbsp;</td>
                    </tr>--%>
                <%--    <tr>
                        <td class="td_left">
                            &nbsp;
                        </td>
                        <td class="td_right" colspan="3">
                            <span style="font-size: 12px">(This request will send to BD, SD and Others person)</span>
                        </td>
                    </tr>--%>
                    <tr>
                        <td class="td_left">
                            Cancer Type:<span style="color: Red">*</span>
                        </td>
                        <td class="td_right">
                            <select id="ddlTumor_Type" class="easyui-combobox" name="ddlTumor_Type" style="width: 150px;">
                            </select>
                        </td>
                        <td class="td_left">
                            Subtype:
                        </td>
                        <td class="td_right">
                                <select id="ddlSubtype" name="ddlSubtype" class="easyui-combotree" multiple  style="width: 250px;">
                            </select>
                        </td>
                    </tr>
                    <tr>
                        <td class="td_left">
                            Model ID:
                        </td>
                        <td class="td_right">
                            <input id="txtModel_ID" name="txtModel_ID" type="text" />
                            <input id="doAdd" class="draw_button_add" name="doAdd" 
                                onclick="AddMulti();" title="Add to list" type="button" value="" />
                                   <input id="doclean" class="draw_button_clean" name="doclean" 
                                onclick="closeAll_tag_action();" title="Clean all" type="button" value="" />
                            <br />
                            <input id="compared_objects_list" 
                                name="compared_objects_list" type="hidden" value="" />
                            <div id="select_gene_info_box" class="select_gene_info_box">
                                <div id="selected_gene" class="selected_gene">
                                    <div id="compare_gene_box" class="compare_gene_box" name="compare_gene">
                                    </div>
                                </div>
                                <div class="clearfix">
                                </div>
                            </div>
                             <span style="font-size: 12px">Cancer Type or Model ID is required.</span></td>
                        <td class="td_left">
                            Potential Study Size:<span style="color: Red">*</span>
                        </td>
                        <td class="td_right">
                            <input id="txtPotential_Study_Size" type="text" class="easyui-numberbox" required="true" />
                        </td>
                    </tr>
                    <tr>
                        <td class="td_left">
                            Special Requirements:
                        </td>
                        <td class="td_right" colspan="3">
                            <textarea id="txtRequirements" cols="20" rows="5" style="width: 450px"></textarea>
                            <input type="button" onclick="Check();" id="btnSend3" name="btnSend" class="button-push"
                                value="Send" />
                             <input type="button" onclick="doModify();" id="btnModify" name="btnModify" class="button-push"
                                value="Modify" />
                        </td>
                    </tr>
                    <tr>
                        <td class="td_right" colspan="4" style="text-align: right; padding-right: 5px; width: 90%">
                            &nbsp;<asp:Button ID="btnSend2" runat="server" OnClick="btnSend_OnClick" Style="display: none" />
                        </td>
                    </tr>
                </table>
            </ContentTemplate>
        </asp:UpdatePanel>
        <table cellpadding="0" cellspacing="0" border="0" width="98%">
            <tr>
                <td>
                    <table id="dgRequest" title="" data-options="toolbar:'#tb'">
                    </table>
                </td>
            </tr>
        </table>
            <div id="tb" style="padding: 5px; height: auto">
        <div style="margin-bottom: 5px">        
             Cancer type:
                  <select id="searchCancertype" class="easyui-combobox" name="searchCancertype" style="width: 100px;">
                            </select>
          Subtype:
            <select id="searchSubtype" name="searchSubtype" class="easyui-combotree" multiple  style="width: 250px;">
                            </select>
             Model ID:
               <input id="searchModelID" name="searchModelID" type="text" />
               Responded:
                     <select id="searchResponded"  name="searchResponded"  class="easyui-combobox" editable="false">
                               <option selected="selected" value="All">All</option>
                                <option value="Have responded">Have responded</option>
                                <option value="Not responded">Not responded</option>
                            </select>
            <a href="javascript:void();" class="easyui-linkbutton" iconcls="icon-search"  onclick="getdgRequest();">
                Search</a>
        </div>
    </div>
      <div id="tb2" style="padding: 5px; height: auto">
            <div style="margin-bottom: 5px">
              
                <a href="javascript:void();" class="easyui-linkbutton" iconcls="icon-ok"   onclick="ConfirmRequest();">
                    Confirm project booking</a>
            </div>
        </div>
          <table cellpadding="0" cellspacing="0" border="0" width="98%">
                    <tr>
                      <td>
                    <table id="dgSelectMice" title="" data-options="toolbar:'#tb2'">
                    </table>
                </td>
                    </tr>
                </table>
       

    </div>
     <a id="w-searchGene" class="fancybox" href="#inline1"></a>
    <div id="inline1" style="width: 800px; height: 400px; display: none;">
        <label id="ContinueNote">
        </label>
        <table id="genegrid" cellpadding="0" cellspacing="0">
        </table>
        <div style="float: right; padding-top: 10px; padding-right: 5px;">
            <input type="button" onclick="Continue_Addselect();" value="Continue" style="height: 20px" />
        </div>
    </div>
    <a id="no-results" class="fancybox" href="#inline2"></a>
    <div id="inline2" style="width: 300px; height: 100px; display: none;">
        <label id="lblnoResults">
        </label>
    </div>
     <a id="w-modifylog" class="fancybox" href="#divModifylog"></a>
    <div id="divModifylog" style="width: 800px; height: 400px; display: none;">
        <table id="dgModifylog" cellpadding="0" cellspacing="0">
        </table>
    </div>
    </form>
</body>
</html>
