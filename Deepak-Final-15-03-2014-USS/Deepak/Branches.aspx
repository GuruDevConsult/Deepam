<%@ page language="C#" masterpagefile="~/AppMaster.master" autoeventwireup="true" inherits="Branches, App_Web_zwikzsdt" title="Untitled Page" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="PageContent" runat="Server">
    <asp:ToolkitScriptManager ID="toolkitscriptmanager1" runat="server">
    </asp:ToolkitScriptManager>
    <div id="Page">
        <div class="three-col">
        <asp:Label ID="lblmsg" runat="server" Text="" ForeColor ="Red"></asp:Label>
            <div class="ControlsWrapper">
                <div>
                    <asp:Label ID="lblBranchName" runat="server" Text="Branch Name"></asp:Label>
                    <asp:TextBox ID="txtBranchname" runat="server" AutoPostBack="true" 
                        ontextchanged="txtBranchname_TextChanged"></asp:TextBox>
                </div>
                <div>
                    <asp:Label ID="lblusername" runat="server" Text="UserName"></asp:Label>
                    <asp:TextBox ID="txtusername" runat="server"></asp:TextBox>
                </div>
            </div>
            <div class="ControlsWrapper">
                <div>
                    <asp:Label ID="lblPwd" runat="server" Text="Password"></asp:Label>
                    <asp:TextBox ID="txtpwd" runat="server"></asp:TextBox>
                </div>
                <div>
                    <asp:Label ID="lblConfpwd" runat="server" Text="Confirm Password"></asp:Label>
                    <asp:TextBox ID="ConfirmPassword" runat="server"></asp:TextBox>
                    <asp:HiddenField ID="HiddenField1" runat="server" />
                </div>
            </div>
            <div class="ControlsWrapper">
                <div>
                    <asp:Label ID="Label1" runat="server" Text="Security Questions"></asp:Label>
                    <asp:DropDownList ID="SecuQues" runat="server">
                        <asp:ListItem Value="0">--SELECT--</asp:ListItem>
                        <asp:ListItem Value="1">What's your first school name?</asp:ListItem>
                        <asp:ListItem Value="2">What's your favourite pass time?</asp:ListItem>
                        <asp:ListItem Value="3">What's your favourite food?</asp:ListItem>
                        <asp:ListItem Value="4">What's the exact time of your birth?</asp:ListItem>
                        <asp:ListItem Value="5">What's your dream car?</asp:ListItem>
                    </asp:DropDownList>
                </div>
                <div>
                    <asp:Label ID="lblanswer" runat="server" Text="Answer"></asp:Label>
                    <asp:TextBox ID="SecuAns" runat="server"></asp:TextBox>
                </div>
            </div>
        </div>
        <div class="three-col-button">
            <div class="btn_spaces">
                <asp:Button ID="btnSave" runat="server" CssClass="btnstyle" Text="Save" 
                    onclick="btnSave_Click" />
                <asp:Button ID="btnView" runat="server" CssClass="btnstyle" Text="View" />
                <asp:Button ID="btnClear" runat="server" CssClass="btnstyle" Text="Clear" 
                    onclick="btnClear_Click" />
                <asp:Button ID="btnDelete" runat="server" CssClass="btnstyle" Text="Delete" />
            </div>
        </div>
        <div class="gridcol">
            
            <asp:GridView ID="GridView1" runat="server">
            </asp:GridView>
            
        </div>
    </div>
</asp:Content>
