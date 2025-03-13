<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CompletedProject.aspx.cs" Inherits="PDXmodelBase.HuData.CompletedProject" %>

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
    <script type="text/javascript" src="/site_media/HuData/CompletedProject.js"></script>
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
  
    <input id="hfmodel_ids" type="hidden" />
    <input id="hfRequest_id" type="hidden" />
    <input id="Searchdata" type="hidden" />
    <input id="hfPN" type="hidden" />
    <input id="hfNoliveAnimal" type="hidden" />
    <input id="book_MODEL_ID" type="hidden" />
       <asp:HiddenField ID="hfAvailableColumns" runat="server" />
    <input id="rid" type="hidden" />
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <div id="context" style="overflow-y: scroll">
      
        <table cellpadding="0" cellspacing="0" border="0" width="100%">
            <tr>
                <td>
                    <table id="dgRequest" title="" data-options="toolbar:'#tb'">
                    </table>
                </td>
            </tr>
        </table>
           <div id="tb" style="padding: 5px; height: auto">
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
                            <option value="Signed">Signed</option>
                            <option value="Cancelled">Cancelled</option>
                        </select>
            </div>
        </div>
          <a href="javascript:void();" class="easyui-linkbutton" iconcls="icon-search" onclick="getdgRequest();">
                    Search</a> <a id="aExport1" class="easyui-linkbutton" href="javascript:void();" iconcls="icon-save"
                        onclick="htmlExport1();">Export</a>
                <asp:Button ID="btnExport1" runat="server" OnClick="btnExport1_Click" Style="display: none"
                    Text="全部导出" />
           
        </div></div> 
             <div id="tb2" style="padding: 5px; height: auto">
            <div style="margin-bottom: 5px">
                Model ID:
                <input id="Text1" name="searchModelID" type="text" />
                Project Number:
                <input id="Text2" name="searchProjectNumber" type="text" />
                   JSD:
                <input id="searchJSD" name="searchJSD" type="text" />
                 PM:
                <input id="searchPM2" name="searchPM2" type="text" />
                DOI:
                <select id="searchDOI" name="searchDOI">
                    <option value=""></option>
                    <option value="Yes">Yes</option>
                    <option value="No">No</option>
                </select>
                    Completed Per Study:
                <select id="searchCompleted" name="searchCompleted">
                     <option value="All" selected="selected">All</option>
                    <option value="No" >No</option>
                    <option value="Yes">Yes</option>
               
                </select>
                
                <a href="javascript:void();" class="easyui-linkbutton" iconcls="icon-search" onclick="doSearchMonitor();">
                    Search</a> <a href="javascript:void();" class="easyui-linkbutton" iconcls="icon-save" onclick="htmlExport_old2();"
                        id="a1">Export</a>
                <asp:Button ID="btnExport2" runat="server" Text="全部导出" OnClick="btnExport2_Click"
                    Style="display: none" />
              </div>
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
      <a id="w-exportCol" class="fancybox" href="#exportCol"></a>
    <div id="exportCol" style="width: 300px; height: 200px; display: none;">
        Available Columns:<br />
        <select id="AvailableColumns" name="AvailableColumns" class="easyui-combotree" multiple
            style="width: 250px;">
        </select><br />
        <input id="btnConfirm" type="button" value="Confirm" onclick="confirm1();" />
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
                    <input id="txtDeliver" class="easyui-datebox" data-options="formatter:myformatter"
                        editable="false" />
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
                    <input id="txtReceive" class="easyui-datebox" data-options="formatter:myformatter"
                        editable="false" />
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
                    Tissue collection:
                </td>
                 <td class="td_right">
                    <label id="txtTissue" ></label>

                </td>
            </tr>
            <tr>
               <td class="td_left"></td>
                  <td class="td_right">  
                      <input id="hfAnimal_Handover_mid" type="hidden" />
                       <input id="hfAnimal_Handover_rid" type="hidden" />
            </td>
            </tr>
        </table>
    </div>
    </form>
</body>
</html>
