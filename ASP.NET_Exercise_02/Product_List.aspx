<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Product_List.aspx.cs" Inherits="ASP.NET_Exercise_02.Product_List" Theme="Default_Theme" %>
<asp:Content ID="ProductContent" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1>Product List</h1>
    <asp:Button ID="Add_Party" runat="server" Text="Add New Product" class="addBtn" SkinID="Button" OnClick="Add_Party_Click" />
    <asp:GridView ID="PartyGrid" runat="server" CssClass="table" AutoGenerateColumns="False" Width="100%">
        <HeaderStyle Font-Bold="true" />
        <Columns>
            <asp:BoundField DataField="product_id" HeaderText="#" />
            <asp:BoundField DataField="product_name" HeaderText="Product Name" />
            <asp:TemplateField HeaderText="Action">
                <ItemTemplate>
                    <asp:Button runat="server" Text="Edit" SkinID= "BtnEdit"/>
                    <asp:Button runat="server" Text="Delete" SkinID= "BtnDelete"/>
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
        <HeaderStyle Font-Bold="True" HorizontalAlign="Left" VerticalAlign="Middle" />
        <RowStyle BorderStyle="None" HorizontalAlign="Left" />
    </asp:GridView>
</asp:Content>
