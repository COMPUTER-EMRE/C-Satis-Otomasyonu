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
    public partial class GrafikIslemlerii : Form
    {
        public GrafikIslemlerii()
        {
            InitializeComponent();
        }
        SqlConnection bag = new SqlConnection(@"Data Source=DESKTOP-ML2A0NI\SQLEXPRESS;Initial Catalog=""Cep Telefonu Satıs"";Integrated Security=True;Encrypt=False");
        //SatisHareketi Tablomuzdan En Çok Satılan Ve En Az Satılan Urun Id'leri' Alarak Grafikte Göstermemize Yarar.
        private void GrafikIslemlerii_Load(object sender, EventArgs e)
        {
        //    DataTable dt = new DataTable();
        //    bag.Open();
        //    SqlDataAdapter adtr= new SqlDataAdapter("Select UrunId,sum(AlinanUrunMiktari) From SatisHareketi group by GROUPING sets(UrunId) Order by Sum(AlinanUrunMiktari)", bag);
        //    adtr.Fill(dt);
        //    dataGridView1.DataSource = dt;
        //    bag.Close();
        //    lblEnAz.Text = "";
        //    lblEnCok.Text = "";
        //    lblEnAz.Text = "Urun Id" + dataGridView1.Rows[dataGridView1.Rows.Count - 2].Cells[0].Value+"\ntoplamda"+ dataGridView1.Rows[dataGridView1.Rows.Count - 2].Cells[1].Value+"tane satıldı";
        //    lblEnCok.Text = "Urun Id" + dataGridView1.Rows[dataGridView1.Rows.Count - 2].Cells[0].Value + "\ntoplamda" + dataGridView1.Rows[0].Cells[1].Value + "tane satıldı";

        //    for (int i=0; i<dataGridView1.Rows.Count-1; i++)
        //    {
        //        chart1.Series["Satış Adetleri"].Points.AddXY(dataGridView1.Rows[i].Cells[0].Value.ToString(), dataGridView1.Rows[i].Cells[1].Value.ToString());
        //    }
        }
    }
}
