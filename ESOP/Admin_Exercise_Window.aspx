<%@ Page Title="" Language="C#" MasterPageFile="~/ESOP.Master" AutoEventWireup="true" CodeBehind="Admin_Exercise_Window.aspx.cs" Inherits="ESOP.Admin_Exercise_Window" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
		.main-content {
			padding-top: 38px;
		}

		.main-footer {
			margin-top: 7px;
		}

		.card {
			height: 100%;
		}

		.mt-5, .my-5 {
			margin-top: 2.6rem !important;
		}

		h3 {
			font-weight: 600;
		}

		.card.card-sales-widget {
			background: linear-gradient(90deg, rgb(23 153 183) 0%, rgb(33 162 191 / 89%) 35%, rgb(35 191 227 / 51%) 100%);
		}

			.card.card-sales-widget .card-header .card-text-blue {
				color: white !important;
				text-shadow: 2px 2px 3px #020c0e !important;
			}

		.bg-blue {
			background-color: #f2f2f2 !important;
			color: #fff;
		}

		.card.card-sales-widget .card-header {
			margin-top: 11%;
		}

		.card .card-header {
			background-color: transparent;
			padding: 15px 10px !important;
		}

		.card.card-sales-widget:hover {
			background: #1d99c7b8;
		}

		h3.font-light.mb-0 {
			font-size: 22px;
			color: white;
			text-shadow: 2px 2px 2px #053a46;
		}

		.mr-4, .mx-4 {
			margin-right: 5.5rem !important;
		}

		.bg-info {
			background-color: #615a72 !important;
			width: 30px;
			height: 30px;
			position: absolute !important;
			top: -13px;
		}

		.card.card-statistic-1, .card.card-statistic-2 {
			display: inline-block;
			width: 100%;
			background: linear-gradient(90deg, rgb(23 153 183) 0%, rgb(33 162 191 / 89%) 35%, rgb(35 191 227 / 51%) 100%);
		}

			.card.card-statistic-1 .card-icon-bg-green .fas {
				color: white;
			}

			.card.card-statistic-1 .card-icon-bg-green {
				border: 2px solid #116173;
			}

		.card.card-statistic-1 {
			border-left: 4px solid #116173;
		}

		a:not(.btn-social-icon):not(.btn-social):not(.page-link) .fas {
			margin-left: 1px;
		}

		.card.card-statistic-1 .card-icon-square .fas {
			font-size: 22px;
		}

		.card.card-statistic-1:hover {
			background: #32a6c1;
		}

		span.notification-count.bg-info {
			color: white;
			padding: 1px 10px;
			font-size: 11px !important;
			padding-top: 7px;
			font-weight: 600;
		}

		.card.profile-widget {
			width: 100% !important;
		}

		.card {
			height: 450px;
		}

		.profile-widget .profile-widget-picture {
			box-shadow: 0 4px 25px 0 rgba(0, 0, 0, .1);
			width: 99px;
			margin-top: -44px;
			display: block;
			z-index: 1;
			padding: 9px !important;
		}

		.card.profile-widget {
			background: #25bddf12;
		}

		.profile-widget .profile-widget-description .profile-widget-name {
			font-size: 17px;
			margin-bottom: 46px;
			font-weight: 600;
			text-align: center;
			color: #34395e;
			padding: 5px;
			background: #279db81c;
			margin-top: -64px;
		}

		span.notification-count.bg-info {
			right: 10px;
			top: 44px;
		}

		.profile-widget-name:hover {
			border: 1px solid #96a2b48f;
		}

		a {
			color: #2f9b96;
			text-decoration: none !important;
		}

		/*.feature-rounded {
			width: 100px;
			height: 100px;
			border-radius: 50%;
			overflow: hidden;
			padding: 18px 0;
			background: #2673FF;
			position: relative;
			top: -60%;
			left: 50%;
			transform: translateX(-50%);
			/* text-align: center;
			border: 1px solid #2673FF;
		}*/

		.feature-rounded img {
			width: 55px;
			margin: 0 auto;
			display: block;
		}

		.profile-widget .profile-widget-description {
			padding: 20px;
			line-height: 26px;
			z-index: 1000 !important;
		}

		.section > :first-child {
			margin-top: 20px;
		}

		.offset-md-10 {
			margin-left: 88.333333%;
		}

		.offset-md-9 {
			margin-left: 84%;
		}
	</style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
	<asp:ScriptManager ID="sc1" runat="server"></asp:ScriptManager>
	<div class="main-content">
		<nav aria-label="breadcrumb" >
			<ol class="breadcrumb">
				<li class="breadcrumb-item"><a href="admin-dashboard">Home</a></li>
				<%--style="margin-left: -23px;"--%>
				<li class="breadcrumb-item active" aria-current="page">Exercise</li>
				<%--style="margin-top: -15px; margin-left: 23px;"--%>
			</ol>
		</nav>
		<section class="section">
			<div class="row">
				<div class="col-lg-12 col-md-12 col-12 col-sm-12">
					<div class="card">
						<div class="card-header">
							<h4>Exercise</h4>
						</div>
						<div class="offset-md-1 card-body mr-4">
							<div class="row" style="margin-top: 55px;">
								<div class="col-12 col-sm-12 col-lg-3">
									<div class="card profile-widget" style="height: 65%;">
										<div class="profile-widget-header">
											<div class="row">
												<div class="col-12">
													<div class="feature-rounded">
														<img alt="image" src="assets/img/grant (4).png" class="">
													</div>
												</div>
											</div>
										</div>
										<div class="profile-widget-description pb-0">
											<a href="exercise.aspx">
												<div class="profile-widget-name">
													
												   <span class="notification-count bg-info" style="color: white; padding: 4px 7px; font-size: 16px; padding-top: 7px;" id="ExerciseWindowcount" runat="server"></span>Exercise Window
												</div>
											</a>
										</div>
									</div>
								</div>
								<div class="col-12 col-sm-12 col-lg-3">
                                    <div class="card profile-widget" style="height: 65%;">
                                        <div class="profile-widget-header">
                                            <div class="row">
                                                <div class="col-12">
                                                    <div class="feature-rounded">
                                                        <img alt="image" src="assets/img/document.png" class="">
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                        <div class="profile-widget-description pb-0">
                                            <a href="Admin_Exercise_Approve_Reject_New.aspx">
                                                <div class="profile-widget-name">
                                                    <span class="notification-count bg-info" style="color: white; padding: 4px 7px; font-size: 16px; padding-top: 7px;" id="DetailsApprovecount" runat="server"></span>Details Approve
                                                    <%--<span class="notification-count bg-info" style="color: white; padding: 4px 7px; font-size: 16px; padding-top: 7px;" id="updategrnt" runat="server"></span>Sell Approve--%>
                                                </div>
                                            </a>
                                        </div>
                                    </div>
                                </div>  
                                <div class="col-12 col-sm-12 col-lg-3">
                                    <div class="card profile-widget" style="height: 65%;">
                                        <div class="profile-widget-header">
                                            <div class="row">
                                                <div class="col-12">
                                                    <div class="feature-rounded">
                                                        <img alt="image" src="assets/img/document.png" class="">
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                        <div class="profile-widget-description pb-0">
                                            <a href="Admin_Details_Approve_Reject.aspx">
                                                <div class="profile-widget-name">
                                                    <span class="notification-count bg-info" style="color: white; padding: 4px 7px; font-size: 16px; padding-top: 7px;" id="ExerciseApprovecount" runat="server"></span>Exercise Approve
                                                    <%--<span class="notification-count bg-info" style="color: white; padding: 4px 7px; font-size: 16px; padding-top: 7px;" id="updategrnt" runat="server"></span>Sell Approve--%>
                                                </div>
                                            </a>
                                        </div>
                                    </div>
                                </div>

                                <div class="col-12 col-sm-12 col-lg-3">
									<div class="card profile-widget" style="height: 65%;">
										<div class="profile-widget-header">
											<div class="row">
												<div class="col-12">
													<div class="feature-rounded">
														<img alt="image" src="assets/img/document.png" class="">
													</div>
												</div>
											</div>
										</div>
										<div class="profile-widget-description pb-0">
											<a href="Admin_Exercise_Cancel.aspx">
												<div class="profile-widget-name">
													
												   <span class="notification-count bg-info" style="color: white; padding: 4px 7px; font-size: 16px; padding-top: 7px;" id="RevertCount" runat="server"></span>Exercise Revert
												</div>
											</a>
										</div>
									</div>
								</div>

							</div>
						</div>
					</div>
				</div>
			</div>
		</section>
	</div>

	<!-- General JS Scripts -->
	<script src="assets/js/app.min.js"></script>
	<!-- JS Libraies -->
	<script src="assets/bundles/echart/echarts.js"></script>
	<!-- Page Specific JS File -->
	<script src="assets/js/page/chart-echarts.js"></script>
	<!-- Page Specific JS File -->
	<script src="assets/js/page/index.js"></script>
	<!-- Template JS File -->
	<script src="assets/js/scripts.js"></script>
</asp:Content>

