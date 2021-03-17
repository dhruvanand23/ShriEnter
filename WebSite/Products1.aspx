﻿<%@ Page Title="" Language="C#" MasterPageFile="~/User.Master" AutoEventWireup="true" CodeFile="Products1.aspx.cs" Inherits="WebSite.Products1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <br />  


    <div class="row" style="padding-top:50px">
       <asp:repeater ID="rptrProducts" runat="server">
           <ItemTemplate>
        <div class="col-sm-3 col-md-3">
            <a href="ProductView1.aspx?PID=<%# Eval("PID") %>" style="text-decoration:none;">
          <div class="thumbnail">              
              <img src="Images/ProductImages/<%# Eval("PID") %>/<%# Eval("ImageName") %><%# Eval("Extention") %>" alt="<%# Eval("ImageName") %>"/>
              <div class="caption"> 
                   
                   <div class="proName"> <%# Eval ("PName") %> </div>
                   <div class="proPrice">  <%# Eval ("PSelPrice") %> </div> 
                   
              </div>
          </div>
        </div>
               </a>
               </ItemTemplate>
       </asp:repeater>
    </div>



    <%--second product--%>

</asp:Content>
