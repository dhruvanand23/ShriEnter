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
    <br />
    Choose an Item: 
    <asp:DropDownList ID="ddlRawMaterial" runat="server" AutoPostBack="true" CssClass="form-control"></asp:DropDownList>
    <br />
    <br />

    <center>
        <asp:Label ID="Label1" runat="server" Text="Quantity In Stock:"></asp:Label>
        <asp:Label ID="qtyDisplay" runat="server" Text="98" Font-Size="XX-Large" ForeColor="#0033CC" Font-Bold="True"></asp:Label>
    </center>
    
    <br />
    <br />
    <table style="width:1140px">
        <tr> 
            <td>
                Edit Quantity:
            </td>
            <td>
                <asp:TextBox ID="quantity" runat="server" Class="form-control"></asp:TextBox><br />
            </td>
        </tr>
        <tr>
            <td>
                Date:
            </td>
            <td>
                <asp:TextBox ID="date" runat="server" textmode="Date" Class="form-control"></asp:TextBox><br />
            </td>
        </tr>
        <tr>
            <td>
                
            </td>
            <td>
                <center>
                    <asp:Button ID="btnEditQty" runat="server" Text="Edit Quantity" />
                </center>
            </td>
        </tr>
    </table>
    
    <br />
    <br />
    <hr />
</asp:Content>