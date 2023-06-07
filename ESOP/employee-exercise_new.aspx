<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/ESOP.Master" CodeBehind="employee-exercise_new.aspx.cs" Inherits="ESOP.employee_exercise_new" %>


<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
        /*.img {
			height: 200px;
			width: 400px;
		}
		.img:hover {
			transform: scale(1);
		}*/
        .img {
            padding: 0px;
            transition: transform .2s;
            width: 200px;
            height: 100px;
            margin: 0 auto;
        }

        /*.img:hover {
				transform: scale(1.5);
				width: 400px;
				height: 200px;
			}*/
        .Image2:hover {
            transform: scale(2);
            margin-top: -30% !important;
            margin-left: 40% !important;
            width: 400px;
            height: 200px;
        }

        .Image5:hover {
            transform: scale(2);
            margin-top: -30% !important;
            margin-left: -50% !important;
            width: 400px;
            height: 200px;
        }
        /*.n_pnl {
			position: relative;
			display: inline-block;
		}

			.n_pnl .n_pnltext {
				visibility: hidden;
				width: auto;
				background: #fff;
				border-radius: 5px;
				border: 4px solid #fff;
				box-shadow: 2px 3px 4px #000;
				color: #fff;
				text-align: center;
				border-radius: 6px;
				/* Position the tooltip *
				position: absolute;
				z-index: 1;
			}

			.n_pnl:hover .n_pnltext {
				visibility: visible;
			}*/

        .mt-5, .my-5 {
            margin-top: 1rem !important;
        }

        .main-footer {
            padding: 20px 0px 20px 280px;
            margin-top: 10px;
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
            height: auto;
        }

        legend {
            display: block;
            width: 40%;
            max-width: 100%;
            padding: 0;
            margin-bottom: .5rem;
            font-size: 1.1rem;
            line-height: inherit;
            white-space: normal;
            color: #2774ff;
            font-weight: 500;
        }

        fieldset {
            min-width: 0;
            padding: 0;
            margin: 0;
            border: 0;
            display: block;
            margin-inline-start: 2px;
            margin-inline-end: 2px;
            padding-block-start: 0.35em;
            padding-inline-start: 0.75em;
            padding-inline-end: 0.75em;
            padding-block-end: 0.625em !important;
            min-inline-size: min-content;
            border-width: 2px;
            border-style: groove;
            border-color: threedface;
            border-image: initial;
            margin-bottom: 0px !important;
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
            border-radius: 5px;
            margin-bottom: 15px;
        }

        .offset-md-10 {
            margin-left: 86.333333%;
        }

        .table-responsive {
            padding: 11px;
        }

        .table:not(.table-sm) thead th {
            background-color: #6c757d3d;
        }

        .form-group .control-label, .form-group > label {
            font-size: 14px !important;
            line-height: 1;
            height: 20px;
        }

        .form-control:not(.form-control-sm):not(.form-control-lg) {
            font-size: 13px;
            padding: 1px 10px;
            height: 30px;
            line-height: 1.4;
        }

        label {
            display: inline-block;
            margin-bottom: .3rem;
        }

        .col-sm-12 {
            padding-right: 0px;
            padding-left: 20px;
        }

        .col-lg-2 {
            max-width: 16.3%;
        }

        select.form-control:not([size]):not([multiple]) {
            height: 30px !important;
        }

        .form-control:not(.form-control-sm):not(.form-control-lg), .input-group-text, select.form-control:not([size]):not([multiple]) {
            line-height: 1.3;
        }

        /*grid css*/
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
            padding: 0px;
            padding-left: 5px;
        }

        .table th {
            background-color: #6c757d4f;
            color: #000000 !important;
            font-size: 14px !important;
            line-height: 1.3;
        }

        .table td {
            font-weight: 500;
            color: #3f646d;
            font-size: 14px;
            background: #bcc0c32e;
        }

        .table:not(.table-sm):not(.table-md):not(.dataTable) th {
            font-weight: 600;
            color: #000000c2 !important;
        }


        fieldset {
            min-width: 0 !important;
            padding: 0 !important;
            margin: 0 !important;
            border: 0 !important;
            display: block !important;
            margin-inline-start: 2px !important;
            margin-inline-end: 2px !important;
            padding-block-start: 0.35em !important;
            padding-inline-start: 0.75em !important;
            padding-inline-end: 0.75em !important;
            padding-block-end: 0.625em !important;
            min-inline-size: min-content !important;
            border-width: 2px !important;
            border-style: groove !important;
            border-color: threedface !important;
            border-image: initial !important;
            margin-bottom: 5px !important;
        }

        legend {
            display: block !important;
            width: 40% !important;
            max-width: 100% !important;
            padding: 4px !important;
            margin-bottom: .5rem !important;
            font-size: 17px !important;
            line-height: inherit !important;
            white-space: normal !important;
            color: #2774ff !important;
            font-weight: 500 !important;
        }

        body {
            margin: 0 !important;
            font-family: -apple-system, BlinkMacSystemFont, "Segoe UI", Roboto, "Helvetica Neue", Arial, "Noto Sans", sans-serif, "Apple Color Emoji", "Segoe UI Emoji", "Segoe UI Symbol", "Noto Color Emoji" !important;
            font-size: 16px !important;
            font-weight: 400 !important;
            line-height: 1 !important;
            color: #212529 !important;
            text-align: left !important;
            background-color: #eef0f0 !important;
        }

        .main-content {
            padding-left: 280px;
            padding-right: 30px;
            padding-top: 35px !important;
            width: 100%;
            position: relative;
            margin-left: -12px;
        }

        label {
            display: inline-block;
            max-width: 100%;
            margin-bottom: 5px;
            font-weight: 400 !important;
        }

        .navbar {
            position: relative;
            min-height: 50px;
            margin-bottom: 0px !important;
            border: 1px solid transparent;
        }

        .navbar {
            height: 70px;
            /*width: 1527px;*/
            padding: 8px 16px;
            left: 250px;
            right: 0;
            position: absolute !important;
            z-index: 890;
            background-color: transparent;
        }

        h2.logo {
            color: #2600ff !important;
            font-size: 42px !important;
        }

        h1, h2, h3, h4, h5, h6 {
            font-weight: 600 !important;
        }

        .h2, h2 {
            font-size: 2rem !important;
        }

        .h1, .h2, .h3, .h4, .h5, .h6, h1, h2, h3, h4, h5, h6 {
            margin-bottom: .5rem !important;
            font-weight: 500 !important;
            line-height: 1.2 !important;
        }

        h1, h2, h3, h4, h5, h6 {
            margin-top: 0 !important;
            margin-bottom: .5rem !important;
        }

        /*constructed stylesheet *, ::after, ::before {
			box-sizing: border-box;
		}*/

        h2 {
            display: block !important;
            font-size: 1.5em !important;
            margin-block-start: 0.83em !important;
            margin-block-end: 0.83em !important;
            margin-inline-start: 0px !important;
            margin-inline-end: 0px !important;
            font-weight: bold !important;
        }

        label.pop {
            font-weight: 600 !important;
            color: #2673ff !important;
            font-size: 14px !important;
            letter-spacing: .5px !important;
        }

        select {
            min-height: 31px;
        }

        label.pops {
            font-weight: 600 !important;
            color: #34395e !important;
            font-size: 14px !important;
            letter-spacing: .5px !important;
        }

        .btn.btn-lg {
            /*padding: 0.40rem 1.5rem !important;*/
            font-size: 13px !important;
            color: white !important;
        }

        .btn-info, .btn-info.disabled {
            box-shadow: 0 2px 6px #719ef8 !important;
            font-size: 14px !important;
            background: #2600ff !important;
            border: 2px solid #09728a !important;
        }

        .btn {
            font-weight: 600 !important;
            font-size: 12px !important;
            line-height: 24px !important;
            padding: .2rem .8rem !important;
            letter-spacing: .5px !important;
        }

        /*letter view*/
        .letterview {
            background-color: #ffffff !important;
            text-align: center !important;
            border: 0px solid #eee !important;
            -moz-box-shadow: 0 0 15px rgba(0, 0, 0, 0.188235) !important;
            -webkit-box-shadow: 0 0 15px rgba(0, 0, 0, 0.188235) !important;
            box-shadow: 2px 2px 15px rgb(0 0 0 / 43%) !important;
            -moz-border-radius: 6px !important;
            -webkit-border-radius: 6px !important;
            border-radius: 6px !important;
            margin-bottom: 15px !important;
        }

        figure.snip0013 {
            position: relative !important;
            overflow: hidden !important;
            width: 100% !important;
            padding: 10px 10px 0px !important;
            background: #fff !important;
            text-align: center !important;
            border-radius: 8px !important;
        }

        .letterview p {
            margin: 3px 0 0 !important;
            font-size: 10px !important;
            font-weight: 500 !important;
            letter-spacing: 0.3px !important;
            color: dimgray !important;
            text-align: left !important;
        }

        figure.snip0013 img {
            max-width: 100% !important;
            opacity: 1 !important;
            -webkit-transition: opacity 0.35s !important;
            transition: opacity 0.35s !important;
        }

        .letterview p i {
            font-size: 12px !important;
            vertical-align: middle !important;
            margin-right: 3px !important;
            color: #ffffff !important;
            background: #078ca9 !important;
            padding: 6px 6px !important;
            border-radius: 5px 0 0 0 !important;
            position: absolute !important;
            bottom: -1px !important;
            right: -3px !important;
        }

        figure.snip0013:hover {
            background: #1fa2c02b !important;
        }


        .table1 th {
            /* background-color: #6c757d4f; */
            color: #000000c2 !important;
            font-size: 14px !important;
            line-height: 2.3;
            padding-left: 20px;
            font-weight: 600;
        }

        .table1 td {
            padding: 0px;
            padding-left: 15px;
            padding-left: 15px;
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
            /* background-color: #2600ff !important; */
            border-radius: 50px !important;
        }

        .modal-header {
            padding: 10px 30px 5px 30px !important;
        }
    </style>

    <link href="assets/css/jquery-ui-1.12.1.css" rel="stylesheet" />

    <script src="assets/js/jquery-1.12.4.js" type="text/javascript"></script>
    <script src="assets/js/app.min.js"></script>

    <script>
        function Clear() {
            if (document.getElementById('customRadioInline4').checked) {
                document.getElementById('<%=ddlNEFTBankName.ClientID%>').value = 0;
                document.getElementById('<%=txtNEFTBankName.ClientID%>').value = "";
                document.getElementById('<%=txtNEFTBranchName.ClientID%>').value = "";
                document.getElementById('<%=txtNEFTAccNo.ClientID%>').value = "";
                document.getElementById('<%=txtNEFTIFSC.ClientID%>').value = "";
                document.getElementById('<%=txtNEFTUTR.ClientID%>').value = "";
                document.getElementById('<%=fuNEFT1.ClientID%>').value = "";

                document.getElementById('<%=txtLoanBankName.ClientID%>').value = "";
                document.getElementById('<%=txtLoanAmount.ClientID%>').value = "";
                document.getElementById('<%=txtLoanMarginAmount.ClientID%>').value = "";
                document.getElementById('<%=ddlLoanMarginMode.ClientID%>').value = 0;
                document.getElementById('<%=ddlChequeBankNameLoan.ClientID%>').value = 0;
                document.getElementById('<%=txtChequeBankNameLoan.ClientID%>').value = "";
                document.getElementById('<%=txtChequeBranchNameLoan.ClientID%>').value = "";
                document.getElementById('<%=txtChequeAccNoLoan.ClientID%>').value = "";
                document.getElementById('<%=txtChequeIFSCLoan.ClientID%>').value = "";
                document.getElementById('<%=txtChequeDateLoan.ClientID%>').value = "";
                document.getElementById('<%=txtChequeAmountLoan.ClientID%>').value = "";
                document.getElementById('<%=fuChequeLoan.ClientID%>').value = "";
                document.getElementById('<%=txtNEFTBankNameLoan.ClientID%>').value = "";
                document.getElementById('<%=txtNEFTBranchNameLoan.ClientID%>').value = "";
                document.getElementById('<%=txtNEFTAccNoLoan.ClientID%>').value = "";
                document.getElementById('<%=txtNEFTIFSCLoan.ClientID%>').value = "";
                document.getElementById('<%=txtNEFTUTRLoan.ClientID%>').value = "";
                document.getElementById('<%=fuNEFTLoan.ClientID%>').value = "";
                document.getElementById('<%=txtChequeNoLoan.ClientID%>').value = "";
                document.getElementById('<%=ddlNEFTBankNameLoan.ClientID%>').value = 0;

                document.getElementById('<%=txtfuNEFTLoan.ClientID%>').value = "";
                document.getElementById('<%=txtfuChequeLoan.ClientID%>').value = "";
                document.getElementById('<%=txtfuNEFT1.ClientID%>').value = "";
            }
            if (document.getElementById('customRadioInline3').checked) {
                document.getElementById('<%=txtLoanBankName.ClientID%>').value = "";
                document.getElementById('<%=txtLoanAmount.ClientID%>').value = "";
                document.getElementById('<%=txtLoanMarginAmount.ClientID%>').value = "";
                document.getElementById('<%=ddlLoanMarginMode.ClientID%>').value = 0;
                document.getElementById('<%=ddlChequeBankNameLoan.ClientID%>').value = 0;
                document.getElementById('<%=txtChequeBankNameLoan.ClientID%>').value = "";
                document.getElementById('<%=txtChequeBranchNameLoan.ClientID%>').value = "";
                document.getElementById('<%=txtChequeAccNoLoan.ClientID%>').value = "";
                document.getElementById('<%=txtChequeIFSCLoan.ClientID%>').value = "";
                document.getElementById('<%=txtChequeDateLoan.ClientID%>').value = "";
                document.getElementById('<%=txtChequeAmountLoan.ClientID%>').value = "";
                document.getElementById('<%=fuChequeLoan.ClientID%>').value = "";
                document.getElementById('<%=txtNEFTBankNameLoan.ClientID%>').value = "";
                document.getElementById('<%=txtNEFTBranchNameLoan.ClientID%>').value = "";
                document.getElementById('<%=txtNEFTAccNoLoan.ClientID%>').value = "";
                document.getElementById('<%=txtNEFTIFSCLoan.ClientID%>').value = "";
                document.getElementById('<%=txtNEFTUTRLoan.ClientID%>').value = "";
                document.getElementById('<%=fuNEFTLoan.ClientID%>').value = "";
                document.getElementById('<%=txtChequeNoLoan.ClientID%>').value = "";
                document.getElementById('<%=ddlNEFTBankNameLoan.ClientID%>').value = 0;

                document.getElementById('<%=ddlChequeBankName.ClientID%>').value = 0;
                document.getElementById('<%=txtChequeBankName.ClientID%>').value = "";
                document.getElementById('<%=txtChequeBranchName.ClientID%>').value = "";
                document.getElementById('<%=txtChequeAccNo.ClientID%>').value = "";
                document.getElementById('<%=txtChequeIFSC.ClientID%>').value = "";
                document.getElementById('<%=txtChequeNo.ClientID%>').value = "";
                document.getElementById('<%=txtChequeDate.ClientID%>').value = "";
                document.getElementById('<%=txtChequeAmount.ClientID%>').value = "";
                document.getElementById('<%=fuCheque.ClientID%>').value = "";

                document.getElementById('<%=txtfuCheque.ClientID%>').value = "";
                document.getElementById('<%=txtfuNEFTLoan.ClientID%>').value = "";
                document.getElementById('<%=txtfuChequeLoan.ClientID%>').value = "";

            }
            if (document.getElementById('customRadioInline2').checked) {
                document.getElementById('<%=ddlNEFTBankName.ClientID%>').value = 0;
                document.getElementById('<%=txtChequeBankName.ClientID%>').value = "";
                document.getElementById('<%=txtNEFTBankName.ClientID%>').value = "";
                document.getElementById('<%=txtNEFTBranchName.ClientID%>').value = "";
                document.getElementById('<%=txtNEFTAccNo.ClientID%>').value = "";
                document.getElementById('<%=txtNEFTIFSC.ClientID%>').value = "";
                document.getElementById('<%=txtNEFTUTR.ClientID%>').value = "";
                document.getElementById('<%=fuNEFT1.ClientID%>').value = "";


                document.getElementById('<%=ddlChequeBankName.ClientID%>').value = 0;
                document.getElementById('<%=txtChequeBranchName.ClientID%>').value = "";
                document.getElementById('<%=txtChequeAccNo.ClientID%>').value = "";
                document.getElementById('<%=txtChequeIFSC.ClientID%>').value = "";
                document.getElementById('<%=txtChequeNo.ClientID%>').value = "";
                document.getElementById('<%=txtChequeDate.ClientID%>').value = "";
                document.getElementById('<%=txtChequeAmount.ClientID%>').value = "";
                document.getElementById('<%=fuCheque.ClientID%>').value = "";

                document.getElementById('<%=txtfuCheque.ClientID%>').value = "";
                document.getElementById('<%=txtfuNEFT1.ClientID%>').value = "";
            }
        };
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ScriptManager ID="script" runat="server"></asp:ScriptManager>
    <!-- Main Content -->
    <div class="main-content">
        <nav aria-label="breadcrumb">
            <ol class="breadcrumb">
                <li class="breadcrumb-item"><a href="employee-dashboard.aspx">Home</a></li>
                <li class="breadcrumb-item active" aria-current="page">Exercise</li>
            </ol>
        </nav>
        <asp:HiddenField ID="hdfield1" runat="server" />
        <section class="section">
            <div class="row">
                <div class="col-lg-12 col-md-12 col-12 col-sm-12">
                    <div class="card">
                        <div class="card-header">
                            <h4>Exercise</h4>
                        </div>
                        <div id="showmsg" style="text-align: center" runat="server">
                            <div class="container mb-2">
                                <asp:Label ID="lblmsg3" runat="server" class="text-left mr-1" Text=""></asp:Label>
                                <br />
                                <asp:Label ID="lblmsg4" runat="server" class="text-left mr-1" Text=""></asp:Label>
                                <br />
                                <asp:Label ID="lblmsg5" runat="server" class="text-left mr-1" Text=""></asp:Label>
                            </div>
                        </div>

                        <div class="card-body">
                            <fieldset>
                                <legend>Basic Information: </legend>
                                <asp:UpdatePanel ID="UpdatePanel2" runat="server" UpdateMode="Conditional">
                                    <ContentTemplate>
                                        <asp:GridView ID="gvExercise" runat="server" AutoGenerateColumns="False" ShowHeaderWhenEmpty="true"
                                            class="table1 table-borderless click" EmptyDataText="No Records Found" DataKeyNames="Vesting_DETAIL_ID,ecode, grant_id"
                                            OnRowDataBound="gvExercise_RowDataBound" Width="100%" Style="border-width: 0px; border-style: none; padding-left: 5px;" OnRowCreated="gvExercise_RowCreated">
                                            <Columns>
                                                <asp:TemplateField HeaderText="Tranch wise Vesting" HeaderStyle-Width="15%">
                                                    <ItemTemplate>
                                                        <div class="remark">
                                                            <asp:TextBox ID="txtTranchVesting" runat="server" Text='<%# Eval("Tranch_Vesting") %>' CssClass="form-control" Enabled="false"></asp:TextBox>
                                                            <asp:Label ID="lblTranchVesting" runat="server" Text='<%# Eval("Tranch_Vesting") %>'></asp:Label>
                                                        </div>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="No. of options Exercised" HeaderStyle-Width="15%">
                                                    <ItemTemplate>
                                                        <div class="remark" style="text-align: left;">
                                                            <asp:TextBox ID="txtTotOptions" runat="server" Text='<%# Eval("no_of_exercise") %>' CssClass="form-control"
                                                                Enabled="false"></asp:TextBox>
                                                            <asp:Label ID="lblTotOptions" runat="server" Text='<%# Eval("no_of_exercise") %>'></asp:Label>
                                                        </div>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="No. of Pending Exercise" HeaderStyle-Width="15%">
                                                    <ItemTemplate>
                                                        <div class="remark">
                                                            <asp:TextBox ID="txtOptionsPending" runat="server" Text='<%# Eval("pending_exercise") %>' CssClass="form-control"
                                                                Enabled="false"></asp:TextBox>
                                                            <asp:Label ID="lblOptionsPending" runat="server" Text='<%# Eval("pending_exercise") %>'></asp:Label>
                                                        </div>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Exer'sd ESOPs" HeaderStyle-Width="15%">
                                                    <ItemTemplate>
                                                        <div class="remark">
                                                            <asp:TextBox ID="txtNoofExcercise" runat="server" Text='<%# Eval("no_of_exercise") %>' CssClass="form-control"
                                                                Enabled="false"></asp:TextBox>
                                                            <asp:Label ID="lblNoofExercise" runat="server" Text='<%# Eval("no_of_exercise") %>'></asp:Label>
                                                        </div>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Pending Approval" HeaderStyle-Width="15%">
                                                    <ItemTemplate>
                                                        <div class="remark">
                                                            <asp:TextBox ID="TxtPendingAPP" runat="server" Text='<%# Eval("Pending_for_Approval") %>' CssClass="form-control"
                                                                Enabled="false"></asp:TextBox>
                                                            <asp:Label ID="lblPendingAPP" runat="server" Text='<%# Eval("Pending_for_Approval") %>'></asp:Label>
                                                        </div>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Grant Price" HeaderStyle-Width="15%">
                                                    <ItemTemplate>
                                                        <div class="remark">
                                                            <asp:TextBox ID="txtGrantPrice" runat="server" Text='<%# Eval("GRANT_PRICE") %>' CssClass="form-control"
                                                                Enabled="false"></asp:TextBox>
                                                            <asp:Label ID="lblGrantPrice" runat="server" Text='<%# Eval("GRANT_PRICE") %>'></asp:Label>
                                                        </div>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="FMV" HeaderStyle-Width="15%">
                                                    <ItemTemplate>
                                                        <div class="remark">
                                                            <asp:TextBox ID="txtFMV" runat="server" Text='<%# Eval("fmv_price") %>' CssClass="form-control"
                                                                Enabled="false"></asp:TextBox>
                                                            <asp:Label ID="lblFMV" runat="server" Text='<%# Eval("fmv_price") %>'></asp:Label>
                                                        </div>
                                                    </ItemTemplate>
                                                </asp:TemplateField>

                                                <asp:TemplateField HeaderText="Tran wise ESOP's" HeaderStyle-Width="15%">
                                                    <ItemTemplate>
                                                        <div class="remark" style="text-align: center;">
                                                            <asp:TextBox ID="txtOptions" runat="server" Text='<%# Eval("no_of_vesting") %>' CssClass="form-control"
                                                                Enabled="false"></asp:TextBox>
                                                            <asp:Label ID="lblOptions" runat="server" Text='<%# Eval("no_of_vesting") %>'></asp:Label>
                                                        </div>
                                                    </ItemTemplate>
                                                </asp:TemplateField>

                                                <asp:TemplateField HeaderText="ESOP's for Exercise" HeaderStyle-Width="15%">
                                                    <ItemTemplate>
                                                        <div class="remark" style="text-align: left;">
                                                            <asp:HiddenField ID="hdnlapsedate" runat="server" Value='<%# Eval("Lapse_Date_new") %>'></asp:HiddenField>
                                                            <asp:TextBox ID="txtOptionsExercised" runat="server" CssClass="form-control" OnTextChanged="txtOptionsExercised_TextChanged"
                                                                AutoPostBack="true" onkeypress="return isNumberKey(this,event)" Text='<%# Eval("no_of_option_exercise") %>'></asp:TextBox>
                                                            <asp:Label ID="lblOptionsExercised" runat="server" Text='<%# Eval("no_of_option_exercise") %>'></asp:Label>
                                                        </div>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                            </Columns>
                                        </asp:GridView>
                                    </ContentTemplate>
                                </asp:UpdatePanel>
                                <div class="row" style="margin-top: 15px;">
                                    <div class="table-responsive">
                                        <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional">
                                            <ContentTemplate>
                                                <asp:GridView ID="gvExerciseCal" runat="server" AutoGenerateColumns="False" ShowHeaderWhenEmpty="true"
                                                    class="table table-borderless click" EmptyDataText="No Records Found" DataKeyNames="Vesting_DETAIL_ID"
                                                    OnRowDataBound="gvExerciseCal_RowDataBound">
                                                    <Columns>
                                                        <%--<asp:BoundField DataField="Tranch_Vesting" HeaderText="Vesting Cycle" HeaderStyle-Width="10%" />--%>
                                                        <asp:TemplateField HeaderText="Vesting Cycle" HeaderStyle-Font-Bold="true" FooterStyle-Font-Bold="true" HeaderStyle-Width="10%">
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblVesting_Cycle" runat="server" Text='<%#Eval("Tranch_Vesting") %>' />
                                                            </ItemTemplate>
                                                        </asp:TemplateField>

                                                        <%--<asp:BoundField DataField="Exercise_Consideration" HeaderText="Exercise Consideration" HeaderStyle-Width="12%" />--%>
                                                        <asp:TemplateField HeaderText="Exercise Consideration" HeaderStyle-Font-Bold="true" FooterStyle-Font-Bold="true" HeaderStyle-Width="10%">
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblExercise_Consideration" runat="server" Text='<%#Eval("Exercise_Consideration") %>' />
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:BoundField DataField="taxable_income" HeaderText="Current Taxable Income" HeaderStyle-Width="13%" />
                                                        <%--Rename (FMV-Grant price)*Options Exercised as Prequre Value by Pallavi on 01/03/2022--%>
                                                        <asp:BoundField DataField="FMV_Grant_Option__Exercise" HeaderText="Prequre Value" HeaderStyle-Width="20%" />
                                                        <asp:BoundField DataField="Revised_Taxable_Income" HeaderText="Revised Taxable Income" HeaderStyle-Width="12%" Visible="false" />
                                                        <%--Rename Tax Per Option as Tax Slab by Pallavi on 01/03/2022--%>
                                                        <asp:BoundField DataField="Tax_Per_Option" HeaderText="Tax Slab" HeaderStyle-Width="8%" Visible="false" />
                                                        <%--<asp:BoundField DataField="Perq_Tax_Amount" HeaderText="Perq Tax Amount" />
														<asp:BoundField DataField="Total_Amount" HeaderText="Total Amount" />--%>
                                                        <asp:TemplateField HeaderText="Perq Tax Amount" HeaderStyle-Font-Bold="true" FooterStyle-Font-Bold="true" HeaderStyle-Width="10%">
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblPerq_Tax_Amount" runat="server" Text='<%#Eval("Perq_Tax_Amount") %>' />
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Total Amount(₹)" HeaderStyle-Font-Bold="true" FooterStyle-Font-Bold="true" HeaderStyle-Width="15%">
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblTotal_Amount" runat="server" Text='<%#Eval("Total_Amount") %>' />
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                    </Columns>
                                                </asp:GridView>
                                            </ContentTemplate>
                                            <Triggers>
                                                <asp:AsyncPostBackTrigger ControlID="gvExercise" />
                                            </Triggers>
                                        </asp:UpdatePanel>
                                    </div>
                                    <div class="col-lg-12 col-md-12 col-sm-12 offset-lg-5">
                                        <asp:Button ID="btnSubmit" type="button" runat="server" Style="margin-bottom: 30px" class="btn btn-info btn-lg" Text="Submit" OnClick="btnSubmit_Click"></asp:Button>
                                    </div>

                                    <div class="col-lg-6 col-md-12 col-sm-12">
                                        <div class="form-group">
                                            <div class="section-title" style="margin-bottom: 15px;">Payment Mode</div>
                                            <div class="col-lg-3">
                                                <div class="custom-control custom-radio custom-control-inline" style="margin-bottom: 15px;">

                                                    <input type="radio" id="customRadioInline4" name="customRadioInline3" class="custom-control-input" value="Cheque" onclick="Clear();" />
                                                    <%--<%= this.inputtypeCheque %>--%>
                                                    <label class="custom-control-label" for="customRadioInline4">Cheque</label>
                                                </div>
                                            </div>
                                            <div class="col-lg-5 custom-control custom-radio custom-control-inline">
                                                <input type="radio" id="customRadioInline3" name="customRadioInline3" class="custom-control-input" value="neft" onclick="Clear();" />
                                                <%--= this.inputtypeNEFT--%>
                                                <label class="custom-control-label" for="customRadioInline3">NEFT (Bank Transfer)</label>
                                            </div>
                                            <div class="col-lg-3 custom-control custom-radio custom-control-inline">
                                                <input type="radio" id="customRadioInline2" name="customRadioInline3" class="custom-control-input" value="loan" onclick="Clear();" />
                                                <%--<%= this.inputtypeLoan %>--%>
                                                <label class="custom-control-label" for="customRadioInline2">Loan</label>
                                            </div>
                                        </div>
                                    </div>

                                    <div class="col-lg-6 col-md-12 col-sm-12">
                                        <div class="col-lg-12 col-md-12 col-sm-12">
                                            <div class="form-group mt-4 pt-2">
                                                <asp:Button ID="btnmsg1" type="button" runat="server" class="btn btn-info btn-lg" Text="Bank Details" data-toggle="modal" data-target="#modalbankdetails"></asp:Button>
                                                <asp:Label ID="lblmsg1" runat="server" class="text-left mr-1" Text=""></asp:Label>
                                            </div>
                                        </div>
                                    </div>
                                    <!--Cheque Options-->
                                    <div class="col-lg-3 col-md-12 col-sm-12 Cheque">
                                        <div class="form-group">
                                            <label>Bank acc Details</label>
                                            <label style="color: red">*</label>
                                            <div class="input-group mb-3">
                                                <asp:UpdatePanel ID="Updatepanel5" runat="server">
                                                    <ContentTemplate>
                                                        <asp:DropDownList ID="ddlChequeBankName" runat="server" CssClass="form-control" AutoPostBack="true"
                                                            OnSelectedIndexChanged="ddlChequeBankName_SelectedIndexChanged">
                                                            <%--onchange="dropchange()"--%>
                                                        </asp:DropDownList>
                                                        <asp:RequiredFieldValidator ID="rfvddlChequeBankName" runat="server"
                                                            ErrorMessage="Please select Bank" ControlToValidate="ddlChequeBankName" ValidationGroup="Add" ForeColor="Red" InitialValue="0"
                                                            Display="None" CssClass="validation" SetFocusOnError="true"></asp:RequiredFieldValidator>
                                                    </ContentTemplate>
                                                </asp:UpdatePanel>
                                            </div>
                                        </div>
                                    </div>

                                    <div class="col-lg-9 col-md-12 col-sm-12 Cheque">
                                    </div>

                                    <div class="col-lg-3 col-md-12 col-sm-12 Cheque">
                                        <div class="form-group">
                                            <label>Bank Name</label>
                                            <label style="color: red">*</label>
                                            <asp:UpdatePanel ID="Updatepanel6" runat="server">
                                                <ContentTemplate>
                                                    <%--<input type="text" class="form-control">--%>
                                                    <asp:TextBox ID="txtChequeBankName" runat="server" CssClass="form-control" MaxLength="50" Enabled="false"></asp:TextBox>
                                                    <asp:RequiredFieldValidator ID="rfvtxtChequeBankName" runat="server"
                                                        ErrorMessage="Bank Name is required" ControlToValidate="txtChequeBankName" ValidationGroup="Add" ForeColor="Red"
                                                        Display="None" CssClass="validation" SetFocusOnError="true"></asp:RequiredFieldValidator>
                                                </ContentTemplate>
                                                <Triggers>
                                                    <asp:AsyncPostBackTrigger ControlID="ddlChequeBankName" />
                                                </Triggers>
                                            </asp:UpdatePanel>
                                        </div>
                                    </div>
                                    <div class="col-lg-3 col-md-12 col-sm-12 Cheque">
                                        <div class="form-group">
                                            <label>Branch Name</label>
                                            <label style="color: red">*</label>
                                            <asp:UpdatePanel ID="Updatepanel7" runat="server">
                                                <ContentTemplate>
                                                    <%--<input type="text" class="form-control">--%>
                                                    <asp:TextBox ID="txtChequeBranchName" runat="server" CssClass="form-control" MaxLength="50" Enabled="false"></asp:TextBox>
                                                    <asp:RequiredFieldValidator ID="rfvtxtChequeBranchName" runat="server"
                                                        ErrorMessage="Branch Name is required" ControlToValidate="txtChequeBranchName" ValidationGroup="Add" ForeColor="Red"
                                                        Display="None" CssClass="validation" SetFocusOnError="true"></asp:RequiredFieldValidator>
                                                </ContentTemplate>
                                                <Triggers>
                                                    <asp:AsyncPostBackTrigger ControlID="ddlChequeBankName" />
                                                </Triggers>
                                            </asp:UpdatePanel>
                                        </div>
                                    </div>
                                    <div class="col-lg-3 col-md-12 col-sm-12 Cheque">
                                        <div class="form-group">
                                            <label>Account Number</label>
                                            <label style="color: red">*</label>
                                            <asp:UpdatePanel ID="Updatepanel19" runat="server">
                                                <ContentTemplate>
                                                    <%--<input type="text" class="form-control">--%>
                                                    <asp:TextBox ID="txtChequeAccNo" runat="server" CssClass="form-control" MaxLength="25" Enabled="false"></asp:TextBox>
                                                    <asp:RequiredFieldValidator ID="rfvtxtChequeAccNo" runat="server"
                                                        ErrorMessage="Account Number is required" ControlToValidate="txtChequeAccNo" ValidationGroup="Add" ForeColor="Red"
                                                        Display="None" CssClass="validation" SetFocusOnError="true"></asp:RequiredFieldValidator>
                                                </ContentTemplate>
                                                <Triggers>
                                                    <asp:AsyncPostBackTrigger ControlID="ddlChequeBankName" />
                                                </Triggers>
                                            </asp:UpdatePanel>
                                        </div>
                                    </div>
                                    <div class="col-lg-3 col-md-12 col-sm-12 Cheque">
                                        <div class="form-group">
                                            <label>IFSC Code</label>
                                            <label style="color: red">*</label>
                                            <asp:UpdatePanel ID="Updatepanel8" runat="server">
                                                <ContentTemplate>
                                                    <%--<input type="text" class="form-control">--%>
                                                    <asp:TextBox ID="txtChequeIFSC" runat="server" CssClass="form-control" MaxLength="20" Enabled="false"></asp:TextBox>
                                                    <asp:RequiredFieldValidator ID="rfvtxtChequeIFSC" runat="server"
                                                        ErrorMessage="IFSC Code is required" ControlToValidate="txtChequeIFSC" ValidationGroup="Add" ForeColor="Red"
                                                        Display="None" CssClass="validation" SetFocusOnError="true"></asp:RequiredFieldValidator>
                                                </ContentTemplate>
                                                <Triggers>
                                                    <asp:AsyncPostBackTrigger ControlID="ddlChequeBankName" />
                                                </Triggers>
                                            </asp:UpdatePanel>
                                        </div>
                                    </div>

                                    <div class="col-lg-3 col-md-12 col-sm-12 Cheque">
                                        <div class="form-group">
                                            <label>Cheque Number</label>
                                            <label style="color: red">*</label>
                                            <%--<input type="text" class="form-control">--%>
                                            <asp:TextBox ID="txtChequeNo" runat="server" CssClass="form-control" MaxLength="15" onkeypress="return isNumberKey1(event)"></asp:TextBox>
                                            <asp:RequiredFieldValidator ID="rfvtxtChequeNo" runat="server"
                                                ErrorMessage="Cheque Number is required" ControlToValidate="txtChequeNo" ValidationGroup="Add" ForeColor="Red"
                                                Display="None" CssClass="validation" SetFocusOnError="true" onkeypress="return isNumberKey(this,event)"></asp:RequiredFieldValidator>
                                        </div>
                                    </div>
                                    <div class="col-lg-3 col-md-12 col-sm-12 Cheque">
                                        <div class="form-group">
                                            <label>Cheque Date</label>
                                            <label style="color: red">*</label>
                                            <%--<input type="text" class="form-control datepicker">--%>
                                            <asp:TextBox ID="txtChequeDate" runat="server" CssClass="form-control" Placeholder="dd-mm-yyyy" autocomplete="off"></asp:TextBox>
                                            <asp:RequiredFieldValidator ID="rfvtxtChequeDate" runat="server"
                                                ErrorMessage="Cheque Date is required" ControlToValidate="txtChequeDate" ValidationGroup="Add" ForeColor="Red"
                                                Display="None" CssClass="validation"></asp:RequiredFieldValidator>
                                            <%--SetFocusOnError="true"--%>
                                        </div>
                                    </div>
                                    <div class="col-lg-3 col-md-12 col-sm-12 Cheque">
                                        <div class="form-group">
                                            <label>Cheque Amount(₹)</label>
                                            <label style="color: red">*</label>
                                            <%--<input type="text" class="form-control">--%>
                                            <asp:UpdatePanel ID="Updatepanel40" runat="server">
                                                <ContentTemplate>
                                                    <asp:TextBox ID="txtChequeAmount" runat="server" CssClass="form-control" MaxLength="12" onkeypress="return isNumberKey(this,event)" ReadOnly="true"></asp:TextBox>
                                                    <asp:RequiredFieldValidator ID="rfvtxtChequeAmount" runat="server"
                                                        ErrorMessage="Cheque Amount is required" ControlToValidate="txtChequeAmount" ValidationGroup="Add" ForeColor="Red"
                                                        Display="None" CssClass="validation" SetFocusOnError="true"></asp:RequiredFieldValidator>
                                                </ContentTemplate>
                                                <Triggers>
                                                    <asp:AsyncPostBackTrigger ControlID="gvExercise" />
                                                </Triggers>
                                            </asp:UpdatePanel>
                                        </div>
                                    </div>
                                    <div class="col-lg-3 col-md-12 col-sm-12 Cheque">
                                        <asp:UpdatePanel ID="Updatepanel41" runat="server">
                                            <ContentTemplate>
                                                <div class="form-group">
                                                    <label>Upload Fresh Cheque Screenshot</label>
                                                    <label style="color: red">*</label>
                                                    <%--<input type="file" class="form-control">--%>

                                                    <cc1:AsyncFileUpload runat="server" ID="fuCheque" Width="100%" UploaderStyle="Traditional" CompleteBackColor="White"
                                                        UploadingBackColor="#CCFFFF" ThrobberID="imgLoader" OnUploadedComplete="fuCheque_UploadedComplete" CssClass="form-control"
                                                        OnClientUploadComplete="uploadComplete1" OnClientUploadStarted="uploadStart" OnClientUploadError="uploadError"
                                                        ErrorBackColor="Transparent"></cc1:AsyncFileUpload>
                                                </div>
                                            </ContentTemplate>
                                            <Triggers>
                                                <asp:PostBackTrigger ControlID="fuCheque" />
                                            </Triggers>
                                        </asp:UpdatePanel>

                                        <asp:TextBox ID="txtfuCheque" runat="server" Style="display: none"></asp:TextBox>
                                        <asp:TextBox ID="txtErr" runat="server" Style="display: none"></asp:TextBox>
                                        <%----%>
                                        <asp:RequiredFieldValidator ID="rfvtxtfuCheque" runat="server"
                                            ErrorMessage="Upload Fresh Cheque Screenshot" ControlToValidate="txtfuCheque" ValidationGroup="Add" ForeColor="Red"
                                            Display="None" CssClass="validation" SetFocusOnError="true"></asp:RequiredFieldValidator>
                                    </div>

                                    <div class="col-lg-3 col-md-12 col-sn-12 form-group filter hdpe Cheque" style="padding-left: 35px;">
                                        <label>Fresh Cheque Screenshot:</label>
                                        <div class="letterview" style="width: 130px; display: none;" id="divCheque">
                                            <figure class="snip0013">
                                                <img src="assets/img/Cancelled-Cheque.jpg" width="130">
                                                <a href="img/doc.doc" download="">
                                                    <asp:UpdatePanel ID="Updatepanel23" runat="server">
                                                        <ContentTemplate>
                                                            <asp:LinkButton ID="lnkChequeDownloadFresh" runat="server" Text="Download" OnClick="lnkChequeDownloadFresh_Click">
																<p><i class="fas fa-download"></i>Download</p>
                                                            </asp:LinkButton>
                                                        </ContentTemplate>
                                                        <Triggers>
                                                            <asp:PostBackTrigger ControlID="lnkChequeDownloadFresh" />
                                                        </Triggers>
                                                    </asp:UpdatePanel>
                                                </a>
                                            </figure>
                                        </div>
                                    </div>
                                    <!--Cheque Ends-->
                                    <!--NEFT options-->
                                    <div class="col-lg-3 col-md-12 col-sm-12 neft">
                                        <div class="form-group">
                                            <label>Bank acc Details</label>
                                            <label style="color: red">*</label>
                                            <div class="input-group mb-3">
                                                <asp:UpdatePanel ID="Updatepanel9" runat="server">
                                                    <ContentTemplate>
                                                        <asp:DropDownList ID="ddlNEFTBankName" runat="server" CssClass="form-control" AutoPostBack="true"
                                                            OnSelectedIndexChanged="ddlNEFTBankName_SelectedIndexChanged">
                                                        </asp:DropDownList>
                                                        <asp:RequiredFieldValidator ID="rfvddlNEFTBankName" runat="server"
                                                            ErrorMessage="Please select Bank" ControlToValidate="ddlNEFTBankName" ValidationGroup="Add" ForeColor="Red" InitialValue="0"
                                                            Display="None" CssClass="validation" SetFocusOnError="true"></asp:RequiredFieldValidator>
                                                    </ContentTemplate>
                                                </asp:UpdatePanel>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="col-lg-9 col-md-12 col-sm-12 neft">
                                    </div>

                                    <div class="col-lg-3 col-md-12 col-sm-12 neft">
                                        <div class="form-group">
                                            <label>Bank Name</label>
                                            <label style="color: red">*</label>
                                            <asp:UpdatePanel ID="Updatepanel10" runat="server">
                                                <ContentTemplate>
                                                    <%--<input type="text" class="form-control">--%>
                                                    <asp:TextBox ID="txtNEFTBankName" runat="server" CssClass="form-control" MaxLength="50" Enabled="false"></asp:TextBox>
                                                    <asp:RequiredFieldValidator ID="rfvtxtNEFTBankName" runat="server"
                                                        ErrorMessage="Bank Name is required" ControlToValidate="txtNEFTBankName" ValidationGroup="Add" ForeColor="Red"
                                                        Display="None" CssClass="validation" SetFocusOnError="true"></asp:RequiredFieldValidator>
                                                </ContentTemplate>
                                                <Triggers>
                                                    <asp:AsyncPostBackTrigger ControlID="ddlNEFTBankName" />
                                                </Triggers>
                                            </asp:UpdatePanel>
                                        </div>
                                    </div>
                                    <div class="col-lg-3 col-md-12 col-sm-12 neft">
                                        <div class="form-group">
                                            <label>Branch Name</label>
                                            <label style="color: red">*</label>
                                            <asp:UpdatePanel ID="Updatepanel11" runat="server">
                                                <ContentTemplate>
                                                    <%--<input type="text" class="form-control">--%>
                                                    <asp:TextBox ID="txtNEFTBranchName" runat="server" CssClass="form-control" MaxLength="50" Enabled="false"></asp:TextBox>
                                                    <asp:RequiredFieldValidator ID="rfvtxtNEFTBranchName" runat="server"
                                                        ErrorMessage="Branch Name is required" ControlToValidate="txtNEFTBranchName" ValidationGroup="Add" ForeColor="Red"
                                                        Display="None" CssClass="validation" SetFocusOnError="true"></asp:RequiredFieldValidator>
                                                </ContentTemplate>
                                                <Triggers>
                                                    <asp:AsyncPostBackTrigger ControlID="ddlNEFTBankName" />
                                                </Triggers>
                                            </asp:UpdatePanel>
                                        </div>
                                    </div>
                                    <div class="col-lg-3 col-md-12 col-sm-12 neft">
                                        <div class="form-group">
                                            <label>Account Number</label>
                                            <label style="color: red">*</label>
                                            <asp:UpdatePanel ID="Updatepanel12" runat="server">
                                                <ContentTemplate>
                                                    <%--<input type="text" class="form-control">--%>
                                                    <asp:TextBox ID="txtNEFTAccNo" runat="server" CssClass="form-control" MaxLength="25" Enabled="false"></asp:TextBox>
                                                    <asp:RequiredFieldValidator ID="rfvtxtNEFTAccNo" runat="server"
                                                        ErrorMessage="Account Number is required" ControlToValidate="txtNEFTAccNo" ValidationGroup="Add" ForeColor="Red"
                                                        Display="None" CssClass="validation" SetFocusOnError="true"></asp:RequiredFieldValidator>
                                                </ContentTemplate>
                                                <Triggers>
                                                    <asp:AsyncPostBackTrigger ControlID="ddlNEFTBankName" />
                                                </Triggers>
                                            </asp:UpdatePanel>
                                        </div>
                                    </div>
                                    <div class="col-lg-3 col-md-12 col-sm-12 neft">
                                        <div class="form-group">
                                            <label>IFSC Code</label>
                                            <label style="color: red">*</label>
                                            <asp:UpdatePanel ID="Updatepanel13" runat="server">
                                                <ContentTemplate>
                                                    <%--<input type="text" class="form-control">--%>
                                                    <asp:TextBox ID="txtNEFTIFSC" runat="server" CssClass="form-control" MaxLength="20" Enabled="false"></asp:TextBox>
                                                    <asp:RequiredFieldValidator ID="rfvtxtNEFTIFSC" runat="server"
                                                        ErrorMessage="IFSC Code is required" ControlToValidate="txtNEFTIFSC" ValidationGroup="Add" ForeColor="Red"
                                                        Display="None" CssClass="validation" SetFocusOnError="true"></asp:RequiredFieldValidator>
                                                </ContentTemplate>
                                                <Triggers>
                                                    <asp:AsyncPostBackTrigger ControlID="ddlNEFTBankName" />
                                                </Triggers>
                                            </asp:UpdatePanel>
                                        </div>
                                    </div>
                                    <div class="col-lg-3 col-md-12 col-sm-12 neft">
                                        <div class="form-group">
                                            <label>UTR / Transfer Reference Number</label>
                                            <label style="color: red">*</label>
                                            <%--<input type="text" class="form-control">--%>
                                            <asp:TextBox ID="txtNEFTUTR" runat="server" CssClass="form-control" MaxLength="25"></asp:TextBox>
                                            <asp:RequiredFieldValidator ID="rfvtxtNEFTUTR" runat="server"
                                                ErrorMessage="UTR / Transfer Reference Number is required" ControlToValidate="txtNEFTUTR" ValidationGroup="Add" ForeColor="Red"
                                                Display="None" CssClass="validation" SetFocusOnError="true"></asp:RequiredFieldValidator>
                                        </div>
                                    </div>
                                    <div class="col-lg-3 col-md-12 col-sm-12 neft">
                                        <div class="form-group">
                                            <label>Upload Transaction Screenshot</label>
                                            <label style="color: red">*</label>

                                            <cc1:AsyncFileUpload runat="server" ID="fuNEFT1" Width="100%" UploaderStyle="Traditional" CompleteBackColor="White"
                                                UploadingBackColor="#CCFFFF" ThrobberID="imgLoader" OnUploadedComplete="fuNEFT1_UploadedComplete" CssClass="form-control"
                                                OnClientUploadComplete="uploadComplete" OnClientUploadStarted="uploadStart" OnClientUploadError="uploadError"
                                                ErrorBackColor="Transparent"></cc1:AsyncFileUpload>

                                        </div>
                                        <asp:TextBox ID="txtfuNEFT1" runat="server" Style="display: none"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="rfvtxtfuNEFT1" runat="server"
                                            ErrorMessage="Upload Transaction Screenshot" ControlToValidate="txtfuNEFT1" ValidationGroup="Add" ForeColor="Red"
                                            Display="None" CssClass="validation" SetFocusOnError="true"></asp:RequiredFieldValidator>
                                    </div>
                                    <div class="col-lg-3 col-md-12 col-sn-12 form-group filter hdpe neft" style="padding-left: 35px;">
                                        <label>Transaction Screenshot</label>
                                        <div class="letterview" style="width: 130px; display: none;" id="divNEFT">
                                            <figure class="snip0013">
                                                <img src="assets/img/Error.png" width="130">
                                                <a href="img/doc.doc" download="">
                                                    <asp:UpdatePanel ID="Updatepanel21" runat="server">
                                                        <ContentTemplate>
                                                            <asp:LinkButton ID="lnkNEFTDownload" runat="server" Text="Download" OnClick="lnkNEFTDownload_Click">
																<p><i class="fas fa-download"></i>Download</p>
                                                            </asp:LinkButton>
                                                        </ContentTemplate>
                                                        <Triggers>
                                                            <asp:PostBackTrigger ControlID="lnkNEFTDownload" />
                                                        </Triggers>
                                                    </asp:UpdatePanel>
                                                </a>
                                            </figure>
                                        </div>
                                    </div>
                                </div>
                                <!--NEFT Ends-->
                                <!--Loan Options-->
                                <div class="col-lg-3 col-md-12 col-sm-12 loan">
                                    <div class="form-group">
                                        <label>Lender Bank Name</label>
                                        <label style="color: red">*</label>
                                        <%--<input type="text" class="form-control">--%>
                                        <asp:TextBox ID="txtLoanBankName" runat="server" CssClass="form-control" MaxLength="50"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="rfvtxtLoanBankName" runat="server"
                                            ErrorMessage="Lender Bank Name is required" ControlToValidate="txtLoanBankName" ValidationGroup="Add" ForeColor="Red"
                                            Display="None" CssClass="validation" SetFocusOnError="true"></asp:RequiredFieldValidator>
                                    </div>
                                </div>
                                <div class="col-lg-3 col-md-12 col-sm-12 loan">
                                    <div class="form-group">
                                        <label>Loan Amount(₹) </label>
                                        <label style="color: red">*</label>
                                        <%--<input type="text" class="form-control">--%>
                                        <asp:UpdatePanel ID="UpdatePanel24" runat="server">
                                            <ContentTemplate>

                                                <asp:TextBox ID="txtLoanAmount" runat="server" CssClass="form-control" MaxLength="12" onkeypress="return isNumberKey(this,event)" OnTextChanged="txtLoanAmount_TextChanged" AutoPostBack="true"></asp:TextBox>
                                                <asp:RequiredFieldValidator ID="rfvtxtLoanAmount" runat="server"
                                                    ErrorMessage="Loan Amount is required" ControlToValidate="txtLoanAmount" ValidationGroup="Add" ForeColor="Red"
                                                    Display="None" CssClass="validation"></asp:RequiredFieldValidator>
                                                <%--SetFocusOnError="true"--%>
                                            </ContentTemplate>
                                            <Triggers>
                                                <asp:AsyncPostBackTrigger ControlID="txtLoanAmount" />
                                            </Triggers>
                                        </asp:UpdatePanel>
                                    </div>
                                </div>
                                <div class="col-lg-3 col-md-12 col-sm-12 loan">
                                    <div class="form-group">
                                        <label>Margin Money Amount(₹)</label>
                                        <label style="color: red">*</label>
                                        <%--<input type="text" class="form-control">--%>
                                        <asp:UpdatePanel ID="upd" runat="server">
                                            <ContentTemplate>
                                                <asp:TextBox ID="txtLoanMarginAmount" runat="server" CssClass="form-control" MaxLength="12" onkeypress="return isNumberKey(this,event)" OnTextChanged="txtLoanMarginAmount_TextChanged" AutoPostBack="true"></asp:TextBox>
                                                <asp:RequiredFieldValidator ID="rfvtxtLoanMarginAmount" runat="server"
                                                    ErrorMessage="Margin Money Amount is required" ControlToValidate="txtLoanMarginAmount" ValidationGroup="Add" ForeColor="Red"
                                                    Display="None" CssClass="validation" SetFocusOnError="true"></asp:RequiredFieldValidator>
                                            </ContentTemplate>
                                            <Triggers>
                                                <asp:AsyncPostBackTrigger ControlID="txtLoanMarginAmount" />
                                            </Triggers>
                                        </asp:UpdatePanel>
                                    </div>
                                </div>
                                <div class="col-lg-3 col-md-12 col-sm-12 loan">
                                    <div class="form-group">
                                        <label>Margin Money Payment Mode</label>
                                        <label style="color: red">*</label>
                                        <div class="input-group mb-3">
                                            <%--<select class="form-control">
													<option>Cheque</option>
													<option>NEFT</option>
												</select>--%>
                                            <asp:UpdatePanel ID="Updatepanel38" runat="server">
                                                <ContentTemplate>
                                                    <asp:DropDownList ID="ddlLoanMarginMode" runat="server" CssClass="form-control" onchange="dropchange()" OnSelectedIndexChanged="ddlLoanMarginMode_SelectedIndexChanged" AutoPostBack="true">
                                                        <asp:ListItem Value="0">Select Payment Mode</asp:ListItem>
                                                        <asp:ListItem Value="Cheque">Cheque</asp:ListItem>
                                                        <asp:ListItem Value="NEFT">NEFT</asp:ListItem>
                                                    </asp:DropDownList>
                                                </ContentTemplate>
                                            </asp:UpdatePanel>
                                            <asp:RequiredFieldValidator ID="rfvddlLoanMarginMode" runat="server"
                                                ErrorMessage="Please select Payment Mode" ControlToValidate="ddlLoanMarginMode" ValidationGroup="Add" ForeColor="Red" InitialValue="0"
                                                Display="None" CssClass="validation" SetFocusOnError="true"></asp:RequiredFieldValidator>
                                        </div>
                                    </div>
                                </div>
                                <!--Loan Ends-->
                                <!--Loan Cheque Start---------------------------------------------------->

                                <div class="col-lg-3 col-md-12 col-sm-12 Loan_Cheque">
                                    <div class="form-group">
                                        <label>Bank acc Details</label>
                                        <label style="color: red">*</label>
                                        <div class="input-group mb-3">
                                            <asp:UpdatePanel ID="Updatepanel25" runat="server">
                                                <ContentTemplate>
                                                    <asp:DropDownList ID="ddlChequeBankNameLoan" runat="server" CssClass="form-control" AutoPostBack="true"
                                                        OnSelectedIndexChanged="ddlChequeBankNameLoan_SelectedIndexChanged">
                                                        <%-- onchange="dropchange()"--%>
                                                    </asp:DropDownList>
                                                    <asp:RequiredFieldValidator ID="rfvddlChequeBankNameLoan" runat="server"
                                                        ErrorMessage="Please select Bank" ControlToValidate="ddlChequeBankNameLoan" ValidationGroup="Add" ForeColor="Red" InitialValue="0"
                                                        Display="None" CssClass="validation" SetFocusOnError="true"></asp:RequiredFieldValidator>
                                                </ContentTemplate>
                                            </asp:UpdatePanel>
                                        </div>
                                    </div>
                                </div>
                                <div class="clearfix Loan_Cheque"></div>

                                <div class="col-lg-3 col-md-12 col-sm-12 Loan_Cheque">
                                    <div class="form-group">
                                        <label>Bank Name</label>
                                        <label style="color: red">*</label>
                                        <asp:UpdatePanel ID="Updatepanel26" runat="server">
                                            <ContentTemplate>
                                                <%--<input type="text" class="form-control">--%>
                                                <asp:TextBox ID="txtChequeBankNameLoan" runat="server" CssClass="form-control" MaxLength="50" Enabled="false"></asp:TextBox>
                                                <asp:RequiredFieldValidator ID="rfvtxtChequeBankNameLoan" runat="server"
                                                    ErrorMessage="Bank Name is required" ControlToValidate="txtChequeBankNameLoan" ValidationGroup="Add" ForeColor="Red"
                                                    Display="None" CssClass="validation" SetFocusOnError="true"></asp:RequiredFieldValidator>
                                            </ContentTemplate>
                                            <Triggers>
                                                <asp:AsyncPostBackTrigger ControlID="ddlChequeBankNameLoan" />
                                            </Triggers>
                                        </asp:UpdatePanel>
                                    </div>
                                </div>
                                <div class="col-lg-3 col-md-12 col-sm-12 Loan_Cheque">
                                    <div class="form-group">
                                        <label>Branch Name</label>
                                        <label style="color: red">*</label>
                                        <asp:UpdatePanel ID="Updatepanel27" runat="server">
                                            <ContentTemplate>
                                                <%--<input type="text" class="form-control">--%>
                                                <asp:TextBox ID="txtChequeBranchNameLoan" runat="server" CssClass="form-control" MaxLength="50" Enabled="false"></asp:TextBox>
                                                <asp:RequiredFieldValidator ID="rfvtxtChequeBranchNameLoan" runat="server"
                                                    ErrorMessage="Branch Name is required" ControlToValidate="txtChequeBranchNameLoan" ValidationGroup="Add" ForeColor="Red"
                                                    Display="None" CssClass="validation" SetFocusOnError="true"></asp:RequiredFieldValidator>
                                            </ContentTemplate>
                                            <Triggers>
                                                <asp:AsyncPostBackTrigger ControlID="ddlChequeBankNameLoan" />
                                            </Triggers>
                                        </asp:UpdatePanel>
                                    </div>
                                </div>
                                <div class="col-lg-3 col-md-12 col-sm-12 Loan_Cheque">
                                    <div class="form-group">
                                        <label>Account Number</label>
                                        <label style="color: red">*</label>
                                        <asp:UpdatePanel ID="Updatepanel28" runat="server">
                                            <ContentTemplate>
                                                <%--<input type="text" class="form-control">--%>
                                                <asp:TextBox ID="txtChequeAccNoLoan" runat="server" CssClass="form-control" MaxLength="25" Enabled="false"></asp:TextBox>
                                                <asp:RequiredFieldValidator ID="rfvtxtChequeAccNoLoan" runat="server"
                                                    ErrorMessage="Account Number is required" ControlToValidate="txtChequeAccNoLoan" ValidationGroup="Add" ForeColor="Red"
                                                    Display="None" CssClass="validation" SetFocusOnError="true"></asp:RequiredFieldValidator>
                                            </ContentTemplate>
                                            <Triggers>
                                                <asp:AsyncPostBackTrigger ControlID="ddlChequeBankNameLoan" />
                                            </Triggers>
                                        </asp:UpdatePanel>
                                    </div>
                                </div>
                                <div class="col-lg-3 col-md-12 col-sm-12 Loan_Cheque">
                                    <div class="form-group">
                                        <label>IFSC Code</label>
                                        <label style="color: red">*</label>
                                        <asp:UpdatePanel ID="Updatepanel29" runat="server">
                                            <ContentTemplate>
                                                <%--<input type="text" class="form-control">--%>
                                                <asp:TextBox ID="txtChequeIFSCLoan" runat="server" CssClass="form-control" MaxLength="20" Enabled="false"></asp:TextBox>
                                                <asp:RequiredFieldValidator ID="rfvtxtChequeIFSCLoan" runat="server"
                                                    ErrorMessage="IFSC Code is required" ControlToValidate="txtChequeIFSCLoan" ValidationGroup="Add" ForeColor="Red"
                                                    Display="None" CssClass="validation" SetFocusOnError="true"></asp:RequiredFieldValidator>
                                            </ContentTemplate>
                                            <Triggers>
                                                <asp:AsyncPostBackTrigger ControlID="ddlChequeBankNameLoan" />
                                            </Triggers>
                                        </asp:UpdatePanel>
                                    </div>
                                </div>
                                <div class="col-lg-3 col-md-12 col-sm-12 Loan_Cheque">
                                    <div class="form-group">
                                        <label>Cheque Number</label>
                                        <label style="color: red">*</label>
                                        <%--<input type="text" class="form-control">--%>
                                        <asp:TextBox ID="txtChequeNoLoan" runat="server" CssClass="form-control" MaxLength="15" onkeypress="return isNumberKey(this,event)"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="rfvtxtChequeNoLoan" runat="server"
                                            ErrorMessage="Cheque Number is required" ControlToValidate="txtChequeNoLoan" ValidationGroup="Add" ForeColor="Red"
                                            Display="None" CssClass="validation" SetFocusOnError="true" onkeypress="return isNumberKey(this,event)"></asp:RequiredFieldValidator>
                                    </div>
                                </div>
                                <div class="col-lg-3 col-md-12 col-sm-12 Loan_Cheque">
                                    <div class="form-group">
                                        <label>Cheque Date</label>
                                        <label style="color: red">*</label>
                                        <%--<input type="text" class="form-control datepicker">--%>
                                        <asp:TextBox ID="txtChequeDateLoan" runat="server" CssClass="form-control" Placeholder="dd-mm-yyyy" autocomplete="off"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="rfvtxtChequeDateLoan" runat="server"
                                            ErrorMessage="Cheque Date is required" ControlToValidate="txtChequeDateLoan" ValidationGroup="Add" ForeColor="Red"
                                            Display="None" CssClass="validation"></asp:RequiredFieldValidator>
                                        <%--SetFocusOnError="true"--%>
                                    </div>
                                </div>
                                <div class="col-lg-3 col-md-12 col-sm-12 Loan_Cheque">
                                    <div class="form-group">
                                        <label>Cheque Amount(₹)</label>
                                        <label style="color: red">*</label>
                                        <%--<input type="text" class="form-control">--%>
                                        <asp:UpdatePanel ID="Updatepanel39" runat="server">
                                            <ContentTemplate>
                                                <asp:TextBox ID="txtChequeAmountLoan" runat="server" CssClass="form-control" MaxLength="12" onkeypress="return isNumberKey(this,event)" ReadOnly="true"></asp:TextBox>
                                                <asp:RequiredFieldValidator ID="rfvtxtChequeAmountLoan" runat="server"
                                                    ErrorMessage="Cheque Amount is required" ControlToValidate="txtChequeAmountLoan" ValidationGroup="Add" ForeColor="Red"
                                                    Display="None" CssClass="validation"></asp:RequiredFieldValidator>
                                                <%-- SetFocusOnError="true"--%>
                                            </ContentTemplate>
                                            <Triggers>
                                                <asp:AsyncPostBackTrigger ControlID="ddlLoanMarginMode" />
                                            </Triggers>
                                        </asp:UpdatePanel>
                                    </div>
                                </div>
                                <div class="col-lg-3 col-md-12 col-sm-12 Loan_Cheque">
                                    <div class="form-group">
                                        <label>Upload Fresh Cheque Screenshot</label>
                                        <label style="color: red">*</label>
                                        <%--<input type="file" class="form-control">--%>
                                        <cc1:AsyncFileUpload runat="server" ID="fuChequeLoan" Width="100%" UploaderStyle="Traditional" CompleteBackColor="White"
                                            UploadingBackColor="#CCFFFF" ThrobberID="imgLoader" OnUploadedComplete="fuChequeLoan_UploadedComplete" CssClass="form-control"
                                            OnClientUploadComplete="uploadComplete1Loan" OnClientUploadStarted="uploadStart"
                                            ErrorBackColor="Transparent"></cc1:AsyncFileUpload>
                                    </div>
                                    <asp:TextBox ID="txtfuChequeLoan" runat="server" Style="display: none"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="rfvfuChequeLoan" runat="server"
                                        ErrorMessage="Upload Fresh Cheque Screenshot" ControlToValidate="txtfuChequeLoan" ValidationGroup="Add" ForeColor="Red"
                                        Display="None" CssClass="validation" SetFocusOnError="true"></asp:RequiredFieldValidator>
                                </div>

                                <div class="col-lg-3 col-md-12 col-sn-12 form-group filter hdpe Loan_Cheque" style="padding-left: 35px;">
                                    <label>Fresh Cheque Screenshot:</label>
                                    <div class="letterview" style="width: 130px; display: none;" id="divChequeLoan">
                                        <figure class="snip0013">
                                            <img src="assets/img/Cancelled-Cheque.jpg" width="130">
                                            <a href="img/doc.doc" download="">
                                                <asp:UpdatePanel ID="Updatepanel31" runat="server">
                                                    <ContentTemplate>
                                                        <asp:LinkButton ID="lnkChequeDownloadFreshLoan" runat="server" Text="Download" OnClick="lnkChequeDownloadFreshLoan_Click">
																<p><i class="fas fa-download"></i>Download</p>
                                                        </asp:LinkButton>
                                                    </ContentTemplate>
                                                    <Triggers>
                                                        <asp:PostBackTrigger ControlID="lnkChequeDownloadFreshLoan" />
                                                    </Triggers>
                                                </asp:UpdatePanel>
                                            </a>
                                        </figure>
                                    </div>
                                </div>

                                <!--Loan Cheque Bank Ends----------------------------------------------------->
                                <!--Loan NEFT Bank Start----------------------------------------------------->
                                <div class="col-lg-3 col-md-12 col-sm-12 neft_Loan">
                                    <div class="form-group">
                                        <label>Bank acc Details</label>
                                        <label style="color: red">*</label>
                                        <div class="input-group mb-3">
                                            <asp:UpdatePanel ID="Updatepanel32" runat="server">
                                                <ContentTemplate>
                                                    <asp:DropDownList ID="ddlNEFTBankNameLoan" runat="server" CssClass="form-control" AutoPostBack="true"
                                                        OnSelectedIndexChanged="ddlNEFTBankNameLoan_SelectedIndexChanged">
                                                    </asp:DropDownList>
                                                    <asp:RequiredFieldValidator ID="rfvddlNEFTBankNameLoan" runat="server"
                                                        ErrorMessage="Please select Bank" ControlToValidate="ddlNEFTBankNameLoan" ValidationGroup="Add" ForeColor="Red" InitialValue="0"
                                                        Display="None" CssClass="validation" SetFocusOnError="true"></asp:RequiredFieldValidator>
                                                </ContentTemplate>
                                            </asp:UpdatePanel>
                                        </div>
                                    </div>
                                </div>
                                <div class="clearfix neft_Loan"></div>

                                <div class="col-lg-3 col-md-12 col-sm-12 neft_Loan">
                                    <div class="form-group">
                                        <label>Bank Name</label>
                                        <label style="color: red">*</label>
                                        <asp:UpdatePanel ID="Updatepanel33" runat="server">
                                            <ContentTemplate>
                                                <%--<input type="text" class="form-control">--%>
                                                <asp:TextBox ID="txtNEFTBankNameLoan" runat="server" CssClass="form-control" MaxLength="50" Enabled="false"></asp:TextBox>
                                                <asp:RequiredFieldValidator ID="rfvtxtNEFTBankNameLoan" runat="server"
                                                    ErrorMessage="Bank Name is required" ControlToValidate="txtNEFTBankNameLoan" ValidationGroup="Add" ForeColor="Red"
                                                    Display="None" CssClass="validation" SetFocusOnError="true"></asp:RequiredFieldValidator>
                                            </ContentTemplate>
                                            <Triggers>
                                                <asp:AsyncPostBackTrigger ControlID="ddlNEFTBankNameLoan" />
                                            </Triggers>
                                        </asp:UpdatePanel>
                                    </div>
                                </div>
                                <div class="col-lg-3 col-md-12 col-sm-12 neft_Loan">
                                    <div class="form-group">
                                        <label>Branch Name</label>
                                        <label style="color: red">*</label>
                                        <asp:UpdatePanel ID="Updatepanel34" runat="server">
                                            <ContentTemplate>
                                                <%--<input type="text" class="form-control">--%>
                                                <asp:TextBox ID="txtNEFTBranchNameLoan" runat="server" CssClass="form-control" MaxLength="50" Enabled="false"></asp:TextBox>
                                                <asp:RequiredFieldValidator ID="rfvtxtNEFTBranchNameLoan" runat="server"
                                                    ErrorMessage="Branch Name is required" ControlToValidate="txtNEFTBranchNameLoan" ValidationGroup="Add" ForeColor="Red"
                                                    Display="None" CssClass="validation" SetFocusOnError="true"></asp:RequiredFieldValidator>
                                            </ContentTemplate>
                                            <Triggers>
                                                <asp:AsyncPostBackTrigger ControlID="ddlNEFTBankNameLoan" />
                                            </Triggers>
                                        </asp:UpdatePanel>
                                    </div>
                                </div>
                                <div class="col-lg-3 col-md-12 col-sm-12 neft_Loan">
                                    <div class="form-group">
                                        <label>Account Number</label>
                                        <label style="color: red">*</label>
                                        <asp:UpdatePanel ID="Updatepanel35" runat="server">
                                            <ContentTemplate>
                                                <%--<input type="text" class="form-control">--%>
                                                <asp:TextBox ID="txtNEFTAccNoLoan" runat="server" CssClass="form-control" MaxLength="25" Enabled="false"></asp:TextBox>
                                                <asp:RequiredFieldValidator ID="rfvtxtNEFTAccNoLoan" runat="server"
                                                    ErrorMessage="Account Number is required" ControlToValidate="txtNEFTAccNoLoan" ValidationGroup="Add" ForeColor="Red"
                                                    Display="None" CssClass="validation" SetFocusOnError="true"></asp:RequiredFieldValidator>
                                            </ContentTemplate>
                                            <Triggers>
                                                <asp:AsyncPostBackTrigger ControlID="ddlNEFTBankNameLoan" />
                                            </Triggers>
                                        </asp:UpdatePanel>
                                    </div>
                                </div>
                                <div class="col-lg-3 col-md-12 col-sm-12 neft_Loan">
                                    <div class="form-group">
                                        <label>IFSC Code</label>
                                        <label style="color: red">*</label>
                                        <asp:UpdatePanel ID="Updatepanel36" runat="server">
                                            <ContentTemplate>
                                                <%--<input type="text" class="form-control">--%>
                                                <asp:TextBox ID="txtNEFTIFSCLoan" runat="server" CssClass="form-control" MaxLength="20" Enabled="false"></asp:TextBox>
                                                <asp:RequiredFieldValidator ID="rfvtxtNEFTIFSCLoan" runat="server"
                                                    ErrorMessage="IFSC Code is required" ControlToValidate="txtNEFTIFSCLoan" ValidationGroup="Add" ForeColor="Red"
                                                    Display="None" CssClass="validation" SetFocusOnError="true"></asp:RequiredFieldValidator>
                                            </ContentTemplate>
                                            <Triggers>
                                                <asp:AsyncPostBackTrigger ControlID="ddlNEFTBankNameLoan" />
                                            </Triggers>
                                        </asp:UpdatePanel>
                                    </div>
                                </div>
                                <div class="col-lg-3 col-md-12 col-sm-12 neft_Loan">
                                    <div class="form-group">
                                        <label>UTR / Transfer Reference Number</label>
                                        <label style="color: red">*</label>
                                        <%--<input type="text" class="form-control">--%>
                                        <asp:TextBox ID="txtNEFTUTRLoan" runat="server" CssClass="form-control" MaxLength="25"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="rfvtxtNEFTUTRLoan" runat="server"
                                            ErrorMessage="UTR / Transfer Reference Number is required" ControlToValidate="txtNEFTUTRLoan" ValidationGroup="Add" ForeColor="Red"
                                            Display="None" CssClass="validation" SetFocusOnError="true"></asp:RequiredFieldValidator>
                                    </div>
                                </div>
                                <div class="col-lg-3 col-md-12 col-sm-12 neft_Loan">
                                    <div class="form-group">
                                        <label>Upload Transaction Screenshot</label>
                                        <label style="color: red">*</label>
                                        <cc1:AsyncFileUpload runat="server" ID="fuNEFTLoan" Width="100%" UploaderStyle="Traditional" CompleteBackColor="White"
                                            UploadingBackColor="#CCFFFF" ThrobberID="imgLoader" OnUploadedComplete="fuNEFTLoan_UploadedComplete" CssClass="form-control"
                                            OnClientUploadComplete="uploadCompleteLoan" OnClientUploadStarted="uploadStart" OnClientUploadError="uploadError"
                                            ErrorBackColor="Transparent"></cc1:AsyncFileUpload>

                                    </div>
                                    <asp:TextBox ID="txtfuNEFTLoan" runat="server" Style="display: none;"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="rfvtxtfuNEFTLoan" runat="server"
                                        ErrorMessage="Upload Transaction Screenshot" ControlToValidate="txtfuNEFTLoan" ValidationGroup="Add" ForeColor="Red"
                                        Display="None" CssClass="validation" SetFocusOnError="true"></asp:RequiredFieldValidator>
                                </div>
                                <div class="col-lg-3 col-md-12 col-sn-12 form-group filter hdpe neft_Loan" style="padding-left: 35px;">
                                    <label>Transaction Screenshot</label>
                                    <div class="letterview" style="width: 130px; display: none;" id="divNEFTLoan">
                                        <figure class="snip0013">
                                            <img src="assets/img/Error.png" width="130">
                                            <a href="img/doc.doc" download="">
                                                <asp:UpdatePanel ID="Updatepanel37" runat="server">
                                                    <ContentTemplate>
                                                        <asp:LinkButton ID="lnkNEFTDownloadLoan" runat="server" Text="Download" OnClick="lnkNEFTDownloadLoan_Click">
																<p><i class="fas fa-download"></i>Download</p>
                                                        </asp:LinkButton>
                                                    </ContentTemplate>
                                                    <Triggers>
                                                        <asp:PostBackTrigger ControlID="lnkNEFTDownloadLoan" />
                                                    </Triggers>
                                                </asp:UpdatePanel>
                                            </a>
                                        </figure>
                                    </div>
                                </div>
                                <!--Loan NEFT Bank Ends----------------------------------------------------->
                            </fieldset>
                            <fieldset>
                                <legend style="width: 10%;">Other Details: </legend>
                                <div class="row" style="margin-top: 15px;">
                                    <div class="col-lg-3 col-md-12 col-sm-12">
                                        <div class="form-group">
                                            <label>Securities Details</label>
                                            <label style="color: red">*</label>
                                            <div class="input-group mb-3">
                                                <asp:UpdatePanel ID="Updatepanel14" runat="server">
                                                    <ContentTemplate>
                                                        <asp:DropDownList ID="ddlOtherSecurity" runat="server" CssClass="form-control" AutoPostBack="true"
                                                            OnSelectedIndexChanged="ddlOtherSecurity_SelectedIndexChanged" onchange="dropchange()">
                                                        </asp:DropDownList>
                                                        <asp:RequiredFieldValidator ID="rfvddlOtherSecurity" runat="server"
                                                            ErrorMessage="Please select DP Name" ControlToValidate="ddlOtherSecurity" ValidationGroup="Add" ForeColor="Red" InitialValue="0"
                                                            Display="None" CssClass="validation" SetFocusOnError="true"></asp:RequiredFieldValidator>
                                                    </ContentTemplate>
                                                </asp:UpdatePanel>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="col-lg-9 col-md-12 col-sm-12">
                                        <div class="form-group mt-4 pt-2">
                                            <asp:Button ID="btnmsg2" type="button" runat="server" class="btn btn-info btn-lg" Text="DMAT Details" data-toggle="modal" data-target="#modaldmatdetails"></asp:Button>
                                            <asp:Label ID="lblmsg2" runat="server" class="text-left mr-1" Text=""></asp:Label>
                                        </div>
                                    </div>

                                    <div class="col-lg-3 col-md-12 col-sm-12">
                                        <div class="form-group">
                                            <label>DP Name</label>
                                            <label style="color: red">*</label>
                                            <asp:UpdatePanel ID="Updatepanel20" runat="server">
                                                <ContentTemplate>
                                                    <asp:TextBox ID="txtOtherSECURITYNAME" runat="server" CssClass="form-control" MaxLength="100" Enabled="false"></asp:TextBox>
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server"
                                                        ErrorMessage="DP Name is required" ControlToValidate="txtOtherSECURITYNAME" ValidationGroup="Add" ForeColor="Red"
                                                        Display="None" CssClass="validation" SetFocusOnError="true"></asp:RequiredFieldValidator>
                                                </ContentTemplate>
                                                <Triggers>
                                                    <asp:AsyncPostBackTrigger ControlID="ddlOtherSecurity" />
                                                </Triggers>
                                            </asp:UpdatePanel>
                                        </div>
                                    </div>
                                    <div class="col-lg-3 col-md-12 col-sm-12">
                                        <div class="form-group">
                                            <label>DP ID</label>
                                            <label style="color: red">*</label>
                                            <asp:UpdatePanel ID="Updatepanel15" runat="server">
                                                <ContentTemplate>
                                                    <asp:TextBox ID="txtOtherDPID" runat="server" CssClass="form-control" MaxLength="25" Enabled="false"></asp:TextBox>
                                                    <asp:RequiredFieldValidator ID="rfvtxtOtherDPID" runat="server"
                                                        ErrorMessage="DP ID is required" ControlToValidate="txtOtherDPID" ValidationGroup="Add" ForeColor="Red"
                                                        Display="None" CssClass="validation" SetFocusOnError="true"></asp:RequiredFieldValidator>
                                                </ContentTemplate>
                                                <Triggers>
                                                    <asp:AsyncPostBackTrigger ControlID="ddlOtherSecurity" />
                                                </Triggers>
                                            </asp:UpdatePanel>
                                        </div>
                                    </div>
                                    <div class="col-lg-3 col-md-12 col-sm-12">
                                        <div class="form-group">
                                            <label>Client ID</label>
                                            <label style="color: red">*</label>
                                            <asp:UpdatePanel ID="Updatepanel16" runat="server">
                                                <ContentTemplate>
                                                    <asp:TextBox ID="txtOtherClientID" runat="server" CssClass="form-control" MaxLength="25" Enabled="false"></asp:TextBox>
                                                    <asp:RequiredFieldValidator ID="rfvtxtOtherClientID" runat="server"
                                                        ErrorMessage="Client ID is required" ControlToValidate="txtOtherClientID" ValidationGroup="Add" ForeColor="Red"
                                                        Display="None" CssClass="validation" SetFocusOnError="true"></asp:RequiredFieldValidator>
                                                </ContentTemplate>
                                                <Triggers>
                                                    <asp:AsyncPostBackTrigger ControlID="ddlOtherSecurity" />
                                                </Triggers>
                                            </asp:UpdatePanel>
                                        </div>
                                    </div>
                                    <div class="col-lg-3 col-md-12 col-sm-12">
                                        <div class="form-group">
                                            <label>Member Type</label>
                                            <label style="color: red">*</label>
                                            <asp:UpdatePanel ID="Updatepanel17" runat="server">
                                                <ContentTemplate>
                                                    <div class="input-group mb-3">
                                                        <asp:TextBox ID="txtOtherMemberType" runat="server" CssClass="form-control" MaxLength="25" Enabled="false"></asp:TextBox>
                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server"
                                                            ErrorMessage="Member Type is required" ControlToValidate="txtOtherMemberType" ValidationGroup="Add" ForeColor="Red"
                                                            Display="None" CssClass="validation" SetFocusOnError="true"></asp:RequiredFieldValidator>
                                                </ContentTemplate>
                                                <Triggers>
                                                    <asp:AsyncPostBackTrigger ControlID="ddlOtherSecurity" />
                                                </Triggers>
                                            </asp:UpdatePanel>
                                        </div>
                                    </div>
                                </div>
                                <div class="col-lg-3 col-md-12 col-sm-12">
                                    <div class="form-group">
                                        <label>Proof of DP ID & Client ID</label>
                                        <div class="letterview" style="width: 130px; display: none;" id="divDPID">
                                            <figure class="snip0013">
                                                <img src="assets/img/Error.png" width="130">
                                                <a href="img/doc.doc" download="">
                                                    <%--<p><i class="fas fa-download"></i>ClientID</p>--%>
                                                    <asp:UpdatePanel ID="Updatepanel18" runat="server">
                                                        <ContentTemplate>
                                                            <asp:LinkButton ID="lnkDownload" runat="server" Text="Download" OnClick="lnkDownload_Click">
																<p><i class="fas fa-download"></i>Download</p>
                                                            </asp:LinkButton>
                                                        </ContentTemplate>
                                                        <Triggers>
                                                            <asp:PostBackTrigger ControlID="lnkDownload" />
                                                        </Triggers>
                                                    </asp:UpdatePanel>
                                                </a>
                                            </figure>
                                        </div>
                                    </div>
                                </div>

                            </fieldset>
                        </div>

                        <div class="row">
                            <div class="col-lg-12 mt-1">
                                <asp:UpdatePanel ID="Updatepanel4" runat="server">
                                    <ContentTemplate>
                                    </ContentTemplate>
                                </asp:UpdatePanel>
                                <div class="row">
                                    <div class="col-md-6 text-right">
                                        <asp:ValidationSummary runat="server" ShowMessageBox="true" ShowSummary="false" ValidationGroup="Add" />
                                        <asp:Button ID="btnPreview" CssClass="btn btn-info btn-lg" Style="margin-bottom: 15px;" runat="server" Text="Preview" ValidationGroup="Add"
                                            CausesValidation="true" OnClick="btnPreview_Click" OnClientClick="Change_Session_Value();" Visible="false" />
                                        <%--<asp:Button ID="btnSession" CssClass="btn btn-info btn-lg" runat="server" Text="Session" OnClick="btnSession_Click" Style="display: none;" />--%>
                                    </div>
                                    <div class="col-md-5 text-right">
                                        <label style="color: red">All (*) marked fields are mandatory.</label>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </section>
    </div>


    <div id="modalbankdetails" class="modal fade" role="dialog">
        <div class="modal-dialog modal-lg">
            <div class="modal-content">
                <div class="modal-header">
                    <h5 class="modal-title" id="lblmodalbankdetails">Bank Details</h5>
                </div>
                <div class="modal-body" style="padding-left: 15px; padding-right: 15px;">
                    <div id="bankdetails" class="row">
                        <div class="">
                            <div class="col-lg-3 col-md-12 col-sm-12">
                                <div class="form-group">
                                    <label>Bank Name<span style="color: red">*</span></label>
                                    <div class="input-group mb-3">
                                        <asp:TextBox ID="txtbankname" runat="server" CssClass="form-control userInput" onkeypress="return characterOnly(event);"></asp:TextBox>
                                    </div>
                                </div>
                            </div>
                            <div class="col-lg-3 col-md-12 col-sm-12">
                                <div class="form-group">
                                    <label>Branch Name<span style="color: red">*</span></label>
                                    <asp:TextBox ID="txtbranchname" runat="server" CssClass="form-control userInput" onkeypress="return characterOnly(event);"></asp:TextBox>
                                </div>
                            </div>

                            <div class="col-lg-3 col-md-12 col-sm-12">
                                <div class="form-group">
                                    <label>Account Number<span style="color: red">*</span></label>
                                    <asp:TextBox ID="txtaccnumber" runat="server" CssClass="form-control userInput" MaxLength="50" onkeypress="return isNumberKey(event);"></asp:TextBox>
                                </div>
                            </div>
                            <div class="col-lg-3 col-md-12 col-sm-12">
                                <div class="form-group">
                                    <label>IFSC Code<span style="color: red">*</span></label>
                                    <asp:TextBox ID="txtifsccode" runat="server" CssClass="form-control userInput" MaxLength="50" onkeypress="return IsAlphaNumeric(event);"></asp:TextBox>
                                </div>
                            </div>
                            <div class="col-lg-3 col-md-12 col-sm-12">
                                <div class="form-group">

                                    <label>Cancel Cheque Upload<span style="color: red">*</span></label>
                                    <asp:FileUpload ID="calcel_cheque_file" runat="server" class="form-control" />

                                </div>
                            </div>
                            <div class="col-lg-9 col-md-12 col-sm-12">
                                <div class="form-group">
                                    <div style="color: red; float: right; margin-top: 30px">
                                        All (*) marked fields are mandatory.
                                    </div>

                                </div>
                            </div>
                        </div>

                        <div class="col-lg-3 offset-md-6 mb-3">
                            <asp:Button ID="save_bankdetail" OnClick="save_bankdetail_Click" Text="Save"
                                runat="server" CssClass="btn btn-info btn-lg" OnClientClick="return ReqValidation()"></asp:Button>
                        </div>
                    </div>
                </div>

                <div class="modal-footer bg-whitesmoke br">
                    <div class="btn-group" role="group" aria-label="Basic example">
                        <a href="#" class="btn btn-info btn-lg all CloseBtnNew" data-dismiss="modal" onclick="$('.modal-backdrop').remove(); $('[id*=modalbankdetails]').removeClass('show');">Close</a>
                    </div>
                </div>
            </div>
        </div>
    </div>

    <div id="modaldmatdetails" class="modal fade" role="dialog">
        <div class="modal-dialog modal-lg">
            <div class="modal-content">
                <div class="modal-header">
                    <h5 class="modal-title" id="lblmodaldmatdetails">DMAT Details</h5>
                </div>
                <div class="modal-body" style="padding-left: 15px; padding-right: 15px;">
                    <div id="dmatdetails" class="row">
                        <div class="">
                            <div class="col-lg-3 col-md-12 col-sm-12">
                                <div class="form-group">
                                    <%--Changes Securities to DP by Pallavi--%>
                                    <label>DP Name<span style="color: red">*</span></label>

                                    <asp:TextBox ID="txtsecurityname" runat="server" CssClass="form-control userInput" onkeypress="return IsAlphaNumeric(event);"></asp:TextBox>

                                </div>
                            </div>
                            <div class="col-lg-3 col-md-12 col-sm-12">
                                <div class="form-group">
                                    <label>DP ID<span style="color: red">*</span></label>
                                    <asp:TextBox ID="txtdpid" runat="server" CssClass="form-control userInput" MaxLength="50" onkeypress="return IsAlphaNumeric(event);"></asp:TextBox>

                                </div>
                            </div>
                            <div class="col-lg-3 col-md-12 col-sm-12">
                                <div class="form-group">
                                    <label>Client ID<span style="color: red">*</span></label>
                                    <asp:TextBox ID="txtclientid" runat="server" CssClass="form-control userInput" MaxLength="50" onkeypress="return IsAlphaNumeric(event);"></asp:TextBox>

                                </div>
                            </div>

                            <div class="col-lg-3 col-md-12 col-sm-12">
                                <div class="form-group">
                                    <label>Member Type<span style="color: red">*</span></label>
                                    <asp:DropDownList CssClass="form-control" ID="ddlmembertype" runat="server">
                                        <asp:ListItem Value="0">Select</asp:ListItem>
                                        <asp:ListItem Value="1">NSDL</asp:ListItem>
                                        <asp:ListItem Value="2">CDSL</asp:ListItem>
                                    </asp:DropDownList>
                                </div>
                            </div>
                            <div class="col-lg-3 col-md-12 col-sm-12">
                                <div class="form-group">
                                    <label>Proof<span style="color: red">*</span></label>
                                    <asp:FileUpload ID="fileuploadproof" runat="server" class="form-control" />
                                </div>
                            </div>
                            <div class="col-lg-9 col-md-12 col-sm-12">
                                <div class="form-group">
                                    <div style="color: red; float: right; margin-top: 30px">
                                        All (*) marked fields are mandatory.
                                    </div>
                                </div>
                            </div>
                        </div>

                        <div class="col-lg-3 offset-md-6 mb-3">
                            <asp:Button ID="save_dmatdetail" OnClick="save_dmatdetail_Click" Text="Save"
                                runat="server" CssClass="btn btn-info btn-lg" OnClientClick="return ReqValidation1()"></asp:Button>
                        </div>

                    </div>
                </div>

                <div class="modal-footer bg-whitesmoke br">
                    <div class="btn-group" role="group" aria-label="Basic example">
                        <a href="#" class="btn btn-info btn-lg all CloseBtnNew" data-dismiss="modal" onclick="$('.modal-backdrop').remove(); $('[id*=modaldmatdetails]').removeClass('show');">Close</a>
                    </div>
                </div>
            </div>
        </div>
    </div>


    <div class="modal fade bd-example-modal-lg1" tabindex="-1" role="dialog" aria-labelledby="myLargeModalLabel" aria-hidden="true" style="display: none;" id="modalPreview">
        <div class="modal-dialog modal-lg">
            <div class="modal-content">
                <div class="modal-header">
                    <h5 class="modal-title" id="myLargeModalLabel">Preview Employee Exercise</h5>
                </div>
                <asp:UpdatePanel ID="UpdatePanel3" runat="server" UpdateMode="Conditional">
                    <ContentTemplate>
                        <div class="modal-body" style="padding-left: 15px; padding-right: 15px;">
                            <fieldset style="margin-bottom: 0px; padding-block-end: 0px;">
                                <legend style="width: 10%; font-size: 1rem;">Basic Information: </legend>
                                <div class="row popRow">
                                    <div class="col-lg-3 col-md-3 col-sm-3" style="padding-right: 5px; padding-left: 17px;">
                                        <div class="form-group">
                                            <label class="pop">Tranchwise Vesting:</label>
                                        </div>
                                    </div>
                                    <div class="col-lg-3 col-md-3 col-sm-3" style="padding-right: 5px; padding-left: 17px;">
                                        <div class="form-group">
                                            <label class="pops" runat="server" id="lblTranchVesting"></label>
                                        </div>
                                    </div>
                                    <div class="col-lg-3 col-md-3 col-sm-3" style="padding-right: 5px; padding-left: 17px; display: none">
                                        <div class="form-group">
                                            <label class="pops" runat="server" id="Label2"></label>
                                        </div>
                                    </div>
                                    <div class="col-lg-3 col-md-3 col-sm-3" style="padding-right: 5px; padding-left: 17px;">
                                        <div class="form-group">
                                            <label class="pop">No. Of Options:</label>
                                        </div>
                                    </div>
                                    <div class="col-lg-3 col-md-3 col-sm-3" style="padding-right: 5px; padding-left: 17px;">
                                        <div class="form-group">
                                            <label class="pops" runat="server" id="lblExercise_Count"></label>
                                        </div>
                                    </div>
                                    <div class="col-lg-3 col-md-3 col-sm-3" style="padding-right: 5px; padding-left: 17px;">
                                        <div class="form-group">
                                            <label class="pop">Total Amount(₹):</label>
                                        </div>
                                    </div>
                                    <div class="col-lg-3 col-md-3 col-sm-3" style="padding-right: 5px; padding-left: 17px;">
                                        <div class="form-group">
                                            <label class="pops" runat="server" id="lblTotalAmount"></label>

                                        </div>
                                    </div>
                                    <div class="col-lg-3 col-md-3 col-sm-3" style="padding-right: 5px; padding-left: 17px;">
                                        <div class="form-group">
                                            <label class="pop">Payment Mode:</label>
                                        </div>
                                    </div>
                                    <div class="col-lg-3 col-md-3 col-sm-3" style="padding-right: 5px; padding-left: 17px;">
                                        <div class="form-group">
                                            <label class="pops" id="lblPaymantMode"></label>
                                            <asp:HiddenField ID="hfPaymantMode" runat="server" />
                                        </div>
                                    </div>
                                    <div class="col-lg-3 col-md-3 col-sm-3 Cheque" style="padding-right: 5px; padding-left: 17px;">
                                        <div class="form-group">
                                            <label class="pop">Bank Name</label>
                                        </div>
                                    </div>
                                    <div class="col-lg-3 col-md-3 col-sm-3 Cheque" style="padding-right: 5px; padding-left: 17px;">
                                        <div class="form-group">
                                            <label class="pops" runat="server" id="lblChequeBankName"></label>
                                        </div>
                                    </div>
                                    <div class="col-lg-3 col-md-3 col-sm-3 Cheque" style="padding-right: 5px; padding-left: 17px;">
                                        <div class="form-group">
                                            <label class="pop">Branch Name</label>
                                        </div>
                                    </div>
                                    <div class="col-lg-3 col-md-3 col-sm-3 Cheque" style="padding-right: 5px; padding-left: 17px;">
                                        <div class="form-group">
                                            <label class="pops" runat="server" id="lblChequeBranchName"></label>
                                        </div>
                                    </div>
                                    <div class="col-lg-3 col-md-3 col-sm-3 Cheque" style="padding-right: 5px; padding-left: 17px;">
                                        <div class="form-group">
                                            <label class="pop">Account Number</label>
                                        </div>
                                    </div>
                                    <div class="col-lg-3 col-md-3 col-sm-3 Cheque" style="padding-right: 5px; padding-left: 17px;">
                                        <div class="form-group">
                                            <label class="pops" runat="server" id="lblChequeAccNo"></label>
                                        </div>
                                    </div>
                                    <div class="col-lg-3 col-md-3 col-sm-3 Cheque" style="padding-right: 5px; padding-left: 17px;">
                                        <div class="form-group">
                                            <label class="pop">IFSC Code</label>
                                        </div>
                                    </div>
                                    <div class="col-lg-3 col-md-3 col-sm-3 Cheque" style="padding-right: 5px; padding-left: 17px;">
                                        <div class="form-group">
                                            <label class="pops" runat="server" id="lblChequeIFSC"></label>
                                        </div>
                                    </div>
                                    <div class="col-lg-3 col-md-3 col-sm-3 Cheque" style="padding-right: 5px; padding-left: 17px;">
                                        <div class="form-group">
                                            <label class="pop">Cheque Number</label>
                                        </div>
                                    </div>
                                    <div class="col-lg-3 col-md-3 col-sm-3 Cheque" style="padding-right: 5px; padding-left: 17px;">
                                        <div class="form-group">
                                            <label class="pops" runat="server" id="lblChequeNo"></label>
                                        </div>
                                    </div>
                                    <div class="col-lg-3 col-md-3 col-sm-3 Cheque" style="padding-right: 5px; padding-left: 17px;">
                                        <div class="form-group">
                                            <label class="pop">Cheque Date</label>
                                        </div>
                                    </div>
                                    <div class="col-lg-3 col-md-3 col-sm-3 Cheque" style="padding-right: 5px; padding-left: 17px;">
                                        <div class="form-group">
                                            <label class="pops" runat="server" id="lblChequeDate"></label>
                                        </div>
                                    </div>
                                    <div class="col-lg-3 col-md-3 col-sm-3 Cheque" style="padding-right: 5px; padding-left: 17px;">
                                        <div class="form-group">
                                            <label class="pop">Cheque Amount(₹)</label>
                                        </div>
                                    </div>
                                    <div class="col-lg-3 col-md-3 col-sm-3 Cheque" style="padding-right: 5px; padding-left: 17px;">
                                        <div class="form-group">
                                            <label class="pops" runat="server" id="lblChequeAmount"></label>
                                        </div>
                                    </div>
                                    <%--NEFT start--%>
                                    <div class="col-lg-3 col-md-3 col-sm-3 neft" style="padding-right: 5px; padding-left: 17px;">
                                        <div class="form-group">
                                            <label class="pop">Bank Name</label>
                                        </div>
                                    </div>
                                    <div class="col-lg-3 col-md-3 col-sm-3 neft" style="padding-right: 5px; padding-left: 17px;">
                                        <div class="form-group">
                                            <label class="pops" runat="server" id="lblNEFTBankName"></label>
                                        </div>
                                    </div>
                                    <div class="col-lg-3 col-md-3 col-sm-3 neft" style="padding-right: 5px; padding-left: 17px;">
                                        <div class="form-group">
                                            <label class="pop">Branch Name</label>
                                        </div>
                                    </div>
                                    <div class="col-lg-3 col-md-3 col-sm-3 neft" style="padding-right: 5px; padding-left: 17px;">
                                        <div class="form-group">
                                            <label class="pops" runat="server" id="lblNEFTBranchName"></label>
                                        </div>
                                    </div>
                                    <div class="col-lg-3 col-md-3 col-sm-3 neft" style="padding-right: 5px; padding-left: 17px;">
                                        <div class="form-group">
                                            <label class="pop">Account Number</label>
                                        </div>
                                    </div>
                                    <div class="col-lg-3 col-md-3 col-sm-3 neft" style="padding-right: 5px; padding-left: 17px;">
                                        <div class="form-group">
                                            <label class="pops" runat="server" id="lblNEFTAccNo"></label>
                                        </div>
                                    </div>
                                    <div class="col-lg-3 col-md-3 col-sm-3 neft" style="padding-right: 5px; padding-left: 17px;">
                                        <div class="form-group">
                                            <label class="pop">IFSC Code</label>
                                        </div>
                                    </div>
                                    <div class="col-lg-3 col-md-3 col-sm-3 neft" style="padding-right: 5px; padding-left: 17px;">
                                        <div class="form-group">
                                            <label class="pops" runat="server" id="lblNEFTIFSC"></label>
                                        </div>
                                    </div>
                                    <div class="col-lg-3 col-md-3 col-sm-3 neft" style="padding-right: 5px; padding-left: 17px;">
                                        <div class="form-group">
                                            <label class="pop">UTR / Transfer Reference Number</label>
                                        </div>
                                    </div>
                                    <div class="col-lg-3 col-md-3 col-sm-3 neft" style="padding-right: 5px; padding-left: 17px;">
                                        <div class="form-group">
                                            <label class="pops" runat="server" id="lblNEFTUTR"></label>
                                        </div>
                                    </div>
                                    <%-- NEFT end--%>
                                    <%--Loan start--%>
                                    <div class="col-lg-3 col-md-3 col-sm-3 loan" style="padding-right: 5px; padding-left: 17px;">
                                        <div class="form-group">
                                            <label class="pop">Lender Bank Name</label>
                                        </div>
                                    </div>
                                    <div class="col-lg-3 col-md-3 col-sm-3 loan" style="padding-right: 5px; padding-left: 17px;">
                                        <div class="form-group">
                                            <label class="pops" runat="server" id="lblLoanBankName"></label>
                                        </div>
                                    </div>
                                    <div class="col-lg-3 col-md-3 col-sm-3 loan" style="padding-right: 5px; padding-left: 17px;">
                                        <div class="form-group">
                                            <label class="pop">Loan Amount(₹)</label>
                                        </div>
                                    </div>
                                    <div class="col-lg-3 col-md-3 col-sm-3 loan" style="padding-right: 5px; padding-left: 17px;">
                                        <div class="form-group">
                                            <label class="pops" runat="server" id="lblLoanAmount"></label>
                                        </div>
                                    </div>
                                    <div class="col-lg-3 col-md-3 col-sm-3 loan" style="padding-right: 5px; padding-left: 17px;">
                                        <div class="form-group">
                                            <label class="pop">Margin Money Amount(₹)</label>
                                        </div>
                                    </div>
                                    <div class="col-lg-3 col-md-3 col-sm-3 loan" style="padding-right: 5px; padding-left: 17px;">
                                        <div class="form-group">
                                            <label class="pops" runat="server" id="lblLoanMarginAmount"></label>
                                        </div>
                                    </div>
                                    <div class="col-lg-3 col-md-3 col-sm-3 loan" style="padding-right: 5px; padding-left: 17px;">
                                        <div class="form-group">
                                            <label class="pop">Margin Money Payment Mode</label>
                                        </div>
                                    </div>
                                    <div class="col-lg-3 col-md-3 col-sm-3 loan" style="padding-right: 5px; padding-left: 17px;">
                                        <div class="form-group">
                                            <label class="pops" runat="server" id="lblLoanPaymentMode"></label>
                                        </div>
                                    </div>
                                    <div class="col-lg-3 col-md-3 col-sm-3 Loan_Cheque" style="padding-right: 5px; padding-left: 17px;">
                                        <div class="form-group">
                                            <label class="pop">Bank Name</label>
                                        </div>
                                    </div>
                                    <div class="col-lg-3 col-md-3 col-sm-3 Loan_Cheque" style="padding-right: 5px; padding-left: 17px;">
                                        <div class="form-group">
                                            <label class="pops" runat="server" id="lblChequeBankNameLoan"></label>
                                        </div>
                                    </div>
                                    <div class="col-lg-3 col-md-3 col-sm-3 Loan_Cheque" style="padding-right: 5px; padding-left: 17px;">
                                        <div class="form-group">
                                            <label class="pop">Branch Name</label>
                                        </div>
                                    </div>
                                    <div class="col-lg-3 col-md-3 col-sm-3 Loan_Cheque" style="padding-right: 5px; padding-left: 17px;">
                                        <div class="form-group">
                                            <label class="pops" runat="server" id="lblChequeBranchNameLoan"></label>
                                        </div>
                                    </div>
                                    <div class="col-lg-3 col-md-3 col-sm-3 Loan_Cheque" style="padding-right: 5px; padding-left: 17px;">
                                        <div class="form-group">
                                            <label class="pop">Account Number</label>
                                        </div>
                                    </div>
                                    <div class="col-lg-3 col-md-3 col-sm-3 Loan_Cheque" style="padding-right: 5px; padding-left: 17px;">
                                        <div class="form-group">
                                            <label class="pops" runat="server" id="lblChequeAccNoLoan"></label>
                                        </div>
                                    </div>
                                    <div class="col-lg-3 col-md-3 col-sm-3 Loan_Cheque" style="padding-right: 5px; padding-left: 17px;">
                                        <div class="form-group">
                                            <label class="pop">IFSC Code</label>
                                        </div>
                                    </div>
                                    <div class="col-lg-3 col-md-3 col-sm-3 Loan_Cheque" style="padding-right: 5px; padding-left: 17px;">
                                        <div class="form-group">
                                            <label class="pops" runat="server" id="lblChequeIFSCLoan"></label>
                                        </div>
                                    </div>
                                    <div class="col-lg-3 col-md-3 col-sm-3 Loan_Cheque" style="padding-right: 5px; padding-left: 17px;">
                                        <div class="form-group">
                                            <label class="pop">Cheque Number</label>
                                        </div>
                                    </div>
                                    <div class="col-lg-3 col-md-3 col-sm-3 Loan_Cheque" style="padding-right: 5px; padding-left: 17px;">
                                        <div class="form-group">
                                            <label class="pops" runat="server" id="lblChequeNoLoan"></label>
                                        </div>
                                    </div>
                                    <div class="col-lg-3 col-md-3 col-sm-3 Loan_Cheque" style="padding-right: 5px; padding-left: 17px;">
                                        <div class="form-group">
                                            <label class="pop">Cheque Date</label>
                                        </div>
                                    </div>
                                    <div class="col-lg-3 col-md-3 col-sm-3 Loan_Cheque" style="padding-right: 5px; padding-left: 17px;">
                                        <div class="form-group">
                                            <label class="pops" runat="server" id="lblChequeDateLoan"></label>
                                        </div>
                                    </div>
                                    <div class="col-lg-3 col-md-3 col-sm-3 Loan_Cheque" style="padding-right: 5px; padding-left: 17px;">
                                        <div class="form-group">
                                            <label class="pop">Cheque Amount(₹)</label>
                                        </div>
                                    </div>
                                    <div class="col-lg-3 col-md-3 col-sm-3 Loan_Cheque" style="padding-right: 5px; padding-left: 17px;">
                                        <div class="form-group">
                                            <label class="pops" runat="server" id="lblChequeAmountLoan"></label>
                                        </div>
                                    </div>
                                    <div class="col-lg-3 col-md-3 col-sm-3 neft_Loan" style="padding-right: 5px; padding-left: 17px;">
                                        <div class="form-group">
                                            <label class="pop">Bank Name</label>
                                        </div>
                                    </div>
                                    <div class="col-lg-3 col-md-3 col-sm-3 neft_Loan" style="padding-right: 5px; padding-left: 17px;">
                                        <div class="form-group">
                                            <label class="pops" runat="server" id="lblNEFTBankNameLoan"></label>
                                        </div>
                                    </div>
                                    <div class="col-lg-3 col-md-3 col-sm-3 neft_Loan" style="padding-right: 5px; padding-left: 17px;">
                                        <div class="form-group">
                                            <label class="pop">Branch Name</label>
                                        </div>
                                    </div>
                                    <div class="col-lg-3 col-md-3 col-sm-3 neft_Loan" style="padding-right: 5px; padding-left: 17px;">
                                        <div class="form-group">
                                            <label class="pops" runat="server" id="lblNEFTBranchNameLoan"></label>
                                        </div>
                                    </div>
                                    <div class="col-lg-3 col-md-3 col-sm-3 neft_Loan" style="padding-right: 5px; padding-left: 17px;">
                                        <div class="form-group">
                                            <label class="pop">Account Number</label>
                                        </div>
                                    </div>
                                    <div class="col-lg-3 col-md-3 col-sm-3 neft_Loan" style="padding-right: 5px; padding-left: 17px;">
                                        <div class="form-group">
                                            <label class="pops" runat="server" id="lblNEFTAccNoLoan"></label>
                                        </div>
                                    </div>
                                    <div class="col-lg-3 col-md-3 col-sm-3 neft_Loan" style="padding-right: 5px; padding-left: 17px;">
                                        <div class="form-group">
                                            <label class="pop">IFSC Code</label>
                                        </div>
                                    </div>
                                    <div class="col-lg-3 col-md-3 col-sm-3 neft_Loan" style="padding-right: 5px; padding-left: 17px;">
                                        <div class="form-group">
                                            <label class="pops" runat="server" id="lblNEFTIFSCLoan"></label>
                                        </div>
                                    </div>
                                    <div class="col-lg-3 col-md-3 col-sm-3 neft_Loan" style="padding-right: 5px; padding-left: 17px;">
                                        <div class="form-group">
                                            <label class="pop">UTR / Transfer Reference Number</label>
                                        </div>
                                    </div>
                                    <div class="col-lg-3 col-md-3 col-sm-3 neft_Loan" style="padding-right: 5px; padding-left: 17px;">
                                        <div class="form-group">
                                            <label class="pops" runat="server" id="lblNEFTUTRLoan"></label>
                                        </div>
                                    </div>
                                </div>
                            </fieldset>
                            <fieldset style="margin-bottom: 0px; padding-block-end: 0px;">
                                <legend style="width: 15%; font-size: 1rem;">DMAT Details: </legend>
                                <div class="row popRow">
                                    <div class="col-lg-3 col-md-3 col-sm-3" style="padding-right: 5px; padding-left: 17px;">
                                        <div class="form-group">
                                            <label class="pop">DP Name:</label>
                                        </div>
                                    </div>
                                    <div class="col-lg-3 col-md-3 col-sm-3" style="padding-right: 5px; padding-left: 17px;">
                                        <div class="form-group">
                                            <label class="pops" runat="server" id="lblSecurityName"></label>
                                        </div>
                                    </div>
                                    <div class="col-lg-3 col-md-3 col-sm-3" style="padding-right: 5px; padding-left: 17px;">
                                        <div class="form-group">
                                            <label class="pop">DP ID:</label>
                                        </div>
                                    </div>
                                    <div class="col-lg-3 col-md-3 col-sm-3" style="padding-right: 5px; padding-left: 17px;">
                                        <div class="form-group">
                                            <label class="pops" runat="server" id="lblDPID"></label>
                                        </div>
                                    </div>
                                    <div class="col-lg-3 col-md-3 col-sm-3" style="padding-right: 5px; padding-left: 17px;">
                                        <div class="form-group">
                                            <label class="pop">Client ID:</label>
                                        </div>
                                    </div>
                                    <div class="col-lg-3 col-md-3 col-sm-3" style="padding-right: 5px; padding-left: 17px;">
                                        <div class="form-group">
                                            <label class="pops" runat="server" id="lblClientID"></label>
                                        </div>
                                    </div>
                                    <div class="col-lg-3 col-md-3 col-sm-3" style="padding-right: 5px; padding-left: 17px;">
                                        <div class="form-group">
                                            <label class="pop">Member Type:</label>
                                        </div>
                                    </div>
                                    <div class="col-lg-3 col-md-3 col-sm-3" style="padding-right: 5px; padding-left: 17px;">
                                        <div class="form-group">
                                            <label class="pops" runat="server" id="lblMemberType"></label>
                                        </div>
                                    </div>
                                </div>
                            </fieldset>
                            <fieldset style="margin-bottom: 0px; padding-block-end: 0px;" id="f2" runat="server">
                                <legend style="width: 15%; font-size: 1rem;">Fresh Cheque Screenshot: </legend>
                                <asp:Image ID="Image3" ImageUrl="" runat="server" CssClass="img" />
                            </fieldset>
                            <div class="col-lg-6 col-md-6 col-sm-3">
                                <fieldset style="margin-bottom: 0px; padding-block-end: 0px;" id="f3" runat="server">
                                    <legend style="width: 60% !important; font-size: 1rem;">Proof of DP ID & Client ID: </legend>
                                    <asp:Image ID="Image2" ImageUrl="" runat="server" CssClass="img Image2" />
                                </fieldset>
                            </div>
                            <fieldset style="margin-bottom: 0px; padding-block-end: 0px;" id="f4" runat="server">
                                <legend style="width: 15%; font-size: 1rem;">NEFT (Bank Transfer) </legend>
                                <asp:Image ID="Image4" ImageUrl="" runat="server" CssClass="img" />
                            </fieldset>
                            <div class="col-lg-6 col-md-6 col-sm-3">
                                <fieldset style="margin-bottom: 0px; padding-block-end: 0px;" id="f5" runat="server">
                                    <legend style="width: 70% !important; font-size: 1rem;">Loan Fresh Cheque Screenshot: </legend>
                                    <asp:Image ID="Image5" ImageUrl="" runat="server" CssClass="img Image5" />
                                </fieldset>
                            </div>
                            <fieldset style="margin-bottom: 0px; padding-block-end: 0px;" id="f6" runat="server">
                                <legend style="width: 40% !important; font-size: 1rem;">Loan Transaction Screenshot: </legend>
                                <asp:Image ID="Image6" ImageUrl="" runat="server" CssClass="img" />
                            </fieldset>
                        </div>
                    </ContentTemplate>
                    <Triggers>
                        <asp:AsyncPostBackTrigger ControlID="btnPreview" EventName="Click" />
                    </Triggers>
                </asp:UpdatePanel>
                <div class="modal-footer bg-whitesmoke br">
                    <div class="btn-group" role="group" aria-label="Basic example">
                        <asp:Button ID="btnFinalSubmit" CssClass="btn btn-info btn-lg" Style="margin-bottom: 15px;" runat="server" Text="Submit"
                            OnClick="btnFinalSubmit_Click" CausesValidation="false" />
                        <a href="#" class="btn btn-info btn-lg all CloseBtnNew" data-dismiss="modal">Close</a>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <!-- General JS Scripts -->

    <script src="assets/js/jquery-1.12.4.js" type="text/javascript"></script>
    <script src="Scripts/bootstrap.min.js"></script>
    <script src="assets/js/scripts.js"></script>

    <script src="assets/js/jquery-ui-1.12.1.js" type="text/javascript"></script>

    <link href="assets/css/bootstrap-3.3.6.min.css" rel="stylesheet" />

    <script type="text/javascript">
        function ReqValidation() {
            //debugger;

            var txtbankname = document.getElementById('<%=txtbankname.ClientID%>').value;
            var txtbranchname = document.getElementById('<%=txtbranchname.ClientID%>').value;
            var txtaccnumber = document.getElementById('<%=txtaccnumber.ClientID%>').value;
            var txtifsccode = document.getElementById('<%=txtifsccode.ClientID%>').value;
            var FileUpload1 = document.getElementById('<%=calcel_cheque_file.ClientID%>').value;

            if (txtbankname.trim() == "") {
                alert("Select bank name.");
                document.getElementById('<%=txtbankname.ClientID%>').focus();
                return false;
            }
            if (txtbranchname.trim() == "") {
                alert("Select branch name.");
                document.getElementById('<%=txtbranchname.ClientID%>').focus();
                return false;
            }
            if (txtaccnumber.trim() == "") {
                alert("Select account number.");
                document.getElementById('<%=txtaccnumber.ClientID%>').focus();
                return false;
            }

            if (txtifsccode.trim() == "") {
                alert("Select IFSC code.");
                document.getElementById('<%=txtifsccode.ClientID%>').focus();
                return false;
            }

            if (FileUpload1.trim() == "") {
                alert("Please upload cancelled cheque");
                document.getElementById('<%=calcel_cheque_file.ClientID%>').focus();
                return false;
            }


            if (FileUpload1.trim() != "") {
                var ext = FileUpload1.substr(FileUpload1.lastIndexOf('.') + 1).toLowerCase();
                if (ext == "png" || ext == "jpg" || ext == "jpeg") {
                    return true;
                }
                else {
                    alert("File should be in .png, .jpg, .jpeg format.");
                    document.getElementById('<%=calcel_cheque_file.ClientID%>').value = "";
                    document.getElementById('<%=calcel_cheque_file.ClientID%>').focus();
                    return false;

                }
            }

        }
    </script>

    <script type="text/javascript">
        function ReqValidation1() {
            //debugger;
            var securityname = document.getElementById('<%=txtsecurityname.ClientID%>').value;
		  
			<%-- document.getElementById('<%=hiddenControl.ClientID%>').value = Fileup;--%>

            var dpid = document.getElementById('<%=txtdpid.ClientID%>').value;
            var client = document.getElementById('<%=txtclientid.ClientID%>').value;
            var member = document.getElementById('<%=ddlmembertype.ClientID%>').value;
            var FileUpload1 = document.getElementById('<%=fileuploadproof.ClientID%>').value;


            if (securityname.trim() == "") {
                alert("Select DP name.");
                document.getElementById('<%=txtsecurityname.ClientID%>').focus();
                return false;
            }
            if (dpid.trim() == "") {
                alert("Select Dp ID.");
                document.getElementById('<%=txtdpid.ClientID%>').focus();
                return false;
            }
            if (client.trim() == "") {
                alert("Select Client ID.");
                document.getElementById('<%=txtclientid.ClientID%>').focus();
                return false;
            }

            if (member == "0") {
                alert("Select member type.");
                document.getElementById('<%=ddlmembertype.ClientID%>').focus();
                return false;
            }

            if (FileUpload1.trim() == "") {
                alert("Select Upload Proof");
                document.getElementById('<%=fileuploadproof.ClientID%>').focus();
                return false;
            }

            if (FileUpload1.trim() != "") {
                var ext = FileUpload1.substr(FileUpload1.lastIndexOf('.') + 1).toLowerCase();
                if (ext == "png" || ext == "jpg" || ext == "jpeg") {
                    return true;
                }
                else {
                    alert("File should be in .png, .jpg, .jpeg format.");
                    document.getElementById('<%=fileuploadproof.ClientID%>').value = "";
                    document.getElementById('<%=fileuploadproof.ClientID%>').focus();
                    return false;

                }
            }
        }
    </script>


    <script>
        $(function () {
            //$.noConflict();
            var from = $("#ContentPlaceHolder1_txtChequeDate")
		 .datepicker({
		     minDate: 0,
		     dateFormat: "dd-M-yy",
		     changeMonth: true,
		     changeYear: true,

		 });

            var fromTo = $("#ContentPlaceHolder1_txtChequeDateLoan")
		.datepicker({
		    minDate: 0,
		    dateFormat: "dd-M-yy",
		    changeMonth: true,
		    changeYear: true,

		});
        });
    </script>
    <script>
        function radioValue_1() {
            var radioValue = $("input[name='customRadioInline3']:checked").val();
            //alert(radioValue);
            //alert('radioValue');
            if (radioValue == "Cheque") {
                ValidatorEnable(document.getElementById("<%=rfvddlChequeBankName.ClientID %>"), true);

                ValidatorEnable(document.getElementById("<%=rfvtxtChequeBankName.ClientID %>"), true);
                ValidatorEnable(document.getElementById("<%=rfvtxtChequeBranchName.ClientID %>"), true);//txtChequeAccNo                  
                ValidatorEnable(document.getElementById("<%=rfvtxtChequeIFSC.ClientID %>"), true);
                ValidatorEnable(document.getElementById("<%=rfvtxtChequeAmount.ClientID %>"), true);
                ValidatorEnable(document.getElementById("<%=rfvtxtChequeDate.ClientID %>"), true);
                ValidatorEnable(document.getElementById("<%=rfvtxtChequeNo.ClientID %>"), true);
                ValidatorEnable(document.getElementById("<%=rfvtxtChequeAccNo.ClientID %>"), true);//txtChequeAccNo

                ValidatorEnable(document.getElementById("<%=rfvddlNEFTBankName.ClientID %>"), false);
                ValidatorEnable(document.getElementById("<%=rfvtxtNEFTAccNo.ClientID %>"), false);
                ValidatorEnable(document.getElementById("<%=rfvtxtNEFTBankName.ClientID %>"), false);
                ValidatorEnable(document.getElementById("<%=rfvtxtNEFTBranchName.ClientID %>"), false);
                ValidatorEnable(document.getElementById("<%=rfvtxtNEFTIFSC.ClientID %>"), false);
                ValidatorEnable(document.getElementById("<%=rfvtxtNEFTUTR.ClientID %>"), false);

                ValidatorEnable(document.getElementById("<%=rfvtxtLoanAmount.ClientID %>"), false);
                ValidatorEnable(document.getElementById("<%=rfvtxtLoanBankName.ClientID %>"), false);
                ValidatorEnable(document.getElementById("<%=rfvtxtLoanMarginAmount.ClientID %>"), false);
                ValidatorEnable(document.getElementById("<%=rfvddlLoanMarginMode.ClientID %>"), false);

                ValidatorEnable(document.getElementById("<%=rfvddlChequeBankNameLoan.ClientID %>"), false);
                ValidatorEnable(document.getElementById("<%=rfvtxtChequeBankNameLoan.ClientID %>"), false);
                ValidatorEnable(document.getElementById("<%=rfvtxtChequeBranchNameLoan.ClientID %>"), false);//txtChequeAccNo
                ValidatorEnable(document.getElementById("<%=rfvtxtChequeAccNoLoan.ClientID %>"), false);//txtChequeAccNo                    
                ValidatorEnable(document.getElementById("<%=rfvtxtChequeIFSCLoan.ClientID %>"), false);
                ValidatorEnable(document.getElementById("<%=rfvtxtChequeAmountLoan.ClientID %>"), false);
                ValidatorEnable(document.getElementById("<%=rfvtxtChequeDateLoan.ClientID %>"), false);
                ValidatorEnable(document.getElementById("<%=rfvtxtChequeNoLoan.ClientID %>"), false);

                ValidatorEnable(document.getElementById("<%=rfvddlNEFTBankNameLoan.ClientID %>"), false);
                ValidatorEnable(document.getElementById("<%=rfvtxtNEFTAccNoLoan.ClientID %>"), false);
                ValidatorEnable(document.getElementById("<%=rfvtxtNEFTBankNameLoan.ClientID %>"), false);
                ValidatorEnable(document.getElementById("<%=rfvtxtNEFTBranchNameLoan.ClientID %>"), false);
                ValidatorEnable(document.getElementById("<%=rfvtxtNEFTIFSCLoan.ClientID %>"), false);
                ValidatorEnable(document.getElementById("<%=rfvtxtNEFTUTRLoan.ClientID %>"), false);

                ValidatorEnable(document.getElementById("<%=rfvtxtfuCheque.ClientID %>"), true);
                ValidatorEnable(document.getElementById("<%=rfvtxtfuNEFT1.ClientID %>"), false);
                ValidatorEnable(document.getElementById("<%=rfvfuChequeLoan.ClientID %>"), false);
                ValidatorEnable(document.getElementById("<%=rfvtxtfuNEFTLoan.ClientID %>"), false);



                $('.Cheque').show()
                $('.neft').hide();
                $('.loan').hide();
                $('.neft_Loan').hide();

                $("#divNEFT").css({ 'display': 'none' });
                $("#divChequeLoan").css({ 'display': 'none' });
                $("#divNEFTLoan").css({ 'display': 'none' });


            }
            else if
				   (radioValue == "neft") {

                ValidatorEnable(document.getElementById("<%=rfvddlChequeBankName.ClientID %>"), false);
                ValidatorEnable(document.getElementById("<%=rfvtxtChequeBankName.ClientID %>"), false);
                ValidatorEnable(document.getElementById("<%=rfvtxtChequeBranchName.ClientID %>"), false);//txtChequeAccNo
                ValidatorEnable(document.getElementById("<%=rfvtxtChequeAccNo.ClientID %>"), false);//txtChequeAccNo
                ValidatorEnable(document.getElementById("<%=rfvtxtChequeAmount.ClientID %>"), false);
                ValidatorEnable(document.getElementById("<%=rfvtxtChequeDate.ClientID %>"), false);
                ValidatorEnable(document.getElementById("<%=rfvtxtChequeIFSC.ClientID %>"), false);
                ValidatorEnable(document.getElementById("<%=rfvtxtChequeNo.ClientID %>"), false);

                ValidatorEnable(document.getElementById("<%=rfvddlNEFTBankName.ClientID %>"), true);
                ValidatorEnable(document.getElementById("<%=rfvtxtNEFTAccNo.ClientID %>"), true);
                ValidatorEnable(document.getElementById("<%=rfvtxtNEFTBankName.ClientID %>"), true);
                ValidatorEnable(document.getElementById("<%=rfvtxtNEFTBranchName.ClientID %>"), true);
                ValidatorEnable(document.getElementById("<%=rfvtxtNEFTIFSC.ClientID %>"), true);
                ValidatorEnable(document.getElementById("<%=rfvtxtNEFTUTR.ClientID %>"), true);

                ValidatorEnable(document.getElementById("<%=rfvtxtLoanAmount.ClientID %>"), false);
                ValidatorEnable(document.getElementById("<%=rfvtxtLoanBankName.ClientID %>"), false);
                ValidatorEnable(document.getElementById("<%=rfvtxtLoanMarginAmount.ClientID %>"), false);
                ValidatorEnable(document.getElementById("<%=rfvddlLoanMarginMode.ClientID %>"), false);

                ValidatorEnable(document.getElementById("<%=rfvddlChequeBankNameLoan.ClientID %>"), false);
                ValidatorEnable(document.getElementById("<%=rfvtxtChequeBankNameLoan.ClientID %>"), false);
                ValidatorEnable(document.getElementById("<%=rfvtxtChequeBranchNameLoan.ClientID %>"), false);//txtChequeAccNo
                ValidatorEnable(document.getElementById("<%=rfvtxtChequeAccNoLoan.ClientID %>"), false);//txtChequeAccNo                    
                ValidatorEnable(document.getElementById("<%=rfvtxtChequeIFSCLoan.ClientID %>"), false);
                ValidatorEnable(document.getElementById("<%=rfvtxtChequeAmountLoan.ClientID %>"), false);
                ValidatorEnable(document.getElementById("<%=rfvtxtChequeDateLoan.ClientID %>"), false);
                ValidatorEnable(document.getElementById("<%=rfvtxtChequeNoLoan.ClientID %>"), false);

                ValidatorEnable(document.getElementById("<%=rfvddlNEFTBankNameLoan.ClientID %>"), false);
                ValidatorEnable(document.getElementById("<%=rfvtxtNEFTAccNoLoan.ClientID %>"), false);
                ValidatorEnable(document.getElementById("<%=rfvtxtNEFTBankNameLoan.ClientID %>"), false);
                ValidatorEnable(document.getElementById("<%=rfvtxtNEFTBranchNameLoan.ClientID %>"), false);
                ValidatorEnable(document.getElementById("<%=rfvtxtNEFTIFSCLoan.ClientID %>"), false);
                ValidatorEnable(document.getElementById("<%=rfvtxtNEFTUTRLoan.ClientID %>"), false);

                ValidatorEnable(document.getElementById("<%=rfvtxtfuCheque.ClientID %>"), false);
                ValidatorEnable(document.getElementById("<%=rfvtxtfuNEFT1.ClientID %>"), true);
                ValidatorEnable(document.getElementById("<%=rfvfuChequeLoan.ClientID %>"), false);
                ValidatorEnable(document.getElementById("<%=rfvtxtfuNEFTLoan.ClientID %>"), false);


                $('.neft').show()
                $('.Cheque').hide();
                $('.loan').hide();
                $('.Loan_Cheque').hide();
                $('.neft_Loan').hide();

                $("#divCheque").css({ 'display': 'none' });
                $("#divChequeLoan").css({ 'display': 'none' });
                $("#divNEFTLoan").css({ 'display': 'none' });


            }

            else if
					(radioValue == "loan") {
                //alert('Loan_1');

                ValidatorEnable(document.getElementById("<%=rfvddlChequeBankName.ClientID %>"), false);
                ValidatorEnable(document.getElementById("<%=rfvtxtChequeBankName.ClientID %>"), false);
                ValidatorEnable(document.getElementById("<%=rfvtxtChequeBranchName.ClientID %>"), false);//txtChequeAccNo
                ValidatorEnable(document.getElementById("<%=rfvtxtChequeAccNo.ClientID %>"), false);//txtChequeAccNo                    
                ValidatorEnable(document.getElementById("<%=rfvtxtChequeIFSC.ClientID %>"), false);
                ValidatorEnable(document.getElementById("<%=rfvtxtChequeAmount.ClientID %>"), false);
                ValidatorEnable(document.getElementById("<%=rfvtxtChequeDate.ClientID %>"), false);
                ValidatorEnable(document.getElementById("<%=rfvtxtChequeNo.ClientID %>"), false);

                ValidatorEnable(document.getElementById("<%=rfvddlNEFTBankName.ClientID %>"), false);
                ValidatorEnable(document.getElementById("<%=rfvtxtNEFTAccNo.ClientID %>"), false);
                ValidatorEnable(document.getElementById("<%=rfvtxtNEFTBankName.ClientID %>"), false);
                ValidatorEnable(document.getElementById("<%=rfvtxtNEFTBranchName.ClientID %>"), false);
                ValidatorEnable(document.getElementById("<%=rfvtxtNEFTIFSC.ClientID %>"), false);
                ValidatorEnable(document.getElementById("<%=rfvtxtNEFTUTR.ClientID %>"), false);

                ValidatorEnable(document.getElementById("<%=rfvtxtLoanAmount.ClientID %>"), true);
                ValidatorEnable(document.getElementById("<%=rfvtxtLoanBankName.ClientID %>"), true);
                ValidatorEnable(document.getElementById("<%=rfvtxtLoanMarginAmount.ClientID %>"), true);
                ValidatorEnable(document.getElementById("<%=rfvddlLoanMarginMode.ClientID %>"), true);

                ValidatorEnable(document.getElementById("<%=rfvtxtfuCheque.ClientID %>"), false);
                ValidatorEnable(document.getElementById("<%=rfvtxtfuNEFT1.ClientID %>"), false);

                if (document.getElementById("<%=ddlLoanMarginMode.ClientID %>").value == 'NEFT') {
                    ValidatorEnable(document.getElementById("<%=rfvfuChequeLoan.ClientID %>"), false);
                    ValidatorEnable(document.getElementById("<%=rfvtxtfuNEFTLoan.ClientID %>"), true);
                }
                else {
                    ValidatorEnable(document.getElementById("<%=rfvfuChequeLoan.ClientID %>"), true);
                    ValidatorEnable(document.getElementById("<%=rfvtxtfuNEFTLoan.ClientID %>"), false);

                }
                $('.loan').show()
                $('.Cheque').hide();
                $('.neft').hide();

                $("#divCheque").css({ 'display': 'none' });
                $("#divNEFT").css({ 'display': 'none' });

                var ddlLMM = document.getElementById("<%=ddlLoanMarginMode.ClientID %>");
                var ddlLMMVal = ddlLMM.value;
                if (ddlLMMVal == "0") {
                    $('.Loan_Cheque').hide();
                    $('.neft_Loan').hide();
                }
                else {
                    if (ddlLMMVal == "Cheque") {
                        $('.Loan_Cheque').show();
                        $('.neft_Loan').hide();
                        ValidatorEnable(document.getElementById("<%=rfvddlChequeBankNameLoan.ClientID %>"), true);
                        ValidatorEnable(document.getElementById("<%=rfvtxtChequeBankNameLoan.ClientID %>"), true);
                        ValidatorEnable(document.getElementById("<%=rfvtxtChequeBranchNameLoan.ClientID %>"), true);//txtChequeAccNo
                        ValidatorEnable(document.getElementById("<%=rfvtxtChequeAccNoLoan.ClientID %>"), true);//txtChequeAccNo                    
                        ValidatorEnable(document.getElementById("<%=rfvtxtChequeIFSCLoan.ClientID %>"), true);
                        ValidatorEnable(document.getElementById("<%=rfvtxtChequeAmountLoan.ClientID %>"), true);
                        ValidatorEnable(document.getElementById("<%=rfvtxtChequeDateLoan.ClientID %>"), true);
                        ValidatorEnable(document.getElementById("<%=rfvtxtChequeNoLoan.ClientID %>"), true);

                        ValidatorEnable(document.getElementById("<%=rfvddlNEFTBankNameLoan.ClientID %>"), false);
                        ValidatorEnable(document.getElementById("<%=rfvtxtNEFTAccNoLoan.ClientID %>"), false);
                        ValidatorEnable(document.getElementById("<%=rfvtxtNEFTBankNameLoan.ClientID %>"), false);
                        ValidatorEnable(document.getElementById("<%=rfvtxtNEFTBranchNameLoan.ClientID %>"), false);
                        ValidatorEnable(document.getElementById("<%=rfvtxtNEFTIFSCLoan.ClientID %>"), false);
                        ValidatorEnable(document.getElementById("<%=rfvtxtNEFTUTRLoan.ClientID %>"), false);
                    }
                    else {
                        $('.Loan_Cheque').hide();
                        $('.neft_Loan').show();
                        ValidatorEnable(document.getElementById("<%=rfvddlChequeBankNameLoan.ClientID %>"), false);
                        ValidatorEnable(document.getElementById("<%=rfvtxtChequeBankNameLoan.ClientID %>"), false);
                        ValidatorEnable(document.getElementById("<%=rfvtxtChequeBranchNameLoan.ClientID %>"), false);//txtChequeAccNo
                        ValidatorEnable(document.getElementById("<%=rfvtxtChequeAccNoLoan.ClientID %>"), false);//txtChequeAccNo                    
                        ValidatorEnable(document.getElementById("<%=rfvtxtChequeIFSCLoan.ClientID %>"), false);
                        ValidatorEnable(document.getElementById("<%=rfvtxtChequeAmountLoan.ClientID %>"), false);
                        ValidatorEnable(document.getElementById("<%=rfvtxtChequeDateLoan.ClientID %>"), false);
                        ValidatorEnable(document.getElementById("<%=rfvtxtChequeNoLoan.ClientID %>"), false);

                        ValidatorEnable(document.getElementById("<%=rfvddlNEFTBankNameLoan.ClientID %>"), true);
                        ValidatorEnable(document.getElementById("<%=rfvtxtNEFTAccNoLoan.ClientID %>"), true);
                        ValidatorEnable(document.getElementById("<%=rfvtxtNEFTBankNameLoan.ClientID %>"), true);
                        ValidatorEnable(document.getElementById("<%=rfvtxtNEFTBranchNameLoan.ClientID %>"), true);
                        ValidatorEnable(document.getElementById("<%=rfvtxtNEFTIFSCLoan.ClientID %>"), true);
                        ValidatorEnable(document.getElementById("<%=rfvtxtNEFTUTRLoan.ClientID %>"), true);
                    }
                }

            }
};
    </script>
    <script>
        $(document).ready(function radioValue() {
            var prm = Sys.WebForms.PageRequestManager.getInstance();
<%--            prm.add_endRequest(function (s, e) {
				var radioValue = $("input[name='customRadioInline3']:checked").val();
				console.log(radioValue);
				alert('radioValue_1');
				if (radioValue == "Cheque") {
					ValidatorEnable(document.getElementById("<%=rfvddlChequeBankName.ClientID %>"), true);

					ValidatorEnable(document.getElementById("<%=rfvtxtChequeBankName.ClientID %>"), true);
					ValidatorEnable(document.getElementById("<%=rfvtxtChequeBranchName.ClientID %>"), true);//txtChequeAccNo                  
					ValidatorEnable(document.getElementById("<%=rfvtxtChequeIFSC.ClientID %>"), true);
					ValidatorEnable(document.getElementById("<%=rfvtxtChequeAmount.ClientID %>"), true);
					ValidatorEnable(document.getElementById("<%=rfvtxtChequeDate.ClientID %>"), true);
					ValidatorEnable(document.getElementById("<%=rfvtxtChequeNo.ClientID %>"), true);
					ValidatorEnable(document.getElementById("<%=rfvtxtChequeAccNo.ClientID %>"), true);//txtChequeAccNo

					ValidatorEnable(document.getElementById("<%=rfvddlNEFTBankName.ClientID %>"), false);
					ValidatorEnable(document.getElementById("<%=rfvtxtNEFTAccNo.ClientID %>"), false);
					ValidatorEnable(document.getElementById("<%=rfvtxtNEFTBankName.ClientID %>"), false);
					ValidatorEnable(document.getElementById("<%=rfvtxtNEFTBranchName.ClientID %>"), false);
					ValidatorEnable(document.getElementById("<%=rfvtxtNEFTIFSC.ClientID %>"), false);
					ValidatorEnable(document.getElementById("<%=rfvtxtNEFTUTR.ClientID %>"), false);

					ValidatorEnable(document.getElementById("<%=rfvtxtLoanAmount.ClientID %>"), false);
					ValidatorEnable(document.getElementById("<%=rfvtxtLoanBankName.ClientID %>"), false);
					ValidatorEnable(document.getElementById("<%=rfvtxtLoanMarginAmount.ClientID %>"), false);
					ValidatorEnable(document.getElementById("<%=rfvddlLoanMarginMode.ClientID %>"), false);

					ValidatorEnable(document.getElementById("<%=rfvddlChequeBankNameLoan.ClientID %>"), false);
					ValidatorEnable(document.getElementById("<%=rfvtxtChequeBankNameLoan.ClientID %>"), false);
					ValidatorEnable(document.getElementById("<%=rfvtxtChequeBranchNameLoan.ClientID %>"), false);//txtChequeAccNo
					ValidatorEnable(document.getElementById("<%=rfvtxtChequeAccNoLoan.ClientID %>"), false);//txtChequeAccNo                    
					ValidatorEnable(document.getElementById("<%=rfvtxtChequeIFSCLoan.ClientID %>"), false);
					ValidatorEnable(document.getElementById("<%=rfvtxtChequeAmountLoan.ClientID %>"), false);
					ValidatorEnable(document.getElementById("<%=rfvtxtChequeDateLoan.ClientID %>"), false);
					ValidatorEnable(document.getElementById("<%=rfvtxtChequeNoLoan.ClientID %>"), false);

					ValidatorEnable(document.getElementById("<%=rfvddlNEFTBankNameLoan.ClientID %>"), false);
					ValidatorEnable(document.getElementById("<%=rfvtxtNEFTAccNoLoan.ClientID %>"), false);
					ValidatorEnable(document.getElementById("<%=rfvtxtNEFTBankNameLoan.ClientID %>"), false);
					ValidatorEnable(document.getElementById("<%=rfvtxtNEFTBranchNameLoan.ClientID %>"), false);
					ValidatorEnable(document.getElementById("<%=rfvtxtNEFTIFSCLoan.ClientID %>"), false);
					ValidatorEnable(document.getElementById("<%=rfvtxtNEFTUTRLoan.ClientID %>"), false);

					ValidatorEnable(document.getElementById("<%=rfvtxtfuCheque.ClientID %>"), true);
					ValidatorEnable(document.getElementById("<%=rfvtxtfuNEFT1.ClientID %>"), false);
					ValidatorEnable(document.getElementById("<%=rfvfuChequeLoan.ClientID %>"), false);
					ValidatorEnable(document.getElementById("<%=rfvtxtfuNEFTLoan.ClientID %>"), false);



					$('.Cheque').show()
					$('.neft').hide();
					$('.loan').hide();
					$('.neft_Loan').hide();
				}
				else if 
				   (radioValue == "neft") {

					ValidatorEnable(document.getElementById("<%=rfvddlChequeBankName.ClientID %>"), false);
					ValidatorEnable(document.getElementById("<%=rfvtxtChequeBankName.ClientID %>"), false);
					ValidatorEnable(document.getElementById("<%=rfvtxtChequeBranchName.ClientID %>"), false);//txtChequeAccNo
					ValidatorEnable(document.getElementById("<%=rfvtxtChequeAccNo.ClientID %>"), false);//txtChequeAccNo
					ValidatorEnable(document.getElementById("<%=rfvtxtChequeAmount.ClientID %>"), false);
					ValidatorEnable(document.getElementById("<%=rfvtxtChequeDate.ClientID %>"), false);
					ValidatorEnable(document.getElementById("<%=rfvtxtChequeIFSC.ClientID %>"), false);
					ValidatorEnable(document.getElementById("<%=rfvtxtChequeNo.ClientID %>"), false);

					ValidatorEnable(document.getElementById("<%=rfvddlNEFTBankName.ClientID %>"), true);
					ValidatorEnable(document.getElementById("<%=rfvtxtNEFTAccNo.ClientID %>"), true);
					ValidatorEnable(document.getElementById("<%=rfvtxtNEFTBankName.ClientID %>"), true);
					ValidatorEnable(document.getElementById("<%=rfvtxtNEFTBranchName.ClientID %>"), true);
					ValidatorEnable(document.getElementById("<%=rfvtxtNEFTIFSC.ClientID %>"), true);
					ValidatorEnable(document.getElementById("<%=rfvtxtNEFTUTR.ClientID %>"), true);

					ValidatorEnable(document.getElementById("<%=rfvtxtLoanAmount.ClientID %>"), false);
					ValidatorEnable(document.getElementById("<%=rfvtxtLoanBankName.ClientID %>"), false);
					ValidatorEnable(document.getElementById("<%=rfvtxtLoanMarginAmount.ClientID %>"), false);
					ValidatorEnable(document.getElementById("<%=rfvddlLoanMarginMode.ClientID %>"), false);

					ValidatorEnable(document.getElementById("<%=rfvddlChequeBankNameLoan.ClientID %>"), false);
					ValidatorEnable(document.getElementById("<%=rfvtxtChequeBankNameLoan.ClientID %>"), false);
					ValidatorEnable(document.getElementById("<%=rfvtxtChequeBranchNameLoan.ClientID %>"), false);//txtChequeAccNo
					ValidatorEnable(document.getElementById("<%=rfvtxtChequeAccNoLoan.ClientID %>"), false);//txtChequeAccNo                    
					ValidatorEnable(document.getElementById("<%=rfvtxtChequeIFSCLoan.ClientID %>"), false);
					ValidatorEnable(document.getElementById("<%=rfvtxtChequeAmountLoan.ClientID %>"), false);
					ValidatorEnable(document.getElementById("<%=rfvtxtChequeDateLoan.ClientID %>"), false);
					ValidatorEnable(document.getElementById("<%=rfvtxtChequeNoLoan.ClientID %>"), false);

					ValidatorEnable(document.getElementById("<%=rfvddlNEFTBankNameLoan.ClientID %>"), false);
					ValidatorEnable(document.getElementById("<%=rfvtxtNEFTAccNoLoan.ClientID %>"), false);
					ValidatorEnable(document.getElementById("<%=rfvtxtNEFTBankNameLoan.ClientID %>"), false);
					ValidatorEnable(document.getElementById("<%=rfvtxtNEFTBranchNameLoan.ClientID %>"), false);
					ValidatorEnable(document.getElementById("<%=rfvtxtNEFTIFSCLoan.ClientID %>"), false);
					ValidatorEnable(document.getElementById("<%=rfvtxtNEFTUTRLoan.ClientID %>"), false);

					ValidatorEnable(document.getElementById("<%=rfvtxtfuCheque.ClientID %>"), false);
					ValidatorEnable(document.getElementById("<%=rfvtxtfuNEFT1.ClientID %>"), true);
					ValidatorEnable(document.getElementById("<%=rfvfuChequeLoan.ClientID %>"), false);
					ValidatorEnable(document.getElementById("<%=rfvtxtfuNEFTLoan.ClientID %>"), false);


					$('.neft').show()
					$('.Cheque').hide();
					$('.loan').hide();
					$('.Loan_Cheque').hide();
					$('.neft_Loan').hide();
				}

				else if
					(radioValue == "loan") {

					ValidatorEnable(document.getElementById("<%=rfvddlChequeBankName.ClientID %>"), false);
					ValidatorEnable(document.getElementById("<%=rfvtxtChequeBankName.ClientID %>"), false);
					ValidatorEnable(document.getElementById("<%=rfvtxtChequeBranchName.ClientID %>"), false);//txtChequeAccNo
					ValidatorEnable(document.getElementById("<%=rfvtxtChequeAccNo.ClientID %>"), false);//txtChequeAccNo                    
					ValidatorEnable(document.getElementById("<%=rfvtxtChequeIFSC.ClientID %>"), false);
					ValidatorEnable(document.getElementById("<%=rfvtxtChequeAmount.ClientID %>"), false);
					ValidatorEnable(document.getElementById("<%=rfvtxtChequeDate.ClientID %>"), false);
					ValidatorEnable(document.getElementById("<%=rfvtxtChequeNo.ClientID %>"), false);

					ValidatorEnable(document.getElementById("<%=rfvddlNEFTBankName.ClientID %>"), false);
					ValidatorEnable(document.getElementById("<%=rfvtxtNEFTAccNo.ClientID %>"), false);
					ValidatorEnable(document.getElementById("<%=rfvtxtNEFTBankName.ClientID %>"), false);
					ValidatorEnable(document.getElementById("<%=rfvtxtNEFTBranchName.ClientID %>"), false);
					ValidatorEnable(document.getElementById("<%=rfvtxtNEFTIFSC.ClientID %>"), false);
					ValidatorEnable(document.getElementById("<%=rfvtxtNEFTUTR.ClientID %>"), false);

					ValidatorEnable(document.getElementById("<%=rfvtxtLoanAmount.ClientID %>"), true);
					ValidatorEnable(document.getElementById("<%=rfvtxtLoanBankName.ClientID %>"), true);
					ValidatorEnable(document.getElementById("<%=rfvtxtLoanMarginAmount.ClientID %>"), true);
					ValidatorEnable(document.getElementById("<%=rfvddlLoanMarginMode.ClientID %>"), true);

					ValidatorEnable(document.getElementById("<%=rfvtxtfuCheque.ClientID %>"), false);
					ValidatorEnable(document.getElementById("<%=rfvtxtfuNEFT1.ClientID %>"), false);

					if (document.getElementById("<%=ddlLoanMarginMode.ClientID %>").value == 'NEFT') {
						ValidatorEnable(document.getElementById("<%=rfvfuChequeLoan.ClientID %>"), false);
						ValidatorEnable(document.getElementById("<%=rfvtxtfuNEFTLoan.ClientID %>"), true);
					}
					else {
						ValidatorEnable(document.getElementById("<%=rfvfuChequeLoan.ClientID %>"), true);
						ValidatorEnable(document.getElementById("<%=rfvtxtfuNEFTLoan.ClientID %>"), false);

					}

					$('.loan').show()
					$('.Cheque').hide();
					$('.neft').hide();
					var ddlLMM = document.getElementById("<%=ddlLoanMarginMode.ClientID %>");
					var ddlLMMVal = ddlLMM.value;
					if (ddlLMMVal == "0") {
						$('.Loan_Cheque').hide();
						$('.neft_Loan').hide();
					}
					else {
						if (ddlLMMVal == "Cheque") {
							$('.Loan_Cheque').show();
							$('.neft_Loan').hide();
							ValidatorEnable(document.getElementById("<%=rfvddlChequeBankNameLoan.ClientID %>"), true);
							ValidatorEnable(document.getElementById("<%=rfvtxtChequeBankNameLoan.ClientID %>"), true);
							ValidatorEnable(document.getElementById("<%=rfvtxtChequeBranchNameLoan.ClientID %>"), true);//txtChequeAccNo
							ValidatorEnable(document.getElementById("<%=rfvtxtChequeAccNoLoan.ClientID %>"), true);//txtChequeAccNo                    
							ValidatorEnable(document.getElementById("<%=rfvtxtChequeIFSCLoan.ClientID %>"), true);
							ValidatorEnable(document.getElementById("<%=rfvtxtChequeAmountLoan.ClientID %>"), true);
							ValidatorEnable(document.getElementById("<%=rfvtxtChequeDateLoan.ClientID %>"), true);
							ValidatorEnable(document.getElementById("<%=rfvtxtChequeNoLoan.ClientID %>"), true);

							ValidatorEnable(document.getElementById("<%=rfvddlNEFTBankNameLoan.ClientID %>"), false);
							ValidatorEnable(document.getElementById("<%=rfvtxtNEFTAccNoLoan.ClientID %>"), false);
							ValidatorEnable(document.getElementById("<%=rfvtxtNEFTBankNameLoan.ClientID %>"), false);
							ValidatorEnable(document.getElementById("<%=rfvtxtNEFTBranchNameLoan.ClientID %>"), false);
							ValidatorEnable(document.getElementById("<%=rfvtxtNEFTIFSCLoan.ClientID %>"), false);
							ValidatorEnable(document.getElementById("<%=rfvtxtNEFTUTRLoan.ClientID %>"), false);
						}
						else {
							$('.Loan_Cheque').hide();
							$('.neft_Loan').show();
							ValidatorEnable(document.getElementById("<%=rfvddlChequeBankNameLoan.ClientID %>"), false);
							ValidatorEnable(document.getElementById("<%=rfvtxtChequeBankNameLoan.ClientID %>"), false);
							ValidatorEnable(document.getElementById("<%=rfvtxtChequeBranchNameLoan.ClientID %>"), false);//txtChequeAccNo
							ValidatorEnable(document.getElementById("<%=rfvtxtChequeAccNoLoan.ClientID %>"), false);//txtChequeAccNo                    
							ValidatorEnable(document.getElementById("<%=rfvtxtChequeIFSCLoan.ClientID %>"), false);
							ValidatorEnable(document.getElementById("<%=rfvtxtChequeAmountLoan.ClientID %>"), false);
							ValidatorEnable(document.getElementById("<%=rfvtxtChequeDateLoan.ClientID %>"), false);
							ValidatorEnable(document.getElementById("<%=rfvtxtChequeNoLoan.ClientID %>"), false);

							ValidatorEnable(document.getElementById("<%=rfvddlNEFTBankNameLoan.ClientID %>"), true);
							ValidatorEnable(document.getElementById("<%=rfvtxtNEFTAccNoLoan.ClientID %>"), true);
							ValidatorEnable(document.getElementById("<%=rfvtxtNEFTBankNameLoan.ClientID %>"), true);
							ValidatorEnable(document.getElementById("<%=rfvtxtNEFTBranchNameLoan.ClientID %>"), true);
							ValidatorEnable(document.getElementById("<%=rfvtxtNEFTIFSCLoan.ClientID %>"), true);
							ValidatorEnable(document.getElementById("<%=rfvtxtNEFTUTRLoan.ClientID %>"), true);
						}
					}

				}
				else {
					ValidatorEnable(document.getElementById("<%=rfvddlChequeBankName.ClientID %>"), false);
					ValidatorEnable(document.getElementById("<%=rfvtxtChequeBankName.ClientID %>"), false);
					ValidatorEnable(document.getElementById("<%=rfvtxtChequeBranchName.ClientID %>"), false);
					ValidatorEnable(document.getElementById("<%=rfvtxtChequeAccNo.ClientID %>"), false);                  
					ValidatorEnable(document.getElementById("<%=rfvtxtChequeIFSC.ClientID %>"), false);
					ValidatorEnable(document.getElementById("<%=rfvtxtChequeAmount.ClientID %>"), false);
					ValidatorEnable(document.getElementById("<%=rfvtxtChequeDate.ClientID %>"), false);
					ValidatorEnable(document.getElementById("<%=rfvtxtChequeNo.ClientID %>"), false);

					ValidatorEnable(document.getElementById("<%=rfvddlNEFTBankName.ClientID %>"), false);
					ValidatorEnable(document.getElementById("<%=rfvtxtNEFTAccNo.ClientID %>"), false);
					ValidatorEnable(document.getElementById("<%=rfvtxtNEFTBankName.ClientID %>"), false);
					ValidatorEnable(document.getElementById("<%=rfvtxtNEFTBranchName.ClientID %>"), false);
					ValidatorEnable(document.getElementById("<%=rfvtxtNEFTIFSC.ClientID %>"), false);
					ValidatorEnable(document.getElementById("<%=rfvtxtNEFTUTR.ClientID %>"), false);

					ValidatorEnable(document.getElementById("<%=rfvtxtLoanAmount.ClientID %>"), false);
					ValidatorEnable(document.getElementById("<%=rfvtxtLoanBankName.ClientID %>"), false);
					ValidatorEnable(document.getElementById("<%=rfvtxtLoanMarginAmount.ClientID %>"), false);
					ValidatorEnable(document.getElementById("<%=rfvddlLoanMarginMode.ClientID %>"), false);

					ValidatorEnable(document.getElementById("<%=rfvddlChequeBankNameLoan.ClientID %>"), false);
					ValidatorEnable(document.getElementById("<%=rfvtxtChequeBankNameLoan.ClientID %>"), false);
					ValidatorEnable(document.getElementById("<%=rfvtxtChequeBranchNameLoan.ClientID %>"), false);
					ValidatorEnable(document.getElementById("<%=rfvtxtChequeAccNoLoan.ClientID %>"), false);                 
					ValidatorEnable(document.getElementById("<%=rfvtxtChequeIFSCLoan.ClientID %>"), false);
					ValidatorEnable(document.getElementById("<%=rfvtxtChequeAmountLoan.ClientID %>"), false);
					ValidatorEnable(document.getElementById("<%=rfvtxtChequeDateLoan.ClientID %>"), false);
					ValidatorEnable(document.getElementById("<%=rfvtxtChequeNoLoan.ClientID %>"), false);

					ValidatorEnable(document.getElementById("<%=rfvddlNEFTBankNameLoan.ClientID %>"), false);
					ValidatorEnable(document.getElementById("<%=rfvtxtNEFTAccNoLoan.ClientID %>"), false);
					ValidatorEnable(document.getElementById("<%=rfvtxtNEFTBankNameLoan.ClientID %>"), false);
					ValidatorEnable(document.getElementById("<%=rfvtxtNEFTBranchNameLoan.ClientID %>"), false);
					ValidatorEnable(document.getElementById("<%=rfvtxtNEFTIFSCLoan.ClientID %>"), false);
					ValidatorEnable(document.getElementById("<%=rfvtxtNEFTUTRLoan.ClientID %>"), false);
				}--%>

            $("input[type='radio']").click(function () {
                /**$("input[name='customRadioInline3']").change(function() {**/

                var radioValue = $("input[name='customRadioInline3']:checked").val();
                console.log(radioValue);
                if (radioValue == "Cheque") {
                    ValidatorEnable(document.getElementById("<%=rfvddlChequeBankName.ClientID %>"), true);
                    ValidatorEnable(document.getElementById("<%=rfvtxtChequeBankName.ClientID %>"), true);
                    ValidatorEnable(document.getElementById("<%=rfvtxtChequeBranchName.ClientID %>"), true);//txtChequeAccNo
                    ValidatorEnable(document.getElementById("<%=rfvtxtChequeAccNo.ClientID %>"), true);//txtChequeAccNo                        
                    ValidatorEnable(document.getElementById("<%=rfvtxtChequeIFSC.ClientID %>"), true);
                    ValidatorEnable(document.getElementById("<%=rfvtxtChequeAmount.ClientID %>"), true);
                    ValidatorEnable(document.getElementById("<%=rfvtxtChequeDate.ClientID %>"), true);
                    ValidatorEnable(document.getElementById("<%=rfvtxtChequeNo.ClientID %>"), true);

                    ValidatorEnable(document.getElementById("<%=rfvddlNEFTBankName.ClientID %>"), false);
                    ValidatorEnable(document.getElementById("<%=rfvtxtNEFTAccNo.ClientID %>"), false);
                    ValidatorEnable(document.getElementById("<%=rfvtxtNEFTBankName.ClientID %>"), false);
                    ValidatorEnable(document.getElementById("<%=rfvtxtNEFTBranchName.ClientID %>"), false);
                    ValidatorEnable(document.getElementById("<%=rfvtxtNEFTIFSC.ClientID %>"), false);
                    ValidatorEnable(document.getElementById("<%=rfvtxtNEFTUTR.ClientID %>"), false);

                    ValidatorEnable(document.getElementById("<%=rfvtxtLoanAmount.ClientID %>"), false);
                    ValidatorEnable(document.getElementById("<%=rfvtxtLoanBankName.ClientID %>"), false);
                    ValidatorEnable(document.getElementById("<%=rfvtxtLoanMarginAmount.ClientID %>"), false);
                    ValidatorEnable(document.getElementById("<%=rfvddlLoanMarginMode.ClientID %>"), false);

                    ValidatorEnable(document.getElementById("<%=rfvddlChequeBankNameLoan.ClientID %>"), false);
                    ValidatorEnable(document.getElementById("<%=rfvtxtChequeBankNameLoan.ClientID %>"), false);
                    ValidatorEnable(document.getElementById("<%=rfvtxtChequeBranchNameLoan.ClientID %>"), false);//txtChequeAccNo
                    ValidatorEnable(document.getElementById("<%=rfvtxtChequeAccNoLoan.ClientID %>"), false);//txtChequeAccNo                    
                    ValidatorEnable(document.getElementById("<%=rfvtxtChequeIFSCLoan.ClientID %>"), false);
                    ValidatorEnable(document.getElementById("<%=rfvtxtChequeAmountLoan.ClientID %>"), false);
                    ValidatorEnable(document.getElementById("<%=rfvtxtChequeDateLoan.ClientID %>"), false);
                    ValidatorEnable(document.getElementById("<%=rfvtxtChequeNoLoan.ClientID %>"), false);

                    ValidatorEnable(document.getElementById("<%=rfvddlNEFTBankNameLoan.ClientID %>"), false);
                    ValidatorEnable(document.getElementById("<%=rfvtxtNEFTAccNoLoan.ClientID %>"), false);
                    ValidatorEnable(document.getElementById("<%=rfvtxtNEFTBankNameLoan.ClientID %>"), false);
                    ValidatorEnable(document.getElementById("<%=rfvtxtNEFTBranchNameLoan.ClientID %>"), false);
                    ValidatorEnable(document.getElementById("<%=rfvtxtNEFTIFSCLoan.ClientID %>"), false);
                    ValidatorEnable(document.getElementById("<%=rfvtxtNEFTUTRLoan.ClientID %>"), false);

                    $('.Cheque').show()
                    $('.neft').hide();
                    $('.loan').hide();
                    //alert('loan hide 1');
                    $('.Loan_Cheque').hide();
                    $('.neft_Loan').hide();

                    $("#divNEFT").css({ 'display': 'none' });
                    $("#divChequeLoan").css({ 'display': 'none' });
                    $("#divNEFTLoan").css({ 'display': 'none' });


                }
                else if
				   (radioValue == "neft") {

                    ValidatorEnable(document.getElementById("<%=rfvddlChequeBankName.ClientID %>"), false);
                    ValidatorEnable(document.getElementById("<%=rfvtxtChequeBankName.ClientID %>"), false);
                    ValidatorEnable(document.getElementById("<%=rfvtxtChequeBranchName.ClientID %>"), false);//txtChequeAccNo
                    ValidatorEnable(document.getElementById("<%=rfvtxtChequeAccNo.ClientID %>"), false);//txtChequeAccNo                        
                    ValidatorEnable(document.getElementById("<%=rfvtxtChequeIFSC.ClientID %>"), false);
                    ValidatorEnable(document.getElementById("<%=rfvtxtChequeAmount.ClientID %>"), false);
                    ValidatorEnable(document.getElementById("<%=rfvtxtChequeDate.ClientID %>"), false);
                    ValidatorEnable(document.getElementById("<%=rfvtxtChequeNo.ClientID %>"), false);

                    ValidatorEnable(document.getElementById("<%=rfvddlNEFTBankName.ClientID %>"), true);
                    ValidatorEnable(document.getElementById("<%=rfvtxtNEFTAccNo.ClientID %>"), true);
                    ValidatorEnable(document.getElementById("<%=rfvtxtNEFTBankName.ClientID %>"), true);
                    ValidatorEnable(document.getElementById("<%=rfvtxtNEFTBranchName.ClientID %>"), true);
                    ValidatorEnable(document.getElementById("<%=rfvtxtNEFTIFSC.ClientID %>"), true);
                    ValidatorEnable(document.getElementById("<%=rfvtxtNEFTUTR.ClientID %>"), true);

                    ValidatorEnable(document.getElementById("<%=rfvtxtLoanAmount.ClientID %>"), false);
                    ValidatorEnable(document.getElementById("<%=rfvtxtLoanBankName.ClientID %>"), false);
                    ValidatorEnable(document.getElementById("<%=rfvtxtLoanMarginAmount.ClientID %>"), false);
                    ValidatorEnable(document.getElementById("<%=rfvddlLoanMarginMode.ClientID %>"), false);

                    ValidatorEnable(document.getElementById("<%=rfvddlChequeBankNameLoan.ClientID %>"), false);
                    ValidatorEnable(document.getElementById("<%=rfvtxtChequeBankNameLoan.ClientID %>"), false);
                    ValidatorEnable(document.getElementById("<%=rfvtxtChequeBranchNameLoan.ClientID %>"), false);//txtChequeAccNo
                    ValidatorEnable(document.getElementById("<%=rfvtxtChequeAccNoLoan.ClientID %>"), false);//txtChequeAccNo                    
                    ValidatorEnable(document.getElementById("<%=rfvtxtChequeIFSCLoan.ClientID %>"), false);
                    ValidatorEnable(document.getElementById("<%=rfvtxtChequeAmountLoan.ClientID %>"), false);
                    ValidatorEnable(document.getElementById("<%=rfvtxtChequeDateLoan.ClientID %>"), false);
                    ValidatorEnable(document.getElementById("<%=rfvtxtChequeNoLoan.ClientID %>"), false);

                    ValidatorEnable(document.getElementById("<%=rfvddlNEFTBankNameLoan.ClientID %>"), false);
                    ValidatorEnable(document.getElementById("<%=rfvtxtNEFTAccNoLoan.ClientID %>"), false);
                    ValidatorEnable(document.getElementById("<%=rfvtxtNEFTBankNameLoan.ClientID %>"), false);
                    ValidatorEnable(document.getElementById("<%=rfvtxtNEFTBranchNameLoan.ClientID %>"), false);
                    ValidatorEnable(document.getElementById("<%=rfvtxtNEFTIFSCLoan.ClientID %>"), false);
                    ValidatorEnable(document.getElementById("<%=rfvtxtNEFTUTRLoan.ClientID %>"), false);

                    $('.neft').show()
                    $('.Cheque').hide();
                    //alert('loan hide 2');
                    $('.loan').hide();
                    $('.Loan_Cheque').hide();
                    $('.neft_Loan').hide();

                    $("#divCheque").css({ 'display': 'none' });
                    $("#divChequeLoan").css({ 'display': 'none' });
                    $("#divNEFTLoan").css({ 'display': 'none' });


                }

                else if 
					(radioValue == "loan") {
                    //alert('Loan_2');

                    ValidatorEnable(document.getElementById("<%=rfvddlChequeBankName.ClientID %>"), false);
                    ValidatorEnable(document.getElementById("<%=rfvtxtChequeBankName.ClientID %>"), false);
                    ValidatorEnable(document.getElementById("<%=rfvtxtChequeBranchName.ClientID %>"), false);//txtChequeAccNo
                    ValidatorEnable(document.getElementById("<%=rfvtxtChequeAccNo.ClientID %>"), false);//txtChequeAccNo                       
                    ValidatorEnable(document.getElementById("<%=rfvtxtChequeIFSC.ClientID %>"), false);
                    ValidatorEnable(document.getElementById("<%=rfvtxtChequeAmount.ClientID %>"), false);
                    ValidatorEnable(document.getElementById("<%=rfvtxtChequeDate.ClientID %>"), false);
                    ValidatorEnable(document.getElementById("<%=rfvtxtChequeNo.ClientID %>"), false);

                    ValidatorEnable(document.getElementById("<%=rfvddlNEFTBankName.ClientID %>"), false);
                    ValidatorEnable(document.getElementById("<%=rfvtxtNEFTAccNo.ClientID %>"), false);
                    ValidatorEnable(document.getElementById("<%=rfvtxtNEFTBankName.ClientID %>"), false);
                    ValidatorEnable(document.getElementById("<%=rfvtxtNEFTBranchName.ClientID %>"), false);
                    ValidatorEnable(document.getElementById("<%=rfvtxtNEFTIFSC.ClientID %>"), false);
                    ValidatorEnable(document.getElementById("<%=rfvtxtNEFTUTR.ClientID %>"), false);

                    ValidatorEnable(document.getElementById("<%=rfvtxtLoanAmount.ClientID %>"), true);
                    ValidatorEnable(document.getElementById("<%=rfvtxtLoanBankName.ClientID %>"), true);
                    ValidatorEnable(document.getElementById("<%=rfvtxtLoanMarginAmount.ClientID %>"), true);
                    ValidatorEnable(document.getElementById("<%=rfvddlLoanMarginMode.ClientID %>"), true);

                    $('.loan').show()
                    $('.Cheque').hide();
                    $('.neft').hide();

                    $("#divCheque").css({ 'display': 'none' });
                    $("#divNEFT").css({ 'display': 'none' });


                    var ddlLMM = document.getElementById("<%=ddlLoanMarginMode.ClientID %>");
                    var ddlLMMVal = ddlLMM.value;
                    if (ddlLMMVal == "0") {
                        $('.Loan_Cheque').hide();
                        $('.neft_Loan').hide();
                    }
                    else {
                        if (ddlLMMVal == "Cheque") {
                            $('.Loan_Cheque').show();
                            $('.neft_Loan').hide();
                            ValidatorEnable(document.getElementById("<%=rfvddlChequeBankNameLoan.ClientID %>"), true);
                            ValidatorEnable(document.getElementById("<%=rfvtxtChequeBankNameLoan.ClientID %>"), true);
                            ValidatorEnable(document.getElementById("<%=rfvtxtChequeBranchNameLoan.ClientID %>"), true);//txtChequeAccNo
                            ValidatorEnable(document.getElementById("<%=rfvtxtChequeAccNoLoan.ClientID %>"), true);//txtChequeAccNo                    
                            ValidatorEnable(document.getElementById("<%=rfvtxtChequeIFSCLoan.ClientID %>"), true);
                            ValidatorEnable(document.getElementById("<%=rfvtxtChequeAmountLoan.ClientID %>"), true);
                            ValidatorEnable(document.getElementById("<%=rfvtxtChequeDateLoan.ClientID %>"), true);
                            ValidatorEnable(document.getElementById("<%=rfvtxtChequeNoLoan.ClientID %>"), true);

                            ValidatorEnable(document.getElementById("<%=rfvddlNEFTBankNameLoan.ClientID %>"), false);
                            ValidatorEnable(document.getElementById("<%=rfvtxtNEFTAccNoLoan.ClientID %>"), false);
                            ValidatorEnable(document.getElementById("<%=rfvtxtNEFTBankNameLoan.ClientID %>"), false);
                            ValidatorEnable(document.getElementById("<%=rfvtxtNEFTBranchNameLoan.ClientID %>"), false);
                            ValidatorEnable(document.getElementById("<%=rfvtxtNEFTIFSCLoan.ClientID %>"), false);
                            ValidatorEnable(document.getElementById("<%=rfvtxtNEFTUTRLoan.ClientID %>"), false);
                        }
                        else {
                            $('.Loan_Cheque').hide();
                            $('.neft_Loan').show();
                            ValidatorEnable(document.getElementById("<%=rfvddlChequeBankNameLoan.ClientID %>"), false);
		                    ValidatorEnable(document.getElementById("<%=rfvtxtChequeBankNameLoan.ClientID %>"), false);
                            ValidatorEnable(document.getElementById("<%=rfvtxtChequeBranchNameLoan.ClientID %>"), false);//txtChequeAccNo
                            ValidatorEnable(document.getElementById("<%=rfvtxtChequeAccNoLoan.ClientID %>"), false);//txtChequeAccNo                    
                            ValidatorEnable(document.getElementById("<%=rfvtxtChequeIFSCLoan.ClientID %>"), false);
                            ValidatorEnable(document.getElementById("<%=rfvtxtChequeAmountLoan.ClientID %>"), false);
                            ValidatorEnable(document.getElementById("<%=rfvtxtChequeDateLoan.ClientID %>"), false);
                            ValidatorEnable(document.getElementById("<%=rfvtxtChequeNoLoan.ClientID %>"), false);

                            ValidatorEnable(document.getElementById("<%=rfvddlNEFTBankNameLoan.ClientID %>"), true);
                            ValidatorEnable(document.getElementById("<%=rfvtxtNEFTAccNoLoan.ClientID %>"), true);
                            ValidatorEnable(document.getElementById("<%=rfvtxtNEFTBankNameLoan.ClientID %>"), true);
                            ValidatorEnable(document.getElementById("<%=rfvtxtNEFTBranchNameLoan.ClientID %>"), true);
                            ValidatorEnable(document.getElementById("<%=rfvtxtNEFTIFSCLoan.ClientID %>"), true);
                            ValidatorEnable(document.getElementById("<%=rfvtxtNEFTUTRLoan.ClientID %>"), true);
                        }
                    }

                }

            });
        });
debugger;
$('.Cheque').hide();
$('.neft').hide();
$('.loan').hide();

$("#divCheque").css({ 'display': 'none' });
$("#divNEFT").css({ 'display': 'none' });
$("#divChequeLoan").css({ 'display': 'none' });
$("#divNEFTLoan").css({ 'display': 'none' });

//alert('loan hide 3');
$('.Loan_Cheque').hide();
$('.neft_Loan').hide();//rfvddlNEFTBankName
ValidatorEnable(document.getElementById("<%=rfvddlChequeBankName.ClientID %>"), false);
ValidatorEnable(document.getElementById("<%=rfvtxtChequeBankName.ClientID %>"), false);
        ValidatorEnable(document.getElementById("<%=rfvtxtChequeBranchName.ClientID %>"), false);//txtChequeAccNo
        ValidatorEnable(document.getElementById("<%=rfvtxtChequeAccNo.ClientID %>"), false);//txtChequeAccNo           
        ValidatorEnable(document.getElementById("<%=rfvtxtChequeIFSC.ClientID %>"), false);
        ValidatorEnable(document.getElementById("<%=rfvtxtChequeAmount.ClientID %>"), false);
        ValidatorEnable(document.getElementById("<%=rfvtxtChequeDate.ClientID %>"), false);
        ValidatorEnable(document.getElementById("<%=rfvtxtChequeNo.ClientID %>"), false);

        ValidatorEnable(document.getElementById("<%=rfvddlNEFTBankName.ClientID %>"), false);
        ValidatorEnable(document.getElementById("<%=rfvtxtNEFTAccNo.ClientID %>"), false);
        ValidatorEnable(document.getElementById("<%=rfvtxtNEFTBankName.ClientID %>"), false);
        ValidatorEnable(document.getElementById("<%=rfvtxtNEFTBranchName.ClientID %>"), false);
        ValidatorEnable(document.getElementById("<%=rfvtxtNEFTIFSC.ClientID %>"), false);
        ValidatorEnable(document.getElementById("<%=rfvtxtNEFTUTR.ClientID %>"), false);

        ValidatorEnable(document.getElementById("<%=rfvtxtLoanAmount.ClientID %>"), false);
        ValidatorEnable(document.getElementById("<%=rfvtxtLoanBankName.ClientID %>"), false);
        ValidatorEnable(document.getElementById("<%=rfvtxtLoanMarginAmount.ClientID %>"), false);
        ValidatorEnable(document.getElementById("<%=rfvddlLoanMarginMode.ClientID %>"), false);

        ValidatorEnable(document.getElementById("<%=rfvddlChequeBankNameLoan.ClientID %>"), false);
        ValidatorEnable(document.getElementById("<%=rfvtxtChequeBankNameLoan.ClientID %>"), false);
        ValidatorEnable(document.getElementById("<%=rfvtxtChequeBranchNameLoan.ClientID %>"), false);
        ValidatorEnable(document.getElementById("<%=rfvtxtChequeAccNoLoan.ClientID %>"), false);
        ValidatorEnable(document.getElementById("<%=rfvtxtChequeIFSCLoan.ClientID %>"), false);
        ValidatorEnable(document.getElementById("<%=rfvtxtChequeAmountLoan.ClientID %>"), false);
        ValidatorEnable(document.getElementById("<%=rfvtxtChequeDateLoan.ClientID %>"), false);
        ValidatorEnable(document.getElementById("<%=rfvtxtChequeNoLoan.ClientID %>"), false);

        ValidatorEnable(document.getElementById("<%=rfvddlNEFTBankNameLoan.ClientID %>"), false);
        ValidatorEnable(document.getElementById("<%=rfvtxtNEFTAccNoLoan.ClientID %>"), false);
        ValidatorEnable(document.getElementById("<%=rfvtxtNEFTBankNameLoan.ClientID %>"), false);
        ValidatorEnable(document.getElementById("<%=rfvtxtNEFTBranchNameLoan.ClientID %>"), false);
        ValidatorEnable(document.getElementById("<%=rfvtxtNEFTIFSCLoan.ClientID %>"), false);
        ValidatorEnable(document.getElementById("<%=rfvtxtNEFTUTRLoan.ClientID %>"), false);

        $("input[type='radio']").click(function () {
            /**$("input[name='customRadioInline3']").change(function() {**/

            var radioValue = $("input[name='customRadioInline3']:checked").val();
            console.log(radioValue);
            if (radioValue == "Cheque") {
                ValidatorEnable(document.getElementById("<%=rfvddlChequeBankName.ClientID %>"), true);
                ValidatorEnable(document.getElementById("<%=rfvtxtChequeBankName.ClientID %>"), true);
                ValidatorEnable(document.getElementById("<%=rfvtxtChequeBranchName.ClientID %>"), true);//txtChequeAccNo 
                ValidatorEnable(document.getElementById("<%=rfvtxtChequeAccNo.ClientID %>"), true);//txtChequeAccNo
                ValidatorEnable(document.getElementById("<%=rfvtxtChequeIFSC.ClientID %>"), true);
                ValidatorEnable(document.getElementById("<%=rfvtxtChequeAmount.ClientID %>"), true);
                ValidatorEnable(document.getElementById("<%=rfvtxtChequeDate.ClientID %>"), true);
                ValidatorEnable(document.getElementById("<%=rfvtxtChequeNo.ClientID %>"), true);


                ValidatorEnable(document.getElementById("<%=rfvddlNEFTBankName.ClientID %>"), false);
                ValidatorEnable(document.getElementById("<%=rfvtxtNEFTAccNo.ClientID %>"), false);
                ValidatorEnable(document.getElementById("<%=rfvtxtNEFTBankName.ClientID %>"), false);
                ValidatorEnable(document.getElementById("<%=rfvtxtNEFTBranchName.ClientID %>"), false);
                ValidatorEnable(document.getElementById("<%=rfvtxtNEFTIFSC.ClientID %>"), false);
                ValidatorEnable(document.getElementById("<%=rfvtxtNEFTUTR.ClientID %>"), false);

                ValidatorEnable(document.getElementById("<%=rfvtxtLoanAmount.ClientID %>"), false);
                ValidatorEnable(document.getElementById("<%=rfvtxtLoanBankName.ClientID %>"), false);
                ValidatorEnable(document.getElementById("<%=rfvtxtLoanMarginAmount.ClientID %>"), false);
                ValidatorEnable(document.getElementById("<%=rfvddlLoanMarginMode.ClientID %>"), false);

                ValidatorEnable(document.getElementById("<%=rfvddlChequeBankNameLoan.ClientID %>"), false);
                ValidatorEnable(document.getElementById("<%=rfvtxtChequeBankNameLoan.ClientID %>"), false);
                ValidatorEnable(document.getElementById("<%=rfvtxtChequeBranchNameLoan.ClientID %>"), false);//txtChequeAccNo
                ValidatorEnable(document.getElementById("<%=rfvtxtChequeAccNoLoan.ClientID %>"), false);//txtChequeAccNo                    
                ValidatorEnable(document.getElementById("<%=rfvtxtChequeIFSCLoan.ClientID %>"), false);
                ValidatorEnable(document.getElementById("<%=rfvtxtChequeAmountLoan.ClientID %>"), false);
                ValidatorEnable(document.getElementById("<%=rfvtxtChequeDateLoan.ClientID %>"), false);
                ValidatorEnable(document.getElementById("<%=rfvtxtChequeNoLoan.ClientID %>"), false);

                ValidatorEnable(document.getElementById("<%=rfvddlNEFTBankNameLoan.ClientID %>"), false);
                ValidatorEnable(document.getElementById("<%=rfvtxtNEFTAccNoLoan.ClientID %>"), false);
                ValidatorEnable(document.getElementById("<%=rfvtxtNEFTBankNameLoan.ClientID %>"), false);
                ValidatorEnable(document.getElementById("<%=rfvtxtNEFTBranchNameLoan.ClientID %>"), false);
                ValidatorEnable(document.getElementById("<%=rfvtxtNEFTIFSCLoan.ClientID %>"), false);
                ValidatorEnable(document.getElementById("<%=rfvtxtNEFTUTRLoan.ClientID %>"), false);

                $('.Cheque').show()
                $('.neft').hide();
                $('.loan').hide();
                //alert('loan hide 4');

                $('.Loan_Cheque').hide();
                $('.neft_Loan').hide();

                $("#divNEFT").css({ 'display': 'none' });
                $("#divChequeLoan").css({ 'display': 'none' });
                $("#divNEFTLoan").css({ 'display': 'none' });


            }
            else if
				   (radioValue == "neft") {

                ValidatorEnable(document.getElementById("<%=rfvddlChequeBankName.ClientID %>"), false);
                ValidatorEnable(document.getElementById("<%=rfvtxtChequeBankName.ClientID %>"), false);
                ValidatorEnable(document.getElementById("<%=rfvtxtChequeBranchName.ClientID %>"), false);//txtChequeAccNo
                ValidatorEnable(document.getElementById("<%=rfvtxtChequeAccNo.ClientID %>"), false);//txtChequeAccNo                   
                ValidatorEnable(document.getElementById("<%=rfvtxtChequeIFSC.ClientID %>"), false);
                ValidatorEnable(document.getElementById("<%=rfvtxtChequeAmount.ClientID %>"), false);
                ValidatorEnable(document.getElementById("<%=rfvtxtChequeDate.ClientID %>"), false);
                ValidatorEnable(document.getElementById("<%=rfvtxtChequeNo.ClientID %>"), false);

                ValidatorEnable(document.getElementById("<%=rfvddlNEFTBankName.ClientID %>"), true);
                ValidatorEnable(document.getElementById("<%=rfvtxtNEFTAccNo.ClientID %>"), true);
                ValidatorEnable(document.getElementById("<%=rfvtxtNEFTBankName.ClientID %>"), true);
                ValidatorEnable(document.getElementById("<%=rfvtxtNEFTBranchName.ClientID %>"), true);
                ValidatorEnable(document.getElementById("<%=rfvtxtNEFTIFSC.ClientID %>"), true);
                ValidatorEnable(document.getElementById("<%=rfvtxtNEFTUTR.ClientID %>"), true);

                ValidatorEnable(document.getElementById("<%=rfvtxtLoanAmount.ClientID %>"), false);
                ValidatorEnable(document.getElementById("<%=rfvtxtLoanBankName.ClientID %>"), false);
                ValidatorEnable(document.getElementById("<%=rfvtxtLoanMarginAmount.ClientID %>"), false);
                ValidatorEnable(document.getElementById("<%=rfvddlLoanMarginMode.ClientID %>"), false);

                ValidatorEnable(document.getElementById("<%=rfvddlChequeBankNameLoan.ClientID %>"), false);
                ValidatorEnable(document.getElementById("<%=rfvtxtChequeBankNameLoan.ClientID %>"), false);
                ValidatorEnable(document.getElementById("<%=rfvtxtChequeBranchNameLoan.ClientID %>"), false);//txtChequeAccNo
                ValidatorEnable(document.getElementById("<%=rfvtxtChequeAccNoLoan.ClientID %>"), false);//txtChequeAccNo                    
                ValidatorEnable(document.getElementById("<%=rfvtxtChequeIFSCLoan.ClientID %>"), false);
                ValidatorEnable(document.getElementById("<%=rfvtxtChequeAmountLoan.ClientID %>"), false);
                ValidatorEnable(document.getElementById("<%=rfvtxtChequeDateLoan.ClientID %>"), false);
                ValidatorEnable(document.getElementById("<%=rfvtxtChequeNoLoan.ClientID %>"), false);

                ValidatorEnable(document.getElementById("<%=rfvddlNEFTBankNameLoan.ClientID %>"), false);
                ValidatorEnable(document.getElementById("<%=rfvtxtNEFTAccNoLoan.ClientID %>"), false);
                ValidatorEnable(document.getElementById("<%=rfvtxtNEFTBankNameLoan.ClientID %>"), false);
                ValidatorEnable(document.getElementById("<%=rfvtxtNEFTBranchNameLoan.ClientID %>"), false);
                ValidatorEnable(document.getElementById("<%=rfvtxtNEFTIFSCLoan.ClientID %>"), false);
                ValidatorEnable(document.getElementById("<%=rfvtxtNEFTUTRLoan.ClientID %>"), false);

                $('.neft').show()
                $('.Cheque').hide();
                $('.loan').hide();
                //alert('loan hide 5');

                $("#divCheque").css({ 'display': 'none' });
                $("#divChequeLoan").css({ 'display': 'none' });
                $("#divNEFTLoan").css({ 'display': 'none' });


                $('.Loan_Cheque').hide();
                $('.neft_Loan').hide();
            }

            else if 
					(radioValue == "loan") {
                //alert('Loan_3');

                ValidatorEnable(document.getElementById("<%=rfvddlChequeBankName.ClientID %>"), false);
                ValidatorEnable(document.getElementById("<%=rfvtxtChequeBankName.ClientID %>"), false);
                ValidatorEnable(document.getElementById("<%=rfvtxtChequeBranchName.ClientID %>"), false);//txtChequeAccNo
                ValidatorEnable(document.getElementById("<%=rfvtxtChequeAccNo.ClientID %>"), false);//txtChequeAccNo                    
                ValidatorEnable(document.getElementById("<%=rfvtxtChequeIFSC.ClientID %>"), false);
                ValidatorEnable(document.getElementById("<%=rfvtxtChequeAmount.ClientID %>"), false);
                ValidatorEnable(document.getElementById("<%=rfvtxtChequeDate.ClientID %>"), false);
                ValidatorEnable(document.getElementById("<%=rfvtxtChequeNo.ClientID %>"), false);

                ValidatorEnable(document.getElementById("<%=rfvddlNEFTBankName.ClientID %>"), false);
                ValidatorEnable(document.getElementById("<%=rfvtxtNEFTAccNo.ClientID %>"), false);
                ValidatorEnable(document.getElementById("<%=rfvtxtNEFTBankName.ClientID %>"), false);
                ValidatorEnable(document.getElementById("<%=rfvtxtNEFTBranchName.ClientID %>"), false);
                ValidatorEnable(document.getElementById("<%=rfvtxtNEFTIFSC.ClientID %>"), false);
                ValidatorEnable(document.getElementById("<%=rfvtxtNEFTUTR.ClientID %>"), false);

                ValidatorEnable(document.getElementById("<%=rfvtxtLoanAmount.ClientID %>"), true);
                ValidatorEnable(document.getElementById("<%=rfvtxtLoanBankName.ClientID %>"), true);
                ValidatorEnable(document.getElementById("<%=rfvtxtLoanMarginAmount.ClientID %>"), true);
                ValidatorEnable(document.getElementById("<%=rfvddlLoanMarginMode.ClientID %>"), true);

                $('.loan').show()
                $('.Cheque').hide();
                $('.neft').hide();

                $("#divCheque").css({ 'display': 'none' });
                $("#divNEFT").css({ 'display': 'none' });

                var ddlLMM = document.getElementById("<%=ddlLoanMarginMode.ClientID %>");
                var ddlLMMVal = ddlLMM.value;
                if (ddlLMMVal == "0") {
                    $('.Loan_Cheque').hide();
                    $('.neft_Loan').hide();
                }
                else {
                    if (ddlLMMVal == "Cheque") {
                        $('.Loan_Cheque').show();
                        $('.neft_Loan').hide();
                        ValidatorEnable(document.getElementById("<%=rfvddlChequeBankNameLoan.ClientID %>"), true);
                        ValidatorEnable(document.getElementById("<%=rfvtxtChequeBankNameLoan.ClientID %>"), true);
                        ValidatorEnable(document.getElementById("<%=rfvtxtChequeBranchNameLoan.ClientID %>"), true);//txtChequeAccNo
                        ValidatorEnable(document.getElementById("<%=rfvtxtChequeAccNoLoan.ClientID %>"), true);//txtChequeAccNo                    
                        ValidatorEnable(document.getElementById("<%=rfvtxtChequeIFSCLoan.ClientID %>"), true);
                        ValidatorEnable(document.getElementById("<%=rfvtxtChequeAmountLoan.ClientID %>"), true);
                        ValidatorEnable(document.getElementById("<%=rfvtxtChequeDateLoan.ClientID %>"), true);
                        ValidatorEnable(document.getElementById("<%=rfvtxtChequeNoLoan.ClientID %>"), true);

                        ValidatorEnable(document.getElementById("<%=rfvddlNEFTBankName.ClientID %>"), false);
                        ValidatorEnable(document.getElementById("<%=rfvtxtNEFTAccNoLoan.ClientID %>"), false);
                        ValidatorEnable(document.getElementById("<%=rfvtxtNEFTBankNameLoan.ClientID %>"), false);
                        ValidatorEnable(document.getElementById("<%=rfvtxtNEFTBranchNameLoan.ClientID %>"), false);
                        ValidatorEnable(document.getElementById("<%=rfvtxtNEFTIFSCLoan.ClientID %>"), false);
                        ValidatorEnable(document.getElementById("<%=rfvtxtNEFTUTRLoan.ClientID %>"), false);
                    }
                    else {
                        $('.Loan_Cheque').hide();
                        $('.neft_Loan').show();
                        ValidatorEnable(document.getElementById("<%=rfvddlChequeBankNameLoan.ClientID %>"), false);
                        ValidatorEnable(document.getElementById("<%=rfvtxtChequeBankNameLoan.ClientID %>"), false);
                        ValidatorEnable(document.getElementById("<%=rfvtxtChequeBranchNameLoan.ClientID %>"), false);//txtChequeAccNo
                        ValidatorEnable(document.getElementById("<%=rfvtxtChequeAccNoLoan.ClientID %>"), false);//txtChequeAccNo                    
                        ValidatorEnable(document.getElementById("<%=rfvtxtChequeIFSCLoan.ClientID %>"), false);
                        ValidatorEnable(document.getElementById("<%=rfvtxtChequeAmountLoan.ClientID %>"), false);
                        ValidatorEnable(document.getElementById("<%=rfvtxtChequeDateLoan.ClientID %>"), false);
                        ValidatorEnable(document.getElementById("<%=rfvtxtChequeNoLoan.ClientID %>"), false);

                        ValidatorEnable(document.getElementById("<%=rfvddlNEFTBankName.ClientID %>"), true);
                        ValidatorEnable(document.getElementById("<%=rfvtxtNEFTAccNoLoan.ClientID %>"), true);
                        ValidatorEnable(document.getElementById("<%=rfvtxtNEFTBankNameLoan.ClientID %>"), true);
                        ValidatorEnable(document.getElementById("<%=rfvtxtNEFTBranchNameLoan.ClientID %>"), true);
                        ValidatorEnable(document.getElementById("<%=rfvtxtNEFTIFSCLoan.ClientID %>"), true);
                        ValidatorEnable(document.getElementById("<%=rfvtxtNEFTUTRLoan.ClientID %>"), true);
                    }
                }

            }

        });
//})
    </script>
    <script>
        $(document).ready(function () {
            $("#submit").click(function () {
                $('input').attr('readonly', true);
                $('select').attr('readonly', true);
            });
        });
    </script>

    <script type="text/javascript">
        var prm = Sys.WebForms.PageRequestManager.getInstance();
        function openModal() {
            var radioValue = $("input[name='customRadioInline3']:checked").val();
            console.log(radioValue);
            if (radioValue == "Cheque") {
                $('.Cheque').show()
                $('.neft').hide();
                $('.loan').hide();
                $('.Loan_Cheque').hide();
                $('.neft_Loan').hide();

                $("#divNEFT").css({ 'display': 'none' });
                $("#divChequeLoan").css({ 'display': 'none' });
                $("#divNEFTLoan").css({ 'display': 'none' });

                document.getElementById('lblPaymantMode').innerHTML = 'Cheque';
                document.getElementById("<%=hfPaymantMode.ClientID %>").value = 'Cheque';
            }
            else if (radioValue == "neft") {
                $('.Cheque').hide()
                $('.neft').show();
                $('.loan').hide();
                $('.Loan_Cheque').hide();
                $('.neft_Loan').hide();
                document.getElementById('lblPaymantMode').innerHTML = 'NEFT';
                document.getElementById("<%=hfPaymantMode.ClientID %>").value = 'NEFT';

                $("#divChequeLoan").css({ 'display': 'none' });
                $("#divNEFTLoan").css({ 'display': 'none' });


            }
            else if (radioValue == "loan") {
                //alert('Loan_4');

                $('.Cheque').hide()
                $('.neft').hide();
                $('.loan').show();

                $("#divNEFT").css({ 'display': 'none' });

                var ddlLMM = document.getElementById("<%=ddlLoanMarginMode.ClientID %>");
                var ddlLMMVal = ddlLMM.value;
                if (ddlLMMVal == "0") {
                    $('.Loan_Cheque').hide();
                    $('.neft_Loan').hide();
                }
                else {
                    if (ddlLMMVal == "Cheque") {
                        $('.Loan_Cheque').show();
                        $('.neft_Loan').hide();
                    }
                    else {
                        $('.Loan_Cheque').hide();
                        $('.neft_Loan').show();
                    }
                }
                document.getElementById('lblPaymantMode').innerHTML = 'Loan';
                document.getElementById("<%=hfPaymantMode.ClientID %>").value = 'Loan';
            }
            else {
                alert('Please Select Payment Mode');
                return;
            }


   <%-- prm.add_endRequest(function (s, e) {
		var radioValue = $("input[name='customRadioInline3']:checked").val();
		console.log(radioValue);
		if (radioValue == "Cheque") {
			$('.Cheque').show()
			$('.neft').hide();
			$('.loan').hide();
			$('.Loan_Cheque').hide();
			$('.neft_Loan').hide();
			document.getElementById('lblPaymantMode').innerHTML = 'Cheque';
			document.getElementById("<%=hfPaymantMode.ClientID %>").value = 'Cheque';
		}
		else if (radioValue == "neft") {
			$('.Cheque').hide()
			$('.neft').show();
			$('.loan').hide();
			$('.Loan_Cheque').hide();
			$('.neft_Loan').hide();
			document.getElementById('lblPaymantMode').innerHTML = 'NEFT';
			document.getElementById("<%=hfPaymantMode.ClientID %>").value = 'NEFT';
		}
		else if (radioValue == "loan") {
			//alert('Loan_5');
			alert(radioValue);
			$('.Cheque').hide()
			$('.neft').hide();
			$('.loan').show();
			var ddlLMM = document.getElementById("<%=ddlLoanMarginMode.ClientID %>");
			var ddlLMMVal = ddlLMM.value;
			if (ddlLMMVal == "0") {
				$('.Loan_Cheque').hide();
				$('.neft_Loan').hide();
			}
			else {
				if (ddlLMMVal == "Cheque") {
					$('.Loan_Cheque').show();
					$('.neft_Loan').hide();
				}
				else {
					$('.Loan_Cheque').hide();
					$('.neft_Loan').show();
				}
			}
			document.getElementById('lblPaymantMode').innerHTML = 'Loan';
			document.getElementById("<%=hfPaymantMode.ClientID %>").value = 'Loan';
		}
		else {
			alert('Please Select Payment Mode');
			return;
		}

			});--%>
            //});
            $('#modalPreview').modal('show');
        }
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
    <script>
        <%--$(document).ready(function () {
            timer = setInterval(function () {
                document.getElementById("<%=btnSession.ClientID %>").click();
			    //alert("Exercise Data Saved");
			}, 30000);
		});--%>
    </script>
    <script type="text/javascript">
        $(document).ready(function () {
            var radioValue = $("input[name='customRadioInline3']:checked").val();
            console.log(radioValue);
            if (radioValue == "Cheque") {
                $('.Cheque').show()
                $('.neft').hide();
                $('.loan').hide();
                $('.Loan_Cheque').hide();
                $('.neft_Loan').hide

                $("#divNEFT").css({ 'display': 'none' });
                $("#divChequeLoan").css({ 'display': 'none' });
                $("#divNEFTLoan").css({ 'display': 'none' });


                document.getElementById('lblPaymantMode').innerHTML = 'Cheque';
                document.getElementById("<%=hfPaymantMode.ClientID %>").value = 'Cheque';
            }
            else if (radioValue == "neft") {
                $('.Cheque').hide()
                $('.neft').show();
                $('.loan').hide();
                $('.Loan_Cheque').hide();
                $('.neft_Loan').hide();
                document.getElementById('lblPaymantMode').innerHTML = 'NEFT';
                document.getElementById("<%=hfPaymantMode.ClientID %>").value = 'NEFT';

                $("#divChequeLoan").css({ 'display': 'none' });
                $("#divNEFTLoan").css({ 'display': 'none' });


            }
            else if (radioValue == "loan") {
                //alert('Loan_6');

                $('.Cheque').hide()
                $('.neft').hide();
                $('.loan').show();

                $("#divNEFT").css({ 'display': 'none' });

                var ddlLMM = document.getElementById("<%=ddlLoanMarginMode.ClientID %>");
                var ddlLMMVal = ddlLMM.value;
                if (ddlLMMVal == "0") {
                    $('.Loan_Cheque').hide();
                    $('.neft_Loan').hide();
                }
                else {
                    if (ddlLMMVal == "Cheque") {
                        $('.Loan_Cheque').show();
                        $('.neft_Loan').hide();
                    }
                    else {
                        $('.Loan_Cheque').hide();
                        $('.neft_Loan').show();
                    }
                }
                document.getElementById('lblPaymantMode').innerHTML = 'Loan';
                document.getElementById("<%=hfPaymantMode.ClientID %>").value = 'Loan';
            }
            else {
                // alert('Please Select Payment Mode');
                return;
            }
        });

var prm = Sys.WebForms.PageRequestManager.getInstance();
if (prm != null) {
    prm.add_endRequest(function (sender, e) {

        var radioValue = $("input[name='customRadioInline3']:checked").val();
        console.log(radioValue);
        if (radioValue == "Cheque") {
            $('.Cheque').show()
            $('.neft').hide();
            $('.loan').hide();
            $('.Loan_Cheque').hide();
            $('.neft_Loan').hide();

            $("#divNEFT").css({ 'display': 'none' });
            $("#divChequeLoan").css({ 'display': 'none' });
            $("#divNEFTLoan").css({ 'display': 'none' });


            document.getElementById('lblPaymantMode').innerHTML = 'Cheque';
            document.getElementById("<%=hfPaymantMode.ClientID %>").value = 'Cheque';
        }
        else if (radioValue == "neft") {
            $('.Cheque').hide()
            $('.neft').show();
            $('.loan').hide();
            $('.Loan_Cheque').hide();
            $('.neft_Loan').hide();
            document.getElementById('lblPaymantMode').innerHTML = 'NEFT';
            document.getElementById("<%=hfPaymantMode.ClientID %>").value = 'NEFT';

            $("#divChequeLoan").css({ 'display': 'none' });
            $("#divNEFTLoan").css({ 'display': 'none' });


        }
        else if (radioValue == "loan") {
            //alert('Loan_7');

            $('.Cheque').hide()
            $('.neft').hide();
            $('.loan').show();

            $("#divNEFT").css({ 'display': 'none' });

            var ddlLMM = document.getElementById("<%=ddlLoanMarginMode.ClientID %>");
            var ddlLMMVal = ddlLMM.value;
            if (ddlLMMVal == "0") {
                $('.Loan_Cheque').hide();
                $('.neft_Loan').hide();
            }
            else {
                if (ddlLMMVal == "Cheque") {
                    $('.Loan_Cheque').show();
                    $('.neft_Loan').hide();
                }
                else {
                    $('.Loan_Cheque').hide();
                    $('.neft_Loan').show();
                }
            }
            document.getElementById('lblPaymantMode').innerHTML = 'Loan';
            document.getElementById("<%=hfPaymantMode.ClientID %>").value = 'Loan';
        }
        else {
            //alert('Please Select Payment Mode');
            return;
        }

    });
};

    </script>
    <script type="text/javascript">
        function uploadComplete(sender) {
            if (document.getElementById('<%=txtErr.ClientID %>').value == 'ERR') {
                document.getElementById('<%=txtfuNEFT1.ClientID %>').value = '';
                //alert('ERR');
            }
            else {
                document.getElementById('<%=txtfuNEFT1.ClientID %>').value = 'file';
            }
        }

        function uploadComplete1(sender) {

            if (document.getElementById('<%=txtErr.ClientID %>').value == 'ERR') {
                document.getElementById('<%=txtfuCheque.ClientID %>').value = '';
                //alert('ERR');
            }
            else {
                document.getElementById('<%=txtfuCheque.ClientID %>').value = 'file';
                //alert('file');
            }
        }

        function FreshChequeSS() {

            $("#divCheque").css({ 'display': 'block' });
        }

        function uploadCompleteLoan(sender) {
            if (document.getElementById('<%=txtErr.ClientID %>').value == 'ERR') {
                //alert('ERR');
                document.getElementById('<%=txtfuNEFTLoan.ClientID %>').value = '';

            }
            else {
                document.getElementById('<%=txtfuNEFTLoan.ClientID %>').value = 'file';
            }
        }

        function uploadComplete1Loan(sender) {
            if (document.getElementById('<%=txtErr.ClientID %>').value == 'ERR') {
                //alert('ERR');
                document.getElementById('<%=txtfuChequeLoan.ClientID %>').value = '';

            }
            else {
                document.getElementById('<%=txtfuChequeLoan.ClientID %>').value = 'file';
            }
        }
        function uploadStart(sender, args) {
            var filename = args.get_fileName();
            var filext = filename.substring(filename.lastIndexOf(".") + 1).toLowerCase();

            if (filext == "jpg" || filext == "jpeg" ||
			filext == "png" || filext == "gif" || filext == "pdf" || filext == "doc" || filext == "docx") {
                var a = sender.get_id()
                if (a == 'ContentPlaceHolder1_fuCheque') {

                    $("#divCheque").css({ 'display': 'block' });
                }
                if (a == 'ContentPlaceHolder1_fuNEFT1') {
                    $("#divNEFT").css({ 'display': 'block' });//divCheque
                }

                if (a == 'ContentPlaceHolder1_fuChequeLoan') {
                    // alert('hi');
                    $("#divChequeLoan").css({ 'display': 'block' });
                }
                if (a == 'ContentPlaceHolder1_fuNEFTLoan') {
                    $("#divNEFTLoan").css({ 'display': 'block' });
                }
                //alert(a);
                document.getElementById('<%=txtErr.ClientID %>').value = ''

                return true;
            }
            else {
                //var err = new Error();
                //err.name = 'Image Format';
                //err.message = 'Only .jpg, .gif, .png, .gif, .pdf, .doc, .docx files are allowed';
                //throw (err);
                var a = sender.get_id()
                if (a == 'ContentPlaceHolder1_fuCheque') {
                    $("#divCheque").css({ 'display': 'none' });
                }
                if (a == 'ContentPlaceHolder1_fuNEFT1') {
                    $("#divNEFT").css({ 'display': 'none' });//divCheque
                }
                if (a == 'ContentPlaceHolder1_fuChequeLoan') {
                    $("#divChequeLoan").css({ 'display': 'none' });
                }
                if (a == 'ContentPlaceHolder1_fuNEFTLoan') {
                    $("#divNEFTLoan").css({ 'display': 'none' });
                }
                alert('Only .jpg, .png, .gif, .pdf, .doc, .docx files are allowed');
                //alert(a);
                document.getElementById('<%=txtErr.ClientID %>').value = 'ERR'
                //alert('ERR');
                return false;
            }
        }
        function uploadError(sender, args) {


            alert('Only .jpg, .png, .gif, .pdf, .doc, .docx files are allowed');
        }
    </script>

    <script type="text/javascript">

        //$(document).ready(function () {
        //    Cancle_Cheque_SS();
        //});
        //$(document).ready(function () {
        //    Cancle_Cheque_SS_Hide();
        //});
        //$(document).ready(function () {
        //    Cancle_Cheque_Loan_SS();
        //});
        //$(document).ready(function () {
        //    Cancle_Cheque_Loan_SS_Hide();
        //});

        function Cancle_Cheque_SS() {
            $("#divChequeFresh").css({ 'display': 'block' });
        }
        function Cancle_Cheque_SS_Hide() {
            //alert('cancel');
            $("#divChequeFresh").css({ 'display': 'none' });
        }
        function Cancle_Cheque_Loan_SS() {
            $("#divChequeFreshLoan").css({ 'display': 'block' });
        }
        function Cancle_Cheque_Loan_SS_Hide() {
            $("#divChequeFreshLoan").css({ 'display': 'none' });
        }


        //$(document).ready(function () {
        //    Fresh_Cheque_SS_Hide();
        //});
        function Fresh_Cheque_SS_Hide() {
            $("#divCheque").css({ 'display': 'none' });
        }
        //$(document).ready(function () {
        //    Fresh_Cheque_SS();
        //});
        function Fresh_Cheque_SS() {

            $("#divCheque").css({ 'display': 'block' });
        }

        //$(document).ready(function () {
        //    NEFT_Trans_SS_Hide();
        //});
        function NEFT_Trans_SS_Hide() {
            $("#divNEFT").css({ 'display': 'none' });
        }
        //$(document).ready(function () {
        //    NEFT_Trans_SS();
        //});
        function NEFT_Trans_SS() {
            $("#divNEFT").css({ 'display': 'block' });
        }


        //$(document).ready(function () {
        //    Loan_Cheque_SS_Hide();
        //});
        function Loan_Cheque_SS_Hide() {
            $("#divChequeLoan").css({ 'display': 'none' });
        }
        //$(document).ready(function () {
        //    Loan_Cheque_SS();
        //});
        function Loan_Cheque_SS() {
            $("#divChequeLoan").css({ 'display': 'block' });
        }

        //$(document).ready(function () {
        //    NEFTLoan_SS_Hide();
        //});
        function NEFTLoan_SS_Hide() {
            $("#divNEFTLoan").css({ 'display': 'none' });
        }
        //$(document).ready(function () {
        //    NEFTLoan_SS();
        //});
        function NEFTLoan_SS() {
            $("#divNEFTLoan").css({ 'display': 'block' });
        }

        $(document).ready(function () {
            dropchange();
        });
        function dropchange() {
            //var id = ddl.id;
            //var value = $("#ddlnoOfCycle1").val();
            //alert(value);

            var ddlCheque = document.getElementById("<%=ddlChequeBankName.ClientID %>");
            var ddlChequeLoan = document.getElementById("<%=ddlChequeBankNameLoan.ClientID %>");
            var ddlDPID = document.getElementById("<%=ddlOtherSecurity.ClientID %>");
            var ddlLMM = document.getElementById("<%=ddlLoanMarginMode.ClientID %>");


            var ddlChequeVal = ddlCheque.value;
            var ddlChequeLoanVal = ddlChequeLoan.value;
            var ddlDPIDVal = ddlDPID.value;
            var ddlLMMVal = ddlLMM.value;

            if (ddlChequeVal == "0") {
                $("#divChequeFresh").css({ 'display': 'none' });

            }
            //else {
            //    alert('show_1');
            //    alert(ddlChequeVal);
            //    $("#divChequeFresh").css({ 'display': 'block' });
            //}

            if (ddlChequeLoanVal == "0") {
                $("#divChequeFreshLoan").css({ 'display': 'none' });

            }
            else {
                debugger;
                $("#divChequeFreshLoan").css({ 'display': 'block' });
            }

            if (ddlDPIDVal == "0") {
                $("#divDPID").css({ 'display': 'none' });

            }
            else {
                $("#divDPID").css({ 'display': 'block' });
            }

            if (ddlLMMVal == "0") {
                $('.Loan_Cheque').hide();
                $('.neft_Loan').hide();
            }
            else {
                if (ddlLMMVal == "Cheque") {
                    $('.Loan_Cheque').show();
                    $('.neft_Loan').hide();
                }
                else {
                    $('.Loan_Cheque').hide();
                    $('.neft_Loan').show();
                }
            }
        }
    </script>
    <script>
        function isNumberKey1(evt) {
            var charCode = (evt.which) ? evt.which : evt.keyCode;
            if (charCode > 31 && (charCode < 48 || charCode > 57))
                return false;

            return true;
        }
    </script>
    <script type="text/javascript">
        function Change_Session_Value() {
            '<%Session["Emp_Exercise_Session"] = "False"; %>';
        }
    </script>
    <script type="text/javascript">
        var prm = Sys.WebForms.PageRequestManager.getInstance();
        function openModal() {
            var radioValue = $("input[name='customRadioInline3']:checked").val();
            console.log(radioValue);
            if (radioValue == "Cheque") {
                $('.Cheque').show()
                $('.neft').hide();
                $('.loan').hide();
                $('.Loan_Cheque').hide();
                $('.neft_Loan').hide();

                $("#divNEFT").css({ 'display': 'none' });
                $("#divChequeLoan").css({ 'display': 'none' });
                $("#divNEFTLoan").css({ 'display': 'none' });

                document.getElementById('lblPaymantMode').innerHTML = 'Cheque';
                document.getElementById("<%=hfPaymantMode.ClientID %>").value = 'Cheque';
            }
            else if (radioValue == "neft") {
                $('.Cheque').hide()
                $('.neft').show();
                $('.loan').hide();
                $('.Loan_Cheque').hide();
                $('.neft_Loan').hide();
                document.getElementById('lblPaymantMode').innerHTML = 'NEFT';
                document.getElementById("<%=hfPaymantMode.ClientID %>").value = 'NEFT';

                $("#divChequeLoan").css({ 'display': 'none' });
                $("#divNEFTLoan").css({ 'display': 'none' });


            }
            else if (radioValue == "loan") {
                //alert('Loan_4');

                $('.Cheque').hide()
                $('.neft').hide();
                $('.loan').show();

                $("#divNEFT").css({ 'display': 'none' });

                var ddlLMM = "";<%--document.getElementById("<%=ddlLoanMarginMode.ClientID %>");--%>
                var ddlLMMVal = ddlLMM.value;
                if (ddlLMMVal == "0") {
                    $('.Loan_Cheque').hide();
                    $('.neft_Loan').hide();
                }
                else {
                    if (ddlLMMVal == "Cheque") {
                        $('.Loan_Cheque').show();
                        $('.neft_Loan').hide();
                    }
                    else {
                        $('.Loan_Cheque').hide();
                        $('.neft_Loan').show();
                    }
                }
                document.getElementById('lblPaymantMode').innerHTML = 'Loan';
                document.getElementById("<%=hfPaymantMode.ClientID %>").value = 'Loan';
            }
            else {
                alert('Please Select Payment Mode');
                return;
            }

    $('#modalPreview').modal('show');
}
    </script>
</asp:Content>
