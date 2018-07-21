<%@ page language="C#" masterpagefile="~/AppMaster.master" autoeventwireup="true" inherits="DeliverySlip, App_Web_utcvgpzk" title="Deepak Roadways" %>

<%@ Register Assembly="CrystalDecisions.Web, Version=10.5.3700.0, Culture=neutral, PublicKeyToken=692fbea5521e1304"
    Namespace="CrystalDecisions.Web" TagPrefix="CR" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="PageContent" runat="Server">
    <cc1:ToolkitScriptManager ID="Too" runat="server">
    </cc1:ToolkitScriptManager>
    <div id="Page">
        <div style="display: block" id="Block_MainPage" runat="server">
            <div class="three-col-new">
                <cc1:AutoCompleteExtender ID="AutoHome" runat="server" MinimumPrefixLength="1" ServiceMethod="GetCategoryName"
                    TargetControlID="CustomerName" CompletionInterval="1">
                </cc1:AutoCompleteExtender>
                <asp:Label runat="server" ID="lblResult" Text="result" ForeColor="#FF3300"></asp:Label>
                <div class="ControlsWrapper1">
                    <div>
                        <asp:Label ID="lblDSlipDate" runat="server" Text="Delivery Slip Date"></asp:Label>
                        <asp:TextBox ID="DSlipDate" onkeypress="return isNumberKey(event);"
                            MaxLength="10" runat="server" AutoPostBack="True"></asp:TextBox>
                        <cc1:CalendarExtender ID="CalendarExtender4" Format="dd/MM/yyyy" runat="server" TargetControlID="DSlipDate"
                            CssClass="cal_Theme">
                        </cc1:CalendarExtender>
                    </div>
                    <div>
                        <asp:Label ID="lblMRNO" runat="server" Text="MRNO"></asp:Label>
                        <asp:TextBox ID="MRNO" TabIndex="1" onkeypress="isValidAlpha(event)" AutoPostBack="True"
                            MaxLength="10" runat="server" OnTextChanged="MRNO_TextChanged"></asp:TextBox>
                    </div>
                    <div>
                        <asp:Label ID="lblLRNo" runat="server" Text="LRNo"></asp:Label>
                        <asp:TextBox ID="LRNo" TabIndex="2" MaxLength="10" runat="server" AutoPostBack="True"
                            OnTextChanged="LRNo_TextChanged"></asp:TextBox>
                    </div>
                    <div>
                        <asp:Label ID="lblCustomerName" runat="server" Text="Customer Name"></asp:Label>
                        <asp:CheckBox ID="CustCheck" runat="server" AutoPostBack="True" />
                        <asp:TextBox ID="CustomerName" TabIndex="3" Width="150px" onkeypress="isValidAlpha(event)"
                            MaxLength="25" runat="server" OnTextChanged="CustomerName_TextChanged" AutoPostBack="true"></asp:TextBox>
                    </div>
                    <div>
                        <asp:Label ID="lblOriCustName" runat="server" Text="Accounts Name"></asp:Label>
                        <asp:TextBox ID="OriCustName" MaxLength="20" runat="server" ReadOnly="true"></asp:TextBox>
                    </div>
                    <div>
                        <asp:Label ID="lblDate" runat="server" Text="Date"></asp:Label>
                        <asp:TextBox ID="Date" onkeypress="return isNumberKey(event);" MaxLength="10" runat="server"
                            AutoPostBack="True"></asp:TextBox>
                        <cc1:CalendarExtender ID="CalendarExtender1" Format="dd/MM/yyyy" runat="server" TargetControlID="Date"
                            CssClass="cal_Theme">
                        </cc1:CalendarExtender>
                    </div>
                   
                    <div>
                      <asp:Label ID="lblCollectedBy" runat="server" Text="Collected By"></asp:Label>
                        <asp:TextBox ID="txtCollectedBy" MaxLength="10" runat="server" OnTextChanged="txtCollectedBy_TextChanged" AutoPostBack="true"></asp:TextBox>
                          <cc1:AutoCompleteExtender ID="AutoCompleteExtender2" runat="server" MinimumPrefixLength="1"
                                ServiceMethod="GetCompletionCollectedBy" TargetControlID="txtCollectedBy" CompletionInterval="1">
                            </cc1:AutoCompleteExtender>
                    </div>
                     
                </div>
                <div class="ControlsWrapper1">
                   
                    <div>
                        <asp:Label ID="lblPackings" runat="server" Text="Packings"></asp:Label>
                        <%--<asp:TextBox ID="Packings" TabIndex="7" onkeypress="return isNumberKey(event);" MaxLength="10"
                        runat="server"></asp:TextBox>--%>
                        <asp:TextBox ID="Packings" MaxLength="10"
                            runat="server"  ReadOnly="true"></asp:TextBox>
                        <%--<asp:DropDownList ID="Packings" runat="server" TabIndex="4" AutoPostBack="true" OnSelectedIndexChanged="Packings_SelectedIndexChanged">
                            <asp:ListItem Value="0">--SELECT--</asp:ListItem>--%>
                            <%--<asp:ListItem Value="1">BUNDLE</asp:ListItem>
                        <asp:ListItem Value="2">CASE</asp:ListItem>
                        <asp:ListItem Value="3">CARTOON</asp:ListItem>
                        <asp:ListItem Value="4">BAGS</asp:ListItem>
                        <asp:ListItem Value="5">CABLE DRUM</asp:ListItem>--%>
                        <%--</asp:DropDownList>--%>
                    </div>
                    <div style="margin-left: 150px">
                        <asp:Label ID="lblFixed" runat="server" Text="Fixed" Visible="false"> </asp:Label>
                        <asp:CheckBox ID="ChFixed" runat="server" AutoPostBack="True" OnCheckedChanged="ChFixed_CheckedChanged" Visible="false"/></div>
                    <div>
                        <asp:Label ID="lblTotalWeight" runat="server" Text="Total Weight"></asp:Label>
                        <asp:TextBox ID="TotalWeight" onkeypress="return isNumberKey(event);" MaxLength="10"
                            runat="server" AutoPostBack="True" ReadOnly="true"></asp:TextBox>
                    </div>
                    <div>
                        <asp:Label ID="lblActualWeight" runat="server" Text="Actual Weight"></asp:Label>
                        <asp:TextBox ID="ActualWeight" TabIndex="5" onkeypress="return isNumberKey(event);"
                            MaxLength="10" runat="server"></asp:TextBox>
                    </div>
                   <%-- <div>
                        <asp:Label ID="lblFreight" runat="server" Text="Freight"></asp:Label>
                        <asp:TextBox ID="Freight" TabIndex="6" onkeypress="return isNumberKey(event);" MaxLength="10"
                            runat="server" OnTextChanged="Freight_TextChanged" AutoPostBack="True"></asp:TextBox>
                    </div>--%>
                    
                    
                     <div>
                        <asp:Label ID="lblNoOfPackages" runat="server" Text="No Of Packages"></asp:Label>
                        <asp:TextBox ID="NoOfPackages" onkeypress="return isNumberKey(event);" MaxLength="10"
                            runat="server" AutoPostBack="True" ReadOnly="true"></asp:TextBox>
                    </div>
                      <div>
                        <asp:Label ID="lblReceivedPkgs" runat="server" Text="Received Packages" visible="false"></asp:Label>
                        <asp:TextBox ID="txtReceivedPkgs" onkeypress="return isNumberKey(event);" MaxLength="10"
                            runat="server" visible="false"  ReadOnly="true"></asp:TextBox>
                    </div>
                      <div>
                        <asp:Label ID="lblDeliveredPkgs" runat="server" Text="Delivered Packages" visible="false"></asp:Label>
                        <asp:TextBox ID="txtDeliveredPkgs" onkeypress="return isNumberKey(event);" MaxLength="10"
                            runat="server" visible="false" AutoPostBack="True" OnTextChanged="txtDeliveredPkgs_TextChanged"></asp:TextBox>
                      </div>
                              <div>
                        <asp:Label ID="lblBalancePkgs" runat="server" Text="Balance Packages" visible="false"></asp:Label>
                        <asp:TextBox ID="txtBalancePkgs" onkeypress="return isNumberKey(event);" MaxLength="10"
                            runat="server" visible="false"  ReadOnly="true"></asp:TextBox>
                            </div>
                    
                    <div>
                        <asp:Label ID="lblPrivateMark" runat="server" Text="PrivateMark"></asp:Label>
                        <asp:TextBox ID="PrivateMarks" MaxLength="10" runat="server"></asp:TextBox>
                    </div>
                    <div>
                        <asp:Label ID="lblContents" runat="server" Text="Contents"></asp:Label>
                        <asp:TextBox ID="Contents" onkeypress="isValidAlpha(event)" MaxLength="20" runat="server"
                            AutoPostBack="True" ReadOnly="true"></asp:TextBox>
                    </div>  
                    
                  <%--  <div>
                        <asp:Label ID="lblDeliveryCh" runat="server" Text="Delivery Ch"></asp:Label>
                        <asp:TextBox ID="DeliveryCh" TabIndex="8" onkeypress="return isNumberKey(event);"
                            MaxLength="20" runat="server" AutoPostBack="True" OnTextChanged="DeliveryCh_TextChanged"></asp:TextBox>
                    </div>--%>
                </div>
                <div class="ControlsWrapper1">
                    <div>
                        <asp:Label ID="lblTotFreight" runat="server" Text="TotFreight"></asp:Label>
                        <asp:TextBox ID="TotFreight" onkeypress="return isNumberKey(event);"
                            MaxLength="10" runat="server" ReadOnly="true" OnTextChanged="TotFreight_TextChanged" AutoPostBack="true"></asp:TextBox>
                    </div>
                      <div>
                        <asp:Label ID="lblLocalCartage" runat="server" Text="Local Cartage"></asp:Label>
                        <asp:TextBox ID="LocalCartage" TabIndex="12" onkeypress="return isNumberKey(event);"
                            MaxLength="10" runat="server" OnTextChanged="LocalCartage_TextChanged" AutoPostBack="true"></asp:TextBox>
                    </div>
                    <div>
                        <asp:Label ID="lblLabour" runat="server" Text="Labour"></asp:Label>
                        <asp:TextBox ID="Labour" TabIndex="9" onkeypress="return isNumberKey(event);" MaxLength="10"
                            runat="server" OnTextChanged="Labour_TextChanged" AutoPostBack="true"></asp:TextBox>
                    </div>
                    <div>
                        <asp:Label ID="lblTotDeliveryCh" runat="server" Text="TotDelivery Ch"></asp:Label>
                        <asp:TextBox ID="TotDeliveryCh" onkeypress="return isNumberKey(event);"
                            MaxLength="20" runat="server" ReadOnly="true" OnTextChanged="TotDeliveryCh_TextChanged" AutoPostBack="true"></asp:TextBox>
                    </div>
                    <div>
                        <asp:Label ID="lblStationaryCh" runat="server" Text="Stationary Ch"></asp:Label>
                        <asp:TextBox ID="StationaryCh" TabIndex="10" onkeypress="return isNumberKey(event);"
                            MaxLength="20" runat="server" OnTextChanged="StationaryCh_TextChanged" AutoPostBack="true"></asp:TextBox>
                    </div>
                    <div>
                        <asp:Label ID="lblDemurrage" runat="server" Text="Demurrage"></asp:Label>
                        <asp:TextBox ID="Demurrage" TabIndex="11" onkeypress="return isNumberKey(event);"
                            MaxLength="10" runat="server" OnTextChanged="Demurrage_TextChanged" AutoPostBack="true" ></asp:TextBox>
                    </div>
                   <%-- <div>
                        <asp:Label ID="lblServiceTax" runat="server" Text="Service Tax"></asp:Label>
                       <%-- <asp:TextBox ID="ServiceTax" TabIndex="7" onkeypress="return isNumberKey(event);"
                            MaxLength="20" runat="server" AutoPostBack="True" OnTextChanged="ServiceTax_TextChanged"></asp:TextBox>--%>
                         <%--<asp:DropDownList ID="ServiceTax" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ServiceTax_SelectedIndexChanged">
                         <asp:ListItem Value="0">--SELECT--</asp:ListItem>
                         <asp:ListItem>0.00</asp:ListItem>
                         <asp:ListItem>3.09</asp:ListItem>
                         </asp:DropDownList>
                    </div>--%>
                  
                    <div>
                        <asp:Label ID="lblTotSerTax" runat="server" Text="TotService"></asp:Label>
                        <asp:TextBox ID="TotSerTax" ReadOnly="true" onkeypress="return isNumberKey(event);"
                            MaxLength="20" runat="server" OnTextChanged="TotSerTax_TextChanged" AutoPostBack="true"></asp:TextBox>
                    </div>
                    <div>
                        <asp:Label ID="lblTotal" runat="server" Text="Total"></asp:Label>
                        <asp:TextBox ID="Total" onkeypress="return isNumberKey(event);" MaxLength="20" runat="server"
                            ReadOnly="true"></asp:TextBox>
                    </div>
                </div>
            </div>
            <div class="ButtonsWrapper three-col-button">
                <div class="btn_spaces">
                    <asp:Button ID="btnEdit" runat="server" Text="Edit" CssClass="btnstyle" Style="background: green"
                        TabIndex="17" OnClick="btnEdit_Click"></asp:Button>
                    <asp:Button ID="btnSave" runat="server" Text="Save" CssClass="btnstyle" TabIndex="13"
                        OnClick="btnSave_Click"></asp:Button>
                    <asp:Button ID="btnClear" runat="server" Text="Clear" CssClass="btnstyle" TabIndex="14" OnClick="btnClear_Click">
                    </asp:Button>
                    <asp:Button ID="btnView" runat="server" Text="View" CssClass="btnstyle" TabIndex="15" OnClick="btnView_Click">
                    </asp:Button>
                    <asp:Button ID="btnDelete" runat="server" Text="Delete" CssClass="btnstyle" TabIndex="16" OnClick="btnDelete_Click"
                        OnClientClick="return ConfirmDelete();"></asp:Button>
                    <asp:Button ID="btnCancel" runat="server" Text="Cancel" CssClass="btnstyle" TabIndex="18" OnClientClick="return ConfirmCancel();"
                        OnClick="btnCancel_Click"></asp:Button>
                    <%--<asp:Button ID="btnReprint" runat="server" Text="Reprint" CssClass="btnstyle"></asp:Button>--%>
                </div>
            </div>
            <%--<div class="three-col">
            <div>
                <asp:Label ID="lblMRNOView" runat="server" Text="MRNO"></asp:Label>
                <asp:TextBox ID="txtMRNO" runat="server" AutoPostBack="True" Width="100"></asp:TextBox>
            </div>
        </div>--%>
            <div style="display: none" id="Show_View_Det" runat="server">
                <div class="three-col-view">
                    <div class="ControlsWrapper_view">
                        <div>
                            <asp:Label ID="lblFromDate" runat="server" Text="FromDate"></asp:Label>
                            <asp:TextBox ID="FDate" runat="server"></asp:TextBox>
                            <cc1:CalendarExtender ID="CalendarExtender2" runat="server" Format="dd/MM/yyyy" TargetControlID="FDate"
                                CssClass="cal_Theme">
                            </cc1:CalendarExtender>
                        </div>
                    </div>
                    <div class="ControlsWrapper_view">
                        <div>
                            <asp:Label ID="lblToDate" runat="server" Text="ToDate"></asp:Label>
                            <asp:TextBox ID="TDate" runat="server" AutoPostBack="True" OnTextChanged="TDate_TextChanged"></asp:TextBox>
                            <cc1:CalendarExtender ID="CalendarExtender3" runat="server" TargetControlID="TDate"
                                Format="dd/MM/yyyy" CssClass="cal_Theme">
                            </cc1:CalendarExtender>
                        </div>
                    </div>
                    <div class="ControlsWrapper_view">
                        <div>
                            <asp:Label ID="lblCName" runat="server" Text="CustomerName"></asp:Label>
                            <asp:DropDownList ID="CName" runat="server" AutoPostBack="True" Width="45%" OnSelectedIndexChanged="CName_SelectedIndexChanged">
                                <asp:ListItem Text="--SELECT--" Value="--SELECT--"></asp:ListItem>
                            </asp:DropDownList>
                        </div>
                    </div>
                </div>
            </div>
            <asp:HiddenField runat="server" ID="hidDSID" />
            <asp:HiddenField runat="server" ID="hidID" />
            <asp:HiddenField runat="server" ID="hidOldPaid" />
            <asp:HiddenField runat="server" ID="hidCustomerID" />
            <div class="gridcol" style="margin-left: 137px;">
                <asp:GridView ID="GridDelivery" runat="server" CellPadding="3" BackColor="#DEBA84"
                    BorderColor="#DEBA84" BorderStyle="None" BorderWidth="1px" CellSpacing="2" AutoGenerateColumns="False"
                    OnSelectedIndexChanged="GridDelivery_SelectedIndexChanged" AllowPaging="True"
                    OnPageIndexChanging="GridDelivery_PageIndexChanging" OnSelectedIndexChanging="GridDelivery_SelectedIndexChanging"
                    PageSize="5">
                    <Columns>
                        <asp:CommandField HeaderText="Select" ShowSelectButton="True" />
                        <asp:BoundField DataField="ID" HeaderText="ID" Visible="False" />
                        <asp:BoundField DataField="LorryChallanDescID" HeaderText="LorryChallanDescID" Visible="False" />
                        <asp:BoundField DataField="ConsigneeName" HeaderText="ConsigneeName" />
                        <asp:BoundField DataField="MRNo" HeaderText="MRNo" />
                    </Columns>
                    <FooterStyle BackColor="#F7DFB5" ForeColor="#003f81" />
                    <RowStyle BackColor="#e9edf2" ForeColor="#003f81" />
                    <SelectedRowStyle BackColor="#e9edf2" Font-Bold="True" ForeColor="#003f81" />
                    <PagerStyle ForeColor="#8C4510" HorizontalAlign="Center" />
                    <HeaderStyle BackColor="#dae9f3" Font-Bold="True" ForeColor="White" />
                </asp:GridView>
            </div>
        </div>
        <div style="display: none; margin-top: 100px" id="DisplayCrysRep" runat="server">
            <div>
                <a href="DeliverySlip.aspx">
                    <img src="App_Themes/Images/Back.png" style="width: 125px; height: 25px" /></a></div>
            <CR:CrystalReportViewer ID="CRViewer" runat="server" AutoDataBind="true" PrintMode="ActiveX"
                DisplayGroupTree="true" />
        </div>
    </div>
</asp:Content>
