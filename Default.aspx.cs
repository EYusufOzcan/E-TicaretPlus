using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Default2 : System.Web.UI.Page
{
    DataKatmani db = new DataKatmani();
    List<Parametreler> liste = new List<Parametreler>();
    string katID = "", marID="";

    protected void Page_Load(object sender, EventArgs e)
    {
        UrunGetir();
    }

    void UrunGetir()
    {
        katID = Request.QueryString["katid"];
        marID = Request.QueryString["marid"];
        DataTable dt = new DataTable();
        if (string.IsNullOrEmpty(katID) && string.IsNullOrEmpty(marID))
        {
            dt = db.TabloOlustur("select Urunler.*, FotoYol from Fotograflar inner join Urunler ON UrunId = UrunID where FotoVitrin = 1 and Vitrin = 1");
        }
        else if(!string.IsNullOrEmpty(katID) && string.IsNullOrEmpty(marID))
        {
            liste.Add(new Parametreler { Ad = "@katid", Deger = katID });
            dt = db.TabloOlustur("select Urunler.*, FotoYol from Fotograflar inner join Urunler ON UrunId = UrunID where FotoVitrin = 1 and Vitrin = 1 and KategoriId=@katid", liste);
            liste.Clear();   
        }

        else if (string.IsNullOrEmpty(katID) && !string.IsNullOrEmpty(marID))
        {
            liste.Add(new Parametreler { Ad = "@marid", Deger = marID });
            dt = db.TabloOlustur("select Urunler.*, FotoYol from Fotograflar inner join Urunler ON UrunId = UrunID where FotoVitrin = 1 and Vitrin = 1 and MarkaId=@marid", liste);
            liste.Clear();
        }
        

        dt.Columns.Add("PuanOrtalama");

        for (int i = 0; i < dt.Rows.Count; i++)
        {
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
            liste.Clear();
        }

        rpUrunler.DataSource = dt;
        rpUrunler.DataBind();
    }

    protected void rpUrunler_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
        Fonksiyonlar.SepeteEkle(e.CommandArgument.ToString());
    }
}