using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tugas_Besar_PBO.NET.model
{
    internal class Buku
    {
        public int IdBuku { get; set; }
        public string JudulBuku { get; set; }
        public string Kategori { get; set; }
        public string Penulis { get; set; }
        public string Penerbit { get; set; }
        public int TahunTerbit { get; set; }
        public int Stok { get; set; }
    }
}
