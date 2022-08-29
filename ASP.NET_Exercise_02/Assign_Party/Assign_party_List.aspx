<%@ Page Title="Assign Party" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Assign_party_List.aspx.cs" Inherits="ASP.NET_Exercise_02.Assign_party" Theme="Default_Theme" MaintainScrollPositionOnPostback="true" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1>Assign Party List</h1>
    <asp:Button ID="Add_Party" runat="server" Text="Add New Party" class="addBtn" OnClick="Add_Party_Click"  SkinID="Button" Height="2em" BorderStyle="Solid" />
    <asp:GridView ID="AssignPartyGrid" runat="server" CssClass="table" AutoGenerateColumns="False" Width="100%" OnRowCommand="AssignPartyGrid_RowCommand">
        <HeaderStyle Font-Bold="true" />
        <Columns>
            <asp:BoundField DataField="assign_id" HeaderText="#" />
            <asp:BoundField DataField="party_name" HeaderText="Party Name" />
            <asp:BoundField DataField="product_name" HeaderText="Product Name" />
            <asp:ButtonField ButtonType="Button" Text="Edit" CommandName="EditAssign" HeaderText="Edit" ControlStyle-BackColor="LightBlue" ControlStyle-BorderStyle="Solid" ControlStyle-BorderColor="LightBlue" ControlStyle-CssClass="Btn-Border" ControlStyle-Height="2.5em"  />
            <asp:ButtonField ButtonType="Button" Text="Delete" CommandName="DeleteAssign" HeaderText="Delete" ControlStyle-ForeColor="White" ControlStyle-BackColor="Red" ControlStyle-BorderStyle="Solid" ControlStyle-BorderColor="Red" ControlStyle-CssClass="Btn-Border" ControlStyle-Height="2.5em" />
        </Columns>
        <HeaderStyle Font-Bold="True" HorizontalAlign="Left" VerticalAlign="Middle" />
        <RowStyle BorderStyle="None" HorizontalAlign="Left" />
    </asp:GridView>
</asp:Content>
