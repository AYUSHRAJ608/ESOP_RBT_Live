<%@ Page Title="" Language="C#" MasterPageFile="~/ESOP.Master" AutoEventWireup="true" CodeBehind="Checker_Lapse_Approve_Reject.aspx.cs" Inherits="ESOP.Checker_Lapse_Approve_Reject" EnableEventValidation="false" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="assets/css/jquery-ui-1.12.1.css" rel="stylesheet" />
    <script src="assets/js/jquery-ui-1.12.1.js" type="text/javascript"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ScriptManager ID="script" runat="server"></asp:ScriptManager>
    <style type="text/css">
        html, body {
            background: none !important;
        }

        #overlay {
            position: fixed;
            z-index: 99;
            top: 0px;
            left: 0px;
            background-color: #FFFFFF;
            width: 100%;
            height: 100%;
            filter: Alpha(Opacity=80);
            opacity: 0.80;
        }

        #theprogress {
            position: center;
            padding-top: 15%;
            padding-left: 40%;
            background-color: white;
            width: 20px;
            height: 12px;
            text-align: center;
            filter: Alpha(Opacity=100);
            opacity: 1;
        }

        #modelprogress {
            position: absolute;
            top: 50%;
            left: 50%;
            margin: -11px 0 0 -55px;
            color: white;
        }

        body > #modelprogress {
            position: fixed;
        }
    </style>
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
            color: #3f646d;
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
            height: 22px;
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
                color: #fff;
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

        div.dataTables_wrapper div.dataTables_length select {
            width: auto !important;
        }

        /*.table th {
            color: #000 !important;
            font-weight: 600 !important;
        }*/

        td input[type=checkbox] {
            margin: 0 auto;
            display: block;
        }

        h4 .badge {
            font-size: 13px;
            padding: 8px 13px;
        }


        .btn {
            display: inline-block !important;
            height: 27px;
            padding: 0 15px !important;
        }

        .edit12 {
            padding: 10px;
            background: #2573ff;
            color: white !important;
            border-radius: 4px;
            line-height: 0;
        }

        .modal-backdrop.in {
            display: block;
            opacity: 0.4;
        }

        /*.width100 .dataTables_scrollHeadInner, .width100 .dataTables_scrollHeadInner table {
            width: 100% !important;
        }*/
    </style>

    <%--    <script type="text/javascript" src="https://ajax.googleapis.com/ajax/libs/jquery/1.8.3/jquery.min.js"></script>
    <script type="text/javascript" src="https://cdn.datatables.net/1.10.20/js/jquery.dataTables.min.js"></script>--%>
    <script type="text/javascript" src="assets/js/jquery-1.8.3.min.js"></script>
    <script src="assets/js/jquery.dataTables-1.10.20.min.js"></script>
    <link href="Scripts/jquery.dataTables.min.css" rel="stylesheet" />
    <link href="Scripts/dataTables.bootstrap4.min.css" rel="stylesheet" />

    <script>
        $(document).ready(function () {
            $('[id*=checkAll]').click(function () {
                $("[id*='chk']").attr('checked', this.checked);
            });

            var prm = Sys.WebForms.PageRequestManager.getInstance();
            prm.add_endRequest(function () {
                $('[id*=checkAll]').click(function () {
                    debugger;
                    $("[id*='chk']").attr('checked', this.checked);
                });
            });
        });
    </script>

    <%--  <script type="text/javascript">
        function alertMessage() {
            alert('Grant has been approved, sent for President approval.!');
        }

        function alertMessage1() {
            alert('Grant has been rejected, sent to Admin for the correction.');
        }
    </script>--%>
    <script>
        <%--function DownloadFile(filepath) {
            __doPostBack("<%= BtnDownload.UniqueID %>", filepath);
        }--%>
    </script>
    <script type="text/javascript">
        function checkAll(objRef) {
            // debugger;
            var GridView = objRef.parentNode.parentNode.parentNode.parentNode;

            var inputList = GridView.getElementsByTagName("input");

            for (var i = 0; i < inputList.length; i++) {

                //Get the Cell To find out ColumnIndex

                var row = inputList[i].parentNode.parentNode;

                if (inputList[i].type == "checkbox" && objRef != inputList[i]) {

                    if (objRef.checked) {

                        //If the header checkbox is checked

                        //check all checkboxes

                        //and highlight all rows

                        //row.style.backgroundColor = "aqua";

                        inputList[i].checked = true;

                    }

                    else {

                        //If the header checkbox is checked

                        //uncheck all checkboxes

                        //and change rowcolor back to original                     

                        inputList[i].checked = false;
                    }

                }

            }

        }

    </script>

    <script type="text/javascript">
        function bulkvalidateCheckBoxesapprove() {
            //  debugger;
            var isValid = false;
            var gridView = document.getElementById('<%= grdpendingapproval.ClientID %>');
            for (var i = 1; i < gridView.rows.length; i++) {
                var inputs = gridView.rows[i].getElementsByTagName('input');
                if (inputs != null) {
                    if (inputs[0].type == "checkbox") {
                        if (inputs[0].checked) {
                            isValid = true;
                            //  return confirm('Are you sure want to reject record?');
                            // if (confirm("Are you sure want to approve record?")) {
                            //      return true;
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
    </script>

    <script type="text/javascript">
        function bulkvalidateCheckBoxesreject() {
            //debugger;
            var isValid = false;
            var gridView = document.getElementById('<%= grdpendingapproval.ClientID %>');
            for (var i = 1; i < gridView.rows.length; i++) {
                var inputs = gridView.rows[i].getElementsByTagName('input');
                if (inputs != null) {
                    if (inputs[0].type == "checkbox") {
                        if (inputs[0].checked) {
                            isValid = true;
                            //  return confirm('Are you sure want to reject record?');
                            // if (confirm("Are you sure want to reject record?")) {
                            ///    return true;
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
    </script>


    <%--    <script type="text/javascript">
        function validateCheckBoxesapprove() {
            // debugger;
            // var isValid = false;
            var gridView = document.getElementById('<%= grdpendingapproval.ClientID %>');
            //for (var i = 1; i < gridView.rows.length; i++) {
            // var inputs = gridView.rows[i].getElementsByTagName('input');
            //  if (inputs != null) {
            // if (inputs[0].type == "checkbox") {
            // if (inputs[0].checked) {
            //  isValid = true;
            //  return confirm('Are you sure want to reject record?');
            if (confirm("Are you sure want to approve record?")) {
                return true;
            } else {
                return false;
            }

            // }
            //  }
            // }
            // }
            //alert("Please select atleast one checkbox");
            return false;
        }
    </script>   --%>

    <script type="text/javascript">
        function validateCheckBoxes() {
            var gridView = document.getElementById('<%= grdpendingapproval.ClientID %>');
            for (var i = 1; i < gridView.rows.length; i++) {
                var inputs = gridView.rows[i].getElementsByTagName('textarea');
                if (inputs[0].value == null || inputs[0].value == "") {
                    alert("Please Enter the reason for rejection.");
                    return false;
                }
                else {
                    if (confirm("Are you sure want to reject record?")) {
                        return true;
                    } else {
                        return false;
                    }
                }
            }
        }
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

            $('[id*=checkAll]').click(function () {
                debugger;
                $("[id*='chk']").attr('checked', this.checked);
            });

            $('a[data-toggle="tab"]').on('shown.bs.tab', function (e) {
                $($.fn.dataTable.tables(true)).DataTable()
                   .columns.adjust()
                   .responsive.recalc();
            });
        });

        var prm = Sys.WebForms.PageRequestManager.getInstance();
        prm.add_endRequest(function () {
            $('[id*=checkAll]').click(function () {
                debugger;
                $("[id*='chk']").attr('checked', this.checked);
            });
        });
    </script>


    <div class="main-content" style="padding-top: 55px; padding-left: 40px; padding-right: 10px;">
        <nav aria-label="breadcrumb">
            <%--<div style="font-weight: 500;"><b>HR Grant Approval Summary</b></div>--%>
            <ol class="breadcrumb">
                <li class="breadcrumb-item"><a href="Checker_Approve_Reject.aspx">Home</a></li>
                <li class="breadcrumb-item active" aria-current="page">Checker</li>
            </ol>
        </nav>
        <section class="section">
            <div class="row">
                <div class="col-lg-12 col-md-12 col-12 col-sm-12">
                    <div class="row">
                        <div class="col-lg-3 col-md-6 col-sm-6 col-12">
                            <div class="card card-statistic-1">
                                <div class="card-icon-square card-icon-bg-green">
                                    <i class="fas fa-award"></i>
                                </div>
                                <div class="card-wrap">
                                    <div class="">
                                        <div class="text-right">
                                            <h3 class="font-light mb-0">
                                                <i class="ti-arrow-up text-success"></i>
                                                <asp:Label ID="lbltotal_lapsed" runat="server" Text="0"></asp:Label>
                                            </h3>
                                            <span class="text-muted">Total Lapsed</span>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                        <div class="col-lg-3 col-md-6 col-sm-6 col-12">
                            <div class="card card-statistic-1">
                                <div class="card-icon-square card-icon-bg-orange">
                                    <i class="fas fa-thumbs-up"></i>
                                </div>
                                <div class="card-wrap">
                                    <div class="">
                                        <div class="text-right">
                                            <h3 class="font-light mb-0">
                                                <i class="ti-arrow-up text-success"></i>
                                                <asp:UpdatePanel ID="UpdatePanel3" runat="server">
                                                    <%----%>
                                                    <ContentTemplate>
                                                        <asp:Label ID="lbl_approved" runat="server" Text="0"></asp:Label>
                                                    </ContentTemplate>
                                                    <Triggers>
                                                        <asp:AsyncPostBackTrigger ControlID="grdpendingapproval" />
                                                        <asp:AsyncPostBackTrigger ControlID="btn_bulkApprove" EventName="Click" />
                                                        <asp:AsyncPostBackTrigger ControlID="btn_bulkReject" EventName="Click" />
                                                    </Triggers>
                                                </asp:UpdatePanel>
                                            </h3>
                                            <span class="text-muted">Approved</span>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                        <div class="col-lg-3 col-md-6 col-sm-6 col-12">
                            <div class="card card-statistic-1">
                                <div class="card-icon-square card-icon-bg-cyan">
                                    <i class="fas fa-times-circle"></i>
                                </div>
                                <div class="card-wrap">
                                    <div class="">
                                        <div class="text-right">
                                            <h3 class="font-light mb-0">
                                                <i class="ti-arrow-up text-success"></i>
                                                <asp:UpdatePanel ID="UpdatePanel4" runat="server">
                                                    <%--UpdateMode="Conditional"--%>
                                                    <ContentTemplate>
                                                        <asp:Label ID="lbl_rejected" runat="server" Text="0"></asp:Label>
                                                    </ContentTemplate>
                                                    <Triggers>
                                                        <asp:AsyncPostBackTrigger ControlID="grdpendingapproval" />
                                                        <asp:AsyncPostBackTrigger ControlID="btn_bulkApprove" EventName="Click" />
                                                        <asp:AsyncPostBackTrigger ControlID="btn_bulkReject" EventName="Click" />
                                                    </Triggers>
                                                </asp:UpdatePanel>
                                            </h3>
                                            <span class="text-muted">Rejected</span>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                        <div class="col-lg-3 col-md-6 col-sm-6 col-12">
                            <div class="card card-statistic-1">
                                <div class="card-icon-square card-icon-bg-purple">
                                    <i class="fas fa-clock"></i>
                                </div>
                                <div class="card-wrap">
                                    <div class="">
                                        <div class="text-right">
                                            <h3 class="font-light mb-0">
                                                <i class="ti-arrow-up text-success"></i>
                                                <asp:UpdatePanel ID="UpdatePanel5" runat="server">
                                                    <%-- UpdateMode="Conditional"--%>
                                                    <ContentTemplate>
                                                        <asp:Label ID="lbl_approval_pending" runat="server" Text="0"></asp:Label>
                                                    </ContentTemplate>
                                                    <Triggers>
                                                        <asp:AsyncPostBackTrigger ControlID="grdpendingapproval" />
                                                        <asp:AsyncPostBackTrigger ControlID="btn_bulkApprove" EventName="Click" />
                                                        <asp:AsyncPostBackTrigger ControlID="btn_bulkReject" EventName="Click" />
                                                    </Triggers>
                                                </asp:UpdatePanel>
                                            </h3>
                                            <span class="text-muted">Approval Pending</span>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>

            </div>
            <div class="row">
                <div class="col-12">
                    <div class="card" style="height: 100%;">
                        <asp:UpdatePanel ID="UpdatePanel6" runat="server" UpdateMode="Conditional">
                            <%-- UpdateMode="Conditional"--%>
                            <ContentTemplate>
                                <div class="card-header">
                                    <h4>List of Lapse approval</h4>

                                    <div class="offset-md-7 buttons" style="margin-left: 60.333333%" id="showhidebtn">
                                        <asp:Button ID="btn_bulkApprove" runat="server" CommandName="Bulk Approve" CausesValidation="false" OnClick="btn_bulkApprove_Click" OnClientClick="return bulkvalidateCheckBoxesapprove();"
                                            Text="Bulk Approve" CssClass="btn badge-success badge-shadow"></asp:Button>
                                        <asp:Button ID="btn_bulkReject" runat="server" CommandName="Bulk Reject" CausesValidation="false" OnClick="btn_bulkReject_Click" OnClientClick="return bulkvalidateCheckBoxesreject();"
                                            Text="Bulk Reject" CssClass="btn badge-danger badge-shadow"></asp:Button>
                                    </div>

                                </div>
                            </ContentTemplate>
                        </asp:UpdatePanel>
                        <div class="card-body">
                            <ul class="offset-md-4 nav nav-pills" id="myTab3" role="tablist">
                                <li class="nav-item">
                                    <a class="nav-link active" id="home-tab3" data-toggle="tab" style="color: #0889a9;" href="#home3" role="tab" aria-controls="home" aria-selected="true">Pending Approval</a>
                                </li>
                                <li class="nav-item">
                                    <a class="nav-link" id="profile-tab3" data-toggle="tab" href="#profile3" style="color: #0889a9;" role="tab" aria-controls="profile" aria-selected="false">Approved</a>
                                </li>
                                <li class="nav-item">
                                    <a class="nav-link" id="contact-tab3" data-toggle="tab" href="#contact3" style="color: #0889a9;" role="tab" aria-controls="contact" aria-selected="false">Rejected</a>
                                </li>
                            </ul>
                            <div class="tab-content" id="myTabContent2">
                                <div class="tab-pane fade active show" id="home3" role="tabpanel" aria-labelledby="home-tab3">
                                    <div class="table-responsive" style="margin-top: 5px;">

                                        <asp:UpdatePanel ID="UpdatePanel2" runat="server" UpdateMode="Conditional" ChildrenAsTriggers="false">
                                            <%-- UpdateMode="Conditional"--%>
                                            <ContentTemplate>
                                                <div id="showmsg" runat="server"></div>
                                                <asp:GridView ID="grdpendingapproval" runat="server" OnPreRender="grdpendingapproval_PreRender" EmptyDataText="" ShowHeaderWhenEmpty="false"
                                                    AutoGenerateColumns="False" class="table" DataKeyNames="ECODE,VESTED_PENDING,EXERCISED_PENDING" OnRowCommand="grdpendingapproval_RowCommand">
                                                    <Columns>
                                                        <asp:TemplateField>
                                                            <HeaderTemplate>
                                                                <asp:CheckBox ID="checkAll" runat="server" />
                                                            </HeaderTemplate>
                                                            <ItemTemplate>
                                                                <asp:CheckBox runat="server" ID="chk" />
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Employee Name" HeaderStyle-CssClass="text-nowrap" HeaderStyle-Font-Bold="true" HeaderStyle-Width="12%" ItemStyle-CssClass="griditem1">
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblEmp" runat="server" Text='<%#Eval("EMP_NAME")%>' Visible="true"></asp:Label>

                                                                <asp:HiddenField ID="HdEmpCode" runat="server" Value='<%# Bind("ECODE") %>' />
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:BoundField DataField="ACTIVE" HeaderStyle-Font-Bold="true" HeaderText="Status" HeaderStyle-Width="8%"></asp:BoundField>
                                                        <asp:TemplateField HeaderText="Vesting Percent" HeaderStyle-Font-Bold="true" FooterStyle-Font-Bold="true"
                                                            HeaderStyle-Width="12%">
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblVPERCENTAGE" runat="server" Text='<%#Eval("VPERCENTAGE") %>' />
                                                                <asp:HiddenField ID="Hd_Id" runat="server" Value='<%# Bind("ID") %>' />
                                                                <asp:HiddenField ID="hdnGrantID" runat="server" Value='<%# Bind("grant_id") %>' />
                                                                <asp:HiddenField ID="hdnVestingID" runat="server" Value='<%# Bind("v_detail_id") %>' />
                                                                <asp:HiddenField ID="IsExpanded" runat="server" />
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Granted" HeaderStyle-CssClass="text-nowrap" HeaderStyle-Font-Bold="true" HeaderStyle-Width="8%">
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblVNAME" runat="server" Text='<%#Eval("GRANTED")%>' Visible="true"></asp:Label>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:BoundField DataField="VESTED" HeaderStyle-Font-Bold="true" HeaderText="Vested" HeaderStyle-Width="8%"></asp:BoundField>
                                                        <asp:BoundField DataField="VESTED_PENDING" HeaderStyle-Font-Bold="true" HeaderText="Pending for Vesting" HeaderStyle-Width="8%"></asp:BoundField>
                                                        <asp:BoundField DataField="EXERCISED" HeaderStyle-Font-Bold="true" HeaderText="Exercised" HeaderStyle-Width="8%"></asp:BoundField>
                                                        <asp:BoundField DataField="EXERCISED_PENDING" HeaderStyle-Font-Bold="true" HeaderText="Pending for Excercise" HeaderStyle-Width="8%"></asp:BoundField>
                                                        <asp:BoundField DataField="SALE" HeaderStyle-Font-Bold="true" HeaderText="Sale" HeaderStyle-Width="8%"></asp:BoundField>

                                                        <asp:TemplateField HeaderText="LBV" HeaderStyle-Font-Bold="true" FooterStyle-Font-Bold="true"
                                                            HeaderStyle-Width="6%">
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblLBV" runat="server" Text='<%#Eval("LBV") %>'  /><%--Style="display: none"--%>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="LAV" HeaderStyle-Font-Bold="true" FooterStyle-Font-Bold="true"
                                                            HeaderStyle-Width="6%">
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblLAV" runat="server" Text='<%#Eval("LAV") %>'  /><%--Style="display: none"--%>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>

                                                        <%--<asp:BoundField DataField="LBV" HeaderStyle-Font-Bold="true" HeaderText="LBV" HeaderStyle-Width="6%"></asp:BoundField>
                                                        <asp:BoundField DataField="LAV" HeaderStyle-Font-Bold="true" HeaderText="LAV" HeaderStyle-Width="6%"></asp:BoundField>--%>

                                                        <asp:BoundField DataField="TOTAL_LAPSE" HeaderStyle-Font-Bold="true" HeaderText="Total Lapsed" HeaderStyle-Width="8%"></asp:BoundField>
                                                        <asp:BoundField DataField="STOCK_IN_HAND" HeaderStyle-Font-Bold="true" HeaderText="Stock in Hand" HeaderStyle-Width="8%"></asp:BoundField>

                                                        <asp:TemplateField HeaderText="Vesting Date" HeaderStyle-Font-Bold="true" FooterStyle-Font-Bold="true"
                                                            HeaderStyle-Width="10%">
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblVESTING_DATE" runat="server" Text='<%#Eval("VESTING_DATE") %>' />
                                                            </ItemTemplate>
                                                        </asp:TemplateField>

                                                        <asp:TemplateField HeaderText="Lapse Date" HeaderStyle-CssClass="text-nowrap" HeaderStyle-Font-Bold="true" HeaderStyle-Width="8%">
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblLapseDate" runat="server" Text='<%#Eval("lapseDate")%>' Visible="true"></asp:Label>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>

                                                        <%--<asp:TemplateField HeaderText="Proposed LBV" HeaderStyle-Font-Bold="true" FooterStyle-Font-Bold="true"
                                                                HeaderStyle-Width="5%">
                                                                <ItemTemplate>
                                                                    <asp:Label ID="lblLBV" runat="server" Text='<%#Eval("LBV") %>' Style="display: none"> />
                                                                </ItemTemplate>
                                                                <ItemTemplate>
                                                                    <div class="remark">
                                                                        <asp:TextBox ID="TxtLBV" runat="server" CssClass="form-control"
                                                                            AutoPostBack="true" Text="" placeholder="Enter LBV Lapse" Width="90" OnTextChanged="TxtLBV_TextChanged"></asp:TextBox>
                                                                    </div>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="Proposed LAV" HeaderStyle-Font-Bold="true" FooterStyle-Font-Bold="true"
                                                                HeaderStyle-Width="5%">
                                                                <ItemTemplate>
                                                                    <asp:Label ID="lblLAV" runat="server" Text='<%#Eval("LAV") %>' Style="display: none" />
                                                                </ItemTemplate>
                                                               <ItemTemplate>
                                                                    <div class="remark">
                                                                        <asp:TextBox ID="TxtLAV" runat="server" CssClass="form-control"
                                                                            AutoPostBack="true" Text="" placeholder="Enter LAV Lapse" Width="90" OnTextChanged="TxtLAV_TextChanged"></asp:TextBox>
                                                                    </div>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="NewLapseDate">
                                                                <ItemTemplate>
                                                                    <div class="remark form-group thiscontrol">
                                                                        <asp:TextBox ID="txtDateOfLapse" runat="server" placeholder="dd-mm-yyyy" class="now form-control"></asp:TextBox>
                                                                    </div>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>--%>

                                                        <asp:TemplateField HeaderText="Remark" HeaderStyle-Width="10%">
                                                            <ItemTemplate>
                                                                <div class="remark">
                                                                    <asp:TextBox ID="TxtRemark" runat="server" placeholder="Enter Remark" Width="" TextMode="MultiLine" ondrop="return false;" ondrag="return false;"></asp:TextBox>
                                                                </div>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>

                                                        <asp:TemplateField HeaderText="Action" HeaderStyle-Width="10%">
                                                            <ItemTemplate>
                                                                <div class="btn-group">
                                                                    <asp:Button ID="BtnGrvApprove" runat="server" CommandName="Approve" OnClick="BtnGrvApprove_Click" CausesValidation="false" CommandArgument=''
                                                                        Text="Lapse Approve" CssClass="btn badge-success badge-shadow"></asp:Button>
                                                                    <asp:Button ID="BtnGrvReject" runat="server" CommandName="Reject" OnClick="BtnGrvReject_Click" CausesValidation="false" CommandArgument=''
                                                                        Text="Lapse Reject" CssClass="btn badge-danger badge-shadow"></asp:Button>
                                                                </div>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Audit Trail">
                                                            <ItemTemplate>
                                                                <asp:LinkButton ID="btn_Audit_1" runat="server" CommandName="Audit" CausesValidation="true"
                                                                    CommandArgument="<%# ((GridViewRow) Container).RowIndex %>"
                                                                    CssClass="fas fa-info edit12"></asp:LinkButton>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                    </Columns>
                                                </asp:GridView>
                                            </ContentTemplate>
                                            <Triggers>
                                                <asp:AsyncPostBackTrigger ControlID="grdpendingapproval" />
                                                <asp:AsyncPostBackTrigger ControlID="btn_bulkApprove" EventName="Click" />
                                                <asp:AsyncPostBackTrigger ControlID="btn_bulkReject" EventName="Click" />
                                            </Triggers>
                                        </asp:UpdatePanel>
                                        <%--<asp:button id="BtnDownload" onclick="DownloadFile_Click" runat="server" visible="false" xmlns:asp="#unknown" />--%>
                                    </div>
                                </div>
                                <div class="tab-pane fade" id="profile3" role="tabpanel" aria-labelledby="profile-tab3">
                                    <div class="table-responsive width100" style="margin-top: 30px;">
                                        <asp:UpdatePanel ID="upd" runat="server" UpdateMode="Conditional">
                                            <%--UpdateMode="Conditional"--%>
                                            <ContentTemplate>
                                                <asp:GridView ID="grdapproval" runat="server" ShowHeaderWhenEmpty="false"
                                                    OnPreRender="grdapproval_PreRender" EmptyDataText="" AutoGenerateColumns="false" OnRowCommand="grdapproval_RowCommand"
                                                    class="table" DataKeyNames="ECODE,VESTED_PENDING,EXERCISED_PENDING">
                                                    <Columns>
                                                        <asp:TemplateField HeaderText="Employee Name" HeaderStyle-CssClass="text-nowrap" HeaderStyle-Font-Bold="true" HeaderStyle-Width="12%" ItemStyle-CssClass="griditem1">
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblEmp" runat="server" Text='<%#Eval("EMP_NAME")%>' Visible="true"></asp:Label>

                                                                <asp:HiddenField ID="HdEmpCode" runat="server" Value='<%# Bind("ECODE") %>' />
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:BoundField DataField="ACTIVE" HeaderStyle-Font-Bold="true" HeaderText="Status" HeaderStyle-Width="8%"></asp:BoundField>
                                                        <asp:TemplateField HeaderText="Vesting Percent" HeaderStyle-Font-Bold="true" FooterStyle-Font-Bold="true"
                                                            HeaderStyle-Width="12%">
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblVPERCENTAGE" runat="server" Text='<%#Eval("VPERCENTAGE") %>' />
                                                                <asp:HiddenField ID="Hd_Id" runat="server" Value='<%# Bind("ID") %>' />
                                                                <asp:HiddenField ID="hdnGrantID" runat="server" Value='<%# Bind("grant_id") %>' />
                                                                <asp:HiddenField ID="hdnVestingID" runat="server" Value='<%# Bind("v_detail_id") %>' />
                                                                <asp:HiddenField ID="IsExpanded" runat="server" />
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Granted" HeaderStyle-CssClass="text-nowrap" HeaderStyle-Font-Bold="true" HeaderStyle-Width="8%">
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblVNAME" runat="server" Text='<%#Eval("GRANTED")%>' Visible="true"></asp:Label>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:BoundField DataField="VESTED" HeaderStyle-Font-Bold="true" HeaderText="Vested" HeaderStyle-Width="8%"></asp:BoundField>
                                                        <asp:BoundField DataField="VESTED_PENDING" HeaderStyle-Font-Bold="true" HeaderText="Pending for Vesting" HeaderStyle-Width="8%"></asp:BoundField>
                                                        <asp:BoundField DataField="EXERCISED" HeaderStyle-Font-Bold="true" HeaderText="Exercised" HeaderStyle-Width="8%"></asp:BoundField>
                                                        <asp:BoundField DataField="EXERCISED_PENDING" HeaderStyle-Font-Bold="true" HeaderText="Pending for Excercise" HeaderStyle-Width="8%"></asp:BoundField>
                                                        <asp:BoundField DataField="SALE" HeaderStyle-Font-Bold="true" HeaderText="Sale" HeaderStyle-Width="8%"></asp:BoundField>
                                                        <asp:BoundField DataField="LBV" HeaderStyle-Font-Bold="true" HeaderText="LBV" HeaderStyle-Width="6%"></asp:BoundField>
                                                        <asp:BoundField DataField="LAV" HeaderStyle-Font-Bold="true" HeaderText="LAV" HeaderStyle-Width="6%"></asp:BoundField>
                                                        <asp:BoundField DataField="TOTAL_LAPSE" HeaderStyle-Font-Bold="true" HeaderText="Total Lapsed" HeaderStyle-Width="8%"></asp:BoundField>
                                                        <asp:BoundField DataField="STOCK_IN_HAND" HeaderStyle-Font-Bold="true" HeaderText="Stock in Hand" HeaderStyle-Width="8%"></asp:BoundField>


                                                        <asp:TemplateField HeaderText="Vesting Date" HeaderStyle-Font-Bold="true" FooterStyle-Font-Bold="true"
                                                            HeaderStyle-Width="10%">
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblVESTING_DATE" runat="server" Text='<%#Eval("VESTING_DATE") %>' />
                                                            </ItemTemplate>
                                                        </asp:TemplateField>

                                                        <asp:TemplateField HeaderText="Lapse Date" HeaderStyle-CssClass="text-nowrap" HeaderStyle-Font-Bold="true" HeaderStyle-Width="8%">
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblLapseDt" runat="server" Text='<%#Eval("lapseDate")%>' Visible="true"></asp:Label>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                    </Columns>
                                                </asp:GridView>
                                            </ContentTemplate>
                                            <Triggers>
                                                <asp:AsyncPostBackTrigger ControlID="grdpendingapproval" />
                                                <asp:AsyncPostBackTrigger ControlID="btn_bulkApprove" EventName="Click" />
                                                <asp:AsyncPostBackTrigger ControlID="btn_bulkReject" EventName="Click" />
                                            </Triggers>
                                        </asp:UpdatePanel>
                                    </div>
                                </div>
                                <div class="tab-pane fade" id="contact3" role="tabpanel" aria-labelledby="contact-tab3">
                                    <div class="table-responsive" style="margin-top: 30px;">
                                        <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional">
                                            <%--UpdateMode="Conditional"--%>
                                            <ContentTemplate>
                                                <asp:GridView ID="grdreject" runat="server" OnPreRender="grdreject_PreRender" ShowHeaderWhenEmpty="false"
                                                    EmptyDataText="" AutoGenerateColumns="false" class="table" OnRowCommand="grdreject_RowCommand" DataKeyNames="ECODE,VESTED_PENDING,EXERCISED_PENDING">
                                                    <Columns>
                                                        <asp:TemplateField>
                                                            <HeaderTemplate>
                                                                <asp:CheckBox ID="checkAll" runat="server" />
                                                            </HeaderTemplate>
                                                            <ItemTemplate>
                                                                <asp:CheckBox runat="server" ID="chk" />
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Employee Name" HeaderStyle-CssClass="text-nowrap" HeaderStyle-Font-Bold="true" HeaderStyle-Width="12%" ItemStyle-CssClass="griditem1">
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblEmp" runat="server" Text='<%#Eval("EMP_NAME")%>' Visible="true"></asp:Label>

                                                                <asp:HiddenField ID="HdEmpCode" runat="server" Value='<%# Bind("ECODE") %>' />
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:BoundField DataField="ACTIVE" HeaderStyle-Font-Bold="true" HeaderText="Status" HeaderStyle-Width="8%"></asp:BoundField>
                                                        <asp:TemplateField HeaderText="Vesting Percent" HeaderStyle-Font-Bold="true" FooterStyle-Font-Bold="true"
                                                            HeaderStyle-Width="12%">
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblVPERCENTAGE" runat="server" Text='<%#Eval("VPERCENTAGE") %>' />
                                                                <asp:HiddenField ID="Hd_Id" runat="server" Value='<%# Bind("ID") %>' />
                                                                <asp:HiddenField ID="hdnGrantID" runat="server" Value='<%# Bind("grant_id") %>' />
                                                                <asp:HiddenField ID="hdnVestingID" runat="server" Value='<%# Bind("v_detail_id") %>' />
                                                                <asp:HiddenField ID="IsExpanded" runat="server" />
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Granted" HeaderStyle-CssClass="text-nowrap" HeaderStyle-Font-Bold="true" HeaderStyle-Width="8%">
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblVNAME" runat="server" Text='<%#Eval("GRANTED")%>' Visible="true"></asp:Label>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:BoundField DataField="VESTED" HeaderStyle-Font-Bold="true" HeaderText="Vested" HeaderStyle-Width="8%"></asp:BoundField>
                                                        <asp:BoundField DataField="VESTED_PENDING" HeaderStyle-Font-Bold="true" HeaderText="Pending for Vesting" HeaderStyle-Width="8%"></asp:BoundField>
                                                        <asp:BoundField DataField="EXERCISED" HeaderStyle-Font-Bold="true" HeaderText="Exercised" HeaderStyle-Width="8%"></asp:BoundField>
                                                        <asp:BoundField DataField="EXERCISED_PENDING" HeaderStyle-Font-Bold="true" HeaderText="Pending for Excercise" HeaderStyle-Width="8%"></asp:BoundField>
                                                        <asp:BoundField DataField="SALE" HeaderStyle-Font-Bold="true" HeaderText="Sale" HeaderStyle-Width="8%"></asp:BoundField>
                                                        <asp:BoundField DataField="LBV" HeaderStyle-Font-Bold="true" HeaderText="LBV" HeaderStyle-Width="6%"></asp:BoundField>
                                                        <asp:BoundField DataField="LAV" HeaderStyle-Font-Bold="true" HeaderText="LAV" HeaderStyle-Width="6%"></asp:BoundField>
                                                        <asp:BoundField DataField="TOTAL_LAPSE" HeaderStyle-Font-Bold="true" HeaderText="Total Lapsed" HeaderStyle-Width="8%"></asp:BoundField>
                                                        <asp:BoundField DataField="STOCK_IN_HAND" HeaderStyle-Font-Bold="true" HeaderText="Stock in Hand" HeaderStyle-Width="8%"></asp:BoundField>

                                                        <asp:TemplateField HeaderText="Vesting Date" HeaderStyle-Font-Bold="true" FooterStyle-Font-Bold="true"
                                                            HeaderStyle-Width="10%">
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblVESTING_DATE" runat="server" Text='<%#Eval("VESTING_DATE") %>' />
                                                            </ItemTemplate>
                                                        </asp:TemplateField>

                                                        <asp:TemplateField HeaderText="Lapse Date" HeaderStyle-CssClass="text-nowrap" HeaderStyle-Font-Bold="true" HeaderStyle-Width="8%">
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblLapseDt" runat="server" Text='<%#Eval("lapseDate")%>' Visible="true"></asp:Label>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Audit Trail" HeaderStyle-Width="12.5%">
                                                            <ItemTemplate>
                                                                <asp:LinkButton ID="btn_Audit_3" runat="server" CommandName="Audit" CausesValidation="true"
                                                                    CommandArgument="<%# ((GridViewRow) Container).RowIndex %>"
                                                                    CssClass="fas fa-info edit12"></asp:LinkButton>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                    </Columns>
                                                </asp:GridView>
                                            </ContentTemplate>
                                            <Triggers>
                                                <asp:AsyncPostBackTrigger ControlID="grdpendingapproval" />
                                                <asp:AsyncPostBackTrigger ControlID="btn_bulkApprove" EventName="Click" />
                                                <asp:AsyncPostBackTrigger ControlID="btn_bulkReject" EventName="Click" />
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
        <asp:UpdateProgress ID="UpdateProgress" runat="server" AssociatedUpdatePanelID="UpdatePanel6">
            <ProgressTemplate>
                <div id="overlay">
                    <div id="modalprogress">
                        <div id="theprogress">
                            <img src="assets/img/loading.gif" />
                        </div>
                    </div>
                </div>
            </ProgressTemplate>
        </asp:UpdateProgress>
        <asp:UpdateProgress ID="UpdateProgress1" runat="server" AssociatedUpdatePanelID="UpdatePanel2">
            <ProgressTemplate>
                <div id="overlay">
                    <div id="modalprogress">
                        <div id="theprogress">
                            <img src="assets/img/loading.gif" />
                        </div>
                    </div>
                </div>
            </ProgressTemplate>
        </asp:UpdateProgress>
    </div>

    <div class="modal bd-example-modal-lg" id="my_Grant_Up_Modal" tabindex="-1" role="dialog">
        <div class="modal-dialog modal-xl boxModalDiv">
            <!-- Modal content-->
            <div class="modal-content" style="width: 100%;">
                <div class="modal-header">
                    <h5 class="modal-title" id="myLargeModalLabel">Audit Trail
                    </h5>
                </div>
                <div class="col-lg-3 offset-md-3" style="padding-top: 12px; margin-left: 88%;">
                    <asp:ImageButton ID='imgExportAudit' runat='server' ImageUrl="~/img/excel1.png" Style="margin-left: 18px;" Height="35px" ToolTip="Export To Excel" OnClick="imgExportAudit_Click" />
                    <asp:ImageButton ID='btnExportPDF' runat='server' ImageUrl="~/img/pdf.png" Height="35px" ToolTip="Export To Pdf" OnClick="btnpdfexport_Click" />
                </div>
                <div class="card-body">
                    <div class="table-responsive">
                        <asp:UpdatePanel ID="UpdatePanel7" runat="server">
                            <ContentTemplate>
                                <asp:GridView ID="grdData" class="table table-striped table-hover" runat="server" Style="width: 98%;" OnPreRender="grdData_PreRender"
                                    AutoGenerateColumns="False" AllowPaging="false" AllowSorting="false" PageSize="10" OnPageIndexChanging="grdData_PageIndexChanging" OnRowDataBound="grdData_RowDataBound"
                                    EmptyDataText="No data found" AllowCustomPaging="false" ViewStateMode="Enabled">
                                    <Columns>
                                        <asp:TemplateField HeaderText="Grant Name" HeaderStyle-CssClass="text-nowrap" HeaderStyle-Font-Bold="true">
                                            <ItemStyle HorizontalAlign="Left" VerticalAlign="Top" Wrap="True" />
                                            <ItemTemplate>
                                                <asp:Label ID="lbl_grant_name" runat="server" Text='<%#Eval("grant_name") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Date of Grant" HeaderStyle-CssClass="text-nowrap" HeaderStyle-Font-Bold="true">
                                            <ItemStyle HorizontalAlign="Left" VerticalAlign="Top" Wrap="True" />
                                            <ItemTemplate>
                                                <asp:Label ID="lbl_ate_of_grant" runat="server" Text='<%#Eval("date_of_grant") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Employee Name" HeaderStyle-CssClass="text-nowrap" HeaderStyle-Font-Bold="true">
                                            <ItemStyle HorizontalAlign="Left" VerticalAlign="Top" Wrap="True" />
                                            <ItemTemplate>
                                                <asp:Label ID="lbl_Employee_Id" runat="server" Text='<%#Eval("Employee_Id") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="No of Options" HeaderStyle-CssClass="text-nowrap" HeaderStyle-Font-Bold="true">
                                            <ItemStyle HorizontalAlign="Left" VerticalAlign="Top" Wrap="True" />
                                            <ItemTemplate>
                                                <asp:Label ID="lbl_no_of_options" runat="server" Text='<%#Eval("no_of_options") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="PR Remark" HeaderStyle-CssClass="text-nowrap" HeaderStyle-Font-Bold="true">
                                            <ItemStyle HorizontalAlign="Left" VerticalAlign="Top" Wrap="True" />
                                            <ItemTemplate>
                                                <asp:Label ID="lbl_remark1" runat="server" Text='<%#Server.HtmlEncode(Eval("remark1").ToString()) %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="HR Remark" HeaderStyle-CssClass="text-nowrap" HeaderStyle-Font-Bold="true">
                                            <ItemStyle HorizontalAlign="Left" VerticalAlign="Top" Wrap="True" />
                                            <ItemTemplate>
                                                <asp:Label ID="lbl_remark2" runat="server" Text='<%#Server.HtmlEncode(Eval("remark2").ToString()) %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Checker Remark" HeaderStyle-CssClass="text-nowrap" HeaderStyle-Font-Bold="true">
                                            <ItemStyle HorizontalAlign="Left" VerticalAlign="Top" Wrap="True" />
                                            <ItemTemplate>
                                                <asp:Label ID="lbl_remark3" runat="server" Text='<%#Server.HtmlEncode(Eval("remark3").ToString()) %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Admin Updation Remark" HeaderStyle-CssClass="text-nowrap" HeaderStyle-Font-Bold="true">
                                            <ItemStyle HorizontalAlign="Left" VerticalAlign="Top" Wrap="True" />
                                            <ItemTemplate>
                                                <asp:Label ID="lbl_Admin_remark" runat="server" Text='<%#Server.HtmlEncode(Eval("ADMIN_GRANT_UPDATION_REMARK").ToString()) %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Admin Correction Remark" HeaderStyle-CssClass="text-nowrap" HeaderStyle-Font-Bold="true">
                                            <ItemStyle HorizontalAlign="Left" VerticalAlign="Top" Wrap="True" />
                                            <ItemTemplate>
                                                <asp:Label ID="lbl_Admin_remark_1" runat="server" Text='<%#Server.HtmlEncode(Eval("ADMIN_GRANT_CORRECTION_REJECTION_REMARK").ToString()) %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Created Date" HeaderStyle-CssClass="text-nowrap" HeaderStyle-Font-Bold="true">
                                            <ItemStyle HorizontalAlign="Left" VerticalAlign="Top" Wrap="True" />
                                            <ItemTemplate>
                                                <asp:Label ID="lbl_creation_date" runat="server" Text='<%#Eval("creation_date") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Created By" HeaderStyle-CssClass="text-nowrap" HeaderStyle-Font-Bold="true">
                                            <ItemStyle HorizontalAlign="Left" VerticalAlign="Top" Wrap="True" />
                                            <ItemTemplate>
                                                <asp:Label ID="lbl_created_by" runat="server" Text='<%#Eval("created_by") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>

                                        <asp:TemplateField HeaderText="Updated Date" HeaderStyle-CssClass="text-nowrap" HeaderStyle-Font-Bold="true">
                                            <ItemStyle HorizontalAlign="Left" VerticalAlign="Top" Wrap="True" />
                                            <ItemTemplate>
                                                <asp:Label ID="lbl_updatation_date" runat="server" Text='<%#Eval("updated_date") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Updated By" HeaderStyle-CssClass="text-nowrap" HeaderStyle-Font-Bold="true">
                                            <ItemStyle HorizontalAlign="Left" VerticalAlign="Top" Wrap="True" />
                                            <ItemTemplate>
                                                <asp:Label ID="lbl_updated_by" runat="server" Text='<%#Eval("updated_by") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>

                                        <asp:TemplateField HeaderText="Status" HeaderStyle-CssClass="text-nowrap" HeaderStyle-Font-Bold="true">
                                            <ItemStyle HorizontalAlign="Left" VerticalAlign="Top" Wrap="True" />
                                            <ItemTemplate>
                                                <asp:Label ID="lbl_Status" runat="server" Text='<%#Eval("Status") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Action" HeaderStyle-CssClass="text-nowrap" HeaderStyle-Font-Bold="true">
                                            <ItemStyle HorizontalAlign="Left" VerticalAlign="Top" Wrap="True" />
                                            <ItemTemplate>
                                                <asp:Label ID="lbl_Action" runat="server" Text='<%#Eval("ACTION") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Proxy" HeaderStyle-CssClass="text-nowrap" HeaderStyle-Font-Bold="true">
                                            <ItemStyle HorizontalAlign="Left" VerticalAlign="Top" Wrap="True" />
                                            <ItemTemplate>
                                                <asp:Label ID="lbl_proxy" runat="server" Text='<%#Eval("proxy") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                    </Columns>
                                    <PagerSettings FirstPageText="First" LastPageText="Last" NextPageText="Next" PreviousPageText="Previous" />

                                    <PagerStyle CssClass="text-right border-pagination" />
                                </asp:GridView>
                                <div class="clearfix"></div>

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

    <script type="text/javascript">
        function openModal2(srcval) {
           <%-- document.getElementById('<%=embed1.ClientID%>').src = "";
            document.getElementById('<%=embed1.ClientID%>').src = srcval;--%>
            $('#myModal1').modal('show');
        }
    </script>

    <script type="text/javascript">
        function openModalShowAudit() {
            debugger;
            $('#my_Grant_Up_Modal').modal('show');
        }
    </script>
    <!-- General JS Scripts -->
    <script src="Scripts/bootstrap.min.js"></script>

    <script src="assets/js/app.min.js"></script>

    <script src="assets/js/scripts.js"></script>


    <script type="text/javascript">
        //$('#ContentPlaceHolder1_grdpendingapproval').clear().draw();
        var prm = Sys.WebForms.PageRequestManager.getInstance();
        prm.add_endRequest(function (sender, e) {
            var table = $('#ContentPlaceHolder1_grdpendingapproval').DataTable({
                lengthMenu: [[-1, 5, 10], ["All", 5, 10]],
                order: [],
                columnDefs: [{ orderable: false, targets: [0, 9, 10, 11] }],
                bRetrieve: true
            });
        });

        $(function () {
            $.noConflict();
            debugger;
            var table = $('#ContentPlaceHolder1_grdpendingapproval').DataTable({
                bLengthChange: true,
                lengthMenu: [[-1, 5, 10], ["All", 5, 10]],
                bFilter: true,
                //order: [],
                columnDefs: [{ orderable: false, targets: [0, 9, 10, 11, 12] }],
                bPaginate: true,
                "aaSorting": [[4, "desc"]]
            });
        });
    </script>



    <script type="text/javascript">
        var prm = Sys.WebForms.PageRequestManager.getInstance();
        prm.add_endRequest(function (sender, e) {
            var table = $('#ContentPlaceHolder1_grdapproval').DataTable({
                lengthMenu: [[-1, 5, 10], ["All", 5, 10]],
                'columnDefs': [{
                    'targets': [11],
                    'orderable': false,
                }],

                bRetrieve: true, fixedHeader: true, "scrollX": true
            });
            table
.search('')
.columns().search('')
.draw();
        });
        $(function () {
            var table = $("#ContentPlaceHolder1_grdapproval").DataTable({
                bLengthChange: true,
                lengthMenu: [[-1, 5, 10], ["All", 5, 10]],
                bFilter: true,
                'columnDefs': [{
                    'targets': [11],
                    'orderable': false,
                }],

                bPaginate: true, "aaSorting": [[4, "desc"]], fixedHeader: true, "scrollX": true
            });
            table
.search('')
.columns().search('')
.draw();
        });
    </script>

    <script type="text/javascript">
        //$('#ContentPlaceHolder1_grdreject').clear().draw();
        var prm = Sys.WebForms.PageRequestManager.getInstance();
        prm.add_endRequest(function (sender, e) {
            var table = $('#ContentPlaceHolder1_grdreject').DataTable({
                lengthMenu: [[-1, 5, 10], ["All", 5, 10]],
                'columnDefs': [{
                    'targets': [11],
                    'orderable': false,
                }],
                bRetrieve: true, fixedHeader: true, "scrollX": true
            });
            table
.search('')
.columns().search('')
.draw();
        });
        $(function () {
            var table = $('#ContentPlaceHolder1_grdreject').DataTable({
                bLengthChange: true,
                lengthMenu: [[-1, 5, 10], ["All", 5, 10]],
                bFilter: true,
                'columnDefs': [{
                    'targets': [11],
                    'orderable': false,
                }],
                bPaginate: true, "aaSorting": [[3, "desc"]], fixedHeader: true, "scrollX": true
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

            $('#ContentPlaceHolder1_grdData').dataTable({
                lengthMenu: [[-1, 5, 10], ["All", 5, 10]],
                columnDefs: [{ orderable: false, targets: [] }],

                bRetrieve: true, fixedHeader: true, "scrollX": true
            });

        });
        $(function () {
            //$.noConflict();

            $("#ContentPlaceHolder1_grdData").DataTable({
                bLengthChange: true,
                lengthMenu: [[-1, 5, 10], ["All", 5, 10]],
                bFilter: true,
                //'columnDefs': [{
                //    'targets': [7],
                //    'orderable': false,
                //}],

                order: [],
                columnDefs: [{ orderable: false, targets: [] }],
                bPaginate: true,
                bSort: true,
                fixedHeader: true, "scrollX": true
            });



        });
    </script>


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
    <script>
        function Count(text) {
            // alert();
            //asp.net textarea maxlength doesnt work; do it by hand
            var maxlength = 500; //set your value here (or add a parm and pass it in)
            var object = document.getElementById(text.id)  //get your object
            if (object.value.length > maxlength) {
                object.focus(); //set focus to prevent jumping
                object.value = text.value.substring(0, maxlength); //truncate the value
                object.scrollTop = object.scrollHeight; //scroll to the end to prevent jumping
                return false;
            }
            return true;
        }

    </script>

</asp:Content>
