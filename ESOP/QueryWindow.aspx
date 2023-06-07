<%@ Page Language="C#" MasterPageFile="~/ESOP.Master" AutoEventWireup="true" CodeBehind="QueryWindow.aspx.cs" Inherits="ESOP.QueryWindow" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

    <link href="assets/css/jquery-ui-1.12.1.css" rel="stylesheet" />
    <script src="assets/js/jquery-1.12.4.js" type="text/javascript"></script>
    <script src="assets/js/app.min.js"></script>

    <link href="Scripts/jquery.dataTables.min.css" rel="stylesheet" />
    <script src="assets/js/jquery.dataTables-1.10.20.min.js"></script>
    <style>
        .img {
            padding: 0px;
            transition: transform .2s;
            width: 200px;
            height: 100px;
            margin: 0 auto;
        }

        .Image2:hover {
            transform: scale(2);
            margin-top: -30% !important;
            margin-left: 40% !important;
            width: 400px;
            height: 200px;
        }

        .Image5:hover {
            transform: scale(2);
            margin-top: -30% !important;
            margin-left: -50% !important;
            width: 400px;
            height: 200px;
        }

        .mt-5, .my-5 {
            margin-top: 1rem !important;
        }

        .main-footer {
            padding: 20px 0px 20px 280px;
            margin-top: 10px;
        }


        optgroup {
            font-size: 12px;
            color: #34395e;
            font-weight: 200;
        }

        option {
            font-weight: 600;
        }

        .section > :first-child {
            margin-top: 18px;
        }

        .offset-md-9 {
            margin-left: 82%;
        }

        .card {
            height: auto;
        }

        legend {
            display: block;
            width: 40%;
            max-width: 100%;
            padding: 0;
            margin-bottom: .5rem;
            font-size: 1.1rem;
            line-height: inherit;
            white-space: normal;
            color: #2774ff;
            font-weight: 500;
        }

        fieldset {
            min-width: 0;
            padding: 0;
            margin: 0;
            border: 0;
            display: block;
            margin-inline-start: 2px;
            margin-inline-end: 2px;
            padding-block-start: 0.35em;
            padding-inline-start: 0.75em;
            padding-inline-end: 0.75em;
            padding-block-end: 0.625em !important;
            min-inline-size: min-content;
            border-width: 2px;
            border-style: groove;
            border-color: threedface;
            border-image: initial;
            margin-bottom: 0px !important;
        }

        label.pop {
            font-weight: 600;
            color: #2673ff;
            font-size: 15px;
            letter-spacing: .5px;
        }

        label.pops {
            font-size: 15px;
        }

        .popRow {
            border-radius: 5px;
            margin-bottom: 15px;
        }

        .offset-md-10 {
            margin-left: 86.333333%;
        }

        .table-responsive {
            padding: 11px;
        }

        .table:not(.table-sm) thead th {
            background-color: #6c757d3d;
        }

        .form-group .control-label, .form-group > label {
            font-size: 14px !important;
            line-height: 1;
            height: 20px;
        }

        .form-control:not(.form-control-sm):not(.form-control-lg) {
            font-size: 13px;
            padding: 1px 10px;
            height: 30px;
            line-height: 1.4;
        }

        label {
            display: inline-block;
            margin-bottom: .3rem;
        }

        .col-sm-12 {
            padding-right: 0px;
            padding-left: 20px;
        }

        .col-lg-2 {
            max-width: 16.3%;
        }

        select.form-control:not([size]):not([multiple]) {
            height: 30px !important;
        }

        .form-control:not(.form-control-sm):not(.form-control-lg), .input-group-text, select.form-control:not([size]):not([multiple]) {
            line-height: 1.3;
        }

        /*grid css*/
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

        .table th {
            background-color: #6c757d4f;
            color: #000000 !important;
            font-size: 14px !important;
            line-height: 1.3;
        }

        .table td {
            font-weight: 500;
            color: #3f646d;
            font-size: 14px;
            background: #bcc0c32e;
        }

        .table:not(.table-sm):not(.table-md):not(.dataTable) th {
            font-weight: 600;
            color: #000000c2 !important;
        }


        fieldset {
            min-width: 0 !important;
            padding: 0 !important;
            margin: 0 !important;
            border: 0 !important;
            display: block !important;
            margin-inline-start: 2px !important;
            margin-inline-end: 2px !important;
            padding-block-start: 0.35em !important;
            padding-inline-start: 0.75em !important;
            padding-inline-end: 0.75em !important;
            padding-block-end: 0.625em !important;
            min-inline-size: min-content !important;
            border-width: 2px !important;
            border-style: groove !important;
            border-color: threedface !important;
            border-image: initial !important;
            margin-bottom: 5px !important;
        }

        legend {
            display: block !important;
            width: 40% !important;
            max-width: 100% !important;
            padding: 4px !important;
            margin-bottom: .5rem !important;
            font-size: 17px !important;
            line-height: inherit !important;
            white-space: normal !important;
            color: #2774ff !important;
            font-weight: 500 !important;
        }

        body {
            margin: 0 !important;
            font-family: -apple-system, BlinkMacSystemFont, "Segoe UI", Roboto, "Helvetica Neue", Arial, "Noto Sans", sans-serif, "Apple Color Emoji", "Segoe UI Emoji", "Segoe UI Symbol", "Noto Color Emoji" !important;
            font-size: 16px !important;
            font-weight: 400 !important;
            line-height: 1 !important;
            color: #212529 !important;
            text-align: left !important;
            background-color: #eef0f0 !important;
        }

        .main-content {
            padding-left: 280px;
            padding-right: 30px;
            padding-top: 35px !important;
            width: 100%;
            position: relative;
            margin-left: -12px;
        }

        label {
            display: inline-block;
            max-width: 100%;
            margin-bottom: 5px;
            font-weight: 400 !important;
        }

        .navbar {
            position: relative;
            min-height: 50px;
            margin-bottom: 0px !important;
            border: 1px solid transparent;
        }

        .navbar {
            height: 70px;
            /*width: 1527px;*/
            padding: 8px 16px;
            left: 250px;
            right: 0;
            position: absolute !important;
            z-index: 890;
            background-color: transparent;
        }

        h2.logo {
            color: #2600ff !important;
            font-size: 42px !important;
        }

        h1, h2, h3, h4, h5, h6 {
            font-weight: 600 !important;
        }

        .h2, h2 {
            font-size: 2rem !important;
        }

        .h1, .h2, .h3, .h4, .h5, .h6, h1, h2, h3, h4, h5, h6 {
            margin-bottom: .5rem !important;
            font-weight: 500 !important;
            line-height: 1.2 !important;
        }

        h1, h2, h3, h4, h5, h6 {
            margin-top: 0 !important;
            margin-bottom: .5rem !important;
        }

        /*constructed stylesheet *, ::after, ::before {
			box-sizing: border-box;
		}*/

        h2 {
            display: block !important;
            font-size: 1.5em !important;
            margin-block-start: 0.83em !important;
            margin-block-end: 0.83em !important;
            margin-inline-start: 0px !important;
            margin-inline-end: 0px !important;
            font-weight: bold !important;
        }

        label.pop {
            font-weight: 600 !important;
            color: #2673ff !important;
            font-size: 14px !important;
            letter-spacing: .5px !important;
        }

        select {
            min-height: 31px;
        }

        label.pops {
            font-weight: 600 !important;
            color: #34395e !important;
            font-size: 14px !important;
            letter-spacing: .5px !important;
        }

        .btn.btn-lg {
            /*padding: 0.40rem 1.5rem !important;*/
            font-size: 13px !important;
            color: white !important;
        }

        .btn-info, .btn-info.disabled {
            box-shadow: 0 2px 6px #719ef8 !important;
            font-size: 14px !important;
            background: #2600ff !important;
            border: 2px solid #09728a !important;
        }

        .btn {
            font-weight: 600 !important;
            font-size: 12px !important;
            line-height: 24px !important;
            padding: .2rem .8rem !important;
            letter-spacing: .5px !important;
        }

        /*letter view*/
        .letterview {
            background-color: #ffffff !important;
            text-align: center !important;
            border: 0px solid #eee !important;
            -moz-box-shadow: 0 0 15px rgba(0, 0, 0, 0.188235) !important;
            -webkit-box-shadow: 0 0 15px rgba(0, 0, 0, 0.188235) !important;
            box-shadow: 2px 2px 15px rgb(0 0 0 / 43%) !important;
            -moz-border-radius: 6px !important;
            -webkit-border-radius: 6px !important;
            border-radius: 6px !important;
            margin-bottom: 15px !important;
        }

        figure.snip0013 {
            position: relative !important;
            overflow: hidden !important;
            width: 100% !important;
            padding: 10px 10px 0px !important;
            background: #fff !important;
            text-align: center !important;
            border-radius: 8px !important;
        }

        .letterview p {
            margin: 3px 0 0 !important;
            font-size: 10px !important;
            font-weight: 500 !important;
            letter-spacing: 0.3px !important;
            color: dimgray !important;
            text-align: left !important;
        }

        figure.snip0013 img {
            max-width: 100% !important;
            opacity: 1 !important;
            -webkit-transition: opacity 0.35s !important;
            transition: opacity 0.35s !important;
        }

        .letterview p i {
            font-size: 12px !important;
            vertical-align: middle !important;
            margin-right: 3px !important;
            color: #ffffff !important;
            background: #078ca9 !important;
            padding: 6px 6px !important;
            border-radius: 5px 0 0 0 !important;
            position: absolute !important;
            bottom: -1px !important;
            right: -3px !important;
        }

        figure.snip0013:hover {
            background: #1fa2c02b !important;
        }


        .table1 th {
            /* background-color: #6c757d4f; */
            color: #000000c2 !important;
            font-size: 14px !important;
            line-height: 2.3;
            padding-left: 20px;
            font-weight: 600;
        }

        .table1 td {
            padding: 0px;
            padding-left: 15px;
            padding-left: 15px;
        }

        .custom-control-label::before {
            position: absolute;
            top: 0px;
            left: -26px;
            display: block;
            pointer-events: none;
            content: "";
            background-color: #fff;
            border: #0d42a2 solid 1px;
            width: 16px;
            height: 16px;
        }

        .custom-control-label::after {
            position: absolute;
            top: 0px;
            left: -26px;
            display: block;
            width: 16px;
            height: 16px;
            content: "";
            background: no-repeat 50%/50% 50%;
            /* background-color: #2600ff !important; */
            border-radius: 50px !important;
        }

        .modal-header {
            padding: 10px 30px 5px 30px !important;
        }
    </style>

    <script type="text/javascript">
        $(document).ready(function () {

            var prm = Sys.WebForms.PageRequestManager.getInstance();

            prm.add_endRequest(function (sender, e) {
                var table = $('#ContentPlaceHolder1_grdMain').DataTable({
                    lengthMenu: [[-1, 5, 10], ["All", 5, 10]],
                    columnDefs: [{
                        'targets': [4],
                        'orderable': false,
                    }],
                    pagingType: 'full_numbers',
                    bRetrieve: true,
                    bStateSave: true,
                    bSort: true,
                    emptyTable: 'No data available in table'
                });// bind data table on first page load
                table
.search('')
.columns().search('')
.draw();
            });

        });

        $(function () {
            debugger;
            $.noConflict();
            var table = $("#ContentPlaceHolder1_grdMain").DataTable({
                bLengthChange: true,
                lengthMenu: [[-1, 5, 10], ["All", 5, 10]],
                bFilter: true,
                columnDefs: [{
                    'targets': [4],
                    'orderable': false,
                }],
                pagingType: 'full_numbers',
                bPaginate: true,
                bRetrieve: true,
                bStateSave: true,
                bSort: true,
                bStateSave: true,
                emptyTable: 'No data available in table'
            });
            table
.search('')
.columns().search('')
.draw();
        });

    </script>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ScriptManager ID="script" runat="server"></asp:ScriptManager>
    <div class="main-content">
        <nav aria-label="breadcrumb">
            <ol class="breadcrumb">
                <li class="breadcrumb-item"><a href="admin-dashboard.aspx">Home</a></li>
                <li class="breadcrumb-item"><a href="settings.aspx">Masters</a></li>
                <li class="breadcrumb-item active" aria-current="page">Query Window</li>
            </ol>
        </nav>
        <section class="section">
            <input type="hidden" id="hdnTab" name="custId" value="2" />
            <section class="row">
                <div id="showmsg" style="text-align: center" runat="server"></div>
                <div class="col-lg-12 col-md-12 col-12 col-sm-12">
                    <div class="card">
                        <div class="card-body">
                            <div class="row">
                                <div class="col-md-10">
                                    <asp:TextBox ID="txtquerywindow" runat="server" placeholder="Enter Query" Width="100%" TextMode="MultiLine" Rows="5"></asp:TextBox>
                                </div>
                                <div class="col-md-2" style="margin: auto">
                                    <asp:Button ID="btnrun" Text="Execute" runat="server" CausesValidation="false" OnClick="btnrun_Click" CssClass="btn badge-success badge-shadow"></asp:Button>
                                </div>
                            </div>
                        </div>
                    </div>

                    <div class="card">
                        <div class="card-body">
                            <div class="col-offset-10 col-md-2" style="margin: auto">
                                <asp:ImageButton ID='btnexcelExport' runat='server' ImageUrl="~/img/excel1.png" Style="margin-left: 3px;" OnClick="btnexcelExport_Click" Height="35px" ToolTip="Export To Excel" />
                            </div>
                            <div class="table-responsive" style="margin-top: 5px;">
                                <asp:UpdatePanel ID="UpdatePanelMain" runat="server" UpdateMode="Conditional">
                                    <ContentTemplate>
                                        <asp:GridView ID="grdMain" runat="server" AutoGenerateColumns="true" CssClass="table table-bordered simple-tree-table" Style="border-collapse: separate;">
                                            <HeaderStyle BackColor="Tan" Font-Bold="True" />
                                        </asp:GridView>

                                    </ContentTemplate>
                                    <Triggers>
                                        <asp:PostBackTrigger ControlID="grdMain" />
                                    </Triggers>
                                </asp:UpdatePanel>
                            </div>
                        </div>
                    </div>
                </div>
            </section>
        </section>
    </div>
    <!-- General JS Scripts -->

    <script src="assets/js/jquery-1.12.4.js" type="text/javascript"></script>
    <script src="Scripts/bootstrap.min.js"></script>
    <script src="assets/js/scripts.js"></script>

    <script src="assets/js/jquery-ui-1.12.1.js" type="text/javascript"></script>

    <link href="assets/css/bootstrap-3.3.6.min.css" rel="stylesheet" />

</asp:Content>
