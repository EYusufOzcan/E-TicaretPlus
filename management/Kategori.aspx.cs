using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class management_Kategori : System.Web.UI.Page
{

    DataKatmani db = new DataKatmani();
    List<Parametreler> liste = new List<Parametreler>();
    string KategoriID = null;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            KategoriGetir();
            btnEkle.Visible = true;
            liste.Clear();
            KategoriGuncelle();
        }
    }

    protected void btnEkle_Click(object sender, EventArgs e)
    {
        liste.Clear();
        liste.Add(new Parametreler { Ad = "@ad", Deger = txtKategoriAd.Text });
        db.SorguCalistir("insert Kategoriler values(@ad)", liste);
        txtKategoriAd.Text = "";
        KategoriGetir();
    }

    void KategoriGetir()
    {
        DataTable dt = db.TabloOlustur("select * from Kategoriler");

        gvKategoriler.DataSource = dt;
        gvKategoriler.DataBind();
    }

    void KategoriGuncelle()
    {
        KategoriID = Request.QueryString["id"];
        if (!string.IsNullOrEmpty(KategoriID))
        {
            btnEkle.Visible = false;
            btnGuncelle.Visible = true;
            liste.Clear();
            liste.Add(new Parametreler { Ad = "@id", Deger = KategoriID });
            txtKategoriAd.Text = db.ScalarCalistir("select KategoriAd from Kategoriler where KategoriID=@id", liste);
        }
    }

    protected void btnGuncelle_Click(object sender, EventArgs e)
    {
        liste.Clear();
        liste.Add(new Parametreler { Ad = "@id", Deger = KategoriID });
        liste.Add(new Parametreler { Ad = "@ad", Deger = txtKategoriAd.Text });
        db.SorguCalistir("update Kategoriler set KategoriAd=@ad where KategoriID=@id", liste);
        btnEkle.Visible = true;
        btnGuncelle.Visible = false;
        txtKategoriAd.Text = "";
        KategoriGetir();
    }
}