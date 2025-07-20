using System;
using System.Configuration;
using System.Data.SqlClient;

namespace BienBaDong
{
    public partial class ThongTinTaiKhoan : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["TenDangNhap"] == null)
                Response.Redirect("DangNhap.aspx");

            if (!IsPostBack)
                LoadThongTin();
        }

        void LoadThongTin()
        {
            string username = Session["TenDangNhap"].ToString();
            string connStr = ConfigurationManager.ConnectionStrings["ChuoiKetNoi"].ConnectionString;

            using (SqlConnection conn = new SqlConnection(connStr))
            {
                string sql = "SELECT * FROM NguoiDung WHERE TenDangNhap = @Ten";
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@Ten", username);

                conn.Open();
                SqlDataReader rd = cmd.ExecuteReader();
                if (rd.Read())
                {
                    txtTenDangNhap.Text = rd["TenDangNhap"].ToString();
                    // **Dòng bổ sung để hiện mật khẩu**
                    if (rd["MatKhau"] != DBNull.Value)
                        txtMatKhau.Text = rd["MatKhau"].ToString();

                    txtHoTen.Text = rd["HoTen"].ToString();
                    ddlGioiTinh.SelectedValue = rd["GioiTinh"].ToString();
                    txtEmail.Text = rd["Email"].ToString();

                    if (rd["NgaySinh"] != DBNull.Value)
                    {
                        DateTime ngaySinh = Convert.ToDateTime(rd["NgaySinh"]);
                        txtNgaySinh.Text = ngaySinh.ToString("yyyy-MM-dd");
                    }
                }
            }
        }

        protected void btnCapNhat_Click(object sender, EventArgs e)
        {
            string username = Session["TenDangNhap"].ToString();
            string connStr = ConfigurationManager.ConnectionStrings["ChuoiKetNoi"].ConnectionString;

            using (SqlConnection conn = new SqlConnection(connStr))
            {
                string sql = @"UPDATE NguoiDung 
                               SET HoTen = @HoTen, GioiTinh = @GioiTinh, Email = @Email, NgaySinh = @NgaySinh 
                               WHERE TenDangNhap = @Ten";

                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@HoTen", txtHoTen.Text.Trim());
                cmd.Parameters.AddWithValue("@GioiTinh", ddlGioiTinh.SelectedValue);
                cmd.Parameters.AddWithValue("@Email", txtEmail.Text.Trim());

                DateTime ngaySinh;
                if (DateTime.TryParse(txtNgaySinh.Text, out ngaySinh))
                    cmd.Parameters.AddWithValue("@NgaySinh", ngaySinh);
                else
                    cmd.Parameters.AddWithValue("@NgaySinh", DBNull.Value);

                cmd.Parameters.AddWithValue("@Ten", username);

                conn.Open();
                int kq = cmd.ExecuteNonQuery();
                if (kq > 0)
                    lblThongBao.Text = "Cập nhật thông tin thành công.";
                else
                    lblThongBao.Text = "Cập nhật thất bại.";
            }
        }
    }
}
