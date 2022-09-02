<%@ Page Title="Assign Party" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Assign_party_List.aspx.cs" Inherits="ASP.NET_Exercise_02.Assign_party" Theme="Default_Theme" MaintainScrollPositionOnPostback="true" %>
<asp:Content ID="HeadContent" ContentPlaceHolderID="Head" runat="server" Visible="false">
    <script src="../scripts/Script.js"></script>
</asp:Content> 

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1>Assign Party List</h1>
    <asp:Label ID="lblError" runat="server" Font-Size="Small" Text=""></asp:Label>
    <asp:ImageButton ImageUrl="~/Images/add_box_FILL0_wght500_GRAD200_opsz48.png" style="float:right" ImageAlign="AbsMiddle" runat="server" ID="Add_Party" runat="server" Text="Add New Party" CssClass="btn" OnClick="Add_Party_Click" />
    <asp:GridView ID="AssignPartyGrid" runat="server" CssClass="table" AutoGenerateColumns="False" Width="100%" >
        <HeaderStyle BackColor="DarkSlateBlue" BorderColor="DarkSlateBlue" ForeColor="White" Font-Bold="true" VerticalAlign="Middle"/>
        <AlternatingRowStyle BackColor="LightBlue" BorderColor="LightBlue"/>
        <RowStyle BackColor="LightCyan" BorderColor="LightCyan" BorderStyle="None" HorizontalAlign="Left" VerticalAlign="Middle" Height="1.5em"/>
        <Columns>
            <asp:BoundField DataField="assign_id" HeaderText="#" ItemStyle-HorizontalAlign="Center"/>
            <asp:BoundField DataField="party_name" HeaderText="Party Name" HeaderStyle-HorizontalAlign="Left"/>
            <asp:BoundField DataField="product_name" HeaderText="Product Name" HeaderStyle-HorizontalAlign="Left" />
            <asp:TemplateField HeaderText="Actions" ShowHeader="False">
                <ItemStyle HorizontalAlign="Center"/>
                <ControlStyle Height="2em"/>
                <ItemTemplate>
                    <asp:ImageButton ID="btnEdit" style="vertical-align:text-bottom;" ImageUrl="~/Images/edit_square_FILL0_wght500_GRAD200_opsz40.png" runat="server" CausesValidation="false" CommandArgument='<%# Eval("assign_id") %>' CommandName="Edit" OnClick="BtnEdit_Click" />
                    <asp:ImageButton ID="btnDelete" style="vertical-align:text-bottom;" ImageUrl="~/Images/delete_forever_FILL0_wght500_GRAD200_opsz40.png" runat="server" CausesValidation="false" ForeColor="White" CommandArgument='<%# Eval("assign_id") %>' OnClientClick="ConfirmDelete()" CommandName="Delete" OnClick="BtnDelete_Click" />
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
    </asp:GridView>
</asp:Content>
