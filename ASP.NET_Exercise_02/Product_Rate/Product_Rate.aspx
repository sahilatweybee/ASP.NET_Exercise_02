<%@ Page Title="Product Rate List" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Product_Rate.aspx.cs" Inherits="ASP.NET_Exercise_02.Produce_Rate" Theme="Default_Theme" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1>Product Rate List</h1>
    <asp:Button ID="Add_Party" runat="server" Text="Add New aproductRate" class="addBtn" SkinID="Button" OnClick="Add_Party_Click" />
    <asp:GridView ID="RateGrid" runat="server" CssClass="table" AutoGenerateColumns="False" Width="100%">
        <HeaderStyle Font-Bold="true" />
        <Columns>
            <asp:BoundField DataField="rate_id" HeaderText="#" />
            <asp:BoundField DataField="product_name" HeaderText="Product Name" />
            <asp:BoundField DataField="rate" HeaderText="Rate" />
            <asp:BoundField DataField="date_of_rate" HeaderText="Date of Rate" />
           <asp:ButtonField ButtonType="Button" Text="Edit" CommandName="EditParty" HeaderText="Edit" ControlStyle-BackColor="LightBlue" ControlStyle-BorderStyle="Solid" ControlStyle-BorderColor="LightBlue" ControlStyle-CssClass="Btn-Border" ControlStyle-Height="2.5em"  />
            <asp:ButtonField ButtonType="Button" Text="Delete" CommandName="DeleteParty" HeaderText="Delete" ControlStyle-ForeColor="White" ControlStyle-BackColor="Red" ControlStyle-BorderStyle="Solid" ControlStyle-BorderColor="Red" ControlStyle-CssClass="Btn-Border" ControlStyle-Height="2.5em" />
        </Columns>
        <HeaderStyle Font-Bold="True" HorizontalAlign="Left" VerticalAlign="Middle" />
        <RowStyle BorderStyle="None" HorizontalAlign="Left" />
    </asp:GridView>
</asp:Content>
