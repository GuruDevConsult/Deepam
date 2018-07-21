<%@ page language="C#" masterpagefile="~/AppMaster.master" autoeventwireup="true" inherits="TaxDetails, App_Web_utcvgpzk" title="Chennai" %>

<asp:Content ID="Content1" ContentPlaceHolderID="PageContent" Runat="Server">

<div id="Page_Single">
   <div class="two-col">
              <div class="ControlsWrapper">
                  <div>
                      <asp:Label ID="lblTaxName" runat="server" Text="Tax Name"></asp:Label><asp:TextBox ID="TaxName"
                          runat="server" TabIndex="1"></asp:TextBox>
                  </div>
                 <div>
                      <asp:Label ID="lblTaxPercentage" runat="server" Text="Tax Percentage"></asp:Label><asp:TextBox ID="TaxPercentage"
                          runat="server" TabIndex="2"></asp:TextBox>
                 </div>
             </div>
              
              <div class="ControlsWrapper">
                <div>
                      <asp:Label ID="lblTaxInfo1" runat="server" Text="Tax Info1"></asp:Label><asp:TextBox ID="TaxInfo1"
                          runat="server" TabIndex="3"></asp:TextBox>
                 </div>
                 <div>
                      <asp:Label ID="lblTaxInfo2" runat="server" Text="Tax Info2"></asp:Label><asp:TextBox ID="TaxInfo2"
                          runat="server" TabIndex="4"></asp:TextBox>
                 </div>
              </div>
           </div>
              <div class="ButtonsWrapper two-col-button">
        <div class="btn_spaces">
            <asp:Button ID="btnSave" runat="server" Text="Save" CssClass="btnstyle" OnClick="btnSave_Click1" />
            <asp:Button ID="btnDelete" runat="server" Text="Delete" CausesValidation="false" CssClass="btnstyle" OnClick="btnDelete_Click" OnClientClick="return ConfirmDelete();" />
            <asp:Button ID="btnClear" runat="server" Text="Clear" CssClass="btnstyle" CausesValidation="false" OnClick="btnClear_Click" />
            <br />
            <asp:HiddenField ID="hidTaxID" runat="server" />
        </div>
        </div>  
     </div> 

            <div class="gridcol">
                <asp:GridView ID="GridTax" runat="server" CellPadding="3" OnRowCreated="GridTax_RowCreated" 
                OnSelectedIndexChanging="GridTax_SelectedIndexChanging" BackColor="#DEBA84" 
                BorderColor="#DEBA84" BorderStyle="None" BorderWidth="1px" CellSpacing="2">
                <Columns>
                    <asp:CommandField HeaderText="Select" ShowSelectButton="True" />
                </Columns>
                <FooterStyle BackColor="#F7DFB5" ForeColor="#003f81" />
                <RowStyle BackColor="#e9edf2" ForeColor="#003f81" />
                <SelectedRowStyle BackColor="#e9edf2" Font-Bold="True" ForeColor="#003f81" />
                <PagerStyle ForeColor="#8C4510" HorizontalAlign="Center" />
                <HeaderStyle BackColor="#dae9f3" Font-Bold="True" ForeColor="White" />
                </asp:GridView>
            </div>
</asp:Content>

