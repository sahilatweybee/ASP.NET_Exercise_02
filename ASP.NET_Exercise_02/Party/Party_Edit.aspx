<%@ Page Title="Party Edit" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Party_Edit.aspx.cs" Inherits="ASP.NET_Exercise_02.Party_Edit" Theme="Default_Theme" %>

<asp:Content ID="HeadContent" ContentPlaceHolderID="Head" runat="server" Visible="false">
    <script src="../scripts/Script.js"></script>
</asp:Content>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1><%=Request.QueryString["ID"]!=null ? "Party Edit" : "Party Add" %></h1>
    <asp:Label ID="lblMessage" runat="server" Font-Size="Medium" Text=""></asp:Label>
    <br />
    <table class="table-edit">
        <tr>
            <td>
                <asp:Label runat="server" Text="Party Name:" />
            </td>
            <td>
                <asp:TextBox ID="Party_name" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td style="text-align: center;">
                <br />
                <asp:Button ID="Update" runat="server" Text="Add" SkinID="BtnUpdate" OnClick="UpdateParty_Click" />
            </td>
            <td>
                <br />
                <asp:Button ID="CancelBtn" runat="server" Text="Cancel" SkinID="BtnCancel" OnClientClick="ConfirmExit()" OnClick="CancelBtn_Click" />
            </td>
        </tr>
    </table>
</asp:Content>
