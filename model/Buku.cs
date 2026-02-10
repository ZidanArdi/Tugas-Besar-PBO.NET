using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tugas_Besar_PBO.NET.model
{
    /// <summary>
    /// Model Buku - Hanya menyimpan data (properties), tanpa logika UI atau database
    /// </summary>
    internal class Buku
    {
        public int IdBuku { get; set; }
        public string Judul { get; set; }
        public string Penulis { get; set; }
        public string Penerbit { get; set; }
        public int TahunTerbit { get; set; }
        public int IdKategori { get; set; }
        public string NamaKategori { get; set; }
        public int Stok { get; set; }
    }
}
