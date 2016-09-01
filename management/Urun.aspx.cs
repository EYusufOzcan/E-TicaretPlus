using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class management_Urun : System.Web.UI.Page
{
    DataKatmani db = new DataKatmani();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            KategoriGetir();
            MarkaGetir();
        }
    }

    void KategoriGetir()
    {
        DataTable dtKategori = db.TabloOlustur("select * from Kategoriler where KategoriID in (select KategoriId from KategoriMarka) order by KategoriAd");

        ddlKategori.DataValueField = "KategoriID";
        ddlKategori.DataTextField = "KategoriAd";
        ddlKategori.DataSource = dtKategori;
        ddlKategori.DataBind();
    }

    void MarkaGetir()
    {
        List<Parametreler> liste = new List<Parametreler>();
        liste.Add(new Parametreler { Ad = "@id", Deger = ddlKategori.SelectedValue });
        DataTable dtMarka = db.TabloOlustur("select distinct(m.MarkaID), m.MarkaAd from Markalar m, KategoriMarka km where m.MarkaID in (select km.MarkaId from KategoriMarka km where km.KategoriId = @id) order by MarkaAd", liste);

        ddlMarka.DataTextField = "MarkaAd";
        ddlMarka.DataValueField = "MarkaID";
        ddlMarka.DataSource = dtMarka;
        ddlMarka.DataBind();
    }

    protected void ddlKategori_SelectedIndexChanged(object sender, EventArgs e)
    {
        MarkaGetir();
    }


    protected void btnEkle_Click(object sender, EventArgs e)
    {
        double sonfiyat, indirim, fiyat;
        if (double.TryParse(txtFiyat.Text, out fiyat) && double.TryParse(txtIndirim.Text, out indirim))
        {
            sonfiyat = fiyat - ((fiyat * indirim) / 100);
            List<Parametreler> liste = new List<Parametreler>();
            liste.Add(new Parametreler { Ad = "@katid", Deger = ddlKategori.SelectedValue });
            liste.Add(new Parametreler { Ad = "@marid", Deger = ddlMarka.SelectedValue });
            liste.Add(new Parametreler { Ad = "@urunad", Deger = txtUrunAd.Text });
            liste.Add(new Parametreler { Ad = "@stok", Deger = txtStok.Text });
            liste.Add(new Parametreler { Ad = "@fiyat", Deger = fiyat });
            liste.Add(new Parametreler { Ad = "@indirim", Deger = indirim });
            liste.Add(new Parametreler { Ad = "@sonfiyat", Deger = sonfiyat});
            liste.Add(new Parametreler { Ad = "@detay", Deger = txtDetay.Text});
            liste.Add(new Parametreler { Ad = "@aktif", Deger = cbAktif.Checked});
            liste.Add(new Parametreler { Ad = "@vitrin", Deger = cbVitrin.Checked });
            db.SorguCalistir("insert Urunler values (@katid, @marid, @urunad, @stok, @fiyat, @indirim, @sonfiyat, @detay, @aktif, @vitrin)", liste);
        }
    }
}