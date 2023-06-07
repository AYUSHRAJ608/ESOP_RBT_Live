<%@ Page Title="" Language="C#" MasterPageFile="~/Report.Master" AutoEventWireup="true" CodeBehind="SelectCriteria.aspx.cs" Inherits="Report_Builder.SelectCriteria" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <style>
        body {
            overflow-y: hidden;
            background: #fff;
        }

        .hideGridColumn {
            display: none;
        }

        @media (max-width:360px) {

            .h-set {
                height: 320px !important;
                overflow: auto;
            }

            .mobile_nav {
                position: fixed;
                z-index: 9999;
            }


            .mt-102 {
                margin-top: 102px;
                left: 0px;
                width: 100%;
            }

            .breadcrumb {
                margin-top: 157px !important;
                padding-top: 7px !important;
            }
        }


        @media (min-width:640px) {


            .h-set {
                height: 110px !important;
                overflow: auto;
            }

            .breadcrumb {
                margin-top: 110px !important;
                padding-top: 7px !important;
            }
        }


        @media (min-width: 641px) and (max-width: 1366px) {
            .breadcrumb {
                margin-top: 34px !important;
                padding-top: 7px !important;
            }

            .h-set {
                height: 400px !important;
                overflow: auto;
            }

            .mt-102 {
                margin-top: -10px;
                left: 0px;
                width: 100%;
            }
        }



        /*@media (min-width:360px) {

               
                .breadcrumb {

                        margin-top: 143px;
                        padding-top: 7px !important;
                }

                .h-set {

                        height:310px;
                        overflow:auto;margin-top:20px;
                }

                .mobile_nav {
  
                        position: fixed;
   
                        z-index: 9999;
                    }


              .mt-102 {

                        margin-top: 102px;
                        left: 0px;
                        width: 100%;
                }
               
            }


        @media (min-width:640px) {

            .breadcrumb {

                       position: fixed;
                        margin-top: 146px;
                        width: 94%;
                }

                .h-set {

                        height:77px;
                        overflow:auto;
                        margin-top: 190px;
                }

            }



        @media (min-width:1366px) {


                .breadcrumb {

                        margin-top: 34px;
                        padding-top: 7px !important;
                        position: fixed;
             width: 100%;
                }

                .h-set {

                        height:340px;
                        overflow:auto;margin-top: 100px;
                }

                 .mt-102 {

                        margin-top: -10px;
                        left: 0px;
                        width: 100%;
                }

            }*/
    </style>
    <main class="login-form">
        <div class="text-center panel_hdr mt-102">
            Select Criteria
        </div>
        <ol class="breadcrumb pt-5">
            <li class="breadcrumb-item"><a href="CreateReport.aspx">Create Report</a></li>
            <li class="breadcrumb-item"><a href="SelectDataset.aspx">Select Dataset</a></li>
            <li class="breadcrumb-item"><a href="SelectColumns.aspx">Select Columns</a></li>
            <li class="breadcrumb-item active">Select Criteria</li>
        </ol>
        <div class="container">
            <div class="row justify-content-center mt-3 mb-5">
                <div class="col-md-12 h-set p-0">
                    <div class="card">
                        <div class="card-body">
                            <div class="row">
                                <div class="col-md-12 table-responsive">
                                    <asp:UpdatePanel ID="UpGird" runat="server">
                                        <ContentTemplate>
                                            <asp:GridView ID="grdFilters" CssClass="table table-bordered" runat="server" AutoGenerateColumns="False" HeaderStyle-BackColor="#000084" HeaderStyle-ForeColor="White" Width="100%" ShowHeaderWhenEmpty="true" ShowHeader="true" OnRowDataBound="grdFilters_RowDataBound" OnRowDeleting="grdFilters_RowDeleting">
                                                <Columns>
                                                    <asp:TemplateField HeaderText="Tables" HeaderStyle-Width="25%">
                                                        <ItemTemplate>
                                                            <asp:DropDownList ID="ddlTables" runat="server" CssClass="form-control" AutoPostBack="true" OnSelectedIndexChanged="ddlTable_OnSelectedIndexChanged">
                                                            </asp:DropDownList>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>

                                                    <asp:TemplateField HeaderText="Fields" HeaderStyle-Width="25%">
                                                        <ItemTemplate>
                                                            <asp:DropDownList ID="ddlFields" runat="server" CssClass="form-control" AutoPostBack="true" OnSelectedIndexChanged="ddlFields_SelectedIndexChanged">
                                                            </asp:DropDownList>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>

                                                    <asp:TemplateField HeaderText="Condition" HeaderStyle-Width="5%">
                                                        <ItemTemplate>
                                                            <asp:DropDownList ID="ddlCondition" runat="server" CssClass="form-control" AutoPostBack="true">
                                                                <asp:ListItem Text="=" Value="=" Selected="True"></asp:ListItem>
                                                                <asp:ListItem Text="<>" Value="<>"></asp:ListItem>
                                                                <asp:ListItem Text=">" Value=">"></asp:ListItem>
                                                                <asp:ListItem Text="<" Value="<"></asp:ListItem>
                                                                <asp:ListItem Text=">=" Value=">="></asp:ListItem>
                                                                <asp:ListItem Text="<=" Value="<="></asp:ListItem>
                                                                <asp:ListItem Text="Like" Value="Like"></asp:ListItem>
                                                                <asp:ListItem Text="Not Like" Value="Not Like"></asp:ListItem>
                                                            </asp:DropDownList>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>

                                                    <asp:TemplateField HeaderText="Criteria">
                                                        <ItemTemplate>
                                                            <asp:TextBox ID="txtCriteria" runat="server" CssClass="form-control">
                                                            </asp:TextBox>
                                                            <asp:RegularExpressionValidator runat="server" ControlToValidate="txtCriteria"
                                                                ForeColor="Red" SetFocusOnError="true" Display="Dynamic" ErrorMessage="Special Characters are not allowed" ID="rfvname"
                                                                ValidationExpression="^[\sa-zA-Z0-9-]*$" ValidationGroup="AddG3">
                                                            </asp:RegularExpressionValidator>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>

                                                    <asp:TemplateField HeaderText="And/Or">
                                                        <ItemTemplate>
                                                            <asp:DropDownList ID="ddlAO" runat="server" CssClass="form-control" AutoPostBack="true" OnSelectedIndexChanged="ddlAO_SelectedIndexChanged">
                                                                <asp:ListItem Text="None" Value="0"></asp:ListItem>
                                                                <asp:ListItem Text="And" Value="1"></asp:ListItem>
                                                                <asp:ListItem Text="Or" Value="2"></asp:ListItem>
                                                            </asp:DropDownList>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:CommandField ShowDeleteButton="true" ButtonType="Button" ControlStyle-CssClass="btn btn-set" />
                                                </Columns>
                                            </asp:GridView>
                                        </ContentTemplate>
                                        <Triggers>
                                            <asp:AsyncPostBackTrigger ControlID="grdFilters" />
                                        </Triggers>
                                    </asp:UpdatePanel>
                                </div>
                            </div>
                        </div>
                        <div class="text-center p-3">
                            <b>Sort By</b>
                        </div>
                        <div class="card-body pt-0">
                            <div class="col-md-12">
                                <div class="row">
                                    <div class="col-md-4">
                                        Tables:
                                        <asp:DropDownList ID="ddlTabs" runat="server" CssClass="form-control" ToolTip="Select Table" AutoPostBack="true" OnSelectedIndexChanged="ddlTabs_SelectedIndexChanged"></asp:DropDownList>
                                    </div>
                                    <div class="col-md-4">
                                        Columns:
                                        <asp:DropDownList ID="ddlCols" runat="server" CssClass="form-control" ToolTip="Select Columns" AutoPostBack="true"></asp:DropDownList>
                                    </div>
                                    <div class="col-md-4">
                                        Sort Order:
                                        <asp:DropDownList ID="ddlSort" runat="server" CssClass="form-control" AutoPostBack="true">
                                            <asp:ListItem Text="Ascending" Value="asc"></asp:ListItem>
                                            <asp:ListItem Text="Descending" Value="desc"></asp:ListItem>
                                        </asp:DropDownList>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
                <div class="col-md-12 text-center mt-3">
                    <asp:Button ID="btnSubmit" runat="server" Text="Show Report" CssClass="btn btn-set" OnClick="btnSubmit_Click" ValidationGroup="AddG3" />
                </div>
            </div>
        </div>
        <script src="js/jquery-3.5.1.min.js"></script>
        <script src="js/bootstrap-4.5.0.min.js"></script>
    </main>
</asp:Content>
