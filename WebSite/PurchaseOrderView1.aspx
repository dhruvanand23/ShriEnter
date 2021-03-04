<%@ Page Title="" Language="C#" MasterPageFile="~/AdminMasterPage.Master" AutoEventWireup="true" CodeFile="PurchaseOrderView1.aspx.cs" Inherits="WebSite.PurchaseOrderView1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <br />
    <br />
    <br />
    <hr />
    <h2><b>Purchase Order Detail View</b></h2>  
    <hr />
    <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>

        <table style="border: 1px solid black;">
            <tr>                
                <td style ="width:1000px; margin:10px; border: 1px solid black;"><center><h1>Purchase Order</h1></center></td>                
                <td style ="width:300px; margin:10px; border: 1px solid black;">   
                    <table >
                        <tr><td>Date: <asp:Label ID="lblDate" runat="server" Text=""></asp:Label></td></tr>
                        <tr><td>POId: <asp:Label ID="lblPOId" runat="server" Text=""></asp:Label></td></tr>
                     </table>
                </td>                
            </tr>
        </table>
        <br />
         <table style="border: 1px solid black;">
            <tr>
                <td style ="width:750px; margin:10px; border: 1px solid black;">
                    <p><b>Shri Enterprises</b><br />
                    Shop No. 1&amp;2, Doke Building,<br />
                    Thergaon Bridge, Chinchwad,<br />
                    Pune- 411033<br />
                    9922910640/9922922541
                    </p>
                </td>
                            
                <td style ="width:750px; margin:10px; border: 1px solid black;">
                    <asp:Label ID="Label2" runat="server" Text="Supplier Information:" Font-Bold="True" Font-Italic="True" Font-Size="Medium"></asp:Label>
                    <p><b>
                        <asp:Label ID="lblSupName" runat="server" Text=""></asp:Label>
                       </b><br />
                        Address: <asp:Label ID="lblAddress" runat="server" Text=""></asp:Label><br />
                        Phone No.: <asp:Label ID="lblPhNo" runat="server" Text=""></asp:Label><br />
                        Email: <asp:Label ID="lblEmail" runat="server" Text=""></asp:Label><br />
                        GST No.: <asp:Label ID="lblGST" runat="server" Text=""></asp:Label>
                    </p>
                </td>
             </tr>
         </table>

</asp:Content>
