using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Tugas_Besar_PBO.NET.controller;
using MySql.Data.MySqlClient;
using Tugas_Besar_PBO.NET.view;
using Tugas_Besar_PBO.NET;

namespace Tugas_Besar_PBO.NET.view
{
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtNPM.Text) ||
                string.IsNullOrWhiteSpace(txtPassword.Text))
            {
                MessageBox.Show("NPM dan Password wajib diisi!");
                return; // Hentikan proses jika ada yang kosong
            }

            UserController controller = new UserController();
            string role = controller.Login(txtNPM.Text, txtPassword.Text);

            if (role != null)
            {
                MessageBox.Show($"Login Berhasil sebagai {role}!");

                // 1. Buat instansi ParentForm baru
                ParentForm mainForm = new ParentForm();

                // 2. Tampilkan ParentForm terlebih dahulu
                mainForm.Show();

                // 3. Panggil fungsi UnlockMenu pada instansi mainForm yang baru saja dibuka
                mainForm.UnlockMenu(role);

                // 4. Tutup atau sembunyikan LoginForm agar hilang dari layar
                this.Hide();
            }
            else
            {
                MessageBox.Show("NPM atau Password salah!");
            }
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            RegisterForm reg = new RegisterForm();
            // DISESUAIKAN: Menjadikan RegisterForm sebagai Child Form agar sesuai syarat Poin 1 
            reg.MdiParent = this.MdiParent;
            reg.StartPosition = FormStartPosition.CenterScreen;
            reg.Show();

            this.Close(); // Menutup login saat pindah ke register agar tidak menumpuk
        }

        private void chkShowPass_CheckedChanged(object sender, EventArgs e)
        {
            // Fitur Show Password: Jika dicentang maka karakter terlihat [cite: 18]
            txtPassword.UseSystemPasswordChar = !chkShowPass.Checked;
        }
    }
}