<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="LoginRB.aspx.cs" Inherits="Report_Builder.LoginRB" %>

<!DOCTYPE html>
<html lang="en">
<head>
    <meta charset="utf-8">
    <meta name="viewport" content="width=device-width, initial-scale=1, shrink-to-fit=no">
    <title>Report Builder Application</title>
    <link rel="preconnect" href="https://fonts.gstatic.com">
    <link href="https://fonts.googleapis.com/css2?family=Montserrat:wght@300&family=Source+Sans+Pro&family=Squada+One&display=swap" rel="stylesheet">

    <link rel="stylesheet" href="https://stackpath.bootstrapcdn.com/bootstrap/4.5.0/css/bootstrap.min.css">
    <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/font-awesome/4.7.0/css/font-awesome.min.css">
    <link rel="stylesheet" href="Styles/style.css" type="text/css">
</head>
<body class="main">
    <div class="container mt-5">
        <div class="row">
            <div class="col-md-6 text-right mt-5 mb-5 logo_set" style="padding-right: 97px !important;">
                <img src="img/HDFC-Ergo.png">
            </div>
            <div class="col-md-6">
                <div class="modal-dialog modal-login">
                    <div class="modal-content">
                        <div class="modal-header">
                            <div class="avatar">
                                <img src="img/login.png" alt="">
                            </div>
                            <h4 class="modal-title"><b>Welcome to</b>
                                <br>
                                <span style="font-size: 30px;">Report Central Login</span></h4>
                        </div>
                        <div class="modal-body">
                            <form id="form1" runat="server">
                                <div class="form-group">
                                    <i class="fa fa-user"></i>
                                   <%-- <input type="text" class="form-control" placeholder="Username" required="required">--%>
                                     <asp:TextBox ID="txtUserid" runat="server" placeholder="Username" CssClass="form-control" required="required"></asp:TextBox>
                                </div>
                                <div class="form-group">
                                    <i class="fa fa-lock"></i>
                                  <%--  <input type="password" class="form-control" placeholder="Password" required="required">--%>
                                     <asp:TextBox ID="txtPassword" runat="server" placeholder="Password" CssClass="form-control" TextMode="Password" required="required"></asp:TextBox>
                                </div>
                                <div class="form-group">
                                    <i class="fa fa-desktop"></i>
                                    <asp:DropDownList ID="ddlSystem" runat="server" class="form-control">
                                        <asp:ListItem Value="Select">Select System</asp:ListItem>
                                        <asp:ListItem Value="1">PMS</asp:ListItem>
                                        <asp:ListItem Value="2">ESOP</asp:ListItem>
                                    </asp:DropDownList>
                                </div>
                                <div class="form-group">
                                    <%--<input type="submit" class="btn btn-primary btn-block btn-lg" value="Login">--%>
                                    <asp:Button ID="BtnSubmit" runat="server" Text="Login" OnClick="BtnSubmit_Click" class="btn btn-primary btn-block btn-lg"/>
                                </div>
                            </form>
                        </div>
                        <!--<div class="modal-footer">
				<a href="#">Forgot Password?</a>
			</div>-->
                    </div>
                </div>
            </div>
        </div>
    </div>
    <div>
    </div>
    <%--<script src="https://code.jquery.com/jquery-3.5.1.min.js"></script>
    <script src="https://stackpath.bootstrapcdn.com/bootstrap/4.5.0/js/bootstrap.min.js"></script>--%>
    <script src="js/jquery-3.5.1.min.js"></script>
    <script src="js/bootstrap-4.5.0.min.js"></script>
</body>
</html>
