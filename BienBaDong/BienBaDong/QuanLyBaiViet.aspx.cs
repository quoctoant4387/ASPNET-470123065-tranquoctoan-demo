using System;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BienBaDong
{
    public partial class QuanLyBaiViet : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // Chỉ cho phép nếu đã đăng nhập
            if (Session["TenDangNhap"] == null)
            {
                Response.Redirect("TrangChu.aspx");
                return;
            }

            if (!IsPostBack)
            {
                LoadDanhSachBaiViet();
            }
        }

        private void LoadDanhSachBaiViet()
        {
            string connStr = ConfigurationManager
                .ConnectionStrings["ChuoiKetNoi"]
                .ConnectionString;

            using (SqlConnection conn = new SqlConnection(connStr))
            {
                conn.Open();

                // Xác định có phải admin hay không
                bool isAdmin = Session["Quyen"] != null
                    && Session["Quyen"].ToString().Trim()
                        .Equals("admin", StringComparison.OrdinalIgnoreCase);

                if (isAdmin)
                {
                    // Admin: lấy toàn bộ bài viết
                    string sql = @"
                        SELECT MaBaiViet, TenBaiViet, NgayDang, NgayCapNhat, MaNguoiDung
                        FROM BaiViet
                        ORDER BY NgayDang DESC";
                    using (SqlDataAdapter da = new SqlDataAdapter(sql, conn))
                    {
                        DataTable dt = new DataTable();
                        da.Fill(dt);
                        gvBaiViet.DataSource = dt;
                        gvBaiViet.DataBind();
                    }
                }
                else
                {
                    // Người dùng thường: chỉ lấy bài của chính họ
                    var userId = Session["MaNguoiDung"];
                    if (userId == null)
                    {
                        // Chưa có ID người dùng thì quay về trang login
                        Response.Redirect("DangNhap.aspx");
                        return;
                    }

                    string sql = @"
                        SELECT MaBaiViet, TenBaiViet, NgayDang, NgayCapNhat, MaNguoiDung
                        FROM BaiViet
                        WHERE MaNguoiDung = @MaNguoiDung
                        ORDER BY NgayDang DESC";
                    using (SqlCommand cmd = new SqlCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("@MaNguoiDung", userId.ToString());
                        using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                        {
                            DataTable dt = new DataTable();
                            da.Fill(dt);
                            gvBaiViet.DataSource = dt;
                            gvBaiViet.DataBind();
                        }
                    }
                }
            }
        }

        protected void btnThemMoi_Click(object sender, EventArgs e)
        {
            Response.Redirect("ThemBai.aspx");
        }

        protected void gvBaiViet_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            string maBaiViet = e.CommandArgument.ToString();

            if (e.CommandName == "EditBaiViet")
            {
                Response.Redirect("SuaBai.aspx?iMaBaiViet=" + maBaiViet);
            }
            else if (e.CommandName == "DeleteBaiViet")
            {
                string connStr = ConfigurationManager
                    .ConnectionStrings["ChuoiKetNoi"]
                    .ConnectionString;
                using (SqlConnection conn = new SqlConnection(connStr))
                {
                    conn.Open();
                    string sql = "DELETE FROM BaiViet WHERE MaBaiViet = @MaBaiViet";
                    using (SqlCommand cmd = new SqlCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("@MaBaiViet", maBaiViet);
                        cmd.ExecuteNonQuery();
                    }
                }
                // Tải lại danh sách sau khi xóa
                LoadDanhSachBaiViet();
            }
        }
    }
}
