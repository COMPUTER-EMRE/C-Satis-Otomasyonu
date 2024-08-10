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
    public partial class OzellikIslemlerii : Form
    {
        public OzellikIslemlerii()
        {
            InitializeComponent();
        }
        SqlConnection bag = new SqlConnection(@"Data Source=DESKTOP-ML2A0NI\SQLEXPRESS;Initial Catalog=""Cep Telefonu Satıs"";Integrated Security=True;Encrypt=False");
        //Ozellikler Tablosunu OzellikDataGridView'de Listelememize Yarar
        private void OzellilListelebtn_Click(object sender, EventArgs e)
        {
            SqlDataAdapter da = new SqlDataAdapter("Select * from Ozellikler", bag);
            DataTable dt = new DataTable();
            da.Fill(dt);
            OzellikDataGridView.DataSource = dt;
        }
        //comboBoxOzellikSilGuncelleOzellikId'den Seçilen Veriye Göre Özellik Silmemize Yarar
        private void comboBoxOzellikSilGuncelleOzellikId_SelectedIndexChanged(object sender, EventArgs e)
        {
            SqlDataAdapter da = new SqlDataAdapter("select * from Ozellikler where Ozellik_Id = @prm1", bag);
            da.SelectCommand.Parameters.AddWithValue("@prm1", comboBoxOzellikSilGuncelleOzellikId.SelectedItem);
            DataTable dt = new DataTable();
            da.Fill(dt);
            OzellikEkleSilGuncelleEkranBoyutu.Text = dt.Rows[0][1].ToString();
            OzellikEkleSilGuncelleDahiliHafiza.Text = dt.Rows[0][2].ToString();
            OzellikEkleSilGuncelleRam.Text = dt.Rows[0][3].ToString();
            OzellikEkleSilGuncellePilKapasitesi.Text = dt.Rows[0][4].ToString();
            OzellikEkleSilGuncelleCozunurluk.Text = dt.Rows[0][5].ToString();
            OzellikEkleSilGuncelleIslemci.Text = dt.Rows[0][6].ToString();
        }
        //comboBoxOzellikSilGuncelleOzellikId'ye Özellik_Id'leri Çekmemize Yarar
        private void OzellikIslemlerii_Load(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand("Select * from Ozellikler", bag);
            bag.Open();
            SqlDataReader dr = komut.ExecuteReader();
            while (dr.Read())
            {
                comboBoxOzellikSilGuncelleOzellikId.Items.Add(dr["Ozellik_Id"]);
            }
            bag.Close();
        }
        //Ozellikler Tablomuza Yeni Özellikler Eklememize Yarar
        private void OzellikEklebtn_Click(object sender, EventArgs e)
        {
                bag.Open();
                SqlCommand komut = new SqlCommand("INSERT INTO Ozellikler (EkranBoyutu, DahiliHafiza, Ram, PilKapasitesi, KameraCozunurlugu, Islemci) VALUES (@prm1,@prm2,@prm3,@prm4,@prm5,@prm6)", bag);
                komut.Parameters.AddWithValue("@prm1", OzellikEkleSilGuncelleEkranBoyutu.Text);
                komut.Parameters.AddWithValue("@prm2", OzellikEkleSilGuncelleDahiliHafiza.Text);
                komut.Parameters.AddWithValue("@prm3", OzellikEkleSilGuncelleRam.Text);
                komut.Parameters.AddWithValue("@prm4", OzellikEkleSilGuncellePilKapasitesi.Text);
                komut.Parameters.AddWithValue("@prm5", OzellikEkleSilGuncelleCozunurluk.Text);
                komut.Parameters.AddWithValue("@prm6", OzellikEkleSilGuncelleIslemci.Text);
                komut.ExecuteNonQuery();
                bag.Close();
                MessageBox.Show("Yeni Özellik Başarı İle Eklendi");
        }
        //Ozellikler Tablomuzdan Özellik Silmemize Yarar
        private void OzellikSilbtn_Click(object sender, EventArgs e)
        {
            {
                DialogResult cevap = MessageBox.Show("Emin misin", "Silinecek", MessageBoxButtons.YesNo);
                if (cevap == DialogResult.Yes)
                {
                    SqlCommand komut = new SqlCommand("DELETE FROM Ozellikler WHERE Ozellik_Id=@prm1", bag);
                    komut.Parameters.AddWithValue("@prm1", comboBoxOzellikSilGuncelleOzellikId.SelectedItem.ToString());
                    bag.Open();
                    komut.ExecuteNonQuery();
                    bag.Close();
                    MessageBox.Show("Ürün Başarı İle Silindi");
                    OzellikEkleSilGuncelleEkranBoyutu.Clear();
                    OzellikEkleSilGuncelleDahiliHafiza.Clear();
                    OzellikEkleSilGuncelleRam.Clear();
                    OzellikEkleSilGuncellePilKapasitesi.Clear();
                    OzellikEkleSilGuncelleCozunurluk.Clear();
                    OzellikEkleSilGuncelleIslemci.Clear();
                }
            }
        }
        //Ozellikler Tablomuzdan Özellik Bilgilerini Güncellememize Yarar
        private void OzellikGuncellebtn_Click(object sender, EventArgs e)
        {
            DialogResult cevap = MessageBox.Show("Emin misin", "Güncellenecek", MessageBoxButtons.YesNo);
            if (cevap == DialogResult.Yes)
            {
            bag.Open();
            SqlCommand komut = new SqlCommand("UPDATE Ozellikler SET EkranBoyutu =@prm1, DahiliHafiza =@prm2, RAM =@prm3, PilKapasitesi =@prm4, KameraCozunurlugu=@prm5, Islemci=@prm6', Ozellik_Id =@prm7 WHERE Islemci=@prm6 ", bag);
            komut.Parameters.AddWithValue("@prm1", OzellikEkleSilGuncelleEkranBoyutu.Text);
            komut.Parameters.AddWithValue("@prm2", OzellikEkleSilGuncelleDahiliHafiza.Text);
            komut.Parameters.AddWithValue("@prm3", OzellikEkleSilGuncelleRam.Text);
            komut.Parameters.AddWithValue("@prm4", OzellikEkleSilGuncellePilKapasitesi.Text);
            komut.Parameters.AddWithValue("@prm5", OzellikEkleSilGuncelleCozunurluk.Text);
            komut.Parameters.AddWithValue("@prm6", OzellikEkleSilGuncelleIslemci.Text);
            komut.Parameters.AddWithValue("@prm7", comboBoxOzellikSilGuncelleOzellikId.SelectedValue.ToString());
            komut.ExecuteNonQuery();
            bag.Close();
            MessageBox.Show("Özellik Başarıyla Güncellendi");
            OzellikEkleSilGuncelleEkranBoyutu.Clear();
            OzellikEkleSilGuncelleDahiliHafiza.Clear();
            OzellikEkleSilGuncelleRam.Clear();
            OzellikEkleSilGuncellePilKapasitesi.Clear();
            OzellikEkleSilGuncelleCozunurluk.Clear();
            OzellikEkleSilGuncelleIslemci.Clear();
            }
            MessageBox.Show("Ürün Başarı ile Güncellendi");
        }
        //Çıkış Yapmamızı Sağlar
        private void Cikisptb_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
