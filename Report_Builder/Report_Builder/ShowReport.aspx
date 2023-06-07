<%@ Page Title="" Language="C#" MasterPageFile="~/Report.Master" AutoEventWireup="true" CodeBehind="ShowReport.aspx.cs" Inherits="Report_Builder.ShowReport" EnableEventValidation="false" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <style>
        body {
            overflow-y: hidden;
        }

        @media (max-width:360px) {

             .breadcrumb {
                margin-top: 150px;
                padding-top: 7px !important;
            }

            .h-set {
                height: 250px !important;
                overflow: auto;
            }

            .txt_rit {
                text-align: left;
                padding-left: 15px !important;
            }

            .panel_hdr {
                background: #d1d1d1;
                padding: 10px 0px;
                font-weight: 600;
                position: fixed;
                width: 100%;
                margin-top: 102px;
                left: 0px;
            }

            .content {
                padding: 10px 0px;
            }
        }


        @media (min-width:640px) {
             .breadcrumb {
                margin-top: 110px;
                padding-top: 7px !important;
            }

            .h-set {
                height: 60px !important;
                overflow: auto;
            }

            .txt_rit {
                text-align: left;
                padding-left: 15px !important;
            }
        }

        @media (min-width: 360px) and (max-width: 640px) {

            
        }


        @media (min-width:1366px) {
            
        }

        @media (min-width: 641px) and (max-width: 1366px) {
        .breadcrumb {
                margin-top: 44px;
                padding-top: 7px !important;
            }

            .h-set {
                height: 385px !important;
                overflow: auto;
            }

            .txt_rit {
                text-align: right;
            }

            .panel_hdr {
                background: #d1d1d1;
                padding: 10px 0px;
                font-weight: 600;
                position: fixed;
                width: 100%;
                margin-top: 0px;
            }

            .content {
                margin-top: 50px !important;
            }
        }



        /*@media (min-width:360px) {

                .breadcrumb {

                        margin-top: 143px;
                        padding-top: 7px !important;
                }

                .h-set {

                        height:270px;
                        overflow:auto;
                }
            .txt_rit {

                text-align:left;
                padding-left:15px !important;
            }

            .panel_hdr {
                        background: #d1d1d1;
                        padding: 10px 0px;
                        font-weight: 600;
                        position: fixed;
                        width: 100%;
                        margin-top: 102px;
                        left: 0px;
                    }

            .content {
                
                padding: 10px 0px;
               
            }


            }


        @media (min-width:640px) {

                .h-set {

                        height:50px;
                        overflow:auto;
                }

                .txt_rit {

                text-align:left;
                padding-left:15px !important;
            }

            }



        @media (min-width:1366px) {

                .breadcrumb {

                        margin-top: 44px;
                        padding-top: 7px !important;
                }

                .h-set {

                        height:370px;
                        overflow:auto;
                }

                .txt_rit {

                text-align:right;
                
            }

                .panel_hdr{
                    background: #d1d1d1;
                    padding: 10px 0px;
                    font-weight: 600;
                    position: fixed;
                    width: 100%;
                    margin-top: 0px;
                }

            }*/
    </style>
    <section>
        <div class="text-center panel_hdr">
            Show Reports
        </div>
        <ol class="breadcrumb pt-5">
            <li class="breadcrumb-item"><a href="CreateReport.aspx">Create Report</a></li>
            <li class="breadcrumb-item"><a href="SelectDataset.aspx">Select Dataset</a></li>
            <li class="breadcrumb-item"><a href="SelectColumns.aspx">Select Columns</a></li>
            <li class="breadcrumb-item"><a href="SelectCriteria.aspx">Select Criteria</a></li>
            <li class="breadcrumb-item active">Show Report</li>
        </ol>
        <div class="container p-0 text-right" style="padding-top: 12px; float: right; padding-right: 100px !important">
            <asp:LinkButton ID="btnexcelExport" runat="server" OnClick="lnkExcel_Click">
                        <img runat="server" src="~/img/excel1.png" width="27" />
            </asp:LinkButton>
            <asp:LinkButton ID="lnkCSV" runat="server" OnClick="lnkCSV_Click">
                        <img runat="server" src="~/img/csv.png" width="27" />
            </asp:LinkButton>
            <asp:LinkButton ID="btnpdfexport" runat="server" OnClick="lnkPDF_Click">
                        <img runat="server" src="~/img/pdf.png" width="27" />
            </asp:LinkButton>
        </div>
        <div class="container">
            <div class="mt-5 mb-3 h-set">
                <%-- <div class="text-left">
                    <h4 style="font-size: 16px;line-height: 28px;padding-right: 10px;margin-bottom: 15px;display: block;width: 100%;font-weight: bold;">Show Reports</h4>
                </div>--%>

                <br />
                <%-- <br />
                <br />--%>
                <div class="table-responsive">
                    <asp:GridView ID="grdReports" CssClass="table tbl_bdr" runat="server" AutoGenerateColumns="False" EmptyDataText="No data found" Width="100%" OnPreRender="grdReports_PreRender">
                    </asp:GridView>
                </div>
            </div>
            <div class="col-md-12 text-center">
                <asp:Button ID="btnFinish" CssClass="btn btn-set" runat="server" Text="Save" OnClick="btnFinish_Click" />
            </div>
        </div>
    </section>

    <script type="text/javascript" src="js/jquery-1.8.3.min.js"></script>
    <script type="text/javascript" src="js/jquery.dataTables-1.10.20.min.js"></script>
    <link href="Styles/jquery.dataTables-1.10.20.css" rel="stylesheet" type="text/css" />

    <script type="text/javascript">
        var prm = Sys.WebForms.PageRequestManager.getInstance();
        prm.add_endRequest(function (sender, e) {
            $("#ContentPlaceHolder1_grdReports").DataTable({
                lengthMenu: [[15, 30, 50, 100, 200, -1], [15, 30, 50, 100, 200, "All"]],
                //columnDefs: [{ orderable: false, targets: [3, 4] }],
                "bStateSave": true,
                bPaginate: true,
                bSort: true,
                bFilter: true,
                bRetrieve: true, fixedHeader: true, "scrollX": true
            });
        });

        $(function () {
            $("#ContentPlaceHolder1_grdReports").DataTable(
            {
                //columnDefs: [{ orderable: false, targets: [3, 4] }],
                bLengthChange: true,
                lengthMenu: [[15, 30, 50, 100, 200, -1], [15, 30, 50, 100, 200, "All"]],
                bFilter: true,
                bSort: true,
                bPaginate: true
            });
        });
    </script>
</asp:Content>
