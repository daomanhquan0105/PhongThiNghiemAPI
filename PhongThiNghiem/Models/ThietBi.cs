using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PhongThiNghiem.Models
{
    public class ThietBi
    {
        [Key]
        public int Id { get; set; }
        public string TenTB { get; set; }
        public string ChucNang { get; set; }
        public int SoLuong { get; set; }
        public int LoaiThieBiId { get; set; }

        [ForeignKey("LoaiThieBiId")]
        public virtual LoaiThietBi LoaiThietBi { get; set; }
    }
}