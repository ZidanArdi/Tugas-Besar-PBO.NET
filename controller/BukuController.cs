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
    public class BukuController
    {
        private string connectionString = "server=localhost;port=3306;username=root;password=;database=db_tugasbesar;";

        public DataTable GetAllBuku()
        {
            DataTable dt = new DataTable();
            try
            {
                using (MySqlConnection conn = new MySqlConnection(connectionString))
                {
                    conn.Open();
                    string query = @"SELECT b.id_buku AS ID, b.judul AS Judul, k.nama_kategori AS Kategori, 
                                     b.penulis AS Penulis, b.penerbit AS Penerbit, b.tahun_terbit AS Tahun, 
                                     b.stok AS Stok
                                     FROM buku b
                                     LEFT JOIN kategori k ON b.id_kategori = k.id_kategori";
                    MySqlDataAdapter da = new MySqlDataAdapter(query, conn);
                    da.Fill(dt);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error GetAllBuku: " + ex.Message);
            }
            return dt;
        }

        public bool TambahBuku(string judul, int idKategori, string penulis, string penerbit, int tahun, int stok)
        {
            try
            {
                using (MySqlConnection conn = new MySqlConnection(connectionString))
                {
                    conn.Open();
                    string query = @"INSERT INTO buku (judul, id_kategori, penulis, penerbit, tahun_terbit, stok)
                                     VALUES (@judul, @idKategori, @penulis, @penerbit, @tahun, @stok)";
                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@judul", judul);
                    cmd.Parameters.AddWithValue("@idKategori", idKategori);
                    cmd.Parameters.AddWithValue("@penulis", penulis);
                    cmd.Parameters.AddWithValue("@penerbit", penerbit);
                    cmd.Parameters.AddWithValue("@tahun", tahun);
                    cmd.Parameters.AddWithValue("@stok", stok);
                    return cmd.ExecuteNonQuery() > 0;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error TambahBuku: " + ex.Message);
                return false;
            }
        }

        public bool UpdateBuku(int idBuku, string judul, int idKategori, string penulis, string penerbit, int tahun, int stok)
        {
            try
            {
                using (MySqlConnection conn = new MySqlConnection(connectionString))
                {
                    conn.Open();
                    string query = @"UPDATE buku SET judul=@judul, id_kategori=@idKategori, penulis=@penulis,
                                     penerbit=@penerbit, tahun_terbit=@tahun, stok=@stok
                                     WHERE id_buku=@idBuku";
                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@idBuku", idBuku);
                    cmd.Parameters.AddWithValue("@judul", judul);
                    cmd.Parameters.AddWithValue("@idKategori", idKategori);
                    cmd.Parameters.AddWithValue("@penulis", penulis);
                    cmd.Parameters.AddWithValue("@penerbit", penerbit);
                    cmd.Parameters.AddWithValue("@tahun", tahun);
                    cmd.Parameters.AddWithValue("@stok", stok);
                    return cmd.ExecuteNonQuery() > 0;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error UpdateBuku: " + ex.Message);
                return false;
            }
        }

        public bool HapusBuku(int idBuku)
        {
            try
            {
                using (MySqlConnection conn = new MySqlConnection(connectionString))
                {
                    conn.Open();
                    string query = "DELETE FROM buku WHERE id_buku=@idBuku";
                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@idBuku", idBuku);
                    return cmd.ExecuteNonQuery() > 0;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error HapusBuku: " + ex.Message);
                return false;
            }
        }
    }
}