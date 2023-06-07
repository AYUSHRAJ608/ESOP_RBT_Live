<%@ Page Title="" Language="C#" MasterPageFile="~/ESOP.Master" AutoEventWireup="true" CodeBehind="Secretarial_Dashboard.aspx.cs" Inherits="ESOP.Secretarial_Dashboard" %>


<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <style>
        .griditem {
            text-align: left !important;
            padding-left: 30px !important;
        }

        table.simple-tree-table span.tree-icon.tree-closed, table.simple-tree-table span.tree-icon.tree-opened {
            background-color: #2673FF !important;
            text-align: center;
            cursor: pointer;
            border-radius: 31px;
            color: #fff;
            display: inline-block;
        }

            table.simple-tree-table span.tree-icon.tree-closed:after {
                content: "+";
                line-height: 22px;
                font-size: 25px;
            }

            table.simple-tree-table span.tree-icon.tree-opened:after {
                content: "-";
                line-height: 18px;
                font-size: 32px;
            }

        table.simple-tree-table span.tree-icon {
            display: inline-block;
            width: 23px !important;
            margin: 5px;
            padding: 0;
            height: 23px;
            line-height: 18px;
            vertical-align: -3px;
        }

        /*.table th {
            color: #000 !important;
            font-weight: 600 !important;
            font-size: 16px !important;
            letter-spacing: 0.2px;
            font-weight: 500 !important;
            text-shadow: none;
            border: 0 !important;
        }*/
        /* span.tree-icon {
         margin-left: 34px !important;
         } */
        .main-content {
            padding-top: 40px;
        }

        .main-footer {
            margin-top: 29px;
        }

        table.simple-tree-table span.tree-icon {
            display: none;
        }

        .sidebar-mini .main-sidebar .sidebar-menu > li > a span {
            display: none;
            width: auto !important;
            color: white;
        }

        .table th {
            color: #000 !important;
            font-weight: 600 !important;
        }

        .table:not(.table-sm):not(.table-md):not(.dataTable) td, .table:not(.table-sm):not(.table-md):not(.dataTable) th {
            padding: 0px 2px;
            vertical-align: middle !important;
            font-size: 14px;
            font-weight: 500;
            text-align: center;
            border: 1px solid #96a2b44a !important;
            /* color: #000000c2 !important; */
        }
    </style>
    <asp:ScriptManager ID="script" runat="server"></asp:ScriptManager>
    <div class="sidebar-mini">
        <div class="loader"></div>
        <div id="app">
            <div class="main-wrapper main-wrapper-1">
                <div class="navbar-bg"></div>
                <div class="main-content" style="padding-top: 25px; padding-left: 40px; padding-right: 10px;">
                    <section class="section">
                        <div class="section-header">
                            <div class="row">
                                <div class="col-xl-6 col-lg-6 col-md-6 col-sm-12">
                                    <div class="section-header-breadcrumb-content">
                                        <%-- <h1 style="margin-right: 6px; margin-top: -60px;">Admin Dashboard FY  </h1>
                                        <select class="mdb-select md-form" searchable="Search here.." style="margin-top: -60px;">
                                            <option value="" disabled selected>2020 - 2021</option>
                                            <option value="1">2021 - 2022</option>
                                            <option value="2">2022 - 2023</option>
                                            <option value="3">2023 - 2024</option>
                                            <option value="3">2024 - 2025</option>
                                            <option value="3">2025 - 2026</option>
                                        </select>--%>
                                    </div>
                                </div>
                                <div class="col-xl-6 col-lg-6 col-md-6 col-sm-12">
                                </div>
                            </div>
                        </div>
                        <!--<div class="row">
                     <div class="col-lg-6 col-md-12 col-12 col-sm-12">
                        <div class="card">
                           <div class="card-header">
                              <h4>Detail ESOP Data</h4>
                           </div>
                           <div class="card-body">
                              <div id="echart_donut" class="chartsh chart-shadow2 donut-chart"></div>
                           </div>
                        </div>
                     </div>
                     <div class="col-lg-6 col-md-12 col-12 col-sm-12">
                        <div class="card" style="height: 407px;">
                           <div class="card-header">
                              <h4>To Do List</h4>
                           </div>
                           <div class="card-body">
                              <div class="card-body mb-4">
                                 <ul class="list-unstyled user-progress list-unstyled-border list-unstyled-noborder">
                                    <li>
                                       <a href="#">Grant <span class="badge-widget bg-orange">20</span></a>
                                    </li>
                                    <li>
                                       <a href="#">Vested Pending<span class="badge-widget bg-red">30</span></a>
                                    </li>
                                    <li>
                                       <a href="#">Total Sale<span class="badge-widget bg-green">40</span></a>
                                    </li>
                                    <li>
                                       <a href="#">Total Stock Count<span class="badge-widget bg-pink">250</span></a>
                                    </li>
                                 </ul>
                              </div>
                           </div>
                        </div>
                     </div>
                  </div>-->
                        <div class="row" style="margin-top: -20px;">
                            <div class="col-lg-12 col-md-12 col-12 col-sm-12">
                                <div class="card" style="height: 100%;">
                                    <div class="card-header">
                                        <h4 style="font-size: 16px; line-height: 28px; padding-right: 10px; margin-bottom: 0; display: block; width: 100%;">Detail ESOP Data  
                                            <a href="javascript:void(0)" id="click-me" class="btn btn-outline-info align-right" style="float: right;">Expand Data</a>
                                            <%--<asp:Button ID="btnShowHide" runat="server" Text="Expand Data" class="btn btn-outline-info align-right" style="float: right;" 
                                                OnClick="btnShowHide_Click"/>--%>
                                        </h4>
                                    </div>
                                    <div class="col-md-12 table-responsive" style="margin-bottom: 0; padding-top: 15px;">

                                        <asp:UpdatePanel ID="upd" UpdateMode="Conditional" runat="server">
                                            <ContentTemplate>
                                                <asp:GridView ID="gvParent" runat="server" AutoGenerateColumns="false"
                                                    CssClass="table table-bordered simple-tree-table" DataKeyNames="" OnRowDataBound="gvParent_RowDataBound"
                                                    Style="border-collapse: separate;" EmptyDataText="No Record Found" EmptyDataRowStyle-CssClass="Empty">
                                                    <Columns>
                                                        <asp:TemplateField HeaderStyle-Width="3%">
                                                            <ItemTemplate>
                                                                <img alt="" style="cursor: pointer" src="assets/img/plus.svg" height="25px" width="25px" />
                                                                <asp:Panel ID="pnlOrders" runat="server" Style="display: none">
                                                                    <asp:GridView ID="gvChild" runat="server" AutoGenerateColumns="false" CssClass="table table-bordered simple-tree-table"
                                                                        Style="border-collapse: separate; border-spacing: 4px;" ShowHeader="false" OnRowDataBound="gvChild_RowDataBound">
                                                                        <Columns>
                                                                            <%--<asp:BoundField DataField="GRANT_NAME" HeaderStyle-Font-Bold="true" HeaderText="" HeaderStyle-Width="100%">
                                                                                <ItemStyle HorizontalAlign="Left" VerticalAlign="Top" Wrap="True" />
                                                                            </asp:BoundField>--%>
                                                                            <asp:TemplateField HeaderStyle-Width="5%" ItemStyle-Width="3%" ItemStyle-HorizontalAlign="Left">
                                                                                <ItemTemplate>
                                                                                    <img alt="" style="cursor: pointer" src="assets/img/plus.svg" height="20px" width="20px" />
                                                                                    <asp:Panel ID="pnlOrders1" runat="server" Style="display: none">
                                                                                        <asp:GridView ID="gvChildInner" runat="server" AutoGenerateColumns="false" CssClass="table table-bordered simple-tree-table"
                                                                                            Style="border-collapse: separate; border-spacing: 4px;" ShowHeader="true" OnRowDataBound="gvChildInner_RowDataBound">
                                                                                            <Columns>
                                                                                                <asp:TemplateField HeaderText="Vesting Percent" HeaderStyle-Font-Bold="true" FooterStyle-Font-Bold="true"
                                                                                                    HeaderStyle-Width="11%">
                                                                                                    <ItemTemplate>
                                                                                                        <asp:Label ID="lblVPERCENTAGE" runat="server" Text='<%#Eval("VPERCENTAGE") %>' />
                                                                                                    </ItemTemplate>
                                                                                                </asp:TemplateField>
                                                                                                <asp:TemplateField HeaderText="Vesting Date" HeaderStyle-Font-Bold="true" FooterStyle-Font-Bold="true"
                                                                                                    HeaderStyle-Width="7%">
                                                                                                    <ItemTemplate>
                                                                                                        <asp:Label ID="lblVESTING_DATE" runat="server" Text='<%#Eval("VESTING_DATE") %>' />
                                                                                                    </ItemTemplate>
                                                                                                </asp:TemplateField>
                                                                                                <asp:TemplateField HeaderText="Granted" HeaderStyle-Font-Bold="true" FooterStyle-Font-Bold="true"
                                                                                                    HeaderStyle-Width="8%">
                                                                                                    <ItemTemplate>
                                                                                                        <asp:Label ID="lblGRANTED" runat="server" Text='<%#Eval("GRANTED") %>' />
                                                                                                    </ItemTemplate>
                                                                                                </asp:TemplateField>
                                                                                                <asp:TemplateField HeaderText="Pending for Vesting" HeaderStyle-Font-Bold="true" FooterStyle-Font-Bold="true"
                                                                                                    HeaderStyle-Width="8%">
                                                                                                    <ItemTemplate>
                                                                                                        <asp:Label ID="lblVESTED_PENDING" runat="server" Text='<%#Eval("VESTED_PENDING") %>' />
                                                                                                    </ItemTemplate>
                                                                                                </asp:TemplateField>
                                                                                                <asp:TemplateField HeaderText="Vested" HeaderStyle-Font-Bold="true" FooterStyle-Font-Bold="true"
                                                                                                    HeaderStyle-Width="8%">
                                                                                                    <ItemTemplate>
                                                                                                        <asp:Label ID="lblVESTED" runat="server" Text='<%#Eval("VESTED") %>' />
                                                                                                    </ItemTemplate>
                                                                                                </asp:TemplateField>
                                                                                                <asp:TemplateField HeaderText="Pending for Excercise" HeaderStyle-Font-Bold="true" FooterStyle-Font-Bold="true"
                                                                                                    HeaderStyle-Width="9%">
                                                                                                    <ItemTemplate>
                                                                                                        <asp:Label ID="lblEXERCISED_PENDING" runat="server" Text='<%#Eval("EXERCISED_PENDING") %>' />
                                                                                                    </ItemTemplate>
                                                                                                </asp:TemplateField>
                                                                                                <asp:TemplateField HeaderText="Exercised" HeaderStyle-Font-Bold="true" FooterStyle-Font-Bold="true"
                                                                                                    HeaderStyle-Width="8%">
                                                                                                    <ItemTemplate>
                                                                                                        <asp:Label ID="lblEXERCISED" runat="server" Text='<%#Eval("EXERCISED") %>' />
                                                                                                    </ItemTemplate>
                                                                                                </asp:TemplateField>


                                                                                                <asp:TemplateField HeaderText="LBV" HeaderStyle-Font-Bold="true" FooterStyle-Font-Bold="true"
                                                                                                    HeaderStyle-Width="8%">
                                                                                                    <ItemTemplate>
                                                                                                        <asp:Label ID="lblLBV" runat="server" Text='<%#Eval("LBV") %>' />
                                                                                                    </ItemTemplate>
                                                                                                </asp:TemplateField>
                                                                                                <asp:TemplateField HeaderText="LAV" HeaderStyle-Font-Bold="true" FooterStyle-Font-Bold="true"
                                                                                                    HeaderStyle-Width="8%">
                                                                                                    <ItemTemplate>
                                                                                                        <asp:Label ID="lblLAV" runat="server" Text='<%#Eval("LAV") %>' />
                                                                                                    </ItemTemplate>
                                                                                                </asp:TemplateField>
                                                                                                <asp:TemplateField HeaderText="Sale" HeaderStyle-Font-Bold="true" FooterStyle-Font-Bold="true"
                                                                                                    HeaderStyle-Width="8%">
                                                                                                    <ItemTemplate>
                                                                                                        <asp:Label ID="lblSALE" runat="server" Text='<%#Eval("SALE") %>' />
                                                                                                    </ItemTemplate>
                                                                                                </asp:TemplateField>
                                                                                                <asp:TemplateField HeaderText="Total Lapsed" HeaderStyle-Font-Bold="true" FooterStyle-Font-Bold="true"
                                                                                                    HeaderStyle-Width="9%">
                                                                                                    <ItemTemplate>
                                                                                                        <asp:Label ID="lblTOTAL_LAPSE" runat="server" Text='<%#Eval("TOTAL_LAPSE") %>' />
                                                                                                    </ItemTemplate>
                                                                                                </asp:TemplateField>
                                                                                                <asp:TemplateField HeaderText="Stock in Hand" HeaderStyle-Font-Bold="true" FooterStyle-Font-Bold="true"
                                                                                                    HeaderStyle-Width="9%">
                                                                                                    <ItemTemplate>
                                                                                                        <asp:Label ID="lblSTOCK_IN_HAND" runat="server" Text='<%#Eval("STOCK_IN_HAND") %>' />
                                                                                                    </ItemTemplate>
                                                                                                </asp:TemplateField>
                                                                                                
                                                                                            </Columns>
                                                                                        </asp:GridView>
                                                                                    </asp:Panel>
                                                                                </ItemTemplate>
                                                                            </asp:TemplateField>
                                                                            <asp:TemplateField HeaderStyle-Width="95%" ItemStyle-Width="95%" ItemStyle-HorizontalAlign="Left" ItemStyle-BackColor="#e8f4f8"
                                                                                ItemStyle-ForeColor="#03a4c8" ItemStyle-CssClass="griditem">
                                                                                <ItemTemplate>
                                                                                    <asp:Label runat="server" ID="lblTranchName" Text='<%#Eval("GRANT_NAME") %>'></asp:Label>
                                                                                </ItemTemplate>
                                                                            </asp:TemplateField>

                                                                        </Columns>
                                                                    </asp:GridView>
                                                                </asp:Panel>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>

                                                        <asp:TemplateField HeaderText="Granted" HeaderStyle-CssClass="text-nowrap" HeaderStyle-Font-Bold="true" HeaderStyle-Width="10%">
                                                            <ItemTemplate>
                                                                <%--<asp:Label ID="lblVID" runat="server" Text='<%#Eval("VID")%>' Visible="false"></asp:Label>--%>
                                                                <asp:Label ID="lblVNAME" runat="server" Text='<%#Eval("GRANTED")%>' Visible="true"></asp:Label>
                                                                <asp:HiddenField ID="IsExpanded" ClientIDMode="AutoID" runat="server" />
                                                            </ItemTemplate>
                                                        </asp:TemplateField>

                                                        <asp:BoundField DataField="VESTED" HeaderStyle-Font-Bold="true" HeaderText="Vested" HeaderStyle-Width="9%">
                                                            <ItemStyle HorizontalAlign="Left" VerticalAlign="Top" Wrap="True" />
                                                        </asp:BoundField>
                                                        <asp:BoundField DataField="VESTED_PENDING" HeaderStyle-Font-Bold="true" HeaderText="Pending for Vesting" HeaderStyle-Width="10%">
                                                            <ItemStyle HorizontalAlign="Left" VerticalAlign="Top" Wrap="True" />
                                                        </asp:BoundField>
                                                        <asp:BoundField DataField="EXERCISED" HeaderStyle-Font-Bold="true" HeaderText="Exercised" HeaderStyle-Width="9%">
                                                            <ItemStyle HorizontalAlign="Left" VerticalAlign="Top" Wrap="True" />
                                                        </asp:BoundField>
                                                        <asp:BoundField DataField="EXERCISED_PENDING" HeaderStyle-Font-Bold="true" HeaderText="Pending for Excercise" HeaderStyle-Width="10%">
                                                            <ItemStyle HorizontalAlign="Left" VerticalAlign="Top" Wrap="True" />
                                                        </asp:BoundField>
                                                        <asp:BoundField DataField="SALE" HeaderStyle-Font-Bold="true" HeaderText="Sale" HeaderStyle-Width="9%">
                                                            <ItemStyle HorizontalAlign="Left" VerticalAlign="Top" Wrap="True" />
                                                        </asp:BoundField>
                                                        <asp:BoundField DataField="LBV" HeaderStyle-Font-Bold="true" HeaderText="LBV" HeaderStyle-Width="9%">
                                                            <ItemStyle HorizontalAlign="Left" VerticalAlign="Top" Wrap="True" />
                                                        </asp:BoundField>
                                                        <asp:BoundField DataField="LAV" HeaderStyle-Font-Bold="true" HeaderText="LAV" HeaderStyle-Width="9%">
                                                            <ItemStyle HorizontalAlign="Left" VerticalAlign="Top" Wrap="True" />
                                                        </asp:BoundField>
                                                        <asp:BoundField DataField="TOTAL_LAPSE" HeaderStyle-Font-Bold="true" HeaderText="Total Lapsed" HeaderStyle-Width="10%">
                                                            <ItemStyle HorizontalAlign="Left" VerticalAlign="Top" Wrap="True" />
                                                        </asp:BoundField>
                                                        <asp:BoundField DataField="STOCK_IN_HAND" HeaderStyle-Font-Bold="true" HeaderText="Stock in Hand" HeaderStyle-Width="10%">
                                                            <ItemStyle HorizontalAlign="Left" VerticalAlign="Top" Wrap="True" />
                                                        </asp:BoundField>
                                                        
                                                    </Columns>
                                                </asp:GridView>
                                            </ContentTemplate>
                                            <Triggers>
                                                <asp:PostBackTrigger ControlID="gvParent" />
                                                <%--<asp:AsyncPostBackTrigger ControlID="btnShowHide" />--%>
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
    <script src="assets/js/jquery-1.8.3.min.js" type="text/javascript"></script>
    <script type="text/javascript" src="assets/js/jequery-simple-tree-table.js"></script>
    <script src="assets/js/app.min.js"></script>

    <script src="assets/js/scripts.js"></script>

    <script>
       
        $("#click-me").click(function () {
            $(".table .toggleDisplay").toggleClass("in");
        });

        $(document).ready(function () {
            $('#collapser').click();
            $('.simple-tree-table tr th:nth-child(4), .simple-tree-table tr th:nth-child(6), .simple-tree-table tr th:nth-child(8), .simple-tree-table tr th:nth-child(9), .simple-tree-table tr td:nth-child(4), .simple-tree-table tr td:nth-child(6), .simple-tree-table tr td:nth-child(8), .simple-tree-table tr td:nth-child(9)').addClass('toggleDisplay')
        })


    </script>
    <script type="text/javascript">
        $(document).on('click', '[src*=plus]', function (e) {


            // $("[src*=plus]").live("click", function () {
            $(this).closest("tr").after("<tr><td></td><td colspan = '999'>" + $(this).next().html() + "</td></tr>")
            $(this).attr("src", "assets/img/minus.svg");
        });
        $(document).on('click', '[src*=minus]', function (e) {
            // $("[src*=minus]").live("click", function () {
            $(this).attr("src", "assets/img/plus.svg");
            $(this).closest("tr").next().remove();
        });

    </script>


    <%--    <script type="text/javascript">
        $("[src*=plus]").live("click", function () {
            $(this).closest("tr").after("<tr><td></td><td colspan = '999'>" + $(this).next().html() + "</td></tr>")
            $(this).attr("src", "assets/img/minus.svg");
        });
        $("[src*=minus]").live("click", function () {
            $(this).attr("src", "assets/img/plus.svg");
            $(this).closest("tr").next().remove();
        });
    </script>--%>
</asp:Content>