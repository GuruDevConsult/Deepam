<%@ page language="C#" masterpagefile="~/AppMaster.master" autoeventwireup="true" inherits="BookingDetails, App_Web_utcvgpzk" title="Deepak Roadways" %>

<%@ Register Assembly="CrystalDecisions.Web, Version=10.5.3700.0, Culture=neutral, PublicKeyToken=692fbea5521e1304"
    Namespace="CrystalDecisions.Web" TagPrefix="CR" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<%--<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>--%>
<asp:Content ID="Content1" ContentPlaceHolderID="PageContent" runat="Server">

    <script language="JavaScript" type="text/javascript">


function boxExpand(me) //For OnKeyPress event
{
	boxValue = me.value.length;
	boxSize = me.size;
	minNum = 6;
	maxNum = 255;
	
	if (boxValue > maxNum)
	{
	}
	else
	{
                
		if (boxValue > minNum)
		{
			me.size = boxValue
		}
		else
                
		if (boxValue < minNum || boxValue != minNum)
		{
			me.size = minNum
		}
	}
}

function boxExpand1(me) // For OnChange event
{
	boxValue = me.value.length;
	boxSize = me.size;
	minNum = 3;
	maxNum = 255;
	
	if (boxValue > maxNum)
	{
	}
	else
	{
                
		if (boxValue > minNum)
		{
			me.size = 1
		}
		else
                
		if (boxValue < minNum || boxValue != minNum)
		{
			me.size = 1
		}
	}
}

function boxExpand2(me) //For OnFocus event
{
	boxValue = me.value.length;
	boxSize = me.size;
	minNum = 6;
	maxNum = 255;
	
	if (boxValue > maxNum)
	{
	}
	else
	{
                
		if (boxValue > minNum)
		{
			me.size = 6
		}
		else
                
		if (boxValue < minNum || boxValue != minNum)
		{
			me.size = 6
		}
	}
}

    </script>

    <cc1:ToolkitScriptManager ID="Too" runat="server">
    </cc1:ToolkitScriptManager>
    <%--<asp:ScriptManager id="ScriptManager1" runat="server"></asp:ScriptManager>--%>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <div id="Page">
            <div style="display: block" id="Block_MainPage" runat="server">
                <div class="three-col-new1">
                    <asp:Label runat="server" ID="lblResult" Text="result" ForeColor="#FF3300"></asp:Label>
                    <%--<cc1:AutoCompleteExtender ID="AutoHome" runat="server" MinimumPrefixLength="1" ServiceMethod="GetConsignorName"
                        TargetControlID="txtConsignor" CompletionInterval="1">
                    </cc1:AutoCompleteExtender>--%>
                    <%--<cc1:AutoCompleteExtender ID="AutoCompleteExtender1" runat="server" MinimumPrefixLength="1"
                        ServiceMethod="GetConsigneeName" TargetControlID="txtConsignee" CompletionInterval="1">
                    </cc1:AutoCompleteExtender>--%>
                    <cc1:AutoCompleteExtender ID="AutoCompleteExtender2" runat="server" MinimumPrefixLength="1"
                        ServiceMethod="GetAgentName" TargetControlID="txtAgentName" CompletionInterval="1">
                    </cc1:AutoCompleteExtender>
                    <cc1:AutoCompleteExtender ID="AutoCompleteExtender3" runat="server" MinimumPrefixLength="1"
                        ServiceMethod="GetToBranchname" TargetControlID="txtTo" CompletionInterval="1">
                    </cc1:AutoCompleteExtender>
                      <cc1:AutoCompleteExtender ID="AutoCompleteExtender4" runat="server" MinimumPrefixLength="1"
                        ServiceMethod="GetItemName" TargetControlID="txtItemName" CompletionInterval="1">
                    </cc1:AutoCompleteExtender>
                     <cc1:AutoCompleteExtender ID="AutoCompleteExtender5" runat="server" MinimumPrefixLength="1"
                        ServiceMethod="GetCustomerName" TargetControlID="txtCustomerName" CompletionInterval="1">
                    </cc1:AutoCompleteExtender>
                    <div class="ControlsWrapper1">
                        
                            <div>
                            <asp:Label ID="lblFrom" runat="server" Text="From"></asp:Label>
                            <asp:TextBox ID="txtFrom"  MaxLength="10" runat="server"></asp:TextBox>
                            </div>
                            <div>
                            <asp:Label ID="lblLRNo" runat="server" Text="LRNO"></asp:Label>
                            <asp:TextBox ID="txtLRNo" TabIndex="1"   MaxLength="10" runat="server" OnTextChanged="txtLRNo_TextChanged" AutoPostBack="true" ></asp:TextBox>
                          </div>
                         <div>
                            <asp:Label ID="lblConsignor" runat="server" Text="Consignor"></asp:Label>
                            <asp:TextBox ID="txtConsignor" runat="server" MaxLength="30" TabIndex="3" OnTextChanged="txtConsignor_TextChanged" AutoPostBack="true"></asp:TextBox>
                        </div>
                        
                         <div>
                            <asp:Label ID="lblNoofPackages" runat="server" Text="No.Of.Packages"></asp:Label>
                            <asp:TextBox ID="txtNoofPackages" TabIndex="6" MaxLength="10" runat="server"></asp:TextBox>
                        </div>
                         <div>
                            <asp:Label ID="lblActualWeight" runat="server" Text="Actual Weight"></asp:Label>
                            <asp:TextBox ID="txtActualWeight" TabIndex="8" MaxLength="10" runat="server"></asp:TextBox>
                        </div>
                          
                          <div>
                            <asp:Label ID="lblItemName" runat="server" Text="Contents"></asp:Label>
                            <asp:TextBox ID="txtItemName" TabIndex="10" MaxLength="30" runat="server" OnTextChanged="txtItemName_TextChanged" AutoPostBack="true"></asp:TextBox>
                        </div>
                        <div>
                            <asp:Label ID="lblPackings" runat="server" Text="Packings"></asp:Label>
                            <asp:DropDownList ID="ddlPackings" MaxLength="10" runat="server" TabIndex="12">
                             <asp:ListItem>--Select--</asp:ListItem>
                            <asp:ListItem>Bundle</asp:ListItem>
                            <asp:ListItem>Case</asp:ListItem>
                            <asp:ListItem>Cartoon</asp:ListItem>
                            <asp:ListItem>Bags</asp:ListItem>
                            <asp:ListItem>Cable Drum</asp:ListItem>
                            </asp:DropDownList>
                        </div>
                      <%--  <div style="margin-left: 150px">
                        <asp:Label ID="lblFixed" runat="server" Text="Fixed"></asp:Label>
                        <asp:CheckBox ID="ChFixed" runat="server" /></div>--%>
                       <%-- <div>
                            <asp:Label ID="lblDeliveryRate" runat="server" Text="Delivery Rate"></asp:Label>
                            <asp:TextBox ID="txtDeliveryRate" runat="server" MaxLength="10" TabIndex="14"  OnTextChanged="txtTo_TextChanged" AutoPostBack="true"></asp:TextBox>
                        </div>
                        --%>
                     
                       
                    </div>
                    <div class="ControlsWrapper1">
                               
                       
                        <div>
                            <asp:Label ID="lblTo" runat="server" Text="TO"></asp:Label>
                            <asp:TextBox ID="txtTo" runat="server" MaxLength="10"   OnTextChanged="txtTo_TextChanged" AutoPostBack="true"></asp:TextBox>
                        </div>
                        <div>
                            <asp:Label ID="lblBookingDate" runat="server" Text="Booking Date"></asp:Label>
                            <asp:TextBox ID="BookingDate" TabIndex="2" MaxLength="10" runat="server"></asp:TextBox>
                            <cc1:CalendarExtender ID="CalendarExtender1" runat="server" Format="dd/MM/yyyy" TargetControlID="BookingDate"
                                CssClass="cal_Theme">
                            </cc1:CalendarExtender>
                             </div>
                     
                         <div>
                            <asp:Label ID="lblConsignee" runat="server" Text="Consignee"></asp:Label>
                            <asp:TextBox ID="txtConsignee" TabIndex="4" MaxLength="30" runat="server" OnTextChanged="txtConsignee_TextChanged" AutoPostBack="true"></asp:TextBox>
                        </div>
                        <div>
                            <asp:Label ID="lblCustomername" runat="server" Text="Customer Name"></asp:Label>
                            <asp:TextBox ID="txtCustomerName" runat="server" MaxLength="30" TabIndex="7" OnTextChanged="txtCustomerName_TextChanged" AutoPostBack="true"></asp:TextBox>
                        </div>
                        
                         <div>
                            <asp:Label ID="lblChargedWeight" runat="server" Text="Charged Weight"></asp:Label>
                            <asp:TextBox ID="txtChargedWeight" TabIndex="9" MaxLength="10" runat="server"></asp:TextBox>
                        </div>
                        <div>
                            <asp:Label ID="lblPrivateMark" runat="server" Text="Private Mark"></asp:Label>
                            <asp:TextBox ID="txtPrivateMark" runat="server" MaxLength="10" TabIndex="11"></asp:TextBox>
                         </div>
                         <div>
                            <asp:Label ID="lblPhoneNumber" runat="server" Text="Phone Number"></asp:Label>
                            <asp:TextBox ID="txtPhoneNumber" runat="server" MaxLength="15" TabIndex="12"></asp:TextBox>
                         </div>
                         <%--  <div>
                            <asp:Label ID="lblRate" runat="server" Text="Rate"></asp:Label>
                            <asp:TextBox ID="txtRate" runat="server" MaxLength="10" TabIndex="13" OnTextChanged="txtRate_TextChanged" AutoPostBack="true"></asp:TextBox>
                        </div>--%>
                          <%--<div>
                            <asp:Label ID="lblServiceTax" runat="server" Text="Rate Of S.T"></asp:Label>
                             <asp:DropDownList ID="ddlServiceTax" TabIndex="15" runat="server" Visible="True" OnSelectedIndexChanged="ddlServiceTax_SelectedIndexChanged" AutoPostBack="true">
                             <asp:ListItem>--Select--</asp:ListItem>
                            </asp:DropDownList>
                            <%--<asp:TextBox ID="txtServiceTax" TabIndex="2" MaxLength="10" runat="server"></asp:TextBox>--%>
                     <%--    </div>--%>
                        
                  
                       
                         
                    </div>
                    <div class="ControlsWrapper1">
                       
                        <div>
                            <asp:Label ID="lblAgentName" runat="server" Text="Agent Name"></asp:Label>
                            <asp:TextBox ID="txtAgentName" runat="server" MaxLength="30" TabIndex="16" OnTextChanged="txtAgentName_TextChanged" AutoPostBack="true"></asp:TextBox>
                        </div>
                         <div>
                            <asp:Label ID="lblPayType" runat="server" Text="PayType"></asp:Label>
                            <asp:DropDownList ID="ddlPayType" TabIndex="17" runat="server" OnSelectedIndexChanged="ddlPayType_SelectedIndexChanged" AutoPostBack="true">
                            <asp:ListItem>--Select--</asp:ListItem>
                            <asp:ListItem>ToPay</asp:ListItem>
                            <asp:ListItem>Paid</asp:ListItem>
                            </asp:DropDownList>
                        </div>
                      
                        <div>
                            <asp:Label ID="lblTotalWeight" runat="server" Text="Freight"></asp:Label>
                            <asp:TextBox ID="txtTotalWeight" runat="server" MaxLength="10" TabIndex="18" OnTextChanged="txtTotalWeight_TextChanged" AutoPostBack="true"></asp:TextBox>
                         </div>
                        <div>
                            <asp:Label ID="lblHandlingCharge" runat="server" Text="Labour Charge"></asp:Label>
                            <asp:TextBox ID="txtHandlingCharge" TabIndex="19" MaxLength="10" runat="server" OnTextChanged="txtHandlingCharge_TextChanged" AutoPostBack="true"></asp:TextBox>
                        </div>
                          <div>
                            <asp:Label ID="lblAcc" runat="server" Text="Delivery Charge"></asp:Label>
                            <asp:TextBox ID="txtAcc" runat="server" MaxLength="10" TabIndex="20" OnTextChanged="txtAcc_TextChanged" AutoPostBack="true"></asp:TextBox>
                        </div>
                         <div>
                            <asp:Label ID="lblStatisticalCharge" runat="server" Text="Statistical Charge"></asp:Label>
                            <asp:TextBox ID="txtStatisticalCharge" runat="server" MaxLength="10" TabIndex="21" OnTextChanged="txtStatisticalCharge_TextChanged" AutoPostBack="true"></asp:TextBox>
                         </div>
                             <div>
                            <asp:Label ID="lblWastageCharge" runat="server" Text="Cartage Charge"></asp:Label>
                            <asp:TextBox ID="txtWastageCharge" TabIndex="22" MaxLength="10" runat="server" OnTextChanged="txtWastageCharge_TextChanged" AutoPostBack="true"></asp:TextBox>
                         </div>
                           <div>
                            <asp:Label ID="lblServiceTaxAmount" runat="server" Text="Serv.Tax Amount"></asp:Label>
                            <asp:TextBox ID="txtServiceTax"  MaxLength="10" runat="server" TabIndex="23" OnTextChanged="txtServiceTax_TextChanged" AutoPostBack="true"></asp:TextBox>
                         </div>
                         
                          <%-- <div>
                            <asp:Label ID="lblInsurance" runat="server" Text="Insurance"></asp:Label>
                            <asp:TextBox ID="txtInsurance" TabIndex="18" MaxLength="10" runat="server" OnTextChanged="txtInsurance_TextChanged" AutoPostBack="true"></asp:TextBox>
                          </div>--%>
                      
                        
                         
                       
                        <div>
                            <asp:Label ID="lblTotal" runat="server" Text="Total"></asp:Label>
                            <asp:TextBox ID="txtTotal" MaxLength="10" runat="server" ></asp:TextBox>
                        </div>
                          
                        <%--<div id="AmountShow" style="display:none" runat="server">
                          <div>
                            <asp:Label ID="lblPaidAmount" runat="server" Text="Paid Amount"></asp:Label>
                            <asp:TextBox ID="txtPaidAmount" MaxLength="10" runat="server" OnTextChanged="txtPaidAmount_TextChanged" AutoPostBack="true" ></asp:TextBox>
                         </div>
                          <div>
                            <asp:Label ID="lblBalance" runat="server" Text="Balance"></asp:Label>
                            <asp:TextBox ID="txtBalance" MaxLength="10" runat="server" ></asp:TextBox>
                         </div>
                         </div>--%>
                        <%--<div>
                            <asp:Label ID="lblInsuranceCompanyDetails" runat="server" Text="InsuranceCom.Det"></asp:Label>
                            <asp:TextBox ID="txtInsuranceCompanyDetails" TabIndex="6" MaxLength="10" runat="server"></asp:TextBox>
                        </div>--%>
                       
                       
                        
                      <%--  <div>
                            <asp:Label ID="lblMiscExp" runat="server" Text="MiscExp"></asp:Label>
                            <asp:TextBox ID="txtMiscExp" TabIndex="17" MaxLength="10" runat="server" OnTextChanged="txtMiscExp_TextChanged" AutoPostBack="true"></asp:TextBox>
                        </div>--%>
                      
                       <%-- <div>
                            <asp:Label ID="lblPaymentMode" runat="server" Text="Payment Mode" Visible="false"></asp:Label>
                             <asp:DropDownList ID="ddlPaymentMode" runat="server" TabIndex="22" Visible="false" OnSelectedIndexChanged="ddlPaymentMode_SelectedIndexChanged" AutoPostBack="true">
                             <asp:ListItem>--Select--</asp:ListItem>
                            <asp:ListItem>Cheque</asp:ListItem>
                            <asp:ListItem>Cash</asp:ListItem>
                            </asp:DropDownList>
                        </div>--%>
                    </div>
                    <div id="ChequeShow" style="display:none" runat="server">
                    <div class="two-col1">
                    <div class="ControlsWrapper1">
                    <div>
                    <asp:Label ID="lblAmount" runat="server" Text="Amount"></asp:Label>
                    <asp:TextBox ID="txtAmount"  MaxLength="10" runat="server"></asp:TextBox>
                    </div>
                    <div>
                    <asp:Label ID="lblChequeDate" runat="server" Text="ChequeDate"></asp:Label>
                    <asp:TextBox ID="txtChequedate"  MaxLength="10" runat="server"></asp:TextBox>
                    <cc1:CalendarExtender ID="CalendarExtender2" runat="server" Format="dd/MM/yyyy" TargetControlID="txtChequedate"
                                CssClass="cal_Theme">
                            </cc1:CalendarExtender>
                    </div>
                    </div>
                    <div class="ControlsWrapper1">
                    <div>
                    <asp:Label ID="lblChequeNo" runat="server" Text="ChequeNo"></asp:Label>
                    <asp:TextBox ID="txtCheque"  MaxLength="10" runat="server"></asp:TextBox>
                    </div>
                    <div>
                    <asp:Label ID="lblbank" runat="server" Text="BankName"></asp:Label>
                    <asp:TextBox ID="txtBankName"  MaxLength="10" runat="server"></asp:TextBox>
                    </div>
                    </div>
                    </div>
                    </div>
                     <div>
                   <%-- <div class="btn_spaces" >
                        <asp:Button ID="txtEnter" runat="server" Text="Enter" CssClass="btnstyle" TabIndex="26"
                             onclick="txtEnter_Click" style="margin-right:40%">
                        </asp:Button>
                    </div>--%>
                    </div>
                   
                </div>
                
                
               
              
                <div style="display: none" id="GridShow" runat="server">
               <div class="gridcol" style="overflow:auto;width: 1200px; height: 350px">
                        <asp:GridView ID="GridBook" runat="server" AutoGenerateColumns="true" AutoGenerateSelectButton="true" OnRowCreated="GridBook_RowCreated"  OnSelectedIndexChanging="GridBook_SelectedIndexChanging">
                       <Columns>
                     <asp:TemplateField HeaderText="S.NO">
                     <ItemTemplate>
                     <%#Container.DataItemIndex+1 %>
                </ItemTemplate>
             </asp:TemplateField>
     </Columns>
                        </asp:GridView>
                    </div>
                  </div>

                <div class="ButtonsWrapper three-col-button">
                    <div class="btn_spaces">
                        <asp:Button ID="btnSave" runat="server" Text="Save" CssClass="btnstyle" TabIndex="27" OnClick="btnSave_Click">
                        </asp:Button>
                        <asp:Button ID="btnClear" runat="server" Text="Clear" CssClass="btnstyle" TabIndex="28" OnClick="btnClear_Click">
                        </asp:Button>
                        <asp:Button ID="btnDelete" runat="server" Text="Delete" CssClass="btnstyle" TabIndex="29" OnClick="btnDelete_Click"
                            OnClientClick="return ConfirmDelete();"></asp:Button>
                             <asp:Button ID="btnVeiw" runat="server" Text="View" CssClass="btnstyle" TabIndex="30" OnClick="btnVeiw_Click">
                        </asp:Button>
                    </div>
                </div>
                <div id="view" runat="server" style="display: none;  margin-bottom:15%">
                <div class="three-col-new1">
                   <div class="ControlsWrapper1">
                        <div>
                            <asp:Label ID="lblfromdate" runat="server" Text="From Date"></asp:Label>
                            <asp:TextBox ID="txtfromdate"  MaxLength="10" runat="server"></asp:TextBox>
                            <cc1:CalendarExtender ID="CalendarExtender3" Format="dd/MM/yyyy" runat="server" TargetControlID="txtfromdate"
                                CssClass="cal_Theme">
                            </cc1:CalendarExtender>
                        </div>
                   </div>
                   <div class="ControlsWrapper1">
                        <div>
                            <asp:Label ID="lbltodate" runat="server" Text="To Date"></asp:Label>
                            <asp:TextBox ID="txttodate"  runat="server" OnTextChanged="txttodate_TextChanged" AutoPostBack="true"></asp:TextBox>
                            <cc1:CalendarExtender ID="CalendarExtender4" Format="dd/MM/yyyy" runat="server" TargetControlID="txttodate"
                                CssClass="cal_Theme">
                            </cc1:CalendarExtender>
                        </div>
                   </div>
                    <div class="ControlsWrapper1">
                        <div>
                            <asp:Label ID="lblAgentName1" runat="server" Text="Agent Name"></asp:Label>
                            <asp:DropDownList ID="ddlAgentName" runat="server" OnSelectedIndexChanged="ddlAgentName_SelectedIndexChanged" AutoPostBack="true">
                             <asp:ListItem>---SELECT---</asp:ListItem>
                            </asp:DropDownList>
                        </div>
                   </div>
                </div>
                </div>
                 <div class="gridcol" style="overflow:auto;width: 1200px; height: 350px">
                         <asp:GridView ID="GridBookView" runat="server" CellPadding="3" BackColor="#DEBA84"
                    BorderColor="#DEBA84" BorderStyle="None" BorderWidth="1px" CellSpacing="2"
                    AllowPaging="true" PageSize="15" 
                             OnSelectedIndexChanging="GridBookView_SelectedIndexChanging" 
                             AutoGenerateSelectButton="True" AutoGenerateColumns="false" >
                             <Columns>
                             <asp:BoundField DataField="ID" HeaderText="ID" Visible="false" />
                              <asp:BoundField DataField="BookingID" HeaderText="BookingID" Visible="false" />
                              <asp:BoundField DataField="ConsignorID" HeaderText="ID" Visible="false" />
                              <asp:BoundField DataField="ConsigneeID" HeaderText="BookingID" Visible="false" />   
                               <asp:BoundField DataField="AgentID" HeaderText="BookingID" Visible="false" />                              
                             <asp:BoundField DataField="BookingDate" HeaderText="Booking Date"/>
                             <asp:BoundField DataField="ConsignorName" HeaderText="Consignor Name"/>
                             <asp:BoundField DataField="ConsigneeName" HeaderText="Consignee Name"/>
                             <asp:BoundField DataField="LRNo" HeaderText="LRNo"/>
                             <asp:BoundField DataField="AgentName" HeaderText="Agent Name"/>
                             <asp:BoundField DataField="StartFrom" HeaderText="From"/>
                             <asp:BoundField DataField="DestTo" HeaderText="To"/>
                              <asp:BoundField DataField="NoOfPackages" HeaderText="No Of Packages" Visible="false"/>
                              <asp:BoundField DataField="ItemName" HeaderText="Item Name" Visible="false"/>
                              <asp:BoundField DataField="Rate" HeaderText="Rate" Visible="false"/> 
                              <asp:BoundField DataField="ActualWeight" HeaderText="ActualWeight" Visible="false"/>
                              <asp:BoundField DataField="ChargedWeight" HeaderText="ChargedWeight" Visible="false"/>
                              <asp:BoundField DataField="TotalWeight" HeaderText="TotalWeight" Visible="false"/>
                              <asp:BoundField DataField="HandlingCharge" HeaderText="To" Visible="false"/>
                              <asp:BoundField DataField="WastageCharge" HeaderText="WastageCharge" Visible="false"/>
                              <asp:BoundField DataField="StatisticalCharge" HeaderText="StatisticalCharge" Visible="false"/>
                              <asp:BoundField DataField="MiscExp" HeaderText="MiscExp" Visible="false"/>
                              <asp:BoundField DataField="ServiceTax" HeaderText="ServiceTax" Visible="false"/>
                              <asp:BoundField DataField="Total" HeaderText="Total" Visible="false"/>
                              
                             </Columns>
                  
                    <FooterStyle BackColor="#F7DFB5" ForeColor="#003f81" />
                    <RowStyle BackColor="#e9edf2" ForeColor="#003f81" />
                    <SelectedRowStyle BackColor="#e9edf2" Font-Bold="True" ForeColor="#003f81" />
                    <PagerStyle ForeColor="#8C4510" HorizontalAlign="Center" />
                    <HeaderStyle BackColor="#dae9f3" Font-Bold="True" ForeColor="White" />
                </asp:GridView>
                    </div>
                </div>
            </div>
            
             <div style="display: none; margin-top: 100px" id="DisplayCrysRep" runat="server">
                <div>
                <a href="BookingDetails.aspx">
                    <img src="App_Themes/Images/Back.png" style="width: 125px; height: 25px" /></a></div>
                    <CR:CrystalReportViewer ID="CRViewer" runat="server" AutoDataBind="true" PrintMode="ActiveX"
                        DisplayGroupTree="true" />
                </div>
            <div>
                <asp:HiddenField runat="server" ID="hidConsignor" />
                <asp:HiddenField runat="server" ID="hidConsignee" />
                <asp:HiddenField runat="server" ID="hidAgent" />
                <asp:HiddenField runat="server" ID="hidID" />
                <asp:HiddenField runat="server" ID="hidStoreID" />
                <asp:HiddenField runat="server" ID="hidBookDetID" />
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
