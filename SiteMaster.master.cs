using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class IndexMaster : System.Web.UI.MasterPage
{
    DataKatmani db = new DataKatmani();
    List<Parametreler> liste = new List<Parametreler>();
    protected void Page_Load(object sender, EventArgs e)
    {
            KategoriGetir();
            MarkaGetir();
            Son();   
    }

    void KategoriGetir()
    {
        DataTable dt = db.TabloOlustur("select * from Kategoriler order by KategoriAd");
        rpKategori.DataSource = dt;
        rpKategori.DataBind();
        rpKategoriler.DataSource = dt;
        rpKategoriler.DataBind();
    }


    void MarkaGetir()
    {
        DataTable dt = db.TabloOlustur("select * from Markalar order by MarkaAd");
        rpMarkalar.DataSource = dt;
        rpMarkalar.DataBind();
    }

    void Son()
    {
        DataTable dt = db.TabloOlustur("select Top(5) Urunler.*, FotoYol from Fotograflar inner join Urunler ON UrunId = UrunID where FotoVitrin = 1 and Vitrin = 1 order by UrunID desc");
        Fonksiyonlar.FiyatSifirla(dt);
        PuanHesaplama(dt);

        rpSon.DataSource = dt;
        rpSon.DataBind();

        dt = db.TabloOlustur("select Top(2) Urunler.*, FotoYol from Fotograflar inner join Urunler ON UrunId = UrunID where FotoVitrin = 1 and Vitrin = 1 and IndirimOrani > 5 order by newID()");

        Fonksiyonlar.FiyatSifirla(dt);
        PuanHesaplama(dt);

        rpFirsat.DataSource = dt;
        rpFirsat.DataBind();

    }

    public void PuanHesaplama(DataTable dt)
    {
        dt.Columns.Add("PuanOrtalama");

        for (int i = 0; i < dt.Rows.Count; i++)
        {
            liste.Clear();
            liste.Add(new Parametreler { Ad = "@" + i, Deger = dt.Rows[i]["UrunID"] });
            string puan = db.ScalarCalistir(string.Format("select AVG(Puan) from Yorumlar where UrunId=@{0}", i), liste);
            if (!string.IsNullOrEmpty(puan))
            {
                dt.Rows[i]["PuanOrtalama"] = puan;
            }
            else
            {
                dt.Rows[i]["PuanOrtalama"] = 0;
            }
        }
    }

    //public void BilgiGetir()
    //{
    //    if (HttpContext.Current.Session["sepet"] != null)
    //    {
    //        DataTable dt = (DataTable)HttpContext.Current.Session["sepet"];
    //        double tutar = 0;
    //        for (int i = 0; i < dt.Rows.Count; i++)
    //        {
    //            tutar += Convert.ToDouble(dt.Rows[i]["tutar"]);
    //        }
    //        int urunSayisi = dt.Rows.Count;

    //        dt = new DataTable();
    //        dt.Columns.Add("urunSayisi");
    //        dt.Columns.Add("toplamTutar");
    //        DataRow dr = dt.NewRow();
    //        dr["urunSayisi"] = urunSayisi;
    //        dr["toplamTutar"] = tutar;
    //        dt.Rows.Add(dr);

    //        rpBilgi.DataSource = dt;
    //        rpBilgi.DataBind();

    //        dt = (DataTable)HttpContext.Current.Session["sepet"];

    //        rpCart.DataSource = dt;
    //        rpCart.DataBind();

    //        Fonksiyonlar.ToplamTutar();
    //        if (!string.IsNullOrEmpty(Fonksiyonlar.genelToplam))
    //        {
    //            lblToplam = new Label();
    //            lblToplam.Text = Fonksiyonlar.genelToplam;
    //        }

    //    }
    //}


}
