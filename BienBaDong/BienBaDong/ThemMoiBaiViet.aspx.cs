using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BienBaDong
{
    public partial class ThemMoiBaiViet : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["TenDangNhap"] == null || Session["Quyen"]?.ToString() != "Admin")
            {
                Response.Redirect("DangNhap.aspx");

            }
        }
    }
}
