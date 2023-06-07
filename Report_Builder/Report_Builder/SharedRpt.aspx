<%@ Page Title="" Language="C#" MasterPageFile="~/Report.Master" AutoEventWireup="true" CodeBehind="SharedRpt.aspx.cs" Inherits="Report_Builder.SharedRpt" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <%--<script src="http://ajax.googleapis.com/ajax/libs/jquery/1.9.0/jquery.min.js"></script>--%>
    <script src="js/jquery-1.9.0.min.js"></script>
    <script src="js/jquery.sumoselect.min.js"></script>
    <link href="Styles/sumoselect.css" rel="stylesheet" />
    <%--<link href="sumoselect.css" rel="stylesheet" />--%>
    <style>
        .SumoSelect .select-all {
            border-radius: 3px 3px 0 0;
            position: relative;
            border-bottom: 1px solid #ddd;
            background-color: #fff;
            padding: 8px 0 3px 35px;
            height: 41px;
            cursor: pointer;
        }

        .rightline {
            height: 493px;
        }

            .rightline:after {
                content: "";
                display: block;
                width: 1px;
                height: 100%;
                background: #ccc;
                position: absolute;
                right: 0;
                bottom: 12px;
            }

        .form-control1 {
            font-size: 12px;
            font-weight: 400;
            width: 100%;
            border: 1px solid #ccc;
            padding: 6px 12px;
            box-shadow: none;
        }

        .mt-60 {
            margin-top: 60px;
        }

        .bx-shd {
            box-shadow: none;
        }

        .ml_pnl {
            margin-left: 55px;
        }





        @media (max-width:360px) {

            .ml_pnl {
                margin-left: -15px;
            }

            .ml_sr_p {
                margin-left: 3px !important;
            }

                        body {
                overflow-y:hidden !important; 
            }
        }


        @media (max-width:640px) {

            .ml_pnl {
                margin-left: -15px;  margin-top: 113px;
            }

            body {
                overflow-y:auto !important; 
            }


            .ml_sr_p {
                margin-left: 85px;
            }
        }

        @media (max-width:1366px) {
            .ml_sr_p {
                margin-left: 85px;
            }
        }
    </style>
    <style>
        .SumoSelect {
            /*width: 100% !important;*/
        }

            .SumoSelect > .CaptionCont > span.placeholder {
                color: #ccc;
                font-style: italic;
                width: 100%;
                border: 0;
            }

            .SumoSelect > .CaptionCont > span {
                border-radius: 3px 3px 0 0;
                position: relative;
                border-bottom: 1px solid #ddd;
                background-color: #fff;
                margin-top: -7px;
                padding: 0px 0 3px 0px;
                height: 40px;
                cursor: pointer;
                font: 500 14px "Montserrat", sans-serif;
                border: 0px solid #eee;
                background-color: rgba(255, 255, 255, 0);
            }

            .form-controlddl, .SumoSelect > .CaptionCont {
                display: block;
                /*width: 100%;*/
                font: 500 12px "Montserrat", sans-serif;
                height: 40px;
                padding: 6px 12px;
                font-size: 12px;
                line-height: 1.42857143;
                color: #555;
                background-color: #fff;
                background-image: none;
                border: 1px solid #eee;
                border-radius: 4px;
                -webkit-box-shadow: inset 0 1px 1px rgba(0,0,0,.075);
                box-shadow: inset 0 1px 1px rgba(0,0,0,.075);
                -webkit-transition: border-color ease-in-out .15s,box-shadow ease-in-out .15s;
                -o-transition: border-color ease-in-out .15s,box-shadow ease-in-out .15s;
                -webkit-transition: border-color ease-in-out .15s,-webkit-box-shadow ease-in-out .15s;
                transition: border-color ease-in-out .15s,-webkit-box-shadow ease-in-out .15s;
                transition: border-color ease-in-out .15s,box-shadow ease-in-out .15s;
                transition: border-color ease-in-out .15s,box-shadow ease-in-out .15s,-webkit-box-shadow ease-in-out .15s;
            }

            .SumoSelect .select-all {
                border-radius: 3px 3px 0 0;
                position: relative;
                border-bottom: 1px solid #ddd;
                background-color: #fff;
                padding: 8px 0 3px 35px;
                height: 41px;
                cursor: pointer;
            }
    </style>
    <style type="text/css">
        .hideGridColumn {
            display: none;
        }

        body {
            overflow-y: hidden;
        }


        @media (min-width:360px) {

            .sh_all_btn {
                margin-top:10px;
              
            }

            
        }


        @media (min-width:1366px) {

            .sh_all_btn {
                margin-top:0px;
              
            }

        }




    </style>
    <section>
        <div class="text-center panel_hdr">
            Shared Reports
        </div>
        <div class="container">
            <div class="mt-5 mb-5 bx-shd">
                <div class="viewbtn pl-4" style="top: -3px; opacity: 1; right: 0;">
                    <ul class="list-unstyled list-inline mt-60 ml_pnl">
                        <asp:Button ID="btnAddShareRecord" Text="Share New Report" runat="server" OnClick="btnAddShareRecord_Click" class="btn btn-set" />
                    </ul>
                </div>
                <br />
                <div class="col-md-12">
                    <div class="row">
                        <div class="col-md-3 text-right p-2">
                            <label>View Shared Reports by :</label>
                        </div>
                        <div class="col-md-3">
                            <asp:DropDownList ID="lstFilterBy1" runat="server" TabIndex="3" CssClass="form-control bdr_ddl" Style="width: 100% !important; resize: none"
                                OnSelectedIndexChanged="lstFilterBy_SelectedIndexChanged" AutoPostBack="true">
                                <asp:ListItem Text="--Select--" Value="0"></asp:ListItem>
                                <asp:ListItem Text="Users" Value="1"></asp:ListItem>
                                <asp:ListItem Text="Report Names" Value="2"></asp:ListItem>
                            </asp:DropDownList>
                        </div>

                        <div class="col-md-3">
                            <%--<asp:ListBox runat="server" ID="lstBoxFilter" SelectionMode="Multiple"></asp:ListBox>--%>
                            <asp:ListBox ID="lstBoxFilter" runat="server" CssClass="listboxDiv form-controlddl" SelectionMode="Multiple"></asp:ListBox>
                        </div>

                        <div class="col-md-3 sh_all_btn">
                            <asp:Button ID="btnFilter" Text="Show" runat="server" CssClass="btn btn-set" OnClick="btnFilter_Click" />
                            <asp:Button ID="btnShowAll" Text="Show All" runat="server" CssClass="btn btn-set" OnClick="btnShowAll_Click" />
                        </div>

                    </div>
                    <br />
                    <div class="text-center mt-3">
                        <%--<asp:Button ID="btnFilter" Text="Show" runat="server" CssClass="btn btn-set" OnClick="btnFilter_Click" />
                        <asp:Button ID="btnShowAll" Text="Show All" runat="server" CssClass="btn btn-set" OnClick="btnShowAll_Click" />--%>
                    </div>
                </div>
                <div class="modal-body table-responsive" style="height: 250px; overflow: auto;">
                    <asp:GridView ID="Grid_ShowReport" CssClass="table tbl_bdr" runat="server" AutoGenerateColumns="False" OnRowDataBound="Grid_ShowReport_RowDataBound" AllowPaging="True" EmptyDataText="No data found" HeaderStyle-CssClass="bg_tbl_hd" Width="100%" OnPreRender="Grid_ShowReport_PreRender">
                        <Columns>
                            <asp:TemplateField HeaderText="rs_id" HeaderStyle-CssClass="hideGridColumn" ItemStyle-CssClass="hideGridColumn bg_tbl_bdy">
                                <ItemTemplate>
                                    <asp:Label ID="lblrsid" runat="server" Text='<%# Eval("rs_id") %>' Style="display: none"></asp:Label></b>  
                                </ItemTemplate>
                            </asp:TemplateField>

                            <asp:TemplateField HeaderText="RS_SHARE_ID" HeaderStyle-CssClass="hideGridColumn" ItemStyle-CssClass="hideGridColumn bg_tbl_bdy">
                                <ItemTemplate>
                                    <asp:Label ID="lblRS_SHARE_ID" runat="server" Text='<%# Eval("RS_SHARE_ID") %>' Style="display: none"></asp:Label></b>  
                                </ItemTemplate>
                            </asp:TemplateField>

                            <asp:BoundField DataField="Srno" HeaderText="Sr. No." HeaderStyle-CssClass="text-nowrap" HeaderStyle-Font-Bold="true">
                                <HeaderStyle CssClass="text-nowrap" Font-Bold="True"></HeaderStyle>
                                <ItemStyle HorizontalAlign="Left" VerticalAlign="Top" Wrap="True" CssClass="bg_tbl_bdy" />
                            </asp:BoundField>

                            <%--<asp:TemplateField HeaderText="Id" ItemStyle-Width="30">
                                <ItemTemplate>
                                    <%# Container.DataItemIndex + 1 %>
                                </ItemTemplate>
                            </asp:TemplateField>--%>

                            <asp:BoundField DataField="RS_EMP_CODE" HeaderText="Employee Code" HeaderStyle-CssClass="text-nowrap" HeaderStyle-Font-Bold="true">
                                <HeaderStyle CssClass="text-nowrap" Font-Bold="True"></HeaderStyle>
                                <ItemStyle HorizontalAlign="Left" VerticalAlign="Top" Wrap="True" CssClass="bg_tbl_bdy" />
                            </asp:BoundField>

                            <asp:BoundField DataField="emp_name" HeaderText="Employee Name" ItemStyle-Wrap="true" HeaderStyle-CssClass="text-nowrap" HeaderStyle-Font-Bold="true">
                                <ItemStyle HorizontalAlign="Left" VerticalAlign="Top" Wrap="True" CssClass="bg_tbl_bdy" />
                            </asp:BoundField>

                            <asp:BoundField DataField="report_name" HeaderText="Report Name" HeaderStyle-CssClass="text-nowrap" HeaderStyle-Font-Bold="true">
                                <HeaderStyle CssClass="text-nowrap" Font-Bold="True"></HeaderStyle>
                                <ItemStyle HorizontalAlign="Left" VerticalAlign="Top" Wrap="True" CssClass="bg_tbl_bdy" />
                            </asp:BoundField>
                            <asp:TemplateField HeaderText="Action" HeaderStyle-Font-Bold="true" ItemStyle-CssClass="bg_tbl_bdy">
                                <ItemTemplate>
                                    <asp:CheckBox ID="chkbAction" runat="server" AutoPostBack="true" OnCheckedChanged="chkbAction_CheckedChanged" />
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                    </asp:GridView>
                </div>
                <%-- Bhushan Start --%>
                <div class="modal" id="myModal">
                    <div class="modal-dialog modal-lg">
                        <div class="modal-content" style="background: #fff !important">
                            <!-- Modal Header -->
                            <div class="modal-header text-center">
                                <h4 class="modal-title" style="font-size: 16px; line-height: 28px; margin-bottom: 15px; display: block; width: 100%; font-weight: bold;">Share Report With</h4>
                                <button type="button" class="close" data-dismiss="modal">&times;</button>
                            </div>
                            <!-- Modal body -->
                            <div class="modal-body">
                                <div class="col-md-12 ml_sr_p">
                                    <div class="col-md-2"></div>
                                    <div class="col-md-8">
                                        <div class="form-group m-4">
                                            <label class="text-right pr-2" style="width: 175px; float: left; padding-top: 7px;">Report Name:</label>
                                            <asp:ListBox ID="ListBx_Rpt" runat="server" CssClass="listboxDiv form-control pt-2 bdr_ddl"></asp:ListBox>
                                        </div>
                                        <div class="form-group m-4">
                                            <label class="text-right pr-2" style="width: 175px; float: left; padding-top: 7px;">Share With:</label>
                                            <asp:ListBox ID="ListBx_emp" runat="server" CssClass="listboxDiv form-control bdr_ddl" SelectionMode="Multiple" TabIndex="1"></asp:ListBox>
                                        </div>
                                    </div>
                                    <div class="col-md-2"></div>
                                </div>
                            </div>
                            <!-- Modal footer -->
                            <div class="modal-footer" style="justify-content: center;">
                                <asp:Button ID="btnSave" runat="server" Text="Save" OnClick="btnSave_Click" CssClass="btn btn-set" ValidationGroup="AddG3" TabIndex="6" />
                                <button type="button" class="btn btn-set" data-dismiss="modal">Close</button>
                            </div>
                        </div>
                    </div>
                </div>
                <%-- Bhushan End --%>
            </div>
        </div>
    </section>
    <script type="text/javascript">
        $(document).ready(function () {
            $(<%=ListBx_emp.ClientID%>).SumoSelect({ search: true, searchText: 'Select User.' });
            $(<%=ListBx_Rpt.ClientID%>).SumoSelect({ search: true, searchText: 'Select Role Name.' });
            $(<%=lstBoxFilter.ClientID%>).SumoSelect({ search: true, searchText: '--Select--' });
        });
    </script>
    <%--<script src="jquery.sumoselect.min.js"></script>--%>

    <%--<script type="text/javascript">
        function callJsForSumoSel() {
            $('.listboxDiv').SumoSelect({ search: true, searchText: 'Enter here.' });
        }
    </script>--%>

    <script src="js/jquery-3.5.1.min.js"></script>
    <script src="js/bootstrap-4.5.0.min.js"></script>

    <%--<script type="text/javascript" src="js/jquery-1.8.3.min.js"></script>--%>
    <script type="text/javascript" src="js/jquery.dataTables-1.10.20.min.js"></script>
    <link href="Styles/jquery.dataTables-1.10.20.css" rel="stylesheet" type="text/css" />

    <script type="text/javascript">
        var prm = Sys.WebForms.PageRequestManager.getInstance();
        prm.add_endRequest(function (sender, e) {
            $("#ContentPlaceHolder1_Grid_ShowReport").DataTable({
                lengthMenu: [[15, 30, 50, 100, 200, -1], [15, 30, 50, 100, 200, "All"]],
                columnDefs: [{ orderable: false, targets: [4, 5, 6] }],
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
                columnDefs: [{ orderable: false, targets: [4, 5, 6] }],
                bLengthChange: true,
                lengthMenu: [[15, 30, 50, 100, 200, -1], [15, 30, 50, 100, 200, "All"]],
                bFilter: true,
                bSort: true,
                bPaginate: true
            });
        });
    </script>

    <script type="text/javascript">
        function openModal() {
            $('#myModal').modal('show');
        }
    </script>
</asp:Content>
