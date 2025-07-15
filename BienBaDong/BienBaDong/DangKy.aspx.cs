using System;
using System.Data.SqlClient;
using System.Configuration;

namespace BienBaDong
{
    public partial class DangKy : System.Web.UI.Page
    {
        protected void btnDangKy_Click(object sender, EventArgs e)
        {
            string hoTen = txtHoTen.Text.Trim();
            string tenDangNhap = txtTenDangNhap.Text.Trim();
            string matKhau = txtMatKhau.Text.Trim();
            string xacNhan = txtXacNhan.Text.Trim();
            string email = txtEmail.Text.Trim();
            string gioiTinh = rblGioiTinh.SelectedValue;
            string ngaySinh = txtNgaySinh.Text;

            if (matKhau != xacNhan)
            {
                ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('Mật khẩu xác nhận không khớp!');", true);
                return;
            }

            string connectionString = ConfigurationManager.ConnectionStrings["ChuoiKetNoi"].ConnectionString;

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();

                SqlCommand checkUser = new SqlCommand("SELECT COUNT(*) FROM NguoiDung WHERE TenDangNhap = @TenDN", conn);
                checkUser.Parameters.AddWithValue("@TenDN", tenDangNhap);
                int count = (int)checkUser.ExecuteScalar();

                if (count > 0)
                {
                    ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('Tên đăng nhập đã tồn tại.');", true);
                    return;
                }

                SqlCommand cmd = new SqlCommand(@"INSERT INTO NguoiDung (HoTen, TenDangNhap, MatKhau, Email, GioiTinh, NgaySinh, Quyen)
                    VALUES (@HoTen, @TenDN, @MatKhau, @Email, @GioiTinh, @NgaySinh, 'User')", conn);

                cmd.Parameters.AddWithValue("@HoTen", hoTen);
                cmd.Parameters.AddWithValue("@TenDN", tenDangNhap);
                cmd.Parameters.AddWithValue("@MatKhau", matKhau);
                cmd.Parameters.AddWithValue("@Email", email);
                cmd.Parameters.AddWithValue("@GioiTinh", gioiTinh);
                cmd.Parameters.AddWithValue("@NgaySinh", Convert.ToDateTime(ngaySinh));

                int result = cmd.ExecuteNonQuery();

                if (result > 0)
                {
                    ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('Đăng ký thành công!');", true);
                }
                else
                {
                    ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('Đăng ký thất bại.');", true);
                }
            }
        }
    }
}
