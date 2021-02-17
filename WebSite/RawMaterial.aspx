<%@ Page Title="" Language="C#" MasterPageFile="~/AdminMasterPage.Master" AutoEventWireup="true" CodeFile="RawMaterial.aspx.cs" Inherits="WebSite.RawMaterial" %>
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
    <h2><b>Raw Material</b></h2>   
    <hr />
   
        <div>

            <table class="auto-style12">
                <tr>
                    <td>
                        <table class="auto-style13">
                            <tr>
                                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                
                                <asp:TextBox ID="TextBox1" runat="server" placeholder="Enter Material Name " ></asp:TextBox>
                                &nbsp;&nbsp;
                                <asp:Button ID="btnSearch" runat="server" Text="Search"  CausesValidation="False" OnClick="btnSearch_Click" />
                            </tr>
                            <tr>
                                <td class="auto-style19">
                                <table class="auto-style14">
                                    <tr>
                                        <td class="auto-style16">
                                            <asp:Label ID="Label1" runat="server" Text="Raw Material Name:"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="RMName" runat="server" CssClass="form-control"></asp:TextBox>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Please Enter Material Name" ControlToValidate="RMName" Font-Italic="True" Font-Size="Medium" ForeColor="Red"></asp:RequiredFieldValidator>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="auto-style17">
                                            <asp:Label ID="Label2" runat="server" Text="Price:"></asp:Label>
                                        </td>
                                        <td class="auto-style18">
                                            <asp:TextBox ID="RMPrice" runat="server" CssClass="form-control"></asp:TextBox>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="Please Enter Price" ControlToValidate="RMPrice" Font-Italic="True" Font-Size="Medium" ForeColor="Red"></asp:RequiredFieldValidator>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="auto-style16">
                                            <asp:Label ID="Label3" runat="server" Text="Unit:"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="RMUnit" runat="server" CssClass="form-control"></asp:TextBox>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="Please Enter Unit" ControlToValidate="RMUnit" Font-Italic="True" Font-Size="Medium" ForeColor="Red"></asp:RequiredFieldValidator>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="auto-style16">
                                            <asp:Label ID="Label4" runat="server" Text="Supplier Name:"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:DropDownList ID="RMSupplier" runat="server" CssClass ="form-control"></asp:DropDownList>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ErrorMessage="Please Select Supplier" ControlToValidate="RMSupplier" Font-Italic="True" Font-Size="Medium" ForeColor="Red"></asp:RequiredFieldValidator>
                                        </td>
                                    
                                </table>
                                </td>
                            </tr>
                            <tr>
                                <td class="auto-style19">
                                    <table class="auto-style15">
                                        <tr>
                                            <td><asp:Button ID="btnAdd" cssclass="button" runat="server" Text="Add" OnClick="btnAdd_Click" /></td>
                                            <td><asp:Button ID="btnEdit" cssclass="button" runat="server" Text="Update" CausesValidation="False" /></td>
                                            <td><asp:Button ID="btnDelete" cssclass="button" runat="server" Text="Delete" CausesValidation="False" /> /> /></td>
                                        </tr>
                                        
                                    </table>
                                </td>
                            </tr>
                            
                        </table>
                    </td>
                    <td>&nbsp;&nbsp;&nbsp;</td>
                    <td class="auto-style20" >
                        <div class="panel panel-default" >
               
                            <asp:repeater ID="rptrRMaterial" runat="server" >

                            <HeaderTemplate>
                                 <table class="table" >
                                      <thead>
                                        <tr>
                                            
                                            <th>Material Name</th>  
                                            <th>Price</th>  
                                            <th>Unit</th>
                                            <th>Supplier Name</th>
                                            
                                            
                                        </tr>
                                    </thead>
                                <tbody>
                             </HeaderTemplate>

                             <ItemTemplate>             
                                 <tr>                                    
                                        <td><%# Eval("RM_Name") %> </td>
                                        <td><%# Eval("RM_Price") %></td>
                                        <td><%# Eval("RM_Unit") %></td>
                                        <td><%# Eval("SupName") %>   </td>                                        
                                     
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
