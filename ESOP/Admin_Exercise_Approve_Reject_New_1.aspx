<%@ Page Title="" Language="C#" MasterPageFile="~/ESOP.Master" AutoEventWireup="true" CodeBehind="Admin_Exercise_Approve_Reject_New_1.aspx.cs" Inherits="ESOP.Admin_Exercise_Approve_Reject_New" EnableEventValidation="false" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ScriptManager ID="script" runat="server"></asp:ScriptManager>

    <style>
        .edit12 {
            padding: 10px;
            background: #2600ff;
            color: white !important;
            border-radius: 4px;
            line-height: 0;
        }

        .aligncenter {
            text-align: center;
            display: block !important;
        }

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
            height: 24px;
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
            margin-left: 61.333333%;
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

        div#table-21_length {
            display: none;
        }

        div#table-22_length {
            display: none;
        }

        .table:not(.table-sm):not(.table-md):not(.dataTable) td, .table:not(.table-sm):not(.table-md):not(.dataTable) th {
            font-size: 14px;
        }

        .buttons {
            padding: 2px;
        }

        .section > :first-child {
            margin-top: 50px;
        }

        a.btn.btn-icon.btn-primary {
            height: 26px;
            width: 41px;
            padding: 0px;
        }

        .theme-white a:hover {
            color: #2600ff;
        }

        a {
            color: #2600ff;
        }

        table.table-bordered.dataTable tbody th {
            color: #3e454c;
            font-size: 14px !important;
        }

        .table th {
            color: #3e454c;
            background: #96a2b433;
            font-size: 14px !important;
            letter-spacing: 0.2px;
            font-weight: 600 !important;
            text-shadow: none;
            border: 0 !important;
        }

        .table:not(.table-sm):not(.table-md):not(.dataTable) td, .table:not(.table-sm):not(.table-md):not(.dataTable) th {
            padding: 0px 2px;
            vertical-align: middle !important;
            font-size: 14px;
            font-weight: 500;
            text-align: center;
            border: 2px solid #fff !important;
        }

        table.simple-tree-table span.tree-icon.tree-closed, table.simple-tree-table span.tree-icon.tree-opened {
            background-color: #2600ff !important;
            text-align: center;
            cursor: pointer;
            border-radius: 31px;
            color: #fff;
            display: inline-block;
            position: relative !important;
            left: 33% !important;
        }

        /*.btn-success, .btn-success.disabled {
			box-shadow: 0 2px 6px #abf2d7;
			background-color: #5a9d44;
			border-color: #5a9d44;
			color: #fff;
			height: 26px;
			line-height: 1.4;
			width: 26px;
		}*/
        .btn-success, .btn-success.disabled {
            box-shadow: 0 2px 6px #abf2d7;
            background-color: #69e7b8;
            border-color: #69e7b8;
            color: #fff !important;
            height: 26px;
            width: 41px;
            padding: 0px;
        }

        .dataTables_scrollBody thead tr th {
            padding-top: 0 !important;
            padding-bottom: 0 !important;
            border: 0 !important;
        }

        div#table-23_length {
            display: none;
        }

        .fa-eye:before {
            margin-left: 0;
            content: "\f06e";
            top: 12px;
            position: relative;
            left: -3px;
        }

        .btn {
            display: inline-block !important;
            height: 27px;
            padding: 0 15px !important;
        }

        .treetablecss th:first-child {
            width: 5px !important;
        }

        table.dataTable img {
            -webkit-box-shadow: 0 5px 15px 0 rgba(105, 103, 103, .5);
            box-shadow: none;
            border: 0px solid #fff;
            border-radius: 10px;
        }

        .hiddencol {
            display: none;
        }
    </style>

    <script src="assets/js/jquery.dataTables-1.10.20.min.js" type="text/javascript"></script>
    <link href="Scripts/jquery.dataTables.min.css" rel="stylesheet" />
    <link href="Scripts/dataTables.bootstrap4.min.css" rel="stylesheet" />

    <script type="text/javascript">
        function checkAll(objRef) {
            var GridView = objRef.parentNode.parentNode.parentNode.parentNode;

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

    <%--<script type="text/javascript">
        function bulkvalidateCheckBoxesapprove() {
            var isValid = false;
            var gridView = document.getElementById('<%= GrvPendingforApproval.ClientID %>');
            for (var i = 1; i < gridView.rows.length; i++) {
                var inputs = gridView.rows[i].getElementsByTagName('input');
                if (inputs != null) {
                    if (inputs[0].type == "checkbox") {
                        if (inputs[0].checked) {
                            isValid = true;
                            //if (confirm("Are you sure want to approve record?")) {
                            //	return true;
                            //} else {
                            //	return false;
                            //}
                            return true;
                        }
                    }
                }
            }
            alert("Please select atleast one checkbox");
            return false;
        }
    </script>--%>

    <%--<script type="text/javascript">
        function bulkvalidateCheckBoxesreject() {
            var isValid = false;
            var gridView = document.getElementById('<%= GrvPendingforApproval.ClientID %>');
            for (var i = 1; i < gridView.rows.length; i++) {
                var inputs = gridView.rows[i].getElementsByTagName('input');
                if (inputs != null) {
                    if (inputs[0].type == "checkbox") {
                        if (inputs[0].checked) {
                            isValid = true;
                            //if (confirm("Are you sure want to reject record?")) {
                            //    return true;
                            //} else {
                            //    return false;
                            //}
                            return true;
                        }
                    }
                }
            }
            alert("Please select atleast one checkbox");
            return false;
        }
    </script>--%>

    <%--  <script type="text/javascript">
		function validateCheckBoxes() {
			var gridView = document.getElementById('<%= GrvPendingforApproval.ClientID %>');
			if (confirm("Are you sure want to reject record?")) {
				return true;
			} else {
				return false;
			}

			return false;
		}
	</script>

	<script type="text/javascript">
		function validateCheckBoxesapprove() {
			var gridView = document.getElementById('<%= GrvPendingforApproval.ClientID %>');
			if (confirm("Are you sure want to approve record?")) {
				return true;
			} else {
				return false;
			}
			return false;
		}
	</script>--%>

    <%--    <script type="text/javascript" src="https://ajax.googleapis.com/ajax/libs/jquery/1.8.3/jquery.min.js"></script>--%>

    <script src="assets/js/jquery-1.8.3.min.js" type="text/javascript"></script>

    <%-- <script type="text/javascript">
		$("[src*=plus]").live("click", function () {
			$(this).closest("tr").after("<tr><td></td><td colspan = '3'>" + $(this).next().html() + "</td></tr>")
			$(this).attr("src", "assets/img/minus.svg");
		});
		$("[src*=minus]").live("click", function () {
			$(this).attr("src", "assets/img/plus.svg");
			$(this).closest("tr").next().remove();
		});
	</script>--%>

    <script type="text/javascript">
        $("[src*=plus]").live("click", function () {
            $(this).closest("tr").after("<tr><td></td><td colspan = '3'>" + $(this).next().html() + "</td></tr>")
            $(this).attr("src", "assets/img/minus.svg");
            var row = $(this).siblings("div").attr('id').split('_');
            $('#hdnchild').val($('#hdnchild').val().replace(row[row.length - 1] + ',', ''));
            $('#hdnchild').val($('#hdnchild').val() + row[row.length - 1] + ',');
        });
        $("[src*=minus]").live("click", function () {
            debugger;
            $(this).attr("src", "assets/img/plus.svg");
            var row = $(this).siblings("div").attr('id').split('_');
            $('#hdnchild').val($('#hdnchild').val().replace(row[row.length - 1] + ',', ''));
            $(this).closest("tr").next().remove();
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

            if ($('#hdnchild').val() != "") {
                var childs = $('#hdnchild').val().split(',');
                if (childs.length > 0) {
                    for (var i = 0; i < childs.length; i++) {
                        $("#ContentPlaceHolder1_grdMain").find('div#ContentPlaceHolder1_grdMain_pnlOrders_' + childs[i]).siblings('img').click();
                    }
                }
            }
        });
    </script>

    <%-- Added by Bhushan on 02-02-2023 for Tax Master CR --%>
    <script>
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
    </script>
    <%-- End --%>

    <!-- Main Content -->
    <div class="main-content">
        <nav aria-label="breadcrumb">
            <ol class="breadcrumb">
                <li class="breadcrumb-item text-left"><a href="admin-dashboard.aspx">Home</a></li>
                <li class="breadcrumb-item text-left"><a href="Admin_exercise_Window.aspx">Exercise</a></li>

                <li class="breadcrumb-item active" aria-current="page">Exercise Approve/ Reject</li>
            </ol>
        </nav>
        <section class="section">
            <div class="row">
                <asp:HiddenField ID="hdnchild" runat="server" ClientIDMode="Static" />
                <div class="col-lg-12 col-md-12 col-12 col-sm-12">
                    <div class="row">
                        <div class="col-lg-12 col-md-6 col-sm-6 col-12" style="margin-top: -40px">
                            <div class="card card-statistic-1">
                                <div class="table-responsive">
                                    <table class="table table-borderless click" style="margin-bottom: 0px;">
                                        <%--  <tbody>
											<tr>
												<td width="360px">
													<h6 style="margin-top: 5px;">Click here to download the documents:</h6>
												</td>
												<%--<td width="150px"><a href="#"><i class="fas fa-arrow-circle-down"></i>Bank Statement</a></td>
												<a class="dropdown-item has-icon text-danger" runat="server" id="lnkBank_Statement" onserverclick="lnkBank_Statement_ServerClick">
													<i class="fas fa-user-cog"></i>Bank Statement
												</a>

												<%--td width="150px"><a href="#"><i class="fas fa-arrow-circle-down"></i>Demo Statement</a></td>
												<a class="dropdown-item has-icon text-danger" runat="server" id="lnkExcercise_Report" onserverclick="lnkExcercise_Report_ServerClick">
													<i class="fas fa-user-cog"></i>Exercise Report 
												</a>
												<td></td>
											</tr>
										</tbody>--%>
                                        <tbody>
                                            <tr>
                                            </tr>
                                        </tbody>
                                    </table>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>

            </div>
            <div class="row">
                <div class="col-12">
                    <div class="card" style="height: 100%;">
                        <div class="card-header">
                            <h4>Admin Approval Summary</h4>

                            <div class="offset-md-7 buttons" style="margin-left: 56.333333%" id="showhidebtn">
                                <asp:Button ID="btn_BulkApprove" runat="server" OnClick="btn_bulkApprove_Click" OnClientClick="bulkvalidateCheckBoxesapprove" CausesValidation="false"
                                    Text="Bulk Approve" CssClass="btn badge badge-success badge-shadow"></asp:Button>
                                <asp:Button ID="btn_BulkReject" runat="server" OnClick="btn_bulkReject_Click" OnClientClick="bulkvalidateCheckBoxesreject" CausesValidation="false"
                                    Text="Bulk Reject" CssClass="btn badge badge-danger badge-shadow"></asp:Button>
                            </div>


                        </div>
                        <div class="card-body">
                            <ul class="offset-md-4 nav nav-pills" id="myTab3" role="tablist">
                                <li class="nav-item">
                                    <a class="nav-link active" id="home-tab3" data-toggle="tab" href="#home3" role="tab" aria-controls="home" aria-selected="true">Pending Approval</a>
                                </li>
                                <li class="nav-item">
                                    <a class="nav-link" id="profile-tab3" data-toggle="tab" href="#profile3" role="tab" aria-controls="profile" aria-selected="false">Approved</a>
                                </li>
                                <li class="nav-item">
                                    <a class="nav-link" id="contact3-tab3" data-toggle="tab" href="#contact3" role="tab" aria-controls="contact" aria-selected="false">Rejected</a>
                                </li>
                                <asp:Label ID="lbl" Text="&nbspExcel Download&nbsp:&nbsp" runat="server" Style="display: none" />
                                <asp:ImageButton ID='btnexcelExport' runat='server' ImageUrl="~/img/excel1.png" Style="margin-left: 20px !important; display: none" OnClick="btnexcelExport_Click" Height="35px" ToolTip="Export To Excel" />
                            </ul>
                            <div class="tab-content" id="myTabContent2">
                                <div class="tab-pane fade active show" id="home3" role="tabpanel" aria-labelledby="home-tab3">
                                    <div class="table-responsive" style="margin-top: 5px;">
                                        <asp:UpdatePanel ID="UpdatePanelMain" runat="server" UpdateMode="Conditional">
                                            <ContentTemplate>
                                                <div id="showmsg" runat="server"></div>
                                                <%-- Commented by Krutika on 02-02-23 --%>
                                                <%--<asp:GridView ID="grdMain" runat="server" AutoGenerateColumns="false" OnPreRender="grdMain_PreRender"
                                                    CssClass="table table-bordered simple-tree-table" DataKeyNames="ECODE" OnRowDataBound="GrvPFADB"
                                                    Style="border-collapse: separate;" EmptyDataText="" EmptyDataRowStyle-CssClass="Empty">
                                                    <Columns>
                                                        <asp:TemplateField HeaderStyle-Width="3%">
                                                            <ItemTemplate>
                                                                <img alt="" style="cursor: pointer" src="assets/img/plus.svg" height="25px" width="25px" />
                                                                <asp:Panel ID="pnlOrders" runat="server" Style="display: none">--%>
                                                <%-- End --%>
                                                <%--<asp:UpdatePanel ID="updpnl1" runat="server" UpdateMode="Conditional">
                                                                        <ContentTemplate>--%>
                                                <asp:GridView ID="GrvPendingforApproval" runat="server" ShowHeaderWhenEmpty="false" AutoGenerateColumns="False" PageSize="25"
                                                    class="table" EmptyDataText="No Records Found" DataKeyNames="EETDID,GRANT_ID,EXERCISE_TRAN_ID,vesting_detail_id,ecode" OnRowCommand="GrvPendingforApproval_RowCommand" OnRowDataBound="GrvPendingforApproval_RowDataBound">
                                                    <Columns>
                                                        <asp:TemplateField>
                                                            <HeaderTemplate>
                                                                <asp:CheckBox ID="checkAll" runat="server" onclick="checkAll(this);" />
                                                            </HeaderTemplate>
                                                            <ItemTemplate>
                                                                <asp:CheckBox runat="server" ID="chk" />
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:BoundField DataField="ecode" HeaderText="Employee Code" HeaderStyle-Width="9%" />
                                                        <asp:BoundField DataField="emp_name" HeaderText="Employee Name" HeaderStyle-Width="10%" />
                                                        <asp:BoundField DataField="GRANT_NAME" HeaderText="ESOP Code" />
                                                        <asp:BoundField DataField="createddate" HeaderText="Exercise Date" DataFormatString="{0:dd-MMM-yyyy}" HeaderStyle-Width="8%" />
                                                        <asp:BoundField DataField="VESTING_DATE" HeaderText="Vesting Date" DataFormatString="{0:dd-MMM-yyyy}" HeaderStyle-Width="9%" />
                                                        <asp:BoundField DataField="grant_price" HeaderText="Grant Price" HeaderStyle-Width="7%" />
                                                        <asp:BoundField DataField="GRANT_FMV_PRICE" HeaderText="Excer FMV Price" HeaderStyle-Width="5%" />
                                                        <%--<asp:BoundField DataField="option_exercise" HeaderText="Options Exercised" HeaderStyle-Width="10%" />--%>
                                                        <asp:BoundField DataField="no_of_exercise" HeaderText="No of Options Exercised" HeaderStyle-Width="10%" />
                                                        <asp:BoundField DataField="NO_OF_VESTING" HeaderText="Total No of Options" HeaderStyle-Width="10%" />
                                                        <asp:BoundField DataField="total_amount" HeaderText="Total Amount Payable" HeaderStyle-Width="10%" />
                                                        <asp:TemplateField HeaderText="Document Type" Visible="false">
                                                            <ItemTemplate>
                                                                <div class="btn-group">
                                                                    <asp:LinkButton ID="btn_Preview" runat="server" CommandName="Preview" CausesValidation="false" CssClass="btn btn-icon btn-success fas fa-eye edit12"></asp:LinkButton>

                                                                    <asp:LinkButton ID="btn_Download" runat="server" CommandName="download" CausesValidation="false"
                                                                        class="btn btn-icon btn-primary fas fa-arrow-down"></asp:LinkButton>
                                                                    &nbsp;
																						<%--<asp:LinkButton ID="btn_View" runat="server" CommandName="View" CausesValidation="false" class="btn btn-icon btn-success fas fa-eye"></asp:LinkButton>--%>
                                                                    <%--<a href="#" class="btn btn-icon btn-primary"><i class="fas fa-arrow-down"></i></a>
																							<a href="#" class="btn btn-icon btn-success"><i class="fas fa-eye"></i></a>--%>
                                                                </div>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Remark">
                                                            <ItemTemplate>
                                                                <div class="remark">
                                                                    <asp:TextBox ID="txt_remark" runat="server" placeholder="Enter Remark" Width="103px" ondrop="return false;" ondrag="return false;"></asp:TextBox>
                                                                </div>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <%-- Added by Bhushan on 02-02-23 --%>
                                                        <asp:TemplateField HeaderText="Perq Tax Amount">
                                                            <ItemTemplate>
                                                                <asp:TextBox ID="txt_PerqAmt" runat="server" placeholder="Enter Perq Tax Amount" Width="103px" OnTextChanged="txt_PerqAmt_TextChanged" onkeypress="return isNumberKey(this,event)" AutoPostBack="true" autocomplete="off"></asp:TextBox>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Total Amount">
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblTotal_Amount" runat="server" />
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <%-- End --%>
                                                        <%-- Added by Krutika on 02-02-23 --%>
                                                        <%--<asp:TemplateField HeaderText="Action">
                                                                                        <ItemTemplate>
                                                                                            <%-- <div class="offset-md-7" style="margin-left: -4px">--%>
                                                        <%--<div class="btn-group">
                                                                                                <asp:Button ID="btn_Approve" runat="server" CommandName="Approve" CausesValidation="true"
                                                                                                    Text="Approve" CssClass="btn badge badge-success badge-shadow"></asp:Button>
                                                                                                <asp:Button ID="btn_Reject" runat="server" CommandName="Reject" CausesValidation="true"
                                                                                                    Text="Reject" CssClass="btn badge badge-danger badge-shadow"></asp:Button>
                                                                                            </div>
                                                                                        </ItemTemplate>
                                                                                    </asp:TemplateField>--%>
                                                        <%-- End --%>
                                                        <%--<asp:BoundField DataField="Repeat" HeaderText="Repeat" HeaderStyle-Width="8%" HeaderStyle-CssClass="hiddencol" ItemStyle-CssClass="hiddencol"/>--%>
                                                    </Columns>
                                                </asp:GridView>
                                                <%--</ContentTemplate>
                                                                        <Triggers>
                                                                            <asp:PostBackTrigger ControlID="GrvPendingforApproval" />
                                                                        </Triggers>
                                                                    </asp:UpdatePanel>--%>
                                                <%-- Commented by Krutika on 02-02-23 --%>
                                                <%--</asp:Panel>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:BoundField DataField="ecode" HeaderText="Employee Code" HeaderStyle-Width="10%" />
                                                        <asp:BoundField DataField="emp_name" HeaderText="Employee Name" HeaderStyle-Width="12%" />
                                                        <asp:BoundField DataField="Total No Of Esop" HeaderText="Total No Of Esop" HeaderStyle-Width="12%" />
                                                    </Columns>
                                                </asp:GridView>--%>
                                                <%-- End --%>
                                            </ContentTemplate>
                                            <Triggers>
                                                <%--<asp:PostBackTrigger ControlID="grdMain" />--%>             <%-- Commented by Krutika on 02-02-23 --%>
                                                <asp:PostBackTrigger ControlID="GrvPendingforApproval" />
                                            </Triggers>
                                        </asp:UpdatePanel>
                                    </div>
                                </div>
                                <div class="tab-pane fade" id="profile3" role="tabpanel" aria-labelledby="profile-tab3">
                                    <%--<asp:ImageButton ID='btnexcelExport' runat='server' ImageUrl="~/img/excel1.png" Style="margin-left: 1089px;" OnClick="btnexcelExport_Click" Height="35px" ToolTip="Export To Excel" />--%>

                                    <div class="table-responsive" style="margin-top: 5px;">
                                        <asp:UpdatePanel ID="updpnl2" runat="server" UpdateMode="Conditional">
                                            <ContentTemplate>
                                                <asp:GridView ID="GrvApproved" runat="server" ShowHeaderWhenEmpty="true" AutoGenerateColumns="False" PageSize="25" OnPreRender="GrvApproved_PreRender"
                                                    class="table" EmptyDataText="" AllowPaging="false" AllowSorting="false" OnPageIndexChanging="GrvApproved_PageIndexChanging" OnSorting="GrvApproved_Sorting">
                                                    <Columns>
                                                        <asp:BoundField DataField="ecode" HeaderText="Employee Code" HeaderStyle-Width="10%" SortExpression="ecode" />
                                                        <asp:BoundField DataField="emp_name" HeaderText="Employee Name" HeaderStyle-Width="12%" SortExpression="emp_name" />
                                                        <%--<asp:BoundField DataField="GRANT_NAME" HeaderText="ESOP Code" />--%>
                                                        <asp:BoundField DataField="GRANT_NAME" HeaderText="ESOP Code" SortExpression="GRANT_NAME" />
                                                        <asp:BoundField DataField="createddate" HeaderText="Exercise Date" DataFormatString="{0:dd-MMM-yyyy}" HeaderStyle-Width="9%" SortExpression="createddate" />
                                                        <asp:BoundField DataField="VESTING_DATE" HeaderText="Vesting Date" DataFormatString="{0:dd-MMM-yyyy}" HeaderStyle-Width="9%" SortExpression="VESTING_DATE" />
                                                        <asp:BoundField DataField="grant_price" HeaderText="Grant Price" HeaderStyle-Width="5%" />
                                                        <asp:BoundField DataField="GRANT_FMV_PRICE" HeaderText="Excer FMV Price" HeaderStyle-Width="5%" />
                                                        <asp:BoundField DataField="option_exercise" HeaderText="Options Exercised" HeaderStyle-Width="5%" />
                                                        <%--<asp:BoundField DataField="No_option_exercise" HeaderText="Options Exercised" HeaderStyle-Width="5%" />--%>
                                                        <asp:BoundField DataField="NO_OF_VESTING" HeaderText="Total No of Options" HeaderStyle-Width="10%" />
                                                        <asp:BoundField DataField="total_amount" HeaderText="Total Amount Payable" HeaderStyle-Width="10%" />
                                                        <asp:BoundField DataField="Remark" HeaderText="Remark" HeaderStyle-Width="8%" />
                                                        <asp:BoundField HeaderText="Pending with" DataField="PENDING_WITH" SortExpression="PENDING_WITH" />
                                                    </Columns>
                                                </asp:GridView>
                                            </ContentTemplate>
                                            <Triggers>
                                                <asp:AsyncPostBackTrigger ControlID="GrvApproved" />
                                            </Triggers>
                                        </asp:UpdatePanel>
                                    </div>
                                </div>
                                <div class="tab-pane fade" id="contact3" role="tabpanel" aria-labelledby="contact3-tab3">
                                    <div class="table-responsive" style="margin-top: 5px;">
                                        <asp:UpdatePanel ID="updpnl3" runat="server" UpdateMode="Conditional">
                                            <ContentTemplate>
                                                <asp:GridView ID="GrvReject" runat="server" ShowHeaderWhenEmpty="true" AutoGenerateColumns="False" PageSize="25"
                                                    class="table dataTable no-footer" EmptyDataText="" OnPreRender="GrvReject_PreRender">
                                                    <Columns>

                                                        <asp:BoundField DataField="ecode" HeaderText="Employee Code" HeaderStyle-Width="10%" />
                                                        <asp:BoundField DataField="emp_name" HeaderText="Employee Name" HeaderStyle-Width="12%" />
                                                        <%--<asp:BoundField DataField="GRANT_NAME" HeaderText="ESOP Code" />--%>
                                                        <asp:BoundField DataField="createddate" HeaderText="Exercise Date" DataFormatString="{0:dd-MMM-yyyy}" HeaderStyle-Width="9%" />
                                                        <asp:BoundField DataField="grant_price" HeaderText="Grant Price" HeaderStyle-Width="5%" />
                                                        <asp:BoundField DataField="GRANT_FMV_PRICE" HeaderText="Excer FMV Price" HeaderStyle-Width="5%" />
                                                        <asp:BoundField DataField="option_exercise" HeaderText="Options Exercised" HeaderStyle-Width="5%" />
                                                        <asp:BoundField DataField="total_amount" HeaderText="Total Amount Payable" HeaderStyle-Width="10%" />
                                                    </Columns>
                                                </asp:GridView>
                                            </ContentTemplate>
                                            <Triggers>
                                                <asp:AsyncPostBackTrigger ControlID="GrvReject" />
                                            </Triggers>
                                        </asp:UpdatePanel>
                                    </div>
                                </div>
                            </div>
                        </div>

                    </div>
                </div>
            </div>
            <div style="display: none" runat="server">
                <asp:GridView ID="gvExercise" runat="server" AutoGenerateColumns="False" PageSize="25" ShowHeaderWhenEmpty="true"
                    class="table table-striped table-hover" DataKeyNames="" EmptyDataText="No Records Found">
                    <Columns>
                        <asp:BoundField DataField="ECODE" HeaderText="EMP Code" HeaderStyle-Width="" />
                        <asp:BoundField DataField="ENAME" HeaderText="EMP Name" HeaderStyle-Width="" />
                        <asp:BoundField DataField="EXERCISE_DATE" HeaderText="Exercise Date" DataFormatString="{0:dd-M-yyyy}" HeaderStyle-Width="" />
                        <asp:BoundField DataField="GRANT_PRICE" HeaderText="Grant Price" HeaderStyle-Width="" />
                        <asp:BoundField DataField="GRANT_FMV_PRICE" HeaderText="Current FMV" HeaderStyle-Width="" />
                        <asp:BoundField DataField="NO_OF_EXERCISE" HeaderText="Options Exercised" HeaderStyle-Width="" />
                        <asp:BoundField DataField="TAX_PER_OPTION" HeaderText="Tax Per Option" HeaderStyle-Width="" />
                        <asp:BoundField DataField="EXERCISE_CONSIDERATION" HeaderText="Exercise Consideration" HeaderStyle-Width="" />
                        <asp:BoundField DataField="FMV_GRANT_OPTION_EXERCISE" HeaderText="(FMV-Grant price)*Options Exercised" HeaderStyle-Width="" />
                        <asp:BoundField DataField="PERQ_TAX_AMOUNT" HeaderText="Perq Tax Amount" HeaderStyle-Width="" />
                        <asp:BoundField DataField="TOTAL_AMOUNT" HeaderText="Total Amount" HeaderStyle-Width="" />
                        <asp:BoundField DataField="BANK_NAME" HeaderText="Bank Name" HeaderStyle-Width="" />
                        <asp:BoundField DataField="ACC_NO" HeaderText="Account Number" HeaderStyle-Width="" />
                        <asp:BoundField DataField="IFSC" HeaderText="IFSC" HeaderStyle-Width="" />
                        <asp:BoundField DataField="CHEQUE_NUMBER" HeaderText="Cheque/DD No." HeaderStyle-Width="" />
                        <asp:BoundField DataField="CHEQUE_DATE" HeaderText="Cheque/DD Date" DataFormatString="{0:dd-M-yyyy}" HeaderStyle-Width="" />
                        <asp:BoundField DataField="AMOUNT_DEPOSITED" HeaderText="Total Amount Deposited" HeaderStyle-Width="" />
                        <asp:BoundField DataField="FUNDING_AMOUNT" HeaderText="Funding Amount" HeaderStyle-Width="" />
                        <asp:BoundField DataField="AMOUNT_DEPOSITED" HeaderText="Total Deposited" HeaderStyle-Width="" />
                        <asp:BoundField DataField="DPID" HeaderText="DP ID" HeaderStyle-Width="" />
                        <asp:BoundField DataField="CLIENT_ID" HeaderText="Client ID" HeaderStyle-Width="" />
                        <asp:BoundField DataField="MEMBER_TYPE" HeaderText="Member Type" HeaderStyle-Width="" />
                    </Columns>
                </asp:GridView>
            </div>
        </section>
    </div>
    <div class="modal fade bd-example-modal-lg1" id="myModal1" tabindex="-1" role="dialog" aria-labelledby="myLargeModalLabel" style="display: none;" aria-hidden="true">
        <div class="modal-dialog modal-lg" style="max-width: 900px;">
            <asp:UpdatePanel runat="server">
                <ContentTemplate>
                    <div class="modal-content">
                        <div class="modal-header">
                            <h5 class="modal-title" id="myLargeModalLabel">Preview </h5>
                        </div>
                        <div class="modal-body" style="padding-left: 15px; padding-right: 15px;">
                            <div class="row popRow aligncenter" runat="server" id="DivImage" style="display: none">
                                <img id="FreshChequeImage1" runat="server" height="200" width="600" />
                            </div>
                            <div class="row popRow aligncenter" runat="server" id="DivPDF" style="display: none">
                                <embed runat="server" id="embed1" width="100%" height="500" alt="pdf" pluginspage="http://www.adobe.com/products/acrobat/readstep2.html" />
                            </div>
                        </div>
                        <div class="modal-footer bg-whitesmoke br">
                            <div class="btn-group" role="group" aria-label="Basic example">
                                <a href="#" class="btn btn-info btn-lg all CloseBtnNew" data-dismiss="modal">Close</a>
                            </div>
                        </div>

                    </div>
                </ContentTemplate>
            </asp:UpdatePanel>
        </div>
    </div>
    <!-- General JS Scripts -->
    <script src="Scripts/bootstrap.min.js"></script>
    <script src="assets/js/app.min.js"></script>
    <script src="assets/js/scripts.js"></script>
    <script type="text/javascript">
        $(function () {
            $("#profile-tab3").on("click", function () {

                $("#showhidebtn").css({ 'display': 'none' });
                $("[id*=btnexcelExport]").attr('style', 'display:block');
                $("[id*=lbl]").attr('style', 'display:block;font-weight:600');
                //alert('hello');

            });

            $("#contact3-tab3").on("click", function () {

                $("#showhidebtn").css({ 'display': 'none' });
                $("[id*=btnexcelExport]").attr('style', 'display:none');
                $("[id*=lbl]").attr('style', 'display:none');

            });

            $("#home-tab3").on("click", function () {

                $("#showhidebtn").css({ 'display': 'block' });
                $("[id*=btnexcelExport]").attr('style', 'display:none');
                $("[id*=lbl]").attr('style', 'display:none');

            });


        });
    </script>
    <script type="text/javascript">
        //$('#ContentPlaceHolder1_grdpendingapproval').clear().draw();

        //var prm = Sys.WebForms.PageRequestManager.getInstance();

        //prm.add_endRequest(function (sender, e) {
        //    debugger;
        //    $('#ContentPlaceHolder1_grdMain').dataTable({
        //        lengthMenu: [[-1, 5, 10], ["All", 5, 10]],
        //        order: [],
        //        columnDefs: [{ orderable: false, targets: [0] }],
        //        bRetrieve: true

        //    });

        //});


        var prm = Sys.WebForms.PageRequestManager.getInstance();

        prm.add_endRequest(function (sender, e) {
            debugger;
            $('#ContentPlaceHolder1_grdMain').dataTable({
                lengthMenu: [[-1, 5, 10], ["All", 5, 10]],
                order: [],
                columnDefs: [{ orderable: false, targets: [] }],
                bRetrieve: true

            });

        });


        $(function () {
            $.noConflict();
            debugger;
            $('#ContentPlaceHolder1_grdMain').DataTable({

                bLengthChange: true,
                lengthMenu: [[-1, 5, 10], ["All", 5, 10]],
                bFilter: true,
                //'columnDefs': [{
                //    'targets': [0, 7, 8],
                //    'orderable': false,
                //}],
                order: [],
                columnDefs: [{ orderable: false, targets: [0] }],
                bPaginate: true,

            });
        });
    </script>
    <script type="text/javascript">
        //$('#ContentPlaceHolder1_grdpendingapproval').clear().draw();

        var prm = Sys.WebForms.PageRequestManager.getInstance();

        prm.add_endRequest(function (sender, e) {
            debugger;
            $('#ContentPlaceHolder1_GrvApproved').dataTable({
                lengthMenu: [[-1, 5, 10], ["All", 5, 10]],
                order: [],
                columnDefs: [{ orderable: false, targets: [] }],
                bRetrieve: true

            });

        });


        $(function () {

            debugger;
            $('#ContentPlaceHolder1_GrvApproved').DataTable({

                bLengthChange: true,
                lengthMenu: [[-1, 5, 10], ["All", 5, 10]],
                bFilter: true,
                //'columnDefs': [{
                //    'targets': [0, 7, 8],
                //    'orderable': false,
                //}],
                order: [],
                columnDefs: [{ orderable: false, targets: [] }],
                bPaginate: true,

            });
        });
    </script>

    <script type="text/javascript">
        //$('#ContentPlaceHolder1_grdpendingapproval').clear().draw();

        var prm = Sys.WebForms.PageRequestManager.getInstance();

        prm.add_endRequest(function (sender, e) {
            debugger;
            $('#ContentPlaceHolder1_GrvReject').dataTable({
                lengthMenu: [[-1, 5, 10], ["All", 5, 10]],
                order: [],
                columnDefs: [{ orderable: false, targets: [] }],
                bRetrieve: true

            });

        });


        $(function () {

            debugger;
            $('#ContentPlaceHolder1_GrvReject').DataTable({

                bLengthChange: true,
                lengthMenu: [[-1, 5, 10], ["All", 5, 10]],
                bFilter: true,
                //'columnDefs': [{
                //    'targets': [0, 7, 8],
                //    'orderable': false,
                //}],
                order: [],
                columnDefs: [{ orderable: false, targets: [] }],
                bPaginate: true,

            });
        });
    </script>
    <script type="text/javascript">
        function openModal() {
            $('#myModal1').modal('show');
        }

        $('.CloseBtnNew').click(function () {


            $("#myModal1").removeClass("show");
            $(".modal-backdrop").remove();
            $("#myModal1").hide();
            $("body").removeClass("modal-open");
            // $("#myModal1").modal("hide");
        });
    </script>
</asp:Content>

