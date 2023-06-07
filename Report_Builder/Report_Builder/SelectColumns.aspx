<%@ Page Title="" Language="C#" MasterPageFile="~/Report.Master" AutoEventWireup="true" CodeBehind="SelectColumns.aspx.cs" Inherits="Report_Builder.SelectColumns" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <style>
        .hideGridColumn {
            display: none;
        }
    </style>
    <script type="text/javascript" src="http://ajax.googleapis.com/ajax/libs/jquery/1.8.3/jquery.min.js"></script>
    <link rel="stylesheet" href="https://ajax.googleapis.com/ajax/libs/jqueryui/1.8.24/themes/smoothness/jquery-ui.css" />
    <script type="text/javascript" src="https://ajax.googleapis.com/ajax/libs/jqueryui/1.8.24/jquery-ui.min.js"></script>
    <script type="text/javascript" src="http://cdnjs.cloudflare.com/ajax/libs/json2/20130526/json2.min.js"></script>
    <script type="text/javascript">
        $(function () {
            $("[id*=grdSelColumns]").sortable({
                items: 'tr:not(tr:first-child)',
                cursor: 'pointer',
                axis: 'y',
                dropOnEmpty: false,
                start: function (e, ui) {
                    ui.item.addClass("selected");
                },
                stop: function (e, ui) {
                    $('#hfDraged').val(ui.item.find("td")[0].innerText);
                    ui.item.removeClass("selected");
                },
                receive: function (e, ui) {
                    $(this).find("tbody").append(ui.item);
                }
            });
        });
    </script>
    <style>
        body {
            overflow-y: hidden;
        }

         @media (max-width:360px) {

            .h-set {
                height: 300px !important;
                overflow: auto;
            }

            .txt_rit {

                text-align:left;
                padding-left:15px !important;
            }
        }


        @media (min-width:640px) {
           

            .h-set {
                height: 100px !important;
                overflow: auto;
            }

            .txt_rit {

                text-align:left;
                padding-left:15px !important;
            }
        }

        @media (min-width: 360px) and (max-width: 640px) {

                .breadcrumb {
                margin-top: 110px !important;
                padding-top: 7px !important;
            }

        }

        @media (min-width: 641px) and (max-width: 1366px) {
            .breadcrumb {
                margin-top: 34px;
                padding-top: 7px !important;
            }

            .h-set {
                height: 400px !important;
                overflow: auto;
            }

            .txt_rit {

                text-align:right;
                
            }
        }


        /*@media (min-width:360px) {

                .breadcrumb {

                        margin-top: 102px;
                        padding-top: 7px !important;
                }

                .h-set {

                        height:368px;
                        overflow:auto;
                }
            .txt_rit {

                text-align:left;
                padding-left:15px !important;
            }

            }


        @media (min-width:640px) {

                .h-set {

                        height:113px;
                        overflow:auto;
                }

                .txt_rit {

                text-align:left;
                padding-left:15px !important;
            }

            }



        @media (min-width:1366px) {

                .breadcrumb {

                        margin-top: 34px;
                        padding-top: 7px !important;
                }

                .h-set {

                        height:400px;
                        overflow:auto;
                }

                .txt_rit {

                text-align:right;
                
            }

            }*/


    </style>
    <main class="login-form">
        <div class="text-center panel_hdr">
            Select Columns
        </div>
        <ol class="breadcrumb pt-5">
            <li class="breadcrumb-item"><a href="CreateReport.aspx">Create Report</a></li>
            <li class="breadcrumb-item"><a href="SelectDataset.aspx">Select Dataset</a></li>
            <li class="breadcrumb-item active">Select Columns</li>
        </ol>
        <div class="container">
            <div class="row justify-content-center mt-3 mb-5">
                <div class="col-md-12 h-set">
                    <div class="card">
                        <div class="row pt-3">
                            <div class="col-md-4 p-2 txt_rit">
                                <label>Name:</label>
                            </div>
                            <div class="col-md-4">
                                <asp:DropDownList ID="ddlTables" runat="server" OnSelectedIndexChanged="ddlTables_SelectedIndexChanged" CssClass="form-control bdr_ddl" AutoPostBack="true">
                                </asp:DropDownList>
                            </div>
                        </div>
                        <div class="card-body">
                            <div class="row">
                                <div class="col-md-6 table-responsive">
                                    <asp:UpdatePanel ID="upd" runat="server">
                                        <ContentTemplate>
                                            <asp:GridView ID="grdColumns" CssClass="table tbl_bdr" runat="server" AutoGenerateColumns="False" EmptyDataText="No data found" HeaderStyle-CssClass="bg_tbl_hd" Width="100%" ShowHeader="true" ShowHeaderWhenEmpty="true">
                                                <Columns>
                                                    <asp:TemplateField ItemStyle-CssClass="bg_tbl_bdy">
                                                        <HeaderTemplate>
                                                            <asp:CheckBox ID="chkAll" runat="server" AutoPostBack="true" OnCheckedChanged="chkAll_CheckedChanged" />
                                                        </HeaderTemplate>
                                                        <ItemTemplate>
                                                            <asp:CheckBox ID="chk" runat="server" AutoPostBack="true"
                                                                OnCheckedChanged="chk_CheckedChanged" />
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:BoundField DataField="COLUMN_NAME" HeaderText="Column Name" ItemStyle-CssClass="bg_tbl_bdy" />
                                                </Columns>
                                            </asp:GridView>
                                        </ContentTemplate>
                                        <Triggers>
                                            <asp:AsyncPostBackTrigger ControlID="grdColumns" />
                                        </Triggers>
                                    </asp:UpdatePanel>
                                </div>
                                <div class="col-md-6 table-responsive">
                                    <asp:UpdatePanel ID="upd1" runat="server" UpdateMode="Conditional">
                                        <ContentTemplate>
                                            <asp:GridView ID="grdSelColumns" CssClass="table tbl_bdr" runat="server" AutoGenerateColumns="False" EmptyDataText="No data found" HeaderStyle-CssClass="bg_tbl_hd" Width="100%" ShowHeaderWhenEmpty="true">
                                                <Columns>
                                                    <asp:TemplateField HeaderText="Id" ItemStyle-Width="30" HeaderStyle-CssClass="hideGridColumn" ItemStyle-CssClass="hideGridColumn">
                                                        <ItemTemplate>
                                                            <%# Container.DataItemIndex + 1 %>
                                                            <input type="hidden" name="LocationId" value='<%# Container.DataItemIndex + 1 %>' />
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:BoundField DataField="COLUMN_NAME" HeaderText="Selected Columns" ItemStyle-CssClass="bg_tbl_bdy" />
                                                    <asp:TemplateField ItemStyle-CssClass="bg_tbl_bdy">
                                                        <HeaderTemplate>
                                                            <asp:Label ID="lblAlias" Text="ALIAS" runat="server"></asp:Label>
                                                        </HeaderTemplate>
                                                        <ItemTemplate>
                                                            <asp:TextBox ID="txtAlias" runat="server" Text='<%#Eval("COLUMN_NAME")%>'></asp:TextBox>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                </Columns>
                                            </asp:GridView>
                                            <asp:HiddenField ID="hfDraged" runat="server" />
                                        </ContentTemplate>
                                        <Triggers>
                                            <asp:AsyncPostBackTrigger ControlID="grdColumns" />
                                        </Triggers>
                                    </asp:UpdatePanel>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
                

               

            </div>

            <div class="row" style="margin-top:-44px;">
            <div class="col-md-12 text-center mt-3">
                    <asp:Button ID="btnBack" runat="server" Text="Update" CssClass="btn btn-set" OnClick="btnBack_Click" />
                    <%--<asp:Button ID="btnSubmit" runat="server" Text="Show Report" CssClass="btn btn-set" OnClick="btnSubmit_Click" />--%>
                    <asp:Button ID="btnSubmit" runat="server" Text="Select Criteria" CssClass="btn btn-set" OnClick="btnSubmit_Click" />
                    <asp:Button ID="BtnShow" runat="server" Text="Show Report" CssClass="btn btn-set" OnClick="BtnShow_Click" />
                </div>
             </div>

        </div>
    </main>
    <script src="js/jquery-3.5.1.min.js"></script>
    <script src="js/bootstrap-4.5.0.min.js"></script>

    <script src="js/RowSorter.js"></script>

    <script type="text/javascript">
        var prm = Sys.WebForms.PageRequestManager.getInstance();
        prm.add_endRequest(function (sender, e) {
            RowSorter("#ContentPlaceHolder1_grdSelColumns");
        });
    </script>


    <%--<script type="text/javascript">
        RowSorter("#ContentPlaceHolder1_grdSelColumns");
    </script>--%>
</asp:Content>
