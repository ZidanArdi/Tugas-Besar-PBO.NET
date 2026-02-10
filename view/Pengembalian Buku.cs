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
    /// <summary>
    /// Form Pengembalian Buku
    /// ========================
    /// Form ini HANYA menangani tampilan UI.
    /// Semua logika proses (hitung denda, insert, update) dilakukan oleh PeminjamanController.
    /// </summary>
    public partial class Pengembalian_Buku : Form
    {
        // ✅ Controller menangani semua logika, View hanya memanggil
        private PeminjamanController peminjamanController = new PeminjamanController();

        /// <summary>
        /// Constructor - Dipanggil saat form pertama kali dibuat
        /// </summary>
        public Pengembalian_Buku()
        {
            InitializeComponent();
            this.Icon = AppIcon.GetIcon();

            // ===== LOAD DATA =====
            LoadDataGrid();
            LoadComboBox();
        }

        // ===== LOAD DATA (memanggil Controller) =====

        /// <summary>
        /// Memuat SEMUA data peminjaman + pengembalian ke DataGridView
        /// Data tetap tampil setelah dikembalikan (termasuk denda & kondisi)
        /// </summary>
        void LoadDataGrid()
        {
            dgvPengembalian.DataSource = peminjamanController.GetDataPengembalian();
        }

        /// <summary>
        /// Memuat data peminjaman AKTIF (belum dikembalikan) ke ComboBox
        /// Hanya yang status = 'Dipinjam' yang bisa dipilih untuk dikembalikan
        /// </summary>
        void LoadComboBox()
        {
            DataTable dt = peminjamanController.GetPeminjamanAktif();
            cbPinjam.DataSource = dt;
            cbPinjam.DisplayMember = "info";
            cbPinjam.ValueMember = "id_pinjam";
            cbPinjam.SelectedIndex = -1;
        }

        // ===== EVENT HANDLERS =====

        /// <summary>
        /// EVENT: TOMBOL KEMBALI DIKLIK
        /// Memproses pengembalian buku via Controller
        /// </summary>
        private void btnKembali_Click(object sender, EventArgs e)
        {
            // Validasi: pastikan transaksi sudah dipilih
            if (cbPinjam.SelectedValue == null)
            {
                MessageBox.Show("Pilih transaksi peminjaman!");
                return;
            }

            // Validasi: pastikan kondisi buku sudah dipilih
            if (string.IsNullOrEmpty(cbKondisi.Text))
            {
                MessageBox.Show("Pilih kondisi buku!");
                return;
            }

            try
            {
                // Ambil tanggal tenggat dari label
                DateTime tenggat = DateTime.Parse(lblTenggat.Text);

                // ✅ Hitung denda via Controller (termasuk denda kerusakan jika kondisi "Rusak")
                decimal denda = peminjamanController.HitungDenda(tenggat, dtKembali.Value, cbKondisi.Text);

                // ✅ Buat object Model, lalu kirim ke Controller
                Pengembalian pengembalian = new Pengembalian
                {
                    IdPinjam = Convert.ToInt32(cbPinjam.SelectedValue),
                    TanggalDikembalikan = dtKembali.Value,
                    Denda = denda,
                    KondisiBuku = cbKondisi.Text
                };

                peminjamanController.KembalikanBuku(pengembalian);
                MessageBox.Show("Pengembalian berhasil");

                // Refresh data
                LoadDataGrid();   // Refresh tabel (data tetap tampil + denda & kondisi terupdate)
                LoadComboBox();   // Refresh ComboBox (transaksi yang sudah dikembalikan hilang dari pilihan)
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        /// <summary>
        /// EVENT: COMBOBOX TRANSAKSI BERUBAH
        /// Menampilkan tanggal tenggat dan menghitung denda otomatis via Controller
        /// </summary>
        private void cbPinjam_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbPinjam.SelectedIndex == -1) return;

            // Ambil tanggal tenggat dari data yang dipilih
            DataRowView row = (DataRowView)cbPinjam.SelectedItem;
            DateTime tenggat = Convert.ToDateTime(row["tanggal_tenggat"]);

            // Tampilkan tanggal tenggat di label
            lblTenggat.Text = tenggat.ToString("dd-MM-yyyy");

            // ✅ Hitung denda via Controller (termasuk kondisi buku)
            string kondisi = cbKondisi.Text;
            decimal denda = peminjamanController.HitungDenda(tenggat, dtKembali.Value, kondisi);
            txtDenda.Text = denda.ToString();
        }

        /// <summary>
        /// EVENT: DATETIMEPICKER BERUBAH
        /// Menghitung ulang denda secara real-time via Controller
        /// </summary>
        private void dtKembali_ValueChanged(object sender, EventArgs e)
        {
            if (cbPinjam.SelectedIndex == -1) return;

            DataRowView row = (DataRowView)cbPinjam.SelectedItem;
            DateTime tenggat = Convert.ToDateTime(row["tanggal_tenggat"]);

            // ✅ Hitung ulang denda via Controller (termasuk kondisi buku)
            decimal denda = peminjamanController.HitungDenda(tenggat, dtKembali.Value, cbKondisi.Text);
            txtDenda.Text = denda.ToString();
        }

        /// <summary>
        /// EVENT: COMBOBOX KONDISI BERUBAH
        /// Menghitung ulang denda secara real-time saat kondisi buku berubah
        /// Kondisi "Rusak" → denda + Rp25.000 tambahan
        /// </summary>
        private void cbKondisi_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbPinjam.SelectedIndex == -1) return;

            DataRowView row = (DataRowView)cbPinjam.SelectedItem;
            DateTime tenggat = Convert.ToDateTime(row["tanggal_tenggat"]);

            // ✅ Hitung ulang denda dengan kondisi buku yang baru dipilih
            decimal denda = peminjamanController.HitungDenda(tenggat, dtKembali.Value, cbKondisi.Text);
            txtDenda.Text = denda.ToString();
        }

        // ===== EXPORT EXCEL =====

        private void btnExportExcel_Click(object sender, EventArgs e)
        {
            if (dgvPengembalian.Rows.Count == 0)
            {
                MessageBox.Show("Data pengembalian masih kosong!");
                return;
            }

            using (SaveFileDialog sfd = new SaveFileDialog())
            {
                sfd.Filter = "Excel File (*.xlsx)|*.xlsx";
                sfd.FileName = "Data_Pengembalian.xlsx";

                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    using (ExcelPackage package = new ExcelPackage())
                    {
                        ExcelWorksheet ws = package.Workbook.Worksheets.Add("Data Pengembalian");

                        // HEADER
                        for (int i = 0; i < dgvPengembalian.Columns.Count; i++)
                        {
                            ws.Cells[1, i + 1].Value = dgvPengembalian.Columns[i].HeaderText;
                            ws.Cells[1, i + 1].Style.Font.Bold = true;
                        }

                        // DATA
                        for (int i = 0; i < dgvPengembalian.Rows.Count; i++)
                        {
                            for (int j = 0; j < dgvPengembalian.Columns.Count; j++)
                            {
                                ws.Cells[i + 2, j + 1].Value =
                                    dgvPengembalian.Rows[i].Cells[j].Value?.ToString();
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
