using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PhongThiNghiem.Models;

namespace PhongThiNghiem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DanhSachThietBiQuaHanController : ControllerBase
    {
        private readonly ApplicationDbContext _db;
        public DanhSachThietBiQuaHanController(ApplicationDbContext db)
        {
            _db = db;
        }

        [HttpGet]
        public async Task<IActionResult> GetAction()
        {
            var ListTBMuonHetHan = _db.PhieuMuons.Where(x => x.DaTra == false && x.NgayTra < DateTime.Now);
            if (ListTBMuonHetHan.Count() == 0) return Ok("Không có thiết bị nào quá hạn mà chưa chả");

            List<ThietBi> thietBis = new List<ThietBi>();
            foreach (PhieuMuon phieuMuon in ListTBMuonHetHan)
            {
                if (phieuMuon.ChiTietPhieuMuons.Count() > 0)
                {
                    foreach (ChiTietPhieuMuon chiTietPhieu in phieuMuon.ChiTietPhieuMuons)
                    {
                        thietBis.Add(chiTietPhieu.ThietBi);
                    }
                }
            }
            return Ok(thietBis);
        }
    }
}