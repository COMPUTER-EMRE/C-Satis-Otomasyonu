using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Cep_Telefonu_Satış_otomasyonu
{
    public partial class UrunIslemlerii : Form
    {
        public UrunIslemlerii()
        {
            InitializeComponent();
        }
        SqlConnection bag = new SqlConnection(@"Data Source=DESKTOP-ML2A0NI\SQLEXPRESS;Initial Catalog=""Cep Telefonu Satıs"";Integrated Security=True;Encrypt=False");
        private void UrunListelebtn_Click(object sender, EventArgs e)
        {
            UrunListele();
        }
        //UrunDataGridView'e Ürünlerimiiz Listelememize Yarar
        public void UrunListele()
        {
            SqlDataAdapter da = new SqlDataAdapter("Select * from Urun", bag);
            DataTable dt = new DataTable();
            da.Fill(dt);
            UrunDataGridView.DataSource = dt;
        }
        //Urun Tablomuza Veri Eklememizi Sağlar
        private void UrunEklebtn_Click(object sender, EventArgs e)
        {
            bag.Open();
            SqlCommand komut = new SqlCommand("Insert into Urun (Marka, Model, Fiyat, TedarikciId) Values (@prm1,@prm2,@prm3,@prm4)", bag);
            komut.Parameters.AddWithValue("@prm1", UrunEkleMarkaText.Text);
            komut.Parameters.AddWithValue("@prm2", UrunEkleModelText.Text);
            komut.Parameters.AddWithValue("@prm3", UrunEkleFiyatText.Text);
            komut.Parameters.AddWithValue("@prm4", UrunEkleTedarikciIdText.Text);
            komut.ExecuteNonQuery();
            bag.Close();
            MessageBox.Show("Yeni Ürün Başarı İle Eklendi", "Bilgi", MessageBoxButtons.OK,MessageBoxIcon.Information);
            UrunListele();
        }
        //Urun Tablomuzdan Veri Silmemizi Sağlar
        private void UrunSilbtn_Click(object sender, EventArgs e)
        {
            {
                DialogResult cevap = MessageBox.Show("Emin misin", "Silinecek", MessageBoxButtons.YesNo);
                if (cevap == DialogResult.Yes)
                {
                    SqlCommand komut = new SqlCommand("DELETE FROM Urun WHERE UrunId=@prm1", bag);
                    komut.Parameters.AddWithValue("@prm1", comboBoxSilUrunId.SelectedItem.ToString());
                    bag.Open();
                    komut.ExecuteNonQuery();
                    bag.Close();
                    MessageBox.Show("Yeni Ürün Başarı İle Silindi", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    UrunListele();
                }
            }
        }
        //comboBoxSilUrunId_SelectedIndexChanged'den Bir Id Seçtiğimizde O Id'nin verilerini TextBoxlara Çeker. 
        private void comboBoxSilUrunId_SelectedIndexChanged(object sender, EventArgs e)
        {
            SqlDataAdapter da = new SqlDataAdapter("select * from Urun where UrunId = @prm1", bag);
            da.SelectCommand.Parameters.AddWithValue("@prm1", comboBoxSilUrunId.SelectedItem);
            DataTable dt = new DataTable();
            da.Fill(dt);
            UrunSilMarkaText.Text = dt.Rows[0][1].ToString();
            UrunSilModelText.Text = dt.Rows[0][2].ToString();
            UrunSilFiyatText.Text = dt.Rows[0][3].ToString();
            UrunSilTedarikciIdText.Text = dt.Rows[0][4].ToString();
        }
        //İçine Gerekli Metotları Atayıp Çalıştırmamızı Sağlar
        private void UrunIslemlerii_Load(object sender, EventArgs e)
        {
            UrunIslemleriSilComboBox();
            UrunIslemleriGuncelleComboBox();
        }
        //ComboBoxUrunGuncelleUrunId_SelectedIndexChanged'den Bir Id Seçtiğimizde O Id'nin verilerini TextBoxlara Çeker. 
        private void ComboBoxUrunGuncelleUrunId_SelectedIndexChanged(object sender, EventArgs e)
        {
            SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM Urun WHERE UrunId = @prm1", bag);
            da.SelectCommand.Parameters.AddWithValue("@prm1", ComboBoxUrunGuncelleUrunId.SelectedItem);
            DataTable dt = new DataTable();
            da.Fill(dt);
            UrunGuncelleMarkaText.Text = dt.Rows[0][1].ToString();
            UrunGuncelleModelText.Text = dt.Rows[0][2].ToString();
            UrunGuncelleFiyatText.Text = dt.Rows[0][3].ToString();
            UrunGuncelleTedarikciIdText.Text = dt.Rows[0][4].ToString();
        }
        //Urun Guncellememize Yarar
        private void UrunGuncellebtn_Click(object sender, EventArgs e)
        {
            bag.Open();
            string kayıtguncelle = "Update Urun set Marka=@prm1, Model=@prm2, Fiyat=@prm3, TedarikciId=@prm4, OzellikId=@prm5 Where UrunId=@prm6";
            SqlCommand komut = new SqlCommand(kayıtguncelle, bag);
            komut.Parameters.AddWithValue("@prm1", UrunGuncelleMarkaText.Text);
            komut.Parameters.AddWithValue("@prm2", UrunGuncelleModelText.Text);
            komut.Parameters.AddWithValue("@prm3", UrunGuncelleFiyatText.Text);
            komut.Parameters.AddWithValue("@prm4", UrunGuncelleTedarikciIdText.Text);
            komut.Parameters.AddWithValue("@prm5", UrunGuncelleOzellikText.Text);
            komut.Parameters.AddWithValue("@prm6", ComboBoxUrunGuncelleUrunId.SelectedValue);
            MessageBox.Show("Başarı ile güncellendi");
            bag.Close();
            UrunListele();
        }
        //Urun Tablomuzdan UrunIslemleriSilComboBox'a Veri Çekmemizi Sağlar
        public void UrunIslemleriSilComboBox()
        {
            SqlCommand komut = new SqlCommand("Select * from Urun", bag);
            bag.Open();
            SqlDataReader dr = komut.ExecuteReader();
            while (dr.Read())
            {
                comboBoxSilUrunId.Items.Add(dr["UrunId"]);
            }
            bag.Close();
        }
        //Urun Tablomuzdan UrunIslemleriGuncelleComboBox'a Veri Çekmemizi Sağlar
        public void UrunIslemleriGuncelleComboBox()
        {
            using (SqlConnection bag = new SqlConnection(@"Data Source=DESKTOP-ML2A0NI\SQLEXPRESS;Initial Catalog=""Cep Telefonu Satıs"";Integrated Security=True;Encrypt=False"))
            {
                bag.Open();
                using (SqlCommand komut = new SqlCommand("SELECT * FROM Urun", bag))
                {
                    SqlDataReader reader = komut.ExecuteReader();
                    while (reader.Read())
                    {
                        ComboBoxUrunGuncelleUrunId.Items.Add(reader["UrunId"]);
                    }
                }
            }
        }
        //UrunEkle TextBoxlarımızı Temizlememize Yarar
        private void UrunEkleTemizleLinkLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            UrunEkleMarkaText.Clear();
            UrunEkleModelText.Clear();
            UrunEkleFiyatText.Clear();
            UrunEkleTedarikciIdText.Clear();
        }
        //UrunSil TextBoxlarımızı Temizlememize Yarar
        private void UrunSilTemizleLinkLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            UrunSilMarkaText.Clear();
            UrunSilModelText.Clear();
            UrunSilFiyatText.Clear();
            UrunSilTedarikciIdText.Clear();
        }
        //UrunGuncelle TextBoxlarımızı Temizlememize Yarar
        private void UrunGuncelleTemizleLinkLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            UrunGuncelleMarkaText.Clear();
            UrunGuncelleModelText.Clear();
            UrunGuncelleFiyatText.Clear();
            UrunGuncelleTedarikciIdText.Clear();
        }
        //Çıkış Butonumuzu Çalıştırmamıza Yarar
        private void Cikisptb_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void UrunGuncelleFiyatText_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
