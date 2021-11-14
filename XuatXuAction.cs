using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SF_QuanLyBanHang_05Nov21
{
    class XuatXuAction
    {
        //Khai bao list
        private List<XuatXu> lstXuatXu = new List<XuatXu>();

        //Ham lay danh sach
        public DataTable LayDanhSach()
        {
            string strSQL = "Select xuatxu_id, xuatxu_name from xuatxu";

            return DataProvider.LayDanhSach(strSQL);
        }

        //Ham lay chi tiet theo ma
        public XuatXu LayChiTiet(string id)
        {
            XuatXu objXX = null;

            string strSQL = "Select * from xuatxu where xuatxu_id = '" + id + "'";

            DataTable dtXX = DataProvider.LayDanhSach(strSQL);

            if(dtXX.Rows.Count > 0)
            {
                objXX = new XuatXu();
                objXX.xuatXuId = dtXX.Rows[0]["xuatxu_id"] + "";
                objXX.xuatXuName = dtXX.Rows[1]["xuatxu_name"] + "";
            }
            return objXX;
        }

        //Ham them moi
        public bool ThemMoi(XuatXu objXX)
        {
            string strInsert = "Insert into xuatxu(xuatxu_id, xuatxu_name) values (@xuatxuid, @xuatxuname)";

            SqlParameter[] pars = new SqlParameter[2];

            //Khoi tao va gan gia tri cho tham so
            pars[0] = new SqlParameter("@xuatxuid", SqlDbType.VarChar, 10);
            pars[0].Value = objXX.xuatXuId;

            pars[1] = new SqlParameter("@xuatxuname", SqlDbType.NVarChar, 100);
            pars[1].Value = objXX.xuatXuName;

            return DataProvider.ThucHien(strInsert, pars);
        }

        //Ham cap nhat
        public bool CapNhat(XuatXu objXX)
        {
            string strUpdate = "Update xuatxu set xuatxu_name=@xuatxuname where xuatxu_id=@xuatxuid";

            SqlParameter[] pars = new SqlParameter[2];

            //Khoi tao va gan gia tri cho tham so
            pars[0] = new SqlParameter("@xuatxuname", SqlDbType.NVarChar, 100);
            pars[0].Value = objXX.xuatXuName;

            pars[1] = new SqlParameter("@xuatxuid", SqlDbType.VarChar, 10);
            pars[1].Value = objXX.xuatXuId;

            return DataProvider.ThucHien(strUpdate, pars);
        }

        //Ham xoa
        public bool Xoa(string id)
        {
            string strDelete = "Delete from xuatxu where xuatxu_id=@xuatxuid";

            SqlParameter[] pars = new SqlParameter[1];

            //Khoi tao va gan gia tri cho tham so
            pars[0] = new SqlParameter("@xuatxuid", SqlDbType.VarChar, 10);
            pars[0].Value = id;


            return DataProvider.ThucHien(strDelete, pars);
        }
    }
}
