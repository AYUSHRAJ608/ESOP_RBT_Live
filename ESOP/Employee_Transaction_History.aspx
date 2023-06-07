<%@ Page Title="" Language="C#" MasterPageFile="~/ESOP.Master" AutoEventWireup="true" CodeBehind="Employee_Transaction_History.aspx.cs" Inherits="ESOP.Employee_Transaction_History" %>

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

    </script>

    <script type="text/javascript">
        $(document).ready(function () {

            $('.CloseBtnNew').click(function () {
                $("#my_Exercise_Modal").removeClass("show");
                $("#my_Exercise_Modal").hide();

                $("#my_Sale_Modal").removeClass("show");
                $("#my_Sale_Modal").hide();

                $(".modal-backdrop").remove();
                $("body").removeClass("modal-open");
            });
        })
    </script>

    <div class="main-content" style="padding-top: 55px; padding-left: 40px; padding-right: 10px;">
        <div style="font-weight: 500; display: none" runat="server" id="div">President Grant Approval Summary</div>
        <nav aria-label="breadcrumb">

            <ol class="breadcrumb">
                <li class="breadcrumb-item text-left"><a href="employee-dashboard.aspx">Home</a></li>
                <li class="breadcrumb-item active" aria-current="page">Transaction History</li>
            </ol>
        </nav>

        <section class="section">
            <div class="row">
                <div class="col-12">
                    <div class="card" style="height: 100%;">
                        <div class="card-header">
                            <h4>Transaction History</h4>
                        </div>
                        <div class="card-body">
                            <div class="row">
                                <div class="col-lg-2 col-md-12 col-sm-12 all">
                                    <div class="form-group">
                                        <%--<label>Workflow</label>--%>
                                        <asp:DropDownList CssClass="form-control" ID="ddlWorkflow" runat="server" ReadOnly="true" Width="86%">
                                            <asp:ListItem Value="0">Select</asp:ListItem>
                                            <asp:ListItem Value="3">Exercise</asp:ListItem>
                                            <asp:ListItem Value="4">Sale</asp:ListItem>
                                        </asp:DropDownList>
                                    </div>
                                </div>

                                <div class="col-lg-2 col-md-12 col-sm-12 all">
                                    <asp:Button ID="btnFilter" runat="server" Text="Filter" Class="btn btn-info btn-lg all"
                                        OnClick="btnFilter_Click" />
                                </div>
                            </div>

                            <asp:GridView ID="grdmain_1" runat="server" AutoGenerateColumns="false" OnPreRender="grdmain_1_PreRender"
                                CssClass="table table-bordered simple-tree-table" DataKeyNames="ECODE" OnRowDataBound="GrvPFADB"
                                Style="border-collapse: separate;" EmptyDataText="" EmptyDataRowStyle-CssClass="Empty">
                                <Columns>
                                    <asp:TemplateField HeaderStyle-Width="3%">
                                        <ItemTemplate>
                                            <img alt="" style="cursor: pointer" src="assets/img/plus.svg" height="25px" width="25px" />
                                            <asp:Panel ID="Panel1" runat="server" Style="display: none">
                                                <asp:GridView ID="grdmain_1_Child" runat="server" ShowHeaderWhenEmpty="true" AutoGenerateColumns="False" PageSize="25"
                                                    class="table" EmptyDataText="No Records Found" DataKeyNames="EETDID,GRANT_ID,EXERCISE_TRAN_ID,vesting_detail_id,ecode" OnRowCommand="grdmain_1_Child_RowCommand">
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
                                                        <asp:TemplateField HeaderText="Audit Trail" HeaderStyle-Width="2%">
                                                            <ItemTemplate>
                                                                <asp:LinkButton ID="LinkButton2" runat="server" CommandName="Audit" CausesValidation="true"
                                                                    CommandArgument="<%# ((GridViewRow) Container).RowIndex %>"
                                                                    CssClass="fas fa-info edit12"></asp:LinkButton>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
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
                                CssClass="table table-bordered simple-tree-table treetablecss" DataKeyNames="ECODE" OnRowDataBound="GrvPFADB_2"
                                Style="border-collapse: separate;" EmptyDataText="" EmptyDataRowStyle-CssClass="Empty">
                                <Columns>
                                    <asp:TemplateField HeaderStyle-Width="3%">
                                        <ItemTemplate>
                                            <img alt="" style="cursor: pointer" src="assets/img/plus.svg" height="25px" width="25px" />
                                            <asp:UpdatePanel ID="UpdatePanel2" runat="server" Style="display: none">
                                                <ContentTemplate>
                                                    <asp:GridView ID="GrvPendingforApproval_2" runat="server" ShowHeaderWhenEmpty="true" AutoGenerateColumns="False" PageSize="10"
                                                        class="table" EmptyDataText="No Records Found" DataKeyNames="ID,vesting_detail_id,sale_tran_id,ecode" OnRowCommand="GrvPendingforApproval_2_RowCommand">
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
                                                            <asp:TemplateField HeaderText="Audit Trail" HeaderStyle-Width="2%">
                                                                <ItemTemplate>
                                                                    <asp:LinkButton ID="LinkButton3" runat="server" CommandName="Audit" CausesValidation="true"
                                                                        CommandArgument="<%# ((GridViewRow) Container).RowIndex %>"
                                                                        CssClass="fas fa-info edit12"></asp:LinkButton>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                        </Columns>
                                                    </asp:GridView>
                                                </ContentTemplate>
                                            </asp:UpdatePanel>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:BoundField DataField="ecode" HeaderText="Employee Code" HeaderStyle-Width="10%" />
                                    <asp:BoundField DataField="emp_name" HeaderText="Employee Name" HeaderStyle-Width="12%" />
                                    <asp:BoundField DataField="Total_No_Of_Sale" HeaderText="Total No Of Sale" HeaderStyle-Width="12%" />

                                </Columns>
                            </asp:GridView>


                        </div>

                    </div>
                </div>
            </div>
        </section>
        <div class="modal bd-example-modal-lg" id="my_Exercise_Modal" tabindex="-1" role="dialog">
            <div class="modal-dialog modal-xl boxModalDiv">
                <!-- Modal content-->
                <div class="modal-content" style="width: 100%;">
                    <div class="modal-header">
                        <h5 class="modal-title" id="myLargeModalLabel">Audit Trail
                        <button type="button" class="close" data-dismiss="modal">×</button>
                        </h5>
                    </div>

                    <div class="card-body">
                        <div class="table-responsive">
                            <asp:UpdatePanel ID="UpdatePanel4" runat="server">
                                <ContentTemplate>
                                    <asp:GridView ID="grdData_2" class="table" runat="server" Style="width: 98%;"
                                        AutoGenerateColumns="False" AllowPaging="false" PageSize="10" AllowSorting="false" OnPageIndexChanging="grdData_2_PageIndexChanging"
                                        EmptyDataText="No data found" AllowCustomPaging="false" ViewStateMode="Enabled">
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
                                            <asp:BoundField DataField="Remark" HeaderText="Remark" HeaderStyle-Width="8%" />
                                            <asp:BoundField DataField="created_date" HeaderText="created_date" HeaderStyle-Width="8%" />
                                            <asp:BoundField DataField="MODIFIEDDATE" HeaderText="Modified Date" HeaderStyle-Width="8%" />
                                            <asp:BoundField DataField="status" HeaderText="status" HeaderStyle-Width="8%" />

                                        </Columns>
                                        <PagerSettings FirstPageText="First" LastPageText="Last" NextPageText="Next" PreviousPageText="Previous" />

                                        <%--<PagerStyle CssClass="text-right border-pagination" />--%>
                                    </asp:GridView>
                                    <%--<div class="clearfix"></div>--%>
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

        <div class="modal bd-example-modal-lg" id="my_Sale_Modal" tabindex="-1" role="dialog">
            <div class="modal-dialog modal-xl boxModalDiv">
                <!-- Modal content-->
                <div class="modal-content" style="width: 100%;">
                    <div class="modal-header">
                        <h5 class="modal-title" id="myLargeModalLabel">Audit Trail
                        <button type="button" class="close" data-dismiss="modal">×</button>
                        </h5>
                    </div>

                    <div class="card-body">
                        <div class="table-responsive">
                            <asp:UpdatePanel ID="UpdatePanel5" runat="server">
                                <ContentTemplate>
                                    <asp:GridView ID="grdData_3" class="table" runat="server" Style="width: 98%;"
                                        AutoGenerateColumns="False" AllowPaging="false" PageSize="10" AllowSorting="false" OnPageIndexChanging="grdData_2_PageIndexChanging"
                                        EmptyDataText="No data found" AllowCustomPaging="false" ViewStateMode="Enabled">
                                        <Columns>
                                            <asp:BoundField DataField="ecode" HeaderText="Employee Code" HeaderStyle-Width="10%" SortExpression="ecode" />
                                            <asp:BoundField DataField="emp_name" HeaderText="Employee Name" HeaderStyle-Width="12%" SortExpression="emp_name" />
                                            <asp:BoundField DataField="Tranch_Vesting" HeaderText="ESOP Code" HeaderStyle-Width="9%" />
                                            <asp:BoundField DataField="VESTING_DATE" HeaderText="Vesting Date" HeaderStyle-Width="9%" />
                                            <asp:BoundField DataField="Sale_Date" HeaderText="Sale Date" HeaderStyle-Width="9%" />
                                            <asp:BoundField DataField="GRANT_PRICE" HeaderText="Grant Price" HeaderStyle-Width="9%" />
                                            <asp:BoundField DataField="sale_fmv_price" HeaderText="Sale FMV" HeaderStyle-Width="9%" />
                                            <asp:BoundField DataField="NO_OF_Exercise" HeaderText="No of Excerise" HeaderStyle-Width="9%" />
                                            <asp:BoundField DataField="no_of_sale" HeaderText="No of Sale" HeaderStyle-Width="9%" />
                                            <asp:BoundField DataField="Amount" HeaderText="Amount" HeaderStyle-Width="9%" />
                                            <asp:BoundField DataField="dpid" HeaderText="DP ID" HeaderStyle-Width="5%" />
                                            <asp:BoundField DataField="client_id" HeaderText="Client ID" HeaderStyle-Width="5%" />
                                            <asp:BoundField DataField="member_type" HeaderText="Member Type" HeaderStyle-Width="8%" />
                                            <asp:BoundField DataField="createddate" HeaderText="Sale Date" DataFormatString="{0:dd-MMM-yyyy}" HeaderStyle-Width="8%" />
                                            <asp:BoundField DataField="MODIFIEDDATE" HeaderText="Modified Date" DataFormatString="{0:dd-MMM-yyyy}" HeaderStyle-Width="8%" />
                                            <asp:BoundField DataField="status" HeaderText="status" HeaderStyle-Width="8%" />

                                        </Columns>
                                        <PagerSettings FirstPageText="First" LastPageText="Last" NextPageText="Next" PreviousPageText="Previous" />

                                        <%--<PagerStyle CssClass="text-right border-pagination" />--%>
                                    </asp:GridView>
                                    <%--<div class="clearfix"></div>--%>
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
    
    <script>

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
    

    <script src="Scripts/bootstrap.min.js"></script>
    <script src="assets/js/app.min.js"></script>
    <script src="assets/js/scripts.js"></script>

    <script type="text/javascript">
        function openModalShowExerciseAudit() {
            $('#my_Exercise_Modal').modal('show');
        }
    </script>
    <script type="text/javascript">
        function openModalShowSaleAudit() {
            $('#my_Sale_Modal').modal('show');
        }
    </script>

</asp:Content>
