<%@ Page Title="" Language="C#" MasterPageFile="~/ESOP.Master" AutoEventWireup="true" CodeBehind="LetterEdit1.aspx.cs" Inherits="ESOP.LetterEdit1" ValidateRequest="false" %>

<%@ Register Assembly="Microsoft.ReportViewer.WebForms, Version=12.0.0.0, Culture=neutral, PublicKeyToken=89845dcd8080cc91" Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>
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
        .nicEdit-main {
            width: 514px;
            margin: 0px;
            overflow: hidden;
            padding: 8px;
            height: 50px;
            font-size: 13px;
        }

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
            margin-left: 76%;
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
        }

        .over {
            margin-top: 7px;
        }

        .form-control:not(.form-control-sm):not(.form-control-lg), .input-group-text, select.form-control:not([size]):not([multiple]) {
            font-size: 14px;
            padding: 0px 10px;
        }

        .padd {
            padding: 0 15px !important;
        }

        .invoice {
            background-color: #fff;
            border-radius: 6px;
            border: 1px solid #e5e9f2;
            position: relative;
            margin-bottom: 30px;
            box-shadow: 0 0.25rem 0.5rem rgb(0 0 0 / 3%);
            padding: 15px;
        }

            .invoice .tablediv {
                width: 100%;
            }

                .invoice .tablediv td:nth-child(2) {
                    text-align: right;
                }

            .invoice strong {
                font-size: 17px;
                font-weight: 500;
                margin-bottom: 16px;
                display: block;
            }


        .col-md-6, .col-md-12 {
            padding-left: 15px !important;
            padding-right: 15px !important;
        }

        .col-md-3 {
            padding-right: 0px;
            padding-left: 17px;
        }
    </style>

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
                    var updateProgress2 = $get("<%= UpdateProgress2.ClientID %>");
                    updateProgress2.style.display = "block";
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
                    var updateProgress2 = $get("<%= UpdateProgress2.ClientID %>");
                    updateProgress2.style.display = "block";
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
                    var updateProgress2 = $get("<%= UpdateProgress2.ClientID %>");
                    updateProgress2.style.display = "block";
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

        function Final_Showprogress() {
            debugger;

            var TxtSignatory = $('#ContentPlaceHolder1_TxtSignatory_ifr').contents().find('body').text();
            var TxtContent = $('#ContentPlaceHolder1_TextBox1_ifr').contents().find('body').text();
            var content = tinymce.get("ContentPlaceHolder1_TextBox1").getContent();

            if (TxtSignatory.trim() == "") {
                alert("Please Fill Signatory.");
                document.getElementById('<%=TxtSignatory.ClientID%>').focus();
                return false;
            }
            if (TxtContent.trim() == "") {
                alert("Please Fill Content.");
                document.getElementById('<%=TextBox1.ClientID%>').focus();
                return false;
            }

            if (content.length > 32530) {
                alert("Max 32530 character set are allowed.Current Character Size=" + content.length);
                document.getElementById('<%=TextBox1.ClientID%>').focus();
                return false;
            }

            var updateProgress3 = $get("<%= UpdateProgress3.ClientID %>");
            updateProgress3.style.display = "block";
        }

        function DrpValidation() {
            var value = document.getElementById("<%=DrpType.ClientID%>");
            var text = value.options[value.selectedIndex].value;
            if (text == "Select") {
                alert("Please select Keywords!!");
                document.getElementById('<%=DrpType.ClientID%>').focus();
                return false;
            }
        }


    </script>

    <script type="text/javascript" src="https://ajax.googleapis.com/ajax/libs/jquery/1.8.3/jquery.min.js"></script>
    <link rel="stylesheet" href="//code.jquery.com/ui/1.12.1/themes/base/jquery-ui.css" />
    <script src="https://code.jquery.com/jquery-1.12.4.js"></script>
    <script src="https://code.jquery.com/ui/1.12.1/jquery-ui.js"></script>

    <%--  <script type="text/javascript">
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
    </script>--%>

    <script type="text/javascript">

        //$(document).ready(function () {
        //    $('#BtnAdd').click(function () {
        //        debugger;
        //        alert('1');
        //        InsertAtCaret('test');
        //    });
        //});

        //        function setTextToCurrentPos() { 
        //                var curPos =  
        //                    document.getElementById("ContentPlaceHolder1_TextBox1").selectionStart;
        //                console.log(curPos); 
        //                let x = $("#ContentPlaceHolder1_TextBox1").val();
        //                let text_to_insert = $("#ContentPlaceHolder1_DrpType").val();
        //                $("#ContentPlaceHolder1_TextBox1").val(
        //x.slice(0, curPos) + text_to_insert + x.slice(curPos)); 
        //            } 

        <%--   function insertAtCaret(areaId) {
            var txtarea = document.getElementById(areaId);
            var text = document.getElementById('<%=DrpType.ClientID%>').value;
            //var text = value.options[value.selectedIndex].value;
            if (text == "Select") {
                alert("Select Content Type!!");
                document.getElementById('<%=DrpType.ClientID%>').focus();
                return;
            }
            if (!txtarea) {
                return;
            }

            var scrollPos = txtarea.scrollTop;
            var strPos = 0;
            var br = ((txtarea.selectionStart || txtarea.selectionStart == '0') ?
              "ff" : (document.selection ? "ie" : false));
            if (br == "ie") {
                txtarea.focus();
                var range = document.selection.createRange();
                range.moveStart('character', -txtarea.value.length);
                strPos = range.text.length;
            } else if (br == "ff") {
                strPos = txtarea.selectionStart;
            }

            var front = (txtarea.value).substring(0, strPos);
            var back = (txtarea.value).substring(strPos, txtarea.value.length);
            txtarea.value = front + text + back;
            strPos = strPos + text.length;
            if (br == "ie") {
                txtarea.focus();
                var ieRange = document.selection.createRange();
                ieRange.moveStart('character', -txtarea.value.length);
                ieRange.moveStart('character', strPos);
                ieRange.moveEnd('character', 0);
                ieRange.select();
            } else if (br == "ff") {
                txtarea.selectionStart = strPos;
                txtarea.selectionEnd = strPos;
                txtarea.focus();
            }

            txtarea.scrollTop = scrollPos;
        }--%>
    </script>

    <%--   <script type="text/javascript" src="tiny_mce/tiny_mce.js"></script>
    <script type="text/javascript" language="javascript">
        tinyMCE.init({
            // General options
            mode: "textareas",
            theme: "advanced",
            // plugins: "pagebreak,style,layer,table,save,advhr,advimage,advlink,emotions,iespell,inlinepopups",
            plugins: "pagebreak,style,layer,table,save,advhr,advimage,advlink,emotions,iespell,inlinepopups",

        });
    </script>--%>


    <script src="tiny_mce/tinymce.min.js" type="text/javascript"></script>
    <script>
        //tinymce.init({ selector: 'textarea' });

        /* wire-up an event to re-add the editor */
        Sys.WebForms.PageRequestManager.getInstance().add_endRequest(EndRequestHandler_Page);

        /* fire this event to remove the existing editor and re-initialize it*/
        function EndRequestHandler_Page(sender, args) {
            //1. Remove the existing TinyMCE instance of TinyMCE
            tinymce.remove('textarea');
            //2. Re-init the TinyMCE editor
            LoadTinyMCE();
        }

        function BeforePostback() {
            tinymce.triggerSave();
        }


        $(document).ready(function () {
            LoadTinyMCE();
        });

        function LoadTinyMCE() {
            tinymce.init({
                selector: 'textarea',
                plugins: [
        'advlist autolink lists charmap pagebreak',
        'searchreplace visualblocks', 'wordcount',
        'table','code'
                ],
                toolbar: 'undo redo cut copy paste| insert | styleselect | bold italic | alignleft aligncenter alignright alignjustify | bullist numlist outdent indent | code',
                branding: false

            });
        }

    </script>
    <div class="main-content">
        <nav aria-label="breadcrumb">
            <ol class="breadcrumb">
                <li class="breadcrumb-item"><a href="admin-dashboard.aspx">Home</a></li>
                <li class="breadcrumb-item"><a href="settings.aspx">Masters</a></li>
                <li class="breadcrumb-item"><a href="LetterConfiguration.aspx">Letter Configuration</a></li>
                <li class="breadcrumb-item active" aria-current="page">Edit Letter</li>
            </ol>
        </nav>
        <asp:UpdatePanel ID="UPabove" runat="server">
            <ContentTemplate>
                <section class="section">
                    <div class="section-body">
                        <div class="invoice">
                            <div class="row">
                                <div class="col-md-6">
                                    <strong>Header:</strong>
                                    <div class="buttons">
                                        <table class="tablediv">
                                            <tr>
                                                <td>
                                                    <asp:FileUpload ID="FileUploadHeader" runat="server" /></td>
                                                <td>
                                                    <asp:LinkButton ID="LnkHeaderEdit" runat="server" OnClick="LnkHeaderEdit_Click" OnClientClick="return Header_ReqValidation();showProgress2(); return false;return postbackButtonClick();" CssClass="fas fa-plus edit2"></asp:LinkButton>
                                                    <asp:LinkButton ID="LnkHeaderDelete" runat="server" CssClass="fas fa-trash-alt delete2" OnClick="LnkHeaderDelete_Click" OnClientClick="return confirm('Are you sure you want to Delete Image?');"></asp:LinkButton>
                                                </td>
                                            </tr>
                                        </table>
                                    </div>
                                    <div class="over">
                                        <asp:Image runat="server" ID="ImgHeader" class="header1" alt="image"></asp:Image>
                                    </div>
                                </div>
                                <div class="col-md-6">
                                    <strong>Footer:</strong>
                                    <div class="buttons">
                                        <table class="tablediv">
                                            <tr>
                                                <td>
                                                    <asp:FileUpload ID="FileUploadFooter" runat="server" /></td>
                                                <td>
                                                    <asp:LinkButton ID="LnkFooterEdit" runat="server" CssClass="fas fa-plus edit2" OnClick="LnkFooterEdit_Click" OnClientClick="return Footer_ReqValidation();showProgress2(); return false;return postbackButtonClick();"></asp:LinkButton>
                                                    <asp:LinkButton ID="LnkFooterDelete" runat="server" CssClass="fas fa-trash-alt delete2" OnClick="LnkFooterDelete_Click" OnClientClick="return confirm('Are you sure you want to Delete Image?');"></asp:LinkButton>
                                                </td>
                                            </tr>
                                        </table>
                                    </div>
                                    <div class="over">
                                        <asp:Image runat="server" ID="ImgFooter" class="header1" alt="image"></asp:Image>
                                    </div>
                                </div>
                            </div>
                        </div>
                        <div class="invoice">
                            <div class="row">
                                <div class="col-md-6">
                                    <strong>Signature:</strong>
                                    <div class="buttons">
                                        <table class="tablediv">
                                            <tr>
                                                <td>
                                                    <asp:FileUpload ID="FileUploadSign" runat="server" />
                                                </td>
                                                <td>
                                                    <asp:LinkButton ID="LnkSignEdit" runat="server" CssClass="fas fa-plus edit2" OnClick="LnkSignEdit_Click" OnClientClick="return Sign_ReqValidation();showProgress2(); return false;return postbackButtonClick();"></asp:LinkButton>
                                                    <asp:LinkButton ID="LnkSignDelete" runat="server" CssClass="fas fa-trash-alt delete2" OnClick="LnkSignDelete_Click" OnClientClick="return confirm('Are you sure you want to Delete Image?');"></asp:LinkButton>
                                                </td>
                                            </tr>
                                        </table>
                                    </div>
                                    <div class="over">
                                        <asp:Image runat="server" ID="ImgSign" class="header1" alt="image"></asp:Image>
                                    </div>
                                </div>
                                <div class="col-md-6">
                                    <strong>Signatory:</strong>
                                    <div class="buttons">
                                    </div>
                                    <div class="over">
                                        <asp:TextBox ID="TxtSignatory" runat="server" TextMode="MultiLine" Rows="15" Style="width: 100%"></asp:TextBox>
                                    </div>
                                </div>
                            </div>
                        </div>
                        <div class="invoice">
                            <div class="row">
                                <div class="col-md-12">
                                    <strong>Content:</strong>
                                    <div class="buttons">
                                        <div class="" style="margin-top: -20px; margin-bottom: 10px;">
                                            <div class="offset-md-8 col-md-4">
                                                <div class="row">
                                                    <div class="col-md-9">
                                                        <%-- <div class="form-group">--%>
                                                        <asp:DropDownList ID="DrpType" runat="server" class="form-control">
                                                            <%-- <asp:DropDownList ID="DropDownList1" runat="server" class="form-control" OnSelectedIndexChanged="DrpType_SelectedIndexChanged" AutoPostBack="true">--%>
                                                            <asp:ListItem Value="Select">Select</asp:ListItem>
                                                            <asp:ListItem Value="@EmpCode">Emp Code</asp:ListItem>
                                                            <asp:ListItem Value="@EmpName">Emp Name</asp:ListItem>
                                                            <asp:ListItem Value="@Tranch_Name">Tranch Name</asp:ListItem>
                                                            <asp:ListItem Value="@No_Of_Options">No Of Options</asp:ListItem>
                                                            <asp:ListItem Value="@FMV_Price">FMV Price</asp:ListItem>
                                                            <asp:ListItem Value="@SrNo">SrNo</asp:ListItem>
                                                            <asp:ListItem Value="@Grant_Date">Grant Date</asp:ListItem>
                                                            <asp:ListItem Value="@TodayDate">Today Date</asp:ListItem>
                                                            <asp:ListItem Value="@Designation">Designation</asp:ListItem>
                                                            <asp:ListItem Value="@Location">Location</asp:ListItem>
                                                            <asp:ListItem Value="@Department">Department</asp:ListItem>
                                                            <asp:ListItem Value="@In_Words">No. In Words</asp:ListItem>
                                                            <asp:ListItem Value="@Reference_No">Reference No</asp:ListItem>
                                                            <asp:ListItem Value="@Vest_Date1">Vest Cycle 1</asp:ListItem>
                                                            <asp:ListItem Value="@Vest_Date2">Vest Cycle 2</asp:ListItem>
                                                            <asp:ListItem Value="@Vest_Date3">Vest Cycle 3</asp:ListItem>
                                                            <asp:ListItem Value="@Vest_Date4">Vest Cycle 4</asp:ListItem>
                                                            <asp:ListItem Value="@Vest_Date5">Vest Cycle 5</asp:ListItem>
                                                            <asp:ListItem Value="@Vest_Date6">Vest Cycle 6</asp:ListItem>
                                                        </asp:DropDownList>
                                                        <%--</div>--%>
                                                    </div>
                                                    <div class="col-md-3">
                                                        <%--   <asp:Button runat="server" ID="BtnAdd" OnClientClick="insertAtCaret('TextArea1');return false;" Text="Add" class="btn btn-outline-success" ClientIDMode="Static" />--%>
                                                        <asp:Button runat="server" ID="BtnAdd" OnClick="BtnAdd_Click" Text="Add" class="btn btn-outline-success" OnClientClick="return DrpValidation();return false;" />
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                        <div class="over">
                                            <div class="row">
                                                <div id="sample" class="col-md-12">
                                                    <asp:TextBox ID="TextBox1" runat="server" TextMode="MultiLine" Style="width: 100%; height: 500px !important;"></asp:TextBox>
                                                    <textarea id="TextArea1" style="width: 100%; height: 500px !important;" runat="server" clientidmode="Static" visible="false" class="form-control text-left"></textarea>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </section>
            </ContentTemplate>
            <Triggers>
                <%--   <asp:PostBackTrigger ControlID="BtnPreviewBelow" />--%>
                <%--<asp:PostBackTrigger ControlID="LnkDesign" />--%>
                <asp:PostBackTrigger ControlID="LnkHeaderEdit" />
                <asp:PostBackTrigger ControlID="LnkFooterEdit" />
                <asp:PostBackTrigger ControlID="LnkSignEdit" />
                <asp:AsyncPostBackTrigger ControlID="LnkHeaderDelete" EventName="Click" />
                <asp:AsyncPostBackTrigger ControlID="LnkFooterDelete" EventName="Click" />
                <asp:AsyncPostBackTrigger ControlID="LnkSignDelete" EventName="Click" />
                <asp:AsyncPostBackTrigger ControlID="BtnAdd" EventName="Click" />
                <%-- <asp:PostBackTrigger ControlID="DrpType" />--%>
            </Triggers>
        </asp:UpdatePanel>
        <section class="section">
            <div class="section-body">
                <div class="row">
                    <div class="buttons offset-md-5 mt-4">
                        <asp:UpdatePanel ID="UpdateFinal" runat="server">
                            <ContentTemplate>
                                <asp:Button runat="server" ID="BtnPreviewBelow" class="btn btn-outline-primary" Text="Preview" OnClick="BtnPreviewBelow_Click" OnClientClick="return Final_Showprogress();showProgress3(); return false;return postbackButtonClick();" />
                                <asp:Button runat="server" ID="BtnUpdateBelow" Text="Update" class="btn btn-outline-primary" OnClick="BtnUpdateBelow_Click2" OnClientClick="return Final_Showprogress();showProgress3(); return false;return postbackButtonClick();" />
                            </ContentTemplate>
                            <Triggers>
                                <asp:PostBackTrigger ControlID="BtnPreviewBelow" />
                                <asp:PostBackTrigger ControlID="BtnUpdateBelow" />
                            </Triggers>
                        </asp:UpdatePanel>
                    </div>
                </div>
            </div>
        </section>
        <%-- <asp:UpdateProgress ID="UpdateProgress1" runat="server" AssociatedUpdatePanelID="UP_submit">
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
        <asp:UpdateProgress ID="UpdateProgress2" runat="server" AssociatedUpdatePanelID="UPabove">
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
        <asp:UpdateProgress ID="UpdateProgress3" runat="server" AssociatedUpdatePanelID="UpdateFinal">
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

    </div>
    <footer class="main-footer">
    </footer>

    <div class="modal fade bd-example-modal-lg" id="ModelPreview" tabindex="-1" role="dialog">
        <div class="modal-dialog modal-lg">
            <div class="modal-content" style="width: 100%">
                <div class="modal-header">
                    <h5 class="modal-title" id="myLargeModalLabel">Confirmation Letter</h5>
                </div>
                <div class="modal-body">
                    <div>
                        <rsweb:ReportViewer ID="RptLetter" runat="server" Width="100%"></rsweb:ReportViewer>
                    </div>
                </div>
                <div class="modal-footer bg-whitesmoke br">
                    <div class="btn-group" role="group" aria-label="Basic example">
                        <button id="btn1" class="btn btn-info btn-lg all CloseBtnNew">Close</button>
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
    <script src="Scripts/bootstrap.min.js"></script>

    <script src="assets/js/app.min.js"></script>
    <script src="assets/bundles/ckeditor/ckeditor.js"></script>
    <!-- JS Libraies -->
    <!-- Page Specific JS File -->
    <!-- Template JS File -->
    <script src="assets/js/scripts.js"></script>
    <script src="assets/bundles/jquery.sparkline.min.js"></script>
    <script type="text/javascript" src="https://www.jqueryscript.net/demo/Drag-And-Drop-File-Uploader-With-Preview-Imageuploadify/dist/imageuploadify.min.js"></script>
    <%-- <script src="Scripts/nicEdit-latest.js"></script>--%>




    <%-- <script type="text/javascript">
        debugger;
        $.noConflict();
        area3 = new nicEditor({ fullPanel: true }).panelInstance('myArea3');
        bkLib.onDomLoaded(function () { toggleArea1(); });
    </script>--%>

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
    <script type="text/javascript">
     <%--   function showProgress1() {
            debugger;
            var updateProgress1 = $get("<%= UpdateProgress1.ClientID %>");
            updateProgress1.style.display = "block";
        }--%>

        function showProgress2() {
            debugger;
            var updateProgress2 = $get("<%= UpdateProgress2.ClientID %>");
            updateProgress2.style.display = "block";
        }

        function showProgress3() {
            debugger;
            var updateProgress3 = $get("<%= UpdateProgress3.ClientID %>");
            updateProgress3.style.display = "block";
        }
    </script>
</asp:Content>
