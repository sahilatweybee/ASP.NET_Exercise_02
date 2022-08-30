<%@ Page Title="Invoice" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Invoice.aspx.cs" Inherits="ASP.NET_Exercise_02.Invoice" Theme="Default_Theme"  %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
        <h1>Invoice</h1>
        <asp:Label ID="LblError" ForeColor="DarkRed" runat="server" Font-Size="Small" Text=""></asp:Label>
    <br />
    <table style="width: 30%; margin: auto; text-align: right;">
        <tr>
            <td><asp:Label runat="server" Text="Party Name:" /></td>
            <td>
                <asp:DropDownList ID="SelectParty" runat="server" AutoPostBack="true" OnSelectedIndexChanged="SelectParty_SelectedIndexChanged">
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td><asp:Label runat="server" Text="Product Name:" /></td>
            <td><asp:DropDownList ID="SelectProduct" runat="server" AutoPostBack="true" OnSelectedIndexChanged="SelectProduct_SelectedIndexChanged">
                </asp:DropDownList>
            </td>
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
    <asp:Button ID="addInvoice" runat="server" Text="Add to Invoice" SkinID="Button" OnClick="addInvoice_Click" style="border-radius:0.3em" CssClass="addBtn btn" />
    <br />
    <asp:GridView ID="Invoice_View" runat="server" CssClass="table" AutoGenerateColumns="False" Width="100%">
        <HeaderStyle Font-Bold="True" HorizontalAlign="Left" VerticalAlign="Middle" />
        <RowStyle BorderStyle="None" HorizontalAlign="Left" />
        <Columns>
            <asp:BoundField DataField="invoice_id" HeaderText="#" />
            <asp:BoundField DataField="party_name" HeaderText="Party" />
            <asp:BoundField DataField="product_name" HeaderText="Product" />
            <asp:BoundField DataField="rate" HeaderText="Rate Of Product" />
            <asp:BoundField DataField="quantity" HeaderText="Quantity" />
            <asp:BoundField DataField="total" HeaderText="Total" />
        </Columns>
    </asp:GridView>
    <br />
    <asp:Label ID="lbltotal" runat="server" style="float: right; margin-right:20px;" Text=""></asp:Label>
    <asp:Label ID="Label1" runat="server" Text="Grand Total:" style="float: right; margin-right:20px"></asp:Label>
    <br />
    <asp:Button runat="server" Text="Close Invoice" SkinID="BtnClose" style="margin-right:20px"/>
</asp:Content>
