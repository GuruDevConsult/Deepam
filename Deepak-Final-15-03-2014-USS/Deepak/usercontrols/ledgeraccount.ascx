<%@ control language="C#" autoeventwireup="true" inherits="usercontrols_ledgeraccount, App_Web_kyla4g6h" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
    <link href="App_Themes/Default_Themes/Form-Style.css" rel="stylesheet" type="text/css" />
    
<%--    <cc1:ToolkitScriptManager ID="Too" runat="server"></cc1:ToolkitScriptManager>--%>

<table style="width: 950px;">
    <tr>
        <td>
            <asp:Label ID="lblStartDate" Text="Start date:" runat="server"></asp:Label>
        </td>
        <td style="width: 100px;">
            <asp:TextBox ID="txtStartDate" runat="server" TabIndex="1"></asp:TextBox>
            <cc1:calendarextender ID="CalendarExtender1" runat="server" TargetControlID="txtStartDate" Format="dd/MM/yyyy" CssClass="cal_Theme"></cc1:calendarextender>
        </td>
        <td>
            <asp:Label ID="Label1" Text="End date:" runat="server"></asp:Label>
        </td>
        <td style="width: 100px;">
            <asp:TextBox ID="txtEndDate" runat="server" AutoPostBack="True" 
                ontextchanged="txtEndDate_TextChanged" TabIndex="2"></asp:TextBox>
            <cc1:calendarextender ID="CalendarExtender2" runat="server" TargetControlID="txtEndDate" Format="dd/MM/yyyy" CssClass="cal_Theme"></cc1:calendarextender>
            
        </td>
        <td>
            <asp:Label ID="lblAccount" runat="server" Text="Account:"></asp:Label>
        </td>
        <td>
            <asp:DropDownList ID="ddlAccount" DataTextField="Name" DataValueField="Id" Width="167px"
                runat="server" AutoPostBack="true" 
                onselectedindexchanged="ddlAccount_SelectedIndexChanged" TabIndex="3">
                <asp:ListItem></asp:ListItem>
            </asp:DropDownList>
        </td>
        <td style="width: 126px;">
           <%-- <asp:Button ID="btnSearch" runat="server" Text="Search" CssClass="btnstyle"  Width="80px" OnClick="btnSearch_Click" />--%>
            <asp:Button ID="btnClear" runat="server" Text="Clear" CssClass="btnstyle" TabIndex="4" Width="80px" OnClick="btnClear_Click" />
            <asp:Button ID="Button1" runat="server" Text="Print" CssClass="btnstyle"  TabIndex="5"
                Width="80px" onclick="Button1_Click"  />
        </td>
    </tr>
</table>

<table style="width: 950px;">
    <tr>
        <td>
            <asp:GridView ID="grdLedgerAccounts" EmptyDataRowStyle-HorizontalAlign="Center" runat="server"
                Width="100%" EmptyDataText="No data found" AutoGenerateColumns="false">
                <EmptyDataRowStyle HorizontalAlign="Center"></EmptyDataRowStyle>
                <Columns>
                    <asp:TemplateField HeaderText="Date" ItemStyle-Width="90px">
                        <ItemTemplate>
                            <asp:Label ID="lblDate" runat="server" Text='<%# Bind("Date") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Particular">
                        <ItemTemplate>
                            <asp:Label ID="lblParticular" runat="server" Text='<%# Bind("Particular") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Paid Date" ItemStyle-Width="90px">
                        <ItemTemplate>
                            <asp:Label ID="lblDate" runat="server" Text='<%# Bind("Date1") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Particular1">
                        <ItemTemplate>
                            <asp:Label ID="lblParticular1" runat="server" Text='<%# Bind("Particular1") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Sh.Amount">
                        <ItemTemplate>
                            <asp:Label ID="lblParticular1" runat="server" Text='<%# Bind("ShortAmount") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Cr" ItemStyle-Width="90px" ItemStyle-HorizontalAlign="Right">
                        <ItemTemplate>
                            <asp:Label ID="lblCr" runat="server" Text='<%# Bind("Cr") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Dr" ItemStyle-Width="90px" ItemStyle-HorizontalAlign="Right">
                        <ItemTemplate>
                            <asp:Label ID="lblDr" runat="server" Text='<%# Bind("Dr") %>'></asp:Label>
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
            <asp:Label ID="lblCrTotal" runat="server"></asp:Label>
        </td>
        <td width="120px" align="right">
            <asp:Label ID="lblDrTotal" runat="server"></asp:Label>
        </td>
    </tr>
</table>
