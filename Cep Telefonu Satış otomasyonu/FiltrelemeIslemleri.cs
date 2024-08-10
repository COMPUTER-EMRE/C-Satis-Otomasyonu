using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Cep_Telefonu_Satış_otomasyonu
{
    public partial class FiltrelemeIslemleri : Form
    {
        public FiltrelemeIslemleri()
        {
            InitializeComponent();
        }
        SqlConnection bag = new SqlConnection(@"Data Source=DESKTOP-ML2A0NI\SQLEXPRESS;Initial Catalog=""Cep Telefonu Satıs"";Integrated Security=True;Encrypt=False");
        //En Çok Satışı Yapılan Ürün ve Özellikleri Listelememize Yarar
        private void Filtreleme_1Satisbtn_Click(object sender, EventArgs e)
        {
            SqlDataAdapter da = new SqlDataAdapter("SELECT TOP 1 * FROM Urun U JOIN Ozellikler O ON U.OzellikId=O.Ozellik_Id ORDER BY U.Fiyat DESC;", bag);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridViewFiltrele.DataSource = dt;
        }
        //En Çok Satış Yapan Personel Ve Bilgilerini Getirmemize Yarar
        private void Filtreleme_2Personelbtn_Click(object sender, EventArgs e)
        {
            SqlDataAdapter da = new SqlDataAdapter("SELECT TOP 1 \r\n    P.PersonelID,  \r\n    P.Ad AS Personel_Adi, \r\n    P.Soyad AS Personel_Soyad, \r\n    P.D_Tarihi, \r\n    P.DepartmanId,\r\n    SUM(SH.AlinanUrunMiktari) AS ToplamSatisMiktari \r\nFROM \r\n    SatisHareketi SH \r\nJOIN \r\n    Personel P ON SH.PersonelID = P.PersonelID \r\nGROUP BY \r\n    P.PersonelID, \r\n    P.Ad, \r\n    P.Soyad, \r\n    P.D_Tarihi, \r\n    P.DepartmanId\r\nORDER BY \r\n    ToplamSatisMiktari DESC;", bag);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridViewFiltrele.DataSource = dt;
        }
        //Belirli Aralıktaki Fiyatlarda Olan Ürün Ve Özellikleri Getirmemize Yarar
        private void Filtrelemebtn2_Click(object sender, EventArgs e)
        {
            bag.Open();
            string sorgu = "SELECT * FROM Urun WHERE Fiyat BETWEEN @prm1 AND @prm2";
            SqlCommand komut = new SqlCommand(sorgu, bag);
            komut.Parameters.AddWithValue("@prm1", FiltrelemeMinDegerText.Text); // Text özelliğini kullan
            komut.Parameters.AddWithValue("@prm2", FiltrelemeMaxDegerText.Text); // Text özelliğini kullan
            SqlDataAdapter da = new SqlDataAdapter(komut);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridViewFiltrele.DataSource = dt;
       }
        //İstediğimiz Marka Ve Modele Göre Listeleme
        private void button4_Click(object sender, EventArgs e)
        {
            bag.Open();
            string sorgu = "SELECT * FROM Urun WHERE Marka=@prm1 AND Model=@prm2";
            SqlCommand komut = new SqlCommand(sorgu, bag);
            komut.Parameters.AddWithValue("@prm1", FiltrelemeMarkaText.Text); // Text özelliğini kullan
            komut.Parameters.AddWithValue("@prm2", FiltrelemeModelText.Text); // Text özelliğini kullan
            SqlDataAdapter da = new SqlDataAdapter(komut);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridViewFiltrele.DataSource = dt;
        }
        //Çıkış Butonu
        private void Cikisptb_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
