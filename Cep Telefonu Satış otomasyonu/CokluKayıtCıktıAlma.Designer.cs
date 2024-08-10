namespace Cep_Telefonu_Satış_otomasyonu
{
    partial class CokluKayıtCıktıAlma
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CokluKayıtCıktıAlma));
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.Yazdırbtn = new System.Windows.Forms.Button();
            this.printDocument1 = new System.Drawing.Printing.PrintDocument();
            this.printPreviewDialog1 = new System.Windows.Forms.PrintPreviewDialog();
            this.OnIzlemebtn = new System.Windows.Forms.Button();
            this.BarkodNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.UrunAdi = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Fiyatı = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Miktar = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Tutar = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dataGridView1.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.dataGridView1.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.BarkodNo,
            this.UrunAdi,
            this.Fiyatı,
            this.Miktar,
            this.Tutar});
            this.dataGridView1.Location = new System.Drawing.Point(1, -1);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.Size = new System.Drawing.Size(562, 311);
            this.dataGridView1.TabIndex = 0;
            // 
            // Yazdırbtn
            // 
            this.Yazdırbtn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.Yazdırbtn.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.Yazdırbtn.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.Yazdırbtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Yazdırbtn.Font = new System.Drawing.Font("Verdana", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.Yazdırbtn.ForeColor = System.Drawing.Color.White;
            this.Yazdırbtn.ImageAlign = System.Drawing.ContentAlignment.BottomLeft;
            this.Yazdırbtn.Location = new System.Drawing.Point(353, 330);
            this.Yazdırbtn.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Yazdırbtn.Name = "Yazdırbtn";
            this.Yazdırbtn.Size = new System.Drawing.Size(153, 81);
            this.Yazdırbtn.TabIndex = 154;
            this.Yazdırbtn.Text = "Yazdır";
            this.Yazdırbtn.UseVisualStyleBackColor = true;
            this.Yazdırbtn.Click += new System.EventHandler(this.Yazdırbtn_Click);
            // 
            // printDocument1
            // 
            this.printDocument1.PrintPage += new System.Drawing.Printing.PrintPageEventHandler(this.printDocument1_PrintPage);
            // 
            // printPreviewDialog1
            // 
            this.printPreviewDialog1.AutoScrollMargin = new System.Drawing.Size(0, 0);
            this.printPreviewDialog1.AutoScrollMinSize = new System.Drawing.Size(0, 0);
            this.printPreviewDialog1.ClientSize = new System.Drawing.Size(400, 300);
            this.printPreviewDialog1.Document = this.printDocument1;
            this.printPreviewDialog1.Enabled = true;
            this.printPreviewDialog1.Icon = ((System.Drawing.Icon)(resources.GetObject("printPreviewDialog1.Icon")));
            this.printPreviewDialog1.Name = "printPreviewDialog1";
            this.printPreviewDialog1.Text = "Baskı önizleme";
            this.printPreviewDialog1.Visible = false;
            // 
            // OnIzlemebtn
            // 
            this.OnIzlemebtn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.OnIzlemebtn.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.OnIzlemebtn.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.OnIzlemebtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.OnIzlemebtn.Font = new System.Drawing.Font("Verdana", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.OnIzlemebtn.ForeColor = System.Drawing.Color.White;
            this.OnIzlemebtn.ImageAlign = System.Drawing.ContentAlignment.BottomLeft;
            this.OnIzlemebtn.Location = new System.Drawing.Point(71, 339);
            this.OnIzlemebtn.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.OnIzlemebtn.Name = "OnIzlemebtn";
            this.OnIzlemebtn.Size = new System.Drawing.Size(153, 81);
            this.OnIzlemebtn.TabIndex = 155;
            this.OnIzlemebtn.Text = "Ön İzleme";
            this.OnIzlemebtn.UseVisualStyleBackColor = true;
            this.OnIzlemebtn.Click += new System.EventHandler(this.OnIzlemebtn_Click);
            // 
            // BarkodNo
            // 
            this.BarkodNo.HeaderText = "Column1";
            this.BarkodNo.MinimumWidth = 6;
            this.BarkodNo.Name = "BarkodNo";
            // 
            // UrunAdi
            // 
            this.UrunAdi.HeaderText = "UrunAdi";
            this.UrunAdi.MinimumWidth = 6;
            this.UrunAdi.Name = "UrunAdi";
            // 
            // Fiyatı
            // 
            this.Fiyatı.HeaderText = "Fiyatı";
            this.Fiyatı.MinimumWidth = 6;
            this.Fiyatı.Name = "Fiyatı";
            // 
            // Miktar
            // 
            this.Miktar.HeaderText = "Miktar";
            this.Miktar.MinimumWidth = 6;
            this.Miktar.Name = "Miktar";
            // 
            // Tutar
            // 
            this.Tutar.HeaderText = "Tutar";
            this.Tutar.MinimumWidth = 6;
            this.Tutar.Name = "Tutar";
            // 
            // CokluKayıtCıktıAlma
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.ClientSize = new System.Drawing.Size(559, 450);
            this.Controls.Add(this.OnIzlemebtn);
            this.Controls.Add(this.Yazdırbtn);
            this.Controls.Add(this.dataGridView1);
            this.Name = "CokluKayıtCıktıAlma";
            this.Text = "Çoklu Kayıt Yazdırma";
            this.Load += new System.EventHandler(this.CokluKayıtCıktıAlma_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        public System.Windows.Forms.Button Yazdırbtn;
        private System.Drawing.Printing.PrintDocument printDocument1;
        private System.Windows.Forms.PrintPreviewDialog printPreviewDialog1;
        public System.Windows.Forms.Button OnIzlemebtn;
        private System.Windows.Forms.DataGridViewTextBoxColumn BarkodNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn UrunAdi;
        private System.Windows.Forms.DataGridViewTextBoxColumn Fiyatı;
        private System.Windows.Forms.DataGridViewTextBoxColumn Miktar;
        private System.Windows.Forms.DataGridViewTextBoxColumn Tutar;
    }
}