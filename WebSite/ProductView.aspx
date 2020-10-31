<%@ Page Title="" Language="C#" MasterPageFile="~/User.Master" AutoEventWireup="true" CodeFile="ProductView.aspx.cs" Inherits="WebSite.ProductView" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <br />
    <br />

    <div style="padding-top:50px">
        <div class="col-md-5">
            <div style="max-width:480px" class="thumbnail">
                <img src="images/mirror2.jpg" />
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
