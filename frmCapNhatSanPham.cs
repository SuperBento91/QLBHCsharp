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
    public partial class frmCapNhatSanPham : Form
    {
        public string sanPhamId { get; set; } = "";
        public frmCapNhatSanPham()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void btnDong_Click(object sender, EventArgs e) { 
            this.Close();
        }

        private void frmCapNhatSanPham_Load(object sender, EventArgs e)
        {
            //Hiển thị XuatXu lên combobox
            HienThiDanhSachXuatXu();
            if(sanPhamId.Length != 0)
            {
                SanPham objSP = DataProvider.SanPhamAct.LayChiTiet(sanPhamId);
                txtMaSP.Text = objSP.sanPhamId;
                txtMaSP.ReadOnly = true;
                txtMoTa.Text = objSP.sanPhamDetail;
                txtTenSP.Text = objSP.sanPhamName;
            }
        }
        /// <summary>
        /// Hiển thị danh sách XuatXu lên combobox
        /// </summary>
        private void HienThiDanhSachXuatXu()
        {
            //Khai bao doi tuong
            XuatXuAction xuatXuAct = new XuatXuAction();

            //Lay danh sach
            DataTable dtXX = xuatXuAct.LayDanhSach();
            DataRow root = dtXX.NewRow();
            root["xuatxu_id"] = "-1";
            root["xuatxu_name"] = "-- Chọn xuất xứ --";
            dtXX.Rows.InsertAt(root, 0);

            //Hien thi len Combobox
            cboXuatXu.DisplayMember = "xuatxu_name";
            cboXuatXu.ValueMember = "xuatxu_id";
            cboXuatXu.DataSource = dtXX;
        }

        private void btnCapNhat_Click(object sender, EventArgs e)
        {
            //Khai báo đối tượng SanPham
            SanPham objSP = new SanPham();
            SanPhamAction spAct = new SanPhamAction();
            DataTable data = spAct.LayDanhSach();
            string maSP = txtMaSP.Text.Replace(" ", "");

            //Gán thông tin từ giao diện
            //Kiểm tra nhập MaSP + check trùng dtb
            if(maSP.Length == 0)
            {
                MessageBox.Show("Vui lòng nhập vào mã sản phẩm");
                txtMaSP.Focus();
                return;
            } 
            else if (maSP.Length > 10)
            {
                MessageBox.Show("Mã sản phẩm tối đa 10 ký tự");
                txtMaSP.Focus();
                return;
            } 

            //Lấy tên SanPham
            if(txtTenSP.Text.Trim().Length == 0)
            {
                MessageBox.Show("Vui lòng nhập vào mã sản phẩm");
                txtTenSP.Focus();
                return;
            }
            else
            {
                objSP.sanPhamName = txtTenSP.Text.Trim();
            }
            //Lấy mota
            objSP.sanPhamDetail = txtMoTa.Text.Trim();
                
            //Lấy thông tin id từ cboXuatXu
            objSP.sanPhamXuatXuId = cboXuatXu.SelectedValue + "";

            //Xử lý thêm mới hoặc cập nhật
            bool ketQua = false;
            if(sanPhamId != null && sanPhamId.Length > 0)
            {
                //Cập nhật
                objSP.sanPhamId = sanPhamId;
                ketQua = spAct.CapNhat(objSP);
            }
            else
            {
                //Thêm mới
                bool isExist = data.AsEnumerable().Any(row => maSP == row.Field<String>("sanpham_id"));
                if (!isExist)
                {
                    objSP.sanPhamId = maSP;
                }
                else
                {
                    MessageBox.Show("Mã sản phẩm đã tồn tại");
                    txtMaSP.Focus();
                    return;
                }
                ketQua = spAct.ThemMoi(objSP);
            }

            if (ketQua)
            {
                MessageBox.Show("Cập nhật sản phẩm thành công");
            }
            else
            {
                MessageBox.Show("Có lỗi trong quá trình cập nhật");
            }
        }
    }
}
