<%@ page language="C#" masterpagefile="~/AppMaster.master" autoeventwireup="true" inherits="ReceivedBookingDetails, App_Web_utcvgpzk" title="Deepak Roadways" %>
<%--<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>--%>
<%@ Register Assembly="AjaxControlToolkit"Namespace="AjaxControlToolkit" TagPrefix="cc1"%>
<asp:Content ID="Content1" ContentPlaceHolderID="PageContent" Runat="Server">
<cc1:ToolkitScriptManager ID="Too" runat="server"></cc1:ToolkitScriptManager>
    <%--<asp:ScriptManager id="ScriptManager1" runat="server"></asp:ScriptManager>--%>
<asp:UpdatePanel id="UpdatePanel1" runat="server">
        <contenttemplate>
<div id="Page">
    <div class="three-col-new">
    <asp:Label runat="server" ID="lblResult" Text="result" ForeColor="#FF3300"></asp:Label>        
    <cc1:AutoCompleteExtender id="AutoHome" runat="server" MinimumPrefixLength="1" ServiceMethod="GetConsignorName" 
TargetControlID="Consignor" CompletionInterval="1"></cc1:AutoCompleteExtender>
<cc1:AutoCompleteExtender id="AutoCompleteExtender1" runat="server" MinimumPrefixLength="1" ServiceMethod="GetConsigneeName" 
TargetControlID="Consignee" CompletionInterval="1"></cc1:AutoCompleteExtender>
<cc1:AutoCompleteExtender id="AutoCompleteExtender2" runat="server" MinimumPrefixLength="1" ServiceMethod="GetAgentName" 
TargetControlID="AgentName" CompletionInterval="1"></cc1:AutoCompleteExtender>
        <div class="ControlsWrapper1">
            <div>
                <asp:Label id="lblLRNo" runat="server" Text="LRNo"></asp:Label> 
                <asp:TextBox id="LRNo" tabIndex="1" onkeypress="return isNumberKey(event)" 
                    MaxLength="20" runat="server" ontextchanged="LRNo_TextChanged" 
                    AutoPostBack="True"></asp:TextBox>
            </div>
            <div>
                <asp:Label id="lblBookingDate" runat="server" Text="BookingDate"></asp:Label> 
                <asp:TextBox id="BookingDate" tabIndex="2" MaxLength="10" runat="server"></asp:TextBox>
                <cc1:calendarextender ID="CalendarExtender1" runat="server" TargetControlID="BookingDate" CssClass="cal_Theme"></cc1:calendarextender>
            </div>
            <div>
                <asp:Label id="lblConsignor" runat="server" Text="Consignor"></asp:Label> 
                <asp:TextBox id="Consignor" tabIndex="3" MaxLength="20" runat="server" 
                    AutoPostBack="True" ontextchanged="Consignor_TextChanged"></asp:TextBox>
            </div>
            <div>
                <asp:Label id="lblAddress" runat="server" Text="Address"></asp:Label> 
                <asp:TextBox id="Address" TextMode="MultiLine" MaxLength="100" runat="server" ReadOnly="true"></asp:TextBox>
            </div>
            <div>
                <asp:Label id="lblCity" runat="server" Text="City"></asp:Label> 
                <asp:TextBox id="City" MaxLength="15" runat="server" ReadOnly="true"></asp:TextBox>
            </div>
            <div>
                <asp:Label id="lblPincode" runat="server" Text="Pincode"></asp:Label> 
                <asp:TextBox id="Pincode" MaxLength="6" runat="server" ReadOnly="true"></asp:TextBox>
            </div>
            
        </div>
        <div class="ControlsWrapper1">
            <div>
                <asp:Label id="lblConsignee" runat="server" Text="Consignee"></asp:Label> 
                <asp:TextBox id="Consignee" tabIndex="4" MaxLength="15" runat="server" 
                    AutoPostBack="True" ontextchanged="Consignee_TextChanged"></asp:TextBox>
            </div>
            <div>
                <asp:Label id="lblConsigneeAddress" runat="server" Text="Consignee Address"></asp:Label> 
                <asp:TextBox id="ConsigneeAddress" MaxLength="100" TextMode="MultiLine" runat="server" ReadOnly="true"></asp:TextBox>
            </div>
            <div>
                <asp:Label id="lblCongineeCity" runat="server" Text="Conginee City"></asp:Label> 
                <asp:TextBox id="ConsigneeCity" MaxLength="20" runat="server" ReadOnly="true"></asp:TextBox>
            </div>
            <div>
                <asp:Label id="lblCongineePincode" runat="server" Text="Conginee Pincode"></asp:Label> 
                <asp:TextBox id="ConsigneePincode" MaxLength="6" runat="server" ReadOnly="true"></asp:TextBox>
            </div>
        </div>
        <div class="ControlsWrapper1">
            
            <div>
                <asp:Label id="lblInsuranceCompanyName" runat="server" Text="Insurance Co Name"></asp:Label> 
                <asp:TextBox id="InsuranceCompanyName" tabIndex="5" MaxLength="25" runat="server"></asp:TextBox>
            </div>
            <div>
                <asp:Label id="lblPolicyNo" runat="server" Text="Policy No"></asp:Label> 
                <asp:TextBox id="PolicyNo" tabIndex="6" MaxLength="15" runat="server"></asp:TextBox>
            </div>
            <div>
                <asp:Label id="lblDate" runat="server" Text="Date"></asp:Label> 
                <asp:TextBox id="Date" tabIndex="7" MaxLength="10" runat="server"></asp:TextBox>
                <cc1:calendarextender ID="CalendarExtender2" runat="server" TargetControlID="Date" CssClass="cal_Theme"></cc1:calendarextender>
            </div>
            <div>
                <asp:Label id="lblRisk" runat="server" Text="Risk"></asp:Label> 
                <asp:TextBox id="Risk" tabIndex="8" MaxLength="25" runat="server"></asp:TextBox>
            </div>
            <div>
                <asp:Label id="lblAgentName" runat="server" Text="Agent Name"></asp:Label> 
                <asp:TextBox id="AgentName" tabIndex="9" MaxLength="20" runat="server" 
                    AutoPostBack="True" ontextchanged="AgentName_TextChanged"></asp:TextBox>
            </div>
            <div>
                <asp:Label id="lblFrom" runat="server" Text="From"></asp:Label> 
                <asp:TextBox id="From" tabIndex="10" MaxLength="20" runat="server"></asp:TextBox>
            </div>
            <div>
                <asp:Label id="lblTo" runat="server" Text="To"></asp:Label> 
                <asp:TextBox id="To" tabIndex="11" MaxLength="20" runat="server" 
                    ></asp:TextBox>
            </div>
        </div>
        <div class="gridcol">
        <asp:GridView ID="GridBook" runat="server" AutoGenerateColumns="false" 
                ShowFooter="True" onrowcommand="GridBook_RowCommand" 
                onrowcancelingedit="GridBook_RowCancelingEdit" 
                onrowediting="GridBook_RowEditing" onrowupdating="GridBook_RowUpdating" 
                onrowdeleting="GridBook_RowDeleting">
            <Columns>
                <asp:TemplateField HeaderText="Sl.No">
                    <ItemTemplate>
                        <%# Container.DataItemIndex + 1 %>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText ="Item ID" Visible="false">
                    <ItemTemplate >
                    <asp:Label runat="server" ID="txtBookingDetailsID" Text='<%#Eval("BookingDetailsID")%>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText ="No.of Packages">
                    <EditItemTemplate >
                        <asp:TextBox ID ="txtPackages" Width ="120px" runat ="server" onKeyPress="return isNumberKey(event)"  Text ='<%#Bind("Packages") %>' ></asp:TextBox>
                    </EditItemTemplate>
                    <FooterTemplate >
                        <asp:TextBox ID="txtPackages1" Width ="120px" TabIndex="12" onKeyPress="return isNumberKey(event)"  runat ="server" Text ='<%#Bind("Packages") %>' ></asp:TextBox>
                    </FooterTemplate>
                    <ItemTemplate >
                        <%#Eval("Packages")%>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText ="Description">
                    <EditItemTemplate >
                        <asp:TextBox ID ="txtDesc" Width ="120px" runat ="server" Text ='<%#Bind("Descr") %>' onkeypress="return alphanumeric_only(this);"></asp:TextBox>
                    </EditItemTemplate>
                    <FooterTemplate >
                        <asp:TextBox ID="txtDesc1" Width ="120px" TabIndex="13" runat ="server" Text ='<%#Bind("Descr") %>' onkeypress="return alphanumeric_only(this);"></asp:TextBox>
                    </FooterTemplate>
                    <ItemTemplate >
                    <%#Eval("Descr")%>
                    </ItemTemplate>
                </asp:TemplateField>
                
                <asp:TemplateField HeaderText ="Actual Weight">
                    <EditItemTemplate >
                        <asp:TextBox ID ="txtActualWeight" Width ="120px" runat ="server" Text ='<%#Bind("Weight") %>' onKeyPress="return isNumberKey(event)"></asp:TextBox>
                    </EditItemTemplate>
                    <FooterTemplate >
                        <asp:TextBox ID="txtActualWeight1" Width ="120px" TabIndex="14" runat ="server" Text ='<%#Bind("Weight") %>' onKeyPress="return isNumberKey(event)"></asp:TextBox>
                    </FooterTemplate>
                    <ItemTemplate >
                        <%#Eval("Weight")%>
                    </ItemTemplate>
                </asp:TemplateField> 
                <asp:TemplateField HeaderText ="Charged Weight">
                    <EditItemTemplate >
                        <asp:TextBox ID ="txtChargedWeight" Width ="120px" runat ="server" Text ='<%#Bind("ChargedWeight") %>' onKeyPress="return isNumberKey(event)"></asp:TextBox>
                    </EditItemTemplate>
                    <FooterTemplate >
                        <asp:TextBox ID="txtChargedWeight1" Width ="120px" TabIndex="15" runat ="server" Text ='<%#Bind("ChargedWeight") %>' onKeyPress="return isNumberKey(event)"></asp:TextBox>
                    </FooterTemplate>
                    <ItemTemplate >
                        <%#Eval("ChargedWeight")%>
                    </ItemTemplate>
                </asp:TemplateField> 
                <asp:TemplateField  HeaderText ="Options">
                   <EditItemTemplate >
                    <asp:LinkButton ID="LinkButton1" runat="server" CommandName ="Update" Text ="<img src='App_Themes/Images/Update.gif' border='0' title='Update' />" CssClass="buttonimage" Width ="25%"></asp:LinkButton>
                    <asp:LinkButton ID="LinkButton2" runat="server" CommandName ="Cancel" Text ="<img src='App_Themes/Images/Cancel.gif' border='0' title='Cancel' />" CssClass="buttonimage" Width ="25%"></asp:LinkButton>
                   </EditItemTemplate> 
                   <FooterTemplate >
                    <asp:LinkButton ID="LinkButton3" runat="server" TabIndex="16" CommandName ="InsertNew" Text ="<img src='App_Themes/Images/Insert1.gif' border='0' title='Insert' />" CssClass="buttonimage" Width ="25%"></asp:LinkButton>
                    <asp:LinkButton ID="LinkButton4" runat="server" CommandName ="CancelNew" Text ="<img src='App_Themes/Images/Cancel.gif'border='0' title='Cancel'  />" CssClass="buttonimage" Width ="25%"></asp:LinkButton>
                   </FooterTemplate>
                   <ItemTemplate >
                     <asp:LinkButton ID="LinkButton5" runat="server" CommandName ="Edit" Text ="<img src='App_Themes/Images/Edit.gif' border='0' title='Edit' />" CssClass="buttonimage" Width ="25%"></asp:LinkButton>
                     <asp:LinkButton ID="LinkButton6" runat="server" CommandName ="Delete" OnClientClick="return ConfirmDelete();" Text ="<img src='App_Themes/Images/Del.gif' border='0' title='Delete' />" CssClass="buttonimage" Width ="25%"></asp:LinkButton>
                   </ItemTemplate>                       
                </asp:TemplateField> 
            </Columns>
        </asp:GridView>
        </div>
        <div class="ControlsWrapper1">
            <div>
                <asp:Label id="lblFreightCharges" runat="server" Text="Freight Charges"></asp:Label> 
                <asp:TextBox id="FreightCharges" tabIndex="17" MaxLength="8" runat="server" 
                    AutoPostBack="True" onKeyPress="return isNumberKey(event)" ontextchanged="FreightCharges_TextChanged"></asp:TextBox>
            </div>
            <div>
                <asp:Label id="lblHandlingCharges" runat="server" Text="Handling Charges"></asp:Label> 
                <asp:TextBox id="HandlingCharges" tabIndex="18" MaxLength="8" runat="server" 
                    AutoPostBack="True" onKeyPress="return isNumberKey(event)" ontextchanged="HandlingCharges_TextChanged"></asp:TextBox>
            </div>
            <div>
                <asp:Label id="lblCartageCharges" runat="server" Text="Cartage Charges"></asp:Label> 
                <asp:TextBox id="CartageCharges" tabIndex="19" MaxLength="8" runat="server" 
                    AutoPostBack="True" onKeyPress="return isNumberKey(event)" ontextchanged="CartageCharges_TextChanged"></asp:TextBox>
            </div>
        </div>
        <div class="ControlsWrapper1">
            <div>
                <asp:Label id="lblStatisticalCharges" runat="server" Text="Statistical Charges"></asp:Label> 
                <asp:TextBox id="StatisticalCharges" tabIndex="20" MaxLength="8" runat="server" 
                    AutoPostBack="True" onKeyPress="return isNumberKey(event)" ontextchanged="StatisticalCharges_TextChanged"></asp:TextBox>
            </div>
            <div>
                <asp:Label id="lblMiscExp" runat="server" Text="Misc.Expenses"></asp:Label> 
                <asp:TextBox id="MiscExp" tabIndex="21" MaxLength="8" runat="server" 
                    AutoPostBack="True" onKeyPress="return isNumberKey(event)" ontextchanged="MiscExp_TextChanged"></asp:TextBox>
            </div>
            <div>
                <asp:Label id="lblInsurance" runat="server" Text="Insurance"></asp:Label> 
                <asp:TextBox id="Insurance" tabIndex="22" MaxLength="8" runat="server" 
                    AutoPostBack="True" onKeyPress="return isNumberKey(event)" ontextchanged="Insurance_TextChanged"></asp:TextBox>
            </div>
        </div>
        <div class="ControlsWrapper1">
            <div>
                <asp:Label id="lblAOC" runat="server" Text="A.O.C"></asp:Label> 
                <asp:TextBox id="AOC" tabIndex="23" MaxLength="8" runat="server" 
                    AutoPostBack="True" onKeyPress="return isNumberKey(event)" ontextchanged="AOC_TextChanged"></asp:TextBox>
            </div>
            <div>
                <asp:Label id="lblServiceTax" runat="server" Text="Service Tax"></asp:Label> 
                <asp:TextBox id="ServiceTax" tabIndex="24" MaxLength="8" runat="server" 
                    AutoPostBack="True" onKeyPress="return isNumberKey(event)" ontextchanged="ServiceTax_TextChanged"></asp:TextBox>
            </div>
            <div>
                <asp:Label id="lblTotal" runat="server" Text="ToPay Total"></asp:Label> 
                <asp:TextBox id="Total" MaxLength="8" runat="server" ReadOnly="true"></asp:TextBox>
            </div>
            <div>
                <asp:Label id="lblPaidTotal" runat="server" Text="Paid Total"></asp:Label> 
                <asp:TextBox id="PaidTotal" TabIndex="25" MaxLength="8" runat="server" ></asp:TextBox>
            </div>
        </div>
    </div>
    <DIV class="ButtonsWrapper three-col-button">
        <DIV class="btn_spaces">
            <asp:Button id="btnSave" runat="server" Text="Save" CssClass="btnstyle" 
                TabIndex="26" onclick="btnSave_Click"></asp:Button> 
            <asp:Button id="btnClear" runat="server" Text="Clear" CssClass="btnstyle" 
                onclick="btnClear_Click"></asp:Button> 
            <asp:Button id="btnDelete" runat="server" Text="Delete" CssClass="btnstyle" 
                onclick="btnDelete_Click"></asp:Button> 
        </DIV>
    </DIV>
    
    <div style="display:none">
        <DIV>
             <asp:Label id="lblPhoneNo" runat="server" meta:resourcekey="lblConsigneePhNo" Text="CusPhNo"></asp:Label> 
             <asp:TextBox id="ConsigneePhNo" runat="server" meta:resourcekey="MailIDResource2"></asp:TextBox>
        </DIV>
         <DIV>
             <asp:Label id="Label1" runat="server" meta:resourcekey="lblCompanyPhNo" Text="CusPhNo"></asp:Label> 
             <asp:TextBox id="phno" runat="server" meta:resourcekey="MailIDResource2"></asp:TextBox>
        </DIV>
    </div>
</div>
<div>
    <asp:HiddenField runat="server" ID="hidConsignor" />
    <asp:HiddenField runat="server" ID="hidConsignee" />
    <asp:HiddenField runat="server" ID="hidAgent" />
    <asp:HiddenField runat="server" ID="hidID" />
    <asp:HiddenField runat="server" ID="hidBookDetID" />
</div>
</contenttemplate>
    </asp:UpdatePanel>
</asp:Content>

