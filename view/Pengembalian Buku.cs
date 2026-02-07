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
                string q = @"SELECT p.id_pinjam, 
                                CONCAT(u.nama, ' - ', b.judul) AS info,
                                p.tanggal_jatuh_tempo,
                                p.id_buku
                         FROM peminjaman p
                         JOIN users u ON p.id_user = u.id_user
                         JOIN buku b ON p.id_buku = b.id_buku
                         WHERE p.status_pinjam = 'Dipinjam'";

                MySqlDataAdapter da = new MySqlDataAdapter(q, conn);
                DataTable dt = new DataTable();
                da.Fill(dt);

                cbPinjam.DataSource = dt;
                cbPinjam.DisplayMember = "info";
                cbPinjam.ValueMember = "id_pinjam";
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
        }

        private void cbPinjam_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbPinjam.SelectedIndex == -1) return;

            // ambil tanggal tenggat dari row yang dipilih
            DataRowView row = (DataRowView)cbPinjam.SelectedItem;
            DateTime tenggat = Convert.ToDateTime(row["tanggal_jatuh_tempo"]);

            lblTenggat.Text = tenggat.ToString("dd-MM-yyyy");

            // hitung denda otomatis
            decimal denda = HitungDenda(tenggat, DateTime.Today);
            txtDenda.Text = denda.ToString();
        }
    }
    }
    

