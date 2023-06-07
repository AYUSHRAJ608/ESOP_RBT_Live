<%@ Page Title="" Language="C#" MasterPageFile="~/Report.Master" AutoEventWireup="true" CodeBehind="SelectDataset.aspx.cs" Inherits="Report_Builder.SelectDataset" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <style>
        body {
            overflow-y: hidden;
        }

        @media (max-width:360px) {

            .h-set {
                height: 400px !important;
                overflow: auto;
            }
        }


        @media (min-width:640px) {
           

            .h-set {
                height: 132px !important;
                overflow: auto;
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
        }

            
        
    </style>
    <main class="login-form">
        <div class="text-center panel_hdr">
            Select Dataset
        </div>
        <ol class="breadcrumb pt-5">
            <li class="breadcrumb-item"><a href="CreateReport.aspx">Create Report</a></li>
            <li class="breadcrumb-item active">Select Dataset</li>
        </ol>
        <div class="container">
            <%--<ul class="breadcrumb">
                <li><a href="CreateReport.aspx">Create Report</a></li>
                <li>Select Dataset</li>
            </ul>--%>
            <div class="row justify-content-center mt-3 mb-5">
                <div class="col-md-12 h-set">
                    <div class="card">
                        <%--<div class="text-center p-3" style="background: #a5a1bd; color: #fff;">
                            Select Dataset
                        </div>

                        <div class="text-left p-3">
                            <b>Select Dataset from the list</b>
                        </div>--%>

                        <div class="card-body">
                            <div class="row">
                                <div class="col-md-6 table-responsive">
                                    <asp:UpdatePanel ID="upd" runat="server">
                                        <ContentTemplate>
                                            <asp:GridView ID="grdAll" CssClass="table tbl_bdr" runat="server" AutoGenerateColumns="False" HeaderStyle-CssClass="bg_tbl_hd" EmptyDataText="No data found" Width="100%">
                                                <Columns>
                                                    <asp:TemplateField ItemStyle-CssClass="bg_tbl_bdy">
                                                        <HeaderTemplate>
                                                            <asp:CheckBox ID="chkAll" runat="server" AutoPostBack="true" OnCheckedChanged="chkAll_CheckedChanged" />
                                                        </HeaderTemplate>
                                                        <ItemTemplate>
                                                            <asp:CheckBox ID="chk" runat="server" AutoPostBack="true" OnCheckedChanged="chk_CheckedChanged" />
                                                            <asp:HiddenField ID="hdnChk" runat="server" Value='<%#Eval("TABLE_TYPE") %>' />
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:BoundField DataField="TABLE_ALIAS" HeaderText="Datasets" HeaderStyle-Font-Bold="true" ItemStyle-CssClass="bg_tbl_bdy">
                                                        <ItemStyle HorizontalAlign="Left" VerticalAlign="Top" Wrap="True" />
                                                    </asp:BoundField>
                                                </Columns>
                                            </asp:GridView>
                                        </ContentTemplate>
                                        <Triggers>
                                            <asp:AsyncPostBackTrigger ControlID="grdAll" />
                                        </Triggers>
                                    </asp:UpdatePanel>
                                </div>

                                <div class="col-md-6 table-responsive">
                                    <asp:UpdatePanel ID="upd1" runat="server" UpdateMode="Conditional">
                                        <ContentTemplate>
                                            <asp:GridView ID="grdSelected" CssClass="table tbl_bdr" runat="server" AutoGenerateColumns="False" EmptyDataText="No data found" HeaderStyle-CssClass="bg_tbl_hd" Width="100%" ShowHeaderWhenEmpty="true">
                                                <Columns>
                                                    <asp:BoundField DataField="TABLE_ALIAS" HeaderText="Selected Datasets" HeaderStyle-Font-Bold="true" ItemStyle-CssClass="bg_tbl_bdy">
                                                        <ItemStyle HorizontalAlign="Left" VerticalAlign="Top" Wrap="True" />
                                                    </asp:BoundField>
                                                </Columns>
                                            </asp:GridView>
                                        </ContentTemplate>
                                        <Triggers>
                                            <asp:AsyncPostBackTrigger ControlID="grdAll" />
                                        </Triggers>
                                    </asp:UpdatePanel>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
                <div class="col-md-12 text-center">
                    <a href="SelectColumns.aspx">
                        <asp:Button ID="btnSelCol" CssClass="btn btn-set" runat="server" Text="Select Columns" OnClick="btnSelCol_Click" />
                    </a>
                </div>
            </div>
        </div>
    </main>
    <script src="js/jquery-3.5.1.min.js"></script>
    <script src="js/bootstrap-4.5.0.min.js"></script>

    <script type="text/javascript">
        //window.onload = function () {
        //    debugger;
        //    var tblFruits = document.getElementById("ContentPlaceHolder1_grdAll");
        //    var chks = tblFruits.getElementsByTagName("input");
        //    for (var i = 0; i < chks.length - 1; i++) {
        //        chks[i].onclick = function () {
        //            var Hdnfld = chks.item(i).value

        //            for (var j = 0; j < chks.length - 1; j++) {
        //                if (Hdnfld == "VIEW") {
        //                    alert(Hdnfld);
        //                    if (chks[j] != this && this.checked) {
        //                        chks[j].checked = false;
        //                    }
        //                }
        //            }
        //        };
        //    }
        //};    
    </script>
</asp:Content>
