<%@ Page Title="Product Edit" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Product_Edit.aspx.cs" Inherits="ASP.NET_Exercise_02.Product_Edit" Theme="Default_Theme" %>
<asp:Content ID="HeadContent" ContentPlaceHolderID="Head" runat="server" Visible="false">
    <script src="../scripts/Script.js"></script>
</asp:Content> 

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1>Product Edit</h1>
    <asp:Label ID="lblError" runat="server" Font-Size="Small" Text=""></asp:Label>
    <br />
    <asp:Label runat="server" Text="Product Name:" />
    &nbsp;&nbsp;
    <asp:TextBox ID="Product_name" runat="server">abc</asp:TextBox>
    <br />
    <br />
    <asp:Button ID="UpdateProduct" runat="server" Text="update" SkinID="BtnUpdate" OnClick="UpdateProduct_Click"/>
    &nbsp;&nbsp;
    <asp:Button ID="CancelBtn" runat="server" Text="Cancel" SkinID="BtnCancel" OnClientClick="ConfirmExit()" OnClick="CancelBtn_Click"/>
</asp:Content>
