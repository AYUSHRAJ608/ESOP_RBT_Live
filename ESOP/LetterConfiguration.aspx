<%@ Page Title="" Language="C#" MasterPageFile="~/ESOP.Master" AutoEventWireup="true" CodeBehind="LetterConfiguration.aspx.cs" Inherits="ESOP.LetterConfiguration" %>

<%--<%@ Register Assembly="FreeTextBox" Namespace="FreeTextBoxControls" TagPrefix="FTB" %>--%>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ScriptManager ID="script" runat="server"></asp:ScriptManager>
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
        .edit12 {
            padding: 10px;
            background: #2600ff;
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

        .btn-group {
            height: 22px;
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
            margin-left: 77%;
        }

        .offset-md-10 {
            margin-left: 82%;
        }

        .section > :first-child {
            margin-top: -34px;
        }


        .table:not(.table-sm):not(.table-md):not(.dataTable) th {
            background: #6c757d75 !important;
            color: #000000c2 !important;
        }

        .btn {
            height: 34px;
            line-height: 19px !important;
        }

        .switch {
            position: relative;
            display: inline-block;
            width: 70px;
            height: 24px;
            margin-top: 7px;
        }

            .switch input {
                opacity: 0;
            }

        .slider {
            position: absolute;
            cursor: pointer;
            top: 0;
            left: 0;
            right: 0;
            bottom: 0;
            background-color: #ccc;
            -webkit-transition: .4s;
            transition: .4s;
        }

            .slider:before {
                position: absolute;
                content: "";
                height: 16px;
                width: 16px;
                left: 4px;
                bottom: 4px;
                background-color: white;
                -webkit-transition: .4s;
                transition: .4s;
            }

        input:checked + .slider {
            background-color: #2600ff;
        }

        input:focus + .slider {
            box-shadow: 0 0 1px #2196F3;
        }

        input:checked + .slider:before {
            -webkit-transform: translateX(46px);
            -ms-transform: translateX(46px);
            transform: translateX(46px);
        }
        /*------ ADDED CSS ---------*/
        .on {
            display: none;
        }

        .on, .off {
            color: white;
            position: absolute;
            transform: translate(-50%,-50%);
            top: 50%;
            left: 50%;
            font-size: 12px;
            font-family: Verdana, sans-serif;
        }

        input:checked + .slider .on {
            display: block;
        }

        input:checked + .slider .off {
            display: none;
        }

        /* Rounded sliders */
        .slider.round {
            border-radius: 34px;
        }

            .slider.round:before {
                border-radius: 50%;
            }

        .table.dataTable.no-footer {
            width: 100% !important;
        }

        .modal.show .modal-content {
            width: 85% !important;
            padding-bottom: 20px;
        }
    </style>




    <script type="text/javascript">


        function DrpValidation() {
            debugger;
            var value = document.getElementById("<%=DrpLetterTyp.ClientID%>");
            var text = value.options[value.selectedIndex].value;
            if (text == "Select") {
                alert("Select Letter Type!!");
                document.getElementById('<%=DrpLetterTyp.ClientID%>').focus();
                return false;
            }
        }


        function ReqValidation() {
            debugger;
            var value = document.getElementById("<%=DrpLetterTyp.ClientID%>");
            var text = value.options[value.selectedIndex].value;
            if (text == "Select") {
                alert("Select Letter Type!!");
                document.getElementById('<%=DrpLetterTyp.ClientID%>').focus();
                return false;
            }

            var FileUploadFooter = document.getElementById('<%=FileUploadFooter.ClientID%>').value;

            if (FileUploadFooter.trim() == "") {
                alert("Select Upload File!");
                document.getElementById('<%=FileUploadFooter.ClientID%>').focus();
                return false;
            }
            else {
                var ext = FileUploadFooter.substr(FileUploadFooter.lastIndexOf('.') + 1).toLowerCase();
                if (ext == "docx") {
                    var updateProgress1 = $get("<%= UpdateProgress1.ClientID %>");
                    updateProgress1.style.display = "block";
                    return true;
                }
                else {
                    alert("Invalid file, must select a *.docx file only.");
                    document.getElementById('<%=FileUploadFooter.ClientID%>').value = "";
                    document.getElementById('<%=FileUploadFooter.ClientID%>').focus();
                    return false;

                }
            }
        }
    </script>



    <div class="main-content">
        <nav aria-label="breadcrumb">
            <ol class="breadcrumb">
                <li class="breadcrumb-item"><a href="admin-dashboard.aspx">Home</a></li>
                <li class="breadcrumb-item"><a href="settings.aspx">Masters</a></li>
                <li class="breadcrumb-item active" aria-current="page">Letter Configuration</li>
            </ol>
        </nav>
        <section class="section" style="margin-top: 50px;">
            <div class="row">
                <div class="col-lg-12 col-md-12 col-12 col-sm-12">
                    <div class="card" style="height: 100%;">
                        <div class="card-header">
                            <%-- <h4 style="font-size: 16px; line-height: 28px; padding-right: 10px; margin-bottom: 0; display: block; width: 100%;">Letters Configuration</h4>--%>
                            <h4>Letters Configuration</h4>
                            <div>
                                <div class="form-group" style="margin-left: 25px; margin-bottom: 0px;">
                                    <div class="custom-control custom-radio custom-control-inline">
                                        <input type="radio" id="customRadioInline3" name="customRadioInline3" class="custom-control-input" value="Upload" checked>
                                        <%--<asp:RadioButton ID="rbBulk" runat="server" Text="Bulk Data Upload" />--%>
                                        <label class="custom-control-label" for="customRadioInline3">Create Letter</label>
                                    </div>
                                    <div class="custom-control custom-radio custom-control-inline">
                                        <input type="radio" id="customRadioInline4" name="customRadioInline3" class="custom-control-input" value="single">
                                        <%--<asp:RadioButton ID="rbSingle" runat="server" Text="Single Data Entry" />--%>
                                        <label class="custom-control-label" for="customRadioInline4">Upload Letter</label>
                                    </div>
                                </div>
                            </div>
                        </div>
                        <div class="card-body">
                            <div class="row" style="margin-top: 15px;">
                                <div class="col-lg-3 col-md-12 col-sm-12 all">
                                    <div class="form-group">
                                        <label>Select Letter :</label>
                                        <asp:DropDownList ID="DrpLetterTyp" runat="server" CssClass="form-control" Style="width: 100% !important;">
                                            <asp:ListItem Value="Select">Select Letter</asp:ListItem>
                                            <asp:ListItem Value="1">Grant Letter</asp:ListItem>
                                            <asp:ListItem Value="2">Sell Offer Letter</asp:ListItem>
                                            <asp:ListItem Value="3">Sell Declaration Letter</asp:ListItem>
                                        </asp:DropDownList>
                                    </div>
                                </div>
                                <div class="col-lg-3 offset-md-3 multidatadiv" style="margin-left: 0%;">
                                    <asp:Button ID="BtnCreateLetter" runat="server" Text="Create Letter" OnClick="BtnCreateLetter_Click"
                                        CausesValidation="true"
                                        class="btn btn-info btn-lg all" OnClientClick="return DrpValidation();" Style="margin-top: 31px;" />
                                </div>
                                <div class="col-lg-4 col-md-12 col-sm-12 singledatadiv">
                                    <div class="form-group">
                                        <label class="btn-block">Upload File</label>
                                        <asp:UpdatePanel ID="UP_submit" runat="server">
                                            <ContentTemplate>
                                                <asp:FileUpload ID="FileUploadFooter" runat="server" />

                                                <asp:Button ID="BtnUpload" runat="server" CausesValidation="false" CommandArgument='<%# Eval("LETTERID") %>' OnClick="BtnUpload_Click" OnClientClick="return ReqValidation(); showProgress1(); return false;return postbackButtonClick();"
                                                    Text="Upload" Style="font-size: 13px; font-weight: 500; letter-spacing: 0.2px; margin: 0; color: #ffffff; clear: both; background: #2600ff; padding: 5px !important; line-height: 14px; height: 28px; border-radius: .25rem;"></asp:Button>
                                                <%--OnClientClick="return ReqValidation();"--%>
                                                <asp:Label ID="lblFileType" runat="server" Text="(Only .docx files are allowed.)" ForeColor="Green" Font-Bold="true" Font-Size="14px"></asp:Label>
                                            </ContentTemplate>
                                            <Triggers>
                                                <asp:PostBackTrigger ControlID="BtnUpload" />
                                            </Triggers>
                                        </asp:UpdatePanel>
                                    </div>
                                </div>
                                <div class="col-lg-2 col-md-12 col-sm-12 all">
                                    <div class="form-group">
                                        <label class="btn-block">Download File Format</label>
                                        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                                            <ContentTemplate>
                                                <%--   <asp:Button ID="BtnDownload" runat="server" CausesValidation="false" OnClick="BtnDownload_Click" OnClientClick="return DrpValidation();"
                                                    Text="Letter format" Style="font-size: 13px; font-weight: 500; letter-spacing: 0.2px; margin: 0; color: #ffffff; clear: both; background: #2600ff; padding: 5px !important; line-height: 14px; height: 28px; border-radius: .25rem;"></asp:Button>--%>
                                                <asp:Button ID="BtnDownload" runat="server" CausesValidation="false" OnClick="BtnDownload_Click" OnClientClick="return DrpValidation();"
                                                    Text="Letter format" class="btn btn-info btn-lg all"></asp:Button>
                                            </ContentTemplate>
                                            <Triggers>
                                                <asp:PostBackTrigger ControlID="BtnDownload" />
                                            </Triggers>
                                        </asp:UpdatePanel>
                                    </div>
                                </div>
                            </div>
                        </div>
                        <asp:UpdatePanel ID="UpdatePanel3" runat="server">
                            <ContentTemplate>
                                <div id="showmsg" runat="server"></div>
                            </ContentTemplate>
                        </asp:UpdatePanel>
                    </div>
                </div>
            </div>

            <div class="col-lg-12 col-md-12 col-12 col-sm-12" id="tablediv" style="margin-top: 30px;">
                <div class="card" style="height: auto;">
                    <div class="card-header">
                        <h4>Letter Configuration Details</h4>
                    </div>
                    <div class="card-body">

                        <div class="table-responsive">
                            <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                                <ContentTemplate>
                                    <asp:GridView ID="GrvLetter_Config" runat="server" AutoGenerateColumns="False" ShowHeaderWhenEmpty="false" DataKeyNames="LETTERID"
                                        class="table" EmptyDataText="No Records Found" OnRowDataBound="GrvLetter_Config_RowDataBound" OnPreRender="GrvLetter_Config_PreRender">
                                        <Columns>
                                            <asp:BoundField DataField="SrNO" HeaderText="Sr No." />
                                            <asp:BoundField DataField="LetterName" HeaderText="Letters" />
                                            <asp:BoundField DataField="UPLOADTYPE" HeaderText="Upload/Create" />
                                            <asp:BoundField DataField="CREATEDDATE" HeaderText="Added Date" />
                                            <asp:TemplateField HeaderText="View Letter">
                                                <ItemTemplate>
                                                    <asp:HiddenField ID="HiddenField1" runat="server" Value='<%# Bind("FILENAME") %>' />
                                                    <asp:HiddenField ID="HdnLtrname" runat="server" Value='<%# Bind("LetterName") %>' />
                                                    <asp:LinkButton ID="btn_Preview" runat="server" CommandName="Preview" CausesValidation="false" OnClick="btn_Preview_Click" CssClass="fas fa-eye edit12"></asp:LinkButton>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Edit">
                                                <ItemTemplate>
                                                    <%--  <a id="lnk" href="#" onclick="window.open('LetterEdit1.aspx?LetterID=<%#Eval("LETTERID") %>')" class="fas fa-pencil-alt edit12"></a>--%>
                                                    <asp:LinkButton ID="Btn_Edit" runat="server" CausesValidation="false" OnClick="Btn_Edit_Click" CommandArgument='<%# Eval("LETTERID") %>' class="fas fa-pencil-alt edit12"></asp:LinkButton>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Enable/Disable">
                                                <ItemTemplate>
                                                    <label class="switch">
                                                        <asp:CheckBox ID="chkOnOff" runat="server" OnCheckedChanged="chkOnOff_CheckedChanged" AutoPostBack="true" Checked='<%# Convert.ToBoolean(Eval("ISACTIVE"))%>' />
                                                        <%--<span class="slider round"></span>--%>
                                                        <div class="slider round">
                                                            <!--ADDED HTML -->
                                                            <span class="on">ON</span><span class="off">OFF</span><!--END-->
                                                        </div>
                                                    </label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Delete">
                                                <ItemTemplate>
                                                    <asp:LinkButton ID="btn_Delete" runat="server" CausesValidation="false" OnClick="btn_Delete_Click"
                                                        CssClass="fas fa-trash-alt delete12"></asp:LinkButton>
                                                    <%--OnClientClick="return confirm('Are you sure you want to Delete record?');"--%>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <%--<asp:TemplateField HeaderText="Show PDF">
                                                <ItemTemplate>
                                                    <asp:LinkButton ID="btn_PDF" runat="server" CausesValidation="false" OnClick="btn_PDF_Click"
                                                        CssClass="fas fa-keyboard edit12"></asp:LinkButton>
                                                </ItemTemplate>
                                            </asp:TemplateField>--%>
                                        </Columns>
                                    </asp:GridView>
                                </ContentTemplate>
                                <Triggers>
                                    <asp:PostBackTrigger ControlID="GrvLetter_Config" />
                                </Triggers>
                            </asp:UpdatePanel>
                        </div>

                    </div>
                </div>
            </div>
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

        </section>

    </div>

    <script src="assets/js/jquery-1.8.3.min.js"></script>
    <script src="assets/js/jquery.dataTables-1.10.20.min.js"></script>
    <link href="Scripts/jquery.dataTables.min.css" rel="stylesheet" />
    <link href="Scripts/dataTables.bootstrap4.min.css" rel="stylesheet" />

    <script type="text/javascript">
        var prm = Sys.WebForms.PageRequestManager.getInstance();
        prm.add_endRequest(function (sender, e) {
            var table = $('#ContentPlaceHolder1_GrvLetter_Config').DataTable({
                lengthMenu: [[-1, 5, 10], ["All", 5, 10]],
                columnDefs: [{ orderable: false, targets: [4, 5, 6, 7,8] }],
                "bStateSave": true,
                bPaginate: true,
                bSort: true,
                bFilter: true,
                bRetrieve: true, fixedHeader: true, "scrollX": true
            });
            table
.search('')
.columns().search('')
.draw();
        });

        $(function () {
            $.noConflict();
            debugger;
            var table = $("#ContentPlaceHolder1_GrvLetter_Config").DataTable({
                bLengthChange: true,
                lengthMenu: [[-1, 5, 10], ["All", 5, 10]],
                bFilter: true,
                order: [],
                columnDefs: [{ orderable: false, targets: [4, 5, 6, 7,8] }],
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

    <%--<div class="modal fade bd-example-modal-lg1" id="myModal1" tabindex="-1" role="dialog" aria-labelledby="myLargeModalLabel" style="display: none;" aria-hidden="true">--%>
    <div class="modal bd-example-modal-lg" id="myModal1" tabindex="-1" role="dialog">
        <div class="modal-dialog modal-lg" style="max-width: 900px;">
            <div class="modal-content">
                <asp:UpdatePanel runat="server">
                    <ContentTemplate>
                        <div class="modal-header">
                            <h5 class="modal-title" id="myLargeModalLabel">Preview </h5>
                        </div>
                        <div class="modal-body" style="padding-left: 15px; padding-right: 15px;">
                            <div class="row popRow" style="">
                                <embed runat="server" id="embed1" width="100%" height="500" alt="pdf" pluginspage="http://www.adobe.com/products/acrobat/readstep2.html" />
                                <%--<iframe src='https://view.officeapps.live.com/op/embed.aspx?src=E:/PrashantK/ESOP/esop_21102020/ESOP/LetterConfig/doc.doc' width='80%' height='565px' frameborder='0'> </iframe>--%>
                                <%--<FTB:FreeTextBox ID="Richtextbox" runat="server">
                                </FTB:FreeTextBox>--%>
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

    <script src="Scripts/bootstrap.min.js"></script>
    <script src="assets/js/app.min.js"></script>
    <script src="assets/js/scripts.js"></script>

    <script type="text/javascript">
        function openModal(srcval) {
            document.getElementById('<%=embed1.ClientID%>').src = "";
            document.getElementById('<%=embed1.ClientID%>').src = srcval;
            $('#myModal1').modal('show');
        }
    </script>
    <script type="text/javascript">
        $(document).ready(function () {
            var ddlLetterTyp = document.getElementById('<%= DrpLetterTyp.ClientID %>');
            ddlLetterTyp.options[2].hidden = true;
            ddlLetterTyp.options[3].hidden = true;

            $('.singledatadiv').hide();
            $("input[name='customRadioInline3']").change(function () {
                var radioValue = $("input[name='customRadioInline3']:checked").val();
                console.log(radioValue);
                if (radioValue == "single") {
                    $('.all').show()
                    $('.singledatadiv').slideDown();
                    $('.multidatadiv').hide();

                    ddlLetterTyp.options[2].hidden = false;
                    ddlLetterTyp.options[3].hidden = false;
                }
                else {
                    $('.all').show()
                    $('.multidatadiv').slideDown();
                    $('.singledatadiv').hide();

                    ddlLetterTyp.options[2].hidden = true;
                    ddlLetterTyp.options[3].hidden = true;
                }
            });

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
        function showProgress1() {
            debugger;
            var updateProgress1 = $get("<%= UpdateProgress1.ClientID %>");
            updateProgress1.style.display = "block";
        }
    </script>
</asp:Content>
