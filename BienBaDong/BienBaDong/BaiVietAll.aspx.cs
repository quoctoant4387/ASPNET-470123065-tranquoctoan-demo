using System;
using System.Data;
using System.Data.SqlClient;

namespace BienBaDong
{
    public partial class BaiVietAll : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadBaiViet();
            }
        }

        void LoadBaiViet()
        {
            string connStr = System.Configuration.ConfigurationManager.ConnectionStrings["ChuoiKetNoi"].ConnectionString;
            using (SqlConnection conn = new SqlConnection(connStr))
            {
                conn.Open();
                // Thay "BaiViet" bằng tên bảng bạn đang dùng
                string sql = "SELECT MaBaiViet, TenBaiViet, An, NgayDang FROM BaiViet ORDER BY NgayDang DESC";
                SqlDataAdapter da = new SqlDataAdapter(sql, conn);
                DataTable dt = new DataTable();
                da.Fill(dt);

                gvBaiViet.DataSource = dt;
                gvBaiViet.DataBind();
            }
        }

        protected void btnThemMoi_Click(object sender, EventArgs e)
        {
            // Chuyển sang trang thêm bài viết mới (tùy bạn đặt tên trang)
            Response.Redirect("ThemBaiViet.aspx");
        }

        protected void gvBaiViet_RowCommand(object sender, System.Web.UI.WebControls.GridViewCommandEventArgs e)
        {
            string maBaiViet = e.CommandArgument.ToString();

            // Đổi trạng thái Ẩn/Hiển thị
            if (e.CommandName == "DoiTrangThai")
            {
                string connStr = System.Configuration.ConfigurationManager.ConnectionStrings["ChuoiKetNoi"].ConnectionString;
                using (SqlConnection conn = new SqlConnection(connStr))
                {
                    conn.Open();
                    // Lấy trạng thái hiện tại
                    string sqlGet = "SELECT An FROM BaiViet WHERE MaBaiViet=@id";
                    SqlCommand cmdGet = new SqlCommand(sqlGet, conn);
                    cmdGet.Parameters.AddWithValue("@id", maBaiViet);
                    object an = cmdGet.ExecuteScalar();
                    int trangThaiMoi = (an != null && an.ToString() == "0") ? 1 : 0;

                    // Đổi trạng thái
                    string sqlUpdate = "UPDATE BaiViet SET An=@an WHERE MaBaiViet=@id";
                    SqlCommand cmdUpdate = new SqlCommand(sqlUpdate, conn);
                    cmdUpdate.Parameters.AddWithValue("@an", trangThaiMoi);
                    cmdUpdate.Parameters.AddWithValue("@id", maBaiViet);
                    cmdUpdate.ExecuteNonQuery();
                }
                LoadBaiViet();
            }

            // Sửa bài viết
            if (e.CommandName == "Sua")
            {
                Response.Redirect("SuaBaiViet.aspx?iMaBaiViet=" + maBaiViet);
            }

            // Xóa bài viết
            if (e.CommandName == "Xoa")
            {
                string connStr = System.Configuration.ConfigurationManager.ConnectionStrings["ChuoiKetNoi"].ConnectionString;
                using (SqlConnection conn = new SqlConnection(connStr))
                {
                    conn.Open();
                    string sql = "DELETE FROM BaiViet WHERE MaBaiViet=@id";
                    SqlCommand cmd = new SqlCommand(sql, conn);
                    cmd.Parameters.AddWithValue("@id", maBaiViet);
                    cmd.ExecuteNonQuery();
                }
                LoadBaiViet();
            }
        }
    }
}
