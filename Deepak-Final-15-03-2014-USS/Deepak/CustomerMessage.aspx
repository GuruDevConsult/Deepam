<%@ page title="" language="C#" masterpagefile="~/AppMaster.master" autoeventwireup="true" inherits="CustomerMessage, App_Web_zwikzsdt" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="PageContent" runat="Server">
    <cc1:ToolkitScriptManager ID="Too" runat="server">
    </cc1:ToolkitScriptManager>
    <div id="Page">
        <div class="three-col-new">
            <asp:Label ID="lblResult" runat="server"></asp:Label>
            <div class="ControlsWrapper1">
                <div>
                    <asp:Label ID="lblNumber" runat="server" Text="Mobile No"></asp:Label>
                    <asp:TextBox ID="txtNumber" runat="server" TabIndex="1"></asp:TextBox>
                </div>
            </div>
            <div class="ControlsWrapper1">
                <div>
                    <asp:Label ID="lblMsg" runat="server" Text="Message"></asp:Label>
                    <asp:TextBox ID="txtMsg" runat="server" TextMode="MultiLine" TabIndex="2"></asp:TextBox>
                </div>
            </div>
        </div>
        <div class="ButtonsWrapper three-col-button" style="margin-top: 1%">
            <div class="btn_spaces">
                <asp:Button ID="btnSend" runat="server" Text="Send" TabIndex="3" CssClass="btnstyle"
                    OnClick="btnSend_Click" />
                <asp:Button ID="btnClear" runat="server" Text="Clear" TabIndex="4" CssClass="btnstyle" OnClick="btnClear_Click" />
                <asp:Button ID="btnView" runat="server" Text="View" TabIndex="5" CssClass="btnstyle" OnClick="btnView_Click">
                </asp:Button>
            </div>
        </div>
        <div style="display: none" id="Show_View_Det" runat="server">
            <div class="three-col-new">
                <div class="ControlsWrapper_view">
                    <div>
                        <asp:Label ID="lblFromDate" runat="server" Text="FromDate"></asp:Label>
                        <asp:TextBox ID="FromDate" TabIndex="17" runat="server"></asp:TextBox>
                        <cc1:CalendarExtender ID="CalendarExtender1" runat="server" Format="dd/MM/yyyy" TargetControlID="FromDate">
                        </cc1:CalendarExtender>
                    </div>
                </div>
                <div class="ControlsWrapper_view">
                    <div>
                        <asp:Label ID="lblToDate" runat="server" Text="ToDate"></asp:Label>
                        <asp:TextBox ID="ToDate" TabIndex="18" runat="server" AutoPostBack="True" OnTextChanged="ToDate_TextChanged"
                            onserverchange="ToDate_ServerChange"></asp:TextBox>
                        <cc1:CalendarExtender ID="CalendarExtender2" runat="server" Format="dd/MM/yyyy" TargetControlID="ToDate">
                        </cc1:CalendarExtender>
                    </div>
                </div>
                <div class="gridcol">
                    <asp:GridView ID="GrdCust" runat="server" AutoGenerateColumns="false" OnPageIndexChanging="GrdCust_PageIndexChanging"
                        PageSize="15" AllowPaging="True">
                        <Columns>
                            <asp:TemplateField>
                                <HeaderTemplate>
                                    <asp:CheckBox ID="ChkHeader" runat="server" AutoPostBack="True" OnCheckedChanged="ChkHeader_CheckedChanged" />
                                </HeaderTemplate>
                                <ItemTemplate>
                                    <asp:CheckBox ID="ChkItem" runat="server" Width="43px" />
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:BoundField DataField="Date" HeaderText="Date" />
                            <asp:BoundField DataField="MobileNo" HeaderText="MobileNo" />
                            <asp:BoundField DataField="Message" HeaderText="Message" />
                        </Columns>
                        <%--<Columns>--%>
                        <%--<asp:CheckBoxField HeaderText="Select" />--%>
                        <%--<asp:BoundField DataField="Date" HeaderText="Date" />
                        <asp:BoundField DataField="MobileNo" HeaderText="MobileNo" />
                        <asp:BoundField DataField="Message" HeaderText="Message" />--%>
                        <%--</Columns>--%>
                    </asp:GridView>
                </div>
                <div class="btn_spaces">
                    <asp:Button ID="btnResend" runat="server" Text="ReSend" TabIndex="12" CssClass="btnstyle"
                        OnClick="btnResend_Click" />
                </div>
            </div>
        </div>
    </div>
</asp:Content>
