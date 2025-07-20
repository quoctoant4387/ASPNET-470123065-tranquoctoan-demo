using System;
using System.Data;
using System.Data.SqlClient;

namespace BienBaDong
{
    public partial class QuanLyBaiViet : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["TenDangNhap"] == null || Session["Quyen"] == null ||
                !Session["Quyen"].ToString().Trim().Equals("admin", StringComparison.OrdinalIgnoreCase))
            {
                Response.Redirect("TrangChu.aspx");
            }

            if (!IsPostBack)
            {
                LoadDanhSachBaiViet();
            }
        }

        void LoadDanhSachBaiViet()
        {
            string connStr = System.Configuration.ConfigurationManager.ConnectionStrings["ChuoiKetNoi"].ConnectionString;
            using (SqlConnection conn = new SqlConnection(connStr))
            {
                conn.Open();
                // Lấy dữ liệu từ bảng BaiViet, bạn điều chỉnh tên trường theo CSDL thực tế
                string sql = "SELECT MaBaiViet, TenBaiViet, NgayDang, NgayCapNhat, MaNguoiDung FROM BaiViet ORDER BY NgayDang DESC";
                SqlDataAdapter da = new SqlDataAdapter(sql, conn);
                DataTable dt = new DataTable();
                da.Fill(dt);

                gvBaiViet.DataSource = dt;
                gvBaiViet.DataBind();
            }
        }

        protected void btnThemMoi_Click(object sender, EventArgs e)
        {
            Response.Redirect("ThemBai.aspx");
        }

        protected void gvBaiViet_RowCommand(object sender, System.Web.UI.WebControls.GridViewCommandEventArgs e)
        {
            string maBaiViet = e.CommandArgument.ToString();

            // Sửa bài viết
            if (e.CommandName == "EditBaiViet")
            {
                Response.Redirect("SuaBai.aspx?iMaBaiViet=" + maBaiViet);
            }

            // Xóa bài viết
            if (e.CommandName == "DeleteBaiViet")
            {
                string connStr = System.Configuration.ConfigurationManager.ConnectionStrings["ChuoiKetNoi"].ConnectionString;
                using (SqlConnection conn = new SqlConnection(connStr))
                {
                    conn.Open();
                    string sql = "DELETE FROM BaiViet WHERE MaBaiViet=@MaBaiViet";
                    SqlCommand cmd = new SqlCommand(sql, conn);
                    cmd.Parameters.AddWithValue("@MaBaiViet", maBaiViet);
                    cmd.ExecuteNonQuery();
                }
                LoadDanhSachBaiViet();
            }
        }
    }
}
