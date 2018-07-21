<%@ Page Language="C#" MasterPageFile="~/AppMaster.master" AutoEventWireup="true"
    CodeFile="BookingDetails.aspx.cs" Inherits="BookingDetails" Title="Deepak Roadways" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<%--<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
--%><asp:Content ID="Content1" ContentPlaceHolderID="PageContent" runat="Server">

    <script language="JavaScript">
<!--


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
//-->
    </script>

    <cc1:ToolkitScriptManager ID="Too" runat="server">
    </cc1:ToolkitScriptManager>
    <%--<asp:ScriptManager id="ScriptManager1" runat="server"></asp:ScriptManager>--%>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <div id="Page">
                <div class="three-col-new">
                    <asp:Label runat="server" ID="lblResult" Text="result" ForeColor="#FF3300"></asp:Label>
                    <cc1:AutoCompleteExtender ID="AutoHome" runat="server" MinimumPrefixLength="1" ServiceMethod="GetConsignorName"
                        TargetControlID="Consignor" CompletionInterval="1">
                    </cc1:AutoCompleteExtender>
                    <cc1:AutoCompleteExtender ID="AutoCompleteExtender1" runat="server" MinimumPrefixLength="1"
                        ServiceMethod="GetConsigneeName" TargetControlID="Consignee" CompletionInterval="1">
                    </cc1:AutoCompleteExtender>
                    <cc1:AutoCompleteExtender ID="AutoCompleteExtender2" runat="server" MinimumPrefixLength="1"
                        ServiceMethod="GetAgentName" TargetControlID="AgentName" CompletionInterval="1">
                    </cc1:AutoCompleteExtender>
                    <cc1:AutoCompleteExtender ID="AutoCompleteExtender3" runat="server" MinimumPrefixLength="1"
                        ServiceMethod="GetToBranchname" TargetControlID="To" CompletionInterval="1">
                    </cc1:AutoCompleteExtender>
                    <div class="ControlsWrapper1">
                        <div>
                            <asp:Label ID="lblLRNo" runat="server" Text="LRNo"></asp:Label>
                            <asp:TextBox ID="LRNo" TabIndex="1" onkeypress="return isNumberKey(event)" MaxLength="20"
                                runat="server" OnTextChanged="LRNo_TextChanged" AutoPostBack="True"></asp:TextBox>
                        </div>
                        <div>
                            <asp:Label ID="lblBookingDate" runat="server" Text="BookingDate"></asp:Label>
                            <asp:TextBox ID="BookingDate" TabIndex="2" MaxLength="10" runat="server"></asp:TextBox>
                            <cc1:CalendarExtender ID="CalendarExtender1" runat="server" Format="dd/MM/yyyy" TargetControlID="BookingDate"
                                CssClass="cal_Theme">
                            </cc1:CalendarExtender>
                        </div>
                        <div>
                            <asp:Label ID="lblConsignor" runat="server" Text="Consignor"></asp:Label>
                            <asp:TextBox ID="Consignor" TabIndex="3" MaxLength="20" runat="server" AutoPostBack="True"
                                OnTextChanged="Consignor_TextChanged"></asp:TextBox>
                        </div>
                        <div>
                            <asp:Label ID="lblAddress" runat="server" Text="Address"></asp:Label>
                            <asp:TextBox ID="Address" TextMode="MultiLine" MaxLength="100" runat="server" ReadOnly="true"></asp:TextBox>
                        </div>
                        <div>
                            <asp:Label ID="lblCity" runat="server" Text="City"></asp:Label>
                            <asp:TextBox ID="City" MaxLength="15" runat="server" ReadOnly="true"></asp:TextBox>
                        </div>
                        <div>
                            <asp:Label ID="lblPincode" runat="server" Text="Pincode"></asp:Label>
                            <asp:TextBox ID="Pincode" MaxLength="6" runat="server" ReadOnly="true"></asp:TextBox>
                        </div>
                    </div>
                    <div class="ControlsWrapper1">
                        <div>
                            <asp:Label ID="lblConsignee" runat="server" Text="Consignee"></asp:Label>
                            <asp:TextBox ID="Consignee" TabIndex="4" MaxLength="15" runat="server" AutoPostBack="True"
                                OnTextChanged="Consignee_TextChanged"></asp:TextBox>
                        </div>
                        <div>
                            <asp:Label ID="lblConsigneeAddress" runat="server" Text="Consignee Address"></asp:Label>
                            <asp:TextBox ID="ConsigneeAddress" MaxLength="100" TextMode="MultiLine" runat="server"
                                ReadOnly="true"></asp:TextBox>
                        </div>
                        <div>
                            <asp:Label ID="lblCongineeCity" runat="server" Text="Conginee City"></asp:Label>
                            <asp:TextBox ID="ConsigneeCity" MaxLength="20" runat="server" ReadOnly="true"></asp:TextBox>
                        </div>
                        <div>
                            <asp:Label ID="lblCongineePincode" runat="server" Text="Conginee Pincode"></asp:Label>
                            <asp:TextBox ID="ConsigneePincode" MaxLength="6" runat="server" ReadOnly="true"></asp:TextBox>
                        </div>
                        <div>
                            <asp:Label ID="lblStoreNo" runat="server" Text="Godown No"></asp:Label>
                            <%--<asp:TextBox ID="StoreNo" MaxLength="6" TabIndex="5" runat="server" OnTextChanged="StoreNo_TextChanged"></asp:TextBox>--%>
                            <asp:DropDownList ID="StoreNo" runat="server" TabIndex="5" AutoPostBack="True" OnSelectedIndexChanged="StoreNo_SelectedIndexChanged">
                            <asp:ListItem>--SELECT--</asp:ListItem>
                            </asp:DropDownList>
                        </div>
                    </div>
                    <div class="ControlsWrapper1">
                        <div>
                            <asp:Label ID="lblInsuranceCompanyName" runat="server" Text="Insurance CoName"></asp:Label>
                            <asp:TextBox ID="InsuranceCompanyName" TabIndex="6" MaxLength="25" runat="server"></asp:TextBox>
                        </div>
                        <div>
                            <asp:Label ID="lblPolicyNo" runat="server" Text="Policy No"></asp:Label>
                            <asp:TextBox ID="PolicyNo" TabIndex="7" MaxLength="15" runat="server"></asp:TextBox>
                        </div>
                        <div>
                            <asp:Label ID="lblDate" runat="server" Text="Date"></asp:Label>
                            <asp:TextBox ID="Date" TabIndex="8" MaxLength="10" runat="server"></asp:TextBox>
                            <cc1:CalendarExtender ID="CalendarExtender2" Format="dd/MM/yyyy" runat="server" TargetControlID="Date"
                                CssClass="cal_Theme">
                            </cc1:CalendarExtender>
                        </div>
                        <div>
                            <asp:Label ID="lblRisk" runat="server" Text="Risk"></asp:Label>
                            <asp:TextBox ID="Risk" TabIndex="9" MaxLength="25" runat="server"></asp:TextBox>
                        </div>
                        <div>
                            <asp:Label ID="lblAgentName" runat="server" Text="Agent Name"></asp:Label>
                            <asp:TextBox ID="AgentName" TabIndex="10" MaxLength="20" runat="server" AutoPostBack="True"
                                OnTextChanged="AgentName_TextChanged"></asp:TextBox>
                        </div>
                        <div>
                            <asp:Label ID="lblFrom" runat="server" Text="From"></asp:Label>
                            <asp:TextBox ID="From" TabIndex="11" MaxLength="20" runat="server"></asp:TextBox>
                        </div>
                        <div>
                            <asp:Label ID="lblTo" runat="server" Text="To"></asp:Label>
                            <asp:TextBox ID="To" TabIndex="12" MaxLength="20" runat="server"></asp:TextBox>
                        </div>
                    </div>
                    <div class="gridcol" style="margin-left:5%">
                        <asp:GridView ID="GridBook" runat="server" AutoGenerateColumns="False" ShowFooter="True"
                            OnRowCommand="GridBook_RowCommand" OnRowCancelingEdit="GridBook_RowCancelingEdit"
                            OnRowEditing="GridBook_RowEditing" OnRowUpdating="GridBook_RowUpdating" OnRowDeleting="GridBook_RowDeleting">
                            <Columns>
                                <asp:TemplateField HeaderText="Sl.No">
                                    <ItemTemplate>
                                        <%# Container.DataItemIndex + 1 %>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Item ID" Visible="false">
                                    <ItemTemplate>
                                        <asp:Label runat="server" ID="txtBookingDetailsID" Text='<%#Eval("BookingDetailsID")%>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="No.of Packages">
                                    <EditItemTemplate>
                                        <asp:TextBox ID="txtPackages" Width="80px" size="6" runat="server" onfocus="boxExpand2(this)"
                                            onChange="boxExpand1(this)" onKeyPress="boxExpand(this);return isNumberKey(event)"
                                            Text='<%#Bind("Packages") %>'></asp:TextBox>
                                    </EditItemTemplate>
                                    <FooterTemplate>
                                        <asp:TextBox ID="txtPackages1" Width="80px" size="6" TabIndex="13" onfocus="boxExpand2(this)"
                                            onChange="boxExpand1(this)" onKeyPress="boxExpand(this);return isNumberKey(event)"
                                            runat="server" Text='<%#Bind("Packages") %>'></asp:TextBox>
                                    </FooterTemplate>
                                    <ItemTemplate>
                                        <%#Eval("Packages")%>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="ItemName">
                                    <EditItemTemplate>
                                        <asp:DropDownList runat="server" ID="ddlItemName" Width="120px" 
                                            TabIndex="14" >
                                            <asp:ListItem Value="0">---SELECT---</asp:ListItem>
                                        </asp:DropDownList>
                                    </EditItemTemplate>
                                    <FooterTemplate>
                                        <asp:DropDownList runat="server" ID="ddlItemName1" Width="120px" TabIndex="14" >
                                            
                                            <asp:ListItem Value="0">---SELECT---</asp:ListItem>
                                        </asp:DropDownList>
                                    </FooterTemplate>
                                    <ItemTemplate>
                                        <%#Eval("ItemName")%>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                
                                  <asp:TemplateField HeaderText="Packings">
                                    <EditItemTemplate>
                                        <asp:DropDownList ID="ddlPackings" runat="server" TabIndex="15" Width="90px"  
                                        OnSelectedIndexChanged="ddlPackings_SelectedIndexChanged" AutoPostBack="true">
                                            <asp:ListItem Value="0">---Select---</asp:ListItem>
                                            <asp:ListItem Value="1">BUNDLE</asp:ListItem>
                                            <asp:ListItem Value="2">CASE</asp:ListItem>
                                            <asp:ListItem Value="3">CARTOON</asp:ListItem>
                                            <asp:ListItem Value="4">BAGS</asp:ListItem>
                                            <asp:ListItem Value="5">CABLE DRUM</asp:ListItem>
                                        </asp:DropDownList>
                                    </EditItemTemplate>
                                    <FooterTemplate>
                                        <asp:DropDownList ID="ddlPackings1" runat="server" TabIndex="15" Width="100px"
                                        OnSelectedIndexChanged="ddlPackings1_SelectedIndexChanged" AutoPostBack="true">
                                            <asp:ListItem Value="0">---Select---</asp:ListItem>
                                            <asp:ListItem Value="1">BUNDLE</asp:ListItem>
                                            <asp:ListItem Value="2">CASE</asp:ListItem>
                                            <asp:ListItem Value="3">CARTOON</asp:ListItem>
                                            <asp:ListItem Value="4">BAGS</asp:ListItem>
                                            <asp:ListItem Value="5">CABLE DRUM</asp:ListItem>
                                        </asp:DropDownList>
                                    </FooterTemplate>
                                    <ItemTemplate>
                                        <%#Eval("Packings")%>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                
                                <asp:TemplateField HeaderText="Rate">
                                    <EditItemTemplate>
                                        <asp:TextBox ID="txtrate" Width="120px" runat="server"  Text='<%#Bind("Rate") %>'
                                            onKeyPress="return isNumberKey(event)" OnTextChanged="txtrate_TextChanged"></asp:TextBox>
                                    </EditItemTemplate>
                                    <FooterTemplate>
                                        <asp:TextBox ID="txtrate1" Width="120px" TabIndex="17" runat="server" Text='<%#Bind("Rate") %>'
                                            onKeyPress="return isNumberKey(event)" AutoPostBack="true" OnTextChanged="txtrate1_TextChanged"></asp:TextBox>
                                    </FooterTemplate>
                                    <ItemTemplate>
                                        <%#Eval("Rate")%>
                                    </ItemTemplate>
                                </asp:TemplateField>
                              
                                <%--<asp:TemplateField HeaderText="Description">
                                    <EditItemTemplate>
                                        <asp:TextBox ID="txtDesc" size="6" runat="server" Text='<%#Bind("Descr") %>' onfocus="boxExpand2(this)"
                                            onChange="boxExpand1(this)" onKeyPress="boxExpand(this);return alphanumeric_only(this);"></asp:TextBox>
                                    </EditItemTemplate>
                                    <FooterTemplate>
                                        <asp:TextBox ID="txtDesc1" size="6" TabIndex="14" runat="server" Text='<%#Bind("Descr") %>'
                                            onfocus="boxExpand2(this)" onChange="boxExpand1(this)" onKeyPress="boxExpand(this);return alphanumeric_only(this);"></asp:TextBox>
                                    </FooterTemplate>
                                    <ItemTemplate>
                                        <%#Eval("Descr")%>
                                    </ItemTemplate>
                                </asp:TemplateField>--%>
                                <asp:TemplateField HeaderText="Actual Weight">
                                    <EditItemTemplate>
                                        <asp:TextBox ID="txtActualWeight" Width="120px" runat="server"  Text='<%#Bind("Weight") %>'
                                            onKeyPress="return isNumberKey(event)"></asp:TextBox>
                                    </EditItemTemplate>
                                    <FooterTemplate>
                                        <asp:TextBox ID="txtActualWeight1" Width="120px" TabIndex="17" runat="server" Text='<%#Bind("Weight") %>'
                                            onKeyPress="return isNumberKey(event)" AutoPostBack="true" OnTextChanged="txtActualWeight1_TextChanged"></asp:TextBox>
                                    </FooterTemplate>
                                    <ItemTemplate>
                                        <%#Eval("Weight")%>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Charged Weight">
                                    <EditItemTemplate>
                                        <asp:TextBox ID="txtChargedWeight" Width="120px" runat="server" Text='<%#Bind("ChargedWeight") %>'
                                            onKeyPress="return isNumberKey(event)" AutoPostBack="true" OnTextChanged="txtChargedWeight_TextChanged"></asp:TextBox>
                                    </EditItemTemplate>
                                    <FooterTemplate>
                                        <asp:TextBox ID="txtChargedWeight1" Width="120px" TabIndex="18" runat="server" Text='<%#Bind("ChargedWeight") %>'
                                            onKeyPress="return isNumberKey(event)" OnTextChanged="txtChargedWeight1_TextChanged"
                                            AutoPostBack="true"></asp:TextBox>
                                    </FooterTemplate>
                                    <ItemTemplate>
                                        <%#Eval("ChargedWeight")%>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Total">
                                    <EditItemTemplate>
                                        <asp:TextBox ID="txtTotal" Width="120px" runat="server" Text='<%#Bind("Total") %>'
                                            onKeyPress="return isNumberKey(event)"></asp:TextBox>
                                    </EditItemTemplate>
                                    <FooterTemplate>
                                        <asp:TextBox ID="txtTotal1" Width="120px" runat="server" Text='<%#Bind("Total") %>'
                                            onKeyPress="return isNumberKey(event)" ReadOnly="true"></asp:TextBox>
                                    </FooterTemplate>
                                    <ItemTemplate>
                                        <%#Eval("Total")%>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Options">
                                    <EditItemTemplate>
                                        <asp:LinkButton ID="LinkButton1" runat="server" CommandName="Update" Text="<img src='App_Themes/Images/Update.gif' border='0' title='Update' />"
                                            CssClass="buttonimage" Width="25%" TabIndex="19"></asp:LinkButton>
                                        <asp:LinkButton ID="LinkButton2" runat="server" CommandName="Cancel" Text="<img src='App_Themes/Images/Cancel.gif' border='0' title='Cancel' />"
                                            CssClass="buttonimage" Width="25%"></asp:LinkButton>
                                    </EditItemTemplate>
                                    <FooterTemplate>
                                        <asp:LinkButton ID="LinkButton3" runat="server" TabIndex="17" CommandName="InsertNew"
                                            Text="<img src='App_Themes/Images/Insert1.gif' border='0' title='Insert' />"
                                            CssClass="buttonimage" Width="25%"></asp:LinkButton>
                                        <asp:LinkButton ID="LinkButton4" runat="server" CommandName="CancelNew" Text="<img src='App_Themes/Images/Cancel.gif'border='0' title='Cancel'  />"
                                            CssClass="buttonimage" Width="25%"></asp:LinkButton>
                                    </FooterTemplate>
                                    <ItemTemplate>
                                        <asp:LinkButton ID="LinkButton5" runat="server" CommandName="Edit" Text="<img src='App_Themes/Images/Edit.gif' border='0' title='Edit' />"
                                            CssClass="buttonimage" Width="25%"></asp:LinkButton>
                                        <asp:LinkButton ID="LinkButton6" runat="server" CommandName="Delete" OnClientClick="return ConfirmDelete();"
                                            Text="<img src='App_Themes/Images/Del.gif' border='0' title='Delete' />" CssClass="buttonimage"
                                            Width="25%"></asp:LinkButton>
                                    </ItemTemplate>
                                </asp:TemplateField>
                            </Columns>
                        </asp:GridView>
                    </div>
                    <div class="ControlsWrapper1">
                        <div>
                            <asp:Label ID="lblFreightCharges" runat="server" Text="Freight Charges"></asp:Label>
                            <asp:TextBox ID="FreightCharges" TabIndex="20" MaxLength="8" runat="server" AutoPostBack="True"
                                onKeyPress="return isNumberKey(event)" OnTextChanged="FreightCharges_TextChanged"></asp:TextBox>
                        </div>
                        <div>
                            <asp:Label ID="lblHandlingCharges" runat="server" Text="Handling Charges"></asp:Label>
                            <asp:TextBox ID="HandlingCharges" TabIndex="21" MaxLength="8" runat="server" AutoPostBack="True"
                                onKeyPress="return isNumberKey(event)" OnTextChanged="HandlingCharges_TextChanged"></asp:TextBox>
                        </div>
                        <div>
                            <asp:Label ID="lblCartageCharges" runat="server" Text="Cartage Charges"></asp:Label>
                            <asp:TextBox ID="CartageCharges" TabIndex="21" MaxLength="8" runat="server" AutoPostBack="True"
                                onKeyPress="return isNumberKey(event)" OnTextChanged="CartageCharges_TextChanged"></asp:TextBox>
                        </div>
                    </div>
                    <div class="ControlsWrapper1">
                        <div>
                            <asp:Label ID="lblStatisticalCharges" runat="server" Text="Statistical Charges"></asp:Label>
                            <asp:TextBox ID="StatisticalCharges" TabIndex="22" MaxLength="8" runat="server" AutoPostBack="True"
                                onKeyPress="return isNumberKey(event)" OnTextChanged="StatisticalCharges_TextChanged"></asp:TextBox>
                        </div>
                        <div>
                            <asp:Label ID="lblMiscExp" runat="server" Text="Misc.Expenses"></asp:Label>
                            <asp:TextBox ID="MiscExp" TabIndex="23" MaxLength="8" runat="server" AutoPostBack="True"
                                onKeyPress="return isNumberKey(event)" OnTextChanged="MiscExp_TextChanged"></asp:TextBox>
                        </div>
                        <div>
                            <asp:Label ID="lblInsurance" runat="server" Text="Insurance"></asp:Label>
                            <asp:TextBox ID="Insurance" TabIndex="24" MaxLength="8" runat="server" AutoPostBack="True"
                                onKeyPress="return isNumberKey(event)" OnTextChanged="Insurance_TextChanged"></asp:TextBox>
                        </div>
                        <div>
                            <asp:Label ID="lbltopay" runat="server" Text="To Pay"></asp:Label>
                             <asp:CheckBox ID="ChFixed" runat="server"  Width="10%" Height="10%" 
                                oncheckedchanged="ChFixed_CheckedChanged" AutoPostBack="true"/>
                        </div>
                    </div>
                    <div class="ControlsWrapper1">
                        <div>
                            <asp:Label ID="lblAOC" runat="server" Text="A.O.C"></asp:Label>
                            <asp:TextBox ID="AOC" TabIndex="24" MaxLength="8" runat="server" AutoPostBack="True"
                                onKeyPress="return isNumberKey(event)" OnTextChanged="AOC_TextChanged"></asp:TextBox>
                        </div> 
                        <div>
                            <asp:Label ID="lblServiceTax" runat="server" Text="ServiceTax"></asp:Label>
                            <asp:TextBox ID="ServiceTax" TabIndex="25" MaxLength="8" runat="server" AutoPostBack="True"
                                onKeyPress="return isNumberKey(event)" OnTextChanged="ServiceTax_TextChanged"></asp:TextBox>
                        </div>
                        <div>
                            <asp:Label ID="lblTotal" runat="server" Text="Total"></asp:Label>
                            <asp:TextBox ID="Total" MaxLength="8" runat="server" ReadOnly="true"></asp:TextBox>
                        </div>
                        
                        <div>
                            <asp:Label ID="lblpaidamount" runat="server" Text="Paid Amount"></asp:Label>
                            <asp:TextBox ID="txtpaidamount" MaxLength="8" runat="server" 
                                ontextchanged="txtpaidamount_TextChanged" AutoPostBack="true"></asp:TextBox>
                        </div>
                       
                        <div>
                            <asp:Label ID="lblbalance" runat="server" Text="Balance Amount"></asp:Label>
                            <asp:TextBox ID="txtbalanceamount" MaxLength="8" runat="server"></asp:TextBox>
                        </div>
                    </div>
                </div>
                <div class="ButtonsWrapper three-col-button">
                    <div class="btn_spaces">
                        <asp:Button ID="btnSave" runat="server" Text="Save" CssClass="btnstyle" TabIndex="26"
                            OnClick="btnSave_Click"></asp:Button>
                        <asp:Button ID="btnClear" runat="server" Text="Clear" CssClass="btnstyle" TabIndex="27" OnClick="btnClear_Click">
                        </asp:Button>
                        <asp:Button ID="btnDelete" runat="server" Text="Delete" CssClass="btnstyle" TabIndex="28" OnClick="btnDelete_Click"
                            OnClientClick="return ConfirmDelete();"></asp:Button>
                    </div>
                </div>
                 <div id="view" runat="server" style="display: none">
                <div class="three-col">
                   <div class="ControlsWrapper1">
                        <div>
                            <asp:Label ID="lblfromdate" runat="server" Text="From Date"></asp:Label>
                            <asp:TextBox ID="txtfromdate" TabIndex="8" MaxLength="10" runat="server"></asp:TextBox>
                            <cc1:CalendarExtender ID="CalendarExtender3" Format="dd/MM/yyyy" runat="server" TargetControlID="txtfromdate"
                                CssClass="cal_Theme">
                            </cc1:CalendarExtender>
                        </div>
                   </div>
                   <div class="ControlsWrapper1">
                        <div>
                            <asp:Label ID="lbltodate" runat="server" Text="To Date"></asp:Label>
                            <asp:TextBox ID="txttodate"  runat="server"></asp:TextBox>
                            <cc1:CalendarExtender ID="CalendarExtender4" Format="dd/MM/yyyy" runat="server" TargetControlID="txttodate"
                                CssClass="cal_Theme">
                            </cc1:CalendarExtender>
                        </div>
                   </div>
                    <div class="ControlsWrapper1">
                        <div>
                            <asp:Label ID="lblviewLrno" runat="server" Text="Date"></asp:Label>
                            <asp:DropDownList ID="ddllrno" runat="server">
                             <asp:ListItem>"---SELECT---"</asp:ListItem>
                            </asp:DropDownList>
                        </div>
                   </div>
                </div>
                </div>
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
