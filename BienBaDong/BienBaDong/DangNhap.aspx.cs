using System;
using System.Data.SqlClient;
using System.Web.UI;
using System.Configuration;

namespace BienBaDong
{
    public partial class DangNhap : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text.Trim();
            string password = txtPassword.Text.Trim();

            string connStr = ConfigurationManager
                .ConnectionStrings["ChuoiKetNoi"]
                .ConnectionString;

            using (SqlConnection conn = new SqlConnection(connStr))
            {
                // Lấy cả MaNguoiDung và Quyen
                string sql = @"
                    SELECT MaNguoiDung, Quyen
                    FROM NguoiDung
                    WHERE TenDangNhap = @Ten
                      AND MatKhau     = @MatKhau";

                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@Ten", username);
                    cmd.Parameters.AddWithValue("@MatKhau", password);

                    conn.Open();
                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        if (dr.Read())
                        {
                            // Gán đầy đủ vào Session
                            Session["MaNguoiDung"] = dr["MaNguoiDung"].ToString();
                            Session["TenDangNhap"] = username;
                            Session["Quyen"] = dr["Quyen"].ToString();

                            // Redirect tuỳ quyền
                            if (string.Equals(dr["Quyen"].ToString(),
                                              "Admin",
                                              StringComparison.OrdinalIgnoreCase))
                            {
                                Response.Redirect("AdminPage.aspx");
                            }
                            else
                            {
                                Response.Redirect("TrangChu.aspx");
                            }
                            return;
                        }
                    }
                }

                // Nếu không có kết quả
                lblThongBao.Text = "Tên đăng nhập hoặc mật khẩu không đúng.";
            }
        }
    }
}
