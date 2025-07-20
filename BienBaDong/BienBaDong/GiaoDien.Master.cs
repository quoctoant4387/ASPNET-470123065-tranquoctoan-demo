using System;

namespace BienBaDong
{
    public partial class GiaoDien : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // Đánh dấu menu "active" dựa trên đường dẫn trang hiện tại
            string url = Request.Url.AbsolutePath.ToLower();

            // Đặt active cho menu tương ứng
            if (url.EndsWith("TrangChu.aspx"))
                liTrangChu.Attributes["class"] = "active";
            else if (url.EndsWith("LienHe.aspx"))
                liLienHe.Attributes["class"] = "active";

            // Ví dụ hiển thị tên người dùng đã đăng nhập:
            if (Session["TenDangNhap"] != null)
            {
                liChaoMung.Visible = true;
                lblChaoMung.Text = "Xin chào, " + Session["TenDangNhap"].ToString();
                liDangNhap.Visible = false;
                liDangKy.Visible = false;
            }
            else
            {
                liChaoMung.Visible = false;
                liDangNhap.Visible = true;
                liDangKy.Visible = true;
            }
        }
    }
}
