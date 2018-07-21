<%@ page language="C#" masterpagefile="~/AppMaster.master" autoeventwireup="true" inherits="RecievedLorryChallan, App_Web_utcvgpzk" title="Deepak Roadways" %>

<%@ Register Assembly="CrystalDecisions.Web, Version=10.5.3700.0, Culture=neutral, PublicKeyToken=692fbea5521e1304"
    Namespace="CrystalDecisions.Web" TagPrefix="CR" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="PageContent" runat="Server">
    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
    <cc1:ToolkitScriptManager ID="Too" runat="server">
    </cc1:ToolkitScriptManager>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <div id="Page">
                <br />
                <br />
                <br />
                <br />
                <br />
                <div>
                    <asp:Label ID="lblerrormsg" runat="server" ForeColor="Red" />
                </div>
                <div style="display: " id="Block_MainPage" runat="server">
                    <div class="gridcol_inside_page" style="margin-left: 2%">
                        <asp:GridView ID="GridRcView" runat="server" BorderStyle="None" CellPadding="3" CellSpacing="2"
                            AllowPaging="True" OnPageIndexChanging="GridRcView_PageIndexChanging" AutoGenerateColumns="False"
                            OnRowEditing="GridRcView_RowEditing" OnRowUpdating="GridRcView_RowUpdating" OnRowCancelingEdit="GridRcView_CancelingEdit"
                            PageSize="10">
                            <Columns>
                                <asp:TemplateField HeaderText="">
                                    <HeaderTemplate>
                                        <asp:Label ID="ChkHeader" runat="server" Text="option" />
                                    </HeaderTemplate>
                                    <ItemTemplate>
                                        <asp:RadioButton ID="chkSelect" runat="server" AutoPostBack="true" OnCheckedChanged="chkSelect_CheckedChanged">
                                        </asp:RadioButton>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="SI.No">
                                    <ItemTemplate>
                                        <%# Container.DataItemIndex + 1 %>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Challan No" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center">
                                    <ItemTemplate>
                                        <span style="width: 50px">
                                            <asp:Label runat="server" ID="lblID" Width="80px" Text='<%#Eval("ChallanNo")%>'></asp:Label></span>
                                    </ItemTemplate>
                                    <HeaderStyle HorizontalAlign="Center" Width="90px"></HeaderStyle>
                                    <ItemStyle HorizontalAlign="Center" Width="90px"></ItemStyle>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Truck No" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center">
                                    <ItemTemplate>
                                        <span style="width: 50px">
                                            <asp:Label runat="server" ID="lblName" Width="60px" Text='<%#Eval("TruckNo")%>'></asp:Label></span>
                                    </ItemTemplate>
                                    <HeaderStyle HorizontalAlign="Left" Width="50px"></HeaderStyle>
                                    <ItemStyle HorizontalAlign="Left" Width="50px"></ItemStyle>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Address" Visible="false">
                                    <ItemTemplate>
                                        <asp:Label runat="server" ID="lblSodate" Width="100px" Text='<%#Eval("Address")%>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Challan Date">
                                    <ItemTemplate>
                                        <asp:Label runat="server" ID="lblColour" Width="100px" Text='<%#Eval("ChallanDate")%>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Driver Name" Visible="false">
                                    <ItemTemplate>
                                        <asp:Label runat="server" ID="lblGSM" Width="80px" Text='<%#Eval("DriverName")%>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Start From">
                                    <ItemTemplate>
                                        <asp:Label runat="server" ID="lblCuttingSize" Width="70px" Text='<%#Eval("StartFrom")%>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Driver PhoneNo" Visible="false">
                                    <ItemTemplate>
                                        <asp:Label runat="server" ID="lblMeter" Width="100px" Text='<%#Eval("DriverPhoneNo")%>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="End To">
                                    <ItemTemplate>
                                        <asp:Label runat="server" ID="lblWeight" Width="70px" Text='<%#Eval("EndTo")%>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Truck Owner Name">
                                    <ItemTemplate>
                                        <asp:Label runat="server" ID="lblWidth" Width="110px" Text='<%#Eval("TruckownerName")%>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Broker Name">
                                    <ItemTemplate>
                                        <asp:Label runat="server" ID="lblRoll" Width="90px" Text='<%#Eval("AgentName")%>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Arrival Date">
                                    <EditItemTemplate>
                                        <asp:TextBox ID="lblPSRoll_Edit" runat="server" onkeypress="return alphanumeric_only(this);"
                                            TabIndex="24" Text='<%#Bind("ArrivalDate") %>' Width="100px"></asp:TextBox>
                                        <cc1:CalendarExtender ID="CalendarExtender2" runat="server" CssClass="cal_Theme"
                                            Format="dd/MM/yyyy" TargetControlID="lblPSRoll_Edit">
                                        </cc1:CalendarExtender>
                                    </EditItemTemplate>
                                    <ItemTemplate>
                                        <asp:Label runat="server" ID="lblPSRoll" Width="90px" Text='<%#Eval("ArrivalDate")%>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Options">
                                    <EditItemTemplate>
                                        <asp:LinkButton ID="LinkButton1" runat="server" CommandName="Update" CssClass="buttonimage"
                                            TabIndex="26" Text="&lt;img src='App_Themes/Images/Update.gif' border='0' title='Update' /&gt;"
                                            Width="25%"></asp:LinkButton>
                                        <asp:LinkButton ID="LinkButton2" runat="server" CommandName="Cancel" CssClass="buttonimage"
                                            TabIndex="27" Text="&lt;img src='App_Themes/Images/Cancel.gif' border='0' title='Cancel' /&gt;"
                                            Width="25%"></asp:LinkButton>
                                    </EditItemTemplate>
                                    <ItemTemplate>
                                        <asp:LinkButton ID="LinkButton2" runat="server" CommandName="Edit" CssClass="buttonimage"
                                            Text="&lt;img src='App_Themes/Images/Edit.gif' border='0' title='Edit' /&gt;"
                                            Width="25%"></asp:LinkButton>
                                    </ItemTemplate>
                                </asp:TemplateField>
                            </Columns>
                        </asp:GridView>
                    </div>
                </div>
                <div class="gridcol" id="divChallanItems"   runat="server" style="overflow: auto; width: 1200px; height: 900px; margin-left: 2%;">
                    <%-- <div class="gridcol_inside_page" style="margin-left: 2%">--%>
                    <asp:GridView ID="GridLorrychallan" runat="server" ShowFooter="true" AutoGenerateColumns="False"
                        OnRowEditing="GridLorrychallan_RowEditing" OnRowDataBound="GridLorrychallan_RowDataBound"
                        OnRowUpdating="GridLorrychallan_RowUpdating">
                        <Columns>
                            <asp:TemplateField HeaderText="Sl.No">
                                <ItemTemplate>
                                    <%# Container.DataItemIndex + 1 %>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField Visible="true">
                                <HeaderTemplate>
                                    <asp:CheckBox ID="ChkHeader" runat="server" />
                                </HeaderTemplate>
                                <FooterTemplate>
                                    <asp:Label ID="lblTotal" runat="server" Text="Total"></asp:Label>
                                </FooterTemplate>
                                <ItemTemplate>
                                    <asp:CheckBox ID="ChkItem" runat="server" Width="18px" />
                                </ItemTemplate>
                            </asp:TemplateField>
                            <%--<asp:TemplateField HeaderText="Select">
                                <ItemTemplate>
                                    <asp:CheckBox ID="ChkItem" runat="server" Width="20px" AutoPostBack="true" />
                                </ItemTemplate>
                            </asp:TemplateField>--%>
                            <asp:TemplateField HeaderText="Date">
                                <%-- <EditItemTemplate>
                                    <asp:TextBox ID="txtDate" runat="server" Text='<%#Bind("Date") %>' Width="88px"></asp:TextBox>
                                    <cc1:CalendarExtender ID="CalendarExtender3" runat="server" CssClass="cal_Theme"
                                        Format="dd/MM/yyyy" TargetControlID="txtDate">
                                    </cc1:CalendarExtender>
                                </EditItemTemplate>--%>
                                <%-- <FooterTemplate>
                                    <asp:TextBox ID="txtdate1" runat="server" Text='<%#Bind("Date") %>' Width="88px"></asp:TextBox>
                                    <cc1:CalendarExtender ID="CalendarExtender5" runat="server" CssClass="cal_Theme"
                                        Format="dd/MM/yyyy" TargetControlID="txtdate1">
                                    </cc1:CalendarExtender>
                                </FooterTemplate>--%>
                                <ItemTemplate>
                                    <asp:Label ID="lblDate" runat="server" Text='<%#Eval("Date")%>'>
                                    </asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="LR.NO">
                                <%--<EditItemTemplate>
                                    <asp:TextBox ID="txtLrno_edit" Text='<%#Bind("LRNo") %>' runat="server" Width="50px"></asp:TextBox>
                                </EditItemTemplate>--%>
                                <%-- <FooterTemplate>
                                    <asp:TextBox ID="txtlno1" Text='<%#Bind("LRNo") %>' runat="server" Width="50px"></asp:TextBox>
                                </FooterTemplate>--%>
                                <ItemTemplate>
                                    <asp:Label ID="lblLRNo" runat="server" Text='<%#Eval("LRNo")%>'>
                                    </asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="From" Visible="false">
                                <%--<EditItemTemplate>
                                    <asp:TextBox ID="txtLrno_edit" Text='<%#Bind("LRNo") %>' runat="server" Width="50px"></asp:TextBox>
                                </EditItemTemplate>--%>
                                <%-- <FooterTemplate>
                                    <asp:TextBox ID="txtlno1" Text='<%#Bind("LRNo") %>' runat="server" Width="50px"></asp:TextBox>
                                </FooterTemplate>--%>
                                <ItemTemplate>
                                    <asp:Label ID="lblFrom" runat="server" Text='<%#Eval("From")%>'>
                                    </asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="To" Visible="false">
                                <%--<EditItemTemplate>
                                    <asp:TextBox ID="txtLrno_edit" Text='<%#Bind("LRNo") %>' runat="server" Width="50px"></asp:TextBox>
                                </EditItemTemplate>--%>
                                <%-- <FooterTemplate>
                                    <asp:TextBox ID="txtlno1" Text='<%#Bind("LRNo") %>' runat="server" Width="50px"></asp:TextBox>
                                </FooterTemplate>--%>
                                <ItemTemplate>
                                    <asp:Label ID="lblTo" runat="server" Text='<%#Eval("To")%>'>
                                    </asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Consignor Name" Visible="false">
                                <%--<EditItemTemplate>
                                    <asp:TextBox ID="txtLrno_edit" Text='<%#Bind("LRNo") %>' runat="server" Width="50px"></asp:TextBox>
                                </EditItemTemplate>--%>
                                <%-- <FooterTemplate>
                                    <asp:TextBox ID="txtlno1" Text='<%#Bind("LRNo") %>' runat="server" Width="50px"></asp:TextBox>
                                </FooterTemplate>--%>
                                <ItemTemplate>
                                    <asp:Label ID="lblConsignorName" runat="server" Text='<%#Eval("ConsignorName")%>'>
                                    </asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Consignee Name" Visible="false">
                                <%--<EditItemTemplate>
                                    <asp:TextBox ID="txtLrno_edit" Text='<%#Bind("LRNo") %>' runat="server" Width="50px"></asp:TextBox>
                                </EditItemTemplate>--%>
                                <%-- <FooterTemplate>
                                    <asp:TextBox ID="txtlno1" Text='<%#Bind("LRNo") %>' runat="server" Width="50px"></asp:TextBox>
                                </FooterTemplate>--%>
                                <ItemTemplate>
                                    <asp:Label ID="lblConsigneeName" runat="server" Text='<%#Eval("ConsigneeName")%>'>
                                    </asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Contents">
                                <%-- <EditItemTemplate>
                                    <asp:TextBox ID="txtItems" runat="server" Text='<%#Bind("Items") %>' Width="60px"></asp:TextBox>
                                </EditItemTemplate>--%>
                                <%-- <FooterTemplate>
                                    <asp:TextBox ID="txtitems1" runat="server" Text='<%#Bind("Items") %>' Width="60px"></asp:TextBox>
                                </FooterTemplate>--%>
                                <ItemTemplate>
                                    <asp:Label ID="lblItems" runat="server" Text='<%#Eval("Contents")%>'>
                                    </asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Actual Weight" Visible="false">
                                <%-- <EditItemTemplate>
                                    <asp:TextBox ID="txtweight" runat="server" Text='<%#Bind("Weight") %>' Width="60px"></asp:TextBox>
                                </EditItemTemplate>--%>
                                <%-- <FooterTemplate>
                                    <asp:TextBox ID="txtweight1" runat="server" Text='<%#Bind("Weight") %>' Width="60px"></asp:TextBox>
                                </FooterTemplate>--%>
                                <ItemTemplate>
                                    <asp:Label ID="lblActualWeight" runat="server" Text='<%#Eval("ActualWeight")%>'>
                                    </asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Weight">
                                <%-- <EditItemTemplate>
                                    <asp:TextBox ID="txtweight" runat="server" Text='<%#Bind("Weight") %>' Width="60px"></asp:TextBox>
                                </EditItemTemplate>--%>
                                <FooterTemplate>
                                    <asp:Label ID="lblTotalWeight" runat="server" Text='<%#Eval("TotalWeight") %>'></asp:Label>
                                </FooterTemplate>
                                <ItemTemplate>
                                    <asp:Label ID="lblWeight" runat="server" Text='<%#Eval("ChargedWeight")%>'>
                                    </asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Private Marks" Visible="false">
                                <%-- <EditItemTemplate>
                                    <asp:TextBox ID="txtweight" runat="server" Text='<%#Bind("Weight") %>' Width="60px"></asp:TextBox>
                                </EditItemTemplate>--%>
                                <%-- <FooterTemplate>
                                    <asp:TextBox ID="txtweight1" runat="server" Text='<%#Bind("Weight") %>' Width="60px"></asp:TextBox>
                                </FooterTemplate>--%>
                                <ItemTemplate>
                                    <asp:Label ID="lblPrivateMarks" runat="server" Text='<%#Eval("PrivateMarks")%>'>
                                    </asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Packings">
                                <%-- <EditItemTemplate>
                                    <asp:TextBox ID="txtweight" runat="server" Text='<%#Bind("Weight") %>' Width="60px"></asp:TextBox>
                                </EditItemTemplate>--%>
                                <%-- <FooterTemplate>
                                    <asp:TextBox ID="txtweight1" runat="server" Text='<%#Bind("Weight") %>' Width="60px"></asp:TextBox>
                                </FooterTemplate>--%>
                                <ItemTemplate>
                                    <asp:Label ID="lblPackings" runat="server" Text='<%#Eval("Packings")%>'>
                                    </asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="PayType" Visible="false">
                                <%-- <EditItemTemplate>
                                    <asp:TextBox ID="txtweight" runat="server" Text='<%#Bind("Weight") %>' Width="60px"></asp:TextBox>
                                </EditItemTemplate>--%>
                                <%-- <FooterTemplate>
                                    <asp:TextBox ID="txtweight1" runat="server" Text='<%#Bind("Weight") %>' Width="60px"></asp:TextBox>
                                </FooterTemplate>--%>
                                <ItemTemplate>
                                    <asp:Label ID="lblPayType" runat="server" Text='<%#Eval("PayType")%>'>
                                    </asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Freight" Visible="false">
                                <%-- <EditItemTemplate>
                                    <asp:TextBox ID="txtweight" runat="server" Text='<%#Bind("Weight") %>' Width="60px"></asp:TextBox>
                                </EditItemTemplate>--%>
                                <%-- <FooterTemplate>
                                    <asp:TextBox ID="txtweight1" runat="server" Text='<%#Bind("Weight") %>' Width="60px"></asp:TextBox>
                                </FooterTemplate>--%>
                                <ItemTemplate>
                                    <asp:Label ID="lblFreight" runat="server" Text='<%#Eval("Freight")%>'>
                                    </asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="LabourCharge" Visible="false">
                                <%-- <EditItemTemplate>
                                    <asp:TextBox ID="txtweight" runat="server" Text='<%#Bind("Weight") %>' Width="60px"></asp:TextBox>
                                </EditItemTemplate>--%>
                                <%-- <FooterTemplate>
                                    <asp:TextBox ID="txtweight1" runat="server" Text='<%#Bind("Weight") %>' Width="60px"></asp:TextBox>
                                </FooterTemplate>--%>
                                <ItemTemplate>
                                    <asp:Label ID="lblLabourCharge" runat="server" Text='<%#Eval("LabourCharge")%>'>
                                    </asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="DeliveryCharge" Visible="false">
                                <%-- <EditItemTemplate>
                                    <asp:TextBox ID="txtweight" runat="server" Text='<%#Bind("Weight") %>' Width="60px"></asp:TextBox>
                                </EditItemTemplate>--%>
                                <%-- <FooterTemplate>
                                    <asp:TextBox ID="txtweight1" runat="server" Text='<%#Bind("Weight") %>' Width="60px"></asp:TextBox>
                                </FooterTemplate>--%>
                                <ItemTemplate>
                                    <asp:Label ID="lblDeliveryCharge" runat="server" Text='<%#Eval("DeliveryCharge")%>'>
                                    </asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="StatisticalCharge" Visible="false">
                                <%-- <EditItemTemplate>
                                    <asp:TextBox ID="txtweight" runat="server" Text='<%#Bind("Weight") %>' Width="60px"></asp:TextBox>
                                </EditItemTemplate>--%>
                                <%-- <FooterTemplate>
                                    <asp:TextBox ID="txtweight1" runat="server" Text='<%#Bind("Weight") %>' Width="60px"></asp:TextBox>
                                </FooterTemplate>--%>
                                <ItemTemplate>
                                    <asp:Label ID="lblStatisticalCharge" runat="server" Text='<%#Eval("StatisticalCharge")%>'>
                                    </asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="CartageCharge" Visible="false">
                                <%-- <EditItemTemplate>
                                    <asp:TextBox ID="txtweight" runat="server" Text='<%#Bind("Weight") %>' Width="60px"></asp:TextBox>
                                </EditItemTemplate>--%>
                                <%-- <FooterTemplate>
                                    <asp:TextBox ID="txtweight1" runat="server" Text='<%#Bind("Weight") %>' Width="60px"></asp:TextBox>
                                </FooterTemplate>--%>
                                <ItemTemplate>
                                    <asp:Label ID="lblCartageCharge" runat="server" Text='<%#Eval("CartageCharge")%>'>
                                    </asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="ServiceTax" Visible="false">
                                <%-- <EditItemTemplate>
                                    <asp:TextBox ID="txtweight" runat="server" Text='<%#Bind("Weight") %>' Width="60px"></asp:TextBox>
                                </EditItemTemplate>--%>
                                <%-- <FooterTemplate>
                                    <asp:TextBox ID="txtweight1" runat="server" Text='<%#Bind("Weight") %>' Width="60px"></asp:TextBox>
                                </FooterTemplate>--%>
                                <ItemTemplate>
                                    <asp:Label ID="lblServiceTax" runat="server" Text='<%#Eval("ServiceTax")%>'>
                                    </asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="To Pay">
                                <%-- <EditItemTemplate>
                                    <asp:TextBox ID="txttopay" runat="server" Text='<%#Bind("ToPay") %>' Width="60px"></asp:TextBox>
                                </EditItemTemplate>--%>
                                <FooterTemplate>
                                    <asp:Label ID="lblTotalToPay" runat="server" Text='<%#Eval("TotalToPay") %>'></asp:Label>
                                </FooterTemplate>
                                <ItemTemplate>
                                    <asp:Label ID="lblToPay" Width="80px" runat="server" Text='<%#Eval("ToPay")%>'>
                                    </asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Paid">
                                <%--<EditItemTemplate>
                                    <asp:TextBox ID="txtpaid" runat="server" Text='<%#Bind("Paid") %>' Width="50px"></asp:TextBox>
                                </EditItemTemplate>--%>
                                <FooterTemplate>
                                    <asp:Label ID="lblTotalPaid" runat="server" Text='<%#Eval("TotalPaid") %>'></asp:Label>
                                </FooterTemplate>
                                <ItemTemplate>
                                    <asp:Label ID="lblPaid" runat="server" Text='<%#Eval("Paid")%>'>
                                    </asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Agent Name">
                                <%--<EditItemTemplate>
                                    <asp:TextBox ID="txtagentname" Text='<%#Bind("AgentName") %>' runat="server" Width="70px"></asp:TextBox>
                                </EditItemTemplate>--%>
                                <%--<FooterTemplate>
                                    <asp:TextBox ID="txtagentname1" Text='<%#Bind("AgentName") %>' runat="server" Width="70px"></asp:TextBox>
                                </FooterTemplate>--%>
                                <ItemTemplate>
                                    <asp:Label ID="lblAgentName" runat="server" Width="90px" Text='<%#Eval("AgentName")%>'>
                                    </asp:Label>
                                     <asp:Label ID="lblAgentID" runat="server" Visible="false" Width="90px" Text='<%#Eval("AgentID")%>'>
                                    </asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Customer Name">
                                <%-- <EditItemTemplate>
                                    <asp:TextBox ID="txtcustname_e" runat="server" Text='<%#Bind("CustName") %>' Width="80px"></asp:TextBox>
                                </EditItemTemplate>
                                <FooterTemplate>
                                    <asp:TextBox ID="txtcusname1" runat="server" Text='<%#Bind("CustName") %>' Width="80px"></asp:TextBox>
                                </FooterTemplate>--%>
                                <ItemTemplate>
                                    <asp:Label ID="lblCustName" runat="server" Text='<%#Eval("CustomerName")%>'>
                                    </asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Account Name" Visible="false">
                                <%--<EditItemTemplate>
                                    <asp:TextBox ID="txtaccname_e" Text='<%#Bind("AccountName") %>' runat="server" Width="80px"></asp:TextBox>
                                </EditItemTemplate>
                                <FooterTemplate>
                                    <asp:TextBox ID="txtaccname" Text='<%#Bind("AccountName") %>' runat="server" Width="80px"></asp:TextBox>
                                </FooterTemplate>--%>
                                <ItemTemplate>
                                    <asp:TextBox ID="txtAccountName" Width="100px" runat="server" Text='<%#Eval("AccountName")%>'>
                                    </asp:TextBox>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Mobile Number">
                                <%-- <EditItemTemplate>
                                    <asp:TextBox ID="txtmob_e" Text='<%#Bind("MobileNumber") %>' runat="server" Width="80px"></asp:TextBox>
                                </EditItemTemplate>
                                <FooterTemplate>
                                    <asp:TextBox ID="txtmob1" Text='<%#Bind("MobileNumber") %>' runat="server" Width="80px"></asp:TextBox>
                                </FooterTemplate>--%>
                                <ItemTemplate>
                                    <asp:Label ID="lblMobileNumber" runat="server" Text='<%#Eval("MobileNumber")%>'>
                                    </asp:Label>
                                    <%--<asp:TextBox ID="txtMobileNumber" onkeypress="return isNumberKey(event);" MaxLength="12" runat="server" Width="100px" Text='<%#Eval("MobileNumber")%>'>
                                    </asp:TextBox>--%>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="No.of Packages" HeaderStyle-Width="70px">
                                <%--<EditItemTemplate>
                                    <asp:TextBox ID="txtPackages_edit" runat="server" Text='<%#Bind("NoofPackages") %>'
                                        Width="60px"></asp:TextBox>
                                </EditItemTemplate>--%>
                                <FooterTemplate>
                                    <asp:Label ID="lblTotalPackages" runat="server" Text='<%#Eval("TotalPackages") %>'></asp:Label>
                                </FooterTemplate>
                                <ItemTemplate>
                                    <asp:Label ID="lblNoofPackages" runat="server" Text='<%#Eval("NoOfPackages")%>'>
                                    </asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Loaded Packages" Visible="false" HeaderStyle-Width="70px">
                                <%--<EditItemTemplate>
                                    <asp:TextBox ID="txtPackages_edit" runat="server" Text='<%#Bind("NoofPackages") %>'
                                        Width="60px"></asp:TextBox>
                                </EditItemTemplate>--%>
                                <%-- <FooterTemplate>
                                    <asp:TextBox ID="txtpack1" runat="server" Text='<%#Bind("NoofPackages") %>' Width="60px"></asp:TextBox>
                                </FooterTemplate>--%>
                                <ItemTemplate>
                                    <asp:Label ID="lblLoadedPackages" runat="server" Text='<%#Eval("LoadedPackages")%>'>
                                    </asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Received Packages" Visible="false" HeaderStyle-Width="80px">
                                <%--<EditItemTemplate>
                                    <asp:TextBox ID="txtPackages_edit" runat="server" Text='<%#Bind("NoofPackages") %>'
                                        Width="60px"></asp:TextBox>
                                </EditItemTemplate>--%>
                                <%-- <FooterTemplate>
                                    <asp:TextBox ID="txtpack1" runat="server" Text='<%#Bind("NoofPackages") %>' Width="60px"></asp:TextBox>
                                </FooterTemplate>--%>
                                <ItemTemplate>
                                    <asp:TextBox ID="txtReceivedPackages" runat="server" Width="70px" Text='<%#Eval("ReceivedPackages")%>'>
                                    </asp:TextBox>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Short Packages" Visible="false" HeaderStyle-Width="180px">
                                <%--<EditItemTemplate>
                                    <asp:TextBox ID="txtPackages_edit" runat="server" Text='<%#Bind("NoofPackages") %>'
                                        Width="60px"></asp:TextBox>
                                </EditItemTemplate>--%>
                                <%-- <FooterTemplate>
                                    <asp:TextBox ID="txtpack1" runat="server" Text='<%#Bind("NoofPackages") %>' Width="60px"></asp:TextBox>
                                </FooterTemplate>--%>
                                <ItemTemplate>
                                    <asp:TextBox ID="txtShortPackages" runat="server" Width="100px" Text='<%#Eval("ShortPackages")%>'>
                                    </asp:TextBox>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Godown">
                                <%-- <EditItemTemplate>
                                    <asp:DropDownList ID="ddlGodown_edit" runat="server" TabIndex="16" Width="58px">
                                        <asp:ListItem>--Select--</asp:ListItem>
                                    </asp:DropDownList>
                                </EditItemTemplate>--%>
                                <%-- <FooterTemplate>
                                    <asp:DropDownList ID="ddlGodown_footer" Width="58px" runat="server">
                                        <asp:ListItem>--Select--</asp:ListItem>
                                    </asp:DropDownList>
                                </FooterTemplate>--%>
                                <ItemTemplate>
                                    <%-- <asp:Label ID="lblGodown" runat="server">
                                    </asp:Label>--%>
                                    <asp:DropDownList ID="ddlGodown_Item" Width="100px" runat="server" OnSelectedIndexChanged="ddlGodown_Item_SelectedIndexChanged"
                                        AutoPostBack="true">
                                        <asp:ListItem>--Select--</asp:ListItem>
                                    </asp:DropDownList>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <%--<asp:TemplateField HeaderText="Options">
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
                            </asp:TemplateField>--%>
                        </Columns>
                    </asp:GridView>
                </div>
                <%--</div>--%>
                <div class="ButtonsWrapper two-col-button" style="margin-left: 12%">
                    <div class="btn_spaces">
                        <asp:Button ID="btnSave" runat="server" Text="Save" CssClass="btnstyle" TabIndex="26"
                            OnClick="btnSave_Click"></asp:Button>
                        <asp:Button ID="btView" runat="server" Text="View" CssClass="btnstyle" TabIndex="27"
                            OnClick="btView_Click"></asp:Button>
                        <asp:Button ID="btnClear" runat="server" Text="Clear" CssClass="btnstyle" TabIndex="28"
                            OnClick="btnClear_Click"></asp:Button>
                        <%--<asp:Button ID="btnDelete" runat="server" Text="Delete" CssClass="btnstyle" TabIndex="29">
                        </asp:Button>--%>
                    </div>
                </div>
                <asp:HiddenField ID="Hid" runat="server" />
                <div style="display: none" id="Show_View_Challan" runat="server">
                    <div class="single-col" style="margin-top: 2%">
                        <%--   <div class="ControlsWrapper1">
                            <div>
                                <asp:Label ID="lblFromDate" runat="server" Text="From Date"></asp:Label>
                                <asp:TextBox ID="txtFromDate" runat="server" Width="100"></asp:TextBox>
                                <cc1:CalendarExtender ID="calFromDate" runat="server" Format="dd/MM/yyyy" TargetControlID="txtFromDate"
                                    CssClass="cal_Theme">
                                </cc1:CalendarExtender>
                            </div>
                        </div>
                        <div class="ControlsWrapper1">
                            <div>
                                <asp:Label ID="lblToDate" runat="server" Text="ToDate"></asp:Label>
                                <asp:TextBox ID="txtToDate" runat="server" Width="100" AutoPostBack="True" OnTextChanged="txtToDate_TextChanged"></asp:TextBox>
                                <cc1:CalendarExtender ID="calToDate" runat="server" TargetControlID="txtToDate"  Format="dd/MM/yyyy" CssClass="cal_Theme">
                                </cc1:CalendarExtender>
                            </div>
                        </div>
                        <div class="ControlsWrapper1">
                            <div>
                                <asp:Label ID="lblGodownno" runat="server" Text="GodownNo"></asp:Label>
                                <asp:DropDownList ID="ddlGodownno_View" Width="150" runat="server" AutoPostBack="True"
                                    OnSelectedIndexChanged="ddlGodownno_View_SelectedIndexChanged">
                                    <asp:ListItem>--Select--</asp:ListItem>
                                </asp:DropDownList>
                            </div>
                        </div>--%>
                        <div class="ControlsWrapper1">
                            <div>
                                <asp:Label ID="lblChallanNoview" runat="server" Text="Challan No"></asp:Label>
                                <asp:TextBox ID="txtChallanNoview" runat="server" Width="100" AutoPostBack="True"
                                    OnTextChanged="txtChallanNoview_TextChanged"></asp:TextBox>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
