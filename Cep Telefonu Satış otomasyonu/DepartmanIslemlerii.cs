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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Cep_Telefonu_Satış_otomasyonu
{
    public partial class DepartmanIslemlerii : Form
    {
        public DepartmanIslemlerii()
        {
            InitializeComponent();
        }
        SqlConnection bag = new SqlConnection(@"Data Source=DESKTOP-ML2A0NI\SQLEXPRESS;Initial Catalog=""Cep Telefonu Satıs"";Integrated Security=True;Encrypt=False");
        //Departman Tablomuza Yeni Departman Girmemize Yarar
        private void DepartmanIsleriEklebtnn_Click(object sender, EventArgs e)
        {
            bag.Open();
            SqlCommand komut = new SqlCommand("Insert into Departman (Departman_Adi) Values (@prm1)", bag);
            komut.Parameters.AddWithValue("@prm1", DepartmanText.Text);
            komut.ExecuteNonQuery();
            bag.Close();
            MessageBox.Show("Departman Başarı İle Eklendi");
        }
        //Departman Tablomuzu DepartmanDataGridView'de Listelememize Yarar
        private void DepartmanListelee_Click(object sender, EventArgs e)
        {
            SqlDataAdapter da = new SqlDataAdapter("Select * from Departman", bag);
            DataTable dt = new DataTable();
            da.Fill(dt);
            DepartmanDataGridView.DataSource = dt;
        }
        //DepartmanIdGetircomboBox'dan Seçilen Departman_id'ye Ait Olan Departman İsmini TextBox'a Çeker
        private void DepartmanIdGetircomboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            SqlDataAdapter da = new SqlDataAdapter("select * from Departman where Departman_id = @prm1", bag);
            da.SelectCommand.Parameters.AddWithValue("@prm1", DepartmanIdGetircomboBox.SelectedItem);
            DataTable dt = new DataTable();
            da.Fill(dt);
            DepartmanText.Text = dt.Rows[0][1].ToString();
        }
        //Departman_id'leri DepartmanIdGetircomboBox'a Çekmemize Yarar
        private void DepartmanIslemlerii_Load(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand("Select * from Departman", bag);
            bag.Open();
            SqlDataReader dr = komut.ExecuteReader();
            while (dr.Read())
            {
                DepartmanIdGetircomboBox.Items.Add(dr["Departman_id"]);
            }
            bag.Close();
        }
        //Departmanı Seçilen id'ye Göre Silmemize Yarar
        private void DepartmanIsleriSilbtnn_Click(object sender, EventArgs e)
        {
            {
                DialogResult cevap = MessageBox.Show("Emin misin", "Silinecek", MessageBoxButtons.YesNo);
                if (cevap == DialogResult.Yes)
                {
                    SqlCommand komut = new SqlCommand("DELETE FROM Departman WHERE Departman_id=@prm1", bag);
                    komut.Parameters.AddWithValue("@prm1", DepartmanIdGetircomboBox.SelectedItem.ToString());
                    bag.Open();
                    komut.ExecuteNonQuery();
                    bag.Close();
                    MessageBox.Show("Departman Başarı İle Silindi");
                }
            }
        }

        //Departman Guncellememize Yarar
        private void DepartmanGuncellebtn_Click(object sender, EventArgs e)
        {
            bag.Open();
            SqlCommand komut = new SqlCommand("update  SatisHareketi set AlinanUrunMiktari=@prm1, SatisTarihi=@prm2, AlisverisTutari=@prm3, MusteriId=@prm4, urunId=@prm5, PersonelId=@prm6 Where SatisNo=@prm7", bag);
            komut.Parameters.AddWithValue("@prm1", DepartmanText.Text);
            komut.ExecuteNonQuery();
            bag.Close();
            MessageBox.Show("Güncellendi");
        }
        //Çıkış Yapmamızı Sağlar
        private void pictureBox2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        
    }
}
