﻿<%@ Page Title="" Language="C#" MasterPageFile="~/ESOP.Master" AutoEventWireup="true" CodeBehind="Admin_Workflow_Pending.aspx.cs" Inherits="ESOP.Admin_Workflow_Pending" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
        .hiddencol {
            display: none;
        }

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

    <script src="assets/js/jquery.dataTables-1.10.20.min.js"></script>
    <link href="Scripts/jquery.dataTables.min.css" rel="stylesheet" />
    <link href="Scripts/dataTables.bootstrap4.min.css" rel="stylesheet" />


    <script type="text/javascript">
        $(document).on('click', '[src*=plus]', function (e) {

            // $("[src*=plus]").live("click", function () {
            $(this).closest("tr").after("<tr><td></td><td colspan = '999'>" + $(this).next().html() + "</td></tr>")
            $(this).attr("src", "assets/img/minus.svg");

        });
        $(document).on('click', '[src*=minus]', function (e) {
            // $("[src*=minus]").live("click", function () {
            $(this).attr("src", "assets/img/plus.svg");

            $(this).closest("tr").next().remove();
        });

        $(document).ready(function () {
            debugger;
            $('.CloseBtnNew').click(function () {
                // alert('test');

                $("#myModal").removeClass("show");
                $("#myModal").hide();
                $(".modal-backdrop").remove();
                //$("#myModal").hide();
                $("body").removeClass("modal-open");
                // $("#myModal1").modal("hide");
            });

            //if ($('#hdnchild').val() != "") {
            //    var childs = $('#hdnchild').val().split(',');
            //    if (childs.length > 0) {
            //        for (var i = 0; i < childs.length; i++) {
            //            $("#ContentPlaceHolder1_grdMain").find('div#ContentPlaceHolder1_grdMain_pnlOrders_' + childs[i]).siblings('img').click();
            //        }
            //    }
            //}
        });
    </script>


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

    <%--    <script src="assets/js/jquery.dataTables-1.10.20.min.js"></script>
    <link href="Scripts/jquery.dataTables.min.css" rel="stylesheet" />
    <link href="Scripts/dataTables.bootstrap4.min.css" rel="stylesheet" />--%>


   

    <div class="main-content" style="padding-top: 55px; padding-left: 40px; padding-right: 10px;">
        <div style="font-weight: 500; display: none" runat="server" id="div">President Grant Approval Summary</div>
        <nav aria-label="breadcrumb">

            <ol class="breadcrumb">
                <li class="breadcrumb-item text-left"><a href="admin-dashboard.aspx">Home</a></li>
                <li class="breadcrumb-item"><a href="settings.aspx">Masters</a></li>
                <li class="breadcrumb-item active" aria-current="page">Pending Reports</li>
            </ol>
        </nav>
        <section class="section">
            <div class="row">
                <div class="col-12">
                    <div class="card" style="height: 100%;">
                        <div class="card-header">
                            <h4>Workflow</h4>
                        </div>
                        <div class="card-body">
                            <div class="row">
                                <div class="col-lg-2 col-md-12 col-sm-12 all">
                                    <div class="form-group">
                                        <%--<label>Workflow</label>--%>
                                        <asp:DropDownList CssClass="form-control" ID="ddlWorkflow" runat="server" ReadOnly="true" Width="86%">
                                            <asp:ListItem Value="0">Select</asp:ListItem>
                                            <asp:ListItem Value="1">Grant</asp:ListItem>
                                            <asp:ListItem Value="2">Vesting</asp:ListItem>
                                            <asp:ListItem Value="3">Exercise</asp:ListItem>
                                            <asp:ListItem Value="4">Sale</asp:ListItem>
                                        </asp:DropDownList>
                                    </div>
                                </div>

                                <div class="col-lg-2 col-md-12 col-sm-12 all">
                                    <asp:Button ID="btnFilter" runat="server" Text="Filter" Class="btn btn-info btn-lg all"
                                        OnClick="btnFilter_Click" />
                                    <%--<asp:ImageButton ID='btnexcelExport' runat='server' ImageUrl="~/img/excel1.png" Style="margin-left: 3px;" OnClick="btnexcelExport_Click" Height="35px" ToolTip="Export To Excel" />--%>
                                </div>
                            </div>

                            <div class="row">
                                <div class="col-lg-12" style="padding-top: 30px;">
                                    <asp:UpdatePanel ID="upd12" runat="server">
                                        <ContentTemplate>
                                                <%--<div class="table-responsive" style="margin-top: 30px;">
                                                    <asp:UpdatePanel ID="upd" runat="server" UpdateMode="Conditional">
                                                        <ContentTemplate>--%>
                                                            <asp:GridView ID="GrvGrant" runat="server" ShowHeaderWhenEmpty="false"
                                                                OnPreRender="GrvGrant_PreRender" EmptyDataText="No Records Found" AutoGenerateColumns="false"
                                                                class="table">
                                                                <Columns>
                                                                    <asp:BoundField DataField="ECODE" HeaderText="Employee ID" />
                                                                    <asp:BoundField DataField="EMP_NAME" HeaderText="Employee Name" />
                                                                    <asp:BoundField DataField="grant_name" HeaderText="Grant Name" />
                                                                    <asp:BoundField DataField="Date_of_Grant" HeaderText="Date of Grant" />
                                                                    <asp:BoundField DataField="APPRAISER_NAME" HeaderText="Manager Name" />
                                                                    <asp:BoundField DataField="NO_OF_OPTIONS" HeaderText="No. of Grants" />
                                                                    <asp:BoundField DataField="FMV_PRICE" HeaderText="Grant Price" />
                                                                    <asp:BoundField DataField="APPROVED_BY" HeaderText="Approved By" ItemStyle-CssClass="hiddencol" HeaderStyle-CssClass="hiddencol" />
                                                                    <asp:BoundField DataField="PENDING_WITH" HeaderText="Pending with" />
                                                                    <asp:BoundField DataField="Grant_ID" HeaderText="Grant ID" ItemStyle-CssClass="hiddencol" HeaderStyle-CssClass="hiddencol" />
                                                                </Columns>
                                                            </asp:GridView>
                                                        <%--</ContentTemplate>
                                                        <Triggers>
                                                            <asp:PostBackTrigger ControlID="GrvGrant" />
                                                        </Triggers>
                                                    </asp:UpdatePanel>
                                                </div>--%>


                                            <%--<div class="col-md-12 table-responsive" style="margin-bottom: 0; padding-top: 15px;">
                                                <asp:UpdatePanel ID="UpdatePanelMain" runat="server" UpdateMode="Conditional">
                                                    <ContentTemplate>--%>
                                                        <asp:GridView ID="grdMain" runat="server" AutoGenerateColumns="false" OnPreRender="grdMain_PreRender"
                                                            CssClass="table table-bordered simple-tree-table" DataKeyNames="ECODE" OnRowDataBound="grdMain_RowDataBound"
                                                            Style="border-collapse: separate;" EmptyDataText="" EmptyDataRowStyle-CssClass="Empty">
                                                            <Columns>
                                                                <asp:TemplateField HeaderStyle-Width="3%">
                                                                    <ItemTemplate>
                                                                        <img alt="" style="cursor: pointer" src="assets/img/plus.svg" height="25px" width="25px" />
                                                                        <asp:Panel ID="pnlOrders" runat="server" Style="display: none">
                                                                            <asp:GridView ID="GrvPendingforApproval" runat="server" ShowHeaderWhenEmpty="true" AutoGenerateColumns="False" PageSize="25"
                                                                                class="table" EmptyDataText="No Records Found" DataKeyNames="ecode" EnableViewState="false" OnPreRender="GrvPendingforApproval_PreRender">
                                                                                <Columns>
                                                                                    <asp:BoundField DataField="ECODE" HeaderText="Emp ID" />
                                                                                    <asp:BoundField DataField="EMP_NAME" HeaderText="Emp Name" />
                                                                                    <asp:BoundField DataField="GRANT_NAME" HeaderText="Tranch Name" />
                                                                                    <asp:BoundField DataField="Grant_Date" HeaderText="Grant Date" DataFormatString="{0:dd-M-yyyy}" />
                                                                                    <asp:BoundField DataField="VESTING_ID" HeaderText="Vest Code" />
                                                                                    <asp:BoundField DataField="percentage" HeaderText="Vest%" />
                                                                                    <asp:BoundField DataField="Vesting_Date" HeaderText="Vest Date" DataFormatString="{0:dd-M-yyyy}" />
                                                                                    <asp:BoundField DataField="no_of_vesting" HeaderText="No. of Opt" />
                                                                                    <asp:BoundField DataField="Tranch_Vesting" HeaderText="Tranch Vest" />
                                                                                    <asp:BoundField HeaderText="Approver" DataField="Approved_By" SortExpression="Approved_By" ItemStyle-CssClass="hiddencol" HeaderStyle-CssClass="hiddencol" />
                                                                                    <asp:BoundField HeaderText="Approved Date" DataField="UPDATATION_DATE" SortExpression="UPDATATION_DATE" ItemStyle-CssClass="hiddencol" HeaderStyle-CssClass="hiddencol" />
                                                                                    <asp:BoundField HeaderText="Pending with" DataField="PENDING_WITH" SortExpression="PENDING_WITH" />
                                                                                </Columns>
                                                                            </asp:GridView>
                                                                        </asp:Panel>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                                <asp:BoundField DataField="ecode" HeaderText="Employee Code" HeaderStyle-Width="10%" />
                                                                <asp:BoundField DataField="emp_name" HeaderText="Employee Name" HeaderStyle-Width="12%" />
                                                                <asp:BoundField DataField="NO_OF_VESTING" HeaderText="Total No Of Esop" HeaderStyle-Width="12%" />
                                                            </Columns>
                                                        </asp:GridView>
                                                    <%--</ContentTemplate>
                                                    <Triggers>
                                                        <asp:PostBackTrigger ControlID="grdMain" />
                                                    </Triggers>
                                                </asp:UpdatePanel>
                                            </div>--%>





                                            <asp:GridView ID="grdmain_1" runat="server" AutoGenerateColumns="false" OnPreRender="grdmain_1_PreRender"
                                                CssClass="table table-bordered simple-tree-table" DataKeyNames="ECODE" OnRowDataBound="GrvPFADB"
                                                Style="border-collapse: separate;" EmptyDataText="" EmptyDataRowStyle-CssClass="Empty">
                                                <Columns>
                                                    <asp:TemplateField HeaderStyle-Width="3%">
                                                        <ItemTemplate>
                                                            <img alt="" style="cursor: pointer" src="assets/img/plus.svg" height="25px" width="25px" />
                                                            <asp:Panel ID="pnlOrders" runat="server" Style="display: none">
                                                                <asp:GridView ID="GrvPendingforApproval" runat="server" ShowHeaderWhenEmpty="true" AutoGenerateColumns="False" PageSize="25"
                                                                    class="table" EmptyDataText="No Records Found" DataKeyNames="EETDID,GRANT_ID,EXERCISE_TRAN_ID,vesting_detail_id,ecode" EnableViewState="false">
                                                                    <Columns>
                                                                        <asp:BoundField DataField="ecode" HeaderText="Employee Code" HeaderStyle-Width="9%" />
                                                                        <asp:BoundField DataField="emp_name" HeaderText="Employee Name" HeaderStyle-Width="10%" />
                                                                        <asp:BoundField DataField="GRANT_NAME" HeaderText="ESOP Code" />
                                                                        <asp:BoundField DataField="createddate" HeaderText="Exercise Date" DataFormatString="{0:dd-MMM-yyyy}" HeaderStyle-Width="8%" />
                                                                        <asp:BoundField DataField="VESTING_DATE" HeaderText="Vesting Date" DataFormatString="{0:dd-MMM-yyyy}" HeaderStyle-Width="9%" />
                                                                        <asp:BoundField DataField="grant_price" HeaderText="Grant Price" HeaderStyle-Width="7%" />
                                                                        <asp:BoundField DataField="GRANT_FMV_PRICE" HeaderText="Excer FMV Price" HeaderStyle-Width="5%" />
                                                                        <%--<asp:BoundField DataField="option_exercise" HeaderText="Options Exercised" HeaderStyle-Width="10%" />--%>
                                                                        <asp:BoundField DataField="no_of_exercise" HeaderText="No of Options Exercised" HeaderStyle-Width="10%" />
                                                                        <asp:BoundField DataField="NO_OF_VESTING" HeaderText="Total No of Options" HeaderStyle-Width="10%" />
                                                                        <asp:BoundField DataField="total_amount" HeaderText="Total Amount Payable" HeaderStyle-Width="10%" />
                                                                        <asp:BoundField DataField="dpid" HeaderText="DP ID" HeaderStyle-Width="7%" />
                                                                        <asp:BoundField DataField="client_id" HeaderText="Client ID" HeaderStyle-Width="7%" />
                                                                        <asp:BoundField DataField="member_type" HeaderText="Member Type" HeaderStyle-Width="8%" />
                                                                        <asp:BoundField DataField="Pending_with" HeaderText="Pending with" HeaderStyle-Width="8%" />
                                                                    </Columns>
                                                                </asp:GridView>
                                                            </asp:Panel>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:BoundField DataField="ecode" HeaderText="Employee Code" HeaderStyle-Width="10%" />
                                                    <asp:BoundField DataField="emp_name" HeaderText="Employee Name" HeaderStyle-Width="12%" />
                                                    <asp:BoundField DataField="Total No Of Esop" HeaderText="Total No Of Esop" HeaderStyle-Width="12%" />
                                                </Columns>
                                            </asp:GridView>




                                            <asp:GridView ID="grdMain2" runat="server" AutoGenerateColumns="false" OnPreRender="grdMain2_PreRender"
                                                CssClass="table table-bordered simple-tree-table treetablecss" DataKeyNames="ECODE,SALE_OFFER_FILE_PATH,SALE_DECLARATION_FILE_PATH,SALE_TRANSACTION_RECEIPT_FILE_PATH" OnRowDataBound="GrvPFADB_2"
                                                Style="border-collapse: separate;" EmptyDataText="" EmptyDataRowStyle-CssClass="Empty">
                                                <Columns>
                                                    <asp:TemplateField HeaderStyle-Width="3%">
                                                        <ItemTemplate>
                                                            <img alt="" style="cursor: pointer" src="assets/img/plus.svg" height="25px" width="25px" />
                                                            <asp:UpdatePanel ID="updpnl1" runat="server" Style="display: none">
                                                                <ContentTemplate>
                                                                    <asp:GridView ID="GrvPendingforApproval_2" runat="server" ShowHeaderWhenEmpty="true" AutoGenerateColumns="False" PageSize="10"
                                                                        class="table" EmptyDataText="No Records Found" DataKeyNames="ID,vesting_detail_id,sale_tran_id,ecode">
                                                                        <Columns>

                                                                            <asp:BoundField DataField="ecode" HeaderText="Employee Code" HeaderStyle-Width="10%" SortExpression="ecode" />
                                                                            <asp:BoundField DataField="emp_name" HeaderText="Employee Name" HeaderStyle-Width="12%" SortExpression="emp_name" />
                                                                            <asp:TemplateField HeaderText="ESOP Code" HeaderStyle-Width="15%">
                                                                                <ItemTemplate>
                                                                                    <asp:Label ID="lblTranchVesting" runat="server" Text='<%# Eval("Tranch_Vesting") %>'></asp:Label>
                                                                                    </div>
                                                                                </ItemTemplate>
                                                                            </asp:TemplateField>
                                                                            <asp:TemplateField HeaderText="Vesting Date" HeaderStyle-Width="15%">
                                                                                <ItemTemplate>
                                                                                    <asp:Label ID="lblVESTING_DATE" runat="server" Text='<%# Eval("VESTING_DATE") %>'></asp:Label>
                                                                                    </div>
                                                                                </ItemTemplate>
                                                                            </asp:TemplateField>
                                                                            <asp:TemplateField HeaderText="Sale Date" HeaderStyle-Width="15%">
                                                                                <ItemTemplate>
                                                                                    <asp:Label ID="lblSale_Date" runat="server" Text='<%# Eval("Sale_Date") %>'></asp:Label>
                                                                                    </div>
                                                                                </ItemTemplate>
                                                                            </asp:TemplateField>
                                                                            <asp:TemplateField HeaderText="Grant Price" HeaderStyle-Width="10%">
                                                                                <ItemTemplate>
                                                                                    <asp:Label ID="lblGrantPrice" runat="server" Text='<%# Eval("GRANT_PRICE") %>'></asp:Label>
                                                                                    </div>
                                                                                </ItemTemplate>
                                                                            </asp:TemplateField>
                                                                            <asp:TemplateField HeaderText="Sale FMV" HeaderStyle-Width="10%">
                                                                                <ItemTemplate>
                                                                                    <asp:Label ID="lblFMVSale" runat="server" Text='<%# Eval("sale_fmv_price") %>'></asp:Label>
                                                                                    </div>
                                                                                </ItemTemplate>
                                                                            </asp:TemplateField>
                                                                            <asp:TemplateField HeaderText="No of Excerise" HeaderStyle-Width="10%">
                                                                                <ItemTemplate>
                                                                                    <asp:Label ID="lblExcericse" runat="server" Text='<%# Eval("NO_OF_Exercise") %>'></asp:Label>
                                                                                    </div>
                                                                                </ItemTemplate>
                                                                            </asp:TemplateField>
                                                                            <asp:TemplateField HeaderText="No of Sale" HeaderStyle-Width="15%">
                                                                                <ItemTemplate>
                                                                                    <asp:Label ID="lblOptions" runat="server" Text='<%# Eval("no_of_sale") %>'></asp:Label>
                                                                                    </div>
                                                                                </ItemTemplate>
                                                                            </asp:TemplateField>
                                                                            <asp:TemplateField HeaderText="Amount" HeaderStyle-Width="15%">
                                                                                <ItemTemplate>
                                                                                    <asp:Label ID="lblAmount" runat="server" Text='<%# Eval("Amount") %>'></asp:Label>
                                                                                </ItemTemplate>
                                                                            </asp:TemplateField>
                                                                            <asp:BoundField DataField="dpid" HeaderText="DP ID" HeaderStyle-Width="5%" />
                                                                            <asp:BoundField DataField="client_id" HeaderText="Client ID" HeaderStyle-Width="5%" />
                                                                            <asp:BoundField DataField="member_type" HeaderText="Member Type" HeaderStyle-Width="8%" />
                                                                            <asp:BoundField DataField="Pending_with" HeaderText="Pending With" HeaderStyle-Width="8%" />

                                                                        </Columns>
                                                                    </asp:GridView>
                                                                </ContentTemplate>
                                                            </asp:UpdatePanel>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:BoundField DataField="ecode" HeaderText="Employee Code" HeaderStyle-Width="10%" />
                                                    <asp:BoundField DataField="emp_name" HeaderText="Employee Name" HeaderStyle-Width="12%" />
                                                    <asp:BoundField DataField="Total_No_Of_Sale" HeaderText="Total No Of Sale" HeaderStyle-Width="12%" />
                                                    <asp:TemplateField HeaderText="SALE_OFFER_FILE_PATH" HeaderStyle-Width="10%">
                                                        <HeaderStyle CssClass="hiddencol" />
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblSALE_OFFER_FILE_PATH" runat="server" Text='<%# Eval("SALE_OFFER_FILE_PATH") %>'></asp:Label>
                                                            </div>
                                                        </ItemTemplate>
                                                        <ItemStyle HorizontalAlign="Right" CssClass="hiddencol" />
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="SALE_DECLARATION_FILE_PATH" HeaderStyle-Width="10%">
                                                        <HeaderStyle CssClass="hiddencol" />
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblSALE_DECLARATION_FILE_PATH" runat="server" Text='<%# Eval("SALE_DECLARATION_FILE_PATH") %>'></asp:Label>
                                                            </div>
                                                        </ItemTemplate>
                                                        <ItemStyle HorizontalAlign="Right" CssClass="hiddencol" />
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="SALE_TRANSACTION_RECEIPT_FILE_PATH" HeaderStyle-Width="10%">
                                                        <HeaderStyle CssClass="hiddencol" />
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblSALE_TRANSACTION_RECEIPT_FILE_PATH" runat="server" Text='<%# Eval("SALE_TRANSACTION_RECEIPT_FILE_PATH") %>'></asp:Label>
                                                            </div>
                                                        </ItemTemplate>
                                                        <ItemStyle HorizontalAlign="Right" CssClass="hiddencol" />
                                                    </asp:TemplateField>
                                                </Columns>
                                            </asp:GridView>

                                        </ContentTemplate>
                                        <Triggers>
                                            <%--<asp:PostBackTrigger ControlID="btnFilter" />
                                            <asp:PostBackTrigger ControlID="btnClearFilter" />
                                            <asp:PostBackTrigger ControlID="btnexcelExport" />
                                            <asp:PostBackTrigger ControlID="btnpdfexport" />--%>
                                        </Triggers>
                                    </asp:UpdatePanel>
                                </div>
                            </div>

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
     <script>
        ////$(document).ready(function () {
        ////    var table = $('#ContentPlaceHolder1_GrvGrant').DataTable({
        ////        "aaSorting": [[3, "desc"]]
        ////    });
        ////});

        //$('#ContentPlaceHolder1_GrvGrant').clear().draw();
        $(function () {
            var prm = Sys.WebForms.PageRequestManager.getInstance();

            prm.add_endRequest(function (sender, e) {

                $('#ContentPlaceHolder1_GrvGrant').dataTable({
                    lengthMenu: [[-1, 5, 10], ["All", 5, 10]],
                    bRetrieve: true,

                });

            });
        });
        $(function () {

            $("#ContentPlaceHolder1_GrvGrant").DataTable({
                bLengthChange: true,
                lengthMenu: [[-1, 5, 10], ["All", 5, 10]],
                bFilter: true,
                'columnDefs': [{
                    'targets': [],
                    'orderable': false,
                }],
                //bSort:true,
                bPaginate: true,
                "aaSorting": [[2, "desc"]]
            });
        });

        $(function () {
            var prm = Sys.WebForms.PageRequestManager.getInstance();

            prm.add_endRequest(function (sender, e) {

                $('#ContentPlaceHolder1_grdMain').dataTable({
                    lengthMenu: [[-1, 5, 10], ["All", 5, 10]],
                    columnDefs: [{ orderable: false, targets: [0] }],
                    bRetrieve: true,

                });

            });
        });
        $(function () {

            $("#ContentPlaceHolder1_grdMain").DataTable({
                bLengthChange: true,
                lengthMenu: [[-1, 5, 10], ["All", 5, 10]],
                bFilter: true,
                'columnDefs': [{
                    'targets': [],
                    'orderable': false,
                }],
                //bSort:true,
                bPaginate: true,
                "aaSorting": [[1, "desc"]],
                columnDefs: [{ orderable: false, targets: [0] }],

            });
        });

        $(function () {
            var prm = Sys.WebForms.PageRequestManager.getInstance();

            prm.add_endRequest(function (sender, e) {

                $('#ContentPlaceHolder1_grdmain_1').dataTable({
                    lengthMenu: [[-1, 5, 10], ["All", 5, 10]],
                    columnDefs: [{ orderable: false, targets: [0] }],
                    bRetrieve: true,

                });

            });
        });
        $(function () {

            $("#ContentPlaceHolder1_grdmain_1").DataTable({
                bLengthChange: true,
                lengthMenu: [[-1, 5, 10], ["All", 5, 10]],
                bFilter: true,
                'columnDefs': [{
                    'targets': [],
                    'orderable': false,
                }],
                //bSort:true,
                bPaginate: true,
                "aaSorting": [[1, "desc"]],
                columnDefs: [{ orderable: false, targets: [0] }],
            });
        });


        $(function () {
            var prm = Sys.WebForms.PageRequestManager.getInstance();

            prm.add_endRequest(function (sender, e) {

                $('#ContentPlaceHolder1_grdMain2').dataTable({
                    lengthMenu: [[-1, 5, 10], ["All", 5, 10]],
                    bRetrieve: true,

                });

            });
        });
        $(function () {

            $("#ContentPlaceHolder1_grdMain2").DataTable({
                bLengthChange: true,
                lengthMenu: [[-1, 5, 10], ["All", 5, 10]],
                bFilter: true,
                'columnDefs': [{
                    'targets': [],
                    'orderable': false,
                }],
                //bSort:true,
                bPaginate: true,
                "aaSorting": [[1, "desc"]]
            });
        });
    </script>




</asp:Content>
