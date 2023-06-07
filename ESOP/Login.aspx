<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="ESOP.Login" EnableEventValidation="true" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>ESOP</title>
    <!-- General CSS Files -->

    <link href="assets/css/app.min.css" rel="stylesheet" />
    <link rel="stylesheet" href="assets/bundles/bootstrap-social/bootstrap-social.css" />

    <link rel="stylesheet" href="assets/css/style.css" />
    <link rel="stylesheet" href="assets/css/components.css" />


    <link rel="stylesheet" href="Content/bootstrap-social.css" />
    <!-- Template CSS -->
    <link rel="stylesheet" href="Content/style.css" />
    <link rel="stylesheet" href="Content/components.css" />
    <!-- Custom style CSS -->

    <link rel='shortcut icon' type='image/x-icon' href='assets/img/favicon.ico' />
    <style>
        .card {
            width: 445px;
            background: #1e5c83c7;
            border: 2px solid #f2f2f259;
            padding-bottom: 35px;
        }

        .profile-widget .profile-widget-items {
            display: flex;
            position: relative;
            margin-top: 10px;
            left: 9%;
        }

        .profile-widget .profile-widget-picture {
            box-shadow: 0 4px 25px 0 rgba(0, 0, 0, .1);
            width: 100px;
            margin-top: -50px;
            display: block;
            z-index: 1;
            margin-bottom: 20px;
        }

        .offset-xl-3 {
            margin-left: 28%;
        }

        .login-brand {
            margin: 13px 5px 0px 142px;
            margin-bottom: 10px;
            font-size: 24px;
            text-transform: uppercase;
            letter-spacing: 4px;
            text-align: center;
        }

        .input-group {
            width: 80%;
        }

        .form-group.floating-addon {
            position: relative;
            left: 44px;
        }

        .profile-widget .profile-widget-items:after {
            content: ' ';
            position: absolute;
            bottom: 73px;
            left: 0;
            right: 77px;
            height: 1px;
            background-color: #27628a1f;
        }

        .fas {
            font-size: 13px;
            color: #195781;
        }

        .title {
            position: absolute;
            top: 28%;
            color: white;
            left: 34%;
        }

        .mt-5 {
            margin-top: 7rem !important;
        }

        h1 {
            font-size: 88px;
        }

        p.text-center.text-light {
            font-size: 33px;
            text-shadow: 2px 2px 2px #0a202b;
            color: white !important;
        }

        p.sub {
            line-height: 0px;
            color: #ffffff91;
            text-align: center;
            font-size: 23px;
        }

        .btn-auth-color {
            background: linear-gradient(180deg, #044b80ed 0, #000000ab 100%) !important;
        }

        h1 {
            text-shadow: 3px 2px 2px black;
        }

        img.mx-auto.d-block {
            width: 35%;
            position: absolute;
            top: 35%;
            right: 15%;
        }

        section.section {
            margin-bottom: 86px;
        }
    </style>
</head>
<body class="back">
    <form id="form1" runat="server">
        <div class="loader"></div>
        <div id="app">
            <section class="section">
                <div class="container mt-5">
                    <div class="row">
                        <div class="col-6" style="border-right: 2px solid #ffffff42;">
                            <img alt="image" src="assets/img/logo_hdfc.png" class="mx-auto d-block">
                        </div>

                        <div class="col-6">
                            <p class="text-center text-light">Welcome to ESOP Portal</p>
                            <div class="card-body">
                                <div class="card profile-widget">
                                    <div class="profile-widget-header">
                                        <div class="row">
                                            <div class="col-12">

                                                <img alt="image" src="assets/img/users/user-6.png" class="rounded-circle profile-widget-picture box-center">
                                            </div>
                                            <div class="col-12">
                                                <div class="">
                                                    <%--<form method="POST" action="#" novalidate="">--%>
                                                    <div class="form-group floating-addon">
                                                        <div class="input-group">
                                                            <div class="input-group-prepend">
                                                                <div class="input-group-text">
                                                                    <i class="fas fa-user-alt"></i>
                                                                </div>
                                                            </div>
                                                            <%--<input id="name" type="text" class="form-control" name="name" autofocus="" placeholder="Name" required>--%>
                                                            <asp:TextBox ID="txtUserid" runat="server" placeholder="User Name" CssClass="form-control"></asp:TextBox>
                                                        </div>
                                                    </div>

                                                    <div class="form-group floating-addon">
                                                        <div class="input-group">
                                                            <div class="input-group-prepend">
                                                                <div class="input-group-text">
                                                                    <i class="fas fa-lock"></i>
                                                                </div>
                                                            </div>
                                                            <%--<input id="password" type="password" class="form-control" name="name" autofocus="" placeholder="Password" required>--%>
                                                            <asp:TextBox ID="txtPassword" runat="server" placeholder="Password" CssClass="form-control" TextMode="Password"></asp:TextBox>
                                                        </div>
                                                    </div>

                                                    <div class="form-group text-center">
                                                        <%--<a class="btn btn-lg btn-auth-color" href="index.html" role="button">Login</a>--%>
                                                        <asp:Button ID="btnLogin" runat="server" Text="Login" CssClass="btn btn-lg btn-auth-color" OnClick="btnLogin_Click" />
                                                    </div>
                                                    <%--</form>--%>
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

    </form>
    <!-- General JS Scripts -->
    <!-- General JS Scripts -->
    <script src="assets/js/app.min.js"></script>
    <!-- JS Libraies -->
    <!-- Page Specific JS File -->
    <!-- Template JS File -->
    <script src="assets/js/scripts.js"></script>
</body>
</html>
