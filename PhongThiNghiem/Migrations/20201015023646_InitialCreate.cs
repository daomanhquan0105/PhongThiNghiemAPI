using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace PhongThiNghiem.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "BaiThiNgiems",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TenBai = table.Column<string>(nullable: true),
                    NoiDung = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BaiThiNgiems", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "GiaoViens",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TenGV = table.Column<string>(nullable: true),
                    NgaySinh = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GiaoViens", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "LoaiThietBis",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TenLoaiTB = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LoaiThietBis", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "GV_BaiThiNghiems",
                columns: table => new
                {
                    GVId = table.Column<int>(nullable: false),
                    BaiTNId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GV_BaiThiNghiems", x => new { x.BaiTNId, x.GVId });
                    table.ForeignKey(
                        name: "FK_GV_BaiThiNghiems_BaiThiNgiems_BaiTNId",
                        column: x => x.BaiTNId,
                        principalTable: "BaiThiNgiems",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_GV_BaiThiNghiems_GiaoViens_GVId",
                        column: x => x.GVId,
                        principalTable: "GiaoViens",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PhieuMuons",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NgayMuon = table.Column<DateTime>(nullable: false),
                    NgayTra = table.Column<DateTime>(nullable: false),
                    GiaoVienId = table.Column<int>(nullable: false),
                    DaTra = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PhieuMuons", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PhieuMuons_GiaoViens_GiaoVienId",
                        column: x => x.GiaoVienId,
                        principalTable: "GiaoViens",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ThietBis",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TenTB = table.Column<string>(nullable: true),
                    ChucNang = table.Column<string>(nullable: true),
                    LoaiThieBiId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ThietBis", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ThietBis_LoaiThietBis_LoaiThieBiId",
                        column: x => x.LoaiThieBiId,
                        principalTable: "LoaiThietBis",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ChiTietPhieuMuons",
                columns: table => new
                {
                    PhieuMuonId = table.Column<int>(nullable: false),
                    ThietBiId = table.Column<int>(nullable: false),
                    SoLuong = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ChiTietPhieuMuons", x => new { x.PhieuMuonId, x.ThietBiId });
                    table.ForeignKey(
                        name: "FK_ChiTietPhieuMuons_PhieuMuons_PhieuMuonId",
                        column: x => x.PhieuMuonId,
                        principalTable: "PhieuMuons",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ChiTietPhieuMuons_ThietBis_ThietBiId",
                        column: x => x.ThietBiId,
                        principalTable: "ThietBis",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ChiTietPhieuMuons_ThietBiId",
                table: "ChiTietPhieuMuons",
                column: "ThietBiId");

            migrationBuilder.CreateIndex(
                name: "IX_GV_BaiThiNghiems_GVId",
                table: "GV_BaiThiNghiems",
                column: "GVId");

            migrationBuilder.CreateIndex(
                name: "IX_PhieuMuons_GiaoVienId",
                table: "PhieuMuons",
                column: "GiaoVienId");

            migrationBuilder.CreateIndex(
                name: "IX_ThietBis_LoaiThieBiId",
                table: "ThietBis",
                column: "LoaiThieBiId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ChiTietPhieuMuons");

            migrationBuilder.DropTable(
                name: "GV_BaiThiNghiems");

            migrationBuilder.DropTable(
                name: "PhieuMuons");

            migrationBuilder.DropTable(
                name: "ThietBis");

            migrationBuilder.DropTable(
                name: "BaiThiNgiems");

            migrationBuilder.DropTable(
                name: "GiaoViens");

            migrationBuilder.DropTable(
                name: "LoaiThietBis");
        }
    }
}
