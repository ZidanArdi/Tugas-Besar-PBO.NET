using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Tugas_Besar_PBO.NET.controller
{
    public class PengembalianController
    {
        private string connectionString = "server=localhost;port=3306;username=root;password=;database=db_tugasbesar;";

        public DataTable GetPeminjamanAktif()
        {
            DataTable dt = new DataTable();
            try
            {
                using (MySqlConnection conn = new MySqlConnection(connectionString))
                {
                    conn.Open();
                    string query = @"SELECT p.id_pinjam, CONCAT(u.nama_lengkap, ' - ', b.judul) AS info,
                                     p.tanggal_tenggat, p.id_buku
                                     FROM peminjaman p
                                     JOIN users u ON p.npm = u.npm
                                     JOIN buku b ON p.id_buku = b.id_buku
                                     WHERE p.status_pinjam='Dipinjam'";
                    MySqlDataAdapter da = new MySqlDataAdapter(query, conn);
                    da.Fill(dt);
                }
            }
            catch (Exception ex) { MessageBox.Show("Error GetPeminjamanAktif: " + ex.Message); }
            return dt;
        }

        public bool SimpanPengembalian(int idPinjam, DateTime tanggalKembali, decimal denda, string kondisi)
        {
            try
            {
                using (MySqlConnection conn = new MySqlConnection(connectionString))
                {
                    conn.Open();
                    string insert = @"INSERT INTO pengembalian (id_pinjam, tanggal_dikembalikan, denda, kondisi_buku)
                                      VALUES (@id, @tgl, @denda, @kondisi)";
                    MySqlCommand cmd = new MySqlCommand(insert, conn);
                    cmd.Parameters.AddWithValue("@id", idPinjam);
                    cmd.Parameters.AddWithValue("@tgl", tanggalKembali);
                    cmd.Parameters.AddWithValue("@denda", denda);
                    cmd.Parameters.AddWithValue("@kondisi", kondisi);
                    cmd.ExecuteNonQuery();

                    string update = "UPDATE peminjaman SET status_pinjam='Kembali' WHERE id_pinjam=@id";
                    MySqlCommand up = new MySqlCommand(update, conn);
                    up.Parameters.AddWithValue("@id", idPinjam);
                    up.ExecuteNonQuery();

                    string updateStok = @"UPDATE buku SET stok = stok + 1 
                                           WHERE id_buku=(SELECT id_buku FROM peminjaman WHERE id_pinjam=@id)";
                    MySqlCommand stokCmd = new MySqlCommand(updateStok, conn);
                    stokCmd.Parameters.AddWithValue("@id", idPinjam);
                    stokCmd.ExecuteNonQuery();
                    return true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error SimpanPengembalian: " + ex.Message);
                return false;
            }
        }

        public decimal HitungDenda(DateTime tenggat, DateTime kembali)
        {
            int telat = (kembali - tenggat).Days;
            return telat > 0 ? telat * 2000 : 0;
        }
    }
}
