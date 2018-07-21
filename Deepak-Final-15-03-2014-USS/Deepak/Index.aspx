<%@ page language="C#" autoeventwireup="true" inherits="Index, App_Web_j2s_bpzk" %>

<!DOCTYPE HTML PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <meta http-equiv="Content-Type" content="text/html; charset=ISO-8859-1">
    <title>Deepak Transport</title>

    <script language="Javascript" type="text/javascript">
function capLock(e){
 kc = e.keyCode?e.keyCode:e.which;
 sk = e.shiftKey?e.shiftKey:((kc == 16)?true:false);
 if(((kc >= 65 && kc <= 90) && !sk)||((kc >= 97 && kc <= 122) && sk))
 alert("CAPS LOCK ON");
 // document.getElementById('divMayus').style.visibility = 'visible';
 else
  document.getElementById('divMayus').style.visibility = 'hidden';
}
    </script>

    <link href="App_Themes/login-box.css" rel="stylesheet" type="text/css">
</head>
<body>
    <div id="login">
        <%--<div id="banner">
       <img src="App_Themes/Images/cargo.png" alt="Banner" />
    </div>--%>
        <form id="form1" runat="server">
        <div id="login-box">
            <h2>
                Login</h2>
                <div class="login-box-name" style="margin-top: 20px;">
                <asp:Label runat="server" ID="lblbranches" Text="Branch name" Width="95px" style="margin-left:-10px"></asp:Label>
            </div>
            <div class="login-box-field" style="margin-top: 20px;">
               <asp:DropDownList class="" runat="server" ID="ddlBranchName">
                    <asp:ListItem Text="---SELECT---">SELECT</asp:ListItem>
                </asp:DropDownList>
            </div>
            <%--<div class="login-box-name" style="margin-top: 20px;">
                <asp:Label runat="server" ID="lblbranches" Text="branch name"></asp:Label>
            </div>
            <div class="login-box-field" style="margin-top: 20px;">
                <asp:DropDownList runat="server" ID="ddlbranches">
                    <asp:ListItem Text="select">select</asp:ListItem>
                    <asp:ListItem Text="chennai">chennai</asp:ListItem>
                </asp:DropDownList>
            </div>--%>
            <div class="login-box-name" style="margin-top: 20px;">
                <asp:Label runat="server" ID="lbluserName" Text="User Name"></asp:Label>
            </div>
            <div class="login-box-field" style="margin-top: 20px;">
                <asp:TextBox class="form-login" runat="server" ID="UserName" onkeypress="capLock(event)"></asp:TextBox>
            </div>
            <div class="login-box-name">
                <asp:Label runat="server" ID="Label1" Text="Password"></asp:Label>
            </div>
            <div class="login-box-field">
                <asp:TextBox class="form-login" runat="server" ID="Password" onkeypress="capLock(event)"
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
                <asp:ImageButton ImageUrl="App_Themes/Images/login-btn.png" ID="ImageButton1" runat="server"
                    OnClick="btnlogin_Click" />
                <asp:ImageButton ImageUrl="App_Themes/Images/cancel_btn.png" ID="btnlogin" runat="server"
                    OnClick="btncancel_Click" />
            </span>
        </div>
        </form>
    </div>
</body>
</html>
