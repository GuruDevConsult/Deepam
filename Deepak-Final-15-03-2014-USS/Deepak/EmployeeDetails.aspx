<%@ page language="C#" masterpagefile="~/AppMaster.master" autoeventwireup="true" inherits="EmployeeDetails, App_Web_utcvgpzk" title="Deepak Roadways" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="PageContent" runat="Server">

    <script type="text/javascript" language="javascript">
  function Email_Validation1(txt) 
{
        var reg = /^([A-Za-z0-9_\-\.])+\@([A-Za-z0-9_\-\.])+\.([A-Za-z]{2,4})$/;
        var email = txt.value;

//        if (!email || 0 == email.length)
//         {
//            alert('please enter email');          
//        }
      if (reg.test(email) == false) 
      {
        
            alert('Invalid Email Id');
            return false;
        }
        else {

            return true;
        }
    }
    </script>

    <cc1:ToolkitScriptManager ID="Too" runat="server">
    </cc1:ToolkitScriptManager>
    <%--
<asp:ScriptManager id="ScriptManager1" runat="server"></asp:ScriptManager>
--%><asp:UpdatePanel ID="UpdatePanel1" runat="server">
    <ContentTemplate>
        <div id="Page">
            <div class="two-col">
                <cc1:AutoCompleteExtender ID="AutoHome" runat="server" MinimumPrefixLength="1" ServiceMethod="GetCompletionHome"
                    TargetControlID="EmpName" CompletionInterval="1">
                </cc1:AutoCompleteExtender>
                <asp:Label ID="lblmasg" runat="server" ForeColor="Red" Text=""></asp:Label>
                <div class="ControlsWrapper1">
                    <div>
                        <asp:Label runat="server" ID="lblEmpCode" Text="Employee Code"></asp:Label><asp:TextBox
                            runat="server" ID="EmpCode" AutoPostBack="True" OnTextChanged="EmpCode_TextChanged"
                            MaxLength="6"></asp:TextBox>
                    </div>
                    <div>
                        <asp:Label runat="server" ID="lblEmpName" Text="Employee Name"></asp:Label><asp:TextBox
                            runat="server" onKeyPress="isValidAlpha(this)" ID="EmpName" MaxLength="20"></asp:TextBox></div>
                    <div>
                        <asp:Label runat="server" ID="lblFatherName" Text="Father Name"></asp:Label><asp:TextBox
                            runat="server" onKeyPress="isValidAlpha(this)" ID="FatherName" MaxLength="20"></asp:TextBox></div>
                    <div>
                        <asp:Label runat="server" ID="lblMotherName" Text="Mother Name"></asp:Label><asp:TextBox
                            runat="server" onKeyPress="isValidAlpha(this)" ID="MotherName" MaxLength="20"></asp:TextBox></div>
                    <div>
                        <asp:Label runat="server" ID="lblGender" Text="Gender"></asp:Label><asp:DropDownList
                            runat="server" ID="Gender">
                            <asp:ListItem>--SELECT--</asp:ListItem>
                            <asp:ListItem>Male</asp:ListItem>
                            <asp:ListItem>Female</asp:ListItem>
                        </asp:DropDownList>
                    </div>
                    <div>
                        <asp:Label runat="server" ID="lblDoB" Text="Date of Birth"></asp:Label>
                        <asp:TextBox ID="DoB" runat="server" AutoPostBack="True" OnTextChanged="DoB_TextChanged"></asp:TextBox>
                        <%--<ajaxToolkit:CalendarExtender ID="defaultCalendarExtender" runat="server" TargetControlID="DoB" />--%>
                        <cc1:CalendarExtender ID="CalendarExtender1" runat="server" TargetControlID="DoB"
                            Format="dd/MM/yyyy" CssClass="cal_Theme">
                        </cc1:CalendarExtender>
                    </div>
                    <div>
                        <asp:Label runat="server" ID="lblAddress" Text="Address"></asp:Label><asp:TextBox
                            runat="server" ID="Address" TextMode="MultiLine" Columns="16" Rows="2"></asp:TextBox></div>
                </div>
                <div class="ControlsWrapper1">
                    <div>
                        <asp:Label runat="server" ID="lblCity" Text="City"></asp:Label>
                        <asp:TextBox ID="City" runat="server" onKeyPress="isValidAlpha(this)" MaxLength="12"></asp:TextBox></div>
                    <div>
                        <asp:Label runat="server" ID="lblPinCode" Text="PinCode"></asp:Label><asp:TextBox
                            runat="server" ID="PinCode" onKeyPress="return isNumberKey(event)" MaxLength="6"></asp:TextBox></div>
                    <div>
                        <asp:Label runat="server" ID="lblPhone" Text="Phone"></asp:Label><asp:TextBox runat="server"
                            ID="Phone" onKeyPress="return isNumberKey(event)" MaxLength="12"></asp:TextBox></div>
                    <div>
                        <asp:Label runat="server" ID="lblMobile" Text="Mobile"></asp:Label><asp:TextBox runat="server"
                            ID="Mobile" onKeyPress="return isNumberKey(event)" MaxLength="12"></asp:TextBox></div>
                    <div>
                        <asp:Label runat="server" ID="lblEmailId" Text="EmailId"></asp:Label><asp:TextBox
                            runat="server" ID="Email" onchange="return Email_Validation1(this);"></asp:TextBox></div>
                    <div>
                        <asp:Label runat="server" ID="lblQualification" Text="Qualification"></asp:Label><asp:TextBox
                            runat="server" ID="Qualification" onKeyPress="isValidAlpha(this)" MaxLength="20"></asp:TextBox></div>
                    <div>
                        <asp:Label runat="server" ID="lblDesignation" Text="Designation"></asp:Label><asp:TextBox
                            runat="server" ID="Designation" onKeyPress="isValidAlpha(this)" MaxLength="12"></asp:TextBox></div>
                    <div>
                        <asp:Label runat="server" ID="lblDOJ" Text="Date of Join"></asp:Label>
                        <asp:TextBox ID="DOJ" runat="server" ToolTip="DOJ" AutoPostBack="True" OnTextChanged="DOJ_TextChanged"></asp:TextBox>
                        <cc1:CalendarExtender ID="CalendarExtender2" runat="server" TargetControlID="DOJ"
                            Format="dd/MM/yyyy" CssClass="cal_Theme">
                        </cc1:CalendarExtender>
                    </div>
                </div>
            </div>
            <div class="ButtonsWrapper two-col-button">
                <div class="btn_spaces">
                    <asp:Button runat="server" ID="btnSave" CssClass="btnstyle" Text="Save" OnClick="btnSave_Click" />
                    <asp:Button runat="server" ID="btnClear" CssClass="btnstyle" Text="Clear" OnClick="btnClear_Click" />
                    <asp:Button runat="server" ID="btnDelete" CssClass="btnstyle" Text="Delete" OnClientClick="return ConfirmDelete();"
                        OnClick="btnDelete_Click" /></div>
            </div>
            <div>
                <asp:HiddenField ID="hidEmpID" runat="server" />
                <asp:HiddenField ID="hidAddID" runat="server" />
            </div>
        </div>
    </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
