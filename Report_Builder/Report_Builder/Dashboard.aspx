<%@ Page Title="" Language="C#" MasterPageFile="~/Report.Master" AutoEventWireup="true" CodeBehind="Dashboard.aspx.cs" Inherits="Report_Builder.Dashboard" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <style>
        body {
            overflow-y: hidden;
        }

        .hideGridColumn {
            display: none;
        }

        .mt-52 {
            margin-top: 52px !important;
        }

    </style>

    <section>
        <div class="text-center panel_hdr">
            Created Reports
        </div>
        <div class="container p-0">
            <div class="mt-5 mb-5 grd_sec">
                <div class="table-responsive">
                    <asp:GridView ID="grdReports" CssClass="table tbl_bdr mt-52" runat="server"
                        AutoGenerateColumns="False" AllowPaging="True" EmptyDataText="No data found"
                        Width="100%" OnPreRender="grdReports_PreRender" OnRowDataBound="grdReports_RowDataBound" DataKeyNames="rpt_id">
                        <Columns>
                            <asp:BoundField DataField="Domain" HeaderText="Domain" HeaderStyle-Font-Bold="true">
                                <ItemStyle HorizontalAlign="Left" VerticalAlign="Top" Wrap="True" />
                            </asp:BoundField>

                            <asp:BoundField DataField="Report_Name" HeaderText="Report Name" HeaderStyle-Font-Bold="true">
                                <ItemStyle HorizontalAlign="Left" VerticalAlign="Top" Wrap="True" />
                            </asp:BoundField>

                            <asp:BoundField DataField="Description" HeaderText="Description" HeaderStyle-Font-Bold="true">
                                <ItemStyle HorizontalAlign="Left" VerticalAlign="Top" Wrap="True" />
                            </asp:BoundField>

                            <asp:TemplateField HeaderText="query" HeaderStyle-Font-Bold="true" HeaderStyle-CssClass="hideGridColumn" ItemStyle-CssClass="hideGridColumn">
                                <ItemTemplate>
                                    <asp:Label runat="server" ID="lblquery" Text='<%#Eval("query") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>

                            <asp:TemplateField HeaderText="View" HeaderStyle-Font-Bold="true">
                                <ItemStyle HorizontalAlign="Left" CssClass="text-center" VerticalAlign="Top" Wrap="True" />
                                <ItemTemplate>
                                    <asp:LinkButton ID="lnkView" runat="server" OnClick="lnkView_Click">
                                        <img runat="server" src="~/img/eye.png" width="27" />
                                    </asp:LinkButton>
                                </ItemTemplate>
                            </asp:TemplateField>

                            <asp:TemplateField HeaderText="Download" HeaderStyle-Font-Bold="true">
                                <ItemStyle HorizontalAlign="Left" CssClass="text-center" VerticalAlign="Top" Wrap="True" />
                                <ItemTemplate>
                                    <asp:LinkButton ID="lnkExcel" runat="server" OnClick="lnkExcel_Click">
                                        <img runat="server" src="~/img/excel1.png" width="27" />
                                    </asp:LinkButton>
                                    <asp:LinkButton ID="lnkCSV" runat="server" OnClick="lnkCSV_Click">
                                        <img runat="server" src="~/img/csv.png" width="27" />
                                    </asp:LinkButton>
                                    <asp:LinkButton ID="lnkPDF" runat="server" OnClick="lnkPDF_Click">
                                        <img runat="server" src="~/img/pdf.png" width="27" />
                                    </asp:LinkButton>
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                    </asp:GridView>
                </div>

                <div class="modal" id="myModal">
                    <div class="modal-dialog" style="max-width: 97%;margin: 10px">
                        <div class="modal-content" style="background: #fff !important">
                            <!-- Modal Header -->
                            <div class="modal-header">
                                <h4 class="modal-title">Report View</h4>
                                <button type="button" class="close" data-dismiss="modal">&times;</button>
                            </div>
                            <!-- Modal body -->
                            <div class="modal-body table-responsive">
                                <asp:GridView ID="Grid_ShowReport" CssClass="table tbl_bdr" runat="server" AutoGenerateColumns="False" EmptyDataText="No data found" Width="100%" OnPreRender="Grid_ShowReport_PreRender">
                                    <Columns>
                                    </Columns>
                                </asp:GridView>
                            </div>
                            <!-- Modal footer -->
                            <div class="modal-footer" style="justify-content: center;">
                                <button type="button" class="btn btn-set" data-dismiss="modal">Close</button>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </section>

    <script src="js/jquery-3.5.1.min.js"></script>
    <script src="js/bootstrap-4.5.0.min.js"></script>


    <%-- Added for datatables plugin --%>

    <script type="text/javascript" src="js/jquery.dataTables-1.10.20.min.js"></script>
    <link href="Styles/jquery.dataTables-1.10.20.css" rel="stylesheet" type="text/css" />

    <script type="text/javascript">
        var prm = Sys.WebForms.PageRequestManager.getInstance();
        prm.add_endRequest(function (sender, e) {
            $("#ContentPlaceHolder1_grdReports").DataTable({
                // lengthMenu: [[15, 30, 50, 100, 200, -1], [15, 30, 50, 100, 200, "All"]],
                //columnDefs: [{ orderable: false, targets: [3,4] }],
                // "bStateSave": true,
                // bPaginate: true,
                // bSort: true,
                // bFilter: true,
                // bRetrieve: true, fixedHeader: true, "scrollX": true

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
                //columnDefs: [{ orderable: false, targets: [3,4] }],
                // bLengthChange: true,
                // lengthMenu: [[15, 30, 50, 100, 200, -1], [15, 30, 50, 100, 200, "All"]],
                // bFilter: true,
                // bSort: true,
                // bPaginate: true

                bLengthChange: true,
                lengthMenu: [[15, 30, 50, 100, 200, -1], [15, 30, 50, 100, 200, "All"]],
                bFilter: true,
                bSort: true,
                bPaginate: true
            });
        });

        var prm1 = Sys.WebForms.PageRequestManager.getInstance();
        prm1.add_endRequest(function (sender, e) {
            $("#ContentPlaceHolder1_Grid_ShowReport").DataTable({
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
            $("#ContentPlaceHolder1_Grid_ShowReport").DataTable(
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
    <%-- End --%>
    <script type="text/javascript">
        function openModalShowAudit() {
            $('#myModal').modal('show');
        }
    </script>
</asp:Content>
