using System;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace Tugas_Besar_PBO.NET
{
    /// <summary>
    /// Helper class untuk membuat icon perpustakaan secara programatis
    /// Tidak perlu file .ico eksternal — icon dibuat menggunakan GDI+
    /// </summary>
    public static class AppIcon
    {
        private static Icon _cachedIcon;

        /// <summary>
        /// Mendapatkan icon aplikasi perpustakaan (buku terbuka + atap)
        /// Icon di-cache setelah pertama kali dibuat
        /// </summary>
        public static Icon GetIcon()
        {
            if (_cachedIcon != null) return _cachedIcon;

            // Buat bitmap 64x64
            Bitmap bmp = new Bitmap(64, 64);
            using (Graphics g = Graphics.FromImage(bmp))
            {
                g.SmoothingMode = SmoothingMode.AntiAlias;
                g.Clear(Color.White);

                Color biru = Color.FromArgb(65, 105, 225); // RoyalBlue
                Brush brushBiru = new SolidBrush(biru);
                Pen penBiru = new Pen(biru, 2.5f);

                // === ATAP PERPUSTAKAAN ===
                // Segitiga atap
                Point[] atap = {
                    new Point(32, 4),   // puncak
                    new Point(12, 20),  // kiri
                    new Point(52, 20)   // kanan
                };
                g.FillPolygon(brushBiru, atap);

                // Pilar-pilar
                g.FillRectangle(brushBiru, 18, 20, 4, 12);
                g.FillRectangle(brushBiru, 30, 20, 4, 12);
                g.FillRectangle(brushBiru, 42, 20, 4, 12);

                // === BUKU TERBUKA ===
                // Halaman kiri
                Point[] halamanKiri = {
                    new Point(8, 36),
                    new Point(30, 40),
                    new Point(30, 56),
                    new Point(8, 52)
                };
                g.DrawPolygon(penBiru, halamanKiri);

                // Halaman kanan
                Point[] halamanKanan = {
                    new Point(34, 40),
                    new Point(56, 36),
                    new Point(56, 52),
                    new Point(34, 56)
                };
                g.DrawPolygon(penBiru, halamanKanan);

                // Punggung buku (tengah)
                g.DrawLine(penBiru, 32, 38, 32, 58);

                // Garis halaman kiri
                g.DrawLine(new Pen(biru, 1), 14, 42, 26, 44);
                g.DrawLine(new Pen(biru, 1), 14, 46, 26, 48);

                // Garis halaman kanan
                g.DrawLine(new Pen(biru, 1), 38, 44, 50, 42);
                g.DrawLine(new Pen(biru, 1), 38, 48, 50, 46);

                brushBiru.Dispose();
                penBiru.Dispose();
            }

            // Convert Bitmap ke Icon
            IntPtr hIcon = bmp.GetHicon();
            _cachedIcon = Icon.FromHandle(hIcon);

            return _cachedIcon;
        }
    }
}
