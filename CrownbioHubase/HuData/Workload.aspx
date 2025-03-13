<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Workload.aspx.cs" Inherits="PDXmodelBase.HuData.Workload" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <title></title>
    <meta name="description" content="CrownBio HuBase" />
    <script type="text/javascript" src="../Common/easyui-1.3.2/jquery-1.8.0.min.js"></script>
    <script type="text/javascript" src="/site_media/chart/js/swfobject.js"></script>
    <script type="text/javascript" src="/site_media/hubase/js/base.js"></script>
    <script type='text/javascript' src='../Common/autocomplete/lib/jquery.bgiframe.min.js'></script>
    <script type='text/javascript' src='../Common/autocomplete/lib/jquery.ajaxQueue.js'></script>
    <script type='text/javascript' src='../Common/autocomplete/lib/thickbox-compressed.js'></script>
    <script type='text/javascript' src='../Common/autocomplete/jquery.autocomplete.js'></script>
    <script type='text/javascript' src='../Common/autocomplete/localdata.js'></script>
    <link rel="stylesheet" type="text/css" href="../Common/autocomplete/jquery.autocomplete.css" />
    <link rel="stylesheet" type="text/css" href="../Common/autocomplete/lib/thickbox.css" />
    <link rel="stylesheet" type="text/css" href="/site_media/hubase/plugins/tree/css/style.css" />
    <script type="text/javascript" src="../Common/easyui-1.2.5/jquery.wresize.js"></script>
    <script type="text/javascript" src="../Common/easyui-1.3.2/jquery.easyui.min.js"></script>
    <link rel="stylesheet" type="text/css" href="/site_media/HuData/css/base.css" />
    <link rel="stylesheet" type="text/css" href="../Common/easyui-1.3.2/themes/bootstrap/easyui.css" />
    <link rel="stylesheet" type="text/css" href="../Common/easyui-1.3.2/themes/icon.css" />
        <script type="text/javascript" src="/site_media/HuData/workload.js"></script>
            <script type="text/javascript" src="/site_media/HuData/export.js"></script>
    <link rel="stylesheet" type="text/css" href="/site_media/hubase/plugins/dv_tabs/dv_tabs.css" />
    <script type="text/javascript" language="javascript" src="/site_media/hubase/plugins/dv_tabs/dv_tabs.js"></script>
    <script type="text/javascript" src="/site_media/hubase/js/util.js"></script>
    <script type="text/javascript" src="/site_media/hubase/js/compareable_barchart_tag.js"></script>
    <script type="text/javascript" src="../Common/fancyBox/source/jquery.fancybox.js?v=2.1.4"></script>
    <link rel="stylesheet" type="text/css" href="../Common/fancyBox/source/jquery.fancybox.css?v=2.1.4"
        media="screen" />
    <link href="../Common/waiting/showLoading.css" rel="stylesheet" media="screen" />
    <script type="text/javascript" src="../Common/waiting/jquery.showLoading.js"></script>
    <!--[if gte IE 8]><script type="text/javascript" src="../Common/textcontent.js"></script><![endif]-->
    <script type="text/javascript">
        $(function () {
            $('#my_chart').css('display', 'none');
        })
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
   
    <script type="text/javascript">
        function showFlash(z) {
            $('#my_chart').css('display', 'block');
            swfobject.embedSWF("open-flash-chart.swf", "my_chart", "700", "400", "9.0.0", "expressInstall.swf", { "data-file": "Workload.aspx?M=workload%26txtName=" + z + "%26cbxDep=" + $('#cbxDep').val() }, { "wmode": "transparent" });
        }
      
    </script>
</head>
<!-- end blockhead-->
<body>
    <form id="form1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <div id="context" style="overflow-y: scroll">
           <table cellpadding="0" cellspacing="0" width="100%">
                                            <tr>
                                                <td style="width: 100%;" valign="top">
                                                    <div>  <span style="display: inline">
                                                            <select id="cbxDep" onchange="ddlDT();">
                                                                <option value="SD">SD</option>
                                                                <option value="JSD">JSD</option>
                                                                <option value="DM">DM</option>
                                                                <option value="DT group">DT group</option>
                                                            </select>
                                                            Name:<select id="txtName" class="easyui-combobox" name="txtName" style="width: 150px;">
                    </select>
                                                         <%--   <input type="button" onclick="AddmiRNA2Multi();" title="Add to compare" id="doAdd"
                                                                name="doAdd" class="draw_button_add" value="" />--%>
                                                                  <a id="dosearch1"
                                                                name="dosearch1"  class="easyui-linkbutton" iconcls="icon-search" onclick="getdgWorkload();" >Search</a>
                                                        </span>
                                                   
                                                            <input type="hidden" id="compared_objects_list" name="compared_objects_list" value="" />
                                                            <div class="select_gene_info_box" id="select_gene_info_box">
                                                                    <div class="selected_gene" id="selected_gene">
                                                                        <div class="compare_gene_box" id="compare_gene_box" name="compare_gene">
                                                                        </div>
                                                                    </div>
                                                                <div class="clearfix">
                                                                </div>
                                                            </div>
                                                       </div>
                                                    <div id="my_chart">
                                                        
                                                    </div>
                                                   <%--<div style="padding-top:10px">
                                                        <span style="margin-left: 10px; margin-top: 5px; clear: both"><a id="zoom_in_chart"
                                                            name="zoom_in_chart" onclick="zoom_chart('my_chart','in');">
                                                            <img alt="" src="/site_media/hubase/images/zoom_in.gif" title="Zoom in" /></a>&nbsp;&nbsp;&nbsp;&nbsp;
                                                            <a id="zoom_out_chart" name="zoom_out_chart" onclick="javascript:zoom_chart('my_chart','out');">
                                                                <img alt="" src="/site_media/hubase/images/zoom_out.gif" title="Zoom out" /></a>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                                                   <img alt="" onclick="save_image()" src="/site_media/hubase/images/view_photo.png" title="View image"/>
                                                        </span>
                                                    </div>--%>
                                                </td>
                                            </tr>
                                        </table>    
                                        <table cellpadding="0" cellspacing="0" width="100%">
                                        <tr>
                                            <td>
                                            <div id="tb1" style="padding: 5px; height: auto;">
                                                        <div style="text-align: left">
                                                            <table cellpadding="0" cellspacing="0">
                                                                <tr>
                                                                    <td>
                                                                        <a href="javascript:void(0);" class="easyui-linkbutton" iconcls="icon-save" onclick="htmlExport_old()"
                                                                            style="display: none" id="aExport1">Export</a>
                                                                    </td>
                                                                    <td>
                                                                        <asp:Button ID="btnExport1" runat="server" Text="全部导出" OnClick="btnExport1_Click"
                                                                            Style="display: none" />
                                                                    </td>
                                                                </tr>
                                                            </table>
                                                        </div>
                                                    </div>
                                            <div id="ic" class="easyui-panel" closed="open">
                                                        <table id="dgWorkload" cellpadding="0" cellspacing="0" toolbar="#tb1">
                                                        </table>
                                                    </div>
                                                    <br />
                                                     <table id="dgDTgroup" cellpadding="0" cellspacing="0" >
                                                        </table>
                                            </td>
                                        </tr>
                                         
                                        </table>              
    </div>
    <a id="open-window" class="fancybox" href="#open1"></a>
    <div id="open1" style="overflow: scroll; display: none; width: 1200px; height: 560px;">
        <iframe runat="server" id="iframeChart" width="100%" height="580px" frameborder="0"
            border="0"></iframe>
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
    </form>
</body>
</html>
