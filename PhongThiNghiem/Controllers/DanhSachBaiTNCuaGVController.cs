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
    public class DanhSachBaiTNCuaGVController : ControllerBase
    {
        private readonly ApplicationDbContext _db;
        public DanhSachBaiTNCuaGVController(ApplicationDbContext db)
        {
            _db = db;
        }
        [HttpGet("")]
        public async Task<IActionResult> GetAction(int GVId)
        {
            var Gv = _db.GiaoViens.SingleOrDefault(x => x.Id == GVId);
            if (Gv == null) return Ok("không tìm thấy giao viên theo ID đã nhập");

            var gV_BaiThiNghiems = _db.GV_BaiThiNghiems.Where(x => x.GVId == GVId);
            if (gV_BaiThiNghiems.Count() == 0) return Ok("Giáo viên bạn vừa tìm chưa nhận bài thí nghiêm nào!!");

            List<BaiThiNgiem> model = new List<BaiThiNgiem>();
            foreach (GV_BaiThiNghiem bai in gV_BaiThiNghiems)
            {
                model.Add(bai.BaiThiNgiem);
            }
            return Ok(model);
        }
    }
}