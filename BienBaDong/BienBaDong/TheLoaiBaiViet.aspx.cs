using System;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace BienBaDong
{
    public partial class TheLoaiBaiViet : System.Web.UI.Page
    {
        string connStr = ConfigurationManager.ConnectionStrings["ChuoiKetNoi"].ConnectionString;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Request.QueryString["MaTheLoai"] != null)
                {
                    int maTheLoai = int.Parse(Request.QueryString["MaTheLoai"]);
                    LoadTheLoai(maTheLoai);
                    LoadBaiViet(maTheLoai);
                }
            }
        }

        void LoadTheLoai(int maTheLoai)
        {
            using (SqlConnection conn = new SqlConnection(connStr))
            {
                string sql = "SELECT TenTheLoai FROM TheLoai WHERE MaTheLoai=@MaTheLoai";
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@MaTheLoai", maTheLoai);
                conn.Open();
                var tenTheLoai = cmd.ExecuteScalar();
                lblTenTheLoai.Text = tenTheLoai != null ? tenTheLoai.ToString() : "";
            }
        }

        void LoadBaiViet(int maTheLoai)
        {
            using (SqlConnection conn = new SqlConnection(connStr))
            {
                string sql = @"SELECT MaBaiViet, TenBaiViet, AnhBia 
                               FROM BaiViet 
                               WHERE MaTheLoai=@MaTheLoai AND (An IS NULL OR An=0)
                               ORDER BY NgayDang DESC";
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@MaTheLoai", maTheLoai);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                rptBaiViet.DataSource = dt;
                rptBaiViet.DataBind();
            }
        }
    }
}
