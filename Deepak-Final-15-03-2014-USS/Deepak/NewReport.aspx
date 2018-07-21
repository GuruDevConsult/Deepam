<%@ page language="C#" masterpagefile="~/AppMaster.master" autoeventwireup="true" inherits="NewReport, App_Web_zwikzsdt" title="Deepak Roadways" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<%@ Register assembly="CrystalDecisions.Web, Version=10.5.3700.0, Culture=neutral, PublicKeyToken=692fbea5521e1304" 
namespace="CrystalDecisions.Web" tagprefix="CR" %>

<asp:Content ID="Content1" ContentPlaceHolderID="PageContent" Runat="Server">
<cc1:ToolkitScriptManager ID="Too" runat="server">
    </cc1:ToolkitScriptManager>
<asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
    <div id="Page">
    <script language="javascript">
function PrintMe(DivID) {
var disp_setting="toolbar=yes,location=no,";
disp_setting+="directories=yes,menubar=yes,";
disp_setting+="scrollbars=yes,width=650, height=600, left=100, top=25";
   var content_vlue = document.getElementById(DivID).innerHTML;
   var docprint=window.open("","",disp_setting);
   docprint.document.open();
   docprint.document.write('<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Strict//EN"');
   docprint.document.write('"http://www.w3.org/TR/xhtml1/DTD/xhtml1-strict.dtd">');
   docprint.document.write('<html xmlns="http://www.w3.org/1999/xhtml" xml:lang="en">');
   docprint.document.write('<head><title>My Title</title>');
   docprint.document.write('<style type="text/css">body{ margin:0px;');
   docprint.document.write('font-family:verdana,Arial;color:#000;');
   docprint.document.write('font-family:Verdana, Geneva, sans-serif; font-size:12px;}');
   docprint.document.write('a{color:#000;text-decoration:none;} </style>');
   docprint.document.write('</head><body onLoad="self.print()"><center>');
   docprint.document.write(content_vlue);
   docprint.document.write('</center></body></html>');
   docprint.document.close();
   docprint.focus();
}
</script>
    <div class="single-col">
        <div>
            <asp:Button ID="btnBack" runat="server" Text="Back" CssClass="btnstyle" OnClick="btnBack_Click" />
            <%--<input type="button" name="btnprint" value="Print" onclick="PrintMe('divid')"/>--%>
        </div>
    </div>
</div>
    
    <div id="divid">
<CR:CrystalReportViewer ID="CRViewer" runat="server" AutoDataBind="true" 
        Height="50px" Width="350px" PrintMode="ActiveX" DisplayGroupTree="true" />
    </div>
    </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>

