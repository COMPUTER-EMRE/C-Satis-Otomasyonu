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
    public partial class Filtreleme : Form
    {
        public Filtreleme()
        {
            InitializeComponent();
        }

        SqlConnection bag = new SqlConnection(@"Data Source=DESKTOP-ML2A0NI\SQLEXPRESS;Initial Catalog=""Cep Telefonu Satıs"";Integrated Security=True;Encrypt=False");

        private void Filtreleme_1Satisbtn_Click_1(object sender, EventArgs e)
        {
            SqlConnection bag = new SqlConnection(@"Data Source=DESKTOP-ML2A0NI\SQLEXPRESS;Initial Catalog=""Cep Telefonu Satıs"";Integrated Security=True;Encrypt=False");
            SqlDataAdapter da = new SqlDataAdapter("SELECT TOP 1 * FROM Urun U JOIN Ozellikler O ON U.OzellikId=O.Ozellik_Id ORDER BY U.Fiyat DESC;", bag);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
        }

        private void UyarıLabel_Click_1(object sender, EventArgs e)
        {
            MessageBox.Show("Buttonların Üstüne Tıklamanız Yeterlidir, TextBoxlara Veri Girmenize Gerek Yoktur");
        }

        private void Cikisptb_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void Gerigelptb_Click(object sender, EventArgs e)
        {
            Ana_Sayfaa ana_sayfaa = new Ana_Sayfaa();
            ana_sayfaa.ShowDialog();
        }
    }
}
