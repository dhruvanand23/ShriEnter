<%@ Page Title="" Language="C#" MasterPageFile="~/AdminMasterPage.Master" AutoEventWireup="true" CodeBehind="AdminHome.aspx.cs" Inherits="WebSite.AdminHome" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <br />
    <br />
    <h2>Welcome Admin !...</h2>

    <div class="container ">

            

                <table style="width:1000px; margin:10px; border: 1px solid black;">
                    <tr style="border: 1px solid black;">
                        <td style="width:500px; border: 1px solid black;"><a href="AddCategory1.aspx">Add Category</a></td>
                        <td style="width:500px; border: 1px solid black;"><a href="AddProduct.aspx">Add Product</a></td>
                    </tr>
                    <tr style="border: 1px solid black;">
                        <td style="width:500px; border: 1px solid black;"><a href="QuotationDispaly.aspx">Quotation Request Display</a></td>
                        <td style="width:500px; border: 1px solid black;"></td>
                    </tr >
                    <tr style="border: 1px solid black;">
                        <td style="width:500px; border: 1px solid black;"><a href="Supplier.aspx">Add Supplier</a></td>
                        <td style="width:500px; border: 1px solid black;"><a href="RawMaterial.aspx">Add Raw Material</a> </td>
                    </tr>
                    <tr style="border: 1px solid black;">
                        <td style="width:500px; border: 1px solid black;"><a href="PurcharseOrder.aspx">Purchase Order</a></td>
                        <td style="width:500px; border: 1px solid black;"><a href="PurchaseOrderView.aspx">Purchase Order List</a></td>
                    </tr>
                    <tr style="border: 1px solid black;">
                        <td style="width:500px; border: 1px solid black;"><a href="SalesOrder.aspx">Sales Order</a></td>
                        <td style="width:500px; border: 1px solid black;"><a href="SalesOrderView.aspx">Sales Order List</a></td>
                    </tr>
                    

                </table>

            
       </div>
</asp:Content>