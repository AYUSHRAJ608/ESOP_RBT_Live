<%@ Page Title="" Language="C#" MasterPageFile="~/ESOP.Master" AutoEventWireup="true" CodeBehind="FMVCreation_Master.aspx.cs" Inherits="ESOP.FMVCreation_Master" EnableEventValidation="false" %>

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

           $(document).on('keydown', 'input[pattern]', function (e) {
               var input = $(this);
               var oldVal = input.val();
               var regex = new RegExp(input.attr('pattern'), 'g');

               setTimeout(function () {
                   var newVal = input.val();
                   if (!regex.test(newVal)) {
                       input.val(oldVal);
                   }
               }, 1);
           });

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
        })
    </script>

    <script type="text/javascript">

        $(function () {
            $.noConflict();
            var from = $("#ContentPlaceHolder1_txtvaldate")
          .datepicker({
              dateFormat: "dd-mm-yy",
              changeMonth: true,
              changeYear: true,
              yearRange: "-50:+50"
          })
          .on("change", function () {
              to.datepicker("option", "minDate", getDate(this));
          }),
        to = $("#ContentPlaceHolder1_txtvalidupto").datepicker({
            dateFormat: "dd-mm-yy",
            changeMonth: true,
            changeYear: true,
            yearRange: "-50:+50"
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
            bindPicker(); //commented on 21-12-2021 by Rahul_Natu
        });
        // bindPicker();
        function bindPicker() {
            //$.noConflict();
            // $("input[type=text][id*=txtvaliduptodate]").datepicker();
            var fromtextbox = $("input[type=text][id*=txtvaldate_Grid]");
            var totextbox = $("input[type=text][id*=txtvaliduptodate]");


            if (typeof(fromtextbox.val()) !== "undefined" || typeof(totextbox.val()) !== 'undefined') {
                var from = $("input[type=text][id*=txtvaldate_Grid]").datepicker({
                    dateFormat: "dd-mm-yy",
                    changeMonth: true,
                    changeYear: true,
                    yearRange: "-50:+50"
                })
                .datepicker('setDate', $.datepicker.parseDate("dd-M-yy", fromtextbox.val()))
                .on("change", function () {
                    to.datepicker("option", "minDate", getDate(this));
                }),

                to = $("input[type=text][id*=txtvaliduptodate]").datepicker({
                    dateFormat: "dd-mm-yy",
                    changeMonth: true,
                    changeYear: true,
                    yearRange: "-50:+50"
                })
                .datepicker('setDate', $.datepicker.parseDate("dd-M-yy", totextbox.val()))
                .on("change", function () {
                    from.datepicker("option", "maxDate", getDate(this));
                });
            }

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

            function getTDate(datevalue) {
                var date;
                var dateFormat = "dd-mm-yy";
                try {
                    date = $.datepicker.parseDate('dd-mm-yy', '13-Dec-2021');
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
    <script type="text/javascript">

        var prm = Sys.WebForms.PageRequestManager.getInstance();

        prm.add_endRequest(function (sender, e) {
            var table = $('#ContentPlaceHolder1_grdfmv').DataTable({
                lengthMenu: [[-1, 5, 10], ["All", 5, 10]],
                columnDefs: [{ orderable: false, targets: [6, 7] }],
                bRetrieve: true,
                bStateSave: true,

            });
 //           table
 //.search('')
 //.columns().search('')
 //.draw();

        });
        $(function () {
            // $.noConflict();
            debugger;
            var table = $("#ContentPlaceHolder1_grdfmv").DataTable({
                bLengthChange: true,
                lengthMenu: [[-1, 5, 10], ["All", 5, 10]],
                bFilter: true,
                //'columnDefs': [{
                //    'targets': [5],
                //    'orderable': false,
                //}],
                order: [],
                columnDefs: [{ orderable: false, targets: [6, 7] }],
                bPaginate: true,
                bSort: true,

                //StateSave: true,
                bStateSave: true,
            });
            table
.search('')
.columns().search('')
.draw();
        });
    </script>

    <script type="text/javascript">

        var prm = Sys.WebForms.PageRequestManager.getInstance();

        prm.add_endRequest(function (sender, e) {

            $('#ContentPlaceHolder1_grdfmv_audit').dataTable({
                lengthMenu: [[-1, 5, 10], ["All", 5, 10]],
                columnDefs: [{ orderable: false, targets: [] }],
                bRetrieve: true,
                bStateSave: true,

            });

        });
        $(function () {
            // $.noConflict();
            debugger;
            $("#ContentPlaceHolder1_grdfmv_audit").DataTable({
                bLengthChange: true,
                lengthMenu: [[-1, 5, 10], ["All", 5, 10]],
                bFilter: true,
                //'columnDefs': [{
                //    'targets': [5],
                //    'orderable': false,
                //}],
                order: [],
                columnDefs: [{ orderable: false, targets: [] }],
                bPaginate: true,
                bSort: true,

                //StateSave: true,
                bStateSave: true,
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

            var FileUpload1 = document.getElementById('<%=FileUpload1.ClientID%>').value;

            var validationdate = document.getElementById('<%=txtvaldate.ClientID%>').value;
            var validupto = document.getElementById('<%=txtvalidupto.ClientID%>').value;
            var FMVPrice = document.getElementById('<%=txtfmvprice.ClientID%>').value;
            var ValueBy = document.getElementById('<%=ddlvaluedby.ClientID%>').value;

            if (validationdate.trim() == "") {
                alert("Select Valuation Date!");
                document.getElementById('<%=txtvaldate.ClientID%>').focus();
                return false;
            }
            if (validupto.trim() == "") {
                alert("Select Valid Upto Date!");
                document.getElementById('<%=txtvalidupto.ClientID%>').focus();
                return false;
            }
            if (FMVPrice.trim() == "") {
                alert("Select FMV Price!");
                document.getElementById('<%=txtfmvprice.ClientID%>').focus();
                return false;
            }

            if (FMVPrice.charAt(0) == 0) {
                alert("FMV Price cannot be" + " " + FMVPrice + "");
                document.getElementById('<%=txtfmvprice.ClientID%>').focus();
                document.getElementById('<%=txtfmvprice.ClientID%>').value = "";
                return false;
            }

            
            //added by Pallavi on 03/03/2022
			//Commented by Krutika on 16-06-22
            <%-- if (ValueBy.trim() == 0) {
                alert("Select Valued By!");
                document.getElementById('<%=ddlvaluedby.ClientID%>').focus();
                return false;
            }--%>
			//END
            <%--if (ValueBy.charAt(0) == 0) {
                alert("Select Valued By!" + " " + FMVPrice + "");
                document.getElementById('<%=ddlvaluedby.ClientID%>').focus();
                document.getElementById('<%=ddlvaluedby.ClientID%>').value = "";
                return false;
            }--%>

            if (FileUpload1.trim() != "" || FileUpload1.trim() == "") {
                var ext = FileUpload1.substr(FileUpload1.lastIndexOf('.') + 1).toLowerCase();
                if (ext != "") {
                    if (ext == "xlsx" || ext == "xls") {
                        return true;
                    }
                    else {
                        alert("File should be in .xls, .xlsx format.");
                        document.getElementById('<%=FileUpload1.ClientID%>').value = "";
                        document.getElementById('<%=FileUpload1.ClientID%>').focus();
                        return false;

                    }
                }
                else {
                    return true;
                }
            }
        }
    </script>
    <script>
        function isNumberKey(txt, evt) {
            var charCode = (evt.which) ? evt.which : evt.keyCode;
            if (charCode == 46) {
                //Check if the text already contains the . character
                if (txt.value.indexOf('.') === -1) {
                    return true;
                } else {
                    return false;
                }
            } else {
                if (charCode > 31 &&
                  (charCode < 48 || charCode > 57))
                    return false;
            }
            return true;
        }
    </script>
    <script type="text/javascript">
        function openModalShowAudit() {
            debugger;
            $('#my_fmv_Up_Modal').modal('show');
        }
    </script>

    <script>
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
    </script>

    <asp:ScriptManager ID="script" runat="server"></asp:ScriptManager>
    <div class="main-content">
        <nav aria-label="breadcrumb" >
            <ol class="breadcrumb">
                <%--  <li class="breadcrumb-item"><a href="admin-dashboard.aspx">Home</a></li>
                <li class="breadcrumb-item"><a href="settings.aspx" style="margin-left: -23px;">Masters</a></li>
                <li class="breadcrumb-item active" aria-current="page" style="margin-top: -15px; margin-left: 32px;">FMV Creation</li>--%>

                <li class="breadcrumb-item"><a href="admin-dashboard.aspx">Home</a></li>

                <li class="breadcrumb-item"><a href="settings.aspx">Masters</a></li>
                <li class="breadcrumb-item active" aria-current="page">FMV Creation</li>
            </ol>
        </nav>
        <section class="section">

            <div class="row">
                <div class="col-lg-12">
                    <div class="card">
                        <div class="card-header">
                            <h4>FMV Creation</h4>
                        </div>
                        <div class="card-body">
                            <div class="row" style="margin-top: 15px;">
                                <div class="col-lg-4 col-md-12 col-sm-12">
                                    <div class="form-group">
                                        <label>Valuation Date <span style="color: red">*</span></label>

                                        <asp:TextBox ID="txtvaldate" type="text" runat="server" Placeholder="dd-mm-yyyy" class="form-control" AutoComplete="off"></asp:TextBox>
                                        <%--<asp:TextBox ID="txtvaldate" runat="server" class="form-control" TextMode="Date"></asp:TextBox>--%>
                                    </div>
                                </div>

                                <div class="col-lg-4 col-md-12 col-sm-12">
                                    <div class="form-group">
                                        <label>Valid Upto <span style="color: red">*</span></label>
                                        <asp:TextBox ID="txtvalidupto" type="text" runat="server" Placeholder="dd-mm-yyyy" class="form-control" AutoComplete="off"></asp:TextBox>
                                        <%-- <asp:TextBox ID="txtvalidupto" runat="server" class="form-control" TextMode="Date"></asp:TextBox>--%>
                                    </div>
                                </div>

                                <div class="col-lg-4 col-md-12 col-sm-12">
                                    <asp:UpdatePanel ID="updprice" runat="server">
                                        <ContentTemplate>
                                            <div class="form-group">
                                                <label>FMV Price <span style="color: red">*</span></label>

                                                <asp:TextBox ID="txtfmvprice" runat="server" CssClass="form-control" onkeypress="return isNumberKey(this, event);" MaxLength="10" pattern="^\d*(\.\d{0,2})?$"></asp:TextBox>

                                            </div>
                                        </ContentTemplate>
                                    </asp:UpdatePanel>
                                </div>


                                <div class="col-lg-4 col-md-12 col-sm-12">
                                    <div class="form-group">
                                        <label>Valued By </label>
                                        <%--<span style="color: red">*</span>  Commented by Krutika on 16-06-22--%>
                                        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                                            <ContentTemplate>
                                                <div class="input-group mb-3">
                                                    <asp:DropDownList ID="ddlvaluedby" runat="server" CssClass="form-control" Style="width: 100% !important;" DataKeyNames="AGENCY_ID, Valued_By">
                                                         <%--<asp:ListItem Value="0">Select</asp:ListItem>
                                                         <asp:ListItem Value="1">Selected</asp:ListItem>--%>
                                                    </asp:DropDownList>
                                                    <%--<asp:RequiredFieldValidator ID="reqFavoriteColor" ErrorMessage="Select valued by" ForeColor="Red"
                                                        InitialValue="0" ControlToValidate="ddlvaluedby" runat="server" Style="margin-top: -17px; font-size: 14px;" />--%>
                                                </div>
                                            </ContentTemplate>
                                        </asp:UpdatePanel>
                                    </div>
                                </div>

                                <div class="col-lg-4 col-md-12 col-sm-12">
                                    <div class="form-group">
                                        <label>Upload File </label>
                                        <%--<span style="color: red">*</span>  Commented by Krutika on 16-06-22--%>
                                        <asp:UpdatePanel ID="UpdatePanel6" runat="server">
                                            <ContentTemplate>
                                                <asp:FileUpload ID="FileUpload1" runat="server" class="form-control" />
                                                <%--Added by Krutika on 16-06-22--%>
                                                <asp:Label ID="lblFileType" runat="server" Text="(Only .xls, .xlsx files are allowed.)" ForeColor="Green" Font-Bold="true" Font-Size="14px"></asp:Label>
                                                <asp:HiddenField ID="hiddenControl" runat="server" />




                                                <div class="col-lg-3 offset-md-3" style="margin-left: 42%; margin-top: 15%">
                                                    <asp:Button ID="btncreatefmv" runat="server" Text="Create FMV" OnClick="btncreatefmv_Click"
                                                        CausesValidation="true"
                                                        class="btn btn-info btn-lg all" OnClientClick="return ReqValidation();" />
                                                </div>
                                            </ContentTemplate>
                                            <Triggers>
                                                <asp:PostBackTrigger ControlID="btncreatefmv" />
                                            </Triggers>
                                        </asp:UpdatePanel>
                                    </div>
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
                                        DataKeyNames="fmv_creation_id" class="table table-bordered" OnPreRender="grdfmv_PreRender" EmptyDataText=""
                                        OnRowEditing="grdfmv_RowEditing" OnRowUpdating="grdfmv_RowUpdating" ShowHeaderWhenEmpty="false"
                                        OnRowCancelingEdit="grdfmv_RowCancelingEdit" OnRowDeleting="grdfmv_RowDeleting" OnRowCommand="grdfmv_RowCommand">
                                        <Columns>
                                            <asp:TemplateField HeaderText="Sr No" HeaderStyle-Width="10%">

                                                <ItemTemplate>
                                                    <asp:Label ID="lblRowNumber" Text='<%# Container.DataItemIndex + 1 %>' runat="server" />

                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Valuation Date" HeaderStyle-Width="15%">

                                                <ItemTemplate>
                                                    <asp:Label ID="lblvaldate" runat="server" Text='<%#Eval("VALUATION_DATE") %>'></asp:Label>
                                                </ItemTemplate>
                                                <EditItemTemplate>

                                                    <asp:TextBox ID="txtvaldate_Grid" runat="server" CssClass="datepick"
                                                        Text='<%#Eval("VALUATION_DATE") %>' Width="100%"></asp:TextBox>

                                                </EditItemTemplate>
                                            </asp:TemplateField>

                                            <asp:TemplateField HeaderText="Valid Upto" HeaderStyle-Width="15%">

                                                <ItemTemplate>
                                                    <asp:Label ID="lblvalidupto" runat="server" Text='<%#Eval("VALID_UPTO_DATE") %>' />
                                                </ItemTemplate>
                                                <EditItemTemplate>
                                                    <asp:TextBox ID="txtvaliduptodate" CssClass="datepick"
                                                        runat="server" Text='<%#Eval("VALID_UPTO_DATE") %>'  Width="100%"></asp:TextBox>
                                                </EditItemTemplate>
                                            </asp:TemplateField>

                                            <asp:TemplateField HeaderText="FMV Price" HeaderStyle-Width="15%">

                                                <ItemTemplate>
                                                    <asp:Label ID="lblfmvprice" runat="server" Text='<%#Eval("FMV_PRICE") %>' />
                                                </ItemTemplate>
                                                <EditItemTemplate>
                                                    <asp:TextBox ID="txtfmvprice" runat="server" Text='<%#Eval("FMV_PRICE") %>' onkeypress="return isNumberKey(this,event)"
                                                        MaxLength="10" Width="100%" onchange="txtChange(this);"></asp:TextBox>
                                                </EditItemTemplate>
                                            </asp:TemplateField>


                                            <asp:TemplateField HeaderText="Valued By">
                                                <ItemTemplate>
                                                    <asp:Label ID="txtVALUEDBY" runat="server" Text='<%#Eval("VALUED_BY") %>'></asp:Label>

                                                </ItemTemplate>
                                                <EditItemTemplate>

                                                    <asp:DropDownList ID="DropDownList1" runat="server" Width="100% ">
                                                    </asp:DropDownList>

                                                </EditItemTemplate>
                                            </asp:TemplateField>

                                            <asp:TemplateField HeaderText="File">

                                                <ItemTemplate>

                                                    <asp:LinkButton ID="lnkDownload" runat="server" CausesValidation="False" Style="color: #5e65ff;" CommandArgument='<%# Eval("UPLOAD_FILE") %>' Enabled='<%# Eval("UPLOAD_FILE").ToString() != "" ? true : false %>'
                                                        Text='<%# string.IsNullOrEmpty(Eval("UPLOAD_FILE").ToString()) ? "File is not available" : "Download" %>' OnClick="lnkDownload_Click" />

                                                </ItemTemplate>

                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Action" HeaderStyle-Width="12.5%">
                                                <ItemTemplate>
                                                    <asp:LinkButton ID="btn_Edit" runat="server" CommandName="Edit" CausesValidation="false"
                                                        CssClass="fas fa-pencil-alt edit12"></asp:LinkButton>
                                                    <asp:LinkButton ID="btn_Delete" runat="server" CommandName="Delete" CausesValidation="false"
                                                        CssClass="fas fa-trash-alt delete12"></asp:LinkButton>
                                                    <%--OnClientClick="return confirm('Are you sure you want to Delete?');"--%>
                                                </ItemTemplate>
                                                <EditItemTemplate>
                                                    <asp:LinkButton ID="btn_Update" runat="server" CssClass="fas fa-check update edit12" CommandName="Update" OnClientClick="return ValidateTextbox();"></asp:LinkButton>
                                                    <asp:LinkButton ID="btn_Cancel" runat="server" CssClass="fas fa-times cancel delete12" CommandName="Cancel"></asp:LinkButton>
                                                </EditItemTemplate>
                                            </asp:TemplateField>

                                            <asp:TemplateField HeaderText="Audit Trail">
                                                <ItemTemplate>
                                                    <asp:LinkButton ID="btn_Audit" runat="server" CommandName="Audit" CausesValidation="true"
                                                        CommandArgument="<%# ((GridViewRow) Container).RowIndex %>"
                                                        CssClass="fas fa-info edit12"></asp:LinkButton>
                                                </ItemTemplate>
                                            </asp:TemplateField>
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
                    <asp:button id="BtnDownload" onclick="DownloadFile_Click" runat="server" visible="false" xmlns:asp="#unknown" />
                </div>
            </div>
        </section>


        <div class="modal bd-example-modal-lg" id="my_fmv_Up_Modal" tabindex="-1" role="dialog">
            <div class="modal-dialog modal-xl boxModalDiv">
                <!-- Modal content-->
                <div class="modal-content" style="width: 100%;">
                    <div class="modal-header">
                        <h5 class="modal-title" id="myLargeModalLabel">Audit Trail
                    
                        </h5>

                    </div>

                    <div class="col-lg-3 offset-md-3" style="padding-top: 12px; margin-left: 88%;">

                        <asp:ImageButton ID='btnexcelExport' runat='server' ImageUrl="~/img/excel1.png" Style="margin-left: 18px;" Height="35px" ToolTip="Export To Excel" OnClick="btnexcelExport_Click" />
                        <asp:ImageButton ID='btnpdfexport' runat='server' ImageUrl="~/img/pdf.png" Height="35px" ToolTip="Export To Pdf" OnClick="btnpdfexport_Click" />
                    </div>

                    <div class="card-body">
                        <div class="table-responsive">
                            <asp:UpdatePanel ID="upd3" runat="server">
                                <ContentTemplate>
                                    <asp:GridView ID="grdfmv_audit" class="table table-striped table-hover"
                                        Style="width: 98%; margin-left: 1%;" DataKeyNames="FMV_CREATION_ID"
                                        runat="server" AutoGenerateColumns="False"
                                        EmptyDataText="No data found" OnRowDataBound="grdfmv_audit_RowDataBound" OnPreRender="grdfmv_audit_PreRender"
                                        OnPageIndexChanging="grdfmv_audit_PageIndexChanging" AllowPaging="false" PageSize="10" AllowCustomPaging="false" ViewStateMode="Enabled">
                                        <Columns>
                                            <asp:TemplateField HeaderText="Valuation Date">

                                                <ItemTemplate>
                                                    <asp:Label ID="lbl_VALUATION_DATE" runat="server" Text='<%#Eval("VALUATION_DATE") %>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>

                                            <asp:TemplateField HeaderText="Valid Upto Date">

                                                <ItemTemplate>
                                                    <asp:Label ID="lbl_VALID_UPTO_DATE" runat="server" Text='<%#Eval("VALID_UPTO_DATE") %>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>


                                            <asp:TemplateField HeaderText="Fmv Price">

                                                <ItemTemplate>
                                                    <asp:Label ID="lbl_FMV_PRICE" runat="server" Text='<%#Eval("FMV_PRICE") %>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>

                                            <asp:TemplateField HeaderText="Valued By">

                                                <ItemTemplate>
                                                    <asp:Label ID="lbl_VALUED_BY" runat="server" Text='<%#Eval("VALUED_BY") %>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>


                                            <asp:TemplateField HeaderText="Created Date">

                                                <ItemTemplate>
                                                    <asp:Label ID="lbl_CREATION_DATE" runat="server" Text='<%#Eval("CREATION_DATE") %>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>


                                            <asp:TemplateField HeaderText="Created By">

                                                <ItemTemplate>
                                                    <asp:Label ID="lbl_CREATED_BY" runat="server" Text='<%#Eval("CREATED_BY") %>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>

                                            <asp:TemplateField HeaderText="Updated Date">

                                                <ItemTemplate>
                                                    <asp:Label ID="lbl_UPDATATION_DATE" runat="server" Text='<%#Eval("UPDATATION_DATE") %>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>

                                            <asp:TemplateField HeaderText="Updated By">

                                                <ItemTemplate>
                                                    <asp:Label ID="lbl_UPDATED_BY" runat="server" Text='<%#Eval("UPDATED_BY") %>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>


                                            <asp:TemplateField HeaderText="Action">

                                                <ItemTemplate>
                                                    <asp:Label ID="lbl_Status" runat="server" Text='<%#Eval("action") %>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>

                                        </Columns>

                                        <PagerStyle HorizontalAlign="Right" CssClass="GridPager" />
                                    </asp:GridView>
                                </ContentTemplate>
                                <Triggers>
                                    <asp:AsyncPostBackTrigger ControlID="grdfmv_audit" />
                                </Triggers>
                            </asp:UpdatePanel>
                        </div>
                    </div>

                    <div class="modal-footer bg-whitesmoke br">
                        <div class="btn-group" role="group" aria-label="Basic example">
                            <button id="btn1" class="btn btn-info btn-lg all CloseBtnNew">Close</button>
                            <%--<a href="#" class="btn btn-info btn-lg all CloseBtnNew" >Close</a>--%>
                        </div>
                    </div>
                </div>
            </div>
        </div>
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


    <script>
        function DownloadFile(filepath) {
            __doPostBack("<%= BtnDownload.UniqueID %>", filepath);
        }
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
