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
    public partial class frmQLHoaDonMua : Form
    {
        public bool isLogin { get; set; } = false;
        public frmQLHoaDonMua()
        {
            InitializeComponent();
        }

        private void frmQLHoaDonMua_Load(object sender, EventArgs e)
        {
            this.Visible = isLogin;
            //Cài đặt khoảng ngày cho Datepicker
            dateFrom.MinDate = new DateTime(2020, 1, 1);
            dateFrom.Value = new DateTime(2021, 1, 1);
            dateTo.MaxDate = DateTime.Today;
            dateTo.Value = DateTime.Today;

            HienThiHoaDonMua();
        }

        private void HienThiHoaDonMua()
        {
            DateTime strFromDate = dateFrom.Value;
            //Thêm cấu trúc để lấy được đúng format ngày tháng
            DateTime strToDate = dateTo.Value.AddDays(1).AddMilliseconds(-1);

            DataTable data = DataProvider.HDMuaAct.LayDanhSach(strFromDate, strToDate);

            //Hiển thị lên giao diện
            gridHoaDonMua.DataSource = null;
            gridHoaDonMua.DataSource = data;
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            HienThiHoaDonMua();
        }

        private void btnThemMoi_Click(object sender, EventArgs e)
        {
            string strThemMoi = "exec dbo.SP_themmoihdmua 'V.A.T', N'Chi tiết hóa đơn mới tạo từ Winform';";

            bool ketQua = DataProvider.ThucHien(strThemMoi);

            if (ketQua) //Them moi thanh cong
            {
                DateTime strFromDate = dateFrom.Value;
                DateTime strToDate = DateTime.Today.AddDays(1).AddMilliseconds(-1);

                DataTable data = DataProvider.HDMuaAct.LayDanhSach(strFromDate, strToDate);

                //Hiển thị lên giao diện
                gridHoaDonMua.DataSource = null;
                gridHoaDonMua.DataSource = data;

                //Lấy giá trị id mới thêm vào từ DataTable
                string id = gridHoaDonMua["hoadonmua_id", gridHoaDonMua.Rows.Count - 1].Value + "";

                //Hien thi form CapNhatThongTin va truyen gia tri id
                frmCapNhatHoaDonMua frmHDMuaChiTiet = new frmCapNhatHoaDonMua();
                frmHDMuaChiTiet.id = id;
                frmHDMuaChiTiet.ShowDialog();
                HienThiHoaDonMua();
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            //Khai bao bien & lay id
            int selectedRow = gridHoaDonMua.CurrentRow.Index;
            string id = gridHoaDonMua["hoadonmua_id", selectedRow].Value + "";

            //Hien thi form CapNhatThongTin va truyen gia tri id
            frmCapNhatHoaDonMua frmHDMuaChiTiet = new frmCapNhatHoaDonMua();
            frmHDMuaChiTiet.id = id;
            frmHDMuaChiTiet.ShowDialog();
            HienThiHoaDonMua();
            HienThiChiTietHoaDon(id);
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Xóa hết sản phẩm trong hóa đơn, ghi chú --Xóa hóa đơn-- và liên hệ bộ phận kế toán để hoàn thiện hồ sơ");
        }

        private void btnDong_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void gridChiTietHoaDon_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void gridHoaDonMua_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            //Khai bao bien
            int selectedRow = gridHoaDonMua.CurrentRow.Index;
            string id = gridHoaDonMua["hoadonmua_id", selectedRow].Value + "";
            //MessageBox.Show("Dòng đang chọn là: " + id);
            HienThiChiTietHoaDon(id);
        }

        private void HienThiChiTietHoaDon(string id)
        {
            string strSQL = "Select sanpham_name as SanPham, sanpham_amount as SoLuong, sanpham_price as GiaNhap, sanpham_amount* sanpham_price as ThanhTien from sanpham sp, hoadonmua_chitiet hdct where sp.sanpham_id = hdct.sanpham_id and hdct.hoadonmua_id = " + id;

            DataTable data = DataProvider.LayDanhSach(strSQL);

            //Hien thi len giao dien
            gridChiTietHoaDon.DataSource = null;
            gridChiTietHoaDon.DataSource = data;

            //Hiển thị ô thành tiền
            object sum = data.Compute("Sum(ThanhTien)", string.Empty);
            txtThanhTien.Text = sum.ToString();
            txtThanhTien.TextAlign = HorizontalAlignment.Right;
            txtThanhTien.ReadOnly = true;
        }
    }
}
