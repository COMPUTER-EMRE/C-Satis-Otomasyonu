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
    public partial class Ana_Sayfaa : Form
    {
        public Ana_Sayfaa()
        {
            InitializeComponent();
        }
        //FiltrelemeIslemleri Sayfasını Ana Sayfadaki EKLEPANEL İsimli Panelimize Ekler.
        public void FiltrelemeGetir(Form frm)
        {
            EklePanell.Controls.Clear();
            frm.Dock = DockStyle.Fill;
            frm.TopLevel = false;
            EklePanell.Controls.Add(frm);
            frm.Show();
        }
        //DepartmanIslemlerii Sayfasını Ana Sayfadaki EKLEPANEL İsimli Panelimize Ekler.
        public void DepartmanGetir(Form frm)
        {
            EklePanell.Controls.Clear();
            frm.Dock = DockStyle.Fill;
            frm.TopLevel = false;
            EklePanell.Controls.Add(frm);
            frm.Show();
        }
        //MusteriIslemlerii Sayfasını Ana Sayfadaki EKLEPANEL İsimli Panelimize Ekler.
        public void MusteriGetir(Form frm)
        {
            EklePanell.Controls.Clear();
            frm.Dock = DockStyle.Fill;
            frm.TopLevel = false;
            EklePanell.Controls.Add(frm);
            frm.Show();
        }
        //OzellikIslemlerii Sayfasını Ana Sayfadaki EKLEPANEL İsimli Panelimize Ekler.
        public void OzellikGetir(Form frm)
        {
            EklePanell.Controls.Clear();
            frm.Dock = DockStyle.Fill;
            frm.TopLevel = false;
            EklePanell.Controls.Add(frm);
            frm.Show();
        }
        //UrunIslemlerii Sayfasını Ana Sayfadaki EKLEPANEL İsimli Panelimize Ekler.
        public void UrunGetir(Form frm)
        {
            EklePanell.Controls.Clear();
            frm.Dock = DockStyle.Fill;
            frm.TopLevel = false;
            EklePanell.Controls.Add(frm);
            frm.Show();
        }
        //SatisIslemlerii Sayfasını Ana Sayfadaki EKLEPANEL İsimli Panelimize Ekler.
        public void SatisGetir(Form frm)
        {
            EklePanell.Controls.Clear();
            frm.Dock = DockStyle.Fill;
            frm.TopLevel = false;
            EklePanell.Controls.Add(frm);
            frm.Show();
        }
        //Filtreleme Butonunu Çalıştır ve Filtreleme Sayfasını Açar
        private void button1_Click(object sender, EventArgs e)
        {
            FiltrelemeGetir(new FiltrelemeIslemleri());
        }

        //private void UrunListelebtn_Click(object sender, EventArgs e)
        //{
        //    SqlConnection bag = new SqlConnection(@"Data Source=DESKTOP-ML2A0NI\SQLEXPRESS;Initial Catalog=""Cep Telefonu Satıs"";Integrated Security=True;Encrypt=False");
        //    SqlDataAdapter da = new SqlDataAdapter("Select * from Urun", bag);
        //    DataTable dt = new DataTable();
        //    da.Fill(dt);
        //    dataGridWiewListele.DataSource = dt;
        //}

        //private void SatisListelebtn_Click(object sender, EventArgs e)
        //{
        //    SqlConnection bag = new SqlConnection(@"Data Source=DESKTOP-ML2A0NI\SQLEXPRESS;Initial Catalog=""Cep Telefonu Satıs"";Integrated Security=True;Encrypt=False");
        //    SqlDataAdapter da = new SqlDataAdapter("Select * from SatisHareketi", bag);
        //    DataTable dt = new DataTable();
        //    da.Fill(dt);
        //    dataGridWiewListele.DataSource = dt;
        //}
        //UrunIslemleribtn Butonunu Çalıştır ve UrunIslemleri Sayfasını Açar
        private void UrunIslemleribtn_Click(object sender, EventArgs e)
        {
            UrunGetir(new UrunIslemlerii());
        }
        //SatisIslemleribtn Butonunu Çalıştır ve SatisIslemleri Sayfasını Açar
        private void SatisIslemleribtn_Click(object sender, EventArgs e)
        {
            SatisGetir(new SatisIslemlerii());
        }
        //DepartmanIslemleribtn Butonunu Çalıştır ve DepartmanIslemleri Sayfasını Açar
        private void DepartmanIslemleribtn_Click(object sender, EventArgs e)
        {
            DepartmanGetir(new DepartmanIslemlerii());
        }
        //MusteriIslemleribtn Butonunu Çalıştır ve MusteriIslemleri Sayfasını Açar
        private void MusteriIslemleribtn_Click(object sender, EventArgs e)
        {
            MusteriGetir(new MusteriIslemlerii());
        }
        //OzellikIslemleribtn Butonunu Çalıştır ve OzellikIslemleri Sayfasını Açar
        private void OzellikIslemleribtn_Click(object sender, EventArgs e)
        {
            OzellikGetir(new OzellikIslemlerii());
        }
        //Uygulamadan Çıkış Yapmamızı Sağlar
        private void pictureBox7_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        //Timer Komutu ile Anlık Tarih Ve Saati almamızı Sağlar
        private void Ana_Sayfaa_Load(object sender, EventArgs e)
        {
            AnlikTarihVeSaattimer.Start();
        }
        //Anlık Tarih Ve Saati Label'da Görünür Yapmamızı Sağlar
        private void AnlikTarihVeSaattimer_Tick(object sender, EventArgs e)
        {
            AnlikTarihVeSaatlabel.Text = DateTime.Now.ToString();
        }
        //Grafik Sayfamızı Başka Bir Sayfa Olarak Açmamızı Sağlar, Panel'e Eklemeden
        private void Grafikbtn_Click(object sender, EventArgs e)
        {
            GrafikIslemlerii grafikIslemlerii = new GrafikIslemlerii();
            grafikIslemlerii.Show();
        }
    }
}
