<%@ Page Title="" Language="C#" MasterPageFile="~/ESOP.Master" AutoEventWireup="true" CodeBehind="Vesting_Correction.aspx.cs" Inherits="ESOP.Vesting_Correction" %>

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
            border: 1px solid #19a5c5;
            border-radius: 6px;
            padding-left: 8px;
            font-weight: 500;
            color: #3f646d;
            font-size: 14px;
            background: #eefafc;
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

        .optiongroup1 {
            font-weight: bold;
            font-size: 14px;
            /*font-style:italic;*/
        }

        .optionchild1 {
            font-size: 12px;
        }
    </style>


    <%--    <script type="text/javascript" src="https://ajax.googleapis.com/ajax/libs/jquery/1.8.3/jquery.min.js"></script>
    <script type="text/javascript" src="https://cdn.datatables.net/1.10.20/js/jquery.dataTables.min.js"></script>--%>


    <script type="text/javascript" src="assets/js/jquery-1.8.3.min.js"></script>
    <script type="text/javascript" src="assets/js/jquery.dataTables-1.10.20.min.js"></script>

    <link href="Scripts/jquery.dataTables.min.css" rel="stylesheet" />
    <link href="Scripts/dataTables.bootstrap4.min.css" rel="stylesheet" />

    <script type="text/javascript">

        var prm = Sys.WebForms.PageRequestManager.getInstance();

        prm.add_endRequest(function (sender, e) {

            $('#ContentPlaceHolder1_grdvestingcorrection').dataTable({
                lengthMenu: [[-1, 5, 10], ["All", 5, 10]],
                columnDefs: [{ orderable: false, targets: [9] }],
                "bStateSave": true
            });

        });
        $(function () {
            $.noConflict();

            $("#ContentPlaceHolder1_grdvestingcorrection").DataTable({
                bLengthChange: true,
                lengthMenu: [[-1, 5, 10], ["All", 5, 10]],
                bFilter: true,
                //'columnDefs': [{
                //    'targets': [7],
                //    'orderable': false,
                //}],

                order: [],
                columnDefs: [{ orderable: false, targets: [9] }],
                bPaginate: true,
                bSort: true,
                "bStateSave": true
            });



        });
    </script>


    <script type="text/javascript">
        function ValidateTextbox() {
            debugger;
            //Reference the GridView.
            var grid = document.getElementById("<%=grdvestingcorrection.ClientID %>");

            //Reference all INPUT elements.
            var Inputs = grid.getElementsByTagName("INPUT");

            if (confirm("Are you sure you want to Update record?")) {
                for (i = 0; i < Inputs.length; i++) {
                    if (Inputs[i].type == 'text') {
                        if (Inputs[i].value == "") {
                            alert("Please enter no of option.");
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
    <asp:ScriptManager ID="script" runat="server"></asp:ScriptManager>

    <div class="main-content">
        <nav aria-label="breadcrumb" class="offset-md-9" style="margin-top: 13px;">
            <ol class="breadcrumb">
                <li class="breadcrumb-item"><a href="grants.aspx">Settings</a></li>
                <li class="breadcrumb-item active" aria-current="page">Grant Correction</li>
            </ol>
        </nav>
        <section class="section">

            <div class="col-lg-12 col-md-12 col-12 col-sm-12">
                <div class="card" style="height: auto;">
                    <div class="card-header">
                        <h4>Rejected Grant Details</h4>
                    </div>
                    <div class="card-body">
                        <div class="table-responsive">
                            <asp:UpdatePanel ID="upd" runat="server">
                                <ContentTemplate>
                                    <asp:GridView ID="grdvestingcorrection" runat="server" DataKeyNames="V_DETAIL_ID,ecode" AutoGenerateColumns="False"
                                        class="table" EmptyDataText="No Records Found" OnPreRender="grdvestingcorrection_PreRender"
                                        OnRowEditing="grdvestingcorrection_RowEditing"
                                        OnRowUpdating="grdvestingcorrection_RowUpdating" OnRowCancelingEdit="grdvestingcorrection_RowCancelingEdit"
                                        OnRowDeleting="grdvestingcorrection_RowDeleting" OnRowDataBound="grdvestingcorrection_RowDataBound">
                                        <Columns>
                                            <asp:TemplateField HeaderText="Employee ID" HeaderStyle-Width="5%">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblecode" runat="server" Text='<%#Eval("ecode") %>' />
                                                </ItemTemplate>
                                                <%-- <EditItemTemplate>
                                                    <asp:TextBox ID="Txt_EmployeeID" runat="server" Text='<%#Eval("ecode") %>'></asp:TextBox>
                                                </EditItemTemplate>--%>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Employee Name" HeaderStyle-Width="15%">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblname" runat="server" Text='<%#Eval("emp_name") %>' />
                                                </ItemTemplate>

                                                <%-- <EditItemTemplate>
                                                    <asp:TextBox ID="txtename" runat="server" Text='<%#Eval("emp_name") %>' Width="100px"></asp:TextBox>
                                                </EditItemTemplate>--%>


                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Manager Name" HeaderStyle-Width="15%">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblappname" runat="server" Text='<%#Eval("appraiser_name") %>' />
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Date of Grant" HeaderStyle-Width="10%">
                                                <ItemTemplate>
                                                    <asp:Label ID="lbldate" runat="server" Text='<%#Eval("Grant_Date") %>' />
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="No. of Grants" HeaderStyle-Width="5%">
                                                <ItemTemplate>
                                                    <asp:Label ID="lbloption" runat="server" Text='<%#Eval("no_of_vesting") %>' />
                                                </ItemTemplate>
                                                <EditItemTemplate>
                                                    <asp:TextBox ID="txtoption" runat="server" Text='<%#Eval("no_of_vesting") %>' Width="95%"></asp:TextBox>
                                                </EditItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Vesting Date" HeaderStyle-Width="5%">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblprice" runat="server" Text='<%#Eval("Vesting_Date") %>' />
                                                </ItemTemplate>
                                                <%-- <EditItemTemplate>
                                                    <asp:TextBox ID="txtprice" runat="server" Text='<%#Eval("fmv_price") %>' Width="100px"></asp:TextBox>
                                                </EditItemTemplate>--%>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Vesting Cycle" HeaderStyle-Width="5%">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblVesting" runat="server" Text='<%#Eval("vname") %>' />
                                                </ItemTemplate>
                                                <EditItemTemplate>
                                                    <asp:DropDownList ID="ddlVesting" runat="server" Width="100%">
                                                    </asp:DropDownList>
                                                </EditItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Rejected By">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblManagerName" runat="server" Text='<%#Eval("status") %>' />
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Rejection Remark" HeaderStyle-Width="10%">
                                                <ItemTemplate>
                                                    <asp:Label ID="Label1" runat="server" Text='<%#Eval("admin_vesting_remark") %>' />

                                                </ItemTemplate>
                                            </asp:TemplateField>

                                            <asp:TemplateField HeaderText="Action" HeaderStyle-Width="15%">
                                                <ItemTemplate>

                                                    <asp:LinkButton ID="btn_Edit" runat="server" CommandName="Edit" CausesValidation="false"
                                                        CssClass="fas fa-pencil-alt edit12"></asp:LinkButton>
                                                    <asp:LinkButton ID="btn_Delete" runat="server" CommandName="Delete" CausesValidation="true"
                                                        CssClass="fas fa-trash-alt delete12" OnClientClick="return confirm('Are you sure you want to Delete?');"></asp:LinkButton>


                                                </ItemTemplate>
                                                <EditItemTemplate>
                                                    <asp:LinkButton ID="btn_Update" runat="server" Text="Save & Send |" CommandName="Update" OnClientClick="return ValidateTextbox();"
                                                        CausesValidation="false"></asp:LinkButton>
                                                    <asp:LinkButton ID="btn_Cancel" runat="server" Text=" Cancel" CommandName="Cancel" CausesValidation="false"></asp:LinkButton>
                                                </EditItemTemplate>
                                            </asp:TemplateField>

                                        </Columns>
                                    </asp:GridView>
                                </ContentTemplate>
                                <Triggers>

                                    <asp:AsyncPostBackTrigger ControlID="grdvestingcorrection" />
                                </Triggers>
                            </asp:UpdatePanel>
                        </div>
                    </div>
                </div>
            </div>
        </section>
    </div>
    <footer class="main-footer">
        <%--  <div class="footer-left">
            Copyright &copy; 2020 
            <div class="bullet"></div>
            Design By <a href="#">Clover Infotech</a>
         </div>
         <div class="footer-right">
         </div>--%>
    </footer>

    <!-- General JS Scripts -->
    <script src="assets/js/app.min.js"></script>
    <!-- Page Specific JS File -->
    <script src="assets/js/page/index.js"></script>
    <!-- Template JS File -->
    <script src="assets/js/scripts.js"></script>
    <script src="assets/bundles/jquery.sparkline.min.js"></script>
    <script src="assets/bundles/prism/prism.js"></script>
    <script src="assets/css/custom.css"></script>
    <!-- JS Libraies -->
    <script src="assets/bundles/datatables/datatables.min.js"></script>
    <script src="assets/bundles/datatables/DataTables-1.10.16/js/dataTables.bootstrap4.min.js"></script>
    <script src="assets/bundles/jquery-ui/jquery-ui.min.js"></script>
    <!-- Page Specific JS File -->
    <script src="assets/js/page/datatables.js"></script>
    <script type="text/javascript">

        $(document).ready(function () {

            $('#grdvestingcorrection').hide();
            $('#btnimport').click(function () {

                $('#grdvestingcorrection').slideToggle();
                $('html, body').animate({
                    scrollTop: $("#grdvestingcorrection").offset().top
                }, 2000);

            });

        })

        $('#basic').simpleTreeTable({
            collapsed: true,

            expander: $('#expander'),
            collapser: $('#collapser')
        });

        $(document).ready(function () {
            $('#collapser').click();
            $('.simple-tree-table tr th:nth-child(4), .simple-tree-table tr th:nth-child(6), .simple-tree-table tr th:nth-child(8), .simple-tree-table tr th:nth-child(9), .simple-tree-table tr td:nth-child(4), .simple-tree-table tr td:nth-child(6), .simple-tree-table tr td:nth-child(8), .simple-tree-table tr td:nth-child(9)').addClass('toggleDisplay')
        });

        $(document).ready(function () {
            $('#txtsrch').change(function () {
                alert();
                if ($('#txtsrch').val().length > 1) {
                    $('#grdvaluation tr').hide();
                    $('#grdvaluation tr:first').show();
                    $('#grdvaluation tr td:containsNoCase(\'' + $('#txtsrch').val() + '\')').parent().show();
                }
                else if ($('#txtSearch').val().length == 0) {
                    resetSearchValue();
                }
            });
        });
    </script>
</asp:Content>
