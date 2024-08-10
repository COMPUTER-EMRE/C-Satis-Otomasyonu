using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Cep_Telefonu_Satış_otomasyonu
{
    public partial class CıktıAlma : Form
    {
        public CıktıAlma()
        {
            InitializeComponent();
        }

        private void Yazdır_Click(object sender, EventArgs e)
        {
            printPreviewDialog1.ShowDialog();
        }

        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            try
            {
                Font font = new Font("Verdana", 14);
                SolidBrush firca = new SolidBrush(Color.Black);
                e.Graphics.DrawString($"Tarih:{DateTime.Now.ToString("dd.MM.yyyy HH:mm:ss")}", font, firca, 50, 25);
                Font = new Font("Verdana", 14, FontStyle.Bold);
                e.Graphics.DrawString("Tanımlı Ürün", font, firca, 335, 115);
                e.Graphics.DrawString("************", font, firca, 335, 115);
                Font = new Font("Verdana", 14, FontStyle.Bold);

                e.Graphics.DrawString("Barkod No", font, firca, 60, 150);
                e.Graphics.DrawString("Fiyatı", font, firca, 60, 200);
                e.Graphics.DrawString("Miktarı", font, firca, 60, 250);
                e.Graphics.DrawString("Tutarı", font, firca, 60, 300);

                Font = new Font("Verdana", 14);
                e.Graphics.DrawString(textBox1.Text, font, firca, 200, 150);
                e.Graphics.DrawString($"{fiyat.ToString("0.00")} tl", font, firca, 200, 200);
                e.Graphics.DrawString($"{miktar.ToString()}", font, firca, 200, 250);
                e.Graphics.DrawString($"{tutar.ToString("0.00")} tl", font, firca, 200, 300);


                Font = new Font("Verdana", 14);
                e.Graphics.DrawString(textBox5.Text, font, firca, 60, 370);            }
            catch (Exception)
            {
 

            }
        }
        decimal fiyat = 0, miktar = 0, tutar = 0;

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            try
            {
                fiyat=decimal.Parse(textBox2.Text);
                miktar=decimal.Parse(textBox3.Text);
                tutar = miktar * fiyat;
                textBox4.Text= tutar.ToString();

            }
            catch (Exception)
            {


            }
        }

        private void printPreviewDialog1_Load(object sender, EventArgs e)
        {

        }
    }
}
