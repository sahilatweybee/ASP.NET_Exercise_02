<%@ Page Title="Party List" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Party_List.aspx.cs" Inherits="ASP.NET_Exercise_02.WebForm1" Theme="Default_Theme" MaintainScrollPositionOnPostback="true" %>


<asp:Content ID="PartyContent" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1>Party List</h1>
    <div class="lbl-Msg">
        <asp:Label ID="lblMessage" runat="server" Font-Size="Medium" Text=""></asp:Label>
    </div>

    <asp:ImageButton ImageUrl="~/Images/add_box_FILL0_wght500_GRAD200_opsz48.png" Style="float: right" ImageAlign="AbsMiddle" runat="server" CssClass="btn" ID="Add_Party" Text="Add New Party" OnClick="Add_Party_Click" />
    <asp:GridView ID="PartyGrid" runat="server" CssClass="table" AutoGenerateColumns="False" Width="100%">
        <HeaderStyle BackColor="#3F51B5" BorderColor="#3F51B5" ForeColor="White" Font-Bold="true" VerticalAlign="Middle" />
        <AlternatingRowStyle BackColor="#D6DBFA" BorderColor="#D6DBFA" BorderStyle="None" />
        <RowStyle BackColor="#E8EAF6" BorderColor="#E8EAF6" BorderStyle="None" HorizontalAlign="Left" VerticalAlign="Middle" Height="1.5em" />
        <Columns>
            <asp:BoundField DataField="party_id" HeaderText="#" ItemStyle-HorizontalAlign="Center" />
            <asp:BoundField DataField="party_name" HeaderText="Party Name" HeaderStyle-HorizontalAlign="Left" />
            <asp:TemplateField HeaderText="Actions" ShowHeader="False">
                <ItemStyle HorizontalAlign="Center" CssClass="action-column" />
                <ControlStyle Height="2em" />
                <ItemTemplate>
                    <asp:ImageButton ID="btnEdit" Style="vertical-align: text-bottom;" ImageUrl="~/Images/edit_square_FILL0_wght500_GRAD200_opsz40.png" runat="server" CausesValidation="false" CommandArgument='<%# Eval("party_id") %>' CommandName="Edit" OnClick="BtnEdit_Click" />
                    <asp:ImageButton ID="btnDelete" Style="vertical-align: text-bottom;" ImageUrl="~/Images/delete_forever_FILL0_wght500_GRAD200_opsz40.png" runat="server" CausesValidation="false" ForeColor="White" CommandArgument='<%# Eval("party_id") %>' OnClientClick="ConfirmDelete()" CommandName="Delete" OnClick="BtnDelete_Click" />
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
    </asp:GridView>
</asp:Content>
