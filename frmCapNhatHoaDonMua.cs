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
    public partial class frmCapNhatHoaDonMua : Form
    {
        //Tạo 1 list Temp
        private DataTable dataTemp = null;
        public frmCapNhatHoaDonMua()
        {
            InitializeComponent();
        }
        //Khai báo biến id
        public string id { get; set; } = "";

        private void frmCapNhatHoaDonMua_Load(object sender, EventArgs e)
        {
            //Hiển thị danh sách sản phẩm
            HienThiDanhSachSanPham();

            //Hiển thị chi tiết hóa đơn
            HienThiHoaDonChiTiet();
        }
        /// <summary>
        /// Hàm hiển thị thông tin sản phẩm lên combobox
        /// </summary>
        private void HienThiDanhSachSanPham()
        {
            //Lay danh sach
            DataTable dtXX = DataProvider.SanPhamAct.LayDanhSach();

            //Chèn thêm 1 lựa chọn trống
            DataRow root = dtXX.NewRow();
            root["sanpham_name"] = "-- Lựa chọn sản phẩm --";
            root["sanpham_id"] = "0";
            dtXX.Rows.InsertAt(root, 0);

            //Hien thi len Combobox
            cboSP.DisplayMember = "sanpham_name";
            cboSP.ValueMember = "sanpham_id";
            cboSP.DataSource = dtXX;
            cboSP.DropDownStyle = ComboBoxStyle.DropDown;
        }

        private void HienThiDanhSachCongTy()
        {
            //Khai bao doi tuong
            //spAct = new SanPhamAction();

            //Lay danh sach
            //DataTable dtXX = spAct.LayDanhSach();

            //Hien thi len Combobox
            //cboSP.DisplayMember = "sanpham_name";
            //cboSP.ValueMember = "sanpham_id";
            //cboSP.DataSource = dtXX;
        }

        private void cboSP_SelectedIndexChanged(object sender, EventArgs e)
        {
            string spId = cboSP.SelectedValue.ToString();
            //MessageBox.Show("Id san pham dang chon la: " + spId);
            if(spId != "0")
            {
                txtChiTietSP.Text = DataProvider.SanPhamAct.LayChiTiet(spId).sanPhamDetail;
                txtChiTietSP.ReadOnly = true;

                //Kiểm tra nếu có sản phẩm trong bảng thì trả về số lượng và giá
                DataRow rw = dataTemp.AsEnumerable().FirstOrDefault(tt => tt.Field<string>("ID") == spId);
                if (rw != null)
                {
                    //MessageBox.Show("Sản phẩm đã có trong bảng chi tiết"); --> OK
                    txtSoLuong.Text = rw["SoLuong"].ToString();
                    txtGia.Text = rw["GiaNhap"].ToString();
                }
                else
                {
                    txtSoLuong.Clear();
                    txtGia.Clear();
                }
            }
            else
            {
                txtChiTietSP.Clear();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //Thêm sản phẩm mới
            frmCapNhatSanPham frmNewSP = new frmCapNhatSanPham();
            frmNewSP.ShowDialog();
            this.Show();
            HienThiDanhSachSanPham();
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            HienThiDanhSachSanPham();
        }

        private void HienThiHoaDonChiTiet()
        {
            string strSQL = "Select sp.sanpham_id as ID, sanpham_name as SanPham, sanpham_amount as SoLuong, sanpham_price as GiaNhap, sanpham_amount*sanpham_price as ThanhTien from sanpham sp, hoadonmua_chitiet hdct where sp.sanpham_id = hdct.sanpham_id and hdct.hoadonmua_id = " + id;

            if(dataTemp == null)
            {
                dataTemp = DataProvider.LayDanhSach(strSQL);
            }

            //Hien thi len giao dien
            gridChiTietHoaDon.DataSource = null;
            gridChiTietHoaDon.DataSource = dataTemp;

            //Hiển thị ô thành tiền
            object sum = dataTemp.Compute("Sum(ThanhTien)", string.Empty);
            txtThanhTien.Text = sum.ToString();
            txtThanhTien.TextAlign = HorizontalAlignment.Right;
            txtThanhTien.ReadOnly = true;

            //Hiển thị thông tin cơ bản của hóa đơn
            HoaDonMua objHD = DataProvider.HDMuaAct.LayChiTiet(id);
            txtSoHoaDon.Text = objHD.hdMua_number + "";
            txtGhiChu.Text = objHD.hdMua_detail + "";
            txtLoaiHD.Text = objHD.hdMua_type + "";
            dateHDMua.Value = objHD.hdMua_date;
        }

        private void gridChiTietHoaDon_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            //Lấy thông tin sản phẩm được click, trả về combobox tương ứng, giá + số lượng
            string spId = gridChiTietHoaDon["ID", e.RowIndex].Value + "";
            string spName = gridChiTietHoaDon["SanPham", e.RowIndex].Value + "";
            txtSoLuong.Text = gridChiTietHoaDon["SoLuong", e.RowIndex].Value + "";
            txtGia.Text = gridChiTietHoaDon["GiaNhap", e.RowIndex].Value + "";

            //Hiển thị combobox - FindStringExact - tìm theo tên hiển thị
            cboSP.SelectedIndex = cboSP.FindStringExact(spName);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //Thêm sp vào hóa đơn
            string spId = cboSP.SelectedValue + "";
            string spName = DataProvider.SanPhamAct.LayChiTiet(spId).sanPhamName;
            int soLuong = 0, gia = 0;
            //Lấy số lượng
            if(!int.TryParse(txtSoLuong.Text, out soLuong))
            {
                MessageBox.Show("Vui lòng nhập vào số lượng");
                txtSoLuong.Focus();
                return;
            }
            //Lấy giá
            if (!int.TryParse(txtGia.Text, out gia))
            {
                MessageBox.Show("Vui lòng nhập vào giá");
                txtGia.Focus();
                return;
            }
            //Kiểm tra đã có trong bảng
            DataRow rw = dataTemp.AsEnumerable().FirstOrDefault(tt => tt.Field<string>("ID") == spId);
            if (rw != null)
            {
                //Sản phẩm đã có trong bảng
                rw["SoLuong"] = soLuong + "";
                rw["GiaNhap"] = gia + "";
                rw["ThanhTien"] = gia * soLuong + "";
            } 
            else
            {
                //Sản phẩm chưa có trong bảng
                DataRow rowInsert = dataTemp.NewRow();
                rowInsert[0] = spId;
                rowInsert[1] = spName + "";
                rowInsert[2] = soLuong + "";
                rowInsert[3] = gia + "";
                rowInsert[4] = (soLuong * gia) + "";
                dataTemp.Rows.InsertAt(rowInsert, dataTemp.Rows.Count);
            }

            //Gọi lại hàm hiển thị hóa đơn chi tiết
            HienThiHoaDonChiTiet();
        }

        private void btnXoaKhoiHD_Click(object sender, EventArgs e)
        {
            //Xóa sp ra khỏi HD
            int selectedRow = gridChiTietHoaDon.CurrentRow.Index;

            var rs = MessageBox.Show("Bạn có chắc muốn xóa sản phẩm này?", "Xác nhận", MessageBoxButtons.OKCancel);

            if(rs == DialogResult.OK)
            {
                //Tiến hành xóa
                DataRow row = dataTemp.Rows[selectedRow];
                dataTemp.Rows.Remove(row);
                //Hiển thị lại thông tin
                HienThiHoaDonChiTiet();
                HienThiDanhSachSanPham();
                txtChiTietSP.Clear();
                txtGia.Clear();
                txtSoLuong.Clear();
            }
            
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnLuuHoaDon_Click(object sender, EventArgs e)
        {
            //Lưu thông tin Hóa đơn
            HoaDonMua objHDMua = new HoaDonMua();

            objHDMua.hdMua_date = dateHDMua.Value;
            objHDMua.congtyId = "testID";
            objHDMua.hdMua_type = txtLoaiHD.Text;
            objHDMua.hdMua_id = int.Parse(id);
            objHDMua.hdMua_number = txtSoHoaDon.Text;
            objHDMua.hdMua_detail = txtGhiChu.Text;
            bool ketQua1 = DataProvider.HDMuaAct.CapNhat(objHDMua);

            //Xử lý bảng sản phẩm
            //Xóa hết thông tin sản phẩm cũ
            string strSQL = "Delete from hoadonmua_chitiet where hoadonmua_id = " + id;

            DataProvider.ThucHien(strSQL);
            //Thêm thông tin sản phẩm mới từ dataTemp
            //Vòng lặp qua bảng để lấy tham số(sanpham_id, sanpham_amount, sanpham_price) chèn vào câu lệnh ThucHien

            HoaDonMuaChiTiet hdct = null;
            bool ketQua2 = false;

            foreach(DataRow row in dataTemp.Rows)
            {
                hdct = new HoaDonMuaChiTiet();
                if(row != null) //TH có dòng trắng vừa xóa xong
                {
                    hdct.hdMua_id = int.Parse(id);
                    hdct.sanPham_id = row["ID"].ToString();
                    hdct.sanPham_amount = int.Parse(row["SoLuong"].ToString());
                    hdct.sanPham_price = int.Parse(row["GiaNhap"].ToString());
                    hdct.hdMuaCT_detail = "Sửa hóa đơn lần cuối lúc: " + DateTime.Now;

                    ketQua2 = DataProvider.HDMuaCTAct.ThemMoi(hdct);
                    if (!ketQua2)
                    {
                        break;
                    }
                }
            }

            if(ketQua1 && ketQua2)
            {
                MessageBox.Show("Cập nhật hóa đơn thành công");
            }
            else
            {
                MessageBox.Show("Xảy ra lỗi trong quá trình cập nhật hóa đơn");
                MessageBox.Show("Cập nhật hóa đơn: " + ketQua1 + " Cập nhật chi tiết: " + ketQua2);
            }
        }
    }
}
