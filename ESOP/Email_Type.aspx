<%@ Page Title="" Language="C#" MasterPageFile="~/ESOP.Master" AutoEventWireup="true" CodeBehind="Email_Type.aspx.cs" Inherits="ESOP.Email_Type" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ScriptManager ID="script" runat="server"></asp:ScriptManager>
    <style>
        body {
            background-color: #f6f6f6 !important;
        }

        #container {
            margin: 15px;
            width: 100px;
            height: 100px;
            position: relative;
        }

        .emplink {
            text-align: center;
        }

            .emplink a {
                background: #e5e5e5;
                color: #693c3c;
                border-radius: 7px;
                font-size: 18px;
                padding: 5px 6px;
                margin: 0 3px;
            }



        .switch {
            position: relative;
            display: inline-block;
            width: 70px;
            height: 24px;
            margin-top: 7px;
        }

            .switch input {
                opacity: 0;
            }

        .slider {
            position: absolute;
            cursor: pointer;
            top: 0;
            left: 0;
            right: 0;
            bottom: 0;
            background-color: #ccc;
            -webkit-transition: .4s;
            transition: .4s;
        }

            .slider:before {
                position: absolute;
                content: "";
                height: 16px;
                width: 16px;
                left: 4px;
                bottom: 4px;
                background-color: white;
                -webkit-transition: .4s;
                transition: .4s;
            }

        input:checked + .slider {
            background-color: #2600ff;
        }

        input:focus + .slider {
            box-shadow: 0 0 1px #2196F3;
        }

        input:checked + .slider:before {
            -webkit-transform: translateX(46px);
            -ms-transform: translateX(46px);
            transform: translateX(46px);
        }
        /*------ ADDED CSS ---------*/
        .on {
            display: none;
        }

        .on, .off {
            color: white;
            position: absolute;
            transform: translate(-50%,-50%);
            top: 50%;
            left: 50%;
            font-size: 12px;
            font-family: Verdana, sans-serif;
        }

        input:checked + .slider .on {
            display: block;
        }

        input:checked + .slider .off {
            display: none;
        }

        /* Rounded sliders */
        .slider.round {
            border-radius: 34px;
        }

            .slider.round:before {
                border-radius: 50%;
            }

        .open > .dropdown-menu {
            display: block;
            overflow: auto;
            transform: scale(1);
            left: 0;
        }

        .multiselect-container .input-group {
            margin: 8px -7px;
        }

        .radio input[type="radio"], .radio-inline input[type="radio"], .checkbox input[type="checkbox"], .checkbox-inline input[type="checkbox"] {
            position: static;
            margin-left: 0px;
        }

        .dropdown-menu > .active > a, .dropdown-menu > .active > a:hover, .dropdown-menu > .active > a:focus {
            color: #fff !important;
            text-decoration: none;
            outline: 0;
            background-color: #d6e9ff;
        }

        .multiselect-container > li > a > label > input[type="checkbox"] {
            margin-bottom: 5px;
            vertical-align: middle;
            margin-right: 6px;
        }

        .multiselect-container > li > a > label.radio, .multiselect-container > li > a > label.checkbox {
            margin: 0;
            font-size: 11px;
            font-family: montserrat;
            font-weight: 500;
        }

        .multiselect-container > li > label.multiselect-group {
            margin: 0;
            padding: 3px 20px 3px 20px;
            height: 100%;
            font-weight: bold;
            display: none;
        }

        .multiselect-container > li > a > label.radio, .multiselect-container > li > a > label.checkbox {
            margin: 0;
            font-size: 11px;
            font-family: montserrat;
            font-weight: 600;
        }

        .form-controlddl {
            display: block;
            /*width: 100%;*/
            font: 500 12px "Montserrat", sans-serif;
            height: 33px;
            padding: 6px 12px;
            font-size: 12px;
            line-height: 1.42857143;
            color: #555;
            background-color: #fff;
            background-image: none;
            border: 1px solid #eee;
            border-radius: 1px;
            -webkit-box-shadow: inset 0 1px 1px rgba(0,0,0,.075);
            box-shadow: inset 0 1px 1px rgba(0,0,0,.075);
            -webkit-transition: border-color ease-in-out .15s,box-shadow ease-in-out .15s;
            -o-transition: border-color ease-in-out .15s,box-shadow ease-in-out .15s;
            -webkit-transition: border-color ease-in-out .15s,-webkit-box-shadow ease-in-out .15s;
            transition: border-color ease-in-out .15s,-webkit-box-shadow ease-in-out .15s;
            transition: border-color ease-in-out .15s,box-shadow ease-in-out .15s;
            transition: border-color ease-in-out .15s,box-shadow ease-in-out .15s,-webkit-box-shadow ease-in-out .15s;
        }

        .multiselect {
            text-align: left;
        }


        .checklist {
            /*height:143px;*/
            height: 250px;
            overflow-y: auto;
            overflow-x: hidden;
        }

            .checklist input[type=checkbox] {
                vertical-align: top;
                margin: 4px 10px 11px 0;
            }

        .modal .form-control:focus ~ label, .modal .has-content.form-control ~ label {
            font: 500 13px "Montserrat", sans-serif;
            color: rgb(0 0 0 / 75%);
            z-index: 1 !important;
            top: -7px !important;
            background: #fff !important;
            padding: 0 5px !important;
        }

        .form-group1 {
            position: relative;
            margin-bottom: 15px;
        }

            .form-group1 label {
                position: absolute;
                font: 500 12px "Montserrat", sans-serif;
                color: rgb(0 0 0 / 75%);
                z-index: 1 !important;
                top: -7px !important;
                left: 8px !important;
                letter-spacing: 0.3px !important;
                margin-bottom: 0px !important;
                color: #979797 !important;
                -webkit-transition: 0.3s !important;
                -o-transtion: 0.3s !important;
                -moz-transition: 0.3s !important;
                transition: 0.3s !important;
                background: #fff !important;
                padding: 0 0px !important;
                z-index: 1 !important;
                top: -7px !important;
                background: #fff !important;
                padding: 0 5px !important;
            }

        .modal .form-group .form-control {
            border: 1px solid #ccc;
            border: 1px solid #ccc;
            padding: 7px 6px 6px 10px;
            /*font-size: 12px;*/
        }

        .modalEdit .form-group1 input, .modalEdit .form-group1 select, .modalEdit .form-group1 textarea {
            font: 500 12px "Montserrat", sans-serif;
            border: 1px solid #eee;
            height: 33px;
            -webkit-border-radius: 4px;
            -moz-border-radius: 4px;
            border-radius: 4px;
            background-color: rgba(255, 255, 255, 0);
            padding-left: 10px;
            -webkit-box-shadow: none;
            -moz-box-shadow: none;
            box-shadow: none;
            letter-spacing: 0.2px;
            position: relative;
            z-index: 1;
            -webkit-transition: 0.3s;
            -o-transtion: 0.3s;
            -moz-transition: 0.3s;
            transition: 0.3s;
            display: block;
            width: 100%;
            padding: 7px 6px 6px 10px;
        }

        .modal .form-group .form-control ~ label {
            position: absolute;
            left: 30px;
            top: 9px;
            font: 500 13px "Montserrat", sans-serif;
            color: rgb(0 0 0 / 75%);
            -webkit-transition: 0.2s;
            -o-transtion: 0.2s;
            -moz-transition: 0.2s;
            transition: 0.2s;
            z-index: 0;
            overflow: hidden;
            text-overflow: clip;
            white-space: nowrap;
            letter-spacing: 0.3px;
            width: auto;
        }

        .emptable tr:first-child th {
            background-color: #e41f25 !important;
            color: #fff !important;
        }

        .emptable td {
            padding: 12px 8px !important;
            font: 500 12px "Montserrat", sans-serif !important;
        }

        .emplink {
            background: #f6f6f6;
            color: #939598;
            border-radius: 7px;
            font-size: 15px;
            padding: 5px 6px;
            margin: 0 3px;
        }



        .hideGridColumn {
            display: none;
        }

        .labelhead {
            margin: 0 5px;
            text-align: center;
            display: block;
            background: #e41f25;
            clear: both;
            padding: 6px;
            color: #fff;
            font-weight: 600;
        }

        #empTable tr td {
            padding: 8px 0px;
            padding-right: 31px !important;
        }

            #empTable tr td input, #empTable tr td select {
                width: 244px;
            }

            #empTable tr td button {
                width: 59px;
                height: 25px;
                background: #e41f25;
                border-radius: 17px;
                color: #fff;
                border: 0;
                box-shadow: none;
                margin: 2px auto 0 -17px;
                display: inline-block;
            }

                #empTable tr td button:before {
                    content: "";
                    height: 3px;
                    width: 13px;
                    background: #fff;
                    display: inline-block;
                    position: relative;
                    top: -3px;
                }

            #empTable tr td:first-child {
                width: 0px;
                display: none;
                padding: 0px;
            }


        .form-controlAdd {
            display: block;
            width: 100%;
            height: 34px;
            padding: 6px 12px;
            font-size: 13px;
            font-weight: 500;
            line-height: 1.42857;
            color: black;
            background-color: #fff;
            background-image: none;
            border: 1px solid #ccc;
            border-radius: 4px;
            -webkit-box-shadow: inset 0 1px 1px rgba(0, 0, 0, 0.075);
            box-shadow: inset 0 1px 1px rgba(0, 0, 0, 0.075);
            -webkit-transition: border-color ease-in-out 0.15s, box-shadow ease-in-out 0.15s;
            -o-transition: border-color ease-in-out 0.15s, box-shadow ease-in-out 0.15s;
            transition: border-color ease-in-out 0.15s, box-shadow ease-in-out 0.15s;
        }

        .emailtable tr th {
            background: rgb(108 117 125 / 46%) !important;
            color: #000 !important;
        }

        .emailtable tr td {
            padding: 0px 5px !important;
            vertical-align: middle !important;
            font-size: 14px;
            font-weight: 500;
            text-align: left !important;
            border: 1px solid #96a2b44a !important;
            background: #eff1f1;
        }

        .list-group-item {
            border-bottom-left-radius: .25rem;
            border-top-right-radius: 0;
            padding: 0;
            border: 0;
        }

        .table:not(.table-sm):not(.table-md):not(.dataTable) th {
            font-weight: 600;
            color: #000 !important;
        }

        .table:not(.table-sm):not(.table-md):not(.dataTable) th {
            font-weight: 600;
            color: #000 !important;
        }

        .card {
            height: auto !important;
        }
    </style>




    <div class="main-content">
        <nav aria-label="breadcrumb">
            <ol class="breadcrumb">

                <li class="breadcrumb-item"><a href="admin-dashboard.aspx">Home</a></li>
                <li class="breadcrumb-item"><a href="settings.aspx">Masters</a></li>
                <li class="breadcrumb-item active" aria-current="page">Email Type</li>

            </ol>
        </nav>
        <section class="section">
            <div class="row">
                <div class="col-lg-12 col-md-12 col-12 col-sm-12">
                    <div class="card">
                        <div class="card-header">
                            <h4 class="d-block col-md-12">Email Notification
                                <div class="float-right">
                                    <asp:UpdatePanel runat="server" ID="up1">
                                        <ContentTemplate>
                                            <ul class="list-group list-group-horizontal list-unstyled">
                                                <li class="list-group-item">

                                                    <asp:Button ID="btnAddScore" Text="Add New Email Type" runat="server" class="commonbtn" OnClick="btnAddScore_Click" CssClass="btn btn-info btn-lg all" />
                                                </li>
                                                <li class="list-group-item">
                                                    <asp:Button ID="Button1" Text="Add New Email Sub Type" runat="server" class="commonbtn" OnClick="Button1_Click" CssClass="btn btn-info btn-lg all" />
                                                </li>
                                            </ul>
                                        </ContentTemplate>
                                        <Triggers>
                                            <asp:AsyncPostBackTrigger ControlID="btnAddScore" />
                                            <asp:AsyncPostBackTrigger ControlID="Button1" />
                                        </Triggers>
                                    </asp:UpdatePanel>
                                </div>
                            </h4>
                        </div>
                        <div class="card-body">
                            <div class="row" style="margin-top: 20px;">
                                <div id="accordion" class="col-md-12">
                                    <asp:UpdatePanel ID="upd" UpdateMode="Conditional" runat="server">
                                        <ContentTemplate>
                                            <asp:GridView ID="grdEmailType" runat="server" AutoGenerateColumns="false" CssClass="table emailtable" DataKeyNames="Email_type_ID"
                                                OnRowDataBound="grdEmailType_RowDataBound" ShowHeaderWhenEmpty="false" EmptyDataText="No Record Found">
                                                <Columns>
                                                    <asp:TemplateField HeaderStyle-Width="40px">
                                                        <ItemTemplate>
                                                            <img alt="" style="cursor: pointer" src="img/plus.png" height="16px" width="16px" />
                                                            <asp:Panel ID="pnlOrders" runat="server" Style="display: none">

                                                                <asp:Button ID="btnAddGoalNew" Text="Add Email" CssClass="btn btn-info btn-lg all pull-right" runat="server" OnClick="btnAddGoalNew_Click" CommandArgument='<%#Eval("Email_type_ID")%>' />
                                                                <br />
                                                                <br />
                                                                <asp:GridView ID="grdEmail" runat="server" OnRowDataBound="grdEmail_RowDataBound" AutoGenerateColumns="false" CssClass="table emailtable">
                                                                    <Columns>

                                                                        <asp:TemplateField HeaderText="Email Type Name" HeaderStyle-CssClass="text-nowrap" HeaderStyle-Font-Bold="true">
                                                                            <ItemTemplate>
                                                                                <asp:Label ID="lblEmailtype" runat="server" Text='<%#Eval("EMAIL_SUB_TYPE_NAME")%>'></asp:Label>
                                                                            </ItemTemplate>
                                                                        </asp:TemplateField>
                                                                        <asp:TemplateField HeaderText="Subject" HeaderStyle-CssClass="text-nowrap" HeaderStyle-Font-Bold="true" ItemStyle-Width="20%">
                                                                            <ItemTemplate>
                                                                                <asp:Label ID="lblSubject" runat="server" Text='<%#Eval("EM_SUB")%>'></asp:Label>
                                                                            </ItemTemplate>
                                                                        </asp:TemplateField>

                                                                        <asp:TemplateField HeaderText="CC Mail ID" HeaderStyle-Font-Bold="true" ItemStyle-Width="20%">
                                                                            <ItemTemplate>
                                                                                <asp:Label ID="lblCC" runat="server" Text='<%#Eval("EM_CC_ID")%>' Style="overflow-wrap: anywhere;"></asp:Label>
                                                                            </ItemTemplate>
                                                                        </asp:TemplateField>

                                                                        <asp:TemplateField HeaderText="from Mail ID" HeaderStyle-CssClass="text-nowrap" HeaderStyle-Font-Bold="true">
                                                                            <ItemTemplate>
                                                                                <asp:Label ID="lblfrom" runat="server" Text='<%#Eval("EM_FROM_ID")%>'></asp:Label>
                                                                            </ItemTemplate>
                                                                        </asp:TemplateField>
                                                                        <asp:TemplateField HeaderText="Action" HeaderStyle-CssClass="text-nowrap" HeaderStyle-Font-Bold="true">
                                                                            <ItemStyle HorizontalAlign="Left" VerticalAlign="Top" Wrap="True" />
                                                                            <ItemTemplate>
                                                                                <asp:HyperLink ID="hypLnkSM" runat="server">Edit Details</asp:HyperLink>
                                                                                <asp:Label ID="lblCodeID" runat="server" Text='<%#Eval("Email_type_ID")%>' Visible="false"></asp:Label>
                                                                                <asp:Label ID="lblEMID" runat="server" Text='<%#Eval("Em_ID")%>' Visible="false"></asp:Label>
                                                                            </ItemTemplate>
                                                                        </asp:TemplateField>

                                                                    </Columns>
                                                                </asp:GridView>
                                                            </asp:Panel>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>

                                                    <asp:BoundField DataField="Email_type_Name" HeaderText="Email Type" HeaderStyle-CssClass="text-nowrap" HeaderStyle-Font-Bold="true" />
                                                    <asp:TemplateField HeaderText="NA" HeaderStyle-CssClass="hideGridColumn" ItemStyle-CssClass="hideGridColumn">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblCode" runat="server" Text='<%#Eval("Email_type_ID")%>'></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Enable/Disable">
                                                        <ItemTemplate>
                                                            <label class="switch">
                                                                <asp:CheckBox ID="chkOnOff" runat="server" Checked='<%#Convert.ToBoolean(Eval("ISACTIVE"))%>' OnCheckedChanged="chkOnOff_CheckedChanged" AutoPostBack="true" />
                                                                <%--<span class="slider round"></span>--%>
                                                                <div class="slider round">
                                                                    <!--ADDED HTML -->
                                                                    <span class="on">ON</span><span class="off">OFF</span><!--END-->
                                                                </div>
                                                            </label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                </Columns>
                                            </asp:GridView>

                                        </ContentTemplate>
                                        <Triggers>
                                            <asp:PostBackTrigger ControlID="grdEmailType" />
                                        </Triggers>
                                    </asp:UpdatePanel>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </section>
    </div>
    <div class="modal fade" id="myModal1" role="dialog">
        <div class="modal-dialog modal-lg">
            <!-- Modal content-->
            <div class="modal-content">
                <div class="modal-header">
                    <h5 class="modal-title">Email Type</h5>
                    <%--    <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                            <span aria-hidden="true">×</span>
                        </button>--%>
                </div>
                <div class="modal-body">
                    <!--        <button type="button" class="close" data-dismiss="modal">&times;</button>-->
                    <%--  <h4 class="modal-title form-group"></h4>--%>
                    <div class="">
                        <div class="row">
                            <div class="col-md-11">
                                <div class="row">
                                    <div class="col-md-4">
                                        <div class="form-group">
                                            <asp:TextBox ID="txtType" runat="server" CssClass="form-control" placeholder="Email Type" ValidationGroup="AddG3" TabIndex="2" />
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server"
                                                ErrorMessage="Please Enter Email Type" ControlToValidate="txtType" ValidationGroup="type" ForeColor="Red"
                                                Display="Dynamic" CssClass="validation" Font-Size="X-Small"></asp:RequiredFieldValidator>
                                            <%--<label>Email Type</label>--%>
                                        </div>
                                    </div>

                                </div>
                            </div>




                        </div>
                    </div>

                </div>
                <div class="modal-footer bg-whitesmoke br">
                    <div class="btn-group" role="group" aria-label="Basic example">
                        <%--    <div class="col-md-12 text-right">--%>

                        <asp:Button ID="btnSave" runat="server" Text="Save" TabIndex="4" class="btn btn-info btn-lg all" OnClick="btnSave_Click" ValidationGroup="type" CausesValidation="true" />

                        <%--</li>
                                    <li>--%>
                        <%--<button data-dismiss="modal" class="btn btn-info btn-lg all">Cancel</button>--%>
                        <a href="#" class="btn btn-info btn-lg all CloseBtnNew" data-dismiss="modal">Close</a>
                        <%--   </li>
                                </ul>--%>
                        <%--  </div>--%>
                    </div>
                </div>
            </div>

        </div>
    </div>
    <div class="modal fade" id="myModalsub" role="dialog">
        <div class="modal-dialog modal-lg">
            <!-- Modal content-->
            <div class="modal-content">
                <div class="modal-header">
                    <h5 class="modal-title">Email Sub Type</h5>
                    <%--   <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                        <span aria-hidden="true">×</span>
                    </button>--%>
                </div>
                <div class="modal-body">
                    <!--        <button type="button" class="close" data-dismiss="modal">&times;</button>-->
                    <%-- <h4 class="modal-title form-group">Email Sub Type</h4>--%>
                    <div class="">
                        <div class="row">
                            <div class="col-md-11">
                                <div class="row">
                                    <div class="col-md-4">
                                        <div class="form-group">
                                            <asp:DropDownList ID="ddlType" runat="server" CssClass="form-control">
                                            </asp:DropDownList>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" InitialValue="0"
                                                ErrorMessage="Please Enter Email Type" ControlToValidate="ddlType" ValidationGroup="SubType" ForeColor="Red"
                                                Display="Dynamic" CssClass="validation" Font-Size="X-Small"></asp:RequiredFieldValidator>
                                            <%-- <label>Email Type</label>--%>
                                        </div>
                                    </div>
                                    <div class="col-md-4">
                                        <div class="form-group">
                                            <asp:TextBox ID="txtSubType" runat="server" CssClass="form-control" ValidationGroup="AddG3" TabIndex="2" placeholder="Email Sub Type" />
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server"
                                                ErrorMessage="Please Enter Email Sub Type" ControlToValidate="txtSubType" ValidationGroup="SubType" ForeColor="Red"
                                                Display="Dynamic" CssClass="validation" Font-Size="X-Small"></asp:RequiredFieldValidator>
                                            <%-- <label>Email Sub Type</label>--%>
                                        </div>
                                    </div>

                                </div>
                            </div>




                        </div>
                    </div>

                </div>
                <div class="modal-footer bg-whitesmoke br">
                    <div class="btn-group" role="group" aria-label="Basic example">
                        <%-- <div class="col-md-12 text-right">--%>
                        <%--<ul class="list-unstyled list-inline">
                                    <li>--%>
                        <%--<button class="modalbutton" runat="server" onclick="btnAddNewRole"  >Submit</button>--%>
                        <asp:Button ID="btnSubSave" runat="server" Text="Save" TabIndex="4" class="btn btn-info btn-lg all" OnClick="btnSubSave_Click" ValidationGroup="SubType" CausesValidation="true" />

                        <%--                                    </li>
                                    <li>--%>
                        <a href="#" class="btn btn-info btn-lg all CloseBtnNew" data-dismiss="modal">Close</a>

                        <%--   </li>
                                </ul>--%>
                        <%--</div>--%>
                    </div>
                </div>

            </div>

        </div>
    </div>

    <script src="assets/js/jquery-2.1.3.min.js" type="text/javascript"></script>
    <script src="Scripts/bootstrap.min.js"></script>

    <script src="assets/js/app.min.js"></script>
    <script src="assets/js/scripts.js"></script>


    <script type="text/javascript">
        function openModal() {

            $('#myModal1').modal('show');
        }

        function openModalSub() {
            $('#myModalsub').modal('show');
            //        CallMe();
        }
    </script>

    <script type="text/javascript">
        $(document).on('click', '[src*=plus]', function (e) {


            // $("[src*=plus]").live("click", function () {
            $(this).closest("tr").after("<tr><td></td><td colspan = '999'>" + $(this).next().html() + "</td></tr>")
            $(this).attr("src", "img/minus.png");
            $(this).attr("height", "16px");
            $(this).attr("width", "16px");
        });
        $(document).on('click', '[src*=minus]', function (e) {
            // $("[src*=minus]").live("click", function () {
            $(this).attr("src", "img/plus.png");
            $(this).attr("height", "16px");
            $(this).attr("width", "16px");
            $(this).closest("tr").next().remove();
        });

    </script>

    <script>

        //$("select").change(function () {
        //    if ($(this)[0].selectedIndex <= 0) {
        //        $(this).removeClass('changecolor');
        //    }
        //    else {
        //        $(this).addClass('changecolor');
        //    }
        //});




        //textbox effect
        //$(".form-control").val("");
        //$(".form-control").focusout(function () {
        //    if ($(this).val() != "") {
        //        $(this).addClass("has-content");
        //    } else {
        //        $(this).removeClass("has-content");
        //    }
        //});


    </script>
    <script type="text/javascript">


        function CallMe() {

            Stop();
        }

        function Stop() {

            $("#button1").on("click", function () {
                $("[src*=plus]").fadeToggle(200);
                return false; // this will not trigger any server side code to execute.
            });
            return false;
        }

    </script>


</asp:Content>
