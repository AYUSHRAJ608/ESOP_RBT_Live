<%@ Page Language="C#" MasterPageFile="~/ESOP.Master" AutoEventWireup="true" CodeBehind="ESOP_Excel_Report.aspx.cs" Inherits="ESOP.ESOP_Excel_Report" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ScriptManager ID="script" runat="server"></asp:ScriptManager>
    <%--<script type="text/javascript" src="http://ajax.googleapis.com/ajax/libs/jquery/1.10.2/jquery.min.js"></script>--%>
    <%--<script type="text/javascript" src="assets/js/jquery-3.3.1.min.js"></script>--%>
    <script type="text/javascript" src="assets/js/jquery-1.8.3.min.js"></script>
    <script type="text/javascript" src="assets/js/bootstrap.min.js"></script>
    <%--<script src="https://cdnjs.cloudflare.com/ajax/libs/waypoints/2.0.3/waypoints.min.js"></script>
    <script src="http://bfintal.github.io/Counter-Up/jquery.counterup.min.js"></script>
    --%>
    <script type="text/javascript">
        //jQuery(document).ready(function ($) {
        //       $('.counter').counterUp({
        //           delay: 10,
        //           time: 1000
        //       });
        //   });
        $('.emptable tr td.more').click(function () {
            debugger;
            $('html, body').animate({ scrollTop: $(this).position().top }, 'slow');
        });
        $(window).scroll(function () {
            sessionStorage.scrollTop = $(this).scrollTop();
        });

        $(document).ready(function () {
            if (sessionStorage.scrollTop != "undefined") {
                $(window).scrollTop(sessionStorage.scrollTop);
            }
        });

    </script>
    <%--<script type="text/javascript" src='https://cdnjs.cloudflare.com/ajax/libs/twitter-bootstrap/3.0.3/js/bootstrap.min.js'></script>--%>
    <script type="text/javascript">
        $(document).ready(function () {
            $('[id*=chkAddAll]').click(function () {
                $("[id*='chkAdd']").attr('checked', this.checked);
            });
            $('[id*=chkUpdateAll]').click(function () {
                $("[id*='chkUpdate']").attr('checked', this.checked);
            });
        });
    </script>
    <script type="text/javascript">
        function openModal() {
            debugger;
            $('#UpdateModal').modal('show');

        }

    </script>
    <style>
        .pagerU table {
            width: 30% !important;
        }

        header {
            padding: 4px !important;
            width: 44px;
        }

        .emptable tr:first-child th {
            background-color: #e41f25 !important;
            color: #fff !important;
            font-weight: bold !important;
        }
    </style>

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


        .onoffswitch {
            position: relative;
            width: 80px;
            -webkit-user-select: none;
            -moz-user-select: none;
            -ms-user-select: none;
            height: 32px;
        }

        .onoffswitch-checkbox {
            display: none;
        }

        .onoffswitch-label {
            display: block;
            overflow: hidden;
            cursor: pointer;
            border: 2px solid #FFFFFF;
            border-radius: 50px;
            position: relative;
            margin: 0;
        }

        .onoffswitch-inner {
            display: block;
            width: 200%;
            margin-left: -100%;
            transition: margin 0.3s ease-in 0s;
        }

            .onoffswitch-inner:before, .onoffswitch-inner:after {
                display: block;
                float: left;
                width: 50%;
                height: 29px;
                padding: 0;
                line-height: 29px;
                font-size: 11px;
                color: white;
                font-family: Montserrat;
                font-weight: 600;
                box-sizing: border-box;
            }

            .onoffswitch-inner:before {
                content: "Enable";
                padding-left: 7px;
                background-color: #EEEEEE;
                color: #26ad5b;
                font-family: Montserrat;
            }

            .onoffswitch-inner:after {
                content: "Disable";
                padding-right: 7px;
                background-color: #EEEEEE;
                color: #999999;
                text-align: right;
                font-family: Montserrat;
            }

        .onoffswitch-switch {
            display: block;
            width: 19px;
            margin: 5px;
            background: #A1A1A1;
            position: absolute;
            top: 0;
            bottom: 0;
            right: 48px;
            border: 2px solid #FFFFFF;
            border-radius: 50px;
            transition: all 0.3s ease-in 0s;
        }

        .onoffswitch-checkbox:checked + .onoffswitch-label .onoffswitch-inner {
            margin-left: 0;
        }

        .onoffswitch-checkbox:checked + .onoffswitch-label .onoffswitch-switch {
            right: 0px;
            background-color: #26ad5b;
        }

        .onoffswitch-inner:after {
            content: "OFF";
            padding-right: 18px;
            background-color: #939598;
            color: #fff;
            text-align: right;
            font-family: Montserrat;
            font-size: 12px;
        }

        .onoffswitch-inner:before {
            content: "ON";
            padding-left: 18px;
            background-color: #5a9d44;
            color: #ffffff;
            font-family: Montserrat;
            font-size: 12px;
        }

        .onoffswitch-checkbox:checked + .onoffswitch-label .onoffswitch-switch {
            right: 0px;
            background-color: #5a9d44;
        }
         @media (min-width: 768px) {
.offset-md-8 {
    margin-left: 76%;
}
}
    </style>

    <div class="main-content" style="min-height: 562px;">
        <nav aria-label="breadcrumb">
            <ol class="breadcrumb" style="margin-bottom: -23px !important;">
                <li class="breadcrumb-item"><a href="admin-dashboard">Home</a></li>
                <li class="breadcrumb-item"><a href="reports.aspx">Reports</a></li>
                <li class="breadcrumb-item active" aria-current="page">Export to Excel</li>

            </ol>
        </nav>
        <section class="section">
            <div class="row">
                <div class="col-lg-12 col-md-12 col-12 col-sm-12">
                    <div class="card">
                        <div class="card-header">
                            <h4></h4>
                        </div>
                        <div class="card-body mr-4">
                            <div class="row" style="margin-top: 15px;">
                                <div class="col-md-12 form-group">
                                    <ul class="list-unstyled list-inline">
                                        <li style="vertical-align: middle;" class="list-inline-item">
                                            <div class="form-group">
                                                <label>Export to Excel</label>
                                            </div>
                                        </li>
                                        <li style="vertical-align: middle;" class="list-inline-item">
                                            <asp:Button ID="btnExportToExcel" runat="server" Text="Export to Excel" OnClick="btnExportToExcel_Click" OnClientClick="return validate(); showProgress1(); return false;return postbackButtonClick();" CssClass="btn btn-info btn-lg all" />
                                        </li>

                                    </ul>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>

            <div class="table-responsive" style="margin-top: 30px;">
                <asp:UpdatePanel ID="upd" runat="server" UpdateMode="Conditional">
                    <ContentTemplate>
                        <asp:GridView ID="GrdExcelData" runat="server" ShowHeaderWhenEmpty="false"
                            EmptyDataText="No Records Found" AutoGenerateColumns="false"
                            class="table">
                            <Columns>
                            </Columns>
                        </asp:GridView>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </div>
        </section>
    </div>


    <%--<script src="https://cdnjs.cloudflare.com/ajax/libs/jquery/2.1.3/jquery.min.js"></script>--%>
    <script>


        $(document).ready(function () {
            if ($('.onoffswitch-checkbox input[type="checkbox"]').is(':checked')) {
                $('.onoffswitch-label .onoffswitch-inner').css('margin-left', '0');
                $('.onoffswitch-label .onoffswitch-switch').css({ 'right': '0', 'background-color': '#5a9d44' });
            }
        });
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

    <script>
        $(document).ready(function () {
            if ($('.onoffswitch-checkbox input[type="checkbox"]').is(':checked')) {
                $('.onoffswitch-label .onoffswitch-inner').css('margin-left', '0');
                $('.onoffswitch-label .onoffswitch-switch').css({ 'right': '0', 'background-color': '#5a9d44' });
            }
        });
    </script>
</asp:Content>
