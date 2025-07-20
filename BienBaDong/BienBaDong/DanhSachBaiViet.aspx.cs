using System;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BienBaDong
{
    public partial class DanhSachBaiViet : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadTheLoai();

                // Nếu có query string iMaTheloai, chọn dropdown tương ứng
                string qs = Request.QueryString["iMaTheloai"];
                if (!string.IsNullOrEmpty(qs) && ddlTheLoai.Items.FindByValue(qs) != null)
                {
                    ddlTheLoai.SelectedValue = qs;
                }

                LoadDanhSachBaiViet();
            }
        }

        // Đổ dữ liệu lên dropdown thể loại
        private void LoadTheLoai()
        {
            string connStr = ConfigurationManager
                .ConnectionStrings["ChuoiKetNoi"].ConnectionString;
            string sql = "SELECT MaTheLoai, TenTheLoai FROM TheLoai ORDER BY TenTheLoai";

            using (SqlConnection conn = new SqlConnection(connStr))
            using (SqlDataAdapter da = new SqlDataAdapter(sql, conn))
            {
                DataTable dt = new DataTable();
                da.Fill(dt);

                ddlTheLoai.DataSource = dt;
                ddlTheLoai.DataTextField = "TenTheLoai";
                ddlTheLoai.DataValueField = "MaTheLoai";
                ddlTheLoai.DataBind();

                // Thêm mục Tất cả
                ddlTheLoai.Items.Insert(0, new ListItem("-- Tất cả --", "0"));
            }
        }

        // Khi thay đổi dropdown thì load lại danh sách
        protected void ddlTheLoai_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadDanhSachBaiViet();
        }

        // Nạp bài viết theo thể loại đang chọn
        private void LoadDanhSachBaiViet()
        {
            string connStr = ConfigurationManager
                .ConnectionStrings["ChuoiKetNoi"].ConnectionString;
            string selected = ddlTheLoai.SelectedValue;

            string sql = @"
                SELECT 
                    BV.MaBaiViet,
                    BV.TenBaiViet,
                    BV.NgayDang,
                    BV.NgayCapNhat,
                    ND.TenDangNhap AS TenNguoiDang,
                    TL.TenTheLoai
                FROM BaiViet BV
                INNER JOIN NguoiDung ND ON BV.MaNguoiDung = ND.MaNguoiDung
                INNER JOIN TheLoai   TL ON BV.MaTheLoai = TL.MaTheLoai
                WHERE (@MaTheLoai = '0' OR BV.MaTheLoai = @MaTheLoai)
                ORDER BY BV.NgayDang DESC";

            using (SqlConnection conn = new SqlConnection(connStr))
            using (SqlCommand cmd = new SqlCommand(sql, conn))
            {
                cmd.Parameters.AddWithValue("@MaTheLoai", selected);
                DataTable dt = new DataTable();
                using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                {
                    da.Fill(dt);
                }

                rptBaiViet.DataSource = dt;
                rptBaiViet.DataBind();
            }
        }
    }
}
