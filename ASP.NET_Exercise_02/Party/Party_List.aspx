<%@ Page Title="Party List" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Party_List.aspx.cs" Inherits="ASP.NET_Exercise_02.WebForm1" Theme="Default_Theme" MaintainScrollPositionOnPostback="true" %>
<asp:Content ID="PartyContent" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1>Party List</h1>
    <asp:Button ID="Add_Party" runat="server" Text="Add New Party" class="addBtn" OnClick="Add_Party_Click"  SkinID="Button" Height="2em" BorderStyle="Solid" />
    <asp:GridView ID="PartyGrid" runat="server" CssClass="table" AutoGenerateColumns="False" Width="100%" OnRowCommand="Alter_Party" >
        <HeaderStyle Font-Bold="true" />
        <Columns>
            <asp:BoundField DataField="party_id" HeaderText="#" />
            <asp:BoundField DataField="party_name" HeaderText="Party Name" />
            <asp:ButtonField ButtonType="Button" Text="Edit" CommandName="EditParty" HeaderText="Edit" ControlStyle-BackColor="LightBlue" ControlStyle-BorderStyle="Solid" ControlStyle-BorderColor="LightBlue" ControlStyle-CssClass="Btn-Border" ControlStyle-Height="2.5em"  />
            <asp:ButtonField ButtonType="Button" Text="Delete" CommandName="DeleteParty" HeaderText="Delete" ControlStyle-ForeColor="White" ControlStyle-BackColor="Red" ControlStyle-BorderStyle="Solid" ControlStyle-BorderColor="Red" ControlStyle-CssClass="Btn-Border" ControlStyle-Height="2.5em" />
        </Columns>
        <HeaderStyle Font-Bold="True" HorizontalAlign="Left" VerticalAlign="Middle" />
        <RowStyle BorderStyle="None" HorizontalAlign="Left" />
    </asp:GridView>
</asp:Content>
