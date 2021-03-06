<%@ Page Title="" Language="C#" MasterPageFile="~/AdminMasterPage.Master" AutoEventWireup="true" CodeFile="SalesOrderView1.aspx.cs" Inherits="WebSite.SalesOrderView1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <br />
    <br />
    <br />
    <hr />
    <h2><b>Sales Order Detail View</b></h2>  
    <hr />

        <table style="border: 1px solid black;">
            <tr>                
                <td style ="width:1000px; margin:10px; border: 1px solid black;"><center><h1>Sales Order</h1></center></td>                
                <td style ="width:300px; margin:10px; border: 1px solid black;">   
                    <table >
                        <tr><td style="height: 20px">Date: <asp:Label ID="lblDate" runat="server" Text=""></asp:Label></td></tr>
                        <tr><td>SOId: <asp:Label ID="lblSOId" runat="server" Text=""></asp:Label></td></tr>
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
                        <asp:Label ID="lblCustName" runat="server" Text=""></asp:Label>
                       </b><br />
                        Address: <asp:Label ID="lblAddress" runat="server" Text=""></asp:Label><br />
                        Phone No.: <asp:Label ID="lblPhNo" runat="server" Text=""></asp:Label><br />
                        Email: <asp:Label ID="lblEmail" runat="server" Text=""></asp:Label><br />
                        GST No.: <asp:Label ID="lblGST" runat="server" Text=""></asp:Label>
                    </p>
                </td>
             </tr>
         </table>

        <br />

        <div class="panel panel-default" >
               
                            <asp:repeater ID="rptrSODetails" runat="server" >

                            <HeaderTemplate>
                                 <table class="table"  >
                                      <thead>
                                        <tr>
                                            
                                                                                        
                                            <th>Product ID</th>
                                            <th>Name</th>
                                            <th>Quantity</th>
                                            <th>Price</th>
                                            <th>Total</th>
                                                                                        
                                            
                                        </tr>
                                    </thead>
                                <tbody>
                             </HeaderTemplate>

                             <ItemTemplate>             
                                 <tr> 
                                        <td><%# Eval("PID") %></td>
                                        <td><%# Eval("PName") %></td>
                                        <td><%# Eval("SOItem_Quantity") %>   </td>
                                        <td><%# Eval("SOItem_Price") %>   </td>
                                        <td><%# Eval("Total") %></td>   
                                     
                                 </tr>

                             </ItemTemplate>


                             <FooterTemplate>
                                 </tbody>

                                  </table>
                             </FooterTemplate>

                         </asp:repeater>

                        </div>

    <table style="border: 1px solid black;">
        <tr><td style ="text-align:right; margin:10px; width: 1300px"><b>Grand Total: <asp:Label ID="lblGTotal" runat="server" Text=""></asp:Label></b></td></tr>
    </table>

    <br />
    <br />

</asp:Content>
