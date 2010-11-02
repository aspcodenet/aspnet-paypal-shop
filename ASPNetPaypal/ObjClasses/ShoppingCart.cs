using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Collections.Generic;


namespace ASPNetPaypal.ObjClasses
{
        public class ShoppingCart : List<ShoppingCartItem>
        {

            public static ShoppingCart GetCurrentUsersCart
            {
                get
                {
                    if (System.Web.HttpContext.Current.Session["ShoppingCart"] == null)
                        System.Web.HttpContext.Current.Session["ShoppingCart"] = new ShoppingCart();
                    return System.Web.HttpContext.Current.Session["ShoppingCart"] as ShoppingCart;
                }
            }

            public double TotalPrice()
            {
                double dRet = 0;
                foreach (ShoppingCartItem oItem in this)
                    dRet += oItem.TotalPrice;
                return dRet;
            }

            public ShoppingCartItem Find(int nArtId)
            {
                foreach (ShoppingCartItem oItem in this)
                    if (oItem.PrArticle.Id == nArtId)
                        return oItem;
                return null;
            }

            private void ClearUp()
            {
                while (true)
                {
                    bool fChanged = false;
                    for (int i = 0; i < Count; i++)
                    {
                        ShoppingCartItem oItem = this[i];
                        if (oItem.Count == 0)
                        {
                            fChanged = true;
                            RemoveAt(i);
                            break;
                        }

                        //Är det en rabatt?

                        if (oItem.PerPrice < 0)
                        {
                            fChanged = true;
                            RemoveAt(i);
                            break;
                        }
                    }

                    if (fChanged == false)
                        break;
                }
            }



            public void SetCount(int nArtId, int nCount)
            {
                ShoppingCartItem oItem = Find(nArtId);
                if (oItem == null)
                {
                    oItem = new ShoppingCartItem();
                    oItem.Count = 0;
                    Article oArt = ArticleCollection.Instance().Find(nArtId);
                    oItem.PrArticle = oArt;
                    oItem.PerPrice = oArt.Price;
                    Add(oItem);
                }
                oItem.Count = nCount;
                oItem.TotalPrice = oItem.PerPrice * oItem.Count;
                ClearUp();

            }

            public void AddCount(int nArtId, int nCount)
            {
                ShoppingCartItem oItem = Find(nArtId);
                if (oItem == null)
                {
                    oItem = new ShoppingCartItem();
                    oItem.Count = 0;
                    Article oArt = ArticleCollection.Instance().Find(nArtId);
                    oItem.PrArticle = oArt;
                    oItem.PerPrice = oArt.Price;
                    Add(oItem);
                }
                oItem.Count++;
                oItem.TotalPrice = oItem.PerPrice * oItem.Count;
                ClearUp();

            }
        }






    public class ShoppingCartItem
    {
        public Article PrArticle = null;
        public int Count = 0;
        public double PerPrice;
        public double TotalPrice;
    }

}
