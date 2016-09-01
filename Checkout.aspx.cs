using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Checkout : System.Web.UI.Page
{
    DataKatmani db = new DataKatmani();
    List<Parametreler> liste = new List<Parametreler>();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            IlGetir();
            ddlIller_SelectedIndexChanged(sender, e);
            SepetBilgisiGetir();
        }

    }
    void IlGetir()
    {
        DataTable dt = db.TabloOlustur("select * from Iller");
        DropDownList ddlIller = (DropDownList)LoginView1.FindControl("ddlIller");
        ddlIller.DataValueField = "IlID";
        ddlIller.DataTextField = "IlAd";
        ddlIller.DataSource = dt;
        ddlIller.DataBind();
    }

    protected void ddlIller_SelectedIndexChanged(object sender, EventArgs e)
    {
        DropDownList ddlIller = (DropDownList)LoginView1.FindControl("ddlIller");
        liste.Clear();
        liste.Add(new Parametreler { Ad = "@id", Deger = ddlIller.SelectedValue });
        DataTable dt = db.TabloOlustur("select * from Ilceler where IlId=@id", liste);
        DropDownList ddlIlceler = (DropDownList)LoginView1.FindControl("ddlIlceler");
        ddlIller = new DropDownList();
        ddlIlceler.DataTextField = "IlceAd";
        ddlIlceler.DataValueField = "IlceID";
        ddlIlceler.DataSource = dt;
        ddlIlceler.DataBind();
    }

    void SepetBilgisiGetir()
    {
        if (HttpContext.Current.Session["sepet"] != null)
        {
            DataTable dt = (DataTable)HttpContext.Current.Session["sepet"];
            Repeater rpSepet = (Repeater)LoginView1.FindControl("rpSepet");
            rpSepet.DataSource = dt;
            rpSepet.DataBind();
            Label lblToplam = (Label)LoginView1.FindControl("lblToplam");
            Fonksiyonlar.ToplamTutar();
            lblToplam.Text = Fonksiyonlar.genelToplam;
        }

    }

    protected void btnOnayla_Click(object sender, EventArgs e)
    {
        try
        {
            int Id = Convert.ToInt32(db.ScalarCalistir("select Top(1) SiparisID from SiparisBilgi order by SiparisID desc"));
            Id += 1;
            liste.Clear();
            liste.Add(new Parametreler { Ad = "@name", Deger = Membership.GetUser().UserName });
            string userid = db.ScalarCalistir("select UserId from Users where UserName=@name", liste);
            if (HttpContext.Current.Session["sepet"] != null)
            {
                DataTable dt = (DataTable)HttpContext.Current.Session["sepet"];

                liste.Clear();
                liste.Add(new Parametreler { Ad = "@sipid", Deger = Id });
                Fonksiyonlar.ToplamTutar();
                TextBox txtAd = (TextBox)LoginView1.FindControl("txtAd");
                TextBox txtAdres = (TextBox)LoginView1.FindControl("txtAdres");
                TextBox txtPosta = (TextBox)LoginView1.FindControl("txtPostaKodu");
                DropDownList ddlIller = (DropDownList)LoginView1.FindControl("ddlIller");
                DropDownList ddlIlceler = (DropDownList)LoginView1.FindControl("ddlIlceler");
                string adres = string.Format("{0} - {1} - {2} - {3}/{4}", txtAd.Text, txtAdres.Text, txtPosta.Text, ddlIlceler.SelectedItem, ddlIller.SelectedItem);
                liste.Add(new Parametreler { Ad = "@adres", Deger = adres });
                liste.Add(new Parametreler { Ad = "@toplam", Deger = Fonksiyonlar.genelToplam });
                db.SorguCalistir("insert SiparisBilgi values(@sipid, @adres, @toplam)", liste);

                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    liste.Clear();
                    liste.Add(new Parametreler { Ad = "@sipid", Deger = Id });
                    liste.Add(new Parametreler { Ad = "@userid", Deger = userid });
                    liste.Add(new Parametreler { Ad = "@urunId", Deger = dt.Rows[i]["id"] });
                    liste.Add(new Parametreler { Ad = "@adet", Deger = dt.Rows[i]["adet"] });
                    liste.Add(new Parametreler { Ad = "@tutar", Deger = dt.Rows[i]["tutar"] });
                    db.SorguCalistir("insert Siparisler values(@sipid, @userid, @urunId, @adet, @tutar)", liste);
                }

                HttpContext.Current.Session["sepet"] = null;
            }
            else
            {
                Response.Write("<script>alert('Siparişte bulunabilmeniz için sepete bir şeyler eklemelisiniz.');</script>");
            }
            Response.Redirect("Default.aspx");
        }

        catch (Exception)
        {

        }


    }
}