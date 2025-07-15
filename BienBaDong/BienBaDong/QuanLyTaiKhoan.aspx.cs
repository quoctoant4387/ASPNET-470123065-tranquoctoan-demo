using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Web.UI.WebControls;

namespace BienBaDong
{
    public partial class QuanLyTaiKhoan : System.Web.UI.Page
    {
        string connStr = System.Configuration.ConfigurationManager.ConnectionStrings["ChuoiKetNoi"].ConnectionString;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["TenDangNhap"] == null || Session["Quyen"] == null ||
                !Session["Quyen"].ToString().Trim().Equals("admin", StringComparison.OrdinalIgnoreCase))
            {
                Response.Redirect("TrangChu.aspx");
            }
            if (!IsPostBack)
            {
                pnlThemMoi.Visible = true;
                LoadDanhSachTaiKhoan();
            }
        }
        private void LoadDanhSachTaiKhoan()
        {
            using (SqlConnection conn = new SqlConnection(connStr))
            {
                SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM NguoiDung", conn);
                DataTable dt = new DataTable();
                da.Fill(dt);
                gvTaiKhoan.DataSource = dt;
                gvTaiKhoan.DataKeyNames = new string[] { "MaND" };
                gvTaiKhoan.DataBind();
            }
        }

        protected void gvTaiKhoan_RowEditing(object sender, GridViewEditEventArgs e)
        {
            gvTaiKhoan.EditIndex = e.NewEditIndex;
            pnlThemMoi.Visible = false;
            LoadDanhSachTaiKhoan();
        }

        protected void gvTaiKhoan_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            gvTaiKhoan.EditIndex = -1;
            pnlThemMoi.Visible = true;
            LoadDanhSachTaiKhoan();
        }

        protected void gvTaiKhoan_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            int maND = Convert.ToInt32(gvTaiKhoan.DataKeys[e.RowIndex].Value);
            GridViewRow row = gvTaiKhoan.Rows[e.RowIndex];

            string hoTen = ((TextBox)row.Cells[1].Controls[0]).Text.Trim();
            string tenDangNhap = ((TextBox)row.Cells[2].Controls[0]).Text.Trim();
            string matKhau = ((TextBox)row.Cells[3].Controls[0]).Text.Trim();
            string gioiTinh = ((RadioButtonList)row.Cells[4].Controls[0]).Text.Trim();
            string quyen = ((TextBox)row.Cells[5].Controls[0]).Text.Trim();

            using (SqlConnection conn = new SqlConnection(connStr))
            {
                string sql = "UPDATE NguoiDung SET HoTen=@HoTen, TenDangNhap=@TenDangNhap, MatKhau=@MatKhau, GioiTinh=@GioiTinh, Quyen=@Quyen WHERE ID=@ID";
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@HoTen", hoTen);
                cmd.Parameters.AddWithValue("@TenDangNhap", tenDangNhap);
                cmd.Parameters.AddWithValue("@MatKhau", matKhau);
                cmd.Parameters.AddWithValue("@GioiTinh", gioiTinh);
                cmd.Parameters.AddWithValue("@Quyen", quyen);
                conn.Open();
                cmd.ExecuteNonQuery();
            }

            gvTaiKhoan.EditIndex = -1;
            pnlThemMoi.Visible = true;
            LoadDanhSachTaiKhoan();
        }

        protected void gvTaiKhoan_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            int maND = Convert.ToInt32(gvTaiKhoan.DataKeys[e.RowIndex].Value);

            using (SqlConnection conn = new SqlConnection(connStr))
            {
                string sql = "DELETE FROM NguoiDung WHERE MaND=@MaND";
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@MaND", maND);

                conn.Open();
                cmd.ExecuteNonQuery();
            }

            LoadDanhSachTaiKhoan();
        }
        protected void btnThemMoi_Click(object sender, EventArgs e)
        {
            string hoTen = txtHoTen.Text.Trim();
            string tenDangNhap = txtTenDangNhap.Text.Trim();
            string matKhau = txtMatKhau.Text.Trim();
            string gioiTinh = rblGioiTinh.SelectedValue;
            string email = txtEmail.Text.Trim();
            string ngaySinhText = txtNgaySinh.Text.Trim();

            DateTime ngaySinh;
            if (!DateTime.TryParseExact(ngaySinhText, "dd/MM/yyyy", null, System.Globalization.DateTimeStyles.None, out ngaySinh))
            {
                lblThongBao.Text = "Ngày sinh không hợp lệ. Vui lòng nhập theo định dạng dd/MM/yyyy.";
                lblThongBao.ForeColor = System.Drawing.Color.Red;
                return;
            }

            string connStr = ConfigurationManager.ConnectionStrings["ChuoiKetNoi"].ConnectionString;
            using (SqlConnection conn = new SqlConnection(connStr))
            {
                string query = "INSERT INTO NguoiDung (HoTen, TenDangNhap, MatKhau, GioiTinh, Email, NgaySinh) VALUES (@HoTen, @TenDangNhap, @MatKhau, @GioiTinh, @Email, @NgaySinh), 'User'";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@HoTen", hoTen);
                    cmd.Parameters.AddWithValue("@TenDangNhap", tenDangNhap);
                    cmd.Parameters.AddWithValue("@MatKhau", matKhau);
                    cmd.Parameters.AddWithValue("@GioiTinh", gioiTinh);
                    cmd.Parameters.AddWithValue("@Email", email);
                    cmd.Parameters.AddWithValue("@NgaySinh", ngaySinh);

                    conn.Open();
                    cmd.ExecuteNonQuery();
                }
            }

            lblThongBao.Text = "Đã thêm tài khoản mới thành công.";
            lblThongBao.ForeColor = System.Drawing.Color.Green;
            LoadDanhSachTaiKhoan(); // Sau khi thêm, cập nhật lại danh sách
        }
    }
}