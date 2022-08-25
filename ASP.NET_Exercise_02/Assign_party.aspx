<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Assign_party.aspx.cs" Inherits="ASP.NET_Exercise_02.Assign_party" Theme="Default_Theme" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1>Assign Party List</h1>
    <asp:Button ID="Add_Party" runat="server" Text="Add New Party" class="addBtn" OnClick="Add_Party_Click"  SkinID="Button" Height="2em" BorderStyle="Solid" />
    <asp:GridView ID="PartyGrid" runat="server" CssClass="table" AutoGenerateColumns="False" Width="100%">
        <HeaderStyle Font-Bold="true" />
        <Columns>
            <asp:BoundField DataField="assign_id" HeaderText="#" />
            <asp:BoundField DataField="party_name" HeaderText="Party Name" />
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
