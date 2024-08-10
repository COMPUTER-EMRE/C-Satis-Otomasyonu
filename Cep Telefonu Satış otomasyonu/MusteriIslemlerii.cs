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
    public partial class MusteriIslemlerii : Form
    {
        public MusteriIslemlerii()
        {
            InitializeComponent();
        }
        SqlConnection bag = new SqlConnection(@"Data Source=DESKTOP-ML2A0NI\SQLEXPRESS;Initial Catalog=""Cep Telefonu Satıs"";Integrated Security=True;Encrypt=False");
        //ComboBoxMusteriSilMusteriId'ye Musteri_id'leri Çekmemize Yarar
        private void MusteriIslemlerii_Load_1(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand("Select * from Musteri", bag);
            bag.Open();
            SqlDataReader dr = komut.ExecuteReader();
            while (dr.Read())
            {
                ComboBoxMusteriSilMusteriId.Items.Add(dr["Musteri_id"]);
            }
            bag.Close();
        }
        //Musteri Tablosunu MusteriDataGridView'de Listelememize Yarar
        private void Listele_Click(object sender, EventArgs e)
        {
            SqlDataAdapter da = new SqlDataAdapter("Select * from Musteri", bag);
            DataTable dt = new DataTable();
            da.Fill(dt);
            MusteriDataGridView.DataSource = dt;
        }
        //Müşteri Tablosuna Yeni Kayıt Eklememize Yarar
        private void MüsteriEklebtn_Click(object sender, EventArgs e)
        {
            bag.Open();
            SqlCommand komut = new SqlCommand("INSERT INTO Musteri (Musteri_adi, Musteri_soyadi, Musteri_telefon, Musteri_gmail) VALUES (@prm1,@prm2,@prm3,@prm4);", bag);
            komut.Parameters.AddWithValue("@prm1", MüsteriAdiText.Text);
            komut.Parameters.AddWithValue("@prm2", MüsteriSoyadiText.Text);
            komut.Parameters.AddWithValue("@prm3", MüsteriTelefonText.Text);
            komut.Parameters.AddWithValue("@prm4", MüsteriGmailText.Text);
            komut.ExecuteNonQuery();
            bag.Close();
            MessageBox.Show("Müşteri Başarı İle Eklendi");
        }
        //Müşteri Tablosundan Kayıt Silmemize Yarar
        private void MusteriSil_Click(object sender, EventArgs e)
        {
            {
                DialogResult cevap = MessageBox.Show("Emin misin", "Silinecek", MessageBoxButtons.YesNo);
                if (cevap == DialogResult.Yes)
                {
                    SqlCommand komut = new SqlCommand("DELETE FROM Musteri WHERE Musteri_id=@prm1", bag);
                    komut.Parameters.AddWithValue("@prm1", ComboBoxMusteriSilMusteriId.SelectedItem.ToString());
                    bag.Open();
                    komut.ExecuteNonQuery();
                    label1.Visible = true;
                    label1.Text = "Silindi";
                    bag.Close();
                    MessageBox.Show("Müşteri Başarı İle Silindi");
                    MüsteriAdiText.Clear();
                    MüsteriSoyadiText.Clear();
                    MüsteriTelefonText.Clear();
                    MüsteriGmailText.Clear();
                    ComboBoxMusteriSilMusteriId.Items.Clear();
                }
            }
        }
        //ComboBoxMusteriSilMusteriId.SelectedItem'den Seçilen Musteri_id'ye Göre Göre Verileri TextBoxlara Alır
        private void ComboBoxMusteriSilMusteriId_SelectedIndexChanged(object sender, EventArgs e)
        {
            SqlDataAdapter da = new SqlDataAdapter("select * from Musteri where Musteri_id = @prm1", bag);
            da.SelectCommand.Parameters.AddWithValue("@prm1", ComboBoxMusteriSilMusteriId.SelectedItem);
            DataTable dt = new DataTable();
            da.Fill(dt);
            MüsteriAdiText.Text = dt.Rows[0][1].ToString();
            MüsteriSoyadiText.Text = dt.Rows[0][2].ToString();
            MüsteriTelefonText.Text = dt.Rows[0][3].ToString();
            MüsteriGmailText.Text = dt.Rows[0][4].ToString();
        }

        private void MusteriGuncelle_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Müşteri Bilgileri Başarı İle Güncellendi");
        }
    }
}
