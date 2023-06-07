<%@ Page Language="C#" MasterPageFile="~/ESOP.Master" AutoEventWireup="true" EnableEventValidation="false" CodeBehind="SharedReport.aspx.cs" Inherits="ESOP.SharedReport" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

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

        .optiongroup1 {
            font-weight: bold;
            font-size: 14px;
            /*font-style:italic;*/
        }

        .optionchild1 {
            font-size: 12px;
        }

        .cancel {
            vertical-align: middle;
            background-color: green;
        }

        .update {
            background-color: blue;
        }

        .cancel:before {
            content: "\f00d";
            color: #fff;
            font-size: 16px;
            margin-left: 0;
            position: absolute;
            top: auto;
            left: auto;
        }

        .hideGridColumn {
            display: none;
        }

        .shadow_none {
            box-shadow: none !important;
        }
    </style>



    <script src="assets/js/jquery-1.8.3.min.js"></script>
    <script src="assets/js/jquery.dataTables-1.10.20.min.js"></script>
    <link href="Scripts/jquery.dataTables.min.css" rel="stylesheet" />
    <link href="Scripts/dataTables.bootstrap4.min.css" rel="stylesheet" />
    <script type="text/javascript">
        $(document).ready(function () {

            $('.CloseBtnNew').click(function () {
                // alert('test');

                $("#myModal").removeClass("show");
                $("#myModal").hide();
                $("#my_ReportModel").removeClass("show");
                $("#my_ReportModel").hide();
                $(".modal-backdrop").remove();
                //$("#myModal").hide();
                $("body").removeClass("modal-open");
                // $("#myModal1").modal("hide");
            });
        })
    </script>

    <script type="text/javascript">
        var prm = Sys.WebForms.PageRequestManager.getInstance();
        prm.add_endRequest(function (sender, e) {
            var table = $('#ContentPlaceHolder1_grdReports').DataTable({
                lengthMenu: [[-1, 5, 10], ["All", 5, 10]],
                columnDefs: [{ orderable: false, targets: [4, 5] }],
                "bStateSave": true,
                bRetrieve: true, fixedHeader: true, "scrollX": true
            });
            //        table
            //.search('')
            //.columns().search('')
            //.draw();
        });

        $(function () {
            $.noConflict();

            var table = $("#ContentPlaceHolder1_grdReports").DataTable({
                bLengthChange: true,
                lengthMenu: [[-1, 5, 10], ["All", 5, 10]],
                bFilter: true,
                'columnDefs': [{
                    'targets': [4, 5],
                    'orderable': false,
                }],
                order: [],
                bPaginate: true,
                bSort: true,
                "bStateSave": true, fixedHeader: true, "scrollX": true
            });
            table
          .search('')
          .columns().search('')
          .draw();
        });
    </script>


    <script type="text/javascript">
        var prm = Sys.WebForms.PageRequestManager.getInstance();
        prm.add_endRequest(function (sender, e) {
            $('#ContentPlaceHolder1_Grid_ShowReport').dataTable({
                lengthMenu: [[-1, 5, 10], ["All", 5, 10]],
                bRetrieve: true, fixedHeader: true, "scrollX": true
            });

        });
        $(function () {
            $("#ContentPlaceHolder1_Grid_ShowReport").DataTable({
                bLengthChange: true,
                lengthMenu: [[-1, 5, 10], ["All", 5, 10]],
                bFilter: true,
                order: [],
                bPaginate: true,
                bSort: true,
                fixedHeader: true, "scrollX": true
            });
        });
    </script>

    <asp:ScriptManager ID="script" runat="server"></asp:ScriptManager>
    <div class="main-content">
        <nav aria-label="breadcrumb">
            <ol class="breadcrumb">
                <li class="breadcrumb-item"><a href="Admin_Exercise_Cancel.aspx">Home</a></li>
                <li class="breadcrumb-item active" aria-current="page">Shared Report</li>
            </ol>
        </nav>
        <section class="section">
            <div class="col-lg-12 col-md-12 col-12 col-sm-12">
                <div class="card" style="height: auto;">
                    <div class="card-header">
                        <h4>Shared Reports</h4>
                    </div>
                    <div class="card-body">
                        <div class="table-responsive">
                            <%-- <asp:UpdatePanel ID="upd" runat="server" UpdateMode="Conditional" class="table dataTable no-footer" aria-describedby="table-2_info">
                                <ContentTemplate>--%>
                            <asp:GridView ID="grdReports" class="table" runat="server"
                                AutoGenerateColumns="False" EmptyDataText="No data found"
                                Width="100%" OnPreRender="grdReports_PreRender" OnRowDataBound="grdReports_RowDataBound" DataKeyNames="rpt_id">
                                <Columns>
                                    <asp:BoundField DataField="Domain" HeaderText="Domain" HeaderStyle-Font-Bold="true">
                                        <ItemStyle HorizontalAlign="Left" VerticalAlign="Top" Wrap="True" />
                                    </asp:BoundField>

                                    <asp:BoundField DataField="Report_Name" HeaderText="Report Name" HeaderStyle-Font-Bold="true">
                                        <ItemStyle HorizontalAlign="Left" VerticalAlign="Top" Wrap="True" />
                                    </asp:BoundField>

                                    <asp:BoundField DataField="Description" HeaderText="Description" HeaderStyle-Font-Bold="true">
                                        <ItemStyle HorizontalAlign="Left" VerticalAlign="Top" Wrap="True" />
                                    </asp:BoundField>

                                    <asp:TemplateField HeaderText="query" HeaderStyle-Font-Bold="true" HeaderStyle-CssClass="hideGridColumn" ItemStyle-CssClass="hideGridColumn">
                                        <ItemTemplate>
                                            <asp:Label runat="server" ID="lblquery" Text='<%#Eval("query") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>

                                    <asp:TemplateField HeaderText="View" HeaderStyle-Font-Bold="true">
                                        <ItemStyle HorizontalAlign="Left" CssClass="text-center" VerticalAlign="Top" Wrap="True" />
                                        <ItemTemplate>
                                            <asp:LinkButton ID="lnkView" runat="server" OnClick="lnkView_Click">
                                        <img runat="server" src="~/img/eye.png" width="27" class="shadow-none" />
                                            </asp:LinkButton>
                                        </ItemTemplate>
                                    </asp:TemplateField>

                                    <asp:TemplateField HeaderText="Download" HeaderStyle-Font-Bold="true">
                                        <ItemStyle HorizontalAlign="Left" CssClass="text-center" VerticalAlign="Top" Wrap="True" />
                                        <ItemTemplate>
                                            <asp:LinkButton ID="lnkExcel" runat="server" OnClick="lnkExcel_Click">
                                        <img runat="server" src="~/img/excel1.png" width="27" class="shadow-none" />
                                            </asp:LinkButton>
                                            <asp:LinkButton ID="lnkCSV" runat="server" OnClick="lnkCSV_Click">
                                        <img runat="server" src="~/img/csv.png" width="27"  class="shadow-none"/>
                                            </asp:LinkButton>
                                            <asp:LinkButton ID="lnkPDF" runat="server" OnClick="lnkPDF_Click">
                                        <img runat="server" src="~/img/pdf.png" width="27" class="shadow-none" />
                                            </asp:LinkButton>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                </Columns>
                            </asp:GridView>
                            <%--</ContentTemplate>
                            </asp:UpdatePanel>--%>
                        </div>
                    </div>
                </div>
            </div>
        </section>

        <div class="modal bd-example-modal-lg" id="my_ReportModel" tabindex="-1" role="dialog">
            <div class="modal-dialog modal-xl boxModalDiv">
                <!-- Modal content-->
                <div class="modal-content" style="width: 100%;">
                    <div class="modal-header">
                        <h5 class="modal-title" id="myLargeModalLabel">Report Data
                        </h5>
                    </div>
                    <div class="col-lg-3 offset-md-3" style="padding-top: 12px; margin-left: 88%;">
                    </div>
                    <div class="card-body">
                        <div class="table-responsive">
                            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                                <ContentTemplate>
                                    <asp:GridView ID="Grid_ShowReport" class="table table-striped table-hover" runat="server" AutoGenerateColumns="False" EmptyDataText="No data found" Width="100%" OnPreRender="Grid_ShowReport_PreRender">
                                        <Columns>
                                        </Columns>
                                    </asp:GridView>
                                </ContentTemplate>
                            </asp:UpdatePanel>
                        </div>
                    </div>
                    <div class="modal-footer bg-whitesmoke br">
                        <div class="btn-group" role="group" aria-label="Basic example">
                            <a href="#" class="btn btn-info btn-lg all CloseBtnNew" data-dismiss="modal">Close</a>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <script src="Scripts/bootstrap.min.js"></script>
    <script src="assets/js/app.min.js"></script>
    <script src="assets/js/scripts.js"></script>
    <script type="text/javascript">
        function openModalShowAudit() {
            debugger;
            $('#my_ReportModel').modal('show');
        }
    </script>

    <style>
        .modal-backdrop.in {
            display: block;
        }

        .modal-backdrop {
            background-color: #0003;
        }

        .modalClose {
            color: #fff;
            margin: 0 !important;
            padding: 0 !important;
            top: -4px;
            position: relative;
            display: inline-block;
            opacity: 1;
            font-size: 28px;
        }

            .modalClose:hover {
                color: #fff;
            }

        .boxModalDiv {
            box-shadow: 0 4px 15px rgba(0, 0, 0, .2);
            margin-left: auto;
            margin-right: auto;
        }
    </style>
</asp:Content>
