<%@ Page Title="" Language="C#" MasterPageFile="~/User.Master" AutoEventWireup="true" CodeFile="ContactUs.aspx.cs" Inherits="WebSite.ContactUs" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <!--Contact Us start-->
            <div class="container">
                <div class="form-horizontal">
                    <hr />
                    <hr />
                    <h2>Contact Us </h2>
                    <hr />

                    <div class="form-group">
                        <label class="col-xs-11">UserName:</label>
                        <div class="col-xs-11">
                        <asp:TextBox ID="txtUname" runat="server" Class="form-control" placeholder="Enter Your UserName"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtUname" ErrorMessage="User Name Required" Font-Italic="True" Font-Size="Medium" ForeColor="Red"></asp:RequiredFieldValidator>
                        </div>                        

                        <label class="col-xs-11">Your Address:</label>
                        <div class="col-xs-11">
                        <asp:TextBox ID="txtadd" runat="server" Class="form-control" placeholder="Enter Your Address"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="txtadd" EnableViewState="False" ErrorMessage="Address Required" Font-Italic="True" Font-Size="Medium" ForeColor="Red"></asp:RequiredFieldValidator>
                        </div>

                        <label class="col-xs-11">Your Mobile Number:</label>
                        <div class="col-xs-11">
                        <asp:TextBox ID="txtmob" runat="server" Class="form-control" placeholder="Enter Your Mobile Number"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="txtmob" ErrorMessage="Mobile Number Required" Font-Italic="True" Font-Size="Medium" ForeColor="Red"></asp:RequiredFieldValidator>
                        </div>

                        <label class="col-xs-11">Your Suggestion:</label>
                        <div class="col-xs-11">
                        <asp:TextBox ID="TextBox1" runat="server" Class="form-control" placeholder="Enter Your Suggestion"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="RequiredFieldValidator" ControlToValidate="TextBox1" Font-Italic="True" ForeColor="Red"></asp:RequiredFieldValidator>
                        </div>

                        <label class="col-xs-11">Your Email:</label>
                        <div class="col-xs-11">
                        <asp:TextBox ID="txtEmail" runat="server" Class="form-control" placeholder="Enter Your Email"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ControlToValidate="txtEmail" ErrorMessage="Email ID Required" Font-Italic="True" Font-Size="Medium" ForeColor="Red"></asp:RequiredFieldValidator>
                            <br />
                            <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="txtEmail" ErrorMessage="Please enter a valid email." Font-Italic="True" Font-Size="Medium" ForeColor="Red" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:RegularExpressionValidator>
                        </div>

                        <label class="col-xs-11"></label>
                        <div class="col-xs-11">
                        <asp:Button ID="txtcontactus" Class="btn btn-success" runat="server" Text="Contact Us" OnClick="Txtcontactus_Click"/>
                        </div>

                    </div>
                </div>
            </div>

    <!--Contact Us End Here-->
</asp:Content>
