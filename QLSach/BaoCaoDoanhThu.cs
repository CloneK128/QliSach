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
    public partial class BaoCaoDoanhThu : Form
    {
        static private string sqlstring = "Data Source=DESKTOP-01AQ8BK\\CLONEK;Initial Catalog=Sach;Integrated Security=True";
        SqlConnection conn = new SqlConnection(sqlstring);
        SqlCommand sqlcmd;
        public BaoCaoDoanhThu()
        {
            InitializeComponent();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void BaoCaoDoanhThu_Load(object sender, EventArgs e)
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
            string query = "select * from HoaDon ";
            DataTable dataTable = new DataTable();
            SqlDataAdapter adapter = new SqlDataAdapter(query, conn);
            adapter.Fill(dataTable);
            dataGridView1.DataSource = dataTable;
            conn.Close();
        }

        private void btnKiemTra_Click(object sender, EventArgs e)
        {
            try
            {
                conn.Open(); // Mở kết nối SQL

                // Tạo truy vấn SQL với tham số hóa
                string query = "SELECT * FROM HoaDon WHERE CAST(NgayBan AS DATE) = @NgayBan";

                // Sử dụng SqlDataAdapter để lấy dữ liệu
                SqlDataAdapter adapter = new SqlDataAdapter(query, conn);

                // Thêm tham số @NgayBan
                adapter.SelectCommand.Parameters.AddWithValue("@NgayBan", dtBaoCao.Value.Date);

                // Tạo DataTable để chứa dữ liệu
                DataTable dataTable = new DataTable();
                adapter.Fill(dataTable);

                // Gán dữ liệu cho DataGridView
                dataGridView1.DataSource = dataTable;

                // Tính tổng tiền từ DataTable
                decimal totalRevenue = 0;
                foreach (DataRow row in dataTable.Rows)
                {
                    if (row["TongTien"] != DBNull.Value) // Kiểm tra giá trị null
                    {
                        totalRevenue += Convert.ToDecimal(row["TongTien"]);
                    }
                }

                // Hiển thị tổng doanh thu vào txtDoanhThu
                txtDoanhThu.Text = totalRevenue.ToString("N0"); // Định dạng số (ví dụ: 1,000,000)
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
            }
            finally
            {
                conn.Close(); // Đảm bảo đóng kết nối SQL
            }
        }
    }
}
