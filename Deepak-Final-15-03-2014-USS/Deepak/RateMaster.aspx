<%@ page language="C#" masterpagefile="~/AppMaster.master" autoeventwireup="true" inherits="RateMaster, App_Web_zwikzsdt" title="Untitled Page" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MetaPlaceHolder" runat="Server">

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="PageContent" runat="Server">
    <cc1:ToolkitScriptManager ID="Too" runat="server">
    </cc1:ToolkitScriptManager>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <contenttemplate>
            <div id="Page">
            <div style="display: block" id="Block_MainPage" runat="server">
                    <div class="three-col-new">
                        <asp:Label runat="server" ID="lblResult" ForeColor="#FF3300"></asp:Label>
                        <div class="ControlsWrapper1">
                            <div>
                                <asp:Label ID="lblCustomerName" runat="server" Text="Customer Name"></asp:Label>
                                <asp:TextBox ID="txtCustomerName" TabIndex="1" Columns="20"
                                    runat="server" AutoPostBack="True" OnTextChanged="txtCustomerName_TextChanged"></asp:TextBox>
                                    <asp:Button ID="btnClear" runat="server" Text="Clear" CssClass="btnstyle"
                                     OnClick="btnClear_Click"></asp:Button>
                                    <cc1:AutoCompleteExtender ID="AutoHome" runat="server" MinimumPrefixLength="1" ServiceMethod="GetCustomerName"
                        TargetControlID="txtCustomerName" CompletionInterval="1">
                        
                    </cc1:AutoCompleteExtender>
                            </div>
                        </div>
                    </div>
                    <div class="gridcol" style="margin-left:13%;" id="divFreight" runat="server">
                    <asp:GridView ID="GridFreight" runat="server" AutoGenerateColumns="False"  ShowFooter="false">
                            <Columns>
                                <asp:TemplateField HeaderText="Sl.No">
                                    <ItemTemplate>
                                        <%#Container.DataItemIndex + 1 %>
                                    </ItemTemplate>
                                </asp:TemplateField>                                                          
                                  <asp:TemplateField HeaderText="Packings">
                                    <ItemTemplate>
                                        <%#Eval("Packings")%>
                                    </ItemTemplate>
                                </asp:TemplateField>                                                             
                            </Columns>
                        </asp:GridView>
                    </div>
            </div>
            </div>
            </contenttemplate>
    </asp:UpdatePanel>
</asp:Content>
