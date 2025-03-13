<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="StorageMaps.aspx.cs" Inherits="PDXmodelBase.HuData.StorageMaps" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
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
    <link rel="stylesheet" type="text/css" href="/site_media/HuData/css/base.css?v=2.0" />
    <script type="text/javascript" src="/site_media/HuData/StorageMaps.js"></script>
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



 



    	<style type="text/css">
.ztree li span.button.add {margin-left:2px; margin-right: -1px; background-position:-144px 0; vertical-align:top; *vertical-align:middle}
	</style>
    <style type="text/css">
.ztree li span.demoIcon{padding:0 2px 0 10px;}
.ztree li span.button.icon01{margin:0; background: url(/site_media/zTree/css/zTreeStyle/img/diy/3.png) no-repeat scroll 0 0 transparent; vertical-align:top; *vertical-align:middle}
.ztree li span.button.icon02{margin:0; background: url(/site_media/zTree/css/zTreeStyle/img/diy/4.png) no-repeat scroll 0 0 transparent; vertical-align:top; *vertical-align:middle}
.ztree li span.button.icon03{margin:0; background: url(/site_media/zTree/css/zTreeStyle/img/diy/5.png) no-repeat scroll 0 0 transparent; vertical-align:top; *vertical-align:middle}
.ztree li span.button.icon04{margin:0; background: url(/site_media/zTree/css/zTreeStyle/img/diy/6.png) no-repeat scroll 0 0 transparent; vertical-align:top; *vertical-align:middle}
.ztree li span.button.icon05{margin:0; background: url(/site_media/zTree/css/zTreeStyle/img/diy/7.png) no-repeat scroll 0 0 transparent; vertical-align:top; *vertical-align:middle}
.ztree li span.button.icon06{margin:0; background: url(/site_media/zTree/css/zTreeStyle/img/diy/8.png) no-repeat scroll 0 0 transparent; vertical-align:top; *vertical-align:middle}
	</style>

      <script type="text/javascript">
          $(function () {
              $(window).wresize(content_resize);
              content_resize();
          });
          function content_resize() {
              $('#wrapper').height(fillsizeH(1));
              $('#treeDemo').height(fillsizeH(1)-50);
              
          }
          function fillsizeH(percent) {
              var bodyHeight = document.documentElement.clientHeight;
              return (bodyHeight) * percent;
          }
    </script>
</head>
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
                    <div id="div_left" style="width: 260px">
                    <ul><li style="height:15px;"><a id="btnRefresh" onclick="refresh_zTree();" class="easyui-linkbutton">Refresh</a> </li></ul>
                       <ul id="treeDemo" class="ztree" style="width: 250px;">
                                    </ul>
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
                        <!--center border-->
                        <!--right--->
                        <div id="div_right_r">
                            <div class="bottomPanel">
                                <div class="pad">
                                   
                                       
           <table width="100%" border="0" align="center" cellpadding="0" cellspacing="1" >
                    <tr>
                        
                         <td ><label id="txtAID"></label></td>
                    </tr>
                    <tr>
                      
                         <td>
                    
       <table id="tbMaps" width="800px" border="1" style="background-color: #87CEFA; font-size:9pt" 
                                 align="left" cellpadding="1" cellspacing="1">
          <tbody>
                        </tbody>
       </table>
  
                         </td>
                    </tr>
                    <tr>
                    <td >
                    <a href="javascript:void(0);" class="easyui-linkbutton" iconcls="icon-save" onclick="htmlExport_old();"
                        id="aExport1">Export empty well</a>
                            <asp:Button ID="btnExport1" runat="server" Text="全部导出" OnClick="btnExport1_Click"
                    Style="display: none" />
                        <input id="hfAID" name="hfAID" type="hidden" />
                        <input id="hfclickID" name="hfclickID" type="hidden" /></td></tr>
                                     </table>
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
    </form>
</body>
</html>
