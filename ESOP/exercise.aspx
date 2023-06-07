<%@ Page Title="" Language="C#" MasterPageFile="~/ESOP.Master" AutoEventWireup="true" CodeBehind="exercise.aspx.cs" EnableEventValidation="false" Inherits="ESOP.exercise" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
	<script type="text/javascript">

		function FixTabs(tab) {
			//alert('in fix tab _ 11');
			var tabIndex = document.getElementById("hdnTab").value;
			//alert(tab);
			var t1 = document.getElementById("home");
			var t2 = document.getElementById("profile");
			var t3 = document.getElementById("home-tab");
			var t4 = document.getElementById("profile-tab");

			t1.setAttribute('class', '');
			t2.setAttribute('class', '');
			if (tabIndex == "1") {
				t1.setAttribute('class', 'tab-pane fade show active');
				t2.setAttribute('class', 'tab-pane');

			}
			else if (tabIndex == "2") {
				t1.setAttribute('class', 'tab-pane fade');
				t4.setAttribute('class', 'nav-link active');
				t3.setAttribute('class', 'nav-link');
				//alert('in fix tab _ END_1');
				document.getElementById("<%=tablediv1.ClientID%>").style.display = "none";
				document.getElementById("<%=tablediv.ClientID%>").style.display = "none";
			}

			//alert('in fix tab _ END');
	}
	</script>
	<style type="text/css">
		html, body {
			background: none !important;
		}

		#overlay {
			position: fixed;
			z-index: 99;
			top: 0px;
			left: 0px;
			background-color: #FFFFFF;
			width: 100%;
			height: 100%;
			filter: Alpha(Opacity=80);
			opacity: 0.80;
		}

		#theprogress {
			position: center;
			  padding-top: 15%;
			padding-left: 40%;
			background-color: white;
			width: 20px;
			height: 12px;
			text-align: center;
			filter: Alpha(Opacity=100);
			opacity: 1;
		}

		#modelprogress {
			position: absolute;
			top: 50%;
			left: 50%;
			margin: -11px 0 0 -55px;
			color: white;
		}

		body > #modelprogress {
			position: fixed;
		}
	</style>
	<style>
		.mt-5, .my-5 {
			margin-top: 1rem !important;
		}

		.main-footer {
			padding: 20px 0px 20px 280px;
			margin-top: 22px;
		}

		optgroup {
			font-size: 12px;
			color: #34395e;
			font-weight: 200;
		}

		option {
			font-weight: 600;
		}

		.section > :first-child {
			margin-top: 18px;
		}

		.offset-md-9 {
			margin-left: 82%;
		}

		.card {
			height: auto !important;
		}

		label.pop {
			font-weight: 600;
			color: #2673ff;
			font-size: 15px;
			letter-spacing: .5px;
		}

		label.pops {
			font-size: 15px;
		}

		.popRow {
			border: 1px solid #239ebb;
			padding: 19px;
			border-radius: 5px;
			margin-bottom: 15px;
		}

		.offset-md-9 {
			margin-left: 87%;
		}

		ul#myTab3 {
			margin-top: 0px;
			margin-left: -40px;
		}

		.card .card-header {
			padding: 0px 40px !important;
			border-bottom: 1px solid #d2d7de;
		}

		li.nav-item {
			width: auto;
			text-align: center;
		}

		.theme-white .nav-pills .nav-link.active {
			color: #2600ff;
			background-color: #f3f1f1;
			border-bottom: 2px solid #135d6f;
			font-size: 16px;
			font-weight: 600;
		}

		.nav-pills .nav-item .nav-link {
			color: #2600ff;
			padding-left: 20px !important;
			padding-right: 20px !important;
			border-radius: 0;
			font-weight: 600;
		}

		.mt-5, .my-5 {
			margin-top: 5rem !important;
		}

		/*.offset-md-5 {
			margin-left: 60.666667%;
		}*/

		button.btn.btn-secondary.buttons-copy.buttons-html5, button.btn.btn-secondary.buttons-copy.buttons-html5,
		button.btn.btn-secondary.buttons-csv.buttons-html5, button.btn.btn-secondary.buttons-pdf.buttons-html5, button.btn.btn-secondary.buttons-print {
			display: none;
		}

		.buttons-excel {
			background-color: #5a9d44 !important;
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

		div.dataTables_wrapper div.dataTables_filter {
			text-align: right;
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

		.custom-control-label::before {
			position: absolute;
			top: 0px;
			left: -26px;
			display: block;
			pointer-events: none;
			content: "";
			background-color: #fff;
			border: #0d42a2 solid 1px;
			width: 16px;
			height: 16px;
		}

		.custom-control-label::after {
			position: absolute;
			top: 0px;
			left: -26px;
			display: block;
			width: 16px;
			height: 16px;
			content: "";
			background: no-repeat 50%/50% 50%;
			/*background-color: #2600ff !important;*/
			border-radius: 50px !important;
		}

		.custom-control .custom-control-label {
			line-height: 14px;
		}

		.modal.show .modal-content {
			width: 100% !important;
		}

		.btn.btn-lg.submit {
			margin-left: -25% !IMPORTANT;
		}

		.GridPager a, .GridPager span {
			display: block;
			height: 25px;
			width: 33px;
			font-weight: bold;
			text-align: center;
			text-decoration: none;
		}

		.theme-white a:hover {
			text-decoration: underline !important;
		}
	</style>
	 <script src="assets/js/jquery-1.8.3.min.js" type="text/javascript"></script>
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

	   </script>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

   
	<script type="text/javascript">

		$(function D1() {
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
		$(function D2() {
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

			$('#ContentPlaceHolder1_grdexcise').dataTable({
				lengthMenu: [[-1, 5, 10], ["All", 5, 10]],
				columnDefs: [{ orderable: false, targets: [] }],
				bRetrieve: true,

			});

		});



		$(function () {

			debugger;
			$("#ContentPlaceHolder1_grdexcise").DataTable({
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

			$('#ContentPlaceHolder1_grdempexercise').dataTable({
				lengthMenu: [[-1, 5, 10], ["All", 5, 10]],
				columnDefs: [{ orderable: false, targets: [] }],
				bRetrieve: true,


			});

		});
		$(function () {

			$("#ContentPlaceHolder1_grdempexercise").DataTable({
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
		<%--  document.getElementById('<%=ddlDates.ClientID%>').focus();--%>
		function ReqValidation1() {
			//debugger;

			var date = document.getElementById('<%=ddlDates.ClientID%>').value;
			var file = document.getElementById('<%=FileUpload2.ClientID%>').value;
			var ExistingDate = document.getElementById('<%=ddlExistingDate.ClientID%>').value;
			//alert(ExistingDate);
			<%--document.getElementById('<%=ddlExistingDate.ClientID%>').selectedIndex = 0;--%>
			<%-- $("#<%=ddlExistingDate.ClientID%>").val("0");--%>
			$("[id*=ddlExistingDate]").val('0');
			//alert(ExistingDate);
			
			document.getElementById('<%=txtstartdate.ClientID%>').value = "";
			document.getElementById('<%=txtenddate.ClientID%>').value = "";

			if (date.trim() == "0") {
				alert("Please select date");
				document.getElementById('<%=ddlDates.ClientID%>').focus();
				return false;
			}
			if (file.trim() == "") {
				alert("Please upload file");
				document.getElementById('<%=FileUpload2.ClientID%>').focus();
				return false;
			}
			


			var updateProgress1 = $get("<%= UpdateProgress1.ClientID %>");
			updateProgress1.style.display = "block";

		}
	</script>



	<script>


		function openModal() {
			$('#excisewiseempdata').modal({ show: true });
		}

	</script>
	<asp:ScriptManager ID="script" runat="server"></asp:ScriptManager>
	<div class="main-content">
		<nav aria-label="breadcrumb">
			<ol class="breadcrumb">
				<li class="breadcrumb-item text-left"><a href="admin-dashboard.aspx">Home</a></li>
				<li class="breadcrumb-item text-left"><a href="Admin_exercise_Window.aspx">Exercise</a></li>
				
				<li class="breadcrumb-item active" aria-current="page">Exercise Window</li>
			</ol>
		</nav>
		<section class="section">
			<input type="hidden" id="hdnTab" name="custId" value="2" />
			<div class="row">
				<div class="col-lg-12 col-md-12 col-12 col-sm-12">
					<div class="card">
						<div class="card-body">
							<div class="tab-content" id="myTabContent2">
								<div class="tab-pane fade show active" id="home3" role="tabpanel" aria-labelledby="home-tab3">
									<div class="row" style="margin-top: 15px;">

										<ul class="nav nav-tabs offset-md-4" id="myTab" role="tablist">
											<li class="nav-item">
												<a class="nav-link active" id="home-tab" data-toggle="tab" href="#home" role="tab" onclick="Hide_Div_1()"
													aria-controls="home" aria-selected="true">Setup Exercise</a>
											</li>
											<li class="nav-item">
												<a class="nav-link" id="profile-tab" data-toggle="tab" href="#profile" role="tab" onclick="Hide_Div()"
													aria-controls="profile" aria-selected="false">Upload Bank Statement</a>
											</li>
										</ul>
										<div class="tab-content mt-4" id="myTabContent">

											<div class="tab-pane fade show active" id="home" role="tabpanel" aria-labelledby="home-tab">
												<div class="row  offset-md-1">
													<div class="col-lg-4 col-md-12 col-sm-12">
														<div class="form-group">
															<label>Select Exercise Dates for Append</label>
															<asp:UpdatePanel ID="UPExcecise" runat="server">
																<ContentTemplate>
																	<asp:DropDownList ID="ddlExistingDate" runat="server" CssClass="form-control" ToolTip="To modify exercise window,please select exercise dates."
																		AutoPostBack="true" OnSelectedIndexChanged="ddlExistingDate_SelectedIndexChanged" onchange="dropchange()">
																	</asp:DropDownList>
																</ContentTemplate>
															</asp:UpdatePanel>
														</div>
													</div>
												</div>
												<div class="row offset-md-1">
													<div class="col-lg-4 col-md-12 col-sm-12">
														<asp:UpdatePanel ID="UpdatePanel1" runat="server">
															<ContentTemplate>
																<div class="form-group">
																	<label>Exercise Start Date <span style="color: red">*</span></label>
																	<asp:TextBox ID="txtstartdate" type="text" runat="server" Placeholder="dd-mm-yyyy" AutoPostBack="true" OnTextChanged="txtstartdate_TextChanged"
																		class="form-control" AutoComplete="off"></asp:TextBox>
																</div>
															</ContentTemplate>
														</asp:UpdatePanel>
													</div>
													<div class="col-lg-4 col-md-12 col-sm-12">
														<asp:UpdatePanel ID="UpdatePanel2" runat="server">
															<ContentTemplate>
																<div class="form-group">
																	<label>Exercise End Date <span style="color: red">*</span></label>
																	<asp:TextBox ID="txtenddate" type="text" runat="server" Placeholder="dd-mm-yyyy" AutoPostBack="true"
																		OnTextChanged="txtenddate_TextChanged1" class="form-control" AutoComplete="off"></asp:TextBox>
																</div>
															</ContentTemplate>
														</asp:UpdatePanel>
													</div>

													<div class="col-lg-2 col-md-12 col-sm-12">

														<div class="form-group">
															<label>FMV Price <span style="color: red">*</span></label>
															<label class="or" style="right: -15%">OR</label>
															<asp:UpdatePanel ID="UpdatePanel3" runat="server">
																<ContentTemplate>
																	<div class="input-group mb-3">
																		<asp:DropDownList ID="ddlFMV" runat="server" CssClass="form-control" AutoPostBack="true">
																		</asp:DropDownList>
																	</div>
																</ContentTemplate>
															</asp:UpdatePanel>
														</div>
													</div>
													<div class="col-lg-2 col-md-12 col-sm-12" style="margin-top: 28px">
														<div class="form-group">
															<label></label>
															<a href="#" class="btn btn-info btn-lg" style="background-color: blue;" data-toggle="modal" data-target="#ModalCreateFMV">Create FMV</a>
														</div>
													</div>

													<div class="col-lg-4 col-md-12 col-sm-12 multidatadiv">
														<div class="form-group">
															<label>Upload Taxable Income <span style="color: red">*</span></label>
                                                            <asp:FileUpload ID="uploadfile" runat="server" CssClass="dropify" accept=".xls, .xlsx" class="form-control" /><br />
                                                            <%--Added by Krutika on 16-06-22--%>
                                                            <asp:Label ID="lblFileType" runat="server" Text="(Only .xls, .xlsx files are allowed.)" ForeColor="Green" Font-Bold="true" Font-Size="14px"></asp:Label>
                                                        </div>
                                                    </div>
                                                    <div class="col-lg-4 col-md-12 col-sm-12" style="display: none">
                                                        <div class="form-group" id="divDataAction">
                                                            <div class="section-title" style="margin-bottom: 15px;">Data Action</div>
                                                            <div class="custom-control custom-radio custom-control-inline" style="margin-bottom: 15px;">
                                                                <input type="radio" id="RadioAppend" name="customRadioInline3" value="AppendData" class="custom-control-input" runat="server">
                                                                <label class="custom-control-label" for="ContentPlaceHolder1_RadioAppend">Append</label>
                                                            </div>
                                                            <div class="col-lg-2 custom-control custom-radio custom-control-inline">
                                                                <input type="radio" id="RadioOverwrite" name="customRadioInline3" value="OverwriteData" class="custom-control-input" runat="server">
                                                                <label class="custom-control-label" for="ContentPlaceHolder1_RadioOverwrite">Overwrite</label>
                                                            </div>
                                                        </div>
                                                    </div>
                                                    <div class="col-lg-4 col-md-12 col-sm-12">
                                                        <div class="form-group">
                                                            <asp:UpdatePanel ID="Updatepanel5" runat="server">
                                                                <ContentTemplate>
                                                                    <div class="section-title">Upload Format</div>
                                                                    <div class="">
                                                                        <label style="margin-right: 15px;">Excel  </label>
                                                                        <%--<a href="#" class="linkbtn" style="font-size: 14px; font-weight: 500; letter-spacing: 0.2px; margin: 10px 0 0 0; color: #5e65ff; clear: both; text-decoration: underline">Download Template</a>--%>
                                                                        <asp:LinkButton ID="myLink" Text="Download Template" OnClick="myLink_Click" runat="server" />
                                                                    </div>
                                                                </ContentTemplate>
                                                                <Triggers>
                                                                    <asp:PostBackTrigger ControlID="myLink" />
                                                                </Triggers>
                                                            </asp:UpdatePanel>

														</div>
													</div>
												</div>
												<div class="row">
													<div class="col-lg-3 offset-md-6 mt-1">
														<asp:UpdatePanel ID="UP_submit" runat="server">
															<ContentTemplate>

																<asp:Button ID="btnSubmit" runat="server" Text="Submit" OnClientClick=" return validate(); showProgress(); return false;return postbackButtonClick();" CssClass="btn btn-info btn-lg submit " OnClick="btnSubmit_Click" />
																<%--OnClientClick="return validate();return false;" --%>
															</ContentTemplate>
															<Triggers>
																<asp:PostBackTrigger ControlID="btnSubmit" />
															</Triggers>
														</asp:UpdatePanel>
													</div>
												</div>
											</div>


											<div class="tab-pane fade" id="profile" role="tabpanel" aria-labelledby="profile-tab">
												<div class="row" style="margin-left: 330px;">
													<div class="col-lg-4 col-md-12 col-sm-12 multidatadiv">
														<div class="form-group">
															<label>Select Date</label><span style="color: red">*</span>
															<asp:DropDownList ID="ddlDates" runat="server" CssClass="form-control" AutoPostBack="false">
															</asp:DropDownList>
														</div>
													</div>
													<div class="col-lg-6 col-md-12 col-sm-12">
														<div class="form-group">
															<label>Upload File</label><span style="color: red">*</span>
                                                            <asp:FileUpload ID="FileUpload2" runat="server" CssClass="dropify" accept=".xls, .xlsx" class="form-control" /><br />
                                                            <%--Added by Krutika on 16-06-22--%>
                                                            <asp:Label ID="lblFileType2" runat="server" Text="(Only .xls, .xlsx files are allowed.)" ForeColor="Green" Font-Bold="true" Font-Size="14px"></asp:Label>
                                                        </div>
                                                    </div>
                                                    <div class="col-lg-6 col-md-12 col-sm-12" style="display: none">
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
                                                        <asp:UpdatePanel ID="up_submit1" runat="server">
                                                            <ContentTemplate>
                                                                <asp:Button ID="btnImport" runat="server" Text="Submit" Style="margin-left: 40% !important;" CssClass="btn btn-info btn-lg" OnClick="btnSubmit_Click" OnClientClick="return ReqValidation1(); showProgress1(); return false;return postbackButtonClick();" />
                                                                <%--OnClientClick="return ReqValidation1()"--%>
                                                            </ContentTemplate>
                                                            <Triggers>
                                                                <asp:PostBackTrigger ControlID="btnImport" />
                                                            </Triggers>
                                                        </asp:UpdatePanel>
                                                    </div>
                                                </div>
                                            </div>
                                            <div style="color: red; float: right">
                                                All (*) marked fields are mandatory.
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                        <asp:UpdatePanel ID="upd3" runat="server">
                            <ContentTemplate>
                                <div id="showmsg" runat="server"></div>
                            </ContentTemplate>
                        </asp:UpdatePanel>

					</div>
				</div>
			</div>



			<div class="col-lg-12 col-md-12 col-12 col-sm-12" runat="server" id="tablediv1" style="display: none">
				<div class="card" style="height: auto;">
					<div class="card-header">
						<h4>Exercise Detail</h4>
					</div>
					<div class="card-body">
						<div class="table-responsive">
							<table class="table table-bordered">
								<%--  <asp:UpdatePanel ID="upd" runat="server" UpdateMode="Conditional">
									<ContentTemplate>--%>
								<asp:GridView ID="grdexcise" runat="server" AutoGenerateColumns="False" ShowHeaderWhenEmpty="false"
									DataKeyNames="EXERCISE_ID" EmptyDataText="" OnPreRender="grdexcise_PreRender" OnRowDataBound="grdexcise_RowDataBound" OnSelectedIndexChanged="grdexcise_SelectedIndexChanged"
									class="table">
									<%-- <RowStyle HorizontalAlign="Left" />--%>
									<Columns>
										<asp:TemplateField HeaderText="Exercise Start Date">
											<ItemTemplate>
												<asp:HyperLink ID="lblstrtdate" runat="server" Text='<%#Eval("START_DATE") %>' ToolTip="Click to View Excercise records" ForeColor="Blue"> </asp:HyperLink>
												<%--<asp:Label ID="lblstrtdate" runat="server" Text='<%#Eval("START_DATE") %>' />--%>
											</ItemTemplate>
										</asp:TemplateField>
										<asp:TemplateField HeaderText="Exercise End Date">
											<ItemTemplate>
												<asp:HyperLink ID="lbltodate" runat="server" Text='<%#Eval("END_DATE") %>' ToolTip="Click to View Excercise records" ForeColor="Blue"> </asp:HyperLink>
												<%--<asp:Label ID="lbltodate" runat="server" Text='<%#Eval("END_DATE") %>' />--%>
											</ItemTemplate>
										</asp:TemplateField>
										<asp:TemplateField HeaderText="Fmv Price">
											<ItemTemplate>
												<asp:HyperLink ID="lblfmvprice" runat="server" Text='<%#Eval("FMV_PRICE") %>' ToolTip="Click to View Excercise records" ForeColor="Blue"> </asp:HyperLink>
												<%--<asp:Label ID="lblfmvprice" runat="server" Text='<%#Eval("FMV_PRICE") %>' />--%>
											</ItemTemplate>
										</asp:TemplateField>
									</Columns>
								</asp:GridView>

								<%--  </ContentTemplate>
									<Triggers>

										<asp:PostBackTrigger ControlID="grdexcise" />
									</Triggers>
								</asp:UpdatePanel>--%>
							</table>
						</div>
					</div>
				</div>
			</div>
			<div class="col-lg-12 col-md-12 col-12 col-sm-12" id="tablediv" runat="server" style="margin-left: 4%;">
				<div class="card" style="height: auto; margin-right: 7%;">
					<div class="card-header">
						<h4>Record Summary</h4>
					</div>
					<div class="card-body">
						<div class="table-responsive">
							<table class="table table-bordered">
								<tbody>
									<tr>
										<td width="100px">1</td>
										<td>Total records uploaded</td>
										<td>
											<%--<div class="badge badge-info"><%= TotalRecords %></div>--%>
										</td>
										<td>No.of records uploaded successfully</td>
										<td>
											<%--<div class="badge badge-success"><%= SuccRecords %></div>--%>
										</td>
										<td>No.of records failed</td>
										<td>
											<%--<div class="badge badge-danger"><%= FailRecords %></div>--%>
										</td>
										<td>
											<%--<a href="#" class="btn btn-icon icon-left" style="font-size: 16px; font-weight: 500; letter-spacing: 0.2px; margin: 10px 0 0 0; color: #5e65ff; clear: both;"><i class="fas fa-arrow-circle-down"></i>Download Failed Records</a>--%>
											<button runat="server" id="btnExDown" onserverclick="downloadFailedRec" style="background: none">
												<i class="fas fa-arrow-circle-down"></i>
												<%--<i class="fas fa-file-excel excel" title="Download Excel" aria-hidden="true"></i>--%>
											</button>
										</td>
									</tr>
								</tbody>
							</table>
						</div>
					</div>
				</div>
			</div>

			<asp:UpdateProgress ID="UpdateProgress" runat="server" AssociatedUpdatePanelID="up_submit">
				<ProgressTemplate>
					<div id="overlay">
						<div id="modalprogress">
							<div id="theprogress">
							<img src="assets/img/loading.gif" />
							</div>
						</div>
					</div>
				</ProgressTemplate>
			</asp:UpdateProgress>

			<asp:UpdateProgress ID="UpdateProgress1" runat="server" AssociatedUpdatePanelID="up_submit1">
				<ProgressTemplate>
					<div id="overlay">
						<div id="modalprogress">
							<div id="theprogress">
							  <img src="assets/img/loading.gif" />
							</div>
						</div>
					</div>
				</ProgressTemplate>
			</asp:UpdateProgress>
		</section>


		<div class="modal fade bd-example-modal-lg" tabindex="-1" id="excisewiseempdata" role="dialog" aria-labelledby="myLargeModalLabel" aria-hidden="true">
			<div class="modal-dialog modal-lg">
				<div class="modal-content">
					<div class="modal-header">
						<h5 class="modal-title" id="myLargeModalLabel2">Employee Details</h5>
					</div>

					<div class="card-body">
						<div class="table-responsive">
							<asp:UpdatePanel ID="UpdatePanel4" runat="server">
								<ContentTemplate>
									<asp:GridView ID="grdempexercise" runat="server" AutoGenerateColumns="False" AllowPaging="false" PageSize="10" OnSorting="grdempexercise_Sorting" AllowSorting="false"
										ShowHeaderWhenEmpty="false" class="table" EmptyDataText="" OnPageIndexChanging="grdempexercise_PageIndexChanging" OnPreRender="grdempexercise_PreRender">
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

											<asp:TemplateField HeaderText="Taxable Income" SortExpression="Taxable_Income">
												<ItemTemplate>
													<asp:Label ID="lblTaxable_Income" runat="server" Text='<%#Eval("Taxable_Income") %>' />
												</ItemTemplate>
											</asp:TemplateField>

											<asp:TemplateField HeaderText="Vesting Date" SortExpression="VESTING_DATE">
												<ItemTemplate>
													<asp:Label ID="lblvestingdate" runat="server" Text='<%#Eval("VESTING_DATE") %>' />
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
					<%--  <button type="button" class="close" data-dismiss="modal" aria-label="Close">
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
                                <%--<span style="color: red">*</span>   Commented by Krutika on 16-06-22  --%>
                                <div class="input-group mb-3">
                                    <asp:DropDownList ID="ddlvaluedby" runat="server" CssClass="form-control" Style="width: 100% !important;">
                                    </asp:DropDownList>
                                </div>
                            </div>
                        </div>

                        <div class="col-lg-6 col-md-12 col-sm-12">
                            <div class="form-group">
                                <label>Upload File </label>
                                <%--<span style="color: red">*</span>   Commented by Krutika on 16-06-22  --%>
                                <asp:FileUpload ID="FileUpload1" runat="server" class="form-control" />
                                <%--Added by Krutika on 16-06-22--%>
                                <asp:Label ID="lblFileType1" runat="server" Text="(Only .xls, .xlsx files are allowed.)" ForeColor="Green" Font-Bold="true" Font-Size="14px"></asp:Label>
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

	<script>

		document.getElementById("<%=tablediv1.ClientID%>").style.display = "block";




		function Hide_Div() {
			document.getElementById("<%=tablediv.ClientID%>").style.display = "none";

			document.getElementById("hdnTab").value = 2;
			var tabIndex = document.getElementById("hdnTab").value;

		};
		function Hide_Div_1() {

			var t2 = document.getElementById("profile");
			t2.setAttribute('class', 'tab-pane fade');
			document.getElementById("Profile").style.display = "none";
			document.getElementById("<%=tablediv1.ClientID%>").style.display = "block";
			document.getElementById("<%=showmsg.ClientID%>").style.display = "none";

		};
	</script>



	<script type="text/javascript">
		function ReqValidation() {
			//debugger;
			var FileUpload1 = document.getElementById('<%=FileUpload1.ClientID%>').value;

			var validationdate = document.getElementById('<%=txtvaldate.ClientID%>').value;
			var validupto = document.getElementById('<%=txtvalidupto.ClientID%>').value;
			var FMVPrice = document.getElementById('<%=txtfmvprice.ClientID%>').value;
			var ValueBy = document.getElementById('<%=ddlvaluedby.ClientID%>').value;

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
			//Commented by Krutika on 16-06-22
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
        }
    </script>
    <script language="javascript" type="text/javascript">
        function validate() {

			if (document.getElementById("<%=txtstartdate.ClientID%>").value == "") {
				alert("Please enter Exercise Start Date");
				document.getElementById("<%=txtstartdate.ClientID %>").focus();
				return false;
			}
			if (document.getElementById("<%=txtenddate.ClientID%>").value == "") {
				alert("Please enter Exercise End Date");
				document.getElementById("<%=txtenddate.ClientID %>").focus();
				return false;
			}
			if (document.getElementById("<%=ddlFMV.ClientID%>").value == 0) {
				alert("Please select FMV price");
				document.getElementById("<%=ddlFMV.ClientID%>").focus();
				return false;
			}
			if (document.getElementById("<%=uploadfile.ClientID%>").value == 0) {
				alert("Please Select File to upload!!");
				document.getElementById("<%=uploadfile.ClientID%>").focus();
				return false;
			}
			var updateProgress = $get("<%= UpdateProgress.ClientID %>");
			updateProgress.style.display = "block";

		}

		$('#tablediv').hide();
		$('#btnSubmit').click(function () {
			$('#tablediv').slideToggle();
			$('html, body').animate({
				scrollTop: $("#tablediv").offset().top
			}, 2000);

		});

		$('#profile-tab').click(function () {

			document.getElementById("<%=tablediv1.ClientID%>").style.display = "none";
			document.getElementById("<%=showmsg.ClientID%>").style.display = "none";
		});

		$('#home-tab').click(function () {

			document.getElementById("<%=tablediv1.ClientID%>").style.display = "block";
			document.getElementById("<%=showmsg.ClientID%>").style.display = "none";
		});
	</script>
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
	<!-- General JS Scripts -->
	<script src="assets/js/bootstrap-3.3.6.min.js"></script>
	<script src="assets/js/app.min.js"></script>

	<script src="assets/js/scripts.js"></script>
	<script type="text/javascript">
		function showProgress() {
			debugger;
			var updateProgress = $get("<%= UpdateProgress.ClientID %>");
			updateProgress.style.display = "block";
		}
	</script>
	<script type="text/javascript">
		function showProgress1() {
			debugger;
			var updateProgress1 = $get("<%= UpdateProgress1.ClientID %>");
			updateProgress1.style.display = "block";
		}
	</script>

	<script type="text/javascript">
		$(document).ready(function () {
			dropchange();
			$('.CloseBtnNew').click(function () {
			   // alert('test');

				$("#myModal").removeClass("show");
				$("#myModal").hide();
				$(".modal-backdrop").remove();
				//$("#myModal").hide();
				$("body").removeClass("modal-open");
				// $("#myModal1").modal("hide");
			});
		});

		function dropchange() {
			var ddlExistingDate = document.getElementById("<%=ddlExistingDate.ClientID %>");
			var ddlExistingDateVal = ddlExistingDate.value;

			if (ddlExistingDateVal == "0") {
				$("#divDataAction").css({ 'display': 'none' });
			}
			else {
				$("#divDataAction").css({ 'display': 'block' });
			}
		}
	</script>
</asp:Content>
