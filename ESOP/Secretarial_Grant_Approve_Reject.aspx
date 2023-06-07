<%@ Page Title="" Language="C#" MasterPageFile="~/ESOP.Master" AutoEventWireup="true" CodeBehind="Secretarial_Grant_Approve_Reject.aspx.cs" Inherits="ESOP.Secretarial_Grant_Approve_Reject" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
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
        function DownloadFile(filepath) {
            __doPostBack("<%= BtnDownload.UniqueID %>", filepath);
        }
    </script>

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
        $(document).ready(function () {

            $('.CloseBtnNew').click(function () {
                // alert('test');

                $("#myModal").removeClass("show");
                $("#myModal").hide();
                $(".modal-backdrop").remove();
                //$("#myModal").hide();
                $("body").removeClass("modal-open");
                // $("#myModal1").modal("hide");
                $("#my_Grant_Up_Modal").hide();          //Added by Krutika on 15-06-22 to hide modal
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

    <script type="text/javascript">

        function uploadStart(sender, args) {
            var filename = args.get_fileName();
            var filext = filename.substring(filename.lastIndexOf(".") + 1);
            if (filext == "xlx" || filext == "xlsx") {
                var a = sender.get_id()

                return true;
            }
            else {

                var a = sender.get_id()

                return false;
            }
        }

    </script>



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

    <script type="text/javascript">
        function UploadFile(_id) {
            document.getElementById('ContentPlaceHolder1_hdnFileIndex').value = _id;
            document.getElementById('ContentPlaceHolder1_btn_Upload').click();
        }
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

    <!-- Main Content -->
    <div class="main-content">


        <nav aria-label="breadcrumb">

            <ol class="breadcrumb">
                <li class="breadcrumb-item"><a href="Secretarial_Approvals.aspx">Home</a></li>
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
                                                <asp:UpdatePanel ID="UpdatePanel3" runat="server">
                                                    <%----%>
                                                    <ContentTemplate>
                                                        <asp:Label ID="lbl_approved" runat="server" Text="0"></asp:Label>
                                                    </ContentTemplate>
                                                    <Triggers>
                                                        <asp:PostBackTrigger ControlID="grdpendingapproval" />
                                                        <asp:PostBackTrigger ControlID="grdapproval" />
                                                        <%--Commented by Krutika on 14-01-23--%>
                                                        <%--<asp:AsyncPostBackTrigger ControlID="btn_bulkApprove" EventName="Click" />--%>
                                                        <%--Added by Krutika on 14-01-23--%>
                                                        <asp:PostBackTrigger ControlID="btn_bulkApprove" />
                                                        <%--End--%>
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
                                                        <asp:PostBackTrigger ControlID="grdpendingapproval" />
                                                        <asp:PostBackTrigger ControlID="grdapproval" />
                                                        <%--Commented by Krutika on 14-01-23--%>
                                                        <%--<asp:AsyncPostBackTrigger ControlID="btn_bulkApprove" EventName="Click" />--%>
                                                        <%--Added by Krutika on 14-01-23--%>
                                                        <asp:PostBackTrigger ControlID="btn_bulkApprove" />
                                                        <%--End--%>
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
                                                        <asp:PostBackTrigger ControlID="grdpendingapproval" />
                                                        <asp:PostBackTrigger ControlID="grdapproval" />
                                                        <%--Commented by Krutika on 14-01-23--%>
                                                        <%--<asp:AsyncPostBackTrigger ControlID="btn_bulkApprove" EventName="Click" />--%>
                                                        <%--Added by Krutika on 14-01-23--%>
                                                        <asp:PostBackTrigger ControlID="btn_bulkApprove" />
                                                        <%--End--%>
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
                                    <h4>Secretarial Grant Approval</h4>

                                    <div class="offset-md-7 buttons" style="margin-left: 56.333333%" id="showhidebtn">
                                        <asp:Button ID="btn_bulkApprove" runat="server" OnClick="btn_bulkApprove_Click" CausesValidation="true"
                                            Text="Bulk Approve" CssClass="btn badge badge-success badge-shadow" OnClientClick="bulkvalidateCheckBoxesapprove"></asp:Button>
                                        <asp:Button ID="btn_bulkReject" runat="server" OnClick="btn_bulkReject_Click" OnClientClick="bulkvalidateCheckBoxesreject" CausesValidation="true"
                                            Text="Bulk Reject" CssClass="btn badge badge-danger badge-shadow"></asp:Button>
                                    </div>
                            </ContentTemplate>
                        </asp:UpdatePanel>

                    </div>
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
                                            <asp:GridView ID="grdpendingapproval" runat="server" OnPreRender="grdpendingapproval_PreRender" ShowHeaderWhenEmpty="false"
                                                AutoGenerateColumns="False" class="table" DataKeyNames="GRANT_ID,ecode,GRANT_NAME,fmv_price,emp_name" OnRowDataBound="grdpendingapproval_RowDataBound"
                                                OnRowCommand="grdpendingapproval_RowCommand" OnRowUpdating="grdpendingapproval_RowUpdating">

                                                <Columns>
                                                    <asp:TemplateField>
                                                        <HeaderTemplate>
                                                            <asp:CheckBox ID="checkAll" runat="server" />
                                                            <%--  <asp:CheckBox runat="server" ID="chk2" onclick="checkAll(this);" CssClass="custom-control-label" />--%>
                                                        </HeaderTemplate>
                                                        <ItemTemplate>
                                                            <asp:CheckBox runat="server" ID="chk" CssClass="custom-control-label" />
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:BoundField HeaderText="Emp ID" DataField="ecode" SortExpression="ecode" HeaderStyle-Width="9%" />
                                                    <asp:BoundField HeaderText="Emp Name" DataField="emp_name" SortExpression="emp_name" HeaderStyle-Width="10%" />
                                                    <asp:BoundField HeaderText="Manager Name" DataField="appraiser_name" SortExpression="appraiser_name" />
                                                    <asp:TemplateField>
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblFMVId" runat="server" Visible="false" Text='<%# Eval("fmv_creation_id") %>'></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <%--<asp:BoundField HeaderText="FMV ID" DataField="fmv_creation_id" Visible="false" />--%>
                                                    <asp:BoundField HeaderText="Grant Name" DataField="GRANT_NAME" ItemStyle-Width="5%" />
                                                    <asp:BoundField HeaderText="Grant Date" DataField="date_of_grant" SortExpression="date_of_grant" DataFormatString="{0:dd-MMM-yyyy}" HeaderStyle-Width="8%" ItemStyle-HorizontalAlign="Center" />
                                                    <asp:BoundField HeaderText="Total Grant" DataField="no_of_options" SortExpression="no_of_options" HeaderStyle-Width="8%" ItemStyle-Width="8%" ItemStyle-HorizontalAlign="Center" />
                                                    <asp:BoundField HeaderText="Grant Price" DataField="fmv_price" SortExpression="fmv_price" HeaderStyle-Width="8%" ItemStyle-HorizontalAlign="Center" />
                                                    <asp:BoundField HeaderText="Created Date" DataField="CREATION_DATE" SortExpression="CREATION_DATE" HeaderStyle-Width="8%" DataFormatString="{0:dd-MMM-yyyy}" ItemStyle-HorizontalAlign="Center" />
                                                    <asp:TemplateField HeaderText="Valued By" HeaderStyle-Width="15%" ItemStyle-HorizontalAlign="Center" ItemStyle-Width="12%">
                                                        <ItemTemplate>
                                                            <asp:DropDownList ID="ddlvaluedby" runat="server" CssClass="form-control" Width="150px" Style="width: 100% !important;">
                                                            </asp:DropDownList>
                                                            <asp:Label ID="lblvaluedby" runat="server" Visible="false" Text='<%# Eval("VALUED_BY") %>'></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="File(.xls,.xlsx only)" HeaderStyle-Width="9%" ItemStyle-HorizontalAlign="Center">
                                                        <ItemTemplate>
                                                            <%--<EditItemTemplate>--%>
                                                            <div class="btn-group">
                                                                <asp:UpdatePanel ID="UpdatePanel3" runat="server" UpdateMode="Conditional" ChildrenAsTriggers="false">
                                                                    <ContentTemplate>
                                                                        <asp:FileUpload ID="fileFMV" runat="server" class="form-control" Width="150px" />
                                                                        <%--<asp:Label ID="lblFileNote" runat="server" Text=".xls, .xlsx files." ForeColor="Green"></asp:Label>--%>

                                                                        <%--<cc1:AsyncFileUpload runat="server" ID="fileFMV" Width="100%" UploaderStyle="Traditional" CompleteBackColor="White"
                                                                                UploadingBackColor="#CCFFFF" ThrobberID="imgLoader" CssClass="form-control" OnUploadedComplete="fileFMV_UploadedComplete"
                                                                                ErrorBackColor="Transparent" OnClientUploadStarted="uploadStart" Style="width: 150px;"></cc1:AsyncFileUpload>--%>
                                                                        <asp:Label ID="lblFileUpload1" runat="server" Text='<%# Eval("UPLOAD_FILE") %>' Visible="false"></asp:Label>

                                                                        <asp:LinkButton ID="btn_Download" runat="server" CommandName="download" CommandArgument='<%# Eval("UPLOAD_FILE") %>' CausesValidation="false"
                                                                            class="btn btn-icon btn-primary fas fa-arrow-down" Visible="false"></asp:LinkButton>
                                                                    </ContentTemplate>
                                                                </asp:UpdatePanel>
                                                            </div>
                                                            <%--</EditItemTemplate>--%>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Remark" HeaderStyle-Width="9%" ItemStyle-HorizontalAlign="Center">
                                                        <ItemTemplate>
                                                            <div class="remark">
                                                                <asp:TextBox ID="txtremark" runat="server" placeholder="Enter Remark" TextMode="MultiLine" onKeyUp="javascript:Count(this);"
                                                                    onChange="javascript:Count(this);" Width="90" OnClientClick="return validateCheckBoxes();"></asp:TextBox>
                                                            </div>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Grant Letter" HeaderStyle-Width="9%" ItemStyle-HorizontalAlign="Center">
                                                        <ItemTemplate>
                                                            <table>
                                                                <tr>
                                                                    <td>
                                                                        <asp:HiddenField ID="HiddenField1" runat="server" Value='<%# Bind("FILEPath") %>' />
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
                                                    <asp:TemplateField HeaderText="Action">
                                                        <ItemTemplate>
                                                            <%-- <div class="offset-md-7" style="margin-left: -4px">--%>
                                                            <div class="btn-group">
                                                                <%--<asp:Button ID="btn_Approve" runat="server" CommandName="Approve" CausesValidation="false" OnClientClick="return validateCheckBoxesapprove();"
                                                                        Text="Approve" CssClass="btn badge badge-success badge-shadow"></asp:Button>--%>
                                                                <asp:LinkButton ID="btn_Approve" runat="server" CommandName="Approve" OnClientClick="return validateCheckBoxesapprove();" Text="Approve" CssClass="btn badge badge-success badge-shadow"></asp:LinkButton>
                                                                <%-- <asp:Button ID="btn_Reject" runat="server" CommandName="Reject" CausesValidation="false" OnClick="btn_Reject_Click" OnClientClick="return validateCheckBoxes();"
                                                                        Text="Reject" CssClass="btn badge badge-danger badge-shadow"></asp:Button>--%>
                                                                <asp:LinkButton ID="btn_Reject" runat="server" CommandName="Reject" OnClientClick="return validateCheckBoxes();" Text="Reject" CssClass="btn badge badge-danger badge-shadow"></asp:LinkButton>
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

                                            <asp:Button ID="btn_Upload" runat="server" Style="display: none; visibility: hidden" OnClick="btn_Upload_Click"
                                                Text="Upload" CssClass="btn badge badge-success badge-shadow"></asp:Button>
                                            <asp:HiddenField ID="hdnFileIndex" runat="server" />
                                        </ContentTemplate>
                                        <Triggers>
                                            <asp:PostBackTrigger ControlID="grdpendingapproval" />
                                            <%--<asp:PostBackTrigger ControlID="fileFMV" />--%>
                                            <%--<asp:PostBackTrigger ControlID="btn_Upload" />--%>
                                            <asp:PostBackTrigger ControlID="grdapproval" />
                                             <%--Commented by Krutika on 14-01-23--%>
                                                        <%--<asp:AsyncPostBackTrigger ControlID="btn_bulkApprove" EventName="Click" />--%>
                                                        <%--Added by Krutika on 14-01-23--%>
                                                        <asp:PostBackTrigger ControlID="btn_bulkApprove" />
                                                        <%--End--%>
                                            <asp:AsyncPostBackTrigger ControlID="btn_bulkReject" EventName="Click" />
                                        </Triggers>
                                    </asp:UpdatePanel>
                                    <asp:button id="BtnDownload" onclick="DownloadFile_Click" runat="server" visible="false" xmlns:asp="#unknown" />
                                </div>
                            </div>
                            <div class="tab-pane fade" id="profile3" role="tabpanel" aria-labelledby="profile-tab3">
                                <div class="table-responsive width100" style="margin-top: 30px;">
                                    <asp:UpdatePanel ID="upd" runat="server" UpdateMode="Conditional">
                                        <%--UpdateMode="Conditional"--%>
                                        <ContentTemplate>
                                            <asp:GridView ID="grdapproval" runat="server" ShowHeaderWhenEmpty="false"
                                                OnPreRender="grdapproval_PreRender" AutoGenerateColumns="false" OnRowCommand="grdapproval_RowCommand"
                                                class="table" DataKeyNames="GRANT_ID,ecode">
                                                <Columns>
                                                    <asp:BoundField HeaderText="Employee ID" DataField="ecode" SortExpression="ecode" />
                                                    <asp:BoundField HeaderText="Employee Name" DataField="emp_name" SortExpression="emp_name" />
                                                    <asp:BoundField HeaderText="Manager Name" DataField="appraiser_name" SortExpression="appraiser_name" />
                                                    <asp:BoundField HeaderText="Date of Grant" DataField="date_of_grant" SortExpression="date_of_grant" />
                                                    <asp:BoundField HeaderText="Grant Name" DataField="GRANT_NAME" />
                                                    <asp:BoundField HeaderText="No.of Grants" DataField="no_of_options" ItemStyle-HorizontalAlign="Center" />
                                                    <asp:BoundField HeaderText="Grant Price" DataField="fmv_price" ItemStyle-HorizontalAlign="Center" />
                                                    <asp:BoundField HeaderText="Status" DataField="status" Visible="false" />
                                                    <asp:BoundField HeaderText="Approved By" DataField="Approved_By" ItemStyle-HorizontalAlign="Center" />
                                                    <asp:BoundField HeaderText="Approved Date" DataField="UPDATATION_DATE" SortExpression="UPDATATION_DATE" ItemStyle-HorizontalAlign="Center" />
                                                    <asp:BoundField HeaderText="Pending With" DataField="Pending_with" ItemStyle-HorizontalAlign="Center" />
                                                    <asp:BoundField HeaderText="Valued By" DataField="VALUED_BY_AGENCY" ItemStyle-HorizontalAlign="Center" />
                                                    <asp:TemplateField HeaderText="File Uploaded" ItemStyle-HorizontalAlign="Center">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblFileUpload1" runat="server" Text='<%# Eval("UPLOAD_FILE") %>' Visible="false"></asp:Label>
                                                            <asp:LinkButton ID="btn_Download" runat="server" CommandName="download" CommandArgument='<%# Eval("UPLOAD_FILE") %>' CausesValidation="false"
                                                                class="btn btn-icon btn-primary fas fa-arrow-down"></asp:LinkButton>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:BoundField DataField="Remark3" HeaderText="Remark" ItemStyle-HorizontalAlign="Center" />

                                                    <%-- <asp:TemplateField HeaderText="Remark">
                                                            <ItemTemplate>
                                                                <asp:Label ID="txtremark1" runat="server" Text='<%# Eval("Remark2") %>' ReadOnly="true"></asp:Label>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>--%>
                                                    <asp:TemplateField HeaderText="Audit Trail" HeaderStyle-Width="12.5%" ItemStyle-HorizontalAlign="Center">
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
                                            <asp:PostBackTrigger ControlID="grdpendingapproval" />
                                            <asp:PostBackTrigger ControlID="grdapproval" />
                                             <%--Commented by Krutika on 14-01-23--%>
                                                        <%--<asp:AsyncPostBackTrigger ControlID="btn_bulkApprove" EventName="Click" />--%>
                                                        <%--Added by Krutika on 14-01-23--%>
                                                        <asp:PostBackTrigger ControlID="btn_bulkApprove" />
                                                        <%--End--%>
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
                                                AutoGenerateColumns="false" class="table" OnRowCommand="grdreject_RowCommand" DataKeyNames="GRANT_ID,ecode">
                                                <Columns>
                                                    <asp:BoundField HeaderText="Employee ID" DataField="ecode" SortExpression="ecode" />
                                                    <asp:BoundField HeaderText="Employee Name" DataField="emp_name" SortExpression="emp_name" />
                                                    <asp:BoundField HeaderText="Manager Name" DataField="appraiser_name" SortExpression="appraiser_name" />
                                                    <asp:BoundField HeaderText="Grant Name" DataField="GRANT_NAME" />

                                                    <asp:BoundField HeaderText="Date of Grant" DataField="date_of_grant" SortExpression="date_of_grant" />
                                                    <asp:BoundField HeaderText="No. of Grants" DataField="no_of_options" ItemStyle-HorizontalAlign="Center" />
                                                    <asp:BoundField HeaderText="Grant Price" DataField="fmv_price" ItemStyle-HorizontalAlign="Center" />
                                                    <asp:BoundField HeaderText="Status" DataField="status" Visible="false" />
                                                    <asp:BoundField HeaderText="Rejected By" DataField="Rejected_By" ItemStyle-HorizontalAlign="Center" />
                                                    <asp:BoundField HeaderText="Rejected Date" DataField="UPDATATION_DATE" SortExpression="UPDATATION_DATE" ItemStyle-HorizontalAlign="Center" />
                                                    <asp:BoundField HeaderText="Pending With" DataField="Pending_with" ItemStyle-HorizontalAlign="Center" />
                                                    <asp:BoundField HeaderText="Valued By" DataField="VALUED_BY_AGENCY" ItemStyle-HorizontalAlign="Center" />
                                                    <%--<asp:TemplateField HeaderText="Valued By">
                                                            <ItemTemplate>
                                                                <asp:DropDownList ID="ddlvaluedby" runat="server" CssClass="form-control" Style="width: 100% !important;">
                                                                </asp:DropDownList>
                                                                <asp:Label ID="lblvaluedby" runat="server" Visible="false" Text='<%# Eval("VALUED_BY_AGENCY") %>' Width="100%"></asp:Label>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>--%>
                                                    <asp:BoundField DataField="Remark3" HeaderText="Remark" ItemStyle-HorizontalAlign="Center" />

                                                    <%-- <asp:TemplateField HeaderText="Remark">
                                                            <ItemTemplate>
                                                                <asp:Label ID="txtremark2" runat="server" Text='<%# Eval("Remark2") %>' ReadOnly="true"></asp:Label>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>--%>
                                                    <asp:TemplateField HeaderText="Audit Trail" HeaderStyle-Width="12.5%" ItemStyle-HorizontalAlign="Center">
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
                                            <asp:PostBackTrigger ControlID="grdpendingapproval" />
                                            <asp:PostBackTrigger ControlID="grdapproval" />
                                             <%--Commented by Krutika on 14-01-23--%>
                                                        <%--<asp:AsyncPostBackTrigger ControlID="btn_bulkApprove" EventName="Click" />--%>
                                                        <%--Added by Krutika on 14-01-23--%>
                                                        <asp:PostBackTrigger ControlID="btn_bulkApprove" />
                                                        <%--End--%>
                                            <asp:AsyncPostBackTrigger ControlID="btn_bulkReject" EventName="Click" />
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
                                    AllowCustomPaging="false" ViewStateMode="Enabled">
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
                                        <asp:TemplateField HeaderText="Valued By" HeaderStyle-CssClass="text-nowrap" HeaderStyle-Font-Bold="true">
                                            <ItemStyle HorizontalAlign="Left" VerticalAlign="Top" Wrap="True" />
                                            <ItemTemplate>
                                                <asp:Label ID="lbl_valued_by" runat="server" Text='<%#Eval("VALUED_BY_AGENCY") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="File Uploaded" HeaderStyle-CssClass="text-nowrap" HeaderStyle-Font-Bold="true">
                                            <ItemStyle HorizontalAlign="Left" VerticalAlign="Top" Wrap="True" />
                                            <ItemTemplate>
                                                <asp:Label ID="lbl_file_uploaded" runat="server" Text='<%#Eval("UPLOAD_FILE") %>'></asp:Label>
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
    <div class="modal bd-example-modal-lg1" id="myModal1" tabindex="-1" role="dialog">
        <div class="modal-dialog modal-lg" style="max-width: 900px;">
            <asp:UpdatePanel runat="server">
                <ContentTemplate>
                    <div class="modal-content">
                        <div class="modal-header">
                            <h5 class="modal-title" id="myLargeModalLabel">Preview </h5>
                            <%--   <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                                <span aria-hidden="true">×</span>
                            </button>--%>
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
            document.getElementById('<%=embed1.ClientID%>').src = "";
            document.getElementById('<%=embed1.ClientID%>').src = srcval;
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
                lengthMenu: [[-1, 1, 10], ["All", 1, 10]],
                order: [],
                columnDefs: [{ orderable: false, targets: [0, 9, 10, 11] }],
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
            var table = $('#ContentPlaceHolder1_grdpendingapproval').DataTable({
                bLengthChange: true,
                lengthMenu: [[-1, 5, 10], ["All", 5, 10]],
                bFilter: true,
                order: [],
                columnDefs: [{ orderable: false, targets: [0, 9, 10, 11, 12] }],
                bPaginate: true, fixedHeader: true, "scrollX": true
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

                bPaginate: true, fixedHeader: true, "scrollX": true
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
                bPaginate: true, fixedHeader: true, "scrollX": true
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

