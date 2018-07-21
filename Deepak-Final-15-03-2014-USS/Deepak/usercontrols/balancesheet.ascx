<%@ control language="C#" autoeventwireup="true" inherits="usercontrols_balancesheet, App_Web_kyla4g6h" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<link href="App_Themes/Default_Themes/Form-Style.css" rel="stylesheet" type="text/css" />
<table style="width: 950px;">
    <tr>
        <td style="width: 50px;">
        </td>
        <td>
        </td>
        <td>
            <asp:Label ID="lblStartDate" runat="server" Text="Start date:"></asp:Label>
        </td>
        <td style="width: 100px;">
            <asp:TextBox ID="txtStartDate" runat="server"></asp:TextBox>
            <cc1:CalendarExtender ID="CalendarExtender1" runat="server" TargetControlID="txtStartDate"
                Format="dd/MM/yyyy" CssClass="cal_Theme">
            </cc1:CalendarExtender>
        </td>
        <td>
            <asp:Label ID="lblEndDate" Text="End date:" runat="server"></asp:Label>
        </td>
        <td>
            <asp:TextBox ID="txtEndDate" runat="server" OnTextChanged="txtEndDate_TextChanged"
                AutoPostBack="True"></asp:TextBox>
            <cc1:CalendarExtender ID="CalendarExtender2" runat="server" TargetControlID="txtEndDate"
                Format="dd/MM/yyyy" CssClass="cal_Theme">
            </cc1:CalendarExtender>
        </td>
        <td style="width: 126px;">
            <%-- <asp:Button ID="btnSearch" runat="server" Text="Search" CssClass="btnstyle" Width="80px"
                OnClick="btnSearch_Click" />--%>
            <asp:Button ID="btnClear" runat="server" Text="Clear" CssClass="btnstyle" Width="80px"
                OnClick="btnClear_Click" />
            <asp:Button ID="btnPrint" runat="server" Text="Print" CssClass="btnstyle" Width="80px"
                OnClick="btnPrint_Click" />
        </td>
    </tr>
</table>
<table style="width: 950px;">
    <tr>
        <td align="right" width="50%">
            <asp:Label ID="lblTBTitle" runat="server" Text="Balance Sheet  " Font-Bold="True"></asp:Label>
        </td>
        <td align="left" width="50%">
            <asp:Label ID="lblTBYear" runat="server" Font-Bold="True"></asp:Label>
        </td>
    </tr>
</table>
<table style="width: 950px;">
    <tr>
        <td>
            <asp:GridView ID="grdBalanceSheet" EmptyDataRowStyle-HorizontalAlign="Center" runat="server"
                Width="100%" EmptyDataText="No data found" AutoGenerateColumns="false">
                <EmptyDataRowStyle HorizontalAlign="Center"></EmptyDataRowStyle>
                <Columns>
                    <%--<asp:TemplateField HeaderText="Date" ItemStyle-Width="120px">
                        <ItemTemplate>
                            <asp:Label ID="lblDate" runat="server" Text='<%# Bind("Date") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>--%>
                    <asp:TemplateField HeaderText="Particular">
                        <ItemTemplate>
                            <asp:Label ID="lblParticular" runat="server" Text='<%# Bind("Particular") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="ASSETS" ItemStyle-Width="120px" ItemStyle-HorizontalAlign="Right">
                        <ItemTemplate>
                            <asp:Label ID="lblDr" runat="server" Text='<%# Bind("Dr") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="LIABILITIES" ItemStyle-Width="120px" ItemStyle-HorizontalAlign="Right">
                        <ItemTemplate>
                            <asp:Label ID="lblCr" runat="server" Text='<%# Bind("Cr") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
        </td>
    </tr>
</table>
<table style="width: 950px;">
    <tr>
        <td>
            <asp:Label ID="lblTotal" runat="server"></asp:Label>
        </td>
        <td width="120px" align="right">
            <asp:Label ID="lblDrTotal" runat="server"></asp:Label>
        </td>
        <td width="120px" align="right">
            <asp:Label ID="lblCrTotal" runat="server"></asp:Label>
        </td>
    </tr>
</table>
