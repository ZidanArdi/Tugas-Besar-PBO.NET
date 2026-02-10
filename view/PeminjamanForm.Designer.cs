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
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnExportExcel = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPeminjaman)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.BackColor = System.Drawing.Color.White;
            this.groupBox1.Controls.Add(this.dgvPeminjaman);
            this.groupBox1.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold);
            this.groupBox1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(776, 260);
            this.groupBox1.TabIndex = 6;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "📋 Data Peminjaman Aktif";
            // 
            // dgvPeminjaman
            // 
            this.dgvPeminjaman.AllowUserToAddRows = false;
            this.dgvPeminjaman.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvPeminjaman.BackgroundColor = System.Drawing.Color.White;
            this.dgvPeminjaman.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvPeminjaman.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dgvPeminjaman.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.dgvPeminjaman.ColumnHeadersDefaultCellStyle = new System.Windows.Forms.DataGridViewCellStyle() { BackColor = System.Drawing.Color.FromArgb(65, 105, 225), ForeColor = System.Drawing.Color.White, Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold), Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter };
            this.dgvPeminjaman.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPeminjaman.DefaultCellStyle = new System.Windows.Forms.DataGridViewCellStyle() { BackColor = System.Drawing.Color.White, ForeColor = System.Drawing.Color.FromArgb(30, 30, 30), SelectionBackColor = System.Drawing.Color.FromArgb(200, 220, 255), SelectionForeColor = System.Drawing.Color.Black, Font = new System.Drawing.Font("Segoe UI", 9F) };
            this.dgvPeminjaman.AlternatingRowsDefaultCellStyle = new System.Windows.Forms.DataGridViewCellStyle() { BackColor = System.Drawing.Color.FromArgb(245, 247, 250) };
            this.dgvPeminjaman.EnableHeadersVisualStyles = false;
            this.dgvPeminjaman.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvPeminjaman.GridColor = System.Drawing.Color.FromArgb(230, 230, 230);
            this.dgvPeminjaman.Location = new System.Drawing.Point(3, 19);
            this.dgvPeminjaman.Name = "dgvPeminjaman";
            this.dgvPeminjaman.ReadOnly = true;
            this.dgvPeminjaman.RowHeadersVisible = false;
            this.dgvPeminjaman.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvPeminjaman.Size = new System.Drawing.Size(770, 238);
            this.dgvPeminjaman.TabIndex = 7;
            // 
            // groupBox2 - Form Input
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.BackColor = System.Drawing.Color.White;
            this.groupBox2.Controls.Add(this.lblNPM);
            this.groupBox2.Controls.Add(this.txtNPM);
            this.groupBox2.Controls.Add(this.lblBuku);
            this.groupBox2.Controls.Add(this.cbBuku);
            this.groupBox2.Controls.Add(this.Tanggal);
            this.groupBox2.Controls.Add(this.dtPinjam);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.dtTenggat);
            this.groupBox2.Controls.Add(this.btnPinjam);
            this.groupBox2.Controls.Add(this.btnExportExcel);
            this.groupBox2.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold);
            this.groupBox2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.groupBox2.Location = new System.Drawing.Point(12, 280);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(776, 158);
            this.groupBox2.TabIndex = 11;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "📝 Form Peminjaman Baru";
            // 
            // lblNPM
            // 
            this.lblNPM.AutoSize = true;
            this.lblNPM.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblNPM.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(60)))));
            this.lblNPM.Location = new System.Drawing.Point(20, 30);
            this.lblNPM.Name = "lblNPM";
            this.lblNPM.Size = new System.Drawing.Size(34, 15);
            this.lblNPM.TabIndex = 1;
            this.lblNPM.Text = "NPM";
            // 
            // txtNPM
            // 
            this.txtNPM.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.txtNPM.Location = new System.Drawing.Point(130, 27);
            this.txtNPM.Name = "txtNPM";
            this.txtNPM.Size = new System.Drawing.Size(220, 24);
            this.txtNPM.TabIndex = 0;
            // 
            // lblBuku
            // 
            this.lblBuku.AutoSize = true;
            this.lblBuku.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblBuku.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(60)))));
            this.lblBuku.Location = new System.Drawing.Point(20, 65);
            this.lblBuku.Name = "lblBuku";
            this.lblBuku.Size = new System.Drawing.Size(60, 15);
            this.lblBuku.TabIndex = 2;
            this.lblBuku.Text = "Pilih Buku";
            // 
            // cbBuku
            // 
            this.cbBuku.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbBuku.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.cbBuku.FormattingEnabled = true;
            this.cbBuku.Location = new System.Drawing.Point(130, 62);
            this.cbBuku.Name = "cbBuku";
            this.cbBuku.Size = new System.Drawing.Size(220, 25);
            this.cbBuku.TabIndex = 3;
            // 
            // Tanggal
            // 
            this.Tanggal.AutoSize = true;
            this.Tanggal.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.Tanggal.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(60)))));
            this.Tanggal.Location = new System.Drawing.Point(395, 30);
            this.Tanggal.Name = "Tanggal";
            this.Tanggal.Size = new System.Drawing.Size(90, 15);
            this.Tanggal.TabIndex = 9;
            this.Tanggal.Text = "Tanggal Pinjam";
            // 
            // dtPinjam
            // 
            this.dtPinjam.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.dtPinjam.Location = new System.Drawing.Point(520, 27);
            this.dtPinjam.Name = "dtPinjam";
            this.dtPinjam.Size = new System.Drawing.Size(235, 23);
            this.dtPinjam.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(60)))));
            this.label2.Location = new System.Drawing.Point(395, 65);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(97, 15);
            this.label2.TabIndex = 10;
            this.label2.Text = "Tanggal Tenggat";
            // 
            // dtTenggat
            // 
            this.dtTenggat.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.dtTenggat.Location = new System.Drawing.Point(520, 62);
            this.dtTenggat.Name = "dtTenggat";
            this.dtTenggat.Size = new System.Drawing.Size(235, 23);
            this.dtTenggat.TabIndex = 5;
            // 
            // btnPinjam
            // 
            this.btnPinjam.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(65)))), ((int)(((byte)(105)))), ((int)(((byte)(225)))));
            this.btnPinjam.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnPinjam.FlatAppearance.BorderSize = 0;
            this.btnPinjam.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPinjam.Font = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Bold);
            this.btnPinjam.ForeColor = System.Drawing.Color.White;
            this.btnPinjam.Location = new System.Drawing.Point(520, 100);
            this.btnPinjam.Name = "btnPinjam";
            this.btnPinjam.Size = new System.Drawing.Size(235, 40);
            this.btnPinjam.TabIndex = 6;
            this.btnPinjam.Text = "💾 Simpan Peminjaman";
            this.btnPinjam.UseVisualStyleBackColor = false;
            this.btnPinjam.Click += new System.EventHandler(this.btnPinjam_Click);
            // 
            // btnExportExcel
            // 
            this.btnExportExcel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(139)))), ((int)(((byte)(34)))));
            this.btnExportExcel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnExportExcel.FlatAppearance.BorderSize = 0;
            this.btnExportExcel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExportExcel.Font = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Bold);
            this.btnExportExcel.ForeColor = System.Drawing.Color.White;
            this.btnExportExcel.Location = new System.Drawing.Point(130, 100);
            this.btnExportExcel.Name = "btnExportExcel";
            this.btnExportExcel.Size = new System.Drawing.Size(220, 40);
            this.btnExportExcel.TabIndex = 12;
            this.btnExportExcel.Text = "📊 Export ke Excel";
            this.btnExportExcel.UseVisualStyleBackColor = false;
            this.btnExportExcel.Click += new System.EventHandler(this.btnExportExcel_Click);
            // 
            // PeminjamanForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(243)))), ((int)(((byte)(249)))));
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.ForeColor = System.Drawing.SystemColors.ControlText;
            this.Name = "PeminjamanForm";
            this.Text = "Peminjaman Buku";
            this.Load += new System.EventHandler(this.PeminjamanForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvPeminjaman)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

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
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btnExportExcel;
    }
}