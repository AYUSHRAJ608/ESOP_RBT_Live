<%@ Page Title="" Language="C#" MasterPageFile="~/ESOP.Master" AutoEventWireup="true" CodeBehind="HRMSIntegration.aspx.cs" Inherits="ESOP.HRMSIntegration" EnableEventValidation="false" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <script src="assets/js/jquery-1.8.3.min.js" type="text/javascript"></script>
    <link href="assets/css/jquery-ui-1.12.1.css" rel="stylesheet" />
    <script src="assets/js/jquery-1.12.4.js" type="text/javascript"></script>
    <script src="assets/js/jquery-ui-1.12.1.js" type="text/javascript"></script>

    <asp:ScriptManager ID="script" runat="server"></asp:ScriptManager>
    <%--<script type="text/javascript" src="assets/js/jquery-2.1.3.min.js"></script>--%>
    <%--<script type="text/javascript" src="assets/js/bootstrap-3.3.6.min.js"></script>--%>
    <script src="assets/js/jquery.dataTables-1.10.20.min.js" type="text/javascript"></script>
    <link href="Scripts/jquery.dataTables.min.css" rel="stylesheet" />
    <link href="Scripts/dataTables.bootstrap4.min.css" rel="stylesheet" />

    <script type="text/javascript">
        //jQuery(document).ready(function ($) {
        //       $('.counter').counterUp({
        //           delay: 10,
        //           time: 1000
        //       });
        //   });
        $('.emptable tr td.more').click(function () {
            debugger;
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
    <script type="text/javascript">
        $(document).ready(function () {
            $('[id*=chkAddAll]').click(function () {
                $("[id*='chkAdd']").attr('checked', this.checked);
            });
            $('[id*=chkUpdateAll]').click(function () {
                $("[id*='chkUpdate']").attr('checked', this.checked);
            });
        });
    </script>
    <script type="text/javascript">
        function openModal() {
            debugger;
            $('#UpdateModal').modal('show');

        }

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

        .m-14 {
            margin-bottom: -14px;
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

        @media (min-width: 768px) {
            .offset-md-9 {
                margin-left: 76%;
            }
        }

        .edn table th {
            letter-spacing: 0.3px;
            color: #6b6b6b;
            border-top: 0px solid #ddd !important;
            padding: 10px 10px !important;
            vertical-align: middle !important;
        }

        .edn table tr {
            line-height: 1 !important;
        }

        .edn table.dataTable > thead > tr > th:not(.sorting_disabled), table.dataTable > thead > tr > td:not(.sorting_disabled) {
            padding-right: 35px !important;
            padding-left: 5px !important;
            height: 30px;
            font-size: 14px !important;
        }

        ::-webkit-scrollbar {
            width: 8px;
            height: 8px;
        }

        ::-webkit-scrollbar-track {
            background-color: #ffffff;
        }

        ::-webkit-scrollbar-thumb {
            background-color: #615a72 !important; /* color of the scroll thumb */
            border-radius: 20px; /* roundness of the scroll thumb */
            border: 1px solid #615a72 !important; /* creates padding around scroll thumb */
        }

        table.dataTable, table.dataTable th, table.dataTable td {
            /*box-sizing: content-box;*/
            border: 1px solid #fff !important;
        }

        .edn table th, td {
            white-space: nowrap;
        }

        .tableheight {
            height: 550px;
        }

        .btnEditBlue {
            padding: 10px;
            background: #2573ff;
            color: white !important;
            border-radius: 4px;
            line-height: 0;
            margin-left: 0px;
        }
    </style>

    <div class="main-content" style="min-height: 562px; padding-right: 0px;">
        <nav aria-label="breadcrumb">
            <ol class="breadcrumb">
                <li class="breadcrumb-item"><a href="admin-dashboard.aspx">Home</a></li>
                <li class="breadcrumb-item"><a href="settings.aspx">Masters</a></li>
                <li class="breadcrumb-item active" aria-current="page">HRMS Integration</li>
            </ol>
        </nav>
        <section class="section">
            <div class="row">
                <div class="col-lg-12 col-md-12 col-12 col-sm-12">
                    <div class="card">
                        <div class="card-header">
                            <h4>HRMS Upload</h4>
                        </div>
                        <div class="card-body mr-4">
                            <div class="row" style="margin-top: 15px;">
                                <div class="col-md-12">
                                    <ul class="list-unstyled list-inline mb-0">
                                        <li style="vertical-align: middle;" class="list-inline-item">
                                            <div class="form-group">
                                                <label>HRMS Data</label>
                                            </div>
                                        </li>
                                        <li style="vertical-align: middle;" class="list-inline-item">
                                            <div class="onoffswitch form-group">
                                                <%--<input type="checkbox" name="onoffswitch" class="onoffswitch-checkbox" id="myonoffswitch1" />--%>
                                                <asp:CheckBox ID="myonoffswitch1" AutoPostBack="true" OnCheckedChanged="myonoffswitch1_CheckedChanged" CssClass="onoffswitch-checkbox" runat="server" />
                                                <label class="onoffswitch-label" for="ContentPlaceHolder1_myonoffswitch1">
                                                    <span class="onoffswitch-inner"></span>
                                                    <span class="onoffswitch-switch"></span>
                                                </label>
                                            </div>
                                        </li>
                                    </ul>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </section>
        <section class="section">
            <div class="row" style="margin-top: 0px !important">
                <div class="col-lg-12 col-md-12 col-12 col-sm-12">
                    <div class="card">
                        <div class="card-header">
                            <h4>HRMS Employee Details</h4>
                        </div>
                        <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional" class="table dataTable no-footer"
                            aria-describedby="table-2_info">
                            <ContentTemplate>
                                <div class="card-body">
                                    <div class="row" style="margin-top: 15px;">
                                        <div class="col-lg-2 col-md-3 col-sm-12">
                                            <div class="form-group">
                                                <label>Employee Code</label>
                                                <%--<input type="text" class="form-control" />--%>
                                                <asp:TextBox ID="txtEmpCode" runat="server" class="form-control" MaxLength="20" />
                                                <%--onkeypress='return event.charCode >= 48 && event.charCode <= 57'>--%>
                                            </div>
                                        </div>
                                        <div class="col-lg-2 col-md-3 col-sm-12">
                                            <div class="form-group">
                                                <label>Employee Name</label>
                                                <%--<input type="text" class="form-control" />--%>
                                                <asp:TextBox ID="txtEmpName" runat="server" class="form-control"></asp:TextBox>

                                            </div>
                                        </div>
                                        <div class="col-lg-2 col-md-3 col-sm-12">
                                            <div class="form-group">
                                                <label>Departments</label>
                                                <asp:DropDownList ID="ddlDept" runat="server" CssClass="form-control" AutoPostBack="false">
                                                </asp:DropDownList>

                                            </div>
                                        </div>
                                        <div class="col-lg-2 col-md-3 col-sm-12">
                                            <div class="form-group">
                                                <label>Function</label>
                                                <asp:DropDownList ID="ddlFunction" runat="server" CssClass="form-control">
                                                </asp:DropDownList>
                                            </div>
                                        </div>
                                        <div class="col-lg-2 col-md-3 col-sm-12">
                                            <div class="form-group">
                                                <label>Cost Center</label>
                                                <asp:DropDownList ID="ddlCC" runat="server" CssClass="form-control">
                                                </asp:DropDownList>
                                            </div>
                                        </div>
                                        <div class="col-lg-2 col-md-3 col-sm-12">
                                            <div class="form-group">
                                                <label>Location</label>
                                                <asp:DropDownList ID="ddlLocation" runat="server" CssClass="form-control">
                                                </asp:DropDownList>
                                            </div>
                                        </div>
                                        <div class="col-lg-2 col-md-3 col-sm-12">
                                            <div class="form-group">
                                                <label>Band</label>
                                                <asp:DropDownList ID="ddlBand" runat="server" CssClass="form-control">
                                                </asp:DropDownList>
                                            </div>
                                        </div>
                                        <div class="col-lg-2 col-md-3 col-sm-12">
                                            <div class="form-group">
                                                <label>HOD</label>
                                                <asp:DropDownList ID="ddlHOD" runat="server" CssClass="form-control">
                                                </asp:DropDownList>
                                            </div>
                                        </div>
                                        <div class="col-lg-2 col-md-3 col-sm-12">
                                            <div class="form-group">
                                                <label>Employee Status</label>
                                                <asp:DropDownList ID="ddlempstatus" runat="server" CssClass="form-control">
                                                    <asp:ListItem Value="0">Select</asp:ListItem>
                                                    <asp:ListItem Value="1">Active</asp:ListItem>
                                                    <asp:ListItem Value="2">Serving Notice</asp:ListItem>
                                                    <asp:ListItem Value="3">Inactive</asp:ListItem>
                                                    <asp:ListItem Value="4">Retired</asp:ListItem>
                                                    <asp:ListItem Value="5">Deputed</asp:ListItem>
                                                </asp:DropDownList>
                                            </div>
                                        </div>
                                        <div class="col-lg-8 offset-md-4">
                                            <asp:Button ID="btnFilter_1" runat="server" class="btn btn-info btn-lg all" Text="Apply Filters" OnClick="btnFilter_Click_1" Style="width: 135px;" />

                                            <%--<asp:Button ID="btnCancel" runat="server" class="btn btn-info btn-lg all" Text="Cancel" OnClick="btnCancel_Click" Style="width: 135px;" />--%>

                                            <asp:Button ID="btnClear" runat="server" class="btn btn-info btn-lg all" Text="Clear" OnClick="btnClear_Click" Style="width: 135px;" />

                                            <asp:ImageButton ID='btnexcelExport' runat='server' ImageUrl="~/img/excel1.png" CssClass="m-14" OnClick="btnexcelExport_Click" Height="35px" ToolTip="Export To Excel" />
                                        </div>
                                    </div>
                                </div>
                            </ContentTemplate>
                        </asp:UpdatePanel>
                        <asp:UpdatePanel ID="upd2" runat="server">
                            <ContentTemplate>
                                <div id="showmsg" runat="server"></div>
                            </ContentTemplate>
                        </asp:UpdatePanel>
                        <div class="card-body">
                            <div id="accordion" class="edn">
                                <asp:UpdatePanel ID="upd" runat="server">
                                    <ContentTemplate>
                                        <div class="container" style="overflow: auto; max-width: 100%">
                                            <asp:GridView ID="grdEmployee" Style="width: 1000px" runat="server" AutoGenerateColumns="false" CssClass="table goaltable table-striped table-hover"
                                                OnRowDataBound="grdEmployee_RowDataBound" OnPreRender="grdEmployee_PreRender" OnRowEditing="grdEmployee_RowEditing"
                                                OnRowUpdating="grdEmployee_RowUpdating" OnRowCancelingEdit="grdEmployee_RowCancelingEdit"
                                                OnRowCreated="grdEmployee_RowCreated"
                                                EmptyDataText="No Data Found" AllowSorting="true" OnRowCommand="grdEmployee_RowCommand">
                                                <Columns>
                                                    <asp:TemplateField HeaderText="Edit" ItemStyle-HorizontalAlign="Center">
                                                        <ItemTemplate>
                                                            <asp:LinkButton ID="lnkEditEmp" align="Middle" runat="server" class="btnEdit" ToolTip="Edit" CausesValidation="false" CommandName="EditEmp" CommandArgument='<%# Eval("ECODE") %>'><i class="fas fa-pencil-alt btnEditBlue"></i></asp:LinkButton>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>

                                                    <asp:TemplateField HeaderText="Employee Code">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblEmployeeCode" runat="server" Text='<%# Eval("ECODE") %>'></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>

                                                    <asp:TemplateField HeaderText="Employee Status">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblEMPLOYEE_STATUS" runat="server" Text='<%# Eval("EMP_STATUS") %>'></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>

                                                    <asp:TemplateField HeaderText="Employee Name">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblEmployeeName" runat="server" Text='<%# Eval("EMP_NAME") %>'></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>

                                                    <asp:TemplateField HeaderText="Date of Joining">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblDOJ" runat="server" Text='<%# Eval("Date of Joining") %>'></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>

                                                    <asp:TemplateField HeaderText="Grade">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblBAND" runat="server" Text='<%# Eval("BANDS") %>'></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>

                                                    <asp:TemplateField HeaderText="Business Department">
                                                        <ItemTemplate>
                                                            <asp:Label ID="Label1" runat="server" Text='<%# Eval("DEPARTMENT") %>'></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>

                                                    <asp:TemplateField HeaderText="Function">
                                                        <ItemTemplate>
                                                            <asp:Label ID="Label3" runat="server" Text='<%# Eval("FUNCTION") %>'></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>

                                                    <asp:TemplateField HeaderText="Cost Centre">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblCOSTCENTRE" runat="server" Text='<%# Eval("COST_CENTRE") %>'></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>

                                                    <asp:TemplateField HeaderText="App Code">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblAPP_CODE" runat="server" Text='<%# Eval("APP_CODE") %>'></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>

                                                    <asp:TemplateField HeaderText="Appraiser Name">
                                                        <ItemTemplate>
                                                            <asp:Label ID="Label4" runat="server" Text='<%# Eval("APPRAISER_NAME") %>'></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>

                                                    <asp:TemplateField HeaderText="Hod Code">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblHOD_CODE" runat="server" Text='<%# Eval("HOD_CODE") %>'></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>

                                                    <asp:TemplateField HeaderText="Hod Name">
                                                        <ItemTemplate>
                                                            <asp:Label ID="Label5" runat="server" Text='<%# Eval("HOD_NAME") %>'></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>

                                                    <asp:TemplateField HeaderText="Bh Code">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblBH_CODE" runat="server" Text='<%# Eval("BH_CODE") %>'></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Bh Name">
                                                        <ItemTemplate>
                                                            <asp:Label ID="Label6" runat="server" Text='<%# Eval("BH_NAME") %>'></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                </Columns>
                                                <PagerSettings FirstPageText="First" LastPageText="Last" NextPageText="Next" PreviousPageText="Previous" />

                                                <PagerStyle CssClass="text-right border-pagination" />
                                            </asp:GridView>
                                        </div>

                                        <div class="container" style="overflow: auto; max-width: 100%; display:none ">
                                            <asp:GridView ID="grdEmployee_Export" Style="width: 1000px" runat="server" AutoGenerateColumns="false" CssClass="table goaltable table-striped table-hover"
                                                OnRowDataBound="grdEmployee_RowDataBound" OnPreRender="grdEmployee_PreRender" OnRowEditing="grdEmployee_RowEditing"
                                                OnRowUpdating="grdEmployee_RowUpdating" OnRowCancelingEdit="grdEmployee_RowCancelingEdit"
                                                OnRowCreated="grdEmployee_RowCreated"
                                                EmptyDataText="No Data Found" AllowSorting="true" OnRowCommand="grdEmployee_RowCommand">
                                                <Columns>

                                                    <asp:TemplateField HeaderText="Employee Code">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblEmployeeCode" runat="server" Text='<%# Eval("ECODE") %>'></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>

                                                    <asp:TemplateField HeaderText="Employee Status">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblEMPLOYEE_STATUS" runat="server" Text='<%# Eval("EMP_STATUS") %>'></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>

                                                    <asp:TemplateField HeaderText="Employee Name">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblEmployeeName" runat="server" Text='<%# Eval("EMP_NAME") %>'></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>

                                                    <asp:TemplateField HeaderText="Date of Joining">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblDOJ" runat="server" Text='<%# Eval("Date of Joining") %>'></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>

                                                    <asp:TemplateField HeaderText="Grade">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblBAND" runat="server" Text='<%# Eval("BANDS") %>'></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>

                                                    <asp:TemplateField HeaderText="Business Department">
                                                        <ItemTemplate>
                                                            <asp:Label ID="Label1" runat="server" Text='<%# Eval("DEPARTMENT") %>'></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>

                                                    <asp:TemplateField HeaderText="Function">
                                                        <ItemTemplate>
                                                            <asp:Label ID="Label3" runat="server" Text='<%# Eval("FUNCTION") %>'></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>

                                                    <asp:TemplateField HeaderText="Cost Centre">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblCOSTCENTRE" runat="server" Text='<%# Eval("COST_CENTRE") %>'></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>

                                                    <asp:TemplateField HeaderText="App Code">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblAPP_CODE" runat="server" Text='<%# Eval("APP_CODE") %>'></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>

                                                    <asp:TemplateField HeaderText="Appraiser Name">
                                                        <ItemTemplate>
                                                            <asp:Label ID="Label4" runat="server" Text='<%# Eval("APPRAISER_NAME") %>'></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>

                                                    <asp:TemplateField HeaderText="Hod Code">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblHOD_CODE" runat="server" Text='<%# Eval("HOD_CODE") %>'></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>

                                                    <asp:TemplateField HeaderText="Hod Name">
                                                        <ItemTemplate>
                                                            <asp:Label ID="Label5" runat="server" Text='<%# Eval("HOD_NAME") %>'></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>

                                                    <asp:TemplateField HeaderText="Bh Code">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblBH_CODE" runat="server" Text='<%# Eval("BH_CODE") %>'></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Bh Name">
                                                        <ItemTemplate>
                                                            <asp:Label ID="Label6" runat="server" Text='<%# Eval("BH_NAME") %>'></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                </Columns>
                                                <PagerSettings FirstPageText="First" LastPageText="Last" NextPageText="Next" PreviousPageText="Previous" />

                                                <PagerStyle CssClass="text-right border-pagination" />
                                            </asp:GridView>
                                        </div>
                                    </ContentTemplate>
                                    <Triggers>
                                        <asp:PostBackTrigger ControlID="btnexcelExport" />
                                    </Triggers>
                                </asp:UpdatePanel>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </section>
    </div>

    <div class="modal fade" id="UpdateModal" role="dialog" data-keyboard="false" data-backdrop="static">
        <div class="modal-dialog modal-lg">
            <!-- Modal content-->
            <div class="modal-content">
                <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                    <ContentTemplate>
                        <div class="modal-header">
                            <asp:Label ID="Label2" runat="server" Font-Size="18px" Font-Bold="true" Text="Update Employee Details"></asp:Label>
                            <button type="button" class="close" data-dismiss="modal">&times;</button>
                        </div>
                        <div class="modal-body">
                            <div class="container">
                                <div class="row">
                                    <div class="col-md-4" style="padding-left: 9px !important">
                                        <div class="form-group">
                                            <asp:Label ID="lblEcode" runat="server" Style="color: #34395e; font-weight: 600;" Font-Size="16px" Font-Bold="true" Text="Employee Code"></asp:Label>
                                            <asp:Label ID="lblEmpcode" runat="server" Style="margin-top: .5rem; padding: 5px !important;" CssClass="form-control" Text=""></asp:Label>
                                        </div>
                                    </div>
                                    <div class="col-md-4" style="padding-left: 9px !important">
                                        <div class="form-group">
                                            <asp:Label ID="lblEname" runat="server" Style="color: #34395e; font-weight: 600;" Font-Size="16px" Font-Bold="true" Text="Employee Name"></asp:Label>
                                            <asp:Label ID="lblEmpname" runat="server" Style="margin-top: .5rem; padding: 5px !important;" CssClass="form-control" Text=""></asp:Label>
                                        </div>
                                    </div>
                                    <div class="col-md-4" style="padding-left: 9px !important">
                                        <div class="form-group">
                                            <label>Employee Status<span style="color: red">*</span></label>
                                            <asp:DropDownList runat="server" ID="txtempstatus" CssClass="form-control has-content" OnSelectedIndexChanged="txtempstatus_TextChanged" AutoPostBack="true">
                                                <asp:ListItem Value="0">Select</asp:ListItem>
                                                <asp:ListItem Value="1">Active</asp:ListItem>
                                                <asp:ListItem Value="2">Serving Notice</asp:ListItem>
                                                <asp:ListItem Value="3">Inactive</asp:ListItem>
                                                <asp:ListItem Value="4">Retired</asp:ListItem>
                                                <asp:ListItem Value="5">Deputed</asp:ListItem>
                                            </asp:DropDownList>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" CssClass="errorMessage" ControlToValidate="txtempstatus" Font-Size="11px" ValidationGroup="UE" Enabled="true" ErrorMessage="* Enter Employee Status" ForeColor="Red"></asp:RequiredFieldValidator>
                                        </div>
                                    </div>
                                </div>
                                <div class="row">
                                    <div class="col-md-3" style="height: 99px">
                                        <div class="form-group">
                                            <label>HOD ID</label>
                                            <asp:TextBox ID="txtHODID" runat="server" CssClass="form-control has-content" ValidationGroup="UE" AutoPostBack="true" OnTextChanged="txtHODID_TextChanged"></asp:TextBox>
                                        </div>
                                    </div>
                                    <div class="col-md-3" style="height: 99px">
                                        <div class="form-group">
                                            <label>HOD Name</label>
                                            <asp:DropDownList runat="server" ID="txtHODName" CssClass="form-control has-content" OnSelectedIndexChanged="txtHODName_TextChanged" AutoPostBack="true"></asp:DropDownList>
                                        </div>
                                    </div>
                                    <div class="col-md-3" style="height: 99px">
                                        <div class="form-group">
                                            <label>BH ID</label>
                                            <asp:TextBox ID="txtBHID" runat="server" CssClass="form-control has-content" ValidationGroup="UE" AutoPostBack="true" OnTextChanged="txtBHID_TextChanged"></asp:TextBox>
                                        </div>
                                    </div>
                                    <div class="col-md-3">
                                        <div class="form-group">
                                            <label>BH Name</label>
                                            <asp:DropDownList runat="server" ID="txtBHName" CssClass="form-control has-content" OnSelectedIndexChanged="txtBHName_TextChanged" AutoPostBack="true"></asp:DropDownList>
                                        </div>
                                    </div>
                                </div>
                                <div class="clearfix">
                                    <div class="col-md-12 text-right" style="padding-left: 0px">
                                        <ul class="list-unstyled list-inline">
                                            <li class="list-inline-item" style="float: left">
                                                <asp:Button ID="btnUpdateEmp" runat="server" class="modalbutton btn btn-info btn-lg all" CausesValidation="true" ValidationGroup="UE" Text="Update" OnClick="btnUpdateEmp_Click" />
                                            </li>
                                            <li class="list-inline-item" style="float: left">
                                                <asp:Button ID="btnCancelEmp" runat="server" data-dismiss="modal" class="modalbutton btn btn-info btn-lg all" Text="Cancel" />
                                            </li>
                                        </ul>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </ContentTemplate>
                    <Triggers>
                        <asp:PostBackTrigger ControlID="btnUpdateEmp" />
                    </Triggers>
                </asp:UpdatePanel>
            </div>
        </div>
    </div>

    <script>


        $(document).ready(function () {
            if ($('.onoffswitch-checkbox input[type="checkbox"]').is(':checked')) {
                $('.onoffswitch-label .onoffswitch-inner').css('margin-left', '0');
                $('.onoffswitch-label .onoffswitch-switch').css({ 'right': '0', 'background-color': '#5a9d44' });
            }
        });
    </script>

    <script>
        function openUpdateModal() {
            debugger;
            $('#UpdateModal').modal('show');
        }

        $(document).ready(function () {
            if ($('.onoffswitch-checkbox input[type="checkbox"]').is(':checked')) {
                $('.onoffswitch-label .onoffswitch-inner').css('margin-left', '0');
                $('.onoffswitch-label .onoffswitch-switch').css({ 'right': '0', 'background-color': '#5a9d44' });
            }
        });
    </script>


    <script type="text/javascript">
        //var prm = Sys.WebForms.PageRequestManager.getInstance();

        //prm.add_endRequest(function (sender, e) {
        //    $('#ContentPlaceHolder1_grdEmployee').dataTable({
        //        dom: 'lf<"table-responsive tableheight"t>ip',
        //        lengthMenu: [[10, 25, 50, 100, -1], [10, 25, 50, 100, "All"]],
        //        bFilter: true,
        //        columnDefs: [{ orderable: false, targets: [0] }, { width: 200, targets: 0 }],
        //        order: [],
        //        bPaginate: true,
        //        bSort: true,
        //        retrieve: true,
        //        fixedColumns: true,
        //        //StateSave: true,
        //        bStateSave: true
        //    });
        //});
        //$( document ).ready(function () {
        //    // $.noConflict();  
        //    debugger;
        //    $("#ContentPlaceHolder1_grdEmployee").DataTable({
        //        dom: 'lf<"table-responsive tableheight"t>ip',
        //        bLengthChange: true,
        //        lengthMenu: [[10, 25, 50, 100, -1], [10, 25, 50, 100, "All"]],
        //        bFilter: true,
        //        order: [],
        //        columnDefs: [{ orderable: false, targets: [0] }, { width: 200, targets: 0 }],
        //        bPaginate: true,
        //        bSort: true,
        //        fixedColumns: true,
        //        //StateSave: true,
        //        retrieve: true,
        //        bStateSave: true
        //    });
        //});
    </script>
    <script src="Scripts/bootstrap.min.js"></script>
    <!-- General JS Scripts -->
    <script src="assets/js/app.min.js"></script>
    <!-- JS Libraies -->
    <%--<script src="assets/bundles/echart/echarts.js"></script>--%>
    <!-- Page Specific JS File -->
    <%-- <script src="assets/js/page/chart-echarts.js"></script>--%>
    <!-- Page Specific JS File -->
    <%-- <script src="assets/js/page/index.js"></script>--%>
    <!-- Template JS File -->
    <script src="assets/js/scripts.js"></script>

</asp:Content>
