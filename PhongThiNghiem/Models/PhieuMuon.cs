using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace PhongThiNghiem.Models
{
    public class PhieuMuon
    {
        [Key]
        public int Id { get; set; }
        public DateTime NgayMuon { get; set; }
        public DateTime NgayTra { get; set; }
        public int GiaoVienId { get; set; }
        public bool DaTra { get; set; }

        [ForeignKey("GiaoVienId")]
        public virtual GiaoVien GiaoVien { get; set; }

        public virtual List<ChiTietPhieuMuon> ChiTietPhieuMuons { get; set; }
    }
}