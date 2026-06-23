<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="webAPItest.aspx.cs" Inherits="PDXmodelBase.HuData.webAPItest" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
    <script type="text/javascript" src="../Common/easyui-1.3.2/jquery-1.8.0.min.js"></script>
    <script type="text/javascript">
        $(function () {
            //var aaa = $.ajax({
            //    type: "GET",
            //    dataType: "json",
            //    url: "/actionapi/Hudata/Get?id=1",
            //    success: function (msg) {
            //        console.log("success:" + msg);
            //    }
            //});
            //var bbb = $.ajax({
            //    type: "POST",
            //    contentType: "application/json", 
            //    dataType: "json",
            //    url: "/actionapi/Hudata/Post",
            //    data: JSON.stringify({ value: "1" }),
            //    success: function (msg) {
            //        console.log("success:" + msg);
            //    }
            //});

        });
        function addRequest() {
            var test = $.ajax({
                type: "POST",
                contentType: "application/json",
                dataType: "json",
                url: "/actionapi/Hudata/SaveRequest",
                data: JSON.stringify({
                    email: "runjun.jia@crownbio.com",
                    password: "123456",
                    txtClient: "Prelude Therapeutics",
                    txtProjectNumber: "E3445-U2252-TC2",
                    ccBD: "",
                    ccSD: "yi.zhang@crownbio.com",
                    txtType_of_Study: "In vivo Efficacy study (IVEF)",
                    ddlTumor_Type: "",
                    ddlSubtype1: "",
                    ddlSubtype2: "",
                    txtModel_ID: "LY2264,LY9615,LY2298,LY0257,LY3604",
                    txtPotential_Study_Size: "32",
                    txtRequirements: "",
                    txtDate_of_Request: "2022-11-30",
                    txtParent_Project: "E3445-U2252",
                    ccLeading_SD: "haochen.wu@crownbio.com",
                    hfRequest_id: "-1",//add new is "-1"
                    txtDate_of_1st_responding: "",
                    editRemark: ""
                }),
                success: function (jsonResult) {
                    console.log(jsonResult.code);
                    console.log(jsonResult.msg);
                }
            });
        }

        function importAnimalInfo() {
            var file = document.getElementById('FileUpload').files;
            if (file.length > 0) {
                var formData = new FormData();
                formData.append("FileUpload", file[0]);

                var test = $.ajax({
                    type: "POST",
                    dataType: "json",
                    url: "https://hudata.crownbio.com/actionapi/Hudata/importAnimalInfo",
                    data: formData,
                    contentType: false,
                    processData: false,
                    success: function (jsonResult) {
                        console.log(jsonResult.code);
                        console.log(jsonResult.msg);
                    }
                });
            }
        }


        function AddUser() {
            var test = $.ajax({
                type: "POST",
                contentType: "application/json",
                dataType: "json",
                url: "https://ucapi.crownbio.com/api/UserCenter/ApproveUser",
                data: JSON.stringify({
                    Email: "runjun.jia@crownbio.com",
                    Password: "Crown01",
                    Firstname: "Jun",
                    Lastname: "Li",
                    Institution: "xx",
                    Country: "China",
                    State: "xx",
                    City: "taicang",
                    Origin: "HuBase"
                }),
                success: function (jsonResult) {
                    console.log(jsonResult.code);
                    console.log(jsonResult.result);
                }
            });
        }

        function getAnimalBooking() {
            var test = $.ajax({
                type: "GET",
                dataType: "json",
                //url: "https://hudata.crownbio.com/actionapi/Hudata/getAnimalBooking",
                url: "http://localhost:29680/actionapi/Hudata/getAnimalBooking",
                data: { model_ID: "BR9465" },
                success: function (jsonResult) {
                    console.log(jsonResult.code);
                    console.log(jsonResult.msg);
                }
            });
        }
        function saveAnimalBooking() {
            var test = $.ajax({
                type: "POST",
                dataType: "json",
                url: "https://hudata.crownbio.com/actionapi/Hudata/saveAnimalBooking",
                data: {
                    Animal_Booking: "E5635-U2304-TC",
                    Further_Expanding: "",
                    Revive: "",
                    Animal_Number: "16664",
                    Project_Number: "E5635-U2304-TC",
                    Book_MODEL_ID: "CR3262",
                },
                success: function (jsonResult) {
                    console.log(jsonResult.code);
                    console.log(jsonResult.msg);
                }
            });
        }
        function getDropdownlist() {
            var test = $.ajax({
                type: "GET",
                dataType: "json",
                url: "https://hudata.crownbio.com/actionapi/Hudata/getDropdownlist",
                success: function (jsonResult) {
                    console.log(jsonResult.code);
                    console.log(jsonResult.msg);
                }
            });
        }
    </script>
</head>
<body>
    <div>
        <button type="button" id="btn1" onclick="addRequest();">add request</button>
        <input id="FileUpload" name="FileUpload" type="file" />
        <button type="button" id="btn2" onclick="importAnimalInfo();">import animaiInfo</button>
        <button type="button" id="btn_ApproveUser" onclick="AddUser();">addUser</button>
    </div>
    <div>
        <button type="button" id="btn_getBooking" onclick="getAnimalBooking();">getAnimalBooking</button>
        <button type="button" id="btn_getDropdownlist" onclick="getDropdownlist();">getDropdownlist</button>
        <button type="button" onclick="saveAnimalBooking();">saveAnimalBooking</button>
    </div>
</body>
</html>
