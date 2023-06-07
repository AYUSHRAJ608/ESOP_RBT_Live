<%@ Page Title="" Language="C#" MasterPageFile="~/ESOP.Master" AutoEventWireup="true" CodeBehind="vesting-creation.aspx.cs" Inherits="ESOP.vesting_creation" %>

<%--<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>--%>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <title>ESOP-Vesting Creation</title>
    <style>
        .validation {
            font-size: 13px;
        }

        .form-control-Error {
            /*width: 100px;
            height: 34px;*/
            border: 1px solid #DB7791;
        }

        .ddlwidth {
            width: 100%;
        }

        /*aside#sidebar-wrapper {
            background-image: -webkit-linear-gradient(360deg, #3eb0c8 0, #1bc2e9 100%) !important;
        }*/

        .main-sidebar .sidebar-menu li a {
            color: white;
        }

        h2.logo {
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
            border-color: #135d6f;
        }

        .btn-outline-primary, .btn-outline-primary.disabled {
            border-color: #135d6f;
            color: #135d6f;
        }

        .sidebar-mini .main-sidebar:after {
            /*background-image: -webkit-linear-gradient(360deg, #2673FFe0 0, #2673FF 100%) !important;*/
            background-image: -webkit-linear-gradient(360deg, #2600ff 0, #2600ff 100%) !important;
        }

        i.far.fa-bell {
            color: black;
        }

        /*.main-sidebar .sidebar-brand {
            background: #0000001f !important;
        }*/

        .btn-outline-primary {
            color: #135d6f;
            border-color: #135d6f;
        }


        .delete12 {
            padding: 10px;
            background: #e3001b; /*background: #e3001b;*/
            color: white !important;
            border-radius: 4px;
            line-height: 0;
            margin-left: 10px;
            width: 30px;
            /*height: 25px;*/
            margin-top: -29px;
            padding-top: 13px;
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
    </style>


    <style>
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

        .table th {
            padding: .4rem;
            color: #000 !important;
            font-weight: 600 !important;
        }

        .table:not(.table-sm) thead th {
            padding-top: 0px;
            padding-bottom: 0px;
        }

        .table td, .table th {
            padding: 0px;
            padding-left: 5px;
        }

        .table:not(.table-sm) thead th {
            background-color: #6c757d4f;
            color: #000000c2;
            font-size: 14px !important;
            line-height: 1.3;
        }

        .table td {
            font-weight: 500;
            color: #3f646d;
            font-size: 14px;
            background: #bcc0c32e;
        }

        .table:not(.table-sm):not(.table-md):not(.dataTable) td, .table:not(.table-sm):not(.table-md):not(.dataTable) th {
            font-size: 14px;
        }

        table.table-bordered.dataTable tbody th {
            color: #3e454c;
            font-size: 14px !important;
        }

        .table th {
            color: #3e454c;
            background: #96a2b433;
            font-size: 14px !important;
            letter-spacing: 0.2px;
            font-weight: 600 !important;
            text-shadow: none;
            border: 0 !important;
        }

        .table:not(.table-sm):not(.table-md):not(.dataTable) td, .table:not(.table-sm):not(.table-md):not(.dataTable) th {
            padding: 0px 2px;
            vertical-align: middle !important;
            font-size: 14px;
            font-weight: 500;
            text-align: center;
            border: 2px solid #fff !important;
        }

        table.simple-tree-table span.tree-icon.tree-closed, table.simple-tree-table span.tree-icon.tree-opened {
            background-color: #2600ff !important;
            text-align: center;
            cursor: pointer;
            border-radius: 31px;
            color: #fff;
            display: inline-block;
            position: relative !important;
            left: 33% !important;
        }

        .treetablecss th:first-child {
            width: 5px !important;
        }

        table.dataTable img {
            -webkit-box-shadow: 0 5px 15px 0 rgba(105, 103, 103, .5);
            box-shadow: none;
            border: 0px solid #fff;
            border-radius: 10px;
        }

        .section > :first-child {
            margin-top: 15px;
        }
    </style>

    <script src="assets/js/jquery-1.8.3.min.js" type="text/javascript"></script>
    <script src="assets/js/jquery.dataTables-1.10.20.min.js" type="text/javascript"></script>
    <link href="Scripts/jquery.dataTables.min.css" rel="stylesheet" />
    <link href="Scripts/dataTables.bootstrap4.min.css" rel="stylesheet" />

    <script type="text/javascript">
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

    <asp:ScriptManager ID="script" runat="server"></asp:ScriptManager>
    <div class="main-content" style="padding-top: 55px;">
        <nav aria-label="breadcrumb">
            <ol class="breadcrumb">
                <li class="breadcrumb-item"><a href="admin-dashboard.aspx">Home</a></li>

                <li class="breadcrumb-item"><a href="settings.aspx">Masters</a></li>
                <li class="breadcrumb-item active" aria-current="page">Vesting Creation</li>
            </ol>
        </nav>
        <section class="section">
            <div class="row">
                <div class="col-lg-12 col-md-12 col-12 col-sm-12">
                    <div class="card" style="height: 100%;">
                        <div class="card-header">
                            <h4>Create Vesting Cycle</h4>
                        </div>
                        <div class="card-body">
                            <div class="row" style="margin-top: 15px;">
                                <div class="offset-md-2 col-lg-4 col-md-12 col-sm-12">
                                    <div class="form-group">
                                        <label>Vesting Name <span style="color: red">*</span></label>
                                        <%--<input type="text" class="form-control">--%>
                                        <asp:TextBox ID="txtVestingName" runat="server" CssClass="form-control" MaxLength="50"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="rfvVestingName" runat="server"
                                            ErrorMessage="Vesting name is required" ControlToValidate="txtVestingName" ValidationGroup="Add" ForeColor="Red"
                                            Display="None" CssClass="validation" SetFocusOnError="true"></asp:RequiredFieldValidator>

                                    </div>
                                </div>
                                <div class="col-lg-4 col-md-12 col-sm-12">
                                    <div class="form-group">
                                        <label>No. Of Vesting Cycle <span style="color: red">*</span> </label>
                                        <div class="input-group mb-3">
                                            <%--<select class="form-control" id="ddlnoOfCycle" >
                                                <option>Select</option>
                                                <option>1</option>
                                                <option>2</option>
                                                <option>3</option>
                                                <option>4</option>
                                                <option>5</option>
                                            </select>--%>
                                            <asp:DropDownList ID="ddlnoOfCycle1" runat="server" CssClass="form-control" onchange="dropchange()">
                                                <asp:ListItem Value="0">Select</asp:ListItem>
                                                <asp:ListItem Value="1">1</asp:ListItem>
                                                <asp:ListItem Value="2">2</asp:ListItem>
                                                <asp:ListItem Value="3">3</asp:ListItem>
                                                <asp:ListItem Value="4">4</asp:ListItem>
                                                <asp:ListItem Value="5">5</asp:ListItem>
                                            </asp:DropDownList>
                                            <asp:RequiredFieldValidator ID="ddddlnoOfCycle1" runat="server"
                                                ErrorMessage="Please select No. of vesting cycle" ControlToValidate="ddlnoOfCycle1" ValidationGroup="Add" ForeColor="Red" InitialValue="0"
                                                Display="None" CssClass="validation" SetFocusOnError="true"></asp:RequiredFieldValidator>
                                        </div>
                                    </div>
                                </div>
                                <div class="table-responsive">
                                    <table class="offset-md-2 table" style="width: 70%;">
                                        <tbody id="noOfVestingTable">
                                            <tr id="trV1" style="display: none">
                                                <td>
                                                    <div class="form-group" style="margin-bottom: -2px;">
                                                        <%--<input type="text" class="form-control" value="v' + (i + 1) + '" disabled="">--%>
                                                        <asp:TextBox ID="txtv1" runat="server" CssClass="form-control" Text="v1" Enabled="false"></asp:TextBox>
                                                    </div>
                                                </td>
                                                <td>
                                                    <div class="form-group" style="margin-bottom: -2px;">
                                                        <%--<input type="text" class="form-control" placeholder="Vesting Cycle %">--%>
                                                        <asp:TextBox ID="txtperc1" runat="server" CssClass="form-control" placeholder="Vesting %"
                                                            onkeypress="return isNumberKey(event,this.id)" MaxLength="3"></asp:TextBox>
                                                        <asp:RequiredFieldValidator ID="rfvperc1" runat="server"
                                                            ErrorMessage="Vesting Cycle % is required" ControlToValidate="txtperc1" ValidationGroup="Add" ForeColor="Red"
                                                            Display="None" CssClass="validation" SetFocusOnError="true"></asp:RequiredFieldValidator>
                                                    </div>
                                                </td>
                                                <td>
                                                    <div class="form-group">
                                                        <div class="input-group mb-3">
                                                            <asp:UpdatePanel ID="Updatepanel5" runat="server">
                                                                <ContentTemplate>
                                                                    <asp:DropDownList ID="ddlduration1" runat="server" Style="margin-bottom: -2px; margin-top: 16px; width: 300px;"
                                                                        CssClass="form-control ddlwidth" OnSelectedIndexChanged="ddlduration1_SelectedIndexChanged" AutoPostBack="true">
                                                                    </asp:DropDownList>
                                                                    <asp:RequiredFieldValidator ID="rfvduration1" runat="server"
                                                                        ErrorMessage="Please select duration" ControlToValidate="ddlduration1" ValidationGroup="Add" ForeColor="Red" InitialValue="0"
                                                                        Display="None" CssClass="validation" SetFocusOnError="true"></asp:RequiredFieldValidator>
                                                                </ContentTemplate>
                                                                <%--<Triggers>
                                                                    <asp:AsyncPostBackTrigger ControlID="ddlduration1" />
                                                                </Triggers>--%>
                                                            </asp:UpdatePanel>
                                                        </div>
                                                    </div>
                                                </td>
                                            </tr>
                                            <tr id="trV2" style="display: none">
                                                <td>
                                                    <div class="form-group" style="margin-bottom: -2px;">
                                                        <%--<input type="text" class="form-control" value="v' + (i + 1) + '" disabled="">--%>
                                                        <asp:TextBox ID="txtv2" runat="server" CssClass="form-control" Text="v2" Enabled="false"></asp:TextBox>
                                                    </div>
                                                </td>
                                                <td>
                                                    <div class="form-group" style="margin-bottom: -2px;">
                                                        <%--<input type="text" class="form-control" placeholder="Vesting Cycle %">--%>
                                                        <asp:TextBox ID="txtperc2" runat="server" CssClass="form-control" placeholder="Vesting %"
                                                            onkeypress="return isNumberKey(event,this.id)" MaxLength="3"></asp:TextBox>
                                                        <asp:RequiredFieldValidator ID="rfvtxtperc2" runat="server"
                                                            ErrorMessage="Vesting Cycle % is required" ControlToValidate="txtperc2" ValidationGroup="Add" ForeColor="Red"
                                                            Display="None" CssClass="validation" SetFocusOnError="true"></asp:RequiredFieldValidator>
                                                    </div>
                                                </td>
                                                <td>
                                                    <div class="form-group">
                                                        <div class="input-group mb-3">

                                                            <asp:UpdatePanel ID="Updatepanel1" runat="server">
                                                                <ContentTemplate>
                                                                    <asp:DropDownList ID="ddlduration2" runat="server" Style="margin-bottom: -2px; margin-top: 16px; width: 300px;" CssClass="form-control ddlwidth"
                                                                        OnSelectedIndexChanged="ddlduration2_SelectedIndexChanged" AutoPostBack="true">
                                                                    </asp:DropDownList>
                                                                    <asp:RequiredFieldValidator ID="rfvduration2" runat="server"
                                                                        ErrorMessage="Please select duration" ControlToValidate="ddlduration2" ValidationGroup="Add" ForeColor="Red" InitialValue="0"
                                                                        Display="None" CssClass="validation" SetFocusOnError="true"></asp:RequiredFieldValidator>
                                                                </ContentTemplate>
                                                                <Triggers>
                                                                    <asp:AsyncPostBackTrigger ControlID="ddlduration1" />
                                                                </Triggers>
                                                            </asp:UpdatePanel>
                                                        </div>
                                                    </div>
                                                </td>
                                            </tr>
                                            <tr id="trV3" style="display: none">
                                                <td>
                                                    <div class="form-group" style="margin-bottom: -2px;">
                                                        <%--<input type="text" class="form-control" value="v' + (i + 1) + '" disabled="">--%>
                                                        <asp:TextBox ID="txtv3" runat="server" CssClass="form-control" Text="v3" Enabled="false"></asp:TextBox>
                                                    </div>
                                                </td>
                                                <td>
                                                    <div class="form-group" style="margin-bottom: -2px;">
                                                        <%--<input type="text" class="form-control" placeholder="Vesting Cycle %">--%>
                                                        <asp:TextBox ID="txtperc3" runat="server" CssClass="form-control" placeholder="Vesting %"
                                                            onkeypress="return isNumberKey(event,this.id)" MaxLength="3"></asp:TextBox>
                                                        <asp:RequiredFieldValidator ID="rfvtxtperc3" runat="server"
                                                            ErrorMessage="Vesting Cycle % is required" ControlToValidate="txtperc3" ValidationGroup="Add" ForeColor="Red"
                                                            Display="None" CssClass="validation" SetFocusOnError="true"></asp:RequiredFieldValidator>
                                                    </div>
                                                </td>
                                                <td>
                                                    <div class="form-group">
                                                        <div class="input-group mb-3">

                                                            <asp:UpdatePanel ID="Updatepanel2" runat="server">
                                                                <ContentTemplate>
                                                                    <asp:DropDownList ID="ddlduration3" runat="server" Style="margin-bottom: -2px; margin-top: 16px; width: 300px;" CssClass="form-control"
                                                                        OnSelectedIndexChanged="ddlduration3_SelectedIndexChanged" AutoPostBack="true">
                                                                    </asp:DropDownList>
                                                                    <asp:RequiredFieldValidator ID="rfvduration3" runat="server"
                                                                        ErrorMessage="Please select duration" ControlToValidate="ddlduration3" ValidationGroup="Add" ForeColor="Red" InitialValue="0"
                                                                        Display="None" CssClass="validation" SetFocusOnError="true"></asp:RequiredFieldValidator>
                                                                </ContentTemplate>
                                                                <Triggers>
                                                                    <asp:AsyncPostBackTrigger ControlID="ddlduration2" />
                                                                </Triggers>
                                                            </asp:UpdatePanel>
                                                        </div>
                                                    </div>
                                                </td>
                                            </tr>
                                            <tr id="trV4" style="display: none">
                                                <td>
                                                    <div class="form-group" style="margin-bottom: -2px;">
                                                        <%--<input type="text" class="form-control" value="v' + (i + 1) + '" disabled="">--%>
                                                        <asp:TextBox ID="txtv4" runat="server" CssClass="form-control" Text="v4" Enabled="false"></asp:TextBox>
                                                    </div>
                                                </td>
                                                <td>
                                                    <div class="form-group" style="margin-bottom: -2px;">
                                                        <%--<input type="text" class="form-control" placeholder="Vesting Cycle %">--%>
                                                        <asp:TextBox ID="txtperc4" runat="server" CssClass="form-control" placeholder="Vesting %"
                                                            onkeypress="return isNumberKey(event,this.id)" MaxLength="3"></asp:TextBox>
                                                    </div>
                                                    <asp:RequiredFieldValidator ID="rfvtxtperc4" runat="server"
                                                        ErrorMessage="Vesting Cycle % is required" ControlToValidate="txtperc4" ValidationGroup="Add" ForeColor="Red"
                                                        Display="None" CssClass="validation" SetFocusOnError="true"></asp:RequiredFieldValidator>
                                                </td>
                                                <td>
                                                    <div class="form-group">
                                                        <div class="input-group mb-3">

                                                            <asp:UpdatePanel ID="Updatepanel3" runat="server">
                                                                <ContentTemplate>
                                                                    <asp:DropDownList ID="ddlduration4" runat="server" Style="margin-bottom: -2px; margin-top: 16px; width: 300px;" CssClass="form-control"
                                                                        OnSelectedIndexChanged="ddlduration4_SelectedIndexChanged" AutoPostBack="true">
                                                                    </asp:DropDownList>
                                                                    <asp:RequiredFieldValidator ID="rfvddlduration4" runat="server"
                                                                        ErrorMessage="Please select duration" ControlToValidate="ddlduration4" ValidationGroup="Add" ForeColor="Red" InitialValue="0"
                                                                        Display="None" CssClass="validation" SetFocusOnError="true"></asp:RequiredFieldValidator>
                                                                </ContentTemplate>
                                                                <Triggers>
                                                                    <asp:AsyncPostBackTrigger ControlID="ddlduration3" />
                                                                </Triggers>
                                                            </asp:UpdatePanel>
                                                        </div>
                                                    </div>
                                                </td>
                                            </tr>
                                            <tr id="trV5" style="display: none">
                                                <td>
                                                    <div class="form-group" style="margin-bottom: -2px;">
                                                        <%--<input type="text" class="form-control" value="v' + (i + 1) + '" disabled="">--%>
                                                        <asp:TextBox ID="txtv5" runat="server" CssClass="form-control" Text="v5" Enabled="false"></asp:TextBox>
                                                    </div>
                                                </td>
                                                <td>
                                                    <div class="form-group" style="margin-bottom: -2px;">
                                                        <%--<input type="text" class="form-control" placeholder="Vesting Cycle %">--%>
                                                        <asp:TextBox ID="txtperc5" runat="server" CssClass="form-control" placeholder="Vesting %"
                                                            onkeypress="return isNumberKey(event,this.id)" MaxLength="3"></asp:TextBox>
                                                        <asp:RequiredFieldValidator ID="rfvtxtperc5" runat="server"
                                                            ErrorMessage="Vesting Cycle % is required" ControlToValidate="txtperc5" ValidationGroup="Add" ForeColor="Red"
                                                            Display="None" CssClass="validation" SetFocusOnError="true"></asp:RequiredFieldValidator>
                                                    </div>
                                                </td>
                                                <td>
                                                    <div class="form-group">
                                                        <div class="input-group mb-3">

                                                            <asp:UpdatePanel ID="Updatepanel4" runat="server">
                                                                <ContentTemplate>
                                                                    <asp:DropDownList ID="ddlduration5" runat="server" Style="margin-bottom: -2px; margin-top: 16px; width: 300px;" CssClass="form-control">
                                                                    </asp:DropDownList>
                                                                    <asp:RequiredFieldValidator ID="rfvddlduration5" runat="server"
                                                                        ErrorMessage="Please select duration" ControlToValidate="ddlduration5" ValidationGroup="Add" ForeColor="Red" InitialValue="0"
                                                                        Display="None" CssClass="validation" SetFocusOnError="true"></asp:RequiredFieldValidator>
                                                                </ContentTemplate>
                                                                <Triggers>
                                                                    <asp:AsyncPostBackTrigger ControlID="ddlduration4" />
                                                                </Triggers>
                                                            </asp:UpdatePanel>
                                                        </div>
                                                    </div>
                                                </td>
                                            </tr>

                                        </tbody>
                                    </table>
                                </div>

                                <div class="col-lg-3 offset-md-5 mt-5">
                                    <%--<asp:UpdatePanel runat="server" ID="upd1">
                                        <ContentTemplate>--%>
                                    <%--<a href="#" class="btn btn-info btn-lg all" id="btnimport">Create Vesting Cycle</a>--%>
                                    <asp:ValidationSummary runat="server" ShowMessageBox="true" ShowSummary="false" ValidationGroup="Add" />
                                    <asp:Button ID="btnimport" CssClass="btn btn-info btn-lg all" runat="server" OnClientClick="return GetSelectedItem('ddlnoOfCycle1');"
                                        Text="Create Vesting Cycle" ValidationGroup="Add" OnClick="btnimport_Click" CausesValidation="true" />
                                    <%-- </ContentTemplate>
                                    </asp:UpdatePanel>--%>
                                </div>



                            </div>
                        </div>
                        <div style="color: red; margin-right: 10px; text-align: right">
                            All (*) marked fields are mandatory.
                        </div>
                        <asp:UpdatePanel ID="upd2" runat="server">
                            <ContentTemplate>
                                <div id="showmsg" runat="server" align="center"></div>
                            </ContentTemplate>
                        </asp:UpdatePanel>
                    </div>
                </div>
            </div>
            <div class="col-lg-12 col-md-12 col-12 col-sm-12" id="tablediv">
                <div class="card mt-4" style="height: auto;">
                    <div class="card-header">
                        <h4>Record Summary</h4>
                    </div>
                    <div class="card-body">
                        <table class="table table-bordered simple-tree-table" id="basic">
                            <tbody>
                                <tr>
                                    <th>No. of Vesting Cycle</th>
                                    <th colspan="2">Vesting Cycle Name</th>
                                </tr>
                                <tr data-node-id="1">
                                    <td><span class="tree-icon tree-opened" style="margin-left: 0px;"></span>2</td>
                                    <td colspan="2">V1</td>
                                </tr>
                                <tr data-node-id="a" data-node-pid="1" style="">
                                    <th style="color: black; border-bottom: 1px solid #239ebb73 !important;">T1</th>
                                    <th colspan="2" style="color: black; border-bottom: 1px solid #239ebb73 !important;"></th>
                                    <span class="tree-icon tree-opened" style="margin-left: 20px;"></span></td>
                                </tr>
                                <tr data-node-id="1.2" data-node-pid="a" style="">
                                    <td><span class="tree-icon" style="margin-left: 40px;"></span>Vesting Cycle %</td>
                                    <td>25%</td>
                                    <td>2 Years</td>
                                </tr>
                                <tr data-node-id="1.3" data-node-pid="a" style="">
                                    <td><span class="tree-icon" style="margin-left: 40px;"></span>Vesting Cycle Duration</td>
                                    <td>50%</td>
                                    <td>3 Years</td>
                                </tr>

                                <tr data-node-id="a.1" data-node-pid="1" style="">
                                    <th style="color: black; border-bottom: 1px solid #239ebb73 !important;">T2</th>
                                    <th colspan="2" style="color: black; border-bottom: 1px solid #239ebb73 !important;"></th>
                                    <span class="tree-icon tree-opened" style="margin-left: 20px;"></span></td>
                                </tr>
                                <tr data-node-id="1.4" data-node-pid="a.1" style="">
                                    <td><span class="tree-icon" style="margin-left: 40px;"></span>Vesting Cycle %</td>
                                    <td>25%</td>
                                    <td>2 Years</td>
                                </tr>
                                <tr data-node-id="1.5" data-node-pid="a.1" style="">
                                    <td><span class="tree-icon" style="margin-left: 40px;"></span>Vesting Cycle Duration</td>
                                    <td>50%</td>
                                    <td>3 Years</td>
                                </tr>
                            </tbody>
                        </table>
                    </div>
                </div>
            </div>
            <div class="col-lg-12 col-md-12 col-12 col-sm-12" id="tablediv">
                <div class="card mt-4" style="height: auto;">
                    <div class="card-header">
                        <h4>Record Summary</h4>
                    </div>
                    <div class="card-body">
                        <div class="table-responsive" style="margin-top: 5px;">
                            <asp:UpdatePanel ID="upd" UpdateMode="Conditional" runat="server">
                                <ContentTemplate>
                                    <asp:GridView ID="gvVesting" runat="server" AutoGenerateColumns="false" ShowHeaderWhenEmpty="false"
                                        OnPreRender="gvVesting_PreRender" CssClass="table table-bordered simple-tree-table treetablecss" DataKeyNames="VID" OnRowDataBound="gvVesting_RowDataBound"
                                        Style="border-collapse: separate;" EmptyDataText="No Record Found" EmptyDataRowStyle-CssClass="Empty"
                                        OnRowDeleting="gvVesting_RowDeleting">
                                        <Columns>
                                            <asp:TemplateField HeaderStyle-Width="4%">
                                                <ItemTemplate>
                                                    <img alt="" style="cursor: pointer" src="assets/img/plus.svg" height="25px" width="25px" />
                                                    <asp:Panel ID="pnlOrders" runat="server" Style="display: none">
                                                        <asp:GridView ID="gvVestingDetails" runat="server" AutoGenerateColumns="false" CssClass="table goaltable"
                                                            Style="border-collapse: separate; border-spacing: 4px;">
                                                            <Columns>
                                                                <%--<asp:TemplateField HeaderText="Sr No" HeaderStyle-Font-Bold="true">
                                                                <ItemTemplate>
                                                                    <span class="numbers">
                                                                        <%#Container.DataItemIndex+1 %></span>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>--%>
                                                                <asp:BoundField DataField="VCYCLENAME" HeaderText="Vesting Cycle Name" FooterText="Total" HeaderStyle-CssClass="text-nowrap"
                                                                    HeaderStyle-Font-Bold="true" HeaderStyle-Width="32%">
                                                                    <ItemStyle HorizontalAlign="Left" VerticalAlign="Top" Wrap="True" />
                                                                    <FooterStyle Font-Bold="true" />
                                                                </asp:BoundField>

                                                                <asp:BoundField DataField="PERCENTAGE" HeaderStyle-Font-Bold="true" HeaderText="Vesting %" FooterText="Total"
                                                                    HeaderStyle-Width="37%">
                                                                    <ItemStyle HorizontalAlign="Left" VerticalAlign="Top" Wrap="True" />
                                                                </asp:BoundField>

                                                                <asp:BoundField DataField="DURATION" HeaderText="Vesting Duration" HeaderStyle-Font-Bold="true"
                                                                    HeaderStyle-Width="31%">
                                                                    <ItemStyle HorizontalAlign="Left" VerticalAlign="Top" Wrap="True" />
                                                                </asp:BoundField>

                                                            </Columns>
                                                        </asp:GridView>
                                                    </asp:Panel>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <%--<asp:BoundField DataField="VID" HeaderStyle-Font-Bold="true" HeaderText="VID">
                                            <ItemStyle HorizontalAlign="Left" VerticalAlign="Top" Wrap="True" />
                                        </asp:BoundField>--%>
                                            <asp:TemplateField HeaderText="No. of Vesting Cycle" HeaderStyle-CssClass="text-nowrap" HeaderStyle-Font-Bold="true" HeaderStyle-Width="31%">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblVID" runat="server" Text='<%#Eval("VID")%>' Visible="false"></asp:Label>
                                                    <asp:Label ID="lblVNAME" runat="server" Text='<%#Eval("VCYCLE")%>' Visible="true"></asp:Label>


                                                    <asp:HiddenField ID="IsExpanded" ClientIDMode="AutoID" runat="server" />
                                                </ItemTemplate>
                                            </asp:TemplateField>

                                            <asp:BoundField DataField="VNAME" HeaderStyle-Font-Bold="true" HeaderText="Vesting Name" HeaderStyle-Width="35%">
                                                <ItemStyle HorizontalAlign="Left" VerticalAlign="Top" Wrap="True" />
                                            </asp:BoundField>
                                            <asp:TemplateField HeaderText="Action" HeaderStyle-CssClass="text-nowrap" HeaderStyle-Font-Bold="true" HeaderStyle-Width="29%">
                                                <ItemTemplate>
                                                    <label class="switch">
                                                        <asp:CheckBox ID="chkOnOff" runat="server" OnCheckedChanged="chkOnOff_CheckedChanged" AutoPostBack="true"
                                                            Checked='<%# Convert.ToBoolean(Eval("ISACTIVE"))%>' />
                                                        <%--<span class="slider round"></span>--%>
                                                        <div class="slider round">
                                                            <!--ADDED HTML -->
                                                            <span class="on">ON</span><span class="off">OFF</span><!--END-->
                                                        </div>
                                                    </label>
                                                    <asp:LinkButton ID="btn_Delete" runat="server" CommandName="Delete" CausesValidation="false"
                                                        CssClass="fas fa-trash-alt delete12" Style="vertical-align: middle;"></asp:LinkButton>
                                                    <%-- OnClientClick="return confirm('Are you sure you want to Delete record?');"--%>
                                                </ItemTemplate>
                                            </asp:TemplateField>

                                        </Columns>
                                    </asp:GridView>
                                </ContentTemplate>
                                <Triggers>
                                    <asp:AsyncPostBackTrigger ControlID="gvVesting" />
                                </Triggers>
                            </asp:UpdatePanel>
                        </div>
                    </div>
                </div>
            </div>
        </section>
    </div>

    <script type="text/javascript">

        var prm = Sys.WebForms.PageRequestManager.getInstance();
        prm.add_endRequest(function (sender, e) {
            var table = $('#ContentPlaceHolder1_gvVesting').DataTable({
                lengthMenu: [[-1, 5, 10], ["All", 5, 10]],
                order: [],
                columnDefs: [{ orderable: false, targets: [0, 3] }],
                bRetrieve: true

            });
        });

        $(function () {
            debugger;
            $.noConflict();
            var table = $("#ContentPlaceHolder1_gvVesting").DataTable({
                bLengthChange: true,
                lengthMenu: [[-1, 5, 10], ["All", 5, 10]],
                bFilter: true,
                order: [],
                columnDefs: [{ orderable: false, targets: [0, 3] }],
                bPaginate: true,
                bSort: true
            });
            table
  .search('')
  .columns().search('')
  .draw();
        });
    </script>
    <script src="Scripts/bootstrap.min.js"></script>
    <script src="assets/js/app.min.js"></script>

    <script src="assets/js/scripts.js"></script>

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

    <script>
        function isNumberKey(evt, id) {
            try {
                var charCode = (evt.which) ? evt.which : event.keyCode;


                if ((charCode < 48 || charCode > 57))
                    return false;

                return true;
            } catch (w) {
                alert(w);
            }
        }

        $(function () {
            <%--//var DropDownID = Document.getElementById('<%= ddlnoOfCycle.ClientID %>');--%>

            $("#ddlnoOfCycle").change(function () {
                if ($(this).val() == "1") {
                    $("#trV1").show();
                    $("#trV2").hide();
                    $("#trV3").hide();
                    $("#trV4").hide();
                    $("#trV5").hide();

                }

                else if ($(this).val() == "2") {
                    $("#trV1").show();
                    $("#trV2").show();
                    $("#trV3").hide();
                    $("#trV4").hide();
                    $("#trV5").hide();

                }
                else if ($(this).val() == "3") {
                    $("#trV1").show();
                    $("#trV2").show();
                    $("#trV3").show();
                    $("#trV4").hide();
                    $("#trV5").hide();



                }
                else if ($(this).val() == "4") {
                    $("#trV1").show();
                    $("#trV2").show();
                    $("#trV3").show();
                    $("#trV4").show();
                    $("#trV5").hide();


                }
                else if ($(this).val() == "5") {
                    $("#trV1").show();
                    $("#trV2").show();
                    $("#trV3").show();
                    $("#trV4").show();
                    $("#trV5").show();
                }
                else {
                    $("#trV1").hide();
                    $("#trV2").hide();
                    $("#trV3").hide();
                    $("#trV4").hide();
                    $("#trV5").hide();
                }
            });
        });
        function ValidatePercent() {
            var DropDownID = $('#ddlnoOfCycle').val();
            alert(DropDownID);

        }

        function GetSelectedItem(el) {
            //var e = document.getElementById(el);
            //var count = e.options[e.selectedIndex].value;
           <%-- var ddl = Document.getElementById('<%= ddlnoOfCycle1.ClientID %>');
            var selectedVal = ddl.value;--%>
            var isValid = true;
            var e = document.getElementById('<%=ddlnoOfCycle1.ClientID%>');
            var count = e.value;
            if (count == "0") {
                ValidatorEnable(document.getElementById("<%=rfvperc1.ClientID %>"), false);
                ValidatorEnable(document.getElementById("<%=rfvtxtperc2.ClientID %>"), false);
                ValidatorEnable(document.getElementById("<%=rfvtxtperc3.ClientID %>"), false);
                ValidatorEnable(document.getElementById("<%=rfvtxtperc4.ClientID %>"), false);
                ValidatorEnable(document.getElementById("<%=rfvtxtperc5.ClientID %>"), false);
                ValidatorEnable(document.getElementById("<%=rfvduration1.ClientID %>"), false);
                ValidatorEnable(document.getElementById("<%=rfvduration2.ClientID %>"), false);
                ValidatorEnable(document.getElementById("<%=rfvduration3.ClientID %>"), false);
                ValidatorEnable(document.getElementById("<%=rfvddlduration4.ClientID %>"), false);
                ValidatorEnable(document.getElementById("<%=rfvddlduration5.ClientID %>"), false);
                if (Page_ClientValidate()) {
                }
            }
            else if (count == "1") {
                ValidatorEnable(document.getElementById("<%=rfvperc1.ClientID %>"), true);
                ValidatorEnable(document.getElementById("<%=rfvtxtperc2.ClientID %>"), false);
                ValidatorEnable(document.getElementById("<%=rfvtxtperc3.ClientID %>"), false);
                ValidatorEnable(document.getElementById("<%=rfvtxtperc4.ClientID %>"), false);
                ValidatorEnable(document.getElementById("<%=rfvtxtperc5.ClientID %>"), false);
                ValidatorEnable(document.getElementById("<%=rfvduration1.ClientID %>"), true);
                ValidatorEnable(document.getElementById("<%=rfvduration2.ClientID %>"), false);
                ValidatorEnable(document.getElementById("<%=rfvduration3.ClientID %>"), false);
                ValidatorEnable(document.getElementById("<%=rfvddlduration4.ClientID %>"), false);
                ValidatorEnable(document.getElementById("<%=rfvddlduration5.ClientID %>"), false);
                //var percent1 = Document.getElementById('<%= txtperc1.ClientID %>').val();
                if (Page_ClientValidate()) {
                    var percent1 = document.getElementById("ContentPlaceHolder1_txtperc1").value;
                    if (percent1 == 0) {

                        alert('First vesting cycle should not be 0 percent');
                        document.getElementById('<%=txtperc1.ClientID%>').focus();
                        isValid = false;
                        return false;
                    }

                    if (percent1 != 100) {

                        alert('Total of vesting cycle should be 100 percent');
                        isValid = false;
                    }
                }
                //else {
                //    return true;
                //}
            }
            else if (count == "2") {
                ValidatorEnable(document.getElementById("<%=rfvperc1.ClientID %>"), true);
                ValidatorEnable(document.getElementById("<%=rfvtxtperc2.ClientID %>"), true);
                ValidatorEnable(document.getElementById("<%=rfvtxtperc3.ClientID %>"), false);
                ValidatorEnable(document.getElementById("<%=rfvtxtperc4.ClientID %>"), false);
                ValidatorEnable(document.getElementById("<%=rfvtxtperc5.ClientID %>"), false);
                ValidatorEnable(document.getElementById("<%=rfvduration1.ClientID %>"), true);
                ValidatorEnable(document.getElementById("<%=rfvduration2.ClientID %>"), true);
                ValidatorEnable(document.getElementById("<%=rfvduration3.ClientID %>"), false);
                ValidatorEnable(document.getElementById("<%=rfvddlduration4.ClientID %>"), false);
                ValidatorEnable(document.getElementById("<%=rfvddlduration5.ClientID %>"), false);
                //var percent1 = Document.getElementById('<%= txtperc1.ClientID %>').val();
                var percent1 = document.getElementById("ContentPlaceHolder1_txtperc1").value;
                var percent2 = document.getElementById("ContentPlaceHolder1_txtperc2").value;
                if (Page_ClientValidate()) {
                    if (percent1 == 0) {

                        alert('First vesting cycle should not be 0 percent');
                        document.getElementById('<%=txtperc1.ClientID%>').focus();
                        isValid = false;
                        return false;

                    }

                    if (percent2 == 0) {

                        alert('Second vesting cycle should not be 0 percent');
                        document.getElementById('<%=txtperc2.ClientID%>').focus();
                        isValid = false;
                        return false;

                    }

                    if ((parseInt(percent1) + parseInt(percent2)) != 100) {

                        alert('Total of vesting cycle should be 100 percent');
                        isValid = false;
                    }
                }
                //else {
                //    return true;
                //}
            }
            else if (count == "3") {
                ValidatorEnable(document.getElementById("<%=rfvperc1.ClientID %>"), true);
                ValidatorEnable(document.getElementById("<%=rfvtxtperc2.ClientID %>"), true);
                ValidatorEnable(document.getElementById("<%=rfvtxtperc3.ClientID %>"), true);
                ValidatorEnable(document.getElementById("<%=rfvtxtperc4.ClientID %>"), false);
                ValidatorEnable(document.getElementById("<%=rfvtxtperc5.ClientID %>"), false);
                ValidatorEnable(document.getElementById("<%=rfvduration1.ClientID %>"), true);
                ValidatorEnable(document.getElementById("<%=rfvduration2.ClientID %>"), true);
                ValidatorEnable(document.getElementById("<%=rfvduration3.ClientID %>"), true);
                ValidatorEnable(document.getElementById("<%=rfvddlduration4.ClientID %>"), false);
                ValidatorEnable(document.getElementById("<%=rfvddlduration5.ClientID %>"), false);
                //var percent1 = Document.getElementById('<%= txtperc1.ClientID %>').val();
                var percent1 = document.getElementById("ContentPlaceHolder1_txtperc1").value;
                var percent2 = document.getElementById("ContentPlaceHolder1_txtperc2").value;
                var percent3 = document.getElementById("ContentPlaceHolder1_txtperc3").value;
                if (Page_ClientValidate()) {
                    if (percent1 == 0) {

                        alert('First vesting cycle should not be 0 percent');
                        document.getElementById('<%=txtperc1.ClientID%>').focus();
                        isValid = false;
                        return false;

                    }

                    if (percent2 == 0) {

                        alert('Second vesting cycle should not be 0 percent');
                        document.getElementById('<%=txtperc2.ClientID%>').focus();
                        isValid = false;
                        return false;

                    }


                    if (percent3 == 0) {

                        alert('Third vesting cycle should not be 0 percent');
                        document.getElementById('<%=txtperc3.ClientID%>').focus();
                        isValid = false;
                        return false;

                    }


                    if ((parseInt(percent1) + parseInt(percent2) + parseInt(percent3)) != 100) {

                        alert('Total of vesting cycle should be 100 percent');
                        isValid = false;
                    }
                }
                //else {
                //    return true;
                //}
            }
            else if (count == "4") {
                ValidatorEnable(document.getElementById("<%=rfvperc1.ClientID %>"), true);
                ValidatorEnable(document.getElementById("<%=rfvtxtperc2.ClientID %>"), true);
                ValidatorEnable(document.getElementById("<%=rfvtxtperc3.ClientID %>"), true);
                ValidatorEnable(document.getElementById("<%=rfvtxtperc4.ClientID %>"), true);
                ValidatorEnable(document.getElementById("<%=rfvtxtperc5.ClientID %>"), false);
                ValidatorEnable(document.getElementById("<%=rfvduration1.ClientID %>"), true);
                ValidatorEnable(document.getElementById("<%=rfvduration2.ClientID %>"), true);
                ValidatorEnable(document.getElementById("<%=rfvduration3.ClientID %>"), true);
                ValidatorEnable(document.getElementById("<%=rfvddlduration4.ClientID %>"), true);
                ValidatorEnable(document.getElementById("<%=rfvddlduration5.ClientID %>"), false);
                //var percent1 = Document.getElementById('<%= txtperc1.ClientID %>').val();
                var percent1 = document.getElementById("ContentPlaceHolder1_txtperc1").value;
                var percent2 = document.getElementById("ContentPlaceHolder1_txtperc2").value;
                var percent3 = document.getElementById("ContentPlaceHolder1_txtperc3").value;
                var percent4 = document.getElementById("ContentPlaceHolder1_txtperc4").value;
                if (Page_ClientValidate()) {

                    if (percent1 == 0) {

                        alert('First vesting cycle should not be 0 percent');
                        document.getElementById('<%=txtperc1.ClientID%>').focus();
                        isValid = false;
                        return false;

                    }

                    if (percent2 == 0) {

                        alert('Second vesting cycle should not be 0 percent');
                        document.getElementById('<%=txtperc2.ClientID%>').focus();
                        isValid = false;
                        return false;

                    }


                    if (percent3 == 0) {

                        alert('Third vesting cycle should not be 0 percent');
                        document.getElementById('<%=txtperc3.ClientID%>').focus();
                        isValid = false;
                        return false;

                    }

                    if (percent4 == 0) {

                        alert('Fourth vesting cycle should not be 0 percent');
                        document.getElementById('<%=txtperc4.ClientID%>').focus();
                        isValid = false;
                        return false;

                    }




                    if ((parseInt(percent1) + parseInt(percent2) + parseInt(percent3) + parseInt(percent4)) != 100) {

                        alert('Total of vesting cycle should be 100 percent');
                        isValid = false;
                    }
                }
                //else {
                //    return true;
                //}
            }
            else if (count == "5") {
                //var percent1 = Document.getElementById('<%= txtperc1.ClientID %>').val();
                ValidatorEnable(document.getElementById("<%=rfvperc1.ClientID %>"), true);
                ValidatorEnable(document.getElementById("<%=rfvtxtperc2.ClientID %>"), true);
                ValidatorEnable(document.getElementById("<%=rfvtxtperc3.ClientID %>"), true);
                ValidatorEnable(document.getElementById("<%=rfvtxtperc4.ClientID %>"), true);
                ValidatorEnable(document.getElementById("<%=rfvtxtperc5.ClientID %>"), true);
                ValidatorEnable(document.getElementById("<%=rfvduration1.ClientID %>"), true);
                ValidatorEnable(document.getElementById("<%=rfvduration2.ClientID %>"), true);
                ValidatorEnable(document.getElementById("<%=rfvduration3.ClientID %>"), true);
                ValidatorEnable(document.getElementById("<%=rfvddlduration4.ClientID %>"), true);
                ValidatorEnable(document.getElementById("<%=rfvddlduration5.ClientID %>"), true);
                var percent1 = document.getElementById("ContentPlaceHolder1_txtperc1").value;
                var percent2 = document.getElementById("ContentPlaceHolder1_txtperc2").value;
                var percent3 = document.getElementById("ContentPlaceHolder1_txtperc3").value;
                var percent4 = document.getElementById("ContentPlaceHolder1_txtperc4").value;
                var percent5 = document.getElementById("ContentPlaceHolder1_txtperc5").value;
                if (Page_ClientValidate()) {

                    if (percent1 == 0) {

                        alert('First vesting cycle should not be 0 percent');
                        document.getElementById('<%=txtperc1.ClientID%>').focus();
                        isValid = false;
                        return false;

                    }

                    if (percent2 == 0) {

                        alert('Second vesting cycle should not be 0 percent');
                        document.getElementById('<%=txtperc2.ClientID%>').focus();
                        isValid = false;
                        return false;

                    }


                    if (percent3 == 0) {

                        alert('Third vesting cycle should not be 0 percent');
                        document.getElementById('<%=txtperc3.ClientID%>').focus();
                        isValid = false;
                        return false;

                    }

                    if (percent4 == 0) {

                        alert('Fourth vesting cycle should not be 0 percent');
                        document.getElementById('<%=txtperc4.ClientID%>').focus();
                        isValid = false;
                        return false;

                    }


                    if (percent5 == 0) {

                        alert('Fifth vesting cycle should not be 0 percent');
                        document.getElementById('<%=txtperc5.ClientID%>').focus();
                        isValid = false;
                        return false;

                    }


                    if ((parseInt(percent1) + parseInt(percent2) + parseInt(percent3) + parseInt(percent4) + parseInt(percent5)) != 100) {

                        alert('Total of vesting cycle should be 100 percent');
                        isValid = false;
                    }
                }
                //else {
                //    return true;
                //}
            }

    return isValid;
}

    </script>
    <script type="text/javascript">
        $(document).ready(function () {
            debugger;
            dropchange();
        });

        function dropchange() {
            debugger;
            //var id = ddl.id;
            //var value = $("#ddlnoOfCycle1").val();
            //alert(value);

            var ddlFruits = document.getElementById("<%=ddlnoOfCycle1.ClientID %>");
            //var selectedText = ddlFruits.options[ddlFruits.selectedIndex].innerHTML;
            var selectedVal = ddlFruits.value;
            //alert(selectedVal);


            // var selectedVal = ddl.value;
            // alert(selectedVal);
            if (selectedVal == "1") {
                $("#trV1").show();
                $("#trV2").hide();
                $("#trV3").hide();
                $("#trV4").hide();
                $("#trV5").hide();

            }

            else if (selectedVal == "2") {
                $("#trV1").show();
                $("#trV2").show();
                $("#trV3").hide();
                $("#trV4").hide();
                $("#trV5").hide();

            }
            else if (selectedVal == "3") {
                $("#trV1").show();
                $("#trV2").show();
                $("#trV3").show();
                $("#trV4").hide();
                $("#trV5").hide();



            }
            else if (selectedVal == "4") {
                $("#trV1").show();
                $("#trV2").show();
                $("#trV3").show();
                $("#trV4").show();
                $("#trV5").hide();


            }
            else if (selectedVal == "5") {
                $("#trV1").show();
                $("#trV2").show();
                $("#trV3").show();
                $("#trV4").show();
                $("#trV5").show();
            }
            else {
                $("#trV1").hide();
                $("#trV2").hide();
                $("#trV3").hide();
                $("#trV4").hide();
                $("#trV5").hide();
            }
        }
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
</asp:Content>
