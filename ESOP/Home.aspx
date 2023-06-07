<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Home.aspx.cs" Inherits="ESOP.Test" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div class="">
            <h4>This is Home page.</h4>
            <ul class="nav navbar-nav">
                <li><a runat="server" href="~/Home">Home</a></li>
                <li><a runat="server" href="~/About">About</a></li>
                <li><a runat="server" href="~/Contact">Contact</a></li>

            </ul>
        </div>
        <div>
            <asp:Button ID="btnEmail" runat="server" class="btn btn_p" Text="Email" OnClick="btnEmail_Click" />
        </div>
    </form>
</body>
</html>
