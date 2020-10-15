using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PhongThiNghiem.Models
{
    public class GiaoVien
    {
        [Key]
        public int Id { get; set; }
        public string TenGV { get; set; }
        public DateTime NgaySinh { get; set; }
        public virtual List<GV_BaiThiNghiem> BaiThiNgiems { get; set; }
    }
}