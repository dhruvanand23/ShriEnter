<%@ Page Title="" Language="C#" MasterPageFile="~/AdminMasterPage.Master" AutoEventWireup="true" CodeFile="QuotationDispaly.aspx.cs" Inherits="WebSite.QuotationDispaly" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class ="container ">
            <div class ="form-horizontal ">
                <br />
                <br />

                <h2>Quotation Requested</h2>
                <hr />                
                </div>

       </div>  
            <asp:Label ID="Label1" runat="server" Text="Home Interior Quotation" Font-Size="Larger" Font-Bold="True"></asp:Label>
        <hr />

        <div class="panel panel-default">
               
        <asp:repeater ID="rptrQuoteHome" runat="server">

        <HeaderTemplate>
             <table class="table">
                  <thead>
                    <tr>
                        
                        <th>Quotation ID</th>
                        <th>Client Name</th>  
                        <th>Mobile Number</th>  
                        <th>Bed Room</th>
                        <th>Living Room</th>
                        <th>Kitchen</th>
                        <th>WholeHouse</th>
                        <th>Others</th> 
                        
                    </tr>
                </thead>
            <tbody>
         </HeaderTemplate>

         <ItemTemplate>             
             <tr>
                    <th><%# Eval("QHomeID") %> </th>
                    <td><%# Eval("Name") %></td>
                    <td><%# Eval("mobile") %></td>
                    <td><%# Eval("BedRoom") %>   </td>
                    <td><%# Eval("LivingRoom") %></td>
                    <td><%# Eval("Kitchen") %></td>
                    <td><%# Eval("WholeHouse") %></td>
                    <td><%# Eval("Others") %></td>
                    
                    
                </tr>

         </ItemTemplate>


         <FooterTemplate>
             </tbody>

              </table>
         </FooterTemplate>

     </asp:repeater>
    </div>

    <hr />
     <asp:Label ID="Label2" runat="server" Text="Commercial Quotation" Font-Size="Larger" Font-Bold="True"></asp:Label>
        <hr />

        <div class="panel panel-default">
               
        <asp:repeater ID="rptrCommQuote" runat="server">

        <HeaderTemplate>
             <table class="table">
                  <thead>
                    <tr>
                        
                        <th>Quotation ID</th>
                        <th>Client Name</th>  
                        <th>Mobile Number</th>  
                        <th>Office</th>
                        <th>Restaurant</th>
                        <th>Hospital</th>
                        <th>Lobbies</th>
                        <th>Others</th>                      
                        
                    </tr>
                </thead>
            <tbody>
         </HeaderTemplate>

         <ItemTemplate>             
             <tr>
                    <th><%# Eval("QComID") %> </th>
                    <td><%# Eval("Name") %></td>
                    <td><%# Eval("mobile") %></td>
                    <td><%# Eval("Office") %>   </td>
                    <td><%# Eval("Restaurant") %></td>
                    <td><%# Eval("Hospital") %></td>
                    <td><%# Eval("Lobbies") %></td>
                    <td><%# Eval("Others") %></td>
                    
                    
                </tr>

         </ItemTemplate>


         <FooterTemplate>
             </tbody>

              </table>
         </FooterTemplate>

     </asp:repeater>
    </div>

        

</asp:Content>
