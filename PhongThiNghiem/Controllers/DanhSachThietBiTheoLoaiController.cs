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
    public class DanhSachThietBiTheoLoaiController : ControllerBase
    {
        private readonly ApplicationDbContext _db;
        public DanhSachThietBiTheoLoaiController(ApplicationDbContext db)
        {
            _db = db;
        }
        [HttpGet]
        public async Task<IActionResult> GetAction(int LoaiId)
        {
            var loaiTB = _db.LoaiThietBis.SingleOrDefault(x => x.id == LoaiId);
            if (loaiTB == null) return Ok("không tìm thấy loại thiết bị bạn vừa nhập");

            var ListTB = _db.ThietBis.Where(x => x.LoaiThieBiId == LoaiId);
            if (ListTB.Count() == 0) return Ok("Loại thiết bị bạn vừa tìm không có thiết thị nào");

            return Ok(ListTB);
        }
    }
}