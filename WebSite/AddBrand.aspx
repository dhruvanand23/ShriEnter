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
            </div>            

</asp:Content>
