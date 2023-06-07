<%@ Page Title="" Language="C#" MasterPageFile="~/ESOP.Master" AutoEventWireup="true" CodeBehind="HRMSUpload.aspx.cs" Inherits="ESOP.HRMSUpload" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
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
            margin-top: 2.6rem !important;
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
            margin-left: 88.333333%;
        }

        .offset-md-9 {
            margin-left: 84%;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ScriptManager ID="script" runat="server"></asp:ScriptManager>
    <div class="main-content" style="min-height: 562px;">
        <nav aria-label="breadcrumb" class="offset-md-9" style="margin-top: 13px;">
            <ol class="breadcrumb">
                <li class="breadcrumb-item"><a href="admin-dashboard">Home</a></li>

                <li class="breadcrumb-item active" aria-current="page">Grants</li>

            </ol>
        </nav>
        <section class="section">
            <div class="row">
                <div class="col-lg-12 col-md-12 col-12 col-sm-12">
                    <div class="card">
                        <div class="card-header">
                            <h4>HRMS Upload</h4>
                        </div>
                        <div class="card-body">
                            <div class="row" style="margin-top: 15px;">
                                <div class="col-md-12 form-group">
                                    <ul class="list-unstyled list-inline">
                                        <li style="vertical-align: middle;" class="list-inline-item">
                                            <div class="form-group">
                                                <asp:FileUpload ID="uploadfile" runat="server" CssClass="dropify" accept=".xls, .xlsx" onchange="return dispFileName();" />
                                            </div>
                                        </li>
                                        <li style="vertical-align: middle;" class="list-inline-item">
                                            <div class="form-group">
                                                <asp:Button ID="btn_downloadFormat" runat="server" class="btn btn-info btn-lg all" Text="Download Format" OnClick="btn_downloadFormat_Click" />
                                            </div>
                                        </li>
                                        <li>
                                            <%--<button class="btn-sm">Download Template</button>--%>
                                            <center><asp:Button ID="btnimport1" runat="server" Text="Upload" OnClick="btnupload_Click" OnClientClick="showProgress()" class="btn btn-info btn-lg all " /></center>

                                        </li>
                                    </ul>
                                </div>

                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </section>
    </div>




    <div class="boxdiv col-md-12" style="padding: 20px 15px 15px;">
        <div id="Div1" runat="server">
            <div class="col-md-12 form-group">
                <ul class="list-unstyled list-inline">
                    <li style="margin-right: 15px;">
                        <label>Data Action</label></li>
                    <li>
                        <div class="cntr">
                            <label for="rdo33" class="btn-radio">
                                <input type="radio" id="rdo33" name="rdobtnAppendOverWrite" value="AppendData">
                                <svg width="20px" height="20px" viewBox="0 0 20 20">
                                    <circle cx="10" cy="10" r="9"></circle>
                                    <path d="M10,7 C8.34314575,7 7,8.34314575 7,10 C7,11.6568542 8.34314575,13 10,13 C11.6568542,13 13,11.6568542 13,10 C13,8.34314575 11.6568542,7 10,7 Z" class="inner"></path>
                                    <path d="M10,1 L10,1 L10,1 C14.9705627,1 19,5.02943725 19,10 L19,10 L19,10 C19,14.9705627 14.9705627,19 10,19 L10,19 L10,19 C5.02943725,19 1,14.9705627 1,10 L1,10 L1,10 C1,5.02943725 5.02943725,1 10,1 L10,1 Z" class="outer"></path>
                                </svg>
                                <span>Append</span>
                            </label>
                        </div>
                    </li>
                    <li>
                        <div class="cntr">
                            <label for="rdo-22" class="btn-radio">
                                <input type="radio" id="rdo-22" name="rdobtnAppendOverWrite" value="OverwriteData">
                                <svg width="20px" height="20px" viewBox="0 0 20 20">
                                    <circle cx="10" cy="10" r="9"></circle>
                                    <path d="M10,7 C8.34314575,7 7,8.34314575 7,10 C7,11.6568542 8.34314575,13 10,13 C11.6568542,13 13,11.6568542 13,10 C13,8.34314575 11.6568542,7 10,7 Z" class="inner"></path>
                                    <path d="M10,1 L10,1 L10,1 C14.9705627,1 19,5.02943725 19,10 L19,10 L19,10 C19,14.9705627 14.9705627,19 10,19 L10,19 L10,19 C5.02943725,19 1,14.9705627 1,10 L1,10 L1,10 C1,5.02943725 5.02943725,1 10,1 L10,1 Z" class="outer"></path>
                                </svg>
                                <span>Overwrite</span>
                            </label>
                        </div>
                    </li>
                </ul>
            </div>
        </div>
        <asp:UpdatePanel ID="UPMain1" runat="server" UpdateMode="Conditional">
            <ContentTemplate>
                <ul class="list-unstyled list-inline pull-right">
                    <li>
                        <%--<button runat="server" id="btnimport" class="btn btn-mini" title="Upload" onserverclick="uploadData"> Upload </button>--%>
                        <center><%--<asp:Button ID="btnimport1" runat="server" Text="Upload" OnClick="btnupload_Click" OnClientClick="showProgress()" class="btn btn-info btn-lg all " />--%></center>

                    </li>
                </ul>
            </ContentTemplate>
            <Triggers>
                <asp:PostBackTrigger ControlID="btnimport1" />
            </Triggers>
        </asp:UpdatePanel>
        <%--<asp:Label ID="lblUploadValidation" runat="server" Text="Please select the option if you want to Append or Overwrite the data." ForeColor="Red" Font-Size="X-Small"></asp:Label>--%>
    </div>

    <div class="clearfix"></div>
    <div id="tablediv" runat="server">
        <div class="alert boxdiv">
            <h3><strong>Summary :</strong> </h3>

            <div id="SuccessDiv" runat="server" style="padding: 10px 20px; background: #efffe4; font-size: 12px; border-radius: 5px;">
                <p>
                    <strong style="color: #e41f25;">
                        <asp:Label ID="lblSuccessTitle" runat="server"></asp:Label>
                    </strong>
                    <asp:Label ID="lblSuccessCount" runat="server" Font-Size="12px"></asp:Label>
                </p>

                <!-- <ul class="list-unstyled list-inline text-right"> 
                        <li>
                            <button id="btnimport">Update</button>
                        </li>
                        <li>
                            <button id="btnimport">Override</button>
                        </li>
                    </ul> -->
            </div>
            <div class="clearfix"></div>
            <br>
            <div id="Div_FailRec" runat="server">

                <div class="" style="padding: 10px 20px; background: #fff2f2; font-size: 12px; border-radius: 5px;">
                    <%--<div class="">--%>
                    <div class="row">
                        <div class="col-md-10">
                            <p>
                                <strong style="color: #e41f25;">
                                    <asp:Label ID="lblFailedTitle" runat="server"></asp:Label></strong>
                                <asp:Label ID="lblFailedCount" runat="server" Font-Size="12px"></asp:Label>
                            </p>
                        </div>
                        <div class="col-md-2">
                            <table class="table reporttable text-right" style="border-collapse: collapse;">
                                <tbody>
                                    <tr style="background-color: transparent;">
                                        <td style="padding: 0;">
                                            <ul class="list-unstyled list-inline">
                                                <%--<li style="    font-size: 12px; vertical-align: text-top;"> Download </li>--%>
                                                <li><%--<i class="fas fa-file-excel excel" title="Download Excel" aria-hidden="true" ></i> --%>

                                                    <asp:ImageButton ID="btnExDown" ImageUrl="assets/images/excel1.png" runat="server" OnClick="downloadFailedRec" CssClass="fas fa-file-excel excel"></asp:ImageButton>

                                                    <%--<button runat="server" id="btnExDown" onserverclick="downloadFailedRec" style="background:none">
                                                     <i class="fas fa-file-excel excel" title="Download Excel" aria-hidden="true" ></i>
                                                    </button>--%>
                                                </li>

                                                <%-- <li> <%--<i class="fas fa-file-excel excel" title="Download Excel" aria-hidden="true" ></i> 
                                                 <button runat="server" id="btnCSVDown" onserverclick="downloadFailedRec_CSV">
                                                     <i class="fas fa-file-csv csv" title="Download CSV" aria-hidden="true"></i>
                                                    </button>
                                            </li>--%>
                                            </ul>
                                        </td>
                                    </tr>
                                </tbody>
                            </table>
                        </div>
                    </div>
                </div>
            </div>


        </div>
    </div>

    <asp:UpdateProgress ID="UpdateProgress" runat="server" AssociatedUpdatePanelID="UPMain1">
        <ProgressTemplate>
            <div id="overlay">
                <div id="modalprogress">
                    <div id="theprogress">

                        <img src="images/loading.gif" />
                    </div>
                </div>
            </div>
        </ProgressTemplate>
    </asp:UpdateProgress>


    <script src="https://cdnjs.cloudflare.com/ajax/libs/jquery/2.1.3/jquery.min.js"></script>
    <script>
        $(document).ready(function () {


        });
        $("select").change(function () {
            if ($(this)[0].selectedIndex <= 0) {
                $(this).removeClass('changecolor');
            }
            else {
                $(this).addClass('changecolor');
            }
        });

        //$('#tablediv').hide();
        //$('#ContentPlaceHolder1_btnimport').click(function () {
        //    debugger;
        //    $('#tablediv').slideDown();
        //    $('html, body').animate({
        //        scrollTop: $("#tablediv").offset().top
        //    }, 2000);

        //});

        //textbox effect
        $(".form-control").val("");
        $(".form-control").focusout(function () {
            if ($(this).val() != "") {
                $(this).addClass("has-content");
            } else {
                $(this).removeClass("has-content");
            }
        });

        $('input:radio[name="rdobtnAppendOverWrite"]').change(
     function () {
         if ($(this).is(':checked')) {
             // alert('gte');
             $('#ContentPlaceHolder1_lblUploadValidation').hide();
             // document.getElementById(lblUploadValidation).style.display = 'block';
         }
     })
    </script>

    <script>

        $('ul li').on('click', function () {
            $('li').removeClass('active');
            $(this).addClass('active');
        });

    </script>

    <style>
        .card {
            height: auto !important;
        }

        h4 {
            font-weight: 600;
            font-size: 16px;
            color: #2b76ff;
        }

        .chosen-container {
            width: 100% !important;
        }


        .switch {
            position: relative;
            display: inline-block;
            width: 70px;
            height: 24px;
            margin-top: 7px;
        }

            .switch input {
                opacity: 0;
            }

        .slider {
            position: absolute;
            cursor: pointer;
            top: 0;
            left: 0;
            right: 0;
            bottom: 0;
            background-color: #ccc;
            -webkit-transition: .4s;
            transition: .4s;
        }

            .slider:before {
                position: absolute;
                content: "";
                height: 16px;
                width: 16px;
                left: 4px;
                bottom: 4px;
                background-color: white;
                -webkit-transition: .4s;
                transition: .4s;
            }

        input:checked + .slider {
            background-color: #2600ff;
        }

        input:focus + .slider {
            box-shadow: 0 0 1px #2196F3;
        }

        input:checked + .slider:before {
            -webkit-transform: translateX(46px);
            -ms-transform: translateX(46px);
            transform: translateX(46px);
        }
        /*------ ADDED CSS ---------*/
        .on {
            display: none;
        }

        .on, .off {
            color: white;
            position: absolute;
            transform: translate(-50%,-50%);
            top: 50%;
            left: 50%;
            font-size: 12px;
            font-family: Verdana, sans-serif;
        }

        input:checked + .slider .on {
            display: block;
        }

        input:checked + .slider .off {
            display: none;
        }

        /* Rounded sliders */
        .slider.round {
            border-radius: 34px;
        }

            .slider.round:before {
                border-radius: 50%;
            }
    </style>

    <%--<script src="https://code.jquery.com/jquery-1.12.0.min.js"></script>
    <link type="text/css" href="CSS/ui.all.css" rel="stylesheet" />
    <script type="text/javascript" src="Scripts/jquery-1.3.2.js"></script>
    <script type="text/javascript" src="Scripts/ui.core.js"></script>
    <script type="text/javascript" src="Scripts/ui.progressbar.js"></script>--%>


    <script type="text/javascript">
        function showProgress() {
            var updateProgress = $get("<%= UpdateProgress.ClientID %>");
            updateProgress.style.display = "block";
        }
    </script>
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
</asp:Content>
