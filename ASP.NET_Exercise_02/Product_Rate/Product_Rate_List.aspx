<%@ Page Title="Product Rate List" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Product_Rate_List.aspx.cs" Inherits="ASP.NET_Exercise_02.Produce_Rate" Theme="Default_Theme" MaintainScrollPositionOnPostback="true" %>
<asp:Content ID="HeadContent" ContentPlaceHolderID="Head" runat="server" Visible="false">
    <script src="../Script.js"></script>
</asp:Content> 

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1>Product Rate List</h1>
    <asp:Label ID="lblError" runat="server" Font-Size="Small" Text=""></asp:Label>
    <asp:Button ID="Add_Party" runat="server" Text="Add New aproductRate" CssClass="addBtn btn" SkinID="Button" OnClick="Add_Party_Click" />
    <asp:GridView ID="RateGrid" runat="server" CssClass="table" AutoGenerateColumns="False" Width="100%">
        <HeaderStyle Font-Bold="true" />
        <Columns>
            <asp:BoundField DataField="rate_id" HeaderText="#" />
            <asp:BoundField DataField="product_name" HeaderText="Product Name" />
            <asp:BoundField DataField="rate" HeaderText="Rate" />
            <asp:BoundField DataField="date_of_rate" HeaderText="Date of Rate" />
            <asp:TemplateField HeaderText="Edit" ShowHeader="False">
                <ItemTemplate>
                    <asp:Button ID="btnEdit" runat="server" CausesValidation="false" CommandArgument='<%# Eval("rate_id") %>' CommandName="Edit" Text="Edit" OnClick="BtnEdit_Click" />
                </ItemTemplate>
                <ControlStyle BackColor="LightBlue" BorderColor="LightBlue" BorderStyle="Solid" CssClass="btn btn-edit" Height="2.5em" />
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Delete" ShowHeader="False">
                <ControlStyle ForeColor="White" BorderStyle="Solid" CssClass="btn btn-red" Height="2.5em"  />
                <ItemTemplate>
                    <asp:Button ID="btnDelete" runat="server" CausesValidation="false" CommandArgument='<%# Eval("rate_id") %>' OnClientClick="ConfirmDelete()" CommandName="Delete" Text="Delete" OnClick="BtnDelete_Click" />
                </ItemTemplate>
            </asp:TemplateField></Columns>
        <HeaderStyle Font-Bold="True" HorizontalAlign="Left" VerticalAlign="Middle" />
        <RowStyle BorderStyle="None" HorizontalAlign="Left" />
    </asp:GridView>
</asp:Content>
