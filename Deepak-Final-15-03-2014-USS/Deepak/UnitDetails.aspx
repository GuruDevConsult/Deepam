<%@ page language="C#" masterpagefile="~/AppMaster.master" autoeventwireup="true" inherits="UnitDetails, App_Web_utcvgpzk" title="Deepak Roadways" %>

<asp:Content ID="Content1" ContentPlaceHolderID="PageContent" Runat="Server">

    <script>
function ConfirmDelete() 
{
   return confirm('Are you sure you want to delete?');
}



</script>
<div id="Page_Single">
    <div class="three-col">
    <asp:Label runat="server" ID="lblResult" Text="result" ForeColor="#FF3300"></asp:Label>        
    
        <div class="ControlsWrapper">
        <div class="gridcol">
        <asp:GridView ID="GridUnit" runat="server"  AutoGenerateColumns="false" 
                ShowFooter="True" onrowcommand="GridUnit_RowCommand" 
                onrowediting="GridUnit_RowEditing" onrowupdating="GridUnit_RowUpdating" 
                onrowdeleting="GridUnit_RowDeleting" 
                OnRowCancelingEdit="GridUnit_RowCancelingEdit" AllowPaging="True" 
                onpageindexchanging="GridUnit_PageIndexChanging">
            <Columns>
            <asp:TemplateField HeaderText="Sl.No">
                <ItemTemplate>
                    <%# Container.DataItemIndex + 1 %>
                </ItemTemplate>
            </asp:TemplateField>
                <asp:TemplateField HeaderText ="Unit Name">
                    <EditItemTemplate >
                        <asp:TextBox ID ="txtUnitName" runat ="server" Text ='<%#Bind("UnitName") %>' onkeypress="return alphanumeric_only(this);"></asp:TextBox>
                    </EditItemTemplate>
                    <FooterTemplate >
                        <asp:TextBox ID="txtUnitName1" Width ="120px" runat ="server" Text ='<%#Bind("UnitName") %>' onkeypress="return alphanumeric_only(this);"></asp:TextBox>
                    </FooterTemplate>
                    <ItemTemplate >
                        <%#Eval("UnitName")%>
                    </ItemTemplate>
                </asp:TemplateField> 
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
        </asp:GridView>
        </div>
      </div>
    </div>
</div> 
</asp:Content>

