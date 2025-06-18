<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Register.aspx.cs" Inherits="PDXmodelBase.HuData.Register" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=UTF-8" />
    <title>User Registration</title>
    <link href="../Common/waiting/showLoading.css" rel="stylesheet" media="screen" />
    <link rel="shortcut icon" href="../images/favicon.svg" />
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
        h2 {
            font-size: 28px;
        }

        textarea {
            width: 230px;
            border: 1px solid #ccc;
            padding: 2px;
        }

        input {
            width: 220px;
            display: block;
            padding: 4px;
            margin: 0 0 10px 0;
            font-size: 18px;
            color: #3a3a3a;
            font-family: Georgia, serif;
            border-radius: 5px;
        }

            input[type=checkbox] {
                width: 20px;
                margin: 0;
                display: inline-block;
            }

        .button {
            background: url(images/button-bg.png) repeat-x top center;
            border: 1px solid #999;
            -moz-border-radius: 5px;
            padding: 5px;
            color: black;
            font-weight: bold;
            -webkit-border-radius: 5px;
            font-size: 13px;
            width: 70px;
        }

            .button:hover {
                background: white;
                color: black;
            }
    </style>

    <script type="text/javascript">
        function GetQueryString(name) {
            var reg = new RegExp("(^|&)" + name + "=([^&]*)(&|$)");
            var r = window.location.search.substr(1).match(reg);
            if (r != null) return unescape(r[2]); return null;
        }
        function register_click() {
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
                var First_name = $('#First_name').val();
                var Last_name = $('#Last_name').val();
                var Position = $('#Position').val();
                var Department = $('#Department').val();
                var Institution = $('#Institution').val();
                var Street_Address = $('#Street_Address').val();
                var City = $('#City').val();
                var obj = document.getElementById('Country');
                var Country = obj.options[obj.selectedIndex].text;
                var Phone = $('#Phone').val();
                var Fax = $('#Fax').val();
                var Email = $('#Email').val();
          
                var Password = $('#Password').val();
                if (First_name != "" && Last_name != "") {
                    jQuery('#activity_pane').showLoading(
                        {
                            'addClass': 'loading-indicator-bars'
                        }
                    );
                    $.ajax({
                        type: "POST", //提交的类型
                        url: "userLogin.ashx?M=register", //提交地址
                         data: { First_name: First_name, Last_name: Last_name, Position: Position, Department: Department
                    , Institution: Institution, Street_Address: Street_Address, City: City, Country: Country
                    , Phone: Phone, Fax: Fax, Email: Email, Password: Password, Interest: ""
                        }, //参数
                        success: function (results) {
                            jQuery('#activity_pane').hideLoading();
                            $.messager.alert("register", results, "info", null);
                            if (results != "Email address already exists!") {

                            }
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
    <div>
        <div style="text-align: center">
            <img src="../images/CROWN BIOSCIENCE - Final Corporate Logo - RGB.svg" style="width: 300px" alt="" />
        </div>
        <form id="form1" runat="server">
            <div style="text-align: center; margin: 0 auto; padding-top: 30px; width: 800px; height: 600px;" id="activity_pane">
                <table width="100%" border="0" align="center" cellpadding="0" cellspacing="1" class="tb1">
                    <tr>
                        <td style="background-color: rgb(255, 255, 255); text-align: center; font-size: large; font-weight: bolder; color: #FF9900;"
                            colspan="2">User Registration</td>
                    </tr>

                    <tr>
                        <td class="td_right"
                            colspan="2"><b>Please complete this form to become a database user.</b></td>
                    </tr>

                    <tr>
                        <td class="td_left">First Name:<span style="color: Red">*</span>&nbsp;</td>
                        <td class="td_right">
                            <input id="First_name" class="easyui-validatebox" required="true" validtype="length[1,20]" /></td>
                    </tr>
                    <tr>
                        <td class="td_left">Last Name:<span style="color: Red">*</span>&nbsp;</td>
                        <td class="td_right">
                            <input id="Last_name" class="easyui-validatebox" required="true" validtype="length[1,20]" /></td>
                    </tr>
                    <tr>
                        <td class="td_left">Company Email:<span style="color: Red">*</span>&nbsp;</td>
                        <td class="td_right">
                            <input id="Email" class="easyui-validatebox" required="true" validtype="email" />Registration using personal email address will be rejected.</td>
                    </tr>
                   
                    <tr>
                        <td class="td_left">Password:<span style="color: Red">*</span>&nbsp;</td>
                        <td class="td_right">
                            <input id="Password" class="easyui-validatebox" required="true" validtype="safepass" type="password" /></td>
                    </tr>
                    <tr>
                        <td class="td_left">Confirm Password:<span style="color: Red">*</span>&nbsp;</td>
                        <td class="td_right">
                            <input id="ConfirmPassword" class="easyui-validatebox" required="true" validtype="ConfirmPassword" type="password" /></td>
                    </tr>
                    <tr>
                        <td class="td_left">Position/Title:<span style="color: Red">*</span>&nbsp;</td>
                        <td class="td_right">
                            <input id="Position" class="easyui-validatebox" required="true" validtype="length[0,50]" /></td>
                    </tr>
                    <tr>
                        <td class="td_left">Department:<span style="color: Red">*</span>&nbsp;</td>
                        <td class="td_right">
                            <input id="Department" class="easyui-validatebox" required="true" validtype="length[0,50]" /></td>
                    </tr>
                    <tr>
                        <td class="td_left">Institution:<span style="color: Red">*</span>&nbsp;</td>
                        <td class="td_right">
                            <input id="Institution" class="easyui-validatebox" required="true" validtype="length[0,100]" /></td>
                    </tr>
                    <tr>
                        <td class="td_left">Street Address:<span style="color: Red">*</span>&nbsp;</td>
                        <td class="td_right">
                            <input id="Street_Address" class="easyui-validatebox" required="true" validtype="length[0,100]" /></td>
                    </tr>
                    <tr>
                        <td class="td_left">City and State:<span style="color: Red">*</span>&nbsp;</td>
                        <td class="td_right">
                            <input id="City" class="easyui-validatebox" required="true" validtype="length[0,100]" /></td>
                    </tr>
                    <tr>
                        <td class="td_left">Country/Region:<span style="color: Red">*</span>&nbsp;</td>
                        <td class="td_right">
                            <select id="Country" name="Country" style="width: 220px;">
                                <option value="AF">Afghanistan</option>
                                <option value="AL">Albania</option>
                                <option value="DZ">Algeria</option>
                                <option value="AS">American Samoa</option>
                                <option value="AD">Andorra</option>
                                <option value="AI">Anguilla</option>
                                <option value="AQ">Antarctica</option>
                                <option value="AG">Antigua And Barbuda</option>
                                <option value="AR">Argentina</option>
                                <option value="AM">Armenia</option>
                                <option value="AW">Aruba</option>
                                <option value="AU">Australia</option>
                                <option value="AT">Austria</option>
                                <option value="AZ">Ayerbaijan</option>
                                <option value="BS">Bahamas, The</option>
                                <option value="BH">Bahrain</option>
                                <option value="BD">Bangladesh</option>
                                <option value="BB">Barbados</option>
                                <option value="BY">Belarus</option>
                                <option value="BZ">Belize</option>
                                <option value="BE">Belgium</option>
                                <option value="BJ">Benin</option>
                                <option value="BM">Bermuda</option>
                                <option value="BT">Bhutan</option>
                                <option value="BO">Bolivia</option>
                                <option value="BV">Bouvet Is</option>
                                <option value="BA">Bosnia and Herzegovina</option>
                                <option value="BW">Botswana</option>
                                <option value="BR">Brazil</option>
                                <option value="IO">British Indian Ocean Territory</option>
                                <option value="BN">Brunei</option>
                                <option value="BG">Bulgaria</option>
                                <option value="BF">Burkina Faso</option>
                                <option value="BI">Burundi</option>
                                <option value="KH">Cambodia</option>
                                <option value="CM">Cameroon</option>
                                <option value="CA">Canada</option>
                                <option value="CV">Cape Verde</option>
                                <option value="KY">Cayman Is</option>
                                <option value="CF">Central African Republic</option>
                                <option value="TD">Chad</option>
                                <option value="CL">Chile</option>
                                <option value="CN">China</option>
                                <option value="HK">China (Hong Kong S.A.R.)</option>
                                <option value="MO">China (Macau S.A.R.)</option>
                                <option value="TW">China (Taiwan Province)</option>
                                <option value="CX">Christmas Is</option>
                                <option value="CC">Cocos (Keeling) Is</option>
                                <option value="CO">Colombia</option>
                                <option value="KM">Comoros</option>
                                <option value="CK">Cook Islands</option>
                                <option value="CR">Costa Rica</option>
                                <option value="CI">Cote D'Ivoire (Ivory Coast)</option>
                                <option value="HR">Croatia (Hrvatska)</option>
                                <option value="CY">Cyprus</option>
                                <option value="CZ">Czech Republic</option>
                                <option value="CD">Democratic Republic of the Congo</option>
                                <option value="DK">Denmark</option>
                                <option value="DM">Dominica</option>
                                <option value="DO">Dominican Republic</option>
                                <option value="DJ">Djibouti</option>
                                <option value="TP">East Timor</option>
                                <option value="EC">Ecuador</option>
                                <option value="EG">Egypt</option>
                                <option value="SV">El Salvador</option>
                                <option value="GQ">Equatorial Guinea</option>
                                <option value="ER">Eritrea</option>
                                <option value="EE">Estonia</option>
                                <option value="ET">Ethiopia</option>
                                <option value="FK">Falkland Is (Is Malvinas)</option>
                                <option value="FO">Faroe Islands</option>
                                <option value="FJ">Fiji Islands</option>
                                <option value="FI">Finland</option>
                                <option value="FR">France</option>
                                <option value="GF">French Guiana</option>
                                <option value="PF">French Polynesia</option>
                                <option value="TF">French Southern Territories</option>
                                <option value="MK">F.Y.R.O. Macedonia</option>
                                <option value="GA">Gabon</option>
                                <option value="GM">Gambia, The</option>
                                <option value="GE">Georgia</option>
                                <option value="DE">Germany</option>
                                <option value="GH">Ghana</option>
                                <option value="GI">Gibraltar</option>
                                <option value="GR">Greece</option>
                                <option value="GL">Greenland</option>
                                <option value="GD">Grenada</option>
                                <option value="GP">Guadeloupe</option>
                                <option value="GU">Guam</option>
                                <option value="GT">Guatemala</option>
                                <option value="GN">Guinea</option>
                                <option value="GW">Guinea-Bissau</option>
                                <option value="GY">Guyana</option>
                                <option value="HT">Haiti</option>
                                <option value="HM">Heard and McDonald Is</option>
                                <option value="HN">Honduras</option>
                                <option value="HU">Hungary</option>
                                <option value="IS">Iceland</option>
                                <option value="IN">India</option>
                                <option value="ID">Indonesia</option>
                                <option value="IE">Ireland</option>
                                <option value="IL">Israel</option>
                                <option value="IT">Italy</option>
                                <option value="JM">Jamaica</option>
                                <option value="JP">Japan</option>
                                <option value="JO">Jordan</option>
                                <option value="KZ">Kayakhstan</option>
                                <option value="KE">Kenya</option>
                                <option value="KI">Kiribati</option>
                                <option value="KR">Korea, South</option>
                                <option value="KW">Kuwait</option>
                                <option value="KG">Kyrgyzstan</option>
                                <option value="LA">Laos</option>
                                <option value="LV">Latvia</option>
                                <option value="LB">Lebanon</option>
                                <option value="LS">Lesotho</option>
                                <option value="LR">Liberia</option>
                                <option value="LI">Liechtenstein</option>
                                <option value="LT">Lithuania</option>
                                <option value="LU">Luxembourg</option>
                                <option value="MG">Madagascar</option>
                                <option value="MW">Malawi</option>
                                <option value="MY">Malaysia</option>
                                <option value="MV">Maldives</option>
                                <option value="ML">Mali</option>
                                <option value="MT">Malta</option>
                                <option value="MH">Marshall Is</option>
                                <option value="MR">Mauritania</option>
                                <option value="MU">Mauritius</option>
                                <option value="MQ">Martinique</option>
                                <option value="YT">Mayotte</option>
                                <option value="MX">Mexico</option>
                                <option value="FM">Micronesia</option>
                                <option value="MD">Moldova</option>
                                <option value="MC">Monaco</option>
                                <option value="MN">Mongolia</option>
                                <option value="MS">Montserrat</option>
                                <option value="MA">Morocco</option>
                                <option value="MZ">Mozambique</option>
                                <option value="MM">Myanmar</option>
                                <option value="NA">Namibia</option>
                                <option value="NR">Nauru</option>
                                <option value="NP">Nepal</option>
                                <option value="NL">Netherlands, The</option>
                                <option value="AN">Netherlands Antilles</option>
                                <option value="NC">New Caledonia</option>
                                <option value="NZ">New Zealand</option>
                                <option value="NI">Nicaragua</option>
                                <option value="NE">Niger</option>
                                <option value="NG">Nigeria</option>
                                <option value="NU">Niue</option>
                                <option value="NO">Norway</option>
                                <option value="NF">Norfolk Island</option>
                                <option value="MP">Northern Mariana Is</option>
                                <option value="OM">Oman</option>
                                <option value="PK">Pakistan</option>
                                <option value="PW">Palau</option>
                                <option value="PA">Panama</option>
                                <option value="PG">Papua new Guinea</option>
                                <option value="PY">Paraguay</option>
                                <option value="PE">Peru</option>
                                <option value="PH">Philippines</option>
                                <option value="PN">Pitcairn Island</option>
                                <option value="PL">Poland</option>
                                <option value="PT">Portugal</option>
                                <option value="PR">Puerto Rico</option>
                                <option value="QA">Qatar</option>
                                <option value="CG">Republic of the Congo</option>
                                <option value="RE">Reunion</option>
                                <option value="RO">Romania</option>
                                <option value="RU">Russia</option>
                                <option value="SH">Saint Helena</option>
                                <option value="KN">Saint Kitts And Nevis</option>
                                <option value="LC">Saint Lucia</option>
                                <option value="PM">Saint Pierre and Miquelon</option>
                                <option value="VC">Saint Vincent And The Grenadines</option>
                                <option value="WS">Samoa</option>
                                <option value="WM">San Marino</option>
                                <option value="ST">Sao Tome and Principe</option>
                                <option value="SA">Saudi Arabia</option>
                                <option value="SN">Senegal</option>
                                <option value="SC">Seychelles</option>
                                <option value="SL">Sierra Leone</option>
                                <option value="SG">Singapore</option>
                                <option value="SK">Slovakia</option>
                                <option value="SI">Slovenia</option>
                                <option value="SB">Solomon Islands</option>
                                <option value="SO">Somalia</option>
                                <option value="ZA">South Africa</option>
                                <option value="GS">South Georgia & The S. Sandwich Is</option>
                                <option value="ES">Spain</option>
                                <option value="LK">Sri Lanka</option>
                                <option value="SR">Suriname</option>
                                <option value="SJ">Svalbard And Jan Mayen Is</option>
                                <option value="SZ">Swaziland</option>
                                <option value="SE">Sweden</option>
                                <option value="CH">Switzerland</option>
                                <option value="SY">Syria</option>
                                <option value="TJ">Tajikistan</option>
                                <option value="TZ">Tanzania</option>
                                <option value="TH">Thailand</option>
                                <option value="TL">Timor-Leste</option>
                                <option value="TG">Togo</option>
                                <option value="TK">Tokelau</option>
                                <option value="TO">Tonga</option>
                                <option value="TT">Trinidad And Tobago</option>
                                <option value="TN">Tunisia</option>
                                <option value="TR">Turkey</option>
                                <option value="TC">Turks And Caicos Is</option>
                                <option value="TM">Turkmenistan</option>
                                <option value="TV">Tuvalu</option>
                                <option value="UG">Uganda</option>
                                <option value="UA">Ukraine</option>
                                <option value="AE">United Arab Emirates</option>
                                <option value="GB">United Kingdom</option>
                                <option value="US" selected="selected">United States</option>
                                <option value="UM">United States Minor Outlying Is</option>
                                <option value="UY">Uruguay</option>
                                <option value="UZ">Uzbekistan</option>
                                <option value="VU">Vanuatu</option>
                                <option value="VA">Vatican City State (Holy See)</option>
                                <option value="VE">Venezuela</option>
                                <option value="VN">Vietnam</option>
                                <option value="VG">Virgin Islands (British)</option>
                                <option value="VI">Virgin Islands (US)</option>
                                <option value="WF">Wallis And Futuna Islands</option>
                                <option value="EH">Western Sahara</option>
                                <option value="YE">Yemen</option>
                                <option value="ZM">Zambia</option>
                                <option value="ZW">Zimbabwe</option>
                            </select>
                        </td>
                    </tr>
                    <tr>
                        <td class="td_left">Phone number:<span style="color: Red">*</span>&nbsp;</td>
                        <td class="td_right">
                            <input id="Phone" class="easyui-validatebox" required="true" /></td>
                    </tr>
                    <tr>
                        <td class="td_left">Fax number:</td>
                        <td class="td_right">
                            <input id="Fax" class="easyui-validatebox" validtype="faxno" /></td>
                    </tr>
                    <tr>
                        <td class="td_left"></td>
                        <td class="td_right">
                            <input id="register" type="button" value="SUBMIT" onclick="register_click()" class="button orange" />
                            <input id="reset" type="reset" value="RESET" class="button orange" />
                        </td>
                    </tr>
                    <tr>
                        <td class="td_right" colspan="2">
                            <b><span class="para">NOTE: </span>If approved, you will receive an email with your access credentials within 
                1 work day.<br />
                                Already have an account? <a href="javascript:history.go(-1);">Click 
                here to log in.</a></b></td>
                    </tr>
                </table>
            </div>
        </form>

    </div>
</body>
</html>
