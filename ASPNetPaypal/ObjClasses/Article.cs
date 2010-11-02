using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Collections.Generic;

namespace ASPNetPaypal.ObjClasses
{
    public class Article
    {
        public int Id;
        public string Name = "";
        public string PaypalID = "";
        public string Group = "";
        public double Price = 0;
    }

    public class ArticleCollection : List<Article>
    {
        public static ArticleCollection Filter(string sWhat)
        {
            ArticleCollection oArtColl = new ArticleCollection();
            foreach (Article oArt in Instance())
            {
                if (oArt.Group == sWhat)
                    oArtColl.Add(oArt);
            }
            return oArtColl;
        }
        private static ArticleCollection m_Instance = null;
        public static ArticleCollection Instance()
        {
            if (m_Instance == null)
            {
                m_Instance = new ArticleCollection();
                Article oArt = new Article();

                oArt.Id = 1;
                oArt.Name = "The cool product 1";
                oArt.PaypalID = "ADSS5";
                oArt.Group = "5";
                oArt.Price = 119;
                m_Instance.Add(oArt);

                oArt = new Article();
                oArt.Id = 2;
                oArt.Name = "Whatever Product 2";
                oArt.PaypalID = "ADMS5";
                oArt.Group = "5";
                oArt.Price = 219;
                m_Instance.Add(oArt);

                oArt = new Article();
                oArt.Id = 3;
                oArt.Name = "Some cool thing ";
                oArt.PaypalID = "ADSC5";
                oArt.Price = 1699;
                oArt.Group = "5";
                m_Instance.Add(oArt);

                oArt = new Article();
                oArt.Id = 4;
                oArt.Name = "Acme Super";
                oArt.PaypalID = "ADIN5";
                oArt.Group = "5";
                oArt.Price = 99;
                m_Instance.Add(oArt);



            }
            return m_Instance;

        }

        public Article Find(string sPaypalID)
        {
            foreach (Article oArt in this)
                if (oArt.PaypalID == sPaypalID)
                    return oArt;
            return null;
        }

        public Article Find(int nId)
        {
            foreach (Article oArt in this)
                if (oArt.Id == nId)
                    return oArt;
            return null;
        }
    }

}
