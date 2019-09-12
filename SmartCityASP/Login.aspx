<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="SmartCityASP.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">

    <meta charset="utf-8" />
    <meta http-equiv="X-UA-Compatible" content="IE=edge" />
    <title>Log in | SCS</title>
    <!-- Tell the browser to be responsive to screen width -->
    <meta content="width=device-width, initial-scale=1, maximum-scale=1, user-scalable=no" name="viewport" />
    <!-- Bootstrap 3.3.6 -->
    <link rel="stylesheet" href="../bootstrap/css/bootstrap.min.css" />
    <!-- Font Awesome -->
    <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/font-awesome/4.5.0/css/font-awesome.min.css" />
    <!-- Ionicons -->
    <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/ionicons/2.0.1/css/ionicons.min.css" />
    <!-- Theme style -->
    <link rel="stylesheet" href="../dist/css/AdminLTE.min.css" />
    <!-- iCheck -->
    <link rel="stylesheet" href="../plugins/iCheck/square/blue.css" />

</head>
<body class="hold-transition login-page">
    <form id="form1" runat="server">
        <div>

            <div class="login-box">
                <div class="login-logo">
                    <a href="#"><b>SMARTCITY SHIRPUR</b></a>
                </div>
                <!-- /.login-logo -->
                <div class="login-box-body">
                    <p class="login-box-msg">Sign in to start your session</p>

                    <%--    <form action="../index2.html" method="post">--%>
                    <div class="form-group has-feedback">
                        <%--<input type="email" class="form-control" placeholder="Email"/>--%>
                        <asp:TextBox ID="txtUserName" class="form-control" runat="server" MaxLength="10" onkeypress="return numbersonly(this,event)" PlaceHolder="eg. 9156342132"></asp:TextBox>
                        <span class="glyphicon glyphicon-envelope form-control-feedback"></span>
                    </div>
                    <div class="form-group has-feedback">
                        <%--<input type="password" class="form-control" placeholder="Password"/>--%>
                        <asp:TextBox ID="txtPassword" class="form-control" runat="server" TextMode="Password" PlaceHolder="Password"></asp:TextBox>
                        <span class="glyphicon glyphicon-lock form-control-feedback"></span>
                    </div>
                    <div class="row">
                        <div class="col-xs-8">
                            <div class="checkbox icheck">
                                <label>
                                    <input type="checkbox" />
                                    Remember Me
           
                                </label>
                            </div>
                        </div>
                        <!-- /.col -->
                        <div class="col-xs-4">
                            <asp:Button ID="btnSubmit" runat="server" Text="Sign In" OnClick="btnSubmit_Click" class="btn btn-primary btn-block btn-flat" />
                        </div>
                        <!-- /.col -->
                    </div>
                    <%--</form>--%>

                    <%--<div class="social-auth-links text-center">
                        <p>- OR -</p>
                        <a href="#" class="btn btn-block btn-social btn-facebook btn-flat"><i class="fa fa-facebook"></i>Sign in using
        Facebook</a>
                        <a href="#" class="btn btn-block btn-social btn-google btn-flat"><i class="fa fa-google-plus"></i>Sign in using
        Google+</a>
                    </div>--%>
                    <!-- /.social-auth-links -->

                    <a href="#">I forgot my password</a><br />
                    <%--<a href="register.html" class="text-center">Register a new membership</a>--%>
                </div>
                <!-- /.login-box-body -->
            </div>
            <!-- /.login-box -->

            <!-- jQuery 2.2.3 -->
            <script src="../plugins/jQuery/jquery-2.2.3.min.js"></script>
            <!-- Bootstrap 3.3.6 -->
            <script src="../bootstrap/js/bootstrap.min.js"></script>
            <!-- iCheck -->
            <script src="../plugins/iCheck/icheck.min.js"></script>
            <script>
                $(function () {
                    $('input').iCheck({
                        checkboxClass: 'icheckbox_square-blue',
                        radioClass: 'iradio_square-blue',
                        increaseArea: '20%' // optional
                    });
                });

                function numbersonly(evt) {
                    var charCode = (evt.fwhich) ? evt.which : event.keyCode;
                    if (charCode != 46 && charCode > 31
                            && (charCode < 48 || charCode > 57))
                        return false;
                    return true;
                }
            </script>

        </div>
    </form>
</body>
</html>
