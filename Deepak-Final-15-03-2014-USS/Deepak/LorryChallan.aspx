<%@ page language="C#" masterpagefile="~/AppMaster.master" autoeventwireup="true" inherits="LorryChallan, App_Web_zwikzsdt" title="Deepak Roadways" %>

<%@ Register Assembly="CrystalDecisions.Web, Version=10.5.3700.0, Culture=neutral, PublicKeyToken=692fbea5521e1304"
    Namespace="CrystalDecisions.Web" TagPrefix="CR" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content2" ContentPlaceHolderID="PageContent" runat="Server">
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
                                <asp:Label ID="lblChallanNo" runat="server" Text="Challan No"></asp:Label>
                                <asp:TextBox ID="txtChallanNo" TabIndex="1" onkeypress="return isNumberKey(event);"
                                    MaxLength="20" runat="server" OnTextChanged="txtChallanNo_TextChanged" AutoPostBack="True"></asp:TextBox>
                            </div>
                            <div>
                                <asp:Label ID="lblChallanDate" runat="server" Text="Challan Date"></asp:Label>
                                <asp:TextBox ID="txtChallanDate" TabIndex="2" MaxLength="20" runat="server"></asp:TextBox>
                                <cc1:CalendarExtender ID="CalendarExtender4" runat="server" TargetControlID="txtChallanDate"
                                    Format="dd/MM/yyyy" CssClass="cal_Theme">
                                </cc1:CalendarExtender>
                            </div>
                            <div>
                                <asp:Label ID="lblStartFrom" runat="server" Text="Start From"></asp:Label>
                                <asp:TextBox ID="txtStartFrom" MaxLength="10" TabIndex="3" runat="server" onkeypress="return alphanumeric_only(this);"></asp:TextBox>
                            </div>
                            <div>
                                <cc1:AutoCompleteExtender ID="AutoCompleteExtender3" runat="server" MinimumPrefixLength="1"
                                    ServiceMethod="GetCompletionBranch" TargetControlID="txtEndTo" CompletionInterval="1">
                                      </cc1:AutoCompleteExtender>
                                <asp:Label ID="lblEndTo" runat="server" Text="End To"></asp:Label>
                                <asp:TextBox ID="txtEndTo" TabIndex="4" MaxLength="20" runat="server" onkeypress="return alphanumeric_only(this);" OnTextChanged="txtEndTo_TextChanged" AutoPostBack="true"></asp:TextBox>
                                <%--<cc1:calendarextender ID="CalendarExtender2" runat="server" TargetControlID="txtEndTo" CssClass="cal_Theme"></cc1:calendarextender>--%>
                            </div>
                            <div>
                                <asp:Label ID="lblArrivalDate" runat="server" Text="Arrival Date"></asp:Label>
                                <asp:TextBox ID="txtArrivalDate" TabIndex="5" MaxLength="20" runat="server" onkeypress="return alphanumeric_only(this);"></asp:TextBox>
                                <cc1:CalendarExtender ID="CalendarExtender3" runat="server" TargetControlID="txtArrivalDate"
                                    Format="dd/MM/yyyy" CssClass="cal_Theme">
                                </cc1:CalendarExtender>
                            </div>
                        </div>
                        <div class="ControlsWrapper1">
                            <%--<div>
               <asp:Label id="lblStoreNo" runat="server" Text="Store No"></asp:Label> 
                <asp:TextBox id="txtStoreNo" TabIndex="5" MaxLength="15" runat="server" 
                    onkeypress="return isNumberKey(event);" AutoPostBack="True" 
                    ontextchanged="txtStoreNo_TextChanged" ></asp:TextBox>
                    <asp:Label id="lblStoreNo" runat="server" Text="Godown No"></asp:Label>
         <asp:DropDownList ID="ddlStoreNo" runat="server" AutoPostBack="True" 
                   onselectedindexchanged="ddlStoreNo_SelectedIndexChanged">
         </asp:DropDownList>  
          </div>
         --%>
                            <div>
                                <asp:Label ID="lblTruckNo" runat="server" Text="Truck No"></asp:Label>
                                <asp:TextBox ID="txtTruckNo" TabIndex="6" MaxLength="15" runat="server" onkeypress="return alphanumeric_only(this);"></asp:TextBox>
                            </div>
                            <div>
                                <asp:Label ID="lblDrivername" runat="server" Text="Name of Driver"></asp:Label>
                                <asp:TextBox ID="txtDrivername" TabIndex="7" MaxLength="100" runat="server" onkeypress="return alphanumeric_only(this);"></asp:TextBox>
                            </div>
                            <div>
                                <asp:Label ID="lblDriverPhoneNo" runat="server" Text="Driver Phone No"></asp:Label>
                                <asp:TextBox ID="txtDriverPhoneNo" TabIndex="8" MaxLength="12" runat="server" onkeypress="return isNumberKey(event);"></asp:TextBox>
                            </div>
                            <div>
                                <cc1:AutoCompleteExtender ID="AutoHome" runat="server" MinimumPrefixLength="1" ServiceMethod="GetCompletionHome"
                                    TargetControlID="txtOwnername" CompletionInterval="1">
                                </cc1:AutoCompleteExtender>
                                <asp:Label ID="lblOwnername" runat="server" Text="Truck Owner's Name"></asp:Label>
                                <asp:TextBox ID="txtOwnername" TabIndex="9" MaxLength="20" runat="server" 
                                  OnTextChanged="txtOwnername_TextChanged" AutoPostBack="true" ></asp:TextBox>
                            </div>
                        </div>
                        <div class="ControlsWrapper1">
                            <div>
                                <asp:Label ID="lblAddress" runat="server" Text="Address"></asp:Label>
                                <asp:TextBox ID="txtAddress" MaxLength="25" TextMode="MultiLine" runat="server"></asp:TextBox>
                            </div>
                            <div>
                                <asp:Label ID="lblCity" runat="server" Text="City"></asp:Label>
                                <asp:TextBox ID="txtCity" MaxLength="15" runat="server"></asp:TextBox>
                            </div>
                            <div>
                                <cc1:AutoCompleteExtender ID="AutoCompleteExtender1" runat="server" MinimumPrefixLength="1"
                                    ServiceMethod="GetCompletionHome_Agent" TargetControlID="txtAgentName" CompletionInterval="1">
                                </cc1:AutoCompleteExtender>
                                <asp:Label ID="lblAgentName" runat="server" Text="Agent Name"></asp:Label>
                                <asp:TextBox ID="txtAgentName"  ReadOnly="true" MaxLength="10" runat="server"
                                    OnTextChanged="txtAgentName_TextChanged"></asp:TextBox>
                            </div>
                           <div>
                                <asp:Label ID="lblGodownNo" runat="server" Text="Godown No" Visible="false"></asp:Label>
                                <asp:DropDownList ID="ddlGodownNo" runat="server" TabIndex="10" MaxLength="11" OnSelectedIndexChanged="ddlGodownNo_SelectedIndexChanged"
                                    AutoPostBack="true" Visible="false">
                                    <asp:ListItem>--Select--</asp:ListItem>
                                </asp:DropDownList>
                            </div>
                        </div>
                        <asp:HiddenField ID="Hidownersid" runat="server" />
                        <asp:HiddenField ID="Hid_update" runat="server" />
                        <asp:HiddenField ID="Hid_AgentName" runat="server" />
                        <asp:HiddenField ID="Hid_AgentCode" runat="server" />
                    </div>
                    <div class="gridcol_Outside">
                    </div>
                    <div class="ButtonsWrapper three-col-button">
                        <div class="btn_spaces">
                            <asp:Button ID="btnSave" runat="server" Text="Save" CssClass="btnstyle" TabIndex="27"
                                OnClick="btnSave_Click"></asp:Button>
                            <asp:Button ID="btnView" runat="server" Text="View" CssClass="btnstyle" TabIndex="28" OnClick="btnView_Click">
                            </asp:Button>
                            <asp:Button ID="btnClear" runat="server" Text="Clear" CssClass="btnstyle" TabIndex="29" OnClick="btnClear_Click">
                            </asp:Button>
                            <asp:Button ID="btnDelete" runat="server" Text="Delete" CssClass="btnstyle" TabIndex="30" OnClick="btnDelete_Click" /></asp:Button>
                        </div>
                    </div>
                    <div style="display: none" id="Show_View_Challan" runat="server">
                        <div class="three-col-view">
                            <div class="ControlsWrapper_view">
                                <div>
                                    <asp:Label ID="lblFromDate" runat="server" Text="From Date"></asp:Label>
                                    <asp:TextBox ID="txtFromDate" runat="server" Width="150"></asp:TextBox>
                                    <cc1:CalendarExtender ID="calFromDate" runat="server" TargetControlID="txtFromDate"
                                        CssClass="cal_Theme">
                                    </cc1:CalendarExtender>
                                </div>
                            </div>
                            <div class="ControlsWrapper_view">
                                <div>
                                    <asp:Label ID="lblToDate" runat="server" Text="ToDate"></asp:Label>
                                    <asp:TextBox ID="txtToDate" runat="server" Width="150" AutoPostBack="True" OnTextChanged="txtToDate_TextChanged"></asp:TextBox>
                                    <cc1:CalendarExtender ID="calToDate" runat="server" TargetControlID="txtToDate" CssClass="cal_Theme">
                                    </cc1:CalendarExtender>
                                </div>
                            </div>
                            <div class="ControlsWrapper_view">
                                <div>
                                    <asp:Label ID="lblChallanNo_View" runat="server" Text="ChallanNo"></asp:Label>
                                    <asp:DropDownList ID="ddlChallanNo_View" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlChallanNo_View_SelectedIndexChanged">
                                    </asp:DropDownList>
                                </div>
                            </div>
                            <asp:HiddenField ID="hidStoreID" runat="server" />
                        </div>
                    </div>
                    <div class="gridcol_Outside" style="margin-left: 8.4%">
                        <asp:GridView ID="GridLorrychallan" runat="server" AutoGenerateColumns="False" OnRowCancelingEdit="GridLorrychallan_RowCancelingEdit"
                            OnRowCommand="GridLorrychallan_RowCommand" OnRowDeleting="GridLorrychallan_RowDeleting"
                            OnRowEditing="GridLorrychallan_RowEditing" OnRowUpdating="GridLorrychallan_RowUpdating"
                            ShowFooter="True">
                            <Columns>
                                <asp:TemplateField HeaderText="Sl.No">
                                    <ItemTemplate>
                                        <%# Container.DataItemIndex + 1 %>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField Visible="false">
                                    <HeaderTemplate>
                                        <asp:CheckBox ID="ChkHeader" runat="server" AutoPostBack="True" OnCheckedChanged="ChkHeader_CheckedChanged" />
                                    </HeaderTemplate>
                                    <ItemTemplate>
                                        <asp:CheckBox ID="ChkItem" runat="server" Width="18px" />
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Challan ID" Visible="false">
                                    <ItemTemplate>
                                        <asp:Label ID="txtLorryChallanID" runat="server" Text='<%#Eval("LorryChallanID")%>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                
                                <asp:TemplateField HeaderText="LR.NO">
                                    <EditItemTemplate>
                                        <asp:TextBox ID="txtLrno_edit" runat="server" onKeyPress="return isNumberKey(event);"
                                            TabIndex="13" Text='<%#Bind("LRNo") %>' Width="50px" 
                                            AutoPostBack="True"></asp:TextBox>
                                    </EditItemTemplate>
                                    <FooterTemplate>
                                        <asp:TextBox ID="txtLrno_footer" runat="server" onKeyPress="return isNumberKey(event);"
                                            TabIndex="13" Text='<%#Bind("LRNo") %>' Width="50px" OnTextChanged="txtLrno_footer_TextChanged"
                                            AutoPostBack="True"></asp:TextBox>
                                    </FooterTemplate>
                                    <ItemTemplate>
                                         <asp:Label ID="txtLrno" runat="server" Text='<%#Eval("LRNo")%>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Date">
                                    <EditItemTemplate>
                                        <asp:TextBox ID="txtDate" runat="server" onKeyPress="return isNumberKey(event);"
                                            TabIndex="12" Text='<%#Bind("Date") %>' Width="88px"></asp:TextBox>
                                        <cc1:CalendarExtender ID="CalendarExtender2" runat="server" CssClass="cal_Theme"
                                            Format="dd/MM/yyyy" TargetControlID="txtDate">
                                        </cc1:CalendarExtender>
                                    </EditItemTemplate>
                                    <FooterTemplate>
                                        <asp:TextBox ID="txtDate1" runat="server" onKeyPress="return isNumberKey(event);"
                                            TabIndex="12" Text='<%#Bind("Date") %>' Width="88px"></asp:TextBox>
                                        <cc1:CalendarExtender ID="CalendarExtender2" runat="server" CssClass="cal_Theme"
                                            Format="dd/MM/yyyy" TargetControlID="txtDate1">
                                        </cc1:CalendarExtender>
                                    </FooterTemplate>
                                    <ItemTemplate>
                                        <%#Eval("Date")%>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                
                                <asp:TemplateField HeaderText="Content">
                                    <EditItemTemplate>
                                        <asp:TextBox ID="txtContents_edit" runat="server" onkeypress="return alphanumeric_only(this);"
                                            TabIndex="15" Text='<%#Bind("Contents") %>' Width="100px"></asp:TextBox>
                                    </EditItemTemplate>
                                    <FooterTemplate>
                                        <asp:TextBox ID="txtContents_footer" runat="server" onkeypress="return alphanumeric_only(this);"
                                            TabIndex="15" Text='<%#Bind("Contents") %>' Width="100px"></asp:TextBox>
                                    </FooterTemplate>
                                    <ItemTemplate>
                                        <%#Eval("Contents")%>
                                    </ItemTemplate>
                                </asp:TemplateField>
                            
                                <%-- <asp:TemplateField HeaderText ="Destination">
                    <EditItemTemplate >
                        <asp:TextBox ID ="txtDestination_edit" Width ="120px" runat ="server" Text ='<%#Bind("Destination") %>' onkeypress="return alphanumeric_only(this);"  ></asp:TextBox>
                    </EditItemTemplate>
                    <FooterTemplate >
                        <asp:TextBox ID="txtDestination_footer" Width ="120px" TabIndex="15" runat ="server" Text ='<%#Bind("Destination") %>' onkeypress="return alphanumeric_only(this);" ></asp:TextBox>
                    </FooterTemplate>
                    <ItemTemplate >
                        <%#Eval("Destination")%>
                    </ItemTemplate>
                </asp:TemplateField> 
               --%>
                               
                                <asp:TemplateField HeaderText="Actual Weight">
                                    <EditItemTemplate>
                                        <asp:TextBox ID="txtWeight_edit" runat="server" onKeyPress="return isNumberKey(event)"
                                            Text='<%#Bind("Weight") %>' Width="60px" TabIndex="17"></asp:TextBox>
                                    </EditItemTemplate>
                                    <FooterTemplate>
                                        <asp:TextBox ID="txtWeight_footer" runat="server" onKeyPress="return isNumberKey(event)"
                                            TabIndex="17" Text='<%#Bind("Weight") %>' Width="60px"></asp:TextBox>
                                    </FooterTemplate>
                                    <ItemTemplate>
                                        <%#Eval("Weight")%>
                                    </ItemTemplate>
                                </asp:TemplateField>
                               <asp:TemplateField HeaderText="Charged Weight">
                                    <EditItemTemplate>
                                        <asp:TextBox ID="txtChargedWeight_edit" runat="server" onKeyPress="return isNumberKey(event)"
                                            Text='<%#Bind("ChargedWeight") %>' Width="60px" TabIndex="17"></asp:TextBox>
                                    </EditItemTemplate>
                                    <FooterTemplate>
                                        <asp:TextBox ID="txtChargedWeight_footer" runat="server" onKeyPress="return isNumberKey(event)"
                                            TabIndex="17" Text='<%#Bind("ChargedWeight") %>' Width="60px"></asp:TextBox>
                                    </FooterTemplate>
                                    <ItemTemplate>
                                        <%#Eval("ChargedWeight")%>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="To Pay">
                                    <EditItemTemplate>
                                        <asp:TextBox ID="txtToPay_edit" runat="server" onKeyPress="return isNumberKey(event)"
                                            Text='<%#Bind("ToPay") %>' Width="60px" TabIndex="18"></asp:TextBox>
                                    </EditItemTemplate>
                                    <FooterTemplate>
                                        <asp:TextBox ID="txtToPay_footer" runat="server" onKeyPress="return isNumberKey(event)"
                                            TabIndex="18" Text='<%#Bind("ToPay") %>' Width="60px"></asp:TextBox>
                                    </FooterTemplate>
                                    <ItemTemplate>
                                        <%#Eval("ToPay")%>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Paid">
                                    <EditItemTemplate>
                                        <asp:TextBox ID="txtPaid_edit" runat="server" onKeyPress="return isNumberKey(event)"
                                            Text='<%#Bind("Paid") %>' Width="60px" TabIndex="19"></asp:TextBox>
                                    </EditItemTemplate>
                                    <FooterTemplate>
                                        <asp:TextBox ID="txtPaid_footer" runat="server" onKeyPress="return isNumberKey(event)"
                                            TabIndex="19" Text='<%#Bind("Paid") %>' Width="60px"></asp:TextBox>
                                    </FooterTemplate>
                                    <ItemTemplate>
                                        <%#Eval("Paid")%>
                                    </ItemTemplate>
                                </asp:TemplateField>
                               <%-- <asp:TemplateField HeaderText="Branch">
                                    <EditItemTemplate>
                                        <asp:DropDownList ID="ddlBranch_edit" runat="server" TabIndex="20" Width="60px">
                                        </asp:DropDownList
                                    </EditItemTemplate>
                                    <FooterTemplate>
                                        <asp:DropDownList ID="ddlBranch_footer" runat="server" TabIndex="20" Width="60px">
                                        </asp:DropDownList>
                                    </FooterTemplate>
                                    <ItemTemplate>
                                        <%#Eval("Branch")%>
                                    </ItemTemplate>
                                </asp:TemplateField>--%>
                                <asp:TemplateField HeaderText="Agent Code">
                                    <EditItemTemplate>
                                        <asp:TextBox ID="txtAgentCode_edit" runat="server" Text='<%#Bind("AgentCode") %>'
                                            Width="80px" TabIndex="21"></asp:TextBox>
                                       <%-- <cc1:AutoCompleteExtender ID="AutoCompleteExtender2" runat="server" CompletionInterval="1"
                                            MinimumPrefixLength="1" ServiceMethod="GetCompletionHome_Agent" TargetControlID="txtAgentCode_edit">
                                        </cc1:AutoCompleteExtender>--%>
                                    </EditItemTemplate>
                                    <FooterTemplate>
                                        <asp:TextBox ID="txtAgentCode_footer" runat="server" TabIndex="21" Text='<%#Bind("AgentCode")  %>'
                                            Width="80px"></asp:TextBox>
                                       <%-- <cc1:AutoCompleteExtender ID="AutoCompleteExtender2" runat="server" CompletionInterval="1"
                                            MinimumPrefixLength="1" ServiceMethod="GetCompletionHome_Agent" TargetControlID="txtAgentCode_footer">
                                        </cc1:AutoCompleteExtender>--%>
                                    </FooterTemplate>
                                    <ItemTemplate>
                                        <%#Eval("AgentCode")%>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Private Marks">
                                    <EditItemTemplate>
                                        <asp:TextBox ID="txtRemarks_edit" runat="server" TabIndex="22" onkeypress="return alphanumeric_only(this);"
                                            Text='<%#Bind("PrivateMarks") %>' Width="80px"></asp:TextBox>
                                        <cc1:AutoCompleteExtender ID="AutoCompleteExtender12" runat="server" CompletionInterval="1"
                                            MinimumPrefixLength="1" ServiceMethod="GetCompletionHome_Customer" TargetControlID="txtRemarks_edit">
                                        </cc1:AutoCompleteExtender>
                                    </EditItemTemplate>
                                    <FooterTemplate>
                                        <asp:TextBox ID="txtRemarks_footer" runat="server" onkeypress="return alphanumeric_only(this);"
                                            TabIndex="22" Text='<%#Bind("PrivateMarks") %>' Width="80px"></asp:TextBox>
                                        <%--<cc1:AutoCompleteExtender ID="AutoCompleteExtender12" runat="server" CompletionInterval="1"
                                            MinimumPrefixLength="1" ServiceMethod="GetCompletionHome_Customer" TargetControlID="txtRemarks_footer">
                                        </cc1:AutoCompleteExtender>--%>
                                    </FooterTemplate>
                                    <ItemTemplate>
                                        <%#Eval("PrivateMarks")%>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Cust Name">
                                    <EditItemTemplate>
                                        <asp:TextBox ID="txtCustName_edit" runat="server" TabIndex="23" onkeypress="return alphanumeric_only(this);"
                                            Text='<%#Bind("CustName") %>' Width="80px" OnTextChanged="txtCustName_edit_TextChanged"
                                            AutoPostBack="true"></asp:TextBox>
                                        <cc1:AutoCompleteExtender ID="AutoCompleteExtenderCustName" runat="server" CompletionInterval="1"
                                            MinimumPrefixLength="1" ServiceMethod="GetCompletionHome_CustName" TargetControlID="txtCustName_edit">
                                        </cc1:AutoCompleteExtender>
                                    </EditItemTemplate>
                                    <FooterTemplate>
                                        <asp:TextBox ID="txtCustName_footer" runat="server" onkeypress="return alphanumeric_only(this);"
                                            TabIndex="23" Text='<%#Bind("CustName") %>' Width="80px" OnTextChanged="txtCustName_footer_TextChanged"
                                            AutoPostBack="true"></asp:TextBox>
                                        <cc1:AutoCompleteExtender ID="AutoCompleteExtenderCustName" runat="server" CompletionInterval="1"
                                            MinimumPrefixLength="1" ServiceMethod="GetCompletionHome_CustName" TargetControlID="txtCustName_footer">
                                        </cc1:AutoCompleteExtender>
                                    </FooterTemplate>
                                    <ItemTemplate>
                                        <%#Eval("CustName")%>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                   <asp:TemplateField HeaderText="Mobile" Visible="True">
                                    <EditItemTemplate>
                                        <asp:TextBox ID="Mob1_edit" runat="server" onkeypress="return alphanumeric_only(this);"
                                            TabIndex="24" Text='<%#Bind("Mob1") %>' Width="60px"></asp:TextBox>
                                    </EditItemTemplate>
                                    <FooterTemplate>
                                        <asp:TextBox ID="Mob1_footer" runat="server" onkeypress="return alphanumeric_only(this);"
                                            TabIndex="24" Text='<%#Bind("Mob1") %>' Width="60px"></asp:TextBox>
                                    </FooterTemplate>
                                    <ItemTemplate>
                                        <%#Eval("Mob1")%>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="No.of Packages">
                                    <EditItemTemplate>
                                        <asp:TextBox ID="txtPackages_edit" runat="server" onKeyPress="return isNumberKey(event);"
                                            TabIndex="14" Text='<%#Bind("NoofPackages") %>' Width="60px"></asp:TextBox>
                                    </EditItemTemplate>
                                    <FooterTemplate>
                                        <asp:TextBox ID="txtPackages_footer" runat="server" onKeyPress="return isNumberKey(event);"
                                            TabIndex="14" Text='<%#Bind("NoofPackages") %>' Width="60px"></asp:TextBox>
                                    </FooterTemplate>
                                    <ItemTemplate>
                                        <%#Eval("NoofPackages")%>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Loaded Packages">
                                    <EditItemTemplate>
                                        <asp:TextBox ID="txtLoadPackages_edit" runat="server" onKeyPress="return isNumberKey(event);"
                                            TabIndex="14" Text='<%#Bind("NoofPackages") %>' Width="60px"></asp:TextBox>
                                    </EditItemTemplate>
                                    <FooterTemplate>
                                        <asp:TextBox ID="txtLoadPackages_footer" runat="server" onKeyPress="return isNumberKey(event);"
                                            TabIndex="14" Text='<%#Bind("NoofPackages") %>' Width="60px"></asp:TextBox>
                                    </FooterTemplate>
                                    <ItemTemplate>
                                        <%#Eval("LoadedPackages")%>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Godown">
                                    <EditItemTemplate>
                                        <%--    <asp:TextBox ID ="txtGodown_edit" Width ="120px" runat ="server" Text ='<%#Bind("Godown") %>' onkeypress="return alphanumeric_only(this);"></asp:TextBox>--%>
                                        <asp:DropDownList ID="ddlGodown_edit" runat="server" OnSelectedIndexChanged="ddlGodown_edit_SelectedIndexChanged"
                                            TabIndex="16" Width="58px">
                                            <asp:ListItem>--Select--</asp:ListItem>
                                        </asp:DropDownList>
                                    </EditItemTemplate>
                                    <FooterTemplate>
                                        <asp:DropDownList ID="ddlGodown_footer" runat="server" OnSelectedIndexChanged="ddlGodown_footer_SelectedIndexChanged"
                                            TabIndex="16" Width="58px">
                                            <asp:ListItem>--Select--</asp:ListItem>
                                        </asp:DropDownList>
                                        <%--  <asp:TextBox ID="txtGodown_footer" Width ="120px" TabIndex="14" runat ="server" Text ='<%#Bind("Godown") %>' onkeypress="return alphanumeric_only(this);"></asp:TextBox>--%>
                                    </FooterTemplate>
                                    <ItemTemplate>
                                        <%#Eval("StoreID")%>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Accounts Name" Visible="false">
                                    <EditItemTemplate>
                                        <asp:TextBox ID="txtOriCustName_edit" runat="server" TabIndex="24" onkeypress="return alphanumeric_only(this);"
                                            Text='<%#Bind("OriCustName") %>' Width="80px" OnTextChanged="txtOriCustName_edit_TextChanged"
                                            AutoPostBack="true"></asp:TextBox>
                                        <cc1:AutoCompleteExtender ID="AutoCompleteExtenderAccName" runat="server" CompletionInterval="1"
                                            MinimumPrefixLength="1" ServiceMethod="GetCompletionHome_CustName" TargetControlID="txtOriCustName_edit">
                                        </cc1:AutoCompleteExtender>
                                    </EditItemTemplate>
                                    <FooterTemplate>
                                        <asp:TextBox ID="txtOriCustName_footer" runat="server" onkeypress="return alphanumeric_only(this);"
                                            TabIndex="24" Text='<%#Bind("OriCustName") %>' Width="80px" OnTextChanged="txtOriCustName_footer_TextChanged"
                                            AutoPostBack="true"></asp:TextBox>
                                        <cc1:AutoCompleteExtender ID="AutoCompleteExtenderAccName" runat="server" CompletionInterval="1"
                                            MinimumPrefixLength="1" ServiceMethod="GetCompletionHome_CustName" TargetControlID="txtOriCustName_footer">
                                        </cc1:AutoCompleteExtender>
                                    </FooterTemplate>
                                    <ItemTemplate>
                                        <%#Eval("OriCustName")%>
                                    </ItemTemplate>
                                </asp:TemplateField>
                             
                                <%--<asp:TemplateField HeaderText ="Total No.of Pakages">
                    <EditItemTemplate >
                        <asp:TextBox ID ="txtTotPackages_edit" Width ="120px" runat ="server" Text ='<%#Bind("TotalPakages") %>' onKeyPress="return isNumberKey(event)"></asp:TextBox>
                    </EditItemTemplate>
                    <FooterTemplate >
                        <asp:TextBox ID="txtTotPackages_footer" Width ="120px" TabIndex="15" runat ="server" Text ='<%#Bind("TotalPakages") %>' onKeyPress="return isNumberKey(event)"></asp:TextBox>
                    </FooterTemplate>
                    <ItemTemplate >
                        <%#Eval("TotalPakages")%>
                    </ItemTemplate>
                </asp:TemplateField> 
                 <asp:TemplateField HeaderText ="Total Weight">
                    <EditItemTemplate >
                        <asp:TextBox ID ="txtTotWeight_edit" Width ="120px" runat ="server" Text ='<%#Bind("TotalWeight") %>' onKeyPress="return isNumberKey(event)"></asp:TextBox>
                    </EditItemTemplate>
                    <FooterTemplate >
                        <asp:TextBox ID="txtTotWeight_footer" Width ="120px" TabIndex="15" runat ="server" Text ='<%#Bind("TotalWeight") %>' onKeyPress="return isNumberKey(event)"></asp:TextBox>
                    </FooterTemplate>
                    <ItemTemplate >
                        <%#Eval("TotalWeight")%>
                    </ItemTemplate>
                </asp:TemplateField>--%>
                                <asp:TemplateField HeaderText="Options">
                                    <EditItemTemplate>
                                        <asp:LinkButton ID="LinkButton1" runat="server" CommandName="Update" CssClass="buttonimage"
                                            TabIndex="26" Text="&lt;img src='App_Themes/Images/Update.gif' border='0' title='Update' /&gt;"
                                            Width="25%"></asp:LinkButton>
                                        <asp:LinkButton ID="LinkButton2" runat="server" CommandName="Cancel" CssClass="buttonimage"
                                            TabIndex="27" Text="&lt;img src='App_Themes/Images/Cancel.gif' border='0' title='Cancel' /&gt;"
                                            Width="25%"></asp:LinkButton>
                                    </EditItemTemplate>
                                    <FooterTemplate>
                                        <asp:LinkButton ID="LinkButton3" runat="server" CommandName="InsertNew" CssClass="buttonimage"
                                            TabIndex="25" Text="&lt;img src='App_Themes/Images/Insert1.gif' border='0' title='Insert' /&gt;"
                                            Width="25%"></asp:LinkButton>
                                        <asp:LinkButton ID="LinkButton4" runat="server" CommandName="CancelNew" CssClass="buttonimage"
                                            TabIndex="26" Text="&lt;img src='App_Themes/Images/Cancel.gif'border='0' title='Cancel'  /&gt;"
                                            Width="25%"></asp:LinkButton>
                                    </FooterTemplate>
                                    <ItemTemplate>
                                        <asp:LinkButton ID="LinkButton5" runat="server" CommandName="Edit" CssClass="buttonimage"
                                            Text="&lt;img src='App_Themes/Images/Edit.gif' border='0' title='Edit' /&gt;"
                                            Width="25%"></asp:LinkButton>
                                        <asp:LinkButton ID="LinkButton6" runat="server" CommandName="Delete" CssClass="buttonimage"
                                            OnClientClick="return ConfirmDelete();" Text="&lt;img src='App_Themes/Images/Del.gif' border='0' title='Delete' /&gt;"
                                            Width="25%"></asp:LinkButton>
                                    </ItemTemplate>
                                </asp:TemplateField>
                            </Columns>
                        </asp:GridView>
                    </div>
                </div>
                <div style="display: none; margin-top: 100px" id="DisplayCrysRep" runat="server">
                <div>
                <a href="LorryChallan.aspx">
                    <img src="App_Themes/Images/Back.png" style="width: 125px; height: 25px" /></a></div>
                    <CR:CrystalReportViewer ID="CRViewer" runat="server" AutoDataBind="true" PrintMode="ActiveX"
                        DisplayGroupTree="true" />
                </div>
            </div>
            <asp:HiddenField ID="hidMob" runat="server" />
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
