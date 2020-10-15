using System.ComponentModel.DataAnnotations.Schema;

namespace PhongThiNghiem.Models
{
    public class GV_BaiThiNghiem
    {
        public int GVId { get; set; }
        public int BaiTNId { get; set; }

        [ForeignKey("GVId")]
        public virtual GiaoVien GiaoVien { get; set; }

        [ForeignKey("BaiTNId")]
        public virtual BaiThiNgiem BaiThiNgiem { get; set; }
    }
}