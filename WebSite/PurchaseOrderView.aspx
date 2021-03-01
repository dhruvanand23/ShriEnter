<%@ Page Title="" Language="C#" MasterPageFile="~/AdminMasterPage.Master" AutoEventWireup="true" CodeFile="PurchaseOrderView.aspx.cs" Inherits="WebSite.PurchaseOrderView" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <style>
        .button {
          padding: 15px 25px;
          font-size: 14px;
          text-align: center;
          cursor: pointer;
          outline: none;
          color: #fff;
          background-color: #4CAF50;
          border: none;
          box-shadow: 0 9px #999;
        }

        .button:hover {background-color: #3e8e41}

        .button:active {
          background-color: #3e8e41;
          box-shadow: 0 5px #666;
          transform: translateY(4px);
        }
    </style>
    
    <br />
    <br />
    <br />
    <hr />
    <h2><b>Purchase Order List View</b></h2>  
    <hr />
    <div class="panel panel-default" >
               
                            <asp:repeater ID="rptrPOView" runat="server" >

                            <HeaderTemplate>
                                 <table class="table" >
                                      <thead>
                                        <tr>
                                            <th >POId</th>
                                            
                                            <th >Suplier Name</th>
                                            
                                            <th >Date</th>           
                                            
                                            <th>Edit</th>
                                            <th>Delete</th>
                                            <th>Status</th>
                                        </tr>
                                    </thead>
                                <tbody>
                             </HeaderTemplate>

                             <ItemTemplate>             
                                 <tr>                               
                                     <td><a href="PurchaseOrderView1.aspx?PO_Id=<%# Eval("PO_ID") %>" style="text-decoration:none;"><%# Eval("PO_ID") %></a></td>
                                     
                                     <td ><%# Eval("SupName") %></td>
                                     
                                     <td><%# Eval("PO_Date") %></td>
                                     
                                     <td>
                                         <asp:Button ID="btnUpdate" runat="server" Text="Edit" CssClass="button" />
                                     </td>                                    
                                    
                                     <td>
                                         <asp:Button  ID="btnDelete" runat="server" Text="Delete" CssClass="button"  OnClick="btnDelete_Click" CommandArgument='<%# Eval("PO_ID") %>' />
                                     </td> 
                                      
                                     <td>
                                         <asp:Button ID="btnStatus" runat="server" Text="Status" CssClass="button" />
                                     </td>
                                 </tr>

                             </ItemTemplate>


                             <FooterTemplate>
                                 </tbody>

                                  </table>
                             </FooterTemplate>

                         </asp:repeater>
                        </div>

    <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>
</asp:Content>
