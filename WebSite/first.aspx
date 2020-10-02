<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="first.aspx.cs" Inherits="WebSite.first" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Home Decor</title>
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
                        <li ><a href="signup.aspx">REGISTRATION</a></li>
                        <li ><a href="#">LOGIN</a></li>
                    </ul>
                </div>

            </div>

        </div> 
        <!--image slider-->

        <div class="container"> 
            <div id="myCarousel" class="carousel slide" data-ride="carousel">
             <!-- Indicators -->
            <ol class="carousel-indicators">
                 <li data-target="#myCarousel" data-slide-to="0" class="active"></li>
                 <li data-target="#myCarousel" data-slide-to="1"></li>
                 <li data-target="#myCarousel" data-slide-to="2"></li>
           </ol>

             <!-- Wrapper for slides -->
        <div class="carousel-inner">

            <div class="item active">
                <img src="imageslider/home1.jpg" alt="Los Angeles" style="width:100%; height:700px;">
                <div class="carousel-caption">
                     <h3>Your Product Shopping </h3>
                     <p>explore what You Need </p>
                     <p><a class="btn btn-lg btn-primary" href="#" role="button"> Buy Now </a> </p>
                </div>
            </div>

            <div class="item">
                <img src="imageslider/home2.jpg" alt="Chicago" style="width:100%; height:700px;">
                     <div class="carousel-caption">
                        <h3>Designs </h3>
                        <p>Many More</p>
                    </div>
            </div>
           
    
            <div class="item">
                <img src="imageslider/home3.jpg" alt="New york" style="width:100%; height:700px;">
                 <div class="carousel-caption">
                       <h3>Beautiful World</h3>
                       <p>Started here</p>
                 </div>
            </div>
         </div>

        <!-- Left and right controls -->
            <a class="left carousel-control" href="#myCarousel" data-slide="prev">
                <span class="glyphicon glyphicon-chevron-left"></span>
                <span class="sr-only">Previous</span>
            </a>
            <a class="right carousel-control" href="#myCarousel" data-slide="next">
                <span class="glyphicon glyphicon-chevron-right"></span>
                <span class="sr-only">Next</span>
            </a>
           </div>
        </div>        
        <!--image slider End-->       
          
    </div>
        <br />
        <br />

        <!--middle content start--> 

        <div class="container center">
            <div class="row">
                <div class="col-lg-4">
                    <img class="img-circle" src="images/wall hanging1.jpg" alt="thumb" width="140" height="140" />
                    <h2>Wall Hangings</h2>
                    <p>Designs For better look.
                        Craftter Iron Floating Wall Hanging Sculpture Frame and Center Piece Metal Art (30.5 X 41.5 X 1 Inch, Multicolored Antique Contemporary Framed)
                        Handmade ( Made in India )
                    </p>
                    
                    <p><a class="btn btn-default" href="#" role="button">View More &raquo;</a></p>
                </div>

                <div class="col-lg-4">
                    <img class="img-circle" src="images/mirror1.jpg" alt="thumb" width="140" height="140" />
                    <h2>Mirrors</h2>
                    <p>Home Centre Cheval Standing Mirror (Rich Brown) (20 * 20 * 60 Inches)
                        Product Dimensions : Length ( 53 cm), Width (53 cm), Height (153 cm)
                        Primary Material : Compressed Wood
                        Warranty: 1 year on productAssembly seller
                    </p>
                    
                    <p><a class="btn btn-default" href="#" role="button">View More &raquo;</a></p>
                </div>

                <div class="col-lg-4">
                    <img class="img-circle" src="images/painting1.jpg" alt="thumb" width="140" height="140" />
                    <h2>Paintings</h2>
                    <p>Kyara arts Multiple Frames, Beautiful red Buddha Wall Painting for Living Room, Bedroom, Office, Hotels,
                        Drawing Room Wooden Framed Digital Painting (50inch x 30inch)
                        A perfect gift for your relative and friends.
                    </p>
                    
                    <p><a class="btn btn-default" href="#" role="button">View More &raquo;</a></p>
                </div>

            </div>


        </div>

        <!--middle content End-->
        
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
