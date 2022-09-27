<%@ Page Title="Product Edit" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Product_Edit.aspx.cs" Inherits="ASP.NET_Exercise_02.Product_Edit" Theme="Default_Theme" %>

<asp:Content ID="HeadContent" ContentPlaceHolderID="Head" runat="server" Visible="false">
    <script src="../scripts/Script.js"></script>
</asp:Content>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1><%=Request.QueryString["ID"]!=null ? "Product Edit" : "Product Add" %></h1>
    <asp:Label ID="lblMessage" runat="server" Font-Size="Medium" Text=""></asp:Label>
    <br />
    <table class="table-edit">
        <tr style="text-align: left;">
            <td>
                <asp:Label runat="server" Text="Product Name:" />
            </td>
            <td>
                <asp:TextBox ID="Product_name" runat="server">abc</asp:TextBox>
            </td>
        </tr>
        <tr style="text-align: left;">
            <td style="text-align:center;">
                <br />
                <asp:Button ID="Update" runat="server" Text="Add" SkinID="BtnUpdate" OnClick="UpdateProduct_Click" />
            </td>
            <td>
                <br />
                <asp:Button ID="CancelBtn" runat="server" Text="Cancel" SkinID="BtnCancel" OnClientClick="ConfirmExit()" OnClick="CancelBtn_Click" />
            </td>
        </tr>
    </table>
</asp:Content>
