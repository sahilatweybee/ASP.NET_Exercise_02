﻿<%@ Page Title="Party List" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Party_List.aspx.cs" Inherits="ASP.NET_Exercise_02.WebForm1" Theme="Default_Theme" MaintainScrollPositionOnPostback="true" %>
<asp:Content ID="HeadContent" ContentPlaceHolderID="Head" runat="server" Visible="false">
    <script src="../scripts/Script.js"></script>
</asp:Content> 

<asp:Content ID="PartyContent" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1>Party List</h1>
    <asp:Label ID="lblError" runat="server" Font-Size="Small" Text=""></asp:Label>
    <asp:Button ID="Add_Party" runat="server" Text="Add New Party" CssClass="addBtn btn" OnClick="Add_Party_Click" Height="2em" BorderStyle="Solid" />
        <asp:GridView ID="PartyGrid" runat="server" CssClass="table" AutoGenerateColumns="False" Width="100%">
        <Columns>
            <asp:BoundField DataField="party_id" HeaderText="#" />
            <asp:BoundField DataField="party_name" HeaderText="Party Name" />
            <asp:TemplateField HeaderText="Edit" ShowHeader="False">
                <ItemTemplate>
                    <asp:Button ID="btnEdit" CssClass="btn-edit btn" runat="server" CausesValidation="false" CommandArgument='<%# Eval("party_id") %>' CommandName="Edit" Text="Edit" OnClick="BtnEdit_Click" />
                </ItemTemplate>
                <ControlStyle BackColor="SkyBlue" BorderColor="SkyBlue" BorderStyle="Solid" Height="2.5em" />
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Delete" ShowHeader="False">
                <ControlStyle ForeColor="White" BorderStyle="Solid" Height="2.5em"  />
                <ItemTemplate>
                    <asp:Button ID="btnDelete" CssClass="btn btn-red" runat="server" CausesValidation="false" CommandArgument='<%# Eval("party_id") %>' OnClientClick="ConfirmDelete()" CommandName="Delete" Text="Delete" OnClick="BtnDelete_Click" />
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
        <HeaderStyle Font-Bold="True" HorizontalAlign="Left" VerticalAlign="Middle" />
        <RowStyle BorderStyle="None" HorizontalAlign="Left" />
    </asp:GridView>
</asp:Content>