<%@ page title="" language="C#" masterpagefile="~/AppMaster.master" autoeventwireup="true" inherits="CustomerMessageReport, App_Web_zwikzsdt" %>

<%@ Register Assembly="CrystalDecisions.Web, Version=10.5.3700.0, Culture=neutral, PublicKeyToken=692fbea5521e1304"
    Namespace="CrystalDecisions.Web" TagPrefix="CR" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="PageContent" runat="Server">
    <cc1:ToolkitScriptManager ID="Too" runat="server">
    </cc1:ToolkitScriptManager>
    <div id="Page">
        <div style="display: block" id="Block_MainPage" runat="server">
            <div class="three-col-new">
                <asp:Label runat="server" ID="lblResult" Text="result" ForeColor="#FF3300"></asp:Label>
                <div class="ControlsWrapper1">
                    <div>
                        <asp:Label ID="lblFDate" runat="server" Text="From Date"></asp:Label>
                        <asp:TextBox ID="FromDate" TabIndex="1" onkeypress="return isNumberKey(event)" MaxLength="20"
                            runat="server" AutoPostBack="True"></asp:TextBox>
                        <cc1:CalendarExtender ID="CalendarExtender2" runat="server" Format="dd/MM/yyyy" TargetControlID="FromDate"
                            CssClass="cal_Theme">
                        </cc1:CalendarExtender>
                    </div>
                </div>
                <div class="ControlsWrapper1">
                    <div>
                        <asp:Label ID="lblToDate" runat="server" Text="ToDate"></asp:Label>
                        <asp:TextBox ID="ToDate" TabIndex="1" onkeypress="return isNumberKey(event)" MaxLength="20"
                            runat="server" AutoPostBack="True" OnTextChanged="ToDate_TextChanged"></asp:TextBox>
                        <cc1:CalendarExtender ID="CalendarExtender1" runat="server" Format="dd/MM/yyyy" TargetControlID="ToDate"
                            CssClass="cal_Theme">
                        </cc1:CalendarExtender>
                    </div>
                </div>
            </div>
        </div>
        <div style="display: none; margin-top: 100px" id="DisplayCrysRep" runat="server">
            <div>
                <a href="CustomerMessageReport.aspx">
                    <img src="App_Themes/Images/Back.png" style="width: 125px; height: 25px" /></a></div>
            <CR:CrystalReportViewer ID="CRViewer" runat="server" AutoDataBind="true" />
        </div>
    </div>
</asp:Content>
