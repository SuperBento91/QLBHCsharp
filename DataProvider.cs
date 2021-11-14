using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SF_QuanLyBanHang_05Nov21
{
    class DataProvider
    {
        private static string ConnectString = @"Server=Michael-s\SQLEXPRESS; Database=SF_Quanlybanhang_05Nov21; Uid=hungnth; Pwd=123;";
        /// <summary>
        /// Lấy danh sách từ db
        /// </summary>
        /// <param name="strSQL">Câu lệnh</param>
        /// <param name="pars">Tham số nếu có</param>
        /// <returns></returns>
        public static DataTable LayDanhSach(string strSQL, SqlParameter[] pars = null)
        {
            //Khai bao 1 danh sach
            DataTable dt = new DataTable();

            //Khai bao 1 doi tuong
            SqlConnection conn = new SqlConnection(ConnectString);

            try
            {
                //Mo ket noi
                conn.Open();

                //Khai bao 1 doi tuong
                SqlCommand comm = new SqlCommand();
                comm.Connection = conn;
                comm.CommandType = CommandType.Text;
                comm.CommandText = strSQL;

                if(pars != null && pars.Length > 0)
                {
                    comm.Parameters.AddRange(pars);
                }
                //Khai bao doi tuong de chua du lieu
                SqlDataAdapter adapter = new SqlDataAdapter(comm);

                //Day du lieu vao table
                adapter.Fill(dt);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Có lỗi xảy ra: " + ex);
            }
            finally
            {
                //Dong ket noi
                conn.Close();
            }
            return dt;
        }
        /// <summary>
        /// Thực hiện công việc thêm mới, sửa, xóa thao tác với db
        /// </summary>
        /// <param name="strSQL">Câu lệnh cần thực hiện</param>
        /// <param name="pars">Tham số của câu lệnh nếu có</param>
        /// <returns>true nếu thành công / false nếu thất bại</returns>
        public static bool ThucHien(string strSQL, SqlParameter[] pars = null)
        {
            //Khai bao bien chua ket qua
            bool isKetQua = false;

            //Khai bao 1 doi tuong
            SqlConnection conn = new SqlConnection(ConnectString);

            try
            {
                //Mo ket noi
                conn.Open();

                //Khai bao 1 doi tuong
                SqlCommand comm = new SqlCommand();
                comm.Connection = conn;
                comm.CommandType = CommandType.Text;
                comm.CommandText = strSQL;

                if (pars != null && pars.Length > 0)
                {
                    comm.Parameters.AddRange(pars);
                }

                //Thuc hien cong viec
                isKetQua = comm.ExecuteNonQuery() > 0;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Có lỗi xảy ra: " + ex);
            }
            finally
            {
                //Dong ket noi
                conn.Close();
            }
            return isKetQua;
        }

        private static XuatXuAction _XuatXuAct = null;
        private static SanPhamAction _SanPhamAct = null;
        private static KhachHangAction _KhachHangAct = null;
        private static HoaDonMuaAction _HoaDonMuaAct = null;
        private static HoaDonMuaCTAction _HoaDonMuaCTAct = null;
        private static HoaDonBanAction _HoaDonBanAct = null;
        private static HoaDonBanCTAction _HoaDonBanCTAct = null;
        public static XuatXuAction XuatXuAct
        {
            get
            {
                if(_XuatXuAct == null)
                {
                    _XuatXuAct = new XuatXuAction();
                }
                return _XuatXuAct;
            }
        }

        public static SanPhamAction SanPhamAct
        {
            get
            {
                if(_SanPhamAct == null)
                {
                    _SanPhamAct = new SanPhamAction();
                }
                return _SanPhamAct;
            }
        }

        public static KhachHangAction KhachHangAct
        {
            get
            {
                if(_KhachHangAct == null)
                {
                    _KhachHangAct = new KhachHangAction();
                }
                return _KhachHangAct;
            }
        }

        public static HoaDonMuaAction HDMuaAct
        {
            get
            {
                if (_HoaDonMuaAct == null)
                {
                    _HoaDonMuaAct = new HoaDonMuaAction();
                }
                return _HoaDonMuaAct;
            }
        }

        public static HoaDonBanAction HDBanAct
        {
            get
            {
                if (_HoaDonBanAct == null)
                {
                    _HoaDonBanAct = new HoaDonBanAction();
                }
                return _HoaDonBanAct;
            }
        }

        public static HoaDonMuaCTAction HDMuaCTAct
        {
            get
            {
                if (_HoaDonMuaCTAct == null)
                {
                    _HoaDonMuaCTAct = new HoaDonMuaCTAction();
                }
                return _HoaDonMuaCTAct;
            }
        }

        public static HoaDonBanCTAction HDBanCTAct
        {
            get
            {
                if (_HoaDonBanCTAct == null)
                {
                    _HoaDonBanCTAct = new HoaDonBanCTAction();
                }
                return _HoaDonBanCTAct;
            }
        }
    }
}
