<%@ Page Language="C#" MasterPageFile="~/ESOP.Master" AutoEventWireup="true" CodeBehind="Grand_Creation.aspx.cs" Inherits="ESOP.Grand_Creation" EnableEventValidation="false" %>


<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ScriptManager ID="script" runat="server"></asp:ScriptManager>

    <style>
        table.dataTable td, table.dataTable th {
            box-sizing: content-box;
            text-align: center;
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
            border-top: none;
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

        .card {
            height: auto;
        }

        .text-muted {
            color: #1ea3c1 !important;
            font-weight: 600;
        }

        .card .card-header h4 {
            font-size: 17px;
        }

        .card .card-header {
            background-color: transparent;
            /*padding: 11px 40px !important;*/
            padding: 5px 40px !important;
        }

        .main-footer {
            margin-top: 32px !important;
        }

        /*.btn-group {
            height: 22px;
        }*/

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

        .card {
            height: auto;
        }

        .text-muted {
            /*color: #1ea3c1 !important;*/
            color: #2773ff !important;
            font-weight: 600;
        }

        .theme-white .nav-pills .nav-link.active {
            color: #2673ff;
            /*color: #0889a9;*/
            background-color: #b0efef70 !important;
            border-bottom: 2px solid #135d6f;
            font-size: 14px;
        }

        .nav-pills .nav-item .nav-link.active {
            color: #fff;
            background-color: #b0efef70;
        }

        .nav-pills .nav-item .nav-link {
            color: #0893c2;
            padding-left: 8px !important;
            padding-right: 8px !important;
            border-radius: 0;
            font-size: 14px;
            background: #8080801f;
            margin-left: 5px;
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

        .form-control:not(.form-control-sm):not(.form-control-lg), .input-group-text, select.form-control:not([size]):not([multiple]) {
            font-size: 14px;
            padding: 0px 0px;
        }

        select.form-control {
            height: 32px !important;
            /*border: 1px solid #615a72;*/
            font-weight: 500;
            color: #3f646d;
            font-size: 14px;
            /*background: #f3f4f4;*/
            border-radius: 6px;
        }

        optgroup {
            font-size: 12px;
            font-weight: 500;
            color: #636060ed;
        }

        div#table-21_length {
            display: none;
        }

        div#table-22_length {
            display: none;
        }

        .offset-md-9 {
            margin-left: 75%;
            margin-top: -25px;
        }

        .offset-md-10 {
            margin-left: 82%;
        }

        .section > :first-child {
            margin-top: -7px;
        }


        .table:not(.table-sm):not(.table-md):not(.dataTable) th {
            background: #6c757d75 !important;
            color: #000000c2 !important;
        }

        .btn {
            height: 34px;
        }

        .form-control:not(.form-control-sm):not(.form-control-lg) {
            font-size: 13px;
            /*padding: 10px 15px !important;
            line-height: 1.4;*/
            height: 31px !important;
        }

        .btn-success, .btn-success.disabled {
            box-shadow: 0 2px 6px #abf2d7;
            background-color: #69e7b8;
            border-color: #69e7b8;
            color: #fff !important;
        }
    </style>
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
        a.btn.btn-icon.btn-primary.form-control {
            /* border-radius: 22px; */
            width: 115% !important;
            color: #fff !important;
            background-color: #2600ff !important;
            padding-top: 6px !important;
        }

        .btn.btn-lg {
            border: 2px solid #09728a;
            /*margin-top: 4px !important;
                 margin-left: -200px;
            font-size: 14px !important;*/
            background: #2600ff !important;
            border: 2px solid #2600ff !important;
        }

        a.btn.btn-icon.btn-primary.form-control {
            border-radius: 22px;
            width: 115% !important;
            color: #fff !important;
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
    <style>
        .mt-5, .my-5 {
            margin-top: 1rem !important;
        }

        .main-footer {
            padding: 20px 0px 20px 280px;
            margin-top: 32px;
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

        label.or {
            font-size: 17px;
            position: absolute;
            right: -13% !important;
            top: 43%;
        }

        .width95 {
            width: 95%;
        }

        .width90 {
            width: 90%;
        }

        .center {
            text-align: center;
            border: 3px solid green;
        }

        /*.modal.show .modal-content {
            width: 85% !important;
            padding-bottom: 12px;
        }*/
    </style>

    <%--  <script type="text/javascript">
        window.onsubmit = function () {
            if (Page_IsValid) {
                var updateProgress = $find("<%= UpdateProgress.ClientID %>");
                window.setTimeout(function () {
                    updateProgress.set_visible(true);
                }, 200);
            }
        }
    </script>--%>
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

    <script language="javascript" type="text/javascript">

        function validate() {


            if (document.getElementById('customRadioInline4').checked) {

                if (document.getElementById('<%=txtDateOfGrant.ClientID%>').value == "") {

                    alert("Please select date of grant");
                    document.getElementById("<%=txtDateOfGrant.ClientID%>").focus();
                    return false;
                }


                if (document.getElementById("<%=ddlFMV.ClientID%>").value == 0) {
                    alert("Please select FMV price");
                    //document.getElementById("<%=ddlFMV.ClientID%>").focus();
                    return false;
                }
                <%--if (document.getElementById("<%=ddlFMV.ClientID%>").value == 'Select FMV') {
                    alert("Please select FMV price");
                    //document.getElementById("<%=ddlFMV.ClientID%>").focus();
                    return false;
                }--%>


                if (document.getElementById("<%=ddlVesting.ClientID %>").value == 0) {
                    alert("Please select Vesting Cycle");
                    //document.getElementById("<%=ddlVesting.ClientID %>").focus();
                    return false;

                 <%--   if (document.getElementById("<%=ddlVesting.ClientID %>").value =='Select Vesting Cycle') {
                    alert("Please select Vesting Cycle");
                    //document.getElementById("<%=ddlVesting.ClientID %>").focus();
                    return false;--%>

                }
                if (document.getElementById("<%=uploadfile.ClientID %>").value == 0) {
                    alert("Please select Excel file");
                    //document.getElementById("<%=ddlVesting.ClientID %>").focus();
                    return false;
                }
                if (document.getElementById("<%=txtLapsMonth.ClientID %>").value == "") {
                    alert("Please enter Lapse Month");
                    return false;
                }

                //Added by Krutika on 11-01-23
                if (document.getElementById('<%=ddlTaxRegime.ClientID%>').value == 0) {
                    alert("Please select Tax Regime");
                    //document.getElementById("<%=ddlTaxRegime.ClientID%>").focus();
                    return false;
                }

                var updateProgress1 = $get("<%= UpdateProgress1.ClientID %>");
                updateProgress1.style.display = "block";
                return true;
            }

            if (document.getElementById('customRadioInline3').checked) {
                if (document.getElementById("<%=txtEmpID.ClientID%>").value == "") {
                    alert("Please enter Employee Code");
                    document.getElementById("<%=ddlVesting.ClientID %>").focus();
                    return false;
                }

                if (document.getElementById('<%=txtDateOfGrant.ClientID%>').value == "") {
                    alert("Please select date of grant");
                    document.getElementById("<%=txtDateOfGrant.ClientID%>").focus();
                    return false;
                }

                if (document.getElementById("<%=ddlFMV.ClientID%>").value == 0) {
                    alert("Please select FMV price");
                    document.getElementById("<%=ddlFMV.ClientID%>").focus();
                    return false;
                }
                if (document.getElementById("<%=ddlVesting.ClientID %>").value == 0) {
                    alert("Please select Vesting Cycle");
                    document.getElementById("<%=ddlVesting.ClientID %>").focus();
                    return false;
                }
                if (document.getElementById("<%=txtNoOfOption.ClientID%>").value == "") {
                    alert("Please enter No. of Option");
                    document.getElementById("<%=ddlVesting.ClientID %>").focus();
                    return false;
                }
                if (document.getElementById("<%=txtLapsMonth.ClientID %>").value == "") {
                    alert("Please enter Lapse Month");
                    return false;
                }
                if (document.getElementById("<%=ddlTaxRegime.ClientID %>").value == 0) {
                    alert("Please select tax Regime");
                    return false;
                }

                var results = null;
                var x = document.getElementById("<%=txtNoOfOption.ClientID%>").value
                results = parseFloat(x);
                <%--if (document.getElementById("<%=txtNoOfOption.ClientID%>").value == "0")--%>
                if (results == "0") {
                    alert("Please enter more than Zero No of Option");
                    document.getElementById("<%=ddlVesting.ClientID %>").focus();
                    return false;
                }
                var updateProgress1 = $get("<%= UpdateProgress1.ClientID %>");
                updateProgress1.style.display = "block";
            }
        }
    </script>
    <script>
        function DownloadFile(filepath) {
            __doPostBack("<%= BtnDownload.UniqueID %>", filepath);
        }
    </script>

    <script type="text/javascript">
        function ReqValidation() {
            debugger;
            var FileUpload1 = document.getElementById('<%=FileUpload1.ClientID%>').value;
            var validationdate = document.getElementById('<%=txtvaldate.ClientID%>').value;
            var validupto = document.getElementById('<%=txtvalidupto.ClientID%>').value;
            var FMVPrice = document.getElementById('<%=txtfmvprice.ClientID%>').value;
            var ValueBy = document.getElementById('<%=ddlvaluedby.ClientID%>').value;

            if (validationdate.trim() == "") {
                alert("Select Valudation Date!");
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

            //Commented by Krutika on 16-06-22
            <%--if (ValueBy.trim() == "0") {
                alert("Select Valued By!!");
                document.getElementById('<%=ddlvaluedby.ClientID%>').focus();
                return false;
            }--%>

            if (FileUpload1.trim() != "") {
                var ext = FileUpload1.substr(FileUpload1.lastIndexOf('.') + 1).toLowerCase();
                if (ext == "xlsx" || ext == "xls") {
                    return true;
                }
                else {
                    alert("Only .xls, .xlsx files are allowed. ");
                    document.getElementById('<%=FileUpload1.ClientID%>').value = "";
                    document.getElementById('<%=FileUpload1.ClientID%>').focus();
                    return false;

                }
            }
        }
    </script>

    <script language="Javascript">
        function isNumberKey1(evt) {
            var charCode = (evt.which) ? evt.which : evt.keyCode;
            if (charCode > 31 && (charCode < 48 || charCode > 57))
                return false;

            return true;
        }
        function isNumberKey2(txt, evt) {
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



    <script type="text/javascript">

        $(document).ready(function () {

            $('.CloseBtnNew').click(function () {
                //alert('test_1');

                $("#myModal").removeClass("show");
                $("#myModal").hide();

                $("#modalVesting").removeClass("show");
                $("#modalVesting").hide();

                $("#ModalCreateFMV").removeClass("show");
                $("#ModalCreateFMV").hide();

                $("#myModal1").removeClass("show");
                $("#myModal1").hide();

                $(".modal-backdrop").remove();
                $("body").removeClass("modal-open");
            });
        })
    </script>

    <script type="text/javascript">

        $(function () {
            $.noConflict();
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

    <script>
        $(function () {
            var from = $("#ContentPlaceHolder1_txtDateOfGrant")
         .datepicker({
             //minDate: 0,
             dateFormat: "dd-mm-yy",
             changeMonth: true,
             changeYear: true,
             yearRange: "-50:+50",

         });
        });


        $(function () {
            Sys.WebForms.PageRequestManager.getInstance().add_endRequest(bindPicker);
            bindPicker();
        });
        // bindPicker();
        function bindPicker() {
            var from = $("#ContentPlaceHolder1_txtDateOfGrant")
        .datepicker({
            //minDate: 0,
            dateFormat: "dd-mm-yy",
            changeMonth: true,
            changeYear: true,
            yearRange: "-50:+50",
        });
        }
    </script>


    <script src="assets/js/jquery.dataTables-1.10.20.min.js"></script>
    <link href="Scripts/jquery.dataTables.min.css" rel="stylesheet" />
    <link href="Scripts/dataTables.bootstrap4.min.css" rel="stylesheet" />

    <script>
        //$('#ContentPlaceHolder1_grdData').clear().draw();
        $(function () {
            var prm = Sys.WebForms.PageRequestManager.getInstance();
            prm.add_endRequest(function (sender, e) {
                $('#ContentPlaceHolder1_grdData').DataTable({
                    lengthMenu: [[-1, 5, 10], ["All", 5, 10]],
                    columnDefs: [{ orderable: false, targets: [4] }],
                    bRetrieve: true,
                });

            });
        });
        $(function () {
            debugger;
            $("#ContentPlaceHolder1_grdData").DataTable({
                bLengthChange: true,
                lengthMenu: [[-1, 5, 10], ["All", 5, 10]],
                bFilter: true,
                'columnDefs': [{
                    'targets': [4],
                    'orderable': false,
                }],
                //bSort:true,
                bPaginate: true

            });
        });
    </script>

    <script>
        function padLeft() {
            debugger;
            $("#ContentPlaceHolder1_ddlVesting option.optionchild1").each(function () {
                $(this).html('&nbsp;&nbsp;&nbsp;&nbsp;' + $(this).text());
            });
        }
    </script>

    <div class="main-content">
        <nav aria-label="breadcrumb">
            <ol class="breadcrumb">
                <li class="breadcrumb-item"><a href="admin-dashboard.aspx">Home</a></li>
                <li class="breadcrumb-item"><a href="grants.aspx">Grant</a></li>
                <li class="breadcrumb-item active" aria-current="page"><b>Grant Creation</b></li>
            </ol>
        </nav>

        <section class="section">
            <div class="row">
                <div class="col-lg-12">
                    <asp:UpdatePanel ID="upd2" runat="server">
                        <ContentTemplate>
                            <div id="showmsg" runat="server"></div>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                    <div class="card" id="GrantCreation" runat="server">
                        <div class="card-header">
                            <h4>Grant Creation</h4>
                            <div>
                                <div class="form-group" style="margin-left: 25px; margin-bottom: 0px;">
                                    <div class="custom-control custom-radio custom-control-inline">
                                        <input type="radio" id="customRadioInline4" name="customRadioInline3" class="custom-control-input" value="bulk" onclick="Hide_Div()" <%= this.inputtypeBulk %>>
                                        <%--<asp:RadioButton ID="rbBulk" runat="server" Text="Bulk Data Upload" />--%>
                                        <label class="custom-control-label" for="customRadioInline4">Bulk Data Upload  </label>
                                    </div>
                                    <div class="custom-control custom-radio custom-control-inline">
                                        <input type="radio" id="customRadioInline3" name="customRadioInline3"
                                            class="custom-control-input" value="single" onclick="Hide_Div()" <%= this.inputtypeSingle %>>
                                        <%--<asp:RadioButton ID="rbSingle" runat="server" Text="Single Data Entry" />--%>
                                        <label class="custom-control-label" for="customRadioInline3">Single Data Entry</label>
                                    </div>
                                    <div class="custom-control custom-radio custom-control-inline">
                                        <asp:LinkButton ID="lnkGrdAppUpdate" Text="Grant Append/ Update" PostBackUrl="~/Grant_Creation_Append_Override_New" runat="server" />
                                    </div>
                                </div>
                            </div>
                        </div>
                        <div class="card-body">
                            <div class="row" style="margin-top: 15px;">
                                <div class="col-lg-4 col-md-12 col-sm-12 all" style="margin-top: 15px;">
                                    <div class="form-group">
                                        <label>Grant Name</label>
                                        <asp:TextBox ID="txtGrantName" runat="server" class="form-control"></asp:TextBox>
                                        <%--ReadOnly="true"--%>
                                    </div>
                                </div>
                                <div class="col-lg-4 col-md-12 col-sm-12 singledatadiv" style="margin-top: 15px;">
                                    <div class="form-group">
                                        <label>Employee Code <span style="color: red">*</span> </label>
                                        <asp:TextBox ID="txtEmpID" runat="server" class="form-control readonly ="></asp:TextBox>
                                    </div>
                                </div>
                                <div class="col-lg-4 col-md-12 col-sm-12 all" style="margin-top: 15px;">
                                    <div class="form-group">
                                        <label>Date of Grant <span style="color: red">*</span></label>
                                        <asp:UpdatePanel ID="up1" runat="server">
                                            <ContentTemplate>
                                                <asp:TextBox ID="txtDateOfGrant" Placeholder="dd-mm-yyyy" runat="server" class="form-control" OnTextChanged="txtDateOfGrant_TextChanged1" AutoPostBack="true"></asp:TextBox>
                                            </ContentTemplate>
                                        </asp:UpdatePanel>
                                    </div>
                                </div>

                                <div class="col-lg-2 col-md-12 col-sm-12 all" style="margin-top: 15px;">
                                    <div class="form-group">
                                        <label>Select Grant Price <span style="color: red">*</span></label>
                                        <label class="or">OR</label>
                                        <asp:UpdatePanel ID="UpdatePanel7" runat="server" class="width95">
                                            <ContentTemplate>
                                                <div class="input-group mb-3">

                                                    <asp:DropDownList ID="ddlFMV" runat="server" CssClass="form-control" AutoPostBack="false">
                                                    </asp:DropDownList>

                                                </div>
                                            </ContentTemplate>
                                        </asp:UpdatePanel>
                                    </div>
                                </div>
                                <div class="col-lg-2 col-md-12 col-sm-12 all" style="margin-top: 15px;">
                                    <div class="form-group">
                                        <label></label>
                                        <a href="#" class="btn btn-icon btn-primary martop width90" data-toggle="modal" data-target="#ModalCreateFMV">Create FMV</a>

                                    </div>
                                </div>
                                <div class="col-lg-2 col-md-12 col-sm-12 all" style="width: 93%; margin-top: 15px; margin-left: -2px !important">
                                    <%-- <asp:UpdatePanel ID="UpdatePanel8" runat="server">
                                        <ContentTemplate>--%>
                                    <div class="form-group" style="width: 93%; margin-left: -2px !important">
                                        <label style="width: 91%; !important">Vesting Cycle <span style="color: red">*</span></label>
                                        <label class="or">OR</label>

                                        <asp:DropDownList ID="ddlVesting" runat="server" CssClass="form-control" AutoPostBack="false" Style="width: 103% !important"></asp:DropDownList>
                                        <%--OnTextChanged="ddlVesting_TextChanged"--%>
                                    </div>
                                    <%--  </ContentTemplate>
                                    </asp:UpdatePanel>--%>
                                </div>
                                <div class="col-lg-2 col-md-12 col-sm-12 all" style="margin-top: 15px;">
                                    <div class="form-group">
                                        <label></label>
                                        <a href="#" class="btn btn-icon btn-primary martop width90" data-toggle="modal" data-target=".bd-example-modal-lg1">Create Vesting Cycle</a>
                                    </div>
                                </div>
                                <div class="col-lg-4 col-md-12 col-sm-12 multidatadiv" style="margin-top: 15px;">
                                    <div class="form-group">
                                        <label>Upload File <span style="color: red">*</span> </label>
                                        <%--<input type="file" class="form-control">--%>
                                        <asp:FileUpload ID="uploadfile" runat="server" CssClass="dropify" accept=".xlx, .xlsx" class="form-control" />
                                        <%--onchange="return dispFileName();"--%>
                                        <%--Added by Krutika on 16-06-22--%>
                                        <asp:Label ID="lblFileType" runat="server" Text="(Only .xls, .xlsx files are allowed.)" ForeColor="Green" Font-Bold="true" Font-Size="14px"></asp:Label>
                                    </div>
                                </div>

                                <div class="col-lg-2 col-md-12 col-sm-12 singledatadiv" style="margin-top: 15px;">
                                    <div class="form-group">
                                        <label>No.of Options <span style="color: red">*</span> </label>
                                        <%--<input type="text" class="form-control">--%>
                                        <asp:TextBox ID="txtNoOfOption" runat="server" class="form-control" onkeypress="return isNumberKey1(event)" Width="140"></asp:TextBox>
                                    </div>
                                </div>

                                <div class="col-lg-2 col-md-12 col-sm-12 multidatadiv" style="margin-top: 15px;">
                                    <div class="form-group">
                                        <div class="section-title">Upload Format</div>
                                        <div class="" style="line-height: 0.75;">
                                            <label style="margin-right: 10px;">Excel  </label>
                                            <br />
                                            <a href="/ExcelFormat/Grant_ExcelFormat_New.xlsx" class="linkbtn" style="font-size: 15px; font-weight: 500; letter-spacing: 0px; margin: 10px 0 0 0; color: #5e65ff; clear: both; text-decoration: underline">Download Template</a>
                                            <%--<asp:LinkButton ID="myLink" Text="Download Template" OnClick="LinkButton_Click" runat="server" />--%>
                                        </div>
                                    </div>
                                </div>

                                <div class="col-lg-2 col-md-12 col-sm-12 all" style="margin-top: 15px;">
                                    <div class="form-group">
                                        <label>Enter Lapse Month <span style="color: red">*</span> </label>
                                        <asp:TextBox ID="txtLapsMonth" runat="server" class="form-control" Width="140"></asp:TextBox>
                                    </div>
                                </div>

                                <div class="col-lg-2 col-md-12 col-sm-12 all">
                                    <div class="form-group">
                                        <label>Select Tax Regime <span style="color: red">*</span> </label>
                                        <asp:DropDownList ID="ddlTaxRegime" runat="server" CssClass="form-control">
                                            <asp:ListItem Text="Select" Value="0"></asp:ListItem>
                                            <asp:ListItem Text="Old" Value="O"></asp:ListItem>
                                            <asp:ListItem Text="New" Value="N"></asp:ListItem>
                                        </asp:DropDownList>
                                    </div>
                                </div>

                                <div class="col-lg-6 offset-lg-3 mt-5">
                                    <asp:UpdatePanel ID="UP_submit" runat="server">
                                        <ContentTemplate>
                                            <asp:Button ID="btnSaveGrant" runat="server" Text="Create Grant" OnClick="btnSaveGrant_Click" OnClientClick="return validate(); showProgress1(); return false;return postbackButtonClick();" CssClass="btn btn-info btn-lg all" />
                                            <br />
                                            <label style="margin-right: 15px;">Password Protected</label>
                                            <asp:CheckBox runat="server" ID="chk" EnableViewState="false" Checked="true" />
                                        </ContentTemplate>
                                        <Triggers>
                                            <asp:PostBackTrigger ControlID="btnSaveGrant" />
                                        </Triggers>
                                    </asp:UpdatePanel>
                                </div>
                                <div class="col-lg-3 offset-md-5 mt-5">
                                    <asp:Button ID="btnPendingGrant" runat="server" Text="Pending Grant" OnClick="btnPendingGrant_Click" CssClass="btn btn-info btn-lg all" />
                                </div>

                            </div>
                            <div style="color: red; float: right">
                                All (*) marked fields are mandatory.
                            </div>
                        </div>
                        <%--<asp:UpdatePanel ID="upd2" runat="server">
                            <ContentTemplate>
                                <div id="showmsg" runat="server"></div>
                            </ContentTemplate>
                        </asp:UpdatePanel>--%>
                    </div>

                    <%--</ContentTemplate>--%>
                    <%--</asp:UpdatePanel>--%>
                </div>

                <div class="col-lg-12 col-md-12 col-12 col-sm-12" id="tablediv" runat="server">
                    <div class="card" style="height: auto;">
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
                                                <div class="badge badge-info"><%= TotalRecords %></div>
                                            </td>
                                            <td>No.of records uploaded successfully</td>
                                            <td>
                                                <div class="badge badge-success"><%= SuccRecords %></div>
                                            </td>
                                            <td>No.of records failed</td>
                                            <td>
                                                <div class="badge badge-danger"><%= FailRecords %></div>
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

                <div class="col-lg-12 col-md-12 col-12 col-sm-12" id="tablediv_1" runat="server">
                    <div class="card" style="height: auto;">
                        <div class="card-header">
                            <h4>Grants</h4>
                        </div>
                        <div class="card-body">
                            <div class="table-responsive">
                                <table class="table table-bordered">
                                    <asp:UpdatePanel ID="UpdatePanel8" runat="server">
                                        <ContentTemplate>
                                            <asp:GridView ID="grdData" class="table dataTable" runat="server" Style="width: 98%;"
                                                AutoGenerateColumns="False" AllowPaging="false" PageSize="10" AllowSorting="false"
                                                EmptyDataText="No data found" OnPreRender="grdData_PreRender" AllowCustomPaging="false" ViewStateMode="Enabled" OnRowCommand="grdData_RowCommand">
                                                <Columns>
                                                    <asp:TemplateField HeaderText="Employee Name">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lbl_DEM_EMP_ID" runat="server" Text='<%#Eval("Employee_Name") %>'></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>

                                                    <asp:TemplateField HeaderText="Grant Name">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lbl_DEM_GRANT_NAME" runat="server" Text='<%#Eval("DEM_GRANT_NAME") %>'></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>

                                                    <asp:TemplateField HeaderText="Date of Grant">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lbl_DEM_GRANT_DATE" runat="server" Text='<%#Eval("DEM_GRANT_DATE") %>'></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>

                                                    <asp:TemplateField HeaderText="No Of Option">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lbl_DEM_NO_OF_OPTION" runat="server" Text='<%#Eval("DEM_NO_OF_OPTION") %>'></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Grant Letter Download">
                                                        <ItemTemplate>
                                                            <asp:HiddenField ID="HiddenField1" runat="server" Value='<%# Bind("FILEName") %>' />
                                                            <asp:LinkButton ID="btn_Preview" runat="server" CausesValidation="false" CommandName="Preview" OnClick="btn_Preview_Click"
                                                                CssClass="btn btn-icon btn-success fas fa-eye"></asp:LinkButton>
                                                            <asp:LinkButton ID="lb_download" runat="server" CommandArgument='<%# Eval("FILEName") %>' CausesValidation="false"
                                                                class="btn btn-icon btn-primary fas fa-arrow-down" OnClick="lb_download_Click"></asp:LinkButton>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                </Columns>

                                            </asp:GridView>

                                        </ContentTemplate>
                                        <%--<Triggers>
                                <asp:AsyncPostBackTrigger ControlID="lb_download" />
                            </Triggers>--%>
                                    </asp:UpdatePanel>
                                </table>
                            </div>
                        </div>
                        <div class="card-body">
                            <div class="modal-footer bg-whitesmoke br" style="margin: 0 auto; width: 100%; justify-content: center;">
                                <div class="btn-group center" role="group" aria-label="Basic example" style="border: none;">
                                    <asp:Button ID="BtnCancle" runat="server" Text="Cancel Grant" OnClick="Cancle_Click" CssClass="btn btn-info btn-lg all" />
                                    <asp:Button ID="BtnSubmitGrant" runat="server" Text="Create Grant" OnClick="BtnSubmitGrant_Click" CssClass="btn btn-info btn-lg all" />
                                    <asp:Button ID="BtnRetunt" runat="server" Text="Retrun to Grant Creation" OnClick="BtnRetunt_Click" CssClass="btn btn-info btn-lg all" />
                                    <%--<a href="#" class="btn btn-info btn-lg all CloseBtnNew" data-dismiss="modal">Save Grant</a>--%>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
        </section>
        <asp:UpdateProgress ID="UpdateProgress1" runat="server" AssociatedUpdatePanelID="UP_submit">
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
        <%--<asp:UpdateProgress ID="UpdateProgress1" runat="server" AssociatedUpdatePanelID="UpdatePanel2">
            <ProgressTemplate>
                <div id="overlay">
                    <div id="modalprogress">
                        <div id="theprogress">

                            <img src="img/loading.gif" />
                        </div>
                    </div>
                </div>
            </ProgressTemplate>
        </asp:UpdateProgress>--%>
    </div>

    <!--Create FMV popup-->

    <div class="modal fade bd-example-modal-lg" tabindex="-1" role="dialog" id="ModalCreateFMV" aria-labelledby="myLargeModalLabel" aria-hidden="false">
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
                                <%--<input type="text" class="form-control datepicker">--%>
                                <%--                                <asp:TextBox ID="txtvaldate" runat="server" class="form-control datepicker"></asp:TextBox>--%>
                                <%--                                <asp:TextBox ID="txtvaldate" runat="server" type="date" class="form-control"></asp:TextBox>--%>
                                <asp:TextBox ID="txtvaldate" type="text" placeholder="dd-mm-yyyy" runat="server" class="form-control" AutoComplete="off"></asp:TextBox>
                            </div>
                        </div>

                        <div class="col-lg-6 col-md-12 col-sm-12">
                            <div class="form-group">
                                <label>Valid Upto <span style="color: red">*</span></label>
                                <%--                                <asp:TextBox ID="txtvalidupto" runat="server" class="form-control datepicker"></asp:TextBox>--%>

                                <%--<input type="text" class="form-control datepicker">--%>
                                <%--                                <asp:TextBox ID="txtvalidupto" runat="server" type="date" class="form-control"></asp:TextBox>--%>
                                <asp:TextBox ID="txtvalidupto" type="text" placeholder="dd-mm-yyyy" runat="server" class="form-control" AutoComplete="off"></asp:TextBox>
                            </div>
                        </div>
                        <div class="col-lg-6 col-md-12 col-sm-12">
                            <div class="form-group">
                                <label>FMV <span style="color: red">*</span></label>
                                <%--  <input type="text" class="form-control">--%>
                                <asp:TextBox ID="txtfmvprice" runat="server" CssClass="form-control" MaxLength="10" onkeypress="return isNumberKey2(this,event)" pattern="^\d*(\.\d{0,2})?$"></asp:TextBox>

                            </div>
                        </div>

                        <div class="col-lg-6 col-md-12 col-sm-12">
                            <div class="form-group">
                                <label>Valued By</label>
                                <%--<span style="color: red">*</span>   Commented by Krutika on 22-06-22--%>
                                <div class="input-group mb-3">
                                    <asp:DropDownList ID="ddlvaluedby" runat="server" CssClass="form-control" Style="width: 100% !important;">
                                    </asp:DropDownList>
                                    <%--<select class="form-control">
                                        <option>Select..</option>
                                        <option>Demo 1</option>
                                        <option>Demo 2</option>
                                        <option>Demo 3</option>
                                    </select>--%>
                                </div>
                            </div>
                        </div>

                        <div class="col-lg-6 col-md-12 col-sm-12">
                            <div class="form-group">
                                <label>Upload File</label>
                                <%--  <input type="file" class="form-control">--%>
                                <asp:FileUpload ID="FileUpload1" runat="server" class="form-control" />
                                <asp:Label ID="lblFileType2" runat="server" Text="(Only .xls, .xlsx files are allowed.)" ForeColor="Green" Font-Bold="true" Font-Size="14px"></asp:Label>
                            </div>
                        </div>
                        <!--<div class="col-lg-6 col-md-12 col-sm-12">
                     <div class="form-group">
                        <label>Upload Formats</label>
                        <div class="custom-control custom-radio custom-control-inline">
                           <input type="radio" id="customRadioInline1" name="customRadioInline1" class="custom-control-input">
                           <label class="custom-control-label" for="customRadioInline1">CSV</label>
                        </div>
                        <div class="custom-control custom-radio custom-control-inline">
                           <input type="radio" id="customRadioInline2" name="customRadioInline1" class="custom-control-input">
                           <label class="custom-control-label" for="customRadioInline2">Excel  </label>
                        </div>
                        <a href="#" class="linkbtn" style="font-size: 14px;font-weight: 500;letter-spacing: 0.2px;margin: 10px 0 0 0;color: #5e65ff;clear: both;text-decoration:underline">Download Template</a>
                     </div>
                  </div>-->
                    </div>
                </div>
                <div class="modal-footer bg-whitesmoke br">
                    <div class="btn-group" role="group" aria-label="Basic example" style="margin: auto">
                        <%--  <div class="col-lg-3 offset-md-3">--%>
                        <%--<button type="button" class="btn btn-primary filterEntry" data-dismiss="modal">Submit</button>--%>
                        <asp:Button ID="btncreatefmv" runat="server" Text="Create FMV" OnClick="btncreatefmv_Click" OnClientClick="return ReqValidation();"
                            class="btn btn-info btn-lg all" />
                        <a href="#" class="btn btn-info btn-lg all CloseBtnNew" data-dismiss="modal">Close</a>
                    </div>
                </div>
                <br />
            </div>


        </div>
    </div>

    <!--Create grant popup end-->

    <!--Create vesting popup-->

    <div class="modal fade bd-example-modal-lg1" tabindex="-1" role="dialog" aria-labelledby="myLargeModalLabel" aria-hidden="true" style="display: none;" id="modalVesting">
        <div class="modal-dialog modal-lg">
            <div class="modal-content">
                <div class="modal-header">
                    <h5 class="modal-title" id="">Create Vesting Cycle</h5>
                    <%--<button type="button" class="close" data-dismiss="modal" aria-label="Close">
                        <span aria-hidden="true">×</span>
                    </button>--%>
                </div>
                <div class="modal-body">
                    <div class="row">
                        <div class="col-lg-12 col-md-12 col-12 col-sm-12">
                            <div class="card" style="height: 100%;">
                                <div class="card-body">
                                    <div class="row" style="margin-top: 15px;">
                                        <div class="offset-md-1 col-lg-5 col-md-12 col-sm-12">
                                            <div class="form-group">
                                                <label>Vesting Name <span style="color: red">*</span></label>
                                                <%--<input type="text" class="form-control">--%>
                                                <asp:TextBox ID="txtVestingName" runat="server" CssClass="form-control" MaxLength="50"></asp:TextBox>
                                                <asp:RequiredFieldValidator ID="rfvVestingName" runat="server"
                                                    ErrorMessage="Vesting name is required" ControlToValidate="txtVestingName" ValidationGroup="Add" ForeColor="Red"
                                                    Display="None" CssClass="validation" SetFocusOnError="true"></asp:RequiredFieldValidator>

                                            </div>
                                        </div>
                                        <div class="col-lg-5 col-md-12 col-sm-12">
                                            <div class="form-group">
                                                <label>No. Of Vesting <span style="color: red">*</span></label>
                                                <div class="input-group mb-3">
                                                    <%--<select class="form-control" id="ddlnoOfCycle" >
                                                <option>Select</option>
                                                <option>1</option>
                                                <option>2</option>
                                                <option>3</option>
                                                <option>4</option>
                                                <option>5</option>
                                            </select>--%>
                                                    <asp:DropDownList ID="ddlnoOfCycle1" runat="server" CssClass="form-control" onchange="dropchange()">
                                                        <asp:ListItem Value="0">Select</asp:ListItem>
                                                        <asp:ListItem Value="1">1</asp:ListItem>
                                                        <asp:ListItem Value="2">2</asp:ListItem>
                                                        <asp:ListItem Value="3">3</asp:ListItem>
                                                        <asp:ListItem Value="4">4</asp:ListItem>
                                                        <asp:ListItem Value="5">5</asp:ListItem>
                                                    </asp:DropDownList>
                                                    <asp:RequiredFieldValidator ID="ddddlnoOfCycle1" runat="server"
                                                        ErrorMessage="Please select No. of vesting cycle" ControlToValidate="ddlnoOfCycle1" ValidationGroup="Add" ForeColor="Red" InitialValue="0"
                                                        Display="None" CssClass="validation" SetFocusOnError="true"></asp:RequiredFieldValidator>
                                                </div>
                                            </div>
                                        </div>
                                        <div class="table-responsive">
                                            <table class="table" style="width: 100%;">
                                                <tbody id="noOfVestingTable">
                                                    <tr id="trV1" style="display: none">
                                                        <td>
                                                            <div class="form-group" style="margin-bottom: -2px;">
                                                                <%--<input type="text" class="form-control" value="v' + (i + 1) + '" disabled="">--%>
                                                                <asp:TextBox ID="txtv1" runat="server" CssClass="form-control" Text="v1" Enabled="false"></asp:TextBox>
                                                            </div>
                                                        </td>
                                                        <td>
                                                            <div class="form-group" style="margin-bottom: -2px;">
                                                                <%--<input type="text" class="form-control" placeholder="Vesting Cycle %">--%>
                                                                <asp:TextBox ID="txtperc1" runat="server" CssClass="form-control" placeholder="Vesting %"
                                                                    onkeypress="return isNumberKey(event,this.id)" MaxLength="3"></asp:TextBox>
                                                                <asp:RequiredFieldValidator ID="rfvperc1" runat="server"
                                                                    ErrorMessage="Vesting Cycle % is required" ControlToValidate="txtperc1" ValidationGroup="Add" ForeColor="Red"
                                                                    Display="None" CssClass="validation" SetFocusOnError="true"></asp:RequiredFieldValidator>
                                                            </div>
                                                        </td>
                                                        <td>
                                                            <div class="form-group">
                                                                <div class="input-group mb-3">
                                                                    <asp:UpdatePanel ID="Updatepanel5" runat="server">
                                                                        <ContentTemplate>
                                                                            <asp:DropDownList ID="ddlduration1" runat="server" Style="margin-bottom: -2px; margin-top: 16px; width: 200px;"
                                                                                CssClass="form-control ddlwidth" OnSelectedIndexChanged="ddlduration1_SelectedIndexChanged" AutoPostBack="true">
                                                                            </asp:DropDownList>
                                                                            <asp:RequiredFieldValidator ID="rfvduration1" runat="server"
                                                                                ErrorMessage="Please select duration" ControlToValidate="ddlduration1" ValidationGroup="Add" ForeColor="Red" InitialValue="0"
                                                                                Display="None" CssClass="validation" SetFocusOnError="true"></asp:RequiredFieldValidator>
                                                                        </ContentTemplate>
                                                                        <%--<Triggers>
                                                                    <asp:AsyncPostBackTrigger ControlID="ddlduration1" />
                                                                </Triggers>--%>
                                                                    </asp:UpdatePanel>
                                                                </div>
                                                            </div>
                                                        </td>
                                                    </tr>
                                                    <tr id="trV2" style="display: none">
                                                        <td>
                                                            <div class="form-group" style="margin-bottom: -2px;">
                                                                <%--<input type="text" class="form-control" value="v' + (i + 1) + '" disabled="">--%>
                                                                <asp:TextBox ID="txtv2" runat="server" CssClass="form-control" Text="v2" Enabled="false"></asp:TextBox>
                                                            </div>
                                                        </td>
                                                        <td>
                                                            <div class="form-group" style="margin-bottom: -2px;">
                                                                <%--<input type="text" class="form-control" placeholder="Vesting Cycle %">--%>
                                                                <asp:TextBox ID="txtperc2" runat="server" CssClass="form-control" placeholder="Vesting %"
                                                                    onkeypress="return isNumberKey(event,this.id)" MaxLength="3"></asp:TextBox>
                                                                <asp:RequiredFieldValidator ID="rfvtxtperc2" runat="server"
                                                                    ErrorMessage="Vesting Cycle % is required" ControlToValidate="txtperc2" ValidationGroup="Add" ForeColor="Red"
                                                                    Display="None" CssClass="validation" SetFocusOnError="true"></asp:RequiredFieldValidator>
                                                            </div>
                                                        </td>
                                                        <td>
                                                            <div class="form-group">
                                                                <div class="input-group mb-3">

                                                                    <asp:UpdatePanel ID="Updatepanel1" runat="server">
                                                                        <ContentTemplate>
                                                                            <asp:DropDownList ID="ddlduration2" runat="server" Style="margin-bottom: -2px; margin-top: 16px; width: 200px;" CssClass="form-control ddlwidth"
                                                                                OnSelectedIndexChanged="ddlduration2_SelectedIndexChanged" AutoPostBack="true">
                                                                            </asp:DropDownList>
                                                                            <asp:RequiredFieldValidator ID="rfvduration2" runat="server"
                                                                                ErrorMessage="Please select duration" ControlToValidate="ddlduration2" ValidationGroup="Add" ForeColor="Red" InitialValue="0"
                                                                                Display="None" CssClass="validation" SetFocusOnError="true"></asp:RequiredFieldValidator>
                                                                        </ContentTemplate>
                                                                        <Triggers>
                                                                            <asp:AsyncPostBackTrigger ControlID="ddlduration1" />
                                                                        </Triggers>
                                                                    </asp:UpdatePanel>
                                                                </div>
                                                            </div>
                                                        </td>
                                                    </tr>
                                                    <tr id="trV3" style="display: none">
                                                        <td>
                                                            <div class="form-group" style="margin-bottom: -2px;">
                                                                <%--<input type="text" class="form-control" value="v' + (i + 1) + '" disabled="">--%>
                                                                <asp:TextBox ID="txtv3" runat="server" CssClass="form-control" Text="v3" Enabled="false"></asp:TextBox>
                                                            </div>
                                                        </td>
                                                        <td>
                                                            <div class="form-group" style="margin-bottom: -2px;">
                                                                <%--<input type="text" class="form-control" placeholder="Vesting Cycle %">--%>
                                                                <asp:TextBox ID="txtperc3" runat="server" CssClass="form-control" placeholder="Vesting %"
                                                                    onkeypress="return isNumberKey(event,this.id)" MaxLength="3"></asp:TextBox>
                                                                <asp:RequiredFieldValidator ID="rfvtxtperc3" runat="server"
                                                                    ErrorMessage="Vesting Cycle % is required" ControlToValidate="txtperc3" ValidationGroup="Add" ForeColor="Red"
                                                                    Display="None" CssClass="validation" SetFocusOnError="true"></asp:RequiredFieldValidator>
                                                            </div>
                                                        </td>
                                                        <td>
                                                            <div class="form-group">
                                                                <div class="input-group mb-3">

                                                                    <asp:UpdatePanel ID="Updatepanel2" runat="server">
                                                                        <ContentTemplate>
                                                                            <asp:DropDownList ID="ddlduration3" runat="server" Style="margin-bottom: -2px; margin-top: 16px; width: 200px;" CssClass="form-control"
                                                                                OnSelectedIndexChanged="ddlduration3_SelectedIndexChanged" AutoPostBack="true">
                                                                            </asp:DropDownList>
                                                                            <asp:RequiredFieldValidator ID="rfvduration3" runat="server"
                                                                                ErrorMessage="Please select duration" ControlToValidate="ddlduration3" ValidationGroup="Add" ForeColor="Red" InitialValue="0"
                                                                                Display="None" CssClass="validation" SetFocusOnError="true"></asp:RequiredFieldValidator>
                                                                        </ContentTemplate>
                                                                        <Triggers>
                                                                            <asp:AsyncPostBackTrigger ControlID="ddlduration2" />
                                                                        </Triggers>
                                                                    </asp:UpdatePanel>
                                                                </div>
                                                            </div>
                                                        </td>
                                                    </tr>
                                                    <tr id="trV4" style="display: none">
                                                        <td>
                                                            <div class="form-group" style="margin-bottom: -2px;">
                                                                <%--<input type="text" class="form-control" value="v' + (i + 1) + '" disabled="">--%>
                                                                <asp:TextBox ID="txtv4" runat="server" CssClass="form-control" Text="v4" Enabled="false"></asp:TextBox>
                                                            </div>
                                                        </td>
                                                        <td>
                                                            <div class="form-group" style="margin-bottom: -2px;">
                                                                <%--<input type="text" class="form-control" placeholder="Vesting Cycle %">--%>
                                                                <asp:TextBox ID="txtperc4" runat="server" CssClass="form-control" placeholder="Vesting %"
                                                                    onkeypress="return isNumberKey(event,this.id)" MaxLength="3"></asp:TextBox>
                                                            </div>
                                                            <asp:RequiredFieldValidator ID="rfvtxtperc4" runat="server"
                                                                ErrorMessage="Vesting Cycle % is required" ControlToValidate="txtperc4" ValidationGroup="Add" ForeColor="Red"
                                                                Display="None" CssClass="validation" SetFocusOnError="true"></asp:RequiredFieldValidator>
                                                        </td>
                                                        <td>
                                                            <div class="form-group">
                                                                <div class="input-group mb-3">

                                                                    <asp:UpdatePanel ID="Updatepanel3" runat="server">
                                                                        <ContentTemplate>
                                                                            <asp:DropDownList ID="ddlduration4" runat="server" Style="margin-bottom: -2px; margin-top: 16px; width: 200px;" CssClass="form-control"
                                                                                OnSelectedIndexChanged="ddlduration4_SelectedIndexChanged" AutoPostBack="true">
                                                                            </asp:DropDownList>
                                                                            <asp:RequiredFieldValidator ID="rfvddlduration4" runat="server"
                                                                                ErrorMessage="Please select duration" ControlToValidate="ddlduration4" ValidationGroup="Add" ForeColor="Red" InitialValue="0"
                                                                                Display="None" CssClass="validation" SetFocusOnError="true"></asp:RequiredFieldValidator>
                                                                        </ContentTemplate>
                                                                        <Triggers>
                                                                            <asp:AsyncPostBackTrigger ControlID="ddlduration3" />
                                                                        </Triggers>
                                                                    </asp:UpdatePanel>
                                                                </div>
                                                            </div>
                                                        </td>
                                                    </tr>
                                                    <tr id="trV5" style="display: none">
                                                        <td>
                                                            <div class="form-group" style="margin-bottom: -2px;">
                                                                <%--<input type="text" class="form-control" value="v' + (i + 1) + '" disabled="">--%>
                                                                <asp:TextBox ID="txtv5" runat="server" CssClass="form-control" Text="v5" Enabled="false"></asp:TextBox>
                                                            </div>
                                                        </td>
                                                        <td>
                                                            <div class="form-group" style="margin-bottom: -2px;">
                                                                <%--<input type="text" class="form-control" placeholder="Vesting Cycle %">--%>
                                                                <asp:TextBox ID="txtperc5" runat="server" CssClass="form-control" placeholder="Vesting %"
                                                                    onkeypress="return isNumberKey(event,this.id)" MaxLength="3"></asp:TextBox>
                                                                <asp:RequiredFieldValidator ID="rfvtxtperc5" runat="server"
                                                                    ErrorMessage="Vesting Cycle % is required" ControlToValidate="txtperc5" ValidationGroup="Add" ForeColor="Red"
                                                                    Display="None" CssClass="validation" SetFocusOnError="true"></asp:RequiredFieldValidator>
                                                            </div>
                                                        </td>
                                                        <td>
                                                            <div class="form-group">
                                                                <div class="input-group mb-3">

                                                                    <asp:UpdatePanel ID="Updatepanel4" runat="server">
                                                                        <ContentTemplate>
                                                                            <asp:DropDownList ID="ddlduration5" runat="server" Style="margin-bottom: -2px; margin-top: 16px; width: 200px;" CssClass="form-control">
                                                                            </asp:DropDownList>
                                                                            <asp:RequiredFieldValidator ID="rfvddlduration5" runat="server"
                                                                                ErrorMessage="Please select duration" ControlToValidate="ddlduration5" ValidationGroup="Add" ForeColor="Red" InitialValue="0"
                                                                                Display="None" CssClass="validation" SetFocusOnError="true"></asp:RequiredFieldValidator>
                                                                        </ContentTemplate>
                                                                        <Triggers>
                                                                            <asp:AsyncPostBackTrigger ControlID="ddlduration4" />
                                                                        </Triggers>
                                                                    </asp:UpdatePanel>
                                                                </div>
                                                            </div>
                                                        </td>
                                                    </tr>

                                                </tbody>
                                            </table>
                                        </div>
                                    </div>

                                </div>
                            </div>
                        </div>
                    </div>
                    <%--<div class="modal-footer bg-whitesmoke br">
                    <div class="col-lg-3 offset-md-3">
                        <asp:Button ID="btnsubmit" runat="server" Text="Submit" OnClick="btnsubmit_Click"
                            class="btn btn-info btn-lg all" />

                    </div>--%>
                    <%--                    <button type="button" class="btn btn-primary filterEntry" data-dismiss="modal">Submit</button>--%>
                    <%--</div>--%>
                </div>
                <div class="modal-footer bg-whitesmoke br">
                    <div class="btn-group" role="group" aria-label="Basic example" style="margin: auto">
                        <%--  <div class="col-lg-3 offset-md-3 mt-5">--%>
                        <%--<asp:UpdatePanel runat="server" ID="upd1">--%>
                        <%--<ContentTemplate>--%>
                        <%--<a href="#" class="btn btn-info btn-lg all" id="btnimport">Create Vesting Cycle</a>--%>
                        <asp:ValidationSummary runat="server" ShowMessageBox="true" ShowSummary="false" ValidationGroup="Add" />
                        <asp:Button ID="btnimport" CssClass="btn btn-info btn-lg all" runat="server" OnClientClick="return GetSelectedItem('ddlnoOfCycle1');"
                            Text="Create Vesting Cycle" ValidationGroup="Add" OnClick="btnimport_Click" />
                        <a href="#" class="btn btn-info btn-lg all CloseBtnNew" data-dismiss="modal">Close</a>
                        <%--</ContentTemplate>--%>
                        <%--</asp:UpdatePanel>--%>
                    </div>

                </div>
                <br />
            </div>
        </div>
    </div>



    <div class="modal fade bd-example-modal-lg1" id="myModal1" tabindex="-1" role="dialog" aria-labelledby="myLargeModalLabel" style="display: none;" aria-hidden="true">
        <div class="modal-dialog modal-lg" style="max-width: 900px;">
            <asp:UpdatePanel runat="server">
                <ContentTemplate>
                    <div class="modal-content">
                        <div class="modal-header">
                            <h5 class="modal-title" id="myLargeModalLabel">Preview </h5>
                            <%--   <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                                <span aria-hidden="true">×</span>
                            </button>--%>
                        </div>
                        <div class="modal-body" style="padding-left: 15px; padding-right: 15px;">
                            <div class="row popRow" style="">
                                <embed runat="server" id="embed1" width="100%" height="500" alt="pdf" pluginspage="http://www.adobe.com/products/acrobat/readstep2.html" />
                            </div>
                        </div>
                        <div class="modal-footer bg-whitesmoke br">
                            <div class="btn-group" role="group" aria-label="Basic example">
                                <%--<button type="button" class="btn btn-primary" data-dismiss="modal" style="margin-right: 44%; width: 40px;" id="Submit">OK</button>--%>
                                <a href="#" class="btn btn-info btn-lg all CloseBtnNew" data-dismiss="modal">Close</a>

                            </div>
                        </div>
                    </div>
                </ContentTemplate>
            </asp:UpdatePanel>
        </div>
    </div>


    <div class="modal bd-example-modal-lg" id="myModal2" tabindex="-1" role="dialog">
        <%--<div class="modal fade bd-example-modal-lg1" id="myModal1" tabindex="-1" role="dialog" aria-labelledby="myLargeModalLabel" style="display: none;" aria-hidden="true">--%>
        <div class="modal-dialog modal-lg" style="max-width: 900px;">

            <div class="modal-content">
                <asp:UpdatePanel runat="server">
                    <ContentTemplate>
                        <div class="modal-header">
                            <h5 class="modal-title" id="myLargeModalLabel1">Preview </h5>
                        </div>
                        <div class="modal-body" style="padding-left: 15px; padding-right: 15px;">
                            <div class="row popRow aligncenter">
                                <img id="FreshChequeImage1" runat="server" />
                            </div>
                        </div>
                    </ContentTemplate>
                </asp:UpdatePanel>
                <div class="modal-footer bg-whitesmoke br">
                    <div class="btn-group" role="group" aria-label="Basic example">
                        <button id="btn1" class="btn btn-info btn-lg all CloseBtnNew">Close</button>
                    </div>
                </div>
            </div>
        </div>
    </div>

    <!-- General JS Scripts -->


    <%--  <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.5.1/jquery.min.js"></script>
  <script src="https://maxcdn.bootstrapcdn.com/bootstrap/3.4.1/js/bootstrap.min.js"></script>--%>
    <script src="assets/js/app.min.js"></script>
    <script src="assets/js/scripts.js"></script>
    <%--    <script src="Scripts/bootstrap.min.js"></script>--%>



    <%--  <link href="assets/css/jquery-ui-1.12.1.css" rel="stylesheet" />  
    <script src="assets/js/jquery-ui-1.12.1.js" type="text/javascript"></script>--%>




    <%-- <script>
        $(document).ready(function () {

            $('.singledatadiv').hide();
            $("input[name='customRadioInline3']").change(function () {

                var radioValue = $("input[name='customRadioInline3']:checked").val();

                if (radioValue == "single") {

                    $('.all').show()
                    $('.singledatadiv').slideDown();
                    $('.multidatadiv').hide();

                    (document.getElementById("<%=ddlFMV.ClientID%>").value = 0)
                    (document.getElementById("<%=ddlVesting.ClientID %>").value = 0)

                    (document.getElementById("<%=txtEmpID.ClientID%>").value = "")
                }
                else {


                    $('.all').show()
                    $('.multidatadiv').slideDown();
                    $('.singledatadiv').hide();
                    (document.getElementById("<%=ddlFMV.ClientID%>").value = 0)
                    (document.getElementById("<%=ddlVesting.ClientID %>").value = 0)

                    (document.getElementById("<%=txtEmpID.ClientID%>").value = "")
                }

            });

            //$('#tablediv').hide();
            //$('#btnSaveGrant').click(function () {
            //    $('#tablediv').slideToggle();
            //    $('html, body').animate({
            //        scrollTop: $("#tablediv").offset().top
            //    }, 2000);

            //});
            //$('#tablediv').hide();

            //$('.CloseBtnNew').click(function () {
            //    alert('test');
            //    $('#myModal').modal('hide');
            //});
        });
    </script>--%>
    <script>
        $(document).ready(function Load() {
            $('.singledatadiv').hide();
            $("input[name='customRadioInline3']").change(function () {
                var radioValue = $("input[name='customRadioInline3']:checked").val();
                if (radioValue == "single") {

                    $('.all').show()
                    $('.singledatadiv').slideDown();
                    $('.multidatadiv').hide();

                    (document.getElementById("<%=ddlFMV.ClientID%>").value = 0)
                    (document.getElementById("<%=ddlVesting.ClientID %>").value = 0)

                    (document.getElementById("<%=txtEmpID.ClientID%>").value = "")
                }
                else {


                    $('.all').show()
                    $('.multidatadiv').slideDown();
                    $('.singledatadiv').hide();
                    (document.getElementById("<%=ddlFMV.ClientID%>").value = 0)
                    (document.getElementById("<%=ddlVesting.ClientID %>").value = 0)

                    (document.getElementById("<%=txtEmpID.ClientID%>").value = "")
                }

            });


            var radioValue = $("input[name='customRadioInline3']:checked").val();

            if (radioValue == "single") {
                $('.all').show()

                $('.multidatadiv').hide();
                $('.singledatadiv').show();
                   <%-- (document.getElementById("<%=ddlFMV.ClientID%>").value = 0)
                    (document.getElementById("<%=ddlVesting.ClientID %>").value = 0)

                    (document.getElementById("<%=txtEmpID.ClientID%>").value = "")--%>
            }
            else {

                $('.all').show()

                $('.singledatadiv').hide();
                $('.multidatadiv').show();
                <%--   (document.getElementById("<%=ddlFMV.ClientID%>").value = 0)
                    (document.getElementById("<%=ddlVesting.ClientID %>").value = 0)

                    (document.getElementById("<%=txtEmpID.ClientID%>").value = "")--%>
            }

            //$('#tablediv').hide();
            //$('#btnSaveGrant').click(function () {
            //    $('#tablediv').slideToggle();
            //    $('html, body').animate({
            //        scrollTop: $("#tablediv").offset().top
            //    }, 2000);

            //});
            //$('#tablediv').hide();

            //$('.CloseBtnNew').click(function () {
            //    alert('test');
            //    $('#myModal').modal('hide');
            //});
        });
    </script>
    <script>
        function Hide_Div() {

            document.getElementById("<%=tablediv.ClientID%>").style.display = "none";

        };
    </script>

    <script>
        function Show_Div() {

            document.getElementById("<%=tablediv.ClientID%>").style.display = "block";

        };
    </script>
    <script>
        //function Show_Div() {
        //    //alert('HII');
        //    $('#tablediv').slideToggle();
        //    $('html, body').animate({
        //        scrollTop: $("#tablediv").offset().top
        //    }, 2000);

        //};
    </script>
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
    <script>
        function createTable() {

            $("#noOfVestingTable").html('');
            var rows = $("#noOfCycle").val();
            if (!rows) {
                return;
            }

            for (var i = 0; i < rows; i++) {
                var htmlcontent = "";

                htmlcontent += '<tr>                                                                                   ';
                htmlcontent += '    <td>                                                                               ';
                htmlcontent += '      <div class="form-group" style="margin-bottom: -2px;">                            ';
                htmlcontent += '         <input type="text" class="form-control" value="v' + (i + 1) + '" disabled="">               ';
                htmlcontent += '      </div>                                                                           ';
                htmlcontent += '    </td>                                                                              ';
                htmlcontent += '    <td>                                                                               ';
                htmlcontent += '      <div class="form-group" style="margin-bottom: -2px;">                            ';
                htmlcontent += '         <input type="text" class="form-control" placeholder="Vesting %">        ';
                htmlcontent += '      </div>                                                                           ';
                htmlcontent += '    </td>                                                                              ';
                htmlcontent += '    <td>                                                                               ';
                htmlcontent += '      <div class="form-group">                                                         ';
                htmlcontent += '         <div class="input-group mb-3">                                                ';
                htmlcontent += '            <select class="form-control" style="margin-bottom: -2px;margin-top: 16px;">';
                htmlcontent += '               <option>Vesting Cycle Duration</option>                                 ';
                htmlcontent += '               <option>1 year</option>                                                 ';
                htmlcontent += '               <option>2 year</option>                                                 ';
                htmlcontent += '               <option>3 year</option>                                                 ';
                htmlcontent += '               <option>4 year</option>                                                 ';
                htmlcontent += '               <option>5 year</option>                                                 ';
                htmlcontent += '               <option>6 year</option>                                                 ';
                htmlcontent += '            </select>                                                                  ';
                htmlcontent += '         </div>                                                                        ';
                htmlcontent += '      </div>                                                                           ';
                htmlcontent += '    </td>                                                                              ';
                htmlcontent += ' </tr>                                                                                 ';


                $("#noOfVestingTable").append(htmlcontent);
            }
        }
    </script>

    <script>
        function isNumberKey(evt) {
            var charCode = (evt.which) ? evt.which : evt.keyCode;
            if (charCode != 46 && charCode > 31
              && (charCode < 48 || charCode > 57))
                return false;

            return true;
        }

        $(function () {
            <%--//var DropDownID = Document.getElementById('<%= ddlnoOfCycle.ClientID %>');--%>

            $("#ddlnoOfCycle").change(function () {
                if ($(this).val() == "1") {
                    $("#trV1").show();
                    $("#trV2").hide();
                    $("#trV3").hide();
                    $("#trV4").hide();
                    $("#trV5").hide();

                }

                else if ($(this).val() == "2") {
                    $("#trV1").show();
                    $("#trV2").show();
                    $("#trV3").hide();
                    $("#trV4").hide();
                    $("#trV5").hide();

                }
                else if ($(this).val() == "3") {
                    $("#trV1").show();
                    $("#trV2").show();
                    $("#trV3").show();
                    $("#trV4").hide();
                    $("#trV5").hide();



                }
                else if ($(this).val() == "4") {
                    $("#trV1").show();
                    $("#trV2").show();
                    $("#trV3").show();
                    $("#trV4").show();
                    $("#trV5").hide();


                }
                else if ($(this).val() == "5") {
                    $("#trV1").show();
                    $("#trV2").show();
                    $("#trV3").show();
                    $("#trV4").show();
                    $("#trV5").show();
                }
                else {
                    $("#trV1").hide();
                    $("#trV2").hide();
                    $("#trV3").hide();
                    $("#trV4").hide();
                    $("#trV5").hide();
                }
            });
        });
        function ValidatePercent() {
            var DropDownID = $('#ddlnoOfCycle').val();

            //var selectedItemsCount = MasterTable.get_selectedItems().length;
            //if (selectedItemsCount == 0) {
            //    alert("Select at least one item!");
            //    return false;
            //}
        }
        //function WebForm_OnSubmit() {
        //    if (typeof (ValidatorOnSubmit) == "function" && ValidatorOnSubmit() == false) {
        //        for (var i in Page_Validators) {
        //            try {
        //                var control = document.getElementById(Page_Validators[i].controltovalidate);
        //                if (!Page_Validators[i].isvalid) {
        //                    control.className = "form-control";
        //                    control.style.border = '1px solid red';
        //                } else {
        //                    control.className = "form-control";
        //                    control.style.border = '1px solid #0b445d42';
        //                }
        //            } catch (e) { }
        //        }
        //        return false;
        //    }
        //    return true;
        //}

        function GetSelectedItem(el) {
            //var e = document.getElementById(el);
            //var count = e.options[e.selectedIndex].value;
           <%-- var ddl = Document.getElementById('<%= ddlnoOfCycle1.ClientID %>');
            var selectedVal = ddl.value;--%>
            var isValid = true;
            var e = document.getElementById('<%=ddlnoOfCycle1.ClientID%>');
            var count = e.value;
            if (count == "0") {
                ValidatorEnable(document.getElementById("<%=rfvperc1.ClientID %>"), false);
                ValidatorEnable(document.getElementById("<%=rfvtxtperc2.ClientID %>"), false);
                ValidatorEnable(document.getElementById("<%=rfvtxtperc3.ClientID %>"), false);
                ValidatorEnable(document.getElementById("<%=rfvtxtperc4.ClientID %>"), false);
                ValidatorEnable(document.getElementById("<%=rfvtxtperc5.ClientID %>"), false);
                ValidatorEnable(document.getElementById("<%=rfvduration1.ClientID %>"), false);
                ValidatorEnable(document.getElementById("<%=rfvduration2.ClientID %>"), false);
                ValidatorEnable(document.getElementById("<%=rfvduration3.ClientID %>"), false);
                ValidatorEnable(document.getElementById("<%=rfvddlduration4.ClientID %>"), false);
                ValidatorEnable(document.getElementById("<%=rfvddlduration5.ClientID %>"), false);
                if (Page_ClientValidate()) {
                }
            }
            else if (count == "1") {
                ValidatorEnable(document.getElementById("<%=rfvperc1.ClientID %>"), true);
                ValidatorEnable(document.getElementById("<%=rfvtxtperc2.ClientID %>"), false);
                ValidatorEnable(document.getElementById("<%=rfvtxtperc3.ClientID %>"), false);
                ValidatorEnable(document.getElementById("<%=rfvtxtperc4.ClientID %>"), false);
                ValidatorEnable(document.getElementById("<%=rfvtxtperc5.ClientID %>"), false);
                ValidatorEnable(document.getElementById("<%=rfvduration1.ClientID %>"), true);
                ValidatorEnable(document.getElementById("<%=rfvduration2.ClientID %>"), false);
                ValidatorEnable(document.getElementById("<%=rfvduration3.ClientID %>"), false);
                ValidatorEnable(document.getElementById("<%=rfvddlduration4.ClientID %>"), false);
                ValidatorEnable(document.getElementById("<%=rfvddlduration5.ClientID %>"), false);
                //var percent1 = Document.getElementById('<%= txtperc1.ClientID %>').val();
                if (Page_ClientValidate()) {
                    var percent1 = document.getElementById("ContentPlaceHolder1_txtperc1").value;
                    if (percent1 == 0) {
                        alert('First vesting cycle should not be 0 percent');
                        document.getElementById('<%=txtperc1.ClientID%>').focus();
                        isValid = false;
                        return false;
                    }
                    if (percent1 != 100) {

                        alert('Total of vesting cycle should be 100 percent');
                        isValid = false;
                    }
                }
                //else {
                //    return true;
                //}
            }
            else if (count == "2") {
                ValidatorEnable(document.getElementById("<%=rfvperc1.ClientID %>"), true);
                ValidatorEnable(document.getElementById("<%=rfvtxtperc2.ClientID %>"), true);
                ValidatorEnable(document.getElementById("<%=rfvtxtperc3.ClientID %>"), false);
                ValidatorEnable(document.getElementById("<%=rfvtxtperc4.ClientID %>"), false);
                ValidatorEnable(document.getElementById("<%=rfvtxtperc5.ClientID %>"), false);
                ValidatorEnable(document.getElementById("<%=rfvduration1.ClientID %>"), true);
                ValidatorEnable(document.getElementById("<%=rfvduration2.ClientID %>"), true);
                ValidatorEnable(document.getElementById("<%=rfvduration3.ClientID %>"), false);
                ValidatorEnable(document.getElementById("<%=rfvddlduration4.ClientID %>"), false);
                ValidatorEnable(document.getElementById("<%=rfvddlduration5.ClientID %>"), false);
                //var percent1 = Document.getElementById('<%= txtperc1.ClientID %>').val();
                var percent1 = document.getElementById("ContentPlaceHolder1_txtperc1").value;
                var percent2 = document.getElementById("ContentPlaceHolder1_txtperc2").value;
                if (Page_ClientValidate()) {
                    if (percent1 == 0) {

                        alert('First vesting cycle should not be 0 percent');
                        document.getElementById('<%=txtperc1.ClientID%>').focus();
                        isValid = false;
                        return false;

                    }

                    if (percent2 == 0) {

                        alert('Second vesting cycle should not be 0 percent');
                        document.getElementById('<%=txtperc2.ClientID%>').focus();
                        isValid = false;
                        return false;

                    }
                    if ((parseInt(percent1) + parseInt(percent2)) != 100) {

                        alert('Total of vesting cycle should be 100 percent');
                        isValid = false;
                    }
                }
                //else {
                //    return true;
                //}
            }
            else if (count == "3") {
                ValidatorEnable(document.getElementById("<%=rfvperc1.ClientID %>"), true);
                ValidatorEnable(document.getElementById("<%=rfvtxtperc2.ClientID %>"), true);
                ValidatorEnable(document.getElementById("<%=rfvtxtperc3.ClientID %>"), true);
                ValidatorEnable(document.getElementById("<%=rfvtxtperc4.ClientID %>"), false);
                ValidatorEnable(document.getElementById("<%=rfvtxtperc5.ClientID %>"), false);
                ValidatorEnable(document.getElementById("<%=rfvduration1.ClientID %>"), true);
                ValidatorEnable(document.getElementById("<%=rfvduration2.ClientID %>"), true);
                ValidatorEnable(document.getElementById("<%=rfvduration3.ClientID %>"), true);
                ValidatorEnable(document.getElementById("<%=rfvddlduration4.ClientID %>"), false);
                ValidatorEnable(document.getElementById("<%=rfvddlduration5.ClientID %>"), false);
                //var percent1 = Document.getElementById('<%= txtperc1.ClientID %>').val();
                var percent1 = document.getElementById("ContentPlaceHolder1_txtperc1").value;
                var percent2 = document.getElementById("ContentPlaceHolder1_txtperc2").value;
                var percent3 = document.getElementById("ContentPlaceHolder1_txtperc3").value;
                if (Page_ClientValidate()) {
                    if (percent1 == 0) {

                        alert('First vesting cycle should not be 0 percent');
                        document.getElementById('<%=txtperc1.ClientID%>').focus();
                        isValid = false;
                        return false;

                    }

                    if (percent2 == 0) {

                        alert('Second vesting cycle should not be 0 percent');
                        document.getElementById('<%=txtperc2.ClientID%>').focus();
                        isValid = false;
                        return false;

                    }


                    if (percent3 == 0) {

                        alert('Third vesting cycle should not be 0 percent');
                        document.getElementById('<%=txtperc3.ClientID%>').focus();
                        isValid = false;
                        return false;

                    }
                    if ((parseInt(percent1) + parseInt(percent2) + parseInt(percent3)) != 100) {

                        alert('Total of vesting cycle should be 100 percent');
                        isValid = false;
                    }
                }
                //else {
                //    return true;
                //}
            }
            else if (count == "4") {
                ValidatorEnable(document.getElementById("<%=rfvperc1.ClientID %>"), true);
                ValidatorEnable(document.getElementById("<%=rfvtxtperc2.ClientID %>"), true);
                ValidatorEnable(document.getElementById("<%=rfvtxtperc3.ClientID %>"), true);
                ValidatorEnable(document.getElementById("<%=rfvtxtperc4.ClientID %>"), true);
                ValidatorEnable(document.getElementById("<%=rfvtxtperc5.ClientID %>"), false);
                ValidatorEnable(document.getElementById("<%=rfvduration1.ClientID %>"), true);
                ValidatorEnable(document.getElementById("<%=rfvduration2.ClientID %>"), true);
                ValidatorEnable(document.getElementById("<%=rfvduration3.ClientID %>"), true);
                ValidatorEnable(document.getElementById("<%=rfvddlduration4.ClientID %>"), true);
                ValidatorEnable(document.getElementById("<%=rfvddlduration5.ClientID %>"), false);
                //var percent1 = Document.getElementById('<%= txtperc1.ClientID %>').val();
                var percent1 = document.getElementById("ContentPlaceHolder1_txtperc1").value;
                var percent2 = document.getElementById("ContentPlaceHolder1_txtperc2").value;
                var percent3 = document.getElementById("ContentPlaceHolder1_txtperc3").value;
                var percent4 = document.getElementById("ContentPlaceHolder1_txtperc4").value;
                if (Page_ClientValidate()) {
                    if (percent1 == 0) {

                        alert('First vesting cycle should not be 0 percent');
                        document.getElementById('<%=txtperc1.ClientID%>').focus();
                        isValid = false;
                        return false;

                    }

                    if (percent2 == 0) {

                        alert('Second vesting cycle should not be 0 percent');
                        document.getElementById('<%=txtperc2.ClientID%>').focus();
                        isValid = false;
                        return false;

                    }


                    if (percent3 == 0) {

                        alert('Third vesting cycle should not be 0 percent');
                        document.getElementById('<%=txtperc3.ClientID%>').focus();
                        isValid = false;
                        return false;

                    }

                    if (percent4 == 0) {

                        alert('Fourth vesting cycle should not be 0 percent');
                        document.getElementById('<%=txtperc4.ClientID%>').focus();
                        isValid = false;
                        return false;

                    }
                    if ((parseInt(percent1) + parseInt(percent2) + parseInt(percent3) + parseInt(percent4)) != 100) {

                        alert('Total of vesting cycle should be 100 percent');
                        isValid = false;
                    }
                }
                //else {
                //    return true;
                //}
            }
            else if (count == "5") {
                //var percent1 = Document.getElementById('<%= txtperc1.ClientID %>').val();
                ValidatorEnable(document.getElementById("<%=rfvperc1.ClientID %>"), true);
                ValidatorEnable(document.getElementById("<%=rfvtxtperc2.ClientID %>"), true);
                ValidatorEnable(document.getElementById("<%=rfvtxtperc3.ClientID %>"), true);
                ValidatorEnable(document.getElementById("<%=rfvtxtperc4.ClientID %>"), true);
                ValidatorEnable(document.getElementById("<%=rfvtxtperc5.ClientID %>"), true);
                ValidatorEnable(document.getElementById("<%=rfvduration1.ClientID %>"), true);
                ValidatorEnable(document.getElementById("<%=rfvduration2.ClientID %>"), true);
                ValidatorEnable(document.getElementById("<%=rfvduration3.ClientID %>"), true);
                ValidatorEnable(document.getElementById("<%=rfvddlduration4.ClientID %>"), true);
                ValidatorEnable(document.getElementById("<%=rfvddlduration5.ClientID %>"), true);
                var percent1 = document.getElementById("ContentPlaceHolder1_txtperc1").value;
                var percent2 = document.getElementById("ContentPlaceHolder1_txtperc2").value;
                var percent3 = document.getElementById("ContentPlaceHolder1_txtperc3").value;
                var percent4 = document.getElementById("ContentPlaceHolder1_txtperc4").value;
                var percent5 = document.getElementById("ContentPlaceHolder1_txtperc5").value;
                if (Page_ClientValidate()) {
                    if (percent1 == 0) {

                        alert('First vesting cycle should not be 0 percent');
                        document.getElementById('<%=txtperc1.ClientID%>').focus();
                        isValid = false;
                        return false;

                    }

                    if (percent2 == 0) {

                        alert('Second vesting cycle should not be 0 percent');
                        document.getElementById('<%=txtperc2.ClientID%>').focus();
                        isValid = false;
                        return false;

                    }


                    if (percent3 == 0) {

                        alert('Third vesting cycle should not be 0 percent');
                        document.getElementById('<%=txtperc3.ClientID%>').focus();
                        isValid = false;
                        return false;

                    }

                    if (percent4 == 0) {

                        alert('Fourth vesting cycle should not be 0 percent');
                        document.getElementById('<%=txtperc4.ClientID%>').focus();
                        isValid = false;
                        return false;

                    }


                    if (percent5 == 0) {

                        alert('Fifth vesting cycle should not be 0 percent');
                        document.getElementById('<%=txtperc5.ClientID%>').focus();
                        isValid = false;
                        return false;

                    }

                    if ((parseInt(percent1) + parseInt(percent2) + parseInt(percent3) + parseInt(percent4) + parseInt(percent5)) != 100) {

                        alert('Total of vesting cycle should be 100 percent');
                        isValid = false;
                    }
                }
                //else {
                //    return true;
                //}
            }

    return isValid;
}
//function ValidatorUpdateDisplay(val) {
//    if (typeof (val.display) == "string") {
//        if (val.display == "None") {
//            return;
//        }
//        if (val.display == "Dynamic") {
//            val.style.display = val.isvalid ? "none" : "inline";
//            return;
//        }

//    }
//    val.style.visibility = val.isvalid ? "hidden" : "visible";
//    if (val.isvalid) {
//        document.getElementById(val.controltovalidate).style.border = '1px solid #DCDCDC';
//    }
//    else {
//        document.getElementById(val.controltovalidate).style.border = '1px solid LightSalmon';
//    }
//}
    </script>
    <script type="text/javascript">
        $(document).ready(function () {
            dropchange();
        });
        function dropchange() {
            ////var id = ddl.id;
            //var selectedVal = ddl.value;
            //// alert(selectedVal);
            var ddlFruits = document.getElementById("<%=ddlnoOfCycle1.ClientID %>");
            //var selectedText = ddlFruits.options[ddlFruits.selectedIndex].innerHTML;
            var selectedVal = ddlFruits.value;
            //alert(selectedVal);
            if (selectedVal == "1") {
                $("#trV1").show();
                $("#trV2").hide();
                $("#trV3").hide();
                $("#trV4").hide();
                $("#trV5").hide();

            }

            else if (selectedVal == "2") {
                $("#trV1").show();
                $("#trV2").show();
                $("#trV3").hide();
                $("#trV4").hide();
                $("#trV5").hide();

            }
            else if (selectedVal == "3") {
                $("#trV1").show();
                $("#trV2").show();
                $("#trV3").show();
                $("#trV4").hide();
                $("#trV5").hide();



            }
            else if (selectedVal == "4") {
                $("#trV1").show();
                $("#trV2").show();
                $("#trV3").show();
                $("#trV4").show();
                $("#trV5").hide();


            }
            else if (selectedVal == "5") {
                $("#trV1").show();
                $("#trV2").show();
                $("#trV3").show();
                $("#trV4").show();
                $("#trV5").show();
            }
            else {
                $("#trV1").hide();
                $("#trV2").hide();
                $("#trV3").hide();
                $("#trV4").hide();
                $("#trV5").hide();
            }
        }
    </script>
    <script type="text/javascript">

        function openModal() {
            $('#modalVesting').modal({ show: true });
        }


    </script>
    <script type="text/javascript">
        function showProgress1() {
            debugger;
            var updateProgress1 = $get("<%= UpdateProgress1.ClientID %>");
            updateProgress1.style.display = "block";
        }
    </script>

    <div class="modal bd-example-modal-lg" id="my_Modal" tabindex="-1" role="dialog">
        <div class="modal-dialog modal-xl boxModalDiv">
            <!-- Modal content-->
            <div class="modal-content" style="width: 100%;">
                <div class="modal-header">
                    <h5 class="modal-title" id="myLargeModalLabel">Grants
                        <%--<button type="button" class="close modalClose" data-dismiss="modal">&times;</button>--%>
                    </h5>
                    <%-- <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                            <span aria-hidden="true">×</span>
                        </button>--%>
                </div>
                <div class="col-lg-3 offset-md-3" style="padding-top: 12px; margin-left: 88%;">
                    <%--<asp:ImageButton ID='imgExportAudit' runat='server' ImageUrl="~/img/excel1.png" Style="margin-left: 18px;" Height="35px" ToolTip="Export To Excel" OnClick="imgExportAudit_Click" onkeydown="return checkShortcut();" />--%>
                    <%--<asp:ImageButton ID='btnExportPDF' runat='server' ImageUrl="~/img/pdf.png" Height="35px" ToolTip="Export To Pdf" OnClick="btnpdfexport_Click" />--%>
                </div>
                <div class="card-body">
                    <div class="table-responsive">
                        <asp:UpdatePanel ID="UpdatePanel6" runat="server">
                            <ContentTemplate>

                                <asp:GridView ID="grdData_1" class="table" runat="server" Style="width: 98%;"
                                    AutoGenerateColumns="False" AllowPaging="false" PageSize="10" AllowSorting="false"
                                    EmptyDataText="No data found" AllowCustomPaging="false" ViewStateMode="Enabled" OnRowCommand="grdData_RowCommand">
                                    <Columns>
                                        <asp:TemplateField HeaderText="Employee Name">
                                            <ItemTemplate>
                                                <asp:Label ID="lbl_DEM_EMP_ID" runat="server" Text='<%#Eval("Employee_Name") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>

                                        <asp:TemplateField HeaderText="Grant Name">
                                            <ItemTemplate>
                                                <asp:Label ID="lbl_DEM_GRANT_NAME" runat="server" Text='<%#Eval("DEM_GRANT_NAME") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>

                                        <asp:TemplateField HeaderText="Date of Grant">
                                            <ItemTemplate>
                                                <asp:Label ID="lbl_DEM_GRANT_DATE" runat="server" Text='<%#Eval("DEM_GRANT_DATE") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>

                                        <asp:TemplateField HeaderText="No Of Option">
                                            <ItemTemplate>
                                                <asp:Label ID="lbl_DEM_NO_OF_OPTION" runat="server" Text='<%#Eval("DEM_NO_OF_OPTION") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Grant Letter Download">
                                            <ItemTemplate>
                                                <asp:HiddenField ID="HiddenField1" runat="server" Value='<%# Bind("FILEName") %>' />
                                                <%--<asp:LinkButton ID="btn_Preview" runat="server" CausesValidation="false" CommandName="Preview" OnClick="btn_Preview_Click"
                                                                                CssClass="btn btn-icon btn-success fas fa-eye"></asp:LinkButton>--%>
                                                <asp:LinkButton ID="lb_download" runat="server" CommandArgument='<%# Eval("FILEName") %>' CausesValidation="false"
                                                    class="btn btn-icon btn-primary fas fa-arrow-down" OnClick="lb_download_Click"></asp:LinkButton>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                    </Columns>

                                </asp:GridView>

                            </ContentTemplate>
                            <%--<Triggers>
                                <asp:AsyncPostBackTrigger ControlID="lb_download" />
                            </Triggers>--%>
                        </asp:UpdatePanel>
                        <asp:button id="BtnDownload" onclick="DownloadFile_Click" runat="server" visible="false" xmlns:asp="#unknown" />
                    </div>
                </div>

                <div class="modal-footer bg-whitesmoke br">
                    <div class="btn-group" role="group" aria-label="Basic example">
                        <asp:Button ID="BtnCancle_1" runat="server" Text="Cancel Grant" OnClick="Cancle_Click" CssClass="btn btn-info btn-lg all" />
                        <asp:Button ID="BtnSubmitGrant_1" runat="server" Text="Create Grant" OnClick="BtnSubmitGrant_Click" CssClass="btn btn-info btn-lg all" />

                        <%--<a href="#" class="btn btn-info btn-lg all CloseBtnNew" data-dismiss="modal">Save Grant</a>--%>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <script type="text/javascript">
        function openGrandModal() {
            debugger;
            $('#my_Modal').modal('show');
        }
    </script>
    <script type="text/javascript">
        function openModal2(srcval) {
            debugger;
            document.getElementById('<%=embed1.ClientID%>').src = "";
            document.getElementById('<%=embed1.ClientID%>').src = srcval;
            $('#myModal1').modal('show');
        }
    </script>
    <script type="text/javascript">
        function openModal1() {
            $('#myModal2').modal('show');
        }
    </script>
    <%--<script>
        $('.CloseBtnNew').click(function () {
            //alert('test_2');
            $("#myModal").removeClass("show");
            $("#myModal").hide();
            $(".modal-backdrop").remove();
            $("body").removeClass("modal-open");


            $("#modalVesting").removeClass("show");
            $("#modalVesting").hide();
            $(".modal-backdrop").remove();
            $("body").removeClass("modal-open");

            $("#ModalCreateFMV").removeClass("show");
            $("#ModalCreateFMV").hide();
            $(".modal-backdrop").remove();
            $("body").removeClass("modal-open");

            //alert('test_3');

        });
    </script>--%>
    <script type="text/javascript">
        function openalert(a) {
            alert('Alert_' + a);
        }
    </script>
</asp:Content>

