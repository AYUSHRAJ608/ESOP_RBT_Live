<%@ Page Title="" Language="C#" MasterPageFile="~/ESOP.Master" AutoEventWireup="true" CodeBehind="PDFPassword.aspx.cs" Inherits="ESOP.PDFPassword" %>


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

    <%--  <script src="assets/js/jquery-1.8.3.min.js" type="text/javascript"></script>
    <link href="assets/css/jquery-ui-1.12.1.css" rel="stylesheet" />
    <script src="assets/js/jquery-1.12.4.js" type="text/javascript"></script>
    <script src="assets/js/jquery-ui-1.12.1.js" type="text/javascript"></script>
    --%>


    <%--<link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/font-awesome/4.7.0/css/font-awesome.min.css" />--%>
    <link href="assets/css/font-awesome.min.css" type="text/javascript" rel="stylesheet" />

    <%--<script src="https://ajax.googleapis.com/ajax/libs/jquery/3.3.1/jquery.min.js"></script>--%>
    <script src="assets/js/jquery.min.js" type="text/javascript"></script>

    <script type="text/javascript">
        $(document).ready(function () {
            $('#show_password').hover(function show() {
                document.getElementById('<%=txtasterisk.ClientID%>').style.display = 'block';
                document.getElementById('<%=txtPassword_1.ClientID%>').style.display = 'none';
                document.getElementById('<%=txtasterisk.ClientID%>').value = document.getElementById('<%=txtPassword_1.ClientID%>').value
                $('.icon').removeClass('fa fa-eye-slash').addClass('fa fa-eye');
            },
                function () {
                    //Change the attribute back to password  
                    $('#txtPassword').attr('type', 'password');
                    document.getElementById('<%=txtasterisk.ClientID%>').style.display = 'none';
                    document.getElementById('<%=txtPassword_1.ClientID%>').style.display = 'block';
                    $('.icon').removeClass('fa fa-eye').addClass('fa fa-eye-slash');
                });
            //CheckBox Show Password  
            $('#ShowPassword').click(function () {
                $('#Password').attr('type', $(this).is(':checked') ? 'text' : 'password');
            });
        });
    </script>


    <script src="assets/js/jquery-1.8.3.min.js" type="text/javascript"></script>
    <link href="assets/css/jquery-ui-1.12.1.css" rel="stylesheet" />
    <script src="assets/js/jquery-1.12.4.js" type="text/javascript"></script>
    <script src="assets/js/jquery-ui-1.12.1.js" type="text/javascript"></script>

    <script type="text/javascript">
        $('.emptable tr td.more').click(function () {
            $('html, body').animate({ scrollTop: $(this).position().top }, 'slow');
        });
        $(window).scroll(function () {
            sessionStorage.scrollTop = $(this).scrollTop();
        });

        $(document).ready(function () {
            if (sessionStorage.scrollTop != "undefined") {
                $(window).scrollTop(sessionStorage.scrollTop);
            }
        });

    </script>

    <style>
        .pagerU table {
            width: 30% !important;
        }

        header {
            padding: 4px !important;
            width: 44px;
        }

        .emptable tr:first-child th {
            background-color: #e41f25 !important;
            color: #fff !important;
            font-weight: bold !important;
        }
    </style>

    <style>
        .card {
            height: auto !important;
        }

        h4 {
            font-weight: 600;
            font-size: 16px;
            color: #2b76ff;
        }

        .chosen-container {
            width: 100% !important;
        }


        .switch {
            position: relative;
            display: inline-block;
            width: 70px;
            height: 24px;
            margin-top: 7px;
        }

            .switch input {
                opacity: 0;
            }

        .slider {
            position: absolute;
            cursor: pointer;
            top: 0;
            left: 0;
            right: 0;
            bottom: 0;
            background-color: #ccc;
            -webkit-transition: .4s;
            transition: .4s;
        }

            .slider:before {
                position: absolute;
                content: "";
                height: 16px;
                width: 16px;
                left: 4px;
                bottom: 4px;
                background-color: white;
                -webkit-transition: .4s;
                transition: .4s;
            }

        input:checked + .slider {
            background-color: #2600ff;
        }

        input:focus + .slider {
            box-shadow: 0 0 1px #2196F3;
        }

        input:checked + .slider:before {
            -webkit-transform: translateX(46px);
            -ms-transform: translateX(46px);
            transform: translateX(46px);
        }
        /*------ ADDED CSS ---------*/
        .on {
            display: none;
        }

        .on, .off {
            color: white;
            position: absolute;
            transform: translate(-50%,-50%);
            top: 50%;
            left: 50%;
            font-size: 12px;
            font-family: Verdana, sans-serif;
        }

        input:checked + .slider .on {
            display: block;
        }

        input:checked + .slider .off {
            display: none;
        }

        /* Rounded sliders */
        .slider.round {
            border-radius: 34px;
        }

            .slider.round:before {
                border-radius: 50%;
            }


        .onoffswitch {
            position: relative;
            width: 80px;
            -webkit-user-select: none;
            -moz-user-select: none;
            -ms-user-select: none;
            height: 32px;
        }

        .onoffswitch-checkbox {
            display: none;
        }

        .onoffswitch-label {
            display: block;
            overflow: hidden;
            cursor: pointer;
            border: 2px solid #FFFFFF;
            border-radius: 50px;
            position: relative;
            margin: 0;
        }

        .onoffswitch-inner {
            display: block;
            width: 200%;
            margin-left: -100%;
            transition: margin 0.3s ease-in 0s;
        }

            .onoffswitch-inner:before, .onoffswitch-inner:after {
                display: block;
                float: left;
                width: 50%;
                height: 29px;
                padding: 0;
                line-height: 29px;
                font-size: 11px;
                color: white;
                font-family: Montserrat;
                font-weight: 600;
                box-sizing: border-box;
            }

            .onoffswitch-inner:before {
                content: "Enable";
                padding-left: 7px;
                background-color: #EEEEEE;
                color: #26ad5b;
                font-family: Montserrat;
            }

            .onoffswitch-inner:after {
                content: "Disable";
                padding-right: 7px;
                background-color: #EEEEEE;
                color: #999999;
                text-align: right;
                font-family: Montserrat;
            }

        .onoffswitch-switch {
            display: block;
            width: 19px;
            margin: 5px;
            background: #A1A1A1;
            position: absolute;
            top: 0;
            bottom: 0;
            right: 48px;
            border: 2px solid #FFFFFF;
            border-radius: 50px;
            transition: all 0.3s ease-in 0s;
        }

        .onoffswitch-checkbox:checked + .onoffswitch-label .onoffswitch-inner {
            margin-left: 0;
        }

        .onoffswitch-checkbox:checked + .onoffswitch-label .onoffswitch-switch {
            right: 0px;
            background-color: #26ad5b;
        }

        .onoffswitch-inner:after {
            content: "OFF";
            padding-right: 18px;
            background-color: #939598;
            color: #fff;
            text-align: right;
            font-family: Montserrat;
            font-size: 12px;
        }

        .onoffswitch-inner:before {
            content: "ON";
            padding-left: 18px;
            background-color: #5a9d44;
            color: #ffffff;
            font-family: Montserrat;
            font-size: 12px;
        }

        .onoffswitch-checkbox:checked + .onoffswitch-label .onoffswitch-switch {
            right: 0px;
            background-color: #5a9d44;
        }
    </style>

    <script type="text/javascript">
        function ReqValidation() {
            var txtPassword = document.getElementById('<%=txtPassword_1.ClientID%>').value;
            if (txtPassword.trim() == "") {
                alert("Please Enter Password.");
                document.getElementById('<%=txtPassword_1.ClientID%>').focus();
                return false;
            }
        }
    </script>

    <div class="main-content" style="min-height: 562px;">
        <nav aria-label="breadcrumb">
            <ol class="breadcrumb">
                <li class="breadcrumb-item"><a href="admin-dashboard.aspx">Home</a></li>
                <li class="breadcrumb-item"><a href="settings.aspx">Masters</a></li>
                <li class="breadcrumb-item active" aria-current="page">PDF Password</li>

            </ol>
        </nav>
        <section class="section">
            <div class="row">
                <div class="col-12">
                    <div class="card">
                        <div class="card-body">
                            <div class="row">
                                <div class="col-lg-12 col-md-12 col-12 col-sm-12">
                                    <div class="card-header">
                                        <h4>PDF Password</h4>
                                    </div>
                                    <div class="card-body">
                                        <div class="row">
                                            <div class="col-lg-3 col-md-12 col-sm-12">
                                                <div class="form-group">
                                                    <label>Enter Admin Password</label>
                                                    <div class="input-group">
                                                        <asp:TextBox ID="txtPassword_1" TextMode="Password" runat="server" CssClass="form-control"></asp:TextBox>
                                                        <asp:TextBox ID="txtasterisk" runat="server" CssClass="form-control" Style="display: none"></asp:TextBox>
                                                        <div class="">
                                                            <button id="show_password" class="btn btn-primary" type="button">
                                                                <span class="fa fa-eye-slash icon"></span>
                                                            </button>
                                                        </div>
                                                    </div>
                                                </div>
                                            </div>
                                            <div class="col-lg-3 col-md-12 col-sm-12">
                                                <div class="form-group">
                                                    <label>Select Employee Password</label>
                                                    <asp:DropDownList ID="ddlEmpPass" runat="server" class="form-control">
                                                        <%--<asp:ListItem Value="0">Select Employee Password</asp:ListItem>
                                                        <asp:ListItem Value="1">PAN Card</asp:ListItem>
                                                        <asp:ListItem Value="2">Adhar Card</asp:ListItem>--%>
                                                    </asp:DropDownList>
                                                </div>

                                            </div>
                                            <div class="col-lg-3 offset-md-3" style="padding-top: 30px;">
                                                <asp:Button ID="btnSave" CssClass="btn btn-info btn-lg all" runat="server" Text="Save" OnClick="btnSave_Click" OnClientClick="return ReqValidation();" />
                                            </div>
                                        </div>
                                        <asp:UpdatePanel ID="upd2" runat="server">
                                            <ContentTemplate>
                                                <div id="showmsg" runat="server"></div>
                                            </ContentTemplate>
                                        </asp:UpdatePanel>
                                    </div>
                                    <div class="table-responsive" style="margin-top: 30px;">
                                        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                                            <ContentTemplate>
                                                <asp:GridView ID="grdData" runat="server" ShowHeaderWhenEmpty="false"
                                                    OnPreRender="grdData_PreRender" EmptyDataText="No data found" AutoGenerateColumns="False"
                                                    class="table dataTable">
                                                    <Columns>
                                                        <asp:TemplateField HeaderText="Admin Password">
                                                            <ItemTemplate>
                                                                <asp:Label ID="lbl_grant_name" runat="server" Text='<%#Eval("PDF_PASSWORD") %>'></asp:Label>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Employee Password">
                                                            <ItemTemplate>
                                                                <asp:Label ID="lbl_ate_of_grant" runat="server" Text='<%#Eval("EMP_PASSWORD") %>'></asp:Label>
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
                                                                <asp:Label ID="lbl_updatation_date" runat="server" Text='<%#Eval("updation_date") %>'></asp:Label>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Updated By">
                                                            <ItemTemplate>
                                                                <asp:Label ID="lbl_updated_by" runat="server" Text='<%#Eval("updated_by") %>'></asp:Label>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="End Date">
                                                            <ItemTemplate>
                                                                <asp:Label ID="lbl_End_Date" runat="server" Text='<%#Eval("END_DATE") %>'></asp:Label>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                    </Columns>
                                                    <PagerSettings FirstPageText="First" LastPageText="Last" NextPageText="Next" PreviousPageText="Previous" />

                                                    <%--<PagerStyle CssClass="text-right border-pagination" />--%>
                                                </asp:GridView>
                                                <%--<div class="clearfix"></div>--%>
                                            </ContentTemplate>
                                            <Triggers>
                                                <asp:PostBackTrigger ControlID="grdData" />
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


    <%--<script src="Scripts/bootstrap.min.js"></script>--%>
    <script src="assets/js/app.min.js"></script>
    <script src="assets/js/scripts.js"></script>



    <script src="assets/js/jquery.dataTables-1.10.20.min.js"></script>
    <link href="Scripts/jquery.dataTables.min.css" rel="stylesheet" />
    <link href="Scripts/dataTables.bootstrap4.min.css" rel="stylesheet" />

    <script>
        //$('#ContentPlaceHolder1_grdData').clear().draw();
        $(function () {
            var prm = Sys.WebForms.PageRequestManager.getInstance();
            prm.add_endRequest(function (sender, e) {
                $('#ContentPlaceHolder1_grdData').DataTable({
                    lengthMenu: [[-1, 5, 10], ["All", 5, 10]],
                    bRetrieve: true,
                });

            });
        });
        $(function () {
            debugger;
            $("#ContentPlaceHolder1_grdData").DataTable({
                bLengthChange: true,
                lengthMenu: [[-1, 5, 10], ["All", 5, 10]],
                bFilter: true,
                'columnDefs': [{
                    'targets': [],
                    'orderable': false,
                }],
                //bSort:true,
                bPaginate: true,
                "aaSorting": [[4, "asc"]]
            });
        });
    </script>
</asp:Content>
