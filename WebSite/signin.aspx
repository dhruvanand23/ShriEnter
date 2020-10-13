<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="signin.aspx.cs" Inherits="WebSite.signin" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>SignIn</title>

    <meta charset="utf-8">
    <meta name="viewport" content="width=device-width,initial-scale=1">
    <meta http-equiv="X-UA-Compatible" content="IE-edge">

    <link href="css/custom.css" rel="stylesheet" />

    <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/3.4.1/css/bootstrap.min.css">
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.5.1/jquery.min.js"></script>
    <script src="https://maxcdn.bootstrapcdn.com/bootstrap/3.4.1/js/bootstrap.min.js"></script>

</head>
<body>
    <form id="form1" runat="server">        
        <div>
        <div class ="navbar navbar-default navbar-fixed-top" role ="navigation">
            <div class ="container ">
                <div class ="navbar-header">
                    <button type="button" class ="navbar-toggle " data-toggle="collapse" data-target=".navbar-collapse">
                        <span class="sr-only>Toggle Navigation</span>
                        <span class="icon-bar"></span>
                        <span class="icon-bar"></span>
                        <span class="icon-bar"></span>

                    </button>
                    <a class="navbar-brand" href="first.aspx"><span><img src="images/logo1.png" alt="Home Decor" height="30"/>Home Decor</span></a>
                </div>
                <div class="navbar-collapse collapse">
                    <ul class="nav navbar-nav navbar-right">
                        <li ><a href="first.aspx">HOME</a></li>
                        <li ><a href="#">ABOUT</a></li>
                        <li ><a href="#">CONTACT US</a></li>
                        <li ><a href="#">BLOG</a></li>
                        <li class ="drodown">
                            <a href ="#" class ="dropdown-toggle" data-toggle="dropdown">Products<b class ="caret"></b></a>
                            <ul class ="dropdown-menu ">
                                <li class ="dropdown-header ">Item1</li>
                                <li role="separator" class ="divider "></li> 
                                <li> <a href ="#">Subitem1</a></li>
                                <li> <a href ="#">Subitem2</a></li>
                                <li> <a href ="#">Subitem3</a></li>
                                <li role="separator" class ="divider "></li>
                                <li class ="dropdown-header ">Item2</li>
                                <li role="separator" class ="divider "></li>
                                <li> <a href ="#">Subitem4</a></li>
                                <li> <a href ="#">Subitem5</a></li>
                                <li> <a href ="#">Subitem6</a></li>
                            </ul>

                        </li>
                        <li ><a href="signup.aspx">SignUp</a></li>
                        <li class="active" ><a href="signin.aspx">SignIn</a></li>
                    </ul>
                </div>
            </div>
        </div>
        </div>

            <!--SignIn start-->
            <div class="container">
                <div class="form-horizontal">
                    <hr />
                    <hr />
                    <h2>SignIn Form</h2>
                    <hr />
                    <div class="form-group">
                        <label class="col-xs-11">UserName:</label>                        
                        <div class="col-xs-11">
                            <asp:TextBox ID="txtUname" runat="server" Class="form-control" placeholder="Enter Your UserName"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtUname" ErrorMessage="UserName Required" Font-Italic="True" Font-Size="Medium" ForeColor="Red"></asp:RequiredFieldValidator>
                        </div>
                       
                        <label class="col-xs-11">Password:</label>
                        <div class="col-xs-11">
                            <asp:TextBox ID="txtPass" runat="server" TextMode="Password" Class="form-control" placeholder="Enter Your password"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtPass" ErrorMessage="Password Required" Font-Italic="True" Font-Size="Medium" ForeColor="Red"></asp:RequiredFieldValidator>
                        </div>
                        
                        
                        <label class="col-xs-11"><asp:CheckBox ID="CheckBox1" runat="server"/>&nbsp;&nbsp;Remember Me<asp:Label ID="Label1" runat="server"></asp:Label>
                        </label>
                        &nbsp;&nbsp;<div class="col-xs-11">
                        </div>
                        
                        <div>
                            <div class="col-xs-11">
                                <asp:Button ID="btnlogin" cssclass="btn btn-success" runat="server" Text="SignIn" OnClick="btnlogin_Click" />&raquo;
                                <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="~/signup.aspx">Sign Up</asp:HyperLink>
                            </div>
                        </div>                        
                        
                        <!--forrgot password-->
                        <div>
                            <div class="col-xs-11">
                                <asp:HyperLink ID="HyForgotPassword" runat="server" NavigateUrl="~/ForgorPassword.aspx">Forgot Password</asp:HyperLink>
                            </div>
                        </div>

                        <div>
                            <div class="col-xs-11">
                                <asp:Label ID="lblError" CssClass="txt-danger" runat="server" ></asp:Label>
                            </div>
                        </div>
                       
                    </div>
                </div>
            </div>

            <!--SignInEnd Here-->

         <!--footer start here -->

        <footer>

            <div class="container">
                <p class="pull-right"><a href="first.aspx">Back To Top</a></p>
                <p>&copy;HomeDecor.in &middot; <a href="first.aspx">Home</a> &middot;<a href="#">About</a> &middot;<a href="#">Contact Us</a> &middot;<a href="#">Products</a> </p>
            </div>


        </footer>


        <!--footer end here-->
    </form>

</body>
</html>
