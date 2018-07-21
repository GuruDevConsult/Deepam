<%@ page language="C#" masterpagefile="~/AppMaster.master" autoeventwireup="true" inherits="BankDetails, App_Web_utcvgpzk" title="Deepak Roadways" %>

<asp:Content ID="Content1" ContentPlaceHolderID="PageContent" runat="Server">
    <div id="Page">
        <div class="three-col-new">
            <asp:Label ID="lblmsg" runat="server" Text="" ForeColor="Red"></asp:Label>
            <div class="ControlsWrapper1">
                <div>
                    <asp:Label runat="server" ID="lblBankName" Text="Bank Name"></asp:Label>
                    <asp:TextBox runat="server" onKeyPress="isValidAlpha(this)" ID="BankName" MaxLength="20"
                        TabIndex="1"></asp:TextBox>&nbsp;
                </div>
                <div>
                    <asp:Label runat="server" ID="lblBankCode" Text="Bank Code"></asp:Label>
                    <asp:TextBox runat="server" ID="BankCode" TabIndex="2" MaxLength="10"></asp:TextBox>
                </div>
                <div>
                    <asp:Label runat="server" ID="lblIFSCode" Text="IFS Code"></asp:Label>
                    <asp:TextBox runat="server" ID="IFSCode" TabIndex="3" MaxLength="20"></asp:TextBox>
                </div>
                <div>
                    <asp:Label runat="server" ID="lblbranchname" Text="Branch Name"></asp:Label>
                    <asp:TextBox runat="server" onKeyPress="isValidAlpha(this)" ID="BranchName" MaxLength="20"
                        TabIndex="4"></asp:TextBox>
                </div>
            </div>
            <div class="ControlsWrapper1">
                <div>
                    <asp:Label runat="server" ID="lblAccType" Text="Account Type"></asp:Label>
                    <asp:DropDownList ID="ddlAccType" runat="server" TabIndex="5">
                        <asp:ListItem Text="--Select--" Value="--Select--"></asp:ListItem>
                        <asp:ListItem>Current</asp:ListItem>
                        <asp:ListItem>Savings</asp:ListItem>
                    </asp:DropDownList>
                </div>
                <div>
                    <asp:Label runat="server" ID="lblAccNo" Text="Account No"></asp:Label>
                    <asp:TextBox runat="server" ID="AccNo" TabIndex="6" MaxLength="20"></asp:TextBox>
                </div>
                <div>
                    <asp:Label runat="server" ID="lblAccName" Text="Account Name"></asp:Label>
                    <asp:TextBox runat="server" ID="AccName" TabIndex="7" MaxLength="20"></asp:TextBox>
                </div>
            </div>
            <div class="ControlsWrapper1">
                <div>
                    <asp:Label runat="server" ID="lbladdress" Text="Address"></asp:Label>
                    <asp:TextBox runat="server" ID="Address" TextMode="MultiLine" TabIndex="8"></asp:TextBox>
                </div>
                <div>
                    <asp:Label runat="server" ID="lblcity" Text="City"></asp:Label>
                    <asp:TextBox runat="server" onKeyPress="isValidAlpha(this)" ID="City" MaxLength="20"
                        TabIndex="9"></asp:TextBox>
                </div>
                <div>
                    <asp:Label runat="server" ID="lblpincode" Text="PinCode"></asp:Label>
                    <asp:TextBox runat="server" onKeyPress="return isNumberKey(event)" ID="PinCode" MaxLength="6"
                        TabIndex="10"></asp:TextBox>
                </div>
            </div>
        </div>
        <div class="ButtonsWrapper three-col-button">
            <div class="btn_spaces">
                <asp:Button ID="btnsave" Text="Save" runat="server" CssClass="btnstyle" OnClick="btnsave_Click"
                    TabIndex="11" />
                <asp:Button ID="btnclear" Text="Clear" runat="server" CssClass="btnstyle" OnClick="btnclear_Click" />
                <asp:Button ID="btndelete" Text="Delete" runat="server" CssClass="btnstyle" OnClick="btndelete_Click"
                    OnClientClick="return ConfirmDelete();" />
                <asp:HiddenField ID="hidBank" runat="server" />
                <asp:HiddenField ID="hidAdd" runat="server" />
            </div>
        </div>
        <div class="gridcol">
        <asp:GridView ID="GridBank" runat="server" BackColor="#DEBA84" BorderColor="#DEBA84"
            BorderStyle="None" BorderWidth="1px" CellPadding="3" CellSpacing="2" OnRowCreated="GridBank_RowCreated"
            OnSelectedIndexChanging="GridBank_SelectedIndexChanging">
            <FooterStyle BackColor="#F7DFB5" ForeColor="#003f81" />
            <RowStyle BackColor="#e9edf2" ForeColor="#003f81" />
            <SelectedRowStyle BackColor="#e9edf2" Font-Bold="True" ForeColor="#003f81" />
            <PagerStyle ForeColor="#8C4510" HorizontalAlign="Center" />
            <HeaderStyle BackColor="#dae9f3" Font-Bold="True" ForeColor="White" />
            <Columns>
                <asp:CommandField HeaderText="Select" ShowSelectButton="True" />
            </Columns>
        </asp:GridView>
    </div>
    </div>
    
</asp:Content>
