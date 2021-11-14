using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SF_QuanLyBanHang_05Nov21
{
    class HoaDonBan
    {
        public int hdBan_id { get; set; }
        public string hdBan_number { get; set; }
        public DateTime hdBan_date { get; set; }
        public string hdBan_type { get; set; }
        public string hdBan_detail { get; set; }
        public int khachhangId { get; set; }
    }
}
