<%@ Page Title="" Language="C#" MasterPageFile="~/AdminMasterPage.Master" AutoEventWireup="true" CodeFile="AddCategory.aspx.cs" Inherits="WebSite.AddCategory" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
   
    <div class="container">
                <div class="form-horizontal">
                    <hr />
                    <hr />
                    <h2>Add Category</h2>
                    <hr />
                    <div class="form-group">
                        <label class="col-xs-11">Category Name:</label>                        
                        <div class="col-xs-11">
                            <asp:TextBox ID="txtCategory" runat="server" Class="form-control" placeholder="Enter Your Category Name"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidatorCategoryName" runat="server" ControlToValidate="txtCategory" ErrorMessage="Category Name Required" Font-Italic="True" Font-Size="Medium" ForeColor="Red"></asp:RequiredFieldValidator>
                        </div>
                       
                        <div>
                            <div class="col-xs-11">
                                <asp:Button ID="btnAddCategory" cssclass="btn btn-success" runat="server" Text="Add" OnClick="btnAddCategory_Click"/>                  
                            </div>
                        </div>                      
                       
                    </div>
                </div>

          <h1>Category</h1>
      <hr />

      <div class="panel panel-default">
                <div class="panel-heading"> All Categories</div>

          <asp:Repeater ID="rptrCategory" runat="server">
              
              <HeaderTemplate>
                  <table class="table">
                    <thead>
                        <tr>
                            <th>#</th>
                            <th>Category</th>
                            <th>Edit</th>
                        </tr>
                    </thead>

                    <tbody>
              </HeaderTemplate>

              <ItemTemplate>
                   <tr>
                            <th><%# Eval("CatID") %></th>
                            <td><%# Eval("CatName") %></td>
                            <td>edit</td>
                        </tr>
              </ItemTemplate>

              <FooterTemplate>
                   </tbody>
                  </table>
              </FooterTemplate>
              
          </asp:Repeater>

        </div>

    </div>
    
</asp:Content>
