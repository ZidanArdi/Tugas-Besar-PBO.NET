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
using Tugas_Besar_PBO.NET.model;
using Tugas_Besar_PBO.NET.view;

namespace Tugas_Besar_PBO.NET.view
{
    public partial class RegisterForm : Form
    {
        public RegisterForm()
        {
            InitializeComponent();
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            // 1. Validasi Input Kosong (Mencegah data kosong masuk ke database)
            if (string.IsNullOrWhiteSpace(txtNamaLengkap.Text) ||
                string.IsNullOrWhiteSpace(txtNPM.Text) ||
                //string.IsNullOrWhiteSpace(txtUsername.Text) ||
                string.IsNullOrWhiteSpace(txtPassword.Text) ||
                string.IsNullOrWhiteSpace(cmbProdi.Text))
            {
                MessageBox.Show("Semua kolom harus diisi! Jangan biarkan ada data yang kosong.");
                return; // Hentikan proses jika ada field yang kosong
            }

            // 2. Perbaikan Logika Pengecekan Password (Jika Anda memiliki field konfirmasi password)
            // Jika hanya satu field password, abaikan bagian ini atau sesuaikan dengan nama textbox Anda
            /*
            if (txtPassword.Text != txtKonfirmasiPassword.Text)
            {
                MessageBox.Show("Password dan Konfirmasi Password tidak cocok!");
                return;
            }
            */

            // 3. Membuat objek User baru dari input Form
            User newUser = new User()
            {
                NamaLengkap = txtNamaLengkap.Text,
                NPM = txtNPM.Text,
                //Username = txtUsername.Text,
                Password = txtPassword.Text,
                ProgramStudi = cmbProdi.Text
            };

            // 4. Proses Registrasi melalui Controller
            UserController controller = new UserController();
            if (controller.Register(newUser))
            {
                MessageBox.Show("Registrasi Berhasil! Silakan Login.");

                // Redirect kembali ke LoginForm sebagai Form mandiri (bukan child)
                LoginForm login = new LoginForm();
                login.Show();

                this.Close(); // Menutup RegisterForm sepenuhnya
            }
            else
            {
                MessageBox.Show("Registrasi Gagal! Mungkin NPM sudah terdaftar.");
            }
        }

        private void txtNPM_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Opsional: Validasi agar NPM hanya bisa diisi angka
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void chkShowPassword_CheckedChanged(object sender, EventArgs e)
        {
            txtPassword.UseSystemPasswordChar = !chkShowPassword.Checked;
        }
    }
}