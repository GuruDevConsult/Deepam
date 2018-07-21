<%@ page language="C#" autoeventwireup="true" inherits="AccountUI.accounts, App_Web_j2s_bpzk" enableeventvalidation="false" %>

<%@ Register Src="~/usercontrols/createuser.ascx" TagName="UCCreateUser" TagPrefix="CU" %>
<%@ Register Src="~/usercontrols/createcompany.ascx" TagName="UCCreateCompany" TagPrefix="CC" %>
<%@ Register Src="~/usercontrols/managecompany.ascx" TagName="UCManageCompany" TagPrefix="MC" %>
<%@ Register Src="~/usercontrols/createaccount.ascx" TagName="UCCreateAccount" TagPrefix="CA" %>
<%@ Register Src="~/usercontrols/createjournalentry.ascx" TagName="UCCreateJournalEntry"
    TagPrefix="CJE" %>
<%@ Register Src="~/usercontrols/managejournalentry.ascx" TagName="UCManageJournalEntry"
    TagPrefix="MJE" %>
<%@ Register Src="~/usercontrols/ledgeraccount.ascx" TagName="UCLedgerAccount" TagPrefix="LA" %>
<%@ Register Src="~/usercontrols/trialbalance.ascx" TagName="UCTrialBalance" TagPrefix="TB" %>
<%@ Register Src="~/usercontrols/balancesheet.ascx" TagName="UCBalanceSheet" TagPrefix="BS" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="App_Themes/Default_Themes/Form-Style.css" rel="stylesheet" type="text/css" />
    <style type="text/css">
        body
        {
            margin: 0 auto;
            padding: 0;
            font-size: 14px;
            font-weight: bold;
            font-family: "Trebuchet MS" ,arial, verdana, helvetica;
            color: #003f81;
            background-color: #eeede9;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <table>
        <tr>
            <td>
                <%--<table style="width: 1220px; height: 100px;" border="1">
                    <tr>
                        <td>
                        </td>
                    </tr>
                </table>--%>
                <table border="1">
                    <tr>
                        <td style="width: 950px; height: 590px;" valign="top">
                            <asp:Label ID="lblTitle" runat="server" Font-Bold="True" Font-Size="Medium"></asp:Label>
                            <table>
                                <tr>
                                    <td>
                                        <CU:UCCreateUser ID="CreateUser" Visible="false" runat="server" />
                                        <CC:UCCreateCompany ID="CreateCompany" Visible="false" runat="server" />
                                        <MC:UCManageCompany ID="ManageCompany" Visible="false" runat="server" />
                                        <CA:UCCreateAccount ID="CreateAccount" Visible="false" runat="server" />
                                        <CJE:UCCreateJournalEntry ID="CreateJournalEntry" Visible="false" runat="server" />
                                        <MJE:UCManageJournalEntry ID="ManageJournalEntry" Visible="false" runat="server" />
                                        <LA:UCLedgerAccount ID="LedgerAccount" Visible="false" runat="server" />
                                        <TB:UCTrialBalance ID="TrialBalance" Visible="false" runat="server" />
                                        <BS:UCBalanceSheet ID="BalanceSheet" Visible="false" runat="server" />
                                    </td>
                                </tr>
                            </table>
                        </td>
                        <td style="width: 250px; height: 590px;" valign="top">
                            <%--<asp:Button ID="btnCreateUser" runat="server" Text="Create User" Width="250px" BorderStyle="Solid"
                                Height="25px" BackColor="#0474d2" OnClick="btnCreateUser_Click" Visible="false" />
                            <asp:Button ID="btnManageUser" runat="server" Text="Manage User" Width="250px" BorderStyle="Solid"
                                Height="25px" BackColor="#0474d2" Visible="false" />
                            <asp:Button ID="btnCreateCompany" runat="server" Text="Create Company" Width="250px"
                                BorderStyle="Solid" Height="25px" BackColor="#0474d2" OnClick="btnCreateCompany_Click" />
                            <asp:Button ID="btnManageCompany" runat="server" Text="Manage Company" Width="250px"
                                BorderStyle="Solid" Height="25px" BackColor="#0474d2" OnClick="btnManageCompany_Click" />
                            <asp:Button ID="btnCreateAccount" runat="server" Text="Create Account" Width="250px"
                                BorderStyle="Solid" Height="25px" BackColor="#0474d2" OnClick="btnCreateAccount_Click" />
                            <asp:Button ID="btnManageAccount" runat="server" Text="Manage Account" Width="250px"
                                BorderStyle="Solid" Height="25px" BackColor="#0474d2" OnClick="btnManageAccount_Click" />
                            <asp:Button ID="btnCreateJournalEntry" runat="server" Text="Create Journal Entry"
                                Width="250px" BorderStyle="Solid" Height="25px" BackColor="#0474d2" OnClick="btnCreateJournalEntry_Click" />
                            <asp:Button ID="btnManageJournalEntry" runat="server" Text="Manage Journal Entry"
                                Width="250px" BorderStyle="Solid" Height="25px" BackColor="#0474d2" OnClick="btnManageJournalEntry_Click" />--%>
                            <asp:Button ID="btnLedgerAccount" runat="server" Text="Ledger Account" Width="250px"
                                BorderStyle="Solid" Height="25px" BackColor="#0474d2" OnClick="btnLedgerAccount_Click" />
                            <asp:Button ID="btnTrialBalance" runat="server" Text="Trial balance" Width="250px"
                                BorderStyle="Solid" Height="25px" BackColor="#0474d2" OnClick="btnTrialBalance_Click" />
                            <asp:Button ID="btnBalanceSheet" runat="server" Text="Balance Sheet" Width="250px"
                                BorderStyle="Solid" Height="25px" BackColor="#0474d2" OnClick="btnBalanceSheet_Click" />
                            <asp:Button ID="btnLogout" runat="server" Text="Logout" Width="250px" BorderStyle="Solid"
                                Height="25px" ForeColor="AliceBlue" BackColor="#0474d2" OnClick="btnLogout_Click" />
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
    </table>
    <%@ register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1" %>
    <cc1:ToolkitScriptManager ID="Too" runat="server">
    </cc1:ToolkitScriptManager>
    <asp:HiddenField ID="hdnCreateAccount" runat="server" />
    </form>
</body>
</html>
