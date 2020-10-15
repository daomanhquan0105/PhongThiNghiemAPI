using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PhongThiNghiem.Models
{
    public class LoaiThietBi
    {
        [Key]
        public int id { get; set; }
        public string TenLoaiTB { get; set; }
        public virtual List<ThietBi> ThietBis { get; set; }
    }
}