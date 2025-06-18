<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="PDXmodelBase.HuData.Login" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Login</title>
    <link rel="shortcut icon" href="../images/favicon.svg" />
    <link rel="stylesheet" type="text/css" href="../Common/easyui-1.3.2/themes/particular_blue.css" />
    <script src="../Common/easyui-1.2.5/jquery-1.7.1.min.js" type="text/javascript"></script>
    <script type="text/javascript" src="../Common/easyui-1.2.5/jquery.easyui.min.js"></script>
    <link rel="stylesheet" type="text/css" href="../Common/easyui-1.2.5/themes/default/easyui.css" />
    <script type="text/javascript">
        $(function () {
            function isPlaceholer() {
                var input = document.createElement('input');
                return "placeholder" in input;
            }
            //不支持的代码
            if (!isPlaceholer()) {
                input("username", "Username"); //s即时input框的ID
                input("password", "Password"); //s即时input框的ID
            }
            function input(theInput, val) {
                var $input = $("#" + theInput + "");
                var val = val;
                $input.attr({ value: val });
                $input.focus(function () {
                    if ($input.val() == val) {
                        $(this).attr({ value: "" });
                    }
                }).blur(function () {
                    if ($input.val() == "") {
                        $(this).attr({ value: val });
                    }
                });
            }
        });
    </script>
    <style type="text/css">
        html, body {
            height: 100%;
        }



        body {
            font: 12px 'Lucida Sans Unicode', 'Trebuchet MS', Arial, Helvetica;
            margin: 0;
            background-color: #d9dee2;
            background-image: -webkit-gradient(linear, left top, left bottom, from(#ebeef2), to(#d9dee2));
            background-image: -webkit-linear-gradient(top, #ebeef2, #d9dee2);
            background-image: -moz-linear-gradient(top, #ebeef2, #d9dee2);
            background-image: -ms-linear-gradient(top, #ebeef2, #d9dee2);
            background-image: -o-linear-gradient(top, #ebeef2, #d9dee2);
            background-image: linear-gradient(top, #ebeef2, #d9dee2);
        }



        /*--------------------*/



        #login {
            background-color: #fff;
            background-image: -webkit-gradient(linear, left top, left bottom, from(#fff), to(#eee));
            background-image: -webkit-linear-gradient(top, #fff, #eee);
            background-image: -moz-linear-gradient(top, #fff, #eee);
            background-image: -ms-linear-gradient(top, #fff, #eee);
            background-image: -o-linear-gradient(top, #fff, #eee);
            background-image: linear-gradient(top, #fff, #eee);
            height: 240px;
            width: 400px;
            margin: -150px 0 0 -230px;
            padding: 30px;
            position: absolute;
            top: 300px;
            left: 50%;
            z-index: 0;
            -moz-border-radius: 3px;
            -webkit-border-radius: 3px;
            border-radius: 3px;
            -webkit-box-shadow: 0 0 2px rgba(0, 0, 0, 0.2), 0 1px 1px rgba(0, 0, 0, .2), 0 3px 0 #fff, 0 4px 0 rgba(0, 0, 0, .2), 0 6px 0 #fff, 0 7px 0 rgba(0, 0, 0, .2);
            -moz-box-shadow: 0 0 2px rgba(0, 0, 0, 0.2), 1px 1px 0 rgba(0, 0, 0, .1), 3px 3px 0 rgba(255, 255, 255, 1), 4px 4px 0 rgba(0, 0, 0, .1), 6px 6px 0 rgba(255, 255, 255, 1), 7px 7px 0 rgba(0, 0, 0, .1);
            box-shadow: 0 0 2px rgba(0, 0, 0, 0.2), 0 1px 1px rgba(0, 0, 0, .2), 0 3px 0 #fff, 0 4px 0 rgba(0, 0, 0, .2), 0 6px 0 #fff, 0 7px 0 rgba(0, 0, 0, .2);
        }



            #login:before {
                content: '';
                position: absolute;
                z-index: -1;
                border: 1px dashed #ccc;
                top: 5px;
                bottom: 5px;
                left: 5px;
                right: 5px;
                -moz-box-shadow: 0 0 0 1px #fff;
                -webkit-box-shadow: 0 0 0 1px #fff;
                box-shadow: 0 0 0 1px #fff;
            }



        /*--------------------*/



        h1 {
            text-shadow: 0 1px 0 rgba(255, 255, 255, .7), 0px 2px 0 rgba(0, 0, 0, .5);
            text-transform: uppercase;
            text-align: center;
            color: #666;
            margin: 0 0 10px 0;
            letter-spacing: 4px;
            font: normal 26px/1 Verdana, Helvetica;
            position: relative;
        }



            h1:after, h1:before {
                background-color: #777;
                content: "";
                height: 1px;
                position: absolute;
                top: 15px;
                width: 120px;
            }



            h1:after {
                background-image: -webkit-gradient(linear, left top, right top, from(#777), to(#fff));
                background-image: -webkit-linear-gradient(left, #777, #fff);
                background-image: -moz-linear-gradient(left, #777, #fff);
                background-image: -ms-linear-gradient(left, #777, #fff);
                background-image: -o-linear-gradient(left, #777, #fff);
                background-image: linear-gradient(left, #777, #fff);
                right: 0;
            }



            h1:before {
                background-image: -webkit-gradient(linear, right top, left top, from(#777), to(#fff));
                background-image: -webkit-linear-gradient(right, #777, #fff);
                background-image: -moz-linear-gradient(right, #777, #fff);
                background-image: -ms-linear-gradient(right, #777, #fff);
                background-image: -o-linear-gradient(right, #777, #fff);
                background-image: linear-gradient(right, #777, #fff);
                left: 0;
            }



        /*--------------------*/



        fieldset {
            border: 0;
            padding: 0;
            margin: 5px;
        }



        /*--------------------*/



        #inputs input {
            background: #f1f1f1 url(../images/login-sprite.png) no-repeat;
            padding: 15px 15px 15px 30px;
            margin: 0 0 10px 0;
            width: 353px; /* 353 + 2 + 45 = 400 */
            border: 1px solid #ccc;
            -moz-border-radius: 5px;
            -webkit-border-radius: 5px;
            border-radius: 5px;
            -moz-box-shadow: 0 1px 1px #ccc inset, 0 1px 0 #fff;
            -webkit-box-shadow: 0 1px 1px #ccc inset, 0 1px 0 #fff;
            box-shadow: 0 1px 1px #ccc inset, 0 1px 0 #fff;
        }



        #username {
            background-position: 5px -2px !important;
        }



        #password {
            background-position: 5px -52px !important;
        }



        #inputs input:focus {
            background-color: #fff;
            border-color: #e8c291;
            outline: none;
            -moz-box-shadow: 0 0 0 1px #e8c291 inset;
            -webkit-box-shadow: 0 0 0 1px #e8c291 inset;
            box-shadow: 0 0 0 1px #e8c291 inset;
        }



        /*--------------------*/

        #actions {
            margin: 0px 0 2px 0;
        }



        #submit, #submit2 {
            background-color: #ffb94b;
            background-image: -webkit-gradient(linear, left top, left bottom, from(#fddb6f), to(#ffb94b));
            background-image: -webkit-linear-gradient(top, #fddb6f, #ffb94b);
            background-image: -moz-linear-gradient(top, #fddb6f, #ffb94b);
            background-image: -ms-linear-gradient(top, #fddb6f, #ffb94b);
            background-image: -o-linear-gradient(top, #fddb6f, #ffb94b);
            background-image: linear-gradient(top, #fddb6f, #ffb94b);
            -moz-border-radius: 3px;
            -webkit-border-radius: 3px;
            border-radius: 3px;
            text-shadow: 0 1px 0 rgba(255,255,255,0.5);
            -moz-box-shadow: 0 0 1px rgba(0, 0, 0, 0.3), 0 1px 0 rgba(255, 255, 255, 0.3) inset;
            -webkit-box-shadow: 0 0 1px rgba(0, 0, 0, 0.3), 0 1px 0 rgba(255, 255, 255, 0.3) inset;
            box-shadow: 0 0 1px rgba(0, 0, 0, 0.3), 0 1px 0 rgba(255, 255, 255, 0.3) inset;
            border-width: 1px;
            border-style: solid;
            border-color: #d69e31 #e3a037 #d5982d #e3a037;
            float: left;
            height: 30px;
            padding: 0;
            text-align: center;
            padding-top: 5px;
            width: 100px;
            cursor: pointer;
            font: bold 15px Arial, Helvetica;
            color: #8f5a0a;
        }



            #submit:hover, #submit:focus {
                background-color: #fddb6f;
                background-image: -webkit-gradient(linear, left top, left bottom, from(#ffb94b), to(#fddb6f));
                background-image: -webkit-linear-gradient(top, #ffb94b, #fddb6f);
                background-image: -moz-linear-gradient(top, #ffb94b, #fddb6f);
                background-image: -ms-linear-gradient(top, #ffb94b, #fddb6f);
                background-image: -o-linear-gradient(top, #ffb94b, #fddb6f);
                background-image: linear-gradient(top, #ffb94b, #fddb6f);
            }

            #submit2:hover, #submit2:focus {
                background-color: #fddb6f;
                background-image: -webkit-gradient(linear, left top, left bottom, from(#ffb94b), to(#fddb6f));
                background-image: -webkit-linear-gradient(top, #ffb94b, #fddb6f);
                background-image: -moz-linear-gradient(top, #ffb94b, #fddb6f);
                background-image: -ms-linear-gradient(top, #ffb94b, #fddb6f);
                background-image: -o-linear-gradient(top, #ffb94b, #fddb6f);
                background-image: linear-gradient(top, #ffb94b, #fddb6f);
            }


            #submit:active {
                outline: none;
                -moz-box-shadow: 0 1px 4px rgba(0, 0, 0, 0.5) inset;
                -webkit-box-shadow: 0 1px 4px rgba(0, 0, 0, 0.5) inset;
                box-shadow: 0 1px 4px rgba(0, 0, 0, 0.5) inset;
            }

            #submit2:active {
                outline: none;
                -moz-box-shadow: 0 1px 4px rgba(0, 0, 0, 0.5) inset;
                -webkit-box-shadow: 0 1px 4px rgba(0, 0, 0, 0.5) inset;
                box-shadow: 0 1px 4px rgba(0, 0, 0, 0.5) inset;
            }


            #submit::-moz-focus-inner {
                border: none;
            }

            #submit2::-moz-focus-inner {
                border: none;
            }



        #actions a {
            color: #3151A2;
            float: right;
            line-height: 10px;
            margin-left: 0px;
        }



        /*--------------------*/



        #back {
            display: block;
            text-align: center;
            position: relative;
            top: 60px;
            color: #999;
        }
    </style>

    <script type="text/javascript">
        function quickQueryCust(evt) {
            evt = (evt) ? evt : ((window.event) ? window.event : "") //兼容IE和Firefox获得keyBoardEvent对象
            var key = evt.keyCode ? evt.keyCode : evt.which; //兼容IE和Firefox获得keyBoardEvent对象的键值
            if (key == 13) { //判断是否是回车事件。
                userLogin_click();

            }
        }
    </script>




    <script type="text/javascript">
        function userLogin_click() {
            var name = $('#username').val();
            var pwd = $('#password').val();
            var remember = "true";
            if ($('#id_remember').attr("checked") != "checked") {
                remember = "false";
            }
            if (name != "" && pwd != "") {
                $.ajax({
                    type: "POST",
                    url: "userLogin.ashx?M=userLogin",
                    data: "name=" + name + "&pwd=" + URLencode(pwd) + "&remember=" + remember,
                    success: function (results) {
                        //表示从start，到end之间的字符串，包括start位置的字符但是不包括end位置的字符
                        var msg = results.substring(0, results.indexOf(':'));
                        //表示从start位置开始取length个字符串
                        var days = results.substr(results.indexOf(':') + 1, results.length - results.indexOf(':') - 1);
                        if (results == "Successful login") {
                            window.location.href = "index.aspx";
                        }
                        else if (msg == "User Trial") {
                            $.messager.alert("login", days + " days remaining for your trial period", "info", function () {
                                window.location.href = "index.aspx";
                            });
                        }
                        else {
                            $.messager.alert("info", results, "info", null);
                        }
                    }
                })
            }
        }
        function trial_click() {
            $.ajax({
                type: "POST",
                url: "userLogin.ashx?M=trial",
                success: function (results) {

                    //表示从start，到end之间的字符串，包括start位置的字符但是不包括end位置的字符
                    var msg = results.substring(0, results.indexOf(':'));
                    //表示从start位置开始取length个字符串
                    var days = results.substr(results.indexOf(':') + 1, results.length - results.indexOf(':') - 1);
                    if (results == "Successful login") {
                        window.location.href = "index.aspx";
                    }
                    else if (msg == "User Trial") {
                        $.messager.alert("login", days + " days remaining for your trial period", "info", function () {
                            window.location.href = "index.aspx";
                        });
                    }
                    else {
                        $.messager.alert("info", results, "info", null);
                    }
                }
            })
        }

        function URLencode(sStr) {
            return escape(sStr).replace(/\+/g, '%2B').replace(/\"/g, '%22').replace(/\'/g, '%27').replace(/\//g, '%2F').replace(/\#/g, '%23').replace(/\&/g, '%26');
        }
    </script>

</head>
<body>
    <div style="text-align: center">
        <img src="../images/CROWN BIOSCIENCE - Final Corporate Logo - RGB.svg" style="width: 300px" alt="" />
    </div>
    <form id="login" runat="server">
        <div style="text-align: center">
            <a style="font-size: 20px;">Access CrownBio </a><a style="font-size: 20px; font-weight: 600;"><span style="color: #056A7B">Hu</span><span style="color: #056A7B">Data</span>
            </a>
        </div>
        <fieldset id="inputs">

            <input id="username" type="text" placeholder="Username" autofocus required />

            <input id="password" type="password" onkeydown="return quickQueryCust(event)" placeholder="Password" required />

        </fieldset>
        <fieldset id="actions">
            <table>
                <tr>
                    <td style="width: 280px;">
                        <input id="submit" value="Log in" onclick="userLogin_click()" />
                    </td>
                    <td style="width: 200px;">
                        <input id="id_remember" name="id_remember" type="checkbox" style="float: left" /><label
                            for="id_remember" title="If checked you will stay logged in for 1 week">
                            Remember Me</label></td>

                </tr>
            </table>
            <table>
                <tr>
                    <td style="width: 280px;">
                        <a style="float: left" href="Register.aspx">Not a user? Register now!</a>
                    </td>
                    <td style="width: 200px">
                        <a style="float: left" href="http://password.crownbio.com">Forgot your password?</a>
                    </td>
                </tr>
                <tr>
                    <td style="padding-top: 10px" colspan="2">We recommend Google Chrome or Firefox for the best browser experience on this website.</td>
                </tr>
            </table>


            <%--  <a href="">Forgot your password?</a>--%>
        </fieldset>
    </form>
</body>
</html>
