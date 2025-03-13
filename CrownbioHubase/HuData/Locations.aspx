<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Locations.aspx.cs" Inherits="PDXmodelBase.HuData.Locations" %>

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
    <link rel="stylesheet" type="text/css" href="/site_media/HuData/css/base.css" />
    <script type="text/javascript" src="/site_media/HuData/Locations.js"></script>
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
    <link rel="stylesheet" type="text/css" href="/site_media/hubase/plugins/tree/css/style.css" />
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
            $('#treeDemo').height(fillsizeH(1) - 30);

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
                                    <ul>
                                        <li>
                                            <p>
                                                &nbsp;&nbsp;&nbsp;&nbsp;[ <a id="copy" href="javascript:void();" title="Copy" onclick="return false;">
                                                    Copy</a> ] &nbsp;&nbsp;&nbsp;&nbsp;[ <a id="paste" href="javascript:void();" title="Paste"
                                                        onclick="return false;">Paste</a> ]
                                                <br />
                                            </p>
                                        </li>
                                    </ul>
                                    <table width="100%" border="0" align="center" cellpadding="0" cellspacing="1" class="tb1">
                                        <tr>
                                            <td class="td_left">
                                                Parent ID:
                                            </td>
                                            <td class="td_right">
                                                <input id="txtAID" disabled="disabled" style="width: 250px" />
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="td_left">
                                                Location Type:
                                            </td>
                                            <td class="td_right">
                                                <select id="txtLocation_Type" class="easyui-combobox" name="txtLocation_Type" style="width: 150px;">
                                                </select>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="td_left">
                                                Name:
                                            </td>
                                            <td class="td_right">
                                                <input id="txtName" disabled="disabled" />
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="td_left">
                                                Rows:
                                            </td>
                                            <td class="td_right">
                                                <input id="txtRows" />
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="td_left">
                                                Columns:
                                            </td>
                                            <td class="td_right">
                                                <input id="txtColumns" />
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="td_left">
                                            </td>
                                            <td class="td_right">
                                                <a class="easyui-linkbutton" onclick="btnSaveLocation();" id="btnSave">Save</a>
                                                <input id="hfAID" type="hidden" />
                                            </td>
                                        </tr>
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
