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
    public partial class Pengembalian_Buku : Form
    {
        public Pengembalian_Buku()
        {
            InitializeComponent();
            LoadPinjaman(); // ← panggil di sini
            dgvPengembalian.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvPengembalian.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            dgvPengembalian.Dock = DockStyle.Fill;
            dgvPengembalian.ReadOnly = true;
            dgvPengembalian.AllowUserToAddRows = false;
            dgvPengembalian.SelectionMode = DataGridViewSelectionMode.FullRowSelect;


        }
        decimal HitungDenda(DateTime tenggat, DateTime kembali)
        {
            int telat = (kembali - tenggat).Days;
            return telat > 0 ? telat * 2000 : 0;
        }

        void LoadPinjaman()
        {
            using (MySqlConnection conn = Koneksi.GetConnection())
            {
                string q = @"
        SELECT 
            p.id_pinjam,
            CONCAT(u.nama_lengkap, ' - ', b.judul) AS info,
            p.tanggal_tenggat
        FROM peminjaman p
        JOIN users u ON p.npm = u.npm
        JOIN buku b ON p.id_buku = b.id_buku
        WHERE p.status_pinjam = 'Dipinjam'
        ";

                MySqlDataAdapter da = new MySqlDataAdapter(q, conn);
                DataTable dt = new DataTable();
                da.Fill(dt);

                // 🔥 INI WAJIB BUAT NGILANGIN ABU-ABU
                dgvPengembalian.DataSource = dt;

                cbPinjam.DataSource = dt;
                cbPinjam.DisplayMember = "info";
                cbPinjam.ValueMember = "id_pinjam";
                cbPinjam.SelectedIndex = -1;
            }
        }
        private void btnKembali_Click(object sender, EventArgs e)
        {
            if (cbPinjam.SelectedValue == null)
            {
                MessageBox.Show("Pilih transaksi peminjaman!");
                return;
            }

            MySqlConnection conn = Koneksi.GetConnection();
            conn.Open();

            DateTime tenggat = DateTime.Parse(lblTenggat.Text);
            decimal denda = HitungDenda(tenggat, dtKembali.Value);

            string insert = "INSERT INTO pengembalian (id_pinjam, tanggal_dikembalikan, denda, kondisi_buku) " +
                            "VALUES (@id, @tgl, @denda, @kondisi)";
            MySqlCommand cmd = new MySqlCommand(insert, conn);
            cmd.Parameters.AddWithValue("@id", cbPinjam.SelectedValue);
            cmd.Parameters.AddWithValue("@tgl", dtKembali.Value);
            cmd.Parameters.AddWithValue("@denda", denda);
            cmd.Parameters.AddWithValue("@kondisi", cbKondisi.Text);
            cmd.ExecuteNonQuery();

            string update = "UPDATE peminjaman SET status_pinjam='Kembali' WHERE id_pinjam=@id";
            MySqlCommand up = new MySqlCommand(update, conn);
            up.Parameters.AddWithValue("@id", cbPinjam.SelectedValue);
            up.ExecuteNonQuery();

            conn.Close();
            MessageBox.Show("Pengembalian berhasil");

            LoadPinjaman();
        }

        private void cbPinjam_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbPinjam.SelectedIndex == -1) return;

            DataRowView row = (DataRowView)cbPinjam.SelectedItem;
            DateTime tenggat = Convert.ToDateTime(row["tanggal_tenggat"]);

            lblTenggat.Text = tenggat.ToString("dd-MM-yyyy");

            decimal denda = HitungDenda(tenggat, dtKembali.Value);
            txtDenda.Text = denda.ToString();
        }

        private void dtKembali_ValueChanged(object sender, EventArgs e)
        {
            if (cbPinjam.SelectedIndex == -1) return;

            DataRowView row = (DataRowView)cbPinjam.SelectedItem;
            DateTime tenggat = Convert.ToDateTime(row["tanggal_tenggat"]);

            decimal denda = HitungDenda(tenggat, dtKembali.Value);
            txtDenda.Text = denda.ToString();
        }
    }
    }
    

