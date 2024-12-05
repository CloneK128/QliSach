using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QLSach
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }
        private void btnOK_Click(object sender, EventArgs e)
        {
            
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close(); // Thoát ứng dụng
        }

        private void btnOK_Click_1(object sender, EventArgs e)
        {
            // Giả sử tài khoản: admin, mật khẩu: 123
            string username = txtUserName.Text;
            string password = txtPassword.Text;

            if (username == "admin" && password == "123")
            {
                MessageBox.Show("Đăng nhập thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Hide(); // Ẩn form đăng nhập
                // Mở form chính (MainForm)
                QliSach mainForm = new QliSach();
                mainForm.Show();
            }
            else
            {
                MessageBox.Show("Sai tên đăng nhập hoặc mật khẩu!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCancel_Click_1(object sender, EventArgs e)
        {
            this.Close(); // Thoát ứng dụng
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
