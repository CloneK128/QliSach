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
    public partial class PN : Form
    {
        static private string sqlstring = "Data Source=DESKTOP-01AQ8BK\\CLONEK;Initial Catalog=Sach;Integrated Security=True";
        SqlConnection conn = new SqlConnection(sqlstring);
        SqlCommand sqlcmd;
        public PN()
        {
            InitializeComponent();
        }

        private void txtGiaNhap_TextChanged(object sender, EventArgs e)
        {

        }

        private void PN_Load(object sender, EventArgs e)
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
            string query = "select * from PhieuNhap ";
            DataTable dataTable = new DataTable();
            SqlDataAdapter adapter = new SqlDataAdapter(query, conn);
            adapter.Fill(dataTable);
            dataGridView1.DataSource = dataTable;
            conn.Close();
        }
        public void cbb()
        {
            DataTable dataTableMaTG = new DataTable();
            SqlDataAdapter adapterMaHD = new SqlDataAdapter("select * from Sach", conn);
            adapterMaHD.Fill(dataTableMaTG);

            for (int i = 0; i < dataTableMaTG.Rows.Count; i++)
            {
                cbbMaSach.Items.Add(dataTableMaTG.Rows[i][0].ToString());
            }
            
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            conn.Open();

            // Lấy SoLuongTon hiện tại từ cơ sở dữ liệu
            string querySoLuongTon = "SELECT SoLuongTon FROM Sach WHERE MaSach = @MaSach";
            sqlcmd = new SqlCommand(querySoLuongTon, conn);
            sqlcmd.Parameters.AddWithValue("@MaSach", cbbMaSach.Text);

            int soLuongTonHienTai = 0;
            SqlDataReader reader = sqlcmd.ExecuteReader();
            if (reader.Read()) // Kiểm tra nếu có dữ liệu trả về
            {
                soLuongTonHienTai = Convert.ToInt32(reader["SoLuongTon"]);
            }
            reader.Close(); // Đóng reader sau khi lấy dữ liệu

            // Cập nhật SoLuongTon mới = SoLuongTon hiện tại + SoLuongNhap
            int soLuongNhap = Convert.ToInt32(txtSoLuongNhap.Text);
            int soLuongTonMoi = soLuongTonHienTai + soLuongNhap;

            // Cập nhật lại SoLuongTon trong bảng Sach
            string queryCapNhatSoLuongTon = "UPDATE Sach SET SoLuongTon = @SoLuongTon WHERE MaSach = @MaSach";
            sqlcmd = new SqlCommand(queryCapNhatSoLuongTon, conn);
            sqlcmd.Parameters.AddWithValue("@SoLuongTon", soLuongTonMoi);
            sqlcmd.Parameters.AddWithValue("@MaSach", cbbMaSach.Text);
            sqlcmd.ExecuteNonQuery();

            // Tiến hành thêm phiếu nhập vào bảng PhieuNhap
            string queryInsertPhieuNhap = "INSERT INTO PhieuNhap ( SoLuongNhap, GiaNhap, NgayNhap, MaSach) " +
                                          "VALUES ( @SoLuongNhap, @GiaNhap, @NgayNhap, @MaSach)";
            sqlcmd = new SqlCommand(queryInsertPhieuNhap, conn);
            sqlcmd.Parameters.AddWithValue("@SoLuongNhap", txtSoLuongNhap.Text);
            sqlcmd.Parameters.AddWithValue("@GiaNhap", txtGiaNhap.Text);
            sqlcmd.Parameters.AddWithValue("@NgayNhap", dtNgayNhap.Value);
            sqlcmd.Parameters.AddWithValue("@MaSach", cbbMaSach.Text);

            try
            {
                sqlcmd.ExecuteNonQuery();
                MessageBox.Show("Thêm phiếu nhập thành công!");
                ketnoi(); // Cập nhật lại DataGridView
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
            }

            conn.Close();
        }

        private void btbnSua_Click(object sender, EventArgs e)
        {
            conn.Open();
            string query = "UPDATE PhieuNhap SET SoLuongNhap=@SoLuongNhap, GiaNhap=@GiaNhap, NgayNhap=@NgayNhap, MaSach=@MaSach WHERE MaPN=@MaPN";
            sqlcmd = new SqlCommand(query, conn);
            sqlcmd.Parameters.AddWithValue("@MaPN", txtMaPN.Text);
            sqlcmd.Parameters.AddWithValue("@SoLuongNhap", txtSoLuongNhap.Text);
            sqlcmd.Parameters.AddWithValue("@GiaNhap", txtGiaNhap.Text);
            sqlcmd.Parameters.AddWithValue("@NgayNhap", dtNgayNhap.Value);
            sqlcmd.Parameters.AddWithValue("@MaSach", cbbMaSach.Text);

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

        private void btnXoa_Click(object sender, EventArgs e)
        {
            conn.Open();
            string query = "delete PhieuNhap where MaPN='" + txtMaPN.Text + "'";
            sqlcmd = new SqlCommand(query, conn);
            sqlcmd.ExecuteNonQuery();
            ketnoi();
            conn.Close();
        }

        private void dataGridView1_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            int i;
            i = dataGridView1.CurrentRow.Index;

            txtMaPN.Text = dataGridView1.Rows[i].Cells[0].Value.ToString();
            txtSoLuongNhap.Text = dataGridView1.Rows[i].Cells[1].Value.ToString();
            txtGiaNhap.Text = dataGridView1.Rows[i].Cells[2].Value.ToString();
            dtNgayNhap.Text = dataGridView1.Rows[i].Cells[3].Value.ToString();
            cbbMaSach.Text = dataGridView1.Rows[i].Cells[4].Value.ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DataTable dataTablema = new DataTable();
            SqlDataAdapter adapterma = new SqlDataAdapter("select * from PhieuNhap where MaPN='" + txtMaPN.Text + "'", conn);
            adapterma.Fill(dataTablema);
            dataGridView1.DataSource = dataTablema;
        }
    }
}
