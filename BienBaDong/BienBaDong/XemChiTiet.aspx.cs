using System;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace BienBaDong
{
    public partial class XemChiTiet : System.Web.UI.Page
    {
        string connStr = ConfigurationManager.ConnectionStrings["ChuoiKetNoi"].ConnectionString;
        int maBaiViet = 0;
        int trangThaiAn = 0;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.QueryString["iMaBaiViet"] == null)
            {
                Response.Redirect("baiviet.aspx");
                return;
            }
            maBaiViet = int.Parse(Request.QueryString["iMaBaiViet"]);
            if (!IsPostBack)
            {
                LoadChiTiet();
                // Ẩn/hiện panel chức năng cho admin
                if (Session["TaiKhoanNV"] != null)
                {
                    pnlAdmin.Visible = true;
                }
            }
        }

        void LoadChiTiet()
        {
            using (SqlConnection conn = new SqlConnection(connStr))
            {
                string sql = @"SELECT bv.*, tl.TenTheLoai, nd.HoTen
                               FROM BaiViet bv
                               LEFT JOIN TheLoai tl ON bv.MaTheLoai = tl.MaTheLoai
                               LEFT JOIN NguoiDung nd ON bv.MaNguoiDung = nd.MaNguoiDung
                               WHERE MaBaiViet = @MaBaiViet";
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@MaBaiViet", maBaiViet);
                conn.Open();
                SqlDataReader rd = cmd.ExecuteReader();
                if (rd.Read())
                {
                    lblTenTheLoai.Text = rd["TenTheLoai"].ToString();
                    lblTenBaiViet.Text = rd["TenBaiViet"].ToString();
                    lblNgayDang.Text = Convert.ToDateTime(rd["NgayDang"]).ToString("dd/MM/yyyy");
                    if (rd["NgayCapNhat"] != DBNull.Value && !string.IsNullOrEmpty(rd["NgayCapNhat"].ToString()))
                    {
                        lblNgayCapNhat.Text = Convert.ToDateTime(rd["NgayCapNhat"]).ToString("dd/MM/yyyy");
                        smallNgayCapNhat.Visible = true;
                    }
                    lblTacGia.Text = rd["HoTen"].ToString();
                    ltrNoiDung.Text = rd["NoiDung"].ToString();
                    trangThaiAn = rd["An"] != DBNull.Value ? Convert.ToInt32(rd["An"]) : 0;
                    btnAnHien.Text = (trangThaiAn == 0) ? "Ẩn" : "Hiển Thị";
                }
                rd.Close();
            }
        }

        protected void btnXoa_Click(object sender, EventArgs e)
        {
            using (SqlConnection conn = new SqlConnection(connStr))
            {
                SqlCommand cmd = new SqlCommand("DELETE FROM BaiViet WHERE MaBaiViet=@MaBaiViet", conn);
                cmd.Parameters.AddWithValue("@MaBaiViet", maBaiViet);
                conn.Open();
                cmd.ExecuteNonQuery();
            }
            Response.Redirect("baiviet.aspx");
        }

        protected void btnCapNhat_Click(object sender, EventArgs e)
        {
            Response.Redirect("SuaBai.aspx?MaBaiViet=" + maBaiViet);
        }

        protected void btnThemMoi_Click(object sender, EventArgs e)
        {
            Response.Redirect("ThemBai.aspx");
        }

        protected void btnAnHien_Click(object sender, EventArgs e)
        {
            using (SqlConnection conn = new SqlConnection(connStr))
            {
                int newTrangThai = (trangThaiAn == 0) ? 1 : 0;
                SqlCommand cmd = new SqlCommand("UPDATE BaiViet SET An=@An WHERE MaBaiViet=@MaBaiViet", conn);
                cmd.Parameters.AddWithValue("@An", newTrangThai);
                cmd.Parameters.AddWithValue("@MaBaiViet", maBaiViet);
                conn.Open();
                cmd.ExecuteNonQuery();
            }
            Response.Redirect(Request.RawUrl); // Tải lại trang để cập nhật trạng thái
        }
    }
}
