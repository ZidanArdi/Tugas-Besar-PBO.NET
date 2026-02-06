using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Tugas_Besar_PBO.NET.view
{
    public partial class KoleksiBukuForm : Form
    {
        private string _role;

        public KoleksiBukuForm(string role)
        {
            InitializeComponent();
            //TampilBuku();
            this._role = role;
        }

        private void TampilBuku()
        {
            // Contoh data buku
            //dataGridViewBuku.DataSource = controller.ShowBuku();
        }

        private void btnSimpan_Click(object sender, EventArgs e)
        {

        }

        private void KoleksiBukuForm_Load(object sender, EventArgs e)
        {
            if (_role != "admin")
            {
                // Sembunyikan panel input buku
                groupBox2.Visible = false;

                // Opsional: Naikkan posisi tabel (DataGridView) agar mengisi ruang kosong
                dataGridViewBuku.Top = groupBox2.Top;
                dataGridViewBuku.Height += groupBox2.Height;

                this.Text = "Koleksi Buku (Mode View - Mahasiswa)";
            }
        }
    }
}
