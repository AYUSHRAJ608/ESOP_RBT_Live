<%@ Page Title="" Language="C#" MasterPageFile="~/ESOP.Master" AutoEventWireup="true" CodeBehind="Sale.aspx.cs" EnableEventValidation="false" Inherits="ESOP.Sale" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
	<style>
		 .DrpWidth {
			width: 175px !important;
		}
		a.btn.btn-icon.btn-primary.form-control {
			/* border-radius: 22px; */
			width: 90% !important;
			color: #fff !important;
			background-color: #2600ff !important;
			padding-top: 6px !important;
			border-radius: 0.25rem;
		}

		.row {
			/*margin-left: 44px !important;*/
		}

		.card {
			width: 98% !important;
		}

		li.nav-item {
			width: auto;
			text-align: center;
		}

		.nav-tabs .nav-link.active {
			background-color: #2600ff !important;
			border-color: #dee2e6 #dee2e6 #fff;
			color: white !important;
		}

		.nav-tabs .nav-item .nav-link {
			background: aliceblue;
		}

		.theme-white .nav-tabs .nav-item .nav-link {
			color: #2600ff;
		}

		.table th {
			padding: .4rem;
			color: #000 !important;
			font-weight: 600 !important;
			background: #d1d4d7;
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

		.table {
			border: none !important;
		}

		table.dataTable, table.dataTable th, table.dataTable td {
			/*box-sizing: content-box;*/
			border: 1px solid #fff !important;
		}

		.GridPager a, .GridPager span {
			display: block;
			height: 25px;
			width: 33px;
			font-weight: bold;
			text-align: center;
			text-decoration: none;
		}

		.modal.show .modal-content {
			width: 85%;
		}

		 .theme-white a:hover {
			text-decoration: underline !important;
		}

	</style>

	<script src="assets/js/jquery-1.8.3.min.js"></script>

	<link href="assets/css/jquery-ui-1.12.1.css" rel="stylesheet" />
	<script src="assets/js/jquery-1.12.4.js" type="text/javascript"></script>
	<script src="assets/js/jquery-ui-1.12.1.js" type="text/javascript"></script>
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
		$(function () {
			$.noConflict();
			var from = $("#ContentPlaceHolder1_txtstartdate")
		  .datepicker({

		      minDate: 0,
			  dateFormat: "dd-mm-yy",
			  changeMonth: true,
			  changeYear: true,
			  yearRange: "-50:+50",
		  })
		  .on("change", function () {
			  to.datepicker("option", "minDate", getDate(this));
		  }),
		to = $("#ContentPlaceHolder1_txtenddate").datepicker({
			dateFormat: "dd-mm-yy",
			changeMonth: true,
			changeYear: true,
			yearRange: "-50:+50",
		})
		.on("change", function () {
			from.datepicker("option", "maxDate", getDate(this));
		});

			function getDate(element) {
				var date;
				var dateFormat = "dd-mm-yy";
				try {
					date = $.datepicker.parseDate(dateFormat, element.value);
				} catch (error) {
					date = null;
				}

				return date;
			}
		});

		$(function () {
			Sys.WebForms.PageRequestManager.getInstance().add_endRequest(bindPicker);
			bindPicker();
		});

		function bindPicker() {

			var from = $("input[type=text][id*=txtstartdate]").datepicker({

			    minDate: 0,
				dateFormat: "dd-mm-yy",
				changeMonth: true,
				changeYear: true,
				yearRange: "-50:+50",
			})
		  .on("change", function () {
			  to.datepicker("option", "minDate", getDate(this));
		  }),
		to = $("input[type=text][id*=txtenddate]").datepicker({
			dateFormat: "dd-mm-yy",
			changeMonth: true,
			changeYear: true,
			yearRange: "-50:+50",
		})
		.on("change", function () {
			from.datepicker("option", "maxDate", getDate(this));
		});

			function getDate(element) {
				var date;
				var dateFormat = "dd-mm-yy";
				try {
					date = $.datepicker.parseDate(dateFormat, element.value);
				} catch (error) {
					date = null;
				}

				return date;
			}
		}
		$(function () {
			// $.noConflict();
			var from = $("#ContentPlaceHolder1_txtvaldate")
		  .datepicker({

			  dateFormat: "dd-mm-yy",
			  changeMonth: true,
			  changeYear: true,
			  yearRange: "-50:+50",
		  })
		  .on("change", function () {
			  to.datepicker("option", "minDate", getDate(this));
		  }),
		to = $("#ContentPlaceHolder1_txtvalidupto").datepicker({
			dateFormat: "dd-mm-yy",
			changeMonth: true,
			changeYear: true,
			yearRange: "-50:+50",
		})
		.on("change", function () {
			from.datepicker("option", "maxDate", getDate(this));
		});

			function getDate(element) {
				var date;
				var dateFormat = "dd-mm-yy";
				try {
					date = $.datepicker.parseDate(dateFormat, element.value);
				} catch (error) {
					date = null;
				}

				return date;
			}
		});
	</script>


	<script src="assets/js/jquery.dataTables-1.10.20.min.js" type="text/javascript"></script>
	<link href="Scripts/jquery.dataTables.min.css" rel="stylesheet" />
	<link href="Scripts/dataTables.bootstrap4.min.css" rel="stylesheet" />


	<script type="text/javascript">

		var prm = Sys.WebForms.PageRequestManager.getInstance();

		prm.add_endRequest(function (sender, e) {

			$('#ContentPlaceHolder1_grdsell').dataTable({
				lengthMenu: [[-1, 5, 10], ["All", 5, 10]],
				columnDefs: [{ orderable: false, targets: [] }],
				bRetrieve: true,


			});

		});
		$(function () {

			debugger;
			$("#ContentPlaceHolder1_grdsell").DataTable({
				bLengthChange: true,
				lengthMenu: [[-1, 5, 10], ["All", 5, 10]],
				bFilter: true,
				//'columnDefs': [{
				//    'targets': [5],
				//    'orderable': false,
				//}],
				order: [],
				columnDefs: [{ orderable: false, targets: [] }],
				bPaginate: true,
				bSort: true,
			});
		});
	</script>

	<script type="text/javascript">

		var prm = Sys.WebForms.PageRequestManager.getInstance();

		prm.add_endRequest(function (sender, e) {

			$('#ContentPlaceHolder1_grdempsell').dataTable({
				lengthMenu: [[-1, 5, 10], ["All", 5, 10]],
				columnDefs: [{ orderable: false, targets: [] }],
				bRetrieve: true,


			});

		});
		$(function () {

			$("#ContentPlaceHolder1_grdempsell").DataTable({
				bLengthChange: true,
				lengthMenu: [[-1, 5, 10], ["All", 5, 10]],
				bFilter: true,
				//'columnDefs': [{
				//    'targets': [5],
				//    'orderable': false,
				//}],
				order: [],
				columnDefs: [{ orderable: false, targets: [] }],
				bPaginate: true,
				bSort: true,
			});
		});
	</script>
	<script>


		function openModal() {

			$('#sellempdata').modal({ show: true });
		}

	</script>

	<asp:ScriptManager ID="script" runat="server"></asp:ScriptManager>
	<div class="main-content">
		<nav aria-label="breadcrumb" >
			<ol class="breadcrumb" >
				<li class="breadcrumb-item"><a href="admin-dashboard.aspx">Home</a></li>
				<li class="breadcrumb-item"><a href="Admin_SellWindow.aspx">Sale</a></li>
				<li class="breadcrumb-item active" aria-current="page">Sale Window</li>
			</ol>
		</nav>

		<section class="section">

			<div class="row">
				<div class="col-lg-12 col-md-12 col-12 col-sm-12">
					<div class="card" style="height: auto;">
						<div class="card-header">
							<h4>Setup Sale Window</h4>
						</div>
						<div class="card-body">

							<div class="tab-content" id="myTabContent2" style="margin-left: 10%;">
								<div class="tab-pane fade show active" id="home3" role="tabpanel" aria-labelledby="home-tab3">

									<div class="row" style="margin-top: 15px;">
										<div class="tab-content mt-4" id="myTabContent">
											<div class="tab-pane fade active show" id="home" role="tabpanel" aria-labelledby="home-tab">
												<div class="row  offset-md-1">
													<div class="col-lg-4 col-md-12 col-sm-12">
														<div class="form-group">
															<label>Update Sale window</label>
															<asp:UpdatePanel ID="UpSale" runat="server">
																<ContentTemplate> 
																	<asp:DropDownList ID="ddlSaleDate" runat="server" CssClass="form-control DrpWidth"  ToolTip="To modify sale window,please select sale dates."
																		AutoPostBack="true" OnSelectedIndexChanged="ddlSaleDate_SelectedIndexChanged">
																	</asp:DropDownList>
																</ContentTemplate>
															</asp:UpdatePanel>
														</div>
													</div>
												</div>
												<div class="row offset-md-1">

													<div class="col-lg-3 col-md-12 col-sm-12 all">
														<asp:UpdatePanel ID="up2" runat="server">
															<ContentTemplate>
																<div class="form-group">
																	<label>Sale Start Date <span style="color:red">*</span></label>
																	<asp:TextBox ID="txtstartdate" type="text" runat="server" Placeholder="dd-mm-yyyy" class="form-control" AutoComplete="off" AutoPostBack="true" OnTextChanged="txtstartdate_TextChanged"></asp:TextBox>
															</ContentTemplate>
														</asp:UpdatePanel>
													</div>
												</div>
												<div class="col-lg-3 col-md-12 col-sm-12 all">
													<asp:UpdatePanel ID="UpdatePanel1" runat="server">
														<ContentTemplate>
															<div class="form-group">
																<label>Sale End Date <span style="color:red">*</span> </label>
																<asp:TextBox ID="txtenddate" type="text" runat="server" Placeholder="dd-mm-yyyy" class="form-control" AutoComplete="off" AutoPostBack="true" OnTextChanged="txtenddate_TextChanged1"></asp:TextBox>
															</div>
														</ContentTemplate>
													</asp:UpdatePanel>
												</div>

												<div class="col-lg-3 col-md-12 col-sm-12">
													<div class="form-group">
														<label>Select Grant Price <span style="color:red">*</span></label>
														<label class="or">OR</label>
														<asp:UpdatePanel ID="UpdatePanel2" runat="server">
															<ContentTemplate>
																<div class="input-group mb-3">
																	<asp:DropDownList ID="ddlFMV" runat="server" CssClass="form-control DrpWidth" AutoPostBack="true">
																	</asp:DropDownList>
																</div>
															</ContentTemplate>
														</asp:UpdatePanel>
													</div>
												</div>
												<div class="col-lg-2 col-md-12 col-sm-12" style="margin-left: 10px;">
													<div class="form-group">
														<label></label>
														<a href="#" class="btn btn-info btn-lg" style="margin-top:5px; background-color: blue;" data-toggle="modal" data-target="#ModalCreateFMV">Create FMV</a>
													</div>

												</div>
												<div class="col-lg-3 offset-md-5 mt-3">
													<asp:Button ID="btnSubmit" runat="server" Text="Submit" Style="margin-left: -40% !important;" OnClientClick="return validate();return false;" CssClass="btn btn-info btn-lg" OnClick="btnSubmit_Click" />
												</div>
											</div>
											<div style="color:red"; align="right">
									All (*) marked fields are mandatory.
								</div>
										</div>
										<div class="tab-pane fade" id="profile" role="tabpanel" aria-labelledby="profile-tab">

											<div class="row" style="margin-left: 330px;">

												<div class="col-lg-6 col-md-12 col-sm-12">
													<div class="form-group">
														<label>Upload File</label>
														<input type="file" class="form-control">
													</div>
												</div>
												<div class="col-lg-6 col-md-12 col-sm-12">
													<div class="form-group">
														<div class="section-title">Upload Format</div>
														<div class="form-group">
															<div class="custom-control custom-radio custom-control-inline">
																<input type="radio" id="customRadioInline4" name="customRadioInline3" class="custom-control-input" value="bulk" checked="">
																<label class="custom-control-label" for="customRadioInline4">PDF  </label>
															</div>
															<div class="custom-control custom-radio custom-control-inline">
																<input type="radio" id="customRadioInline3" name="customRadioInline3" class="custom-control-input" value="single">
																<label class="custom-control-label" for="customRadioInline3">Excel</label>
															</div>
														</div>
													</div>
												</div>
											</div>
											<div class="row">
												<div class="col-lg-3 offset-md-5 mt-4 mb-4">
													<a href="#" class="btn btn-info btn-lg" id="btnimport">Submit</a>
												</div>
											</div>
										</div>
									</div>
								</div>
							</div>
						</div>

						<div id="showmsg" runat="server"></div>
					</div>
				</div>
			</div>


			<div class="col-lg-12 col-md-12 col-12 col-sm-12" id="tablediv1" runat="server">
				<div class="card" style="height: auto;">
					<div class="card-header">
						<h4>Sale Detail</h4>
					</div>
					<div class="card-body">
						<div class="table-responsive">
							<table class="table table-bordered">
								<%--  <asp:UpdatePanel ID="upd" runat="server">
									<ContentTemplate>--%>
								<asp:GridView ID="grdsell" runat="server" AutoGenerateColumns="False" ShowHeaderWhenEmpty="false"
									DataKeyNames="SALE_ID" EmptyDataText="" OnPreRender="grdsell_PreRender" OnRowDataBound="grdsell_RowDataBound"
									class="table" OnSelectedIndexChanged="grdsell_SelectedIndexChanged">
									<%-- <RowStyle HorizontalAlign="Left" />--%>
									<Columns>

										<asp:TemplateField HeaderText="Sale Start Date">
											<ItemTemplate>
												 <asp:HyperLink ID="lblstrtdate" runat="server" Text='<%#Eval("START_DATE") %>' ToolTip="Click to View Sale records" ForeColor="Blue"> </asp:HyperLink>
											  <%--  <asp:Label ID="lblstrtdate" runat="server" Text='<%#Eval("START_DATE") %>' ToolTip="Click to View Sale records" ForeColor="Blue" />--%>
											</ItemTemplate>
										</asp:TemplateField>

										<asp:TemplateField HeaderText="Sale End Date">
											<ItemTemplate>
												 <asp:HyperLink ID="lbltodate" runat="server" Text='<%#Eval("END_DATE") %>' ToolTip="Click to View Sale records" ForeColor="Blue"> </asp:HyperLink>
											<%--    <asp:Label ID="lbltodate" runat="server" Text='<%#Eval("END_DATE") %>' ToolTip="Click to View Sale records" ForeColor="Blue"/>--%>
											</ItemTemplate>
										</asp:TemplateField>

										<asp:TemplateField HeaderText="Fmv Price">
											<ItemTemplate>
												 <asp:HyperLink ID="lblfmvprice" runat="server" Text='<%#Eval("FMV_PRICE") %>' ToolTip="Click to View Sale records" ForeColor="Blue"> </asp:HyperLink>
											  <%--  <asp:Label ID="lblfmvprice" runat="server" Text='<%#Eval("FMV_PRICE") %>' ToolTip="Click to View Sale records" ForeColor="Blue"/>--%>
											</ItemTemplate>
										</asp:TemplateField>
									</Columns>
								</asp:GridView>

								<%-- </ContentTemplate>
									<Triggers>

										<asp:AsyncPostBackTrigger ControlID="grdsell" />
									</Triggers>
								</asp:UpdatePanel>--%>
							</table>
						</div>
					</div>
				</div>
			</div>
		</section>
		<div class="modal fade bd-example-modal-lg" tabindex="-1" id="sellempdata" role="dialog" aria-labelledby="myLargeModalLabel" aria-hidden="true">
			<div class="modal-dialog modal-lg">
				<div class="modal-content">
					<div class="modal-header">
						<h5 class="modal-title" id="myLargeModalLabel2">Employee Details</h5>
					</div>



					<div class="card-body">
						<div class="table-responsive">
							<asp:UpdatePanel ID="UpdatePanel4" runat="server">
								<ContentTemplate>

									<asp:GridView ID="grdempsell" runat="server" AutoGenerateColumns="False" ShowHeaderWhenEmpty="false" OnPageIndexChanging="grdempsell_PageIndexChanging" OnPreRender="grdempsell_PreRender"
										class="table" EmptyDataText="" DataKeyNames="SALE_ID" AllowPaging="false" PageSize="10" OnSorting="grdempsell_Sorting" AllowSorting="false">
										<%-- <RowStyle HorizontalAlign="Left" />--%>
										<Columns>
											<asp:TemplateField HeaderText="Employee Code" SortExpression="ECODE">


												<ItemTemplate>
													<asp:Label ID="lblempcode" runat="server" Text='<%#Eval("ECODE") %>' />
												</ItemTemplate>

											</asp:TemplateField>
											<asp:TemplateField HeaderText="Employee Name" SortExpression="EMP_NAME">


												<ItemTemplate>
													<asp:Label ID="lblempname" runat="server" Text='<%#Eval("EMP_NAME") %>' />
												</ItemTemplate>

											</asp:TemplateField>


											<asp:TemplateField HeaderText="Grant name" SortExpression="grant_name">


												<ItemTemplate>
													<asp:Label ID="lblgrntname" runat="server" Text='<%#Eval("grant_name") %>' />
												</ItemTemplate>

											</asp:TemplateField>


											<asp:TemplateField HeaderText="Vesting Name" SortExpression="vcyclename">
												<ItemTemplate>
													<asp:Label ID="lblvcyclename" runat="server" Text='<%#Eval("vcyclename") %>' />
												</ItemTemplate>
											</asp:TemplateField>

											<asp:TemplateField HeaderText="FMV Price" SortExpression="fmv_price">
												<ItemTemplate>
													<asp:Label ID="lblfmv_price" runat="server" Text='<%#Eval("fmv_price") %>' />
												</ItemTemplate>
											</asp:TemplateField>


											<asp:TemplateField HeaderText="Sale Window Date" SortExpression="sale_window_date">
												<ItemTemplate>
													<asp:Label ID="lblvestingdate" runat="server" Text='<%#Eval("sale_window_date") %>' />
												</ItemTemplate>
											</asp:TemplateField>
										</Columns>
										<PagerStyle HorizontalAlign="Right" CssClass="GridPager" />
									</asp:GridView>
								</ContentTemplate>
							</asp:UpdatePanel>
						</div>

					</div>
					<style>
						.btn.btn-info.all.CloseBtnNew:hover {
							color: #498A07 !important;
							background: #ffff !important;
							border: 2px solid #498A07 !important;
						}
					</style>
					<div class="modal-footer bg-whitesmoke br">
						<div class="btn-group" role="group" aria-label="Basic example">
							<%--   <asp:Button ID="btn" runat="server" class="btn btn-info btn-lg all" data-dismiss="modal" Text="Close"/>--%>
							<%--<a href="#" class="btn btn-info btn-lg all CloseBtnNew" data-dismiss="modal">Close</a>--%>
							<button id="btn1" class="btn btn-info btn-lg all CloseBtnNew">Close</button>
						</div>
					</div>
				</div>
			</div>


		</div>
	</div>

	<div class="modal fade bd-example-modal-lg" tabindex="-1" id="ModalCreateFMV" role="dialog" aria-labelledby="myLargeModalLabel" aria-hidden="true" style="display: none;">
		<div class="modal-dialog modal-lg">
			<div class="modal-content">
				<div class="modal-header">
					<h5 class="modal-title" id="myLargeModalLabel">Create FMV</h5>
					<%-- <button type="button" class="close" data-dismiss="modal" aria-label="Close">
						<span aria-hidden="true">×</span>
					</button>--%>
				</div>
				<div class="modal-body">
					<div class="row">
						<!--Sweet alert-->
						<div class="col-lg-6 col-md-12 col-sm-12">
							<div class="form-group">
								<label>Valuation Date <span style="color: red">*</span></label>
								<asp:TextBox ID="txtvaldate" type="text" placeholder="dd-mm-yyyy" runat="server" class="form-control" AutoComplete="off"></asp:TextBox>
							</div>
						</div>

						<div class="col-lg-6 col-md-12 col-sm-12">
							<div class="form-group">
								<label>Valid Upto <span style="color: red">*</span></label>
								<asp:TextBox ID="txtvalidupto" type="text" placeholder="dd-mm-yyyy" runat="server" class="form-control" AutoComplete="off"></asp:TextBox>
							</div>
						</div>
						<div class="col-lg-6 col-md-12 col-sm-12">
							<div class="form-group">
								<label>FMV <span style="color: red">*</span></label>
								<asp:TextBox ID="txtfmvprice" runat="server" CssClass="form-control" MaxLength="10" onkeypress="return isNumberKey(this,event)" pattern="^\d*(\.\d{0,2})?$"></asp:TextBox>
							</div>
						</div>

                        <div class="col-lg-6 col-md-12 col-sm-12">
                            <div class="form-group">
                                <label>Valued By </label>
                                <%--<span style="color: red">*</span>    Commented by Krutika on 17-06-22--%>
                                <div class="input-group mb-3">
                                    <asp:DropDownList ID="ddlvaluedby" runat="server" CssClass="form-control" Style="width: 100% !important;">
                                    </asp:DropDownList>
                                </div>
                            </div>
                        </div>

                        <div class="col-lg-6 col-md-12 col-sm-12">
                            <div class="form-group">
                                <label>Upload File </label>
                                <%--<span style="color: red">*</span>    Commented by Krutika on 17-06-22--%>
                                <asp:FileUpload ID="FileUpload1" runat="server" class="form-control" />
                                <asp:Label ID="lblFileType" runat="server" Text="(Only .xls, .xlsx files are allowed.)" ForeColor="Green" Font-Bold="true" Font-Size="14px"></asp:Label>
                            </div>
                        </div>
                    </div>
                </div>
                <div class="modal-footer bg-whitesmoke br">
                    <div class="btn-group" role="group" aria-label="Basic example">
                        <asp:Button ID="btncreatefmv" runat="server" Text="Create Fmv" OnClick="btncreatefmv_Click" OnClientClick="return ReqValidation();"
                            class="btn btn-info btn-lg all" />
                        <a href="#" class="btn btn-info btn-lg all CloseBtnNew" data-dismiss="modal">Close</a>
                    </div>
                </div>
            </div>


		</div>
	</div>




	<!-- General JS Scripts -->
	<script src="Scripts/bootstrap.min.js"></script>
	<script src="assets/js/app.min.js"></script>

	<script src="assets/js/scripts.js"></script>


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


	<%--   <script>
		$(document).ready(function () {

			$('.singledatadiv').hide();
			$("input[name='customRadioInline3']").change(function () {

				var radioValue = $("input[name='customRadioInline3']:checked").val();
				console.log(radioValue);
				if (radioValue == "single") {
					$('.all').show()
					$('.singledatadiv').slideDown();
					$('.multidatadiv').hide();
				}
				else {
					$('.all').show()
					$('.multidatadiv').slideDown();
					$('.singledatadiv').hide();
				}
			});

			$('#tablediv').hide();
			$('#btnimport').click(function () {
				$('#tablediv').slideToggle();
				$('html, body').animate({
					scrollTop: $("#tablediv").offset().top
				}, 2000);

			});

		})
	</script>--%>

   <%-- <script type="text/javascript">
		$('#basic').simpleTreeTable({
			collapsed: true,

			expander: $('#expander'),
			collapser: $('#collapser')
		});

		$(document).ready(function () {
			$('#collapser').click();
			$('.simple-tree-table tr th:nth-child(4), .simple-tree-table tr th:nth-child(6), .simple-tree-table tr th:nth-child(8), .simple-tree-table tr th:nth-child(9), .simple-tree-table tr td:nth-child(4), .simple-tree-table tr td:nth-child(6), .simple-tree-table tr td:nth-child(8), .simple-tree-table tr td:nth-child(9)').addClass('toggleDisplay')
		})


	</script>--%>
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
		function ReqValidation() {
			//debugger;
			var Fileup = document.getElementById('<%=FileUpload1.ClientID%>').value;
			<%--  document.getElementById('<%=hiddenControl.ClientID%>').value = Fileup;--%>
			var validationdate = document.getElementById('<%=txtvaldate.ClientID%>').value;
			var validupto = document.getElementById('<%=txtvalidupto.ClientID%>').value;
			var FMVPrice = document.getElementById('<%=txtfmvprice.ClientID%>').value;
			var ValueBy = document.getElementById('<%=ddlvaluedby.ClientID%>').value;
		   <%-- //var uploadfile = document.getElementById('<%=uploadfile.ClientID%>').value;--%>
			if (validationdate.trim() == "") {
				alert("Select Valuation Date!");
				document.getElementById('<%=txtvaldate.ClientID%>').focus();
				return false;
			}
			if (validupto.trim() == "") {
				alert("Select Valid Upto Date!");
				document.getElementById('<%=txtvalidupto.ClientID%>').focus();
				return false;
			}
			if (FMVPrice.trim() == "") {
				alert("Select FMV Price!!");
				document.getElementById('<%=txtfmvprice.ClientID%>').focus();
				return false;
			}

			if (FMVPrice.charAt(0) == 0) {
				alert("FMV Price cannot be" + " " + FMVPrice + "");
				document.getElementById('<%=txtfmvprice.ClientID%>').focus();
				document.getElementById('<%=txtfmvprice.ClientID%>').value = "";
				return false;
			}

			//added by Pallavi on 03/03/2022
			//Commented by Krutika on 17-06-22
			<%--if (ValueBy.trim() == "0") {
				alert("Select Valued By!!");
				document.getElementById('<%=ddlvaluedby.ClientID%>').focus();
				return false;
			}--%>
			//END

            if (FileUpload1.trim() != "" || FileUpload1.trim() == "") {
                var ext = FileUpload1.substr(FileUpload1.lastIndexOf('.') + 1).toLowerCase();
                if (ext != "") {
                    if (ext == "xlsx" || ext == "xlx") {
                        return true;
                    }
                    else {
                        alert("File should be in .xls, .xlsx format.");
                        document.getElementById('<%=FileUpload1.ClientID%>').value = "";
                        document.getElementById('<%=FileUpload1.ClientID%>').focus();
                        return false;

                    }
                }
                else {
                    return true;
                }
            }
            //if (uploadfile.trim() == "") {
            //    alert("Please Select File to upload!!");
            //    return false;
            //}
        }
    </script>

	<script language="javascript" type="text/javascript">
		function validate() {

			if (document.getElementById("<%=txtstartdate.ClientID%>").value == "") {
				alert("Please Enter Sale Start Date");
				document.getElementById("<%=txtstartdate.ClientID %>").focus();
				return false;
			}
			if (document.getElementById("<%=txtenddate.ClientID%>").value == "") {
				alert("Please Enter Sale End Date");
				document.getElementById("<%=txtenddate.ClientID %>").focus();
				return false;
			}
			if (document.getElementById("<%=ddlFMV.ClientID%>").value == 0) {
				alert("Please Select FMV price");
				document.getElementById("<%=ddlFMV.ClientID%>").focus();
				return false;
			}

		}

		$('#tablediv').hide();
		$('#btnSubmit').click(function () {
			$('#tablediv').slideToggle();
			$('html, body').animate({
				scrollTop: $("#tablediv").offset().top
			}, 2000);

		});
	</script>

</asp:Content>
