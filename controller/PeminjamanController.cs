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
    /// PeminjamanController - Menangani semua logika peminjaman dan pengembalian buku
    /// ================================================================================
    /// Semua operasi terkait peminjaman dan pengembalian dilakukan di sini.
    /// View (Form) hanya memanggil method di controller ini.
    /// </summary>
    internal class PeminjamanController
    {
        // ╔══════════════════════════════════════════════════════════════╗
        // ║                   LOAD DATA PEMINJAMAN                      ║
        // ╚══════════════════════════════════════════════════════════════╝

        /// <summary>
        /// Mengambil semua data peminjaman dengan JOIN ke tabel buku
        /// Digunakan oleh PeminjamanForm untuk menampilkan histori peminjaman
        /// </summary>
        /// <returns>DataTable berisi data peminjaman</returns>
        public DataTable GetSemuaPeminjaman()
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
                return dt;
            }
        }

        // ╔══════════════════════════════════════════════════════════════╗
        // ║                   PROSES PEMINJAMAN                         ║
        // ╚══════════════════════════════════════════════════════════════╝

        /// <summary>
        /// Memproses peminjaman buku baru
        /// Termasuk insert data peminjaman DAN update stok buku (stok - 1)
        /// </summary>
        /// <param name="peminjaman">Object Peminjaman berisi data peminjaman</param>
        /// <returns>true jika berhasil</returns>
        public bool PinjamBuku(Peminjaman peminjaman)
        {
            MySqlConnection conn = Koneksi.GetConnection();
            conn.Open();

            // Gunakan transaction agar insert + update stok konsisten
            MySqlTransaction transaction = conn.BeginTransaction();

            try
            {
                // 1. INSERT data peminjaman
                string insert = "INSERT INTO peminjaman (npm, id_buku, tanggal_pinjam, tanggal_tenggat) " +
                                "VALUES (@npm, @buku, @pinjam, @tenggat)";
                MySqlCommand cmd = new MySqlCommand(insert, conn, transaction);
                cmd.Parameters.AddWithValue("@npm", peminjaman.NPM);
                cmd.Parameters.AddWithValue("@buku", peminjaman.IdBuku);
                cmd.Parameters.AddWithValue("@pinjam", peminjaman.TanggalPinjam);
                cmd.Parameters.AddWithValue("@tenggat", peminjaman.TanggalTenggat);
                cmd.ExecuteNonQuery();

                // 2. UPDATE stok buku (kurangi 1)
                string updateStok = "UPDATE buku SET stok = stok - 1 WHERE id_buku=@id";
                MySqlCommand stokCmd = new MySqlCommand(updateStok, conn, transaction);
                stokCmd.Parameters.AddWithValue("@id", peminjaman.IdBuku);
                stokCmd.ExecuteNonQuery();

                transaction.Commit();
                return true;
            }
            catch (Exception ex)
            {
                transaction.Rollback();
                throw new Exception("Gagal memproses peminjaman: " + ex.Message);
            }
            finally
            {
                conn.Close();
            }
        }

        // ╔══════════════════════════════════════════════════════════════╗
        // ║                   LOAD DATA PENGEMBALIAN                    ║
        // ╚══════════════════════════════════════════════════════════════╝

        /// <summary>
        /// Mengambil data peminjaman yang belum dikembalikan (status = 'Dipinjam')
        /// Digunakan oleh ComboBox untuk memilih transaksi yang akan dikembalikan
        /// </summary>
        /// <returns>DataTable berisi data peminjaman aktif</returns>
        public DataTable GetPeminjamanAktif()
        {
            using (MySqlConnection conn = Koneksi.GetConnection())
            {
                string query = @"
                    SELECT 
                        p.id_pinjam,
                        CONCAT(u.nama_lengkap, ' - ', b.judul) AS info,
                        p.tanggal_tenggat
                    FROM peminjaman p
                    JOIN users u ON p.npm = u.npm
                    JOIN buku b ON p.id_buku = b.id_buku
                    WHERE p.status_pinjam = 'Dipinjam'";

                MySqlDataAdapter da = new MySqlDataAdapter(query, conn);
                DataTable dt = new DataTable();
                da.Fill(dt);
                return dt;
            }
        }

        /// <summary>
        /// Mengambil SEMUA data peminjaman + data pengembalian (denda, kondisi)
        /// Data tetap tampil setelah dikembalikan (tidak hilang)
        /// LEFT JOIN agar peminjaman yang belum dikembalikan tetap tampil
        /// </summary>
        /// <returns>DataTable berisi semua data peminjaman lengkap dengan denda dan kondisi</returns>
        public DataTable GetDataPengembalian()
        {
            using (MySqlConnection conn = Koneksi.GetConnection())
            {
                string query = @"
                    SELECT 
                        p.id_pinjam AS 'ID',
                        u.nama_lengkap AS 'Nama',
                        b.judul AS 'Judul Buku',
                        p.tanggal_pinjam AS 'Tgl Pinjam',
                        p.tanggal_tenggat AS 'Tgl Tenggat',
                        pg.tanggal_dikembalikan AS 'Tgl Kembali',
                        p.status_pinjam AS 'Status',
                        pg.kondisi_buku AS 'Kondisi',
                        pg.denda AS 'Denda'
                    FROM peminjaman p
                    JOIN users u ON p.npm = u.npm
                    JOIN buku b ON p.id_buku = b.id_buku
                    LEFT JOIN pengembalian pg ON p.id_pinjam = pg.id_pinjam
                    ORDER BY p.id_pinjam DESC";

                MySqlDataAdapter da = new MySqlDataAdapter(query, conn);
                DataTable dt = new DataTable();
                da.Fill(dt);
                return dt;
            }
        }

        // ╔═════════════════════════════════════════════════════════════╗
        // ║                    HITUNG DENDA OTOMATIS                    ║
        // ╠═════════════════════════════════════════════════════════════╣
        // ║  RUMUS:                                                     ║
        // ║  1. Denda Keterlambatan:                                    ║
        // ║     Jika telat > 0 hari → Denda = hari × Rp2.000            ║
        // ║     Jika tepat waktu/lebih awal → Denda = Rp0               ║
        // ║                                                             ║
        // ║  2. Denda Kerusakan (kondisi "Rusak"):                      ║
        // ║     Tambahan denda Rp25.000 untuk buku rusak                ║
        // ║                                                             ║
        // ║  CONTOH:                                                    ║
        // ║  ┌──────────────┬──────────────┬────────┬───────┬─────────┐ ║
        // ║  │ Tgl Tenggat  │ Tgl Kembali  │ Telat  │Kondisi│ Denda   │ ║
        // ║  ├──────────────┼──────────────┼────────┼───────┼─────────┤ ║
        // ║  │ 05 Feb 2026  │ 05 Feb 2026  │ 0 hari │ Baik  │ Rp 0    │ ║
        // ║  │ 05 Feb 2026  │ 08 Feb 2026  │ 3 hari │ Baik  │ Rp 6.000│ ║
        // ║  │ 05 Feb 2026  │ 05 Feb 2026  │ 0 hari │ Rusak │Rp25.000 │ ║
        // ║  │ 05 Feb 2026  │ 08 Feb 2026  │ 3 hari │ Rusak │Rp31.000 │ ║
        // ║  └──────────────┴──────────────┴────────┴───────┴─────────┘ ║
        // ╚══════════════════════════════════════════════════════════════╝

        // Konstanta denda
        private const int DENDA_PER_HARI = 2000;        // Rp2.000 per hari keterlambatan
        private const int DENDA_KERUSAKAN = 25000;       // Rp25.000 denda tambahan jika buku rusak

        /// <summary>
        /// Menghitung total denda pengembalian buku
        /// Total = Denda Keterlambatan + Denda Kerusakan (jika kondisi "Rusak")
        /// </summary>
        /// <param name="tanggalTenggat">Tanggal batas pengembalian dari database</param>
        /// <param name="tanggalKembali">Tanggal pengembalian aktual</param>
        /// <param name="kondisiBuku">Kondisi buku saat dikembalikan ("Baik" / "Rusak")</param>
        /// <returns>Jumlah total denda dalam Rupiah (decimal)</returns>
        public decimal HitungDenda(DateTime tanggalTenggat, DateTime tanggalKembali, string kondisiBuku = "Baik")
        {
            // 1. Hitung denda keterlambatan
            int telat = (tanggalKembali - tanggalTenggat).Days;
            decimal dendaKeterlambatan = telat > 0 ? telat * DENDA_PER_HARI : 0;

            // 2. Tambahkan denda kerusakan jika kondisi buku "Rusak"
            decimal dendaKerusakan = (kondisiBuku == "Rusak") ? DENDA_KERUSAKAN : 0;

            // 3. Total denda = keterlambatan + kerusakan
            return dendaKeterlambatan + dendaKerusakan;
        }

        // ╔══════════════════════════════════════════════════════════════╗
        // ║                   PROSES PENGEMBALIAN                       ║
        // ╚══════════════════════════════════════════════════════════════╝

        /// <summary>
        /// Memproses pengembalian buku
        /// Termasuk:
        /// 1. Insert data ke tabel pengembalian (dengan denda yang sudah dihitung)
        /// 2. Update status peminjaman menjadi 'Kembali'
        /// </summary>
        /// <param name="pengembalian">Object Pengembalian berisi data pengembalian</param>
        /// <returns>true jika berhasil</returns>
        public bool KembalikanBuku(Pengembalian pengembalian)
        {
            MySqlConnection conn = Koneksi.GetConnection();
            conn.Open();

            // Gunakan transaction agar insert + update status konsisten
            MySqlTransaction transaction = conn.BeginTransaction();

            try
            {
                // 1. INSERT data pengembalian ke database
                string insert = "INSERT INTO pengembalian (id_pinjam, tanggal_dikembalikan, denda, kondisi_buku) " +
                                "VALUES (@id, @tgl, @denda, @kondisi)";
                MySqlCommand cmd = new MySqlCommand(insert, conn, transaction);
                cmd.Parameters.AddWithValue("@id", pengembalian.IdPinjam);
                cmd.Parameters.AddWithValue("@tgl", pengembalian.TanggalDikembalikan);
                cmd.Parameters.AddWithValue("@denda", pengembalian.Denda);
                cmd.Parameters.AddWithValue("@kondisi", pengembalian.KondisiBuku);
                cmd.ExecuteNonQuery();

                // 2. UPDATE status peminjaman menjadi 'Kembali'
                string update = "UPDATE peminjaman SET status_pinjam='Kembali' WHERE id_pinjam=@id";
                MySqlCommand up = new MySqlCommand(update, conn, transaction);
                up.Parameters.AddWithValue("@id", pengembalian.IdPinjam);
                up.ExecuteNonQuery();

                transaction.Commit();
                return true;
            }
            catch (Exception ex)
            {
                transaction.Rollback();
                throw new Exception("Gagal memproses pengembalian: " + ex.Message);
            }
            finally
            {
                conn.Close();
            }
        }
    }
}
