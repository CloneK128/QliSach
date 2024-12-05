using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Data.SqlTypes;

namespace QLSach
{
    public partial class NhapTheLoai : Form
    {
        static private string sqlstring = "Data Source=DESKTOP-01AQ8BK\\CLONEK;Initial Catalog=Sach;Integrated Security=True";
        SqlConnection conn = new SqlConnection(sqlstring);
        SqlCommand sqlcmd;
        public NhapTheLoai()
        {
            InitializeComponent();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            conn.Open();
            string query = "delete TheLoai where MaTL='" + txtMaTL.Text + "'";
            sqlcmd = new SqlCommand(query, conn);
            sqlcmd.ExecuteNonQuery();
            ketnoi();
            conn.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {

            conn.Open();
            string query = "UPDATE TheLoai SET TenTL=@TenTL WHERE MaTL=@MaTL";
            sqlcmd = new SqlCommand(query, conn);
            sqlcmd.Parameters.AddWithValue("@MaTL", txtMaTL.Text); // Sử dụng giá trị này trong WHERE
            sqlcmd.Parameters.AddWithValue("@TenTL", txtTenTL.Text);

            try
            {
                sqlcmd.ExecuteNonQuery();
                ketnoi(); // Cập nhật lại dữ liệu nếu cần
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi rồi: " + ex.Message);
            }
            finally
            {
                conn.Close(); // Đảm bảo đóng kết nối trong mọi trường hợp
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            conn.Open();
            string query = "insert into TheLoai values(@TenTL)";
            sqlcmd = new SqlCommand(query, conn);
            sqlcmd.Parameters.AddWithValue("@TenTL", txtTenTL.Text);




            try
            {
                sqlcmd.ExecuteNonQuery();

                ketnoi();
            }
            catch (Exception ex)
            {
                MessageBox.Show("loi roi " + ex.Message);
            };

            conn.Close();
        }

        private void NhapTheLoai_Load(object sender, EventArgs e)
        {
            conn.Open();
            try
            {
                ketnoi();
            }
            catch (Exception ex)
            {
                MessageBox.Show("loi roi " + ex.Message);
            }
            finally
            {
                conn.Close();

            }
        }
        public void ketnoi()
        {

            //conn.Open();
            string query = "select * from TheLoai ";
            DataTable dataTable = new DataTable();
            SqlDataAdapter adapter = new SqlDataAdapter(query, conn);
            adapter.Fill(dataTable);
            dataGridView1.DataSource = dataTable;
            conn.Close();
        }

        private void dataGridView1_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            int i;
            i = dataGridView1.CurrentRow.Index;

            txtMaTL.Text = dataGridView1.Rows[i].Cells[0].Value.ToString();
            txtTenTL.Text = dataGridView1.Rows[i].Cells[1].Value.ToString();
        }
    }
}
