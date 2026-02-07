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
    public class PeminjamanController
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
                    string query = @"SELECT p.id_pinjam, u.nama_lengkap, b.judul, p.tanggal_pinjam, p.tanggal_tenggat, p.status_pinjam
                                     FROM peminjaman p
                                     JOIN users u ON p.npm = u.npm
                                     JOIN buku b ON p.id_buku = b.id_buku
                                     WHERE p.status_pinjam='Dipinjam'";
                    MySqlDataAdapter da = new MySqlDataAdapter(query, conn);
                    da.Fill(dt);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error GetPeminjamanAktif: " + ex.Message);
            }
            return dt;
        }

        public bool TambahPeminjaman(string npm, int idBuku, DateTime tanggalPinjam, DateTime tanggalTenggat)
        {
            try
            {
                using (MySqlConnection conn = new MySqlConnection(connectionString))
                {
                    conn.Open();
                    string insert = @"INSERT INTO peminjaman (npm, id_buku, tanggal_pinjam, tanggal_tenggat) 
                                      VALUES (@npm, @idBuku, @tglPinjam, @tglTenggat)";
                    MySqlCommand cmd = new MySqlCommand(insert, conn);
                    cmd.Parameters.AddWithValue("@npm", npm);
                    cmd.Parameters.AddWithValue("@idBuku", idBuku);
                    cmd.Parameters.AddWithValue("@tglPinjam", tanggalPinjam);
                    cmd.Parameters.AddWithValue("@tglTenggat", tanggalTenggat);
                    cmd.ExecuteNonQuery();

                    string updateStok = "UPDATE buku SET stok = stok - 1 WHERE id_buku=@idBuku";
                    MySqlCommand stokCmd = new MySqlCommand(updateStok, conn);
                    stokCmd.Parameters.AddWithValue("@idBuku", idBuku);
                    stokCmd.ExecuteNonQuery();
                    return true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error TambahPeminjaman: " + ex.Message);
                return false;
            }
        }
    }
}