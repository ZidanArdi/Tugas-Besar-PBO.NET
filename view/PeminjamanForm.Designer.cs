namespace Tugas_Besar_PBO.NET.view
{
    partial class PeminjamanForm
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
            this.txtNPM = new System.Windows.Forms.TextBox();
            this.lblNPM = new System.Windows.Forms.Label();
            this.lblBuku = new System.Windows.Forms.Label();
            this.cbBuku = new System.Windows.Forms.ComboBox();
            this.dtPinjam = new System.Windows.Forms.DateTimePicker();
            this.dtTenggat = new System.Windows.Forms.DateTimePicker();
            this.btnPinjam = new System.Windows.Forms.Button();
            this.dgvPeminjaman = new System.Windows.Forms.DataGridView();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.Tanggal = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPeminjaman)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtNPM
            // 
            this.txtNPM.Location = new System.Drawing.Point(121, 280);
            this.txtNPM.Name = "txtNPM";
            this.txtNPM.Size = new System.Drawing.Size(121, 20);
            this.txtNPM.TabIndex = 0;
            // 
            // lblNPM
            // 
            this.lblNPM.AutoSize = true;
            this.lblNPM.Location = new System.Drawing.Point(24, 280);
            this.lblNPM.Name = "lblNPM";
            this.lblNPM.Size = new System.Drawing.Size(31, 13);
            this.lblNPM.TabIndex = 1;
            this.lblNPM.Text = "NPM";
            // 
            // lblBuku
            // 
            this.lblBuku.AutoSize = true;
            this.lblBuku.Location = new System.Drawing.Point(24, 346);
            this.lblBuku.Name = "lblBuku";
            this.lblBuku.Size = new System.Drawing.Size(54, 13);
            this.lblBuku.TabIndex = 2;
            this.lblBuku.Text = "Pilih Buku";
            // 
            // cbBuku
            // 
            this.cbBuku.FormattingEnabled = true;
            this.cbBuku.Location = new System.Drawing.Point(121, 343);
            this.cbBuku.Name = "cbBuku";
            this.cbBuku.Size = new System.Drawing.Size(121, 21);
            this.cbBuku.TabIndex = 3;
            // 
            // dtPinjam
            // 
            this.dtPinjam.Location = new System.Drawing.Point(371, 285);
            this.dtPinjam.Name = "dtPinjam";
            this.dtPinjam.Size = new System.Drawing.Size(200, 20);
            this.dtPinjam.TabIndex = 4;
            // 
            // dtTenggat
            // 
            this.dtTenggat.Location = new System.Drawing.Point(371, 346);
            this.dtTenggat.Name = "dtTenggat";
            this.dtTenggat.Size = new System.Drawing.Size(200, 20);
            this.dtTenggat.TabIndex = 5;
            // 
            // btnPinjam
            // 
            this.btnPinjam.Location = new System.Drawing.Point(578, 382);
            this.btnPinjam.Name = "btnPinjam";
            this.btnPinjam.Size = new System.Drawing.Size(204, 38);
            this.btnPinjam.TabIndex = 6;
            this.btnPinjam.Text = "Simpan peminjaman";
            this.btnPinjam.UseVisualStyleBackColor = true;
            this.btnPinjam.Click += new System.EventHandler(this.btnPinjam_Click);
            // 
            // dgvPeminjaman
            // 
            this.dgvPeminjaman.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPeminjaman.Location = new System.Drawing.Point(6, 19);
            this.dgvPeminjaman.Name = "dgvPeminjaman";
            this.dgvPeminjaman.Size = new System.Drawing.Size(764, 200);
            this.dgvPeminjaman.TabIndex = 7;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.dgvPeminjaman);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(776, 225);
            this.groupBox1.TabIndex = 8;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Data Peminjam";
            // 
            // Tanggal
            // 
            this.Tanggal.AutoSize = true;
            this.Tanggal.Location = new System.Drawing.Point(271, 287);
            this.Tanggal.Name = "Tanggal";
            this.Tanggal.Size = new System.Drawing.Size(80, 13);
            this.Tanggal.TabIndex = 9;
            this.Tanggal.Text = "Tanggal Pinjam";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(271, 346);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(83, 13);
            this.label2.TabIndex = 10;
            this.label2.Text = "Tanggal Tengat";
            // 
            // PeminjamanForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.RoyalBlue;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.Tanggal);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnPinjam);
            this.Controls.Add(this.dtTenggat);
            this.Controls.Add(this.dtPinjam);
            this.Controls.Add(this.cbBuku);
            this.Controls.Add(this.lblBuku);
            this.Controls.Add(this.lblNPM);
            this.Controls.Add(this.txtNPM);
            this.ForeColor = System.Drawing.SystemColors.ControlText;
            this.Name = "PeminjamanForm";
            this.Text = "PeminjamanForm";
            this.Load += new System.EventHandler(this.PeminjamanForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvPeminjaman)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtNPM;
        private System.Windows.Forms.Label lblNPM;
        private System.Windows.Forms.Label lblBuku;
        private System.Windows.Forms.ComboBox cbBuku;
        private System.Windows.Forms.DateTimePicker dtPinjam;
        private System.Windows.Forms.DateTimePicker dtTenggat;
        private System.Windows.Forms.Button btnPinjam;
        private System.Windows.Forms.DataGridView dgvPeminjaman;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label Tanggal;
        private System.Windows.Forms.Label label2;
    }
}