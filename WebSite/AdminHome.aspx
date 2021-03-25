<%@ Page Title="" Language="C#" MasterPageFile="~/AdminMasterPage.Master" AutoEventWireup="true" CodeBehind="AdminHome.aspx.cs" Inherits="WebSite.AdminHome" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <br />
    <br />
    <br />
    <h2>Welcome Admin !...</h2>
    <hr />

    <br />

    <div class="container ">

            

                <table style="width:1000px; margin:10px;" class="table">
                    <tr >
                        <td style="width:500px; "><a href="AddCategory1.aspx"><Center>Add Category</Center></a></td>
                        <td style="width:500px; "><a href="AddProduct.aspx"><Center>Add Product</Center></a></td>
                    </tr>
                    <tr >
                        <td style="width:500px; "><a href="QuotationDispaly.aspx"><center>Quotation Request Display</center></a></td>
                        <td style="width:500px; "><a href="#"><center>Add Employee</center></a></td>
                    </tr >
                    <tr >
                        <td style="width:500px;" ><a href="Supplier.aspx"><center>Add Supplier</center></a></td>
                        <td style="width:500px;" ><a href="RawMaterial.aspx"><center>Add Raw Material</center></a> </td>
                    </tr>
                    <tr >
                        <td style="width:500px; "><a href="PurcharseOrder.aspx"><center>Purchase Order</center></a></td>
                        <td style="width:500px;" ><a href="PurchaseOrderView.aspx"><center>Purchase Order List</center></a></td>
                    </tr>
                    <tr >
                        <td style="width:500px; "><a href="SalesOrder.aspx"><center>Sales Order</center></a></td>
                        <td style="width:500px; "><a href="SalesOrderView.aspx"><center>Sales Order List</center></a></td>
                    </tr>
                    <tr >
                        <td style="width:500px; "><a href="InventoryManagement.aspx"><center>Inventory Manager</center></a></td>
                        <td style="width:500px; "><a href="#"><center>Payment Information</center></a></td>
                    </tr>
                    <tr></tr>

                </table>

        <br />
        <br />
       </div>
</asp:Content>