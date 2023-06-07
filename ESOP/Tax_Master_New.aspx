<%@ Page Title="" Language="C#" MasterPageFile="~/ESOP.Master" AutoEventWireup="true" CodeBehind="Tax_Master_New.aspx.cs" Inherits="ESOP.Tax_Master_New" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
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
            color: #000 !important;
            font-weight: 600 !important;
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
    </style>

    <asp:ScriptManager ID="sm1" runat="server"></asp:ScriptManager>

    <script src="assets/js/jquery-1.8.3.min.js"></script>
    <script src="assets/js/jquery.dataTables-1.10.20.min.js"></script>

    <link href="Scripts/jquery.dataTables.min.css" rel="stylesheet" />
    <link href="Scripts/dataTables.bootstrap4.min.css" rel="stylesheet" />

    <script type="text/javascript">

        $(document).on('keydown', 'input[pattern]', function (e) {
            var input = $(this);
            var oldVal = input.val();
            var regex = new RegExp(input.attr('pattern'), 'g');

            setTimeout(function () {
                var newVal = input.val();
                if (!regex.test(newVal)) {
                    input.val(oldVal);
                }
            }, 1);
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

            //Commented by Krutika on 03-01-23
            //var prm = Sys.WebForms.PageRequestManager.getInstance();

            //prm.add_endRequest(function (sender, e) {
            //    var table = $('#ContentPlaceHolder1_grdtax').DataTable({
            //        lengthMenu: [[-1, 5, 10], ["All", 5, 10]],
            //        columnDefs: [{
            //            'targets': [4],
            //            'orderable': false,
            //        }],
            //        pagingType: 'full_numbers',
            //        bRetrieve: true,
            //        bStateSave: true,
            //        bSort: true,
            //        emptyTable: 'No data available in table'
            //    });// bind data table on first page load

            //    table.search('').columns().search('').draw();

            //    var table1 = $('#ContentPlaceHolder1_grdTaxRegime').DataTable({
            //        lengthMenu: [[-1, 5, 10], ["All", 5, 10]],
            //        columnDefs: [{
            //            'targets': [4],
            //            'orderable': false,
            //        }],
            //        pagingType: 'full_numbers',
            //        bRetrieve: true,
            //        bStateSave: true,
            //        bSort: true,
            //        emptyTable: 'No data available in table'
            //    });// bind data table on first page load
            //    table1.search('').columns().search('').draw();
            //});
            //End
        });

        //Commented by Krutika on 03-01-23
        //$(function () {
        //    debugger;
        //    $.noConflict();
        //    var table = $("#ContentPlaceHolder1_grdtax").DataTable({
        //        bLengthChange: true,
        //        lengthMenu: [[-1, 5, 10], ["All", 5, 10]],
        //        bFilter: true,
        //        columnDefs: [{ orderable: false, targets: [4] }],
        //        bPaginate: true,
        //        bSort: true,
        //        pagingType: 'full_numbers',
        //        bStateSave: true,
        //        emptyTable: 'No data available in table'
        //    });
        //    table.search('').columns().search('').draw();

        //    var table1 = $("#ContentPlaceHolder1_grdTaxRegime").DataTable({
        //        bLengthChange: true,
        //        lengthMenu: [[-1, 5, 10], ["All", 5, 10]],
        //        bFilter: true,
        //        columnDefs: [{ orderable: false, targets: [4] }],
        //        bPaginate: true,
        //        bSort: true,
        //        pagingType: 'full_numbers',
        //        bStateSave: true,
        //        emptyTable: 'No data available in table'
        //    });
        //    table1.search('').columns().search('').draw();
        //});
        //End

    </script>


    <script type="text/javascript">
        function ReqValidation() {
            debugger;
            var from = document.getElementById('<%=txtfrom.ClientID%>').value;
            var to = document.getElementById('<%=txtto.ClientID%>').value;
            var rate = document.getElementById('<%=txtrate.ClientID%>').value;

            //Added by Krutika on 03-01-23
            var year = document.getElementById('<%=ddl_FaYrs.ClientID%>');
            var yearvalue = year.options[year.selectedIndex].value;
            var regime = document.getElementById('<%=ddlTaxRegime.ClientID%>');
            var regimetype = regime.options[regime.selectedIndex].value;

            if (regimetype.trim() == "0") {
                alert("Please Select Tax Regime Type.");
                document.getElementById('<%=ddlTaxRegime.ClientID%>').focus();
                return false;
            }

            if (yearvalue.trim() == "0") {
                alert("Please Select Year.");
                document.getElementById('<%=ddlTaxRegime.ClientID%>').focus();
                return false;
            }
            //End

            if (from.trim() == "") {
                alert("Please Enter Income From Range.");
                document.getElementById('<%=txtfrom.ClientID%>').focus();
                return false;
            }

            if (to.trim() == "") {
                alert("Please Enter Income To Range.");
                document.getElementById('<%=txtto.ClientID%>').focus();
                return false;
            }

            if (rate.trim() == "") {
                alert("Please Enter Tax Rate.");
                document.getElementById('<%=txtrate.ClientID%>').focus();
                return false;
            }
        }
    </script>

    <script type="text/javascript">
        function ValidateNumberOnly() {
            if ((event.keyCode < 48 || event.keyCode > 57)) {
                event.returnValue = false;
            }
        }
        function isNumberKey(txt, evt) {
            var charCode = (evt.which) ? evt.which : evt.keyCode;
            if (charCode == 46) {
                //Check if the text already contains the . character
                if (txt.value.indexOf('.') === -1) {
                    return true;
                } else {
                    return false;
                }
            } else {
                if (charCode > 31 &&
                  (charCode < 48 || charCode > 57))
                    return false;
            }
            return true;
        }
        function ValidateTextbox() {
            debugger;
            //Reference the GridView.
            var grid = document.getElementById("<%=grdtax.ClientID %>");

            //Reference all INPUT elements.
            var Inputs = grid.getElementsByTagName("INPUT");

            if (confirm("Are you sure want to Update record?")) {
                for (i = 0; i < Inputs.length; i++) {
                    if (Inputs[i].type == 'text') {
                        if (Inputs[i].value == "") {
                            alert("Please enter value.");
                            return false;
                        }
                    }
                }
                return true;
            } else {
                return false;
            }
        }
        function ValidateTextbox1() {
            debugger;
            //Reference the GridView.
            var grid = document.getElementById("<%=grdTaxRegime.ClientID %>");

            //Reference all INPUT elements.
            var Inputs = grid.getElementsByTagName("INPUT");

            if (confirm("Are you sure want to Update record?")) {
                for (i = 0; i < Inputs.length; i++) {
                    if (Inputs[i].type == 'text') {
                        if (Inputs[i].value == "") {
                            alert("Please enter value.");
                            return false;
                        }
                    }
                }
                return true;
            } else {
                return false;
            }
        }
        function ConfirmDelete() {
            debugger;
            //Reference the GridView.
            var grid = document.getElementById("<%=grdtax.ClientID %>");

            //Reference all INPUT elements.
            var Inputs = grid.getElementsByTagName("INPUT");

            if (confirm("Are you sure want to Delete record?")) {
                return true;
            } else {
                return false;
            }
        }
        function ConfirmDelete1() {
            debugger;
            //Reference the GridView.
            var grid = document.getElementById("<%=grdTaxRegime.ClientID %>");

            //Reference all INPUT elements.
            var Inputs = grid.getElementsByTagName("INPUT");

            if (confirm("Are you sure want to Delete record?")) {
                return true;
            } else {
                return false;
            }
        }
    </script>
    <div class="main-content">
        <nav aria-label="breadcrumb">
            <ol class="breadcrumb">

                <li class="breadcrumb-item"><a href="admin-dashboard.aspx">Home</a></li>
                <li class="breadcrumb-item"><a href="settings.aspx">Masters</a></li>
                <li class="breadcrumb-item active" aria-current="page">Tax Master</li>

            </ol>
        </nav>
        <section class="section">

            <asp:UpdatePanel ID="UpdatePanel1" runat="server">

                <ContentTemplate>
                    <div class="row">
                        <div class="col-lg-12">
                            <div class="card">
                                <div class="card-header">
                                    <h4>Tax Master</h4>
                                </div>
                                <div class="card-body">
                                    <div class="offset-md row mx-auto" style="margin-top: 15px;">
                                        <div class="col-lg-3 col-md-12 col-sm-12">
                                            <div class="form-group">
                                                <label>Tax Regime <span style="color: red">*</span></label>
                                                <asp:DropDownList ID="ddlTaxRegime" runat="server" CssClass="form-control">
                                                    <asp:ListItem Text="Select" Value="0"></asp:ListItem>
                                                    <asp:ListItem Text="Old" Value="O"></asp:ListItem>
                                                    <asp:ListItem Text="New" Value="N"></asp:ListItem>
                                                </asp:DropDownList>

                                            </div>
                                        </div>
                                        <div class="col-lg-3 col-md-12 col-sm-12">
                                            <div class="form-group">
                                                <label>Financial Year<span style="color: red">*</span></label>
                                                <asp:DropDownList ID="ddl_FaYrs" runat="server" CssClass="form-control" MaxLength="20"></asp:DropDownList>

                                            </div>
                                        </div>
                                        <div class="col-lg-2 col-md-12 col-sm-12">
                                            <div class="form-group">
                                                <label>Income Range From <span style="color: red">*</span></label>
                                                <asp:TextBox ID="txtfrom" runat="server" CssClass="form-control" MaxLength="20" onkeypress="return ValidateNumberOnly()"></asp:TextBox>

                                            </div>
                                        </div>
                                        <div class="col-lg-2 col-md-12 col-sm-12">
                                            <div class="form-group">
                                                <label>Income Range To <span style="color: red">*</span></label>
                                                <asp:TextBox ID="txtto" runat="server" CssClass="form-control" MaxLength="20" onkeypress="return ValidateNumberOnly()" OnTextChanged="txtto_TextChanged" AutoPostBack="true"></asp:TextBox>

                                            </div>
                                        </div>
                                        <div class="col-lg-2 col-md-12 col-sm-12">
                                            <div class="form-group">
                                                <label>Tax Rate <span style="color: red">*</span></label>
                                                <asp:TextBox ID="txtrate" runat="server" CssClass="form-control" MaxLength="20" onkeypress="return isNumberKey(this, event);" pattern="^\d*(\.\d{0,2})?$"></asp:TextBox>

                                            </div>
                                        </div>

                                        <div class="col-lg-3 offset-md-3" style="margin-top: 7rem !important; margin-left: 45%;">
                                            <asp:Button ID="btnSave" runat="server" Text="Create" OnClick="btnSave_Click"
                                                class="btn btn-info btn-lg all" CausesValidation="true" OnClientClick=" return ReqValidation();" />

                                        </div>
                                    </div>
                                    <div style="color: red; float: right">
                                        All (*) marked fields are mandatory.
                                    </div>
                                </div>

                                <div id="showmsg" runat="server"></div>
                            </div>
                        </div>
                    </div>
                </ContentTemplate>
            </asp:UpdatePanel>
            <div class="col-lg-12 col-md-12 col-12 col-sm-12" id="tablediv">
                <div class="card" style="height: auto;">
                    <div class="card-header">
                        <h4>Record Summary</h4>
                    </div>
                    <div class="card-body">
                        <div class="table-responsive">
                            <%--<asp:UpdatePanel ID="upd" runat="server" UpdateMode="Conditional" class="table dataTable no-footer" aria-describedby="table-2_info">--%>

                            <asp:UpdatePanel ID="upd" runat="server">
                                <ContentTemplate>
                                    <div class="row" style="margin-bottom: 10px">
                                        <div class="col-md-6 form-group" style="margin-top: 7px; font-weight: bold">
                                            Tax Regime Type - Old
                                        </div>
                                        <div class="col-md-6 form-group" style="margin-top: 7px">
                                            <asp:DropDownList ID="ddl_Fa_Yrs" CssClass="form-control float-right" OnSelectedIndexChanged="ddl_Fa_Yrs_SelectedIndexChanged" AutoPostBack="true" Width="50%" runat="server"></asp:DropDownList>
                                        </div>

                                    </div>

                                    <asp:GridView ID="grdtax" runat="server" AutoGenerateColumns="False" ShowHeaderWhenEmpty="false"
                                        DataKeyNames="ID" OnRowEditing="grdtax_RowEditing" OnRowDataBound="grdtax_RowDataBound"
                                        OnRowUpdating="grdtax_RowUpdating" OnRowCommand="grdtax_RowCommand"
                                        OnRowCancelingEdit="grdtax_RowCancelingEdit" OnRowDeleting="grdtax_RowDeleting" class="table">
                                        <%-- <RowStyle HorizontalAlign="Left" />--%>
                                        <Columns>
                                            <asp:TemplateField HeaderText="Income Range From">
                                                <ItemTemplate>
                                                    <asp:Label ID="lbl_Income_Range_From" runat="server" Text='<%#Eval("INCOME_RANGE_FROM") %>' CssClass="align-left" />
                                                </ItemTemplate>

                                                <EditItemTemplate>
                                                    <asp:TextBox ID="txt_Income_Range_From" MaxLength="20" CssClass="align-content-center" onkeypress="return ValidateNumberOnly()"
                                                        runat="server" Text='<%#Eval("INCOME_RANGE_FROM") %>'></asp:TextBox>
                                                </EditItemTemplate>
                                            </asp:TemplateField>

                                            <asp:TemplateField HeaderText="Income Range To">
                                                <ItemTemplate>
                                                    <asp:Label ID="lbl_Income_Range_To" runat="server" Text='<%#Eval("INCOME_RANGE_TO") %>' />
                                                </ItemTemplate>

                                                <EditItemTemplate>
                                                    <asp:TextBox ID="txt_Income_Range_To" MaxLength="20" runat="server" onkeypress="return ValidateNumberOnly()"
                                                        Text='<%#Eval("INCOME_RANGE_TO") %>'></asp:TextBox>
                                                </EditItemTemplate>
                                            </asp:TemplateField>

                                            <asp:TemplateField HeaderText="Tax Rate">
                                                <ItemTemplate>
                                                    <asp:Label ID="lbl_TAX_RATE" runat="server" Text='<%#Eval("TAX_RATE") %>' />
                                                </ItemTemplate>

                                                <EditItemTemplate>
                                                    <asp:TextBox ID="txt_TAX_RATE" MaxLength="20" runat="server" onkeypress="return isNumberKey(this, event);"
                                                        Text='<%#Eval("TAX_RATE") %>'></asp:TextBox>
                                                </EditItemTemplate>
                                            </asp:TemplateField>

                                            <asp:TemplateField HeaderText="Financial Year">
                                                <ItemTemplate>
                                                    <asp:Label ID="lbl_FINANCIAL_YEAR" runat="server" Text='<%#Eval("YEAR") %>' />
                                                </ItemTemplate>

                                                <EditItemTemplate>
                                                    <asp:TextBox ID="txt_FINANCIAL_YEAR" MaxLength="20" runat="server" onkeypress="return isNumberKey(this, event);"
                                                        Text='<%#Eval("YEAR") %>'></asp:TextBox>
                                                </EditItemTemplate>
                                            </asp:TemplateField>

                                            <asp:TemplateField HeaderText="Action">
                                                <ItemTemplate>
                                                    <asp:LinkButton ID="btn_Edit" runat="server" CommandName="Edit" CausesValidation="false"
                                                        CssClass="fas fa-pencil-alt edit12" Enabled='<%#Eval("ISDELETED").ToString() != "N" ? false : true %>'></asp:LinkButton>
                                                    <asp:LinkButton ID="btn_Delete" runat="server" CommandName="Delete" CausesValidation="false" Enabled='<%#Eval("ISDELETED").ToString() != "N" ? false : true %>'
                                                        CssClass="fas fa-trash-alt delete12" OnClientClick=" return ConfirmDelete();"></asp:LinkButton>
                                                    <%--OnClientClick="return confirm('Are you sure you want to Delete?');"--%>
                                                </ItemTemplate>

                                                <EditItemTemplate>
                                                    <asp:LinkButton ID="btn_Update" runat="server" CssClass="fas fa-check update edit12" CommandName="Update"
                                                        OnClientClick=" return ValidateTextbox();"></asp:LinkButton>
                                                    <asp:LinkButton ID="btn_Cancel" runat="server" CssClass="fas fa-times cancel delete12" CommandName="Cancel"></asp:LinkButton>
                                                </EditItemTemplate>
                                            </asp:TemplateField>
                                        </Columns>
                                    </asp:GridView>

                                </ContentTemplate>
                                <Triggers>
                                    <asp:AsyncPostBackTrigger ControlID="btnSave" EventName="Click" />
                                </Triggers>
                            </asp:UpdatePanel>

                            <br />
                            <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                                <ContentTemplate>
                                    <div class="row" style="margin-bottom: 10px">
                                        <div class="col-md-6 form-group" style="margin-top: 7px; font-weight: bold">
                                            Tax Regime Type - New
                                        </div>
                                        <div class="col-md-6 form-group" style="margin-top: 7px">
                                            <asp:DropDownList ID="ddlYear" CssClass="form-control float-right" OnSelectedIndexChanged="ddlYear_SelectedIndexChanged" AutoPostBack="true" Width="50%" runat="server"></asp:DropDownList>
                                        </div>

                                    </div>

                                    <asp:GridView ID="grdTaxRegime" runat="server" AutoGenerateColumns="False" ShowHeaderWhenEmpty="false"
                                        DataKeyNames="ID" OnRowEditing="grdTaxRegime_RowEditing" OnRowDataBound="grdTaxRegime_RowDataBound"
                                        OnRowUpdating="grdTaxRegime_RowUpdating" OnRowCommand="grdTaxRegime_RowCommand"
                                        OnRowCancelingEdit="grdTaxRegime_RowCancelingEdit" OnRowDeleting="grdTaxRegime_RowDeleting" class="table">
                                        <%-- <RowStyle HorizontalAlign="Left" />--%>
                                        <Columns>
                                            <asp:TemplateField HeaderText="Income Range From">
                                                <ItemTemplate>
                                                    <asp:Label ID="lbl_Income_Range_From" runat="server" Text='<%#Eval("INCOME_RANGE_FROM") %>' CssClass="align-left" />
                                                </ItemTemplate>

                                                <EditItemTemplate>
                                                    <asp:TextBox ID="txt_Income_Range_From" MaxLength="20" CssClass="align-content-center" onkeypress="return ValidateNumberOnly()"
                                                        runat="server" Text='<%#Eval("INCOME_RANGE_FROM") %>'></asp:TextBox>
                                                </EditItemTemplate>
                                            </asp:TemplateField>

                                            <asp:TemplateField HeaderText="Income Range To">
                                                <ItemTemplate>
                                                    <asp:Label ID="lbl_Income_Range_To" runat="server" Text='<%#Eval("INCOME_RANGE_TO") %>' />
                                                </ItemTemplate>

                                                <EditItemTemplate>
                                                    <asp:TextBox ID="txt_Income_Range_To" MaxLength="20" runat="server" onkeypress="return ValidateNumberOnly()"
                                                        Text='<%#Eval("INCOME_RANGE_TO") %>'></asp:TextBox>
                                                </EditItemTemplate>
                                            </asp:TemplateField>

                                            <asp:TemplateField HeaderText="Tax Rate">
                                                <ItemTemplate>
                                                    <asp:Label ID="lbl_TAX_RATE" runat="server" Text='<%#Eval("TAX_RATE") %>' />
                                                </ItemTemplate>

                                                <EditItemTemplate>
                                                    <asp:TextBox ID="txt_TAX_RATE" MaxLength="20" runat="server" onkeypress="return isNumberKey(this, event);"
                                                        Text='<%#Eval("TAX_RATE") %>'></asp:TextBox>
                                                </EditItemTemplate>
                                            </asp:TemplateField>

                                            <asp:TemplateField HeaderText="Financial Year">
                                                <ItemTemplate>
                                                    <asp:Label ID="lbl_FINANCIAL_YEAR" runat="server" Text='<%#Eval("YEAR") %>' />
                                                </ItemTemplate>

                                                <EditItemTemplate>
                                                    <asp:TextBox ID="txt_FINANCIAL_YEAR" MaxLength="20" runat="server" onkeypress="return isNumberKey(this, event);"
                                                        Text='<%#Eval("YEAR") %>'></asp:TextBox>
                                                </EditItemTemplate>
                                            </asp:TemplateField>

                                            <asp:TemplateField HeaderText="Action">
                                                <ItemTemplate>
                                                    <asp:LinkButton ID="btn_Edit" runat="server" CommandName="Edit" CausesValidation="false"
                                                        CssClass="fas fa-pencil-alt edit12" Enabled='<%#Eval("ISDELETED").ToString() != "N" ? false : true %>'></asp:LinkButton>
                                                    <asp:LinkButton ID="btn_Delete" runat="server" CommandName="Delete" CausesValidation="false" Enabled='<%#Eval("ISDELETED").ToString() != "N" ? false : true %>'
                                                        CssClass="fas fa-trash-alt delete12" OnClientClick=" return ConfirmDelete1();"></asp:LinkButton>
                                                    <%--OnClientClick="return confirm('Are you sure you want to Delete?');"--%>
                                                </ItemTemplate>

                                                <EditItemTemplate>
                                                    <asp:LinkButton ID="btn_Update" runat="server" CssClass="fas fa-check update edit12" CommandName="Update"
                                                        OnClientClick=" return ValidateTextbox1();"></asp:LinkButton>
                                                    <asp:LinkButton ID="btn_Cancel" runat="server" CssClass="fas fa-times cancel delete12" CommandName="Cancel"></asp:LinkButton>
                                                </EditItemTemplate>
                                            </asp:TemplateField>

                                        </Columns>
                                    </asp:GridView>

                                </ContentTemplate>
                                <Triggers>
                                    <asp:AsyncPostBackTrigger ControlID="btnSave" EventName="Click" />
                                </Triggers>
                            </asp:UpdatePanel>


                        </div>
                    </div>
                </div>
            </div>
        </section>
    </div>

    <script src="Scripts/bootstrap.min.js"></script>
    <script src="assets/js/app.min.js"></script>

    <%--    <script src="assets/bundles/jquery-ui/jquery-ui.min.js"></script>--%>

    <script src="assets/js/scripts.js"></script>

</asp:Content>

