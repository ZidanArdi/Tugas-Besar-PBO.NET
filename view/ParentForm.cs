using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Tugas_Besar_PBO.NET.view;

namespace Tugas_Besar_PBO.NET
{
    public partial class ParentForm : Form
    {
        public string UserRole { get; set; }

        public ParentForm()
        {
            InitializeComponent();
            this.Icon = AppIcon.GetIcon();
        }

        private void ParentForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        public void ShowLoginForm()
        {
            LoginForm login = new LoginForm();
            login.MdiParent = this; // Memenuhi syarat poin 1 [cite: 5]
            login.StartPosition = FormStartPosition.CenterScreen;
            login.Show();
        }

        public void SetRole(string role)
        {
            this.UserRole = role;
        }

        private void registerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RegisterForm regForm = new RegisterForm();
            regForm.MdiParent = this;
            regForm.Show();
        }

        private void ParentForm_Load(object sender, EventArgs e)
        {
            // Saat aplikasi pertama dimuat, menu dikunci dan menu Login ditampilkan [cite: 5, 7]
            //menuDataBuku.Enabled = false;
            //menuTransaksi.Enabled = false;

            //// Pastikan menu login terlihat sebelum user masuk
            //menuLogin.Visible = true;

            //ShowLoginForm();
        }

        // Fungsi ini dipanggil dari LoginForm setelah berhasil login
        public void UnlockMenu(string role)
        {
            //this.UserRole = role;

            // 1. Sembunyikan menu Login (sesuaikan nama komponennya)
            //menuLogin.Visible = false;

            // 2. Buka akses menu utama
            //if (role == "admin")
            //{
            //    menuDataBuku.Enabled = true;
            //    menuTransaksi.Enabled = true;
            //    menuDataBuku.Enabled = true;
            //}
            //else
            //{
            //    menuDataBuku.Enabled = true;
            //    menuTransaksi.Enabled = true; // Mahasiswa dibatasi
            //    menuDataBuku.Enabled = true;
            //}
            // Sembunyikan menu login di strip menu
            this.UserRole = role; // PENTING: Simpan role di sini
            menuLogin.Visible = false;

            if (role == "admin")
            {
                menuDataBuku.Enabled = true;
                peminjamanToolStripMenuItem.Enabled = true;
            }
            else
            {
                menuDataBuku.Enabled = true;
                peminjamanToolStripMenuItem.Enabled = true; // Mahasiswa tidak bisa transaksi
            }
        }

        private void menuDataBuku_Click(object sender, EventArgs e)
        {
            // Cek role dari session login
            KoleksiBukuForm koleksi = new KoleksiBukuForm(this.UserRole);

            koleksi.MdiParent = this;
            koleksi.StartPosition = FormStartPosition.CenterScreen;
            koleksi.Show();
        }

        private void menuExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void menuLogin_Click(object sender, EventArgs e)
        {
            if (menuLogin.Visible)
            {
                ShowLoginForm();
                menuLogin.Visible = true;

            }

        }
        PeminjamanForm pf;
        Pengembalian_Buku kf;

        private void peminjamanToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (pf == null || pf.IsDisposed)
                pf = new PeminjamanForm();

            pf.Show();
            pf.BringToFront();
            pf.MdiParent = this;
            pf.StartPosition = FormStartPosition.CenterScreen;
        }
        

        private void pengembalianToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            if (kf == null || kf.IsDisposed)
                kf = new Pengembalian_Buku();

            kf.Show();
            kf.BringToFront();
            kf.MdiParent = this;
            kf.StartPosition = FormStartPosition.CenterScreen;
        }
    }
}