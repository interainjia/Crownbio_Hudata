<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Husbandry.aspx.cs" Inherits="PDXmodelBase.HuData.Husbandry" %>

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
    <link rel="stylesheet" type="text/css" href="../Common/easyui-1.3.2/themes/bootstrap/easyui.css" />
    <link rel="stylesheet" type="text/css" href="../Common/easyui-1.3.2/themes/icon.css" />
    <script type="text/javascript" src="../Common/fancyBox/source/jquery.fancybox.js?v=2.1.4"></script>
    <link rel="stylesheet" type="text/css" href="../Common/fancyBox/source/jquery.fancybox.css?v=2.1.4"
        media="screen" />
    <link rel="stylesheet" type="text/css" href="../Common/css/form.css" />
    <link rel="stylesheet" type="text/css" href="/site_media/uploadify/uploadify.css" />
    <script type='text/javascript' src='/site_media/uploadify/jquery.uploadify.min.js'></script>
    <link rel="stylesheet" type="text/css" href="../Common/css/Button.css" />
    <script type='text/javascript' src='/site_media/HuData/Husbandry.js'></script>
    <script type='text/javascript' src='/site_media/HuData/export.js'></script>
</head>
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
<body>
    <form id="form1" runat="server">
      <div id="context" style="overflow-y: scroll">
    <div id="tb2" style="padding: 5px; ">
        <div style="margin-bottom: 5px">
            <table cellpadding="0" cellspacing="0" border="0" width="100%">
                <tr>
                    <td>
                        <div id="testID">
                        </div>
                    </td>
                   
                </tr>
                <tr> <td>
                        <div id="testID2">
                        </div>
                    </td></tr>
                <tr>
                    <td>
                        <div style="padding-top: 5px">
                            <table>
                                <tr>
                                <td>Animal info: </td>
                                    <td>
                                       <input type="file" name="uploadify3" id="uploadify3" class="shiny-blue" />
                                    </td>
                                    <td>
                                       <a class="easyui-linkbutton" href="javascript:$('#uploadify3').uploadify('upload','*')">
                                            Upload Files</a>
                                    </td>
                                </tr>
                                  <tr>
                                    <td>Z-group: </td>
                                    <td>
                                        <input type="file" name="uploadify4" id="uploadify4" class="shiny-blue" />
                                    </td>
                                    <td>
                                       <a class="easyui-linkbutton" href="javascript:$('#uploadify4').uploadify('upload','*')">
                                            Upload Files</a>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <%--<input id="txtDate" class="easyui-datebox" data-options="formatter:myformatter" editable="false" />--%>
                                    </td>
                                    <td>
                                        <a href="javascript:void();" class="easyui-linkbutton" iconcls="icon-search" onclick="getdgHusbandry();">
                                            Search</a>
                                    </td>
                                    <td>
                                        <a href="javascript:void();" class="easyui-linkbutton" iconcls="icon-save" onclick="htmlExport_old();"
                                            id="aExport1">Export</a>
                                        <asp:Button ID="btnExport1" runat="server" Text="全部导出" OnClick="btnExport1_Click"
                                            Style="display: none" />
                                    </td>
                                </tr>
                            </table>
                        </div>
                    </td>
                </tr>
            </table>
        </div>
    </div>
    <table cellpadding="0" cellspacing="0" border="0" width="100%">
        <tr>
            <td>
                <table id="dgHusbandry" title="" data-options="toolbar:'#tb2'">
                </table>
            </td>
        </tr>
    </table>
    </div>
    </form>
</body>
</html>
