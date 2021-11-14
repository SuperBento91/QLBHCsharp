using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SF_QuanLyBanHang_05Nov21
{
    class HoaDonMuaCTAction
    {
        //Khai bao list
        private List<HoaDonMuaChiTiet> lstHDMuaCT = new List<HoaDonMuaChiTiet>();

        //Ham lay danh sach
        public DataTable LayDanhSach()
        {
            string strSQL = "Select * from hoadonmua_chitiet";

            return DataProvider.LayDanhSach(strSQL);
        }

        //Ham lay chi tiet theo ma
        public HoaDonMuaChiTiet LayChiTiet(string id)
        {
            HoaDonMuaChiTiet objKH = null;

            string strSQL = "Select * from hoadonmua_chitiet where hoadonmua_id = '" + id + "'";

            DataTable data = DataProvider.LayDanhSach(strSQL);

            if (data.Rows.Count > 0)
            {
                objKH = new HoaDonMuaChiTiet();
                objKH.hdMua_id = (int)data.Rows[0]["hoadonmua_id"];
                objKH.sanPham_id = data.Rows[1]["sanpham_id"] + "";
                objKH.sanPham_amount = (int) data.Rows[2]["sanpham_amount"];
                objKH.sanPham_price = (int) data.Rows[3]["sanpham_price"];
                objKH.hdMuaCT_detail = data.Rows[4]["hoadonct_detail"] + "";
            }
            return objKH;
        }

        //Ham them moi
        public bool ThemMoi(HoaDonMuaChiTiet objKH)
        {
            string strInsert = "Insert into hoadonmua_chitiet(hoadonmua_id, sanpham_id, sanpham_amount, sanpham_price, hoadonct_detail) values (@hdmuaid, @sanphamid, @sanphamamount, @sanphamprice, @hdctdetail)";

            SqlParameter[] pars = new SqlParameter[5];

            //Khoi tao va gan gia tri cho tham so
            pars[0] = new SqlParameter("@hdmuaid", SqlDbType.Int);
            pars[0].Value = objKH.hdMua_id;

            pars[1] = new SqlParameter("@sanphamid", SqlDbType.VarChar, 10);
            pars[1].Value = objKH.sanPham_id;

            pars[2] = new SqlParameter("@sanphamamount", SqlDbType.Int);
            pars[2].Value = objKH.sanPham_amount;

            pars[3] = new SqlParameter("@sanphamprice", SqlDbType.Int);
            pars[3].Value = objKH.sanPham_price;

            pars[4] = new SqlParameter("@hdctdetail", SqlDbType.NVarChar, 200);
            pars[4].Value = objKH.hdMuaCT_detail;

            return DataProvider.ThucHien(strInsert, pars);
        }

        //Ham cap nhat
        public bool CapNhat(HoaDonMuaChiTiet objKH)
        {
            string strUpdate = "Update hoadonmua_chitiet set sanpham_id=@sanphamid, sanpham_amount=@sanphamamount, sanpham_price=@sanphamprice, hoadonct_detail=@hdctdetail where hoadonmua_id=@hoadonmuaid";

            SqlParameter[] pars = new SqlParameter[6];

            //Khoi tao va gan gia tri cho tham so
            pars[4] = new SqlParameter("@hoadonmuaid", SqlDbType.Int);
            pars[4].Value = objKH.hdMua_id;

            pars[0] = new SqlParameter("@sanphamid", SqlDbType.VarChar, 10);
            pars[0].Value = objKH.sanPham_id;

            pars[1] = new SqlParameter("@sanphamamount", SqlDbType.Int);
            pars[1].Value = objKH.sanPham_amount;

            pars[2] = new SqlParameter("@sanphamprice", SqlDbType.Int);
            pars[2].Value = objKH.sanPham_price;

            pars[3] = new SqlParameter("@hdctdetail", SqlDbType.NVarChar, 200);
            pars[3].Value = objKH.hdMuaCT_detail;

            return DataProvider.ThucHien(strUpdate, pars);
        }

        //Ham xoa
        public bool Xoa(string id)
        {
            string strDelete = "Delete from hoadonmua_chitiet where hoadonmua_id=@id";

            SqlParameter[] pars = new SqlParameter[1];

            //Khoi tao va gan gia tri cho tham so
            pars[0] = new SqlParameter("@id", SqlDbType.Int);
            pars[0].Value = id;


            return DataProvider.ThucHien(strDelete, pars);
        }
    }
}
