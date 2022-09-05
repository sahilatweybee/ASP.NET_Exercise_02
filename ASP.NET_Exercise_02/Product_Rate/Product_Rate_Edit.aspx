<%@ Page Title="Product_Rate_Edit" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Product_Rate_Edit.aspx.cs" Inherits="ASP.NET_Exercise_02.WebForm2" Theme="Default_Theme" %>
<asp:Content ID="HeadContent" ContentPlaceHolderID="Head" runat="server" Visible="false">
    <script src="../scripts/Script.js"></script>
</asp:Content> 

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1>Product Rate Edit</h1>
    <asp:Label ID="lblMessage" runat="server" Font-Size="Small" Text=""></asp:Label>
    <br />
    <table style="margin: auto;">
        <tr>
            <td style="text-align: right;"><asp:Label runat="server" Text="Product Name:" /></td>
            <td style="text-align: left;">
                <asp:DropDownList ID="SelectProduct" runat="server">
                </asp:DropDownList> 
            </td>
        </tr>
        <tr>
            <td style="text-align: right;"><asp:Label runat="server" Text="Current Rate:" /></td>
            <td style="text-align: left;"><asp:TextBox ID="Curr_rate" runat="server"></asp:TextBox></td>
        </tr>
        <tr>
            <td style="text-align: right;"><asp:Label runat="server" Text="Date:" /></td>
            <td style="text-align: left;">
                <asp:TextBox ID="DateOfRate" runat="server"></asp:TextBox>
                <asp:ImageButton ID="Show_calander" runat="server" Height="1.7em" ImageUrl="~/Images/calendar_month_FILL0_wght300_GRAD200_opsz40.png" OnClick="Show_calander_Click"  />
                <asp:Calendar ID="Calendar" runat="server" Visible="False" OnSelectionChanged="Calendar_SelectionChanged" BackColor="White" BorderColor="#3366CC" BorderWidth="1px" CellPadding="1" FirstDayOfWeek="Sunday" Font-Names="Verdana" Font-Size="8pt" ForeColor="#003399" Height="150px" Width="234px">
                    <DayHeaderStyle BackColor="#99CCCC" ForeColor="#336666" Height="1px" />
                    <NextPrevStyle Font-Size="8pt" ForeColor="#CCCCFF" />
                    <OtherMonthDayStyle ForeColor="#999999" />
                    <SelectedDayStyle BackColor="#009999" Font-Bold="True" ForeColor="#CCFF99" />
                    <SelectorStyle BackColor="#99CCCC" ForeColor="#336666" />
                    <TitleStyle BackColor="#003399" BorderColor="#3366CC" BorderWidth="1px" Font-Bold="True" Font-Size="10pt" ForeColor="#CCCCFF" Height="25px" />
                    <TodayDayStyle BackColor="#99CCCC" ForeColor="White" />
                    <WeekendDayStyle BackColor="#CCCCFF" />
                </asp:Calendar>
            </td>
        </tr>
    </table>
    <br />
    <asp:Button ID="Update" runat="server" Text="Add" SkinID="BtnUpdate" OnClick="UpdateProductRate_Click"/>
    &nbsp;&nbsp;
    <asp:Button ID="CancelBtn" runat="server" Text="Cancel" SkinID="BtnCancel" OnClientClick="ConfirmExit()" OnClick="CancelBtn_Click"/>
</asp:Content>
