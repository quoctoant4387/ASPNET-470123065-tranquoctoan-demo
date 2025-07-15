using System;
using System.Web.UI;

namespace BienBaDong
{
    public partial class ThemBai : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["TenDangNhap"] == null || Session["Quyen"]?.ToString() != "Admin")
            {
                Response.Redirect("DangNhap.aspx");
            }
        }

        protected void btnLuu_Click(object sender, EventArgs e)
        {
            string tieuDe = txtTieuDe.Text.Trim();
            string noiDung = txtNoiDung.Text.Trim();

            if (string.IsNullOrEmpty(tieuDe) || string.IsNullOrEmpty(noiDung))
            {
                lblMessage.Text = "Vui lòng nhập đầy đủ tiêu đề và nội dung!";
                lblMessage.ForeColor = System.Drawing.Color.Red;
                return;
            }

            // TODO: Ghi vào cơ sở dữ liệu
            // Ví dụ tạm: bạn sẽ kết nối SQL ở bước sau

            lblMessage.ForeColor = System.Drawing.Color.Green;
            lblMessage.Text = "Đã lưu bài viết (chưa kết nối CSDL).";
            txtTieuDe.Text = "";
            txtNoiDung.Text = "";
        }
    }
}
