<%@ control language="C#" autoeventwireup="true" inherits="AccountUI.usercontrols_createjournalentry, App_Web_kyla4g6h" %>
<table style="width: 950px;">
    <tr>
        <td style="width: 50px;">
        </td>
        <td>
            <asp:Label ID="lblDate" Text="Date:" runat="server"></asp:Label>
        </td>
        <td>
            <asp:TextBox ID="txtDate" Width="160px" runat="server"></asp:TextBox>
        </td>
        <td style="width: 100px;">
        </td>
        <td>
            <asp:Label ID="lblAccount" runat="server" Text="Account:"></asp:Label>
        </td>
        <td>
            <asp:DropDownList ID="ddlAccount" DataTextField="Name" DataValueField="Id" Width="167px"
                runat="server">
            </asp:DropDownList>
        </td>
        <td style="width: 50px;">
        </td>
    </tr>
    <tr>
        <td style="width: 50px;">
        </td>
        <td>
            <asp:Label ID="lblParticular" Text="Particular:" runat="server"></asp:Label>
        </td>
        <td>
            <asp:TextBox ID="txtParticular" Width="160px" runat="server"></asp:TextBox>
            
        </td>
        <td>
        </td>
        <td>
            <asp:Label ID="lblType" runat="server" Text="Type:"></asp:Label>
        </td>
        <td>
            <asp:DropDownList ID="ddlType" DataTextField="Name" DataValueField="Id" Width="167px"
                runat="server">
                <asp:ListItem Text="--Select--" Value="--Select--"></asp:ListItem>
                <asp:ListItem Text="Dr" Value="Dr"></asp:ListItem>
                <asp:ListItem Text="Cr" Value="Cr"></asp:ListItem>
            </asp:DropDownList>
        </td>
        <td style="width: 50px;">
        </td>
    </tr>
    <tr>
        <td style="width: 50px;">
        </td>
        <td>
            
        </td>
        <td>
            
        </td>
        <td>
        </td>
        <td>
            <asp:Label ID="lblAmount" runat="server" Text="Amount:"></asp:Label>
        </td>
        <td>
            <asp:TextBox ID="txtAmount" Width="160px" runat="server"></asp:TextBox>
        </td>
        <td style="width: 50px;">
        </td>
    </tr>
</table>
<table style="width: 950px;">
    <tr>
        <td align="right">
            <asp:Button ID="btnAdd" runat="server" Text="Add" BorderStyle="Solid" BackColor="White"
                OnClick="btnAdd_Click" />
            <asp:Button ID="btnUpdate" runat="server" Text="Update" BorderStyle="Solid" BackColor="White"
                OnClick="btnUpdate_Click" />
            <asp:Button ID="btnRemove" runat="server" Text="Remove" BorderStyle="Solid" BackColor="White"
                OnClick="btnRemove_Click" />
            <asp:Button ID="btnCancel" runat="server" Text="Cancel" BorderStyle="Solid" BackColor="White"
                OnClick="btnCancel_Click" />
        </td>
    </tr>
</table>
<table style="width: 950px;">
    <tr>
        <td>
            <asp:GridView ID="grdCreateDebitsCredits" EmptyDataRowStyle-HorizontalAlign="Center" runat="server"
                Width="100%" EmptyDataText="No data found" AutoGenerateColumns="false">
                <EmptyDataRowStyle HorizontalAlign="Center"></EmptyDataRowStyle>
                <Columns>
                    <asp:TemplateField>
                        <ItemTemplate>
                            <asp:CheckBox ID="chkEdit" runat="server" AutoPostBack="true" OnCheckedChanged="chkEdit_CheckedChanged" />
                            <asp:HiddenField ID="hidAccountId" Value='<%#DataBinder.Eval(Container.DataItem,"Account.Id") %>'
                                runat="server" />
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Date">
                        <ItemTemplate>
                            <asp:Label ID="lblDate" runat="server" Text='<%# Bind("Date") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Account Name">
                        <ItemTemplate>
                            <asp:Label ID="lblAccountName" runat="server" Text='<%# Bind("Account.Name") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Particular">
                        <ItemTemplate>
                            <asp:Label ID="lblParticular" runat="server" Text='<%# Bind("Particular") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Dr / Cr">
                        <ItemTemplate>
                            <asp:Label ID="lblDrCr" runat="server" Text='<%# Bind("Type") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Amount">
                        <ItemTemplate>
                            <asp:Label ID="lblAmount" runat="server" Text='<%# Bind("Amount") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>                                      
                </Columns>
            </asp:GridView>
        </td>
    </tr>
</table>
<table style="width: 950px;">
    <tr>
        <td align="right">
            <asp:Button ID="btnSubmit" runat="server" Text="Submit" BorderStyle="Solid" BackColor="White"
                OnClick="btnSubmit_Click" />
            <asp:Button ID="btnSCancel" runat="server" Text="Cancel" BorderStyle="Solid" BackColor="White" />
        </td>
    </tr>
    <tr>
        <td align="center">
            <asp:Label ID="lblMessage" runat="server" Text="Data Inserted Successfully" Visible="false"
                ForeColor="red"></asp:Label>
                <asp:Label ID="lblError" runat="server" Text="You are trying to insert invalid data. Please correct journal entries." Visible="false"
                ForeColor="red"></asp:Label>
        </td>
    </tr>
</table>