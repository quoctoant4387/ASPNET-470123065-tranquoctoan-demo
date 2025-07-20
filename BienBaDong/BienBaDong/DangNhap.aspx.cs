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

            string connStr = ConfigurationManager.ConnectionStrings["ChuoiKetNoi"].ConnectionString;

            using (SqlConnection conn = new SqlConnection(connStr))
            {
                string sql = "SELECT Quyen FROM NguoiDung WHERE TenDangNhap = @Ten AND MatKhau = @MatKhau";
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@Ten", username);
                cmd.Parameters.AddWithValue("@MatKhau", password);

                conn.Open();
                object quyen = cmd.ExecuteScalar();

                if (quyen != null && quyen != DBNull.Value)
                {
                    Session["TenDangNhap"] = username;
                    Session["Quyen"] = quyen.ToString();

                    if (string.Equals(quyen.ToString(), "Admin", StringComparison.OrdinalIgnoreCase))
                        Response.Redirect("AdminPage.aspx");
                    else
                        Response.Redirect("TrangChu.aspx");
                }
                else
                {
                    lblThongBao.Text = "Tên đăng nhập hoặc mật khẩu không đúng.";
                }
            }
        }
    }
}
