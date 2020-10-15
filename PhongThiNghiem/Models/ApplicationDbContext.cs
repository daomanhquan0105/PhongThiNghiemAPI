using Microsoft.EntityFrameworkCore;

namespace PhongThiNghiem.Models
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<GV_BaiThiNghiem>().HasKey(x => new { x.BaiTNId, x.GVId });
            modelBuilder.Entity<ChiTietPhieuMuon>().HasKey(x => new { x.PhieuMuonId, x.ThietBiId });
        }
        public DbSet<LoaiThietBi> LoaiThietBis { get; set; }
        public DbSet<ThietBi> ThietBis { get; set; }
        public DbSet<GiaoVien> GiaoViens { get; set; }
        public DbSet<BaiThiNgiem> BaiThiNgiems { get; set; }
        public DbSet<GV_BaiThiNghiem> GV_BaiThiNghiems { get; set; }
        public DbSet<PhieuMuon> PhieuMuons { get; set; }
        public DbSet<ChiTietPhieuMuon> ChiTietPhieuMuons { get; set; }
    }
}