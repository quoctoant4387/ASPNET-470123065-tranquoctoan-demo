using System;
using System.Data;
using System.Data.SqlClient;
using System.Web.UI.WebControls;

namespace BienBaDong
{
    public partial class SuaBai : System.Web.UI.Page
    {
        protected string MaBaiViet;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                MaBaiViet = Request.QueryString["iMaBaiViet"];
                if (string.IsNullOrEmpty(MaBaiViet))
                {
                    lblMessage.Text = "Không xác định được mã bài viết!";
                    btnLuu.Enabled = false;
                    return;
                }
                LoadTheLoai();
                LoadBaiViet(MaBaiViet);
            }
        }

        void LoadTheLoai()
        {
            string connStr = System.Configuration.ConfigurationManager.ConnectionStrings["ChuoiKetNoi"].ConnectionString;
            using (SqlConnection conn = new SqlConnection(connStr))
            {
                conn.Open();
                string sql = "SELECT MaTheLoai, TenTheLoai FROM TheLoai";
                SqlDataAdapter da = new SqlDataAdapter(sql, conn);
                DataTable dt = new DataTable();
                da.Fill(dt);

                ddlTheLoai.DataSource = dt;
                ddlTheLoai.DataTextField = "TenTheLoai";
                ddlTheLoai.DataValueField = "MaTheLoai";
                ddlTheLoai.DataBind();
            }
        }

        void LoadBaiViet(string maBaiViet)
        {
            string connStr = System.Configuration.ConfigurationManager.ConnectionStrings["ChuoiKetNoi"].ConnectionString;
            using (SqlConnection conn = new SqlConnection(connStr))
            {
                conn.Open();
                string sql = "SELECT MaBaiViet, An, TenBaiViet, MaTheLoai, NoiDung FROM BaiViet WHERE MaBaiViet = @MaBaiViet";
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@MaBaiViet", maBaiViet);

                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    txtMaBaiViet.Text = reader["MaBaiViet"].ToString();
                    ddlAn.SelectedValue = reader["An"].ToString();
                    txtTenBaiViet.Text = reader["TenBaiViet"].ToString();
                    ddlTheLoai.SelectedValue = reader["MaTheLoai"].ToString();
                    txtNoiDung.Text = reader["NoiDung"] != DBNull.Value ? reader["NoiDung"].ToString() : "";
                }
                else
                {
                    lblMessage.Text = "Không tìm thấy bài viết cần sửa!";
                    btnLuu.Enabled = false;
                }
                reader.Close();
            }
        }

        protected void btnLuu_Click(object sender, EventArgs e)
        {
            string connStr = System.Configuration.ConfigurationManager.ConnectionStrings["ChuoiKetNoi"].ConnectionString;
            using (SqlConnection conn = new SqlConnection(connStr))
            {
                conn.Open();
                string sql = "UPDATE BaiViet SET An=@An, TenBaiViet=@TenBaiViet, MaTheLoai=@MaTheLoai, NoiDung=@NoiDung WHERE MaBaiViet=@MaBaiViet";
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@An", ddlAn.SelectedValue);
                cmd.Parameters.AddWithValue("@TenBaiViet", txtTenBaiViet.Text.Trim());
                cmd.Parameters.AddWithValue("@MaTheLoai", ddlTheLoai.SelectedValue);
                cmd.Parameters.AddWithValue("@NoiDung", txtNoiDung.Text.Trim());
                cmd.Parameters.AddWithValue("@MaBaiViet", txtMaBaiViet.Text.Trim());
                int kq = cmd.ExecuteNonQuery();
                if (kq > 0)
                {
                    lblMessage.ForeColor = System.Drawing.Color.Green;
                    lblMessage.Text = "Cập nhật bài viết thành công!";
                }
                else
                {
                    lblMessage.Text = "Cập nhật thất bại!";
                }
            }
        }
    }
}
