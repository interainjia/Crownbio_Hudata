<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="index.aspx.cs" Inherits="PDXmodelBase.HuData.index" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <meta charset="utf-8" />
    <meta http-equiv="X-UA-Compatible" content="IE=edge" />
    <meta name="viewport" content="width=device-width, initial-scale=1" />
    <!-- 上述3个meta标签*必须*放在最前面，任何其他内容都*必须*跟随其后！ -->
    <meta name="description" content="" />
    <meta name="author" content="" />
    <link rel="shortcut icon" href="../images/minlogo.png" />
    <title>Crownbio HuData</title>
    <!-- Bootstrap core CSS -->
    <link href="../Common/bootstrap-3.3.5-dist/css/bootstrap.min.css" rel="stylesheet" />
    <link href="../Common/bootstrap-3.3.5-dist/css/bootstrap_header.css" rel="stylesheet" />
    <link rel="stylesheet" type="text/css" href="../Common/easyui-1.3.2/themes/bootstrap/easyui.css" />
    <link rel="stylesheet" type="text/css" href="../site_media/HuData/css/crownbio.css" />
    <!-- HTML5 shim and Respond.js for IE8 support of HTML5 elements and media queries -->
    <!--[if lt IE 9]>
      <script src="//cdn.bootcss.com/html5shiv/3.7.2/html5shiv.min.js"></script>
      <script src="//cdn.bootcss.com/respond.js/1.4.2/respond.min.js"></script>
    <![endif]-->
</head>
<body style="padding-top: 50px;">
    <%-- <div id="north" region="north" border="false" runat="server">--%>
    <!-- Fixed navbar -->
    <nav class="navbar navbar-default navbar-fixed-top">
        <div class="container">
            <div class="navbar-header">
                <button type="button" class="navbar-toggle collapsed" data-toggle="collapse" data-target="#navbar" aria-expanded="false" aria-controls="navbar">
                    <span class="sr-only">Toggle navigation</span>
                    <span class="icon-bar"></span>
                    <span class="icon-bar"></span>
                    <span class="icon-bar"></span>
                </button>
                <div style="font-size: 30px">
                    <img src="../images/CROWN BIOSCIENCE - Final Corporate Logo - RGB.svg" class="crown-logo" style="height: 50px;" alt="" />
                    <span style="color: #056A7B;font-weight:600;">HuData<sup>®</sup></span>
                </div>
            </div>
            <div id="navbar" class="navbar-collapse collapse">
                <ul id="Nav_actve" class="nav navbar-nav">
                    <li class="dropdown">
                        <a href="javascript:void();" class="dropdown-toggle" data-toggle="dropdown" role="button" aria-haspopup="true" aria-expanded="false">PDX Model<span class="caret"></span></a>
                        <ul class="dropdown-menu">
                            <li><a href="javascript:void(0);" onclick="addTab('PDX Model','PDXmodelInfo.aspx')"><span>PDX Model Info</span></a></li>
                            <li><a href="javascript:void(0);" onclick="addTab('MuPrime Model','MuPrime.aspx')"><span>MuPrime Model Info</span></a></li>
                            <li><a href="javascript:void(0);" onclick="addTab('Animal Info', 'AnimalInfo.aspx')"><span>Animal Info</span></a></li>
                            <li><a href="javascript:void(0);" onclick="addTab('Model Tree', 'AnimalTree.aspx')"><span>Model Tree</span></a></li>
                            <%-- <li role="separator" class="divider"></li>--%>
                        </ul>
                    </li>

                    <li><a onfocus="this.blur();" href="javascript:void(0);" onclick="addTab('New Request', 'Request2.aspx')">New Request</a> </li>
                    <li class="dropdown">
                        <a href="javascript:void();" class="dropdown-toggle" data-toggle="dropdown" role="button" aria-haspopup="true" aria-expanded="false">Project Monitor <span class="caret"></span></a>
                        <ul class="dropdown-menu">
                            <li><a href="javascript:void(0);" onclick="addTab('Project Monitor', 'ProjectMonitor.aspx')"><span>Project Monitor</span></a></li>
                            <li><a href="javascript:void(0);" onclick="addTab('Workload', 'Workload.aspx')"><span>Workload</span></a></li>
                            <li><a href="javascript:void(0);" onclick="addTab('Completed Project', 'CompletedProject.aspx')"><span>Completed Project</span></a></li>
                            <li><a href="javascript:void(0);" onclick="addTab('Project Consulting', 'ProjectConsulting.aspx')"><span>Project Consulting</span></a></li>
                        </ul>
                    </li>
                    <li><a onfocus="this.blur();" href="javascript:void(0);" class="parent" onclick="addTab('ProjectBooking', 'ProjectBooking.aspx')">Project Booking</a> </li>
                    <li class="dropdown">
                        <a href="javascript:void();" class="dropdown-toggle" data-toggle="dropdown" role="button" aria-haspopup="true" aria-expanded="false">Tissue Bank<span class="caret"></span></a>
                        <ul class="dropdown-menu">

                            <li><a href="javascript:void(0);" onclick="addTab('Specimen Stocks','SpecimenStocks.aspx')"><span>Specimen Stocks</span></a></li>
                            <li><a href="javascript:void(0);" onclick="addTab('Storage Maps','StorageMaps.aspx')"><span>Storage Maps</span></a></li>
                            <li><a href="javascript:void(0);" onclick="addTab('Tissue Withdraw','TissueWithdraw.aspx')"><span>Tissue Withdraw</span></a></li>
                        </ul>
                    </li>
                    <li class="dropdown">
                        <a href="javascript:void();" class="dropdown-toggle" data-toggle="dropdown" role="button" aria-haspopup="true" aria-expanded="false">Model Manage<span class="caret"></span></a>
                        <ul class="dropdown-menu">
                            <li><a href="javascript:void(0);" onclick="addTab('New Model','NewModel.aspx')"><span>New Model</span></a></li>
                            <li><a href="javascript:void(0);" onclick="addTab('Validation','Validation.aspx')"><span>Validation</span></a></li>
                            <li><a href="javascript:void(0);" onclick="addTab('Routine Maintain','RoutineMaintain.aspx')"><span>Routine Maintain</span></a></li>
                            <li><a href="javascript:void(0);" onclick="addTab('End Models','EndModels.aspx')"><span>End Models</span></a></li>
                            <li class="dropdown-submenu">
                                <a href="javascript:;">Model Validation Status<span class="arrow"></span></a>
                                <ul class="dropdown-menu">
                                    <li><a href="javascript:void(0);" onclick="addTab('Validation Status1','ValidationStatus_Huprime.aspx')"><span>Huprime&Muprime</span></a></li>
                                    <li><a href="javascript:void(0);" onclick="addTab('Validation Status2','ValidationStatus_Hukime.aspx')"><span>Hukime</span></a></li>
                                </ul>
                            </li>
                            <li><a href="javascript:void(0);" onclick="addTab('Revival','Revival.aspx')"><span>Revival</span></a></li>
                            <li><a href="javascript:void(0);" onclick="addTab('GeneticTest','GeneticTest.aspx')"><span>GeneticTest</span></a></li>
                        </ul>
                    </li>


                </ul>
                <ul class="nav navbar-nav navbar-right">
                    <li class="dropdown">
                        <a href="javascript:void();" class="dropdown-toggle" data-toggle="dropdown" role="button" aria-haspopup="true" aria-expanded="false">User<span class="caret"></span></a>
                        <ul class="dropdown-menu">
                            <% =IsUsers%>
                            <li><a id="ChangeUser" href="javascript:void(0);" onclick="addTab('User Information','ChangeUsers.aspx')">
                                <% =ChangeUser%></a></li>
                            <li><a href="javascript:void(0);" onclick="Logout_Click()">Logout</a></li>
                        </ul>
                    </li>
                </ul>
            </div>
            <!--/.nav-collapse -->
        </div>
    </nav>
    <!-- Bootstrap core JavaScript
    ================================================== -->
    <!-- Placed at the end of the document so the pages load faster -->
    <script type="text/javascript" src="../Common/bootstrap-3.3.5-dist/js/jquery.min.js"></script>
    <script type="text/javascript" src="../Common/bootstrap-3.3.5-dist/js/bootstrap.min.js"></script>
    <!-- IE10 viewport hack for Surface/desktop Windows 8 bug -->
    <%--    <script type="text/javascript" src="../../assets/js/ie10-viewport-bug-workaround.js"></script>--%>
    <script type="text/javascript" src="../Common/easyui-1.3.2/jquery-1.8.0.min.js"></script>
    <script type="text/javascript" src="../Common/easyui-1.2.5/jquery.wresize.js"></script>

    <script type="text/javascript" src="../Common/easyui-1.3.2/jquery.easyui.min.js"></script>
    <script type="text/javascript" src="../Common/Base.js"></script>

    <%--<div class="head_bg">
            <div class="head_logo">
            </div>
            <div class="head_right">
               <div class="head_btn4" align="center">
                <a id="Users" href="javascript:void(0);" onclick="addTab('System Management','SysManagement.aspx')">
                    <span style="color: White">
                        <% =IsUsers%></span></a> <a id="ChangeUser" href="javascript:void(0);" onclick="addTab('User Information','ChangeUsers.aspx')">
                            <span style="color: White">
                                <% =ChangeUser%></span></a>
               </div>
                <div class="head_btn5" align="center">
                    <a id="Button1" href="javascript:void(0);" onclick="Logout_Click()"></a><span class="btn5_span">
                        Logout</span></div>
            </div>
               </div>
     </div>--%>
    <%--<div id="diymenu" style="position: absolute; z-index: 20; margin-top: 5px; margin-left: 160px">
        <ul class="diymenu">
            <li><a href="javascript:void(0);" class="parent" >
                <span>PDX Model</span></a> 
                <div>
                                <ul>
                                    <li><a href="javascript:void(0);" onclick="addTab('PDX Model','PDXmodelInfo.aspx')"><span>PDX Model Info</span></a></li>
                                    <li><a href="javascript:void(0);" onclick="addTab('Animal Info', 'AnimalInfo.aspx')"><span>Animal Info</span></a></li>
                                     <li><a href="javascript:void(0);" onclick="addTab('Model Tree', 'AnimalTree.aspx')"><span>Model Tree</span></a></li>
                                       <%--<li><a href="javascript:void(0);" onclick="addTab('Case Report', 'CaseReport.aspx')"><span>Case Report</span></a></li>
                                </ul>
                            </div>
                </li>

        <li><a href="javascript:void(0);" class="parent" onclick="addTab('New Request', 'Request2.aspx')">
                <span>New Request</span></a> </li>
                  <li><a href="javascript:void(0);" class="parent">
                <span>Project Monitor</span></a> 
                <div>
                    <ul>
                        <li><a href="javascript:void(0);" onclick="addTab('Project Monitor', 'ProjectMonitor.aspx')"><span>Project Monitor</span></a></li>
                          <li><a href="javascript:void(0);" onclick="addTab('Workload', 'Workload.aspx')"><span>Workload</span></a></li>
                            <li><a href="javascript:void(0);" onclick="addTab('Completed Project', 'CompletedProject.aspx')"><span>Completed Project</span></a></li>
                    </ul>
                </div></li>
                   <li><a href="javascript:void(0);" class="parent" onclick="addTab('ProjectBooking', 'ProjectBooking.aspx')">
                <span>Project Booking</span></a> </li>
            <li><a href="javascript:void(0);" class="parent"><span>Tissue Bank</span></a>
                <div>
                    <ul>
                        <li><a href="javascript:void(0);" onclick="addTab('Specimen Stocks','SpecimenStocks.aspx')"><span>
                            Specimen Stocks</span></a></li>
                       <li><a href="javascript:void(0);" onclick="addTab('Storage Maps','StorageMaps.aspx')"><span>
                            Storage Maps</span></a></li>
                             <li><a href="javascript:void(0);" onclick="addTab('Tissue Withdraw','TissueWithdraw.aspx')"><span>
                            Tissue Withdraw</span></a></li>
                    </ul>
                </div>
            </li>
              <li><a href="javascript:void(0);" class="parent"><span>PDX Model Manage</span></a>
                <div>
                    <ul>
                        <li><a href="javascript:void(0);" onclick="addTab('New Model','NewModel.aspx')"><span>
                            New Model</span></a></li>
                       <li><a href="javascript:void(0);" onclick="addTab('Validation','Validation.aspx')"><span>
                            Validation</span></a></li>
                             <li><a href="javascript:void(0);" onclick="addTab('Routine Maintain','RoutineMaintain.aspx')"><span>
                            Routine Maintain</span></a></li>
                    </ul>
                </div>
            </li>
        </ul>
    </div>--%>

    <div class="easyui-tabs" fit="true" border="false" id="tt">
    </div>
    <div id="mm" class="easyui-menu" style="width: 150px; display: none;">
        <div id="mm-tabclose">
            tab close
        </div>
        <div id="mm-tabcloseall">
            tab close all
        </div>
        <div id="mm-tabcloseother">
            tab close other
        </div>
        <div class="menu-sep">
        </div>
        <div id="mm-tabcloseright">
            tab close right
        </div>
        <div id="mm-tabcloseleft">
            tab close left
        </div>
    </div>
</body>
</html>
