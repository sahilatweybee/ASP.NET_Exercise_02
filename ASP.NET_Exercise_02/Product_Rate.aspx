<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Product_Rate.aspx.cs" Inherits="ASP.NET_Exercise_02.Produce_Rate" Theme="Default_Theme" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1>Product Rate List</h1>
    <asp:Button ID="Add_Party" runat="server" Text="Add New Party" class="addBtn" SkinID="Button" Height="2em" BorderStyle="Solid" />
    <asp:GridView ID="RateGrid" runat="server" CssClass="table" AutoGenerateColumns="False" Width="100%">
        <HeaderStyle Font-Bold="true" />
        <Columns>
            <asp:BoundField DataField="rate_id" HeaderText="#" />
            <asp:BoundField DataField="product_name" HeaderText="Product Name" />
            <asp:BoundField DataField="rate" HeaderText="Rate" />
            <asp:BoundField DataField="date_of_rate" HeaderText="Date of Rate" />
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
