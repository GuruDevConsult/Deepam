//JScript File

function CheckRequired(obj) {
            var txt = document.getElementById(obj).value;
            if (txt == "") {
                alert("Required Field");
            }
        }


function CheckItem(res1,res2)
{
     var val1 = document.getElementById(res1).value;
     var val2 = document.getElementById(res2).value;
         if(val1 =="" && val2 =="")
          {
            alert('You must enter either Color or GSM');
            document.getElementById(res1).focus();
            return(false);
          }
          else
          {
            return(true);
          }
}



function Form_Validator(id1,id2,id3,id4,id5,id6,id7,id8,id9,id10,id11,id12,id13,id14,id15,id16,id17,id18,id19,id20,id21,id22,id23,id24)
{
 //debugger;
  var Numberval='';
  var Dateval='';
  var Sizeval='';
  var Qtyval='';
  var bit;
  var ControlID='';
  var ContentID='ctl00_PageContent_';
   ControlID=id1.substring(0,3);
   bit=CheckDropText(ControlID,ContentID,id1);
   if(bit==false)
   { 
    return(false);
   }
   else if(bit==true)
   {
    ControlID=id2.substring(0,3);
    bit=CheckDropText(ControlID,ContentID,id2);
   }
   if(bit==false){ return(false);}
   else if(bit==true)
   {  
   ControlID=id3.substring(0,3);
   bit=CheckDropText(ControlID,ContentID,id3);
   }
   if(bit==false){ return(false); }
   else if(bit==true)
   { 
       ControlID=id4.substring(0,3);
       bit=CheckDropText(ControlID,ContentID,id4);
   }
      if(bit==false){ return(false); }
       else(bit==true)
       { 
         ControlID=id5.substring(0,3);
         bit=CheckDropText(ControlID,ContentID,id5);
       }
       if(bit==false){ return(false); }
       else(bit==true)
       { 
         ControlID=id6.substring(0,3);
         bit=CheckDropText(ControlID,ContentID,id6);
       }
       if(bit==false){ return(false); }
       else(bit==true)
       { 
         ControlID=id7.substring(0,3);
         bit=CheckDropText(ControlID,ContentID,id7);
       }
       if(bit==false){ return(false); }
       else(bit==true)
       { 
         ControlID=id8.substring(0,3);
        bit= CheckDropText(ControlID,ContentID,id8);
       }
       if(bit==false){ return(false); }
       else(bit==true)
       { 
         ControlID=id9.substring(0,3);
         bit=CheckDropText(ControlID,ContentID,id9);
       }
       if(bit==false){ return(false); }
       else(bit==true)
       { 
         ControlID=id10.substring(0,3);
         bit=CheckDropText(ControlID,ContentID,id10);
       }
       if(bit==false){ return(false); }
       else(bit==true)
       { 
         ControlID=id11.substring(0,3);
         bit=CheckDropText(ControlID,ContentID,id11);
       }
       if(bit==false){ return(false); }
       else(bit==true)
       { 
       ControlID=id12.substring(0,3);
       bit = CheckDropText(ControlID,ContentID,id12);
       }
       
       if(bit==false){ return(false); }
       else(bit==true)
       { 
       ControlID=id13.substring(0,3);
       bit = CheckDropText(ControlID,ContentID,id13);
       }
       if(bit==false){ return(false); }
       else(bit==true)
       { 
       ControlID=id14.substring(0,3);
       bit = CheckDropText(ControlID,ContentID,id14);
       }
       
       if(bit==false){ return(false); }
       else(bit==true)
       { 
       ControlID=id15.substring(0,3);
       bit = CheckDropText(ControlID,ContentID,id15);
       }
       
       if(bit==false){ return(false); }
       else(bit==true)
       { 
       ControlID=id16.substring(0,3);
       bit = CheckDropText(ControlID,ContentID,id16);
       }
       
       if(bit==false){ return(false); }
       else(bit==true)
       { 
       ControlID=id17.substring(0,3);
       bit = CheckDropText(ControlID,ContentID,id17);
       }
       
       if(bit==false){ return(false); }
       else(bit==true)
       { 
       ControlID=id18.substring(0,3);
       bit = CheckDropText(ControlID,ContentID,id18);
       }
       
       if(bit==false){ return(false); }
       else(bit==true)
       { 
       ControlID=id19.substring(0,3);
       bit = CheckDropText(ControlID,ContentID,id19);
       }
       
       if(bit==false){ return(false); }
       else(bit==true)
       { 
       ControlID=id20.substring(0,3);
       bit = CheckDropText(ControlID,ContentID,id20);
       }
       
       if(bit==false){ return(false); }
       else(bit==true)
       { 
       ControlID=id21.substring(0,3);
       bit = CheckDropText(ControlID,ContentID,id21);
       }
       
       if(bit==false){ return(false); }
       else(bit==true)
       { 
       ControlID=id22.substring(0,3);
       bit = CheckDropText(ControlID,ContentID,id22);
       }
       
       if(bit==false){ return(false); }
       else(bit==true)
       { 
       ControlID=id23.substring(0,3);
       bit = CheckDropText(ControlID,ContentID,id23);
       }
       
       if(bit==false){ return(false); }
       else(bit==true)
       { 
       ControlID=id24.substring(0,3);
       bit = CheckDropText(ControlID,ContentID,id24);
       }
       
       if(bit==false){ return(false); }
       else(bit==true)
       {
        return(true);
       }
 }

 function CheckDropText(ControlID,ContentID,id)
 {
  if(ControlID=="ddl")
   {
     var Targetctr=id.substring(3,id.length);
     val1 = document.getElementById(ContentID+Targetctr).value;
     if (val1 == "--SELECT--" && (document.getElementById(ContentID + Targetctr).disabled==false))
     {
       
        var strMsg='You must select the'+' '+ Targetctr
        alert(strMsg);
        document.getElementById(ContentID+Targetctr).focus();
        return(false);
     }
     else
     {
      return(true);
     }
  }
  else if(ControlID=="txt")
   {
   var strMsg='';
    var Targetctr=id.substring(3,id.length);
     val1 = document.getElementById(ContentID + Targetctr).value;
   //var c =document.getElementById(ContentID + Targetctr).disabled;
     if (val1 == "" && (document.getElementById(ContentID + Targetctr).disabled==false))
     {
        if(Targetctr=="txtTotalAmount")
        {
          strMsg='You must select'+' '+ 'Description Details'
        }
        else
        {
         strMsg='You must enter'+' '+ Targetctr
        }
        alert(strMsg);
        document.getElementById(ContentID + Targetctr).focus();
        return(false);
     }
     else
     {
      return(true);
     }
  }
 }

function CompletedNumeric_Validator(isMandatory,obj)
{
//debugger;
         if(obj.value=='')
         {
                if(isMandatory)
                {
                   obj.focus();
                }
         }
         else
         {
                 //validate numeric up to 2 decimal points only
                 if(!(/^\d+(\.\d{1,2})?$/).test(obj.value))
                 {
                      var val =obj.value;
                      var newval =val.substring(0, val.length-1);
                      obj.value=newval;
                      obj.focus();
                  }
         }
}
function Numeric_Validator(id)
{
 // debugger;
    var checkOK = "0123456789";
    //var checkStr = document.getElementById("ctl00_PageContent_Qty").value;
      var checkStr=document.getElementById(id).value;
    var allValid = true;
    var allNum = "";
    for (i = 0;  i < checkStr.length;  i++)
    {
        ch = checkStr.charAt(i);
        for (j = 0;  j < checkOK.length;  j++)
        if (ch == checkOK.charAt(j))
        break;
        if (j == checkOK.length)
        {
            allValid = false;
            break;
        }
        if (ch != ",")
        allNum += ch;
    }
    if (!allValid)
    {
        alert("Please enter only digit characters in the \"Numbers\" field.");
       // document.getElementById("ctl00_PageContent_Qty").focus();
        return(false);
    }
}

function Decimal_Validator(id)
{   
//debugger;

    var checkOK = "0123456789.";
    var checkStr = document.getElementById(id).value;
    var allValid = true;
    var decPoints = 0;
    var allNum = "";
    var dotcount=0;
    for (i = 0;  i < checkStr.length;  i++)
    {
        ch = checkStr.charAt(i);
        for (j = 0;  j < checkOK.length;  j++)
        if (ch == checkOK.charAt(j))
        break;
        if (ch == "." && dotcount==0)
        {
          dotcount=1;
        }
        else if(ch == "." && dotcount==1)
        {
           allValid = false;
           break;
            if (!allValid)
            {
            alert("Please enter only decimal characters in the \"DecimalText\" field.");
            document.getElementById(id).focus();
            return (false);
            }
        }
        if (j == checkOK.length)
        {
         allValid = false;
         break;
        }
        
         allNum += ch;
       }
        if (!allValid)
        {
        alert("Please enter only decimal characters in the \"DecimalText\" field.");
        document.getElementById(id).focus();
        return (false);
    }
}


 function CheckNumeric(obj)
 {
 //debugger;
   var Qty;
   var Amount;                                                           
 //test regular expression regarding numeric format
if (!(obj.value).match(/^\d+(\.\d*)?$/))
{
    obj.value= obj.value.replace(/[^0-9.]/g,'');
    document.getElementById("ctl00_PageContent_PurchaseAmount").value='';
                                if(document.all)
                                        event.returnValue = false;
                                else
                                        return false;
}
  else
  {
        var strEnteredText;
        strEnteredText=obj.value;
 
        if(strEnteredText.indexOf('.')!=-1)
        {
                if((strEnteredText.split("."))[1].length>2)
                {
                        obj.value=strEnteredText.substring(0,strEnteredText.length-1);
                }
                 Qty=document.getElementById("ctl00_PageContent_Weight").value;
                 Amount=strEnteredText*Qty;
                                
                  if (!isNaN(Amount)) 
                     {
			           var n = round(Amount)+"";
			              if (n.indexOf(".")==-1)
			                 {
				                n += ".00";
			                 }
			                    while(n.length-n.indexOf(".")<3) 
			                    {
				                     n += "0";
			                    }
			                            
		              }
                     document.getElementById("ctl00_PageContent_PurchaseAmount").value=n;
        }
      else
        {
          Qty=document.getElementById("ctl00_PageContent_Weight").value;
          Amount=strEnteredText*Qty;
          //Amount.toFixed(2)
          if (!isNaN(Amount)) 
          {
                var n = round(Amount)+"";
                if (n.indexOf(".")==-1)
                {
                    n += ".00";
                }
                while(n.length-n.indexOf(".")<3) 
                {
                    n += "0";
                }
                
            }
          document.getElementById("ctl00_PageContent_PurchaseAmount").value=n;
        }
  }
}
function CheckPermittedCharacters(id,event)
{
 //debugger;

  var strCode;
  var Qty;
  var Amount;

  strCode=document.all?event.keyCode:event.which;
  var objControl=document.getElementById(id);
  var strEntered=objControl.value;
  var strNewChar=String.fromCharCode(strCode);
  var strNew=String.fromCharCode(strCode);
  //allow characters: 0-9 and .
  if((strCode >= 48 && strCode < 58) || (strCode == 46))
  {
        if(strNew==".")
        {
         if(strEntered.indexOf(".")!=-1)
                {
                                if(document.all)
                                        event.returnValue = false;
                                else
                                        return false;
                                       
                }
        }
        
        if(strCode==46)
        {
                if(strEntered.indexOf(".")!=-1)
                {
                                if(document.all)
                                        event.returnValue = false;
                                else
                                       // return false;
                                       event.returnValue = false;
                }
        }
        else
        {
                if(strEntered.indexOf(".")!=-1)
                {
                                    
                             event.returnValue = true;
                                     
                        if((strEntered.split(".")[1] + strNewChar).length>2)
                        {
                                if(document.all)
                                         event.returnValue = false;
                                else
                                        //return false;
                                        event.returnValue = false;
                        }
                        if(event.returnValue==true)
                        {
                     Qty=document.getElementById("ctl00_PageContent_Weight").value;
                      Amount=(strEntered + strNewChar)*Qty;
                      //Amount.toFixed(2)
                       if (!isNaN(Amount)) 
                      {
                            var n = round(Amount)+"";
                            if (n.indexOf(".")==-1)
                            {
                                n += ".00";
                            }
                            while(n.length-n.indexOf(".")<3) 
                            {
                                n += "0";
                            }
                            
                        }
                      document.getElementById("ctl00_PageContent_PurchaseAmount").value=n;
                         }
                }
                else
                {
                        if(strEntered=="0")
                        {
                                if(strCode!=46)
                                {
                                        if(document.all)
                                                event.returnValue = false;
                                        else
                                                return false;
                                }
                        }
                        else if(strEntered=="")
                        {
                          Qty=document.getElementById("ctl00_PageContent_Weight").value;
                          Amount=strNewChar*Qty;
                          //Amount.toFixed(2)
                          if (!isNaN(Amount)) 
                          {
                                var n = round(Amount)+"";
                                if (n.indexOf(".")==-1)
                                {
                                    n += ".00";
                                }
                                while(n.length-n.indexOf(".")<3) 
                                {
                                    n += "0";
                                }
                                
                            }
                          document.getElementById("ctl00_PageContent_PurchaseAmount").value=n;
                          }
                                                                
                else 
                {
                          Qty=document.getElementById("ctl00_PageContent_Weight").value;
                          Amount=(strEntered + strNewChar)*Qty;
                          //Amount.toFixed(2)
                          if (!isNaN(Amount)) 
                          {
                                var n = round(Amount)+"";
                                if (n.indexOf(".")==-1)
                                {
                                    n += ".00";
                                }
                                while(n.length-n.indexOf(".")<3) 
                                {
                                    n += "0";
                                }
                                
                            }
                          document.getElementById("ctl00_PageContent_PurchaseAmount").value=n;
                }           
                }
                                                              
        }
  }
  else
  {
                        if(document.all)
                                event.returnValue = false;
                        else
                                return false;
        }
}
 function round(n) 
 {
   // debugger;
	return Math.round(n*100+((n*1000)%10>4?1:0))/100;
 }
function CheckCompletedNumeric(isMandatory,obj)
{
//debugger;
         if(obj.value==''){
                if(isMandatory){
                        //alert('Please fill in the value!');
                       obj.focus();
                }
         }else{
                 //validate numeric up to 2 decimal points only
                 if(!(/^\d+(\.\d{1,2})?$/).test(obj.value))
                 {
               var vald=  obj.value;
               // var vald =document.getElementById("ctl00_PageContent_Rate").value;
                     //  alert('Please fill in numeric format only!');
                        obj.focus();
                  }
         }
}
function ConfirmDelete()
{
if(confirm('Are you sure to delete this record?')==true)
    return true;
else
    return false;    
    74
}
function SaveClicked(tag)
 {
  debugger;
  var temp;
  temp = document.getElementById('UserName').value;
  var BrowseQryStr = "ForgotPassword.aspx?User=" + temp;
  var result =window.showModalDialog(BrowseQryStr,"newwin","dialogWidth:1000px; dialogHeight:500px; dialoglocation:no; dialogtoolbar:no; dialogscrollbars:no; resizable:off;  status:off; dialogmenubar:no;");
}
function ReturnMethod()
{
 window.returnValue ='';
 Exit();
}
function Exit()
{
    debugger;
    if(navigator.appName=="Microsoft Internet Explorer") 
     {
           this.focus();self.opener = this;self.close(); 
     }
    else 
        { 
            window.open('','_parent',''); 
            window.close(); 
        }
    return false;
}


function isValidAlpha()
{

	var c=	event.keyCode;

	event.keyCode=(!( (c>=65 && c<=90) || (c==46) || (c>=97 && c<=122) || (c==32)))?0:event.keyCode;

}
function isAlphaNum(keyCode) 
        {
            if(keyCode==16) 
                isShift = true;
            return ((keyCode >= 65 && keyCode <= 90) || ((keyCode == 8 || keyCode == 32 || keyCode == 190 || keyCode == 189 || keyCode == 191 || keyCode == 109 || keyCode == 111 || (keyCode >= 48 && keyCode <= 57) || (keyCode >= 96 && keyCode <= 105)) && isShift==false)) 
        }

function isNumberKey(evt)
{
var charCode = (evt.which) ? evt.which : event.keyCode
if (charCode != 46 && charCode > 31 
&& (charCode < 48 || charCode > 57))
return false;

return true;
}

function alphanumeric_only(e)
{
    var keycode;
    if (window.event) keycode = window.event.keyCode;else if (event) keycode = event.keyCode;
    else if (e) keycode = e.which;else return true;if( (keycode >= 47 && keycode <= 57) || (keycode >= 65 && keycode <= 90) || (keycode >= 97 && keycode <= 122) || keycode == 32)
    {
        return true;
    }
    else
    {
        return false;
    }
        return true;
}