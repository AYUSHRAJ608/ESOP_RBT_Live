<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/ESOP.Master" CodeBehind="Employee_Password_Master.aspx.cs" Inherits="ESOP.Employee_Password_Master" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <title>ESOP-FMV Creation</title>
    <style>
        .sidebar-mini .main-sidebar:after {
            box-shadow: 0 4px 25px 0 rgba(0, 0, 0, .1);
            content: ' ';
            position: fixed;
            background-color: rgb(38 114 255) !important;
            width: 65px;
            height: 100%;
            left: 0;
            top: 0;
            z-index: -1;
            opacity: 0;
            animation-name: mini-sidebar;
            animation-duration: 1.5s;
            animation-fill-mode: forwards;
        }

        .main-sidebar .sidebar-menu li a {
            color: white;
        }

        .main-sidebar .sidebar-brand {
            border-bottom: 3px solid white;
        }



        .navbar {
            background-color: white;
        }

        .table {
            border: none !important;
        }

        table.dataTable, table.dataTable th, table.dataTable td {
            /*box-sizing: content-box;*/
            border: 1px solid #fff !important;
        }

        .sorting_1 {
            border: 1px solid #fff !important;
        }

        .card .card-body, .card .card-footer, .card .card-header {
            /*background-color: transparent;*/
            padding: 15px 25px !important;
        }

        table.dataTable thead th, table.dataTable thead td {
            padding: 10px 15px;
            /*border-bottom: 1px solid #111;*/
        }

        table.dataTable td, table.dataTable th {
            -webkit-box-sizing: content-box;
            box-sizing: content-box;
            line-height: 23px;
        }

        table.dataTable > thead > tr > th:not(.sorting_disabled), table.dataTable > thead > tr > td:not(.sorting_disabled) {
            padding-right: 35px !important;
            padding-left: 5px !important;
            height: 30px;
            font-size: 14px !important;
        }

        .remark {
            padding: 5px;
        }

        .table th {
            padding: .4rem;
            color: #000 !important;
            font-weight: 600 !important;
            background: #d1d4d7;
        }

        .table:not(.table-sm) thead th {
            padding-top: 0px;
            padding-bottom: 0px;
        }

        .table td, .table th {
            padding: .32rem;
        }

        .table:not(.table-sm) thead th {
            background-color: #6c757d4f;
            color: #000000c2;
            font-size: 14px !important;
            font-size: 15px !important;
            padding: 6px;
        }

        .table td {
            font-weight: 500;
            color: #3f646d;
            font-size: 14px;
            background: #bcc0c32e;
        }

        input[type="text"] {
            /*border: 1px solid #19a5c5;*/
            border-radius: 6px;
            padding-left: 8px;
            font-weight: 500;
            color: #3f646d;
            font-size: 14px;
            /*background: #eefafc;*/
        }

        .card .card-header {
            background-color: transparent;
            padding: 11px 40px !important;
        }

        .main-footer {
            margin-top: -12px !important;
        }

        .btn-group {
            height: 34px;
        }

        button.btn.badge.badge-success.badge-shadow {
            line-height: 3px;
        }

        button.btn.badge.badge-danger.badge-shadow {
            line-height: 3px;
        }

        .card .card-header .btn {
            margin-top: 1px;
            padding: 0px 8px;
        }

        .buttons .btn {
            margin: 0 0px 0px 0;
        }

        .offset-md-7 {
            margin-left: 63.333333%;
        }

        .badge.badge-success {
            background: linear-gradient(180deg, #00b3da 0, #18c5ec 100%);
        }

        .edit12 {
            padding: 10px;
            background: #2573ff;
            color: white !important;
            border-radius: 4px;
            line-height: 0;
        }

        .delete12 {
            padding: 10px;
            background: #e3001b; /*background: #e3001b;*/
            color: white !important;
            border-radius: 4px;
            line-height: 0;
            margin-left: 4px;
            width: 30px;
        }

        .breadcrumb {
            background-color: none !important;
        }

        .section > :first-child {
            margin-top: 16px !important;
        }

        .offset-md-9 {
            margin-left: 81%;
        }

        .table:not(.table-sm):not(.table-md):not(.dataTable) th {
            background: #6c757d75 !important;
            color: #000000c2 !important;
        }

        .btn.btn-info.all.CloseBtnNew:hover {
            color: #498A07 !important;
            background: #ffff !important;
            border: 2px solid #498A07 !important;
        }

        .GridPager a, .GridPager span {
            display: block;
            height: 25px;
            width: 33px;
            font-weight: bold;
            text-align: center;
            text-decoration: none;
        }

        .cancel {
            vertical-align: middle;
            background-color: green;
        }

        .update {
            background-color: blue;
        }

        .cancel:before {
            content: "\f00d";
            color: #fff;
            font-size: 16px;
            margin-left: 0;
            position: absolute;
            top: auto;
            left: auto;
        }
    </style>


    <script src="assets/js/jquery-1.8.3.min.js" type="text/javascript"></script>
    <link href="assets/css/jquery-ui-1.12.1.css" rel="stylesheet" />
    <script src="assets/js/jquery-1.12.4.js" type="text/javascript"></script>
    <script src="assets/js/jquery-ui-1.12.1.js" type="text/javascript"></script>
    <%--    - ------- ------ ------ ------ ------ ------ ------ for label and  for gridview textbox------ ------ ------ ------ ------ ------ ------  ----%>

    <script type="text/javascript">

        $(function () {
            $.noConflict();
            var from = $("#ContentPlaceHolder1_txtvaldate")
          .datepicker({

              dateFormat: "dd-mm-yy",
              changeMonth: true,
              changeYear: true,
              yearRange: "-50:+50",
          })
          .on("change", function () {
              to.datepicker("option", "minDate", getDate(this));
          }),
        to = $("#ContentPlaceHolder1_txtvalidupto").datepicker({
            dateFormat: "dd-mm-yy",
            changeMonth: true,
            changeYear: true,
            yearRange: "-50:+50",
        })
        .on("change", function () {
            from.datepicker("option", "maxDate", getDate(this));
        });

            function getDate(element) {
                var date;
                var dateFormat = "dd-mm-yy";
                try {
                    date = $.datepicker.parseDate(dateFormat, element.value);
                } catch (error) {
                    date = null;
                }

                return date;
            }
        });

        $(function () {
            Sys.WebForms.PageRequestManager.getInstance().add_endRequest(bindPicker);
            bindPicker();
        });
        // bindPicker();
        function bindPicker() {
            //$.noConflict();
            // $("input[type=text][id*=txtvaliduptodate]").datepicker();
            var from = $("input[type=text][id*=txtvaldate_Grid]").datepicker({


                dateFormat: "dd-mm-yy",
                changeMonth: true,
                changeYear: true,
                yearRange: "-50:+50",
            })
          .on("change", function () {
              to.datepicker("option", "minDate", getDate(this));
          }),
        to = $("input[type=text][id*=txtvaliduptodate]").datepicker({
            dateFormat: "dd-mm-yy",
            changeMonth: true,
            changeYear: true,
            yearRange: "-50:+50",
        })
        .on("change", function () {
            from.datepicker("option", "maxDate", getDate(this));
        });

            function getDate(element) {
                var date;
                var dateFormat = "dd-mm-yy";
                try {
                    date = $.datepicker.parseDate(dateFormat, element.value);
                } catch (error) {
                    date = null;
                }

                return date;
            }
        }


    </script>


    <script src="assets/js/jquery.dataTables-1.10.20.min.js" type="text/javascript"></script>
    <link href="Scripts/jquery.dataTables.min.css" rel="stylesheet" />
    <link href="Scripts/dataTables.bootstrap4.min.css" rel="stylesheet" />
    
     <script>
        //$('#ContentPlaceHolder1_grdfmv').clear().draw();
        $(function () {
            var prm = Sys.WebForms.PageRequestManager.getInstance();
            prm.add_endRequest(function (sender, e) {
                $('#ContentPlaceHolder1_grdfmv').DataTable({
                    lengthMenu: [[-1, 5, 10], ["All", 5, 10]],
                    bRetrieve: true,
                });

            });
        });
        $(function () {
            debugger;
            $("#ContentPlaceHolder1_grdfmv").DataTable({
                bLengthChange: true,
                lengthMenu: [[-1, 5, 10], ["All", 5, 10]],
                bFilter: true,
                'columnDefs': [{
                    'targets': [],
                    'orderable': false,
                }],
                //bSort:true,
                bPaginate: true

            });
        });
    </script>



    <script type="text/javascript">
        function displayimg(srcval) {

            //if (document.getElementById('btncreatefmv').clicked == true) {
            //    alert("button was clicked");
            //}

        }
    </script>
    <script type="text/javascript">
        function ValidateTextbox() {
            debugger;
            //Reference the GridView.
            var grid = document.getElementById("<%=grdfmv.ClientID %>");

            //Reference all INPUT elements.
            var Inputs = grid.getElementsByTagName("INPUT");
            // if (confirm("Are you sure want to Update record?")) {
            for (i = 0; i < Inputs.length; i++) {
                if (Inputs[i].type == 'text') {
                    if (Inputs[i].value == "") {
                        alert("Please enter value.");
                        return false;
                    }

                }

                if (Inputs[i].type == 'date') {
                    if (Inputs[i].value == "") {
                        alert("Please enter correct date.");
                        return false;
                    }

                }
            }
            return true;
            //} else {
            //    return false;
            //}
        }
    </script>
    <script type="text/javascript">
        function ReqValidation() {
            debugger;


            //document.getElementById('< .ClientID%>').innerHTML = "";


            var FMVPrice = document.getElementById('<%=txtfmvprice.ClientID%>').value;

            if (FMVPrice.trim() == "") {
                alert("Please Enter Password!");
                document.getElementById('<%=txtfmvprice.ClientID%>').focus();
                return false;
            }
        }
    </script>

    <script type="text/javascript">
        function openModalShowAudit() {
            debugger;
            $('#my_fmv_Up_Modal').modal('show');
        }
    </script>

    <%--<script>
        function txtChange(txt) {
            var txtName;
            var gridRow = txt.parentNode.parentNode;

            //Fetch all controls in GridView Row.
            var controls = gridRow.getElementsByTagName("*");

            //Loop through the fetched controls.
            for (var i = 0; i < controls.length; i++) {

                //Find the TextBox control.
                if (controls[i].id.indexOf("txtfmvprice") != -1) {
                    txtName = controls[i];
                }
            }
            //Validate the TextBox control.        
            if (txtName.value == 0) {
                //alert("FMV Price cannot be" + " " + txtName.value + "");
                alert("FMV Price cannot be 0 or Empty.");
                txtName.focus();
                txtName.value = "";
                return false;
            }
        }
    </script>--%>

    <asp:ScriptManager ID="script" runat="server"></asp:ScriptManager>
    <div class="main-content">
        <nav aria-label="breadcrumb">
            <ol class="breadcrumb">

                <li class="breadcrumb-item"><a href="admin-dashboard.aspx">Home</a></li>
                <li class="breadcrumb-item"><a href="settings.aspx">Masters</a></li>
                <li class="breadcrumb-item active" aria-current="page">ID Proof Master</li>
            </ol>
        </nav>
        <section class="section">

            <div class="row">
                <div class="col-lg-12">
                    <div class="card">
                        <div class="card-header">
                            <h4>ID Proof Password</h4>
                        </div>
                        <div class="card-body">
                            <div class="row" style="margin-top: 15px;">




                                <div class="col-lg-4 col-md-12 col-sm-12">
                                    <asp:UpdatePanel ID="updprice" runat="server">
                                        <ContentTemplate>
                                            <div class="form-group">
                                                <label>ID Proof Password <span style="color: red">*</span></label>

                                                <asp:TextBox ID="txtfmvprice" runat="server" CssClass="form-control"></asp:TextBox>

                                            </div>
                                            <div class="col-lg-3 offset-md-3" style="margin-left: 42%; margin-top: 15%">
                                                <asp:Button ID="btncreatefmv" runat="server" Text="Create Password" OnClick="btncreatefmv_Click"
                                                    CausesValidation="true"
                                                    class="btn btn-info btn-lg all" OnClientClick="return ReqValidation();" />
                                            </div>
                                        </ContentTemplate>
                                    </asp:UpdatePanel>
                                </div>
                            </div>
                            <div style="color: red; float: right">
                                All (*) marked fields are mandatory.
                            </div>
                        </div>
                        <asp:UpdatePanel ID="upd2" runat="server">
                            <ContentTemplate>
                                <div id="showmsg" runat="server"></div>
                            </ContentTemplate>
                        </asp:UpdatePanel>
                    </div>
                </div>
            </div>

            <div class="col-lg-12 col-md-12 col-12 col-sm-12" id="tablediv">
                <div class="card" style="height: auto;">
                    <div class="card-header">
                        <h4>Record Summary</h4>
                    </div>
                    <div class="card-body">
                        <div class="table-responsive">
                            <asp:UpdatePanel ID="upd" runat="server">
                                <ContentTemplate>
                                    <asp:GridView ID="grdfmv" runat="server" AutoGenerateColumns="False" OnRowDataBound="grdfmv_RowDataBound"
                                        class="table table-bordered" OnPreRender="grdfmv_PreRender" EmptyDataText=""
                                        OnRowEditing="grdfmv_RowEditing" ShowHeaderWhenEmpty="false"
                                        OnRowCommand="grdfmv_RowCommand">
                                        <Columns>
                                            <asp:TemplateField HeaderText="Sr No" HeaderStyle-Width="10%">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblRowNumber" Text='<%# Container.DataItemIndex + 1 %>' runat="server" />
                                                </ItemTemplate>
                                            </asp:TemplateField>

                                            <asp:TemplateField HeaderText="ID Proof" HeaderStyle-Width="15%">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblvaldate" runat="server" Text='<%#Eval("Emp_Password") %>'></asp:Label>
                                                </ItemTemplate>
                                                <%-- <EditItemTemplate>
                                                    <asp:TextBox ID="txtvaldate_Grid" runat="server" CssClass="datepick"
                                                        Text='<%#Eval("Emp_Password") %>' Width="100%"></asp:TextBox>
                                                </EditItemTemplate>--%>
                                            </asp:TemplateField>

                                            <asp:TemplateField HeaderText="Created By" HeaderStyle-Width="10%">
                                                <ItemTemplate>
                                                    <asp:Label ID="CreatedBy" runat="server" Text='<%#Eval("created_by") %>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>

                                            <asp:TemplateField HeaderText="Created Date" HeaderStyle-Width="10%">
                                                <ItemTemplate>
                                                    <asp:Label ID="CreatedDate" runat="server" Text='<%#Eval("created_date") %>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <%--<asp:TemplateField HeaderText="Action" HeaderStyle-Width="12.5%">
                                                <ItemTemplate>
                                                    <asp:LinkButton ID="btn_Edit" runat="server" CommandName="Edit" CausesValidation="false"
                                                        CssClass="fas fa-pencil-alt edit12"></asp:LinkButton>
                                                    <asp:LinkButton ID="btn_Delete" runat="server" CommandName="Delete" CausesValidation="false"
                                                        CssClass="fas fa-trash-alt delete12"></asp:LinkButton>
                                                </ItemTemplate>
                                                <EditItemTemplate>
                                                    <asp:LinkButton ID="btn_Update" runat="server" CssClass="fas fa-check update edit12" CommandName="Update" OnClientClick="return ValidateTextbox();"></asp:LinkButton>
                                                    <asp:LinkButton ID="btn_Cancel" runat="server" CssClass="fas fa-times cancel delete12" CommandName="Cancel"></asp:LinkButton>
                                                </EditItemTemplate>
                                            </asp:TemplateField>--%>
                                        </Columns>

                                    </asp:GridView>

                                </ContentTemplate>

                                <%--      <Triggers>
                                    <asp:PostBackTrigger ControlID="grdfmv" />

                                    <asp:PostBackTrigger ControlID="FileUpload1" />
                                </Triggers>--%>
                            </asp:UpdatePanel>

                        </div>
                    </div>
                    <%--<asp:button id="BtnDownload" onclick="DownloadFile_Click" runat="server" visible="false" xmlns:asp="#unknown" />--%>
                </div>
            </div>
        </section>
    </div>

    <script src="Scripts/bootstrap.min.js"></script>

    <%--<script src="assets/js/bootstrap-3.3.6.min.js"></script>--%>
    <script src="assets/js/app.min.js"></script>

    <script src="assets/js/scripts.js"></script>


    <script>
        $(document).ready(function () {
            $('.CloseBtnNew').click(function () {
                // alert('test');

                $("#myModal").removeClass("show");
                $("#myModal").hide();
                $(".modal-backdrop").remove();
                //$("#myModal").hide();
                $("body").removeClass("modal-open");
                // $("#myModal1").modal("hide");
            });

            $('#grdfmv').hide();

            $('#btncreatefmv').click(function () {

                $('#grdfmv').slideToggle();
                $('html, body').animate({
                    scrollTop: $("#grdfmv").offset().top
                }, 2000);

            });

        })
    </script>


    <style>
        .modal-backdrop.in {
            display: block;
        }

        .modal-backdrop {
            background-color: #0003;
        }

        .modalClose {
            color: #fff;
            margin: 0 !important;
            padding: 0 !important;
            top: -4px;
            position: relative;
            display: inline-block;
            opacity: 1;
            font-size: 28px;
        }

            .modalClose:hover {
                color: #fff;
            }

        .boxModalDiv {
            box-shadow: 0 4px 15px rgba(0, 0, 0, .2);
            margin-left: auto;
            margin-right: auto;
        }
    </style>
</asp:Content>

