﻿<%@ Page Title="Product Rate List" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Product_Rate_List.aspx.cs" Inherits="ASP.NET_Exercise_02.Produce_Rate" Theme="Default_Theme" MaintainScrollPositionOnPostback="true" %>
<asp:Content ID="HeadContent" ContentPlaceHolderID="Head" runat="server" Visible="false">
    <script src="../scripts/Script.js"></script>
</asp:Content> 

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1>Product Rate List</h1>
    <asp:Label ID="lblError" runat="server" Font-Size="Small" Text=""></asp:Label>
    <asp:ImageButton ImageUrl="~/Images/add_box_FILL0_wght500_GRAD200_opsz48.png" style="float:right" ImageAlign="AbsMiddle" runat="server"  CssClass="btn" OnClick="Add_Party_Click" Text="Add New aproductRate" ID="Add_Party"/>
    <asp:GridView ID="RateGrid" runat="server" CssClass="table" AutoGenerateColumns="False" Width="100%">
        <HeaderStyle BackColor="#666666" ForeColor="White" Font-Bold="true" HorizontalAlign="Center" VerticalAlign="Middle"  />
        <AlternatingRowStyle BackColor="#cccccc" BorderColor="#cccccc"/>
        <RowStyle BackColor="White" BorderColor="White" BorderStyle="None" HorizontalAlign="Left" />
        <Columns>
            <asp:BoundField DataField="rate_id" HeaderText="#" ItemStyle-HorizontalAlign="Center"/>
            <asp:BoundField DataField="product_name" HeaderText="Product Name" />
            <asp:BoundField DataField="rate" HeaderText="Rate" />
            <asp:BoundField DataField="date_of_rate" HeaderText="Date of Rate" />
            <asp:TemplateField HeaderText="Actions" ShowHeader="False">
                <ItemStyle HorizontalAlign="Center" VerticalAlign="Bottom" Height="1em"/>
                <ControlStyle Height="2em"/>
                <ItemTemplate>
                    <asp:ImageButton ID="btnEdit" style="vertical-align:text-bottom;" ImageUrl="~/Images/edit_square_FILL0_wght500_GRAD200_opsz40.png" runat="server" CausesValidation="false" CommandArgument='<%# Eval("rate_id") %>' CommandName="Edit" OnClick="BtnEdit_Click" />
                    <asp:ImageButton ID="btnDelete" style="vertical-align:text-bottom;" ImageUrl="~/Images/delete_forever_FILL0_wght500_GRAD200_opsz40.png" runat="server" CausesValidation="false" ForeColor="White" CommandArgument='<%# Eval("rate_id") %>' OnClientClick="ConfirmDelete()" CommandName="Delete" OnClick="BtnDelete_Click" />
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
    </asp:GridView>
</asp:Content>
