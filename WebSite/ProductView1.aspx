<%@ Page Title="" Language="C#" MasterPageFile="~/User.Master" AutoEventWireup="true" CodeFile="ProductView1.aspx.cs" Inherits="WebSite.ProductView1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <br />
    <br />

    <div style="padding-top:50px">
        <div class="col-md-5">
            <div style="max-width:480px" class="thumbnail">
             <%--   for proImage slider--%>
                <div id="carousel-example-generic" class="carousel slide" data-ride="carousel">
  <!-- Indicators -->
  <ol class="carousel-indicators">
    <li data-target="#carousel-example-generic" data-slide-to="0" class="active"></li>
    <li data-target="#carousel-example-generic" data-slide-to="1"></li>
    <li data-target="#carousel-example-generic" data-slide-to="2"></li>
      <li data-target="#carousel-example-generic" data-slide-to="3"></li>
      <li data-target="#carousel-example-generic" data-slide-to="4"></li>

  </ol>

  <!-- Wrapper for slides -->
  <div class="carousel-inner" role="listbox">

      <asp:repeater ID="rptrImage" runat="server">
          <ItemTemplate>
    <div class="item <%# GetActiveImgClass(Container.ItemIndex) %>">
      <img src="Images/ProductImages/<%# Eval("PID") %>/<%# Eval("Name") %><%# Eval("Extention") %>" alt="<%# Eval("Name") %>" onerror="this.src='Images/ImageNotAvailable.jpg'">
      
    </div>
             </ItemTemplate>
    </asp:repeater>


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

              <%--  for proimage slider ending--%>
            </div>
        </div>
        <div class="col-md-5">
            <asp:Repeater ID="rptrProductDetails" runat="server" OnItemDataBound="rptrProductDetails_ItemDataBound">
                <ItemTemplate>
            <div class="divDet1">
                 <h1 class="proNameView"><%# Eval("PName") %> </h1>
                <p class="proPriceView">Rs. <%#Eval("PSelPrice") %></p>
            </div>
           
            <div class="divDet1">
                <asp:button ID="btnAddtoCart" CssClass="mainButton" runat="server" text="ADD TO FAV" OnClick="btnAddtoCart_Click" />
                <asp:Label ID="lblError" CssClass ="text-danger " runat="server" ></asp:Label>
            </div>
            <div class="divDet1">
                <h5 class="h5size"> Description</h5>
                <p>   <%#Eval("PDescription") %>          </p>

                 <h5 class="h5size"> Product Details</h5>
                <p>   <%#Eval("PProductDetails") %>     </p>
                
            </div>
            
                    <asp:HiddenField ID="hfCatID" runat="server" Value='<%# Eval("PcategoryID") %>' />
                 

</ItemTemplate>
</asp:Repeater>

        </div>

    </div>

</asp:Content>

