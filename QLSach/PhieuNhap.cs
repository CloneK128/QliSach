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
    public partial class PhieuNhap : Form
    {
        static private string sqlstring = "Data Source=DESKTOP-01AQ8BK\\CLONEK;Initial Catalog=Sach;Integrated Security=True";
        SqlConnection conn = new SqlConnection(sqlstring);
        SqlCommand sqlcmd;
        public PhieuNhap()
        {
            InitializeComponent();
        }

        private void PhieuNhap_Load(object sender, EventArgs e)
        {
            cbb();
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
            string query = "select * from Sach ";
            DataTable dataTable = new DataTable();
            SqlDataAdapter adapter = new SqlDataAdapter(query, conn);
            adapter.Fill(dataTable);
            dataGridView1.DataSource = dataTable;
            conn.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            conn.Open();
            string query = "insert into Sach values(@TenSach,@MaTL,@MaTG,@MaNXB,@SoLuongTon)";
            sqlcmd = new SqlCommand(query, conn);
            sqlcmd.Parameters.AddWithValue("@TenSach", txtTenSach.Text);
            sqlcmd.Parameters.AddWithValue("@MaTL", cbbMaTL.Text);
            sqlcmd.Parameters.AddWithValue("@MaTG", cbbMaTG.Text);
            sqlcmd.Parameters.AddWithValue("@MaNXB", cbbMaNXB.Text);
            sqlcmd.Parameters.AddWithValue("@SoLuongTon", txtSoLuongNhap.Text);



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

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void txtGiaNhap_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            conn.Open();
            string query = "UPDATE Sach SET TenSach=@TenSach, MaTL=@MaTL, MaTG=@MaTG, MaNXB=@MaNXB, SoLuongTon=@SoLuongTon WHERE MaSach=@MaSach";
            sqlcmd = new SqlCommand(query, conn);
            sqlcmd.Parameters.AddWithValue("@MaSach", txtMaSach.Text); 
            sqlcmd.Parameters.AddWithValue("@TenSach", txtTenSach.Text);
            sqlcmd.Parameters.AddWithValue("@MaTL", cbbMaTL.Text);
            sqlcmd.Parameters.AddWithValue("@MaTG", cbbMaTG.Text);
            sqlcmd.Parameters.AddWithValue("@MaNXB", cbbMaNXB.Text);
            sqlcmd.Parameters.AddWithValue("@SoLuongTon", txtSoLuongNhap.Text);

            try
            {
                sqlcmd.ExecuteNonQuery();
                ketnoi();
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

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void dataGridView1_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void dataGridView1_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            int i;
            i = dataGridView1.CurrentRow.Index;

            txtMaSach.Text = dataGridView1.Rows[i].Cells[0].Value.ToString();
            txtTenSach.Text = dataGridView1.Rows[i].Cells[1].Value.ToString();
            cbbMaTL.Text = dataGridView1.Rows[i].Cells[2].Value.ToString();
            cbbMaTG.Text = dataGridView1.Rows[i].Cells[3].Value.ToString();
            cbbMaNXB.Text = dataGridView1.Rows[i].Cells[4].Value.ToString();
            txtSoLuongNhap.Text = dataGridView1.Rows[i].Cells[5].Value.ToString();
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            conn.Open();
            string query = "delete Sach where MaSach='" + txtMaSach.Text + "'";
            sqlcmd = new SqlCommand(query, conn);
            sqlcmd.ExecuteNonQuery();
            ketnoi();
            conn.Close();
        }
        public void cbb()
        {
            DataTable dataTableMaTG = new DataTable();
            SqlDataAdapter adapterMaHD = new SqlDataAdapter("select * from Sach", conn);
            adapterMaHD.Fill(dataTableMaTG);

            for (int i = 0; i < dataTableMaTG.Rows.Count; i++)
            {
                cbbMaTG.Items.Add(dataTableMaTG.Rows[i][3].ToString());
            }
            DataTable dataTableMaTL = new DataTable();
            SqlDataAdapter adapterMaTL = new SqlDataAdapter("select * from Sach", conn);
            adapterMaTL.Fill(dataTableMaTL);

            for (int i = 0; i < dataTableMaTL.Rows.Count; i++)
            {
                cbbMaTL.Items.Add(dataTableMaTL.Rows[i][2].ToString());
            }
            DataTable dataTableMaNXB = new DataTable();
            SqlDataAdapter adapterMaNXB = new SqlDataAdapter("select * from Sach", conn);
            adapterMaNXB.Fill(dataTableMaNXB);

            for (int i = 0; i < dataTableMaNXB.Rows.Count; i++)
            {
                cbbMaNXB.Items.Add(dataTableMaNXB.Rows[i][4].ToString());
            }
        }

        private void cbbMaTG_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            DataTable dataTablema = new DataTable();
            SqlDataAdapter adapterma = new SqlDataAdapter("select * from Sach where MaSach='" + txtMaSach.Text + "'", conn);
            adapterma.Fill(dataTablema);
            dataGridView1.DataSource = dataTablema;
        }
    }
}
