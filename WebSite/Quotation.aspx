<%@ Page Title="" Language="C#" MasterPageFile="~/User.Master" AutoEventWireup="true" CodeFile="Quotation.aspx.cs" Inherits="WebSite.Quotation" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .auto-style1 {
            width : 300px;
            height : 300px;
            position : absolute;
            top: 48px;
            bottom: 305px;
            left: 28px;
            right: 951px;
            margin : auto;
        }
    </style>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container">
    <div>
        <div class="center-page">
            <hr />
            <br />
            <br />
            <asp:RadioButton ID="RadioButton1" runat="server" Text="Home Interior" GroupName="InteriorType" />
            <hr />
            <br />
        </div>
        <div class="col-xs-11">
            <asp:CheckBox ID="CheckBox1" runat="server" Text="BedRoom"/><br />            
            <asp:CheckBox ID="CheckBox2" runat="server" Text="LivingRoom"/><br />
            <asp:CheckBox ID="CheckBox3" runat="server" Text="Kitchen"/><br />
            <asp:CheckBox ID="CheckBox4" runat="server" Text="WholeRoom"/><br />
            <asp:CheckBox ID="CheckBox5" runat="server" Text="Other"/><br />
            <input id="Text1" type="text" /><br /><hr />
        </div>
    </div>
    <div>
        <div class="auto-style1">
            <hr />
            <br />
            <br />
            <asp:RadioButton ID="RadioButton2" runat="server" Text="commercial" GroupName="InteriorType" />
            <hr />
            <br />
        </div>
        <div class="col-xs-11">
            <asp:CheckBox ID="CheckBox6" runat="server" Text="Office" /><br />
            <asp:CheckBox ID="CheckBox7" runat="server" Text="Restaurant"/><br />
            <asp:CheckBox ID="CheckBox8" runat="server" Text="Hospital"/><br />
            <asp:CheckBox ID="CheckBox9" runat="server" Text="Lobbies"/><br />
            <asp:CheckBox ID="CheckBox10" runat="server" Text="Other"/><br />           
            <input id="Text2" type="text" /><br /><hr />
             
        </div>
       
    </div>
        <div>
            <asp:Button ID="Submit_Details" CssClass="btn-btn-success" runat="server" Text="Submit&raquo;" OnClick="Submit_Details_Click" />
        </div>
    </div>
</asp:Content>
