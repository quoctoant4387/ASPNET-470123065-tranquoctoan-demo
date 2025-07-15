using System;
using System.Data;
using System.Data.SqlClient;
using System.Web.UI;

namespace BienBaDong
{
    public partial class BaiViet : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string sMaBaiViet = Request.QueryString["iMaBaiViet"];
                if (!string.IsNullOrEmpty(sMaBaiViet) && int.TryParse(sMaBaiViet, out int maBaiViet))
                {
                    LoadBaiViet(maBaiViet);
                }
                else
                {
                    Response.Redirect("~/DanhSachBaiViet.aspx"); // Nếu không có mã, quay lại danh sách
                }
            }
        }

        private void LoadBaiViet(int maBaiViet)
        {
            string connStr = System.Configuration.ConfigurationManager.ConnectionStrings["ChuoiKetNoi"].ConnectionString;
            using (SqlConnection conn = new SqlConnection(connStr))
            {
                string query = "SELECT TenBaiViet, NoiDung, HinhAnh FROM BaiViet WHERE MaBaiViet = @MaBaiViet";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@MaBaiViet", maBaiViet);

                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    lblTieuDe.Text = reader["TenBaiViet"].ToString();
                    ltrNoiDung.Text = reader["NoiDung"].ToString();
                    imgHinh.ImageUrl = "~/Hinh/" + reader["HinhAnh"].ToString();
                }
                else
                {
                    lblTieuDe.Text = "Không tìm thấy bài viết.";
                }
                conn.Close();
            }
        }
    }
}
