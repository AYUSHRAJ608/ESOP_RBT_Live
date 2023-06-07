<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="error.aspx.cs" Inherits="ESOP.error" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
     <meta charset="UTF-8">
  <meta content="width=device-width, initial-scale=1, maximum-scale=1, shrink-to-fit=no" name="viewport">
  <title>ESOP</title>
  <!-- General CSS Files -->
  <link rel="stylesheet" href="assets/css/app.min.css">
  <!-- Template CSS -->
  <link rel="stylesheet" href="assets/css/style.css">
  <link rel="stylesheet" href="assets/css/components.css">
  <!-- Custom style CSS -->
  
  <link rel='shortcut icon' type='image/x-icon' href='assets/img/favicon.ico' />
  <style>
    .btn-auth-color {
    background: linear-gradient(180deg, #3fd80c 0, #3d7d27 100%)!important;
}
  </style>
</head>
<body class="background-image-body">
  <div class="loader"></div>
  <div id="app">
    <section class="section">
      <div class="container mt-5">
        <div class="page-error">
          <div class="page-inner">
            <h1></h1>
            <div class="page-description">
              We apologise for the inconvenience. Something unexpected happened while performing your request. 
The page you've requested is not available at this moment.
            </div>
             

            <div class="page-search">
              <form>
                <div class="form-group floating-addon floating-addon-not-append">
                  <div class="input-group">
                    <div class="input-group-prepend">
                      
                    </div>
                  </div>
                </div>
              </form>
              <div class="mt-3 btn btn-auth-color btn-lg">
                <a href="javascript:history.go(-1)">Back to previous page</a>
              </div>
            </div>
          </div>
        </div>
      </div>
    </section>
  </div>
  <!-- General JS Scripts -->
  <script src="assets/js/app.min.js"></script>
  <!-- JS Libraies -->
  <!-- Page Specific JS File -->
  <!-- Template JS File -->
  <script src="assets/js/scripts.js"></script>
  
</body>
</html>
