using System;
using System.Web.UI;

namespace BienBaDong
{
    public partial class SuaBai : Page
    {
        public int BaiID;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["TenDangNhap"] == null || Session["Quyen"]?.ToString() != "Admin")
            {
                Response.Redirect("TrangChu.aspx");
            }

            if (!IsPostBack)
            {
                if (!int.TryParse(Request.QueryString["id"], out BaiID))
                {
                    Response.Redirect("AdminPage.aspx");
                    return;
                }

                // TODO: Lấy dữ liệu bài viết từ CSDL theo ID
                // Dữ liệu mẫu
                if (BaiID == 1)
                {
                    txtTieuDe.Text = "Học ASP.NET Web Forms";
                    txtNoiDung.Text = "Đây là nội dung cần sửa...";
                }
                else if (BaiID == 2)
                {
                    txtTieuDe.Text = "Tin tức công nghệ";
                    txtNoiDung.Text = "AI đang phát triển rất mạnh mẽ...";
                }
                else
                {
                    lblMessage.Text = "Không tìm thấy bài viết.";
                    btnCapNhat.Enabled = false;
                }
            }
        }

        protected void btnCapNhat_Click(object sender, EventArgs e)
        {
            string tieuDe = txtTieuDe.Text.Trim();
            string noiDung = txtNoiDung.Text.Trim();

            if (string.IsNullOrEmpty(tieuDe) || string.IsNullOrEmpty(noiDung))
            {
                lblMessage.ForeColor = System.Drawing.Color.Red;
                lblMessage.Text = "Vui lòng nhập đầy đủ!";
                return;
            }

            // TODO: Ghi cập nhật vào CSDL
            lblMessage.ForeColor = System.Drawing.Color.Green;
            lblMessage.Text = "Cập nhật thành công (demo).";
        }
    }
}
