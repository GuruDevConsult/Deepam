<%@ control language="C#" autoeventwireup="true" inherits="AccountUI.usercontrols_createuser, App_Web_kyla4g6h" %>
<table style="width: 950px;">
    <tr>
        <td style="width: 50px;">
        </td>
        <td>
            <asp:Label ID="lblFirstName" Text="First Name:" runat="server"></asp:Label>
        </td>
        <td>
            <asp:TextBox ID="txtFirstName" Width="160px" runat="server"></asp:TextBox>
        </td>
        <td style="width: 100px;">
        </td>
        <td>
            <asp:Label ID="lblUserName" runat="server" Text="User Name:"></asp:Label>
        </td>
        <td>
            <asp:TextBox ID="txtUserName" Width="160px" runat="server"></asp:TextBox>
        </td>
        <td style="width: 50px;">
        </td>
    </tr>
    <tr>
        <td style="width: 50px;">
        </td>
        <td>
            <asp:Label ID="lblLastName" Text="Last Name:" runat="server"></asp:Label>
        </td>
        <td>
            <asp:TextBox ID="txtLastName" Width="160px" runat="server"></asp:TextBox>
        </td>
        <td>
        </td>
        <td>
            <asp:Label ID="lblPassword" runat="server" Text="Password:"></asp:Label>
        </td>
        <td>
            <asp:TextBox ID="txtPassword" Width="160px" runat="server" TextMode="Password"></asp:TextBox>
        </td>
        <td style="width: 50px;">
        </td>
    </tr>
    <tr>
        <td style="width: 50px;">
        </td>
        <td>
            <asp:Label ID="lblsex" Text="Sex:" runat="server"></asp:Label>
        </td>
        <td>
            <asp:DropDownList ID="ddlSex" Width="167px" runat="server">
                <asp:ListItem Value="--Select--" Text="--Select--"></asp:ListItem>
                <asp:ListItem Value="Male" Text="Male"></asp:ListItem>
                <asp:ListItem Value="Female" Text="Female"></asp:ListItem>
            </asp:DropDownList>
        </td>
        <td>
        </td>
        <td>
            <asp:Label ID="lblConfirmPwd" runat="server" Text="Confirm Password:"></asp:Label>
        </td>
        <td>
            <asp:TextBox ID="txtConfirmPwd" Width="160px" runat="server" TextMode="Password"></asp:TextBox>
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
            <asp:Label ID="lblIsHiddenUser" runat="server" Text="Is Hidden User:"></asp:Label>
        </td>
        <td>
            <asp:CheckBox ID="chkIsHiddenUser" runat="server" />
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
            <asp:Label ID="lblRole" runat="server" Text="Role:"></asp:Label>
        </td>
        <td>
            <asp:DropDownList ID="ddlRole" DataTextField="RoleName" DataValueField="RoleId" Width="167px"
                runat="server">
            </asp:DropDownList>
        </td>
        <td style="width: 50px;">
        </td>
    </tr>
    <tr>
        <td style="width: 50px;">
        </td>
        <td valign="top">
            <asp:Label ID="lblEmail" runat="server" Text="Email:"></asp:Label>
        </td>
        <td valign="top">
            <asp:TextBox ID="txtEmail" Width="160px" runat="server"></asp:TextBox>
        </td>
        <td>
        </td>
        <td valign="top">
            <asp:Label ID="lblCompany" runat="server" Text="Company:"></asp:Label>
        </td>
        <td valign="top">
            <asp:CheckBoxList ID="cblCompany" runat="server">
            </asp:CheckBoxList>
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
            <asp:GridView ID="grdCreateUser" EmptyDataRowStyle-HorizontalAlign="Center" runat="server"
                Width="100%" EmptyDataText="No data found" AutoGenerateColumns="false">
                <EmptyDataRowStyle HorizontalAlign="Center"></EmptyDataRowStyle>
                <Columns>
                    <asp:TemplateField>
                        <ItemTemplate>
                            <asp:CheckBox ID="chkEdit" runat="server" AutoPostBack="true" OnCheckedChanged="chkEdit_CheckedChanged" />
                            <asp:HiddenField ID="hidCompanyId" Value='<%#DataBinder.Eval(Container.DataItem,"CompanyId") %>'
                                runat="server" />
                            <asp:HiddenField ID="hidRoleId" Value='<%#DataBinder.Eval(Container.DataItem,"RoleId") %>'
                                runat="server" />
                            <asp:HiddenField ID="hidPassword" Value='<%#DataBinder.Eval(Container.DataItem,"Password") %>'
                                runat="server" />
                            <asp:HiddenField ID="hidConfirmPassword" Value='<%#DataBinder.Eval(Container.DataItem,"ConfirmPassword") %>'
                                runat="server" />
                            <asp:HiddenField ID="hidIsHiddenUser" Value='<%#DataBinder.Eval(Container.DataItem,"IsHiddenUser") %>'
                                runat="server" />
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="First Name">
                        <ItemTemplate>
                            <asp:Label ID="lblFirstName" runat="server" Text='<%# Bind("FirstName") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Last Name">
                        <ItemTemplate>
                            <asp:Label ID="lblLastName" runat="server" Text='<%# Bind("LastName") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="User Name">
                        <ItemTemplate>
                            <asp:Label ID="lblUserName" runat="server" Text='<%# Bind("UserName") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="State">
                        <ItemTemplate>
                            <asp:Label ID="lblState" runat="server" Text='<%# Bind("State") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Sex">
                        <ItemTemplate>
                            <asp:Label ID="lblSex" runat="server" Text='<%# Bind("Sex") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="City">
                        <ItemTemplate>
                            <asp:Label ID="lblCity" runat="server" Text='<%# Bind("City") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Email">
                        <ItemTemplate>
                            <asp:Label ID="lblEmail" runat="server" Text='<%# Bind("Email") %>'></asp:Label>
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
