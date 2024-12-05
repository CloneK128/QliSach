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
    public partial class NhapTacGia : Form
    {
        static private string sqlstring = "Data Source=DESKTOP-01AQ8BK\\CLONEK;Initial Catalog=Sach;Integrated Security=True";
        SqlConnection conn = new SqlConnection(sqlstring);
        SqlCommand sqlcmd;
        public NhapTacGia()
        {
            InitializeComponent();
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void NhapTacGia_Load(object sender, EventArgs e)
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
            string query = "select * from TacGia ";
            DataTable dataTable = new DataTable();
            SqlDataAdapter adapter = new SqlDataAdapter(query, conn);
            adapter.Fill(dataTable);
            dataGridView1.DataSource = dataTable;
            conn.Close();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            conn.Open();
            string query = "insert into TacGia values(@TenTG,@LienLac)";
            sqlcmd = new SqlCommand(query, conn);
            sqlcmd.Parameters.AddWithValue("@TenTG", txtTenTG.Text);
            sqlcmd.Parameters.AddWithValue("@LienLac", txtLienLac.Text);


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
            string query = "UPDATE TacGia SET TenTG=@TenTG, LienLac=@LienLac WHERE MaTG=@MaTG";
            sqlcmd = new SqlCommand(query, conn);
            sqlcmd.Parameters.AddWithValue("@MaTG", txtMaTG.Text);
            sqlcmd.Parameters.AddWithValue("@TenTG", txtTenTG.Text);
            sqlcmd.Parameters.AddWithValue("@LienLac", txtLienLac.Text);

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
            string query = "delete TacGia where MaTG='" + txtMaTG.Text + "'";
            sqlcmd = new SqlCommand(query, conn);
            sqlcmd.ExecuteNonQuery();
            ketnoi();
            conn.Close();
        }

        private void dataGridView1_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            int i;
            i = dataGridView1.CurrentRow.Index;

            txtMaTG.Text = dataGridView1.Rows[i].Cells[0].Value.ToString();
            txtTenTG.Text = dataGridView1.Rows[i].Cells[1].Value.ToString();
            txtLienLac.Text = dataGridView1.Rows[i].Cells[2].Value.ToString();
            
        }
    }
}
