<%@ page language="C#" masterpagefile="~/AppMaster.master" autoeventwireup="true" inherits="DayBook, App_Web_zwikzsdt" title="Deepak Roadways" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="PageContent" runat="Server">
    <cc1:ToolkitScriptManager ID="Too" runat="server">
    </cc1:ToolkitScriptManager>
    <div id="Page">
        <div class="three-col-new">
            <asp:Label runat="server" ID="lblResult" Text="result" ForeColor="#FF3300"></asp:Label>
            <div class="ControlsWrapper1">
                <div>
                    <asp:Label ID="lblDayBookDate" runat="server" Text="DayBookDate"></asp:Label>
                    <asp:TextBox ID="DayBookDate" onkeypress="return isNumberKey(event)"
                        MaxLength="20" runat="server" AutoPostBack="True" OnTextChanged="DayBookDate_TextChanged"></asp:TextBox>
                    <cc1:CalendarExtender ID="CalendarExtender1" runat="server" Format="dd/MM/yyyy" TargetControlID="DayBookDate"
                        CssClass="cal_Theme">
                    </cc1:CalendarExtender>
                </div>
            </div>
            <div class="gridcol">
                <asp:GridView ID="GridDayBook" runat="server" AutoGenerateColumns="false" ShowFooter="True"
                    OnRowCommand="GridDayBook_RowCommand" 
                    OnRowEditing="GridDayBook_RowEditing" OnRowUpdating="GridDayBook_RowUpdating"
                    OnRowCancelingEdit="GridDayBook_RowCancelingEdit" 
                    onpageindexchanging="GridDayBook_PageIndexChanging" PageSize="20" 
                    onrowdeleting="GridDayBook_RowDeleting">
                    <%--
                onrowediting="GridDayBook_RowEditing" onrowupdating="GridDayBook_RowUpdating" 
                onrowdeleting="GridDayBook_RowDeleting" OnRowCancelingEdit="GridDayBook_RowCancelingEdit"--%>
                    <Columns>
                        <asp:TemplateField HeaderText="Sl.No">
                            <ItemTemplate>
                                <%# Container.DataItemIndex + 1 %>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="ID" Visible="false">
                            <ItemTemplate>
                                <asp:Label runat="server" ID="txtID" Text='<%#Eval("ID")%>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Date">
                            <EditItemTemplate>
                                <asp:TextBox ID="txtDate_edit" TabIndex="1" Width="100px" runat="server" Text='<%#Bind("Date") %>'
                                    onKeyPress="return alphanumeric_only(this);"></asp:TextBox>
                                <cc1:CalendarExtender ID="CalendarExtender2" runat="server" Format="dd/MM/yyyy" TargetControlID="txtDate_edit"
                                    CssClass="cal_Theme">
                                </cc1:CalendarExtender>
                            </EditItemTemplate>
                            <FooterTemplate>
                                <asp:TextBox ID="txtDate_footer" Width="100px" TabIndex="1" runat="server" Text='<%#Bind("Date") %>'
                                    onKeyPress="return alphanumeric_only(this);"></asp:TextBox>
                                <cc1:CalendarExtender ID="CalendarExtender3" runat="server" Format="dd/MM/yyyy" TargetControlID="txtDate_footer"
                                    CssClass="cal_Theme">
                                </cc1:CalendarExtender>
                            </FooterTemplate>
                            <ItemTemplate>
                                <%#Eval("Date")%>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Account">
                            <EditItemTemplate>
                                <asp:DropDownList ID="ddlAccount_edit" runat="server" TabIndex="1" Width="120px">
                                </asp:DropDownList>
                            </EditItemTemplate>
                            <FooterTemplate>
                                <asp:DropDownList ID="ddlAccount_footer" runat="server" TabIndex="1" Width="120px">
                                </asp:DropDownList>
                            </FooterTemplate>
                            <ItemTemplate>
                                <%#Eval("AccountName")%>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Type">
                            <EditItemTemplate>
                                <asp:DropDownList ID="ddlType_edit" runat="server" TabIndex="2" Width="120px">
                                    <asp:ListItem Value="0">---SELECT---</asp:ListItem>
                                    <asp:ListItem Value="1">Dr</asp:ListItem>
                                    <asp:ListItem Value="2">Cr</asp:ListItem>
                                </asp:DropDownList>
                            </EditItemTemplate>
                            <FooterTemplate>
                                <asp:DropDownList ID="ddlType_footer" runat="server" TabIndex="2" Width="120px">
                                    <asp:ListItem Value="0">---SELECT---</asp:ListItem>
                                    <asp:ListItem Value="1">Dr</asp:ListItem>
                                    <asp:ListItem Value="2">Cr</asp:ListItem>
                                </asp:DropDownList>
                            </FooterTemplate>
                            <ItemTemplate>
                                <%#Eval("Types")%>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Particulars">
                            <EditItemTemplate>
                                <asp:TextBox ID="txtParticulars_edit" Width="100%" runat="server" TabIndex="3" TextMode="MultiLine"
                                    Text='<%#Bind("Particulars") %>' onKeyPress="return alphanumeric_only(this);"></asp:TextBox>
                            </EditItemTemplate>
                            <FooterTemplate>
                                <asp:TextBox ID="txtParticulars_footer" Width="100%" TabIndex="3" TextMode="MultiLine"
                                    runat="server" Text='<%#Bind("Particulars") %>' onKeyPress="return alphanumeric_only(this);"></asp:TextBox>
                            </FooterTemplate>
                            <ItemTemplate>
                                <%#Eval("Particulars")%>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Amount">
                            <EditItemTemplate>
                                <asp:TextBox ID="txtAmount_edit" Width="120px" TabIndex="4" runat="server" Text='<%#Bind("Amount") %>'
                                    onKeyPress="return isNumberKey(event)"></asp:TextBox>
                            </EditItemTemplate>
                            <FooterTemplate>
                                <asp:TextBox ID="txtAmount_footer" Width="120px" TabIndex="4" runat="server" Text='<%#Bind("Amount") %>'
                                    onKeyPress="return isNumberKey(event)"></asp:TextBox>
                            </FooterTemplate>
                            <ItemTemplate>
                                <%#Eval("Amount")%>
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
                                <asp:LinkButton ID="LinkButton3" runat="server" TabIndex="5" CommandName="InsertNew"
                                    Text="<img src='App_Themes/Images/Insert1.gif' border='0' title='Insert' />"
                                    CssClass="buttonimage" Width="25%"></asp:LinkButton>
                                <asp:LinkButton ID="LinkButton4" runat="server" TabIndex="6" CommandName="CancelNew" Text="<img src='App_Themes/Images/Cancel.gif'border='0' title='Cancel'  />"
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
        </div>
    </div>
</asp:Content>
