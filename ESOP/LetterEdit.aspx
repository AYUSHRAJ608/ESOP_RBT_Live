<%@ Page Title="" Language="C#" MasterPageFile="~/ESOP.Master" AutoEventWireup="true" CodeBehind="LetterEdit.aspx.cs" Inherits="ESOP.LetterEdit" %>

<%@ Register Assembly="Microsoft.ReportViewer.WebForms, Version=12.0.0.0, Culture=neutral, PublicKeyToken=89845dcd8080cc91" Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>


<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <asp:ScriptManager ID="script" runat="server"></asp:ScriptManager>
    <style>
        .header1 {
            width: 100% !important;
            height: 65px;
            border: 2px dotted #808080f2;
            padding: 6px;
        }

        .delete2 {
            padding: 10px;
            background: #F20000; /*background: #e3001b;*/
            color: white !important;
            border-radius: 4px;
            line-height: 0;
            margin-left: -2px;
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



        .card .card-body, .card .card-footer, .card .card-header {
            /*background-color: transparent;*/
            padding: 15px 25px !important;
        }



        .remark {
            padding: 5px;
        }

        input[type="text"] {
            border: 1px solid #615a72;
            border-radius: 6px;
            padding-left: 8px;
            font-weight: 500;
            color: #3f646d;
            font-size: 14px;
            background: #f3f4f4;
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
            border: 1px solid #615a72;
            font-weight: 500;
            color: #3f646d;
            font-size: 14px;
            background: #f3f4f4;
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
            margin-left: 81%;
        }

        .offset-md-10 {
            margin-left: 82%;
        }

        .section > :first-child {
            margin-top: -7px;
        }

        .btn {
            height: 34px;
        }

        .edit2 {
            padding: 10px;
            background: #2573ff;
            color: white !important;
            border-radius: 4px;
            line-height: 0;
            margin-left: -37px;
        }

        .over {
            margin-top: 7px;
        }

        .form-control:not(.form-control-sm):not(.form-control-lg), .input-group-text, select.form-control:not([size]):not([multiple]) {
            font-size: 14px;
            padding: 0px 10px;
            margin-left: -36px;
            width: 200px;
        }
    </style>

    <%-- <script type="text/javascript" src="https://ajax.googleapis.com/ajax/libs/jquery/1.8.3/jquery.min.js"></script>
    <link rel="stylesheet" href="//code.jquery.com/ui/1.12.1/themes/base/jquery-ui.css" />
    <script src="https://code.jquery.com/ui/1.12.1/jquery-ui.js"></script>--%>
    <script type="text/javascript">
        function Footer_ReqValidation() {
            var FileUploadFooter = document.getElementById('<%=FileUploadFooter.ClientID%>').value;

            if (FileUploadFooter.trim() == "") {
                alert("Select Footer Image!");
                document.getElementById('<%=FileUploadFooter.ClientID%>').focus();
                return false;
            }
            else {
                var ext = FileUploadFooter.substr(FileUploadFooter.lastIndexOf('.') + 1).toLowerCase();
                if (ext == "jpeg" || ext == "jpg" || ext == "png") {
                    return true;
                }
                else {
                    alert("Invalid Footer image file, must select a *.jpeg, *.jpg, or *.png file.");
                    document.getElementById('<%=FileUploadFooter.ClientID%>').value = "";
                    document.getElementById('<%=FileUploadFooter.ClientID%>').focus();
                    return false;

                }
            }
        }

        function Header_ReqValidation() {
            var FileUploadHeader = document.getElementById('<%=FileUploadHeader.ClientID%>').value;

            if (FileUploadHeader.trim() == "") {
                alert("Select Header Image!");
                document.getElementById('<%=FileUploadHeader.ClientID%>').focus();
                return false;
            }
            else {
                var ext = FileUploadHeader.substr(FileUploadHeader.lastIndexOf('.') + 1).toLowerCase();
                if (ext == "jpeg" || ext == "jpg" || ext == "png") {
                    return true;
                }
                else {
                    alert("Invalid Header image file, must select a *.jpeg, *.jpg, or *.png file.");
                    document.getElementById('<%=FileUploadHeader.ClientID%>').value = "";
                    document.getElementById('<%=FileUploadHeader.ClientID%>').focus();
                    return false;

                }
            }
        }

        function Sign_ReqValidation() {
            var FileUploadSign = document.getElementById('<%=FileUploadSign.ClientID%>').value;

            if (FileUploadSign.trim() == "") {
                alert("Select Signature Image!");
                document.getElementById('<%=FileUploadSign.ClientID%>').focus();
                return false;
            }
            else {
                var ext = FileUploadSign.substr(FileUploadSign.lastIndexOf('.') + 1).toLowerCase();
                if (ext == "jpeg" || ext == "jpg" || ext == "png") {
                    return true;
                }
                else {
                    alert("Invalid Signature image file, must select a *.jpeg, *.jpg, or *.png file.");
                    document.getElementById('<%=FileUploadSign.ClientID%>').value = "";
                    document.getElementById('<%=FileUploadSign.ClientID%>').focus();
                    return false;

                }
            }
        }

        function Design_ReqValidation() {
            var FileUploadDesignation = document.getElementById('<%=FileUploadDesignation.ClientID%>').value;

            if (FileUploadDesignation.trim() == "") {
                alert("Select Designation Image!");
                document.getElementById('<%=FileUploadDesignation.ClientID%>').focus();
                return false;
            }
            else {
                var ext = FileUploadDesignation.substr(FileUploadDesignation.lastIndexOf('.') + 1).toLowerCase();
                if (ext == "jpeg" || ext == "jpg" || ext == "png") {
                    return true;
                }
                else {
                    alert("Invalid Designation image file, must select a *.jpeg, *.jpg, or *.png file.");
                    document.getElementById('<%=FileUploadDesignation.ClientID%>').value = "";
                    document.getElementById('<%=FileUploadDesignation.ClientID%>').focus();
                    return false;
                }
            }
        }

    </script>

<%--    <script type="text/javascript" src="https://ajax.googleapis.com/ajax/libs/jquery/1.8.3/jquery.min.js"></script>
    <link rel="stylesheet" href="//code.jquery.com/ui/1.12.1/themes/base/jquery-ui.css" />
    <script src="https://code.jquery.com/jquery-1.12.4.js"></script>
    <script src="https://code.jquery.com/ui/1.12.1/jquery-ui.js"></script>--%>
    <script src="assets/js/jquery-1.8.3.min.js" type="text/javascript"></script>
    <link href="assets/css/jquery-ui-1.12.1.css" rel="stylesheet" />
    <script src="assets/js/jquery-1.12.4.js" type="text/javascript"></script>
    <script src="assets/js/jquery-ui-1.12.1.js" type="text/javascript"></script>
    <script type="text/javascript">
        $(function () {
            $.noConflict();
            debugger;
            $("#ContentPlaceHolder1_TxtLetterDate").datepicker(
            {
                changeMonth: true,
                changeYear: true,
                dateFormat: 'dd-mm-yy'
            });
        });
    </script>

    <div class="main-content">
        <nav aria-label="breadcrumb" class="offset-md-10">
            <ol class="breadcrumb">
                <li class="breadcrumb-item"><a href="admin_dashboard.aspx">Home</a></li>
                <li class="breadcrumb-item active" aria-current="page">Edit Letter</li>
            </ol>
        </nav>
        <section class="section">
            <div class="section-body">
                <div class="invoice">
                    <div class="invoice-print">
                        <div class="row">
                            <div class="col-lg-12">
                                <asp:UpdatePanel ID="UPabove" runat="server">
                                    <ContentTemplate>
                                        <div class="row">
                                            <div class="col-md-4">
                                                <strong>Header:</strong>
                                                <div class="buttons">
                                                    <table>
                                                        <tr>
                                                            <td>
                                                                <asp:FileUpload ID="FileUploadHeader" runat="server" /></td>
                                                            <td>
                                                                <asp:LinkButton ID="LnkHeaderEdit" runat="server" OnClick="LnkHeaderEdit_Click" OnClientClick="return Header_ReqValidation();" CssClass="fas fa-pencil-alt edit2"></asp:LinkButton>
                                                            </td>
                                                            <td>
                                                                <asp:LinkButton ID="LnkHeaderDelete" runat="server" CssClass="fas fa-trash-alt delete2" OnClick="LnkHeaderDelete_Click"  OnClientClick="return confirm('Are you sure you want to Delete Image?');"></asp:LinkButton>
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </div>
                                                <div class="over">
                                                    <asp:Image runat="server" ID="ImgHeader" class="header1" alt="image"></asp:Image>
                                                </div>
                                            </div>
                                            <div class="col-md-4">
                                                <strong>Footer:</strong>
                                                <div class="buttons">
                                                    <table>
                                                        <tr>
                                                            <td>
                                                                <asp:FileUpload ID="FileUploadFooter" runat="server" /></td>
                                                            <td>
                                                                <asp:LinkButton ID="LnkFooterEdit" runat="server" CssClass="fas fa-pencil-alt edit2" OnClick="LnkFooterEdit_Click" OnClientClick="return Footer_ReqValidation();"></asp:LinkButton>
                                                                <asp:LinkButton ID="LnkFooterDelete" runat="server" CssClass="fas fa-trash-alt delete2" OnClick="LnkFooterDelete_Click"  OnClientClick="return confirm('Are you sure you want to Delete Image?');"></asp:LinkButton>
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </div>
                                                <div class="over">
                                                    <asp:Image runat="server" ID="ImgFooter" class="header1" alt="image"></asp:Image>
                                                </div>
                                            </div>
                                            <div class="col-md-4">
                                                <strong>Singnature:</strong>
                                                <div class="buttons">
                                                    <table>
                                                        <tr>
                                                            <td>
                                                                <asp:FileUpload ID="FileUploadSign" runat="server" />
                                                            </td>
                                                            <td>
                                                                <asp:LinkButton ID="LnkSignEdit" runat="server" CssClass="fas fa-pencil-alt edit2" OnClick="LnkSignEdit_Click" OnClientClick="return Sign_ReqValidation();"></asp:LinkButton>
                                                                <asp:LinkButton ID="LnkSignDelete" runat="server" CssClass="fas fa-trash-alt delete2" OnClick="LnkSignDelete_Click"  OnClientClick="return confirm('Are you sure you want to Delete Image?');"></asp:LinkButton>
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </div>
                                                <div class="over">
                                                    <asp:Image runat="server" ID="ImgSign" class="header1" alt="image"></asp:Image>
                                                </div>
                                            </div>
                                            <div class="buttons offset-md-5 mt-4">
                                                <asp:Button runat="server" ID="BtnPreview" class="btn btn-outline-primary" Text="Preview" OnClick="BtnPreviewBelow_Click" />
                                                <asp:Button runat="server" ID="Btnupdate" Text="Update" class="btn btn-outline-success" OnClick="Btnupdate_Click" />
                                            </div>
                                        </div>
                                    </ContentTemplate>
                                    <Triggers>
                                        <asp:PostBackTrigger ControlID="BtnPreview"/>
                                        <asp:AsyncPostBackTrigger ControlID="Btnupdate" EventName="Click" />
                                        <asp:AsyncPostBackTrigger ControlID="LnkHeaderDelete" EventName="Click" />
                                        <asp:AsyncPostBackTrigger ControlID="LnkFooterDelete" EventName="Click" />
                                        <asp:AsyncPostBackTrigger ControlID="LnkSignDelete" EventName="Click" />
                                        <asp:PostBackTrigger ControlID="LnkHeaderEdit" />
                                        <asp:PostBackTrigger ControlID="LnkFooterEdit" />
                                        <asp:PostBackTrigger ControlID="LnkSignEdit" />
                                    </Triggers>
                                </asp:UpdatePanel>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </section>
        <section class="section">
            <div class="section-body">
                <div class="invoice">
                    <div class="invoice-print">
                        <div class="row">
                            <div class="col-lg-12">
                                <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                                    <ContentTemplate>
                                        <div class="row">
                                            <div class="col-md-6">
                                                <strong>Signatory:</strong>
                                                <div class="buttons">
                                                    <div class="row" style="margin-top: -20px; margin-bottom: 10px;">
                                                        <div class="col-md-4 offset-md-3">
                                                            <%--  <input type="text" class="form-control" placeholder="Name--%>
                                                            <asp:FileUpload ID="FileUploadDesignation" runat="server" Style="margin-left: 86px;" />
                                                        </div>
                                                        <div class="col-md-4">
                                                            <%--<input type="text" class="form-control" placeholder="Designation">--%>
                                                        </div>
                                                        <div class="col-md-1">
                                                            <asp:LinkButton ID="LnkDesign" runat="server" CssClass="fas fa-pencil-alt edit2" OnClick="LnkDesign_Click" OnClientClick="return Design_ReqValidation();" Style="margin-left: -7px"></asp:LinkButton>
                                                        </div>
                                                    </div>
                                                    <div class="over">
                                                        <asp:Image runat="server" ID="ImgDesgn" class="header1" alt="image" Style="height: 70px;"></asp:Image>
                                                    </div>
                                                </div>
                                            </div>
                                            <div class="col-md-6">
                                                <strong>Content:</strong>
                                                <div class="buttons">
                                                    <div class="row" style="margin-top: 10px;">
                                                        <div class="col-md-4">
                                                            <div class="form-group" style="margin-top: 14px;">
                                                                <%--   <select class="form-control">
                                                            <option value="">Select</option>
                                                            <option value="1">Emp Code</option>
                                                            <option value="2">Today Date</option>
                                                            <option value="3">Emp Name</option>
                                                            <option value="4">Title</option>
                                                            <option value="4">Band</option>
                                                            <option value="4">Designation</option>
                                                            <option value="4">Location</option>
                                                            <option value="4">Department</option>
                                                            <option value="4">Function</option>
                                                            <option value="4">Cost Center</option>
                                                        </select>--%>
                                                                <strong>Select Letter Date:</strong>
                                                            </div>
                                                        </div>
                                                        <div class="over col-md-8">
                                                            <div id="sample" class="col-md-12" style="text-align: right">
                                                                <asp:TextBox ID="TxtLetterDate" runat="server" class="form-control"></asp:TextBox>
                                                                <%--  <textarea class="form-control text-left" name="area2" id="myArea3" style="width: 100%;">The following demo applies a red border to elements that match :read-only, and applies a green border to elements that match :read-write. Elements that don’t match either of the two pseudo-class selectors have a gray border. The result may differ depending on the browser you’re using. See the Browser Support section below for details.</textarea>--%>
                                                            </div>
                                                        </div>

                                                    </div>

                                                </div>
                                            </div>
                                            <div class="buttons offset-md-5 mt-4">
                                                <asp:Button runat="server" ID="BtnPreviewBelow" class="btn btn-outline-primary" Text="Preview" OnClick="BtnPreviewBelow_Click" />
                                                <asp:Button runat="server" ID="BtnUpdateBelow" Text="Update" class="btn btn-outline-success" OnClick="BtnUpdateBelow_Click" />
                                            </div>
                                        </div>
                                    </ContentTemplate>
                                    <Triggers>
                                        <asp:PostBackTrigger ControlID="BtnPreviewBelow" />
                                        <asp:AsyncPostBackTrigger ControlID="BtnUpdateBelow" EventName="Click" />
                                        <asp:PostBackTrigger ControlID="LnkDesign" />
                                    </Triggers>
                                </asp:UpdatePanel>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </section>
    </div>
    <footer class="main-footer">
    </footer>

    <div class="modal fade bd-example-modal-lg" id="ModelPreview" tabindex="-1" role="dialog" aria-labelledby="myLargeModalLabel" aria-hidden="true" style="display: none;">
        <div class="modal-dialog modal-lg">
            <div class="modal-content">
                <div class="modal-header">
                    <h5 class="modal-title" id="myLargeModalLabel">Confirmation Letter</h5>
                    <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                        <span aria-hidden="true">×</span>
                    </button>
                </div>
                <div class="modal-body">
                    <div>
                        <rsweb:ReportViewer ID="RptLetter" runat="server" Width="100%"></rsweb:ReportViewer>
                    </div>
                </div>
            </div>
        </div>
    </div>

    <script type="text/javascript">
        function openModal() {
            $('#ModelPreview').modal('show');
        }

    </script>

    <!-- General JS Scripts -->
    <script src="assets/js/app.min.js"></script>
    <script src="assets/bundles/ckeditor/ckeditor.js"></script>
    <!-- JS Libraies -->
    <!-- Page Specific JS File -->
    <!-- Template JS File -->
    <script src="assets/js/scripts.js"></script>
    <script src="assets/bundles/jquery.sparkline.min.js"></script>
    <script type="text/javascript" src="https://www.jqueryscript.net/demo/Drag-And-Drop-File-Uploader-With-Preview-Imageuploadify/dist/imageuploadify.min.js"></script>
    <script src="http://js.nicedit.com/nicEdit-latest.js" type="text/javascript"></script>
    <script type="text/javascript">
        area3 = new nicEditor({ fullPanel: true }).panelInstance('myArea3');
        bkLib.onDomLoaded(function () { toggleArea1(); });
    </script>

    <script type="text/javascript">
        $(document).ready(function () {
            $('input[type="file"]').imageuploadify();
            $('#tablediv').hide();
            $('#btnimport').click(function () {
                $('#tablediv').slideToggle();
                $('html, body').animate({
                    scrollTop: $("#tablediv").offset().top
                }, 2000);

            });
        })
    </script>
    <script>
        function changeProfile() {
            $('#FileuploadImg1').click();
            $('#image1').click();
        }

        $(document).ready(function () {
            $('#FileuploadImg1').change(function () {
                debugger;
                var imgPath = this.value;
                var ext = imgPath.substring(imgPath.lastIndexOf('.') + 1).toLowerCase();
                if (ext == "gif" || ext == "png" || ext == "jpg" || ext == "jpeg")
                    readURL(this);
                else
                    alert("Please select image file (jpg, jpeg, png).")
            });
        });

        $('#image1').change(function () {
            var imgPath = this.value;
            var ext = imgPath.substring(imgPath.lastIndexOf('.') + 1).toLowerCase();
            if (ext == "gif" || ext == "png" || ext == "jpg" || ext == "jpeg")
                readURL1(this);
            else
                alert("Please select image file (jpg, jpeg, png).")
        });

        function readURL(input) {
            if (input.files && input.files[0]) {
                var reader = new FileReader();
                reader.readAsDataURL(input.files[0]);
                reader.onload = function (e) {
                    $('#image').attr('src', e.target.result);
                    $("#remove").val(0);
                };
            }
        }

        function readURL1(input) {
            if (input.files && input.files[0]) {
                var reader = new FileReader();
                reader.readAsDataURL(input.files[0]);
                reader.onload = function (e) {
                    $('#preview1').attr('src', e.target.result);
                    $("#remove1").val(0);
                };
            }
        }
        function removeImage() {
            $('#preview').attr('src', 'assets/images/header.PNG');
            $("#remove").val(1);
            $('#preview1').attr('src', 'assets/images/footer.PNG');
            $("#remove1").val(1);
        }
    </script>
</asp:Content>
