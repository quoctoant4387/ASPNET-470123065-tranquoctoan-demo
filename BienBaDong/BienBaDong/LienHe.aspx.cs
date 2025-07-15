using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BienBaDong
{
    public partial class LienHe : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            string hoTen = txtHoTen.Text.Trim();
            string email = txtEmail.Text.Trim();
            string dienThoai = txtDienThoai.Text.Trim();
            string chuDe = ddlChuDe.SelectedItem.Text;
            string noiDung = txtNoiDung.Text.Trim();

            lblThongBao.Text = "Thông tin của bạn đã gửi thành công.";

        }
    }
}
