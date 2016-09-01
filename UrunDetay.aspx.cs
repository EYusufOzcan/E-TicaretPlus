using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class UrunDetay : System.Web.UI.Page
{
    DataKatmani db = new DataKatmani();
    List<Parametreler> liste = new List<Parametreler>();
    string urunID = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        urunID = Request.QueryString["id"];
        if (!string.IsNullOrEmpty(urunID))
        {
            liste.Add(new Parametreler { Ad = "@id", Deger = urunID });
            UrunGetir();
            BenzerUrunGetir();
            YorumGetir();
        }
        else
        {
            Response.Redirect("Default.aspx");
        }
    }

    void UrunGetir()
    {
        DataTable dt = db.TabloOlustur("select Urunler.*, Markalar.*, Kategoriler.*, FotoYol from  Markalar inner join Urunler on MarkaID = MarkaId inner join Fotograflar on UrunID = UrunId inner join Kategoriler on KategoriId=KategoriID and UrunID=@id and FotoVitrin=1", liste);

        Fonksiyonlar.FiyatSifirla(dt);

        DegerlendirmeGetir(dt);

        rpUrun.DataSource = dt;
        rpUrun.DataBind();
    }

    protected void rpUrun_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        DataTable dt = db.TabloOlustur("select * from Fotograflar where UrunId=@id and FotoVitrin=0", liste);
        Repeater rpt = (Repeater)e.Item.FindControl("rpResim");//rpresim, rp urunun içinde olduğundan ona normalde ulaşamıyoruz, bu nedenle rpurun içindeki kontrollerden bulup kullanıyoruz. Bu metot rpUrune data bağlandığında otomatik çalışıyor.
        rpt.DataSource = dt;
        rpt.DataBind();
    }

    void BenzerUrunGetir()
    {
        DataTable dt = db.TabloOlustur("select Top(4) Urunler.*, FotoYol from Fotograflar, Markalar, Urunler, Kategoriler where UrunID = UrunId and MarkaId = MarkaID and KategoriId = KategoriID and (MarkaAd = (select MarkaAd from Urunler, Markalar where UrunID = @id and MarkaId = MarkaID) or KategoriAd = (select KategoriAd from Urunler, Kategoriler where UrunID = @id and KategoriId = KategoriID)) and FotoVitrin=1 and Vitrin=1 and UrunId != @id", liste);

        rpBenzer.DataSource = dt;
        rpBenzer.DataBind();

    }

    void YorumGetir()
    {
        DataTable dt = db.TabloOlustur("select  Yorumlar.*, UserName from dbo.Users INNER JOIN Yorumlar ON Users.UserId = Yorumlar.UserId and UrunId = @id order by Tarih desc, YorumID desc", liste);

        rpYorumlar.DataSource = dt;
        rpYorumlar.DataBind();

    }
    void DegerlendirmeGetir(DataTable dt)
    {
        dt.Columns.Add("PuanOrtalama");
        dt.Columns.Add("YorumSayisi");

        for (int i = 0; i < dt.Rows.Count; i++)
        {
            string puan = db.ScalarCalistir("select AVG(Puan) from Yorumlar where UrunId=@id", liste);
            dt.Rows[i]["YorumSayisi"] = db.ScalarCalistir("select Count(*) from Yorumlar where UrunId=@id", liste);
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

    protected void btnSepet_Command(object sender, CommandEventArgs e)
    {
        
        Fonksiyonlar.SepeteEkle(e.CommandArgument.ToString());
    }

    protected void btnYorum_Command(object sender, EventArgs e)
    {
        liste.Clear();
        liste.Add(new Parametreler { Ad = "@name", Deger = Membership.GetUser().UserName });//Giris yapmış kullanıcının adını bulmaya yarıyan hazır bir yöntem.
        string userid = db.ScalarCalistir("select UserId from Users where UserName=@name", liste);
        liste.Clear();
        liste.Add(new Parametreler { Ad = "@userId", Deger = userid });
        liste.Add(new Parametreler { Ad = "@urunId", Deger = urunID });
        TextBox txt =  (TextBox)LoginView1.FindControl("txtYorum");
        liste.Add(new Parametreler { Ad = "@yorum", Deger = txt.Text });
        txt.Text = "";
        string puan = "0";
        for (int i = 1; i < 6; i++)//foreach ve Control işe yaramadı?
        {
            RadioButton rb = (RadioButton)LoginView1.FindControl(string.Format("rb" + i));
            if (((RadioButton)rb).Checked)
            {
                puan = ((RadioButton)rb).Text;
                ((RadioButton)rb).Checked = false;
                break;
            }
        }
        liste.Add(new Parametreler { Ad = "@puan", Deger = puan });
        liste.Add(new Parametreler { Ad = "@tarih", Deger = DateTime.Now });

        db.SorguCalistir("insert Yorumlar values(@userId, @urunId, @yorum, @puan, @tarih)", liste);
        Page_Load(sender, e);
    }
}