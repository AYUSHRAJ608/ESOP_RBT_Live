<%@ Page Title="" Language="C#" MasterPageFile="~/ESOP.Master" AutoEventWireup="true" CodeBehind="Audit.aspx.cs" Inherits="ESOP.Audit" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ScriptManager ID="script" runat="server"></asp:ScriptManager>
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

        .card {
            height: 163px;
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
            padding: .32rem;
        }

        .table:not(.table-sm) thead th {
            background-color: #6c757d4f;
            color: #000000c2;
            font-size: 14px !important;
            font-size: 15px !important;
            padding: 6px;
        }

        .table td {
            font-weight: 500;
            color: #3f646d;
            font-size: 14px;
            background: #bcc0c32e;
        }

        input[type="text"] {
            /*border: 1px solid #19a5c5;*/
            border-radius: 6px;
            padding-left: 8px;
            font-weight: 500;
            color: #3f646d;
            font-size: 14px;
            /*background: #eefafc;*/
        }

        .card .card-header {
            background-color: transparent;
            padding: 11px 40px !important;
        }

        .main-footer {
            margin-top: -12px !important;
        }

        .btn-group {
            height: 34px;
        }

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

        .badge.badge-success {
            background: linear-gradient(180deg, #00b3da 0, #18c5ec 100%);
        }

        .edit12 {
            padding: 10px;
            background: #2573ff;
            color: white !important;
            border-radius: 4px;
            line-height: 0;
        }

        .delete12 {
            padding: 10px;
            background: #e3001b; /*background: #e3001b;*/
            color: white !important;
            border-radius: 4px;
            line-height: 0;
            margin-left: 4px;
            width: 30px;
        }

        .breadcrumb {
            background-color: none !important;
        }

        .section > :first-child {
            margin-top: 16px !important;
        }

        .offset-md-9 {
            margin-left: 81%;
        }

        .table:not(.table-sm):not(.table-md):not(.dataTable) th {
            background: #6c757d75 !important;
            color: #000000c2 !important;
        }
    </style>

    <script type="text/javascript" src="assets/js/jquery-1.8.3.min.js"></script>
    <script src="assets/js/jquery.dataTables-1.10.20.min.js"></script>
    <link href="Scripts/jquery.dataTables.min.css" rel="stylesheet" />
    <link href="Scripts/dataTables.bootstrap4.min.css" rel="stylesheet" />



    <script type="text/javascript">
        $("[src*=plus]").live("click", function () {
            $(this).closest("tr").after("<tr><td></td><td colspan = '999'>" + $(this).next().html() + "</td></tr>")
            $(this).attr("src", "assets/img/minus.svg");
        });
        $("[src*=minus]").live("click", function () {
            $(this).attr("src", "assets/img/plus.svg");
            $(this).closest("tr").next().remove();
        });
    </script>

    <div class="main-content">
        <nav aria-label="breadcrumb" class="offset-md-9">
            <ol class="breadcrumb" style="margin-left: -19px;">
                <li class="breadcrumb-item"><a href="admin-dashboard.aspx">Home</a></li>

                <li class="breadcrumb-item"><a href="reports.aspx">Reports</a></li>
                <li class="breadcrumb-item active" aria-current="page">Audit Trail</li>
            </ol>
        </nav>
        <section class="section">
            <div class="row">
                <div class="col-lg-12">
                    <div class="card">
                        <div class="card-header">
                            <h4>Audit Trail</h4>
                        </div>
                        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                            <ContentTemplate>
                                <div class="card-body" style="margin-left: 0%;">
                                    <div class="offset-md-3 row" style="margin-top: 15px;">
                                        <div class="col-lg-4 col-md-12 col-sm-12">
                                            <div class="form-group">
                                                <asp:DropDownList ID="ddlAudit" runat="server" CssClass="form-control" Style="width: 100% !important;">
                                                    <asp:ListItem Value="">Select..</asp:ListItem>
                                                    <asp:ListItem Value="1">Grant</asp:ListItem>
                                                    <asp:ListItem Value="2">Vesting</asp:ListItem>
                                                    <asp:ListItem Value="3">Exercise</asp:ListItem>
                                                    <asp:ListItem Value="4">Sell</asp:ListItem>
                                                </asp:DropDownList>
                                            </div>
                                        </div>

                                        <div class="col-lg-3 offset-md-3" style="margin-left: 0%;">
                                            <asp:Button ID="btnSubmit" runat="server" Text="Submit" CausesValidation="true" class="btn btn-info btn-lg all" OnClick="btnAudit_Click" />
                                        </div>

                                    </div>
                                </div>
                            </ContentTemplate>
                            <Triggers>
                                <asp:AsyncPostBackTrigger ControlID="btnSubmit" />
                            </Triggers>
                        </asp:UpdatePanel>
                    </div>
                </div>
            </div>

            <div class="col-lg-12 col-md-12 col-12 col-sm-12" id="tablediv">
                <div class="card" style="height: auto;">
                    <div class="card-header">
                        <h4>Audit Trail Summary</h4>
                    </div>
                    <div class="card-body">
                        <div class="table-responsive">
                            <asp:UpdatePanel ID="upd" runat="server">
                                <ContentTemplate>
                                    <asp:GridView ID="grdAudit" runat="server" EmptyDataText="No Records Found" AutoGenerateColumns="True"
                                        class="table table-striped table-hover" ShowHeaderWhenEmpty="false">
                                        <Columns>
                                        </Columns>
                                    </asp:GridView>

                                    <asp:GridView ID="grdExercise" runat="server" EmptyDataText="No Records Found" AutoGenerateColumns="True" DataKeyNames="ID"
                                        class="table table-striped table-hover" ShowHeaderWhenEmpty="false" OnRowDataBound="grdExercis_RowDataBound">
                                        <Columns>
                                            <asp:TemplateField HeaderStyle-Width="3%">
                                                <ItemTemplate>
                                                    <img alt="" style="cursor: pointer" src="assets/img/plus.svg" height="25px" width="25px" />
                                                    <asp:UpdatePanel ID="grdExerciseUP" runat="server" Style="display: none" UpdateMode="Conditional">
                                                        <ContentTemplate>
                                                            <asp:GridView ID="grdExercisChild" runat="server" ShowHeaderWhenEmpty="true" AutoGenerateColumns="True" PageSize="25"
                                                                class="table" EmptyDataText="No Records Found" EnableViewState="false">
                                                                <Columns>
                                                                </Columns>
                                                            </asp:GridView>
                                                        </ContentTemplate>
                                                    </asp:UpdatePanel>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                        </Columns>
                                    </asp:GridView>

                                    <asp:GridView ID="grdSell" runat="server" EmptyDataText="No Records Found" AutoGenerateColumns="True" DataKeyNames="ID"
                                        class="table table-striped table-hover" ShowHeaderWhenEmpty="false" OnRowDataBound="grdSell_RowDataBound">
                                        <Columns>
                                            <asp:TemplateField HeaderStyle-Width="3%">
                                                <ItemTemplate>
                                                    <img alt="" style="cursor: pointer" src="assets/img/plus.svg" height="25px" width="25px" />
                                                    <asp:UpdatePanel ID="grdSellUP" runat="server" Style="display: none">
                                                        <ContentTemplate>
                                                            <asp:GridView ID="grdSellChild" runat="server" ShowHeaderWhenEmpty="true" AutoGenerateColumns="True" PageSize="25"
                                                                class="table" EmptyDataText="No Records Found" EnableViewState="false">
                                                                <Columns>
                                                                </Columns>
                                                            </asp:GridView>
                                                        </ContentTemplate>
                                                    </asp:UpdatePanel>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                        </Columns>
                                    </asp:GridView>
                                </ContentTemplate>
                                <Triggers>
                                    <asp:AsyncPostBackTrigger ControlID="grdAudit" />
                                </Triggers>
                            </asp:UpdatePanel>
                        </div>
                    </div>
                </div>
            </div>
        </section>
    </div>

    <script src="Scripts/bootstrap.min.js"></script>

    <script src="assets/js/app.min.js"></script>

    <script src="assets/js/scripts.js"></script>

    <script>
        var prm = Sys.WebForms.PageRequestManager.getInstance();

        prm.add_endRequest(function (sender, e) {

            var table = $('#ContentPlaceHolder1_grdAudit').DataTable({
                lengthMenu: [[-1, 5, 10], ["All", 5, 10]],
                bRetrieve: true,
                order: [],
            });
            table
.search('')
.columns().search('')
.draw();
        });
        $(function () {
            $.noConflict();
            var table = $('#ContentPlaceHolder1_grdAudit').DataTable({
                order: [],
                bLengthChange: true,
                lengthMenu: [[-1, 5, 10], ["All", 5, 10]],
                bFilter: true,
                'columnDefs': [{
                    'targets': [],
                    'orderable': false,
                }],
                bPaginate: true,
            });
            table
.search('')
.columns().search('')
.draw();
        });
    </script>
    <script>
        var prm = Sys.WebForms.PageRequestManager.getInstance();

        prm.add_endRequest(function (sender, e) {

            $('#ContentPlaceHolder1_grdExercise').dataTable({
                order: [],
                lengthMenu: [[-1, 5, 10], ["All", 5, 10]],
                columnDefs: [{ orderable: false, targets: [0] }],
                bRetrieve: true,
            });
        });
        $(function () {
            $('#ContentPlaceHolder1_grdExercise').DataTable({
                bLengthChange: true,
                lengthMenu: [[-1, 5, 10], ["All", 5, 10]],
                bFilter: true,
                order: [],
                columnDefs: [{ orderable: false, targets: [0] }],
                bPaginate: true,
            });
        });
    </script>
    <script>
        var prm = Sys.WebForms.PageRequestManager.getInstance();

        prm.add_endRequest(function (sender, e) {

            $('#ContentPlaceHolder1_grdSell').dataTable({
                order: [],
                lengthMenu: [[-1, 5, 10], ["All", 5, 10]],
                columnDefs: [{ orderable: false, targets: [0] }],
                bRetrieve: true,
            });
        });
        $(function () {
            $('#ContentPlaceHolder1_grdSell').DataTable({
                bLengthChange: true,
                lengthMenu: [[-1, 5, 10], ["All", 5, 10]],
                bFilter: true,
                order: [],
                columnDefs: [{ orderable: false, targets: [0] }],
                bPaginate: true,
            });
        });
    </script>
</asp:Content>


