<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ProjectBooking.aspx.cs" Inherits="PDXmodelBase.HuData.ProjectBooking" %>

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
    <script type="text/javascript" src="../Common/css/persontree.js"></script>
    <link rel="stylesheet" type="text/css" href="../Common/easyui-1.3.2/themes/bootstrap/easyui.css" />
    <link rel="stylesheet" type="text/css" href="../Common/easyui-1.3.2/themes/icon.css" />
    <script type="text/javascript" src="/site_media/HuData/ProjectBooking.js?v=1.0"></script>
        <script type="text/javascript" src="/site_media/HuData/export.js"></script>
    <script type="text/javascript" src="../Common/fancyBox/source/jquery.fancybox.js?v=2.1.4"></script>
    <link rel="stylesheet" type="text/css" href="../Common/fancyBox/source/jquery.fancybox.css?v=2.1.4"
        media="screen" />
    <link rel="stylesheet" type="text/css" href="../Common/css/form.css" />
    <link rel="stylesheet" type="text/css" href="/site_media/uploadify/uploadify.css" />
    <script type='text/javascript' src='/site_media/uploadify/jquery.uploadify.min.js'></script>
    <link rel="stylesheet" type="text/css" href="../Common/css/buttons3.css" />
 <link href="../Common/waiting/showLoading.css" rel="stylesheet" media="screen" /> 
  <script type="text/javascript" src="../Common/waiting/jquery.showLoading.js"></script>

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
        div#activity_pane
        {
        }
        .loading-indicator-bars
        {
            background-image: url('../Common/waiting/image/loading2.gif');
            width: 150px;
        }
    </style>
</head>
<body>
     <form id="uploadexcel" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
   

    <div id="context" style="overflow:auto">
        <table cellpadding="0" cellspacing="0" border="0" width="100%">
      
            <tr>
                <td>
                    <table id="dgProjectBooking" title="" data-options="toolbar:'#tb'">
                    </table>
                </td>
            </tr>
        </table>
            <div id="tb" style="padding: 5px; height: auto">
        <div style="margin-bottom: 5px">     
         Project Number:<input id="txtPN" name="txtPN" type="text" />   
             Animal Booking:<input id="txtAnimalBooking" name="txtAnimalBooking" type="text" />
             Further Expanding:<input id="txtFurtherExpanding" name="txtFurtherExpanding" type="text" />
                Revive:<input id="txtRevive" name="txtRevive" type="text" />
             Model ID:
               <input id="searchModelID" name="searchModelID" type="text" />
               Animal Number:<input id="searchAnimalNumber" name="searchAnimalNumber" type="text" />
                BD:
               <input id="searchBD" name="searchBD" type="text" />
                SD:
               <input id="searchSD" name="searchSD" type="text" />
            <a href="javascript:void();" class="easyui-linkbutton" iconcls="icon-search"  onclick="getdgProjectBooking();">
                Search</a>
             <a href="javascript:void();" class="easyui-linkbutton" iconcls="icon-save" onclick="htmlExport_old();"
                                                                            id="aExport1" >Export</a>
                                                                         
                                                                          <asp:Button ID="btnExport1" runat="server" Text="全部导出" OnClick="btnExport1_Click" 
                                                                            Style="display: none" />
              
        </div>
    </div> 
    </div>
     <a id="w-searchGene" class="fancybox" href="#inline1"></a>
    <div id="inline1" style="width: 800px; height: 400px; display: none;">
        <label id="ContinueNote">
        </label>
        <table id="genegrid" cellpadding="0" cellspacing="0">
        </table>
    </div>
    <a id="no-results" class="fancybox" href="#inline2"></a>
    <div id="inline2" style="width: 300px; height: 100px; display: none;">
        <label id="lblnoResults">
        </label>
    </div>
    </form>
</body>
</html>
