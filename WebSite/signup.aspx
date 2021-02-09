<%@ Page Language="C#" AutoEventWireup="true" CodeFile="signup.aspx.cs" Inherits="WebSite.signup" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>SignUp</title>
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
                    <a class="navbar-brand" href="first.aspx"><span><img src="images/logo.jpg" alt="Home Decor" height="35" width="250"/></span></a>
                </div>
                <div class="navbar-collapse collapse">
                    <ul class="nav navbar-nav navbar-right">
                        <li ><a href="first.aspx">HOME</a></li>
                        <li ><a href="#">ABOUT</a></li>
                        <li ><a href="#">CONTACT US</a></li>                        
                        <li >
                            <a href ="Products1.aspx" >Products</a>
                        </li>
                        <li class="active"><a href="signup.aspx">SignUp</a></li>
                        <li ><a href="signin.aspx">SignIn</a></li>
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
                    <h2>SignUp Form</h2>
                    <hr />

                    <div class="form-group">
                        <label class="col-xs-11">UserName:</label>
                        <div class="col-xs-11">
                        <asp:TextBox ID="txtUname" runat="server" Class="form-control" placeholder="Enter Your UserName"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtUname" ErrorMessage="User Name Required" Font-Italic="True" Font-Size="Medium" ForeColor="Red"></asp:RequiredFieldValidator>
                        </div>

                        <label class="col-xs-11">Password:</label>
                        <div class="col-xs-11">
                        <asp:TextBox ID="txtPass" runat="server" TextMode="Password" Class="form-control" placeholder="Enter Your password"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtPass" ErrorMessage="Password Required" Font-Italic="True" Font-Size="Medium" ForeColor="Red"></asp:RequiredFieldValidator>
                        </div>

                        <label class="col-xs-11">Confirm Password:</label>
                        <div class="col-xs-11">
                        <asp:TextBox ID="txtCPass" runat="server" TextMode="Password" Class="form-control" placeholder="Enter Your Confirm password"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtCPass" EnableViewState="False" ErrorMessage="Confirm Password Required" Font-Italic="True" Font-Size="Medium" ForeColor="Red"></asp:RequiredFieldValidator>
                            <asp:CompareValidator ID="CompareValidator1" runat="server" ControlToCompare="txtPass" ControlToValidate="txtCPass" ErrorMessage="Password does not match." Font-Italic="True" Font-Size="Medium" ForeColor="Red"></asp:CompareValidator>
                        </div>

                        <label class="col-xs-11">Your Address:</label>
                        <div class="col-xs-11">
                        <asp:TextBox ID="txtadd" runat="server" Class="form-control" placeholder="Enter Your Address"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="txtadd" EnableViewState="False" ErrorMessage="Address Required" Font-Italic="True" Font-Size="Medium" ForeColor="Red"></asp:RequiredFieldValidator>
                        </div>

                        <label class="col-xs-11">Your Mobile Number:</label>
                        <div class="col-xs-11">
                        <asp:TextBox ID="txtmob" runat="server" Class="form-control" placeholder="Enter Your Mobile Number"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="txtmob" ErrorMessage="Mobile Number Required" Font-Italic="True" Font-Size="Medium" ForeColor="Red"></asp:RequiredFieldValidator>
                        </div>

                        <label class="col-xs-11">Email:</label>
                        <div class="col-xs-11">
                        <asp:TextBox ID="txtEmail" runat="server" Class="form-control" placeholder="Enter Your Email"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ControlToValidate="txtEmail" ErrorMessage="Email ID Required" Font-Italic="True" Font-Size="Medium" ForeColor="Red"></asp:RequiredFieldValidator>
                            <br />
                            <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="txtEmail" ErrorMessage="Please enter a valid email." Font-Italic="True" Font-Size="Medium" ForeColor="Red" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:RegularExpressionValidator>
                        </div>

                        <label class="col-xs-11"></label>
                        <div class="col-xs-11">
                        <asp:Button ID="txtsignup" Class="btn btn-success" runat="server" Text="SignUP" OnClick="txtsignup_Click"/>
                        </div>

                    </div>
                </div>
            </div>

            <!--SignInEnd Here-->

             <!--footer start here -->
    
        <footer>

            <div class="container">
                <p class="pull-right"><a href="first.aspx">Back To Top</a></p>
                <p>&copy;ShriEnterprises.in &middot; <a href="first.aspx">Home</a> &middot;<a href="#">About</a> &middot;<a href="#">Contact Us</a> &middot;<a href="#">Products</a> </p>
            </div>


        </footer>


        <!--footer end here-->
    </form>
</body>
</html>
