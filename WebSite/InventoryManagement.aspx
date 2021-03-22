<%@ Page Title="" Language="C#" MasterPageFile="~/AdminMasterPage.Master" AutoEventWireup="true" CodeFile="InventoryManagement.aspx.cs" Inherits="WebSite.InventoryManagement" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <br />
    <br />
    <br />

    <hr />
    <h2><b>Inventory Manager</b></h2>   
    <hr />
    
    Choose an Supplier: 
    <asp:DropDownList ID="ddlSupplier" runat="server" AutoPostBack="true" CssClass="form-control" OnSelectedIndexChanged="ddlSupplier_SelectedIndexChanged"></asp:DropDownList>

    Choose an Item: 
    <asp:DropDownList ID="ddlRawMaterial" runat="server" AutoPostBack="true" CssClass="form-control"></asp:DropDownList>

    <asp:Label ID="qtyDisplay" runat="server" Text="abc"></asp:Label>


    <br />
    <br />
    <hr />
</asp:Content>