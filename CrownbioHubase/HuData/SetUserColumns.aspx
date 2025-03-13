<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SetUserColumns.aspx.cs" Inherits="PDXmodelBase.HuData.SetUserColumns" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
     <script type="text/javascript" src="/Common/easyui-1.3.2/jquery-1.8.0.min.js"></script>
     <%--<script type="text/javascript" src="http://libs.baidu.com/jquery/1.10.2/jquery.min.js"></script>--%>
         <%--<script type="text/javascript" src="../site_media/CellData/base.js"></script>--%>
             <link rel="stylesheet" type="text/css" href="../Common/css/buttons2.css" />
  
     <script type="text/javascript">

         function GetQueryString(name) {
             var reg = new RegExp("(^|&)" + name + "=([^&]*)(&|$)", "i");
             var r = window.location.search.substr(1).match(reg);
             if (r != null) return unescape(r[2]); return null;
         }

         $(function () {
           
                     $.ajax({
                         type: "POST",
                         dataType: "json",
                         url: "Person.ashx?M=getTableDisplayColumns&&Table=" + GetQueryString("Table"),
                         success: function (data) {
                             for (var i = 0; i < data.length; i++) {
                                 var object = data[i];
                                 $("#s1").append("<option value='" + object.id + "'>" + object.text + "</option>");
                             }
                             autoColumns();
                         }
                     });


         });
</script>
    <script type="text/javascript">
        function autoColumns() {

            $("#s1 option:first,#s2 option:first").attr("selected", true);

            $("#s1").dblclick(function () {
                $("option:selected", this).clone().appendTo("#s2");
                $("option:selected", this).remove();
                $("#s1 option:first,#s2 option:first").attr("selected", true);
            });

            $("#s2").dblclick(function () {
                $("option:selected", this).clone().appendTo("#s1");
                $("option:selected", this).remove();
                $("#s1 option:first,#s2 option:first").attr("selected", true);
            });

            $("#add").click(function () {
                $("#s1 option:selected").clone().appendTo("#s2");
                $("#s1 option:selected").remove();
                $("#s1 option:first,#s2 option:first").attr("selected", true);
            });

            $("#remove").click(function () {
                $("#s2 option:selected").clone().appendTo("#s1");
                $("#s2 option:selected").remove();
                $("#s1 option:first,#s2 option:first").attr("selected", true);
            });

            $("#addall").click(function () {
                $("#s1 option").clone().appendTo("#s2");
                $("#s1 option").remove();
                $("#s1 option:first,#s2 option:first").attr("selected", true);
            });

            $("#removeall").click(function () {
                $("#s2 option").clone().appendTo("#s1");
                $("#s2 option").remove();
                $("#s1 option:first,#s2 option:first").attr("selected", true);
            });

            $("#s1up").click(function () {
                var so = $("#s1 option:selected");
                if (so.get(0).index != 0) {
                    so.each(function () {
                        $(this).prev().before($(this));
                    });
                }
            });

            $("#s1down").click(function () {
                var alloptions = $("#s1 option");
                var so = $("#s1 option:selected");

                if (so.get(so.length - 1).index != alloptions.length - 1) {
                    for (i = so.length - 1; i >= 0; i--) {
                        var item = $(so.get(i));
                        item.insertAfter(item.next());
                    }
                }
            });

            $("#s2up").click(function () {
                var so = $("#s2 option:selected");
                if (so.get(0).index != 0) {
                    so.each(function () {
                        $(this).prev().before($(this));
                    });
                }
            });

            $("#s2down").click(function () {
                var alloptions = $("#s2 option");
                var so = $("#s2 option:selected");

                if (so.get(so.length - 1).index != alloptions.length - 1) {
                    for (i = so.length - 1; i >= 0; i--) {
                        var item = $(so.get(i));
                        item.insertAfter(item.next());
                    }
                }
            });
        }
      
    </script>
    <script type="text/javascript">
        function SaveUserColumns() {
            var arr1 = new Array();
            var arr2 = new Array();
            $("#s1 option").each(function () {
                var txt = $(this).text(); //获取单个text
                arr1.push(txt);
            });
            $("#s2 option").each(function () {
                var txt = $(this).text(); //获取单个text
                arr2.push(txt);
            });
            var all1 = arr1.toString();
            var all2 = arr2.toString();
            if (arr2.length > 0) {
                $.ajax({
                    type: "POST",
                    dataType: "text",
                    url: "Person.ashx?M=SaveUserColumns&Table=" + GetQueryString("Table"),
                    data: "s1=" + all1 + "&s2=" + all2,
                    success: function (data) {
                        if (data == "") {
                            parent.getUserColumns();
                            parent.$.fancybox.close();
                        }
                    }
                });
            }
        }
    </script>
</head>
<body>    
<form id="form1" runat="server">
   <table style="width:488px; height:250px" border="0" cellpadding="0" cellspacing="0">
        <tr>
            <td>
            </td>
            <td>
                Hidden Fields:
            </td>
            <td>
            </td>
            <td>
                Display:
            </td>
            <td>
            </td>
        </tr>
        <tr>
            <td width="29">
                <input type="button" name="s1up" id="s1up" value="↑" /><br />
                <input type="button" name="s1down" id="s1down" value="↓" />
            </td>
            <td width="200">
                <select name="s1" size="15" multiple="multiple" id="s1" style="width: 100%">
                </select>
            </td>
            <td width="37" align="center">
                <input type="button" name="add" id="add" value=">" /><br />
                <input type="button" name="remove" id="remove" value="<" /><br />
                <input type="button" name="addall" id="addall" value=">>" /><br />
                <input type="button" name="removeall" id="removeall" value="<<" />
            </td>
            <td width="200">
                <select name="s2" size="15" multiple="multiple" id="s2" style="width: 100%;">
                </select>
            </td>
            <td>
                <input type="button" name="s2up" id="s2up" value="↑" /><br />
                <input type="button" name="s2down" id="s2down" value="↓" />
            </td>
        </tr>
        <tr><td>  <input id="btnSave" type="button" value="Save" onclick="SaveUserColumns()" class="button-push"/></td></tr>
    </table>
      
    </form>
</body>

</html>
