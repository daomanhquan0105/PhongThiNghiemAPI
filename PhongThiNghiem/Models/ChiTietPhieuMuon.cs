using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace PhongThiNghiem.Models
{
    public class ChiTietPhieuMuon
    {
        public int PhieuMuonId { get; set; }
        public int ThietBiId { get; set; }
        public int SoLuong { get; set; }
        [ForeignKey("PhieuMuonId")]
        public virtual PhieuMuon PhieuMuon { get; set; }
        [ForeignKey("ThietBiId")]
        public virtual ThietBi ThietBi { get; set; }
    }
}