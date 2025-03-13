<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Forget.aspx.cs" Inherits="PDXmodelBase.HuData.Forget" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=UTF-8" />
    <title>User Registration</title>
    <link href="../Common/waiting/showLoading.css" rel="stylesheet" media="screen" />
    <link rel="shortcut icon" href="../images/minlogo.png" />
	<link rel="stylesheet" type="text/css" href="../Common/easyui-1.2.5/themes/icon.css" />
	<link rel="stylesheet" type="text/css" href="../Common/easyui-1.2.5/demo/demo.css" />
    <link rel="stylesheet" type="text/css" href="../Common/easyui-1.2.5/themes/default/easyui.css" />
	<script type="text/javascript" src="../Common/easyui-1.2.5/jquery-1.7.1.min.js"></script>
      <%--<script type="text/javascript" src="../Common/waiting/jquery-1.3.2.min.js"></script>--%>
     <script type="text/javascript" src="../Common/waiting/jquery.showLoading.js"></script>
	<script type="text/javascript" src="../Common/easyui-1.2.5/jquery.easyui.min.js"></script>
    <link rel="stylesheet" type="text/css" href="../Common/easyui-1.3.2/themes/particular_blue.css" />
    <link rel="stylesheet" type="text/css" href="../Common/css/form.css" />
    <link rel="stylesheet" type="text/css" href="../Common/css/buttons.css"/>
    <style type="text/css">
	div#activity_pane {
           border: 0px solid #CCCCCC;
        }
	.loading-indicator-bars {
		background-image: url('../Common/waiting/image/loading-bars.gif');
		width: 150px;
	}

   </style>
    <style type="text/css">
         h2
         {
             font-size:28px;
         }
		textarea{
			width:230px;
			border:1px solid #ccc;
			padding:2px;
		}
		input				{ width: 220px; display: block; padding: 4px; margin: 0 0 10px 0; font-size: 18px;
					  color: #3a3a3a; font-family: Georgia, serif;}
input[type=checkbox]{ width: 20px; margin: 0; display: inline-block; }
					  
.button				{ background: url(images/button-bg.png) repeat-x top center; border: 1px solid #999;
					  -moz-border-radius: 5px; padding: 5px; color: black; font-weight: bold;
					  -webkit-border-radius: 5px; font-size: 13px;  width: 70px; }
.button:hover		{ background: white; color: black; }
	</style>

    <script type="text/javascript">
        function forgot_click() {
            var flag = true;
            $('#form1 input').each(function () {
                if ($(this).attr('required') || $(this).attr('validType')) {
                    if (!$(this).validatebox('isValid')) {
                        flag = false;
                        return;
                    }
                }
            });
            if (!flag) {
                alert('Please fill out the missing info as indicated.');
                return false;
            }

            if (flag) {

                var Email = $('#Email').val();

                if (Email != "") {
                    jQuery('#activity_pane').showLoading(
	 			         {
	 			             'addClass': 'loading-indicator-bars'
	 			         }
				        );
                    $.ajax({
                        type: "POST",
                        url: "userLogin.ashx?M=forgot",
                        data: { Email: Email
                        }, //参数
                        success: function (results) {
                            jQuery('#activity_pane').hideLoading();
                            $.messager.alert("forgot password", results, "info", null);
                           
                        }
                    })
                }
            }
        }
    </script>

    <script type="text/javascript">
        $.extend($.fn.validatebox.defaults.rules, {
            safepass: {// 验证密码
                validator: function (value, param) {
                    return safePassword(value);
                },
                message: 'Your password must contain at least 6 characters and be consist of both numbers and letters, e.g. Crown01. The password is case sensitive.'
            },
            ConfirmPassword: {
                validator: function (value, param) {
                    return ConfirmPass(value);
                },
                message: 'Retype password must match to password.'
            },
            faxno: {// 验证传真 
                validator: function (value) {
                    //            return /^[+]{0,1}(\d){1,3}[ ]?([-]?((\d)|[ ]){1,12})+$/i.test(value); 
                    return /^((\(\d{2,3}\))|(\d{3}\-))?(\(0\d{2,3}\)|0\d{2,3}-)?[1-9]\d{6,7}(\-\d{1,4})?$/i.test(value);
                },
                message: 'Please enter a valid fax number.'
            },
            phone: {
                validator: function (value) {
                    return /((\d{11})|^((\d{7,8})|(\d{4}|\d{3})-(\d{7,8})|(\d{4}|\d{3})-(\d{7,8})-(\d{4}|\d{3}|\d{2}|\d{1})|(\d{7,8})-(\d{4}|\d{3}|\d{2}|\d{1}))$)/.test(value);
                },
                message: 'Please enter a valid phone number. e.g. 12345678901、1234-12345678-1234.'
            }
        });
        var safePassword = function (value) {
            return !(/^(([A-Z]*|[a-z]*|\d*|[-_\~!@#\$%\^&\*\.\(\)\[\]\{\}<>\?\\\/\'\"]*)|.{0,5})$|\s/.test(value));
        }
        var ConfirmPass = function (value) {
            var old = $('#Password').val();
            if (value !== old) {
                return false;
            }
            else {
                return true;
            }
        }
    </script>
    <script type="text/javascript">
        function GetCheckBoxListValue(objID) {
            var v = new Array();
            var CheckBoxList = document.getElementById(objID);
            if (CheckBoxList.tagName == "TABLE") {
                for (i = 0; i < CheckBoxList.rows.length; i++)
                    for (j = 0; j < CheckBoxList.rows[i].cells.length; j++)
                        if (CheckBoxList.rows[i].cells[j].childNodes[0])
                            if (CheckBoxList.rows[i].cells[j].childNodes[0].checked == true)
                                v.push(CheckBoxList.rows[i].cells[j].childNodes[1].innerHTML);
            }
            if (CheckBoxList.tagName == "SPAN") {
                for (i = 0; i < CheckBoxList.childNodes.length; i++)
                    if (CheckBoxList.childNodes[i].tagName == "INPUT")
                        if (CheckBoxList.childNodes[i].checked == true) {
                            i++;
                            v.push(CheckBoxList.childNodes[i].innerHTML);
                        }
            }
            return v;
        }
    </script>
</head>
<body>
<div >
    <div style="text-align:center;">

<div class="head_bg">
        	<div class="head_logo">
             <%--<asp:Image ID="Image1" ImageAlign="Left" runat="server" ImageUrl="../images/logoleft.jpg"  Height="45px" Width="120px"/>--%>
			<img src="../../images/CROWN BIOSCIENCE - Final Corporate Logo - RGB.svg" class="crown-logo" />
            </div>
        </div>
</div>
    <form id="form1" runat="server">
    
    <div style="text-align:center;margin:0 auto; padding-top:30px;width: 800px; height: 600px;" id="activity_pane">
       <table width="100%" border="0" align="center" cellpadding="0" cellspacing="1" class="tb1">
       <tr>
            <td style="background-color:rgb(255, 255, 255);text-align:center; font-size: large; font-weight: bolder; color: #FF9900;" 
                colspan="2">Forgot Your Password?</td>  
       </tr>
		
       <tr>
            <td class="td_right"
                colspan="2">Please enter the email you gave us when you created this account. If we find an account with the email address, we will send you an email.</td>  
       </tr>
		
         <tr>
			<td class="td_left">Email:<span style="color:Red">*</span>&nbsp;</td>
			<td class="td_right"><input id="Email" class="easyui-validatebox"  required="true"  /></td>
		</tr>
        <tr>
            <td class="td_left">
               
            </td>
            <td class="td_right">
             <input id="forgot" type="button" value="Submit" onclick="forgot_click()" class="button orange"/>
               <input id="back" type="button" value="Back" class="button orange"  onclick="javascript:history.go(-1);"/> 
            </td>
        </tr>
        </table>
	</div>
    </form>

    </div>
</body>
</html>
