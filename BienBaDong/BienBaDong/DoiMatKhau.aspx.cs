using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BienBaDong
{
    public partial class DoiMatKhau : System.Web.UI.Page
    {
            protected void Page_Load(object sender, EventArgs e)
            {
                if (Session["TenDangNhap"] == null)
                    Response.Redirect("DangNhap.aspx");
            }

            protected void btnDoiMatKhau_Click(object sender, EventArgs e)
            {
                string tenDangNhap = Session["TenDangNhap"].ToString();
                string matKhauCu = txtMatKhauCu.Text.Trim();
                string matKhauMoi = txtMatKhauMoi.Text.Trim();
                string xacNhan = txtXacNhan.Text.Trim();

                if (matKhauMoi != xacNhan)
                {
                    lblThongBao.Text = "Xác nhận mật khẩu không khớp.";
                    return;
                }

                string connStr = ConfigurationManager.ConnectionStrings["ChuoiKetNoi"].ConnectionString;
                using (SqlConnection conn = new SqlConnection(connStr))
                {
                    conn.Open();

                    // Kiểm tra mật khẩu cũ có đúng không
                    string sqlCheck = "SELECT COUNT(*) FROM NguoiDung WHERE TenDangNhap = @Ten AND MatKhau = @MKCu";
                    SqlCommand cmdCheck = new SqlCommand(sqlCheck, conn);
                    cmdCheck.Parameters.AddWithValue("@Ten", tenDangNhap);
                    cmdCheck.Parameters.AddWithValue("@MKCu", matKhauCu);

                    int count = (int)cmdCheck.ExecuteScalar();
                    if (count == 0)
                    {
                        lblThongBao.Text = "Mật khẩu cũ không đúng.";
                        return;
                    }

                    // Cập nhật mật khẩu mới
                    string sqlUpdate = "UPDATE NguoiDung SET MatKhau = @MKMoi WHERE TenDangNhap = @Ten";
                    SqlCommand cmdUpdate = new SqlCommand(sqlUpdate, conn);
                    cmdUpdate.Parameters.AddWithValue("@MKMoi", matKhauMoi);
                    cmdUpdate.Parameters.AddWithValue("@Ten", tenDangNhap);

                    int result = cmdUpdate.ExecuteNonQuery();

                    if (result > 0)
                    {
                        lblThongBao.ForeColor = System.Drawing.Color.Green;
                        lblThongBao.Text = "Đổi mật khẩu thành công.";
                    }
                    else
                    {
                        lblThongBao.Text = "Đổi mật khẩu thất bại.";
                    }
                }
            }
        }
    }
