<%@ page language="C#" masterpagefile="~/AppMaster.master" autoeventwireup="true" inherits="DeliverySlipReport, App_Web_zwikzsdt" title="Deepak Roadways" %>

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
                                <asp:Label ID="lblFromMRNo" runat="server" Text="From-MRNo"></asp:Label>
                                <asp:TextBox ID="FromMRNo" TabIndex="1" onkeypress="return isNumberKey(event);" MaxLength="20"
                                    runat="server"></asp:TextBox>
                            </div>
                        </div>
                        <div class="ControlsWrapper1">
                            <div>
                                <asp:Label ID="lblToMRNo" runat="server" Text="To-MRNo"></asp:Label>
                                <asp:TextBox ID="ToMRNo" TabIndex="2" onkeypress="return isNumberKey(event);" MaxLength="20"
                                    runat="server" AutoPostBack="true" OnTextChanged="ToMRNo_TextChanged"></asp:TextBox>
                            </div>
                        </div>
                    </div>
                </div>
                <div style="display: none; margin-top: 100px" id="DisplayCrysRep" runat="server">
                    <div>
                        <a href="DeliverySlipReport.aspx">
                            <img src="App_Themes/Images/Back.png" style="width: 125px; height: 25px" /></a></div>
                    <CR:CrystalReportViewer ID="CRViewer" runat="server" AutoDataBind="true" />
                </div>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
