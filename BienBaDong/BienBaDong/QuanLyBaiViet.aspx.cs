using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Web.UI.WebControls;

namespace BienBaDong
{
    public partial class QuanLyBaiViet : System.Web.UI.Page
    {
        string connStr = ConfigurationManager.ConnectionStrings["ChuoiKetNoi"].ConnectionString;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["TenDangNhap"] == null ||
                !string.Equals(Session["Quyen"]?.ToString(), "Admin", StringComparison.OrdinalIgnoreCase))
            {
                Response.Redirect("TrangChu.aspx");
                return;
            }

            if (!IsPostBack)
                LoadDanhSach();
        }

        private void LoadDanhSach(string keyword = "")
        {
            using (SqlConnection conn = new SqlConnection(connStr))
            {
                string query = "SELECT * FROM BaiViet WHERE TieuDe LIKE @kw ORDER BY NgayDang DESC";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@kw", "%" + keyword + "%");
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                gvBaiViet.DataSource = dt;
                gvBaiViet.DataBind();
            }
        }

        protected void btnTimKiem_Click(object sender, EventArgs e)
        {
            string kw = txtTimKiem.Text.Trim();
            LoadDanhSach(kw);
        }

        protected void btnThem_Click(object sender, EventArgs e)
        {
            string tieuDe = txtTieuDe.Text.Trim();
            string noiDung = txtNoiDung.Text.Trim();
            string nguoiDang = Session["TenDangNhap"]?.ToString() ?? "Admin";
            DateTime ngayDang = DateTime.Now;

            using (SqlConnection conn = new SqlConnection(connStr))
            {
                string query = "INSERT INTO BaiViet (TieuDe, NoiDung, NguoiDang, NgayDang) VALUES (@TieuDe, @NoiDung, @NguoiDang, @NgayDang)";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@TieuDe", tieuDe);
                cmd.Parameters.AddWithValue("@NoiDung", noiDung);
                cmd.Parameters.AddWithValue("@NguoiDang", nguoiDang);
                cmd.Parameters.AddWithValue("@NgayDang", ngayDang);

                conn.Open();
                cmd.ExecuteNonQuery();
            }

            lblThongBao.Text = "Thêm bài viết thành công!";
            LoadDanhSach();
        }

        protected void gvBaiViet_RowEditing(object sender, GridViewEditEventArgs e)
        {
            gvBaiViet.EditIndex = e.NewEditIndex;
            LoadDanhSach(txtTimKiem.Text.Trim());
        }

        protected void gvBaiViet_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            gvBaiViet.EditIndex = -1;
            LoadDanhSach(txtTimKiem.Text.Trim());
        }

        protected void gvBaiViet_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            int id = Convert.ToInt32(gvBaiViet.DataKeys[e.RowIndex].Value);
            GridViewRow row = gvBaiViet.Rows[e.RowIndex];

            string tieuDe = ((TextBox)row.Cells[1].Controls[0]).Text.Trim();
            string noiDung = ((TextBox)row.Cells[2].Controls[0]).Text.Trim();

            using (SqlConnection conn = new SqlConnection(connStr))
            {
                string query = "UPDATE BaiViet SET TieuDe=@TieuDe, NoiDung=@NoiDung, NgayDang=GETDATE() WHERE MaBV=@MaBV";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@TieuDe", tieuDe);
                cmd.Parameters.AddWithValue("@NoiDung", noiDung);
                cmd.Parameters.AddWithValue("@MaBV", id);

                conn.Open();
                cmd.ExecuteNonQuery();
            }

            gvBaiViet.EditIndex = -1;
            LoadDanhSach(txtTimKiem.Text.Trim());
        }

        protected void gvBaiViet_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            int id = Convert.ToInt32(gvBaiViet.DataKeys[e.RowIndex].Value);

            using (SqlConnection conn = new SqlConnection(connStr))
            {
                string query = "DELETE FROM BaiViet WHERE MaBV=@MaBV";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@MaBV", id);
                conn.Open();
                cmd.ExecuteNonQuery();
            }

            LoadDanhSach(txtTimKiem.Text.Trim());
        }
    }
}
