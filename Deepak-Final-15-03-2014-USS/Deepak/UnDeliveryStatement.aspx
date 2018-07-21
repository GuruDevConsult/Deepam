<%@ page language="C#" masterpagefile="~/AppMaster.master" autoeventwireup="true" inherits="UnDeliveryStatement, App_Web_zwikzsdt" title="Untitled Page" %>

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
                                <asp:Label ID="lblGodownNo" runat="server" Text="Godown No"></asp:Label>
                                <asp:DropDownList ID="ddlGodownNo" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlGodownNo_SelectedIndexChanged">
                                </asp:DropDownList>
                            </div>
                        </div>
                    </div>
                </div>
                <asp:HiddenField runat="server" ID="HiddenField1" />
                <asp:HiddenField runat="server" ID="hidDeliveryDate" />
                <div style="display: none; margin-top: 100px" id="DisplayCrysRep" runat="server">
                    <div>
                        <a href="UnDeliveryStatement.aspx">
                            <img src="App_Themes/Images/Back.png" style="width: 125px; height: 25px" /></a></div>
                    <CR:CrystalReportViewer ID="CRViewer" runat="server" AutoDataBind="true" />
                </div>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
