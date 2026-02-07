namespace Tugas_Besar_PBO.NET.view
{
    partial class Pengembalian_Buku
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
            this.cbPinjam = new System.Windows.Forms.ComboBox();
            this.dtKembali = new System.Windows.Forms.DateTimePicker();
            this.txtDenda = new System.Windows.Forms.TextBox();
            this.cbKondisi = new System.Windows.Forms.ComboBox();
            this.btnKembali = new System.Windows.Forms.Button();
            this.dgvPengembalian = new System.Windows.Forms.DataGridView();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lblTenggat = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPengembalian)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // cbPinjam
            // 
            this.cbPinjam.DisplayMember = "\"info\";";
            this.cbPinjam.FormattingEnabled = true;
            this.cbPinjam.Location = new System.Drawing.Point(197, 267);
            this.cbPinjam.Name = "cbPinjam";
            this.cbPinjam.Size = new System.Drawing.Size(121, 21);
            this.cbPinjam.TabIndex = 0;
            this.cbPinjam.ValueMember = "\"id_pinjam\";";
            this.cbPinjam.SelectedIndexChanged += new System.EventHandler(this.cbPinjam_SelectedIndexChanged);
            // 
            // dtKembali
            // 
            this.dtKembali.Location = new System.Drawing.Point(536, 297);
            this.dtKembali.Name = "dtKembali";
            this.dtKembali.Size = new System.Drawing.Size(200, 20);
            this.dtKembali.TabIndex = 1;
            this.dtKembali.Value = new System.DateTime(2026, 2, 5, 0, 0, 0, 0);
            this.dtKembali.ValueChanged += new System.EventHandler(this.dtKembali_ValueChanged);
            // 
            // txtDenda
            // 
            this.txtDenda.Location = new System.Drawing.Point(197, 375);
            this.txtDenda.Name = "txtDenda";
            this.txtDenda.ReadOnly = true;
            this.txtDenda.Size = new System.Drawing.Size(121, 20);
            this.txtDenda.TabIndex = 2;
            // 
            // cbKondisi
            // 
            this.cbKondisi.FormattingEnabled = true;
            this.cbKondisi.Items.AddRange(new object[] {
            "Baik",
            "Rusak",
            "Hilang"});
            this.cbKondisi.Location = new System.Drawing.Point(197, 325);
            this.cbKondisi.Name = "cbKondisi";
            this.cbKondisi.Size = new System.Drawing.Size(121, 21);
            this.cbKondisi.TabIndex = 3;
            // 
            // btnKembali
            // 
            this.btnKembali.Location = new System.Drawing.Point(536, 378);
            this.btnKembali.Name = "btnKembali";
            this.btnKembali.Size = new System.Drawing.Size(167, 43);
            this.btnKembali.TabIndex = 4;
            this.btnKembali.Text = "Simpan pengembalian";
            this.btnKembali.UseVisualStyleBackColor = true;
            this.btnKembali.Click += new System.EventHandler(this.btnKembali_Click);
            // 
            // dgvPengembalian
            // 
            this.dgvPengembalian.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPengembalian.Location = new System.Drawing.Point(6, 19);
            this.dgvPengembalian.Name = "dgvPengembalian";
            this.dgvPengembalian.Size = new System.Drawing.Size(764, 216);
            this.dgvPengembalian.TabIndex = 5;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.dgvPengembalian);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(776, 241);
            this.groupBox1.TabIndex = 6;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Data Pengembalian";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(38, 325);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(68, 13);
            this.label1.TabIndex = 7;
            this.label1.Text = "Kondisi buku";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(38, 267);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(83, 13);
            this.label2.TabIndex = 8;
            this.label2.Text = "Pilih data pinjam";
            // 
            // lblTenggat
            // 
            this.lblTenggat.AutoSize = true;
            this.lblTenggat.Location = new System.Drawing.Point(393, 297);
            this.lblTenggat.Name = "lblTenggat";
            this.lblTenggat.Size = new System.Drawing.Size(85, 13);
            this.lblTenggat.TabIndex = 9;
            this.lblTenggat.Text = "Tanggal kembali";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(38, 378);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(39, 13);
            this.label4.TabIndex = 10;
            this.label4.Text = "Denda";
            // 
            // Pengembalian_Buku
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.RoyalBlue;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.lblTenggat);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnKembali);
            this.Controls.Add(this.cbKondisi);
            this.Controls.Add(this.txtDenda);
            this.Controls.Add(this.dtKembali);
            this.Controls.Add(this.cbPinjam);
            this.Name = "Pengembalian_Buku";
            this.Text = "Pengembalian_Buku";
            ((System.ComponentModel.ISupportInitialize)(this.dgvPengembalian)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cbPinjam;
        private System.Windows.Forms.DateTimePicker dtKembali;
        private System.Windows.Forms.TextBox txtDenda;
        private System.Windows.Forms.ComboBox cbKondisi;
        private System.Windows.Forms.Button btnKembali;
        private System.Windows.Forms.DataGridView dgvPengembalian;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblTenggat;
        private System.Windows.Forms.Label label4;
    }
}