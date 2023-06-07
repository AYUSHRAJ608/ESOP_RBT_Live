<%@ Page Title="" Language="C#" MasterPageFile="~/ESOP.Master" AutoEventWireup="true" CodeBehind="employee-sale-report.aspx.cs" Inherits="ESOP.employee_sale_report" %>

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
            margin-left: 81%;
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
    </style>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">



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
    <%-- ------- ------ ------ ------ ------ ------ ------ for label and  for gridview textbox------ ------ ------ ------ ------ ------ ------  --%>
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


    <script src="assets/js/jquery.dataTables-1.10.20.min.js" type="text/javascript"></script>
    <link href="Scripts/jquery.dataTables.min.css" rel="stylesheet" />
    <link href="Scripts/dataTables.bootstrap4.min.css" rel="stylesheet" />

    <script type="text/javascript">

        //$('#ContentPlaceHolder1_grdreject').clear().draw();
        var prm = Sys.WebForms.PageRequestManager.getInstance();

        prm.add_endRequest(function (sender, e) {

            $('#ContentPlaceHolder1_gvSale').dataTable({
                lengthMenu: [[-1, 5, 10], ["All", 5, 10]],
                bRetrieve: true, fixedHeader: true, "scrollX": true
            });

        });
        $(function () {
            debugger;
            $('#ContentPlaceHolder1_gvSale').DataTable({
                bLengthChange: true,
                lengthMenu: [[-1, 5, 10], ["All", 5, 10]],
                bFilter: true,
                'columnDefs': [{

                    'orderable': false,
                }],
                bPaginate: true, fixedHeader: true, "scrollX": true

            });
        });


    </script>
    <%--    <script type="text/javascript">
        function ReqValidation() {

            var strtdate = document.getElementById('<%=txtStartDate.ClientID%>').value;
            var enddate = document.getElementById('<%=txtEndDate.ClientID%>').value;

            if (strtdate.trim() == "") {
                alert("Select Start Date!");
                document.getElementById('<%=txtStartDate.ClientID%>').focus();
                return false;
            }
            if (enddate.trim() == "") {
                alert("Select End Date!");
                document.getElementById('<%=txtEndDate.ClientID%>').focus();
                return false;
            }
        }
    </script>--%>
    <asp:ScriptManager ID="script" runat="server"></asp:ScriptManager>
    <div class="main-content">
        <nav aria-label="breadcrumb">
            <ol class="breadcrumb">
                <li class="breadcrumb-item"><a href="employee-dashboard.aspx">Home</a></li>
                <li class="breadcrumb-item"><a href="Employee_report.aspx">Reports</a></li>
                <li class="breadcrumb-item active" aria-current="page">Sale Reports</li>
            </ol>
        </nav>
        <section class="section">
            <div class="row">
                <div class="col-12">
                    <div class="card">
                        <div class="card-header">
                            <h4>Sale Reports</h4>
                        </div>
                        <div class="card-body">
                            <div class="row">
                                <div class="col-lg-2 col-md-12 col-sm-12 all">
                                    <div class="form-group">
                                        <label>Start Date</label>
                                        <%--<input type="text" class="form-control datepicker">--%>
                                        <asp:TextBox ID="txtStartDate" type="text" runat="server" Placeholder="dd-mm-yyyy" class="form-control" AutoComplete="off"></asp:TextBox>
                                    </div>
                                </div>
                                <div class="col-lg-2 col-md-12 col-sm-12 all">
                                    <div class="form-group">
                                        <label>End Date</label>
                                        <%--<input type="text" class="form-control datepicker">--%>
                                        <asp:TextBox ID="txtEndDate" type="text" runat="server" Placeholder="dd-mm-yyyy" class="form-control" AutoComplete="off"></asp:TextBox>
                                    </div>
                                </div>
                                <div class="col-lg-3 offset-md-3" style="padding-top: 30px;">
                                    <%--<a href="#" class="btn    btn-success form-control">Filter</a>--%>
                                    <asp:Button ID="btnFilter" runat="server" Text="Filter" Class="btn btn-info btn-lg all" CausesValidation="true"
                                        OnClick="btnFilter_Click" OnClientClick="return ReqValidation();" Style="margin-top: -11%" />
                                    <asp:Button ID="btnClearFilter" runat="server" Text="Clear Filter" Class="btn btn-info btn-lg all" CausesValidation="true" Style="margin-top: -28px;"
                                                OnClick="btnClearFilter_Click" />
                                    <%--                                    <asp:Button ID="btnExport" runat="server" Text="Export" Class="btn btn-info btn-lg all" OnClick="btnExport_Click" />--%>
                                    <asp:ImageButton ID='btnexcelExport' runat='server' ImageUrl="~/img/excel1.png" Style="margin-left: 3px;" OnClick="btnexcelExport_Click" Height="35px" ToolTip="Export To Excel" />
                                    <asp:ImageButton ID='btnpdfexport' runat='server' ImageUrl="~/img/pdf.png" OnClick="btnpdfexport_Click" Height="35px" ToolTip="Export To Pdf" />
                                </div>
                            </div>
                            <div class="table-responsive" style="margin-top: 30px;">
                                <asp:UpdatePanel ID="UpdatePanel3" runat="server" UpdateMode="Conditional">

                                    <ContentTemplate>
                                        <asp:GridView ID="gvSale" runat="server" AutoGenerateColumns="False" PageSize="25" ShowHeaderWhenEmpty="false"
                                            class="table table-striped table-hover" DataKeyNames="" EmptyDataText="No Records Found">
                                            <Columns>

                                                <asp:BoundField DataField="ECODE" HeaderText="EMP Code" HeaderStyle-Width="" />
                                                <asp:BoundField DataField="ENAME" HeaderText="EMP Name" HeaderStyle-Width="" />
                                                <asp:BoundField DataField="SALE_DATE" HeaderText="Sale Date" DataFormatString="{0:dd-M-yyyy}" HeaderStyle-Width="" />
                                                <asp:BoundField DataField="GRANT_PRICE" HeaderText="Grant Price" HeaderStyle-Width="" />
                                                <asp:BoundField DataField="EXERCISE_FMV_PRICE" HeaderText="Exercise Price" HeaderStyle-Width="" />
                                                <asp:BoundField DataField="SALE_FMV_PRICE" HeaderText="Sale Price" HeaderStyle-Width="" />
                                                <asp:BoundField DataField="NO_OF_SALE" HeaderText="Options Sold" HeaderStyle-Width="" />

                                                <asp:BoundField DataField="BANK_NAME" HeaderText="Bank Name" HeaderStyle-Width="" />
                                                <asp:BoundField DataField="ACC_NO" HeaderText="Account Number" HeaderStyle-Width="" />
                                                <asp:BoundField DataField="IFSC" HeaderText="IFSC" HeaderStyle-Width="" />
                                               <%-- <asp:BoundField DataField="CHEQUE_NUMBER" HeaderText="Cheque/DD No." HeaderStyle-Width="" />--%>
                                                <%--<asp:BoundField DataField="CHEQUE_DATE" HeaderText="Cheque/DD Date" DataFormatString="{0:dd-M-yyyy}" HeaderStyle-Width="" />--%>

                                                <asp:BoundField DataField="DPID" HeaderText="DP ID" HeaderStyle-Width="" />
                                                <asp:BoundField DataField="CLIENT_ID" HeaderText="Client ID" HeaderStyle-Width="" />
                                                <asp:BoundField DataField="MEMBER_TYPE" HeaderText="Member Type" HeaderStyle-Width="" />
                                                <asp:BoundField DataField="STATUS" HeaderText="Status" HeaderStyle-Width="" />

                                            </Columns>
                                        </asp:GridView>
                                    </ContentTemplate>
                                    <Triggers>
                                        <asp:AsyncPostBackTrigger ControlID="gvSale" />
                                    </Triggers>
                                </asp:UpdatePanel>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </section>
    </div>

    <!-- General JS Scripts -->
    <script src="Scripts/bootstrap.min.js"></script>

    <script src="assets/js/app.min.js"></script>

    <script src="assets/js/scripts.js"></script>

</asp:Content>

