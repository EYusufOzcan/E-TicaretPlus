using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class management_ResimEkle : System.Web.UI.Page
{
    DataKatmani db = new DataKatmani();
    List<Parametreler> liste = new List<Parametreler>();
    string urunID = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        UrunAdGetir();
        VitrinBilgisiGetir();
    }
    protected void btnEkle_Click(object sender, EventArgs e)
    {
        try
        {
            string uzanti, isim, gecici;
            int yukseklik, genislik;
            string[] izinUzanti = { ".png", ".jpeg", ".jpg", ".PNG", ".JPEG", ".JPG" }, boyut = { "62", "152", "350", "600" };
            uzanti = Path.GetExtension(fuResim.FileName);
            if (fuResim.FileName != "")
            {
                byte[] resimBoyut = fuResim.FileBytes;
                if (resimBoyut.Length < 8388608)
                {
                    if (izinUzanti.Contains(uzanti))
                    {
                        isim = Guid.NewGuid().ToString();
                        isim += uzanti;
                        gecici = Server.MapPath(@"~\resimler\gecici" + uzanti);
                        fuResim.SaveAs(gecici);

                        using (Bitmap orijinal = new Bitmap(gecici))
                        {
                            for (int i = 0; i < boyut.Length; i++)
                            {
                                int sayi = Convert.ToInt32(boyut[i]);
                                yukseklik = sayi; genislik = sayi;
                                Bitmap yeniResim = new Bitmap(orijinal, new Size(genislik, yukseklik));
                                yeniResim.Save(Server.MapPath(string.Format(@"~\resimler\{0}\" + isim, sayi.ToString())));
                                yeniResim.Dispose();
                            }
                        }

                        FileInfo fi = new FileInfo(Server.MapPath(@"~\resimler\gecici" + uzanti));
                        fi.Delete();

                        if (cbVitrin.Checked)
                        {
                            liste.Clear();
                            liste.Add(new Parametreler { Ad = "@id", Deger = urunID });
                            db.SorguCalistir("update Fotograflar set FotoVitrin=0 where UrunId=@id", liste);
                        }

                        liste.Clear();
                        liste.Add(new Parametreler { Ad = "@id", Deger = urunID });
                        liste.Add(new Parametreler { Ad = "@vitrin", Deger = cbVitrin.Checked });
                        liste.Add(new Parametreler { Ad = "@yol", Deger = isim });
                        db.SorguCalistir("insert Fotograflar values(@id, @vitrin, @yol)", liste);
                        VitrinBilgisiGetir();
                        cbVitrin.Checked = false;
                    }

                    else
                    {
                        lblUyarı.Text = "Yanlış türde dosya seçimi yaptınız. Dosya uzantısı .png, .jpeg, .jpg olmalı";
                    }
                }
                else
                {
                    lblUyarı.Text = "Dosya boyutu 8MB'dan büyük olamaz.";
                }
            }
            else
            {
                lblUyarı.Text = "Dosya yüklemediniz.";
            }
        }
        catch (Exception)
        {

            throw;
        }
    }

    void UrunAdGetir()
    {
        urunID = Request.QueryString["id"];
        if (!string.IsNullOrEmpty(urunID))
        {
            liste.Clear();
            liste.Add(new Parametreler { Ad = "@id", Deger = urunID } );
            lblUrunAd.Text = db.ScalarCalistir("select UrunAd from Urunler where UrunID=@id", liste);
        }
        else
        {
            Response.Redirect("UrunListesi.aspx");
        }
    }

    void VitrinBilgisiGetir()
    {
        liste.Clear();
        liste.Add(new Parametreler { Ad = "@id", Deger = urunID });
        int sayi = Convert.ToInt32(db.ScalarCalistir("select count(*) from Fotograflar where UrunId=@id and FotoVitrin=1", liste));
        if (sayi == 0)
        {
            lblVitrin.Text = "Ürün vitrin fotoğrafına sahip değil";
        }
        else
        {
            lblVitrin.Text = "Ürün vitrin fotografına sahip.";
        }
    }

    //void ReimBilgisiGetir()
    //{
    //    liste.Clear();
    //    liste.Add(new Parametreler { Ad = "@id", Deger = urunID });
    //    db.ScalarCalistir("select count(*) from Fotograflar where UrunId=@id", liste);
    //}

    protected void btnGeri_Click(object sender, EventArgs e)
    {
        Response.Redirect("UrunListesi.aspx");
    }


}