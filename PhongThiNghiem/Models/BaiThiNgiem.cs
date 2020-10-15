using System.Collections.Generic;

namespace PhongThiNghiem.Models
{
    public class BaiThiNgiem
    {
        public int Id { get; set; }
        public string TenBai { get; set; }
        public string NoiDung { get; set; }
        public virtual List<GV_BaiThiNghiem> GiaoViens { get; set; }
    }
}