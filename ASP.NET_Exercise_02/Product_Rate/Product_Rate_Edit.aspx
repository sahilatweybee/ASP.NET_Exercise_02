<%@ Page Title="Product_Rate_Edit" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Product_Rate_Edit.aspx.cs" Inherits="ASP.NET_Exercise_02.WebForm2" Theme="Default_Theme" %>
<asp:Content ID="HeadContent" ContentPlaceHolderID="Head" runat="server" Visible="false">
    <script src="../Script.js"></script>
</asp:Content> 

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1>Product Rate Edit</h1>
    <asp:Label ID="lblError" runat="server" Font-Size="Small" Text=""></asp:Label>
    <br />
    <table style="width: 30%; margin: auto; text-align: right;">
        <tr>
            <td><asp:Label runat="server" Text="Product Name:" /></td>
            <td>
                <asp:DropDownList ID="SelectProduct" runat="server">
                </asp:DropDownList> 
            </td>
        </tr>
        <tr>
            <td><asp:Label runat="server" Text="Current Rate:" /></td>
            <td><asp:TextBox ID="Curr_rate" runat="server"></asp:TextBox></td>
        </tr>
        <tr>
            <td><asp:Label runat="server" Text="Date:" /></td>
            <td><asp:TextBox ID="DateOfRate" runat="server"></asp:TextBox></td>
        </tr>
    </table>
    <br />
    <asp:Button ID="UpdateProductRate" runat="server" Text="update" SkinID="BtnUpdate" OnClick="UpdateProductRate_Click"/>
    &nbsp;&nbsp;
    <asp:Button ID="CancelBtn" runat="server" Text="Cancel" SkinID="BtnCancel" OnClientClick="ConfirmExit()" OnClick="CancelBtn_Click"/>
</asp:Content>
