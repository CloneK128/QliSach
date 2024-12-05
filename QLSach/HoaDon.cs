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
    public partial class HoaDon : Form
    {
        static private string sqlstring = "Data Source=DESKTOP-01AQ8BK\\CLONEK;Initial Catalog=Sach;Integrated Security=True";
        SqlConnection conn = new SqlConnection(sqlstring);
        SqlCommand sqlcmd;
        public HoaDon()
        {
            InitializeComponent();
        }

        private void HoaDon_Load(object sender, EventArgs e)
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
            string query = "select * from HoaDon ";
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

        private void btnThem_Click(object sender, EventArgs e)
        {
            conn.Open();

            try
            {
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

                // Cập nhật SoLuongTon mới = SoLuongTon hiện tại - SoLuongBan
                int soLuongBan = Convert.ToInt32(txtSoLuongBan.Text);
                if (soLuongBan > soLuongTonHienTai)
                {
                    MessageBox.Show("Số lượng bán vượt quá số lượng tồn!");
                    conn.Close();
                    return;
                }
                int soLuongTonMoi = soLuongTonHienTai - soLuongBan;

                // Cập nhật lại SoLuongTon trong bảng Sach
                string queryCapNhatSoLuongTon = "UPDATE Sach SET SoLuongTon = @SoLuongTon WHERE MaSach = @MaSach";
                sqlcmd = new SqlCommand(queryCapNhatSoLuongTon, conn);
                sqlcmd.Parameters.AddWithValue("@SoLuongTon", soLuongTonMoi);
                sqlcmd.Parameters.AddWithValue("@MaSach", cbbMaSach.Text);
                sqlcmd.ExecuteNonQuery();

                // Tính Tổng Tiền = Số Lượng Bán * Giá Bán
                int giaBan = Convert.ToInt32(txtGiaBan.Text);
                int tongTien = soLuongBan * giaBan;

                // Tiến hành thêm hóa đơn vào bảng HoaDon
                string queryInsertHoaDon = "INSERT INTO HoaDon (SoLuongBan, GiaBan, NgayBan, MaSach, TongTien) " +
                                            "VALUES (@SoLuongBan, @GiaBan, @NgayBan, @MaSach, @TongTien)";
                sqlcmd = new SqlCommand(queryInsertHoaDon, conn);
                sqlcmd.Parameters.AddWithValue("@SoLuongBan", soLuongBan);
                sqlcmd.Parameters.AddWithValue("@GiaBan", giaBan);
                sqlcmd.Parameters.AddWithValue("@NgayBan", dtNgayBan.Value);
                sqlcmd.Parameters.AddWithValue("@MaSach", cbbMaSach.Text);
                sqlcmd.Parameters.AddWithValue("@TongTien", tongTien);

                sqlcmd.ExecuteNonQuery();
                MessageBox.Show("Thêm hóa đơn thành công!");
                ketnoi(); // Cập nhật lại DataGridView
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
            }
            finally
            {
                conn.Close(); // Đảm bảo đóng kết nối
            }
        }

        private void btbnSua_Click(object sender, EventArgs e)
        {
            conn.Open();

            try
            {
                // Tính lại Tổng Tiền = Số Lượng Bán * Giá Bán
                int soLuongBan = Convert.ToInt32(txtSoLuongBan.Text);
                int giaBan = Convert.ToInt32(txtGiaBan.Text);
                int tongTien = soLuongBan * giaBan;

                // Cập nhật thông tin trong bảng HoaDon
                string query = "UPDATE HoaDon " +
                               "SET SoLuongBan = @SoLuongBan, GiaBan = @GiaBan, NgayBan = @NgayBan, MaSach = @MaSach, TongTien = @TongTien " +
                               "WHERE MaHD = @MaHD";
                sqlcmd = new SqlCommand(query, conn);
                sqlcmd.Parameters.AddWithValue("@MaHD", txtMaHD.Text);
                sqlcmd.Parameters.AddWithValue("@SoLuongBan", soLuongBan);
                sqlcmd.Parameters.AddWithValue("@GiaBan", giaBan);
                sqlcmd.Parameters.AddWithValue("@NgayBan", dtNgayBan.Value);
                sqlcmd.Parameters.AddWithValue("@MaSach", cbbMaSach.Text);
                sqlcmd.Parameters.AddWithValue("@TongTien", tongTien);

                sqlcmd.ExecuteNonQuery();
                MessageBox.Show("Cập nhật hóa đơn thành công!");
                ketnoi(); // Cập nhật lại DataGridView
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
            }
            finally
            {
                conn.Close(); // Đảm bảo đóng kết nối trong mọi trường hợp
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            conn.Open();
            string query = "delete HoaDon where MaHD='" + txtMaHD.Text + "'";
            sqlcmd = new SqlCommand(query, conn);
            sqlcmd.ExecuteNonQuery();
            ketnoi();
            conn.Close();
        }

        private void dataGridView1_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            int i;
            i = dataGridView1.CurrentRow.Index;

            txtMaHD.Text = dataGridView1.Rows[i].Cells[0].Value.ToString();
            txtSoLuongBan.Text = dataGridView1.Rows[i].Cells[1].Value.ToString();
            txtGiaBan.Text = dataGridView1.Rows[i].Cells[2].Value.ToString();
            dtNgayBan.Text = dataGridView1.Rows[i].Cells[3].Value.ToString();
            cbbMaSach.Text = dataGridView1.Rows[i].Cells[4].Value.ToString();
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            DataTable dataTablema = new DataTable();
            SqlDataAdapter adapterma = new SqlDataAdapter("select * from HoaDon where MaHD='" + txtMaHD.Text + "'", conn);
            adapterma.Fill(dataTablema);
            dataGridView1.DataSource = dataTablema;
        }
    }
}
