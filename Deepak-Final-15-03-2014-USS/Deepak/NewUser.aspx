<%@ page language="C#" masterpagefile="~/AppMaster.master" autoeventwireup="true" inherits="NewUser, App_Web_zwikzsdt" title="Deepak" %>

<asp:Content ID="Content1" ContentPlaceHolderID="PageContent" runat="Server">
    <%--<script type ="text/javascript" language ="javascript" >


</script> --%>
    <asp:ScriptManager ID="SMItemMaster" runat="server">
    </asp:ScriptManager>
    <asp:UpdatePanel ID="UPItemMaster" runat="server">
        <ContentTemplate>
            <div id="Page">
             
               <%-- <div class="three-col-title">        
            <div style="text-align: center; margin-top: ">
               
            </div>
        </div>--%>
                <div class="single-col">
                <asp:Label runat="server" ID="lblerr" ForeColor="Red" Width="454px" Height="16px"
                    Style="margin-bottom: 2px"></asp:Label>
                    <div class="ControlsWrapper">
                        <div>
                            <asp:Label ID="lblEmployeeName" runat="server" Text="EmployeeName"></asp:Label>
                            <asp:DropDownList ID="EmployeeName" runat="server" AutoPostBack="True" 
                                OnSelectedIndexChanged="EmployeeName_SelectedIndexChanged">
                                <asp:ListItem Selected="True">--SELECT--</asp:ListItem>
                            </asp:DropDownList>
                        </div>
                        <div>
                            <asp:Label ID="lblUserName" runat="server" Text="UserName"></asp:Label><asp:TextBox
                                ID="UserName" runat="server"></asp:TextBox>
                        </div>
                        <div>
                            <asp:Label ID="lblPassword" runat="server" Text="Password"></asp:Label>
                            <asp:TextBox ID="Password" runat="server" TextMode="Password" CausesValidation="True"></asp:TextBox>
                        </div>
                        <div>
                            <asp:Label ID="lblConfPassword" runat="server" Text="Confirm Password"></asp:Label>
                            <asp:TextBox ID="ConfirmPassword" runat="server" TextMode="Password" CausesValidation="True"></asp:TextBox>
                            <asp:CompareValidator ID="CompareValidator1" ControlToValidate="ConfirmPassword"
                                ControlToCompare="Password" runat="server" ErrorMessage="Enter Correct Password"></asp:CompareValidator>
                        </div>
                        <div>
                            <asp:Label ID="lblSecurityQuestions" runat="server" Text="Security Questions"></asp:Label>
                            <asp:DropDownList  ID="SecuQues" runat="server">
                                <asp:ListItem Selected="True">--SELECT--</asp:ListItem>
                                <asp:ListItem Value="1">What's your first school name?</asp:ListItem>
                                <asp:ListItem Value="2">What's your favourite pass time?</asp:ListItem>
                                <asp:ListItem Value="3">What's your favourite food?</asp:ListItem>
                                <asp:ListItem Value="4">What's the exact time of your birth?</asp:ListItem>
                                <asp:ListItem Value="5">What's your dream car?</asp:ListItem>
                            </asp:DropDownList>
                        </div>
                        <div>
                            <asp:Label ID="lblSecuAns" runat="server" Text="Security Answer"></asp:Label><asp:TextBox
                                ID="SecuAns" runat="server"></asp:TextBox>&nbsp;
                            <%--<asp:RegularExpressionValidator id="RegExpValSecuAns" runat="server" Width="8px" ControlToValidate="SecuAns">*</asp:RegularExpressionValidator>--%></div>
                    </div>
                    <div style="clear: both">
                    </div>
                </div>
                    <div class="btn_spaces">
                        <asp:Button ID="btnSubmit" OnClick="btnSubmit_Click" runat="server" Text="Submit"
                            CssClass="btnstyle"></asp:Button>
                        <asp:Button ID="btnClear" runat="server" Text="Clear" CssClass="btnstyle" OnClick="btnClear_Click">
                        </asp:Button>
                </div>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
