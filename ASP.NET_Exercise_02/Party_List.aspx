﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Party_List.aspx.cs" Inherits="ASP.NET_Exercise_02.WebForm1" Theme="Default_Theme"%>
<asp:Content ID="PartyContent" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1>Party List</h1>
    <asp:Button ID="Add_Party" runat="server" Text="Add New Party" class="addBtn" OnClick="Add_Party_Click"  SkinID="Button" Height="2em" BorderStyle="Solid" />
    <asp:GridView ID="PartyGrid" runat="server" CssClass="table" AutoGenerateColumns="False" Width="100%">
        <HeaderStyle Font-Bold="true" />
        <Columns>
            <asp:BoundField DataField="party_id" HeaderText="#" />
            <asp:BoundField DataField="party_name" HeaderText="Party Name" />
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
