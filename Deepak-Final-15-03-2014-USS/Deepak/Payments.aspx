<%@ page language="C#" masterpagefile="~/AppMaster.master" autoeventwireup="true" inherits="Payments, App_Web_zwikzsdt" title="Payments" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="PageContent" runat="Server">
    <cc1:ToolkitScriptManager ID="Too" runat="server">
    </cc1:ToolkitScriptManager>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <div id="Page">
                <div class="single-col">
                    <asp:Label runat="server" ID="lblResult" Text="" ForeColor="Red"></asp:Label>
                    <div class="ControlsWrapper1">
                        <asp:RadioButtonList ID="rdSelect" runat="server" RepeatDirection="Horizontal" Width="30%"
                            AutoPostBack="true" OnSelectedIndexChanged="rdSelect_SelectedIndexChanged">
                            <asp:ListItem Value="0">Old Balance</asp:ListItem>
                            <asp:ListItem Value="1">Payments</asp:ListItem>
                        </asp:RadioButtonList>
                    </div>
                </div>
                <div class="three-col-new" style="margin-top: -1%; margin-bottom: 1%">
                    <div class="ControlsWrapper1">
                       <div>
                            <asp:Label ID="LblReciptNo" runat="server" Text="ReciptNo" Visible="false"></asp:Label>
                            <asp:TextBox ID="txtReciptNo" runat="server" ReadOnly="true" AutoPostBack="True" Visible="false"></asp:TextBox>
                        </div>
                          <div>
                            <asp:Label ID="lblMRNo" runat="server" Text="MRNo"></asp:Label>
                            <asp:TextBox ID="txtMRNo"  onkeypress="return isNumberKey(event)"
                                MaxLength="20" runat="server" OnTextChanged="txtMRNo_TextChanged" AutoPostBack="true"></asp:TextBox>
                        </div>
                        <div>
                            <asp:Label ID="lblType" runat="server" Text="Type"></asp:Label>
                            <asp:DropDownList ID="ddlType" runat="server" OnSelectedIndexChanged="ddlType_SelectedIndexChanged">
                                <asp:ListItem Value="0">--SELECT--</asp:ListItem>
                                <asp:ListItem Value="1">Customer</asp:ListItem>
                                <asp:ListItem Value="2">Agent</asp:ListItem>
                                <asp:ListItem Value="3">Transport</asp:ListItem>
                                <asp:ListItem Value="4">CashBook</asp:ListItem>
                            </asp:DropDownList>
                        </div>
                        <div>
                            <asp:Label ID="lblPartyName" runat="server" Text="Party Name"></asp:Label>
                            <asp:TextBox ID="txtPartyName" TabIndex="1" onkeypress="return alphanumeric_only(this);"
                                MaxLength="20" runat="server" AutoPostBack="True" OnTextChanged="txtPartyName_TextChanged"></asp:TextBox>
                            <cc1:AutoCompleteExtender ID="AutoCompleteExtender1" runat="server" MinimumPrefixLength="1"
                                ServiceMethod="GetCompletionHome" TargetControlID="txtPartyName" CompletionInterval="1">
                            </cc1:AutoCompleteExtender>
                        </div>
                        <div>
                            <asp:Label ID="lblCollectedBy" runat="server" Text="Collected By"></asp:Label>
                            <asp:TextBox ID="txtCollectedBy" TabIndex="2" onkeypress="return alphanumeric_only(this);"
                                MaxLength="20" runat="server" AutoPostBack="True" OnTextChanged="txtCollectedBy_TextChanged"></asp:TextBox>
                            <cc1:AutoCompleteExtender ID="AutoCompleteExtender2" runat="server" MinimumPrefixLength="1"
                                ServiceMethod="GetCompletionCollectedBy" TargetControlID="txtCollectedBy" CompletionInterval="1">
                            </cc1:AutoCompleteExtender>
                        </div>
                    </div>
                    <div class="ControlsWrapper1">
                        <div>
                            <asp:Label ID="lblPaidDate" runat="server" Text="Paid Date"></asp:Label>
                            <asp:TextBox ID="txtPaidDate" TabIndex="3" MaxLength="20" runat="server"></asp:TextBox>
                            <cc1:CalendarExtender ID="CalendarExtender2" Format="dd/MM/yyyy" runat="server" TargetControlID="txtPaidDate"
                                CssClass="cal_Theme">
                            </cc1:CalendarExtender>
                        </div>
                        <div>
                            <asp:Label ID="lblTotalBalance" runat="server" Text="Total Balance"></asp:Label>
                            <asp:TextBox ID="txtTotalBalance" ReadOnly="true" onkeypress="return isNumberKey(event)"
                                MaxLength="20" runat="server"></asp:TextBox>
                        </div>
                        <div>
                            <asp:Label ID="lblTotalPaid" runat="server" Text="Total Paid"></asp:Label>
                            <asp:TextBox ID="txtTotalPaid" ReadOnly="true" onkeypress="return isNumberKey(event)"
                                MaxLength="20" runat="server"></asp:TextBox>
                        </div>
                    </div>
                    <div class="ControlsWrapper1">
                        <div>
                            <asp:Label ID="lblPaidAmount" runat="server" Text="Paid Amount"></asp:Label>
                            <asp:TextBox ID="txtPaidAmount" onkeypress="return isNumberKey(event)"
                                MaxLength="20" runat="server" Width="25%" AutoPostBack="True" OnTextChanged="txtPaidAmount_TextChanged"></asp:TextBox>
                        </div>
                        <div>
                            <asp:Label ID="lblPaymentMode" runat="server" Text="Payment Mode"></asp:Label>
                            <asp:DropDownList ID="ddlPaymentMode" TabIndex="4" runat="server" AutoPostBack="True"
                                OnSelectedIndexChanged="ddlPaymentMode_SelectedIndexChanged">
                                <asp:ListItem Value="0"> --SELECT-- </asp:ListItem>
                                <asp:ListItem Value="1">Cash</asp:ListItem>
                                <asp:ListItem Value="2">Cheque</asp:ListItem>
                            </asp:DropDownList>
                        </div>
                    </div>
                    <div id="ShowCheque" runat="server" style="display: none">
                        <div class="ControlsWrapper1">
                            <div>
                                <asp:Label ID="lblChequeDDNo" runat="server" Text="Cheque/DD No"></asp:Label>
                                <asp:TextBox ID="txtChequeDDNo" TabIndex="9" onkeypress="return isNumberKey(event)"
                                    MaxLength="20" runat="server"></asp:TextBox>
                            </div>
                        </div>
                        <div class="ControlsWrapper1">
                            <div>
                                <asp:Label ID="lblChequeDDDate" runat="server" Text="Cheque/DD Date"></asp:Label>
                                <asp:TextBox ID="txtChequeDDDate" TabIndex="10" MaxLength="20" runat="server"></asp:TextBox>
                                <cc1:CalendarExtender ID="CalendarExtender1" runat="server" Format="dd/MM/yyyy" TargetControlID="txtChequeDDDate"
                                    CssClass="cal_Theme">
                                </cc1:CalendarExtender>
                            </div>
                        </div>
                        <div class="ControlsWrapper1">
                            <div>
                                <asp:Label ID="lblBankName" runat="server" Text="Bank Name"></asp:Label>
                                <asp:TextBox ID="txtBankName" TabIndex="11" onkeypress="return alphanumeric_only(this);"
                                    MaxLength="20" runat="server"></asp:TextBox>
                            </div>
                        </div>
                    </div>
                </div>
                <div class="gridcol" style="margin-left: 13.1%; margin-bottom: 1%; margin-top: 0.5%">
                    <asp:GridView ID="GridCustomerinvoice" runat="server" AutoGenerateColumns="false"
                        CellPadding="3" CellSpacing="2" ShowFooter="false">
                        <Columns>
                            <asp:TemplateField>
                                <HeaderTemplate>
                                    <asp:CheckBox ID="ChkHeader" runat="server" AutoPostBack="True" OnCheckedChanged="ChkHeader_CheckedChanged" />
                                </HeaderTemplate>
                                <ItemTemplate>
                                    <asp:CheckBox ID="ChkItem" runat="server" Width="43px" AutoPostBack="True" OnCheckedChanged="ChkItem_CheckedChanged" />
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="SI.NO">
                                <ItemTemplate>
                                    <%#Container.DataItemIndex+1 %>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="ID" Visible="false">
                                <ItemTemplate>
                                    <asp:Label runat="server" ID="lblID" Text='<%#Eval("ID")%>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="DelID" Visible="false">
                                <EditItemTemplate>
                                    <asp:Label ID="lblDeliveryid" runat="server" Text='<%#Eval("DeliveryID") %>'></asp:Label>
                                </EditItemTemplate>
                                <ItemTemplate>
                                    <asp:Label ID="txtDeliveryID" runat="server" Text='<%#Eval("DeliveryID")%>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="DeliveryDate">
                                <EditItemTemplate>
                                    <asp:Label ID="lblDeliveryDate" runat="server" Text='<%#Eval("DeliveryDate") %>'></asp:Label>
                                </EditItemTemplate>
                                <ItemTemplate>
                                    <asp:Label ID="DeliveryDate" runat="server" Text='<%#Eval("DeliveryDate") %>'></asp:Label>
                                    <%--<%#Eval("MRNO")%>--%>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="MRNO">
                                <EditItemTemplate>
                                    <asp:Label ID="lblMRNO" runat="server" Text='<%#Eval("MRNO") %>'></asp:Label>
                                </EditItemTemplate>
                                <ItemTemplate>
                                    <asp:Label ID="ItemlblMRNO" runat="server" Text='<%#Eval("MRNO") %>'></asp:Label>
                                    <%--<%#Eval("MRNO")%>--%>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Amount">
                                <EditItemTemplate>
                                    <asp:Label ID="lblAmount" runat="server" Text='<%#Eval("Amount") %>'></asp:Label>
                                </EditItemTemplate>
                                <ItemTemplate>
                                    <asp:Label ID="txtAmount" runat="server" Text=' <%#Eval("Amount")%>'></asp:Label>
                                </ItemTemplate>
                                <%--<FooterTemplate>
                                    <asp:Literal ID="litTotID" runat="server" />
                                </FooterTemplate>--%>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Balance">
                                <EditItemTemplate>
                                    <asp:Label ID="lblbalance" runat="server" Text='<%#Eval("Balance") %>'></asp:Label>
                                </EditItemTemplate>
                                <ItemTemplate>
                                    <asp:Label ID="txtBalance" runat="server" Text='<%#Eval("Balance")%>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="PaidAmount">
                                <EditItemTemplate>
                                    <asp:TextBox ID="txtPaidAmount" runat="server" TabIndex="10" Text='<%#Bind("PaidAmount") %>'></asp:TextBox>
                                </EditItemTemplate>
                                <ItemTemplate>
                                    <asp:TextBox ID="txtPaidAmountadd" runat="server" Text='<%#Bind("PaidAmount") %>'
                                        Width="120" TabIndex="10" OnTextChanged="txtPaidAmountadd_TextChanged" AutoPostBack="true"></asp:TextBox>
                                </ItemTemplate>
                            </asp:TemplateField>
                             <asp:TemplateField HeaderText="ShortAmount">
                                <EditItemTemplate>
                                    <asp:TextBox ID="txtShortPay" runat="server" TabIndex="10" Text='<%#Bind("ShortAmount") %>'></asp:TextBox>
                                </EditItemTemplate>
                                <ItemTemplate>
                                    <asp:TextBox ID="txtShortPayAdd" runat="server" Text='<%#Bind("ShortAmount") %>'
                                        Width="120" TabIndex="10" OnTextChanged="txtShortPayAdd_TextChanged" AutoPostBack="true"></asp:TextBox>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <%--
                            <asp:BoundField DataField="MRNO" HeaderText="MRNO" />
                            <asp:BoundField DataField="Balance" HeaderText="Balance" />
                            --%>
                        </Columns>
                    </asp:GridView>
                </div>
                <div class="ButtonsWrapper three-col-button" style="margin-top: 1%">
                    <div class="btn_spaces">
                        <asp:Button ID="btnSave" runat="server" Text="Save" TabIndex="5" CssClass="btnstyle"
                            OnClick="btnSave_Click1" />
                        <asp:Button ID="btnClear" runat="server" Text="Clear" TabIndex="6" CssClass="btnstyle" OnClick="btnClear_Click" />
                        <asp:Button ID="btnView" runat="server" Text="View" TabIndex="7" CssClass="btnstyle" OnClick="btnView_Click" />
                        <%--<asp:Button ID="btnDelete" runat="server" Text="Delete" CssClass="btnstyle" OnClientClick="return ConfirmDelete();"
                            OnClick="btnDelete_Click" />--%>
                    </div>
                </div>
                <div id="ShowViewGrid" runat="server" style="display: none">
                    <div class="three-col-new" style="margin-top: 0.5%">
                        <div class="ControlsWrapper1">
                            <div>
                                <asp:Label ID="lblFromDate" runat="server" Text="From Date"></asp:Label>
                                <asp:TextBox ID="txtFromDate" runat="server" TabIndex="13"></asp:TextBox>
                                <cc1:CalendarExtender ID="CalendarExtender3" Format="dd/MM/yyyy" runat="server" TargetControlID="txtFromDate"
                                    CssClass="cal_Theme">
                                </cc1:CalendarExtender>
                            </div>
                             <div id="MRNOView" runat="server">
                                <asp:Label ID="lblMRNOView" runat="server" Text="MRNO"></asp:Label>
                                <asp:DropDownList ID="ddlMRNo" runat="server" TabIndex="15" AutoPostBack="True" OnSelectedIndexChanged="ddlMRNo_SelectedIndexChanged">
                                <asp:ListItem>--Select</asp:ListItem>
                                </asp:DropDownList>
                            </div>
                            <div id="Div1" runat="server">
                                <asp:Label ID="lblMRNOView1" runat="server" Text="MRNO"></asp:Label>
                                <asp:TextBox ID="txtMRNOView" runat="server" TabIndex="14" AutoPostBack="true" OnTextChanged="txtMRNOView_TextChanged"></asp:TextBox>
                            </div>
                        </div>
                        <div class="ControlsWrapper1">
                            <div>
                                <asp:Label ID="lblToDate" runat="server" Text="To Date"></asp:Label>
                                <asp:TextBox ID="txtToDate" runat="server" TabIndex="14" AutoPostBack="true" OnTextChanged="txtToDate_TextChanged"></asp:TextBox>
                                <cc1:CalendarExtender ID="CalendarExtender4" Format="dd/MM/yyyy" runat="server" TargetControlID="txtToDate"
                                    CssClass="cal_Theme">
                                </cc1:CalendarExtender>
                            </div>
                        </div>
                        <div class="ControlsWrapper1">
                            <div>
                                <asp:Label ID="lblName" runat="server" Text="Name"></asp:Label>
                                <asp:DropDownList ID="ddlName" runat="server" TabIndex="13" AutoPostBack="True" OnSelectedIndexChanged="ddlName_SelectedIndexChanged">
                                </asp:DropDownList>
                            </div>
                        </div>
                    </div>
                </div>
                <div class="gridcol" style="margin-left: 13%">
                    <asp:GridView ID="Gridview" runat="server" AutoGenerateSelectButton="True" OnSelectedIndexChanging="Gridview_SelectedIndexChanging" OnRowCreated="Gridview_RowCreated"
                        BackColor="#DEBA84" BorderColor="#DEBA84" BorderStyle="None" BorderWidth="1px">
                        <FooterStyle BackColor="#F7DFB5" ForeColor="#003f81" />
                        <RowStyle BackColor="#e9edf2" ForeColor="#003f81" />
                        <SelectedRowStyle BackColor="#e9edf2" Font-Bold="True" ForeColor="#003f81" />
                        <PagerStyle ForeColor="#8C4510" HorizontalAlign="Center" />
                        <HeaderStyle BackColor="#dae9f3" Font-Bold="True" ForeColor="White" />
                    </asp:GridView>
                </div>
                <div class="gridcol">
                <asp:GridView ID="Gridview1" runat="server" BackColor="#DEBA84" BorderColor="#DEBA84"
                    BorderStyle="None" BorderWidth="1px" AutoGenerateColumns="False">
                    <Columns>
                    <asp:BoundField DataField="MRNO" HeaderText="MRNo" />
                        <asp:BoundField DataField="PaidDate" HeaderText="Paid Date" />
                        <asp:BoundField DataField="Amount" HeaderText="Amount">
                            <HeaderStyle HorizontalAlign="Right" />
                        </asp:BoundField>
                    </Columns>
                    <FooterStyle BackColor="#F7DFB5" ForeColor="#003f81" />
                    <RowStyle BackColor="#e9edf2" ForeColor="#003f81" />
                    <SelectedRowStyle BackColor="#e9edf2" Font-Bold="True" ForeColor="#003f81" />
                    <PagerStyle ForeColor="#8C4510" HorizontalAlign="Center" />
                    <HeaderStyle BackColor="#dae9f3" Font-Bold="True" ForeColor="White" />
                </asp:GridView>
            </div>
            </div>
            
            <asp:HiddenField ID="hidMRNO" runat="server" />
            <asp:HiddenField ID="hidContact" runat="server" />
            <asp:HiddenField ID="hidPay" runat="server" />
            <asp:HiddenField ID="hidEmpID" runat="server" />
            <asp:HiddenField ID="hidTot" runat="server" />
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
