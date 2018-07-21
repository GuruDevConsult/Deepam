<%@ page language="C#" masterpagefile="~/AppMaster.master" autoeventwireup="true" inherits="DeliveryCredit, App_Web_zwikzsdt" title="Deepak Roadways" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="PageContent" runat="Server">
    <cc1:ToolkitScriptManager ID="Too" runat="server">
    </cc1:ToolkitScriptManager>
    <div id="Page">
        <div class="three-col-new">
        <cc1:AutoCompleteExtender ID="AutoHome" runat="server" MinimumPrefixLength="1" ServiceMethod="GetCategoryName"
                TargetControlID="CustomerName" CompletionInterval="1">
            </cc1:AutoCompleteExtender>
            <div class="ControlsWrapper1">
                <div>
                    <asp:Label ID="lblDCreditDate" runat="server" Text="Delivery Credit Date"></asp:Label>
                    <asp:TextBox ID="DCreditDate" TabIndex="1" onkeypress="return isNumberKey(event);"
                        MaxLength="10" runat="server" ></asp:TextBox>
                    <cc1:CalendarExtender ID="CalendarExtender1" Format="dd/MM/yyyy" runat="server" TargetControlID="DCreditDate"
                        CssClass="cal_Theme">
                    </cc1:CalendarExtender>
                </div>
                <div>
                    <asp:Label ID="lblCustomerName" runat="server" Text="Customer Name"></asp:Label>
                    <asp:TextBox ID="CustomerName" TabIndex="2" onkeypress="isValidAlpha(event)" MaxLength="25"
                        runat="server" AutoPostBack="True" 
                        ontextchanged="CustomerName_TextChanged"></asp:TextBox>
                </div>
                <div>
                    <asp:Label ID="lblMRNo" runat="server" Text="MRNo"></asp:Label>
                    <asp:DropDownList ID="MRNo" runat="server" TabIndex="3">
                        <asp:ListItem Value="0">--SELECT--</asp:ListItem>
                    </asp:DropDownList>
                </div>
                <div>
                    <asp:Label ID="lblAmount" runat="server" Text="Amount"></asp:Label>
                    <asp:TextBox ID="Amount" onkeypress="return isNumberKey(event);" TabIndex="4" MaxLength="10" runat="server"></asp:TextBox>
                </div>
            </div>
        </div>
        <div class="ButtonsWrapper three-col-button">
            <div class="btn_spaces">
                <asp:Button ID="btnSave" runat="server" Text="Save" CssClass="btnstyle" 
                    TabIndex="5" onclick="btnSave_Click"></asp:Button>
                <asp:Button ID="btnClear" runat="server" Text="Clear"  TabIndex="6" CssClass="btnstyle" 
                    onclick="btnClear_Click">
                </asp:Button>
                <%--<asp:Button ID="btnDelete" runat="server" Text="Delete" CssClass="btnstyle" OnClick="btnDelete_Click"
                    OnClientClick="return ConfirmDelete();"></asp:Button>--%>
            </div>
        </div>
    </div>
</asp:Content>
