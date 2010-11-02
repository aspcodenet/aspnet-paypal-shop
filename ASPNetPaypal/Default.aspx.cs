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
    public partial class _Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Request["addcart"] != null)
                {
                    string sWhat = Request["addcart"];
                    ObjClasses.Article oArt = ObjClasses.ArticleCollection.Instance().Find(sWhat);
                    if (oArt != null)
                    {
                        ObjClasses.ShoppingCart.GetCurrentUsersCart.AddCount(oArt.Id, 1);
                        Response.Redirect("default.aspx", true);
                    }
                }

                //Cart
                plCart.DataSource = ObjClasses.ShoppingCart.GetCurrentUsersCart;
                plCart.DataBind();

                if ( ObjClasses.ShoppingCart.GetCurrentUsersCart.Count == 0 )
                    btnPay.Visible = false;
                else
                    btnPay.Visible = true;


                //Setup products...
                repArt.DataSource = ObjClasses.ArticleCollection.Instance();
                repArt.DataBind();
            }
        }

        protected void plCart_ItemCreated(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                DropDownList ddlList = e.Item.FindControl("ddlCount") as DropDownList;
                for (int i = 0; i < 20; i++)
                    ddlList.Items.Add(i.ToString());
                ddlList.Attributes["rowno"] = e.Item.ItemIndex.ToString();
                ddlList.SelectedIndexChanged += new EventHandler(ddlList_SelectedIndexChanged);
            }

        }

        private void ddlList_SelectedIndexChanged(object sender, EventArgs e)
        {
            //Update cart...
            int nIndex = Convert.ToInt32((sender as DropDownList).Attributes["rowno"]);
            ObjClasses.ShoppingCartItem oItem = ObjClasses.ShoppingCart.GetCurrentUsersCart[nIndex];
            ObjClasses.ShoppingCart.GetCurrentUsersCart.SetCount(Convert.ToInt32(oItem.PrArticle.Id),
                Convert.ToInt32((sender as DropDownList).SelectedValue));

            Response.Redirect(Request.Url.ToString(), true);

        }



        protected void plCart_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Footer)
            {
                HyperLink Hyperlink2 = e.Item.FindControl("Hyperlink2") as HyperLink;
                Hyperlink2.Text = "USD $" + ObjClasses.ShoppingCart.GetCurrentUsersCart.TotalPrice().ToString("##0.00");
            }
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                ObjClasses.ShoppingCartItem oItem = e.Item.DataItem as ObjClasses.ShoppingCartItem;
                Literal hlCountAndName = e.Item.FindControl("hlCountAndName") as Literal;
                hlCountAndName.Text = oItem.PrArticle.Name;
                Literal Hyperlink1 = e.Item.FindControl("Hyperlink1") as Literal;
                Hyperlink1.Text = oItem.PerPrice.ToString("$##0.00");
                Literal hlTotPrice = e.Item.FindControl("hlTotPrice") as Literal;
                hlTotPrice.Text = oItem.TotalPrice.ToString("$##0.00");

                DropDownList ddlList = e.Item.FindControl("ddlCount") as DropDownList;
                ddlList.SelectedIndex = oItem.Count;
                if (oItem.TotalPrice < 0)
                {
                    ddlList.Visible = false;
                }

            }

        }

        protected void btnPay_Click(object sender, EventArgs e)
        {
            Response.Redirect("shopcheckout.aspx", true);
        }

        protected void repArt_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                ObjClasses.Article oArt = e.Item.DataItem as ObjClasses.Article;
                HyperLink hlAddToCart = e.Item.FindControl("hlAddToCart") as HyperLink;
                hlAddToCart.NavigateUrl = "default.aspx?addcart=" + oArt.PaypalID;
                Literal litName = e.Item.FindControl("litName") as Literal;
                litName.Text = oArt.Name;
                Literal litProductID = e.Item.FindControl("litProductID") as Literal;
                litProductID.Text = oArt.PaypalID;
                Literal litPrice = e.Item.FindControl("litPrice") as Literal;
                litPrice.Text = oArt.Price.ToString("USD $##0.00");

            }

        }
    }
}
