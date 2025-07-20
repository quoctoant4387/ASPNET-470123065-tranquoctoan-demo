using System;
using System.Data.SqlClient;
using System.Configuration;
using System.IO;

namespace BienBaDong
{
    public partial class ThemBai : System.Web.UI.Page
    {
        string connStr = ConfigurationManager.ConnectionStrings["ChuoiKetNoi"].ConnectionString;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadTheLoai();
            }
        }

        void LoadTheLoai()
        {
            using (SqlConnection conn = new SqlConnection(connStr))
            {
                string sql = "SELECT MaTheLoai, TenTheLoai FROM TheLoai";
                SqlDataAdapter da = new SqlDataAdapter(sql, conn);
                var dt = new System.Data.DataTable();
                da.Fill(dt);

                ddlTheLoai.DataSource = dt;
                ddlTheLoai.DataTextField = "TenTheLoai";
                ddlTheLoai.DataValueField = "MaTheLoai";
                ddlTheLoai.DataBind();

                ddlTheLoai.Items.Insert(0, new System.Web.UI.WebControls.ListItem("-- Chọn thể loại --", ""));
            }
        }

        protected void btnLuu_Click(object sender, EventArgs e)
        {
            string tieuDe = txtTenBaiViet.Text.Trim();
            string maTheLoai = ddlTheLoai.SelectedValue;
            string noiDung = txtNoiDung.Text.Trim();
            string maNguoiDung = null;

            if (string.IsNullOrEmpty(tieuDe) || string.IsNullOrEmpty(maTheLoai) || string.IsNullOrEmpty(noiDung))
            {
                lblMessage.Text = "Vui lòng nhập đầy đủ thông tin bắt buộc!";
                return;
            }

            string MaNguoiDung = Session["TenDangNhap"]?.ToString();

            try
            {
                using (SqlConnection conn = new SqlConnection(connStr))
                {
                    conn.Open();
                    string sql = @"INSERT INTO BaiViet (TenBaiViet, MaTheLoai, NoiDung, NgayDang, MaNguoiDung)
                           VALUES (@TenBaiViet, @MaTheLoai, @NoiDung, @NgayDang, @MaNguoiDung)";
                    SqlCommand cmd = new SqlCommand(sql, conn);
                    cmd.Parameters.AddWithValue("@TenBaiViet", tieuDe);
                    cmd.Parameters.AddWithValue("@MaTheLoai", maTheLoai);
                    cmd.Parameters.AddWithValue("@NoiDung", noiDung);
                    cmd.Parameters.AddWithValue("@NgayDang", DateTime.Now);
                    cmd.Parameters.AddWithValue("@MaNguoiDung", maNguoiDung ?? (object)DBNull.Value);

                    cmd.ExecuteNonQuery();
                }
                lblMessage.ForeColor = System.Drawing.Color.Green;
                lblMessage.Text = "Đã thêm bài viết thành công!";
                txtTenBaiViet.Text = "";
                ddlTheLoai.SelectedIndex = 0;
                txtNoiDung.Text = "";
            }
            catch (Exception ex)
            {
                lblMessage.ForeColor = System.Drawing.Color.Red;
                lblMessage.Text = "Lỗi khi lưu bài viết: " + ex.Message;
            }
        }
    }
}