<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="LetterList_TypeCommon.aspx.cs" Inherits="ESOP.LetterList_TypeCommon" MasterPageFile="~/ESOP.Master" EnableEventValidation="false" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ScriptManager ID="script" runat="server"></asp:ScriptManager>

    <style>
        .aligncenter {
            text-align: center;
            display: block !important;
        }

        .card {
            height: 100%;
        }

        .table th {
            padding: .4rem;
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
        }

        .table td {
            font-weight: 500;
            color: #3f646d;
            font-size: 14px;
            background: #bcc0c32e;
        }

        .card .card-header {
            background-color: transparent;
            padding: 11px 40px !important;
        }

        .main-footer {
            margin-top: 32px !important;
        }

        .btn-group {
            /*height: 25px;*/
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

        .btn-success, .btn-success.disabled {
            box-shadow: 0 2px 6px #abf2d7;
            background-color: #5a9d44;
            border-color: #5a9d44;
            color: #fff;
        }

        
        .section > :first-child {
            margin-top: 16px !important;
        }

        .offset-md-9 {
            margin-left: 88%;
            margin-top: 35px;
        }

        .nav .nav-item .nav-link .fas, .nav .nav-item .nav-link .ion {
            font-size: 16px;
        }

        .theme-white .nav-pills .nav-link.active {
            color: white;
            background-color: #2600ff;
            font-size: 15px;
            border-bottom: none;
        }

        .nav-pills .nav-item .nav-link {
            padding: 5px;
            color: #0893c2;
            padding-left: 8px !important;
            padding-right: 8px !important;
            font-size: 16px;
            background: #8080801f;
            margin-left: 5px;
            border-radius: 5px;
            box-shadow: 0px 3px 2px 0px #00000066;
            font-weight: 600;
        }

        .letterview {
            background-color: #ffffff;
            text-align: center;
            border: 0px solid #eee;
            -moz-box-shadow: 0 0 15px rgba(0, 0, 0, 0.188235);
            -webkit-box-shadow: 0 0 15px rgba(0, 0, 0, 0.188235);
            box-shadow: 2px 2px 15px rgb(0 0 0 / 43%);
            -moz-border-radius: 6px;
            -webkit-border-radius: 6px;
            border-radius: 6px;
            margin-bottom: 15px;
        }

        figure.snip0013 {
            position: relative;
            overflow: hidden;
            /* margin: 10px; */
            width: 100%;
            padding: 10px 10px 0px;
            background: #fff;
            text-align: center;
            border-radius: 8px;
        }

            figure.snip0013 img {
                max-width: 100%;
                opacity: 1;
                -webkit-transition: opacity 0.35s;
                transition: opacity 0.35s;
            }

            figure.snip0013 > div {
                left: 0;
                right: 0;
                top: 0;
                bottom: 0;
                height: 100%;
                position: absolute;
            }

                figure.snip0013 > div::before {
                    position: absolute;
                    top: 30px;
                    right: 50%;
                    bottom: 30px;
                    left: 50%;
                    border-left: 1px solid rgba(255, 255, 255, 0.8);
                    border-right: 1px solid rgba(255, 255, 255, 0.8);
                    content: '';
                    opacity: 0;
                    background-color: #ffffff;
                    -webkit-transition: all 0.4s;
                    transition: all 0.4s;
                    -webkit-transition-delay: 0.3s;
                    transition-delay: 0.3s;
                }

                figure.snip0013 > div a {
                    color: #ffffff;
                }

                    figure.snip0013 > div a i.right-icon {
                        transform: translate3d(0, -50%, 0);
                    }

                    figure.snip0013 > div a i {
                        font-size: 14px;
                        opacity: 0;
                        top: 50%;
                        position: relative;
                        transition-delay: 0s;
                        display: inline-block;
                    }

        .letterview p {
            margin: 3px 0 0;
            font-size: 10px;
            font-weight: 500;
            letter-spacing: 0.3px;
            color: dimgray;
            text-align: left;
        }

        .form-group > label {
            font-size: 15px;
        }

        .letterview p i {
            font-size: 12px;
            vertical-align: middle;
            margin-right: 3px;
            color: #ffffff;
            background: #078ca9;
            padding: 6px 6px;
            border-radius: 5px 0 0 0;
            position: absolute;
            bottom: -1px;
            right: -3px;
        }

        figure.snip0013:hover {
            background: #1fa2c02b !important;
        }

        li.nav-item {
            width: 92px;
            text-align: center;
        }

        .offset-md-8 {
            margin-left: 72.666667%;
        }

        .edit12 {
            padding: 10px;
            background: green;
            color: white !important;
            border-radius: 4px;
            line-height: 0;
        }

        .download1 {
            padding: 10px;
            background: #2600ff;
            color: white !important;
            border-radius: 4px;
            line-height: 0;
        }

        .letterview {
            width: 157px;
        }

        .letterlist td {
            padding: 9px;
        }

            .letterlist td a {
                margin: 3px 0 0;
                font-size: 10px;
                letter-spacing: 0.3px;
                color: dimgray;
                text-align: left;
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

        #LetterList .dataTables_scrollHeadInner, .dataTables_scrollBody table {
            width: 100% !important;
        }
    </style>

    <script src="assets/js/jquery-1.8.3.min.js"></script>
    <script src="assets/js/jquery.dataTables-1.10.20.min.js"></script>
    <link href="Scripts/jquery.dataTables.min.css" rel="stylesheet" />
    <link href="Scripts/dataTables.bootstrap4.min.css" rel="stylesheet" />

    <script type="text/javascript">
        $(document).ready(function () {

            $('.CloseBtnNew').click(function () {

                $("#myModal1").removeClass("show");
                $("#myModal1").hide();

                $("#myModal").removeClass("show");
                $("#myModal").hide();

                $("#myModal2").removeClass("show");
                $("#myModal2").hide();

                $(".modal-backdrop").remove();
                //$("#myModal").hide();
                $("body").removeClass("modal-open");
                // $("#myModal1").modal("hide");
            });
        });
    </script>


    <script>
        function DownloadFile(filepath) {
            __doPostBack("<%= BtnDownload.UniqueID %>", filepath);
        }
   
        function PreviewFile(filepath) {
            __doPostBack("<%= BtnPreview.UniqueID %>", filepath);
          }
    </script>

    <script type="text/javascript">
        var prm = Sys.WebForms.PageRequestManager.getInstance();
        prm.add_endRequest(function (sender, e) {
            var table = $('#ContentPlaceHolder1_GrvLetter_List').DataTable({
                lengthMenu: [[-1, 5, 10], ["All", 5, 10]],
                columnDefs: [{ orderable: false, targets: [7] }],
                bStateSave: true,
                bPaginate: true,
                bSort: true,
                bFilter: true,
                bRetrieve: true, fixedHeader: true, "scrollX": true

            });
            //            table
            //.search('')
            //.columns().search('')
            //.draw();
        });

        $(function () {
            $.noConflict();
            var table = $('#ContentPlaceHolder1_GrvLetter_List').DataTable({
                bLengthChange: true,
                lengthMenu: [[-1, 5, 10], ["All", 5, 10]],
                bFilter: true,
                order: [],
                columnDefs: [{ orderable: false, targets: [7] }],
                bPaginate: true,
                bSort: true, bRetrieve: true,
                bStateSave: true, fixedHeader: true, "scrollX": true,
                //"fnStateSave": function (oSettings, oData) {
                //    localStorage.setItem('offersDataTables', JSON.stringify(oData));
                //},
                //"fnStateLoad": function (oSettings) {
                //    return JSON.parse(localStorage.getItem('offersDataTables'));
                //}
            });
            table
.search('')
.columns().search('')
.draw();
        });
    </script>

    <div id="app">
        <div class="main-wrapper main-wrapper-1">
            <div class="navbar-bg"></div>
            <nav class="navbar navbar-expand-lg main-navbar">
                <ul class="navbar-nav navbar-right">
                </ul>
            </nav>

            <!-- Main Content -->
            <div class="main-content">
                <nav aria-label="breadcrumb">
                    <ol class="breadcrumb">
                        <li class="breadcrumb-item"><a href="employee-dashboard.aspx">Home</a></li>
                        <li class="breadcrumb-item active" aria-current="page">Letters</li>
                    </ol>
                </nav>
                <section class="section">
                    <div class="row">
                        <div class="col-12">
                            <div class="card">
                                <div class="card-header">
                                    <h4>Letter Summary</h4>
                                    <ul class="nav nav-pills" id="myTab4" role="tablist">
                                        <li class="nav-item" style="width: auto;">
                                            <asp:Button ID="btnExportToExcel" runat="server" Text="Export to Excel" OnClick="btnExportToExcel_Click" OnClientClick="return validate(); showProgress1(); return false;return postbackButtonClick();" CssClass="btn btn-info btn-lg all" />
                                        </li>
                                    </ul>
                                    <ul class="nav nav-pills offset-md-7" id="myTab4" role="tablist">
                                        <li class="nav-item" style="width: auto;">
                                            <a style="padding: 1px; padding-left: 8px!important; padding-right: 8px!important; margin-left: 5px; border-radius: 5px; box-shadow: none; font-weight: 600;" class="nav-link active" id="home-tab4" data-toggle="tab" href="#home4" role="tab"
                                                aria-controls="home" aria-selected="true"><i class="fas fa-list-ul"></i></a>
                                        </li>
                                        <li class="nav-item" style="width: auto;">
                                            <a style="padding: 1px; padding-left: 8px!important; padding-right: 8px!important; margin-left: 5px; border-radius: 5px; box-shadow: none; font-weight: 600;" class="nav-link" id="profile-tab4" data-toggle="tab" href="#profile4" role="tab"
                                                aria-controls="profile" aria-selected="false"><i class="fas fa-image"></i></a>
                                        </li>
                                    </ul>
                                </div>
                                <div class="card-body">
                                    <div class="tab-content" id="myTabContent">
                                        <div class="tab-pane fade show active" id="home4" role="tabpanel" aria-labelledby="home-tab4">
                                            <div class="table-responsive" style="margin-bottom: 0; padding-top: 15px;" id="LetterList" role="tab">
                                                <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                                                    <ContentTemplate>
                                                        <asp:GridView ID="GrvLetter_List" runat="server" AutoGenerateColumns="False"
                                                            class="table table-bordered" EmptyDataText="No Records Found"
                                                             ShowHeaderWhenEmpty="false" OnPreRender="GrvLetter_List_PreRender">
                                                            <Columns>
                                                                <asp:BoundField DataField="SrNO" HeaderText="Sr No." ItemStyle-Width="50" ItemStyle-Wrap="false" />
                                                                <asp:BoundField DataField="EMP_NAME" HeaderText="Employee Name" />
                                                                <asp:BoundField DataField="GRANT_NAME" HeaderText="Grant Name" />
                                                                <asp:BoundField DataField="LetterName" HeaderText="Type" />
                                                                <asp:BoundField DataField="GRANT_DATE" HeaderText="Grant / Sale Date" ItemStyle-Wrap="false"/>
                                                                <asp:BoundField DataField="CREATEDDATE" HeaderText="Date" ItemStyle-Wrap="false"/>
                                                                <asp:BoundField DataField="ACKNOWLEGDED_DATE" HeaderText="Acknowlegement Date" ItemStyle-Wrap="false"/>
                                                                <asp:TemplateField HeaderText="Action" ItemStyle-Width="100" ItemStyle-Wrap="false">
                                                                    <ItemTemplate>                                                                    
                                                                        <span>
                                                                            <asp:HiddenField ID="HiddenField1" runat="server" Value='<%# Bind("FILENAME") %>' />
                                                                            <asp:LinkButton ID="btn_Preview" runat="server" CausesValidation="false" CommandName="Preview" OnClick="btn_Preview_Click" CommandArgument='<%# Eval("FILENAME") %>'
                                                                                CssClass="btn btn-icon btn-success fas fa-eye"></asp:LinkButton>
                                                                        </span>
                                                                            <asp:LinkButton ID="lb_download" runat="server" CommandName="download" OnClick="lb_download_Click" CommandArgument='<%# Eval("FILENAME") %>' CausesValidation="false"
                                                                            class="btn btn-icon btn-primary fas fa-arrow-down"></asp:LinkButton>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                            </Columns>
                                                        </asp:GridView>
                                                    </ContentTemplate>
                                                    <%--     <Triggers>
                                                        <asp:AsyncPostBackTrigger ControlID="GrvLetter_List" />
                                                    </Triggers>--%>
                                                </asp:UpdatePanel>
                                            </div>
                                            <asp:button id="BtnDownload" onclick="DownloadFile_Click" runat="server" visible="false" xmlns:asp="#unknown" />
                                            <asp:button id="BtnPreview" onclick="PreviewFile_Click" runat="server" visible="false" xmlns:asp="#unknown" />
                                        </div>
                                        <div class="tab-pane fade" id="profile4" role="tabpanel" aria-labelledby="profile-tab4">
                                            <div>
                                                <ul class="offset-md-4 nav nav-pills" id="myTab3" role="tablist">
                                                    <li class="nav-item">
                                                        <a class="nav-link active" id="home-tab3" data-toggle="tab" href="#home3" role="tab" aria-controls="home" aria-selected="true">All</a>
                                                    </li>
                                                    <li class="nav-item">
                                                        <a class="nav-link" id="profile-tab3" data-toggle="tab" href="#profile3" role="tab" aria-controls="profile" aria-selected="false">Grant</a>
                                                    </li>
                                                    <li class="nav-item">
                                                        <a class="nav-link" id="sale-tab3" data-toggle="tab" href="#sale3" role="tab" aria-controls="sale" aria-selected="false">Sales</a>
                                                    </li>
                                                </ul>
                                                <div class="tab-content mt-3" id="myTabContent2">
                                                    <div class="tab-pane fade active show" id="home3" role="tabpanel" aria-labelledby="home-tab3">
                                                        <div class="row">
                                                            <div class="col-sm-12 filter hdpe" style="height: 318px; overflow: auto;">
                                                                <asp:UpdatePanel ID="Updatepanel1" runat="server">
                                                                    <ContentTemplate>
                                                                        <div>
                                                                            <asp:DataList Width="" CssClass="letterlist" align="center" CellSpacing="0" runat="server" ID="dlLetterList" RepeatColumns="6" GridLines="None" RepeatDirection="Horizontal">
                                                                                <ItemTemplate>

                                                                                    <div class="letterview">
                                                                                        <center>
                                                                              
                                                                      <figure class="snip0013">
                                                                        <img src="assets/img/Capture.png" width="130" />
                                                                           <asp:LinkButton ID="lnkAllDoc" runat="server" Text='<%#Eval("FName") %>' OnClick="lnkAllDoc_Click"  CommandArgument='<%# Eval("FILENAME") %>' class="fas fa-download">                                                               
                                                                              </asp:LinkButton>
                                                                        </figure>
                                                                        
                                                                              </center>
                                                                                    </div>
                                                                                </ItemTemplate>
                                                                            </asp:DataList>
                                                                        </div>
                                                                    </ContentTemplate>
                                                                <%--    <Triggers>
                                                                        <asp:PostBackTrigger ControlID="dlLetterList" />
                                                                    </Triggers>--%>
                                                                </asp:UpdatePanel>

                                                            </div>

                                                        </div>
                                                    </div>
                                                    <div class="tab-pane fade" id="profile3" role="tabpanel" aria-labelledby="profile-tab3">
                                                        <div class="row">
                                                            <div class="col-sm-12 filter hdpe" style="height: 318px; overflow: auto;">
                                                                <asp:UpdatePanel ID="Updatepanel3" runat="server">
                                                                    <ContentTemplate>
                                                                        <div>
                                                                            <asp:DataList Width="" CssClass="letterlist" align="center" CellSpacing="0" runat="server"
                                                                                ID="dlGrantDoc" RepeatColumns="6" GridLines="None" RepeatDirection="Horizontal">
                                                                                <ItemTemplate>
                                                                                    <div class="letterview">
                                                                                        <center>                                                                              
                                                                      <figure class="snip0013">
                                                                        <img src="assets/img/Capture.png" width="130" />
                                                                           <asp:LinkButton ID="lnkGrantDOC" runat="server" Text='<%#Eval("FName") %>' OnClick="lnkGrantDOC_Click"  CommandArgument='<%# Eval("FILENAME") %>' class="fas fa-download">                                                               
                                                                              </asp:LinkButton>
                                                                        </figure>                                                                        
                                                                              </center>
                                                                                    </div>
                                                                                </ItemTemplate>
                                                                            </asp:DataList>
                                                                        </div>
                                                                    </ContentTemplate>
                                                                  <%--  <Triggers>
                                                                        <asp:PostBackTrigger ControlID="dlGrantDoc" />
                                                                    </Triggers>--%>
                                                                </asp:UpdatePanel>

                                                            </div>

                                                        </div>
                                                    </div>
                                                    <div class="tab-pane fade" id="sale3" role="tabpanel" aria-labelledby="sale-tab3">
                                                        <div class="tab-pane fade active show" id="home3" role="tabpanel" aria-labelledby="home-tab3">
                                                            <div class="row">
                                                                <div class="col-sm-12 filter hdpe" style="height: 318px; overflow: auto;">
                                                                    <asp:UpdatePanel ID="Updatepanel4" runat="server">
                                                                        <ContentTemplate>
                                                                            <div>
                                                                                <asp:DataList Width="" CssClass="letterlist" align="center" CellSpacing="0" runat="server" ID="dlSales"
                                                                                    RepeatColumns="6" GridLines="None" RepeatDirection="Horizontal">
                                                                                    <ItemTemplate>

                                                                                        <div class="letterview">
                                                                                            <center>
                                                                              
                                                                      <figure class="snip0013">
                                                                        <img src="assets/img/Capture.png" width="130" />
                                                                           <asp:LinkButton ID="lnkSales" runat="server" Text='<%#Eval("FName") %>' OnClick="lnkSales_Click"  CommandArgument='<%# Eval("FILENAME") %>' class="fas fa-download">                                                               
                                                                              </asp:LinkButton>
                                                                        </figure>
                                                                        
                                                                              </center>
                                                                                        </div>
                                                                                    </ItemTemplate>
                                                                                </asp:DataList>
                                                                            </div>
                                                                        </ContentTemplate>
                                                                     <%--   <Triggers>
                                                                            <asp:PostBackTrigger ControlID="dlSales" />
                                                                        </Triggers>--%>
                                                                    </asp:UpdatePanel>

                                                                </div>
                                                            </div>
                                                        </div>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                    </div>

                                </div>
                            </div>
                        </div>
                    </div>
                </section>
            </div>
        </div>
    </div>

    <div class="modal fade bd-example-modal-lg1" id="myModal1" tabindex="-1" role="dialog" aria-labelledby="myLargeModalLabel" style="display: none;" aria-hidden="true">
        <div class="modal-dialog modal-lg" style="max-width: 900px;">
            <asp:UpdatePanel runat="server">
                <ContentTemplate>
                    <div class="modal-content">
                        <div class="modal-header">
                            <h5 class="modal-title" id="myLargeModalLabel">Preview </h5>
                            <%--   <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                                <span aria-hidden="true">×</span>
                            </button>--%>
                        </div>
                        <div class="modal-body" style="padding-left: 15px; padding-right: 15px;">
                            <div class="row popRow" style="">
                                <embed runat="server" id="embed1" width="100%" height="500" alt="pdf" pluginspage="http://www.adobe.com/products/acrobat/readstep2.html" />
                            </div>
                        </div>
                        <div class="modal-footer bg-whitesmoke br">
                            <div class="btn-group" role="group" aria-label="Basic example">
                                <%--<button type="button" class="btn btn-primary" data-dismiss="modal" style="margin-right: 44%; width: 40px;" id="Submit">OK</button>--%>
                                <a href="#" class="btn btn-info btn-lg all CloseBtnNew" data-dismiss="modal">Close</a>

                            </div>
                        </div>
                    </div>
                </ContentTemplate>
            </asp:UpdatePanel>
        </div>
    </div>

    <div class="modal bd-example-modal-lg" id="myModal2" tabindex="-1" role="dialog">
        <%--<div class="modal fade bd-example-modal-lg1" id="myModal1" tabindex="-1" role="dialog" aria-labelledby="myLargeModalLabel" style="display: none;" aria-hidden="true">--%>
        <div class="modal-dialog modal-lg" style="max-width: 900px;">

            <div class="modal-content">
                <asp:UpdatePanel runat="server">
                    <ContentTemplate>
                        <div class="modal-header">
                            <h5 class="modal-title" id="myLargeModalLabel1">Preview </h5>
                        </div>
                        <div class="modal-body" style="padding-left: 15px; padding-right: 15px;">
                            <div class="row popRow aligncenter">
                                <img id="FreshChequeImage1" runat="server" />
                            </div>
                        </div>
                    </ContentTemplate>
                </asp:UpdatePanel>
                <div class="modal-footer bg-whitesmoke br">
                    <div class="btn-group" role="group" aria-label="Basic example">
                        <%--<button id="btn1" class="btn btn-info btn-lg all CloseBtnNew">Close</button>--%>
                        <a href="#" class="btn btn-info btn-lg all CloseBtnNew" data-dismiss="modal">Close</a>

                    </div>
                </div>
            </div>
        </div>
    </div>

    <%--<script src="Scripts/bootstrap.min.js"></script>--%>
    <script src="assets/js/app.min.js"></script>
    <script src="assets/js/scripts.js"></script>


    <script type="text/javascript">
        function openModal(srcval) {
            debugger;
            document.getElementById('<%=embed1.ClientID%>').src = "";
            document.getElementById('<%=embed1.ClientID%>').src = srcval;
            $('#myModal1').modal('show');
        }
    </script>

    <script type="text/javascript">
        function openModal1() {
            debugger;
            $('#myModal2').modal('show');
        }
    </script>

    

</asp:Content>
