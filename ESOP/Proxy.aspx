<%@ Page Title="" Language="C#" MasterPageFile="~/ESOP.Master" AutoEventWireup="true" CodeBehind="Proxy.aspx.cs" Inherits="ESOP.Proxy" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ScriptManager ID="script" runat="server"></asp:ScriptManager>

    <script language="javascript" type="text/javascript">
        function validate() {

            if (document.getElementById("<%=ddlUserName.ClientID %>").value == 0) {
                alert("Please Select User Name");
                //document.getElementById("<%=ddlUserName.ClientID %>").focus();
                return false;
            }

        }
    </script>

    <style>
        .mt-5, .my-5 {
            margin-top: 1rem !important;
        }

        .main-footer {
            padding: 20px 0px 20px 280px;
            margin-top: 32px;
        }

        optgroup {
            font-size: 12px;
            color: #34395e;
            font-weight: 200;
        }

        option {
            font-weight: 600;
        }

        .section > :first-child {
            margin-top: 18px;
        }

        .offset-md-9 {
            margin-left: 82%;
        }

        input#ContentPlaceHolder1_btnFilter {
            height: 33px;
            margin-top: 13px;
            line-height: 1.2;
        }

        .col-md-2 {
            flex: 1 0 18.666667%;
            max-width: 19.666667%;
        }

        .text {
            color: #2f9b96;
        }

        input#ContentPlaceHolder1_Button2 {
            background: none;
            border: none;
            text-decoration: underline;
            margin-left: 76px;
        }

        .col-md-3 {
            flex: 0 0 10%;
            max-width: 25%;
            width: 140px;
        }

        .btn-success, .btn-success.disabled {
            box-shadow: 0 2px 6px #abf2d7;
            background-color: #5a9d44;
            border-color: #5a9d44;
            color: #fff;
        }

        .btn-danger, .btn-danger.disabled {
            box-shadow: 0 2px 6px #fff;
            background-color: #F20000;
            border-color: #F20000;
            color: #fff;
        }

        .offset-md-6 {
            margin-left: 60%;
        }

        .card {
            height: auto;
        }
    </style>
    <%--<body class="sidebar-mini">--%>
    <div class="loader"></div>
    <div id="app">
        <div class="main-wrapper main-wrapper-1">
            <div class="navbar-bg"></div>


            <!-- Main Content -->
            <div class="main-content">
                <%--<nav aria-label="breadcrumb" class="offset-md-9">
                        <ol class="breadcrumb">
                            <li class="breadcrumb-item">
                                <asp:Button ID="Button2" runat="server" class="text" Text="Previous Page" OnClick="btnPreviousPage_Click" Style="display: none" /></li>

                        </ol>
                    </nav>--%>
                <section class="section">
                    <div class="row">
                        <div class="col-lg-12 col-md-12 col-12 col-sm-12">
                            <div class="card">
                                <div class="card-header">
                                    <h4>Proxy</h4>
                                </div>
                                <asp:UpdatePanel ID="upd" runat="server" UpdateMode="Conditional" class="table dataTable no-footer" aria-describedby="table-2_info">
                                    <ContentTemplate>
                                        <div class="card-body">
                                            <div class="row" style="margin-top: 15px;">
                                                <div id="DivFilter" runat="server" class="">
                                                    <%--style="display: none"--%>
                                                    <div class="row">
                                                        <div class="col-md-12 offset-md-6 text-right mb-3">
                                                            <div class="row">
                                                                <div class="col-md-3">
                                                                    <asp:Button ID="btnFilter_1" runat="server" class="btn btn-success" Text="Apply Filters" OnClick="btnFilter_Click_1" Style="width: 135px;" />
                                                                </div>
                                                                <div class="col-md-3">
                                                                    <asp:Button ID="btnCancel" runat="server" class="btn btn-danger" Text="Cancel" OnClick="btnCancel_Click" Style="width: 135px;" />
                                                                </div>
                                                                <div class="col-md-3">
                                                                    <asp:Button ID="Button1" runat="server" class="btn btn-primary" Text="Clear" OnClick="btnClear_Click" Style="width: 135px;" />
                                                                </div>

                                                            </div>
                                                        </div>
                                                        <div class="col-md-2">
                                                            <div class="form-group">
                                                                <label>Employee Code</label>
                                                                <%--<input type="text" class="form-control" />--%>
                                                                <asp:TextBox ID="txtEmpCode" runat="server" class="form-control" MaxLength="20" />
                                                                <%--onkeypress='return event.charCode >= 48 && event.charCode <= 57'>--%>
                                                            </div>
                                                        </div>
                                                        <div class="col-md-2">
                                                            <div class="form-group">
                                                                <label>Employee Name</label>
                                                                <%--<input type="text" class="form-control" />--%>
                                                                <asp:TextBox ID="txtEmpName" runat="server" class="form-control"></asp:TextBox>

                                                            </div>
                                                        </div>
                                                        <div class="col-md-2">
                                                            <div class="form-group">
                                                                <label>Departments</label>
                                                                <asp:DropDownList ID="ddlDept" runat="server" CssClass="form-control" AutoPostBack="false">
                                                                </asp:DropDownList>

                                                            </div>
                                                        </div>
                                                        <div class="col-md-2">
                                                            <div class="form-group">
                                                                <label>Band</label>
                                                                <asp:DropDownList ID="ddlBand" runat="server" CssClass="form-control">
                                                                </asp:DropDownList>

                                                            </div>
                                                        </div>
                                                        <div class="col-md-2">
                                                            <div class="form-group">
                                                                <label>Designation</label>
                                                                <asp:DropDownList ID="ddlDesignation" runat="server" CssClass="form-control">
                                                                </asp:DropDownList>

                                                            </div>
                                                        </div>
                                                        <div class="clearfix">
                                                        </div>

                                                    </div>
                                                </div>
                                                <div class="offset-md-3 col-lg-5 col-md-12 col-sm-12 all">
                                                    <div class="form-group">
                                                        <label>Username</label>&nbsp;&nbsp
                                                            <asp:Label ID="lbl_text" ForeColor="Red" runat="server" Text=""></asp:Label>
                                                        <div class="input-group mb-3">
                                                            <asp:DropDownList ID="ddlUserName" runat="server" CssClass="form-control" Style="width: 100% !important;"></asp:DropDownList>
                                                        </div>
                                                    </div>
                                                </div>

                                                <div class="col-lg-3 mt-3" style="margin-left: -85px;">
                                                    <asp:Button ID="btnFilter" runat="server" class="btn btn-info btn-lg all" Text="Filter" OnClick="btnFilter_Click" />
                                                </div>
                                            </div>

                                        </div>
                                        <div class="col-lg-3 offset-md-5 mt-2 mb-2">
                                            <asp:Button ID="btnProxyLogin" runat="server" class="btn btn-info btn-lg all" Text="Proxy Login" OnClick="btnProxyLogin_Click" />
                                        </div>
                                        
                                    </ContentTemplate>
                                </asp:UpdatePanel>
                            </div>
                        </div>
                    </div>
                </section>
            </div>
        </div>
    </div>

    <footer class="main-footer">
    </footer>
    <!-- General JS Scripts -->
    <script src="assets/js/app.min.js"></script>
    <!-- JS Libraies -->
    <script src="assets/bundles/echart/echarts.js"></script>
    <!-- Page Specific JS File -->
    <script src="assets/js/page/chart-echarts.js"></script>
    <!-- Page Specific JS File -->
    <script src="assets/js/page/index.js"></script>
    <!-- Template JS File -->
    <script src="assets/js/scripts.js"></script>
    <script src="assets/bundles/jquery.sparkline.min.js"></script>
    <script src="assets/bundles/bootstrap-daterangepicker/daterangepicker.js"></script>
    <script src="assets/bundles/bootstrap-timepicker/js/bootstrap-timepicker.min.js"></script>
  <%--  <script type="text/javascript" src="https://www.jqueryscript.net/demo/simple-tree-table/jquery-simple-tree-table.js"></script>
    <link rel="stylesheet" type="text/css" href="https://www.jqueryscript.net/demo/simple-tree-table/jquery-simple-tree-table.css">--%>
    <script src="assets/js/jquery-simple-tree-table.js" type="text/javascript"></script>
    <link href="assets/css/jquery-simple-tree-table.css" rel="stylesheet" />
    <script src="assets/bundles/sweetalert/sweetalert.min.js"></script>
    <!-- Page Specific JS File -->
    <script src="assets/js/page/sweetalert.js"></script>
    <script src="assets/bundles/prism/prism.js"></script>
    <script>
        $(document).ready(function () {

            $('.singledatadiv').hide();
            $("input[name='customRadioInline3']").change(function () {

                var radioValue = $("input[name='customRadioInline3']:checked").val();
                console.log(radioValue);
                if (radioValue == "single") {
                    $('.all').show()
                    $('.singledatadiv').slideDown();
                    $('.multidatadiv').hide();
                }
                else {
                    $('.all').show()
                    $('.multidatadiv').slideDown();
                    $('.singledatadiv').hide();
                }
            });

            $('#tablediv').hide();
            $('#btnimport').click(function () {
                $('#tablediv').slideToggle();
                $('html, body').animate({
                    scrollTop: $("#tablediv").offset().top
                }, 2000);

            });

        })
    </script>

    <script type="text/javascript">
        $('#basic').simpleTreeTable({
            collapsed: true,

            expander: $('#expander'),
            collapser: $('#collapser')
        });

        $(document).ready(function () {
            $('#collapser').click();
            $('.simple-tree-table tr th:nth-child(4), .simple-tree-table tr th:nth-child(6), .simple-tree-table tr th:nth-child(8), .simple-tree-table tr th:nth-child(9), .simple-tree-table tr td:nth-child(4), .simple-tree-table tr td:nth-child(6), .simple-tree-table tr td:nth-child(8), .simple-tree-table tr td:nth-child(9)').addClass('toggleDisplay')
        })


    </script>
    <script>
        function createTable() {

            $("#noOfVestingTable").html('');
            var rows = $("#noOfCycle").val();
            if (!rows) {
                return;
            }

            for (var i = 0; i < rows; i++) {
                var htmlcontent = "";

                htmlcontent += '<tr>                                                                                   ';
                htmlcontent += '    <td>                                                                               ';
                htmlcontent += '      <div class="form-group" style="margin-bottom: -2px;">                            ';
                htmlcontent += '         <input type="text" class="form-control" value="v' + (i + 1) + '" disabled="">               ';
                htmlcontent += '      </div>                                                                           ';
                htmlcontent += '    </td>                                                                              ';
                htmlcontent += '    <td>                                                                               ';
                htmlcontent += '      <div class="form-group" style="margin-bottom: -2px;">                            ';
                htmlcontent += '         <input type="text" class="form-control" placeholder="Vesting Cycle %">        ';
                htmlcontent += '      </div>                                                                           ';
                htmlcontent += '    </td>                                                                              ';
                htmlcontent += '    <td>                                                                               ';
                htmlcontent += '      <div class="form-group">                                                         ';
                htmlcontent += '         <div class="input-group mb-3">                                                ';
                htmlcontent += '            <select class="form-control" style="margin-bottom: -2px;margin-top: 16px;">';
                htmlcontent += '               <option>Vesting Cycle Duration</option>                                 ';
                htmlcontent += '               <option>1 year</option>                                                 ';
                htmlcontent += '               <option>2 year</option>                                                 ';
                htmlcontent += '               <option>3 year</option>                                                 ';
                htmlcontent += '               <option>4 year</option>                                                 ';
                htmlcontent += '               <option>5 year</option>                                                 ';
                htmlcontent += '               <option>6 year</option>                                                 ';
                htmlcontent += '            </select>                                                                  ';
                htmlcontent += '         </div>                                                                        ';
                htmlcontent += '      </div>                                                                           ';
                htmlcontent += '    </td>                                                                              ';
                htmlcontent += ' </tr>                                                                                 ';


                $("#noOfVestingTable").append(htmlcontent);
            }
        }
    </script>
<%--    <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.5.1/jquery.min.js"></script>
    <script src="https://cdnjs.cloudflare.com/ajax/libs/chosen/1.8.7/chosen.jquery.min.js"></script>
    <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/chosen/1.8.7/chosen.min.css" />--%>
    <script src="assets/js/jquery-3.5.1.min.js" type="text/javascript"></script>
    <script src="assets/js/chosen.jquery-1.8.7.min.js" type="text/javascript"></script>
    <link href="assets/css/chosen-1.8.7.min.css" rel="stylesheet"  />
    <script>

        $('#<%=ddlUserName.ClientID%>').chosen();
        $(document).ready(function () {
            $('#<%=ddlUserName.ClientID%>').chosen();
                Sys.WebForms.PageRequestManager.getInstance().add_endRequest(EndRequestHandler);
                function EndRequestHandler(sender, args) {
                    $('#<%=ddlUserName.ClientID%>').chosen();
                }
            });
    </script>
</asp:Content>
