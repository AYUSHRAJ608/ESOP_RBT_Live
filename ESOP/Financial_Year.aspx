<%@ Page Title="" Language="C#" MasterPageFile="~/ESOP.Master" AutoEventWireup="true" CodeBehind="Financial_Year.aspx.cs" Inherits="ESOP.Financial_Year" %>

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

        .auto-style1 {
            position: relative;
            width: 100%;
            flex: 0 0 100%;
            max-width: 100%;
            left: 0px;
            top: 0px;
            padding-left: 15px;
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

            var prm = Sys.WebForms.PageRequestManager.getInstance();

            prm.add_endRequest(function (sender, e) {
                var table = $('#ContentPlaceHolder1_grdtax').DataTable({
                    lengthMenu: [[-1, 5, 10], ["All", 5, 10]],
                    columnDefs: [{
                        'targets': [3],
                        'orderable': false,
                    }],
                    pagingType: 'full_numbers',
                    bRetrieve: true,
                    bStateSave: true,
                    bSort: true,
                });// bind data table on first page load
                table
.search('')
.columns().search('')
.draw();
            });

        });


        $(function () {
            debugger;
            $.noConflict();
            var table = $("#ContentPlaceHolder1_grdtax").DataTable({
                bLengthChange: true,
                lengthMenu: [[-1, 5, 10], ["All", 5, 10]],
                bFilter: true,
                'columnDefs': [{
                    'targets': [],
                    'orderable': false,
                }],
                order: [],
                columnDefs: [{ orderable: true, targets: [3] }],
                bPaginate: true,
                bSort: true,
                pagingType: 'full_numbers',
                bStateSave: true,
            });
            table
.search('')
.columns().search('')
.draw();
        });

    </script>


    <script type="text/javascript">
        function ReqValidation() {
            debugger;
            var from = $("#txtfrom").val().length
            <%-- var to = document.getElementById('<%=txtto.ClientID%>').value;--%>
            <%--var rate = document.getElementById('<%=txtrate.ClientID%>').value;--%>

            if (from != 4) {
                alert("Please Enter correct year.");
                document.getElementById('<%=txtfrom.ClientID%>').focus();
                return false;
            }

           <%-- if (to.trim() == "") {
                alert("Please Enter Income To Range.");
                document.getElementById('<%=txtto.ClientID%>').focus();
                return false;
            }
            if (rate.trim() == "") {
                alert("Please Enter Tax Rate.");
                <%--document.getElementById('<%=txtrate.ClientID%>').focus();--%>
            //return false;
            //}--%>
        }
    </script>
    <script type="text/javascript">
        function ValidateNumberOnly() {

            if ((event.keyCode < 48 || event.keyCode > 57)) {
                event.returnValue = false;
            }


        }



        function validation() {
            debugger;
            var abc = 1;
            var Value = $('#txtfrom').val();
            if (Value != "") {
                abc += parseFloat(Value);
                // Value= parseFloat(Value) + parseFloat(1);              
                $('#txtto').val(abc);

            }
            else {
                $('#txtto').val('');
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
            <%--var grid = document.getElementById("<%=grdtax.ClientID %>");

            //Reference all INPUT elements.
            var Inputs = grid.getElementsByTagName("INPUT");--%>

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
    </script>
    <div class="main-content">
        <nav aria-label="breadcrumb">
            <ol class="breadcrumb">

                <li class="breadcrumb-item"><a href="admin-dashboard.aspx">Home</a></li>
                <li class="breadcrumb-item"><a href="settings.aspx">Masters</a></li>
                <li class="breadcrumb-item active" aria-current="page">Financial Year</li>

            </ol>
        </nav>
        <section class="section">

            <asp:UpdatePanel ID="UpdatePanel1" runat="server">

                <ContentTemplate>
                    <div class="row">
                        <div class="auto-style1">
                            <div class="card">
                                <div class="card-header">
                                    <h4>Financial Year Master</h4>
                                </div>
                                <div class="card-body mx-xl-auto">
                                    <div class="offset-md-2 row" style="margin-top: 15px;">
                                        <div class="col-lg-6 col-md-12 col-sm-12">
                                            <div class="form-group">
                                                <label>Please Enter Year <span style="color: red">*</span></label>
                                                <asp:TextBox ID="txtfrom" runat="server" ClientIDMode="Static" CssClass="form-control" MaxLength="20" onkeypress="return ValidateNumberOnly()" oninput="validation();"></asp:TextBox>

                                            </div>
                                        </div>
                                        <div class="col-lg-6 col-md-12 col-sm-12">
                                            <div class="form-group">
                                                <label>To Year <span style="color: red">*</span></label>
                                                <asp:TextBox ID="txtto" runat="server" ClientIDMode="Static" CssClass="form-control" MaxLength="20" ReadOnly="true" onkeypress="return ValidateNumberOnly()"></asp:TextBox>

                                            </div>
                                        </div>
                                        <div class="col-lg-6 offset-md-3" style="margin-top: 4rem !important; margin-left: 32%;">
                                            <asp:Button ID="btn_Save" runat="server" Text="Create" OnClick="btn_Save_Click" class="btn btn-info btn-lg all" CausesValidation="true" OnClientClick="return ReqValidation();" />

                                        </div>
                                    </div>

                                </div>
                                <div style="color: red; float: right">
                                    All (*) marked fields are mandatory.
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
                        <h4>Financial Year</h4>
                    </div>
                    <div class="card-body">
                        <div class="table-responsive">
                            <%--<asp:UpdatePanel ID="upd" runat="server" UpdateMode="Conditional" class="table dataTable no-footer" aria-describedby="table-2_info">--%>

                            <asp:UpdatePanel ID="upd" runat="server">
                                <ContentTemplate>
                                    

                                    <asp:GridView ID="grdtax" runat="server" AutoGenerateColumns="False" ShowHeaderWhenEmpty="false"
                                        DataKeyNames="ID" OnPreRender="grdtax_PreRender" class="table" EmptyDataText="No data found" >
                                        <%-- <RowStyle HorizontalAlign="Left" />--%>
                                        <Columns>
                                            <%--<asp:TemplateField HeaderText="ID">
                                                <ItemTemplate>
                                                    <asp:Label ID="lbl_id" runat="server" Text='<%#Eval("ID") %>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>--%>
                                            <asp:TemplateField HeaderText="FINANCIAL YEAR">
                                                <ItemTemplate>
                                                    <asp:Label ID="lbl_Yrs" runat="server" Text='<%#Eval("FINANCIAL_YEAR") %>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                           <%-- <asp:TemplateField HeaderText="INCOME RANGE FROM">
                                                <ItemTemplate>
                                                    <asp:Label ID="lbl_Income_from" runat="server" Text='<%#Eval("INCOME_RANGE_FROM") %>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="INCOME RANGE TO">
                                                <ItemTemplate>
                                                    <asp:Label ID="lbl_Inc_Rangeto" runat="server" Text='<%#Eval("INCOME_RANGE_TO") %>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="TAX RATE">
                                                <ItemTemplate>
                                                    <asp:Label ID="lbl_Tax_Rate" runat="server" Text='<%#Eval("TAX_RATE") %>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                             <asp:TemplateField HeaderText="CREATED BY">
                                                <ItemTemplate>
                                                    <asp:Label ID="lbl_Created_BY" runat="server" Text='<%#Eval("CREATEDBY") %>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                             <asp:TemplateField HeaderText="CREATED DATE">
                                                <ItemTemplate>
                                                    <asp:Label ID="lbl_Created_date" runat="server" Text='<%#Eval("CREATEDDATE") %>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                             <asp:TemplateField HeaderText="MODIFIED BY">
                                                <ItemTemplate>
                                                    <asp:Label ID="lbl_Modify_by" runat="server" Text='<%#Eval("MODIFIEDBY") %>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                             <asp:TemplateField HeaderText="MODIFIED DATE">
                                                <ItemTemplate>
                                                    <asp:Label ID="lbl_Modify_date" runat="server" Text='<%#Eval("MODIFIED DATE") %>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                             <asp:TemplateField HeaderText="IS DELETED">
                                                <ItemTemplate>
                                                    <asp:Label ID="lbl_Is_delelted" runat="server" Text='<%#Eval("ISDELETED") %>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                             <asp:TemplateField HeaderText="IS ACTIVE">
                                                <ItemTemplate>
                                                    <asp:Label ID="lbl_Is_Active" runat="server" Text='<%#Eval("ISACTIVE") %>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>--%>
                                        </Columns>
                                    </asp:GridView>

                                </ContentTemplate>

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
