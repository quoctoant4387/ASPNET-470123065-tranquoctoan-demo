using System;
using System.Data.SqlClient;
using System.Security.Cryptography;
using System.Text;
using System.Web.UI;

namespace BienBaDong
{
    public partial class KetNoiDuLieu : System.Web.UI.Page
    {
        // Khai báo chuỗi kết nối
        public SqlConnection con = new SqlConnection("Data Source=QUOCTOAN;Initial Catalog=BienBaDong;Integrated Security=True");

        // Hàm mã hóa mật khẩu bằng SHA256
        public string MaHoa(string str)
        {
            using (SHA256 sha256 = SHA256.Create())
            {
                byte[] bytes = Encoding.UTF8.GetBytes(str);
                byte[] hashBytes = sha256.ComputeHash(bytes);
                return BitConverter.ToString(hashBytes).Replace("-", "").ToLower();
            }
        }
    }
}
