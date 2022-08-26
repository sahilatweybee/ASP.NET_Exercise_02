<%@ Page Title="Assign Party Edit" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Assign_Party_Edit.aspx.cs" Inherits="ASP.NET_Exercise_02.Assign_Party_Edit" Theme="Default_Theme" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1>Assign Party Edit</h1>
    <br />
    
    <table style="width: 30%; margin: auto; text-align: right;">
        <tr>
            <td><asp:Label runat="server" Text="Party Name:" /></td>
            <td>
                <asp:DropDownList ID="SelectParty" runat="server">
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td><asp:Label runat="server" Text="Product Name:" /></td>
            <td><asp:DropDownList ID="SelectProduct" runat="server">
                </asp:DropDownList>
            </td>
        </tr>
    </table>
    <br />
    <asp:Button ID="UpdateAssignParty" runat="server" Text="update" SkinID="BtnUpdate" OnClick="UpdateAssignParty_Click"/>
    &nbsp;&nbsp;
    <asp:Button ID="CancelBtn" runat="server" Text="Cancel" SkinID="BtnCancel"/>
</asp:Content>
