<%@ Page Title="" Language="C#" MasterPageFile="~/AdminMasterPage.Master" AutoEventWireup="true" CodeFile="Supplier.aspx.cs" Inherits="WebSite.Supplier" %>
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
    <h2><b>Supplier</b></h2>   
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
                                <asp:Button ID="btnSearch" runat="server" Text="Search" onClick="btnSearch_Click" CausesValidation="False" />
                            </tr>
                            <tr>
                                <td class="auto-style19">
                                <table class="auto-style14">
                                    <tr>
                                        <td class="auto-style16">
                                            <asp:Label ID="Label1" runat="server" Text="Supplier Name:"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="SupName" runat="server" CssClass="form-control"></asp:TextBox>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Please Enter Supplier Name" ControlToValidate="SupName" Font-Italic="True" Font-Size="Medium" ForeColor="Red"></asp:RequiredFieldValidator>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="auto-style17">
                                            <asp:Label ID="Label2" runat="server" Text="Phone Number:"></asp:Label>
                                        </td>
                                        <td class="auto-style18">
                                            <asp:TextBox ID="SupPhNumber" runat="server" CssClass="form-control"></asp:TextBox>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="Please Enter Phone Number" ControlToValidate="SupPhNumber" Font-Italic="True" Font-Size="Medium" ForeColor="Red"></asp:RequiredFieldValidator>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="auto-style16">
                                            <asp:Label ID="Label3" runat="server" Text="Address:"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="SupAddress" runat="server" CssClass="form-control"></asp:TextBox>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="Please Enter Address" ControlToValidate="SupAddress" Font-Italic="True" Font-Size="Medium" ForeColor="Red"></asp:RequiredFieldValidator>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="auto-style16">
                                            <asp:Label ID="Label4" runat="server" Text="Email:"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="SupEmail" runat="server" CssClass="form-control"></asp:TextBox>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ErrorMessage="Please Enter Email" ControlToValidate="SupEmail" Font-Italic="True" Font-Size="Medium" ForeColor="Red"></asp:RequiredFieldValidator>
                                        &nbsp;<asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="SupEmail" ErrorMessage="Please Enter Valid Email" Font-Italic="True" Font-Size="Medium" ForeColor="Red" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:RegularExpressionValidator>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="auto-style16">
                                            <asp:Label ID="Label5" runat="server" Text="GST Number:"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="SupGST" runat="server" CssClass="form-control"></asp:TextBox>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ErrorMessage="Please Enter GST Number" ControlToValidate="SupGST" Font-Italic="True" Font-Size="Medium" ForeColor="Red"></asp:RequiredFieldValidator>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="auto-style16">
                                            <asp:Label ID="Label6" runat="server" Text="Bank Name" ></asp:Label>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="SupBankName" runat="server" CssClass="form-control"></asp:TextBox>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ErrorMessage="Please Enter Bank Name" ControlToValidate="SupBankName" Font-Italic="True" Font-Size="Medium" ForeColor="Red"></asp:RequiredFieldValidator>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="auto-style16">
                                            <asp:Label ID="Label7" runat="server" Text="Account Number"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="SupAccNo" runat="server" CssClass="form-control"></asp:TextBox>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ErrorMessage="Please Enter Account Number" ControlToValidate="SupAccNo" Font-Italic="True" Font-Size="Medium" ForeColor="Red"></asp:RequiredFieldValidator>
                                        </td>
                                    </tr>
                                    <tr>

                                        <td class="auto-style16">
                                            <asp:Label ID="Label8" runat="server" Text="IFSC Code"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="SupIFSC" runat="server" CssClass="form-control"></asp:TextBox>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" ErrorMessage="Please Enter IFSC Code" ControlToValidate="SupIFSC" Font-Italic="True" Font-Overline="False" Font-Size="Medium" ForeColor="Red"></asp:RequiredFieldValidator>
                                        </td>
                                    </tr>
                                </table>
                                </td>
                            </tr>
                            <tr>
                                <td class="auto-style19">
                                    <table class="auto-style15">
                                        <tr>
                                            <td><asp:Button ID="btnAdd" cssclass="button" runat="server" Text="Add" OnClick="btnAdd_Click" /></td>
                                            <td><asp:Button ID="btnEdit" cssclass="button" runat="server" Text="Update" CausesValidation="False" OnClick="btnEdit_Click" /></td>
                                            <td><asp:Button ID="btnDelete" cssclass="button" runat="server" Text="Delete" CausesValidation="False" OnClick="btnDelete_Click" /></td>
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
                                            <th>Phone Number</th>  
                                            <th>Address</th>
                                            <th>Email</th>
                                            <th>GST Number</th>
                                            <th>Bank Name</th>
                                            <th>Account Number</th> 
                                            <th>IFSC Code</th> 
                                            
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
