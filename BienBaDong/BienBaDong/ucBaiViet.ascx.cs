using System;
using System.Collections.Generic;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BienBaDong
{
    public partial class ucBaiViet : System.Web.UI.UserControl
    {
        public bool HienNutAdmin { get; set; }

        public class BaiViet
        {
            public int ID { get; set; }
            public string TieuDe { get; set; }
            public string NoiDung { get; set; }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            // Kiểm tra quyền một lần duy nhất
            if (Session["Quyen"]?.ToString() == "Admin")
                HienNutAdmin = true;
        }

        public void LoadData(List<BaiViet> ds)
        {
            rptBaiViet.DataSource = ds;
            rptBaiViet.DataBind();
        }

        protected void rptBaiViet_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                Panel pnl = (Panel)e.Item.FindControl("pnlAdmin");
                if (pnl != null)
                {
                    pnl.Visible = HienNutAdmin;
                }
            }
        }
    }
}
