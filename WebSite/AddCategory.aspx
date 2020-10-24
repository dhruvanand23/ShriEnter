<%@ Page Title="" Language="C#" MasterPageFile="~/AdminMasterPage.Master" AutoEventWireup="true" CodeFile="AddCategory.aspx.cs" Inherits="WebSite.AddCategory" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
   
    <div class="container">
                <div class="form-horizontal">
                    <hr />
                    <hr />
                    <h2>Category</h2>
                    <hr />
                    <div class="form-group">
                        <label class="col-xs-11">Category :</label>                        
                        <div class="col-xs-11">
                            <asp:TextBox ID="txtCategory" runat="server" Class="form-control" placeholder="Enter Category"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidatorCategory" runat="server" ControlToValidate="txtCategory" ErrorMessage="Please Enter Category" Font-Italic="True" Font-Size="Medium" ForeColor="Red"></asp:RequiredFieldValidator>
                        </div>
                       
                        <div>
                            <div class="col-xs-11">
                                <asp:Button ID="btnAddCategory" cssclass="btn btn-success" runat="server" Text="Add Category" Height="36px" Width="153px" OnClick="btnAddCategory_Click" />                  
                            </div>
                        </div>
                    </div>
                </div>
            </div>
    
</asp:Content>
