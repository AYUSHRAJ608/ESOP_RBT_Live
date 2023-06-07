<%@ Page Title="" Language="C#" MasterPageFile="~/ESOP.Master" AutoEventWireup="true" CodeBehind="Secretarial_Sell_Aapprove_Reject.aspx.cs" Inherits="ESOP.Secretarial_Sell_Aapprove_Reject" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ScriptManager ID="script" runat="server"></asp:ScriptManager>

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
            color: #000 !important;
            font-weight: 600 !important;
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
        }


        input[type="text"] {
            /*border: 1px solid #615a72;*/
            border-radius: 6px;
            padding-left: 8px;
            font-weight: 500;
            /*color: #3f646d;*/
            font-size: 14px;
            /*background: #f3f4f4;*/
        }

        .card .card-header {
            background-color: transparent;
            padding: 5px 40px !important;
        }

        .main-footer {
            margin-top: 32px !important;
        }

        .btn-group {
            height: 24px;
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
            margin-left: 61.333333%;
        }

        .card {
            height: auto;
        }

        .text-muted {
            color: #1ea3c1 !important;
            font-weight: 600;
        }

        .theme-white .nav-pills .nav-link.active {
            color: #2600ff;
            background-color: #2673ff33;
            border-bottom: 2px solid #044aca;
            font-size: 14px;
        }

        .nav-pills .nav-item .nav-link {
            color: #2600ff;
            padding-left: 8px !important;
            padding-right: 8px !important;
            border-radius: 0;
            font-size: 14px;
            background: #8080801f;
            font-weight: 600;
            margin-left: 5px;
        }

            .nav-pills .nav-item .nav-link.active {
                background-color: #b0efef70;
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

        div#table-21_length {
            display: none;
        }

        div#table-22_length {
            display: none;
        }

        .table:not(.table-sm):not(.table-md):not(.dataTable) td, .table:not(.table-sm):not(.table-md):not(.dataTable) th {
            font-size: 14px;
        }

        .buttons {
            padding: 2px;
        }

        .section > :first-child {
            margin-top: 15px;
        }

        a.btn.btn-icon.btn-primary {
            height: 26px;
            width: 41px;
            padding: 0px;
        }




        table.table-bordered.dataTable tbody th {
            color: #3e454c;
            font-size: 14px !important;
        }

        .table th {
            color: #3e454c;
            background: #96a2b433;
            font-size: 14px !important;
            letter-spacing: 0.2px;
            font-weight: 600 !important;
            text-shadow: none;
            border: 0 !important;
        }

        .table:not(.table-sm):not(.table-md):not(.dataTable) td, .table:not(.table-sm):not(.table-md):not(.dataTable) th {
            padding: 0px 2px;
            vertical-align: middle !important;
            font-size: 14px;
            font-weight: 500;
            text-align: center;
            border: 2px solid #fff !important;
        }

        table.simple-tree-table span.tree-icon.tree-closed, table.simple-tree-table span.tree-icon.tree-opened {
            background-color: #2600ff !important;
            text-align: center;
            cursor: pointer;
            border-radius: 31px;
            color: #fff;
            display: inline-block;
            position: relative !important;
            left: 33% !important;
        }

        .btn-success, .btn-success.disabled {
            box-shadow: 0 2px 6px #abf2d7;
            background-color: #5a9d44;
            border-color: #5a9d44;
            color: #fff;
            height: 26px;
            line-height: 1.4;
            width: 26px;
        }

        .dataTables_scrollBody thead tr th {
            padding-top: 0 !important;
            padding-bottom: 0 !important;
            border: 0 !important;
        }

        div#table-23_length {
            display: none;
        }

        .fa-eye:before {
            margin-left: -7px;
            content: "\f06e";
        }

        .btn {
            display: inline-block !important;
            height: 27px;
            padding: 0 15px !important;
        }

        .treetablecss th:first-child {
            width: 5px !important;
        }

        table.dataTable img {
            -webkit-box-shadow: 0 5px 15px 0 rgba(105, 103, 103, .5);
            box-shadow: none;
            border: 0px solid #fff;
            border-radius: 10px;
        }
    </style>


    <script type="text/javascript">
        function checkAll(objRef) {
            var GridView = objRef.parentNode.parentNode.parentNode.parentNode.parentNode.parentNode.parentNode; //objRef.parentNode.parentNode.parentNode.parentNode;

            var inputList = GridView.getElementsByTagName("input");

            for (var i = 0; i < inputList.length; i++) {

                var row = inputList[i].parentNode.parentNode;

                if (inputList[i].type == "checkbox" && objRef != inputList[i]) {

                    if (objRef.checked) {

                        inputList[i].checked = true;
                    }

                    else {
                        inputList[i].checked = false;
                    }

                }
            }
        }

    </script>

    <%--<script type="text/javascript">
        function bulkvalidateCheckBoxesapprove() {
            debugger;
            var isValid = false;
            var gridView = document.getElementById('<%= GrvPendingforApproval.ClientID %>');
            for (var i = 1; i < gridView.rows.length; i++) {
                var inputs = gridView.rows[i].getElementsByTagName('input');
                if (inputs != null) {
                    if (inputs[0].type == "checkbox") {
                        if (inputs[0].checked) {
                            isValid = true;
                            //  return confirm('Are you sure want to reject record?');
                            // if (confirm("Are you sure want to approve record?")) {
                            //   return true;
                            //  } else {
                            return true;
                            // }

                        }
                    }
                }
            }
            alert("Please select atleast one checkbox");
            return false;
        }

        function bulkvalidateCheckBoxesreject() {
            debugger;
            var isValid = false;
            var gridView = document.getElementById('<%= GrvPendingforApproval.ClientID %>');
            for (var i = 1; i < gridView.rows.length; i++) {
                var inputs = gridView.rows[i].getElementsByTagName('input');
                if (inputs != null) {
                    if (inputs[0].type == "checkbox") {
                        if (inputs[0].checked) {
                            isValid = true;
                            //  return confirm('Are you sure want to reject record?');
                            //  if (confirm("Are you sure want to reject record?")) {
                            //  return true;
                            // } else {
                            return true;
                            // }

                        }
                    }
                }
            }
            alert("Please select atleast one checkbox");
            return false;
        }

    </script>--%>

    <%--    <script type="text/javascript" src="https://ajax.googleapis.com/ajax/libs/jquery/1.8.3/jquery.min.js"></script>--%>

    <script src="assets/js/jquery-1.8.3.min.js" type="text/javascript"></script>
    <script type="text/javascript">

        $("[src*=plus]").live("click", function () {
            $(this).closest("tr").after("<tr><td></td><td colspan = '7'>" + $(this).next().html() + "</td></tr>")
            $(this).attr("src", "assets/img/minus.svg");
        });
        $("[src*=minus]").live("click", function () {
            $(this).attr("src", "assets/img/plus.svg");
            $(this).closest("tr").next().remove();
        });
    </script>

    <%--    <script type="text/javascript" src="https://cdn.datatables.net/1.10.20/js/jquery.dataTables.min.js"></script>--%>

    <script src="assets/js/jquery.dataTables-1.10.20.min.js" type="text/javascript"></script>
    <link href="Scripts/jquery.dataTables.min.css" rel="stylesheet" />
    <link href="Scripts/dataTables.bootstrap4.min.css" rel="stylesheet" />
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
    s
    <!-- Main Content -->
    <div class="main-content">


        <nav aria-label="breadcrumb">

            <ol class="breadcrumb">
                <li class="breadcrumb-item"><a href="Secretarial_Approvals.aspx">Home</a></li>
                <li class="breadcrumb-item active" aria-current="page">Sale Approval</li>
            </ol>
        </nav>



        <section class="section">

            <div class="row">
                <div class="col-12">
                    <div class="card" style="height: 100%;">
                        <div class="card-header">
                            <h4>Secretarial Sale Approval</h4>

                            <div class="offset-md-7 buttons" style="margin-left: 56.333333%" id="showhidebtn">
                                <asp:Button ID="btn_BulkApprove" runat="server" OnClick="btn_bulkApprove_Click" CausesValidation="false"
                                    Text="Bulk Approve" CssClass="btn badge badge-success badge-shadow"></asp:Button><%-- OnClientClick="bulkvalidateCheckBoxesapprove"--%>
                                <%--<asp:Button ID="btn_BulkReject" runat="server" OnClick="btn_bulkReject_Click" OnClientClick="bulkvalidateCheckBoxesreject" CausesValidation="false"
                                    Text="Bulk Reject" CssClass="btn badge badge-danger badge-shadow"></asp:Button> --%>
                            </div>


                        </div>
                        <div class="card-body">
                            <ul class="offset-md-4 nav nav-pills" id="myTab3" role="tablist">
                                <li class="nav-item">
                                    <a class="nav-link active" id="home-tab3" data-toggle="tab" href="#home3" role="tab" aria-controls="home" aria-selected="true">Pending Approval</a>
                                </li>
                                <li class="nav-item">
                                    <a class="nav-link" id="profile-tab3" data-toggle="tab" href="#profile3" role="tab" aria-controls="profile" aria-selected="false">Approved</a>
                                </li>
                                <li class="nav-item">
                                    <a class="nav-link" id="contact-tab3" data-toggle="tab" href="#contact3" role="tab" aria-controls="contact" aria-selected="false" style="display: none;">Rejected</a>
                                </li>
                            </ul>
                            <div class="tab-content" id="myTabContent2">
                                <div class="tab-pane fade active show" id="home3" role="tabpanel" aria-labelledby="home-tab3">
                                    <div class="table-responsive" style="margin-top: 5px;">
                                        <%--<asp:UpdatePanel ID="UpdatePanelMain" runat="server" UpdateMode="Conditional">
                                            <ContentTemplate>--%>
                                        <div id="showmsg" runat="server"></div>
                                        <asp:GridView ID="grdMain" runat="server" AutoGenerateColumns="false" OnPreRender="grdMain_PreRender"
                                            CssClass="table table-bordered simple-tree-table treetablecss" DataKeyNames="ECODE,SALE_OFFER_FILE_PATH,SALE_DECLARATION_FILE_PATH,SALE_TRANSACTION_RECEIPT_FILE_PATH" OnRowDataBound="GrvPFADB"
                                            Style="border-collapse: separate;" EmptyDataText="" EmptyDataRowStyle-CssClass="Empty" OnRowCommand="grdMain_RowCommand">
                                            <Columns>
                                                <asp:TemplateField>
                                                    <HeaderTemplate>
                                                        <asp:CheckBox ID="checkAll" runat="server" onclick="checkAll(this);" />
                                                    </HeaderTemplate>
                                                    <ItemTemplate>
                                                        <asp:CheckBox runat="server" ID="chk" EnableViewState="false" />
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderStyle-Width="3%">
                                                    <ItemTemplate>
                                                        <img alt="" style="cursor: pointer" src="assets/img/plus.svg" height="25px" width="25px" />
                                                        <asp:UpdatePanel ID="updpnl1" runat="server" Style="display: none">
                                                            <ContentTemplate>
                                                                <asp:GridView ID="GrvPendingforApproval" runat="server" ShowHeaderWhenEmpty="true" AutoGenerateColumns="False" PageSize="10"
                                                                    class="table" EmptyDataText="No Records Found" DataKeyNames="ID,vesting_detail_id,sale_tran_id,ecode" OnRowCommand="GrvPendingforApproval_RowCommand">
                                                                    <Columns>
                                                                       
                                                                        <asp:BoundField DataField="ecode" HeaderText="Employee Code" HeaderStyle-Width="10%" SortExpression="ecode" />
                                                                        <asp:BoundField DataField="emp_name" HeaderText="Employee Name" HeaderStyle-Width="12%" SortExpression="emp_name" />
                                                                        <asp:TemplateField HeaderText="ESOP Code" HeaderStyle-Width="15%">
                                                                            <ItemTemplate>
                                                                                <asp:Label ID="lblTranchVesting" runat="server" Text='<%# Eval("Tranch_Vesting") %>'></asp:Label>
                                                                            </ItemTemplate>
                                                                        </asp:TemplateField>
                                                                        <asp:TemplateField HeaderText="Vesting Date" HeaderStyle-Width="15%">
                                                                            <ItemTemplate>
                                                                                <asp:Label ID="lblVESTING_DATE" runat="server" Text='<%# Eval("VESTING_DATE") %>'></asp:Label>
                                                                            </ItemTemplate>
                                                                        </asp:TemplateField>
                                                                        <asp:TemplateField HeaderText="Sale Date" HeaderStyle-Width="15%">
                                                                            <ItemTemplate>
                                                                                <asp:Label ID="lblSale_Date" runat="server" Text='<%# Eval("Sale_Date") %>'></asp:Label>
                                                                            </ItemTemplate>
                                                                        </asp:TemplateField>
                                                                        <asp:TemplateField HeaderText="Grant Price" HeaderStyle-Width="10%">
                                                                            <ItemTemplate>
                                                                                <asp:Label ID="lblGrantPrice" runat="server" Text='<%# Eval("GRANT_PRICE") %>'></asp:Label>
                                                                            </ItemTemplate>
                                                                        </asp:TemplateField>
                                                                        <asp:TemplateField HeaderText="Sale FMV" HeaderStyle-Width="10%">
                                                                            <ItemTemplate>
                                                                                <asp:Label ID="lblFMVSale" runat="server" Text='<%# Eval("sale_fmv_price") %>'></asp:Label>
                                                                            </ItemTemplate>
                                                                        </asp:TemplateField>
                                                                        <asp:TemplateField HeaderText="No of Excerise" HeaderStyle-Width="10%">
                                                                            <ItemTemplate>
                                                                                <asp:Label ID="lblExcericse" runat="server" Text='<%# Eval("NO_OF_Exercise") %>'></asp:Label>
                                                                            </ItemTemplate>
                                                                        </asp:TemplateField>
                                                                        <asp:TemplateField HeaderText="No of Sale" HeaderStyle-Width="15%">
                                                                            <ItemTemplate>
                                                                                <asp:Label ID="lblOptions" runat="server" Text='<%# Eval("no_of_sale") %>'></asp:Label>
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
                                                                    </Columns>
                                                                </asp:GridView>
                                                            </ContentTemplate>
                                                        </asp:UpdatePanel>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:BoundField DataField="ecode" HeaderText="Employee Code" HeaderStyle-Width="10%" />
                                                <asp:BoundField DataField="emp_name" HeaderText="Employee Name" HeaderStyle-Width="12%" />
                                                <asp:BoundField DataField="Total_No_Of_Sale" HeaderText="Total No Of Sale" HeaderStyle-Width="12%" />
                                                <asp:TemplateField HeaderText="Download" ItemStyle-Width="100" ItemStyle-Wrap="false">
                                                    <ItemTemplate>
                                                        <asp:LinkButton ID="lb_download" runat="server" CommandName="Download" CausesValidation="false"
                                                            OnClick="lb_download_Click" class="btn btn-icon btn-primary fas fa-arrow-down"></asp:LinkButton>
                                                        <%--OnClick="lb_download_Click"--%>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Remark" HeaderStyle-Width="10%">
                                                    <ItemTemplate>
                                                        <div class="remark">
                                                            <asp:TextBox ID="TxtRemarkPend_Approval" runat="server" placeholder="Enter Remark" Width="" TextMode="MultiLine"></asp:TextBox>
                                                        </div>
                                                    </ItemTemplate>
                                                </asp:TemplateField>

                                                <asp:TemplateField HeaderText="Action" HeaderStyle-Width="10%">
                                                    <ItemTemplate>
                                                        <div class="btn-group">

                                                            <asp:Button ID="BtnGrvBulkApprove" runat="server" CommandName="Approve" CausesValidation="false" CommandArgument='<%--<%# Eval("SALE_TRAN_ID") %>--%>' OnClientClick="return validateCheckBoxesapprove();"
                                                                Text="Approve" CssClass="btn badge badge-success badge-shadow"></asp:Button>

                                                            <asp:Button ID="BtnGrvBulkReject" runat="server" CommandName="Reject" CausesValidation="false" CommandArgument='<%--<%# Eval("SALE_TRAN_ID") %>--%>'
                                                                Text="Reject" CssClass="btn badge badge-danger badge-shadow" OnClientClick="return validateCheckBoxes();" Visible="false"></asp:Button>
                                                        </div>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="SALE_OFFER_FILE_PATH" HeaderStyle-Width="10%">
                                                    <HeaderStyle CssClass="hiddencol" />
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblSALE_OFFER_FILE_PATH" runat="server" Text='<%# Eval("SALE_OFFER_FILE_PATH") %>'></asp:Label>
                                                    </ItemTemplate>
                                                    <ItemStyle HorizontalAlign="Right" CssClass="hiddencol" />
                                                </asp:TemplateField>

                                                <asp:TemplateField HeaderText="SALE_DECLARATION_FILE_PATH" HeaderStyle-Width="10%">
                                                    <HeaderStyle CssClass="hiddencol" />
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblSALE_DECLARATION_FILE_PATH" runat="server" Text='<%# Eval("SALE_DECLARATION_FILE_PATH") %>'></asp:Label>
                                                    </ItemTemplate>
                                                    <ItemStyle HorizontalAlign="Right" CssClass="hiddencol" />
                                                </asp:TemplateField>

                                                <asp:TemplateField HeaderText="SALE_TRANSACTION_RECEIPT_FILE_PATH" HeaderStyle-Width="10%">
                                                    <HeaderStyle CssClass="hiddencol" />
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblSALE_TRANSACTION_RECEIPT_FILE_PATH" runat="server" Text='<%# Eval("SALE_TRANSACTION_RECEIPT_FILE_PATH") %>'></asp:Label>
                                                    </ItemTemplate>
                                                    <ItemStyle HorizontalAlign="Right" CssClass="hiddencol" />
                                                </asp:TemplateField>
                                            </Columns>
                                        </asp:GridView>
                                        <%--</ContentTemplate>
                                        </asp:UpdatePanel>--%>
                                    </div>
                                </div>
                                <div class="tab-pane fade" id="profile3" role="tabpanel" aria-labelledby="profile-tab3">
                                    <div class="table-responsive" style="margin-top: 5px;">
                                        <asp:UpdatePanel ID="updpnl2" runat="server" UpdateMode="Conditional">
                                            <ContentTemplate>
                                                <asp:GridView ID="GrvApproved" runat="server" ShowHeaderWhenEmpty="true" AutoGenerateColumns="False" PageSize="25"
                                                    class="table" EmptyDataText="" OnPreRender="GrvApproved_PreRender">
                                                    <Columns>
                                                        <asp:BoundField DataField="ecode" HeaderText="Employee Code" HeaderStyle-Width="10%" SortExpression="ecode" />
                                                        <asp:BoundField DataField="emp_name" HeaderText="Employee Name" HeaderStyle-Width="12%" SortExpression="emp_name" />
                                                        <asp:BoundField DataField="Tranch_Vesting" HeaderText="ESOP Code" HeaderStyle-Width="8%" />
                                                        <asp:BoundField DataField="VESTING_DATE1" HeaderText="Vesting Date" DataFormatString="{0:dd-M-yyyy}" HeaderStyle-Width="9%" SortExpression="emp_name" />
                                                        <asp:BoundField DataField="EXERCISE_DATE" HeaderText="Excercise Date" HeaderStyle-Width="10%" SortExpression="EXERCISE_DATE" DataFormatString="{0:dd-M-yyyy}" />
                                                        <asp:BoundField DataField="sale_date1" HeaderText="Sale Date" HeaderStyle-Width="10%" SortExpression="sale_date" DataFormatString="{0:dd-M-yyyy}" />
                                                        <asp:BoundField DataField="GRANT_PRICE" HeaderText="Grant Price" HeaderStyle-Width="10%" />
                                                        <asp:BoundField DataField="sale_fmv_price" HeaderText="Sale Fmv Price" HeaderStyle-Width="5%" />
                                                        <asp:BoundField DataField="NO_OF_Exercise" HeaderText="No of Exercise" HeaderStyle-Width="8%" />
                                                        <asp:BoundField DataField="no_of_sale" HeaderText="No of Sale" HeaderStyle-Width="5%" />
                                                        <asp:BoundField DataField="total_amount" HeaderText="Total Amount Payable" HeaderStyle-Width="10%" />
                                                        <asp:BoundField DataField="dpid" HeaderText="DP ID" HeaderStyle-Width="5%" />
                                                        <asp:BoundField DataField="client_id" HeaderText="Client ID" HeaderStyle-Width="5%" />
                                                        <asp:BoundField DataField="member_type" HeaderText="Member Type" HeaderStyle-Width="8%" />
                                                        <asp:BoundField DataField="Remark" HeaderText="Remark" HeaderStyle-Width="8%" />
                                                    </Columns>
                                                </asp:GridView>
                                            </ContentTemplate>
                                            <Triggers>
                                                <asp:AsyncPostBackTrigger ControlID="GrvApproved" />
                                            </Triggers>
                                        </asp:UpdatePanel>
                                    </div>
                                </div>
                                <div class="tab-pane fade" id="contact3" role="tabpanel" aria-labelledby="contact3-tab3">
                                    <div class="table-responsive" style="margin-top: 5px;">
                                        <asp:UpdatePanel ID="updpnl3" runat="server" UpdateMode="Conditional">
                                            <ContentTemplate>
                                                <asp:GridView ID="GrvReject" runat="server" OnPreRender="GrvReject_PreRender" ShowHeaderWhenEmpty="true" AutoGenerateColumns="False" PageSize="25"
                                                    class="table dataTable no-footer" EmptyDataText="">
                                                    <Columns>

                                                        <asp:BoundField DataField="ecode" HeaderText="Employee Code" HeaderStyle-Width="10%" />
                                                        <asp:BoundField DataField="emp_name" HeaderText="Employee Name" HeaderStyle-Width="12%" />
                                                        <%--<asp:BoundField DataField="sale_date" HeaderText="Sale Date" HeaderStyle-Width="5%" />--%>

                                                        <asp:BoundField DataField="sale_date_New" HeaderText="Sale Date" HeaderStyle-Width="10%" SortExpression="sale_date" DataFormatString="{0:dd-M-yyyy}" />

                                                        <asp:BoundField DataField="sale_fmv_price" HeaderText="Sale Fmv Price" HeaderStyle-Width="5%" />
                                                        <%--<asp:BoundField DataField="grant_price" HeaderText="Grant Price" HeaderStyle-Width="5%" />--%>
                                                        <asp:BoundField DataField="no_of_sale" HeaderText="No of Sale" HeaderStyle-Width="5%" />
                                                        <asp:BoundField DataField="total_amount" HeaderText="Total Amount Payable" HeaderStyle-Width="10%" />

                                                    </Columns>
                                                </asp:GridView>
                                            </ContentTemplate>
                                            <Triggers>
                                                <asp:AsyncPostBackTrigger ControlID="GrvReject" />
                                            </Triggers>
                                        </asp:UpdatePanel>
                                    </div>
                                </div>
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

    <script type="text/javascript">
        $(function () {
            $("#profile-tab3").on("click", function () {

                $("#showhidebtn").css({ 'display': 'none' });

            });

            $("#contact3-tab3").on("click", function () {

                $("#showhidebtn").css({ 'display': 'none' });
            });

            $("#home-tab3").on("click", function () {

                $("#showhidebtn").css({ 'display': 'block' });

            });


        });
    </script>
    <script type="text/javascript">
        //$('#ContentPlaceHolder1_grdpendingapproval').clear().draw();

        var prm = Sys.WebForms.PageRequestManager.getInstance();

        prm.add_endRequest(function (sender, e) {
            debugger;
            $('#ContentPlaceHolder1_grdMain').dataTable({
                lengthMenu: [[-1, 5, 10], ["All", 5, 10]],
                order: [],
                columnDefs: [{ orderable: false, targets: [0, 1, 5, 6, 7] }],
                bRetrieve: true, fixedHeader: true, "scrollX": true

            });

        });


        $(function () {
            $.noConflict();
            debugger;
            $('#ContentPlaceHolder1_grdMain').DataTable({

                bLengthChange: true,
                lengthMenu: [[-1, 5, 10], ["All", 5, 10]],
                bFilter: true,
                //'columnDefs': [{
                //    'targets': [0, 7, 8],
                //    'orderable': false,
                //}],
                order: [],
                columnDefs: [{ orderable: false, targets: [0, 1, 5, 6, 7] }],
                bPaginate: true, fixedHeader: true, "scrollX": true

            });
        });
    </script>

    <script type="text/javascript">
        //$('#ContentPlaceHolder1_grdpendingapproval').clear().draw();

        var prm = Sys.WebForms.PageRequestManager.getInstance();

        prm.add_endRequest(function (sender, e) {
            debugger;
            $('#ContentPlaceHolder1_GrvApproved').dataTable({
                lengthMenu: [[-1, 5, 10], ["All", 5, 10]],
                order: [],
                columnDefs: [{ orderable: false, targets: [] }],
                bRetrieve: true, fixedHeader: true, "scrollX": true

            });

        });


        $(function () {

            debugger;
            $('#ContentPlaceHolder1_GrvApproved').DataTable({

                bLengthChange: true,
                lengthMenu: [[-1, 5, 10], ["All", 5, 10]],
                bFilter: true,
                //'columnDefs': [{
                //    'targets': [0, 7, 8],
                //    'orderable': false,
                //}],
                order: [],
                columnDefs: [{ orderable: false, targets: [] }],
                bPaginate: true, fixedHeader: true, "scrollX": true

            });
        });
    </script>


    <script>
        var prm = Sys.WebForms.PageRequestManager.getInstance();

        prm.add_endRequest(function (sender, e) {
            var table = $('#ContentPlaceHolder1_GrvReject').DataTable({
                lengthMenu: [[-1, 5, 10], ["All", 5, 10]],
                columnDefs: [{ orderable: false, targets: [5] }],
                bRetrieve: true,//fixedHeader: true, "scrollX": true
            });
            table
.search('')
.columns().search('')
.draw();
        });

        $(function () {
            var table = $('#ContentPlaceHolder1_GrvReject').DataTable({
                bLengthChange: true,
                lengthMenu: [[-1, 5, 10], ["All", 5, 10]],
                bFilter: true,
                'columnDefs': [{
                    'targets': [5],
                    'orderable': false,
                }],
                bPaginate: true,//fixedHeader: true, "scrollX": true
            });
            table
.search('')
.columns().search('')
.draw();
        });


    </script>
</asp:Content>

