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
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.lblTenggatLabel = new System.Windows.Forms.Label();
            this.btnExportExcel = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPengembalian)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1 - Data Grid
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.BackColor = System.Drawing.Color.White;
            this.groupBox1.Controls.Add(this.dgvPengembalian);
            this.groupBox1.Font = new System.Drawing.Font("Segoe UI Semibold", 9.5F, System.Drawing.FontStyle.Bold);
            this.groupBox1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(776, 230);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "📋 Daftar Peminjaman";
            // 
            // dgvPengembalian
            // 
            this.dgvPengembalian.AllowUserToAddRows = false;
            this.dgvPengembalian.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvPengembalian.BackgroundColor = System.Drawing.Color.White;
            this.dgvPengembalian.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvPengembalian.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dgvPengembalian.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.dgvPengembalian.ColumnHeadersDefaultCellStyle = new System.Windows.Forms.DataGridViewCellStyle() { BackColor = System.Drawing.Color.FromArgb(65, 105, 225), ForeColor = System.Drawing.Color.White, Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold), Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter };
            this.dgvPengembalian.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPengembalian.DefaultCellStyle = new System.Windows.Forms.DataGridViewCellStyle() { BackColor = System.Drawing.Color.White, ForeColor = System.Drawing.Color.FromArgb(30, 30, 30), SelectionBackColor = System.Drawing.Color.FromArgb(200, 220, 255), SelectionForeColor = System.Drawing.Color.Black, Font = new System.Drawing.Font("Segoe UI", 9F) };
            this.dgvPengembalian.AlternatingRowsDefaultCellStyle = new System.Windows.Forms.DataGridViewCellStyle() { BackColor = System.Drawing.Color.FromArgb(245, 247, 250) };
            this.dgvPengembalian.EnableHeadersVisualStyles = false;
            this.dgvPengembalian.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvPengembalian.GridColor = System.Drawing.Color.FromArgb(230, 230, 230);
            this.dgvPengembalian.Location = new System.Drawing.Point(3, 20);
            this.dgvPengembalian.Name = "dgvPengembalian";
            this.dgvPengembalian.ReadOnly = true;
            this.dgvPengembalian.RowHeadersVisible = false;
            this.dgvPengembalian.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvPengembalian.Size = new System.Drawing.Size(770, 207);
            this.dgvPengembalian.TabIndex = 20;
            // 
            // groupBox2 - Form Input
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.BackColor = System.Drawing.Color.White;
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.cbPinjam);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.cbKondisi);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.txtDenda);
            this.groupBox2.Controls.Add(this.lblTenggatLabel);
            this.groupBox2.Controls.Add(this.lblTenggat);
            this.groupBox2.Controls.Add(this.lblKembaliLabel);
            this.groupBox2.Controls.Add(this.dtKembali);
            this.groupBox2.Controls.Add(this.btnKembali);
            this.groupBox2.Controls.Add(this.btnExportExcel);
            this.groupBox2.Font = new System.Drawing.Font("Segoe UI Semibold", 9.5F, System.Drawing.FontStyle.Bold);
            this.groupBox2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.groupBox2.Location = new System.Drawing.Point(12, 250);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(776, 210);
            this.groupBox2.TabIndex = 21;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "🔄 Proses Pengembalian";
            // 
            // label2 - Pilih Data Pinjam
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(60)))));
            this.label2.Location = new System.Drawing.Point(20, 30);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(98, 15);
            this.label2.TabIndex = 8;
            this.label2.Text = "Pilih Data Pinjam";
            // 
            // cbPinjam
            // 
            this.cbPinjam.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbPinjam.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.cbPinjam.FormattingEnabled = true;
            this.cbPinjam.Location = new System.Drawing.Point(130, 27);
            this.cbPinjam.Name = "cbPinjam";
            this.cbPinjam.Size = new System.Drawing.Size(250, 25);
            this.cbPinjam.TabIndex = 0;
            this.cbPinjam.SelectedIndexChanged += new System.EventHandler(this.cbPinjam_SelectedIndexChanged);
            // 
            // label1 - Kondisi Buku
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(60)))));
            this.label1.Location = new System.Drawing.Point(20, 65);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(76, 15);
            this.label1.TabIndex = 7;
            this.label1.Text = "Kondisi Buku";
            // 
            // cbKondisi
            // 
            this.cbKondisi.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbKondisi.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.cbKondisi.FormattingEnabled = true;
            this.cbKondisi.Items.AddRange(new object[] {
            "Baik",
            "Rusak"});
            this.cbKondisi.Location = new System.Drawing.Point(130, 62);
            this.cbKondisi.Name = "cbKondisi";
            this.cbKondisi.Size = new System.Drawing.Size(250, 25);
            this.cbKondisi.TabIndex = 3;
            this.cbKondisi.SelectedIndexChanged += new System.EventHandler(this.cbKondisi_SelectedIndexChanged);
            // 
            // label4 - Denda
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.label4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(60)))));
            this.label4.Location = new System.Drawing.Point(20, 100);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(42, 15);
            this.label4.TabIndex = 10;
            this.label4.Text = "Denda";
            // 
            // txtDenda
            // 
            this.txtDenda.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(245)))), ((int)(((byte)(245)))));
            this.txtDenda.Font = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Bold);
            this.txtDenda.ForeColor = System.Drawing.Color.Red;
            this.txtDenda.Location = new System.Drawing.Point(130, 97);
            this.txtDenda.Name = "txtDenda";
            this.txtDenda.ReadOnly = true;
            this.txtDenda.Size = new System.Drawing.Size(250, 25);
            this.txtDenda.TabIndex = 2;
            this.txtDenda.Text = "Rp 0";
            // 
            // lblTenggatLabel
            // 
            this.lblTenggatLabel.AutoSize = true;
            this.lblTenggatLabel.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblTenggatLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(60)))));
            this.lblTenggatLabel.Location = new System.Drawing.Point(412, 30);
            this.lblTenggatLabel.Name = "lblTenggatLabel";
            this.lblTenggatLabel.Size = new System.Drawing.Size(94, 15);
            this.lblTenggatLabel.TabIndex = 13;
            this.lblTenggatLabel.Text = "Tanggal Tenggat";
            // 
            // lblTenggat
            // 
            this.lblTenggat.AutoSize = true;
            this.lblTenggat.Font = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Bold);
            this.lblTenggat.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(65)))), ((int)(((byte)(105)))), ((int)(((byte)(225)))));
            this.lblTenggat.Location = new System.Drawing.Point(520, 28);
            this.lblTenggat.Name = "lblTenggat";
            this.lblTenggat.Size = new System.Drawing.Size(16, 17);
            this.lblTenggat.TabIndex = 9;
            this.lblTenggat.Text = "-";
            // 
            // lblKembaliLabel
            // 
            this.lblKembaliLabel = new System.Windows.Forms.Label();
            this.lblKembaliLabel.AutoSize = true;
            this.lblKembaliLabel.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblKembaliLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(60)))));
            this.lblKembaliLabel.Location = new System.Drawing.Point(412, 65);
            this.lblKembaliLabel.Name = "lblKembaliLabel";
            this.lblKembaliLabel.Size = new System.Drawing.Size(94, 15);
            this.lblKembaliLabel.TabIndex = 15;
            this.lblKembaliLabel.Text = "Tanggal Kembali";
            // 
            // dtKembali
            // 
            this.dtKembali.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.dtKembali.Location = new System.Drawing.Point(520, 62);
            this.dtKembali.Name = "dtKembali";
            this.dtKembali.Size = new System.Drawing.Size(235, 23);
            this.dtKembali.TabIndex = 1;
            this.dtKembali.ValueChanged += new System.EventHandler(this.dtKembali_ValueChanged);
            // 
            // btnKembali
            // 
            this.btnKembali.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(65)))), ((int)(((byte)(105)))), ((int)(((byte)(225)))));
            this.btnKembali.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnKembali.FlatAppearance.BorderSize = 0;
            this.btnKembali.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnKembali.Font = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Bold);
            this.btnKembali.ForeColor = System.Drawing.Color.White;
            this.btnKembali.Location = new System.Drawing.Point(520, 97);
            this.btnKembali.Name = "btnKembali";
            this.btnKembali.Size = new System.Drawing.Size(235, 40);
            this.btnKembali.TabIndex = 4;
            this.btnKembali.Text = "💾 Simpan Pengembalian";
            this.btnKembali.UseVisualStyleBackColor = false;
            this.btnKembali.Click += new System.EventHandler(this.btnKembali_Click);
            // 
            // btnExportExcel
            // 
            this.btnExportExcel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(139)))), ((int)(((byte)(34)))));
            this.btnExportExcel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnExportExcel.FlatAppearance.BorderSize = 0;
            this.btnExportExcel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExportExcel.Font = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Bold);
            this.btnExportExcel.ForeColor = System.Drawing.Color.White;
            this.btnExportExcel.Location = new System.Drawing.Point(130, 133);
            this.btnExportExcel.Name = "btnExportExcel";
            this.btnExportExcel.Size = new System.Drawing.Size(250, 36);
            this.btnExportExcel.TabIndex = 14;
            this.btnExportExcel.Text = "📊 Export ke Excel";
            this.btnExportExcel.UseVisualStyleBackColor = false;
            this.btnExportExcel.Click += new System.EventHandler(this.btnExportExcel_Click);
            // 
            // Pengembalian_Buku
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(243)))), ((int)(((byte)(249)))));
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "Pengembalian_Buku";
            this.Text = "Pengembalian Buku";
            ((System.ComponentModel.ISupportInitialize)(this.dgvPengembalian)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

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
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label lblTenggatLabel;
        private System.Windows.Forms.Label lblKembaliLabel;
        private System.Windows.Forms.Button btnExportExcel;
    }
}