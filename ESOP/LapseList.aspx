<%@ Page Title="" Language="C#" MasterPageFile="~/ESOP.Master" AutoEventWireup="true" CodeBehind="LapseList.aspx.cs" EnableEventValidation="false" Inherits="ESOP.LapseList" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>ESOP-Lapse</title>

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

    <script src="assets/js/jquery-1.12.4.js" type="text/javascript"></script>
    <script src="assets/js/jquery.dataTables-1.10.20.min.js"></script>
    <link href="assets/css/jquery-ui-1.12.1.css" rel="stylesheet" />
    <script src="assets/js/jquery-ui-1.12.1.js" type="text/javascript"></script>

    <%--<script src="https://cdnjs.cloudflare.com/ajax/libs/bootstrap-datepicker/1.9.0/js/bootstrap-datepicker.min.js" type="text/javascript"></script>
    <link href="https://cdnjs.cloudflare.com/ajax/libs/bootstrap-datepicker/1.9.0/css/bootstrap-datepicker.css" rel="stylesheet" />--%>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ScriptManager ID="script" runat="server"></asp:ScriptManager>
    <script>
        $(document).ready(function () {
            $(function () {
                $.noConflict();
                var from = $('input[type=text][id*="txtDateOfLapse"]').datepicker({
                    minDate: -1,
                    dateFormat: "dd-mm-yy",
                    changeMonth: true,
                    changeYear: true,
                    yearRange: "-50:+50",

                });
            });

            $(function () {
                Sys.WebForms.PageRequestManager.getInstance().add_endRequest(bindPicker);
                bindPicker();
            });

            // bindPicker();
            function bindPicker() {
                //debugger;
                var from = $('input[type=text][id*="txtDateOfLapse"]').datepicker({
                    minDate: -1,
                    dateFormat: "dd-mm-yy",
                    changeMonth: true,
                    changeYear: true,
                    yearRange: "-50:+50",

                });
            }

            $('[id*=checkAll]').click(function () {
                $("[id*='chk']").attr('checked', this.checked);
            });

            var prm = Sys.WebForms.PageRequestManager.getInstance();
            prm.add_endRequest(function () {
                $('[id*=checkAll]').click(function () {
                    //debugger;
                    $("[id*='chk']").attr('checked', this.checked);
                });
            });
        });
    </script>
    <script type="text/javascript">
        function BtnGrvApprove_Click() {
            //  debugger;
            var isValid = false;
            var gridView = document.getElementById('<%= gvParent.ClientID %>');
            for (var i = 1; i < gridView.rows.length; i++) {
                var inputs = gridView.rows[i].getElementsByTagName('input');
                if (inputs != null) {
                    if (inputs[0].type == "checkbox") {
                        if (inputs[0].checked) {
                            isValid = true;
                            // return confirm('Are you sure want to Aprove LAV?');
                            debugger;

                            if (confirm("Are you sure you want to Lapse the LAV/LBV of the checked employee?")) {
                                return true;
                            } else {
                                return false;
                            }

                        }
                    }
                }
            }
            return false;
        }
    </script>

    <script type="text/javascript">
        function BtnGrvReject_Click2() {
           // debugger;
            var isValid = false;
            var gridView = document.getElementById('<%= gvParent.ClientID %>');
            for (var i = 1; i < gridView.rows.length; i++) {
                var inputs = gridView.rows[i].getElementsByTagName('input');
                if (inputs != null) {
                    if (inputs[0].type == "checkbox") {
                        if (inputs[0].checked) {
                            isValid = true;
                            debugger;
                            if (confirm("Are you sure want to Extend the Lapse Date?")) {
                                return true;
                            } else {
                                event.preventDefault();
                                return false;
                            }

                        }
                    }
                }
            }
            return false;
        }
    </script>
    <script type="text/javascript">
        function bulkvalidateCheckBoxesapprove() {
            //  debugger;
            var isValid = false;
            var gridView = document.getElementById('<%= gvParent.ClientID %>');
            for (var i = 1; i < gridView.rows.length; i++) {
                var inputs = gridView.rows[i].getElementsByTagName('input');
                if (inputs != null) {
                    if (inputs[0].type == "checkbox") {
                        if (inputs[0].checked) {
                            isValid = true;

                            if (confirm("Are you sure you want to Lapse the LAV/LBV of the checked employees?")) {
                                return true;
                            } else {
                                return false;
                            }

                        }
                    }
                }
            }
            alert("Please select atleast one checkbox");
            return false;
        }
    </script>
    <script type="text/javascript">
        function bulkvalidateCheckBoxesreject() {
            //debugger;
            var isValid = false;
            var gridView = document.getElementById('<%= gvParent.ClientID %>');
            for (var i = 1; i < gridView.rows.length; i++) {
                var inputs = gridView.rows[i].getElementsByTagName('input');
                if (inputs != null) {
                    if (inputs[0].type == "checkbox") {
                        if (inputs[0].checked) {
                            isValid = true;
                            if (confirm("Are you sure want to Extend the Lapse Date?")) {
                                return true;
                            } else {
                                return false;
                            }

                        }
                    }
                }
            }
            alert("Please select atleast one checkbox");

            return false;
        }
    </script>

    <script src="assets/js/jquery-1.12.4.js" type="text/javascript"></script>
    <script src="assets/js/jquery.dataTables-1.10.20.min.js"></script>

    <link href="Scripts/jquery.dataTables.min.css" rel="stylesheet" />
    <link href="Scripts/dataTables.bootstrap4.min.css" rel="stylesheet" />

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
                                            <h4>Lapse List
                                            </h4>
                                            <div class="offset-md-7 buttons" style="margin-left: 60.333333%" id="showhidebtn">
                                                <asp:Button ID="btn_bulkApprove" runat="server" CommandName="Bulk Approve" CausesValidation="false" OnClick="btn_bulkApprove_Click" OnClientClick="return bulkvalidateCheckBoxesapprove();"
                                                    Text="Bulk LAV/LBV Approve" CssClass="btn badge-success badge-shadow"></asp:Button>
                                                <asp:Button ID="btn_bulkReject" runat="server" CommandName="Bulk Reject" CausesValidation="false" OnClick="btn_bulkReject_Click" OnClientClick="return bulkvalidateCheckBoxesreject();"
                                                    Text="Bulk Extend Date" CssClass="btn badge-danger badge-shadow"></asp:Button>
                                            </div>
                                        </div>
                                        <div id="showmsg" runat="server"></div>
                                        <div class="col-md-12 table-responsive" style="margin-bottom: 0; padding-top: 15px; padding-right: 15px">
                                            <asp:UpdatePanel ID="upd" UpdateMode="Conditional" runat="server">
                                                <ContentTemplate>
                                                    <asp:GridView ID="gvParent" runat="server" AutoGenerateColumns="false" ShowHeaderWhenEmpty="true"
                                                        CssClass="table table-bordered simple-tree-table" DataKeyNames="ECODE,VESTED_PENDING,EXERCISED_PENDING"
                                                        Style="border-collapse: separate;" EmptyDataText="No Record Found" EmptyDataRowStyle-CssClass="Empty" OnRowCommand="gvParent_RowCommand" OnRowDataBound="gvParent_RowDataBound">
                                                        <Columns>
                                                            <asp:TemplateField>
                                                                <HeaderTemplate>
                                                                    <asp:CheckBox ID="checkAll" runat="server" />
                                                                </HeaderTemplate>
                                                                <ItemTemplate>
                                                                    <asp:CheckBox ID="chk" runat="server" />
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="Employee ID" HeaderStyle-CssClass="text-nowrap" HeaderStyle-Font-Bold="true" HeaderStyle-Width="12%" ItemStyle-CssClass="griditem1">
                                                                <ItemTemplate>
                                                                    <asp:Label ID="lblECODE" runat="server" Text='<%#Eval("ECODE")%>' Visible="true"></asp:Label>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="Employee Name" HeaderStyle-CssClass="text-nowrap" HeaderStyle-Font-Bold="true" HeaderStyle-Width="12%" ItemStyle-CssClass="griditem1">
                                                                <ItemTemplate>
                                                                    <asp:Label ID="lblEmp" runat="server" Text='<%#Eval("EMP_NAME")%>' Visible="true"></asp:Label>

                                                                    <asp:HiddenField ID="HdEmpCode" runat="server" Value='<%# Bind("ECODE") %>' />
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:BoundField DataField="ACTIVE" HeaderStyle-Font-Bold="true" HeaderText="Status" HeaderStyle-Width="8%"></asp:BoundField>
                                                            <asp:TemplateField HeaderText="Vesting Percent" HeaderStyle-Font-Bold="true" FooterStyle-Font-Bold="true"
                                                                HeaderStyle-Width="12%">
                                                                <ItemTemplate>
                                                                    <asp:Label ID="lblVPERCENTAGE" runat="server" Text='<%#Eval("VPERCENTAGE") %>' />
                                                                    <asp:HiddenField ID="Hd_Id" runat="server" Value='<%# Bind("ID") %>' />
                                                                    <asp:HiddenField ID="hdnGrantID" runat="server" Value='<%# Bind("grant_id") %>' />
                                                                    <asp:HiddenField ID="hdnVestingID" runat="server" Value='<%# Bind("v_detail_id") %>' />
                                                                    <asp:HiddenField ID="IsExpanded" runat="server" />
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="Pending for Vesting" HeaderStyle-CssClass="text-nowrap" HeaderStyle-Font-Bold="true" HeaderStyle-Width="8%">
                                                                <ItemTemplate>
                                                                    <asp:Label ID="lblVESTED_PENDING" runat="server" Text='<%#Eval("VESTED_PENDING") %>' />
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:BoundField DataField="VESTED" HeaderStyle-Font-Bold="true" HeaderText="Vested" HeaderStyle-Width="8%"></asp:BoundField>
                                                            <asp:TemplateField HeaderText="Granted" HeaderStyle-CssClass="text-nowrap" HeaderStyle-Font-Bold="true" HeaderStyle-Width="8%">
                                                                <ItemTemplate>
                                                                    <asp:Label ID="lblVNAME" runat="server" Text='<%#Eval("GRANTED")%>' Visible="true"></asp:Label>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <%--<asp:BoundField DataField="VESTED_PENDING" HeaderStyle-Font-Bold="true" HeaderText="Pending for Vesting" HeaderStyle-Width="8%"></asp:BoundField>--%>
                                                            <asp:BoundField DataField="EXERCISED" HeaderStyle-Font-Bold="true" HeaderText="Exercised" HeaderStyle-Width="8%"></asp:BoundField>

                                                            <asp:TemplateField HeaderText="Pending for Excercise" HeaderStyle-CssClass="text-nowrap" HeaderStyle-Font-Bold="true" HeaderStyle-Width="8%">
                                                                <ItemTemplate>
                                                                    <asp:Label ID="lblEXERCISED_PENDING" runat="server" Text='<%#Eval("EXERCISED_PENDING") %>' />
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <%--<asp:BoundField DataField="EXERCISED_PENDING" HeaderStyle-Font-Bold="true" HeaderText="Pending for Excercise" HeaderStyle-Width="8%"></asp:BoundField>--%>
                                                            <asp:BoundField DataField="SALE" HeaderStyle-Font-Bold="true" HeaderText="Sale" HeaderStyle-Width="8%"></asp:BoundField>
                                                            <asp:BoundField DataField="LBV" HeaderStyle-Font-Bold="true" HeaderText="LBV" HeaderStyle-Width="6%"></asp:BoundField>
                                                            <asp:BoundField DataField="LAV" HeaderStyle-Font-Bold="true" HeaderText="LAV" HeaderStyle-Width="6%"></asp:BoundField>
                                                            <asp:BoundField DataField="TOTAL_LAPSE" HeaderStyle-Font-Bold="true" HeaderText="Total Lapsed" HeaderStyle-Width="8%"></asp:BoundField>
                                                            <asp:BoundField DataField="STOCK_IN_HAND" HeaderStyle-Font-Bold="true" HeaderText="Stock in Hand" HeaderStyle-Width="8%"></asp:BoundField>

                                                            <asp:TemplateField HeaderText="Vesting Date" HeaderStyle-Font-Bold="true" FooterStyle-Font-Bold="true"
                                                                HeaderStyle-Width="10%">
                                                                <ItemTemplate>
                                                                    <asp:Label ID="lblVESTING_DATE" runat="server" Text='<%#Eval("VESTING_DATE") %>' />
                                                                </ItemTemplate>
                                                            </asp:TemplateField>

                                                            <asp:TemplateField HeaderText="Lapse Date" HeaderStyle-CssClass="text-nowrap" HeaderStyle-Font-Bold="true" HeaderStyle-Width="8%">
                                                                <ItemTemplate>
                                                                    <asp:Label ID="lblLapseDt" runat="server" Text='<%#Eval("lapseDate")%>' Visible="true"></asp:Label>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>

                                                            <asp:TemplateField HeaderText="LBV" HeaderStyle-Font-Bold="true" FooterStyle-Font-Bold="true"
                                                                HeaderStyle-Width="5%">
                                                                <ItemTemplate>
                                                                    <asp:Label ID="lblLBV" runat="server" Text='<%#Eval("LBV") %>' Style="display: none" />
                                                                </ItemTemplate>
                                                                <ItemTemplate>
                                                                    <div class="remark">
                                                                        <asp:UpdatePanel ID="updLBV" UpdateMode="Conditional" runat="server">
                                                                            <ContentTemplate>
                                                                                <asp:TextBox ID="TxtLBV" runat="server" CssClass="form-control"
                                                                                    AutoPostBack="true" Text="" placeholder="Enter LBV Lapse" Width="90" OnTextChanged="TxtLBV_TextChanged"></asp:TextBox>
                                                                            </ContentTemplate>
                                                                            <Triggers>
                                                                                <asp:AsyncPostBackTrigger ControlID="TxtLBV" EventName="TextChanged" />
                                                                            </Triggers>
                                                                        </asp:UpdatePanel>
                                                                    </div>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="LAV" HeaderStyle-Font-Bold="true" FooterStyle-Font-Bold="true"
                                                                HeaderStyle-Width="5%">
                                                                <ItemTemplate>
                                                                    <asp:Label ID="lblLAV" runat="server" Text='<%#Eval("LAV") %>' Style="display: none" />
                                                                </ItemTemplate>
                                                                <ItemTemplate>
                                                                    <div class="remark">
                                                                        <asp:UpdatePanel ID="updLAV" UpdateMode="Conditional" runat="server">
                                                                            <ContentTemplate>
                                                                                <asp:TextBox ID="TxtLAV" runat="server" CssClass="form-control"
                                                                                    AutoPostBack="true" Text="" placeholder="Enter LAV Lapse" Width="90" OnTextChanged="TxtLAV_TextChanged"></asp:TextBox>
                                                                            </ContentTemplate>
                                                                            <Triggers>
                                                                                <asp:AsyncPostBackTrigger ControlID="TxtLAV" EventName="TextChanged" />
                                                                            </Triggers>
                                                                        </asp:UpdatePanel>
                                                                    </div>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="NewLapseDate">
                                                                <ItemTemplate>
                                                                    <div class="remark form-group thiscontrol">
                                                                        <asp:TextBox ID="txtDateOfLapse" runat="server" placeholder="dd-mm-yyyy" class="now form-control"></asp:TextBox>
                                                                    </div>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="Remark" HeaderStyle-Width="10%">
                                                                <ItemTemplate>
                                                                    <div class="remark">
                                                                        <asp:TextBox ID="TxtRemark" runat="server" placeholder="Enter Remark" Width="" TextMode="MultiLine" ondrop="return false;" ondrag="return false;" CausesValidation="false"></asp:TextBox>
                                                                    </div>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="Action" HeaderStyle-Width="10%">
                                                                <ItemTemplate>
                                                                    <div class="btn-group">
                                                                        <asp:Button ID="BtnGrvApprove" runat="server" CommandName="Approve" OnClick="BtnGrvApprove_Click" CausesValidation="false" CommandArgument=''
                                                                            Text="LAV/LBV Approve" CssClass="btn badge-success badge-shadow" OnClientClick="return BtnGrvApprove_Click()"></asp:Button>
                                                                        <asp:Button ID="BtnGrvReject" runat="server" CommandName="Reject" OnClick="BtnGrvReject_Click" CausesValidation="false" CommandArgument=''
                                                                            Text="Extend Date" CssClass="btn badge-danger badge-shadow" OnClientClick="BtnGrvReject_Click2()"></asp:Button>
                                                                    </div>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
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
        $(document).ready(function () {
            var prm = Sys.WebForms.PageRequestManager.getInstance();

            <%--prm.add_endRequest(function (sender, e) {
                if ($.fn.dataTable.isDataTable('#<%=gvParent.ClientID %>')) {
                    $('#<%=gvParent.ClientID %>').DataTable().destroy();
                }

                debugger;
                var table = $("#ContentPlaceHolder1_gvParent").DataTable({
                    destroy: true,
                    lengthMenu: [[-1, 5, 10], ["All", 5, 10]],
                    order: [],
                    columnDefs: [{ "orderable": "false", "targets": [0, -1] }],
                    bRetrieve: true,
                    stateSave: true
                });
                // bind data table on first page load

                //table.search('').columns().search('').draw();
            });--%>

        });

        $(function () {
            debugger;
            $.noConflict();
            var table = $("#ContentPlaceHolder1_gvParent").DataTable({
                destroy: true,
                bLengthChange: true,
                lengthMenu: [[-1, 5, 10], ["All", 5, 10]],
                bFilter: true,
                columnDefs: [{ "orderable": "false", "targets": [0, -1] }],
                bPaginate: true,
                stateSave: true
            });

            //table.search('').columns().search('').draw();
        });

    </script>

    <script type="text/javascript">
        $(document).on('click', '[src*=plus]', function (e) {
            //alert("plus");
            //console.log($(this).closest("tr").html());
            //console.log($(this).next().next().html());

            $(this).closest("tr").after("<tr><td></td><td colspan = '999'>" + $(this).next().next().html() + "</td></tr>")
            $(this).attr("src", "assets/img/minus.svg");
            $(this).closest('tr').find('[id*=IsExpanded]').val(1);

            $(this).closest('tr').find('[id*=IsalsoExpanded]').val(1);
            //alert($(this).closest('tr').find('[id*=IsExpanded]').val());
        });

        $(document).on('click', '[src*=minus]', function (e) {
            //alert("minus");
            //console.log($(this).closest("tr").html());
            //console.log($(this).next().next().html());

            $(this).attr("src", "assets/img/plus.svg");
            $(this).closest("tr").next().remove();
            $(this).closest('tr').find('[id*=IsExpanded]').val("");

            $(this).closest('tr').find('[id*=IsalsoExpanded]').val("");
            //alert($(this).closest('tr').find('[id*=IsExpanded]').val());
        });

        $(function () {
            //$("[id*=IsExpanded]").each(function () {
            //    if ($(this).val() == "1") {
            //        $(this).closest("tr").parent().closest("td").parent().closest("tr").after("<tr><td></td><td colspan = '999'>" + $(this).closest("tr").parent().parent().parent().html() + "</td></tr>");
            //        $(this).closest("tr").parent().closest("td").find("img").attr("src", "assets/img/minus.svg");
            //    }
            //});

            $("[id*=IsalsoExpanded]").each(function () {
                if ($(this).val() == "1") {
                    console.log($(this).closest("td").find("div").html());
                    $(this).closest("tr").after("<tr><td></td><td colspan = '999'>" + $(this).closest("td").find("div").html() + "</td></tr>");
                    $(this).closest("td").find("img").attr("src", "assets/img/minus.svg");
                }
            });
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
