using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tugas_Besar_PBO.NET.model
{
    /// <summary>
    /// Model Peminjaman - Hanya menyimpan data (properties), tanpa logika UI atau database
    /// </summary>
    internal class Peminjaman
    {
        public int IdPinjam { get; set; }
        public string NPM { get; set; }
        public int IdBuku { get; set; }
        public string JudulBuku { get; set; }
        public DateTime TanggalPinjam { get; set; }
        public DateTime TanggalTenggat { get; set; }
        public string StatusPinjam { get; set; }
    }

    /// <summary>
    /// Model Pengembalian - Data pengembalian buku
    /// </summary>
    internal class Pengembalian
    {
        public int IdPinjam { get; set; }
        public DateTime TanggalDikembalikan { get; set; }
        public decimal Denda { get; set; }
        public string KondisiBuku { get; set; }
    }
}
