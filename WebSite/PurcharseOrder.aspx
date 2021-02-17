<%@ Page Title="" Language="C#" MasterPageFile="~/AdminMasterPage.Master" AutoEventWireup="true" CodeFile="PurcharseOrder.aspx.cs" Inherits="WebSite.PurcharseOrder" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <style type="text/css">
        .auto-style12 {
            width: 100%;
            height: 615px;
        }
        .auto-style13 {
            width: 100%;
            height: 698px;
        }
        .auto-style14 {
            width: 100%;
            height: 705px;
        }
        .auto-style15 {
            width: 100%;
            height: 54px;
        }
        .auto-style16 {
            width: 173px;
        }
        
        .auto-style17 {
            width: 173px;
            height: 88px;
        }
        .auto-style18 {
            height: 88px;
        }
        .auto-style19 {
            width: 1106px;
        }
        .button {
              background-color: #4CAF50;
              border: none;
              color: white;
              padding: 15px 32px;
              text-align: center;
              text-decoration: none;
              display: inline-block;
              font-size: 16px;
              margin: 4px 2px;
              cursor: pointer;
        }
        
        .auto-style20 {
            width: 40px;
        }
        
    </style>

    <br />
    <br />
    <br />

    <hr />
    <h2><b>Purchase Order</b></h2>   
    <hr />
   
        <div>

            <table class="auto-style12">
                <tr>
                    <td>
                        <table class="auto-style13">
                            <tr>
                                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                
                                <asp:TextBox ID="TextBox1" runat="server" placeholder="Enter Supplier Name "></asp:TextBox>
                                &nbsp;&nbsp;
                                <asp:Button ID="btnSearch" runat="server" Text="Search"  CausesValidation="False" />
                            </tr>
                            <tr>
                                <td class="auto-style19">
                                <table class="auto-style14">
                                    <tr>
                                        <td class="auto-style16">
                                            <asp:Label ID="Label1" runat="server" Text="Date :"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:Calendar ID="PO_Date" runat="server"></asp:Calendar>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="auto-style17">
                                            <asp:Label ID="Label2" runat="server" Text="Supplier Name :"></asp:Label>
                                        </td>
                                        
                                        <td class="auto-style18">
                                            <asp:DropDownList ID="PO_SupName" CssClass ="form-control" runat="server"></asp:DropDownList>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="auto-style16">
                                            <asp:Label ID="Label3"  runat="server" Text="Item Name :"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:DropDownList ID="PO_ItemName" CssClass ="form-control" runat="server"> </asp:DropDownList>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="auto-style16">
                                            <asp:Label ID="Label4" runat="server" Text="Quantity :"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="PO_Quantity" runat="server" CssClass="form-control"></asp:TextBox>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ErrorMessage="Please Enter Email" ControlToValidate="PO_Quantity" Font-Italic="True" Font-Size="Medium" ForeColor="Red"></asp:RequiredFieldValidator>
                                    </tr>
                                    <tr>
                                        <td class="auto-style16">
                                            <asp:Label ID="Label5" runat="server" Text="Amount :"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="PO_Amount" runat="server" CssClass="form-control"></asp:TextBox>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ErrorMessage="Please Enter GST Number" ControlToValidate="PO_Amount" Font-Italic="True" Font-Size="Medium" ForeColor="Red"></asp:RequiredFieldValidator>
                                        </td>
                                    </tr>
                                      </table>
                                </td>
                            </tr>
                            <tr>
                                <td class="auto-style19">
                                    <table class="auto-style15">
                                        <tr>
                                            <td><asp:Button ID="btnAdd" cssclass="button" runat="server" Text="Add"  /></td>
                                            <td><asp:Button ID="btnEdit" cssclass="button" runat="server" Text="Update" CausesValidation="False"  /></td>
                                            <td><asp:Button ID="btnDelete" cssclass="button" runat="server" Text="Delete" CausesValidation="False"  /></td>
                                        </tr>
                                        
                                    </table>
                                </td>
                            </tr>
                            
                        </table>
                    </td>
                    <td>&nbsp;&nbsp;&nbsp;</td>
                    <td class="auto-style20" >
                        <div class="panel panel-default" >
               
                            <asp:repeater ID="rptrSupplier" runat="server" >

                            <HeaderTemplate>
                                 <table class="table" >
                                      <thead>
                                        <tr>
                                            
                                            <th>Supplier Name</th>  
                                            <th>Item Name</th>  
                                            <th>Date</th>
                                            <th>Quantity</th>
                                            <th>Amount</th>
                                            <th>Total</th>                                            
                                            
                                        </tr>
                                    </thead>
                                <tbody>
                             </HeaderTemplate>

                             <ItemTemplate>             
                                 <tr>
                                     
                                        <td><%# Eval("SupName") %> </td>
                                        <td><%# Eval("SupPhNo") %></td>
                                        <td><%# Eval("SupAdd") %></td>
                                        <td><%# Eval("SupEmail") %>   </td>
                                        <td><%# Eval("SupGST") %></td>
                                        <td><%# Eval("SupBank") %></td>
                                        <td><%# Eval("SupAccNo") %></td>
                                        <td><%# Eval("SupIFSC") %></td>
                                     
                                    </tr>

                             </ItemTemplate>


                             <FooterTemplate>
                                 </tbody>

                                  </table>
                             </FooterTemplate>

                         </asp:repeater>
                        </div>

                    </td>                    
                </tr>                
            </table>

        </div>

</asp:Content>
