using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Tugas_Besar_PBO.NET.Database;

namespace Tugas_Besar_PBO.NET.view
{
    public partial class KoleksiBukuForm : Form
    {
        private string _role;

        public KoleksiBukuForm(string role)
        {
            InitializeComponent();
            dgvBuku.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvBuku.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            //TampilBuku();
            this._role = role;
        }

        private void TampilBuku()
        {
            // Contoh data buku
            //dataGridViewBuku.DataSource = controller.ShowBuku();
        }

        void LoadBuku()
        {
            using (MySqlConnection conn = Koneksi.GetConnection())
            {
                string q = @"SELECT b.id_buku, b.judul, b.penulis, b.penerbit,
                            b.tahun_terbit, k.nama_kategori, b.stok
                     FROM buku b
                     JOIN kategori k ON b.id_kategori = k.id_kategori";

                MySqlDataAdapter da = new MySqlDataAdapter(q, conn);
                DataTable dt = new DataTable();
                da.Fill(dt);

                dgvBuku.DataSource = dt;
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
            using (MySqlConnection conn = Koneksi.GetConnection())
            {
                conn.Open();
                string insert = @"INSERT INTO buku
        (judul, penulis, penerbit, tahun_terbit, id_kategori, stok)
        VALUES (@j, @p, @pb, @t, @k, @s)";

                MySqlCommand cmd = new MySqlCommand(insert, conn);
                cmd.Parameters.AddWithValue("@j", txtJudul.Text);
                cmd.Parameters.AddWithValue("@p", txtPenulis.Text);
                cmd.Parameters.AddWithValue("@pb", txtPenerbit.Text);
                cmd.Parameters.AddWithValue("@t", txtTahun.Text);
                cmd.Parameters.AddWithValue("@k", cbKategori.SelectedValue);                // ID kategori
                cmd.Parameters.AddWithValue("@s", Convert.ToInt32(txtStok.Text));

                cmd.ExecuteNonQuery();
            }

            LoadBuku();
            MessageBox.Show("Buku berhasil ditambahkan");
        }

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
        void LoadKategori()
        {
            using (MySqlConnection conn = Koneksi.GetConnection())
            {
                string q = "SELECT id_kategori, nama_kategori FROM kategori";
                MySqlDataAdapter da = new MySqlDataAdapter(q, conn);
                DataTable dt = new DataTable();
                da.Fill(dt);

                cbKategori.DataSource = dt;
                cbKategori.DisplayMember = "nama_kategori";
                cbKategori.ValueMember = "id_kategori";
                cbKategori.SelectedIndex = -1;
            }
        }


        int idBukuTerpilih = 0;
        private void dataGridViewBuku_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvBuku.Rows[e.RowIndex];
                txtJudul.Text = row.Cells["judul"].Value.ToString();
                txtPenulis.Text = row.Cells["penulis"].Value.ToString();
                txtPenerbit.Text = row.Cells["penerbit"].Value.ToString();
                txtTahun.Text = row.Cells["tahun_terbit"].Value.ToString();
                txtStok.Text = row.Cells["stok"].Value.ToString();
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            LoadBuku();
        }

        private void dataGridViewBuku_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            DataGridViewRow row = dgvBuku.Rows[e.RowIndex];

            idBukuTerpilih = Convert.ToInt32(row.Cells["id_buku"].Value);
            txtJudul.Text = row.Cells["judul"].Value.ToString();
            txtPenulis.Text = row.Cells["penulis"].Value.ToString();
            txtPenerbit.Text = row.Cells["penerbit"].Value.ToString();
            txtTahun.Text = row.Cells["tahun_terbit"].Value.ToString();
            txtStok.Text = row.Cells["stok"].Value.ToString();
            cbKategori.Text = row.Cells["nama_kategori"].Value.ToString();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (idBukuTerpilih == 0)
            {
                MessageBox.Show("Pilih buku terlebih dahulu!");
                return;
            }

            using (MySqlConnection conn = Koneksi.GetConnection())
            {
                conn.Open();
                string q = @"UPDATE buku SET 
                        judul=@judul,
                        penulis=@penulis,
                        penerbit=@penerbit,
                        tahun_terbit=@tahun,
                        id_kategori=@kategori,
                        stok=@stok
                     WHERE id_buku=@id";

                MySqlCommand cmd = new MySqlCommand(q, conn);
                cmd.Parameters.AddWithValue("@judul", txtJudul.Text);
                cmd.Parameters.AddWithValue("@penulis", txtPenulis.Text);
                cmd.Parameters.AddWithValue("@penerbit", txtPenerbit.Text);
                cmd.Parameters.AddWithValue("@tahun", txtTahun.Text);
                cmd.Parameters.AddWithValue("@kategori", cbKategori.SelectedValue);
                cmd.Parameters.AddWithValue("@stok", txtStok.Text);
                cmd.Parameters.AddWithValue("@id", idBukuTerpilih);

                cmd.ExecuteNonQuery();
            }

            MessageBox.Show("Data berhasil diupdate");
            LoadBuku();
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

            using (MySqlConnection conn = Koneksi.GetConnection())
            {
                conn.Open();
                string q = "DELETE FROM buku WHERE id_buku=@id";
                MySqlCommand cmd = new MySqlCommand(q, conn);
                cmd.Parameters.AddWithValue("@id", idBukuTerpilih);
                cmd.ExecuteNonQuery();
            }

            MessageBox.Show("Data berhasil dihapus");
            LoadBuku();
        }


    }
}
