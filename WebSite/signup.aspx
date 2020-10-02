<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="signup.aspx.cs" Inherits="WebSite.signup" %>

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

             <div class="navbar navabar-default navbar-fixed-top" role="navigation">
                <div class"container">
                 <div class="navbar-header">
                    <button type="button" class="navbar-toggle" data-toggle="collapse" data-target=".navbar>
                        <span class="sr-only>Toggle Navigation</span>
                        <span class="icon-bar"></span>
                        <span class="icon-bar"></span>
                        <span class="icon-bar"></span>
                    </button>
                    <a class="navbar-brand" href="first.aspx"><span><img src="images/logo1.jpg" alt="Home Decor"width="80" height="80"/></span><h2>Home Decor</h2></a>
                 </div
                <div class="navbar-collapse collapse">
                    <ul class="nav navbar-nav navbar-right">
                        <li class="active"><a href="first.aspx">HOME</a></li>
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
                        <li ><a href="signup.aspx">REGISTRATION</a></li>
                        <li ><a href="#">LOGIN</a></li>
                    </ul>
                 </div>

               </div>

            </div>            

        </div>

        <!--signup page start here-->
        <div class="center-page">

            <label class="col-xs-11">First Name</label>
            <div class="col-xs-11">
                <asp:TextBox ID="f_name" runat="server" CssClass="form-control" placeholder="Enter First Name"></asp:TextBox>
            </div>

            <label class="col-xs-11">Last Name</label>
            <div class="col-xs-11">
                <asp:TextBox ID="l_name" runat="server" CssClass="form-control" placeholder="Enter last Name"></asp:TextBox>
            </div>

            <label class="col-xs-11">User Type</label>
            <div class="col-xs-11">
                <asp:TextBox ID="u_type" runat="server" CssClass="form-control" placeholder="Enter User Type"></asp:TextBox>
            </div>

            <label class="col-xs-11">Mobile</label>
            <div class="col-xs-11">
                <asp:TextBox ID="u_mob" runat="server" CssClass="form-control" placeholder="Enter Your Mobile Number"></asp:TextBox>
            </div>

            <label class="col-xs-11">Current Address</label>
            <div class="col-xs-11">
                <asp:TextBox ID="u_cadd" runat="server" CssClass="form-control" placeholder="Enter Your Current Address Here"></asp:TextBox>
            </div>

            <label class="col-xs-11">Email</label>
            <div class="col-xs-11">
                <asp:TextBox ID="u_mail" runat="server" CssClass="form-control" placeholder="Enter Your mail"></asp:TextBox>
            </div>

            <label class="col-xs-11">Password</label>
            <div class="col-xs-11">
                <asp:TextBox ID="u_pass" runat="server" CssClass="form-control" placeholder="Enter Your Password Here"></asp:TextBox>
            </div>

            <label class="col-xs-11">Confirm Password</label>
            <div class="col-xs-11">
                <asp:TextBox ID="u_cpass" runat="server" CssClass="form-control" placeholder="Re-Enter Your Password"></asp:TextBox>
            </div>

             <label class="col-xs-11"></label>
             <div class="col-xs-11">
                 <asp:Button ID="u_signup" CssClass="btn btn-success" runat="server" Text="SignUp" />
            </div>


        </div>
         <!--signup page End here-->

        <!--footer start here -->

        <footer class="footer-pos">

            <div class="container">
                <p class="pull-right"><a href="first.aspx">Back To Top</a></p>
                <p>&copy;HomeDecor.in &middot;<a href="first.aspx">Home</a> &middot;<a href="#">About</a> &middot;<a href="#">Contact Us</a> &middot;<a href="#">Products</a> </p>
            </div>


        </footer>


        <!--footer end here-->

    </form>
</body>
</html>
