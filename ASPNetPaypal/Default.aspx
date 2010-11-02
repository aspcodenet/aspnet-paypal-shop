<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="ASPNetPaypal._Default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>ASPCode.net demo shop</title>
  <link rel="stylesheet" href="css/muffin.css" type="text/css" />
    
</head>
<body>
<a href="http://www.aspcode.net">Created by ASPCode.net</a>
    <form id="form1" runat="server">
    <div>
				<h2>YOUR SHOPPING CART</h2>
				<p>
<asp:repeater id="plCart" Runat="server" OnItemDataBound="plCart_ItemDataBound" OnItemCreated="plCart_ItemCreated">				
<HeaderTemplate>
<TABLE>
<THEAD>
<TR>
<TH scope=col>Product</TH>
<TH scope=col>Price</TH>
<TH scope=col>Quantity</TH>
<TH scope=col>Subtotal</TH></TR></THEAD>
<TBODY>
</HeaderTemplate>
<ItemTemplate>
<TR>
<TH id=TH3 scope=row><asp:Literal ID="hlCountAndName" runat="server"></asp:Literal></TH>
<TD><asp:Literal ID="Hyperlink1" runat="server"></asp:Literal></TD>
<TD><asp:DropDownList ID="ddlCount" Runat="server" AutoPostBack="True"></asp:DropDownList></TD>
<TD><asp:Literal ID="hlTotPrice" runat="server"></asp:Literal></TD></TR>
</ItemTemplate>
<FooterTemplate>
</TBODY>
			<tfoot>
<TH scope=col></TH>
<TH scope=col></TH>
<TH scope=col>TOTAL TO PAY</TH>
<TH scope=col><asp:HyperLink ID="Hyperlink2" runat="server"></asp:HyperLink></TH></TR>			</tfoot>
</TABLE>                

</FooterTemplate>
</asp:repeater>
				
				</p>

<p><asp:button id="btnPay" Runat="server" CssClass="button" Text="Click here to place your order"
	Font-Bold="True" OnClick="btnPay_Click"></asp:button></p>				


				<h2>AVAILABLE PRODUCTS...</h2>
				
<asp:Repeater ID="repArt" runat="server" OnItemDataBound="repArt_ItemDataBound">
<HeaderTemplate>
<TABLE>
<THEAD>
<TR>
<TH scope=col>Software</TH>
<TH scope=col>Product ID</TH>
<TH scope=col>Price</TH>
<TH scope=col>Purchase</TH></TR></THEAD>
<TBODY>

</HeaderTemplate>
<ItemTemplate>
<TR>
<TH id=r82 scope=row><asp:Literal id="litName" runat="server"></asp:Literal></TH>
<TD><asp:Literal id="litProductID" runat="server"></asp:Literal></TD>
<TD><asp:Literal id="litPrice" runat="server"></asp:Literal></TD>
<TD><asp:HyperLink id="hlAddToCart" runat="server">Add to cart</asp:HyperLink></TD></TR>

</ItemTemplate>
<FooterTemplate>
</TBODY></TABLE>                
</FooterTemplate>
</asp:Repeater>

    
    </div>
    </form>
</body>
</html>
