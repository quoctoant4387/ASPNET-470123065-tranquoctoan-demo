using System;
using System.Data;
using System.Data.SqlClient;
using System.Web.UI;

namespace BienBaDong
{
    public partial class DanhSachBaiViet : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadDanhSachBaiViet();
            }
        }

        private void LoadDanhSachBaiViet()
        {
            string connStr = System.Configuration.ConfigurationManager.ConnectionStrings["ChuoiKetNoi"].ConnectionString;
            using (SqlConnection conn = new SqlConnection(connStr))
            {
                string query = "SELECT MaBaiViet, TenBaiViet, AnhBia FROM BaiViet";
                SqlDataAdapter da = new SqlDataAdapter(query, conn);
                DataTable dt = new DataTable();
                da.Fill(dt);

                rptBaiViet.DataSource = dt;
                rptBaiViet.DataBind();
            }
        }
    }
}
