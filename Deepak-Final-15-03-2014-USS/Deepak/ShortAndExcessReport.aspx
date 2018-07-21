<%@ page language="C#" masterpagefile="~/AppMaster.master" autoeventwireup="true" inherits="ShortAndExcessReport, App_Web_utcvgpzk" title="Untitled Page" %>


<%@ Register Assembly="CrystalDecisions.Web, Version=10.5.3700.0, Culture=neutral, PublicKeyToken=692fbea5521e1304"
    Namespace="CrystalDecisions.Web" TagPrefix="CR" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="PageContent" Runat="Server">
 <cc1:ToolkitScriptManager ID="Too" runat="server">
    </cc1:ToolkitScriptManager>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <div id="Page">
                
                <div style="display: block" id="Block_MainPage" runat="server">
                <div class="single-col">
                    <asp:Label runat="server" ID="lblResult" ForeColor="#FF3300"></asp:Label>
                    <div class="ControlsWrapper1">
                        <div>
                            <asp:Label ID="lblToDate" runat="server" Text="Date"></asp:Label>
                            <asp:TextBox ID="txtToDate" MaxLength="10" runat="server" OnTextChanged="txtToDate_TextChanged" AutoPostBack="true"></asp:TextBox>
                            <cc1:CalendarExtender ID="CalendarExtender1" runat="server" Format="dd/MM/yyyy" TargetControlID="txtToDate"
                                CssClass="cal_Theme">
                            </cc1:CalendarExtender>
                        </div>
                    </div>
                     <%--<div class="ControlsWrapper">
                        <div>
                            <asp:Label ID="lbl" runat="server" Text="Short" Visible="false"></asp:Label>
                            <asp:DropDownList ID="ddlShort" runat="server" Visible="false">
                            <asp:ListItem>--Select--</asp:ListItem>
                            <asp:ListItem>Short</asp:ListItem>
                            </asp:DropDownList>
                        </div>
                    </div>--%>
                    </div>
                </div>
                <%--<div class="two-col">
            <asp:Label ID="lblresult" runat="server" ForeColor="Red" Text=""></asp:Label>
            <div class="ControlsWrapper">
                <div>
                    <asp:Label ID="lblStoreNo" runat="server" Text="Godown No"></asp:Label><asp:TextBox
                        ID="StoreNo" runat="server" TabIndex="1" MaxLength="8"></asp:TextBox>
                </div>
                <div>
                    <asp:Label ID="lblItemName" runat="server" Text="Item Name"></asp:Label>
                    <asp:DropDownList runat="server" ID="ddlItemName" TabIndex="2">
                        <asp:ListItem Text="--SELECT--" Value="--Select--"></asp:ListItem>
                    </asp:DropDownList>
                </div>
                <div>
                    <asp:Label ID="lblQty" runat="server" Text="Quantity"></asp:Label><asp:TextBox ID="Quantity"
                        runat="server" TabIndex="3" MaxLength="8"></asp:TextBox>
                </div>
            </div>
            <div class="ControlsWrapper">
                <div>
                    <asp:Label ID="lblUnit" runat="server" Text="Unit"></asp:Label><asp:TextBox ID="Unit"
                        runat="server" TabIndex="4" MaxLength="8"></asp:TextBox>
                </div>
                <div>
                    <asp:Label ID="lblLRNo" runat="server" Text="LRNo"></asp:Label><asp:TextBox ID="LRNo"
                        runat="server" TabIndex="5" MaxLength="8"></asp:TextBox>
                </div>
            </div>
        </div>--%>
                <%--   <div class="ButtonsWrapper two-col-button">
            <div class="btn_spaces-View">
                <asp:Button ID="btnSave" runat="server" Text="Save" CssClass="btnstyle" TabIndex="6"
                    OnClick="btnSave_Click" />
                <asp:Button ID="btnDelete" runat="server" Text="Delete" TabIndex="7" CausesValidation="false"
                    CssClass="btnstyle" OnClick="btnDelete_Click" OnClientClick="return ConfirmDelete();" />
                <asp:Button ID="btnClear" TabIndex="8" runat="server" Text="Clear" CssClass="btnstyle"
                    CausesValidation="false" OnClick="btnClear_Click" />
                <asp:Button ID="btnView" runat="server" Text="View" TabIndex="9" CssClass="btnstyle"
                    CausesValidation="false" OnClick="btnView_Click" />
            </div>
            <div class="ControlsWrapper" id="StoreNoID_View" style="display: none" runat="server">
                <div style="margin-top: -20px; margin-bottom: -20px; margin-left: -30px">
                    <asp:Label ID="lblStoreNoView" runat="server" Text="Store No"></asp:Label>
                    <asp:TextBox ID="StoreNoView" runat="server" TabIndex="1" MaxLength="8" AutoPostBack="True"
                        OnTextChanged="StoreNoView_TextChanged"></asp:TextBox>
                </div>
            </div>
        </div>
        <asp:HiddenField ID="hidID" runat="server" />--%>
                <%--  <asp:Panel ID="panelitem" runat="server" BackColor="#CDCDB4" 
                         BorderStyle="Groove" height="300px" Width="250px">
            <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional">
                <ContentTemplate>
                    <asp:GridView ID="GridView1" runat="server" AutoGenerateSelectButton="true" 
                        AutoGenerateColumns="false" 
                        onselectedindexchanging="GridView1_SelectedIndexChanging1" 
                        onrowdatabound="GridView1_RowDataBound" 
                      >
                       <Columns>
                       <asp:TemplateField>
                            <ItemTemplate>
                                <asp:LinkButton ID="lnkSelect" runat="server" Text="Select" >Select1</asp:LinkButton>
                            </ItemTemplate>
                        </asp:TemplateField>
                         
                         <asp:BoundField DataField="StoreNo" HeaderText="Godown No" />
                       </Columns>
                    </asp:GridView>   
                            <asp:LinkButton ID="lnkcancel" runat="server" CausesValidation="false" onclick="lnkcancel_Click">Cancel</asp:LinkButton>
                </ContentTemplate>
                <Triggers>
                   <asp:AsyncPostBackTrigger ControlID="lnkcancel" />
                </Triggers>
            </asp:UpdatePanel>
        </asp:Panel> --%>
                <%--   <div class="gridcol">
            <asp:GridView ID="GridStore" runat="server" BackColor="#DEBA84" BorderColor="#DEBA84"
                BorderStyle="None" BorderWidth="1px" CellPadding="3" CellSpacing="2" AutoGenerateColumns="False"
                OnSelectedIndexChanging="GridStore_SelectedIndexChanging">
                <FooterStyle BackColor="#F7DFB5" ForeColor="#003f81" />
                <RowStyle BackColor="#e9edf2" ForeColor="#003f81" />
                <SelectedRowStyle BackColor="#e9edf2" Font-Bold="True" ForeColor="#003f81" />
                <PagerStyle ForeColor="#8C4510" HorizontalAlign="Center" />
                <HeaderStyle BackColor="#dae9f3" Font-Bold="True" ForeColor="White" />
                <Columns>
                    <asp:CommandField HeaderText="Select" ShowSelectButton="True" />
                    <asp:BoundField DataField="ItemName" HeaderText="ItemName" />
                    <asp:BoundField DataField="Quantity" HeaderText="Quantity" />
                    <asp:BoundField DataField="Unit" HeaderText="Unit" />
                    <asp:BoundField DataField="LRNo" HeaderText="LRNo" />
                </Columns>
            </asp:GridView>
        </div>--%>
        <div style="display: none; margin-top: 100px" id="DisplayCrysRep" runat="server">
                <div>
                    <a href="ShortAndExcessReport.aspx">
                        <img src="App_Themes/Images/Back.png" style="width: 125px; height: 25px" /></a></div>
                <CR:CrystalReportViewer ID="CRViewer" runat="server" AutoDataBind="true" />
            </div>
            </div>
            
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>

