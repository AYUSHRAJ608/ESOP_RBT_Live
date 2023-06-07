<%@ Page Title="" Language="C#" MasterPageFile="~/ESOP.Master" AutoEventWireup="true" CodeBehind="Grant_Creation_Append_Override_New.aspx.cs" Inherits="ESOP.Grant_Creation_Append_Override_New" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ScriptManager ID="script" runat="server"></asp:ScriptManager>
    <style type="text/css">
        html, body {
            background: none !important;
        }

        #overlay {
            position: fixed;
            z-index: 99;
            top: 0px;
            left: 0px;
            background-color: #FFFFFF;
            width: 100%;
            height: 100%;
            filter: Alpha(Opacity=80);
            opacity: 0.80;
        }

        #theprogress {
            position: center;
            padding-top: 15%;
            padding-left: 40%;
            background-color: white;
            width: 20px;
            height: 12px;
            text-align: center;
            filter: Alpha(Opacity=100);
            opacity: 1;
        }

        #modelprogress {
            position: absolute;
            top: 50%;
            left: 50%;
            margin: -11px 0 0 -55px;
            color: white;
        }

        body > #modelprogress {
            position: fixed;
        }
    </style>
    <style>
        a.btn.btn-icon.btn-primary.form-control {
            /* border-radius: 22px; */
            width: 115% !important;
            color: #fff !important;
            background-color: #2600ff !important;
            padding-top: 6px !important;
        }

        .btn.btn-lg {
            border: 2px solid #09728a;
            /*margin-top: 4px !important;
				 margin-left: -200px;
			font-size: 14px !important;*/
            background: #2600ff !important;
            border: 2px solid #2600ff !important;
        }

        a.btn.btn-icon.btn-primary.form-control {
            border-radius: 22px;
            width: 115% !important;
            color: #fff !important;
        }

        .optiongroup1 {
            font-weight: bold;
            font-size: 14px;
            /*font-style:italic;*/
        }

        .optionchild1 {
            font-size: 12px;
        }
    </style>
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
    </style>
    <%--  <script type="text/javascript">
		window.onsubmit = function () {
			if (Page_IsValid) {
				var updateProgress = $find("<%= UpdateProgress.ClientID %>");
				window.setTimeout(function () {
					updateProgress.set_visible(true);
				}, 200);
			}
		}
	</script>--%>

    <script language="javascript" type="text/javascript">
        function validate() {


            if (document.getElementById('customRadioInline4').checked) {


                if (document.getElementById('<%=ddlGrantName.ClientID%>').value == 0) {

			        alert("Please select Grant");
			        document.getElementById("<%=ddlGrantName.ClientID%>").focus();
					return false;
                }

                if (document.getElementById('<%=txtDateOfGrant.ClientID%>').value == "") {

			        alert("Please select date of grant");
			        document.getElementById("<%=txtDateOfGrant.ClientID%>").focus();
					return false;
                }


                if (document.getElementById("<%=ddlFMV.ClientID%>").value == 0) {
			        alert("Please select FMV price");
			        //document.getElementById("<%=ddlFMV.ClientID%>").focus();
				    return false;
				}
				<%--if (document.getElementById("<%=ddlFMV.ClientID%>").value == 'Select FMV') {
					alert("Please select FMV price");
					//document.getElementById("<%=ddlFMV.ClientID%>").focus();
					return false;
				}--%>

			    if (document.getElementById("<%=ddlVesting.ClientID %>").value == 0) {
			        alert("Please select Vesting Cycle");
			        //document.getElementById("<%=ddlVesting.ClientID %>").focus();
				    return false;

				 <%--   if (document.getElementById("<%=ddlVesting.ClientID %>").value =='Select Vesting Cycle') {
					alert("Please select Vesting Cycle");
					//document.getElementById("<%=ddlVesting.ClientID %>").focus();
					return false;--%>

				}
			    if (document.getElementById("<%=uploadfile.ClientID %>").value == 0) {
			        alert("Please select Excel file");
			        //document.getElementById("<%=ddlVesting.ClientID %>").focus();
				    return false;
				}
                var updateProgress1 = $get("<%= UpdateProgress1.ClientID %>");
			    updateProgress1.style.display = "block";
			    return true;
			}

            if (document.getElementById('customRadioInline3').checked) {

                if (document.getElementById('<%=ddlGrantName.ClientID%>').value == 0) {

			        alert("Please select Grant");
			        document.getElementById("<%=ddlGrantName.ClientID%>").focus();
					return false;
                }

                if (document.getElementById("<%=txtEmpID.ClientID%>").value == "") {
			        alert("Please enter Employee ID");
			        document.getElementById("<%=ddlVesting.ClientID %>").focus();
					return false;
                }



                if (document.getElementById('<%=txtDateOfGrant.ClientID%>').value == "") {

			        alert("Please select date of grant");
			        document.getElementById("<%=txtDateOfGrant.ClientID%>").focus();
					return false;
                }

                if (document.getElementById("<%=ddlFMV.ClientID%>").value == 0) {
			        alert("Please select FMV price");
			        document.getElementById("<%=ddlFMV.ClientID%>").focus();
					return false;
                }
                if (document.getElementById("<%=ddlVesting.ClientID %>").value == 0) {
			        alert("Please select Vesting Cycle");
			        document.getElementById("<%=ddlVesting.ClientID %>").focus();
					return false;
                }
                if (document.getElementById("<%=txtNoOfOption.ClientID%>").value == "") {
			        alert("Please enter No. of Option");
			        document.getElementById("<%=ddlVesting.ClientID %>").focus();
					return false;
                }
                var results = null;
                var x = document.getElementById("<%=txtNoOfOption.ClientID%>").value
				results = parseFloat(x);
				if (results == "0") {
				    alert("Please enter more than Zero No of Option");
				    document.getElementById("<%=ddlVesting.ClientID %>").focus();
					return false;
                }
                var updateProgress1 = $get("<%= UpdateProgress1.ClientID %>");
			    updateProgress1.style.display = "block";
			}
        }
    </script>


    <script type="text/javascript">
        function ReqValidation() {
            debugger;
            var FileUpload1 = document.getElementById('<%=FileUpload1.ClientID%>').value;
			var validationdate = document.getElementById('<%=txtvaldate.ClientID%>').value;
		    var validupto = document.getElementById('<%=txtvalidupto.ClientID%>').value;
		    var FMVPrice = document.getElementById('<%=txtfmvprice.ClientID%>').value;
		    var ValueBy = document.getElementById('<%=ddlvaluedby.ClientID%>').value;

		    if (validationdate.trim() == "") {
		        alert("Select Valudation Date!");
		        document.getElementById('<%=txtvaldate.ClientID%>').focus();
				return false;
            }
            if (validupto.trim() == "") {
                alert("Select Valid Upto Date!");
                document.getElementById('<%=txtvalidupto.ClientID%>').focus();
				return false;
            }
            if (FMVPrice.trim() == "") {
                alert("Select FMV Price!!");
                document.getElementById('<%=txtfmvprice.ClientID%>').focus();
				return false;
            }


            if (FMVPrice.charAt(0) == 0) {
                alert("FMV Price cannot be" + " " + FMVPrice + "");
                document.getElementById('<%=txtfmvprice.ClientID%>').focus();
				document.getElementById('<%=txtfmvprice.ClientID%>').value = "";
			    return false;
			}

			<%--if (ValueBy.trim() == "0") {
				alert("Select Valued By!!");
				document.getElementById('<%=ddlvaluedby.ClientID%>').focus();
				return false;
			}--%>

		    if (FileUpload1.trim() != "") {
		        var ext = FileUpload1.substr(FileUpload1.lastIndexOf('.') + 1).toLowerCase();
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
        }
    </script>

    <script language="Javascript">
        function isNumberKey1(evt) {
            var charCode = (evt.which) ? evt.which : evt.keyCode;
            if (charCode > 31 && (charCode < 48 || charCode > 57))
                return false;

            return true;
        }
        function isNumberKey2(txt, evt) {
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
        function Override_Click() {
            //alert('HI');
            document.getElementById("<%=ddlGrantName.ClientID %>").value == 0
		}
    </script>

    <div class="main-content">
        <nav aria-label="breadcrumb">
            <ol class="breadcrumb">
                <li class="breadcrumb-item"><a href="admin-dashboard.aspx">Home</a></li>
                <li class="breadcrumb-item"><a href="grants.aspx">Grant</a></li>
                <li class="breadcrumb-item active" aria-current="page">Grant Updation</li>
            </ol>
        </nav>

        <section class="section">
            <div class="row">
                <div class="col-lg-12">
                    <asp:UpdatePanel ID="upd2" runat="server">
                        <ContentTemplate>
                            <div id="showmsg" runat="server"></div>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                    <div class="card" id="GrantUpdation" runat="server">
                        <div class="card-header">
                            <h4>Grant Updation</h4>
                            <div>
                                <div class="form-group" style="margin-left: 25px; margin-bottom: 0px;">
                                    <div class="custom-control custom-radio custom-control-inline">
                                        <input type="radio" id="customRadioInline4" name="customRadioInline3" class="custom-control-input" value="bulk" onclick="Hide_Div()" <%= this.inputtypeBulk %>/>
                                        <%--<asp:RadioButton ID="rbBulk" runat="server" Text="Bulk Data Upload" />--%>
                                        <label class="custom-control-label" for="customRadioInline4">Bulk Data Upload  </label>
                                    </div>
                                    <div class="custom-control custom-radio custom-control-inline">
                                        <input type="radio" id="customRadioInline3" name="customRadioInline3"
                                            class="custom-control-input" value="single" onclick="Hide_Div()" <%= this.inputtypeSingle %>/>
                                        <%--<asp:RadioButton ID="rbSingle" runat="server" Text="Single Data Entry" />--%>
                                        <label class="custom-control-label" for="customRadioInline3">Single Data Entry</label>
                                    </div>
                                    <div class="custom-control custom-radio custom-control-inline">
                                        <asp:LinkButton ID="lnkGrdAppUpdate" Text="Grant Creation" PostBackUrl="~/Grand_Creation" runat="server" />
                                    </div>
                                </div>
                            </div>
                        </div>

                        <div class="form-group" style="margin-left: 50px; margin-bottom: 0px;">
                            <%-- <asp:RadioButton ID="rbAppend" runat="server" Text="&nbsp Append" /> &nbsp &nbsp
							<asp:RadioButton ID="rbOverridw" runat="server" Text="&nbsp Override" />--%>
                            <div class="custom-control custom-radio custom-control-inline">
                                <%--<input type="radio" id="rbAppend" name="radioBtn" class="custom-control-input" value="Append" checked>--%>
                                <input type="radio" id="rbAppend" name="radioBtn" class="custom-control-input" value="Append" <%= this.inputtypeCT %>>
                                <label class="custom-control-label" for="rbAppend">Append</label>
                            </div>
                            <div class="custom-control custom-radio custom-control-inline">
                                <input type="radio" id="rbOverride" name="radioBtn" class="custom-control-input" value="Override" <%= this.inputtypeCT_1 %>>
                                <%--onchange="Override_Click();"--%>
                                <label class="custom-control-label" for="rbOverride">Override</label>
                            </div>
                        </div>

                        <div class="card-body">
                            <div class="row" style="margin-top: 15px;">
                                <!--Sweet alert-->
                                <div class="col-lg-4 col-md-12 col-sm-12 all">
                                    <div class="form-group">
                                        <label>Grant Name <span style="color: red">*</span></label>
                                        <%--<input type="text" class="form-control" value="Tranch 12" disabled>--%>
                                        <%--<asp:TextBox ID="txtGrantName" ReadOnly="true" runat="server" class="form-control"></asp:TextBox>--%>
                                        <asp:DropDownList ID="ddlGrantName" runat="server" CssClass="form-control" AutoPostBack="true" OnSelectedIndexChanged="ddlGrantName_SelectedIndexChanged"></asp:DropDownList>
                                    </div>
                                </div>
                                <div class="col-lg-4 col-md-12 col-sm-12 singledatadiv">
                                    <div class="form-group">
                                        <label>Employee ID <span style="color: red">*</span> </label>
                                        <%--<input type="text" class="form-control">--%>
                                        <asp:TextBox ID="txtEmpID" runat="server" class="form-control readonly ="></asp:TextBox>
                                    </div>
                                </div>
                                <div class="col-lg-4 col-md-12 col-sm-12 all">
                                    <div class="form-group">
                                        <label>Date of Grant <span style="color: red">*</span></label>
                                        <asp:UpdatePanel ID="up1" runat="server">
                                            <ContentTemplate>
                                                <asp:TextBox ID="txtDateOfGrant" Placeholder="dd-mm-yyyy" runat="server" class="form-control" OnTextChanged="txtDateOfGrant_TextChanged1" AutoPostBack="true"></asp:TextBox>
                                            </ContentTemplate>
                                        </asp:UpdatePanel>
                                    </div>
                                </div>

                                <div class="col-lg-2 col-md-12 col-sm-12 all">
                                    <div class="form-group">
                                        <label>Select Grant Price <span style="color: red">*</span></label>
                                        <label class="or">OR</label>
                                        <asp:UpdatePanel ID="UpdatePanel7" runat="server">
                                            <ContentTemplate>
                                                <div class="input-group mb-3">

                                                    <asp:DropDownList ID="ddlFMV" runat="server" CssClass="form-control" AutoPostBack="false">
                                                    </asp:DropDownList>

                                                </div>
                                            </ContentTemplate>
                                        </asp:UpdatePanel>
                                    </div>
                                </div>
                                <div class="col-lg-2 col-md-12 col-sm-12 all">
                                    <div class="form-group">
                                        <label></label>
                                        <a href="#" class="btn btn-icon btn-primary martop" data-toggle="modal" data-target="#ModalCreateFMV">Create FMV</a>

                                    </div>
                                </div>
                                <div class="col-lg-2 col-md-12 col-sm-12 all">
                                    <div class="form-group">
                                        <label>Vesting Cycle <span style="color: red">*</span></label>
                                        <label class="or">OR</label>
                                        <%--<label class="or">OR</label>
									<div class="input-group mb-3">
										<select class="form-control">
											<option value="vesting Cycle 1">Vesting Cycle 1</option>
											<optgroup label="V1 25% of the Grant after 2 years"></optgroup>
											<optgroup label="V2 25% of the Grant after 3 years"></optgroup>
											<optgroup label="V3 50% of the Grant after 4 years"></optgroup>
											<option value="Vesing Cycle 2">Vesting Cycle 2</option>
											<optgroup label="V1 20% of the Grant after 1 years"></optgroup>
											<optgroup label="V2 80% of the Grant after 4 years"></optgroup>
										</select>
									</div>--%>
                                        <asp:DropDownList ID="ddlVesting" runat="server" CssClass="form-control" AutoPostBack="false"></asp:DropDownList>
                                    </div>
                                </div>
                                <div class="col-lg-2 col-md-12 col-sm-12 all">
                                    <div class="form-group">
                                        <label></label>
                                        <a href="#" class="btn btn-icon btn-primary martop" data-toggle="modal" data-target=".bd-example-modal-lg1">Create Vesting Cycle</a>
                                    </div>
                                </div>

                                <div class="col-lg-4 col-md-12 col-sm-12 multidatadiv">
                                    <div class="form-group">
                                        <label>Upload File <span style="color: red">*</span></label>
                                        <%--<input type="file" class="form-control">--%>
                                        <asp:FileUpload ID="uploadfile" runat="server" CssClass="dropify" accept=".xls, .xlsx" class="form-control" />
                                        <asp:Label ID="lblFileType2" runat="server" Text="(Only .xls, .xlsx files are allowed.)" ForeColor="Green" Font-Bold="true" Font-Size="14px"></asp:Label>
                                        <%--onchange="return dispFileName();"--%>
                                    </div>
                                </div>

                                <div class="col-lg-4 col-md-12 col-sm-12 singledatadiv">
                                    <div class="form-group">
                                        <label>No.of Options <span style="color: red">*</span> </label>
                                        <%--<input type="text" class="form-control">--%>
                                        <asp:TextBox ID="txtNoOfOption" runat="server" class="form-control" onkeypress="return isNumberKey1(event)" MaxLength="10"></asp:TextBox>
                                    </div>
                                </div>

                                <div class="col-lg-4 col-md-12 col-sm-12 multidatadiv">
                                    <div class="form-group">
                                        <div class="section-title">Upload Format</div>
                                        <div class="">
                                            <label style="margin-right: 15px;">Excel  </label>
                                            <%--<a href="#" class="linkbtn" style="font-size: 14px; font-weight: 500; letter-spacing: 0.2px; margin: 10px 0 0 0; color: #5e65ff; clear: both; text-decoration: underline">Download Template</a>--%>
                                            <asp:LinkButton ID="myLink" Text="Download Template" OnClick="LinkButton_Click" runat="server" />
                                        </div>
                                    </div>
                                </div>

                                <div class="col-lg-2 col-md-12 col-sm-12 all">
                                    <div class="form-group">
                                        <label>Select Tax Regime <span style="color: red">*</span> </label>
                                        <asp:DropDownList ID="ddlTaxRegime" runat="server" CssClass="form-control">
                                            <asp:ListItem Text="Select" Value="0"></asp:ListItem>
                                            <asp:ListItem Text="Old" Value="O"></asp:ListItem>
                                            <asp:ListItem Text="New" Value="N"></asp:ListItem>
                                        </asp:DropDownList>
                                    </div>
                                </div>

                                <div class="col-lg-6 offset-lg-3 mt-5">
                                    <asp:UpdatePanel ID="UP_submit" runat="server">
                                        <ContentTemplate>
                                            <asp:Button ID="btnSaveGrant" runat="server" Text="Create Grant" OnClick="btnSaveGrant_Click" OnClientClick="return validate(); showProgress1(); return false;return postbackButtonClick();" CssClass="btn btn-info btn-lg all" />
                                            <br />
                                            <label style="margin-right: 15px;">Password Protected</label>
                                            <asp:CheckBox runat="server" ID="chk" EnableViewState="false" Checked="true" />
                                        </ContentTemplate>
                                        <Triggers>
                                            <asp:PostBackTrigger ControlID="btnSaveGrant" />
                                        </Triggers>
                                    </asp:UpdatePanel>
                                </div>

                            </div>
                            <div style="color: red; float: right">
                                All (*) marked fields are mandatory.
                            </div>
                        </div>
                        <%--<asp:UpdatePanel ID="upd2" runat="server">
							<ContentTemplate>
								<div id="showmsg" runat="server"></div>
							</ContentTemplate>
						</asp:UpdatePanel>--%>
                    </div>

                    <%--</ContentTemplate>--%>
                    <%--</asp:UpdatePanel>--%>
                </div>
                <div class="col-lg-12 col-md-12 col-12 col-sm-12" id="tablediv" runat="server">

                    <div class="card" style="height: auto;">
                        <div class="card-header">
                            <h4>Record Summary</h4>
                        </div>
                        <div class="card-body">
                            <div class="table-responsive">
                                <table class="table table-bordered">
                                    <tbody>
                                        <tr>
                                            <td width="100px">1</td>
                                            <td>Total records uploaded</td>
                                            <td>
                                                <div class="badge badge-info"><%= TotalRecords %></div>
                                            </td>
                                            <td>No.of records uploaded successfully</td>
                                            <td>
                                                <div class="badge badge-success"><%= SuccRecords %></div>
                                            </td>
                                            <td>No.of records failed</td>
                                            <td>
                                                <div class="badge badge-danger"><%= FailRecords %></div>
                                            </td>
                                            <td>
                                                <%--<a href="#" class="btn btn-icon icon-left" style="font-size: 16px; font-weight: 500; letter-spacing: 0.2px; margin: 10px 0 0 0; color: #5e65ff; clear: both;"><i class="fas fa-arrow-circle-down"></i>Download Failed Records</a>--%>
                                                <button runat="server" id="btnExDown" onserverclick="downloadFailedRec" style="background: none">
                                                    <i class="fas fa-arrow-circle-down"></i>
                                                    <%--<i class="fas fa-file-excel excel" title="Download Excel" aria-hidden="true"></i>--%>
                                                </button>
                                            </td>
                                        </tr>
                                    </tbody>
                                </table>
                            </div>
                        </div>
                    </div>
                </div>

                <div class="col-lg-12 col-md-12 col-12 col-sm-12" id="tablediv_1" runat="server">
                    <div class="card" style="height: auto;">
                        <div class="card-header">
                            <h4>Grants</h4>
                        </div>
                        <div class="card-body">
                            <div class="table-responsive">
                                <table class="table table-bordered">
                                    <asp:UpdatePanel ID="UpdatePanel8" runat="server">
                                        <ContentTemplate>

                                            <asp:GridView ID="grdData" class="table" runat="server" Style="width: 98%;"
                                                AutoGenerateColumns="False" AllowPaging="false" PageSize="10" AllowSorting="false"
                                                EmptyDataText="No data found" AllowCustomPaging="false" ViewStateMode="Enabled" OnRowCommand="grdData_RowCommand">
                                                <Columns>
                                                    <asp:TemplateField HeaderText="Employee Name">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lbl_DEM_EMP_ID" runat="server" Text='<%#Eval("Employee_Name") %>'></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>

                                                    <asp:TemplateField HeaderText="Grant Name">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lbl_DEM_GRANT_NAME" runat="server" Text='<%#Eval("DEM_GRANT_NAME") %>'></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>

                                                    <asp:TemplateField HeaderText="Date of Grant">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lbl_DEM_GRANT_DATE" runat="server" Text='<%#Eval("DEM_GRANT_DATE") %>'></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>

                                                    <asp:TemplateField HeaderText="No Of Option">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lbl_DEM_NO_OF_OPTION" runat="server" Text='<%#Eval("DEM_NO_OF_OPTION") %>'></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Grant Letter Download">
                                                        <ItemTemplate>
                                                            <asp:HiddenField ID="HiddenField1" runat="server" Value='<%# Bind("FILEName") %>' />
                                                            <asp:LinkButton ID="btn_Preview" runat="server" CausesValidation="false" CommandName="Preview" OnClick="btn_Preview_Click"
                                                                CssClass="btn btn-icon btn-success fas fa-eye" AutoPostback="false"></asp:LinkButton>
                                                            <asp:LinkButton ID="lb_download" runat="server" CommandArgument='<%# Eval("FILEName") %>' CausesValidation="false"
                                                                class="btn btn-icon btn-primary fas fa-arrow-down" OnClick="lb_download_Click"></asp:LinkButton>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                </Columns>

                                            </asp:GridView>

                                        </ContentTemplate>
                                        <%--<Triggers>
								<asp:AsyncPostBackTrigger ControlID="lb_download" />
							</Triggers>--%>
                                    </asp:UpdatePanel>
                                </table>
                            </div>
                        </div>
                    </div>
                    <div class="card-body">
                        <div class="modal-footer bg-whitesmoke br" style="margin: 0 auto; width: 100%; justify-content: center;">
                            <div class="btn-group" role="group" aria-label="Basic example">
                                <asp:Button ID="BtnCancle" runat="server" Text="Cancel Grant" OnClick="Cancle_Click" CssClass="btn btn-info btn-lg all" />
                                <asp:Button ID="BtnSubmitGrant" runat="server" Text="Save Grant" OnClick="BtnSubmitGrant_Click" CssClass="btn btn-info btn-lg all" />
                                <asp:Button ID="BtnRetunt" runat="server" Text="Retrun to Grant Creation" OnClick="BtnRetunt_Click" CssClass="btn btn-info btn-lg all" />

                                <%--<a href="#" class="btn btn-info btn-lg all CloseBtnNew" data-dismiss="modal">Save Grant</a>--%>
                            </div>
                        </div>
                    </div>
                </div>

                <asp:UpdateProgress ID="UpdateProgress1" runat="server" AssociatedUpdatePanelID="UP_submit">
                    <ProgressTemplate>
                        <div id="overlay">
                            <div id="modalprogress">
                                <div id="theprogress">
                                    <img src="assets/img/loading.gif" />
                                </div>
                            </div>
                        </div>
                    </ProgressTemplate>
                </asp:UpdateProgress>
            </div>
        </section>


    </div>

    <!--Create FMV popup-->

    <div class="modal fade bd-example-modal-lg" tabindex="-1" role="dialog" id="ModalCreateFMV" aria-labelledby="myLargeModalLabel" aria-hidden="false">
        <div class="modal-dialog modal-lg">
            <div class="modal-content">
                <div class="modal-header">
                    <h5 class="modal-title" id="myLargeModalLabel">Create FMV</h5>
                    <%--  <button type="button" class="close" data-dismiss="modal" aria-label="Close">
						<span aria-hidden="true">×</span>
					</button>--%>
                </div>
                <div class="modal-body">

                    <div class="row">
                        <!--Sweet alert-->
                        <div class="col-lg-6 col-md-12 col-sm-12">
                            <div class="form-group">
                                <label>Valuation Date</label>
                                <%--<input type="text" class="form-control datepicker">--%>
                                <%--                                <asp:TextBox ID="txtvaldate" runat="server" class="form-control datepicker"></asp:TextBox>--%>
                                <%--                                <asp:TextBox ID="txtvaldate" runat="server" type="date" class="form-control"></asp:TextBox>--%>
                                <asp:TextBox ID="txtvaldate" type="text" placeholder="dd-mm-yyyy" runat="server" class="form-control" autocomplete="off"></asp:TextBox>


                            </div>
                        </div>

                        <div class="col-lg-6 col-md-12 col-sm-12">
                            <div class="form-group">
                                <label>Valid Upto</label>
                                <%--                                <asp:TextBox ID="txtvalidupto" runat="server" class="form-control datepicker"></asp:TextBox>--%>

                                <%--<input type="text" class="form-control datepicker">--%>
                                <%--                                <asp:TextBox ID="txtvalidupto" runat="server" type="date" class="form-control"></asp:TextBox>--%>
                                <asp:TextBox ID="txtvalidupto" type="text" placeholder="dd-mm-yyyy" runat="server" class="form-control" autocomplete="off"></asp:TextBox>


                            </div>
                        </div>
                        <div class="col-lg-6 col-md-12 col-sm-12">
                            <div class="form-group">
                                <label>FMV</label>
                                <%--  <input type="text" class="form-control">--%>
                                <asp:TextBox ID="txtfmvprice" runat="server" CssClass="form-control" MaxLength="10" onkeypress="return isNumberKey2(this,event)"></asp:TextBox>

                            </div>
                        </div>

                        <div class="col-lg-6 col-md-12 col-sm-12">
                            <div class="form-group">
                                <label>Valued By</label>
                                <div class="input-group mb-3">
                                    <asp:DropDownList ID="ddlvaluedby" runat="server" CssClass="form-control" Style="width: 100% !important;">
                                    </asp:DropDownList>
                                    <%--<select class="form-control">
										<option>Select..</option>
										<option>Demo 1</option>
										<option>Demo 2</option>
										<option>Demo 3</option>
									</select>--%>
                                </div>
                            </div>
                        </div>

                        <div class="col-lg-6 col-md-12 col-sm-12">
                            <div class="form-group">
                                <label>Upload File</label>
                                <%--  <input type="file" class="form-control">--%>
                                <asp:FileUpload ID="FileUpload1" runat="server" class="form-control" />
                                <asp:Label ID="Label1" runat="server" Text="(Only .xls, .xlsx files are allowed.)" ForeColor="Green" Font-Bold="true" Font-Size="14px"></asp:Label>
                            </div>
                        </div>
                        <!--<div class="col-lg-6 col-md-12 col-sm-12">
					 <div class="form-group">
						<label>Upload Formats</label>
						<div class="custom-control custom-radio custom-control-inline">
						   <input type="radio" id="customRadioInline1" name="customRadioInline1" class="custom-control-input">
						   <label class="custom-control-label" for="customRadioInline1">CSV</label>
						</div>
						<div class="custom-control custom-radio custom-control-inline">
						   <input type="radio" id="customRadioInline2" name="customRadioInline1" class="custom-control-input">
						   <label class="custom-control-label" for="customRadioInline2">Excel  </label>
						</div>
						<a href="#" class="linkbtn" style="font-size: 14px;font-weight: 500;letter-spacing: 0.2px;margin: 10px 0 0 0;color: #5e65ff;clear: both;text-decoration:underline">Download Template</a>
					 </div>
				  </div>-->
                    </div>
                </div>
                <div class="modal-footer bg-whitesmoke br">
                    <div class="btn-group" role="group" aria-label="Basic example">
                        <%--  <div class="col-lg-3 offset-md-3">--%>
                        <%--<button type="button" class="btn btn-primary filterEntry" data-dismiss="modal">Submit</button>--%>
                        <asp:Button ID="btncreatefmv" runat="server" Text="Create FMV" OnClick="btncreatefmv_Click" OnClientClick="return ReqValidation();"
                            class="btn btn-info btn-lg all" />
                        <a href="#" class="btn btn-info btn-lg all CloseBtnNew" data-dismiss="modal">Close</a>
                    </div>
                </div>
            </div>


        </div>
    </div>

    <!--Create grant popup end-->

    <!--Create vesting popup-->

    <div class="modal fade bd-example-modal-lg1" tabindex="-1" role="dialog" aria-labelledby="myLargeModalLabel" aria-hidden="true" style="display: none;" id="modalVesting">
        <div class="modal-dialog modal-lg">
            <div class="modal-content">
                <div class="modal-header">
                    <h5 class="modal-title" id="">Create Vesting Cycle</h5>
                    <%--<button type="button" class="close" data-dismiss="modal" aria-label="Close">
						<span aria-hidden="true">×</span>
					</button>--%>
                </div>
                <div class="modal-body">
                    <div class="row">
                        <div class="col-lg-12 col-md-12 col-12 col-sm-12">
                            <div class="card" style="height: 100%;">
                                <div class="card-body">
                                    <div class="row" style="margin-top: 15px;">
                                        <div class="offset-md-1 col-lg-5 col-md-12 col-sm-12">
                                            <div class="form-group">
                                                <label>Vesting Name</label>
                                                <%--<input type="text" class="form-control">--%>
                                                <asp:TextBox ID="txtVestingName" runat="server" CssClass="form-control" MaxLength="50"></asp:TextBox>
                                                <asp:RequiredFieldValidator ID="rfvVestingName" runat="server"
                                                    ErrorMessage="Vesting name is required" ControlToValidate="txtVestingName" ValidationGroup="Add" ForeColor="Red"
                                                    Display="None" CssClass="validation" SetFocusOnError="true"></asp:RequiredFieldValidator>

                                            </div>
                                        </div>
                                        <div class="col-lg-5 col-md-12 col-sm-12">
                                            <div class="form-group">
                                                <label>No. Of Vesting</label>
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
                                            <table class="table" style="width: 100%;">
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
                                                                            <asp:DropDownList ID="ddlduration1" runat="server" Style="margin-bottom: -2px; margin-top: 16px; width: 200px;"
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
                                                                            <asp:DropDownList ID="ddlduration2" runat="server" Style="margin-bottom: -2px; margin-top: 16px; width: 200px;" CssClass="form-control ddlwidth"
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
                                                                            <asp:DropDownList ID="ddlduration3" runat="server" Style="margin-bottom: -2px; margin-top: 16px; width: 200px;" CssClass="form-control"
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
                                                                            <asp:DropDownList ID="ddlduration4" runat="server" Style="margin-bottom: -2px; margin-top: 16px; width: 200px;" CssClass="form-control"
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
                                                                            <asp:DropDownList ID="ddlduration5" runat="server" Style="margin-bottom: -2px; margin-top: 16px; width: 200px;" CssClass="form-control">
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
                                    </div>

                                </div>
                            </div>
                        </div>
                    </div>
                    <%--<div class="modal-footer bg-whitesmoke br">
					<div class="col-lg-3 offset-md-3">
						<asp:Button ID="btnsubmit" runat="server" Text="Submit" OnClick="btnsubmit_Click"
							class="btn btn-info btn-lg all" />

					</div>--%>
                    <%--                    <button type="button" class="btn btn-primary filterEntry" data-dismiss="modal">Submit</button>--%>
                    <%--</div>--%>
                </div>
                <div class="modal-footer bg-whitesmoke br">
                    <div class="btn-group" role="group" aria-label="Basic example">
                        <%--  <div class="col-lg-3 offset-md-3 mt-5">--%>
                        <%--<asp:UpdatePanel runat="server" ID="upd1">--%>
                        <%--<ContentTemplate>--%>
                        <%--<a href="#" class="btn btn-info btn-lg all" id="btnimport">Create Vesting Cycle</a>--%>
                        <asp:ValidationSummary runat="server" ShowMessageBox="true" ShowSummary="false" ValidationGroup="Add" />
                        <asp:Button ID="btnimport" CssClass="btn btn-info btn-lg all" runat="server" OnClientClick="return GetSelectedItem('ddlnoOfCycle1');"
                            Text="Create Vesting Cycle" ValidationGroup="Add" OnClick="btnimport_Click" />
                        <a href="#" class="btn btn-info btn-lg all CloseBtnNew" data-dismiss="modal">Close</a>
                        <%--</ContentTemplate>--%>
                        <%--</asp:UpdatePanel>--%>
                    </div>

                </div>
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
                        <button id="btn1" class="btn btn-info btn-lg all CloseBtnNew">Close</button>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <!-- General JS Scripts -->


    <%--  <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.5.1/jquery.min.js"></script>
  <script src="https://maxcdn.bootstrapcdn.com/bootstrap/3.4.1/js/bootstrap.min.js"></script>--%>
    <script src="assets/js/app.min.js"></script>
    <script src="assets/js/scripts.js"></script>



    <link href="assets/css/jquery-ui-1.12.1.css" rel="stylesheet" />
    <%--  <script src="assets/js/jquery-1.12.4.js" type="text/javascript"></script>--%>
    <script src="assets/js/jquery-ui-1.12.1.js" type="text/javascript"></script>

    <%--    <script src="Scripts/bootstrap.min.js"></script>--%>
    <script type="text/javascript">

        $(function () {
            // $.noConflict();
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
    </script>

    <script>
        $(function () {
            var from = $("#ContentPlaceHolder1_txtDateOfGrant")
		 .datepicker({
		     //minDate: 0,
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
            var from = $("#ContentPlaceHolder1_txtDateOfGrant")
		.datepicker({
		    //minDate: 0,
		    dateFormat: "dd-mm-yy",
		    changeMonth: true,
		    changeYear: true,
		    yearRange: "-50:+50",
		});
        }
    </script>

    <%-- <script>
		$(document).ready(function () {

			$('.singledatadiv').hide();
			$("input[name='customRadioInline3']").change(function () {

				var radioValue = $("input[name='customRadioInline3']:checked").val();

				if (radioValue == "single") {

					$('.all').show()
					$('.singledatadiv').slideDown();
					$('.multidatadiv').hide();

					(document.getElementById("<%=ddlFMV.ClientID%>").value = 0)
					(document.getElementById("<%=ddlVesting.ClientID %>").value = 0)

					(document.getElementById("<%=txtEmpID.ClientID%>").value = "")
				}
				else {


					$('.all').show()
					$('.multidatadiv').slideDown();
					$('.singledatadiv').hide();
					(document.getElementById("<%=ddlFMV.ClientID%>").value = 0)
					(document.getElementById("<%=ddlVesting.ClientID %>").value = 0)

					(document.getElementById("<%=txtEmpID.ClientID%>").value = "")
				}

			});

			//$('#tablediv').hide();
			//$('#btnSaveGrant').click(function () {
			//    $('#tablediv').slideToggle();
			//    $('html, body').animate({
			//        scrollTop: $("#tablediv").offset().top
			//    }, 2000);

			//});
			//$('#tablediv').hide();

			//$('.CloseBtnNew').click(function () {
			//    alert('test');
			//    $('#myModal').modal('hide');
			//});
		});
	</script>--%>
    <script>
        $(document).ready(function Load() {
            $('.singledatadiv').hide();
            $("input[name='customRadioInline3']").change(function () {
                var radioValue = $("input[name='customRadioInline3']:checked").val();
                if (radioValue == "single") {

                    $('.all').show()
                    $('.singledatadiv').slideDown();
                    $('.multidatadiv').hide();

                    (document.getElementById("<%=ddlFMV.ClientID%>").value = 0)
					(document.getElementById("<%=ddlVesting.ClientID %>").value = 0)

					(document.getElementById("<%=txtEmpID.ClientID%>").value = "")
                }
                else {


                    $('.all').show()
                    $('.multidatadiv').slideDown();
                    $('.singledatadiv').hide();
                    (document.getElementById("<%=ddlFMV.ClientID%>").value = 0)
					(document.getElementById("<%=ddlVesting.ClientID %>").value = 0)

					(document.getElementById("<%=txtEmpID.ClientID%>").value = "")
                }

			});


		    var radioValue = $("input[name='customRadioInline3']:checked").val();

		    if (radioValue == "single") {
		        $('.all').show()

		        $('.multidatadiv').hide();
		        $('.singledatadiv').show();
				   <%-- (document.getElementById("<%=ddlFMV.ClientID%>").value = 0)
					(document.getElementById("<%=ddlVesting.ClientID %>").value = 0)

					(document.getElementById("<%=txtEmpID.ClientID%>").value = "")--%>
			}
			else {

			    $('.all').show()

			    $('.singledatadiv').hide();
			    $('.multidatadiv').show();
			    <%--   (document.getElementById("<%=ddlFMV.ClientID%>").value = 0)
					(document.getElementById("<%=ddlVesting.ClientID %>").value = 0)

					(document.getElementById("<%=txtEmpID.ClientID%>").value = "")--%>
			}

		    //$('#tablediv').hide();
		    //$('#btnSaveGrant').click(function () {
		    //    $('#tablediv').slideToggle();
		    //    $('html, body').animate({
		    //        scrollTop: $("#tablediv").offset().top
		    //    }, 2000);

		    //});
		    //$('#tablediv').hide();

		    //$('.CloseBtnNew').click(function () {
		    //    alert('test');
		    //    $('#myModal').modal('hide');
		    //});
		});
    </script>
    <script>
        function Hide_Div() {

            document.getElementById("<%=tablediv.ClientID%>").style.display = "none";

		};
    </script>

    <script>
        function Show_Div() {

            document.getElementById("<%=tablediv.ClientID%>").style.display = "block";

		};
    </script>
    <script>
        //function Show_Div() {
        //    //alert('HII');
        //    $('#tablediv').slideToggle();
        //    $('html, body').animate({
        //        scrollTop: $("#tablediv").offset().top
        //    }, 2000);

        //};
    </script>
    <%-- <script type="text/javascript">
		$('#basic').simpleTreeTable({
			collapsed: true,

			expander: $('#expander'),
			collapser: $('#collapser')
		});

		$(document).ready(function () {
			$('#collapser').click();
			$('.simple-tree-table tr th:nth-child(4), .simple-tree-table tr th:nth-child(6), .simple-tree-table tr th:nth-child(8), .simple-tree-table tr th:nth-child(9), .simple-tree-table tr td:nth-child(4), .simple-tree-table tr td:nth-child(6), .simple-tree-table tr td:nth-child(8), .simple-tree-table tr td:nth-child(9)').addClass('toggleDisplay')
		})


	</script>--%>
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
                htmlcontent += '         <input type="text" class="form-control" placeholder="Vesting %">        ';
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

    <script>
        function isNumberKey(evt) {
            var charCode = (evt.which) ? evt.which : evt.keyCode;
            if (charCode != 46 && charCode > 31
			  && (charCode < 48 || charCode > 57))
                return false;

            return true;
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

		    //var selectedItemsCount = MasterTable.get_selectedItems().length;
		    //if (selectedItemsCount == 0) {
		    //    alert("Select at least one item!");
		    //    return false;
		    //}
		}
		//function WebForm_OnSubmit() {
		//    if (typeof (ValidatorOnSubmit) == "function" && ValidatorOnSubmit() == false) {
		//        for (var i in Page_Validators) {
		//            try {
		//                var control = document.getElementById(Page_Validators[i].controltovalidate);
		//                if (!Page_Validators[i].isvalid) {
		//                    control.className = "form-control";
		//                    control.style.border = '1px solid red';
		//                } else {
		//                    control.className = "form-control";
		//                    control.style.border = '1px solid #0b445d42';
		//                }
		//            } catch (e) { }
		//        }
		//        return false;
		//    }
		//    return true;
		//}

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
//function ValidatorUpdateDisplay(val) {
//    if (typeof (val.display) == "string") {
//        if (val.display == "None") {
//            return;
//        }
//        if (val.display == "Dynamic") {
//            val.style.display = val.isvalid ? "none" : "inline";
//            return;
//        }

//    }
//    val.style.visibility = val.isvalid ? "hidden" : "visible";
//    if (val.isvalid) {
//        document.getElementById(val.controltovalidate).style.border = '1px solid #DCDCDC';
//    }
//    else {
//        document.getElementById(val.controltovalidate).style.border = '1px solid LightSalmon';
//    }
//}
    </script>
    <script type="text/javascript">
        $(document).ready(function () {
            dropchange();
        });
        function dropchange() {
            ////var id = ddl.id;
            //var selectedVal = ddl.value;
            //// alert(selectedVal);
            var ddlFruits = document.getElementById("<%=ddlnoOfCycle1.ClientID %>");
		    //var selectedText = ddlFruits.options[ddlFruits.selectedIndex].innerHTML;
		    var selectedVal = ddlFruits.value;
		    //alert(selectedVal);
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

        function openModal() {
            $('#modalVesting').modal({ show: true });
        }


    </script>
    <script type="text/javascript">
        function showProgress1() {
            debugger;
            var updateProgress1 = $get("<%= UpdateProgress1.ClientID %>");
			updateProgress1.style.display = "block";
        }
    </script>
    <script type="text/javascript">
        function openModal2(srcval) {
            debugger;
            document.getElementById('<%=embed1.ClientID%>').src = "";
			document.getElementById('<%=embed1.ClientID%>').src = srcval;
		    $('#myModal1').modal('show');
		}
    </script>
</asp:Content>