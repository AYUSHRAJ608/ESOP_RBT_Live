<%@ Page Title="" Language="C#" MasterPageFile="~/ESOP.Master" MaintainScrollPositionOnPostback="false" AutoEventWireup="true" CodeBehind="Valuation_Master.aspx.cs" Inherits="ESOP.Valuation_Master" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <title>ESOP-Valuation Master</title>
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

        .offset-md-3 {
            margin-left: 29%;
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

    <%--<script type="text/javascript" src="https://ajax.googleapis.com/ajax/libs/jquery/1.8.3/jquery.min.js"></script>
    <script type="text/javascript" src="https://cdn.datatables.net/1.10.20/js/jquery.dataTables.min.js"></script>

    --%>

   

    <script src="assets/js/jquery-1.8.3.min.js"></script>
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
        })
    </script>

    <script type="text/javascript">
        $(document).ready(function () {
            debugger;
            var prm = Sys.WebForms.PageRequestManager.getInstance();

            prm.add_endRequest(function (sender, e) {

                var table = $('#ContentPlaceHolder1_grdvaluation').DataTable({
                    lengthMenu: [[-1, 5, 10], ["All", 5, 10]],
                    'columnDefs': [{
                        'targets': [2],
                        'orderable': false,
                    }],
                    pagingType: 'full_numbers',
                    bRetrieve: true,
                    bStateSave: true,
                });// bind data table on first page load
//                table
//.search('')
//.columns().search('')
//.draw();

            });

        });


        $(function () {
            debugger;
            $.noConflict();
            var table = $("#ContentPlaceHolder1_grdvaluation").DataTable({

                bLengthChange: true,
                lengthMenu: [[-1, 5, 10], ["All", 5, 10]],
                bFilter: true,
                'columnDefs': [{
                    'targets': [2],
                    'orderable': false,
                }],
                order: [],
                //columnDefs: [{ orderable: true, targets: [2] }],
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
            document.getElementById('<%=showmsg.ClientID%>').innerHTML = "";
            var Name = document.getElementById('<%=txtagencyname.ClientID%>').value;
            var address = document.getElementById('<%=txtagencyaddress.ClientID%>').value;

            if (Name.trim() == "") {
                alert("Please Enter Agency Name");
                document.getElementById('<%=txtagencyname.ClientID%>').focus();
                return false;
            }

            if (address.trim() == "") {
                alert("Please Enter Agency Address");
                document.getElementById('<%=txtagencyaddress.ClientID%>').focus();
                return false;
            }

        }
    </script>

    <script type="text/javascript">
        function ValidateTextbox() {
            debugger;
            //Reference the GridView.
            var grid = document.getElementById("<%=grdvaluation.ClientID %>");

            //Reference all INPUT elements.
            var Inputs = grid.getElementsByTagName("INPUT");

            //if (confirm("Are you sure want to Update record?")) {
            for (i = 0; i < Inputs.length; i++) {
                if (Inputs[i].type == 'text') {
                    if (Inputs[i].value.trim() == "") {
                        alert("Please enter value.");
                        return false;
                    }

                }
            }
            return true;
            //} else {
            //    return false;
            //}
        }
    </script>

    <script type="text/javascript">
        function ValidateAlpha(evt) {
            var keyCode = (evt.which) ? evt.which : evt.keyCode
            if ((keyCode < 65 || keyCode > 90) && (keyCode < 97 || keyCode > 123) && keyCode != 32)

                return false;
            return true;
        }
        function validate(evt) {
            //debugger;
          <%--   var Name = document.getElementById('<%=txt.ClientID%>').value;--%>
        }
    </script>

    <asp:ScriptManager ID="script" runat="server"></asp:ScriptManager>


    <asp:HiddenField ID="hdf1" runat="server" />
    <asp:HiddenField ID="hdf2" runat="server" />


    <div class="main-content">
        <nav aria-label="breadcrumb">
            <ol class="breadcrumb">
                <li class="breadcrumb-item"><a href="admin-dashboard.aspx">Home</a></li>
                <li class="breadcrumb-item"><a href="settings.aspx">Masters</a></li>
                <li class="breadcrumb-item active" aria-current="page">Valuation Master</li>
            </ol>
        </nav>
        <section class="section">

            <asp:UpdatePanel ID="UpdatePanel1" runat="server">

                <ContentTemplate>
                    <div class="row">
                        <div class="col-lg-12">
                            <div class="card">
                                <div class="card-header">
                                    <h4>Valuation Master</h4>
                                </div>
                                <div class="card-body">
                                    <div class="offset-md-2 row" style="margin-top: 15px;">
                                        <div class="col-lg-4 col-md-12 col-sm-12">
                                            <div class="form-group">
                                                <label>Agency Name <span style="color:red">*</span></label>
                                                <asp:TextBox ID="txtagencyname" runat="server" CssClass="form-control" MaxLength="50"></asp:TextBox>
                                                <%-- <asp:RequiredFieldValidator ID="RequiredFieldValidator1" ControlToValidate="txtagencyname"
                                        runat="server" ErrorMessage="Enter agency name" ForeColor="Red" ToolTip="Required" Style="font-size: 14px;"></asp:RequiredFieldValidator>--%>
                                            </div>
                                        </div>
                                        <div class="col-lg-4 col-md-12 col-sm-12">
                                            <div class="form-group">
                                                <label>Agency Address <span style="color:red">*</span></label>
                                                <asp:TextBox ID="txtagencyaddress" TextMode="MultiLine" Height="100" runat="server" CssClass="form-control" onkeypress="if(this.value.length > 99) {return false;}" AutoPostBack="false"></asp:TextBox>
                                                <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator2" ControlToValidate="txtagencyaddress"
                                        runat="server" ErrorMessage="Enter agency address" ForeColor="Red" ToolTip="Required" Style="font-size: 14px;"></asp:RequiredFieldValidator>--%>
                                            </div>
                                        </div>
                                        <div class="col-lg-3 offset-md-3" style="margin-top: 7rem !important;">
                                            <asp:Button ID="btnSave" runat="server" Text="Create" OnClick="btnSaveValuation_click"
                                                class="btn btn-info btn-lg all" CausesValidation="true" OnClientClick=" return ReqValidation();" />

                                        </div>
                                    </div>
                                     <div style="color:red"; align="right">
                                    All (*) marked fields are mandatory.
                                </div>
                                </div>
                                <asp:UpdatePanel ID="upd1" runat="server">
                                    <ContentTemplate>
                                        <div id="showmsg" runat="server" align="center"></div>
                                    </ContentTemplate>
                                </asp:UpdatePanel>
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
                            <%--                    <asp:UpdatePanel ID="upd" runat="server" UpdateMode="Conditional" class="table dataTable no-footer" aria-describedby="table-2_info">--%>

                            <asp:UpdatePanel ID="upd" runat="server">
                                <ContentTemplate>
                                    <asp:GridView ID="grdvaluation" runat="server" AutoGenerateColumns="False" ShowHeaderWhenEmpty="false"
                                        DataKeyNames="AGENCY_ID" OnRowEditing="grdvaluation_RowEditing" EmptyDataText=""
                                        OnRowUpdating="grdvaluation_RowUpdating" OnPreRender="grdvaluation_PreRender"
                                        OnRowCancelingEdit="grdvaluation_RowCancelingEdit" OnRowDeleting="grdvaluation_RowDeleting"
                                        class="table">
                                        <%-- <RowStyle HorizontalAlign="Left" />--%>
                                        <Columns>

                                            <asp:TemplateField HeaderText="Agency Name">


                                                <ItemTemplate>
                                                    <asp:Label ID="agency_name" runat="server" Text='<%#Eval("agency_name") %>' CssClass="align-left" />
                                                </ItemTemplate>
                                                <ItemStyle HorizontalAlign="Left" VerticalAlign="Middle" />
                                                <EditItemTemplate>
                                                    <asp:TextBox ID="txt_agency_name" MaxLength="50" CssClass="align-content-center"
                                                        runat="server" Text='<%#Eval("agency_name") %>'></asp:TextBox>
                                                    <%--onKeyPress="return ValidateAlpha(event);"--%>
                                                </EditItemTemplate>
                                            </asp:TemplateField>

                                            <asp:TemplateField HeaderText="Agency Address">

                                                <ItemTemplate>
                                                    <asp:Label ID="agency_address" runat="server" Text='<%#Eval("agency_address") %>' />
                                                </ItemTemplate>
                                                <EditItemTemplate>
                                                    <asp:TextBox ID="txt_agency_address" MaxLength="100" runat="server" onkeypress="if(this.value.length > 99 ){return false;}"
                                                        Text='<%#Eval("agency_address") %>'></asp:TextBox>
                                                </EditItemTemplate>
                                            </asp:TemplateField>


                                            <asp:TemplateField HeaderText="Action">
                                                <ItemTemplate>

                                                    <asp:LinkButton ID="btn_Edit" runat="server" CommandName="Edit" CausesValidation="false"
                                                        CssClass="fas fa-pencil-alt edit12" ViewStateMode="Disabled"></asp:LinkButton>
                                                    <asp:LinkButton ID="btn_Delete" runat="server" CommandName="Delete" CausesValidation="true"
                                                        CssClass="fas fa-trash-alt delete12"></asp:LinkButton><%--OnClientClick="return confirm('Are you sure you want to Delete?');"--%>
                                                </ItemTemplate>
                                                <EditItemTemplate>
                                                    <asp:LinkButton ID="btn_Update" runat="server" CssClass="fas fa-check update edit12" CommandName="Update" OnClientClick="return ValidateTextbox();"></asp:LinkButton>
                                                    <%-- --%>
                                                    <asp:LinkButton ID="btn_Cancel" runat="server" CssClass="fas fa-times cancel delete12" CommandName="Cancel"></asp:LinkButton>
                                                </EditItemTemplate>
                                            </asp:TemplateField>
                                        </Columns>
                                    </asp:GridView>

                                </ContentTemplate>
                                <Triggers>
                                    <asp:AsyncPostBackTrigger ControlID="btnSave" EventName="Click" />
                                    <%--  <asp:AsyncPostBackTrigger ControlID="txtsrch" EventName="Click" />--%>
                                </Triggers>
                            </asp:UpdatePanel>

                        </div>
                    </div>
                </div>
            </div>
        </section>
    </div>

    <%-- <footer class="main-footer">
         <div class="footer-left">
            Copyright &copy; 2020 
            <div class="bullet"></div>
            Design By <a href="#">Clover Infotech</a>
        </div>
        <div class="footer-right">
        </div>
    </footer>--%>
    <script src="Scripts/bootstrap.min.js"></script>

    <script src="assets/js/app.min.js"></script>
    <!-- JS Libraies -->
    <%--    <script src="assets/bundles/echart/echarts.js"></script>--%>
    <!-- JS Libraies -->
    <%--  <script src="assets/bundles/datatables/datatables.min.js"></script>
    <script src="assets/bundles/datatables/DataTables-1.10.16/js/dataTables.bootstrap4.min.js"></script>--%>
    <script src="assets/bundles/jquery-ui/jquery-ui.min.js"></script>
    <!-- Page Specific JS File -->
    <%--    <script src="assets/js/page/chart-echarts.js"></script>--%>
    <!-- Page Specific JS File -->
    <%--    <script src="assets/js/page/index.js"></script>--%>
    <!-- Template JS File -->
    <script src="assets/js/scripts.js"></script>
    <script src="assets/bundles/jquery.sparkline.min.js"></script>
    <%--    <script src="assets/bundles/bootstrap-daterangepicker/daterangepicker.js"></script>
    <script src="assets/bundles/bootstrap-timepicker/js/bootstrap-timepicker.min.js"></script>--%>
    <%--   <script type="text/javascript" src="https://www.jqueryscript.net/demo/simple-tree-table/jquery-simple-tree-table.js"></script>
    <link rel="stylesheet" type="text/css" href="https://www.jqueryscript.net/demo/simple-tree-table/jquery-simple-tree-table.css" />--%>
    <script src="assets/bundles/sweetalert/sweetalert.min.js"></script>
    <!-- Page Specific JS File -->
    <script src="assets/js/page/sweetalert.js"></script>
    <script src="assets/bundles/prism/prism.js"></script>





    <%--    <script type="text/javascript">
        $(document).ready(function () {

            $('#grdvaluation').hide();
            $('#btnimport').click(function () {

                $('#grdvaluation').slideToggle();
                $('html, body').animate({
                    scrollTop: $("#grdvaluation").offset().top
                }, 2000);

            });

        })

        //$('#basic').simpleTreeTable({
        //    collapsed: true,

        //    expander: $('#expander'),
        //    collapser: $('#collapser')
        //});

        //$(document).ready(function () {
        //    $('#collapser').click();
        //    $('.simple-tree-table tr th:nth-child(4), .simple-tree-table tr th:nth-child(6), .simple-tree-table tr th:nth-child(8), .simple-tree-table tr th:nth-child(9), .simple-tree-table tr td:nth-child(4), .simple-tree-table tr td:nth-child(6), .simple-tree-table tr td:nth-child(8), .simple-tree-table tr td:nth-child(9)').addClass('toggleDisplay')
        //});


    </script>--%>
</asp:Content>

