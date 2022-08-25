<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Invoice.aspx.cs" Inherits="ASP.NET_Exercise_02.Invoice" Theme="Default_Theme" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
        <h1>Party Edit</h1>
    <br />
    <table style="width: 30%; margin: auto; text-align: end;">
        <tr>
            <td><asp:Label runat="server" Text="Party Name:" /></td>
            <td><asp:TextBox ID="party_name" runat="server">abc</asp:TextBox></td>
        </tr>
        <tr>
            <td><asp:Label runat="server" Text="Product Name:" /></td>
            <td><asp:TextBox ID="product_name" runat="server">abc</asp:TextBox></td>
        </tr>
        <tr>
            <td><asp:Label runat="server" Text="Current Rate:" /></td>
            <td><asp:TextBox ID="Curr_rate" runat="server"></asp:TextBox></td>
        </tr>
        <tr>
            <td><asp:Label runat="server" Text="Quantity:" /></td>
            <td><asp:TextBox ID="quantity_txtbox" runat="server"></asp:TextBox></td>
        </tr>
    </table>
    <br />
    <asp:Button ID="addInvoice" runat="server" Text="Add to Invoice" SkinID="Button" />
    <br />
    <asp:Label ID="Label1" runat="server" Text="Grand Total:" style="float: right; margin-right:20px"></asp:Label>
    <br />
    <asp:Button runat="server" Text="Close Invoice" SkinID="BtnDelete" style="float:right; margin-right:20px"/>
</asp:Content>
