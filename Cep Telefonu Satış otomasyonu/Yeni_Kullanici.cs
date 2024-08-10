using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Cep_Telefonu_Satış_otomasyonu
{
    public partial class Yeni_Kullanici : Form
    {
        public Yeni_Kullanici()
        {
            InitializeComponent();
        }
        //Sql Bağlantısı
        SqlConnection bag = new SqlConnection(@"Data Source=DESKTOP-ML2A0NI\SQLEXPRESS;Initial Catalog=""Cep Telefonu Satıs"";Integrated Security=True;Encrypt=False");
        private void YeniKullanicibtn_Click(object sender, EventArgs e)
        {
                //Yeni Kullanıcı Oluşturma Kaynak Kodları
                bag.Open();
                SqlCommand komut = new SqlCommand("Insert into Personel (Ad, Soyad, D_Tarihi, DepartmanId, Kullanici_Adi, Sifre) Values (@prm1, @prm2, @prm3, @prm4, @prm5, @prm6)", bag);
                komut.Parameters.AddWithValue("@prm1", YeniKullaniciAdiText.Text);
                komut.Parameters.AddWithValue("@prm2", YeniKullaniciSoyadText.Text);
                komut.Parameters.AddWithValue("@prm3", YeniKullaniciDogumTarihiText.Text);
                komut.Parameters.AddWithValue("@prm4", YeniKullaniciDepartmanIdText.Text); // Departman ID'yi integer'a çevirin.
                komut.Parameters.AddWithValue("@prm5", YeniKullaniciUserText.Text);
                komut.Parameters.AddWithValue("@prm6", YeniKullaniciSifreText.Text);
                komut.ExecuteNonQuery();
                MessageBox.Show("Kullanıcı Başarı İle Eklendi");
                bag.Close();
        }
    }
}
