<%@ page language="C#" masterpagefile="~/AppMaster.master" autoeventwireup="true" inherits="LorryACSlip, App_Web_utcvgpzk" title="Deepak Roadways" %>

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
                <cc1:AutoCompleteExtender ID="AutoCompleteExtender2" runat="server" MinimumPrefixLength="1"
                    ServiceMethod="GetAgentName" TargetControlID="AgentName" CompletionInterval="1">
                </cc1:AutoCompleteExtender>
                <div class="ControlsWrapper1">
                    <div>
                        <asp:Label ID="lblLSlipNo" runat="server" Text="LSlipNo"></asp:Label>
                        <asp:TextBox ID="LSlipNo" TabIndex="1" onkeypress="return alphanumeric_only(this);"
                            MaxLength="10" runat="server" AutoPostBack="True" OnTextChanged="LSlipNo_TextChanged"></asp:TextBox>
                    </div>
                    <div>
                        <asp:Label ID="lblDate" runat="server" Text="Date"></asp:Label>
                        <asp:TextBox ID="Date" TabIndex="2" MaxLength="10" runat="server"></asp:TextBox>
                        <cc1:CalendarExtender ID="CalendarExtender1" runat="server" Format="dd/MM/yyyy" TargetControlID="Date"
                            CssClass="cal_Theme">
                        </cc1:CalendarExtender>
                    </div>
                </div>
                <div class="ControlsWrapper1">
                    <div>
                        <asp:Label ID="lblLorryDate" runat="server" Text="LorryDate"></asp:Label>
                        <asp:TextBox ID="LorryDate" TabIndex="3" MaxLength="20" runat="server" AutoPostBack="True"
                            OnTextChanged="LorryDate_TextChanged"></asp:TextBox>
                        <cc1:CalendarExtender ID="CalendarExtender2" runat="server" Format="dd/MM/yyyy" TargetControlID="LorryDate"
                            CssClass="cal_Theme">
                        </cc1:CalendarExtender>
                    </div>
                    <div>
                        <asp:Label ID="lblLorryNo" runat="server" Text="LorryNo"></asp:Label>
                        <asp:DropDownList ID="LorryNo" runat="server" TabIndex="4" AutoPostBack="True" OnSelectedIndexChanged="LorryNo_SelectedIndexChanged">
                        <asp:ListItem>--Select--</asp:ListItem>
                        </asp:DropDownList>
                    </div>
                </div>
                <div class="ControlsWrapper1">
                    <div>
                        <asp:Label ID="lblStartFrom" runat="server" Text="StartFrom"></asp:Label>
                        <asp:TextBox ID="StartFrom" onkeypress="return alphanumeric_only(this);" MaxLength="20"
                            runat="server"></asp:TextBox>
                    </div>
                    <div>
                        <cc1:AutoCompleteExtender ID="AutoCompleteExtender3" runat="server" MinimumPrefixLength="1"
                                    ServiceMethod="GetCompletionBranch" TargetControlID="DestTo" CompletionInterval="1">
                                      </cc1:AutoCompleteExtender>
                        <asp:Label ID="lblDestTo" runat="server" Text="DestTo"></asp:Label>
                        <asp:TextBox ID="DestTo" onkeypress="return alphanumeric_only(this);" MaxLength="20"
                            runat="server" OnTextChanged="DestTo_TextChanged" AutoPostBack="true"></asp:TextBox>
                    </div>
                </div>
                <div class="gridcol">
                    <asp:GridView ID="GridLorryAc" runat="server" AutoGenerateColumns="false" ShowFooter="False"
                        OnRowCommand="GridLorryAc_RowCommand" OnRowCancelingEdit="GridLorryAc_RowCancelingEdit"
                        OnRowEditing="GridLorryAc_RowEditing" OnRowUpdating="GridLorryAc_RowUpdating"
                        OnRowDeleting="GridLorryAc_RowDeleting">
                        <Columns>
                            <asp:TemplateField HeaderText="Sl.No">
                                <ItemTemplate>
                                    <%#Container.DataItemIndex + 1 %>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="LorryAcSlip ID" Visible="false">
                                <ItemTemplate>
                                    <asp:Label runat="server" ID="LorryAcSlipID" Text='<%#Eval("LorryAcSlipID")%>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Challan No">
                                <EditItemTemplate>
                                    <asp:TextBox ID="ChallanNo" Width="82px" runat="server" onKeyPress="return isNumberKey(event)"
                                        Text='<%#Bind("ChallanNo") %>'></asp:TextBox>
                                </EditItemTemplate>
                                <FooterTemplate>
                                    <asp:TextBox ID="ChallanNo1" Width="82px" onKeyPress="return isNumberKey(event)"
                                        runat="server" Text='<%#Bind("ChallanNo") %>'></asp:TextBox>
                                </FooterTemplate>
                                <ItemTemplate>
                                    <%#Eval("ChallanNo")%>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Destination">
                                <EditItemTemplate>
                                    <asp:TextBox ID="Destination" Width="100px" runat="server" Text='<%#Bind("Destination") %>'
                                        onkeypress="return alphanumeric_only(this);"></asp:TextBox>
                                </EditItemTemplate>
                                <FooterTemplate>
                                    <asp:TextBox ID="Destination1" Width="100px" runat="server" Text='<%#Bind("Destination") %>'
                                        onkeypress="return alphanumeric_only(this);"></asp:TextBox>
                                </FooterTemplate>
                                <ItemTemplate>
                                    <%#Eval("Destination")%>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Packages">
                                <EditItemTemplate>
                                    <asp:TextBox ID="Packages" Width="75px" runat="server" Text='<%#Bind("Packages") %>'
                                        onKeyPress="return isNumberKey(event)"></asp:TextBox>
                                </EditItemTemplate>
                                <FooterTemplate>
                                    <asp:TextBox ID="Packages1" Width="75px" runat="server" Text='<%#Bind("Packages") %>'
                                        onKeyPress="return isNumberKey(event)"></asp:TextBox>
                                </FooterTemplate>
                                <ItemTemplate>
                                    <%#Eval("Packages")%>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Weight">
                                <EditItemTemplate>
                                    <asp:TextBox ID="Weight" Width="70px" runat="server" Text='<%#Bind("Weight") %>'
                                        onKeyPress="return isNumberKey(event)"></asp:TextBox>
                                </EditItemTemplate>
                                <FooterTemplate>
                                    <asp:TextBox ID="Weight1" Width="70px" runat="server" Text='<%#Bind("Weight") %>'
                                        onKeyPress="return isNumberKey(event)"></asp:TextBox>
                                </FooterTemplate>
                                <ItemTemplate>
                                    <%#Eval("Weight")%>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Collection">
                                <EditItemTemplate>
                                    <asp:TextBox ID="Collection" Width="120px" runat="server" Text='<%#Bind("Collections") %>'
                                        onKeyPress="return alphanumeric_only(this);"></asp:TextBox>
                                </EditItemTemplate>
                                <FooterTemplate>
                                    <asp:TextBox ID="Collection1" Width="120px" runat="server" Text='<%#Bind("Collections") %>'
                                        onKeyPress="return alphanumeric_only(this);"></asp:TextBox>
                                </FooterTemplate>
                                <ItemTemplate>
                                    <%#Eval("Collections")%>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Options">
                                <EditItemTemplate>
                                    <asp:LinkButton ID="LinkButton1" runat="server" CommandName="Update" Text="<img src='App_Themes/Images/Update.gif' border='0' title='Update' />"
                                        CssClass="buttonimage" Width="25%"></asp:LinkButton>
                                    <asp:LinkButton ID="LinkButton2" runat="server" CommandName="Cancel" Text="<img src='App_Themes/Images/Cancel.gif' border='0' title='Cancel' />"
                                        CssClass="buttonimage" Width="25%"></asp:LinkButton>
                                </EditItemTemplate>
                                <FooterTemplate>
                                    <asp:LinkButton ID="LinkButton3" runat="server" CommandName="InsertNew" Text="<img src='App_Themes/Images/Insert1.gif' border='0' title='Insert' />"
                                        CssClass="buttonimage" Width="25%"></asp:LinkButton>
                                    <asp:LinkButton ID="LinkButton4" runat="server" CommandName="CancelNew" Text="<img src='App_Themes/Images/Cancel.gif'border='0' title='Cancel'  />"
                                        CssClass="buttonimage" Width="25%"></asp:LinkButton>
                                </FooterTemplate>
                                <ItemTemplate>
                                    <asp:LinkButton ID="LinkButton5" runat="server" CommandName="Edit" Text="<img src='App_Themes/Images/Edit.gif' border='0' title='Edit' />"
                                        CssClass="buttonimage" Width="25%"></asp:LinkButton>
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                    </asp:GridView>
                </div>
                <div class="ControlsWrapper1">
                    <div>
                        <asp:Label ID="lblTotalPackages" runat="server" Text="Total Packages"></asp:Label>
                        <asp:TextBox ID="TotalPack" onkeypress="return isNumberKey(event)" MaxLength="20"
                            runat="server" ReadOnly="true"></asp:TextBox>
                    </div>
                    <div>
                        <asp:Label ID="lblTotalWeight" runat="server" Text="Total Weight"></asp:Label>
                        <asp:TextBox ID="TotalWeight" onkeypress="return isNumberKey(event)" MaxLength="20"
                            runat="server" ReadOnly="true"></asp:TextBox>
                    </div>
                    <div>
                        <asp:Label ID="lblLorryToPay" runat="server" Text="LorryToPay"></asp:Label>
                        <asp:TextBox ID="LorryToPay" MaxLength="20" runat="server"></asp:TextBox>
                    </div>
                    <div>
                        <asp:Label ID="lblLorryToPaid" runat="server" Text="LorryToPaid"></asp:Label>
                        <asp:TextBox ID="LorryToPaid" MaxLength="20" runat="server"></asp:TextBox>
                    </div>
                    <div>
                        <asp:Label ID="lblLorryToPayBalance" runat="server" Text="LorryToPay Balance"></asp:Label>
                        <asp:TextBox ID="LorryToPayBalance" onkeypress="return isNumberKey(event)" MaxLength="20"
                            runat="server"></asp:TextBox>
                    </div>
                </div>
                <div class="ControlsWrapper1">
                    <div>
                        <asp:Label ID="lblLorryHire" runat="server" Text="LorryHire"></asp:Label>
                        <asp:TextBox ID="LorryHire" TabIndex="5" onkeypress="return alphanumeric_only(this);"
                            MaxLength="20" runat="server" AutoPostBack="True" OnTextChanged="LorryHire_TextChanged"></asp:TextBox>
                    </div>
                    <div>
                        <asp:Label ID="lblAdvance" runat="server" Text="Advance"></asp:Label>
                        <asp:TextBox ID="Advance" TabIndex="6" onkeypress="return isNumberKey(event)" MaxLength="20"
                            runat="server" AutoPostBack="True" OnTextChanged="Advance_TextChanged"></asp:TextBox>
                    </div>
                    <div>
                        <asp:Label ID="lblBalance" runat="server" Text="Balance"></asp:Label>
                        <asp:TextBox ID="Balance" onkeypress="return isNumberKey(event)" MaxLength="20" runat="server"></asp:TextBox>
                    </div>
                </div>
                <div class="ControlsWrapper1">
                    <div>
                        <asp:Label ID="lblFreightPayable" runat="server" Text="Freight Payable"></asp:Label>
                        <asp:TextBox ID="FreightPayable" TabIndex="7" onkeypress="return alphanumeric_only(this)"
                            MaxLength="20" runat="server"></asp:TextBox>
                    </div>
                    <div>
                        <asp:Label ID="lblAgentName" runat="server" Text="Agent Name"></asp:Label>
                        <asp:TextBox ID="AgentName" TabIndex="8" onkeypress="return alphanumeric_only(this);"
                            MaxLength="20" runat="server" OnTextChanged="AgentName_TextChanged"></asp:TextBox>
                    </div>
                </div>
            </div>
            <div class="ButtonsWrapper three-col-button">
                <div class="btn_spaces">
                    <asp:Button ID="btnSave" runat="server" Text="Save" CssClass="btnstyle" TabIndex="9"
                        OnClick="btnSave_Click"></asp:Button>
                    <asp:Button ID="btnClear" runat="server" Text="Clear" CssClass="btnstyle" TabIndex="10"
                        OnClick="btnClear_Click"></asp:Button>
                    <asp:Button ID="btnDelete" runat="server" Text="Delete" CssClass="btnstyle" OnClick="btnDelete_Click"
                        TabIndex="11" OnClientClick="return ConfirmDelete();"></asp:Button>
                </div>
            </div>
        </div>
        <asp:HiddenField runat="server" ID="hidAgent" />
        <asp:HiddenField runat="server" ID="hidLorrySlipID" />
        <div style="display: none; margin-top: 100px" id="DisplayCrysRep" runat="server">
            <div>
                <a href="LorryACSlip.aspx">
                    <img src="App_Themes/Images/Back.png" style="width: 125px; height: 25px" /></a></div>
            <CR:CrystalReportViewer ID="CRViewer" runat="server" AutoDataBind="true" PrintMode="ActiveX"
                DisplayGroupTree="true" />
        </div>
    </div>
</asp:Content>
