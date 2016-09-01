using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Sepet : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        SepetiGetir();
    }

    void SepetiGetir()
    {
        DataTable dt = (DataTable)HttpContext.Current.Session["sepet"];

        rpSepet.DataSource = dt;
        rpSepet.DataBind();
        Fonksiyonlar.ToplamTutar();
        lblToplam.Text = Fonksiyonlar.genelToplam;
    }

    protected void btnSil_Command(object sender, CommandEventArgs e)
    {
        rpSepet.DataSource = Fonksiyonlar.Sil(sender, e);
        rpSepet.DataBind();
        Fonksiyonlar.ToplamTutar();
        lblToplam.Text = Fonksiyonlar.genelToplam;
    }

    protected void btnGuncelle_Command(object sender, CommandEventArgs e)
    {
        string s = Request.Form["adet"];
        rpSepet.DataSource = Fonksiyonlar.Guncelle(sender, e, s);
        rpSepet.DataBind();
        Fonksiyonlar.ToplamTutar();
        lblToplam.Text = Fonksiyonlar.genelToplam;
    }
}