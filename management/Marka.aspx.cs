using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class management_Marka : System.Web.UI.Page
{
    DataKatmani db = new DataKatmani();
    List<Parametreler> liste = new List<Parametreler>();
    string MarkaID = null;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            MarkaGetir();
        }
        MarkaGuncelle();
    }

    void MarkaGetir()
    {
        DataTable dt = db.TabloOlustur("select * from Markalar");

        gvMarkalar.DataSource = dt;
        gvMarkalar.DataBind();
    }


    protected void btnEkle_Click(object sender, EventArgs e)
    {
        if (!string.IsNullOrEmpty(txtMarkaAd.Text))
        {
            liste.Clear();
            liste.Add(new Parametreler { Ad = "@ad", Deger = txtMarkaAd.Text });
            db.SorguCalistir("insert Markalar values(@ad)", liste);
            MarkaGetir();
        }
        else
        {
                
        }

    }

    void MarkaGuncelle()
    {
        MarkaID = Request.QueryString["id"];
        if (!string.IsNullOrEmpty(MarkaID))
        {
            btnEkle.Visible = false;
            btnGuncelle.Visible = true;
            liste.Clear();
            liste.Add(new Parametreler { Ad = "@id", Deger = MarkaID });
            txtMarkaAd.Text = db.ScalarCalistir("select MarkaAd from Markalar where MarkaID=@id", liste);
        }

    }

    protected void btnGuncelle_Click(object sender, EventArgs e)
    {
        liste.Clear();
        liste.Add(new Parametreler { Ad = "@id", Deger = MarkaID });
        liste.Add(new Parametreler { Ad = "@ad", Deger = txtMarkaAd.Text });
        db.SorguCalistir("update Kategoriler set KategoriAd=@ad where KategoriID=@id", liste);
        btnEkle.Visible = true;
        btnGuncelle.Visible = false;
        txtMarkaAd.Text = "";
        MarkaGetir();
    }

}