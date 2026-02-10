using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using OfficeOpenXml;
using Tugas_Besar_PBO.NET.controller;
using Tugas_Besar_PBO.NET.model;

namespace Tugas_Besar_PBO.NET.view
{
    public partial class PeminjamanForm : Form
    {
        // ✅ Controller menangani semua logika, View hanya memanggil
        private PeminjamanController peminjamanController = new PeminjamanController();
        private BukuController bukuController = new BukuController();

        public PeminjamanForm()
        {
            InitializeComponent();
            this.Icon = AppIcon.GetIcon();
        }

        private void PeminjamanForm_Load(object sender, EventArgs e)
        {
            LoadBuku();
            LoadPeminjaman();
        }

        // ===== LOAD DATA (memanggil Controller) =====

        void LoadPeminjaman()
        {
            DataTable dt = peminjamanController.GetSemuaPeminjaman();
            dgvPeminjaman.DataSource = dt;
        }

        void LoadBuku()
        {
            DataTable dt = bukuController.GetBukuTersedia();
            cbBuku.DataSource = dt;
            cbBuku.DisplayMember = "judul";
            cbBuku.ValueMember = "id_buku";
            cbBuku.SelectedIndex = -1;
        }

        // ===== EVENT HANDLERS =====

        private void btnPinjam_Click(object sender, EventArgs e)
        {
            // Validasi pilih buku
            if (cbBuku.SelectedValue == null)
            {
                MessageBox.Show("Pilih buku terlebih dahulu!");
                return;
            }

            try
            {
                // ✅ Buat object Model, lalu kirim ke Controller
                Peminjaman peminjaman = new Peminjaman
                {
                    NPM = txtNPM.Text,
                    IdBuku = Convert.ToInt32(cbBuku.SelectedValue),
                    TanggalPinjam = dtPinjam.Value,
                    TanggalTenggat = dtTenggat.Value
                };

                peminjamanController.PinjamBuku(peminjaman);
                MessageBox.Show("Peminjaman berhasil");

                // Refresh data
                LoadPeminjaman();
                LoadBuku();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        // ===== EXPORT EXCEL =====

        private void btnExportExcel_Click(object sender, EventArgs e)
        {
            if (dgvPeminjaman.Rows.Count == 0)
            {
                MessageBox.Show("Data peminjaman masih kosong!");
                return;
            }

            using (SaveFileDialog sfd = new SaveFileDialog())
            {
                sfd.Filter = "Excel File (*.xlsx)|*.xlsx";
                sfd.FileName = "Data_Peminjaman.xlsx";

                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    using (ExcelPackage package = new ExcelPackage())
                    {
                        ExcelWorksheet ws = package.Workbook.Worksheets.Add("Data Peminjaman");

                        // HEADER
                        for (int i = 0; i < dgvPeminjaman.Columns.Count; i++)
                        {
                            ws.Cells[1, i + 1].Value = dgvPeminjaman.Columns[i].HeaderText;
                            ws.Cells[1, i + 1].Style.Font.Bold = true;
                        }

                        // DATA
                        for (int i = 0; i < dgvPeminjaman.Rows.Count; i++)
                        {
                            for (int j = 0; j < dgvPeminjaman.Columns.Count; j++)
                            {
                                ws.Cells[i + 2, j + 1].Value =
                                    dgvPeminjaman.Rows[i].Cells[j].Value?.ToString();
                            }
                        }

                        ws.Cells.AutoFitColumns();
                        FileInfo fi = new FileInfo(sfd.FileName);
                        package.SaveAs(fi);
                    }

                    MessageBox.Show("Export berhasil!");
                }
            }
        }
    }
}
