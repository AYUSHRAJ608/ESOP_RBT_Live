<%@ Page Title="" Language="C#" MasterPageFile="~/ESOP.Master" AutoEventWireup="true" CodeBehind="AddEmployeeUnderPresident.aspx.cs" Inherits="ESOP.AddEmployeeUnderPresident" %>

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

        .edit12 {
            padding: 10px;
            background: #2573ff;
            color: white !important;
            border-radius: 4px;
            line-height: 0;
        }



        @media (min-width: 768px) {
            .offset-md-8 {
                margin-left: 77%;
            }
        }


        @media (min-width: 992px) {
            .col-lg-12 {
                flex: 0% !important;
                max-width: 100%;
            }
        }

        table.dataTable.no-footer {
            width: 100% !important;
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
    <script src="assets/js/jquery.dataTables-1.10.20.min.js"></script>
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
        });
    </script>

    <script type="text/javascript">
        var prm = Sys.WebForms.PageRequestManager.getInstance();
        prm.add_endRequest(function (sender, e) {
            $.noConflict();
            $('#ContentPlaceHolder1_grdapproval').DataTable({
                lengthMenu: [[5, 10, 15, -1], [5, 10, 15, "All"]],
                columnDefs: [{ orderable: false, targets: [4, 5] }],
                "bStateSave": true,
                bPaginate: true,
                bSort: true,
                bFilter: true,
                bRetrieve: true, fixedHeader: true, "scrollX": true
            });
        });



        $(function () {
            $.noConflict();
            debugger;
            $("#ContentPlaceHolder1_grdapproval").DataTable({
                bLengthChange: true,
                lengthMenu: [[5, 10, 15, -1], [5, 10, 15, "All"]],
                bFilter: true,
                order: [],
                columnDefs: [{ orderable: false, targets: [4, 5] }],
                bPaginate: true,
                bSort: true,
                "bStateSave": true, fixedHeader: true, "scrollX": true
            });
        });
    </script>





    <%--<body class="sidebar-mini">--%>
    <div class="loader"></div>
    <div id="app">
        <div class="main-wrapper main-wrapper-1">
            <div class="navbar-bg"></div>
            <!-- Main Content -->
            <%--<div class="main-content">--%>
            <div class="main-content" style="min-height: 562px; padding-right: 0px;">
                <%--<nav aria-label="breadcrumb" class="offset-md-9">--%>
                <nav aria-label="breadcrumb">
                    <ol class="breadcrumb">
                        <li class="breadcrumb-item"><a href="admin-dashboard.aspx">Home</a></li>
                        <li class="breadcrumb-item"><a href="settings.aspx">Masters</a></li>
                        <li class="breadcrumb-item active" aria-current="page">Add Employee</li>
                    </ol>
                </nav>
                <section class="section">
                    <div class="row">
                        <div class="col-lg-12 col-md-12 col-12 col-sm-12">
                            <div class="card">
                                <div class="card-header">
                                    <h4>Add Employee to ESOP System</h4>
                                </div>
                                <asp:UpdatePanel ID="upd" runat="server" UpdateMode="Conditional" class="table dataTable no-footer"
                                    aria-describedby="table-2_info">
                                    <ContentTemplate>
                                        <div class="card-body">
                                            <div class="row" style="margin-top: 15px;">
                                                <%--  <div id="DivFilter" runat="server" class="">--%>
                                                <%--style="display: none"--%>
                                                <%--  <div class="row">--%>
                                                <div class="col-lg-3 col-md-12 col-sm-12">
                                                    <div class="form-group">
                                                        <label>Employee Code</label>
                                                        <%--<input type="text" class="form-control" />--%>
                                                        <asp:TextBox ID="txtEmpCode" runat="server" class="form-control" MaxLength="20" />
                                                        <%--onkeypress='return event.charCode >= 48 && event.charCode <= 57'>--%>
                                                    </div>
                                                </div>
                                                <div class="col-lg-3 col-md-12 col-sm-12">
                                                    <div class="form-group">
                                                        <label>Employee Name</label>
                                                        <%--<input type="text" class="form-control" />--%>
                                                        <asp:TextBox ID="txtEmpName" runat="server" class="form-control"></asp:TextBox>

                                                    </div>
                                                </div>
                                                <div class="col-lg-3 col-md-12 col-sm-12">
                                                    <div class="form-group">
                                                        <label>Departments</label>
                                                        <asp:DropDownList ID="ddlDept" runat="server" CssClass="form-control" AutoPostBack="false">
                                                        </asp:DropDownList>

                                                    </div>
                                                </div>
                                                <div class="col-lg-3 col-md-12 col-sm-12">
                                                    <div class="form-group">
                                                        <label>Band</label>
                                                        <asp:DropDownList ID="ddlBand" runat="server" CssClass="form-control">
                                                        </asp:DropDownList>

                                                    </div>
                                                </div>
                                                <div class="col-lg-3 col-md-12 col-sm-12">
                                                    <div class="form-group">
                                                        <label>Location</label>
                                                        <asp:DropDownList ID="ddlLocation" runat="server" CssClass="form-control">
                                                        </asp:DropDownList>
                                                    </div>
                                                </div>
                                                <%--</div>--%>
                                                <%--  </div>--%>
                                                <div class="offset-md-3 col-lg-5 col-md-12 col-sm-12 all" style="display: none">
                                                    <div class="form-group">
                                                        <label>Username</label>&nbsp;&nbsp
                                                            <asp:Label ID="lbl_text" ForeColor="Red" runat="server" Text=""></asp:Label>
                                                        <div class="input-group mb-3">
                                                            <asp:DropDownList ID="ddlUserName" runat="server" CssClass="form-control" Style="width: 100% !important;"></asp:DropDownList>
                                                        </div>
                                                    </div>
                                                </div>
                                                <div class="col-lg-3 col-md-12 col-sm-12">
                                                    <div class="form-group">
                                                        <%--<label>Role</label>
                                                        <asp:DropDownList ID="ddlRole" runat="server" CssClass="form-control">
                                                        </asp:DropDownList>--%>
                                                    </div>
                                                </div>

                                                <div class="col-lg-3 mt-3" style="margin-left: -85px;">
                                                    <asp:Button ID="btnFilter" runat="server" class="btn btn-info btn-lg all" Text="Filter" OnClick="btnFilter_Click" Style="display: none" />
                                                </div>


                                                <div class="col-lg-3 offset-md-5 mt-2 mb-2">
                                                    <asp:Button ID="btnProxyLogin" runat="server" class="btn btn-info btn-lg all" Text="Proxy Login" OnClick="btnProxyLogin_Click" Style="display: none" />
                                                </div>
                                                <div class="col-lg-12 offset-md-4">
                                                    <%--  <div class="col-md-3  mb-3">
                                                    <div class="form-group">--%>
                                                    <asp:Button ID="btnFilter_1" runat="server" class="btn btn-success" Text="Apply Filters" OnClick="btnFilter_Click_1" Style="width: 135px;" />
                                                    <%--      </div>
                                                </div>
                                                <div class="col-md-3  mb-3">
                                                    <div class="form-group">--%>
                                                    <asp:Button ID="btnCancel" runat="server" class="btn btn-success" Text="Cancel" OnClick="btnCancel_Click" Style="width: 135px;" />
                                                    <%--   </div>
                                                </div>
                                                <div class="col-md-3 mb-3">
                                                    <div class="form-group">--%>
                                                    <asp:Button ID="Button1" runat="server" class="btn btn-primary" Text="Clear" OnClick="btnClear_Click" Style="width: 135px;" />
                                                    <%--   </div>
                                                </div>--%>
                                                </div>
                                            </div>
                                        </div>
                                    </ContentTemplate>
                                    <Triggers>
                                        <asp:PostBackTrigger ControlID="btnFilter" />
                                    </Triggers>
                                </asp:UpdatePanel>
                            </div>
                            <asp:UpdatePanel ID="upd2" runat="server">
                                <ContentTemplate>
                                    <div id="showmsg" runat="server"></div>
                                </ContentTemplate>
                            </asp:UpdatePanel>
                        </div>
                    </div>

                    <div class="row">
                        <div class="col-12">
                            <div class="card">
                                <div class="card-header">
                                    <h4>Employee Details</h4>
                                </div>
                                <div class="card-body">
                                    <div class="table-responsive" style="margin-top: 30px;">
                                        <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional">
                                            <ContentTemplate>
                                                <asp:GridView ID="grdapproval" runat="server" ShowHeaderWhenEmpty="false"
                                                    OnRowCommand="grdapproval_RowCommand" EmptyDataText="No Records Found" AutoGenerateColumns="false"
                                                    class="table" DataKeyNames="ecode" OnPreRender="grdapproval_PreRender" OnRowDataBound="grdapproval_RowDataBound">
                                                    <Columns>
                                                        <asp:BoundField HeaderText="Employee ID" DataField="ecode" SortExpression="ecode" />
                                                        <asp:BoundField HeaderText="Employee Name" DataField="emp_name" SortExpression="emp_name" />
                                                        <asp:BoundField HeaderText="DEPARTMENT" DataField="DEPARTMENT" SortExpression="DEPARTMENT" />
                                                        <asp:BoundField HeaderText="BANDS" DataField="BANDS" SortExpression="BANDS" />
                                                        <%--<asp:BoundField HeaderText="LOCATION" DataField="LOCATION" SortExpression="LOCATION" />--%>
                                                        <%--<asp:BoundField HeaderText="EMP STATUS" DataField="ESTATUS" SortExpression="ESTATUS" />--%>
                                                        <asp:TemplateField HeaderText="Assign Role" HeaderStyle-Width="30%">
                                                            <ItemTemplate>
                                                                <%--<asp:DropDownList ID="ddlRole" runat="server" CssClass="form-control">
                                                                    <asp:ListItem Text="Select Role" Value="0" Selected="True"></asp:ListItem>
                                                                    <asp:ListItem Text="Admin" Value="1"></asp:ListItem>
                                                                    <asp:ListItem Text="HR Head" Value="2"></asp:ListItem>
                                                                    <asp:ListItem Text="President" Value="3"></asp:ListItem>
                                                                    <asp:ListItem Text="Secretarial" Value="5"></asp:ListItem>
                                                                </asp:DropDownList>--%>
                                                                <div>
                                                                    <asp:CheckBoxList ID="checkboxlist1"
                                                                        CellPadding="0"
                                                                        CellSpacing="5"
                                                                        RepeatDirection="Horizontal"
                                                                        TextAlign="Right"
                                                                        runat="server">
                                                                        <asp:ListItem Value="1">Admin</asp:ListItem>
                                                                        <asp:ListItem Value="2">HRHead</asp:ListItem>
                                                                        <asp:ListItem Value="3">President</asp:ListItem>
                                                                        <asp:ListItem Value="4">Employee</asp:ListItem>
                                                                        <asp:ListItem Value="5">Secreterial</asp:ListItem>
                                                                        <asp:ListItem Value="6">Checker</asp:ListItem>
                                                                    </asp:CheckBoxList>
                                                                </div>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Add To ESOP User" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center">
                                                            <ItemTemplate>
                                                                <asp:LinkButton ID="btn_Audit_1" runat="server" CommandName="Add" CausesValidation="true"
                                                                    CommandArgument="<%# ((GridViewRow) Container).RowIndex %>"
                                                                    class="btn btn-success" Text="Add" Width="40%"></asp:LinkButton>
                                                                <%--CssClass="fas edit12"--%>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                    </Columns>
                                                </asp:GridView>
                                            </ContentTemplate>
                                            <Triggers>
                                                <asp:PostBackTrigger ControlID="grdapproval" />
                                            </Triggers>
                                        </asp:UpdatePanel>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </section>
                <%--<section class="section">--%>

                <%--</section>--%>
            </div>
        </div>
    </div>



    <footer class="main-footer">
    </footer>


    <script src="Scripts/bootstrap.min.js"></script>
    <script src="assets/js/app.min.js"></script>

    <script src="assets/js/scripts.js"></script>


</asp:Content>

