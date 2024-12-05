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
    public partial class NhapNXB : Form
    {
        static private string sqlstring = "Data Source=DESKTOP-01AQ8BK\\CLONEK;Initial Catalog=Sach;Integrated Security=True";
        SqlConnection conn = new SqlConnection(sqlstring);
        SqlCommand sqlcmd;
        public NhapNXB()
        {
            InitializeComponent();
        }

        private void NhapNXB_Load(object sender, EventArgs e)
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
            string query = "select * from NXB ";
            DataTable dataTable = new DataTable();
            SqlDataAdapter adapter = new SqlDataAdapter(query, conn);
            adapter.Fill(dataTable);
            dataGridView1.DataSource = dataTable;
            conn.Close();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            conn.Open();
            string query = "insert into NXB values(@TenNXB,@DiaChi,@SDT)";
            sqlcmd = new SqlCommand(query, conn);
            sqlcmd.Parameters.AddWithValue("@TenNXB", txtTenNXB.Text);
            sqlcmd.Parameters.AddWithValue("@DiaChi", txtDiaChi.Text);
            sqlcmd.Parameters.AddWithValue("@SDT", txtSDT.Text);

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

        private void btnSua_Click(object sender, EventArgs e)
        {
            conn.Open();
            string query = "UPDATE NXB SET TenNXB=@TenNXB, DiaChi=@DiaChi, SDT=@SDT WHERE MaNXB=@MaNXB";
            sqlcmd = new SqlCommand(query, conn);
            sqlcmd.Parameters.AddWithValue("@MaNXB", txtMaNXB.Text); // Sử dụng giá trị này trong WHERE
            sqlcmd.Parameters.AddWithValue("@TenNXB", txtTenNXB.Text);
            sqlcmd.Parameters.AddWithValue("@DiaChi", txtDiaChi.Text);
            sqlcmd.Parameters.AddWithValue("@SDT", txtSDT.Text);

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

        private void btnXoa_Click(object sender, EventArgs e)
        {
            conn.Open();
            string query = "delete NXB where MaNXB='" + txtMaNXB.Text + "'";
            sqlcmd = new SqlCommand(query, conn);
            sqlcmd.ExecuteNonQuery();
            ketnoi();
            conn.Close();
        }

        private void dataGridView1_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            int i;
            i = dataGridView1.CurrentRow.Index;

            txtMaNXB.Text = dataGridView1.Rows[i].Cells[0].Value.ToString();
            txtTenNXB.Text = dataGridView1.Rows[i].Cells[1].Value.ToString();
            txtDiaChi.Text = dataGridView1.Rows[i].Cells[2].Value.ToString();
            txtSDT.Text = dataGridView1.Rows[i].Cells[3].Value.ToString();
        }
    }
}
