<%@ page language="C#" masterpagefile="~/AppMaster.master" autoeventwireup="true" inherits="ItemDetails, App_Web_zwikzsdt" title="Deepak Roadways" %>

<asp:Content ID="Content1" ContentPlaceHolderID="PageContent" Runat="Server">
<script>
function ConfirmDelete() 
{
   return confirm('Are you sure you want to delete?');
}

</script>
<div id="Page_Single">
    <%--<div class="three-col">
        <div class="ControlsWrapper">
            <div>
                <asp:Label runat="server" ID="lblItemName" Text="Item Name"></asp:Label>        
                <asp:TextBox runat="server" onKeyPress="isValidAlpha(this)" ID="ItemName" TabIndex="1"></asp:TextBox>
             </div>
        </div>
    </div>--%>
    <div class="three-col">
    <asp:Label runat="server" ID="lblResult" Text="result" ForeColor="#FF3300"></asp:Label>        
    
        <div class="ControlsWrapper">
        <div class="gridcol">
        <asp:GridView ID="GridItem" runat="server"  AutoGenerateColumns="false" 
                ShowFooter="True" onrowcommand="GridItem_RowCommand" 
                onrowediting="GridItem_RowEditing" onrowupdating="GridItem_RowUpdating" 
                onrowdeleting="GridItem_RowDeleting" 
                OnRowCancelingEdit="GridItem_RowCancelingEdit" AllowPaging="True" 
                onpageindexchanging="GridItem_PageIndexChanging" PageSize="10" >
            <Columns>
            <asp:TemplateField HeaderText="Sl.No">
                <ItemTemplate>
                    <%# Container.DataItemIndex + 1 %>
                </ItemTemplate>
            </asp:TemplateField>

                <asp:TemplateField HeaderText ="Item ID" Visible="false">
                    <%--<EditItemTemplate >
                        <asp:TextBox ID ="txtItemID" runat ="server" Text ='<%#Bind("ID") %>'></asp:TextBox>
                    </EditItemTemplate>
                   <FooterTemplate >
                    <asp:Label runat="server" ID="txtItemID1" ></asp:Label>
                    </FooterTemplate>--%>
                    <ItemTemplate >
                    <asp:Label runat="server" ID="txtItemID" Text='<%#Eval("ID")%>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText ="Item Name">
                    <EditItemTemplate >
                        <asp:TextBox ID ="txtItemName" runat ="server" Text ='<%#Bind("ItemName") %>' onkeypress="return alphanumeric_only(this);"></asp:TextBox>
                    </EditItemTemplate>
                    <FooterTemplate >
                        <asp:TextBox ID="txtItemName1" Width ="120px" runat ="server" Text ='<%#Bind("ItemName") %>' onkeypress="return alphanumeric_only(this);"></asp:TextBox>
                    </FooterTemplate>
                    <ItemTemplate >
                        <%#Eval("ItemName")%>
                    </ItemTemplate>
                </asp:TemplateField> 
               <%-- <asp:TemplateField HeaderText ="Rate">
                    <EditItemTemplate >
                        <asp:TextBox ID ="txtRate" runat ="server" Text ='<%#Bind("Rate") %>' onkeypress="return isNumberKey(this);"></asp:TextBox>
                    </EditItemTemplate>
                    <FooterTemplate >
                        <asp:TextBox ID="txtRate1" Width ="120px" runat ="server" Text ='<%#Bind("Rate") %>' onkeypress="return isNumberKey(this);"></asp:TextBox>
                    </FooterTemplate>
                    <ItemTemplate >
                        <%#Eval("Rate")%>
                    </ItemTemplate>
                </asp:TemplateField> --%>
                <asp:TemplateField  HeaderText ="Options">
                   <EditItemTemplate >
                    <asp:LinkButton ID="LinkButton1" runat="server" CommandName ="Update" Text ="<img src='App_Themes/Images/Update.gif' border='0' title='Update' />" CssClass="buttonimage" Width ="25%"></asp:LinkButton>
                    <asp:LinkButton ID="LinkButton2" runat="server" CommandName ="Cancel" Text ="<img src='App_Themes/Images/Cancel.gif' border='0' title='Cancel' />" CssClass="buttonimage" Width ="25%"></asp:LinkButton>
                   </EditItemTemplate> 
                   <FooterTemplate >
                    <asp:LinkButton ID="LinkButton3" runat="server" CommandName ="InsertNew" Text ="<img src='App_Themes/Images/Insert1.gif' border='0' title='Insert' />" CssClass="buttonimage" Width ="25%"></asp:LinkButton>
                    <asp:LinkButton ID="LinkButton4" runat="server" CommandName ="CancelNew" Text ="<img src='App_Themes/Images/Cancel.gif'border='0' title='Cancel'  />" CssClass="buttonimage" Width ="25%"></asp:LinkButton>
                   </FooterTemplate>
                   <ItemTemplate >
                     <asp:LinkButton ID="LinkButton5" runat="server" CommandName ="Edit" Text ="<img src='App_Themes/Images/Edit.gif' border='0' title='Edit' />" CssClass="buttonimage" Width ="25%"></asp:LinkButton>
                     <asp:LinkButton ID="LinkButton6" runat="server" CommandName ="Delete" OnClientClick="return ConfirmDelete();" Text ="<img src='App_Themes/Images/Del.gif' border='0' title='Delete' />" CssClass="buttonimage" Width ="25%"></asp:LinkButton>
                   </ItemTemplate>                       
                </asp:TemplateField> 
            </Columns>
            <%--<PagerTemplate>
            <table width="100%">
                <tr>
                    <td style="text-align: right">
                        <asp:PlaceHolder ID="PlaceHolder1" runat="server" />
                    </td>
                </tr>
            </table>
        </PagerTemplate>--%>
        </asp:GridView>
        </div>
      </div>
    </div>
    <%--<div class="ButtonsWrapper three-col-button">
        <div class="btn_spaces">
            <asp:Button ID="btnSave" Text="Save" runat="server" CssClass="btnstyle" TabIndex="11" />
            <asp:Button ID="btnclear" Text="Clear" runat="server"  CssClass="btnstyle"/>
            <asp:Button ID="btnDelete" Text="Delete" runat="server" CssClass="btnstyle" />
            <asp:HiddenField ID="hidBank" runat="server" />
            <asp:HiddenField ID="hidAdd" runat="server" />
        </div>
     </div>--%>
</div>            
</asp:Content>

