<%@ Page Title="" Language="C#" MasterPageFile="~/ESOP.Master" AutoEventWireup="true" CodeBehind="employee-sale.aspx.cs" Inherits="ESOP.employee_sale" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
        .n_pnl {
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
                /* Position the tooltip */
                position: absolute;
                z-index: 1;
            }

            .n_pnl:hover .n_pnltext {
                visibility: visible;
            }
    </style>

    <style>
        .DrpWidth {
            width: 220px !important;
        }

        .img {
            padding: 0px;
            transition: transform .2s;
            margin: 0 auto;
            width: 200px;
            height: 100px;
        }

        /*.img:hover {
                transform: scale(1.5);
                width: 400px;
                height: 200px;
            }*/
        .Image2:hover {
            transform: scale(1);
            margin-top: 0% !important;
            margin-left: 0% !important;
            width: 600px !important;
            height: 200px !important;
        }

        .Image1:hover {
            transform: scale(1);
            margin-top: 0% !important;
            margin-left: 0% !important;
            width: 600px !important;
            height: 200px !important;
        }

        .Image3:hover {
            transform: scale(1);
            margin-top: 0% !important;
            margin-left: 0% !important;
            width: 600px;
            height: 200px;
        }

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
            width: auto !important;
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
            margin-left: 87.333333%;
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
            width: auto !important;
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

        .btn.btn-lg1 {
            /*padding: 0.40rem 1.5rem !important;*/
            font-size: 13px !important;
            color: white !important;
            margin-right: -480px;
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

        figure.snip0014 {
            position: relative;
            overflow: hidden;
            /* margin: 10px; */
            width: 100%;
            padding: 10px 10px 0px;
            background: #fff;
            text-align: center;
            border-radius: 8px;
        }

            figure.snip0014 img {
                max-width: 100%;
                opacity: 1;
                -webkit-transition: opacity 0.35s;
                transition: opacity 0.35s;
            }

            figure.snip0014:hover {
                background: #1fa2c02b !important;
                height: 215px;
            }

            figure.snip0014 img {
                height: 70px !important;
                width: 85px !important;
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
            height: 215px;
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

        .modal-header {
            display: initial;
        }

        .modal-header {
            padding: 6px !important;
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
    </style>
    <link href="assets/css/jquery-ui-1.12.1.css" rel="stylesheet" />
    <script src="assets/js/jquery-1.12.4.js" type="text/javascript"></script>
    <script src="assets/js/app.min.js"></script>

    <!-- Tooltip Start -->
    <script type="text/javascript">

        // Load this script once the document is ready
        $(document).ready(function () {

            // Get all the thumbnail
            $('div.pnl_item').mouseenter(function (e) {

                // Calculate the position of the image pnl_item2
                x = e.pageX - $(this).offset().left;
                y = e.pageY - $(this).offset().top;

                // Set the z-index of the current item, 
                // make sure it's greater than the rest of thumbnail items
                // Set the position and display the image pnl_item2
                $(this).css('z-index', '15')
                .children("div.pnl_item2")
                .css({ 'top': y + 10, 'left': x + 20, 'display': 'block' });

            }).mousemove(function (e) {

                // Calculate the position of the image pnl_item2			
                x = e.pageX - $(this).offset().left;
                y = e.pageY - $(this).offset().top;

                // This line causes the pnl_item2 will follow the mouse pointer
                $(this).children("div.pnl_item2").css({ 'top': y + 10, 'left': x + 20 });

            }).mouseleave(function () {

                // Reset the z-index and hide the image pnl_item2 
                $(this).css('z-index', '1')
                .children("div.pnl_item2")
                .animate({ "opacity": "hide" }, "fast");
            });

        });


    </script>
    <!-- Tooltip End -->


</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <style>
        .abc:hover {
            z-index: 99;
            -ms-transform: scale(1.5); /*IE 9*/
            -webkit-transform: scale(1.5); /*Safari 3-8*/
            transform: scale(1.5) translate(80px, 80px);
        }
    </style>
    <asp:ScriptManager ID="script" runat="server"></asp:ScriptManager>
    <div class="main-content">
        <nav aria-label="breadcrumb">
            <ol class="breadcrumb">
                <li class="breadcrumb-item"><a href="employee-dashboard.aspx">Home</a></li>
                <li class="breadcrumb-item active" aria-current="page">Sale</li>
            </ol>
        </nav>
        <section class="section">
            <div class="row">
                <div class="col-lg-12 col-md-12 col-12 col-sm-12">
                    <div class="card">
                        <div class="card-header">
                            <h4>Sale</h4>
                        </div>
                        <asp:UpdatePanel ID="upd1" runat="server">
                            <ContentTemplate>
                                <div id="showmsg" runat="server">
                                </div>
                            </ContentTemplate>
                        </asp:UpdatePanel>
                        <div class="card-body">
                            <fieldset>
                                <legend>Basic Information: </legend>
                                <asp:UpdatePanel ID="UpdatePanel2" runat="server" UpdateMode="Conditional">
                                    <ContentTemplate>
                                        <asp:GridView ID="gvExercise" runat="server" AutoGenerateColumns="False" ShowHeaderWhenEmpty="true"
                                            class="table1 table-borderless click" EmptyDataText="No Records Found" DataKeyNames="Vesting_DETAIL_ID"
                                            OnRowDataBound="gvExercise_RowDataBound" Width="100%" Style="border-width: 0px; border-style: none; padding-left: 5px;" OnRowCreated="gvExercise_RowCreated">
                                            <Columns>
                                                <asp:TemplateField HeaderText="Tranche wise vesting	" HeaderStyle-Width="10%">
                                                    <ItemTemplate>
                                                        <div class="remark">
                                                            <asp:TextBox ID="txtTranchVesting" runat="server" Text='<%# Eval("Tranch_Vesting") %>' CssClass="form-control"
                                                                Enabled="false"></asp:TextBox>
                                                            <asp:Label ID="lblTranchVesting" runat="server" Text='<%# Eval("Tranch_Vesting") %>'></asp:Label>
                                                        </div>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="No.of Sale" HeaderStyle-Width="2%">
                                                    <ItemTemplate>
                                                        <div class="remark">
                                                            <asp:TextBox ID="txtNoOfSale" runat="server" Text='<%# Eval("No_Of_sale") %>' CssClass="form-control"
                                                                Enabled="false"></asp:TextBox>

                                                        </div>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Grant Price" HeaderStyle-Width="8%">
                                                    <ItemTemplate>
                                                        <div class="remark">
                                                            <asp:TextBox ID="txtGrantPrice" runat="server" Text='<%# Eval("GRANT_PRICE") %>' CssClass="form-control"
                                                                Enabled="false"></asp:TextBox>
                                                            <asp:Label ID="lblGrantPrice" runat="server" Text='<%# Eval("GRANT_PRICE") %>'></asp:Label>
                                                        </div>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Exer FMV" HeaderStyle-Width="8%">
                                                    <ItemTemplate>
                                                        <div class="remark">
                                                            <asp:TextBox ID="txtFMV" runat="server" Text='<%# Eval("fmv_price") %>' CssClass="form-control"
                                                                Enabled="false"></asp:TextBox>
                                                            <asp:Label ID="lblFMV" runat="server" Text='<%# Eval("fmv_price") %>'></asp:Label>
                                                        </div>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="FMV" HeaderStyle-Width="8%">
                                                    <ItemTemplate>
                                                        <div class="remark">
                                                            <asp:TextBox ID="txtFMVSale" runat="server" Text='<%# Eval("sale_fmv_price") %>' CssClass="form-control"
                                                                Enabled="false"></asp:TextBox>
                                                            <asp:Label ID="lblFMVSale" runat="server" Text='<%# Eval("sale_fmv_price") %>'></asp:Label>
                                                        </div>
                                                    </ItemTemplate>
                                                </asp:TemplateField>

                                                <asp:TemplateField HeaderText="Total No.of Vesting" HeaderStyle-Width="10%">
                                                    <ItemTemplate>
                                                        <div class="remark" style="text-align: center;">
                                                            <asp:TextBox ID="txtOptions" runat="server" Text='<%# Eval("no_of_vesting") %>' CssClass="form-control"
                                                                Enabled="false"></asp:TextBox>
                                                            <asp:Label ID="lblOptions" runat="server" Text='<%# Eval("no_of_vesting") %>'></asp:Label>
                                                        </div>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Total No.of Tranchwise Options" HeaderStyle-Width="12%">
                                                    <ItemTemplate>
                                                        <div class="remark" style="text-align: center;">
                                                            <asp:TextBox ID="txtTotOptions" runat="server" Text='<%# Eval("Tranch_wise_options") %>' CssClass="form-control"
                                                                Enabled="false"></asp:TextBox>
                                                            <asp:Label ID="lblTotOptions" runat="server" Text='<%# Eval("Tranch_wise_options") %>'></asp:Label>
                                                        </div>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="No. of Exercise Options" HeaderStyle-Width="12%">
                                                    <ItemTemplate>
                                                        <div class="remark" style="text-align: center;">
                                                            <asp:TextBox ID="txtOptionsExercised" runat="server" Text='<%# Eval("no_of_exercise") %>' CssClass="form-control"
                                                                Enabled="false"></asp:TextBox>
                                                            <asp:Label ID="lblOptionsExercised" runat="server" Text='<%# Eval("no_of_exercise") %>'></asp:Label>
                                                        </div>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Pending Approval" HeaderStyle-Width="12%">
                                                    <ItemTemplate>
                                                        <div class="remark">
                                                            <asp:TextBox ID="TxtPendingAPP" runat="server" Text='<%# Eval("Pending_for_Approval") %>' CssClass="form-control"
                                                                Enabled="false"></asp:TextBox>
                                                            <asp:Label ID="lblPendingAPP" runat="server" Text='<%# Eval("Pending_for_Approval") %>'></asp:Label>
                                                        </div>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Shares available for sale" HeaderStyle-Width="10%">
                                                    <ItemTemplate>
                                                        <div class="remark" style="text-align: center;">
                                                            <asp:TextBox ID="txtOptionsPendingSale" runat="server" Text='<%# Eval("pending_sale") %>' CssClass="form-control"
                                                                Enabled="false"></asp:TextBox>
                                                            <asp:Label ID="lblOptionsPendingSale" runat="server" Text='<%# Eval("pending_sale") %>'></asp:Label>
                                                        </div>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="No. of shares to be sold" HeaderStyle-Width="12%">
                                                    <ItemTemplate>
                                                        <div class="remark" style="text-align: left;">
                                                            <table>
                                                                <tr>
                                                                    <td style="width: 90%;">
                                                                        <asp:TextBox ID="txtOptionsSold" runat="server" CssClass="form-control" OnTextChanged="txtOptionsSold_TextChanged"
                                                                            AutoPostBack="true" onkeypress="return isNumberKey(this,event)" Text='<%# Eval("no_of_option_sold") %>'></asp:TextBox>
                                                                        <asp:Label ID="lblOptionsSold" runat="server" Text='<%# Eval("no_of_option_sold") %>'></asp:Label>
                                                                    </td>
                                                                    <td style="width: 10%;">
                                                                        <asp:Label ID="LblAlert" runat="server" ForeColor="Red" Font-Bold="true" ToolTip="No of options exceeded.."></asp:Label>
                                                                    </td>
                                                                </tr>

                                                            </table>
                                                    </ItemTemplate>
                                                </asp:TemplateField>

                                            </Columns>
                                        </asp:GridView>
                                    </ContentTemplate>
                                </asp:UpdatePanel>

                                <div class="row" style="margin-top: 15px;">
                                    <%--  <div class="col-lg-12 col-md-12 col-sm-12">
                                        <div class="form-group">
                                            <div class="section-title" style="margin-bottom: 15px;">Payment Mode</div>
                                            <div class="col-lg-2">
                                                <div class="custom-control custom-radio custom-control-inline" style="margin-bottom: 15px;">
                                                    <input type="radio" id="customRadioInline4" name="customRadioInline3" class="custom-control-input" value="Cheque">
                                                    <label class="custom-control-label" for="customRadioInline4">Cheque</label>
                                                </div>
                                            </div>
                                            <div class="col-lg-3">
                                                <div class="custom-control custom-radio custom-control-inline">
                                                    <input type="radio" id="customRadioInline3" name="customRadioInline3" class="custom-control-input" value="neft">
                                                    <label class="custom-control-label" for="customRadioInline3">NEFT (Bank Transfer)</label>
                                                </div>
                                            </div>                                            
                                        </div>
                                    </div>--%>

                                    <!--Cheque Options-->
                                    <div class="col-lg-3 col-md-12 col-sm-12 Cheque">
                                        <div class="form-group">
                                            <label>Bank acc Details</label>
                                            <label style="color: red">*</label>
                                            <div class="input-group mb-3">
                                                <asp:UpdatePanel ID="Updatepanel5" runat="server">
                                                    <ContentTemplate>
                                                        <asp:DropDownList ID="ddlChequeBankName" runat="server" class="form-control DrpWidth" AutoPostBack="true"
                                                            OnSelectedIndexChanged="ddlChequeBankName_SelectedIndexChanged" onchange="dropchange()">
                                                        </asp:DropDownList>
                                                        <asp:RequiredFieldValidator ID="rfvddlChequeBankName" runat="server"
                                                            ErrorMessage="Please select Bank" ControlToValidate="ddlChequeBankName" ValidationGroup="Add" ForeColor="Red" InitialValue="0"
                                                            Display="None" CssClass="validation" SetFocusOnError="true"></asp:RequiredFieldValidator>
                                                    </ContentTemplate>
                                                </asp:UpdatePanel>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="col-lg-6 col-md-12 col-sm-12">
                                        <div class="col-lg-12 col-md-12 col-sm-12">
                                            <div class="form-group mt-4 pt-2">
                                                <asp:Button ID="btnmsg1" type="button" runat="server" class="btn btn-info btn-lg" Text="Bank Details" data-toggle="modal" data-target="#modalbankdetails"></asp:Button>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="col-lg-3 col-md-12 col-sm-12 Cheque">
                                        <div class="form-group">
                                        </div>
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
                                    <%-- <div class="col-lg-3 col-md-12 col-sm-12 Cheque">
                                        <div class="form-group">
                                            <label>MICR Code</label>

                                           
                                            <asp:TextBox ID="txtChequeMICR" runat="server" CssClass="form-control" MaxLength="30"></asp:TextBox>
                                            <asp:RequiredFieldValidator ID="rfvtxtChequeMICR" runat="server"
                                                ErrorMessage="MICR Code is required" ControlToValidate="txtChequeMICR" ValidationGroup="Add" ForeColor="Red"
                                                Display="None" CssClass="validation" SetFocusOnError="true"></asp:RequiredFieldValidator>

                                        </div>
                                    </div>--%>
                                    <%--<div class="col-lg-3 col-md-12 col-sm-12 Cheque">
                                        <div class="form-group">
                                            <label>Cheque Number</label>
                                            
                                            <asp:TextBox ID="txtChequeNo" runat="server" CssClass="form-control" MaxLength="20"></asp:TextBox>
                                            <asp:RequiredFieldValidator ID="rfvtxtChequeNo" runat="server"
                                                ErrorMessage="Cheque Number is required" ControlToValidate="txtChequeNo" ValidationGroup="Add" ForeColor="Red"
                                                Display="None" CssClass="validation" SetFocusOnError="true"></asp:RequiredFieldValidator>
                                        </div>
                                    </div>
                                    <div class="col-lg-3 col-md-12 col-sm-12 Cheque">
                                        <div class="form-group">
                                            <label>Cheque Date</label>
                                            
                                            <asp:TextBox ID="txtChequeDate" runat="server" CssClass="form-control" Placeholder="dd-mm-yyyy" autocomplete="off"></asp:TextBox>
                                            <asp:RequiredFieldValidator ID="rfvtxtChequeDate" runat="server"
                                                ErrorMessage="Cheque Date is required" ControlToValidate="txtChequeDate" ValidationGroup="Add" ForeColor="Red"
                                                Display="None" CssClass="validation" SetFocusOnError="true"></asp:RequiredFieldValidator>
                                        </div>
                                    </div>
                                    <div class="col-lg-3 col-md-12 col-sm-12 Cheque">
                                        <div class="form-group">
                                            <label>Cheque Amount</label>
                                            
                                            <asp:TextBox ID="txtChequeAmount" runat="server" CssClass="form-control" MaxLength="12" onkeypress="return isNumberKey(event)"></asp:TextBox>
                                            <asp:RequiredFieldValidator ID="rfvtxtChequeAmount" runat="server"
                                                ErrorMessage="Cheque Amount is required" ControlToValidate="txtChequeAmount" ValidationGroup="Add" ForeColor="Red"
                                                Display="None" CssClass="validation" SetFocusOnError="true"></asp:RequiredFieldValidator>
                                        </div>
                                    </div>--%>
                                    <%-- <div class="col-lg-3 col-md-12 col-sm-12 Cheque">
                                        <div class="form-group">
                                            <label>Upload File</label>
                                            <input type="file" class="form-control">
                                        </div>
                                    </div>--%>
                                    <div class="col-lg-3 col-md-12 col-sn-12 form-group filter hdpe Cheque" style="padding-left: 35px;">
                                        <label>Cancel Cheque Screenshot</label>
                                        <div class="letterview" style="width: 130px; display: none;" id="divCheque">
                                            <figure class="snip0013">
                                                <img src="assets/img/Cancelled-Cheque.jpg" width="150" height="70">
                                                <a href="img/doc.doc" download="">
                                                    <asp:UpdatePanel ID="Updatepanel22" runat="server">
                                                        <ContentTemplate>
                                                            <asp:LinkButton ID="lnkChequeDownload" runat="server" Text="Download" OnClick="lnkChequeDownload_Click">
                                                                <p><i class="fas fa-download"></i>Download</p>
                                                            </asp:LinkButton>
                                                        </ContentTemplate>
                                                        <Triggers>
                                                            <asp:PostBackTrigger ControlID="lnkChequeDownload" />
                                                        </Triggers>
                                                    </asp:UpdatePanel>
                                                </a>
                                            </figure>
                                        </div>
                                    </div>
                                    <!--Cheque Ends-->
                                    <!--NEFT options-->
                                    <%--<div class="col-lg-3 col-md-12 col-sm-12 neft">
                                        <div class="form-group">
                                            <label>Bank acc Details</label>
                                            <div class="input-group mb-3">
                                                <asp:UpdatePanel ID="Updatepanel9" runat="server">
                                                    <ContentTemplate>
                                                        <asp:DropDownList ID="ddlNEFTBankName" runat="server" class="form-control" AutoPostBack="true"
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
                                    <div class="col-lg-3 col-md-12 col-sm-12 neft">
                                    </div>
                                    <div class="col-lg-3 col-md-12 col-sm-12 neft">
                                    </div>
                                    <div class="col-lg-3 col-md-12 col-sm-12 neft">
                                    </div>
                                    <div class="col-lg-3 col-md-12 col-sm-12 neft">
                                        <div class="form-group">
                                            <label>Bank Name</label>
                                            <asp:UpdatePanel ID="Updatepanel10" runat="server">
                                                <ContentTemplate>
                                                  
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
                                            <asp:UpdatePanel ID="Updatepanel11" runat="server">
                                                <ContentTemplate>
                                              
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
                                            <asp:UpdatePanel ID="Updatepanel12" runat="server">
                                                <ContentTemplate>
                                               
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
                                            <asp:UpdatePanel ID="Updatepanel13" runat="server">
                                                <ContentTemplate>
                                                  
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
                                    </div>--%>
                                    <%--<div class="col-lg-3 col-md-12 col-sm-12 neft">
                                        <div class="form-group">
                                            <label>UTR / Transfer Reference Number</label>
                                            
                                            <asp:TextBox ID="txtNEFTUTR" runat="server" CssClass="form-control" MaxLength="25"></asp:TextBox>
                                            <asp:RequiredFieldValidator ID="rfvtxtNEFTUTR" runat="server"
                                                ErrorMessage="UTR / Transfer Reference Number is required" ControlToValidate="txtNEFTUTR" ValidationGroup="Add" ForeColor="Red"
                                                Display="None" CssClass="validation" SetFocusOnError="true"></asp:RequiredFieldValidator>
                                        </div>
                                    </div>--%>
                                    <%--<div class="col-lg-3 col-md-12 col-sm-12 neft">
                                        <div class="form-group">
                                            <label>Upload Transaction Screenshot</label>
                                            <input type="file" class="form-control">
                                        </div>
                                    </div>
                                    <div class="col-lg-3 col-md-12 col-sn-12 form-group filter hdpe neft" style="padding-left: 35px;">
                                        <label>Transaction Screenshot</label>
                                        <div class="letterview" style="width: 130px;">
                                            <figure class="snip0013">
                                                <img src="assets/img/Error.png" width="130">
                                                <a href="img/doc.doc" download="">
                                                    <p><i class="fas fa-download"></i>Screenshot1</p>
                                                </a>
                                            </figure>
                                        </div>
                                    </div>--%>
                                </div>
                                <!--NEFT Ends-->
                                <!--Loan Options-->
                                <%--<div class="col-lg-3 col-md-12 col-sm-12 loan">
                                    <div class="form-group">
                                        <label>Lender Bank Name</label>
                                        
                                        <asp:TextBox ID="txtLoanBankName" runat="server" CssClass="form-control" MaxLength="50"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="rfvtxtLoanBankName" runat="server"
                                            ErrorMessage="Lender Bank Name is required" ControlToValidate="txtLoanBankName" ValidationGroup="Add" ForeColor="Red"
                                            Display="None" CssClass="validation" SetFocusOnError="true"></asp:RequiredFieldValidator>
                                    </div>
                                </div>--%>
                                <%--<div class="col-lg-3 col-md-12 col-sm-12 loan">
                                    <div class="form-group">
                                        <label>Loan Amount</label>
                                       
                                        <asp:TextBox ID="txtLoanAmount" runat="server" CssClass="form-control" MaxLength="12" onkeypress="return isNumberKey(event)"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="rfvtxtLoanAmount" runat="server"
                                            ErrorMessage="Loan Amount is required" ControlToValidate="txtLoanAmount" ValidationGroup="Add" ForeColor="Red"
                                            Display="None" CssClass="validation" SetFocusOnError="true"></asp:RequiredFieldValidator>
                                    </div>
                                </div>--%>
                                <%--<div class="col-lg-3 col-md-12 col-sm-12 loan">
                                    <div class="form-group">
                                        <label>Margin Money Amount</label>
                                        
                                        <asp:TextBox ID="txtLoanMarginAmount" runat="server" CssClass="form-control" MaxLength="12" onkeypress="return isNumberKey(event)"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="rfvtxtLoanMarginAmount" runat="server"
                                            ErrorMessage="Margin Money Amount is required" ControlToValidate="txtLoanMarginAmount" ValidationGroup="Add" ForeColor="Red"
                                            Display="None" CssClass="validation" SetFocusOnError="true"></asp:RequiredFieldValidator>
                                    </div>
                                </div>--%>
                                <%--<div class="col-lg-3 col-md-12 col-sm-12 loan">
                                    <div class="form-group">
                                        <label>Margin Money Payment Mode</label>
                                        <div class="input-group mb-3">
                                            
                                            <asp:DropDownList ID="ddlLoanMarginMode" runat="server" class="form-control">
                                                <asp:ListItem Value="0">Select Payment Mode</asp:ListItem>
                                                <asp:ListItem Value="Cheque">Cheque</asp:ListItem>
                                                <asp:ListItem Value="NEFT">NEFT</asp:ListItem>
                                            </asp:DropDownList>
                                            <asp:RequiredFieldValidator ID="rfvddlLoanMarginMode" runat="server"
                                                ErrorMessage="Please select Payment Mode" ControlToValidate="ddlLoanMarginMode" ValidationGroup="Add" ForeColor="Red" InitialValue="0"
                                                Display="None" CssClass="validation" SetFocusOnError="true"></asp:RequiredFieldValidator>
                                        </div>
                                    </div>
                                </div>--%>
                                <!--Loan Ends-->
                            </fieldset>
                            <%-- <fieldset>
                                <legend style="width: 10%;">Other Details: </legend>--%>
                            <%--  <div class="row" style="margin-top: 15px;">
                                    <div class="col-lg-3 col-md-12 col-sm-12">
                                        <div class="form-group">
                                            <label>Securities Details</label>
                                            <label style="color: red">*</label>
                                            <div class="input-group mb-3">
                                                <asp:UpdatePanel ID="Updatepanel14" runat="server">
                                                    <ContentTemplate>
                                                        <asp:DropDownList ID="ddlOtherSecurity" runat="server" class="form-control DrpWidth" AutoPostBack="true"
                                                            OnSelectedIndexChanged="ddlOtherSecurity_SelectedIndexChanged" onchange="dropchange()">
                                                        </asp:DropDownList>
                                                        <asp:RequiredFieldValidator ID="rfvddlOtherSecurity" runat="server"
                                                            ErrorMessage="Please select Security Name" ControlToValidate="ddlOtherSecurity" ValidationGroup="Add" ForeColor="Red" InitialValue="0"
                                                            Display="None" CssClass="validation" SetFocusOnError="true"></asp:RequiredFieldValidator>
                                                    </ContentTemplate>
                                                </asp:UpdatePanel>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="col-lg-3 col-md-12 col-sm-12">
                                        <div class="form-group">
                                        </div>
                                    </div>
                                    <div class="col-lg-3 col-md-12 col-sm-12">
                                        <div class="form-group">
                                        </div>
                                    </div>
                                    <div class="col-lg-3 col-md-12 col-sm-12">
                                        <div class="form-group">
                                        </div>
                                    </div>
                                    <div class="col-lg-3 col-md-12 col-sm-12">
                                        <div class="form-group">
                                            <label>Security Name</label>
                                            <label style="color: red">*</label>
                                            <asp:UpdatePanel ID="Updatepanel20" runat="server">
                                                <ContentTemplate>                                                  
                                                    <asp:TextBox ID="txtOtherSECURITYNAME" runat="server" CssClass="form-control" MaxLength="100" Enabled="false"></asp:TextBox>
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server"
                                                        ErrorMessage="Security Name is required" ControlToValidate="txtOtherSECURITYNAME" ValidationGroup="Add" ForeColor="Red"
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
                                </div>--%>
                            <%--<div class="col-lg-3 col-md-12 col-sm-12">
                                    <div class="form-group">
                                        <label>Upload Proof of DP ID & Client ID</label>
                                        <input type="file" class="form-control">
                                    </div>
                                </div>--%>
                            <%--  <div class="col-lg-3 col-md-12 col-sm-12">
                                    <div class="form-group">
                                        <label>Proof of DP ID & Client ID</label>
                                        <label style="color: red">*</label>
                                        <div class="letterview" style="width: 130px; display: none;" id="divDPID">
                                            <figure class="snip0013">
                                                <img src="assets/img/Error.png" width="130">
                                                <a href="img/doc.doc" download="">                                                  
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
                                <div class="col-lg-3 col-md-12 col-sm-12">
                                    <div class="form-group">
                                        <label>Proof of PAN Card</label>
                                        <label style="color: red">*</label>
                                        <div class="letterview" style="width: 130px; display: none;" id="divPAN">
                                            <figure class="snip0013">
                                                <img src="assets/img/PAN-card.jpg" width="130" height="70">
                                                <a href="img/doc.doc" download="">                                                   
                                                    <asp:UpdatePanel ID="Updatepanel23" runat="server">
                                                        <ContentTemplate>
                                                            <asp:LinkButton ID="lnkPANCard" runat="server" Text="Download" OnClick="lnkPANCard_Click">
                                                                <p><i class="fas fa-download"></i>Download</p>
                                                            </asp:LinkButton>
                                                        </ContentTemplate>
                                                        <Triggers>
                                                            <asp:PostBackTrigger ControlID="lnkPANCard" />
                                                        </Triggers>
                                                    </asp:UpdatePanel>
                                                </a>
                                            </figure>
                                        </div>
                                    </div>
                                </div>--%>
                            <%--  </fieldset>--%>
                            <fieldset>
                                <legend style="width: 29%; font-size: 1rem;">Download, Fill & Reupload the Documents: </legend>
                                <div class="row">
                                    <div class="col-lg-2 col-md-2 col-sm-2 col-xs-6 filter hdpe">
                                        <div class="letterview">
                                            <figure class="snip0013">
                                                <img src="assets/img/Error.png" width="130" />
                                                <a href="img/doc.doc" download>
                                                    <%--<p><i class="fas fa-download"></i>ESOP Sale Offer</p>--%>
                                                    <asp:UpdatePanel ID="Updatepanel1" runat="server">
                                                        <ContentTemplate>
                                                            <asp:LinkButton ID="lnkSaleOffer" runat="server" Text="Download" OnClick="lnkSaleOffer_Click">
                                                                <p><i class="fas fa-download"></i>ESOP Sale Offer</p>
                                                            </asp:LinkButton>
                                                        </ContentTemplate>
                                                        <Triggers>
                                                            <asp:PostBackTrigger ControlID="lnkSaleOffer" />
                                                        </Triggers>
                                                    </asp:UpdatePanel>
                                                </a>
                                            </figure>
                                        </div>
                                    </div>
                                    <div class="col-lg-2 col-md-2 col-sm-2 col-xs-6 filter hdpe">
                                        <div class="letterview">
                                            <figure class="snip0013">
                                                <img src="assets/img/Error1.png" width="130" />
                                                <a href="img/doc2.doc" download>
                                                    <%-- <p><i class="fas fa-download"></i>ESOP Declaration</p>--%>
                                                    <asp:UpdatePanel ID="Updatepanel21" runat="server">
                                                        <ContentTemplate>
                                                            <asp:LinkButton ID="lnkSaleDeclaration" runat="server" Text="Download" OnClick="lnkSaleDeclaration_Click">
                                                                <p><i class="fas fa-download"></i>ESOP Declaration</p>
                                                            </asp:LinkButton>
                                                        </ContentTemplate>
                                                        <Triggers>
                                                            <asp:PostBackTrigger ControlID="lnkSaleDeclaration" />
                                                        </Triggers>
                                                    </asp:UpdatePanel>
                                                </a>
                                            </figure>
                                        </div>
                                    </div>


                                    <%--<div class="col-lg-2 col-md-2 col-sm-2 col-xs-6 filter hdpe">
                                        <div class="letterview">
                                            <figure class="snip0013">
                                                <img src="assets/img/Error1.png" width="130" />
                                                <a href="img/doc2.doc" download>
                                                    <asp:UpdatePanel ID="Updatepanel12" runat="server">
                                                        <ContentTemplate>
                                                            <asp:LinkButton ID="lnkSaleTransactionReceipt" runat="server" Text="Download" OnClick="lnkSaleTransactionReceipt_Click">
                                                                <p><i class="fas fa-download"></i>Sale Transaction Receipt</p>
                                                            </asp:LinkButton>
                                                        </ContentTemplate>
                                                        <Triggers>
                                                            <asp:PostBackTrigger ControlID="lnkSaleTransactionReceipt" />
                                                        </Triggers>
                                                    </asp:UpdatePanel>
                                                </a>
                                            </figure>
                                        </div>
                                    </div>--%>


                                    <div class="col-lg-4 col-md-12 col-sm-12">
                                        <asp:UpdatePanel ID="Updatepanel9" runat="server">
                                            <ContentTemplate>
                                                <div class="form-group">
                                                    <%--<label style="white-space: nowrap;">Upload ESOP Sale Offer:<span style="color: red"> *</span></label>
                                            <asp:FileUpload ID="fileupSaleOffer" runat="server" CssClass="dropify" />
                                            <asp:UpdatePanel ID="Updatepanel10" runat="server">
                                                <ContentTemplate>
                                                    <asp:Label ID="LblSaleOffer" runat="server" Font-Bold="true" Style="margin-top: 5px; display: inline-block;"></asp:Label>
                                                </ContentTemplate>
                                                <Triggers>
                                                    <asp:AsyncPostBackTrigger ControlID="gvExercise" />
                                                    <asp:AsyncPostBackTrigger ControlID="ddlChequeBankName" />
                                                </Triggers>
                                            </asp:UpdatePanel>--%>

                                                    <label style="white-space: nowrap;">Upload ESOP Sale Offer:<span style="color: red"> *</span></label>
                                                    <cc1:AsyncFileUpload runat="server" ID="fuCheque" Width="100%" UploaderStyle="Traditional" CompleteBackColor="White"
                                                        UploadingBackColor="#CCFFFF" ThrobberID="imgLoader" OnUploadedComplete="fuCheque_UploadedComplete" OnClientUploadComplete="uploadComplete" CssClass="form-control"
                                                        ErrorBackColor="Transparent" OnClientUploadStarted="uploadStart" OnClientUploadError="uploadError"></cc1:AsyncFileUpload>
                                                    <asp:Label ID="lblFileType1" runat="server" Text="(Only .jpg, .png files are allowed.)" ForeColor="Green" Font-Bold="true" Font-Size="14px"></asp:Label>
                                                </div>
                                            </ContentTemplate>
                                            <Triggers>
                                                <asp:PostBackTrigger ControlID="fuCheque" />
                                            </Triggers>
                                        </asp:UpdatePanel>
                                        <asp:Label ID="LblSaleOffer" runat="server" Font-Bold="true" Style="margin-top: 5px; display: inline-block;"></asp:Label>
                                        <asp:TextBox ID="TextBox0" runat="server" Style="display: none"></asp:TextBox>
                                        <%----%>
                                        <asp:RequiredFieldValidator ID="rfvtxtfuCheque" runat="server"
                                            ErrorMessage="Please upload Sale Offer." ControlToValidate="TextBox0" ValidationGroup="Add" ForeColor="Red"
                                            Display="None" CssClass="validation" SetFocusOnError="true"></asp:RequiredFieldValidator>
                                    </div>
                                    <%--<div class="col-lg-2 col-md-12 col-sm-12">
                                        <div class="form-group text-right" style="padding-top: 25px;">

                                            <asp:Button runat="server" ID="btnUpload" OnClick="btnUpload_Click" Text="Upload" OnClientClick="return SaleOffer_ReqValidation();" Style="font-size: 13px; font-weight: 500; letter-spacing: 0.2px; margin: 0; color: #ffffff; clear: both; background: #2600ff; padding: 5px !important; line-height: 14px; height: 28px; border-radius: .25rem;" />
                                        </div>
                                    </div>--%>
                                    <div class="col-lg-4 col-md-12 col-sm-12">
                                        <asp:UpdatePanel ID="Updatepanel10" runat="server">
                                            <ContentTemplate>
                                                <div class="form-group">

                                                    <%--<label style="white-space: nowrap;">Upload ESOP Sale Declaration: <span style="color: red">*</span></label>
                                            <asp:FileUpload ID="FileupSaleDeclaration" runat="server" CssClass="dropify" />
                                            <asp:UpdatePanel ID="Updatepanel9" runat="server">
                                                <ContentTemplate>
                                                    <asp:Label ID="lblSaleDeclaration" runat="server" Font-Bold="true" Style="margin-top: 5px; display: inline-block;"></asp:Label>
                                                </ContentTemplate>
                                                <Triggers>
                                                    <asp:AsyncPostBackTrigger ControlID="gvExercise" />
                                                    <asp:AsyncPostBackTrigger ControlID="ddlChequeBankName" />
                                                </Triggers>
                                            </asp:UpdatePanel>--%>
                                                    <label style="white-space: nowrap;">Upload ESOP Sale Declaration: <span style="color: red">*</span></label>

                                                    <cc1:AsyncFileUpload runat="server" ID="AsynFileupSaleDeclaration" Width="100%" UploaderStyle="Traditional" CompleteBackColor="White"
                                                        UploadingBackColor="#CCFFFF" ThrobberID="imgLoader" OnUploadedComplete="AsynFileupSaleDeclaration_UploadedComplete" OnClientUploadComplete="uploadComplete_1" CssClass="form-control"
                                                        ErrorBackColor="Transparent" OnClientUploadStarted="uploadStart" OnClientUploadError="uploadError"></cc1:AsyncFileUpload>
                                                    <asp:Label ID="lblFiletype2" runat="server" Text="(Only .jpg, .png files are allowed.)" ForeColor="Green" Font-Bold="true" Font-Size="14px"></asp:Label>
                                                </div>
                                            </ContentTemplate>
                                            <Triggers>
                                                <asp:PostBackTrigger ControlID="AsynFileupSaleDeclaration" />
                                            </Triggers>
                                        </asp:UpdatePanel>
                                        <asp:Label ID="lblSaleDeclaration" runat="server" Font-Bold="true" Style="margin-top: 5px; display: inline-block;"></asp:Label>
                                        <asp:TextBox ID="TextBox1" runat="server" Style="display: none"></asp:TextBox>
                                        <%----%>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server"
                                            ErrorMessage="Please upload Sale Declaration." ControlToValidate="TextBox1" ValidationGroup="Add" ForeColor="Red"
                                            Display="None" CssClass="validation" SetFocusOnError="true"></asp:RequiredFieldValidator>
                                    </div>

                                    <div class="col-md-6 text-right">
                                        <asp:UpdatePanel ID="Updatepanel12" runat="server">
                                            <ContentTemplate>
                                                <asp:Button ID="btnimport1" CssClass="btn btn-info btn-lg" Style="margin-bottom: 15px;" runat="server" Text="Preview1"
                                                    OnClick="btnimport_Click1" />
                                            </ContentTemplate>
                                        </asp:UpdatePanel>
                                    </div>
                                    <%--<div class="col-lg-2 col-md-12 col-sm-12">
                                        <div class="form-group text-right" style="padding-top: 25px;">

                                            <asp:Button runat="server" ID="BtnSaleDeclaration" OnClick="BtnSaleDeclaration_Click" OnClientClick="return SaleDeclaration_ReqValidation();" Text="Upload" Style="font-size: 13px; font-weight: 500; letter-spacing: 0.2px; margin: 0; color: #ffffff; clear: both; background: #2600ff; padding: 5px !important; line-height: 14px; height: 28px; border-radius: .25rem;" />
                                        </div>
                                    </div>--%>

                                    <%--<div class="col-lg-2 col-md-12 col-sm-12" style="left: 364px;">
                                        <div class="form-group">
                                            <label style="white-space: nowrap;">Upload Transaction Receipt: <span style="color: red">*</span></label>
                                            <asp:FileUpload ID="FileupTransactionReceipt" runat="server" CssClass="dropify" />
                                            <asp:UpdatePanel ID="Updatepanel11" runat="server">
                                                <ContentTemplate>
                                                    <asp:Label ID="lblTransactionReceipt" runat="server" Font-Bold="true" Style="margin-top: 5px; display: inline-block;"></asp:Label>
                                                </ContentTemplate>
                                                <Triggers>
                                                    <asp:AsyncPostBackTrigger ControlID="gvExercise" />
                                                    <asp:AsyncPostBackTrigger ControlID="ddlChequeBankName" />
                                                </Triggers>
                                            </asp:UpdatePanel>
                                        </div>
                                    </div>--%>

                                    <%--<div class="col-lg-2 col-md-12 col-sm-12" style="left: 364px;">
                                        <div class="form-group text-right" style="padding-top: 25px;">

                                            <asp:Button runat="server" ID="btnTransactionReceipt" OnClick="btnTransactionReceipt_Click" OnClientClick="return TransactionReceipt_ReqValidation();" Text="Upload" Style="font-size: 13px; font-weight: 500; letter-spacing: 0.2px; margin: 0; color: #ffffff; clear: both; background: #2600ff; padding: 5px !important; line-height: 14px; height: 28px; border-radius: .25rem;" />
                                        </div>
                                    </div>--%>
                            </fieldset>

                            <fieldset id="uploadTransactionRpt" runat="server" style="visibility: hidden">
                                <legend style="width: 29%; font-size: 1rem;">Upload Transaction Receipt: </legend>
                                <div class="row">
                                    <div class="col-lg-4 col-md-12 col-sm-12">
                                        <asp:UpdatePanel ID="Updatepanel11" runat="server">
                                            <ContentTemplate>
                                                <div class="form-group">
                                                    <label style="white-space: nowrap;">Upload Transaction Receipt: <span style="color: red">*</span></label>
                                                    <%--<asp:FileUpload ID="FileupTransactionReceipt" runat="server" CssClass="dropify" />
                                            <asp:UpdatePanel ID="Updatepanel16" runat="server">
                                                <ContentTemplate>
                                                    <asp:Label ID="lblTransactionReceipt" runat="server" Font-Bold="true" Style="margin-top: 5px; display: inline-block;"></asp:Label>
                                                </ContentTemplate>
                                                <Triggers>
                                                    <asp:AsyncPostBackTrigger ControlID="gvExercise" />
                                                    <asp:AsyncPostBackTrigger ControlID="ddlChequeBankName" />
                                                </Triggers>
                                            </asp:UpdatePanel>--%>

                                                    <cc1:AsyncFileUpload runat="server" ID="AsyncFileupTransactionReceipt" Width="100%" UploaderStyle="Traditional" CompleteBackColor="White"
                                                        UploadingBackColor="#CCFFFF" ThrobberID="imgLoader" OnUploadedComplete="AsyncFileupTransactionReceipt_UploadedComplete" OnClientUploadComplete="uploadComplete_2" CssClass="form-control"
                                                        ErrorBackColor="Transparent" OnClientUploadStarted="uploadStart" OnClientUploadError="uploadError"></cc1:AsyncFileUpload>
                                                    <asp:Label ID="lblFileType3" runat="server" Text="(Only .jpg, .png files are allowed.)" ForeColor="Green" Font-Bold="true" Font-Size="14px"></asp:Label>
                                                </div>
                                            </ContentTemplate>
                                            <Triggers>
                                                <asp:PostBackTrigger ControlID="AsyncFileupTransactionReceipt" />
                                                <asp:AsyncPostBackTrigger ControlID="btnimport" EventName="Click" />
                                            </Triggers>
                                        </asp:UpdatePanel>
                                        <asp:Label ID="lblTransactionReceipt" runat="server" Font-Bold="true" Style="margin-top: 5px; display: inline-block;"></asp:Label>
                                        <asp:TextBox ID="TextBox2" runat="server" Style="display: none"></asp:TextBox>
                                        <%----%>
                                        <%-- <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server"
                                            ErrorMessage="Please upload Transaction Receipt." ControlToValidate="TextBox2" ValidationGroup="Add" ForeColor="Red"
                                            Display="None" CssClass="validation" SetFocusOnError="true"></asp:RequiredFieldValidator>--%>
                                    </div>

                                    <%--<div class="col-lg-2 col-md-12 col-sm-12">
                                        <div class="form-group text-right" style="padding-top: 25px;">

                                            <asp:Button runat="server" ID="btnTransactionReceipt" OnClick="btnTransactionReceipt_Click" OnClientClick="return TransactionReceipt_ReqValidation();" Text="Upload" Style="font-size: 13px; font-weight: 500; letter-spacing: 0.2px; margin: 0; color: #ffffff; clear: both; background: #2600ff; padding: 5px !important; line-height: 14px; height: 28px; border-radius: .25rem;" />
                                        </div>
                                    </div>--%>
                                </div>
                            </fieldset>
                        </div>
                        <div class="row">
                            <div class="col-lg-12 mt-1">
                                <%--<a href="#" class="btn btn-info btn-lg" data-toggle="modal" data-target=".bd-example-modal-lg1"data-toggle="modal" data-target=".bd-example-modal-lg1" runat="server" id="btnsumbit"
                                        validationgroup="Add" causesvalidation="true">Submit</a>--%>
                                <asp:UpdatePanel ID="Updatepanel4" runat="server">
                                    <ContentTemplate>
                                        <div class="row">
                                            <div class="col-md-6 text-right">
                                                <asp:ValidationSummary runat="server" ShowMessageBox="true" ShowSummary="false" ValidationGroup="Add" />
                                                <asp:Button ID="btnimport" Visible="false" CssClass="btn btn-info btn-lg" Style="margin-bottom: 15px;" runat="server" Text="Preview"
                                                    CausesValidation="true" OnClick="btnimport_Click" OnClientClick="Change_Session_Value();" />
                                                <asp:Button ID="btnSession" CssClass="btn btn-info btn-lg" runat="server" Text="Session" OnClick="btnSession_Click" Style="display: none;" />
                                            </div>
                                            <div class="col-md-5 text-right">
                                                <label style="color: red">All (*) marked fields are mandatory.</label>
                                            </div>
                                        </div>
                                    </ContentTemplate>
                                </asp:UpdatePanel>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </section>
    </div>

    <div class="modal fade bd-example-modal-lg1" tabindex="-1" role="dialog" aria-labelledby="myLargeModalLabel" aria-hidden="true" style="display: none;" id="modalPreview">
        <div class="modal-dialog modal-lg">
            <div class="modal-content">
                <div class="modal-header">
                    <h5 class="modal-title" id="myLargeModalLabel">Preview Employee Sale</h5>
                    <%-- <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                        <span aria-hidden="true">×</span>
                    </button>--%>

                    <%-- <span style="float:right">
                        <asp:Button ID="BtnClosePopup" runat="server" Text="X" data-dismiss="modal" aria-label="Close" aria-hidden="true" ForeColor="Black" />
                    </span>--%>
                </div>
                <br />
                <br />

                <div style="text-align: center;">

                    <%--<div class="pnl_item">
                        <a href="#">
                            <img src="img/mount_e2.jpg" width="98" height="65" class="pnl" /></a>
                        <div class="pnl_item2">
                            <img src="img/mount_e2.jpg" alt="" width="398" height="265" class="bdr_set" />
                            <span class="overlay"></span>
                        </div>
                    </div>--%>
                </div>
                <asp:UpdatePanel ID="UpdatePanel3" runat="server" UpdateMode="Conditional">
                    <ContentTemplate>
                        <div class="modal-body" style="padding-left: 15px; padding-right: 15px;">
                            <fieldset style="margin-bottom: 0px; padding-block-end: 0px;">
                                <legend style="width: 20%; font-size: 1rem;">Basic Information: </legend>
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
                                            <label class="pop">Total Amount(₹)</label>
                                        </div>
                                    </div>
                                    <div class="col-lg-3 col-md-3 col-sm-3" style="padding-right: 5px; padding-left: 17px;">
                                        <div class="form-group">
                                            <label class="pops" runat="server" id="lblTotalAmount"></label>
                                        </div>
                                    </div>
                                    <%--  <div class="col-lg-3 col-md-3 col-sm-3" style="padding-right: 5px; padding-left: 17px;">
                                        <div class="form-group">
                                            <label class="pop">Payment Mode:</label>
                                        </div>
                                    </div>
                                    <div class="col-lg-3 col-md-3 col-sm-3" style="padding-right: 5px; padding-left: 17px;">
                                        <div class="form-group">                                        
                                            <label class="pops" id="lblPaymantMode"></label>
                                            <asp:HiddenField ID="hfPaymantMode" runat="server" />
                                        </div>
                                    </div>--%>
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
                                    <%-- <div class="col-lg-3 col-md-3 col-sm-3 Cheque" style="padding-right: 5px; padding-left: 17px;">
                                        <div class="form-group">
                                            <label class="pop">MICR Code</label>
                                        </div>
                                    </div>
                                    <div class="col-lg-3 col-md-3 col-sm-3 Cheque" style="padding-right: 5px; padding-left: 17px;">
                                        <div class="form-group">                                           
                                            <label class="pops" runat="server" id="lblChequeMICR"></label>
                                        </div>
                                    </div>--%>
                                    <%--<div class="col-lg-3 col-md-3 col-sm-3 Cheque" style="padding-right: 5px; padding-left: 17px;">
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
                                            <label class="pop">Cheque Amount</label>
                                        </div>
                                    </div>
                                    <div class="col-lg-3 col-md-3 col-sm-3 Cheque" style="padding-right: 5px; padding-left: 17px;">
                                        <div class="form-group">
                                           
                                            <label class="pops" runat="server" id="lblChequeAmount"></label>
                                        </div>
                                    </div>
                                    <div class="col-lg-3 col-md-3 col-sm-3 Cheque" style="padding-right: 5px; padding-left: 17px;">
                                        <div class="form-group">
                                            <label class="pop">Upload File</label>
                                        </div>
                                    </div>
                                    <div class="col-lg-3 col-md-3 col-sm-3 Cheque" style="padding-right: 5px; padding-left: 17px;">
                                        <div class="form-group">
                                            <label class="pops">demo.xlsx</label>
                                        </div>
                                    </div>--%>
                                    <%--NEFT start--%>
                                    <%--<div class="col-lg-3 col-md-3 col-sm-3 neft" style="padding-right: 5px; padding-left: 17px;">
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
                                    </div>--%>
                                    <%-- <div class="col-lg-3 col-md-3 col-sm-3 neft" style="padding-right: 5px; padding-left: 17px;">
                                        <div class="form-group">
                                            <label class="pop">UTR / Transfer Reference Number</label>
                                        </div>
                                    </div>--%>
                                    <%--<div class="col-lg-3 col-md-3 col-sm-3 neft" style="padding-right: 5px; padding-left: 17px;">
                                        <div class="form-group">
                                            
                                            <label class="pops" runat="server" id="lblNEFTUTR"></label>
                                        </div>
                                    </div>--%>
                                    <%--<div class="col-lg-3 col-md-3 col-sm-3 neft" style="padding-right: 5px; padding-left: 17px;">
                                        <div class="form-group">
                                            <label class="pop">Upload Transaction Screenshot</label>
                                        </div>
                                    </div>
                                    <div class="col-lg-3 col-md-3 col-sm-3 neft" style="padding-right: 5px; padding-left: 17px;">
                                        <div class="form-group">
                                            <label class="pops">demo.xlsx</label>
                                        </div>
                                    </div>--%>
                                    <%-- NEFT end--%>
                                    <%--Loan start--%>
                                    <%-- <div class="col-lg-3 col-md-3 col-sm-3 loan" style="padding-right: 5px; padding-left: 17px;">
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
                                            <label class="pop">Loan Amount</label>
                                        </div>
                                    </div>
                                    <div class="col-lg-3 col-md-3 col-sm-3 loan" style="padding-right: 5px; padding-left: 17px;">
                                        <div class="form-group">
                                            
                                            <label class="pops" runat="server" id="lblLoanAmount"></label>
                                        </div>
                                    </div>
                                    <div class="col-lg-3 col-md-3 col-sm-3 loan" style="padding-right: 5px; padding-left: 17px;">
                                        <div class="form-group">
                                            <label class="pop">Margin Money Amount</label>
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
                                    </div>--%>
                                    <%--Loan end--%>
                                </div>
                            </fieldset>

                            <fieldset style="margin-bottom: 0px; padding-block-end: 0px;">
                                <legend style="width: 15%; font-size: 1rem;">DMAT Details: </legend>
                                <div class="row popRow">
                                    <div class="col-lg-3 col-md-3 col-sm-3" style="padding-right: 5px; padding-left: 17px;">
                                        <div class="form-group">
                                            <label class="pop">Security Name:</label>
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
                                    <%-- <div class="col-lg-3 col-md-3 col-sm-3" style="padding-right: 5px; padding-left: 17px;">
                                        <div class="form-group">
                                            <label class="pop">Upload Proof of DP ID & Client ID :</label>
                                        </div>
                                    </div>
                                    <div class="col-lg-3 col-md-3 col-sm-3" style="padding-right: 5px; padding-left: 17px;">
                                        <div class="form-group">                                            
                                            <asp:Image ID="Image2" ImageUrl="" runat="server" CssClass="img" />
                                        </div>
                                    </div>--%>

                                    <fieldset style="margin-bottom: 0px; padding-block-end: 0px;">
                                        <legend style="width: 15%; font-size: 1rem;">Upload ESOP Sale Offer: </legend>



                                        <%--<div class="n_pnl">
                                            <center><a href="#"><img src="img/mount_e.jpg" width="98" height="65"></a></center>
                                            <span class="n_pnltext">
                                                <img src="img/mount_e.jpg" width="398" height="265"></span>
                                        </div>--%>

                                        <asp:Image ID="Image2" ImageUrl="" runat="server" CssClass="img Image2" />
                                        <%--<figure class="snip0014" style="margin-top: 8px; height: 113px !important; left: 0px;">
                                            <asp:Image ID="Image2" ImageUrl="" runat="server" CssClass="img Image2" />
                                        </figure>--%>
                                    </fieldset>





                                    <fieldset style="margin-bottom: 0px; padding-block-end: 0px;">
                                        <legend style="width: 15%; font-size: 1rem;">Upload ESOP Sale Declaration:</legend>
                                        <asp:Image ID="Image1" ImageUrl="" runat="server" CssClass="img Image1" />
                                        <%--<div class="n_pnl">
                                            <center><a href="#"><img src="img/mount_e2.jpg" width="98" height="65"></a</center>
                                            <span class="n_pnltext">
                                                <img src="img/mount_e2.jpg" width="398" height="265"></span>
                                        </div>--%>

                                        <%--<figure class="snip0014" style="margin-top: 8px; height: 113px !important; left: 0px;">
                                            <asp:Image ID="Image1" ImageUrl="" runat="server" CssClass="img Image1" />
                                        </figure>--%>
                                    </fieldset>

                                    <fieldset id="uploadTransactionRpt1" runat="server" style="margin-bottom: 0px; padding-block-end: 0px; visibility: hidden">
                                        <legend style="width: 15%; font-size: 1rem;">Upload Transaction Receipt</legend>
                                        <asp:Image ID="Image3" ImageUrl="" runat="server" CssClass="img Image3" />
                                        <%--<figure class="snip0014" style="margin-top: 8px; height: 113px !important; left: 0px;">
                                            <asp:Image ID="Image3" ImageUrl="" runat="server" CssClass="img Image3" />
                                        </figure>--%>
                                    </fieldset>
                            </fieldset>

                            <%--  <fieldset style="margin-bottom: 0px; padding-block-end: 0px;">
                                <legend style="width: 15%; font-size: 1rem;">Proof of DP ID & Client ID </legend>
                                <asp:Image ID="Image2" ImageUrl="" runat="server" CssClass="img" />
                            </fieldset>
                            <fieldset style="margin-bottom: 0px; padding-block-end: 0px;">
                                <legend style="width: 15%; font-size: 1rem;">Proof of PAN Card </legend>
                                <asp:Image ID="Image3" ImageUrl="" runat="server" CssClass="img" />
                            </fieldset>--%>
                        </div>
                    </ContentTemplate>
                    <Triggers>
                        <asp:AsyncPostBackTrigger ControlID="btnimport1" EventName="Click" />
                        <asp:AsyncPostBackTrigger ControlID="btnimport" EventName="Click" />
                        <%-- <asp:PostBackTrigger ControlID="btnSubmit" />--%>
                    </Triggers>
                </asp:UpdatePanel>

                <div class="modal-footer bg-whitesmoke br">
                    <div class="btn-group" role="group" aria-label="Basic example">
                        <%--<button type="button" class="btn btn-primary" data-dismiss="modal" style="margin-right: 44%;" id="submit">Submit</button>--%>
                        <%--<asp:UpdatePanel ID="Updatepanel19" runat="server" UpdateMode="Conditional">
                        <ContentTemplate>--%>
                        <asp:Button ID="btnSubmit" CssClass="btn btn-info btn-lg" Style="margin-bottom: 15px;" runat="server" Text="Submit"
                            OnClick="btnSubmit_Click" ValidationGroup="Add" />
                        <%--CausesValidation="false"--%>
                        <a href="#" class="btn btn-info btn-lg all CloseBtnNew" data-dismiss="modal">Close</a>
                    </div>
                </div>

            </div>
        </div>
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
                                    <asp:Label ID="lblFileType" runat="server" Text="(Only .jpg, .png files are allowed.)" ForeColor="Green" Font-Bold="true" Font-Size="14px"></asp:Label>
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
    <!-- General JS Scripts -->

    <script src="assets/js/jquery-1.12.4.js" type="text/javascript"></script>
    <script src="Scripts/bootstrap.min.js"></script>
    <script src="assets/js/scripts.js"></script>

    <script src="assets/js/jquery-ui-1.12.1.js" type="text/javascript"></script>
    <script>
        $(function () {
            //    $.noConflict();
            var from = $("#ContentPlaceHolder1_txtChequeDate")
         .datepicker({
             minDate: 0,
             dateFormat: "dd-M-yy",
             changeMonth: true,
             changeYear: true,

         });
        });
    </script>

    <script>
        $(document).ready(function () {
            $("#submit").click(function () {
                $('input').attr('readonly', true);
                $('select').attr('readonly', true);
            });
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

    <%--  <script src="assets/js/bootstrap-3.3.6.min.js" type="text/javascript"></script>--%>
    <link href="assets/css/bootstrap-3.3.6.min.css" rel="stylesheet" />

    <script type="text/javascript">
        var prm = Sys.WebForms.PageRequestManager.getInstance();
        //prm.add_endRequest(function (s, e) {
        //    //alert('Postback1!');
        //    openModal();
        //});
        function openModal() {
            //$('.Cheque').hide();
            //$("input[type='radio']").click(function () {
            /**$("input[name='customRadioInline3']").change(function() {**/

            <%--   var radioValue = $("input[name='customRadioInline3']:checked").val();
            console.log(radioValue);
            if (radioValue == "Cheque") {
                $('.Cheque').show()
                $('.neft').hide();
                $('.loan').hide();
                document.getElementById('lblPaymantMode').innerHTML = 'Cheque';
                document.getElementById("<%=hfPaymantMode.ClientID %>").value = 'Cheque';
            }
            else if (radioValue == "neft") {
                $('.Cheque').hide()
                $('.neft').show();
                $('.loan').hide();
                document.getElementById('lblPaymantMode').innerHTML = 'NEFT';
                document.getElementById("<%=hfPaymantMode.ClientID %>").value = 'NEFT';
            }
            else if (radioValue == "loan") {
                $('.Cheque').hide()
                $('.neft').hide();
                $('.loan').show();
                document.getElementById('lblPaymantMode').innerHTML = 'Loan';
                document.getElementById("<%=hfPaymantMode.ClientID %>").value = 'Loan';
            }
            else {
                alert('Please Select Payment Mode');
                return;
            }--%>


<%--    prm.add_endRequest(function (s, e) {
        console.log(radioValue);
        if (radioValue == "Cheque") {
            $('.Cheque').show()
            $('.neft').hide();
            $('.loan').hide();
            document.getElementById('lblPaymantMode').innerHTML = 'Cheque';
            document.getElementById("<%=hfPaymantMode.ClientID %>").value = 'Cheque';
        }
        else if (radioValue == "neft") {
            $('.Cheque').hide()
            $('.neft').show();
            $('.loan').hide();
            document.getElementById('lblPaymantMode').innerHTML = 'NEFT';
            document.getElementById("<%=hfPaymantMode.ClientID %>").value = 'NEFT';
        }
        else if (radioValue == "loan") {
            $('.Cheque').hide()
            $('.neft').hide();
            $('.loan').show();
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

    <script type="text/javascript">
        function uploadComplete(sender) {

            // $("#divNEFT").css({ 'display': 'block' });//divCheque
        }

        function uploadComplete1(sender) {

            //$("#divCheque").css({ 'display': 'block' });//divCheque
        }
        function uploadStart(sender, args) {
            var filename = args.get_fileName();
            var filext = filename.substring(filename.lastIndexOf(".") + 1).toLowerCase();
            if (filext == "jpeg" || filext == "png" || filext == "pdf" || filext == "jpg") {
                return true;
            }
            else {
                var err = new Error();
                err.name = 'Doc Format';
                err.message = 'Only .jpeg .png .jpg .pdf files';
                throw (err);
                return false;
            }
        }
        function uploadError(sender, args) {
            alert('Only Image/Pdf file allowed');
        }
    </script>
    <script type="text/javascript">
        $(document).ready(function () {
            dropchange();
        });
        function dropchange() {
            //var id = ddl.id;
            //var value = $("#ddlnoOfCycle1").val();
            //alert(value);

            var ddlCheque = document.getElementById("<%=ddlChequeBankName.ClientID %>");
           <%-- var ddlDPID = document.getElementById("<%=ddlOtherSecurity.ClientID %>");--%>

            var ddlChequeVal = ddlCheque.value;
            //var ddlDPIDVal = ddlDPID.value;

            if (ddlChequeVal == "0") {
                $("#divCheque").css({ 'display': 'none' });

            }
            else {
                $("#divCheque").css({ 'display': 'block' });
            }

            //if (ddlDPIDVal == "0") {
            //    $("#divDPID").css({ 'display': 'none' });
            //    $("#divPAN").css({ 'display': 'none' });

            //}
            //else {
            //    $("#divDPID").css({ 'display': 'block' });
            //    $("#divPAN").css({ 'display': 'block' });
            //}
        }
    </script>

    <script type="text/javascript">
        function SaleOffer_ReqValidation() {
            <%--var file = document.getElementById('<%=fileupSaleOffer.ClientID%>').value;
            if (file.trim() == "") {
                alert("Please upload Sale Offer.");
                document.getElementById('<%=fileupSaleOffer.ClientID%>').focus();
                return false;
            }

            if (file.trim() != "") {
                var ext = file.substr(file.lastIndexOf('.') + 1).toLowerCase();
                if (ext == "png" || ext == "jpg" || ext == "jpeg" || ext == "pdf" || ext == "docx" || ext == "doc") {
                    return true;
                }
                else {
                    alert("Only .jpg, .jpeg, .png, .pdf, .docx , .doc files are allowed.");
                    return false;
                }
            }--%>
        }

        function SaleDeclaration_ReqValidation() {
            <%--var file = document.getElementById('<%=FileupSaleDeclaration.ClientID%>').value;
            if (file.trim() == "") {
                alert("Please upload Sale Declaration.");
                document.getElementById('<%=FileupSaleDeclaration.ClientID%>').focus();
                return false;
            }

            if (file.trim() != "") {
                var ext = file.substr(file.lastIndexOf('.') + 1).toLowerCase();
                if (ext == "png" || ext == "jpg" || ext == "jpeg" || ext == "pdf" || ext == "docx" || ext == "doc") {
                    return true;
                }
                else {
                    alert("Only .jpg, .jpeg, .png, .pdf, .docx , .doc files are allowed.");
                    return false;
                }
            }--%>
        }

        function TransactionReceipt_ReqValidation() {
            <%--var file = document.getElementById('<%=FileupTransactionReceipt.ClientID%>').value;
            if (file.trim() == "") {
                alert("Please upload Transaction Receipt.");
                document.getElementById('<%=FileupTransactionReceipt.ClientID%>').focus();
                return false;
            }

            if (file.trim() != "") {
                var ext = file.substr(file.lastIndexOf('.') + 1).toLowerCase();
                if (ext == "png" || ext == "jpg" || ext == "jpeg" || ext == "pdf" || ext == "docx" || ext == "doc") {
                    return true;
                }
                else {
                    alert("Only .jpg, .jpeg, .png, .pdf, .docx , .doc files are allowed.");
                    return false;
                }
            }--%>
        }
    </script>
    <script type="text/javascript">
        function Change_Session_Value() {
            '<%Session["Emp_Sale_Session"] = "False"; %>';
        }

        <%--$(document).ready(function () {

            timer = setInterval(function () {
                document.getElementById("<%=btnSession.ClientID %>").click();
                //alert("Sale Data Saved");
            }, 30000);
        });--%>
    </script>
    <script type="text/javascript">
        function uploadComplete(sender) {
            $get("<%=LblSaleOffer.ClientID%>").innerHTML = "File Uploaded Successfully";
            document.getElementById('<%=TextBox0.ClientID %>').value = 'file';
        }

        function uploadComplete_1(sender) {
            $get("<%=lblSaleDeclaration.ClientID%>").innerHTML = "File Uploaded Successfully";
            document.getElementById('<%=TextBox1.ClientID %>').value = 'file';
        }

        function uploadComplete_2(sender) {
            $get("<%=lblTransactionReceipt.ClientID%>").innerHTML = "File Uploaded Successfully";
            document.getElementById('<%=TextBox2.ClientID %>').value = 'file';
        }



        function uploadStart(sender, args) {
            var filename = args.get_fileName();
            var filext = filename.substring(filename.lastIndexOf(".") + 1).toLowerCase();
            if (filext == "jpg" || filext == "jpeg" ||
            filext == "png" || filext == "gif" || filext == "pdf" || filext == "doc" || filext == "docx") {
                var a = sender.get_id()

                return true;
            }
            else {

                var a = sender.get_id()

                return false;
            }
        }

        function uploadError(sender, args) {
            alert('Only .jpg, .png, .gif, .pdf, .doc, .docx files are allowed');
        }
    </script>

</asp:Content>
