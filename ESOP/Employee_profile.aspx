<%@ Page Title="" Language="C#" MasterPageFile="~/ESOP.Master" AutoEventWireup="true" CodeBehind="Employee_profile.aspx.cs" Inherits="ESOP.Employee_profile" EnableEventValidation="false" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ScriptManager ID="script" runat="server"></asp:ScriptManager>
    <!-- General CSS Files -->
    <link rel="stylesheet" href="assets/css/app.min.css" />
    <!-- Template CSS -->
    <link rel="stylesheet" href="assets/css/style.css" />
    <link rel="stylesheet" href="assets/css/components.css" />
    <link rel="stylesheet" href="assets/bundles/bootstrap-social/bootstrap-social.css" />
    <link rel="stylesheet" href="assets/bundles/flag-icon-css/css/flag-icon.min.css" />
    <link rel="stylesheet" href="assets/css/custom.css" />
    <!-- Custom style CSS -->
    <link rel='shortcut icon' type='image/x-icon' href='assets/img/favicon.ico' />

    <style>
        .letterview {
            margin-left: -104%;
            margin-top: 77px;
        }

        .section > :first-child {
            margin-top: 53px !important;
        }

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
            margin-top: 3.6rem !important;
        }

        h3 {
            font-weight: 600;
        }




        .accordion .fa {
            margin-right: 0.5rem;
            font-size: 24px;
            font-weight: bold;
            position: relative;
            vertical-align: text-bottom;
            top: 2px;
        }

        .bs-example {
            width: 100%;
        }

        .card .card-headertest {
            border: 0;
            padding: 3px !important;
            background: #eff1f1;
            margin: 0 0 5px 0;
            border-radius: 5px;
        }

        .card .card-header .btn {
            margin-top: 0px;
            padding: 2px 15px;
            display: inline-block;
            vertical-align: top;
        }

        .btn:not(.btn-social):not(.btn-social-icon):active, .btn:not(.btn-social):not(.btn-social-icon):focus, .btn:not(.btn-social):not(.btn-social-icon):hover {
            border-color: transparent !important;
            background-color: #eff1f1;
        }

        .card .card-header .btn {
            margin-top: 0px;
            padding: 2px 15px;
            display: inline-block;
            vertical-align: middle;
            font-size: 15px;
            font-weight: 700;
            margin: -13px 0 0 0;
            color: #2600ff;
            text-decoration: none;
            outline: 0px;
        }


        input.form-control.userInput1 {
            background-color: #fff !important;
        }


        .letterview {
            background-color: #ffffff;
            text-align: center;
            border: 0px solid #eee;
            -moz-box-shadow: 0 0 15px rgba(0, 0, 0, 0.188235);
            -webkit-box-shadow: 0 0 15px rgba(0, 0, 0, 0.188235);
            box-shadow: 2px 2px 15px rgb(0 0 0 / 43%);
            -moz-border-radius: 6px;
            -webkit-border-radius: 6px;
            border-radius: 6px;
            margin-bottom: 15px;
        }

        figure.snip0013 {
            position: relative;
            overflow: hidden;
            /* margin: 10px; */
            width: 100%;
            padding: 4px 2px 0px;
            background: #fff;
            text-align: center;
            border-radius: 8px;
        }

        figure.snip0014 {
            position: relative;
            overflow: hidden;
            /* margin: 10px; */
            width: 100%;
            padding: 0px 2px 0px;
            background: #fff;
            text-align: center;
            border-radius: 8px;
        }

        .letterview p {
            margin: 3px 0 0;
            font-size: 10px;
            font-weight: 500;
            letter-spacing: 0.3px;
            color: dimgray;
            text-align: left;
        }

        figure.snip0013 img {
            max-width: 100%;
            opacity: 1;
            -webkit-transition: opacity 0.35s;
            transition: opacity 0.35s;
        }

        figure.snip0014 img {
            max-width: 100%;
            opacity: 1;
            -webkit-transition: opacity 0.35s;
            transition: opacity 0.35s;
        }

        .letterview p i {
            font-size: 12px;
            vertical-align: middle;
            margin-right: 3px;
            color: #ffffff;
            background: #078ca9;
            padding: 6px 6px;
            border-radius: 5px 0 0 0;
            position: absolute;
            bottom: -1px;
            right: -3px;
        }

        figure.snip0013:hover {
            background: #1fa2c02b !important;
        }


        figure.snip0014:hover {
            background: #1fa2c02b !important;
        }


        .btn:focus, .btn:hover, .btn:active {
            box-shadow: none !important;
            text-decoration: none;
            outline: 0px;
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
            background-color: #2196F3;
        }

        input:focus + .slider {
            box-shadow: 0 0 1px #2196F3;
        }

        input:checked + .slider:before {
            -webkit-transform: translateX(46px);
            -ms-transform: translateX(46px);
            transform: translateX(46px);
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



        .form-control:not(.form-control-sm):not(.form-control-lg), .input-group-text, select.form-control:not([size]):not([multiple]) {
            font-size: 14px;
            padding: 0px !important;
            height: 42px;
            line-height: 1.3;
        }

        figure.snip0013 img {
            height: 70px !important;
            width: 85px !important;
        }

        figure.snip0014 img {
            height: 70px !important;
            width: 85px !important;
        }

        .h6, h6 {
            font-size: 0.6rem;
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
    </style>



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
                alert("Select security name.");
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

    <script type="text/javascript">
        function ReqValidation3() {
           <%-- var email = document.getElementById('<%=txtemailid.ClientID%>').value;
            var filter = /^([a-zA-Z0-9_\.\-])+\@(([a-zA-Z0-9\-])+\.)+([a-zA-Z0-9]{2,4})+$/;

            var x = email;
            var atposition = x.indexOf("@");
            var dotposition = x.lastIndexOf(".");
            if (atposition < 1 || dotposition < atposition + 2 || dotposition + 2 >= x.length) {
                alert("Please enter a valid e-mail addres");
                return false;
            }--%>
        }

        function characterOnly(e) {
            isIE = document.all ? 1 : 0
            keyEntry = !isIE ? e.which : event.keyCode;
            if (((keyEntry >= '65') && (keyEntry <= '90')) || ((keyEntry >= '97') && (keyEntry <= '122')) || (keyEntry == '46') || (keyEntry == '32') || keyEntry == '45')
                return true;
            else {
                return false;
            }
        }

        function IsAlphaNumeric(e) {
            var k;
            document.all ? k = e.keyCode : k = e.which;
            return ((k > 64 && k < 91) || (k > 96 && k < 123) || k == 8 || k == 32 || (k >= 48 && k <= 57));
        }

        function isNumberKey(evt) {
            var charCode = (evt.which) ? evt.which : evt.keyCode;
            if (charCode > 31 && (charCode < 48 || charCode > 57))
                return false;
            return true;
        }
    </script>


    <!-- Main Content -->
    <asp:HiddenField ID="hdfield1" runat="server" />
    <asp:HiddenField ID="hdfield2" runat="server" />
    <asp:HiddenField ID="hdfield3" runat="server" />

    <div class="main-content">
        <section class="section">
            <div class="row">
                <div class="col-lg-12 col-md-12 col-12 col-sm-12">
                    <div class="card">
                        <div class="card-header">
                            <h4>My Profile</h4>
                        </div>
                        <div id="showmsg" runat="server"></div>
                        <div class="card-body">
                            <div class="row">
                                <div class="bs-example">
                                    <div class="accordion" id="accordionExample">
                                        <div class="">
                                            <div class="card-header card-headertest" id="headingOne">
                                                <h2 class="mb-0">
                                                    <button type="button" class="btn btn-link collapsed" data-toggle="collapse" data-target="#collapseOne"><i class="fa fa-angle-right"></i>Profile Details</button>
                                                </h2>
                                            </div>

                                            <!-- New Add -->

                                           <div id="collapseOne" class="collapse show" aria-labelledby="headingOne" data-parent="#accordionExample">
                                                <div class="panel-body">
                                                    <div class="form-row">
                                                        <div class="col-sm-3 form-group">
                                                            <label>Name</label>
                                                            <div>
                                                                <asp:TextBox ID="txtempname" runat="server" CssClass="form-control userInput" ReadOnly="true" Width="86%"></asp:TextBox>
                                                            </div>
                                                        </div>
                                                        <div class="col-sm-3 form-group">
                                                            <label>Date of Joining</label>
                                                            <div>
                                                                <asp:TextBox ID="txtdoj" runat="server" CssClass="form-control userInput" ReadOnly="true" Width="86%"></asp:TextBox>
                                                            </div>
                                                        </div>
                                                        <div class="col-sm-3 form-group">
                                                            <label>Designation</label>
                                                            <div>
                                                                <asp:DropDownList CssClass="form-control" ID="ddldesignation" runat="server" readonly="true" Width="86%">
                                                                </asp:DropDownList>
                                                            </div>
                                                        </div>
                                                        <div class="col-sm-3 form-group">
                                                            <label>Location</label>
                                                            <div>
                                                                <asp:TextBox ID="txtlocation" runat="server" CssClass="form-control userInput" ReadOnly="true" Width="86%"></asp:TextBox>
                                                            </div>
                                                        </div>
                                                    </div>
                                                    <div class="form-row">
                                                        <div class="col-sm-3 form-group">
                                                            <label>Employee Status</label>
                                                            <div>
                                                                <asp:DropDownList CssClass="form-control" ID="ddlempstatus" runat="server" ReadOnly="true" Width="86%">
                                                                    <asp:ListItem Value="0">Select</asp:ListItem>
                                                                    <asp:ListItem Value="1">Active</asp:ListItem>
                                                                    <asp:ListItem Value="2">Serving Notice</asp:ListItem>
                                                                    <asp:ListItem Value="3">Inactive</asp:ListItem>
                                                                    <asp:ListItem Value="4">Retired</asp:ListItem>
                                                                    <asp:ListItem Value="5">Deputed</asp:ListItem>
                                                                </asp:DropDownList>
                                                            </div>
                                                        </div>
                                                        <div class="col-sm-3 form-group">
                                                            <label>Band</label>
                                                            <div>
                                                                <asp:DropDownList CssClass="form-control" ID="ddlband" runat="server" ReadOnly="true" Width="86%">
                                                                </asp:DropDownList>
                                                            </div>
                                                        </div>
                                                        <div class="col-sm-3 form-group">
                                                            <label>Personal Email ID</label>
                                                            <div>
                                                                <asp:TextBox ID="txtemailid" runat="server" CssClass="form-control userInput" ReadOnly="true" Width="86%"></asp:TextBox>
                                                            </div>
                                                        </div>
                                                        <div class="col-sm-3 form-group">
                                                            <label>Manager Name</label>
                                                            <div>
                                                                <asp:TextBox ID="txtmanagername" runat="server" CssClass="form-control userInput" ReadOnly="true" Width="86%"></asp:TextBox>
                                                            </div>
                                                        </div>
                                                    </div>
                                                    <div class="form-row">
                                                        <div class="col-md-9" style="padding: 0px;">
                                                            <div class="row" style="padding: 0px;">
                                                                <div class="col-sm-4 form-group">
                                                                    <label>Pan Card Number</label>
                                                                    <div>
                                                                        <asp:TextBox ID="txtpanno" runat="server" CssClass="form-control userInput" ReadOnly="true" Width="86%"></asp:TextBox>

                                                                    </div>
                                                                </div>
                                                                <div class="col-sm-4 form-group">
                                                                    <div class="col-md-12 form-group" style="padding: 0px;">
                                                                        <label>Pan Card</label>
                                                                        <div>
                                                                            <cc1:AsyncFileUpload runat="server" ID="filepancard" UploaderStyle="Traditional" CompleteBackColor="White" Width="86%"
                                                                                UploadingBackColor="#CCFFFF" ThrobberID="imgLoader" OnUploadedComplete="filepancard_UploadedComplete" CssClass="form-control"
                                                                                ErrorBackColor="Transparent" OnClientUploadComplete="uploadComplete1" OnClientUploadStarted="uploadStart1"></cc1:AsyncFileUpload>
                                                                        </div>
                                                                    </div>
                                                                    <div class="col-md-12" id="DivPanCard" runat="server" style="padding: 0px; margin-top: 10px;">
                                                                        <div style="background: #fff; border-radius: 5px; padding: 5px; height: 122px; width: 120px; border: 1px solid #d1d1d1;">
                                                                            <figure class="snip0014">
                                                                                <img id="imgDisplay1" alt="No Image Found" />
                                                                                <a href="#" dowmload>
                                                                                    <asp:UpdatePanel ID="Updatepanel2" runat="server">
                                                                                        <ContentTemplate>
                                                                                            <asp:LinkButton ID="lnkpandownload" runat="server" Text="Download" OnClick="lnkpandownload_Click">
                                                                <p style="font-size:11px;"><i class="fas fa-download" style="float: right; padding-top: 7px;"></i>Pan Card</p>
                                                                                            </asp:LinkButton>
                                                                                        </ContentTemplate>
                                                                                        <Triggers>
                                                                                            <asp:PostBackTrigger ControlID="lnkpandownload" />
                                                                                        </Triggers>
                                                                                    </asp:UpdatePanel>
                                                                                </a>
                                                                            </figure>
                                                                        </div>
                                                                    </div>
                                                                </div>
                                                                <div class="col-sm-4 form-group">
                                                                    <div class="col-md-12 form-group" style="padding: 0px;">
                                                                        <label>Profile</label>
                                                                        <div>
                                                                            <cc1:AsyncFileUpload runat="server" ID="fileempprofileimg" Width="86%" UploaderStyle="Traditional" CompleteBackColor="White"
                                                                                UploadingBackColor="#CCFFFF" ThrobberID="imgLoader" OnUploadedComplete="fileempprofileimg_UploadedComplete" CssClass="form-control"
                                                                                OnClientUploadComplete="uploadComplete" OnClientUploadStarted="uploadStart"
                                                                                ErrorBackColor="Transparent"></cc1:AsyncFileUpload>
                                                                        </div>
                                                                    </div>
                                                                    <div class="col-md-12" id="DivProfilPic" runat="server" style="padding: 0px; margin-top: 10px;">
                                                                       <div style="background: #fff; border-radius: 5px; padding: 5px; height: 122px; width: 120px; border: 1px solid #d1d1d1;">
                                                                            <figure class="snip0014" id="snip0014">
                                                                                <img src="" id="imgDisplay" alt="No Image Found" />
                                                                                <a href="#" dowmload>
                                                                                    <asp:UpdatePanel ID="Updatepanel21" runat="server">
                                                                                        <ContentTemplate>
                                                                                            <asp:LinkButton ID="lnkprofileDownload" runat="server" Text="Download" OnClick="lnkprofileDownload_Click">
                                                                <p style="font-size:11px;">
                                                                        <i class="fas fa-download" style="float: right; padding-top: 7px;"></i>Profile Picture

                                                                </p>
                                                                                            </asp:LinkButton>
                                                                                        </ContentTemplate>
                                                                                        <Triggers>
                                                                                            <asp:PostBackTrigger ControlID="lnkprofileDownload" />
                                                                                        </Triggers>
                                                                                    </asp:UpdatePanel>
                                                                                </a>
                                                                            </figure>
                                                                        </div>
                                                                    </div>
                                                                </div>
                                                            </div>
                                                        </div>
                                                        <div class="col-md-3" style="padding: 0px;">
                                                            <div class="col-sm-3 form-group">
                                                                <label>&nbsp;</label>
                                                                <div>
                                                                    <asp:UpdatePanel ID="Updatepanel3" runat="server">
                                                                        <ContentTemplate>
                                                                            <asp:Button ID="saveempdetails" OnClick="saveempdetails_Click" Text="Save"
                                                                                runat="server" CssClass="btn btn-info btn-lg" OnClientClick="return ReqValidation3()"></asp:Button>
                                                                        </ContentTemplate>
                                                                        <Triggers>
                                                                            <asp:PostBackTrigger ControlID="saveempdetails" />
                                                                        </Triggers>
                                                                    </asp:UpdatePanel>
                                                                </div>
                                                            </div>
                                                        </div>
                                                    </div>
                                                </div>
                                            </div>



                                            <!-- New Add -->

                                        </div>
                                        <div class="">
                                            <div class="card-header card-headertest" id="headingTwo">
                                                <h2 class="mb-0">
                                                    <button type="button" class="btn btn-link" data-toggle="collapse" data-target="#collapseTwo"><i class="fa fa-angle-right"></i>Bank Details</button>
                                                </h2>
                                            </div>

                                            <div id="collapseTwo" class="collapse" aria-labelledby="headingTwo" data-parent="#accordionExample">
                                                <div class="card-body">
                                                    <div class="row">
                                                        <div class="col-lg-3 col-md-12 col-sm-12">
                                                            <div class="form-group">
                                                                <label>Bank Name<span style="color: red">*</span></label>
                                                                <div class="input-group mb-3">
                                                                    <%-- <select class="form-control">
                                                                        <option>Select</option>
                                                                        <option value="NSDL">HDFC Bank</option>
                                                                        <option value="CDSL">RBL Bank</option>
                                                                    </select>--%>
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
                                                        <%-- <asp:UpdatePanel ID="UpdatePanel4" runat="server">

                                                            <ContentTemplate>--%>
                                                        <asp:Button ID="save_bankdetail" OnClick="save_bankdetail_Click" Text="Save"
                                                            runat="server" CssClass="btn btn-info btn-lg" OnClientClick="return ReqValidation()"></asp:Button>
                                                        <%--      </ContentTemplate>
                                                            <Triggers>
                                                             <asp:AsyncPostBackTrigger ControlID="grdbankdetail" />

                                                            </Triggers>
                                                        </asp:UpdatePanel>--%>
                                                    </div>

                                                    <div class="card" style="height: auto; margin-bottom: 0;">
                                                        <div class="card-header">
                                                            <h4>Record Summary</h4>
                                                        </div>
                                                        <div class="card-body">
                                                            <div class="table-responsive">
                                                                <asp:UpdatePanel ID="upd" runat="server" UpdateMode="Conditional">

                                                                    <ContentTemplate>
                                                                        <asp:GridView ID="grdbankdetail" runat="server" ShowHeaderWhenEmpty="false" OnPreRender="grdbankdetail_PreRender"
                                                                            EmptyDataText="No Records Found" AutoGenerateColumns="false" DataKeyNames="ID" EmptyDataRowStyle-HorizontalAlign="Center"
                                                                            CssClass="table table-bordered">
                                                                            <Columns>
                                                                                <asp:TemplateField HeaderText="Sr No">

                                                                                    <ItemTemplate>
                                                                                        <asp:Label ID="lblRowNumber" Text='<%# Container.DataItemIndex + 1 %>' runat="server" />
                                                                                        <asp:HiddenField ID="key" runat="server" Value='<%#Eval("ID") %>' />
                                                                                    </ItemTemplate>
                                                                                </asp:TemplateField>
                                                                                <asp:BoundField HeaderText="Bank Name" DataField="BANK_NAME" />
                                                                                <asp:BoundField HeaderText="Branch Name" DataField="BRANCH_NAME" />
                                                                                <asp:BoundField HeaderText="Account Number" DataField="ACC_NO" />
                                                                                <asp:BoundField HeaderText="IFSC Code" DataField="IFSC" />
                                                                                <%-- <asp:BoundField HeaderText="Cancelled Cheque" DataField="FILE_PATH" />--%>
                                                                                <asp:TemplateField HeaderText="Cancelled Cheque">

                                                                                    <ItemTemplate>
                                                                                        <asp:LinkButton ID="lnkDownload" runat="server" Style="color: #5e65ff" AutoPostBack="true"
                                                                                            CommandArgument='<%# Eval("FILE_PATH") %>' Enabled='<%# Eval("FILE_PATH").ToString() != "" ? true : false %>'
                                                                                            Text='<%# string.IsNullOrEmpty(Eval("FILE_PATH").ToString()) ? "File is not available" : "Download" %>' OnClick="lnkDownload_Click" />
                                                                                    </ItemTemplate>

                                                                                </asp:TemplateField>
                                                                                <asp:TemplateField HeaderText="Enable/Disable">

                                                                                    <ItemTemplate>

                                                                                        <label class="switch">
                                                                                            <asp:CheckBox runat="server" ID="chkOnOff"
                                                                                                Checked='<%# Convert.ToBoolean(Eval("ISACTIVE"))%>' />
                                                                                            <%--  <asp:CheckBox runat="server" ID="chkOnOff" OnCheckedChanged="chkOnOff_CheckedChanged"
                                                                                                AutoPostBack="true" Checked='<%# Convert.ToBoolean(Eval("ISACTIVE"))%>' />--%>
                                                                                            <%-- <asp:Label ID="txtenabledisable" runat="server" Text='<%# Eval("ISACTIVE") %>' ReadOnly="true"></asp:Label>--%>
                                                                                            <div class="slider round">
                                                                                                <!--ADDED HTML -->
                                                                                                <span class="on">ON</span><span class="off">OFF</span><!--END-->
                                                                                            </div>
                                                                                        </label>
                                                                                    </ItemTemplate>

                                                                                </asp:TemplateField>
                                                                            </Columns>
                                                                        </asp:GridView>
                                                                    </ContentTemplate>
                                                                    <Triggers>
                                                                        <%--    <asp:PostBackTrigger ControlID="grdbankdetail" />

                                                                        <%--  <asp:PostBackTrigger ControlID="lnkDownload" />--%>
                                                                        <%--<asp:PostBackTrigger ControlID="grdbankdetail" />--%>
                                                                    </Triggers>
                                                                </asp:UpdatePanel>
                                                            </div>
                                                        </div>
                                                        <asp:button id="BtnDownload" onclick="DownloadFile_Click" runat="server" visible="false" xmlns:asp="#unknown" />
                                                    </div>
                                                </div>
                                            </div>

                                        </div>
                                        <div class="">
                                            <div class="card-header card-headertest" id="headingThree">
                                                <h2 class="mb-0">
                                                    <button type="button" class="btn btn-link collapsed" data-toggle="collapse" data-target="#collapseThree"><i class="fa fa-angle-right"></i>DMAT Details</button>
                                                </h2>
                                            </div>
                                            <div id="collapseThree" class="collapse" aria-labelledby="headingThree" data-parent="#accordionExample">
                                                <div class="card-body">
                                                    <div class="row">
                                                        <div class="col-lg-3 col-md-12 col-sm-12">
                                                            <div class="form-group">
                                                                <%--Rename Securities to DP by Pallavi--%>
                                                                <label>DP Name<span style="color: red">*</span></label>
                                                                <%-- <div class="input-group mb-3">
                                                                    <select class="form-control">
                                                                        <option>Select</option>
                                                                        <option value="NSDL">HDFC Bank</option>
                                                                        <option value="CDSL">RBL Bank</option>
                                                                    </select>
                                                                </div>--%>
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
                                                        <asp:Button ID="savedmatdetail" OnClick="savedmatdetail_Click" Text="Save"
                                                            runat="server" CssClass="btn btn-info btn-lg" OnClientClick="return ReqValidation1()"></asp:Button>
                                                    </div>
                                                    <div class="card" style="height: auto; margin-bottom: 0;">
                                                        <div class="card-header">
                                                            <h4>Record Summary</h4>
                                                        </div>
                                                        <div class="card-body">
                                                            <div class="table-responsive">

                                                                <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional">

                                                                    <ContentTemplate>
                                                                        <asp:GridView ID="grdempdmatdetail" runat="server" ShowHeaderWhenEmpty="false" OnPreRender="grdempdmatdetail_PreRender"
                                                                            EmptyDataText="No Records Found" AutoGenerateColumns="false" DataKeyNames="ID" EmptyDataRowStyle-HorizontalAlign="Center"
                                                                            CssClass="table table-bordered">
                                                                            <Columns>
                                                                                <asp:TemplateField HeaderText="Sr No">

                                                                                    <ItemTemplate>
                                                                                        <asp:Label ID="lblRowNumber" Text='<%# Container.DataItemIndex + 1 %>' runat="server" />
                                                                                        <asp:HiddenField ID="Dematkey" runat="server" Value='<%#Eval("ID") %>' />
                                                                                    </ItemTemplate>
                                                                                </asp:TemplateField>
                                                                                <asp:BoundField HeaderText="Security Name" DataField="SECURITY_NAME" />
                                                                                <asp:BoundField HeaderText="Dp Id" DataField="DPID" />
                                                                                <asp:BoundField HeaderText="Client Id" DataField="CLIENT_ID" />
                                                                                <asp:BoundField HeaderText="Member Type" DataField="MEMBER_TYPE" />
                                                                                <%-- <asp:BoundField HeaderText="Cancelled Cheque" DataField="FILE_PATH" />--%>
                                                                                <asp:TemplateField HeaderText="Proof">

                                                                                    <ItemTemplate>
                                                                                        <asp:LinkButton ID="lnkDownload1" runat="server" Style="color: #5e65ff" CausesValidation="false" AutoPostBack="true"
                                                                                            CommandArgument='<%# Eval("FILE_PATH") %>' Enabled='<%# Eval("FILE_PATH").ToString() != "" ? true : false %>'
                                                                                            Text='<%# string.IsNullOrEmpty(Eval("FILE_PATH").ToString()) ? "File is not available" : "Download" %>' OnClick="lnkDownload1_Click" />
                                                                                    </ItemTemplate>




                                                                                </asp:TemplateField>
                                                                                <asp:TemplateField HeaderText="Enable/Disable">

                                                                                    <ItemTemplate>

                                                                                        <label class="switch">
                                                                                            <asp:CheckBox runat="server" ID="chkOnOff1" Checked='<%# Convert.ToBoolean(Eval("ISACTIVE"))%>' />
                                                                                            <%--  <asp:CheckBox runat="server" ID="chkOnOff1" OnCheckedChanged="chkOnOff1_CheckedChanged"
                                                                                                AutoPostBack="true" Checked='<%# Convert.ToBoolean(Eval("ISACTIVE"))%>' />--%>
                                                                                            <%-- <asp:Label ID="txtenabledisable" runat="server" Text='<%# Eval("ISACTIVE") %>' ReadOnly="true"></asp:Label>--%>
                                                                                            <div class="slider round">
                                                                                                <!--ADDED HTML -->
                                                                                                <span class="on">ON</span><span class="off">OFF</span><!--END-->
                                                                                            </div>
                                                                                        </label>
                                                                                    </ItemTemplate>

                                                                                </asp:TemplateField>
                                                                            </Columns>
                                                                        </asp:GridView>
                                                                    </ContentTemplate>
                                                                    <Triggers>

                                                                        <%--<asp:PostBackTrigger ControlID="grdempdmatdetail" />--%>
                                                                    </Triggers>
                                                                </asp:UpdatePanel>

                                                            </div>
                                                        </div>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                </div>


                                <div class="col-12 col-sm-12 col-lg-3">
                                </div>
                                <div class="col-12 col-sm-12 col-lg-3">
                                </div>
                                <div class="col-12 col-sm-12 col-lg-3">
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </section>
    </div>


    <script src="assets/js/jquery-1.8.3.min.js" type="text/javascript"></script>
    <script src="assets/js/jquery.dataTables-1.10.20.min.js" type="text/javascript"></script>
    <link href="Scripts/jquery.dataTables.min.css" rel="stylesheet" />
    <link href="Scripts/dataTables.bootstrap4.min.css" rel="stylesheet" />

    <script type="text/javascript">
        $(document).ready(function () {
            $('.CloseBtnNew').click(function () {
                $("#myModal").removeClass("show");
                $("#myModal").hide();
                $(".modal-backdrop").remove();
                $("body").removeClass("modal-open");
            });
        })
    </script>

    <script>
        function DownloadFile(filepath) {
            __doPostBack("<%= BtnDownload.UniqueID %>", filepath);
        }
    </script>

    <script>
        //$('#ContentPlaceHolder1_grdreject').clear().draw();
        var prm = Sys.WebForms.PageRequestManager.getInstance();
        prm.add_endRequest(function (sender, e) {
            //debugger;
            $('#ContentPlaceHolder1_grdbankdetail').dataTable({
                lengthMenu: [[-1, 5, 10], ["All", 5, 10]],
                bRetrieve: true, 'columnDefs': [{
                    'targets': [5, 6],
                    'orderable': false,
                }],
                bStateSave: true,
            });

        });
        $(function () {
            //debugger;
            $.noConflict();
            $('#ContentPlaceHolder1_grdbankdetail').DataTable({
                bLengthChange: true,
                lengthMenu: [[-1, 5, 10], ["All", 5, 10]],
                bFilter: true,
                'columnDefs': [{
                    'targets': [5, 6],
                    'orderable': false,
                }],
                bPaginate: true,

            });
        });
    </script>

    <%--Bank Details Checkbox--%>
    <script>
        $('#ContentPlaceHolder1_grdbankdetail input[type="checkbox"]').click(function () {
            //debugger;
            var BankID = $(this).closest("tr").find("input[type=hidden][id*=key]").val();
            var ISACTIVE = "";
            if (this.checked == true) {
                ISACTIVE = 1;
            }
            else {
                ISACTIVE = 0;
            }
            Ajzx(BankID, ISACTIVE);
        });


        function onSuccess(response) {
            if (response.d != "") {
                alert(response.d);
                location.reload();
            }
            return true;
        }

        function Ajzx(BankID, ISACTIVE) {
            $.ajax({
                type: "POST",
                url: "Employee_profile.aspx/Bank_Checked",
                data: "{'BankID': '" + BankID + "','IsActive': '" + ISACTIVE + "'}",
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: onSuccess,
                failure: function (response) {
                    alert(response.d);
                    return false;
                },
                error: function (msg)
                { alert(msg.responseText); }
            });
        }
    </script>
    <%--End Bank Details Checkbox--%>


    <%--Demat Details Checkbox--%>
    <script>
        $('#ContentPlaceHolder1_grdempdmatdetail input[type="checkbox"]').click(function () {
            //debugger;
            var DematID = $(this).closest("tr").find("input[type=hidden][id*=Dematkey]").val();
            var ISACTIVE = "";
            if (this.checked == true) {
                ISACTIVE = 1;
            }
            else {
                ISACTIVE = 0;
            }
            Ajzx2(DematID, ISACTIVE);
        });


        function onSuccess(response) {
            if (response.d != "") {
                alert(response.d);
                location.reload();
            }
            return true;
        }

        function Ajzx2(DematID, ISACTIVE) {
            $.ajax({
                type: "POST",
                url: "Employee_profile.aspx/Demat_Checked",
                data: "{'DematID': '" + DematID + "','IsActive': '" + ISACTIVE + "'}",
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: onSuccess,
                failure: function (response) {
                    alert(response.d);
                    return false;
                },
                error: function (msg)
                { alert(msg.responseText); }
            });
        }
    </script>
    <%--End Demat Details Checkbox--%>

    <script>
        //$('#ContentPlaceHolder1_grdreject').clear().draw();
        var prm = Sys.WebForms.PageRequestManager.getInstance();

        prm.add_endRequest(function (sender, e) {
            //debugger;
            $('#ContentPlaceHolder1_grdempdmatdetail').dataTable({
                lengthMenu: [[-1, 5, 10], ["All", 5, 10]],
                bRetrieve: true, 'columnDefs': [{
                    'targets': [5, 6],
                    'orderable': false,
                }],
                bStateSave: true
            });

        });
        $(function () {
            //debugger;    //$.noConflict();
            $('#ContentPlaceHolder1_grdempdmatdetail').DataTable({
                bLengthChange: true,
                lengthMenu: [[-1, 5, 10], ["All", 5, 10]],
                bFilter: true,
                'columnDefs': [{
                    'targets': [5, 6],
                    'orderable': false,
                }],
                bPaginate: true,

            });
        });


    </script>

    <script type="text/javascript">
        function displayimg(srcval, srcval2) {
            $("#imgDisplay").attr('src', srcval);
            $("#imgDisplay1").attr('src', srcval2);
        }
    </script>

    <script src="assets/js/app.min.js"></script>
    <script src="assets/js/scripts.js"></script>

    <%--<script>
        $('table tr.clickable').on('click', function () {
            if ($(this).children('td:first-child').children('i').hasClass('fa-plus')) {
                $(this).children('td:first-child').children('i').removeClass('fa-plus').addClass('fa-minus');
            } else {
                $(this).children('td:first-child').children('i').removeClass('fa-minus').addClass('fa-plus');
            }
        })
        $("#click-me").click(function () {
            $(".table .toggleDisplay").toggleClass("in");
        });

        $('#basic').simpleTreeTable({
            collapsed: true,

            expander: $('#expander'),
            collapser: $('#collapser')
        });

        $(document).ready(function () {
            $('#collapser').click();
            $('.simple-tree-table tr th:nth-child(4), .simple-tree-table tr th:nth-child(6), .simple-tree-table tr th:nth-child(8), .simple-tree-table tr th:nth-child(9), .simple-tree-table tr td:nth-child(4), .simple-tree-table tr td:nth-child(6), .simple-tree-table tr td:nth-child(8), .simple-tree-table tr td:nth-child(9)').addClass('toggleDisplay')
        })
    </script>

    <script>
        $(document).ready(function () {
            // Add down arrow icon for collapse element which is open by default
            $(".collapse.show").each(function () {
                $(this).prev(".card-header").find(".fa").addClass("fa-angle-down").removeClass("fa-angle-right");
            });

            // Toggle right and down arrow icon on show hide of collapse element
            $(".collapse").on('show.bs.collapse', function () {
                $(this).prev(".card-header").find(".fa").removeClass("fa-angle-right").addClass("fa-angle-down");
            }).on('hide.bs.collapse', function () {
                $(this).prev(".card-header").find(".fa").removeClass("fa-angle-down").addClass("fa-angle-right");
            });
        });
    </script>--%>


    <script type="text/javascript">
        function uploadComplete(sender, args) {
            //debugger;
            //var filename = args.get_fileName();
            //$get("imgDisplay12").src = "./EMP_BankDetail/" + filename;
            var imgDisplay = $get("imgDisplay");//


            //if (imgDisplay == null) { alert('no image found....'); return true; }
            imgDisplay.src = "images/loader.gif";
            imgDisplay.style.cssText = "";
            var img = new Image();
            img.onload = function () {
                imgDisplay.style.cssText = "height:100px;width:100px";
                imgDisplay.src = img.src;
            };
         <%--   //imgDisplay.src = "<%=ResolveUrl(hdfield1) %>" + args.get_fileName();--%>
            imgDisplay.src = $get("<%= hdfield1.ClientID %>").value;
            //imgDisplay.src = "./EMP_BankDetail/" + filename;

            $('[id*=DivProfilPic]').attr('style', 'Display: block');
        }



        function uploadStart() {
            //debugger;
            //$get("imgDisplay").style.display = "none";

            //var imgDisplay = $get("imgDisplay");
            //var filename = args.get_fileName();
            //var filext = filename.substring(filename.lastIndexOf(".") + 1);
            //if (filext == "jpg" || filext == "jpeg" ||
            //filext == "png" || filext == "gif") {
            //    return true;
            //}
            //else {
            //    var err = new Error();
            //    err.name = 'Image Format';
            //    err.message = 'Only .jpg, .gif, .png, .gif files';
            //    throw (err);
            //    return false;
            //}

            //$get("imgDisplay").style.display = "none";



            //var _validFileFlag;
            //function uploadStartNew(vfilePath) {
            //    var vFileName = vfilePath.split('\\').pop();
            //    var vFileExt = vfileName.split('.').pop();
            //    if (vFileExt.toUpperCase() == "JPEG" || vFileExt.toUpperCase() == "JPG") {
            //        _validFileFlag = true;
            //        alert('Valid file');
            //    }
            //    _validFileFlag = false;
            //}
        }

    </script>
    <script>
        function uploadComplete1(sender, args) {
            //debugger;
            var imgDisplay1 = $get("imgDisplay1");//
            //if (imgDisplay1 == null) { alert('no image found....'); return true; }
            imgDisplay1.src = "images/loader.gif";
            imgDisplay1.style.cssText = "";
            var img = new Image();
            img.onload = function () {
                imgDisplay1.style.cssText = "height:100px;width:100px";
                imgDisplay1.src = img.src;
            };
                <%--   //imgDisplay.src = "<%=ResolveUrl(hdfield1) %>" + args.get_fileName();--%>
            imgDisplay1.src = $get("<%= hdfield2.ClientID %>").value;

            $('[id*=DivPanCard]').attr('style', 'Display: block');
        }

        function uploadStart1() {
        }


    </script>
</asp:Content>
