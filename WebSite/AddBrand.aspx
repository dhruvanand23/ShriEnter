  <%@ Page Title="" Language="C#" MasterPageFile="~/AdminMasterPage.Master" AutoEventWireup="true" CodeBehind="AddBrand.aspx.cs" Inherits="WebSite.AddBrand" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
  <div class="container">
                <div class="form-horizontal">
                    <hr />
                    <hr />
                    <h2>Add Brand</h2>
                    <hr />
                    <div class="form-group">
                        <label class="col-xs-11">Brand Name:</label>                        
                        <div class="col-xs-11">
                            <asp:TextBox ID="txtBrand" runat="server" Class="form-control" placeholder="Enter Your Brand Name"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidatorBrandName" runat="server" ControlToValidate="txtBrand" ErrorMessage="Brand Name Required" Font-Italic="True" Font-Size="Medium" ForeColor="Red"></asp:RequiredFieldValidator>
                        </div>
                       
                        <div>
                            <div class="col-xs-11">
                                <asp:Button ID="btnAddBrand" cssclass="btn btn-success" runat="server" Text="Add" OnClick="btnAddBrand_Click"/>                  
                            </div>
                        </div>                      
                       
                    </div>
                </div>

          <h1>Brand</h1>
      <hr />
      <div class="panel panel-default">
                <div class="panel-heading"> All Brands</div>

          <asp:Repeater ID="rptrBrands" runat="server">
              
              <HeaderTemplate>
                  <table class="table">
                    <thead>
                        <tr>
                            <th>#</th>
                            <th>Brand</th>
                            <th>Edit</th>
                        </tr>
                    </thead>

                    <tbody>
              </HeaderTemplate>

              <ItemTemplate>
                   <tr>
                            <th><%# Eval("BrandID") %></th>
                            <td><%# Eval("Name") %></td>
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
