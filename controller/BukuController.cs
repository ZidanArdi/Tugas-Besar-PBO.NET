using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using Tugas_Besar_PBO.NET.Database;
using Tugas_Besar_PBO.NET.model;

namespace Tugas_Besar_PBO.NET.controller
{
    /// <summary>
    /// BukuController - Menangani semua logika proses buku
    /// ====================================================
    /// Semua operasi CRUD dan query buku dilakukan di sini.
    /// View (Form) hanya memanggil method di controller ini.
    /// </summary>
    internal class BukuController
    {
        // ╔══════════════════════════════════════════════════════════════╗
        // ║                     READ / LOAD DATA                        ║
        // ╚══════════════════════════════════════════════════════════════╝

        /// <summary>
        /// Mengambil semua data buku dengan JOIN ke tabel kategori
        /// </summary>
        /// <returns>DataTable berisi data buku + nama kategori</returns>
        public DataTable GetSemuaBuku()
        {
            using (MySqlConnection conn = Koneksi.GetConnection())
            {
                string query = @"SELECT b.id_buku, b.judul, b.penulis, b.penerbit,
                                b.tahun_terbit, k.nama_kategori, b.stok
                         FROM buku b
                         JOIN kategori k ON b.id_kategori = k.id_kategori";

                MySqlDataAdapter da = new MySqlDataAdapter(query, conn);
                DataTable dt = new DataTable();
                da.Fill(dt);
                return dt;
            }
        }

        /// <summary>
        /// Mencari buku berdasarkan judul atau penulis
        /// </summary>
        /// <param name="keyword">Kata kunci pencarian</param>
        /// <returns>DataTable berisi hasil pencarian</returns>
        public DataTable CariBuku(string keyword)
        {
            using (MySqlConnection conn = Koneksi.GetConnection())
            {
                string query = @"SELECT b.id_buku, b.judul, b.penulis, b.penerbit,
                                b.tahun_terbit, k.nama_kategori, b.stok
                         FROM buku b
                         JOIN kategori k ON b.id_kategori = k.id_kategori
                         WHERE b.judul LIKE @k OR b.penulis LIKE @k";

                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@k", "%" + keyword + "%");

                MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                return dt;
            }
        }

        /// <summary>
        /// Mengambil semua data kategori untuk ComboBox
        /// </summary>
        /// <returns>DataTable berisi id_kategori dan nama_kategori</returns>
        public DataTable GetSemuaKategori()
        {
            using (MySqlConnection conn = Koneksi.GetConnection())
            {
                string query = "SELECT id_kategori, nama_kategori FROM kategori";
                MySqlDataAdapter da = new MySqlDataAdapter(query, conn);
                DataTable dt = new DataTable();
                da.Fill(dt);
                return dt;
            }
        }

        /// <summary>
        /// Mengambil buku yang stoknya > 0 (untuk dropdown peminjaman)
        /// </summary>
        /// <returns>DataTable berisi id_buku dan judul</returns>
        public DataTable GetBukuTersedia()
        {
            using (MySqlConnection conn = Koneksi.GetConnection())
            {
                string query = "SELECT id_buku, judul FROM buku WHERE stok > 0";
                MySqlDataAdapter da = new MySqlDataAdapter(query, conn);
                DataTable dt = new DataTable();
                da.Fill(dt);
                return dt;
            }
        }

        // ╔══════════════════════════════════════════════════════════════╗
        // ║                     CREATE / TAMBAH                         ║
        // ╚══════════════════════════════════════════════════════════════╝

        /// <summary>
        /// Menambahkan buku baru ke database
        /// </summary>
        /// <param name="buku">Object Buku yang berisi data buku baru</param>
        /// <returns>true jika berhasil, false jika gagal</returns>
        public bool TambahBuku(Buku buku)
        {
            try
            {
                using (MySqlConnection conn = Koneksi.GetConnection())
                {
                    conn.Open();
                    string query = @"INSERT INTO buku 
                        (judul, penulis, penerbit, tahun_terbit, id_kategori, stok) 
                        VALUES (@j, @p, @pb, @t, @k, @s)";

                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@j", buku.Judul);
                    cmd.Parameters.AddWithValue("@p", buku.Penulis);
                    cmd.Parameters.AddWithValue("@pb", buku.Penerbit);
                    cmd.Parameters.AddWithValue("@t", buku.TahunTerbit);
                    cmd.Parameters.AddWithValue("@k", buku.IdKategori);
                    cmd.Parameters.AddWithValue("@s", buku.Stok);

                    return cmd.ExecuteNonQuery() > 0;
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Gagal menambah buku: " + ex.Message);
            }
        }

        // ╔══════════════════════════════════════════════════════════════╗
        // ║                     UPDATE / EDIT                           ║
        // ╚══════════════════════════════════════════════════════════════╝

        /// <summary>
        /// Mengupdate data buku yang sudah ada
        /// </summary>
        /// <param name="buku">Object Buku dengan data yang sudah diubah</param>
        /// <returns>true jika berhasil, false jika gagal</returns>
        public bool UpdateBuku(Buku buku)
        {
            try
            {
                using (MySqlConnection conn = Koneksi.GetConnection())
                {
                    conn.Open();
                    string query = @"UPDATE buku SET 
                            judul=@judul,
                            penulis=@penulis,
                            penerbit=@penerbit,
                            tahun_terbit=@tahun,
                            id_kategori=@kategori,
                            stok=@stok
                         WHERE id_buku=@id";

                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@judul", buku.Judul);
                    cmd.Parameters.AddWithValue("@penulis", buku.Penulis);
                    cmd.Parameters.AddWithValue("@penerbit", buku.Penerbit);
                    cmd.Parameters.AddWithValue("@tahun", buku.TahunTerbit);
                    cmd.Parameters.AddWithValue("@kategori", buku.IdKategori);
                    cmd.Parameters.AddWithValue("@stok", buku.Stok);
                    cmd.Parameters.AddWithValue("@id", buku.IdBuku);

                    return cmd.ExecuteNonQuery() > 0;
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Gagal mengupdate buku: " + ex.Message);
            }
        }

        // ╔══════════════════════════════════════════════════════════════╗
        // ║                     DELETE / HAPUS                          ║
        // ╚══════════════════════════════════════════════════════════════╝

        /// <summary>
        /// Menghapus buku berdasarkan ID
        /// </summary>
        /// <param name="idBuku">ID buku yang akan dihapus</param>
        /// <returns>true jika berhasil, false jika gagal</returns>
        public bool HapusBuku(int idBuku)
        {
            try
            {
                using (MySqlConnection conn = Koneksi.GetConnection())
                {
                    conn.Open();
                    string query = "DELETE FROM buku WHERE id_buku=@id";
                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@id", idBuku);

                    return cmd.ExecuteNonQuery() > 0;
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Gagal menghapus buku: " + ex.Message);
            }
        }
    }
}
