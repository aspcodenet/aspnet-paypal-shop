using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

namespace ASPNetPaypal
{
    public partial class shopcheckout : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            int nCount = 1;
            string sAdd;


            foreach (ObjClasses.ShoppingCartItem oItem in ObjClasses.ShoppingCart.GetCurrentUsersCart)
            {
                //Rabatt
                if (oItem.PerPrice < 0)
                    continue;

                string sTxt = oItem.PrArticle.PaypalID;
                sTxt += " " + oItem.PrArticle.Name;

                //Apply discount
                double dPerPrice = oItem.PerPrice;

                double dTotalPrice = dPerPrice * oItem.Count;

                sAdd = "<input name=\"item_name_" + nCount.ToString() + "\" type=\"hidden\" value=\"" + sTxt + "\"> ";
                plHej.Controls.Add(new System.Web.UI.LiteralControl(sAdd));
                sAdd = "<input name=\"item_number_" + nCount.ToString() + "\" type=\"hidden\" value=\"" + oItem.PrArticle.PaypalID + "\"> ";
                plHej.Controls.Add(new System.Web.UI.LiteralControl(sAdd));

                sAdd = "<input name=\"amount_" + nCount.ToString() + "\" type=\"hidden\" value=\"" + dPerPrice.ToString("0.00").Replace(",", ".") + "\"> ";
                plHej.Controls.Add(new System.Web.UI.LiteralControl(sAdd));
                sAdd = "<input name=\"quantity_" + nCount.ToString() + "\" type=\"hidden\" value=\"" + (oItem.Count).ToString() + "\"> ";
                plHej.Controls.Add(new System.Web.UI.LiteralControl(sAdd));
                nCount++;
            }
            nCount--;
            sAdd = "<input name=\"num_cart_items\" type=\"hidden\" value=\"" + nCount.ToString() + "\"> ";
            plHej.Controls.Add(new System.Web.UI.LiteralControl(sAdd));


        }

    }
}
