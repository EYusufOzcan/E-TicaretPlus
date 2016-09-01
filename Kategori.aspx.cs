using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Kategori : System.Web.UI.Page
{
    DataKatmani db = new DataKatmani();
    List<Parametreler> liste = new List<Parametreler>();
    DataTable dt = new DataTable();
    string[] siralama = { "UrunID", "UrunAd", "UrunAd desc", "Fiyat", "Fiyat desc" };
    protected void Page_Load(object sender, EventArgs e)
    {
        ddlSiralama_SelectedIndexChanged(sender, e);
    }
    protected void btnSepet_Command(object sender, CommandEventArgs e)
    {
        Fonksiyonlar.SepeteEkle(e.CommandArgument.ToString());
    }

    protected void ddlSiralama_SelectedIndexChanged(object sender, EventArgs e)
    {
        string sorgu = string.Format("select * from Urunler inner join Fotograflar on UrunID = UrunId where FotoVitrin = 1 and Vitrin = 1 order by {0}", siralama[Convert.ToInt32(ddlSiralama.SelectedValue)]);
        dt = db.TabloOlustur(sorgu);
        dt.Columns.Add("PuanOrtalama");

        Fonksiyonlar.DegerlendirmeGetir(dt);

        rpUrun.DataSource = dt;
        rpUrun.DataBind();
    }
}