using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlTypes;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace QLSach
{
    public partial class QliSach : Form
    {
        private string connectionString = @"Data Source=DESKTOP-01AQ8BK\\CLONEK;Initial Catalog=Sach;Integrated Security=True;Trust Server Certificate=True";
        SqlConnection conn;
        SqlCommand sqlcmd;
        public QliSach()
        {
            InitializeComponent();
        }

        private void phiếuNhậpSáchToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void nhậpSáchToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PhieuNhap formPhieuNhap = new PhieuNhap();
            formPhieuNhap.ShowDialog(); // Hiển thị dưới dạng cửa sổ độc lập
        }

        private void nhậpThểLoạiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            NhapTheLoai formPhieuNhap = new NhapTheLoai();
            formPhieuNhap.ShowDialog(); // Hiển thị dưới dạng cửa sổ độc lập
        }

        private void nhậpTácGiảToolStripMenuItem_Click(object sender, EventArgs e)
        {
            NhapTacGia formPhieuNhap = new NhapTacGia();
            formPhieuNhap.ShowDialog(); // Hiển thị dưới dạng cửa sổ độc lập
        }

        private void nhậpNXBToolStripMenuItem_Click(object sender, EventArgs e)
        {
            NhapNXB formPhieuNhap = new NhapNXB();
            formPhieuNhap.ShowDialog(); // Hiển thị dưới dạng cửa sổ độc lập
        }

        private void phiếuNhậpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PN formPhieuNhap = new PN();
            formPhieuNhap.ShowDialog(); // Hiển thị dưới dạng cửa sổ độc lập
        }

        private void nhậpHoáĐơnToolStripMenuItem_Click(object sender, EventArgs e)
        {
            HoaDon formPhieuNhap = new HoaDon();
            formPhieuNhap.ShowDialog(); // Hiển thị dưới dạng cửa sổ độc lập
        }

        private void báoCáoDoanhThuToolStripMenuItem_Click(object sender, EventArgs e)
        {
            BaoCaoDoanhThu formPhieuNhap = new BaoCaoDoanhThu();
            formPhieuNhap.ShowDialog(); // Hiển thị dưới dạng cửa sổ độc lập
        }
    }
}
