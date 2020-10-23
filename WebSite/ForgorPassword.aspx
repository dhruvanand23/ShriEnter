<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ForgorPassword.aspx.cs" Inherits="WebSite.ForgorPassword" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Forgot Password</title>
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
                    <a class="navbar-brand" href="first.aspx"><span><img src="images/logo1.png" alt="Home Decor" height="30"/>Space Decor</span></a>
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
                                                
                        <li><a href="signin.aspx">SignIn</a></li>
                    </ul>
                </div>
            </div>
        </div>      

        </div>

        <div class="Container" >
            <div class="form-horizontal">   
                <br /><br />
                <h2>Recover Password</h2>
                <hr />                   
                <h3>Please Enter Email Address</h3>                   
                <div class="form-group">
                    <label class="col-xs-11">Enter your Email ID:</label>
                        <div class="col-xs-11">
                        <asp:TextBox ID="txtEmailID" runat="server" Class="form-control" ></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtEmailID" ErrorMessage="Email ID Required" Font-Italic="True" Font-Size="Medium" ForeColor="Red"></asp:RequiredFieldValidator>
                        </div>
                    <label class="col-xs-11">New Password:</label>
                        <div class="col-xs-11">
                        <asp:TextBox ID="txtPassFP" runat="server" Class="form-control" ></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtPassFP" ErrorMessage="Password Required" Font-Italic="True" Font-Size="Medium" ForeColor="Red"></asp:RequiredFieldValidator>
                        </div>
                    <label class="col-xs-11">Confirm New Password:</label>
                        <div class="col-xs-11">
                        <asp:TextBox ID="txtConPassFP" runat="server" Class="form-control" ></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="txtConPassFP" ErrorMessage="Confirm Password Required" Font-Italic="True" Font-Size="Medium" ForeColor="Red"></asp:RequiredFieldValidator>
                        </div>
                </div>

                <div class="form-group">
                    <div class="col-md-2">
                    </div>
                    <div class="col-md-6">
                        <asp:Button ID="btnResetPass" CssClass="btn btn-default" runat="server" Text="Update" OnClick="btnResetPass_Click" />
                        <asp:Label ID="lblResetPassMsg" CssClass="txt-success" runat="server" ></asp:Label>
                    </div>
                </div>

            </div>
        </div>

    </form>
     <!--footer start here -->

        <footer>

            <div class="container">
                <p class="pull-right"><a href="first.aspx">Back To Top</a></p>
                <p>&copy;SpaceDecor.in &middot; <a href="first.aspx">Home</a> &middot;<a href="#">About</a> &middot;<a href="#">Contact Us</a> &middot;<a href="#">Products</a> </p>
            </div>


        </footer>


     <!--footer end here-->
</body>
</html>
