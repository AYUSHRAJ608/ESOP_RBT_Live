<%@ Page Title="" Language="C#" MasterPageFile="~/ESOP.Master" AutoEventWireup="true" CodeBehind="Add_Existing_Data.aspx.cs" Inherits="ESOP.Add_Existing_Data" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

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

        @media (min-width: 768px) {
            .offset-md-8 {
                margin-left: 74%;
            }
        }

        /*.modal.show .modal-content {
            width: 85% !important;
            padding-bottom: 12px;
        }*/
    </style>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <script src="assets/js/jquery-1.8.3.min.js" type="text/javascript"></script>
    <link href="assets/css/jquery-ui-1.12.1.css" rel="stylesheet" />
    <script src="assets/js/jquery-1.12.4.js" type="text/javascript"></script>
    <script src="assets/js/jquery-ui-1.12.1.js" type="text/javascript"></script>



    <script src="assets/js/jquery.dataTables-1.10.20.min.js" type="text/javascript"></script>
    <link href="Scripts/jquery.dataTables.min.css" rel="stylesheet" />
    <link href="Scripts/dataTables.bootstrap4.min.css" rel="stylesheet" />

    <script>
        function DrpValidation() {
            debugger;

            var value = document.getElementById("<%=ddlData.ClientID%>");
            var text = value.options[value.selectedIndex].text;
            if (text == "Select") {
                alert("Please Select Master!!");
                document.getElementById('<%=ddlData.ClientID%>').focus();
                return false;
            }

            var FileUploadFooter = document.getElementById('<%=uploadfile.ClientID%>').value;

            if (FileUploadFooter.trim() == "") {
                alert("Select Upload File!");
                document.getElementById('<%=uploadfile.ClientID%>').focus();
                return false;
            }
            else {
                var ext = FileUploadFooter.substr(FileUploadFooter.lastIndexOf('.') + 1).toLowerCase();
                if (ext == "xlx" || ext == "xlsx") {
                   <%-- var updateProgress1 = $get("<%= UpdateProgress1.ClientID %>");
                    updateProgress1.style.display = "block";--%>
                    return true;
                }
                else {
                    alert("Invalid file, must select a *.xlx,xlsx file only.");
                    document.getElementById('<%=uploadfile.ClientID%>').value = "";
                    document.getElementById('<%=uploadfile.ClientID%>').focus();
                    return false;

                }
            }
        }
    </script>


    <asp:ScriptManager ID="script" runat="server"></asp:ScriptManager>
    <div class="main-content">
        <nav aria-label="breadcrumb">
            <ol class="breadcrumb">
                <li class="breadcrumb-item"><a href="admin-dashboard.aspx">Home</a></li>
                <li class="breadcrumb-item"><a href="settings.aspx">Masters</a></li>
                <li class="breadcrumb-item active" aria-current="page">Bulk Master Upload</li>
            </ol>
        </nav>
        <section class="section">
            <input type="hidden" id="hdnTab" name="custId" value="2" />
            <div class="row">
                <div class="col-lg-12 col-md-12 col-12 col-sm-12">
                    <div class="card">
                        <div class="card-body">
                            <div class="row">
                                <div class="col-md-4 multidatadiv">

                                    <div class="form-group">
                                        <label>Select</label><span style="color: red">*</span>
                                        <asp:DropDownList ID="ddlData" runat="server" CssClass="form-control" AutoPostBack="false">
                                            <asp:ListItem Value="0">Select</asp:ListItem>
                                            <asp:ListItem Value="3">Valuation Master</asp:ListItem>
                                            <asp:ListItem Value="1">FMV Master</asp:ListItem>
                                            <asp:ListItem Value="4">Vesting Master</asp:ListItem>
                                            <asp:ListItem Value="2">Grant Creation Master</asp:ListItem>
                                            <%--<asp:ListItem Value="7">Grant Vesting Creation</asp:ListItem>--%>
                                            <asp:ListItem Value="6">Employee Excercise</asp:ListItem>
                                            <asp:ListItem Value="5">Employee Sale</asp:ListItem>
                                           <%-- <asp:ListItem Value="1">FMV Master</asp:ListItem>
                                            <asp:ListItem Value="2">Grant Creation Master</asp:ListItem>
                                            <asp:ListItem Value="7">Grant Vesting Creation</asp:ListItem>
                                            <asp:ListItem Value="3">Valuation Master</asp:ListItem>
                                            <asp:ListItem Value="4">Vesting Master</asp:ListItem>
                                            <asp:ListItem Value="5">Employee Sale</asp:ListItem>
                                            <asp:ListItem Value="6">Employee Excercise</asp:ListItem>--%>
                                        </asp:DropDownList>
                                    </div>

                                </div>
                                <div class="col-md-4 multidatadiv">

                                    <div class="form-group">
                                        <label>Upload File</label><span style="color: red">*</span>
                                        <asp:FileUpload ID="uploadfile" runat="server" CssClass="dropify" accept=".xlx, .xlsx" class="form-control" />
                                    </div>

                                </div>
                                <div class="col-md-4 multidatadiv">

                                    <div class="form-group">
                                        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                                            <ContentTemplate>
                                                <label class="btn-block" style="font-weight: 600; color: #34395e"><b>Download File Format</b></label>
                                                <asp:Button ID="BtnDownload" runat="server" CausesValidation="false" OnClick="BtnDownload_Click"
                                                    Text="Excel format" class="btn btn-info btn-lg all"></asp:Button>
                                            </ContentTemplate>
                                            <Triggers>
                                                <asp:PostBackTrigger ControlID="BtnDownload" />
                                            </Triggers>
                                        </asp:UpdatePanel>
                                    </div>

                                </div>
                            </div>
                            <div class="row" style="margin-left: 330px;">


                                <%--</div>--%>
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
                                            <asp:Button ID="btnImport" runat="server" Text="Submit" CssClass="btn btn-info btn-lg" OnClientClick="return DrpValidation();"
                                                OnClick="btnImport_Click" />
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
            <div class="col-lg-12 col-md-12 col-12 col-sm-12">
                      <asp:GridView ID="gvdttoexcel" runat="server" AutoGenerateColumns="False" ShowHeaderWhenEmpty="true"
                                                    class="table table-borderless click" Visible="false">
                     </asp:GridView>
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
                                            <button runat="server" id="btnExDown" onserverclick="downloadFailedRec" style="background: none">
                                                <i class="fas fa-arrow-circle-down"></i>
                                            </button>
                                        </td>
                                    </tr>
                                </tbody>
                            </table>
                        </div>
                    </div>
                </div>
            </div>
            <asp:UpdatePanel ID="upd3" runat="server">
                <ContentTemplate>
                    <div id="showmsg" runat="server"></div>
                </ContentTemplate>
            </asp:UpdatePanel>
        </section>
    </div>
    <!-- General JS Scripts -->
    <script src="assets/js/bootstrap-3.3.6.min.js"></script>
    <script src="assets/js/app.min.js"></script>

    <script src="assets/js/scripts.js"></script>
    <%--<script type="text/javascript">
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
    </script>--%>
</asp:Content>

