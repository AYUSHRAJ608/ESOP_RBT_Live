<%@ Page Language="C#" MasterPageFile="~/ESOP.Master" AutoEventWireup="true" EnableEventValidation="false" CodeBehind="AdminGrantUpdation.aspx.cs" Inherits="ESOP.AdminGrantUpdation" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <%--<style>
        .edit12 {
            padding: 6px;
            background: #0abae1;
            color: white !important;
            border-radius: 4px;
            line-height: -1;
            /*height: 20px;*/
            vertical-align: middle;
            width: 30px;
        }


        .delete12 {
            padding: 6px;
            background: #f30808;
            color: white !important;
            border-radius: 4px;
            line-height: -1;
            margin-left: 4px;
            width: 30px;
        }

        .card; {
            height: auto;
        }

        .text-muted {
            color: #1ea3c1 !important;
            font-weight: 600;
        }

        .card .card-header h4 {
            font-size: 17px;
        }

        .table:not(.table-sm) thead th {
            background-color: rgb(163 236 236 / 86%);
            color: #157b92;
            font-size: 14px !important;
        }


        .table td {
            font-weight: 500;
            color: #3f646d;
            font-size: 14px;
            background: #29bbdc14;
        }
    </style>--%>
    <%--  <style>
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
            background-color: #6c757d75 !important;
            color: #000000c2 !important;
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
            height: 25px;
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
            background: #2673FF;
            color: white !important;
            border-radius: 4px;
            line-height: 0;
        }

        .delete12 {
            padding: 10px;
            background: #e3001b;
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
            margin-left: 83%;
        }

        a {
            color: #000000c2 !important;
        }

        .table:not(.table-sm):not(.table-md):not(.dataTable) td, .table:not(.table-sm):not(.table-md):not(.dataTable) th {
            padding: 0px 2px;
            vertical-align: middle !important;
            font-size: 14px;
            font-weight: 500;
            text-align: center;
            border: 1px solid #96a2b44a !important;
            color: #000000c2 !important;
        }

        .table:not(.table-sm) thead th {
            background-color: #6c757d75 !important;
            color: #000000c2 !important;
            font-size: 14px !important;
            font-size: 15px !important;
            padding: 6px;
        }

        .table:not(.table-sm):not(.table-md):not(.dataTable) th {
            background: #6c757d75 !important;
            color: #000000c2 !important;
        }
    </style>--%>


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

    <%--    <script type="text/javascript" src="https://ajax.googleapis.com/ajax/libs/jquery/1.8.3/jquery.min.js"></script>--%>
    <%--    <script type="text/javascript" src="https://cdn.datatables.net/1.10.20/js/jquery.dataTables.min.js"></script>--%>

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

        var prm = Sys.WebForms.PageRequestManager.getInstance();

        prm.add_endRequest(function (sender, e) {

            var table = $('#ContentPlaceHolder1_GrvAdminGUP').DataTable({
                lengthMenu: [[-1, 5, 10], ["All", 5, 10]],
                columnDefs: [{ orderable: false, targets: [9, 10, 11] }],
                "bStateSave": true,
                bRetrieve: true, fixedHeader: true, "scrollX": true
            });
            //        table
            //.search('')
            //.columns().search('')
            //.draw();

        });

        $(function () {
            $.noConflict();

            var table = $("#ContentPlaceHolder1_GrvAdminGUP").DataTable({
                bLengthChange: true,
                lengthMenu: [[-1, 5, 10], ["All", 5, 10]],
                bFilter: true,
                //'columnDefs': [{
                //    'targets': [7],
                //    'orderable': false,
                //}],

                order: [],
                columnDefs: [{ orderable: false, targets: [9, 10, 11] }],
                bPaginate: true,
                bSort: true,
                "bStateSave": true, fixedHeader: true, "scrollX": true
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
                columnDefs: [{ orderable: false, targets: [9, 10, 11] }],

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
                columnDefs: [{ orderable: false, targets: [9, 10, 11] }],
                bPaginate: true,
                bSort: true,
                fixedHeader: true, "scrollX": true
            });



        });
    </script>


    <script type="text/javascript">
        function ValidateTextbox() {
            debugger;
            //Reference the GridView.
            var grid = document.getElementById("<%=GrvAdminGUP.ClientID %>");

            //Reference all INPUT elements.
            var Inputs = grid.getElementsByTagName("INPUT");

            //if (confirm("Are you sure you want to Update record?")) {
            for (i = 0; i < Inputs.length; i++) {
                if (Inputs[i].type == 'text') {
                    if (Inputs[i].value == "") {
                        alert("Please enter no of option.");
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

    <script language="Javascript">
        function isNumberKey(evt) {
            var charCode = (evt.which) ? evt.which : evt.keyCode;
            if (charCode > 31 && (charCode < 48 || charCode > 57))
                return false;
            return true;
        }
    </script>
    <script>
        function validateCheckBoxes() {
            debugger;
            var isValid = false;
            var gridView = document.getElementById('<%= GrvAdminGUP.ClientID %>');
            for (var i = 1; i < gridView.rows.length; i++) {
                var inputs = gridView.rows[i].getElementsByTagName('textarea');
                console.log(inputs[0].value);
                if (inputs[0].value == null || inputs[0].value == "") {
                    
                        alert("Please Enter the reason for rejection.");
                        return false;
                }
            }
            
        }
    </script>
    <asp:ScriptManager ID="script" runat="server"></asp:ScriptManager>
    <div class="main-content">
        <nav aria-label="breadcrumb" >
            <ol class="breadcrumb" >
                <li class="breadcrumb-item"><a href="admin-dashboard.aspx">Home</a></li>
                <li class="breadcrumb-item"><a href="grants.aspx">Grant</a></li>
                <li class="breadcrumb-item active" aria-current="page">Grant Updation</li>
            </ol>
        </nav>
        <section class="section">

            <div class="col-lg-12 col-md-12 col-12 col-sm-12">
                <div class="card" style="height: auto;">
                    <div class="card-header">
                        <h4>Update Grant Details</h4>
                    </div>

                    <asp:UpdatePanel ID="upd3" runat="server">
                        <ContentTemplate>
                            <div id="showmsg" runat="server"></div>
                        </ContentTemplate>
                    </asp:UpdatePanel>

                    <div class="card-body">
                        <div class="table-responsive">
                            <asp:UpdatePanel ID="upd" runat="server" UpdateMode="Conditional" class="table dataTable no-footer" aria-describedby="table-2_info">
                                <ContentTemplate>
                                    <asp:GridView ID="GrvAdminGUP" runat="server" DataKeyNames="GRANT_ID,EmployeeID" AutoGenerateColumns="False"
                                        class="table" OnPreRender="GrvAdminGUP_PreRender"
                                        EmptyDataText="" OnRowEditing="GrvAdminGUP_RowEditing"
                                        OnRowUpdating="GrvAdminGUP_RowUpdating" OnRowCancelingEdit="GrvAdminGUP_RowCancelingEdit"
                                        OnRowDeleting="GrvAdminGUP_RowDeleting" OnRowDataBound="GrvAdminGUP_RowDataBound" OnRowCommand="GrvAdminGUP_RowCommand">
                                        <Columns>
                                            <asp:TemplateField HeaderText="Employee Code" SortExpression="EmployeeID" HeaderStyle-Width="10.5%">
                                                <ItemTemplate>
                                                    <asp:Label ID="EmployeeID" runat="server" Text='<%#Eval("EmployeeID") %>' />
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Employee Name" SortExpression="EmployeeName" HeaderStyle-Width="12.5%">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblEmployeeName" runat="server" Text='<%#Eval("EmployeeName") %>' />
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Manager Name" SortExpression="ManagerName" HeaderStyle-Width="12.5%">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblManagerName" runat="server" Text='<%#Eval("ManagerName") %>' />
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Date of Grant" SortExpression="Date_of_Grant" HeaderStyle-Width="13%">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblDateofGrant" runat="server" Text='<%#Eval("Date_of_Grant") %>' />
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Created Date">
                                                <ItemTemplate>
                                                    <asp:Label ID="lbl_creation_date" runat="server" Text='<%#Eval("creation_date") %>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Tranch Code" HeaderStyle-Width="12.5%">
                                                <ItemTemplate>
                                                    <asp:Label ID="lbltranchcode" runat="server" Text='<%#Eval("grant_name") %>' />
                                                </ItemTemplate>
                                            </asp:TemplateField>


                                            <asp:TemplateField HeaderText="No. of Grants" HeaderStyle-Width="10%">
                                                <ItemTemplate>
                                                    <asp:Label ID="No_of_Grants" runat="server" Text='<%#Eval("NoofGrants") %>' />
                                                </ItemTemplate>
                                                <EditItemTemplate>
                                                    <asp:TextBox ID="Txt_No_of_Grants" runat="server" Width="70" Text='<%#Eval("NoofGrants") %>' onkeypress="return isNumberKey(event)"></asp:TextBox>
                                                </EditItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Grant Price" HeaderStyle-Width="10.5%">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblGrantPrice" runat="server" Text='<%#Eval("GrantPrice") %>' />
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Vesting Cycle" HeaderStyle-Width="12.5%">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblVesting" runat="server" Text='<%#Eval("vname") %>' />
                                                </ItemTemplate>
                                                <EditItemTemplate>
                                                    <asp:DropDownList ID="ddlVesting" runat="server" Width="90">
                                                    </asp:DropDownList>
                                                </EditItemTemplate>
                                            </asp:TemplateField>


                                            <asp:TemplateField HeaderText="Pending with" HeaderStyle-Width="12.5%">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblPendingWith" runat="server" Text='<%#Eval("PENDINGWITH") %>' />
                                                </ItemTemplate>
                                            </asp:TemplateField>


                                            <asp:TemplateField HeaderText="Remark" HeaderStyle-Width="12.5%">
                                                <ItemTemplate>
                                                    <asp:Label ID="lbladmin_grant_updation_remark" runat="server" Text='<%#Eval("admin_grant_updation_remark") %>' />
                                                </ItemTemplate>
                                                <EditItemTemplate>
                                                    <div class="remark">
                                                        <asp:TextBox ID="txtremark" runat="server" ondrop="return false;" ondrag="return false;" Width="90"
                                                            placeholder="Enter Remark" Text='<%#Eval("admin_grant_updation_remark") %>'
                                                            TextMode="MultiLine" onKeyUp="javascript:Count(this);"
                                                            onChange="javascript:Count(this);"></asp:TextBox>
                                                    </div>
                                                </EditItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Action" HeaderStyle-Width="13%">
                                                <ItemTemplate>
                                                    <table>
                                                        <tr>
                                                            <td>
                                                                <asp:LinkButton ID="btn_Edit" runat="server" CommandName="Edit" CausesValidation="false"
                                                                    CssClass="fas fa-pencil-alt edit12"></asp:LinkButton>
                                                            </td>
                                                            <td>
                                                                <asp:LinkButton ID="btn_Delete" runat="server" CommandName="Delete" CausesValidation="false"
                                                                    CssClass="fas fa-trash-alt delete12"></asp:LinkButton>
                                                            </td>
                                                        </tr>
                                                    </table>
                                                    <%--OnClientClick="return confirm('Are you sure you want to Delete record?');"--%>
                                                </ItemTemplate>
                                                <EditItemTemplate>
                                                    <asp:LinkButton ID="btn_Update" runat="server" CssClass="fas fa-check update edit12" CommandName="Update" OnClientClick="return ValidateTextbox();" CausesValidation="false"></asp:LinkButton>
                                                    <asp:LinkButton ID="btn_Cancel" runat="server" CssClass="fas fa-times cancel delete12" CommandName="Cancel" CausesValidation="false"></asp:LinkButton>
                                                </EditItemTemplate>
                                            </asp:TemplateField>

                                            <asp:TemplateField HeaderText="Audit Trail" HeaderStyle-Width="12.5%">
                                                <ItemTemplate>
                                                    <asp:LinkButton ID="btn_Audit" runat="server" CommandName="Audit" CausesValidation="true"
                                                        CommandArgument="<%# ((GridViewRow) Container).RowIndex %>"
                                                        CssClass="fas fa-info edit12"></asp:LinkButton>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                        </Columns>
                                    </asp:GridView>
                                </ContentTemplate>
                            </asp:UpdatePanel>
                        </div>
                    </div>
                </div>
            </div>
        </section>

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
                            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                                <ContentTemplate>
                                    <asp:GridView ID="grdData" class="table" runat="server" Style="width: 100%;"
                                        AutoGenerateColumns="False" OnRowDataBound="grdData_RowDataBound" OnPreRender="grdData_PreRender"
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
                                            <asp:TemplateField HeaderText="Admin Remark">
                                                <ItemTemplate>
                                                    <asp:Label ID="lbl_Admin_remark" runat="server" Text='<%#Server.HtmlEncode(Eval("ADMIN_GRANT_UPDATION_REMARK").ToString()) %>'></asp:Label>
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
                                        <PagerSettings FirstPageText="First" LastPageText="Last" NextPageText="Next" PreviousPageText="Previous" />

                                        <%--<PagerStyle CssClass="text-right border-pagination" />--%>
                                    </asp:GridView>
                                    <%--<div class="clearfix"></div>--%>
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
    </div>
    <script src="Scripts/bootstrap.min.js"></script>

    <script src="assets/js/app.min.js"></script>

    <script src="assets/js/scripts.js"></script>
    <script type="text/javascript">
        function openModalShowAudit() {
            debugger;
            $('#my_Grant_Up_Modal').modal('show');
        }
    </script>

    <style>
        .modal-backdrop.in {
            display: block;
        }

        .modal-backdrop {
            background-color: #0003;
        }

        .modalClose {
            color: #fff;
            margin: 0 !important;
            padding: 0 !important;
            top: -4px;
            position: relative;
            display: inline-block;
            opacity: 1;
            font-size: 28px;
        }

            .modalClose:hover {
                color: #fff;
            }

        .boxModalDiv {
            box-shadow: 0 4px 15px rgba(0, 0, 0, .2);
            margin-left: auto;
            margin-right: auto;
        }
    </style>
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
