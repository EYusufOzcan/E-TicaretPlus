using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;

/// <summary>
/// Veri tabanı işlemleri için oluşturulmuş sınıf
/// </summary>
public class DataKatmani
{
    public DataKatmani()
	{
	}

    public SqlConnection Baglan()
    {
        SqlConnection.ClearAllPools();//Baglantıyı sürekli açıyoruz bir süre açılabilir baglantı sayısı doluyor. Bu nedenle temizliyoruz öncekileri.
        SqlConnection con = new SqlConnection("server=.; database=DBProje; integrated security=SSPI");
        con.Open();
        return con;    
    }

    public int SorguCalistir(string sorgu)
    {
        SqlCommand cmd = new SqlCommand(sorgu, Baglan());
        return cmd.ExecuteNonQuery();
    
    }

    void ListeyeParametreEkle(SqlCommand cmd, List<Parametreler> liste)
    {
        foreach (Parametreler parametre in liste)
        {
            cmd.Parameters.AddWithValue(parametre.Ad, parametre.Deger);
        }
    }

    public int SorguCalistir(string sorgu, List<Parametreler> liste)
    {
        SqlCommand cmd = new SqlCommand(sorgu, Baglan());
        ListeyeParametreEkle(cmd, liste);
        return cmd.ExecuteNonQuery();
    }

    public DataTable TabloOlustur(string sorgu)
    {
        SqlDataAdapter ad = new SqlDataAdapter(sorgu, Baglan());
        DataTable dt = new DataTable();
        ad.Fill(dt);
        return dt;
    }

    public DataTable TabloOlustur(string sorgu, List<Parametreler> liste)
    {
        SqlDataAdapter ad = new SqlDataAdapter(sorgu, Baglan());
        ListeyeParametreEkle(ad.SelectCommand, liste);
        DataTable dt = new DataTable();
        ad.Fill(dt);
        return dt;
    }

    public string ScalarCalistir(string sorgu)
    {
        SqlCommand cmd = new SqlCommand(sorgu, Baglan());
        return cmd.ExecuteScalar().ToString();
    }

    public string ScalarCalistir(string sorgu, List<Parametreler> liste)
    {
        SqlCommand cmd = new SqlCommand(sorgu, Baglan());
        ListeyeParametreEkle(cmd, liste);
        return cmd.ExecuteScalar().ToString();
    }

    public DataRow DataSatiriOlustur(string sorgu, List<Parametreler> liste)
    {
        DataTable dt = TabloOlustur(sorgu, liste);
        if (dt.Rows.Count != 0)
        {
            return dt.Rows[0];
        }
        else
        {
            return null;
        }
    }
    
}

    public class Parametreler
    {
        public string Ad { get; set; }
        public object Deger { get; set; }
    
        public Parametreler()
        {
            Ad = null;
            Deger = null;
        }
    }

