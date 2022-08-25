<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Assign_Party_Edit.aspx.cs" Inherits="ASP.NET_Exercise_02.Assign_Party_Edit" Theme="Default_Theme" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1>Assign Party Edit</h1>
    <br />
    <asp:Label runat="server" Text="Party Name:" />
    &nbsp;&nbsp;
    <asp:DropDownList ID="SelectParty" runat="server" Height="2em" Width="150px" style="border-radius: 0.3em" EnableViewState="true">
    </asp:DropDownList>
    <br />
    <asp:Label runat="server" Text="Product Name:" />
    &nbsp;&nbsp;
    <asp:DropDownList ID="SelectProduct" runat="server" Height="2em" Width="150px" style="border-radius: 0.3em" EnableViewState="true">
    </asp:DropDownList>
    <br />
    <br />
    <asp:Button ID="UpdateAssignParty" runat="server" Text="update" SkinID="BtnUpdate" OnClick="UpdateAssignParty_Click"/>
    &nbsp;&nbsp;
    <asp:Button ID="CancelBtn" runat="server" Text="Cancel" SkinID="BtnCancel"/>
</asp:Content>
