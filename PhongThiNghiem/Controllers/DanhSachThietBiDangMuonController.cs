using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PhongThiNghiem.Models;

namespace Namespace
{
    [Route("api/[controller]")]
    [ApiController]
    public class DanhSachThietBiDangMuonController : ControllerBase
    {
        private readonly ApplicationDbContext _db;
        public DanhSachThietBiDangMuonController(ApplicationDbContext db)
        {
            _db = db;
        }
        [HttpGet]
        public async Task<IActionResult> GetAction()
        {

            var ListPMSapCha = _db.PhieuMuons.Where(x => x.DaTra == false && x.NgayTra >= DateTime.Now);
            if (ListPMSapCha.Count() == 0) return Ok("Không có thiết bị nào đang được muộn");

            List<ThietBi> thietBis = new List<ThietBi>();
            foreach (PhieuMuon phieuMuon in ListPMSapCha)
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