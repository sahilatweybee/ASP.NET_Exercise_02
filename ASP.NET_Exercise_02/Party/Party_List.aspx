<%@ Page Title="Party List" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Party_List.aspx.cs" Inherits="ASP.NET_Exercise_02.WebForm1" Theme="Default_Theme" MaintainScrollPositionOnPostback="true" %>
<asp:Content ID="HeadContent" ContentPlaceHolderID="Head" runat="server" Visible="false">
    <script src="../scripts/Script.js"></script>
</asp:Content> 

<asp:Content ID="PartyContent" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1>Party List</h1>
    <asp:Label ID="lblError" runat="server" Font-Size="Small" Text=""></asp:Label>
    <asp:ImageButton ImageUrl="~/Images/add_box_FILL0_wght500_GRAD200_opsz48.png" style="float:right" ImageAlign="AbsMiddle" runat="server"  CssClass="btn" ID="Add_Party" runat="server" Text="Add New Party"  OnClick="Add_Party_Click" />
        <asp:GridView ID="PartyGrid" runat="server" CssClass="table" AutoGenerateColumns="False" Width="100%">
            <HeaderStyle BackColor="#666666" ForeColor="White" Font-Bold="true" HorizontalAlign="Center" VerticalAlign="Middle"  />
            <AlternatingRowStyle BackColor="#cccccc" BorderColor="#cccccc"/>
            <RowStyle BackColor="White" BorderColor="White" BorderStyle="None" HorizontalAlign="Left" />
            <Columns>
                <asp:BoundField DataField="party_id" HeaderText="#" ItemStyle-HorizontalAlign="Center"/>
                <asp:BoundField DataField="party_name" HeaderText="Party Name" />
                <asp:TemplateField HeaderText="Actions" ShowHeader="False">
                <ItemStyle HorizontalAlign="Center" />
                <ControlStyle Height="2em" />
                <ItemTemplate>
                    <asp:ImageButton ID="btnEdit" style="vertical-align:text-bottom;" ImageUrl="~/Images/edit_square_FILL0_wght500_GRAD200_opsz40.png" runat="server" CausesValidation="false" CommandArgument='<%# Eval("party_id") %>' CommandName="Edit" OnClick="BtnEdit_Click" />
                    <asp:ImageButton ID="btnDelete" style="vertical-align:text-bottom;" ImageUrl="~/Images/delete_forever_FILL0_wght500_GRAD200_opsz40.png" runat="server" CausesValidation="false" ForeColor="White" CommandArgument='<%# Eval("party_id") %>' OnClientClick="ConfirmDelete()" CommandName="Delete" OnClick="BtnDelete_Click" />
                </ItemTemplate>
            </asp:TemplateField>
            </Columns>
    </asp:GridView>
</asp:Content>