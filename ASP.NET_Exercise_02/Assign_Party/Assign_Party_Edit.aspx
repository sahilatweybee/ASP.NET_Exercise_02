<%@ Page Title="Assign Party Edit" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Assign_Party_Edit.aspx.cs" Inherits="ASP.NET_Exercise_02.Assign_Party_Edit" Theme="Default_Theme" %>
<asp:Content ID="HeadContent" ContentPlaceHolderID="Head" runat="server" Visible="false">
    <script src="../scripts/Script.js"></script>
    <script src="../scripts/Script.js"></script>
</asp:Content> 

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1><%=Request.QueryString["ID"] != null ? "Assign Party Edit" : "Assign Party Add" %></h1>
    <asp:Label ID="lblMessage" runat="server" Font-Size="Medium" Text=""></asp:Label>
    <br />
    
    <table class="table-edit">
        <tr>
            <td><asp:Label runat="server" Text="Party Name:" /></td>
            <td>
                <asp:DropDownList ID="SelectParty" runat="server">
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td><asp:Label runat="server" Text="Product Name:" /></td>
            <td>
                <asp:DropDownList ID="SelectProduct" runat="server">
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td style="text-align: center">
                <br />
                <asp:Button ID="Update" runat="server" Text="Add" SkinID="BtnUpdate" OnClick="UpdateAssignParty_Click" style="width: 57px"/>
            </td>
            <td>
                <br />
                <asp:Button ID="CancelBtn" runat="server" Text="Cancel" SkinID="BtnCancel" OnClientClick="ConfirmExit()" OnClick="CancelBtn_Click"/>
            </td>
        </tr>
    </table>
</asp:Content>
