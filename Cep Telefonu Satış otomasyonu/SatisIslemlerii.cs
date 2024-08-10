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
    public partial class SatisIslemlerii : Form
    {
        public SatisIslemlerii()
        {
            InitializeComponent();
        }
        SqlConnection bag = new SqlConnection(@"Data Source=DESKTOP-ML2A0NI\SQLEXPRESS;Initial Catalog=""Cep Telefonu Satıs"";Integrated Security=True;Encrypt=False");
        //SatisDataGridView'e Yapılan Satışlarımızı Listelememize Yarar
        private void SatisListele_Click(object sender, EventArgs e)
        {
            SqlDataAdapter da = new SqlDataAdapter("Select * from SatisHareketi", bag);
            DataTable dt = new DataTable();
            da.Fill(dt);
            SatisDataGridView.DataSource = dt;
        }
        //Satış Yapmamızı Sağlar Ve Bunu SatisHareketi Tablomuza Ekler
        private void SatışYapbtn_Click(object sender, EventArgs e)
        {
            bag.Open();
            SqlCommand komut = new SqlCommand("Insert into SatisHareketi (AlinanUrunMiktari, SatisTarihi, AlisverisTutari, MusteriId, UrunId, PersonelId, SatisNo) Values (@prm1,@prm2,@prm3,@prm4,@prm5,@prm6,@prm7)", bag);
            komut.Parameters.AddWithValue("@prm1", SatisYapAdetText.Text);
            komut.Parameters.AddWithValue("@prm2", SatisYapTarihText.Text);
            komut.Parameters.AddWithValue("@prm3", SatisYapToplamTutarText.Text);
            komut.Parameters.AddWithValue("@prm4", SatisYapMusteriText.Text);
            komut.Parameters.AddWithValue("@prm5", SatisYapUrunIdText.Text);
            komut.Parameters.AddWithValue("@prm6", SatisYapPersonelText.Text);
            komut.Parameters.AddWithValue("@prm7", SatisYapSatisNoText.Text);
            komut.ExecuteNonQuery();
            bag.Close();
            MessageBox.Show("Satış Başarı İle Yapıldı");
        }
        //ComboBoxSatisIptalVeriCekme_SelectedIndexChanged'den Seçilen SatisNo'ya Göre Gerekli Verileri TextBoxlara Çeker
        private void ComboBoxSatisIptalVeriCekme_SelectedIndexChanged(object sender, EventArgs e)
        {
            SqlDataAdapter da = new SqlDataAdapter("select * from SatisHareketi where SatisNo = @prm1", bag);
            da.SelectCommand.Parameters.AddWithValue("@prm1", ComboBoxSatisIptalVeriCekme.SelectedItem);
            DataTable dt = new DataTable();
            da.Fill(dt);
            SatisİptalAdetText.Text = dt.Rows[0][1].ToString();
            SatisİptalSatisTarihiText.Text = dt.Rows[0][2].ToString();
            SatisİptalToplamTutarText.Text = dt.Rows[0][3].ToString();
            SatisİptalMusteriText.Text = dt.Rows[0][4].ToString();
            SatisİptalUrunText.Text = dt.Rows[0][5].ToString();
            SatisİptalPersonelText.Text = dt.Rows[0][6].ToString();
        }
        //ComboBoxSatisIptalVeriCekme'ye SatisHareketi Tablosundan SatisNo'ları Çekmemize Yarar
        private void SatisIslemlerii_Load(object sender, EventArgs e)
        {
            SatisIslemleri();
            SatisGuncelle();
        }
        //Çıkış Yapmamızı Sağlar

        //Satış Bilgilerini Güncellememize Yarar
        private void SatisGuncellebtn_Click(object sender, EventArgs e)
        {
            bag.Open();
            string kayıtguncelle = "Update SatisHareketi set AlinanUrunMiktarı=@prm1, SatisTarihi=@prm2, AlisverisTutari=@prm3, MusteriıD=@prm4, UrunId=@prm5, PersonelId=@prm6 Where SatisNo=@prm8";
            SqlCommand komut = new SqlCommand(kayıtguncelle, bag);
            komut.Parameters.AddWithValue("@prm1", SatisGuncelleAdet);
            komut.Parameters.AddWithValue("@prm2", SatisGuncelleSatihTarihi.Text);
            komut.Parameters.AddWithValue("@prm3", SatisGuncelleToplamTutar.Text);
            komut.Parameters.AddWithValue("@prm4", SatisGuncelleMusteriId.Text);
            komut.Parameters.AddWithValue("@prm5", SatisGuncelleUrunId.Text);
            komut.Parameters.AddWithValue("@prm6", SatisGuncellePersonelId.Text);
            komut.Parameters.AddWithValue("@prm7", ComboBoxSatisGuncelleVeriCekme.SelectedValue);
            MessageBox.Show("Başarı ile güncellendi");
            bag.Close();
        }

        //Guncelle ComboBox'ına Veri çekmek İçin
        private void SatisGuncelle()
        {
            SqlCommand komut = new SqlCommand("select * from Satishareketi", bag);
            bag.Open();
            SqlDataReader dr = komut.ExecuteReader();
            while (dr.Read())
            {
                ComboBoxSatisGuncelleVeriCekme.Items.Add(dr["SatisNo"]);
            }
            bag.Close();
        }
        //İptal ComboBox'ına Veri Çekmek İçin
        private void SatisIslemleri()
        {
            SqlCommand komut = new SqlCommand("select * from Satishareketi", bag);
            bag.Open();
            SqlDataReader dr = komut.ExecuteReader();
            while (dr.Read())
            {
                ComboBoxSatisIptalVeriCekme.Items.Add(dr["SatisNo"]);
            }
            bag.Close();
        }
        //Çıkış Kodu
        private void Cikisptb_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        //Satış İptal Kodu
        private void Satisİptalbtn_Click(object sender, EventArgs e)
        {
            {
                DialogResult cevap = MessageBox.Show("Emin misin", "Silinecek", MessageBoxButtons.YesNo);
                if (cevap == DialogResult.Yes)
                {
                    SqlCommand komut = new SqlCommand("DELETE FROM SatisHareketi WHERE SatisNo=@prm1", bag);
                    komut.Parameters.AddWithValue("@prm1", ComboBoxSatisIptalVeriCekme.SelectedItem.ToString());
                    bag.Open();
                    komut.ExecuteNonQuery();
                    bag.Close();
                    MessageBox.Show("Yeni Ürün Başarı İle Silindi", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }
    }
}
