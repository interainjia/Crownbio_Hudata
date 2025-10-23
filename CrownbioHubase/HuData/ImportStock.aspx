<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ImportStock.aspx.cs" Inherits="PDXmodelBase.HuData.ImportStock" %>

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
    <script type="text/javascript" src="/site_media/HuData/ImportStock.js"></script>
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
    <form id="uploadexcel" enctype="multipart/form-data" method="post" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <div id="context" style="overflow: auto">
        <table cellpadding="0" cellspacing="0" border="0" width="100%">
        <tr> 
       <td> 
          <span style="color:Red">Region: </span> <input id="Radio1" type="radio" name="S_region" value="CBCN" checked="checked"/>CBCN
           <input id="Radio2" type="radio" name="S_region" value="CBSD"/>CBSD
             <input id="Radio3" type="radio" name="S_region" value="CBSG"/>CBSG
           <input id="Radio4" type="radio" name="S_region" value="CBNC"/>CBNC
           </td>
        </tr>
            <tr>
                <td>
                    <div id="activity_pane">
                        Import Stocks:&nbsp;
                        <input id="FileUpload" name="FileUpload" type="file" style="width: 400px; background: White"
                            class="easyui-validatebox" validtype="length[1,100]" />
                        <a href="javascript:void();" class="easyui-linkbutton" iconcls="icon-add" onclick="doAction1();">Import Cache</a> 
                        <a id="btnSaveStock" class="easyui-linkbutton" href="javascript:void();" iconcls="icon-redo" name="btnSaveStock"
                    onclick="btnSaveStock();">Confirm</a><br />
                         Import Withdraw: <input id="FileUpload2" name="FileUpload2" type="file" style="width: 400px; background: White"
                            class="easyui-validatebox" validtype="length[1,100]" />
                        <a href="javascript:void();" class="easyui-linkbutton" iconcls="icon-add" onclick="doAction2();">Import Cache</a>
                         <a id="btnSaveWithdraw" class="easyui-linkbutton" href="javascript:void();" iconcls="icon-redo" name="btnSaveWithdraw"
                    onclick="btnSaveWithdraw();">Confirm</a>
                        <table cellpadding="0" cellspacing="0" border="0" width="100%">
                            <tr>
                                <td>
                                    <table id="dgTissueStock" title="" data-options="toolbar:'#tb1'">
                                    </table>
                                </td>
                            </tr>
                        </table>
                    </div>
                </td>
            </tr>
        </table>
        <div id="tb1" style="padding: 5px; height: auto">
            <div style="margin-bottom: 5px;">
               </div>
        </div>
    </div>
    </form>
</body>
</html>
