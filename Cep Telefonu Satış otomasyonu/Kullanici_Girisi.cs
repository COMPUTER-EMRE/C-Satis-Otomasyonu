using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;//Microsoft Sql ile bağlantı kurma kodu

namespace Cep_Telefonu_Satış_otomasyonu
{
    public partial class Kullanici_Girisi : Form
    {
        public Kullanici_Girisi()
        {
            InitializeComponent();
        }
        //Şifreyi Gizli/Göster yapmamızı sağlayan kaynak kod
        private void CheckBoxSifreGizleGoster_CheckedChanged(object sender, EventArgs e)
        {
            if (CheckBoxSifreGizleGoster.CheckState == CheckState.Checked)
            {
                ParaloText.UseSystemPasswordChar = true;
            }
            else if (CheckBoxSifreGizleGoster.CheckState == CheckState.Unchecked)
            {
                ParaloText.UseSystemPasswordChar = false;
            }
        }
        //Kullanıcı Adı ve şifrenin doğru olup olmadığını kontrol eder
        private void KullaniciGirisbtn_Click(object sender, EventArgs e)
        {
            SqlConnection bag = new SqlConnection("Data Source=DESKTOP-ML2A0NI\\SQLEXPRESS;Initial Catalog=\"Cep Telefonu Satıs\";Integrated Security=True;Encrypt=False");
            SqlParameter prm1 = new SqlParameter("@prm1", KullaniciAdiText.Text);
            SqlParameter prm2 = new SqlParameter("@prm2", ParaloText.Text);
            SqlCommand komut = new SqlCommand("select * from Personel where Kullanici_Adi=@prm1 and Sifre=@prm2", bag);
            SqlDataAdapter da = new SqlDataAdapter(komut);
            komut.Parameters.Add(prm1);
            komut.Parameters.Add(prm2);
            DataTable dt = new DataTable();
            da.Fill(dt);
            if (dt.Rows.Count > 0)//Kullanıcı adı ve şifre doğruysa AnaSayfaa formunu açar
            {
               Ana_Sayfaa ana_sayfa = new Ana_Sayfaa();
                ana_sayfa.Show();
            }
            else
            {
                label4.Text = "туура эмес колдонуучу аты же сырсөз";
            }
        }
        //Yeni Kullanıcı Oluşturma Sayfasını Açar
        private void YeniKullaniciLink_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Yeni_Kullanici yeni_kullanici = new Yeni_Kullanici();
            yeni_kullanici.Show();
        }
    }
}
