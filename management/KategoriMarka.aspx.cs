using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class management_KategoriMarka : System.Web.UI.Page
{
    DataKatmani db = new DataKatmani();
    string MarkaId = null, KategoriId = null;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            KategoriGetir();
            MarkaGetir();
            KatMarTablo();
        }
        Sil();
    }

    void KategoriGetir()
    {
        DataTable dtKategori = db.TabloOlustur("select * from Kategoriler order by KategoriAd");

        ddlKategori.DataValueField = "KategoriID";
        ddlKategori.DataTextField = "KategoriAd";
        ddlKategori.DataSource = dtKategori;
        ddlKategori.DataBind();
    }

    void MarkaGetir()
    {
        List<Parametreler> liste = new List<Parametreler>();
        liste.Add(new Parametreler { Ad = "@id", Deger = ddlKategori.SelectedValue });
        DataTable dtMarka = db.TabloOlustur("select m.* from Markalar m, KategoriMarka km where m.MarkaID not in (select km.MarkaId from KategoriMarka km where km.KategoriId = @id) order by MarkaAd", liste);
        ddlMarka.DataTextField = "MarkaAd";
        ddlMarka.DataValueField = "MarkaID";
        ddlMarka.DataSource = dtMarka;
        ddlMarka.DataBind();
        liste.Clear();
    }

    protected void ddlKategori_SelectedIndexChanged(object sender, EventArgs e)
    {
        MarkaGetir();
    }

    protected void btnEsle_Click(object sender, EventArgs e)
    {
        List<Parametreler> liste = new List<Parametreler>();
        liste.Add(new Parametreler { Ad = "@katid", Deger = ddlKategori.SelectedValue });
        liste.Add(new Parametreler { Ad = "@marid", Deger = ddlMarka.SelectedValue });
        db.SorguCalistir("insert KategoriMarka values(@katid, @marid)", liste);
        KatMarTablo();
    }

    void KatMarTablo()
    {
        DataTable dt = db.TabloOlustur("select m.*, k.* from KategoriMarka km, Markalar m, Kategoriler k where km.KategoriId = k.KategoriID and km.MarkaId = m.MarkaID");
        gvKatMar.DataSource = dt;
        gvKatMar.DataBind();
    }

    void Sil()
    {
        MarkaId = Request.QueryString["marid"];
        KategoriId = Request.QueryString["katid"];
        if (KategoriId != null && MarkaId != null)
        {
            List<Parametreler> liste = new List<Parametreler>();
            liste.Add(new Parametreler { Ad = "@katid", Deger = KategoriId });
            liste.Add(new Parametreler { Ad = "@marid", Deger = MarkaId });
            db.SorguCalistir("delete from KategoriMarka where KategoriId=@katid and MarkaId=@marid", liste);
            KatMarTablo();
        }

    }
}