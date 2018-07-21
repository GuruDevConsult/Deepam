<%@ page language="C#" masterpagefile="~/AppMaster.master" autoeventwireup="true" inherits="AddressBook, App_Web_utcvgpzk" title="Deepak Roadways" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="PageContent" runat="Server">

    <script type="text/javascript" language="javascript">
  function Email_Validation1(txt) 
{
        var reg = /^([A-Za-z0-9_\-\.])+\@([A-Za-z0-9_\-\.])+\.([A-Za-z]{2,4})$/;
        var email = txt.value;

//        if (!email || 0 == email.length)
//         {
//            alert('please enter email');          
//        }
      if (reg.test(email) == false) 
      {
        
            alert('Invalid Email Id');
            return false;
          
          
        }
        else {

            return true;
        }
    }
    </script>

    <cc1:ToolkitScriptManager ID="Too" runat="server">
    </cc1:ToolkitScriptManager>
    <%--<asp:ScriptManager id="ScriptManager1" runat="server"></asp:ScriptManager>--%>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <div id="Page">
                <div class="two-col">
                    <asp:Label ID="lblMsg" Text="" runat="server" Style="color: red"></asp:Label>
                    
                    <cc1:AutoCompleteExtender ID="AutoOriCustName" runat="server" MinimumPrefixLength="1"
                        ServiceMethod="GetOriCustName" TargetControlID="OriCustName" CompletionInterval="1">
                    </cc1:AutoCompleteExtender>
                    <div class="ControlsWrapper">
                        <div>
                            <asp:Label ID="lblCategory" runat="server" Text="Category"></asp:Label>
                            <asp:DropDownList runat="server" ID="Category" AutoPostBack="True" OnSelectedIndexChanged="Category_SelectedIndexChanged"
                                TabIndex="1">
                                <asp:ListItem Value="0">--SELECT--</asp:ListItem>
                                <asp:ListItem Value="1">CUSTOMER</asp:ListItem>
                                <asp:ListItem Value="2">AGENT</asp:ListItem>
                                <asp:ListItem Value="3">TRANSPORT</asp:ListItem>
                                <asp:ListItem Value="4">CASHBOOK</asp:ListItem>
                            </asp:DropDownList>
                        </div>
                        <div>
                            <asp:Label ID="lblName" runat="server" Text="Name"></asp:Label>
                            <asp:TextBox ID="Name" TabIndex="2" MaxLength="20" runat="server" AutoPostBack="True"
                                OnTextChanged="Name_TextChanged"></asp:TextBox>
                                <cc1:AutoCompleteExtender ID="AutoHome" runat="server" MinimumPrefixLength="1" ServiceMethod="GetCategoryName"
                        TargetControlID="Name" CompletionInterval="1">
                    </cc1:AutoCompleteExtender>
                        </div>
                        <div>
                            <asp:Label ID="lblSurName" runat="server" Text="SurName"></asp:Label>
                            <asp:TextBox ID="SurName" TabIndex="3" MaxLength="20" runat="server"></asp:TextBox>
                        </div>
                        <div>
                            <asp:Label ID="lblOriCustName" runat="server" Text="Accounts Name"></asp:Label>
                            <asp:TextBox ID="OriCustName" TabIndex="4" MaxLength="20" runat="server" OnTextChanged="OriCustName_TextChanged"
                                AutoPostBack="true"></asp:TextBox>
                        </div>
                        <div>
                            <asp:Label ID="lblGroupName" runat="server" Text="GroupName"></asp:Label>
                            <asp:DropDownList ID="GroupName" runat="server" TabIndex="5">
                            </asp:DropDownList>
                        </div>
                        <div>
                            <asp:Label ID="lblAgentCode" runat="server" Text="Agent Code"></asp:Label>
                            <asp:TextBox ID="AgentCode" TabIndex="6" MaxLength="12" runat="server" AutoPostBack="True"
                                OnTextChanged="AgentCode_TextChanged"></asp:TextBox>
                        </div>
                        <div>
                            <asp:Label ID="lblAddress" runat="server" Text="Address"></asp:Label>
                            <asp:TextBox ID="Address" TabIndex="7" runat="server" TextMode="MultiLine"></asp:TextBox>
                        </div>
                        <div>
                            <asp:Label ID="lblCity" runat="server" Text="City"></asp:Label>
                            <asp:TextBox ID="City" TabIndex="8" onkeypress="isValidAlpha(this)" runat="server"></asp:TextBox>
                        </div>
                        <div>
                            <asp:Label ID="lblPinCode" runat="server" Text="PinCode"></asp:Label>
                            <asp:TextBox ID="PinCode" TabIndex="9" onkeypress="return isNumberKey(event);" MaxLength="6"
                                runat="server"></asp:TextBox>
                        </div>
                        <div>
                            <asp:Label ID="lblPrimaryPhone" runat="server" Text="PrimaryPhone"></asp:Label>
                            <asp:TextBox ID="PrimaryPhone" TabIndex="10" onkeypress="return isNumberKey(event)"
                                MaxLength="12" runat="server"></asp:TextBox>
                        </div>
                        <div>
                            <asp:Label ID="lblSecondaryPhone" runat="server" Text="SecondaryPhone"></asp:Label>
                            <asp:TextBox ID="SecondaryPhone" TabIndex="11" onkeypress="return isNumberKey(event)"
                                MaxLength="12" runat="server"></asp:TextBox>
                        </div>
                        <div>
                            <asp:Label ID="lblMob" runat="server" Text="Mobile1"></asp:Label>
                            <asp:TextBox ID="Mobile1" TabIndex="12" onkeypress="return isNumberKey(event)" MaxLength="12"
                                runat="server"></asp:TextBox>
                        </div>
                        <div>
                            <asp:Label ID="lblMobile2" runat="server" Text="Mobile2"></asp:Label>
                            <asp:TextBox ID="Mobile2" TabIndex="13" onkeypress="return isNumberKey(event)" MaxLength="12"
                                runat="server"></asp:TextBox>
                        </div>
                        <div>
                            <asp:Label ID="lblPrimaryEmail" runat="server" Text="PrimaryEmail"></asp:Label>
                            <asp:TextBox ID="PrimaryEmail" TabIndex="14" runat="server" onchange="return Email_Validation1(this);"></asp:TextBox>
                        </div>
                    </div>
                    <div class="ControlsWrapper">
                        <div>
                            <asp:Label ID="lblSecondaryEmail" runat="server" Text="SecondaryEmail"></asp:Label>
                            <asp:TextBox ID="SecondaryEmail" TabIndex="15" runat="server" onchange="return Email_Validation1(this);"></asp:TextBox>
                        </div>
                        <div>
                            <asp:Label ID="lblWebsite" runat="server" Text="Website"></asp:Label>
                            <asp:TextBox ID="Website" TabIndex="16" runat="server"></asp:TextBox>
                        </div>
                        <div>
                            <asp:Label ID="lblFax" runat="server" Text="Fax"></asp:Label>
                            <asp:TextBox ID="Fax" TabIndex="17" onkeypress="return isNumberKey(event)" MaxLength="12"
                                runat="server"></asp:TextBox>
                        </div>
                        <div>
                            <asp:Label ID="lblTINNo" runat="server" Text="TIN No"></asp:Label>
                            <asp:TextBox ID="TINNo" TabIndex="18" onkeypress="return isNumberKey(event)" MaxLength="15"
                                runat="server"></asp:TextBox>
                        </div>
                        <div>
                            <asp:Label ID="lblCSTNo" runat="server" Text="CST No"></asp:Label>
                            <asp:TextBox ID="CSTNo" TabIndex="19" onkeypress="return isNumberKey(event)" MaxLength="10"
                                runat="server"></asp:TextBox>
                        </div>
                        <div>
                            <asp:Label ID="lblAreaCode" runat="server" Text="AreaCode"></asp:Label>
                            <asp:TextBox ID="AreaCode" TabIndex="20" onkeypress="return isNumberKey(event)" MaxLength="10"
                                runat="server"></asp:TextBox>
                        </div>
                        <%--<div>
                            <asp:Label ID="lblFreight" runat="server" Text="Freight"></asp:Label>
                            <asp:TextBox ID="Freight" TabIndex="13" runat="server" onkeypress="return isNumberKey(event);"></asp:TextBox>
                        </div>--%>
                        <div>
                            <asp:Label ID="lblLabour" runat="server" Text="Labour"></asp:Label>
                            <asp:TextBox ID="Labour" TabIndex="21" runat="server" onkeypress="return isNumberKey(event);"></asp:TextBox>
                        </div>
                        <div>
                            <asp:Label ID="lblDeliveryCh" runat="server" Text="DeliveryCh"></asp:Label>
                            <asp:TextBox ID="DeliveryCh" TabIndex="22" runat="server" onkeypress="return isNumberKey(event);"></asp:TextBox>
                        </div>
                        <div>
                            <asp:Label ID="lblStationaryCh" runat="server" Text="StationaryCh"></asp:Label>
                            <asp:TextBox ID="StationaryCh" TabIndex="23" runat="server" onkeypress="return isNumberKey(event);"></asp:TextBox>
                        </div>
                        <div>
                            <asp:Label ID="lblDemurrage" runat="server" Text="Demurrage"></asp:Label>
                            <asp:TextBox ID="Demurrage" TabIndex="24" runat="server" onkeypress="return isNumberKey(event);"></asp:TextBox>
                        </div>
                        <div>
                            <asp:Label ID="lblLocalCartage" runat="server" Text="LocalCartage"></asp:Label>
                            <asp:TextBox ID="LocalCartage" TabIndex="25" runat="server" onkeypress="return isNumberKey(event);"></asp:TextBox>
                        </div>
                        <div>
                            <asp:Label ID="lblServiceTax" runat="server" Text="Service Tax"></asp:Label>
                            <asp:TextBox ID="ServiceTax" TabIndex="26" runat="server" onkeypress="return isNumberKey(event);"></asp:TextBox>
                        </div>
                    </div>
                    <div class="ControlsWrapper">
                        <div>
                            <asp:Label runat="server" ID="lblResult" ForeColor="#FF3300"></asp:Label>
                        </div>
                    </div>
                    <div class="gridcol">
                        <asp:GridView ID="GridFreight" runat="server" AutoGenerateColumns="False" OnRowCancelingEdit="GridFreight_RowCancelingEdit"
                            OnRowCommand="GridFreight_RowCommand" OnRowDeleting="GridFreight_RowDeleting"
                            OnRowEditing="GridFreight_RowEditing" OnRowUpdating="GridFreight_RowUpdating"
                            ShowFooter="True">
                            <Columns>
                                <asp:TemplateField HeaderText="Sl.No">
                                    <ItemTemplate>
                                        <%#Container.DataItemIndex + 1 %>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Freight ID" Visible="false">
                                    <ItemTemplate>
                                        <asp:Label ID="txtLorryChallanID" runat="server" Text='<%#Eval("FreightID")%>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                              <%--  <asp:TemplateField HeaderText="Packings">
                                    <EditItemTemplate>
                                        <asp:DropDownList ID="ddlPackings" runat="server" TabIndex="27" Width="100px">
                                            <asp:ListItem Value="0">--Select--</asp:ListItem>
                                            <asp:ListItem Value="1">BUNDLE</asp:ListItem>
                                            <asp:ListItem Value="2">CASE</asp:ListItem>
                                            <asp:ListItem Value="3">CARTOON</asp:ListItem>
                                            <asp:ListItem Value="4">BAGS</asp:ListItem>
                                            <asp:ListItem Value="5">CABLE DRUM</asp:ListItem>
                                        </asp:DropDownList>
                                    </EditItemTemplate>
                                    <FooterTemplate>
                                        <asp:DropDownList ID="ddlPackings1" runat="server" TabIndex="27" Width="100px">
                                            <asp:ListItem Value="0">--Select--</asp:ListItem>
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
                                </asp:TemplateField>--%>
                                  <asp:TemplateField HeaderText="Packings">
                                    <EditItemTemplate>
                                        <asp:TextBox ID="txtPacking" Width="120px" runat="server" Text='<%#Bind("Packings") %>'
                                            TabIndex="28"></asp:TextBox>
                                    </EditItemTemplate>
                                    <FooterTemplate>
                                        <asp:TextBox ID="txtPackingF" Width="120px" runat="server" Text='<%#Bind("Packings") %>'
                                            TabIndex="28"></asp:TextBox>
                                    </FooterTemplate>
                                    <ItemTemplate>
                                        <%#Eval("Packings")%>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Rate" AccessibleHeaderText="0">
                                    <EditItemTemplate>
                                        <asp:TextBox ID="txtWeight" Width="120px" runat="server" Text='<%#Bind("Weight") %>'
                                            TabIndex="28" onkeypress="return isNumberKey(event);"></asp:TextBox>
                                    </EditItemTemplate>
                                    <FooterTemplate>
                                        <asp:TextBox ID="txtWeight1" Width="120px" runat="server" Text='<%#Bind("Weight") %>'
                                            TabIndex="28" onkeypress="return isNumberKey(event);"></asp:TextBox>
                                    </FooterTemplate>
                                    <ItemTemplate>
                                        <%#Eval("Weight")%>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Fixed">
                                    <EditItemTemplate>
                                        <asp:TextBox ID="txtFixed" runat="server" Text='<%#Bind("Fixed") %>' TabIndex="29"
                                            Width="88%" onkeypress="return isNumberKey(event);"></asp:TextBox>
                                    </EditItemTemplate>
                                    <FooterTemplate>
                                        <asp:TextBox ID="txtFixed1" runat="server" Text='<%#Bind("Fixed") %>' TabIndex="29"
                                            Width="88%" onkeypress="return isNumberKey(event);"></asp:TextBox>
                                    </FooterTemplate>
                                    <ItemTemplate>
                                        <%#Eval("Fixed")%>
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
                                            TabIndex="30" CssClass="buttonimage" Width="25%"></asp:LinkButton>
                                        <asp:LinkButton ID="LinkButton4" runat="server" CommandName="CancelNew" Text="<img src='App_Themes/Images/Cancel.gif'border='0' title='Cancel'  />"
                                            TabIndex="31" CssClass="buttonimage" Width="25%"></asp:LinkButton>
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
                </div>
                <div class="ButtonsWrapper two-col-button">
                    <div class="btn_spaces">
                        <asp:Button ID="btnSave" OnClick="btnSave_Click" runat="server" Text="Save" CssClass="btnstyle"
                            TabIndex="32"></asp:Button>
                        <asp:Button ID="btnClear" OnClick="btnClear_Click" runat="server" Text="Clear" CssClass="btnstyle">
                        </asp:Button>
                        <asp:Button ID="btnView" runat="server" Text="View" CssClass="btnstyle" OnClick="btnView_Click">
                        </asp:Button>
                        <asp:Button ID="btnDelete" OnClick="btnDelete_Click" runat="server" Text="Delete"
                            CssClass="btnstyle"></asp:Button>
                    </div>
                </div>
                <asp:HiddenField ID="hidCon" runat="server"></asp:HiddenField>
                <asp:HiddenField ID="hidCharges" runat="server"></asp:HiddenField>
                <asp:HiddenField ID="hidAdd" runat="server"></asp:HiddenField>
                <asp:HiddenField ID="hidAccID" runat="server"></asp:HiddenField>
                <div class="gridcol">
                <asp:GridView ID="gridView_Type" runat="server" CellPadding="4" ForeColor="#333333"
                    GridLines="None">
                </asp:GridView>
            </div>
            </div>
            
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
