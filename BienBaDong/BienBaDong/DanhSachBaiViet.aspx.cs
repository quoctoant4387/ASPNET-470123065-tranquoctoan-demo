using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BienBaDong
{
    public partial class DanhSachBaiViet : System.Web.UI.Page
    {
        string connStr = ConfigurationManager.ConnectionStrings["ChuoiKetNoi"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string maTheLoai = Request.QueryString["iMaTheloai"];
                if (!string.IsNullOrEmpty(maTheLoai))
                    LoadBaiVietTheoTheLoai(maTheLoai);
                else
                    LoadTatCaBaiViet();
            }
        }

        void LoadBaiVietTheoTheLoai(string maTheLoai)
        {
            using (SqlConnection conn = new SqlConnection(connStr))
            {
                string sql = @"SELECT MaBaiViet, TenBaiViet FROM BaiViet WHERE MaTheLoai=@maTheLoai";
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@maTheLoai", maTheLoai);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                var dt = new System.Data.DataTable();
                da.Fill(dt);

                rptBaiViet.DataSource = dt;
                rptBaiViet.DataBind();
            }
        }

        void LoadTatCaBaiViet()
        {
            using (SqlConnection conn = new SqlConnection(connStr))
            {
                string sql = @"SELECT MaBaiViet, TenBaiViet FROM BaiViet";
                SqlCommand cmd = new SqlCommand(sql, conn);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                var dt = new System.Data.DataTable();
                da.Fill(dt);

                rptBaiViet.DataSource = dt;
                rptBaiViet.DataBind();
            }
        }
    }
}