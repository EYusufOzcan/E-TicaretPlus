using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class management_UrunListesi : System.Web.UI.Page
{
    DataKatmani db = new DataKatmani();
    protected void Page_Load(object sender, EventArgs e)
    {
        UrunGetir();
    }

    void UrunGetir()
    {
        DataTable dtUrun = db.TabloOlustur("select u.*, KategoriAd, MarkaAd from Urunler u, Kategoriler k, Markalar m where u.KategoriId = k.KategoriID and m.MarkaID = u.MarkaId");
        gvUrunler.DataSource = dtUrun;
        gvUrunler.DataBind();
    }

}