<%@ Page Title="" Language="C#" MasterPageFile="~/User.Master" AutoEventWireup="true" CodeFile="ProductView.aspx.cs" Inherits="WebSite.ProductView" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <br />
    <br />

    <div style="padding-top:50px">
        <div class="col-md-5">
            <div style="max-width:480px" class="thumbnail">
                <!---For ProImage slider--->
                <div id="carousel-example-generic" class="carousel slide" data-ride="carousel">
  <!-- Indicators -->
  <ol class="carousel-indicators">
    <li data-target="#carousel-example-generic" data-slide-to="0" class="active"></li>
    <li data-target="#carousel-example-generic" data-slide-to="1"></li>
    <li data-target="#carousel-example-generic" data-slide-to="2"></li>
  </ol>

  <!-- Wrapper for slides -->
  <div class="carousel-inner" role="listbox">
      <asp:Repeater ID="rptrImage" runat="server">
          <ItemTemplate>
          <div class="item active">
              <img src="images/ProductImages/home2.jpg" alt="..." >
              <div class="carousel-caption">
                  01
              </div>
          </div>
          </ItemTemplate>
      </asp:Repeater>

  </div>

  <!-- Controls -->
  <a class="left carousel-control" href="#carousel-example-generic" role="button" data-slide="prev">
    <span class="glyphicon glyphicon-chevron-left" aria-hidden="true"></span>
    <span class="sr-only">Previous</span>
  </a>
  <a class="right carousel-control" href="#carousel-example-generic" role="button" data-slide="next">
    <span class="glyphicon glyphicon-chevron-right" aria-hidden="true"></span>
    <span class="sr-only">Next</span>
  </a>
</div>

                <!---For ProImage slider End Here--->
            </div>
        </div>
        <div class="col-md-5">
            <div class="divDet1">
                 <h1 class="proNameView">Furnish Craft Steel Glass wall Mirror</h1>
                <span class="proOgPriceView">Rs. 3200</span>
                <span class="proPriceDiscountView"> (200 OFF)</span>
                <p class="proPriceView"> Rs.3000</p>
            </div>
            
            <div class="divDet1">
                <asp:button ID="btnAddtoCart" CssClass="mainButton" runat="server" text="ADD TO CART" />
            </div>
            <div class="divDet1">
                <h5 class="h5size"> Description</h5>
                <p>Beautiful design,
                    The design is eye-catching and you will completely fall in love with this
                    trendy decorative wall mirror
                </p>
                <h5 class="h5size"> Product Details</h5>
                <p> 
                    Easy to installation and Clean. Waterproof and Long Durable Finish
                </p>                 
                <p>
                    Material : Glass / Mild Steel,Color : Golden
                </p>
            </div>
            <div >
                <p>Free Delivery    </p>
                <p>30 Days Returns</p>
                <p>Cash on Delivery</p>
            </div>

        </div>

    </div>
</asp:Content>
