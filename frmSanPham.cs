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
    public partial class frmSanPham : Form
    {
        public frmSanPham()
        {
            InitializeComponent();
        }

        private void btnCapNhat_Click(object sender, EventArgs e)
        {
            //Sửa sản phẩm
            int selectedRow = gridSanPham.CurrentRow.Index;
            string idSP = gridSanPham["sanpham_id", selectedRow].Value.ToString();

            frmCapNhatSanPham frmSuaSP = new frmCapNhatSanPham();
            frmSuaSP.sanPhamId = idSP;
            frmSuaSP.ShowDialog();

            //Hiển thị lại danh sách Sản phẩm
            HienThiDanhSachSanPham();
        }

        private void btnThemMoi_Click(object sender, EventArgs e)
        {
            frmCapNhatSanPham frmAddSP = new frmCapNhatSanPham();
            frmAddSP.ShowDialog();

            //Hiển thị lại danh sách sản phẩm
            HienThiDanhSachSanPham();
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            //Xóa sản phẩm
        }

        private void btnDong_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmSanPham_Load(object sender, EventArgs e)
        {
            HienThiDanhSachSanPham();
        }

        private void HienThiDanhSachSanPham()
        {
            //Khai bao doi tuong
            SanPhamAction sanPhamAct = new SanPhamAction();

            //Lay danh sach
            DataTable dtSP = sanPhamAct.LayDanhSach();

            //Hien thi danh sach
            gridSanPham.DataSource = null;
            gridSanPham.DataSource = dtSP;
        }
    }
}
