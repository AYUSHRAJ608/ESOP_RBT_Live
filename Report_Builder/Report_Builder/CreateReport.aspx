<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Report.Master" CodeBehind="CreateReport.aspx.cs" Inherits="Report_Builder.CreateReport" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <style>
        body {
            overflow-y: hidden;
        }
    </style>
    <section>
        <div class="text-center panel_hdr">
            Create Report
        </div>
        <div class="container">
            <main class="login-form">
                <div class="cotainer">
                    <div class="row justify-content-center mt-3">
                        <div class="col-md-8" style="padding-top:100px;">
                            <div class="card">
                                <div>&nbsp;</div>
                                <div class="card-body">
                                    <div class="form-group row">
                                        <label for="email_address" class="col-md-4 col-form-label text-md-right">Domain :</label>
                                        <div class="col-md-6">
                                            <label id="lblDomainName" class="col-form-label" runat="server"></label>
                                        </div>
                                    </div>

                                    <div class="form-group row">
                                        <label for="email_address" class="col-md-4 col-form-label text-md-right">Report :</label>
                                        <div class="col-md-6">
                                            <asp:TextBox ID="txtReportName" runat="server" class="form-control input_bg" AutoCompleteType="None"></asp:TextBox>
                                            <asp:RequiredFieldValidator ID="rfvReportName" runat="server"
                                                ErrorMessage="Please Enter Report Name" ControlToValidate="txtReportName" ValidationGroup="AddG3" ForeColor="Red"
                                                Display="Dynamic" CssClass="validation" Font-Size="X-Small"></asp:RequiredFieldValidator>
                                        </div>
                                    </div>

                                    <div class="form-group row">
                                        <label for="email_address" class="col-md-4 col-form-label text-md-right">Description :</label>
                                        <div class="col-md-6">
                                            <asp:TextBox ID="txtDescription" runat="server" class="form-control input_bg"></asp:TextBox>
                                        </div>
                                    </div>

                                    <div class="col-md-6 offset-md-4">
                                        <a href="define_team.html">
                                            <asp:Button ID="btnSubmit" Text="Select Dataset" class="btn btn-set" runat="server" ValidationGroup="AddG3" OnClick="btnSubmit_Click"></asp:Button>
                                        </a>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </main>
        </div>
    </section>

    <%--<script src="https://code.jquery.com/jquery-3.5.1.min.js"></script>
    <script src="https://stackpath.bootstrapcdn.com/bootstrap/4.5.0/js/bootstrap.min.js"></script>--%>

    <script src="js/jquery-3.5.1.min.js"></script>
    <script src="js/bootstrap-4.5.0.min.js"></script>    

    <script>
        $('#myTable').on('click', '.clickable-row', function (event) {
            $(this).addClass('active').siblings().removeClass('active');
        });
    </script>
</asp:Content>
