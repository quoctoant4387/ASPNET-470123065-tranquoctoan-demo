using System;
using System.Web.UI;

namespace BienBaDong
{
    public partial class XoaBai : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["TenDangNhap"] == null || Session["Quyen"]?.ToString() != "Admin")
            {
                Response.Redirect("DangNhap.aspx");
            }

            if (!IsPostBack)
            {
                int baiID;
                if (!int.TryParse(Request.QueryString["id"], out baiID))
                {
                    lblMessage.Text = "Không xác định được bài viết cần xóa.";
                    return;
                }

                // TODO: Xóa bài viết trong CSDL (hiện đang demo)
                // Ví dụ:
                // DELETE FROM BaiViet WHERE ID = baiID;

                lblMessage.Text = $"Đã xóa bài viết có ID = {baiID} (demo)";
                lblMessage.ForeColor = System.Drawing.Color.Green;
            }
        }
    }
}
