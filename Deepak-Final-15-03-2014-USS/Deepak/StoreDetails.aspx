<%@ page language="C#" masterpagefile="~/AppMaster.master" autoeventwireup="true" inherits="StoreDetails, App_Web_utcvgpzk" title="Deepak Roadways" %>

<asp:Content ID="Content1" ContentPlaceHolderID="PageContent" runat="Server">

    <script>
function ConfirmDelete() 
{
   return confirm('Are you sure you want to delete?');
}
    </script>

    <div id="Page_Single">
        <div class="three-col">
            <asp:Label ID="lblmsg" runat="server" Text="" ForeColor="red"></asp:Label>
            <div class="ControlsWrapper">
                <div class="gridcol">
                    <asp:GridView ID="GridStore" runat="server" AutoGenerateColumns="false" ShowFooter="True"
                        OnRowCommand="GridStore_RowCommand" OnRowEditing="GridStore_RowEditing" OnRowUpdating="GridStore_RowUpdating"
                        OnRowDeleting="GridStore_RowDeleting" OnRowCancelingEdit="GridStore_RowCancelingEdit"
                        AllowPaging="true">
                        <Columns>
                            <asp:TemplateField HeaderText="Sl.No">
                                <ItemTemplate>
                                    <%#Container.DataItemIndex + 1 %>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Godown No">
                                <EditItemTemplate>
                                    <asp:TextBox ID="txtStoreNo" Width="120px" runat="server" Text='<%#Bind("StoreNo") %>'
                                        onkeypress="return alphanumeric_only(this);"></asp:TextBox>
                                </EditItemTemplate>
                                <FooterTemplate>
                                    <asp:TextBox ID="txtStoreNo1" Width="120px" runat="server" Text='<%#Bind("StoreNo") %>'
                                        onkeypress="return alphanumeric_only(this);"></asp:TextBox>
                                </FooterTemplate>
                                <ItemTemplate>
                                    <%#Eval("StoreNo")%>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Godown Address">
                                <EditItemTemplate>
                                    <asp:TextBox ID="txtStoreAddress" runat="server" Text='<%#Bind("StoreAddress") %>'
                                        Width="88%" TextMode="MultiLine"></asp:TextBox>
                                </EditItemTemplate>
                                <FooterTemplate>
                                    <asp:TextBox ID="txtStoreAddress1" runat="server" Text='<%#Bind("StoreAddress") %>'
                                        Width="88%" TextMode="MultiLine"></asp:TextBox>
                                </FooterTemplate>
                                <ItemTemplate>
                                    <%#Eval("StoreAddress")%>
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
            </div>
        </div>
    </div>
</asp:Content>
