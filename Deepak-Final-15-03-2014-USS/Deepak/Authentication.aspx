<%@ page language="C#" masterpagefile="~/AppMaster.master" autoeventwireup="true" inherits="Authentication, App_Web_utcvgpzk" title="Authentication" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<%@ Register Assembly="System.Web.Extensions, Version=1.0.61025.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35"
    Namespace="System.Web.UI" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="PageContent" runat="Server">
    <asp:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server">
    </asp:ToolkitScriptManager>
    <link href="../App_Themes/Dafault_Themes/HeaderCssClass.css" rel="stylesheet" type="text/css" />
    <link href="../App_Themes/Dafault_Themes/ContentCssClass.css" rel="stylesheet" type="text/css" />
    <link href="../App_Themes/Dafault_Themes/HeaderSelectedCssClass.css" rel="stylesheet"
        type="text/css" />
    <div id="Page">
        <div class="three-col">
            <%--<div class="ControlsWrapper">        
             <div>
                <asp:Label ID="lblUserName" runat="server" Text="User Name"></asp:Label>
                <asp:DropDownList ID="UserName" runat="server">
                <asp:ListItem Text="--SELECT--" Value="--SELECT--"></asp:ListItem>
                </asp:DropDownList>
            </div>
         </div>--%>
            <div class="ControlsWrapper">
                <div>
                    <asp:Label ID="lblEmployeeName" runat="server" Text="Employee Name"></asp:Label>
                    <asp:DropDownList ID="EmployeeName" runat="server" OnSelectedIndexChanged="EmployeeName_SelectedIndexChanged"
                        AutoPostBack="True">
                        <asp:ListItem Text="--SELECT--" Value="--SELECT--"></asp:ListItem>
                    </asp:DropDownList>
                </div>
                <%-- <div>
             <asp:Button ID="btnTickAll" runat="server" Text="Select All" OnClick="btnTickAll_Click" />
            </div>   --%>
            </div>
        </div>
        <br />
        <div style="margin-left: 150px; margin-top: 70px">
            <asp:Accordion ID="Accordion1" runat="server" HeaderCssClass="Header" ContentCssClass="Content"
                HeaderSelectedCssClass="SelectedHeader" Font-Names="Verdana" Font-Size="10" BorderStyle="Solid"
                BorderWidth="2" FramesPerSecond="100" FadeTransitions="true" TransitionDuration="500"
                SuppressHeaderPostbacks="true" SelectedIndex="0" BackColor="Beige" Height="100px">
                <Panes>
                    <asp:AccordionPane runat="server" ID="AccordionPane2">
                        <Header>
                            Master
                        </Header>
                        <Content>
                            <div class="gridcol_inside_page">
                                <asp:GridView ID="GridViewMaster" runat="server" CellPadding="4" ForeColor="#ffffff"
                                    GridLines="None" AutoGenerateColumns="False">
                                    <Columns>
                                        <asp:TemplateField>
                                            <HeaderTemplate>
                                                <asp:CheckBox ID="checkall" runat="server" AutoPostBack="True" OnCheckedChanged="btnTickAll_Click" />
                                            </HeaderTemplate>
                                            <ItemTemplate>
                                                <asp:CheckBox ID="ChkItem" runat="server" Width="43px" Enabled="false" />
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:BoundField DataField="Master" HeaderText="ResourceName" />
                                        <asp:TemplateField HeaderText="All">
                                            <ItemTemplate>
                                                <asp:CheckBox ID="chkAll" runat="server" AutoPostBack="true" OnCheckedChanged="chkAll_CheckedChanged" />
                                            </ItemTemplate>
                                            <ItemStyle CssClass="TableData" HorizontalAlign="Center" />
                                            <FooterStyle CssClass="datafooter" />
                                            <HeaderStyle Width="10%" HorizontalAlign="Center" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Save">
                                            <ItemTemplate>
                                                <asp:CheckBox ID="chkSave" runat="server" AutoPostBack="true" OnCheckedChanged="chkCancel_CheckedChanged"
                                                    runat="server" />
                                            </ItemTemplate>
                                            <ItemStyle CssClass="TableData" HorizontalAlign="Center" />
                                            <FooterStyle CssClass="datafooter" />
                                            <HeaderStyle Width="10%" HorizontalAlign="Center" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Delete">
                                            <ItemTemplate>
                                                <asp:CheckBox ID="chkDelete" AutoPostBack="true" OnCheckedChanged="chkCancel_CheckedChanged"
                                                    runat="server" />
                                            </ItemTemplate>
                                            <ItemStyle CssClass="TableData" HorizontalAlign="Center" />
                                            <FooterStyle CssClass="datafooter" />
                                            <HeaderStyle Width="10%" HorizontalAlign="Center" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="View">
                                            <ItemTemplate>
                                                <asp:CheckBox ID="chkView" runat="server" AutoPostBack="true" OnCheckedChanged="chkView_CheckedChanged" />
                                            </ItemTemplate>
                                            <ItemStyle CssClass="TableData" HorizontalAlign="Center" />
                                            <FooterStyle CssClass="datafooter" />
                                            <HeaderStyle Width="10%" HorizontalAlign="Center" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Edit">
                                            <ItemTemplate>
                                                <asp:CheckBox ID="chkEdit" runat="server" AutoPostBack="true" OnCheckedChanged="chkCancel_CheckedChanged" />
                                            </ItemTemplate>
                                            <ItemStyle CssClass="TableData" HorizontalAlign="Center" />
                                            <FooterStyle CssClass="datafooter" />
                                            <HeaderStyle Width="10%" HorizontalAlign="Center" />
                                        </asp:TemplateField>
                                    </Columns>
                                    <FooterStyle BackColor="#5D7B9D" ForeColor="White" Font-Bold="True" />
                                    <RowStyle BackColor="#F7F6F3" ForeColor="#333333" BorderColor="PeachPuff" />
                                    <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                                    <PagerStyle ForeColor="White" HorizontalAlign="Center" BackColor="#284775" />
                                    <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                                    <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                                    <EditRowStyle BackColor="#999999" />
                                </asp:GridView>
                            </div>
                        </Content>
                    </asp:AccordionPane>
                </Panes>
                <Panes>
                    <asp:AccordionPane runat="server" ID="AccordionPane1">
                        <Header>
                            Booking Details</Header>
                        <Content>
                            <div class="gridcol_inside_page">
                                <asp:GridView ID="GridViewBookingDetails" runat="server" CellPadding="4" ForeColor="#333333"
                                    GridLines="None" AutoGenerateColumns="False">
                                    <Columns>
                                        <asp:TemplateField>
                                            <HeaderTemplate>
                                                <asp:CheckBox ID="checkall" runat="server" AutoPostBack="True" OnCheckedChanged="btnTickAll_Click" />
                                            </HeaderTemplate>
                                            <ItemTemplate>
                                                <asp:CheckBox ID="ChkItem" runat="server" Width="43px" Enabled="false" />
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:BoundField DataField="BOOKINGDETAILS" HeaderText="ResourceName" />
                                        <asp:TemplateField HeaderText="All">
                                            <ItemTemplate>
                                                <asp:CheckBox ID="chkAll" runat="server" AutoPostBack="true" OnCheckedChanged="chkAll_CheckedChanged" />
                                            </ItemTemplate>
                                            <ItemStyle CssClass="TableData" HorizontalAlign="Center" />
                                            <FooterStyle CssClass="datafooter" />
                                            <HeaderStyle Width="10%" HorizontalAlign="Center" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Save">
                                            <ItemTemplate>
                                                <asp:CheckBox ID="chkSave" runat="server" AutoPostBack="true" OnCheckedChanged="chkCancel_CheckedChanged"
                                                    runat="server" />
                                            </ItemTemplate>
                                            <ItemStyle CssClass="TableData" HorizontalAlign="Center" />
                                            <FooterStyle CssClass="datafooter" />
                                            <HeaderStyle Width="10%" HorizontalAlign="Center" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Delete">
                                            <ItemTemplate>
                                                <asp:CheckBox ID="chkDelete" AutoPostBack="true" OnCheckedChanged="chkCancel_CheckedChanged"
                                                    runat="server" />
                                            </ItemTemplate>
                                            <ItemStyle CssClass="TableData" HorizontalAlign="Center" />
                                            <FooterStyle CssClass="datafooter" />
                                            <HeaderStyle Width="10%" HorizontalAlign="Center" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="View">
                                            <ItemTemplate>
                                                <asp:CheckBox ID="chkView" runat="server" AutoPostBack="true" OnCheckedChanged="chkView_CheckedChanged" />
                                            </ItemTemplate>
                                            <ItemStyle CssClass="TableData" HorizontalAlign="Center" />
                                            <FooterStyle CssClass="datafooter" />
                                            <HeaderStyle Width="10%" HorizontalAlign="Center" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Edit">
                                            <ItemTemplate>
                                                <asp:CheckBox ID="chkEdit" runat="server" AutoPostBack="true" OnCheckedChanged="chkCancel_CheckedChanged" />
                                            </ItemTemplate>
                                            <ItemStyle CssClass="TableData" HorizontalAlign="Center" />
                                            <FooterStyle CssClass="datafooter" />
                                            <HeaderStyle Width="10%" HorizontalAlign="Center" />
                                        </asp:TemplateField>
                                    </Columns>
                                    <FooterStyle BackColor="#5D7B9D" ForeColor="White" Font-Bold="True" />
                                    <RowStyle BackColor="#F7F6F3" ForeColor="#333333" BorderColor="PeachPuff" />
                                    <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                                    <PagerStyle ForeColor="White" HorizontalAlign="Center" BackColor="#284775" />
                                    <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                                    <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                                    <EditRowStyle BackColor="#999999" />
                                </asp:GridView>
                            </div>
                        </Content>
                    </asp:AccordionPane>
                </Panes>
                <Panes>
                    <asp:AccordionPane runat="server" ID="AccordionPane3">
                        <Header>
                            Lorry A/C</Header>
                        <Content>
                            <div class="gridcol_inside_page">
                                <asp:GridView ID="GridViewLorryAC" runat="server" CellPadding="4" ForeColor="#333333"
                                    GridLines="None" AutoGenerateColumns="False">
                                    <Columns>
                                        <asp:TemplateField>
                                            <HeaderTemplate>
                                                <asp:CheckBox ID="checkall" runat="server" AutoPostBack="True" OnCheckedChanged="btnTickAll_Click" />
                                            </HeaderTemplate>
                                            <ItemTemplate>
                                                <asp:CheckBox ID="ChkItem" runat="server" Width="43px" Enabled="false" />
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:BoundField DataField="LorryChallan" HeaderText="ResourceName" />
                                        <asp:TemplateField HeaderText="All">
                                            <ItemTemplate>
                                                <asp:CheckBox ID="chkAll" runat="server" AutoPostBack="true" OnCheckedChanged="chkAll_CheckedChanged" />
                                            </ItemTemplate>
                                            <ItemStyle CssClass="TableData" HorizontalAlign="Center" />
                                            <FooterStyle CssClass="datafooter" />
                                            <HeaderStyle Width="10%" HorizontalAlign="Center" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Save">
                                            <ItemTemplate>
                                                <asp:CheckBox ID="chkSave" runat="server" AutoPostBack="true" OnCheckedChanged="chkCancel_CheckedChanged"
                                                    runat="server" />
                                            </ItemTemplate>
                                            <ItemStyle CssClass="TableData" HorizontalAlign="Center" />
                                            <FooterStyle CssClass="datafooter" />
                                            <HeaderStyle Width="10%" HorizontalAlign="Center" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Delete">
                                            <ItemTemplate>
                                                <asp:CheckBox ID="chkDelete" AutoPostBack="true" OnCheckedChanged="chkCancel_CheckedChanged"
                                                    runat="server" />
                                            </ItemTemplate>
                                            <ItemStyle CssClass="TableData" HorizontalAlign="Center" />
                                            <FooterStyle CssClass="datafooter" />
                                            <HeaderStyle Width="10%" HorizontalAlign="Center" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="View">
                                            <ItemTemplate>
                                                <asp:CheckBox ID="chkView" runat="server" AutoPostBack="true" OnCheckedChanged="chkView_CheckedChanged" />
                                            </ItemTemplate>
                                            <ItemStyle CssClass="TableData" HorizontalAlign="Center" />
                                            <FooterStyle CssClass="datafooter" />
                                            <HeaderStyle Width="10%" HorizontalAlign="Center" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Edit">
                                            <ItemTemplate>
                                                <asp:CheckBox ID="chkEdit" runat="server" AutoPostBack="true" OnCheckedChanged="chkCancel_CheckedChanged" />
                                            </ItemTemplate>
                                            <ItemStyle CssClass="TableData" HorizontalAlign="Center" />
                                            <FooterStyle CssClass="datafooter" />
                                            <HeaderStyle Width="10%" HorizontalAlign="Center" />
                                        </asp:TemplateField>
                                    </Columns>
                                    <FooterStyle BackColor="#5D7B9D" ForeColor="White" Font-Bold="True" />
                                    <RowStyle BackColor="#F7F6F3" ForeColor="#333333" BorderColor="PeachPuff" />
                                    <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                                    <PagerStyle ForeColor="White" HorizontalAlign="Center" BackColor="#284775" />
                                    <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                                    <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                                    <EditRowStyle BackColor="#999999" />
                                </asp:GridView>
                            </div>
                        </Content>
                    </asp:AccordionPane>
                </Panes>
                <Panes>
                    <asp:AccordionPane runat="server" ID="AccordionPane4">
                        <Header>
                            Delivery Slip</Header>
                        <Content>
                            <div class="gridcol_inside_page">
                                <asp:GridView ID="GridViewDeliverySlip" runat="server" CellPadding="4" ForeColor="#333333"
                                    GridLines="None" AutoGenerateColumns="False">
                                    <Columns>
                                        <asp:TemplateField>
                                            <HeaderTemplate>
                                                <asp:CheckBox ID="checkall" runat="server" AutoPostBack="True" OnCheckedChanged="btnTickAll_Click" />
                                            </HeaderTemplate>
                                            <ItemTemplate>
                                                <asp:CheckBox ID="ChkItem" runat="server" Width="43px" Enabled="false" />
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:BoundField DataField="DeliverySlip" HeaderText="ResourceName" />
                                        <asp:TemplateField HeaderText="All">
                                            <ItemTemplate>
                                                <asp:CheckBox ID="chkAll" runat="server" AutoPostBack="true" OnCheckedChanged="chkAll_CheckedChanged" />
                                            </ItemTemplate>
                                            <ItemStyle CssClass="TableData" HorizontalAlign="Center" />
                                            <FooterStyle CssClass="datafooter" />
                                            <HeaderStyle Width="10%" HorizontalAlign="Center" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Save">
                                            <ItemTemplate>
                                                <asp:CheckBox ID="chkSave" runat="server" AutoPostBack="true" OnCheckedChanged="chkCancel_CheckedChanged"
                                                    runat="server" />
                                            </ItemTemplate>
                                            <ItemStyle CssClass="TableData" HorizontalAlign="Center" />
                                            <FooterStyle CssClass="datafooter" />
                                            <HeaderStyle Width="10%" HorizontalAlign="Center" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Delete">
                                            <ItemTemplate>
                                                <asp:CheckBox ID="chkDelete" AutoPostBack="true" OnCheckedChanged="chkCancel_CheckedChanged"
                                                    runat="server" />
                                            </ItemTemplate>
                                            <ItemStyle CssClass="TableData" HorizontalAlign="Center" />
                                            <FooterStyle CssClass="datafooter" />
                                            <HeaderStyle Width="10%" HorizontalAlign="Center" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="View">
                                            <ItemTemplate>
                                                <asp:CheckBox ID="chkView" runat="server" AutoPostBack="true" OnCheckedChanged="chkView_CheckedChanged" />
                                            </ItemTemplate>
                                            <ItemStyle CssClass="TableData" HorizontalAlign="Center" />
                                            <FooterStyle CssClass="datafooter" />
                                            <HeaderStyle Width="10%" HorizontalAlign="Center" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Edit">
                                            <ItemTemplate>
                                                <asp:CheckBox ID="chkEdit" runat="server" AutoPostBack="true" OnCheckedChanged="chkCancel_CheckedChanged" />
                                            </ItemTemplate>
                                            <ItemStyle CssClass="TableData" HorizontalAlign="Center" />
                                            <FooterStyle CssClass="datafooter" />
                                            <HeaderStyle Width="10%" HorizontalAlign="Center" />
                                        </asp:TemplateField>
                                    </Columns>
                                    <FooterStyle BackColor="#5D7B9D" ForeColor="White" Font-Bold="True" />
                                    <RowStyle BackColor="#F7F6F3" ForeColor="#333333" BorderColor="PeachPuff" />
                                    <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                                    <PagerStyle ForeColor="White" HorizontalAlign="Center" BackColor="#284775" />
                                    <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                                    <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                                    <EditRowStyle BackColor="#999999" />
                                </asp:GridView>
                            </div>
                        </Content>
                    </asp:AccordionPane>
                </Panes>
                <Panes>
                    <asp:AccordionPane runat="server" ID="AccordionPane5">
                        <Header>
                            Payments</Header>
                        <Content>
                            <div class="gridcol_inside_page">
                                <asp:GridView ID="GridViewPayments" runat="server" CellPadding="4" ForeColor="#333333"
                                    GridLines="None" AutoGenerateColumns="False">
                                    <Columns>
                                        <asp:TemplateField>
                                            <HeaderTemplate>
                                                <asp:CheckBox ID="checkall" runat="server" AutoPostBack="True" OnCheckedChanged="btnTickAll_Click" />
                                            </HeaderTemplate>
                                            <ItemTemplate>
                                                <asp:CheckBox ID="ChkItem" runat="server" Width="43px" Enabled="false" />
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:BoundField DataField="Payments" HeaderText="ResourceName" />
                                        <asp:TemplateField HeaderText="All">
                                            <ItemTemplate>
                                                <asp:CheckBox ID="chkAll" runat="server" AutoPostBack="true" OnCheckedChanged="chkAll_CheckedChanged" />
                                            </ItemTemplate>
                                            <ItemStyle CssClass="TableData" HorizontalAlign="Center" />
                                            <FooterStyle CssClass="datafooter" />
                                            <HeaderStyle Width="10%" HorizontalAlign="Center" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Save">
                                            <ItemTemplate>
                                                <asp:CheckBox ID="chkSave" runat="server" AutoPostBack="true" OnCheckedChanged="chkCancel_CheckedChanged"
                                                    runat="server" />
                                            </ItemTemplate>
                                            <ItemStyle CssClass="TableData" HorizontalAlign="Center" />
                                            <FooterStyle CssClass="datafooter" />
                                            <HeaderStyle Width="10%" HorizontalAlign="Center" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Delete">
                                            <ItemTemplate>
                                                <asp:CheckBox ID="chkDelete" AutoPostBack="true" OnCheckedChanged="chkCancel_CheckedChanged"
                                                    runat="server" />
                                            </ItemTemplate>
                                            <ItemStyle CssClass="TableData" HorizontalAlign="Center" />
                                            <FooterStyle CssClass="datafooter" />
                                            <HeaderStyle Width="10%" HorizontalAlign="Center" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="View">
                                            <ItemTemplate>
                                                <asp:CheckBox ID="chkView" runat="server" AutoPostBack="true" OnCheckedChanged="chkView_CheckedChanged" />
                                            </ItemTemplate>
                                            <ItemStyle CssClass="TableData" HorizontalAlign="Center" />
                                            <FooterStyle CssClass="datafooter" />
                                            <HeaderStyle Width="10%" HorizontalAlign="Center" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Edit">
                                            <ItemTemplate>
                                                <asp:CheckBox ID="chkEdit" runat="server" AutoPostBack="true" OnCheckedChanged="chkCancel_CheckedChanged" />
                                            </ItemTemplate>
                                            <ItemStyle CssClass="TableData" HorizontalAlign="Center" />
                                            <FooterStyle CssClass="datafooter" />
                                            <HeaderStyle Width="10%" HorizontalAlign="Center" />
                                        </asp:TemplateField>
                                    </Columns>
                                    <FooterStyle BackColor="#5D7B9D" ForeColor="White" Font-Bold="True" />
                                    <RowStyle BackColor="#F7F6F3" ForeColor="#333333" BorderColor="PeachPuff" />
                                    <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                                    <PagerStyle ForeColor="White" HorizontalAlign="Center" BackColor="#284775" />
                                    <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                                    <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                                    <EditRowStyle BackColor="#999999" />
                                </asp:GridView>
                            </div>
                        </Content>
                    </asp:AccordionPane>
                </Panes>
                <Panes>
                    <asp:AccordionPane runat="server" ID="AccordionPane7">
                        <Header>
                            DayBook</Header>
                        <Content>
                            <div class="gridcol_inside_page">
                                <asp:GridView ID="GridViewDayBook" runat="server" CellPadding="4" ForeColor="#333333"
                                    GridLines="None" AutoGenerateColumns="False">
                                    <Columns>
                                        <asp:TemplateField>
                                            <HeaderTemplate>
                                                <asp:CheckBox ID="checkall" runat="server" AutoPostBack="True" OnCheckedChanged="btnTickAll_Click" />
                                            </HeaderTemplate>
                                            <ItemTemplate>
                                                <asp:CheckBox ID="ChkItem" runat="server" Width="43px" Enabled="false" />
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:BoundField DataField="DayBook" HeaderText="ResourceName" />
                                        <asp:TemplateField HeaderText="All">
                                            <ItemTemplate>
                                                <asp:CheckBox ID="chkAll" runat="server" AutoPostBack="true" OnCheckedChanged="chkAll_CheckedChanged" />
                                            </ItemTemplate>
                                            <ItemStyle CssClass="TableData" HorizontalAlign="Center" />
                                            <FooterStyle CssClass="datafooter" />
                                            <HeaderStyle Width="10%" HorizontalAlign="Center" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Save">
                                            <ItemTemplate>
                                                <asp:CheckBox ID="chkSave" runat="server" AutoPostBack="true" OnCheckedChanged="chkCancel_CheckedChanged"
                                                    runat="server" />
                                            </ItemTemplate>
                                            <ItemStyle CssClass="TableData" HorizontalAlign="Center" />
                                            <FooterStyle CssClass="datafooter" />
                                            <HeaderStyle Width="10%" HorizontalAlign="Center" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Delete">
                                            <ItemTemplate>
                                                <asp:CheckBox ID="chkDelete" AutoPostBack="true" OnCheckedChanged="chkCancel_CheckedChanged"
                                                    runat="server" />
                                            </ItemTemplate>
                                            <ItemStyle CssClass="TableData" HorizontalAlign="Center" />
                                            <FooterStyle CssClass="datafooter" />
                                            <HeaderStyle Width="10%" HorizontalAlign="Center" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="View">
                                            <ItemTemplate>
                                                <asp:CheckBox ID="chkView" runat="server" AutoPostBack="true" OnCheckedChanged="chkView_CheckedChanged" />
                                            </ItemTemplate>
                                            <ItemStyle CssClass="TableData" HorizontalAlign="Center" />
                                            <FooterStyle CssClass="datafooter" />
                                            <HeaderStyle Width="10%" HorizontalAlign="Center" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Edit">
                                            <ItemTemplate>
                                                <asp:CheckBox ID="chkEdit" runat="server" AutoPostBack="true" OnCheckedChanged="chkCancel_CheckedChanged" />
                                            </ItemTemplate>
                                            <ItemStyle CssClass="TableData" HorizontalAlign="Center" />
                                            <FooterStyle CssClass="datafooter" />
                                            <HeaderStyle Width="10%" HorizontalAlign="Center" />
                                        </asp:TemplateField>
                                    </Columns>
                                    <FooterStyle BackColor="#5D7B9D" ForeColor="White" Font-Bold="True" />
                                    <RowStyle BackColor="#F7F6F3" ForeColor="#333333" BorderColor="PeachPuff" />
                                    <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                                    <PagerStyle ForeColor="White" HorizontalAlign="Center" BackColor="#284775" />
                                    <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                                    <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                                    <EditRowStyle BackColor="#999999" />
                                </asp:GridView>
                            </div>
                        </Content>
                    </asp:AccordionPane>
                </Panes>
                <Panes>
                    <asp:AccordionPane runat="server" ID="AccordionPane8">
                        <Header>
                            Authentication</Header>
                        <Content>
                            <div class="gridcol_inside_page">
                                <asp:GridView ID="GridViewAuthentication" runat="server" CellPadding="4" ForeColor="#333333"
                                    GridLines="None" AutoGenerateColumns="False">
                                    <Columns>
                                        <asp:TemplateField>
                                            <HeaderTemplate>
                                                <asp:CheckBox ID="checkall" runat="server" AutoPostBack="True" OnCheckedChanged="btnTickAll_Click" />
                                            </HeaderTemplate>
                                            <ItemTemplate>
                                                <asp:CheckBox ID="ChkItem" runat="server" Width="43px" Enabled="false" />
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:BoundField DataField="Authentication" HeaderText="ResourceName" />
                                        <asp:TemplateField HeaderText="All">
                                            <ItemTemplate>
                                                <asp:CheckBox ID="chkAll" runat="server" AutoPostBack="true" OnCheckedChanged="chkAll_CheckedChanged" />
                                            </ItemTemplate>
                                            <ItemStyle CssClass="TableData" HorizontalAlign="Center" />
                                            <FooterStyle CssClass="datafooter" />
                                            <HeaderStyle Width="10%" HorizontalAlign="Center" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Save">
                                            <ItemTemplate>
                                                <asp:CheckBox ID="chkSave" runat="server" AutoPostBack="true" OnCheckedChanged="chkCancel_CheckedChanged"
                                                    runat="server" />
                                            </ItemTemplate>
                                            <ItemStyle CssClass="TableData" HorizontalAlign="Center" />
                                            <FooterStyle CssClass="datafooter" />
                                            <HeaderStyle Width="10%" HorizontalAlign="Center" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Delete">
                                            <ItemTemplate>
                                                <asp:CheckBox ID="chkDelete" AutoPostBack="true" OnCheckedChanged="chkCancel_CheckedChanged"
                                                    runat="server" />
                                            </ItemTemplate>
                                            <ItemStyle CssClass="TableData" HorizontalAlign="Center" />
                                            <FooterStyle CssClass="datafooter" />
                                            <HeaderStyle Width="10%" HorizontalAlign="Center" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="View">
                                            <ItemTemplate>
                                                <asp:CheckBox ID="chkView" runat="server" AutoPostBack="true" OnCheckedChanged="chkView_CheckedChanged" />
                                            </ItemTemplate>
                                            <ItemStyle CssClass="TableData" HorizontalAlign="Center" />
                                            <FooterStyle CssClass="datafooter" />
                                            <HeaderStyle Width="10%" HorizontalAlign="Center" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Edit">
                                            <ItemTemplate>
                                                <asp:CheckBox ID="chkEdit" runat="server" AutoPostBack="true" OnCheckedChanged="chkCancel_CheckedChanged" />
                                            </ItemTemplate>
                                            <ItemStyle CssClass="TableData" HorizontalAlign="Center" />
                                            <FooterStyle CssClass="datafooter" />
                                            <HeaderStyle Width="10%" HorizontalAlign="Center" />
                                        </asp:TemplateField>
                                    </Columns>
                                    <FooterStyle BackColor="#5D7B9D" ForeColor="White" Font-Bold="True" />
                                    <RowStyle BackColor="#F7F6F3" ForeColor="#333333" BorderColor="PeachPuff" />
                                    <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                                    <PagerStyle ForeColor="White" HorizontalAlign="Center" BackColor="#284775" />
                                    <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                                    <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                                    <EditRowStyle BackColor="#999999" />
                                </asp:GridView>
                            </div>
                        </Content>
                    </asp:AccordionPane>
                </Panes>
                <Panes>
                    <asp:AccordionPane runat="server" ID="AccordionPane6">
                        <Header>
                            Message</Header>
                        <Content>
                            <div class="gridcol_inside_page">
                                <asp:GridView ID="GridViewMessage" runat="server" CellPadding="4" ForeColor="#333333"
                                    GridLines="None" AutoGenerateColumns="False">
                                    <Columns>
                                        <asp:TemplateField>
                                            <HeaderTemplate>
                                                <asp:CheckBox ID="checkall" runat="server" AutoPostBack="True" OnCheckedChanged="btnTickAll_Click" />
                                            </HeaderTemplate>
                                            <ItemTemplate>
                                                <asp:CheckBox ID="ChkItem" runat="server" Width="43px" Enabled="false" />
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:BoundField DataField="Message" HeaderText="ResourceName" />
                                        <asp:TemplateField HeaderText="All">
                                            <ItemTemplate>
                                                <asp:CheckBox ID="chkAll" runat="server" AutoPostBack="true" OnCheckedChanged="chkAll_CheckedChanged" />
                                            </ItemTemplate>
                                            <ItemStyle CssClass="TableData" HorizontalAlign="Center" />
                                            <FooterStyle CssClass="datafooter" />
                                            <HeaderStyle Width="10%" HorizontalAlign="Center" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Save">
                                            <ItemTemplate>
                                                <asp:CheckBox ID="chkSave" runat="server" AutoPostBack="true" OnCheckedChanged="chkCancel_CheckedChanged"
                                                    runat="server" />
                                            </ItemTemplate>
                                            <ItemStyle CssClass="TableData" HorizontalAlign="Center" />
                                            <FooterStyle CssClass="datafooter" />
                                            <HeaderStyle Width="10%" HorizontalAlign="Center" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Delete">
                                            <ItemTemplate>
                                                <asp:CheckBox ID="chkDelete" AutoPostBack="true" OnCheckedChanged="chkCancel_CheckedChanged"
                                                    runat="server" />
                                            </ItemTemplate>
                                            <ItemStyle CssClass="TableData" HorizontalAlign="Center" />
                                            <FooterStyle CssClass="datafooter" />
                                            <HeaderStyle Width="10%" HorizontalAlign="Center" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="View">
                                            <ItemTemplate>
                                                <asp:CheckBox ID="chkView" runat="server" AutoPostBack="true" OnCheckedChanged="chkView_CheckedChanged" />
                                            </ItemTemplate>
                                            <ItemStyle CssClass="TableData" HorizontalAlign="Center" />
                                            <FooterStyle CssClass="datafooter" />
                                            <HeaderStyle Width="10%" HorizontalAlign="Center" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Edit">
                                            <ItemTemplate>
                                                <asp:CheckBox ID="chkEdit" runat="server" AutoPostBack="true" OnCheckedChanged="chkCancel_CheckedChanged" />
                                            </ItemTemplate>
                                            <ItemStyle CssClass="TableData" HorizontalAlign="Center" />
                                            <FooterStyle CssClass="datafooter" />
                                            <HeaderStyle Width="10%" HorizontalAlign="Center" />
                                        </asp:TemplateField>
                                    </Columns>
                                    <FooterStyle BackColor="#5D7B9D" ForeColor="White" Font-Bold="True" />
                                    <RowStyle BackColor="#F7F6F3" ForeColor="#333333" BorderColor="PeachPuff" />
                                    <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                                    <PagerStyle ForeColor="White" HorizontalAlign="Center" BackColor="#284775" />
                                    <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                                    <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                                    <EditRowStyle BackColor="#999999" />
                                </asp:GridView>
                            </div>
                        </Content>
                    </asp:AccordionPane>
                </Panes>
                <Panes>
                    <asp:AccordionPane runat="server" ID="AccordionPane9">
                        <Header>
                            Accounts</Header>
                        <Content>
                            <div class="gridcol_inside_page">
                                <asp:GridView ID="GridViewAccounts" runat="server" CellPadding="4" ForeColor="#333333"
                                    GridLines="None" AutoGenerateColumns="False">
                                    <Columns>
                                        <asp:TemplateField>
                                            <HeaderTemplate>
                                                <asp:CheckBox ID="checkall" runat="server" AutoPostBack="True" OnCheckedChanged="btnTickAll_Click" />
                                            </HeaderTemplate>
                                            <ItemTemplate>
                                                <asp:CheckBox ID="ChkItem" runat="server" Width="43px" Enabled="false" />
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:BoundField DataField="Accounts" HeaderText="ResourceName" />
                                        <asp:TemplateField HeaderText="All">
                                            <ItemTemplate>
                                                <asp:CheckBox ID="chkAll" runat="server" AutoPostBack="true" OnCheckedChanged="chkAll_CheckedChanged" />
                                            </ItemTemplate>
                                            <ItemStyle CssClass="TableData" HorizontalAlign="Center" />
                                            <FooterStyle CssClass="datafooter" />
                                            <HeaderStyle Width="10%" HorizontalAlign="Center" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Save">
                                            <ItemTemplate>
                                                <asp:CheckBox ID="chkSave" runat="server" AutoPostBack="true" OnCheckedChanged="chkCancel_CheckedChanged"
                                                    runat="server" />
                                            </ItemTemplate>
                                            <ItemStyle CssClass="TableData" HorizontalAlign="Center" />
                                            <FooterStyle CssClass="datafooter" />
                                            <HeaderStyle Width="10%" HorizontalAlign="Center" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Delete">
                                            <ItemTemplate>
                                                <asp:CheckBox ID="chkDelete" AutoPostBack="true" OnCheckedChanged="chkCancel_CheckedChanged"
                                                    runat="server" />
                                            </ItemTemplate>
                                            <ItemStyle CssClass="TableData" HorizontalAlign="Center" />
                                            <FooterStyle CssClass="datafooter" />
                                            <HeaderStyle Width="10%" HorizontalAlign="Center" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="View">
                                            <ItemTemplate>
                                                <asp:CheckBox ID="chkView" runat="server" AutoPostBack="true" OnCheckedChanged="chkView_CheckedChanged" />
                                            </ItemTemplate>
                                            <ItemStyle CssClass="TableData" HorizontalAlign="Center" />
                                            <FooterStyle CssClass="datafooter" />
                                            <HeaderStyle Width="10%" HorizontalAlign="Center" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Edit">
                                            <ItemTemplate>
                                                <asp:CheckBox ID="chkEdit" runat="server" AutoPostBack="true" OnCheckedChanged="chkCancel_CheckedChanged" />
                                            </ItemTemplate>
                                            <ItemStyle CssClass="TableData" HorizontalAlign="Center" />
                                            <FooterStyle CssClass="datafooter" />
                                            <HeaderStyle Width="10%" HorizontalAlign="Center" />
                                        </asp:TemplateField>
                                    </Columns>
                                    <FooterStyle BackColor="#5D7B9D" ForeColor="White" Font-Bold="True" />
                                    <RowStyle BackColor="#F7F6F3" ForeColor="#333333" BorderColor="PeachPuff" />
                                    <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                                    <PagerStyle ForeColor="White" HorizontalAlign="Center" BackColor="#284775" />
                                    <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                                    <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                                    <EditRowStyle BackColor="#999999" />
                                </asp:GridView>
                            </div>
                        </Content>
                    </asp:AccordionPane>
                </Panes>
                <Panes>
                    <asp:AccordionPane runat="server" ID="AccordionPane10">
                        <Header>
                            Reports</Header>
                        <Content>
                            <div class="gridcol_inside_page">
                                <asp:GridView ID="GridViewReports" runat="server" CellPadding="4" ForeColor="#333333"
                                    GridLines="None" AutoGenerateColumns="False">
                                    <Columns>
                                        <asp:TemplateField>
                                            <HeaderTemplate>
                                                <asp:CheckBox ID="checkall" runat="server" AutoPostBack="True" OnCheckedChanged="btnTickAll_Click" />
                                            </HeaderTemplate>
                                            <ItemTemplate>
                                                <asp:CheckBox ID="ChkItem" runat="server" Width="43px" Enabled="false" />
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:BoundField DataField="Reports" HeaderText="ResourceName" />
                                        <asp:TemplateField HeaderText="All">
                                            <ItemTemplate>
                                                <asp:CheckBox ID="chkAll" runat="server" AutoPostBack="true" OnCheckedChanged="chkAll_CheckedChanged" />
                                            </ItemTemplate>
                                            <ItemStyle CssClass="TableData" HorizontalAlign="Center" />
                                            <FooterStyle CssClass="datafooter" />
                                            <HeaderStyle Width="10%" HorizontalAlign="Center" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Save">
                                            <ItemTemplate>
                                                <asp:CheckBox ID="chkSave" runat="server" AutoPostBack="true" OnCheckedChanged="chkCancel_CheckedChanged"
                                                    runat="server" />
                                            </ItemTemplate>
                                            <ItemStyle CssClass="TableData" HorizontalAlign="Center" />
                                            <FooterStyle CssClass="datafooter" />
                                            <HeaderStyle Width="10%" HorizontalAlign="Center" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Delete">
                                            <ItemTemplate>
                                                <asp:CheckBox ID="chkDelete" AutoPostBack="true" OnCheckedChanged="chkCancel_CheckedChanged"
                                                    runat="server" />
                                            </ItemTemplate>
                                            <ItemStyle CssClass="TableData" HorizontalAlign="Center" />
                                            <FooterStyle CssClass="datafooter" />
                                            <HeaderStyle Width="10%" HorizontalAlign="Center" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="View">
                                            <ItemTemplate>
                                                <asp:CheckBox ID="chkView" runat="server" AutoPostBack="true" OnCheckedChanged="chkView_CheckedChanged" />
                                            </ItemTemplate>
                                            <ItemStyle CssClass="TableData" HorizontalAlign="Center" />
                                            <FooterStyle CssClass="datafooter" />
                                            <HeaderStyle Width="10%" HorizontalAlign="Center" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Edit">
                                            <ItemTemplate>
                                                <asp:CheckBox ID="chkEdit" runat="server" AutoPostBack="true" OnCheckedChanged="chkCancel_CheckedChanged" />
                                            </ItemTemplate>
                                            <ItemStyle CssClass="TableData" HorizontalAlign="Center" />
                                            <FooterStyle CssClass="datafooter" />
                                            <HeaderStyle Width="10%" HorizontalAlign="Center" />
                                        </asp:TemplateField>
                                    </Columns>
                                    <FooterStyle BackColor="#5D7B9D" ForeColor="White" Font-Bold="True" />
                                    <RowStyle BackColor="#F7F6F3" ForeColor="#333333" BorderColor="PeachPuff" />
                                    <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                                    <PagerStyle ForeColor="White" HorizontalAlign="Center" BackColor="#284775" />
                                    <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                                    <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                                    <EditRowStyle BackColor="#999999" />
                                </asp:GridView>
                            </div>
                        </Content>
                    </asp:AccordionPane>
                </Panes>
            </asp:Accordion>
        </div>
        <div class="btn_spaces">
            <asp:Button ID="btnSave" runat="server" Text="Save" CssClass="btnstyle" OnClick="btnSave_Click" />
            <asp:HiddenField ID="hidID" runat="server" />
        </div>
    </div>
</asp:Content>
