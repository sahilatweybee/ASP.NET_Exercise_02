<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Party_Edit.aspx.cs" Inherits="ASP.NET_Exercise_02.Party_Edit" Theme="Default_Theme" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1>Party Edit</h1>
    <br />
    <asp:Label runat="server" Text="Party Name:" />
    &nbsp;&nbsp;
    <asp:TextBox ID="Party_name" runat="server" ></asp:TextBox>
    <br />
    <br />
    <asp:Button ID="UpdateParty" runat="server" Text="update" SkinID="BtnUpdate" OnClick="UpdateParty_Click"/>
    &nbsp;&nbsp;
    <asp:Button ID="CancelBtn" runat="server" Text="Cancel" SkinID="BtnCancel"/>
</asp:Content>
