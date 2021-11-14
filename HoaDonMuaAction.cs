using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SF_QuanLyBanHang_05Nov21
{
    class HoaDonMuaAction
    {
        //Khai bao list
        private List<HoaDonMua> lstHDMua = new List<HoaDonMua>();

        //Ham lay danh sach
        public DataTable LayDanhSach(DateTime fromDate, DateTime toDate)
        {
            string strSQL = "Select * from hoadonmua where hoadonmua_date between '" + fromDate +"' and '" + toDate + "'";

            return DataProvider.LayDanhSach(strSQL);
        }

        //Ham lay chi tiet theo ma
        public HoaDonMua LayChiTiet(string id)
        {
            HoaDonMua objKH = null;

            string strSQL = "Select * from hoadonmua where hoadonmua_id = '" + id + "'";

            DataTable data = DataProvider.LayDanhSach(strSQL);

            if (data.Rows.Count > 0)
            {
                objKH = new HoaDonMua();
                objKH.hdMua_id = (int)data.Rows[0]["hoadonmua_id"];
                objKH.hdMua_number = data.Rows[0]["hoadonmua_number"] + "";
                objKH.hdMua_date = (DateTime) data.Rows[0]["hoadonmua_date"];
                objKH.hdMua_type = data.Rows[0]["hoadonmua_type"] + "";
                objKH.hdMua_detail = data.Rows[0]["hoadonmua_detail"] + "";
                objKH.congtyId = data.Rows[0]["congty_id"] + "";
            }
            return objKH;
        }

        //Ham them moi
        public bool ThemMoi(HoaDonMua objKH)
        {
            string strInsert = "Insert into hoadonmua(hoadonmua_number, hoadonmua_date, hoadonmua_type, hoadonmua_detail, congty_id) values (@hdmuano, @hdmuadate, @hdmuatype, @hdmuadetail, @congtyid)";

            SqlParameter[] pars = new SqlParameter[5];

            //Khoi tao va gan gia tri cho tham so
            pars[0] = new SqlParameter("@hdmuano", SqlDbType.VarChar, 20);
            pars[0].Value = objKH.hdMua_number;

            pars[1] = new SqlParameter("@hdmuadate", SqlDbType.DateTime);
            pars[1].Value = objKH.hdMua_date;

            pars[2] = new SqlParameter("@hdmuatype", SqlDbType.NVarChar, 20);
            pars[2].Value = objKH.hdMua_type;

            pars[3] = new SqlParameter("@hdmuadetail", SqlDbType.NVarChar, 200);
            pars[3].Value = objKH.hdMua_detail;

            pars[4] = new SqlParameter("@congtyid", SqlDbType.VarChar, 10);
            pars[4].Value = objKH.congtyId;

            return DataProvider.ThucHien(strInsert, pars);
        }

        //Ham cap nhat
        public bool CapNhat(HoaDonMua objKH)
        {
            string strUpdate = "Update hoadonmua set hoadonmua_number=@hdmuano, hoadonmua_date=@hdmuadate, hoadonmua_type=@hdmuatype, hoadonmua_detail=@hdmuadetail, congty_id=@congtyid where hoadonmua_id=@id";

            SqlParameter[] pars = new SqlParameter[6];

            //Khoi tao va gan gia tri cho tham so
            pars[0] = new SqlParameter("@hdmuano", SqlDbType.VarChar, 10);
            pars[0].Value = objKH.hdMua_number;

            pars[1] = new SqlParameter("@hdmuadate", SqlDbType.DateTime);
            pars[1].Value = objKH.hdMua_date;

            pars[2] = new SqlParameter("@hdmuatype", SqlDbType.NVarChar, 20);
            pars[2].Value = objKH.hdMua_type;

            pars[3] = new SqlParameter("@hdmuadetail", SqlDbType.NVarChar, 200);
            pars[3].Value = objKH.hdMua_detail;

            pars[4] = new SqlParameter("@congtyid", SqlDbType.VarChar, 10);
            pars[4].Value = objKH.congtyId;

            pars[5] = new SqlParameter("@id", SqlDbType.Int);
            pars[5].Value = objKH.hdMua_id;

            return DataProvider.ThucHien(strUpdate, pars);
        }

        //Ham xoa
        public bool Xoa(string id)
        {
            string strDelete = "Delete from hoadonmua where hoadonmua_id=@id";

            SqlParameter[] pars = new SqlParameter[1];

            //Khoi tao va gan gia tri cho tham so
            pars[0] = new SqlParameter("@id", SqlDbType.Int);
            pars[0].Value = id;


            return DataProvider.ThucHien(strDelete, pars);
        }
    }
}
