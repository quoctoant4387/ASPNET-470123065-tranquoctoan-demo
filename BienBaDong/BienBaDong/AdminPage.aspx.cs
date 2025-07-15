using System;
using System.Collections.Generic;

namespace BienBaDong
{
    public partial class AdminPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // Chặn người không phải Admin
            if (Session["TenDangNhap"] == null || Session["Quyen"] == null ||
                !Session["Quyen"].ToString().Trim().Equals("admin", StringComparison.OrdinalIgnoreCase))
            {
                Response.Redirect("TrangChu.aspx");
            }
            if (!IsPostBack)
            {
                // Gắn tên người dùng
                lblUser.Text = Session["TenDangNhap"].ToString();

                // Dữ liệu mẫu (sau này bạn thay bằng dữ liệu từ CSDL)
                var ds = new List<ucBaiViet.BaiViet>
                {
                    new ucBaiViet.BaiViet { ID = 1, TieuDe = "Giới thiệu ASP.NET", NoiDung = "Web Forms là công nghệ của Microsoft..." },
                    new ucBaiViet.BaiViet { ID = 2, TieuDe = "Tin tức công nghệ", NoiDung = "AI đang phát triển rất nhanh." }
                };

                // Gọi hàm LoadData của UserControl để hiển thị
                ucBaiViet1.LoadData(ds);
            }
        }

        protected void btnDangXuat_Click(object sender, EventArgs e)
        {
            // Xóa session và chuyển về trang đăng nhập
            Session.Clear();
            Response.Redirect("DangNhap.aspx");
        }
    }
}
