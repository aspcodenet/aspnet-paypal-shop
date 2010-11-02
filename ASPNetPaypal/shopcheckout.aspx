<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ShopCheckout.aspx.cs" Inherits="ASPNetPaypal.shopcheckout" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">


<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <title>Checking out...</title>
  <link rel="stylesheet" href="muffin.css" type="text/css" />
</head>
	<BODY onload="document.payment_provider_form.submit()">
				<h2>Please wait while redirecting to Paypal for payment </h2>
		<form name="payment_provider_form" method="post" action="https://www.paypal.com/cgi-bin/webscr">
			<br>
			<br>
			Click here is nothing happens... <input type="image" src="http://www.paypal.com/en_US/i/btn/x-click-but01.gif" name="submit"
				alt="Make payments with PayPal - it's fast, free and secure!"> <input name="business" type="hidden" value="stefan.holmberg@systementor.se">
			<input name="cmd" type="hidden" value="_cart"> <input name="upload" type="hidden" value="1">
			<input name="rm" type="hidden" value="2"> <input name="no_shipping" type="hidden" value="1">
			<input name="no_note" type="hidden" value="1"> <input name="cs" type="hidden" value="0">
			<input name="currency_code" type="hidden" value="USD">
			<asp:PlaceHolder id="plHej" runat="server"></asp:PlaceHolder>
		</form>
				

</body>
</html>
