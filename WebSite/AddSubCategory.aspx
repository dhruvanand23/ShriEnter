<%@ Page Title="" Language="C#" MasterPageFile="~/AdminMasterPage.Master" AutoEventWireup="true" CodeFile="AddSubCategory.aspx.cs" Inherits="WebSite.AddSubCategory" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server"> 

     <div class="container">
                <div class="form-horizontal">
                    <hr />
                    <hr />
                    <h2>SubCategory</h2>
                    <hr />

                    <label class="col-xs-11">Main Category ID</label>                        
                        <div class="col-xs-11">
                            <asp:DropDownList ID="ddlMainCatID" CssClass ="form-control" runat="server"></asp:DropDownList>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidatorMainCatID" runat="server" ControlToValidate="ddlMainCatID" ErrorMessage="Please Enter MainCategory" Font-Italic="True" Font-Size="Medium" ForeColor="Red"></asp:RequiredFieldValidator>
                        </div>

                    <div class="form-group">
                        <label class="col-xs-11">SubCategory :</label>                        
                        <div class="col-xs-11">
                            <asp:TextBox ID="txtSubCategory" runat="server" Class="form-control" placeholder="Enter SubCategory"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidatorSubCategory" runat="server" ControlToValidate="txtSubCategory" ErrorMessage="Please Enter SubCategory" Font-Italic="True" Font-Size="Medium" ForeColor="Red"></asp:RequiredFieldValidator>
                        </div>
                       
                        <div>
                            <div class="col-xs-11">
                                <asp:Button ID="btnAddSubCategory" cssclass="btn btn-success" runat="server" Text="Add SubCategory" Height="36px" Width="153px" OnClick="btnAddSubCategory_Click" />                  
                            </div>
                        </div>
                    </div>
                </div>

         <h1>SubCategory</h1>
      <hr />

      <div class="panel panel-default">
                <div class="panel-heading"> All SubCategories</div>

          <asp:Repeater ID="rptrSubCat" runat="server">
              
              <HeaderTemplate>
                  <table class="table">
                    <thead>
                        <tr>
                            <th>#</th>
                            <th>SubCategory</th>
                            <th>Main Category</th>
                            <th>Edit</th>
                        </tr>
                    </thead>

                    <tbody>
              </HeaderTemplate>

              <ItemTemplate>
                   <tr>
                       <th><%# DataBinder.Eval(Container.DataItem, "SubCatID") %></th>
                       <td><%# DataBinder.Eval(Container.DataItem, "SubCatName") %></td>
                       <td><%# DataBinder.Eval(Container.DataItem, "CatName") %></td>
                       <td>edit</td>
                   </tr>
              </ItemTemplate>

              <FooterTemplate>
                   </tbody>
                  </table>
              </FooterTemplate>
              
          </asp:Repeater>

            </div>
   
</asp:Content>
