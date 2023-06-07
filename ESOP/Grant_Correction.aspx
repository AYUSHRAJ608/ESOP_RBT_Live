<%@ Page Title="" Language="C#" MasterPageFile="~/ESOP.Master" AutoEventWireup="true" CodeBehind="Grant_Correction.aspx.cs" Inherits="ESOP.Grant_Correction" EnableEventValidation="false" %>

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
            background: linear-gradient(180deg, #4DCC00 0, #16c655 100%);
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
            color: #000 !important;
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


    <script src="assets/js/jquery-1.8.3.min.js" type="text/javascript"></script>
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
    <script type="text/javascript">

        var prm = Sys.WebForms.PageRequestManager.getInstance();

        prm.add_endRequest(function (sender, e) {

            var table = $('#ContentPlaceHolder1_grdgrntcorrection').DataTable({
                lengthMenu: [[-1, 5, 10], ["All", 5, 10]],
                columnDefs: [{ orderable: false, targets: [0,10, 11,12] }],
                "bStateSave": true,
                bRetrieve: true, fixedHeader: true, "scrollX": true
            });

            //            table
            //.search('')
            //.columns().search('')
            //.draw();
        });
        $(function () {
            $.noConflict();

            var table = $("#ContentPlaceHolder1_grdgrntcorrection").DataTable({
                bLengthChange: true,
                lengthMenu: [[-1, 5, 10], ["All", 5, 10]],
                bFilter: true,
                //'columnDefs': [{
                //    'targets': [7],
                //    'orderable': false,
                //}],

                order: [],
                columnDefs: [{ orderable: false, targets: [0,10, 11,12] }],
                bPaginate: true,
                bSort: true,
                bStateSave: true, fixedHeader: true, "scrollX": true
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
        function ValidateTextbox() {
            debugger;
            //Reference the GridView.
            var grid = document.getElementById("<%=grdgrntcorrection.ClientID %>");

            //Reference all INPUT elements.
            var Inputs = grid.getElementsByTagName("INPUT");

            // if (confirm("Are you sure you want to Update record?")) {
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
     <script type="text/javascript">
        function bulkvalidateCheckBoxesapprove() {
            //  debugger;
            var isValid = false;
            var gridView = document.getElementById('<%= grdgrntcorrection.ClientID %>');
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
        function bulkvalidateCheckBoxesreject() {
            //debugger;
            var isValid = false;
            var gridView = document.getElementById('<%= grdgrntcorrection.ClientID %>');
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
        $(document).ready(function () {

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
              <script>
        function validateCheckBoxes() {
            debugger;
            var isValid = false;
            var gridView = document.getElementById('<%= grdgrntcorrection.ClientID %>');
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
                <li class="breadcrumb-item active" aria-current="page">Grant Correction</li>
            </ol>
        </nav>
        <section class="section">

            <div class="col-lg-12 col-md-12 col-12 col-sm-12">
                <div class="card" style="height: auto;">
                    <div class="card-header">
                        <h4>Rejected Grant Details</h4>
                        <div class="offset-md-7 buttons" style="margin-left: 60.333333%" id="showhidebtn">
                                        <asp:Button ID="btn_bulkApprove" runat="server" CommandName="Bulk Approve" CausesValidation="false" OnClick="btn_bulkApprove_Click" OnClientClick="return bulkvalidateCheckBoxesapprove();"
                                            Text="Bulk Approve" CssClass="btn badge badge-success badge-shadow"></asp:Button>
                                        <asp:Button ID="btn_bulkReject" runat="server" CommandName="Bulk Reject" CausesValidation="false" OnClick="btn_bulkReject_Click" OnClientClick="return bulkvalidateCheckBoxesreject();"
                                            Text="Bulk Reject" CssClass="btn badge badge-danger badge-shadow"></asp:Button>
                                    </div>
                    </div>

                    <asp:UpdatePanel ID="upd3" runat="server">
                        <ContentTemplate>
                            <div id="showmsg" runat="server"></div>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                    <div class="card-body">
                        <asp:Label ID="lbldisplay" runat="server"></asp:Label>
                        <div class="table-responsive">
                            <asp:UpdatePanel ID="upd" runat="server" UpdateMode="Conditional" class="table dataTable no-footer" aria-describedby="table-2_info">
                                <ContentTemplate>
                                    <asp:GridView ID="grdgrntcorrection" runat="server" DataKeyNames="GRANT_ID,ecode" AutoGenerateColumns="False"
                                        class="table" EmptyDataText="" OnPreRender="grdgrntcorrection_PreRender"
                                        OnRowEditing="grdgrntcorrection_RowEditing"
                                        OnRowUpdating="grdgrntcorrection_RowUpdating" OnRowCancelingEdit="grdgrntcorrection_RowCancelingEdit"
                                        OnRowDeleting="grdgrntcorrection_RowDeleting" OnRowDataBound="grdgrntcorrection_RowDataBound" OnRowCommand="grdgrntcorrection_RowCommand">
                                        <Columns>
                                            <%--<asp:TemplateField HeaderText="GRANT_ID" HeaderStyle-Width="5%">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblecode_1" runat="server" Text='<%#Eval("GRANT_ID") %>' />
                                                </ItemTemplate>
                                                <EditItemTemplate>
                                                    <asp:TextBox ID="Txt_EmployeeID" runat="server" Text='<%#Eval("ecode") %>'></asp:TextBox>
                                                </EditItemTemplate>
                                            </asp:TemplateField>--%>
                                            <asp:TemplateField>
                                                            <HeaderTemplate>
                                                                <asp:CheckBox ID="checkAll" runat="server" />
                                                                <%--  <asp:CheckBox runat="server" ID="chk2" onclick="checkAll(this);" CssClass="custom-control-label" />--%>
                                                            </HeaderTemplate>
                                                            <ItemTemplate>
                                                                <asp:CheckBox runat="server" ID="chk" CssClass="custom-control-label" />
                                                            </ItemTemplate>
                                                        </asp:TemplateField>

                                            <asp:TemplateField HeaderText="Employee Code" HeaderStyle-Width="10.5%">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblecode" runat="server" Text='<%#Eval("ecode") %>' />
                                                </ItemTemplate>
                                                <%-- <EditItemTemplate>
                                                    <asp:TextBox ID="Txt_EmployeeID" runat="server" Text='<%#Eval("ecode") %>'></asp:TextBox>
                                                </EditItemTemplate>--%>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Employee Name" HeaderStyle-Width="12.5%">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblname" runat="server" Text='<%#Eval("emp_name") %>' />
                                                </ItemTemplate>

                                                <%-- <EditItemTemplate>
                                                    <asp:TextBox ID="txtename" runat="server" Text='<%#Eval("emp_name") %>' Width="100px"></asp:TextBox>
                                                </EditItemTemplate>--%>


                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Manager Name" HeaderStyle-Width="12.5%">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblappname" runat="server" Text='<%#Eval("appraiser_name") %>' />
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Date of Grant" HeaderStyle-Width="13%">
                                                <ItemTemplate>
                                                    <asp:Label ID="lbldate" runat="server" Text='<%#Eval("date_of_grant") %>' />
                                                </ItemTemplate>
                                            </asp:TemplateField>

                                            <asp:TemplateField HeaderText="Tranch Code" HeaderStyle-Width="12.5%">
                                                <ItemTemplate>
                                                    <asp:Label ID="lbltranchcode" runat="server" Text='<%#Eval("grant_name") %>' />
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="No. of Grants" HeaderStyle-Width="10%">
                                                <ItemTemplate>
                                                    <asp:Label ID="lbloption" runat="server" Text='<%#Eval("no_of_options") %>' />
                                                </ItemTemplate>
                                                <EditItemTemplate>
                                                    <asp:TextBox ID="txtoption" runat="server" Text='<%#Eval("no_of_options") %>' onkeypress="return isNumberKey(event)" Width="95%"></asp:TextBox>
                                                </EditItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Grant Price" HeaderStyle-Width="10.5%">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblprice" runat="server" Text='<%#Eval("fmv_price") %>' />
                                                </ItemTemplate>
                                                <%-- <EditItemTemplate>
                                                    <asp:TextBox ID="txtprice" runat="server" Text='<%#Eval("fmv_price") %>' Width="100px"></asp:TextBox>
                                                </EditItemTemplate>--%>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Vest Cycle" HeaderStyle-Width="12.5%">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblVesting" runat="server" Text='<%#Eval("vname") %>' />
                                                </ItemTemplate>
                                                <EditItemTemplate>
                                                    <asp:DropDownList ID="ddlVesting" runat="server" Width="100%">
                                                    </asp:DropDownList>
                                                </EditItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Rej By" HeaderStyle-Width="12.5%">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblManagerName" runat="server" Text='<%#Eval("status") %>' />
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <%-- <asp:TemplateField HeaderText="Rejection Remark" HeaderStyle-Width="10%">
                                                <ItemTemplate>
                                                    <asp:Label ID="Label1" runat="server" Text='<%#Eval("remark2") %>' />

                                                </ItemTemplate>
                                            </asp:TemplateField>--%>

                                            <asp:TemplateField HeaderText="Remark" HeaderStyle-Width="10%">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblADMIN_GRANT_CORRECTION_REJECTION_REMARK" runat="server" Text='<%#Eval("ADMIN_GRANT_CORRECTION_REJECTION_REMARK") %>' />
                                                </ItemTemplate>
                                                <EditItemTemplate>
                                                    <div class="remark">
                                                        <asp:TextBox ID="txtremark" runat="server" ondrop="return false;" ondrag="return false;" placeholder="Enter Remark" Width="90"
                                                            Text='<%#Eval("ADMIN_GRANT_CORRECTION_REJECTION_REMARK") %>' TextMode="MultiLine" onKeyUp="javascript:Count(this);"
                                                            onChange="javascript:Count(this);" OnClientClick="return validateCheckBoxes();"></asp:TextBox>
                                                    </div>
                                                </EditItemTemplate>
                                            </asp:TemplateField>


                                            <asp:TemplateField HeaderText="Action" HeaderStyle-Width="20%">
                                                <ItemTemplate>

                                                    <asp:LinkButton ID="btn_Edit" runat="server" CommandName="Edit" CausesValidation="false"
                                                        CssClass="fas fa-pencil-alt edit12"></asp:LinkButton>
                                                    <asp:LinkButton ID="btn_Delete" runat="server" CommandName="Delete" CausesValidation="true"
                                                        CssClass="fas fa-trash-alt delete12"></asp:LinkButton>
                                                    <%--OnClientClick="return confirm('Are you sure you want to Delete?');"--%>
                                                </ItemTemplate>
                                                <EditItemTemplate>
                                                    <asp:LinkButton ID="btn_Update" runat="server" CssClass="fas fa-check update edit12" CommandName="Update" OnClientClick="return ValidateTextbox();"
                                                        CausesValidation="false"></asp:LinkButton>
                                                    <asp:LinkButton ID="btn_Cancel" runat="server" CssClass="fas fa-times cancel delete12" CommandName="Cancel" CausesValidation="false"></asp:LinkButton>
                                                </EditItemTemplate>
                                            </asp:TemplateField>

                                            <asp:TemplateField HeaderText="Audit Trail" HeaderStyle-Width="2%">
                                                <ItemTemplate>
                                                    <asp:LinkButton ID="btn_Audit" runat="server" CommandName="Audit" CausesValidation="true"
                                                        CommandArgument="<%# ((GridViewRow) Container).RowIndex %>"
                                                        CssClass="fas fa-info edit12"></asp:LinkButton>
                                                </ItemTemplate>
                                            </asp:TemplateField>

                                        </Columns>
                                    </asp:GridView>
                                </ContentTemplate>
                                <Triggers>
                                    <asp:AsyncPostBackTrigger ControlID="grdgrntcorrection" EventName="RowCommand" />
                                    <asp:AsyncPostBackTrigger ControlID="grdgrntcorrection" />
                                </Triggers>
                            </asp:UpdatePanel>
                        </div>
                    </div>
                </div>
            </div>
        </section>


        <%--<a href="#" class="fas fa-info edit12" data-toggle="modal" data-target="#my_Grant_Corr_Modal" style="display: none"></a>--%>
        <div class="modal bd-example-modal-lg" id="my_Grant_Corr_Modal" tabindex="-1" role="dialog">
            <div class="modal-dialog modal-xl boxModalDiv">
                <!-- Modal content-->
                <div class="modal-content" style="width: 100%;">
                    <div class="modal-header">
                        <h5 class="modal-title" id="myLargeModalLabel">Audit Trail
                        </h5>
                    </div>
                    <div class="col-lg-3 offset-md-3" style="padding-top: 12px; margin-left: 88%;">
                        <asp:ImageButton ID='imgExportAudit' runat='server' ImageUrl="~/img/excel1.png" Style="margin-left: 18px;" Height="35px" ToolTip="Export To Excel" OnClick="imgExportAudit_Click" />
                        <asp:ImageButton ID='btnpdfexport' runat='server' ImageUrl="~/img/pdf.png" Height="35px" ToolTip="Export To Pdf" OnClick="btnExportPDF_Click1" />
                    </div>
                    <div class="card-body">
                        <div class="table-responsive">
                            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                                <ContentTemplate>
                                    <asp:GridView ID="grdData" class="table" runat="server" Style="width: 98%;" OnPreRender="grdData_PreRender"
                                        AutoGenerateColumns="False" AllowPaging="false" PageSize="10" AllowSorting="false" OnPageIndexChanging="grdData_PageIndexChanging"
                                        OnRowDataBound="grdData_RowDataBound"
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
                                                    <asp:Label ID="lbl_Admin_remark" runat="server" Text='<%#Server.HtmlEncode(Eval("ADMIN_GRANT_CORRECTION_REJECTION_REMARK").ToString()) %>'></asp:Label>
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

            $('#grdgrntcorrection').hide();
            $('#btnimport').click(function () {

                $('#grdgrntcorrection').slideToggle();
                $('html, body').animate({
                    scrollTop: $("#grdgrntcorrection").offset().top
                }, 2000);

            });

        })

        //$('#basic').simpleTreeTable({
        //    collapsed: true,

        //    expander: $('#expander'),
        //    collapser: $('#collapser')
        //});

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

            //$("[data-dismiss=modal]").click(function () {
            //    // $(this).closest('.modal').modal('hide');
            //    $('.modal').modal('hide');
            //    $('.modal-backdrop').hide();
            //    return false;
            //});
        });
    </script>

    <script type="text/javascript">
        //Added by Jyoti on 02-10-2020 for Goal Audit - Start
        function openModalShowAudit() {
            debugger;
            $('#my_Grant_Corr_Modal').modal('show');

            //$('#my_Grant_Corr_Modal').show();


        }

        $(".closebtnnew").click(function () {
            alert('test');
        });

        //Added by Jyoti on 02-10-2020 for Goal Audit - End
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
    <script language="Javascript">
        function isNumberKey(evt) {
            var charCode = (evt.which) ? evt.which : evt.keyCode;
            if (charCode > 31 && (charCode < 48 || charCode > 57))
                return false;
            return true;
        }
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
