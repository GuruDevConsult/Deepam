<%@ page language="C#" autoeventwireup="true" inherits="AccountUI.Login, App_Web_j2s_bpzk" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Login Page</title>

    <script language="javascript">
        function ClearData()
        {
            var UserId = document.getElementById('<%=txtUserId.ClientID %>');
            var Pwd = document.getElementById('<%=txtPwd.ClientID %>');
            UserId.value='';Pwd.value='';
        }
    </script>

    <link href="App_Themes/login-box.css" rel="stylesheet" type="text/css">
</head>
<body>
    <form id="form1" runat="server">
    <div id="login">
        <%--<div id="banner">
       <img src="App_Themes/Images/cargo.png" alt="Banner" />
    </div>--%>
        <div id="login-box">
            <h2>
                Login</h2>
            <div class="login-box-name" style="margin-top: 20px;">
                <asp:Label runat="server" ID="lblbranches" Text="Branch name" Width="95px" Style="margin-left: -10px"></asp:Label>
            </div>
            <div class="login-box-field" style="margin-top: 20px;">
                <asp:DropDownList class="" runat="server" ID="ddlBranchName">
                    <asp:ListItem Value="0">SELECT</asp:ListItem>
                </asp:DropDownList>
            </div>
 
            <div class="login-box-name" style="margin-top: 20px;">
                <asp:Label ID="lblUserId" runat="server" Text="User Id:"></asp:Label>
            </div>
            <div class="login-box-field" style="margin-top: 20px;">
                <asp:TextBox class="form-login" runat="server" ID="txtUserId" onkeypress="capLock(event)"></asp:TextBox>
            </div>
            <div class="login-box-name">
                <asp:Label runat="server" ID="lblPwd" Text="Password"></asp:Label>
            </div>
            <div class="login-box-field">
                <asp:TextBox class="form-login" runat="server" ID="txtPwd" onkeypress="capLock(event)"
                    TextMode="Password"></asp:TextBox>
            </div>
            <br>
            <span class="login-box-options"><a href="#" style="margin-right: 5%">Change Password</a>
                <a href="#" onclick="SaveClicked(document.getElementById('UserName')); return false;">
                    Forgot Password</a> </span>
            <br>
            <br>
            <span class="login-box-options">
                <%--<asp:Button runat="server" ID="btnlogin" CausesValidation="true" CssClass="btnstyle" Text="Login" OnClick="btnlogin_Click" />--%>
                <asp:ImageButton ImageUrl="App_Themes/Images/login-btn.png" ID="btnSubmit" runat="server"
                    OnClick="btnSubmit_Click" />
                <asp:ImageButton ImageUrl="App_Themes/Images/cancel_btn.png" ID="btnCancel" runat="server"
                    OnClientClick="ClearData();" />
            </span>
        </div>
    </div>
    </form>
</body>
</html>
