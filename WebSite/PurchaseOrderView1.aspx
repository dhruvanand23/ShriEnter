<%@ Page Title="" Language="C#" MasterPageFile="~/AdminMasterPage.Master" AutoEventWireup="true" CodeFile="PurchaseOrderView1.aspx.cs" Inherits="WebSite.PurchaseOrderView1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <br />
    <br />
    <br />
    <hr />
    <h2><b>Purchase Order List View</b></h2>  
    <hr />

    <div class="panel panel-default" >
        <asp:Repeater ID="Repeater1" runat="server"></asp:Repeater>

        <ItemTemplate>

            <div class="divDet1">
                <h5 class="h5size"> Purchase Oder ID</h5>
                <p>   <%#Eval("PO_ID") %>          </p>                
                
            </div>
        </ItemTemplate>

    </div>

</asp:Content>
