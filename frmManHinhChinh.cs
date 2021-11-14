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
    public partial class frmManHinhChinh : Form
    {
        bool isLogin = false;
        string tenDangNhap = "";
        public frmManHinhChinh()
        {
            InitializeComponent();
        }

        private void menuDangNhap_Click(object sender, EventArgs e)
        {
            //Ấn nhầm, không có gì xảy ra ở đây cả.
        }

        private void đăngNhậpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Hiển thị form đăng nhập
            frmDangNhap frmLogin = new frmDangNhap();
            frmLogin.ShowDialog();
            this.Show();
            this.isLogin = frmLogin.isDangNhap;
            this.tenDangNhap = frmLogin.tenDangNhap;

            lblUser.Text = "Người dùng: " + tenDangNhap;
            HienThiMenu(isLogin);
        }

        private void đăngXuấtToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Đăng xuất, đóng (hidden) các cửa sổ
            var rs = MessageBox.Show("Bạn có chắc muốn đăng xuất?", "Xác nhận", MessageBoxButtons.OKCancel);
            if(rs == DialogResult.OK)
            {
                isLogin = false;
                tenDangNhap = "";
                //Close all the open form
                Logout();
                //Display the login form again
                frmDangNhap frmLogin = new frmDangNhap();
                frmLogin.ShowDialog();
            }
        }

        private void hóaĐơnMuaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Hiển thị danh sách hóa đơn mua frmQLHoaDonMua
            frmQLHoaDonMua frmHDMua = new frmQLHoaDonMua();
            frmHDMua.isLogin = isLogin;
            frmHDMua.Show();
        }

        private void hóaĐơnBánToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Hiển thị dánh sách hóa đơn bán frmQLHoaDonBan
        }

        private void báoCáoDoanhThuToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Hiển thị báo cáo doanh thu
        }

        private void báoCáoTồnKhoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Hiển thị báo cáo tồn kho
        }

        private void sảnPhẩmToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Hiển thị form Sản phẩm frmSanPham
            frmSanPham frmSP = new frmSanPham();
            frmSP.Show();
        }

        private void côngTyNhàCungCấpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Hiển thị form Công ty
            
        }

        private void kháchHàngToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Hiển thị form Khách hàng
        }

        private void xuấtXứToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Hiển thị form Xuất xứ frmXuatXu
            frmXuatXu frmXX = new frmXuatXu();
            frmXX.Show();
        }

        private void frmManHinhChinh_Load(object sender, EventArgs e)
        {
            this.Name = "ManHinhChinh";
            isLogin = false;
            tenDangNhap = "";

            //Set hiển thị menu
            HienThiMenu(isLogin);
        }

        private void HienThiMenu(bool isLogin) 
        {
            //Login = true
            menuDangNhap.Visible = !isLogin;
            menuDangXuat.Visible = isLogin;
            menuBaoCao.Visible = isLogin;
            menuHoaDon.Visible = isLogin;
            menuThongTin.Visible = isLogin;
        }

        public static void Logout()
        {
            foreach(Form frm in Application.OpenForms)
            {
                if(frm.Name != "ManHinhChinh")
                {
                    frm.Close();
                }
            }
        }
    }
}
