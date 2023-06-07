<%@ Page Title="" Language="C#" MasterPageFile="~/ESOP.Master" AutoEventWireup="true" CodeBehind="President_report.aspx.cs" Inherits="ESOP.President_report" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <asp:ScriptManager ID="script" runat="server"></asp:ScriptManager>

    <meta charset="UTF-8">
    <meta content="width=device-width, initial-scale=1, maximum-scale=1, shrink-to-fit=no" name="viewport">
    <title>ESOP - Admin Dashboard</title>
    <!-- General CSS Files -->
    <link rel="stylesheet" href="assets/css/app.min.css">
    <!-- Template CSS -->
    <link rel="stylesheet" href="assets/css/style.css">
    <link rel="stylesheet" href="assets/css/components.css">
    <link rel="stylesheet" href="assets/bundles/bootstrap-social/bootstrap-social.css">
    <link rel="stylesheet" href="assets/bundles/flag-icon-css/css/flag-icon.min.css">
    <link rel="stylesheet" href="assets/css/custom.css">
    <!-- Custom style CSS -->
    <link rel='shortcut icon' type='image/x-icon' href='assets/img/favicon.ico' />
    <style>
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
            margin-top: -2.4rem !important;
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
            height: 450px;
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
            border: 1px solid #96a2b48f;
        }

        a {
            color: #2f9b96;
            text-decoration: none !important;
        }

        /*.feature-rounded {
            width: 100px;
            height: 100px;
            border-radius: 50%;
            overflow: hidden;
            padding: 18px 0;
            background: #2673FF;
            position: relative;
            top: -60%;
            left: 50%;
            transform: translateX(-50%);
            /* text-align: center;
            border: 1px solid #2673FF;
        }*/

            .feature-rounded img {
                width: 55px;
                margin: 0 auto;
                display: block;
            }

        .profile-widget .profile-widget-description {
            padding: 20px;
            line-height: 26px;
            z-index: 1000 !important;
        }

        .section > :first-child {
            margin-top: 20px;
        }

        .offset-md-10 {
            margin-left:  87.333333%;
        }

        .offset-md-9 {
            margin-left: 87%;
        }
    </style>


    <!-- Main Content -->
    <div class="main-content">
        <nav aria-label="breadcrumb">
            <ol class="breadcrumb">
                <li class="breadcrumb-item"><a href="President-dashboard.aspx">Home</a></li>
                <li class="breadcrumb-item active" aria-current="page">Reports</li>
            </ol>
        </nav>
        <section class="section">
            <div class="row">
                <div class="col-lg-12 col-md-12 col-12 col-sm-12">
                    <div class="card">
                        <div class="card-header">
                            <h4>Report Details</h4>
                        </div>
                        <div class="card-body mr-4">
                            <div class="row" style="margin-top: 55px;margin-left: 306px;">
                                <div class="col-12 col-sm-12 col-lg-4">
                                    <div class="card profile-widget" style="height: 65%;">
                                        <div class="profile-widget-header">
                                            <div class="row">
                                                <div class="col-12">
                                                    <div class="feature-rounded">
                                                        <img alt="image" src="assets/img/document.png" class="" style="background: #2600ff  !important;">
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                        <div class="profile-widget-description pb-0">
                                            <a href="PresidentsGrantApproval_Report.aspx">
                                                <div class="profile-widget-name">Grant Report</div>
                                            </a>
                                        </div>
                                    </div>
                                </div>
                                <div class="col-12 col-sm-12 col-lg-4">
                                    <div class="card profile-widget" style="height: 65%;">
                                        <div class="profile-widget-header">
                                            <div class="row">
                                                <div class="col-12">
                                                    <div class="feature-rounded">
                                                        <img alt="image" src="assets/img/document.png" class="" style="background: #2600ff  !important;">
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                        <div class="profile-widget-description pb-0">
                                            <a href="vesting_approval_president_Report.aspx">
                                                <div class="profile-widget-name">Vesting Report</div>
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
   <%-- <footer class="main-footer">
    </footer>--%>
    <!-- General JS Scripts -->
    <script src="assets/js/app.min.js"></script>
    <!-- JS Libraies -->
    <script src="assets/bundles/echart/echarts.js"></script>
    <!-- Page Specific JS File -->
    <script src="assets/js/page/chart-echarts.js"></script>
    <!-- Page Specific JS File -->
    <script src="assets/js/page/index.js"></script>
    <!-- Template JS File -->
    <script src="assets/js/scripts.js"></script>
    <script src="assets/bundles/jquery.sparkline.min.js"></script>
  <%--  <script type="text/javascript" src="https://www.jqueryscript.net/demo/simple-tree-table/jquery-simple-tree-table.js"></script>
    <link rel="stylesheet" type="text/css" href="https://www.jqueryscript.net/demo/simple-tree-table/jquery-simple-tree-table.css">--%>
    <script src="assets/js/jquery-simple-tree-table.js" type="text/javascript"></script>
    <link href="assets/css/jquery-simple-tree-table.css" rel="stylesheet" />
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
