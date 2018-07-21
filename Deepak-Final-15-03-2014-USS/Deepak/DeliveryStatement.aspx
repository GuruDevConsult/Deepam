<%@ page language="C#" masterpagefile="~/AppMaster.master" autoeventwireup="true" inherits="DeliveryStatement, App_Web_zwikzsdt" title="Deepak Roadways" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<%@ Register Assembly="CrystalDecisions.Web, Version=10.5.3700.0, Culture=neutral, PublicKeyToken=692fbea5521e1304"
    Namespace="CrystalDecisions.Web" TagPrefix="CR" %>
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
                                <asp:Label ID="lblNo" runat="server" Text="No"></asp:Label>
                                <asp:TextBox ID="txtNo" TabIndex="1" MaxLength="20" runat="server"></asp:TextBox>
                            </div>
                            <div>
                                <asp:Label ID="lblDeliveryDate" runat="server" Text="Delivery Date"></asp:Label>
                                <asp:TextBox ID="DeliveryDate" TabIndex="2" onkeypress="return isNumberKey(event);"
                                    MaxLength="20" runat="server" AutoPostBack="True" OnTextChanged="DeliveryDate_TextChanged"></asp:TextBox>
                                <cc1:CalendarExtender ID="CalendarExtender4" Format="dd/MM/yyyy" runat="server" TargetControlID="DeliveryDate"
                                    CssClass="cal_Theme">
                                </cc1:CalendarExtender>
                            </div>
                        </div>
                    </div>
                    <asp:HiddenField runat="server" ID="HiddenField1" />
                    <asp:HiddenField runat="server" ID="hidDeliveryDate" />
                </div>
                <div style="display: none; margin-top: 100px" id="DisplayCrysRep" runat="server">
                <div>
                <a href="DeliveryStatement.aspx">
                    <img src="App_Themes/Images/Back.png" style="width: 125px; height: 25px" /></a></div>
                    <CR:CrystalReportViewer ID="CRViewer" runat="server" AutoDataBind="true" PrintMode="ActiveX"
                        DisplayGroupTree="true" />
                    <%--<triggers> <cc1:PostBackTrigger ControlID="CRViewer"/></triggers>--%>
                </div>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
