using System;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace BienBaDong
{
    public partial class BaiViet : System.Web.UI.Page
    {
        protected string MaBaiViet;
        protected string MaNguoiDungBaiViet = "";

        protected void Page_Load(object sender, EventArgs e)
        {
            // Panel thêm bài và bình luận luôn hiển thị đúng trạng thái
            pnlAddPost.Visible = (Session["TenDangNhap"] != null);
            pnlAddComment.Visible = (Session["TenDangNhap"] != null);

            MaBaiViet = Request.QueryString["iMaBaiViet"];
            if (!string.IsNullOrEmpty(MaBaiViet))
            {
                LoadBaiViet(MaBaiViet); // Gán ViewState["MaNguoiDungBaiViet"]
                if (!IsPostBack)
                {
                    LoadComments(MaBaiViet);
                }
            }
            else
            {
                lblTenBaiViet.Text = "Không tìm thấy bài viết!";
                lblNoiDung.Text = "";
            }

            // Phân quyền sửa/xóa: đặt ngoài IsPostBack để mọi lúc đều đúng!
            divAdminTools.Visible = false;
            if (Session["TenDangNhap"] != null)
            {
                string quyen = Session["Quyen"] == null ? "" : Session["Quyen"].ToString().Trim().ToLower();
                string tenDangNhap = Session["TenDangNhap"].ToString().Trim();
                string maNguoiDungBaiViet = ViewState["MaNguoiDungBaiViet"] == null ? "" : ViewState["MaNguoiDungBaiViet"].ToString().Trim();

                // Hiện nút nếu là admin hoặc là chủ bài viết
                if (quyen == "admin" || tenDangNhap.Equals(maNguoiDungBaiViet, StringComparison.OrdinalIgnoreCase))
                    divAdminTools.Visible = true;
            }
        }

        void LoadBaiViet(string id)
        {
            string connStr = ConfigurationManager.ConnectionStrings["ChuoiKetNoi"].ConnectionString;
            using (SqlConnection conn = new SqlConnection(connStr))
            {
                conn.Open();
                string sql = "SELECT TenBaiViet, NoiDung, MaNguoiDung FROM BaiViet WHERE MaBaiViet = @id";
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@id", id);

                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    lblTenBaiViet.Text = reader["TenBaiViet"].ToString();
                    lblNoiDung.Text = reader["NoiDung"].ToString().Replace("\n", "<br/>");
                    MaNguoiDungBaiViet = reader["MaNguoiDung"].ToString();
                    ViewState["MaNguoiDungBaiViet"] = MaNguoiDungBaiViet;
                }
                else
                {
                    lblTenBaiViet.Text = "Không tìm thấy bài viết!";
                    lblNoiDung.Text = "";
                    MaNguoiDungBaiViet = "";
                    ViewState["MaNguoiDungBaiViet"] = null;
                }
                reader.Close();
            }
        }

        void LoadComments(string maBaiViet)
        {
            string connStr = ConfigurationManager.ConnectionStrings["ChuoiKetNoi"].ConnectionString;
            using (SqlConnection conn = new SqlConnection(connStr))
            {
                conn.Open();
                string sql = "SELECT HoTen, NoiDung, NgayTao FROM BinhLuan WHERE MaBaiViet = @MaBaiViet ORDER BY NgayTao DESC";
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@MaBaiViet", maBaiViet);

                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);

                rptComments.DataSource = dt;
                rptComments.DataBind();
            }
        }

        protected void btnAddPost_Click(object sender, EventArgs e)
        {
            Response.Redirect("ThemBaiViet.aspx");
        }

        protected void btnComment_Click(object sender, EventArgs e)
        {
            if (Session["TenDangNhap"] == null)
            {
                lblCommentMsg.Text = "Bạn cần đăng nhập để bình luận!";
                return;
            }

            string noiDung = txtComment.Text.Trim();
            if (string.IsNullOrEmpty(noiDung))
            {
                lblCommentMsg.Text = "Vui lòng nhập nội dung bình luận!";
                return;
            }

            string maBaiViet = Request.QueryString["iMaBaiViet"];
            string hoTen = Session["TenDangNhap"].ToString();

            string connStr = ConfigurationManager.ConnectionStrings["ChuoiKetNoi"].ConnectionString;
            using (SqlConnection conn = new SqlConnection(connStr))
            {
                conn.Open();
                string sql = "INSERT INTO BinhLuan (MaBaiViet, HoTen, NoiDung, NgayTao) VALUES (@MaBaiViet, @HoTen, @NoiDung, GETDATE())";
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@MaBaiViet", maBaiViet);
                cmd.Parameters.AddWithValue("@HoTen", hoTen);
                cmd.Parameters.AddWithValue("@NoiDung", noiDung);
                cmd.ExecuteNonQuery();
            }

            txtComment.Text = "";
            lblCommentMsg.Text = "Bình luận đã gửi!";
            LoadComments(maBaiViet);
        }

        protected void btnSua_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(Request.QueryString["iMaBaiViet"]))
            {
                Response.Redirect("SuaBai.aspx?iMaBaiViet=" + Request.QueryString["iMaBaiViet"]);
            }
        }

        protected void btnXoa_Click(object sender, EventArgs e)
        {
            string id = Request.QueryString["iMaBaiViet"];
            if (!string.IsNullOrEmpty(id))
            {
                string connStr = ConfigurationManager.ConnectionStrings["ChuoiKetNoi"].ConnectionString;
                using (SqlConnection conn = new SqlConnection(connStr))
                {
                    conn.Open();
                    // Kiểm tra quyền lần cuối
                    string sqlCheck = "SELECT MaNguoiDung FROM BaiViet WHERE MaBaiViet = @id";
                    SqlCommand cmdCheck = new SqlCommand(sqlCheck, conn);
                    cmdCheck.Parameters.AddWithValue("@id", id);
                    string maNguoiDung = Convert.ToString(cmdCheck.ExecuteScalar());

                    bool isAdmin = Session["Quyen"] != null && Session["Quyen"].ToString().Trim().ToLower() == "admin";
                    bool isOwner = (Session["TenDangNhap"] != null && Session["TenDangNhap"].ToString().Trim().Equals(maNguoiDung, StringComparison.OrdinalIgnoreCase));

                    if (isAdmin || isOwner)
                    {
                        string sql = "DELETE FROM BaiViet WHERE MaBaiViet = @id";
                        SqlCommand cmd = new SqlCommand(sql, conn);
                        cmd.Parameters.AddWithValue("@id", id);
                        cmd.ExecuteNonQuery();
                        Response.Redirect("QuanLyBaiViet.aspx");
                    }
                    else
                    {
                        lblTenBaiViet.Text = "Bạn không có quyền xóa bài viết này!";
                    }
                }
            }
        }
    }
}
