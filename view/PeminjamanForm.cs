using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Tugas_Besar_PBO.NET.Database;

namespace Tugas_Besar_PBO.NET.view
{
    public partial class PeminjamanForm : Form
    {
        public PeminjamanForm()
        {
            InitializeComponent();

        }

        private void PeminjamanForm_Load(object sender, EventArgs e)
        {
            LoadBuku();
            LoadPeminjaman(); // 🔥 tampilkan data
        }
        void LoadPeminjaman()
        {
            using (MySqlConnection conn = Koneksi.GetConnection())
            {
                string query = @"
        SELECT 
            p.id_pinjam,
            p.npm,
            b.judul,
            p.tanggal_pinjam,
            p.tanggal_tenggat,
            p.status_pinjam
        FROM peminjaman p
        JOIN buku b ON p.id_buku = b.id_buku
        ORDER BY p.id_pinjam DESC";

                MySqlDataAdapter da = new MySqlDataAdapter(query, conn);
                DataTable dt = new DataTable();
                da.Fill(dt);

                dgvPeminjaman.DataSource = dt;

                // biar rapi
                dgvPeminjaman.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                dgvPeminjaman.ReadOnly = true;
                dgvPeminjaman.AllowUserToAddRows = false;
            }
        }

        void LoadBuku()
        {
            MySqlConnection conn = Koneksi.GetConnection();
            string query = "SELECT id_buku, judul FROM buku WHERE stok > 0";

            MySqlDataAdapter da = new MySqlDataAdapter(query, conn);
            DataTable dt = new DataTable();
            da.Fill(dt);

            cbBuku.DataSource = dt;
            cbBuku.DisplayMember = "judul";
            cbBuku.ValueMember = "id_buku";
            cbBuku.SelectedIndex = -1; // penting
        }

        private void btnPinjam_Click(object sender, EventArgs e)
        {
            // 1️⃣ VALIDASI PILIH BUKU
            if (cbBuku.SelectedValue == null)
            {
                MessageBox.Show("Pilih buku terlebih dahulu!");
                return;
            }

            int idBuku = Convert.ToInt32(cbBuku.SelectedValue);
            MySqlConnection conn = Koneksi.GetConnection();
            conn.Open();

            string insert = "INSERT INTO peminjaman (npm, id_buku, tanggal_pinjam, tanggal_tenggat) " +
                            "VALUES (@npm, @buku, @pinjam, @tenggat)";
            MySqlCommand cmd = new MySqlCommand(insert, conn);
            cmd.Parameters.AddWithValue("@npm", txtNPM.Text);
            cmd.Parameters.AddWithValue("@buku", cbBuku.SelectedValue);
            cmd.Parameters.AddWithValue("@pinjam", dtPinjam.Value);
            cmd.Parameters.AddWithValue("@tenggat", dtTenggat.Value);
            cmd.ExecuteNonQuery();

            string updateStok = "UPDATE buku SET stok = stok - 1 WHERE id_buku=@id";
            MySqlCommand stokCmd = new MySqlCommand(updateStok, conn);
            stokCmd.Parameters.AddWithValue("@id", cbBuku.SelectedValue);
            stokCmd.ExecuteNonQuery();

            conn.Close();
            MessageBox.Show("Peminjaman berhasil");

            // 🔥 refresh tabel
            LoadPeminjaman();

        }
    }
    
}
