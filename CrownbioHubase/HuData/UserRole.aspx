<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="UserRole.aspx.cs" Inherits="PDXmodelBase.HuData.UserRole" %>

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
        <script type="text/javascript" src="/site_media/HuData/UserRole.js"></script>
    <script type="text/javascript" src="../Common/fancyBox/source/jquery.fancybox.js?v=2.1.4"></script>
    <link rel="stylesheet" type="text/css" href="../Common/fancyBox/source/jquery.fancybox.css?v=2.1.4"
        media="screen" />
    <link rel="stylesheet" type="text/css" href="../Common/css/form.css" />
    <link rel="stylesheet" type="text/css" href="/site_media/uploadify/uploadify.css" />
    <script type='text/javascript' src='/site_media/uploadify/jquery.uploadify.min.js'></script>
        <link rel="stylesheet" type="text/css" href="../Common/css/Button.css" />
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
         <div id="context" style="overflow: auto">
     <input id="hfRoleID" type="hidden" />
     <div id="tb2" style="padding: 5px;">
                <div style="margin-bottom: 5px">
                   <a href="javascript:void();" class="easyui-linkbutton" iconcls="icon-add"   onclick="add();">
                    Add</a>
                     <a href="javascript:void();" class="easyui-linkbutton" iconcls="icon-edit"   onclick="edit();">
                    Edit</a>
                        <a href="javascript:void();" class="easyui-linkbutton" iconcls="icon-cancel"   onclick="deleteRole();">
                    Delete</a>
                  <a href="javascript:void();" class="easyui-linkbutton" iconcls="icon-search"   onclick="query();">
                    Search</a>
                    </div>
      </div>
     <table id="dgUserRole" cellspacing="0" cellpadding="0"  data-options="toolbar:'#tb2'">
        </table>
            <a id="open_userRole" class="fancybox" href="#inline1"></a>
                <div id="inline1" style="width: 900px; height: 480px;display: none;">
                    <iframe runat="server" id="iframeUserRole" width="100%" height="480px" frameborder="0"
            border="0"></iframe>
                </div>
                </div>
    </form>
</body>
</html>
