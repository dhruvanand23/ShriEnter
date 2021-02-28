<%@ Page Title="" Language="C#" MasterPageFile="~/AdminMasterPage.Master" AutoEventWireup="true" CodeFile="PurchaseOrderView.aspx.cs" Inherits="WebSite.PurchaseOrderView" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <br />
    <br />
    <br />
    <hr />
    <h2><b>Purchase Order List View</b></h2>  
    <hr />
    <div class="panel panel-default" >
               
                            <asp:repeater ID="rptrPOView" runat="server" >

                            <HeaderTemplate>
                                 <table class="table" style="width:600px" >
                                      <thead>
                                        <tr>
                                            <th>POId</th>
                                            
                                            <th>Suplier Name</th>
                                            
                                            <th>Date</th>           
                                            <th>View</th>
                                            <th>Edit</th>
                                            <th>Delete</th>
                                            <th>Status</th>
                                        </tr>
                                    </thead>
                                <tbody>
                             </HeaderTemplate>

                             <ItemTemplate>             
                                 <tr>                               
                                     <td><%# Eval("PO_ID") %></td>
                                     
                                     <td><%# Eval("SupName") %></td>
                                     
                                     <td><%# Eval("PO_Date") %></td>
                                     <td>
                                         <asp:Button ID="btnView" runat="server" Text="View" OnClick="btnView_Click" />
                                     </td>
                                     <td>
                                         <asp:Button ID="btnUpdate" runat="server" Text="Edit" />
                                     </td>
                                     
                                     <td>
                                         <asp:Button ID="btnDelete" runat="server" Text="Delete" />
                                     </td>
                                      
                                     <td>
                                         <asp:Button ID="btnStatus" runat="server" Text="Status" />
                                     </td>
                                 </tr>

                             </ItemTemplate>


                             <FooterTemplate>
                                 </tbody>

                                  </table>
                             </FooterTemplate>

                         </asp:repeater>
                        </div>

</asp:Content>
