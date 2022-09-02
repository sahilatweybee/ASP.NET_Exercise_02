﻿<%@ Page Title="Invoice" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Invoice.aspx.cs" Inherits="ASP.NET_Exercise_02.Invoice" Theme="Default_Theme"  %>
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
    <asp:Button ID="addInvoice" runat="server" CssClass="addBtn" Text="Add to Invoice" OnClick="addInvoice_Click" Height="1.5em" Font-Size="1.2em" BorderStyle="Solid"/>
    <br />
    <asp:GridView ID="Invoice_View" runat="server" CssClass="table table-primary table-striped" AutoGenerateColumns="False" Width="100%">
        <HeaderStyle BackColor="DarkSlateBlue" BorderColor="DarkSlateBlue" ForeColor="White" Font-Bold="true" VerticalAlign="Middle"  />
        <AlternatingRowStyle BackColor="LightBlue" BorderColor="LightBlue"/>
        <RowStyle BackColor="LightCyan" BorderColor="LightCyan" BorderStyle="None" HorizontalAlign="Left" VerticalAlign="Middle" Height="1.5em"/>
        <Columns>
            <asp:BoundField DataField="invoice_id" HeaderText="#" ItemStyle-HorizontalAlign="Center"/>
            <asp:BoundField DataField="party_name" HeaderText="Party" HeaderStyle-HorizontalAlign="Left"/>
            <asp:BoundField DataField="product_name" HeaderText="Product" HeaderStyle-HorizontalAlign="Left"/>
            <asp:BoundField DataField="rate" HeaderText="Rate Of Product" HeaderStyle-HorizontalAlign="Left"/>
            <asp:BoundField DataField="quantity" HeaderText="Quantity" HeaderStyle-HorizontalAlign="Left"/>
            <asp:BoundField DataField="total" HeaderText="Total" HeaderStyle-HorizontalAlign="Left"/>
        </Columns>
    </asp:GridView>
    <br />
    <asp:Label ID="lbltotal" runat="server" style="float: right; margin-right:20px;" Text=""></asp:Label>
    <asp:Label ID="Label1" runat="server" Text="Grand Total:" style="float: right; margin-right:20px"></asp:Label>
    <br />
    <asp:Button ID="btnCloseInvoice" runat="server" Text="Close Invoice" SkinID="BtnClose" OnClick="btnCloseInvoice_Click"/>
</asp:Content>
