using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SF_QuanLyBanHang_05Nov21
{
    public partial class frmDangNhap : Form
    {
        public bool isDangNhap { get; set; } = false;
        public string tenDangNhap { get; set; } = "";
        public frmDangNhap()
        {
            InitializeComponent();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnDangNhap_Click(object sender, EventArgs e)
        {
            //Kiểm tra đăng nhập
            string matKhau = "", mkMD5 = "";
            tenDangNhap = txtTenDangNhap.Text.Trim();
            matKhau = txtMatKhau.Text.Trim();

            if(tenDangNhap.Length == 0)
            {
                MessageBox.Show("Vui lòng nhập vào tên đăng nhập");
                txtTenDangNhap.Focus();
                return;
            }

            if(matKhau.Length == 0)
            {
                MessageBox.Show("Vui lòng nhập vào mật khẩu");
                txtMatKhau.Focus();
                return;
            }
            //Chuyển đổi mật khẩu hash MD5
            mkMD5 = layMaMD5(matKhau);
            //MessageBox.Show("MD5 C# là: " + mkMD5);

            //Kiểm tra dtb
            string strSQL = "select CONVERT(varchar(max),md5,2) as md5ss from taikhoan where tendangnhap = '" + tenDangNhap + "'";

            DataTable data = DataProvider.LayDanhSach(strSQL);
            
            if(data.Rows.Count == 0)
            {
                MessageBox.Show("Tên đăng nhập không tồn tại");
            }
            else
            {
                string mkSQL = data.Rows[0].Field<string>(0);
                //MessageBox.Show("MD5 SQL là: " + mkSQL);
                if (mkSQL.Equals(mkMD5))
                {
                    MessageBox.Show("Đăng nhập thành công. Xin chào " + tenDangNhap);
                    this.isDangNhap = true;
                    //Quay lại màn hình chính - set DialogResult.OK
                    this.DialogResult = DialogResult.OK;
                } 
                else
                {
                    MessageBox.Show("Sai mật khẩu");
                    txtMatKhau.Focus();
                    return;
                }
            }
        }

        public static string layMaMD5(string input)
        {
            // Use input string to calculate MD5 hash
            using (System.Security.Cryptography.MD5 md5 = System.Security.Cryptography.MD5.Create())
            {
                byte[] inputBytes = System.Text.Encoding.ASCII.GetBytes(input);
                byte[] hashBytes = md5.ComputeHash(inputBytes);

                // Convert the byte array to hexadecimal string
                StringBuilder sb = new StringBuilder();
                for (int i = 0; i < hashBytes.Length; i++)
                {
                    sb.Append(hashBytes[i].ToString("X2"));
                }
                return sb.ToString();
            }
        }
    }
}
