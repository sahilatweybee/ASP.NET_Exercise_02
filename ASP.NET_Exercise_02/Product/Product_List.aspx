<%@ Page Title="Product Edit" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Product_List.aspx.cs" Inherits="ASP.NET_Exercise_02.Product_List" Theme="Default_Theme" MaintainScrollPositionOnPostback="true" %>
<asp:Content ID="HeadContent" ContentPlaceHolderID="Head" runat="server" Visible="false">
    <script src="../scripts/Script.js"></script>
</asp:Content> 

<asp:Content ID="ProductContent" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1>Product List</h1>
    <asp:Label ID="lblError" runat="server" Font-Size="Small" Text=""></asp:Label>
    <asp:Button ID="Add_Party" runat="server" Text="Add New Product" CssClass="addBtn btn" OnClick="Add_Party_Click" Height="2em" BorderStyle="Solid"/>
    <asp:GridView ID="ProductGrid" runat="server" CssClass="table" AutoGenerateColumns="False" Width="100%">
        <HeaderStyle Font-Bold="True" HorizontalAlign="Left" VerticalAlign="Middle" />
        <RowStyle BorderStyle="None" HorizontalAlign="Left" />
        <Columns>
            <asp:BoundField DataField="product_id" HeaderText="#" />
            <asp:BoundField DataField="product_name" HeaderText="Product Name" />
            <asp:TemplateField HeaderText="Edit" ShowHeader="False">
                <ItemTemplate>
                    <asp:Button ID="btnEdit" runat="server" CausesValidation="false" CommandArgument='<%# Eval("product_id") %>' CommandName="Edit" Text="Edit" OnClick="BtnEdit_Click" />
                </ItemTemplate>
                <ControlStyle BackColor="LightBlue" BorderColor="LightBlue" BorderStyle="Solid" CssClass="btn btn-edit" Height="2.5em" />
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Delete" ShowHeader="False">
                <ControlStyle ForeColor="White" BorderStyle="Solid" CssClass="btn btn-red" Height="2.5em"  />
                <ItemTemplate>
                    <asp:Button ID="btnDelete" runat="server" CausesValidation="false" CommandArgument='<%# Eval("product_id") %>' OnClientClick="ConfirmDelete()" CommandName="Delete" Text="Delete" OnClick="BtnDelete_Click" />
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
    </asp:GridView>
</asp:Content>
