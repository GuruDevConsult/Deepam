<%@ page language="C#" masterpagefile="~/AppMaster.master" autoeventwireup="true" inherits="MonthlyTrialBalance, App_Web_utcvgpzk" title="Deepak Roadways" %>

<%@ Register Assembly="CrystalDecisions.Web, Version=10.5.3700.0, Culture=neutral, PublicKeyToken=692fbea5521e1304"
    Namespace="CrystalDecisions.Web" TagPrefix="CR" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="PageContent" runat="Server">
    <cc1:ToolkitScriptManager ID="Too" runat="server">
    </cc1:ToolkitScriptManager>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <div id="Page">
                <div style="display: block" id="Block_MainPage" runat="server">
                    <div class="three-col-new">
                        <asp:Label runat="server" ID="lblResult" ForeColor="#FF3300"></asp:Label>
                        <div class="ControlsWrapper1">
                            <div>
                                <asp:Label ID="lblDate" runat="server" Text="Date"></asp:Label>
                                <asp:TextBox ID="Date" TabIndex="2" onkeypress="return isNumberKey(event);" MaxLength="20"
                                    runat="server" AutoPostBack="True" OnTextChanged="Date_TextChanged"></asp:TextBox>
                                <cc1:CalendarExtender ID="CalendarExtender4" Format="dd/MM/yyyy" runat="server" TargetControlID="Date"
                                    CssClass="cal_Theme">
                                </cc1:CalendarExtender>
                            </div>
                            <%--<div>
                            <asp:GridView ID="GridMonthTrial" EmptyDataRowStyle-HorizontalAlign="Center" runat="server"
                                Width="100%" EmptyDataText="No data found" AutoGenerateColumns="false">
                                <EmptyDataRowStyle HorizontalAlign="Center"></EmptyDataRowStyle>
                                <Columns>
                                    <asp:TemplateField HeaderText="Particular">
                                        <ItemTemplate>
                                            <asp:Label ID="lblParticular" runat="server" Text='<%# Bind("Particular") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Cr" ItemStyle-Width="120px" ItemStyle-HorizontalAlign="Right">
                                        <ItemTemplate>
                                            <asp:Label ID="lblCr" runat="server" Text='<%# Bind("Cr") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Dr" ItemStyle-Width="120px" ItemStyle-HorizontalAlign="Right">
                                        <ItemTemplate>
                                            <asp:Label ID="lblDr" runat="server" Text='<%# Bind("Dr") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                </Columns>
                            </asp:GridView>
                        </div>--%>
                        </div>
                    </div>
                </div>
                <div style="display: none; margin-top: 100px" id="DisplayCrysRep" runat="server">
                    <div>
                        <a href="MonthlyTrialBalance.aspx">
                            <img src="App_Themes/Images/Back.png" style="width: 125px; height: 25px" /></a></div>
                    <CR:CrystalReportViewer ID="CRViewer" runat="server" AutoDataBind="true" />
                </div>
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
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
