using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;

/// <summary>
/// Summary description for Fonksiyonlar
/// </summary>
public class Fonksiyonlar
{
    static DataKatmani db = new DataKatmani();
    static List<Parametreler> liste = new List<Parametreler>();
    public static void SepeteEkle(string urunID)
    {
        DataTable dt = new DataTable();

        if (HttpContext.Current.Session["sepet"] != null)//Ürün eklenmisse
        {
            dt = (DataTable)HttpContext.Current.Session["sepet"];//DataTable'a at
        }
        else//Eklenmemişse
        {
            //Bu sütunları oluştur. Bundan önce datatable boş
            dt.Columns.Add("id");
            dt.Columns.Add("urunAd");
            dt.Columns.Add("fiyat");
            dt.Columns.Add("adet");
            dt.Columns.Add("tutar");
            dt.Columns.Add("fotoYol");

        }

        bool sepetKontrol = Kontrol(urunID);

        liste.Clear();
        liste.Add(new Parametreler { Ad = "@id", Deger = urunID });
        DataRow urunSatiri = db.DataSatiriOlustur("select FotoYol, Urunler.* from Urunler inner join Fotograflar on UrunID = UrunId where UrunID=@id and FotoVitrin=1", liste);
        int adet = 1;

        if (sepetKontrol)
        {
            Arttir(urunID, adet);
        }
        else
        {
            DataRow dr = dt.NewRow();
            dr["id"] = urunID;
            dr["urunAd"] = urunSatiri["UrunAd"];
            dr["fiyat"] = urunSatiri["SonFiyat"];
            dr["adet"] = adet;
            dr["tutar"] = Convert.ToInt32(urunSatiri["SonFiyat"]) * adet;
            dr["fotoYol"] = urunSatiri["FotoYol"];
            dt.Rows.Add(dr);
        }

        HttpContext.Current.Session["sepet"] = dt;
    }

    private static void Arttir(string id, int adet)
    {
        DataTable dt = (DataTable)HttpContext.Current.Session["sepet"];
        for (int i = 0; i < dt.Rows.Count; i++)
        {
            if (dt.Rows[i]["id"].ToString() == id)
            {
                int urunAdedi = Convert.ToInt32(dt.Rows[i]["adet"]) + adet;
                dt.Rows[i]["adet"] = urunAdedi;
                dt.Rows[i]["tutar"] = Convert.ToDouble(dt.Rows[i]["fiyat"]) * urunAdedi;
                HttpContext.Current.Session["sepet"] = dt;
                break;
            }
        }

    }

    private static bool Kontrol(string id)//Eklenecek ürünün sepette var mı yok mu kontrolü yapıyor
    {
        bool evet = false;
        if (HttpContext.Current.Session["sepet"] != null)//Sepette bir şey varsa kontrol edecek
        {
            DataTable dt = (DataTable)HttpContext.Current.Session["sepet"];
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                if (dt.Rows[i]["id"].ToString() == id)
                {
                    evet = true;
                    break;
                }
            }
            return evet;
        }
        else//sepette bir şey yoksa zaten o ürün yoktur
        {
            return evet;
        }
    }

    public static void FiyatSifirla(DataTable dt)
    {
        for (int i = 0; i < dt.Rows.Count; i++)
        {
            if (dt.Rows[i]["IndirimOrani"].ToString() == "0")
            {
                dt.Rows[i]["Fiyat"] = DBNull.Value;
            }
        }
    }

    public static DataTable Sil(object s, CommandEventArgs e)
    {
        DataTable dt = (DataTable)HttpContext.Current.Session["sepet"];
        if (e.CommandName == "sil")
        {
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                if (dt.Rows[i]["id"].ToString() == e.CommandArgument.ToString())
                {
                    dt.Rows.RemoveAt(i);
                    break;
                }
            }
        }
        HttpContext.Current.Session["sepet"] = dt;
        ToplamTutar();
        return dt;
    }

    public static DataTable Guncelle(object s, CommandEventArgs e, string yeniMiktar)
    {
        DataTable dt = (DataTable)HttpContext.Current.Session["sepet"];
        if (e.CommandName == "guncelle")
        {
            string[] dizi = yeniMiktar.Split(',');
            ArrayList arr = new ArrayList();
            for (int i = 0; i < dizi.Length; i++)
            {
                if (dizi[i].ToString() != ",")
                {
                    arr.Add(dizi[i]);
                }
            }
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                if (dt.Rows[i]["id"].ToString() == e.CommandArgument.ToString())
                {
                    dt.Rows[i]["adet"] = arr[i];
                    dt.Rows[i]["tutar"] = Convert.ToInt32(dt.Rows[i]["adet"]) * Convert.ToDouble(dt.Rows[i]["fiyat"]);
                    break;
                }
            }
        }
        HttpContext.Current.Session["sepet"] = dt;
        ToplamTutar();
        return dt;
    }
    public static void ToplamTutar()
    {
        double tutar = 0;
        DataTable dt = new DataTable();
        if (HttpContext.Current.Session["sepet"] != null)
        {
            dt = (DataTable)HttpContext.Current.Session["sepet"];

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                tutar += Convert.ToDouble(dt.Rows[i]["tutar"]);
            }
        }

        genelToplam = string.Format("₺{0}", tutar);
    }
    public static string genelToplam;

    public static void DegerlendirmeGetir(DataTable dt)
    {
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
    }
}

