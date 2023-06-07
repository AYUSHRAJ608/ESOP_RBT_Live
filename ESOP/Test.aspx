<div id="collapseOne" class="collapse show" aria-labelledby="headingOne" data-parent="#accordionExample">
    <div class="" style="padding: 15px 0 !important;">

        <div class="row">
            <div class="col-lg-3 col-md-12 col-sm-12">
                <div class="form-group">
                    <label>Name</label>
                    <%-- <input type="text" class="form-control userInput">--%>
                    <asp:textbox id="txtempname" runat="server" cssclass="form-control userInput" readonly="true" width="86%"></asp:textbox>

                </div>
            </div>
            <div class="col-lg-3 col-md-12 col-sm-12">
                <div class="form-group">
                    <label>Date of Joining</label>
                    <%--<input type="text" class="form-control userInput">--%>
                    <asp:textbox id="txtdoj" runat="server" cssclass="form-control userInput" readonly="true" width="86%"></asp:textbox>

                </div>
            </div>

            <div class="col-lg-3 col-md-12 col-sm-12">
                <div class="form-group">
                    <label>Designation</label>
                    <asp:dropdownlist cssclass="form-control" id="ddldesignation" runat="server" readonly="true" width="86%">
                                                                </asp:dropdownlist>
                </div>
            </div>


            <div class="col-lg-3 col-md-12 col-sm-12">
                <div class="form-group">
                    <label>Location</label>
                    <%--<input type="text" class="form-control userInput">--%>
                    <asp:textbox id="txtlocation" runat="server" cssclass="form-control userInput" readonly="true" width="86%"></asp:textbox>

                </div>
            </div>


            <div class="col-lg-3 col-md-12 col-sm-12">
                <div class="form-group">
                    <label>Employee Status</label>
                    <asp:dropdownlist cssclass="form-control" id="ddlempstatus" runat="server" readonly="true" width="86%">
                                                                    <asp:ListItem Value="0">Select</asp:ListItem>
                                                                    <asp:ListItem Value="1">Active</asp:ListItem>
                                                                    <asp:ListItem Value="2">Serving Notice</asp:ListItem>
                                                                    <asp:ListItem Value="3">Inactive</asp:ListItem>
                                                                    <asp:ListItem Value="4">Retired</asp:ListItem>
                                                                    <asp:ListItem Value="5">Deputed</asp:ListItem>

                                                                </asp:dropdownlist>

                </div>
            </div>
            <div class="col-lg-3 col-md-12 col-sm-12">
                <div class="form-group">
                    <label>Band </label>
                    <div class="input-group mb-3" style="width: 86%">


                        <asp:dropdownlist cssclass="form-control" id="ddlband" runat="server" readonly="true" width="86%">
                                                                    </asp:dropdownlist>
                    </div>
                </div>
            </div>
            <div class="col-lg-3 col-md-12 col-sm-12">
                <div class="form-group">
                    <label>Personal Email ID</label>
                    <%-- <input type="text" class="form-control userInput">--%>
                    <asp:textbox id="txtemailid" runat="server" cssclass="form-control userInput" readonly="true" width="86%"></asp:textbox>

                </div>
            </div>
            <div class="col-lg-3 col-md-12 col-sm-12">
                <div class="form-group">
                    <label>Manager Name</label>

                    <asp:textbox id="txtmanagername" runat="server" cssclass="form-control userInput" readonly="true" width="86%"></asp:textbox>

                </div>
            </div>
            <div class="col-lg-3 col-md-12 col-sm-12">
                <div class="form-group">
                    <label>Pan Card Number</label>

                    <asp:textbox id="txtpanno" runat="server" cssclass="form-control userInput" readonly="true" width="86%"></asp:textbox>

                </div>
            </div>
            <div class="col-lg-3 col-md-12 col-sm-12">
                <div class="form-group" style="width: 86%">
                    <label>Pan Card</label>
                    <cc1:asyncfileupload runat="server" id="filepancard" uploaderstyle="Traditional" completebackcolor="White" width="86%"
                        uploadingbackcolor="#CCFFFF" throbberid="imgLoader" onuploadedcomplete="filepancard_UploadedComplete" cssclass="form-control"
                        errorbackcolor="Transparent" onclientuploadcomplete="uploadComplete1" onclientuploadstarted="uploadStart1"></cc1:asyncfileupload>

                </div>
            </div>
            <div class="col-lg-3 col-md-12 col-sm-12">
                <div class="letterview" style="width: 130px; margin-top: 75px;">
                    <div runat="server" id="divletter1">
                        <figure class="snip0014" style="margin-top: 8px; height: 113px !important;">
                            <img id="imgDisplay1" alt="No Image Found" />
                            <a href="#" dowmload>
                                <asp:updatepanel id="Updatepanel2" runat="server">
                                                                                <ContentTemplate>
                                                                                    <asp:LinkButton ID="lnkpandownload" runat="server" Text="Download" OnClick="lnkpandownload_Click">
                                                                <p><i class="fas fa-download"></i>Pan Card</p>
                                                                                    </asp:LinkButton>
                                                                                </ContentTemplate>
                                                                                <Triggers>
                                                                                    <asp:PostBackTrigger ControlID="lnkpandownload" />
                                                                                </Triggers>
                                                                            </asp:updatepanel>
                            </a>
                        </figure>
                    </div>

                </div>
            </div>
            <div class="col-lg-3 col-md-12 col-sm-12">
                <div class="form-group" style="margin-left: -103%; width: 86%;">
                    <label>Profile</label>
                    <cc1:asyncfileupload runat="server" id="fileempprofileimg" width="86%" uploaderstyle="Traditional" completebackcolor="White"
                        uploadingbackcolor="#CCFFFF" throbberid="imgLoader" onuploadedcomplete="fileempprofileimg_UploadedComplete" cssclass="form-control"
                        onclientuploadcomplete="uploadComplete" onclientuploadstarted="uploadStart"
                        errorbackcolor="Transparent"></cc1:asyncfileupload>

                </div>
            </div>
            <!-- <style>
                                                            .letterview {
                                                            Profile    margin-left: -104%;
                                                            }
                                                        </style>-->
            <div class="col-lg-3 col-md-12 col-sm-12" style="margin-left: 3%">
                <div class="letterview" style="width: 130px; margin-top: -43%; margin-left: 201%;">
                    <div runat="server" id="divletter">
                        <figure class="snip0014" id="snip0014" style="margin-top: 0px;">
                            <img src="" id="imgDisplay" alt="No Image Found" />
                            <a href="#" dowmload>
                                <asp:updatepanel id="Updatepanel21" runat="server">
                                                                                <ContentTemplate>
                                                                                    <asp:LinkButton ID="lnkprofileDownload" runat="server" Text="Download" OnClick="lnkprofileDownload_Click">
                                                                <p><i class="fas fa-download"></i>Profile Picture</p>
                                                                                    </asp:LinkButton>
                                                                                </ContentTemplate>
                                                                                <Triggers>
                                                                                    <asp:PostBackTrigger ControlID="lnkprofileDownload" />

                                                                                </Triggers>
                                                                            </asp:updatepanel>

                            </a>
                        </figure>
                    </div>

                </div>
            </div>
            <div class="col-lg-3 col-md-12 col-sm-12">

                <asp:updatepanel id="Updatepanel3" runat="server">
                                                                <ContentTemplate>
                                                                    <asp:Button ID="saveempdetails" OnClick="saveempdetails_Click" Text="Save"
                                                                        runat="server" CssClass="btn btn-info btn-lg" OnClientClick="return ReqValidation3()"></asp:Button>
                                                                </ContentTemplate>
                                                                <Triggers>
                                                                    <asp:PostBackTrigger ControlID="saveempdetails" />
                                                                </Triggers>
                                                            </asp:updatepanel>
            </div>
        </div>
    </div>
    <div class="col-lg-3 offset-md-6 mb-3">
    </div>
</div>
