<%@ Page Title="" Language="C#" MasterPageFile="~/ESOP.Master" AutoEventWireup="true" CodeBehind="Email_Notification.aspx.cs" Inherits="ESOP.Email_Notification" ValidateRequest="false" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajax" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ScriptManager ID="script" runat="server"></asp:ScriptManager>

    <%-- <script type="text/javascript" src="tiny_mce/tiny_mce.js"></script>--%>
    <%--   <script type="text/javascript" language="javascript">
        tinyMCE.init({
            // General options
            mode: "textareas",
            theme: "advanced",
            plugins: "pagebreak,style,layer,table,save,advhr,advimage,advlink,emotions,iespell,inlinepopups",

        });
    </script>--%>

    <style>
        .card {
            height: auto !important;
        }

        h4 {
            font-weight: 600;
            font-size: 16px;
            color: #2b76ff;
        }

        .chosen-container {
            width: 100% !important;
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

    <script src="tiny_mce/tinymce.min.js" type="text/javascript"></script>
    <script>
        tinymce.init({
            selector: 'textarea',
            plugins: [
    'advlist autolink lists charmap pagebreak',
    'searchreplace visualblocks',
    'table'
            ],
            toolbar: 'undo redo cut copy paste| insert | styleselect | bold italic | alignleft aligncenter alignright alignjustify | bullist numlist outdent indent | code',
            branding: false
        });
    </script>

    <script type="text/javascript">
        function GetRevName(source, eventArgs) {
            debugger;
            var s = source.get_id();
            //  alert(s);
            var ss = s.split("_");
            var UpdateTextBox = ss[0] + '_txtCC';
            var text = document.getElementById(UpdateTextBox)
            var UpdateTextBoxVal = document.getElementById(UpdateTextBox);
            UpdateTextBoxVal.value = text.value + ";" + eventArgs.get_value();

        };

        function Txt_Validation() {
            debugger;
            var TxtEmailBody = $('#ContentPlaceHolder1_myArea3_ifr').contents().find('body').text();
            var content = tinymce.get("ContentPlaceHolder1_myArea3").getContent();
            var txtSubject = document.getElementById('<%=txtSubject.ClientID%>').value;

            if (TxtEmailBody.trim() == "") {
                alert("Please Fill Email Body.");
                document.getElementById('<%=myArea3.ClientID%>').focus();
                return false;
            }

            if (txtSubject.trim() == "") {
                alert("Please Fill Subject.");
                document.getElementById('<%=txtSubject.ClientID%>').focus();
                return false;
            }

            if (content.length > 32530) {
                alert("Max 32530 character set are allowed.Current Character Size=" + content.length);
                document.getElementById('<%=myArea3.ClientID%>').focus();
                return false;
            }
        }

    </script>

    <%--  <script type="text/javascript">
        function GetEmail(source, eventArgs) {
            alert('hi');
            // Sample string
            var str = "The quick brown fox jumps over the lazy dog."

            // Check if the substring exists inside the string
            var index = str.indexOf(";");
            if (index !== -1) {
                var s = source.get_id();
                //  alert(s);
                var ss = s.split("_");
                var UpdateTextBox = ss[0] + '_txtCC';
                var text = document.getElementById(UpdateTextBox)
                var UpdateTextBoxVal = document.getElementById(UpdateTextBox);
                UpdateTextBoxVal.value = text.value + ";" + eventArgs.get_value();
            }
            else {

            }

        };
    </script>--%>
    <%-- <asp:UpdatePanel ID="upd" UpdateMode="Conditional" runat="server">--%>
    <%--<ContentTemplate>--%>
    <div class="main-content">
        <nav aria-label="breadcrumb" class="offset-md-9" style="margin-top: -8px; margin-right: -60px;">
            <ol class="breadcrumb">
                <li class="breadcrumb-item"><a href="Email_Type.aspx">Email Type</a></li>

                <li class="breadcrumb-item active" aria-current="page">Email Notification</li>

            </ol>
        </nav>
        <section class="section">
            <div class="row">
                <div class="col-lg-12 col-md-12 col-12 col-sm-12">
                    <div class="card">
                        <div class="card-header">
                            <h4>Set Email Format</h4>
                            <div class="col-md-6">
                                <label class="switch">
                                    <asp:CheckBox ID="chkOnOff1" runat="server" />
                                    <%--<span class="slider round"></span>--%>
                                    <div class="slider round">
                                        <!--ADDED HTML -->
                                        <span class="on">ON</span><span class="off">OFF</span><!--END-->
                                    </div>
                                </label>
                            </div>
                        </div>
                        <div class="card-body mr-4">
                            <div class="row">
                                <div class="col-md-12">
                                    <div id="accordion">
                                        <table class="table emptable">
                                            <tr>
                                                <td style="padding: 0 !important;" colspan="5">
                                                    <div class="col-md-12" id="additional_row1">
                                                        <div class="" style="padding-top: 5px;" id="dynamic_form">

                                                            <div class="row">
                                                                <div class="col-md-4">
                                                                    <div class="form-group text-left">
                                                                        <label>From (Employee ID)</label>
                                                                        <asp:TextBox ID="txtFrom" runat="server" Width="100%" CssClass="form-control"></asp:TextBox>
                                                                    </div>
                                                                </div>
                                                                <div class="col-md-4">
                                                                    <div class="form-group text-left">
                                                                        <label>Email Type</label>
                                                                        <asp:TextBox ID="txtEmailType" runat="server" Width="100%" CssClass="form-control"></asp:TextBox>
                                                                    </div>
                                                                </div>
                                                                <div class="col-md-4">
                                                                    <div class="form-group text-left">
                                                                        <label>Add CC</label>
                                                                        <asp:UpdatePanel runat="server" ID="UpdatePanel5">
                                                                            <ContentTemplate>
                                                                                <asp:DropDownList ID="ddlAddCC" runat="server" CssClass="form-control" AutoPostBack="true" OnSelectedIndexChanged="ddlAddCC_SelectedIndexChanged"></asp:DropDownList>
                                                                            </ContentTemplate>
                                                                        </asp:UpdatePanel>
                                                                    </div>
                                                                </div>
                                                                <div class="col-md-12 text-left">
                                                                    <div class="">
                                                                        <h4>Add CC Details</h4>
                                                                    </div>
                                                                </div>
                                                                <div class="clearfix"></div>

                                                                <div class="col-md-12">
                                                                    <div class="form-group text-left">
                                                                        <div class="sandbox">
                                                                            <!--<label for="select-to">Email:</label>-->
                                                                            <%--   <label>Add CC</label>--%>
                                                                            <asp:UpdatePanel runat="server" ID="UpdatePanel1">
                                                                                <ContentTemplate>
                                                                                    <asp:TextBox ID="txtCC" runat="server" placeholder="Add CC..." Width="100%" CssClass="form-control" Style="height: 60px!important"></asp:TextBox>
                                                                                    <%-- TextMode="MultiLine"--%>
                                                                                </ContentTemplate>
                                                                                <Triggers>
                                                                                    <%--<asp:AsyncPostBackTrigger ControlID="ddlHRHead" EventName="SelectedIndexChanged" />
                                                                                    <asp:AsyncPostBackTrigger ControlID="ddlPresident" EventName="SelectedIndexChanged" />--%>
                                                                                    <%--<asp:AsyncPostBackTrigger ControlID="ddlEmployee" EventName="SelectedIndexChanged" />--%>
                                                                                </Triggers>
                                                                            </asp:UpdatePanel>
                                                                            <%-- <select id="select-to" class="contacts" placeholder="Add CC..."></select>--%>
                                                                        </div>
                                                                    </div>
                                                                </div>

                                                                <%--                                                                <div class="col-md-4">
                                                                    <div class="form-group text-left">
                                                                                                                        <asp:DropDownList ID="ddlHOD" runat="server" CssClass="form-control" >
                                                </asp:DropDownList>
                                                                        <asp:TextBox ID="txtHOD" runat="server" CssClass="form-control"></asp:TextBox>
                                                    <ajax:autocompleteextender ID="AutoCompleteExtender2" runat="server" TargetControlID="txtHOD"
                                                        MinimumPrefixLength="1" EnableCaching="true" CompletionSetCount="12" CompletionInterval="1000"
                                                        ServiceMethod="SearchEmployeeHOD" UseContextKey="True" OnClientItemSelected="GetRevName">
                                                    </ajax:autocompleteextender>

                                                                        <label>HR Head</label>
                                                                        <asp:UpdatePanel runat="server" ID="UpdatePanel2">
                                                                            <ContentTemplate>
                                                                                <asp:DropDownList ID="ddlHRHead" runat="server" CssClass="form-control" AutoPostBack="true" OnSelectedIndexChanged="ddlHRHead_SelectedIndexChanged"></asp:DropDownList>
                                                                            </ContentTemplate>
                                                                        </asp:UpdatePanel>
                                                                    </div>
                                                                </div>
                                                                <div class="col-md-4">
                                                                    <div class="form-group text-left">
                                                                                     <asp:DropDownList ID="ddlRev" runat="server" CssClass="form-control" >
                                                </asp:DropDownList>
                                                                        
                                                                        <asp:TextBox ID="txtRev" runat="server" CssClass="form-control"></asp:TextBox>
                                                    <ajax:autocompleteextender ID="AutoCompleteExtender1" runat="server" TargetControlID="txtRev"
                                                        MinimumPrefixLength="1" EnableCaching="true" CompletionSetCount="12" CompletionInterval="1000"
                                                        ServiceMethod="SearchEmployeeRev" UseContextKey="True" OnClientItemSelected="GetRevName">
                                                    </ajax:autocompleteextender>
                                                                        <label>President</label>
                                                                        <asp:UpdatePanel runat="server" ID="UpdatePanel3">
                                                                            <ContentTemplate>
                                                                                <asp:DropDownList ID="ddlPresident" runat="server" CssClass="form-control" AutoPostBack="true" OnSelectedIndexChanged="ddlPresident_SelectedIndexChanged"></asp:DropDownList>
                                                                            </ContentTemplate>
                                                                        </asp:UpdatePanel>
                                                                    </div>
                                                                </div>

                                                                <div class="col-md-4">
                                                                    <div class="form-group text-left">
                                                                        <asp:TextBox ID="txtMAT" runat="server" CssClass="form-control"></asp:TextBox>
                                                    <ajax:autocompleteextender ID="AutoCompleteExtender3" runat="server" TargetControlID="txtMAT"
                                                        MinimumPrefixLength="1" EnableCaching="true" CompletionSetCount="12" CompletionInterval="1000"
                                                        ServiceMethod="SearchEmployeeMx" UseContextKey="True" OnClientItemSelected="GetRevName">
                                                    </ajax:autocompleteextender>
                                                                        <label>Employee</label>
                                                                        <asp:UpdatePanel runat="server" ID="UpdatePanel4">
                                                                            <ContentTemplate>
                                                                                <asp:DropDownList ID="ddlEmployee" runat="server" CssClass="form-control" AutoPostBack="true" OnSelectedIndexChanged="ddlEmployee_SelectedIndexChanged"></asp:DropDownList>
                                                                            </ContentTemplate>
                                                                        </asp:UpdatePanel>
                                                                    </div>
                                                                </div>--%>

                                                                <div class="col-md-12 text-left">
                                                                    <div class="">
                                                                        <h4>Add BCC Details</h4>
                                                                    </div>
                                                                </div>
                                                                <div class="clearfix"></div>
                                                                <div class="col-md-12">
                                                                    <div class="form-group text-left">
                                                                        <div class="sandbox">
                                                                            <%-- <label>Add BCC</label>--%>
                                                                            <!--<label for="select-to">Email:</label>-->
                                                                            <asp:TextBox ID="txtBCC" runat="server" placeholder="Add BCC..." Width="100%" CssClass="form-control" Style="height: 60px!important"></asp:TextBox>
                                                                            <%--<select id="select-to1" class="contacts" placeholder="Add BCC..."></select>--%>
                                                                        </div>
                                                                    </div>
                                                                </div>
                                                                <%--                                             <div class="col-md-4">
                                <div class="form-group">
                                    <select class="form-control form-control1">
                                    <option value="">Departments</option>
                                    <option value="1">2018-2019</option>
                                    <option value="2">2017-2018</option>
                                    <option value="3">2016-2017</option>
                                </select>
                                    <label>Departments</label>
                                </div>
                            </div>
                            
                            <div class="col-md-4">
                                <div class="form-group">                                    
                                    <select class="form-control form-control1">
                                    <option value="">Function</option>
                                    <option value="1">2018-2019</option>
                                    <option value="2">2017-2018</option>
                                    <option value="3">2016-2017</option>
                                </select>
                                    <label>Function</label>
                                </div>
                            </div>  
                            <div class="col-md-4">
                                <div class="form-group">                                    
                                  <select class="form-control form-control1">
                                    <option value="">Region</option>
                                    <option value="1">2018-2019</option>
                                    <option value="2">2017-2018</option>
                                    <option value="3">2016-2017</option>
                                </select>
                                    <label>Band</label>
                                </div>
                            </div>
                            <div class="col-md-4">
                                <div class="form-group">
                                    <select class="form-control form-control1">
                                    <option value="">Band</option>
                                    <option value="1">2018-2019</option>
                                    <option value="2">2017-2018</option>
                                    <option value="3">2016-2017</option>
                                </select>
                                    <label>HOD</label>                                    
                                </div>
                            </div>
                            <div class="col-md-4">
                                <div class="form-group">                                    
                                    <select class="form-control form-control1">
                                    <option value="">HOD</option>
                                    <option value="1">2018-2019</option>
                                    <option value="2">2017-2018</option>
                                    <option value="3">2016-2017</option>
                                </select>
                                    <label>Reviewer</label>
                                </div>
                            </div>

                             <div class="col-md-4">
                                <div class="form-group">                                    
                                    <select class="form-control form-control1">
                                    <option value="">HOD</option>
                                    <option value="1">2018-2019</option>
                                    <option value="2">2017-2018</option>
                                    <option value="3">2016-2017</option>
                                </select>
                                    <label>Metrix Manager</label>
                                </div>
                            </div>
                                                                --%>



                                                                <div class="col-md-12 text-left">
                                                                    <div class="">
                                                                        <h4>Add Subject</h4>
                                                                    </div>
                                                                </div>




                                                                <div class="col-md-12">
                                                                    <div class="form-group text-left">
                                                                        <%-- <label>Add Subject</label>--%>
                                                                        <asp:TextBox ID="txtSubject" runat="server" Width="100%" CssClass="form-control" Style="height: 60px!important"></asp:TextBox>
                                                                        <%--                                        <label>Subject</label>
                                                                        --%>
                                                                    </div>
                                                                </div>
                                                                <div class="clearfix"></div>
                                                                <div class="col-md-4 text-left">
                                                                    <div class="form-group">
                                                                        <label>Add Mail Body</label>
                                                                        <asp:DropDownList ID="ddlType" runat="server" CssClass="form-control has-content">
                                                                        </asp:DropDownList>
                                                                    </div>
                                                                </div>
                                                                <div class="col-md-4">
                                                                    <div class="form-group">
                                                                    </div>
                                                                </div>
                                                                <div class="col-md-4">
                                                                    <div class="form-group">
                                                                        <label>Mail Type Field</label>
                                                                        <asp:DropDownList ID="ddlfieldType" runat="server" CssClass="form-control has-content" AutoPostBack="true" OnSelectedIndexChanged="ddlfieldType_SelectedIndexChanged">
                                                                        </asp:DropDownList>
                                                                    </div>
                                                                </div>
                                                                <%-- <div class="col-md-4">
                                                                    <div class="form-group">
                                                                        <asp:DropDownList ID="ddlType" runat="server" CssClass="form-control has-content">
                                                                        </asp:DropDownList>
                                                                    </div>
                                                                </div>--%>
                                                                <div id="sample" class="col-md-12 form-group">
                                                                    <asp:TextBox ID="myArea3" runat="server" TextMode="MultiLine" Width="100%" CssClass="form-control" Height="150px"> </asp:TextBox>

                                                                </div>
                                                                <ul class="list-unstyled list-inline pull-right form-group col-md-12 text-right">
                                                                    <li style="padding: 0;">

                                                                        <asp:Button ID="btnSave" runat="server" Text="Save" CssClass="btn btn-info btn-lg all" OnClick="btnSave_Click" OnClientClick="return Txt_Validation();" />

                                                                    </li>

                                                                </ul>
                                                            </div>
                                                        </div>
                                                    </div>
                                                </td>
                                            </tr>

                                        </table>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </section>
    </div>

    <%-- </ContentTemplate>--%>
    <%--</asp:UpdatePanel>--%>
    <script src="assets/js/jquery-3.5.1.min.js"></script>
    <script type="text/javascript" src="assets/js/bootstrap-3.0.3.min.js"></script>

    <!-- General JS Scripts -->
    <script src="assets/js/app.min.js"></script>
    <script src="assets/js/scripts.js"></script>



    <script src="assets/js/chosen.jquery-1.8.7.min.js"></script>
    <link href="assets/css/chosen-1.8.7.min.css" rel="stylesheet" />

    <script>
    <%--    $('#<%=ddlPresident.ClientID%>').chosen();--%>
        $(document).ready(function () {
           <%-- $('#<%=ddlPresident.ClientID%>').chosen();--%>
            Sys.WebForms.PageRequestManager.getInstance().add_endRequest(EndRequestHandler);
            function EndRequestHandler(sender, args) {
                <%-- $('#<%=ddlPresident.ClientID%>').chosen();--%>
            }
        });
    </script>

    <script>
     <%--   $('#<%=ddlHRHead.ClientID%>').chosen();--%>
        $(document).ready(function () {
            <%--$('#<%=ddlHRHead.ClientID%>').chosen();--%>
            Sys.WebForms.PageRequestManager.getInstance().add_endRequest(EndRequestHandler);
            function EndRequestHandler(sender, args) {
                <%-- $('#<%=ddlHRHead.ClientID%>').chosen();--%>
            }
        });
    </script>

    <script>
     <%--   $('#<%=ddlEmployee.ClientID%>').chosen();--%>
        $(document).ready(function () {
           <%-- $('#<%=ddlEmployee.ClientID%>').chosen();--%>
            Sys.WebForms.PageRequestManager.getInstance().add_endRequest(EndRequestHandler);
            function EndRequestHandler(sender, args) {
                <%-- $('#<%=ddlEmployee.ClientID%>').chosen();--%>
            }
        });
    </script>

</asp:Content>
