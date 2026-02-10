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
using OfficeOpenXml.Style;
using Tugas_Besar_PBO.NET.controller;
using Tugas_Besar_PBO.NET.model;

namespace Tugas_Besar_PBO.NET.view
{
    public partial class KoleksiBukuForm : Form
    {
        private string _role;
        private int idBukuTerpilih = 0;

        // ✅ Controller menangani semua logika, View hanya memanggil
        private BukuController bukuController = new BukuController();

        public KoleksiBukuForm(string role)
        {
            InitializeComponent();
            this.Icon = AppIcon.GetIcon();
            dgvBuku.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvBuku.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            this._role = role;
        }

        // ===== LOAD DATA (memanggil Controller) =====

        void LoadBuku()
        {
            dgvBuku.DataSource = bukuController.GetSemuaBuku();
        }

        void LoadKategori()
        {
            DataTable dt = bukuController.GetSemuaKategori();
            cbKategori.DataSource = dt;
            cbKategori.DisplayMember = "nama_kategori";
            cbKategori.ValueMember = "id_kategori";
            cbKategori.SelectedIndex = -1;
        }

        // ===== EVENT HANDLERS =====

        private void KoleksiBukuForm_Load(object sender, EventArgs e)
        {
            LoadBuku();
            LoadKategori();
            if (_role != "admin")
            {
                groupBox2.Visible = false;
                dgvBuku.Top = groupBox2.Top;
                dgvBuku.Height += groupBox2.Height;
                this.Text = "Koleksi Buku (Mode View - Mahasiswa)";
            }
        }

        private void btnSimpan_Click(object sender, EventArgs e)
        {
            if (_role != "admin")
            {
                MessageBox.Show("Anda tidak memiliki hak untuk menambah buku.");
                return;
            }

            if (cbKategori.SelectedValue == null)
            {
                MessageBox.Show("Pilih kategori buku!");
                return;
            }

            try
            {
                // ✅ Buat object Model, lalu kirim ke Controller
                Buku buku = new Buku
                {
                    Judul = txtJudul.Text,
                    Penulis = txtPenulis.Text,
                    Penerbit = txtPenerbit.Text,
                    TahunTerbit = Convert.ToInt32(txtTahun.Text),
                    IdKategori = Convert.ToInt32(cbKategori.SelectedValue),
                    Stok = Convert.ToInt32(txtStok.Text)
                };

                bukuController.TambahBuku(buku);
                LoadBuku();
                MessageBox.Show("Buku berhasil ditambahkan");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (idBukuTerpilih == 0)
            {
                MessageBox.Show("Pilih buku terlebih dahulu!");
                return;
            }

            try
            {
                // ✅ Buat object Model, lalu kirim ke Controller
                Buku buku = new Buku
                {
                    IdBuku = idBukuTerpilih,
                    Judul = txtJudul.Text,
                    Penulis = txtPenulis.Text,
                    Penerbit = txtPenerbit.Text,
                    TahunTerbit = Convert.ToInt32(txtTahun.Text),
                    IdKategori = Convert.ToInt32(cbKategori.SelectedValue),
                    Stok = Convert.ToInt32(txtStok.Text)
                };

                bukuController.UpdateBuku(buku);
                MessageBox.Show("Data berhasil diupdate");
                LoadBuku();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (idBukuTerpilih == 0)
            {
                MessageBox.Show("Pilih buku dulu!");
                return;
            }

            DialogResult konfirmasi = MessageBox.Show(
                "Yakin ingin menghapus buku ini?",
                "Konfirmasi",
                MessageBoxButtons.YesNo
            );

            if (konfirmasi == DialogResult.No) return;

            try
            {
                // ✅ Panggil Controller untuk delete
                bukuController.HapusBuku(idBukuTerpilih);
                MessageBox.Show("Data berhasil dihapus");
                LoadBuku();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void dataGridViewBuku_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvBuku.Rows[e.RowIndex];
                idBukuTerpilih = Convert.ToInt32(row.Cells["id_buku"].Value);
                txtJudul.Text = row.Cells["judul"].Value.ToString();
                txtPenulis.Text = row.Cells["penulis"].Value.ToString();
                txtPenerbit.Text = row.Cells["penerbit"].Value.ToString();
                txtTahun.Text = row.Cells["tahun_terbit"].Value.ToString();
                txtStok.Text = row.Cells["stok"].Value.ToString();

                // Handle kategori safely
                if (row.Cells["nama_kategori"].Value != null)
                {
                    cbKategori.Text = row.Cells["nama_kategori"].Value.ToString();
                }
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            LoadBuku();
        }

        private void txtCari_TextChanged(object sender, EventArgs e)
        {
            dgvBuku.DataSource = bukuController.CariBuku(txtCari.Text);
        }

        private void btnExportExcel_Click(object sender, EventArgs e)
        {
            if (dgvBuku.Rows.Count == 0)
            {
                MessageBox.Show("Data buku masih kosong!");
                return;
            }

            using (SaveFileDialog sfd = new SaveFileDialog())
            {
                sfd.Filter = "Excel File (*.xlsx)|*.xlsx";
                sfd.FileName = "Data_Koleksi_Buku.xlsx";

                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    ExportToExcel(dgvBuku, sfd.FileName);
                    MessageBox.Show("Export berhasil!");
                }

                void ExportToExcel(DataGridView dgv, string filePath)
                {
                    using (ExcelPackage package = new ExcelPackage())
                    {
                        ExcelWorksheet ws = package.Workbook.Worksheets.Add("Koleksi Buku");

                        // HEADER
                        for (int i = 0; i < dgv.Columns.Count; i++)
                        {
                            ws.Cells[1, i + 1].Value = dgv.Columns[i].HeaderText;
                            ws.Cells[1, i + 1].Style.Font.Bold = true;
                        }

                        // DATA
                        for (int i = 0; i < dgv.Rows.Count; i++)
                        {
                            for (int j = 0; j < dgv.Columns.Count; j++)
                            {
                                ws.Cells[i + 2, j + 1].Value =
                                    dgv.Rows[i].Cells[j].Value?.ToString();
                            }
                        }

                        ws.Cells.AutoFitColumns();

                        FileInfo fi = new FileInfo(filePath);
                        package.SaveAs(fi);
                    }
                }
            }
        }
    }
}