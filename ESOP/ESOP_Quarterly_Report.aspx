<%@ Page Title="" Language="C#" MasterPageFile="~/ESOP.Master" AutoEventWireup="true" CodeBehind="ESOP_Quarterly_Report.aspx.cs" Inherits="ESOP.ESOP_Quarterly_Report" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
        .sidebar-mini .main-sidebar:after {
            box-shadow: 0 4px 25px 0 rgba(0, 0, 0, .1);
            content: ' ';
            position: fixed;
            background-color: rgb(38 114 255) !important;
            width: 65px;
            height: 100%;
            left: 0;
            top: 0;
            z-index: -1;
            opacity: 0;
            animation-name: mini-sidebar;
            animation-duration: 1.5s;
            animation-fill-mode: forwards;
        }

        .main-sidebar .sidebar-menu li a {
            color: white;
        }

        .main-sidebar .sidebar-brand {
            border-bottom: 3px solid white;
        }

        .navbar {
            background-color: white;
        }

        .table {
            border: none !important;
        }

        table.dataTable, table.dataTable th, table.dataTable td {
            /*box-sizing: content-box;*/
            border: 1px solid #fff !important;
        }

        .sorting_1 {
            border: 1px solid #fff !important;
        }

        .card .card-body, .card .card-footer, .card .card-header {
            /*background-color: transparent;*/
            padding: 15px 25px !important;
        }

        table.dataTable thead th, table.dataTable thead td {
            padding: 10px 15px;
            /*border-bottom: 1px solid #111;*/
        }

        table.dataTable td, table.dataTable th {
            -webkit-box-sizing: content-box;
            box-sizing: content-box;
            line-height: 23px;
        }

        table.dataTable > thead > tr > th:not(.sorting_disabled), table.dataTable > thead > tr > td:not(.sorting_disabled) {
            padding-right: 35px !important;
            padding-left: 5px !important;
            height: 30px;
            font-size: 14px !important;
        }

        .remark {
            padding: 5px;
        }

        .table th {
            padding: .4rem;
        }

        .table:not(.table-sm) thead th {
            padding-top: 0px;
            padding-bottom: 0px;
        }

        .table td, .table th {
            padding: 0px;
            padding-left: 5px;
        }

        .table:not(.table-sm) thead th {
            background-color: #6c757d4f;
            color: #000000c2;
            font-size: 14px !important;
            line-height: 1.3;
        }

        .table td {
            font-weight: 500;
            color: #3f646d;
            font-size: 14px;
            background: #bcc0c32e;
            border-top: none;
        }

        input[type="text"] {
            /*border: 1px solid #615a72;*/
            border-radius: 6px;
            padding-left: 8px;
            font-weight: 500;
            color: #3f646d;
            font-size: 14px;
            /*background: #f3f4f4;*/
        }

        .card {
            height: auto;
        }

        .text-muted {
            color: #1ea3c1 !important;
            font-weight: 600;
        }

        .card .card-header h4 {
            font-size: 17px;
        }

        .card .card-header {
            background-color: transparent;
            /*padding: 11px 40px !important;*/
            padding: 5px 40px !important;
        }

        .main-footer {
            margin-top: 32px !important;
        }

        /*.btn-group {
            height: 22px;
        }*/

        button.btn.badge.badge-success.badge-shadow {
            line-height: 3px;
        }

        button.btn.badge.badge-danger.badge-shadow {
            line-height: 3px;
        }

        .card .card-header .btn {
            margin-top: 1px;
            padding: 0px 8px;
        }

        .buttons .btn {
            margin: 0 0px 0px 0;
        }

        .offset-md-7 {
            margin-left: 63.333333%;
        }

        .card {
            height: auto;
        }

        .text-muted {
            /*color: #1ea3c1 !important;*/
            color: #2773ff !important;
            font-weight: 600;
        }

        .theme-white .nav-pills .nav-link.active {
            color: #2673ff;
            /*color: #0889a9;*/
            background-color: #b0efef70 !important;
            border-bottom: 2px solid #135d6f;
            font-size: 14px;
        }

        .nav-pills .nav-item .nav-link.active {
            color: #fff;
            background-color: #b0efef70;
        }

        .nav-pills .nav-item .nav-link {
            color: #0893c2;
            padding-left: 8px !important;
            padding-right: 8px !important;
            border-radius: 0;
            font-size: 14px;
            background: #8080801f;
            margin-left: 5px;
        }

        .nav-link {
            display: block;
            padding: .1rem 1rem;
        }

        .head {
            font-size: 13px !important;
        }

        .card .card-header h4 {
            font-size: 17px;
        }

        .form-control:not(.form-control-sm):not(.form-control-lg), .input-group-text, select.form-control:not([size]):not([multiple]) {
            font-size: 14px;
            padding: 0px 0px;
        }

        select.form-control {
            height: 32px !important;
            /*border: 1px solid #615a72;*/
            font-weight: 500;
            color: #3f646d;
            font-size: 14px;
            /*background: #f3f4f4;*/
            border-radius: 6px;
        }

        optgroup {
            font-size: 12px;
            font-weight: 500;
            color: #636060ed;
        }

        div#table-21_length {
            display: none;
        }

        div#table-22_length {
            display: none;
        }

        .offset-md-9 {
            margin-left: 75%;
            margin-top: -25px;
        }

        .offset-md-10 {
            margin-left: 82%;
        }

        .section > :first-child {
            margin-top: -7px;
        }


        .table:not(.table-sm):not(.table-md):not(.dataTable) th {
            background: #6c757d75 !important;
            color: #000000c2 !important;
        }

        .btn {
            height: 34px;
        }

        .form-control:not(.form-control-sm):not(.form-control-lg) {
            font-size: 13px;
            /*padding: 10px 15px !important;
            line-height: 1.4;*/
            height: 31px !important;
        }

        .btn-success, .btn-success.disabled {
            box-shadow: 0 2px 6px #abf2d7;
            background-color: #2600ff;
            border-color: #2600ff;
            color: #fff !important;
        }

        /*.modal.show .modal-content {
            width: 85% !important;
            padding-bottom: 12px;
        }*/
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ScriptManager ID="script" runat="server"></asp:ScriptManager>

    <script src="assets/js/jquery-1.8.3.min.js" type="text/javascript"></script>
    <link href="assets/css/jquery-ui-1.12.1.css" rel="stylesheet" />
    <script src="assets/js/jquery-1.12.4.js" type="text/javascript"></script>
    <script src="assets/js/jquery-ui-1.12.1.js" type="text/javascript"></script>

    <script type="text/javascript">
        $(document).ready(function () {

            $('.CloseBtnNew').click(function () {
                // alert('test');

                $("#myModal").removeClass("show");
                $("#myModal").hide();
                $(".modal-backdrop").remove();
                //$("#myModal").hide();
                $("body").removeClass("modal-open");
                // $("#myModal1").modal("hide");
            });
        })
    </script>
    <script type="text/javascript">

        $(function () {
            $.noConflict();
            var from = $("#ContentPlaceHolder1_txtStartDate")
          .datepicker({
              //minDate: '-1m',
              dateFormat: "dd-mm-yy",
              changeMonth: true,
              changeYear: true,
              yearRange: "-50:+50",

          })
          .on("change", function () {
              to.datepicker("option", "minDate", getDate(this));
          }),
        to = $("#ContentPlaceHolder1_txtEndDate").datepicker({
            dateFormat: "dd-mm-yy",
            changeMonth: true,
            changeYear: true,
            yearRange: "-50:+50",
        })
        .on("change", function () {
            from.datepicker("option", "maxDate", getDate(this));
        });

            function getDate(element) {
                var date;
                var dateFormat = "dd-mm-yy";
                try {
                    date = $.datepicker.parseDate(dateFormat, element.value);
                } catch (error) {
                    date = null;
                }

                return date;
            }
        });
    </script>

    <script src="assets/js/jquery.dataTables-1.10.20.min.js"></script>
    <link href="Scripts/jquery.dataTables.min.css" rel="stylesheet" />
    <link href="Scripts/dataTables.bootstrap4.min.css" rel="stylesheet" />


    <script>
        //$('#ContentPlaceHolder1_GrvApproved').clear().draw();
        $(function () {
            var prm = Sys.WebForms.PageRequestManager.getInstance();

            prm.add_endRequest(function (sender, e) {

                $('#ContentPlaceHolder1_GrvApproved').dataTable({
                    lengthMenu: [[-1, 5, 10], ["All", 5, 10]],
                    bRetrieve: true,
                });

            });
        });
        $(function () {

            $("#ContentPlaceHolder1_GrvApproved").DataTable({
                bLengthChange: true,
                lengthMenu: [[-1, 5, 10], ["All", 5, 10]],
                bFilter: true,
                'columnDefs': [{
                    'targets': [],
                    'orderable': false,
                }],
                //bSort:true,
                bPaginate: true

            });
        });
    </script>



    <div class="main-content" style="padding-top: 55px; padding-left: 40px; padding-right: 10px;">
        <div style="font-weight: 500; display: none" runat="server" id="div">ESOP Summary</div>
        <nav aria-label="breadcrumb">

            <ol class="breadcrumb">
                <li class="breadcrumb-item"><a id="dasboard" runat="server" href="admin-dashboard.aspx">Home</a></li>
                <li class="breadcrumb-item"><a id="report" runat="server" href="reports.aspx">Reports</a></li>
                <li class="breadcrumb-item active" aria-current="page" runat="server" id="li">ESOP</li>
            </ol>
        </nav>
        <section class="section">
            <div class="row">
                <div class="col-12">
                    <div class="card">
                        <div class="card-header">
                            <h4>ESOP Summary</h4>
                        </div>
                        <div class="card-body">
                            <div class="row">
                                <div class="col-lg-2 col-md-12 col-sm-12 all">
                                    <div class="form-group">
                                        <label>Select Duration</label>
                                        <asp:DropDownList ID="ddlDuratin" runat="server" CssClass="form-control" AutoPostBack="false">
                                            <asp:ListItem Value="0">Select</asp:ListItem>
                                            <asp:ListItem Value="1">1st Qaurter</asp:ListItem>
                                            <asp:ListItem Value="2">2nd  Qaurter</asp:ListItem>
                                            <asp:ListItem Value="3">3rd Qaurter</asp:ListItem>
                                            <asp:ListItem Value="4">4th Qaurter</asp:ListItem>
                                            <asp:ListItem Value="5">1st Half</asp:ListItem>
                                            <asp:ListItem Value="6">2nd Half</asp:ListItem>
                                            <asp:ListItem Value="7">Yearly</asp:ListItem>
                                        </asp:DropDownList>
                                    </div>
                                </div>
                                <div class="col-lg-2 col-md-12 col-sm-12 all" style="display:none">
                                    <div class="form-group">
                                        <label>Start Date</label>
                                        <asp:TextBox ID="txtStartDate" type="text" runat="server" Placeholder="dd-mm-yyyy" class="form-control" AutoComplete="off"></asp:TextBox>
                                    </div>
                                </div>
                                <div class="col-lg-2 col-md-12 col-sm-12 all" style="display:none">
                                    <div class="form-group">
                                        <label>End Date</label>
                                        <asp:TextBox ID="txtEndDate" type="text" runat="server" Placeholder="dd-mm-yyyy" class="form-control" AutoComplete="off"></asp:TextBox>
                                    </div>
                                </div>
                                <div class="col-lg-3 offset-md-3" style="padding-top: 30px;">
                                    <asp:UpdatePanel ID="upd12" runat="server">
                                        <ContentTemplate>
                                            <asp:Button ID="btnFilter" runat="server" Text="Filter" Class="btn btn-info btn-lg all" Style="margin-top: -11%"
                                                OnClick="btnFilter_Click" />
                                            <asp:Button ID="btnClearFilter" runat="server" Text="Clear Filter" Class="btn btn-info btn-lg all" CausesValidation="true" Style="margin-top: -28px; display:none"
                                                OnClick="btnClearFilter_Click" />
                                            <asp:ImageButton ID='btnexcelExport' runat='server' ImageUrl="~/img/excel1.png" Style="margin-left: 3px;" OnClick="btnexcelExport_Click" Height="35px" ToolTip="Export To Excel" />
                                            <asp:ImageButton ID='btnpdfexport' runat='server' ImageUrl="~/img/pdf.png" OnClick="btnpdfexport_Click" Height="35px" ToolTip="Export To Pdf" />
                                        </ContentTemplate>
                                        <Triggers>
                                            <asp:PostBackTrigger ControlID="btnFilter" />
                                            <asp:PostBackTrigger ControlID="btnClearFilter" />
                                            <asp:PostBackTrigger ControlID="btnexcelExport" />
                                            <asp:PostBackTrigger ControlID="btnpdfexport" />
                                        </Triggers>
                                    </asp:UpdatePanel>
                                </div>
                            </div>




                            <div class="table-responsive" style="margin-top: 30px;">
                                <asp:UpdatePanel ID="upd" runat="server" UpdateMode="Conditional">

                                    <ContentTemplate>
                                        <asp:GridView ID="GrvApproved" runat="server" ShowHeaderWhenEmpty="false"
                                            OnPreRender="GrvApproved_PreRender" EmptyDataText="No Records Found" AutoGenerateColumns="false"
                                            class="table">
                                            <Columns>
                                                <asp:BoundField DataField="grant_name" HeaderText="Tranch ID" />
                                                <asp:BoundField DataField="date_of_grant" HeaderText="Date Of Grant" />
                                                <asp:BoundField DataField="FMV_PRICE" HeaderText="Grant Price" />
                                                <asp:BoundField DataField="Tot_Shares" HeaderText="Total Shares" />
                                                <asp:BoundField DataField="Emp_count" HeaderText="Emp Count @ Grant" /> 
                                                <asp:BoundField DataField="no_of_vesting" HeaderText="Total Vested" />
                                                <asp:BoundField DataField="no_of_vesting_Pending" HeaderText="Pending For Vesting" />
                                                <asp:BoundField DataField="NO_OF_EXERCISE" HeaderText="Total Exercised" />
                                                <asp:BoundField DataField="Pending_For_Exercise" HeaderText="Pending For Exercise" />
                                                <asp:BoundField DataField="LBV" HeaderText="Lapsed Before Vesting" />
                                                <asp:BoundField DataField="LAV" HeaderText="Lapsed After Vesting" />
                                                <asp:BoundField DataField="Tot_lapse" HeaderText="Total Lapsed" />
                                            </Columns>
                                        </asp:GridView>
                                    </ContentTemplate>
                                    <Triggers>

                                        <asp:PostBackTrigger ControlID="GrvApproved" />
                                    </Triggers>
                                </asp:UpdatePanel>
                            </div>
                            <%-- </div>--%>
                        </div>



                    </div>
                </div>
            </div>
        </section>
    </div>
    <%--  <footer class="main-footer">
    </footer>--%>
    <script src="Scripts/bootstrap.min.js"></script>
    <script src="assets/js/app.min.js"></script>

    <script src="assets/js/scripts.js"></script>



</asp:Content>
