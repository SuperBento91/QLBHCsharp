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
    public partial class frmXuatXu : Form
    {
        public frmXuatXu()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            HienThiDanhSachXuatXu();
        }
        
        private void HienThiDanhSachXuatXu()
        {
            //Khai bao doi tuong
            XuatXuAction xuatXuAct = new XuatXuAction();

            //Lay danh sach
            DataTable dtXX = xuatXuAct.LayDanhSach();

            //Hien thi danh sach
            gridXuatXu.DataSource = null;
            gridXuatXu.DataSource = dtXX;
        }

        private void btnDong_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {

        }

        private void btnCapNhat_Click(object sender, EventArgs e)
        {

        }

        private void btnThemMoi_Click(object sender, EventArgs e)
        {

        }
    }
}
