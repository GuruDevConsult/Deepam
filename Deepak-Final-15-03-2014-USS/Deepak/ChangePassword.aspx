<%@ page language="C#" masterpagefile="~/AppMaster.master" autoeventwireup="true" inherits="ChangePassword, App_Web_utcvgpzk" title="Untitled Page" %>

<asp:Content ID="Content1" ContentPlaceHolderID="PageContent" runat="Server">
    <div id="Page">
        <div class="single-col">
            <div>
                <asp:Label ID="lblStatus" runat="server" ForeColor="Red"></asp:Label></div>
            <div class="ControlsWrapper">
                <div>
                    <asp:Label ID="lblOldPassword" runat="server" TabIndex="1" Text="Old Password"></asp:Label><asp:TextBox
                        ID="OldPassword" runat="server" TextMode="Password"></asp:TextBox>
                </div>
                <div>
                    <asp:Label ID="lblNewPassword" runat="server" TabIndex="2" Text="New Password"></asp:Label><asp:TextBox
                        ID="NewPassword" runat="server" TextMode="Password"></asp:TextBox>
                </div>
                <div>
                    <asp:Label ID="lblReTypePassword" runat="server" TabIndex="3" Text="ReType Password"></asp:Label><asp:TextBox
                        ID="ReTypePassword" runat="server" TextMode="Password"></asp:TextBox>
                </div>
            </div>
        </div>
        <div class="ButtonsWrapper two-col-button">
            <asp:Button runat="server" ID="btnSubmit" Text="Submit" CausesValidation="true" ValidationGroup="Submit"
                CssClass="btnstyle" OnClick="btnSubmit_Click" AutoPostBack="true" />
            <asp:Button runat="server" ID="btnClear" Text="Clear" CssClass="btnstyle" />
        </div>
    </div>
</asp:Content>
