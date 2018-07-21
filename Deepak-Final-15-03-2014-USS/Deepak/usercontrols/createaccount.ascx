<%@ control language="C#" autoeventwireup="true" inherits="AccountUI.usercontrols_createaccount, App_Web_kyla4g6h" %>
<table style="width: 950px;">
    <tr>
        <td style="width: 50px;">
        </td>
        <td>
            <asp:Label ID="lblAccountName" Text="Account Name:" runat="server"></asp:Label>
        </td>
        <td>
            <asp:TextBox ID="txtAccountName" Width="160px" runat="server"></asp:TextBox>
        </td>
        <td style="width: 100px;">
        </td>
        <td>
            <asp:Label ID="lblCompanyName" runat="server" Text="Company Name:"></asp:Label>
        </td>
        <td>
            <asp:DropDownList ID="ddlCompany" DataTextField="Name" DataValueField="Id" Width="167px"
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
            <asp:Label ID="lblGroupName" Text="Group Name:" runat="server"></asp:Label>
        </td>
        <td>
            <asp:DropDownList ID="ddlGroupName" DataTextField="Name" DataValueField="Id" Width="167px"
                runat="server">
            </asp:DropDownList>
        </td>
        <td>
        </td>
        <td>
            <asp:Label ID="lblPanITNo" runat="server" Text="Pan IT No:"></asp:Label>
        </td>
        <td>
            <asp:TextBox ID="txtPanITNo" Width="160px" runat="server"></asp:TextBox>
        </td>
        <td style="width: 50px;">
        </td>
    </tr>
    <tr>
        <td style="width: 50px;">
        </td>
        <td>
            <asp:Label ID="lblSalesTaxNo" Text="Sales Tax No:" runat="server"></asp:Label>
        </td>
        <td>
            <asp:TextBox ID="txtSalesTaxNo" Width="160px" runat="server"></asp:TextBox>
        </td>
        <td>
        </td>
        <td>
            <asp:Label ID="lblAddress" runat="server" Text="Address:"></asp:Label>
        </td>
        <td>
            <asp:TextBox ID="txtAddress" Width="160px" runat="server"></asp:TextBox>
        </td>
        <td style="width: 50px;">
        </td>
    </tr>
    <tr>
        <td style="width: 50px;">
        </td>
        <td>
            <asp:Label ID="lblCity" runat="server" Text="City:"></asp:Label>
        </td>
        <td>
            <asp:TextBox ID="txtCity" Width="160px" runat="server"></asp:TextBox>
        </td>
        <td>
        </td>
        <td>
            <asp:Label ID="lblState" runat="server" Text="State:"></asp:Label>            
        </td>
        <td>
            <asp:DropDownList ID="ddlState" DataTextField="Name" DataValueField="Id" Width="167px"
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
            <asp:Label ID="lblPincode" runat="server" Text="Pincode:"></asp:Label>
        </td>
        <td>
            <asp:TextBox ID="txtPincode" Width="160px" runat="server"></asp:TextBox>
        </td>
        <td>
        </td>
        <td>
            <asp:Label ID="lblIsHiddenUser" runat="server" Text="Is Hidden User:"></asp:Label>
        </td>
        <td>
            <asp:CheckBox ID="chkIsHiddenUser" runat="server" />
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
            <asp:GridView ID="grdCreateAccount" EmptyDataRowStyle-HorizontalAlign="Center" runat="server"
                Width="100%" EmptyDataText="No data found" AutoGenerateColumns="false">
                <EmptyDataRowStyle HorizontalAlign="Center"></EmptyDataRowStyle>
                <Columns>
                    <asp:TemplateField>
                        <ItemTemplate>
                            <asp:CheckBox ID="chkEdit" runat="server" AutoPostBack="true" OnCheckedChanged="chkEdit_CheckedChanged" />
                            <asp:HiddenField ID="hidCompanyId" Value='<%#DataBinder.Eval(Container.DataItem,"Company.Id") %>'
                                runat="server" />
                            <asp:HiddenField ID="hidStateId" Value='<%#DataBinder.Eval(Container.DataItem,"State.Id") %>'
                                runat="server" />
                            <asp:HiddenField ID="hidGroupId" Value='<%#DataBinder.Eval(Container.DataItem,"Group.Id") %>'
                                runat="server" />                            
                            <asp:HiddenField ID="hidIsHiddenUser" Value='<%#DataBinder.Eval(Container.DataItem,"IsHiddenUser") %>'
                                runat="server" />
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Name">
                        <ItemTemplate>
                            <asp:Label ID="lblName" runat="server" Text='<%# Bind("Name") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Company Name">
                        <ItemTemplate>
                            <asp:Label ID="lblCompanyName" runat="server" Text='<%# Bind("Company.Name") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Pan IT No">
                        <ItemTemplate>
                            <asp:Label ID="lblPanItNo" runat="server" Text='<%# Bind("PanItNo") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Sales Tax No">
                        <ItemTemplate>
                            <asp:Label ID="lblSalesTaxNo" runat="server" Text='<%# Bind("SalesTaxNo") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Group Name">
                        <ItemTemplate>
                            <asp:Label ID="lblGroupName" runat="server" Text='<%# Bind("Group.Name") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Address">
                        <ItemTemplate>
                            <asp:Label ID="lblAddress" runat="server" Text='<%# Bind("Address") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>                    
                    <asp:TemplateField HeaderText="City">
                        <ItemTemplate>
                            <asp:Label ID="lblCity" runat="server" Text='<%# Bind("City") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>                    
                    <asp:TemplateField HeaderText="State">
                        <ItemTemplate>
                            <asp:Label ID="lblState" runat="server" Text='<%# Bind("State.Name") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>                    
                    <asp:TemplateField HeaderText="Pincode">
                        <ItemTemplate>
                            <asp:Label ID="lblPincode" runat="server" Text='<%# Bind("Pincode") %>'></asp:Label>
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