﻿<%@ Page Title="" Language="C#" MasterPageFile="~/AdminMasterPage.Master" AutoEventWireup="true" CodeFile="PurcharseOrder.aspx.cs" Inherits="WebSite.PurcharseOrder" %>
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
            height: 600px;
        }
        .auto-style15 {
            width: 100%;
            height: 54px;
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
            width: 185px;
        }
         .auto-style23 {
             height: 47px;
         }
         .auto-style24 {
             width: 173px;
             height: 73px;
         }
         .auto-style25 {
             height: 73px;
         }
         .auto-style26 {
             width: 173px;
             height: 43px;
         }
         .auto-style27 {
             height: 43px;
         }
         .auto-style28 {
             width: 173px;
             height: 45px;
         }
         .auto-style29 {
             height: 45px;
         }
         .auto-style30 {
             width: 173px;
             height: 28px;
         }
         .auto-style31 {
             height: 28px;
         }
         .auto-style32 {
             width: 173px;
             height: 6px;
         }
         .auto-style33 {
             
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
                                
                                <asp:TextBox ID="TextBox1" runat="server" placeholder="Enter Supplier Name "  AutoPostBack="True"></asp:TextBox>
                                &nbsp;&nbsp;
                                <asp:Button ID="btnSearch" runat="server" Text="Search"  CausesValidation="False" OnClick="btnSearch_Click" />
                            </tr>

                            
                            <tr>
                                <td class="auto-style19">
                                <table class="auto-style14">
                                    
                                    <tr>
                                        <td class="auto-style23">
                                            <asp:RadioButton ID="RadioButton1" runat="server" Text="Add Purchase Order" GroupName="AddSelection" AutoPostBack="True" OnCheckedChanged="AddSelection_CheckedChanged" />
                                        </td>
                                        <td class="auto-style23">
                                            <asp:RadioButton ID="RadioButton2" runat="server" Text="Add Item" GroupName="AddSelection" AutoPostBack="True" OnCheckedChanged="AddSelection_CheckedChanged" />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="auto-style32">
                                            <asp:Label ID="Label1" runat="server" Text="Date :"></asp:Label>
                                        </td>
                                        <td class="auto-style33">
                                            <asp:Calendar ID="PO_Date" runat="server" SelectionMode="DayWeekMonth" Enabled="False"></asp:Calendar>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="auto-style26">
                                            <asp:Label ID="Label2" runat="server" Text="Supplier Name :"></asp:Label>
                                        </td>
                                        
                                        <td class="auto-style27">
                                            <asp:DropDownList ID="PO_SupName" CssClass ="form-control" runat="server" Enabled="False" OnSelectedIndexChanged="PO_SupName_SelectedIndexChanged" AutoPostBack="True"></asp:DropDownList>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="auto-style28">
                                            <asp:Label ID="Label3"  runat="server" Text="Item Name :"></asp:Label>
                                        </td>
                                        <td class="auto-style29">
                                            <asp:DropDownList ID="PO_ItemName" CssClass ="form-control" runat="server" Enabled="False" OnSelectedIndexChanged="PO_ItemName_SelectedIndexChanged" AutoPostBack="True"> </asp:DropDownList>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="auto-style24">
                                            <asp:Label ID="Label4" runat="server" Text="Quantity :"></asp:Label>
                                        </td>
                                        <td class="auto-style25">
                                            <asp:Label ID="lblMsg" runat="server" Text="" Font-Bold="True" Font-Size="Larger" ForeColor="Red"></asp:Label>
                                            <asp:TextBox ID="PO_Quantity" runat="server" CssClass="form-control" Enabled="False"></asp:TextBox>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ErrorMessage="Please Enter Quantity" ControlToValidate="PO_Quantity" Font-Italic="True" Font-Size="Medium" ForeColor="Red"></asp:RequiredFieldValidator>
                                    </tr>
                                    <tr>
                                        <td class="auto-style30">
                                            <asp:Label ID="Label5" runat="server" Text="Amount :"></asp:Label>
                                        </td>
                                        <td class="auto-style31">
                                            <asp:TextBox ID="PO_Amount" runat="server" CssClass="form-control" Enabled="False"></asp:TextBox>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ErrorMessage="Please Enter Amount" ControlToValidate="PO_Amount" Font-Italic="True" Font-Size="Medium" ForeColor="Red"></asp:RequiredFieldValidator>
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
                                            <td><asp:Button ID="btnEdit" cssclass="button" runat="server" Text="Update" CausesValidation="False" OnClick="btnEdit_Click"  /></td>
                                            <td><asp:Button ID="btnDelete" cssclass="button" runat="server" Text="Delete" CausesValidation="False" OnClick="btnDelete_Click"  /></td>
                                        </tr>
                                        
                                    </table>
                                </td>
                            </tr>
                            
                        </table>
                    </td>
                    <td>&nbsp;&nbsp;&nbsp;</td>
                    <td class="auto-style20" >
                        <table style="width:600px">
                            <tr>
                                <td class="auto-style23">
                                    <asp:Label ID="Label7" runat="server" Text="P.O.Id:"></asp:Label>
                                    <br />
                                    <asp:Label ID="lblPOId" runat="server" Text=""></asp:Label>
                                </td>
                                <td class="auto-style23">
                                    <asp:Label ID="Label8" runat="server" Text="Date:"></asp:Label>
                                    <br />
                                    <asp:Label ID="lblDate" runat="server" Text=""></asp:Label>
                                </td>
                                <td class="auto-style23">
                                    <asp:Label ID="Label6" runat="server" Text="Supplier Name:"></asp:Label>
                                    <br />
                                    <asp:Label ID="lblSupName" runat="server" Text=""></asp:Label>
                                </td>
                            </tr>
                         </table>   
                             <div class="panel panel-default" >
               
                            <asp:repeater ID="rptrPO" runat="server" >

                            <HeaderTemplate>
                                 <table class="table" style="width:600px" >
                                      <thead>
                                        <tr>
                                            
                                                                                        
                                            <th>Item Name</th>
                                            <th>Quantity</th>
                                            <th>Price</th>
                                                                                        
                                            
                                        </tr>
                                    </thead>
                                <tbody>
                             </HeaderTemplate>

                             <ItemTemplate>             
                                 <tr>                                     
                                        
                                        <td><%# Eval("RM_Name") %></td>
                                        <td><%# Eval("POItem_Quantity") %></td>
                                        <td><%# Eval("POItem_Price") %>   </td>
                                                                                
                                     
                                 </tr>

                             </ItemTemplate>


                             <FooterTemplate>
                                 </tbody>

                                  </table>
                             </FooterTemplate>

                         </asp:repeater>
                        </div>
                            </tr>
                         </table>
                    </td>                    
                

        </div>
    

</asp:Content>
