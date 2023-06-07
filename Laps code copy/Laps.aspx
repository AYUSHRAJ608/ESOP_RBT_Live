<%@ Page Title="" Language="C#" MasterPageFile="~/ESOP.Master" AutoEventWireup="true" CodeBehind="Laps.aspx.cs" Inherits="ESOP.Laps" %>


<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>ESOP-President Dashboard</title>
    <style>
        .griditem {
            text-align: left !important;
            padding-left: 30px !important;
        }

        .griditem1 {
            text-align: left !important;
            padding-left: 5px !important;
        }
        /*aside#sidebar-wrapper {
            background-image: -webkit-linear-gradient(360deg, #3eb0c8 0, #1bc2e9 100%) !important;
                background-image: -webkit-linear-gradient(360deg, #2674fe 0, #2876fd 100%) !important;
        }*/
        .main-sidebar .sidebar-menu li a {
            color: white;
        }

        h2.logo {
            /*color: #1083a5 !important;*/
            font-size: 42px !important;
        }

        .navbar-bg {
            background: white;
            box-shadow: 0 4px 25px 0 rgba(0, 0, 0, .1) !important;
        }

        .purple-sidebar .main-sidebar .sidebar-brand {
            background-color: rgba(0, 0, 0, .15);
        }

        .btn-outline-primary:not(:disabled):not(.disabled).active, .btn-outline-primary:not(:disabled):not(.disabled):active, .show > .btn-outline-primary.dropdown-toggle {
            color: #fff;
            /*background-color: #135d6f;*/
            border-color: #135d6f;
        }

        .btn-outline-primary, .btn-outline-primary.disabled {
            border-color: #135d6f;
            color: #135d6f;
        }
        /*.sidebar-mini .main-sidebar:after{
            background-image: -webkit-linear-gradient(360deg, #3eb0c8 0, #1bc2e9 100%) !important;
        }*/
        i.far.fa-bell {
            color: black;
        }
        /*.main-sidebar .sidebar-brand{
            background: #0000001f !important;
        }*/
        /*.btn-group {
            height: 22px;
        }*/
        hidden {
            display: none;
        }
    </style>


</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ScriptManager ID="script" runat="server"></asp:ScriptManager>
    <div class="sidebar-mini">
        <div class="loader"></div>
        <div id="app">
            <div class="main-wrapper main-wrapper-1">
                <div class="navbar-bg"></div>
                <div class="main-content" style="padding-top: 55px; padding-left: 40px; padding-right: 10px;">
                    <nav aria-label="breadcrumb">
                        <ol class="breadcrumb">
                            <li class="breadcrumb-item"><a href="admin-dashboard.aspx">Home</a></li>
                            <li class="breadcrumb-item"><a href="settings.aspx">Masters</a></li>
                            <li class="breadcrumb-item active" aria-current="page">Lapse</li>
                        </ol>
                    </nav>
                    <section class="section">
                        <div class="section-header">
                            <div class="row">
                                <div class="col-lg-12 col-md-12 col-12 col-sm-12">
                                    <div class="card" style="height: 100%;">
                                        <div class="card-header">
                                            <%--<h4 style="font-size: 16px; line-height: 28px; padding-right: 10px; margin-bottom: 0; display: block; width: 100%;">Detailed ESOP Data  <a href="javascript:void(0)" id="click-me" class="btn btn-outline-info align-right" style="float: right;">Expand Data</a></h4>--%>
                                            <h4 class="col-md-12">Lapse List
                                            <div class="buttons pull-right" id="showhidebtn">
                                                <asp:Button ID="btn_Lapes" runat="server" CommandName="Lapse" CausesValidation="false" OnClick="btn_Lapes_Click"
                                                    Text="Lapes" CssClass="btn badge badge-success badge-shadow"></asp:Button>
                                            </div>
                                            </h4>
                                        </div>
                                        <div class="col-md-12 table-responsive" style="margin-bottom: 0; padding-top: 15px; padding-right: 15px">
                                            <asp:UpdatePanel ID="upd" UpdateMode="Conditional" runat="server">
                                                <ContentTemplate>
                                                    <asp:GridView ID="gvParent" runat="server" AutoGenerateColumns="false" ShowHeaderWhenEmpty="true"
                                                        CssClass="table table-bordered simple-tree-table" DataKeyNames="ECODE,VESTED_PENDING,EXERCISED_PENDING"
                                                        Style="border-collapse: separate;" EmptyDataText="No Record Found" EmptyDataRowStyle-CssClass="Empty" OnRowCommand="gvParent_RowCommand" OnRowDataBound="gvParent_RowDataBound">
                                                        <Columns>
                                                            <asp:TemplateField HeaderStyle-Width="1%">
                                                                <ItemTemplate>
                                                                    <img alt="" style="cursor: pointer" src="assets/img/plus.svg" height="20px" width="20px" />
                                                                    <asp:Panel ID="pnlOrders" runat="server" Style="display: none">
                                                                        <asp:GridView ID="gvChild" runat="server" AutoGenerateColumns="false" CssClass="table table-bordered simple-tree-table"
                                                                            Style="border-collapse: separate; border-spacing: 4px;" ShowHeader="false" OnRowDataBound="gvChild_RowDataBound">
                                                                            <Columns>
                                                                                <asp:TemplateField HeaderStyle-Width="1%" ItemStyle-Width="3%" ItemStyle-HorizontalAlign="Left">
                                                                                    <ItemTemplate>
                                                                                        <img alt="" style="cursor: pointer" src="assets/img/plus.svg" height="20px" width="20px" />
                                                                                        <asp:Panel ID="pnlOrders1" runat="server" Style="display: none">
                                                                                            <asp:GridView ID="gvSubChild" runat="server" AutoGenerateColumns="false" CssClass="table table-bordered simple-tree-table"
                                                                                                Style="border-collapse: separate; border-spacing: 4px;" ShowHeader="true" OnRowDataBound="gvSubChild_RowDataBound" OnRowCommand="gvSubChild_RowCommand">
                                                                                                <Columns>
                                                                                                    <asp:TemplateField HeaderText="Vesting Percent" HeaderStyle-Font-Bold="true" FooterStyle-Font-Bold="true"
                                                                                                        HeaderStyle-Width="12%">
                                                                                                        <ItemTemplate>
                                                                                                            <asp:Label ID="lblVPERCENTAGE" runat="server" Text='<%#Eval("VPERCENTAGE") %>' />
                                                                                                            <asp:HiddenField ID="Hd_Id" runat="server" Value='<%# Bind("ID") %>' />
                                                                                                        </ItemTemplate>
                                                                                                    </asp:TemplateField>
                                                                                                    <asp:TemplateField HeaderText="Vesting Date" HeaderStyle-Font-Bold="true" FooterStyle-Font-Bold="true"
                                                                                                        HeaderStyle-Width="10%">
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
                                                                                                    <asp:TemplateField HeaderText="Vested" HeaderStyle-Font-Bold="true" FooterStyle-Font-Bold="true"
                                                                                                        HeaderStyle-Width="8%">
                                                                                                        <ItemTemplate>
                                                                                                            <asp:Label ID="lblVESTED" runat="server" Text='<%#Eval("VESTED") %>' />
                                                                                                        </ItemTemplate>
                                                                                                    </asp:TemplateField>
                                                                                                    <asp:TemplateField HeaderText="Exercised" HeaderStyle-Font-Bold="true" FooterStyle-Font-Bold="true"
                                                                                                        HeaderStyle-Width="8%">
                                                                                                        <ItemTemplate>
                                                                                                            <asp:Label ID="lblEXERCISED" runat="server" Text='<%#Eval("EXERCISED") %>' />
                                                                                                        </ItemTemplate>
                                                                                                    </asp:TemplateField>
                                                                                                    <asp:TemplateField HeaderText="Pending for Vesting" HeaderStyle-Font-Bold="true" FooterStyle-Font-Bold="true"
                                                                                                        HeaderStyle-Width="8%">
                                                                                                        <ItemTemplate>
                                                                                                            <asp:Label ID="lblVESTED_PENDING" runat="server" Text='<%#Eval("VESTED_PENDING") %>' />
                                                                                                        </ItemTemplate>
                                                                                                    </asp:TemplateField>
                                                                                                    <asp:TemplateField HeaderText="Sell" HeaderStyle-Font-Bold="true" FooterStyle-Font-Bold="true"
                                                                                                        HeaderStyle-Width="8%">
                                                                                                        <ItemTemplate>
                                                                                                            <asp:Label ID="lblSALE" runat="server" Text='<%#Eval("SALE") %>' />
                                                                                                        </ItemTemplate>
                                                                                                    </asp:TemplateField>
                                                                                                    <asp:TemplateField HeaderText="Pending for Excercise" HeaderStyle-Font-Bold="true" FooterStyle-Font-Bold="true"
                                                                                                        HeaderStyle-Width="8%">
                                                                                                        <ItemTemplate>
                                                                                                            <asp:Label ID="lblEXERCISED_PENDING" runat="server" Text='<%#Eval("EXERCISED_PENDING") %>' />
                                                                                                        </ItemTemplate>
                                                                                                    </asp:TemplateField>
                                                                                                    <asp:TemplateField HeaderText="Lapse Date" HeaderStyle-CssClass="text-nowrap" HeaderStyle-Font-Bold="true" HeaderStyle-Width="8%">
                                                                                                        <ItemTemplate>
                                                                                                            <asp:Label ID="lblLapseDt" runat="server" Text='<%#Eval("lapsDate")%>' Visible="true"></asp:Label>
                                                                                                        </ItemTemplate>
                                                                                                    </asp:TemplateField>
                                                                                                    <asp:TemplateField HeaderText="Total Lapsed" HeaderStyle-Font-Bold="true" FooterStyle-Font-Bold="true"
                                                                                                        HeaderStyle-Width="8%">
                                                                                                        <ItemTemplate>
                                                                                                            <asp:Label ID="lblTOTAL_LAPSE" runat="server" Text='<%#Eval("TOTAL_LAPSE") %>' />
                                                                                                        </ItemTemplate>
                                                                                                    </asp:TemplateField>
                                                                                                    <asp:TemplateField HeaderText="LBV" HeaderStyle-Font-Bold="true" FooterStyle-Font-Bold="true"
                                                                                                        HeaderStyle-Width="7%">
                                                                                                        <ItemTemplate>
                                                                                                            <asp:Label ID="lblLBV" runat="server" Text='<%#Eval("LBV") %>' Style="display: none" />
                                                                                                        </ItemTemplate>
                                                                                                        <ItemTemplate>
                                                                                                            <div class="remark">
                                                                                                                <asp:TextBox ID="TxtLBV" runat="server" CssClass="form-control"
                                                                                                                    AutoPostBack="true" Text="" placeholder="Enter LBV Lapse" Width="90" OnTextChanged="TxtLBV_TextChanged"></asp:TextBox>
                                                                                                            </div>
                                                                                                        </ItemTemplate>
                                                                                                    </asp:TemplateField>
                                                                                                    <asp:TemplateField HeaderText="LAV" HeaderStyle-Font-Bold="true" FooterStyle-Font-Bold="true"
                                                                                                        HeaderStyle-Width="7%">
                                                                                                        <ItemTemplate>
                                                                                                            <asp:Label ID="lblLAV" runat="server" Text='<%#Eval("LAV") %>' Style="display: none" />
                                                                                                        </ItemTemplate>
                                                                                                        <ItemTemplate>
                                                                                                            <div class="remark">
                                                                                                                <asp:TextBox ID="TxtLAV" runat="server" CssClass="form-control"
                                                                                                                    AutoPostBack="true" Text="" placeholder="Enter LAV Lapse" Width="90" OnTextChanged="TxtLAV_TextChanged"></asp:TextBox>
                                                                                                            </div>
                                                                                                        </ItemTemplate>
                                                                                                    </asp:TemplateField>
                                                                                                    <asp:TemplateField HeaderText="Enter Lapse" Visible="false">
                                                                                                        <ItemTemplate>
                                                                                                            <div class="remark">
                                                                                                                <asp:TextBox ID="TxtLaps" runat="server" CssClass="form-control"
                                                                                                                    AutoPostBack="false" Text="" placeholder="Enter Lapse" Width="90"></asp:TextBox>
                                                                                                            </div>
                                                                                                        </ItemTemplate>
                                                                                                    </asp:TemplateField>
                                                                                                    <%--<asp:TemplateField HeaderText="Action" HeaderStyle-Width="10%">
                                                                                                        <ItemTemplate>
                                                                                                            <div class="btn-group">
                                                                                                                <asp:Button ID="BtnLaps" class="btn btn-info btn-lg" runat="server" CommandName="Lapse" CausesValidation="false" Text="Lapse"></asp:Button>
                                                                                                            </div>
                                                                                                        </ItemTemplate>
                                                                                                    </asp:TemplateField>--%>
                                                                                                    <asp:TemplateField HeaderText="Stock in Hand" HeaderStyle-Font-Bold="true" FooterStyle-Font-Bold="true"
                                                                                                        HeaderStyle-Width="8%">
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
                                                                                        <asp:HiddenField ID="HdEmpCodeTranchwise" runat="server" Value='<%# Bind("ECODE") %>' />
                                                                                    </ItemTemplate>
                                                                                </asp:TemplateField>
                                                                            </Columns>
                                                                        </asp:GridView>
                                                                    </asp:Panel>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="Employee Name" HeaderStyle-CssClass="text-nowrap" HeaderStyle-Font-Bold="true" HeaderStyle-Width="12%" ItemStyle-CssClass="griditem1">
                                                                <ItemTemplate>
                                                                    <asp:Label ID="lblEmp" runat="server" Text='<%#Eval("EMP_NAME")%>' Visible="true"></asp:Label>
                                                                    <asp:HiddenField ID="IsExpanded" ClientIDMode="AutoID" runat="server" />
                                                                    <asp:HiddenField ID="HdEmpCode" runat="server" Value='<%# Bind("ECODE") %>' />
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <%-- <asp:TemplateField HeaderText="Manager Name" HeaderStyle-CssClass="text-nowrap" HeaderStyle-Font-Bold="true" HeaderStyle-Width="12%" ItemStyle-CssClass="griditem1">
                                                                <ItemTemplate>
                                                                    <asp:Label ID="LblMangeName" runat="server" Text='<%#Eval("APPRAISER_NAME")%>' Visible="true"></asp:Label>
                                                                    <asp:HiddenField ID="HdEmpCode" runat="server" Value='<%# Bind("ECODE") %>' />
                                                                </ItemTemplate>
                                                            </asp:TemplateField>--%>
                                                            <asp:BoundField DataField="ACTIVE" HeaderStyle-Font-Bold="true" HeaderText="Status" HeaderStyle-Width="8%"></asp:BoundField>

                                                            <asp:TemplateField HeaderText="Granted" HeaderStyle-CssClass="text-nowrap" HeaderStyle-Font-Bold="true" HeaderStyle-Width="8%">
                                                                <ItemTemplate>
                                                                    <asp:Label ID="lblVNAME" runat="server" Text='<%#Eval("GRANTED")%>' Visible="true"></asp:Label>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:BoundField DataField="VESTED" HeaderStyle-Font-Bold="true" HeaderText="Vested" HeaderStyle-Width="8%"></asp:BoundField>
                                                            <asp:BoundField DataField="VESTED_PENDING" HeaderStyle-Font-Bold="true" HeaderText="Pending for Vesting" HeaderStyle-Width="8%"></asp:BoundField>
                                                            <asp:BoundField DataField="EXERCISED" HeaderStyle-Font-Bold="true" HeaderText="Exercised" HeaderStyle-Width="8%"></asp:BoundField>
                                                            <asp:BoundField DataField="EXERCISED_PENDING" HeaderStyle-Font-Bold="true" HeaderText="Pending for Excercise" HeaderStyle-Width="8%"></asp:BoundField>
                                                            <asp:BoundField DataField="SALE" HeaderStyle-Font-Bold="true" HeaderText="Sell" HeaderStyle-Width="8%"></asp:BoundField>


                                                            <asp:BoundField DataField="LBV" HeaderStyle-Font-Bold="true" HeaderText="LBV" HeaderStyle-Width="6%"></asp:BoundField>
                                                            <asp:BoundField DataField="LAV" HeaderStyle-Font-Bold="true" HeaderText="LAV" HeaderStyle-Width="6%"></asp:BoundField>
                                                            <asp:BoundField DataField="TOTAL_LAPSE" HeaderStyle-Font-Bold="true" HeaderText="Total Lapsed" HeaderStyle-Width="8%"></asp:BoundField>
                                                            <asp:BoundField DataField="STOCK_IN_HAND" HeaderStyle-Font-Bold="true" HeaderText="Stock in Hand" HeaderStyle-Width="8%"></asp:BoundField>
                                                            <%--<asp:TemplateField HeaderText="Enter Lapse">
                                                                <ItemTemplate>
                                                                    <div class="remark">
                                                                        <asp:TextBox ID="TxtLaps" runat="server" CssClass="form-control" OnTextChanged="TxtLaps_TextChanged"
                                                                            AutoPostBack="true" onkeypress="return isNumberKey(this,event)" placeholder="Enter Lapse" Width="90"></asp:TextBox>
                                                                    </div>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>--%>
                                                            <%--<asp:TemplateField HeaderText="Action" HeaderStyle-Width="10%">
                                                                <ItemTemplate>
                                                                    <div class="btn-group">
                                                                        <asp:Button ID="BtnLaps" class="btn btn-info btn-lg" runat="server" CommandName="Laps" CausesValidation="false" Text="Lapse"></asp:Button>
                                                                    </div>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>--%>
                                                        </Columns>
                                                    </asp:GridView>
                                                </ContentTemplate>
                                                <Triggers>
                                                    <asp:PostBackTrigger ControlID="gvParent" />
                                                </Triggers>
                                            </asp:UpdatePanel>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>

                    </section>
                </div>
            </div>
        </div>
    </div>
    <!-- General JS Scripts -->
    <script src="assets/js/app.min.js"></script>

    <script src="assets/js/page/index.js"></script>
    <!-- Template JS File -->
    <script src="assets/js/scripts.js"></script>
    <script src="assets/bundles/jquery.sparkline.min.js"></script>
    <script type="text/javascript" src="assets/js/jequery-simple-tree-table.js"></script>

    <%--<script>
         
         $("#click-me").click(function() {
         $(".table .toggleDisplay").toggleClass("in");
         }); 

         $(document).ready(function(){
           $('#collapser').click();
           $('.simple-tree-table tr th:nth-child(6),.simple-tree-table tr th:nth-child(8),.simple-tree-table tr th:nth-child(10),.simple-tree-table tr th:nth-child(11),.simple-tree-table tr td:nth-child(6),.simple-tree-table tr td:nth-child(11),.simple-tree-table tr td:nth-child(10),.simple-tree-table tr td:nth-child(8)').addClass('toggleDisplay')
         })
      </script>--%>


    <script type="text/javascript">
        $(document).on('click', '[src*=plus]', function (e) {
            $(this).closest("tr").after("<tr><td></td><td colspan = '999'>" + $(this).next().html() + "</td></tr>")
            $(this).attr("src", "assets/img/minus.svg");
        });
        $(document).on('click', '[src*=minus]', function (e) {
            $(this).attr("src", "assets/img/plus.svg");

            $(this).closest("tr").next().remove();
        });
    </script>

    <script type="text/javascript">
        $(function hide() {

        });
    </script>

    <%-- <script type="text/javascript">
        $(document).on('click', '[src*=plus]', function (e) {
            $(this).closest("tr").after("<tr><td></td><td colspan = '999'>" + $(this).next().html() + "</td></tr>")
            $(this).attr("src", "assets/img/minus.svg");

            $("input", $(this).closest("tr").next()).each(function () {
                alert('hi')
                this.value = this.value.substring(',', '');
            });
        });
        $(document).on('click', '[src*=minus]', function (e) {
            $(this).attr("src", "assets/img/plus.svg");
            $(this).closest("tr").next().remove();
        });
    </script>--%>

    <script>
        function Count(text) {
            // alert();
            //asp.net textarea maxlength doesnt work; do it by hand
            var maxlength = 500; //set your value here (or add a parm and pass it in)
            var object = document.getElementById(text.id)  //get your object
            if (object.value.length > maxlength) {
                object.focus(); //set focus to prevent jumping
                object.value = text.value.substring(0, maxlength); //truncate the value
                object.scrollTop = object.scrollHeight; //scroll to the end to prevent jumping
                return false;
            }
            return true;
        }

    </script>
    <script>
        function isNumberKey(txt, evt) {
            //    var charCode = (evt.which) ? evt.which : evt.keyCode;
            //    if (charCode == 46) {
            //        //Check if the text already contains the . character
            //        if (txt.value.indexOf('.') === -1) {
            //            return true;
            //        } else {
            //            return false;
            //        }
            //    } else {
            //        if (charCode > 31 &&
            //          (charCode < 48 || charCode > 57))
            //            return false;
            //    }
            return true;
        }
    </script>
</asp:Content>

