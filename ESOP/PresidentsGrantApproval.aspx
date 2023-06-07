<%@ Page Title="" Language="C#" MasterPageFile="~/ESOP.Master" AutoEventWireup="true" CodeBehind="PresidentsGrantApproval.aspx.cs" Inherits="ESOP.PresidentsGrantApproval" EnableEventValidation="false" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
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
        .edit12 {
            padding: 10px;
            background: #2573ff;
            color: white !important;
            border-radius: 4px;
            line-height: 0;
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

        .table th {
            color: #000 !important;
            font-weight: 600 !important;
        }

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

        .sidebar-mini .main-content, .sidebar-mini .main-footer {
            padding-left: 55px !important;
        }

        .modal-backdrop.in {
            display: block;
            opacity: 0.4;
        }
    </style>

    <script>

        function CheckAll(objRef) {

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


    <%-- <script type="text/javascript" src="https://ajax.googleapis.com/ajax/libs/jquery/1.8.3/jquery.min.js"></script>
    <script type="text/javascript" src="https://cdn.datatables.net/1.10.20/js/jquery.dataTables.min.js"></script>--%>
    <script src="assets/js/jquery-1.8.3.min.js" type="text/javascript"></script>
    <script src="assets/js/jquery.dataTables-1.10.20.min.js" type="text/javascript"></script>
    <link href="Scripts/jquery.dataTables.min.css" rel="stylesheet" />
    <link href="Scripts/dataTables.bootstrap4.min.css" rel="stylesheet" />

    <script>
        function DownloadFile(filepath) {
            __doPostBack("<%= BtnDownload.UniqueID %>", filepath);
        }
    </script>

    <script type="text/javascript">
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
                            // return true;
                            //  } else {
                            return true;
                            //  }

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
                            //    return true;
                            //  } else {
                            return true;
                            //  }

                        }
                    }
                }
            }
            alert("Please select atleast one checkbox");
            return false;
        }

    </script>
    <%--    <script>
        function ValidateCheckBoxesapprove() {
            debugger;
            // var isValid = false;
            var gridView = document.getElementById('<%= GrvPendingforApproval.ClientID %>');
            //  for (var i = 1; i < gridView.rows.length; i++) {
            // var inputs = gridView.rows[i].getElementsByTagName('input');
            // if (inputs != null) {
            // if (inputs[0].type == "checkbox") {
            //   if (inputs[0].checked) {
            //     isValid = true;
            //  return confirm('Are you sure want to reject record?');
            if (confirm("Are you sure want to approve record?")) {
                return true;
            } else {
                return false;
            }

            //  }
            // }
            // }
            //  }
            // alert("Please select checkbox");
            return false;
        }

        function validateCheckBoxes() {
            debugger;
            //   var isValid = false;
            var gridView = document.getElementById('<%= GrvPendingforApproval.ClientID %>');
            // for (var i = 1; i < gridView.rows.length; i++) {
            //  var inputs = gridView.rows[i].getElementsByTagName('input');
            //  if (inputs != null) {
            //   if (inputs[0].type == "checkbox") {
            //   if (inputs[0].checked) {
            //  isValid = true;
            //  return confirm('Are you sure want to reject record?');
            if (confirm("Are you sure want to reject record?")) {
                return true;
            } else {
                return false;
            }

            //  }
            //  }
            //  }
            //  }
            // alert("Please select checkbox");
            return false;
        }
    </script>--%>

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
                $("[id*='CheckBox1']").attr('checked', this.checked);
            });
        });

        var prm = Sys.WebForms.PageRequestManager.getInstance();
        prm.add_endRequest(function () {
            $('[id*=checkAll]').click(function () {
                debugger;
                $("[id*='CheckBox1']").attr('checked', this.checked);
            });
        });

    </script>


    <div class="main-content" style="padding-top: 55px; padding-left: 40px; padding-right: 10px;">
        <nav aria-label="breadcrumb">
            <ol class="breadcrumb">
                <li class="breadcrumb-item"><a href="president-dashboard.aspx">Home</a></li>
                <li class="breadcrumb-item"><a href="approval.aspx">Approval</a></li>
                <li class="breadcrumb-item active" aria-current="page">Grant Approval</li>
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

                                                <asp:Label ID="lbltotal_grant" runat="server" Text="0"></asp:Label>
                                            </h3>
                                            <span class="text-muted">Total Grants</span>
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
                                                <asp:UpdatePanel ID="UpdatePanel6" runat="server" UpdateMode="Conditional">
                                                    <ContentTemplate>
                                                        <asp:Label ID="lbl_approved" runat="server" Text="0"></asp:Label>
                                                    </ContentTemplate>
                                                    <Triggers>
                                                        <asp:AsyncPostBackTrigger ControlID="GrvPendingforApproval" />
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
                                                <asp:UpdatePanel ID="UpdatePanel4" runat="server" UpdateMode="Conditional">
                                                    <ContentTemplate>
                                                        <asp:Label ID="lbl_rejected" runat="server" Text="0"></asp:Label>
                                                    </ContentTemplate>
                                                    <Triggers>
                                                        <asp:AsyncPostBackTrigger ControlID="GrvPendingforApproval" />
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
                                                <asp:UpdatePanel ID="UpdatePanel5" runat="server" UpdateMode="Conditional">
                                                    <ContentTemplate>
                                                        <i class="ti-arrow-up text-success"></i>
                                                        <asp:Label ID="lbl_approval_pending" runat="server" Text="0"></asp:Label>
                                                    </ContentTemplate>
                                                    <Triggers>
                                                        <asp:AsyncPostBackTrigger ControlID="GrvPendingforApproval" />
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
                        <asp:UpdatePanel ID="UpdatePanel7" runat="server" UpdateMode="Conditional">
                            <ContentTemplate>
                                <div class="card-header">
                                    <h4>President Grant Approval List</h4>
                                    <div class="offset-md-7 buttons" style="margin-left: 56.333333%" id="showhidebtn">
                                        <asp:Button ID="btn_bulkApprove" runat="server" CommandName="Bulk Approve" CausesValidation="false" OnClick="BtnBulkApprove_Click" OnClientClick="return bulkvalidateCheckBoxesapprove();"
                                            Text="Bulk Approve" CssClass="btn badge badge-success badge-shadow"></asp:Button>
                                        <asp:Button ID="btn_bulkReject" runat="server" CommandName="Bulk Reject" CausesValidation="false" OnClick="BtnBulkReject_Click" OnClientClick="return bulkvalidateCheckBoxesreject();"
                                            Text="Bulk Reject" CssClass="btn badge badge-danger badge-shadow"></asp:Button>
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
                                    <div class="table-responsive" style="margin-top: 2px;">

                                        <asp:UpdatePanel ID="UpdatePanel2" runat="server" UpdateMode="Conditional">
                                            <ContentTemplate>
                                                <div id="showmsg" runat="server"></div>
                                                <asp:GridView ID="GrvPendingforApproval" runat="server" AutoGenerateColumns="False" PageSize="25" ShowHeaderWhenEmpty="false"
                                                    class="table dataTable no-footer" DataKeyNames="GRANT_ID,EmployeeID,LETTERID,GRANT_NAME,EmployeeName,GrantPrice" OnRowCommand="GrvPendingforApproval_RowCommand"
                                                    OnPreRender="GrvPendingforApproval_PreRender" EmptyDataText="" Width="100%">
                                                    <Columns>
                                                        <asp:TemplateField>
                                                            <HeaderTemplate>
                                                                <asp:CheckBox ID="checkAll" runat="server" />
                                                                <%--  <asp:CheckBox runat="server" ID="chk2" onclick="checkAll(this);" CssClass="custom-control-label" />--%>
                                                            </HeaderTemplate>
                                                            <ItemTemplate>
                                                                <asp:CheckBox runat="server" ID="CheckBox1" />
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:BoundField DataField="EmployeeID" HeaderText="Emp ID" />
                                                        <asp:BoundField DataField="EmployeeName" HeaderText="Emp Name" ItemStyle-Width="10%"  HeaderStyle-Wrap="true" ItemStyle-Wrap="true" />
                                                        <asp:BoundField DataField="ManagerName" HeaderText="Manager Name" />
                                                        <asp:BoundField HeaderText="Grant Name" DataField="GRANT_NAME" />
                                                        <asp:BoundField DataField="Date_of_Grant" HeaderText="Grant Date" />
                                                        <asp:BoundField DataField="NoofGrants" HeaderText="Total Grant" />
                                                        <asp:BoundField DataField="GrantPrice" HeaderText="Grant Price" />
                                                        <asp:BoundField HeaderText="Approver" DataField="Approved_By" SortExpression="Approved_By" />
                                                        <asp:BoundField HeaderText="Approved Date" DataField="UPDATATION_DATE" SortExpression="UPDATATION_DATE" />
                                                        <asp:TemplateField HeaderText="Grant Letter">
                                                            <ItemTemplate>
                                                                 <table>
                                                                    <tr> <td>
                                                                <asp:HiddenField ID="HiddenField1" runat="server" Value='<%# Bind("filepath") %>' />
                                                                <asp:LinkButton ID="btn_Preview" runat="server" CausesValidation="false" CommandName="Preview" OnClick="btn_Preview_Click"
                                                                    CssClass="btn btn-icon btn-success fas fa-eye" CommandArgument='<%# Eval("FILEPath") %>'></asp:LinkButton>
                                                                 </td>
                                                                         <td>
                                                                        <asp:LinkButton ID="lb_download" runat="server" CommandArgument='<%# Eval("FILEPath") %>' CausesValidation="false"
                                                                    class="btn btn-icon btn-primary fas fa-arrow-down" OnClick="lb_download_Click"></asp:LinkButton>
                                                                              </td>
                                                                        </tr>
                                                                    </table>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                         <asp:TemplateField HeaderText="Remark">
                                                            <ItemTemplate>
                                                                <div class="remark">
                                                                    <asp:TextBox ID="TxtRemarkPend_Approval" ondrop="return false;" ondrag="return false;" runat="server" placeholder="Enter Remark"
                                                                        TextMode="MultiLine" onKeyUp="javascript:Count(this);"
                                                                        onChange="javascript:Count(this);" Width="90px"></asp:TextBox>
                                                                </div>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Action">
                                                            <ItemTemplate>
                                                                <div class="btn-group">
                                                                    <%-- <div class="offset-md-7" style="margin-left: -4px">--%>
                                                                    <asp:Button ID="BtnGrvBulkApprove" runat="server" CommandName="Approve" CausesValidation="false" CommandArgument='<%# Eval("GRANT_ID")+","+Eval("LETTERID") %>' OnClientClick="return ValidateCheckBoxesapprove();"
                                                                        Text="Approve" CssClass="btn badge badge-success badge-shadow"></asp:Button>
                                                                    <asp:Button ID="BtnGrvBulkReject" runat="server" CommandName="Reject" CausesValidation="false" CommandArgument='<%# Eval("GRANT_ID") %>'
                                                                        Text="Reject" CssClass="btn badge badge-danger badge-shadow" OnClientClick="return validateCheckBoxes();"></asp:Button>
                                                                </div>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Audit" HeaderStyle-Width="12.5%">
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
                                                <asp:AsyncPostBackTrigger ControlID="GrvPendingforApproval" />
                                                <asp:AsyncPostBackTrigger ControlID="btn_bulkApprove" EventName="Click" />
                                                <asp:AsyncPostBackTrigger ControlID="btn_bulkReject" EventName="Click" />
                                            </Triggers>
                                        </asp:UpdatePanel>
                                        <asp:button id="BtnDownload" onclick="DownloadFile_Click" runat="server" visible="false" xmlns:asp="#unknown" />

                                    </div>
                                </div>
                                <div class="tab-pane fade" id="profile3" role="tabpanel" aria-labelledby="profile-tab3">
                                    <div class="table-responsive" style="margin-top: 30px;">
                                        <asp:UpdatePanel ID="upd" runat="server" UpdateMode="Conditional">
                                            <ContentTemplate>
                                                <asp:GridView ID="GrvApproved" runat="server" OnPreRender="GrvApproved_PreRender" ShowHeaderWhenEmpty="false"
                                                    AutoGenerateColumns="false" PageSize="25" class="table" EmptyDataText="" DataKeyNames="GRANT_ID,EmployeeID" OnRowCommand="GrvApproved_RowCommand">
                                                    <Columns>
                                                        <asp:BoundField DataField="EmployeeID" HeaderText="Employee ID" />
                                                        <asp:BoundField DataField="EmployeeName" HeaderText="Employee Name" />
                                                        <asp:BoundField DataField="ManagerName" HeaderText="Manager Name" />
                                                        <asp:BoundField HeaderText="Grant Name" DataField="GRANT_NAME" />

                                                        <asp:BoundField DataField="Date_of_Grant" HeaderText="Date of Grant" />
                                                        <asp:BoundField DataField="NoofGrants" HeaderText="No. of Grants" />
                                                        <asp:BoundField DataField="GrantPrice" HeaderText="Grant Price" />
                                                        <asp:BoundField HeaderText="Approved By" DataField="Approved_By" SortExpression="Approved_By" />
                                                        <asp:BoundField HeaderText="Approved Date" DataField="UPDATATION_DATE" SortExpression="UPDATATION_DATE" />
                                                        <asp:BoundField DataField="Remark" HeaderText="Remark" />

                                                        <%-- <asp:TemplateField HeaderText="Remark">
                                                            <ItemTemplate>
                                                                <asp:Label ID="TxtRemarkPend_Approval" runat="server" Text='<%# Eval("Remark") %>' ReadOnly="true"></asp:Label>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>--%>
                                                        <asp:TemplateField HeaderText="Audit Trail" HeaderStyle-Width="12.5%">
                                                            <ItemTemplate>
                                                                <asp:LinkButton ID="btn_Audit_2" runat="server" CommandName="Audit" CausesValidation="true"
                                                                    CommandArgument="<%# ((GridViewRow) Container).RowIndex %>"
                                                                    CssClass="fas fa-info edit12"></asp:LinkButton>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                    </Columns>
                                                </asp:GridView>
                                            </ContentTemplate>
                                            <Triggers>
                                                <asp:AsyncPostBackTrigger ControlID="GrvPendingforApproval" />
                                                <asp:AsyncPostBackTrigger ControlID="btn_bulkApprove" EventName="Click" />
                                                <asp:AsyncPostBackTrigger ControlID="btn_bulkReject" EventName="Click" />
                                            </Triggers>
                                        </asp:UpdatePanel>
                                    </div>
                                </div>
                                <div class="tab-pane fade" id="contact3" role="tabpanel" aria-labelledby="contact-tab3">
                                    <div class="table-responsive" style="margin-top: 30px;">
                                        <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional">
                                            <ContentTemplate>
                                                <asp:GridView ID="GrvReject" runat="server" OnPreRender="GrvReject_PreRender" ShowHeaderWhenEmpty="false"
                                                    AutoGenerateColumns="false" PageSize="25" class="table" EmptyDataText="" DataKeyNames="GRANT_ID,EmployeeID" OnRowCommand="GrvReject_RowCommand">
                                                    <Columns>
                                                        <asp:BoundField DataField="EmployeeID" HeaderText="Employee ID" />
                                                        <asp:BoundField DataField="EmployeeName" HeaderText="Employee Name" />
                                                        <asp:BoundField DataField="ManagerName" HeaderText="Manager Name" />
                                                        <asp:BoundField HeaderText="Grant Name" DataField="GRANT_NAME" />

                                                        <asp:BoundField DataField="Date_of_Grant" HeaderText="Date of Grant" />
                                                        <asp:BoundField DataField="NoofGrants" HeaderText="No. of Grants" />
                                                        <asp:BoundField DataField="GrantPrice" HeaderText="Grant Price" />
                                                        <asp:BoundField HeaderText="Rejected By" DataField="Rejected_By" SortExpression="Rejected_By" />
                                                        <asp:BoundField HeaderText="Rejected Date" DataField="UPDATATION_DATE" SortExpression="UPDATATION_DATE" />
                                                        <asp:BoundField HeaderText="Pending With" DataField="Pending_with" SortExpression="Pending_with" />
                                                        <asp:BoundField DataField="Remark" HeaderText="Remark" />

                                                        <%-- <asp:TemplateField HeaderText="Remark">
                                                            <ItemTemplate>
                                                                <asp:Label ID="TxtRemarkPend_Approval" runat="server" Text='<%# Eval("Remark") %>' ReadOnly="true"></asp:Label>

                                                                <%--                                                                <asp:TextBox ID="TxtRemarkPend_Approval" runat="server" Text='<%# Eval("Remark") %>' ReadOnly="true"></asp:TextBox>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>--%>
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
                                                <asp:AsyncPostBackTrigger ControlID="GrvPendingforApproval" />
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
        <asp:UpdateProgress ID="UpdateProgress" runat="server" AssociatedUpdatePanelID="UpdatePanel7">
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
                        <asp:UpdatePanel ID="UpdatePanel3" runat="server">
                            <ContentTemplate>
                                <asp:GridView ID="grdData" class="table" runat="server" Style="width: 98%;" OnPreRender="grdData_PreRender"
                                    AutoGenerateColumns="False" AllowPaging="false" PageSize="10" AllowSorting="false" OnPageIndexChanging="grdData_PageIndexChanging" OnRowDataBound="grdData_RowDataBound"
                                    EmptyDataText="No data found" AllowCustomPaging="false" ViewStateMode="Enabled">
                                    <Columns>
                                        <asp:TemplateField HeaderText="Grant Name">

                                            <ItemTemplate>
                                                <asp:Label ID="lbl_grant_name" runat="server" Text='<%#Eval("grant_name") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Date of Grant">

                                            <ItemTemplate>
                                                <asp:Label ID="lbl_ate_of_grant" runat="server" Text='<%#Eval("date_of_grant") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Employee Name">

                                            <ItemTemplate>
                                                <asp:Label ID="lbl_Employee_Id" runat="server" Text='<%#Eval("Employee_Id") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="No of Options">

                                            <ItemTemplate>
                                                <asp:Label ID="lbl_no_of_options" runat="server" Text='<%#Eval("no_of_options") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="PR Remark">

                                            <ItemTemplate>
                                                <asp:Label ID="lbl_remark1" runat="server" Text='<%#Server.HtmlEncode(Eval("remark1").ToString()) %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="HR Remark">

                                            <ItemTemplate>
                                                <asp:Label ID="lbl_remark2" runat="server" Text='<%#Server.HtmlEncode(Eval("remark2").ToString()) %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Checker Remark">

                                            <ItemTemplate>
                                                <asp:Label ID="lbl_remark3" runat="server" Text='<%#Server.HtmlEncode(Eval("remark3").ToString()) %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Admin Updation Remark">

                                            <ItemTemplate>
                                                <asp:Label ID="lbl_Admin_remark" runat="server" Text='<%#Server.HtmlEncode(Eval("ADMIN_GRANT_UPDATION_REMARK").ToString()) %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>

                                        <asp:TemplateField HeaderText="Admin Correction Remark">
                                            <ItemTemplate>
                                                <asp:Label ID="lbl_Admin_remark_1" runat="server" Text='<%#Server.HtmlEncode(Eval("ADMIN_GRANT_CORRECTION_REJECTION_REMARK").ToString()) %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>


                                        <asp:TemplateField HeaderText="Created Date">

                                            <ItemTemplate>
                                                <asp:Label ID="lbl_creation_date" runat="server" Text='<%#Eval("creation_date") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Created By">

                                            <ItemTemplate>
                                                <asp:Label ID="lbl_created_by" runat="server" Text='<%#Eval("created_by") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>

                                        <asp:TemplateField HeaderText="Updated Date">

                                            <ItemTemplate>
                                                <asp:Label ID="lbl_updatation_date" runat="server" Text='<%#Eval("updated_date") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Updated By">

                                            <ItemTemplate>
                                                <asp:Label ID="lbl_updated_by" runat="server" Text='<%#Eval("updated_by") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>

                                        <asp:TemplateField HeaderText="Status">

                                            <ItemTemplate>
                                                <asp:Label ID="lbl_Status" runat="server" Text='<%#Eval("Status") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Action">

                                            <ItemTemplate>
                                                <asp:Label ID="lbl_Action" runat="server" Text='<%#Eval("ACTION") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Proxy">

                                            <ItemTemplate>
                                                <asp:Label ID="lbl_proxy" runat="server" Text='<%#Eval("proxy") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
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
    <script type="text/javascript">
        function openModalShowAudit() {
            debugger;
            $('#my_Grant_Up_Modal').modal('show');
        }
    </script>
   

     <%--  <div class="modal fade bd-example-modal-lg1" id="myModal11" tabindex="-1" role="dialog" aria-labelledby="myLargeModalLabel" style="display: none;" aria-hidden="true">--%>
        <div class="modal bd-example-modal-lg1" id="myModal_GrantLetter" tabindex="-1" role="dialog">
        <div class="modal-dialog modal-lg" style="max-width: 900px;">
            <asp:UpdatePanel runat="server">
                <ContentTemplate>
                    <div class="modal-content">
                        <div class="modal-header">
                            <h5 class="modal-title" id="myLargeModalLabel_Grant">Preview </h5>
                        </div>
                        <div class="modal-body" style="padding-left: 15px; padding-right: 15px;">
                            <div class="row popRow" style="">
                                <embed runat="server" id="embed1" width="100%" height="500" alt="pdf" pluginspage="http://www.adobe.com/products/acrobat/readstep2.html" />
                            </div>
                        </div>
                        <div class="modal-footer bg-whitesmoke br">
                            <div class="btn-group" role="group" aria-label="Basic example">
                                <%--<button type="button" class="btn btn-primary" data-dismiss="modal" style="margin-right: 44%; width: 40px;" id="Submit">OK</button>--%>
                                <a href="#" class="btn btn-info btn-lg all CloseBtnNew" data-dismiss="modal">Close</a>

                            </div>
                        </div>
                    </div>
                </ContentTemplate>
            </asp:UpdatePanel>
        </div>
    </div>


    <script type="text/javascript">
        function openModal2(srcval) {
            debugger;
            document.getElementById('<%=embed1.ClientID%>').src = "";
            document.getElementById('<%=embed1.ClientID%>').src = srcval;
            $('#myModal_GrantLetter').modal('show');
        }
    </script>
    <!-- General JS Scripts -->
    <script src="Scripts/bootstrap.min.js"></script>

    <script src="assets/js/app.min.js"></script>
    <%-- <!-- JS Libraies -->
    <script src="assets/bundles/echart/echarts.js"></script>
    <!-- Page Specific JS File -->
    <script src="assets/js/page/chart-hr.js"></script>
    <!-- Page Specific JS File -->
    <script src="assets/js/page/index.js"></script>
    <!-- Template JS File -->--%>
    <script src="assets/js/scripts.js"></script>
    <%--  <script src="assets/bundles/jquery.sparkline.min.js"></script>
    <!-- JS Libraies -->
    <script src="assets/bundles/datatables/datatables.min.js"></script>
    <script src="assets/bundles/datatables/DataTables-1.10.16/js/dataTables.bootstrap4.min.js"></script>
    <script src="assets/bundles/jquery-ui/jquery-ui.min.js"></script>
    <!-- Page Specific JS File -->
    <script src="assets/js/page/datatables.js"></script>--%>


    <script type="text/javascript">
        // $('#ContentPlaceHolder1_GrvPendingforApproval').clear().draw();
        var prm = Sys.WebForms.PageRequestManager.getInstance();

        prm.add_endRequest(function (sender, e) {

            var table = $('#ContentPlaceHolder1_GrvPendingforApproval').DataTable({
                order: [],
                lengthMenu: [[-1, 5, 10], ["All", 5, 10]],
                columnDefs: [{ orderable: false, targets: [0, 10, 11, 12] }],
                bRetrieve: true, fixedHeader: true, "scrollX": true
            });
            table
.search('')
.columns().search('')
.draw();
        });

        $(function () {
            $.noConflict();
            debugger;
            var table = $('#ContentPlaceHolder1_GrvPendingforApproval').DataTable({
                bLengthChange: true,
                lengthMenu: [[-1, 5, 10], ["All", 5, 10]],
                bFilter: true,
                //'columnDefs': [{
                //    'targets': [0, 7, 8],
                //    'orderable': false,
                //}],
                order: [],
                columnDefs: [{ orderable: false, targets: [0, 10, 11, 12] }],
                bPaginate: true, fixedHeader: true, "scrollX": true

            });
            table
.search('')
.columns().search('')
.draw();
        });
    </script>

    <script>
        // $('#ContentPlaceHolder1_GrvApproved').clear().draw();
        var prm = Sys.WebForms.PageRequestManager.getInstance();

        prm.add_endRequest(function (sender, e) {
            var table = $('#ContentPlaceHolder1_GrvApproved').DataTable({
                lengthMenu: [[-1, 5, 10], ["All", 5, 10]],
                columnDefs: [{ orderable: false, targets: [10] }],
                bRetrieve: true, //fixedHeader: true, "scrollX": true
            });
            table
.search('')
.columns().search('')
.draw();
        });

        $(function () {
            var table = $("#ContentPlaceHolder1_GrvApproved").DataTable({
                bLengthChange: true,
                lengthMenu: [[-1, 5, 10], ["All", 5, 10]],
                bFilter: true,
                'columnDefs': [{
                    'targets': [10],
                    'orderable': false,
                }],
                //bSort:true,
                bPaginate: true,// fixedHeader: true, "scrollX": true
            });
            table
.search('')
.columns().search('')
.draw();
        });
    </script>


    <script>
        //   $('#ContentPlaceHolder1_GrvReject').clear().draw();
        var prm = Sys.WebForms.PageRequestManager.getInstance();

        prm.add_endRequest(function (sender, e) {
            var table = $('#ContentPlaceHolder1_GrvReject').DataTable({
                lengthMenu: [[-1, 5, 10], ["All", 5, 10]],
                columnDefs: [{ orderable: false, targets: [11] }],
                bRetrieve: true,// fixedHeader: true, "scrollX": true
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
                    'targets': [11],
                    'orderable': false,
                }],
                bPaginate: true,// fixedHeader: true, "scrollX": true
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

            <%--  var rowcount = $("#<%=grdpendingapproval.ClientID %>").length;
            debugger;
            if (rowcount == 2) {
                $(".buttons").css({ 'display': 'none' });
            }
            else {
                $(".buttons").css({ 'display': 'block' });
            }--%>
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
