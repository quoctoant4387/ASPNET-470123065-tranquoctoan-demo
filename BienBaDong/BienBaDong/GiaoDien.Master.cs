using System;
using System.Web.UI;

namespace BienBaDong
{
    public partial class GiaoDien : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["TenDangNhap"] != null)
                {
                    string tenDangNhap = Session["TenDangNhap"].ToString();
                    string quyen = Session["Quyen"] != null ? Session["Quyen"].ToString() : "";

                    lblChaoMung.Text = "Xin chào, " + tenDangNhap;
                    liChaoMung.Visible = true;
                    lnkDangNhap.Visible = false;
                    lnkDangKy.Visible = false;
                }
                else
                {
                    liChaoMung.Visible = false;
                    lnkDangNhap.Visible = true;
                    lnkDangKy.Visible = true;
                }
            }
        }
        public string IsActiveMenu(string pageName)
        {
            string currentPage = System.IO.Path.GetFileName(Request.Url.AbsolutePath);
            System.Diagnostics.Debug.WriteLine("🔍 Current Page: " + currentPage);  // Xem log
            return currentPage.Equals(pageName, StringComparison.OrdinalIgnoreCase) ? "active" : "";
        }
        public string IsActiveMenu(string pageName, string loaiPrefix = "")
        {
            string currentPage = System.IO.Path.GetFileName(Request.Url.AbsolutePath);
            string loai = Request.QueryString["loai"] ?? "";

            if (!string.IsNullOrEmpty(loaiPrefix))
            {
                return (currentPage.Equals(pageName, StringComparison.OrdinalIgnoreCase) && loai.StartsWith(loaiPrefix, StringComparison.OrdinalIgnoreCase)) ? "active" : "";
            }

            return currentPage.Equals(pageName, StringComparison.OrdinalIgnoreCase) ? "active" : "";
        }

    }
}
