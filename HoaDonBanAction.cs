using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SF_QuanLyBanHang_05Nov21
{
    class HoaDonBanAction
    {
        //Khai bao list
        private List<HoaDonBan> lstHDBan = new List<HoaDonBan>();

        //Ham lay danh sach
        public DataTable LayDanhSach()
        {
            string strSQL = "Select * from hoadonban";

            return DataProvider.LayDanhSach(strSQL);
        }

        //Ham lay chi tiet theo ma
        public HoaDonBan LayChiTiet(string id)
        {
            HoaDonBan objKH = null;

            string strSQL = "Select * from hoadonban where hoadonban_id = '" + id + "'";

            DataTable data = DataProvider.LayDanhSach(strSQL);

            if (data.Rows.Count > 0)
            {
                objKH = new HoaDonBan();
                objKH.hdBan_id = (int)data.Rows[0]["hoadonmua_id"];
                objKH.hdBan_number = data.Rows[0]["hoadonmua_number"] + "";
                objKH.hdBan_date = (DateTime) data.Rows[0]["hoadonmua_date"];
                objKH.hdBan_type = data.Rows[0]["hoadonmua_type"] + "";
                objKH.hdBan_detail = data.Rows[0]["hoadonmua_detail"] + "";
                objKH.khachhangId = (int) data.Rows[0]["khachhang_id"];
            }
            return objKH;
        }

        //Ham them moi
        public bool ThemMoi(HoaDonBan objKH)
        {
            string strInsert = "Insert into hoadonban(hoadonban_number, hoadonban_date, hoadonban_type, hoadonban_detail, khachhang_id) values (@hdmuano, @hdmuadate, @hdmuatype, @hdmuadetail, @khachhangid)";

            SqlParameter[] pars = new SqlParameter[5];

            //Khoi tao va gan gia tri cho tham so
            pars[0] = new SqlParameter("@hdmuano", SqlDbType.VarChar, 20);
            pars[0].Value = objKH.hdBan_number;

            pars[1] = new SqlParameter("@hdmuadate", SqlDbType.DateTime);
            pars[1].Value = objKH.hdBan_date;

            pars[2] = new SqlParameter("@hdmuatype", SqlDbType.NVarChar, 20);
            pars[2].Value = objKH.hdBan_type;

            pars[3] = new SqlParameter("@hdmuadetail", SqlDbType.NVarChar, 200);
            pars[3].Value = objKH.hdBan_detail;

            pars[4] = new SqlParameter("@khachhangid", SqlDbType.VarChar, 10);
            pars[4].Value = objKH.khachhangId;

            return DataProvider.ThucHien(strInsert, pars);
        }

        //Ham cap nhat
        public bool CapNhat(HoaDonBan objKH)
        {
            string strUpdate = "Update hoadonban set hoadonban_number=@hdmuano, hoadonban_date=@hdmuadate, hoadonban_type=@hdmuatype, hoadonban_detail=@hdmuadetail, khachhang_id=@khachhangid where hoadonban_id=@id";

            SqlParameter[] pars = new SqlParameter[6];

            //Khoi tao va gan gia tri cho tham so
            pars[0] = new SqlParameter("@hdmuano", SqlDbType.VarChar, 20);
            pars[0].Value = objKH.hdBan_number;

            pars[1] = new SqlParameter("@hdmuadate", SqlDbType.DateTime);
            pars[1].Value = objKH.hdBan_date;

            pars[2] = new SqlParameter("@hdmuatype", SqlDbType.NVarChar, 20);
            pars[2].Value = objKH.hdBan_type;

            pars[3] = new SqlParameter("@hdmuadetail", SqlDbType.NVarChar, 200);
            pars[3].Value = objKH.hdBan_detail;

            pars[4] = new SqlParameter("@khachhangid", SqlDbType.VarChar, 10);
            pars[4].Value = objKH.khachhangId;

            pars[5] = new SqlParameter("@id", SqlDbType.Int);
            pars[5].Value = objKH.hdBan_id;

            return DataProvider.ThucHien(strUpdate, pars);
        }

        //Ham xoa
        public bool Xoa(string id)
        {
            string strDelete = "Delete from hoadonban where hoadonban_id=@id";

            SqlParameter[] pars = new SqlParameter[1];

            //Khoi tao va gan gia tri cho tham so
            pars[0] = new SqlParameter("@id", SqlDbType.Int);
            pars[0].Value = id;


            return DataProvider.ThucHien(strDelete, pars);
        }
    }
}
