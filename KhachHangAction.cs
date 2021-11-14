using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SF_QuanLyBanHang_05Nov21
{
    class KhachHangAction
    {
        //Khai bao list
        private List<KhachHang> lstKhachHang = new List<KhachHang>();

        //Ham lay danh sach
        public DataTable LayDanhSach()
        {
            string strSQL = "Select * from khachhang";

            return DataProvider.LayDanhSach(strSQL);
        }

        //Ham lay chi tiet theo ma
        public KhachHang LayChiTiet(string id)
        {
            KhachHang objKH = null;

            string strSQL = "Select * from khachhang where khachhang_id = '" + id + "'";

            DataTable data = DataProvider.LayDanhSach(strSQL);

            if(data.Rows.Count > 0)
            {
                objKH = new KhachHang();
                objKH.khachhang_id = (int) data.Rows[0]["khachhang_id"];
                objKH.khachhang_name = data.Rows[1]["khachhang_name"] + "";
                objKH.khachhang_gender = (int) data.Rows[2]["khachhang_gender"];
                objKH.khachhang_dob = (DateTime) data.Rows[3]["khachhang_dob"];
                objKH.khachhang_phone = data.Rows[4]["khachhang_phone"] + "";
                objKH.khachhang_email = data.Rows[5]["khachhang_email"] + "";
                objKH.khachhang_address = data.Rows[6]["khachhang_address"] + "";
                objKH.khachhang_congtyid = data.Rows[7]["khachhang_congtyid"] + "";
                objKH.khachhang_identityno = data.Rows[8]["khachhang_identityno"] + "";
                objKH.khachhang_identitydoi = (DateTime)data.Rows[9]["khachhang_identity_doi"];
                objKH.khachhang_identitypoi = data.Rows[10]["khachhang_identity_poi"] + "";
            }
            return objKH;
        }

        //Ham them moi
        public bool ThemMoi(KhachHang objKH)
        {
            string strInsert = "Insert into khachhang(khachhang_name, khachhang_gender, khachhang_dob, khachhang_phone, khachhang_email, khachhang_address, khachhang_contyid, khachhang_identityno, khachhang_identity_doi, khachhang_identity_poi) values (@name, @gender, @dob, @phone, @email, @address, @congtyid, @identityno, @identitydoi, @identitypoi)";

            SqlParameter[] pars = new SqlParameter[10];

            //Khoi tao va gan gia tri cho tham so
            pars[0] = new SqlParameter("@name", SqlDbType.NVarChar, 50);
            pars[0].Value = objKH.khachhang_name;

            pars[1] = new SqlParameter("@gender", SqlDbType.TinyInt);
            pars[1].Value = objKH.khachhang_gender;

            pars[2] = new SqlParameter("@dob", SqlDbType.DateTime);
            pars[2].Value = objKH.khachhang_dob;

            pars[3] = new SqlParameter("@phone", SqlDbType.VarChar, 30);
            pars[3].Value = objKH.khachhang_phone;

            pars[4] = new SqlParameter("@email", SqlDbType.VarChar, 50);
            pars[4].Value = objKH.khachhang_email;

            pars[5] = new SqlParameter("@address", SqlDbType.NVarChar, 200);
            pars[5].Value = objKH.khachhang_address;

            pars[6] = new SqlParameter("@congtyid", SqlDbType.VarChar, 10);
            pars[6].Value = objKH.khachhang_congtyid;

            pars[7] = new SqlParameter("@identityno", SqlDbType.VarChar, 20);
            pars[7].Value = objKH.khachhang_identityno;

            pars[8] = new SqlParameter("@identitydoi", SqlDbType.DateTime);
            pars[8].Value = objKH.khachhang_identitydoi;

            pars[9] = new SqlParameter("@identitypoi", SqlDbType.NVarChar, 200);
            pars[9].Value = objKH.khachhang_identitypoi;

            return DataProvider.ThucHien(strInsert, pars);
        }

        //Ham cap nhat
        public bool CapNhat(KhachHang objKH)
        {
            string strUpdate = "Update khachhang set khachhang_name=@name, khachhang_gender=@gender, khachhang_dob=@dob, khachhang_phone=@phone, khachhang_email=@email, khachhang_address=@address, khachhang_congtyid=@congtyid, khachhang_identityno=@identityno, khachhang_identity_doi=@identitydoi, khachhang_identity_poi=@identitypoi where khachhang_id=@id";

            SqlParameter[] pars = new SqlParameter[11];

            //Khoi tao va gan gia tri cho tham so
            pars[0] = new SqlParameter("@name", SqlDbType.NVarChar, 50);
            pars[0].Value = objKH.khachhang_name;

            pars[1] = new SqlParameter("@gender", SqlDbType.TinyInt);
            pars[1].Value = objKH.khachhang_gender;

            pars[2] = new SqlParameter("@dob", SqlDbType.DateTime);
            pars[2].Value = objKH.khachhang_dob;

            pars[3] = new SqlParameter("@phone", SqlDbType.VarChar, 30);
            pars[3].Value = objKH.khachhang_phone;

            pars[4] = new SqlParameter("@email", SqlDbType.VarChar, 50);
            pars[4].Value = objKH.khachhang_email;

            pars[5] = new SqlParameter("@address", SqlDbType.NVarChar, 200);
            pars[5].Value = objKH.khachhang_address;

            pars[6] = new SqlParameter("@congtyid", SqlDbType.VarChar, 10);
            pars[6].Value = objKH.khachhang_congtyid;

            pars[7] = new SqlParameter("@identityno", SqlDbType.VarChar, 20);
            pars[7].Value = objKH.khachhang_identityno;

            pars[8] = new SqlParameter("@identitydoi", SqlDbType.DateTime);
            pars[8].Value = objKH.khachhang_identitydoi;

            pars[9] = new SqlParameter("@identitypoi", SqlDbType.NVarChar, 200);
            pars[9].Value = objKH.khachhang_identitypoi;

            pars[10] = new SqlParameter("@id", SqlDbType.Int);
            pars[10].Value = objKH.khachhang_id;

            return DataProvider.ThucHien(strUpdate, pars);
        }

        //Ham xoa
        public bool Xoa(string id)
        {
            string strDelete = "Delete from khachhang where khachhang_id=@id";

            SqlParameter[] pars = new SqlParameter[1];

            //Khoi tao va gan gia tri cho tham so
            pars[0] = new SqlParameter("@id", SqlDbType.Int);
            pars[0].Value = id;


            return DataProvider.ThucHien(strDelete, pars);
        }
    }
}
