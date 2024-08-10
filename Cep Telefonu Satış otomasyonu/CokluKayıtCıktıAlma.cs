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
    public partial class CokluKayıtCıktıAlma : Form
    {
        public CokluKayıtCıktıAlma()
        {
            InitializeComponent();
        }
        SqlConnection bag = new SqlConnection(@"Data Source=DESKTOP-ML2A0NI\SQLEXPRESS;Initial Catalog=""Cep Telefonu Satıs"";Integrated Security=True;Encrypt=False");
        private void CokluKayıtCıktıAlma_Load(object sender, EventArgs e)
        {
            //SqlDataAdapter da = new SqlDataAdapter("Select * from SatisHareketi", bag);
            //DataTable dt = new DataTable();
            //da.Fill(dt);
            //dataGridView1.DataSource = dt;
        }
        private void OnIzlemebtn_Click(object sender, EventArgs e)
        {
            printPreviewDialog1.ShowDialog();
        }

        private void Yazdırbtn_Click(object sender, EventArgs e)
        {
            printDocument1.Print();
        }

        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            try
            {
                Font font = new Font("Verdana", 14);
                SolidBrush firca = new SolidBrush(Color.Black);
                e.Graphics.DrawString($"Tarih:{DateTime.Now.ToString("dd.MM.yyyy")}",font,firca,60,25);
                Font = new Font("Verdana", 14);
                e.Graphics.DrawString("Ürün Listesi", font, firca, 335, 115);
                e.Graphics.DrawString("------------", font, firca, 335, 115);
                Font = new Font("Verdana", 14);

                e.Graphics.DrawString("Barkod No", font, firca, 60, 115);
                e.Graphics.DrawString("Ürün Adı", font, firca, 280, 170);
                e.Graphics.DrawString("Fiyatı", font, firca, 420, 170);
                e.Graphics.DrawString("Miktarı", font, firca, 550, 170);
                e.Graphics.DrawString("Tutarı", font, firca, 700, 170);
                int i = 0;
                int y = 210;
                while(i<dataGridView1.Rows.Count-2)
                {
                    font = new Font("Verdana", 14);
                    e.Graphics.DrawString(dataGridView1.Rows[i].Cells[0].Value.ToString(), font, firca, 60, y);
                    e.Graphics.DrawString(dataGridView1.Rows[i].Cells[1].Value.ToString(), font, firca, 280, y);
                    e.Graphics.DrawString(dataGridView1.Rows[i].Cells[2].Value.ToString(), font, firca, 420, y);
                    e.Graphics.DrawString(dataGridView1.Rows[i].Cells[3].Value.ToString(), font, firca, 550, y);
                    e.Graphics.DrawString(dataGridView1.Rows[i].Cells[4].Value.ToString(), font, firca, 700, y);
                }
            }
            catch (Exception)
            {

            }
        }
    }
}
