using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SF_QuanLyBanHang_05Nov21
{
    class SanPhamAction
    {
        //Khai bao list
        private List<SanPham> lstSanPham = new List<SanPham>();

        //Ham lay danh sach
        public DataTable LayDanhSach()
        {
            string strSQL = "Select * from sanpham";

            return DataProvider.LayDanhSach(strSQL);
        }

        //Ham lay chi tiet theo ma
        public SanPham LayChiTiet(string id)
        {
            SanPham objSP = null;

            string strSQL = "Select * from sanpham where sanpham_id = '" + id + "'";

            DataTable dtSP = DataProvider.LayDanhSach(strSQL);

            if(dtSP.Rows.Count > 0)
            {
                objSP = new SanPham();
                objSP.sanPhamId = dtSP.Rows[0]["sanpham_id"] + "";
                objSP.sanPhamName = dtSP.Rows[0]["sanpham_name"] + "";
                objSP.sanPhamDetail = dtSP.Rows[0]["sanpham_detail"] + "";
                objSP.sanPhamXuatXuId = dtSP.Rows[0]["sanpham_xuatxuid"] + "";
            }
            return objSP;
        }

        //Ham them moi
        public bool ThemMoi(SanPham objSP)
        {
            string strInsert = "Insert into sanpham(sanpham_id, sanpham_name, sanpham_detail, sanpham_xuatxuid) values (@sanphamid, @sanphamname, @sanphamdetail, @sanphamxuatxuid)";

            SqlParameter[] pars = new SqlParameter[4];

            //Khoi tao va gan gia tri cho tham so
            pars[0] = new SqlParameter("@sanphamid", SqlDbType.VarChar, 10);
            pars[0].Value = objSP.sanPhamId;

            pars[1] = new SqlParameter("@sanphamname", SqlDbType.NVarChar, 50);
            pars[1].Value = objSP.sanPhamName;

            pars[2] = new SqlParameter("@sanphamdetail", SqlDbType.NVarChar, 200);
            pars[2].Value = objSP.sanPhamDetail;

            pars[3] = new SqlParameter("@sanphamxuatxuid", SqlDbType.VarChar, 10);
            pars[3].Value = objSP.sanPhamXuatXuId;

            return DataProvider.ThucHien(strInsert, pars);
        }

        //Ham cap nhat
        public bool CapNhat(SanPham objSP)
        {
            string strUpdate = "Update sanpham set sanpham_name=@sanphamname, sanpham_detail=@sanphamdetail, sanpham_xuatxuid=@sanphamxuatxuid where sanpham_id=@sanphamid";

            SqlParameter[] pars = new SqlParameter[4];

            //Khoi tao va gan gia tri cho tham so
            pars[0] = new SqlParameter("@sanphamname", SqlDbType.NVarChar, 50);
            pars[0].Value = objSP.sanPhamName;

            pars[1] = new SqlParameter("@sanphamdetail", SqlDbType.NVarChar, 200);
            pars[1].Value = objSP.sanPhamDetail;

            pars[2] = new SqlParameter("@sanphamxuatxuid", SqlDbType.VarChar, 10);
            pars[2].Value = objSP.sanPhamXuatXuId;

            pars[3] = new SqlParameter("@sanphamid", SqlDbType.VarChar, 10);
            pars[3].Value = objSP.sanPhamId;

            return DataProvider.ThucHien(strUpdate, pars);
        }

        //Ham xoa
        public bool Xoa(string id)
        {
            string strDelete = "Delete from sanpham where sanpham_id=@sanphamid";

            SqlParameter[] pars = new SqlParameter[1];

            //Khoi tao va gan gia tri cho tham so
            pars[0] = new SqlParameter("@sanphamid", SqlDbType.VarChar, 10);
            pars[0].Value = id;


            return DataProvider.ThucHien(strDelete, pars);
        }
    }
}
