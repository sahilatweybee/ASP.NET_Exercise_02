<%@ Page Title="Product Edit" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Product_List.aspx.cs" Inherits="ASP.NET_Exercise_02.Product_List" Theme="Default_Theme" %>
<asp:Content ID="ProductContent" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1>Product List</h1>
    <asp:Button ID="Add_Party" runat="server" Text="Add New Product" class="addBtn" SkinID="Button" OnClick="Add_Party_Click" />
    <asp:GridView ID="PartyGrid" runat="server" CssClass="table" AutoGenerateColumns="False" Width="100%">
        <HeaderStyle Font-Bold="True" HorizontalAlign="Left" VerticalAlign="Middle" />
        <RowStyle BorderStyle="None" HorizontalAlign="Left" />
        <Columns>
            <asp:BoundField DataField="product_id" HeaderText="#" />
            <asp:BoundField DataField="product_name" HeaderText="Product Name" />
            <asp:ButtonField ButtonType="Button" Text="Edit" CommandName="EditParty" HeaderText="Edit" ControlStyle-BackColor="LightBlue" ControlStyle-BorderStyle="Solid" ControlStyle-BorderColor="LightBlue" ControlStyle-CssClass="Btn-Border" ControlStyle-Height="2.5em"  />
            <asp:ButtonField ButtonType="Button" Text="Delete" CommandName="DeleteParty" HeaderText="Delete" ControlStyle-ForeColor="White" ControlStyle-BackColor="Red" ControlStyle-BorderStyle="Solid" ControlStyle-BorderColor="Red" ControlStyle-CssClass="Btn-Border" ControlStyle-Height="2.5em" />
        </Columns>
    </asp:GridView>
</asp:Content>
