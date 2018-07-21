<%@ control language="C#" autoeventwireup="true" inherits="AccountUI.usercontrols_createcompany, App_Web_kyla4g6h" %>
<table style="width: 950px;">
    <tr>
        <td style="width: 50px;">
        </td>
        <td>
            <asp:Label ID="lblName" Text="Name:" runat="server"></asp:Label>
        </td>
        <td>
            <asp:TextBox ID="txtName" Width="160px" runat="server"></asp:TextBox>
        </td>
        <td style="width: 100px;">
        </td>
        <td>
            <asp:Label ID="lblTelephone" runat="server" Text="Telephone:"></asp:Label>
        </td>
        <td>
            <asp:TextBox ID="txtTelephone" Width="160px" runat="server"></asp:TextBox>
        </td>
        <td style="width: 50px;">
        </td>
    </tr>
    <tr>
        <td style="width: 50px;">
        </td>
        <td>
            <asp:Label ID="lblMailingName" Text="Mailing name:" runat="server"></asp:Label>
        </td>
        <td>
            <asp:TextBox ID="txtMailingName" Width="160px" runat="server"></asp:TextBox>
        </td>
        <td>
        </td>
        <td>
            <asp:Label ID="lblEmail" runat="server" Text="E-mail:"></asp:Label>
        </td>
        <td>
            <asp:TextBox ID="txtEmail" Width="160px" runat="server"></asp:TextBox>
        </td>
        <td style="width: 50px;">
        </td>
    </tr>
    <tr>
        <td style="width: 50px;">
        </td>
        <td>
            <asp:Label ID="lblAddress" Text="Address:" runat="server"></asp:Label>
        </td>
        <td>
            <asp:TextBox ID="txtAddress" Width="160px" runat="server"></asp:TextBox>
        </td>
        <td>
        </td>
        <td>
            <asp:Label ID="lblFinancialStart" runat="server" Text="Financial start:"></asp:Label>
        </td>
        <td>
            <asp:TextBox ID="txtFinancialStart" Width="160px" runat="server"></asp:TextBox>
        </td>
        <td style="width: 50px;">
        </td>
    </tr>
    <tr>
        <td style="width: 50px;">
        </td>
        <td>
            <asp:Label ID="lblState" runat="server" Text="State:"></asp:Label>
        </td>
        <td>
            <asp:DropDownList ID="ddlState" DataTextField="Name" DataValueField="Id" Width="167px"
                runat="server">
            </asp:DropDownList>
        </td>
        <td>
        </td>
        <td>
            <asp:Label ID="lblBooksStart" runat="server" Text="Books start:"></asp:Label>
        </td>
        <td>
            <asp:TextBox ID="txtBooksStart" Width="160px" runat="server"></asp:TextBox>
        </td>
        <td style="width: 50px;">
        </td>
    </tr>
    <tr>
        <td style="width: 50px;">
        </td>
        <td>
            <asp:Label ID="lblPincode" runat="server" Text="Pincode:"></asp:Label>
        </td>
        <td>
            <asp:TextBox ID="txtPincode" Width="160px" runat="server"></asp:TextBox>
        </td>
        <td>
        </td>
        <td>
            <asp:Label ID="lblMaintain" runat="server" Text="Maintain:"></asp:Label>
        </td>
        <td>
            <asp:TextBox ID="txtMaintain" Width="160px" runat="server"></asp:TextBox>
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
            <asp:GridView ID="grdCreateCompany" EmptyDataRowStyle-HorizontalAlign="Center" runat="server"
                Width="100%" EmptyDataText="No data found" AutoGenerateColumns="false">
                <EmptyDataRowStyle HorizontalAlign="Center"></EmptyDataRowStyle>
                <Columns>
                    <asp:TemplateField>
                        <ItemTemplate>
                            <asp:CheckBox ID="chkEdit" runat="server" AutoPostBack="true" OnCheckedChanged="chkEdit_CheckedChanged" />
                            <asp:HiddenField ID="hidStateId" Value='<%#DataBinder.Eval(Container.DataItem,"objState.Id") %>'
                                runat="server" />
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Name">
                        <ItemTemplate>
                            <asp:Label ID="lblName" runat="server" Text='<%# Bind("Name") %>'></asp:Label>                            
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Mailing Name">
                        <ItemTemplate>
                            <asp:Label ID="lblMailingName" runat="server" Text='<%# Bind("MailingName") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Address">
                        <ItemTemplate>
                            <asp:Label ID="lblAddress" runat="server" Text='<%# Bind("Address") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="StateName">
                        <ItemTemplate>
                            <asp:Label ID="lblStateName" runat="server" Text='<%# Bind("objState.Name") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>                    
                    <asp:TemplateField HeaderText="Pincode">
                        <ItemTemplate>
                            <asp:Label ID="lblPincode" runat="server" Text='<%# Bind("Pincode") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Telephone">
                        <ItemTemplate>
                            <asp:Label ID="lblTelephone" runat="server" Text='<%# Bind("Telephone") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Email">
                        <ItemTemplate>
                            <asp:Label ID="lblEmail" runat="server" Text='<%# Bind("Email") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Financial Start">
                        <ItemTemplate>
                            <asp:Label ID="lblFinancialStart" runat="server" Text='<%# Bind("FinancialStart") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Books Start">
                        <ItemTemplate>
                            <asp:Label ID="lblBooksStart" runat="server" Text='<%# Bind("BooksStart") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Maintain">
                        <ItemTemplate>
                            <asp:Label ID="lblMaintain" runat="server" Text='<%# Bind("Maintain") %>'></asp:Label>
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
        </td>
    </tr>
</table>
