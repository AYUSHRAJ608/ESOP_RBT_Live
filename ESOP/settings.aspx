<%@ Page Title="" Language="C#" MasterPageFile="~/ESOP.Master" AutoEventWireup="true" CodeBehind="settings.aspx.cs" Inherits="ESOP.settings" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>


<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ScriptManager ID="script" runat="server"></asp:ScriptManager>
    <title>ESOP-Settings</title>
    <style>
        .main-content {
            padding-top: 38px;
        }

        .main-footer {
            margin-top: 7px;
        }

        .card {
            height: 100%;
        }

        .mt-5, .my-5 {
            margin-top: 3.6rem !important;
        }

        h3 {
            font-weight: 600;
        }

        .card.card-sales-widget {
            background: linear-gradient(90deg, rgb(23 153 183) 0%, rgb(33 162 191 / 89%) 35%, rgb(35 191 227 / 51%) 100%);
        }

            .card.card-sales-widget .card-header .card-text-blue {
                color: white !important;
                text-shadow: 2px 2px 3px #020c0e !important;
            }

        .bg-blue {
            background-color: #f2f2f2 !important;
            color: #fff;
        }

        .card.card-sales-widget .card-header {
            margin-top: 11%;
        }

        .card .card-header {
            background-color: transparent;
            padding: 15px 10px !important;
        }

        .card.card-sales-widget:hover {
            background: #1d99c7b8;
        }

        h3.font-light.mb-0 {
            font-size: 22px;
            color: white;
            text-shadow: 2px 2px 2px #053a46;
        }

        .mr-4, .mx-4 {
            margin-right: 5.5rem !important;
        }

        .bg-info {
            background-color: #615a72 !important;
            width: 30px;
            height: 30px;
            position: absolute !important;
            top: -13px;
        }

        .card.card-statistic-1, .card.card-statistic-2 {
            display: inline-block;
            width: 100%;
            background: linear-gradient(90deg, rgb(23 153 183) 0%, rgb(33 162 191 / 89%) 35%, rgb(35 191 227 / 51%) 100%);
        }

            .card.card-statistic-1 .card-icon-bg-green .fas {
                color: white;
            }

            .card.card-statistic-1 .card-icon-bg-green {
                border: 2px solid #116173;
            }

        .card.card-statistic-1 {
            border-left: 4px solid #116173;
        }

        a:not(.btn-social-icon):not(.btn-social):not(.page-link) .fas {
            margin-left: 1px;
        }

        .card.card-statistic-1 .card-icon-square .fas {
            font-size: 22px;
        }

        .card.card-statistic-1:hover {
            background: #32a6c1;
        }

        span.notification-count.bg-info {
            color: white;
            padding: 1px 10px;
            font-size: 11px !important;
            padding-top: 7px;
            font-weight: 600;
        }

        .card.profile-widget {
            width: 100% !important;
        }

        .card {
            height: 100%;
        }

        .profile-widget .profile-widget-picture {
            box-shadow: 0 4px 25px 0 rgba(0, 0, 0, .1);
            width: 99px;
            margin-top: -44px;
            display: block;
            z-index: 1;
            padding: 9px !important;
        }

        .card.profile-widget {
            background: #25bddf12;
        }

        .profile-widget .profile-widget-description .profile-widget-name {
            font-size: 17px;
            margin-bottom: 46px;
            font-weight: 600;
            text-align: center;
            color: #34395e;
            padding: 5px;
            background: #279db81c;
            margin-top: -64px;
        }

        span.notification-count.bg-info {
            right: 10px;
            top: 44px;
        }

        .profile-widget-name:hover {
            border: 1px solid #279db8b3;
        }

        a {
            color: #2f9b96;
            text-decoration: none !important;
        }

        /*.feature-rounded {
            width: 90px;
            height: 90px;
            border-radius: 50%;
            overflow: hidden;
            padding: 18px 0;
            background: #2673FF;
            position: relative;
            top: -60%;
            left: 50%;
            transform: translateX(-50%);
            /* text-align: center; 
            border: 1px solid #0d4dc1;
        }*/

        .feature-rounded img {
            width: 40px;
            margin: 0 auto;
            display: block;
        }

        .profile-widget .profile-widget-description {
            padding: 20px;
            line-height: 26px;
            z-index: 1000 !important;
            max-height: 62px;
        }

        .offset-md-9 {
            margin-left: 86%;
        }
    </style>
    <div class="loader"></div>
    <div id="app">
        <div class="main-wrapper main-wrapper-1">
            <div class="navbar-bg"></div>

            <!-- Main Content -->
            <div class="main-content">
                <nav aria-label="breadcrumb">
                    <ol class="breadcrumb">
                        <li class="breadcrumb-item"><a href="admin-dashboard">Home</a></li>
                        <%--style="margin-left: -23px;"--%>
                        <li class="breadcrumb-item active" aria-current="page">Masters</li>
                        <%--style="margin-top: -15px; margin-left: 23px;"--%>
                    </ol>
                </nav>
                <section class="section">
                    <div class="row">
                        <div class="col-lg-12 col-md-12 col-12 col-sm-12">
                            <div class="card">
                                <div class="card-header">
                                    <h4>Masters</h4>
                                </div>
                                <div class="container card-body">
                                    <div class="row" style="margin-top: 55px;">
                                        <div class="col-2">
                                            <div class="card profile-widget" style="height: 55%;">
                                                <div class="profile-widget-header">
                                                    <div class="row">
                                                        <div class="col-12">
                                                            <div class="feature-rounded">
                                                                <img alt="image" src="assets/img/createFmv.png" class="">
                                                            </div>
                                                        </div>
                                                    </div>
                                                </div>
                                                <div class="profile-widget-description pb-0">
                                                    <a href="FMVCreation_Master.aspx">
                                                        <div class="profile-widget-name">
                                                            <span class="notification-count bg-info" style="color: white; padding: 4px 7px; font-size: 16px; padding-top: 7px;" id="fmvcount" runat="server"></span>
                                                            FMV <br />
                                                            Creation
                                                        </div>
                                                    </a>
                                                </div>
                                            </div>
                                        </div>
                                        <div class="col-2">
                                            <div class="card profile-widget" style="height: 55%;">
                                                <div class="profile-widget-header">
                                                    <div class="row">
                                                        <div class="col-12">
                                                            <div class="feature-rounded">
                                                                <img alt="image" src="assets/img/calendar.png" class="" />
                                                            </div>
                                                        </div>
                                                    </div>
                                                </div>
                                                <div class="profile-widget-description pb-0">
                                                    <a href="vesting-creation.aspx">
                                                        <div class="profile-widget-name">
                                                            <span class="notification-count bg-info" style="color: white; padding: 4px 7px; font-size: 16px; padding-top: 7px;" id="vestingcount" runat="server"></span>
                                                            Vesting <br />Creation
                                                        </div>
                                                    </a>
                                                </div>
                                            </div>
                                        </div>
                                        <div class="col-2">
                                            <div class="card profile-widget" style="height: 55%;">
                                                <div class="profile-widget-header">
                                                    <div class="row">
                                                        <div class="col-12">
                                                            <div class="feature-rounded">
                                                                <img alt="image" src="assets/img/refresh (2).png" class="">
                                                            </div>
                                                        </div>
                                                    </div>
                                                </div>
                                                <div class="profile-widget-description pb-0">
                                                    <a href="Valuation_Master.aspx">
                                                        <div class="profile-widget-name">
                                                            <span class="notification-count bg-info" style="color: white; padding: 4px 7px; font-size: 16px; padding-top: 7px;" id="valuationcount" runat="server"></span>
                                                            Valuation
                                                        </div>
                                                    </a>
                                                </div>
                                            </div>
                                        </div>
                                        <div class="col-2">
                                            <div class="card profile-widget" style="height: 55%;">
                                                <div class="profile-widget-header">
                                                    <div class="row">
                                                        <div class="col-12">
                                                            <div class="feature-rounded">
                                                                <img alt="image" src="assets/img/email1.png">
                                                            </div>
                                                        </div>
                                                    </div>
                                                </div>
                                                <div class="profile-widget-description pb-0">
                                                    <a href="LetterConfiguration.aspx">
                                                        <div class="profile-widget-name">
                                                            <span class="notification-count bg-info" style="color: white; padding: 4px 7px; font-size: 16px; padding-top: 7px;" id="lettercount" runat="server"></span>
                                                            Letter Configuration
                                                        </div>
                                                    </a>
                                                </div>
                                            </div>
                                        </div>
                                        <div class="col-2">
                                            <div class="card profile-widget" style="height: 55%;">
                                                <div class="profile-widget-header">
                                                    <div class="row">
                                                        <div class="col-12">
                                                            <div class="feature-rounded">
                                                                <img alt="image" src="assets/img/email1.png">
                                                            </div>
                                                        </div>
                                                    </div>
                                                </div>
                                                <div class="profile-widget-description pb-0">
                                                    <a href="Email_Type.aspx">
                                                        <div class="profile-widget-name">E-mail Configuration</div>
                                                    </a>
                                                </div>
                                            </div>
                                        </div>
                                        <div class="col-2">
                                            <div class="card profile-widget" style="height: 55%;">
                                                <div class="profile-widget-header">
                                                    <div class="row">
                                                        <div class="col-12">
                                                            <div class="feature-rounded">
                                                                <img alt="image" src="assets/img/tax-saving.png">
                                                            </div>
                                                        </div>
                                                    </div>
                                                </div>
                                                <div class="profile-widget-description pb-0">
                                                    <a href="Financial_Year.aspx">
                                                        <div class="profile-widget-name">
                                                            Financial<br />
                                                            Year
                                                        </div>
                                                    </a>
                                                </div>
                                            </div>
                                        </div>
                                        <div class="col-2">
                                            <div class="card profile-widget" style="height: 55%;">
                                                <div class="profile-widget-header">
                                                    <div class="row">
                                                        <div class="col-12">
                                                            <div class="feature-rounded">
                                                                <img alt="image" src="assets/img/tax-saving.png">
                                                            </div>
                                                        </div>
                                                    </div>
                                                </div>
                                                <div class="profile-widget-description pb-0">
                                                    <%--<a href="Tax_Master.aspx">--%>
                                                    <%--Added by Krutika on 03-01-23--%>
                                                    <a href="Tax_Master_New.aspx">              
                                                        <div class="profile-widget-name">
                                                            <span class="notification-count bg-info" style="color: white; padding: 4px 7px; font-size: 16px; padding-top: 7px;" id="taxcount" runat="server"></span>
                                                            Tax<br />
                                                            Master
                                                        </div>
                                                    </a>
                                                </div>
                                            </div>
                                        </div>
                                        <div class="col-2">
                                            <div class="card profile-widget" style="height: 55%;">
                                                <div class="profile-widget-header">
                                                    <div class="row">
                                                        <div class="col-12">
                                                            <div class="feature-rounded">
                                                                <img alt="image" src="assets/img/synchronize-icon.png">
                                                            </div>
                                                        </div>
                                                    </div>
                                                </div>
                                                <div class="profile-widget-description pb-0">
                                                    <a href="hrmsintegration.aspx">
                                                        <div class="profile-widget-name">
                                                            HRMS Integration
                                                        </div>
                                                    </a>
                                                </div>
                                            </div>
                                        </div>
                                        <div class="col-2">
                                            <div class="card profile-widget" style="height: 55%;">
                                                <div class="profile-widget-header">
                                                    <div class="row">
                                                        <div class="col-12">
                                                            <div class="feature-rounded">
                                                                <img alt="image" src="assets/img/key.png">
                                                            </div>
                                                        </div>
                                                    </div>
                                                </div>
                                                <div class="profile-widget-description pb-0">
                                                    <a href="PDFPassword.aspx">
                                                        <div class="profile-widget-name">
                                                            PDF Password
                                                        </div>
                                                    </a>
                                                </div>
                                            </div>
                                        </div>
                                        <%--<div class="col">
                                            <div class="card profile-widget" style="height: 55%;">
                                                <div class="profile-widget-header">
                                                    <div class="row">
                                                        <div class="col-12">
                                                            <div class="feature-rounded">
                                                                <img alt="image" src="assets/img/id.png">
                                                            </div>
                                                        </div>
                                                    </div>
                                                </div>
                                                <div class="profile-widget-description pb-0" style="padding: 20px 5px 25px 5px;">
                                                    <a href="Employee_Password_Master.aspx">
                                                        <div class="profile-widget-name">
                                                            ID Proof Master
                                                        </div>
                                                    </a>
                                                </div>
                                            </div>
                                        </div>--%>
                                        <%--<div class="col">
                                            <div class="card profile-widget" style="height: 55%;">
                                                <div class="profile-widget-header">
                                                    <div class="row">
                                                        <div class="col-12">
                                                            <div class="feature-rounded">
                                                                <img alt="image" src="assets/img/cloud-computing.png">
                                                            </div>
                                                        </div>
                                                    </div>
                                                </div>
                                                <div class="profile-widget-description pb-0">
                                                    <a href="Add_Existing_Data.aspx">
                                                        <div class="profile-widget-name">
                                                            Bulk Upload
                                                        </div>
                                                    </a>
                                                </div>
                                            </div>
                                        </div>--%>
                                        <div class="col-2">
                                            <div class="card profile-widget" style="height: 55%;">
                                                <div class="profile-widget-header">
                                                    <div class="row">
                                                        <div class="col-12">
                                                            <div class="feature-rounded">
                                                                <img alt="image" src="assets/img/add-friend.png">
                                                            </div>
                                                        </div>
                                                    </div>
                                                </div>
                                                <div class="profile-widget-description pb-0" style="padding: 20px 5px 25px 5px;">
                                                    <a href="AddEmployee.aspx">
                                                        <div class="profile-widget-name">
                                                            Add User to ESOP
                                                        </div>
                                                    </a>
                                                </div>
                                            </div>
                                        </div>
                                        <%--<div class="col">
                                            <div class="card profile-widget" style="height: 55%;">
                                                <div class="profile-widget-header">
                                                    <div class="row">
                                                        <div class="col-12">
                                                            <div class="feature-rounded">
                                                                <img alt="image" src="assets/img/synchronize-icon.png">
                                                            </div>
                                                        </div>
                                                    </div>
                                                </div>
                                                <div class="profile-widget-description pb-0">
                                                    <a href="UserLog.aspx">
                                                        <div class="profile-widget-name">
                                                            User Log
                                                        </div>
                                                    </a>
                                                </div>
                                            </div>
                                        </div>--%>
                                        
                                        <div class="col-2">
                                            <div class="card profile-widget" style="height: 55%;">
                                                <div class="profile-widget-header">
                                                    <div class="row">
                                                        <div class="col-12">
                                                            <div class="feature-rounded">
                                                                <img alt="image" src="assets/img/error_new.png">
                                                            </div>
                                                        </div>
                                                    </div>
                                                </div>
                                                <div class="profile-widget-description pb-0" style="padding: 20px 5px 25px 5px;">
                                                    <a href="Lapse_Master.aspx">
                                                        <div class="profile-widget-name">
                                                            Lapse Master
                                                        </div>
                                                    </a>
                                                </div>
                                            </div>
                                        </div>
                                        <div class="col-2">
                                            <div class="card profile-widget" style="height: 55%;">
                                                <div class="profile-widget-header">
                                                    <div class="row">
                                                        <div class="col-12">
                                                            <div class="feature-rounded">
                                                                <img alt="image" src="assets/img/error_new.png">
                                                            </div>
                                                        </div>
                                                    </div>
                                                </div>
                                                <div class="profile-widget-description pb-0" style="padding: 20px 5px 25px 5px;">
                                                    <a href="LapseList.aspx">
                                                        <div class="profile-widget-name">
                                                            Lapse
                                                        </div>
                                                    </a>
                                                </div>
                                            </div>
                                        </div>
                                        <div class="col-2">
                                            <div class="card profile-widget" style="height: 55%;">
                                                <div class="profile-widget-header">
                                                    <div class="row">
                                                        <div class="col-12">
                                                            <div class="feature-rounded">
                                                                <img alt="image" src="assets/img/error_new.png">
                                                            </div>
                                                        </div>
                                                    </div>
                                                </div>
                                                <div class="profile-widget-description pb-0" style="padding: 20px 5px 25px 5px;">
                                                    <a href="Admin_Workflow_Pending.aspx">
                                                        <div class="profile-widget-name">
                                                            Pending Workflow
                                                        </div>
                                                    </a>
                                                </div>
                                            </div>
                                        </div>
                                        <%-- Added by Bhushan on 17-12-2021 for PAN Card Upload --%>
                                        <div class="col-2">
                                            <div class="card profile-widget" style="height: 55%;">
                                                <div class="profile-widget-header">
                                                    <div class="row">
                                                        <div class="col-12">
                                                            <div class="feature-rounded">
                                                                <img alt="image" src="assets/img/error_new.png">
                                                            </div>
                                                        </div>
                                                    </div>
                                                </div>
                                                <div class="profile-widget-description pb-0" style="padding: 20px 5px 25px 5px;">
                                                    <a href="PANCardUpload.aspx">
                                                        <div class="profile-widget-name">
                                                            PAN Card Number<br/>
                                                            Upload
                                                        </div>
                                                    </a>
                                                </div>
                                            </div>
                                        </div>
                                        <%-- End --%>
                                        <div class="col-2">
                                            <div class="card profile-widget" style="height: 55%;">
                                                <div class="profile-widget-header">
                                                    <div class="row">
                                                        <div class="col-12">
                                                            <div class="feature-rounded">
                                                                <img alt="image" src="assets/img/error_new.png">
                                                            </div>
                                                        </div>
                                                    </div>
                                                </div>
                                                <div class="profile-widget-description pb-0" style="padding: 20px 5px 25px 5px;">
                                                    <a href="ErrorPage.aspx">
                                                        <div class="profile-widget-name">
                                                            Error<br />
                                                            List
                                                        </div>
                                                    </a>
                                                </div>
                                            </div>
                                        </div>
                                        <div class="col-2">
                                            <div class="card profile-widget" style="height: 55%;">
                                                <div class="profile-widget-header">
                                                    <div class="row">
                                                        <div class="col-12">
                                                            <div class="feature-rounded">
                                                                <img alt="image" src="assets/img/error_new.png">
                                                            </div>
                                                        </div>
                                                    </div>
                                                </div>
                                                <div class="profile-widget-description pb-0" style="padding: 20px 5px 25px 5px;">
                                                    <a href="Add_Existing_Data_New.aspx">
                                                        <div class="profile-widget-name">
                                                            Historic Data<br />
                                                            Upload
                                                        </div>
                                                    </a>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </section>
            </div>
        </div>
    </div>

    <!-- General JS Scripts -->
    <script src="assets/js/app.min.js"></script>

    <script src="assets/js/page/index.js"></script>
    <!-- Template JS File -->
    <script src="assets/js/scripts.js"></script>
    <script src="assets/bundles/jquery.sparkline.min.js"></script>


    <script type="text/javascript" src="assets/js/jquery-simple-tree-table.js"></script>
    <link type="text/css" href="assets/css/jquery-simple-tree-table.css" rel="stylesheet" />
    <script>
        $('table tr.clickable').on('click', function () {
            if ($(this).children('td:first-child').children('i').hasClass('fa-plus')) {
                $(this).children('td:first-child').children('i').removeClass('fa-plus').addClass('fa-minus');
            } else {
                $(this).children('td:first-child').children('i').removeClass('fa-minus').addClass('fa-plus');
            }
        })
        $("#click-me").click(function () {
            $(".table .toggleDisplay").toggleClass("in");
        });

        $('#basic').simpleTreeTable({
            collapsed: true,

            expander: $('#expander'),
            collapser: $('#collapser')
        });

        $(document).ready(function () {
            $('#collapser').click();
            $('.simple-tree-table tr th:nth-child(4), .simple-tree-table tr th:nth-child(6), .simple-tree-table tr th:nth-child(8), .simple-tree-table tr th:nth-child(9), .simple-tree-table tr td:nth-child(4), .simple-tree-table tr td:nth-child(6), .simple-tree-table tr td:nth-child(8), .simple-tree-table tr td:nth-child(9)').addClass('toggleDisplay')
        })
    </script>
</asp:Content>
