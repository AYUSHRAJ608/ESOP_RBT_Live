<%@ Page Title="" Language="C#" MasterPageFile="~/ESOP.Master" AutoEventWireup="true" CodeBehind="PANCardUpload.aspx.cs" Inherits="ESOP.PANCardUpload" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ScriptManager ID="script" runat="server"></asp:ScriptManager>

    <style>
        .card .card-body, .card .card-footer, .card .card-header {
            padding: 15px 25px !important;
        }

        .card {
            height: auto;
        }

        .card .card-header h4 {
            font-size: 17px;
        }

        .card .card-header {
            background-color: transparent;
            padding: 5px 40px !important;
        }

        .card .card-header .btn {
            margin-top: 1px;
            padding: 0px 8px;
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

    <div class="main-content">
        <div style="font-weight: 500; display: none" runat="server" id="div">President Grant Approval Summary</div>
        <nav aria-label="breadcrumb">

            <ol class="breadcrumb">
                <li class="breadcrumb-item text-left"><a href="admin-dashboard.aspx">Home</a></li>
                <li class="breadcrumb-item"><a href="settings.aspx">Masters</a></li>
                <li class="breadcrumb-item active" aria-current="page">PAN Card Number upload</li>
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
                    <div class="card" id="PanUpload" runat="server">
                        <div class="card-header">
                            <h4>PAN Card Number Upload</h4>
                        </div>
                        <div class="card-body">
                            <div class="row" style="margin-top: 15px;">
                                <div class="col-lg-4 col-md-12 col-sm-12 multidatadiv">
                                    <div class="form-group">
                                        <label>Upload File <span style="color: red">*</span></label>
                                        <asp:FileUpload ID="uploadfile" runat="server" CssClass="dropify" accept=".xls, .xlsx" class="form-control" /><br />
                                        <asp:Label ID="lblFileType" runat="server" Text="(Only .xls, .xlsx files are allowed.)" ForeColor="Green" Font-Bold="true" Font-Size="14px"></asp:Label>
                                    </div>
                                </div>

                                <div class="col-lg-4 col-md-12 col-sm-12 multidatadiv">
                                    <div class="form-group">
                                        <div class="section-title">Upload Format</div>
                                        <div class="">
                                            <label style="margin-right: 15px;">Excel</label>
                                            <asp:LinkButton ID="lnkDownloadFormat" Text="Download Template" OnClick="lnkDownloadFormat_Click" runat="server" />
                                        </div>
                                    </div>
                                </div>

                                <div class="col-lg-3 offset-md-5 mt-5">
                                    <asp:UpdatePanel ID="UP_submit" runat="server">
                                        <ContentTemplate>
                                            <asp:Button ID="btnUpload" runat="server" Text="Upload" OnClick="btnUpload_Click" OnClientClick="return validate(); showProgress1(); return false;" CssClass="btn btn-info btn-lg all" />
                                        </ContentTemplate>
                                        <Triggers>
                                            <asp:PostBackTrigger ControlID="btnUpload" />
                                        </Triggers>
                                    </asp:UpdatePanel>
                                </div>
                            </div>
                            <div style="color: red; float: right">
                                All (*) marked fields are mandatory.
                            </div>
                        </div>
                    </div>
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
                                                <div class="badge badge-success"><%= SuccessRecords %></div>
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
    </div>

    <script src="assets/js/jquery-1.8.3.min.js" type="text/javascript"></script>
    <link href="assets/css/jquery-ui-1.12.1.css" rel="stylesheet" />
    <script src="assets/js/jquery-1.12.4.js" type="text/javascript"></script>
    <script src="assets/js/jquery-ui-1.12.1.js" type="text/javascript"></script>

    <script type="text/javascript">
        function validate()
        {
            if (document.getElementById("<%=uploadfile.ClientID %>").value == 0) {
                alert("Please select Excel file");
                return false;
            }
            var updateProgress1 = $get("<%= UpdateProgress1.ClientID %>");
            updateProgress1.style.display = "block";
            return true;
        }

        function showProgress1() {
            var updateProgress1 = $get("<%= UpdateProgress1.ClientID %>");
            updateProgress1.style.display = "block";
        }

        function Hide_Div() {
            document.getElementById("<%=tablediv.ClientID%>").style.display = "none";
        };

        function Show_Div() {
            document.getElementById("<%=tablediv.ClientID%>").style.display = "block";
        };
    </script>

    <script src="assets/js/app.min.js"></script>
    <script src="assets/js/scripts.js"></script>
</asp:Content>
