<%@ page language="C#" masterpagefile="~/AppMaster.master" autoeventwireup="true" inherits="Company, App_Web_utcvgpzk" title="Deepak Roadways" %>

<asp:Content ID="Content1" ContentPlaceHolderID="PageContent" Runat="Server">
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
<div id="Page">
<div class="two-col">
    <div class="ControlsWrapper">
            <div>
                <asp:Label ID="lblCompanyName" runat="server" Text="Company Name"></asp:Label><asp:TextBox ID="CompanyName"
                runat="server" AutoPostBack="True" OnTextChanged="CompanyName_TextChanged" MaxLength="30" tabindex="1"></asp:TextBox>
            </div>
            <div>
                <asp:Label ID="lblAddress" runat="server" Text="Address"></asp:Label><asp:TextBox ID="Address"
                runat="server" TextMode="MultiLine" tabindex="2"></asp:TextBox>
            </div>
             <div>
                <asp:Label ID="lblCity" runat="server" Text="City" ></asp:Label><asp:TextBox ID="City"
                runat="server" tabindex="3" MaxLength="20"></asp:TextBox>
            </div>
            <div>
                <asp:Label ID="lblPinCode" runat="server" Text="Pin Code"></asp:Label><asp:TextBox ID="PinCode"
                runat="server"  tabindex="4" MaxLength="6"></asp:TextBox>
            </div>
            <div>
                <asp:Label ID="lblPhonePrimary" runat="server" Text="Phone Primary"></asp:Label><asp:TextBox ID="PhonePrimary"
                runat="server" tabindex="5" MaxLength="15"></asp:TextBox>
            </div>
            <div>
                <asp:Label ID="lblPhoneSecondary" runat="server" Text="Phone Secondary"></asp:Label><asp:TextBox ID="PhoneSecondary"
                runat="server" tabindex="6" MaxLength="15"></asp:TextBox>
            </div>
            <div>
                <asp:Label ID="lblMob1" runat="server" Text="Mobile1"></asp:Label><asp:TextBox ID="Mobile1"
                runat="server" tabindex="7" MaxLength="12"></asp:TextBox>
            </div>
    </div>
    <div class="ControlsWrapper">
            <div>
                <asp:Label ID="lblMobile2" runat="server" Text="Mobile2"></asp:Label><asp:TextBox ID="Mobile2"
                runat="server" tabindex="8" MaxLength="12"></asp:TextBox>
            </div>
            <div>
                <asp:Label ID="lblFax" runat="server" Text="Fax"></asp:Label><asp:TextBox ID="Fax"
                runat="server" tabindex="9" MaxLength="20"></asp:TextBox>
            </div>
            <div>
                <asp:Label ID="lblEmail1" runat="server" Text="Email1"  ></asp:Label>
                <asp:TextBox ID="Email1" onchange="return Email_Validation1(this);"
                runat="server" tabindex="10" MaxLength="30"></asp:TextBox>
            </div>
            <div>
                <asp:Label ID="lblEmail2" runat="server" Text="Email2" ></asp:Label><asp:TextBox ID="Email2"
                runat="server" tabindex="11" MaxLength="30" onchange="return Email_Validation1(this);" ></asp:TextBox>
            </div>
             <div>
                <asp:Label ID="lblWebSite" runat="server" Text="Web Site"></asp:Label><asp:TextBox ID="WebSite"
                runat="server" tabindex="12"></asp:TextBox>
            </div>
            <div>
                <asp:Label ID="lblTinNo" runat="server" Text="Tin No"></asp:Label><asp:TextBox ID="TinNo"
                runat="server" tabindex="13" MaxLength="15"></asp:TextBox>
            </div>
            <div>
                <asp:Label ID="lblCstNo" runat="server" Text="CstNo"></asp:Label><asp:TextBox ID="CstNo"
                runat="server" tabindex="14" MaxLength="15"></asp:TextBox>
            </div>
             <div>
                <asp:Label ID="lblAreaCode" runat="server" Text="Area Code"></asp:Label><asp:TextBox ID="AreaCode"
                runat="server" tabindex="15" MaxLength="15"></asp:TextBox>
            </div>
    </div>
</div>
    <div class="ButtonsWrapper two-col-button">
        <div class="btn_spaces">
            
            <asp:Button ID="btnSave" runat="server" Text="Save" TabIndex="16" CssClass="btnstyle" OnClick="btnSave_Click"/>
            <asp:Button ID="btnDelete" runat="server" Text="Delete" TabIndex="17" CssClass="btnstyle" OnClick="btnDelete_Click" visible="false"/>
            <asp:Button ID="btnClear" runat="server" Text="Clear" TabIndex="18" CssClass="btnstyle" CausesValidation="False" OnClick="btnClear_Click" visible="false"/>
        </div>
    </div>

</div>
<asp:HiddenField ID="hidCompanyID" runat="server" />
            <asp:HiddenField ID="hidAddID" runat="server" />
</asp:Content>

