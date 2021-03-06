<%@ Page Title="" Language="C#" MasterPageFile="~/AdminMasterPage.Master" AutoEventWireup="true" CodeFile="SalesOrderView.aspx.cs" Inherits="WebSite.SalesOrderView" %>

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
    <h2><b>Sales Order List View</b></h2>  
    <hr />

    <table style="width:400px">
        <tr>
            <td><asp:RadioButton ID="btnAll" runat="server" Text="  All"  GroupName="FilterSelect" AutoPostBack="True" OnCheckedChanged="FilterSelect_CheckedChanged" Font-Bold="True" Font-Size="Large" /></td>
            <td><asp:RadioButton ID="btnLive" runat="server" Text="  Live"  GroupName="FilterSelect" AutoPostBack="True" OnCheckedChanged="FilterSelect_CheckedChanged" Font-Bold="True" Font-Size="Large" /></td>
            <td><asp:RadioButton ID="btnDead" runat="server" Text="  Dead"  GroupName="FilterSelect" AutoPostBack="True" OnCheckedChanged="FilterSelect_CheckedChanged" Font-Bold="True" Font-Size="Large" /></td>
        </tr>
    </table>
    <br />

     <div class="panel panel-default" >
               
                            <asp:repeater ID="rptrSOView" runat="server" >

                            <HeaderTemplate>
                                 <table class="table" >
                                      <thead>
                                        <tr>
                                            <th >SOId</th>
                                            
                                            <th >Customer Name</th>
                                            
                                            <th >Date</th>           
                                            
                                            <th>Edit</th>
                                            <th>Delete</th>
                                            <th>Status</th>
                                            <th>Change Status</th>
                                        </tr>
                                    </thead>
                                <tbody>
                             </HeaderTemplate>

                             <ItemTemplate>             
                                 <tr>                               
                                     <td><a href="SalesOrderView1.aspx?SO_Id=<%# Eval("SO_ID") %>" style="text-decoration:none;"><%# Eval("SO_ID") %></a></td>
                                     
                                     <td ><%# Eval("Name") %></td>
                                     
                                     <td><%# Eval("SO_Date") %></td>
                                     
                                     <td>
                                         
                                         <asp:Button ID="btnUpdate" runat="server" Text="Edit" CssClass="button" OnClick="btnUpdate_Click" />
                                         
                                     </td>                                    
                                    
                                     <td>
                                         <asp:Button  ID="btnDelete" runat="server" Text="Delete" CssClass="button"  OnClick="btnDelete_Click" CommandArgument='<%# Eval("SO_ID") %>'  />
                                     </td> 
                                         
                                     <td> 
                                        <%# Eval("SO_Status") %>
                                         
                                     </td>
                                     <td>
                                         
                                         <asp:Button ID="btnUpdate1" runat="server" Text="Change Status" CssClass="button" OnClick="btnUpdate1_Click" CommandArgument='<%# Eval("SO_ID") %>' />
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
