using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tugas_Besar_PBO.NET.model;
//using System.Data.SqlClient;
using System.Data;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace Tugas_Besar_PBO.NET.controller
{
    internal class UserController
    {
        private string connectionString = "server=localhost;port=3306;username=root;password=;database=db_tugasbesar;";

        public string Login(string npm, string password)
        {
            // Cek Admin Statis sesuai permintaan Anda
            if (npm == "1234567" && password == "admin123")
            {
                return "admin";
            }

            try
            {
                using (MySqlConnection conn = new MySqlConnection(connectionString))
                {
                    conn.Open();
                    // Query sesuai kolom di database Anda: npm, username, password, role
                    string query = "SELECT role FROM users WHERE npm=@npm AND password=@pass";
                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@npm", npm);
                    cmd.Parameters.AddWithValue("@pass", password);

                    object result = cmd.ExecuteScalar();
                    return result?.ToString(); // Mengembalikan role (mahasiswa/admin) jika ditemukan
                }
            }
            catch (Exception ex)    
            {
                System.Windows.Forms.MessageBox.Show("Error Database: " + ex.Message);
                return null;
            }
        }

        // Tugas Besar PBO .NET/controller/UserController.cs

        public bool Register(User user)
        {
            try
            {
                using (MySqlConnection conn = new MySqlConnection(connectionString))
                {
                    conn.Open();
                    // PERUBAHAN: Kolom username dan parameter @user DIHAPUS
                    string query = "INSERT INTO users (password, nama_lengkap, npm, program_studi, role, status_anggota) " +
                                   "VALUES (@pass, @nama, @npm, @prodi, 'mahasiswa', 'aktif')";

                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@pass", user.Password);
                    cmd.Parameters.AddWithValue("@nama", user.NamaLengkap);
                    cmd.Parameters.AddWithValue("@npm", user.NPM);
                    cmd.Parameters.AddWithValue("@prodi", user.ProgramStudi);

                    return cmd.ExecuteNonQuery() > 0;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Registrasi Gagal: " + ex.Message);
                return false;
            }
        }

        public DataTable ShowBuku()
        {
            DataTable dt = new DataTable();
            try
            {
                using (MySqlConnection conn = new MySqlConnection(connectionString))
                {
                    conn.Open();
                    // Alias digunakan agar header DataGridView rapi
                    string query = "SELECT id_buku AS 'ID', judul_buku AS 'Judul', kategori AS 'Kategori', " +
                                   "penulis AS 'Penulis', penerbit AS 'Penerbit', tahun_terbit AS 'Tahun', " +
                                   "stok AS 'Stok' FROM buku";
                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                    da.Fill(dt);
                }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
            return dt;
        }

        // Method untuk Input Buku Baru
        public bool TambahBuku(string judul, string kategori, string penulis, string penerbit, int tahun, int stok)
        {
            try
            {
                using (MySqlConnection conn = new MySqlConnection(connectionString))
                {
                    conn.Open();
                    string query = "INSERT INTO buku (judul_buku, kategori, penulis, penerbit, tahun_terbit, stok) " +
                                   "VALUES (@judul, @kat, @pen, @pbt, @thn, @stok)";
                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@judul", judul);
                    cmd.Parameters.AddWithValue("@kat", kategori);
                    cmd.Parameters.AddWithValue("@pen", penulis);
                    cmd.Parameters.AddWithValue("@pbt", penerbit);
                    cmd.Parameters.AddWithValue("@thn", tahun);
                    cmd.Parameters.AddWithValue("@stok", stok);
                    return cmd.ExecuteNonQuery() > 0;
                }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); return false; }
        }

    }
}
